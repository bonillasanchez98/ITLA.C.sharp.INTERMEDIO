using BiblioCleanSol.Application.Dtos.Libros.Estados;
using BiblioCleanSol.Application.Extentions.Libros;
using BiblioCleanSol.Application.Interfaces.Repositories.Libros;
using BiblioCleanSol.Application.Interfaces.Services.Libros;
using BiblioCleanSol.Domain.Base;
using BiblioCleanSol.Domain.Base.utils;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace BiblioCleanSol.Application.Services.Libros
{
    public class EstadosService : IEstadosService
    {
        private readonly IEstadosRepo _repo;
        private readonly ILogger _logger;

        public EstadosService(IEstadosRepo repo, ILogger<EstadosService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<OperationResult> EditarEstadosAsync(EstadosEditarDto estadosEditarDto)
        {
            OperationResult result = new OperationResult();
            try
            {
                //Por cada validacion que se haga se debe de crear un caso de prueba (Prueba Unitaria)
                _logger.LogInformation($"Agregando un nuevo Estado: {estadosEditarDto.Estado}");

                if (estadosEditarDto is null) //Caso de prueba: EditarEstadoyncIsNull
                {
                    result = OperationResult.Failure("Estado es nulo");
                    return result;
                }
                var exsite = await _repo.ExisteAsyn(e => e.Estado == estadosEditarDto.Estado);
                if (exsite != null) //Caso de prueba: EditarEstadoAsyncExisteEstado
                {
                    result = OperationResult.Failure($"Ya existe un estado de nombre: {estadosEditarDto.Estado}");
                    return result;
                }
                if (Regex.IsMatch(estadosEditarDto.Estado, ExpresionesReg.STRING_PATTERN))
                {
                    result = OperationResult.Failure("Formato de esta invalido!"); //Caso de prueba: EditarEstadoFormatoInvalido
                    return result;
                }
                if(estadosEditarDto.EstadoId <= 0)
                {
                    result = OperationResult.Failure($"Id {estadosEditarDto.EstadoId} es invalido");
                    return result;
                }

                result = await _repo.EditarAsync(EstadosExtention.ToEstadoEntityFromEstadoDtoEditar(estadosEditarDto));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error intentando editar un estado");
                result = OperationResult.Failure("Ha ocurrido un error intentando editar un estado");
            }
            return result;
        }

        public async Task<OperationResult> GuardarEstadosAsync(EstadosDto estadosDto)
        {
            OperationResult result = new OperationResult();
            try
            {
                //Por cada validacion que se haga se debe de crear un caso de prueba (Prueba Unitaria)
                _logger.LogInformation($"Agregando un nuevo Estado: {estadosDto.Estado}");

                if (estadosDto is null) //Caso de prueba: GuardarEstadoAsyncIsNull
                {
                    result = OperationResult.Failure("Estado es nulo");
                    return result;
                }
                var exsite = await _repo.ExisteAsyn(e => e.Estado == estadosDto.Estado);
                if (exsite != null) //Caso de prueba: EditarEstadoAsyncExisteEstado
                {
                    result = OperationResult.Failure($"Ya existe un estado de nombre: {estadosDto.Estado}");
                    return result;
                }
                if (Regex.IsMatch(estadosDto.Estado, ExpresionesReg.STRING_PATTERN)) //Caso de prueba: GuardarEstadoAsyncFormatoInvalido
                {
                    result = OperationResult.Failure("Formato de esta invalido!");
                    return result;
                }

                result = await _repo.GuardarAsync(EstadosExtention.ToEstadoEntityFromEstadoDtoAgregar(estadosDto));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error intentando guardar un estado");
                result = OperationResult.Failure("Ha ocurrido un error intentando guardar un estado");
            }
            return result;
        }

        public async Task<OperationResult> ObtenerEstadosAsync()
        {
            OperationResult result = new OperationResult();

            try
            {
                var estadosResult = await _repo.ObtenerTodosAsync(e => e.elimino == false);
                if (estadosResult.IsSuccess)
                {
                    result = OperationResult.Success($"Estados obtenidos", estadosResult.Data);
                    _logger.LogInformation("Obtencion de estados exitosa!");
                }
                else
                {
                    result = OperationResult.Failure("Fallo al intentar obtener a los estados");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error obteniendo los estados");
                result = OperationResult.Failure("Ha ocurrido un error obteniendo los estados");
            }
            return result;

        }
    }
}
