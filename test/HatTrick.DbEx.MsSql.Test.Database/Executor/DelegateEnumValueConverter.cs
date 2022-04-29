using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    public class DelegateEnumValueConverter : ExecutorTestBase
    {
        [Theory]
        [Trait("Configuration", "DelegateEnumValueConverter")]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_persons_where_gendertype_is_male_return_no_results_when_delegate_value_converter_converts_male_to_defauult(int version)
        {
            //given
            var converter = new Sql.Converter.DelegateEnumValueConverter<GenderType>(g => Enum.ToObject(typeof(GenderType), 0), o => default);
            ConfigureForMsSqlVersion(version, c => c.Conversions.UseDefaultFactory(x => x.OverrideForEnumType<GenderType>().Use(converter)));

            //when
            IList<Person> persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.GenderType == GenderType.Male)
                .Execute();

            //then
            persons.Should().BeEmpty();
        }
    }
}
