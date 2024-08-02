using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;

namespace GymSystem.Authorization
{
    public class UserService
    {
        private readonly string connectionString;

        public UserService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> AuthenticateAccount(string userName, string password)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand($"SELECT * FROM UserData WHERE Username='{userName}'", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            if(reader.GetString(2) == password)
                            {
                                return true;
                            }
                        }    
                    }
                }
            }

            return false;
        }

        public async Task<UserSession> GetNewSession(string userName, string password)
        {
            UserSession newSession = new UserSession();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand($"SELECT * FROM UserData WHERE Username='{userName}'", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            newSession.UserName = reader.GetString(1);
                            newSession.UserId = reader.GetGuid(0);
                            newSession.OrgId = reader.GetGuid(3);
                            newSession.Role = reader.GetString(4);
                        }
                    }
                }
            }

            return newSession;
        }
    }
}
