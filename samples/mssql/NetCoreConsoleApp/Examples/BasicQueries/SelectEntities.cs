using System;
using System.Collections.Generic;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.MsSql.Expression;
using SimpleConsole.Data;
using SimpleConsole.DataService;
using SimpleConsole.dboData;
using SimpleConsole.dboDataService;

namespace NetCoreConsoleApp
{
	public class SelectEntities : IExecute
	{
		#region execute
		public void Execute()
		{
			var p1 = this.SelectPersonById(1);
			var p2 = this.SelectPersonByFirstNameLastNameAndBirthdate("Kyle", "Broflovski", DateTime.Parse("1996-03-01"));
			var tpv = this.SelectTotalPurchaseViewByPersonId(2);

			var pSet1 = this.GetPeopleOverAge(25);
			var prodSet1 = this.GetProductsWithinPriceRange(20.00, 30.00);
			var aSet = this.GetAllAddressesWithinZip("80456");

			var tp1 = this.SelectTotalPurchaseViewsAtOrAbove(1000.00);
		}
		#endregion

		#region select one table based or entity
		public Person SelectPersonById(int id)
		{
			//select * from dbo.Person where dbo.Person.Id = {id};
			var p = db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.Id == id).Execute();

			return p;
		}

		public Person SelectPersonByFirstNameLastNameAndBirthdate(string firstName, string lastName, DateTime birthdate)
		{
			//select * 
			//from dbo.Person 
			//where dbo.Person.FirstName = {firstName} 
			//  and dbo.Person.LastName = {lastName} 
			//  and dbo.Person.BirthDate = {birthdate};
			var p = db.SelectOne<Person>()
				.From(dbo.Person)
				.Where(dbo.Person.FirstName == firstName
					 & dbo.Person.LastName == lastName
					 & dbo.Person.BirthDate == birthdate.Date)
				.Execute();

			return p;
		}
		#endregion

		#region select one view based entity
		public PersonTotalPurchasesView SelectTotalPurchaseViewByPersonId(int id)
		{
			//select * 
			//from dbo.PersonTotalPurchaseView 
			//where dbo.PersonTotalPurchaseView.Id = {id};
			var tpv = db.SelectOne<PersonTotalPurchasesView>()
				.From(dbo.PersonTotalPurchasesView)
				.Where(dbo.PersonTotalPurchasesView.Id == id)
				.Execute();

			return tpv;
		}
		#endregion

		#region select many table based entities
		public IEnumerable<Person> GetPeopleOverAge(int age)
		{
			//select * from dbo.Person where dbo.Person.BirthDate < DATEADD(yy, -{age}, GETDATE());
			var people = db.SelectMany<Person>()
				.From(dbo.Person)
				.Where(dbo.Person.BirthDate < DateTime.Now.AddYears(-age))
				.Execute();

			return people;
		}

		public IEnumerable<Product> GetProductsWithinPriceRange(double min, double max)
		{
			//select * from dbo.Product where dbo.Product.ListPrice >= {min} and dbo.Product.ListPrice <= {max};
			var products = db.SelectMany<Product>()
				.From(dbo.Product).Where(dbo.Product.ListPrice >= min & dbo.Product.ListPrice <= max)
				.Execute();

			return products;
		}

		public IEnumerable<Address> GetAllAddressesWithinZip(string zip)
		{
			//select * from dbo.Address where dbo.Address.Zip = {zip};
			var addresses = db.SelectMany<Address>()
				.From(dbo.Address)
				.Where(dbo.Address.Zip == zip)
				.Execute();

			return addresses;
		}
		#endregion

		#region select many view based entities
		public PersonTotalPurchasesView SelectTotalPurchaseViewsAtOrAbove(double amount)
		{
			//select * 
			//from dbo.PersonTotalPurchaseView 
			//where dbo.PersonTotalPurchaseView.TotalAmount >= {amount};
			var tpv = db.SelectOne<PersonTotalPurchasesView>()
				.From(dbo.PersonTotalPurchasesView)
				.Where(dbo.PersonTotalPurchasesView.TotalAmount >= amount)
				.Execute();

			return tpv;
		}
		#endregion
	}
}
