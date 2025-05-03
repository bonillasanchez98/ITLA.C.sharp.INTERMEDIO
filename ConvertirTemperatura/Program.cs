namespace ConvertirTemperatura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creacion del objecto Fahrenheit
            TemperaturaFahrenheit fahrenheit = new TemperaturaFahrenheit();
            fahrenheit.ConvertirFahrenheit();

            //Linea divisoria
            Console.WriteLine("==========================================");

            //Cracion del objeto Celsius
            TemperaturaCelsius celsius = new TemperaturaCelsius();
            celsius.ConvertirCelsius();
        }
    }
}
