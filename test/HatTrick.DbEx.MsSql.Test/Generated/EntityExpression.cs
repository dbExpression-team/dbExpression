
namespace DbEx.dboDataService
{
    using DbEx.dboData;
    using DbEx.Data;
    using HatTrick.DbEx.Sql.Executor;
    using HatTrick.DbEx.Sql.Expression;
    using System;

    #region address
    public partial class AddressEntity : EntityExpression<Address>
    {
        #region internals
        private const string _idFieldIdentifier = "MsSqlDbExTest.dbo.Address.Id";
        private const string _addressTypeFieldIdentifier = "MsSqlDbExTest.dbo.Address.AddressType";
        private const string _line1FieldIdentifier = "MsSqlDbExTest.dbo.Address.Line1";
        private const string _line2FieldIdentifier = "MsSqlDbExTest.dbo.Address.Line2";
        private const string _cityFieldIdentifier = "MsSqlDbExTest.dbo.Address.City";
        private const string _stateFieldIdentifier = "MsSqlDbExTest.dbo.Address.State";
        private const string _zipFieldIdentifier = "MsSqlDbExTest.dbo.Address.Zip";
        private const string _dateCreatedFieldIdentifier = "MsSqlDbExTest.dbo.Address.DateCreated";
        private const string _dateUpdatedFieldIdentifier = "MsSqlDbExTest.dbo.Address.DateUpdated";
        #endregion

        #region interface properties
		public Int32FieldExpression<Address> Id { get { return Fields[_idFieldIdentifier] as Int32FieldExpression<Address>; } }
		public NullableEnumFieldExpression<Address, AddressType> AddressType { get { return Fields[_addressTypeFieldIdentifier] as NullableEnumFieldExpression<Address, AddressType>; } }
		public StringFieldExpression<Address> Line1 { get { return Fields[_line1FieldIdentifier] as StringFieldExpression<Address>; } }
		public StringFieldExpression<Address> Line2 { get { return Fields[_line2FieldIdentifier] as StringFieldExpression<Address>; } }
		public StringFieldExpression<Address> City { get { return Fields[_cityFieldIdentifier] as StringFieldExpression<Address>; } }
		public StringFieldExpression<Address> State { get { return Fields[_stateFieldIdentifier] as StringFieldExpression<Address>; } }
		public StringFieldExpression<Address> Zip { get { return Fields[_zipFieldIdentifier] as StringFieldExpression<Address>; } }
		public DateTimeFieldExpression<Address> DateCreated { get { return Fields[_dateCreatedFieldIdentifier] as DateTimeFieldExpression<Address>; } }
		public DateTimeFieldExpression<Address> DateUpdated { get { return Fields[_dateUpdatedFieldIdentifier] as DateTimeFieldExpression<Address>; } }
        #endregion

        #region constructors
		public AddressEntity(SchemaExpression schema): this(schema, null)
        {
        }

        private AddressEntity(SchemaExpression schema, string alias) : base("MsSqlDbExTest.dbo.Address", schema, alias)
        {
			Fields.Add(_idFieldIdentifier, new Int32FieldExpression<Address>(_idFieldIdentifier, this));
			Fields.Add(_addressTypeFieldIdentifier, new NullableEnumFieldExpression<Address, AddressType>(_addressTypeFieldIdentifier, this));
			Fields.Add(_line1FieldIdentifier, new StringFieldExpression<Address>(_line1FieldIdentifier, this));
			Fields.Add(_line2FieldIdentifier, new StringFieldExpression<Address>(_line2FieldIdentifier, this));
			Fields.Add(_cityFieldIdentifier, new StringFieldExpression<Address>(_cityFieldIdentifier, this));
			Fields.Add(_stateFieldIdentifier, new StringFieldExpression<Address>(_stateFieldIdentifier, this));
			Fields.Add(_zipFieldIdentifier, new StringFieldExpression<Address>(_zipFieldIdentifier, this));
			Fields.Add(_dateCreatedFieldIdentifier, new DateTimeFieldExpression<Address>(_dateCreatedFieldIdentifier, this));
			Fields.Add(_dateUpdatedFieldIdentifier, new DateTimeFieldExpression<Address>(_dateUpdatedFieldIdentifier, this));
        }
        #endregion

        #region methods
        public AddressEntity As(string name)
        {
            return new AddressEntity(this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                AddressType,
                Line1,
                Line2,
                City,
                State,
                Zip,
                DateCreated,
                DateUpdated
            );
        }
		
        protected override InsertExpressionSet<Address> GetInclusiveInsertExpression(Address address)
        {
            return new InsertExpressionSet<Address>(
				address,
                Id.Insert(address.Id),
                AddressType.Insert(address.AddressType),
                Line1.Insert(address.Line1),
                Line2.Insert(address.Line2),
                City.Insert(address.City),
                State.Insert(address.State),
                Zip.Insert(address.Zip),
                DateCreated.Insert(address.DateCreated),
                DateUpdated.Insert(address.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Address from, Address to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.AddressType != to.AddressType) { expr &= AddressType.Set(to.AddressType); };
			if (from.Line1 != to.Line1) { expr &= Line1.Set(to.Line1); };
			if (from.Line2 != to.Line2) { expr &= Line2.Set(to.Line2); };
			if (from.City != to.City) { expr &= City.Set(to.City); };
			if (from.State != to.State) { expr &= State.Set(to.State); };
			if (from.Zip != to.Zip) { expr &= Zip.Set(to.Zip); };
			if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); };
            expr &= DateUpdated.Set(DateTime.UtcNow);
			
