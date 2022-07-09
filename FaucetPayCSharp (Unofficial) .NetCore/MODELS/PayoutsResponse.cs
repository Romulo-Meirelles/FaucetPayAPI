using System;
using System.Collections.Generic;
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
    internal partial class PayoutsResponse : FaucetPayResponse
    {

        [JsonProperty("rewards")]
        public IEnumerable<Payout> Payouts { get; set; }
    }

    public partial class Payout
    {
        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("amount")]
        public long SatoshiAmount { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}