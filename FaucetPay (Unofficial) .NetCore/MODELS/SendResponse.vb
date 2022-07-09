Imports Newtonsoft.Json

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
    Public Class SendResponse
        Inherits FaucetPayResponse

        <JsonProperty("rate_limit_remaining")>
        Public Property RateLimitRemaining As Single?

        <JsonProperty("currency")>
        Public Property Currency As String

        <JsonProperty("balance")>
        Public Property RemainingSatoshiBalance As Long

        <JsonProperty("balance_bitcoin")>
        Public Property RemainingActualBalance As Decimal

        <JsonProperty("payout_id")>
        Public Property PayoutId As Integer

        <JsonProperty("payout_user_hash")>
        Public Property PayoutUserHash As String
    End Class
End Namespace
