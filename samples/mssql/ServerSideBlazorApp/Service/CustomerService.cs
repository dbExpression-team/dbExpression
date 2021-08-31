using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Executor;
using ServerSideBlazorApp.Data;
using ServerSideBlazorApp.DataService;
using ServerSideBlazorApp.dboData;
using ServerSideBlazorApp.dboDataService;
using ServerSideBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HatTrick.DbEx.Sql.Expression;

namespace ServerSideBlazorApp.Service
{
    /// <summary>
    /// A service that provides methods to retrieve, insert, and update Customer information in the database.
    /// </summary>
    /// <remarks>
    /// While C# code uses the type name 'Customer', the database table is actually named 'Person'.  This was done simply to match the semantics of this sample application.
    /// The configuration to change the table name was specified in dbex.config.json, which resulted in a code generated type name of 'Customer'.
    /// </remarks>
    public class CustomerService
    {
        //dbExpression element to approximate a person's current age.  Stored as a variable as it's used more than once.
        private static readonly NullableInt16Element currentAgeApproximation = db.fx.Cast(db.fx.Floor(db.fx.DateDiff(DateParts.Day, dbo.Customer.BirthDate, db.fx.GetUtcDate()) / 365.25)).AsSmallInt();

        #region customer summary
        //variable to hold dbExpression select elements.  Stored as a variable as it's used more than once and to demonstrate that select elements can be treated like most any other .NET object
        private static readonly IList<AnyElement> CustomerSummarySelectClauseElements = new List<AnyElement>
        {
            dbo.Customer.Id,
            (dbo.Customer.FirstName + " " + dbo.Customer.LastName).As(nameof(CustomerSummaryModel.Name)),
            db.fx.IsNull(dbo.PersonTotalPurchasesView.TotalAmount, 0).As(nameof(CustomerSummaryModel.LifetimeValue)),
            currentAgeApproximation.As(nameof(CustomerSummaryModel.CurrentAge))
        };

        //variable to hold dbExpression order by elements.  Stored as a variable as it's used more than once and to demonstrate that order by elements can be treated like most any other .NET object
        private static readonly IDictionary<string, AnyElement> CustomerSummaryOrderByClauseElements = new Dictionary<string, AnyElement>
        {
            { nameof(CustomerSummaryModel.Name), dbo.Customer.FirstName + " " + dbo.Customer.LastName },
            { nameof(CustomerSummaryModel.LifetimeValue), dbo.PersonTotalPurchasesView.TotalAmount },
            { nameof(CustomerSummaryModel.CurrentAge), currentAgeApproximation }
        };


        /// <summary>
        /// Fetch a list of VIP customers, ordered by total amount spent.
        /// </summary>
        /// <param name="count">The maximum number of VIP customers to fetch.</param>
        public async Task<IEnumerable<CustomerSummaryModel>> GetVIPCustomersPageAsync(int count = 5)
        {
            var customer = dbo.Customer;
            var ptpv = dbo.PersonTotalPurchasesView;

            return await db.SelectMany(
                    CustomerSummarySelectClauseElements
                )
                .Top(count)
                .From(customer)
                .LeftJoin(ptpv).On(ptpv.Id == customer.Id)
                .Where(ptpv.TotalAmount >= Rules.LifetimeValueAmountToBeAVIPCustomer)
                .OrderBy(ptpv.TotalAmount.Desc)
                .ExecuteAsync(MapToCustomerSummary);  //use a custom mapping function to map data from a data reader to a CustomerSummaryModel
        }

