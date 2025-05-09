
namespace Practica_03_05_2025.Entidades
{
    public abstract class Curso : Auditoria
    {
        public string Titulo { get; set; }
        public int Creditos{ get; set; }
        public string Departamento { get; set; }

        public abstract string ObtenerInformacion();
    }
}
