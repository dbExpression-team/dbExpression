using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboData;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboDataService;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using Field = HatTrick.DbEx.Sql.Executor.Field;

namespace HatTrick.DbEx.MsSql.Benchmark
{
    public class PersonRowReader : ISqlRowReader, IAsyncSqlRowReader
    {
        private static readonly Person person = new()
        {
            Id = 1,
            BirthDate = new DateTime(),
            CreditLimit = 1000,
            FirstName = "First",
            LastName = "Last",
            YearOfLastCreditLimitReview = 2010,
            DateCreated = new DateTime(),
            DateUpdated = new DateTime(),
            GenderType = GenderType.Female,
            LastLoginDate = new DateTime(),
            RegistrationDate = new DateTime()
        }; 
        private readonly IValueConverterProvider valueConverterProvider;
        private ISqlFieldReader fieldReader;

        public PersonRowReader(IValueConverterProvider valueConverterProvider)
        {
            this.valueConverterProvider = valueConverterProvider;
        }

        public void Close() { }

        public void Dispose() { }

        public ISqlFieldReader ReadRow()
            => CreateRow();

        public Task<ISqlFieldReader> ReadRowAsync()
            => Task.FromResult(CreateRow());

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async IAsyncEnumerable<ISqlFieldReader> ReadRowAsyncEnumerable([EnumeratorCancellation] CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            yield return CreateRow();
        }

        private ISqlFieldReader CreateRow()
        {
            if (fieldReader is not null)
                return null; //ensure this method returns only 1 row when invoked

            int zero = 0;
            int one = 1;
            int two = 2;
            int three = 3;
            int four = 4;
            int five = 5;
            int six = 6;
            int seven = 7;
            int eight = 8;
            int nine = 9;
            int ten = 10;

            fieldReader = new Row(ref zero, new ISqlField[11]
                {
                    new Field(ref zero, nameof(dbo.Person.Id), typeof(int), person.Id, valueConverterProvider),
                    new Field(ref one, nameof(dbo.Person.FirstName), typeof(string), person.FirstName, valueConverterProvider),
                    new Field(ref two, nameof(dbo.Person.LastName), typeof(string), person.LastName, valueConverterProvider),
                    new Field(ref three, nameof(dbo.Person.BirthDate), typeof(DateTime?), person.BirthDate, valueConverterProvider),
                    new Field(ref four, nameof(dbo.Person.GenderType), typeof(GenderType), person.GenderType, valueConverterProvider),
                    new Field(ref five, nameof(dbo.Person.CreditLimit), typeof(int?), person.CreditLimit, valueConverterProvider),
                    new Field(ref six, nameof(dbo.Person.YearOfLastCreditLimitReview), typeof(int?), person.YearOfLastCreditLimitReview,valueConverterProvider),
                    new Field(ref seven, nameof(dbo.Person.RegistrationDate), typeof(DateTimeOffset), person.RegistrationDate, valueConverterProvider),
                    new Field(ref eight, nameof(dbo.Person.LastLoginDate), typeof(DateTimeOffset?), person.LastLoginDate, valueConverterProvider),
                    new Field(ref nine, nameof(dbo.Person.DateCreated), typeof(DateTime), person.DateCreated, valueConverterProvider),
                    new Field(ref ten, nameof(dbo.Person.DateUpdated), typeof(DateTime), person.DateUpdated, valueConverterProvider),
                });
            return fieldReader;
        }
    }
}