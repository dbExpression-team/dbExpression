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
            ConfigureForMsSqlVersion(version);

            SelectValueContinuation<MsSqlDb,int> exp1;
            UnionSelectAnyContinuation<MsSqlDb> union;
            SelectValuesContinuation<MsSqlDb,int> exp2;
            SelectSetQueryExpression expressionSet;

            //when
            exp1 = db.SelectOne(dbo.Person.Id)
               .From(dbo.Person);

            union = exp1.Union;

            exp2 = union
               .SelectMany(dbo.Address.Id)
               .From(dbo.Address);

            expressionSet = ((union as IQueryExpressionProvider)!.Expression as SelectSetQueryExpression)!;

            //then
            expressionSet.Expressions.Should().HaveCount(2);

            var first = expressionSet.Expressions.First();
            first.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<PersonEntity.IdField>();
            first.ConcatenationExpression.Should().BeOfType<UnionExpression>();
            first.SelectQueryExpression.From.Should().NotBeNull()
                .And.BeOfType<PersonEntity>();
            first.SelectQueryExpression.Top.Should().Be(1);
            exp1.Expression.Should().Be(first.SelectQueryExpression);

            var last = expressionSet.Expressions.Last();
            last.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<AddressEntity.IdField>();
            last.ConcatenationExpression.Should().BeNull();
            last.SelectQueryExpression.From.Should().NotBeNull()
                .And.BeOfType<AddressEntity>();
            last.SelectQueryExpression.Top.Should().BeNull();
            exp2.Expression.Should().Be(last.SelectQueryExpression);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_with_multiple_fields_unioned_with_select_many_result_in_valid_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            SelectDynamicContinuation<MsSqlDb> exp1;
            UnionSelectAnyContinuation<MsSqlDb> union;
            SelectDynamicsContinuation<MsSqlDb> exp2;
            SelectSetQueryExpression expressionSet;

            //when
            exp1 = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
               .From(dbo.Person);

            union = exp1.Union;

            exp2 = union
               .SelectMany(dbo.Address.Id, dbo.Address.City)
               .From(dbo.Address);

            expressionSet = ((union as IQueryExpressionProvider)!.Expression as SelectSetQueryExpression)!;

            //then
            expressionSet.Expressions.Should().HaveCount(2);

            var first = expressionSet.Expressions.First();
            first.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<PersonEntity.IdField>();
            first.SelectQueryExpression.Select.Expressions.Last().Expression.Should().BeOfType<PersonEntity.FirstNameField>();
            first.ConcatenationExpression.Should().BeOfType<UnionExpression>();
            first.SelectQueryExpression.From.Should().NotBeNull()
                .And.BeOfType<PersonEntity>();
            first.SelectQueryExpression.Top.Should().Be(1);
            exp1.Expression.Should().Be(first.SelectQueryExpression);

            var last = expressionSet.Expressions.Last();
            last.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<AddressEntity.IdField>();
            last.SelectQueryExpression.Select.Expressions.Last().Expression.Should().BeOfType<AddressEntity.CityField>();
            last.ConcatenationExpression.Should().BeNull();
            last.SelectQueryExpression.From.Should().NotBeNull()
                .And.BeOfType<AddressEntity>();
            last.SelectQueryExpression.Top.Should().BeNull();
            exp2.Expression.Should().Be(last.SelectQueryExpression);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_with_single_fields_union_all_with_select_many_result_in_valid_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            SelectValueContinuation<MsSqlDb, int> exp1;
            UnionSelectAnyContinuation<MsSqlDb> unionAll;
            SelectValuesContinuation<MsSqlDb, int> exp2;
            SelectSetQueryExpression expressionSet;

            //when
            exp1 = db.SelectOne(dbo.Person.Id)
               .From(dbo.Person);

            unionAll = exp1.UnionAll;

            exp2 = unionAll
               .SelectMany(dbo.Address.Id)
               .From(dbo.Address);

            expressionSet = ((unionAll as IQueryExpressionProvider)!.Expression as SelectSetQueryExpression)!;

            //then
            expressionSet.Expressions.Should().HaveCount(2);

            var first = expressionSet.Expressions.First();
            first.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<PersonEntity.IdField>();
            first.ConcatenationExpression.Should().BeOfType<UnionAllExpression>();
            first.SelectQueryExpression.From.Should().NotBeNull()
                .And.BeOfType<PersonEntity>();
            first.SelectQueryExpression.Top.Should().Be(1);
            exp1.Expression.Should().Be(first.SelectQueryExpression);

            var last = expressionSet.Expressions.Last();
            last.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<AddressEntity.IdField>();
            last.ConcatenationExpression.Should().BeNull();
            last.SelectQueryExpression.From.Should().NotBeNull()
                .And.BeOfType<AddressEntity>();
            last.SelectQueryExpression.Top.Should().BeNull();
            exp2.Expression.Should().Be(last.SelectQueryExpression);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_select_one_with_multiple_fields_unio_all_with_select_many_result_in_valid_expression(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            SelectDynamicContinuation<MsSqlDb> exp1;
            UnionSelectAnyContinuation<MsSqlDb> unionAll;
            SelectDynamicsContinuation<MsSqlDb> exp2;
            SelectSetQueryExpression expressionSet;

            //when
            exp1 = db.SelectOne(dbo.Person.Id, dbo.Person.FirstName)
               .From(dbo.Person);

            unionAll = exp1.UnionAll;

            exp2 = unionAll
               .SelectMany(dbo.Address.Id, dbo.Address.City)
               .From(dbo.Address);

            expressionSet = ((unionAll as IQueryExpressionProvider)!.Expression as SelectSetQueryExpression)!;

            //then
            expressionSet.Expressions.Should().HaveCount(2);

            var first = expressionSet.Expressions.First();
            first.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<PersonEntity.IdField>();
            first.SelectQueryExpression.Select.Expressions.Last().Expression.Should().BeOfType<PersonEntity.FirstNameField>();
            first.ConcatenationExpression.Should().BeOfType<UnionAllExpression>();
            first.SelectQueryExpression.From.Should().NotBeNull()
                .And.BeOfType<PersonEntity>();
            first.SelectQueryExpression.Top.Should().Be(1);
            exp1.Expression.Should().Be(first.SelectQueryExpression);

            var last = expressionSet.Expressions.Last();
            last.SelectQueryExpression.Select.Expressions.First().Expression.Should().BeOfType<AddressEntity.IdField>();
            last.SelectQueryExpression.Select.Expressions.Last().Expression.Should().BeOfType<AddressEntity.CityField>();
            last.ConcatenationExpression.Should().BeNull();
            last.SelectQueryExpression.From.Should().NotBeNull()
                .And.BeOfType<AddressEntity>();
            last.SelectQueryExpression.Top.Should().BeNull();
            exp2.Expression.Should().Be(last.SelectQueryExpression);
        }
    }
}
