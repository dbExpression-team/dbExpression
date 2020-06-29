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
		
        protected override InsertExpressionSet GetInclusiveInsertExpression(Address address)
        {
            return new InsertExpressionSet(
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

        protected override void HydrateEntity(Address address, ISqlFieldReader reader, IValueMapper mapper)
        {
			address.Id = mapper.Map<int>(reader.ReadField().Value);
			address.AddressType = mapper.Map<AddressType?>(reader.ReadField().Value);
			address.Line1 = mapper.Map<string>(reader.ReadField().Value);
			address.Line2 = mapper.Map<string>(reader.ReadField().Value);
			address.City = mapper.Map<string>(reader.ReadField().Value);
			address.State = mapper.Map<string>(reader.ReadField().Value);
			address.Zip = mapper.Map<string>(reader.ReadField().Value);
			address.DateCreated = mapper.Map<DateTime>(reader.ReadField().Value);
			address.DateUpdated = mapper.Map<DateTime>(reader.ReadField().Value);
        }

		protected override void HydrateField(Address address, FieldExpression field, object value, IValueMapper mapper)
        {
			if (field == Id)
			{
				address.Id = mapper.Map<int>(value);
				return;
			}
			if (field == AddressType)
			{
				address.AddressType = mapper.Map<AddressType?>(value);
				return;
			}
			if (field == Line1)
			{
				address.Line1 = mapper.Map<string>(value);
				return;
			}
			if (field == Line2)
			{
				address.Line2 = mapper.Map<string>(value);
				return;
			}
			if (field == City)
			{
				address.City = mapper.Map<string>(value);
				return;
			}
			if (field == State)
			{
				address.State = mapper.Map<string>(value);
				return;
			}
			if (field == Zip)
			{
				address.Zip = mapper.Map<string>(value);
				return;
			}
			if (field == DateCreated)
			{
				address.DateCreated = mapper.Map<DateTime>(value);
				return;
			}
			if (field == DateUpdated)
			{
				address.DateUpdated = mapper.Map<DateTime>(value);
				return;
			}
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
		
        protected override InsertExpressionSet GetInclusiveInsertExpression(Person person)
        {
            return new InsertExpressionSet(
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

        protected override void HydrateEntity(Person person, ISqlFieldReader reader, IValueMapper mapper)
        {
			person.Id = mapper.Map<int>(reader.ReadField().Value);
			person.FirstName = mapper.Map<string>(reader.ReadField().Value);
			person.LastName = mapper.Map<string>(reader.ReadField().Value);
			person.BirthDate = mapper.Map<DateTime?>(reader.ReadField().Value);
			person.GenderType = mapper.Map<GenderType>(reader.ReadField().Value);
			person.CreditLimit = mapper.Map<int?>(reader.ReadField().Value);
			person.YearOfLastCreditLimitReview = mapper.Map<int?>(reader.ReadField().Value);
			person.DateCreated = mapper.Map<DateTime>(reader.ReadField().Value);
			person.DateUpdated = mapper.Map<DateTime>(reader.ReadField().Value);
        }

		protected override void HydrateField(Person person, FieldExpression field, object value, IValueMapper mapper)
        {
			if (field == Id)
			{
				person.Id = mapper.Map<int>(value);
				return;
			}
			if (field == FirstName)
			{
				person.FirstName = mapper.Map<string>(value);
				return;
			}
			if (field == LastName)
			{
				person.LastName = mapper.Map<string>(value);
				return;
			}
			if (field == BirthDate)
			{
				person.BirthDate = mapper.Map<DateTime?>(value);
				return;
			}
			if (field == GenderType)
			{
				person.GenderType = mapper.Map<GenderType>(value);
				return;
			}
			if (field == CreditLimit)
			{
				person.CreditLimit = mapper.Map<int?>(value);
				return;
			}
			if (field == YearOfLastCreditLimitReview)
			{
				person.YearOfLastCreditLimitReview = mapper.Map<int?>(value);
				return;
			}
			if (field == DateCreated)
			{
				person.DateCreated = mapper.Map<DateTime>(value);
				return;
			}
			if (field == DateUpdated)
			{
				person.DateUpdated = mapper.Map<DateTime>(value);
				return;
			}
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
		
        protected override InsertExpressionSet GetInclusiveInsertExpression(PersonAddress personAddress)
        {
            return new InsertExpressionSet(
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

        protected override void HydrateEntity(PersonAddress personAddress, ISqlFieldReader reader, IValueMapper mapper)
        {
			personAddress.Id = mapper.Map<int>(reader.ReadField().Value);
			personAddress.PersonId = mapper.Map<int>(reader.ReadField().Value);
			personAddress.AddressId = mapper.Map<int>(reader.ReadField().Value);
			personAddress.DateCreated = mapper.Map<DateTime>(reader.ReadField().Value);
        }

		protected override void HydrateField(PersonAddress personAddress, FieldExpression field, object value, IValueMapper mapper)
        {
			if (field == Id)
			{
				personAddress.Id = mapper.Map<int>(value);
				return;
			}
			if (field == PersonId)
			{
				personAddress.PersonId = mapper.Map<int>(value);
				return;
			}
			if (field == AddressId)
			{
				personAddress.AddressId = mapper.Map<int>(value);
				return;
			}
			if (field == DateCreated)
			{
				personAddress.DateCreated = mapper.Map<DateTime>(value);
				return;
			}
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
		
        protected override InsertExpressionSet GetInclusiveInsertExpression(Product product)
        {
            return new InsertExpressionSet(
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

        protected override void HydrateEntity(Product product, ISqlFieldReader reader, IValueMapper mapper)
        {
			product.Id = mapper.Map<int>(reader.ReadField().Value);
			product.ProductCategoryType = mapper.Map<ProductCategoryType?>(reader.ReadField().Value);
			product.Name = mapper.Map<string>(reader.ReadField().Value);
			product.Description = mapper.Map<string>(reader.ReadField().Value);
			product.ListPrice = mapper.Map<decimal>(reader.ReadField().Value);
			product.Price = mapper.Map<decimal>(reader.ReadField().Value);
			product.Quantity = mapper.Map<int>(reader.ReadField().Value);
			product.DateCreated = mapper.Map<DateTime>(reader.ReadField().Value);
			product.DateUpdated = mapper.Map<DateTime>(reader.ReadField().Value);
        }

		protected override void HydrateField(Product product, FieldExpression field, object value, IValueMapper mapper)
        {
			if (field == Id)
			{
				product.Id = mapper.Map<int>(value);
				return;
			}
			if (field == ProductCategoryType)
			{
				product.ProductCategoryType = mapper.Map<ProductCategoryType?>(value);
				return;
			}
			if (field == Name)
			{
				product.Name = mapper.Map<string>(value);
				return;
			}
			if (field == Description)
			{
				product.Description = mapper.Map<string>(value);
				return;
			}
			if (field == ListPrice)
			{
				product.ListPrice = mapper.Map<decimal>(value);
				return;
			}
			if (field == Price)
			{
				product.Price = mapper.Map<decimal>(value);
				return;
			}
			if (field == Quantity)
			{
				product.Quantity = mapper.Map<int>(value);
				return;
			}
			if (field == DateCreated)
			{
				product.DateCreated = mapper.Map<DateTime>(value);
				return;
			}
			if (field == DateUpdated)
			{
				product.DateUpdated = mapper.Map<DateTime>(value);
				return;
			}
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
                DateCreated,
                DateUpdated
            );
        }
		
        protected override InsertExpressionSet GetInclusiveInsertExpression(Purchase purchase)
        {
            return new InsertExpressionSet(
                PersonId.Insert(purchase.PersonId),
                TotalPurchaseAmount.Insert(purchase.TotalPurchaseAmount),
                PurchaseDate.Insert(purchase.PurchaseDate),
                ShipDate.Insert(purchase.ShipDate),
                ExpectedDeliveryDate.Insert(purchase.ExpectedDeliveryDate),
                TrackingIdentifier.Insert(purchase.TrackingIdentifier),
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
			if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); };
            expr &= DateUpdated.Set(DateTime.UtcNow);
			
            return expr;
        }

        protected override void HydrateEntity(Purchase purchase, ISqlFieldReader reader, IValueMapper mapper)
        {
			purchase.Id = mapper.Map<int>(reader.ReadField().Value);
			purchase.PersonId = mapper.Map<int>(reader.ReadField().Value);
			purchase.TotalPurchaseAmount = mapper.Map<decimal>(reader.ReadField().Value);
			purchase.PurchaseDate = mapper.Map<DateTime>(reader.ReadField().Value);
			purchase.ShipDate = mapper.Map<DateTime?>(reader.ReadField().Value);
			purchase.ExpectedDeliveryDate = mapper.Map<DateTime?>(reader.ReadField().Value);
			purchase.TrackingIdentifier = mapper.Map<Guid?>(reader.ReadField().Value);
			purchase.DateCreated = mapper.Map<DateTime>(reader.ReadField().Value);
			purchase.DateUpdated = mapper.Map<DateTime>(reader.ReadField().Value);
        }

		protected override void HydrateField(Purchase purchase, FieldExpression field, object value, IValueMapper mapper)
        {
			if (field == Id)
			{
				purchase.Id = mapper.Map<int>(value);
				return;
			}
			if (field == PersonId)
			{
				purchase.PersonId = mapper.Map<int>(value);
				return;
			}
			if (field == TotalPurchaseAmount)
			{
				purchase.TotalPurchaseAmount = mapper.Map<decimal>(value);
				return;
			}
			if (field == PurchaseDate)
			{
				purchase.PurchaseDate = mapper.Map<DateTime>(value);
				return;
			}
			if (field == ShipDate)
			{
				purchase.ShipDate = mapper.Map<DateTime?>(value);
				return;
			}
			if (field == ExpectedDeliveryDate)
			{
				purchase.ExpectedDeliveryDate = mapper.Map<DateTime?>(value);
				return;
			}
			if (field == TrackingIdentifier)
			{
				purchase.TrackingIdentifier = mapper.Map<Guid?>(value);
				return;
			}
			if (field == DateCreated)
			{
				purchase.DateCreated = mapper.Map<DateTime>(value);
				return;
			}
			if (field == DateUpdated)
			{
				purchase.DateUpdated = mapper.Map<DateTime>(value);
				return;
			}
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
		
        protected override InsertExpressionSet GetInclusiveInsertExpression(PurchaseLine purchaseLine)
        {
            return new InsertExpressionSet(
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

        protected override void HydrateEntity(PurchaseLine purchaseLine, ISqlFieldReader reader, IValueMapper mapper)
        {
			purchaseLine.Id = mapper.Map<int>(reader.ReadField().Value);
			purchaseLine.PurchaseId = mapper.Map<int>(reader.ReadField().Value);
			purchaseLine.ProductId = mapper.Map<int>(reader.ReadField().Value);
			purchaseLine.PurchasePrice = mapper.Map<decimal>(reader.ReadField().Value);
			purchaseLine.Quantity = mapper.Map<int>(reader.ReadField().Value);
			purchaseLine.DateCreated = mapper.Map<DateTime>(reader.ReadField().Value);
			purchaseLine.DateUpdated = mapper.Map<DateTime>(reader.ReadField().Value);
        }

		protected override void HydrateField(PurchaseLine purchaseLine, FieldExpression field, object value, IValueMapper mapper)
        {
			if (field == Id)
			{
				purchaseLine.Id = mapper.Map<int>(value);
				return;
			}
			if (field == PurchaseId)
			{
				purchaseLine.PurchaseId = mapper.Map<int>(value);
				return;
			}
			if (field == ProductId)
			{
				purchaseLine.ProductId = mapper.Map<int>(value);
				return;
			}
			if (field == PurchasePrice)
			{
				purchaseLine.PurchasePrice = mapper.Map<decimal>(value);
				return;
			}
			if (field == Quantity)
			{
				purchaseLine.Quantity = mapper.Map<int>(value);
				return;
			}
			if (field == DateCreated)
			{
				purchaseLine.DateCreated = mapper.Map<DateTime>(value);
				return;
			}
			if (field == DateUpdated)
			{
				purchaseLine.DateUpdated = mapper.Map<DateTime>(value);
				return;
			}
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
		
        protected override InsertExpressionSet GetInclusiveInsertExpression(PersonTotalPurchasesView personTotalPurchasesView)
        {
            return new InsertExpressionSet(
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

        protected override void HydrateEntity(PersonTotalPurchasesView personTotalPurchasesView, ISqlFieldReader reader, IValueMapper mapper)
        {
			personTotalPurchasesView.Id = mapper.Map<int>(reader.ReadField().Value);
			personTotalPurchasesView.TotalPurchases = mapper.Map<decimal?>(reader.ReadField().Value);
        }

		protected override void HydrateField(PersonTotalPurchasesView personTotalPurchasesView, FieldExpression field, object value, IValueMapper mapper)
        {
			if (field == Id)
			{
				personTotalPurchasesView.Id = mapper.Map<int>(value);
				return;
			}
			if (field == TotalPurchases)
			{
				personTotalPurchasesView.TotalPurchases = mapper.Map<decimal?>(value);
				return;
			}
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
		
        protected override InsertExpressionSet GetInclusiveInsertExpression(Person person)
        {
            return new InsertExpressionSet(
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

        protected override void HydrateEntity(Person person, ISqlFieldReader reader, IValueMapper mapper)
        {
			person.Id = mapper.Map<int>(reader.ReadField().Value);
			person.SSN = mapper.Map<string>(reader.ReadField().Value);
			person.DateCreated = mapper.Map<DateTime>(reader.ReadField().Value);
			person.DateUpdated = mapper.Map<DateTime>(reader.ReadField().Value);
        }

		protected override void HydrateField(Person person, FieldExpression field, object value, IValueMapper mapper)
        {
			if (field == Id)
			{
				person.Id = mapper.Map<int>(value);
				return;
			}
			if (field == SSN)
			{
				person.SSN = mapper.Map<string>(value);
				return;
			}
			if (field == DateCreated)
			{
				person.DateCreated = mapper.Map<DateTime>(value);
				return;
			}
			if (field == DateUpdated)
			{
				person.DateUpdated = mapper.Map<DateTime>(value);
				return;
			}
        }
		#endregion
    }
    #endregion
}