using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Expression
{
    public class StoredProcedureExpressionSetEqualityTests : TestBase
    {
        [Fact]
        public void StoredProcedure_expressions_of_same_values_should_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new StoredProcedureExpression(1, "name", new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression)));
            var exp2 = new StoredProcedureExpression(1, "name", new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression)));

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Fact]
        public void StoredProcedure_expressions_of_different_values_should_not_be_equal()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new StoredProcedureExpression(1, "name", new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression)));
            var exp2 = new StoredProcedureExpression(1, "name2", new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression)));

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Fact]
        public void StoredProcedure_expressions_of_same_values_should_have_same_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new StoredProcedureExpression(1, "name", new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression)));
            var exp2 = new StoredProcedureExpression(1, "name", new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression)));

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Fact]
        public void StoredProcedure_expressions_of_different_values_should_have_different_hash_codes()
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            var exp1 = new StoredProcedureExpression(1, "name", new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression)));
            var exp2 = new StoredProcedureExpression(1, "name2", new dboSchemaExpression(1, "dbo", typeof(dboSchemaExpression)));

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
