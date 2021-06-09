﻿using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "SELECT")]
    [Trait("Function", "RTRIM")]
    public partial class RTrim : ExecutorTestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_rtrim_of_person_first_name_with_space_padding_succeed(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.RTrim(" " + dbo.Person.FirstName + " ")
                ).From(dbo.Person);

            //when               
            var result = exp.Execute();

            //then
            result.Should().NotEndWith(" ");
            result.Should().StartWith(" ");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_rtrim_of_null_address_line2_with_space_padding_succeed(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            var exp = db.SelectOne(
                    db.fx.RTrim(" " + dbo.Address.Line2 + " ")
                ).From(dbo.Address)
                .Where(dbo.Address.Line2 == DBNull.Value);

            //when               
            var result = exp.Execute();

            //then
            result.Should().BeNull();
        }
    }
}
