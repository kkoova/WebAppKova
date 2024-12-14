using WebApiKovaApi.Common.Abstractions;
using WebAppKovaApi.Context.Contracts;
using WebAppKovaApi.Contracts;

namespace WebApiKovaApi.Repositories
{
    public interface SupplierWriteRepository : BaseWriteRepository<Supplier>
    {
        public SupplierWriteRepository(IWriter writer,
            IDataTimeProvider dataTimeProvider)
            : base (writer, dataTimeProvider)
        {

        }
    }
}
