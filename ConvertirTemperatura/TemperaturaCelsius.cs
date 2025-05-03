namespace ConvertirTemperatura
{
    public class TemperaturaCelsius
    {
        //Formula: °C = 5/9 (°F - 32)

        double fahrenheit = 73;

        public void ConvertirCelsius()
        {
            Console.WriteLine("========== Conversor de Temperatura Celsius =============");
            double celsius = (5 * (fahrenheit - 32) )/ 9; 
            Console.WriteLine("°C = {0}", celsius);
            Console.ReadLine();
        }

    }
}
