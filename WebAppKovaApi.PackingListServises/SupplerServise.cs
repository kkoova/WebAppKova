using AutoMapper;
using WebApiKovaApi.Repositories.Contracts;
using WebAppKovaApi.Context.Contracts;
using WebAppKovaApi.Contracts;
using WebAppKovaApi.PackingListServises.Contracts;
using WebAppKovaApi.PackingListServises.Contracts.Models;
using WebAppKovaApi.PackingListServises.Exceptions;

namespace WebAppKovaApi.PackingListServises
{
    /// <inheritdoc cref="ISupplierServise"/>
    public class SupplerServise : ISupplierServise
    {
        private readonly IMapper mapper;
        private readonly ISupplierReadRepository supplierReadRepository;
        private readonly ISupplierWriteRepository supplierWriteRepository;
        private readonly IUnitOfWork unitOfWork;

        public SupplerServise(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ISupplierWriteRepository supplierWriteRepository, 
            ISupplierReadRepository supplierReadRepository)
        {
            this.mapper = mapper;
            this.supplierWriteRepository = supplierWriteRepository;
            this.supplierReadRepository = supplierReadRepository;
            this.unitOfWork = unitOfWork;
        }

        async Task<Guid> ISupplierServise.Add(AddSupplierModel model, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Supplier>(model);
            supplierWriteRepository.Add(entity);
            await unitOfWork.CommitAsync(cancellationToken);
            return entity.Id;
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await supplierReadRepository.GetById(id, cancellationToken);

            if (result == null)
            {
                throw new NotFoundSupplierException(id);
            }

            supplierWriteRepository.Delete(result);
            await unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task Edit(SupplierModel model, CancellationToken cancellationToken)
        {
            var result = await supplierReadRepository.GetById(model.Id, cancellationToken);

            if (result == null)
            {
                throw new NotFoundSupplierException(model.Id);
            }
            result.Name = model.Name;
            result.Description = model.Description;

            supplierWriteRepository.Update(result);
            await unitOfWork.CommitAsync(cancellationToken);
        }

        public async Task<SupplierModel> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await supplierReadRepository.GetById(id, cancellationToken);

            return result == null
                ? throw new NotFoundSupplierException(id)
                : mapper.Map<SupplierModel>(result);
        }

        public async Task<IReadOnlyCollection<SupplierModel>> GetAll(CancellationToken cancellationToken)
        {
            var items = await supplierReadRepository.GetAll(cancellationToken);
            var result = mapper.Map<IReadOnlyCollection<SupplierModel>>(items);
            return result;
        }
    }
}
