using System;
using System.Collections.Generic;

namespace Features.ShoppingCarts
{
    class GetCartFeature
    {
        ShoppingCartBrief GetShoppingCartBrief()
        {
            throw new NotImplementedException();
        }

        ShoppingCart GetShoppingCartSummary()
        {
            throw new NotImplementedException();
        }
    }

    class ShoppingCartBrief
    {
        public int ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
    }

    class ShoppingCart
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
