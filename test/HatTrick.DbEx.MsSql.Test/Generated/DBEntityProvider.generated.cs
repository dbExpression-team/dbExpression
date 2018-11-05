using HatTrick.DbEx.Sql.Expression;

namespace DataService
{
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

    public static partial class dbo
    {
        #region internals
        private static volatile dboSchema _schema;
        private static volatile AddressEntity _addressEntity;
        private static volatile PersonEntity _personEntity;
        private static volatile Person_AddressEntity _person_AddressEntity;
        private static volatile ProductEntity _productEntity;
        private static volatile PurchaseEntity _purchaseEntity;
        private static volatile PersonTotalPurchasesViewEntity _personTotalPurchasesViewEntity;
        #endregion

        #region interface
        public static AddressEntity Address => _addressEntity;
        public static PersonEntity Person => _personEntity;
        public static Person_AddressEntity Person_Address => _person_AddressEntity;
        public static ProductEntity Product => _productEntity;
        public static PurchaseEntity Purchase => _purchaseEntity;
        public static PersonTotalPurchasesViewEntity PersonTotalPurchasesView => _personTotalPurchasesViewEntity;
        #endregion

        #region constructors
        static dbo()
        {
            _schema = new dboSchema();
            _addressEntity = new AddressEntity(_schema, "Address");
            _personEntity = new PersonEntity(_schema, "Person");
            _person_AddressEntity = new Person_AddressEntity(_schema, "Person_Address");
            _productEntity = new ProductEntity(_schema, "Product");
            _purchaseEntity = new PurchaseEntity(_schema, "Purchase");
            _personTotalPurchasesViewEntity = new PersonTotalPurchasesViewEntity(_schema, "PersonTotalPurchasesView");
        }
        #endregion
    }
	#endregion
}
namespace DataService
{
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

    public static partial class sec
    {
        #region internals
        private static volatile secSchema _schema;
        private static volatile PersonEntity _personEntity;
        #endregion

        #region interface
        public static PersonEntity Person => _personEntity;
        #endregion

        #region constructors
        static sec()
        {
            _schema = new secSchema();
            _personEntity = new PersonEntity(_schema, "Person");
        }

        #endregion
    }
    #endregion
}
