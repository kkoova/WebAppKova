using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebAppKovaApi.Contracts.Configurations;

namespace WebAppKovaApi.Context
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public class AppContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SupplierConfiguration).Assembly);
        }
    }
}