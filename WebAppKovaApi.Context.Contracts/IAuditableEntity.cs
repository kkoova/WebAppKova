﻿namespace WebAppKovaApi.Context.Contracts
{
    public class IAuditableEntity
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
