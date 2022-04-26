using DbEx.dboDataService;
using DbEx.secDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Expression;
using System;
using Xunit;
using dboPersonEntity = DbEx.dboDataService.PersonEntity;
using secPersonEntity = DbEx.secDataService.PersonEntity;

namespace HatTrick.DbEx.MsSql.Test.Expression
{
    [Trait("Statement", "SELECT")]
    [Trait("Clause", "WHERE")]
    public class FilterExpressionTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_single_filter_construct_correctly(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            FilterExpression exp = sec.Person.Id > 0;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<secPersonEntity.IdField>()
                .And.Be(sec.Person.Id);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_single_filter_and_another_single_filter_construct_correctly(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            FilterExpressionSet exp = sec.Person.Id > 0 & sec.Person.SocialSecurityNumber == "XXX";

            //then
            FilterExpressionSet.FilterExpressionSetElements leftArg = (exp as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>)!.Expression;

            FilterExpression idFilter = (leftArg.Args[0] as FilterExpression)!;
            FilterExpression ssnFilter = (leftArg.Args[1] as FilterExpression)!;

            leftArg.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);

            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            idFilter.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<secPersonEntity.IdField>()
                .And.Be(sec.Person.Id);

            idFilter.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(0);

            ssnFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            ssnFilter.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<secPersonEntity.SocialSecurityNumberField>()
                .And.Be(sec.Person.SocialSecurityNumber);

            ssnFilter.RightArg
                .Should().BeOfType<LiteralExpression<string>>()
                .Which.Expression.Should().Be("XXX");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Do_three_filters_construct_correctly(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var now = DateTime.UtcNow;

            //when
            FilterExpressionSet exp = sec.Person.Id > 0 & sec.Person.SocialSecurityNumber == "XXX" & sec.Person.DateCreated != now;

            //then
            FilterExpressionSet.FilterExpressionSetElements leftArg = (exp as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>).Expression;

            FilterExpression idFilter = (leftArg.Args[0]! as FilterExpression)!;
            FilterExpression ssnFilter = (leftArg.Args[1]! as FilterExpression)!;
            FilterExpression dateCreatedFilter = (leftArg.Args[2]! as FilterExpression)!;

            leftArg.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);

            idFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            idFilter.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<secPersonEntity.IdField>()
                .And.Be(sec.Person.Id);

            idFilter.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(0);

            ssnFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            ssnFilter.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<secPersonEntity.SocialSecurityNumberField>()
                .And.Be(sec.Person.SocialSecurityNumber);

            ssnFilter.RightArg
                .Should().BeOfType<LiteralExpression<string>>()
                .Which.Expression.Should().Be("XXX");

            dateCreatedFilter.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            dateCreatedFilter.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<secPersonEntity.DateCreatedField>()
                .And.Be(sec.Person.DateCreated);

            dateCreatedFilter.RightArg
                .Should().BeOfType<LiteralExpression<DateTime>>()
                .Which.Expression.Should().Be(now);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_complex_filters_construct_correctly(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            FilterExpressionSet exp = dbo.Person.Id > 0 & dbo.Person.LastName == "Cartman" & dbo.Person.CreditLimit == 10000 & (dbo.Person.FirstName == "Kyle" | dbo.Person.LastName == "Stan") & dbo.Person.BirthDate <= DateTime.Today;

            //then
            var whereClause = exp as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>;
            var args = whereClause.Expression.Args!;

            whereClause.Expression.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);
            args.Count.Should().Be(5);

            //  dbo.Person.Id > 0
            var arg0 = (args[0] as FilterExpression)!;
            arg0.Negate.Should().BeFalse();
            arg0.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);
            arg0.LeftArg.Should().BeOfType<dboPersonEntity.IdField>();
            arg0.RightArg.Should().BeOfType<LiteralExpression<int>>().Which.Expression.Should().Be(0);

