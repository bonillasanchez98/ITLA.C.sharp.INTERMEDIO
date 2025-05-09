namespace SistemaGestionDeNomina.Entidades
{
    public abstract class Empleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Departamento { get; set; }
        //public double Sueldo { get; set; }

        protected Empleado()
        {
        }

        protected Empleado(string nombre, string apellido, string correo, string departamento)
        {
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Departamento = departamento;
        }

        /// <summary>
        /// Metodo para calcular los pagos de los empleados.
        /// </summary>
        public abstract void CalcularPago();

        /// <summary>
        /// Metodo que muestra por consola los datos del empleado.
        /// </summary>
        public virtual void MostrarInformacion() 
        {
            Console.WriteLine($"NOMBRE: {Nombre.ToUpper()} {Apellido.ToUpper()}\n" +
                              $"CORREO: {Correo}\n" +
                              $"DEPARTAMENTO: {Departamento}");
            Console.ReadKey();
        }
    }
}
