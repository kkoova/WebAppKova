using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data;
using WebAppKovaApi.Models;
using WebAppKovaApi.PackingListServises.Exceptions;

namespace WebAppKovaApi.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomExeptionFilter : IExceptionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is SupplierException exception)
            {
                switch (exception)
                {
                    case NotFoundSupplierException supplierException:
                        SetHandledException(context, new NotFoundObjectResult(new ErrorModel
                        {
                            Message = exception.Message,
                            ErrorCode = StatusCodes.Status404NotFound,
                        }));
                        break;
                    case ValidateSupplayerException validateSupplayer:
                        SetHandledException(context, new ObjectResult(new ErrorValidationModel
                        {
                            Errors = validateSupplayer.Errors.Select(x =>
                                new KeyValuePair<string, string>(x.Item1, x.Item2))
                        })
                        {
                            StatusCode = StatusCodes.Status406NotAcceptable,
                        });
                        break;
                    case OperationSupplierException operationSupplierException:
                        SetHandledException(context, new ConflictObjectResult(new ErrorModel
                        {
                            Message = exception.Message,
                            ErrorCode = StatusCodes.Status409Conflict,
                        }));
                        break;
                    default:
                        SetHandledException(context, new BadRequestObjectResult(new ErrorModel
                        {
                            Message = exception.Message,
                            ErrorCode = StatusCodes.Status400BadRequest,
                        }));
                        break;
                }
            }
        }

        private static void SetHandledException(ExceptionContext context, ObjectResult result)
        {
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
