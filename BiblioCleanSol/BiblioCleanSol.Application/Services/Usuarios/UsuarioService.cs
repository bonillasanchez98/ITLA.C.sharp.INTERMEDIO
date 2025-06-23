using BiblioCleanSol.Application.Dtos.Usuarios;
using BiblioCleanSol.Application.Extentions.Usuarios;
using BiblioCleanSol.Application.Interfaces.Repositories.Usuarios;
using BiblioCleanSol.Application.Interfaces.Services.Usuarios;
using BiblioCleanSol.Domain.Base;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace BiblioCleanSol.Application.Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepo _repo;
        private readonly ILogger<Usuario> _logger;
        private readonly string STRING_PATTERN = @"^[a-zA-Z]+";
        private readonly string EMAIL_PATTERN = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        public UsuarioService(IUsuarioRepo repo, ILogger<Usuario> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<OperationResult> GuardarUsuarioAsync(UsuarioDto usuarioDto)
        {
            OperationResult result = new OperationResult();
            try
            {
                _logger.LogInformation($"Guardando usuario {usuarioDto}");

                if (usuarioDto is null)
                {
                    result = OperationResult.Failure("El usuario no puede ser nulo");
                    return result;
                }
                if (!Regex.IsMatch(usuarioDto.Nombre, STRING_PATTERN))
                {
                    result = OperationResult.Failure("Formato de nombre invalido");
                    return result;
                }
                if (!Regex.IsMatch(usuarioDto.Apellido, STRING_PATTERN))
                {
                    result = OperationResult.Failure("Formato de apellido invalido");
                    return result;
                }
                if(!Regex.IsMatch(usuarioDto.Correo, EMAIL_PATTERN))
                {
                    result = OperationResult.Failure("Formato de correo invalido");
                    return result;
                }
                if (await _repo.ExisteAsyn(c => c.Correo == usuarioDto.Correo))
                {
                    result = OperationResult.Failure($"Ya existe un correo {usuarioDto.Correo}");
                    return result;
                }
                if (String.IsNullOrEmpty(usuarioDto.Correo))
                {
                    result = OperationResult.Failure("El correo no debe ser nulo");
                    return result;
                }
                if (String.IsNullOrEmpty(usuarioDto.Clave))
                {
                    result = OperationResult.Failure("La clave no debe ser nulo");
                    return result;
                }
                if (usuarioDto.Rol_id <= 0)
                {
                    result = OperationResult.Failure("Rol invalido");
                    return result;
                }

                _logger.LogInformation($"Usuario agregado con existo");

                result = await _repo.GuardarAsync(UsuarioExtention.ToUsuarioEntityFromUsuarioDtoAgregar(usuarioDto));
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error intentando guardar un usuario");
                result = OperationResult.Failure("Ha ocurrido un error intentando guardar un usuario");
            }
            return result;
        }

        public async Task<OperationResult> EditarUsuarioAsync(UsuarioEditarDto usuarioEditarDto)
        {
            OperationResult result = new OperationResult();
            try
            {
                _logger.LogInformation($"Guardando usuario {usuarioEditarDto}");

                if (usuarioEditarDto is null)
                {
                    result = OperationResult.Failure("El usuario no puede ser nulo");
                    return result;
                }
                if (!Regex.IsMatch(usuarioEditarDto.Nombre, STRING_PATTERN))
                {
                    result = OperationResult.Failure("Formato de nombre invalido");
                    return result;
                }
                if (!Regex.IsMatch(usuarioEditarDto.Apellido, STRING_PATTERN))
                {
                    result = OperationResult.Failure("Formato de apellido invalido");
                    return result;
                }
                if (!Regex.IsMatch(usuarioEditarDto.Correo, EMAIL_PATTERN))
                {
                    result = OperationResult.Failure("Formato de correo invalido");
                    return result;
                }
                if (await _repo.ExisteAsyn(c => c.Correo == usuarioEditarDto.Correo))
                {
                    result = OperationResult.Failure($"Ya existe un correo {usuarioEditarDto.Correo}");
                    return result;
                }
                if (String.IsNullOrEmpty(usuarioEditarDto.Correo))
                {
                    result = OperationResult.Failure("El correo no debe ser nulo");
                    return result;
                }
                if (String.IsNullOrEmpty(usuarioEditarDto.Clave))
                {
                    result = OperationResult.Failure("La clave no debe ser nulo");
                    return result;
                }
                if (usuarioEditarDto.Rol_id <= 0)
                {
                    result = OperationResult.Failure("Rol invalido");
                    return result;
                }
                if(usuarioEditarDto.UsuarioId <= 0)
                {
                    result = OperationResult.Failure("Id de usuario invalido");
                    return result;
                }

                _logger.LogInformation($"Usuario editado con existo");

                result = await _repo.EditarAsync(UsuarioExtention.ToUsuarioEntityFromUsuarioDtoEditar(usuarioEditarDto));
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error intentando editar el usuario");
                result = OperationResult.Failure("Ha ocurrido un error intentando editar un usuario");
            }
            return result;
        }

        public async Task<OperationResult> ObtenerUsuariosAsync()
        {
            OperationResult result = new OperationResult();
            try
            {
                var usuariosResult = await _repo.ObtenerTodosAsync(u => u.elimino == false);
                if (usuariosResult.IsSuccess)
                {
                    _logger.LogInformation("Obtencion de usuarios exitosa!");
                    result = OperationResult.Success($"Usuarios obtenidos", usuariosResult.Data);
                }
                else
                {
                    result = OperationResult.Failure("Fallo al intentar obtener a los usuarios");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error obteniendo los usuarios");
                result = OperationResult.Failure("Ha ocurrido un error obteniendo los usuarios");
            }
            return result;
        }
    }
}
