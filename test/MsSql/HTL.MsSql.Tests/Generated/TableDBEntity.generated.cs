using System;
using System.Collections.Generic;
using HTL.DbEx.Utility;
using HTL.DbEx.Sql.Expression;

namespace HTL.MsSql.MsSqlTest.dbo.DataService
{
	using Data;

	public static partial class dbo
	{
		#region address
		public partial class AddressEntity : DBExpressionEntity
		{
			#region internals
			private DBExpressionField<int> _id;
			private DBExpressionField<AddressType> _addressType;
			private DBExpressionField<string> _line1;
			private DBExpressionField<string> _line2;
			private DBExpressionField<string> _city;
			private DBExpressionField<string> _state;
			private DBExpressionField<string> _zip;
			private DBExpressionField<DateTime> _dateCreated;
			private DBExpressionField<DateTime> _dateUpdated;
			#endregion

			#region interface properties
			public DBExpressionField<int> Id { get { return _id; } }
			public DBExpressionField<AddressType> AddressType { get { return _addressType; } }
			public DBExpressionField<string> Line1 { get { return _line1; } }
			public DBExpressionField<string> Line2 { get { return _line2; } }
			public DBExpressionField<string> City { get { return _city; } }
			public DBExpressionField<string> State { get { return _state; } }
			public DBExpressionField<string> Zip { get { return _zip; } }
			public DBExpressionField<DateTime> DateCreated { get { return _dateCreated; } }
			public DBExpressionField<DateTime> DateUpdated { get { return _dateUpdated; } }
			#endregion

			#region constructors
			public AddressEntity(string schema, string entityName) : base(schema, entityName)
			{
				_id = new DBExpressionField<int>(this, "Id", 4);
				_addressType = new DBExpressionField<AddressType>(this, "AddressType", 4);
				_line1 = new DBExpressionField<string>(this, "Line1", 50);
				_line2 = new DBExpressionField<string>(this, "Line2", 50);
				_city = new DBExpressionField<string>(this, "City", 60);
				_state = new DBExpressionField<string>(this, "State", 2);
				_zip = new DBExpressionField<string>(this, "Zip", 10);
				_dateCreated = new DBExpressionField<DateTime>(this, "DateCreated", 8);
				_dateUpdated = new DBExpressionField<DateTime>(this, "DateUpdated", 8);
			}
			#endregion

			#region methods
			public new AddressEntity Correlate(string alias)
            {
                return new AddressEntity(base.Schema, base.Name) { IsCorrelated = true, AliasName = alias };
            }

			public new AddressEntity As(string alias)
            {
                return new AddressEntity(base.Schema, base.Name) { IsAliased = true, AliasName = alias };
            }

			public Address Clone(Address address)
			{
				return CloneUtility.DeepCopy<Address>(address);
			}

			public SqlExpressionBuilder<Address> Query()
			{
				return dbo.GetExpressionBuilder<Address>(this)
					.WithSelectExpressionProvider(this.GetInclusiveSelectExpression)
					.WithFillCallback(this.FillObject)
					.WithInsertExpressionProvider(this.GetInclusiveInsertExpression);
			}

			public DBSelectExpressionSet GetInclusiveSelectExpression()
			{
				DBSelectExpressionSet select = null;
           		select &= _id;
           		select &= _addressType;
           		select &= _line1;
           		select &= _line2;
           		select &= _city;
           		select &= _state;
           		select &= _zip;
           		select &= _dateCreated;
           		select &= _dateUpdated;
				return select;
			}

			public DBInsertExpressionSet GetInclusiveInsertExpression(Address address)
			{
				List<string> msg;
				if (!this.IsPersistSafe(address, out msg))
				{
					throw new InvalidOperationException(string.Format("Object is not persist safe: {0}", string.Join("; ", msg)));
				}

				DBInsertExpressionSet expr = null;
				expr &= _addressType.Insert(address.AddressType);
				expr &= _line1.Insert(address.Line1);
				expr &= _line2.Insert(address.Line2);
				expr &= _city.Insert(address.City);
				expr &= _state.Insert(address.State);
				expr &= _zip.Insert(address.Zip);
				expr &= _dateCreated.Insert(address.DateCreated);
				expr &= _dateUpdated.Insert(address.DateUpdated);
				return expr;
			}

