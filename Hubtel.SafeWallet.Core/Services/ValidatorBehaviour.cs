using FluentValidation;
using FluentValidation.Results;
using Hubtel.SafeWallet.Core.Domain.Interfaces;
using Hubtel.SafeWallet.Core.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Services
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }
            var context = new ValidationContext<TRequest>(request);

            var errorsDictionary = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .GroupBy(
                    x => x.PropertyName,
                    x => x.ErrorMessage,
                    (propertyName, errorMessages) => new ValidationFailure()
                    {
                        PropertyName = propertyName,
                        ErrorMessage = errorMessages.FirstOrDefault(),
                    })
                .ToList();

            if (errorsDictionary.Any())
            {
                throw new CustomValidationException(errorsDictionary);
            }

            return await next();
        }
    }

}

