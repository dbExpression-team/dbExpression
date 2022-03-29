using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboData;
using HatTrick.DbEx.MsSql.Benchmark.dbExpression.dboDataService;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Executor;
using System;
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

        private ISqlFieldReader CreateRow()
        {
            if (fieldReader is object)
                return default;
            fieldReader = new Row(0, new ISqlField[11]
                {
                    new Field(0, nameof(dbo.Person.Id), typeof(int), person.Id, (f, t) => valueConverterProvider.FindConverter(0, t, f.RawValue)),
                    new Field(1, nameof(dbo.Person.FirstName), typeof(string), person.FirstName, (f, t) => valueConverterProvider.FindConverter(1, t, person.FirstName)),
                    new Field(2, nameof(dbo.Person.LastName), typeof(string), person.LastName, (f, t) => valueConverterProvider.FindConverter(2, t, person.LastName)),
                    new Field(3, nameof(dbo.Person.BirthDate), typeof(DateTime?), person.BirthDate, (f, t) => valueConverterProvider.FindConverter(3, t, person.BirthDate)),
                    new Field(4, nameof(dbo.Person.GenderType), typeof(GenderType), person.GenderType, (f, t) => valueConverterProvider.FindConverter(4, t, person.GenderType)),
                    new Field(5, nameof(dbo.Person.CreditLimit), typeof(int?), person.CreditLimit, (f, t) => valueConverterProvider.FindConverter(5, t, person.CreditLimit)),
                    new Field(6, nameof(dbo.Person.YearOfLastCreditLimitReview), typeof(int?), person.YearOfLastCreditLimitReview, (f, t) => valueConverterProvider.FindConverter(6, t, person.YearOfLastCreditLimitReview)),
                    new Field(7, nameof(dbo.Person.RegistrationDate), typeof(DateTimeOffset), person.RegistrationDate, (f, t) => valueConverterProvider.FindConverter(7, t, person.RegistrationDate)),
                    new Field(8, nameof(dbo.Person.LastLoginDate), typeof(DateTimeOffset?), person.LastLoginDate, (f, t) => valueConverterProvider.FindConverter(8, t, person.LastLoginDate)),
                    new Field(9, nameof(dbo.Person.DateCreated), typeof(DateTime), person.DateCreated, (f, t) => valueConverterProvider.FindConverter(9, t, person.DateCreated)),
                    new Field(10, nameof(dbo.Person.DateUpdated), typeof(DateTime), person.DateUpdated, (f, t) => valueConverterProvider.FindConverter(10, t, person.DateUpdated)),
                });
            return fieldReader;
        }
    }
}