using DbEx.Data;
using v2019DbEx.DataService;
using v2019DbEx.dboData;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Test.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Integration
{
    [Trait("Statement", "STORED_PROCEDURE")]
    public partial class StoredProcedureTests : ResetDatabaseAfterEveryTest
    {

        [Theory]
        [InlineData(3)]
        public void Can_execute_stored_procedure_with_ignored_input_parameter_with_default_and_return_scalar_value(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var id = db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input_And_Default_Value().GetValue<int>().Execute();

            //then
            id.Should().Be(expected);
        }

        [Theory]
        [InlineData(1)]
        public void Can_execute_stored_procedure_with_input_parameter_and_return_dynamic(int id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var person = db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue().Execute();

            //then
            ((int)person!.Id).Should().Be(id);
        }
        
        [Theory]
        [InlineData(null)]
        public void Can_execute_stored_procedure_with_null_input_parameter_and_return_dynamic(int? id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var person = db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue().Execute();

            //then
            ((object?)person).Should().BeNull();
        }

        [Theory]
        [InlineData(0, 50)]
        public void Can_execute_stored_procedure_with_input_parameter_and_return_dynamic_list(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var persons = db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues<int?>().Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(0, 50)]
        public void Can_execute_stored_procedure_with_input_parameter_and_return_list_of_person(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var persons = db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues(row => new Person { Id = row.ReadField()!.GetValue<int>() }).Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(0, 45, 50)]
        public void Can_execute_stored_procedure_with_input_parameter_and_command_timeout_and_return_list_of_person(int id, int expectedCommandTimeout, int expected)
        {
            //given
            int commandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.Events.OnAfterCommand(context => commandTimeout = context.DbCommand.CommandTimeout));

            //when               
            var persons = db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues(row => new Person { Id = row.ReadField()!.GetValue<int>() }).Execute(expectedCommandTimeout);

            //then
            persons.Should().HaveCount(expected);
            commandTimeout.Should().Be(expectedCommandTimeout);
        }

        [Theory]
        [InlineData(0, 50)]
        public void Can_execute_stored_procedure_with_input_parameter_and_provided_connection_and_return_list_of_person(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            using var connection = db.GetConnection();
            var persons = db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues(row => new Person { Id = row.ReadField()!.GetValue<int>() }).Execute(connection);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(0, 45, 50)]
        public void Can_execute_stored_procedure_with_input_parameter_and_provided_connection_and_command_timeout_and_return_list_of_person(int id, int expectedCommandTimeout, int expected)
        {
            //given
            int commandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.Events.OnAfterCommand(context => commandTimeout = context.DbCommand.CommandTimeout));

            //when               
            using var connection = db.GetConnection();
            var persons = db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues(row => new Person { Id = row.ReadField()!.GetValue<int>() }).Execute(connection, expectedCommandTimeout);

            //then
            persons.Should().HaveCount(expected);
            commandTimeout.Should().Be(expectedCommandTimeout);
        }

        [Theory]
        [InlineData(1)]
        public void Can_execute_stored_procedure_with_input_parameter_and_return_a_person(int id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var person = db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue(row => new Person { Id = row.ReadField()!.GetValue<int>() }).Execute();

            //then
            person.Should().NotBeNull();
            person!.Id.Should().Be(id);
        }

        [Theory]
        [InlineData(1, 45)]
        public void Can_execute_stored_procedure_with_input_parameter_and_command_timeout_and_return_a_person(int id, int expectedCommandTimeout)
        {
            //given
            int commandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.Events.OnAfterCommand(context => commandTimeout = context.DbCommand.CommandTimeout));

            //when               
            var person = db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue(row => new Person { Id = row.ReadField()!.GetValue<int>() }).Execute(expectedCommandTimeout);

            //then
            person.Should().NotBeNull();
            person!.Id.Should().Be(id);
            commandTimeout.Should().Be(expectedCommandTimeout);
        }

        [Theory]
        [InlineData(1)]
        public void Can_execute_stored_procedure_with_input_parameter_and_provided_connection_and_return_a_person(int id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            using var connection = db.GetConnection();
            var person = db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue(row => new Person { Id = row.ReadField()!.GetValue<int>() }).Execute(connection);

            //then
            person.Should().NotBeNull();
            person!.Id.Should().Be(id);
        }

        [Theory]
        [InlineData(1, 45)]
        public void Can_execute_stored_procedure_with_input_parameter_and_provided_connection_and_command_timeout_and_return_a_person(int id, int expectedCommandTimeout)
        {
            //given
            int commandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.Events.OnAfterCommand(context => commandTimeout = context.DbCommand.CommandTimeout));

            //when               
            using var connection = db.GetConnection();
            var person = db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue(row => new Person { Id = row.ReadField()!.GetValue<int>() }).Execute(connection, expectedCommandTimeout);

            //then
            person.Should().NotBeNull();
            person!.Id.Should().Be(id);
            commandTimeout.Should().Be(expectedCommandTimeout);
        }

        [Theory]
        [InlineData(null)]
        public void Can_execute_stored_procedure_with_null_input_parameter_and_return_dynamic_list(int? id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var persons = db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues().Execute();

            //then
            persons.Should().BeEmpty();
        }

        [Theory]
        [InlineData(1)]
        public void Can_execute_stored_procedure_with_input_parameter_and_return_scalar_value(int id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var value = db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue<int>().Execute();

            //then
            value.Should().Be(id);
        }

        [Theory]
        [InlineData(null)]
        public void Can_execute_stored_procedure_with_null_input_parameter_and_return_scalar_value(int? id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var value = db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue<int?>().Execute();

            //then
            value.Should().BeNull();
        }

        [Theory]
        [InlineData(0, 50)]
        public void Can_execute_stored_procedure_with_input_parameter_and_return_scalar_value_list(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var values = db.sp.dbo.SelectPersonId_As_ScalarValueList_With_Input(id).GetValues<int>().Execute();

            //then
            values.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(null)]
        public void Can_execute_stored_procedure_with_null_input_parameter_and_return_scalar_value_list(int? id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var values = db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValues<int?>().Execute();

            //then
            values.Should().BeEmpty();
        }

        [Theory]
        [InlineData(1)]
        public void Can_execute_stored_procedure_with_input_and_output_parameters_and_return_dynamic(int id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var count = 0;

            //when               
            var person = db.sp.dbo.SelectPerson_As_Dynamic_With_Input_And_Output(id, p => count = p[nameof(count)]!.GetValue<int>()).GetValue().Execute();

            //then
            ((int)person!.Id).Should().Be(id);
            count.Should().Be(id);
        }

        [Theory]
        [InlineData(0, 50)]
        public void Can_execute_stored_procedure_with_input_and_output_parameters_and_return_dynamic_list(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var count = 0;

            //when               
            var persons = db.sp.dbo.SelectPerson_As_DynamicList_With_Input_And_Output(id, p => count = p[nameof(count)]!.GetValue<int>()).GetValues().Execute();

            //then
            persons.Should().HaveCount(expected);
            count.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, 10000)]
        public void Can_execute_stored_procedure_with_input_and_inputoutput_parameter_and_return_scalar_value(int id, int creditLimit)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var outCreditLimit = 0;

            //when               
            var personId = db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput(id, creditLimit, p => outCreditLimit = p[nameof(creditLimit)]!.GetValue<int>()).GetValue<int>().Execute();

            //then
            personId.Should().Be(id);
            outCreditLimit.Should().Be(creditLimit * 2);
        }

        [Theory]
        [InlineData(1, 10000, 11)]
        public void Can_execute_stored_procedure_with_input_and_inputoutput_parameter_and_return_scalar_value_list(int id, int creditLimit, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var outCreditLimit = 0;

            //when               
            var persons = db.sp.dbo.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput(id, creditLimit, p => outCreditLimit = p[nameof(creditLimit)]!.GetValue<int>()).GetValues().Execute();

            //then
            persons.Should().HaveCount(expected);
            outCreditLimit.Should().Be(creditLimit * 2);
        }

        [Theory]
        [InlineData(1, 10000)]
        public void Can_execute_stored_procedure_with_input_and_inputoutput_parameter_and_return_dynamic_value(int id, int creditLimit)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var outCreditLimit = 0;

            //when               
            var person = db.sp.dbo.SelectPerson_As_Dynamic_With_Input_And_InputOutput(id, creditLimit, p => outCreditLimit = p[nameof(creditLimit)]!.GetValue<int>()).GetValue().Execute();

            //then
            ((int)person!.Id).Should().Be(id);
            outCreditLimit.Should().Be(creditLimit * 2);
        }

        [Theory]
        [InlineData(1, 10000, 11)]
        public void Can_execute_stored_procedure_with_input_and_inputoutput_parameter_and_return_dynamic_list(int id, int creditLimit, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var outCreditLimit = 0;

            //when               
            var persons = db.sp.dbo.SelectPerson_As_DynamicList_With_Input_And_InputOutput(id, creditLimit, p => outCreditLimit = p[nameof(creditLimit)]!.GetValue<int>()).GetValues().Execute();

            //then
            persons.Should().HaveCount(expected);
            outCreditLimit.Should().Be(creditLimit * 2);
        }

        [Theory]
        [InlineData(0, 50)]
        public void Can_execute_stored_procedure_with_input_parameter_and_use_mapping_delegate(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var persons = new List<Person>();
            var mapToPerson = dbex.GetDefaultMappingFor(dbo.Person);

            //when               
            db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).MapValues(row => 
            {
                var person = new Person();
                mapToPerson(row, person);
                persons.Add(person);
            }).Execute();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(1, 99999)]
        public void Can_execute_stored_procedure_with_input_and_output_parameter_with_no_return(int id, int creditLimit)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            db.sp.dbo.UpdatePersonCreditLimit_With_Inputs(id, creditLimit).Execute();

            //then
            var updated = db.SelectOne(dbo.Person.CreditLimit).From(dbo.Person).Where(dbo.Person.Id == id).Execute();
            updated.Should().Be(creditLimit);
        }

        [Theory]
        [InlineData(3)]
        public async Task Can_execute_async_stored_procedure_with_ignored_input_parameter_with_default_and_return_scalar_value(int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var id = await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input_And_Default_Value().GetValue<int>().ExecuteAsync();

            //then
            id.Should().Be(expected);
        }

        [Theory]
        [InlineData(1)]
        public async Task Can_execute_async_stored_procedure_with_input_parameter_and_return_dynamic(int id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var person = await db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue().ExecuteAsync();

            //then
            ((int)person!.Id).Should().Be(id);
        }

        [Theory]
        [InlineData(null)]
        public async Task Can_execute_async_stored_procedure_with_null_input_parameter_and_return_dynamic(int? id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var person = await db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue().ExecuteAsync();

            //then
            ((object?)person).Should().BeNull();
        }

        [Theory]
        [InlineData(0, 50)]
        public async Task Can_execute_async_stored_procedure_with_input_parameter_and_return_dynamic_list(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var persons = await db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues<int?>().ExecuteAsync();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(0, 50)]
        public async Task Can_execute_async_enumerable_stored_procedure_with_input_parameter_and_return_dynamic_list(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            List<int?> persons = new();

            //when               
            await foreach (var v in db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues<int?>().ExecuteAsyncEnumerable())
                persons.Add(v);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(0, 50)]
        public async Task Can_execute_async_stored_procedure_with_input_parameter_and_return_list_of_person(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var persons = await db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues(row => new Person { Id = row.ReadField()!.GetValue<int>() }).ExecuteAsync();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(0, 50)]
        public async Task Can_execute_async_enumerable_stored_procedure_with_input_parameter_and_return_list_of_person(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            List<Person> persons = new();

            //when               
            await foreach (var v in db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues(row => new Person { Id = row.ReadField()!.GetValue<int>() }).ExecuteAsyncEnumerable())
                persons.Add(v);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(0, 45, 50)]
        public async Task Can_execute_async_stored_procedure_with_input_parameter_and_command_timeout_and_return_list_of_person(int id, int expectedCommandTimeout, int expected)
        {
            //given
            int commandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.Events.OnAfterCommand(context => commandTimeout = context.DbCommand.CommandTimeout));

            //when               
            var persons = await db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues(row => new Person { Id = row.ReadField()!.GetValue<int>() }).ExecuteAsync(expectedCommandTimeout);

            //then
            persons.Should().HaveCount(expected);
            commandTimeout.Should().Be(expectedCommandTimeout);
        }

        [Theory]
        [InlineData(0, 45, 50)]
        public async Task Can_execute_async_enumerable_stored_procedure_with_input_parameter_and_command_timeout_and_return_list_of_person(int id, int expectedCommandTimeout, int expected)
        {
            //given
            int commandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.Events.OnAfterCommand(context => commandTimeout = context.DbCommand.CommandTimeout));
            List<Person> persons = new();

            //when               
            await foreach (var v in db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues(row => new Person { Id = row.ReadField()!.GetValue<int>() }).ExecuteAsyncEnumerable(expectedCommandTimeout))
                persons.Add(v);

            //then
            persons.Should().HaveCount(expected);
            commandTimeout.Should().Be(expectedCommandTimeout);
        }

        [Theory]
        [InlineData(0, 50)]
        public async Task Can_execute_async_stored_procedure_with_input_parameter_and_provided_connection_and_return_list_of_person(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            using var connection = db.GetConnection();
            var persons = await db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues(row => new Person { Id = row.ReadField()!.GetValue<int>() }).ExecuteAsync(connection);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(0, 50)]
        public async Task Can_execute_async_enumerable_stored_procedure_with_input_parameter_and_provided_connection_and_return_list_of_person(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            List<Person> persons = new();

            //when               
            using var connection = db.GetConnection();
            await foreach (var v in db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues(row => new Person { Id = row.ReadField()!.GetValue<int>() }).ExecuteAsyncEnumerable(connection))
                persons.Add(v);

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(0, 45, 50)]
        public async Task Can_execute_async_stored_procedure_with_input_parameter_and_provided_connection_and_command_timeout_and_return_list_of_person(int id, int expectedCommandTimeout, int expected)
        {
            //given
            int commandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.Events.OnAfterCommand(context => commandTimeout = context.DbCommand.CommandTimeout));

            //when               
            using var connection = db.GetConnection();
            var persons = await db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues(row => new Person { Id = row.ReadField()!.GetValue<int>() }).ExecuteAsync(connection, expectedCommandTimeout);

            //then
            persons.Should().HaveCount(expected);
            commandTimeout.Should().Be(expectedCommandTimeout);
        }

        [Theory]
        [InlineData(0, 45, 50)]
        public async Task Can_execute_async_enumerable_stored_procedure_with_input_parameter_and_provided_connection_and_command_timeout_and_return_list_of_person(int id, int expectedCommandTimeout, int expected)
        {
            //given
            int commandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.Events.OnAfterCommand(context => commandTimeout = context.DbCommand.CommandTimeout));
            List<Person> persons = new();

            //when               
            using var connection = db.GetConnection();
            await foreach (var v in db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues(row => new Person { Id = row.ReadField()!.GetValue<int>() }).ExecuteAsyncEnumerable(connection, expectedCommandTimeout))
                persons.Add(v);

            //then
            persons.Should().HaveCount(expected);
            commandTimeout.Should().Be(expectedCommandTimeout);
        }

        [Theory]
        [InlineData(null)]
        public async Task Can_execute_async_stored_procedure_with_null_input_parameter_and_return_dynamic_list(int? id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var persons = await db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues().ExecuteAsync();

            //then
            persons.Should().BeEmpty();
        }

        [Theory]
        [InlineData(null)]
        public async Task Can_execute_async_enumerable_stored_procedure_with_null_input_parameter_and_return_dynamic_list(int? id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            List<Person> persons = new();

            //when               
            await foreach (var v in db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).GetValues().ExecuteAsyncEnumerable())
                persons.Add(v);

            //then
            persons.Should().BeEmpty();
        }

        [Theory]
        [InlineData(1)]
        public async Task Can_execute_async_stored_procedure_with_input_parameter_and_return_scalar_value(int id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var value = await db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue<int>().ExecuteAsync();

            //then
            value.Should().Be(id);
        }

        [Theory]
        [InlineData(null)]
        public async Task Can_execute_async_stored_procedure_with_null_input_parameter_and_return_scalar_value(int? id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var value = await db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue<int?>().ExecuteAsync();

            //then
            value.Should().BeNull();
        }

        [Theory]
        [InlineData(0, 50)]
        public async Task Can_execute_async_stored_procedure_with_input_parameter_and_return_scalar_value_list(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var values = await db.sp.dbo.SelectPersonId_As_ScalarValueList_With_Input(id).GetValues<int>().ExecuteAsync();

            //then
            values.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(0, 50)]
        public async Task Can_execute_async_enumerable_stored_procedure_with_input_parameter_and_return_scalar_value_list(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            List<int> values = new();

            //when               
            await foreach (var v in db.sp.dbo.SelectPersonId_As_ScalarValueList_With_Input(id).GetValues<int>().ExecuteAsyncEnumerable())
                values.Add(v);

            //then
            values.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(null)]
        public async Task Can_execute_async_stored_procedure_with_null_input_parameter_and_return_scalar_value_list(int? id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var values = await db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValues<int?>().ExecuteAsync();

            //then
            values.Should().BeEmpty();
        }

        [Theory]
        [InlineData(null)]
        public async Task Can_execute_async_enumerable_stored_procedure_with_null_input_parameter_and_return_scalar_value_list(int? id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            List<int?> values = new();

            //when               
            await foreach (var v in db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValues<int?>().ExecuteAsyncEnumerable())
                values.Add(v);

            //then
            values.Should().BeEmpty();
        }

        [Theory]
        [InlineData(1)]
        public async Task Can_execute_async_stored_procedure_with_input_and_output_parameters_and_return_dynamic(int id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var count = 0;

            //when               
            var person = await db.sp.dbo.SelectPerson_As_Dynamic_With_Input_And_Output(id, p => count = p[nameof(count)]!.GetValue<int>()).GetValue().ExecuteAsync();

            //then
            ((int)person!.Id).Should().Be(id);
            count.Should().Be(id);
        }

        [Theory]
        [InlineData(0, 50)]
        public async Task Can_execute_async_stored_procedure_with_input_and_output_parameters_and_return_dynamic_list(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var count = 0;

            //when               
            var persons = await db.sp.dbo.SelectPerson_As_DynamicList_With_Input_And_Output(id, p => count = p[nameof(count)]!.GetValue<int>()).GetValues().ExecuteAsync();

            //then
            persons.Should().HaveCount(expected);
            count.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 50)]
        public async Task Can_execute_async_enumerable_stored_procedure_with_input_and_output_parameters_and_return_dynamic_list(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            List<dynamic> persons = new();
            var count = 0;

            //when               
            await foreach (var v in db.sp.dbo.SelectPerson_As_DynamicList_With_Input_And_Output(id, p => count = p[nameof(count)]!.GetValue<int>()).GetValues().ExecuteAsyncEnumerable())
                persons.Add(v);

            //then
            persons.Should().HaveCount(expected);
            count.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, 10000)]
        public async Task Can_execute_async_stored_procedure_with_input_and_inputoutput_parameter_and_return_scalar_value(int id, int creditLimit)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var outCreditLimit = 0;

            //when               
            var personId = await db.sp.dbo.SelectPersonId_As_ScalarValue_With_Input_And_InputOutput(id, creditLimit, p => outCreditLimit = p[nameof(creditLimit)]!.GetValue<int>()).GetValue<int>().ExecuteAsync();

            //then
            personId.Should().Be(id);
            outCreditLimit.Should().Be(creditLimit * 2);
        }

        [Theory]
        [InlineData(1, 10000, 11)]
        public async Task Can_execute_async_stored_procedure_with_input_and_inputoutput_parameter_and_return_scalar_value_list(int id, int creditLimit, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var outCreditLimit = 0;

            //when               
            var persons = await db.sp.dbo.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput(id, creditLimit, p => outCreditLimit = p[nameof(creditLimit)]!.GetValue<int>()).GetValues().ExecuteAsync();

            //then
            persons.Should().HaveCount(expected);
            outCreditLimit.Should().Be(creditLimit * 2);
        }

        [Theory]
        [InlineData(1, 10000, 11)]
        public async Task Can_execute_async_enumerable_stored_procedure_with_input_and_inputoutput_parameter_and_return_scalar_value_list(int id, int creditLimit, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            List<dynamic> persons = new();
            var outCreditLimit = 0;

            //when               
            await foreach (var v in db.sp.dbo.SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput(id, creditLimit, p => outCreditLimit = p[nameof(creditLimit)]!.GetValue<int>()).GetValues().ExecuteAsyncEnumerable())
                persons.Add(v);

            //then
            persons.Should().HaveCount(expected);
            outCreditLimit.Should().Be(creditLimit * 2);
        }

        [Theory]
        [InlineData(1, 10000)]
        public async Task Can_execute_async_stored_procedure_with_input_and_inputoutput_parameter_and_return_dynamic_value(int id, int creditLimit)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var outCreditLimit = 0;

            //when               
            var person = await db.sp.dbo.SelectPerson_As_Dynamic_With_Input_And_InputOutput(id, creditLimit, p => outCreditLimit = p[nameof(creditLimit)]!.GetValue<int>()).GetValue().ExecuteAsync();

            //then
            ((int)person!.Id).Should().Be(id);
            outCreditLimit.Should().Be(creditLimit * 2);
        }

        [Theory]
        [InlineData(1, 10000, 11)]
        public async Task Can_execute_async_stored_procedure_with_input_and_inputoutput_parameter_and_return_dynamic_list(int id, int creditLimit, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var outCreditLimit = 0;

            //when               
            var persons = await db.sp.dbo.SelectPerson_As_DynamicList_With_Input_And_InputOutput(id, creditLimit, p => outCreditLimit = p[nameof(creditLimit)]!.GetValue<int>()).GetValues().ExecuteAsync();

            //then
            persons.Should().HaveCount(expected);
            outCreditLimit.Should().Be(creditLimit * 2);
        }

        [Theory]
        [InlineData(1, 10000, 11)]
        public async Task Can_execute_async_enumerable_stored_procedure_with_input_and_inputoutput_parameter_and_return_dynamic_list(int id, int creditLimit, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            List<dynamic> persons = new();
            var outCreditLimit = 0;

            //when               
            await foreach (var v in db.sp.dbo.SelectPerson_As_DynamicList_With_Input_And_InputOutput(id, creditLimit, p => outCreditLimit = p[nameof(creditLimit)]!.GetValue<int>()).GetValues().ExecuteAsyncEnumerable())
                persons.Add(v);

            //then
            persons.Should().HaveCount(expected);
            outCreditLimit.Should().Be(creditLimit * 2);
        }

        [Theory]
        [InlineData(1)]
        public async Task Can_execute_async_stored_procedure_with_input_parameter_and_return_a_person(int id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            var person = await db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue(row => new Person { Id = row.ReadField()!.GetValue<int>() }).ExecuteAsync();

            //then
            person.Should().NotBeNull();
            person!.Id.Should().Be(id);
        }

        [Theory]
        [InlineData(1, 45)]
        public async Task Can_execute_async_stored_procedure_with_input_parameter_and_command_timeout_and_return_a_person(int id, int expectedCommandTimeout)
        {
            //given
            int commandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.Events.OnAfterCommand(context => commandTimeout = context.DbCommand.CommandTimeout));

            //when               
            var person = await db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue(row => new Person { Id = row.ReadField()!.GetValue<int>() }).ExecuteAsync(expectedCommandTimeout);

            //then
            person.Should().NotBeNull();
            person!.Id.Should().Be(id);
            commandTimeout.Should().Be(expectedCommandTimeout);
        }

        [Theory]
        [InlineData(1)]
        public async Task Can_execute_async_stored_procedure_with_input_parameter_and_provided_connection_and_return_a_person(int id)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            using var connection = db.GetConnection();
            var person = await db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue(row => new Person { Id = row.ReadField()!.GetValue<int>() }).ExecuteAsync(connection);

            //then
            person.Should().NotBeNull();
            person!.Id.Should().Be(id);
        }

        [Theory]
        [InlineData(1, 45)]
        public async Task Can_execute_async_stored_procedure_with_input_parameter_and_provided_connection_and_command_timeout_and_return_a_person(int id, int expectedCommandTimeout)
        {
            //given
            int commandTimeout = 0;
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.Events.OnAfterCommand(context => commandTimeout = context.DbCommand.CommandTimeout));

            //when               
            using var connection = db.GetConnection();
            var person = await db.sp.dbo.SelectPerson_As_Dynamic_With_Input(id).GetValue(row => new Person { Id = row.ReadField()!.GetValue<int>() }).ExecuteAsync(connection, expectedCommandTimeout);

            //then
            person.Should().NotBeNull();
            person!.Id.Should().Be(id);
            commandTimeout.Should().Be(expectedCommandTimeout);
        }

        [Theory]
        [InlineData(0, 50)]
        public async Task Can_execute_async_stored_procedure_with_input_parameter_and_use_mapping_delegate(int id, int expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var persons = new List<Person>();
            var mapToPerson = dbex.GetDefaultMappingFor(dbo.Person);

            //when               
            await db.sp.dbo.SelectPerson_As_DynamicList_With_Input(id).MapValues(row =>
            {
                var person = new Person();
                mapToPerson(row, person);
                persons.Add(person);
            }).ExecuteAsync();

            //then
            persons.Should().HaveCount(expected);
        }

        [Theory]
        [InlineData(1, 99999)]
        public async Task Can_execute_async_stored_procedure_with_input_and_output_parameter_with_no_return(int id, int creditLimit)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            //when               
            await db.sp.dbo.UpdatePersonCreditLimit_With_Inputs(id, creditLimit).ExecuteAsync();

            //then
            var updated = await db.SelectOne(dbo.Person.CreditLimit).From(dbo.Person).Where(dbo.Person.Id == id).ExecuteAsync();
            updated.Should().Be(creditLimit);
        }
    }
}
