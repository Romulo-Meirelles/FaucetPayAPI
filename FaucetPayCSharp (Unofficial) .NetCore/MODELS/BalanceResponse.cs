using Newtonsoft.Json;

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
    public partial class BalanceResponse : FaucetPayResponse
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("balance")]
        public long SatoshiBalance { get; set; }

        [JsonProperty("balance_bitcoin")]
        public decimal ActualBalance { get; set; }

        public override string ToString()
        {
            return $"Faucet {Currency} balance: {ActualBalance}{Currency}";
        }
    }
}