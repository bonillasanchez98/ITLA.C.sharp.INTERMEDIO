namespace KISS
{
    public class RestaurantBill
    {
        /// <summary>
        /// Metodo de menu, donde se capturaran y validaran los valores ingresados.
        /// </summary>
        public void Menu()
        {
            Console.Write("Ingrese los precios de los platos separados por comas (ej: 10.50,25.75,5.00): ");
            string priceInput = Console.ReadLine(); // cada precio se almacenaran en esta variable
            string[] princesInput = priceInput.Split(','); // los precios se almacenaran en este array divididos por comas
            Console.WriteLine();
            decimal[] prices;

            try
            {
                prices = princesInput.Select(decimal.Parse).ToArray();
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error {e.Message}: Formato ingresado de los precios de los platos incorrecto!.");
                return;
            }

            Console.Write("Ingrese el porcentaje % de propina que quisera dar (opcional, se da un 10% si deja vacio): ");
            string tipInput = Console.ReadLine();
            decimal? tipPercentage = null; // se inicializa con nulo para poder validar la condicion debajo
            
            if (!String.IsNullOrWhiteSpace(tipInput))
            {
                try
                {
                    tipPercentage = decimal.Parse(tipInput);

                }catch (FormatException e)
                {
                    Console.WriteLine($"Error {e.Message}: Porcentaje ingresado es incorrecto!, ingrese un numero decimal!.");
                    return;
                }
            }
            decimal total = CalculateTotal(prices);
            Console.WriteLine($"El total a pagar es ${total:C2}");
            Console.ReadLine();
        }

        /// <summary>
        /// Metodo para calcular el precio total de los platos
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="tipPercentage"></param>
        /// <returns></returns>
        public decimal CalculateTotal(decimal[] prices, decimal? tipPercentage = 0.10m)
        {            
            decimal subTotal = prices.Sum(); //Sum() sumara todos los valores en secuencia del arreglo prices
            decimal tipAmount = subTotal * (tipPercentage.GetValueOrDefault() / 100); //se asigna el valor enviado, sino se queda el por defecto (10%)
            
            return subTotal + tipAmount;
        }
    }
}
