using System;
using HatTrick.DbEx.Sql;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace DbEx.dboData
{
    #region access audit log
    public partial class AccessAuditLog : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual int PersonId { get; set; }
        public virtual int AccessResult { get; set; }
        public virtual DateTime DateCreated { get; set; }
        #endregion

        #region constructor
        public AccessAuditLog()
        {
        }
        #endregion
    }
    #endregion

    #region address
    public partial class Address : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual DbEx.Data.AddressType? AddressType { get; set; }
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zip { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Address()
        {
        }
        #endregion
    }
    #endregion

    #region person
    public partial class Person : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime? BirthDate { get; set; }
        public virtual DbEx.Data.GenderType GenderType { get; set; }
        public virtual int? CreditLimit { get; set; }
        public virtual int? YearOfLastCreditLimitReview { get; set; }
        public virtual DateTimeOffset RegistrationDate { get; set; }
        public virtual DateTimeOffset? LastLoginDate { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Person()
        {
        }
        #endregion
    }
    #endregion

    #region person address
    public partial class PersonAddress : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual int PersonId { get; set; }
        public virtual int AddressId { get; set; }
        public virtual DateTime DateCreated { get; set; }
        #endregion

        #region constructor
        public PersonAddress()
        {
        }
        #endregion
    }
    #endregion

    #region product
    public partial class Product : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual DbEx.Data.ProductCategoryType? ProductCategoryType { get; set; }
        public virtual string Name { get; set; }
        public virtual HatTrick.DbEx.MsSql.Test.ProductDescription Description { get; set; }
        public virtual double ListPrice { get; set; }
        public virtual double Price { get; set; }
        public virtual int Quantity { get; set; }
        public virtual byte[] Image { get; set; }
        public virtual decimal? Height { get; set; }
        public virtual decimal? Width { get; set; }
        public virtual decimal? Depth { get; set; }
        public virtual decimal? Weight { get; set; }
        public virtual decimal ShippingWeight { get; set; }
        public virtual TimeSpan? ValidStartTimeOfDayForPurchase { get; set; }
        public virtual TimeSpan? ValidEndTimeOfDayForPurchase { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Product()
        {
        }
        #endregion
    }
    #endregion

    #region purchase
    public partial class Purchase : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual int PersonId { get; set; }
        public virtual string OrderNumber { get; set; }
        public virtual string TotalPurchaseQuantity { get; set; }
        public virtual double TotalPurchaseAmount { get; set; }
        public virtual DateTime PurchaseDate { get; set; }
        public virtual DateTime? ShipDate { get; set; }
        public virtual DateTime? ExpectedDeliveryDate { get; set; }
        public virtual Guid? TrackingIdentifier { get; set; }
        public virtual DbEx.Data.PaymentMethodType PaymentMethodType { get; set; }
        public virtual DbEx.Data.PaymentSourceType? PaymentSourceType { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Purchase()
        {
        }
        #endregion
    }
    #endregion

    #region purchase line
    public partial class PurchaseLine : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual int PurchaseId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual decimal PurchasePrice { get; set; }
        public virtual int Quantity { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public PurchaseLine()
        {
        }
        #endregion
    }
    #endregion

    #region unit test
    public partial class UnitTest : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual bool Boolean { get; set; }
        public virtual bool? NullableBoolean { get; set; }
        public virtual byte Byte { get; set; }
        public virtual byte? NullableByte { get; set; }
        public virtual byte[] ByteArray { get; set; }
        public virtual byte[] NullableByteArray { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual DateTime? NullableDateTime { get; set; }
        public virtual DateTimeOffset DateTimeOffset { get; set; }
        public virtual DateTimeOffset? NullableDateTimeOffset { get; set; }
        public virtual decimal Decimal { get; set; }
        public virtual decimal? NullableDecimal { get; set; }
        public virtual double Double { get; set; }
        public virtual double? NullableDouble { get; set; }
        public virtual Guid Guid { get; set; }
        public virtual Guid? NullableGuid { get; set; }
        public virtual short Int16 { get; set; }
        public virtual short? NullableInt16 { get; set; }
        public virtual int Int32 { get; set; }
        public virtual int? NullableInt32 { get; set; }
        public virtual long Int64 { get; set; }
        public virtual long? NullableInt64 { get; set; }
        public virtual float Single { get; set; }
        public virtual float? NullableSingle { get; set; }
        public virtual string String { get; set; }
        public virtual string NullableString { get; set; }
        public virtual TimeSpan? TimeSpan { get; set; }
        public virtual TimeSpan? NullableTimeSpan { get; set; }
        #endregion

        #region constructor
        public UnitTest()
        {
        }
        #endregion
    }
    #endregion

    #region person total purchases view
    public partial class PersonTotalPurchasesView : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual double? TotalAmount { get; set; }
        public virtual int? TotalCount { get; set; }
        #endregion

        #region constructor
        public PersonTotalPurchasesView()
        {
        }
        #endregion
    }
    #endregion

}
namespace DbEx.secData
{
    #region person
    public partial class Person : IDbEntity
    {
        #region interface
        public virtual int Id { get; set; }
        public virtual string SocialSecurityNumber { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        #endregion

        #region constructor
        public Person()
        {
        }
        #endregion
    }
    #endregion

}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
