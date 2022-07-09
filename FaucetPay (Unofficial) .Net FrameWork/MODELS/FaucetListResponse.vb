Imports System.Runtime.Serialization
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Models
    ''' <summary>
    ''' *** MADE FOR GITHUB ***
    ''' WRITTEN BY ROMULO MEIRELLES.
    ''' UPWORK: https://www.upwork.com/freelancers/~01fcbc5039ac5766b4
    ''' CONTACT WHATSAPP: https://wa.me/message/KWIS3BYO6K24N1
    ''' CONTACT TELEGRAM: https://t.me/Romulo_Meirelles
    ''' GITHUB: https://github.com/Romulo-Meirelles
    ''' DISCORD: đąяķňέs§¢øďε#2786
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    <DataContract>
    Public Class FaucetListResponse
        Inherits FaucetPayResponse

        <JsonProperty("list_data")>
        Public Property DataList As IDictionary(Of String, Normal)

        Public Class Normal

            <JsonProperty("BCH")>
            Public Property BitCoin_Cash As IDictionary(Of String, Items)

            <JsonProperty("BNB")>
            Public Property Binance As IDictionary(Of String, Items)

            <JsonProperty("BTC")>
            Public Property BitCoin As IDictionary(Of String, Items)

            <JsonProperty("DASH")>
            Public Property Dash As IDictionary(Of String, Items)

            <JsonProperty("DGB")>
            Public Property DigiByte As IDictionary(Of String, Items)

            <JsonProperty("DOGE")>
            Public Property DogeCoin As IDictionary(Of String, Items)

            <JsonProperty("ETH")>
            Public Property Ethereum As IDictionary(Of String, Items)

            <JsonProperty("FEY")>
            Public Property Feyorra As IDictionary(Of String, Items)

            <JsonProperty("LTC")>
            Public Property LiteCoin As IDictionary(Of String, Items)

            <JsonProperty("SOL")>
            Public Property Solana As IDictionary(Of String, Items)

            <JsonProperty("TRX")>
            Public Property Tron As IDictionary(Of String, Items)

            <JsonProperty("USDT")>
            Public Property Tether As IDictionary(Of String, Items)

            <JsonProperty("ZEC")>
            Public Property ZCash As IDictionary(Of String, Items)
        End Class

        Public Class Items
            <JsonProperty("id")>
            Public Property Id As Integer

            <JsonProperty("name")>
            Public Property Name As String

            <JsonProperty("url")>
            Public Property URL As String

            <JsonProperty("owner_id")>
            Public Property Owner_Id As Integer

            <JsonProperty("owner_name")>
            Public Property Owner_Name As String

            <JsonProperty("currency")>
            Public Property Currency_Symbol As String

            <JsonProperty("timer_in_minutes")>
            Public Property Timer_In_Minutes As Integer

            <JsonProperty("reward")>
            Public Property Reward As Integer

            <JsonProperty("is_enabled")>
            Public Property Is_Enabled As Integer

            <JsonProperty("creation_date")>
            Public Property Creation_Date As Integer

            <JsonProperty("category")>
            Public Property Category As String

            <JsonProperty("paid_today")>
            Public Property Paid_Today As String

            <JsonProperty("total_users_paid")>
            Public Property Total_Users_Paid As Integer

            <JsonProperty("active_users")>
            Public Property Active_Users As Integer

            <JsonProperty("balance")>
            Public Property Balance As String

            <JsonProperty("health")>
            Public Property Health As Integer
        End Class
    End Class
End Namespace


