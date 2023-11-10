using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Domain.Model
{
    public class CustomHttpException : Exception
    {
        public int StatusCode { get; }
        public string CustomMessage { get; }

        public CustomHttpException(string message, int statusCode, string customMessage)
            : base(message)
        {
            StatusCode = statusCode;
            CustomMessage = customMessage;
        }
    }
}
