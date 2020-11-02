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
    public class CustomerService : ServiceBase
    {
        private IDictionary<string, ExpressionMediator> SortConversion = new Dictionary<string, ExpressionMediator>
        {
            { nameof(CustomerSummaryModel.Name), dbo.Customer.FirstName + " " + dbo.Customer.LastName },
            { nameof(CustomerSummaryModel.LifetimeValue), dbo.PersonTotalPurchasesView.TotalAmount },
            { nameof(CustomerSummaryModel.CurrentAge), dbo.Customer.BirthDate }
        };

        public async Task<IEnumerable<(int,decimal)>> GetPurchaseValueByYear(int customerId)
        {
            IEnumerable<dynamic> metrics = await

                db.SelectMany(
                    db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("Year"),
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount)
                )
                .From(dbo.Purchase)
                .Where(dbo.Purchase.PersonId == customerId)
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
                    dbo.Customer.Id,
                    (dbo.Customer.FirstName + " " + dbo.Customer.LastName).As("Name"),
                    db.fx.IsNull(dbo.PersonTotalPurchasesView.TotalAmount, 0).As("LifetimeValue"),
                    db.fx.Floor(db.fx.DateDiff(DateParts.Day, dbo.Customer.BirthDate, db.fx.GetUtcDate()) / 365.25).As("CurrentAge")
                )
                .From(dbo.Customer)
                .Where(string.IsNullOrWhiteSpace(model.SearchPhrase) ? null : (dbo.Customer.FirstName + " " + dbo.Customer.LastName).Like(model.SearchPhrase + '%'))
                .LeftJoin(dbo.PersonTotalPurchasesView).On(dbo.Customer.Id == dbo.PersonTotalPurchasesView.Id)
                .OrderBy(
                    model.Sort is object ? 
                        (model.Sort.Ascending ? SortConversion[model.Sort.Field].Asc : SortConversion[model.Sort.Field].Desc)
                        :
                        (dbo.Customer.FirstName + " " + dbo.Customer.LastName).Asc
                )
                .Skip(model.Offset).Limit(model.Limit)
                .ExecuteAsync(row => {
                    var customer = new CustomerSummaryModel
                    {
                        Id = row.ReadField().GetValue<int>(),
                        Name = row.ReadField().GetValue<string>(),
                        LifetimeValue = row.ReadField().GetValue<double>(),
                        CurrentAge = row.ReadField().GetValue<short?>(),
                    };
                    customer.IsVIP = customer.LifetimeValue >= LifetimeValueAmountToBeAVIPCustomer;
                    return customer;
                });

            var countOfCustomers = await
                db.SelectOne(
                    db.fx.Count()
                )
                .From(dbo.Customer)
                .LeftJoin(dbo.PersonTotalPurchasesView).On(dbo.Customer.Id == dbo.PersonTotalPurchasesView.Id)
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
            {
                return new AddressModel
                {
                    Type = addressType,
                    Line1 = sqlRow.ReadField().GetValue<string>(),
                    Line2 = sqlRow.ReadField().GetValue<string>(),
                    City = sqlRow.ReadField().GetValue<string>(),
                    State = sqlRow.ReadField().GetValue<string>(),
                    ZIP = sqlRow.ReadField().GetValue<string>()
                };
            };

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
                    db.alias(nameof(CustomerDetailModel.MailingAddress), nameof(dbo.Address.Line1)).ToString(),
                    db.alias(nameof(CustomerDetailModel.MailingAddress), nameof(dbo.Address.Line2)).ToString(),
                    db.alias(nameof(CustomerDetailModel.MailingAddress), nameof(dbo.Address.City)).ToString(),
                    db.alias(nameof(CustomerDetailModel.MailingAddress), nameof(dbo.Address.State)).ToString(),
                    db.alias(nameof(CustomerDetailModel.MailingAddress), nameof(dbo.Address.Zip)).ToString(),
                    db.alias(nameof(CustomerDetailModel.BillingAddress), nameof(dbo.Address.Line1)).ToString(),
                    db.alias(nameof(CustomerDetailModel.BillingAddress), nameof(dbo.Address.Line2)).ToString(),
                    db.alias(nameof(CustomerDetailModel.BillingAddress), nameof(dbo.Address.City)).ToString(),
                    db.alias(nameof(CustomerDetailModel.BillingAddress), nameof(dbo.Address.State)).ToString(),
                    db.alias(nameof(CustomerDetailModel.BillingAddress), nameof(dbo.Address.Zip)).ToString(),
                    db.alias(nameof(CustomerDetailModel.ShippingAddress), nameof(dbo.Address.Line1)).ToString(),
                    db.alias(nameof(CustomerDetailModel.ShippingAddress), nameof(dbo.Address.Line2)).ToString(),
                    db.alias(nameof(CustomerDetailModel.ShippingAddress), nameof(dbo.Address.City)).ToString(),
                    db.alias(nameof(CustomerDetailModel.ShippingAddress), nameof(dbo.Address.State)).ToString(),
                    db.alias(nameof(CustomerDetailModel.ShippingAddress), nameof(dbo.Address.Zip)).ToString()
                )
                .From(dbo.Customer)
                .LeftJoin(dbo.PersonTotalPurchasesView).On(dbo.Customer.Id == dbo.PersonTotalPurchasesView.Id)
                .LeftJoin(
                    db.SelectOne(
                        dbo.CustomerAddress.PersonId,
                        dbo.Address.Line1,
                        dbo.Address.Line2,
                        dbo.Address.City,
                        dbo.Address.State,
                        dbo.Address.Zip
                    )
                    .From(dbo.Address)
                    .InnerJoin(dbo.CustomerAddress).On(dbo.CustomerAddress.AddressId == dbo.Address.Id)
                    .Where(dbo.CustomerAddress.PersonId == customerId & dbo.Address.AddressType == AddressType.Mailing)
                ).As(nameof(CustomerDetailModel.MailingAddress)).On(dbo.Customer.Id == db.alias(nameof(CustomerDetailModel.MailingAddress), nameof(dbo.CustomerAddress.PersonId)).ToInt())
                .LeftJoin(
                    db.SelectOne(
                        dbo.CustomerAddress.PersonId,
                        dbo.Address.Line1,
                        dbo.Address.Line2,
                        dbo.Address.City,
                        dbo.Address.State,
                        dbo.Address.Zip
                    )
                    .From(dbo.Address)
                    .InnerJoin(dbo.CustomerAddress).On(dbo.CustomerAddress.AddressId == dbo.Address.Id)
                    .Where(dbo.CustomerAddress.PersonId == customerId & dbo.Address.AddressType == AddressType.Billing)
                ).As(nameof(CustomerDetailModel.BillingAddress)).On(dbo.Customer.Id == db.alias(nameof(CustomerDetailModel.BillingAddress), nameof(dbo.CustomerAddress.PersonId)).ToInt())
                .LeftJoin(
                    db.SelectOne(
                        dbo.CustomerAddress.PersonId,
                        dbo.Address.Line1,
                        dbo.Address.Line2,
                        dbo.Address.City,
                        dbo.Address.State,
                        dbo.Address.Zip
                    )
                    .From(dbo.Address)
                    .InnerJoin(dbo.CustomerAddress).On(dbo.CustomerAddress.AddressId == dbo.Address.Id)
                    .Where(dbo.CustomerAddress.PersonId == customerId & dbo.Address.AddressType == AddressType.Shipping)
                ).As(nameof(CustomerDetailModel.ShippingAddress)).On(dbo.Customer.Id == db.alias(nameof(CustomerDetailModel.ShippingAddress), nameof(dbo.CustomerAddress.PersonId)).ToInt())
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
                        customer.IsVIP = customer.LifetimeValue >= LifetimeValueAmountToBeAVIPCustomer;
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
                    dbo.Customer.Id,
                    (dbo.Customer.FirstName + " " + dbo.Customer.LastName).As("Name"),
                    db.fx.IsNull(dbo.PersonTotalPurchasesView.TotalAmount, 0).As("LifetimeValue"),
                    db.fx.Floor(db.fx.DateDiff(DateParts.Day, dbo.Customer.BirthDate, db.fx.GetUtcDate()) / 365.25).As("CurrentAge")
                )
                .From(customer)
                .LeftJoin(ptpv).On(ptpv.Id == customer.Id)
                .Skip(0).Limit(length)
                .Where(ptpv.TotalAmount >= LifetimeValueAmountToBeAVIPCustomer) //Lifetime spend > $1,500 is a VIP
                .OrderBy(ptpv.TotalAmount.Desc)
                .ExecuteAsync(row =>
                    new CustomerSummaryModel
                    {
                        Id = row.ReadField().GetValue<int>(),
                        Name = row.ReadField().GetValue<string>(),
                        LifetimeValue = row.ReadField().GetValue<double>(),
                        CurrentAge = row.ReadField().GetValue<short?>(),
                        IsVIP = true
                    }
                );
        }

        public async Task<AddressModel> SaveAddressAsync(int customerId, AddressModel address)
        {
            if (await GetAddressAsync(customerId, address.Type) is object)
            {
                return await UpdateAddressAsync(customerId, address);
            }
            else
            {
                return await InsertAddressAsync(customerId, address);
            }
        }

        public async Task<AddressModel> GetAddressAsync(int customerId, AddressType addressType)
        {
            var address = await db.SelectOne<Address>()
                .From(dbo.Address)
                .InnerJoin(dbo.CustomerAddress).On(dbo.Address.Id == dbo.CustomerAddress.AddressId)
                .Where(dbo.CustomerAddress.PersonId == customerId & dbo.Address.AddressType == addressType)
                .ExecuteAsync();

            return address is object ? new AddressModel
            {
                Line1 = address.Line1,
                Line2 = address.Line2,
                City = address.City,
                State = address.State,
                ZIP = address.Zip
            } : null;
        }

        public async Task<AddressModel> UpdateAddressAsync(int customerId, AddressModel address)
        {
            await db.Update(
                dbo.Address.Line1.Set(address.Line1),
                dbo.Address.Line2.Set(address.Line2),
                dbo.Address.City.Set(address.City),
                dbo.Address.State.Set(address.State),
                dbo.Address.Zip.Set(address.ZIP),
                dbo.Address.DateUpdated.Set(DateTime.UtcNow)
            )
            .From(dbo.Address)
            .InnerJoin(dbo.CustomerAddress).On(dbo.Address.Id == dbo.CustomerAddress.AddressId)
            .Where(dbo.CustomerAddress.PersonId == customerId & dbo.Address.AddressType == address.Type)
            .ExecuteAsync();

            return await GetAddressAsync(customerId, address.Type);
        }

        public async Task<AddressModel> InsertAddressAsync(int customerId, AddressModel address)
        {
            var insertAddress = new Address
            {
                AddressType = address.Type,
                Line1 = address.Line1,
                Line2 = address.Line2,
                City = address.City,
                State = address.State,
                Zip = address.ZIP,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            using (var conn = db.GetConnection())
            {
                conn.Open();
                try
                {
                    conn.BeginTransaction();

                    await db.Insert(insertAddress)
                        .Into(dbo.Address)
                        .ExecuteAsync(conn);

                    await db.Insert(
                            new CustomerAddress
                            {
                                PersonId = customerId,
                                AddressId = insertAddress.Id,
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

            return new AddressModel
            {
                Line1 = insertAddress.Line1,
                Line2 = insertAddress.Line2,
                City = insertAddress.City,
                State = address.State,
                ZIP = insertAddress.Zip
            };
        }
    }
}
