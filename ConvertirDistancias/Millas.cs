namespace ConvertirDistancias
{
    public class Millas
    {
        //En esta variable se almacenara la distancia a convertir.
        public double km = 150;

        //Metodo para convertir de Kilometros a Millas
        public void ConvertirMillas()
        {
            //Formula: Millas = kilometros × 0.621371

            const double VALOR = 0.621371;
            Console.WriteLine("========== Convertir de Km a Millas =========");
            double millas = km * VALOR;
            Console.WriteLine("{0} Millas", millas);

            Console.ReadLine();
        }
    }
}
