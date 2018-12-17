using System;
using System.Collections.Generic;

namespace DataService.EntityExpression.dbo
{
    using Data;
    using Data.dbo;
    using HatTrick.DbEx.MsSql.Expression;
    using HatTrick.DbEx.Sql.Executor;
    using HatTrick.DbEx.Sql.Expression;
    using HatTrick.DbEx.Sql.Mapper;
    using HatTrick.DbEx.Utility;
    using System.Data;

    #region address
    public partial class AddressEntity : EntityExpression<Address>
    {
        #region internals
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
        private AddressEntity(EntityExpressionMetadata metadata) : base(metadata)
        {
            _id = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "Id", SqlDbType.Int, 4));
            _addressType = new FieldExpression<AddressType>(new MsSqlFieldExpressionMetadata(this, "AddressType", SqlDbType.Int, 4));
            _line1 = new FieldExpression<string>(new MsSqlFieldExpressionMetadata(this, "Line1", SqlDbType.VarChar, 50));
            _line2 = new FieldExpression<string>(new MsSqlFieldExpressionMetadata(this, "Line2", SqlDbType.VarChar, 50));
            _city = new FieldExpression<string>(new MsSqlFieldExpressionMetadata(this, "City", SqlDbType.VarChar, 60));
            _state = new FieldExpression<string>(new MsSqlFieldExpressionMetadata(this, "State", SqlDbType.VarChar, 2));
            _zip = new FieldExpression<string>(new MsSqlFieldExpressionMetadata(this, "Zip", SqlDbType.VarChar, 10));
            _dateCreated = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "DateCreated", SqlDbType.DateTime, 8));
            _dateUpdated = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "DateUpdated", SqlDbType.DateTime, 8));             
        }

        public AddressEntity(SchemaExpression schema, string entityName) : this(new EntityExpressionMetadata(schema, entityName))
        {

        }

        public AddressEntity(SchemaExpression schema, string entityName, string aliasName) : this(new EntityExpressionMetadata(schema, entityName, aliasName))
        {
        }
        #endregion

        #region methods
        public AddressEntity As(string name)
        {
            var meta = (this as IExpressionMetadataProvider<EntityExpressionMetadata>).Metadata;
            var newMeta = CloneUtility.DeepCopy(meta);
            newMeta.AliasName = name;
            return new AddressEntity(newMeta);
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
        private PersonEntity(EntityExpressionMetadata metadata) : base(metadata)
        {
            _id = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "Id", SqlDbType.Int, 4));
            _firstName = new FieldExpression<string>(new MsSqlFieldExpressionMetadata(this, "FirstName", SqlDbType.VarChar, 20));
            _lastName = new FieldExpression<string>(new MsSqlFieldExpressionMetadata(this, "LastName", SqlDbType.VarChar, 20));
            _birthDate = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "BirthDate", SqlDbType.DateTime, 8));
            _genderType = new FieldExpression<GenderType>(new MsSqlFieldExpressionMetadata(this, "GenderType", SqlDbType.Int, 4));
            _dateCreated = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "DateCreated", SqlDbType.DateTime, 8));
            _dateUpdated = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "DateUpdated", SqlDbType.DateTime, 8));
        }

        public PersonEntity(SchemaExpression schema, string entityName) : this(new EntityExpressionMetadata(schema, entityName))
        {

        }
        public PersonEntity(SchemaExpression schema, string entityName, string aliasName) : base(new EntityExpressionMetadata(schema, entityName, aliasName))
        {
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
        {
            var meta = (this as IExpressionMetadataProvider<EntityExpressionMetadata>).Metadata;
            var newMeta = CloneUtility.DeepCopy(meta);
            newMeta.AliasName = name;
            return new PersonEntity(newMeta);
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
        private Person_AddressEntity(EntityExpressionMetadata metadata) : base(metadata)
        {
            _id = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "Id", SqlDbType.Int, 4));
            _personId = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "PersonId", SqlDbType.Int, 4));
            _addressId = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "AddressId", SqlDbType.Int, 4));
            _dateCreated = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "DateCreated", SqlDbType.DateTime, 8));
        }

        public Person_AddressEntity(SchemaExpression schema, string entityName) : this(new EntityExpressionMetadata(schema, entityName))
        {

        }
        public Person_AddressEntity(SchemaExpression schema, string entityName, string aliasName) : this(new EntityExpressionMetadata(schema, entityName, aliasName))
        {
        }
        #endregion

        #region methods
        public Person_AddressEntity As(string name)
        {
            var meta = (this as IExpressionMetadataProvider<EntityExpressionMetadata>).Metadata;
            var newMeta = CloneUtility.DeepCopy(meta);
            newMeta.AliasName = name;
            return new Person_AddressEntity(newMeta);
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
        private ProductEntity(EntityExpressionMetadata metadata) : base(metadata)
        {
            _id = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "Id", SqlDbType.Int, 4));
            _productCategoryType = new FieldExpression<ProductCategoryType>(new MsSqlFieldExpressionMetadata(this, "ProductCategoryType", SqlDbType.Int, 4));
            _name = new FieldExpression<string>(new MsSqlFieldExpressionMetadata(this, "Name", SqlDbType.VarChar, 80));
            _description = new FieldExpression<string>(new MsSqlFieldExpressionMetadata(this, "Description", SqlDbType.VarChar, 300));
            _price = new FieldExpression<decimal>(new MsSqlFieldExpressionMetadata(this, "Price", SqlDbType.Decimal, 12, 2));
            _listPrice = new FieldExpression<decimal>(new MsSqlFieldExpressionMetadata(this, "ListPrice", SqlDbType.Decimal, 12, 2));
            _quantity = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "Quantity", SqlDbType.Int, 4));
            _dateCreated = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "DateCreated", SqlDbType.DateTime, 8));
            _dateUpdated = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "DateUpdated", SqlDbType.DateTime, 8));
        }

        public ProductEntity(SchemaExpression schema, string entityName) : this(new EntityExpressionMetadata(schema, entityName))
        {

        }

        public ProductEntity(SchemaExpression schema, string entityName, string aliasName) : this(new EntityExpressionMetadata(schema, entityName, aliasName))
        {
        }
        #endregion

        #region methods
        public ProductEntity As(string name)
        {
            var meta = (this as IExpressionMetadataProvider<EntityExpressionMetadata>).Metadata;
            var newMeta = CloneUtility.DeepCopy(meta);
            newMeta.AliasName = name;
            return new ProductEntity(newMeta);
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
        private FieldExpression<int> _id;
        private FieldExpression<int> _personId;
        private FieldExpression<decimal> _totalPurchaseAmount;
        private FieldExpression<DateTime> _purchaseDate;
        private FieldExpression<DateTime> _shipDate;
        private FieldExpression<DateTime> _dateCreated;
        private FieldExpression<DateTime> _dateUpdated;
        #endregion

        #region interface properties
        public FieldExpression<int> Id { get { return _id; } }
        public FieldExpression<int> PersonId { get { return _personId; } }
        public FieldExpression<decimal> TotalPurchaseAmount { get { return _totalPurchaseAmount; } }
        public FieldExpression<DateTime> PurchaseDate { get { return _purchaseDate; } }
        public FieldExpression<DateTime> ShipDate { get { return _shipDate; } }
        public FieldExpression<DateTime> DateCreated { get { return _dateCreated; } }
        public FieldExpression<DateTime> DateUpdated { get { return _dateUpdated; } }
        #endregion

        #region constructors
        private PurchaseEntity(EntityExpressionMetadata metadata) : base(metadata)
        {
            _id = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "Id", SqlDbType.Int, 4));
            _personId = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "PersonId", SqlDbType.Int, 4));
            _totalPurchaseAmount = new FieldExpression<decimal>(new MsSqlFieldExpressionMetadata(this, "TotalPurchaseAmount", SqlDbType.Decimal, 12, 2));
            _purchaseDate = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "PurchaseDate", SqlDbType.DateTime, 8));
            _shipDate = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "ShipDate", SqlDbType.DateTime, 8));
            _dateCreated = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "DateCreated", SqlDbType.DateTime, 8));
            _dateUpdated = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "DateUpdated", SqlDbType.DateTime, 8));
        }

        public PurchaseEntity(SchemaExpression schema, string entityName) : this(new EntityExpressionMetadata(schema, entityName))
        {

        }
        public PurchaseEntity(SchemaExpression schema, string entityName, string aliasName) : this(new EntityExpressionMetadata(schema, entityName, aliasName))
        {
        }
        #endregion

        #region methods
        public PurchaseEntity As(string name)
        {
            var meta = (this as IExpressionMetadataProvider<EntityExpressionMetadata>).Metadata;
            var newMeta = CloneUtility.DeepCopy(meta);
            newMeta.AliasName = name;
            return new PurchaseEntity(newMeta);
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
            purchase.ShipDate = mapper.Map<DateTime>(_shipDate, reader.Read());
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
        private PurchaseLineEntity(EntityExpressionMetadata metadata) : base(metadata)
        {
            _id = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "Id", SqlDbType.Int, 4));
            _purchaseId = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "PurchaseId", SqlDbType.Int, 4));
            _productId = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "ProductId", SqlDbType.Int, 4));
            _purchasePrice = new FieldExpression<decimal>(new MsSqlFieldExpressionMetadata(this, "PurchasePrice", SqlDbType.Decimal, 12, 2));
            _quantity = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "Quantity", SqlDbType.Int, 4));
            _dateCreated = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "DateCreated", SqlDbType.DateTime, 8));
            _dateUpdated = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "DateUpdated", SqlDbType.DateTime, 8));
        }

        public PurchaseLineEntity(SchemaExpression schema, string entityName) : this(new EntityExpressionMetadata(schema, entityName))
        {

        }
        public PurchaseLineEntity(SchemaExpression schema, string entityName, string aliasName) : this(new EntityExpressionMetadata(schema, entityName, aliasName))
        {
        }
        #endregion

        #region methods
        public PurchaseLineEntity As(string name)
        {
            var meta = (this as IExpressionMetadataProvider<EntityExpressionMetadata>).Metadata;
            var newMeta = CloneUtility.DeepCopy(meta);
            newMeta.AliasName = name;
            return new PurchaseLineEntity(newMeta);
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
    using HatTrick.DbEx.Sql.Executor;
    using HatTrick.DbEx.Sql.Expression;
    using HatTrick.DbEx.Sql.Mapper;
    using HatTrick.DbEx.Utility;
    using System.Data;

    #region person
    public partial class PersonEntity : EntityExpression<Person>
    {
        #region internals
        private static volatile FieldExpression<int> _id;
        private static volatile FieldExpression<int> _personId;
        private static volatile FieldExpression<string> _sSN;
        private static volatile FieldExpression<DateTime> _dateCreated;
        private static volatile FieldExpression<DateTime> _dateUpdated;
        #endregion

        #region interface properties
        public FieldExpression<int> Id { get { return _id; } }
        public FieldExpression<int> PersonId { get { return _personId; } }
        public FieldExpression<string> SSN { get { return _sSN; } }
        public FieldExpression<DateTime> DateCreated { get { return _dateCreated; } }
        public FieldExpression<DateTime> DateUpdated { get { return _dateUpdated; } }
        #endregion

        #region constructors
        private PersonEntity(EntityExpressionMetadata metadata) : base(metadata)
        {
            _id = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "Id", SqlDbType.Int, 4));
            _personId = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "PersonId", SqlDbType.Int, 8));
            _sSN = new FieldExpression<string>(new MsSqlFieldExpressionMetadata(this, "SSN", SqlDbType.VarChar, 9));
            _dateCreated = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "DateCreated", SqlDbType.DateTime, 8));
            _dateUpdated = new FieldExpression<DateTime>(new MsSqlFieldExpressionMetadata(this, "DateUpdated", SqlDbType.DateTime, 8));
        }

        public PersonEntity(SchemaExpression schema, string entityName) : this(new EntityExpressionMetadata(schema, entityName))
        {

        }
        public PersonEntity(SchemaExpression schema, string entityName, string aliasName) : this(new EntityExpressionMetadata(schema, entityName, aliasName))
        {
        }
        #endregion

        #region methods
        public PersonEntity As(string name)
        {
            var meta = (this as IExpressionMetadataProvider<EntityExpressionMetadata>).Metadata;
            var newMeta = CloneUtility.DeepCopy(meta);
            newMeta.AliasName = name;
            return new PersonEntity(newMeta);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                _id,
                _personId,
                _sSN,
                _dateCreated,
                _dateUpdated
            );
        }

        protected override InsertExpressionSet GetInclusiveInsertExpression(Person person)
        {
            return new InsertExpressionSet(
                _personId.Insert(person.PersonId),
                _sSN.Insert(person.SSN),
                _dateCreated.Insert(person.DateCreated),
                _dateUpdated.Insert(person.DateUpdated)
            );
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(Person from, Person to)
        {
            AssignmentExpressionSet expr = null;
            if (from.PersonId != to.PersonId) { expr &= _personId.Set(to.PersonId); }
            if (from.SSN != to.SSN) { expr &= _sSN.Set(to.SSN); }
            expr &= _dateUpdated.Set(DateTime.UtcNow);
            return expr;
        }

        protected override void HydrateEntity(Person person, IFieldReader reader, IValueMapper valueMapper)
        {
            person.Id = valueMapper.Map<int>(_id, reader.Read());
            person.PersonId = valueMapper.Map<int>(_personId, reader.Read());
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
