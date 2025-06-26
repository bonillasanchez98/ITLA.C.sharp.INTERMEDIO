using BiblioCleanSol.Application.Dtos.Libros.Estados;
using BiblioCleanSol.Domain.Entities.Libros;

namespace BiblioCleanSol.Application.Extentions.Libros
{
    public static class EstadosExtention
    {
        public static Estados ToEstadoEntityFromEstadoDtoAgregar(EstadosDto estadosDto)
        {
            return new Estados
            {
                Estado = estadosDto.Estado,
                Descripcion = estadosDto.Descripcion
            };
        }

        public static Estados ToEstadoEntityFromEstadoDtoEditar(EstadosEditarDto estadosEditarDto)
        {
            return new Estados
            {
                EstadoId = estadosEditarDto.EstadoId,
                Estado = estadosEditarDto.Estado,
                Descripcion = estadosEditarDto.Descripcion
            };
        }

        public static EstadosEditarDto ToEstadoDtoFromEstadoEntity(Estados estados)
        {
            return new  EstadosEditarDto
            {
                EstadoId = estados.EstadoId,
                Estado = estados.Estado,
                Descripcion= estados.Descripcion
            };
        }
    }
}
