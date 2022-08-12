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
    public class SelectExpressionSetBuilderTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_with_single_fields_unioned_with_select_many_result_in_valid_expression(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            SelectValuesContinuation<MsSqlDb,int> builder;
            SelectSetQueryExpression expressionSet;

            //when
            builder = db.SelectOne(dbo.Person.Id)
               .From(dbo.Person)
               .Union()
               .SelectMany(dbo.Address.Id)
               .From(dbo.Address);
            
            expressionSet = (((builder as SelectValuesSelectQueryExpressionBuilder<MsSqlDb, int>)!.Controller as IQueryExpressionProvider)!.Expression as SelectSetQueryExpression)!;

            //then
            expressionSet.Expressions.Should().HaveCount(2);

            var first = expressionSet.Expressions.First();
            first.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<PersonEntity.IdField>();
            first.ConcatenationExpression.Should().BeOfType<UnionExpression>();
            first.SelectQueryExpression.From!.Expression.Should().NotBeNull()
                .And.BeOfType<PersonEntity>();
            first.SelectQueryExpression.Top.Should().Be(1);

            var last = expressionSet.Expressions.Last();
            last.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<AddressEntity.IdField>();
            last.ConcatenationExpression.Should().BeNull();
            last.SelectQueryExpression.From!.Expression.Should().NotBeNull()
                .And.BeOfType<AddressEntity>();
            last.SelectQueryExpression.Top.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_with_multiple_fields_unioned_with_select_many_result_in_valid_expression(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            SelectDynamicsContinuation<MsSqlDb> exp;
            SelectSetQueryExpression expressionSet;

            //when
            exp = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
               .From(dbo.Person)
               .Union()
               .SelectMany(dbo.Address.Id, dbo.Address.City)
               .From(dbo.Address);

            expressionSet = (((exp as SelectDynamicsSelectQueryExpressionBuilder<MsSqlDb>)!.Controller as IQueryExpressionProvider)!.Expression as SelectSetQueryExpression)!;

            //then
            expressionSet.Expressions.Should().HaveCount(2);

            var first = expressionSet.Expressions.First();
            first.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<PersonEntity.IdField>();
            first.SelectQueryExpression.Select.Expressions.Last().Expression.Should().BeOfType<PersonEntity.FirstNameField>();
            first.ConcatenationExpression.Should().BeOfType<UnionExpression>();
            first.SelectQueryExpression.From!.Expression.Should().NotBeNull()
                .And.BeOfType<PersonEntity>();
            first.SelectQueryExpression.Top.Should().Be(1);

            var last = expressionSet.Expressions.Last();
            last.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<AddressEntity.IdField>();
            last.SelectQueryExpression.Select.Expressions.Last().Expression.Should().BeOfType<AddressEntity.CityField>();
            last.ConcatenationExpression.Should().BeNull();
            last.SelectQueryExpression.From!.Expression.Should().NotBeNull()
                .And.BeOfType<AddressEntity>();
            last.SelectQueryExpression.Top.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_with_single_fields_union_all_with_select_many_result_in_valid_expression(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            SelectValuesContinuation<MsSqlDb, int> exp;
            SelectSetQueryExpression expressionSet;

            //when
            exp = db.SelectOne(dbo.Person.Id)
               .From(dbo.Person)
               .UnionAll().SelectMany(dbo.Address.Id)
               .From(dbo.Address);

            expressionSet = (((exp as SelectValuesSelectQueryExpressionBuilder<MsSqlDb, int>)!.Controller as IQueryExpressionProvider)!.Expression as SelectSetQueryExpression)!;

            //then
            expressionSet.Expressions.Should().HaveCount(2);

            var first = expressionSet.Expressions.First();
            first.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<PersonEntity.IdField>();
            first.ConcatenationExpression.Should().BeOfType<UnionAllExpression>();
            first.SelectQueryExpression.From!.Expression.Should().NotBeNull()
                .And.BeOfType<PersonEntity>();
            first.SelectQueryExpression.Top.Should().Be(1);

            var last = expressionSet.Expressions.Last();
            last.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<AddressEntity.IdField>();
            last.ConcatenationExpression.Should().BeNull();
            last.SelectQueryExpression.From!.Expression.Should().NotBeNull()
                .And.BeOfType<AddressEntity>();
            last.SelectQueryExpression.Top.Should().BeNull();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_with_multiple_fields_union_all_with_select_many_result_in_valid_expression(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);

            SelectDynamicsContinuation<MsSqlDb> builder;
            SelectSetQueryExpression expressionSet;

            //when
            builder = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
               .From(dbo.Person)
               .UnionAll()
               .SelectMany(dbo.Address.Id, dbo.Address.City)
               .From(dbo.Address);

            var x = (builder as SelectDynamicsSelectQueryExpressionBuilder<MsSqlDb>)!.Controller;
            var y = (x as IQueryExpressionProvider)!.Expression;
            expressionSet = (((builder as SelectDynamicsSelectQueryExpressionBuilder<MsSqlDb>)!.Controller as IQueryExpressionProvider)!.Expression as SelectSetQueryExpression)!;

            //then
            expressionSet.Expressions.Should().HaveCount(2);

            var first = expressionSet.Expressions.First();
            first.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<PersonEntity.IdField>();
            first.SelectQueryExpression.Select.Expressions.Last().Expression.Should().BeOfType<PersonEntity.FirstNameField>();
            first.ConcatenationExpression.Should().BeOfType<UnionAllExpression>();
            first.SelectQueryExpression.From!.Expression.Should().NotBeNull()
                .And.BeOfType<PersonEntity>();
            first.SelectQueryExpression.Top.Should().Be(1);

            var last = expressionSet.Expressions.Last();
            last.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<AddressEntity.IdField>();
            last.SelectQueryExpression.Select.Expressions.Last().Expression.Should().BeOfType<AddressEntity.CityField>();
            last.ConcatenationExpression.Should().BeNull();
            last.SelectQueryExpression.From!.Expression.Should().NotBeNull()
                .And.BeOfType<AddressEntity>();
            last.SelectQueryExpression.Top.Should().BeNull();
        }
    }
}
