using BiblioCleanSol.Application.Interfaces.Repositories.Libros;
using BiblioCleanSol.Domain.Base;
using BiblioCleanSol.Domain.Base.utils;
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
            if(!Regex.IsMatch(categoria.Nombre, ExpresionesReg.STRING_PATTERN))
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
            if(!Regex.IsMatch(categoria.Descripcion, ExpresionesReg.STRING_PATTERN))
            {
                result = OperationResult.Failure("El formato no es valido");
            }
            
            categoria.elimino = false;
            categoria.usuario_creacion_id = 2;
            categoria.fecha_creacion = DateTime.Now;
            
            categoria.fecha_mod = null;
            categoria.usuario_mod = null;

            categoria.usuario_elim_id = null;
            categoria.fecha_elim = null;

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
            if (Regex.IsMatch(categoria.Nombre, ExpresionesReg.STRING_PATTERN))
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
            if (Regex.IsMatch(categoria.Descripcion, ExpresionesReg.STRING_PATTERN))
            {
                result = OperationResult.Failure("El formato no es valido");
            }

            categoria.fecha_mod = DateTime.Now;
            categoria.usuario_mod = 2;

            return base.EditarAsync(categoria);
        }

        public override Task<OperationResult> BorrarAsync(Categoria categoria)
        {
            categoria.elimino = true;

            categoria.usuario_elim_id = 2;
            categoria.fecha_elim = DateTime.Now;

            return base.BorrarAsync(categoria);
        }

        //Metodo adicional que esta entidad pueda necesitar.
    }
}
