using System.Collections.Generic;

namespace Features.Products
{
    class GetProductDetailsFeature
    {
        private readonly IGetProductDetailsFeatureDataAccess _dataAccess;

        public GetProductDetailsFeature(IGetProductDetailsFeatureDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        ProductDetails GetDetails(string productId) => _dataAccess.GetProductDetails(productId);
    }

    interface IGetProductDetailsFeatureDataAccess
    {
        ProductDetails GetProductDetails(string productId);
    }

    class ProductDetails
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<string> ImageUrls { get; set; }
    }
}
