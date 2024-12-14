using WebAppKovaApi.Contracts;

namespace WebApiKovaApi.Repositories.Contracts
{
    public interface ISupplierReadRepository
    {
        /// <summary>
        /// Получает <see cref="Supplier"/> по id
        /// </summary>
        Task<Supplier?> GetById(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получает список всех действующих <see cref="Supplier"/>
        /// </summary>
        Task<List<Supplier>> GetAll(CancellationToken cancellationToken);
    }
}
