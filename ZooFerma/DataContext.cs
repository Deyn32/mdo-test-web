using Microsoft.EntityFrameworkCore;

namespace ZooFerma
{
    public class DataContext: DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration) => Configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }
}
