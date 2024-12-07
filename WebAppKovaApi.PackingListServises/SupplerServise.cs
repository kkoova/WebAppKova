using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAppKovaApi.Contracts;
using WebAppKovaApi.PackingListServises.Contracts;
using WebAppKovaApi.PackingListServises.Contracts.Models;
using WebAppKovaApi.PackingListServises.Infrastructure;

namespace WebAppKovaApi.PackingListServises
{
    /// <inheritdoc cref="ISupplierServise"/>
    public class SupplerServise : ISupplierServise
    {
        private readonly  Context.AppContext appContext;
        private readonly IMapper mapper;

        public SupplerServise(Context.AppContext appContext,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.appContext = appContext;
        }

        async Task<Guid> ISupplierServise.Add(AddSupplierModel model, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Supplier>(model);

            appContext.Suppliers.Add(entity);
            await appContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await appContext.Suppliers
                .FirstOrDefaultAsync(
                x => x.Id == id && x.Deleted == null,
                cancellationToken);
            if (result == null)
            {
                throw new NotFoundSupplierException(id);
            }

            result.Deleted = DateTimeOffset.Now;
            appContext.Suppliers.Update(result);
            await appContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Edit(SupplierModel model, CancellationToken cancellationToken)
        {
            var result = await appContext.Suppliers.FirstOrDefaultAsync(
                x => x.Id == model.Id && x.Deleted == null,
                cancellationToken);
            if (result == null)
            {
                throw new NotFoundSupplierException(model.Id);
            }
            result.Name = model.Name;
            result.Description = model.Description;
            result.UpdatedAt = DateTimeOffset.Now;

            appContext.Suppliers.Update(result);
            await appContext.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        public async Task<SupplierModel> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await appContext.Suppliers
                .Where(x => x.Id == id && x.Deleted == null)
                .FirstOrDefaultAsync(cancellationToken);

            return result == null
                ? throw new NotFoundSupplierException(id)
                : mapper.Map<SupplierModel>(result);
        }

        public async Task<SupplierModel> GetAll(CancellationToken cancellationToken)
        {
            var items = await appContext.Suppliers
                .Where(x => x.Deleted == null)
                .ToListAsync(cancellationToken);

            var result = mapper.Map<IReadOnlyCollection<SupplierModel>>(items);
            return result;
        }
    }
}
