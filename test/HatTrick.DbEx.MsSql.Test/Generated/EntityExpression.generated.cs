using System;
using System.Collections.Generic;

namespace DataService.EntityExpression.dbo
{
    using Data;
    using Data.dbo;
    using HatTrick.DbEx.MsSql.Expression;
    using HatTrick.DbEx.Sql;
    using HatTrick.DbEx.Sql.Configuration;
    using HatTrick.DbEx.Sql.Executor;
    using HatTrick.DbEx.Sql.Expression;
    using HatTrick.DbEx.Sql.Mapper;
    using HatTrick.DbEx.Utility;
    using System.Data;

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
        public Int32FieldExpression<Address> Id { get { return Fields[_idFieldName].Value as Int32FieldExpression<Address>; } }
        public EnumFieldExpression<Address, AddressType> AddressType { get { return Fields[_addressTypeFieldName].Value as EnumFieldExpression<Address, AddressType>; } }
        public StringFieldExpression<Address> Line1 { get { return Fields[_line1FieldName].Value as StringFieldExpression<Address>; } }
        public StringFieldExpression<Address> Line2 { get { return Fields[_line2FieldName].Value as StringFieldExpression<Address>; } }
        public StringFieldExpression<Address> City { get { return Fields[_cityFieldName].Value as StringFieldExpression<Address>; } }
        public StringFieldExpression<Address> State { get { return Fields[_stateFieldName].Value as StringFieldExpression<Address>; } }
        public StringFieldExpression<Address> Zip { get { return Fields[_zipFieldName].Value as StringFieldExpression<Address>; } }
        public DateTimeFieldExpression<Address> DateCreated { get { return Fields[_dateCreatedFieldName].Value as DateTimeFieldExpression<Address>; } }
        public DateTimeFieldExpression<Address> DateUpdated { get { return Fields[_dateUpdatedFieldName].Value as DateTimeFieldExpression<Address>; } }
        #endregion

        #region constructors
        public AddressEntity(SchemaExpression schema, ISqlEntityMetadata metadata): this(schema, metadata, null)
        {
        }

