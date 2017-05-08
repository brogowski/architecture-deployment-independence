using System;
using System.Collections.Generic;

namespace Features.Products
{
    class ListProductsFeature
    {
        public IEnumerable<Product> ListProducts()
        {
            throw new NotImplementedException();
        }
    }

    class Query
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public string SearchText { get; set; }        
    }

    class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