        /// <summary>
        /// Search for customers, and retrieve a paged list using the supplied paging parameters and an optional search phrase.
        /// </summary>
        /// <param name="pagingParameters">A set of parameters specifying the offset, limit, and sorting criteria used in the SQL statement.</param>
        public async Task<Page<CustomerSummaryModel, PagingParametersWithSearch>> GetSummaryPageAsync(PagingParametersWithSearch pagingParameters)
        {
            var whereClause = string.IsNullOrWhiteSpace(pagingParameters.SearchPhrase) ?
                    null
                    : dbo.Customer.FirstName.Like(pagingParameters.SearchPhrase + '%') | dbo.Customer.LastName.Like(pagingParameters.SearchPhrase + '%');

            var customers = await
                db.SelectMany(
                    CustomerSummarySelectClauseElements
                )
                .From(dbo.Customer)
                .Where(whereClause)
                .LeftJoin(dbo.PersonTotalPurchasesView).On(dbo.Customer.Id == dbo.PersonTotalPurchasesView.Id)
                .OrderBy(
                    pagingParameters.Sorting?.Select(s => s.Direction == OrderExpressionDirection.ASC ? CustomerSummaryOrderByClauseElements[s.Field].Asc : CustomerSummaryOrderByClauseElements[s.Field].Desc)
                )
                .Offset(pagingParameters.Offset).Limit(pagingParameters.Limit)
                .ExecuteAsync(MapToCustomerSummary);

            var countOfCustomers = await
                db.SelectOne(
                    db.fx.Count()
                )
                .From(dbo.Customer)
                .Where(whereClause)
                .ExecuteAsync();

            return new Page<CustomerSummaryModel, PagingParametersWithSearch>(
                pagingParameters,
                customers,
                countOfCustomers
            );
        }

        private static CustomerSummaryModel MapToCustomerSummary(ISqlFieldReader row)
            => new CustomerSummaryModel
            {
                Id = row.ReadField().GetValue<int>(),
                Name = row.ReadField().GetValue<string>(),
                LifetimeValue = row.ReadField().GetValue<double>(),
                CurrentAge = row.ReadField().GetValue<short?>(),
                IsVIP = row.GetValue<double>(2) >= Rules.LifetimeValueAmountToBeAVIPCustomer
            };
        #endregion

