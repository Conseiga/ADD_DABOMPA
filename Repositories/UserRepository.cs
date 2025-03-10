using ADD_DABOMPA.Models;
using ADD_DABOMPA.Services;
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
        public static UserModel? GetUserByEmail(string email)
        {
            using (var db = new AppDbContext()) // Create a database session
            {
                return db.Users.FirstOrDefault(u => u.email == email);
            }
        }
    }
}

