using HatTrick.DbEx.Sql;
using System;

namespace Data.dbo
{
    #region address
    [Serializable]
    public partial class Address : I32BitIdentityDbEntity
    {
        #region interface
        public int Id { get; set; }
        public AddressType AddressType { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Address()
        {

        }
        #endregion
    }
    #endregion
    #region person
    [Serializable]
    public partial class Person : I32BitIdentityDbEntity
    {
        #region interface
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderType GenderType { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Person()
        {

        }
        #endregion
    }
    #endregion
    #region person_ address
    [Serializable]
    public partial class Person_Address : I32BitIdentityDbEntity
    {
        #region interface
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int AddressId { get; set; }
        public DateTime DateCreated { get; set; }
        #endregion

        #region constructor
        public Person_Address()
        {

        }
        #endregion
    }
    #endregion
    #region product
    [Serializable]
    public partial class Product : I32BitIdentityDbEntity
    {
        #region interface
        public int Id { get; set; }
        public ProductCategoryType ProductCategoryType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal ListPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Product()
        {

        }
        #endregion
    }
    #endregion
    #region purchase
    [Serializable]
    public partial class Purchase : I32BitIdentityDbEntity
    {
        #region interface
        public int Id { get; set; }
        public int PersonId { get; set; }
        public decimal TotalPurchaseAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Purchase()
        {

        }
        #endregion
    }
    #endregion
    #region purchase
    [Serializable]
    public partial class PurchaseLine : I32BitIdentityDbEntity
    {
        #region interface
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public PurchaseLine()
        {

        }
        #endregion
    }
    #endregion
}
namespace Data.sec
{
    #region person
    [Serializable]
    public partial class Person : I32BitIdentityDbEntity
    {
        #region interface
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string SSN { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Person()
        {

        }
        #endregion
    }
    #endregion
}