			public DBAssignmentExpressionSet GetAssignmentExpression(Address from, Address to)
			{
				DBAssignmentExpressionSet expr = null;
				if (from.AddressType != to.AddressType) { expr &= _addressType.Set(to.AddressType); }
				if (from.Line1 != to.Line1) { expr &= _line1.Set(to.Line1); }
				if (from.Line2 != to.Line2) { expr &= _line2.Set(to.Line2); }
				if (from.City != to.City) { expr &= _city.Set(to.City); }
				if (from.State != to.State) { expr &= _state.Set(to.State); }
				if (from.Zip != to.Zip) { expr &= _zip.Set(to.Zip); }
				expr &= _dateUpdated.Set(DateTime.UtcNow);
				return expr;
			}
		
			public void FillObject(Address address, object[] values)
			{
				//if the column allows null, do the dbnull check, else just cast in..???
				address.Id = (int)values[0];
				address.AddressType = (values[1] != DBNull.Value) ? (AddressType)values[1] : default(AddressType);
				address.Line1 = (string)values[2];
				address.Line2 = (values[3] != DBNull.Value) ? (string)values[3] : default(string);
				address.City = (string)values[4];
				address.State = (string)values[5];
				address.Zip = (string)values[6];
				address.DateCreated = DateTime.SpecifyKind((DateTime)values[7], DateTimeKind.Utc);
				address.DateUpdated = DateTime.SpecifyKind((DateTime)values[8], DateTimeKind.Utc);
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
		public partial class PersonEntity : DBExpressionEntity
		{
			#region internals
			private DBExpressionField<int> _id;
			private DBExpressionField<string> _firstName;
			private DBExpressionField<string> _lastName;
			private DBExpressionField<DateTime> _birthDate;
			private DBExpressionField<DateTime> _dateCreated;
			private DBExpressionField<DateTime> _dateUpdated;
			#endregion

			#region interface properties
			public DBExpressionField<int> Id { get { return _id; } }
			public DBExpressionField<string> FirstName { get { return _firstName; } }
			public DBExpressionField<string> LastName { get { return _lastName; } }
			public DBExpressionField<DateTime> BirthDate { get { return _birthDate; } }
			public DBExpressionField<DateTime> DateCreated { get { return _dateCreated; } }
			public DBExpressionField<DateTime> DateUpdated { get { return _dateUpdated; } }
			#endregion

			#region constructors
			public PersonEntity(string schema, string entityName) : base(schema, entityName)
			{
				_id = new DBExpressionField<int>(this, "Id", 4);
				_firstName = new DBExpressionField<string>(this, "FirstName", 20);
				_lastName = new DBExpressionField<string>(this, "LastName", 20);
				_birthDate = new DBExpressionField<DateTime>(this, "BirthDate", 8);
				_dateCreated = new DBExpressionField<DateTime>(this, "DateCreated", 8);
				_dateUpdated = new DBExpressionField<DateTime>(this, "DateUpdated", 8);
			}
			#endregion

			#region methods
			public new PersonEntity Correlate(string alias)
            {
                return new PersonEntity(base.Schema, base.Name) { IsCorrelated = true, AliasName = alias };
            }

			public new PersonEntity As(string alias)
            {
                return new PersonEntity(base.Schema, base.Name) { IsAliased = true, AliasName = alias };
            }

			public Person Clone(Person person)
			{
				return CloneUtility.DeepCopy<Person>(person);
			}

			public SqlExpressionBuilder<Person> Query()
			{
				return dbo.GetExpressionBuilder<Person>(this)
					.WithSelectExpressionProvider(this.GetInclusiveSelectExpression)
					.WithFillCallback(this.FillObject)
					.WithInsertExpressionProvider(this.GetInclusiveInsertExpression);
			}

			public DBSelectExpressionSet GetInclusiveSelectExpression()
			{
				DBSelectExpressionSet select = null;
           		select &= _id;
           		select &= _firstName;
           		select &= _lastName;
           		select &= _birthDate;
           		select &= _dateCreated;
           		select &= _dateUpdated;
				return select;
			}

			public DBInsertExpressionSet GetInclusiveInsertExpression(Person person)
			{
				List<string> msg;
				if (!this.IsPersistSafe(person, out msg))
				{
					throw new InvalidOperationException(string.Format("Object is not persist safe: {0}", string.Join("; ", msg)));
				}

				DBInsertExpressionSet expr = null;
				expr &= _firstName.Insert(person.FirstName);
				expr &= _lastName.Insert(person.LastName);
				expr &= _birthDate.Insert(person.BirthDate);
				expr &= _dateCreated.Insert(person.DateCreated);
				expr &= _dateUpdated.Insert(person.DateUpdated);
				return expr;
			}

			public DBAssignmentExpressionSet GetAssignmentExpression(Person from, Person to)
			{
				DBAssignmentExpressionSet expr = null;
				if (from.FirstName != to.FirstName) { expr &= _firstName.Set(to.FirstName); }
				if (from.LastName != to.LastName) { expr &= _lastName.Set(to.LastName); }
				if (from.BirthDate != to.BirthDate) { expr &= _birthDate.Set(to.BirthDate); }
				expr &= _dateUpdated.Set(DateTime.UtcNow);
				return expr;
			}
		
			public void FillObject(Person person, object[] values)
			{
				//if the column allows null, do the dbnull check, else just cast in..???
				person.Id = (int)values[0];
				person.FirstName = (string)values[1];
				person.LastName = (string)values[2];
				person.BirthDate = DateTime.SpecifyKind((DateTime)values[3], DateTimeKind.Utc);
				person.DateCreated = DateTime.SpecifyKind((DateTime)values[4], DateTimeKind.Utc);
				person.DateUpdated = DateTime.SpecifyKind((DateTime)values[5], DateTimeKind.Utc);
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
		public partial class Person_AddressEntity : DBExpressionEntity
		{
			#region internals
			private DBExpressionField<int> _id;
			private DBExpressionField<int> _personId;
			private DBExpressionField<int> _addressId;
			private DBExpressionField<DateTime> _dateCreated;
			#endregion

			#region interface properties
			public DBExpressionField<int> Id { get { return _id; } }
			public DBExpressionField<int> PersonId { get { return _personId; } }
			public DBExpressionField<int> AddressId { get { return _addressId; } }
			public DBExpressionField<DateTime> DateCreated { get { return _dateCreated; } }
			#endregion

			#region constructors
			public Person_AddressEntity(string schema, string entityName) : base(schema, entityName)
			{
				_id = new DBExpressionField<int>(this, "Id", 4);
				_personId = new DBExpressionField<int>(this, "PersonId", 4);
				_addressId = new DBExpressionField<int>(this, "AddressId", 4);
				_dateCreated = new DBExpressionField<DateTime>(this, "DateCreated", 8);
			}
			#endregion

			#region methods
			public new Person_AddressEntity Correlate(string alias)
            {
                return new Person_AddressEntity(base.Schema, base.Name) { IsCorrelated = true, AliasName = alias };
            }

			public new Person_AddressEntity As(string alias)
            {
                return new Person_AddressEntity(base.Schema, base.Name) { IsAliased = true, AliasName = alias };
            }

			public Person_Address Clone(Person_Address person_Address)
			{
				return CloneUtility.DeepCopy<Person_Address>(person_Address);
			}

			public SqlExpressionBuilder<Person_Address> Query()
			{
				return dbo.GetExpressionBuilder<Person_Address>(this)
					.WithSelectExpressionProvider(this.GetInclusiveSelectExpression)
					.WithFillCallback(this.FillObject)
					.WithInsertExpressionProvider(this.GetInclusiveInsertExpression);
			}

			public DBSelectExpressionSet GetInclusiveSelectExpression()
			{
				DBSelectExpressionSet select = null;
           		select &= _id;
           		select &= _personId;
           		select &= _addressId;
           		select &= _dateCreated;
				return select;
			}

			public DBInsertExpressionSet GetInclusiveInsertExpression(Person_Address person_Address)
			{
				List<string> msg;
				if (!this.IsPersistSafe(person_Address, out msg))
				{
					throw new InvalidOperationException(string.Format("Object is not persist safe: {0}", string.Join("; ", msg)));
				}

				DBInsertExpressionSet expr = null;
				expr &= _personId.Insert(person_Address.PersonId);
				expr &= _addressId.Insert(person_Address.AddressId);
				expr &= _dateCreated.Insert(person_Address.DateCreated);
				return expr;
			}

			public DBAssignmentExpressionSet GetAssignmentExpression(Person_Address from, Person_Address to)
			{
				DBAssignmentExpressionSet expr = null;
				if (from.PersonId != to.PersonId) { expr &= _personId.Set(to.PersonId); }
				if (from.AddressId != to.AddressId) { expr &= _addressId.Set(to.AddressId); }
				return expr;
			}
		
			public void FillObject(Person_Address person_Address, object[] values)
			{
				//if the column allows null, do the dbnull check, else just cast in..???
				person_Address.Id = (int)values[0];
				person_Address.PersonId = (int)values[1];
				person_Address.AddressId = (int)values[2];
				person_Address.DateCreated = DateTime.SpecifyKind((DateTime)values[3], DateTimeKind.Utc);
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
		public partial class ProductEntity : DBExpressionEntity
		{
			#region internals
			private DBExpressionField<int> _id;
			private DBExpressionField<string> _name;
			private DBExpressionField<string> _description;
			private DBExpressionField<decimal> _price;
			private DBExpressionField<int> _quantity;
			private DBExpressionField<DateTime> _dateCreated;
			private DBExpressionField<DateTime> _dateUpdated;
			#endregion

			#region interface properties
			public DBExpressionField<int> Id { get { return _id; } }
			public DBExpressionField<string> Name { get { return _name; } }
			public DBExpressionField<string> Description { get { return _description; } }
			public DBExpressionField<decimal> Price { get { return _price; } }
			public DBExpressionField<int> Quantity { get { return _quantity; } }
			public DBExpressionField<DateTime> DateCreated { get { return _dateCreated; } }
			public DBExpressionField<DateTime> DateUpdated { get { return _dateUpdated; } }
			#endregion

			#region constructors
			public ProductEntity(string schema, string entityName) : base(schema, entityName)
			{
				_id = new DBExpressionField<int>(this, "Id", 4);
				_name = new DBExpressionField<string>(this, "Name", 80);
				_description = new DBExpressionField<string>(this, "Description", 300);
				_price = new DBExpressionField<decimal>(this, "Price", 9);
				_quantity = new DBExpressionField<int>(this, "Quantity", 4);
				_dateCreated = new DBExpressionField<DateTime>(this, "DateCreated", 8);
				_dateUpdated = new DBExpressionField<DateTime>(this, "DateUpdated", 8);
			}
			#endregion

			#region methods
			public new ProductEntity Correlate(string alias)
            {
                return new ProductEntity(base.Schema, base.Name) { IsCorrelated = true, AliasName = alias };
            }

			public new ProductEntity As(string alias)
            {
                return new ProductEntity(base.Schema, base.Name) { IsAliased = true, AliasName = alias };
            }

			public Product Clone(Product product)
			{
				return CloneUtility.DeepCopy<Product>(product);
			}

			public SqlExpressionBuilder<Product> Query()
			{
				return dbo.GetExpressionBuilder<Product>(this)
					.WithSelectExpressionProvider(this.GetInclusiveSelectExpression)
					.WithFillCallback(this.FillObject)
					.WithInsertExpressionProvider(this.GetInclusiveInsertExpression);
			}

			public DBSelectExpressionSet GetInclusiveSelectExpression()
			{
				DBSelectExpressionSet select = null;
           		select &= _id;
           		select &= _name;
           		select &= _description;
           		select &= _price;
           		select &= _quantity;
           		select &= _dateCreated;
           		select &= _dateUpdated;
				return select;
			}

			public DBInsertExpressionSet GetInclusiveInsertExpression(Product product)
			{
				List<string> msg;
				if (!this.IsPersistSafe(product, out msg))
				{
					throw new InvalidOperationException(string.Format("Object is not persist safe: {0}", string.Join("; ", msg)));
				}

				DBInsertExpressionSet expr = null;
				expr &= _name.Insert(product.Name);
				expr &= _description.Insert(product.Description);
				expr &= _price.Insert(product.Price);
				expr &= _quantity.Insert(product.Quantity);
				expr &= _dateCreated.Insert(product.DateCreated);
				expr &= _dateUpdated.Insert(product.DateUpdated);
				return expr;
			}

			public DBAssignmentExpressionSet GetAssignmentExpression(Product from, Product to)
			{
				DBAssignmentExpressionSet expr = null;
				if (from.Name != to.Name) { expr &= _name.Set(to.Name); }
				if (from.Description != to.Description) { expr &= _description.Set(to.Description); }
				if (from.Price != to.Price) { expr &= _price.Set(to.Price); }
				if (from.Quantity != to.Quantity) { expr &= _quantity.Set(to.Quantity); }
				expr &= _dateUpdated.Set(DateTime.UtcNow);
				return expr;
			}
		
			public void FillObject(Product product, object[] values)
			{
				//if the column allows null, do the dbnull check, else just cast in..???
				product.Id = (int)values[0];
				product.Name = (string)values[1];
				product.Description = (values[2] != DBNull.Value) ? (string)values[2] : default(string);
				product.Price = (decimal)values[3];
				product.Quantity = (int)values[4];
				product.DateCreated = DateTime.SpecifyKind((DateTime)values[5], DateTimeKind.Utc);
				product.DateUpdated = DateTime.SpecifyKind((DateTime)values[6], DateTimeKind.Utc);
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
		public partial class PurchaseEntity : DBExpressionEntity
		{
			#region internals
			private DBExpressionField<int> _id;
			private DBExpressionField<int> _personId;
			private DBExpressionField<int> _productId;
			private DBExpressionField<decimal> _purchasePrice;
			private DBExpressionField<DateTime> _purchaseDate;
			private DBExpressionField<DateTime> _dateCreated;
			#endregion

			#region interface properties
			public DBExpressionField<int> Id { get { return _id; } }
			public DBExpressionField<int> PersonId { get { return _personId; } }
			public DBExpressionField<int> ProductId { get { return _productId; } }
			public DBExpressionField<decimal> PurchasePrice { get { return _purchasePrice; } }
			public DBExpressionField<DateTime> PurchaseDate { get { return _purchaseDate; } }
			public DBExpressionField<DateTime> DateCreated { get { return _dateCreated; } }
			#endregion

			#region constructors
			public PurchaseEntity(string schema, string entityName) : base(schema, entityName)
			{
				_id = new DBExpressionField<int>(this, "Id", 4);
				_personId = new DBExpressionField<int>(this, "PersonId", 4);
				_productId = new DBExpressionField<int>(this, "ProductId", 4);
				_purchasePrice = new DBExpressionField<decimal>(this, "PurchasePrice", 9);
				_purchaseDate = new DBExpressionField<DateTime>(this, "PurchaseDate", 8);
				_dateCreated = new DBExpressionField<DateTime>(this, "DateCreated", 8);
			}
			#endregion

			#region methods
			public new PurchaseEntity Correlate(string alias)
            {
                return new PurchaseEntity(base.Schema, base.Name) { IsCorrelated = true, AliasName = alias };
            }

			public new PurchaseEntity As(string alias)
            {
                return new PurchaseEntity(base.Schema, base.Name) { IsAliased = true, AliasName = alias };
            }

			public Purchase Clone(Purchase purchase)
			{
				return CloneUtility.DeepCopy<Purchase>(purchase);
			}

			public SqlExpressionBuilder<Purchase> Query()
			{
				return dbo.GetExpressionBuilder<Purchase>(this)
					.WithSelectExpressionProvider(this.GetInclusiveSelectExpression)
					.WithFillCallback(this.FillObject)
					.WithInsertExpressionProvider(this.GetInclusiveInsertExpression);
			}

			public DBSelectExpressionSet GetInclusiveSelectExpression()
			{
				DBSelectExpressionSet select = null;
           		select &= _id;
           		select &= _personId;
           		select &= _productId;
           		select &= _purchasePrice;
           		select &= _purchaseDate;
           		select &= _dateCreated;
				return select;
			}

			public DBInsertExpressionSet GetInclusiveInsertExpression(Purchase purchase)
			{
				List<string> msg;
				if (!this.IsPersistSafe(purchase, out msg))
				{
					throw new InvalidOperationException(string.Format("Object is not persist safe: {0}", string.Join("; ", msg)));
				}

				DBInsertExpressionSet expr = null;
				expr &= _personId.Insert(purchase.PersonId);
				expr &= _productId.Insert(purchase.ProductId);
				expr &= _purchasePrice.Insert(purchase.PurchasePrice);
				expr &= _purchaseDate.Insert(purchase.PurchaseDate);
				expr &= _dateCreated.Insert(purchase.DateCreated);
				return expr;
			}

			public DBAssignmentExpressionSet GetAssignmentExpression(Purchase from, Purchase to)
			{
				DBAssignmentExpressionSet expr = null;
				if (from.PersonId != to.PersonId) { expr &= _personId.Set(to.PersonId); }
				if (from.ProductId != to.ProductId) { expr &= _productId.Set(to.ProductId); }
				if (from.PurchasePrice != to.PurchasePrice) { expr &= _purchasePrice.Set(to.PurchasePrice); }
				if (from.PurchaseDate != to.PurchaseDate) { expr &= _purchaseDate.Set(to.PurchaseDate); }
				return expr;
			}
		
			public void FillObject(Purchase purchase, object[] values)
			{
				//if the column allows null, do the dbnull check, else just cast in..???
				purchase.Id = (int)values[0];
				purchase.PersonId = (int)values[1];
				purchase.ProductId = (int)values[2];
				purchase.PurchasePrice = (decimal)values[3];
				purchase.PurchaseDate = DateTime.SpecifyKind((DateTime)values[4], DateTimeKind.Utc);
				purchase.DateCreated = DateTime.SpecifyKind((DateTime)values[5], DateTimeKind.Utc);
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
}
namespace HTL.MsSql.MsSqlTest.sec.DataService
{
	using Data;

	public static partial class sec
	{
		#region person
		public partial class PersonEntity : DBExpressionEntity
		{
			#region internals
			private DBExpressionField<int> _id;
			private DBExpressionField<long> _personId;
			private DBExpressionField<string> _sSN;
			private DBExpressionField<DateTime> _dateCreated;
			private DBExpressionField<DateTime> _dateUpdated;
			#endregion

			#region interface properties
			public DBExpressionField<int> Id { get { return _id; } }
			public DBExpressionField<long> PersonId { get { return _personId; } }
			public DBExpressionField<string> SSN { get { return _sSN; } }
			public DBExpressionField<DateTime> DateCreated { get { return _dateCreated; } }
			public DBExpressionField<DateTime> DateUpdated { get { return _dateUpdated; } }
			#endregion

			#region constructors
			public PersonEntity(string schema, string entityName) : base(schema, entityName)
			{
				_id = new DBExpressionField<int>(this, "Id", 4);
				_personId = new DBExpressionField<long>(this, "PersonId", 8);
				_sSN = new DBExpressionField<string>(this, "SSN", 9);
				_dateCreated = new DBExpressionField<DateTime>(this, "DateCreated", 8);
				_dateUpdated = new DBExpressionField<DateTime>(this, "DateUpdated", 8);
			}
			#endregion

			#region methods
			public new PersonEntity Correlate(string alias)
            {
                return new PersonEntity(base.Schema, base.Name) { IsCorrelated = true, AliasName = alias };
            }

			public new PersonEntity As(string alias)
            {
                return new PersonEntity(base.Schema, base.Name) { IsAliased = true, AliasName = alias };
            }

			public Person Clone(Person person)
			{
				return CloneUtility.DeepCopy<Person>(person);
			}

			public SqlExpressionBuilder<Person> Query()
			{
				return sec.GetExpressionBuilder<Person>(this)
					.WithSelectExpressionProvider(this.GetInclusiveSelectExpression)
					.WithFillCallback(this.FillObject)
					.WithInsertExpressionProvider(this.GetInclusiveInsertExpression);
			}

			public DBSelectExpressionSet GetInclusiveSelectExpression()
			{
				DBSelectExpressionSet select = null;
           		select &= _id;
           		select &= _personId;
           		select &= _sSN;
           		select &= _dateCreated;
           		select &= _dateUpdated;
				return select;
			}

			public DBInsertExpressionSet GetInclusiveInsertExpression(Person person)
			{
				List<string> msg;
				if (!this.IsPersistSafe(person, out msg))
				{
					throw new InvalidOperationException(string.Format("Object is not persist safe: {0}", string.Join("; ", msg)));
				}

				DBInsertExpressionSet expr = null;
				expr &= _personId.Insert(person.PersonId);
				expr &= _sSN.Insert(person.SSN);
				expr &= _dateCreated.Insert(person.DateCreated);
				expr &= _dateUpdated.Insert(person.DateUpdated);
				return expr;
			}

			public DBAssignmentExpressionSet GetAssignmentExpression(Person from, Person to)
			{
				DBAssignmentExpressionSet expr = null;
				if (from.PersonId != to.PersonId) { expr &= _personId.Set(to.PersonId); }
				if (from.SSN != to.SSN) { expr &= _sSN.Set(to.SSN); }
				expr &= _dateUpdated.Set(DateTime.UtcNow);
				return expr;
			}
		
			public void FillObject(Person person, object[] values)
			{
				//if the column allows null, do the dbnull check, else just cast in..???
				person.Id = (int)values[0];
				person.PersonId = (long)values[1];
				person.SSN = (string)values[2];
				person.DateCreated = DateTime.SpecifyKind((DateTime)values[3], DateTimeKind.Utc);
				person.DateUpdated = DateTime.SpecifyKind((DateTime)values[4], DateTimeKind.Utc);
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
}
