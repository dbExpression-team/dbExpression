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
#nullable enable
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CA1034 // Nested types should not be visible
namespace DbEx.DataService
{
	using DbEx.dboDataService;
	using DbEx.unit_testDataService;
	using DbEx.secDataService;
	using _dboDataService = DbEx.dboDataService;
	using _unit_testDataService = DbEx.unit_testDataService;
	using _secDataService = DbEx.secDataService;

    #region db
    public static class db
    {
        #region internals
        private static MsSqlDb? _mssqldb;
        private static MsSqlDb MsSqlDb => _mssqldb ?? throw new DbExpressionConfigurationException("the database 'MsSqlDb' has not been properly configured for runtime use with dbExpression.");
        #endregion

        #region interface
        public static MsSqlFunctionExpressionBuilder fx => MsSqlDb.fx;
        public static MsSqlDb.MsSqlDbStoredProcedures sp => MsSqlDb.sp;
        #endregion

        #region methods
        internal static void UseDatabase(MsSqlDb mssqldb)
            => _mssqldb = mssqldb ?? throw new ArgumentNullException(nameof(mssqldb));
        
        #region select one
        /// <summary>
        /// Start constructing a sql SELECT query expression for a single entity.
        /// <para>
        /// To retrieve a <see cref="DbEx.dboData.AccessAuditLog" />, use a type param of <see cref="DbEx.dboData.AccessAuditLog" />
        /// </para>
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectEntity{TEntity}"/>, a fluent builder for constructing a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        /// <typeparam name="TEntity">The entity type to select.</typeparam>
        public static SelectEntity<TEntity> SelectOne<TEntity>()
            where TEntity : class, IDbEntity, new()
            => MsSqlDb.SelectOne<TEntity>();

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="TEnum"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />
        ///, for example "dbo.Person.GenderType"
        /// </param>
        /// <returns><see cref="Sql.SelectValue{TEnum}"/>, a fluent builder for constructing a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        /// <typeparam name="TEnum">The type of the Enum to select.</typeparam>
        public static SelectValue<TEnum> SelectOne<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => MsSqlDb.SelectOne<TEnum>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="TEnum"/>? value.  
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />?
        ///, for example "dbo.Address.AddressType"
        /// </param>
        /// <returns><see cref="SelectValue{TEnum}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="TEnum">The type of the Enum to select.</typeparam>
        public static SelectValue<TEnum?> SelectOne<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable
            => MsSqlDb.SelectOne<TEnum>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="object"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValue{object}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<object>? SelectOne(ObjectElement element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="object"/>? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValue{object}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<object?> SelectOne(NullableObjectElement element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="T"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement{T}" />
        /// </param>
        /// <returns><see cref="SelectValue{T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the object to select.</typeparam>
        public static SelectObject<T> SelectOne<T>(ObjectElement<T> element)
            where T : class?
            => MsSqlDb.SelectOne<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="T"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AliasedElement{T}" />      
        /// </param>
        /// <returns><see cref="SelectValues{T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the value to select.</typeparam>
        public static SelectValue<T> SelectOne<T>(AliasedElement<T> element)
            => MsSqlDb.SelectOne<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="bool" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        ///, for example "unit_test.ExpressionElementType.Boolean" or "db.fx.IsNull(unit_test.ExpressionElementType.Boolean, false)
        ///</param>
        /// <returns><see cref="SelectValue{Boolean}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<bool> SelectOne(AnyElement<bool> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="bool" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />?
        ///, for example "unit_test.ExpressionElementType.NullableBoolean""
        ///</param>
        /// <returns><see cref="SelectValue{Boolean}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<bool?> SelectOne(AnyElement<bool?> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />
        ///, for example "unit_test.ExpressionElementType.Byte" or "db.fx.IsNull(unit_test.ExpressionElementType.Byte, byte.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValue{Byte}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<byte> SelectOne(AnyElement<byte> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />?
        ///, for example "unit_test.ExpressionElementType.NullableByte"
        ///</param>
        /// <returns><see cref="SelectValue{Byte}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<byte?> SelectOne(AnyElement<byte?> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" />[] value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte[]}" />
        ///</param>
        /// <returns><see cref="SelectValue{Byte[]}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<byte[]> SelectOne(AnyElement<byte[]> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTime" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />
        ///, for example "dbo.AccessAuditLog.DateCreated", "db.fx.DateAdd(DateParts.Year, 1, dbo.AccessAuditLog.DateCreated) or "db.fx.IsNull(dbo.AccessAuditLog.DateCreated, DateTime.Now)"
        ///</param>
        /// <returns><see cref="SelectValue{DateTime}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<DateTime> SelectOne(AnyElement<DateTime> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTime" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />?
        ///, for example "dbo.Person.BirthDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.BirthDate)
        ///</param>
        /// <returns><see cref="SelectValue{DateTime}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<DateTime?> SelectOne(AnyElement<DateTime?> field)
            => MsSqlDb.SelectOne(field);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTimeOffset" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />
        ///, for example "dbo.Person.RegistrationDate", "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.RegistrationDate)" or "db.fx.IsNull(dbo.Person.RegistrationDate, DateTimeOffset.Now)"
        ///</param>
        /// <returns><see cref="SelectValue{DateTimeOffset}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<DateTimeOffset> SelectOne(AnyElement<DateTimeOffset> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTimeOffset" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />?
        ///, for example "dbo.Person.LastLoginDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.LastLoginDate)" 
        ///</param>
        /// <returns><see cref="SelectValue{DateTimeOffset}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<DateTimeOffset?> SelectOne(AnyElement<DateTimeOffset?> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="decimal" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />
        ///, for example "dbo.Product.ShippingWeight" or "db.fx.IsNull(dbo.Product.ShippingWeight, decimal.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValue{Decimal}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<decimal> SelectOne(AnyElement<decimal> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="decimal" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />?
        ///, for example "dbo.Product.Height" or "db.fx.Min(dbo.Product.Height)"
        ///</param>
        /// <returns><see cref="SelectValue{Decimal}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<decimal?> SelectOne(AnyElement<decimal?> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="double" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />
        ///, for example "dbo.Product.ListPrice" or "db.fx.IsNull(dbo.Product.ListPrice, double.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValue{Double}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<double> SelectOne(AnyElement<double> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="double" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />?
        ///, for example "dbo.PersonTotalPurchasesView.TotalAmount" or "db.fx.Min(dbo.PersonTotalPurchasesView.TotalAmount)"
        ///</param>
        /// <returns><see cref="SelectValue{Double}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<double?> SelectOne(AnyElement<double?> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="Guid" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />
        ///, for example "unit_test.ExpressionElementType.Guid" or "db.fx.IsNull(unit_test.ExpressionElementType.Guid, Guid.Empty)"
        ///</param>
        /// <returns><see cref="SelectValue{Guid}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<Guid> SelectOne(AnyElement<Guid> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="Guid" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />?
        ///, for example "dbo.Purchase.TrackingIdentifier"
        ///</param>
        /// <returns><see cref="SelectValue{Guid}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<Guid?> SelectOne(AnyElement<Guid?> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="short" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />
        ///, for example "unit_test.ExpressionElementType.Int16" or "db.fx.IsNull(unit_test.ExpressionElementType.Int16, short.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValue{Int16}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<short> SelectOne(AnyElement<short> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="short" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />?
        ///, for example "unit_test.ExpressionElementType.NullableInt16" or "db.fx.Max(unit_test.ExpressionElementType.NullableInt16)"
        ///</param>
        /// <returns><see cref="SelectValue{Int16}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<short?> SelectOne(AnyElement<short?> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="int" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />?
        ///, for example "dbo.AccessAuditLog.Id" or "db.fx.Avg(dbo.AccessAuditLog.Id)"
        ///</param>
        /// <returns><see cref="SelectValue{Int32}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<int> SelectOne(AnyElement<int> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="int" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />?
        ///, for example "dbo.Person.CreditLimit" or "db.fx.Avg(dbo.Person.CreditLimit)"
        ///</param>
        /// <returns><see cref="SelectValue{Int32}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<int?> SelectOne(AnyElement<int?> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="long" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />
        ///, for example "unit_test.ExpressionElementType.Int64" or "db.fx.IsNull(unit_test.ExpressionElementType.Int64, long.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValue{Int64}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<long> SelectOne(AnyElement<long> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="long" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />?
        ///, for example "unit_test.ExpressionElementType.NullableInt64" or "db.fx.Max(unit_test.ExpressionElementType.NullableInt64)"
        ///</param>
        /// <returns><see cref="SelectValue{Int64}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<long?> SelectOne(AnyElement<long?> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="float" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />
        ///, for example "unit_test.ExpressionElementType.Single" or "db.fx.IsNull(unit_test.ExpressionElementType.Single, float.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValue{Single}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<float> SelectOne(AnyElement<float> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="float" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />?
        ///, for example "unit_test.ExpressionElementType.NullableSingle" or "db.fx.Max(unit_test.ExpressionElementType.NullableSingle)"
        ///</param>
        /// <returns><see cref="SelectValue{Single}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<float?> SelectOne(AnyElement<float?> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="string" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />?
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        ///</param>
        /// <returns><see cref="SelectValue{String}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<string> SelectOne(StringElement element) 
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="string" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />?
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        ///</param>
        /// <returns><see cref="SelectValue{String}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<string?> SelectOne(NullableStringElement element) 
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="TimeSpan" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />
        ///, for example "unit_test.ExpressionElementType.TimeSpan", "db.fx.IsNull(unit_test.ExpressionElementType.TimeSpan, TimeSpan.MinValue)" or "unit_test.ExpressionElementType.TimeSpan + DateTime.Now"
        ///</param>
        /// <returns><see cref="SelectValue{TimeSpan}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<TimeSpan> SelectOne(AnyElement<TimeSpan> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="TimeSpan" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />?
        ///, for example "dbo.Product.ValidStartTimeOfDayForPurchase"
        ///</param>
        /// <returns><see cref="SelectValue{TimeSpan}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<TimeSpan?> SelectOne(AnyElement<TimeSpan?> element)
            => MsSqlDb.SelectOne(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>databaseExpressionName
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="element2">Any expression</param>
        /// <param name="elements">Any expression</param>
        /// <returns><see cref="SelectDynamic"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectDynamic SelectOne(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => MsSqlDb.SelectOne(element1, element2, elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="elements">A list of any expression</param>
        /// <returns><see cref="SelectDynamic"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectDynamic SelectOne(IEnumerable<AnyElement> elements)
            => MsSqlDb.SelectOne(elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression that is valid for a SELECT query expression.</param>
        /// <param name="additionalElements">Any additional fields to select as part of the SELECT query expression.</param>
        /// <returns><see cref="SelectDynamics"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectDynamic SelectOne(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
            => MsSqlDb.SelectOne((elements ?? throw new ArgumentNullException(nameof(elements))).Concat(additionalElements));
        #endregion

        #region select many
        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of entities.
        /// <para>
        /// To retrieve a list of <see cref="DbEx.dboData.AccessAuditLog" />(s), use a type param of <see cref="DbEx.dboData.AccessAuditLog" />
        /// </para>
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectEntities{TEntity}"/>, a fluent builder for constructing a sql SELECT query expression for a list of <typeparamref name="TEntity"/> entities.</returns>
        /// <typeparam name="TEntity">The entity type to select.</typeparam>
        public static SelectEntities<TEntity> SelectMany<TEntity>()
           where TEntity : class, IDbEntity, new()
           => MsSqlDb.SelectMany<TEntity>();

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="TEnum"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />
        ///, for example "dbo.Person.GenderType"
        /// </param>
        /// <returns><see cref="SelectValues{TEnum}"/>, a fluent builder for constructing a sql SELECT query expression for a list of <typeparamref name="TEntity"/> entities.</returns>
        public static SelectValues<TEnum> SelectMany<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => MsSqlDb.SelectMany<TEnum>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="TEnum"/>? values.
        /// </summary>
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />?
        ///, for example "dbo.Address.AddressType"
        /// </param>
        /// <returns><see cref="SelectValues{TEnum}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<TEnum?> SelectMany<TEnum>(AnyElement<TEnum?> element)
            where TEnum : struct, Enum, IComparable
            => MsSqlDb.SelectMany<TEnum>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="object"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValues{object}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<object>? SelectMany(ObjectElement element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="object"/>? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValues{object}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<object?> SelectMany(NullableObjectElement element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="T"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement{T}" />
        /// </param>
        /// <returns><see cref="SelectValues{T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the object to select.</typeparam>
        public static SelectObjects<T> SelectMany<T>(ObjectElement<T> element)
            where T : class?
            => MsSqlDb.SelectMany<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="T"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AliasedElement{T}" />      
        /// </param>
        /// <returns><see cref="SelectValues{T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the value to select.</typeparam>
        public static SelectValues<T> SelectMany<T>(AliasedElement<T> element)
            => MsSqlDb.SelectMany<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="bool" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        ///, for example "unit_test.ExpressionElementType.Boolean" or "db.fx.IsNull(unit_test.ExpressionElementType.Boolean, false)
        ///</param>
        /// <returns><see cref="SelectValues{Boolean}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<bool> SelectMany(AnyElement<bool> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="bool" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />?
        ///, for example "unit_test.ExpressionElementType.NullableBoolean""
        ///</param>
        /// <returns><see cref="SelectValues{Boolean}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<bool?> SelectMany(AnyElement<bool?> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />
        ///, for example "unit_test.ExpressionElementType.Byte" or "db.fx.IsNull(unit_test.ExpressionElementType.Byte, byte.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValues{Byte}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<byte> SelectMany(AnyElement<byte> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />?
        ///, for example "unit_test.ExpressionElementType.NullableByte"
        ///</param>
        /// <returns><see cref="SelectValues{Byte}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<byte?> SelectMany(AnyElement<byte?> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" />[] values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte[]}" />
        ///</param>
        /// <returns><see cref="SelectValues{Byte[]}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<byte[]> SelectMany(AnyElement<byte[]> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTime" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />
        ///, for example "dbo.AccessAuditLog.DateCreated", "db.fx.DateAdd(DateParts.Year, 1, dbo.AccessAuditLog.DateCreated) or "db.fx.IsNull(dbo.AccessAuditLog.DateCreated, DateTime.Now)"
        ///</param>
        /// <returns><see cref="SelectValues{DateTime}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<DateTime> SelectMany(AnyElement<DateTime> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTime" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />?
        ///, for example "dbo.Person.BirthDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.BirthDate)
        ///</param>
        /// <returns><see cref="SelectValues{DateTime}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<DateTime?> SelectMany(AnyElement<DateTime?> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTimeOffset" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />
        ///, for example "dbo.Person.RegistrationDate", "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.RegistrationDate)" or "db.fx.IsNull(dbo.Person.RegistrationDate, DateTimeOffset.Now)"
        ///</param>
        /// <returns><see cref="SelectValues{DateTimeOffset}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<DateTimeOffset> SelectMany(AnyElement<DateTimeOffset> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTimeOffset" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />?
        ///, for example "dbo.Person.LastLoginDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.LastLoginDate)" 
        ///</param>
        /// <returns><see cref="SelectValues{DateTimeOffset}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<DateTimeOffset?> SelectMany(AnyElement<DateTimeOffset?> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="decimal" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />
        ///, for example "dbo.Product.ShippingWeight" or "db.fx.IsNull(dbo.Product.ShippingWeight, decimal.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValues{Decimal}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<decimal> SelectMany(AnyElement<decimal> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="decimal" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />?
        ///, for example "dbo.Product.Height"
        ///</param>
        /// <returns><see cref="SelectValues{Decimal}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<decimal?> SelectMany(AnyElement<decimal?> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="double" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />
        ///, for example "dbo.Product.ListPrice" or "db.fx.IsNull(dbo.Product.ListPrice, double.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValues{Double}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<double> SelectMany(AnyElement<double> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="double" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />?
        ///, for example "dbo.PersonTotalPurchasesView.TotalAmount"
        ///</param>
        /// <returns><see cref="SelectValues{Double}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<double?> SelectMany(AnyElement<double?> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="Guid" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />
        ///, for example "unit_test.ExpressionElementType.Guid" or "db.fx.IsNull(unit_test.ExpressionElementType.Guid, Guid.Empty)"
        ///</param>
        /// <returns><see cref="SelectValues{Guid}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<Guid> SelectMany(AnyElement<Guid> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="Guid" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />?
        ///, for example "dbo.Purchase.TrackingIdentifier"
        ///</param>
        /// <returns><see cref="SelectValues{Guid}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<Guid?> SelectMany(AnyElement<Guid?> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="short" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />
        ///, for example "unit_test.ExpressionElementType.Int16" or "db.fx.IsNull(unit_test.ExpressionElementType.Int16, short.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValues{Int16}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<short> SelectMany(AnyElement<short> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="short" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />?
        ///, for example "unit_test.ExpressionElementType.NullableInt16"
        ///</param>
        /// <returns><see cref="SelectValues{Int16}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<short?> SelectMany(AnyElement<short?> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="int" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />
        ///, for example "dbo.AccessAuditLog.Id"
        ///</param>
        /// <returns><see cref="SelectValues{Int32}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<int> SelectMany(AnyElement<int> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="int" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />?
        ///, for example "dbo.:column.Entity.Name}.CreditLimit"
        ///</param>
        /// <returns><see cref="SelectValues{Int32}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<int?> SelectMany(AnyElement<int?> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="long" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />
        ///, for example "unit_test.ExpressionElementType.Int64" or "db.fx.IsNull(unit_test.ExpressionElementType.Int64, long.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValues{Int64}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<long> SelectMany(AnyElement<long> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="long" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />?
        ///, for example "unit_test.ExpressionElementType.NullableInt64"
        ///</param>
        /// <returns><see cref="SelectValues{Int64}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<long?> SelectMany(AnyElement<long?> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="float" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />
        ///, for example "unit_test.ExpressionElementType.Single" or "db.fx.IsNull(unit_test.ExpressionElementType.Single, float.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValues{Single}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<float> SelectMany(AnyElement<float> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="float" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />?
        ///, for example "unit_test.ExpressionElementType.NullableSingle"
        ///</param>
        /// <returns><see cref="SelectValues{Single}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<float?> SelectMany(AnyElement<float?> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="string" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />?
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        ///</param>
        /// <returns><see cref="SelectValues{String}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<string> SelectMany(StringElement element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="string" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />?
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        ///</param>
        /// <returns><see cref="SelectValues{String}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<string?> SelectMany(NullableStringElement element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="TimeSpan" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />
        ///, for example "unit_test.ExpressionElementType.TimeSpan", "db.fx.IsNull(unit_test.ExpressionElementType.TimeSpan, TimeSpan.MinValue)" or "unit_test.ExpressionElementType.TimeSpan + DateTime.Now"
        ///</param>
        /// <returns><see cref="SelectValues{TimeSpan}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<TimeSpan> SelectMany(AnyElement<TimeSpan> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="TimeSpan" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />?
        ///, for example "dbo.Product.ValidStartTimeOfDayForPurchase"
        ///</param>
        /// <returns><see cref="SelectValues{TimeSpan}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<TimeSpan?> SelectMany(AnyElement<TimeSpan?> element)
            => MsSqlDb.SelectMany(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="element2">Any expression</param>
        /// <param name="elements">Any expression</param>
        /// <returns><see cref="SelectDynamics"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectDynamics SelectMany(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => MsSqlDb.SelectMany(element1, element2, elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression</param>
        /// <returns><see cref="SelectDynamics"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectDynamics SelectMany(IEnumerable<AnyElement> elements)
            => MsSqlDb.SelectMany(elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression that is valid for a SELECT query expression.</param>
        /// <param name="additionalElements">Any additional fields to select as part of the SELECT query expression.</param>
        /// <returns><see cref="SelectDynamics"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectDynamics SelectMany(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
            => MsSqlDb.SelectMany((elements ?? throw new ArgumentNullException(nameof(elements))).Concat(additionalElements));
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
        /// <returns><see cref="UpdateEntities"/>, a fluent builder for constructing a sql UPDATE statement.</returns>
        public static UpdateEntities Update(EntityFieldAssignment assignment, params EntityFieldAssignment[] assignments)
            => MsSqlDb.Update(assignment, assignments);

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
        /// <returns><see cref="UpdateEntities"/>, a fluent builder for constructing a sql UPDATE statement.</returns>
        public static UpdateEntities Update(IEnumerable<EntityFieldAssignment> assignments)
            => MsSqlDb.Update(assignments);   
        #endregion

        #region delete
        /// <summary>
        /// Start constructing a sql DELETE query expression to remove records.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/delete-transact-sql">Microsoft docs on DELETE</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="DeleteEntities"/>, a fluent builder for constructing a sql DELETE statement.</returns>
        public static DeleteEntities Delete()
            => MsSqlDb.Delete();
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
        /// <returns><see cref="InsertEntity{TEntity}"/>, a fluent builder for constructing a sql INSERT statement.</returns>
        /// <typeparam name="TEntity">The entity type of the entity to insert.</typeparam>
        public static InsertEntity<TEntity> Insert<TEntity>(TEntity entity)
            where TEntity : class, IDbEntity
            => MsSqlDb.Insert<TEntity>(entity);

        /// <summary>
        /// Start constructing a sql INSERT query expression to insert one or more record.  The property values from each <paramref name="entities"/> entity instance are used to create the new record values for the INSERT statement.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/insert-transact-sql">Microsoft docs on INSERT</see>
        /// </para>
        /// </summary>
        /// <param name="entities">A list of entities.
        /// </param>
        /// <returns><see cref="InsertEntities{TEntity}"/>, a fluent builder for constructing a sql INSERT statement.</returns>
        /// <typeparam name="TEntity">The entity type of the entities to insert.</typeparam>
        public static InsertEntities<TEntity> InsertMany<TEntity>(TEntity entity, params TEntity[] entities)
            where TEntity : class, IDbEntity
            => MsSqlDb.InsertMany<TEntity>(entity, entities);

        /// <summary>
        /// Start constructing a sql INSERT query expression to insert one or more record.  The property values from each <paramref name="entities"/> entity instance are used to create the new record values for the INSERT statement.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/insert-transact-sql">Microsoft docs on INSERT</see>
        /// </para>
        /// </summary>
        /// <param name="entities">A list of entities.
        /// </param>
        /// <returns><see cref="InsertEntities{TEntity}"/>, a fluent builder for constructing a sql INSERT statement.</returns>
        /// <typeparam name="TEntity">The entity type of the entities to insert.</typeparam>
        public static InsertEntities<TEntity> InsertMany<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IDbEntity
            => MsSqlDb.InsertMany<TEntity>(entities);
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
            => MsSqlDb.GetConnection();
        #endregion

        #endregion
    }
    #endregion

    #region MsSqlDb
    public class MsSqlDb : ISqlDatabaseRuntime, 
        SelectOneInitiation, 
        SelectManyInitiation,
        UpdateEntitiesInitiation,
        DeleteEntitiesInitiation,
        InsertEntitiesInitiation
    {
        #region internals
        private static readonly SqlDatabaseMetadataProvider _metadata = new SqlDatabaseMetadataProvider(new MsSqlDbSqlDatabaseMetadata("MsSqlDb"));
        private static readonly MsSqlFunctionExpressionBuilder _fx = new MsSqlFunctionExpressionBuilder();
        private static readonly List<SchemaExpression> _schemas = new List<SchemaExpression>();
        private static readonly Dictionary<Type, Table> _entityTypeToTableMap = new Dictionary<Type, Table>();
        private readonly IQueryExpressionBuilderFactory _queryExpressionBuilderFactory;
        private readonly ISqlConnectionFactory _connectionFactory;
        private MsSqlDbStoredProcedures? _sp;
        #endregion

        #region interface
        ISqlDatabaseMetadataProvider ISqlDatabaseRuntime.MetadataProvider => _metadata;
        public MsSqlFunctionExpressionBuilder fx => _fx;
        public MsSqlDbStoredProcedures sp => _sp ?? (_sp = new MsSqlDbStoredProcedures(this, _schemas));
        #endregion

        #region constructors
        static MsSqlDb()
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

            var unit_testSchema = new _unit_testDataService.unit_testSchemaExpression("unit_test");
            _schemas.Add(unit_testSchema);
            _unit_testDataService.unit_test.UseSchema(unit_testSchema);
            _entityTypeToTableMap.Add(typeof(unit_testData.alias), unit_testSchema.alias);
            _entityTypeToTableMap.Add(typeof(unit_testData.entity), unit_testSchema.entity);
            _entityTypeToTableMap.Add(typeof(unit_testData.ExpressionElementType), unit_testSchema.ExpressionElementType);
            _entityTypeToTableMap.Add(typeof(unit_testData.identifier), unit_testSchema.identifier);
            _entityTypeToTableMap.Add(typeof(unit_testData.name), unit_testSchema.name);
            _entityTypeToTableMap.Add(typeof(unit_testData.schema), unit_testSchema.schema);

            var secSchema = new _secDataService.secSchemaExpression("sec");
            _schemas.Add(secSchema);
            _secDataService.sec.UseSchema(secSchema);
            _entityTypeToTableMap.Add(typeof(secData.Person), secSchema.Person);

        }

        public MsSqlDb(
            IQueryExpressionBuilderFactory queryExpressionBuilderFactory,
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

        protected IQueryExpressionBuilder GetBuilder()
            => _queryExpressionBuilderFactory.CreateQueryExpressionBuilder();

        #region select one
        /// <summary>
        /// Start constructing a sql SELECT query expression for a single entity.
        /// <para>
        /// To retrieve a <see cref="DbEx.dboData.AccessAuditLog" />, use a type param of <see cref="DbEx.dboData.AccessAuditLog" />
        /// </para>
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectEntity{TEntity}"/>, a fluent builder for constructing a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        /// <typeparam name="TEntity">The entity type to select.</typeparam>
        public SelectEntity<TEntity> SelectOne<TEntity>()
            where TEntity : class, IDbEntity, new()
            => GetBuilder().CreateSelectEntityBuilder<TEntity>(GetTable<TEntity>());

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="TEnum"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />
        ///, for example "dbo.Person.GenderType"
        /// </param>
        /// <returns><see cref="Sql.SelectValue{TEnum}"/>, a fluent builder for constructing a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        /// <typeparam name="TEnum">The type of the Enum to select.</typeparam>
        public SelectValue<TEnum> SelectOne<TEnum>(AnyElement<TEnum> element)
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
        /// <returns><see cref="SelectValue{TEnum}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="TEnum">The type of the Enum to select.</typeparam>
        public SelectValue<TEnum?> SelectOne<TEnum>(AnyElement<TEnum?> element)
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
        /// <returns><see cref="SelectValue{object}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<object>? SelectOne(ObjectElement element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="object"/>? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValue{object}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<object?> SelectOne(NullableObjectElement element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="T"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement{T}" />
        /// </param>
        /// <returns><see cref="SelectValues{T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the object to select.</typeparam>
        public SelectObject<T> SelectOne<T>(ObjectElement<T> element)
            where T : class?
            => GetBuilder().CreateSelectValueBuilder<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="T"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AliasedElement{T}" />    
        /// </param>
        /// <returns><see cref="SelectValue{T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<T> SelectOne<T>(AliasedElement<T> element)
            => GetBuilder().CreateSelectValueBuilder<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="bool" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        ///, for example "unit_test.ExpressionElementType.Boolean" or "db.fx.IsNull(unit_test.ExpressionElementType.Boolean, false)
        /// </param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<bool> SelectOne(AnyElement<bool> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="bool" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />?
        ///, for example "unit_test.ExpressionElementType.NullableBoolean""
        /// </param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<bool?> SelectOne(AnyElement<bool?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />
        ///, for example "unit_test.ExpressionElementType.Byte" or "db.fx.IsNull(unit_test.ExpressionElementType.Byte, byte.MinValue)"
        /// </param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<byte> SelectOne(AnyElement<byte> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />?
        ///, for example "unit_test.ExpressionElementType.NullableByte"
        /// </param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<byte?> SelectOne(AnyElement<byte?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" />[] value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte[]}" />
        /// </param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<byte[]> SelectOne(AnyElement<byte[]> element)
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
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<DateTime> SelectOne(AnyElement<DateTime> element)
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
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<DateTime?> SelectOne(AnyElement<DateTime?> field)
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
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<DateTimeOffset> SelectOne(AnyElement<DateTimeOffset> element)
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
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<DateTimeOffset?> SelectOne(AnyElement<DateTimeOffset?> element)
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
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<decimal> SelectOne(AnyElement<decimal> element)
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
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<decimal?> SelectOne(AnyElement<decimal?> element)
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
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<double> SelectOne(AnyElement<double> element)
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
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<double?> SelectOne(AnyElement<double?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="Guid" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />
        ///, for example "unit_test.ExpressionElementType.Guid" or "db.fx.IsNull(unit_test.ExpressionElementType.Guid, Guid.Empty)"
        /// </param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<Guid> SelectOne(AnyElement<Guid> element)
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
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<Guid?> SelectOne(AnyElement<Guid?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="short" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />
        ///, for example "unit_test.ExpressionElementType.Int16" or "db.fx.IsNull(unit_test.ExpressionElementType.Int16, short.MinValue)"
        /// </param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<short> SelectOne(AnyElement<short> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="short" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />?
        ///, for example "unit_test.ExpressionElementType.NullableInt16" or "db.fx.Max(unit_test.ExpressionElementType.NullableInt16)"
        /// </param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<short?> SelectOne(AnyElement<short?> element)
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
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<int> SelectOne(AnyElement<int> element)
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
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<int?> SelectOne(AnyElement<int?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="long" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />
        ///, for example "unit_test.ExpressionElementType.Int64" or "db.fx.IsNull(unit_test.ExpressionElementType.Int64, long.MinValue)"
        /// </param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<long> SelectOne(AnyElement<long> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="long" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />?
        ///, for example "unit_test.ExpressionElementType.NullableInt64" or "db.fx.Max(unit_test.ExpressionElementType.NullableInt64)"
        /// </param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<long?> SelectOne(AnyElement<long?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="float" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />
        ///, for example "unit_test.ExpressionElementType.Single" or "db.fx.IsNull(unit_test.ExpressionElementType.Single, float.MinValue)"
        /// </param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<float> SelectOne(AnyElement<float> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="float" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />?
        ///, for example "unit_test.ExpressionElementType.NullableSingle" or "db.fx.Max(unit_test.ExpressionElementType.NullableSingle)"
        /// </param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<float?> SelectOne(AnyElement<float?> element)
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="string" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />?
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        /// </param>
        /// <returns><see cref="SelectValue{String}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<string> SelectOne(StringElement element) 
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="string" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />?
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        /// </param>
        /// <returns><see cref="SelectValue{String}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<string?> SelectOne(NullableStringElement element) 
            => GetBuilder().CreateSelectValueBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="TimeSpan" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />
        ///, for example "unit_test.ExpressionElementType.TimeSpan", "db.fx.IsNull(unit_test.ExpressionElementType.TimeSpan, TimeSpan.MinValue)" or "unit_test.ExpressionElementType.TimeSpan + DateTime.Now"
        /// </param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<TimeSpan> SelectOne(AnyElement<TimeSpan> element)
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
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValue<TimeSpan?> SelectOne(AnyElement<TimeSpan?> element)
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
        /// <returns><see cref="SelectDynamic "/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectDynamic SelectOne(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => GetBuilder().CreateSelectDynamicBuilder(element1, element2, elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="elements">A list of any expression</param>
        /// <returns><see cref="SelectDynamic "/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectDynamic SelectOne(IEnumerable<AnyElement> elements)
            => GetBuilder().CreateSelectDynamicBuilder(elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression that is valid for a SELECT query expression.</param>
        /// <param name="additionalElements">Any additional fields to select as part of the SELECT query expression.</param>
        /// <returns><see cref="SelectDynamic "/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectDynamic SelectOne(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
            => GetBuilder().CreateSelectDynamicBuilder((elements ?? throw new ArgumentNullException(nameof(elements))).Concat(additionalElements));
        #endregion

        #region select many
        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of entities.
        /// <para>
        /// To retrieve a list of <see cref="DbEx.dboData.AccessAuditLog" />(s), use a type param of <see cref="DbEx.dboData.AccessAuditLog" />
        /// </para>
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectEntities{TEntity}"/>, a fluent builder for constructing a sql SELECT query expression for a list of <typeparamref name="TEntity"/> entities.</returns>
        /// <typeparam name="TEntity">The entity type to select.</typeparam>
        public SelectEntities<TEntity> SelectMany<TEntity>()
           where TEntity : class, IDbEntity, new()
           => GetBuilder().CreateSelectEntitiesBuilder<TEntity>(GetTable<TEntity>());

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="TEnum"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />
        ///, for example "dbo.Person.GenderType"
        /// </param>
        /// <returns><see cref="SelectValues{TEnum}"/>, a fluent builder for constructing a sql SELECT query expression for a list of <typeparamref name="TEntity"/> entities.</returns>
        public SelectValues<TEnum> SelectMany<TEnum>(AnyElement<TEnum> element)
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
        /// <returns><see cref="SelectValues{TEnum}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<TEnum?> SelectMany<TEnum>(AnyElement<TEnum?> element)
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
        /// <returns><see cref="SelectValues{object}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<object>? SelectMany(ObjectElement element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="object"/>? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableObjectElement" />
        /// </param>
        /// <returns><see cref="SelectValues{object}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<object?> SelectMany(NullableObjectElement element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="T"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="ObjectElement{T}" />
        /// </param>
        /// <returns><see cref="SelectValues{T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        /// <typeparam name="T">The type of the object to select.</typeparam>
        public SelectObjects<T> SelectMany<T>(ObjectElement<T> element)
            where T : class?
            => GetBuilder().CreateSelectValuesBuilder<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="T"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AliasedElement{T}" />    
        /// </param>
        /// <returns><see cref="SelectValues{T}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<T> SelectMany<T>(AliasedElement<T> element)
            => GetBuilder().CreateSelectValuesBuilder<T>(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="bool" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        ///, for example "unit_test.ExpressionElementType.Boolean" or "db.fx.IsNull(unit_test.ExpressionElementType.Boolean, false)
        /// </param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<bool> SelectMany(AnyElement<bool> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="bool" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />?
        ///, for example "unit_test.ExpressionElementType.NullableBoolean""
        /// </param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<bool?> SelectMany(AnyElement<bool?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />
        ///, for example "unit_test.ExpressionElementType.Byte" or "db.fx.IsNull(unit_test.ExpressionElementType.Byte, byte.MinValue)"
        /// </param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<byte> SelectMany(AnyElement<byte> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />?
        ///, for example "unit_test.ExpressionElementType.NullableByte"
        /// </param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<byte?> SelectMany(AnyElement<byte?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" />[] values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte[]}" />
        /// </param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<byte[]> SelectMany(AnyElement<byte[]> element)
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
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<DateTime> SelectMany(AnyElement<DateTime> element)
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
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<DateTime?> SelectMany(AnyElement<DateTime?> element)
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
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<DateTimeOffset> SelectMany(AnyElement<DateTimeOffset> element)
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
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<DateTimeOffset?> SelectMany(AnyElement<DateTimeOffset?> element)
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
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<decimal> SelectMany(AnyElement<decimal> element)
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
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<decimal?> SelectMany(AnyElement<decimal?> element)
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
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<double> SelectMany(AnyElement<double> element)
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
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<double?> SelectMany(AnyElement<double?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="Guid" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />
        ///, for example "unit_test.ExpressionElementType.Guid" or "db.fx.IsNull(unit_test.ExpressionElementType.Guid, Guid.Empty)"
        /// </param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<Guid> SelectMany(AnyElement<Guid> element)
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
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<Guid?> SelectMany(AnyElement<Guid?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="short" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />
        ///, for example "unit_test.ExpressionElementType.Int16" or "db.fx.IsNull(unit_test.ExpressionElementType.Int16, short.MinValue)"
        /// </param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<short> SelectMany(AnyElement<short> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="short" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />?
        ///, for example "unit_test.ExpressionElementType.NullableInt16"
        /// </param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<short?> SelectMany(AnyElement<short?> element)
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
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<int> SelectMany(AnyElement<int> element)
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
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<int?> SelectMany(AnyElement<int?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="long" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />
        ///, for example "unit_test.ExpressionElementType.Int64" or "db.fx.IsNull(unit_test.ExpressionElementType.Int64, long.MinValue)"
        /// </param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<long> SelectMany(AnyElement<long> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="long" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />?
        ///, for example "unit_test.ExpressionElementType.NullableInt64"
        /// </param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<long?> SelectMany(AnyElement<long?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="float" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />
        ///, for example "unit_test.ExpressionElementType.Single" or "db.fx.IsNull(unit_test.ExpressionElementType.Single, float.MinValue)"
        /// </param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<float> SelectMany(AnyElement<float> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="float" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />?
        ///, for example "unit_test.ExpressionElementType.NullableSingle"
        /// </param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<float?> SelectMany(AnyElement<float?> element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="string" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />?
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        /// </param>
        /// <returns><see cref="SelectValues{String}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<string> SelectMany(StringElement element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="string" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />?
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        /// </param>
        /// <returns><see cref="SelectValues{String}"/>?, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<string?> SelectMany(NullableStringElement element)
            => GetBuilder().CreateSelectValuesBuilder(element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="TimeSpan" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />
        ///, for example "unit_test.ExpressionElementType.TimeSpan", "db.fx.IsNull(unit_test.ExpressionElementType.TimeSpan, TimeSpan.MinValue)" or "unit_test.ExpressionElementType.TimeSpan + DateTime.Now"
        /// </param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<TimeSpan> SelectMany(AnyElement<TimeSpan> element)
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
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectValues<TimeSpan?> SelectMany(AnyElement<TimeSpan?> element)
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
        /// <returns><see cref="SelectDynamics "/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectDynamics SelectMany(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => GetBuilder().CreateSelectDynamicsBuilder(element1, element2, elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression</param>
        /// <returns><see cref="SelectDynamics "/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectDynamics SelectMany(IEnumerable<AnyElement> elements)
            => GetBuilder().CreateSelectDynamicsBuilder(elements);

            /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression that is valid for a SELECT query expression.</param>
        /// <param name="additionalElements">Any additional fields to select as part of the SELECT query expression.</param>
        /// <returns><see cref="SelectDynamics "/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public SelectDynamics SelectMany(IEnumerable<AnyElement> elements, params AnyElement[] additionalElements)
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
        /// <returns><see cref="UpdateEntities "/>, a fluent builder for constructing a sql UPDATE statement.</returns>
        public UpdateEntities Update(EntityFieldAssignment assignment, params EntityFieldAssignment[] assignments)
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
        /// <returns><see cref="UpdateEntities "/>, a fluent builder for constructing a sql UPDATE statement.</returns>
        public UpdateEntities Update(IEnumerable<EntityFieldAssignment> assignments)
            => GetBuilder().CreateUpdateExpressionBuilder(assignments);   
        #endregion

        #region delete
        /// <summary>
        /// Start constructing a sql DELETE query expression to remove records.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/delete-transact-sql">Microsoft docs on DELETE</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="DeleteEntities "/>, a fluent builder for constructing a sql DELETE statement.</returns>
        public DeleteEntities Delete()
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
        /// <returns><see cref="InsertEntity{TEntity}"/>, a fluent builder for constructing a sql INSERT statement.</returns>
        /// <typeparam name="TEntity">The entity type of the entity to insert.</typeparam>
        public InsertEntity<TEntity> Insert<TEntity>(TEntity entity)
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
        /// <returns><see cref="InsertEntities{TEntity}"/>, a fluent builder for constructing a sql INSERT statement.</returns>
        /// <typeparam name="TEntity">The entity type of the entities to insert.</typeparam>
        public InsertEntities<TEntity> InsertMany<TEntity>(TEntity entity, params TEntity[] entities)
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
        /// <returns><see cref="InsertEntities{TEntity}"/>, a fluent builder for constructing a sql INSERT statement.</returns>
        /// <typeparam name="TEntity">The entity type of the entities to insert.</typeparam>
        public InsertEntities<TEntity> InsertMany<TEntity>(IEnumerable<TEntity> entities)
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
        public class MsSqlDbStoredProcedures
        {
            #region internals
            private readonly dboStoredProcedures _dboStoredProcedures;
            private readonly unit_testStoredProcedures _unit_testStoredProcedures;
            private readonly secStoredProcedures _secStoredProcedures;
            #endregion

            #region interface
            /// <summary>
            /// Accessors to construct and execute stored procedure query expressions in the dbo schema.
            /// </summary>
            public dboStoredProcedures dbo => _dboStoredProcedures;

            /// <summary>
            /// Accessors to construct and execute stored procedure query expressions in the unit_test schema.
            /// </summary>
            public unit_testStoredProcedures unit_test => _unit_testStoredProcedures;

            /// <summary>
            /// Accessors to construct and execute stored procedure query expressions in the sec schema.
            /// </summary>
            public secStoredProcedures sec => _secStoredProcedures;

            #endregion

            #region constructors
            public MsSqlDbStoredProcedures(MsSqlDb database, IEnumerable<SchemaExpression> schemas)
            {
                if (database is null)
                    throw new ArgumentNullException(nameof(database));
                _dboStoredProcedures = new dboStoredProcedures(database, schemas.Single(s => s.Identifier == "dbo"));
                _unit_testStoredProcedures = new unit_testStoredProcedures(database, schemas.Single(s => s.Identifier == "unit_test"));
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
            private readonly MsSqlDb _database;
            private readonly SchemaExpression _dbo;
            #endregion

            #region constructors
            public dboStoredProcedures(MsSqlDb database, SchemaExpression schema)
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
            public StoredProcedureContinuation SelectPerson_As_Dynamic_With_Input(int? P1)
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
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation SelectPerson_As_Dynamic_With_Input_And_InputOutput(int? P1,int? CreditLimit, Action<ISqlOutputParameterList> outputParameters)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPerson_As_Dynamic_With_Input_And_InputOutputStoredProcedure("dbo", _dbo, P1, CreditLimit, outputParameters));

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
            public StoredProcedureContinuation SelectPerson_As_Dynamic_With_Input_And_Output(int? P1, Action<ISqlOutputParameterList> outputParameters)
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
            public StoredProcedureContinuation SelectPerson_As_DynamicList_With_Input(int? P1)
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
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation SelectPerson_As_DynamicList_With_Input_And_InputOutput(int? P1,int? CreditLimit, Action<ISqlOutputParameterList> outputParameters)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPerson_As_DynamicList_With_Input_And_InputOutputStoredProcedure("dbo", _dbo, P1, CreditLimit, outputParameters));

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
            public StoredProcedureContinuation SelectPerson_As_DynamicList_With_Input_And_Output(int? P1, Action<ISqlOutputParameterList> outputParameters)
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
            public StoredProcedureContinuation SelectPersonId_As_ScalarValue_With_Input(int? P1)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPersonId_As_ScalarValue_With_InputStoredProcedure("dbo", _dbo, P1));

            /// <summary>
            /// Method to start constructing a stored procedure query expression for the SelectPersonId_As_ScalarValue_With_Input_And_Default_Value stored procedure.
            /// </summary>
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation SelectPersonId_As_ScalarValue_With_Input_And_Default_Value()
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPersonId_As_ScalarValue_With_Input_And_Default_ValueStoredProcedure("dbo", _dbo));

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
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation SelectPersonId_As_ScalarValue_With_Input_And_InputOutput(int? P1,int? CreditLimit, Action<ISqlOutputParameterList> outputParameters)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPersonId_As_ScalarValue_With_Input_And_InputOutputStoredProcedure("dbo", _dbo, P1, CreditLimit, outputParameters));

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
            public StoredProcedureContinuation SelectPersonId_As_ScalarValue_With_Input_And_Output(int? P1, Action<ISqlOutputParameterList> outputParameters)
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
            public StoredProcedureContinuation SelectPersonId_As_ScalarValueList_With_Input(int? P1)
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
            /// <returns><see cref="StoredProcedureContinuation"/>, a fluent builder for constructing a stored procedure query expression.</returns>
            public StoredProcedureContinuation SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput(int? P1,int? CreditLimit, Action<ISqlOutputParameterList> outputParameters)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new SelectPersonId_As_ScalarValueList_With_Input_And_InputOutputStoredProcedure("dbo", _dbo, P1, CreditLimit, outputParameters));

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
            public StoredProcedureContinuation SelectPersonId_As_ScalarValueList_With_Input_And_Output(int? P1, Action<ISqlOutputParameterList> outputParameters)
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
            public StoredProcedureContinuation UpdatePersonCreditLimit_With_Inputs(int? P1,int? CreditLimit)
                => _database.GetBuilder().CreateStoredProcedureBuilder(new UpdatePersonCreditLimit_With_InputsStoredProcedure("dbo", _dbo, P1, CreditLimit));

            #endregion
        }

        /// <summary>
        /// Accessors to construct and execute stored procedure query expressions in the unit_test schema.
        /// </summary>
        public class unit_testStoredProcedures
        {
            #region internals
            private readonly MsSqlDb _database;
            private readonly SchemaExpression _unit_test;
            #endregion

            #region constructors
            public unit_testStoredProcedures(MsSqlDb database, SchemaExpression schema)
            {
                _database = database ?? throw new ArgumentNullException(nameof(database));
                _unit_test = schema ?? throw new ArgumentNullException(nameof(schema));
            }
            #endregion

            #region methods
            #endregion
        }

        /// <summary>
        /// Accessors to construct and execute stored procedure query expressions in the sec schema.
        /// </summary>
        public class secStoredProcedures
        {
            #region internals
            private readonly MsSqlDb _database;
            private readonly SchemaExpression _sec;
            #endregion

            #region constructors
            public secStoredProcedures(MsSqlDb database, SchemaExpression schema)
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

namespace DbEx.dboDataService
{
	using DbEx.dboData;
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
            Attributes.Entities.Add($"{identifier}.PersonAddress", PersonAddress = new PersonAddressEntity($"{identifier}.PersonAddress", "PersonAddress", this));
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
        private SelectExpressionSet? _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="DbEx.dboDataService.AccessAuditLogEntity.IdField"/> representing the "dbo.AccessAuditLog.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.AccessAuditLogEntity.IdField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.AccessAuditLogEntity.PersonIdField"/> representing the "dbo.AccessAuditLog.PersonId" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.AccessAuditLogEntity.PersonIdField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.AccessAuditLogEntity.AccessResultField"/> representing the "dbo.AccessAuditLog.AccessResult" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.AccessAuditLogEntity.AccessResultField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
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


        /// <summary>A <see cref="DbEx.dboDataService.AccessAuditLogEntity.DateCreatedField"/> representing the "dbo.AccessAuditLog.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.dboDataService.AccessAuditLogEntity.DateCreatedField"/> can be 
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

        private AccessAuditLogEntity(string identifier, string name, Schema schema, string? alias) : base(identifier, name, schema, alias)
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
                ,new SelectExpression<int>(AccessResult)
                ,new SelectExpression<DateTime>(DateCreated)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet? set = null;
            string? aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Id));

            aliased = alias(nameof(PersonId));
            set &= aliased != nameof(PersonId) ? new SelectExpression<int>(PersonId, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(PersonId));

            aliased = alias(nameof(AccessResult));
            set &= aliased != nameof(AccessResult) ? new SelectExpression<int>(AccessResult, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(AccessResult));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateCreated));

            return set;
        }
		
        protected override InsertExpressionSet<AccessAuditLog> GetInclusiveInsertExpression(AccessAuditLog entity)
        {
            return new InsertExpressionSet<AccessAuditLog>(entity 
                ,new InsertExpression<int>(entity.PersonId, PersonId)
                ,new InsertExpression<int>(entity.AccessResult, AccessResult)
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
            entity.Id = reader.ReadField()!.GetValue<int>();
            entity.PersonId = reader.ReadField()!.GetValue<int>();
            entity.AccessResult = reader.ReadField()!.GetValue<int>();
            entity.DateCreated = reader.ReadField()!.GetValue<DateTime>();
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
        public partial class AccessResultField : Int32FieldExpression<AccessAuditLog>
        {
            #region constructors
            public AccessResultField(string identifier, string name, Table entity) : base(identifier, name, entity)
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
        private SelectExpressionSet? _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="DbEx.dboDataService.AddressEntity.IdField"/> representing the "dbo.Address.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.AddressEntity.IdField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.AddressEntity.AddressTypeField"/> representing the "dbo.Address.AddressType" column in the database, 
        /// with a .NET type of <see cref="DbEx.Data.AddressType"/>?.  The <see cref="DbEx.dboDataService.AddressEntity.AddressTypeField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DbEx.Data.AddressType}"/>?.
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


        /// <summary>A <see cref="DbEx.dboDataService.AddressEntity.Line1Field"/> representing the "dbo.Address.Line1" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="DbEx.dboDataService.AddressEntity.Line1Field"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.AddressEntity.Line2Field"/> representing the "dbo.Address.Line2" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.dboDataService.AddressEntity.Line2Field"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.AddressEntity.CityField"/> representing the "dbo.Address.City" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="DbEx.dboDataService.AddressEntity.CityField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.AddressEntity.StateField"/> representing the "dbo.Address.State" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="DbEx.dboDataService.AddressEntity.StateField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.AddressEntity.ZipField"/> representing the "dbo.Address.Zip" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="DbEx.dboDataService.AddressEntity.ZipField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.AddressEntity.DateCreatedField"/> representing the "dbo.Address.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.dboDataService.AddressEntity.DateCreatedField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.AddressEntity.DateUpdatedField"/> representing the "dbo.Address.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.dboDataService.AddressEntity.DateUpdatedField"/> can be 
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

        private AddressEntity(string identifier, string name, Schema schema, string? alias) : base(identifier, name, schema, alias)
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
                ,new SelectExpression<DbEx.Data.AddressType?>(AddressType)
                ,new SelectExpression<string>(Line1)
                ,new SelectExpression<string?>(Line2)
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

            SelectExpressionSet? set = null;
            string? aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Id));

            aliased = alias(nameof(AddressType));
            set &= aliased != nameof(AddressType) ? new SelectExpression<DbEx.Data.AddressType?>(AddressType, aliased) as SelectExpression<DbEx.Data.AddressType?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(AddressType));

            aliased = alias(nameof(Line1));
            set &= aliased != nameof(Line1) ? new SelectExpression<string>(Line1, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Line1));

            aliased = alias(nameof(Line2));
            set &= aliased != nameof(Line2) ? new SelectExpression<string?>(Line2, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Line2));

            aliased = alias(nameof(City));
            set &= aliased != nameof(City) ? new SelectExpression<string>(City, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(City));

            aliased = alias(nameof(State));
            set &= aliased != nameof(State) ? new SelectExpression<string>(State, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(State));

            aliased = alias(nameof(Zip));
            set &= aliased != nameof(Zip) ? new SelectExpression<string>(Zip, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Zip));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<Address> GetInclusiveInsertExpression(Address entity)
        {
            return new InsertExpressionSet<Address>(entity 
                ,new InsertExpression<DbEx.Data.AddressType?>(entity.AddressType, AddressType)
                ,new InsertExpression<string>(entity.Line1, Line1)
                ,new InsertExpression<string?>(entity.Line2, Line2)
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
            entity.Id = reader.ReadField()!.GetValue<int>();
            entity.AddressType = reader.ReadField()!.GetValue<DbEx.Data.AddressType?>();
            entity.Line1 = reader.ReadField()!.GetValue<string>();
            entity.Line2 = reader.ReadField()!.GetValue<string?>();
            entity.City = reader.ReadField()!.GetValue<string>();
            entity.State = reader.ReadField()!.GetValue<string>();
            entity.Zip = reader.ReadField()!.GetValue<string>();
            entity.DateCreated = reader.ReadField()!.GetValue<DateTime>();
            entity.DateUpdated = reader.ReadField()!.GetValue<DateTime>();
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
        public partial class AddressTypeField : NullableEnumFieldExpression<Address,DbEx.Data.AddressType>
        {
            #region constructors
            public AddressTypeField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DbEx.Data.AddressType?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<DbEx.Data.AddressType?>(value, this));
            public AssignmentExpression Set(DbEx.Data.AddressType value) => new AssignmentExpression(this, new LiteralExpression<DbEx.Data.AddressType>(value, this));
            public AssignmentExpression Set(AnyElement<DbEx.Data.AddressType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DbEx.Data.AddressType? value) => new AssignmentExpression(this, new LiteralExpression<DbEx.Data.AddressType?>(value, this));
            public AssignmentExpression Set(AnyElement<DbEx.Data.AddressType?> value) => new AssignmentExpression(this, value);
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
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
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
        private SelectExpressionSet? _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="DbEx.dboDataService.PersonEntity.IdField"/> representing the "dbo.Person.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.PersonEntity.IdField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PersonEntity.FirstNameField"/> representing the "dbo.Person.FirstName" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="DbEx.dboDataService.PersonEntity.FirstNameField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PersonEntity.LastNameField"/> representing the "dbo.Person.LastName" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="DbEx.dboDataService.PersonEntity.LastNameField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PersonEntity.BirthDateField"/> representing the "dbo.Person.BirthDate" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>?.  The <see cref="DbEx.dboDataService.PersonEntity.BirthDateField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PersonEntity.GenderTypeField"/> representing the "dbo.Person.GenderType" column in the database, 
        /// with a .NET type of <see cref="DbEx.Data.GenderType"/>.  The <see cref="DbEx.dboDataService.PersonEntity.GenderTypeField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DbEx.Data.GenderType}"/>.
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


        /// <summary>A <see cref="DbEx.dboDataService.PersonEntity.CreditLimitField"/> representing the "dbo.Person.CreditLimit" column in the database, 
        /// with a .NET type of <see cref="int"/>?.  The <see cref="DbEx.dboDataService.PersonEntity.CreditLimitField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PersonEntity.YearOfLastCreditLimitReviewField"/> representing the "dbo.Person.YearOfLastCreditLimitReview" column in the database, 
        /// with a .NET type of <see cref="int"/>?.  The <see cref="DbEx.dboDataService.PersonEntity.YearOfLastCreditLimitReviewField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PersonEntity.RegistrationDateField"/> representing the "dbo.Person.RegistrationDate" column in the database, 
        /// with a .NET type of <see cref="DateTimeOffset"/>.  The <see cref="DbEx.dboDataService.PersonEntity.RegistrationDateField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PersonEntity.LastLoginDateField"/> representing the "dbo.Person.LastLoginDate" column in the database, 
        /// with a .NET type of <see cref="DateTimeOffset"/>?.  The <see cref="DbEx.dboDataService.PersonEntity.LastLoginDateField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PersonEntity.DateCreatedField"/> representing the "dbo.Person.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.dboDataService.PersonEntity.DateCreatedField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PersonEntity.DateUpdatedField"/> representing the "dbo.Person.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.dboDataService.PersonEntity.DateUpdatedField"/> can be 
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

        private PersonEntity(string identifier, string name, Schema schema, string? alias) : base(identifier, name, schema, alias)
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
                ,new SelectExpression<DbEx.Data.GenderType>(GenderType)
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

            SelectExpressionSet? set = null;
            string? aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Id));

            aliased = alias(nameof(FirstName));
            set &= aliased != nameof(FirstName) ? new SelectExpression<string>(FirstName, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(FirstName));

            aliased = alias(nameof(LastName));
            set &= aliased != nameof(LastName) ? new SelectExpression<string>(LastName, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(LastName));

            aliased = alias(nameof(BirthDate));
            set &= aliased != nameof(BirthDate) ? new SelectExpression<DateTime?>(BirthDate, aliased) as SelectExpression<DateTime?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(BirthDate));

            aliased = alias(nameof(GenderType));
            set &= aliased != nameof(GenderType) ? new SelectExpression<DbEx.Data.GenderType>(GenderType, aliased) as SelectExpression<DbEx.Data.GenderType> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(GenderType));

            aliased = alias(nameof(CreditLimit));
            set &= aliased != nameof(CreditLimit) ? new SelectExpression<int?>(CreditLimit, aliased) as SelectExpression<int?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(CreditLimit));

            aliased = alias(nameof(YearOfLastCreditLimitReview));
            set &= aliased != nameof(YearOfLastCreditLimitReview) ? new SelectExpression<int?>(YearOfLastCreditLimitReview, aliased) as SelectExpression<int?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(YearOfLastCreditLimitReview));

            aliased = alias(nameof(RegistrationDate));
            set &= aliased != nameof(RegistrationDate) ? new SelectExpression<DateTimeOffset>(RegistrationDate, aliased) as SelectExpression<DateTimeOffset> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(RegistrationDate));

            aliased = alias(nameof(LastLoginDate));
            set &= aliased != nameof(LastLoginDate) ? new SelectExpression<DateTimeOffset?>(LastLoginDate, aliased) as SelectExpression<DateTimeOffset?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(LastLoginDate));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<Person> GetInclusiveInsertExpression(Person entity)
        {
            return new InsertExpressionSet<Person>(entity 
                ,new InsertExpression<string>(entity.FirstName, FirstName)
                ,new InsertExpression<string>(entity.LastName, LastName)
                ,new InsertExpression<DateTime?>(entity.BirthDate, BirthDate)
                ,new InsertExpression<DbEx.Data.GenderType>(entity.GenderType, GenderType)
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
            entity.Id = reader.ReadField()!.GetValue<int>();
            entity.FirstName = reader.ReadField()!.GetValue<string>();
            entity.LastName = reader.ReadField()!.GetValue<string>();
            entity.BirthDate = reader.ReadField()!.GetValue<DateTime?>();
            entity.GenderType = reader.ReadField()!.GetValue<DbEx.Data.GenderType>();
            entity.CreditLimit = reader.ReadField()!.GetValue<int?>();
            entity.YearOfLastCreditLimitReview = reader.ReadField()!.GetValue<int?>();
            entity.RegistrationDate = reader.ReadField()!.GetValue<DateTimeOffset>();
            entity.LastLoginDate = reader.ReadField()!.GetValue<DateTimeOffset?>();
            entity.DateCreated = reader.ReadField()!.GetValue<DateTime>();
            entity.DateUpdated = reader.ReadField()!.GetValue<DateTime>();
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
        public partial class GenderTypeField : EnumFieldExpression<Person,DbEx.Data.GenderType>
        {
            #region constructors
            public GenderTypeField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DbEx.Data.GenderType>(value));
            public AssignmentExpression Set(DbEx.Data.GenderType value) => new AssignmentExpression(this, new LiteralExpression<DbEx.Data.GenderType>(value, this));
            public AssignmentExpression Set(AnyElement<DbEx.Data.GenderType> value) => new AssignmentExpression(this, value);
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
        private SelectExpressionSet? _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="DbEx.dboDataService.PersonAddressEntity.IdField"/> representing the "dbo.Person_Address.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.PersonAddressEntity.IdField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PersonAddressEntity.PersonIdField"/> representing the "dbo.Person_Address.PersonId" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.PersonAddressEntity.PersonIdField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PersonAddressEntity.AddressIdField"/> representing the "dbo.Person_Address.AddressId" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.PersonAddressEntity.AddressIdField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PersonAddressEntity.DateCreatedField"/> representing the "dbo.Person_Address.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.dboDataService.PersonAddressEntity.DateCreatedField"/> can be 
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

        private PersonAddressEntity(string identifier, string name, Schema schema, string? alias) : base(identifier, name, schema, alias)
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

            SelectExpressionSet? set = null;
            string? aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Id));

