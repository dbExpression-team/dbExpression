using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Expression;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql;
using DbExpression.Sql.Expression;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    public class MappingTests : ResetDatabaseNotRequired
    {
        [Fact]
        public void Can_map_nullable_enum_to_non_null_value_for_dynamic_object()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var product = db.SelectOne(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType != dbex.Null)
            .Execute();

            //then
            ((ProductCategoryType?)product!.ProductCategoryType).Should().NotBeNull();
        }

        [Fact]
        public void Can_map_nullable_enum_to_null_value_for_dynamic_object()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var product = db.SelectOne(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType == dbex.Null)
            .Execute();

            //then
            ((ProductCategoryType?)product!.ProductCategoryType).Should().BeNull();
        }

        [Fact]
        [Trait("Function", "ISNULL")]
        public void Can_map_isnull_of_nullable_enum_to_non_null_value_for_dynamic_object()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var product = db.SelectOne(
                dbo.Product.Id,
                db.fx.IsNull(dbo.Product.ProductCategoryType, ProductCategoryType.Books).As("ProductCategoryType")
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType == dbex.Null)
            .Execute();

            //then
            ((ProductCategoryType?)product!.ProductCategoryType).Should().Be(ProductCategoryType.Books);
        }

        [Fact]
        public void Can_map_enum_to_value_for_dynamic_object()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var person = db.SelectOne(
                dbo.Person.Id,
                dbo.Person.GenderType
            )
            .From(dbo.Person)
            .Where(dbo.Person.Id == 1)
            .Execute();

            //then
            ((GenderType)person!.GenderType).Should().Be(GenderType.Male);
        }

        [Fact]
        public void Can_map_nullable_enum_to_non_null_value_for_dynamic_object_list()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var products = db.SelectMany(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType != dbex.Null)
            .Execute();

            //then
            products.Select(x => (ProductCategoryType?)x.ProductCategoryType).Should().AllBeAssignableTo<ProductCategoryType>();
        }

        [Fact]
        public void Can_map_nullable_enum_to_null_value_for_dynamic_object_list()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var products = db.SelectMany(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType == dbex.Null)
            .Execute();

            //then
            products.Select(x => (ProductCategoryType?)x.ProductCategoryType).Should().Contain(x => x == null);
        }

        [Fact]
        public void Can_map_enum_to_value_for_dynamic_object_list()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var persons = db.SelectMany(
                dbo.Person.Id,
                dbo.Person.GenderType
            )
            .From(dbo.Person)
            .Execute();

            //then
            persons.Select(x => (GenderType)x.GenderType).Should().AllBeAssignableTo<GenderType>();
        }

        [Fact]
        public void Can_map_nullable_enum_to_non_null_value_for_dynamic_object_when_providing_mapping_function_to_execute()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var product = db.SelectOne(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType != dbex.Null)
            .Execute(p => {
                dynamic d = new ExpandoObject();
                d.Id = p.ReadField()!.GetValue<int>();
                d.ProductCategoryType = p.ReadField()!.GetValue<ProductCategoryType?>();
                return d;
            });

            //then
            ((ProductCategoryType?)product!.ProductCategoryType).Should().NotBeNull();
        }

        [Fact]
        public void Can_map_nullable_enum_to_null_value_for_dynamic_object_when_providing_mapping_function_to_execute()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var product = db.SelectOne(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType == dbex.Null)
            .Execute(p => {
                dynamic d = new ExpandoObject();
                d.Id = p.ReadField()!.GetValue<int>();
                d.ProductCategoryType = p.ReadField()!.GetValue<ProductCategoryType?>();
                return d;
            });

            //then
            ((ProductCategoryType?)product!.ProductCategoryType).Should().BeNull();
        }

        [Fact]
        public void Can_map_enum_to_value_for_dynamic_object_when_providing_mapping_function_to_execute()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var person = db.SelectOne(
                dbo.Person.Id,
                dbo.Person.GenderType
            )
            .From(dbo.Person)
            .Where(dbo.Person.Id == 1)
            .Execute(p => {
                dynamic d = new ExpandoObject();
                d.Id = p.ReadField()!.GetValue<int>();
                d.GenderType = p.ReadField()!.GetValue<GenderType>();
                return d;
            });

            //then
            ((GenderType)person!.GenderType).Should().Be(GenderType.Male);
        }

        [Fact]
        public void Can_map_nullable_enum_to_non_null_value_for_dynamic_object_list_when_providing_mapping_function_to_execute()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var products = db.SelectMany(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType != dbex.Null)
            .Execute(p => {
                dynamic d = new ExpandoObject();
                d.Id = p.ReadField()!.GetValue<int>();
                d.ProductCategoryType = p.ReadField()!.GetValue<ProductCategoryType?>();
                return d;
            });

            //then
            products.Select(x => (ProductCategoryType?)x.ProductCategoryType).Should().AllBeAssignableTo<ProductCategoryType>();
        }

        [Fact]
        public void Can_map_nullable_enum_to_null_value_for_dynamic_object_list_when_providing_mapping_function_to_execute()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var products = db.SelectMany(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType == dbex.Null)
            .Execute(p => {
                dynamic d = new ExpandoObject();
                d.Id = p.ReadField()!.GetValue<int>();
                d.ProductCategoryType = p.ReadField()!.GetValue<ProductCategoryType?>();
                return d;
            });

            //then
            products.Select(x => (ProductCategoryType?)x.ProductCategoryType).Should().Contain(x => x == null);
        }

        [Fact]
        public void Can_map_enum_to_value_for_dynamic_object_list_when_providing_mapping_function_to_execute()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            var persons = db.SelectMany(
                dbo.Person.Id,
                dbo.Person.GenderType
            )
            .From(dbo.Person)
            .Execute(p => {
                dynamic d = new ExpandoObject();
                d.Id = p.ReadField()!.GetValue<int>();
                d.GenderType = p.ReadField()!.GetValue<GenderType>();
                return d;
            });

            //then
            persons.Select(x => (GenderType)x.GenderType).Should().AllBeAssignableTo<GenderType>();
        }

        [Theory]
        [Trait("Operation", "INNER QUERY")]
        [InlineData(3)]
        public async Task Can_map_complex_dynamic_object_when_providing_mapping_function_to_execute(int personId)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var customer = new Customer();

            //when
            await db.SelectOne(
                    dbo.Person.Id,
                    dbo.Person.GenderType,
                    dbex.Alias<string>(nameof(Customer.MailingAddress), nameof(dbo.Address.Line1)),
                    dbex.Alias<string>(nameof(Customer.MailingAddress), nameof(dbo.Address.Line2)),
                    dbex.Alias<string>(nameof(Customer.MailingAddress), nameof(dbo.Address.City)),
                    dbex.Alias<string>(nameof(Customer.MailingAddress), nameof(dbo.Address.State)),
                    dbex.Alias<string>(nameof(Customer.MailingAddress), nameof(dbo.Address.Zip)),
                    dbex.Alias<string>(nameof(Customer.BillingAddress), nameof(dbo.Address.Line1)),
                    dbex.Alias<string>(nameof(Customer.BillingAddress), nameof(dbo.Address.Line2)),
                    dbex.Alias<string>(nameof(Customer.BillingAddress), nameof(dbo.Address.City)),
                    dbex.Alias<string>(nameof(Customer.BillingAddress), nameof(dbo.Address.State)),
                    dbex.Alias<string>(nameof(Customer.BillingAddress), nameof(dbo.Address.Zip)),
                    dbex.Alias<string>(nameof(Customer.ShippingAddress), nameof(dbo.Address.Line1)),
                    dbex.Alias<string>(nameof(Customer.ShippingAddress), nameof(dbo.Address.Line2)),
                    dbex.Alias<string>(nameof(Customer.ShippingAddress), nameof(dbo.Address.City)),
                    dbex.Alias<string>(nameof(Customer.ShippingAddress), nameof(dbo.Address.State)),
                    dbex.Alias<string>(nameof(Customer.ShippingAddress), nameof(dbo.Address.Zip))
                )
                .From(dbo.Person)
                .LeftJoin(
                    db.SelectOne(
                        dbo.PersonAddress.PersonId,
                        dbo.Address.Line1,
                        dbo.Address.Line2,
                        dbo.Address.City,
                        dbo.Address.State,
                        dbo.Address.Zip
                    )
                    .From(dbo.Address)
                    .InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                    .Where(dbo.PersonAddress.PersonId == personId & dbo.Address.AddressType == AddressType.Mailing)
                ).As(nameof(Customer.MailingAddress)).On(dbo.Person.Id == (nameof(Customer.MailingAddress), nameof(dbo.PersonAddress.PersonId)))
                .LeftJoin(
                    db.SelectOne(
                        dbo.PersonAddress.PersonId,
                        dbo.Address.Line1,
                        dbo.Address.Line2,
                        dbo.Address.City,
                        dbo.Address.State,
                        dbo.Address.Zip
                    )
                    .From(dbo.Address)
                    .InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                    .Where(dbo.PersonAddress.PersonId == personId & dbo.Address.AddressType == AddressType.Billing)
                ).As(nameof(Customer.BillingAddress)).On(dbo.Person.Id == (nameof(Customer.BillingAddress), nameof(dbo.PersonAddress.PersonId)))
                .LeftJoin(
                    db.SelectOne(
                        dbo.PersonAddress.PersonId,
                        dbo.Address.Line1,
                        dbo.Address.Line2,
                        dbo.Address.City,
                        dbo.Address.State,
                        dbo.Address.Zip
                    )
                    .From(dbo.Address)
                    .InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                    .Where(dbo.PersonAddress.PersonId == personId & dbo.Address.AddressType == AddressType.Shipping)
                ).As(nameof(Customer.ShippingAddress)).On(dbo.Person.Id == (nameof(Customer.ShippingAddress), nameof(dbo.PersonAddress.PersonId)))
                .Where(dbo.Person.Id == personId)
                .ExecuteAsync(
                    sqlRow =>
                    {
                        customer.Id = sqlRow.ReadField()!.GetValue<int>();
                        customer.Gender = sqlRow.ReadField()!.GetValue<GenderType>();
                        customer.MailingAddress.Line1 = sqlRow.ReadField()!.GetValue<string>()!;
                        customer.MailingAddress.Line2 = sqlRow.ReadField()!.GetValue<string?>();
                        customer.MailingAddress.City = sqlRow.ReadField()!.GetValue<string>()!;
                        customer.MailingAddress.State = sqlRow.ReadField()!.GetValue<string>()!;
                        customer.MailingAddress.ZIP = sqlRow.ReadField()!.GetValue<string>()!;
                        customer.BillingAddress.Line1 = sqlRow.ReadField()!.GetValue<string>()!;
                        customer.BillingAddress.Line2 = sqlRow.ReadField()!.GetValue<string?>();
                        customer.BillingAddress.City = sqlRow.ReadField()!.GetValue<string>()!;
                        customer.BillingAddress.State = sqlRow.ReadField()!.GetValue<string>()!;
                        customer.BillingAddress.ZIP = sqlRow.ReadField()!.GetValue<string>()!;
                        customer.ShippingAddress.Line1 = sqlRow.ReadField()!.GetValue<string>()!;
                        customer.ShippingAddress.Line2 = sqlRow.ReadField()!.GetValue<string?>();
                        customer.ShippingAddress.City = sqlRow.ReadField()!.GetValue<string>()!;
                        customer.ShippingAddress.State = sqlRow.ReadField()!.GetValue<string>()!;
                        customer.ShippingAddress.ZIP = sqlRow.ReadField()!.GetValue<string>()!;
                        return customer;
                    }
                );


            //then
            customer.Should().NotBeNull();
            customer.BillingAddress.Should().NotBeNull();
            customer.MailingAddress.Should().NotBeNull();
            customer.ShippingAddress.Should().NotBeNull();

            customer.Id.Should().Be(personId);
            customer.MailingAddress.State.Should().Be("CO");
            customer.BillingAddress.State.Should().Be("CO");
            customer.ShippingAddress.State.Should().BeNullOrEmpty();
        }

        private class Customer
        {
            public int Id { get; set; }
            public Address ShippingAddress { get; set; } = new Address();
            public Address MailingAddress { get; set; } = new Address();
            public Address BillingAddress { get; set; } = new Address();
            public DateTimeOffset? BirthDate { get; set; }
            public GenderType Gender { get; set; }
        }

        private class Address
        {
            public string Line1 { get; set; } = String.Empty;
            public string? Line2 { get; set; }
            public string City { get; set; } = String.Empty;
            public string State { get; set; } = String.Empty;
            public string ZIP { get; set; } = String.Empty;
        }
    }
}
