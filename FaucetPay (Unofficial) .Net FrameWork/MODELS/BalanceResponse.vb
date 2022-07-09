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
    Public Class BalanceResponse
        Inherits FaucetPayResponse
        <JsonProperty("currency")>
        Public Property Currency As String

        <JsonProperty("balance")>
        Public Property SatoshiBalance As Long

        <JsonProperty("balance_bitcoin")>
        Public Property ActualBalance As Decimal

        Public Overrides Function ToString() As String
            Return $"Faucet {Currency} balance: {ActualBalance}{Currency}"
        End Function
    End Class
End Namespace
