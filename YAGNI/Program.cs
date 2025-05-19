using YAGNI.service;

namespace YAGNI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Ejercicio 3: Aplicando YAGNI (You Aren't Gonna Need It).
             * Un sistema de gestión de productos permite agregar y eliminar productos.
             * Sin embargo, el código contiene un método para generar reportes que aún no es necesario.
             */

            Console.WriteLine("********** Ejercicio 3: Aplicando YAGNI (You Aren't Gonna Need It) **********");
            ProductService productService = new ProductService();
            productService.Menu();
        }
    }
}
