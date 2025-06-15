using BiblioCleanSol.Application.Dtos.Libros.Categoria;
using BiblioCleanSol.Application.Extentions.Libros;
using BiblioCleanSol.Application.Interfaces.Repositories.Libros;
using BiblioCleanSol.Application.Interfaces.Services.Libros;
using BiblioCleanSol.Domain.Base;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace BiblioCleanSol.Application.Services.Libros
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepo _repo;
        private readonly ILogger _logger;

        public CategoriaService(ICategoriaRepo repo, ILogger<CategoriaService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<OperationResult> EditarAutorAsync(CategoriaEditarDto categoriaEditarDto)
        {
            OperationResult result = new OperationResult();
            string PATTERN = @"^[a-zA-Z]+";
            try
            {
                _logger.LogInformation($"Editando categoria {categoriaEditarDto.Nombre}");

                if(categoriaEditarDto is null)
                {
                    result = OperationResult.Failure("La categoria no puede ser nulo");
                    return result;
                }
                if(await _repo.ExisteAsyn(c => c.Nombre == categoriaEditarDto.Nombre))
                {
                    result = OperationResult.Failure($"Ya existe una categoria {categoriaEditarDto.Nombre}");
                    return result;
                }
                if(categoriaEditarDto.CategoriaId <= 0)
                {
                    result = OperationResult.Failure($"Id {categoriaEditarDto.CategoriaId} incorrecto");
                    return result;
                }
                if(!Regex.IsMatch(categoriaEditarDto.Nombre, PATTERN))
                {
                    result = OperationResult.Failure("Formato de nombre invalido");
                    return result;
                }
                if (!Regex.IsMatch(categoriaEditarDto.Descripcion, PATTERN))
                {
                    result = OperationResult.Failure("Formato de descripcion invalido");
                    return result;
                }

                result = await _repo.EditarAsync(CategoriaExtention.ToCategoriaEntityFromCategoriaDtoEditar( categoriaEditarDto));

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error intentando editar una categoria");
                result = OperationResult.Failure("Ha ocurrido un error intentando editar una categoria");
            }

            return result;
        }

        public async Task<OperationResult> GuardarAutorAsync(CategoriaDto categoriaDto)
        {
            OperationResult result = new OperationResult();
            string PATTERN = @"^[a-zA-Z]+";
            try
            {
                _logger.LogInformation($"Guardando categoria {categoriaDto.Nombre}");

                if (categoriaDto is null)
                {
                    result = OperationResult.Failure("La categoria no puede ser nulo");
                    return result;
                }
                if (await _repo.ExisteAsyn(c => c.Nombre == categoriaDto.Nombre))
                {
                    result = OperationResult.Failure($"Ya existe una categoria {categoriaDto.Nombre}");
                    return result;
                }
                if (!Regex.IsMatch(categoriaDto.Nombre, PATTERN))
                {
                    result = OperationResult.Failure("Formato de nombre invalido");
                    return result;
                }
                if (!Regex.IsMatch(categoriaDto.Descripcion, PATTERN))
                {
                    result = OperationResult.Failure("Formato de descripcion invalido");
                    return result;
                }

                await _repo.EditarAsync(CategoriaExtention.ToCategoriaEntityFromCategoriaDtoAgregar(categoriaDto));

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error intentando guardar una categoria");
                result = OperationResult.Failure("Ha ocurrido un error intentando guardar una categoria");
            }

            return result;
        }

        public async Task<OperationResult> ObtenerCategoriasAsync()
        {
            OperationResult result = new OperationResult();
            try
            {
                var categoriaResult = await _repo.ObtenerTodosAsync(c => c.Habilitado == true);
                if (categoriaResult.IsSuccess)
                {
                    result = OperationResult.Success($"Categorias obtenidas: {result.Data}");
                }
                else
                {
                    result = OperationResult.Failure("Fallo al intentar obtener a las categorias");
                }
                _logger.LogInformation("Obtencion de categorias exitosa!");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error obteniendo las categorias");
                result = OperationResult.Failure("Ha ocurrido un error obteniendo las categorias");
            }
            return result;
        }
    }
}
