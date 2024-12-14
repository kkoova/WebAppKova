namespace WebAppKovaApi.Context.Contracts.Specs
{
    public static class CommonSpecification
    {
        public static IQueryable<T> NotDeleted<T>(this IQueryable<T> set)
            where T : ISoftDeleted
            => set.Where(x => x.Deleted == null);

        public static IQueryable<T> ById<T>(this IQueryable<T> set, Guid id)
            where T : IEntityWhihId
            => set.Where(x => x.Id == id);
    }
}
