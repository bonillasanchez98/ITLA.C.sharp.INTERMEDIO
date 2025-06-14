using BiblioCleanSol.Application.Dtos.Libros.Autor;
using BiblioCleanSol.Application.Extentions.Libros;
using BiblioCleanSol.Application.Interfaces.Repositories.Libros;
using BiblioCleanSol.Application.Interfaces.Services.Libros;
using BiblioCleanSol.Domain.Base;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace BiblioCleanSol.Application.Services.Libros
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepo _repo;
        private readonly ILogger _logger;

        public AutorService(IAutorRepo repo, ILogger<AutorService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<OperationResult> EditarAutorAsync(AutorEditarDto autor)
        {
            OperationResult result = new OperationResult();
            string PATTERN = @"^[a-zA-Z]+";
            try
            {
                //Por cada validacion que se haga se debe de crear un caso de prueba (Prueba Unitaria)
                _logger.LogInformation($"Editando Autor: {autor.Nombre}");

                if (autor is null) //Caso de prueba: EditarAutorAsyncIsNull
                {
                    result = OperationResult.Failure("Autor no puede ser nulo");
                    return result;
                }
                if (await _repo.ExisteAsyn(a => a.Nombre == autor.Nombre)) //Caso de prueba: EditarAutorAsyncNombreExiste
                {
                    result = OperationResult.Failure($"Ya existe un autor de nombre: {autor.Nombre}");
                    return result;
                }
                if(autor.AutorId <= 0) //Caso de prueba: EditarAutorAsyncIdInvalido
                {
                    result = OperationResult.Failure($"Id {autor.AutorId} incorrecto");
                    return result;
                }
                if(Regex.IsMatch(autor.Nombre, PATTERN))
                {
                    result = OperationResult.Failure("Formato de nombre invalido"); //Caso de prueba: EditarAutorAsyncFormatoNombreInvalido
                    return result;
                }
                if (Regex.IsMatch(autor.Apellido, PATTERN))
                {
                    result = OperationResult.Failure("Formato de apellido invalido"); //Caso de prueba: EditarAutorAsyncFormatoApellidoInvalido
                    return result;
                }
                if (Regex.IsMatch(autor.Nacionalidad, PATTERN))
                {
                    result = OperationResult.Failure("Formato de nacionalidad invalido"); //Caso de prueba: EditarAutorAsyncFormatoNacionalidadInvalido
                    return result;
                }

                await _repo.GuardarAsync(AutorExtention.ToAutorEntityFromAutorDtoEditar(autor));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error intentando guardar un autor");
            }
            return result;
        }

        public async Task<OperationResult> GuardarAutorAsync(AutorDto autor)
        {
            OperationResult result = new OperationResult();
            try
            {
                //Por cada validacion que se haga se debe de crear un caso de prueba (Prueba Unitaria)
                _logger.LogInformation($"Agregando un nuevo Autor: {autor.Nombre}");

                if (autor is null) //Caso de prueba: GuardarAutorAsyncIsNull
                {
                    result = OperationResult.Failure("Autor es nulo");
                    return result;
                }
                if (await _repo.ExisteAsyn(a => a.Nombre == autor.Nombre)) //Caso de prueba: GuardarAutorAsyncExisteNombre
                {
                    result = OperationResult.Failure($"Ya existe un autor de nombre: {autor.Nombre}");
                    return result;
                }

                await _repo.GuardarAsync(AutorExtention.ToAutorEntityFromAutorDtoAgregar(autor));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error intentando guardar un autor");
            }
            return result;
        }

        public async Task<OperationResult> ObtenerAutoresAsync()
        {
            OperationResult result = new OperationResult();
            try
            {
                var autoresResult = await _repo.ObtenerTodosAsync(a => a.Habilitado == true);
                if (autoresResult.IsSuccess)
                {
                    result = OperationResult.Success($"Autores obtenidos: {result.Data}");
                }
                else
                {
                    result = OperationResult.Failure("Fallo al intentar obtener a los autores");
                }
                _logger.LogInformation("Obtencion de autores exitosa!");
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error obteniendo los autores");
                result = OperationResult.Failure("Ha ocurrido un error obteniendo los autores");
            }
            return result ;
        }
    }
}
