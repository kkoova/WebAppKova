using WebAppKovaApi.Context.Contracts;

namespace WebAppKovaApi.Contracts
{
    /// <summary>
    /// Поставщик
    /// </summary>
    public class Supplier : ISoftDeleted, IAuditableEntity, IEntityWhihId
    {
        /// <inheritdoc cref="Id"/>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <inheritdoc cref="IAuditableEntity.CreatedAt"/>
        public DateTimeOffset CreatedAt { get; set; }

        /// <inheritdoc cref="IAuditableEntity.UpdatedAt"/>
        public DateTimeOffset UpdatedAt { get; set; }

        /// <inheritdoc cref="ISoftDeleted.Deleted"/>
        public DateTimeOffset? Deleted { get; set; }
    }
}
