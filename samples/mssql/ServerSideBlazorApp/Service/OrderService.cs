using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using ServerSideBlazorApp.Data;
using ServerSideBlazorApp.DataService;
using ServerSideBlazorApp.dboDataService;
using ServerSideBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Service
{
    /// <summary>
    /// A service that provides methods to retrieve Order information from the database.
    /// </summary>
    /// <remarks>
    /// While C# code uses the type name 'Ordere', the database table is actually named 'Purchase'.  This was done simply to match the semantics of this sample application.
    /// The configuration to change the table name was specified in dbex.config.json, which resulted in a code generated type name of 'Orders'.
    /// </remarks>
    public class OrderService
    {
        private readonly CRMDatabase CRMDatabase;

        //variable to hold dbExpression order by elements.  Stored as a variable as it's used more than once and to demonstrate that order by elements can be treated like most any other .NET object
        private static readonly IDictionary<string, AnyElement> OrderSummarySortingFields = new Dictionary<string, AnyElement>
        {
            { nameof(OrderSummaryModel.OrderNumber), dbo.Purchase.OrderNumber },
            { nameof(OrderSummaryModel.CustomerName), dbo.Customer.FirstName + " " + dbo.Customer.LastName },
            { nameof(OrderSummaryModel.PaymentMethod), dbo.Purchase.PaymentMethodType },
            { nameof(OrderSummaryModel.TotalPurchaseAmount), dbo.Purchase.TotalPurchaseAmount },
            { nameof(OrderSummaryModel.PurchaseDate), dbo.Purchase.PurchaseDate },
            { nameof(OrderSummaryModel.ShipDate), dbo.Purchase.ShipDate }
        };

        public OrderService(CRMDatabase crmDatabase)
        {
            this.CRMDatabase = crmDatabase ?? throw new ArgumentNullException(nameof(crmDatabase));
        }

        /// <summary>
        /// Search for orders, and retrieve a paged list using the supplied paging parameters.
        /// </summary>
        /// <param name="pagingParameters">A set of parameters specifying the offset, limit, and sorting criteria used in the SQL statement.</param>
        public async Task<Page<OrderSummaryModel>> GetOrdersPageAsync(PagingParameters pagingParameters)
        {
            var orders = await
                CRMDatabase.SelectMany(
                    dbo.Purchase.Id,
                    dbo.Purchase.CustomerId,
                    dbo.Customer.FirstName + " " + dbo.Customer.LastName,
                    db.fx.IsNull(dbo.PersonTotalPurchasesView.TotalAmount, 0).As(nameof(CustomerSummaryModel.LifetimeValue)),
                    dbo.Purchase.OrderNumber,
                    dbo.Purchase.PaymentMethodType,
                    dbo.Purchase.TotalPurchaseAmount,
                    dbo.Purchase.PurchaseDate,
                    dbo.Purchase.ShipDate
                )
                .From(dbo.Purchase)
                .InnerJoin(dbo.Customer).On(dbo.Purchase.CustomerId == dbo.Customer.Id)
                .LeftJoin(dbo.PersonTotalPurchasesView).On(dbo.Customer.Id == dbo.PersonTotalPurchasesView.Id)
                .OrderBy(
                    pagingParameters.Sorting?.Select(
                        s => s.Direction == OrderExpressionDirection.ASC 
                            ? OrderSummarySortingFields[s.Field].Asc : OrderSummarySortingFields[s.Field].Desc
                    )!
                )
                .Offset(pagingParameters.Offset).Limit(pagingParameters.Limit)
                .ExecuteAsync(reader =>
                    new OrderSummaryModel
                    {
                        Id = reader.ReadField()!.GetValue<int>(),
                        CustomerId = reader.ReadField()!.GetValue<int>(),
                        CustomerName = reader.ReadField()!.GetValue<string>(),
                        IsVIP = reader.ReadField()!.GetValue<double>() >= Rules.LifetimeValueAmountToBeAVIPCustomer,
                        OrderNumber = reader.ReadField()!.GetValue<string>(),
                        PaymentMethod = reader.ReadField()!.GetValue<PaymentMethodType>(),
                        TotalPurchaseAmount = reader.ReadField()!.GetValue<double>(),
                        PurchaseDate = reader.ReadField()!.GetValue<DateTime>(),
                        ShipDate = reader.ReadField()!.GetValue<DateTime?>()
                    }
                );

            var countOfOrders = await
                CRMDatabase.SelectOne(
                    db.fx.Count()
                )
                .From(dbo.Purchase)
                .ExecuteAsync();

            return new Page<OrderSummaryModel>(
                pagingParameters,
                orders,
                countOfOrders
            );
        }

        /// <summary>
        /// Search for orders for a specific customer, and retrieve a paged list using the supplied paging parameters.
        /// </summary>
        /// <param name="customerId">The id of the customer that is used as a parameter in the where clause of the SQL statement.</param>
        /// <param name="pagingParameters">A set of parameters specifying the offset, limit, and sorting criteria used in the SQL statement.</param>
        public async Task<Page<OrderSummaryModel>> GetCustomerOrdersPageAsync(int customerId, PagingParameters pagingParameters)
        {
            var orders = await
                CRMDatabase.SelectMany(
                    dbo.Purchase.Id,
                    dbo.Purchase.CustomerId,
                    dbo.Customer.FirstName + " " + dbo.Customer.LastName,
                    db.fx.IsNull(dbo.PersonTotalPurchasesView.TotalAmount, 0).As(nameof(OrderSummaryModel.TotalPurchaseAmount)),
                    dbo.Purchase.OrderNumber,
                    dbo.Purchase.PaymentMethodType,
                    dbo.Purchase.TotalPurchaseAmount,
                    dbo.Purchase.PurchaseDate,
                    dbo.Purchase.ShipDate
                )
                .From(dbo.Purchase)
                .InnerJoin(dbo.Customer).On(dbo.Purchase.CustomerId == dbo.Customer.Id)
                .LeftJoin(dbo.PersonTotalPurchasesView).On(dbo.Customer.Id == dbo.PersonTotalPurchasesView.Id)
                .Where(dbo.Purchase.CustomerId == customerId)
                .OrderBy(
                    pagingParameters.Sorting?.Select(
                        s => s.Direction == OrderExpressionDirection.ASC 
                        ? OrderSummarySortingFields[s.Field].Asc : OrderSummarySortingFields[s.Field].Desc
                    )!
                )
                .Offset(pagingParameters.Offset).Limit(pagingParameters.Limit)
                .ExecuteAsync(reader =>
                    new OrderSummaryModel
                    {
                        Id = reader.ReadField()!.GetValue<int>(),
                        CustomerId = reader.ReadField()!.GetValue<int>(),
                        CustomerName = reader.ReadField()!.GetValue<string>(),
                        IsVIP = reader.ReadField()!.GetValue<double>() >= Rules.LifetimeValueAmountToBeAVIPCustomer,
                        OrderNumber = reader.ReadField()!.GetValue<string>(),
                        PaymentMethod = reader.ReadField()!.GetValue<PaymentMethodType>(),
                        TotalPurchaseAmount = reader.ReadField()!.GetValue<double>(),
                        PurchaseDate = reader.ReadField()!.GetValue<DateTime>(),
                        ShipDate = reader.ReadField()!.GetValue<DateTime?>()
                    }
                );

            var countOfOrders = await
                CRMDatabase.SelectOne(
                    db.fx.Count()
                )
                .From(dbo.Purchase)
                .Where(dbo.Purchase.CustomerId == customerId)
                .ExecuteAsync();

            return new Page<OrderSummaryModel>(
                pagingParameters,
                orders,
                countOfOrders
            );
        }

        /// <summary>
        /// Fetch a specific order by id.
        /// </summary>
        public async Task<OrderDetailModel?> GetOrderAsync(int orderId)
        {
            var billingAddress = nameof(OrderDetailModel.BillingAddress);
            var shippingAddress = nameof(OrderDetailModel.ShippingAddress);

            //get the root order, passing a mapping function to execute
            var order = await CRMDatabase.SelectOne(
                dbo.Purchase.Id,
                dbo.Customer.Id.As(nameof(OrderDetailModel.CustomerId)),
                (dbo.Customer.FirstName + " " + dbo.Customer.LastName).As(nameof(OrderDetailModel.CustomerName)),
                db.fx.IsNull(dbo.PersonTotalPurchasesView.TotalAmount, 0).As(nameof(OrderDetailModel.TotalPurchaseAmount)),
                dbo.Purchase.OrderNumber,
                dbo.Purchase.TotalPurchaseAmount,
                dbo.Purchase.PurchaseDate,
                dbo.Purchase.ShipDate,
                dbo.Purchase.PaymentMethodType,
                dbo.Purchase.ExpectedDeliveryDate,
                dbo.Purchase.TrackingIdentifier,
                dbex.Alias<string>(billingAddress, nameof(dbo.Address.Line1)),
                dbex.Alias<string>(billingAddress, nameof(dbo.Address.Line2)),
                dbex.Alias<string>(billingAddress, nameof(dbo.Address.City)),
                dbex.Alias<string>(billingAddress, nameof(dbo.Address.State)),
                dbex.Alias<string>(billingAddress, nameof(dbo.Address.Zip)),
                dbex.Alias<string>(shippingAddress, nameof(dbo.Address.Line1)),
                dbex.Alias<string>(shippingAddress, nameof(dbo.Address.Line2)),
                dbex.Alias<string>(shippingAddress, nameof(dbo.Address.City)),
                dbex.Alias<string>(shippingAddress, nameof(dbo.Address.State)),
                dbex.Alias<string>(shippingAddress, nameof(dbo.Address.Zip))
            )
            .From(dbo.Purchase)
            .InnerJoin(dbo.Customer).On(dbo.Purchase.CustomerId == dbo.Customer.Id)
            .LeftJoin(dbo.PersonTotalPurchasesView).On(dbo.Customer.Id == dbo.PersonTotalPurchasesView.Id)
            .LeftJoin(
                CRMDatabase.SelectOne(
                    dbo.CustomerAddress.CustomerId.As(nameof(OrderDetailModel.CustomerId)),
                    dbo.Address.Line1,
                    dbo.Address.Line2,
                    dbo.Address.City,
                    dbo.Address.State,
                    dbo.Address.Zip
                )
                .From(dbo.Address)
                .InnerJoin(dbo.CustomerAddress).On(dbo.CustomerAddress.AddressId == dbo.Address.Id)
                .InnerJoin(dbo.Purchase).On(dbo.CustomerAddress.CustomerId == dbo.Purchase.CustomerId)
                .Where(dbo.Purchase.Id == orderId & dbo.Address.AddressType == AddressType.Billing)
            ).As(billingAddress).On(dbo.Customer.Id == dbex.Alias(billingAddress, nameof(OrderDetailModel.CustomerId)))
            .LeftJoin(
                CRMDatabase.SelectOne(
                    dbo.CustomerAddress.CustomerId.As(nameof(OrderDetailModel.CustomerId)),
                    dbo.Address.Line1,
                    dbo.Address.Line2,
                    dbo.Address.City,
                    dbo.Address.State,
                    dbo.Address.Zip
                )
                .From(dbo.Address)
                .InnerJoin(dbo.CustomerAddress).On(dbo.CustomerAddress.AddressId == dbo.Address.Id)
                .InnerJoin(dbo.Purchase).On(dbo.CustomerAddress.CustomerId == dbo.Purchase.CustomerId)
                .Where(dbo.Purchase.Id == orderId & dbo.Address.AddressType == AddressType.Shipping)
            ).As(shippingAddress).On(dbo.Customer.Id == dbex.Alias(shippingAddress, nameof(OrderDetailModel.CustomerId)))
            .Where(dbo.Purchase.Id == orderId)
            .ExecuteAsync(
                reader => new OrderDetailModel
                    {
                        Id = reader.ReadField()!.GetValue<int>(),
                        CustomerId = reader.ReadField()!.GetValue<int>(),
                        CustomerName = reader.ReadField()!.GetValue<string>(),
                        IsVIP = reader.ReadField()!.GetValue<double>() >= Rules.LifetimeValueAmountToBeAVIPCustomer,
                        OrderNumber = reader.ReadField()!.GetValue<string>(),
                        TotalPurchaseAmount = reader.ReadField()!.GetValue<double>(),
                        PurchaseDate = reader.ReadField()!.GetValue<DateTime>(),
                        ShipDate = reader.ReadField()!.GetValue<DateTime?>(),
                        PaymentMethod = reader.ReadField()!.GetValue<PaymentMethodType>(),
                        ExpectedDeliveryDate = reader.ReadField()!.GetValue<DateTime?>(),
                        TrackingIdentifier = reader.ReadField()!.GetValue<Guid?>(),
                        BillingAddress = new AddressModel
                        {
                            Type = AddressType.Billing,
                            Line1 = reader.ReadField()!.GetValue<string>(),
                            Line2 = reader.ReadField()!.GetValue<string>(),
                            City = reader.ReadField()!.GetValue<string>(),
                            State = reader.ReadField()!.GetValue<string>(),
                            ZIP = reader.ReadField()!.GetValue<string>()
                        },
                        ShippingAddress = new AddressModel
                        {
                            Type = AddressType.Shipping,
                            Line1 = reader.ReadField()!.GetValue<string>(),
                            Line2 = reader.ReadField()!.GetValue<string>(),
                            City = reader.ReadField()!.GetValue<string>(),
                            State = reader.ReadField()!.GetValue<string>(),
                            ZIP = reader.ReadField()!.GetValue<string>()
                        }
                    }
            );

            if (order is null)
                return null;

            //get all of the order lines for the order
            var orderLines = await CRMDatabase.SelectMany(
                dbo.Product.ProductCategoryType,
                dbo.Product.Name,
                dbo.PurchaseLine.PurchasePrice,
                dbo.PurchaseLine.Quantity,
                (dbo.PurchaseLine.PurchasePrice * dbo.PurchaseLine.Quantity).As(nameof(OrderLineModel.Subtotal))
            )
            .From(dbo.PurchaseLine)
            .InnerJoin(dbo.Purchase).On(dbo.PurchaseLine.PurchaseId == dbo.Purchase.Id)
            .InnerJoin(dbo.Product).On(dbo.PurchaseLine.ProductId == dbo.Product.Id)
            .Where(dbo.Purchase.Id == orderId)
            .ExecuteAsync();

            //map to models seperate from the execution (no technical reason, just demonstrating the use of the database data seperate from mapping operation)
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

        /// <summary>
        /// Fetch the total sales for all products, aggregated by date of sale.
        /// </summary>
        public async Task<IList<dynamic>> GetRecentSalesByDay()
        {
            return await CRMDatabase.SelectMany(
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

        /// <summary>
        /// Fetch the total sales for all products, aggregated by product category.
        /// </summary>
        public async Task<IList<dynamic>> GetSalesByProductCategory()
        {
            return await CRMDatabase.SelectMany(
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
