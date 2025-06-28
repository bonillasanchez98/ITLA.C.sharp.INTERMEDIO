using BiblioCleanSol.Application.Dtos.Usuarios.Rol;
using BiblioCleanSol.Domain.Entities.Seguridad;

namespace BiblioCleanSol.Application.Extentions.Usuarios
{
    public static class RolExtention
    {
        public static Rol ToRolEntityFromRolDtoAgregar(RolDto rol)
        {
            return new Rol
            {
                Nombre = rol.Nombre,
                elimino = rol.Habilitado
            };
        }

        public static Rol ToRolEntityFromRolDtoEditar(RolEditarDto rolEditarDto)
        {
            return new Rol
            {
                RolId = rolEditarDto.RolId,
                Nombre = rolEditarDto.Nombre,
                elimino = rolEditarDto.Habilitado
            };
        }

        public static RolDto ToRolDtoFromRolEntity(Rol rol)
        {
            return new RolDto
            {
                Nombre = rol.Nombre,
                Habilitado = rol.elimino
            };
        }
    }
}
