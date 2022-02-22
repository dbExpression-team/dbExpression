using DbEx.Data;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Expression;
using System;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Code.Configuration
{
    public class ConversionConfigurationBuilderTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_using_instance_method_with_null_instance_throw_expected_exception(int version)
        {
            //given & when & then
            Assert.Throws<DbExpressionConfigurationException>(() => ConfigureForMsSqlVersion(version, builder => builder.Conversions.Use((IValueConverterFactory)null)));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_converter_factory_using_generic_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Conversions.Use<NoOpValueConverterFactory>());

            //when
            var matchingType = config.ValueConverterFactory is NoOpValueConverterFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_converter_factory_using_instance_use_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Conversions.Use(new NoOpValueConverterFactory()));

            //when
            var matchingType = config.ValueConverterFactory is NoOpValueConverterFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_type_converter_override_using_generic_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Conversions.UseDefaultFactory(x => x.OverrideForValueType<int>().Use<NoOpValueConverter>()));

            //when
            var matchingType = config.ValueConverterFactory is IValueConverterFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_type_using_generic_method_return_correct_converter_of_a_type_converter_override(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Conversions.UseDefaultFactory(x => x.OverrideForValueType<int>().Use<NoOpValueConverter>()));
            var converter = config.ValueConverterFactory.CreateConverter<int>();

            //when & then
            Assert.Throws<NotImplementedException>(() => converter.ConvertFromDatabase(1));
            converter.Should().BeOfType<NoOpValueConverter>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_type_converter_override_using_instance_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Conversions.UseDefaultFactory(x => x.OverrideForValueType<int>().Use(new NoOpValueConverter())));

            //when
            var matchingType = config.ValueConverterFactory is IValueConverterFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_type_using_instance_method_return_correct_converter_of_a_type_converter_override(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Conversions.UseDefaultFactory(x => x.OverrideForValueType<int>().Use(new NoOpValueConverter())));
            var converter = config.ValueConverterFactory.CreateConverter<int>();

            //when & then
            Assert.Throws<NotImplementedException>(() => converter.ConvertFromDatabase(1));
            converter.Should().BeOfType<NoOpValueConverter>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_enum_type_converter_override_using_generic_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Conversions.UseDefaultFactory(x => x.OverrideForEnumType<AddressType>().Use<NoOpValueConverter>()));

            //when
            var matchingType = config.ValueConverterFactory is IValueConverterFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_enum_type_using_generic_method_return_correct_converter_of_a_type_converter_override(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Conversions.UseDefaultFactory(x => x.OverrideForEnumType<AddressType>().Use<NoOpValueConverter>()));
            var converter = config.ValueConverterFactory.CreateConverter<AddressType>();

            //when & then
            Assert.Throws<NotImplementedException>(() => converter.ConvertFromDatabase(1));
            converter.Should().BeOfType<NoOpValueConverter>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_enum_type_converter_override_using_instance_method_succeed(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Conversions.UseDefaultFactory(x => x.OverrideForEnumType<AddressType>().Use(new NoOpValueConverter())));

            //when
            var matchingType = config.ValueConverterFactory is IValueConverterFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_of_a_enum_type_using_instance_method_return_correct_converter_of_a_type_converter_override(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Conversions.UseDefaultFactory(x => x.OverrideForEnumType<AddressType>().Use(new NoOpValueConverter())));
            var converter = config.ValueConverterFactory.CreateConverter<AddressType>();

            //when & then
            Assert.Throws<NotImplementedException>(() => converter.ConvertFromDatabase(1));
            converter.Should().BeOfType<NoOpValueConverter>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_using_generic_for_enum_type_method_return_correct_converter_of_a_type_converter_override(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Conversions.UseDefaultFactory(x => x.OverrideForEnumType<AddressType>().Use<NoOpValueConverter>()));

            //when
            var matchingType = config.ValueConverterFactory is IValueConverterFactory;

            //then
            matchingType.Should().BeTrue();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_using_instance_for_enum_type_method_return_correct_converter_of_a_type_converter_override(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Conversions.UseDefaultFactory(x => x.OverrideForEnumType<AddressType>().Use(new NoOpValueConverter())));
            var converter = config.ValueConverterFactory.CreateConverter<AddressType>();

            //when & then
            Assert.Throws<NotImplementedException>(() => converter.ConvertFromDatabase(1));
            converter.Should().BeOfType<NoOpValueConverter>();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_configuration_using_delegates_for_enum_type_method_return_correct_converter_of_a_enum_type_converter_override(int version)
        {
            //given
            var config = ConfigureForMsSqlVersion(version, builder => builder.Conversions.UseDefaultFactory(x => x.OverrideForEnumType<AddressType>().Use(a => throw new NotImplementedException(), a => AddressType.Mailing)));
            var converter = config.ValueConverterFactory.CreateConverter<AddressType>();

            //when
            var value = converter.ConvertFromDatabase(AddressType.Billing);

            //then
            value.Should().Be(AddressType.Mailing);
        }        

        public class NoOpValueConverter : IValueConverter
        {
            public object ConvertFromDatabase(object value) => throw new NotImplementedException();
            public T ConvertFromDatabase<T>(object value) => throw new NotImplementedException();
            public (Type, object) ConvertToDatabase(object value) => throw new NotImplementedException();
        }

        public class NoOpValueConverterFactory : IValueConverterFactory
        {
            public IValueConverter CreateConverter<T>() => throw new NotImplementedException();
            public IValueConverter CreateConverter(Type type) => throw new NotImplementedException();
            public IValueConverter CreateConverter(FieldExpression field) => throw new NotImplementedException();
        }
    }
}
