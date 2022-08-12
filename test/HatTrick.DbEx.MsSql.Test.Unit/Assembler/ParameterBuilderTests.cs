using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Linq;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Assembler
{
    public class ParameterBuilderTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_long_parameters_with_same_value_share_the_parameter(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(1, typeof(long), context);
            parameterBuilder.Parameters.Add(parameter);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.CreateInputParameter(1, typeof(long), context);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_long_parameters_with_different_value_result_in_new_parameter(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(1, typeof(long), context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter(2, typeof(long), context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_long_and_int_parameters_with_samve_value_result_in_new_parameter(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(1, typeof(long), context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter(1, typeof(int), context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_long_and_int_primitive_parameter_with_different_value_result_in_new_parameter(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(1, typeof(long), context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter(2, typeof(int), context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_int_parameters_with_same_value_using_generic_version_share_the_parameter(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(1, context);
            parameterBuilder.AddParameter(parameter);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.CreateInputParameter(1, context);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_int_parameters_with_different_value_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(1, context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter(2, context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_long_and_int_parameters_with_same_value_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(1, typeof(long), context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter<int>(1, context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_an_int_and_long_parameters_with_different_values_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(1, typeof(long), context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter<int>(2, context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_long_parameters_with_same_value_first_by_object_then_by_generic_share_the_parameter(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(1, typeof(long), context);
            parameterBuilder.AddParameter(parameter);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.CreateInputParameter<long>(1, context);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_same_value_and_type_share_the_parameter(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter("HelloWorld", typeof(string), context);
            parameterBuilder.AddParameter(parameter);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.CreateInputParameter("HelloWorld", typeof(string), context);

            //then
            newParameter.Should().Be(parameter);
            newParameter.Parameter.Size.Should().Be("HelloWorld".Length);
            newParameter.Parameter.Value.Should().Be("HelloWorld");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_different_value_result_in_new_parameter(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter("HelloWorld", typeof(string), context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter("xHelloWorld", typeof(string), context);

            //then
            newParameter.Should().NotBe(parameter);
            newParameter.Parameter.Size.Should().Be("xHelloWorld".Length);
            newParameter.Parameter.Value.Should().Be("xHelloWorld");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_same_value_and_type_using_generic_version_share_the_parameter(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter("HelloWorld", context);
            parameterBuilder.AddParameter(parameter);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.CreateInputParameter("HelloWorld", context);

            //then
            newParameter.Should().Be(parameter);
            newParameter.Parameter.Size.Should().Be("HelloWorld".Length);
            newParameter.Parameter.Value.Should().Be("HelloWorld");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_different_value_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter("HelloWorld", context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter("xHelloWorld", context);

            //then
            newParameter.Should().NotBe(parameter);
            newParameter.Parameter.Size.Should().Be("xHelloWorld".Length);
            newParameter.Parameter.Value.Should().Be("xHelloWorld");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_different_value_and_type_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter("HelloWorld", typeof(string), context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter<string>("xHelloWorld", context);

            //then
            newParameter.Should().NotBe(parameter);
            newParameter.Parameter.Size.Should().Be("xHelloWorld".Length);
            newParameter.Parameter.Value.Should().Be("xHelloWorld");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_same_value_and_type_first_by_object_then_by_generic_share_the_parameter(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter("HelloWorld", typeof(string), context);
            parameterBuilder.AddParameter(parameter);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.CreateInputParameter<string>("HelloWorld", context);

            //then
            newParameter.Should().Be(parameter);
            newParameter.Parameter.Size.Should().Be("HelloWorld".Length);
            newParameter.Parameter.Value.Should().Be("HelloWorld");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_DateTime_parameter_with_same_value_and_type_share_the_parameter(int version)
        {
            //given
            var now = DateTime.UtcNow;
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(now, typeof(DateTime), context);
            parameterBuilder.AddParameter(parameter);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.CreateInputParameter(now, typeof(DateTime), context);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_DateTime_parameter_with_different_value_result_in_new_parameter(int version)
        {
            //given
            var now = DateTime.UtcNow;
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(now, typeof(DateTime), context);
            parameterBuilder.AddParameter(parameter);

            //when
            var newParameter = parameterBuilder.CreateInputParameter(now.AddMilliseconds(1).Date, typeof(DateTime), context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_DateTime_parameter_with_same_value_and_type_using_generic_version_share_the_parameter(int version)
        {
            //given
            var now = DateTime.UtcNow;
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(now, context);
            parameterBuilder.AddParameter(parameter);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.CreateInputParameter(now, context);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_DateTime_parameter_with_different_value_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var now = DateTime.UtcNow;
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(now, context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter(now.AddMilliseconds(1).Date, context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_DateTime_parameter_with_different_value_and_type_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var now = DateTime.UtcNow;
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(now, typeof(DateTime), context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter<DateTime>(now.AddMilliseconds(1).Date, context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_DateTime_parameter_with_same_value_and_type_first_by_object_then_by_generic_share_the_parameter(int version)
        {
            //given
            var now = DateTime.UtcNow;
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(now, typeof(DateTime), context);
            parameterBuilder.AddParameter(parameter);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.CreateInputParameter<DateTime>(now, context);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_byte_array_parameter_with_same_value_and_type_share_the_parameter(int version)
        {
            //given
            var value = new byte[] { 1, 2, 3 };
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(value, typeof(byte[]), context);
            parameterBuilder.AddParameter(parameter);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.CreateInputParameter(value, typeof(byte[]), context);

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
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(value, typeof(byte[]), context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter(newValue, typeof(byte[]), context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_byte_array_parameter_with_same_value_and_type_using_generic_version_share_the_parameter(int version)
        {
            //given
            var value = new byte[] { 1, 2, 3 };
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(value, context);
            parameterBuilder.AddParameter(parameter);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.CreateInputParameter(value, context);

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
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(value, context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter(newValue, context);

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
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(value, typeof(byte[]), context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter<byte[]>(newValue, context);

            //then
            newParameter.Should().NotBe(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_byte_array_parameter_with_same_value_and_type_first_by_object_then_by_generic_fail(int version)
        {
            //given
            var value = new byte[] { 1, 2, 3 };
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            parameterBuilder.CreateInputParameter(value, typeof(byte[]), context);

            //when
            try
            {
                var newParameter = parameterBuilder.CreateInputParameter<byte[]>(value, context);
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
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(value, typeof(byte[]), context);
            parameterBuilder.AddParameter(parameter);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.CreateInputParameter<byte[]>(value, context);

            //then
            newParameter.Should().Be(parameter);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_parameter_for_product_name_create_correct_dbtype_and_size_for_filter_expression(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var builder = serviceProvider.GetRequiredService<ISqlStatementBuilder<MsSqlDb>>();
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            string productName = "1234";

            var predicate = dbo.Product.Name == productName;

            var appender = serviceProvider.GetRequiredService<IExpressionElementAppenderFactory<MsSqlDb>>().CreateElementAppender(predicate.GetType())!;

            //when
            appender.AppendElement(predicate, builder, context);
            var parameter = builder.Parameters.Parameters.Single();
            var meta = (parameter.Metadata as ISqlColumnMetadata)!;

            //then
            meta.DbType.Should().Be(SqlDbType.VarChar);
            parameter.Parameter.DbType.Should().Be(DbType.AnsiString);
            parameter.Parameter.Size.Should().Be(meta.Size);
            parameter.Parameter.Value.Should().Be(productName);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_parameter_for_person_firstname_create_correct_dbtype_and_size_for_filter_expression(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var builder = serviceProvider.GetRequiredService<ISqlStatementBuilder<MsSqlDb>>();
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            string firstName = "xxx";

            var predicate = dbo.Person.FirstName == firstName;

            var appender = serviceProvider.GetRequiredService<IExpressionElementAppenderFactory<MsSqlDb>>().CreateElementAppender(predicate.GetType())!;

            //when
            appender.AppendElement(predicate, builder, context);
            var parameter = builder.Parameters.Parameters.Single();
            var meta = (parameter.Metadata as ISqlColumnMetadata)!;

            //then
            meta.DbType.Should().Be(SqlDbType.VarChar);
            parameter.Parameter.DbType.Should().Be(DbType.AnsiString);
            parameter.Parameter.Size.Should().Be(meta.Size);
            parameter.Parameter.Value.Should().Be(firstName);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_parameter_for_product_price_create_correct_dbtype_for_filter_expression(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var builder = serviceProvider.GetRequiredService<ISqlStatementBuilder<MsSqlDb>>();
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            double productPrice = 12.99;

            var predicate = dbo.Product.Price == productPrice;

            var appender = serviceProvider.GetRequiredService<IExpressionElementAppenderFactory<MsSqlDb>>().CreateElementAppender(predicate.GetType())!;

            //when
            appender.AppendElement(predicate, builder, context);
            var parameter = builder.Parameters.Parameters.Single();
            var meta = (parameter.Metadata as ISqlColumnMetadata)!;

            //then
            meta.DbType.Should().Be(SqlDbType.Money);
            parameter.Parameter.DbType.Should().Be(DbType.Currency);
            parameter.Parameter.Value.Should().Be(productPrice);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_parameter_for_product_image_create_correct_dbtype_for_filter_expression(int version)
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var builder = serviceProvider.GetRequiredService<ISqlStatementBuilder<MsSqlDb>>();
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            byte[] image = new byte[] { 1, 2, 3 };

            var predicate = dbo.Product.Image == image;

            var appender = serviceProvider.GetRequiredService<IExpressionElementAppenderFactory<MsSqlDb>>().CreateElementAppender(predicate.GetType())!;

            //when
            appender.AppendElement(predicate, builder, context);
            var parameter = builder.Parameters.Parameters.Single();
            var meta = (parameter.Metadata as ISqlColumnMetadata)!;

            //then
            meta.DbType.Should().Be(SqlDbType.VarBinary);
            parameter.Parameter.DbType.Should().Be(DbType.Binary);
            parameter.Parameter.Value.Should().Be(image);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_decimal_parameter_with_same_value_and_type_share_the_parameter(int version)
        {
            //given
            var value = 11.11m;
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(value, typeof(decimal), context);
            parameterBuilder.AddParameter(parameter);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.CreateInputParameter(value, typeof(decimal), context);

            //then
            newParameter.Should().Be(parameter);
            newParameter.Parameter.Precision.Should().Be(4);
            newParameter.Parameter.Scale.Should().Be(2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_decimal_parameter_with_different_value_result_in_new_parameter(int version)
        {
            //given
            var value = 11.11m;
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(value, typeof(decimal), context);
            parameterBuilder.AddParameter(parameter);

            //when
            var newParameter = parameterBuilder.CreateInputParameter(value + .001m, typeof(decimal), context);

            //then
            newParameter.Should().NotBe(parameter);
            newParameter.Parameter.Precision.Should().Be(5);
            newParameter.Parameter.Scale.Should().Be(3);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_decimal_parameter_with_same_value_and_type_using_generic_version_share_the_parameter(int version)
        {
            //given
            var value = 11.11m;
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(value, context);
            parameterBuilder.AddParameter(parameter);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.CreateInputParameter(value, context);

            //then
            newParameter.Should().Be(parameter);
            newParameter.Parameter.Precision.Should().Be(4);
            newParameter.Parameter.Scale.Should().Be(2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_decimal_parameter_with_different_value_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var value = 11.11m;
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(value, context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter(value + .001m, context);

            //then
            newParameter.Should().NotBe(parameter);
            newParameter.Parameter.Precision.Should().Be(5);
            newParameter.Parameter.Scale.Should().Be(3);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_decimal_parameter_with_different_value_and_type_using_generic_version_result_in_new_parameter(int version)
        {
            //given
            var value = 11.11m;
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(value, typeof(decimal), context);

            //when
            var newParameter = parameterBuilder.CreateInputParameter<decimal>(value + .001m, context);

            //then
            newParameter.Should().NotBe(parameter);
            newParameter.Parameter.Precision.Should().Be(5);
            newParameter.Parameter.Scale.Should().Be(3);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_decimal_parameter_with_same_value_and_type_first_by_object_then_by_generic_share_the_parameter(int version)
        {
            //given
            var value = 11.11m;
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var parameter = parameterBuilder.CreateInputParameter(value, typeof(decimal), context);
            parameterBuilder.AddParameter(parameter);

            //when
            context.TrySharingExistingParameter = true;
            var newParameter = parameterBuilder.CreateInputParameter<decimal>(value, context);

            //then
            newParameter.Should().Be(parameter);
            newParameter.Parameter.Precision.Should().Be(4);
            newParameter.Parameter.Scale.Should().Be(2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_string_parameter_with_empty_value_and_metadata_type_char_produce_parameter_with_correct_sqldbtype(int version)
        {
            //given
            var value = string.Empty;
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var databaseMetadata = new MsSqlDbSqlDatabaseMetadata(nameof(MsSqlDb));
            var fieldMetadata = new MsSqlColumnMetadata($"{nameof(dbo)}.{nameof(dbo.Person)}.{nameof(dbo.Person.FirstName)}", SqlDbType.Char, 0);

            //when
            var parameter = parameterBuilder.CreateInputParameter(value, typeof(string), fieldMetadata, context);

            //then
            parameter.Parameter.DbType.Should().Be(DbType.AnsiString);
            parameter.Parameter.Size.Should().Be(1);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_adding_a_byte_array_parameter_with_empty_value_and_metadata_type_binary_produce_parameter_with_correct_sqldbtype(int version)
        {
            //given
            var value = Array.Empty<byte>();
            var (db, serviceProvider) = ConfigureForMsSqlVersion(version);
            var context = serviceProvider.GetRequiredService<AssemblyContext>();
            var parameterBuilder = serviceProvider.GetRequiredService<ISqlParameterBuilder<MsSqlDb>>();
            var databaseMetadata = new MsSqlDbSqlDatabaseMetadata(nameof(MsSqlDb));
            var fieldMetadata = new MsSqlColumnMetadata($"{nameof(dbo)}.{nameof(dbo.Product)}.{nameof(dbo.Product.Image)}", SqlDbType.Binary, 0);

            //when
            var parameter = parameterBuilder.CreateInputParameter(value, typeof(byte[]), fieldMetadata, context);

            //then
            parameter.Parameter.DbType.Should().Be(DbType.Binary);
        }
    }
}
