using DbEx.Data;
using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql.Converter;
using System;
using System.Collections.Generic;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    public class DelegateEnumValueConverterTests : ExecutorTestBase
    {
        [Theory]
        [Trait("Configuration", "DelegateEnumValueConverter")]
        [MsSqlVersions.AllVersions]
        public void Does_selecting_persons_where_gendertype_is_male_return_no_results_when_delegate_value_converter_converts_male_to_defauult(int version)
        {
            //given
            var converter = new DelegateEnumValueConverter<GenderType>(g => Enum.ToObject(typeof(GenderType), 0), o => default);
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version, c => c.Conversions.ForTypes(x => x.ForEnumType<GenderType>().Use(converter)));

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
