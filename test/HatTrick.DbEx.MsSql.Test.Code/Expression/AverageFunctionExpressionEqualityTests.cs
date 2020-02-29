using DbEx.DataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Expression
{
    public class AverageFunctionExpressionEqualityTests : TestBase
    {
        [Theory]
        [InlineData(2014)]
        public void Average_functions_of_person_id_should_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var exp1 = db.fx.Avg(dbo.Person.Id);
            var exp2 = db.fx.Avg(dbo.Person.Id);

            //then
            Assert.True(exp1.Equals(exp2));
        }

        [Theory]
        [InlineData(2014)]
        public void Average_functions_of_person_id_with_one_aliased_should_not_be_equal(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when
            var exp1 = db.fx.Avg(dbo.Person.Id);
            var exp2 = db.fx.Avg(dbo.Person.Id).As("foo");

            //then
            Assert.False(exp1.Equals(exp2));
        }

        [Theory]
        [InlineData(2014)]
        public void Average_functions_of_person_id_should_have_same_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = db.fx.Avg(dbo.Person.Id);
            var exp2 = db.fx.Avg(dbo.Person.Id);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().Be(hc2);
        }

        [Theory]
        [InlineData(2014)]
        public void Average_functions_of_person_id_with_one_aliased_should_have_different_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = db.fx.Avg(dbo.Person.Id);
            var exp2 = db.fx.Avg(dbo.Person.Id).As("foo");

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }

        [Theory]
        [InlineData(2014)]
        public void Average_functions_of_person_id_with_one_distinct_should_have_different_hash_codes(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp1 = db.fx.Avg(dbo.Person.Id);
            var exp2 = db.fx.Avg(dbo.Person.Id, true);

            //when
            var hc1 = exp1.GetHashCode();
            var hc2 = exp2.GetHashCode();

            //then
            hc1.Should().NotBe(hc2);
        }
    }
}
