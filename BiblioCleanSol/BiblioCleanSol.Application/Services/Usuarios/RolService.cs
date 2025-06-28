using BiblioCleanSol.Application.Dtos.Usuarios.Rol;
using BiblioCleanSol.Application.Extentions.Usuarios;
using BiblioCleanSol.Application.Interfaces.Repositories.Usuarios;
using BiblioCleanSol.Application.Interfaces.Services.Usuarios;
using BiblioCleanSol.Domain.Base;
using BiblioCleanSol.Domain.Base.utils;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace BiblioCleanSol.Application.Services.Usuarios
{
    public class RolService : IRolService
    {
        private readonly IRolRepo _repo;
        private readonly ILogger<RolService> _logger;

        public RolService(IRolRepo repo, ILogger<RolService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<OperationResult> EditarRolAsync(RolEditarDto rolEditarDto)
        {
            OperationResult result = new OperationResult();
            try
            {
                _logger.LogInformation($"Editando rol {rolEditarDto.Nombre}");

                if(rolEditarDto is null)
                {
                    result = OperationResult.Failure("El rol no puede ser nulo");
                    return result;
                }
                if(rolEditarDto.RolId <= 0)
                {
                    result = OperationResult.Failure("Id de rol invalido");
                    return result;
                }
                if(Regex.IsMatch(rolEditarDto.Nombre, ExpresionesReg.STRING_PATTERN))
                {
                    result = OperationResult.Failure("Formato de nombre de rol invalido");
                    return result;
                }

                return result = await _repo.EditarAsync(RolExtention.ToRolEntityFromRolDtoEditar(rolEditarDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error intentando editar un rol");
                result = OperationResult.Failure("Ha ocurrido un error intentando editar un rol");
            }

            return result;
        }

        public async Task<OperationResult> GuardarRolAsync(RolDto rolDto)
        {
            OperationResult result = new OperationResult();
            try
            {
                _logger.LogInformation($"Guardando rol {rolDto.Nombre}");

                if (rolDto is null)
                {
                    result = OperationResult.Failure("El rol no puede ser nulo");
                    return result;
                }
                if (Regex.IsMatch(rolDto.Nombre, ExpresionesReg.STRING_PATTERN))
                {
                    result = OperationResult.Failure("Formato de nombre de rol invalido");
                    return result;
                }

                return result = await _repo.GuardarAsync(RolExtention.ToRolEntityFromRolDtoAgregar(rolDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error intentando guardar un rol");
                result = OperationResult.Failure("Ha ocurrido un error intentando guardar un rol");
            }

            return result;
        }
        
        public async Task<OperationResult> ObtenerRolesAsync()
        {
            OperationResult result = new OperationResult();

            try
            {
                var rolResult = await _repo.ObtenerTodosAsync(r => r.elimino == false);
                if (rolResult.IsSuccess)
                {
                    _logger.LogInformation("Obtencion de roles exitosa!");
                    result = OperationResult.Success($"Roles obtenidos", rolResult.Data);
                }
                else
                {
                    result = OperationResult.Failure("Fallo al intentar obtener a los roles");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error intentando obtener un rol");
                result = OperationResult.Failure("Ha ocurrido un error intentando obtener un rol");
            }
            return result;
        }
    }
}