            aliased = alias(nameof(PersonId));
            set &= aliased != nameof(PersonId) ? new SelectExpression<int>(PersonId, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(PersonId));

            aliased = alias(nameof(AddressId));
            set &= aliased != nameof(AddressId) ? new SelectExpression<int>(AddressId, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(AddressId));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateCreated));

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
            entity.Id = reader.ReadField()!.GetValue<int>();
            entity.PersonId = reader.ReadField()!.GetValue<int>();
            entity.AddressId = reader.ReadField()!.GetValue<int>();
            entity.DateCreated = reader.ReadField()!.GetValue<DateTime>();
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
        private SelectExpressionSet? _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.IdField"/> representing the "dbo.Product.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.ProductEntity.IdField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.ProductCategoryTypeField"/> representing the "dbo.Product.ProductCategoryType" column in the database, 
        /// with a .NET type of <see cref="DbEx.Data.ProductCategoryType"/>?.  The <see cref="DbEx.dboDataService.ProductEntity.ProductCategoryTypeField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DbEx.Data.ProductCategoryType}"/>?.
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.NameField"/> representing the "dbo.Product.Name" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="DbEx.dboDataService.ProductEntity.NameField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.DescriptionField"/> representing the "dbo.Product.Description" column in the database, 
        /// with a .NET type of <see cref="HatTrick.DbEx.MsSql.Test.ProductDescription"/>?.  The <see cref="DbEx.dboDataService.ProductEntity.DescriptionField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{HatTrick.DbEx.MsSql.Test.ProductDescription}"/>?.
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.ListPriceField"/> representing the "dbo.Product.ListPrice" column in the database, 
        /// with a .NET type of <see cref="double"/>.  The <see cref="DbEx.dboDataService.ProductEntity.ListPriceField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.PriceField"/> representing the "dbo.Product.Price" column in the database, 
        /// with a .NET type of <see cref="double"/>.  The <see cref="DbEx.dboDataService.ProductEntity.PriceField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.QuantityField"/> representing the "dbo.Product.Quantity" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.ProductEntity.QuantityField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.ImageField"/> representing the "dbo.Product.Image" column in the database, 
        /// with a .NET type of <see cref="byte"/>[].  The <see cref="DbEx.dboDataService.ProductEntity.ImageField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.HeightField"/> representing the "dbo.Product.Height" column in the database, 
        /// with a .NET type of <see cref="decimal"/>?.  The <see cref="DbEx.dboDataService.ProductEntity.HeightField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.WidthField"/> representing the "dbo.Product.Width" column in the database, 
        /// with a .NET type of <see cref="decimal"/>?.  The <see cref="DbEx.dboDataService.ProductEntity.WidthField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.DepthField"/> representing the "dbo.Product.Depth" column in the database, 
        /// with a .NET type of <see cref="decimal"/>?.  The <see cref="DbEx.dboDataService.ProductEntity.DepthField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.WeightField"/> representing the "dbo.Product.Weight" column in the database, 
        /// with a .NET type of <see cref="decimal"/>?.  The <see cref="DbEx.dboDataService.ProductEntity.WeightField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.ShippingWeightField"/> representing the "dbo.Product.ShippingWeight" column in the database, 
        /// with a .NET type of <see cref="decimal"/>.  The <see cref="DbEx.dboDataService.ProductEntity.ShippingWeightField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.ValidStartTimeOfDayForPurchaseField"/> representing the "dbo.Product.ValidStartTimeOfDayForPurchase" column in the database, 
        /// with a .NET type of <see cref="TimeSpan"/>?.  The <see cref="DbEx.dboDataService.ProductEntity.ValidStartTimeOfDayForPurchaseField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.ValidEndTimeOfDayForPurchaseField"/> representing the "dbo.Product.ValidEndTimeOfDayForPurchase" column in the database, 
        /// with a .NET type of <see cref="TimeSpan"/>?.  The <see cref="DbEx.dboDataService.ProductEntity.ValidEndTimeOfDayForPurchaseField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.DateCreatedField"/> representing the "dbo.Product.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.dboDataService.ProductEntity.DateCreatedField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity.DateUpdatedField"/> representing the "dbo.Product.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.dboDataService.ProductEntity.DateUpdatedField"/> can be 
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

        private ProductEntity(string identifier, string name, Schema schema, string? alias) : base(identifier, name, schema, alias)
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
                ,new SelectExpression<DbEx.Data.ProductCategoryType?>(ProductCategoryType)
                ,new SelectExpression<string>(Name)
                ,new SelectExpression<HatTrick.DbEx.MsSql.Test.ProductDescription?>(Description)
                ,new SelectExpression<double>(ListPrice)
                ,new SelectExpression<double>(Price)
                ,new SelectExpression<int>(Quantity)
                ,new SelectExpression<byte[]?>(Image)
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

            SelectExpressionSet? set = null;
            string? aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Id));

            aliased = alias(nameof(ProductCategoryType));
            set &= aliased != nameof(ProductCategoryType) ? new SelectExpression<DbEx.Data.ProductCategoryType?>(ProductCategoryType, aliased) as SelectExpression<DbEx.Data.ProductCategoryType?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(ProductCategoryType));

            aliased = alias(nameof(Name));
            set &= aliased != nameof(Name) ? new SelectExpression<string>(Name, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Name));

            aliased = alias(nameof(Description));
            set &= aliased != nameof(Description) ? new SelectExpression<HatTrick.DbEx.MsSql.Test.ProductDescription?>(Description, aliased) as SelectExpression<HatTrick.DbEx.MsSql.Test.ProductDescription?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Description));

            aliased = alias(nameof(ListPrice));
            set &= aliased != nameof(ListPrice) ? new SelectExpression<double>(ListPrice, aliased) as SelectExpression<double> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(ListPrice));

            aliased = alias(nameof(Price));
            set &= aliased != nameof(Price) ? new SelectExpression<double>(Price, aliased) as SelectExpression<double> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Price));

            aliased = alias(nameof(Quantity));
            set &= aliased != nameof(Quantity) ? new SelectExpression<int>(Quantity, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Quantity));

            aliased = alias(nameof(Image));
            set &= aliased != nameof(Image) ? new SelectExpression<byte[]?>(Image, aliased) as SelectExpression<byte[]?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Image));

            aliased = alias(nameof(Height));
            set &= aliased != nameof(Height) ? new SelectExpression<decimal?>(Height, aliased) as SelectExpression<decimal?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Height));

            aliased = alias(nameof(Width));
            set &= aliased != nameof(Width) ? new SelectExpression<decimal?>(Width, aliased) as SelectExpression<decimal?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Width));

            aliased = alias(nameof(Depth));
            set &= aliased != nameof(Depth) ? new SelectExpression<decimal?>(Depth, aliased) as SelectExpression<decimal?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Depth));

            aliased = alias(nameof(Weight));
            set &= aliased != nameof(Weight) ? new SelectExpression<decimal?>(Weight, aliased) as SelectExpression<decimal?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Weight));

            aliased = alias(nameof(ShippingWeight));
            set &= aliased != nameof(ShippingWeight) ? new SelectExpression<decimal>(ShippingWeight, aliased) as SelectExpression<decimal> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(ShippingWeight));

            aliased = alias(nameof(ValidStartTimeOfDayForPurchase));
            set &= aliased != nameof(ValidStartTimeOfDayForPurchase) ? new SelectExpression<TimeSpan?>(ValidStartTimeOfDayForPurchase, aliased) as SelectExpression<TimeSpan?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(ValidStartTimeOfDayForPurchase));

            aliased = alias(nameof(ValidEndTimeOfDayForPurchase));
            set &= aliased != nameof(ValidEndTimeOfDayForPurchase) ? new SelectExpression<TimeSpan?>(ValidEndTimeOfDayForPurchase, aliased) as SelectExpression<TimeSpan?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(ValidEndTimeOfDayForPurchase));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<Product> GetInclusiveInsertExpression(Product entity)
        {
            return new InsertExpressionSet<Product>(entity 
                ,new InsertExpression<DbEx.Data.ProductCategoryType?>(entity.ProductCategoryType, ProductCategoryType)
                ,new InsertExpression<string>(entity.Name, Name)
                ,new InsertExpression<HatTrick.DbEx.MsSql.Test.ProductDescription?>(entity.Description, Description)
                ,new InsertExpression<double>(entity.ListPrice, ListPrice)
                ,new InsertExpression<double>(entity.Price, Price)
                ,new InsertExpression<int>(entity.Quantity, Quantity)
                ,new InsertExpression<byte[]?>(entity.Image, Image)
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
            entity.Id = reader.ReadField()!.GetValue<int>();
            entity.ProductCategoryType = reader.ReadField()!.GetValue<DbEx.Data.ProductCategoryType?>();
            entity.Name = reader.ReadField()!.GetValue<string>();
            entity.Description = reader.ReadField()!.GetValue<HatTrick.DbEx.MsSql.Test.ProductDescription?>();
            entity.ListPrice = reader.ReadField()!.GetValue<double>();
            entity.Price = reader.ReadField()!.GetValue<double>();
            entity.Quantity = reader.ReadField()!.GetValue<int>();
            entity.Image = reader.ReadField()!.GetValue<byte[]?>();
            entity.Height = reader.ReadField()!.GetValue<decimal?>();
            entity.Width = reader.ReadField()!.GetValue<decimal?>();
            entity.Depth = reader.ReadField()!.GetValue<decimal?>();
            entity.Weight = reader.ReadField()!.GetValue<decimal?>();
            entity.ShippingWeight = reader.ReadField()!.GetValue<decimal>();
            entity.ValidStartTimeOfDayForPurchase = reader.ReadField()!.GetValue<TimeSpan?>();
            entity.ValidEndTimeOfDayForPurchase = reader.ReadField()!.GetValue<TimeSpan?>();
            entity.DateCreated = reader.ReadField()!.GetValue<DateTime>();
            entity.DateUpdated = reader.ReadField()!.GetValue<DateTime>();
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
        public partial class ProductCategoryTypeField : NullableEnumFieldExpression<Product,DbEx.Data.ProductCategoryType>
        {
            #region constructors
            public ProductCategoryTypeField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DbEx.Data.ProductCategoryType?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<DbEx.Data.ProductCategoryType?>(value, this));
            public AssignmentExpression Set(DbEx.Data.ProductCategoryType value) => new AssignmentExpression(this, new LiteralExpression<DbEx.Data.ProductCategoryType>(value, this));
            public AssignmentExpression Set(AnyElement<DbEx.Data.ProductCategoryType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DbEx.Data.ProductCategoryType? value) => new AssignmentExpression(this, new LiteralExpression<DbEx.Data.ProductCategoryType?>(value, this));
            public AssignmentExpression Set(AnyElement<DbEx.Data.ProductCategoryType?> value) => new AssignmentExpression(this, value);
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
        public partial class DescriptionField : ObjectFieldExpression<Product,HatTrick.DbEx.MsSql.Test.ProductDescription?>
        {
            #region constructors
            public DescriptionField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<HatTrick.DbEx.MsSql.Test.ProductDescription?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<HatTrick.DbEx.MsSql.Test.ProductDescription?>(value, this));
            public AssignmentExpression Set(HatTrick.DbEx.MsSql.Test.ProductDescription? value) => new AssignmentExpression(this, new LiteralExpression<HatTrick.DbEx.MsSql.Test.ProductDescription?>(value, this));
            public AssignmentExpression Set(AnyElement<HatTrick.DbEx.MsSql.Test.ProductDescription?> value) => new AssignmentExpression(this, value);
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
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<byte[]?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<byte[]?>(value, this));
            public AssignmentExpression Set(byte[]? value) => new AssignmentExpression(this, new LiteralExpression<byte[]?>(value, this));
            public AssignmentExpression Set(AnyElement<byte[]?> value) => new AssignmentExpression(this, value);
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
        private SelectExpressionSet? _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="DbEx.dboDataService.PurchaseEntity.IdField"/> representing the "dbo.Purchase.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.PurchaseEntity.IdField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseEntity.PersonIdField"/> representing the "dbo.Purchase.PersonId" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.PurchaseEntity.PersonIdField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseEntity.OrderNumberField"/> representing the "dbo.Purchase.OrderNumber" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="DbEx.dboDataService.PurchaseEntity.OrderNumberField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseEntity.TotalPurchaseQuantityField"/> representing the "dbo.Purchase.TotalPurchaseQuantity" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="DbEx.dboDataService.PurchaseEntity.TotalPurchaseQuantityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>.
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseEntity.TotalPurchaseAmountField"/> representing the "dbo.Purchase.TotalPurchaseAmount" column in the database, 
        /// with a .NET type of <see cref="double"/>.  The <see cref="DbEx.dboDataService.PurchaseEntity.TotalPurchaseAmountField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseEntity.PurchaseDateField"/> representing the "dbo.Purchase.PurchaseDate" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.dboDataService.PurchaseEntity.PurchaseDateField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseEntity.ShipDateField"/> representing the "dbo.Purchase.ShipDate" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>?.  The <see cref="DbEx.dboDataService.PurchaseEntity.ShipDateField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseEntity.ExpectedDeliveryDateField"/> representing the "dbo.Purchase.ExpectedDeliveryDate" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>?.  The <see cref="DbEx.dboDataService.PurchaseEntity.ExpectedDeliveryDateField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseEntity.TrackingIdentifierField"/> representing the "dbo.Purchase.TrackingIdentifier" column in the database, 
        /// with a .NET type of <see cref="Guid"/>?.  The <see cref="DbEx.dboDataService.PurchaseEntity.TrackingIdentifierField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseEntity.PaymentMethodTypeField"/> representing the "dbo.Purchase.PaymentMethodType" column in the database, 
        /// with a .NET type of <see cref="DbEx.Data.PaymentMethodType"/>.  The <see cref="DbEx.dboDataService.PurchaseEntity.PaymentMethodTypeField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DbEx.Data.PaymentMethodType}"/>.
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseEntity.PaymentSourceTypeField"/> representing the "dbo.Purchase.PaymentSourceType" column in the database, 
        /// with a .NET type of <see cref="DbEx.Data.PaymentSourceType"/>?.  The <see cref="DbEx.dboDataService.PurchaseEntity.PaymentSourceTypeField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DbEx.Data.PaymentSourceType}"/>?.
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseEntity.DateCreatedField"/> representing the "dbo.Purchase.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.dboDataService.PurchaseEntity.DateCreatedField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseEntity.DateUpdatedField"/> representing the "dbo.Purchase.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.dboDataService.PurchaseEntity.DateUpdatedField"/> can be 
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

        private PurchaseEntity(string identifier, string name, Schema schema, string? alias) : base(identifier, name, schema, alias)
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
                ,new SelectExpression<string>(TotalPurchaseQuantity)
                ,new SelectExpression<double>(TotalPurchaseAmount)
                ,new SelectExpression<DateTime>(PurchaseDate)
                ,new SelectExpression<DateTime?>(ShipDate)
                ,new SelectExpression<DateTime?>(ExpectedDeliveryDate)
                ,new SelectExpression<Guid?>(TrackingIdentifier)
                ,new SelectExpression<DbEx.Data.PaymentMethodType>(PaymentMethodType)
                ,new SelectExpression<DbEx.Data.PaymentSourceType?>(PaymentSourceType)
                ,new SelectExpression<DateTime>(DateCreated)
                ,new SelectExpression<DateTime>(DateUpdated)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet? set = null;
            string? aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Id));

            aliased = alias(nameof(PersonId));
            set &= aliased != nameof(PersonId) ? new SelectExpression<int>(PersonId, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(PersonId));

            aliased = alias(nameof(OrderNumber));
            set &= aliased != nameof(OrderNumber) ? new SelectExpression<string>(OrderNumber, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(OrderNumber));

            aliased = alias(nameof(TotalPurchaseQuantity));
            set &= aliased != nameof(TotalPurchaseQuantity) ? new SelectExpression<string>(TotalPurchaseQuantity, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(TotalPurchaseQuantity));

            aliased = alias(nameof(TotalPurchaseAmount));
            set &= aliased != nameof(TotalPurchaseAmount) ? new SelectExpression<double>(TotalPurchaseAmount, aliased) as SelectExpression<double> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(TotalPurchaseAmount));

            aliased = alias(nameof(PurchaseDate));
            set &= aliased != nameof(PurchaseDate) ? new SelectExpression<DateTime>(PurchaseDate, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(PurchaseDate));

            aliased = alias(nameof(ShipDate));
            set &= aliased != nameof(ShipDate) ? new SelectExpression<DateTime?>(ShipDate, aliased) as SelectExpression<DateTime?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(ShipDate));

            aliased = alias(nameof(ExpectedDeliveryDate));
            set &= aliased != nameof(ExpectedDeliveryDate) ? new SelectExpression<DateTime?>(ExpectedDeliveryDate, aliased) as SelectExpression<DateTime?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(ExpectedDeliveryDate));

            aliased = alias(nameof(TrackingIdentifier));
            set &= aliased != nameof(TrackingIdentifier) ? new SelectExpression<Guid?>(TrackingIdentifier, aliased) as SelectExpression<Guid?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(TrackingIdentifier));

            aliased = alias(nameof(PaymentMethodType));
            set &= aliased != nameof(PaymentMethodType) ? new SelectExpression<DbEx.Data.PaymentMethodType>(PaymentMethodType, aliased) as SelectExpression<DbEx.Data.PaymentMethodType> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(PaymentMethodType));

            aliased = alias(nameof(PaymentSourceType));
            set &= aliased != nameof(PaymentSourceType) ? new SelectExpression<DbEx.Data.PaymentSourceType?>(PaymentSourceType, aliased) as SelectExpression<DbEx.Data.PaymentSourceType?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(PaymentSourceType));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<Purchase> GetInclusiveInsertExpression(Purchase entity)
        {
            return new InsertExpressionSet<Purchase>(entity 
                ,new InsertExpression<int>(entity.PersonId, PersonId)
                ,new InsertExpression<string>(entity.OrderNumber, OrderNumber)
                ,new InsertExpression<string>(entity.TotalPurchaseQuantity, TotalPurchaseQuantity)
                ,new InsertExpression<double>(entity.TotalPurchaseAmount, TotalPurchaseAmount)
                ,new InsertExpression<DateTime>(entity.PurchaseDate, PurchaseDate)
                ,new InsertExpression<DateTime?>(entity.ShipDate, ShipDate)
                ,new InsertExpression<DateTime?>(entity.ExpectedDeliveryDate, ExpectedDeliveryDate)
                ,new InsertExpression<Guid?>(entity.TrackingIdentifier, TrackingIdentifier)
                ,new InsertExpression<DbEx.Data.PaymentMethodType>(entity.PaymentMethodType, PaymentMethodType)
                ,new InsertExpression<DbEx.Data.PaymentSourceType?>(entity.PaymentSourceType, PaymentSourceType)
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
            entity.Id = reader.ReadField()!.GetValue<int>();
            entity.PersonId = reader.ReadField()!.GetValue<int>();
            entity.OrderNumber = reader.ReadField()!.GetValue<string>();
            entity.TotalPurchaseQuantity = reader.ReadField()!.GetValue<string>();
            entity.TotalPurchaseAmount = reader.ReadField()!.GetValue<double>();
            entity.PurchaseDate = reader.ReadField()!.GetValue<DateTime>();
            entity.ShipDate = reader.ReadField()!.GetValue<DateTime?>();
            entity.ExpectedDeliveryDate = reader.ReadField()!.GetValue<DateTime?>();
            entity.TrackingIdentifier = reader.ReadField()!.GetValue<Guid?>();
            entity.PaymentMethodType = reader.ReadField()!.GetValue<DbEx.Data.PaymentMethodType>();
            entity.PaymentSourceType = reader.ReadField()!.GetValue<DbEx.Data.PaymentSourceType?>();
            entity.DateCreated = reader.ReadField()!.GetValue<DateTime>();
            entity.DateUpdated = reader.ReadField()!.GetValue<DateTime>();
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
        public partial class TotalPurchaseQuantityField : StringFieldExpression<Purchase>
        {
            #region constructors
            public TotalPurchaseQuantityField(string identifier, string name, Table entity) : base(identifier, name, entity)
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
        public partial class PaymentMethodTypeField : EnumFieldExpression<Purchase,DbEx.Data.PaymentMethodType>
        {
            #region constructors
            public PaymentMethodTypeField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DbEx.Data.PaymentMethodType>(value));
            public AssignmentExpression Set(DbEx.Data.PaymentMethodType value) => new AssignmentExpression(this, new LiteralExpression<DbEx.Data.PaymentMethodType>(value, this));
            public AssignmentExpression Set(AnyElement<DbEx.Data.PaymentMethodType> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region payment source type field expression
        public partial class PaymentSourceTypeField : NullableEnumFieldExpression<Purchase,DbEx.Data.PaymentSourceType>
        {
            #region constructors
            public PaymentSourceTypeField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<DbEx.Data.PaymentSourceType?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<DbEx.Data.PaymentSourceType?>(value, this));
            public AssignmentExpression Set(DbEx.Data.PaymentSourceType value) => new AssignmentExpression(this, new LiteralExpression<DbEx.Data.PaymentSourceType>(value, this));
            public AssignmentExpression Set(AnyElement<DbEx.Data.PaymentSourceType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DbEx.Data.PaymentSourceType? value) => new AssignmentExpression(this, new LiteralExpression<DbEx.Data.PaymentSourceType?>(value, this));
            public AssignmentExpression Set(AnyElement<DbEx.Data.PaymentSourceType?> value) => new AssignmentExpression(this, value);
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
        private SelectExpressionSet? _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="DbEx.dboDataService.PurchaseLineEntity.IdField"/> representing the "dbo.PurchaseLine.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.PurchaseLineEntity.IdField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseLineEntity.PurchaseIdField"/> representing the "dbo.PurchaseLine.PurchaseId" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.PurchaseLineEntity.PurchaseIdField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseLineEntity.ProductIdField"/> representing the "dbo.PurchaseLine.ProductId" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.PurchaseLineEntity.ProductIdField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseLineEntity.PurchasePriceField"/> representing the "dbo.PurchaseLine.PurchasePrice" column in the database, 
        /// with a .NET type of <see cref="decimal"/>.  The <see cref="DbEx.dboDataService.PurchaseLineEntity.PurchasePriceField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseLineEntity.QuantityField"/> representing the "dbo.PurchaseLine.Quantity" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.PurchaseLineEntity.QuantityField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseLineEntity.DateCreatedField"/> representing the "dbo.PurchaseLine.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.dboDataService.PurchaseLineEntity.DateCreatedField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PurchaseLineEntity.DateUpdatedField"/> representing the "dbo.PurchaseLine.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.dboDataService.PurchaseLineEntity.DateUpdatedField"/> can be 
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

        private PurchaseLineEntity(string identifier, string name, Schema schema, string? alias) : base(identifier, name, schema, alias)
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

            SelectExpressionSet? set = null;
            string? aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Id));

            aliased = alias(nameof(PurchaseId));
            set &= aliased != nameof(PurchaseId) ? new SelectExpression<int>(PurchaseId, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(PurchaseId));

            aliased = alias(nameof(ProductId));
            set &= aliased != nameof(ProductId) ? new SelectExpression<int>(ProductId, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(ProductId));

            aliased = alias(nameof(PurchasePrice));
            set &= aliased != nameof(PurchasePrice) ? new SelectExpression<decimal>(PurchasePrice, aliased) as SelectExpression<decimal> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(PurchasePrice));

            aliased = alias(nameof(Quantity));
            set &= aliased != nameof(Quantity) ? new SelectExpression<int>(Quantity, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Quantity));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateUpdated));

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
            entity.Id = reader.ReadField()!.GetValue<int>();
            entity.PurchaseId = reader.ReadField()!.GetValue<int>();
            entity.ProductId = reader.ReadField()!.GetValue<int>();
            entity.PurchasePrice = reader.ReadField()!.GetValue<decimal>();
            entity.Quantity = reader.ReadField()!.GetValue<int>();
            entity.DateCreated = reader.ReadField()!.GetValue<DateTime>();
            entity.DateUpdated = reader.ReadField()!.GetValue<DateTime>();
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
        private SelectExpressionSet? _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="DbEx.dboDataService.PersonTotalPurchasesViewEntity.IdField"/> representing the "dbo.PersonTotalPurchasesView.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.dboDataService.PersonTotalPurchasesViewEntity.IdField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PersonTotalPurchasesViewEntity.TotalAmountField"/> representing the "dbo.PersonTotalPurchasesView.TotalAmount" column in the database, 
        /// with a .NET type of <see cref="double"/>?.  The <see cref="DbEx.dboDataService.PersonTotalPurchasesViewEntity.TotalAmountField"/> can be 
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


        /// <summary>A <see cref="DbEx.dboDataService.PersonTotalPurchasesViewEntity.TotalCountField"/> representing the "dbo.PersonTotalPurchasesView.TotalCount" column in the database, 
        /// with a .NET type of <see cref="int"/>?.  The <see cref="DbEx.dboDataService.PersonTotalPurchasesViewEntity.TotalCountField"/> can be 
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

        private PersonTotalPurchasesViewEntity(string identifier, string name, Schema schema, string? alias) : base(identifier, name, schema, alias)
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

            SelectExpressionSet? set = null;
            string? aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Id));

            aliased = alias(nameof(TotalAmount));
            set &= aliased != nameof(TotalAmount) ? new SelectExpression<double?>(TotalAmount, aliased) as SelectExpression<double?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(TotalAmount));

            aliased = alias(nameof(TotalCount));
            set &= aliased != nameof(TotalCount) ? new SelectExpression<int?>(TotalCount, aliased) as SelectExpression<int?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(TotalCount));

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
            entity.Id = reader.ReadField()!.GetValue<int>();
            entity.TotalAmount = reader.ReadField()!.GetValue<double?>();
            entity.TotalCount = reader.ReadField()!.GetValue<int?>();
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
            ,int? CreditLimit
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base($"{identifier}.SelectPerson_As_Dynamic_With_Input_And_InputOutput", "SelectPerson_As_Dynamic_With_Input_And_InputOutput", schema, outputParameters)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPerson_As_Dynamic_With_Input_And_InputOutput.@P1", "P1", P1, ParameterDirection.Input));
            Attributes.Parameters.Add("CreditLimit", new ParameterExpression<int?>($"{identifier}.SelectPerson_As_Dynamic_With_Input_And_InputOutput.@CreditLimit", "CreditLimit", CreditLimit, ParameterDirection.InputOutput));
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
            ,int? CreditLimit
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base($"{identifier}.SelectPerson_As_DynamicList_With_Input_And_InputOutput", "SelectPerson_As_DynamicList_With_Input_And_InputOutput", schema, outputParameters)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPerson_As_DynamicList_With_Input_And_InputOutput.@P1", "P1", P1, ParameterDirection.Input));
            Attributes.Parameters.Add("CreditLimit", new ParameterExpression<int?>($"{identifier}.SelectPerson_As_DynamicList_With_Input_And_InputOutput.@CreditLimit", "CreditLimit", CreditLimit, ParameterDirection.InputOutput));
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
        ) : base($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_Default_Value", "SelectPersonId_As_ScalarValue_With_Input_And_Default_Value", schema)
        { 
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
            ,int? CreditLimit
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput", "SelectPersonId_As_ScalarValue_With_Input_And_InputOutput", schema, outputParameters)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput.@P1", "P1", P1, ParameterDirection.Input));
            Attributes.Parameters.Add("CreditLimit", new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput.@CreditLimit", "CreditLimit", CreditLimit, ParameterDirection.InputOutput));
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
            ,int? CreditLimit
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput", "SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput", schema, outputParameters)
        { 
            Attributes.Parameters.Add("P1", new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput.@P1", "P1", P1, ParameterDirection.Input));
            Attributes.Parameters.Add("CreditLimit", new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput.@CreditLimit", "CreditLimit", CreditLimit, ParameterDirection.InputOutput));
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
        private static dboSchemaExpression? schema;

        #region interface
        /// <summary>A <see cref="DbEx.dboDataService.AccessAuditLogEntity"/> representing the "dbo.AccessAuditLog" table in the database.
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
        public static AccessAuditLogEntity AccessAuditLog { get; private set; } = null!;

        /// <summary>A <see cref="DbEx.dboDataService.AddressEntity"/> representing the "dbo.Address" table in the database.
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
        public static AddressEntity Address { get; private set; } = null!;

        /// <summary>A <see cref="DbEx.dboDataService.PersonEntity"/> representing the "dbo.Person" table in the database.
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
        public static PersonEntity Person { get; private set; } = null!;

        /// <summary>A <see cref="DbEx.dboDataService.PersonAddressEntity"/> representing the "dbo.Person_Address" table in the database.
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
        public static PersonAddressEntity PersonAddress { get; private set; } = null!;

        /// <summary>A <see cref="DbEx.dboDataService.ProductEntity"/> representing the "dbo.Product" table in the database.
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
        public static ProductEntity Product { get; private set; } = null!;

        /// <summary>A <see cref="DbEx.dboDataService.PurchaseEntity"/> representing the "dbo.Purchase" table in the database.
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
        public static PurchaseEntity Purchase { get; private set; } = null!;

        /// <summary>A <see cref="DbEx.dboDataService.PurchaseLineEntity"/> representing the "dbo.PurchaseLine" table in the database.
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
        public static PurchaseLineEntity PurchaseLine { get; private set; } = null!;

        /// <summary>A <see cref="DbEx.dboDataService.PersonTotalPurchasesViewEntity"/> representing the "dbo.PersonTotalPurchasesView" view in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>PersonTotalPurchasesView</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public static PersonTotalPurchasesViewEntity PersonTotalPurchasesView { get; private set; } = null!;

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

namespace DbEx.unit_testDataService
{
	using DbEx.unit_testData;
	using System.Data;

    #region unit_test schema expression
    public class unit_testSchemaExpression : SchemaExpression
    {
        #region interface
        public readonly aliasEntity alias;
        public readonly entityEntity entity;
        public readonly ExpressionElementTypeEntity ExpressionElementType;
        public readonly identifierEntity identifier;
        public readonly nameEntity name;
        public readonly schemaEntity schema;
        #endregion

        #region constructors
        public unit_testSchemaExpression(string _identifier) : base(_identifier)
        {
            Attributes.Entities.Add($"{identifier}.alias", alias = new aliasEntity($"{_identifier}.alias", "alias", this));
            Attributes.Entities.Add($"{identifier}.entity", entity = new entityEntity($"{_identifier}.entity", "entity", this));
            Attributes.Entities.Add($"{identifier}.ExpressionElementType", ExpressionElementType = new ExpressionElementTypeEntity($"{_identifier}.ExpressionElementType", "ExpressionElementType", this));
            Attributes.Entities.Add($"{identifier}.identifier", identifier = new identifierEntity($"{_identifier}.identifier", "identifier", this));
            Attributes.Entities.Add($"{identifier}.name", name = new nameEntity($"{_identifier}.name", "name", this));
            Attributes.Entities.Add($"{identifier}.schema", schema = new schemaEntity($"{_identifier}.schema", "schema", this));
        }
        #endregion
    }
    #endregion

    #region alias entity expression
    public partial class aliasEntity : EntityExpression<alias>
    {
        #region internals
        private SelectExpressionSet? _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="DbEx.unit_testDataService.aliasEntity.identifierField"/> representing the "unit_test.alias.identifier" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.aliasEntity.identifierField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>identifier</description>
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
        public readonly identifierField identifier;


        /// <summary>A <see cref="DbEx.unit_testDataService.aliasEntity._identifierField"/> representing the "unit_test.alias._identifier" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.aliasEntity._identifierField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_identifier</description>
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
        public readonly _identifierField _identifier;


        /// <summary>A <see cref="DbEx.unit_testDataService.aliasEntity.__identifierField"/> representing the "unit_test.alias.__identifier" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.aliasEntity.__identifierField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__identifier</description>
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
        public readonly __identifierField __identifier;


        /// <summary>A <see cref="DbEx.unit_testDataService.aliasEntity.nameField"/> representing the "unit_test.alias.name" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.aliasEntity.nameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>name</description>
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
        public readonly nameField name;


        /// <summary>A <see cref="DbEx.unit_testDataService.aliasEntity._nameField"/> representing the "unit_test.alias._name" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.aliasEntity._nameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_name</description>
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
        public readonly _nameField _name;


        /// <summary>A <see cref="DbEx.unit_testDataService.aliasEntity.__nameField"/> representing the "unit_test.alias.__name" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.aliasEntity.__nameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__name</description>
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
        public readonly __nameField __name;


        /// <summary>A <see cref="DbEx.unit_testDataService.aliasEntity.schemaField"/> representing the "unit_test.alias.schema" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.aliasEntity.schemaField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>schema</description>
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
        public readonly schemaField schema;


        /// <summary>A <see cref="DbEx.unit_testDataService.aliasEntity._schemaField"/> representing the "unit_test.alias._schema" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.aliasEntity._schemaField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_schema</description>
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
        public readonly _schemaField _schema;


        /// <summary>A <see cref="DbEx.unit_testDataService.aliasEntity.__schemaField"/> representing the "unit_test.alias.__schema" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.aliasEntity.__schemaField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__schema</description>
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
        public readonly __schemaField __schema;


        /// <summary>A <see cref="DbEx.unit_testDataService.aliasEntity._aliasField"/> representing the "unit_test.alias._alias" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.aliasEntity._aliasField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_alias</description>
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
        public readonly _aliasField _alias;


        /// <summary>A <see cref="DbEx.unit_testDataService.aliasEntity.__aliasField"/> representing the "unit_test.alias.__alias" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.aliasEntity.__aliasField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__alias</description>
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
        public readonly __aliasField __alias;


        /// <summary>A <see cref="DbEx.unit_testDataService.aliasEntity.entityField"/> representing the "unit_test.alias.entity" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.aliasEntity.entityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>entity</description>
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
        public readonly entityField entity;


        /// <summary>A <see cref="DbEx.unit_testDataService.aliasEntity._entityField"/> representing the "unit_test.alias._entity" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.aliasEntity._entityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_entity</description>
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
        public readonly _entityField _entity;


        /// <summary>A <see cref="DbEx.unit_testDataService.aliasEntity.__entityField"/> representing the "unit_test.alias.__entity" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.aliasEntity.__entityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__entity</description>
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
        public readonly __entityField __entity;

        #endregion

        #region constructors
        public aliasEntity(string ___identifier, string ___name, Schema ___schema) : this(___identifier, ___name, ___schema, null)
        {
        }

        private aliasEntity(string ___identifier, string ___name, Schema ___schema, string? alias) : base(___identifier, ___name, ___schema, alias)
        {
            Attributes.Fields.Add($"{identifier}.identifier", identifier = new identifierField($"{___identifier}.identifier", "identifier", this));
            Attributes.Fields.Add($"{identifier}._identifier", _identifier = new _identifierField($"{___identifier}._identifier", "_identifier", this));
            Attributes.Fields.Add($"{identifier}.__identifier", __identifier = new __identifierField($"{___identifier}.__identifier", "__identifier", this));
            Attributes.Fields.Add($"{identifier}.name", name = new nameField($"{___identifier}.name", "name", this));
            Attributes.Fields.Add($"{identifier}._name", _name = new _nameField($"{___identifier}._name", "_name", this));
            Attributes.Fields.Add($"{identifier}.__name", __name = new __nameField($"{___identifier}.__name", "__name", this));
            Attributes.Fields.Add($"{identifier}.schema", schema = new schemaField($"{___identifier}.schema", "schema", this));
            Attributes.Fields.Add($"{identifier}._schema", _schema = new _schemaField($"{___identifier}._schema", "_schema", this));
            Attributes.Fields.Add($"{identifier}.__schema", __schema = new __schemaField($"{___identifier}.__schema", "__schema", this));
            Attributes.Fields.Add($"{identifier}._alias", _alias = new _aliasField($"{___identifier}._alias", "_alias", this));
            Attributes.Fields.Add($"{identifier}.__alias", __alias = new __aliasField($"{___identifier}.__alias", "__alias", this));
            Attributes.Fields.Add($"{identifier}.entity", entity = new entityField($"{___identifier}.entity", "entity", this));
            Attributes.Fields.Add($"{identifier}._entity", _entity = new _entityField($"{___identifier}._entity", "_entity", this));
            Attributes.Fields.Add($"{identifier}.__entity", __entity = new __entityField($"{___identifier}.__entity", "__entity", this));
        }
        #endregion

        #region methods
        public aliasEntity As(string alias)
            => new aliasEntity(this.Attributes.Identifier, this.Attributes.Name, this.Attributes.Schema, alias);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return _inclusiveSelectExpressionSet ?? (_inclusiveSelectExpressionSet = new SelectExpressionSet(
                new SelectExpression<string?>(identifier)
                ,new SelectExpression<string?>(_identifier)
                ,new SelectExpression<string?>(__identifier)
                ,new SelectExpression<string?>(name)
                ,new SelectExpression<string?>(_name)
                ,new SelectExpression<string?>(__name)
                ,new SelectExpression<string?>(schema)
                ,new SelectExpression<string?>(_schema)
                ,new SelectExpression<string?>(__schema)
                ,new SelectExpression<string?>(_alias)
                ,new SelectExpression<string?>(__alias)
                ,new SelectExpression<string?>(entity)
                ,new SelectExpression<string?>(_entity)
                ,new SelectExpression<string?>(__entity)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet? set = null;
            string? aliased = null;

            aliased = alias(nameof(identifier));
            set &= aliased != nameof(identifier) ? new SelectExpression<string?>(identifier, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(identifier));

            aliased = alias(nameof(_identifier));
            set &= aliased != nameof(_identifier) ? new SelectExpression<string?>(_identifier, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_identifier));

            aliased = alias(nameof(__identifier));
            set &= aliased != nameof(__identifier) ? new SelectExpression<string?>(__identifier, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__identifier));

            aliased = alias(nameof(name));
            set &= aliased != nameof(name) ? new SelectExpression<string?>(name, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(name));

            aliased = alias(nameof(_name));
            set &= aliased != nameof(_name) ? new SelectExpression<string?>(_name, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_name));

            aliased = alias(nameof(__name));
            set &= aliased != nameof(__name) ? new SelectExpression<string?>(__name, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__name));

            aliased = alias(nameof(schema));
            set &= aliased != nameof(schema) ? new SelectExpression<string?>(schema, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(schema));

            aliased = alias(nameof(_schema));
            set &= aliased != nameof(_schema) ? new SelectExpression<string?>(_schema, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_schema));

            aliased = alias(nameof(__schema));
            set &= aliased != nameof(__schema) ? new SelectExpression<string?>(__schema, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__schema));

            aliased = alias(nameof(_alias));
            set &= aliased != nameof(_alias) ? new SelectExpression<string?>(_alias, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_alias));

            aliased = alias(nameof(__alias));
            set &= aliased != nameof(__alias) ? new SelectExpression<string?>(__alias, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__alias));

            aliased = alias(nameof(entity));
            set &= aliased != nameof(entity) ? new SelectExpression<string?>(entity, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(entity));

            aliased = alias(nameof(_entity));
            set &= aliased != nameof(_entity) ? new SelectExpression<string?>(_entity, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_entity));

            aliased = alias(nameof(__entity));
            set &= aliased != nameof(__entity) ? new SelectExpression<string?>(__entity, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__entity));

            return set;
        }
		
        protected override InsertExpressionSet<alias> GetInclusiveInsertExpression(alias ___entity)
        {
            return new InsertExpressionSet<alias>(___entity 
                ,new InsertExpression<string?>(___entity.identifier, identifier)
                ,new InsertExpression<string?>(___entity._identifier, _identifier)
                ,new InsertExpression<string?>(___entity.__identifier, __identifier)
                ,new InsertExpression<string?>(___entity.name, name)
                ,new InsertExpression<string?>(___entity._name, _name)
                ,new InsertExpression<string?>(___entity.__name, __name)
                ,new InsertExpression<string?>(___entity.schema, schema)
                ,new InsertExpression<string?>(___entity._schema, _schema)
                ,new InsertExpression<string?>(___entity.__schema, __schema)
                ,new InsertExpression<string?>(___entity._alias, _alias)
                ,new InsertExpression<string?>(___entity.__alias, __alias)
                ,new InsertExpression<string?>(___entity.entity, entity)
                ,new InsertExpression<string?>(___entity._entity, _entity)
                ,new InsertExpression<string?>(___entity.__entity, __entity)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(alias target, alias source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.identifier != source.identifier) { expr &= identifier.Set(source.identifier); }
            if (target._identifier != source._identifier) { expr &= _identifier.Set(source._identifier); }
            if (target.__identifier != source.__identifier) { expr &= __identifier.Set(source.__identifier); }
            if (target.name != source.name) { expr &= name.Set(source.name); }
            if (target._name != source._name) { expr &= _name.Set(source._name); }
            if (target.__name != source.__name) { expr &= __name.Set(source.__name); }
            if (target.schema != source.schema) { expr &= schema.Set(source.schema); }
            if (target._schema != source._schema) { expr &= _schema.Set(source._schema); }
            if (target.__schema != source.__schema) { expr &= __schema.Set(source.__schema); }
            if (target._alias != source._alias) { expr &= _alias.Set(source._alias); }
            if (target.__alias != source.__alias) { expr &= __alias.Set(source.__alias); }
            if (target.entity != source.entity) { expr &= entity.Set(source.entity); }
            if (target._entity != source._entity) { expr &= _entity.Set(source._entity); }
            if (target.__entity != source.__entity) { expr &= __entity.Set(source.__entity); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, alias ___entity)
        {
            ___entity.identifier = reader.ReadField()!.GetValue<string?>();
            ___entity._identifier = reader.ReadField()!.GetValue<string?>();
            ___entity.__identifier = reader.ReadField()!.GetValue<string?>();
            ___entity.name = reader.ReadField()!.GetValue<string?>();
            ___entity._name = reader.ReadField()!.GetValue<string?>();
            ___entity.__name = reader.ReadField()!.GetValue<string?>();
            ___entity.schema = reader.ReadField()!.GetValue<string?>();
            ___entity._schema = reader.ReadField()!.GetValue<string?>();
            ___entity.__schema = reader.ReadField()!.GetValue<string?>();
            ___entity._alias = reader.ReadField()!.GetValue<string?>();
            ___entity.__alias = reader.ReadField()!.GetValue<string?>();
            ___entity.entity = reader.ReadField()!.GetValue<string?>();
            ___entity._entity = reader.ReadField()!.GetValue<string?>();
            ___entity.__entity = reader.ReadField()!.GetValue<string?>();
        }
		#endregion

        #region classes
        #region identifier field expression
        public partial class identifierField : NullableStringFieldExpression<alias>
        {
            #region constructors
            public identifierField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _identifier field expression
        public partial class _identifierField : NullableStringFieldExpression<alias>
        {
            #region constructors
            public _identifierField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __identifier field expression
        public partial class __identifierField : NullableStringFieldExpression<alias>
        {
            #region constructors
            public __identifierField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region name field expression
        public partial class nameField : NullableStringFieldExpression<alias>
        {
            #region constructors
            public nameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _name field expression
        public partial class _nameField : NullableStringFieldExpression<alias>
        {
            #region constructors
            public _nameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __name field expression
        public partial class __nameField : NullableStringFieldExpression<alias>
        {
            #region constructors
            public __nameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region schema field expression
        public partial class schemaField : NullableStringFieldExpression<alias>
        {
            #region constructors
            public schemaField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _schema field expression
        public partial class _schemaField : NullableStringFieldExpression<alias>
        {
            #region constructors
            public _schemaField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __schema field expression
        public partial class __schemaField : NullableStringFieldExpression<alias>
        {
            #region constructors
            public __schemaField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _alias field expression
        public partial class _aliasField : NullableStringFieldExpression<alias>
        {
            #region constructors
            public _aliasField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __alias field expression
        public partial class __aliasField : NullableStringFieldExpression<alias>
        {
            #region constructors
            public __aliasField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region entity field expression
        public partial class entityField : NullableStringFieldExpression<alias>
        {
            #region constructors
            public entityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _entity field expression
        public partial class _entityField : NullableStringFieldExpression<alias>
        {
            #region constructors
            public _entityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __entity field expression
        public partial class __entityField : NullableStringFieldExpression<alias>
        {
            #region constructors
            public __entityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region entity entity expression
    public partial class entityEntity : EntityExpression<entity>
    {
        #region internals
        private SelectExpressionSet? _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="DbEx.unit_testDataService.entityEntity.identifierField"/> representing the "unit_test.entity.identifier" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.entityEntity.identifierField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>identifier</description>
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
        public readonly identifierField identifier;


        /// <summary>A <see cref="DbEx.unit_testDataService.entityEntity._identifierField"/> representing the "unit_test.entity._identifier" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.entityEntity._identifierField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_identifier</description>
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
        public readonly _identifierField _identifier;


        /// <summary>A <see cref="DbEx.unit_testDataService.entityEntity.__identifierField"/> representing the "unit_test.entity.__identifier" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.entityEntity.__identifierField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__identifier</description>
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
        public readonly __identifierField __identifier;


        /// <summary>A <see cref="DbEx.unit_testDataService.entityEntity.nameField"/> representing the "unit_test.entity.name" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.entityEntity.nameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>name</description>
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
        public readonly nameField name;


        /// <summary>A <see cref="DbEx.unit_testDataService.entityEntity._nameField"/> representing the "unit_test.entity._name" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.entityEntity._nameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_name</description>
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
        public readonly _nameField _name;


        /// <summary>A <see cref="DbEx.unit_testDataService.entityEntity.__nameField"/> representing the "unit_test.entity.__name" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.entityEntity.__nameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__name</description>
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
        public readonly __nameField __name;


        /// <summary>A <see cref="DbEx.unit_testDataService.entityEntity.schemaField"/> representing the "unit_test.entity.schema" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.entityEntity.schemaField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>schema</description>
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
        public readonly schemaField schema;


        /// <summary>A <see cref="DbEx.unit_testDataService.entityEntity._schemaField"/> representing the "unit_test.entity._schema" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.entityEntity._schemaField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_schema</description>
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
        public readonly _schemaField _schema;


        /// <summary>A <see cref="DbEx.unit_testDataService.entityEntity.__schemaField"/> representing the "unit_test.entity.__schema" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.entityEntity.__schemaField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__schema</description>
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
        public readonly __schemaField __schema;


        /// <summary>A <see cref="DbEx.unit_testDataService.entityEntity.aliasField"/> representing the "unit_test.entity.alias" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.entityEntity.aliasField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>alias</description>
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
        public readonly aliasField alias;


        /// <summary>A <see cref="DbEx.unit_testDataService.entityEntity._aliasField"/> representing the "unit_test.entity._alias" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.entityEntity._aliasField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_alias</description>
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
        public readonly _aliasField _alias;


        /// <summary>A <see cref="DbEx.unit_testDataService.entityEntity.__aliasField"/> representing the "unit_test.entity.__alias" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.entityEntity.__aliasField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__alias</description>
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
        public readonly __aliasField __alias;


        /// <summary>A <see cref="DbEx.unit_testDataService.entityEntity._entityField"/> representing the "unit_test.entity._entity" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.entityEntity._entityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_entity</description>
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
        public readonly _entityField _entity;


        /// <summary>A <see cref="DbEx.unit_testDataService.entityEntity.__entityField"/> representing the "unit_test.entity.__entity" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.entityEntity.__entityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__entity</description>
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
        public readonly __entityField __entity;

        #endregion

        #region constructors
        public entityEntity(string ___identifier, string ___name, Schema ___schema) : this(___identifier, ___name, ___schema, null)
        {
        }

        private entityEntity(string ___identifier, string ___name, Schema ___schema, string? ___alias) : base(___identifier, ___name, ___schema, ___alias)
        {
            Attributes.Fields.Add($"{identifier}.identifier", identifier = new identifierField($"{___identifier}.identifier", "identifier", this));
            Attributes.Fields.Add($"{identifier}._identifier", _identifier = new _identifierField($"{___identifier}._identifier", "_identifier", this));
            Attributes.Fields.Add($"{identifier}.__identifier", __identifier = new __identifierField($"{___identifier}.__identifier", "__identifier", this));
            Attributes.Fields.Add($"{identifier}.name", name = new nameField($"{___identifier}.name", "name", this));
            Attributes.Fields.Add($"{identifier}._name", _name = new _nameField($"{___identifier}._name", "_name", this));
            Attributes.Fields.Add($"{identifier}.__name", __name = new __nameField($"{___identifier}.__name", "__name", this));
            Attributes.Fields.Add($"{identifier}.schema", schema = new schemaField($"{___identifier}.schema", "schema", this));
            Attributes.Fields.Add($"{identifier}._schema", _schema = new _schemaField($"{___identifier}._schema", "_schema", this));
            Attributes.Fields.Add($"{identifier}.__schema", __schema = new __schemaField($"{___identifier}.__schema", "__schema", this));
            Attributes.Fields.Add($"{identifier}.alias", alias = new aliasField($"{___identifier}.alias", "alias", this));
            Attributes.Fields.Add($"{identifier}._alias", _alias = new _aliasField($"{___identifier}._alias", "_alias", this));
            Attributes.Fields.Add($"{identifier}.__alias", __alias = new __aliasField($"{___identifier}.__alias", "__alias", this));
            Attributes.Fields.Add($"{identifier}._entity", _entity = new _entityField($"{___identifier}._entity", "_entity", this));
            Attributes.Fields.Add($"{identifier}.__entity", __entity = new __entityField($"{___identifier}.__entity", "__entity", this));
        }
        #endregion

        #region methods
        public entityEntity As(string alias)
            => new entityEntity(this.Attributes.Identifier, this.Attributes.Name, this.Attributes.Schema, alias);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return _inclusiveSelectExpressionSet ?? (_inclusiveSelectExpressionSet = new SelectExpressionSet(
                new SelectExpression<string?>(identifier)
                ,new SelectExpression<string?>(_identifier)
                ,new SelectExpression<string?>(__identifier)
                ,new SelectExpression<string?>(name)
                ,new SelectExpression<string?>(_name)
                ,new SelectExpression<string?>(__name)
                ,new SelectExpression<string?>(schema)
                ,new SelectExpression<string?>(_schema)
                ,new SelectExpression<string?>(__schema)
                ,new SelectExpression<string?>(alias)
                ,new SelectExpression<string?>(_alias)
                ,new SelectExpression<string?>(__alias)
                ,new SelectExpression<string?>(_entity)
                ,new SelectExpression<string?>(__entity)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> ___alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet? set = null;
            string? aliased = null;

            aliased = ___alias(nameof(identifier));
            set &= aliased != nameof(identifier) ? new SelectExpression<string?>(identifier, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(identifier));

            aliased = ___alias(nameof(_identifier));
            set &= aliased != nameof(_identifier) ? new SelectExpression<string?>(_identifier, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_identifier));

            aliased = ___alias(nameof(__identifier));
            set &= aliased != nameof(__identifier) ? new SelectExpression<string?>(__identifier, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__identifier));

            aliased = ___alias(nameof(name));
            set &= aliased != nameof(name) ? new SelectExpression<string?>(name, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(name));

            aliased = ___alias(nameof(_name));
            set &= aliased != nameof(_name) ? new SelectExpression<string?>(_name, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_name));

            aliased = ___alias(nameof(__name));
            set &= aliased != nameof(__name) ? new SelectExpression<string?>(__name, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__name));

            aliased = ___alias(nameof(schema));
            set &= aliased != nameof(schema) ? new SelectExpression<string?>(schema, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(schema));

            aliased = ___alias(nameof(_schema));
            set &= aliased != nameof(_schema) ? new SelectExpression<string?>(_schema, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_schema));

            aliased = ___alias(nameof(__schema));
            set &= aliased != nameof(__schema) ? new SelectExpression<string?>(__schema, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__schema));

            aliased = ___alias(nameof(alias));
            set &= aliased != nameof(alias) ? new SelectExpression<string?>(alias, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(alias));

            aliased = ___alias(nameof(_alias));
            set &= aliased != nameof(_alias) ? new SelectExpression<string?>(_alias, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_alias));

            aliased = ___alias(nameof(__alias));
            set &= aliased != nameof(__alias) ? new SelectExpression<string?>(__alias, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__alias));

            aliased = ___alias(nameof(_entity));
            set &= aliased != nameof(_entity) ? new SelectExpression<string?>(_entity, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_entity));

            aliased = ___alias(nameof(__entity));
            set &= aliased != nameof(__entity) ? new SelectExpression<string?>(__entity, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__entity));

            return set;
        }
		
        protected override InsertExpressionSet<entity> GetInclusiveInsertExpression(entity entity)
        {
            return new InsertExpressionSet<entity>(entity 
                ,new InsertExpression<string?>(entity.identifier, identifier)
                ,new InsertExpression<string?>(entity._identifier, _identifier)
                ,new InsertExpression<string?>(entity.__identifier, __identifier)
                ,new InsertExpression<string?>(entity.name, name)
                ,new InsertExpression<string?>(entity._name, _name)
                ,new InsertExpression<string?>(entity.__name, __name)
                ,new InsertExpression<string?>(entity.schema, schema)
                ,new InsertExpression<string?>(entity._schema, _schema)
                ,new InsertExpression<string?>(entity.__schema, __schema)
                ,new InsertExpression<string?>(entity.alias, alias)
                ,new InsertExpression<string?>(entity._alias, _alias)
                ,new InsertExpression<string?>(entity.__alias, __alias)
                ,new InsertExpression<string?>(entity._entity, _entity)
                ,new InsertExpression<string?>(entity.__entity, __entity)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(entity target, entity source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.identifier != source.identifier) { expr &= identifier.Set(source.identifier); }
            if (target._identifier != source._identifier) { expr &= _identifier.Set(source._identifier); }
            if (target.__identifier != source.__identifier) { expr &= __identifier.Set(source.__identifier); }
            if (target.name != source.name) { expr &= name.Set(source.name); }
            if (target._name != source._name) { expr &= _name.Set(source._name); }
            if (target.__name != source.__name) { expr &= __name.Set(source.__name); }
            if (target.schema != source.schema) { expr &= schema.Set(source.schema); }
            if (target._schema != source._schema) { expr &= _schema.Set(source._schema); }
            if (target.__schema != source.__schema) { expr &= __schema.Set(source.__schema); }
            if (target.alias != source.alias) { expr &= alias.Set(source.alias); }
            if (target._alias != source._alias) { expr &= _alias.Set(source._alias); }
            if (target.__alias != source.__alias) { expr &= __alias.Set(source.__alias); }
            if (target._entity != source._entity) { expr &= _entity.Set(source._entity); }
            if (target.__entity != source.__entity) { expr &= __entity.Set(source.__entity); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, entity entity)
        {
            entity.identifier = reader.ReadField()!.GetValue<string?>();
            entity._identifier = reader.ReadField()!.GetValue<string?>();
            entity.__identifier = reader.ReadField()!.GetValue<string?>();
            entity.name = reader.ReadField()!.GetValue<string?>();
            entity._name = reader.ReadField()!.GetValue<string?>();
            entity.__name = reader.ReadField()!.GetValue<string?>();
            entity.schema = reader.ReadField()!.GetValue<string?>();
            entity._schema = reader.ReadField()!.GetValue<string?>();
            entity.__schema = reader.ReadField()!.GetValue<string?>();
            entity.alias = reader.ReadField()!.GetValue<string?>();
            entity._alias = reader.ReadField()!.GetValue<string?>();
            entity.__alias = reader.ReadField()!.GetValue<string?>();
            entity._entity = reader.ReadField()!.GetValue<string?>();
            entity.__entity = reader.ReadField()!.GetValue<string?>();
        }
		#endregion

        #region classes
        #region identifier field expression
        public partial class identifierField : NullableStringFieldExpression<entity>
        {
            #region constructors
            public identifierField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _identifier field expression
        public partial class _identifierField : NullableStringFieldExpression<entity>
        {
            #region constructors
            public _identifierField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __identifier field expression
        public partial class __identifierField : NullableStringFieldExpression<entity>
        {
            #region constructors
            public __identifierField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region name field expression
        public partial class nameField : NullableStringFieldExpression<entity>
        {
            #region constructors
            public nameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _name field expression
        public partial class _nameField : NullableStringFieldExpression<entity>
        {
            #region constructors
            public _nameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __name field expression
        public partial class __nameField : NullableStringFieldExpression<entity>
        {
            #region constructors
            public __nameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region schema field expression
        public partial class schemaField : NullableStringFieldExpression<entity>
        {
            #region constructors
            public schemaField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _schema field expression
        public partial class _schemaField : NullableStringFieldExpression<entity>
        {
            #region constructors
            public _schemaField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __schema field expression
        public partial class __schemaField : NullableStringFieldExpression<entity>
        {
            #region constructors
            public __schemaField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region alias field expression
        public partial class aliasField : NullableStringFieldExpression<entity>
        {
            #region constructors
            public aliasField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _alias field expression
        public partial class _aliasField : NullableStringFieldExpression<entity>
        {
            #region constructors
            public _aliasField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __alias field expression
        public partial class __aliasField : NullableStringFieldExpression<entity>
        {
            #region constructors
            public __aliasField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _entity field expression
        public partial class _entityField : NullableStringFieldExpression<entity>
        {
            #region constructors
            public _entityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __entity field expression
        public partial class __entityField : NullableStringFieldExpression<entity>
        {
            #region constructors
            public __entityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region expression element type entity expression
    public partial class ExpressionElementTypeEntity : EntityExpression<ExpressionElementType>
    {
        #region internals
        private SelectExpressionSet? _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.IdField"/> representing the "unit_test.ExpressionElementType.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.IdField"/> can be 
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


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.BooleanField"/> representing the "unit_test.ExpressionElementType.Boolean" column in the database, 
        /// with a .NET type of <see cref="bool"/>.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.BooleanField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Boolean}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Boolean</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>bit</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly BooleanField Boolean;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableBooleanField"/> representing the "unit_test.ExpressionElementType.NullableBoolean" column in the database, 
        /// with a .NET type of <see cref="bool"/>?.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableBooleanField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Boolean}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>NullableBoolean</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>bit</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly NullableBooleanField NullableBoolean;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.ByteField"/> representing the "unit_test.ExpressionElementType.Byte" column in the database, 
        /// with a .NET type of <see cref="byte"/>.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.ByteField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Byte}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Byte</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>tinyint</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ByteField Byte;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableByteField"/> representing the "unit_test.ExpressionElementType.NullableByte" column in the database, 
        /// with a .NET type of <see cref="byte"/>?.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableByteField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Byte}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>NullableByte</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>tinyint</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly NullableByteField NullableByte;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.ByteArrayField"/> representing the "unit_test.ExpressionElementType.ByteArray" column in the database, 
        /// with a .NET type of <see cref="byte"/>[].  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.ByteArrayField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Byte[]}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ByteArray</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>varbinary(MAX)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly ByteArrayField ByteArray;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableByteArrayField"/> representing the "unit_test.ExpressionElementType.NullableByteArray" column in the database, 
        /// with a .NET type of <see cref="byte"/>[].  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableByteArrayField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Byte[]}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>NullableByteArray</description>
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
        public readonly NullableByteArrayField NullableByteArray;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.DateTimeField"/> representing the "unit_test.ExpressionElementType.DateTime" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.DateTimeField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateTime</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime2</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateTimeField DateTime;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableDateTimeField"/> representing the "unit_test.ExpressionElementType.NullableDateTime" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>?.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableDateTimeField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTime}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>NullableDateTime</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetime2</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly NullableDateTimeField NullableDateTime;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.DateTimeOffsetField"/> representing the "unit_test.ExpressionElementType.DateTimeOffset" column in the database, 
        /// with a .NET type of <see cref="DateTimeOffset"/>.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.DateTimeOffsetField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTimeOffset}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>DateTimeOffset</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>datetimeoffset</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DateTimeOffsetField DateTimeOffset;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableDateTimeOffsetField"/> representing the "unit_test.ExpressionElementType.NullableDateTimeOffset" column in the database, 
        /// with a .NET type of <see cref="DateTimeOffset"/>?.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableDateTimeOffsetField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{DateTimeOffset}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>NullableDateTimeOffset</description>
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
        public readonly NullableDateTimeOffsetField NullableDateTimeOffset;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.DecimalField"/> representing the "unit_test.ExpressionElementType.Decimal" column in the database, 
        /// with a .NET type of <see cref="decimal"/>.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.DecimalField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Decimal}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Decimal</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>decimal(5,4)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly DecimalField Decimal;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableDecimalField"/> representing the "unit_test.ExpressionElementType.NullableDecimal" column in the database, 
        /// with a .NET type of <see cref="decimal"/>?.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableDecimalField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Decimal}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>NullableDecimal</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>decimal(5,4)</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly NullableDecimalField NullableDecimal;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.DoubleField"/> representing the "unit_test.ExpressionElementType.Double" column in the database, 
        /// with a .NET type of <see cref="double"/>.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.DoubleField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Double}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Double</description>
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
        public readonly DoubleField Double;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableDoubleField"/> representing the "unit_test.ExpressionElementType.NullableDouble" column in the database, 
        /// with a .NET type of <see cref="double"/>?.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableDoubleField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Double}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>NullableDouble</description>
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
        public readonly NullableDoubleField NullableDouble;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.GuidField"/> representing the "unit_test.ExpressionElementType.Guid" column in the database, 
        /// with a .NET type of <see cref="Guid"/>.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.GuidField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Guid}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Guid</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>uniqueidentifier</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly GuidField Guid;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableGuidField"/> representing the "unit_test.ExpressionElementType.NullableGuid" column in the database, 
        /// with a .NET type of <see cref="Guid"/>?.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableGuidField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Guid}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>NullableGuid</description>
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
        public readonly NullableGuidField NullableGuid;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.Int16Field"/> representing the "unit_test.ExpressionElementType.Int16" column in the database, 
        /// with a .NET type of <see cref="short"/>.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.Int16Field"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int16}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Int16</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>smallint</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly Int16Field Int16;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableInt16Field"/> representing the "unit_test.ExpressionElementType.NullableInt16" column in the database, 
        /// with a .NET type of <see cref="short"/>?.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableInt16Field"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int16}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>NullableInt16</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>smallint</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly NullableInt16Field NullableInt16;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.Int32Field"/> representing the "unit_test.ExpressionElementType.Int32" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.Int32Field"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Int32</description>
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
        public readonly Int32Field Int32;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableInt32Field"/> representing the "unit_test.ExpressionElementType.NullableInt32" column in the database, 
        /// with a .NET type of <see cref="int"/>?.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableInt32Field"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int32}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>NullableInt32</description>
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
        public readonly NullableInt32Field NullableInt32;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.Int64Field"/> representing the "unit_test.ExpressionElementType.Int64" column in the database, 
        /// with a .NET type of <see cref="long"/>.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.Int64Field"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int64}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Int64</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>bigint</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly Int64Field Int64;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableInt64Field"/> representing the "unit_test.ExpressionElementType.NullableInt64" column in the database, 
        /// with a .NET type of <see cref="long"/>?.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableInt64Field"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Int64}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>NullableInt64</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>bigint</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly NullableInt64Field NullableInt64;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.SingleField"/> representing the "unit_test.ExpressionElementType.Single" column in the database, 
        /// with a .NET type of <see cref="float"/>.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.SingleField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Single}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>Single</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>real</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly SingleField Single;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableSingleField"/> representing the "unit_test.ExpressionElementType.NullableSingle" column in the database, 
        /// with a .NET type of <see cref="float"/>?.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableSingleField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{Single}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>NullableSingle</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>real</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>yes</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly NullableSingleField NullableSingle;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.StringField"/> representing the "unit_test.ExpressionElementType.String" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.StringField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>String</description>
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
        public readonly StringField String;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableStringField"/> representing the "unit_test.ExpressionElementType.NullableString" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableStringField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>NullableString</description>
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
        public readonly NullableStringField NullableString;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.TimeSpanField"/> representing the "unit_test.ExpressionElementType.TimeSpan" column in the database, 
        /// with a .NET type of <see cref="TimeSpan"/>.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.TimeSpanField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{TimeSpan}"/>.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>TimeSpan</description>
        /// </item>
        /// <item>
        /// <term>sql type</term><description>time</description>
        /// </item>
        /// <item>
        /// <term>allow null</term><description>no</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public readonly TimeSpanField TimeSpan;


        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableTimeSpanField"/> representing the "unit_test.ExpressionElementType.NullableTimeSpan" column in the database, 
        /// with a .NET type of <see cref="TimeSpan"/>?.  The <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity.NullableTimeSpanField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{TimeSpan}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>NullableTimeSpan</description>
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
        public readonly NullableTimeSpanField NullableTimeSpan;

        #endregion

        #region constructors
        public ExpressionElementTypeEntity(string identifier, string name, Schema schema) : this(identifier, name, schema, null)
        {
        }

        private ExpressionElementTypeEntity(string identifier, string name, Schema schema, string? alias) : base(identifier, name, schema, alias)
        {
            Attributes.Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Attributes.Fields.Add($"{identifier}.Boolean", Boolean = new BooleanField($"{identifier}.Boolean", "Boolean", this));
            Attributes.Fields.Add($"{identifier}.NullableBoolean", NullableBoolean = new NullableBooleanField($"{identifier}.NullableBoolean", "NullableBoolean", this));
            Attributes.Fields.Add($"{identifier}.Byte", Byte = new ByteField($"{identifier}.Byte", "Byte", this));
            Attributes.Fields.Add($"{identifier}.NullableByte", NullableByte = new NullableByteField($"{identifier}.NullableByte", "NullableByte", this));
            Attributes.Fields.Add($"{identifier}.ByteArray", ByteArray = new ByteArrayField($"{identifier}.ByteArray", "ByteArray", this));
            Attributes.Fields.Add($"{identifier}.NullableByteArray", NullableByteArray = new NullableByteArrayField($"{identifier}.NullableByteArray", "NullableByteArray", this));
            Attributes.Fields.Add($"{identifier}.DateTime", DateTime = new DateTimeField($"{identifier}.DateTime", "DateTime", this));
            Attributes.Fields.Add($"{identifier}.NullableDateTime", NullableDateTime = new NullableDateTimeField($"{identifier}.NullableDateTime", "NullableDateTime", this));
            Attributes.Fields.Add($"{identifier}.DateTimeOffset", DateTimeOffset = new DateTimeOffsetField($"{identifier}.DateTimeOffset", "DateTimeOffset", this));
            Attributes.Fields.Add($"{identifier}.NullableDateTimeOffset", NullableDateTimeOffset = new NullableDateTimeOffsetField($"{identifier}.NullableDateTimeOffset", "NullableDateTimeOffset", this));
            Attributes.Fields.Add($"{identifier}.Decimal", Decimal = new DecimalField($"{identifier}.Decimal", "Decimal", this));
            Attributes.Fields.Add($"{identifier}.NullableDecimal", NullableDecimal = new NullableDecimalField($"{identifier}.NullableDecimal", "NullableDecimal", this));
            Attributes.Fields.Add($"{identifier}.Double", Double = new DoubleField($"{identifier}.Double", "Double", this));
            Attributes.Fields.Add($"{identifier}.NullableDouble", NullableDouble = new NullableDoubleField($"{identifier}.NullableDouble", "NullableDouble", this));
            Attributes.Fields.Add($"{identifier}.Guid", Guid = new GuidField($"{identifier}.Guid", "Guid", this));
            Attributes.Fields.Add($"{identifier}.NullableGuid", NullableGuid = new NullableGuidField($"{identifier}.NullableGuid", "NullableGuid", this));
            Attributes.Fields.Add($"{identifier}.Int16", Int16 = new Int16Field($"{identifier}.Int16", "Int16", this));
            Attributes.Fields.Add($"{identifier}.NullableInt16", NullableInt16 = new NullableInt16Field($"{identifier}.NullableInt16", "NullableInt16", this));
            Attributes.Fields.Add($"{identifier}.Int32", Int32 = new Int32Field($"{identifier}.Int32", "Int32", this));
            Attributes.Fields.Add($"{identifier}.NullableInt32", NullableInt32 = new NullableInt32Field($"{identifier}.NullableInt32", "NullableInt32", this));
            Attributes.Fields.Add($"{identifier}.Int64", Int64 = new Int64Field($"{identifier}.Int64", "Int64", this));
            Attributes.Fields.Add($"{identifier}.NullableInt64", NullableInt64 = new NullableInt64Field($"{identifier}.NullableInt64", "NullableInt64", this));
            Attributes.Fields.Add($"{identifier}.Single", Single = new SingleField($"{identifier}.Single", "Single", this));
            Attributes.Fields.Add($"{identifier}.NullableSingle", NullableSingle = new NullableSingleField($"{identifier}.NullableSingle", "NullableSingle", this));
            Attributes.Fields.Add($"{identifier}.String", String = new StringField($"{identifier}.String", "String", this));
            Attributes.Fields.Add($"{identifier}.NullableString", NullableString = new NullableStringField($"{identifier}.NullableString", "NullableString", this));
            Attributes.Fields.Add($"{identifier}.TimeSpan", TimeSpan = new TimeSpanField($"{identifier}.TimeSpan", "TimeSpan", this));
            Attributes.Fields.Add($"{identifier}.NullableTimeSpan", NullableTimeSpan = new NullableTimeSpanField($"{identifier}.NullableTimeSpan", "NullableTimeSpan", this));
        }
        #endregion

        #region methods
        public ExpressionElementTypeEntity As(string alias)
            => new ExpressionElementTypeEntity(this.Attributes.Identifier, this.Attributes.Name, this.Attributes.Schema, alias);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return _inclusiveSelectExpressionSet ?? (_inclusiveSelectExpressionSet = new SelectExpressionSet(
                new SelectExpression<int>(Id)
                ,new SelectExpression<bool>(Boolean)
                ,new SelectExpression<bool?>(NullableBoolean)
                ,new SelectExpression<byte>(Byte)
                ,new SelectExpression<byte?>(NullableByte)
                ,new SelectExpression<byte[]>(ByteArray)
                ,new SelectExpression<byte[]?>(NullableByteArray)
                ,new SelectExpression<DateTime>(DateTime)
                ,new SelectExpression<DateTime?>(NullableDateTime)
                ,new SelectExpression<DateTimeOffset>(DateTimeOffset)
                ,new SelectExpression<DateTimeOffset?>(NullableDateTimeOffset)
                ,new SelectExpression<decimal>(Decimal)
                ,new SelectExpression<decimal?>(NullableDecimal)
                ,new SelectExpression<double>(Double)
                ,new SelectExpression<double?>(NullableDouble)
                ,new SelectExpression<Guid>(Guid)
                ,new SelectExpression<Guid?>(NullableGuid)
                ,new SelectExpression<short>(Int16)
                ,new SelectExpression<short?>(NullableInt16)
                ,new SelectExpression<int>(Int32)
                ,new SelectExpression<int?>(NullableInt32)
                ,new SelectExpression<long>(Int64)
                ,new SelectExpression<long?>(NullableInt64)
                ,new SelectExpression<float>(Single)
                ,new SelectExpression<float?>(NullableSingle)
                ,new SelectExpression<string>(String)
                ,new SelectExpression<string?>(NullableString)
                ,new SelectExpression<TimeSpan>(TimeSpan)
                ,new SelectExpression<TimeSpan?>(NullableTimeSpan)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet? set = null;
            string? aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Id));

            aliased = alias(nameof(Boolean));
            set &= aliased != nameof(Boolean) ? new SelectExpression<bool>(Boolean, aliased) as SelectExpression<bool> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Boolean));

            aliased = alias(nameof(NullableBoolean));
            set &= aliased != nameof(NullableBoolean) ? new SelectExpression<bool?>(NullableBoolean, aliased) as SelectExpression<bool?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(NullableBoolean));

            aliased = alias(nameof(Byte));
            set &= aliased != nameof(Byte) ? new SelectExpression<byte>(Byte, aliased) as SelectExpression<byte> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Byte));

            aliased = alias(nameof(NullableByte));
            set &= aliased != nameof(NullableByte) ? new SelectExpression<byte?>(NullableByte, aliased) as SelectExpression<byte?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(NullableByte));

            aliased = alias(nameof(ByteArray));
            set &= aliased != nameof(ByteArray) ? new SelectExpression<byte[]>(ByteArray, aliased) as SelectExpression<byte[]> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(ByteArray));

            aliased = alias(nameof(NullableByteArray));
            set &= aliased != nameof(NullableByteArray) ? new SelectExpression<byte[]?>(NullableByteArray, aliased) as SelectExpression<byte[]?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(NullableByteArray));

            aliased = alias(nameof(DateTime));
            set &= aliased != nameof(DateTime) ? new SelectExpression<DateTime>(DateTime, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateTime));

            aliased = alias(nameof(NullableDateTime));
            set &= aliased != nameof(NullableDateTime) ? new SelectExpression<DateTime?>(NullableDateTime, aliased) as SelectExpression<DateTime?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(NullableDateTime));

            aliased = alias(nameof(DateTimeOffset));
            set &= aliased != nameof(DateTimeOffset) ? new SelectExpression<DateTimeOffset>(DateTimeOffset, aliased) as SelectExpression<DateTimeOffset> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateTimeOffset));

            aliased = alias(nameof(NullableDateTimeOffset));
            set &= aliased != nameof(NullableDateTimeOffset) ? new SelectExpression<DateTimeOffset?>(NullableDateTimeOffset, aliased) as SelectExpression<DateTimeOffset?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(NullableDateTimeOffset));

            aliased = alias(nameof(Decimal));
            set &= aliased != nameof(Decimal) ? new SelectExpression<decimal>(Decimal, aliased) as SelectExpression<decimal> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Decimal));

            aliased = alias(nameof(NullableDecimal));
            set &= aliased != nameof(NullableDecimal) ? new SelectExpression<decimal?>(NullableDecimal, aliased) as SelectExpression<decimal?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(NullableDecimal));

            aliased = alias(nameof(Double));
            set &= aliased != nameof(Double) ? new SelectExpression<double>(Double, aliased) as SelectExpression<double> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Double));

            aliased = alias(nameof(NullableDouble));
            set &= aliased != nameof(NullableDouble) ? new SelectExpression<double?>(NullableDouble, aliased) as SelectExpression<double?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(NullableDouble));

            aliased = alias(nameof(Guid));
            set &= aliased != nameof(Guid) ? new SelectExpression<Guid>(Guid, aliased) as SelectExpression<Guid> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Guid));

            aliased = alias(nameof(NullableGuid));
            set &= aliased != nameof(NullableGuid) ? new SelectExpression<Guid?>(NullableGuid, aliased) as SelectExpression<Guid?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(NullableGuid));

            aliased = alias(nameof(Int16));
            set &= aliased != nameof(Int16) ? new SelectExpression<short>(Int16, aliased) as SelectExpression<short> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Int16));

            aliased = alias(nameof(NullableInt16));
            set &= aliased != nameof(NullableInt16) ? new SelectExpression<short?>(NullableInt16, aliased) as SelectExpression<short?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(NullableInt16));

            aliased = alias(nameof(Int32));
            set &= aliased != nameof(Int32) ? new SelectExpression<int>(Int32, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Int32));

            aliased = alias(nameof(NullableInt32));
            set &= aliased != nameof(NullableInt32) ? new SelectExpression<int?>(NullableInt32, aliased) as SelectExpression<int?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(NullableInt32));

            aliased = alias(nameof(Int64));
            set &= aliased != nameof(Int64) ? new SelectExpression<long>(Int64, aliased) as SelectExpression<long> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Int64));

            aliased = alias(nameof(NullableInt64));
            set &= aliased != nameof(NullableInt64) ? new SelectExpression<long?>(NullableInt64, aliased) as SelectExpression<long?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(NullableInt64));

            aliased = alias(nameof(Single));
            set &= aliased != nameof(Single) ? new SelectExpression<float>(Single, aliased) as SelectExpression<float> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Single));

            aliased = alias(nameof(NullableSingle));
            set &= aliased != nameof(NullableSingle) ? new SelectExpression<float?>(NullableSingle, aliased) as SelectExpression<float?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(NullableSingle));

            aliased = alias(nameof(String));
            set &= aliased != nameof(String) ? new SelectExpression<string>(String, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(String));

            aliased = alias(nameof(NullableString));
            set &= aliased != nameof(NullableString) ? new SelectExpression<string?>(NullableString, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(NullableString));

            aliased = alias(nameof(TimeSpan));
            set &= aliased != nameof(TimeSpan) ? new SelectExpression<TimeSpan>(TimeSpan, aliased) as SelectExpression<TimeSpan> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(TimeSpan));

            aliased = alias(nameof(NullableTimeSpan));
            set &= aliased != nameof(NullableTimeSpan) ? new SelectExpression<TimeSpan?>(NullableTimeSpan, aliased) as SelectExpression<TimeSpan?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(NullableTimeSpan));

            return set;
        }
		
        protected override InsertExpressionSet<ExpressionElementType> GetInclusiveInsertExpression(ExpressionElementType entity)
        {
            return new InsertExpressionSet<ExpressionElementType>(entity 
                ,new InsertExpression<int>(entity.Id, Id)
                ,new InsertExpression<bool>(entity.Boolean, Boolean)
                ,new InsertExpression<bool?>(entity.NullableBoolean, NullableBoolean)
                ,new InsertExpression<byte>(entity.Byte, Byte)
                ,new InsertExpression<byte?>(entity.NullableByte, NullableByte)
                ,new InsertExpression<byte[]>(entity.ByteArray, ByteArray)
                ,new InsertExpression<byte[]?>(entity.NullableByteArray, NullableByteArray)
                ,new InsertExpression<DateTime>(entity.DateTime, DateTime)
                ,new InsertExpression<DateTime?>(entity.NullableDateTime, NullableDateTime)
                ,new InsertExpression<DateTimeOffset>(entity.DateTimeOffset, DateTimeOffset)
                ,new InsertExpression<DateTimeOffset?>(entity.NullableDateTimeOffset, NullableDateTimeOffset)
                ,new InsertExpression<decimal>(entity.Decimal, Decimal)
                ,new InsertExpression<decimal?>(entity.NullableDecimal, NullableDecimal)
                ,new InsertExpression<double>(entity.Double, Double)
                ,new InsertExpression<double?>(entity.NullableDouble, NullableDouble)
                ,new InsertExpression<Guid>(entity.Guid, Guid)
                ,new InsertExpression<Guid?>(entity.NullableGuid, NullableGuid)
                ,new InsertExpression<short>(entity.Int16, Int16)
                ,new InsertExpression<short?>(entity.NullableInt16, NullableInt16)
                ,new InsertExpression<int>(entity.Int32, Int32)
                ,new InsertExpression<int?>(entity.NullableInt32, NullableInt32)
                ,new InsertExpression<long>(entity.Int64, Int64)
                ,new InsertExpression<long?>(entity.NullableInt64, NullableInt64)
                ,new InsertExpression<float>(entity.Single, Single)
                ,new InsertExpression<float?>(entity.NullableSingle, NullableSingle)
                ,new InsertExpression<string>(entity.String, String)
                ,new InsertExpression<string?>(entity.NullableString, NullableString)
                ,new InsertExpression<TimeSpan>(entity.TimeSpan, TimeSpan)
                ,new InsertExpression<TimeSpan?>(entity.NullableTimeSpan, NullableTimeSpan)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(ExpressionElementType target, ExpressionElementType source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.Id != source.Id) { expr &= Id.Set(source.Id); }
            if (target.Boolean != source.Boolean) { expr &= Boolean.Set(source.Boolean); }
            if (target.NullableBoolean != source.NullableBoolean) { expr &= NullableBoolean.Set(source.NullableBoolean); }
            if (target.Byte != source.Byte) { expr &= Byte.Set(source.Byte); }
            if (target.NullableByte != source.NullableByte) { expr &= NullableByte.Set(source.NullableByte); }
            if (target.ByteArray != source.ByteArray) { expr &= ByteArray.Set(source.ByteArray); }
            if (target.NullableByteArray != source.NullableByteArray) { expr &= NullableByteArray.Set(source.NullableByteArray); }
            if (target.DateTime != source.DateTime) { expr &= DateTime.Set(source.DateTime); }
            if (target.NullableDateTime != source.NullableDateTime) { expr &= NullableDateTime.Set(source.NullableDateTime); }
            if (target.DateTimeOffset != source.DateTimeOffset) { expr &= DateTimeOffset.Set(source.DateTimeOffset); }
            if (target.NullableDateTimeOffset != source.NullableDateTimeOffset) { expr &= NullableDateTimeOffset.Set(source.NullableDateTimeOffset); }
            if (target.Decimal != source.Decimal) { expr &= Decimal.Set(source.Decimal); }
            if (target.NullableDecimal != source.NullableDecimal) { expr &= NullableDecimal.Set(source.NullableDecimal); }
            if (target.Double != source.Double) { expr &= Double.Set(source.Double); }
            if (target.NullableDouble != source.NullableDouble) { expr &= NullableDouble.Set(source.NullableDouble); }
            if (target.Guid != source.Guid) { expr &= Guid.Set(source.Guid); }
            if (target.NullableGuid != source.NullableGuid) { expr &= NullableGuid.Set(source.NullableGuid); }
            if (target.Int16 != source.Int16) { expr &= Int16.Set(source.Int16); }
            if (target.NullableInt16 != source.NullableInt16) { expr &= NullableInt16.Set(source.NullableInt16); }
            if (target.Int32 != source.Int32) { expr &= Int32.Set(source.Int32); }
            if (target.NullableInt32 != source.NullableInt32) { expr &= NullableInt32.Set(source.NullableInt32); }
            if (target.Int64 != source.Int64) { expr &= Int64.Set(source.Int64); }
            if (target.NullableInt64 != source.NullableInt64) { expr &= NullableInt64.Set(source.NullableInt64); }
            if (target.Single != source.Single) { expr &= Single.Set(source.Single); }
            if (target.NullableSingle != source.NullableSingle) { expr &= NullableSingle.Set(source.NullableSingle); }
            if (target.String != source.String) { expr &= String.Set(source.String); }
            if (target.NullableString != source.NullableString) { expr &= NullableString.Set(source.NullableString); }
            if (target.TimeSpan != source.TimeSpan) { expr &= TimeSpan.Set(source.TimeSpan); }
            if (target.NullableTimeSpan != source.NullableTimeSpan) { expr &= NullableTimeSpan.Set(source.NullableTimeSpan); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, ExpressionElementType entity)
        {
            entity.Id = reader.ReadField()!.GetValue<int>();
            entity.Boolean = reader.ReadField()!.GetValue<bool>();
            entity.NullableBoolean = reader.ReadField()!.GetValue<bool?>();
            entity.Byte = reader.ReadField()!.GetValue<byte>();
            entity.NullableByte = reader.ReadField()!.GetValue<byte?>();
            entity.ByteArray = reader.ReadField()!.GetValue<byte[]>();
            entity.NullableByteArray = reader.ReadField()!.GetValue<byte[]?>();
            entity.DateTime = reader.ReadField()!.GetValue<DateTime>();
            entity.NullableDateTime = reader.ReadField()!.GetValue<DateTime?>();
            entity.DateTimeOffset = reader.ReadField()!.GetValue<DateTimeOffset>();
            entity.NullableDateTimeOffset = reader.ReadField()!.GetValue<DateTimeOffset?>();
            entity.Decimal = reader.ReadField()!.GetValue<decimal>();
            entity.NullableDecimal = reader.ReadField()!.GetValue<decimal?>();
            entity.Double = reader.ReadField()!.GetValue<double>();
            entity.NullableDouble = reader.ReadField()!.GetValue<double?>();
            entity.Guid = reader.ReadField()!.GetValue<Guid>();
            entity.NullableGuid = reader.ReadField()!.GetValue<Guid?>();
            entity.Int16 = reader.ReadField()!.GetValue<short>();
            entity.NullableInt16 = reader.ReadField()!.GetValue<short?>();
            entity.Int32 = reader.ReadField()!.GetValue<int>();
            entity.NullableInt32 = reader.ReadField()!.GetValue<int?>();
            entity.Int64 = reader.ReadField()!.GetValue<long>();
            entity.NullableInt64 = reader.ReadField()!.GetValue<long?>();
            entity.Single = reader.ReadField()!.GetValue<float>();
            entity.NullableSingle = reader.ReadField()!.GetValue<float?>();
            entity.String = reader.ReadField()!.GetValue<string>();
            entity.NullableString = reader.ReadField()!.GetValue<string?>();
            entity.TimeSpan = reader.ReadField()!.GetValue<TimeSpan>();
            entity.NullableTimeSpan = reader.ReadField()!.GetValue<TimeSpan?>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<ExpressionElementType>
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

        #region boolean field expression
        public partial class BooleanField : BooleanFieldExpression<ExpressionElementType>
        {
            #region constructors
            public BooleanField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<bool>(value));
            public AssignmentExpression Set(bool value) => new AssignmentExpression(this, new LiteralExpression<bool>(value, this));
            public AssignmentExpression Set(AnyElement<bool> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region nullable boolean field expression
        public partial class NullableBooleanField : NullableBooleanFieldExpression<ExpressionElementType>
        {
            #region constructors
            public NullableBooleanField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<bool?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<bool?>(value, this));
            public AssignmentExpression Set(bool? value) => new AssignmentExpression(this, new LiteralExpression<bool?>(value, this));
            public AssignmentExpression Set(AnyElement<bool?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(bool value) => new AssignmentExpression(this, new LiteralExpression<bool>(value, this));
            public AssignmentExpression Set(AnyElement<bool> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region byte field expression
        public partial class ByteField : ByteFieldExpression<ExpressionElementType>
        {
            #region constructors
            public ByteField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<byte>(value));
            public AssignmentExpression Set(byte value) => new AssignmentExpression(this, new LiteralExpression<byte>(value, this));
            public AssignmentExpression Set(AnyElement<byte> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region nullable byte field expression
        public partial class NullableByteField : NullableByteFieldExpression<ExpressionElementType>
        {
            #region constructors
            public NullableByteField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<byte?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<byte?>(value, this));
            public AssignmentExpression Set(byte? value) => new AssignmentExpression(this, new LiteralExpression<byte?>(value, this));
            public AssignmentExpression Set(AnyElement<byte?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(byte value) => new AssignmentExpression(this, new LiteralExpression<byte>(value, this));
            public AssignmentExpression Set(AnyElement<byte> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region byte array field expression
        public partial class ByteArrayField : ByteArrayFieldExpression<ExpressionElementType>
        {
            #region constructors
            public ByteArrayField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<byte[]>(value));
            public AssignmentExpression Set(byte[] value) => new AssignmentExpression(this, new LiteralExpression<byte[]>(value, this));
            public AssignmentExpression Set(AnyElement<byte[]> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region nullable byte array field expression
        public partial class NullableByteArrayField : NullableByteArrayFieldExpression<ExpressionElementType>
        {
            #region constructors
            public NullableByteArrayField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<byte[]?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<byte[]?>(value, this));
            public AssignmentExpression Set(byte[]? value) => new AssignmentExpression(this, new LiteralExpression<byte[]?>(value, this));
            public AssignmentExpression Set(AnyElement<byte[]?> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date time field expression
        public partial class DateTimeField : DateTimeFieldExpression<ExpressionElementType>
        {
            #region constructors
            public DateTimeField(string identifier, string name, Table entity) : base(identifier, name, entity)
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

        #region nullable date time field expression
        public partial class NullableDateTimeField : NullableDateTimeFieldExpression<ExpressionElementType>
        {
            #region constructors
            public NullableDateTimeField(string identifier, string name, Table entity) : base(identifier, name, entity)
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

        #region date time offset field expression
        public partial class DateTimeOffsetField : DateTimeOffsetFieldExpression<ExpressionElementType>
        {
            #region constructors
            public DateTimeOffsetField(string identifier, string name, Table entity) : base(identifier, name, entity)
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

        #region nullable date time offset field expression
        public partial class NullableDateTimeOffsetField : NullableDateTimeOffsetFieldExpression<ExpressionElementType>
        {
            #region constructors
            public NullableDateTimeOffsetField(string identifier, string name, Table entity) : base(identifier, name, entity)
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

        #region decimal field expression
        public partial class DecimalField : DecimalFieldExpression<ExpressionElementType>
        {
            #region constructors
            public DecimalField(string identifier, string name, Table entity) : base(identifier, name, entity)
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

        #region nullable decimal field expression
        public partial class NullableDecimalField : NullableDecimalFieldExpression<ExpressionElementType>
        {
            #region constructors
            public NullableDecimalField(string identifier, string name, Table entity) : base(identifier, name, entity)
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

        #region double field expression
        public partial class DoubleField : DoubleFieldExpression<ExpressionElementType>
        {
            #region constructors
            public DoubleField(string identifier, string name, Table entity) : base(identifier, name, entity)
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

        #region nullable double field expression
        public partial class NullableDoubleField : NullableDoubleFieldExpression<ExpressionElementType>
        {
            #region constructors
            public NullableDoubleField(string identifier, string name, Table entity) : base(identifier, name, entity)
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

        #region guid field expression
        public partial class GuidField : GuidFieldExpression<ExpressionElementType>
        {
            #region constructors
            public GuidField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<Guid>(value));
            public AssignmentExpression Set(Guid value) => new AssignmentExpression(this, new LiteralExpression<Guid>(value, this));
            public AssignmentExpression Set(AnyElement<Guid> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region nullable guid field expression
        public partial class NullableGuidField : NullableGuidFieldExpression<ExpressionElementType>
        {
            #region constructors
            public NullableGuidField(string identifier, string name, Table entity) : base(identifier, name, entity)
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

        #region int16 field expression
        public partial class Int16Field : Int16FieldExpression<ExpressionElementType>
        {
            #region constructors
            public Int16Field(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<short>(value));
            public AssignmentExpression Set(short value) => new AssignmentExpression(this, new LiteralExpression<short>(value, this));
            public AssignmentExpression Set(AnyElement<short> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region nullable int16 field expression
        public partial class NullableInt16Field : NullableInt16FieldExpression<ExpressionElementType>
        {
            #region constructors
            public NullableInt16Field(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<short?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<short?>(value, this));
            public AssignmentExpression Set(short? value) => new AssignmentExpression(this, new LiteralExpression<short?>(value, this));
            public AssignmentExpression Set(AnyElement<short?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(short value) => new AssignmentExpression(this, new LiteralExpression<short>(value, this));
            public AssignmentExpression Set(AnyElement<short> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region int32 field expression
        public partial class Int32Field : Int32FieldExpression<ExpressionElementType>
        {
            #region constructors
            public Int32Field(string identifier, string name, Table entity) : base(identifier, name, entity)
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

        #region nullable int32 field expression
        public partial class NullableInt32Field : NullableInt32FieldExpression<ExpressionElementType>
        {
            #region constructors
            public NullableInt32Field(string identifier, string name, Table entity) : base(identifier, name, entity)
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

        #region int64 field expression
        public partial class Int64Field : Int64FieldExpression<ExpressionElementType>
        {
            #region constructors
            public Int64Field(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<long>(value));
            public AssignmentExpression Set(long value) => new AssignmentExpression(this, new LiteralExpression<long>(value, this));
            public AssignmentExpression Set(AnyElement<long> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region nullable int64 field expression
        public partial class NullableInt64Field : NullableInt64FieldExpression<ExpressionElementType>
        {
            #region constructors
            public NullableInt64Field(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<long?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<long?>(value, this));
            public AssignmentExpression Set(long? value) => new AssignmentExpression(this, new LiteralExpression<long?>(value, this));
            public AssignmentExpression Set(AnyElement<long?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(long value) => new AssignmentExpression(this, new LiteralExpression<long>(value, this));
            public AssignmentExpression Set(AnyElement<long> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region single field expression
        public partial class SingleField : SingleFieldExpression<ExpressionElementType>
        {
            #region constructors
            public SingleField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<float>(value));
            public AssignmentExpression Set(float value) => new AssignmentExpression(this, new LiteralExpression<float>(value, this));
            public AssignmentExpression Set(AnyElement<float> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region nullable single field expression
        public partial class NullableSingleField : NullableSingleFieldExpression<ExpressionElementType>
        {
            #region constructors
            public NullableSingleField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<float?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<float?>(value, this));
            public AssignmentExpression Set(float? value) => new AssignmentExpression(this, new LiteralExpression<float?>(value, this));
            public AssignmentExpression Set(AnyElement<float?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(float value) => new AssignmentExpression(this, new LiteralExpression<float>(value, this));
            public AssignmentExpression Set(AnyElement<float> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region string field expression
        public partial class StringField : StringFieldExpression<ExpressionElementType>
        {
            #region constructors
            public StringField(string identifier, string name, Table entity) : base(identifier, name, entity)
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

        #region nullable string field expression
        public partial class NullableStringField : NullableStringFieldExpression<ExpressionElementType>
        {
            #region constructors
            public NullableStringField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region time span field expression
        public partial class TimeSpanField : TimeSpanFieldExpression<ExpressionElementType>
        {
            #region constructors
            public TimeSpanField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<TimeSpan>(value));
            public AssignmentExpression Set(TimeSpan value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan>(value, this));
            public AssignmentExpression Set(AnyElement<TimeSpan> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region nullable time span field expression
        public partial class NullableTimeSpanField : NullableTimeSpanFieldExpression<ExpressionElementType>
        {
            #region constructors
            public NullableTimeSpanField(string identifier, string name, Table entity) : base(identifier, name, entity)
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

        #endregion
    }
    #endregion

    #region identifier entity expression
    public partial class identifierEntity : EntityExpression<identifier>
    {
        #region internals
        private SelectExpressionSet? _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="DbEx.unit_testDataService.identifierEntity._identifierField"/> representing the "unit_test.identifier._identifier" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.identifierEntity._identifierField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_identifier</description>
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
        public readonly _identifierField _identifier;


        /// <summary>A <see cref="DbEx.unit_testDataService.identifierEntity.__identifierField"/> representing the "unit_test.identifier.__identifier" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.identifierEntity.__identifierField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__identifier</description>
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
        public readonly __identifierField __identifier;


        /// <summary>A <see cref="DbEx.unit_testDataService.identifierEntity.nameField"/> representing the "unit_test.identifier.name" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.identifierEntity.nameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>name</description>
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
        public readonly nameField name;


        /// <summary>A <see cref="DbEx.unit_testDataService.identifierEntity._nameField"/> representing the "unit_test.identifier._name" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.identifierEntity._nameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_name</description>
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
        public readonly _nameField _name;


        /// <summary>A <see cref="DbEx.unit_testDataService.identifierEntity.__nameField"/> representing the "unit_test.identifier.__name" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.identifierEntity.__nameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__name</description>
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
        public readonly __nameField __name;


        /// <summary>A <see cref="DbEx.unit_testDataService.identifierEntity.schemaField"/> representing the "unit_test.identifier.schema" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.identifierEntity.schemaField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>schema</description>
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
        public readonly schemaField schema;


        /// <summary>A <see cref="DbEx.unit_testDataService.identifierEntity._schemaField"/> representing the "unit_test.identifier._schema" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.identifierEntity._schemaField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_schema</description>
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
        public readonly _schemaField _schema;


        /// <summary>A <see cref="DbEx.unit_testDataService.identifierEntity.__schemaField"/> representing the "unit_test.identifier.__schema" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.identifierEntity.__schemaField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__schema</description>
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
        public readonly __schemaField __schema;


        /// <summary>A <see cref="DbEx.unit_testDataService.identifierEntity.aliasField"/> representing the "unit_test.identifier.alias" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.identifierEntity.aliasField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>alias</description>
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
        public readonly aliasField alias;


        /// <summary>A <see cref="DbEx.unit_testDataService.identifierEntity._aliasField"/> representing the "unit_test.identifier._alias" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.identifierEntity._aliasField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_alias</description>
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
        public readonly _aliasField _alias;


        /// <summary>A <see cref="DbEx.unit_testDataService.identifierEntity.__aliasField"/> representing the "unit_test.identifier.__alias" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.identifierEntity.__aliasField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__alias</description>
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
        public readonly __aliasField __alias;


        /// <summary>A <see cref="DbEx.unit_testDataService.identifierEntity.entityField"/> representing the "unit_test.identifier.entity" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.identifierEntity.entityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>entity</description>
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
        public readonly entityField entity;


        /// <summary>A <see cref="DbEx.unit_testDataService.identifierEntity._entityField"/> representing the "unit_test.identifier._entity" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.identifierEntity._entityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_entity</description>
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
        public readonly _entityField _entity;


        /// <summary>A <see cref="DbEx.unit_testDataService.identifierEntity.__entityField"/> representing the "unit_test.identifier.__entity" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.identifierEntity.__entityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__entity</description>
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
        public readonly __entityField __entity;

        #endregion

        #region constructors
        public identifierEntity(string identifier, string ___name, Schema ___schema) : this(identifier, ___name, ___schema, null)
        {
        }

        private identifierEntity(string identifier, string ___name, Schema ___schema, string? ___alias) : base(identifier, ___name, ___schema, ___alias)
        {
            Attributes.Fields.Add($"{identifier}._identifier", _identifier = new _identifierField($"{identifier}._identifier", "_identifier", this));
            Attributes.Fields.Add($"{identifier}.__identifier", __identifier = new __identifierField($"{identifier}.__identifier", "__identifier", this));
            Attributes.Fields.Add($"{identifier}.name", name = new nameField($"{identifier}.name", "name", this));
            Attributes.Fields.Add($"{identifier}._name", _name = new _nameField($"{identifier}._name", "_name", this));
            Attributes.Fields.Add($"{identifier}.__name", __name = new __nameField($"{identifier}.__name", "__name", this));
            Attributes.Fields.Add($"{identifier}.schema", schema = new schemaField($"{identifier}.schema", "schema", this));
            Attributes.Fields.Add($"{identifier}._schema", _schema = new _schemaField($"{identifier}._schema", "_schema", this));
            Attributes.Fields.Add($"{identifier}.__schema", __schema = new __schemaField($"{identifier}.__schema", "__schema", this));
            Attributes.Fields.Add($"{identifier}.alias", alias = new aliasField($"{identifier}.alias", "alias", this));
            Attributes.Fields.Add($"{identifier}._alias", _alias = new _aliasField($"{identifier}._alias", "_alias", this));
            Attributes.Fields.Add($"{identifier}.__alias", __alias = new __aliasField($"{identifier}.__alias", "__alias", this));
            Attributes.Fields.Add($"{identifier}.entity", entity = new entityField($"{identifier}.entity", "entity", this));
            Attributes.Fields.Add($"{identifier}._entity", _entity = new _entityField($"{identifier}._entity", "_entity", this));
            Attributes.Fields.Add($"{identifier}.__entity", __entity = new __entityField($"{identifier}.__entity", "__entity", this));
        }
        #endregion

        #region methods
        public identifierEntity As(string alias)
            => new identifierEntity(this.Attributes.Identifier, this.Attributes.Name, this.Attributes.Schema, alias);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return _inclusiveSelectExpressionSet ?? (_inclusiveSelectExpressionSet = new SelectExpressionSet(
                new SelectExpression<string?>(_identifier)
                ,new SelectExpression<string?>(__identifier)
                ,new SelectExpression<string?>(name)
                ,new SelectExpression<string?>(_name)
                ,new SelectExpression<string?>(__name)
                ,new SelectExpression<string?>(schema)
                ,new SelectExpression<string?>(_schema)
                ,new SelectExpression<string?>(__schema)
                ,new SelectExpression<string?>(alias)
                ,new SelectExpression<string?>(_alias)
                ,new SelectExpression<string?>(__alias)
                ,new SelectExpression<string?>(entity)
                ,new SelectExpression<string?>(_entity)
                ,new SelectExpression<string?>(__entity)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> ___alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet? set = null;
            string? aliased = null;

            aliased = ___alias(nameof(_identifier));
            set &= aliased != nameof(_identifier) ? new SelectExpression<string?>(_identifier, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_identifier));

            aliased = ___alias(nameof(__identifier));
            set &= aliased != nameof(__identifier) ? new SelectExpression<string?>(__identifier, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__identifier));

            aliased = ___alias(nameof(name));
            set &= aliased != nameof(name) ? new SelectExpression<string?>(name, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(name));

            aliased = ___alias(nameof(_name));
            set &= aliased != nameof(_name) ? new SelectExpression<string?>(_name, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_name));

            aliased = ___alias(nameof(__name));
            set &= aliased != nameof(__name) ? new SelectExpression<string?>(__name, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__name));

            aliased = ___alias(nameof(schema));
            set &= aliased != nameof(schema) ? new SelectExpression<string?>(schema, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(schema));

            aliased = ___alias(nameof(_schema));
            set &= aliased != nameof(_schema) ? new SelectExpression<string?>(_schema, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_schema));

            aliased = ___alias(nameof(__schema));
            set &= aliased != nameof(__schema) ? new SelectExpression<string?>(__schema, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__schema));

            aliased = ___alias(nameof(alias));
            set &= aliased != nameof(alias) ? new SelectExpression<string?>(alias, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(alias));

            aliased = ___alias(nameof(_alias));
            set &= aliased != nameof(_alias) ? new SelectExpression<string?>(_alias, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_alias));

            aliased = ___alias(nameof(__alias));
            set &= aliased != nameof(__alias) ? new SelectExpression<string?>(__alias, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__alias));

            aliased = ___alias(nameof(entity));
            set &= aliased != nameof(entity) ? new SelectExpression<string?>(entity, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(entity));

            aliased = ___alias(nameof(_entity));
            set &= aliased != nameof(_entity) ? new SelectExpression<string?>(_entity, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_entity));

            aliased = ___alias(nameof(__entity));
            set &= aliased != nameof(__entity) ? new SelectExpression<string?>(__entity, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__entity));

            return set;
        }
		
        protected override InsertExpressionSet<identifier> GetInclusiveInsertExpression(identifier ___entity)
        {
            return new InsertExpressionSet<identifier>(___entity 
                ,new InsertExpression<string?>(___entity._identifier, _identifier)
                ,new InsertExpression<string?>(___entity.__identifier, __identifier)
                ,new InsertExpression<string?>(___entity.name, name)
                ,new InsertExpression<string?>(___entity._name, _name)
                ,new InsertExpression<string?>(___entity.__name, __name)
                ,new InsertExpression<string?>(___entity.schema, schema)
                ,new InsertExpression<string?>(___entity._schema, _schema)
                ,new InsertExpression<string?>(___entity.__schema, __schema)
                ,new InsertExpression<string?>(___entity.alias, alias)
                ,new InsertExpression<string?>(___entity._alias, _alias)
                ,new InsertExpression<string?>(___entity.__alias, __alias)
                ,new InsertExpression<string?>(___entity.entity, entity)
                ,new InsertExpression<string?>(___entity._entity, _entity)
                ,new InsertExpression<string?>(___entity.__entity, __entity)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(identifier target, identifier source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target._identifier != source._identifier) { expr &= _identifier.Set(source._identifier); }
            if (target.__identifier != source.__identifier) { expr &= __identifier.Set(source.__identifier); }
            if (target.name != source.name) { expr &= name.Set(source.name); }
            if (target._name != source._name) { expr &= _name.Set(source._name); }
            if (target.__name != source.__name) { expr &= __name.Set(source.__name); }
            if (target.schema != source.schema) { expr &= schema.Set(source.schema); }
            if (target._schema != source._schema) { expr &= _schema.Set(source._schema); }
            if (target.__schema != source.__schema) { expr &= __schema.Set(source.__schema); }
            if (target.alias != source.alias) { expr &= alias.Set(source.alias); }
            if (target._alias != source._alias) { expr &= _alias.Set(source._alias); }
            if (target.__alias != source.__alias) { expr &= __alias.Set(source.__alias); }
            if (target.entity != source.entity) { expr &= entity.Set(source.entity); }
            if (target._entity != source._entity) { expr &= _entity.Set(source._entity); }
            if (target.__entity != source.__entity) { expr &= __entity.Set(source.__entity); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, identifier ___entity)
        {
            ___entity._identifier = reader.ReadField()!.GetValue<string?>();
            ___entity.__identifier = reader.ReadField()!.GetValue<string?>();
            ___entity.name = reader.ReadField()!.GetValue<string?>();
            ___entity._name = reader.ReadField()!.GetValue<string?>();
            ___entity.__name = reader.ReadField()!.GetValue<string?>();
            ___entity.schema = reader.ReadField()!.GetValue<string?>();
            ___entity._schema = reader.ReadField()!.GetValue<string?>();
            ___entity.__schema = reader.ReadField()!.GetValue<string?>();
            ___entity.alias = reader.ReadField()!.GetValue<string?>();
            ___entity._alias = reader.ReadField()!.GetValue<string?>();
            ___entity.__alias = reader.ReadField()!.GetValue<string?>();
            ___entity.entity = reader.ReadField()!.GetValue<string?>();
            ___entity._entity = reader.ReadField()!.GetValue<string?>();
            ___entity.__entity = reader.ReadField()!.GetValue<string?>();
        }
		#endregion

        #region classes
        #region _identifier field expression
        public partial class _identifierField : NullableStringFieldExpression<identifier>
        {
            #region constructors
            public _identifierField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __identifier field expression
        public partial class __identifierField : NullableStringFieldExpression<identifier>
        {
            #region constructors
            public __identifierField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region name field expression
        public partial class nameField : NullableStringFieldExpression<identifier>
        {
            #region constructors
            public nameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _name field expression
        public partial class _nameField : NullableStringFieldExpression<identifier>
        {
            #region constructors
            public _nameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __name field expression
        public partial class __nameField : NullableStringFieldExpression<identifier>
        {
            #region constructors
            public __nameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region schema field expression
        public partial class schemaField : NullableStringFieldExpression<identifier>
        {
            #region constructors
            public schemaField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _schema field expression
        public partial class _schemaField : NullableStringFieldExpression<identifier>
        {
            #region constructors
            public _schemaField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __schema field expression
        public partial class __schemaField : NullableStringFieldExpression<identifier>
        {
            #region constructors
            public __schemaField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region alias field expression
        public partial class aliasField : NullableStringFieldExpression<identifier>
        {
            #region constructors
            public aliasField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _alias field expression
        public partial class _aliasField : NullableStringFieldExpression<identifier>
        {
            #region constructors
            public _aliasField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __alias field expression
        public partial class __aliasField : NullableStringFieldExpression<identifier>
        {
            #region constructors
            public __aliasField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region entity field expression
        public partial class entityField : NullableStringFieldExpression<identifier>
        {
            #region constructors
            public entityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _entity field expression
        public partial class _entityField : NullableStringFieldExpression<identifier>
        {
            #region constructors
            public _entityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __entity field expression
        public partial class __entityField : NullableStringFieldExpression<identifier>
        {
            #region constructors
            public __entityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region name entity expression
    public partial class nameEntity : EntityExpression<name>
    {
        #region internals
        private SelectExpressionSet? _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="DbEx.unit_testDataService.nameEntity.identifierField"/> representing the "unit_test.name.identifier" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.nameEntity.identifierField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>identifier</description>
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
        public readonly identifierField identifier;


        /// <summary>A <see cref="DbEx.unit_testDataService.nameEntity._identifierField"/> representing the "unit_test.name._identifier" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.nameEntity._identifierField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_identifier</description>
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
        public readonly _identifierField _identifier;


        /// <summary>A <see cref="DbEx.unit_testDataService.nameEntity.__identifierField"/> representing the "unit_test.name.__identifier" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.nameEntity.__identifierField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__identifier</description>
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
        public readonly __identifierField __identifier;


        /// <summary>A <see cref="DbEx.unit_testDataService.nameEntity._nameField"/> representing the "unit_test.name._name" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.nameEntity._nameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_name</description>
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
        public readonly _nameField _name;


        /// <summary>A <see cref="DbEx.unit_testDataService.nameEntity.__nameField"/> representing the "unit_test.name.__name" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.nameEntity.__nameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__name</description>
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
        public readonly __nameField __name;


        /// <summary>A <see cref="DbEx.unit_testDataService.nameEntity.schemaField"/> representing the "unit_test.name.schema" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.nameEntity.schemaField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>schema</description>
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
        public readonly schemaField schema;


        /// <summary>A <see cref="DbEx.unit_testDataService.nameEntity._schemaField"/> representing the "unit_test.name._schema" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.nameEntity._schemaField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_schema</description>
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
        public readonly _schemaField _schema;


        /// <summary>A <see cref="DbEx.unit_testDataService.nameEntity.__schemaField"/> representing the "unit_test.name.__schema" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.nameEntity.__schemaField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__schema</description>
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
        public readonly __schemaField __schema;


        /// <summary>A <see cref="DbEx.unit_testDataService.nameEntity.aliasField"/> representing the "unit_test.name.alias" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.nameEntity.aliasField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>alias</description>
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
        public readonly aliasField alias;


        /// <summary>A <see cref="DbEx.unit_testDataService.nameEntity._aliasField"/> representing the "unit_test.name._alias" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.nameEntity._aliasField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_alias</description>
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
        public readonly _aliasField _alias;


        /// <summary>A <see cref="DbEx.unit_testDataService.nameEntity.__aliasField"/> representing the "unit_test.name.__alias" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.nameEntity.__aliasField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__alias</description>
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
        public readonly __aliasField __alias;


        /// <summary>A <see cref="DbEx.unit_testDataService.nameEntity.entityField"/> representing the "unit_test.name.entity" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.nameEntity.entityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>entity</description>
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
        public readonly entityField entity;


        /// <summary>A <see cref="DbEx.unit_testDataService.nameEntity._entityField"/> representing the "unit_test.name._entity" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.nameEntity._entityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_entity</description>
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
        public readonly _entityField _entity;


        /// <summary>A <see cref="DbEx.unit_testDataService.nameEntity.__entityField"/> representing the "unit_test.name.__entity" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.nameEntity.__entityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__entity</description>
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
        public readonly __entityField __entity;

        #endregion

        #region constructors
        public nameEntity(string ___identifier, string name, Schema ___schema) : this(___identifier, name, ___schema, null)
        {
        }

        private nameEntity(string ___identifier, string name, Schema ___schema, string? ___alias) : base(___identifier, name, ___schema, ___alias)
        {
            Attributes.Fields.Add($"{identifier}.identifier", identifier = new identifierField($"{___identifier}.identifier", "identifier", this));
            Attributes.Fields.Add($"{identifier}._identifier", _identifier = new _identifierField($"{___identifier}._identifier", "_identifier", this));
            Attributes.Fields.Add($"{identifier}.__identifier", __identifier = new __identifierField($"{___identifier}.__identifier", "__identifier", this));
            Attributes.Fields.Add($"{identifier}._name", _name = new _nameField($"{___identifier}._name", "_name", this));
            Attributes.Fields.Add($"{identifier}.__name", __name = new __nameField($"{___identifier}.__name", "__name", this));
            Attributes.Fields.Add($"{identifier}.schema", schema = new schemaField($"{___identifier}.schema", "schema", this));
            Attributes.Fields.Add($"{identifier}._schema", _schema = new _schemaField($"{___identifier}._schema", "_schema", this));
            Attributes.Fields.Add($"{identifier}.__schema", __schema = new __schemaField($"{___identifier}.__schema", "__schema", this));
            Attributes.Fields.Add($"{identifier}.alias", alias = new aliasField($"{___identifier}.alias", "alias", this));
            Attributes.Fields.Add($"{identifier}._alias", _alias = new _aliasField($"{___identifier}._alias", "_alias", this));
            Attributes.Fields.Add($"{identifier}.__alias", __alias = new __aliasField($"{___identifier}.__alias", "__alias", this));
            Attributes.Fields.Add($"{identifier}.entity", entity = new entityField($"{___identifier}.entity", "entity", this));
            Attributes.Fields.Add($"{identifier}._entity", _entity = new _entityField($"{___identifier}._entity", "_entity", this));
            Attributes.Fields.Add($"{identifier}.__entity", __entity = new __entityField($"{___identifier}.__entity", "__entity", this));
        }
        #endregion

        #region methods
        public nameEntity As(string alias)
            => new nameEntity(this.Attributes.Identifier, this.Attributes.Name, this.Attributes.Schema, alias);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return _inclusiveSelectExpressionSet ?? (_inclusiveSelectExpressionSet = new SelectExpressionSet(
                new SelectExpression<string?>(identifier)
                ,new SelectExpression<string?>(_identifier)
                ,new SelectExpression<string?>(__identifier)
                ,new SelectExpression<string?>(_name)
                ,new SelectExpression<string?>(__name)
                ,new SelectExpression<string?>(schema)
                ,new SelectExpression<string?>(_schema)
                ,new SelectExpression<string?>(__schema)
                ,new SelectExpression<string?>(alias)
                ,new SelectExpression<string?>(_alias)
                ,new SelectExpression<string?>(__alias)
                ,new SelectExpression<string?>(entity)
                ,new SelectExpression<string?>(_entity)
                ,new SelectExpression<string?>(__entity)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> ___alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet? set = null;
            string? aliased = null;

            aliased = ___alias(nameof(identifier));
            set &= aliased != nameof(identifier) ? new SelectExpression<string?>(identifier, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(identifier));

            aliased = ___alias(nameof(_identifier));
            set &= aliased != nameof(_identifier) ? new SelectExpression<string?>(_identifier, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_identifier));

            aliased = ___alias(nameof(__identifier));
            set &= aliased != nameof(__identifier) ? new SelectExpression<string?>(__identifier, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__identifier));

            aliased = ___alias(nameof(_name));
            set &= aliased != nameof(_name) ? new SelectExpression<string?>(_name, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_name));

            aliased = ___alias(nameof(__name));
            set &= aliased != nameof(__name) ? new SelectExpression<string?>(__name, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__name));

            aliased = ___alias(nameof(schema));
            set &= aliased != nameof(schema) ? new SelectExpression<string?>(schema, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(schema));

            aliased = ___alias(nameof(_schema));
            set &= aliased != nameof(_schema) ? new SelectExpression<string?>(_schema, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_schema));

            aliased = ___alias(nameof(__schema));
            set &= aliased != nameof(__schema) ? new SelectExpression<string?>(__schema, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__schema));

            aliased = ___alias(nameof(alias));
            set &= aliased != nameof(alias) ? new SelectExpression<string?>(alias, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(alias));

            aliased = ___alias(nameof(_alias));
            set &= aliased != nameof(_alias) ? new SelectExpression<string?>(_alias, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_alias));

            aliased = ___alias(nameof(__alias));
            set &= aliased != nameof(__alias) ? new SelectExpression<string?>(__alias, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__alias));

            aliased = ___alias(nameof(entity));
            set &= aliased != nameof(entity) ? new SelectExpression<string?>(entity, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(entity));

            aliased = ___alias(nameof(_entity));
            set &= aliased != nameof(_entity) ? new SelectExpression<string?>(_entity, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_entity));

            aliased = ___alias(nameof(__entity));
            set &= aliased != nameof(__entity) ? new SelectExpression<string?>(__entity, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__entity));

            return set;
        }
		
        protected override InsertExpressionSet<name> GetInclusiveInsertExpression(name ___entity)
        {
            return new InsertExpressionSet<name>(___entity 
                ,new InsertExpression<string?>(___entity.identifier, identifier)
                ,new InsertExpression<string?>(___entity._identifier, _identifier)
                ,new InsertExpression<string?>(___entity.__identifier, __identifier)
                ,new InsertExpression<string?>(___entity._name, _name)
                ,new InsertExpression<string?>(___entity.__name, __name)
                ,new InsertExpression<string?>(___entity.schema, schema)
                ,new InsertExpression<string?>(___entity._schema, _schema)
                ,new InsertExpression<string?>(___entity.__schema, __schema)
                ,new InsertExpression<string?>(___entity.alias, alias)
                ,new InsertExpression<string?>(___entity._alias, _alias)
                ,new InsertExpression<string?>(___entity.__alias, __alias)
                ,new InsertExpression<string?>(___entity.entity, entity)
                ,new InsertExpression<string?>(___entity._entity, _entity)
                ,new InsertExpression<string?>(___entity.__entity, __entity)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(name target, name source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.identifier != source.identifier) { expr &= identifier.Set(source.identifier); }
            if (target._identifier != source._identifier) { expr &= _identifier.Set(source._identifier); }
            if (target.__identifier != source.__identifier) { expr &= __identifier.Set(source.__identifier); }
            if (target._name != source._name) { expr &= _name.Set(source._name); }
            if (target.__name != source.__name) { expr &= __name.Set(source.__name); }
            if (target.schema != source.schema) { expr &= schema.Set(source.schema); }
            if (target._schema != source._schema) { expr &= _schema.Set(source._schema); }
            if (target.__schema != source.__schema) { expr &= __schema.Set(source.__schema); }
            if (target.alias != source.alias) { expr &= alias.Set(source.alias); }
            if (target._alias != source._alias) { expr &= _alias.Set(source._alias); }
            if (target.__alias != source.__alias) { expr &= __alias.Set(source.__alias); }
            if (target.entity != source.entity) { expr &= entity.Set(source.entity); }
            if (target._entity != source._entity) { expr &= _entity.Set(source._entity); }
            if (target.__entity != source.__entity) { expr &= __entity.Set(source.__entity); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, name ___entity)
        {
            ___entity.identifier = reader.ReadField()!.GetValue<string?>();
            ___entity._identifier = reader.ReadField()!.GetValue<string?>();
            ___entity.__identifier = reader.ReadField()!.GetValue<string?>();
            ___entity._name = reader.ReadField()!.GetValue<string?>();
            ___entity.__name = reader.ReadField()!.GetValue<string?>();
            ___entity.schema = reader.ReadField()!.GetValue<string?>();
            ___entity._schema = reader.ReadField()!.GetValue<string?>();
            ___entity.__schema = reader.ReadField()!.GetValue<string?>();
            ___entity.alias = reader.ReadField()!.GetValue<string?>();
            ___entity._alias = reader.ReadField()!.GetValue<string?>();
            ___entity.__alias = reader.ReadField()!.GetValue<string?>();
            ___entity.entity = reader.ReadField()!.GetValue<string?>();
            ___entity._entity = reader.ReadField()!.GetValue<string?>();
            ___entity.__entity = reader.ReadField()!.GetValue<string?>();
        }
		#endregion

        #region classes
        #region identifier field expression
        public partial class identifierField : NullableStringFieldExpression<name>
        {
            #region constructors
            public identifierField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _identifier field expression
        public partial class _identifierField : NullableStringFieldExpression<name>
        {
            #region constructors
            public _identifierField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __identifier field expression
        public partial class __identifierField : NullableStringFieldExpression<name>
        {
            #region constructors
            public __identifierField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _name field expression
        public partial class _nameField : NullableStringFieldExpression<name>
        {
            #region constructors
            public _nameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __name field expression
        public partial class __nameField : NullableStringFieldExpression<name>
        {
            #region constructors
            public __nameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region schema field expression
        public partial class schemaField : NullableStringFieldExpression<name>
        {
            #region constructors
            public schemaField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _schema field expression
        public partial class _schemaField : NullableStringFieldExpression<name>
        {
            #region constructors
            public _schemaField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __schema field expression
        public partial class __schemaField : NullableStringFieldExpression<name>
        {
            #region constructors
            public __schemaField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region alias field expression
        public partial class aliasField : NullableStringFieldExpression<name>
        {
            #region constructors
            public aliasField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _alias field expression
        public partial class _aliasField : NullableStringFieldExpression<name>
        {
            #region constructors
            public _aliasField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __alias field expression
        public partial class __aliasField : NullableStringFieldExpression<name>
        {
            #region constructors
            public __aliasField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region entity field expression
        public partial class entityField : NullableStringFieldExpression<name>
        {
            #region constructors
            public entityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _entity field expression
        public partial class _entityField : NullableStringFieldExpression<name>
        {
            #region constructors
            public _entityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __entity field expression
        public partial class __entityField : NullableStringFieldExpression<name>
        {
            #region constructors
            public __entityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region schema entity expression
    public partial class schemaEntity : EntityExpression<schema>
    {
        #region internals
        private SelectExpressionSet? _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="DbEx.unit_testDataService.schemaEntity.identifierField"/> representing the "unit_test.schema.identifier" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.schemaEntity.identifierField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>identifier</description>
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
        public readonly identifierField identifier;


        /// <summary>A <see cref="DbEx.unit_testDataService.schemaEntity._identifierField"/> representing the "unit_test.schema._identifier" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.schemaEntity._identifierField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_identifier</description>
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
        public readonly _identifierField _identifier;


        /// <summary>A <see cref="DbEx.unit_testDataService.schemaEntity.__identifierField"/> representing the "unit_test.schema.__identifier" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.schemaEntity.__identifierField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__identifier</description>
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
        public readonly __identifierField __identifier;


        /// <summary>A <see cref="DbEx.unit_testDataService.schemaEntity.nameField"/> representing the "unit_test.schema.name" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.schemaEntity.nameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>name</description>
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
        public readonly nameField name;


        /// <summary>A <see cref="DbEx.unit_testDataService.schemaEntity._nameField"/> representing the "unit_test.schema._name" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.schemaEntity._nameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_name</description>
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
        public readonly _nameField _name;


        /// <summary>A <see cref="DbEx.unit_testDataService.schemaEntity.__nameField"/> representing the "unit_test.schema.__name" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.schemaEntity.__nameField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__name</description>
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
        public readonly __nameField __name;


        /// <summary>A <see cref="DbEx.unit_testDataService.schemaEntity._schemaField"/> representing the "unit_test.schema._schema" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.schemaEntity._schemaField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_schema</description>
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
        public readonly _schemaField _schema;


        /// <summary>A <see cref="DbEx.unit_testDataService.schemaEntity.__schemaField"/> representing the "unit_test.schema.__schema" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.schemaEntity.__schemaField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__schema</description>
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
        public readonly __schemaField __schema;


        /// <summary>A <see cref="DbEx.unit_testDataService.schemaEntity.aliasField"/> representing the "unit_test.schema.alias" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.schemaEntity.aliasField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>alias</description>
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
        public readonly aliasField alias;


        /// <summary>A <see cref="DbEx.unit_testDataService.schemaEntity._aliasField"/> representing the "unit_test.schema._alias" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.schemaEntity._aliasField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_alias</description>
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
        public readonly _aliasField _alias;


        /// <summary>A <see cref="DbEx.unit_testDataService.schemaEntity.__aliasField"/> representing the "unit_test.schema.__alias" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.schemaEntity.__aliasField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__alias</description>
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
        public readonly __aliasField __alias;


        /// <summary>A <see cref="DbEx.unit_testDataService.schemaEntity.entityField"/> representing the "unit_test.schema.entity" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.schemaEntity.entityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>entity</description>
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
        public readonly entityField entity;


        /// <summary>A <see cref="DbEx.unit_testDataService.schemaEntity._entityField"/> representing the "unit_test.schema._entity" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.schemaEntity._entityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>_entity</description>
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
        public readonly _entityField _entity;


        /// <summary>A <see cref="DbEx.unit_testDataService.schemaEntity.__entityField"/> representing the "unit_test.schema.__entity" column in the database, 
        /// with a .NET type of <see cref="string"/>?.  The <see cref="DbEx.unit_testDataService.schemaEntity.__entityField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>?.
        /// <para>Database Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>__entity</description>
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
        public readonly __entityField __entity;

        #endregion

        #region constructors
        public schemaEntity(string ___identifier, string ___name, Schema schema) : this(___identifier, ___name, schema, null)
        {
        }

        private schemaEntity(string ___identifier, string ___name, Schema schema, string? ___alias) : base(___identifier, ___name, schema, ___alias)
        {
            Attributes.Fields.Add($"{identifier}.identifier", identifier = new identifierField($"{___identifier}.identifier", "identifier", this));
            Attributes.Fields.Add($"{identifier}._identifier", _identifier = new _identifierField($"{___identifier}._identifier", "_identifier", this));
            Attributes.Fields.Add($"{identifier}.__identifier", __identifier = new __identifierField($"{___identifier}.__identifier", "__identifier", this));
            Attributes.Fields.Add($"{identifier}.name", name = new nameField($"{___identifier}.name", "name", this));
            Attributes.Fields.Add($"{identifier}._name", _name = new _nameField($"{___identifier}._name", "_name", this));
            Attributes.Fields.Add($"{identifier}.__name", __name = new __nameField($"{___identifier}.__name", "__name", this));
            Attributes.Fields.Add($"{identifier}._schema", _schema = new _schemaField($"{___identifier}._schema", "_schema", this));
            Attributes.Fields.Add($"{identifier}.__schema", __schema = new __schemaField($"{___identifier}.__schema", "__schema", this));
            Attributes.Fields.Add($"{identifier}.alias", alias = new aliasField($"{___identifier}.alias", "alias", this));
            Attributes.Fields.Add($"{identifier}._alias", _alias = new _aliasField($"{___identifier}._alias", "_alias", this));
            Attributes.Fields.Add($"{identifier}.__alias", __alias = new __aliasField($"{___identifier}.__alias", "__alias", this));
            Attributes.Fields.Add($"{identifier}.entity", entity = new entityField($"{___identifier}.entity", "entity", this));
            Attributes.Fields.Add($"{identifier}._entity", _entity = new _entityField($"{___identifier}._entity", "_entity", this));
            Attributes.Fields.Add($"{identifier}.__entity", __entity = new __entityField($"{___identifier}.__entity", "__entity", this));
        }
        #endregion

        #region methods
        public schemaEntity As(string alias)
            => new schemaEntity(this.Attributes.Identifier, this.Attributes.Name, this.Attributes.Schema, alias);

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return _inclusiveSelectExpressionSet ?? (_inclusiveSelectExpressionSet = new SelectExpressionSet(
                new SelectExpression<string?>(identifier)
                ,new SelectExpression<string?>(_identifier)
                ,new SelectExpression<string?>(__identifier)
                ,new SelectExpression<string?>(name)
                ,new SelectExpression<string?>(_name)
                ,new SelectExpression<string?>(__name)
                ,new SelectExpression<string?>(_schema)
                ,new SelectExpression<string?>(__schema)
                ,new SelectExpression<string?>(alias)
                ,new SelectExpression<string?>(_alias)
                ,new SelectExpression<string?>(__alias)
                ,new SelectExpression<string?>(entity)
                ,new SelectExpression<string?>(_entity)
                ,new SelectExpression<string?>(__entity)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> ___alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet? set = null;
            string? aliased = null;

            aliased = ___alias(nameof(identifier));
            set &= aliased != nameof(identifier) ? new SelectExpression<string?>(identifier, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(identifier));

            aliased = ___alias(nameof(_identifier));
            set &= aliased != nameof(_identifier) ? new SelectExpression<string?>(_identifier, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_identifier));

            aliased = ___alias(nameof(__identifier));
            set &= aliased != nameof(__identifier) ? new SelectExpression<string?>(__identifier, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__identifier));

            aliased = ___alias(nameof(name));
            set &= aliased != nameof(name) ? new SelectExpression<string?>(name, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(name));

            aliased = ___alias(nameof(_name));
            set &= aliased != nameof(_name) ? new SelectExpression<string?>(_name, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_name));

            aliased = ___alias(nameof(__name));
            set &= aliased != nameof(__name) ? new SelectExpression<string?>(__name, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__name));

            aliased = ___alias(nameof(_schema));
            set &= aliased != nameof(_schema) ? new SelectExpression<string?>(_schema, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_schema));

            aliased = ___alias(nameof(__schema));
            set &= aliased != nameof(__schema) ? new SelectExpression<string?>(__schema, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__schema));

            aliased = ___alias(nameof(alias));
            set &= aliased != nameof(alias) ? new SelectExpression<string?>(alias, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(alias));

            aliased = ___alias(nameof(_alias));
            set &= aliased != nameof(_alias) ? new SelectExpression<string?>(_alias, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_alias));

            aliased = ___alias(nameof(__alias));
            set &= aliased != nameof(__alias) ? new SelectExpression<string?>(__alias, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__alias));

            aliased = ___alias(nameof(entity));
            set &= aliased != nameof(entity) ? new SelectExpression<string?>(entity, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(entity));

            aliased = ___alias(nameof(_entity));
            set &= aliased != nameof(_entity) ? new SelectExpression<string?>(_entity, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(_entity));

            aliased = ___alias(nameof(__entity));
            set &= aliased != nameof(__entity) ? new SelectExpression<string?>(__entity, aliased) as SelectExpression<string?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(__entity));

            return set;
        }
		
        protected override InsertExpressionSet<schema> GetInclusiveInsertExpression(schema ___entity)
        {
            return new InsertExpressionSet<schema>(___entity 
                ,new InsertExpression<string?>(___entity.identifier, identifier)
                ,new InsertExpression<string?>(___entity._identifier, _identifier)
                ,new InsertExpression<string?>(___entity.__identifier, __identifier)
                ,new InsertExpression<string?>(___entity.name, name)
                ,new InsertExpression<string?>(___entity._name, _name)
                ,new InsertExpression<string?>(___entity.__name, __name)
                ,new InsertExpression<string?>(___entity._schema, _schema)
                ,new InsertExpression<string?>(___entity.__schema, __schema)
                ,new InsertExpression<string?>(___entity.alias, alias)
                ,new InsertExpression<string?>(___entity._alias, _alias)
                ,new InsertExpression<string?>(___entity.__alias, __alias)
                ,new InsertExpression<string?>(___entity.entity, entity)
                ,new InsertExpression<string?>(___entity._entity, _entity)
                ,new InsertExpression<string?>(___entity.__entity, __entity)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(schema target, schema source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.identifier != source.identifier) { expr &= identifier.Set(source.identifier); }
            if (target._identifier != source._identifier) { expr &= _identifier.Set(source._identifier); }
            if (target.__identifier != source.__identifier) { expr &= __identifier.Set(source.__identifier); }
            if (target.name != source.name) { expr &= name.Set(source.name); }
            if (target._name != source._name) { expr &= _name.Set(source._name); }
            if (target.__name != source.__name) { expr &= __name.Set(source.__name); }
            if (target._schema != source._schema) { expr &= _schema.Set(source._schema); }
            if (target.__schema != source.__schema) { expr &= __schema.Set(source.__schema); }
            if (target.alias != source.alias) { expr &= alias.Set(source.alias); }
            if (target._alias != source._alias) { expr &= _alias.Set(source._alias); }
            if (target.__alias != source.__alias) { expr &= __alias.Set(source.__alias); }
            if (target.entity != source.entity) { expr &= entity.Set(source.entity); }
            if (target._entity != source._entity) { expr &= _entity.Set(source._entity); }
            if (target.__entity != source.__entity) { expr &= __entity.Set(source.__entity); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, schema ___entity)
        {
            ___entity.identifier = reader.ReadField()!.GetValue<string?>();
            ___entity._identifier = reader.ReadField()!.GetValue<string?>();
            ___entity.__identifier = reader.ReadField()!.GetValue<string?>();
            ___entity.name = reader.ReadField()!.GetValue<string?>();
            ___entity._name = reader.ReadField()!.GetValue<string?>();
            ___entity.__name = reader.ReadField()!.GetValue<string?>();
            ___entity._schema = reader.ReadField()!.GetValue<string?>();
            ___entity.__schema = reader.ReadField()!.GetValue<string?>();
            ___entity.alias = reader.ReadField()!.GetValue<string?>();
            ___entity._alias = reader.ReadField()!.GetValue<string?>();
            ___entity.__alias = reader.ReadField()!.GetValue<string?>();
            ___entity.entity = reader.ReadField()!.GetValue<string?>();
            ___entity._entity = reader.ReadField()!.GetValue<string?>();
            ___entity.__entity = reader.ReadField()!.GetValue<string?>();
        }
		#endregion

        #region classes
        #region identifier field expression
        public partial class identifierField : NullableStringFieldExpression<schema>
        {
            #region constructors
            public identifierField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _identifier field expression
        public partial class _identifierField : NullableStringFieldExpression<schema>
        {
            #region constructors
            public _identifierField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __identifier field expression
        public partial class __identifierField : NullableStringFieldExpression<schema>
        {
            #region constructors
            public __identifierField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region name field expression
        public partial class nameField : NullableStringFieldExpression<schema>
        {
            #region constructors
            public nameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _name field expression
        public partial class _nameField : NullableStringFieldExpression<schema>
        {
            #region constructors
            public _nameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __name field expression
        public partial class __nameField : NullableStringFieldExpression<schema>
        {
            #region constructors
            public __nameField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _schema field expression
        public partial class _schemaField : NullableStringFieldExpression<schema>
        {
            #region constructors
            public _schemaField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __schema field expression
        public partial class __schemaField : NullableStringFieldExpression<schema>
        {
            #region constructors
            public __schemaField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region alias field expression
        public partial class aliasField : NullableStringFieldExpression<schema>
        {
            #region constructors
            public aliasField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _alias field expression
        public partial class _aliasField : NullableStringFieldExpression<schema>
        {
            #region constructors
            public _aliasField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __alias field expression
        public partial class __aliasField : NullableStringFieldExpression<schema>
        {
            #region constructors
            public __aliasField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region entity field expression
        public partial class entityField : NullableStringFieldExpression<schema>
        {
            #region constructors
            public entityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region _entity field expression
        public partial class _entityField : NullableStringFieldExpression<schema>
        {
            #region constructors
            public _entityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region __entity field expression
        public partial class __entityField : NullableStringFieldExpression<schema>
        {
            #region constructors
            public __entityField(string identifier, string name, Table entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set((string TableName, string FieldName) value) => new AssignmentExpression(this, new AliasExpression<string?>(value));
            public AssignmentExpression Set(NullElement value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(string? value) => new AssignmentExpression(this, new LiteralExpression<string?>(value, this));
            public AssignmentExpression Set(AnyStringElement value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #endregion
    }
    #endregion

    #region unit_test
#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
#pragma warning disable IDE1006 // Naming Styles
    public partial class unit_test
#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
    {
        private static unit_testSchemaExpression? _schema;

        #region interface
        /// <summary>A <see cref="DbEx.unit_testDataService.aliasEntity"/> representing the "unit_test.alias" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>alias</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public static aliasEntity alias { get; private set; } = null!;

        /// <summary>A <see cref="DbEx.unit_testDataService.entityEntity"/> representing the "unit_test.entity" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>entity</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public static entityEntity entity { get; private set; } = null!;

        /// <summary>A <see cref="DbEx.unit_testDataService.ExpressionElementTypeEntity"/> representing the "unit_test.ExpressionElementType" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>ExpressionElementType</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public static ExpressionElementTypeEntity ExpressionElementType { get; private set; } = null!;

        /// <summary>A <see cref="DbEx.unit_testDataService.identifierEntity"/> representing the "unit_test.identifier" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>identifier</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public static identifierEntity identifier { get; private set; } = null!;

        /// <summary>A <see cref="DbEx.unit_testDataService.nameEntity"/> representing the "unit_test.name" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>name</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public static nameEntity name { get; private set; } = null!;

        /// <summary>A <see cref="DbEx.unit_testDataService.schemaEntity"/> representing the "unit_test.schema" table in the database.
        /// <para>Properties:
        /// <list type="table">
        /// <item>
        /// <term>name</term><description>schema</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public static schemaEntity schema { get; private set; } = null!;

        #endregion

        #region use schema
        public static void UseSchema(unit_testSchemaExpression _schema)
        { 
            if (_schema == null)
                 throw new ArgumentNullException(nameof(_schema));

            unit_test._schema = _schema;

            alias = _schema.alias;
            entity = _schema.entity;
            ExpressionElementType = _schema.ExpressionElementType;
            identifier = _schema.identifier;
            name = _schema.name;
            schema = _schema.schema;
        }
        #endregion
    }
    #endregion
}

namespace DbEx.secDataService
{
	using DbEx.secData;
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
        private SelectExpressionSet? _inclusiveSelectExpressionSet;
        #endregion

        #region interface

        /// <summary>A <see cref="DbEx.secDataService.PersonEntity.IdField"/> representing the "sec.Person.Id" column in the database, 
        /// with a .NET type of <see cref="int"/>.  The <see cref="DbEx.secDataService.PersonEntity.IdField"/> can be 
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


        /// <summary>A <see cref="DbEx.secDataService.PersonEntity.SocialSecurityNumberField"/> representing the "sec.Person.SSN" column in the database, 
        /// with a .NET type of <see cref="string"/>.  The <see cref="DbEx.secDataService.PersonEntity.SocialSecurityNumberField"/> can be 
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
        public readonly SocialSecurityNumberField SocialSecurityNumber;


        /// <summary>A <see cref="DbEx.secDataService.PersonEntity.DateCreatedField"/> representing the "sec.Person.DateCreated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.secDataService.PersonEntity.DateCreatedField"/> can be 
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


        /// <summary>A <see cref="DbEx.secDataService.PersonEntity.DateUpdatedField"/> representing the "sec.Person.DateUpdated" column in the database, 
        /// with a .NET type of <see cref="DateTime"/>.  The <see cref="DbEx.secDataService.PersonEntity.DateUpdatedField"/> can be 
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

        private PersonEntity(string identifier, string name, Schema schema, string? alias) : base(identifier, name, schema, alias)
        {
            Attributes.Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Attributes.Fields.Add($"{identifier}.SocialSecurityNumber", SocialSecurityNumber = new SocialSecurityNumberField($"{identifier}.SocialSecurityNumber", "SocialSecurityNumber", this));
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
                ,new SelectExpression<string>(SocialSecurityNumber)
                ,new SelectExpression<DateTime>(DateCreated)
                ,new SelectExpression<DateTime>(DateUpdated)
            ));
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression(Func<string, string> alias)
        {
            if (alias is null)
                throw new ArgumentNullException(nameof(alias));

            SelectExpressionSet? set = null;
            string? aliased = null;

            aliased = alias(nameof(Id));
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id, aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(Id));

            aliased = alias(nameof(SocialSecurityNumber));
            set &= aliased != nameof(SocialSecurityNumber) ? new SelectExpression<string>(SocialSecurityNumber, aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(SocialSecurityNumber));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated, aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider)?.Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<Person> GetInclusiveInsertExpression(Person entity)
        {
            return new InsertExpressionSet<Person>(entity 
                ,new InsertExpression<int>(entity.Id, Id)
                ,new InsertExpression<string>(entity.SocialSecurityNumber, SocialSecurityNumber)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person target, Person source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.Id != source.Id) { expr &= Id.Set(source.Id); }
            if (target.SocialSecurityNumber != source.SocialSecurityNumber) { expr &= SocialSecurityNumber.Set(source.SocialSecurityNumber); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, Person entity)
        {
            entity.Id = reader.ReadField()!.GetValue<int>();
            entity.SocialSecurityNumber = reader.ReadField()!.GetValue<string>();
            entity.DateCreated = reader.ReadField()!.GetValue<DateTime>();
            entity.DateUpdated = reader.ReadField()!.GetValue<DateTime>();
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

        #region social security number field expression
        public partial class SocialSecurityNumberField : StringFieldExpression<Person>
        {
            #region constructors
            public SocialSecurityNumberField(string identifier, string name, Table entity) : base(identifier, name, entity)
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
        private static secSchemaExpression? schema;

        #region interface
        /// <summary>A <see cref="DbEx.secDataService.PersonEntity"/> representing the "sec.Person" table in the database.
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
        public static PersonEntity Person { get; private set; } = null!;

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
