using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Exceptions
{

    /// <summary>
    /// *** MADE FOR GITHUB ***
    /// WRITTEN BY ROMULO MEIRELLES.
    /// UPWORK: https://www.upwork.com/freelancers/~01fcbc5039ac5766b4
    /// CONTACT WHATSAPP: https://wa.me/message/KWIS3BYO6K24N1
    /// CONTACT TELEGRAM: https://t.me/Romulo_Meirelles
    /// GITHUB: https://github.com/Romulo-Meirelles
    /// DISCORD: đąяķňέs§¢øďε#2786
    /// </summary>
    /// <remarks></remarks>
    public partial class FaucetPayException : Exception
    {
        public int StatusCode { get; private set; }
        public FaucetPayException()
        {
        }

        public FaucetPayException(int statusCode)
        {
            StatusCode = statusCode;
        }

        public FaucetPayException(string message) : base(message)
        {

        }
        public FaucetPayException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
        public FaucetPayException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public FaucetPayException(string message, int statusCode, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
        protected FaucetPayException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public bool HasError(FaucetPayError error)
        {
            return StatusCode == (int)error;
        }
        public bool HasError(FaucetPayError error, params FaucetPayError[] errors)
        {
            return errors.Concat(new[] { error }).Any(e => StatusCode == (int)e);
        }
    }

    public enum FaucetPayError
    {
        AccessDenied = 401,
        InsufficientFunds = 402,
        InvalidApiKey = 403,
        NotFound = 404,
        InvalidPaymentAmount = 405,
        InvalidCurrency = 410,
        SendLimitReached = 450,
        InvalidAddress = 456,
        BlackListedAPI = 457
    }
}