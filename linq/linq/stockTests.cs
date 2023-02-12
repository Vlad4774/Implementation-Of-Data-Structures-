
using Xunit.Sdk;

namespace linq
{
    public class stockTests
    {
        [Fact]
        public void AddProductInList()
        {
            var stock = new Stock();
            var product = new product("miere", 15);
            stock.AddProductInList(product);

            Assert.True(stock.ContainsProduct(product));
            Assert.Equal(15, stock.ReturnStockForAProduct(product));
        }

        [Fact]
        public void RemoveProductFromList()
        {
            var stock = new Stock();
            var product1 = new product("miere", 15);
            var product2 = new product("zahar", 25);
            stock.AddProductInList(product1);
            stock.AddProductInList(product2);
            stock.RemoveProductFromList(product1);

            Assert.False(stock.ContainsProduct(product1));
            Assert.True(stock.ContainsProduct(product2));
        }

        [Fact]
        public void AddStockForAProduct()
        {
            var stock = new Stock();
            var product = new product("miere", 15);
            stock.AddProductInList(product);
            stock.AddStockForAProduct(product, 10);

            Assert.Equal(25, stock.ReturnStockForAProduct(product));
        }

        [Fact]
        public void RemoveStockForAProduct()
        {
            var stock = new Stock();
            var product = new product("miere", 15);
            stock.AddProductInList(product);
            stock.RemoveStockForAProduct(product, 10);

            Assert.Equal(5, stock.ReturnStockForAProduct(product));
        }

        [Fact]
        public void AddStockForAProductThrowsException()
        {
            var stock = new Stock();
            var product = new product("miere", 15);
            stock.AddProductInList(product);

            Assert.Throws<ArgumentException>(() => stock.AddStockForAProduct(product, -10));
        }

        [Fact]
        public void RemoveStockForAProductThrowsException()
        {
            var stock = new Stock();
            var product = new product("miere", 15);
            stock.AddProductInList(product);

            Assert.Throws<ArgumentException>(() => stock.RemoveStockForAProduct(product, -10));
            Assert.Throws<ArgumentException>(() => stock.RemoveStockForAProduct(product, 20));
        }

        [Fact]
        public void CallbackIsCalledWhenStockBelowTen()
        {
            var stock = new Stock();
            var product = new product("miere", 14);
            stock.AddProductInList(product);

            string callbackName = null;
            int callbackStock = -1;
            stock.SetCallBack((name, stock) =>
            {
                callbackName = name;
                callbackStock = stock;
            });

            stock.RemoveStockForAProduct(product, 5);

            Assert.Equal("miere", callbackName);
            Assert.Equal(9, callbackStock);
        }
    }
}