            return expr;
        }

        protected override void HydrateEntity(Address address, ISqlFieldReader reader)
        {
			address.Id = reader.ReadField().GetValue<int>();
			address.AddressType = reader.ReadField().GetValue<AddressType?>();
			address.Line1 = reader.ReadField().GetValue<string>();
			address.Line2 = reader.ReadField().GetValue<string>();
			address.City = reader.ReadField().GetValue<string>();
			address.State = reader.ReadField().GetValue<string>();
			address.Zip = reader.ReadField().GetValue<string>();
			address.DateCreated = reader.ReadField().GetValue<DateTime>();
			address.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion
    }
    #endregion

    #region person
    public partial class PersonEntity : EntityExpression<Person>
    {
        #region internals
        private const string _idFieldIdentifier = "MsSqlDbExTest.dbo.Person.Id";
        private const string _firstNameFieldIdentifier = "MsSqlDbExTest.dbo.Person.FirstName";
        private const string _lastNameFieldIdentifier = "MsSqlDbExTest.dbo.Person.LastName";
        private const string _birthDateFieldIdentifier = "MsSqlDbExTest.dbo.Person.BirthDate";
        private const string _genderTypeFieldIdentifier = "MsSqlDbExTest.dbo.Person.GenderType";
        private const string _creditLimitFieldIdentifier = "MsSqlDbExTest.dbo.Person.CreditLimit";
        private const string _yearOfLastCreditLimitReviewFieldIdentifier = "MsSqlDbExTest.dbo.Person.YearOfLastCreditLimitReview";
        private const string _dateCreatedFieldIdentifier = "MsSqlDbExTest.dbo.Person.DateCreated";
        private const string _dateUpdatedFieldIdentifier = "MsSqlDbExTest.dbo.Person.DateUpdated";
        #endregion

        #region interface properties
		public Int32FieldExpression<Person> Id { get { return Fields[_idFieldIdentifier] as Int32FieldExpression<Person>; } }
		public StringFieldExpression<Person> FirstName { get { return Fields[_firstNameFieldIdentifier] as StringFieldExpression<Person>; } }
		public StringFieldExpression<Person> LastName { get { return Fields[_lastNameFieldIdentifier] as StringFieldExpression<Person>; } }
		public NullableDateTimeFieldExpression<Person> BirthDate { get { return Fields[_birthDateFieldIdentifier] as NullableDateTimeFieldExpression<Person>; } }
		public EnumFieldExpression<Person, GenderType> GenderType { get { return Fields[_genderTypeFieldIdentifier] as EnumFieldExpression<Person, GenderType>; } }
		public NullableInt32FieldExpression<Person> CreditLimit { get { return Fields[_creditLimitFieldIdentifier] as NullableInt32FieldExpression<Person>; } }
		public NullableInt32FieldExpression<Person> YearOfLastCreditLimitReview { get { return Fields[_yearOfLastCreditLimitReviewFieldIdentifier] as NullableInt32FieldExpression<Person>; } }
		public DateTimeFieldExpression<Person> DateCreated { get { return Fields[_dateCreatedFieldIdentifier] as DateTimeFieldExpression<Person>; } }
		public DateTimeFieldExpression<Person> DateUpdated { get { return Fields[_dateUpdatedFieldIdentifier] as DateTimeFieldExpression<Person>; } }
        #endregion

        #region constructors
		public PersonEntity(SchemaExpression schema): this(schema, null)
        {
        }

