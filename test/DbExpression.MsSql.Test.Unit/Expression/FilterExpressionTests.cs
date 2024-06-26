using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using v2019DbEx.secDataService;
using v2019DbEx.unit_testDataService;
using FluentAssertions;
using DbExpression.Sql.Expression;
using System;
using Xunit;
using dboPersonEntity = v2019DbEx.dboDataService.PersonEntity;
using secPersonEntity = v2019DbEx.secDataService.PersonEntity;

namespace DbExpression.MsSql.Test.Unit.Expression
{
    [Trait("Statement", "SELECT")]
    [Trait("Clause", "WHERE")]
    public class FilterExpressionTests : TestBase
    {
        [Fact]
        public void Does_single_filter_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

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

        [Fact]
        public void Does_single_filter_and_another_single_filter_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpressionSet exp = sec.Person.Id > 0 & sec.Person.SocialSecurityNumber == "XXX";

            //then
            FilterExpressionSet.FilterExpressionSetElements leftArg = (exp as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>)!.Expression!;

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

        [Fact]
        public void Do_three_filters_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var now = DateTime.UtcNow;

            //when
            FilterExpressionSet exp = sec.Person.Id > 0 & sec.Person.SocialSecurityNumber == "XXX" & sec.Person.DateCreated != now;

            //then
            FilterExpressionSet.FilterExpressionSetElements leftArg = (exp as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>).Expression!;

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

        [Fact]
        public void Does_complex_filters_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpressionSet exp = dbo.Person.Id > 0 & dbo.Person.LastName == "Cartman" & dbo.Person.CreditLimit == 10000 & (dbo.Person.FirstName == "Kyle" | dbo.Person.LastName == "Stan") & dbo.Person.BirthDate <= DateTime.Today;

            //then
            var whereClause = exp as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>;
            var args = whereClause.Expression!.Args!;

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
            arg3.Expression!.ConditionalOperator.Should().Be(ConditionalExpressionOperator.Or);
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

        [Fact]
        public void Does_complex_filters_construct_correctly_2()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpressionSet exp = dbo.Person.Id > 0 & !(dbo.Person.LastName == "Cartman" | !(dbo.Person.CreditLimit == 10000)) & (dbo.Person.FirstName == "Kyle" | dbo.Person.LastName == "Stan") & !(dbo.Person.BirthDate <= DateTime.Today);

            //then
            var whereClause = exp as IExpressionProvider<FilterExpressionSet.FilterExpressionSetElements>;
            var andArgs = whereClause.Expression!.Args!;

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
            arg1.Expression!.ConditionalOperator.Should().Be(ConditionalExpressionOperator.Or);
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
            arg2.Expression!.ConditionalOperator.Should().Be(ConditionalExpressionOperator.Or);
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

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_or_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_or_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_not_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_or_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_or_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_not_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_or_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_or_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_not_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_or_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_or_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_not_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_or_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_or_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_not_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_or_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_or_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_not_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_or_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_or_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_not_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_or_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_or_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_not_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_or_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_or_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_not_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_or_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_or_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_not_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_or_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_or_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_not_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_or_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_or_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_short_field_not_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_or_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_or_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_not_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_or_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_or_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_not_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_or_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_or_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_not_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_or_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_or_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_not_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_or_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_or_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_not_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_or_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_or_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_int_field_not_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_or_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_or_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_not_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_or_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_or_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_not_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_or_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_or_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_not_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_or_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_or_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_not_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_or_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_or_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_not_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_or_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_or_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_long_field_not_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_or_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_or_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_not_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_or_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_or_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_not_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_or_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_or_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_not_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_or_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_or_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_not_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_or_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_or_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_not_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_or_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_or_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_not_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_or_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_or_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_not_equal_to_byte_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            byte value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<byte>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_or_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_or_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_not_equal_to_short_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            short value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<short>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_or_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_or_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_not_equal_to_int_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            int value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<int>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_or_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_or_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_not_equal_to_long_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            long value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<long>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_or_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_or_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_not_equal_to_decimal_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            decimal value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<decimal>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_or_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_or_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_double_field_not_equal_to_double_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            double value = 100;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<double>>()
                .Which.Expression.Should().Be(value);
        }


