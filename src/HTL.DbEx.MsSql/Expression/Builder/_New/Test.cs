using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Expression;
using System;

namespace HTL.DbEx.MsSql.Expression._New.Test
{
    using db = MsSqlBuilder;
    using dbo = MySchema;

    public static class MySchema
    {
        public static void Test()
        {
            db.Delete().From(dbo.person);
            db.Insert(new Person()).Into(dbo.person); //.Execute();
            db.Update(dbo.person.FirstName.Set("bob")).From(dbo.person).Where(dbo.person.Id == 3).Execute(null);
            db.Select<Person>().From(dbo.address); //.Execute();
            db.Select(dbo.person.Id, dbo.person.FirstName).From(dbo.person).Where(dbo.person.FirstName.Like("bob%")).InnerJoin(dbo.address).On(dbo.person.Id == dbo.address.Id); //.Execute();
            db.Select(dbo.person.Id).From(dbo.person).Where(dbo.person.FirstName == "bob"); //.Execute();
            db.SelectAll<Person>().From(dbo.person).Skip(9).Limit(10).InnerJoin(dbo.address).On(dbo.person.Id == dbo.address.Id); //.Execute();
            db.SelectAll(dbo.person.Id, dbo.person.FirstName).From(dbo.person).Where(dbo.person.FirstName.Like("bob%")).InnerJoin(dbo.address).On(dbo.person.Id == dbo.address.Id); //.Execute();
            db.Select<Person>().From(dbo.address).InnerJoin(dbo.person).On(dbo.address.Id == dbo.person.Id); //.Execute();
        }

        public static PersonEntity person => new PersonEntity();
        public static AddressEntity address => new AddressEntity();

        public class Person : IDBEntity { }

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
                throw new NotImplementedException();
            }

            public override DBSelectExpressionSet GetInclusiveSelectExpression()
            {
                throw new NotImplementedException();
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
