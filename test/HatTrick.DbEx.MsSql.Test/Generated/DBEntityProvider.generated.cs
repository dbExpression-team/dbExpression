using HatTrick.DbEx.Sql.Expression;

namespace Generated.DataService
{
    using static Generated.dbo.Data.dbo;

    #region dbo
    public class dboSchema : SchemaExpression
    {
        #region internals
        private static readonly string _connectionStringName = "hattrick.dbex.mssql.test";
        #endregion

        #region constructors
        public dboSchema() : base("dbo", _connectionStringName) { }
        #endregion
    }

    public static class dbo
    {
        #region internals
        private static volatile dboSchema instance = new dboSchema();
        private static volatile AddressEntity _addressEntity;
        private static volatile PersonEntity _personEntity;
        private static volatile Person_AddressEntity _person_AddressEntity;
        private static volatile ProductEntity _productEntity;
        private static volatile PurchaseEntity _purchaseEntity;
        #endregion

        #region interface
        public static AddressEntity Address => _addressEntity ?? (_addressEntity = new AddressEntity(dbo.instance, "Address"));
        public static PersonEntity Person => _personEntity ?? (_personEntity = new PersonEntity(dbo.instance, "Person"));
        public static Person_AddressEntity Person_Address => _person_AddressEntity ?? (_person_AddressEntity = new Person_AddressEntity(dbo.instance, "Person_Address"));
        public static ProductEntity Product => _productEntity ?? (_productEntity = new ProductEntity(dbo.instance, "Product"));
        public static PurchaseEntity Purchase => _purchaseEntity ?? (_purchaseEntity = new PurchaseEntity(dbo.instance, "Purchase"));
        #endregion
    }
	#endregion
}
namespace Generated.DataService
{
    using static Generated.sec.Data.sec;
    
    #region sec
    public class secSchema : SchemaExpression
    {
        #region internals
        private static readonly string _connectionStringName = "hattrick.dbex.mssql.test";
        #endregion

        #region constructors
        public secSchema() : base("sec", _connectionStringName) { }
        #endregion
    }

    public static class sec
    {
        #region internals
        private static volatile secSchema instance = new secSchema();
        private static volatile PersonEntity _personEntity;
        #endregion

        #region interface
        public static PersonEntity Person => _personEntity ?? (_personEntity = new PersonEntity(sec.instance, "Person"));
        #endregion
    }
    #endregion
}
