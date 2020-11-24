using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using ServerSideBlazorApp.Data;
using ServerSideBlazorApp.DataService;
using ServerSideBlazorApp.dboDataService;
using ServerSideBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Service
{
    public class OrderService : ServiceBase
    {
        public async Task<PageResponseModel<OrderSummaryModel>> GetOrdersPageAsync(PageModel model)
        {
            var orders = await
                db.SelectMany(
                    dbo.Purchase.Id,
                    dbo.Purchase.PersonId,
                    dbo.Customer.FirstName + " " + dbo.Customer.LastName,
                    db.fx.IsNull(dbo.PersonTotalPurchasesView.TotalAmount, 0).As("LifetimeValue"),
                    dbo.Purchase.OrderNumber,
                    dbo.Purchase.PaymentMethodType,
                    dbo.Purchase.TotalPurchaseAmount,
                    dbo.Purchase.PurchaseDate,
                    dbo.Purchase.ShipDate
                )
                .From(dbo.Purchase)
                .InnerJoin(dbo.Customer).On(dbo.Purchase.PersonId == dbo.Customer.Id)
                .LeftJoin(dbo.PersonTotalPurchasesView).On(dbo.Customer.Id == dbo.PersonTotalPurchasesView.Id)
                .OrderBy(dbo.Purchase.PurchaseDate.Desc)
                .Skip(model.Offset).Limit(model.Limit)
                .ExecuteAsync(row =>
                    new OrderSummaryModel
                    {
                        Id = row.ReadField().GetValue<int>(),
                        CustomerId = row.ReadField().GetValue<int>(),
                        CustomerName = row.ReadField().GetValue<string>(),
                        IsVIP = row.ReadField().GetValue<double>() >= LifetimeValueAmountToBeAVIPCustomer,
                        OrderNumber = row.ReadField().GetValue<string>(),
                        PaymentMethod = row.ReadField().GetValue<PaymentMethodType>(),
                        TotalPurchaseAmount = row.ReadField().GetValue<double>(),
                        PurchaseDate = row.ReadField().GetValue<DateTime>(),
                        ShipDate = row.ReadField().GetValue<DateTime?>()
                    }
                );

            var countOfOrders = await
                db.SelectOne(
                    db.fx.Count()
                )
                .From(dbo.Purchase)
                .ExecuteAsync();

            return new PageResponseModel<OrderSummaryModel>(
                model.Offset,
                model.Limit,
                model.SearchPhrase,
                orders,
                countOfOrders
            );
        }

        public async Task<PageResponseModel<OrderSummaryModel>> GetCustomerOrdersPageAsync(int customerId, PageModel model)
        {
            var orders = await
                db.SelectMany(
                    dbo.Purchase.Id,
                    dbo.Purchase.PersonId,
                    dbo.Customer.FirstName + " " + dbo.Customer.LastName,
                    db.fx.IsNull(dbo.PersonTotalPurchasesView.TotalAmount, 0).As("LifetimeValue"),
                    dbo.Purchase.OrderNumber,
                    dbo.Purchase.PaymentMethodType,
                    dbo.Purchase.TotalPurchaseAmount,
                    dbo.Purchase.PurchaseDate,
                    dbo.Purchase.ShipDate
                )
                .From(dbo.Purchase)
                .InnerJoin(dbo.Customer).On(dbo.Purchase.PersonId == dbo.Customer.Id)
                .LeftJoin(dbo.PersonTotalPurchasesView).On(dbo.Customer.Id == dbo.PersonTotalPurchasesView.Id)
                .Where(dbo.Purchase.PersonId == customerId)
                .OrderBy(dbo.Purchase.PurchaseDate.Desc)
                .Skip(model.Offset).Limit(model.Limit)
                .ExecuteAsync(row =>
                    new OrderSummaryModel
                    {
                        Id = row.ReadField().GetValue<int>(),
                        CustomerId = row.ReadField().GetValue<int>(),
                        CustomerName = row.ReadField().GetValue<string>(),
                        IsVIP = row.ReadField().GetValue<double>() >= LifetimeValueAmountToBeAVIPCustomer,
                        OrderNumber = row.ReadField().GetValue<string>(),
                        PaymentMethod = row.ReadField().GetValue<PaymentMethodType>(),
                        TotalPurchaseAmount = row.ReadField().GetValue<double>(),
                        PurchaseDate = row.ReadField().GetValue<DateTime>(),
                        ShipDate = row.ReadField().GetValue<DateTime?>()
                    }
                );

            var countOfOrders = await
                db.SelectOne(
                    db.fx.Count()
                )
                .From(dbo.Purchase)
                .Where(dbo.Purchase.PersonId == customerId)
                .ExecuteAsync();

            return new PageResponseModel<OrderSummaryModel>(
                model.Offset,
                model.Limit,
                model.SearchPhrase,
                orders,
                countOfOrders
            );
        }

        public async Task<OrderDetailModel> GetOrderAsync(int orderId)
        {
            var billingAddress = nameof(OrderDetailModel.BillingAddress);
            var shippingAddress = nameof(OrderDetailModel.ShippingAddress);
            static Int32ExpressionMediator int_alias(string table, string field) => db.alias(table, field).AsInt32();
            static StringElement string_alias(string table, string field) => db.alias(table, field).AsString();

            //get the root order, passing a mapping function to execute
            var order = await db.SelectOne(
                dbo.Purchase.Id,
                dbo.Customer.Id.As("CustomerId"),
                (dbo.Customer.FirstName + " " + dbo.Customer.LastName).As("CustomerName"),
                db.fx.IsNull(dbo.PersonTotalPurchasesView.TotalAmount, 0).As("LifetimeValue"),
                dbo.Purchase.OrderNumber,
                dbo.Purchase.TotalPurchaseAmount,
                dbo.Purchase.PurchaseDate,
                dbo.Purchase.ShipDate,
                dbo.Purchase.PaymentMethodType,
                dbo.Purchase.ExpectedDeliveryDate,
                dbo.Purchase.TrackingIdentifier,
                string_alias(billingAddress, nameof(dbo.Address.Line1)),
                string_alias(billingAddress, nameof(dbo.Address.Line2)),
                string_alias(billingAddress, nameof(dbo.Address.City)),
                string_alias(billingAddress, nameof(dbo.Address.State)),
                string_alias(billingAddress, nameof(dbo.Address.Zip)),
                string_alias(shippingAddress, nameof(dbo.Address.Line1)),
                string_alias(shippingAddress, nameof(dbo.Address.Line2)),
                string_alias(shippingAddress, nameof(dbo.Address.City)),
                string_alias(shippingAddress, nameof(dbo.Address.State)),
                string_alias(shippingAddress, nameof(dbo.Address.Zip))
            )
            .From(dbo.Purchase)
            .InnerJoin(dbo.Customer).On(dbo.Purchase.PersonId == dbo.Customer.Id)
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
                .InnerJoin(dbo.Purchase).On(dbo.CustomerAddress.PersonId == dbo.Purchase.PersonId)
                .Where(dbo.Purchase.Id == orderId & dbo.Address.AddressType == AddressType.Billing)
            ).As(billingAddress).On(dbo.Customer.Id == int_alias(billingAddress, nameof(dbo.CustomerAddress.PersonId)))
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
                .InnerJoin(dbo.Purchase).On(dbo.CustomerAddress.PersonId == dbo.Purchase.PersonId)
                .Where(dbo.Purchase.Id == orderId & dbo.Address.AddressType == AddressType.Shipping)
            ).As(shippingAddress).On(dbo.Customer.Id == int_alias(shippingAddress, nameof(dbo.CustomerAddress.PersonId)))
            .Where(dbo.Purchase.Id == orderId)
            .ExecuteAsync(
                row => new OrderDetailModel
                    {
                        Id = row.ReadField().GetValue<int>(),
                        CustomerId = row.ReadField().GetValue<int>(),
                        CustomerName = row.ReadField().GetValue<string>(),
                        IsVIP = row.ReadField().GetValue<double>() >= LifetimeValueAmountToBeAVIPCustomer,
                        OrderNumber = row.ReadField().GetValue<string>(),
                        TotalPurchaseAmount = row.ReadField().GetValue<double>(),
                        PurchaseDate = row.ReadField().GetValue<DateTime>(),
                        ShipDate = row.ReadField().GetValue<DateTime?>(),
                        PaymentMethod = row.ReadField().GetValue<PaymentMethodType>(),
                        ExpectedDeliveryDate = row.ReadField().GetValue<DateTime?>(),
                        TrackingIdentifier = row.ReadField().GetValue<Guid?>(),
                        BillingAddress = new AddressModel
                        {
                            Type = AddressType.Billing,
                            Line1 = row.ReadField().GetValue<string>(),
                            Line2 = row.ReadField().GetValue<string>(),
                            City = row.ReadField().GetValue<string>(),
                            State = row.ReadField().GetValue<string>(),
                            ZIP = row.ReadField().GetValue<string>()
                        },
                        ShippingAddress = new AddressModel
                        {
                            Type = AddressType.Shipping,
                            Line1 = row.ReadField().GetValue<string>(),
                            Line2 = row.ReadField().GetValue<string>(),
                            City = row.ReadField().GetValue<string>(),
                            State = row.ReadField().GetValue<string>(),
                            ZIP = row.ReadField().GetValue<string>()
                        }
                    }
            );

            //get all of the order lines for the order
            var orderLines = await db.SelectMany(
                dbo.Product.ProductCategoryType,
                dbo.Product.Name,
                dbo.PurchaseLine.PurchasePrice,
                dbo.PurchaseLine.Quantity,
                (dbo.PurchaseLine.PurchasePrice * dbo.PurchaseLine.Quantity).As("Subtotal")
            )
            .From(dbo.PurchaseLine)
            .InnerJoin(dbo.Purchase).On(dbo.PurchaseLine.PurchaseId == dbo.Purchase.Id)
            .InnerJoin(dbo.Product).On(dbo.PurchaseLine.ProductId == dbo.Product.Id)
            .Where(dbo.Purchase.Id == orderId)
            .ExecuteAsync();

            //map to models seperate from the execution
            foreach (var orderLine in orderLines)
            {
                order.Lines.Add(
                    new OrderLineModel
                    {
                        Category = orderLine.ProductCategoryType,
                        Name = orderLine.Name,
                        PurchasePrice = Convert.ToDouble(orderLine.PurchasePrice), //PurchasePrice in database is typed as a decimal
                        Quantity = orderLine.Quantity,
                        Subtotal = Convert.ToDouble(orderLine.Subtotal) //PurchasePrice in database is typed as a decimal, therefore multiplication results in a decimal
                    }
                );
            };

            return order;
        }

        public async Task<IList<dynamic>> GetRecentSalesByDay()
        {
            return await db.SelectMany(
                db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate).As("Year"),
                db.fx.DatePart(DateParts.Month, dbo.Purchase.PurchaseDate).As("Month"),
                db.fx.DatePart(DateParts.Day, dbo.Purchase.PurchaseDate).As("Day"),
                db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).As("TotalSales")
            )
            .From(dbo.Purchase)
            .GroupBy(
                db.fx.DatePart(DateParts.Year, dbo.Purchase.PurchaseDate),
                db.fx.DatePart(DateParts.Month, dbo.Purchase.PurchaseDate),
                db.fx.DatePart(DateParts.Day, dbo.Purchase.PurchaseDate)
            )
            .ExecuteAsync();
        }

        public async Task<IList<dynamic>> GetSalesByProductCategory()
        {
            return await db.SelectMany(
                dbo.Product.ProductCategoryType,
                db.fx.Sum(dbo.PurchaseLine.PurchasePrice * dbo.PurchaseLine.Quantity).As("TotalSales")
            )
            .From(dbo.PurchaseLine)
            .InnerJoin(dbo.Product).On(dbo.PurchaseLine.ProductId == dbo.Product.Id)
            .GroupBy(
                dbo.Product.ProductCategoryType
            )
            .ExecuteAsync();
        }
    }
}
