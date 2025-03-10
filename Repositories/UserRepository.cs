using ADD_DABOMPA.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD_DABOMPA.Repositories
{
    public static class UserRepository
    {
        private static string ConnectionString = "Data Source=C:\\ADD_DABOMPA\\ADD_DABOMPA_DB.db";

        public static UserModel GetUserByEmail(string email)
        {
            UserModel user = null;
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT email, login, password FROM Users WHERE Email = @Email and deleted = 0";
                command.Parameters.AddWithValue("@Email", email);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel
                        {
                            email = reader.GetString(0),
                            login = reader.GetString(1),
                            password = reader.GetString(2)
                        };
                    }
                }
            }
            return user;
        }
    }
}

