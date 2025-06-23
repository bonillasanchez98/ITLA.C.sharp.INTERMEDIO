using BiblioCleanSol.Application.Interfaces.Repositories.Usuarios;
using BiblioCleanSol.Domain.Base;
using BiblioCleanSol.Persistence.Context;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace BiblioCleanSol.Persistence.Base
{
    public sealed class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepo
    {
        private readonly ILogger<Usuario> _logger;
        private readonly string STRING_PATTERN = @"^[a-zA-Z]+";
        private readonly string EMAIL_PATTERN = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        public UsuarioRepository(Biblio_dbContext dbContext, ILogger<Usuario> logger) : base(dbContext)
        {
            _logger = logger;
        }

        public override Task<OperationResult> GuardarAsync(Usuario usuario)
        {
            OperationResult result = new OperationResult();
            
                if(usuario is null)
                {
                    result = OperationResult.Failure("Usuario no puede ser nulo");
                }
                if (String.IsNullOrWhiteSpace(usuario!.Nombre))
                {
                    result = OperationResult.Failure("El nombre de usuario no puede ser nulo");
                }
                if(usuario.Nombre.Length > 50)
                {
                    result = OperationResult.Failure("El nombre de usuario no puede exceder los 50 caracteres");
                }
                if(!Regex.IsMatch(usuario.Nombre, STRING_PATTERN))
                {
                    result = OperationResult.Failure("El nombre debe ser en un formato valido");
                }

                if (String.IsNullOrWhiteSpace(usuario!.Apellido))
                {
                    result = OperationResult.Failure("El apellido de usuario no puede ser nulo");
                }
                if (usuario.Apellido.Length > 50)
                {
                    result = OperationResult.Failure("El apellido de usuario no puede exceder los 50 caracteres");
                }
                if (!Regex.IsMatch(usuario.Apellido, STRING_PATTERN))
                {
                    result = OperationResult.Failure("El apellido debe ser en un formato valido");
                }

                if(String.IsNullOrWhiteSpace(usuario.Correo) || String.IsNullOrEmpty(usuario.Correo))
                {
                    result = OperationResult.Failure("El correo no puede nulo o vacio");
                }
                if(usuario.Correo.Length > 50)
                {
                    result = OperationResult.Failure("El correo no puede exceder los 50 caracteres");
                }
                if(!Regex.IsMatch(usuario.Correo, EMAIL_PATTERN))
                {
                    result = OperationResult.Failure("El correo debe ser en un formato valido");
                }

                if(String.IsNullOrWhiteSpace(usuario.Clave) || String.IsNullOrEmpty(usuario.Clave))
                {
                    result = OperationResult.Failure("La clave no puede ser nulo o vacio");
                }
                if(usuario.Clave.Length > 50)
                {
                    result = OperationResult.Failure("La clave no puede exceder los 50 caracteres");
                }

                if(usuario.Rol_id.Equals(null))
                {
                    result = OperationResult.Failure("El rol no puede ser nulo");
                }
                if(usuario.Rol_id <= 0)
                {
                    result = OperationResult.Failure("Id invalido");
                }

            _logger.LogInformation($"UsuarioCreacion: {usuario.usuario_creacion_id} |" +
                $"FechaCreacion: {usuario.fecha_creacion = DateTime.Now}");

            usuario.elimino = false;

            return base.GuardarAsync(usuario);
        }

        public override Task<OperationResult> EditarAsync(Usuario usuario)
        {
            OperationResult result = new OperationResult();

            if (usuario is null)
            {
                result = OperationResult.Failure("Usuario no puede ser nulo");
            }
            if (String.IsNullOrWhiteSpace(usuario!.Nombre))
            {
                result = OperationResult.Failure("El nombre de usuario no puede ser nulo");
            }
            if (usuario.Nombre.Length > 50)
            {
                result = OperationResult.Failure("El nombre de usuario no puede exceder los 50 caracteres");
            }
            if (!Regex.IsMatch(usuario.Nombre, STRING_PATTERN))
            {
                result = OperationResult.Failure("El nombre debe ser en un formato valido");
            }

            if (String.IsNullOrWhiteSpace(usuario!.Apellido))
            {
                result = OperationResult.Failure("El apellido de usuario no puede ser nulo");
            }
            if (usuario.Apellido.Length > 50)
            {
                result = OperationResult.Failure("El apellido de usuario no puede exceder los 50 caracteres");
            }
            if (!Regex.IsMatch(usuario.Apellido, STRING_PATTERN))
            {
                result = OperationResult.Failure("El apellido debe ser en un formato valido");
            }

            if (String.IsNullOrWhiteSpace(usuario.Correo) || String.IsNullOrEmpty(usuario.Correo))
            {
                result = OperationResult.Failure("El correo no puede nulo o vacio");
            }
            if (usuario.Correo.Length > 50)
            {
                result = OperationResult.Failure("El correo no puede exceder los 50 caracteres");
            }
            if (!Regex.IsMatch(usuario.Correo, EMAIL_PATTERN))
            {
                result = OperationResult.Failure("El correo debe ser en un formato valido");
            }

            if (String.IsNullOrWhiteSpace(usuario.Clave) || String.IsNullOrEmpty(usuario.Clave))
            {
                result = OperationResult.Failure("La clave no puede ser nulo o vacio");
            }
            if (usuario.Clave.Length > 50)
            {
                result = OperationResult.Failure("La clave no puede exceder los 50 caracteres");
            }

            if (usuario.Rol_id.Equals(null))
            {
                result = OperationResult.Failure("El rol no puede ser nulo");
            }
            if (usuario.Rol_id <= 0)
            {
                result = OperationResult.Failure("Id invalido");
            }

            _logger.LogInformation($"UsuarioMod: {usuario.usuario_mod} |" +
                $"FechaMod: {usuario.fecha_mod = DateTime.Now}");

            return base.EditarAsync(usuario);
        }

        public override Task<OperationResult> BorrarAsync(Usuario usuario)
        {
            OperationResult result = new OperationResult();

            usuario.elimino = true;

            result = OperationResult.Success($"Usuario borrado con exito!, ", usuario);

            _logger.LogInformation($"UsuarioElim: {usuario.usuario_elim_id} |" +
                $"FechaElim: {usuario.fecha_elim = DateTime.Now}");

            return base.BorrarAsync(usuario);
        }

        
        public Task<OperationResult> ObtenerUsuarioPorRolId(int RolId)
        {
            OperationResult result = new OperationResult();

            var rolExiste = base.ExisteAsyn(r => r.Rol_id == RolId);
            if(!rolExiste.IsCompleted)
            {
                result = OperationResult.Failure("El rol indicado no existe");
            }
            return result.Data;

        }
    }
}
