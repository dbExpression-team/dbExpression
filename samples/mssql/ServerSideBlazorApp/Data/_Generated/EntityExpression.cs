using System;
using ServerSideBlazorApp.Data;

namespace ServerSideBlazorApp.dboDataService
{
    using ServerSideBlazorApp.dboData;
    using HatTrick.DbEx.Sql;
    using HatTrick.DbEx.Sql.Executor;
    using HatTrick.DbEx.Sql.Expression;
    using HatTrick.DbEx.Sql.Mapper;

    #region address
    public partial class AddressEntity : EntityExpression<Address>
    {
        #region internals
        private const string _idFieldName = "Id";
        private const string _addressTypeFieldName = "AddressType";
        private const string _line1FieldName = "Line1";
        private const string _line2FieldName = "Line2";
        private const string _cityFieldName = "City";
        private const string _stateFieldName = "State";
        private const string _zipFieldName = "Zip";
        private const string _dateCreatedFieldName = "DateCreated";
        private const string _dateUpdatedFieldName = "DateUpdated";
        #endregion

        #region interface properties
		public Int32FieldExpression<Address> Id { get { return Fields[_idFieldName] as Int32FieldExpression<Address>; } }
		public NullableEnumFieldExpression<Address, AddressType> AddressType { get { return Fields[_addressTypeFieldName] as NullableEnumFieldExpression<Address, AddressType>; } }
		public StringFieldExpression<Address> Line1 { get { return Fields[_line1FieldName] as StringFieldExpression<Address>; } }
		public StringFieldExpression<Address> Line2 { get { return Fields[_line2FieldName] as StringFieldExpression<Address>; } }
		public StringFieldExpression<Address> City { get { return Fields[_cityFieldName] as StringFieldExpression<Address>; } }
		public StringFieldExpression<Address> State { get { return Fields[_stateFieldName] as StringFieldExpression<Address>; } }
		public StringFieldExpression<Address> Zip { get { return Fields[_zipFieldName] as StringFieldExpression<Address>; } }
		public DateTimeFieldExpression<Address> DateCreated { get { return Fields[_dateCreatedFieldName] as DateTimeFieldExpression<Address>; } }
		public DateTimeFieldExpression<Address> DateUpdated { get { return Fields[_dateUpdatedFieldName] as DateTimeFieldExpression<Address>; } }
        #endregion

        #region constructors
		public AddressEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata): this(schema, metadata, null)
        {
        }

