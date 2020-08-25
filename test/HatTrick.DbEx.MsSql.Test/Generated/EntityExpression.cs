
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
        private static string _idFieldIdentifier;
        private static string _addressTypeFieldIdentifier;
        private static string _line1FieldIdentifier;
        private static string _line2FieldIdentifier;
        private static string _cityFieldIdentifier;
        private static string _stateFieldIdentifier;
        private static string _zipFieldIdentifier;
        private static string _dateCreatedFieldIdentifier;
        private static string _dateUpdatedFieldIdentifier;
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
        private AddressEntity() : base(null, null, null)
        {
        }

		public AddressEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private AddressEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add(_idFieldIdentifier = $"{identifier}.Id", new Int32FieldExpression<Address>(_idFieldIdentifier, this));
            Fields.Add(_addressTypeFieldIdentifier = $"{identifier}.AddressType", new NullableEnumFieldExpression<Address, AddressType>(_addressTypeFieldIdentifier, this));
            Fields.Add(_line1FieldIdentifier = $"{identifier}.Line1", new StringFieldExpression<Address>(_line1FieldIdentifier, this));
            Fields.Add(_line2FieldIdentifier = $"{identifier}.Line2", new StringFieldExpression<Address>(_line2FieldIdentifier, this));
            Fields.Add(_cityFieldIdentifier = $"{identifier}.City", new StringFieldExpression<Address>(_cityFieldIdentifier, this));
            Fields.Add(_stateFieldIdentifier = $"{identifier}.State", new StringFieldExpression<Address>(_stateFieldIdentifier, this));
            Fields.Add(_zipFieldIdentifier = $"{identifier}.Zip", new StringFieldExpression<Address>(_zipFieldIdentifier, this));
            Fields.Add(_dateCreatedFieldIdentifier = $"{identifier}.DateCreated", new DateTimeFieldExpression<Address>(_dateCreatedFieldIdentifier, this));
            Fields.Add(_dateUpdatedFieldIdentifier = $"{identifier}.DateUpdated", new DateTimeFieldExpression<Address>(_dateUpdatedFieldIdentifier, this));
        }
        #endregion

        #region methods
        public AddressEntity As(string name)
        {
            return new AddressEntity(this.identifier, this.schema, name);
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
        private static string _idFieldIdentifier;
        private static string _firstNameFieldIdentifier;
        private static string _lastNameFieldIdentifier;
        private static string _birthDateFieldIdentifier;
        private static string _genderTypeFieldIdentifier;
        private static string _creditLimitFieldIdentifier;
        private static string _yearOfLastCreditLimitReviewFieldIdentifier;
        private static string _dateCreatedFieldIdentifier;
        private static string _dateUpdatedFieldIdentifier;
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
        private PersonEntity() : base(null, null, null)
        {
        }

		public PersonEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private PersonEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add(_idFieldIdentifier = $"{identifier}.Id", new Int32FieldExpression<Person>(_idFieldIdentifier, this));
            Fields.Add(_firstNameFieldIdentifier = $"{identifier}.FirstName", new StringFieldExpression<Person>(_firstNameFieldIdentifier, this));
            Fields.Add(_lastNameFieldIdentifier = $"{identifier}.LastName", new StringFieldExpression<Person>(_lastNameFieldIdentifier, this));
            Fields.Add(_birthDateFieldIdentifier = $"{identifier}.BirthDate", new NullableDateTimeFieldExpression<Person>(_birthDateFieldIdentifier, this));
            Fields.Add(_genderTypeFieldIdentifier = $"{identifier}.GenderType", new EnumFieldExpression<Person, GenderType>(_genderTypeFieldIdentifier, this));
            Fields.Add(_creditLimitFieldIdentifier = $"{identifier}.CreditLimit", new NullableInt32FieldExpression<Person>(_creditLimitFieldIdentifier, this));
            Fields.Add(_yearOfLastCreditLimitReviewFieldIdentifier = $"{identifier}.YearOfLastCreditLimitReview", new NullableInt32FieldExpression<Person>(_yearOfLastCreditLimitReviewFieldIdentifier, this));
            Fields.Add(_dateCreatedFieldIdentifier = $"{identifier}.DateCreated", new DateTimeFieldExpression<Person>(_dateCreatedFieldIdentifier, this));
            Fields.Add(_dateUpdatedFieldIdentifier = $"{identifier}.DateUpdated", new DateTimeFieldExpression<Person>(_dateUpdatedFieldIdentifier, this));
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
        {
            return new PersonEntity(this.identifier, this.schema, name);
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
        private static string _idFieldIdentifier;
        private static string _personIdFieldIdentifier;
        private static string _addressIdFieldIdentifier;
        private static string _dateCreatedFieldIdentifier;
        #endregion

        #region interface properties
		public Int32FieldExpression<PersonAddress> Id { get { return Fields[_idFieldIdentifier] as Int32FieldExpression<PersonAddress>; } }
		public Int32FieldExpression<PersonAddress> PersonId { get { return Fields[_personIdFieldIdentifier] as Int32FieldExpression<PersonAddress>; } }
		public Int32FieldExpression<PersonAddress> AddressId { get { return Fields[_addressIdFieldIdentifier] as Int32FieldExpression<PersonAddress>; } }
		public DateTimeFieldExpression<PersonAddress> DateCreated { get { return Fields[_dateCreatedFieldIdentifier] as DateTimeFieldExpression<PersonAddress>; } }
        #endregion

        #region constructors
        private PersonAddressEntity() : base(null, null, null)
        {
        }

		public PersonAddressEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private PersonAddressEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add(_idFieldIdentifier = $"{identifier}.Id", new Int32FieldExpression<PersonAddress>(_idFieldIdentifier, this));
            Fields.Add(_personIdFieldIdentifier = $"{identifier}.PersonId", new Int32FieldExpression<PersonAddress>(_personIdFieldIdentifier, this));
            Fields.Add(_addressIdFieldIdentifier = $"{identifier}.AddressId", new Int32FieldExpression<PersonAddress>(_addressIdFieldIdentifier, this));
            Fields.Add(_dateCreatedFieldIdentifier = $"{identifier}.DateCreated", new DateTimeFieldExpression<PersonAddress>(_dateCreatedFieldIdentifier, this));
        }
        #endregion

        #region methods
        public PersonAddressEntity As(string name)
        {
            return new PersonAddressEntity(this.identifier, this.schema, name);
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
        private static string _idFieldIdentifier;
        private static string _productCategoryTypeFieldIdentifier;
        private static string _nameFieldIdentifier;
        private static string _descriptionFieldIdentifier;
        private static string _listPriceFieldIdentifier;
        private static string _priceFieldIdentifier;
        private static string _quantityFieldIdentifier;
        private static string _dateCreatedFieldIdentifier;
        private static string _dateUpdatedFieldIdentifier;
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
        private ProductEntity() : base(null, null, null)
        {
        }

		public ProductEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private ProductEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add(_idFieldIdentifier = $"{identifier}.Id", new Int32FieldExpression<Product>(_idFieldIdentifier, this));
            Fields.Add(_productCategoryTypeFieldIdentifier = $"{identifier}.ProductCategoryType", new NullableEnumFieldExpression<Product, ProductCategoryType>(_productCategoryTypeFieldIdentifier, this));
            Fields.Add(_nameFieldIdentifier = $"{identifier}.Name", new StringFieldExpression<Product>(_nameFieldIdentifier, this));
            Fields.Add(_descriptionFieldIdentifier = $"{identifier}.Description", new StringFieldExpression<Product>(_descriptionFieldIdentifier, this));
            Fields.Add(_listPriceFieldIdentifier = $"{identifier}.ListPrice", new DecimalFieldExpression<Product>(_listPriceFieldIdentifier, this));
            Fields.Add(_priceFieldIdentifier = $"{identifier}.Price", new DecimalFieldExpression<Product>(_priceFieldIdentifier, this));
            Fields.Add(_quantityFieldIdentifier = $"{identifier}.Quantity", new Int32FieldExpression<Product>(_quantityFieldIdentifier, this));
            Fields.Add(_dateCreatedFieldIdentifier = $"{identifier}.DateCreated", new DateTimeFieldExpression<Product>(_dateCreatedFieldIdentifier, this));
            Fields.Add(_dateUpdatedFieldIdentifier = $"{identifier}.DateUpdated", new DateTimeFieldExpression<Product>(_dateUpdatedFieldIdentifier, this));
        }
        #endregion

        #region methods
        public ProductEntity As(string name)
        {
            return new ProductEntity(this.identifier, this.schema, name);
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
        private static string _idFieldIdentifier;
        private static string _personIdFieldIdentifier;
        private static string _totalPurchaseAmountFieldIdentifier;
        private static string _purchaseDateFieldIdentifier;
        private static string _shipDateFieldIdentifier;
        private static string _expectedDeliveryDateFieldIdentifier;
        private static string _trackingIdentifierFieldIdentifier;
        private static string _paymentMethodTypeFieldIdentifier;
        private static string _dateCreatedFieldIdentifier;
        private static string _dateUpdatedFieldIdentifier;
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
        private PurchaseEntity() : base(null, null, null)
        {
        }

		public PurchaseEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private PurchaseEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add(_idFieldIdentifier = $"{identifier}.Id", new Int32FieldExpression<Purchase>(_idFieldIdentifier, this));
            Fields.Add(_personIdFieldIdentifier = $"{identifier}.PersonId", new Int32FieldExpression<Purchase>(_personIdFieldIdentifier, this));
            Fields.Add(_totalPurchaseAmountFieldIdentifier = $"{identifier}.TotalPurchaseAmount", new DecimalFieldExpression<Purchase>(_totalPurchaseAmountFieldIdentifier, this));
            Fields.Add(_purchaseDateFieldIdentifier = $"{identifier}.PurchaseDate", new DateTimeFieldExpression<Purchase>(_purchaseDateFieldIdentifier, this));
            Fields.Add(_shipDateFieldIdentifier = $"{identifier}.ShipDate", new NullableDateTimeFieldExpression<Purchase>(_shipDateFieldIdentifier, this));
            Fields.Add(_expectedDeliveryDateFieldIdentifier = $"{identifier}.ExpectedDeliveryDate", new NullableDateTimeFieldExpression<Purchase>(_expectedDeliveryDateFieldIdentifier, this));
            Fields.Add(_trackingIdentifierFieldIdentifier = $"{identifier}.TrackingIdentifier", new NullableGuidFieldExpression<Purchase>(_trackingIdentifierFieldIdentifier, this));
            Fields.Add(_paymentMethodTypeFieldIdentifier = $"{identifier}.PaymentMethodType", new EnumFieldExpression<Purchase, PaymentMethodType>(_paymentMethodTypeFieldIdentifier, this));
            Fields.Add(_dateCreatedFieldIdentifier = $"{identifier}.DateCreated", new DateTimeFieldExpression<Purchase>(_dateCreatedFieldIdentifier, this));
            Fields.Add(_dateUpdatedFieldIdentifier = $"{identifier}.DateUpdated", new DateTimeFieldExpression<Purchase>(_dateUpdatedFieldIdentifier, this));
        }
        #endregion

        #region methods
        public PurchaseEntity As(string name)
        {
            return new PurchaseEntity(this.identifier, this.schema, name);
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
        private static string _idFieldIdentifier;
        private static string _purchaseIdFieldIdentifier;
        private static string _productIdFieldIdentifier;
        private static string _purchasePriceFieldIdentifier;
        private static string _quantityFieldIdentifier;
        private static string _dateCreatedFieldIdentifier;
        private static string _dateUpdatedFieldIdentifier;
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
        private PurchaseLineEntity() : base(null, null, null)
        {
        }

		public PurchaseLineEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private PurchaseLineEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add(_idFieldIdentifier = $"{identifier}.Id", new Int32FieldExpression<PurchaseLine>(_idFieldIdentifier, this));
            Fields.Add(_purchaseIdFieldIdentifier = $"{identifier}.PurchaseId", new Int32FieldExpression<PurchaseLine>(_purchaseIdFieldIdentifier, this));
            Fields.Add(_productIdFieldIdentifier = $"{identifier}.ProductId", new Int32FieldExpression<PurchaseLine>(_productIdFieldIdentifier, this));
            Fields.Add(_purchasePriceFieldIdentifier = $"{identifier}.PurchasePrice", new DecimalFieldExpression<PurchaseLine>(_purchasePriceFieldIdentifier, this));
            Fields.Add(_quantityFieldIdentifier = $"{identifier}.Quantity", new Int32FieldExpression<PurchaseLine>(_quantityFieldIdentifier, this));
            Fields.Add(_dateCreatedFieldIdentifier = $"{identifier}.DateCreated", new DateTimeFieldExpression<PurchaseLine>(_dateCreatedFieldIdentifier, this));
            Fields.Add(_dateUpdatedFieldIdentifier = $"{identifier}.DateUpdated", new DateTimeFieldExpression<PurchaseLine>(_dateUpdatedFieldIdentifier, this));
        }
        #endregion

        #region methods
        public PurchaseLineEntity As(string name)
        {
            return new PurchaseLineEntity(this.identifier, this.schema, name);
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
        private static string _idFieldIdentifier;
        private static string _totalPurchasesFieldIdentifier;
        #endregion

        #region interface properties
		public Int32FieldExpression<PersonTotalPurchasesView> Id { get { return Fields[_idFieldIdentifier] as Int32FieldExpression<PersonTotalPurchasesView>; } }
		public NullableDecimalFieldExpression<PersonTotalPurchasesView> TotalPurchases { get { return Fields[_totalPurchasesFieldIdentifier] as NullableDecimalFieldExpression<PersonTotalPurchasesView>; } }
        #endregion

        #region constructors
        private PersonTotalPurchasesViewEntity() : base(null, null, null)
        {
        }

		public PersonTotalPurchasesViewEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private PersonTotalPurchasesViewEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add(_idFieldIdentifier = $"{identifier}.Id", new Int32FieldExpression<PersonTotalPurchasesView>(_idFieldIdentifier, this));
            Fields.Add(_totalPurchasesFieldIdentifier = $"{identifier}.TotalPurchases", new NullableDecimalFieldExpression<PersonTotalPurchasesView>(_totalPurchasesFieldIdentifier, this));
        }
        #endregion

        #region methods
        public PersonTotalPurchasesViewEntity As(string name)
        {
            return new PersonTotalPurchasesViewEntity(this.identifier, this.schema, name);
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
        private static string _idFieldIdentifier;
        private static string _sSNFieldIdentifier;
        private static string _dateCreatedFieldIdentifier;
        private static string _dateUpdatedFieldIdentifier;
        #endregion

        #region interface properties
		public Int32FieldExpression<Person> Id { get { return Fields[_idFieldIdentifier] as Int32FieldExpression<Person>; } }
		public StringFieldExpression<Person> SSN { get { return Fields[_sSNFieldIdentifier] as StringFieldExpression<Person>; } }
		public DateTimeFieldExpression<Person> DateCreated { get { return Fields[_dateCreatedFieldIdentifier] as DateTimeFieldExpression<Person>; } }
		public DateTimeFieldExpression<Person> DateUpdated { get { return Fields[_dateUpdatedFieldIdentifier] as DateTimeFieldExpression<Person>; } }
        #endregion

        #region constructors
        private PersonEntity() : base(null, null, null)
        {
        }

		public PersonEntity(string identifier, SchemaExpression schema) : this(identifier, schema, null)
        {
        }

        private PersonEntity(string identifier, SchemaExpression schema, string alias) : base(identifier, schema, alias)
        {
            Fields.Add(_idFieldIdentifier = $"{identifier}.Id", new Int32FieldExpression<Person>(_idFieldIdentifier, this));
            Fields.Add(_sSNFieldIdentifier = $"{identifier}.SSN", new StringFieldExpression<Person>(_sSNFieldIdentifier, this));
            Fields.Add(_dateCreatedFieldIdentifier = $"{identifier}.DateCreated", new DateTimeFieldExpression<Person>(_dateCreatedFieldIdentifier, this));
            Fields.Add(_dateUpdatedFieldIdentifier = $"{identifier}.DateUpdated", new DateTimeFieldExpression<Person>(_dateUpdatedFieldIdentifier, this));
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
        {
            return new PersonEntity(this.identifier, this.schema, name);
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