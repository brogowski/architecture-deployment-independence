using System;
using System.Collections.Generic;

namespace Features.Products
{
    class GetProductDetailsFeature
    {
        ProductDetails GetDetails(string productId)
        {
            throw new NotImplementedException();
        }
    }

    class ProductDetails
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<string> ImageUrls { get; set; }
    }
}
