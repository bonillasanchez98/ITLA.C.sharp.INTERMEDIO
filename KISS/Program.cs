namespace KISS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Ejercicio 1: Aplicando KISS (Keep It Simple, Stupid)
            * Enunciado: Un restaurante necesita calcular el total a pagar por los clientes.
            * Se deben sumar los precios de los platos y agregar una propina opcional.*/

            RestaurantBill restaurantBill = new RestaurantBill();

            Console.WriteLine("********** Ejercicio 1: Aplicando KISS (Keep It Simple, Stupid) **********");
            restaurantBill.Menu();
        }
    }
}
