using DbEx.Data;
using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Dynamic;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public class Mapping : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_map_nullable_enum_to_non_null_value_for_dynamic_object(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var product = db.SelectOne(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType != DBNull.Value)
            .Execute();

            //then
            ((ProductCategoryType?)product.ProductCategoryType).Should().BeAssignableTo<ProductCategoryType>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_map_nullable_enum_to_null_value_for_dynamic_object(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var product = db.SelectOne(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType == DBNull.Value)
            .Execute();

            //then
            ((ProductCategoryType?)product.ProductCategoryType).Should().BeNull();
        }

        [Theory]
        [Trait("Function", "ISNULL")]
        [MsSqlVersions.AllVersions]
        public void Can_map_isnull_of_nullable_enum_to_non_null_value_for_dynamic_object(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var product = db.SelectOne(
                dbo.Product.Id,
                db.fx.IsNull(dbo.Product.ProductCategoryType, ProductCategoryType.Books).As("ProductCategoryType")
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType == DBNull.Value)
            .Execute();

            //then
            ((ProductCategoryType?)product.ProductCategoryType).Should().Be(ProductCategoryType.Books);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_map_enum_to_value_for_dynamic_object(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var person = db.SelectOne(
                dbo.Person.Id,
                dbo.Person.GenderType
            )
            .From(dbo.Person)
            .Execute();

            //then
            ((GenderType)person.GenderType).Should().BeAssignableTo<GenderType>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_map_nullable_enum_to_non_null_value_for_dynamic_object_list(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var products = db.SelectMany(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType != DBNull.Value)
            .Execute();

            //then
            products.Select(x => (ProductCategoryType?)x.ProductCategoryType).Should().AllBeAssignableTo<ProductCategoryType>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_map_nullable_enum_to_null_value_for_dynamic_object_list(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var products = db.SelectMany(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType == DBNull.Value)
            .Execute();

            //then
            products.Select(x => (ProductCategoryType?)x.ProductCategoryType).Should().Contain(x => x == null);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_map_enum_to_value_for_dynamic_object_list(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

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

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_map_nullable_enum_to_non_null_value_for_dynamic_object_when_providing_mapping_function_to_execute(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var product = db.SelectOne(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType != DBNull.Value)
            .Execute(p => {
                dynamic d = new ExpandoObject();
                d.Id = p.ReadField().GetValue<int>();
                d.ProductCategoryType = p.ReadField().GetValue<ProductCategoryType?>();
                return d;
            });

            //then
            ((ProductCategoryType?)product.ProductCategoryType).Should().BeAssignableTo<ProductCategoryType>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_map_nullable_enum_to_null_value_for_dynamic_object_when_providing_mapping_function_to_execute(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var product = db.SelectOne(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType == DBNull.Value)
            .Execute(p => {
                dynamic d = new ExpandoObject();
                d.Id = p.ReadField().GetValue<int>();
                d.ProductCategoryType = p.ReadField().GetValue<ProductCategoryType?>();
                return d;
            });

            //then
            ((ProductCategoryType?)product.ProductCategoryType).Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_map_enum_to_value_for_dynamic_object_when_providing_mapping_function_to_execute(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var person = db.SelectOne(
                dbo.Person.Id,
                dbo.Person.GenderType
            )
            .From(dbo.Person)
            .Execute(p => {
                dynamic d = new ExpandoObject();
                d.Id = p.ReadField().GetValue<int>();
                d.GenderType = p.ReadField().GetValue<GenderType>();
                return d;
            });

            //then
            ((GenderType)person.GenderType).Should().BeAssignableTo<GenderType>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_map_nullable_enum_to_non_null_value_for_dynamic_object_list_when_providing_mapping_function_to_execute(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var products = db.SelectMany(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType != DBNull.Value)
            .Execute(p => {
                dynamic d = new ExpandoObject();
                d.Id = p.ReadField().GetValue<int>();
                d.ProductCategoryType = p.ReadField().GetValue<ProductCategoryType?>();
                return d;
            });

            //then
            products.Select(x => (ProductCategoryType?)x.ProductCategoryType).Should().AllBeAssignableTo<ProductCategoryType>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_map_nullable_enum_to_null_value_for_dynamic_object_list_when_providing_mapping_function_to_execute(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var products = db.SelectMany(
                dbo.Product.Id,
                dbo.Product.ProductCategoryType
            )
            .From(dbo.Product)
            .Where(dbo.Product.ProductCategoryType == DBNull.Value)
            .Execute(p => {
                dynamic d = new ExpandoObject();
                d.Id = p.ReadField().GetValue<int>();
                d.ProductCategoryType = p.ReadField().GetValue<ProductCategoryType?>();
                return d;
            });

            //then
            products.Select(x => (ProductCategoryType?)x.ProductCategoryType).Should().Contain(x => x == null);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_map_enum_to_value_for_dynamic_object_list_when_providing_mapping_function_to_execute(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var persons = db.SelectMany(
                dbo.Person.Id,
                dbo.Person.GenderType
            )
            .From(dbo.Person)
            .Execute(p => {
                dynamic d = new ExpandoObject();
                d.Id = p.ReadField().GetValue<int>();
                d.GenderType = p.ReadField().GetValue<GenderType>();
                return d;
            });

            //then
            persons.Select(x => (GenderType)x.GenderType).Should().AllBeAssignableTo<GenderType>();
        }
    }
}
