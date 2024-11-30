namespace WebAppKovaApi.Context.Contracts
{
    /// <summary>
    /// Мягкое удаление
    /// </summary>
    public interface ISoftDeleted
    {
        public DateTimeOffset? Deleted { get; set; }
    }
}