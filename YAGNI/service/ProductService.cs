using YAGNI.entities;

namespace YAGNI.service
{
    public class ProductService
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(string name, decimal price)
        {
            products.Add(new Product { _Name = name, _Price = price });
            Console.WriteLine($"Product: {name}\n" +
                              $"Price: ${price}\n");
        }

        public void DeleteProduct(int productId)
        {
            if (!productId.Equals(0))
            {
                products.Remove(products[productId]);
                Console.WriteLine($"Product {productId} deleted.");
            }
            else
                Console.WriteLine("Product id not found!");
        }

        public void Menu()
        {
            try
            {
                Console.WriteLine("Seleccione una opcion: \n");
                Console.WriteLine("1. Agregar producto\n" +
                                  "2. Eliminar producto\n");
                ChooseOption(int.Parse(Console.ReadLine()));
            }
            catch
            {
                throw new Exception("Error, Debe seleccionar uno de las opciones del menu!");
            }
        }

        private void ChooseOption(int option)
        {
            switch (option)
            {
                case 1:
                    Console.Write("Ingrese el nombre del producto: ");
                    string productName = Console.ReadLine();
                    Console.Write("Ingrese el precion del producto: ");
                    decimal productPrice = Convert.ToDecimal(Console.ReadLine());
                    AddProduct(productName, productPrice);
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Ingrese Id del producto a Eliminar: ");
                    int productId = int.Parse(Console.ReadLine());
                    DeleteProduct(productId);
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Opcion incorrecta, favor verifique!");
                    Console.ReadLine();
                    break;

            }
        }
    }
}
