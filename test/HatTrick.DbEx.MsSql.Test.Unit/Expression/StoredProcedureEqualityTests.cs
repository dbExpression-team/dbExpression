using DbEx.DataService;
using DbEx.dboDataService;
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
        [Theory]
        [MsSqlVersions.AllVersions]
        public void StoredProcedure_expressions_of_same_values_should_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new StoredProcedureExpression(1, "name", new dboSchemaExpression(1));
            var exp2 = new StoredProcedureExpression(1, "name", new dboSchemaExpression(1));

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void StoredProcedure_expressions_of_different_values_should_not_be_equal(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new StoredProcedureExpression(1, "name", new dboSchemaExpression(1));
            var exp2 = new StoredProcedureExpression(1, "name2", new dboSchemaExpression(1));

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void StoredProcedure_expressions_of_same_values_should_have_same_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new StoredProcedureExpression(1, "name", new dboSchemaExpression(1));
            var exp2 = new StoredProcedureExpression(1, "name", new dboSchemaExpression(1));

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void StoredProcedure_expressions_of_different_values_should_have_different_hash_codes(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            var exp1 = new StoredProcedureExpression(1, "name", new dboSchemaExpression(1));
            var exp2 = new StoredProcedureExpression(1, "name2", new dboSchemaExpression(1));

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
