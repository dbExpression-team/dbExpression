using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using HTL.DbEx.Sql;
using HTL.DbEx.MsSql;
using HTL.DbEx.Sql.Expression;
using HTL.DbEx.MsSql.Expression;

namespace HTL.DbEx.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person() { Id = 3, FirstName = "John", LastName = "Doe" };

            var p = dbo.Person;

            dbo.Insert(person).Into(p);

            dbo.Insert(new xxx() { YYY = "" }).Into(p);

            //dbo.Select<Person>().From(p);
            dbo.Select().From(p);

            dbo.Select<string>((p.FirstName + " " + p.LastName).As("FullName")).From(p);

            dbo.Update(p.FirstName.Set("Jorge"), p.LastName.Set("Gonzolas")).From(p).Where(p.Id == 3);

            dbo.Delete().From(p).Where(p.Id == 3);
        }

        public class xxx
        {
            public string YYY { get; set; }
        }

        public static class dbo
        {
            public static IFromEntitySelector<T> Select<T>(params DBExpressionField[] fields)
            {
                return new EntitySelector<T>();
            }

            public static IFromEntitySelector<T> Select<T>(DBSelectExpression select)
            {
                return new EntitySelector<T>();
            }

            public static IFromEntitySelector Select()
            {
                return new EntitySelector();
            }

            public static IIntoEntitySelector<T> Insert<T>(T record)
            {
                return new EntitySelector<T>();
            }

            public static IFromEntitySelector Update(params DBAssignmentExpression[] assignmentExpressions)
            {
                return new EntitySelector();
            }

            public static IFromEntitySelector Delete()
            {
                return new EntitySelector();
            }

            private static PersonEntity _person;
            public static PersonEntity Person { get { return _person == null ? _person = new PersonEntity() : _person; } }
        }

        public class PersonEntity : DBExpressionEntity<Person>
        {
            public DBExpressionField<int> Id { get; set; }
            public DBExpressionField<string> FirstName { get; set; }
            public DBExpressionField<string> LastName { get; set; }

            public PersonEntity() : base("dbo", "Person", null, null, null)
            {
                this.Id = new DBExpressionField<int>(this, "Id", 4);
                this.Id = new DBExpressionField<int>(this, "FirstName", 20);
                this.Id = new DBExpressionField<int>(this, "LastName", 20);
            }
        }

        public class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
