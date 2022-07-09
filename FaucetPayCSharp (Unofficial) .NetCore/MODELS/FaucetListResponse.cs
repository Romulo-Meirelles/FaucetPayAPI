using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
    [DataContract]
    public partial class FaucetListResponse : FaucetPayResponse
    {

        [JsonProperty("list_data")]
        public IDictionary<string, Normal> DataList { get; set; }

        public partial class Normal
        {

            [JsonProperty("BCH")]
            public IDictionary<string, Items> BitCoin_Cash { get; set; }

            [JsonProperty("BNB")]
            public IDictionary<string, Items> Binance { get; set; }

            [JsonProperty("BTC")]
            public IDictionary<string, Items> BitCoin { get; set; }

            [JsonProperty("DASH")]
            public IDictionary<string, Items> Dash { get; set; }

            [JsonProperty("DGB")]
            public IDictionary<string, Items> DigiByte { get; set; }

            [JsonProperty("DOGE")]
            public IDictionary<string, Items> DogeCoin { get; set; }

            [JsonProperty("ETH")]
            public IDictionary<string, Items> Ethereum { get; set; }

            [JsonProperty("FEY")]
            public IDictionary<string, Items> Feyorra { get; set; }

            [JsonProperty("LTC")]
            public IDictionary<string, Items> LiteCoin { get; set; }

            [JsonProperty("SOL")]
            public IDictionary<string, Items> Solana { get; set; }

            [JsonProperty("TRX")]
            public IDictionary<string, Items> Tron { get; set; }

            [JsonProperty("USDT")]
            public IDictionary<string, Items> Tether { get; set; }

            [JsonProperty("ZEC")]
            public IDictionary<string, Items> ZCash { get; set; }
        }

        public partial class Items
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("url")]
            public string URL { get; set; }

            [JsonProperty("owner_id")]
            public int Owner_Id { get; set; }

            [JsonProperty("owner_name")]
            public string Owner_Name { get; set; }

            [JsonProperty("currency")]
            public string Currency_Symbol { get; set; }

            [JsonProperty("timer_in_minutes")]
            public int Timer_In_Minutes { get; set; }

            [JsonProperty("reward")]
            public int Reward { get; set; }

            [JsonProperty("is_enabled")]
            public int Is_Enabled { get; set; }

            [JsonProperty("creation_date")]
            public int Creation_Date { get; set; }

            [JsonProperty("category")]
            public string Category { get; set; }

            [JsonProperty("paid_today")]
            public string Paid_Today { get; set; }

            [JsonProperty("total_users_paid")]
            public int Total_Users_Paid { get; set; }

            [JsonProperty("active_users")]
            public int Active_Users { get; set; }

            [JsonProperty("balance")]
            public string Balance { get; set; }

            [JsonProperty("health")]
            public int Health { get; set; }
        }
    }
}