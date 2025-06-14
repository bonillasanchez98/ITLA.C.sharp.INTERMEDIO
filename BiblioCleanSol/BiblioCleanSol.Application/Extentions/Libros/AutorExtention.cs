using BiblioCleanSol.Application.Dtos.Libros.Autor;
using BiblioCleanSol.Domain.Entities.Libros;

namespace BiblioCleanSol.Application.Extentions.Libros
{
    public static class AutorExtention
    {
        public static Autor ToAutorEntityFromAutorDtoAgregar(AutorDto autorDto)
        {
            return new Autor
            {
                Nombre = autorDto.Nombre,
                Apellido = autorDto.Apellido,
                Nacionalidad = autorDto.Nacionalidad
            };
        }

        public static Autor ToAutorEntityFromAutorDtoEditar(AutorEditarDto autorDto)
        {
            return new Autor
            {
               AutorId = autorDto.AutorId,
               Nombre = autorDto.Nombre,
               Apellido = autorDto.Apellido,
               Nacionalidad = autorDto.Nacionalidad
            };
        }

        public static AutorEditarDto ToAutorDtoFromAutorEntity(Autor autor)
        {
            return new AutorEditarDto
            {
                AutorId = autor.AutorId,
                Nombre = autor.Nombre,
                Apellido = autor.Apellido,
                Nacionalidad = autor.Nacionalidad
            };
        }
    }
}
