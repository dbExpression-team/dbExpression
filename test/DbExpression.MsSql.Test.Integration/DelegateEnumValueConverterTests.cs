using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Test.Executor;
using DbExpression.Sql.Converter;
using System;
using System.Collections.Generic;
using Xunit;

namespace DbExpression.MsSql.Test.Integration
{
    public class DelegateEnumValueConverterTests : ResetDatabaseNotRequired
    {
        [Fact]
        [Trait("Configuration", "DelegateEnumValueConverter")]
        public void Does_selecting_persons_where_gendertype_is_male_return_no_results_when_delegate_value_converter_converts_male_to_defauult()
        {
            //given
            var converter = new DelegateEnumValueConverter<GenderType>(g => Enum.ToObject(typeof(GenderType), 0), o => default);
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.Conversions.ForTypes(x => x.ForEnumType<GenderType>().Use(converter)));

            //when
            IEnumerable<Person> persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.GenderType == GenderType.Male)
                .Execute();

            //then
            persons.Should().BeEmpty();
        }
    }
}
