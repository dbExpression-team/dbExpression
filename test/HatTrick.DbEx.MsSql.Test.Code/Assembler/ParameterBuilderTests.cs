using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
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
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, typeof(long), context);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.Add(1, typeof(long), context);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_long_parameters_with_different_value_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, typeof(long), context);

            //when
            var newParameter = parameterBuilder.Add(2, typeof(long), context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_long_and_int_parameters_with_samve_value_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, typeof(long), context);

            //when
            var newParameter = parameterBuilder.Add(1, typeof(int), context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_long_and_int_primitive_parameter_with_different_value_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, typeof(long), context);

            //when
            var newParameter = parameterBuilder.Add(2, typeof(int), context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_int_parameters_with_same_value_using_generic_version_share_the_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, context);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.Add(1, context);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_int_parameters_with_different_value_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, context);

            //when
            var newParameter = parameterBuilder.Add(2, context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_long_and_int_parameters_with_same_value_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, typeof(long), context);

            //when
            var newParameter = parameterBuilder.Add<int>(1, context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_an_int_and_long_parameters_with_different_values_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, typeof(long), context);

            //when
            var newParameter = parameterBuilder.Add<int>(2, context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_long_parameters_with_same_value_first_by_object_then_by_generic_share_the_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(1, typeof(long), context);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.Add<long>(1, context);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_same_value_and_type_share_the_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add("HelloWorld", typeof(string), context);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.Add("HelloWorld", typeof(string), context);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_different_value_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add("HelloWorld", typeof(string), context);

            //when
            var newParameter = parameterBuilder.Add("xHelloWorld", typeof(string), context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_same_value_and_type_using_generic_version_share_the_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add("HelloWorld", context);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.Add("HelloWorld", context);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_different_value_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add("HelloWorld", context);

            //when
            var newParameter = parameterBuilder.Add("xHelloWorld", context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_different_value_and_type_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add("HelloWorld", typeof(string), context);

            //when
            var newParameter = parameterBuilder.Add<string>("xHelloWorld", context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_same_value_and_type_first_by_object_then_by_generic_share_the_parameter(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add("HelloWorld", typeof(string), context);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.Add<string>("HelloWorld", context);

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
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(now, typeof(DateTime), context);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.Add(now, typeof(DateTime), context);

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
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(now, typeof(DateTime), context);

            //when
            var newParameter = parameterBuilder.Add(now.AddMilliseconds(1).Date, typeof(DateTime), context);

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
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(now, context);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.Add(now, context);

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
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(now, context);

            //when
            var newParameter = parameterBuilder.Add(now.AddMilliseconds(1).Date, context);

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
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(now, typeof(DateTime), context);

            //when
            var newParameter = parameterBuilder.Add<DateTime>(now.AddMilliseconds(1).Date, context);

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
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(now, typeof(DateTime), context);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.Add<DateTime>(now, context);

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
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(value, typeof(byte[]), context);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.Add(value, typeof(byte[]), context);

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
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(value, typeof(byte[]), context);

            //when
            var newParameter = parameterBuilder.Add(newValue, typeof(byte[]), context);

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
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(value, context);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.Add(value, context);

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
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(value, context);

            //when
            var newParameter = parameterBuilder.Add(newValue, context);

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
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(value, typeof(byte[]), context);

            //when
            var newParameter = parameterBuilder.Add<byte[]>(newValue, context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_byte_array_parameter_with_same_value_and_type_first_by_object_then_by_generic_fail(int version)
        {
            //given
            var value = new byte[] { 1, 2, 3 };
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            parameterBuilder.Add(value, typeof(byte[]), context);

            //when
            try
            {
                var newParameter = parameterBuilder.Add<byte[]>(value, context);
                newParameter.Should().BeNull();
            }
            catch (Exception)
            {
                //then
            }            
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_byte_array_parameter_with_same_value_and_type_first_by_object_then_by_generic_share_the_parameter_when_parameter_reuse_is_required(int version)
        {
            //given
            var value = new byte[] { 1, 2, 3 };
            var database = ConfigureForMsSqlVersion(version);
            var context = new AssemblyContext(database.AssemblerConfiguration);
            var parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var parameter = parameterBuilder.Add(value, typeof(byte[]), context);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.Add<byte[]>(value, context);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_parameter_for_product_description_create_correct_dbtype_and_size_for_filter_expression(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, database.QueryExpressionFactory.CreateQueryExpression<SelectQueryExpression>(), database.AppenderFactory.CreateAppender(), database.ParameterBuilderFactory.CreateSqlParameterBuilder());
            var context = new AssemblyContext(database.AssemblerConfiguration);
            string productDescription = "1234";

            var predicate = dbo.Product.Description == productDescription;

            var appender = database.AssemblyPartAppenderFactory.CreateElementAppender(predicate);

            //when
            appender.AppendElement(predicate, builder, context);
            var parameter = builder.Parameters.Parameters.SingleOrDefault();

            //then
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
            var builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, database.QueryExpressionFactory.CreateQueryExpression<SelectQueryExpression>(), database.AppenderFactory.CreateAppender(), database.ParameterBuilderFactory.CreateSqlParameterBuilder());
            var context = new AssemblyContext(database.AssemblerConfiguration);
            string firstName = "xxx";

            var predicate = dbo.Person.FirstName == firstName;

            var appender = database.AssemblyPartAppenderFactory.CreateElementAppender(predicate);

            //when
            appender.AppendElement(predicate, builder, context);
            var parameter = builder.Parameters.Parameters.SingleOrDefault();

            //then
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
            var builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, database.QueryExpressionFactory.CreateQueryExpression<SelectQueryExpression>(), database.AppenderFactory.CreateAppender(), database.ParameterBuilderFactory.CreateSqlParameterBuilder());
            var context = new AssemblyContext(database.AssemblerConfiguration);
            double productPrice = 12.99;

            var predicate = dbo.Product.Price == productPrice;

            var appender = database.AssemblyPartAppenderFactory.CreateElementAppender(predicate);

            //when
            appender.AppendElement(predicate, builder, context);
            var parameter = builder.Parameters.Parameters.SingleOrDefault();

            //then
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
            var builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, database.QueryExpressionFactory.CreateQueryExpression<SelectQueryExpression>(), database.AppenderFactory.CreateAppender(), database.ParameterBuilderFactory.CreateSqlParameterBuilder());
            var context = new AssemblyContext(database.AssemblerConfiguration);
            byte[] image = new byte[] { 1, 2, 3 };

            var predicate = dbo.Product.Image == image;

            var appender = database.AssemblyPartAppenderFactory.CreateElementAppender(predicate);

            //when
            appender.AppendElement(predicate, builder, context);
            var parameter = builder.Parameters.Parameters.SingleOrDefault();

            //then
            parameter.Metadata.DbType.Should().Be(SqlDbType.VarBinary);
            parameter.Parameter.DbType.Should().Be(DbType.Binary);
            parameter.Parameter.Value.Should().Be(image);
        }
    }
}
