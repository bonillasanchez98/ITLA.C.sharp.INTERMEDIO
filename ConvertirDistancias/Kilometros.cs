namespace ConvertirDistancias
{
    public class Kilometros
    {
        //En esta variable se almacenara la distancia a convertir.
        public double millas = 150;

        //Metodo para convertir de Millas a Kilometros
        public void ConvertirKM()
        {
            //Formula: kilometros = millas × 1.60934
            const double VALOR = 1.60934;

            Console.WriteLine("========== Convertir de Milla a Km ==========");
            double km = millas * VALOR;
            Console.WriteLine("{0} Km", km);

            Console.ReadKey();
        }
    }
}
