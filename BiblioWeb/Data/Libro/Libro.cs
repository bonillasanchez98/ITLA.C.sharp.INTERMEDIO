﻿namespace BiblioWeb.Data.Libro
{
    public class Libro
    {
        public int id_Libro { get; set; }
        public string Titulo { get; set; }
        public int Autor_id { get; set; }
        public string ISBN { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public int Categoria_id { get; set; }
        public int CantidadEjemplares { get; set; }
    }
}
