using BiblioWeb.Data.Categoria;
using BiblioWeb.Models.Result;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Data;

namespace BiblioWeb.Data.Autor
{
    public class AutorDAO : IAutorDAO
    {
        private string _connString;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CategoriaDAO> _logger;

        public AutorDAO(IConfiguration configuration, ILogger<CategoriaDAO> logger)
        {
            _connString = configuration.GetConnectionString("biblioConn");
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<OperationResult> AddAuthorAsync(Autor autor)
        {
            OperationResult Opresult = new OperationResult();

            try
            {
                _logger.LogInformation("Iniciando procedimiento de guardado de autor...");

                if (autor == null)
                    Opresult = OperationResult.Failure("Autor no puede ser nulo.");
                if (string.IsNullOrEmpty(autor!.Nombre))
                    Opresult = OperationResult.Failure("El nombre del autor no puede ser nulo.");
                if (autor.Nombre.Length > 50)
                    Opresult = OperationResult.Failure("El nombre del autor no puede exceder los 50 caracteres.");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Core.GuardandoAutores", conn))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_NombreAutor", autor!.Nombre);
                        command.Parameters.AddWithValue("@p_ApellidoAutor", autor.Apellido);
                        command.Parameters.AddWithValue("@p_FechaNacimiento", autor.FechaNacimiento);
                        command.Parameters.AddWithValue("@p_Nacionalidad", autor.Nacionalidad);
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
                            Opresult = OperationResult.Failure($"Error agregando el autor: {autor}");

                        _logger.LogInformation("Autor guardado con exito!");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error agregando autor: {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} agregando autor.");
            }

            return Opresult;
        }

        public async Task<OperationResult> GetAllAuthorsAsync()
        {
            OperationResult Opresult = new OperationResult();
            try
            {
                _logger.LogInformation("Iniciando procedimiento para obtener todos los autores...");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Core.ObteniendoAutores", conn))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        await conn.OpenAsync();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            List<Autor> autores = new List<Autor>();
                            while (await reader.ReadAsync())
                            {
                                autores.Add(new Autor()
                                {
                                    id_Autor = Convert.ToInt32(reader["id_Autor"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    FechaNacimiento = DateTime.Parse(reader["Fecha_nacimiento"].ToString()),
                                    Nacionalidad = reader["Nacionalidad"].ToString()
                                });
                            }
                            Opresult = OperationResult.Success("Autores obtenidos con exito!", autores);
                        }
                        else
                            Opresult = OperationResult.Failure("Autores no encontradas.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error buscando los autores: {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} buscando los autores.");
            }

            return Opresult;
        }

        public async Task<OperationResult> GetAuthorAsync(int id)
        {
            OperationResult Opresult = new OperationResult();
            try
            {
                _logger.LogInformation($"Iniciando procedimiento para obtener autor id {id}...");

                if (id <= 0)
                    Opresult = OperationResult.Failure($"ID {id}, debe ser mayor a cero (0)");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Core.ObteniendoAutorPorId", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_AutorId", id);

                        await conn.OpenAsync();
                        var reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            Autor autor = new Autor();
                            autor.id_Autor = Convert.ToInt32(reader["id_Autor"]);
                            autor.Nombre = reader["Nombre"].ToString();
                            autor.Apellido = reader["Apellido"].ToString();
                            autor.FechaNacimiento = DateTime.Parse(reader["Fecha_nacimiento"].ToString());
                            autor.Nacionalidad = reader["Nacionalidad"].ToString();

                            Opresult = OperationResult.Success($"El autor fue encontrado con exito!.", autor);
                        }
                        else
                            Opresult = OperationResult.Failure($"El autor de ID {id} no fue encontrado");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error obtiendo el autor de ID: {id} : {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} obteniendo el autor.");
            }

            return Opresult;
        }

        public async Task<OperationResult> UpdateAuthorAsync(Autor autor)
        {
            throw new NotImplementedException();
        }
    }
}
