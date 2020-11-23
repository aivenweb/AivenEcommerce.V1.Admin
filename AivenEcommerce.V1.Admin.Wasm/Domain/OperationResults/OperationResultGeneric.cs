using System.Net;

using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults.Validations;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults
{
    public class OperationResult<T> : OperationResult where T : class
    {
        public OperationResult()
        {
        }

        public OperationResult(T result)
        {
            Result = result;
            IsSuccess = true;
        }

        public T Result { get; set; }

        public static OperationResult<T> Success(T result) =>
            new()
            {
                IsSuccess = true,
                Result = result,
                Status = HttpStatusCode.OK
            };



        public static new OperationResult<T> Fail(ValidationResult validations) =>

             new()
             {
                 Validations = validations,
                 Status = HttpStatusCode.BadRequest,
                 IsSuccess = false
             };


        public static OperationResult<T> NotFound(ValidationResult validations) =>

             new()
             {
                 Validations = validations,
                 Status = HttpStatusCode.NotFound,
                 IsSuccess = false
             };

        public static OperationResult<T> NotFound() =>

             new()
             {
                 Status = HttpStatusCode.NotFound,
                 IsSuccess = false
             };
    }
}
