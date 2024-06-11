using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace LMS_BACKEND_MAIN.ContextFactory
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer(configuration.GetConnectionString("LemaoString"), a=> a.MigrationsAssembly("LMS_BACKEND_MAIN"));
            return new DataContext(builder.Options);
        }
    }
}
