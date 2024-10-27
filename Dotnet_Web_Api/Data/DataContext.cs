using Dotnet_Web_Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Web_Api.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
            
        }

        public DbSet<User> users { get; set; }
    }
}