        private PersonEntity(SchemaExpression schema, string alias) : base("MsSqlDbExTest.dbo.Person", schema, alias)
        {
			Fields.Add(_idFieldIdentifier, new Int32FieldExpression<Person>(_idFieldIdentifier, this));
			Fields.Add(_firstNameFieldIdentifier, new StringFieldExpression<Person>(_firstNameFieldIdentifier, this));
			Fields.Add(_lastNameFieldIdentifier, new StringFieldExpression<Person>(_lastNameFieldIdentifier, this));
			Fields.Add(_birthDateFieldIdentifier, new NullableDateTimeFieldExpression<Person>(_birthDateFieldIdentifier, this));
			Fields.Add(_genderTypeFieldIdentifier, new EnumFieldExpression<Person, GenderType>(_genderTypeFieldIdentifier, this));
			Fields.Add(_creditLimitFieldIdentifier, new NullableInt32FieldExpression<Person>(_creditLimitFieldIdentifier, this));
			Fields.Add(_yearOfLastCreditLimitReviewFieldIdentifier, new NullableInt32FieldExpression<Person>(_yearOfLastCreditLimitReviewFieldIdentifier, this));
			Fields.Add(_dateCreatedFieldIdentifier, new DateTimeFieldExpression<Person>(_dateCreatedFieldIdentifier, this));
			Fields.Add(_dateUpdatedFieldIdentifier, new DateTimeFieldExpression<Person>(_dateUpdatedFieldIdentifier, this));
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
        {
            return new PersonEntity(this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                FirstName,
                LastName,
                BirthDate,
                GenderType,
                CreditLimit,
                YearOfLastCreditLimitReview,
                DateCreated,
                DateUpdated
            );
        }
		
        protected override InsertExpressionSet<Person> GetInclusiveInsertExpression(Person person)
        {
            return new InsertExpressionSet<Person>(
				person,
                Id.Insert(person.Id),
                FirstName.Insert(person.FirstName),
                LastName.Insert(person.LastName),
                BirthDate.Insert(person.BirthDate),
                GenderType.Insert(person.GenderType),
                CreditLimit.Insert(person.CreditLimit),
                YearOfLastCreditLimitReview.Insert(person.YearOfLastCreditLimitReview),
                DateCreated.Insert(person.DateCreated),
                DateUpdated.Insert(person.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person from, Person to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.FirstName != to.FirstName) { expr &= FirstName.Set(to.FirstName); };
			if (from.LastName != to.LastName) { expr &= LastName.Set(to.LastName); };
			if (from.BirthDate != to.BirthDate) { expr &= BirthDate.Set(to.BirthDate); };
			if (from.GenderType != to.GenderType) { expr &= GenderType.Set(to.GenderType); };
			if (from.CreditLimit != to.CreditLimit) { expr &= CreditLimit.Set(to.CreditLimit); };
			if (from.YearOfLastCreditLimitReview != to.YearOfLastCreditLimitReview) { expr &= YearOfLastCreditLimitReview.Set(to.YearOfLastCreditLimitReview); };
			if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); };
            expr &= DateUpdated.Set(DateTime.UtcNow);
			
            return expr;
        }

        protected override void HydrateEntity(Person person, ISqlFieldReader reader)
        {
			person.Id = reader.ReadField().GetValue<int>();
			person.FirstName = reader.ReadField().GetValue<string>();
			person.LastName = reader.ReadField().GetValue<string>();
			person.BirthDate = reader.ReadField().GetValue<DateTime?>();
			person.GenderType = reader.ReadField().GetValue<GenderType>();
			person.CreditLimit = reader.ReadField().GetValue<int?>();
			person.YearOfLastCreditLimitReview = reader.ReadField().GetValue<int?>();
			person.DateCreated = reader.ReadField().GetValue<DateTime>();
			person.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion
    }
    #endregion

    #region person address
    public partial class PersonAddressEntity : EntityExpression<PersonAddress>
    {
        #region internals
        private const string _idFieldIdentifier = "MsSqlDbExTest.dbo.Person_Address.Id";
        private const string _personIdFieldIdentifier = "MsSqlDbExTest.dbo.Person_Address.PersonId";
        private const string _addressIdFieldIdentifier = "MsSqlDbExTest.dbo.Person_Address.AddressId";
        private const string _dateCreatedFieldIdentifier = "MsSqlDbExTest.dbo.Person_Address.DateCreated";
        #endregion

        #region interface properties
		public Int32FieldExpression<PersonAddress> Id { get { return Fields[_idFieldIdentifier] as Int32FieldExpression<PersonAddress>; } }
		public Int32FieldExpression<PersonAddress> PersonId { get { return Fields[_personIdFieldIdentifier] as Int32FieldExpression<PersonAddress>; } }
		public Int32FieldExpression<PersonAddress> AddressId { get { return Fields[_addressIdFieldIdentifier] as Int32FieldExpression<PersonAddress>; } }
		public DateTimeFieldExpression<PersonAddress> DateCreated { get { return Fields[_dateCreatedFieldIdentifier] as DateTimeFieldExpression<PersonAddress>; } }
        #endregion

        #region constructors
		public PersonAddressEntity(SchemaExpression schema): this(schema, null)
        {
        }

        private PersonAddressEntity(SchemaExpression schema, string alias) : base("MsSqlDbExTest.dbo.Person_Address", schema, alias)
        {
			Fields.Add(_idFieldIdentifier, new Int32FieldExpression<PersonAddress>(_idFieldIdentifier, this));
			Fields.Add(_personIdFieldIdentifier, new Int32FieldExpression<PersonAddress>(_personIdFieldIdentifier, this));
			Fields.Add(_addressIdFieldIdentifier, new Int32FieldExpression<PersonAddress>(_addressIdFieldIdentifier, this));
			Fields.Add(_dateCreatedFieldIdentifier, new DateTimeFieldExpression<PersonAddress>(_dateCreatedFieldIdentifier, this));
        }
        #endregion

        #region methods
        public PersonAddressEntity As(string name)
        {
            return new PersonAddressEntity(this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                PersonId,
                AddressId,
                DateCreated
            );
        }
		
        protected override InsertExpressionSet<PersonAddress> GetInclusiveInsertExpression(PersonAddress personAddress)
        {
            return new InsertExpressionSet<PersonAddress>(
				personAddress,
                Id.Insert(personAddress.Id),
                PersonId.Insert(personAddress.PersonId),
                AddressId.Insert(personAddress.AddressId),
                DateCreated.Insert(personAddress.DateCreated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PersonAddress from, PersonAddress to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.PersonId != to.PersonId) { expr &= PersonId.Set(to.PersonId); };
			if (from.AddressId != to.AddressId) { expr &= AddressId.Set(to.AddressId); };
			if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); };
			
