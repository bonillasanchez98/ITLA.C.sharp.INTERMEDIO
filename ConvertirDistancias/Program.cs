namespace ConvertirDistancias
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Creacion de objeto de tipo Kilometros
            Kilometros km = new Kilometros();
            km.ConvertirKM();

            //Creacion de objeto de tipo Millas
            Millas millas = new Millas();
            millas.ConvertirMillas();
        }
    }
}