        #region customer detail
        /// <summary>
        /// Fetch a specific customer by id.
        /// </summary>
        public async Task<CustomerDetailModel> GetCustomerDetailAsync(int customerId)
        {
            static AddressModel mapAddress(AddressType addressType, ISqlFieldReader sqlRow)
                =>  new AddressModel
                {
                    Type = addressType,
                    Line1 = sqlRow.ReadField().GetValue<string>(),
                    Line2 = sqlRow.ReadField().GetValue<string>(),
                    City = sqlRow.ReadField().GetValue<string>(),
                    State = sqlRow.ReadField().GetValue<string>(),
                    ZIP = sqlRow.ReadField().GetValue<string>()
                };

            var mailingAddress = nameof(CustomerDetailModel.MailingAddress);
            var billingAddress = nameof(CustomerDetailModel.BillingAddress);
            var shippingAddress = nameof(CustomerDetailModel.ShippingAddress);
            Func<string,AnyElement,ObjectElement> alias = (string table, AnyElement a) => dbex.Alias(table, nameof(a));

            var customer = new CustomerDetailModel();

            //query will select data for the customer, and append fields to include all of their addresses 
            await db.SelectOne(
                    dbo.Customer.Id,
                    dbo.Customer.FirstName,
                    dbo.Customer.LastName,
                    db.fx.IsNull(dbo.PersonTotalPurchasesView.TotalAmount, 0).As(nameof(CustomerSummaryModel.LifetimeValue)),
                    dbo.Customer.GenderType,
                    dbo.Customer.CreditLimit,
                    dbo.Customer.YearOfLastCreditLimitReview,
                    dbo.Customer.BirthDate,
                    currentAgeApproximation.As(nameof(CustomerSummaryModel.CurrentAge)),
                    dbex.Alias(mailingAddress, nameof(AddressModel.Line1)),
                    dbex.Alias(mailingAddress, nameof(AddressModel.Line2)),
                    dbex.Alias(mailingAddress, nameof(AddressModel.City)),
                    dbex.Alias(mailingAddress, nameof(AddressModel.State)),
                    dbex.Alias(mailingAddress, nameof(AddressModel.ZIP)),
                    dbex.Alias(billingAddress, nameof(AddressModel.Line1)),
                    dbex.Alias(billingAddress, nameof(AddressModel.Line2)),
                    dbex.Alias(billingAddress, nameof(AddressModel.City)),
                    dbex.Alias(billingAddress, nameof(AddressModel.State)),
                    dbex.Alias(billingAddress, nameof(AddressModel.ZIP)),
                    dbex.Alias(shippingAddress, nameof(AddressModel.Line1)),
                    dbex.Alias(shippingAddress, nameof(AddressModel.Line2)),
                    dbex.Alias(shippingAddress, nameof(AddressModel.City)),
                    dbex.Alias(shippingAddress, nameof(AddressModel.State)),
                    dbex.Alias(shippingAddress, nameof(AddressModel.ZIP))
                )
                .From(dbo.Customer)
                .LeftJoin(dbo.PersonTotalPurchasesView).On(dbo.Customer.Id == dbo.PersonTotalPurchasesView.Id)
                .LeftJoin(
                    db.SelectOne(
                        dbo.CustomerAddress.CustomerId.As(nameof(CustomerSummaryModel.Id)),
                        dbo.Address.Line1,
                        dbo.Address.Line2,
                        dbo.Address.City,
                        dbo.Address.State,
                        dbo.Address.Zip
                    )
                    .From(dbo.Address)
                    .InnerJoin(dbo.CustomerAddress).On(dbo.CustomerAddress.AddressId == dbo.Address.Id)
                    .Where(dbo.CustomerAddress.CustomerId == customerId & dbo.Address.AddressType == AddressType.Mailing)
                ).As(mailingAddress).On(dbo.Customer.Id == dbex.Alias(nameof(CustomerDetailModel.MailingAddress), nameof(CustomerSummaryModel.Id)))
                .LeftJoin(
                    db.SelectOne(
                        dbo.CustomerAddress.CustomerId.As(nameof(CustomerSummaryModel.Id)),
                        dbo.Address.Line1,
                        dbo.Address.Line2,
                        dbo.Address.City,
                        dbo.Address.State,
                        dbo.Address.Zip
                    )
                    .From(dbo.Address)
                    .InnerJoin(dbo.CustomerAddress).On(dbo.CustomerAddress.AddressId == dbo.Address.Id)
                    .Where(dbo.CustomerAddress.CustomerId == customerId & dbo.Address.AddressType == AddressType.Billing)
                ).As(billingAddress).On(dbo.Customer.Id == dbex.Alias(nameof(CustomerDetailModel.BillingAddress), nameof(CustomerSummaryModel.Id)))
                .LeftJoin(
                    db.SelectOne(
                        dbo.CustomerAddress.CustomerId.As(nameof(CustomerSummaryModel.Id)),
                        dbo.Address.Line1,
                        dbo.Address.Line2,
                        dbo.Address.City,
                        dbo.Address.State,
                        dbo.Address.Zip
                    )
                    .From(dbo.Address)
                    .InnerJoin(dbo.CustomerAddress).On(dbo.CustomerAddress.AddressId == dbo.Address.Id)
                    .Where(dbo.CustomerAddress.CustomerId == customerId & dbo.Address.AddressType == AddressType.Shipping)
                ).As(shippingAddress).On(dbo.Customer.Id == dbex.Alias(nameof(CustomerDetailModel.ShippingAddress), nameof(CustomerSummaryModel.Id)))
                .Where(dbo.Customer.Id == customerId)
                .ExecuteAsync(
                    reader => 
                    {
                        customer.Id = reader.ReadField().GetValue<int>();
                        customer.FirstName = reader.ReadField().GetValue<string>();
                        customer.LastName = reader.ReadField().GetValue<string>();
                        customer.LifetimeValue = reader.ReadField().GetValue<double>();
                        customer.Gender = reader.ReadField().GetValue<GenderType>();
                        customer.CreditLimit = reader.ReadField().GetValue<int?>();
                        customer.YearOfLastCreditLimitReview = reader.ReadField().GetValue<int?>();
                        customer.BirthDate = reader.ReadField().GetValue<DateTime?>();
                        customer.CurrentAge = reader.ReadField().GetValue<short?>();
                        customer.MailingAddress = mapAddress(AddressType.Mailing, reader);
                        customer.BillingAddress = mapAddress(AddressType.Billing, reader);
                        customer.ShippingAddress = mapAddress(AddressType.Shipping, reader);
                        customer.IsVIP = customer.LifetimeValue >= Rules.LifetimeValueAmountToBeAVIPCustomer;
                        return customer;
                    }
                );

            return customer;
        }
        #endregion