        [Fact]
        public void Does_single_filter_of_DateTime_field_greater_than_DateTime_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTime value = DateTime.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTime>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_greater_than_or_equal_to_DateTime_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTime value = DateTime.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTime>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_less_than_DateTime_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTime value = DateTime.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTime>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_less_than_or_equal_to_DateTime_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTime value = DateTime.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTime>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_equal_to_DateTime_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTime value = DateTime.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTime>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_not_equal_to_DateTime_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTime value = DateTime.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTime>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_greater_than_DateTimeOffset_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTimeOffset value = DateTimeOffset.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTimeOffset>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_greater_than_or_equal_to_DateTimeOffset_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTimeOffset value = DateTimeOffset.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTimeOffset>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_less_than_DateTimeOffset_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTimeOffset value = DateTimeOffset.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTimeOffset>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_less_than_or_equal_to_DateTimeOffset_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTimeOffset value = DateTimeOffset.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTimeOffset>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_equal_to_DateTimeOffset_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTimeOffset value = DateTimeOffset.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTimeOffset>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_not_equal_to_DateTimeOffset_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTimeOffset value = DateTimeOffset.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTimeOffset>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_greater_than_DateTime_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTime value = DateTime.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTime>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_greater_than_or_equal_to_DateTime_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTime value = DateTime.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTime>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_less_than_DateTime_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTime value = DateTime.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTime>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_less_than_or_equal_to_DateTime_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTime value = DateTime.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTime>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_equal_to_DateTime_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTime value = DateTime.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTime>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_not_equal_to_DateTime_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTime value = DateTime.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTime>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_greater_than_DateTimeOffset_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTimeOffset value = DateTimeOffset.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset > value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTimeOffset>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_greater_than_or_equal_to_DateTimeOffset_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTimeOffset value = DateTimeOffset.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset >= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTimeOffset>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_less_than_DateTimeOffset_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTimeOffset value = DateTimeOffset.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset < value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTimeOffset>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_less_than_or_equal_to_DateTimeOffset_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTimeOffset value = DateTimeOffset.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset <= value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTimeOffset>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_equal_to_DateTimeOffset_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTimeOffset value = DateTimeOffset.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset == value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTimeOffset>>()
                .Which.Expression.Should().Be(value);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_not_equal_to_DateTimeOffset_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            DateTimeOffset value = DateTimeOffset.Now;

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset != value;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<LiteralExpression<DateTimeOffset>>()
                .Which.Expression.Should().Be(value);
        }


        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte > unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_or_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte >= unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte < unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_or_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte <= unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte == unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_not_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte != unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 > unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_or_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 >= unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 < unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_or_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 <= unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_short_field_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 == unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_short_field_not_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 != unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 > unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_or_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 >= unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 < unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_or_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 <= unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_int_field_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 == unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_int_field_not_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 != unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 > unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_or_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 >= unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 < unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_or_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 <= unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_long_field_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 == unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_long_field_not_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 != unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal > unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_or_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal >= unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal < unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_or_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal <= unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal == unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_not_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal != unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double > unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_or_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double >= unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double < unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_or_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double <= unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_double_field_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double == unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_double_field_not_equal_to_byte_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double != unit_test.ExpressionElementType.Byte;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte > unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_or_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte >= unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte < unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_or_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte <= unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte == unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_not_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte != unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 > unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_or_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 >= unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 < unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_or_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 <= unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_short_field_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 == unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_short_field_not_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 != unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 > unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_or_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 >= unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 < unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_or_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 <= unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_int_field_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 == unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_int_field_not_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 != unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 > unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_or_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 >= unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 < unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_or_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 <= unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_long_field_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 == unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_long_field_not_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 != unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal > unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_or_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal >= unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal < unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_or_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal <= unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal == unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_not_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal != unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double > unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_or_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double >= unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double < unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_or_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double <= unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_double_field_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double == unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_double_field_not_equal_to_short_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double != unit_test.ExpressionElementType.Int16;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte > unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_or_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte >= unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte < unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_or_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte <= unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte == unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_not_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte != unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 > unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_or_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 >= unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 < unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_or_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 <= unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_short_field_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 == unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_short_field_not_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 != unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 > unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_or_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 >= unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 < unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_or_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 <= unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_int_field_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 == unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_int_field_not_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 != unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 > unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_or_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 >= unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 < unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_or_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 <= unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_long_field_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 == unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_long_field_not_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 != unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal > unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_or_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal >= unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal < unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_or_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal <= unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal == unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_not_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal != unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double > unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_or_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double >= unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double < unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_or_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double <= unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_double_field_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double == unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_double_field_not_equal_to_int_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double != unit_test.ExpressionElementType.Int32;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte > unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_or_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte >= unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte < unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_or_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte <= unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte == unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_not_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte != unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 > unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_or_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 >= unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 < unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_or_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 <= unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_short_field_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 == unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_short_field_not_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 != unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 > unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_or_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 >= unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 < unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_or_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 <= unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_int_field_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 == unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_int_field_not_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 != unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 > unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_or_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 >= unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 < unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_or_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 <= unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_long_field_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 == unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_long_field_not_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 != unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal > unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_or_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal >= unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal < unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_or_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal <= unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal == unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_not_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal != unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double > unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_or_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double >= unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double < unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_or_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double <= unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_double_field_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double == unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_double_field_not_equal_to_long_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double != unit_test.ExpressionElementType.Int64;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte > unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_or_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte >= unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte < unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_or_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte <= unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte == unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_not_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte != unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 > unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_or_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 >= unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 < unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_or_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 <= unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_short_field_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 == unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_short_field_not_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 != unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 > unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_or_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 >= unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 < unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_or_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 <= unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_int_field_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 == unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_int_field_not_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 != unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 > unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_or_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 >= unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 < unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_or_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 <= unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_long_field_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 == unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_long_field_not_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 != unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal > unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_or_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal >= unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal < unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_or_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal <= unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal == unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_not_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal != unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double > unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_or_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double >= unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double < unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_or_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double <= unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_double_field_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double == unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_double_field_not_equal_to_decimal_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double != unit_test.ExpressionElementType.Decimal;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte > unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_greater_than_or_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte >= unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte < unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_less_than_or_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte <= unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte == unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_byte_field_not_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Byte != unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.ByteField>()
                .And.Be(unit_test.ExpressionElementType.Byte);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 > unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_short_field_greater_than_or_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 >= unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 < unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_short_field_less_than_or_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 <= unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_short_field_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 == unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_short_field_not_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int16 != unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int16Field>()
                .And.Be(unit_test.ExpressionElementType.Int16);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 > unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_int_field_greater_than_or_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 >= unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 < unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_int_field_less_than_or_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 <= unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_int_field_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 == unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_int_field_not_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int32 != unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int32Field>()
                .And.Be(unit_test.ExpressionElementType.Int32);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 > unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_long_field_greater_than_or_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 >= unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 < unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_long_field_less_than_or_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 <= unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_long_field_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 == unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_long_field_not_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Int64 != unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.Int64Field>()
                .And.Be(unit_test.ExpressionElementType.Int64);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal > unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_greater_than_or_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal >= unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal < unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_less_than_or_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal <= unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal == unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_decimal_field_not_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Decimal != unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DecimalField>()
                .And.Be(unit_test.ExpressionElementType.Decimal);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double > unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_double_field_greater_than_or_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double >= unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double < unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_double_field_less_than_or_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double <= unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_double_field_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double == unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }

        [Fact]
        public void Does_single_filter_of_double_field_not_equal_to_double_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.Double != unit_test.ExpressionElementType.Double;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DoubleField>()
                .And.Be(unit_test.ExpressionElementType.Double);
        }


        [Fact]
        public void Does_single_filter_of_DateTime_field_greater_than_DateTime_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime > unit_test.ExpressionElementType.DateTime;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_greater_than_or_equal_to_DateTime_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime >= unit_test.ExpressionElementType.DateTime;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_less_than_DateTime_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime < unit_test.ExpressionElementType.DateTime;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_less_than_or_equal_to_DateTime_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime <= unit_test.ExpressionElementType.DateTime;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_equal_to_DateTime_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime == unit_test.ExpressionElementType.DateTime;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_not_equal_to_DateTime_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime != unit_test.ExpressionElementType.DateTime;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_greater_than_DateTime_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset > unit_test.ExpressionElementType.DateTime;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_greater_than_or_equal_to_DateTime_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset >= unit_test.ExpressionElementType.DateTime;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_less_than_DateTime_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset < unit_test.ExpressionElementType.DateTime;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_less_than_or_equal_to_DateTime_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset <= unit_test.ExpressionElementType.DateTime;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_equal_to_DateTime_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset == unit_test.ExpressionElementType.DateTime;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_not_equal_to_DateTime_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset != unit_test.ExpressionElementType.DateTime;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_greater_than_DateTimeOffset_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime > unit_test.ExpressionElementType.DateTimeOffset;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_greater_than_or_equal_to_DateTimeOffset_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime >= unit_test.ExpressionElementType.DateTimeOffset;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_less_than_DateTimeOffset_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime < unit_test.ExpressionElementType.DateTimeOffset;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_less_than_or_equal_to_DateTimeOffset_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime <= unit_test.ExpressionElementType.DateTimeOffset;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_equal_to_DateTimeOffset_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime == unit_test.ExpressionElementType.DateTimeOffset;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);
        }

        [Fact]
        public void Does_single_filter_of_DateTime_field_not_equal_to_DateTimeOffset_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTime != unit_test.ExpressionElementType.DateTimeOffset;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeField>()
                .And.Be(unit_test.ExpressionElementType.DateTime);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_greater_than_DateTimeOffset_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset > unit_test.ExpressionElementType.DateTimeOffset;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_greater_than_or_equal_to_DateTimeOffset_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset >= unit_test.ExpressionElementType.DateTimeOffset;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.GreaterThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_less_than_DateTimeOffset_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset < unit_test.ExpressionElementType.DateTimeOffset;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThan);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_less_than_or_equal_to_DateTimeOffset_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset <= unit_test.ExpressionElementType.DateTimeOffset;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.LessThanOrEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_equal_to_DateTimeOffset_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset == unit_test.ExpressionElementType.DateTimeOffset;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.Equal);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);
        }

        [Fact]
        public void Does_single_filter_of_DateTimeOffset_field_not_equal_to_DateTimeOffset_field_construct_correctly()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when
            FilterExpression exp = unit_test.ExpressionElementType.DateTimeOffset != unit_test.ExpressionElementType.DateTimeOffset;

            //then
            exp.ExpressionOperator.Should().Be(FilterExpressionOperator.NotEqual);

            exp.LeftArg
                .Should().NotBeNull()
                .And.BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);

            exp.RightArg
                .Should().BeOfType<ExpressionElementTypeEntity.DateTimeOffsetField>()
                .And.Be(unit_test.ExpressionElementType.DateTimeOffset);
        }

    }
}