            return expr;
        }

        protected override void HydrateEntity(PersonAddress personAddress, ISqlFieldReader reader)
        {
			personAddress.Id = reader.ReadField().GetValue<int>();
			personAddress.PersonId = reader.ReadField().GetValue<int>();
			personAddress.AddressId = reader.ReadField().GetValue<int>();
			personAddress.DateCreated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion
    }
    #endregion

    #region product
    public partial class ProductEntity : EntityExpression<Product>
    {
        #region internals
        private const string _idFieldIdentifier = "MsSqlDbExTest.dbo.Product.Id";
        private const string _productCategoryTypeFieldIdentifier = "MsSqlDbExTest.dbo.Product.ProductCategoryType";
        private const string _nameFieldIdentifier = "MsSqlDbExTest.dbo.Product.Name";
        private const string _descriptionFieldIdentifier = "MsSqlDbExTest.dbo.Product.Description";
        private const string _listPriceFieldIdentifier = "MsSqlDbExTest.dbo.Product.ListPrice";
        private const string _priceFieldIdentifier = "MsSqlDbExTest.dbo.Product.Price";
        private const string _quantityFieldIdentifier = "MsSqlDbExTest.dbo.Product.Quantity";
        private const string _dateCreatedFieldIdentifier = "MsSqlDbExTest.dbo.Product.DateCreated";
        private const string _dateUpdatedFieldIdentifier = "MsSqlDbExTest.dbo.Product.DateUpdated";
        #endregion

        #region interface properties
		public Int32FieldExpression<Product> Id { get { return Fields[_idFieldIdentifier] as Int32FieldExpression<Product>; } }
		public NullableEnumFieldExpression<Product, ProductCategoryType> ProductCategoryType { get { return Fields[_productCategoryTypeFieldIdentifier] as NullableEnumFieldExpression<Product, ProductCategoryType>; } }
		public StringFieldExpression<Product> Name { get { return Fields[_nameFieldIdentifier] as StringFieldExpression<Product>; } }
		public StringFieldExpression<Product> Description { get { return Fields[_descriptionFieldIdentifier] as StringFieldExpression<Product>; } }
		public DecimalFieldExpression<Product> ListPrice { get { return Fields[_listPriceFieldIdentifier] as DecimalFieldExpression<Product>; } }
		public DecimalFieldExpression<Product> Price { get { return Fields[_priceFieldIdentifier] as DecimalFieldExpression<Product>; } }
		public Int32FieldExpression<Product> Quantity { get { return Fields[_quantityFieldIdentifier] as Int32FieldExpression<Product>; } }
		public DateTimeFieldExpression<Product> DateCreated { get { return Fields[_dateCreatedFieldIdentifier] as DateTimeFieldExpression<Product>; } }
		public DateTimeFieldExpression<Product> DateUpdated { get { return Fields[_dateUpdatedFieldIdentifier] as DateTimeFieldExpression<Product>; } }
        #endregion

        #region constructors
		public ProductEntity(SchemaExpression schema): this(schema, null)
        {
        }

        private ProductEntity(SchemaExpression schema, string alias) : base("MsSqlDbExTest.dbo.Product", schema, alias)
        {
			Fields.Add(_idFieldIdentifier, new Int32FieldExpression<Product>(_idFieldIdentifier, this));
			Fields.Add(_productCategoryTypeFieldIdentifier, new NullableEnumFieldExpression<Product, ProductCategoryType>(_productCategoryTypeFieldIdentifier, this));
			Fields.Add(_nameFieldIdentifier, new StringFieldExpression<Product>(_nameFieldIdentifier, this));
			Fields.Add(_descriptionFieldIdentifier, new StringFieldExpression<Product>(_descriptionFieldIdentifier, this));
			Fields.Add(_listPriceFieldIdentifier, new DecimalFieldExpression<Product>(_listPriceFieldIdentifier, this));
			Fields.Add(_priceFieldIdentifier, new DecimalFieldExpression<Product>(_priceFieldIdentifier, this));
			Fields.Add(_quantityFieldIdentifier, new Int32FieldExpression<Product>(_quantityFieldIdentifier, this));
			Fields.Add(_dateCreatedFieldIdentifier, new DateTimeFieldExpression<Product>(_dateCreatedFieldIdentifier, this));
			Fields.Add(_dateUpdatedFieldIdentifier, new DateTimeFieldExpression<Product>(_dateUpdatedFieldIdentifier, this));
        }
        #endregion

        #region methods
        public ProductEntity As(string name)
        {
            return new ProductEntity(this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                ProductCategoryType,
                Name,
                Description,
                ListPrice,
                Price,
                Quantity,
                DateCreated,
                DateUpdated
            );
        }
		
