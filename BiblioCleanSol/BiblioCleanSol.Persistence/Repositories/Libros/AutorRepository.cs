
using BiblioCleanSol.Application.Interfaces.Repositories.Libros;
using BiblioCleanSol.Domain.Base;
using BiblioCleanSol.Domain.Entities.Libros;
using BiblioCleanSol.Persistence.Base;
using BiblioCleanSol.Persistence.Context;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace BiblioCleanSol.Persistence.Repositories.Libros
{
    //TODO: Hacer las validaciones de campo
    public sealed class AutorRepository : BaseRepository<Autor>, IAutorRepo
    {
        private readonly ILogger<Autor> _logger;
        private readonly string PATTERN = @"^[a-zA-Z]+";

        private OperationResult result = new OperationResult();

        public AutorRepository(Biblio_dbContext dbContext, ILogger<Autor> logger) : base(dbContext)
        {
            _logger = logger;
        }

        //Los metodos del padre se deben llamar a traves del override.
        //Cada metodo debe implementar la logica de negocio que se necesite antes de: guardar, editar y obtener un autor.

        /// <summary>
        /// Metodo para guardar Autor en la BD.
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        public override Task<OperationResult> GuardarAsync(Autor autor)
        {   
            //OperationResult _result = new OperationResult();
            //Validaciones de campo
            //Nombre
            if (autor is null)
            {
                result = OperationResult.Failure("El autor no puede ser nulo");
            }
            if(String.IsNullOrWhiteSpace(autor!.Nombre))
            {
                result = OperationResult.Failure("El nombre del autor no puede ser nulo");
            }
            if(!Regex.IsMatch(autor.Nombre, PATTERN))
            {
                result = OperationResult.Failure("El nombre esta en formato invalido");
            }
            if(autor.Nombre.Length > 50)
            {
                result = OperationResult.Failure("El nombre del autor no puede superar los 50 caracteres");
            }

            //Apellido
            if (String.IsNullOrWhiteSpace(autor.Apellido))
            {
                result = OperationResult.Failure("El apellido del autor no puede ser nulo");
            }
            if(!Regex.IsMatch(autor.Apellido, PATTERN))
            {
                result = OperationResult.Failure("El apellido del autor debe ser de un formato valido");
            }

            //Nacionalidad
            if (String.IsNullOrWhiteSpace(autor.Nacionalidad))
            {
                result = OperationResult.Failure("La nacionalidad del autor no puede ser nula");
            }
            if(!Regex.IsMatch(autor.Nacionalidad, PATTERN))
            {
                result = OperationResult.Failure("La nacionalidad esta en formato invalido");
            }

            result = OperationResult.Success($"El autor fue registrado con exito!", autor);

            _logger.LogInformation($"UsuarioCreacion: {autor.UsuarioCreacionId} |" +
                $"FechaCreacion: {autor.FechaCreacion = DateTime.Now}");

            autor.Habilitado = true;
            return base.GuardarAsync(autor);
        }

        /// <summary>
        /// Metodo para editar Autor en la BD.
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        public override Task<OperationResult> EditarAsync(Autor autor)
        {
            //OperationResult _result = new OperationResult();

            //Validaciones de campo
            //Nombre
            if (autor is null)
            {
                result = OperationResult.Failure("El autor no puede ser nulo");
            }
            if (String.IsNullOrWhiteSpace(autor!.Nombre))
            {
                result = OperationResult.Failure("El nombre del autor no puede ser nulo");
            }
            if (!Regex.IsMatch(autor.Nombre, PATTERN))
            {
                result = OperationResult.Failure("El nombre esta en formato invalido");
            }
            if (autor.Nombre.Length > 50)
            {
                result = OperationResult.Failure("El nombre del autor no puede superar los 50 caracteres");
            }

            //Apellido
            if (String.IsNullOrWhiteSpace(autor.Apellido))
            {
                result = OperationResult.Failure("El apellido del autor no puede ser nulo");
            }
            if (!Regex.IsMatch(autor.Apellido, PATTERN))
            {
                result = OperationResult.Failure("El apellido del autor debe ser de un formato valido");
            }

            //Nacionalidad
            if (String.IsNullOrWhiteSpace(autor.Nacionalidad))
            {
                result = OperationResult.Failure("La nacionalidad del autor no puede ser nula");
            }
            if (!Regex.IsMatch(autor.Nacionalidad, PATTERN))
            {
                result = OperationResult.Failure("La nacionalidad esta en formato invalido");
            }

            result = OperationResult.Success($"Autor editado con exito!", autor);

            _logger.LogInformation($"UsuarioMod: {autor.UsuarioModId} |" +
                $"Fecha Mod: {autor.FechaMod = DateTime.Now}");

            return base.EditarAsync(autor);
        }

        /// <summary>
        /// Metodo para borrar (borrado logico) Autor en la BD.
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        public override Task<OperationResult> BorrarAsync(Autor autor)
        {
            autor.Habilitado = false;

            result = OperationResult.Success($"Autor borrado con exito!, ", autor);

            _logger.LogInformation($"UsuarioElim: {autor.UsuarioEliminoId} |" +
                $"FechaElim: {autor.FechaElimino = DateTime.Now}");

            return base.BorrarAsync(autor);
        }

        /// <summary>
        /// Meodo para obtener todos los Autores habilitados en la BD.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        
        //Aqui irian los contratos de IAutorRepo.

    }
}
