using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppKovaApi.PackingListServises.Exceptions
{
    /// <summary>
    /// Ошибка выполнение опрерации
    /// </summary>
    public class OperationSupplierException : SupplierException
    {
        /// <summary>
        /// ctor
        /// </summary>
        public OperationSupplierException(string message) : base(message) 
        {

        }
    }
}
