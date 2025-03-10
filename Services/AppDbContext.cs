using ADD_DABOMPA.Models;
using Microsoft.EntityFrameworkCore;

namespace ADD_DABOMPA.Services
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\ADD_DABOMPA\\ADD_DABOMPA_DB.db");
        }
    }
}
