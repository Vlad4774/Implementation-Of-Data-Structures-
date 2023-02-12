
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace linq
{
    class Stock
    {
        private List<product> products;
        private Action<string, int> stockBelowTenCallback;

        public Stock()
        {
            products = new List<product>();
            stockBelowTenCallback = default;
        }
        public void SetCallBack(Action<string, int> callback)
        {
            stockBelowTenCallback = callback;
        }

        public void AddProductInList(product newProduct)
        {
            products.Add(newProduct);
        }

        public void RemoveProductFromList(product productToRemove)
        {
            products.Remove(productToRemove);
        }

        public void AddStockForAProduct(product productToAddStock, int stockToAdd)
        {
            StockIsAPositiveNumber(stockToAdd);
            products.Single(products => products == productToAddStock).Stock += stockToAdd;
            CheckStockForCallBack(productToAddStock);
        }

        public void RemoveStockForAProduct(product productToRemoveStock, int stockToRemove)
        {
            StockIsAPositiveNumber(stockToRemove);
            StockToRemoveIsAValidNumber(stockToRemove, products.Single(products => products == productToRemoveStock).Stock);
            products.Single(products => products == productToRemoveStock).Stock -= stockToRemove;
            CheckStockForCallBack(productToRemoveStock);
        }

        public bool ContainsProduct(product productToCheck)
        {
            return products.Contains(productToCheck);
        }
        
        public int ReturnStockForAProduct(product productToCheck)
        {
            return products.Single(products => products == productToCheck).Stock;
        }

        private void CheckStockForCallBack(product productToCheck)
        {
            if (stockBelowTenCallback != null)
            {
                int stock = ReturnStockForAProduct(productToCheck);
                if (stock < 10)
                {
                    stockBelowTenCallback(productToCheck.name, stock);
                }
            }
        }

        private void StockIsAPositiveNumber(int stock)
        {
            if (stock <= 0)
            { 
                throw new ArgumentException("stock has to be greater then 0");
            }
        }

        private void StockToRemoveIsAValidNumber(int stockToRemove, int stock)
        {
            if (stockToRemove > stock)
            {
                throw new ArgumentException("Not enough stock to remove");
            }
        }
    }
}