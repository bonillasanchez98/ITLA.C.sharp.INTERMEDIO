namespace ConvertirTemperatura
{
    public class TemperaturaFahrenheit
    {
        ///Formula: °F = ( °C * 9/5 ) + 32

        double celsius = 23;

        public void ConvertirFahrenheit()
        {
            Console.WriteLine("========== Conversor de Temperatura Fahrenheit ==========");

            double fahrenheit = ((celsius * 9) / 5) + 32;
            Console.WriteLine("°F = {0}", fahrenheit);

            Console.ReadKey();
        }
    }
}
