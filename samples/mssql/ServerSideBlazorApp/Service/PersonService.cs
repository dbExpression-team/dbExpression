//using ServerSideBlazorApp.Data.dbo;
using ServerSideBlazorApp.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Service
{
    public class PersonService
    {
        public IEnumerable<Person> GetPeople(int offset, int length, string nameStartsWith)
        {
            return db.SelectMany<Person>()
                .From(DataService.dbo.Person)
                .Where((dbo.Person.FirstName + " " + dbo.Person.LastName).Like(nameStartsWith + "%")
                .Execute();
        }

        //GWG to JROD: Here's what I put as "Application arguments" in HatTrick.DbEx.Tools to gen code in the ./Data/_Generated folder: "gen -p d:/src/db-ex/samples/mssql/ServerSideBlazorApp/DbExConfig.json -o d:/src/db-ex/samples/mssql/ServerSideBlazorApp/Data/_Generated"
    }
}
