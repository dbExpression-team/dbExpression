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

namespace ServerSideBlazorApp.Service
{
    public class CustomerService
    {
        private static readonly NullableInt16Element currentAgeApproximation = db.fx.Cast(db.fx.Floor(db.fx.DateDiff(DateParts.Day, dbo.Customer.BirthDate, db.fx.GetUtcDate()) / 365.25)).AsSmallInt();

        private static readonly IList<AnyElement> CustomerSummarySelectFields = new List<AnyElement>
        {
            dbo.Customer.Id,
            (dbo.Customer.FirstName + " " + dbo.Customer.LastName).As("Name"),
            db.fx.IsNull(dbo.PersonTotalPurchasesView.TotalAmount, 0).As("LifetimeValue"),
            currentAgeApproximation.As("CurrentAge")
        };

        private static readonly IDictionary<string, AnyElement> CustomerSummarySortingFields = new Dictionary<string, AnyElement>
        {
            { nameof(CustomerSummaryModel.Name), dbo.Customer.FirstName + " " + dbo.Customer.LastName },
            { nameof(CustomerSummaryModel.LifetimeValue), dbo.PersonTotalPurchasesView.TotalAmount },
            { nameof(CustomerSummaryModel.CurrentAge), currentAgeApproximation }
        };

        public async Task<IEnumerable<(int,decimal)>> GetPurchaseValueByYear(int customerId)
        {
            IEnumerable<dynamic> metrics = await

                db.SelectMany(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("Year"),
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .Where(dbo.Purchase.CustomerId == customerId)
                .GroupBy(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate)
                )

                .ExecuteAsync();

            return metrics.Select(x => ((int,decimal))(x.Year, x.TotalPurchaseAmount));
        }

        public async Task<PageResponseModel<CustomerSummaryModel>> GetSummaryPageAsync(PageModel model)
        {
            var customers = await
                db.SelectMany(
                    CustomerSummarySelectFields
                )
                .From(dbo.Customer)
                .Where(string.IsNullOrWhiteSpace(model.SearchPhrase) ? null : (dbo.Customer.FirstName + " " + dbo.Customer.LastName).Like(model.SearchPhrase + '%'))
                .LeftJoin(dbo.PersonTotalPurchasesView).On(dbo.Customer.Id == dbo.PersonTotalPurchasesView.Id)
                .OrderBy(
                    model.Sorting?.Select(s => s.Ascending ? CustomerSummarySortingFields[s.Field].Asc : CustomerSummarySortingFields[s.Field].Desc)
                )
                .Skip(model.Offset).Limit(model.Limit)
                .ExecuteAsync(MapToCustomer);

            var countOfCustomers = await
                db.SelectOne(
                    db.fx.Count()
                )
                .From(dbo.Customer)
                .Where(string.IsNullOrWhiteSpace(model.SearchPhrase) ? null : (dbo.Customer.FirstName + " " + dbo.Customer.LastName).Like(model.SearchPhrase + '%'))
                .ExecuteAsync();

            return new PageResponseModel<CustomerSummaryModel>(
                model.Offset,
                model.Limit,
                model.SearchPhrase,
                customers,
                countOfCustomers
            );
        }

