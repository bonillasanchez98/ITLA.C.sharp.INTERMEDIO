using BiblioCleanSol.Application.Interfaces.Repositories.Libros;
using BiblioCleanSol.Domain.Base;
using BiblioCleanSol.Domain.Entities.Libros;
using BiblioCleanSol.Persistence.Base;
using BiblioCleanSol.Persistence.Context;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace BiblioCleanSol.Persistence.Repositories.Libros
{
    //TODO: Hacer las validaciones de campo
    public sealed class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepo
    {
        private readonly ILogger<Categoria> _logger;
        private readonly string PATTERN = "@^[a-zA-Z]+";

        public CategoriaRepository(Biblio_dbContext dbContext, ILogger<Categoria> logger) : base(dbContext)
        {
            _logger = logger;
        }

        //Los metodos del padre se deben llamar a traves del override.
        //Cada metodo debe implementar la logica de negocio que se necesite antes de: guardar, editar y obtener un Categoria.

        public override Task<OperationResult> GuardarAsync(Categoria categoria)
        {
            OperationResult result = new OperationResult();
            if(categoria is null)
            {
                result = OperationResult.Failure("La categoria no puede ser null");
            }
            if (String.IsNullOrWhiteSpace(categoria!.Nombre))
            {
                result = OperationResult.Failure("El nombre de la categoria no puede ser vacio");
            }
            if(categoria.Nombre.Length > 50)
            {
                result = OperationResult.Failure("El nombre de la categoria no puede exceder los 50 caracteres");
            }
            if(!Regex.IsMatch(categoria.Nombre, PATTERN))
            {
                result = OperationResult.Failure("El formato no es valido");
            }

            if (String.IsNullOrEmpty(categoria.Descripcion))
            {
                result = OperationResult.Failure("La descripcion no puede ser vacio");
            }
            if(categoria.Descripcion.Length > 150)
            {
                result = OperationResult.Failure("La descripcion de la categoria no puede exceder los 150 caracteres");
            }
            if(!Regex.IsMatch(categoria.Descripcion, PATTERN))
            {
                result = OperationResult.Failure("El formato no es valido");
            }
            
            categoria.Habilitado = true;

            _logger.LogInformation($"UsuarioCreacion: {categoria.UsuarioCreacionId} |" +
                $"FechaCreacion: {categoria.FechaCreacion = DateTime.Now}");

            return base.GuardarAsync(categoria);
        }

        public override Task<OperationResult> EditarAsync(Categoria categoria)
        {
            OperationResult result = new OperationResult();

            if (categoria is null)
            {
                result = OperationResult.Failure("La categoria no puede ser null");
            }
            if (String.IsNullOrWhiteSpace(categoria!.Nombre))
            {
                result = OperationResult.Failure("El nombre de la categoria no puede ser vacio");
            }
            if (categoria.Nombre.Length > 50)
            {
                result = OperationResult.Failure("El nombre de la categoria no puede exceder los 50 caracteres");
            }
            if (!Regex.IsMatch(categoria.Nombre, PATTERN))
            {
                result = OperationResult.Failure("El formato no es valido");
            }

            if (String.IsNullOrEmpty(categoria.Descripcion))
            {
                result = OperationResult.Failure("La descripcion no puede ser vacio");
            }
            if (categoria.Descripcion.Length > 150)
            {
                result = OperationResult.Failure("La descripcion de la categoria no puede exceder los 150 caracteres");
            }
            if (!Regex.IsMatch(categoria.Descripcion, PATTERN))
            {
                result = OperationResult.Failure("El formato no es valido");
            }

            _logger.LogInformation($"UsuarioMod: {categoria.UsuarioModId} |" +
                $"FechaMod: {categoria.FechaMod = DateTime.Now}");

            return base.EditarAsync(categoria);
        }

        public override Task<OperationResult> BorrarAsync(Categoria categoria)
        {
            categoria.Habilitado = false;

            _logger.LogInformation($"UsuarioElimino: {categoria.UsuarioEliminoId} |" +
                $"FechaElimino: {categoria.FechaElimino = DateTime.Now}");

            return base.BorrarAsync(categoria);
        }

        //Metodo adicional que esta entidad pueda necesitar.
    }
}