        protected override InsertExpressionSet<Product> GetInclusiveInsertExpression(Product product)
        {
            return new InsertExpressionSet<Product>(
				product,
                Id.Insert(product.Id),
                ProductCategoryType.Insert(product.ProductCategoryType),
                Name.Insert(product.Name),
                Description.Insert(product.Description),
                ListPrice.Insert(product.ListPrice),
                Price.Insert(product.Price),
                Quantity.Insert(product.Quantity),
                DateCreated.Insert(product.DateCreated),
                DateUpdated.Insert(product.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Product from, Product to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.ProductCategoryType != to.ProductCategoryType) { expr &= ProductCategoryType.Set(to.ProductCategoryType); };
			if (from.Name != to.Name) { expr &= Name.Set(to.Name); };
			if (from.Description != to.Description) { expr &= Description.Set(to.Description); };
			if (from.ListPrice != to.ListPrice) { expr &= ListPrice.Set(to.ListPrice); };
			if (from.Price != to.Price) { expr &= Price.Set(to.Price); };
			if (from.Quantity != to.Quantity) { expr &= Quantity.Set(to.Quantity); };
			if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); };
            expr &= DateUpdated.Set(DateTime.UtcNow);
			
            return expr;
        }

        protected override void HydrateEntity(Product product, ISqlFieldReader reader)
        {
			product.Id = reader.ReadField().GetValue<int>();
			product.ProductCategoryType = reader.ReadField().GetValue<ProductCategoryType?>();
			product.Name = reader.ReadField().GetValue<string>();
			product.Description = reader.ReadField().GetValue<string>();
			product.ListPrice = reader.ReadField().GetValue<decimal>();
			product.Price = reader.ReadField().GetValue<decimal>();
			product.Quantity = reader.ReadField().GetValue<int>();
			product.DateCreated = reader.ReadField().GetValue<DateTime>();
			product.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion
    }
    #endregion

    #region purchase
    public partial class PurchaseEntity : EntityExpression<Purchase>
    {
        #region internals
        private const string _idFieldIdentifier = "MsSqlDbExTest.dbo.Purchase.Id";
        private const string _personIdFieldIdentifier = "MsSqlDbExTest.dbo.Purchase.PersonId";
        private const string _totalPurchaseAmountFieldIdentifier = "MsSqlDbExTest.dbo.Purchase.TotalPurchaseAmount";
        private const string _purchaseDateFieldIdentifier = "MsSqlDbExTest.dbo.Purchase.PurchaseDate";
        private const string _shipDateFieldIdentifier = "MsSqlDbExTest.dbo.Purchase.ShipDate";
        private const string _expectedDeliveryDateFieldIdentifier = "MsSqlDbExTest.dbo.Purchase.ExpectedDeliveryDate";
        private const string _trackingIdentifierFieldIdentifier = "MsSqlDbExTest.dbo.Purchase.TrackingIdentifier";
        private const string _paymentMethodTypeFieldIdentifier = "MsSqlDbExTest.dbo.Purchase.PaymentMethodType";
        private const string _dateCreatedFieldIdentifier = "MsSqlDbExTest.dbo.Purchase.DateCreated";
        private const string _dateUpdatedFieldIdentifier = "MsSqlDbExTest.dbo.Purchase.DateUpdated";
        #endregion

        #region interface properties
		public Int32FieldExpression<Purchase> Id { get { return Fields[_idFieldIdentifier] as Int32FieldExpression<Purchase>; } }
		public Int32FieldExpression<Purchase> PersonId { get { return Fields[_personIdFieldIdentifier] as Int32FieldExpression<Purchase>; } }
		public DecimalFieldExpression<Purchase> TotalPurchaseAmount { get { return Fields[_totalPurchaseAmountFieldIdentifier] as DecimalFieldExpression<Purchase>; } }
		public DateTimeFieldExpression<Purchase> PurchaseDate { get { return Fields[_purchaseDateFieldIdentifier] as DateTimeFieldExpression<Purchase>; } }
		public NullableDateTimeFieldExpression<Purchase> ShipDate { get { return Fields[_shipDateFieldIdentifier] as NullableDateTimeFieldExpression<Purchase>; } }
		public NullableDateTimeFieldExpression<Purchase> ExpectedDeliveryDate { get { return Fields[_expectedDeliveryDateFieldIdentifier] as NullableDateTimeFieldExpression<Purchase>; } }
		public NullableGuidFieldExpression<Purchase> TrackingIdentifier { get { return Fields[_trackingIdentifierFieldIdentifier] as NullableGuidFieldExpression<Purchase>; } }
		public EnumFieldExpression<Purchase, PaymentMethodType> PaymentMethodType { get { return Fields[_paymentMethodTypeFieldIdentifier] as EnumFieldExpression<Purchase, PaymentMethodType>; } }
		public DateTimeFieldExpression<Purchase> DateCreated { get { return Fields[_dateCreatedFieldIdentifier] as DateTimeFieldExpression<Purchase>; } }
		public DateTimeFieldExpression<Purchase> DateUpdated { get { return Fields[_dateUpdatedFieldIdentifier] as DateTimeFieldExpression<Purchase>; } }
        #endregion

        #region constructors
		public PurchaseEntity(SchemaExpression schema): this(schema, null)
        {
        }

