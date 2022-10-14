using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using Xunit;
using System.Linq;
using HatTrick.DbEx.Sql;

namespace HatTrick.DbEx.MsSql.Test.Unit.Builder
{
    [Trait("Statement", "SELECT")]
    [Trait("Operation", "UNION")]
    public class ContinuationExpressionTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_with_single_fields_unioned_with_select_many_result_in_valid_expression(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            SelectValuesContinuation<MsSqlDb, int> builder;
            SelectValuesSelectQueryExpressionBuilder<MsSqlDb, int> concreteBuilder;
            SelectQueryExpression select;

            //when
            builder = db.SelectOne(dbo.Person.Id)
               .From(dbo.Person)
               .Union()
               .SelectMany(dbo.Address.Id)
               .From(dbo.Address);

            concreteBuilder = (builder as SelectValuesSelectQueryExpressionBuilder<MsSqlDb, int>)!;
            select = concreteBuilder.SelectQueryExpression!;

            //then
            select.ContinuationExpression.Should().NotBeNull();

            var continuation = select.ContinuationExpression!.ContinuationExpression;
            continuation.Should().BeOfType<UnionExpression>();

            var expression = (select.ContinuationExpression.Expression as SelectQueryExpression)!;
            expression.Select.Expressions.First().Expression.Should().BeOfType<AddressEntity.IdField>();
            expression.ContinuationExpression.Should().BeNull();
            expression.From!.Expression.Should().NotBeNull()
                .And.BeOfType<AddressEntity>();
            expression.Top.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_with_multiple_fields_unioned_with_select_many_result_in_valid_expression(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            SelectDynamicsContinuation<MsSqlDb> builder;
            SelectQueryExpression select;

            //when
            builder = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
               .From(dbo.Person)
               .Union()
               .SelectMany(dbo.Address.Id, dbo.Address.City)
               .From(dbo.Address);

            select = (builder as SelectDynamicsSelectQueryExpressionBuilder<MsSqlDb>)!.SelectQueryExpression!;

            //then
            select.ContinuationExpression.Should().NotBeNull();
            select.Select.Expressions.First().Expression.Should().BeOfType<PersonEntity.IdField>();
            select.Select.Expressions.Last().Expression.Should().BeOfType<PersonEntity.FirstNameField>();
            select.From!.Expression.Should().NotBeNull()
                .And.BeOfType<PersonEntity>();

            var continuation = select.ContinuationExpression!.ContinuationExpression;
            continuation.Should().BeOfType<UnionExpression>();

            var expression = (select.ContinuationExpression.Expression as SelectQueryExpression)!;
            expression.Select.Expressions.First().Expression.Should().BeOfType<AddressEntity.IdField>();
            expression.Select.Expressions.Last().Expression.Should().BeOfType<AddressEntity.CityField>();
            expression.ContinuationExpression.Should().BeNull();
            expression.From!.Expression.Should().NotBeNull()
                .And.BeOfType<AddressEntity>();
            expression.Top.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_with_single_fields_union_all_with_select_many_result_in_valid_expression(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            SelectValuesContinuation<MsSqlDb, int> builder;
            SelectQueryExpression select;

            //when
            builder = db.SelectOne(dbo.Person.Id)
               .From(dbo.Person)
               .UnionAll().SelectMany(dbo.Address.Id)
               .From(dbo.Address);

            select = (builder as SelectValuesSelectQueryExpressionBuilder<MsSqlDb, int>)!.SelectQueryExpression!;

            //then
            select.ContinuationExpression.Should().NotBeNull();
            select.ContinuationExpression.Should().NotBeNull();
            select.Select.Expressions.Single().Expression.Should().BeOfType<PersonEntity.IdField>();
            select.From!.Expression.Should().NotBeNull()
                .And.BeOfType<PersonEntity>();

            var continuation = select.ContinuationExpression!.ContinuationExpression;
            continuation.Should().BeOfType<UnionAllExpression>();

            var expression = (select.ContinuationExpression.Expression as SelectQueryExpression)!;
            expression.Select.Expressions.Single().Expression.Should().BeOfType<AddressEntity.IdField>();
            expression.ContinuationExpression.Should().BeNull();
            expression.From!.Expression.Should().NotBeNull()
                .And.BeOfType<AddressEntity>();
            expression.Top.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_with_multiple_fields_union_all_with_select_many_result_in_valid_expression(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            SelectDynamicsContinuation<MsSqlDb> builder;
            SelectQueryExpression select;

            //when
            builder = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
               .From(dbo.Person)
               .UnionAll()
               .SelectMany(dbo.Address.Id, dbo.Address.City)
               .From(dbo.Address);

            select = (builder as SelectDynamicsSelectQueryExpressionBuilder<MsSqlDb>)!.SelectQueryExpression!;

            //then
            select.ContinuationExpression.Should().NotBeNull();
            select.Select.Expressions.First().Expression.Should().BeOfType<PersonEntity.IdField>();
            select.Select.Expressions.Last().Expression.Should().BeOfType<PersonEntity.FirstNameField>();
            select.From!.Expression.Should().NotBeNull()
                .And.BeOfType<PersonEntity>();

            var continuation = select.ContinuationExpression!;
            continuation.ContinuationExpression.Should().BeOfType<UnionAllExpression>();

            var expression = (continuation.Expression as SelectQueryExpression)!;
            expression.Select.Expressions.First().Expression.Should().BeOfType<AddressEntity.IdField>();
            expression.Select.Expressions.Last().Expression.Should().BeOfType<AddressEntity.CityField>();
            expression.ContinuationExpression.Should().BeNull();
            expression.From!.Expression.Should().NotBeNull()
                .And.BeOfType<AddressEntity>();
            expression.Top.Should().BeNull();
        }
    }
}
