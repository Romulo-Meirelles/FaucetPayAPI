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
    Friend Class PayoutsResponse
        Inherits FaucetPayResponse

        <JsonProperty("rewards")>
        Public Property Payouts As IEnumerable(Of Payout)
    End Class

    Public Class Payout
        <JsonProperty("to")>
        Public Property [To] As String

        <JsonProperty("amount")>
        Public Property SatoshiAmount As Long

        <JsonProperty("date")>
        Public Property [Date] As Date
    End Class
End Namespace
