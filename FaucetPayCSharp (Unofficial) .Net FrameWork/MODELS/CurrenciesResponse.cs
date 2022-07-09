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
    public partial class CurrenciesResponse : FaucetPayResponse
    {
        [JsonProperty("currencies")]
        public IEnumerable<string> CurrenciesAbbreviations { get; set; }

        [JsonProperty("currencies_names")]
        public IEnumerable<Currency> Currencies { get; set; }

        public partial class Currency
        {
            public string Name { get; set; }
            public string Acronym { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}