        public async Task<CustomerDetailModel> GetCustomerAsync(int customerId)
        {
            static AddressModel mapAddress(AddressType addressType, ISqlRow sqlRow)
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
            Func<string,AnyElement,ObjectElement> alias = (string table, AnyElement a) => dbex.alias(table, nameof(a));

            var customer = new CustomerDetailModel();

            await db.SelectOne(
                    dbo.Customer.Id,
                    dbo.Customer.FirstName,
                    dbo.Customer.LastName,
                    db.fx.IsNull(dbo.PersonTotalPurchasesView.TotalAmount, 0).As("LifetimeValue"),
                    dbo.Customer.GenderType,
                    dbo.Customer.CreditLimit,
                    dbo.Customer.YearOfLastCreditLimitReview,
                    dbo.Customer.BirthDate,
                    db.fx.Floor(db.fx.DateDiff(DateParts.Day, dbo.Customer.BirthDate, db.fx.GetUtcDate()) / 365.25).As("CurrentAge"),
                    dbex.alias(mailingAddress, nameof(dbo.Address.Line1)),
                    dbex.alias(mailingAddress, nameof(dbo.Address.Line2)),
                    dbex.alias(mailingAddress, nameof(dbo.Address.City)),
                    dbex.alias(mailingAddress, nameof(dbo.Address.State)),
                    dbex.alias(mailingAddress, nameof(dbo.Address.Zip)),
                    dbex.alias(billingAddress, nameof(dbo.Address.Line1)),
                    dbex.alias(billingAddress, nameof(dbo.Address.Line2)),
                    dbex.alias(billingAddress, nameof(dbo.Address.City)),
                    dbex.alias(billingAddress, nameof(dbo.Address.State)),
                    dbex.alias(billingAddress, nameof(dbo.Address.Zip)),
                    dbex.alias(shippingAddress, nameof(dbo.Address.Line1)),
                    dbex.alias(shippingAddress, nameof(dbo.Address.Line2)),
                    dbex.alias(shippingAddress, nameof(dbo.Address.City)),
                    dbex.alias(shippingAddress, nameof(dbo.Address.State)),
                    dbex.alias(shippingAddress, nameof(dbo.Address.Zip))
                )
                .From(dbo.Customer)
                .LeftJoin(dbo.PersonTotalPurchasesView).On(dbo.Customer.Id == dbo.PersonTotalPurchasesView.Id)
                .LeftJoin(
                    db.SelectOne(
                        dbo.CustomerAddress.CustomerId,
                        dbo.Address.Line1,
                        dbo.Address.Line2,
                        dbo.Address.City,
                        dbo.Address.State,
                        dbo.Address.Zip
                    )
                    .From(dbo.Address)
                    .InnerJoin(dbo.CustomerAddress).On(dbo.CustomerAddress.AddressId == dbo.Address.Id)
                    .Where(dbo.CustomerAddress.CustomerId == customerId & dbo.Address.AddressType == AddressType.Mailing)
                ).As(mailingAddress).On(dbo.Customer.Id == dbex.alias(nameof(CustomerDetailModel.MailingAddress), "PersonId"))
                .LeftJoin(
                    db.SelectOne(
                        dbo.CustomerAddress.CustomerId,
                        dbo.Address.Line1,
                        dbo.Address.Line2,
                        dbo.Address.City,
                        dbo.Address.State,
                        dbo.Address.Zip
                    )
                    .From(dbo.Address)
                    .InnerJoin(dbo.CustomerAddress).On(dbo.CustomerAddress.AddressId == dbo.Address.Id)
                    .Where(dbo.CustomerAddress.CustomerId == customerId & dbo.Address.AddressType == AddressType.Billing)
                ).As(billingAddress).On(dbo.Customer.Id == dbex.alias(nameof(CustomerDetailModel.BillingAddress), "PersonId"))
                .LeftJoin(
                    db.SelectOne(
                        dbo.CustomerAddress.CustomerId,
                        dbo.Address.Line1,
                        dbo.Address.Line2,
                        dbo.Address.City,
                        dbo.Address.State,
                        dbo.Address.Zip
                    )
                    .From(dbo.Address)
                    .InnerJoin(dbo.CustomerAddress).On(dbo.CustomerAddress.AddressId == dbo.Address.Id)
                    .Where(dbo.CustomerAddress.CustomerId == customerId & dbo.Address.AddressType == AddressType.Shipping)
                ).As(shippingAddress).On(dbo.Customer.Id == dbex.alias(nameof(CustomerDetailModel.ShippingAddress), "PersonId"))
                .Where(dbo.Customer.Id == customerId)
                .ExecuteAsync(
                    sqlRow => 
                    {
                        customer.Id = sqlRow.ReadField().GetValue<int>();
                        customer.FirstName = sqlRow.ReadField().GetValue<string>();
                        customer.LastName = sqlRow.ReadField().GetValue<string>();
                        customer.LifetimeValue = sqlRow.ReadField().GetValue<double>();
                        customer.Gender = sqlRow.ReadField().GetValue<GenderType>();
                        customer.CreditLimit = sqlRow.ReadField().GetValue<int?>();
                        customer.YearOfLastCreditLimitReview = sqlRow.ReadField().GetValue<int?>();
                        customer.BirthDate = sqlRow.ReadField().GetValue<DateTime?>();
                        customer.CurrentAge = sqlRow.ReadField().GetValue<short?>();
                        customer.MailingAddress = mapAddress(AddressType.Mailing, sqlRow);
                        customer.BillingAddress = mapAddress(AddressType.Billing, sqlRow);
                        customer.ShippingAddress = mapAddress(AddressType.Shipping, sqlRow);
                        customer.IsVIP = customer.LifetimeValue >= Constants.LifetimeValueAmountToBeAVIPCustomer;
                        return customer;
                    }
                );

            return customer;
        }

        public async Task<IEnumerable<CustomerSummaryModel>> GetVIPCustomers(int length = 5)
        {
            var customer = dbo.Customer;
            var ptpv = dbo.PersonTotalPurchasesView;

            return await db.SelectMany(
                    CustomerSummarySelectFields
                )
                .From(customer)
                .LeftJoin(ptpv).On(ptpv.Id == customer.Id)
                .Where(ptpv.TotalAmount >= Constants.LifetimeValueAmountToBeAVIPCustomer)
                .OrderBy(ptpv.TotalAmount.Desc)
                .Skip(0).Limit(length)
                .ExecuteAsync(MapToCustomer);
        }

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
            => await db.Update(
                persisted,
                @new
            )
            .From(dbo.Address)
            .Where(dbo.Address.Id == persisted.Id)
            .ExecuteAsync();

        private async Task InsertAddressAsync(int customerId, Address address)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                try
                {
                    conn.BeginTransaction();

                    await db.Insert(address)
                        .Into(dbo.Address)
                        .ExecuteAsync(conn);

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

                    conn.CommitTransaction();
                }
                catch (Exception)
                {
                    conn.RollbackTransaction();
                    throw;
                }
            }
        }

        private CustomerSummaryModel MapToCustomer(ISqlRow row)
            =>  new CustomerSummaryModel
            {
                Id = row.ReadField().GetValue<int>(),
                Name = row.ReadField().GetValue<string>(),
                LifetimeValue = row.ReadField().GetValue<double>(),
                CurrentAge = row.ReadField().GetValue<short?>(),
            };
    }
}
