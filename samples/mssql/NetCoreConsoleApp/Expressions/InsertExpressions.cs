using System;
using HatTrick.DbEx.Sql;
using SimpleConsole.DataService;
using SimpleConsole.dboData;
using SimpleConsole.dboDataService;

namespace NetCoreConsoleApp
{
	public class InsertExpressions
	{
		#region simple insert
		public void SimpleInsertPerson(Person p)
		{
			/* Ther person table has and identity column as PK.  After insert the Person Id column will be populated
			 * with the identity value gererated. */

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

					db.Insert(p).Into(dbo.Person).Execute(conn);
					db.Insert(a).Into(dbo.Address).Execute(conn);

					//both p and a have identity PKs, so the Id's of each should now be populated
					var pa = new PersonAddress()
					{ PersonId = p.Id, AddressId = a.Id, DateCreated = DateTime.Now };

					db.Insert(pa).Into(dbo.PersonAddress).Execute(conn);

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
