using BiblioWeb.Models.Result;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Biblio.Web.Data
{
    public class CategoriaDAO : ICategoriaDAO
    {
        private string _connString;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CategoriaDAO> _logger;


        //Inyectando el string de conexion de la BD
        public CategoriaDAO(IConfiguration configuration, ILogger<CategoriaDAO> logger)
        {
            _connString = configuration.GetConnectionString("biblioConn");
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<OperationResult> AddCategoryAsync(Categoria categoria)
        {
            OperationResult Opresult = new OperationResult();

            try
            {
                _logger.LogInformation("Iniciando procedimiento de guardado de categoria...");

                if(categoria == null)
                    Opresult = OperationResult.Failure("Categoria no puede ser nulo.");
                if (string.IsNullOrEmpty(categoria!.Nombre))
                    Opresult = OperationResult.Failure("El nombre de la categoria no puede ser nulo.");
                if (categoria.Descripcion.Length > 150)
                    Opresult = OperationResult.Failure("La descripcion de la categoria no puede exceder los 150 caracteres.");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Core.GuardandoCategorias", conn))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_NombreCategoria", categoria!.Nombre);
                        command.Parameters.AddWithValue("@p_DescripcionCategoria", categoria.Descripcion);
                        command.Parameters.AddWithValue("@p_UsuarioCreacionId", 2);

                        SqlParameter p_result = new SqlParameter("@p_Result", System.Data.SqlDbType.VarChar)
                        {
                            Size = 4000,
                            Direction = System.Data.ParameterDirection.Output,
                        };

                        command.Parameters.Add(p_result);

                        await conn.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        var result = (string)p_result.Value;

                        if (result == "Ok")
                            Opresult = OperationResult.Success(result);
                        else
                            Opresult = OperationResult.Failure($"Error agregando la categoria: {categoria}");

                        _logger.LogInformation("Categoria guardada con exito!");
                    }   
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error agregando categoria: {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} agregando categoria.");
            }

            return Opresult;
        }

        public async Task<OperationResult> GetAllCategoriesAsync()
        {
            OperationResult Opresult = new OperationResult();
            try
            {
                _logger.LogInformation("Iniciando procedimiento para obtener todas las categorias...");

                using(var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Core.ObteniendoCategorias", conn))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        await conn.OpenAsync();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            List<Categoria> categorias = new List<Categoria>();
                            while (await reader.ReadAsync())
                            {
                                categorias.Add(new Categoria
                                {
                                    id_Categoria = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    Descripcion = reader.GetString(2)
                                });
                            }
                            Opresult = OperationResult.Success("Categorias obtenidas con exito!", categorias);
                        }
                        else
                            Opresult = OperationResult.Failure("Categorias no encontradas.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error buscando las categorias: {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} buscando las categorias.");
            }

            return Opresult;
        }

        public async Task<OperationResult> GetCategoryAsync(int id)
        {
            OperationResult Opresult = new OperationResult();
            try
            {
                _logger.LogInformation($"Iniciando procedimiento para obtener categoria id {id}...");

                if (id <= 0)
                    Opresult = OperationResult.Failure($"ID {id}, debe ser mayor a cero (0)");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Core.ObteniendoCategoriaPorId", conn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_CategoriaId", id);

                        await conn.OpenAsync();
                        var reader = await command.ExecuteReaderAsync();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            Categoria categoria = new Categoria();
                            categoria.id_Categoria = reader.GetInt32(0);
                            categoria.Nombre = reader.GetString(1);
                            categoria.Descripcion = reader.GetString(2);

                            Opresult = OperationResult.Success($"La categoria fue encontrada con exito!.", categoria);
                        }   
                        else
                            Opresult = OperationResult.Failure($"La categoria de ID {id} no fue encontrada");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error obtiendo la categoria de ID: {id} : {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} obteniendo la categoria.");
            }

            return Opresult;
        }

        public async Task<OperationResult> UpdateCategoryAsync(int id, Categoria categoria)
        {
            OperationResult Opresult = new OperationResult();

            try
            {
                _logger.LogInformation("Iniciando procedimiento de actualizado de categoria...");

                if (categoria.id_Categoria != id)
                    Opresult = OperationResult.Failure("Id de categoria no encontrado.");
                if(categoria == null)
                    Opresult = OperationResult.Failure("Categoria no puede ser nulo.");
                if (string.IsNullOrEmpty(categoria!.Nombre))
                    Opresult = OperationResult.Failure("El nombre de la categoria no puede ser nulo");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Core.ActualizandoCategoria", conn))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_CategoriaId", categoria.id_Categoria);
                        command.Parameters.AddWithValue("@p_NombreCategoria", categoria.Nombre);
                        command.Parameters.AddWithValue("@p_FechaMod", DateTime.Now);
                        command.Parameters.AddWithValue("@p_UsuarioMod", 1);

                        SqlParameter p_result = new SqlParameter("@p_Result", System.Data.SqlDbType.VarChar)
                        {
                            Size = 4000,
                            Direction = System.Data.ParameterDirection.Output,
                        };

                        command.Parameters.Add(p_result);
                        await conn.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        var result = (string)p_result.Value;

                        if (result != "Ok")
                            Opresult = OperationResult.Failure($"Error actualizando la categoria: {categoria}");
                        else
                            Opresult = OperationResult.Success(result);

                        _logger.LogInformation("Categoria actualizada con exito!");
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error agregando categoria: {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} actualizando categoria.");
            }

            return Opresult;
        }
    }
}
