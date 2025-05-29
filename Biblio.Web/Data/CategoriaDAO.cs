using Biblio.Web.Exceptions;
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

        public async Task AddCategoryAsync(Categoria categoria)
        {
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Core.GuardandoCategorias", conn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_NombreCategoria", categoria.Nombre);
                        command.Parameters.AddWithValue("@p_UsuarioCreacionId", 1);

                        SqlParameter p_result = new SqlParameter("@p_Result", System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output,
                        };

                        command.Parameters.Add(p_result);

                        await conn.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        var result = (string)p_result.Value;
                        if (result != "Ok")
                            throw new CategoriaException(result);
                    }   
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error agregando categoria: {ex.Message}", ex.ToString);
            }
        }

        public async Task<List<Categoria>> GetAllCategoriesAsync()
        {
            List<Categoria> categorias = new List<Categoria>();
            try
            {
                using(var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Core.ObteniendoCategorias", conn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        SqlDataReader reader = command.ExecuteReader();
                        while (await reader.ReadAsync())
                        {
                            categorias.Add(new Categoria
                            {
                                id_Categoria = reader.GetInt32("id_Categoria"),
                                Nombre = reader.GetString("Nombre"),
                                Descripcion = reader.GetString("Descripcion")
                            });
                        }

                        await conn.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error buscando las categorias: {ex.Message}", ex.ToString);
            }

            return categorias;
        }

        public Task<Categoria> GetCategoryAsync(int id)
        {
            return Task.FromResult(new Categoria {
                id_Categoria = id, Nombre = "Categoria Ejemplo", Descripcion = "Descripcion categoria Ejemplo", FechaCreacion = DateTime.Now});
        }

        public Task UpdateCategoryAsync(int id, Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
