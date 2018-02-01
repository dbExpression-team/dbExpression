using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Expression;
using HTL.DbEx.MsSql;
using HTL.DbEx.MsSql.Expression;

namespace HTL.MsSql.MsSqlTest.dbo.DataService
{
	#region dbo
    public static partial class dbo
    {
        #region internals
        private static AddressEntity _addressEntity;
        private static PersonEntity _personEntity;
        private static Person_AddressEntity _person_AddressEntity;
        private static ProductEntity _productEntity;
        private static PurchaseEntity _purchaseEntity;
        private static PersonTotalPurchasesViewEntity _personTotalPurchasesViewEntity;

		private static readonly string _connectionStringName = "htl.mssql.test";
        #endregion

        #region interface
        public static AddressEntity Address
        {
            get
            {
				return (_addressEntity == null) 
					? _addressEntity = new AddressEntity("dbo", "Address") 
					: _addressEntity;
            }
        }
        public static PersonEntity Person
        {
            get
            {
				return (_personEntity == null) 
					? _personEntity = new PersonEntity("dbo", "Person") 
					: _personEntity;
            }
        }
        public static Person_AddressEntity Person_Address
        {
            get
            {
				return (_person_AddressEntity == null) 
					? _person_AddressEntity = new Person_AddressEntity("dbo", "Person_Address") 
					: _person_AddressEntity;
            }
        }
        public static ProductEntity Product
        {
            get
            {
				return (_productEntity == null) 
					? _productEntity = new ProductEntity("dbo", "Product") 
					: _productEntity;
            }
        }
        public static PurchaseEntity Purchase
        {
            get
            {
				return (_purchaseEntity == null) 
					? _purchaseEntity = new PurchaseEntity("dbo", "Purchase") 
					: _purchaseEntity;
            }
        }
        public static PersonTotalPurchasesViewEntity PersonTotalPurchasesView
        {
            get
            {
				return (_personTotalPurchasesViewEntity == null) 
					? _personTotalPurchasesViewEntity = new PersonTotalPurchasesViewEntity("dbo", "PersonTotalPurchasesView") 
					: _personTotalPurchasesViewEntity;
            }
        }
        #endregion
        
        #region methods
        public static SqlConnection GetConnection()
        {
			return new MsSqlConnection(_connectionStringName);
        }

        public static SqlExpressionBuilder<T> GetExpressionBuilder<T>(DBExpressionEntity baseEntity) where T : new ()
        {
			return new MsSqlExpressionBuilder<T>(_connectionStringName, baseEntity);
        }
        #endregion
    }
	#endregion
}
namespace HTL.MsSql.MsSqlTest.sec.DataService
{
	#region sec
    public static partial class sec
    {
        #region internals
        private static PersonEntity _personEntity;

		private static readonly string _connectionStringName = "htl.mssql.test";
        #endregion

        #region interface
        public static PersonEntity Person
        {
            get
            {
				return (_personEntity == null) 
					? _personEntity = new PersonEntity("sec", "Person") 
					: _personEntity;
            }
        }
        #endregion
        
        #region methods
        public static SqlConnection GetConnection()
        {
			return new MsSqlConnection(_connectionStringName);
        }

        public static SqlExpressionBuilder<T> GetExpressionBuilder<T>(DBExpressionEntity baseEntity) where T : new ()
        {
			return new MsSqlExpressionBuilder<T>(_connectionStringName, baseEntity);
        }
        #endregion
    }
	#endregion
}
