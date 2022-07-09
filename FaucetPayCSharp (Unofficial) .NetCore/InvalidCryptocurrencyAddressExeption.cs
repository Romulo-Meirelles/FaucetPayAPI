using System;
using Exceptions;

namespace AddressException
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
    public partial class InvalidCryptocurrencyAddressException : FaucetPayException
    {
        private const int ErrorCode = (int) FaucetPayError.InvalidAddress;
        public InvalidCryptocurrencyAddressException() : base(ErrorCode)
        {

        }
        public InvalidCryptocurrencyAddressException(string message) : base(message, ErrorCode)
        {
        }

        public InvalidCryptocurrencyAddressException(string message, Exception innerException) : base(message, ErrorCode, innerException)
        {
        }
    }
}