        private PurchaseEntity(SchemaExpression schema, string alias) : base("MsSqlDbExTest.dbo.Purchase", schema, alias)
        {
			Fields.Add(_idFieldIdentifier, new Int32FieldExpression<Purchase>(_idFieldIdentifier, this));
			Fields.Add(_personIdFieldIdentifier, new Int32FieldExpression<Purchase>(_personIdFieldIdentifier, this));
			Fields.Add(_totalPurchaseAmountFieldIdentifier, new DecimalFieldExpression<Purchase>(_totalPurchaseAmountFieldIdentifier, this));
			Fields.Add(_purchaseDateFieldIdentifier, new DateTimeFieldExpression<Purchase>(_purchaseDateFieldIdentifier, this));
			Fields.Add(_shipDateFieldIdentifier, new NullableDateTimeFieldExpression<Purchase>(_shipDateFieldIdentifier, this));
			Fields.Add(_expectedDeliveryDateFieldIdentifier, new NullableDateTimeFieldExpression<Purchase>(_expectedDeliveryDateFieldIdentifier, this));
			Fields.Add(_trackingIdentifierFieldIdentifier, new NullableGuidFieldExpression<Purchase>(_trackingIdentifierFieldIdentifier, this));
			Fields.Add(_paymentMethodTypeFieldIdentifier, new EnumFieldExpression<Purchase, PaymentMethodType>(_paymentMethodTypeFieldIdentifier, this));
			Fields.Add(_dateCreatedFieldIdentifier, new DateTimeFieldExpression<Purchase>(_dateCreatedFieldIdentifier, this));
			Fields.Add(_dateUpdatedFieldIdentifier, new DateTimeFieldExpression<Purchase>(_dateUpdatedFieldIdentifier, this));
        }
        #endregion

        #region methods
        public PurchaseEntity As(string name)
        {
            return new PurchaseEntity(this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                PersonId,
                TotalPurchaseAmount,
                PurchaseDate,
                ShipDate,
                ExpectedDeliveryDate,
                TrackingIdentifier,
                PaymentMethodType,
                DateCreated,
                DateUpdated
            );
        }
		
        protected override InsertExpressionSet<Purchase> GetInclusiveInsertExpression(Purchase purchase)
        {
            return new InsertExpressionSet<Purchase>(
				purchase,
                Id.Insert(purchase.Id),
                PersonId.Insert(purchase.PersonId),
                TotalPurchaseAmount.Insert(purchase.TotalPurchaseAmount),
                PurchaseDate.Insert(purchase.PurchaseDate),
                ShipDate.Insert(purchase.ShipDate),
                ExpectedDeliveryDate.Insert(purchase.ExpectedDeliveryDate),
                TrackingIdentifier.Insert(purchase.TrackingIdentifier),
                PaymentMethodType.Insert(purchase.PaymentMethodType),
                DateCreated.Insert(purchase.DateCreated),
                DateUpdated.Insert(purchase.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Purchase from, Purchase to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.PersonId != to.PersonId) { expr &= PersonId.Set(to.PersonId); };
			if (from.TotalPurchaseAmount != to.TotalPurchaseAmount) { expr &= TotalPurchaseAmount.Set(to.TotalPurchaseAmount); };
			if (from.PurchaseDate != to.PurchaseDate) { expr &= PurchaseDate.Set(to.PurchaseDate); };
			if (from.ShipDate != to.ShipDate) { expr &= ShipDate.Set(to.ShipDate); };
			if (from.ExpectedDeliveryDate != to.ExpectedDeliveryDate) { expr &= ExpectedDeliveryDate.Set(to.ExpectedDeliveryDate); };
			if (from.TrackingIdentifier != to.TrackingIdentifier) { expr &= TrackingIdentifier.Set(to.TrackingIdentifier); };
			if (from.PaymentMethodType != to.PaymentMethodType) { expr &= PaymentMethodType.Set(to.PaymentMethodType); };
			if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); };
            expr &= DateUpdated.Set(DateTime.UtcNow);
			
            return expr;
        }

        protected override void HydrateEntity(Purchase purchase, ISqlFieldReader reader)
        {
			purchase.Id = reader.ReadField().GetValue<int>();
			purchase.PersonId = reader.ReadField().GetValue<int>();
			purchase.TotalPurchaseAmount = reader.ReadField().GetValue<decimal>();
			purchase.PurchaseDate = reader.ReadField().GetValue<DateTime>();
			purchase.ShipDate = reader.ReadField().GetValue<DateTime?>();
			purchase.ExpectedDeliveryDate = reader.ReadField().GetValue<DateTime?>();
			purchase.TrackingIdentifier = reader.ReadField().GetValue<Guid?>();
			purchase.PaymentMethodType = reader.ReadField().GetValue<PaymentMethodType>();
			purchase.DateCreated = reader.ReadField().GetValue<DateTime>();
			purchase.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion
    }
    #endregion

    #region purchase line
    public partial class PurchaseLineEntity : EntityExpression<PurchaseLine>
    {
        #region internals
        private const string _idFieldIdentifier = "MsSqlDbExTest.dbo.PurchaseLine.Id";
        private const string _purchaseIdFieldIdentifier = "MsSqlDbExTest.dbo.PurchaseLine.PurchaseId";
        private const string _productIdFieldIdentifier = "MsSqlDbExTest.dbo.PurchaseLine.ProductId";
        private const string _purchasePriceFieldIdentifier = "MsSqlDbExTest.dbo.PurchaseLine.PurchasePrice";
        private const string _quantityFieldIdentifier = "MsSqlDbExTest.dbo.PurchaseLine.Quantity";
        private const string _dateCreatedFieldIdentifier = "MsSqlDbExTest.dbo.PurchaseLine.DateCreated";
        private const string _dateUpdatedFieldIdentifier = "MsSqlDbExTest.dbo.PurchaseLine.DateUpdated";
        #endregion

