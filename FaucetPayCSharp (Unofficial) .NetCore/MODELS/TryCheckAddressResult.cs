
namespace Models
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
    public sealed partial class TryCheckAddressResult
    {
        internal TryCheckAddressResult(string address, string currency, bool isValidAddress, CheckAddressResponse response)
        {
            Address = address;
            Currency = currency;
            IsValidAddress = isValidAddress;
            Response = response;
        }

        public string Address { get; private set; }
        public string Currency { get; set; }
        public bool IsValidAddress { get; private set; }
        public CheckAddressResponse Response { get; private set; }
    }
}