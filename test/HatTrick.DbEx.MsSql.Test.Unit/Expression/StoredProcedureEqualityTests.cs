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
            ConfigureForMsSqlVersion(version);

            var exp1 = new StoredProcedureExpression("id", "name", new dboSchemaExpression("id"));
            var exp2 = new StoredProcedureExpression("id", "name", new dboSchemaExpression("id"));

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void StoredProcedure_expressions_of_different_values_should_not_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new StoredProcedureExpression("id", "name", new dboSchemaExpression("id"));
            var exp2 = new StoredProcedureExpression("id", "name2", new dboSchemaExpression("id"));

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void StoredProcedure_expressions_of_same_values_should_have_same_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = new StoredProcedureExpression("id", "name", new dboSchemaExpression("id"));
            var exp2 = new StoredProcedureExpression("id", "name", new dboSchemaExpression("id"));

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
            ConfigureForMsSqlVersion(version);

            var exp1 = new StoredProcedureExpression("id", "name", new dboSchemaExpression("id"));
            var exp2 = new StoredProcedureExpression("id", "name2", new dboSchemaExpression("id"));

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
