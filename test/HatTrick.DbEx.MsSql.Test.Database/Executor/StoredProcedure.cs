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
using System.Threading.Tasks;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Database.Executor
{
    [Trait("Statement", "STORED_PROCEDURE")]
    public partial class StoredProcedure : ExecutorTestBase
    {
        private async Task ScratchPad(int version)
        {
            int? _nullable_int = 0;
            dynamic _dynamic = null;
            IList<int> _int_list = null;
            IList<dynamic> _dynamic_list = null;

            //sync
            db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).Execute();

            //sync
            db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).MapValues(row => row.ReadField().GetValue<int>()).Execute();

            _nullable_int = db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).GetValue<int?>().Execute();
            var x = db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).GetValue<AddressType>().Execute();
            _int_list = db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).GetValues<int>().Execute();
            db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).MapValues(row => row.ReadField().GetValue<int>()).Execute();
            _dynamic = db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).GetValue().Execute();
            _dynamic_list = db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).GetValues().Execute();


            //async
            await db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).ExecuteAsync();

            _nullable_int = await db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).GetValue<int>().ExecuteAsync();
            _int_list = await db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).GetValues<int>().ExecuteAsync();
            await db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).MapValues(row => row.ReadField().GetValue<int>()).ExecuteAsync();
            _dynamic = await db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).GetValue().ExecuteAsync();
            _dynamic_list = await db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).GetValues().ExecuteAsync();

            //sync
            db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, (name, value) => { })).Execute();
            _nullable_int = db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, (name, value) => { })).GetValue<int>().Execute();
            db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, (name, value) => { })).MapValues(row => row.ReadField().GetValue<int>()).Execute();
            _dynamic = db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, (name, value) => { })).GetValue().Execute();
            _dynamic_list = db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, (name, value) => { })).GetValues().Execute();


            //async
            await db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, (name, value) => { })).ExecuteAsync();
            _nullable_int = await db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, (name, value) => { })).GetValue<int>().ExecuteAsync();
            await db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, (name, value) => { })).MapValues(row => row.ReadField().GetValue<int>()).ExecuteAsync();
            _dynamic = await db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, (name, value) => { })).GetValue().ExecuteAsync();
            _dynamic_list = await db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, (name, value) => { })).GetValues().ExecuteAsync();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_execute_stored_procedure_with_input_parameters_and_no_output_pararameters_and_no_return(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when               
            db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).Execute();

            //then
            //no exceptions
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_execute_stored_procedure_with_input_parameters_and_return_scalar_value(int version, int expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when               
            int scalarValue = db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(expected, 2)).GetValue<int>().Execute();

            //then
            scalarValue.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_execute_stored_procedure_with_input_parameters_and_return_nullable_scalar_value(int version, int expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when               
            int? scalarValue = db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(expected, 2)).GetValue<int?>().Execute();

            //then
            scalarValue.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_execute_stored_procedure_with_input_parameters_map_to_list_of_scalar_values(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var ids = new List<int>();

            //when               
            db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).MapValues(row => ids.Add(row.ReadField().GetValue<int>())).Execute();

            //then
            ids.Should().HaveCountGreaterOrEqualTo(2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_execute_stored_procedure_with_input_parameters_and_return_dynamic_value(int version, int expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when               
            dynamic person = db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).GetValue().Execute();

            //then
            ((int)person.Id).Should().Be(expected);
            ((string)person.FirstName).Should().NotBeNullOrWhiteSpace();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_execute_stored_procedure_with_input_parameters_and_return_dynamic_list(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when               
            IList<dynamic> persons = db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).GetValues().Execute();

            //then
            persons.Should().HaveCount(expected);
            persons.Select(p => p.Id).Should().BeEquivalentTo(Enumerable.Range(1, 50));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_execute_stored_procedure_with_input_parameters_and_output_pararameters_and_no_return(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            int Id = 0;
            string FullName = null;
            void map(string name, object value)
            {
                if (name == nameof(Id))
                    Id = (int)value;
                if (name == nameof(FullName))
                    FullName = (string)value;
            };

            //when               
            db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, map)).Execute();

            //then
            Id.Should().BeGreaterThan(0);
            FullName.Should().NotBeNullOrWhiteSpace();
            FullName.Should().Contain(" ");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_execute_stored_procedure_with_input_parameters_and_output_pararameters_and_scalar_return(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            int Id = 0;
            string FullName = null;
            void map(string name, object value)
            {
                if (name == nameof(Id))
                    Id = (int)value;
                if (name == nameof(FullName))
                    FullName = (string)value;
            };

            //when               
            int? scalarValue = db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, map)).GetValue<int>().Execute();

            //then
            Id.Should().BeGreaterThan(0);
            FullName.Should().NotBeNullOrWhiteSpace();
            FullName.Should().Contain(" ");
            scalarValue.Should().BeGreaterThan(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_execute_stored_procedure_with_input_parameters_and_output_pararameters_and_list_of_int_return(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var ids = new List<int>();
            int Id = 0;
            string FullName = null;
            void map(string name, object value)
            {
                if (name == nameof(Id))
                    Id = (int)value;
                if (name == nameof(FullName))
                    FullName = (string)value;
            };

            //when               
            db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, map)).MapValues(row => ids.Add(row.ReadField().GetValue<int>())).Execute();

            //then
            Id.Should().BeGreaterThan(0);
            FullName.Should().NotBeNullOrWhiteSpace();
            FullName.Should().Contain(" ");
            ids.Should().HaveCount(50);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_execute_stored_procedure_with_input_parameters_and_output_pararameters_and_dynamic_return(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            int Id = 0;
            string FullName = null;
            void map(string name, object value)
            {
                if (name == nameof(Id))
                    Id = (int)value;
                if (name == nameof(FullName))
                    FullName = (string)value;
            };

            //when               
            var person = db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, map)).GetValue().Execute();

            //then
            Id.Should().BeGreaterThan(0);
            FullName.Should().NotBeNullOrWhiteSpace();
            FullName.Should().Contain(" ");
            ((string)person.FirstName).Should().NotBeNullOrWhiteSpace();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_execute_stored_procedure_with_input_parameters_and_output_pararameters_and_dynamic_list_return(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            int Id = 0;
            string FullName = null;
            void map(string name, object value)
            {
                if (name == nameof(Id))
                    Id = (int)value;
                if (name == nameof(FullName))
                    FullName = (string)value;
            };

            //when               
            IList<dynamic> persons = db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, map)).GetValues().Execute();

            //then
            Id.Should().BeGreaterThan(0);
            FullName.Should().NotBeNullOrWhiteSpace();
            FullName.Should().Contain(" ");
            persons.Should().HaveCount(50);
            persons.Select(p => p.Id).Should().BeEquivalentTo(Enumerable.Range(1, 50));

        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Can_execute_stored_procedure_with_input_parameters_and_output_pararameters_with_input_parameter_with_null_value_and_dynamic_list_return(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            int Id = 0;
            string FullName = null;
            void map(string name, object value)
            {
                if (name == nameof(Id))
                    Id = (int)value;
                if (name == nameof(FullName))
                    FullName = (string)value;
            };

            //when               
            IList<dynamic> persons = db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson((int?)null, 2, map)).GetValues().Execute();

            //map is Action<MyStoredProcedureWithOutputParameters_OutputParameters>
            //code gen MyStoredProcedureWithOutputParameters_Parameters and MyStoredProcedureWithOutputParameters_OutputParameters, if the parameter is InputOutput, it would appear in both classes.
            //note that dbo.MyStoredProcedureWithOutputParameters is property, no longer a method

            //IList<dynamic> persons = db.Exec(dbo.MyStoredProcedureWithOutputParameters.WithInputParameters(new MyStoredProcedureWithOutputParameters_Parameters { P1 = 1, P2 = 2 }).WithOutputParameters(map))).MapDynamicList().Execute();

            //then
            Id.Should().BeGreaterThan(0);
            FullName.Should().NotBeNullOrWhiteSpace();
            FullName.Should().Contain(" ");
            persons.Should().HaveCount(50);
            persons.Select(p => p.Id).Should().BeEquivalentTo(Enumerable.Range(1, 50));

        }

        //[Theory]
        //[MsSqlVersions.AllVersions]
        //public void enum_test(int version)
        //{
        //    //given
        //    ConfigureForMsSqlVersion(version);
        //    int Id = 0;
        //    string FullName = null;
        //    void map(string name, object value)
        //    {
        //        if (name == nameof(Id))
        //            Id = (int)value;
        //        if (name == nameof(FullName))
        //            FullName = (string)value;
        //    };

        //    //when               
        //    IList<AddressType> persons = db.sp(dbo.MyStoredProcedure(1, 2)).GetValues<AddressType>().Execute();

        //    //then
        //}


        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_execute_async_stored_procedure_with_input_parameters_and_no_output_pararameters_and_no_return(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when               
            await db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).ExecuteAsync();

            //then
            //no exceptions
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_execute_async_stored_procedure_with_input_parameters_and_return_scalar_value(int version, int expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when               
            int scalarValue = await db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(expected, 2)).GetValue<int>().ExecuteAsync();

            //then
            scalarValue.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_execute_async_stored_procedure_with_input_parameters_and_return_nullable_scalar_value(int version, int expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when               
            int? scalarValue = await db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(expected, 2)).GetValue<int?>().ExecuteAsync();

            //then
            scalarValue.Value.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_execute_async_stored_procedure_with_input_parameters_and_map_to_list_of_scalar_values(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var ids = new List<int>();

            //when               
            await db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).MapValues(row => ids.Add(row.ReadField().GetValue<int>())).ExecuteAsync();

            //then
            ids.Should().HaveCountGreaterOrEqualTo(2);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_execute_async_stored_procedure_with_input_parameters_and_return_dynamic_value(int version, int expected = 1)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when               
            dynamic person = await db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).GetValue().ExecuteAsync();

            //then
            ((int)person.Id).Should().Be(expected);
            ((string)person.FirstName).Should().NotBeNullOrWhiteSpace();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_execute_async_stored_procedure_with_input_parameters_and_return_dynamic_list(int version, int expected = 50)
        {
            //given
            ConfigureForMsSqlVersion(version);

            //when               
            IList<dynamic> persons = await db.sp(dbo.UpdatePersonCreditLimitAndReturnPerson(1, 2)).GetValues().ExecuteAsync();

            //then
            persons.Should().HaveCount(expected);
            persons.Select(p => p.Id).Should().BeEquivalentTo(Enumerable.Range(1, 50));
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_execute_async_stored_procedure_with_input_parameters_and_output_pararameters_and_no_return(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            int Id = 0;
            string FullName = null;
            void map(string name, object value)
            {
                if (name == nameof(Id))
                    Id = (int)value;
                if (name == nameof(FullName))
                    FullName = (string)value;
            };

            //when               
            await db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, map)).ExecuteAsync();

            //then
            Id.Should().BeGreaterThan(0);
            FullName.Should().NotBeNullOrWhiteSpace();
            FullName.Should().Contain(" ");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_execute_async_stored_procedure_with_input_parameters_and_output_pararameters_and_scalar_return(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            int Id = 0;
            string FullName = null;
            void map(string name, object value)
            {
                if (name == nameof(Id))
                    Id = (int)value;
                if (name == nameof(FullName))
                    FullName = (string)value;
            };

            //when               
            int scalarValue = await db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, map)).GetValue<int>().ExecuteAsync();

            //then
            Id.Should().BeGreaterThan(0);
            FullName.Should().NotBeNullOrWhiteSpace();
            FullName.Should().Contain(" ");
            scalarValue.Should().BeGreaterThan(0);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_execute_async_stored_procedure_with_input_parameters_and_output_pararameters_and_list_of_int_return(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            var ids = new List<int>();
            int Id = 0;
            string FullName = null;
            void map(string name, object value)
            {
                if (name == nameof(Id))
                    Id = (int)value;
                if (name == nameof(FullName))
                    FullName = (string)value;
            };

            //when               
            await db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, map)).MapValues(row => ids.Add(row.ReadField().GetValue<int>())).ExecuteAsync();

            //then
            Id.Should().BeGreaterThan(0);
            FullName.Should().NotBeNullOrWhiteSpace();
            FullName.Should().Contain(" ");
            ids.Should().HaveCount(50);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_execute_async_stored_procedure_with_input_parameters_and_output_pararameters_and_dynamic_return(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            int Id = 0;
            string FullName = null;
            void map(string name, object value)
            {
                if (name == nameof(Id))
                    Id = (int)value;
                if (name == nameof(FullName))
                    FullName = (string)value;
            };

            //when               
            var person = await db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, map)).GetValue().ExecuteAsync();

            //then
            Id.Should().BeGreaterThan(0);
            FullName.Should().NotBeNullOrWhiteSpace();
            FullName.Should().Contain(" ");
            ((string)person.FirstName).Should().NotBeNullOrWhiteSpace();
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public async Task Can_execute_async_stored_procedure_with_input_parameters_and_output_pararameters_and_dynamic_list_return(int version)
        {
            //given
            ConfigureForMsSqlVersion(version);
            int Id = 0;
            string FullName = null;
            void map(string name, object value)
            {
                if (name == nameof(Id))
                    Id = (int)value;
                if (name == nameof(FullName))
                    FullName = (string)value;
            };

            //when               
            IList<dynamic> persons = await db.sp(dbo.UpdatePersonCreditLimitWithOutputParametersAndReturnPerson(1, 2, map)).GetValues().ExecuteAsync();

            //then
            Id.Should().BeGreaterThan(0);
            FullName.Should().NotBeNullOrWhiteSpace();
            FullName.Should().Contain(" ");
            persons.Should().HaveCount(50);
            persons.Select(p => p.Id).Should().BeEquivalentTo(Enumerable.Range(1, 50));

        }
    }
}
