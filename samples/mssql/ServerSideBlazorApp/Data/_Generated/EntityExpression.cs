
namespace ServerSideBlazorApp.dboDataService
{
    using ServerSideBlazorApp.dboData;
    using ServerSideBlazorApp.Data;
    using HatTrick.DbEx.Sql.Executor;
    using HatTrick.DbEx.Sql.Expression;
    using System;

    #region address
    public partial class AddressEntity : EntityExpression<Address>
    {
        #region interface properties
		public Int32FieldExpression<Address> Id { get; private set; }
		public NullableEnumFieldExpression<Address, AddressType> AddressType { get; private set; }
		public StringFieldExpression<Address> Line1 { get; private set; }
		public StringFieldExpression<Address> Line2 { get; private set; }
		public StringFieldExpression<Address> City { get; private set; }
		public StringFieldExpression<Address> State { get; private set; }
		public StringFieldExpression<Address> Zip { get; private set; }
		public DateTimeFieldExpression<Address> DateCreated { get; private set; }
		public DateTimeFieldExpression<Address> DateUpdated { get; private set; }
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
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<Address>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.AddressType", AddressType = new NullableEnumFieldExpression<Address, AddressType>($"{identifier}.AddressType", this));
            Fields.Add($"{identifier}.Line1", Line1 = new StringFieldExpression<Address>($"{identifier}.Line1", this));
            Fields.Add($"{identifier}.Line2", Line2 = new StringFieldExpression<Address>($"{identifier}.Line2", this));
            Fields.Add($"{identifier}.City", City = new StringFieldExpression<Address>($"{identifier}.City", this));
            Fields.Add($"{identifier}.State", State = new StringFieldExpression<Address>($"{identifier}.State", this));
            Fields.Add($"{identifier}.Zip", Zip = new StringFieldExpression<Address>($"{identifier}.Zip", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateTimeFieldExpression<Address>($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateTimeFieldExpression<Address>($"{identifier}.DateUpdated", this));
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
        #region interface properties
		public Int32FieldExpression<Person> Id { get; private set; }
		public StringFieldExpression<Person> FirstName { get; private set; }
		public StringFieldExpression<Person> LastName { get; private set; }
		public NullableDateTimeFieldExpression<Person> BirthDate { get; private set; }
		public EnumFieldExpression<Person, GenderType> GenderType { get; private set; }
		public NullableInt32FieldExpression<Person> CreditLimit { get; private set; }
		public NullableInt32FieldExpression<Person> YearOfLastCreditLimitReview { get; private set; }
		public DateTimeFieldExpression<Person> DateCreated { get; private set; }
		public DateTimeFieldExpression<Person> DateUpdated { get; private set; }
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
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<Person>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.FirstName", FirstName = new StringFieldExpression<Person>($"{identifier}.FirstName", this));
            Fields.Add($"{identifier}.LastName", LastName = new StringFieldExpression<Person>($"{identifier}.LastName", this));
            Fields.Add($"{identifier}.BirthDate", BirthDate = new NullableDateTimeFieldExpression<Person>($"{identifier}.BirthDate", this));
            Fields.Add($"{identifier}.GenderType", GenderType = new EnumFieldExpression<Person, GenderType>($"{identifier}.GenderType", this));
            Fields.Add($"{identifier}.CreditLimit", CreditLimit = new NullableInt32FieldExpression<Person>($"{identifier}.CreditLimit", this));
            Fields.Add($"{identifier}.YearOfLastCreditLimitReview", YearOfLastCreditLimitReview = new NullableInt32FieldExpression<Person>($"{identifier}.YearOfLastCreditLimitReview", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateTimeFieldExpression<Person>($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateTimeFieldExpression<Person>($"{identifier}.DateUpdated", this));
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
        #region interface properties
		public Int32FieldExpression<PersonAddress> Id { get; private set; }
		public Int32FieldExpression<PersonAddress> PersonId { get; private set; }
		public Int32FieldExpression<PersonAddress> AddressId { get; private set; }
		public DateTimeFieldExpression<PersonAddress> DateCreated { get; private set; }
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
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<PersonAddress>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.PersonId", PersonId = new Int32FieldExpression<PersonAddress>($"{identifier}.PersonId", this));
            Fields.Add($"{identifier}.AddressId", AddressId = new Int32FieldExpression<PersonAddress>($"{identifier}.AddressId", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateTimeFieldExpression<PersonAddress>($"{identifier}.DateCreated", this));
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
        #region interface properties
		public Int32FieldExpression<Product> Id { get; private set; }
		public NullableEnumFieldExpression<Product, ProductCategoryType> ProductCategoryType { get; private set; }
		public StringFieldExpression<Product> Name { get; private set; }
		public StringFieldExpression<Product> Description { get; private set; }
		public DecimalFieldExpression<Product> ListPrice { get; private set; }
		public DecimalFieldExpression<Product> Price { get; private set; }
		public Int32FieldExpression<Product> Quantity { get; private set; }
		public DateTimeFieldExpression<Product> DateCreated { get; private set; }
		public DateTimeFieldExpression<Product> DateUpdated { get; private set; }
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
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<Product>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.ProductCategoryType", ProductCategoryType = new NullableEnumFieldExpression<Product, ProductCategoryType>($"{identifier}.ProductCategoryType", this));
            Fields.Add($"{identifier}.Name", Name = new StringFieldExpression<Product>($"{identifier}.Name", this));
            Fields.Add($"{identifier}.Description", Description = new StringFieldExpression<Product>($"{identifier}.Description", this));
            Fields.Add($"{identifier}.ListPrice", ListPrice = new DecimalFieldExpression<Product>($"{identifier}.ListPrice", this));
            Fields.Add($"{identifier}.Price", Price = new DecimalFieldExpression<Product>($"{identifier}.Price", this));
            Fields.Add($"{identifier}.Quantity", Quantity = new Int32FieldExpression<Product>($"{identifier}.Quantity", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateTimeFieldExpression<Product>($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateTimeFieldExpression<Product>($"{identifier}.DateUpdated", this));
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
        #region interface properties
		public Int32FieldExpression<Purchase> Id { get; private set; }
		public Int32FieldExpression<Purchase> PersonId { get; private set; }
		public DecimalFieldExpression<Purchase> TotalPurchaseAmount { get; private set; }
		public DateTimeFieldExpression<Purchase> PurchaseDate { get; private set; }
		public NullableDateTimeFieldExpression<Purchase> ShipDate { get; private set; }
		public NullableDateTimeFieldExpression<Purchase> ExpectedDeliveryDate { get; private set; }
		public NullableGuidFieldExpression<Purchase> TrackingIdentifier { get; private set; }
		public EnumFieldExpression<Purchase, PaymentMethodType> PaymentMethodType { get; private set; }
		public DateTimeFieldExpression<Purchase> DateCreated { get; private set; }
		public DateTimeFieldExpression<Purchase> DateUpdated { get; private set; }
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
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<Purchase>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.PersonId", PersonId = new Int32FieldExpression<Purchase>($"{identifier}.PersonId", this));
            Fields.Add($"{identifier}.TotalPurchaseAmount", TotalPurchaseAmount = new DecimalFieldExpression<Purchase>($"{identifier}.TotalPurchaseAmount", this));
            Fields.Add($"{identifier}.PurchaseDate", PurchaseDate = new DateTimeFieldExpression<Purchase>($"{identifier}.PurchaseDate", this));
            Fields.Add($"{identifier}.ShipDate", ShipDate = new NullableDateTimeFieldExpression<Purchase>($"{identifier}.ShipDate", this));
            Fields.Add($"{identifier}.ExpectedDeliveryDate", ExpectedDeliveryDate = new NullableDateTimeFieldExpression<Purchase>($"{identifier}.ExpectedDeliveryDate", this));
            Fields.Add($"{identifier}.TrackingIdentifier", TrackingIdentifier = new NullableGuidFieldExpression<Purchase>($"{identifier}.TrackingIdentifier", this));
            Fields.Add($"{identifier}.PaymentMethodType", PaymentMethodType = new EnumFieldExpression<Purchase, PaymentMethodType>($"{identifier}.PaymentMethodType", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateTimeFieldExpression<Purchase>($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateTimeFieldExpression<Purchase>($"{identifier}.DateUpdated", this));
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
        #region interface properties
		public Int32FieldExpression<PurchaseLine> Id { get; private set; }
		public Int32FieldExpression<PurchaseLine> PurchaseId { get; private set; }
		public Int32FieldExpression<PurchaseLine> ProductId { get; private set; }
		public DecimalFieldExpression<PurchaseLine> PurchasePrice { get; private set; }
		public Int32FieldExpression<PurchaseLine> Quantity { get; private set; }
		public DateTimeFieldExpression<PurchaseLine> DateCreated { get; private set; }
		public DateTimeFieldExpression<PurchaseLine> DateUpdated { get; private set; }
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
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<PurchaseLine>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.PurchaseId", PurchaseId = new Int32FieldExpression<PurchaseLine>($"{identifier}.PurchaseId", this));
            Fields.Add($"{identifier}.ProductId", ProductId = new Int32FieldExpression<PurchaseLine>($"{identifier}.ProductId", this));
            Fields.Add($"{identifier}.PurchasePrice", PurchasePrice = new DecimalFieldExpression<PurchaseLine>($"{identifier}.PurchasePrice", this));
            Fields.Add($"{identifier}.Quantity", Quantity = new Int32FieldExpression<PurchaseLine>($"{identifier}.Quantity", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateTimeFieldExpression<PurchaseLine>($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateTimeFieldExpression<PurchaseLine>($"{identifier}.DateUpdated", this));
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
        #region interface properties
		public Int32FieldExpression<PersonTotalPurchasesView> Id { get; private set; }
		public NullableDecimalFieldExpression<PersonTotalPurchasesView> TotalPurchases { get; private set; }
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
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<PersonTotalPurchasesView>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.TotalPurchases", TotalPurchases = new NullableDecimalFieldExpression<PersonTotalPurchasesView>($"{identifier}.TotalPurchases", this));
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
namespace ServerSideBlazorApp.secDataService
{
    using ServerSideBlazorApp.secData;
    using ServerSideBlazorApp.Data;
    using HatTrick.DbEx.Sql.Executor;
    using HatTrick.DbEx.Sql.Expression;
    using System;

    #region person
    public partial class PersonEntity : EntityExpression<Person>
    {
        #region interface properties
		public Int32FieldExpression<Person> Id { get; private set; }
		public StringFieldExpression<Person> SSN { get; private set; }
		public DateTimeFieldExpression<Person> DateCreated { get; private set; }
		public DateTimeFieldExpression<Person> DateUpdated { get; private set; }
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
            Fields.Add($"{identifier}.Id", Id = new Int32FieldExpression<Person>($"{identifier}.Id", this));
            Fields.Add($"{identifier}.SSN", SSN = new StringFieldExpression<Person>($"{identifier}.SSN", this));
            Fields.Add($"{identifier}.DateCreated", DateCreated = new DateTimeFieldExpression<Person>($"{identifier}.DateCreated", this));
            Fields.Add($"{identifier}.DateUpdated", DateUpdated = new DateTimeFieldExpression<Person>($"{identifier}.DateUpdated", this));
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