        #region interface properties
		public Int32FieldExpression<PurchaseLine> Id { get { return Fields[_idFieldIdentifier] as Int32FieldExpression<PurchaseLine>; } }
		public Int32FieldExpression<PurchaseLine> PurchaseId { get { return Fields[_purchaseIdFieldIdentifier] as Int32FieldExpression<PurchaseLine>; } }
		public Int32FieldExpression<PurchaseLine> ProductId { get { return Fields[_productIdFieldIdentifier] as Int32FieldExpression<PurchaseLine>; } }
		public DecimalFieldExpression<PurchaseLine> PurchasePrice { get { return Fields[_purchasePriceFieldIdentifier] as DecimalFieldExpression<PurchaseLine>; } }
		public Int32FieldExpression<PurchaseLine> Quantity { get { return Fields[_quantityFieldIdentifier] as Int32FieldExpression<PurchaseLine>; } }
		public DateTimeFieldExpression<PurchaseLine> DateCreated { get { return Fields[_dateCreatedFieldIdentifier] as DateTimeFieldExpression<PurchaseLine>; } }
		public DateTimeFieldExpression<PurchaseLine> DateUpdated { get { return Fields[_dateUpdatedFieldIdentifier] as DateTimeFieldExpression<PurchaseLine>; } }
        #endregion

        #region constructors
		public PurchaseLineEntity(SchemaExpression schema): this(schema, null)
        {
        }

        private PurchaseLineEntity(SchemaExpression schema, string alias) : base("MsSqlDbExTest.dbo.PurchaseLine", schema, alias)
        {
			Fields.Add(_idFieldIdentifier, new Int32FieldExpression<PurchaseLine>(_idFieldIdentifier, this));
			Fields.Add(_purchaseIdFieldIdentifier, new Int32FieldExpression<PurchaseLine>(_purchaseIdFieldIdentifier, this));
			Fields.Add(_productIdFieldIdentifier, new Int32FieldExpression<PurchaseLine>(_productIdFieldIdentifier, this));
			Fields.Add(_purchasePriceFieldIdentifier, new DecimalFieldExpression<PurchaseLine>(_purchasePriceFieldIdentifier, this));
			Fields.Add(_quantityFieldIdentifier, new Int32FieldExpression<PurchaseLine>(_quantityFieldIdentifier, this));
			Fields.Add(_dateCreatedFieldIdentifier, new DateTimeFieldExpression<PurchaseLine>(_dateCreatedFieldIdentifier, this));
			Fields.Add(_dateUpdatedFieldIdentifier, new DateTimeFieldExpression<PurchaseLine>(_dateUpdatedFieldIdentifier, this));
        }
        #endregion

        #region methods
        public PurchaseLineEntity As(string name)
        {
            return new PurchaseLineEntity(this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                PurchaseId,
                ProductId,
                PurchasePrice,
                Quantity,
                DateCreated,
                DateUpdated
            );
        }
		
        protected override InsertExpressionSet<PurchaseLine> GetInclusiveInsertExpression(PurchaseLine purchaseLine)
        {
            return new InsertExpressionSet<PurchaseLine>(
				purchaseLine,
                Id.Insert(purchaseLine.Id),
                PurchaseId.Insert(purchaseLine.PurchaseId),
                ProductId.Insert(purchaseLine.ProductId),
                PurchasePrice.Insert(purchaseLine.PurchasePrice),
                Quantity.Insert(purchaseLine.Quantity),
                DateCreated.Insert(purchaseLine.DateCreated),
                DateUpdated.Insert(purchaseLine.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PurchaseLine from, PurchaseLine to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.PurchaseId != to.PurchaseId) { expr &= PurchaseId.Set(to.PurchaseId); };
			if (from.ProductId != to.ProductId) { expr &= ProductId.Set(to.ProductId); };
			if (from.PurchasePrice != to.PurchasePrice) { expr &= PurchasePrice.Set(to.PurchasePrice); };
			if (from.Quantity != to.Quantity) { expr &= Quantity.Set(to.Quantity); };
			if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); };
            expr &= DateUpdated.Set(DateTime.UtcNow);
			
            return expr;
        }

        protected override void HydrateEntity(PurchaseLine purchaseLine, ISqlFieldReader reader)
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
    }
    #endregion

    #region person total purchases view
    public partial class PersonTotalPurchasesViewEntity : EntityExpression<PersonTotalPurchasesView>
    {
        #region internals
        private const string _idFieldIdentifier = "MsSqlDbExTest.dbo.PersonTotalPurchasesView.Id";
        private const string _totalPurchasesFieldIdentifier = "MsSqlDbExTest.dbo.PersonTotalPurchasesView.TotalPurchases";
        #endregion

        #region interface properties
		public Int32FieldExpression<PersonTotalPurchasesView> Id { get { return Fields[_idFieldIdentifier] as Int32FieldExpression<PersonTotalPurchasesView>; } }
		public NullableDecimalFieldExpression<PersonTotalPurchasesView> TotalPurchases { get { return Fields[_totalPurchasesFieldIdentifier] as NullableDecimalFieldExpression<PersonTotalPurchasesView>; } }
        #endregion

