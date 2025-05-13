namespace SistemaGestionDeNomina.Entidades
{
    public abstract class Empleado
    {
        public string _Nombre { get; set; }
        public string _Apellido { get; set; }
        public string _Correo { get; set; }
        public string _Departamento { get; set; }
        public double _Sueldo { get; set; }

        protected Empleado()
        {
        }

        protected Empleado(string nombre, string apellido, string correo, string departamento, double sueldo)
        {
            _Nombre = nombre;
            _Apellido = apellido;
            _Correo = correo;
            _Departamento = departamento;
            _Sueldo = sueldo;
        }

        /// <summary>
        /// Metodo para calcular los pagos de los empleados.
        /// </summary>
        public virtual double CalcularPago() {
            
            return _Sueldo;
        }

        /// <summary>
        /// Metodo que muestra por consola los datos del empleado.
        /// </summary>
        public abstract void MostrarInformacion();
        
    }
}
