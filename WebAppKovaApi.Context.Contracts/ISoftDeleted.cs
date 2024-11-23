namespace WebAppKovaApi.Context.Contracts
{
    /// <summary>
    /// Мягкое удаление
    /// </summary>
    public class ISoftDeleted
    {
        public DateTimeOffset? Deleted { get; set; }
    }
}