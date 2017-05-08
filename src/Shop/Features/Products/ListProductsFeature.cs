using System.Collections.Generic;

namespace Features.Products
{
    class ListProductsFeature
    {
        private readonly IListProductsFeatureDataAccess _dataAccess;

        public ListProductsFeature(IListProductsFeatureDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<Product> ListProducts(Query query) => _dataAccess.ListProducts(query);
    }

    interface IListProductsFeatureDataAccess
    {
        IEnumerable<Product> ListProducts(Query query);
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
