using System.Collections.Generic;
using System.Linq;

namespace Features.Orders
{
    class GetOrderSummaryFeature
    {
        private readonly IGetOrderSummaryFeatureDataAccess _dataAccess;
        private readonly IPaymentProcessor _paymentProcessor;

        public GetOrderSummaryFeature(IGetOrderSummaryFeatureDataAccess dataAccess, IPaymentProcessor paymentProcessor)
        {
            _dataAccess = dataAccess;
            _paymentProcessor = paymentProcessor;
        }

        OrderSummary GetNewOrderSummary(IEnumerable<string> productIds) => GetOrderSummaryForProducts(productIds, OrderStatus.New);

        OrderSummary GetOrderSummary(string orderId)
        {
            var productIds = _dataAccess.GetProductsFromOrder(orderId);
            var status = GetOrderStatus(orderId);
            return GetOrderSummaryForProducts(productIds, status);
        }

        private OrderStatus GetOrderStatus(string orderId)
        {
            if (_dataAccess.OrderIsCancelled(orderId)) { return OrderStatus.Cancelled; }
            if (_paymentProcessor.OrderIsPaid(orderId)) { return OrderStatus.Completed; }
            return OrderStatus.Confirmed;
        }

        private OrderSummary GetOrderSummaryForProducts(IEnumerable<string> productIds, OrderStatus status)
        {
            var details = _dataAccess.GetProductDetails(productIds.Distinct());
            var summaries = details.Select(x => new ProductSummary(x, CountProducts(x.Id, productIds))).ToList();
            return new OrderSummary(summaries, status);
        }

        private static int CountProducts(string id, IEnumerable<string> allIds) => allIds.Count(x => x == id);
    }

    interface IPaymentProcessor
    {
        bool OrderIsPaid(string orderId);
    }

    interface IGetOrderSummaryFeatureDataAccess
    {
        IEnumerable<ProductDetails> GetProductDetails(IEnumerable<string> productIds);
        IEnumerable<string> GetProductsFromOrder(string orderId);
        bool OrderIsCancelled(string orderId);
    }

    class ProductDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }

    class OrderSummary
    {
        public OrderSummary(List<ProductSummary> summaries, OrderStatus status)
        {
            Products = summaries;
            TotalPrice = summaries.Sum(x => x.Price * x.Quantity);
            Status = status;
        }

        public decimal TotalPrice { get; set; }
        public IEnumerable<ProductSummary> Products { get; set; }
        public OrderStatus Status { get; set; }
    }

    class ProductSummary
    {
        public ProductSummary(ProductDetails details, int count)
        {
            Id = details.Id;
            Name = details.Name;
            ImageUrl = details.ImageUrl;
            Price = details.Price;
            Quantity = count;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
