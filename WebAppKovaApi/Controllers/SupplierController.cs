using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppKovaApi.Contracts;
using WebAppKovaApi.Models;
using WebAppKovaApi.PackingListServises.Contracts;

namespace WebAppKovaApi.Controllers
{
    /// <summary>
    /// CRUD 
    /// </summary>
    /// <returns></returns>
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly Context.AppContext appContext;
        private readonly IMapper mapper;
        private readonly ISupplierServise supplierServise;

        /// <summary>
        /// 
        /// </summary>
        public SupplierController(
            Context.AppContext appContext, 
            IMapper mapper, 
            ISupplierServise supplierServise
            )
        {
            this.supplierServise = supplierServise;
            this.appContext = appContext;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получает список поставщиков
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<SupplierApiModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var items = await appContext.Suppliers
                .Where(x => x.Deleted == null)
                .ToListAsync(cancellationToken);

            var result = mapper.Map<IReadOnlyCollection<SupplierApiModel>>(items);
            return Ok(result);
        }

        /// <summary>
        /// Получает список поставщика по идетентификатору
        /// </summary>
        /// api/supplier/guid
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(SupplierApiModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await appContext.Suppliers
                .Where(x => x.Id == id && x.Deleted == null)
                .Select(x => new SupplierApiModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                })
                .FirstOrDefaultAsync(cancellationToken);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<SupplierApiModel>(result));
        }

        /// <summary>
        /// Добавление поставщика
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Add(AddSupplierApiModel model, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Supplier>(model);

            appContext.Suppliers.Add(entity);
            await appContext.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Редактирование поставщика с указанным идетентификатором
        /// </summary>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Edit(
            [FromRoute] Guid id,
            [FromBody] AddSupplierApiModel model,
            CancellationToken cancellationToken)
        {
            var result = await appContext.Suppliers.FirstOrDefaultAsync(
                x => x.Id == id && x.Deleted == null,
                cancellationToken);
            if (result == null)
            {
                return NotFound();
            }
            result.Name = model.Name;
            result.Description = model.Description;
            result.UpdatedAt = DateTimeOffset.Now;

            appContext.Suppliers.Update(result);
            await appContext.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Удаление поставщика с указанным идетентификатором
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(
            Guid id,
            CancellationToken cancellationToken)
        {
            var result = await appContext.Suppliers.FirstOrDefaultAsync(
                x => x.Id == id && x.Deleted == null,
                cancellationToken);
            if (result == null)
            {
                return NotFound();
            }

            result.Deleted = DateTimeOffset.Now;
            appContext.Suppliers.Update(result);
            await appContext.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