        #region constructors
		public PersonTotalPurchasesViewEntity(SchemaExpression schema): this(schema, null)
        {
        }

        private PersonTotalPurchasesViewEntity(SchemaExpression schema, string alias) : base("MsSqlDbExTest.dbo.PersonTotalPurchasesView", schema, alias)
        {
			Fields.Add(_idFieldIdentifier, new Int32FieldExpression<PersonTotalPurchasesView>(_idFieldIdentifier, this));
			Fields.Add(_totalPurchasesFieldIdentifier, new NullableDecimalFieldExpression<PersonTotalPurchasesView>(_totalPurchasesFieldIdentifier, this));
        }
        #endregion

        #region methods
        public PersonTotalPurchasesViewEntity As(string name)
        {
            return new PersonTotalPurchasesViewEntity(this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                TotalPurchases
            );
        }
		
        protected override InsertExpressionSet<PersonTotalPurchasesView> GetInclusiveInsertExpression(PersonTotalPurchasesView personTotalPurchasesView)
        {
            return new InsertExpressionSet<PersonTotalPurchasesView>(
				personTotalPurchasesView,
                Id.Insert(personTotalPurchasesView.Id),
                TotalPurchases.Insert(personTotalPurchasesView.TotalPurchases)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PersonTotalPurchasesView from, PersonTotalPurchasesView to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.Id != to.Id) { expr &= Id.Set(to.Id); };
			if (from.TotalPurchases != to.TotalPurchases) { expr &= TotalPurchases.Set(to.TotalPurchases); };
			
            return expr;
        }

        protected override void HydrateEntity(PersonTotalPurchasesView personTotalPurchasesView, ISqlFieldReader reader)
        {
			personTotalPurchasesView.Id = reader.ReadField().GetValue<int>();
			personTotalPurchasesView.TotalPurchases = reader.ReadField().GetValue<decimal?>();
        }
		#endregion
    }
    #endregion

}
namespace DbEx.secDataService
{
    using DbEx.secData;
    using DbEx.Data;
    using HatTrick.DbEx.Sql.Executor;
    using HatTrick.DbEx.Sql.Expression;
    using System;

    #region person
    public partial class PersonEntity : EntityExpression<Person>
    {
        #region internals
        private const string _idFieldIdentifier = "MsSqlDbExTest.sec.Person.Id";
        private const string _sSNFieldIdentifier = "MsSqlDbExTest.sec.Person.SSN";
        private const string _dateCreatedFieldIdentifier = "MsSqlDbExTest.sec.Person.DateCreated";
        private const string _dateUpdatedFieldIdentifier = "MsSqlDbExTest.sec.Person.DateUpdated";
        #endregion

        #region interface properties
		public Int32FieldExpression<Person> Id { get { return Fields[_idFieldIdentifier] as Int32FieldExpression<Person>; } }
		public StringFieldExpression<Person> SSN { get { return Fields[_sSNFieldIdentifier] as StringFieldExpression<Person>; } }
		public DateTimeFieldExpression<Person> DateCreated { get { return Fields[_dateCreatedFieldIdentifier] as DateTimeFieldExpression<Person>; } }
		public DateTimeFieldExpression<Person> DateUpdated { get { return Fields[_dateUpdatedFieldIdentifier] as DateTimeFieldExpression<Person>; } }
        #endregion

        #region constructors
		public PersonEntity(SchemaExpression schema): this(schema, null)
        {
        }

        private PersonEntity(SchemaExpression schema, string alias) : base("MsSqlDbExTest.sec.Person", schema, alias)
        {
			Fields.Add(_idFieldIdentifier, new Int32FieldExpression<Person>(_idFieldIdentifier, this));
			Fields.Add(_sSNFieldIdentifier, new StringFieldExpression<Person>(_sSNFieldIdentifier, this));
			Fields.Add(_dateCreatedFieldIdentifier, new DateTimeFieldExpression<Person>(_dateCreatedFieldIdentifier, this));
			Fields.Add(_dateUpdatedFieldIdentifier, new DateTimeFieldExpression<Person>(_dateUpdatedFieldIdentifier, this));
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
        {
            return new PersonEntity(this.schema, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                SSN,
                DateCreated,
                DateUpdated
            );
        }
		
        protected override InsertExpressionSet<Person> GetInclusiveInsertExpression(Person person)
        {
            return new InsertExpressionSet<Person>(
				person,
                Id.Insert(person.Id),
                SSN.Insert(person.SSN),
                DateCreated.Insert(person.DateCreated),
                DateUpdated.Insert(person.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person from, Person to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();

			if (from.SSN != to.SSN) { expr &= SSN.Set(to.SSN); };
			if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); };
            expr &= DateUpdated.Set(DateTime.UtcNow);
			
            return expr;
        }

        protected override void HydrateEntity(Person person, ISqlFieldReader reader)
        {
			person.Id = reader.ReadField().GetValue<int>();
			person.SSN = reader.ReadField().GetValue<string>();
			person.DateCreated = reader.ReadField().GetValue<DateTime>();
			person.DateUpdated = reader.ReadField().GetValue<DateTime>();
        }
		#endregion
    }
    #endregion

}