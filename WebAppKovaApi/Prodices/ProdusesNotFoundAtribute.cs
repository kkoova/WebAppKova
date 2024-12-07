using Microsoft.AspNetCore.Mvc;
using WebAppKovaApi.Models;

namespace WebAppKovaApi.Prodices
{
    /// <summary>
    /// Ошибка не найденого обьекта
    /// </summary>
    public class ProdusesNotFoundAtribute : ProducesResponseTypeAttribute
    {
        public ProdusesNotFoundAtribute()
            : base(typeof(ErrorModel), StatusCodes.Status404NotFound)
        {

        }
    }
}