        private AddressEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata, string alias) : base("dbo.Address", schema, metadata, alias)
        {
			Fields.Add(_idFieldName, new Int32FieldExpression<Address>("dbo.Address.Id", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_idFieldName])));
			Fields.Add(_addressTypeFieldName, new NullableEnumFieldExpression<Address, AddressType>("dbo.Address.AddressType", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_addressTypeFieldName])));
			Fields.Add(_line1FieldName, new StringFieldExpression<Address>("dbo.Address.Line1", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_line1FieldName])));
			Fields.Add(_line2FieldName, new StringFieldExpression<Address>("dbo.Address.Line2", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_line2FieldName])));
			Fields.Add(_cityFieldName, new StringFieldExpression<Address>("dbo.Address.City", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_cityFieldName])));
			Fields.Add(_stateFieldName, new StringFieldExpression<Address>("dbo.Address.State", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_stateFieldName])));
			Fields.Add(_zipFieldName, new StringFieldExpression<Address>("dbo.Address.Zip", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_zipFieldName])));
			Fields.Add(_dateCreatedFieldName, new DateTimeFieldExpression<Address>("dbo.Address.DateCreated", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_dateCreatedFieldName])));
			Fields.Add(_dateUpdatedFieldName, new DateTimeFieldExpression<Address>("dbo.Address.DateUpdated", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_dateUpdatedFieldName])));
        }
        #endregion

        #region methods
        public AddressEntity As(string name)
        {
            return new AddressEntity(this.Schema, this.MetadataResolver, name);
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
        private const string _idFieldName = "Id";
        private const string _firstNameFieldName = "FirstName";
        private const string _lastNameFieldName = "LastName";
        private const string _birthDateFieldName = "BirthDate";
        private const string _genderTypeFieldName = "GenderType";
        private const string _creditLimitFieldName = "CreditLimit";
        private const string _yearOfLastCreditLimitReviewFieldName = "YearOfLastCreditLimitReview";
        private const string _dateCreatedFieldName = "DateCreated";
        private const string _dateUpdatedFieldName = "DateUpdated";
        #endregion

        #region interface properties
		public Int32FieldExpression<Person> Id { get { return Fields[_idFieldName] as Int32FieldExpression<Person>; } }
		public StringFieldExpression<Person> FirstName { get { return Fields[_firstNameFieldName] as StringFieldExpression<Person>; } }
		public StringFieldExpression<Person> LastName { get { return Fields[_lastNameFieldName] as StringFieldExpression<Person>; } }
		public NullableDateTimeFieldExpression<Person> BirthDate { get { return Fields[_birthDateFieldName] as NullableDateTimeFieldExpression<Person>; } }
		public EnumFieldExpression<Person, GenderType> GenderType { get { return Fields[_genderTypeFieldName] as EnumFieldExpression<Person, GenderType>; } }
		public NullableInt32FieldExpression<Person> CreditLimit { get { return Fields[_creditLimitFieldName] as NullableInt32FieldExpression<Person>; } }
		public NullableInt32FieldExpression<Person> YearOfLastCreditLimitReview { get { return Fields[_yearOfLastCreditLimitReviewFieldName] as NullableInt32FieldExpression<Person>; } }
		public DateTimeFieldExpression<Person> DateCreated { get { return Fields[_dateCreatedFieldName] as DateTimeFieldExpression<Person>; } }
		public DateTimeFieldExpression<Person> DateUpdated { get { return Fields[_dateUpdatedFieldName] as DateTimeFieldExpression<Person>; } }
        #endregion

        #region constructors
		public PersonEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata): this(schema, metadata, null)
        {
        }

        private PersonEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata, string alias) : base("dbo.Person", schema, metadata, alias)
        {
			Fields.Add(_idFieldName, new Int32FieldExpression<Person>("dbo.Person.Id", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_idFieldName])));
			Fields.Add(_firstNameFieldName, new StringFieldExpression<Person>("dbo.Person.FirstName", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_firstNameFieldName])));
			Fields.Add(_lastNameFieldName, new StringFieldExpression<Person>("dbo.Person.LastName", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_lastNameFieldName])));
			Fields.Add(_birthDateFieldName, new NullableDateTimeFieldExpression<Person>("dbo.Person.BirthDate", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_birthDateFieldName])));
			Fields.Add(_genderTypeFieldName, new EnumFieldExpression<Person, GenderType>("dbo.Person.GenderType", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_genderTypeFieldName])));
			Fields.Add(_creditLimitFieldName, new NullableInt32FieldExpression<Person>("dbo.Person.CreditLimit", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_creditLimitFieldName])));
			Fields.Add(_yearOfLastCreditLimitReviewFieldName, new NullableInt32FieldExpression<Person>("dbo.Person.YearOfLastCreditLimitReview", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_yearOfLastCreditLimitReviewFieldName])));
			Fields.Add(_dateCreatedFieldName, new DateTimeFieldExpression<Person>("dbo.Person.DateCreated", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_dateCreatedFieldName])));
			Fields.Add(_dateUpdatedFieldName, new DateTimeFieldExpression<Person>("dbo.Person.DateUpdated", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_dateUpdatedFieldName])));
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
        {
            return new PersonEntity(this.Schema, this.MetadataResolver, name);
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
        private const string _idFieldName = "Id";
        private const string _personIdFieldName = "PersonId";
        private const string _addressIdFieldName = "AddressId";
        private const string _dateCreatedFieldName = "DateCreated";
        #endregion

        #region interface properties
		public Int32FieldExpression<PersonAddress> Id { get { return Fields[_idFieldName] as Int32FieldExpression<PersonAddress>; } }
		public Int32FieldExpression<PersonAddress> PersonId { get { return Fields[_personIdFieldName] as Int32FieldExpression<PersonAddress>; } }
		public Int32FieldExpression<PersonAddress> AddressId { get { return Fields[_addressIdFieldName] as Int32FieldExpression<PersonAddress>; } }
		public DateTimeFieldExpression<PersonAddress> DateCreated { get { return Fields[_dateCreatedFieldName] as DateTimeFieldExpression<PersonAddress>; } }
        #endregion

        #region constructors
		public PersonAddressEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata): this(schema, metadata, null)
        {
        }

        private PersonAddressEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata, string alias) : base("dbo.PersonAddress", schema, metadata, alias)
        {
			Fields.Add(_idFieldName, new Int32FieldExpression<PersonAddress>("dbo.PersonAddress.Id", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_idFieldName])));
			Fields.Add(_personIdFieldName, new Int32FieldExpression<PersonAddress>("dbo.PersonAddress.PersonId", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_personIdFieldName])));
			Fields.Add(_addressIdFieldName, new Int32FieldExpression<PersonAddress>("dbo.PersonAddress.AddressId", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_addressIdFieldName])));
			Fields.Add(_dateCreatedFieldName, new DateTimeFieldExpression<PersonAddress>("dbo.PersonAddress.DateCreated", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_dateCreatedFieldName])));
        }
        #endregion

        #region methods
        public PersonAddressEntity As(string name)
        {
            return new PersonAddressEntity(this.Schema, this.MetadataResolver, name);
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
        private const string _idFieldName = "Id";
        private const string _productCategoryTypeFieldName = "ProductCategoryType";
        private const string _nameFieldName = "Name";
        private const string _descriptionFieldName = "Description";
        private const string _listPriceFieldName = "ListPrice";
        private const string _priceFieldName = "Price";
        private const string _quantityFieldName = "Quantity";
        private const string _dateCreatedFieldName = "DateCreated";
        private const string _dateUpdatedFieldName = "DateUpdated";
        #endregion

        #region interface properties
		public Int32FieldExpression<Product> Id { get { return Fields[_idFieldName] as Int32FieldExpression<Product>; } }
		public NullableEnumFieldExpression<Product, ProductCategoryType> ProductCategoryType { get { return Fields[_productCategoryTypeFieldName] as NullableEnumFieldExpression<Product, ProductCategoryType>; } }
		public StringFieldExpression<Product> Name { get { return Fields[_nameFieldName] as StringFieldExpression<Product>; } }
		public StringFieldExpression<Product> Description { get { return Fields[_descriptionFieldName] as StringFieldExpression<Product>; } }
		public DecimalFieldExpression<Product> ListPrice { get { return Fields[_listPriceFieldName] as DecimalFieldExpression<Product>; } }
		public DecimalFieldExpression<Product> Price { get { return Fields[_priceFieldName] as DecimalFieldExpression<Product>; } }
		public Int32FieldExpression<Product> Quantity { get { return Fields[_quantityFieldName] as Int32FieldExpression<Product>; } }
		public DateTimeFieldExpression<Product> DateCreated { get { return Fields[_dateCreatedFieldName] as DateTimeFieldExpression<Product>; } }
		public DateTimeFieldExpression<Product> DateUpdated { get { return Fields[_dateUpdatedFieldName] as DateTimeFieldExpression<Product>; } }
        #endregion

        #region constructors
		public ProductEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata): this(schema, metadata, null)
        {
        }

        private ProductEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata, string alias) : base("dbo.Product", schema, metadata, alias)
        {
			Fields.Add(_idFieldName, new Int32FieldExpression<Product>("dbo.Product.Id", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_idFieldName])));
			Fields.Add(_productCategoryTypeFieldName, new NullableEnumFieldExpression<Product, ProductCategoryType>("dbo.Product.ProductCategoryType", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_productCategoryTypeFieldName])));
			Fields.Add(_nameFieldName, new StringFieldExpression<Product>("dbo.Product.Name", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_nameFieldName])));
			Fields.Add(_descriptionFieldName, new StringFieldExpression<Product>("dbo.Product.Description", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_descriptionFieldName])));
			Fields.Add(_listPriceFieldName, new DecimalFieldExpression<Product>("dbo.Product.ListPrice", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_listPriceFieldName])));
			Fields.Add(_priceFieldName, new DecimalFieldExpression<Product>("dbo.Product.Price", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_priceFieldName])));
			Fields.Add(_quantityFieldName, new Int32FieldExpression<Product>("dbo.Product.Quantity", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_quantityFieldName])));
			Fields.Add(_dateCreatedFieldName, new DateTimeFieldExpression<Product>("dbo.Product.DateCreated", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_dateCreatedFieldName])));
			Fields.Add(_dateUpdatedFieldName, new DateTimeFieldExpression<Product>("dbo.Product.DateUpdated", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_dateUpdatedFieldName])));
        }
        #endregion

        #region methods
        public ProductEntity As(string name)
        {
            return new ProductEntity(this.Schema, this.MetadataResolver, name);
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
        private const string _idFieldName = "Id";
        private const string _personIdFieldName = "PersonId";
        private const string _totalPurchaseAmountFieldName = "TotalPurchaseAmount";
        private const string _purchaseDateFieldName = "PurchaseDate";
        private const string _shipDateFieldName = "ShipDate";
        private const string _expectedDeliveryDateFieldName = "ExpectedDeliveryDate";
        private const string _trackingIdentifierFieldName = "TrackingIdentifier";
        private const string _paymentMethodFieldName = "PaymentMethod";
        private const string _dateCreatedFieldName = "DateCreated";
        private const string _dateUpdatedFieldName = "DateUpdated";
        #endregion

        #region interface properties
		public Int32FieldExpression<Purchase> Id { get { return Fields[_idFieldName] as Int32FieldExpression<Purchase>; } }
		public Int32FieldExpression<Purchase> PersonId { get { return Fields[_personIdFieldName] as Int32FieldExpression<Purchase>; } }
		public DecimalFieldExpression<Purchase> TotalPurchaseAmount { get { return Fields[_totalPurchaseAmountFieldName] as DecimalFieldExpression<Purchase>; } }
		public DateTimeFieldExpression<Purchase> PurchaseDate { get { return Fields[_purchaseDateFieldName] as DateTimeFieldExpression<Purchase>; } }
		public NullableDateTimeFieldExpression<Purchase> ShipDate { get { return Fields[_shipDateFieldName] as NullableDateTimeFieldExpression<Purchase>; } }
		public NullableDateTimeFieldExpression<Purchase> ExpectedDeliveryDate { get { return Fields[_expectedDeliveryDateFieldName] as NullableDateTimeFieldExpression<Purchase>; } }
		public NullableGuidFieldExpression<Purchase> TrackingIdentifier { get { return Fields[_trackingIdentifierFieldName] as NullableGuidFieldExpression<Purchase>; } }
		public EnumFieldExpression<Purchase, PaymentMethodType> PaymentMethod { get { return Fields[_paymentMethodFieldName] as EnumFieldExpression<Purchase, PaymentMethodType>; } }
		public DateTimeFieldExpression<Purchase> DateCreated { get { return Fields[_dateCreatedFieldName] as DateTimeFieldExpression<Purchase>; } }
		public DateTimeFieldExpression<Purchase> DateUpdated { get { return Fields[_dateUpdatedFieldName] as DateTimeFieldExpression<Purchase>; } }
        #endregion

        #region constructors
		public PurchaseEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata): this(schema, metadata, null)
        {
        }

        private PurchaseEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata, string alias) : base("dbo.Purchase", schema, metadata, alias)
        {
			Fields.Add(_idFieldName, new Int32FieldExpression<Purchase>("dbo.Purchase.Id", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_idFieldName])));
			Fields.Add(_personIdFieldName, new Int32FieldExpression<Purchase>("dbo.Purchase.PersonId", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_personIdFieldName])));
			Fields.Add(_totalPurchaseAmountFieldName, new DecimalFieldExpression<Purchase>("dbo.Purchase.TotalPurchaseAmount", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_totalPurchaseAmountFieldName])));
			Fields.Add(_purchaseDateFieldName, new DateTimeFieldExpression<Purchase>("dbo.Purchase.PurchaseDate", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_purchaseDateFieldName])));
			Fields.Add(_shipDateFieldName, new NullableDateTimeFieldExpression<Purchase>("dbo.Purchase.ShipDate", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_shipDateFieldName])));
			Fields.Add(_expectedDeliveryDateFieldName, new NullableDateTimeFieldExpression<Purchase>("dbo.Purchase.ExpectedDeliveryDate", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_expectedDeliveryDateFieldName])));
			Fields.Add(_trackingIdentifierFieldName, new NullableGuidFieldExpression<Purchase>("dbo.Purchase.TrackingIdentifier", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_trackingIdentifierFieldName])));
			Fields.Add(_paymentMethodFieldName, new EnumFieldExpression<Purchase, PaymentMethodType>("dbo.Purchase.PaymentMethod", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_paymentMethodFieldName])));
			Fields.Add(_dateCreatedFieldName, new DateTimeFieldExpression<Purchase>("dbo.Purchase.DateCreated", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_dateCreatedFieldName])));
			Fields.Add(_dateUpdatedFieldName, new DateTimeFieldExpression<Purchase>("dbo.Purchase.DateUpdated", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_dateUpdatedFieldName])));
        }
        #endregion

        #region methods
        public PurchaseEntity As(string name)
        {
            return new PurchaseEntity(this.Schema, this.MetadataResolver, name);
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
                PaymentMethod,
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
                PaymentMethod.Insert(purchase.PaymentMethod),
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
			if (from.PaymentMethod != to.PaymentMethod) { expr &= PaymentMethod.Set(to.PaymentMethod); };
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
			purchase.PaymentMethod = reader.ReadField().GetValue<PaymentMethodType>();
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
        private const string _idFieldName = "Id";
        private const string _purchaseIdFieldName = "PurchaseId";
        private const string _productIdFieldName = "ProductId";
        private const string _purchasePriceFieldName = "PurchasePrice";
        private const string _quantityFieldName = "Quantity";
        private const string _dateCreatedFieldName = "DateCreated";
        private const string _dateUpdatedFieldName = "DateUpdated";
        #endregion

        #region interface properties
		public Int32FieldExpression<PurchaseLine> Id { get { return Fields[_idFieldName] as Int32FieldExpression<PurchaseLine>; } }
		public Int32FieldExpression<PurchaseLine> PurchaseId { get { return Fields[_purchaseIdFieldName] as Int32FieldExpression<PurchaseLine>; } }
		public Int32FieldExpression<PurchaseLine> ProductId { get { return Fields[_productIdFieldName] as Int32FieldExpression<PurchaseLine>; } }
		public DecimalFieldExpression<PurchaseLine> PurchasePrice { get { return Fields[_purchasePriceFieldName] as DecimalFieldExpression<PurchaseLine>; } }
		public Int32FieldExpression<PurchaseLine> Quantity { get { return Fields[_quantityFieldName] as Int32FieldExpression<PurchaseLine>; } }
		public DateTimeFieldExpression<PurchaseLine> DateCreated { get { return Fields[_dateCreatedFieldName] as DateTimeFieldExpression<PurchaseLine>; } }
		public DateTimeFieldExpression<PurchaseLine> DateUpdated { get { return Fields[_dateUpdatedFieldName] as DateTimeFieldExpression<PurchaseLine>; } }
        #endregion

        #region constructors
		public PurchaseLineEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata): this(schema, metadata, null)
        {
        }

        private PurchaseLineEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata, string alias) : base("dbo.PurchaseLine", schema, metadata, alias)
        {
			Fields.Add(_idFieldName, new Int32FieldExpression<PurchaseLine>("dbo.PurchaseLine.Id", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_idFieldName])));
			Fields.Add(_purchaseIdFieldName, new Int32FieldExpression<PurchaseLine>("dbo.PurchaseLine.PurchaseId", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_purchaseIdFieldName])));
			Fields.Add(_productIdFieldName, new Int32FieldExpression<PurchaseLine>("dbo.PurchaseLine.ProductId", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_productIdFieldName])));
			Fields.Add(_purchasePriceFieldName, new DecimalFieldExpression<PurchaseLine>("dbo.PurchaseLine.PurchasePrice", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_purchasePriceFieldName])));
			Fields.Add(_quantityFieldName, new Int32FieldExpression<PurchaseLine>("dbo.PurchaseLine.Quantity", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_quantityFieldName])));
			Fields.Add(_dateCreatedFieldName, new DateTimeFieldExpression<PurchaseLine>("dbo.PurchaseLine.DateCreated", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_dateCreatedFieldName])));
			Fields.Add(_dateUpdatedFieldName, new DateTimeFieldExpression<PurchaseLine>("dbo.PurchaseLine.DateUpdated", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_dateUpdatedFieldName])));
        }
        #endregion

        #region methods
        public PurchaseLineEntity As(string name)
        {
            return new PurchaseLineEntity(this.Schema, this.MetadataResolver, name);
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
        private const string _idFieldName = "Id";
        private const string _totalPurchasesFieldName = "TotalPurchases";
        #endregion

        #region interface properties
		public Int32FieldExpression<PersonTotalPurchasesView> Id { get { return Fields[_idFieldName] as Int32FieldExpression<PersonTotalPurchasesView>; } }
		public NullableDecimalFieldExpression<PersonTotalPurchasesView> TotalPurchases { get { return Fields[_totalPurchasesFieldName] as NullableDecimalFieldExpression<PersonTotalPurchasesView>; } }
        #endregion

        #region constructors
		public PersonTotalPurchasesViewEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata): this(schema, metadata, null)
        {
        }

        private PersonTotalPurchasesViewEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata, string alias) : base("dbo.PersonTotalPurchasesView", schema, metadata, alias)
        {
			Fields.Add(_idFieldName, new Int32FieldExpression<PersonTotalPurchasesView>("dbo.PersonTotalPurchasesView.Id", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_idFieldName])));
			Fields.Add(_totalPurchasesFieldName, new NullableDecimalFieldExpression<PersonTotalPurchasesView>("dbo.PersonTotalPurchasesView.TotalPurchases", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_totalPurchasesFieldName])));
        }
        #endregion

        #region methods
        public PersonTotalPurchasesViewEntity As(string name)
        {
            return new PersonTotalPurchasesViewEntity(this.Schema, this.MetadataResolver, name);
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
namespace ServerSideBlazorApp.secDataService
{
    using ServerSideBlazorApp.secData;
    using HatTrick.DbEx.Sql;
    using HatTrick.DbEx.Sql.Executor;
    using HatTrick.DbEx.Sql.Expression;
    using HatTrick.DbEx.Sql.Mapper;

    #region person
    public partial class PersonEntity : EntityExpression<Person>
    {
        #region internals
        private const string _idFieldName = "Id";
        private const string _sSNFieldName = "SSN";
        private const string _dateCreatedFieldName = "DateCreated";
        private const string _dateUpdatedFieldName = "DateUpdated";
        #endregion

        #region interface properties
		public Int32FieldExpression<Person> Id { get { return Fields[_idFieldName] as Int32FieldExpression<Person>; } }
		public StringFieldExpression<Person> SSN { get { return Fields[_sSNFieldName] as StringFieldExpression<Person>; } }
		public DateTimeFieldExpression<Person> DateCreated { get { return Fields[_dateCreatedFieldName] as DateTimeFieldExpression<Person>; } }
		public DateTimeFieldExpression<Person> DateUpdated { get { return Fields[_dateUpdatedFieldName] as DateTimeFieldExpression<Person>; } }
        #endregion

        #region constructors
		public PersonEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata): this(schema, metadata, null)
        {
        }

        private PersonEntity(SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata, string alias) : base("sec.Person", schema, metadata, alias)
        {
			Fields.Add(_idFieldName, new Int32FieldExpression<Person>("sec.Person.Id", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_idFieldName])));
			Fields.Add(_sSNFieldName, new StringFieldExpression<Person>("sec.Person.SSN", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_sSNFieldName])));
			Fields.Add(_dateCreatedFieldName, new DateTimeFieldExpression<Person>("sec.Person.DateCreated", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_dateCreatedFieldName])));
			Fields.Add(_dateUpdatedFieldName, new DateTimeFieldExpression<Person>("sec.Person.DateUpdated", this, new Lazy<ISqlFieldMetadata>(() => metadata.Value.Fields[_dateUpdatedFieldName])));
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
        {
            return new PersonEntity(this.Schema, this.MetadataResolver, name);
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