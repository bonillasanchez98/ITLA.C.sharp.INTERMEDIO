using BiblioWeb.Data.Categoria;
using BiblioWeb.Models.Result;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BiblioWeb.Data.Usuario
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private string _connString;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CategoriaDAO> _logger;

        public UsuarioDAO(IConfiguration configuration, ILogger<CategoriaDAO> logger)
        {
            _connString = configuration.GetConnectionString("biblioConn");
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<OperationResult> AddUserAsync(Usuario usuario)
        {
            OperationResult Opresult = new OperationResult();

            try
            {
                _logger.LogInformation("Iniciando procedimiento para guardar un usuario...");

                if (usuario == null)
                    Opresult = OperationResult.Failure("Usuario no puede ser nulo.");
                if (string.IsNullOrEmpty(usuario!.Nombre))
                    Opresult = OperationResult.Failure("El nombre del usuario no puede ser nulo.");
                if (string.IsNullOrEmpty(usuario.Correo))
                    Opresult = OperationResult.Failure("El correo del usuario no puede ser nulo.");
                if (string.IsNullOrEmpty(usuario.Clave))
                    Opresult = OperationResult.Failure("La clave del usuario no puede ser nulo.");
                

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Seguridad.GuardandoUsuarios", conn))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_Nombre", usuario!.Nombre);
                        command.Parameters.AddWithValue("@p_Correo", usuario.Correo);
                        command.Parameters.AddWithValue("@p_Clave", usuario.Clave);
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
                            Opresult = OperationResult.Failure($"Error agregando el usuario: {usuario}");

                        _logger.LogInformation("Usuario guardado con exito!");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error agregando usuario: {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} agregando usuario.");
            }

            return Opresult;
        }

        public async Task<OperationResult> GetAllUsersAsync()
        {
            OperationResult Opresult = new OperationResult();
            try
            {
                _logger.LogInformation("Iniciando procedimiento para obtener todas los usuarios...");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Seguridad.ObteniendoUsuarios", conn))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        await conn.OpenAsync();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            List<Usuario> usuarios = new List<Usuario>();
                            while (await reader.ReadAsync())
                            {
                                usuarios.Add(new Usuario()
                                {
                                    id_Usuario = Convert.ToInt32(reader["id_Usuario"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Correo = reader["Correo"].ToString()
                                });
                            }
                            Opresult = OperationResult.Success("Usuarios obtenidos con exito!", usuarios);
                        }
                        else
                            Opresult = OperationResult.Failure("Usuarios no encontradas.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error buscando los usuarios: {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} buscando los usuarios.");
            }

            return Opresult;
        }

        public async Task<OperationResult> GetUserAsync(int id)
        {
            OperationResult Opresult = new OperationResult();
            try
            {
                _logger.LogInformation($"Iniciando procedimiento para obtener usuario {id}...");

                if (id <= 0)
                    Opresult = OperationResult.Failure($"ID {id}, debe ser mayor a cero (0)");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Seguridad.ObteniendoUsuarioPorId", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_UsuarioId", id);

                        await conn.OpenAsync();
                        var reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            Usuario usuario = new Usuario();
                            usuario.id_Usuario = Convert.ToInt32(reader["id_Usuario"]);
                            usuario.Nombre = reader["Nombre"].ToString();
                            usuario.Correo = reader["Correo"].ToString();

                            Opresult = OperationResult.Success($"El usuario fue encontrada con exito!.", usuario);
                        }
                        else
                            Opresult = OperationResult.Failure($"El usuario de ID {id} no fue encontrado");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error obtiendo el usuairo de ID: {id} : {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} obteniendo el usuario.");
            }

            return Opresult;
        }

        public async Task<OperationResult> UpdateUserAsync(Usuario usuario)
        {
            OperationResult Opresult = new OperationResult();

            try
            {
                _logger.LogInformation("Iniciando procedimiento de actualizado de usuario...");

                if (usuario == null)
                    Opresult = OperationResult.Failure("Usuario no puede ser nulo.");
                if (string.IsNullOrEmpty(usuario!.Nombre))
                    Opresult = OperationResult.Failure("El nombre del usuario no puede ser nulo.");
                if (string.IsNullOrEmpty(usuario.Correo))
                    Opresult = OperationResult.Failure("El correo del usuario no puede ser nulo.");
                if (string.IsNullOrEmpty(usuario.Clave))
                    Opresult = OperationResult.Failure("La clave del usuario no puede ser nulo.");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Seguridad.ActualizandoUsuario", conn))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_Nombre", usuario!.Nombre);
                        command.Parameters.AddWithValue("@p_Correo", usuario.Correo);
                        command.Parameters.AddWithValue("@p_Clave", usuario.Clave);
                        command.Parameters.AddWithValue("@p_FechaMod", DateTime.Now);
                        command.Parameters.AddWithValue("@p_UsuarioMod", 2);

                        SqlParameter p_result = new SqlParameter("@p_Result", SqlDbType.VarChar)
                        {
                            Size = 4000,
                            Direction = ParameterDirection.Output,
                        };

                        command.Parameters.Add(p_result);
                        await conn.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        var result = (string)p_result.Value;

                        if (result != "Ok")
                            Opresult = OperationResult.Failure($"Error actualizando el usuario: {usuario}");
                        else
                            Opresult = OperationResult.Success(result);

                        _logger.LogInformation("Usuario actualizada con exito!");
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error agregando usuario: {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} actualizando usuario.");
            }

            return Opresult;
        }
    }
}
