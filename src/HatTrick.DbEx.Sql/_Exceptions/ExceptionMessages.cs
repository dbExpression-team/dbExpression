#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Resources;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace HatTrick.DbEx.Sql
{
    public static class ExceptionMessages
    {
        private static Lazy<ResourceManager> exceptionMessages = new Lazy<ResourceManager>(() => new ResourceManager("HatTrick.DbEx.Sql._Resources.ExceptionMessages", typeof(ExceptionMessages).Assembly));       

        public static string InitializeStaticRuntime(Type databaseType)
            => BuildExceptionMessage(nameof(InitializeStaticRuntime), databaseType.FullName ?? databaseType.Name);

        public static string DatabaseBuilderAggregate()
            => BuildExceptionMessage(nameof(DatabaseBuilderAggregate));

        public static string RegistrationBuilderType(Type builderType, Type implementationType)
            => BuildExceptionMessage(nameof(RegistrationBuilderType), builderType, implementationType);

        public static string DuplicateRegistration<T>()
            => DuplicateRegistration(typeof(T));

        public static string DuplicateRegistration(Type registrationType)
            => BuildExceptionMessage(nameof(DuplicateRegistration), registrationType.FullName ?? registrationType.Name);

        public static string ServiceResolution<T>()
            => ServiceResolution(typeof(T));

        public static string ServiceResolution(Type serviceType)
            => BuildExceptionMessage(nameof(ServiceResolution), serviceType.FullName ?? serviceType.Name);

        public static string RegistrationAdapter(ServiceDescriptor descriptor)
            => BuildExceptionMessage(nameof(RegistrationAdapter), descriptor);

        public static string ServiceRegistration(Type concreteType, Type implementationType)
            => BuildExceptionMessage(nameof(ServiceRegistration), concreteType, implementationType);

        public static string WrongFactoryType(Type factoryType, Type serviceType)
            => BuildExceptionMessage(nameof(WrongFactoryType), factoryType.FullName ?? factoryType.Name, serviceType.FullName ?? serviceType.Name);

        public static string WrongType(Type? actualType, Type expectedType)
            => BuildExceptionMessage(nameof(WrongType), actualType?.FullName ?? actualType?.Name ?? "NULL", expectedType.FullName ?? expectedType.Name);

        public static string ValueMustBeGreaterThan<T>(T providedValue, T minimumValue)
            => BuildExceptionMessage(nameof(ValueMustBeGreaterThan), providedValue, minimumValue);

        public static string MetadataResolution(string metadataTargetType, string metadataTargetName)
            => BuildExceptionMessage(nameof(MetadataResolution), metadataTargetType, metadataTargetName);

        public static string MetadataResolution(Type metadataTargetType, string metadataTargetName)
            => BuildExceptionMessage(nameof(MetadataResolution), metadataTargetType.FullName ?? metadataTargetType.Name, metadataTargetName);

        public static string DataMappingFailed(Type convertToType)
            => BuildExceptionMessage(nameof(DataMappingFailed), convertToType.FullName ?? convertToType.Name);

        public static string NullValueUnexpected()
            => BuildExceptionMessage(nameof(NullValueUnexpected));

        public static string DateConversionCausesLossOfTimeZoneInformation(Type convertToType, Type actualType)
            => BuildExceptionMessage(nameof(DateConversionCausesLossOfTimeZoneInformation), convertToType.FullName ?? convertToType.Name, actualType.FullName ?? actualType.Name);

        public static string PipelineEventFailed(string eventName, string queryType)
            => BuildExceptionMessage(nameof(PipelineEventFailed), eventName, queryType);

        public static string UpdatePipelineEventNoFieldFound(string fieldName, string entityName)
            => BuildExceptionMessage(nameof(UpdatePipelineEventNoFieldFound), fieldName, entityName);

        public static string UpdatePipelineEventSetValueFailed(string fieldName, object? value)
            => BuildExceptionMessage(nameof(UpdatePipelineEventSetValueFailed), fieldName, value);

        public static string ValueConversionFailed(object? value, Type? fromType, Type toType)
            => BuildExceptionMessage(nameof(ValueConversionFailed), value, fromType?.FullName ?? fromType?.Name ?? "NULL", toType.FullName ?? toType.Name);

        public static string UnsupportedCodeGenTemplateVersion(string runtimeVersion, string templateVersion, IEnumerable<string> compatibleRuntimeVersions)
        {
            string inner = compatibleRuntimeVersions.Aggregate(string.Empty, (x, y) => 
                { 
                    if (y == compatibleRuntimeVersions.First())
                        return $"'{y}'";
                    return x += (y == compatibleRuntimeVersions.Last() ? " & " : ", ") + $"'{y}'";
                });

            return BuildExceptionMessage(nameof(UnsupportedCodeGenTemplateVersion), runtimeVersion, templateVersion, inner);
        }

        public static string InsertExpectedIntegerAsFirstField()
            => BuildExceptionMessage(nameof(InsertExpectedIntegerAsFirstField));

        public static string WrongDbCommandType(Type actualType, Type expectedType)
            => BuildExceptionMessage(nameof(WrongDbCommandType), expectedType, actualType);

        private static string BuildExceptionMessage(string messageKey, params object?[] values)
        {
            try
            {
                var template = GetMessageTemplate(messageKey);
                return string.Format(template, values);
            }
            catch (InvalidOperationException e)
            {
                return e.Message;
            }
            catch (Exception)
            {
                return $"An error occurred formatting an exception message for '{messageKey}'.  This is an internal exception and should be reported as an issue.";
            }
        }

        private static string GetMessageTemplate(string resourceName)
        {
            var msgTemplate = exceptionMessages.Value.GetString($"{resourceName}Exception");
            if (string.IsNullOrWhiteSpace(msgTemplate))
                throw new InvalidOperationException($"The requested message template '{resourceName}' was not found in the resource file.  This is an internal exception and should be reported as an issue.");
            return msgTemplate;
        }
    }
}
