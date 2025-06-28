using BiblioCleanSol.Application.Dtos.Usuarios;
using BiblioCleanSol.Domain.Base;

namespace BiblioCleanSol.Application.Extentions.Usuarios
{
    public static class UsuarioExtention
    {
        public static Usuario ToUsuarioEntityFromUsuarioDtoAgregar(UsuarioDto usuarioDto)
        {
            return new Usuario
            {
                Nombre = usuarioDto.Nombre,
                Apellido = usuarioDto.Apellido,
                Correo = usuarioDto.Correo,
                Clave = usuarioDto.Clave,
                Rol_id = usuarioDto.Rol_id
            };
        }

        public static Usuario ToUsuarioEntityFromUsuarioDtoEditar(UsuarioEditarDto usuarioEditarDto)
        {
            return new Usuario
            {
                UsuarioId = usuarioEditarDto.UsuarioId,
                Nombre = usuarioEditarDto.Nombre,
                Apellido = usuarioEditarDto.Apellido,
                Correo = usuarioEditarDto.Correo,
                Clave = usuarioEditarDto.Clave,
                Rol_id = usuarioEditarDto.Rol_id,
                elimino = usuarioEditarDto.Habilitado
            };
        }

        public static UsuarioDto ToUsuarioDtoFromUsuarioEntity(Usuario usuario)
        {
            return new UsuarioDto
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo,
                Clave = usuario.Clave,
                Rol_id = usuario.Rol_id
            };
        }
    }
}
