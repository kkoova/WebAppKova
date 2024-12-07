using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAppKovaApi.Models;
using WebAppKovaApi.PackingListServises.Contracts;
using WebAppKovaApi.PackingListServises.Contracts.Models;

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
        private readonly IMapper mapper;
        private readonly ISupplierServise supplierServise;

        /// <summary>
        /// ctor
        /// </summary>
        public SupplierController(IMapper mapper, 
            ISupplierServise supplierServise)
        {
            this.supplierServise = supplierServise;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получает список поставщиков
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<SupplierApiModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var items = await supplierServise.GetAll(cancellationToken);
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
            var result = await supplierServise.Get(id, cancellationToken);
            return Ok(mapper.Map<>);
        }

        /// <summary>
        /// Добавление поставщика
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Add(AddSupplierApiModel model, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<AddSupplierModel>(model);
            await supplierServise.Add(entity, cancellationToken);
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
            [FromBody] AddSupplierApiModel request,
            CancellationToken cancellationToken)
        {
            var model = mapper.Map<SupplierModel>(request);
            model.Id = id;

            await supplierServise.Edit(model, cancellationToken);
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

            await supplierServise.Delete(id, cancellationToken);
            return NoContent();
        }
    }
}
