using System;
using DbExpression.Sql;
using SimpleConsole.Data;
using SimpleConsole.DataService;
using SimpleConsole.dboData;
using SimpleConsole.dboDataService;

namespace NetCoreConsoleApp
{
	public class Inserts : IExecute
	{
		#region execute
		public void Execute()
		{
			#region simple insert
			{
				var p = new Person()
				{
					FirstName = "Charlie",
					LastName = "Brown",
					BirthDate = new DateTime(1950, 10, 1),
					GenderType = GenderType.Male,
					CreditLimit = 4500,
					YearOfLastCreditLimitReview = 2019,
					RegistrationDate = DateTimeOffset.Now,
					LastLoginDate = null,
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now
				};

				this.InsertPerson(p);
			}
			#endregion

			#region transactional insert
			{
				var p = new Person()
				{
					FirstName = "Mickey",
					LastName = "Mouse",
					BirthDate = new DateTime(1928, 11, 18),
					GenderType = GenderType.Male,
					CreditLimit = 80000,
					YearOfLastCreditLimitReview = 2020,
					RegistrationDate = DateTimeOffset.Now,
					LastLoginDate = null,
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now
				};

				var a = new Address()
				{
					Line1 = "101 Disney Way",
					Line2 = "Suite 210",
					City = "Burbank",
					State = "CA",
					Zip = "91508",
					AddressType = AddressType.Mailing,
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now
				};

				this.TransactionalInsertPersonAndAddress(p, a);
			}
			#endregion

			#region batch insert
			{
				var p1 = new Person()
				{
					FirstName = "Bugs",
					LastName = "Bunny",
					BirthDate = new DateTime(1940, 6, 27),
					GenderType = GenderType.Male,
					CreditLimit = 75000,
					YearOfLastCreditLimitReview = 2018,
					RegistrationDate = DateTimeOffset.Now,
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now
				};

				var p2 = new Person()
				{
					FirstName = "Elmer",
					LastName = "Fudd",
					BirthDate = new DateTime(1940, 3, 2),
					GenderType = GenderType.Male,
					CreditLimit = 1200,
					YearOfLastCreditLimitReview = 2018,
					RegistrationDate = DateTimeOffset.Now,
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now
				};

				var p3 = new Person()
				{
					FirstName = "Porky",
					LastName = "Pig",
					BirthDate = new DateTime(1935, 3, 2),
					GenderType = GenderType.Male,
					CreditLimit = 7500,
					YearOfLastCreditLimitReview = 2018,
					RegistrationDate = DateTimeOffset.Now,
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now
				};

				var p4 = new Person()
				{
					FirstName = "Daffy",
					LastName = "Duck",
					BirthDate = new DateTime(1937, 4, 17),
					GenderType = GenderType.Male,
					CreditLimit = 10000,
					YearOfLastCreditLimitReview = 2015,
					RegistrationDate = DateTimeOffset.Now,
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now
				};

				var p5 = new Person()
				{
					FirstName = "Witch",
					LastName = "Hazel",
					BirthDate = new DateTime(1954, 7, 24),
					GenderType = GenderType.Female,
					CreditLimit = 35000,
					YearOfLastCreditLimitReview = 2016,
					RegistrationDate = DateTimeOffset.Now,
					DateCreated = DateTime.Now,
					DateUpdated = DateTime.Now
				};

				this.BatchInsertPeople(p1, p2, p3, p4, p5);
			}
			#endregion
		}
		#endregion

		#region simple insert
		public void InsertPerson(Person p)
		{
			/* Ther person table has and identity column as PK.  After insert the Person Id column will be populated
			 * with the identity value generated. */

			//insert into dbo.Person 
			//([FirstName],[LastName],[BirthDate],[GenderType],[CreditLimit],[YearOfLastCreditLimitReview],[DateCreated],[DateUpdated])
			//Values ('first', 'last', '2020-01-01', 1, 800, 2015, GetDate(), GetDate());
			db.Insert(p).Into(dbo.Person).Execute();

			//p.Id should now have a value...
		}
		#endregion

