
namespace linq
{
    class product
    {
        public string name;
        public int Stock { get; internal set; }

        public product(string name, int stock)
        {
            this.name = name;
            this.Stock = stock;
        }
    }
}
