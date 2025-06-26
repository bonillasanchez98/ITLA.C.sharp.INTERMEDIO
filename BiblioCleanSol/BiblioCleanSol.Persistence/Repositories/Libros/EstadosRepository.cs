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
    public sealed class EstadosRepository : BaseRepository<Estados>, IEstadosRepo
    {
        private readonly ILogger<Estados> _logger;

        public EstadosRepository(Biblio_dbContext dbContext, ILogger<Estados> logger) : base(dbContext)
        {
            _logger = logger;
        }

        //Los metodos del padre se deben llamar a traves del override.
        //Cada metodo debe implementar la logica de negocio que se necesite antes de: guardar, editar y obtener un Estado.
        
        public override Task<OperationResult> GuardarAsync(Estados estado)
        {
            OperationResult result = new OperationResult();

            if(estado is null)
            {
                result = OperationResult.Failure("El estado no puede ser nulo");
            }
            if (String.IsNullOrEmpty(estado!.Estado))
            {
                result = OperationResult.Failure("El estado no puede ser nulo o vacio");
            }
            if(estado.Estado.Length > 50)
            {
                result = OperationResult.Failure("El estado no puede exceder los 50 caracteres");
            }
            if (String.IsNullOrEmpty(estado.Descripcion))
            {
                result = OperationResult.Failure("La descripcion del estado no puede ser nula o vacia");
            }
            if (estado.Descripcion.Length > 200)
            {
                result = OperationResult.Failure("La descripcion del estado no puede exceder los 200 caracteres");
            }
            if(Regex.IsMatch(estado.Estado, ExpresionesReg.STRING_PATTERN))
            {
                result = OperationResult.Failure("El formato del estado es invalido");
            }
            if (Regex.IsMatch(estado.Descripcion, ExpresionesReg.STRING_PATTERN))
            {
                result = OperationResult.Failure("El formato de la descripcion es invalido");
            }

            estado.elimino = false;

            estado.usuario_creacion_id = 2;
            estado.fecha_creacion = DateTime.Now;

            estado.usuario_mod  = null;
            estado.fecha_mod = null;

            estado.usuario_elim_id = null;
            estado.fecha_mod = null;

            return base.GuardarAsync(estado);
        }

        public override Task<OperationResult> EditarAsync(Estados estado)
        {
            OperationResult result = new OperationResult();

            if (estado is null)
            {
                result = OperationResult.Failure("El estado no puede ser nulo");
            }
            if (String.IsNullOrEmpty(estado!.Estado))
            {
                result = OperationResult.Failure("El estado no puede ser nulo o vacio");
            }
            if (estado.Estado.Length > 50)
            {
                result = OperationResult.Failure("El estado no puede exceder los 50 caracteres");
            }
            if (String.IsNullOrEmpty(estado.Descripcion))
            {
                result = OperationResult.Failure("La descripcion del estado no puede ser nula o vacia");
            }
            if (estado.Descripcion.Length > 200)
            {
                result = OperationResult.Failure("La descripcion del estado no puede exceder los 200 caracteres");
            }
            if (Regex.IsMatch(estado.Estado, ExpresionesReg.STRING_PATTERN))
            {
                result = OperationResult.Failure("El formato del estado es invalido");
            }
            if (Regex.IsMatch(estado.Descripcion, ExpresionesReg.STRING_PATTERN))
            {
                result = OperationResult.Failure("El formato de la descripcion es invalido");
            }
            if(estado.EstadoId <= 0)
            {
                result = OperationResult.Failure("Id incorrecto");
            }

            estado.usuario_mod = 2;
            estado.fecha_mod = DateTime.Now;

            return base.EditarAsync(estado);
        }

        public override Task<OperationResult> BorrarAsync(Estados estado)
        {
            OperationResult result = new OperationResult();

            estado.elimino = true;

            estado.usuario_elim_id = 2;
            estado.fecha_mod = DateTime.Now;

            result = OperationResult.Success($"Estado eliminado con exito!", estado);

            return base.BorrarAsync(estado);
        }

        //Metodo adicional que esta entidad pueda necesitar.
    }
}
