using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ScuolaAPIServer.Data;

namespace ScuolaAPIServer.Data
{
    public class ScuolaDbContextFactory : IDesignTimeDbContextFactory<ScuolaDbContext>
    {
        public ScuolaDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ScuolaDbContext>();
            var conn = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(conn);

            return new ScuolaDbContext(optionsBuilder.Options);
        }
    }
}