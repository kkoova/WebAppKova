using Microsoft.EntityFrameworkCore;
using WebApiKovaApi.Repositories.Contracts;
using WebAppKovaApi.Context.Contracts;
using WebAppKovaApi.Context.Contracts.Specs;
using WebAppKovaApi.Contracts;

namespace WebApiKovaApi.Repositories
{
    public class SupplierReadRepository : ISupplierReadRepository
    {
        public readonly IReader reader;

        public SupplierReadRepository(IReader reader)
        {
            this.reader = reader;
        }

        public async Task<IReadOnlyCollection<Supplier>> GetAll(CancellationToken cancellationToken)
        => await reader.Read<Supplier>()
             .NotDeleted()
             .ToListAsync(cancellationToken);

        public Task<Supplier?> GetById(Guid id, CancellationToken cancellationToken)
            => reader.Read<Supplier>()
            .NotDeleted()
            .ById(id)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
