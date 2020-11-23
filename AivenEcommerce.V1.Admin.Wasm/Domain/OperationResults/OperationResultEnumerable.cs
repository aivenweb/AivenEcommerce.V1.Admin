﻿using System.Collections.Generic;
using System.Net;

using AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults.Validations;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.OperationResults
{
    public class OperationResultEnumerable<T> : OperationResult
    {
        public OperationResultEnumerable()
        {
        }

        public OperationResultEnumerable(IEnumerable<T> result)
        {
            Result = result;
            IsSuccess = true;
        }

        public IEnumerable<T> Result { get; set; }

        public static OperationResultEnumerable<T> Success(IEnumerable<T> result) =>

            new()
            {
                IsSuccess = true,
                Result = result,
                Status = HttpStatusCode.OK
            };


        public static new OperationResultEnumerable<T> Success() => Success(default);

        public static new OperationResultEnumerable<T> Fail(ValidationResult validations) =>

             new()
             {
                 Validations = validations,
                 Status = HttpStatusCode.BadRequest,
                 IsSuccess = false
             };


        public static new OperationResultEnumerable<T> Error(ValidationResult validations) =>

             new()
             {
                 Validations = validations,
                 Status = HttpStatusCode.InternalServerError,
                 IsSuccess = false
             };

    }
}
