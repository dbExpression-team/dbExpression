using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Data;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Code.Assembler
{
    public class ParameterBuilderTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_long_parameters_with_same_value_share_the_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, typeof(long));

            //when
            var newParameter = parameterBuilder.Add(1, typeof(long));

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_long_parameters_with_different_value_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, typeof(long));

            //when
            var newParameter = parameterBuilder.Add(2, typeof(long));

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_long_and_int_parameters_with_samve_value_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, typeof(long));

            //when
            var newParameter = parameterBuilder.Add(1, typeof(int));

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_long_and_int_primitive_parameter_with_different_value_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, typeof(long));

            //when
            var newParameter = parameterBuilder.Add(2, typeof(int));

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_int_parameters_with_same_value_using_generic_version_share_the_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1);

            //when
            var newParameter = parameterBuilder.Add(1);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_int_parameters_with_different_value_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1);

            //when
            var newParameter = parameterBuilder.Add(2);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_long_and_int_parameters_with_same_value_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, typeof(long));

            //when
            var newParameter = parameterBuilder.Add<int>(1);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_an_int_and_long_parameters_with_different_values_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, typeof(long));

            //when
            var newParameter = parameterBuilder.Add<int>(2);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_long_parameters_with_same_value_first_by_object_then_by_generic_share_the_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, typeof(long));

            //when
            var newParameter = parameterBuilder.Add<long>(1);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_same_value_and_type_share_the_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add("HelloWorld", typeof(string));

            //when
            var newParameter = parameterBuilder.Add("HelloWorld", typeof(string));

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_different_value_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add("HelloWorld", typeof(string));

            //when
            var newParameter = parameterBuilder.Add("xHelloWorld", typeof(string));

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_same_value_and_type_using_generic_version_share_the_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add("HelloWorld");

            //when
            var newParameter = parameterBuilder.Add("HelloWorld");

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_different_value_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add("HelloWorld");

            //when
            var newParameter = parameterBuilder.Add("xHelloWorld");

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_different_value_and_type_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add("HelloWorld", typeof(string));

            //when
            var newParameter = parameterBuilder.Add<string>("xHelloWorld");

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_same_value_and_type_first_by_object_then_by_generic_share_the_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add("HelloWorld", typeof(string));

            //when
            var newParameter = parameterBuilder.Add<string>("HelloWorld");

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_DateTime_parameter_with_same_value_and_type_share_the_parameter(int version)
        {
            //given
            var now = DateTime.UtcNow;
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(now, typeof(DateTime));

            //when
            var newParameter = parameterBuilder.Add(now, typeof(DateTime));

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_DateTime_parameter_with_different_value_result_in_new_parameter(int version)
        {
            //given
            var now = DateTime.UtcNow;
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(now, typeof(DateTime));

            //when
            var newParameter = parameterBuilder.Add(now.AddMilliseconds(1).Date, typeof(DateTime));

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_DateTime_parameter_with_same_value_and_type_using_generic_version_share_the_parameter(int version)
        {
            //given
            var now = DateTime.UtcNow;
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(now);

            //when
            var newParameter = parameterBuilder.Add(now);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_DateTime_parameter_with_different_value_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var now = DateTime.UtcNow;
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(now);

            //when
            var newParameter = parameterBuilder.Add(now.AddMilliseconds(1).Date);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_DateTime_parameter_with_different_value_and_type_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var now = DateTime.UtcNow;
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(now, typeof(DateTime));

            //when
            var newParameter = parameterBuilder.Add<DateTime>(now.AddMilliseconds(1).Date);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_DateTime_parameter_with_same_value_and_type_first_by_object_then_by_generic_share_the_parameter(int version)
        {
            //given
            var now = DateTime.UtcNow;
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(now, typeof(DateTime));

            //when
            var newParameter = parameterBuilder.Add<DateTime>(now);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_byte_array_parameter_with_same_value_and_type_share_the_parameter(int version)
        {
            //given
            var value = new byte[] { 1, 2, 3 };
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(value, typeof(byte[]));

            //when
            var newParameter = parameterBuilder.Add(value, typeof(byte[]));

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_byte_array_parameter_with_different_value_result_in_new_parameter(int version)
        {
            //given
            var value = new byte[] { 1, 2, 3 };
            var newValue = new byte[] { 1, 2, 3, 4 };
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(value, typeof(byte[]));

            //when
            var newParameter = parameterBuilder.Add(newValue, typeof(byte[]));

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_byte_array_parameter_with_same_value_and_type_using_generic_version_share_the_parameter(int version)
        {
            //given
            var value = new byte[] { 1, 2, 3 };
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(value);

            //when
            var newParameter = parameterBuilder.Add(value);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_byte_array_parameter_with_different_value_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var value = new byte[] { 1, 2, 3 };
            var newValue = new byte[] { 1, 2, 3, 4 };
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(value);

            //when
            var newParameter = parameterBuilder.Add(newValue);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_byte_array_parameter_with_different_value_and_type_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var value = new byte[] { 1, 2, 3 };
            var newValue = new byte[] { 1, 2, 3, 4 };
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(value, typeof(byte[]));

            //when
            var newParameter = parameterBuilder.Add<byte[]>(newValue);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_byte_array_parameter_with_same_value_and_type_first_by_object_then_by_generic_share_the_parameter(int version)
        {
            //given
            var value = new byte[] { 1, 2, 3 };
            var database = ConfigureForMsSqlVersion(version);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(value, typeof(byte[]));

            //when
            var newParameter = parameterBuilder.Add<byte[]>(value);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_parameter_for_product_description_create_correct_dbtype_and_size_for_filter_expression(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, null, database.AppenderFactory.CreateAppender(), database.ParameterBuilderFactory.CreateSqlParameterBuilder());
            var context = new AssemblyContext(database.AssemblerConfiguration);
            string productDescription = "1234";

            var predicate = dbo.Product.Description == productDescription;

            var appender = database.AssemblyPartAppenderFactory.CreatePartAppender(predicate);

            //when
            appender.AppendPart(predicate, builder, context);
            var parameter = builder.Parameters.Parameters.SingleOrDefault();

            //then
            parameter.Field.Should().Be(dbo.Product.Description);
            parameter.Metadata.DbType.Should().Be(SqlDbType.NVarChar);
            parameter.Parameter.DbType.Should().Be(DbType.String);
            parameter.Parameter.Size.Should().Be(parameter.Metadata.Size);
            parameter.Parameter.Value.Should().Be(productDescription);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_parameter_for_person_firstname_create_correct_dbtype_and_size_for_filter_expression(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, null, database.AppenderFactory.CreateAppender(), database.ParameterBuilderFactory.CreateSqlParameterBuilder());
            var context = new AssemblyContext(database.AssemblerConfiguration);
            string firstName = "xxx";

            var predicate = dbo.Person.FirstName == firstName;

            var appender = database.AssemblyPartAppenderFactory.CreatePartAppender(predicate);

            //when
            appender.AppendPart(predicate, builder, context);
            var parameter = builder.Parameters.Parameters.SingleOrDefault();

            //then
            parameter.Field.Should().Be(dbo.Person.FirstName);
            parameter.Metadata.DbType.Should().Be(SqlDbType.VarChar);
            parameter.Parameter.DbType.Should().Be(DbType.AnsiString);
            parameter.Parameter.Size.Should().Be(parameter.Metadata.Size);
            parameter.Parameter.Value.Should().Be(firstName);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_parameter_for_product_price_create_correct_dbtype_for_filter_expression(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, null, database.AppenderFactory.CreateAppender(), database.ParameterBuilderFactory.CreateSqlParameterBuilder());
            var context = new AssemblyContext(database.AssemblerConfiguration);
            double productPrice = 12.99;

            var predicate = dbo.Product.Price == productPrice;

            var appender = database.AssemblyPartAppenderFactory.CreatePartAppender(predicate);

            //when
            appender.AppendPart(predicate, builder, context);
            var parameter = builder.Parameters.Parameters.SingleOrDefault();

            //then
            parameter.Field.Should().Be(dbo.Product.Price);
            parameter.Metadata.DbType.Should().Be(SqlDbType.Money);
            parameter.Parameter.DbType.Should().Be(DbType.Currency);
            parameter.Parameter.Value.Should().Be(productPrice);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_parameter_for_product_image_create_correct_dbtype_for_filter_expression(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, null, database.AppenderFactory.CreateAppender(), database.ParameterBuilderFactory.CreateSqlParameterBuilder());
            var context = new AssemblyContext(database.AssemblerConfiguration);
            byte[] image = new byte[] { 1, 2, 3 };

            var predicate = dbo.Product.Image == image;

            var appender = database.AssemblyPartAppenderFactory.CreatePartAppender(predicate);

            //when
            appender.AppendPart(predicate, builder, context);
            var parameter = builder.Parameters.Parameters.SingleOrDefault();

            //then
            parameter.Field.Should().Be(dbo.Product.Image);
            parameter.Metadata.DbType.Should().Be(SqlDbType.VarBinary);
            parameter.Parameter.DbType.Should().Be(DbType.Binary);
            parameter.Parameter.Value.Should().Be(image);
        }
    }
}
