using HTL.DbEx.MsSql.Assembler;
using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Expression;
using HTL.DbEx.Sql.Assembler;
using System;
using System.Configuration;
using System.Collections.Generic;

namespace HTL.DbEx.MsSql.Builder._New.Test
{
    using db = MsSqlBuilder;
    using dbo = MySchema;

    public static class MySchema
    {
        public static void Test()
        {
            DBExpressionConfiguration.ConnectionStringSettings = ConfigurationManager.ConnectionStrings["cq.genres"];
            DBExpressionConfiguration.AssemblerFactory = new MsSqlAssemblerFactory();
            DBExpressionConfiguration.ParameterBuilderFactory = new MsSqlParameterBuilderFactory();

            //db.Delete().From(dbo.person).Execute();
            //db.Insert(new Person { FirstName = "Bob", LastName = "Smith" }).Into(dbo.person).Execute();
            //db.Update(dbo.person.FirstName.Set("bob"), dbo.person.LastName.Set("Smith")).From(dbo.person).Where(dbo.person.Id == 3).Execute(null);
            //db.Select<Person>().From(dbo.person).Execute();
            //db.Select(dbo.person.Id, dbo.person.FirstName, dbo.person.LastName).From(dbo.person).Where(dbo.person.FirstName.Like("bob%") & (dbo.person.LastName == "Smith" | dbo.person.LastName == "Jones")).InnerJoin(dbo.address).On(dbo.person.Id == dbo.address.Id).Execute();
            //db.Select(dbo.person.Id, (dbo.person.FirstName + dbo.person.LastName).As("foo")).From(dbo.person)
            //    .Where(dbo.person.Id.In(1,2,3) &  dbo.person.FirstName.Like("bob%") & (dbo.person.LastName >= "Smith" | dbo.person.LastName == "Jones")).InnerJoin(dbo.address).On(dbo.person.Id == dbo.address.Id)
            //    .Execute();
            //db.SelectAll(dbo.person.Id + 3, (dbo.person.FirstName + dbo.person.LastName).As("foo")).From(dbo.person)
            //    .Where(dbo.person.Id == 3 & dbo.person.Id.In(1, 2, 3) & dbo.person.FirstName.Like("bob%") & (dbo.person.LastName >= "Smith" | dbo.person.LastName == "Jones")).InnerJoin(dbo.address).On(dbo.person.Id == dbo.address.Id)
            //    .GroupBy(dbo.person.Id, dbo.person.LastName)
            //    .OrderBy(dbo.person.FirstName.Asc, dbo.person.LastName.Desc)
            //    .Execute();

            IList<dynamic> results = db.SelectAll(dbo.person.Id.Sum(), dbo.person.Id + 3, (dbo.person.FirstName + dbo.person.LastName).As("foo")).From(dbo.person)
                .Where(dbo.person.Id == 3 & dbo.person.Id.In(1, 2, 3) & dbo.person.FirstName.Like("bob%") & (dbo.person.LastName >= "Smith" | dbo.person.LastName == "Jones")).InnerJoin(dbo.address).On(dbo.person.Id == dbo.address.Id)
                .GroupBy(dbo.person.Id, dbo.person.LastName)
                .OrderBy(dbo.person.FirstName.Asc, dbo.person.LastName.Desc)
                .Execute();

            //db.Select(dbo.person.Id).From(dbo.person).Where(dbo.person.FirstName == "bob").Execute();
            IList<Person> persons = db.SelectAll<Person>().From(dbo.person).Skip(9).Limit(10).InnerJoin(dbo.address).On(dbo.person.Id == dbo.address.Id).OrderBy(dbo.person.FirstName.Asc).Execute();
            //db.SelectAll(dbo.person.Id, dbo.person.FirstName).From(dbo.person).Where(dbo.person.FirstName.Like("bob%")).InnerJoin(dbo.address).On(dbo.person.Id == dbo.address.Id).Execute();
            Person person = db.Select<Person>().From(dbo.person).InnerJoin(dbo.person).On(dbo.address.Id == dbo.person.Id).Execute();


            db.SelectAll<Person>().From(dbo.person).Skip(9).Limit(10).InnerJoin(dbo.address).On(dbo.person.Id == dbo.address.Id).OrderBy(dbo.person.LastName.Asc, dbo.person.FirstName.Desc).Execute();
        }

        public static PersonEntity person => new PersonEntity();
        public static AddressEntity address => new AddressEntity();

        public class Person : IDBEntity
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Address : IDBEntity { }
        public class PersonEntity : DBExpressionEntity<Person>
        {
            public DBExpressionField<int> Id => new DBExpressionField<int>(this, "Id");
            public DBExpressionField<string> FirstName => new DBExpressionField<string>(this, "FirstName");
            public DBExpressionField<string> LastName => new DBExpressionField<string>(this, "LastName");

            public PersonEntity() : base("dbo", "Person") { }

            public override void FillObject(Person entity, object[] values)
            {
                throw new NotImplementedException();
            }

            public override DBInsertExpressionSet GetInclusiveInsertExpression(Person entity)
            {
                DBInsertExpressionSet expr = null;
                expr &= Id.Insert(entity.Id);
                expr &= FirstName.Insert(entity.FirstName);
                expr &= LastName.Insert(entity.LastName);
                return expr;
            }

            public override DBSelectExpressionSet GetInclusiveSelectExpression()
            {
                return Id & FirstName & LastName;
            }
        }
        public class AddressEntity : DBExpressionEntity<Address>
        {
            public DBExpressionField<int> Id => new DBExpressionField<int>(this, "Id");
            public DBExpressionField<string> AddressLine1 => new DBExpressionField<string>(this, "AddressLine1");
            public DBExpressionField<string> City => new DBExpressionField<string>(this, "City");

            public AddressEntity() : base("dbo", "Address") { }

            public override void FillObject(Address entity, object[] values)
            {
                throw new NotImplementedException();
            }

            public override DBInsertExpressionSet GetInclusiveInsertExpression(Address entity)
            {
                throw new NotImplementedException();
            }

            public override DBSelectExpressionSet GetInclusiveSelectExpression()
            {
                throw new NotImplementedException();
            }
        }
    }
}
