using BiblioWeb.Models.Result;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Biblio.Web.Data
{
    public class CategoriaDAO : ICategoriaDAO
    {
        private readonly string _connString;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CategoriaDAO> _logger;


        //Inyectando el string de conexion de la BD
        public CategoriaDAO(string connString, IConfiguration configuration, ILogger<CategoriaDAO> logger)
        {
            _connString = connString;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<OperationResult> AddCategoryAsync(Categoria categoria)
        {
            OperationResult Opresult = new OperationResult();

            try
            {
                if(categoria == null)
                    Opresult = OperationResult.Failure("Categoria no puede ser nulo.");
                if (string.IsNullOrEmpty(categoria!.Nombre))
                    Opresult = OperationResult.Failure("El nombre de la categoria no puede ser nulo");
                

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Core.GuardandoCategorias", conn))
                    {
                        _logger.LogInformation("Iniciando procedimiento de guardado de categoria...");

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_NombreCategoria", categoria!.Nombre);
                        command.Parameters.AddWithValue("@p_UsuarioCreacionId", 1);

                        SqlParameter p_result = new SqlParameter("@p_Result", System.Data.SqlDbType.VarChar)
                        {
                            Direction = System.Data.ParameterDirection.Output,
                        };

                        command.Parameters.Add(p_result);

                        await conn.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        var result = (string)p_result.Value;

                        if (result != "Ok")
                            Opresult = OperationResult.Failure($"Error agregando la categoria: {categoria}");
                        else
                            Opresult = OperationResult.Success(result);

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
                using(var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Core.ObteniendoCategorias", conn))
                    {
                        _logger.LogInformation("Iniciando procedimiento para obtener todas las categorias...");

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

                        }


                        await conn.OpenAsync();
                        await command.ExecuteNonQueryAsync();
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

        public Task<OperationResult> GetCategoryAsync(int id)
        {
            OperationResult Opresult = new OperationResult();
            try
            {

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error agregando categoria: {ex.Message}", ex.ToString);
            }

            return Task.FromResult(Opresult);
        }

        public async Task<OperationResult> UpdateCategoryAsync(int id, Categoria categoria)
        {
            OperationResult Opresult = new OperationResult();

            try
            {
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
                        _logger.LogInformation("Iniciando procedimiento de actualizado de categoria...");

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_CategoriaId", categoria.id_Categoria);
                        command.Parameters.AddWithValue("@p_NombreCategoria", categoria.Nombre);
                        command.Parameters.AddWithValue("@p_FechaMod", DateTime.Now);
                        command.Parameters.AddWithValue("@p_UsuarioMod", 1);

                        SqlParameter p_result = new SqlParameter("@p_Result", System.Data.SqlDbType.VarChar)
                        {
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
