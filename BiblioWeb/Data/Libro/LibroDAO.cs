using BiblioWeb.Models.Result;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BiblioWeb.Data.Libro
{
    public class LibroDAO : ILibroDAO
    {
        private string _connString;
        private readonly IConfiguration _configuration;
        private readonly ILogger<LibroDAO> _logger;

        public LibroDAO(IConfiguration configuration, ILogger<LibroDAO> logger)
        {
            _connString = configuration.GetConnectionString("biblioConn");
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<OperationResult> AddBookAsync(Libro libro)
        {
            OperationResult Opresult = new OperationResult();

            try
            {
                _logger.LogInformation("Iniciando procedimiento de guardado de libro...");

                if (libro == null)
                    Opresult = OperationResult.Failure("Libro no puede ser nulo.");
                if (libro.Autor_id <= 0)
                    Opresult = OperationResult.Failure("El autor no puede ser nulo.");
                if (libro.Categoria_id <= 0)
                    Opresult = OperationResult.Failure("La categoria no puede ser nulo.");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Core.GuardandoLibros", conn))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_Titulo", libro.Titulo);
                        command.Parameters.AddWithValue("@p_AutorId", libro.Autor_id);
                        command.Parameters.AddWithValue("@p_ISBN", libro.ISBN);
                        command.Parameters.AddWithValue("@p_fechaPublicacion", libro.FechaPublicacion);
                        command.Parameters.AddWithValue("@p_CantEjemplar", libro.CantidadEjemplares);
                        command.Parameters.AddWithValue("@p_CategoriaId", libro.Categoria_id);
                        command.Parameters.AddWithValue("@p_UsuarioCreacionId", 2);

                        SqlParameter p_result = new SqlParameter("@p_Result", SqlDbType.VarChar)
                        {
                            Size = 4000,
                            Direction = ParameterDirection.Output,
                        };

                        command.Parameters.Add(p_result);

                        await conn.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        var result = (string)p_result.Value;

                        if (result == "Ok")
                            Opresult = OperationResult.Success(result);
                        else
                            Opresult = OperationResult.Failure($"Error agregando el libro: {libro}");

                        _logger.LogInformation("Libro guardado con exito!");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error agregando libro: {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} agregando libro.");
            }

            return Opresult;
        }

        public async Task<OperationResult> GetAllBooksAsync()
        {
            OperationResult Opresult = new OperationResult();
            try
            {
                _logger.LogInformation("Iniciando procedimiento para obtener todos los libros...");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Core.ObteniendoLibros", conn))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        await conn.OpenAsync();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            List<Libro> libros = new List<Libro>();
                            while (await reader.ReadAsync())
                            {
                                libros.Add(new Libro()
                                {
                                    id_Libro = Convert.ToInt32(reader["id_Libro"]),
                                    Titulo = reader["Titulo"].ToString(),
                                    Autor_id = Convert.ToInt32(reader["Autor_id"].ToString()),
                                    ISBN = reader["ISBN"].ToString(),
                                    Categoria_id = Convert.ToInt32(reader["Categoria_id"].ToString()),
                                    FechaPublicacion = DateTime.Parse(reader["Fecha_publicacion"].ToString()),
                                    CantidadEjemplares = Convert.ToInt32(reader["Cantidad_ejemplares"])
                                });
                            }
                            Opresult = OperationResult.Success("Libros obtenidos con exito!", libros);
                        }
                        else
                            Opresult = OperationResult.Failure("Libros no encontrados.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error buscando los Libros: {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} buscando los Libros.");
            }

            return Opresult;
        }
        
        public async Task<OperationResult> GetBookAsync(int id)
        {
            OperationResult Opresult = new OperationResult();
            try
            {
                _logger.LogInformation($"Iniciando procedimiento para obtener libro id {id}...");

                if (id <= 0)
                    Opresult = OperationResult.Failure($"ID {id}, debe ser mayor a cero (0)");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Core.ObteniendoLibroPorId", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_LibroId", id);

                        await conn.OpenAsync();
                        var reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            Libro libro = new Libro();
                            libro.id_Libro = Convert.ToInt32(reader["id_Libro"]);
                            libro.Titulo = reader["Titulo"].ToString();
                            libro.Autor_id = Convert.ToInt32(reader["Autor_id"].ToString());
                            libro.Categoria_id = Convert.ToInt32(reader["Categoria_id"].ToString());
                            libro.ISBN = reader["ISBN"].ToString();
                            libro.FechaPublicacion = DateTime.Parse(reader["Fecha_publicacion"].ToString());
                            libro.CantidadEjemplares = Convert.ToInt32(reader["Cantidad_ejemplares"].ToString());

                            Opresult = OperationResult.Success($"El libro fue encontrado con exito!.", libro);
                        }
                        else
                            Opresult = OperationResult.Failure($"El libro de ID {id} no fue encontrado");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error obtiendo el libro de ID: {id} : {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} obteniendo el libro.");
            }

            return Opresult;
        }

        public Task<OperationResult> UpdateBookAsync(Libro libro)
        {
            throw new NotImplementedException();
        }
    }
}
