using System.Net;

using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults.Validations;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults
{
    public class OperationResult
    {
        public HttpStatusCode Status { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public ValidationResult Validations { get; set; }

        public static OperationResult Success() =>

            new OperationResult
            {
                Status = HttpStatusCode.OK,
                IsSuccess = true
            };


        public static OperationResult Fail() =>

             new OperationResult
             {
                 Status = HttpStatusCode.BadRequest,
                 IsSuccess = false
             };


        public static OperationResult Error() =>

             new OperationResult
             {
                 Status = HttpStatusCode.InternalServerError,
                 IsSuccess = false
             };

        public static OperationResult Fail(ValidationResult validations) =>

             new OperationResult
             {
                 Validations = validations,
                 Status = HttpStatusCode.BadRequest,
                 IsSuccess = false
             };


        public static OperationResult Error(ValidationResult validations) =>

             new OperationResult
             {
                 Validations = validations,
                 Status = HttpStatusCode.InternalServerError,
                 IsSuccess = false
             };

    }
}
