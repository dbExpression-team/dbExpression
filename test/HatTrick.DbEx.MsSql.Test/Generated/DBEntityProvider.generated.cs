using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.MsSql;

namespace HatTrick.DbEx.MsSql.Test.dbo.DataService
{
    #region dbo
    public class dboSchema : SchemaExpression
    {
		private static readonly string _connectionStringName = "hattrick.mssql.test";
        public dboSchema() : base("dbo", _connectionStringName) { }
    }

    public static partial class dbo
    {
        #region internals
        private static volatile dboSchema _dboSchema;
        private static volatile AddressEntity _addressEntity;
        private static volatile PersonEntity _personEntity;
        private static volatile Person_AddressEntity _person_AddressEntity;
        private static volatile ProductEntity _productEntity;
        private static volatile PurchaseEntity _purchaseEntity;
        private static volatile PersonTotalPurchasesViewEntity _personTotalPurchasesViewEntity;

        private static dboSchema dboSchema => _dboSchema ?? (_dboSchema = new dboSchema());

        #endregion

        #region interface
        public static AddressEntity Address => _addressEntity ?? (_addressEntity = new AddressEntity(dboSchema, "Address"));
        public static PersonEntity Person => _personEntity ?? (_personEntity = new PersonEntity(dboSchema, "Person"));
        public static Person_AddressEntity Person_Address => _person_AddressEntity ?? (_person_AddressEntity = new Person_AddressEntity(dboSchema, "Person_Address"));
        public static ProductEntity Product => _productEntity ?? (_productEntity = new ProductEntity(dboSchema, "Product"));
        public static PurchaseEntity Purchase => _purchaseEntity ?? (_purchaseEntity = new PurchaseEntity(dboSchema, "Purchase"));
        #endregion
    }
	#endregion
}
namespace HatTrick.DbEx.MsSql.Test.sec.DataService
{
    #region sec
    public class secSchema : SchemaExpression
    {
        private static readonly string _connectionStringName = "hattrick.mssql.test";
        public secSchema() : base("sec", _connectionStringName) { }
    }

    public static partial class sec
    {
        #region internals
        private static volatile secSchema _secSchema;
        private static volatile PersonEntity _personEntity;

        private static secSchema secSchema => _secSchema ?? (_secSchema = new secSchema());

        #endregion

        #region interface
        public static PersonEntity Person => _personEntity ?? (_personEntity = new PersonEntity(secSchema, "Person"));
        #endregion
    }
    #endregion
}
