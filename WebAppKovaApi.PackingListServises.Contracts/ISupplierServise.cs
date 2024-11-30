using WebAppKovaApi.PackingListServises.Contracts.Models;

namespace WebAppKovaApi.PackingListServises.Contracts
{
    /// <summary>
    /// Сервис по работе с постащиками
    /// </summary>
    public interface ISupplierServise
    {
        /// <summary>
        /// 
        /// </summary>
        Task<IReadOnlyCollection<SupplierModel>> GetAll(CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        Task<IReadOnlyCollection<SupplierModel>> Get(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        Task<Guid> Add(AddSupplierModel model, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        Task Edit(SupplierModel model, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        Task<IReadOnlyCollection<SupplierModel>> Delete(Guid id, CancellationToken cancellationToken);
    }
}
