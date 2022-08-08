//===============================================================================
// TinyIoC
//
// An easy to use, hassle free, Inversion of Control Container for small projects
// and beginners alike.
//
// https://github.com/grumpydev/TinyIoC
//===============================================================================
// Copyright © Steven Robbins.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

#nullable disable //HatTrick added

namespace TinyIoC
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    #region SafeDictionary
    internal class SafeDictionary<TKey, TValue> : IDisposable
    {
        private readonly ReaderWriterLockSlim _padlock = new ReaderWriterLockSlim();
        private readonly Dictionary<TKey, TValue> _Dictionary = new Dictionary<TKey, TValue>();

        public bool ContainsKey(TKey key)
        {
            _padlock.EnterWriteLock();

            try
            {
                return _Dictionary.ContainsKey(key);
            }
            finally
            {
                _padlock.ExitWriteLock();
            }
        }

        public TValue this[TKey key]
        {
            set
            {
                _padlock.EnterWriteLock();

                try
                {
                    TValue current;
                    if (_Dictionary.TryGetValue(key, out current))
                    {
                        var disposable = current as IDisposable;

                        if (disposable != null)
                            disposable.Dispose();
                    }

                    _Dictionary[key] = value;
                }
                finally
                {
                    _padlock.ExitWriteLock();
                }
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            _padlock.EnterReadLock();
            try
            {
                return _Dictionary.TryGetValue(key, out value);
            }
            finally
            {
                _padlock.ExitReadLock();
            }
        }

        public bool Remove(TKey key)
        {
            _padlock.EnterWriteLock();
            try
            {
                return _Dictionary.Remove(key);
            }
            finally
            {
                _padlock.ExitWriteLock();
            }
        }

        public void Clear()
        {
            _padlock.EnterWriteLock();
            try
            {
                _Dictionary.Clear();
            }
            finally
            {
                _padlock.ExitWriteLock();
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                _padlock.EnterReadLock();
                try
                {
                    return new List<TKey>(_Dictionary.Keys);
                }
                finally
                {
                    _padlock.ExitReadLock();
                }
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            _padlock.EnterWriteLock();

            try
            {
                var disposableItems = from item in _Dictionary.Values
                                      where item is IDisposable
                                      select item as IDisposable;

                foreach (var item in disposableItems)
                {
                    item.Dispose();
                }
            }
            finally
            {
                _padlock.ExitWriteLock();
            }

            GC.SuppressFinalize(this);
        }

        #endregion
    }
    #endregion

    #region Extensions
    internal static class AssemblyExtensions
    {
        public static Type[] SafeGetTypes(this Assembly assembly)
        {
            Type[] assemblies;

            try
            {
                assemblies = assembly.GetTypes();
            }
            catch (System.IO.FileNotFoundException)
            {
                assemblies = new Type[] { };
            }
            catch (NotSupportedException)
            {
                assemblies = new Type[] { };
            }
            catch (ReflectionTypeLoadException e)
            {
                assemblies = e.Types.Where(t => t != null).ToArray();
            }
            return assemblies;
        }
    }

    internal static class TypeExtensions
    {
        private static SafeDictionary<GenericMethodCacheKey, MethodInfo> _genericMethodCache;

        static TypeExtensions()
        {
            _genericMethodCache = new SafeDictionary<GenericMethodCacheKey, MethodInfo>();
        }

        /// <summary>
        /// Gets a generic method from a type given the method name, binding flags, generic types and parameter types
        /// </summary>
        /// <param name="sourceType">Source type</param>
        /// <param name="bindingFlags">Binding flags</param>
        /// <param name="methodName">Name of the method</param>
        /// <param name="genericTypes">Generic types to use to make the method generic</param>
        /// <param name="parameterTypes">Method parameters</param>
        /// <returns>MethodInfo or null if no matches found</returns>
        /// <exception cref="System.Reflection.AmbiguousMatchException"/>
        /// <exception cref="System.ArgumentException"/>
        public static MethodInfo GetGenericMethod(this Type sourceType, BindingFlags bindingFlags, string methodName, Type[] genericTypes, Type[] parameterTypes)
        {
            MethodInfo method;
            var cacheKey = new GenericMethodCacheKey(sourceType, methodName, genericTypes, parameterTypes);

            // Shouldn't need any additional locking
            // we don't care if we do the method info generation
            // more than once before it gets cached.
            if (!_genericMethodCache.TryGetValue(cacheKey, out method))
            {
                method = GetMethod(sourceType, bindingFlags, methodName, genericTypes, parameterTypes);
                _genericMethodCache[cacheKey] = method;
            }

            return method;
        }
        //#endif

        private static MethodInfo GetMethod(Type sourceType, BindingFlags bindingFlags, string methodName, Type[] genericTypes, Type[] parameterTypes)
        {
            var methods =
                      sourceType.GetMethods(bindingFlags).Where(
                          mi => string.Equals(methodName, mi.Name, StringComparison.Ordinal)).Where(
                              mi => mi.ContainsGenericParameters).Where(mi => mi.GetGenericArguments().Length == genericTypes.Length).
                          Where(mi => mi.GetParameters().Length == parameterTypes.Length).Select(
                              mi => mi.MakeGenericMethod(genericTypes)).Where(
                                  mi => mi.GetParameters().Select(pi => pi.ParameterType).SequenceEqual(parameterTypes)).ToList();
            if (methods.Count > 1)
            {
                throw new AmbiguousMatchException();
            }

            return methods.FirstOrDefault();
        }

        private sealed class GenericMethodCacheKey
        {
            private readonly Type _sourceType;

            private readonly string _methodName;

            private readonly Type[] _genericTypes;

            private readonly Type[] _parameterTypes;

            private readonly int _hashCode;

            public GenericMethodCacheKey(Type sourceType, string methodName, Type[] genericTypes, Type[] parameterTypes)
            {
                _sourceType = sourceType;
                _methodName = methodName;
                _genericTypes = genericTypes;
                _parameterTypes = parameterTypes;
                _hashCode = GenerateHashCode();
            }

            public override bool Equals(object obj)
            {
                var cacheKey = obj as GenericMethodCacheKey;
                if (cacheKey == null)
                    return false;

                if (_sourceType != cacheKey._sourceType)
                    return false;

                if (!String.Equals(_methodName, cacheKey._methodName, StringComparison.Ordinal))
                    return false;

                if (_genericTypes.Length != cacheKey._genericTypes.Length)
                    return false;

                if (_parameterTypes.Length != cacheKey._parameterTypes.Length)
                    return false;

                for (int i = 0; i < _genericTypes.Length; ++i)
                {
                    if (_genericTypes[i] != cacheKey._genericTypes[i])
                        return false;
                }

                for (int i = 0; i < _parameterTypes.Length; ++i)
                {
                    if (_parameterTypes[i] != cacheKey._parameterTypes[i])
                        return false;
                }

                return true;
            }

            public override int GetHashCode()
            {
                return _hashCode;
            }

            private int GenerateHashCode()
            {
                unchecked
                {
                    var result = _sourceType.GetHashCode();

                    result = (result * 397) ^ _methodName.GetHashCode();

                    for (int i = 0; i < _genericTypes.Length; ++i)
                    {
                        result = (result * 397) ^ _genericTypes[i].GetHashCode();
                    }

                    for (int i = 0; i < _parameterTypes.Length; ++i)
                    {
                        result = (result * 397) ^ _parameterTypes[i].GetHashCode();
                    }

                    return result;
                }
            }
        }

    }
    #endregion

    #region TinyIoC Exception Types
    internal class TinyIoCResolutionException : Exception
    {
        private const string ERROR_TEXT = "Unable to resolve type: {0}";

        public TinyIoCResolutionException(Type type)
            : base(String.Format(ERROR_TEXT, type.FullName))
        {
        }

        public TinyIoCResolutionException(Type type, Exception innerException)
            : base(String.Format(ERROR_TEXT, type.FullName), innerException)
        {
        }

        protected TinyIoCResolutionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

    }

    [Serializable]
    internal class TinyIoCRegistrationTypeException : Exception
    {
        private const string REGISTER_ERROR_TEXT = "Cannot register type {0} - abstract classes or interfaces are not valid implementation types for {1}.";

        public TinyIoCRegistrationTypeException(Type type, string factory)
            : base(String.Format(REGISTER_ERROR_TEXT, type.FullName, factory))
        {
        }

        public TinyIoCRegistrationTypeException(Type type, string factory, Exception innerException)
            : base(String.Format(REGISTER_ERROR_TEXT, type.FullName, factory), innerException)
        {
        }

        protected TinyIoCRegistrationTypeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

    }

    [Serializable]
    internal class TinyIoCRegistrationException : Exception
    {
        private const string CONVERT_ERROR_TEXT = "Cannot convert current registration of {0} to {1}";
        private const string GENERIC_CONSTRAINT_ERROR_TEXT = "Type {1} is not valid for a registration of type {0}";

        public TinyIoCRegistrationException(Type type, string method)
            : base(String.Format(CONVERT_ERROR_TEXT, type.FullName, method))
        {
        }

        public TinyIoCRegistrationException(Type type, string method, Exception innerException)
            : base(String.Format(CONVERT_ERROR_TEXT, type.FullName, method), innerException)
        {
        }

        public TinyIoCRegistrationException(Type registerType, Type implementationType)
            : base(String.Format(GENERIC_CONSTRAINT_ERROR_TEXT, registerType.FullName, implementationType.FullName))
        {
        }

        public TinyIoCRegistrationException(Type registerType, Type implementationType, Exception innerException)
            : base(String.Format(GENERIC_CONSTRAINT_ERROR_TEXT, registerType.FullName, implementationType.FullName), innerException)
        {
        }

        protected TinyIoCRegistrationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

    }

    [Serializable]
    internal class TinyIoCWeakReferenceException : Exception
    {
        private const string ERROR_TEXT = "Unable to instantiate {0} - referenced object has been reclaimed";

        public TinyIoCWeakReferenceException(Type type)
            : base(String.Format(ERROR_TEXT, type.FullName))
        {
        }

        public TinyIoCWeakReferenceException(Type type, Exception innerException)
            : base(String.Format(ERROR_TEXT, type.FullName), innerException)
        {
        }

        protected TinyIoCWeakReferenceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

    }

    [Serializable]
    internal class TinyIoCConstructorResolutionException : Exception
    {
        private const string ERROR_TEXT = "Unable to resolve constructor for {0} using provided Expression.";

        public TinyIoCConstructorResolutionException(Type type)
            : base(String.Format(ERROR_TEXT, type.FullName))
        {
        }

        public TinyIoCConstructorResolutionException(Type type, Exception innerException)
            : base(String.Format(ERROR_TEXT, type.FullName), innerException)
        {
        }

        public TinyIoCConstructorResolutionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public TinyIoCConstructorResolutionException(string message)
            : base(message)
        {
        }

        protected TinyIoCConstructorResolutionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

    }

    [Serializable]
    internal class TinyIoCAutoRegistrationException : Exception
    {
        private const string ERROR_TEXT = "Duplicate implementation of type {0} found ({1}).";

        public TinyIoCAutoRegistrationException(Type registerType, IEnumerable<Type> types)
            : base(String.Format(ERROR_TEXT, registerType, GetTypesString(types)))
        {
        }

        public TinyIoCAutoRegistrationException(Type registerType, IEnumerable<Type> types, Exception innerException)
            : base(String.Format(ERROR_TEXT, registerType, GetTypesString(types)), innerException)
        {
        }

        protected TinyIoCAutoRegistrationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        private static string GetTypesString(IEnumerable<Type> types)
        {
            var typeNames = from type in types
                            select type.FullName;

            return string.Join(",", typeNames.ToArray());
        }
    }
    #endregion

    #region Public Setup / Settings Classes
    /// <summary>
    /// Name/Value pairs for specifying "user" parameters when resolving
    /// </summary>
    internal sealed class NamedParameterOverloads : Dictionary<string, object>
    {
        public static NamedParameterOverloads FromIDictionary(IDictionary<string, object> data)
        {
            return data as NamedParameterOverloads ?? new NamedParameterOverloads(data);
        }

        public NamedParameterOverloads()
        {
        }

        public NamedParameterOverloads(IDictionary<string, object> data)
            : base(data)
        {
        }

        private static readonly NamedParameterOverloads _Default = new NamedParameterOverloads();

        public static NamedParameterOverloads Default
        {
            get
            {
                return _Default;
            }
        }
    }

    internal enum UnregisteredResolutionActions
    {
        /// <summary>
        /// Attempt to resolve type, even if the type isn't registered.
        /// 
        /// Registered types/options will always take precedence.
        /// </summary>
        AttemptResolve,

        /// <summary>
        /// Fail resolution if type not explicitly registered
        /// </summary>
        Fail,

        /// <summary>
        /// Attempt to resolve unregistered type if requested type is generic
        /// and no registration exists for the specific generic parameters used.
        /// 
        /// Registered types/options will always take precedence.
        /// </summary>
        GenericsOnly
    }

    internal enum NamedResolutionFailureActions
    {
        AttemptUnnamedResolution,
        Fail
    }

    internal enum DuplicateImplementationActions
    {
        RegisterSingle,
        RegisterMultiple,
        Fail
    }

    /// <summary>
    /// Resolution settings
    /// </summary>
    internal sealed class ResolveOptions
    {
        private static readonly ResolveOptions _Default = new ResolveOptions();
        private static readonly ResolveOptions _FailUnregisteredAndNameNotFound = new ResolveOptions() { NamedResolutionFailureAction = NamedResolutionFailureActions.Fail, UnregisteredResolutionAction = UnregisteredResolutionActions.Fail };
        private static readonly ResolveOptions _FailUnregisteredOnly = new ResolveOptions() { NamedResolutionFailureAction = NamedResolutionFailureActions.AttemptUnnamedResolution, UnregisteredResolutionAction = UnregisteredResolutionActions.Fail };
        private static readonly ResolveOptions _FailNameNotFoundOnly = new ResolveOptions() { NamedResolutionFailureAction = NamedResolutionFailureActions.Fail, UnregisteredResolutionAction = UnregisteredResolutionActions.AttemptResolve };

        private UnregisteredResolutionActions _UnregisteredResolutionAction = UnregisteredResolutionActions.AttemptResolve;
        public UnregisteredResolutionActions UnregisteredResolutionAction
        {
            get { return _UnregisteredResolutionAction; }
            set { _UnregisteredResolutionAction = value; }
        }

        private NamedResolutionFailureActions _NamedResolutionFailureAction = NamedResolutionFailureActions.Fail;
        public NamedResolutionFailureActions NamedResolutionFailureAction
        {
            get { return _NamedResolutionFailureAction; }
            set { _NamedResolutionFailureAction = value; }
        }

        /// <summary>
        /// Gets the default options (attempt resolution of unregistered types, fail on named resolution if name not found)
        /// </summary>
        public static ResolveOptions Default
        {
            get
            {
                return _Default;
            }
        }

        /// <summary>
        /// Preconfigured option for attempting resolution of unregistered types and failing on named resolution if name not found
        /// </summary>
        public static ResolveOptions FailNameNotFoundOnly
        {
            get
            {
                return _FailNameNotFoundOnly;
            }
        }

        /// <summary>
        /// Preconfigured option for failing on resolving unregistered types and on named resolution if name not found
        /// </summary>
        public static ResolveOptions FailUnregisteredAndNameNotFound
        {
            get
            {
                return _FailUnregisteredAndNameNotFound;
            }
        }

        /// <summary>
        /// Preconfigured option for failing on resolving unregistered types, but attempting unnamed resolution if name not found
        /// </summary>
        public static ResolveOptions FailUnregisteredOnly
        {
            get
            {
                return _FailUnregisteredOnly;
            }
        }
    }
    #endregion

    internal sealed partial class TinyIoCContainer : IDisposable
    {
        #region "Fluent" API
        /// <summary>
        /// Registration options for "fluent" API
        /// </summary>
        public sealed class RegisterOptions
        {
            private TinyIoCContainer _Container;
            private Type _Registration;

            public RegisterOptions(TinyIoCContainer container, Type registration)
            {
                _Container = container;
                _Registration = registration;
            }

            /// <summary>
            /// Make registration a singleton (single instance) if possible
            /// </summary>
            /// <returns>RegisterOptions</returns>
            /// <exception cref="TinyIoCRegistrationException"></exception>
            public RegisterOptions AsSingleton()
            {
                var currentFactory = _Container.GetCurrentFactory(_Registration);

                if (currentFactory == null)
                    throw new TinyIoCRegistrationException(_Registration, "singleton");

                return _Container.AddUpdateRegistration(_Registration, currentFactory.SingletonVariant);
            }

            /// <summary>
            /// Make registration multi-instance if possible
            /// </summary>
            /// <returns>RegisterOptions</returns>
            /// <exception cref="TinyIoCRegistrationException"></exception>
            public RegisterOptions AsMultiInstance()
            {
                var currentFactory = _Container.GetCurrentFactory(_Registration);

                if (currentFactory == null)
                    throw new TinyIoCRegistrationException(_Registration, "multi-instance");

                return _Container.AddUpdateRegistration(_Registration, currentFactory.MultiInstanceVariant);
            }

            /// <summary>
            /// Make registration hold a weak reference if possible
            /// </summary>
            /// <returns>RegisterOptions</returns>
            /// <exception cref="TinyIoCRegistrationException"></exception>
            public RegisterOptions WithWeakReference()
            {
                var currentFactory = _Container.GetCurrentFactory(_Registration);

                if (currentFactory == null)
                    throw new TinyIoCRegistrationException(_Registration, "weak reference");

                return _Container.AddUpdateRegistration(_Registration, currentFactory.WeakReferenceVariant);
            }

            /// <summary>
            /// Make registration hold a strong reference if possible
            /// </summary>
            /// <returns>RegisterOptions</returns>
            /// <exception cref="TinyIoCRegistrationException"></exception>
            public RegisterOptions WithStrongReference()
            {
                var currentFactory = _Container.GetCurrentFactory(_Registration);

                if (currentFactory == null)
                    throw new TinyIoCRegistrationException(_Registration, "strong reference");

                return _Container.AddUpdateRegistration(_Registration, currentFactory.StrongReferenceVariant);
            }

            public RegisterOptions UsingConstructor<RegisterType>(Expression<Func<RegisterType>> constructor)
            {
                if (!IsValidAssignment(_Registration, typeof(RegisterType)))
                    throw new TinyIoCConstructorResolutionException(typeof(RegisterType));

                var lambda = constructor as LambdaExpression;
                if (lambda == null)
                    throw new TinyIoCConstructorResolutionException(typeof(RegisterType));

                var newExpression = lambda.Body as NewExpression;
                if (newExpression == null)
                    throw new TinyIoCConstructorResolutionException(typeof(RegisterType));

                var constructorInfo = newExpression.Constructor;
                if (constructorInfo == null)
                    throw new TinyIoCConstructorResolutionException(typeof(RegisterType));

                var currentFactory = _Container.GetCurrentFactory(_Registration);
                if (currentFactory == null)
                    throw new TinyIoCConstructorResolutionException(typeof(RegisterType));

                currentFactory.SetConstructor(constructorInfo);

                return this;
            }

            /// <summary>
            /// Switches to a custom lifetime manager factory if possible.
            /// 
            /// Usually used for RegisterOptions "To*" extension methods such as the ASP.Net per-request one.
            /// </summary>
            /// <param name="instance">RegisterOptions instance</param>
            /// <param name="lifetimeProvider">Custom lifetime manager</param>
            /// <param name="errorString">Error string to display if switch fails</param>
            /// <returns>RegisterOptions</returns>
            public static RegisterOptions ToCustomLifetimeManager(RegisterOptions instance, ITinyIoCObjectLifetimeProvider lifetimeProvider, string errorString)
            {
                if (instance == null)
                    throw new ArgumentNullException("instance", "instance is null.");

                if (lifetimeProvider == null)
                    throw new ArgumentNullException("lifetimeProvider", "lifetimeProvider is null.");

                if (string.IsNullOrEmpty(errorString))
                    throw new ArgumentException("errorString is null or empty.", "errorString");

                var currentFactory = instance._Container.GetCurrentFactory(instance._Registration);

                if (currentFactory == null)
                    throw new TinyIoCRegistrationException(instance._Registration, errorString);

                return instance._Container.AddUpdateRegistration(instance._Registration, currentFactory.GetCustomObjectLifetimeVariant(lifetimeProvider, errorString));
            }
        }

        /// <summary>
        /// Registration options for "fluent" API when registering multiple implementations
        /// </summary>
        public sealed class MultiRegisterOptions
        {
            private IEnumerable<RegisterOptions> _RegisterOptions;

            /// <summary>
            /// Initializes a new instance of the MultiRegisterOptions class.
            /// </summary>
            /// <param name="registerOptions">Registration options</param>
            public MultiRegisterOptions(IEnumerable<RegisterOptions> registerOptions)
            {
                _RegisterOptions = registerOptions;
            }

            /// <summary>
            /// Make registration a singleton (single instance) if possible
            /// </summary>
            /// <returns>RegisterOptions</returns>
            /// <exception cref="TinyIoCRegistrationException"></exception>
            public MultiRegisterOptions AsSingleton()
            {
                _RegisterOptions = ExecuteOnAllRegisterOptions(ro => ro.AsSingleton());
                return this;
            }

            /// <summary>
            /// Make registration multi-instance if possible
            /// </summary>
            /// <returns>MultiRegisterOptions</returns>
            /// <exception cref="TinyIoCRegistrationException"></exception>
            public MultiRegisterOptions AsMultiInstance()
            {
                _RegisterOptions = ExecuteOnAllRegisterOptions(ro => ro.AsMultiInstance());
                return this;
            }

            /// <summary>
            /// Switches to a custom lifetime manager factory if possible.
            /// 
            /// Usually used for RegisterOptions "To*" extension methods such as the ASP.Net per-request one.
            /// </summary>
            /// <param name="instance">MultiRegisterOptions instance</param>
            /// <param name="lifetimeProvider">Custom lifetime manager</param>
            /// <param name="errorString">Error string to display if switch fails</param>
            /// <returns>MultiRegisterOptions</returns>
            public static MultiRegisterOptions ToCustomLifetimeManager(
                MultiRegisterOptions instance,
                ITinyIoCObjectLifetimeProvider lifetimeProvider,
                string errorString)
            {
                if (instance == null)
                    throw new ArgumentNullException("instance", "instance is null.");

                if (lifetimeProvider == null)
                    throw new ArgumentNullException("lifetimeProvider", "lifetimeProvider is null.");

                if (string.IsNullOrEmpty(errorString))
                    throw new ArgumentException("errorString is null or empty.", "errorString");

                instance._RegisterOptions = instance.ExecuteOnAllRegisterOptions(ro => RegisterOptions.ToCustomLifetimeManager(ro, lifetimeProvider, errorString));

                return instance;
            }

            private IEnumerable<RegisterOptions> ExecuteOnAllRegisterOptions(Func<RegisterOptions, RegisterOptions> action)
            {
                var newRegisterOptions = new List<RegisterOptions>();

                foreach (var registerOption in _RegisterOptions)
                {
                    newRegisterOptions.Add(action(registerOption));
                }

                return newRegisterOptions;
            }
        }
        #endregion

        #region Public API
        #region Child Containers
        public TinyIoCContainer GetChildContainer()
        {
            return new TinyIoCContainer(this);
        }
        #endregion

        #region Registration
        /// <summary>
        /// Attempt to automatically register all non-generic classes and interfaces in the current app domain.
        /// 
        /// If more than one class implements an interface then only one implementation will be registered
        /// although no error will be thrown.
        /// </summary>
        public void AutoRegister()
        {
            AutoRegisterInternal(AppDomain.CurrentDomain.GetAssemblies().Where(a => !IsIgnoredAssembly(a)), DuplicateImplementationActions.RegisterSingle, null);
        }

        /// <summary>
        /// Attempt to automatically register all non-generic classes and interfaces in the current app domain.
        /// Types will only be registered if they pass the supplied registration predicate.
        /// 
        /// If more than one class implements an interface then only one implementation will be registered
        /// although no error will be thrown.
        /// </summary>
        /// <param name="registrationPredicate">Predicate to determine if a particular type should be registered</param>
        public void AutoRegister(Func<Type, bool> registrationPredicate)
        {
            AutoRegisterInternal(AppDomain.CurrentDomain.GetAssemblies().Where(a => !IsIgnoredAssembly(a)), DuplicateImplementationActions.RegisterSingle, registrationPredicate);
        }

        /// <summary>
        /// Attempt to automatically register all non-generic classes and interfaces in the current app domain.
        /// </summary>
        /// <param name="duplicateAction">What action to take when encountering duplicate implementations of an interface/base class.</param>
        /// <exception cref="TinyIoCAutoRegistrationException"/>
        public void AutoRegister(DuplicateImplementationActions duplicateAction)
        {
            AutoRegisterInternal(AppDomain.CurrentDomain.GetAssemblies().Where(a => !IsIgnoredAssembly(a)), duplicateAction, null);
        }

        /// <summary>
        /// Attempt to automatically register all non-generic classes and interfaces in the current app domain.
        /// Types will only be registered if they pass the supplied registration predicate.
        /// </summary>
        /// <param name="duplicateAction">What action to take when encountering duplicate implementations of an interface/base class.</param>
        /// <param name="registrationPredicate">Predicate to determine if a particular type should be registered</param>
        /// <exception cref="TinyIoCAutoRegistrationException"/>
        public void AutoRegister(DuplicateImplementationActions duplicateAction, Func<Type, bool> registrationPredicate)
        {
            AutoRegisterInternal(AppDomain.CurrentDomain.GetAssemblies().Where(a => !IsIgnoredAssembly(a)), duplicateAction, registrationPredicate);
        }

        /// <summary>
        /// Attempt to automatically register all non-generic classes and interfaces in the specified assemblies
        /// 
        /// If more than one class implements an interface then only one implementation will be registered
        /// although no error will be thrown.
        /// </summary>
        /// <param name="assemblies">Assemblies to process</param>
        public void AutoRegister(IEnumerable<Assembly> assemblies)
        {
            AutoRegisterInternal(assemblies, DuplicateImplementationActions.RegisterSingle, null);
        }

        /// <summary>
        /// Attempt to automatically register all non-generic classes and interfaces in the specified assemblies
        /// Types will only be registered if they pass the supplied registration predicate.
        /// 
        /// If more than one class implements an interface then only one implementation will be registered
        /// although no error will be thrown.
        /// </summary>
        /// <param name="assemblies">Assemblies to process</param>
        /// <param name="registrationPredicate">Predicate to determine if a particular type should be registered</param>
        public void AutoRegister(IEnumerable<Assembly> assemblies, Func<Type, bool> registrationPredicate)
        {
            AutoRegisterInternal(assemblies, DuplicateImplementationActions.RegisterSingle, registrationPredicate);
        }

        /// <summary>
        /// Attempt to automatically register all non-generic classes and interfaces in the specified assemblies
        /// </summary>
        /// <param name="assemblies">Assemblies to process</param>
        /// <param name="duplicateAction">What action to take when encountering duplicate implementations of an interface/base class.</param>
        /// <exception cref="TinyIoCAutoRegistrationException"/>
        public void AutoRegister(IEnumerable<Assembly> assemblies, DuplicateImplementationActions duplicateAction)
        {
            AutoRegisterInternal(assemblies, duplicateAction, null);
        }

        /// <summary>
        /// Attempt to automatically register all non-generic classes and interfaces in the specified assemblies
        /// Types will only be registered if they pass the supplied registration predicate.
        /// </summary>
        /// <param name="assemblies">Assemblies to process</param>
        /// <param name="duplicateAction">What action to take when encountering duplicate implementations of an interface/base class.</param>
        /// <param name="registrationPredicate">Predicate to determine if a particular type should be registered</param>
        /// <exception cref="TinyIoCAutoRegistrationException"/>
        public void AutoRegister(IEnumerable<Assembly> assemblies, DuplicateImplementationActions duplicateAction, Func<Type, bool> registrationPredicate)
        {
            AutoRegisterInternal(assemblies, duplicateAction, registrationPredicate);
        }

        /// <summary>
        /// Creates/replaces a container class registration with default options.
        /// </summary>
        /// <param name="registerType">Type to register</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register(Type registerType)
        {
            return RegisterInternal(registerType, GetDefaultObjectFactory(registerType, registerType));
        }

        /// <summary>
        /// Creates/replaces a container class registration with a given implementation and default options.
        /// </summary>
        /// <param name="registerType">Type to register</param>
        /// <param name="registerImplementation">Type to instantiate that implements RegisterType</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register(Type registerType, Type registerImplementation)
        {
            return this.RegisterInternal(registerType, GetDefaultObjectFactory(registerType, registerImplementation));
        }

        /// <summary>
        /// Creates/replaces a container class registration with a specific, strong referenced, instance.
        /// </summary>
        /// <param name="registerType">Type to register</param>
        /// <param name="instance">Instance of RegisterType to register</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register(Type registerType, object instance)
        {
            return RegisterInternal(registerType, new InstanceFactory(registerType, registerType, instance));
        }

        /// <summary>
        /// Creates/replaces a container class registration with a specific, strong referenced, instance.
        /// </summary>
        /// <param name="registerType">Type to register</param>
        /// <param name="registerImplementation">Type of instance to register that implements RegisterType</param>
        /// <param name="instance">Instance of RegisterImplementation to register</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register(Type registerType, Type registerImplementation, object instance)
        {
            return RegisterInternal(registerType, new InstanceFactory(registerType, registerImplementation, instance));
        }

        /// <summary>
        /// Creates/replaces a container class registration with a user specified factory
        /// </summary>
        /// <param name="registerType">Type to register</param>
        /// <param name="factory">Factory/lambda that returns an instance of RegisterType</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register(Type registerType, Func<TinyIoCContainer, NamedParameterOverloads, object> factory)
        {
            return RegisterInternal(registerType, new DelegateFactory(registerType, factory));
        }

         /// <summary>
        /// Creates/replaces a container class registration with default options.
        /// </summary>
        /// <typeparam name="RegisterType">Type to register</typeparam>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register<RegisterType>()
            where RegisterType : class
        {
            return this.Register(typeof(RegisterType));
        }

        /// <summary>
        /// Creates/replaces a container class registration with a given implementation and default options.
        /// </summary>
        /// <typeparam name="RegisterType">Type to register</typeparam>
        /// <typeparam name="RegisterImplementation">Type to instantiate that implements RegisterType</typeparam>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register<RegisterType, RegisterImplementation>()
            where RegisterType : class
            where RegisterImplementation : class, RegisterType
        {
            return this.Register(typeof(RegisterType), typeof(RegisterImplementation));
        }

        /// <summary>
        /// Creates/replaces a container class registration with a specific, strong referenced, instance.
        /// </summary>
        /// <typeparam name="RegisterType">Type to register</typeparam>
        /// <param name="instance">Instance of RegisterType to register</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register<RegisterType>(RegisterType instance)
           where RegisterType : class
        {
            return this.Register(typeof(RegisterType), instance);
        }

        /// <summary>
        /// Creates/replaces a container class registration with a specific, strong referenced, instance.
        /// </summary>
        /// <typeparam name="RegisterType">Type to register</typeparam>
        /// <typeparam name="RegisterImplementation">Type of instance to register that implements RegisterType</typeparam>
        /// <param name="instance">Instance of RegisterImplementation to register</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register<RegisterType, RegisterImplementation>(RegisterImplementation instance)
            where RegisterType : class
            where RegisterImplementation : class, RegisterType
        {
            return this.Register(typeof(RegisterType), typeof(RegisterImplementation), instance);
        }

        /// <summary>
        /// Creates/replaces a container class registration with a user specified factory
        /// </summary>
        /// <typeparam name="RegisterType">Type to register</typeparam>
        /// <param name="factory">Factory/lambda that returns an instance of RegisterType</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register<RegisterType>(Func<TinyIoCContainer, NamedParameterOverloads, RegisterType> factory)
            where RegisterType : class
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return this.Register(typeof(RegisterType), (c, o) => factory(c, o));
        }

        /// <summary>
        /// Register multiple implementations of a type.
        /// 
        /// Internally this registers each implementation using the full name of the class as its registration name.
        /// </summary>
        /// <typeparam name="RegisterType">Type that each implementation implements</typeparam>
        /// <param name="implementationTypes">Types that implement RegisterType</param>
        /// <returns>MultiRegisterOptions for the fluent API</returns>
        public MultiRegisterOptions RegisterMultiple<RegisterType>(IEnumerable<Type> implementationTypes)
        {
            return RegisterMultiple(typeof(RegisterType), implementationTypes);
        }

        /// <summary>
        /// Register multiple implementations of a type.
        /// 
        /// Internally this registers each implementation using the full name of the class as its registration name.
        /// </summary>
        /// <param name="registrationType">Type that each implementation implements</param>
        /// <param name="implementationTypes">Types that implement RegisterType</param>
        /// <returns>MultiRegisterOptions for the fluent API</returns>
        public MultiRegisterOptions RegisterMultiple(Type registrationType, IEnumerable<Type> implementationTypes)
        {
            if (implementationTypes == null)
                throw new ArgumentNullException("types", "types is null.");

            foreach (var type in implementationTypes)
                if (!registrationType.IsAssignableFrom(type))
                    throw new ArgumentException(String.Format("types: The type {0} is not assignable from {1}", registrationType.FullName, type.FullName));

            if (implementationTypes.Count() != implementationTypes.Distinct().Count())
            {
                var queryForDuplicatedTypes = from i in implementationTypes
                                              group i by i
                                                  into j
                                              where j.Count() > 1
                                              select j.Key.FullName;

                var fullNamesOfDuplicatedTypes = string.Join(",\n", queryForDuplicatedTypes.ToArray());
                var multipleRegMessage = string.Format("types: The same implementation type cannot be specified multiple times for {0}\n\n{1}", registrationType.FullName, fullNamesOfDuplicatedTypes);
                throw new ArgumentException(multipleRegMessage);
            }

            var registerOptions = new List<RegisterOptions>();

            foreach (var type in implementationTypes)
            {
                registerOptions.Add(Register(registrationType, type, type.FullName));
            }

            return new MultiRegisterOptions(registerOptions);
        }
        #endregion

        #region Unregistration

        /// <summary>
        /// Remove a container class registration.
        /// </summary>
        /// <typeparam name="RegisterType">Type to unregister</typeparam>
        /// <returns>true if the registration is successfully found and removed; otherwise, false.</returns>
        public bool Unregister<RegisterType>()
        {
            return Unregister(typeof(RegisterType));
        }

        /// <summary>
        /// Remove a container class registration.
        /// </summary>
        /// <param name="registerType">Type to unregister</param>
        /// <returns>true if the registration is successfully found and removed; otherwise, false.</returns>
        public bool Unregister(Type registerType)
        {
            return RemoveRegistration(registerType);
        }
        #endregion

        #region Resolution
        /// <summary>
        /// Attempts to resolve a type using default options.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public object Resolve(Type resolveType)
        {
            return ResolveInternal(resolveType, NamedParameterOverloads.Default, ResolveOptions.Default);
        }

        /// <summary>
        /// Attempts to resolve a type using specified options.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public object Resolve(Type resolveType, ResolveOptions options)
        {
            return ResolveInternal(resolveType, NamedParameterOverloads.Default, options);
        }

        /// <summary>
        /// Attempts to resolve a type using default options and the supplied constructor parameters.
        ///
        /// Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one exists).
        /// All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will fail.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public object Resolve(Type resolveType, NamedParameterOverloads parameters)
        {
            return ResolveInternal(resolveType, parameters, ResolveOptions.Default);
        }

        /// <summary>
        /// Attempts to resolve a type using specified options and the supplied constructor parameters.
        ///
        /// Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one exists).
        /// All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will fail.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public object Resolve(Type resolveType, NamedParameterOverloads parameters, ResolveOptions options)
        {
            return ResolveInternal(resolveType, parameters, options);
        }

        /// <summary>
        /// Attempts to resolve a type using default options.
        /// </summary>
        /// <typeparam name="ResolveType">Type to resolve</typeparam>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public ResolveType Resolve<ResolveType>()
            where ResolveType : class
        {
            return (ResolveType)Resolve(typeof(ResolveType));
        }

        /// <summary>
        /// Attempts to resolve a type using specified options.
        /// </summary>
        /// <typeparam name="ResolveType">Type to resolve</typeparam>
        /// <param name="options">Resolution options</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public ResolveType Resolve<ResolveType>(ResolveOptions options)
            where ResolveType : class
        {
            return (ResolveType)Resolve(typeof(ResolveType), options);
        }

        /// <summary>
        /// Attempts to resolve a type using default options and the supplied constructor parameters.
        ///
        /// Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one exists).
        /// All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will fail.
        /// </summary>
        /// <typeparam name="ResolveType">Type to resolve</typeparam>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public ResolveType Resolve<ResolveType>(NamedParameterOverloads parameters)
            where ResolveType : class
        {
            return (ResolveType)Resolve(typeof(ResolveType), parameters);
        }

        /// <summary>
        /// Attempts to resolve a type using specified options and the supplied constructor parameters.
        ///
        /// Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one exists).
        /// All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will fail.
        /// </summary>
        /// <typeparam name="ResolveType">Type to resolve</typeparam>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public ResolveType Resolve<ResolveType>(NamedParameterOverloads parameters, ResolveOptions options)
            where ResolveType : class
        {
            return (ResolveType)Resolve(typeof(ResolveType), parameters, options);
        }

        /// <summary>
        /// Attempts to predict whether a given type can be resolved with default options.
        ///
        /// Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve(Type resolveType)
        {
            return CanResolveInternal(resolveType, NamedParameterOverloads.Default, ResolveOptions.Default);
        }

        /// <summary>
        /// Attempts to predict whether a given type can be resolved with the specified options.
        ///
        /// Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve(Type resolveType, ResolveOptions options)
        {
            return CanResolveInternal(resolveType, NamedParameterOverloads.Default, options);
        }

        /// <summary>
        /// Attempts to predict whether a given type can be resolved with the supplied constructor parameters and default options.
        ///
        /// Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one exists).
        /// All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will fail.
        /// 
        /// Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="parameters">User supplied named parameter overloads</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve(Type resolveType, NamedParameterOverloads parameters)
        {
            return CanResolveInternal(resolveType, parameters, ResolveOptions.Default);
        }

        /// <summary>
        /// Attempts to predict whether a given type can be resolved with the supplied constructor parameters options.
        ///
        /// Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one exists).
        /// All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will fail.
        /// 
        /// Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="parameters">User supplied named parameter overloads</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve(Type resolveType, NamedParameterOverloads parameters, ResolveOptions options)
        {
            return CanResolveInternal(resolveType, parameters, options);
        }

        /// <summary>
        /// Attempts to predict whether a given type can be resolved with default options.
        ///
        /// Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <typeparam name="ResolveType">Type to resolve</typeparam>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve<ResolveType>()
            where ResolveType : class
        {
            return CanResolve(typeof(ResolveType));
        }

        /// <summary>
        /// Attempts to predict whether a given type can be resolved with the specified options.
        ///
        /// Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <typeparam name="ResolveType">Type to resolve</typeparam>
        /// <param name="options">Resolution options</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve<ResolveType>(ResolveOptions options)
            where ResolveType : class
        {
            return CanResolve(typeof(ResolveType), options);
        }

        /// <summary>
        /// Attempts to predict whether a given type can be resolved with the supplied constructor parameters and default options.
        ///
        /// Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one exists).
        /// All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will fail.
        /// 
        /// Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <typeparam name="ResolveType">Type to resolve</typeparam>
        /// <param name="parameters">User supplied named parameter overloads</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve<ResolveType>(NamedParameterOverloads parameters)
            where ResolveType : class
        {
            return CanResolve(typeof(ResolveType), parameters);
        }

        /// <summary>
        /// Attempts to predict whether a given type can be resolved with the supplied constructor parameters options.
        ///
        /// Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one exists).
        /// All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will fail.
        /// 
        /// Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <typeparam name="ResolveType">Type to resolve</typeparam>
        /// <param name="parameters">User supplied named parameter overloads</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve<ResolveType>(NamedParameterOverloads parameters, ResolveOptions options)
            where ResolveType : class
        {
            return CanResolve(typeof(ResolveType), parameters, options);
        }

        /// <summary>
        /// Attempts to resolve a type using the default options
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve(Type resolveType, out object resolvedType)
        {
            try
            {
                resolvedType = Resolve(resolveType);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = null;
                return false;
            }
        }

        /// <summary>
        /// Attempts to resolve a type using the given options
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="options">Resolution options</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve(Type resolveType, ResolveOptions options, out object resolvedType)
        {
            try
            {
                resolvedType = Resolve(resolveType, options);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = null;
                return false;
            }
        }

        /// <summary>
        /// Attempts to resolve a type using the default options and supplied constructor parameters
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve(Type resolveType, NamedParameterOverloads parameters, out object resolvedType)
        {
            try
            {
                resolvedType = Resolve(resolveType, parameters);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = null;
                return false;
            }
        }

        /// <summary>
        /// Attempts to resolve a type using the supplied options and constructor parameters
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="options">Resolution options</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve(Type resolveType, NamedParameterOverloads parameters, ResolveOptions options, out object resolvedType)
        {
            try
            {
                resolvedType = Resolve(resolveType, parameters, options);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = null;
                return false;
            }
        }

        /// <summary>
        /// Attempts to resolve a type using the default options
        /// </summary>
        /// <typeparam name="ResolveType">Type to resolve</typeparam>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve<ResolveType>(out ResolveType resolvedType)
            where ResolveType : class
        {
            try
            {
                resolvedType = Resolve<ResolveType>();
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = default(ResolveType);
                return false;
            }
        }

        /// <summary>
        /// Attempts to resolve a type using the given options
        /// </summary>
        /// <typeparam name="ResolveType">Type to resolve</typeparam>
        /// <param name="options">Resolution options</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve<ResolveType>(ResolveOptions options, out ResolveType resolvedType)
            where ResolveType : class
        {
            try
            {
                resolvedType = Resolve<ResolveType>(options);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = default(ResolveType);
                return false;
            }
        }

        /// <summary>
        /// Attempts to resolve a type using the default options and supplied constructor parameters
        /// </summary>
        /// <typeparam name="ResolveType">Type to resolve</typeparam>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve<ResolveType>(NamedParameterOverloads parameters, out ResolveType resolvedType)
            where ResolveType : class
        {
            try
            {
                resolvedType = Resolve<ResolveType>(parameters);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = default(ResolveType);
                return false;
            }
        }

        /// <summary>
        /// Attempts to resolve a type using the supplied options and constructor parameters
        /// </summary>
        /// <typeparam name="ResolveType">Type to resolve</typeparam>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="options">Resolution options</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve<ResolveType>(NamedParameterOverloads parameters, ResolveOptions options, out ResolveType resolvedType)
            where ResolveType : class
        {
            try
            {
                resolvedType = Resolve<ResolveType>(parameters, options);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = default(ResolveType);
                return false;
            }
        }

        /// <summary>
        /// Returns all registrations of a type
        /// </summary>
        /// <param name="resolveType">Type to resolveAll</param>
        /// <param name="includeUnnamed">Whether to include un-named (default) registrations</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<object> ResolveAll(Type resolveType, bool includeUnnamed)
        {
            return ResolveAllInternal(resolveType, includeUnnamed);
        }

        /// <summary>
        /// Returns all registrations of a type, both named and unnamed
        /// </summary>
        /// <param name="resolveType">Type to resolveAll</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<object> ResolveAll(Type resolveType)
        {
            return ResolveAll(resolveType, true);
        }

        /// <summary>
        /// Returns all registrations of a type
        /// </summary>
        /// <typeparam name="ResolveType">Type to resolveAll</typeparam>
        /// <param name="includeUnnamed">Whether to include un-named (default) registrations</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<ResolveType> ResolveAll<ResolveType>(bool includeUnnamed)
            where ResolveType : class
        {
            return this.ResolveAll(typeof(ResolveType), includeUnnamed).Cast<ResolveType>();
        }

        /// <summary>
        /// Returns all registrations of a type, both named and unnamed
        /// </summary>
        /// <typeparam name="ResolveType">Type to resolveAll</typeparam>
        /// <returns>IEnumerable</returns>
        public IEnumerable<ResolveType> ResolveAll<ResolveType>()
            where ResolveType : class
        {
            return ResolveAll<ResolveType>(true);
        }

        /// <summary>
        /// Attempts to resolve all public property dependencies on the given object.
        /// </summary>
        /// <param name="input">Object to "build up"</param>
        public void BuildUp(object input)
        {
            BuildUpInternal(input, ResolveOptions.Default);
        }

        /// <summary>
        /// Attempts to resolve all public property dependencies on the given object using the given resolve options.
        /// </summary>
        /// <param name="input">Object to "build up"</param>
        /// <param name="resolveOptions">Resolve options to use</param>
        public void BuildUp(object input, ResolveOptions resolveOptions)
        {
            BuildUpInternal(input, resolveOptions);
        }
        #endregion
        #endregion

        #region Object Factories
        /// <summary>
        /// Provides custom lifetime management for ASP.Net per-request lifetimes etc.
        /// </summary>
        public interface ITinyIoCObjectLifetimeProvider
        {
            /// <summary>
            /// Gets the stored object if it exists, or null if not
            /// </summary>
            /// <returns>Object instance or null</returns>
            object GetObject();

            /// <summary>
            /// Store the object
            /// </summary>
            /// <param name="value">Object to store</param>
            void SetObject(object value);

            /// <summary>
            /// Release the object
            /// </summary>
            void ReleaseObject();
        }

        private abstract class ObjectFactoryBase
        {
            /// <summary>
            /// Whether to assume this factory successfully constructs its objects
            /// 
            /// Generally set to true for delegate style factories as CanResolve cannot delve
            /// into the delegates they contain.
            /// </summary>
            public virtual bool AssumeConstruction { get { return false; } }

            /// <summary>
            /// The type the factory instantiates
            /// </summary>
            public abstract Type CreatesType { get; }

            /// <summary>
            /// Constructor to use, if specified
            /// </summary>
            public ConstructorInfo Constructor { get; protected set; }

            /// <summary>
            /// Create the type
            /// </summary>
            /// <param name="requestedType">Type user requested to be resolved</param>
            /// <param name="container">Container that requested the creation</param>
            /// <param name="parameters">Any user parameters passed</param>
            /// <param name="options"></param>
            /// <returns></returns>
            public abstract object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options);

            public virtual ObjectFactoryBase SingletonVariant
            {
                get
                {
                    throw new TinyIoCRegistrationException(this.GetType(), "singleton");
                }
            }

            public virtual ObjectFactoryBase MultiInstanceVariant
            {
                get
                {
                    throw new TinyIoCRegistrationException(this.GetType(), "multi-instance");
                }
            }

            public virtual ObjectFactoryBase StrongReferenceVariant
            {
                get
                {
                    throw new TinyIoCRegistrationException(this.GetType(), "strong reference");
                }
            }

            public virtual ObjectFactoryBase WeakReferenceVariant
            {
                get
                {
                    throw new TinyIoCRegistrationException(this.GetType(), "weak reference");
                }
            }

            public virtual ObjectFactoryBase GetCustomObjectLifetimeVariant(ITinyIoCObjectLifetimeProvider lifetimeProvider, string errorString)
            {
                throw new TinyIoCRegistrationException(this.GetType(), errorString);
            }

            public virtual void SetConstructor(ConstructorInfo constructor)
            {
                Constructor = constructor;
            }

            public virtual ObjectFactoryBase GetFactoryForChildContainer(Type type, TinyIoCContainer parent, TinyIoCContainer child)
            {
                return this;
            }
        }

        /// <summary>
        /// IObjectFactory that creates new instances of types for each resolution
        /// </summary>
        private class MultiInstanceFactory : ObjectFactoryBase
        {
            private readonly Type registerType;
            private readonly Type registerImplementation;
            public override Type CreatesType { get { return this.registerImplementation; } }

            public MultiInstanceFactory(Type registerType, Type registerImplementation)
            {
                if (registerImplementation.IsAbstract || registerImplementation.IsInterface)
                    throw new TinyIoCRegistrationTypeException(registerImplementation, "MultiInstanceFactory");

                if (!IsValidAssignment(registerType, registerImplementation))
                    throw new TinyIoCRegistrationTypeException(registerImplementation, "MultiInstanceFactory");

                this.registerType = registerType;
                this.registerImplementation = registerImplementation;
            }

            public override object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options)
            {
                try
                {
                    return container.ConstructType(requestedType, this.registerImplementation, Constructor, parameters, options);
                }
                catch (TinyIoCResolutionException ex)
                {
                    throw new TinyIoCResolutionException(this.registerType, ex);
                }
            }

            public override ObjectFactoryBase SingletonVariant
            {
                get
                {
                    return new SingletonFactory(this.registerType, this.registerImplementation);
                }
            }

            public override ObjectFactoryBase GetCustomObjectLifetimeVariant(ITinyIoCObjectLifetimeProvider lifetimeProvider, string errorString)
            {
                return new CustomObjectLifetimeFactory(this.registerType, this.registerImplementation, lifetimeProvider, errorString);
            }

            public override ObjectFactoryBase MultiInstanceVariant
            {
                get
                {
                    return this;
                }
            }
        }

        /// <summary>
        /// IObjectFactory that invokes a specified delegate to construct the object
        /// </summary>
        private class DelegateFactory : ObjectFactoryBase
        {
            private readonly Type registerType;

            private Func<TinyIoCContainer, NamedParameterOverloads, object> _factory;

            public override bool AssumeConstruction { get { return true; } }

            public override Type CreatesType { get { return this.registerType; } }

            public override object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options)
            {
                // Make the requested type available to the factory function
                parameters = new NamedParameterOverloads(parameters);
                parameters["__requestedType"] = requestedType;

                try
                {
                    return _factory.Invoke(container, parameters);
                }
                catch (Exception ex)
                {
                    throw new TinyIoCResolutionException(this.registerType, ex);
                }
            }

            public DelegateFactory(Type registerType, Func<TinyIoCContainer, NamedParameterOverloads, object> factory)
            {
                if (factory == null)
                    throw new ArgumentNullException("factory");

                _factory = factory;

                this.registerType = registerType;
            }

            public override ObjectFactoryBase SingletonVariant
            {
                get
                {
                    return new DelegateSingletonFactory(registerType, _factory);
                }
            }

            public override ObjectFactoryBase WeakReferenceVariant
            {
                get
                {
                    return new WeakDelegateFactory(this.registerType, _factory);
                }
            }

            public override ObjectFactoryBase StrongReferenceVariant
            {
                get
                {
                    return this;
                }
            }

            public override void SetConstructor(ConstructorInfo constructor)
            {
                throw new TinyIoCConstructorResolutionException("Constructor selection is not possible for delegate factory registrations");
            }
        }

        /// <summary>
        /// IObjectFactory that invokes a specified delegate to construct the object
        /// Holds the delegate using a weak reference
        /// </summary>
        private class WeakDelegateFactory : ObjectFactoryBase
        {
            private readonly Type registerType;

            private WeakReference _factory;

            public override bool AssumeConstruction { get { return true; } }

            public override Type CreatesType { get { return this.registerType; } }

            public override object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options)
            {
                var factory = _factory.Target as Func<TinyIoCContainer, NamedParameterOverloads, object>;

                if (factory == null)
                    throw new TinyIoCWeakReferenceException(this.registerType);

                try
                {
                    return factory.Invoke(container, parameters);
                }
                catch (Exception ex)
                {
                    throw new TinyIoCResolutionException(this.registerType, ex);
                }
            }

            public WeakDelegateFactory(Type registerType, Func<TinyIoCContainer, NamedParameterOverloads, object> factory)
            {
                if (factory == null)
                    throw new ArgumentNullException("factory");

                _factory = new WeakReference(factory);

                this.registerType = registerType;
            }

            public override ObjectFactoryBase StrongReferenceVariant
            {
                get
                {
                    var factory = _factory.Target as Func<TinyIoCContainer, NamedParameterOverloads, object>;

                    if (factory == null)
                        throw new TinyIoCWeakReferenceException(this.registerType);

                    return new DelegateFactory(this.registerType, factory);
                }
            }

            public override ObjectFactoryBase WeakReferenceVariant
            {
                get
                {
                    return this;
                }
            }

            public override void SetConstructor(ConstructorInfo constructor)
            {
                throw new TinyIoCConstructorResolutionException("Constructor selection is not possible for delegate factory registrations");
            }
        }

        /// <summary>
        /// Stores an particular instance to return for a type
        /// </summary>
        private class InstanceFactory : ObjectFactoryBase, IDisposable
        {
            private readonly Type registerType;
            private readonly Type registerImplementation;
            private object _instance;

            public override bool AssumeConstruction { get { return true; } }

            public InstanceFactory(Type registerType, Type registerImplementation, object instance)
            {
                if (!IsValidAssignment(registerType, registerImplementation))
                    throw new TinyIoCRegistrationTypeException(registerImplementation, "InstanceFactory");

                this.registerType = registerType;
                this.registerImplementation = registerImplementation;
                _instance = instance;
            }

            public override Type CreatesType
            {
                get { return this.registerImplementation; }
            }

            public override object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options)
            {
                return _instance;
            }

            public override ObjectFactoryBase MultiInstanceVariant
            {
                get { return new MultiInstanceFactory(this.registerType, this.registerImplementation); }
            }

            public override ObjectFactoryBase WeakReferenceVariant
            {
                get
                {
                    return new WeakInstanceFactory(this.registerType, this.registerImplementation, this._instance);
                }
            }

            public override ObjectFactoryBase StrongReferenceVariant
            {
                get
                {
                    return this;
                }
            }

            public override void SetConstructor(ConstructorInfo constructor)
            {
                throw new TinyIoCConstructorResolutionException("Constructor selection is not possible for instance factory registrations");
            }

            public void Dispose()
            {
                var disposable = _instance as IDisposable;

                if (disposable != null)
                    disposable.Dispose();
            }
        }

        /// <summary>
        /// Stores an particular instance to return for a type
        /// 
        /// Stores the instance with a weak reference
        /// </summary>
        private class WeakInstanceFactory : ObjectFactoryBase, IDisposable
        {
            private readonly Type registerType;
            private readonly Type registerImplementation;
            private readonly WeakReference _instance;

            public WeakInstanceFactory(Type registerType, Type registerImplementation, object instance)
            {
                if (!IsValidAssignment(registerType, registerImplementation))
                    throw new TinyIoCRegistrationTypeException(registerImplementation, "WeakInstanceFactory");

                this.registerType = registerType;
                this.registerImplementation = registerImplementation;
                _instance = new WeakReference(instance);
            }

            public override Type CreatesType
            {
                get { return this.registerImplementation; }
            }

            public override object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options)
            {
                var instance = _instance.Target;

                if (instance == null)
                    throw new TinyIoCWeakReferenceException(this.registerType);

                return instance;
            }

            public override ObjectFactoryBase MultiInstanceVariant
            {
                get
                {
                    return new MultiInstanceFactory(this.registerType, this.registerImplementation);
                }
            }

            public override ObjectFactoryBase WeakReferenceVariant
            {
                get
                {
                    return this;
                }
            }

            public override ObjectFactoryBase StrongReferenceVariant
            {
                get
                {
                    var instance = _instance.Target;

                    if (instance == null)
                        throw new TinyIoCWeakReferenceException(this.registerType);

                    return new InstanceFactory(this.registerType, this.registerImplementation, instance);
                }
            }

            public override void SetConstructor(ConstructorInfo constructor)
            {
                throw new TinyIoCConstructorResolutionException("Constructor selection is not possible for instance factory registrations");
            }

            public void Dispose()
            {
                var disposable = _instance.Target as IDisposable;

                if (disposable != null)
                    disposable.Dispose();
            }
        }

        /// <summary>
        /// A factory that lazy instantiates a type and always returns the same instance
        /// </summary>
        private class SingletonFactory : ObjectFactoryBase, IDisposable
        {
            private readonly Type registerType;
            private readonly Type registerImplementation;
            private readonly object SingletonLock = new object();
            private object _Current;

            public SingletonFactory(Type registerType, Type registerImplementation)
            {
                if (registerImplementation.IsAbstract || registerImplementation.IsInterface)
                    throw new TinyIoCRegistrationTypeException(registerImplementation, "SingletonFactory");

                if (!IsValidAssignment(registerType, registerImplementation))
                    throw new TinyIoCRegistrationTypeException(registerImplementation, "SingletonFactory");

                this.registerType = registerType;
                this.registerImplementation = registerImplementation;
            }

            //If we've already got an instance we don't need to construct another,
            //returning true here tells the resolve code not to bother calling
            //expensive reflection methods to find constructor details we aren't going to use.
            public override bool AssumeConstruction => _Current != null;

            public override Type CreatesType
            {
                get { return this.registerImplementation; }
            }

            public override object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options)
            {
                if (parameters.Count != 0)
                    throw new ArgumentException("Cannot specify parameters for singleton types");

                //Avoid unnecessary lock when object already constructed (need to keep null check inside lock though)
                //(this is most likely to help perf in multi-threaded environments like asp.net, but may provide a small
                //performance boost even for single threaded use)
                if (_Current != null) return _Current;

                lock (SingletonLock)
                    if (_Current == null)
                        _Current = container.ConstructType(requestedType, this.registerImplementation, Constructor, options);

                return _Current;
            }

            public override ObjectFactoryBase SingletonVariant
            {
                get
                {
                    return this;
                }
            }

            public override ObjectFactoryBase GetCustomObjectLifetimeVariant(ITinyIoCObjectLifetimeProvider lifetimeProvider, string errorString)
            {
                return new CustomObjectLifetimeFactory(this.registerType, this.registerImplementation, lifetimeProvider, errorString);
            }

            public override ObjectFactoryBase MultiInstanceVariant
            {
                get
                {
                    return new MultiInstanceFactory(this.registerType, this.registerImplementation);
                }
            }

            public override ObjectFactoryBase GetFactoryForChildContainer(Type type, TinyIoCContainer parent, TinyIoCContainer child)
            {
                // We make sure that the singleton is constructed before the child container takes the factory.
                // Otherwise the results would vary depending on whether or not the parent container had resolved
                // the type before the child container does.
                GetObject(type, parent, NamedParameterOverloads.Default, ResolveOptions.Default);
                return this;
            }

            public void Dispose()
            {
                if (this._Current == null)
                    return;

                var disposable = this._Current as IDisposable;

                if (disposable != null)
                    disposable.Dispose();
            }
        }

        #region Singleton Container
        private static readonly TinyIoCContainer _Current = new TinyIoCContainer();

        static TinyIoCContainer()
        {
        }

        /// <summary>
        /// Lazy created Singleton instance of the container for simple scenarios
        /// </summary>
        public static TinyIoCContainer Current
        {
            get
            {
                return _Current;
            }
        }
        #endregion

        /// <summary>
        /// A factory that lazy instantiates a type using a factory method and after construction
        /// always returns the same instance
        /// </summary>
        private class DelegateSingletonFactory : ObjectFactoryBase, IDisposable
        {
            private readonly Func<TinyIoCContainer, NamedParameterOverloads, object> _factory;
            private readonly object _singletonLock = new object();
            private object _instance;

            public DelegateSingletonFactory(Type creatingType, Func<TinyIoCContainer, NamedParameterOverloads, object> factory)
            {
                _factory = factory;
                CreatesType = creatingType;
            }

            public override Type CreatesType { get; }

            public override object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters,
                ResolveOptions options)
            {
                if (_instance == null)
                {
                    lock (_singletonLock)
                    {
                        if (_instance == null)
                            _instance = _factory(container, parameters);
                    }
                }

                return _instance;
            }

            public void Dispose()
            {
                if (_instance is IDisposable disp)
                {
                    disp.Dispose();
                    _instance = null;
                }
            }
        }

        /// <summary>
        /// A factory that offloads lifetime to an external lifetime provider
        /// </summary>
        private class CustomObjectLifetimeFactory : ObjectFactoryBase, IDisposable
        {
            private readonly object SingletonLock = new object();
            private readonly Type registerType;
            private readonly Type registerImplementation;
            private readonly ITinyIoCObjectLifetimeProvider _LifetimeProvider;

            public CustomObjectLifetimeFactory(Type registerType, Type registerImplementation, ITinyIoCObjectLifetimeProvider lifetimeProvider, string errorMessage)
            {
                if (lifetimeProvider == null)
                    throw new ArgumentNullException("lifetimeProvider", "lifetimeProvider is null.");

                if (!IsValidAssignment(registerType, registerImplementation))
                    throw new TinyIoCRegistrationTypeException(registerImplementation, "SingletonFactory");

                if (registerImplementation.IsAbstract || registerImplementation.IsInterface)
                    throw new TinyIoCRegistrationTypeException(registerImplementation, errorMessage);

                this.registerType = registerType;
                this.registerImplementation = registerImplementation;
                _LifetimeProvider = lifetimeProvider;
            }

            public override Type CreatesType
            {
                get { return this.registerImplementation; }
            }

            public override object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options)
            {
                object current;

                lock (SingletonLock)
                {
                    current = _LifetimeProvider.GetObject();
                    if (current == null)
                    {
                        current = container.ConstructType(requestedType, this.registerImplementation, Constructor, options);
                        _LifetimeProvider.SetObject(current);
                    }
                }

                return current;
            }

            public override ObjectFactoryBase SingletonVariant
            {
                get
                {
                    _LifetimeProvider.ReleaseObject();
                    return new SingletonFactory(this.registerType, this.registerImplementation);
                }
            }

            public override ObjectFactoryBase MultiInstanceVariant
            {
                get
                {
                    _LifetimeProvider.ReleaseObject();
                    return new MultiInstanceFactory(this.registerType, this.registerImplementation);
                }
            }

            public override ObjectFactoryBase GetCustomObjectLifetimeVariant(ITinyIoCObjectLifetimeProvider lifetimeProvider, string errorString)
            {
                _LifetimeProvider.ReleaseObject();
                return new CustomObjectLifetimeFactory(this.registerType, this.registerImplementation, lifetimeProvider, errorString);
            }

            public override ObjectFactoryBase GetFactoryForChildContainer(Type type, TinyIoCContainer parent, TinyIoCContainer child)
            {
                // We make sure that the singleton is constructed before the child container takes the factory.
                // Otherwise the results would vary depending on whether or not the parent container had resolved
                // the type before the child container does.
                GetObject(type, parent, NamedParameterOverloads.Default, ResolveOptions.Default);
                return this;
            }

            public void Dispose()
            {
                _LifetimeProvider.ReleaseObject();
            }
        }
        #endregion

        #region Type Registrations
        private readonly SafeDictionary<Type, ObjectFactoryBase> _RegisteredTypes;
        private delegate object ObjectConstructor(params object[] parameters);
        private static readonly SafeDictionary<ConstructorInfo, ObjectConstructor> _ObjectConstructorCache = new();
        #endregion

        #region Constructors
        public TinyIoCContainer()
        {
            _RegisteredTypes = new SafeDictionary<Type, ObjectFactoryBase>();

            //RegisterDefaultTypes();
        }

        TinyIoCContainer _Parent;
        private TinyIoCContainer(TinyIoCContainer parent)
            : this()
        {
            _Parent = parent;
        }
        #endregion

        #region Internal Methods
        private readonly object _AutoRegisterLock = new object();
        private void AutoRegisterInternal(IEnumerable<Assembly> assemblies, DuplicateImplementationActions duplicateAction, Func<Type, bool> registrationPredicate)
        {
            var typeOfThis = this.GetType();
            lock (_AutoRegisterLock)
            {
                var types = assemblies.SelectMany(a => a.SafeGetTypes()).Where(t => !IsIgnoredType(t, registrationPredicate)).ToList();

                var concreteTypes = types
                    .Where(type => type.IsClass && (type.IsAbstract == false) && (type != typeOfThis && (type.DeclaringType != typeOfThis) && (!type.IsGenericTypeDefinition)) && !type.IsNestedPrivate)
                    .ToList();

                foreach (var type in concreteTypes)
                {
                    try
                    {
                        RegisterInternal(type, GetDefaultObjectFactory(type, type));
                    }
                    catch (MethodAccessException)
                    {
                        // Ignore methods we can't access - added for Silverlight
                    }
                }

                var abstractInterfaceTypes = from type in types
                                             where ((type.IsInterface || type.IsAbstract) && (type.DeclaringType != typeOfThis) && (!type.IsGenericTypeDefinition))
                                             select type;

                foreach (var type in abstractInterfaceTypes)
                {
                    var localType = type;
                    var implementations = from implementationType in concreteTypes
                                          where localType.IsAssignableFrom(implementationType)
                                          select implementationType;

                    if (implementations.Skip(1).Any())
                    {
                        if (duplicateAction == DuplicateImplementationActions.Fail)
                            throw new TinyIoCAutoRegistrationException(type, implementations);

                        if (duplicateAction == DuplicateImplementationActions.RegisterMultiple)
                        {
                            RegisterMultiple(type, implementations);
                        }
                    }

                    var firstImplementation = implementations.FirstOrDefault();
                    if (firstImplementation != null)
                    {
                        try
                        {
                            RegisterInternal(type, GetDefaultObjectFactory(type, firstImplementation));
                        }
                        catch (MethodAccessException)
                        {
                            // Ignore methods we can't access - added for Silverlight
                        }
                    }
                }
            }
        }

        // TODO - find a better way to remove "system" assemblies from the auto registration
        private static readonly IReadOnlyList<Func<Assembly, bool>> ignoredAssemlies = new List<Func<Assembly, bool>>()
        {
            asm => asm.FullName.StartsWith("Microsoft.", StringComparison.Ordinal),
            asm => asm.FullName.StartsWith("System.", StringComparison.Ordinal),
            asm => asm.FullName.StartsWith("System,", StringComparison.Ordinal),
            asm => asm.FullName.StartsWith("CR_ExtUnitTest", StringComparison.Ordinal),
            asm => asm.FullName.StartsWith("mscorlib,", StringComparison.Ordinal),
            asm => asm.FullName.StartsWith("CR_VSTest", StringComparison.Ordinal),
            asm => asm.FullName.StartsWith("DevExpress.CodeRush", StringComparison.Ordinal),
            asm => asm.FullName.StartsWith("xunit.", StringComparison.Ordinal),
        };

        private bool IsIgnoredAssembly(Assembly assembly)
        {
            for (int i = 0; i < ignoredAssemlies.Count; i++)
            {
                if (ignoredAssemlies[i].Invoke(assembly))
                    return true;
            }

            return false;
        }

        // TODO - find a better way to remove "system" types from the auto registration
        private static readonly IReadOnlyList<Func<Type, bool>> ignoreChecks = new List<Func<Type, bool>>()
        {
            t => t.FullName.StartsWith("System.", StringComparison.Ordinal),
            t => t.FullName.StartsWith("Microsoft.", StringComparison.Ordinal),
            t => t.IsPrimitive,
            t => (t.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Length == 0) && !(t.IsInterface || t.IsAbstract),
        };

        private bool IsIgnoredType(Type type, Func<Type, bool> registrationPredicate)
        {
            if (ignoreChecks.Any(c => c(type)))
                return true;

            return registrationPredicate != null && !registrationPredicate(type);
        }

        private void RegisterDefaultTypes()
        {
            Register<TinyIoCContainer>(this);
        }

        private ObjectFactoryBase GetCurrentFactory(Type registration)
        {
            ObjectFactoryBase current = null;

            _RegisteredTypes.TryGetValue(registration, out current);

            return current;
        }

        private RegisterOptions RegisterInternal(Type registerType, ObjectFactoryBase factory)
        {
            return AddUpdateRegistration(registerType, factory);
        }

        private RegisterOptions AddUpdateRegistration(Type typeRegistration, ObjectFactoryBase factory)
        {
            _RegisteredTypes[typeRegistration] = factory;

            return new RegisterOptions(this, typeRegistration);
        }

        private bool RemoveRegistration(Type typeRegistration)
        {
            return _RegisteredTypes.Remove(typeRegistration);
        }

        private ObjectFactoryBase GetDefaultObjectFactory(Type registerType, Type registerImplementation)
        {
            if (registerType.IsInterface || registerType.IsAbstract)
                return new SingletonFactory(registerType, registerImplementation);

            return new MultiInstanceFactory(registerType, registerImplementation);
        }

        private bool CanResolveInternal(Type checkType, NamedParameterOverloads parameters, ResolveOptions options)
        {
            if (parameters == null)
                throw new ArgumentNullException("parameters");

            ObjectFactoryBase factory;
            if (_RegisteredTypes.TryGetValue(checkType, out factory))
            {
                if (factory.AssumeConstruction)
                    return true;

                if (factory.Constructor == null)
                    return GetBestConstructor(factory.CreatesType, parameters, options) != null;
                else
                    return CanConstruct(factory.Constructor, parameters, options);
            }

            if (checkType.IsInterface && checkType.IsGenericType)
            {
                // if the type is registered as an open generic, then see if the open generic is registered
                if (_RegisteredTypes.TryGetValue(checkType.GetGenericTypeDefinition(), out factory))
                {
                    if (factory.AssumeConstruction)
                        return true;

                    if (factory.Constructor == null)
                        return GetBestConstructor(factory.CreatesType, parameters, options) != null;
                    else
                        return CanConstruct(factory.Constructor, parameters, options);
                }
            }

            // Check if type is an automatic lazy factory request
            if (IsAutomaticLazyFactoryRequest(checkType))
                return true;

            // Check if type is an IEnumerable<ResolveType>
            if (IsIEnumerableRequest(checkType))
                return true;

            // Attempt unregistered construction if possible and requested
            // If we cant', bubble if we have a parent
            if ((options.UnregisteredResolutionAction == UnregisteredResolutionActions.AttemptResolve) || (checkType.IsGenericType && options.UnregisteredResolutionAction == UnregisteredResolutionActions.GenericsOnly))
                return (GetBestConstructor(checkType, parameters, options) != null) ? true : (_Parent != null) ? _Parent.CanResolveInternal(checkType, parameters, options) : false;

            // Bubble resolution up the container tree if we have a parent
            if (_Parent != null)
                return _Parent.CanResolveInternal(checkType, parameters, options);

            return false;
        }

        private bool IsIEnumerableRequest(Type type)
        {
            if (!type.IsGenericType)
                return false;

            Type genericType = type.GetGenericTypeDefinition();

            if (genericType == typeof(IEnumerable<>))
                return true;

            return false;
        }

        private bool IsAutomaticLazyFactoryRequest(Type type)
        {
            if (_LazyAutomaticFactories.ContainsKey(type))
                return true;

            if (!type.IsGenericType)
                return false;

            Type genericType = type.GetGenericTypeDefinition();

            // Just a func
            if (genericType == typeof(Func<>))
                return true;

            Type[] genericArguments = null;
            // 2 parameter func with string as first parameter (name)
            if ((genericType == typeof(Func<,>) && (genericArguments = type.GetGenericArguments())[0] == typeof(string)))
                return true;

            if ((genericType == typeof(Func<,,>) && (genericArguments = genericArguments ?? type.GetGenericArguments())[0] == typeof(string) && (genericArguments = genericArguments ?? type.GetGenericArguments())[1] == typeof(IDictionary<String, object>)))
                return true;

            return false;
        }

        private ObjectFactoryBase GetParentObjectFactory(Type registration)
        {
            if (_Parent == null)
                return null;

            ObjectFactoryBase factory;

            if (_Parent._RegisteredTypes.TryGetValue(registration, out factory))
            {
                return factory.GetFactoryForChildContainer(registration, _Parent, this);
            }

            // Attempt container resolution of open generic
            if (registration.IsGenericType)
            {
                if (_Parent._RegisteredTypes.TryGetValue(registration.GetGenericTypeDefinition(), out factory))
                {
                    return factory.GetFactoryForChildContainer(registration, _Parent, this);
                }

                return _Parent.GetParentObjectFactory(registration);
            }

            return _Parent.GetParentObjectFactory(registration);
        }

        private object ResolveInternal(Type type, NamedParameterOverloads parameters, ResolveOptions options)
        {
            ObjectFactoryBase factory;

            // Attempt container resolution
            if (_RegisteredTypes.TryGetValue(type, out factory))
            {
                try
                {
                    return factory.GetObject(type, this, parameters, options);
                }
                catch (TinyIoCResolutionException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new TinyIoCResolutionException(type, ex);
                }
            }

            // Attempt container resolution of open generic
            if (type.IsGenericType)
            {
                if (_RegisteredTypes.TryGetValue(type.GetGenericTypeDefinition(), out factory))
                {
                    try
                    {
                        return factory.GetObject(type, this, parameters, options);
                    }
                    catch (TinyIoCResolutionException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        throw new TinyIoCResolutionException(type, ex);
                    }
                }
            }

            // Attempt to get a factory from parent if we can
            var bubbledObjectFactory = GetParentObjectFactory(type);
            if (bubbledObjectFactory != null)
            {
                try
                {
                    return bubbledObjectFactory.GetObject(type, this, parameters, options);
                }
                catch (TinyIoCResolutionException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new TinyIoCResolutionException(type, ex);
                }
            }

            // Attempt to construct an automatic lazy factory if possible
            if (IsAutomaticLazyFactoryRequest(type))
                return GetLazyAutomaticFactoryRequest(type);

            if (IsIEnumerableRequest(type))
                return GetIEnumerableRequest(type);

            // Attempt unregistered construction if possible and requested
            if ((options.UnregisteredResolutionAction == UnregisteredResolutionActions.AttemptResolve) || (type.IsGenericType && options.UnregisteredResolutionAction == UnregisteredResolutionActions.GenericsOnly))
            {
                if (!type.IsAbstract && !type.IsInterface)
                    return ConstructType(null, type, parameters, options);
            }

            // Unable to resolve - throw
            throw new TinyIoCResolutionException(type);
        }

        private readonly SafeDictionary<Type, object> _LazyAutomaticFactories = new();
        private object GetLazyAutomaticFactoryRequest(Type type)
        {
            if (!type.IsGenericType)
                return null;

            if (_LazyAutomaticFactories.TryGetValue(type, out var retVal))
                return retVal;

            Type genericType = type.GetGenericTypeDefinition();
            Type[] genericArguments = type.GetGenericArguments();

            // Just a func
            if (genericType == typeof(Func<>))
            {
                Type returnType = genericArguments[0];

                MethodInfo resolveMethod = typeof(TinyIoCContainer).GetMethod("Resolve", new Type[] { });

                resolveMethod = resolveMethod.MakeGenericMethod(returnType);

                var resolveCall = Expression.Call(Expression.Constant(this), resolveMethod);

                var resolveLambda = Expression.Lambda(resolveCall).Compile();

                _LazyAutomaticFactories[type] = resolveLambda;

                return resolveLambda;
            }

            // 2 parameter func with string as first parameter (name)
            if ((genericType == typeof(Func<,>)) && (genericArguments[0] == typeof(string)))
            {
                Type returnType = genericArguments[1];

                MethodInfo resolveMethod = typeof(TinyIoCContainer).GetMethod("Resolve", new Type[] { typeof(String) });

                resolveMethod = resolveMethod.MakeGenericMethod(returnType);

                ParameterExpression[] resolveParameters = new ParameterExpression[] { Expression.Parameter(typeof(String), "name") };
                var resolveCall = Expression.Call(Expression.Constant(this), resolveMethod, resolveParameters);

                var resolveLambda = Expression.Lambda(resolveCall, resolveParameters).Compile();

                _LazyAutomaticFactories[type] = resolveLambda;

                return resolveLambda;
            }

            // 3 parameter func with string as first parameter (name) and IDictionary<string, object> as second (parameters)
            if ((genericType == typeof(Func<,,>) && type.GetGenericArguments()[0] == typeof(string) && type.GetGenericArguments()[1] == typeof(IDictionary<string, object>)))
            {
                Type returnType = genericArguments[2];

                var name = Expression.Parameter(typeof(string), "name");
                var parameters = Expression.Parameter(typeof(IDictionary<string, object>), "parameters");

                MethodInfo resolveMethod = typeof(TinyIoCContainer).GetMethod("Resolve", new Type[] { typeof(String), typeof(NamedParameterOverloads) });

                resolveMethod = resolveMethod.MakeGenericMethod(returnType);

                var resolveCall = Expression.Call(Expression.Constant(this), resolveMethod, name, Expression.Call(typeof(NamedParameterOverloads), "FromIDictionary", null, parameters));

                var resolveLambda = Expression.Lambda(resolveCall, name, parameters).Compile();

                _LazyAutomaticFactories[type] = resolveLambda;

                return resolveLambda;
            }

            throw new TinyIoCResolutionException(type);
        }
        private object GetIEnumerableRequest(Type type)
        {
            var genericResolveAllMethod = this.GetType().GetGenericMethod(BindingFlags.Public | BindingFlags.Instance, "ResolveAll", type.GetGenericArguments(), new[] { typeof(bool) });

            return genericResolveAllMethod.Invoke(this, new object[] { false });
        }

        private bool CanConstruct(ConstructorInfo ctor, NamedParameterOverloads parameters, ResolveOptions options)
        {
            if (parameters == null)
                throw new ArgumentNullException("parameters");

            foreach (var parameter in ctor.GetParameters())
            {
                if (string.IsNullOrEmpty(parameter.Name))
                    return false;

                var isParameterOverload = parameters.ContainsKey(parameter.Name);

                if (parameter.ParameterType.IsPrimitive && !isParameterOverload)
                    return false;

                if (!isParameterOverload && !CanResolveInternal(parameter.ParameterType, NamedParameterOverloads.Default, options))
                    return false;
            }

            return true;
        }

        private ConstructorInfo GetBestConstructor(Type type, NamedParameterOverloads parameters, ResolveOptions options)
        {
            if (parameters == null)
                throw new ArgumentNullException("parameters");

            if (type.IsValueType)
                return null;

            // Get constructors in reverse order based on the number of parameters
            // i.e. be as "greedy" as possible so we satify the most amount of dependencies possible
            var ctors = TinyIoCReflectionCache.GetUsableConstructors(type);

            foreach (var ctor in ctors)
            {
                if (this.CanConstruct(ctor, parameters, options))
                    return ctor;
            }

            return null;
        }

        private object ConstructType(Type requestedType, Type implementationType, ResolveOptions options)
        {
            return ConstructType(requestedType, implementationType, null, NamedParameterOverloads.Default, options);
        }

        private object ConstructType(Type requestedType, Type implementationType, ConstructorInfo constructor, ResolveOptions options)
        {
            return ConstructType(requestedType, implementationType, constructor, NamedParameterOverloads.Default, options);
        }

        private object ConstructType(Type requestedType, Type implementationType, NamedParameterOverloads parameters, ResolveOptions options)
        {
            return ConstructType(requestedType, implementationType, null, parameters, options);
        }

        private object ConstructType(Type requestedType, Type implementationType, ConstructorInfo constructor, NamedParameterOverloads parameters, ResolveOptions options)
        {
            var typeToConstruct = implementationType;

            if (implementationType.IsGenericTypeDefinition)
            {
                typeToConstruct = TinyIoCReflectionCache.GetGenericImplementationType(typeToConstruct, requestedType);
            }

            if (constructor == null)
            {
                // Try and get the best constructor that we can construct
                // if we can't construct any then get the constructor
                // with the least number of parameters so we can throw a meaningful
                // resolve exception
                constructor = GetBestConstructor(typeToConstruct, parameters, options) ?? TinyIoCReflectionCache.GetUsableConstructors(typeToConstruct).LastOrDefault();
            }

            if (constructor == null)
                throw new TinyIoCResolutionException(typeToConstruct);

            var ctorParams = constructor.GetParameters();
            object[] args = new object[ctorParams.Length];

            for (int parameterIndex = 0; parameterIndex < ctorParams.Length; parameterIndex++)
            {
                var currentParam = ctorParams[parameterIndex];

                try
                {
                    args[parameterIndex] = parameters.ContainsKey(currentParam.Name) ?
                                                                                        parameters[currentParam.Name] :
                                                                                        ResolveInternal(
                                                                                                currentParam.ParameterType,
                                                                                                NamedParameterOverloads.Default,
                                                                                                options);
                }
                catch (TinyIoCResolutionException ex)
                {
                    // If a constructor parameter can't be resolved
                    // it will throw, so wrap it and throw that this can't
                    // be resolved.
                    throw new TinyIoCResolutionException(typeToConstruct, ex);
                }
                catch (Exception ex)
                {
                    throw new TinyIoCResolutionException(typeToConstruct, ex);
                }
            }

            try
            {
                var constructionDelegate = CreateObjectConstructionDelegateWithCache(constructor);
                return constructionDelegate.Invoke(args);
            }
            catch (Exception ex)
            {
                throw new TinyIoCResolutionException(typeToConstruct, ex);
            }
        }

        private static ObjectConstructor CreateObjectConstructionDelegateWithCache(ConstructorInfo constructor)
        {
            ObjectConstructor objectConstructor;
            if (_ObjectConstructorCache.TryGetValue(constructor, out objectConstructor))
                return objectConstructor;

            // We could lock the cache here, but there's no real side
            // effect to two threads creating the same ObjectConstructor
            // at the same time, compared to the cost of a lock for 
            // every creation.
            var constructorParams = constructor.GetParameters();
            var lambdaParams = Expression.Parameter(typeof(object[]), "parameters");
            var newParams = new Expression[constructorParams.Length];

            for (int i = 0; i < constructorParams.Length; i++)
            {
                var paramsParameter = Expression.ArrayIndex(lambdaParams, Expression.Constant(i));

                newParams[i] = Expression.Convert(paramsParameter, constructorParams[i].ParameterType);
            }

            var newExpression = Expression.New(constructor, newParams);

            var constructionLambda = Expression.Lambda(typeof(ObjectConstructor), newExpression, lambdaParams);

            objectConstructor = (ObjectConstructor)constructionLambda.Compile();

            _ObjectConstructorCache[constructor] = objectConstructor;
            return objectConstructor;
        }

        private void BuildUpInternal(object input, ResolveOptions resolveOptions)
        {
            var properties = from property in input.GetType().GetProperties()
                             where (property.GetGetMethod() != null) && (property.GetSetMethod() != null) && !property.PropertyType.IsValueType
                             select property;

            foreach (var property in properties)
            {
                if (property.GetValue(input, null) == null)
                {
                    try
                    {
                        property.SetValue(input, ResolveInternal(property.PropertyType, NamedParameterOverloads.Default, resolveOptions), null);
                    }
                    catch (TinyIoCResolutionException)
                    {
                        // Catch any resolution errors and ignore them
                    }
                }
            }
        }

        private IEnumerable<Type> GetParentRegistrationsForType(Type resolveType)
        {
            if (_Parent == null)
                return new Type[] { };

            var registrations = _Parent._RegisteredTypes.Keys.Where(tr => tr == resolveType);

            return registrations.Concat(_Parent.GetParentRegistrationsForType(resolveType));
        }

        private IEnumerable<object> ResolveAllInternal(Type resolveType, bool includeUnnamed)
        {
            var registrations = _RegisteredTypes.Keys.Where(tr => tr == resolveType).Concat(GetParentRegistrationsForType(resolveType)).Distinct();

            if (!includeUnnamed)
                registrations = registrations.Where(tr => tr.Name != string.Empty);

            return registrations.Select(registration => this.ResolveInternal(registration, NamedParameterOverloads.Default, ResolveOptions.Default));
        }

        private static bool IsValidAssignment(Type registerType, Type registerImplementation)
        {
            if (!registerType.IsGenericTypeDefinition)
            {
                if (!registerType.IsAssignableFrom(registerImplementation))
                    return false;
            }
            else
            {
                if (registerType.IsInterface)
                {
                    if (!registerImplementation.FindInterfaces((t, o) => t.Name == registerType.Name, null).Any())
                        return false;
                }
                else if (registerType.IsAbstract && registerImplementation.BaseType != registerType)
                {
                    return false;
                }
            }
            //#endif
            return true;
        }

        #endregion

        #region IDisposable Members
        bool disposed = false;
        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;

                _RegisteredTypes.Dispose();

                GC.SuppressFinalize(this);
            }
        }

        #endregion
    }

    [AttributeUsage(AttributeTargets.Constructor, Inherited = false, AllowMultiple = false)]
    internal sealed class TinyIoCConstructorAttribute : Attribute
    {
    }

    internal static class TinyIoCReflectionCache
    {
        private static readonly SafeDictionary<Type, ConstructorInfo[]> _UsableConstructors = new SafeDictionary<Type, ConstructorInfo[]>();
        private static readonly SafeDictionary<string, Type> _GenericTypes = new SafeDictionary<string, Type>();

        public static IEnumerable<ConstructorInfo> GetUsableConstructors(Type type)
        {
            // Get constructors in reverse order based on the number of parameters
            // i.e. be as "greedy" as possible so we satify the most amount of dependencies possible

            if (!_UsableConstructors.TryGetValue(type, out var constructors))
            {
                var candidateCtors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(x => !x.IsPrivate) // Includes internal constructors but not private constructors
                    .Where(x => !x.IsFamily) // Excludes protected constructors
                    .ToList();

                var attributeCtors = candidateCtors.Where(x => x.GetCustomAttributes(typeof(TinyIoCConstructorAttribute), false).Any())
                    .ToList();

                if (attributeCtors.Any())
                    candidateCtors = attributeCtors;

                constructors = candidateCtors.OrderByDescending(ctor => ctor.GetParameters().Length).ToArray();

                _UsableConstructors[type] = constructors;
            }

            return constructors;
        }

        internal static Type GetGenericImplementationType(Type typeToConstruct, Type requestedType)
        {
            var key = typeToConstruct.FullName + ":" + requestedType.FullName;
            if (!_GenericTypes.TryGetValue(key, out var retVal))
            {
                Type[] genericTypeArguments = null;
                if (requestedType == null || !requestedType.IsGenericType || !(genericTypeArguments = requestedType.GetGenericArguments()).Any())
                    throw new TinyIoCResolutionException(typeToConstruct);

                retVal = typeToConstruct.MakeGenericType(genericTypeArguments);
                _GenericTypes[key] = retVal;
            }

            return retVal;
        }
    }
}