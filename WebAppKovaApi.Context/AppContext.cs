using Microsoft.EntityFrameworkCore;
using WebAppKovaApi.Contracts;
using WebAppKovaApi.Contracts.Configurations;

namespace WebAppKovaApi.Context
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <remarks>
    /// dotnet tool install --global dotnet-ef --version 6.*
    /// dotnet tool install --global dotnet-ef
    /// dotnet tool update --global dotnet-ef
    /// dotnet ef migrations add Init --project WebAppKovaApi.Context/WebAppKovaApi.Context.csproj
    /// </remarks>
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IContractAnchor).Assembly);
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Supplier> Suppliers { get; set; }
    }
}