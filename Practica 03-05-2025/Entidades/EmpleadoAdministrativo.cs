namespace Practica_03_05_2025.Entidades
{
    public sealed class EmpleadoAdministrativo : Empleado
    {
        public string AreaDeTrabajo { get; set; }
        public string Departamento { get; set; }

        public override void ObtenerInformacion()
        {
            //Mostrar informacion del empleado administrativo
            base.ObtenerInformacion();
        }

        public override void CalcularSueldo()
        {
            //Calcular el sueldo del empleado administrativo
            base.CalcularSueldo();
        }
    }
}
