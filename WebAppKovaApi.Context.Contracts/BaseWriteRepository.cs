using System.Diagnostics.CodeAnalysis;
using WebApiKovaApi.Common.Abstractions;

namespace WebAppKovaApi.Context.Contracts
{
    public abstract class BaseWriteRepository<T> : IDbWrider where T : class
    {
        private readonly IWriter writer;
        private readonly IDataTimeProvider dataTimeProvider;

        /// <summary>
        /// ctor
        /// </summary>
        protected BaseWriteRepository(IWriter writer, 
            IDataTimeProvider dataTimeProvider)
        {
            this.writer = writer;
            this.dataTimeProvider = dataTimeProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Add([NotNull] T entity)
        {
            if (entity is IEntityWhihId entityWhihId &&
                entityWhihId.Id == default)
            {
                entityWhihId.Id = Guid.NewGuid();
            }
            AuditForCreate(entity);
            writer.Add(entity);

        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete([NotNull] T entity)
        {
            AuditForUpdate(entity);
            if (entity is ISoftDeleted softDeleted)
            {
                softDeleted.Deleted = dataTimeProvider.UtcNow;
                writer.Update(entity);
            }
            else
            {
                writer.Delete(entity);
            }
        }

        public void Update([NotNull] T entity)
        {
            AuditForUpdate(entity);
            writer.Update(entity);
        }

        private void AuditForCreate([NotNull] T entity) 
        {
            if (entity is IAuditableEntity auditableEntity)
            {
                auditableEntity.CreatedAt = dataTimeProvider.UtcNow;
                auditableEntity.UpdatedAt = dataTimeProvider.UtcNow;
            }
        }

        private void AuditForUpdate([NotNull] T entity)
        {
            if (entity is IAuditableEntity auditableEntity)
            {
                auditableEntity.CreatedAt = dataTimeProvider.UtcNow;
                auditableEntity.UpdatedAt = dataTimeProvider.UtcNow;
            }
        }
    }
}
