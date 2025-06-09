using BiblioWeb.Models.Result;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BiblioWeb.Data.Rol
{
    public class RolDAO : IRolDAO
    {
        private string _connString;
        private readonly IConfiguration _configuration;
        private readonly ILogger<RolDAO> _logger;

        public RolDAO(IConfiguration configuration, ILogger<RolDAO> logger)
        {
            _connString = configuration.GetConnectionString("biblioConn");
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<OperationResult> AddRoleAsync(Rol rol)
        {
            OperationResult Opresult = new OperationResult();

            try
            {
                _logger.LogInformation("Iniciando procedimiento para guardar un rol...");

                if (rol == null)
                    Opresult = OperationResult.Failure("Rol no puede ser nulo.");
                if (string.IsNullOrEmpty(rol!.Nombre))
                    Opresult = OperationResult.Failure("El nombre del rol no puede ser nulo.");
                if (rol.Nombre.Length > 50)
                    Opresult = OperationResult.Failure("El nombre de rol no puede exceder los 50 caracteres.");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Seguridad.GuardandoRoles", conn))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_NombreRol", rol.Nombre);
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
                            Opresult = OperationResult.Failure($"Error agregando el rol: {rol}");

                        _logger.LogInformation("Rol guardado con exito!");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error agregando rol: {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} agregando rol.");
            }

            return Opresult;
        }

        public async Task<OperationResult> GetAllRoleAsync()
        {
            OperationResult Opresult = new OperationResult();
            try
            {
                _logger.LogInformation("Iniciando procedimiento para obtener todas los roles...");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Seguridad.ObteniendoRoles", conn))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        await conn.OpenAsync();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            List<Rol> roles = new List<Rol>();
                            while (await reader.ReadAsync())
                            {
                                roles.Add(new Rol(){
                                    id_Rol = Convert.ToInt32(reader["id_Rol"]),
                                    Nombre = reader["Nombre"].ToString()
                                });
                            }
                            Opresult = OperationResult.Success("Roles obtenidos con exito!", roles);
                        }
                        else
                            Opresult = OperationResult.Failure("Roles no encontrados.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error buscando los roles: {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} buscando los roles.");
            }

            return Opresult;
        }

        public async Task<OperationResult> GetRoleAsync(int id)
        {
            OperationResult Opresult = new OperationResult();
            try
            {
                _logger.LogInformation($"Iniciando procedimiento para obtener rol {id}...");

                if (id <= 0)
                    Opresult = OperationResult.Failure($"ID {id}, debe ser mayor a cero (0)");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Seguridad.ObteniendoRolPorId", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_RolId", id);

                        await conn.OpenAsync();
                        var reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            Rol rol = new Rol();
                            rol.id_Rol = Convert.ToInt32(reader["id_Rol"]);
                            rol.Nombre = reader["Nombre"].ToString();

                            Opresult = OperationResult.Success($"El rol fue encontrada con exito!.", rol);
                        }
                        else
                            Opresult = OperationResult.Failure($"El rol  de ID {id} no fue encontrado");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error obtiendo el rol de ID: {id} : {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} obteniendo el rol.");
            }

            return Opresult;
        }

        public async Task<OperationResult> UpdateRoleAsync(Rol rol)
        {
            OperationResult Opresult = new OperationResult();

            try
            {
                _logger.LogInformation("Iniciando procedimiento de actualizado de rol...");

                if (rol == null)
                    Opresult = OperationResult.Failure("Rol no puede ser nulo.");
                if (string.IsNullOrEmpty(rol!.Nombre))
                    Opresult = OperationResult.Failure("El nombre del rol no puede ser nulo.");
                if (rol.Nombre.Length > 50)
                    Opresult = OperationResult.Failure("El nombre del rol no puede ser nulo.");

                using (var conn = new SqlConnection(_connString))
                {
                    using (var command = new SqlCommand("Seguridad.ActualizandoRol", conn))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_RolId", rol.id_Rol);
                        command.Parameters.AddWithValue("@p_NombreRol", rol!.Nombre);
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
                            Opresult = OperationResult.Failure($"Error actualizando el rol: {rol}");
                        else
                            Opresult = OperationResult.Success(result);

                        _logger.LogInformation("Rol actualizada con exito!");
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error agregando rol: {ex.Message}", ex.ToString);
                Opresult = OperationResult.Failure($"Error: {ex.Message} actualizando rol.");
            }

            return Opresult;
        }
    }
}
