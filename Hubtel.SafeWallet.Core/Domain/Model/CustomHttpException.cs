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

        public CustomHttpException(string customMessage, int statusCode) : base(customMessage)
        {
            StatusCode = statusCode;
            CustomMessage = customMessage;
        }
    }
}
