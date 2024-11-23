using WebAppKovaApi.Context.Contracts;

namespace WebAppKovaApi.Contracts
{
    /// <summary>
    /// Поставщик
    /// </summary>
    public class Supplier : IAuditableEntity, ISoftDeleted
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Опиcание
        /// </summary>
        public string Description { get; set; }

        /// <inheritdoc cref="IAuditableEntity.CreatedAt"/>
        public DateTimeOffset CreatedAt { get; set; }

        /// <inheritdoc cref="IAuditableEntity.UpdatedAt"/>
        public DataMisalignedException UpdatedAt { get; set; }

        /// <inheritdoc cref="ISoftDeleted.Deleted"/>
        public DateTimeOffset? Deleted { get; set; }

    }
}
