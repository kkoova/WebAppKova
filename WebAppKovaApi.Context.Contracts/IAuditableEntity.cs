namespace WebAppKovaApi.Context.Contracts
{
    public interface IAuditableEntity
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
