using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Domain.Model
{
    public class CustomValidationException : ValidationException
    {
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; }
        public CustomValidationException(IEnumerable<ValidationFailure> errors) : base(errors)
        {
            ValidationErrors = errors;
        }
    }

    public class ValidationError
    {
        public string PropertyName { get; }
        public string ErrorMessage { get; }

        public ValidationError(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
    }
}
