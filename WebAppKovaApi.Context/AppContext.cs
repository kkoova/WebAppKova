using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using WebAppKovaApi.Context.Contracts;
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
    public class AppContext : DbContext, 
        IReader, 
        IWriter, 
        IUnitOfWork
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IContractAnchor).Assembly);
        }

        IQueryable<TEntity> IReader.Read<TEntity>()
            => base.Set<TEntity>()
            .AsNoTracking()
            .AsQueryable();

        async Task<int> IUnitOfWork.CommitAsync(CancellationToken cancellationToken)
        {
            var count = await base.SaveChangesAsync(cancellationToken);
            foreach (var entry in base.ChangeTracker.Entries().ToArray())
            {
                entry.State = EntityState.Detached;
            }

            return count;
        }

        void IWriter.Add<IEntity>([NotNull] IEntity entity)
            => base.Entry(entity).State = EntityState.Added;

        void IWriter.Update<IEntity>([NotNull] IEntity entity)
            => base.Entry(entity).State = EntityState.Modified;

        void IWriter.Delete<IEntity>([NotNull] IEntity entity)
            => base.Entry(entity).State = EntityState.Deleted;
    }
}