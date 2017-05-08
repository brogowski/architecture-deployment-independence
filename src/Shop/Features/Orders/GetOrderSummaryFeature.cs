using System;
using System.Collections.Generic;

namespace Features.Orders
{
    class GetOrderSummaryFeature
    {
        OrderSummary GetOrderSummary(IEnumerable<string> productIds)
        {
            throw new NotImplementedException();
        }
    }

    class OrderSummary
    {
        public decimal TotalPrice { get; set; }
        public IEnumerable<ProductSummary> Products { get; set; }
    }

    class ProductSummary
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
