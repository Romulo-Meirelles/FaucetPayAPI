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
    Public Class CurrenciesResponse
        Inherits FaucetPayResponse
        <JsonProperty("currencies")>
        Public Property CurrenciesAbbreviations As IEnumerable(Of String)

        <JsonProperty("currencies_names")>
        Public Property Currencies As IEnumerable(Of Currency)

        Public Class Currency
            Public Property Name As String
            Public Property Acronym As String

            Public Overrides Function ToString() As String
                Return Name
            End Function
        End Class
    End Class
End Namespace
