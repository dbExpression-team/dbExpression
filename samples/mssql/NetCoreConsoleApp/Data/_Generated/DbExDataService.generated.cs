using HatTrick.DbEx.MsSql.Builder;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
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

    #region runtime db
    public abstract partial class SimpleConsoleDbRuntimeSqlDatabase : IRuntimeSqlDatabase, IExpressionListProvider<SchemaExpression>
    {
        #region internals
        protected static readonly MsSqlQueryExpressionBuilderFactory expressionBuilderFactory = new MsSqlQueryExpressionBuilderFactory();
        protected static readonly IList<SchemaExpression> schemas = new List<SchemaExpression>();
        protected static RuntimeSqlDatabaseConfiguration configuration => configurationFactory.CreateConfiguration() ?? throw new DbExpressionConfigurationException($"Configuration factory returned a null value for configuration ({nameof(RuntimeSqlDatabaseConfiguration)}).  Cannot build and execute queries without valid configuration.");
        private static IRuntimeSqlDatabaseConfigurationFactory configurationFactory;
        #endregion

        #region interface
        IEnumerable<SchemaExpression> IExpressionListProvider<SchemaExpression>.Expressions => schemas;
        #endregion

        #region methods
        void IRuntimeSqlDatabase.UseConfigurationFactory(IRuntimeSqlDatabaseConfigurationFactory configurationFactory)
            => SimpleConsoleDbRuntimeSqlDatabase.configurationFactory = configurationFactory ?? throw new ArgumentNullException(nameof(configurationFactory));
        #endregion
    }
    #endregion

    #region db
    public partial class db : SimpleConsoleDbRuntimeSqlDatabase
    {
        #region constructors
        static db()
        {
            var dboSchema = new _dboDataService.dboSchemaExpression("dbo");
            schemas.Add(dboSchema);
            _dboDataService.dbo.UseSchema(dboSchema);

            var secSchema = new _secDataService.secSchemaExpression("sec");
            schemas.Add(secSchema);
            _secDataService.sec.UseSchema(secSchema);

        }
        #endregion

        #region methods
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
        /// <returns><see cref="SelectEntity{TEntity}"/>, a fluent builder for constructing a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        /// <typeparam name="TEntity">The entity type to select.</typeparam>
        public static SelectEntity<TEntity> SelectOne<TEntity>()
            where TEntity : class, IDbEntity, new()
            => expressionBuilderFactory.CreateSelectEntityBuilder<TEntity>(configuration);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <typeparamref name="TEnum"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />
        ///, for example "dbo.AccessAuditLog.AccessResult"
        /// </param>
        /// <returns><see cref="Sql.SelectValue{TEnum}"/>, a fluent builder for constructing a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        /// <typeparam name="TEnum">The type of the Enum to select.</typeparam>
        public static SelectValue<TEnum> SelectOne<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => expressionBuilderFactory.CreateSelectValueBuilder<TEnum>(configuration, element);

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
            => expressionBuilderFactory.CreateSelectValueBuilder<TEnum>(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="object" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Object}" />?
        ///, for example "dbo.AccessAuditLog.AccessResult"
        /// </param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<object> SelectOne(AnyElement<object> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="bool" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<bool> SelectOne(AnyElement<bool> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="bool" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />?
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<bool?> SelectOne(AnyElement<bool?> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<byte> SelectOne(AnyElement<byte> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />?
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<byte?> SelectOne(AnyElement<byte?> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="byte" />[] value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte[]}" />
        ///, for example "dbo.Product.Image" or "db.fx.IsNull(dbo.Product.Image, new byte[0])"
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<byte[]> SelectOne(AnyElement<byte[]> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTime" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />
        ///, for example "dbo.AccessAuditLog.DateCreated", "db.fx.DateAdd(DateParts.Year, 1, dbo.AccessAuditLog.DateCreated) or "db.fx.IsNull(dbo.AccessAuditLog.DateCreated, DateTime.Now)"
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<DateTime> SelectOne(AnyElement<DateTime> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTime" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />?
        ///, for example "dbo.Person.BirthDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.BirthDate)
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<DateTime?> SelectOne(AnyElement<DateTime?> field)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, field);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTimeOffset" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />
        ///, for example "dbo.Person.RegistrationDate", "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.RegistrationDate)" or "db.fx.IsNull(dbo.Person.RegistrationDate, DateTimeOffset.Now)"
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<DateTimeOffset> SelectOne(AnyElement<DateTimeOffset> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="DateTimeOffset" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />?
        ///, for example "dbo.Person.LastLoginDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.LastLoginDate)" 
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<DateTimeOffset?> SelectOne(AnyElement<DateTimeOffset?> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="decimal" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />
        ///, for example "dbo.Product.ShippingWeight" or "db.fx.IsNull(dbo.Product.ShippingWeight, decimal.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<decimal> SelectOne(AnyElement<decimal> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="decimal" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />?
        ///, for example "dbo.Product.Height" or "db.fx.Min(dbo.Product.Height)"
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<decimal?> SelectOne(AnyElement<decimal?> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="double" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />
        ///, for example "dbo.Product.ListPrice" or "db.fx.IsNull(dbo.Product.ListPrice, double.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<double> SelectOne(AnyElement<double> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="double" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />?
        ///, for example "dbo.PersonTotalPurchasesView.TotalAmount" or "db.fx.Min(dbo.PersonTotalPurchasesView.TotalAmount)"
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<double?> SelectOne(AnyElement<double?> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="Guid" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<Guid> SelectOne(AnyElement<Guid> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="Guid" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />?
        ///, for example "dbo.Purchase.TrackingIdentifier"
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<Guid?> SelectOne(AnyElement<Guid?> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="short" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<short> SelectOne(AnyElement<short> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="short" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />?
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<short?> SelectOne(AnyElement<short?> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="int" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />?
        ///, for example "dbo.AccessAuditLog.Id" or "db.fx.Avg(dbo.AccessAuditLog.Id)"
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<int> SelectOne(AnyElement<int> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="int" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />?
        ///, for example "dbo.Person.CreditLimit" or "db.fx.Avg(dbo.Person.CreditLimit)"
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<int?> SelectOne(AnyElement<int?> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="long" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<long> SelectOne(AnyElement<long> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="long" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />?
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<long?> SelectOne(AnyElement<long?> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="float" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<float> SelectOne(AnyElement<float> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="float" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />?
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<float?> SelectOne(AnyElement<float?> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="string" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<string> SelectOne(AnyElement<string> element) 
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="TimeSpan" /> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<TimeSpan> SelectOne(AnyElement<TimeSpan> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="TimeSpan" />? value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />?
        ///, for example "dbo.Product.ValidStartTimeOfDayForPurchase"
        ///</param>
        /// <returns><see cref="SelectValue{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValue<TimeSpan?> SelectOne(AnyElement<TimeSpan?> element)
            => expressionBuilderFactory.CreateSelectValueBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a single <see cref="System.Dynamic.ExpandoObject" /> object.  The properties of the object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element1">Any expression</param>
        /// <param name="element2">Any expression</param>
        /// <param name="elements">Any expression</param>
        /// <returns><see cref="SelectDynamic"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectDynamic SelectOne(AnyElement element1, AnyElement element2, params AnyElement[] elements)
            => expressionBuilderFactory.CreateSelectDynamicBuilder(configuration, element1, element2, elements);

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
            => expressionBuilderFactory.CreateSelectDynamicBuilder(configuration, elements);

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
            => expressionBuilderFactory.CreateSelectDynamicBuilder(configuration, (elements ?? throw new ArgumentNullException(nameof(elements))).Concat(additionalElements));
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
        /// <returns><see cref="SelectEntities{TEntity}"/>, a fluent builder for constructing a sql SELECT query expression for a list of <typeparamref name="TEntity"/> entities.</returns>
        /// <typeparam name="TEntity">The entity type to select.</typeparam>
        public static SelectEntities<TEntity> SelectMany<TEntity>()
           where TEntity : class, IDbEntity, new()
           => expressionBuilderFactory.CreateSelectEntitiesBuilder<TEntity>(configuration);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <typeparamref name="TEnum"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}" />
        ///, for example "dbo.AccessAuditLog.AccessResult"
        /// </param>
        /// <returns><see cref="SelectValues{TEnum}"/>, a fluent builder for constructing a sql SELECT query expression for a list of <typeparamref name="TEntity"/> entities.</returns>
        public static SelectValues<TEnum> SelectMany<TEnum>(AnyElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => expressionBuilderFactory.CreateSelectValuesBuilder<TEnum>(configuration, element);

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
            => expressionBuilderFactory.CreateSelectValuesBuilder<TEnum>(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="object" /> values.
        /// </summary>
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// <param name="element">An expression of type <see cref="AnyElement{Object}" />
        ///, for example "db.fx.Coalesce(dbo.Person.CreditLimit, dbo.Address.Line1)"
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<object> SelectMany(AnyElement<object> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="bool" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<bool> SelectMany(AnyElement<bool> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="bool" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}" />?
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<bool?> SelectMany(AnyElement<bool?> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<byte> SelectMany(AnyElement<byte> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}" />?
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<byte?> SelectMany(AnyElement<byte?> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="byte" />[] values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte[]}" />
        ///, for example "dbo.Product.Image" or "db.fx.IsNull(dbo.Product.Image, new byte[0])"
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<byte[]> SelectMany(AnyElement<byte[]> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTime" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />
        ///, for example "dbo.AccessAuditLog.DateCreated", "db.fx.DateAdd(DateParts.Year, 1, dbo.AccessAuditLog.DateCreated) or "db.fx.IsNull(dbo.AccessAuditLog.DateCreated, DateTime.Now)"
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<DateTime> SelectMany(AnyElement<DateTime> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTime" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}" />?
        ///, for example "dbo.Person.BirthDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.BirthDate)
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<DateTime?> SelectMany(AnyElement<DateTime?> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTimeOffset" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />
        ///, for example "dbo.Person.RegistrationDate", "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.RegistrationDate)" or "db.fx.IsNull(dbo.Person.RegistrationDate, DateTimeOffset.Now)"
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<DateTimeOffset> SelectMany(AnyElement<DateTimeOffset> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="DateTimeOffset" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}" />?
        ///, for example "dbo.Person.LastLoginDate" or "db.fx.DateAdd(DateParts.Year, 1, dbo.Person.LastLoginDate)" 
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<DateTimeOffset?> SelectMany(AnyElement<DateTimeOffset?> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="decimal" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />
        ///, for example "dbo.Product.ShippingWeight" or "db.fx.IsNull(dbo.Product.ShippingWeight, decimal.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<decimal> SelectMany(AnyElement<decimal> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="decimal" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}" />?
        ///, for example "dbo.Product.Height"
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<decimal?> SelectMany(AnyElement<decimal?> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="double" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />
        ///, for example "dbo.Product.ListPrice" or "db.fx.IsNull(dbo.Product.ListPrice, double.MinValue)"
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<double> SelectMany(AnyElement<double> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="double" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}" />?
        ///, for example "dbo.PersonTotalPurchasesView.TotalAmount"
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<double?> SelectMany(AnyElement<double?> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="Guid" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<Guid> SelectMany(AnyElement<Guid> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="Guid" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}" />?
        ///, for example "dbo.Purchase.TrackingIdentifier"
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<Guid?> SelectMany(AnyElement<Guid?> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="short" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<short> SelectMany(AnyElement<short> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="short" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}" />?
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<short?> SelectMany(AnyElement<short?> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="int" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />
        ///, for example "dbo.AccessAuditLog.Id"
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<int> SelectMany(AnyElement<int> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="int" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}" />?
        ///, for example "dbo.:column.Entity.Name}.CreditLimit"
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<int?> SelectMany(AnyElement<int?> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="long" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<long> SelectMany(AnyElement<long> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="long" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}" />?
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<long?> SelectMany(AnyElement<long?> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="float" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<float> SelectMany(AnyElement<float> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="float" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}" />?
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<float?> SelectMany(AnyElement<float?> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="string" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}" />
        ///, for example "dbo.Address.Line1" or "db.fx.Concat("Value: ", dbo.Address.Line1)"
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<string> SelectMany(AnyElement<string> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="TimeSpan" /> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<TimeSpan> SelectMany(AnyElement<TimeSpan> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="TimeSpan" />? values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}" />?
        ///, for example "dbo.Product.ValidStartTimeOfDayForPurchase"
        ///</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectValues<TimeSpan?> SelectMany(AnyElement<TimeSpan?> element)
            => expressionBuilderFactory.CreateSelectValuesBuilder(configuration, element);

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
            => expressionBuilderFactory.CreateSelectDynamicsBuilder(configuration, element1, element2, elements);

        /// <summary>
        /// Start constructing a sql SELECT query expression for a list of <see cref="System.Dynamic.ExpandoObject" /> objects.  The dynamic properties of each object are defined by the <see cref="AnyElement" /> method parameters.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="elements">A list of any expression</param>
        /// <returns><see cref="SelectDynamics"/>, a fluent builder for constructing a sql SELECT query expression.</returns>
        public static SelectDynamics SelectMany(IEnumerable<AnyElement> elements)
            => expressionBuilderFactory.CreateSelectDynamicsBuilder(configuration, elements);

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
            => expressionBuilderFactory.CreateSelectDynamicsBuilder(configuration, (elements ?? throw new ArgumentNullException(nameof(elements))).Concat(additionalElements));
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
            => expressionBuilderFactory.CreateUpdateExpressionBuilder(configuration, assignment, assignments);

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
            => expressionBuilderFactory.CreateUpdateExpressionBuilder(configuration, assignments);   
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
            => expressionBuilderFactory.CreateDeleteExpressionBulder(configuration);
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
            => expressionBuilderFactory.CreateInsertExpressionBuilder(configuration, entity);

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
            => expressionBuilderFactory.CreateInsertExpressionBuilder(configuration, entity, entities);

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
            => expressionBuilderFactory.CreateInsertExpressionBuilder(configuration, entities);
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
            => new SqlConnector(configuration.ConnectionStringFactory, configuration.ConnectionFactory);
        #endregion
        #endregion

        #region fx
        /// <inheritdoc />
        public partial class fx : MsSqlFunctionExpressionBuilder
        {
        }
        #endregion

        #region sp
        /// <inheritdoc />
        public partial class sp : MsSqlStoredProcedureExpressionBuilder
        {
            /// <summary>
            /// Accessors to construct and execute stored procedure query expressions in the dbo schema.
            /// </summary>
            public partial class dbo
            {
                /// <summary>
                /// Method to start constructing a stored procedure query expression for the SelectPerson_As_Dynamic_With_Input stored procedure.
                /// </summary>
                /// <param name="P1">The value to use for creating the database parameter @P1.
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
                public static StoredProcedureContinuation SelectPerson_As_Dynamic_With_Input(int? P1)
                    => expressionBuilderFactory.CreateStoredProcedureBuilder(configuration, new SelectPerson_As_Dynamic_With_InputStoredProcedure("dbo", schemas.Single(s => s.Identifier == "dbo"), P1));

                /// <summary>
                /// Method to start constructing a stored procedure query expression for the SelectPerson_As_Dynamic_With_Input_And_InputOutput stored procedure.
                /// </summary>
                /// <param name="P1">The value to use for creating the database parameter @P1.
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
                public static StoredProcedureContinuation SelectPerson_As_Dynamic_With_Input_And_InputOutput(int? P1, Action<ISqlOutputParameterList> outputParameters)
                    => expressionBuilderFactory.CreateStoredProcedureBuilder(configuration, new SelectPerson_As_Dynamic_With_Input_And_InputOutputStoredProcedure("dbo", schemas.Single(s => s.Identifier == "dbo"), P1, outputParameters));

                /// <summary>
                /// Method to start constructing a stored procedure query expression for the SelectPerson_As_Dynamic_With_Input_And_Output stored procedure.
                /// </summary>
                /// <param name="P1">The value to use for creating the database parameter @P1.
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
                public static StoredProcedureContinuation SelectPerson_As_Dynamic_With_Input_And_Output(int? P1, Action<ISqlOutputParameterList> outputParameters)
                    => expressionBuilderFactory.CreateStoredProcedureBuilder(configuration, new SelectPerson_As_Dynamic_With_Input_And_OutputStoredProcedure("dbo", schemas.Single(s => s.Identifier == "dbo"), P1, outputParameters));

                /// <summary>
                /// Method to start constructing a stored procedure query expression for the SelectPerson_As_DynamicList_With_Input stored procedure.
                /// </summary>
                /// <param name="P1">The value to use for creating the database parameter @P1.
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
                public static StoredProcedureContinuation SelectPerson_As_DynamicList_With_Input(int? P1)
                    => expressionBuilderFactory.CreateStoredProcedureBuilder(configuration, new SelectPerson_As_DynamicList_With_InputStoredProcedure("dbo", schemas.Single(s => s.Identifier == "dbo"), P1));

                /// <summary>
                /// Method to start constructing a stored procedure query expression for the SelectPerson_As_DynamicList_With_Input_And_InputOutput stored procedure.
                /// </summary>
                /// <param name="P1">The value to use for creating the database parameter @P1.
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
                public static StoredProcedureContinuation SelectPerson_As_DynamicList_With_Input_And_InputOutput(int? P1, Action<ISqlOutputParameterList> outputParameters)
                    => expressionBuilderFactory.CreateStoredProcedureBuilder(configuration, new SelectPerson_As_DynamicList_With_Input_And_InputOutputStoredProcedure("dbo", schemas.Single(s => s.Identifier == "dbo"), P1, outputParameters));

                /// <summary>
                /// Method to start constructing a stored procedure query expression for the SelectPerson_As_DynamicList_With_Input_And_Output stored procedure.
                /// </summary>
                /// <param name="P1">The value to use for creating the database parameter @P1.
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
                public static StoredProcedureContinuation SelectPerson_As_DynamicList_With_Input_And_Output(int? P1, Action<ISqlOutputParameterList> outputParameters)
                    => expressionBuilderFactory.CreateStoredProcedureBuilder(configuration, new SelectPerson_As_DynamicList_With_Input_And_OutputStoredProcedure("dbo", schemas.Single(s => s.Identifier == "dbo"), P1, outputParameters));

                /// <summary>
                /// Method to start constructing a stored procedure query expression for the SelectPersonId_As_ScalarValue_With_Input stored procedure.
                /// </summary>
                /// <param name="P1">The value to use for creating the database parameter @P1.
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
                public static StoredProcedureContinuation SelectPersonId_As_ScalarValue_With_Input(int? P1)
                    => expressionBuilderFactory.CreateStoredProcedureBuilder(configuration, new SelectPersonId_As_ScalarValue_With_InputStoredProcedure("dbo", schemas.Single(s => s.Identifier == "dbo"), P1));

                /// <summary>
                /// Method to start constructing a stored procedure query expression for the SelectPersonId_As_ScalarValue_With_Input_And_Default_Value stored procedure.
                /// </summary>
                /// <param name="P1">The value to use for creating the database parameter @P1.
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
                public static StoredProcedureContinuation SelectPersonId_As_ScalarValue_With_Input_And_Default_Value(int? P1)
                    => expressionBuilderFactory.CreateStoredProcedureBuilder(configuration, new SelectPersonId_As_ScalarValue_With_Input_And_Default_ValueStoredProcedure("dbo", schemas.Single(s => s.Identifier == "dbo"), P1));

                /// <summary>
                /// Method to start constructing a stored procedure query expression for the SelectPersonId_As_ScalarValue_With_Input_And_InputOutput stored procedure.
                /// </summary>
                /// <param name="P1">The value to use for creating the database parameter @P1.
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
                public static StoredProcedureContinuation SelectPersonId_As_ScalarValue_With_Input_And_InputOutput(int? P1, Action<ISqlOutputParameterList> outputParameters)
                    => expressionBuilderFactory.CreateStoredProcedureBuilder(configuration, new SelectPersonId_As_ScalarValue_With_Input_And_InputOutputStoredProcedure("dbo", schemas.Single(s => s.Identifier == "dbo"), P1, outputParameters));

                /// <summary>
                /// Method to start constructing a stored procedure query expression for the SelectPersonId_As_ScalarValue_With_Input_And_Output stored procedure.
                /// </summary>
                /// <param name="P1">The value to use for creating the database parameter @P1.
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
                public static StoredProcedureContinuation SelectPersonId_As_ScalarValue_With_Input_And_Output(int? P1, Action<ISqlOutputParameterList> outputParameters)
                    => expressionBuilderFactory.CreateStoredProcedureBuilder(configuration, new SelectPersonId_As_ScalarValue_With_Input_And_OutputStoredProcedure("dbo", schemas.Single(s => s.Identifier == "dbo"), P1, outputParameters));

                /// <summary>
                /// Method to start constructing a stored procedure query expression for the SelectPersonId_As_ScalarValueList_With_Input stored procedure.
                /// </summary>
                /// <param name="P1">The value to use for creating the database parameter @P1.
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
                public static StoredProcedureContinuation SelectPersonId_As_ScalarValueList_With_Input(int? P1)
                    => expressionBuilderFactory.CreateStoredProcedureBuilder(configuration, new SelectPersonId_As_ScalarValueList_With_InputStoredProcedure("dbo", schemas.Single(s => s.Identifier == "dbo"), P1));

                /// <summary>
                /// Method to start constructing a stored procedure query expression for the SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput stored procedure.
                /// </summary>
                /// <param name="P1">The value to use for creating the database parameter @P1.
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
                public static StoredProcedureContinuation SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput(int? P1, Action<ISqlOutputParameterList> outputParameters)
                    => expressionBuilderFactory.CreateStoredProcedureBuilder(configuration, new SelectPersonId_As_ScalarValueList_With_Input_And_InputOutputStoredProcedure("dbo", schemas.Single(s => s.Identifier == "dbo"), P1, outputParameters));

                /// <summary>
                /// Method to start constructing a stored procedure query expression for the SelectPersonId_As_ScalarValueList_With_Input_And_Output stored procedure.
                /// </summary>
                /// <param name="P1">The value to use for creating the database parameter @P1.
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
                public static StoredProcedureContinuation SelectPersonId_As_ScalarValueList_With_Input_And_Output(int? P1, Action<ISqlOutputParameterList> outputParameters)
                    => expressionBuilderFactory.CreateStoredProcedureBuilder(configuration, new SelectPersonId_As_ScalarValueList_With_Input_And_OutputStoredProcedure("dbo", schemas.Single(s => s.Identifier == "dbo"), P1, outputParameters));

                /// <summary>
                /// Method to start constructing a stored procedure query expression for the UpdatePersonCreditLimit_With_Inputs stored procedure.
                /// </summary>
                /// <param name="P1">The value to use for creating the database parameter @P1.
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
                /// <param name="CreditLimit">The value to use for creating the database parameter @CreditLimit.
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
                public static StoredProcedureContinuation UpdatePersonCreditLimit_With_Inputs(int? P1,int? CreditLimit)
                    => expressionBuilderFactory.CreateStoredProcedureBuilder(configuration, new UpdatePersonCreditLimit_With_InputsStoredProcedure("dbo", schemas.Single(s => s.Identifier == "dbo"), P1, CreditLimit));

            }

            /// <summary>
            /// Accessors to construct and execute stored procedure query expressions in the sec schema.
            /// </summary>
            public partial class sec
            {
            }

        }
        #endregion
    }
    #endregion

    #region runtime environment db
    public class SimpleConsoleDb : RuntimeEnvironmentSqlDatabase
    {
        public SimpleConsoleDb() : base(new db(), new SqlDatabaseMetadataProvider(new SimpleConsoleDbSqlDatabaseMetadata("SimpleConsoleDb", "MsSqlDbExTest")))
        { }
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
        public dboSchemaExpression(string identifier) : base(identifier, null)
        {
            Entities.Add($"{identifier}.AccessAuditLog", AccessAuditLog = new AccessAuditLogEntity($"{identifier}.AccessAuditLog", "AccessAuditLog", this));
            Entities.Add($"{identifier}.Address", Address = new AddressEntity($"{identifier}.Address", "Address", this));
            Entities.Add($"{identifier}.Person", Person = new PersonEntity($"{identifier}.Person", "Person", this));
            Entities.Add($"{identifier}.Person_Address", PersonAddress = new PersonAddressEntity($"{identifier}.Person_Address", "Person_Address", this));
            Entities.Add($"{identifier}.Product", Product = new ProductEntity($"{identifier}.Product", "Product", this));
            Entities.Add($"{identifier}.Purchase", Purchase = new PurchaseEntity($"{identifier}.Purchase", "Purchase", this));
            Entities.Add($"{identifier}.PurchaseLine", PurchaseLine = new PurchaseLineEntity($"{identifier}.PurchaseLine", "PurchaseLine", this));
            Entities.Add($"{identifier}.PersonTotalPurchasesView", PersonTotalPurchasesView = new PersonTotalPurchasesViewEntity($"{identifier}.PersonTotalPurchasesView", "PersonTotalPurchasesView", this));
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
        private AccessAuditLogEntity() : base(null, null, null, null)
        {
        }

        public AccessAuditLogEntity(string identifier, string name, SchemaExpression schema) : this(identifier, name, schema, null)
        {
        }

        private AccessAuditLogEntity(string identifier, string name, SchemaExpression schema, string alias) : base(identifier, name, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Fields.Add($"{identifier}.PersonId", PersonId = new PersonIdField($"{identifier}.PersonId", "PersonId", this));
            Fields.Add($"{identifier}.AccessResult", AccessResult = new AccessResultField($"{identifier}.AccessResult", "AccessResult", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
        }
        #endregion

        #region methods
        public AccessAuditLogEntity As(string name)
            => new AccessAuditLogEntity(this.identifier, this.name, this.schema, name);

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
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(PersonId));
            set &= aliased != nameof(PersonId) ? new SelectExpression<int>(PersonId).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PersonId));

            aliased = alias(nameof(AccessResult));
            set &= aliased != nameof(AccessResult) ? new SelectExpression<SimpleConsole.Data.AccessAuditResult>(AccessResult).As(aliased) as SelectExpression<SimpleConsole.Data.AccessAuditResult> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(AccessResult));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated).As(aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            return set;
        }
		
        protected override InsertExpressionSet<AccessAuditLog> GetInclusiveInsertExpression(AccessAuditLog accessAuditLog)
        {
            return new InsertExpressionSet<AccessAuditLog>(accessAuditLog 
                ,new InsertExpression<int>(accessAuditLog.PersonId, PersonId)
                ,new InsertExpression<SimpleConsole.Data.AccessAuditResult>(accessAuditLog.AccessResult, AccessResult)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(AccessAuditLog target, AccessAuditLog source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.PersonId != source.PersonId) { expr &= PersonId.Set(source.PersonId); }
            if (target.AccessResult != source.AccessResult) { expr &= AccessResult.Set(source.AccessResult); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, AccessAuditLog accessAuditLog)
        {
            accessAuditLog.Id = reader.ReadField().GetValue<int>();
            accessAuditLog.PersonId = reader.ReadField().GetValue<int>();
            accessAuditLog.AccessResult = reader.ReadField().GetValue<SimpleConsole.Data.AccessAuditResult>();
            accessAuditLog.DateCreated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<AccessAuditLog>
        {
            #region constructors
            public IdField(string identifier, string name, AccessAuditLogEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            #endregion
        }
        #endregion

        #region person id field expression
        public partial class PersonIdField : Int32FieldExpression<AccessAuditLog>
        {
            #region constructors
            public PersonIdField(string identifier, string name, AccessAuditLogEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region access result field expression
        public partial class AccessResultField : EnumFieldExpression<AccessAuditLog,SimpleConsole.Data.AccessAuditResult>
        {
            #region constructors
            public AccessResultField(string identifier, string name, AccessAuditLogEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(SimpleConsole.Data.AccessAuditResult value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.AccessAuditResult>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.AccessAuditResult> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<AccessAuditLog>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, AccessAuditLogEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
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
        /// with a .NET type of <see cref="string"/>.  The <see cref="SimpleConsole.dboDataService.AddressEntity.Line2Field"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>.
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
        private AddressEntity() : base(null, null, null, null)
        {
        }

        public AddressEntity(string identifier, string name, SchemaExpression schema) : this(identifier, name, schema, null)
        {
        }

        private AddressEntity(string identifier, string name, SchemaExpression schema, string alias) : base(identifier, name, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Fields.Add($"{identifier}.AddressType", AddressType = new AddressTypeField($"{identifier}.AddressType", "AddressType", this));
            Fields.Add($"{identifier}.Line1", Line1 = new Line1Field($"{identifier}.Line1", "Line1", this));
            Fields.Add($"{identifier}.Line2", Line2 = new Line2Field($"{identifier}.Line2", "Line2", this));
            Fields.Add($"{identifier}.City", City = new CityField($"{identifier}.City", "City", this));
            Fields.Add($"{identifier}.State", State = new StateField($"{identifier}.State", "State", this));
            Fields.Add($"{identifier}.Zip", Zip = new ZipField($"{identifier}.Zip", "Zip", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", "DateUpdated", this));
        }
        #endregion

        #region methods
        public AddressEntity As(string name)
            => new AddressEntity(this.identifier, this.name, this.schema, name);

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
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(AddressType));
            set &= aliased != nameof(AddressType) ? new SelectExpression<SimpleConsole.Data.AddressType?>(AddressType).As(aliased) as SelectExpression<SimpleConsole.Data.AddressType?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(AddressType));

            aliased = alias(nameof(Line1));
            set &= aliased != nameof(Line1) ? new SelectExpression<string>(Line1).As(aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Line1));

            aliased = alias(nameof(Line2));
            set &= aliased != nameof(Line2) ? new SelectExpression<string>(Line2).As(aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Line2));

            aliased = alias(nameof(City));
            set &= aliased != nameof(City) ? new SelectExpression<string>(City).As(aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(City));

            aliased = alias(nameof(State));
            set &= aliased != nameof(State) ? new SelectExpression<string>(State).As(aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(State));

            aliased = alias(nameof(Zip));
            set &= aliased != nameof(Zip) ? new SelectExpression<string>(Zip).As(aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Zip));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated).As(aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated).As(aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<Address> GetInclusiveInsertExpression(Address address)
        {
            return new InsertExpressionSet<Address>(address 
                ,new InsertExpression<SimpleConsole.Data.AddressType?>(address.AddressType, AddressType)
                ,new InsertExpression<string>(address.Line1, Line1)
                ,new InsertExpression<string>(address.Line2, Line2)
                ,new InsertExpression<string>(address.City, City)
                ,new InsertExpression<string>(address.State, State)
                ,new InsertExpression<string>(address.Zip, Zip)
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

        protected override void HydrateEntity(ISqlFieldReader reader, Address address)
        {
            address.Id = reader.ReadField().GetValue<int>();
            address.AddressType = reader.ReadField().GetValue<SimpleConsole.Data.AddressType?>();
            address.Line1 = reader.ReadField().GetValue<string>();
            address.Line2 = reader.ReadField().GetValue<string>();
            address.City = reader.ReadField().GetValue<string>();
            address.State = reader.ReadField().GetValue<string>();
            address.Zip = reader.ReadField().GetValue<string>();
            address.DateCreated = reader.ReadField().GetValue<DateTime>();
            address.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<Address>
        {
            #region constructors
            public IdField(string identifier, string name, AddressEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            #endregion
        }
        #endregion

        #region address type field expression
        public partial class AddressTypeField : NullableEnumFieldExpression<Address,SimpleConsole.Data.AddressType>
        {
            #region constructors
            public AddressTypeField(string identifier, string name, AddressEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(SimpleConsole.Data.AddressType value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.AddressType>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.AddressType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(SimpleConsole.Data.AddressType? value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.AddressType?>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.AddressType?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.AddressType>(value, this));
            #endregion
        }
        #endregion

        #region line1 field expression
        public partial class Line1Field : StringFieldExpression<Address>
        {
            #region constructors
            public Line1Field(string identifier, string name, AddressEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(AnyElement<string> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region line2 field expression
        public partial class Line2Field : NullableStringFieldExpression<Address>
        {
            #region constructors
            public Line2Field(string identifier, string name, AddressEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(AnyElement<string> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            #endregion
        }
        #endregion

        #region city field expression
        public partial class CityField : StringFieldExpression<Address>
        {
            #region constructors
            public CityField(string identifier, string name, AddressEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(AnyElement<string> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region state field expression
        public partial class StateField : StringFieldExpression<Address>
        {
            #region constructors
            public StateField(string identifier, string name, AddressEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(AnyElement<string> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region zip field expression
        public partial class ZipField : StringFieldExpression<Address>
        {
            #region constructors
            public ZipField(string identifier, string name, AddressEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(AnyElement<string> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<Address>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, AddressEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            #endregion
        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<Address>
        {
            #region constructors
            public DateUpdatedField(string identifier, string name, AddressEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
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
        private PersonEntity() : base(null, null, null, null)
        {
        }

        public PersonEntity(string identifier, string name, SchemaExpression schema) : this(identifier, name, schema, null)
        {
        }

        private PersonEntity(string identifier, string name, SchemaExpression schema, string alias) : base(identifier, name, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Fields.Add($"{identifier}.FirstName", FirstName = new FirstNameField($"{identifier}.FirstName", "FirstName", this));
            Fields.Add($"{identifier}.LastName", LastName = new LastNameField($"{identifier}.LastName", "LastName", this));
            Fields.Add($"{identifier}.BirthDate", BirthDate = new BirthDateField($"{identifier}.BirthDate", "BirthDate", this));
            Fields.Add($"{identifier}.GenderType", GenderType = new GenderTypeField($"{identifier}.GenderType", "GenderType", this));
            Fields.Add($"{identifier}.CreditLimit", CreditLimit = new CreditLimitField($"{identifier}.CreditLimit", "CreditLimit", this));
            Fields.Add($"{identifier}.YearOfLastCreditLimitReview", YearOfLastCreditLimitReview = new YearOfLastCreditLimitReviewField($"{identifier}.YearOfLastCreditLimitReview", "YearOfLastCreditLimitReview", this));
            Fields.Add($"{identifier}.RegistrationDate", RegistrationDate = new RegistrationDateField($"{identifier}.RegistrationDate", "RegistrationDate", this));
            Fields.Add($"{identifier}.LastLoginDate", LastLoginDate = new LastLoginDateField($"{identifier}.LastLoginDate", "LastLoginDate", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", "DateUpdated", this));
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
            => new PersonEntity(this.identifier, this.name, this.schema, name);

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
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(FirstName));
            set &= aliased != nameof(FirstName) ? new SelectExpression<string>(FirstName).As(aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(FirstName));

            aliased = alias(nameof(LastName));
            set &= aliased != nameof(LastName) ? new SelectExpression<string>(LastName).As(aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(LastName));

            aliased = alias(nameof(BirthDate));
            set &= aliased != nameof(BirthDate) ? new SelectExpression<DateTime?>(BirthDate).As(aliased) as SelectExpression<DateTime?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(BirthDate));

            aliased = alias(nameof(GenderType));
            set &= aliased != nameof(GenderType) ? new SelectExpression<SimpleConsole.Data.GenderType>(GenderType).As(aliased) as SelectExpression<SimpleConsole.Data.GenderType> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(GenderType));

            aliased = alias(nameof(CreditLimit));
            set &= aliased != nameof(CreditLimit) ? new SelectExpression<int?>(CreditLimit).As(aliased) as SelectExpression<int?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(CreditLimit));

            aliased = alias(nameof(YearOfLastCreditLimitReview));
            set &= aliased != nameof(YearOfLastCreditLimitReview) ? new SelectExpression<int?>(YearOfLastCreditLimitReview).As(aliased) as SelectExpression<int?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(YearOfLastCreditLimitReview));

            aliased = alias(nameof(RegistrationDate));
            set &= aliased != nameof(RegistrationDate) ? new SelectExpression<DateTimeOffset>(RegistrationDate).As(aliased) as SelectExpression<DateTimeOffset> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(RegistrationDate));

            aliased = alias(nameof(LastLoginDate));
            set &= aliased != nameof(LastLoginDate) ? new SelectExpression<DateTimeOffset?>(LastLoginDate).As(aliased) as SelectExpression<DateTimeOffset?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(LastLoginDate));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated).As(aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated).As(aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<Person> GetInclusiveInsertExpression(Person person)
        {
            return new InsertExpressionSet<Person>(person 
                ,new InsertExpression<string>(person.FirstName, FirstName)
                ,new InsertExpression<string>(person.LastName, LastName)
                ,new InsertExpression<DateTime?>(person.BirthDate, BirthDate)
                ,new InsertExpression<SimpleConsole.Data.GenderType>(person.GenderType, GenderType)
                ,new InsertExpression<int?>(person.CreditLimit, CreditLimit)
                ,new InsertExpression<int?>(person.YearOfLastCreditLimitReview, YearOfLastCreditLimitReview)
                ,new InsertExpression<DateTimeOffset>(person.RegistrationDate, RegistrationDate)
                ,new InsertExpression<DateTimeOffset?>(person.LastLoginDate, LastLoginDate)
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

        protected override void HydrateEntity(ISqlFieldReader reader, Person person)
        {
            person.Id = reader.ReadField().GetValue<int>();
            person.FirstName = reader.ReadField().GetValue<string>();
            person.LastName = reader.ReadField().GetValue<string>();
            person.BirthDate = reader.ReadField().GetValue<DateTime?>();
            person.GenderType = reader.ReadField().GetValue<SimpleConsole.Data.GenderType>();
            person.CreditLimit = reader.ReadField().GetValue<int?>();
            person.YearOfLastCreditLimitReview = reader.ReadField().GetValue<int?>();
            person.RegistrationDate = reader.ReadField().GetValue<DateTimeOffset>();
            person.LastLoginDate = reader.ReadField().GetValue<DateTimeOffset?>();
            person.DateCreated = reader.ReadField().GetValue<DateTime>();
            person.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<Person>
        {
            #region constructors
            public IdField(string identifier, string name, PersonEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            #endregion
        }
        #endregion

        #region first name field expression
        public partial class FirstNameField : StringFieldExpression<Person>
        {
            #region constructors
            public FirstNameField(string identifier, string name, PersonEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(AnyElement<string> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region last name field expression
        public partial class LastNameField : StringFieldExpression<Person>
        {
            #region constructors
            public LastNameField(string identifier, string name, PersonEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(AnyElement<string> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region birth date field expression
        public partial class BirthDateField : NullableDateTimeFieldExpression<Person>
        {
            #region constructors
            public BirthDateField(string identifier, string name, PersonEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DateTime? value) => new AssignmentExpression(this, new LiteralExpression<DateTime?>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            #endregion
        }
        #endregion

        #region gender type field expression
        public partial class GenderTypeField : EnumFieldExpression<Person,SimpleConsole.Data.GenderType>
        {
            #region constructors
            public GenderTypeField(string identifier, string name, PersonEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(SimpleConsole.Data.GenderType value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.GenderType>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.GenderType> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region credit limit field expression
        public partial class CreditLimitField : NullableInt32FieldExpression<Person>
        {
            #region constructors
            public CreditLimitField(string identifier, string name, PersonEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(int? value) => new AssignmentExpression(this, new LiteralExpression<int?>(value, this));
            public AssignmentExpression Set(AnyElement<int?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            #endregion
        }
        #endregion

        #region year of last credit limit review field expression
        public partial class YearOfLastCreditLimitReviewField : NullableInt32FieldExpression<Person>
        {
            #region constructors
            public YearOfLastCreditLimitReviewField(string identifier, string name, PersonEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(int? value) => new AssignmentExpression(this, new LiteralExpression<int?>(value, this));
            public AssignmentExpression Set(AnyElement<int?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            #endregion
        }
        #endregion

        #region registration date field expression
        public partial class RegistrationDateField : DateTimeOffsetFieldExpression<Person>
        {
            #region constructors
            public RegistrationDateField(string identifier, string name, PersonEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(DateTimeOffset value) => new AssignmentExpression(this, new LiteralExpression<DateTimeOffset>(value, this));
            public AssignmentExpression Set(AnyElement<DateTimeOffset> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region last login date field expression
        public partial class LastLoginDateField : NullableDateTimeOffsetFieldExpression<Person>
        {
            #region constructors
            public LastLoginDateField(string identifier, string name, PersonEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(DateTimeOffset value) => new AssignmentExpression(this, new LiteralExpression<DateTimeOffset>(value, this));
            public AssignmentExpression Set(AnyElement<DateTimeOffset> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DateTimeOffset? value) => new AssignmentExpression(this, new LiteralExpression<DateTimeOffset?>(value, this));
            public AssignmentExpression Set(AnyElement<DateTimeOffset?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<DateTimeOffset>(value, this));
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<Person>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, PersonEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            #endregion
        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<Person>
        {
            #region constructors
            public DateUpdatedField(string identifier, string name, PersonEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
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
        private PersonAddressEntity() : base(null, null, null, null)
        {
        }

        public PersonAddressEntity(string identifier, string name, SchemaExpression schema) : this(identifier, name, schema, null)
        {
        }

        private PersonAddressEntity(string identifier, string name, SchemaExpression schema, string alias) : base(identifier, name, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Fields.Add($"{identifier}.PersonId", PersonId = new PersonIdField($"{identifier}.PersonId", "PersonId", this));
            Fields.Add($"{identifier}.AddressId", AddressId = new AddressIdField($"{identifier}.AddressId", "AddressId", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
        }
        #endregion

        #region methods
        public PersonAddressEntity As(string name)
            => new PersonAddressEntity(this.identifier, this.name, this.schema, name);

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
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(PersonId));
            set &= aliased != nameof(PersonId) ? new SelectExpression<int>(PersonId).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PersonId));

            aliased = alias(nameof(AddressId));
            set &= aliased != nameof(AddressId) ? new SelectExpression<int>(AddressId).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(AddressId));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated).As(aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            return set;
        }
		
        protected override InsertExpressionSet<PersonAddress> GetInclusiveInsertExpression(PersonAddress personAddress)
        {
            return new InsertExpressionSet<PersonAddress>(personAddress 
                ,new InsertExpression<int>(personAddress.PersonId, PersonId)
                ,new InsertExpression<int>(personAddress.AddressId, AddressId)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PersonAddress target, PersonAddress source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.PersonId != source.PersonId) { expr &= PersonId.Set(source.PersonId); }
            if (target.AddressId != source.AddressId) { expr &= AddressId.Set(source.AddressId); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, PersonAddress personAddress)
        {
            personAddress.Id = reader.ReadField().GetValue<int>();
            personAddress.PersonId = reader.ReadField().GetValue<int>();
            personAddress.AddressId = reader.ReadField().GetValue<int>();
            personAddress.DateCreated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<PersonAddress>
        {
            #region constructors
            public IdField(string identifier, string name, PersonAddressEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            #endregion
        }
        #endregion

        #region person id field expression
        public partial class PersonIdField : Int32FieldExpression<PersonAddress>
        {
            #region constructors
            public PersonIdField(string identifier, string name, PersonAddressEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region address id field expression
        public partial class AddressIdField : Int32FieldExpression<PersonAddress>
        {
            #region constructors
            public AddressIdField(string identifier, string name, PersonAddressEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<PersonAddress>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, PersonAddressEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
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
        /// with a .NET type of <see cref="string"/>.  The <see cref="SimpleConsole.dboDataService.ProductEntity.DescriptionField"/> can be 
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{String}"/>.
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
        /// used with any operation accepting a <see cref="HatTrick.DbEx.Sql.AnyElement{ByteArray}"/>.
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
        private ProductEntity() : base(null, null, null, null)
        {
        }

        public ProductEntity(string identifier, string name, SchemaExpression schema) : this(identifier, name, schema, null)
        {
        }

        private ProductEntity(string identifier, string name, SchemaExpression schema, string alias) : base(identifier, name, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Fields.Add($"{identifier}.ProductCategoryType", ProductCategoryType = new ProductCategoryTypeField($"{identifier}.ProductCategoryType", "ProductCategoryType", this));
            Fields.Add($"{identifier}.Name", Name = new NameField($"{identifier}.Name", "Name", this));
            Fields.Add($"{identifier}.Description", Description = new DescriptionField($"{identifier}.Description", "Description", this));
            Fields.Add($"{identifier}.ListPrice", ListPrice = new ListPriceField($"{identifier}.ListPrice", "ListPrice", this));
            Fields.Add($"{identifier}.Price", Price = new PriceField($"{identifier}.Price", "Price", this));
            Fields.Add($"{identifier}.Quantity", Quantity = new QuantityField($"{identifier}.Quantity", "Quantity", this));
            Fields.Add($"{identifier}.Image", Image = new ImageField($"{identifier}.Image", "Image", this));
            Fields.Add($"{identifier}.Height", Height = new HeightField($"{identifier}.Height", "Height", this));
            Fields.Add($"{identifier}.Width", Width = new WidthField($"{identifier}.Width", "Width", this));
            Fields.Add($"{identifier}.Depth", Depth = new DepthField($"{identifier}.Depth", "Depth", this));
            Fields.Add($"{identifier}.Weight", Weight = new WeightField($"{identifier}.Weight", "Weight", this));
            Fields.Add($"{identifier}.ShippingWeight", ShippingWeight = new ShippingWeightField($"{identifier}.ShippingWeight", "ShippingWeight", this));
            Fields.Add($"{identifier}.ValidStartTimeOfDayForPurchase", ValidStartTimeOfDayForPurchase = new ValidStartTimeOfDayForPurchaseField($"{identifier}.ValidStartTimeOfDayForPurchase", "ValidStartTimeOfDayForPurchase", this));
            Fields.Add($"{identifier}.ValidEndTimeOfDayForPurchase", ValidEndTimeOfDayForPurchase = new ValidEndTimeOfDayForPurchaseField($"{identifier}.ValidEndTimeOfDayForPurchase", "ValidEndTimeOfDayForPurchase", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", "DateUpdated", this));
        }
        #endregion

        #region methods
        public ProductEntity As(string name)
            => new ProductEntity(this.identifier, this.name, this.schema, name);

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
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(ProductCategoryType));
            set &= aliased != nameof(ProductCategoryType) ? new SelectExpression<SimpleConsole.Data.ProductCategoryType?>(ProductCategoryType).As(aliased) as SelectExpression<SimpleConsole.Data.ProductCategoryType?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ProductCategoryType));

            aliased = alias(nameof(Name));
            set &= aliased != nameof(Name) ? new SelectExpression<string>(Name).As(aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Name));

            aliased = alias(nameof(Description));
            set &= aliased != nameof(Description) ? new SelectExpression<string>(Description).As(aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Description));

            aliased = alias(nameof(ListPrice));
            set &= aliased != nameof(ListPrice) ? new SelectExpression<double>(ListPrice).As(aliased) as SelectExpression<double> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ListPrice));

            aliased = alias(nameof(Price));
            set &= aliased != nameof(Price) ? new SelectExpression<double>(Price).As(aliased) as SelectExpression<double> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Price));

            aliased = alias(nameof(Quantity));
            set &= aliased != nameof(Quantity) ? new SelectExpression<int>(Quantity).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Quantity));

            aliased = alias(nameof(Image));
            set &= aliased != nameof(Image) ? new SelectExpression<byte[]>(Image).As(aliased) as SelectExpression<byte[]> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Image));

            aliased = alias(nameof(Height));
            set &= aliased != nameof(Height) ? new SelectExpression<decimal?>(Height).As(aliased) as SelectExpression<decimal?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Height));

            aliased = alias(nameof(Width));
            set &= aliased != nameof(Width) ? new SelectExpression<decimal?>(Width).As(aliased) as SelectExpression<decimal?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Width));

            aliased = alias(nameof(Depth));
            set &= aliased != nameof(Depth) ? new SelectExpression<decimal?>(Depth).As(aliased) as SelectExpression<decimal?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Depth));

            aliased = alias(nameof(Weight));
            set &= aliased != nameof(Weight) ? new SelectExpression<decimal?>(Weight).As(aliased) as SelectExpression<decimal?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Weight));

            aliased = alias(nameof(ShippingWeight));
            set &= aliased != nameof(ShippingWeight) ? new SelectExpression<decimal>(ShippingWeight).As(aliased) as SelectExpression<decimal> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ShippingWeight));

            aliased = alias(nameof(ValidStartTimeOfDayForPurchase));
            set &= aliased != nameof(ValidStartTimeOfDayForPurchase) ? new SelectExpression<TimeSpan?>(ValidStartTimeOfDayForPurchase).As(aliased) as SelectExpression<TimeSpan?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ValidStartTimeOfDayForPurchase));

            aliased = alias(nameof(ValidEndTimeOfDayForPurchase));
            set &= aliased != nameof(ValidEndTimeOfDayForPurchase) ? new SelectExpression<TimeSpan?>(ValidEndTimeOfDayForPurchase).As(aliased) as SelectExpression<TimeSpan?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ValidEndTimeOfDayForPurchase));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated).As(aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated).As(aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<Product> GetInclusiveInsertExpression(Product product)
        {
            return new InsertExpressionSet<Product>(product 
                ,new InsertExpression<SimpleConsole.Data.ProductCategoryType?>(product.ProductCategoryType, ProductCategoryType)
                ,new InsertExpression<string>(product.Name, Name)
                ,new InsertExpression<string>(product.Description, Description)
                ,new InsertExpression<double>(product.ListPrice, ListPrice)
                ,new InsertExpression<double>(product.Price, Price)
                ,new InsertExpression<int>(product.Quantity, Quantity)
                ,new InsertExpression<byte[]>(product.Image, Image)
                ,new InsertExpression<decimal?>(product.Height, Height)
                ,new InsertExpression<decimal?>(product.Width, Width)
                ,new InsertExpression<decimal?>(product.Depth, Depth)
                ,new InsertExpression<decimal?>(product.Weight, Weight)
                ,new InsertExpression<decimal>(product.ShippingWeight, ShippingWeight)
                ,new InsertExpression<TimeSpan?>(product.ValidStartTimeOfDayForPurchase, ValidStartTimeOfDayForPurchase)
                ,new InsertExpression<TimeSpan?>(product.ValidEndTimeOfDayForPurchase, ValidEndTimeOfDayForPurchase)
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

        protected override void HydrateEntity(ISqlFieldReader reader, Product product)
        {
            product.Id = reader.ReadField().GetValue<int>();
            product.ProductCategoryType = reader.ReadField().GetValue<SimpleConsole.Data.ProductCategoryType?>();
            product.Name = reader.ReadField().GetValue<string>();
            product.Description = reader.ReadField().GetValue<string>();
            product.ListPrice = reader.ReadField().GetValue<double>();
            product.Price = reader.ReadField().GetValue<double>();
            product.Quantity = reader.ReadField().GetValue<int>();
            product.Image = reader.ReadField().GetValue<byte[]>();
            product.Height = reader.ReadField().GetValue<decimal?>();
            product.Width = reader.ReadField().GetValue<decimal?>();
            product.Depth = reader.ReadField().GetValue<decimal?>();
            product.Weight = reader.ReadField().GetValue<decimal?>();
            product.ShippingWeight = reader.ReadField().GetValue<decimal>();
            product.ValidStartTimeOfDayForPurchase = reader.ReadField().GetValue<TimeSpan?>();
            product.ValidEndTimeOfDayForPurchase = reader.ReadField().GetValue<TimeSpan?>();
            product.DateCreated = reader.ReadField().GetValue<DateTime>();
            product.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<Product>
        {
            #region constructors
            public IdField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            #endregion
        }
        #endregion

        #region product category type field expression
        public partial class ProductCategoryTypeField : NullableEnumFieldExpression<Product,SimpleConsole.Data.ProductCategoryType>
        {
            #region constructors
            public ProductCategoryTypeField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(SimpleConsole.Data.ProductCategoryType value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.ProductCategoryType>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.ProductCategoryType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(SimpleConsole.Data.ProductCategoryType? value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.ProductCategoryType?>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.ProductCategoryType?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.ProductCategoryType>(value, this));
            #endregion
        }
        #endregion

        #region name field expression
        public partial class NameField : StringFieldExpression<Product>
        {
            #region constructors
            public NameField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(AnyElement<string> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region description field expression
        public partial class DescriptionField : NullableStringFieldExpression<Product>
        {
            #region constructors
            public DescriptionField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(AnyElement<string> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            #endregion
        }
        #endregion

        #region list price field expression
        public partial class ListPriceField : DoubleFieldExpression<Product>
        {
            #region constructors
            public ListPriceField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(double value) => new AssignmentExpression(this, new LiteralExpression<double>(value, this));
            public AssignmentExpression Set(AnyElement<double> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region price field expression
        public partial class PriceField : DoubleFieldExpression<Product>
        {
            #region constructors
            public PriceField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(double value) => new AssignmentExpression(this, new LiteralExpression<double>(value, this));
            public AssignmentExpression Set(AnyElement<double> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region quantity field expression
        public partial class QuantityField : Int32FieldExpression<Product>
        {
            #region constructors
            public QuantityField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region image field expression
        public partial class ImageField : NullableByteArrayFieldExpression<Product>
        {
            #region constructors
            public ImageField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(byte[] value) => new AssignmentExpression(this, new LiteralExpression<byte[]>(value, this));
            public AssignmentExpression Set(AnyElement<byte[]> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<byte[]>(value, this));
            #endregion
        }
        #endregion

        #region height field expression
        public partial class HeightField : NullableDecimalFieldExpression<Product>
        {
            #region constructors
            public HeightField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            public AssignmentExpression Set(AnyElement<decimal> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(decimal? value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value, this));
            public AssignmentExpression Set(AnyElement<decimal?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            #endregion
        }
        #endregion

        #region width field expression
        public partial class WidthField : NullableDecimalFieldExpression<Product>
        {
            #region constructors
            public WidthField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            public AssignmentExpression Set(AnyElement<decimal> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(decimal? value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value, this));
            public AssignmentExpression Set(AnyElement<decimal?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            #endregion
        }
        #endregion

        #region depth field expression
        public partial class DepthField : NullableDecimalFieldExpression<Product>
        {
            #region constructors
            public DepthField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            public AssignmentExpression Set(AnyElement<decimal> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(decimal? value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value, this));
            public AssignmentExpression Set(AnyElement<decimal?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            #endregion
        }
        #endregion

        #region weight field expression
        public partial class WeightField : NullableDecimalFieldExpression<Product>
        {
            #region constructors
            public WeightField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            public AssignmentExpression Set(AnyElement<decimal> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(decimal? value) => new AssignmentExpression(this, new LiteralExpression<decimal?>(value, this));
            public AssignmentExpression Set(AnyElement<decimal?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            #endregion
        }
        #endregion

        #region shipping weight field expression
        public partial class ShippingWeightField : DecimalFieldExpression<Product>
        {
            #region constructors
            public ShippingWeightField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            public AssignmentExpression Set(AnyElement<decimal> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region valid start time of day for purchase field expression
        public partial class ValidStartTimeOfDayForPurchaseField : NullableTimeSpanFieldExpression<Product>
        {
            #region constructors
            public ValidStartTimeOfDayForPurchaseField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(TimeSpan value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan>(value, this));
            public AssignmentExpression Set(AnyElement<TimeSpan> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(TimeSpan? value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan?>(value, this));
            public AssignmentExpression Set(AnyElement<TimeSpan?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan>(value, this));
            #endregion
        }
        #endregion

        #region valid end time of day for purchase field expression
        public partial class ValidEndTimeOfDayForPurchaseField : NullableTimeSpanFieldExpression<Product>
        {
            #region constructors
            public ValidEndTimeOfDayForPurchaseField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(TimeSpan value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan>(value, this));
            public AssignmentExpression Set(AnyElement<TimeSpan> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(TimeSpan? value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan?>(value, this));
            public AssignmentExpression Set(AnyElement<TimeSpan?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<TimeSpan>(value, this));
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<Product>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            #endregion
        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<Product>
        {
            #region constructors
            public DateUpdatedField(string identifier, string name, ProductEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
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
        private PurchaseEntity() : base(null, null, null, null)
        {
        }

        public PurchaseEntity(string identifier, string name, SchemaExpression schema) : this(identifier, name, schema, null)
        {
        }

        private PurchaseEntity(string identifier, string name, SchemaExpression schema, string alias) : base(identifier, name, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Fields.Add($"{identifier}.PersonId", PersonId = new PersonIdField($"{identifier}.PersonId", "PersonId", this));
            Fields.Add($"{identifier}.OrderNumber", OrderNumber = new OrderNumberField($"{identifier}.OrderNumber", "OrderNumber", this));
            Fields.Add($"{identifier}.TotalPurchaseQuantity", TotalPurchaseQuantity = new TotalPurchaseQuantityField($"{identifier}.TotalPurchaseQuantity", "TotalPurchaseQuantity", this));
            Fields.Add($"{identifier}.TotalPurchaseAmount", TotalPurchaseAmount = new TotalPurchaseAmountField($"{identifier}.TotalPurchaseAmount", "TotalPurchaseAmount", this));
            Fields.Add($"{identifier}.PurchaseDate", PurchaseDate = new PurchaseDateField($"{identifier}.PurchaseDate", "PurchaseDate", this));
            Fields.Add($"{identifier}.ShipDate", ShipDate = new ShipDateField($"{identifier}.ShipDate", "ShipDate", this));
            Fields.Add($"{identifier}.ExpectedDeliveryDate", ExpectedDeliveryDate = new ExpectedDeliveryDateField($"{identifier}.ExpectedDeliveryDate", "ExpectedDeliveryDate", this));
            Fields.Add($"{identifier}.TrackingIdentifier", TrackingIdentifier = new TrackingIdentifierField($"{identifier}.TrackingIdentifier", "TrackingIdentifier", this));
            Fields.Add($"{identifier}.PaymentMethodType", PaymentMethodType = new PaymentMethodTypeField($"{identifier}.PaymentMethodType", "PaymentMethodType", this));
            Fields.Add($"{identifier}.PaymentSourceType", PaymentSourceType = new PaymentSourceTypeField($"{identifier}.PaymentSourceType", "PaymentSourceType", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", "DateUpdated", this));
        }
        #endregion

        #region methods
        public PurchaseEntity As(string name)
            => new PurchaseEntity(this.identifier, this.name, this.schema, name);

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
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(PersonId));
            set &= aliased != nameof(PersonId) ? new SelectExpression<int>(PersonId).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PersonId));

            aliased = alias(nameof(OrderNumber));
            set &= aliased != nameof(OrderNumber) ? new SelectExpression<string>(OrderNumber).As(aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(OrderNumber));

            aliased = alias(nameof(TotalPurchaseQuantity));
            set &= aliased != nameof(TotalPurchaseQuantity) ? new SelectExpression<int>(TotalPurchaseQuantity).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(TotalPurchaseQuantity));

            aliased = alias(nameof(TotalPurchaseAmount));
            set &= aliased != nameof(TotalPurchaseAmount) ? new SelectExpression<double>(TotalPurchaseAmount).As(aliased) as SelectExpression<double> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(TotalPurchaseAmount));

            aliased = alias(nameof(PurchaseDate));
            set &= aliased != nameof(PurchaseDate) ? new SelectExpression<DateTime>(PurchaseDate).As(aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PurchaseDate));

            aliased = alias(nameof(ShipDate));
            set &= aliased != nameof(ShipDate) ? new SelectExpression<DateTime?>(ShipDate).As(aliased) as SelectExpression<DateTime?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ShipDate));

            aliased = alias(nameof(ExpectedDeliveryDate));
            set &= aliased != nameof(ExpectedDeliveryDate) ? new SelectExpression<DateTime?>(ExpectedDeliveryDate).As(aliased) as SelectExpression<DateTime?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ExpectedDeliveryDate));

            aliased = alias(nameof(TrackingIdentifier));
            set &= aliased != nameof(TrackingIdentifier) ? new SelectExpression<Guid?>(TrackingIdentifier).As(aliased) as SelectExpression<Guid?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(TrackingIdentifier));

            aliased = alias(nameof(PaymentMethodType));
            set &= aliased != nameof(PaymentMethodType) ? new SelectExpression<SimpleConsole.Data.PaymentMethodType>(PaymentMethodType).As(aliased) as SelectExpression<SimpleConsole.Data.PaymentMethodType> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PaymentMethodType));

            aliased = alias(nameof(PaymentSourceType));
            set &= aliased != nameof(PaymentSourceType) ? new SelectExpression<SimpleConsole.Data.PaymentSourceType?>(PaymentSourceType).As(aliased) as SelectExpression<SimpleConsole.Data.PaymentSourceType?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PaymentSourceType));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated).As(aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated).As(aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<Purchase> GetInclusiveInsertExpression(Purchase purchase)
        {
            return new InsertExpressionSet<Purchase>(purchase 
                ,new InsertExpression<int>(purchase.PersonId, PersonId)
                ,new InsertExpression<string>(purchase.OrderNumber, OrderNumber)
                ,new InsertExpression<int>(purchase.TotalPurchaseQuantity, TotalPurchaseQuantity)
                ,new InsertExpression<double>(purchase.TotalPurchaseAmount, TotalPurchaseAmount)
                ,new InsertExpression<DateTime>(purchase.PurchaseDate, PurchaseDate)
                ,new InsertExpression<DateTime?>(purchase.ShipDate, ShipDate)
                ,new InsertExpression<DateTime?>(purchase.ExpectedDeliveryDate, ExpectedDeliveryDate)
                ,new InsertExpression<Guid?>(purchase.TrackingIdentifier, TrackingIdentifier)
                ,new InsertExpression<SimpleConsole.Data.PaymentMethodType>(purchase.PaymentMethodType, PaymentMethodType)
                ,new InsertExpression<SimpleConsole.Data.PaymentSourceType?>(purchase.PaymentSourceType, PaymentSourceType)
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

        protected override void HydrateEntity(ISqlFieldReader reader, Purchase purchase)
        {
            purchase.Id = reader.ReadField().GetValue<int>();
            purchase.PersonId = reader.ReadField().GetValue<int>();
            purchase.OrderNumber = reader.ReadField().GetValue<string>();
            purchase.TotalPurchaseQuantity = reader.ReadField().GetValue<int>();
            purchase.TotalPurchaseAmount = reader.ReadField().GetValue<double>();
            purchase.PurchaseDate = reader.ReadField().GetValue<DateTime>();
            purchase.ShipDate = reader.ReadField().GetValue<DateTime?>();
            purchase.ExpectedDeliveryDate = reader.ReadField().GetValue<DateTime?>();
            purchase.TrackingIdentifier = reader.ReadField().GetValue<Guid?>();
            purchase.PaymentMethodType = reader.ReadField().GetValue<SimpleConsole.Data.PaymentMethodType>();
            purchase.PaymentSourceType = reader.ReadField().GetValue<SimpleConsole.Data.PaymentSourceType?>();
            purchase.DateCreated = reader.ReadField().GetValue<DateTime>();
            purchase.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<Purchase>
        {
            #region constructors
            public IdField(string identifier, string name, PurchaseEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            #endregion
        }
        #endregion

        #region person id field expression
        public partial class PersonIdField : Int32FieldExpression<Purchase>
        {
            #region constructors
            public PersonIdField(string identifier, string name, PurchaseEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region order number field expression
        public partial class OrderNumberField : StringFieldExpression<Purchase>
        {
            #region constructors
            public OrderNumberField(string identifier, string name, PurchaseEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(AnyElement<string> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region total purchase quantity field expression
        public partial class TotalPurchaseQuantityField : Int32FieldExpression<Purchase>
        {
            #region constructors
            public TotalPurchaseQuantityField(string identifier, string name, PurchaseEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region total purchase amount field expression
        public partial class TotalPurchaseAmountField : DoubleFieldExpression<Purchase>
        {
            #region constructors
            public TotalPurchaseAmountField(string identifier, string name, PurchaseEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(double value) => new AssignmentExpression(this, new LiteralExpression<double>(value, this));
            public AssignmentExpression Set(AnyElement<double> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region purchase date field expression
        public partial class PurchaseDateField : DateTimeFieldExpression<Purchase>
        {
            #region constructors
            public PurchaseDateField(string identifier, string name, PurchaseEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region ship date field expression
        public partial class ShipDateField : NullableDateTimeFieldExpression<Purchase>
        {
            #region constructors
            public ShipDateField(string identifier, string name, PurchaseEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DateTime? value) => new AssignmentExpression(this, new LiteralExpression<DateTime?>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            #endregion
        }
        #endregion

        #region expected delivery date field expression
        public partial class ExpectedDeliveryDateField : NullableDateTimeFieldExpression<Purchase>
        {
            #region constructors
            public ExpectedDeliveryDateField(string identifier, string name, PurchaseEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DateTime? value) => new AssignmentExpression(this, new LiteralExpression<DateTime?>(value, this));
            public AssignmentExpression Set(AnyElement<DateTime?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<DateTime>(value, this));
            #endregion
        }
        #endregion

        #region tracking identifier field expression
        public partial class TrackingIdentifierField : NullableGuidFieldExpression<Purchase>
        {
            #region constructors
            public TrackingIdentifierField(string identifier, string name, PurchaseEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(Guid value) => new AssignmentExpression(this, new LiteralExpression<Guid>(value, this));
            public AssignmentExpression Set(AnyElement<Guid> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(Guid? value) => new AssignmentExpression(this, new LiteralExpression<Guid?>(value, this));
            public AssignmentExpression Set(AnyElement<Guid?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<Guid>(value, this));
            #endregion
        }
        #endregion

        #region payment method type field expression
        public partial class PaymentMethodTypeField : EnumFieldExpression<Purchase,SimpleConsole.Data.PaymentMethodType>
        {
            #region constructors
            public PaymentMethodTypeField(string identifier, string name, PurchaseEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(SimpleConsole.Data.PaymentMethodType value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.PaymentMethodType>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.PaymentMethodType> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region payment source type field expression
        public partial class PaymentSourceTypeField : NullableEnumFieldExpression<Purchase,SimpleConsole.Data.PaymentSourceType>
        {
            #region constructors
            public PaymentSourceTypeField(string identifier, string name, PurchaseEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(SimpleConsole.Data.PaymentSourceType value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.PaymentSourceType>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.PaymentSourceType> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(SimpleConsole.Data.PaymentSourceType? value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.PaymentSourceType?>(value, this));
            public AssignmentExpression Set(AnyElement<SimpleConsole.Data.PaymentSourceType?> value) => new AssignmentExpression(this, value);
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<SimpleConsole.Data.PaymentSourceType>(value, this));
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<Purchase>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, PurchaseEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            #endregion
        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<Purchase>
        {
            #region constructors
            public DateUpdatedField(string identifier, string name, PurchaseEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
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
        private PurchaseLineEntity() : base(null, null, null, null)
        {
        }

        public PurchaseLineEntity(string identifier, string name, SchemaExpression schema) : this(identifier, name, schema, null)
        {
        }

        private PurchaseLineEntity(string identifier, string name, SchemaExpression schema, string alias) : base(identifier, name, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Fields.Add($"{identifier}.PurchaseId", PurchaseId = new PurchaseIdField($"{identifier}.PurchaseId", "PurchaseId", this));
            Fields.Add($"{identifier}.ProductId", ProductId = new ProductIdField($"{identifier}.ProductId", "ProductId", this));
            Fields.Add($"{identifier}.PurchasePrice", PurchasePrice = new PurchasePriceField($"{identifier}.PurchasePrice", "PurchasePrice", this));
            Fields.Add($"{identifier}.Quantity", Quantity = new QuantityField($"{identifier}.Quantity", "Quantity", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", "DateUpdated", this));
        }
        #endregion

        #region methods
        public PurchaseLineEntity As(string name)
            => new PurchaseLineEntity(this.identifier, this.name, this.schema, name);

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
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(PurchaseId));
            set &= aliased != nameof(PurchaseId) ? new SelectExpression<int>(PurchaseId).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PurchaseId));

            aliased = alias(nameof(ProductId));
            set &= aliased != nameof(ProductId) ? new SelectExpression<int>(ProductId).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(ProductId));

            aliased = alias(nameof(PurchasePrice));
            set &= aliased != nameof(PurchasePrice) ? new SelectExpression<decimal>(PurchasePrice).As(aliased) as SelectExpression<decimal> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(PurchasePrice));

            aliased = alias(nameof(Quantity));
            set &= aliased != nameof(Quantity) ? new SelectExpression<int>(Quantity).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Quantity));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated).As(aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated).As(aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<PurchaseLine> GetInclusiveInsertExpression(PurchaseLine purchaseLine)
        {
            return new InsertExpressionSet<PurchaseLine>(purchaseLine 
                ,new InsertExpression<int>(purchaseLine.PurchaseId, PurchaseId)
                ,new InsertExpression<int>(purchaseLine.ProductId, ProductId)
                ,new InsertExpression<decimal>(purchaseLine.PurchasePrice, PurchasePrice)
                ,new InsertExpression<int>(purchaseLine.Quantity, Quantity)
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

        protected override void HydrateEntity(ISqlFieldReader reader, PurchaseLine purchaseLine)
        {
            purchaseLine.Id = reader.ReadField().GetValue<int>();
            purchaseLine.PurchaseId = reader.ReadField().GetValue<int>();
            purchaseLine.ProductId = reader.ReadField().GetValue<int>();
            purchaseLine.PurchasePrice = reader.ReadField().GetValue<decimal>();
            purchaseLine.Quantity = reader.ReadField().GetValue<int>();
            purchaseLine.DateCreated = reader.ReadField().GetValue<DateTime>();
            purchaseLine.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<PurchaseLine>
        {
            #region constructors
            public IdField(string identifier, string name, PurchaseLineEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            #endregion
        }
        #endregion

        #region purchase id field expression
        public partial class PurchaseIdField : Int32FieldExpression<PurchaseLine>
        {
            #region constructors
            public PurchaseIdField(string identifier, string name, PurchaseLineEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region product id field expression
        public partial class ProductIdField : Int32FieldExpression<PurchaseLine>
        {
            #region constructors
            public ProductIdField(string identifier, string name, PurchaseLineEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region purchase price field expression
        public partial class PurchasePriceField : DecimalFieldExpression<PurchaseLine>
        {
            #region constructors
            public PurchasePriceField(string identifier, string name, PurchaseLineEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(decimal value) => new AssignmentExpression(this, new LiteralExpression<decimal>(value, this));
            public AssignmentExpression Set(AnyElement<decimal> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region quantity field expression
        public partial class QuantityField : Int32FieldExpression<PurchaseLine>
        {
            #region constructors
            public QuantityField(string identifier, string name, PurchaseLineEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<PurchaseLine>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, PurchaseLineEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            #endregion
        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<PurchaseLine>
        {
            #region constructors
            public DateUpdatedField(string identifier, string name, PurchaseLineEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
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
        private PersonTotalPurchasesViewEntity() : base(null, null, null, null)
        {
        }

        public PersonTotalPurchasesViewEntity(string identifier, string name, SchemaExpression schema) : this(identifier, name, schema, null)
        {
        }

        private PersonTotalPurchasesViewEntity(string identifier, string name, SchemaExpression schema, string alias) : base(identifier, name, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Fields.Add($"{identifier}.TotalAmount", TotalAmount = new TotalAmountField($"{identifier}.TotalAmount", "TotalAmount", this));
            Fields.Add($"{identifier}.TotalCount", TotalCount = new TotalCountField($"{identifier}.TotalCount", "TotalCount", this));
        }
        #endregion

        #region methods
        public PersonTotalPurchasesViewEntity As(string name)
            => new PersonTotalPurchasesViewEntity(this.identifier, this.name, this.schema, name);

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
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(TotalAmount));
            set &= aliased != nameof(TotalAmount) ? new SelectExpression<double?>(TotalAmount).As(aliased) as SelectExpression<double?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(TotalAmount));

            aliased = alias(nameof(TotalCount));
            set &= aliased != nameof(TotalCount) ? new SelectExpression<int?>(TotalCount).As(aliased) as SelectExpression<int?> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(TotalCount));

            return set;
        }
		
        protected override InsertExpressionSet<PersonTotalPurchasesView> GetInclusiveInsertExpression(PersonTotalPurchasesView personTotalPurchasesView)
        {
            return new InsertExpressionSet<PersonTotalPurchasesView>(personTotalPurchasesView 
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PersonTotalPurchasesView target, PersonTotalPurchasesView source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, PersonTotalPurchasesView personTotalPurchasesView)
        {
            personTotalPurchasesView.Id = reader.ReadField().GetValue<int>();
            personTotalPurchasesView.TotalAmount = reader.ReadField().GetValue<double?>();
            personTotalPurchasesView.TotalCount = reader.ReadField().GetValue<int?>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<PersonTotalPurchasesView>
        {
            #region constructors
            public IdField(string identifier, string name, PersonTotalPurchasesViewEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            #endregion
        }
        #endregion

        #region total amount field expression
        public partial class TotalAmountField : NullableDoubleFieldExpression<PersonTotalPurchasesView>
        {
            #region constructors
            public TotalAmountField(string identifier, string name, PersonTotalPurchasesViewEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<double>(value, this));
            #endregion
        }
        #endregion

        #region total count field expression
        public partial class TotalCountField : NullableInt32FieldExpression<PersonTotalPurchasesView>
        {
            #region constructors
            public TotalCountField(string identifier, string name, PersonTotalPurchasesViewEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
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
            ,SchemaExpression schema
            ,int? P1
        ) : base(
                $"{identifier}.SelectPerson_As_Dynamic_With_Input"
                ,"SelectPerson_As_Dynamic_With_Input"
                ,schema
                ,new List<ParameterExpression> 
                { 
                    new ParameterExpression<int?>($"{identifier}.SelectPerson_As_Dynamic_With_Input.@P1", "P1", P1, ParameterDirection.Input)
                }
            )
        { }
    }
    #endregion

    #region select person_ as_ dynamic_ with_ input_ and_ input output stored procedure expression
    public partial class SelectPerson_As_Dynamic_With_Input_And_InputOutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPerson_As_Dynamic_With_Input_And_InputOutputStoredProcedure(
            string identifier
            ,SchemaExpression schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base(
                $"{identifier}.SelectPerson_As_Dynamic_With_Input_And_InputOutput"
                ,"SelectPerson_As_Dynamic_With_Input_And_InputOutput"
                ,schema
                ,new List<ParameterExpression> 
                { 
                    new ParameterExpression<int?>($"{identifier}.SelectPerson_As_Dynamic_With_Input_And_InputOutput.@P1", "P1", P1, ParameterDirection.Input)
                    ,new ParameterExpression<int?>($"{identifier}.SelectPerson_As_Dynamic_With_Input_And_InputOutput.@CreditLimit", "CreditLimit", ParameterDirection.Output)
                }
                ,outputParameters
            )
        { }
    }
    #endregion

    #region select person_ as_ dynamic_ with_ input_ and_ output stored procedure expression
    public partial class SelectPerson_As_Dynamic_With_Input_And_OutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPerson_As_Dynamic_With_Input_And_OutputStoredProcedure(
            string identifier
            ,SchemaExpression schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base(
                $"{identifier}.SelectPerson_As_Dynamic_With_Input_And_Output"
                ,"SelectPerson_As_Dynamic_With_Input_And_Output"
                ,schema
                ,new List<ParameterExpression> 
                { 
                    new ParameterExpression<int?>($"{identifier}.SelectPerson_As_Dynamic_With_Input_And_Output.@P1", "P1", P1, ParameterDirection.Input)
                    ,new ParameterExpression<int?>($"{identifier}.SelectPerson_As_Dynamic_With_Input_And_Output.@Count", "Count", ParameterDirection.Output)
                }
                ,outputParameters
            )
        { }
    }
    #endregion

    #region select person_ as_ dynamic list_ with_ input stored procedure expression
    public partial class SelectPerson_As_DynamicList_With_InputStoredProcedure : StoredProcedureExpression
    {
        public SelectPerson_As_DynamicList_With_InputStoredProcedure(
            string identifier
            ,SchemaExpression schema
            ,int? P1
        ) : base(
                $"{identifier}.SelectPerson_As_DynamicList_With_Input"
                ,"SelectPerson_As_DynamicList_With_Input"
                ,schema
                ,new List<ParameterExpression> 
                { 
                    new ParameterExpression<int?>($"{identifier}.SelectPerson_As_DynamicList_With_Input.@P1", "P1", P1, ParameterDirection.Input)
                }
            )
        { }
    }
    #endregion

    #region select person_ as_ dynamic list_ with_ input_ and_ input output stored procedure expression
    public partial class SelectPerson_As_DynamicList_With_Input_And_InputOutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPerson_As_DynamicList_With_Input_And_InputOutputStoredProcedure(
            string identifier
            ,SchemaExpression schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base(
                $"{identifier}.SelectPerson_As_DynamicList_With_Input_And_InputOutput"
                ,"SelectPerson_As_DynamicList_With_Input_And_InputOutput"
                ,schema
                ,new List<ParameterExpression> 
                { 
                    new ParameterExpression<int?>($"{identifier}.SelectPerson_As_DynamicList_With_Input_And_InputOutput.@P1", "P1", P1, ParameterDirection.Input)
                    ,new ParameterExpression<int?>($"{identifier}.SelectPerson_As_DynamicList_With_Input_And_InputOutput.@CreditLimit", "CreditLimit", ParameterDirection.Output)
                }
                ,outputParameters
            )
        { }
    }
    #endregion

    #region select person_ as_ dynamic list_ with_ input_ and_ output stored procedure expression
    public partial class SelectPerson_As_DynamicList_With_Input_And_OutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPerson_As_DynamicList_With_Input_And_OutputStoredProcedure(
            string identifier
            ,SchemaExpression schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base(
                $"{identifier}.SelectPerson_As_DynamicList_With_Input_And_Output"
                ,"SelectPerson_As_DynamicList_With_Input_And_Output"
                ,schema
                ,new List<ParameterExpression> 
                { 
                    new ParameterExpression<int?>($"{identifier}.SelectPerson_As_DynamicList_With_Input_And_Output.@P1", "P1", P1, ParameterDirection.Input)
                    ,new ParameterExpression<int?>($"{identifier}.SelectPerson_As_DynamicList_With_Input_And_Output.@Count", "Count", ParameterDirection.Output)
                }
                ,outputParameters
            )
        { }
    }
    #endregion

    #region select person id_ as_ scalar value_ with_ input stored procedure expression
    public partial class SelectPersonId_As_ScalarValue_With_InputStoredProcedure : StoredProcedureExpression
    {
        public SelectPersonId_As_ScalarValue_With_InputStoredProcedure(
            string identifier
            ,SchemaExpression schema
            ,int? P1
        ) : base(
                $"{identifier}.SelectPersonId_As_ScalarValue_With_Input"
                ,"SelectPersonId_As_ScalarValue_With_Input"
                ,schema
                ,new List<ParameterExpression> 
                { 
                    new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValue_With_Input.@P1", "P1", P1, ParameterDirection.Input)
                }
            )
        { }
    }
    #endregion

    #region select person id_ as_ scalar value_ with_ input_ and_ default_ value stored procedure expression
    public partial class SelectPersonId_As_ScalarValue_With_Input_And_Default_ValueStoredProcedure : StoredProcedureExpression
    {
        public SelectPersonId_As_ScalarValue_With_Input_And_Default_ValueStoredProcedure(
            string identifier
            ,SchemaExpression schema
            ,int? P1
        ) : base(
                $"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_Default_Value"
                ,"SelectPersonId_As_ScalarValue_With_Input_And_Default_Value"
                ,schema
                ,new List<ParameterExpression> 
                { 
                    new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_Default_Value.@P1", "P1", P1, ParameterDirection.Input)
                }
            )
        { }
    }
    #endregion

    #region select person id_ as_ scalar value_ with_ input_ and_ input output stored procedure expression
    public partial class SelectPersonId_As_ScalarValue_With_Input_And_InputOutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPersonId_As_ScalarValue_With_Input_And_InputOutputStoredProcedure(
            string identifier
            ,SchemaExpression schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base(
                $"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput"
                ,"SelectPersonId_As_ScalarValue_With_Input_And_InputOutput"
                ,schema
                ,new List<ParameterExpression> 
                { 
                    new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput.@P1", "P1", P1, ParameterDirection.Input)
                    ,new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput.@CreditLimit", "CreditLimit", ParameterDirection.Output)
                }
                ,outputParameters
            )
        { }
    }
    #endregion

    #region select person id_ as_ scalar value_ with_ input_ and_ output stored procedure expression
    public partial class SelectPersonId_As_ScalarValue_With_Input_And_OutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPersonId_As_ScalarValue_With_Input_And_OutputStoredProcedure(
            string identifier
            ,SchemaExpression schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base(
                $"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_Output"
                ,"SelectPersonId_As_ScalarValue_With_Input_And_Output"
                ,schema
                ,new List<ParameterExpression> 
                { 
                    new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_Output.@P1", "P1", P1, ParameterDirection.Input)
                    ,new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValue_With_Input_And_Output.@Count", "Count", ParameterDirection.Output)
                }
                ,outputParameters
            )
        { }
    }
    #endregion

    #region select person id_ as_ scalar value list_ with_ input stored procedure expression
    public partial class SelectPersonId_As_ScalarValueList_With_InputStoredProcedure : StoredProcedureExpression
    {
        public SelectPersonId_As_ScalarValueList_With_InputStoredProcedure(
            string identifier
            ,SchemaExpression schema
            ,int? P1
        ) : base(
                $"{identifier}.SelectPersonId_As_ScalarValueList_With_Input"
                ,"SelectPersonId_As_ScalarValueList_With_Input"
                ,schema
                ,new List<ParameterExpression> 
                { 
                    new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input.@P1", "P1", P1, ParameterDirection.Input)
                }
            )
        { }
    }
    #endregion

    #region select person id_ as_ scalar value list_ with_ input_ and_ input output stored procedure expression
    public partial class SelectPersonId_As_ScalarValueList_With_Input_And_InputOutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPersonId_As_ScalarValueList_With_Input_And_InputOutputStoredProcedure(
            string identifier
            ,SchemaExpression schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base(
                $"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput"
                ,"SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput"
                ,schema
                ,new List<ParameterExpression> 
                { 
                    new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput.@P1", "P1", P1, ParameterDirection.Input)
                    ,new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput.@CreditLimit", "CreditLimit", ParameterDirection.Output)
                }
                ,outputParameters
            )
        { }
    }
    #endregion

    #region select person id_ as_ scalar value list_ with_ input_ and_ output stored procedure expression
    public partial class SelectPersonId_As_ScalarValueList_With_Input_And_OutputStoredProcedure : StoredProcedureExpression
    {
        public SelectPersonId_As_ScalarValueList_With_Input_And_OutputStoredProcedure(
            string identifier
            ,SchemaExpression schema
            ,int? P1
            ,Action<ISqlOutputParameterList> outputParameters
        ) : base(
                $"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_Output"
                ,"SelectPersonId_As_ScalarValueList_With_Input_And_Output"
                ,schema
                ,new List<ParameterExpression> 
                { 
                    new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_Output.@P1", "P1", P1, ParameterDirection.Input)
                    ,new ParameterExpression<int?>($"{identifier}.SelectPersonId_As_ScalarValueList_With_Input_And_Output.@Count", "Count", ParameterDirection.Output)
                }
                ,outputParameters
            )
        { }
    }
    #endregion

    #region update person credit limit_ with_ inputs stored procedure expression
    public partial class UpdatePersonCreditLimit_With_InputsStoredProcedure : StoredProcedureExpression
    {
        public UpdatePersonCreditLimit_With_InputsStoredProcedure(
            string identifier
            ,SchemaExpression schema
            ,int? P1
            ,int? CreditLimit
        ) : base(
                $"{identifier}.UpdatePersonCreditLimit_With_Inputs"
                ,"UpdatePersonCreditLimit_With_Inputs"
                ,schema
                ,new List<ParameterExpression> 
                { 
                    new ParameterExpression<int?>($"{identifier}.UpdatePersonCreditLimit_With_Inputs.@P1", "P1", P1, ParameterDirection.Input)
                    ,new ParameterExpression<int?>($"{identifier}.UpdatePersonCreditLimit_With_Inputs.@CreditLimit", "CreditLimit", CreditLimit, ParameterDirection.Input)
                }
            )
        { }
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
        public secSchemaExpression(string identifier) : base(identifier, null)
        {
            Entities.Add($"{identifier}.Person", Person = new PersonEntity($"{identifier}.Person", "Person", this));
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
        private PersonEntity() : base(null, null, null, null)
        {
        }

        public PersonEntity(string identifier, string name, SchemaExpression schema) : this(identifier, name, schema, null)
        {
        }

        private PersonEntity(string identifier, string name, SchemaExpression schema, string alias) : base(identifier, name, schema, alias)
        {
            Fields.Add($"{identifier}.Id", Id = new IdField($"{identifier}.Id", "Id", this));
            Fields.Add($"{identifier}.SSN", SSN = new SSNField($"{identifier}.SSN", "SSN", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateCreatedField($"{identifier}.DateCreated", "DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateUpdatedField($"{identifier}.DateUpdated", "DateUpdated", this));
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
            => new PersonEntity(this.identifier, this.name, this.schema, name);

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
            set &= aliased != nameof(Id) ? new SelectExpression<int>(Id).As(aliased) as SelectExpression<int> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(Id));

            aliased = alias(nameof(SSN));
            set &= aliased != nameof(SSN) ? new SelectExpression<string>(SSN).As(aliased) as SelectExpression<string> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(SSN));

            aliased = alias(nameof(DateCreated));
            set &= aliased != nameof(DateCreated) ? new SelectExpression<DateTime>(DateCreated).As(aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateCreated));

            aliased = alias(nameof(DateUpdated));
            set &= aliased != nameof(DateUpdated) ? new SelectExpression<DateTime>(DateUpdated).As(aliased) as SelectExpression<DateTime> : GetInclusiveSelectExpression().Expressions.Single(x => (x.Expression as IExpressionNameProvider).Name == nameof(DateUpdated));

            return set;
        }
		
        protected override InsertExpressionSet<Person> GetInclusiveInsertExpression(Person person)
        {
            return new InsertExpressionSet<Person>(person 
                ,new InsertExpression<int>(person.Id, Id)
                ,new InsertExpression<string>(person.SSN, SSN)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person target, Person source)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

            if (target.Id != source.Id) { expr &= Id.Set(source.Id); }
            if (target.SSN != source.SSN) { expr &= SSN.Set(source.SSN); }
            return expr;
        }

        protected override void HydrateEntity(ISqlFieldReader reader, Person person)
        {
            person.Id = reader.ReadField().GetValue<int>();
            person.SSN = reader.ReadField().GetValue<string>();
            person.DateCreated = reader.ReadField().GetValue<DateTime>();
            person.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion

        #region classes
        #region id field expression
        public partial class IdField : Int32FieldExpression<Person>
        {
            #region constructors
            public IdField(string identifier, string name, PersonEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(int value) => new AssignmentExpression(this, new LiteralExpression<int>(value, this));
            public AssignmentExpression Set(AnyElement<int> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region s s n field expression
        public partial class SSNField : StringFieldExpression<Person>
        {
            #region constructors
            public SSNField(string identifier, string name, PersonEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            public AssignmentExpression Set(string value) => new AssignmentExpression(this, new LiteralExpression<string>(value, this));
            public AssignmentExpression Set(AnyElement<string> value) => new AssignmentExpression(this, value);
            #endregion
        }
        #endregion

        #region date created field expression
        public partial class DateCreatedField : DateTimeFieldExpression<Person>
        {
            #region constructors
            public DateCreatedField(string identifier, string name, PersonEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
            #endregion
        }
        #endregion

        #region date updated field expression
        public partial class DateUpdatedField : DateTimeFieldExpression<Person>
        {
            #region constructors
            public DateUpdatedField(string identifier, string name, PersonEntity entity) : base(identifier, name, entity)
            {

            }
            #endregion

            #region set
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