        private AddressEntity(SchemaExpression schema, ISqlEntityMetadata metadata, string alias)
            : base(schema, metadata, alias)
        {
            Fields.Add(_idFieldName, new Lazy<FieldExpression>(() => new Int32FieldExpression<Address>(this, metadata.Fields[_idFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_idFieldName}'"), x => x.Id)));
            Fields.Add(_addressTypeFieldName, new Lazy<FieldExpression>(() => new EnumFieldExpression<Address, AddressType>(this, metadata.Fields[_addressTypeFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_addressTypeFieldName}'"), x => x.AddressType)));
            Fields.Add(_line1FieldName, new Lazy<FieldExpression>(() => new StringFieldExpression<Address>(this, metadata.Fields[_line1FieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_line1FieldName}'"), x => x.Line1)));
            Fields.Add(_line2FieldName, new Lazy<FieldExpression>(() => new StringFieldExpression<Address>(this, metadata.Fields[_line2FieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_line2FieldName}'"), x => x.Line2)));
            Fields.Add(_cityFieldName, new Lazy<FieldExpression>(() => new StringFieldExpression<Address>(this, metadata.Fields[_cityFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_cityFieldName}'"), x => x.City)));
            Fields.Add(_stateFieldName, new Lazy<FieldExpression>(() => new StringFieldExpression<Address>(this, metadata.Fields[_stateFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_stateFieldName}'"), x => x.State)));
            Fields.Add(_zipFieldName, new Lazy<FieldExpression>(() => new StringFieldExpression<Address>(this, metadata.Fields[_zipFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_zipFieldName}'"), x => x.Zip)));
            Fields.Add(_dateCreatedFieldName, new Lazy<FieldExpression>(() => new DateTimeFieldExpression<Address>(this, metadata.Fields[_dateCreatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_dateCreatedFieldName}'"), x => x.DateCreated)));
            Fields.Add(_dateUpdatedFieldName, new Lazy<FieldExpression>(() => new DateTimeFieldExpression<Address>(this, metadata.Fields[_dateUpdatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_dateUpdatedFieldName}'"), x => x.DateUpdated)));
        }

        #endregion

        #region methods
        public AddressEntity As(string name)
        {
            return new AddressEntity(this.Schema, this.Metadata, name);
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
            if (from.AddressType != to.AddressType) { expr &= AddressType.Set(to.AddressType); }
            if (from.Line1 != to.Line1) { expr &= Line1.Set(to.Line1); }
            if (from.Line2 != to.Line2) { expr &= Line2.Set(to.Line2); }
            if (from.City != to.City) { expr &= City.Set(to.City); }
            if (from.State != to.State) { expr &= State.Set(to.State); }
            if (from.Zip != to.Zip) { expr &= Zip.Set(to.Zip); }
            expr &= DateUpdated.Set(DateTime.UtcNow);
            return expr;
        }

        protected override void HydrateEntity(Address address, ISqlFieldReader reader, IValueMapper mapper)
        {
            address.Id = mapper.Map<int>(Id, reader.ReadField());
            address.AddressType = (AddressType)mapper.Map<int>(AddressType, reader.ReadField());
            address.Line1 = mapper.Map<string>(Line1, reader.ReadField());
            address.Line2 = mapper.Map<string>(Line2, reader.ReadField());
            address.City = mapper.Map<string>(City, reader.ReadField());
            address.State = mapper.Map<string>(State, reader.ReadField());
            address.Zip = mapper.Map<string>(Zip, reader.ReadField());
            address.DateCreated = mapper.Map<DateTime>(DateCreated, reader.ReadField());
            address.DateUpdated = mapper.Map<DateTime>(DateUpdated, reader.ReadField());
        }

        protected bool IsPersistSafe(Address address, out List<string> validationMessages)
        {
            validationMessages = new List<string>();
            if (address.Line1 == null) { validationMessages.Add("Line1 cannot be empty."); }
            if (address.Line1 != null && address.Line1.Length > 50) { validationMessages.Add("Line1 cannot be longer than 50 characters."); }
            if (address.Line2 != null && address.Line2.Length > 50) { validationMessages.Add("Line2 cannot be longer than 50 characters."); }
            if (address.City == null) { validationMessages.Add("City cannot be empty."); }
            if (address.City != null && address.City.Length > 60) { validationMessages.Add("City cannot be longer than 60 characters."); }
            if (address.State == null) { validationMessages.Add("State cannot be empty."); }
            if (address.State != null && address.State.Length > 2) { validationMessages.Add("State cannot be longer than 2 characters."); }
            if (address.Zip == null) { validationMessages.Add("Zip cannot be empty."); }
            if (address.Zip != null && address.Zip.Length > 10) { validationMessages.Add("Zip cannot be longer than 10 characters."); }
            if (address.DateCreated == default(DateTime)) { validationMessages.Add("Date Created must contain a value."); }
            if (address.DateUpdated == default(DateTime)) { validationMessages.Add("Date Updated must contain a value."); }
            return validationMessages.Count == 0;
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
        private const string _dateCreatedFieldName = "DateCreated";
        private const string _dateUpdatedFieldName = "DateUpdated";
        #endregion

        #region interface properties
        public Int32FieldExpression<Person> Id { get { return Fields[_idFieldName].Value as Int32FieldExpression<Person>; } }
        public StringFieldExpression<Person> FirstName { get { return Fields[_firstNameFieldName].Value as StringFieldExpression<Person>; } }
        public StringFieldExpression<Person> LastName { get { return Fields[_lastNameFieldName].Value as StringFieldExpression<Person>; } }
        public NullableDateTimeFieldExpression<Person> BirthDate { get { return Fields[_birthDateFieldName].Value as NullableDateTimeFieldExpression<Person>; } }
        public EnumFieldExpression<Person, GenderType> GenderType { get { return Fields[_genderTypeFieldName].Value as EnumFieldExpression<Person, GenderType>; } }
        public DateTimeFieldExpression<Person> DateCreated { get { return Fields[_dateCreatedFieldName].Value as DateTimeFieldExpression<Person>; } }
        public DateTimeFieldExpression<Person> DateUpdated { get { return Fields[_dateUpdatedFieldName].Value as DateTimeFieldExpression<Person>; } }
        #endregion

        #region constructors
        public PersonEntity(SchemaExpression schema, ISqlEntityMetadata metadata) : this(schema, metadata, null)
        {
        }

        private PersonEntity(SchemaExpression schema, ISqlEntityMetadata metadata, string alias) : base(schema, metadata, alias)
        {
            Fields.Add(_idFieldName, new Lazy<FieldExpression>(() => new Int32FieldExpression<Person>(this, metadata.Fields[_idFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_idFieldName}'"), x => x.Id)));
            Fields.Add(_firstNameFieldName, new Lazy<FieldExpression>(() => new StringFieldExpression<Person>(this, metadata.Fields[_firstNameFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_firstNameFieldName}'"), x => x.FirstName)));
            Fields.Add(_lastNameFieldName, new Lazy<FieldExpression>(() => new StringFieldExpression<Person>(this, metadata.Fields[_lastNameFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_lastNameFieldName}'"), x => x.LastName)));
            Fields.Add(_birthDateFieldName, new Lazy<FieldExpression>(() => new NullableDateTimeFieldExpression<Person>(this, metadata.Fields[_birthDateFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_birthDateFieldName}'"), x => x.BirthDate)));
            Fields.Add(_genderTypeFieldName, new Lazy<FieldExpression>(() => new EnumFieldExpression<Person, GenderType>(this, metadata.Fields[_genderTypeFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_genderTypeFieldName}'"), x => x.GenderType)));
            Fields.Add(_dateCreatedFieldName, new Lazy<FieldExpression>(() => new DateTimeFieldExpression<Person>(this, metadata.Fields[_dateCreatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_dateCreatedFieldName}'"), x => x.DateCreated)));
            Fields.Add(_dateUpdatedFieldName, new Lazy<FieldExpression>(() => new DateTimeFieldExpression<Person>(this, metadata.Fields[_dateUpdatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_dateUpdatedFieldName}'"), x => x.DateUpdated)));
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
        {
            return new PersonEntity(this.Schema, this.Metadata, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                FirstName,
                LastName,
                BirthDate,
                GenderType,
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
                DateCreated.Insert(person.DateCreated),
                DateUpdated.Insert(person.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person from, Person to)
        {
            AssignmentExpressionSet expr = null;
            if (from.FirstName != to.FirstName) { expr &= FirstName.Set(to.FirstName); }
            if (from.LastName != to.LastName) { expr &= LastName.Set(to.LastName); }
            if (from.BirthDate != to.BirthDate) { expr &= BirthDate.Set(to.BirthDate); }
            if (from.GenderType != to.GenderType) { expr &= GenderType.Set(to.GenderType); }
            expr &= DateUpdated.Set(DateTime.UtcNow);
            return expr;
        }

        protected override void HydrateEntity(Person person, ISqlFieldReader reader, IValueMapper mapper)
        {
            person.Id = mapper.Map<int>(Id, reader.ReadField());
            person.FirstName = mapper.Map<string>(FirstName, reader.ReadField());
            person.LastName = mapper.Map<string>(LastName, reader.ReadField());
            person.BirthDate = mapper.Map<DateTime>(BirthDate, reader.ReadField());
            person.GenderType = (GenderType)mapper.Map<int>(GenderType, reader.ReadField());
            person.DateCreated = mapper.Map<DateTime>(DateCreated, reader.ReadField());
            person.DateUpdated = mapper.Map<DateTime>(DateUpdated, reader.ReadField());
        }

        protected bool IsPersistSafe(Person person, out List<string> validationMessages)
        {
            validationMessages = new List<string>();
            if (person.FirstName == null) { validationMessages.Add("First Name cannot be empty."); }
            if (person.FirstName != null && person.FirstName.Length > 20) { validationMessages.Add("First Name cannot be longer than 20 characters."); }
            if (person.LastName == null) { validationMessages.Add("Last Name cannot be empty."); }
            if (person.LastName != null && person.LastName.Length > 20) { validationMessages.Add("Last Name cannot be longer than 20 characters."); }
            if (person.BirthDate == default(DateTime)) { validationMessages.Add("Birth Date must contain a value."); }
            if (person.DateCreated == default(DateTime)) { validationMessages.Add("Date Created must contain a value."); }
            if (person.DateUpdated == default(DateTime)) { validationMessages.Add("Date Updated must contain a value."); }
            return validationMessages.Count == 0;
        }
        #endregion
    }
    #endregion
    #region person_ address
    public partial class Person_AddressEntity : EntityExpression<Person_Address>
    {
        #region internals
        private const string _idFieldName = "Id";
        private const string _personIdFieldName = "PersonId";
        private const string _addressIdFieldName = "AddressId";
        private const string _dateCreatedFieldName = "DateCreated";
        #endregion

        #region interface properties
        public Int32FieldExpression<Person_Address> Id { get { return Fields[_idFieldName].Value as Int32FieldExpression<Person_Address>; } }
        public Int32FieldExpression<Person_Address> PersonId { get { return Fields[_personIdFieldName].Value as Int32FieldExpression<Person_Address>; } }
        public Int32FieldExpression<Person_Address> AddressId { get { return Fields[_addressIdFieldName].Value as Int32FieldExpression<Person_Address>; } }
        public DateTimeFieldExpression<Person_Address> DateCreated { get { return Fields[_dateCreatedFieldName].Value as DateTimeFieldExpression<Person_Address>; } }
        #endregion

        #region constructors
        public Person_AddressEntity(SchemaExpression schema, ISqlEntityMetadata metadata) : this(schema, metadata, null)
        {
        }

        private Person_AddressEntity(SchemaExpression schema, ISqlEntityMetadata metadata, string alias) : base(schema, metadata, alias)
        {
            Fields.Add(_idFieldName, new Lazy<FieldExpression>(() => new Int32FieldExpression<Person_Address>(this, metadata.Fields[_idFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_idFieldName}'"), x => x.Id)));
            Fields.Add(_personIdFieldName, new Lazy<FieldExpression>(() => new Int32FieldExpression<Person_Address>(this, metadata.Fields[_personIdFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_personIdFieldName}'"), x => x.PersonId)));
            Fields.Add(_addressIdFieldName, new Lazy<FieldExpression>(() => new Int32FieldExpression<Person_Address>(this, metadata.Fields[_addressIdFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_addressIdFieldName}'"), x => x.AddressId)));
            Fields.Add(_dateCreatedFieldName, new Lazy<FieldExpression>(() => new DateTimeFieldExpression<Person_Address>(this, metadata.Fields[_dateCreatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_dateCreatedFieldName}'"), x => x.DateCreated)));
        }
        #endregion

        #region methods
        public Person_AddressEntity As(string name)
        {
            return new Person_AddressEntity(this.Schema, this.Metadata, name);
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

        protected override InsertExpressionSet GetInclusiveInsertExpression(Person_Address person_Address)
        {
            return new InsertExpressionSet(
                PersonId.Insert(person_Address.PersonId),
                AddressId.Insert(person_Address.AddressId),
                DateCreated.Insert(person_Address.DateCreated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person_Address from, Person_Address to)
        {
            AssignmentExpressionSet expr = null;
            if (from.PersonId != to.PersonId) { expr &= PersonId.Set(to.PersonId); }
            if (from.AddressId != to.AddressId) { expr &= AddressId.Set(to.AddressId); }
            return expr;
        }

        protected override void HydrateEntity(Person_Address person_Address, ISqlFieldReader reader, IValueMapper mapper)
        {
            person_Address.Id = mapper.Map<int>(Id, reader.ReadField());
            person_Address.PersonId = mapper.Map<int>(PersonId, reader.ReadField());
            person_Address.AddressId = mapper.Map<int>(AddressId, reader.ReadField());
            person_Address.DateCreated = mapper.Map<DateTime>(DateCreated, reader.ReadField());
        }

        protected bool IsPersistSafe(Person_Address person_Address, out List<string> validationMessages)
        {
            validationMessages = new List<string>();
            if (person_Address.DateCreated == default(DateTime)) { validationMessages.Add("Date Created must contain a value."); }
            return validationMessages.Count == 0;
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
        private const string _priceFieldName = "Price";
        private const string _listPriceFieldName = "ListPrice";
        private const string _quantityFieldName = "Quantity";
        private const string _dateCreatedFieldName = "DateCreated";
        private const string _dateUpdatedFieldName = "DateUpdated";
        #endregion

        #region interface properties
        public Int32FieldExpression<Product> Id { get { return Fields[_idFieldName].Value as Int32FieldExpression<Product>; } }
        public EnumFieldExpression<Product, ProductCategoryType> ProductCategoryType { get { return Fields[_productCategoryTypeFieldName].Value as EnumFieldExpression<Product, ProductCategoryType>; } }
        public StringFieldExpression<Product> Name { get { return Fields[_nameFieldName].Value as StringFieldExpression<Product>; } }
        public StringFieldExpression<Product> Description { get { return Fields[_descriptionFieldName].Value as StringFieldExpression<Product>; } }
        public DecimalFieldExpression<Product> Price { get { return Fields[_priceFieldName].Value as DecimalFieldExpression<Product>; } }
        public DecimalFieldExpression<Product> ListPrice { get { return Fields[_listPriceFieldName].Value as DecimalFieldExpression<Product>; } }
        public Int32FieldExpression<Product> Quantity { get { return Fields[_quantityFieldName].Value as Int32FieldExpression<Product>; } }
        public DateTimeFieldExpression<Product> DateCreated { get { return Fields[_dateCreatedFieldName].Value as DateTimeFieldExpression<Product>; } }
        public DateTimeFieldExpression<Product> DateUpdated { get { return Fields[_dateUpdatedFieldName].Value as DateTimeFieldExpression<Product>; } }
        #endregion

        #region constructors
        public ProductEntity(SchemaExpression schema, ISqlEntityMetadata metadata) : this(schema, metadata, null)
        {
        }

        private ProductEntity(SchemaExpression schema, ISqlEntityMetadata metadata, string alias) : base(schema, metadata, alias)
        {
            Fields.Add(_idFieldName, new Lazy<FieldExpression>(() => new Int32FieldExpression<Product>(this, metadata.Fields[_idFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_idFieldName}'"), x => x.Id)));
            Fields.Add(_productCategoryTypeFieldName, new Lazy<FieldExpression>(() => new EnumFieldExpression<Product, ProductCategoryType>(this, metadata.Fields[_productCategoryTypeFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_productCategoryTypeFieldName}'"), x => x.ProductCategoryType)));
            Fields.Add(_nameFieldName, new Lazy<FieldExpression>(() => new StringFieldExpression<Product>(this, metadata.Fields[_nameFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_nameFieldName}'"), x => x.Name)));
            Fields.Add(_descriptionFieldName, new Lazy<FieldExpression>(() => new StringFieldExpression<Product>(this, metadata.Fields[_descriptionFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_descriptionFieldName}'"), x => x.Description)));
            Fields.Add(_priceFieldName, new Lazy<FieldExpression>(() => new DecimalFieldExpression<Product>(this, metadata.Fields[_priceFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_priceFieldName}'"), x => x.Price)));
            Fields.Add(_listPriceFieldName, new Lazy<FieldExpression>(() => new DecimalFieldExpression<Product>(this, metadata.Fields[_listPriceFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_listPriceFieldName}'"), x => x.ListPrice)));
            Fields.Add(_quantityFieldName, new Lazy<FieldExpression>(() => new Int32FieldExpression<Product>(this, metadata.Fields[_quantityFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_quantityFieldName}'"), x => x.Quantity)));
            Fields.Add(_dateCreatedFieldName, new Lazy<FieldExpression>(() => new DateTimeFieldExpression<Product>(this, metadata.Fields[_dateCreatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_dateCreatedFieldName}'"), x => x.DateCreated)));
            Fields.Add(_dateUpdatedFieldName, new Lazy<FieldExpression>(() => new DateTimeFieldExpression<Product>(this, metadata.Fields[_dateUpdatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_dateUpdatedFieldName}'"), x => x.DateUpdated)));
        }
        #endregion

        #region methods
        public ProductEntity As(string name)
        {
            return new ProductEntity(this.Schema, this.Metadata, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                ProductCategoryType,
                Name,
                Description,
                Price,
                ListPrice,
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
                Price.Insert(product.Price),
                ListPrice.Insert(product.ListPrice),
                Quantity.Insert(product.Quantity),
                DateCreated.Insert(product.DateCreated),
                DateUpdated.Insert(product.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Product from, Product to)
        {
            AssignmentExpressionSet expr = null;
            if (from.ProductCategoryType != to.ProductCategoryType) { expr &= ProductCategoryType.Set(to.ProductCategoryType); }
            if (from.Name != to.Name) { expr &= Name.Set(to.Name); }
            if (from.Description != to.Description) { expr &= Description.Set(to.Description); }
            if (from.Price != to.Price) { expr &= Price.Set(to.Price); }
            if (from.ListPrice != to.ListPrice) { expr &= ListPrice.Set(to.ListPrice); }
            if (from.Quantity != to.Quantity) { expr &= Quantity.Set(to.Quantity); }
            expr &= DateUpdated.Set(DateTime.UtcNow);
            return expr;
        }

        protected override void HydrateEntity(Product product, ISqlFieldReader reader, IValueMapper mapper)
        {
            product.Id = mapper.Map<int>(Id, reader.ReadField());
            product.ProductCategoryType = (ProductCategoryType)mapper.Map<int>(ProductCategoryType, reader.ReadField());
            product.Name = mapper.Map<string>(Name, reader.ReadField());
            product.Description = mapper.Map<string>(Description, reader.ReadField());
            product.Price = mapper.Map<decimal>(Price, reader.ReadField());
            product.ListPrice = mapper.Map<decimal>(ListPrice, reader.ReadField());
            product.Quantity = mapper.Map<int>(Quantity, reader.ReadField());
            product.DateCreated = mapper.Map<DateTime>(DateCreated, reader.ReadField());
            product.DateUpdated = mapper.Map<DateTime>(DateUpdated, reader.ReadField());
        }

        protected bool IsPersistSafe(Product product, out List<string> validationMessages)
        {
            validationMessages = new List<string>();
            if (product.Name == null) { validationMessages.Add("Name cannot be empty."); }
            if (product.Name != null && product.Name.Length > 80) { validationMessages.Add("Name cannot be longer than 80 characters."); }
            if (product.Description != null && product.Description.Length > 300) { validationMessages.Add("Description cannot be longer than 300 characters."); }
            if (product.DateCreated == default(DateTime)) { validationMessages.Add("Date Created must contain a value."); }
            if (product.DateUpdated == default(DateTime)) { validationMessages.Add("Date Updated must contain a value."); }
            return validationMessages.Count == 0;
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
        private const string _dateCreatedFieldName = "DateCreated";
        private const string _dateUpdatedFieldName = "DateUpdated";
        #endregion

        #region interface properties
        public Int32FieldExpression<Purchase> Id { get { return Fields[_idFieldName].Value as Int32FieldExpression<Purchase>; } }
        public Int32FieldExpression<Purchase> PersonId { get { return Fields[_personIdFieldName].Value as Int32FieldExpression<Purchase>; } }
        public DecimalFieldExpression<Purchase> TotalPurchaseAmount { get { return Fields[_totalPurchaseAmountFieldName].Value as DecimalFieldExpression<Purchase>; } }
        public DateTimeFieldExpression<Purchase> PurchaseDate { get { return Fields[_purchaseDateFieldName].Value as DateTimeFieldExpression<Purchase>; } }
        public NullableDateTimeFieldExpression<Purchase> ShipDate { get { return Fields[_shipDateFieldName].Value as NullableDateTimeFieldExpression<Purchase>; } }
        public DateTimeFieldExpression<Purchase> DateCreated { get { return Fields[_dateCreatedFieldName].Value as DateTimeFieldExpression<Purchase>; } }
        public DateTimeFieldExpression<Purchase> DateUpdated { get { return Fields[_dateUpdatedFieldName].Value as DateTimeFieldExpression<Purchase>; } }
        #endregion

        #region constructors
        public PurchaseEntity(SchemaExpression schema, ISqlEntityMetadata metadata) : this(schema, metadata, null)
        {
        }

        private PurchaseEntity(SchemaExpression schema, ISqlEntityMetadata metadata, string alias) : base(schema, metadata, alias)
        {
            Fields.Add(_idFieldName, new Lazy<FieldExpression>(() => new Int32FieldExpression<Purchase>(this, metadata.Fields[_idFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_idFieldName}'"), x => x.Id)));
            Fields.Add(_personIdFieldName, new Lazy<FieldExpression>(() => new Int32FieldExpression<Purchase>(this, metadata.Fields[_personIdFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_personIdFieldName}'"), x => x.PersonId)));
            Fields.Add(_totalPurchaseAmountFieldName, new Lazy<FieldExpression>(() => new DecimalFieldExpression<Purchase>(this, metadata.Fields[_totalPurchaseAmountFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_totalPurchaseAmountFieldName}'"), x => x.TotalPurchaseAmount)));
            Fields.Add(_purchaseDateFieldName, new Lazy<FieldExpression>(() => new DateTimeFieldExpression<Purchase>(this, metadata.Fields[_purchaseDateFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_purchaseDateFieldName}'"), x => x.PurchaseDate)));
            Fields.Add(_shipDateFieldName, new Lazy<FieldExpression>(() => new NullableDateTimeFieldExpression<Purchase>(this, metadata.Fields[_shipDateFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_shipDateFieldName}'"), x => x.ShipDate)));
            Fields.Add(_dateCreatedFieldName, new Lazy<FieldExpression>(() => new DateTimeFieldExpression<Purchase>(this, metadata.Fields[_dateCreatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_dateCreatedFieldName}'"), x => x.DateCreated)));
            Fields.Add(_dateUpdatedFieldName, new Lazy<FieldExpression>(() => new DateTimeFieldExpression<Purchase>(this, metadata.Fields[_dateUpdatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_dateUpdatedFieldName}'"), x => x.DateUpdated)));
        }
        #endregion

        #region methods
        public PurchaseEntity As(string name)
        {
            return new PurchaseEntity(this.Schema, this.Metadata, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                PersonId,
                TotalPurchaseAmount,
                PurchaseDate,
                ShipDate,
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
                DateCreated.Insert(purchase.DateCreated),
                DateUpdated.Insert(purchase.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Purchase from, Purchase to)
        {
            AssignmentExpressionSet expr = null;
            if (from.PersonId != to.PersonId) { expr &= PersonId.Set(to.PersonId); }
            if (from.TotalPurchaseAmount != to.TotalPurchaseAmount) { expr &= TotalPurchaseAmount.Set(to.TotalPurchaseAmount); }
            if (from.PurchaseDate != to.PurchaseDate) { expr &= PurchaseDate.Set(to.PurchaseDate); }
            if (from.ShipDate != to.ShipDate) { expr &= ShipDate.Set(to.ShipDate); }
            expr &= DateUpdated.Set(DateTime.UtcNow);
            return expr;
        }

        protected override void HydrateEntity(Purchase purchase, ISqlFieldReader reader, IValueMapper mapper)
        {
            purchase.Id = mapper.Map<int>(Id, reader.ReadField());
            purchase.PersonId = mapper.Map<int>(PersonId, reader.ReadField());
            purchase.TotalPurchaseAmount = mapper.Map<decimal>(TotalPurchaseAmount, reader.ReadField());
            purchase.PurchaseDate = mapper.Map<DateTime>(PurchaseDate, reader.ReadField());
            purchase.ShipDate = mapper.Map<DateTime?>(ShipDate, reader.ReadField());
            purchase.DateCreated = mapper.Map<DateTime>(DateCreated, reader.ReadField());
            purchase.DateUpdated = mapper.Map<DateTime>(DateUpdated, reader.ReadField());
        }

        protected bool IsPersistSafe(Purchase purchase, out List<string> validationMessages)
        {
            validationMessages = new List<string>();
            if (purchase.PurchaseDate == default(DateTime)) { validationMessages.Add("Purchase Date must contain a value."); }
            if (purchase.DateCreated == default(DateTime)) { validationMessages.Add("Date Created must contain a value."); }
            return validationMessages.Count == 0;
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
        public Int32FieldExpression<PurchaseLine> Id { get { return Fields[_idFieldName].Value as Int32FieldExpression<PurchaseLine>; } }
        public Int32FieldExpression<PurchaseLine> PurchaseId { get { return Fields[_purchaseIdFieldName].Value as Int32FieldExpression<PurchaseLine>; } }
        public Int32FieldExpression<PurchaseLine> ProductId { get { return Fields[_productIdFieldName].Value as Int32FieldExpression<PurchaseLine>; } }
        public DecimalFieldExpression<PurchaseLine> PurchasePrice { get { return Fields[_purchasePriceFieldName].Value as DecimalFieldExpression<PurchaseLine>; } }
        public Int32FieldExpression<PurchaseLine> Quantity { get { return Fields[_quantityFieldName].Value as Int32FieldExpression<PurchaseLine>; } }
        public DateTimeFieldExpression<PurchaseLine> DateCreated { get { return Fields[_dateCreatedFieldName].Value as DateTimeFieldExpression<PurchaseLine>; } }
        public DateTimeFieldExpression<PurchaseLine> DateUpdated { get { return Fields[_dateUpdatedFieldName].Value as DateTimeFieldExpression<PurchaseLine>; } }
        #endregion

        #region constructors
        public PurchaseLineEntity(SchemaExpression schema, ISqlEntityMetadata metadata) : this(schema, metadata, null)
        {
        }

        private PurchaseLineEntity(SchemaExpression schema, ISqlEntityMetadata metadata, string alias) : base(schema, metadata, alias)
        {
            Fields.Add(_idFieldName, new Lazy<FieldExpression>(() => new Int32FieldExpression<PurchaseLine>(this, metadata.Fields[_idFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_idFieldName}'"), x => x.Id)));
            Fields.Add(_purchaseIdFieldName, new Lazy<FieldExpression>(() => new Int32FieldExpression<PurchaseLine>(this, metadata.Fields[_purchaseIdFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_purchaseIdFieldName}'"), x => x.PurchaseId)));
            Fields.Add(_productIdFieldName, new Lazy<FieldExpression>(() => new Int32FieldExpression<PurchaseLine>(this, metadata.Fields[_productIdFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_productIdFieldName}'"), x => x.ProductId)));
            Fields.Add(_purchasePriceFieldName, new Lazy<FieldExpression>(() => new DecimalFieldExpression<PurchaseLine>(this, metadata.Fields[_purchasePriceFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_purchasePriceFieldName}'"), x => x.PurchasePrice)));
            Fields.Add(_quantityFieldName, new Lazy<FieldExpression>(() => new NullableInt32FieldExpression<PurchaseLine>(this, metadata.Fields[_quantityFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_quantityFieldName}'"), x => x.Quantity)));
            Fields.Add(_dateCreatedFieldName, new Lazy<FieldExpression>(() => new DateTimeFieldExpression<PurchaseLine>(this, metadata.Fields[_dateCreatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_dateCreatedFieldName}'"), x => x.DateCreated)));
            Fields.Add(_dateUpdatedFieldName, new Lazy<FieldExpression>(() => new DateTimeFieldExpression<PurchaseLine>(this, metadata.Fields[_dateUpdatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_dateUpdatedFieldName}'"), x => x.DateUpdated)));
        }
        #endregion

        #region methods
        public PurchaseLineEntity As(string name)
        {
            return new PurchaseLineEntity(this.Schema, this.Metadata, name);
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
            AssignmentExpressionSet expr = null;
            if (from.PurchaseId != to.PurchaseId) { expr &= PurchaseId.Set(to.PurchaseId); }
            if (from.ProductId != to.ProductId) { expr &= ProductId.Set(to.ProductId); }
            if (from.PurchasePrice != to.PurchasePrice) { expr &= PurchasePrice.Set(to.PurchasePrice); }
            if (from.Quantity != to.Quantity) { expr &= Quantity.Set(to.Quantity); }
            if (from.DateCreated != to.DateCreated) { expr &= DateCreated.Set(to.DateCreated); }
            if (from.DateUpdated != to.DateUpdated) { expr &= DateUpdated.Set(to.DateUpdated); }
            return expr;
        }

        protected override void HydrateEntity(PurchaseLine purchaseLine, ISqlFieldReader reader, IValueMapper mapper)
        {
            purchaseLine.Id = mapper.Map<int>(Id, reader.ReadField());
            purchaseLine.PurchaseId = mapper.Map<int>(PurchaseId, reader.ReadField());
            purchaseLine.ProductId = mapper.Map<int>(ProductId, reader.ReadField());
            purchaseLine.PurchasePrice = mapper.Map<decimal>(PurchasePrice, reader.ReadField());
            purchaseLine.Quantity = mapper.Map<int>(Quantity, reader.ReadField());
            purchaseLine.DateCreated = mapper.Map<DateTime>(DateCreated, reader.ReadField());
            purchaseLine.DateUpdated = mapper.Map<DateTime>(DateUpdated, reader.ReadField());
        }

        protected bool IsPersistSafe(Purchase purchase, out List<string> validationMessages)
        {
            validationMessages = new List<string>();
            if (purchase.PurchaseDate == default(DateTime)) { validationMessages.Add("Purchase Date must contain a value."); }
            if (purchase.DateCreated == default(DateTime)) { validationMessages.Add("Date Created must contain a value."); }
            return validationMessages.Count == 0;
        }
        #endregion
    }
    #endregion
}

namespace DataService.EntityExpression.sec
{
    using Data.sec;
    using HatTrick.DbEx.MsSql.Expression;
    using HatTrick.DbEx.Sql;
    using HatTrick.DbEx.Sql.Executor;
    using HatTrick.DbEx.Sql.Expression;
    using HatTrick.DbEx.Sql.Mapper;
    using HatTrick.DbEx.Utility;
    using System.Data;

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
        public Int32FieldExpression<Person> Id { get { return Fields[_idFieldName].Value as Int32FieldExpression<Person>; } }
        public StringFieldExpression<Person> SSN { get { return Fields[_sSNFieldName].Value as StringFieldExpression<Person>; } }
        public DateTimeFieldExpression<Person> DateCreated { get { return Fields[_dateCreatedFieldName].Value as DateTimeFieldExpression<Person>; } }
        public DateTimeFieldExpression<Person> DateUpdated { get { return Fields[_dateUpdatedFieldName].Value as DateTimeFieldExpression<Person>; } }
        #endregion

        #region constructors
        public PersonEntity(SchemaExpression schema, ISqlEntityMetadata metadata) : this(schema, metadata, null)
        {
        }

        private PersonEntity(SchemaExpression schema, ISqlEntityMetadata metadata, string alias) : base(schema, metadata, alias)
        {
            Fields.Add(_idFieldName, new Lazy<FieldExpression>(() => new Int32FieldExpression<Person>(this, metadata.Fields[_idFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_idFieldName}'"), x => x.Id)));
            Fields.Add(_sSNFieldName, new Lazy<FieldExpression>(() => new StringFieldExpression<Person>(this, metadata.Fields[_sSNFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_sSNFieldName}'"), x => x.SSN)));
            Fields.Add(_dateCreatedFieldName, new Lazy<FieldExpression>(() => new DateTimeFieldExpression<Person>(this, metadata.Fields[_dateCreatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_dateCreatedFieldName}'"), x => x.DateCreated)));
            Fields.Add(_dateUpdatedFieldName, new Lazy<FieldExpression>(() => new DateTimeFieldExpression<Person>(this, metadata.Fields[_dateUpdatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_dateUpdatedFieldName}'"), x => x.DateUpdated)));
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
        {
            return new PersonEntity(this.Schema, this.Metadata,name);
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
            AssignmentExpressionSet expr = null;
            if (from.SSN != to.SSN) { expr &= SSN.Set(to.SSN); }
            expr &= DateUpdated.Set(DateTime.UtcNow);
            return expr;
        }

        protected override void HydrateEntity(Person person, ISqlFieldReader reader, IValueMapper valueMapper)
        {
            person.Id = valueMapper.Map<int>(Id, reader.ReadField());
            person.SSN = valueMapper.Map<string>(SSN, reader.ReadField());
            person.DateCreated = valueMapper.Map<DateTime>(DateCreated, reader.ReadField());
            person.DateUpdated = valueMapper.Map<DateTime>(DateUpdated, reader.ReadField());
        }

        protected bool IsPersistSafe(Person person, out List<string> validationMessages)
        {
            validationMessages = new List<string>();
            if (person.SSN == null) { validationMessages.Add("S S N cannot be empty."); }
            if (person.SSN != null && person.SSN.Length > 9) { validationMessages.Add("S S N cannot be longer than 9 characters."); }
            if (person.DateCreated == default(DateTime)) { validationMessages.Add("Date Created must contain a value."); }
            if (person.DateUpdated == default(DateTime)) { validationMessages.Add("Date Updated must contain a value."); }
            return validationMessages.Count == 0;
        }
        #endregion
    }
    #endregion
}