            // dbo.Person.LastName == "Cartman"
            var arg1 = (args[1] as FilterExpression)!;
            arg1.Negate.Should().BeFalse();
            arg1.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);
            arg1.LeftArg.Should().BeOfType<dboPersonEntity.LastNameField>();
            arg1.RightArg.Should().BeOfType<LiteralExpression<string>>().Which.Expression.Should().Be("Cartman");

            // dbo.Person.CreditLimit == 10000
            var arg2 = (args[2] as FilterExpression)!;
            arg2.Negate.Should().BeFalse();
            arg2.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);
            arg2.LeftArg.Should().BeOfType<dboPersonEntity.CreditLimitField>();
            arg2.RightArg.Should().BeOfType<LiteralExpression<int>>().Which.Expression.Should().Be(10000);

            // (dbo.Person.FirstName == "Kyle" | dbo.Person.LastName == "Stan")
            var arg3 = (args[3] as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>)!;
            arg3.Expression.ConditionalOperator.Should().Be(ConditionalExpressionOperator.Or);
            var arg3_0 = (arg3!.Expression.Args[0] as FilterExpression)!;
            arg3_0.Negate.Should().BeFalse();
            arg3_0.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);
            arg3_0.LeftArg.Should().BeOfType<dboPersonEntity.FirstNameField>();
            arg3_0.RightArg.Should().BeOfType<LiteralExpression<string>>().Which.Expression.Should().Be("Kyle");

            var arg3_1 = (arg3!.Expression.Args[1] as FilterExpression)!;
            arg3_1.Negate.Should().BeFalse();
            arg3_1.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);
            arg3_1.LeftArg.Should().BeOfType<dboPersonEntity.LastNameField>();
            arg3_1.RightArg.Should().BeOfType<LiteralExpression<string>>().Which.Expression.Should().Be("Stan");

            // dbo.Person.BirthDate <= DateTime.Today
            var arg4 = (args[4] as FilterExpression)!;
            arg4.Negate.Should().BeFalse();
            arg4.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);
            arg4.LeftArg.Should().BeOfType<dboPersonEntity.BirthDateField>();
            arg4.RightArg.Should().BeOfType<LiteralExpression<DateTime>>().Which.Expression.Should().Be(DateTime.Today);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_complex_filters_construct_correctly_2(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            FilterExpressionSet exp = dbo.Person.Id > 0 & !(dbo.Person.LastName == "Cartman" | !(dbo.Person.CreditLimit == 10000)) & (dbo.Person.FirstName == "Kyle" | dbo.Person.LastName == "Stan") & !(dbo.Person.BirthDate <= DateTime.Today);

            //then
            var whereClause = exp as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>;
            var andArgs = whereClause.Expression.Args!;

            whereClause.Expression.ConditionalOperator.Should().Be(ConditionalExpressionOperator.And);
            andArgs.Count.Should().Be(4);

            // dbo.Person.Id > 0
            var arg0 = (andArgs[0] as FilterExpression)!;
            arg0.Negate.Should().BeFalse();
            arg0.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);
            arg0.LeftArg.Should().BeOfType<dboPersonEntity.IdField>();
            arg0.RightArg.Should().BeOfType<LiteralExpression<int>>().Which.Expression.Should().Be(0);

            // !(dbo.Person.LastName == "Cartman" | !(dbo.Person.CreditLimit == 10000))
            var arg1 = (andArgs[1] as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>)!;
            arg1.Expression.ConditionalOperator.Should().Be(ConditionalExpressionOperator.Or);
            arg1.Expression.Negate.Should().BeTrue();
            var arg1_0 = (arg1!.Expression.Args[0] as FilterExpression)!;
            arg1_0.Negate.Should().BeFalse();
            arg1_0.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);
            arg1_0.LeftArg.Should().BeOfType<dboPersonEntity.LastNameField>();
            arg1_0.RightArg.Should().BeOfType<LiteralExpression<string>>().Which.Expression.Should().Be("Cartman");

            var arg1_1 = (arg1!.Expression.Args[1] as FilterExpression)!;
            arg1_1.Negate.Should().BeTrue();
            arg1_1.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);
            arg1_1.LeftArg.Should().BeOfType<dboPersonEntity.CreditLimitField>();
            arg1_1.RightArg.Should().BeOfType<LiteralExpression<int>>().Which.Expression.Should().Be(10000);

            // (dbo.Person.FirstName == "Kyle" | dbo.Person.LastName == "Stan")
            var arg2 = (andArgs[2] as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>)!;
            arg2.Expression.ConditionalOperator.Should().Be(ConditionalExpressionOperator.Or);
            arg2.Expression.Negate.Should().BeFalse();
            var arg2_0 = (arg2!.Expression.Args[0] as FilterExpression)!;
            arg2_0.Negate.Should().BeFalse();
            arg2_0.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);
            arg2_0.LeftArg.Should().BeOfType<dboPersonEntity.FirstNameField>();
            arg2_0.RightArg.Should().BeOfType<LiteralExpression<string>>().Which.Expression.Should().Be("Kyle");

            var arg2_1 = (arg2!.Expression.Args[1] as FilterExpression)!;
            arg2_1.Negate.Should().BeFalse();
            arg2_1.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);
            arg2_1.LeftArg.Should().BeOfType<dboPersonEntity.LastNameField>();
            arg2_1.RightArg.Should().BeOfType<LiteralExpression<string>>().Which.Expression.Should().Be("Stan");
            
            // !(dbo.Person.BirthDate <= DateTime.Today)
            var arg3 = (andArgs[3] as FilterExpression)!;
            arg3.Negate.Should().BeTrue();
            arg3.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);
            arg3.LeftArg.Should().BeOfType<dboPersonEntity.BirthDateField>();
            arg3.RightArg.Should().BeOfType<LiteralExpression<DateTime>>().Which.Expression.Should().Be(DateTime.Today);
        }
    }
}
