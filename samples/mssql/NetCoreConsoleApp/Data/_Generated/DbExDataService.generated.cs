using HatTrick.DbEx.MsSql.Builder;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CA1034 // Nested types should not be visible
namespace SimpleConsole.DataService
{
	using SimpleConsole.dboDataService;
	using SimpleConsole.secDataService;
	using _dboDataService = SimpleConsole.dboDataService;
	using _secDataService = SimpleConsole.secDataService;

    #region db
    public static class db
    {
        #region internals
        private static SimpleConsoleDb _simpleconsoledb;
        private static SimpleConsoleDb SimpleConsoleDb => _simpleconsoledb ?? throw new DbExpressionConfigurationException("the database 'SimpleConsoleDb' has not been properly configured for runtime use with dbExpression.");
        #endregion

        #region interface
        public static MsSqlFunctionExpressionBuilder fx => SimpleConsoleDb.fx;
        public static SimpleConsoleDb.SimpleConsoleDbStoredProcedures sp => SimpleConsoleDb.sp;
        #endregion

        #region methods
        internal static void UseDatabase(SimpleConsoleDb simpleconsoledb)
            => _simpleconsoledb = simpleconsoledb ?? throw new ArgumentNullException(nameof(simpleconsoledb));
        
        #region select one
        /// <summary>
        /// Start constructing a sql SELECT query expression for a single entity.
        /// <para>
        /// To retrieve a <see cref="SimpleConsole.dboData.AccessAuditLog" />, use a type param of <see cref="SimpleConsole.dboData.AccessAuditLog" />
        /// </para>
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectEntity{SimpleConsoleDb, TEntity}"/>, a fluent builder for constructing a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        /// <typeparam name="TEntity">The entity type to select.</typeparam>
        public static SelectEntity<SimpleConsoleDb, TEntity> SelectOne<TEntity>()
            where TEntity : class, IDbEntity, new()
            => SimpleConsoleDb.SelectOne<TEntity>();

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="TEnum"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />
        ///, for example "dbo.AccessAuditLog.AccessResult"
        /// </param>
        /// <returns><see cref="Sql.SelectValue{SimpleConsoleDb, TEnum}"/>, a fluent builder for constructing a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        /// <typeparam name="TEnum">The type of the Enum to select.</typeparam>
        public static SelectValue<SimpleConsoleDb, TEnum> SelectOne<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => SimpleConsoleDb.SelectOne<TEnum>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="TEnum"/>? value.  
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />?
        ///, for example "dbo.Address.AddressType"
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TEnum}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="TEnum">The type of the Enum to select.</typeparam>
        public static SelectValue<SimpleConsoleDb, TEnum?> SelectOne<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable
            => SimpleConsoleDb.SelectOne<TEnum>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="object"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, object}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, object> SelectOne(ObjectElement element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="object"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, object}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, object> SelectOne(NullableObjectElement element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="T"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement{T}" />
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the object to select.</typeparam>
        public static SelectObject<SimpleConsoleDb, T> SelectOne<T>(ObjectElement<T> element)
            where T : class
            => SimpleConsoleDb.SelectOne<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="T"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AliasedElement{T}" />      
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the value to select.</typeparam>
        public static SelectValue<SimpleConsoleDb, T> SelectOne<T>(AliasedElement<T> element)
            => SimpleConsoleDb.SelectOne<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="bool" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Boolean}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, bool> SelectOne(AnyElement<bool> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="bool" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />?
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Boolean}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, bool?> SelectOne(AnyElement<bool?> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Byte}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, byte> SelectOne(AnyElement<byte> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />?
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Byte}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, byte?> SelectOne(AnyElement<byte?> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" />[] value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte[]}" />
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Byte[]}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, byte[]> SelectOne(AnyElement<byte[]> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTime" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />
        ///, for example "dbo.AccessAuditLog.DateCreated", "db.fx.DateAdd(DateParts.Year, 1, dbo.AccessAuditLog.DateCreated) or "db.fx.IsNull(dbo.AccessAuditLog.DateCreated, DateTime.Now)"
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, DateTime}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, DateTime> SelectOne(AnyElement<DateTime> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTime" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />?
        ///, for example "dbo.Person.BirthDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.BirthDate)
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, DateTime}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, DateTime?> SelectOne(AnyElement<DateTime?> field)
            => SimpleConsoleDb.SelectOne(field);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTimeOffset" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />
        ///, for example "dbo.Person.RegistrationDate", "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.RegistrationDate)" or "db.fx.IsNull(dbo.Person.RegistrationDate, DateTimeOffset.Now)"
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, DateTimeOffset}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, DateTimeOffset> SelectOne(AnyElement<DateTimeOffset> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTimeOffset" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />?
        ///, for example "dbo.Person.LastLoginDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.LastLoginDate)" 
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, DateTimeOffset}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, DateTimeOffset?> SelectOne(AnyElement<DateTimeOffset?> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="decimal" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />
        ///, for example "dbo.Product.ShippingWeight" or "db.fx.IsNull(dbo.Product.ShippingWeight, decimal.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Decimal}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, decimal> SelectOne(AnyElement<decimal> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="decimal" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />?
        ///, for example "dbo.Product.Height" or "db.fx.Min(dbo.Product.Height)"
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Decimal}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, decimal?> SelectOne(AnyElement<decimal?> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="double" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />
        ///, for example "dbo.Product.ListPrice" or "db.fx.IsNull(dbo.Product.ListPrice, double.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Double}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, double> SelectOne(AnyElement<double> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="double" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />?
        ///, for example "dbo.PersonTotalPurchasesView.TotalAmount" or "db.fx.Min(dbo.PersonTotalPurchasesView.TotalAmount)"
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Double}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, double?> SelectOne(AnyElement<double?> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="Guid" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Guid}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, Guid> SelectOne(AnyElement<Guid> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="Guid" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />?
        ///, for example "dbo.Purchase.TrackingIdentifier"
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Guid}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, Guid?> SelectOne(AnyElement<Guid?> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="short" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Int16}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, short> SelectOne(AnyElement<short> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="short" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />?
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Int16}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, short?> SelectOne(AnyElement<short?> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="int" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />?
        ///, for example "dbo.AccessAuditLog.Id" or "db.fx.Avg(dbo.AccessAuditLog.Id)"
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Int32}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, int> SelectOne(AnyElement<int> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="int" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />?
        ///, for example "dbo.Person.CreditLimit" or "db.fx.Avg(dbo.Person.CreditLimit)"
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Int32}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, int?> SelectOne(AnyElement<int?> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="long" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Int64}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, long> SelectOne(AnyElement<long> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="long" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />?
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Int64}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, long?> SelectOne(AnyElement<long?> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="float" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Single}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, float> SelectOne(AnyElement<float> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="float" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />?
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, Single}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, float?> SelectOne(AnyElement<float?> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="string" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, String}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, string> SelectOne(StringElement element) 
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="string" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, String}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, string> SelectOne(NullableStringElement element) 
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="TimeSpan" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TimeSpan}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, TimeSpan> SelectOne(AnyElement<TimeSpan> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="TimeSpan" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />?
        ///, for example "dbo.Product.ValidStartTimeOfDayForPurchase"
        ///</param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TimeSpan}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<SimpleConsoleDb, TimeSpan?> SelectOne(AnyElement<TimeSpan?> element)
            => SimpleConsoleDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="element2">Any expression</param>
        /// <param name="elements">Any expression</param>
        /// <returns><see cref="SelectDynamic{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectDynamic<SimpleConsoleDb> SelectOne(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => SimpleConsoleDb.SelectOne(element1, element2, elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="elements">A list of any expression</param>
        /// <returns><see cref="SelectDynamic{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectDynamic<SimpleConsoleDb> SelectOne(IEnumerable<AnyElement> elements)
            => SimpleConsoleDb.SelectOne(elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression that is valid for a SELECT query expression.</param>
        /// <param name="additionalElements">Any additional fields to select as part of the SELECT query expression.</param>
        /// <returns><see cref="SelectDynamics{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectDynamic<SimpleConsoleDb> SelectOne(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
            => SimpleConsoleDb.SelectOne((elements ?? throw new ArgumentNullException(nameof(elements))).Concat(additionalElements));
        #endregion

        #region select many
        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of entities.
        /// <para>
        /// To retrieve a list of <see cref="SimpleConsole.dboData.AccessAuditLog" />(s), use a type param of <see cref="SimpleConsole.dboData.AccessAuditLog" />
        /// </para>
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectEntities{SimpleConsoleDb, TEntity}"/>, a fluent builder for constructing a sql SELECT query expression for a list of <typeparamref name="TEntity"/> entities.</returns>
        /// <typeparam name="TEntity">The entity type to select.</typeparam>
        public static SelectEntities<SimpleConsoleDb, TEntity> SelectMany<TEntity>()
           where TEntity : class, IDbEntity, new()
           => SimpleConsoleDb.SelectMany<TEntity>();

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="TEnum"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />
        ///, for example "dbo.AccessAuditLog.AccessResult"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TEnum}"/>, a fluent builder for constructing a sql SELECT query expression for a list of <typeparamref name="TEntity"/> entities.</returns>
        public static SelectValues<SimpleConsoleDb, TEnum> SelectMany<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => SimpleConsoleDb.SelectMany<TEnum>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="TEnum"/>? values.
        /// </summary>
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />?
        ///, for example "dbo.Address.AddressType"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TEnum}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, TEnum?> SelectMany<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable
            => SimpleConsoleDb.SelectMany<TEnum>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="object"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, object}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, object> SelectMany(ObjectElement element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="object"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, object}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, object> SelectMany(NullableObjectElement element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="T"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement{T}" />
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the object to select.</typeparam>
        public static SelectObjects<SimpleConsoleDb, T> SelectMany<T>(ObjectElement<T> element)
            where T : class
            => SimpleConsoleDb.SelectMany<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="T"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AliasedElement{T}" />      
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the value to select.</typeparam>
        public static SelectValues<SimpleConsoleDb, T> SelectMany<T>(AliasedElement<T> element)
            => SimpleConsoleDb.SelectMany<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="bool" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Boolean}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, bool> SelectMany(AnyElement<bool> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="bool" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />?
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Boolean}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, bool?> SelectMany(AnyElement<bool?> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Byte}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, byte> SelectMany(AnyElement<byte> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />?
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Byte}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, byte?> SelectMany(AnyElement<byte?> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" />[] values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte[]}" />
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Byte[]}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, byte[]> SelectMany(AnyElement<byte[]> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTime" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />
        ///, for example "dbo.AccessAuditLog.DateCreated", "db.fx.DateAdd(DateParts.Year, 1, dbo.AccessAuditLog.DateCreated) or "db.fx.IsNull(dbo.AccessAuditLog.DateCreated, DateTime.Now)"
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, DateTime}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, DateTime> SelectMany(AnyElement<DateTime> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTime" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />?
        ///, for example "dbo.Person.BirthDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.BirthDate)
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, DateTime}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, DateTime?> SelectMany(AnyElement<DateTime?> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTimeOffset" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />
        ///, for example "dbo.Person.RegistrationDate", "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.RegistrationDate)" or "db.fx.IsNull(dbo.Person.RegistrationDate, DateTimeOffset.Now)"
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, DateTimeOffset}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, DateTimeOffset> SelectMany(AnyElement<DateTimeOffset> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTimeOffset" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />?
        ///, for example "dbo.Person.LastLoginDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.LastLoginDate)" 
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, DateTimeOffset}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, DateTimeOffset?> SelectMany(AnyElement<DateTimeOffset?> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="decimal" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />
        ///, for example "dbo.Product.ShippingWeight" or "db.fx.IsNull(dbo.Product.ShippingWeight, decimal.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Decimal}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, decimal> SelectMany(AnyElement<decimal> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="decimal" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />?
        ///, for example "dbo.Product.Height"
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Decimal}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, decimal?> SelectMany(AnyElement<decimal?> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="double" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />
        ///, for example "dbo.Product.ListPrice" or "db.fx.IsNull(dbo.Product.ListPrice, double.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Double}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, double> SelectMany(AnyElement<double> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="double" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />?
        ///, for example "dbo.PersonTotalPurchasesView.TotalAmount"
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Double}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, double?> SelectMany(AnyElement<double?> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="Guid" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Guid}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, Guid> SelectMany(AnyElement<Guid> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="Guid" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />?
        ///, for example "dbo.Purchase.TrackingIdentifier"
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Guid}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, Guid?> SelectMany(AnyElement<Guid?> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="short" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Int16}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, short> SelectMany(AnyElement<short> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="short" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />?
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Int16}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, short?> SelectMany(AnyElement<short?> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="int" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />
        ///, for example "dbo.AccessAuditLog.Id"
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Int32}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, int> SelectMany(AnyElement<int> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="int" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />?
        ///, for example "dbo.:column.Entity.Name}.CreditLimit"
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Int32}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, int?> SelectMany(AnyElement<int?> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="long" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Int64}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, long> SelectMany(AnyElement<long> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="long" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />?
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Int64}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, long?> SelectMany(AnyElement<long?> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="float" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Single}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, float> SelectMany(AnyElement<float> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="float" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />?
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, Single}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, float?> SelectMany(AnyElement<float?> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="string" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, String}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, string> SelectMany(StringElement element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="string" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, String}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, string> SelectMany(NullableStringElement element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="TimeSpan" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TimeSpan}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, TimeSpan> SelectMany(AnyElement<TimeSpan> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="TimeSpan" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />?
        ///, for example "dbo.Product.ValidStartTimeOfDayForPurchase"
        ///</param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TimeSpan}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<SimpleConsoleDb, TimeSpan?> SelectMany(AnyElement<TimeSpan?> element)
            => SimpleConsoleDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="element2">Any expression</param>
        /// <param name="elements">Any expression</param>
        /// <returns><see cref="SelectDynamics{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectDynamics<SimpleConsoleDb> SelectMany(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => SimpleConsoleDb.SelectMany(element1, element2, elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression</param>
        /// <returns><see cref="SelectDynamics{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectDynamics<SimpleConsoleDb> SelectMany(IEnumerable<AnyElement> elements)
            => SimpleConsoleDb.SelectMany(elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression that is valid for a SELECT query expression.</param>
        /// <param name="additionalElements">Any additional fields to select as part of the SELECT query expression.</param>
        /// <returns><see cref="SelectDynamics{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectDynamics<SimpleConsoleDb> SelectMany(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
            => SimpleConsoleDb.SelectMany((elements ?? throw new ArgumentNullException(nameof(elements))).Concat(additionalElements));
        #endregion

        #region update
        /// <summary>
        /// Start constructing a sql UPDATE query expression to update record(s).
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/update-transact-sql">Microsoft docs on UPDATE</see>
        /// </para>
        /// </summary>
        /// <param name="assignment">A <see cref="EntityFieldAssignment" /> assigning a database field/column a new value.  
        /// For example "dbo.Address.Line1.Set("new value")"
        /// or "dbo.Person.CreditLimit.Set(dbo.Person.CreditLimit + 10)"
        ///</param>
        /// <param name="assignments">An additional list of <see cref="EntityFieldAssignment" />(s) assigning database fields/columns new values.  </param>
        /// <returns><see cref="UpdateEntities{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql UPDATE statement.</returns>
        public static UpdateEntities<SimpleConsoleDb> Update(EntityFieldAssignment assignment, params EntityFieldAssignment[] assignments)
            => SimpleConsoleDb.Update(assignment, assignments);

        /// <summary>
        /// Start constructing a sql UPDATE query expression to update records.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/update-transact-sql">Microsoft docs on UPDATE</see>
        /// </para>
        /// </summary>
        /// <param name="assignments">A list of <see cref="EntityFieldAssignment" />(s) that assign a database field/column a new value.  
        /// For example "dbo.Address.Line1.Set("new value")"
        /// or "dbo.Person.CreditLimit.Set(dbo.Person.CreditLimit + 10)"
        ///</param>
        /// <returns><see cref="UpdateEntities{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql UPDATE statement.</returns>
        public static UpdateEntities<SimpleConsoleDb> Update(IEnumerable<EntityFieldAssignment> assignments)
            => SimpleConsoleDb.Update(assignments);   
        #endregion

        #region delete
        /// <summary>
        /// Start constructing a sql DELETE query expression to remove records.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/delete-transact-sql">Microsoft docs on DELETE</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="DeleteEntities{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql DELETE statement.</returns>
        public static DeleteEntities<SimpleConsoleDb> Delete()
            => SimpleConsoleDb.Delete();
        #endregion

        #region insert
        /// <summary>
        /// Start constructing a sql INSERT query expression to insert a record.  Property values from the <paramref name="entity"/> instance are used to create the record values for the INSERT statement. 
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/insert-transact-sql">Microsoft docs on INSERT</see>
        /// </para>
        /// </summary>
        /// <param name="entity">The entity supplying the property values.
        /// </param>
        /// <returns><see cref="InsertEntity{SimpleConsoleDb, TEntity}"/>, a fluent builder for constructing a sql INSERT statement.</returns>
        /// <typeparam name="TEntity">The entity type of the entity to insert.</typeparam>
        public static InsertEntity<SimpleConsoleDb, TEntity> Insert<TEntity>(TEntity entity)
            where TEntity : class, IDbEntity
            => SimpleConsoleDb.Insert<TEntity>(entity);

        /// <summary>
        /// Start constructing a sql INSERT query expression to insert one or more record.  The property values from each <paramref name="entities"/> entity instance are used to create the new record values for the INSERT statement.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/insert-transact-sql">Microsoft docs on INSERT</see>
        /// </para>
        /// </summary>
        /// <param name="entities">A list of entities.
        /// </param>
        /// <returns><see cref="InsertEntities{SimpleConsoleDb, TEntity}"/>, a fluent builder for constructing a sql INSERT statement.</returns>
        /// <typeparam name="TEntity">The entity type of the entities to insert.</typeparam>
        public static InsertEntities<SimpleConsoleDb, TEntity> InsertMany<TEntity>(TEntity entity, params TEntity[] entities)
            where TEntity : class, IDbEntity
            => SimpleConsoleDb.InsertMany<TEntity>(entity, entities);

        /// <summary>
        /// Start constructing a sql INSERT query expression to insert one or more record.  The property values from each <paramref name="entities"/> entity instance are used to create the new record values for the INSERT statement.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/insert-transact-sql">Microsoft docs on INSERT</see>
        /// </para>
        /// </summary>
        /// <param name="entities">A list of entities.
        /// </param>
        /// <returns><see cref="InsertEntities{SimpleConsoleDb, TEntity}"/>, a fluent builder for constructing a sql INSERT statement.</returns>
        /// <typeparam name="TEntity">The entity type of the entities to insert.</typeparam>
        public static InsertEntities<SimpleConsoleDb, TEntity> InsertMany<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IDbEntity
            => SimpleConsoleDb.InsertMany<TEntity>(entities);
        #endregion

        #region get connection
        /// <summary>
        /// Creates a connection to the database.
        /// <para>
        /// The connection has not been opened, use <see cref="System.Data.IDbConnection.Open"/> or <see cref="Connection.ISqlConnection.EnsureOpen"/> to ensure an open connection to the database prior to operations like <see cref="System.Data.IDbConnection.BeginTransaction"/>.
        /// </para>
        /// </summary>
        /// <returns><see cref="ISqlConnection"/>, a connection to the database.</returns>
        public static ISqlConnection GetConnection()
            => SimpleConsoleDb.GetConnection();
        #endregion

        #endregion
    }
    #endregion

    #region SimpleConsoleDb
    public class SimpleConsoleDb : ISqlDatabaseRuntime, 
        SelectOneInitiation<SimpleConsoleDb>, 
        SelectManyInitiation<SimpleConsoleDb>,
        UpdateEntitiesInitiation<SimpleConsoleDb>,
        DeleteEntitiesInitiation<SimpleConsoleDb>,
        InsertEntitiesInitiation<SimpleConsoleDb>
    {
        #region internals
        private static readonly SqlDatabaseMetadataProvider _metadata = new SqlDatabaseMetadataProvider(new SimpleConsoleDbSqlDatabaseMetadata("SimpleConsoleDb"));
        private static readonly MsSqlFunctionExpressionBuilder _fx = new MsSqlFunctionExpressionBuilder();
        private static readonly List<SchemaExpression> _schemas = new List<SchemaExpression>();
        private static readonly Dictionary<Type, Table> _entityTypeToTableMap = new Dictionary<Type, Table>();
        private readonly IQueryExpressionBuilderFactory<SimpleConsoleDb> _queryExpressionBuilderFactory;
        private readonly ISqlConnectionFactory _connectionFactory;
        private SimpleConsoleDbStoredProcedures _sp;
        #endregion

        #region interface
        ISqlDatabaseMetadataProvider ISqlDatabaseRuntime.MetadataProvider => _metadata;
        public MsSqlFunctionExpressionBuilder fx => _fx;
        public SimpleConsoleDbStoredProcedures sp => _sp ?? (_sp = new SimpleConsoleDbStoredProcedures(this, _schemas));
        #endregion

        #region constructors
        static SimpleConsoleDb()
        {
            var dboSchema = new _dboDataService.dboSchemaExpression("dbo");
            _schemas.Add(dboSchema);
            _dboDataService.dbo.UseSchema(dboSchema);
            _entityTypeToTableMap.Add(typeof(dboData.AccessAuditLog), dboSchema.AccessAuditLog);
            _entityTypeToTableMap.Add(typeof(dboData.Address), dboSchema.Address);
            _entityTypeToTableMap.Add(typeof(dboData.Person), dboSchema.Person);
            _entityTypeToTableMap.Add(typeof(dboData.PersonAddress), dboSchema.PersonAddress);
            _entityTypeToTableMap.Add(typeof(dboData.Product), dboSchema.Product);
            _entityTypeToTableMap.Add(typeof(dboData.Purchase), dboSchema.Purchase);
            _entityTypeToTableMap.Add(typeof(dboData.PurchaseLine), dboSchema.PurchaseLine);
            _entityTypeToTableMap.Add(typeof(dboData.PersonTotalPurchasesView), dboSchema.PersonTotalPurchasesView);

            var secSchema = new _secDataService.secSchemaExpression("sec");
            _schemas.Add(secSchema);
            _secDataService.sec.UseSchema(secSchema);
            _entityTypeToTableMap.Add(typeof(secData.Person), secSchema.Person);

        }

        public SimpleConsoleDb(
            IQueryExpressionBuilderFactory<SimpleConsoleDb> queryExpressionBuilderFactory,
            ISqlConnectionFactory connectionFactory        
        )
        {
            _queryExpressionBuilderFactory = queryExpressionBuilderFactory ?? throw new ArgumentNullException(nameof(queryExpressionBuilderFactory));
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }
        #endregion

        #region methods
        void ISqlDatabaseRuntime.InitializeStaticRuntime()
            => db.UseDatabase(this);

        protected IQueryExpressionBuilder<SimpleConsoleDb> GetBuilder()
            => _queryExpressionBuilderFactory.CreateQueryExpressionBuilder(this);

        #region select one
        /// <summary>
        /// Start constructing a sql SELECT query expression for a single entity.
        /// <para>
        /// To retrieve a <see cref="SimpleConsole.dboData.AccessAuditLog" />, use a type param of <see cref="SimpleConsole.dboData.AccessAuditLog" />
        /// </para>
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectEntity{SimpleConsoleDb, TEntity}"/>, a fluent builder for constructing a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        /// <typeparam name="TEntity">The entity type to select.</typeparam>
        public SelectEntity<SimpleConsoleDb, TEntity> SelectOne<TEntity>()
            where TEntity : class, IDbEntity, new()
            => GetBuilder().CreateSelectEntityBuilder<TEntity>(GetTable<TEntity>());

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="TEnum"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />
        ///, for example "dbo.AccessAuditLog.AccessResult"
        /// </param>
        /// <returns><see cref="Sql.SelectValue{SimpleConsoleDb, TEnum}"/>, a fluent builder for constructing a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        /// <typeparam name="TEnum">The type of the Enum to select.</typeparam>
        public SelectValue<SimpleConsoleDb, TEnum> SelectOne<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => GetBuilder().CreateSelectValueBuilder<TEnum>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="TEnum"/>? value.  
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />?
        ///, for example "dbo.Address.AddressType"
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TEnum}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="TEnum">The type of the Enum to select.</typeparam>
        public SelectValue<SimpleConsoleDb, TEnum?> SelectOne<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable
            => GetBuilder().CreateSelectValueBuilder<TEnum>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="object"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, object}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, object> SelectOne(ObjectElement element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="object"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, object}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, object> SelectOne(NullableObjectElement element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="T"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement{T}" />
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the object to select.</typeparam>
        public SelectObject<SimpleConsoleDb, T> SelectOne<T>(ObjectElement<T> element)
            where T : class
            => GetBuilder().CreateSelectValueBuilder<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="T"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AliasedElement{T}" />    
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, T> SelectOne<T>(AliasedElement<T> element)
            => GetBuilder().CreateSelectValueBuilder<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="bool" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, bool> SelectOne(AnyElement<bool> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="bool" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />?
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, bool?> SelectOne(AnyElement<bool?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, byte> SelectOne(AnyElement<byte> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />?
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, byte?> SelectOne(AnyElement<byte?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" />[] value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte[]}" />
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, byte[]> SelectOne(AnyElement<byte[]> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTime" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />
        ///, for example "dbo.AccessAuditLog.DateCreated", "db.fx.DateAdd(DateParts.Year, 1, dbo.AccessAuditLog.DateCreated) or "db.fx.IsNull(dbo.AccessAuditLog.DateCreated, DateTime.Now)"
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, DateTime> SelectOne(AnyElement<DateTime> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTime" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />?
        ///, for example "dbo.Person.BirthDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.BirthDate)
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, DateTime?> SelectOne(AnyElement<DateTime?> field)
            => GetBuilder().CreateSelectValueBuilder(field);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTimeOffset" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />
        ///, for example "dbo.Person.RegistrationDate", "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.RegistrationDate)" or "db.fx.IsNull(dbo.Person.RegistrationDate, DateTimeOffset.Now)"
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, DateTimeOffset> SelectOne(AnyElement<DateTimeOffset> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTimeOffset" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />?
        ///, for example "dbo.Person.LastLoginDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.LastLoginDate)" 
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, DateTimeOffset?> SelectOne(AnyElement<DateTimeOffset?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="decimal" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />
        ///, for example "dbo.Product.ShippingWeight" or "db.fx.IsNull(dbo.Product.ShippingWeight, decimal.MinValue)"
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, decimal> SelectOne(AnyElement<decimal> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="decimal" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />?
        ///, for example "dbo.Product.Height" or "db.fx.Min(dbo.Product.Height)"
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, decimal?> SelectOne(AnyElement<decimal?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="double" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />
        ///, for example "dbo.Product.ListPrice" or "db.fx.IsNull(dbo.Product.ListPrice, double.MinValue)"
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, double> SelectOne(AnyElement<double> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="double" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />?
        ///, for example "dbo.PersonTotalPurchasesView.TotalAmount" or "db.fx.Min(dbo.PersonTotalPurchasesView.TotalAmount)"
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, double?> SelectOne(AnyElement<double?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="Guid" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, Guid> SelectOne(AnyElement<Guid> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="Guid" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />?
        ///, for example "dbo.Purchase.TrackingIdentifier"
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, Guid?> SelectOne(AnyElement<Guid?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="short" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, short> SelectOne(AnyElement<short> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="short" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />?
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, short?> SelectOne(AnyElement<short?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="int" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />?
        ///, for example "dbo.AccessAuditLog.Id" or "db.fx.Avg(dbo.AccessAuditLog.Id)"
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, int> SelectOne(AnyElement<int> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="int" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />?
        ///, for example "dbo.Person.CreditLimit" or "db.fx.Avg(dbo.Person.CreditLimit)"
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, int?> SelectOne(AnyElement<int?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="long" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, long> SelectOne(AnyElement<long> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="long" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />?
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, long?> SelectOne(AnyElement<long?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="float" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, float> SelectOne(AnyElement<float> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="float" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />?
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, float?> SelectOne(AnyElement<float?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="string" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, String}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, string> SelectOne(StringElement element) 
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="string" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, String}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, string> SelectOne(NullableStringElement element) 
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="TimeSpan" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, TimeSpan> SelectOne(AnyElement<TimeSpan> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="TimeSpan" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />?
        ///, for example "dbo.Product.ValidStartTimeOfDayForPurchase"
        /// </param>
        /// <returns><see cref="SelectValue{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<SimpleConsoleDb, TimeSpan?> SelectOne(AnyElement<TimeSpan?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="element2">Any expression</param>
        /// <param name="elements">Any expression</param>
        /// <returns><see cref="SelectDynamic{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectDynamic<SimpleConsoleDb> SelectOne(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => GetBuilder().CreateSelectDynamicBuilder(element1, element2, elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="elements">A list of any expression</param>
        /// <returns><see cref="SelectDynamic{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectDynamic<SimpleConsoleDb> SelectOne(IEnumerable<AnyElement> elements)
            => GetBuilder().CreateSelectDynamicBuilder(elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression that is valid for a SELECT query expression.</param>
        /// <param name="additionalElements">Any additional fields to select as part of the SELECT query expression.</param>
        /// <returns><see cref="SelectDynamic{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectDynamic<SimpleConsoleDb> SelectOne(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
            => GetBuilder().CreateSelectDynamicBuilder((elements ?? throw new ArgumentNullException(nameof(elements))).Concat(additionalElements));
        #endregion

        #region select many
        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of entities.
        /// <para>
        /// To retrieve a list of <see cref="SimpleConsole.dboData.AccessAuditLog" />(s), use a type param of <see cref="SimpleConsole.dboData.AccessAuditLog" />
        /// </para>
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectEntities{SimpleConsoleDb, TEntity}"/>, a fluent builder for constructing a sql SELECT query expression for a list of <typeparamref name="TEntity"/> entities.</returns>
        /// <typeparam name="TEntity">The entity type to select.</typeparam>
        public SelectEntities<SimpleConsoleDb, TEntity> SelectMany<TEntity>()
           where TEntity : class, IDbEntity, new()
           => GetBuilder().CreateSelectEntitiesBuilder<TEntity>(GetTable<TEntity>());

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="TEnum"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />
        ///, for example "dbo.AccessAuditLog.AccessResult"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TEnum}"/>, a fluent builder for constructing a sql SELECT query expression for a list of <typeparamref name="TEntity"/> entities.</returns>
        public SelectValues<SimpleConsoleDb, TEnum> SelectMany<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => GetBuilder().CreateSelectValuesBuilder<TEnum>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="TEnum"/>? values.
        /// </summary>
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />?
        ///, for example "dbo.Address.AddressType"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TEnum}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, TEnum?> SelectMany<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable
            => GetBuilder().CreateSelectValuesBuilder<TEnum>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="object"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, object}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, object> SelectMany(ObjectElement element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="object"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, object}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, object> SelectMany(NullableObjectElement element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="T"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement{T}" />
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the object to select.</typeparam>
        public SelectObjects<SimpleConsoleDb, T> SelectMany<T>(ObjectElement<T> element)
            where T : class
            => GetBuilder().CreateSelectValuesBuilder<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="T"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AliasedElement{T}" />    
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, T> SelectMany<T>(AliasedElement<T> element)
            => GetBuilder().CreateSelectValuesBuilder<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="bool" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, bool> SelectMany(AnyElement<bool> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="bool" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />?
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, bool?> SelectMany(AnyElement<bool?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, byte> SelectMany(AnyElement<byte> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />?
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, byte?> SelectMany(AnyElement<byte?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" />[] values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte[]}" />
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, byte[]> SelectMany(AnyElement<byte[]> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTime" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />
        ///, for example "dbo.AccessAuditLog.DateCreated", "db.fx.DateAdd(DateParts.Year, 1, dbo.AccessAuditLog.DateCreated) or "db.fx.IsNull(dbo.AccessAuditLog.DateCreated, DateTime.Now)"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, DateTime> SelectMany(AnyElement<DateTime> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTime" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />?
        ///, for example "dbo.Person.BirthDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.BirthDate)
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, DateTime?> SelectMany(AnyElement<DateTime?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTimeOffset" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />
        ///, for example "dbo.Person.RegistrationDate", "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.RegistrationDate)" or "db.fx.IsNull(dbo.Person.RegistrationDate, DateTimeOffset.Now)"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, DateTimeOffset> SelectMany(AnyElement<DateTimeOffset> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTimeOffset" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />?
        ///, for example "dbo.Person.LastLoginDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.LastLoginDate)" 
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, DateTimeOffset?> SelectMany(AnyElement<DateTimeOffset?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="decimal" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />
        ///, for example "dbo.Product.ShippingWeight" or "db.fx.IsNull(dbo.Product.ShippingWeight, decimal.MinValue)"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, decimal> SelectMany(AnyElement<decimal> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="decimal" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />?
        ///, for example "dbo.Product.Height"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, decimal?> SelectMany(AnyElement<decimal?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="double" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />
        ///, for example "dbo.Product.ListPrice" or "db.fx.IsNull(dbo.Product.ListPrice, double.MinValue)"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, double> SelectMany(AnyElement<double> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="double" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />?
        ///, for example "dbo.PersonTotalPurchasesView.TotalAmount"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, double?> SelectMany(AnyElement<double?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="Guid" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, Guid> SelectMany(AnyElement<Guid> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="Guid" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />?
        ///, for example "dbo.Purchase.TrackingIdentifier"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, Guid?> SelectMany(AnyElement<Guid?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="short" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, short> SelectMany(AnyElement<short> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="short" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />?
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, short?> SelectMany(AnyElement<short?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="int" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />
        ///, for example "dbo.AccessAuditLog.Id"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, int> SelectMany(AnyElement<int> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="int" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />?
        ///, for example "dbo.:column.Entity.Name}.CreditLimit"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, int?> SelectMany(AnyElement<int?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="long" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, long> SelectMany(AnyElement<long> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="long" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />?
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, long?> SelectMany(AnyElement<long?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="float" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, float> SelectMany(AnyElement<float> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="float" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />?
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, float?> SelectMany(AnyElement<float?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="string" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, String}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, string> SelectMany(StringElement element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="string" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, String}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, string> SelectMany(NullableStringElement element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="TimeSpan" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, TimeSpan> SelectMany(AnyElement<TimeSpan> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="TimeSpan" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />?
        ///, for example "dbo.Product.ValidStartTimeOfDayForPurchase"
        /// </param>
        /// <returns><see cref="SelectValues{SimpleConsoleDb, TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<SimpleConsoleDb, TimeSpan?> SelectMany(AnyElement<TimeSpan?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="element2">Any expression</param>
        /// <param name="elements">Any expression</param>
        /// <returns><see cref="SelectDynamics{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectDynamics<SimpleConsoleDb> SelectMany(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => GetBuilder().CreateSelectDynamicsBuilder(element1, element2, elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression</param>
        /// <returns><see cref="SelectDynamics{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectDynamics<SimpleConsoleDb> SelectMany(IEnumerable<AnyElement> elements)
            => GetBuilder().CreateSelectDynamicsBuilder(elements);

            /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression that is valid for a SELECT query expression.</param>
        /// <param name="additionalElements">Any additional fields to select as part of the SELECT query expression.</param>
        /// <returns><see cref="SelectDynamics{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectDynamics<SimpleConsoleDb> SelectMany(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
            => GetBuilder().CreateSelectDynamicsBuilder((elements ?? throw new ArgumentNullException(nameof(elements))).Concat(additionalElements));
        #endregion

        #region update
        /// <summary>
        /// Start constructing a sql UPDATE query expression to update record(s).
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/update-transact-sql">Microsoft docs on UPDATE</see>
        /// </para>
        /// </summary>
        /// <param name="assignment">A <see cref="EntityFieldAssignment" /> assigning a database field/column a new value.  
        /// For example "dbo.Address.Line1.Set("new value")"
        /// or "dbo.Person.CreditLimit.Set(dbo.Person.CreditLimit + 10)"
        /// </param>
        /// <param name="assignments">An additional list of <see cref="EntityFieldAssignment" />(s) assigning database fields/columns new values.  </param>
        /// <returns><see cref="UpdateEntities{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql UPDATE statement.</returns>
        public UpdateEntities<SimpleConsoleDb> Update(EntityFieldAssignment assignment, params EntityFieldAssignment[] assignments)
            => GetBuilder().CreateUpdateExpressionBuilder(assignment, assignments);

        /// <summary>
        /// Start constructing a sql UPDATE query expression to update records.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/update-transact-sql">Microsoft docs on UPDATE</see>
        /// </para>
        /// </summary>
        /// <param name="assignments">A list of <see cref="EntityFieldAssignment" />(s) that assign a database field/column a new value.  
        /// For example "dbo.Address.Line1.Set("new value")"
        /// or "dbo.Person.CreditLimit.Set(dbo.Person.CreditLimit + 10)"
        /// </param>
        /// <returns><see cref="UpdateEntities{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql UPDATE statement.</returns>
        public UpdateEntities<SimpleConsoleDb> Update(IEnumerable<EntityFieldAssignment> assignments)
            => GetBuilder().CreateUpdateExpressionBuilder(assignments);   
        #endregion

        #region delete
        /// <summary>
        /// Start constructing a sql DELETE query expression to remove records.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/delete-transact-sql">Microsoft docs on DELETE</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="DeleteEntities{ SimpleConsoleDb }"/>, a fluent builder for constructing a sql DELETE statement.</returns>
        public DeleteEntities<SimpleConsoleDb> Delete()
            => GetBuilder().CreateDeleteExpressionBuilder();
        #endregion

        #region insert
        /// <summary>
        /// Start constructing a sql INSERT query expression to insert a record.  Property values from the <paramref name="entity"/> instance are used to create the record values for the INSERT statement. 
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/insert-transact-sql">Microsoft docs on INSERT</see>
        /// </para>
        /// </summary>
        /// <param name="entity">The entity supplying the property values.
        /// </param>
        /// <returns><see cref="InsertEntity{SimpleConsoleDb, TEntity}"/>, a fluent builder for constructing a sql INSERT statement.</returns>
        /// <typeparam name="TEntity">The entity type of the entity to insert.</typeparam>
        public InsertEntity<SimpleConsoleDb, TEntity> Insert<TEntity>(TEntity entity)
            where TEntity : class, IDbEntity
            => GetBuilder().CreateInsertExpressionBuilder<TEntity>(entity);

        /// <summary>
        /// Start constructing a sql INSERT query expression to insert one or more record.  The property values from each <paramref name="entities"/> entity instance are used to create the new record values for the INSERT statement.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/insert-transact-sql">Microsoft docs on INSERT</see>
        /// </para>
        /// </summary>
        /// <param name="entities">A list of entities.
        /// </param>
        /// <returns><see cref="InsertEntities{SimpleConsoleDb, TEntity}"/>, a fluent builder for constructing a sql INSERT statement.</returns>
        /// <typeparam name="TEntity">The entity type of the entities to insert.</typeparam>
        public InsertEntities<SimpleConsoleDb, TEntity> InsertMany<TEntity>(TEntity entity, params TEntity[] entities)
            where TEntity : class, IDbEntity
            => GetBuilder().CreateInsertExpressionBuilder<TEntity>(entity, entities);

        /// <summary>
        /// Start constructing a sql INSERT query expression to insert one or more record.  The property values from each <paramref name="entities"/> entity instance are used to create the new record values for the INSERT statement.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/insert-transact-sql">Microsoft docs on INSERT</see>
        /// </para>
        /// </summary>
        /// <param name="entities">A list of entities.
        /// </param>
        /// <returns><see cref="InsertEntities{SimpleConsoleDb, TEntity}"/>, a fluent builder for constructing a sql INSERT statement.</returns>
        /// <typeparam name="TEntity">The entity type of the entities to insert.</typeparam>
        public InsertEntities<SimpleConsoleDb, TEntity> InsertMany<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IDbEntity
            => GetBuilder().CreateInsertExpressionBuilder<TEntity>(entities);
        #endregion

        #region get connection
        /// <summary>
        /// Creates a connection to the database.
        /// <para>
        /// The connection has not been opened, use <see cref="System.Data.IDbConnection.Open"/> or <see cref="ISqlConnection.EnsureOpen"/> to ensure an open connection to the database prior to operations like <see cref="System.Data.IDbConnection.BeginTransaction"/>.
        /// </para>
        /// </summary>
        /// <returns><see cref="ISqlConnection"/>, a connection to the database.</returns>
        public ISqlConnection GetConnection()
            => new SqlConnector(_connectionFactory);
        #endregion

        protected virtual Table<TEntity> GetTable<TEntity>()
            where TEntity : class, IDbEntity
        {
            if (!_entityTypeToTableMap.ContainsKey(typeof(TEntity)))
                throw new DbExpressionException($"Entity type {typeof(TEntity)} is not known.");
            return _entityTypeToTableMap[typeof(TEntity)] as Table<TEntity> ?? throw new DbExpressionException($"Map contains an invalid reference for type {typeof(TEntity)}.");
        }
        #endregion

        #region sp
        public class SimpleConsoleDbStoredProcedures
        {
            #region internals
            private readonly dboStoredProcedures _dboStoredProcedures;
            private readonly secStoredProcedures _secStoredProcedures;
            #endregion

            #region interface
            /// <summary>
            /// Accessors to construct and execute stored procedure query expressions in the dbo schema.
            /// </summary>
            public dboStoredProcedures dbo => _dboStoredProcedures;

            /// <summary>
            /// Accessors to construct and execute stored procedure query expressions in the sec schema.
            /// </summary>
            public secStoredProcedures sec => _secStoredProcedures;

            #endregion

            #region constructors
            public SimpleConsoleDbStoredProcedures(SimpleConsoleDb database, IEnumerable<SchemaExpression> schemas)
            {
                if (database is null)
                    throw new ArgumentNullException(nameof(database));
                _dboStoredProcedures = new dboStoredProcedures(database, schemas.Single(s => s.Identifier == "dbo"));
                _secStoredProcedures = new secStoredProcedures(database, schemas.Single(s => s.Identifier == "sec"));
            }
            #endregion
        }

        #region classes
        /// <summary>
        /// Accessors to construct and execute stored procedure query expressions in the dbo schema.
        /// </summary>
        public class dboStoredProcedures
        {
            #region internals
            private readonly SimpleConsoleDb _database;
            private readonly SchemaExpression _dbo;
            #endregion

            #region constructors
            public dboStoredProcedures(SimpleConsoleDb database, SchemaExpression schema)
            {
                _database = database ?? throw new ArgumentNullException(nameof(database));
                _dbo = schema ?? throw new ArgumentNullException(nameof(schema));
            }
            #endregion

            #region methods
            /// <summary>
            /// Method to start constructing a stored procedure query expression for the SelectPerson_As_Dynamic_With_Input stored procedure.
            /// </summary>
            /// <param name="P1">The value to use for creating the stored procedure parameter @P1.
            /// <para>Database Properties:
            /// <list type="table">
            /// <item>
            /// <term>name</term><description>@P1</description>
            /// </item>
            /// <item>
            /// <term>sql type</term><description>int</description>
            /// </item>
            /// <item>
            /// <term>allow null</term><description>yes</description>
            /// </item>
            /// </list>
            /// </para>
            /// </param>
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation<SimpleConsoleDb> SelectPerson_As_Dynamic_With_Input(int? P1)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPerson_As_Dynamic_With_InputStoredProcedure("dbo", _dbo, P1));

            /// <summary>
            /// Method to start constructing a stored procedure query expression for the SelectPerson_As_Dynamic_With_Input_And_InputOutput stored procedure.
            /// </summary>
            /// <param name="P1">The value to use for creating the stored procedure parameter @P1.
            /// <para>Database Properties:
            /// <list type="table">
            /// <item>
            /// <term>name</term><description>@P1</description>
            /// </item>
            /// <item>
            /// <term>sql type</term><description>int</description>
            /// </item>
            /// <item>
            /// <term>allow null</term><description>yes</description>
            /// </item>
            /// </list>
            /// </para>
            /// </param>
            /// <param name="outputParameters">The delegate to manage the output parameters returned from execution of the stored procedure.</param>
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation<SimpleConsoleDb> SelectPerson_As_Dynamic_With_Input_And_InputOutput(int? P1, Action<ISqlOutputParameterList> outputParameters)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPerson_As_Dynamic_With_Input_And_InputOutputStoredProcedure("dbo", _dbo, P1, outputParameters));

            /// <summary>
            /// Method to start constructing a stored procedure query expression for the SelectPerson_As_Dynamic_With_Input_And_Output stored procedure.
            /// </summary>
            /// <param name="P1">The value to use for creating the stored procedure parameter @P1.
            /// <para>Database Properties:
            /// <list type="table">
            /// <item>
            /// <term>name</term><description>@P1</description>
            /// </item>
            /// <item>
            /// <term>sql type</term><description>int</description>
            /// </item>
            /// <item>
            /// <term>allow null</term><description>yes</description>
            /// </item>
            /// </list>
            /// </para>
            /// </param>
            /// <param name="outputParameters">The delegate to manage the output parameters returned from execution of the stored procedure.</param>
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation<SimpleConsoleDb> SelectPerson_As_Dynamic_With_Input_And_Output(int? P1, Action<ISqlOutputParameterList> outputParameters)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPerson_As_Dynamic_With_Input_And_OutputStoredProcedure("dbo", _dbo, P1, outputParameters));

            /// <summary>
            /// Method to start constructing a stored procedure query expression for the SelectPerson_As_DynamicList_With_Input stored procedure.
            /// </summary>
            /// <param name="P1">The value to use for creating the stored procedure parameter @P1.
            /// <para>Database Properties:
            /// <list type="table">
            /// <item>
            /// <term>name</term><description>@P1</description>
            /// </item>
            /// <item>
            /// <term>sql type</term><description>int</description>
            /// </item>
            /// <item>
            /// <term>allow null</term><description>yes</description>
            /// </item>
            /// </list>
            /// </para>
            /// </param>
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation<SimpleConsoleDb> SelectPerson_As_DynamicList_With_Input(int? P1)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPerson_As_DynamicList_With_InputStoredProcedure("dbo", _dbo, P1));

            /// <summary>
            /// Method to start constructing a stored procedure query expression for the SelectPerson_As_DynamicList_With_Input_And_InputOutput stored procedure.
            /// </summary>
            /// <param name="P1">The value to use for creating the stored procedure parameter @P1.
            /// <para>Database Properties:
            /// <list type="table">
            /// <item>
            /// <term>name</term><description>@P1</description>
            /// </item>
            /// <item>
            /// <term>sql type</term><description>int</description>
            /// </item>
            /// <item>
            /// <term>allow null</term><description>yes</description>
            /// </item>
            /// </list>
            /// </para>
            /// </param>
            /// <param name="outputParameters">The delegate to manage the output parameters returned from execution of the stored procedure.</param>
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation<SimpleConsoleDb> SelectPerson_As_DynamicList_With_Input_And_InputOutput(int? P1, Action<ISqlOutputParameterList> outputParameters)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPerson_As_DynamicList_With_Input_And_InputOutputStoredProcedure("dbo", _dbo, P1, outputParameters));

            /// <summary>
            /// Method to start constructing a stored procedure query expression for the SelectPerson_As_DynamicList_With_Input_And_Output stored procedure.
            /// </summary>
            /// <param name="P1">The value to use for creating the stored procedure parameter @P1.
            /// <para>Database Properties:
            /// <list type="table">
            /// <item>
            /// <term>name</term><description>@P1</description>
            /// </item>
            /// <item>
            /// <term>sql type</term><description>int</description>
            /// </item>
            /// <item>
            /// <term>allow null</term><description>yes</description>
            /// </item>
            /// </list>
            /// </para>
            /// </param>
            /// <param name="outputParameters">The delegate to manage the output parameters returned from execution of the stored procedure.</param>
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation<SimpleConsoleDb> SelectPerson_As_DynamicList_With_Input_And_Output(int? P1, Action<ISqlOutputParameterList> outputParameters)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPerson_As_DynamicList_With_Input_And_OutputStoredProcedure("dbo", _dbo, P1, outputParameters));

            /// <summary>
            /// Method to start constructing a stored procedure query expression for the SelectPersonId_As_ScalarValue_With_Input stored procedure.
            /// </summary>
            /// <param name="P1">The value to use for creating the stored procedure parameter @P1.
            /// <para>Database Properties:
            /// <list type="table">
            /// <item>
            /// <term>name</term><description>@P1</description>
            /// </item>
            /// <item>
            /// <term>sql type</term><description>int</description>
            /// </item>
            /// <item>
            /// <term>allow null</term><description>yes</description>
            /// </item>
            /// </list>
            /// </para>
            /// </param>
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation<SimpleConsoleDb> SelectPersonId_As_ScalarValue_With_Input(int? P1)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPersonId_As_ScalarValue_With_InputStoredProcedure("dbo", _dbo, P1));

            /// <summary>
            /// Method to start constructing a stored procedure query expression for the SelectPersonId_As_ScalarValue_With_Input_And_Default_Value stored procedure.
            /// </summary>
            /// <param name="P1">The value to use for creating the stored procedure parameter @P1.
            /// <para>Database Properties:
            /// <list type="table">
            /// <item>
            /// <term>name</term><description>@P1</description>
            /// </item>
            /// <item>
            /// <term>sql type</term><description>int</description>
            /// </item>
            /// <item>
            /// <term>allow null</term><description>yes</description>
            /// </item>
            /// </list>
            /// </para>
            /// </param>
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation<SimpleConsoleDb> SelectPersonId_As_ScalarValue_With_Input_And_Default_Value(int? P1)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPersonId_As_ScalarValue_With_Input_And_Default_ValueStoredProcedure("dbo", _dbo, P1));

            /// <summary>
            /// Method to start constructing a stored procedure query expression for the SelectPersonId_As_ScalarValue_With_Input_And_InputOutput stored procedure.
            /// </summary>
            /// <param name="P1">The value to use for creating the stored procedure parameter @P1.
            /// <para>Database Properties:
            /// <list type="table">
            /// <item>
            /// <term>name</term><description>@P1</description>
            /// </item>
            /// <item>
            /// <term>sql type</term><description>int</description>
            /// </item>
            /// <item>
            /// <term>allow null</term><description>yes</description>
            /// </item>
            /// </list>
            /// </para>
            /// </param>
            /// <param name="outputParameters">The delegate to manage the output parameters returned from execution of the stored procedure.</param>
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation<SimpleConsoleDb> SelectPersonId_As_ScalarValue_With_Input_And_InputOutput(int? P1, Action<ISqlOutputParameterList> outputParameters)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPersonId_As_ScalarValue_With_Input_And_InputOutputStoredProcedure("dbo", _dbo, P1, outputParameters));

            /// <summary>
            /// Method to start constructing a stored procedure query expression for the SelectPersonId_As_ScalarValue_With_Input_And_Output stored procedure.
            /// </summary>
            /// <param name="P1">The value to use for creating the stored procedure parameter @P1.
            /// <para>Database Properties:
            /// <list type="table">
            /// <item>
            /// <term>name</term><description>@P1</description>
            /// </item>
            /// <item>
            /// <term>sql type</term><description>int</description>
            /// </item>
            /// <item>
            /// <term>allow null</term><description>yes</description>
            /// </item>
            /// </list>
            /// </para>
            /// </param>
            /// <param name="outputParameters">The delegate to manage the output parameters returned from execution of the stored procedure.</param>
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation<SimpleConsoleDb> SelectPersonId_As_ScalarValue_With_Input_And_Output(int? P1, Action<ISqlOutputParameterList> outputParameters)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPersonId_As_ScalarValue_With_Input_And_OutputStoredProcedure("dbo", _dbo, P1, outputParameters));

            /// <summary>
            /// Method to start constructing a stored procedure query expression for the SelectPersonId_As_ScalarValueList_With_Input stored procedure.
            /// </summary>
            /// <param name="P1">The value to use for creating the stored procedure parameter @P1.
            /// <para>Database Properties:
            /// <list type="table">
            /// <item>
            /// <term>name</term><description>@P1</description>
            /// </item>
            /// <item>
            /// <term>sql type</term><description>int</description>
            /// </item>
            /// <item>
            /// <term>allow null</term><description>yes</description>
            /// </item>
            /// </list>
            /// </para>
            /// </param>
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation<SimpleConsoleDb> SelectPersonId_As_ScalarValueList_With_Input(int? P1)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPersonId_As_ScalarValueList_With_InputStoredProcedure("dbo", _dbo, P1));

            /// <summary>
            /// Method to start constructing a stored procedure query expression for the SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput stored procedure.
            /// </summary>
            /// <param name="P1">The value to use for creating the stored procedure parameter @P1.
            /// <para>Database Properties:
            /// <list type="table">
            /// <item>
            /// <term>name</term><description>@P1</description>
            /// </item>
            /// <item>
            /// <term>sql type</term><description>int</description>
            /// </item>
            /// <item>
            /// <term>allow null</term><description>yes</description>
            /// </item>
            /// </list>
            /// </para>
            /// </param>
            /// <param name="outputParameters">The delegate to manage the output parameters returned from execution of the stored procedure.</param>
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation<SimpleConsoleDb> SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput(int? P1, Action<ISqlOutputParameterList> outputParameters)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPersonId_As_ScalarValueList_With_Input_And_InputOutputStoredProcedure("dbo", _dbo, P1, outputParameters));

            /// <summary>
            /// Method to start constructing a stored procedure query expression for the SelectPersonId_As_ScalarValueList_With_Input_And_Output stored procedure.
            /// </summary>
            /// <param name="P1">The value to use for creating the stored procedure parameter @P1.
            /// <para>Database Properties:
            /// <list type="table">
            /// <item>
            /// <term>name</term><description>@P1</description>
            /// </item>
            /// <item>
            /// <term>sql type</term><description>int</description>
            /// </item>
            /// <item>
            /// <term>allow null</term><description>yes</description>
            /// </item>
            /// </list>
            /// </para>
            /// </param>
            /// <param name="outputParameters">The delegate to manage the output parameters returned from execution of the stored procedure.</param>
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation<SimpleConsoleDb> SelectPersonId_As_ScalarValueList_With_Input_And_Output(int? P1, Action<ISqlOutputParameterList> outputParameters)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPersonId_As_ScalarValueList_With_Input_And_OutputStoredProcedure("dbo", _dbo, P1, outputParameters));

            /// <summary>
            /// Method to start constructing a stored procedure query expression for the UpdatePersonCreditLimit_With_Inputs stored procedure.
            /// </summary>
            /// <param name="P1">The value to use for creating the stored procedure parameter @P1.
            /// <para>Database Properties:
            /// <list type="table">
            /// <item>
            /// <term>name</term><description>@P1</description>
            /// </item>
            /// <item>
            /// <term>sql type</term><description>int</description>
            /// </item>
            /// <item>
            /// <term>allow null</term><description>yes</description>
            /// </item>
            /// </list>
            /// </para>
            /// </param>
            /// <param name="CreditLimit">The value to use for creating the stored procedure parameter @CreditLimit.
            /// <para>Database Properties:
            /// <list type="table">
            /// <item>
            /// <term>name</term><description>@CreditLimit</description>
            /// </item>
            /// <item>
            /// <term>sql type</term><description>int</description>
            /// </item>
            /// <item>
            /// <term>allow null</term><description>yes</description>
            /// </item>
            /// </list>
            /// </para>
            /// </param>
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation<SimpleConsoleDb> UpdatePersonCreditLimit_With_Inputs(int? P1,int? CreditLimit)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new UpdatePersonCreditLimit_With_InputsStoredProcedure("dbo", _dbo, P1, CreditLimit));

            #endregion
        }

        /// <summary>
        /// Accessors to construct and execute stored procedure query expressions in the sec schema.
        /// </summary>
        public class secStoredProcedures
        {
            #region internals
            private readonly SimpleConsoleDb _database;
            private readonly SchemaExpression _sec;
            #endregion

            #region constructors
            public secStoredProcedures(SimpleConsoleDb database, SchemaExpression schema)
            {
                _database = database ?? throw new ArgumentNullException(nameof(database));
                _sec = schema ?? throw new ArgumentNullException(nameof(schema));
            }
            #endregion

            #region methods
            #endregion
        }

        #endregion
        #endregion
    }
    #endregion

}

namespace SimpleConsole.dboDataService
{
	using SimpleConsole.dboData;
	using System.Data;

    #region dbo schema expression
    public class dboSchemaExpression : SchemaExpression
    {
        #region interface
        public readonly AccessAuditLogEntity AccessAuditLog;
        public readonly AddressEntity Address;
        public readonly PersonEntity Person;
        public readonly PersonAddressEntity PersonAddress;
        public readonly ProductEntity Product;
        public readonly PurchaseEntity Purchase;
        public readonly PurchaseLineEntity PurchaseLine;
        public readonly PersonTotalPurchasesViewEntity PersonTotalPurchasesView;
        #endregion

        #region constructors
        public dboSchemaExpression(string identifier) : base(identifier)
        {
            Attributes.Entities.Add($"{identifier}.AccessAuditLog", AccessAuditLog = new AccessAuditLogEntity($"{identifier}.AccessAuditLog", "AccessAuditLog", this));
            Attributes.Entities.Add($"{identifier}.Address", Address = new AddressEntity($"{identifier}.Address", "Address", this));
            Attributes.Entities.Add($"{identifier}.Person", Person = new PersonEntity($"{identifier}.Person", "Person", this));
            Attributes.Entities.Add($"{identifier}.Person_Address", PersonAddress = new PersonAddressEntity($"{identifier}.Person_Address", "PersonAddress", this));
            Attributes.Entities.Add($"{identifier}.Product", Product = new ProductEntity($"{identifier}.Product", "Product", this));
            Attributes.Entities.Add($"{identifier}.Purchase", Purchase = new PurchaseEntity($"{identifier}.Purchase", "Purchase", this));
            Attributes.Entities.Add($"{identifier}.PurchaseLine", PurchaseLine = new PurchaseLineEntity($"{identifier}.PurchaseLine", "PurchaseLine", this));
            Attributes.Entities.Add($"{identifier}.PersonTotalPurchasesView", PersonTotalPurchasesView = new PersonTotalPurchasesViewEntity($"{identifier}.PersonTotalPurchasesView", "PersonTotalPurchasesView", this));
        }
        #endregion
    }
    #endregion

    #region access audit log entity expression
    public partial class AccessAuditLogEntity : EntityExpression<AccessAuditLog>
    {
        #region internals
        private SelectExpressionSet _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="SimpleConsole.dboDataService.AccessAuditLogEntity.IdField"/> representing the "dbo.AccessAuditLog.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.AccessAuditLogEntity.IdField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>identity</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;


        /// <summary>A <see cref="SimpleConsole.dboDataService.AccessAuditLogEntity.PersonIdField"/> representing the "dbo.AccessAuditLog.PersonId" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.AccessAuditLogEntity.PersonIdField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PersonId</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PersonIdField PersonId;


        /// <summary>A <see cref="SimpleConsole.dboDataService.AccessAuditLogEntity.AccessResultField"/> representing the "dbo.AccessAuditLog.AccessResult" column in the database, 
        /// with a .NET type of <see cref="SimpleConsole.Data.AccessAuditResult"/>.  The <see cref="SimpleConsole.dboDataService.AccessAuditLogEntity.AccessResultField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{SimpleConsole.Data.AccessAuditResult}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>AccessResult</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly AccessResultField AccessResult;


        /// <summary>A <see cref="SimpleConsole.dboDataService.AccessAuditLogEntity.DateCreatedField"/> representing the "dbo.AccessAuditLog.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="SimpleConsole.dboDataService.AccessAuditLogEntity.DateCreatedField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateCreated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateCreatedField DateCreated;

        #endregion

        #region constructors
        public AccessAuditLogEntity(string identifier, string name, Schema schema) : this(identifier, name, schema, null)
        {
        }

        private AccessAuditLogEntity(string identifier, string name, Schema schema, string alias) : base(identifier, name, schema, alias)
        {
            Attributes.Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Attributes.Fields.Add($"{identifier}.PersonId", PersonId = new PersonIdField($"{identifier}.PersonId", "PersonId", this));
            Attributes.Fields.Add($"{identifier}.AccessResult", AccessResult = new AccessResultField($"{identifier}.AccessResult", "AccessResult", this));
            Attributes.Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
        }
        #endregion

        #region methods
        public AccessAuditLogEntity As(string alias)
            => new AccessAuditLogEntity(this.Attributes.Identifier, this.Attributes.Name, this.Attributes.Schema, alias);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return _inclusiveSelectExpressionSet ?? (_inclusiveSelectExpressionSet = new SelectExpressionSet(
                new SelectExpression<int>(Id)
                ,new SelectExpression<int>(PersonId)
                ,new SelectExpression<SimpleConsole.Data.AccessAuditResult>(AccessResult)
                ,new SelectExpression<DateTime>(DateCreated)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet set = null;
            string aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(PersonId));
            set &= aliased != nameof(PersonId) ? new SelectExpression<int>(PersonId, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PersonId));

            aliased = alias(nameof(AccessResult));
            set &= aliased != nameof(AccessResult) ? new SelectExpression<SimpleConsole.Data.AccessAuditResult>(AccessResult, aliased) as SelectExpression<SimpleConsole.Data.AccessAuditResult> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(AccessResult));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            return set;
        }
		
        protected override InsertExpressionSet<AccessAuditLog> GetInclusiveInsertExpression(AccessAuditLog entity)
        {
            return new InsertExpressionSet<AccessAuditLog>(entity 
                ,new InsertExpression<int>(entity.PersonId, PersonId)
                ,new InsertExpression<SimpleConsole.Data.AccessAuditResult>(entity.AccessResult, AccessResult)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(AccessAuditLog target, AccessAuditLog source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.PersonId != source.PersonId) { expr &= PersonId.Set(source.PersonId); }
            if (target.AccessResult != source.AccessResult) { expr &= AccessResult.Set(source.AccessResult); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, AccessAuditLog entity)
        {
            entity.Id = reader.ReadField().GetValue<int>();
            entity.PersonId = reader.ReadField().GetValue<int>();
            entity.AccessResult = reader.ReadField().GetValue<SimpleConsole.Data.AccessAuditResult>();
            entity.DateCreated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<AccessAuditLog>
        {
            #region constructors
            public IdField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region person id field expression
        public partial class PersonIdField : Int32FieldExpression<AccessAuditLog>
        {
            #region constructors
            public PersonIdField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region access result field expression
        public partial class AccessResultField : EnumFieldExpression<AccessAuditLog,SimpleConsole.Data.AccessAuditResult>
        {
            #region constructors
            public AccessResultField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<SimpleConsole.Data.AccessAuditResult>(value));
            public AssignmentExpression Set(SimpleConsole.Data.AccessAuditResult value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.AccessAuditResult>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.AccessAuditResult> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<AccessAuditLog>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime>(value));
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region address entity expression
    public partial class AddressEntity : EntityExpression<Address>
    {
        #region internals
        private SelectExpressionSet _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.IdField"/> representing the "dbo.Address.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.AddressEntity.IdField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>identity</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;


        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.AddressTypeField"/> representing the "dbo.Address.AddressType" column in the database, 
        /// with a .NET type of <see cref="SimpleConsole.Data.AddressType"/>?.  The <see cref="SimpleConsole.dboDataService.AddressEntity.AddressTypeField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{SimpleConsole.Data.AddressType}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>AddressType</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly AddressTypeField AddressType;


        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.Line1Field"/> representing the "dbo.Address.Line1" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="SimpleConsole.dboDataService.AddressEntity.Line1Field"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Line1</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(50)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly Line1Field Line1;


        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.Line2Field"/> representing the "dbo.Address.Line2" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="SimpleConsole.dboDataService.AddressEntity.Line2Field"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Line2</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(50)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly Line2Field Line2;


        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.CityField"/> representing the "dbo.Address.City" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="SimpleConsole.dboDataService.AddressEntity.CityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>City</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(60)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly CityField City;


        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.StateField"/> representing the "dbo.Address.State" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="SimpleConsole.dboDataService.AddressEntity.StateField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>State</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>char(2)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly StateField State;


        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.ZipField"/> representing the "dbo.Address.Zip" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="SimpleConsole.dboDataService.AddressEntity.ZipField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Zip</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(10)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ZipField Zip;


        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.DateCreatedField"/> representing the "dbo.Address.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="SimpleConsole.dboDataService.AddressEntity.DateCreatedField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateCreated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateCreatedField DateCreated;


        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity.DateUpdatedField"/> representing the "dbo.Address.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="SimpleConsole.dboDataService.AddressEntity.DateUpdatedField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateUpdated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateUpdatedField DateUpdated;

        #endregion

        #region constructors
        public AddressEntity(string identifier, string name, Schema schema) : this(identifier, name, schema, null)
        {
        }

        private AddressEntity(string identifier, string name, Schema schema, string alias) : base(identifier, name, schema, alias)
        {
            Attributes.Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Attributes.Fields.Add($"{identifier}.AddressType", AddressType = new AddressTypeField($"{identifier}.AddressType", "AddressType", this));
            Attributes.Fields.Add($"{identifier}.Line1", Line1 = new Line1Field($"{identifier}.Line1", "Line1", this));
            Attributes.Fields.Add($"{identifier}.Line2", Line2 = new Line2Field($"{identifier}.Line2", "Line2", this));
            Attributes.Fields.Add($"{identifier}.City", City = new CityField($"{identifier}.City", "City", this));
            Attributes.Fields.Add($"{identifier}.State", State = new StateField($"{identifier}.State", "State", this));
            Attributes.Fields.Add($"{identifier}.Zip", Zip = new ZipField($"{identifier}.Zip", "Zip", this));
            Attributes.Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
            Attributes.Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", "DateUpdated", this));
        }
        #endregion

        #region methods
        public AddressEntity As(string alias)
            => new AddressEntity(this.Attributes.Identifier, this.Attributes.Name, this.Attributes.Schema, alias);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return _inclusiveSelectExpressionSet ?? (_inclusiveSelectExpressionSet = new SelectExpressionSet(
                new SelectExpression<int>(Id)
                ,new SelectExpression<SimpleConsole.Data.AddressType?>(AddressType)
                ,new SelectExpression<string>(Line1)
                ,new SelectExpression<string>(Line2)
                ,new SelectExpression<string>(City)
                ,new SelectExpression<string>(State)
                ,new SelectExpression<string>(Zip)
                ,new SelectExpression<DateTime>(DateCreated)
                ,new SelectExpression<DateTime>(DateUpdated)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet set = null;
            string aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(AddressType));
            set &= aliased != nameof(AddressType) ? new SelectExpression<SimpleConsole.Data.AddressType?>(AddressType, aliased) as SelectExpression<SimpleConsole.Data.AddressType?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(AddressType));

            aliased = alias(nameof(Line1));
            set &= aliased != nameof(Line1) ? new SelectExpression<string>(Line1, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Line1));

            aliased = alias(nameof(Line2));
            set &= aliased != nameof(Line2) ? new SelectExpression<string>(Line2, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Line2));

            aliased = alias(nameof(City));
            set &= aliased != nameof(City) ? new SelectExpression<string>(City, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(City));

            aliased = alias(nameof(State));
            set &= aliased != nameof(State) ? new SelectExpression<string>(State, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(State));

            aliased = alias(nameof(Zip));
            set &= aliased != nameof(Zip) ? new SelectExpression<string>(Zip, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Zip));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<Address> GetInclusiveInsertExpression(Address entity)
        {
            return new InsertExpressionSet<Address>(entity 
                ,new InsertExpression<SimpleConsole.Data.AddressType?>(entity.AddressType, AddressType)
                ,new InsertExpression<string>(entity.Line1, Line1)
                ,new InsertExpression<string>(entity.Line2, Line2)
                ,new InsertExpression<string>(entity.City, City)
                ,new InsertExpression<string>(entity.State, State)
                ,new InsertExpression<string>(entity.Zip, Zip)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Address target, Address source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.AddressType != source.AddressType) { expr &= AddressType.Set(source.AddressType); }
            if (target.Line1 != source.Line1) { expr &= Line1.Set(source.Line1); }
            if (target.Line2 != source.Line2) { expr &= Line2.Set(source.Line2); }
            if (target.City != source.City) { expr &= City.Set(source.City); }
            if (target.State != source.State) { expr &= State.Set(source.State); }
            if (target.Zip != source.Zip) { expr &= Zip.Set(source.Zip); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, Address entity)
        {
            entity.Id = reader.ReadField().GetValue<int>();
            entity.AddressType = reader.ReadField().GetValue<SimpleConsole.Data.AddressType?>();
            entity.Line1 = reader.ReadField().GetValue<string>();
            entity.Line2 = reader.ReadField().GetValue<string>();
            entity.City = reader.ReadField().GetValue<string>();
            entity.State = reader.ReadField().GetValue<string>();
            entity.Zip = reader.ReadField().GetValue<string>();
            entity.DateCreated = reader.ReadField().GetValue<DateTime>();
            entity.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<Address>
        {
            #region constructors
            public IdField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region address type field expression
        public partial class AddressTypeField : NullableEnumFieldExpression<Address,SimpleConsole.Data.AddressType>
        {
            #region constructors
            public AddressTypeField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<SimpleConsole.Data.AddressType?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.AddressType?>(value, this));
            public AssignmentExpression Set(SimpleConsole.Data.AddressType value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.AddressType>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.AddressType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(SimpleConsole.Data.AddressType? value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.AddressType?>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.AddressType?> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region line1 field expression
        public partial class Line1Field : StringFieldExpression<Address>
        {
            #region constructors
            public Line1Field(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string>(value));
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region line2 field expression
        public partial class Line2Field : NullableStringFieldExpression<Address>
        {
            #region constructors
            public Line2Field(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region city field expression
        public partial class CityField : StringFieldExpression<Address>
        {
            #region constructors
            public CityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string>(value));
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region state field expression
        public partial class StateField : StringFieldExpression<Address>
        {
            #region constructors
            public StateField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string>(value));
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region zip field expression
        public partial class ZipField : StringFieldExpression<Address>
        {
            #region constructors
            public ZipField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string>(value));
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<Address>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime>(value));
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<Address>
        {
            #region constructors
            public DateUpdatedField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime>(value));
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region person entity expression
    public partial class PersonEntity : EntityExpression<Person>
    {
        #region internals
        private SelectExpressionSet _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.IdField"/> representing the "dbo.Person.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.PersonEntity.IdField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>identity</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.FirstNameField"/> representing the "dbo.Person.FirstName" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="SimpleConsole.dboDataService.PersonEntity.FirstNameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>FirstName</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(20)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly FirstNameField FirstName;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.LastNameField"/> representing the "dbo.Person.LastName" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="SimpleConsole.dboDataService.PersonEntity.LastNameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>LastName</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(20)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly LastNameField LastName;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.BirthDateField"/> representing the "dbo.Person.BirthDate" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>?.  The <see cref="SimpleConsole.dboDataService.PersonEntity.BirthDateField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>BirthDate</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>date</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly BirthDateField BirthDate;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.GenderTypeField"/> representing the "dbo.Person.GenderType" column in the database, 
        /// with a .NET type of <see cref="SimpleConsole.Data.GenderType"/>.  The <see cref="SimpleConsole.dboDataService.PersonEntity.GenderTypeField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{SimpleConsole.Data.GenderType}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>GenderType</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly GenderTypeField GenderType;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.CreditLimitField"/> representing the "dbo.Person.CreditLimit" column in the database, 
        /// with a .NET type of <see cref="int"/>?.  The <see cref="SimpleConsole.dboDataService.PersonEntity.CreditLimitField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>CreditLimit</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly CreditLimitField CreditLimit;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.YearOfLastCreditLimitReviewField"/> representing the "dbo.Person.YearOfLastCreditLimitReview" column in the database, 
        /// with a .NET type of <see cref="int"/>?.  The <see cref="SimpleConsole.dboDataService.PersonEntity.YearOfLastCreditLimitReviewField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>YearOfLastCreditLimitReview</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly YearOfLastCreditLimitReviewField YearOfLastCreditLimitReview;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.RegistrationDateField"/> representing the "dbo.Person.RegistrationDate" column in the database, 
        /// with a .NET type of <see cref="DateTimeOffset"/>.  The <see cref="SimpleConsole.dboDataService.PersonEntity.RegistrationDateField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTimeOffset}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>RegistrationDate</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetimeoffset</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(sysdatetimeoffset())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly RegistrationDateField RegistrationDate;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.LastLoginDateField"/> representing the "dbo.Person.LastLoginDate" column in the database, 
        /// with a .NET type of <see cref="DateTimeOffset"/>?.  The <see cref="SimpleConsole.dboDataService.PersonEntity.LastLoginDateField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTimeOffset}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>LastLoginDate</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetimeoffset</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly LastLoginDateField LastLoginDate;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.DateCreatedField"/> representing the "dbo.Person.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="SimpleConsole.dboDataService.PersonEntity.DateCreatedField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateCreated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateCreatedField DateCreated;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity.DateUpdatedField"/> representing the "dbo.Person.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="SimpleConsole.dboDataService.PersonEntity.DateUpdatedField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateUpdated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateUpdatedField DateUpdated;

        #endregion

        #region constructors
        public PersonEntity(string identifier, string name, Schema schema) : this(identifier, name, schema, null)
        {
        }

        private PersonEntity(string identifier, string name, Schema schema, string alias) : base(identifier, name, schema, alias)
        {
            Attributes.Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Attributes.Fields.Add($"{identifier}.FirstName", FirstName = new FirstNameField($"{identifier}.FirstName", "FirstName", this));
            Attributes.Fields.Add($"{identifier}.LastName", LastName = new LastNameField($"{identifier}.LastName", "LastName", this));
            Attributes.Fields.Add($"{identifier}.BirthDate", BirthDate = new BirthDateField($"{identifier}.BirthDate", "BirthDate", this));
            Attributes.Fields.Add($"{identifier}.GenderType", GenderType = new GenderTypeField($"{identifier}.GenderType", "GenderType", this));
            Attributes.Fields.Add($"{identifier}.CreditLimit", CreditLimit = new CreditLimitField($"{identifier}.CreditLimit", "CreditLimit", this));
            Attributes.Fields.Add($"{identifier}.YearOfLastCreditLimitReview", YearOfLastCreditLimitReview = new YearOfLastCreditLimitReviewField($"{identifier}.YearOfLastCreditLimitReview", "YearOfLastCreditLimitReview", this));
            Attributes.Fields.Add($"{identifier}.RegistrationDate", RegistrationDate = new RegistrationDateField($"{identifier}.RegistrationDate", "RegistrationDate", this));
            Attributes.Fields.Add($"{identifier}.LastLoginDate", LastLoginDate = new LastLoginDateField($"{identifier}.LastLoginDate", "LastLoginDate", this));
            Attributes.Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
            Attributes.Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", "DateUpdated", this));
        }
        #endregion

        #region methods
        public PersonEntity As(string alias)
            => new PersonEntity(this.Attributes.Identifier, this.Attributes.Name, this.Attributes.Schema, alias);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return _inclusiveSelectExpressionSet ?? (_inclusiveSelectExpressionSet = new SelectExpressionSet(
                new SelectExpression<int>(Id)
                ,new SelectExpression<string>(FirstName)
                ,new SelectExpression<string>(LastName)
                ,new SelectExpression<DateTime?>(BirthDate)
                ,new SelectExpression<SimpleConsole.Data.GenderType>(GenderType)
                ,new SelectExpression<int?>(CreditLimit)
                ,new SelectExpression<int?>(YearOfLastCreditLimitReview)
                ,new SelectExpression<DateTimeOffset>(RegistrationDate)
                ,new SelectExpression<DateTimeOffset?>(LastLoginDate)
                ,new SelectExpression<DateTime>(DateCreated)
                ,new SelectExpression<DateTime>(DateUpdated)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet set = null;
            string aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(FirstName));
            set &= aliased != nameof(FirstName) ? new SelectExpression<string>(FirstName, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(FirstName));

            aliased = alias(nameof(LastName));
            set &= aliased != nameof(LastName) ? new SelectExpression<string>(LastName, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(LastName));

            aliased = alias(nameof(BirthDate));
            set &= aliased != nameof(BirthDate) ? new SelectExpression<DateTime?>(BirthDate, aliased) as SelectExpression<DateTime?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(BirthDate));

            aliased = alias(nameof(GenderType));
            set &= aliased != nameof(GenderType) ? new SelectExpression<SimpleConsole.Data.GenderType>(GenderType, aliased) as SelectExpression<SimpleConsole.Data.GenderType> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(GenderType));

            aliased = alias(nameof(CreditLimit));
            set &= aliased != nameof(CreditLimit) ? new SelectExpression<int?>(CreditLimit, aliased) as SelectExpression<int?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(CreditLimit));

            aliased = alias(nameof(YearOfLastCreditLimitReview));
            set &= aliased != nameof(YearOfLastCreditLimitReview) ? new SelectExpression<int?>(YearOfLastCreditLimitReview, aliased) as SelectExpression<int?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(YearOfLastCreditLimitReview));

            aliased = alias(nameof(RegistrationDate));
            set &= aliased != nameof(RegistrationDate) ? new SelectExpression<DateTimeOffset>(RegistrationDate, aliased) as SelectExpression<DateTimeOffset> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(RegistrationDate));

            aliased = alias(nameof(LastLoginDate));
            set &= aliased != nameof(LastLoginDate) ? new SelectExpression<DateTimeOffset?>(LastLoginDate, aliased) as SelectExpression<DateTimeOffset?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(LastLoginDate));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<Person> GetInclusiveInsertExpression(Person entity)
        {
            return new InsertExpressionSet<Person>(entity 
                ,new InsertExpression<string>(entity.FirstName, FirstName)
                ,new InsertExpression<string>(entity.LastName, LastName)
                ,new InsertExpression<DateTime?>(entity.BirthDate, BirthDate)
                ,new InsertExpression<SimpleConsole.Data.GenderType>(entity.GenderType, GenderType)
                ,new InsertExpression<int?>(entity.CreditLimit, CreditLimit)
                ,new InsertExpression<int?>(entity.YearOfLastCreditLimitReview, YearOfLastCreditLimitReview)
                ,new InsertExpression<DateTimeOffset>(entity.RegistrationDate, RegistrationDate)
                ,new InsertExpression<DateTimeOffset?>(entity.LastLoginDate, LastLoginDate)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person target, Person source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.FirstName != source.FirstName) { expr &= FirstName.Set(source.FirstName); }
            if (target.LastName != source.LastName) { expr &= LastName.Set(source.LastName); }
            if (target.BirthDate != source.BirthDate) { expr &= BirthDate.Set(source.BirthDate); }
            if (target.GenderType != source.GenderType) { expr &= GenderType.Set(source.GenderType); }
            if (target.CreditLimit != source.CreditLimit) { expr &= CreditLimit.Set(source.CreditLimit); }
            if (target.YearOfLastCreditLimitReview != source.YearOfLastCreditLimitReview) { expr &= YearOfLastCreditLimitReview.Set(source.YearOfLastCreditLimitReview); }
            if (target.RegistrationDate != source.RegistrationDate) { expr &= RegistrationDate.Set(source.RegistrationDate); }
            if (target.LastLoginDate != source.LastLoginDate) { expr &= LastLoginDate.Set(source.LastLoginDate); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, Person entity)
        {
            entity.Id = reader.ReadField().GetValue<int>();
            entity.FirstName = reader.ReadField().GetValue<string>();
            entity.LastName = reader.ReadField().GetValue<string>();
            entity.BirthDate = reader.ReadField().GetValue<DateTime?>();
            entity.GenderType = reader.ReadField().GetValue<SimpleConsole.Data.GenderType>();
            entity.CreditLimit = reader.ReadField().GetValue<int?>();
            entity.YearOfLastCreditLimitReview = reader.ReadField().GetValue<int?>();
            entity.RegistrationDate = reader.ReadField().GetValue<DateTimeOffset>();
            entity.LastLoginDate = reader.ReadField().GetValue<DateTimeOffset?>();
            entity.DateCreated = reader.ReadField().GetValue<DateTime>();
            entity.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<Person>
        {
            #region constructors
            public IdField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region first name field expression
        public partial class FirstNameField : StringFieldExpression<Person>
        {
            #region constructors
            public FirstNameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string>(value));
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region last name field expression
        public partial class LastNameField : StringFieldExpression<Person>
        {
            #region constructors
            public LastNameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string>(value));
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region birth date field expression
        public partial class BirthDateField : NullableDateTimeFieldExpression<Person>
        {
            #region constructors
            public BirthDateField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<DateTime?>(value, this));
            public AssignmentExpression Set(DateTime? value) => new AssignmentExpression(this, new LiteralExpression<DateTime?>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region gender type field expression
        public partial class GenderTypeField : EnumFieldExpression<Person,SimpleConsole.Data.GenderType>
        {
            #region constructors
            public GenderTypeField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<SimpleConsole.Data.GenderType>(value));
            public AssignmentExpression Set(SimpleConsole.Data.GenderType value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.GenderType>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.GenderType> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region credit limit field expression
        public partial class CreditLimitField : NullableInt32FieldExpression<Person>
        {
            #region constructors
            public CreditLimitField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<int?>(value, this));
            public AssignmentExpression Set(int? value) => new AssignmentExpression(this, new LiteralExpression<int?>(value, this));
            public AssignmentExpression Set(AnyElement<int?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region year of last credit limit review field expression
        public partial class YearOfLastCreditLimitReviewField : NullableInt32FieldExpression<Person>
        {
            #region constructors
            public YearOfLastCreditLimitReviewField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<int?>(value, this));
            public AssignmentExpression Set(int? value) => new AssignmentExpression(this, new LiteralExpression<int?>(value, this));
            public AssignmentExpression Set(AnyElement<int?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region registration date field expression
        public partial class RegistrationDateField : DateTimeOffsetFieldExpression<Person>
        {
            #region constructors
            public RegistrationDateField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTimeOffset>(value));
            public AssignmentExpression Set(DateTimeOffset value) => new AssignmentExpression(this, new LiteralExpression<DateTimeOffset>(value, this));
            public AssignmentExpression Set(AnyElement<DateTimeOffset> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region last login date field expression
        public partial class LastLoginDateField : NullableDateTimeOffsetFieldExpression<Person>
        {
            #region constructors
            public LastLoginDateField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTimeOffset?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<DateTimeOffset?>(value, this));
            public AssignmentExpression Set(DateTimeOffset? value) => new AssignmentExpression(this, new LiteralExpression<DateTimeOffset?>(value, this));
            public AssignmentExpression Set(AnyElement<DateTimeOffset?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DateTimeOffset value) => new AssignmentExpression(this, new LiteralExpression<DateTimeOffset>(value, this));
            public AssignmentExpression Set(AnyElement<DateTimeOffset> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<Person>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime>(value));
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<Person>
        {
            #region constructors
            public DateUpdatedField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime>(value));
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region person address entity expression
    public partial class PersonAddressEntity : EntityExpression<PersonAddress>
    {
        #region internals
        private SelectExpressionSet _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonAddressEntity.IdField"/> representing the "dbo.Person_Address.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.PersonAddressEntity.IdField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>identity</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonAddressEntity.PersonIdField"/> representing the "dbo.Person_Address.PersonId" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.PersonAddressEntity.PersonIdField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PersonId</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PersonIdField PersonId;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonAddressEntity.AddressIdField"/> representing the "dbo.Person_Address.AddressId" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.PersonAddressEntity.AddressIdField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>AddressId</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly AddressIdField AddressId;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonAddressEntity.DateCreatedField"/> representing the "dbo.Person_Address.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="SimpleConsole.dboDataService.PersonAddressEntity.DateCreatedField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateCreated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateCreatedField DateCreated;

        #endregion

        #region constructors
        public PersonAddressEntity(string identifier, string name, Schema schema) : this(identifier, name, schema, null)
        {
        }

        private PersonAddressEntity(string identifier, string name, Schema schema, string alias) : base(identifier, name, schema, alias)
        {
            Attributes.Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Attributes.Fields.Add($"{identifier}.PersonId", PersonId = new PersonIdField($"{identifier}.PersonId", "PersonId", this));
            Attributes.Fields.Add($"{identifier}.AddressId", AddressId = new AddressIdField($"{identifier}.AddressId", "AddressId", this));
            Attributes.Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
        }
        #endregion

        #region methods
        public PersonAddressEntity As(string alias)
            => new PersonAddressEntity(this.Attributes.Identifier, this.Attributes.Name, this.Attributes.Schema, alias);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return _inclusiveSelectExpressionSet ?? (_inclusiveSelectExpressionSet = new SelectExpressionSet(
                new SelectExpression<int>(Id)
                ,new SelectExpression<int>(PersonId)
                ,new SelectExpression<int>(AddressId)
                ,new SelectExpression<DateTime>(DateCreated)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet set = null;
            string aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(PersonId));
            set &= aliased != nameof(PersonId) ? new SelectExpression<int>(PersonId, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PersonId));

            aliased = alias(nameof(AddressId));
            set &= aliased != nameof(AddressId) ? new SelectExpression<int>(AddressId, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(AddressId));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            return set;
        }
		
        protected override InsertExpressionSet<PersonAddress> GetInclusiveInsertExpression(PersonAddress entity)
        {
            return new InsertExpressionSet<PersonAddress>(entity 
                ,new InsertExpression<int>(entity.PersonId, PersonId)
                ,new InsertExpression<int>(entity.AddressId, AddressId)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PersonAddress target, PersonAddress source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.PersonId != source.PersonId) { expr &= PersonId.Set(source.PersonId); }
            if (target.AddressId != source.AddressId) { expr &= AddressId.Set(source.AddressId); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, PersonAddress entity)
        {
            entity.Id = reader.ReadField().GetValue<int>();
            entity.PersonId = reader.ReadField().GetValue<int>();
            entity.AddressId = reader.ReadField().GetValue<int>();
            entity.DateCreated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<PersonAddress>
        {
            #region constructors
            public IdField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region person id field expression
        public partial class PersonIdField : Int32FieldExpression<PersonAddress>
        {
            #region constructors
            public PersonIdField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region address id field expression
        public partial class AddressIdField : Int32FieldExpression<PersonAddress>
        {
            #region constructors
            public AddressIdField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<PersonAddress>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime>(value));
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region product entity expression
    public partial class ProductEntity : EntityExpression<Product>
    {
        #region internals
        private SelectExpressionSet _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.IdField"/> representing the "dbo.Product.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.ProductEntity.IdField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>identity</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.ProductCategoryTypeField"/> representing the "dbo.Product.ProductCategoryType" column in the database, 
        /// with a .NET type of <see cref="SimpleConsole.Data.ProductCategoryType"/>?.  The <see cref="SimpleConsole.dboDataService.ProductEntity.ProductCategoryTypeField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{SimpleConsole.Data.ProductCategoryType}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ProductCategoryType</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ProductCategoryTypeField ProductCategoryType;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.NameField"/> representing the "dbo.Product.Name" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="SimpleConsole.dboDataService.ProductEntity.NameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Name</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(80)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly NameField Name;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.DescriptionField"/> representing the "dbo.Product.Description" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="SimpleConsole.dboDataService.ProductEntity.DescriptionField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Description</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>nvarchar(2000)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DescriptionField Description;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.ListPriceField"/> representing the "dbo.Product.ListPrice" column in the database, 
        /// with a .NET type of <see cref="double"/>.  The <see cref="SimpleConsole.dboDataService.ProductEntity.ListPriceField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Double}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ListPrice</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>money</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ListPriceField ListPrice;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.PriceField"/> representing the "dbo.Product.Price" column in the database, 
        /// with a .NET type of <see cref="double"/>.  The <see cref="SimpleConsole.dboDataService.ProductEntity.PriceField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Double}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Price</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>money</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PriceField Price;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.QuantityField"/> representing the "dbo.Product.Quantity" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.ProductEntity.QuantityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Quantity</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly QuantityField Quantity;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.ImageField"/> representing the "dbo.Product.Image" column in the database, 
        /// with a .NET type of <see cref="byte"/>[].  The <see cref="SimpleConsole.dboDataService.ProductEntity.ImageField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Byte[]}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Image</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varbinary(MAX)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ImageField Image;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.HeightField"/> representing the "dbo.Product.Height" column in the database, 
        /// with a .NET type of <see cref="decimal"/>?.  The <see cref="SimpleConsole.dboDataService.ProductEntity.HeightField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Decimal}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Height</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>decimal(4,1)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly HeightField Height;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.WidthField"/> representing the "dbo.Product.Width" column in the database, 
        /// with a .NET type of <see cref="decimal"/>?.  The <see cref="SimpleConsole.dboDataService.ProductEntity.WidthField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Decimal}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Width</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>decimal(4,1)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly WidthField Width;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.DepthField"/> representing the "dbo.Product.Depth" column in the database, 
        /// with a .NET type of <see cref="decimal"/>?.  The <see cref="SimpleConsole.dboDataService.ProductEntity.DepthField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Decimal}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Depth</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>decimal(4,1)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DepthField Depth;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.WeightField"/> representing the "dbo.Product.Weight" column in the database, 
        /// with a .NET type of <see cref="decimal"/>?.  The <see cref="SimpleConsole.dboDataService.ProductEntity.WeightField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Decimal}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Weight</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>decimal(4,1)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly WeightField Weight;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.ShippingWeightField"/> representing the "dbo.Product.ShippingWeight" column in the database, 
        /// with a .NET type of <see cref="decimal"/>.  The <see cref="SimpleConsole.dboDataService.ProductEntity.ShippingWeightField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Decimal}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ShippingWeight</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>decimal(4,1)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ShippingWeightField ShippingWeight;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.ValidStartTimeOfDayForPurchaseField"/> representing the "dbo.Product.ValidStartTimeOfDayForPurchase" column in the database, 
        /// with a .NET type of <see cref="TimeSpan"/>?.  The <see cref="SimpleConsole.dboDataService.ProductEntity.ValidStartTimeOfDayForPurchaseField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{TimeSpan}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ValidStartTimeOfDayForPurchase</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>time</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ValidStartTimeOfDayForPurchaseField ValidStartTimeOfDayForPurchase;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.ValidEndTimeOfDayForPurchaseField"/> representing the "dbo.Product.ValidEndTimeOfDayForPurchase" column in the database, 
        /// with a .NET type of <see cref="TimeSpan"/>?.  The <see cref="SimpleConsole.dboDataService.ProductEntity.ValidEndTimeOfDayForPurchaseField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{TimeSpan}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ValidEndTimeOfDayForPurchase</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>time</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ValidEndTimeOfDayForPurchaseField ValidEndTimeOfDayForPurchase;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.DateCreatedField"/> representing the "dbo.Product.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="SimpleConsole.dboDataService.ProductEntity.DateCreatedField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateCreated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateCreatedField DateCreated;


        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity.DateUpdatedField"/> representing the "dbo.Product.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="SimpleConsole.dboDataService.ProductEntity.DateUpdatedField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateUpdated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateUpdatedField DateUpdated;

        #endregion

        #region constructors
        public ProductEntity(string identifier, string name, Schema schema) : this(identifier, name, schema, null)
        {
        }

        private ProductEntity(string identifier, string name, Schema schema, string alias) : base(identifier, name, schema, alias)
        {
            Attributes.Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Attributes.Fields.Add($"{identifier}.ProductCategoryType", ProductCategoryType = new ProductCategoryTypeField($"{identifier}.ProductCategoryType", "ProductCategoryType", this));
            Attributes.Fields.Add($"{identifier}.Name", Name = new NameField($"{identifier}.Name", "Name", this));
            Attributes.Fields.Add($"{identifier}.Description", Description = new DescriptionField($"{identifier}.Description", "Description", this));
            Attributes.Fields.Add($"{identifier}.ListPrice", ListPrice = new ListPriceField($"{identifier}.ListPrice", "ListPrice", this));
            Attributes.Fields.Add($"{identifier}.Price", Price = new PriceField($"{identifier}.Price", "Price", this));
            Attributes.Fields.Add($"{identifier}.Quantity", Quantity = new QuantityField($"{identifier}.Quantity", "Quantity", this));
            Attributes.Fields.Add($"{identifier}.Image", Image = new ImageField($"{identifier}.Image", "Image", this));
            Attributes.Fields.Add($"{identifier}.Height", Height = new HeightField($"{identifier}.Height", "Height", this));
            Attributes.Fields.Add($"{identifier}.Width", Width = new WidthField($"{identifier}.Width", "Width", this));
            Attributes.Fields.Add($"{identifier}.Depth", Depth = new DepthField($"{identifier}.Depth", "Depth", this));
            Attributes.Fields.Add($"{identifier}.Weight", Weight = new WeightField($"{identifier}.Weight", "Weight", this));
            Attributes.Fields.Add($"{identifier}.ShippingWeight", ShippingWeight = new ShippingWeightField($"{identifier}.ShippingWeight", "ShippingWeight", this));
            Attributes.Fields.Add($"{identifier}.ValidStartTimeOfDayForPurchase", ValidStartTimeOfDayForPurchase = new ValidStartTimeOfDayForPurchaseField($"{identifier}.ValidStartTimeOfDayForPurchase", "ValidStartTimeOfDayForPurchase", this));
            Attributes.Fields.Add($"{identifier}.ValidEndTimeOfDayForPurchase", ValidEndTimeOfDayForPurchase = new ValidEndTimeOfDayForPurchaseField($"{identifier}.ValidEndTimeOfDayForPurchase", "ValidEndTimeOfDayForPurchase", this));
            Attributes.Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
            Attributes.Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", "DateUpdated", this));
        }
        #endregion

        #region methods
        public ProductEntity As(string alias)
            => new ProductEntity(this.Attributes.Identifier, this.Attributes.Name, this.Attributes.Schema, alias);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return _inclusiveSelectExpressionSet ?? (_inclusiveSelectExpressionSet = new SelectExpressionSet(
                new SelectExpression<int>(Id)
                ,new SelectExpression<SimpleConsole.Data.ProductCategoryType?>(ProductCategoryType)
                ,new SelectExpression<string>(Name)
                ,new SelectExpression<string>(Description)
                ,new SelectExpression<double>(ListPrice)
                ,new SelectExpression<double>(Price)
                ,new SelectExpression<int>(Quantity)
                ,new SelectExpression<byte[]>(Image)
                ,new SelectExpression<decimal?>(Height)
                ,new SelectExpression<decimal?>(Width)
                ,new SelectExpression<decimal?>(Depth)
                ,new SelectExpression<decimal?>(Weight)
                ,new SelectExpression<decimal>(ShippingWeight)
                ,new SelectExpression<TimeSpan?>(ValidStartTimeOfDayForPurchase)
                ,new SelectExpression<TimeSpan?>(ValidEndTimeOfDayForPurchase)
                ,new SelectExpression<DateTime>(DateCreated)
                ,new SelectExpression<DateTime>(DateUpdated)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet set = null;
            string aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(ProductCategoryType));
            set &= aliased != nameof(ProductCategoryType) ? new SelectExpression<SimpleConsole.Data.ProductCategoryType?>(ProductCategoryType, aliased) as SelectExpression<SimpleConsole.Data.ProductCategoryType?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ProductCategoryType));

            aliased = alias(nameof(Name));
            set &= aliased != nameof(Name) ? new SelectExpression<string>(Name, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Name));

            aliased = alias(nameof(Description));
            set &= aliased != nameof(Description) ? new SelectExpression<string>(Description, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Description));

            aliased = alias(nameof(ListPrice));
            set &= aliased != nameof(ListPrice) ? new SelectExpression<double>(ListPrice, aliased) as SelectExpression<double> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ListPrice));

            aliased = alias(nameof(Price));
            set &= aliased != nameof(Price) ? new SelectExpression<double>(Price, aliased) as SelectExpression<double> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Price));

            aliased = alias(nameof(Quantity));
            set &= aliased != nameof(Quantity) ? new SelectExpression<int>(Quantity, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Quantity));

            aliased = alias(nameof(Image));
            set &= aliased != nameof(Image) ? new SelectExpression<byte[]>(Image, aliased) as SelectExpression<byte[]> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Image));

            aliased = alias(nameof(Height));
            set &= aliased != nameof(Height) ? new SelectExpression<decimal?>(Height, aliased) as SelectExpression<decimal?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Height));

            aliased = alias(nameof(Width));
            set &= aliased != nameof(Width) ? new SelectExpression<decimal?>(Width, aliased) as SelectExpression<decimal?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Width));

            aliased = alias(nameof(Depth));
            set &= aliased != nameof(Depth) ? new SelectExpression<decimal?>(Depth, aliased) as SelectExpression<decimal?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Depth));

            aliased = alias(nameof(Weight));
            set &= aliased != nameof(Weight) ? new SelectExpression<decimal?>(Weight, aliased) as SelectExpression<decimal?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Weight));

            aliased = alias(nameof(ShippingWeight));
            set &= aliased != nameof(ShippingWeight) ? new SelectExpression<decimal>(ShippingWeight, aliased) as SelectExpression<decimal> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ShippingWeight));

            aliased = alias(nameof(ValidStartTimeOfDayForPurchase));
            set &= aliased != nameof(ValidStartTimeOfDayForPurchase) ? new SelectExpression<TimeSpan?>(ValidStartTimeOfDayForPurchase, aliased) as SelectExpression<TimeSpan?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ValidStartTimeOfDayForPurchase));

            aliased = alias(nameof(ValidEndTimeOfDayForPurchase));
            set &= aliased != nameof(ValidEndTimeOfDayForPurchase) ? new SelectExpression<TimeSpan?>(ValidEndTimeOfDayForPurchase, aliased) as SelectExpression<TimeSpan?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ValidEndTimeOfDayForPurchase));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<Product> GetInclusiveInsertExpression(Product entity)
        {
            return new InsertExpressionSet<Product>(entity 
                ,new InsertExpression<SimpleConsole.Data.ProductCategoryType?>(entity.ProductCategoryType, ProductCategoryType)
                ,new InsertExpression<string>(entity.Name, Name)
                ,new InsertExpression<string>(entity.Description, Description)
                ,new InsertExpression<double>(entity.ListPrice, ListPrice)
                ,new InsertExpression<double>(entity.Price, Price)
                ,new InsertExpression<int>(entity.Quantity, Quantity)
                ,new InsertExpression<byte[]>(entity.Image, Image)
                ,new InsertExpression<decimal?>(entity.Height, Height)
                ,new InsertExpression<decimal?>(entity.Width, Width)
                ,new InsertExpression<decimal?>(entity.Depth, Depth)
                ,new InsertExpression<decimal?>(entity.Weight, Weight)
                ,new InsertExpression<decimal>(entity.ShippingWeight, ShippingWeight)
                ,new InsertExpression<TimeSpan?>(entity.ValidStartTimeOfDayForPurchase, ValidStartTimeOfDayForPurchase)
                ,new InsertExpression<TimeSpan?>(entity.ValidEndTimeOfDayForPurchase, ValidEndTimeOfDayForPurchase)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Product target, Product source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.ProductCategoryType != source.ProductCategoryType) { expr &= ProductCategoryType.Set(source.ProductCategoryType); }
            if (target.Name != source.Name) { expr &= Name.Set(source.Name); }
            if (target.Description != source.Description) { expr &= Description.Set(source.Description); }
            if (target.ListPrice != source.ListPrice) { expr &= ListPrice.Set(source.ListPrice); }
            if (target.Price != source.Price) { expr &= Price.Set(source.Price); }
            if (target.Quantity != source.Quantity) { expr &= Quantity.Set(source.Quantity); }
            if (target.Image != source.Image) { expr &= Image.Set(source.Image); }
            if (target.Height != source.Height) { expr &= Height.Set(source.Height); }
            if (target.Width != source.Width) { expr &= Width.Set(source.Width); }
            if (target.Depth != source.Depth) { expr &= Depth.Set(source.Depth); }
            if (target.Weight != source.Weight) { expr &= Weight.Set(source.Weight); }
            if (target.ShippingWeight != source.ShippingWeight) { expr &= ShippingWeight.Set(source.ShippingWeight); }
            if (target.ValidStartTimeOfDayForPurchase != source.ValidStartTimeOfDayForPurchase) { expr &= ValidStartTimeOfDayForPurchase.Set(source.ValidStartTimeOfDayForPurchase); }
            if (target.ValidEndTimeOfDayForPurchase != source.ValidEndTimeOfDayForPurchase) { expr &= ValidEndTimeOfDayForPurchase.Set(source.ValidEndTimeOfDayForPurchase); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, Product entity)
        {
            entity.Id = reader.ReadField().GetValue<int>();
            entity.ProductCategoryType = reader.ReadField().GetValue<SimpleConsole.Data.ProductCategoryType?>();
            entity.Name = reader.ReadField().GetValue<string>();
            entity.Description = reader.ReadField().GetValue<string>();
            entity.ListPrice = reader.ReadField().GetValue<double>();
            entity.Price = reader.ReadField().GetValue<double>();
            entity.Quantity = reader.ReadField().GetValue<int>();
            entity.Image = reader.ReadField().GetValue<byte[]>();
            entity.Height = reader.ReadField().GetValue<decimal?>();
            entity.Width = reader.ReadField().GetValue<decimal?>();
            entity.Depth = reader.ReadField().GetValue<decimal?>();
            entity.Weight = reader.ReadField().GetValue<decimal?>();
            entity.ShippingWeight = reader.ReadField().GetValue<decimal>();
            entity.ValidStartTimeOfDayForPurchase = reader.ReadField().GetValue<TimeSpan?>();
            entity.ValidEndTimeOfDayForPurchase = reader.ReadField().GetValue<TimeSpan?>();
            entity.DateCreated = reader.ReadField().GetValue<DateTime>();
            entity.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<Product>
        {
            #region constructors
            public IdField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region product category type field expression
        public partial class ProductCategoryTypeField : NullableEnumFieldExpression<Product,SimpleConsole.Data.ProductCategoryType>
        {
            #region constructors
            public ProductCategoryTypeField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<SimpleConsole.Data.ProductCategoryType?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.ProductCategoryType?>(value, this));
            public AssignmentExpression Set(SimpleConsole.Data.ProductCategoryType value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.ProductCategoryType>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.ProductCategoryType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(SimpleConsole.Data.ProductCategoryType? value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.ProductCategoryType?>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.ProductCategoryType?> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region name field expression
        public partial class NameField : StringFieldExpression<Product>
        {
            #region constructors
            public NameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string>(value));
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region description field expression
        public partial class DescriptionField : NullableStringFieldExpression<Product>
        {
            #region constructors
            public DescriptionField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region list price field expression
        public partial class ListPriceField : DoubleFieldExpression<Product>
        {
            #region constructors
            public ListPriceField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<double>(value));
            public AssignmentExpression Set(double value) => new AssignmentExpression(this, new LiteralExpression<double>(value, this));
            public AssignmentExpression Set(AnyElement<double> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region price field expression
        public partial class PriceField : DoubleFieldExpression<Product>
        {
            #region constructors
            public PriceField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<double>(value));
            public AssignmentExpression Set(double value) => new AssignmentExpression(this, new LiteralExpression<double>(value, this));
            public AssignmentExpression Set(AnyElement<double> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region quantity field expression
        public partial class QuantityField : Int32FieldExpression<Product>
        {
            #region constructors
            public QuantityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region image field expression
        public partial class ImageField : NullableByteArrayFieldExpression<Product>
        {
            #region constructors
            public ImageField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<byte[]>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<byte[]>(value, this));
            public AssignmentExpression Set(byte[] value) => new AssignmentExpression(this, new LiteralExpression<byte[]>(value, this));
            public AssignmentExpression Set(AnyElement<byte[]> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region height field expression
        public partial class HeightField : NullableDecimalFieldExpression<Product>
        {
            #region constructors
            public HeightField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<decimal?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value, this));
            public AssignmentExpression Set(decimal? value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value, this));
            public AssignmentExpression Set(AnyElement<decimal?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            public AssignmentExpression Set(AnyElement<decimal> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region width field expression
        public partial class WidthField : NullableDecimalFieldExpression<Product>
        {
            #region constructors
            public WidthField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<decimal?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value, this));
            public AssignmentExpression Set(decimal? value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value, this));
            public AssignmentExpression Set(AnyElement<decimal?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            public AssignmentExpression Set(AnyElement<decimal> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region depth field expression
        public partial class DepthField : NullableDecimalFieldExpression<Product>
        {
            #region constructors
            public DepthField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<decimal?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value, this));
            public AssignmentExpression Set(decimal? value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value, this));
            public AssignmentExpression Set(AnyElement<decimal?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            public AssignmentExpression Set(AnyElement<decimal> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region weight field expression
        public partial class WeightField : NullableDecimalFieldExpression<Product>
        {
            #region constructors
            public WeightField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<decimal?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value, this));
            public AssignmentExpression Set(decimal? value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value, this));
            public AssignmentExpression Set(AnyElement<decimal?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            public AssignmentExpression Set(AnyElement<decimal> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region shipping weight field expression
        public partial class ShippingWeightField : DecimalFieldExpression<Product>
        {
            #region constructors
            public ShippingWeightField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<decimal>(value));
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            public AssignmentExpression Set(AnyElement<decimal> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region valid start time of day for purchase field expression
        public partial class ValidStartTimeOfDayForPurchaseField : NullableTimeSpanFieldExpression<Product>
        {
            #region constructors
            public ValidStartTimeOfDayForPurchaseField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<TimeSpan?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan?>(value, this));
            public AssignmentExpression Set(TimeSpan? value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan?>(value, this));
            public AssignmentExpression Set(AnyElement<TimeSpan?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(TimeSpan value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan>(value, this));
            public AssignmentExpression Set(AnyElement<TimeSpan> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region valid end time of day for purchase field expression
        public partial class ValidEndTimeOfDayForPurchaseField : NullableTimeSpanFieldExpression<Product>
        {
            #region constructors
            public ValidEndTimeOfDayForPurchaseField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<TimeSpan?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan?>(value, this));
            public AssignmentExpression Set(TimeSpan? value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan?>(value, this));
            public AssignmentExpression Set(AnyElement<TimeSpan?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(TimeSpan value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan>(value, this));
            public AssignmentExpression Set(AnyElement<TimeSpan> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<Product>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime>(value));
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<Product>
        {
            #region constructors
            public DateUpdatedField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime>(value));
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region purchase entity expression
    public partial class PurchaseEntity : EntityExpression<Purchase>
    {
        #region internals
        private SelectExpressionSet _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.IdField"/> representing the "dbo.Purchase.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseEntity.IdField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>identity</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.PersonIdField"/> representing the "dbo.Purchase.PersonId" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseEntity.PersonIdField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PersonId</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PersonIdField PersonId;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.OrderNumberField"/> representing the "dbo.Purchase.OrderNumber" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseEntity.OrderNumberField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>OrderNumber</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(20)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly OrderNumberField OrderNumber;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.TotalPurchaseQuantityField"/> representing the "dbo.Purchase.TotalPurchaseQuantity" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseEntity.TotalPurchaseQuantityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>TotalPurchaseQuantity</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly TotalPurchaseQuantityField TotalPurchaseQuantity;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.TotalPurchaseAmountField"/> representing the "dbo.Purchase.TotalPurchaseAmount" column in the database, 
        /// with a .NET type of <see cref="double"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseEntity.TotalPurchaseAmountField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Double}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>TotalPurchaseAmount</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>money</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly TotalPurchaseAmountField TotalPurchaseAmount;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.PurchaseDateField"/> representing the "dbo.Purchase.PurchaseDate" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseEntity.PurchaseDateField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PurchaseDate</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PurchaseDateField PurchaseDate;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.ShipDateField"/> representing the "dbo.Purchase.ShipDate" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>?.  The <see cref="SimpleConsole.dboDataService.PurchaseEntity.ShipDateField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ShipDate</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ShipDateField ShipDate;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.ExpectedDeliveryDateField"/> representing the "dbo.Purchase.ExpectedDeliveryDate" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>?.  The <see cref="SimpleConsole.dboDataService.PurchaseEntity.ExpectedDeliveryDateField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ExpectedDeliveryDate</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ExpectedDeliveryDateField ExpectedDeliveryDate;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.TrackingIdentifierField"/> representing the "dbo.Purchase.TrackingIdentifier" column in the database, 
        /// with a .NET type of <see cref="Guid"/>?.  The <see cref="SimpleConsole.dboDataService.PurchaseEntity.TrackingIdentifierField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Guid}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>TrackingIdentifier</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>uniqueidentifier</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly TrackingIdentifierField TrackingIdentifier;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.PaymentMethodTypeField"/> representing the "dbo.Purchase.PaymentMethodType" column in the database, 
        /// with a .NET type of <see cref="SimpleConsole.Data.PaymentMethodType"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseEntity.PaymentMethodTypeField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{SimpleConsole.Data.PaymentMethodType}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PaymentMethodType</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(20)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PaymentMethodTypeField PaymentMethodType;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.PaymentSourceTypeField"/> representing the "dbo.Purchase.PaymentSourceType" column in the database, 
        /// with a .NET type of <see cref="SimpleConsole.Data.PaymentSourceType"/>?.  The <see cref="SimpleConsole.dboDataService.PurchaseEntity.PaymentSourceTypeField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{SimpleConsole.Data.PaymentSourceType}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PaymentSourceType</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varchar(20)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PaymentSourceTypeField PaymentSourceType;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.DateCreatedField"/> representing the "dbo.Purchase.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseEntity.DateCreatedField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateCreated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateCreatedField DateCreated;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity.DateUpdatedField"/> representing the "dbo.Purchase.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseEntity.DateUpdatedField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateUpdated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateUpdatedField DateUpdated;

        #endregion

        #region constructors
        public PurchaseEntity(string identifier, string name, Schema schema) : this(identifier, name, schema, null)
        {
        }

        private PurchaseEntity(string identifier, string name, Schema schema, string alias) : base(identifier, name, schema, alias)
        {
            Attributes.Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Attributes.Fields.Add($"{identifier}.PersonId", PersonId = new PersonIdField($"{identifier}.PersonId", "PersonId", this));
            Attributes.Fields.Add($"{identifier}.OrderNumber", OrderNumber = new OrderNumberField($"{identifier}.OrderNumber", "OrderNumber", this));
            Attributes.Fields.Add($"{identifier}.TotalPurchaseQuantity", TotalPurchaseQuantity = new TotalPurchaseQuantityField($"{identifier}.TotalPurchaseQuantity", "TotalPurchaseQuantity", this));
            Attributes.Fields.Add($"{identifier}.TotalPurchaseAmount", TotalPurchaseAmount = new TotalPurchaseAmountField($"{identifier}.TotalPurchaseAmount", "TotalPurchaseAmount", this));
            Attributes.Fields.Add($"{identifier}.PurchaseDate", PurchaseDate = new PurchaseDateField($"{identifier}.PurchaseDate", "PurchaseDate", this));
            Attributes.Fields.Add($"{identifier}.ShipDate", ShipDate = new ShipDateField($"{identifier}.ShipDate", "ShipDate", this));
            Attributes.Fields.Add($"{identifier}.ExpectedDeliveryDate", ExpectedDeliveryDate = new ExpectedDeliveryDateField($"{identifier}.ExpectedDeliveryDate", "ExpectedDeliveryDate", this));
            Attributes.Fields.Add($"{identifier}.TrackingIdentifier", TrackingIdentifier = new TrackingIdentifierField($"{identifier}.TrackingIdentifier", "TrackingIdentifier", this));
            Attributes.Fields.Add($"{identifier}.PaymentMethodType", PaymentMethodType = new PaymentMethodTypeField($"{identifier}.PaymentMethodType", "PaymentMethodType", this));
            Attributes.Fields.Add($"{identifier}.PaymentSourceType", PaymentSourceType = new PaymentSourceTypeField($"{identifier}.PaymentSourceType", "PaymentSourceType", this));
            Attributes.Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
            Attributes.Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", "DateUpdated", this));
        }
        #endregion

        #region methods
        public PurchaseEntity As(string alias)
            => new PurchaseEntity(this.Attributes.Identifier, this.Attributes.Name, this.Attributes.Schema, alias);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return _inclusiveSelectExpressionSet ?? (_inclusiveSelectExpressionSet = new SelectExpressionSet(
                new SelectExpression<int>(Id)
                ,new SelectExpression<int>(PersonId)
                ,new SelectExpression<string>(OrderNumber)
                ,new SelectExpression<int>(TotalPurchaseQuantity)
                ,new SelectExpression<double>(TotalPurchaseAmount)
                ,new SelectExpression<DateTime>(PurchaseDate)
                ,new SelectExpression<DateTime?>(ShipDate)
                ,new SelectExpression<DateTime?>(ExpectedDeliveryDate)
                ,new SelectExpression<Guid?>(TrackingIdentifier)
                ,new SelectExpression<SimpleConsole.Data.PaymentMethodType>(PaymentMethodType)
                ,new SelectExpression<SimpleConsole.Data.PaymentSourceType?>(PaymentSourceType)
                ,new SelectExpression<DateTime>(DateCreated)
                ,new SelectExpression<DateTime>(DateUpdated)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet set = null;
            string aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(PersonId));
            set &= aliased != nameof(PersonId) ? new SelectExpression<int>(PersonId, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PersonId));

            aliased = alias(nameof(OrderNumber));
            set &= aliased != nameof(OrderNumber) ? new SelectExpression<string>(OrderNumber, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(OrderNumber));

            aliased = alias(nameof(TotalPurchaseQuantity));
            set &= aliased != nameof(TotalPurchaseQuantity) ? new SelectExpression<int>(TotalPurchaseQuantity, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(TotalPurchaseQuantity));

            aliased = alias(nameof(TotalPurchaseAmount));
            set &= aliased != nameof(TotalPurchaseAmount) ? new SelectExpression<double>(TotalPurchaseAmount, aliased) as SelectExpression<double> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(TotalPurchaseAmount));

            aliased = alias(nameof(PurchaseDate));
            set &= aliased != nameof(PurchaseDate) ? new SelectExpression<DateTime>(PurchaseDate, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PurchaseDate));

            aliased = alias(nameof(ShipDate));
            set &= aliased != nameof(ShipDate) ? new SelectExpression<DateTime?>(ShipDate, aliased) as SelectExpression<DateTime?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ShipDate));

            aliased = alias(nameof(ExpectedDeliveryDate));
            set &= aliased != nameof(ExpectedDeliveryDate) ? new SelectExpression<DateTime?>(ExpectedDeliveryDate, aliased) as SelectExpression<DateTime?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ExpectedDeliveryDate));

            aliased = alias(nameof(TrackingIdentifier));
            set &= aliased != nameof(TrackingIdentifier) ? new SelectExpression<Guid?>(TrackingIdentifier, aliased) as SelectExpression<Guid?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(TrackingIdentifier));

            aliased = alias(nameof(PaymentMethodType));
            set &= aliased != nameof(PaymentMethodType) ? new SelectExpression<SimpleConsole.Data.PaymentMethodType>(PaymentMethodType, aliased) as SelectExpression<SimpleConsole.Data.PaymentMethodType> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PaymentMethodType));

            aliased = alias(nameof(PaymentSourceType));
            set &= aliased != nameof(PaymentSourceType) ? new SelectExpression<SimpleConsole.Data.PaymentSourceType?>(PaymentSourceType, aliased) as SelectExpression<SimpleConsole.Data.PaymentSourceType?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PaymentSourceType));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<Purchase> GetInclusiveInsertExpression(Purchase entity)
        {
            return new InsertExpressionSet<Purchase>(entity 
                ,new InsertExpression<int>(entity.PersonId, PersonId)
                ,new InsertExpression<string>(entity.OrderNumber, OrderNumber)
                ,new InsertExpression<int>(entity.TotalPurchaseQuantity, TotalPurchaseQuantity)
                ,new InsertExpression<double>(entity.TotalPurchaseAmount, TotalPurchaseAmount)
                ,new InsertExpression<DateTime>(entity.PurchaseDate, PurchaseDate)
                ,new InsertExpression<DateTime?>(entity.ShipDate, ShipDate)
                ,new InsertExpression<DateTime?>(entity.ExpectedDeliveryDate, ExpectedDeliveryDate)
                ,new InsertExpression<Guid?>(entity.TrackingIdentifier, TrackingIdentifier)
                ,new InsertExpression<SimpleConsole.Data.PaymentMethodType>(entity.PaymentMethodType, PaymentMethodType)
                ,new InsertExpression<SimpleConsole.Data.PaymentSourceType?>(entity.PaymentSourceType, PaymentSourceType)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Purchase target, Purchase source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.PersonId != source.PersonId) { expr &= PersonId.Set(source.PersonId); }
            if (target.OrderNumber != source.OrderNumber) { expr &= OrderNumber.Set(source.OrderNumber); }
            if (target.TotalPurchaseQuantity != source.TotalPurchaseQuantity) { expr &= TotalPurchaseQuantity.Set(source.TotalPurchaseQuantity); }
            if (target.TotalPurchaseAmount != source.TotalPurchaseAmount) { expr &= TotalPurchaseAmount.Set(source.TotalPurchaseAmount); }
            if (target.PurchaseDate != source.PurchaseDate) { expr &= PurchaseDate.Set(source.PurchaseDate); }
            if (target.ShipDate != source.ShipDate) { expr &= ShipDate.Set(source.ShipDate); }
            if (target.ExpectedDeliveryDate != source.ExpectedDeliveryDate) { expr &= ExpectedDeliveryDate.Set(source.ExpectedDeliveryDate); }
            if (target.TrackingIdentifier != source.TrackingIdentifier) { expr &= TrackingIdentifier.Set(source.TrackingIdentifier); }
            if (target.PaymentMethodType != source.PaymentMethodType) { expr &= PaymentMethodType.Set(source.PaymentMethodType); }
            if (target.PaymentSourceType != source.PaymentSourceType) { expr &= PaymentSourceType.Set(source.PaymentSourceType); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, Purchase entity)
        {
            entity.Id = reader.ReadField().GetValue<int>();
            entity.PersonId = reader.ReadField().GetValue<int>();
            entity.OrderNumber = reader.ReadField().GetValue<string>();
            entity.TotalPurchaseQuantity = reader.ReadField().GetValue<int>();
            entity.TotalPurchaseAmount = reader.ReadField().GetValue<double>();
            entity.PurchaseDate = reader.ReadField().GetValue<DateTime>();
            entity.ShipDate = reader.ReadField().GetValue<DateTime?>();
            entity.ExpectedDeliveryDate = reader.ReadField().GetValue<DateTime?>();
            entity.TrackingIdentifier = reader.ReadField().GetValue<Guid?>();
            entity.PaymentMethodType = reader.ReadField().GetValue<SimpleConsole.Data.PaymentMethodType>();
            entity.PaymentSourceType = reader.ReadField().GetValue<SimpleConsole.Data.PaymentSourceType?>();
            entity.DateCreated = reader.ReadField().GetValue<DateTime>();
            entity.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<Purchase>
        {
            #region constructors
            public IdField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region person id field expression
        public partial class PersonIdField : Int32FieldExpression<Purchase>
        {
            #region constructors
            public PersonIdField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region order number field expression
        public partial class OrderNumberField : StringFieldExpression<Purchase>
        {
            #region constructors
            public OrderNumberField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string>(value));
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region total purchase quantity field expression
        public partial class TotalPurchaseQuantityField : Int32FieldExpression<Purchase>
        {
            #region constructors
            public TotalPurchaseQuantityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region total purchase amount field expression
        public partial class TotalPurchaseAmountField : DoubleFieldExpression<Purchase>
        {
            #region constructors
            public TotalPurchaseAmountField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<double>(value));
            public AssignmentExpression Set(double value) => new AssignmentExpression(this, new LiteralExpression<double>(value, this));
            public AssignmentExpression Set(AnyElement<double> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region purchase date field expression
        public partial class PurchaseDateField : DateTimeFieldExpression<Purchase>
        {
            #region constructors
            public PurchaseDateField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime>(value));
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region ship date field expression
        public partial class ShipDateField : NullableDateTimeFieldExpression<Purchase>
        {
            #region constructors
            public ShipDateField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<DateTime?>(value, this));
            public AssignmentExpression Set(DateTime? value) => new AssignmentExpression(this, new LiteralExpression<DateTime?>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region expected delivery date field expression
        public partial class ExpectedDeliveryDateField : NullableDateTimeFieldExpression<Purchase>
        {
            #region constructors
            public ExpectedDeliveryDateField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<DateTime?>(value, this));
            public AssignmentExpression Set(DateTime? value) => new AssignmentExpression(this, new LiteralExpression<DateTime?>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region tracking identifier field expression
        public partial class TrackingIdentifierField : NullableGuidFieldExpression<Purchase>
        {
            #region constructors
            public TrackingIdentifierField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<Guid?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<Guid?>(value, this));
            public AssignmentExpression Set(Guid? value) => new AssignmentExpression(this, new LiteralExpression<Guid?>(value, this));
            public AssignmentExpression Set(AnyElement<Guid?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(Guid value) => new AssignmentExpression(this, new LiteralExpression<Guid>(value, this));
            public AssignmentExpression Set(AnyElement<Guid> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region payment method type field expression
        public partial class PaymentMethodTypeField : EnumFieldExpression<Purchase,SimpleConsole.Data.PaymentMethodType>
        {
            #region constructors
            public PaymentMethodTypeField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<SimpleConsole.Data.PaymentMethodType>(value));
            public AssignmentExpression Set(SimpleConsole.Data.PaymentMethodType value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.PaymentMethodType>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.PaymentMethodType> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region payment source type field expression
        public partial class PaymentSourceTypeField : NullableEnumFieldExpression<Purchase,SimpleConsole.Data.PaymentSourceType>
        {
            #region constructors
            public PaymentSourceTypeField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<SimpleConsole.Data.PaymentSourceType?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.PaymentSourceType?>(value, this));
            public AssignmentExpression Set(SimpleConsole.Data.PaymentSourceType value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.PaymentSourceType>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.PaymentSourceType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(SimpleConsole.Data.PaymentSourceType? value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.PaymentSourceType?>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.PaymentSourceType?> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<Purchase>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime>(value));
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<Purchase>
        {
            #region constructors
            public DateUpdatedField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime>(value));
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region purchase line entity expression
    public partial class PurchaseLineEntity : EntityExpression<PurchaseLine>
    {
        #region internals
        private SelectExpressionSet _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.IdField"/> representing the "dbo.PurchaseLine.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.IdField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>identity</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.PurchaseIdField"/> representing the "dbo.PurchaseLine.PurchaseId" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.PurchaseIdField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PurchaseId</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PurchaseIdField PurchaseId;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.ProductIdField"/> representing the "dbo.PurchaseLine.ProductId" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.ProductIdField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ProductId</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ProductIdField ProductId;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.PurchasePriceField"/> representing the "dbo.PurchaseLine.PurchasePrice" column in the database, 
        /// with a .NET type of <see cref="decimal"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.PurchasePriceField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Decimal}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PurchasePrice</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>decimal(12,2)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly PurchasePriceField PurchasePrice;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.QuantityField"/> representing the "dbo.PurchaseLine.Quantity" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.QuantityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Quantity</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly QuantityField Quantity;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.DateCreatedField"/> representing the "dbo.PurchaseLine.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.DateCreatedField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateCreated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateCreatedField DateCreated;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.DateUpdatedField"/> representing the "dbo.PurchaseLine.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="SimpleConsole.dboDataService.PurchaseLineEntity.DateUpdatedField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateUpdated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateUpdatedField DateUpdated;

        #endregion

        #region constructors
        public PurchaseLineEntity(string identifier, string name, Schema schema) : this(identifier, name, schema, null)
        {
        }

        private PurchaseLineEntity(string identifier, string name, Schema schema, string alias) : base(identifier, name, schema, alias)
        {
            Attributes.Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Attributes.Fields.Add($"{identifier}.PurchaseId", PurchaseId = new PurchaseIdField($"{identifier}.PurchaseId", "PurchaseId", this));
            Attributes.Fields.Add($"{identifier}.ProductId", ProductId = new ProductIdField($"{identifier}.ProductId", "ProductId", this));
            Attributes.Fields.Add($"{identifier}.PurchasePrice", PurchasePrice = new PurchasePriceField($"{identifier}.PurchasePrice", "PurchasePrice", this));
            Attributes.Fields.Add($"{identifier}.Quantity", Quantity = new QuantityField($"{identifier}.Quantity", "Quantity", this));
            Attributes.Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
            Attributes.Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", "DateUpdated", this));
        }
        #endregion

        #region methods
        public PurchaseLineEntity As(string alias)
            => new PurchaseLineEntity(this.Attributes.Identifier, this.Attributes.Name, this.Attributes.Schema, alias);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return _inclusiveSelectExpressionSet ?? (_inclusiveSelectExpressionSet = new SelectExpressionSet(
                new SelectExpression<int>(Id)
                ,new SelectExpression<int>(PurchaseId)
                ,new SelectExpression<int>(ProductId)
                ,new SelectExpression<decimal>(PurchasePrice)
                ,new SelectExpression<int>(Quantity)
                ,new SelectExpression<DateTime>(DateCreated)
                ,new SelectExpression<DateTime>(DateUpdated)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet set = null;
            string aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(PurchaseId));
            set &= aliased != nameof(PurchaseId) ? new SelectExpression<int>(PurchaseId, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PurchaseId));

            aliased = alias(nameof(ProductId));
            set &= aliased != nameof(ProductId) ? new SelectExpression<int>(ProductId, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ProductId));

            aliased = alias(nameof(PurchasePrice));
            set &= aliased != nameof(PurchasePrice) ? new SelectExpression<decimal>(PurchasePrice, aliased) as SelectExpression<decimal> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PurchasePrice));

            aliased = alias(nameof(Quantity));
            set &= aliased != nameof(Quantity) ? new SelectExpression<int>(Quantity, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Quantity));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<PurchaseLine> GetInclusiveInsertExpression(PurchaseLine entity)
        {
            return new InsertExpressionSet<PurchaseLine>(entity 
                ,new InsertExpression<int>(entity.PurchaseId, PurchaseId)
                ,new InsertExpression<int>(entity.ProductId, ProductId)
                ,new InsertExpression<decimal>(entity.PurchasePrice, PurchasePrice)
                ,new InsertExpression<int>(entity.Quantity, Quantity)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PurchaseLine target, PurchaseLine source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.PurchaseId != source.PurchaseId) { expr &= PurchaseId.Set(source.PurchaseId); }
            if (target.ProductId != source.ProductId) { expr &= ProductId.Set(source.ProductId); }
            if (target.PurchasePrice != source.PurchasePrice) { expr &= PurchasePrice.Set(source.PurchasePrice); }
            if (target.Quantity != source.Quantity) { expr &= Quantity.Set(source.Quantity); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, PurchaseLine entity)
        {
            entity.Id = reader.ReadField().GetValue<int>();
            entity.PurchaseId = reader.ReadField().GetValue<int>();
            entity.ProductId = reader.ReadField().GetValue<int>();
            entity.PurchasePrice = reader.ReadField().GetValue<decimal>();
            entity.Quantity = reader.ReadField().GetValue<int>();
            entity.DateCreated = reader.ReadField().GetValue<DateTime>();
            entity.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<PurchaseLine>
        {
            #region constructors
            public IdField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region purchase id field expression
        public partial class PurchaseIdField : Int32FieldExpression<PurchaseLine>
        {
            #region constructors
            public PurchaseIdField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region product id field expression
        public partial class ProductIdField : Int32FieldExpression<PurchaseLine>
        {
            #region constructors
            public ProductIdField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region purchase price field expression
        public partial class PurchasePriceField : DecimalFieldExpression<PurchaseLine>
        {
            #region constructors
            public PurchasePriceField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<decimal>(value));
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            public AssignmentExpression Set(AnyElement<decimal> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region quantity field expression
        public partial class QuantityField : Int32FieldExpression<PurchaseLine>
        {
            #region constructors
            public QuantityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<PurchaseLine>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime>(value));
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<PurchaseLine>
        {
            #region constructors
            public DateUpdatedField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime>(value));
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region person total purchases view entity expression
    public partial class PersonTotalPurchasesViewEntity : EntityExpression<PersonTotalPurchasesView>
    {
        #region internals
        private SelectExpressionSet _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonTotalPurchasesViewEntity.IdField"/> representing the "dbo.PersonTotalPurchasesView.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.dboDataService.PersonTotalPurchasesViewEntity.IdField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonTotalPurchasesViewEntity.TotalAmountField"/> representing the "dbo.PersonTotalPurchasesView.TotalAmount" column in the database, 
        /// with a .NET type of <see cref="double"/>?.  The <see cref="SimpleConsole.dboDataService.PersonTotalPurchasesViewEntity.TotalAmountField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Double}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>TotalAmount</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>money</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly TotalAmountField TotalAmount;


        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonTotalPurchasesViewEntity.TotalCountField"/> representing the "dbo.PersonTotalPurchasesView.TotalCount" column in the database, 
        /// with a .NET type of <see cref="int"/>?.  The <see cref="SimpleConsole.dboDataService.PersonTotalPurchasesViewEntity.TotalCountField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>TotalCount</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly TotalCountField TotalCount;

        #endregion

        #region constructors
        public PersonTotalPurchasesViewEntity(string identifier, string name, Schema schema) : this(identifier, name, schema, null)
        {
        }

        private PersonTotalPurchasesViewEntity(string identifier, string name, Schema schema, string alias) : base(identifier, name, schema, alias)
        {
            Attributes.Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Attributes.Fields.Add($"{identifier}.TotalAmount", TotalAmount = new TotalAmountField($"{identifier}.TotalAmount", "TotalAmount", this));
            Attributes.Fields.Add($"{identifier}.TotalCount", TotalCount = new TotalCountField($"{identifier}.TotalCount", "TotalCount", this));
        }
        #endregion

        #region methods
        public PersonTotalPurchasesViewEntity As(string alias)
            => new PersonTotalPurchasesViewEntity(this.Attributes.Identifier, this.Attributes.Name, this.Attributes.Schema, alias);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return _inclusiveSelectExpressionSet ?? (_inclusiveSelectExpressionSet = new SelectExpressionSet(
                new SelectExpression<int>(Id)
                ,new SelectExpression<double?>(TotalAmount)
                ,new SelectExpression<int?>(TotalCount)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet set = null;
            string aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(TotalAmount));
            set &= aliased != nameof(TotalAmount) ? new SelectExpression<double?>(TotalAmount, aliased) as SelectExpression<double?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(TotalAmount));

            aliased = alias(nameof(TotalCount));
            set &= aliased != nameof(TotalCount) ? new SelectExpression<int?>(TotalCount, aliased) as SelectExpression<int?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(TotalCount));

            return set;
        }
		
        protected override InsertExpressionSet<PersonTotalPurchasesView> GetInclusiveInsertExpression(PersonTotalPurchasesView entity)
        {
            return new InsertExpressionSet<PersonTotalPurchasesView>(entity 
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PersonTotalPurchasesView target, PersonTotalPurchasesView source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, PersonTotalPurchasesView entity)
        {
            entity.Id = reader.ReadField().GetValue<int>();
            entity.TotalAmount = reader.ReadField().GetValue<double?>();
            entity.TotalCount = reader.ReadField().GetValue<int?>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<PersonTotalPurchasesView>
        {
            #region constructors
            public IdField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region total amount field expression
        public partial class TotalAmountField : NullableDoubleFieldExpression<PersonTotalPurchasesView>
        {
            #region constructors
            public TotalAmountField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<double?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<double?>(value, this));
            public AssignmentExpression Set(double? value) => new AssignmentExpression(this, new LiteralExpression<double?>(value, this));
            public AssignmentExpression Set(AnyElement<double?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(double value) => new AssignmentExpression(this, new LiteralExpression<double>(value, this));
            public AssignmentExpression Set(AnyElement<double> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region total count field expression
        public partial class TotalCountField : NullableInt32FieldExpression<PersonTotalPurchasesView>
        {
            #region constructors
            public TotalCountField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<int?>(value, this));
            public AssignmentExpression Set(int? value) => new AssignmentExpression(this, new LiteralExpression<int?>(value, this));
            public AssignmentExpression Set(AnyElement<int?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region select person_ as_ dynamic_ with_ input stored procedure expression
    public partial class SelectPerson_As_Dynamic_With_InputStoredProcedure : StoredProcedureExpression
    {
        public SelectPerson_As_Dynamic_With_InputStoredProcedure(
            string identifier
            ,Schema schema
            ,int? P1
        ) : base($"{identifier}.SelectPerson_As_Dynamic_With_Input", "SelectPerson_As_Dynamic_With_Input", schema)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPerson_As_Dynamic_With_Input.@P1", "P1", P1, ParameterDirection.Input));
        }
    }
    #endregion

    #region select person_ as_ dynamic_ with_ input_ and_ input output stored procedure expression
    public partial class SelectPerson_As_Dynamic_With_Input_And_InputOutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPerson_As_Dynamic_With_Input_And_InputOutputStoredProcedure(
            string identifier
            ,Schema schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base($"{identifier}.SelectPerson_As_Dynamic_With_Input_And_InputOutput", "SelectPerson_As_Dynamic_With_Input_And_InputOutput", schema, outputParameters)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPerson_As_Dynamic_With_Input_And_InputOutput.@P1", "P1", P1, ParameterDirection.Input));
            Attributes.Parameters.Add("CreditLimit", new ParameterExpression<int?>($"{identifier}.SelectPerson_As_Dynamic_With_Input_And_InputOutput.@CreditLimit", "CreditLimit", ParameterDirection.Output));
        }
    }
    #endregion

    #region select person_ as_ dynamic_ with_ input_ and_ output stored procedure expression
    public partial class SelectPerson_As_Dynamic_With_Input_And_OutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPerson_As_Dynamic_With_Input_And_OutputStoredProcedure(
            string identifier
            ,Schema schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base($"{identifier}.SelectPerson_As_Dynamic_With_Input_And_Output", "SelectPerson_As_Dynamic_With_Input_And_Output", schema, outputParameters)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPerson_As_Dynamic_With_Input_And_Output.@P1", "P1", P1, ParameterDirection.Input));
            Attributes.Parameters.Add("Count", new ParameterExpression<int?>($"{identifier}.SelectPerson_As_Dynamic_With_Input_And_Output.@Count", "Count", ParameterDirection.Output));
        }
    }
    #endregion

    #region select person_ as_ dynamic list_ with_ input stored procedure expression
    public partial class SelectPerson_As_DynamicList_With_InputStoredProcedure : StoredProcedureExpression
    {
        public SelectPerson_As_DynamicList_With_InputStoredProcedure(
            string identifier
            ,Schema schema
            ,int? P1
        ) : base($"{identifier}.SelectPerson_As_DynamicList_With_Input", "SelectPerson_As_DynamicList_With_Input", schema)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPerson_As_DynamicList_With_Input.@P1", "P1", P1, ParameterDirection.Input));
        }
    }
    #endregion

    #region select person_ as_ dynamic list_ with_ input_ and_ input output stored procedure expression
    public partial class SelectPerson_As_DynamicList_With_Input_And_InputOutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPerson_As_DynamicList_With_Input_And_InputOutputStoredProcedure(
            string identifier
            ,Schema schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base($"{identifier}.SelectPerson_As_DynamicList_With_Input_And_InputOutput", "SelectPerson_As_DynamicList_With_Input_And_InputOutput", schema, outputParameters)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPerson_As_DynamicList_With_Input_And_InputOutput.@P1", "P1", P1, ParameterDirection.Input));
            Attributes.Parameters.Add("CreditLimit", new ParameterExpression<int?>($"{identifier}.SelectPerson_As_DynamicList_With_Input_And_InputOutput.@CreditLimit", "CreditLimit", ParameterDirection.Output));
        }
    }
    #endregion

    #region select person_ as_ dynamic list_ with_ input_ and_ output stored procedure expression
    public partial class SelectPerson_As_DynamicList_With_Input_And_OutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPerson_As_DynamicList_With_Input_And_OutputStoredProcedure(
            string identifier
            ,Schema schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base($"{identifier}.SelectPerson_As_DynamicList_With_Input_And_Output", "SelectPerson_As_DynamicList_With_Input_And_Output", schema, outputParameters)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPerson_As_DynamicList_With_Input_And_Output.@P1", "P1", P1, ParameterDirection.Input));
            Attributes.Parameters.Add("Count", new ParameterExpression<int?>($"{identifier}.SelectPerson_As_DynamicList_With_Input_And_Output.@Count", "Count", ParameterDirection.Output));
        }
    }
    #endregion

    #region select person id_ as_ scalar value_ with_ input stored procedure expression
    public partial class SelectPersonId_As_ScalarValue_With_InputStoredProcedure : StoredProcedureExpression
    {
        public SelectPersonId_As_ScalarValue_With_InputStoredProcedure(
            string identifier
            ,Schema schema
            ,int? P1
        ) : base($"{identifier}.SelectPersonId_As_ScalarValue_With_Input", "SelectPersonId_As_ScalarValue_With_Input", schema)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValue_With_Input.@P1", "P1", P1, ParameterDirection.Input));
        }
    }
    #endregion

    #region select person id_ as_ scalar value_ with_ input_ and_ default_ value stored procedure expression
    public partial class SelectPersonId_As_ScalarValue_With_Input_And_Default_ValueStoredProcedure : StoredProcedureExpression
    {
        public SelectPersonId_As_ScalarValue_With_Input_And_Default_ValueStoredProcedure(
            string identifier
            ,Schema schema
            ,int? P1
        ) : base($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_Default_Value", "SelectPersonId_As_ScalarValue_With_Input_And_Default_Value", schema)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_Default_Value.@P1", "P1", P1, ParameterDirection.Input));
        }
    }
    #endregion

    #region select person id_ as_ scalar value_ with_ input_ and_ input output stored procedure expression
    public partial class SelectPersonId_As_ScalarValue_With_Input_And_InputOutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPersonId_As_ScalarValue_With_Input_And_InputOutputStoredProcedure(
            string identifier
            ,Schema schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput", "SelectPersonId_As_ScalarValue_With_Input_And_InputOutput", schema, outputParameters)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput.@P1", "P1", P1, ParameterDirection.Input));
            Attributes.Parameters.Add("CreditLimit", new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput.@CreditLimit", "CreditLimit", ParameterDirection.Output));
        }
    }
    #endregion

    #region select person id_ as_ scalar value_ with_ input_ and_ output stored procedure expression
    public partial class SelectPersonId_As_ScalarValue_With_Input_And_OutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPersonId_As_ScalarValue_With_Input_And_OutputStoredProcedure(
            string identifier
            ,Schema schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_Output", "SelectPersonId_As_ScalarValue_With_Input_And_Output", schema, outputParameters)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_Output.@P1", "P1", P1, ParameterDirection.Input));
            Attributes.Parameters.Add("Count", new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_Output.@Count", "Count", ParameterDirection.Output));
        }
    }
    #endregion

    #region select person id_ as_ scalar value list_ with_ input stored procedure expression
    public partial class SelectPersonId_As_ScalarValueList_With_InputStoredProcedure : StoredProcedureExpression
    {
        public SelectPersonId_As_ScalarValueList_With_InputStoredProcedure(
            string identifier
            ,Schema schema
            ,int? P1
        ) : base($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input", "SelectPersonId_As_ScalarValueList_With_Input", schema)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input.@P1", "P1", P1, ParameterDirection.Input));
        }
    }
    #endregion

    #region select person id_ as_ scalar value list_ with_ input_ and_ input output stored procedure expression
    public partial class SelectPersonId_As_ScalarValueList_With_Input_And_InputOutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPersonId_As_ScalarValueList_With_Input_And_InputOutputStoredProcedure(
            string identifier
            ,Schema schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput", "SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput", schema, outputParameters)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput.@P1", "P1", P1, ParameterDirection.Input));
            Attributes.Parameters.Add("CreditLimit", new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput.@CreditLimit", "CreditLimit", ParameterDirection.Output));
        }
    }
    #endregion

    #region select person id_ as_ scalar value list_ with_ input_ and_ output stored procedure expression
    public partial class SelectPersonId_As_ScalarValueList_With_Input_And_OutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPersonId_As_ScalarValueList_With_Input_And_OutputStoredProcedure(
            string identifier
            ,Schema schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_Output", "SelectPersonId_As_ScalarValueList_With_Input_And_Output", schema, outputParameters)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_Output.@P1", "P1", P1, ParameterDirection.Input));
            Attributes.Parameters.Add("Count", new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_Output.@Count", "Count", ParameterDirection.Output));
        }
    }
    #endregion

    #region update person credit limit_ with_ inputs stored procedure expression
    public partial class UpdatePersonCreditLimit_With_InputsStoredProcedure : StoredProcedureExpression
    {
        public UpdatePersonCreditLimit_With_InputsStoredProcedure(
            string identifier
            ,Schema schema
            ,int? P1
            ,int? CreditLimit
        ) : base($"{identifier}.UpdatePersonCreditLimit_With_Inputs", "UpdatePersonCreditLimit_With_Inputs", schema)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.UpdatePersonCreditLimit_With_Inputs.@P1", "P1", P1, ParameterDirection.Input));
            Attributes.Parameters.Add("CreditLimit", new ParameterExpression<int?>($"{identifier}.UpdatePersonCreditLimit_With_Inputs.@CreditLimit", "CreditLimit", CreditLimit, ParameterDirection.Input));
        }
    }
    #endregion

    #region dbo
#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
#pragma warning disable IDE1006 // Naming Styles
    public partial class dbo
#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
    {
        private static dboSchemaExpression schema;

        #region interface
        /// <summary>A <see cref="SimpleConsole.dboDataService.AccessAuditLogEntity"/> representing the "dbo.AccessAuditLog" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>AccessAuditLog</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Indexes:</para>
        /// <para>
        /// <list type="bullet">PK_AccessAuditLog
        /// <list type="table">
        /// <item>
        /// <term>primary key</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>columns</term><description>Id</description>
        /// </item>
        /// </list>
        /// </list>
        /// </para>
        /// </summary>
        public static AccessAuditLogEntity AccessAuditLog { get; private set; }

        /// <summary>A <see cref="SimpleConsole.dboDataService.AddressEntity"/> representing the "dbo.Address" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Address</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Indexes:</para>
        /// <para>
        /// <list type="bullet">PK_Address
        /// <list type="table">
        /// <item>
        /// <term>primary key</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>columns</term><description>Id</description>
        /// </item>
        /// </list>
        /// </list>
        /// </para>
        /// </summary>
        public static AddressEntity Address { get; private set; }

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonEntity"/> representing the "dbo.Person" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Person</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Indexes:</para>
        /// <para>
        /// <list type="bullet">PK_Person
        /// <list type="table">
        /// <item>
        /// <term>primary key</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>columns</term><description>Id</description>
        /// </item>
        /// </list>
        /// </list>
        /// </para>
        /// </summary>
        public static PersonEntity Person { get; private set; }

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonAddressEntity"/> representing the "dbo.Person_Address" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Person_Address</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Indexes:</para>
        /// <para>
        /// <list type="bullet">PK_Person_Address
        /// <list type="table">
        /// <item>
        /// <term>primary key</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>columns</term><description>Id</description>
        /// </item>
        /// </list>
        /// </list>
        /// </para>
        /// </summary>
        public static PersonAddressEntity PersonAddress { get; private set; }

        /// <summary>A <see cref="SimpleConsole.dboDataService.ProductEntity"/> representing the "dbo.Product" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Product</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Indexes:</para>
        /// <para>
        /// <list type="bullet">PK_Product
        /// <list type="table">
        /// <item>
        /// <term>primary key</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>columns</term><description>Id</description>
        /// </item>
        /// </list>
        /// </list>
        /// </para>
        /// </summary>
        public static ProductEntity Product { get; private set; }

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseEntity"/> representing the "dbo.Purchase" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Purchase</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Indexes:</para>
        /// <para>
        /// <list type="bullet">PK_Purchase
        /// <list type="table">
        /// <item>
        /// <term>primary key</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>columns</term><description>Id</description>
        /// </item>
        /// </list>
        /// </list>
        /// </para>
        /// </summary>
        public static PurchaseEntity Purchase { get; private set; }

        /// <summary>A <see cref="SimpleConsole.dboDataService.PurchaseLineEntity"/> representing the "dbo.PurchaseLine" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PurchaseLine</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Indexes:</para>
        /// <para>
        /// <list type="bullet">PK_PurchaseLine
        /// <list type="table">
        /// <item>
        /// <term>primary key</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>columns</term><description>Id</description>
        /// </item>
        /// </list>
        /// </list>
        /// </para>
        /// </summary>
        public static PurchaseLineEntity PurchaseLine { get; private set; }

        /// <summary>A <see cref="SimpleConsole.dboDataService.PersonTotalPurchasesViewEntity"/> representing the "dbo.PersonTotalPurchasesView" view in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PersonTotalPurchasesView</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public static PersonTotalPurchasesViewEntity PersonTotalPurchasesView { get; private set; }

        #endregion

        #region use schema
        public static void UseSchema(dboSchemaExpression schema)
        { 
            if (schema == null)
                 throw new ArgumentNullException(nameof(schema));

            dbo.schema = schema;

            AccessAuditLog = schema.AccessAuditLog;
            Address = schema.Address;
            Person = schema.Person;
            PersonAddress = schema.PersonAddress;
            Product = schema.Product;
            Purchase = schema.Purchase;
            PurchaseLine = schema.PurchaseLine;
            PersonTotalPurchasesView = schema.PersonTotalPurchasesView;
        }
        #endregion
    }
    #endregion
}

namespace SimpleConsole.secDataService
{
	using SimpleConsole.secData;
	using System.Data;

    #region sec schema expression
    public class secSchemaExpression : SchemaExpression
    {
        #region interface
        public readonly PersonEntity Person;
        #endregion

        #region constructors
        public secSchemaExpression(string identifier) : base(identifier)
        {
            Attributes.Entities.Add($"{identifier}.Person", Person = new PersonEntity($"{identifier}.Person", "Person", this));
        }
        #endregion
    }
    #endregion

    #region person entity expression
    public partial class PersonEntity : EntityExpression<Person>
    {
        #region internals
        private SelectExpressionSet _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="SimpleConsole.secDataService.PersonEntity.IdField"/> representing the "sec.Person.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="SimpleConsole.secDataService.PersonEntity.IdField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Id</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>int</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly IdField Id;


        /// <summary>A <see cref="SimpleConsole.secDataService.PersonEntity.SSNField"/> representing the "sec.Person.SSN" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="SimpleConsole.secDataService.PersonEntity.SSNField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>SSN</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>char(11)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly SSNField SSN;


        /// <summary>A <see cref="SimpleConsole.secDataService.PersonEntity.DateCreatedField"/> representing the "sec.Person.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="SimpleConsole.secDataService.PersonEntity.DateCreatedField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateCreated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateCreatedField DateCreated;


        /// <summary>A <see cref="SimpleConsole.secDataService.PersonEntity.DateUpdatedField"/> representing the "sec.Person.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="SimpleConsole.secDataService.PersonEntity.DateUpdatedField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateUpdated</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// <item>
        /// <term>default</term><description>(getdate())</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateUpdatedField DateUpdated;

        #endregion

        #region constructors
        public PersonEntity(string identifier, string name, Schema schema) : this(identifier, name, schema, null)
        {
        }

        private PersonEntity(string identifier, string name, Schema schema, string alias) : base(identifier, name, schema, alias)
        {
            Attributes.Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Attributes.Fields.Add($"{identifier}.SSN", SSN = new SSNField($"{identifier}.SSN", "SSN", this));
            Attributes.Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
            Attributes.Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", "DateUpdated", this));
        }
        #endregion

        #region methods
        public PersonEntity As(string alias)
            => new PersonEntity(this.Attributes.Identifier, this.Attributes.Name, this.Attributes.Schema, alias);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return _inclusiveSelectExpressionSet ?? (_inclusiveSelectExpressionSet = new SelectExpressionSet(
                new SelectExpression<int>(Id)
                ,new SelectExpression<string>(SSN)
                ,new SelectExpression<DateTime>(DateCreated)
                ,new SelectExpression<DateTime>(DateUpdated)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet set = null;
            string aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(SSN));
            set &= aliased != nameof(SSN) ? new SelectExpression<string>(SSN, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(SSN));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<Person> GetInclusiveInsertExpression(Person entity)
        {
            return new InsertExpressionSet<Person>(entity 
                ,new InsertExpression<int>(entity.Id, Id)
                ,new InsertExpression<string>(entity.SSN, SSN)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person target, Person source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.Id != source.Id) { expr &= Id.Set(source.Id); }
            if (target.SSN != source.SSN) { expr &= SSN.Set(source.SSN); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, Person entity)
        {
            entity.Id = reader.ReadField().GetValue<int>();
            entity.SSN = reader.ReadField().GetValue<string>();
            entity.DateCreated = reader.ReadField().GetValue<DateTime>();
            entity.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<Person>
        {
            #region constructors
            public IdField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<int>(value));
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region s s n field expression
        public partial class SSNField : StringFieldExpression<Person>
        {
            #region constructors
            public SSNField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string>(value));
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(StringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<Person>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime>(value));
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<Person>
        {
            #region constructors
            public DateUpdatedField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DateTime>(value));
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region sec
#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
#pragma warning disable IDE1006 // Naming Styles
    public partial class sec
#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
    {
        private static secSchemaExpression schema;

        #region interface
        /// <summary>A <see cref="SimpleConsole.secDataService.PersonEntity"/> representing the "sec.Person" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Person</description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>Indexes:</para>
        /// <para>
        /// <list type="bullet">PK_secPerson
        /// <list type="table">
        /// <item>
        /// <term>primary key</term><description>yes</description>
        /// </item>
        /// <item>
        /// <term>columns</term><description>Id</description>
        /// </item>
        /// </list>
        /// </list>
        /// </para>
        /// </summary>
        public static PersonEntity Person { get; private set; }

        #endregion

        #region use schema
        public static void UseSchema(secSchemaExpression schema)
        { 
            if (schema == null)
                 throw new ArgumentNullException(nameof(schema));

            sec.schema = schema;

            Person = schema.Person;
        }
        #endregion
    }
    #endregion
}

#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CA1034 // Nested types should not be visible
