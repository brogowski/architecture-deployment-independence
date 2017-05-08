namespace Features.ShoppingCarts
{
    class EditCartFeature
    {
        private readonly IEditCartFeatureDataAccess _dataAccess;

        public EditCartFeature(IEditCartFeatureDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        void AddProduct(string productId) => _dataAccess.AddProduct(productId);

        void RemoveProduct(string productId) => _dataAccess.RemoveProduct(productId);

        void RemoveAllProducts() => _dataAccess.RemoveAllProducts();
    }

    interface IEditCartFeatureDataAccess
    {
        void AddProduct(string productId);
        void RemoveAllProducts();
        void RemoveProduct(string productId);
    }
}