        #region customer address
        /// <summary>
        /// Persist a customer's address.
        /// </summary>
        /// <param name="customerId">The identifier for the customer record to associate the address with.</param>
        /// <param name="address">The address information to asssociate with the customer</param>
        /// <remarks>Method will determine whether the address is an update to an existing address, or a new address to be inserted.</returns>
        public async Task<AddressModel> SaveAddressAsync(int customerId, AddressModel address)
        {
            var @new = new Address
            {
                Line1 = address.Line1,
                Line2 = address.Line2,
                City = address.City,
                State = address.State,
                Zip = address.ZIP,
                AddressType = address.Type
            };

            if (await GetAddressAsync(customerId, address.Type) is Address persisted)
            {
                //address by address type already exists for this customer, perform an udpate
                @new.DateCreated = persisted.DateCreated;
                @new.DateUpdated = DateTime.UtcNow;

                await UpdateAddressAsync(persisted, @new);
                var updated = await GetAddressAsync(customerId, address.Type);
                return new AddressModel
                {
                    Line1 = updated.Line1,
                    Line2 = updated.Line2,
                    City = updated.City,
                    State = updated.State,
                    ZIP = updated.Zip,
                    Type = address.Type
                };
            }
            else
            {
                await InsertAddressAsync(customerId, @new);
                return new AddressModel
                {
                    Line1 = @new.Line1,
                    Line2 = @new.Line2,
                    City = @new.City,
                    State = @new.State,
                    ZIP = @new.Zip,
                    Type = address.Type
                };
            }
        }

        private async Task<Address> GetAddressAsync(int customerId, AddressType addressType)
            => await db.SelectOne<Address>()
                .From(dbo.Address)
                .InnerJoin(dbo.CustomerAddress).On(dbo.Address.Id == dbo.CustomerAddress.AddressId)
                .Where(dbo.CustomerAddress.CustomerId == customerId & dbo.Address.AddressType == addressType)
                .ExecuteAsync();

        private async Task UpdateAddressAsync(Address persisted, Address @new)
        {
            //build a list of assignment expressions for the update statement based on the difference between the two Address instances.
            var assignments = dbex.BuildAssignmentsFor(dbo.Address).From(persisted).To(@new);

            //if there are differences, execute an update.
            if (assignments.Any())
            {
                await db.Update(
                    assignments
                )
                .From(dbo.Address)
                .Where(dbo.Address.Id == persisted.Id)
                .ExecuteAsync();
            }
        }

        private async Task InsertAddressAsync(int customerId, Address address)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                try
                {
                    //begin a transaction as data needs to be inserted in the address table and the mapping table between a customer and address
                    conn.BeginTransaction();

                    //insert into Address table
                    await db.Insert(address)
                        .Into(dbo.Address)
                        .ExecuteAsync(conn);

                    //insert into mapping table
                    await db.Insert(
                            new CustomerAddress
                            {
                                CustomerId = customerId,
                                AddressId = address.Id,
                                DateCreated = DateTime.UtcNow
                            }
                        )
                        .Into(dbo.CustomerAddress)
                        .ExecuteAsync(conn);

                    //commit the transaction
                    conn.CommitTransaction();
                }
                catch (Exception)
                {
                    conn.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion
    }
}