		#region transactional insert person and address
		public void TransactionalInsertPersonAndAddress(Person p, Address a)
		{
			//BEGIN TRANSACTION;

			//DECLARE @PId int;
			//DECLARE @AId int;
			//DECLARE @Tmstmp datetime = GETDATE();

			//insert into dbo.Person 
			//([FirstName],[LastName],[BirthDate],[GenderType],[CreditLimit],[YearOfLastCreditLimitReview],[DateCreated],[DateUpdated])
			//Values ('first', 'last', '2020-01-01', 1, 800, 2015, @Tmstmp, @Tmstmp);
			//SET @PId = @@IDENTITY;

			//insert into dbo.Address
			//([AddressType],[Line1],[Line2],[City],[State],[Zip],[DateCreated],[DateUpdated])
			//Values (1, 'line1', 'line2', 'Dallas', 'TX', '12345', @Tmstmp, @Tmstmp);
			//SET @AId = @@IDENTITY;

			//insert into dbo.Person_Address
			//(PersonId, AddressId, DateCreated)
			//Values (@PId, @AId, @Tmstmp);

			//COMMIT TRANSACTION;

			using (var conn = db.GetConnection())
			{
				conn.Open();
				try
				{
					conn.BeginTransaction();

					db.Insert(p).Into(dbo.Person).Execute(conn);//pass in connection to execute within transaction
					db.Insert(a).Into(dbo.Address).Execute(conn);//pass in connection to execute within transaction

					//both p and a have identity PKs, so the Id's of each should now be populated
					var pa = new PersonAddress()
					{ PersonId = p.Id, AddressId = a.Id, DateCreated = DateTime.Now };

					db.Insert(pa).Into(dbo.PersonAddress).Execute(conn);//pass in connection to execute within transaction

					conn.CommitTransaction();
				}
				catch (Exception ex)
				{
					var msg = ex.Message;
					conn.RollbackTransaction();
				}
			}
		}
		#endregion

		#region batch insert people
		public void BatchInsertPeople(params Person[] people)
		{
			//SET NOCOUNT ON;
			//MERGE [dbo].[Person] USING (
			//VALUES
			//	..... all the values ......
			//) AS [__values] (
			//	[FirstName], 
			//	[LastName], 
			//	[BirthDate], 
			//	[GenderType], 
			//	[CreditLimit], 
			//	[YearOfLastCreditLimitReview], 
			//	[DateCreated], 
			//	[DateUpdated], 
			//	[ordinal]
			//) ON 1 != 1
			//WHEN NOT MATCHED THEN
			//INSERT (
			//	[FirstName], 
			//	[LastName], 
			//	[BirthDate], 
			//	[GenderType], 
			//	[CreditLimit], 
			//	[YearOfLastCreditLimitReview], 
			//	[DateCreated], 
			//	[DateUpdated]
			//) VALUES (
			//	[__values].[FirstName], 
			//	[__values].[LastName], 
			//	[__values].[BirthDate], 
			//	[__values].[GenderType], 
			//	[__values].[CreditLimit], 
			//	[__values].[YearOfLastCreditLimitReview], 
			//	[__values].[DateCreated], 
			//	[__values].[DateUpdated]
			//)
			//OUTPUT
			//	__values.[ordinal], 
			//	INSERTED.[Id], 
			//	INSERTED.[FirstName], 
			//	INSERTED.[LastName], 
			//	INSERTED.[BirthDate], 
			//	INSERTED.[GenderType], 
			//	INSERTED.[CreditLimit], 
			//	INSERTED.[YearOfLastCreditLimitReview], 
			//	INSERTED.[DateCreated], 
			//	INSERTED.[DateUpdated];

			db.InsertMany(people).Into(dbo.Person).Execute();
		}
		#endregion
	}
}
