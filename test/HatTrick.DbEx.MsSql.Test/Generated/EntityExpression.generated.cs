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

        private FieldExpression<int> _id;
        private FieldExpression<AddressType> _addressType;
        private FieldExpression<string> _line1;
        private FieldExpression<string> _line2;
        private FieldExpression<string> _city;
        private FieldExpression<string> _state;
        private FieldExpression<string> _zip;
        private FieldExpression<DateTime> _dateCreated;
        private FieldExpression<DateTime> _dateUpdated;
        #endregion

        #region interface properties
        public FieldExpression<int> Id { get { return _id; } }
        public FieldExpression<AddressType> AddressType { get { return _addressType; } }
        public FieldExpression<string> Line1 { get { return _line1; } }
        public FieldExpression<string> Line2 { get { return _line2; } }
        public FieldExpression<string> City { get { return _city; } }
        public FieldExpression<string> State { get { return _state; } }
        public FieldExpression<string> Zip { get { return _zip; } }
        public FieldExpression<DateTime> DateCreated { get { return _dateCreated; } }
        public FieldExpression<DateTime> DateUpdated { get { return _dateUpdated; } }
        #endregion

        #region constructors
        public AddressEntity(
            SchemaExpression schema,
            ISqlEntityMetadata entity,
            string alias
        ) : this(
                schema,
                entity, 
                new Dictionary<string, ISqlFieldMetadata>
                {
                    { _idFieldName, entity.Fields?[_idFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_idFieldName}'")}, 
                    { _addressTypeFieldName, entity.Fields?[_addressTypeFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_addressTypeFieldName}'")},
                    { _line1FieldName, entity.Fields?[_line1FieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_line1FieldName}'")},
                    { _line2FieldName, entity.Fields?[_line2FieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_line2FieldName}'")},
                    { _cityFieldName, entity.Fields?[_cityFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_cityFieldName}'")},
                    { _stateFieldName, entity.Fields?[_stateFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_stateFieldName}'")},
                    { _zipFieldName, entity.Fields?[_zipFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_zipFieldName}'")},
                    { _dateCreatedFieldName, entity.Fields?[_dateCreatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_dateCreatedFieldName}'")},
                    { _dateUpdatedFieldName, entity.Fields?[_dateUpdatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_dateUpdatedFieldName}'")}
                }, 
                alias
        )
        {
        }

        private AddressEntity(SchemaExpression schema, ISqlEntityMetadata metadata, IDictionary<string, ISqlFieldMetadata> fields, string alias) 
            : base(schema, metadata, fields, alias)
        {
            _id = new FieldExpression<int>(this, fields[_idFieldName]);
            _addressType = new FieldExpression<AddressType>(this, fields[_addressTypeFieldName]);
            _line1 = new FieldExpression<string>(this, fields[_line1FieldName]);
            _line2 = new FieldExpression<string>(this, fields[_line2FieldName]);
            _city = new FieldExpression<string>(this, fields[_cityFieldName]);
            _state = new FieldExpression<string>(this, fields[_stateFieldName]);
            _zip = new FieldExpression<string>(this, fields[_zipFieldName]);
            _dateCreated = new FieldExpression<DateTime>(this, fields[_dateCreatedFieldName]);
            _dateUpdated = new FieldExpression<DateTime>(this, fields[_dateUpdatedFieldName]);
        }
        #endregion

        #region methods
        public AddressEntity As(string name)
        {
            return new AddressEntity(this.Schema, this.Metadata, this.Fields, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                _id,
                _addressType,
                _line1,
                _line2,
                _city,
                _state,
                _zip,
                _dateCreated,
                _dateUpdated
            );
        }

        protected override InsertExpressionSet GetInclusiveInsertExpression(Address address)
        {
            return new InsertExpressionSet(
                _addressType.Insert(address.AddressType),
                _line1.Insert(address.Line1),
                _line2.Insert(address.Line2),
                _city.Insert(address.City),
                _state.Insert(address.State),
                _zip.Insert(address.Zip),
                _dateCreated.Insert(address.DateCreated),
                _dateUpdated.Insert(address.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Address from, Address to)
        {
            AssignmentExpressionSet expr = new AssignmentExpressionSet();
            if (from.AddressType != to.AddressType) { expr &= _addressType.Set(to.AddressType); }
            if (from.Line1 != to.Line1) { expr &= _line1.Set(to.Line1); }
            if (from.Line2 != to.Line2) { expr &= _line2.Set(to.Line2); }
            if (from.City != to.City) { expr &= _city.Set(to.City); }
            if (from.State != to.State) { expr &= _state.Set(to.State); }
            if (from.Zip != to.Zip) { expr &= _zip.Set(to.Zip); }
            expr &= _dateUpdated.Set(DateTime.UtcNow);
            return expr;
        }

        protected override void HydrateEntity(Address address, IFieldReader reader, IValueMapper mapper)
        {
            address.Id = mapper.Map<int>(_id, reader.Read());
            address.AddressType = (AddressType)mapper.Map<int>(_addressType, reader.Read());
            address.Line1 = mapper.Map<string>(_line1, reader.Read());
            address.Line2 = mapper.Map<string>(_line2, reader.Read());
            address.City = mapper.Map<string>(_city, reader.Read());
            address.State = mapper.Map<string>(_state, reader.Read());
            address.Zip = mapper.Map<string>(_zip, reader.Read());
            address.DateCreated = mapper.Map<DateTime>(_dateCreated, reader.Read());
            address.DateUpdated = mapper.Map<DateTime>(_dateUpdated, reader.Read());
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

        private FieldExpression<int> _id;
        private FieldExpression<string> _firstName;
        private FieldExpression<string> _lastName;
        private FieldExpression<DateTime> _birthDate;
        private FieldExpression<GenderType> _genderType;
        private FieldExpression<DateTime> _dateCreated;
        private FieldExpression<DateTime> _dateUpdated;
        #endregion

        #region interface properties
        public FieldExpression<int> Id { get { return _id; } }
        public FieldExpression<string> FirstName { get { return _firstName; } }
        public FieldExpression<string> LastName { get { return _lastName; } }
        public FieldExpression<DateTime> BirthDate { get { return _birthDate; } }
        public FieldExpression<GenderType> GenderType { get { return _genderType; } }
        public FieldExpression<DateTime> DateCreated { get { return _dateCreated; } }
        public FieldExpression<DateTime> DateUpdated { get { return _dateUpdated; } }
        #endregion

        #region constructors
        public PersonEntity(
            SchemaExpression schema,
            ISqlEntityMetadata entity,
            string alias
        ) : this(
                schema,
                entity,
                new Dictionary<string, ISqlFieldMetadata>
                {
                    { _idFieldName, entity.Fields?[_idFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_idFieldName}'")},
                    { _firstNameFieldName, entity.Fields?[_firstNameFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_firstNameFieldName}'")},
                    { _lastNameFieldName, entity.Fields?[_lastNameFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_lastNameFieldName}'") },
                    { _birthDateFieldName, entity.Fields?[_birthDateFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_birthDateFieldName}'") },
                    { _genderTypeFieldName, entity.Fields?[_genderTypeFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_genderTypeFieldName}'") },
                    { _dateCreatedFieldName, entity.Fields?[_dateCreatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_dateCreatedFieldName}'") },
                    { _dateUpdatedFieldName, entity.Fields?[_dateUpdatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_dateUpdatedFieldName}'") }
                },
                alias
        )
        {
        }

        private PersonEntity(
            SchemaExpression schema,
            ISqlEntityMetadata metadata, 
            IDictionary<string, ISqlFieldMetadata> fields, string alias)
            : base(schema, metadata, fields, alias)
        {
            _id = new FieldExpression<int>(this, fields[_idFieldName]);
            _firstName = new FieldExpression<string>(this, fields[_firstNameFieldName]);
            _lastName = new FieldExpression<string>(this, fields[_lastNameFieldName]);
            _birthDate = new FieldExpression<DateTime>(this, fields[_birthDateFieldName]);
            _genderType = new FieldExpression<GenderType>(this, fields[_genderTypeFieldName]);
            _dateCreated = new FieldExpression<DateTime>(this, fields[_dateCreatedFieldName]);
            _dateUpdated = new FieldExpression<DateTime>(this, fields[_dateUpdatedFieldName]);
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
        {
            return new PersonEntity(this.Schema, this.Metadata, this.Fields, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                _id,
                _firstName,
                _lastName,
                _birthDate,
                _genderType,
                _dateCreated,
                _dateUpdated
            );
        }

        protected override InsertExpressionSet GetInclusiveInsertExpression(Person person)
        {
            return new InsertExpressionSet(
                _firstName.Insert(person.FirstName),
                _lastName.Insert(person.LastName),
                _birthDate.Insert(person.BirthDate),
                _genderType.Insert(person.GenderType),
                _dateCreated.Insert(person.DateCreated),
                _dateUpdated.Insert(person.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person from, Person to)
        {
            AssignmentExpressionSet expr = null;
            if (from.FirstName != to.FirstName) { expr &= _firstName.Set(to.FirstName); }
            if (from.LastName != to.LastName) { expr &= _lastName.Set(to.LastName); }
            if (from.BirthDate != to.BirthDate) { expr &= _birthDate.Set(to.BirthDate); }
            if (from.GenderType != to.GenderType) { expr &= _genderType.Set(to.GenderType); }
            expr &= _dateUpdated.Set(DateTime.UtcNow);
            return expr;
        }

        protected override void HydrateEntity(Person person, IFieldReader reader, IValueMapper mapper)
        {
            person.Id = mapper.Map<int>(_id, reader.Read());
            person.FirstName = mapper.Map<string>(_firstName, reader.Read());
            person.LastName = mapper.Map<string>(_lastName, reader.Read());
            person.BirthDate = mapper.Map<DateTime>(_birthDate, reader.Read());
            person.GenderType = (GenderType)mapper.Map<int>(_genderType, reader.Read());
            person.DateCreated = mapper.Map<DateTime>(_dateCreated, reader.Read());
            person.DateUpdated = mapper.Map<DateTime>(_dateUpdated, reader.Read());
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

        private FieldExpression<int> _id;
        private FieldExpression<int> _personId;
        private FieldExpression<int> _addressId;
        private FieldExpression<DateTime> _dateCreated;
        #endregion

        #region interface properties
        public FieldExpression<int> Id { get { return _id; } }
        public FieldExpression<int> PersonId { get { return _personId; } }
        public FieldExpression<int> AddressId { get { return _addressId; } }
        public FieldExpression<DateTime> DateCreated { get { return _dateCreated; } }
        #endregion

        #region constructors
        public Person_AddressEntity(
            SchemaExpression schema,
            ISqlEntityMetadata entity,
            string alias
        ) : this(
                schema,
                entity,
                new Dictionary<string, ISqlFieldMetadata>
                {
                    { _idFieldName, entity.Fields?[_idFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_idFieldName}'")},
                    { _personIdFieldName, entity.Fields?[_personIdFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_personIdFieldName}'") },
                    { _addressIdFieldName, entity.Fields?[_addressIdFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_addressIdFieldName}'") },
                    { _dateCreatedFieldName, entity.Fields?[_dateCreatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_dateCreatedFieldName}'") }
                },
                alias
        )
        {
        }

        private Person_AddressEntity(
            SchemaExpression schema,
            ISqlEntityMetadata metadata, 
            IDictionary<string, ISqlFieldMetadata> fields, 
            string alias)
            : base(schema, metadata, fields, alias)
        {
            _id = new FieldExpression<int>(this, fields[_idFieldName]);
            _personId = new FieldExpression<int>(this, fields[_personIdFieldName]);
            _addressId = new FieldExpression<int>(this, fields[_addressIdFieldName]);
            _dateCreated = new FieldExpression<DateTime>(this, fields[_dateCreatedFieldName]);
        }
        #endregion

        #region methods
        public Person_AddressEntity As(string name)
        {
            return new Person_AddressEntity(this.Schema, this.Metadata, this.Fields, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                _id,
                _personId,
                _addressId,
                _dateCreated
            );
        }

        protected override InsertExpressionSet GetInclusiveInsertExpression(Person_Address person_Address)
        {
            return new InsertExpressionSet(
                _personId.Insert(person_Address.PersonId),
                _addressId.Insert(person_Address.AddressId),
                _dateCreated.Insert(person_Address.DateCreated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person_Address from, Person_Address to)
        {
            AssignmentExpressionSet expr = null;
            if (from.PersonId != to.PersonId) { expr &= _personId.Set(to.PersonId); }
            if (from.AddressId != to.AddressId) { expr &= _addressId.Set(to.AddressId); }
            return expr;
        }

        protected override void HydrateEntity(Person_Address person_Address, IFieldReader reader, IValueMapper mapper)
        {
            person_Address.Id = mapper.Map<int>(_id, reader.Read());
            person_Address.PersonId = mapper.Map<int>(_personId, reader.Read());
            person_Address.AddressId = mapper.Map<int>(_addressId, reader.Read());
            person_Address.DateCreated = mapper.Map<DateTime>(_dateCreated, reader.Read());
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

        private FieldExpression<int> _id;
        private FieldExpression<ProductCategoryType> _productCategoryType;
        private FieldExpression<string> _name;
        private FieldExpression<string> _description;
        private FieldExpression<decimal> _price;
        private FieldExpression<decimal> _listPrice;
        private FieldExpression<int> _quantity;
        private FieldExpression<DateTime> _dateCreated;
        private FieldExpression<DateTime> _dateUpdated;
        #endregion

        #region interface properties
        public FieldExpression<int> Id { get { return _id; } }
        public FieldExpression<ProductCategoryType> ProductCategoryType { get { return _productCategoryType; } }
        public FieldExpression<string> Name { get { return _name; } }
        public FieldExpression<string> Description { get { return _description; } }
        public FieldExpression<decimal> Price { get { return _price; } }
        public FieldExpression<decimal> ListPrice { get { return _listPrice; } }
        public FieldExpression<int> Quantity { get { return _quantity; } }
        public FieldExpression<DateTime> DateCreated { get { return _dateCreated; } }
        public FieldExpression<DateTime> DateUpdated { get { return _dateUpdated; } }
        #endregion

        #region constructors
        public ProductEntity(
            SchemaExpression schema,
            ISqlEntityMetadata entity,
            string alias
        ) : this(
                schema,
                entity,
                new Dictionary<string, ISqlFieldMetadata>
                {
                    { _idFieldName, entity.Fields?[_idFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_idFieldName}'")},
                    { _productCategoryTypeFieldName, entity.Fields?[_productCategoryTypeFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_productCategoryTypeFieldName}'") },
                    { _nameFieldName, entity.Fields?[_nameFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_nameFieldName}'") },
                    { _descriptionFieldName, entity.Fields?[_descriptionFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_descriptionFieldName}'") },
                    { _priceFieldName, entity.Fields?[_priceFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_priceFieldName}'") },
                    { _listPriceFieldName, entity.Fields?[_listPriceFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_listPriceFieldName}'") },
                    { _quantityFieldName, entity.Fields?[_quantityFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_quantityFieldName}'") },
                    { _dateCreatedFieldName, entity.Fields?[_dateCreatedFieldName]  ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_dateCreatedFieldName}'")},
                    { _dateUpdatedFieldName, entity.Fields?[_dateUpdatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_dateUpdatedFieldName}'") }
                },
                alias
        )
        {
        }

        private ProductEntity(
            SchemaExpression schema,
            ISqlEntityMetadata metadata, 
            IDictionary<string, ISqlFieldMetadata> fields, 
            string alias)
            : base(schema, metadata, fields, alias)
        {
            _id = new FieldExpression<int>(this, fields[_idFieldName]);
            _productCategoryType = new FieldExpression<ProductCategoryType>(this, fields[_productCategoryTypeFieldName]);
            _name = new FieldExpression<string>(this, fields[_nameFieldName]);
            _description = new FieldExpression<string>(this, fields[_descriptionFieldName]);
            _price = new FieldExpression<decimal>(this, fields[_priceFieldName]);
            _listPrice = new FieldExpression<decimal>(this, fields[_listPriceFieldName]);
            _quantity = new FieldExpression<int>(this, fields[_quantityFieldName]);
            _dateCreated = new FieldExpression<DateTime>(this, fields[_dateCreatedFieldName]);
            _dateUpdated = new FieldExpression<DateTime>(this, fields[_dateUpdatedFieldName]);
        }
        #endregion

        #region methods
        public ProductEntity As(string name)
        {
            return new ProductEntity(this.Schema, this.Metadata, this.Fields, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                _id,
                _productCategoryType,
                _name,
                _description,
                _price,
                _listPrice,
                _quantity,
                _dateCreated,
                _dateUpdated
            );
        }

        protected override InsertExpressionSet GetInclusiveInsertExpression(Product product)
        {
            return new InsertExpressionSet(
                _productCategoryType.Insert(product.ProductCategoryType),
                _name.Insert(product.Name),
                _description.Insert(product.Description),
                _price.Insert(product.Price),
                _listPrice.Insert(product.ListPrice),
                _quantity.Insert(product.Quantity),
                _dateCreated.Insert(product.DateCreated),
                _dateUpdated.Insert(product.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Product from, Product to)
        {
            AssignmentExpressionSet expr = null;
            if (from.ProductCategoryType != to.ProductCategoryType) { expr &= _productCategoryType.Set(to.ProductCategoryType); }
            if (from.Name != to.Name) { expr &= _name.Set(to.Name); }
            if (from.Description != to.Description) { expr &= _description.Set(to.Description); }
            if (from.Price != to.Price) { expr &= _price.Set(to.Price); }
            if (from.ListPrice != to.ListPrice) { expr &= _listPrice.Set(to.ListPrice); }
            if (from.Quantity != to.Quantity) { expr &= _quantity.Set(to.Quantity); }
            expr &= _dateUpdated.Set(DateTime.UtcNow);
            return expr;
        }

        protected override void HydrateEntity(Product product, IFieldReader reader, IValueMapper mapper)
        {
            product.Id = mapper.Map<int>(_id, reader.Read());
            product.ProductCategoryType = (ProductCategoryType)mapper.Map<int>(_productCategoryType, reader.Read());
            product.Name = mapper.Map<string>(_name, reader.Read());
            product.Description = mapper.Map<string>(_description, reader.Read());
            product.Price = mapper.Map<decimal>(_price, reader.Read());
            product.ListPrice = mapper.Map<decimal>(_listPrice, reader.Read());
            product.Quantity = mapper.Map<int>(_quantity, reader.Read());
            product.DateCreated = mapper.Map<DateTime>(_dateCreated, reader.Read());
            product.DateUpdated = mapper.Map<DateTime>(_dateUpdated, reader.Read());
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

        private FieldExpression<int> _id;
        private FieldExpression<int> _personId;
        private FieldExpression<decimal> _totalPurchaseAmount;
        private FieldExpression<DateTime> _purchaseDate;
        private NullableFieldExpression<DateTime> _shipDate;
        private FieldExpression<DateTime> _dateCreated;
        private FieldExpression<DateTime> _dateUpdated;
        #endregion

        #region interface properties
        public FieldExpression<int> Id { get { return _id; } }
        public FieldExpression<int> PersonId { get { return _personId; } }
        public FieldExpression<decimal> TotalPurchaseAmount { get { return _totalPurchaseAmount; } }
        public FieldExpression<DateTime> PurchaseDate { get { return _purchaseDate; } }
        public NullableFieldExpression<DateTime> ShipDate { get { return _shipDate; } }
        public FieldExpression<DateTime> DateCreated { get { return _dateCreated; } }
        public FieldExpression<DateTime> DateUpdated { get { return _dateUpdated; } }
        #endregion

        #region constructors
        public PurchaseEntity(
            SchemaExpression schema,
            ISqlEntityMetadata entity,
            string alias
        ) : this(
                schema,
                entity,
                new Dictionary<string, ISqlFieldMetadata>
                {
                    { _idFieldName, entity.Fields?[_idFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_idFieldName}'")},
                    { _personIdFieldName, entity.Fields?[_personIdFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_personIdFieldName}'") },
                    { _totalPurchaseAmountFieldName, entity.Fields?[_totalPurchaseAmountFieldName]  ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_totalPurchaseAmountFieldName}'")},
                    { _purchaseDateFieldName, entity.Fields?[_purchaseDateFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_purchaseDateFieldName}'") },
                    { _shipDateFieldName, entity.Fields?[_shipDateFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_shipDateFieldName}'") },
                    { _dateCreatedFieldName, entity.Fields?[_dateCreatedFieldName]  ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_dateCreatedFieldName}'")},
                    { _dateUpdatedFieldName, entity.Fields?[_dateUpdatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_dateUpdatedFieldName}'") }
                },
                alias
        )
        {
        }

        private PurchaseEntity(
            SchemaExpression schema,
            ISqlEntityMetadata metadata, 
            IDictionary<string, ISqlFieldMetadata> fields, 
            string alias)
            : base(schema, metadata, fields, alias)
        {
            _id = new FieldExpression<int>(this, fields[_idFieldName]);
            _personId = new FieldExpression<int>(this, fields[_personIdFieldName]);
            _totalPurchaseAmount = new FieldExpression<decimal>(this, fields[_totalPurchaseAmountFieldName]);
            _purchaseDate = new FieldExpression<DateTime>(this, fields[_purchaseDateFieldName]);
            _shipDate = new NullableFieldExpression<DateTime>(this, fields[_shipDateFieldName]);
            _dateCreated = new FieldExpression<DateTime>(this, fields[_dateCreatedFieldName]);
            _dateUpdated = new FieldExpression<DateTime>(this, fields[_dateUpdatedFieldName]);
        }
        #endregion

        #region methods
        public PurchaseEntity As(string name)
        {
            return new PurchaseEntity(this.Schema, this.Metadata, this.Fields, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                _id,
                _personId,
                _totalPurchaseAmount,
                _purchaseDate,
                _shipDate,
                _dateCreated,
                _dateUpdated
            );
        }

        protected override InsertExpressionSet GetInclusiveInsertExpression(Purchase purchase)
        {
            return new InsertExpressionSet(
                _personId.Insert(purchase.PersonId),
                _totalPurchaseAmount.Insert(purchase.TotalPurchaseAmount),
                _purchaseDate.Insert(purchase.PurchaseDate),
                _shipDate.Insert(purchase.ShipDate),
                _dateCreated.Insert(purchase.DateCreated),
                _dateUpdated.Insert(purchase.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Purchase from, Purchase to)
        {
            AssignmentExpressionSet expr = null;
            if (from.PersonId != to.PersonId) { expr &= _personId.Set(to.PersonId); }
            if (from.TotalPurchaseAmount != to.TotalPurchaseAmount) { expr &= _totalPurchaseAmount.Set(to.TotalPurchaseAmount); }
            if (from.PurchaseDate != to.PurchaseDate) { expr &= _purchaseDate.Set(to.PurchaseDate); }
            if (from.ShipDate != to.ShipDate) { expr &= _shipDate.Set(to.ShipDate); }
            expr &= _dateUpdated.Set(DateTime.UtcNow);
            return expr;
        }

        protected override void HydrateEntity(Purchase purchase, IFieldReader reader, IValueMapper mapper)
        {
            purchase.Id = mapper.Map<int>(_id, reader.Read());
            purchase.PersonId = mapper.Map<int>(_personId, reader.Read());
            purchase.TotalPurchaseAmount = mapper.Map<decimal>(_totalPurchaseAmount, reader.Read());
            purchase.PurchaseDate = mapper.Map<DateTime>(_purchaseDate, reader.Read());
            purchase.ShipDate = mapper.Map<DateTime?>(_shipDate, reader.Read());
            purchase.DateCreated = mapper.Map<DateTime>(_dateCreated, reader.Read());
            purchase.DateUpdated = mapper.Map<DateTime>(_dateUpdated, reader.Read());
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

        private FieldExpression<int> _id;
        private FieldExpression<int> _purchaseId;
        private FieldExpression<int> _productId;
        private FieldExpression<decimal> _purchasePrice;
        private FieldExpression<int> _quantity;
        private FieldExpression<DateTime> _dateCreated;
        private FieldExpression<DateTime> _dateUpdated;
        #endregion

        #region interface properties
        public FieldExpression<int> Id { get { return _id; } }
        public FieldExpression<int> PurchaseId { get { return _purchaseId; } }
        public FieldExpression<int> ProductId { get { return _productId; } }
        public FieldExpression<decimal> PurchasePrice { get { return _purchasePrice; } }
        public FieldExpression<int> Quantity { get { return _quantity; } }
        public FieldExpression<DateTime> DateCreated { get { return _dateCreated; } }
        public FieldExpression<DateTime> DateUpdated { get { return _dateUpdated; } }
        #endregion

        #region constructors
        public PurchaseLineEntity(
            SchemaExpression schema,
            ISqlEntityMetadata entity,
            string alias
        ) : this(
                schema,
                entity,
                new Dictionary<string, ISqlFieldMetadata>
                {
                    { _idFieldName, entity.Fields?[_idFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_idFieldName}'")},
                    { _purchaseIdFieldName, entity.Fields?[_purchaseIdFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_purchaseIdFieldName}'") },
                    { _productIdFieldName, entity.Fields?[_productIdFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_productIdFieldName}'") },
                    { _purchasePriceFieldName, entity.Fields?[_purchasePriceFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_purchasePriceFieldName}'") },
                    { _quantityFieldName, entity.Fields?[_quantityFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_quantityFieldName}'") },
                    { _dateCreatedFieldName, entity.Fields?[_dateCreatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_dateCreatedFieldName}'") },
                    { _dateUpdatedFieldName, entity.Fields?[_dateUpdatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_dateUpdatedFieldName}'") }
                },
                alias
        )
        {
        }

        private PurchaseLineEntity(
            SchemaExpression schema,
            ISqlEntityMetadata metadata, 
            IDictionary<string, ISqlFieldMetadata> fields, 
            string alias)
            : base(schema, metadata, fields, alias)
        {
            _id = new FieldExpression<int>(this, fields[_idFieldName]);
            _purchaseId = new FieldExpression<int>(this, fields[_purchaseIdFieldName]);
            _productId = new FieldExpression<int>(this, fields[_productIdFieldName]);
            _purchasePrice = new FieldExpression<decimal>(this, fields[_purchasePriceFieldName]);
            _quantity = new FieldExpression<int>(this, fields[_quantityFieldName]);
            _dateCreated = new FieldExpression<DateTime>(this, fields[_dateCreatedFieldName]);
            _dateUpdated = new FieldExpression<DateTime>(this, fields[_dateUpdatedFieldName]);
        }
        #endregion

        #region methods
        public PurchaseLineEntity As(string name)
        {
            return new PurchaseLineEntity(this.Schema, this.Metadata, this.Fields, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                _id,
                _purchaseId,
                _productId,
                _purchasePrice,
                _quantity,
                _dateCreated,
                _dateUpdated
            );
        }

        protected override InsertExpressionSet GetInclusiveInsertExpression(PurchaseLine purchaseLine)
        {
            return new InsertExpressionSet(
                _purchaseId.Insert(purchaseLine.PurchaseId),
                _productId.Insert(purchaseLine.ProductId),
                _purchasePrice.Insert(purchaseLine.PurchasePrice),
                _quantity.Insert(purchaseLine.Quantity),
                _dateCreated.Insert(purchaseLine.DateCreated),
                _dateUpdated.Insert(purchaseLine.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PurchaseLine from, PurchaseLine to)
        {
            AssignmentExpressionSet expr = null;
            if (from.PurchaseId != to.PurchaseId) { expr &= _purchaseId.Set(to.PurchaseId); }
            if (from.ProductId != to.ProductId) { expr &= _productId.Set(to.ProductId); }
            if (from.PurchasePrice != to.PurchasePrice) { expr &= _purchasePrice.Set(to.PurchasePrice); }
            if (from.Quantity != to.Quantity) { expr &= _quantity.Set(to.Quantity); }
            if (from.DateCreated != to.DateCreated) { expr &= _dateCreated.Set(to.DateCreated); }
            if (from.DateUpdated != to.DateUpdated) { expr &= _dateUpdated.Set(to.DateUpdated); }
            return expr;
        }

        protected override void HydrateEntity(PurchaseLine purchaseLine, IFieldReader reader, IValueMapper mapper)
        {
            purchaseLine.Id = mapper.Map<int>(_id, reader.Read());
            purchaseLine.PurchaseId = mapper.Map<int>(_purchaseId, reader.Read());
            purchaseLine.ProductId = mapper.Map<int>(_productId, reader.Read());
            purchaseLine.PurchasePrice = mapper.Map<decimal>(_purchasePrice, reader.Read());
            purchaseLine.Quantity = mapper.Map<int>(_quantity, reader.Read());
            purchaseLine.DateCreated = mapper.Map<DateTime>(_dateCreated, reader.Read());
            purchaseLine.DateUpdated = mapper.Map<DateTime>(_dateUpdated, reader.Read());
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

        private static volatile FieldExpression<int> _id;
        private static volatile FieldExpression<string> _sSN;
        private static volatile FieldExpression<DateTime> _dateCreated;
        private static volatile FieldExpression<DateTime> _dateUpdated;
        #endregion

        #region interface properties
        public FieldExpression<int> Id { get { return _id; } }
        public FieldExpression<string> SSN { get { return _sSN; } }
        public FieldExpression<DateTime> DateCreated { get { return _dateCreated; } }
        public FieldExpression<DateTime> DateUpdated { get { return _dateUpdated; } }
        #endregion

        #region constructors
        public PersonEntity(
            SchemaExpression schema,
            ISqlEntityMetadata entity,
            string alias
        ) : this(
                schema,
                entity,
                new Dictionary<string, ISqlFieldMetadata>
                {
                    { _idFieldName, entity.Fields[_idFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_idFieldName}'")},
                    { _sSNFieldName, entity.Fields[_sSNFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_sSNFieldName}'") },
                    { _dateCreatedFieldName, entity.Fields[_dateCreatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_dateCreatedFieldName}'") },
                    { _dateUpdatedFieldName, entity.Fields[_dateUpdatedFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity {entity.Name} does not contain metadata for field '{_dateUpdatedFieldName}'") }
                },
                alias
        )
        {
        }

        private PersonEntity(
            SchemaExpression schema,
            ISqlEntityMetadata metadata, 
            IDictionary<string, ISqlFieldMetadata> fields, 
            string alias)
            : base(schema, metadata, fields, alias)
        {
            _id = new FieldExpression<int>(this, fields[_idFieldName]);
            _sSN = new FieldExpression<string>(this, fields[_sSNFieldName]);
            _dateCreated = new FieldExpression<DateTime>(this, fields[_dateCreatedFieldName]);
            _dateUpdated = new FieldExpression<DateTime>(this, fields[_dateUpdatedFieldName]);
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
        {
            return new PersonEntity(this.Schema, this.Metadata, this.Fields, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                _id,
                _sSN,
                _dateCreated,
                _dateUpdated
            );
        }

        protected override InsertExpressionSet GetInclusiveInsertExpression(Person person)
        {
            return new InsertExpressionSet(
                _sSN.Insert(person.SSN),
                _dateCreated.Insert(person.DateCreated),
                _dateUpdated.Insert(person.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person from, Person to)
        {
            AssignmentExpressionSet expr = null;
            if (from.SSN != to.SSN) { expr &= _sSN.Set(to.SSN); }
            expr &= _dateUpdated.Set(DateTime.UtcNow);
            return expr;
        }

        protected override void HydrateEntity(Person person, IFieldReader reader, IValueMapper valueMapper)
        {
            person.Id = valueMapper.Map<int>(_id, reader.Read());
            person.SSN = valueMapper.Map<string>(_sSN, reader.Read());
            person.DateCreated = valueMapper.Map<DateTime>(_dateCreated, reader.Read());
            person.DateUpdated = valueMapper.Map<DateTime>(_dateUpdated, reader.Read());
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
