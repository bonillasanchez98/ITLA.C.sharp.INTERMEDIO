namespace YAGNI.entities
{
    public sealed class Product
    {
        public Product(int productId, string name, decimal price)
        {
            this.productId = productId;
            _Name = name;
            _Price = price;
        }

        public Product()
        {
            productId = ++idCont;
        }

        private int productId { get; set; }
        public string _Name { get; set; }
        public decimal _Price { get; set; }

        private static int idCont = 0;
    }
}
