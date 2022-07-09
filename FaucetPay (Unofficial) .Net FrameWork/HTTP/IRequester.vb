Imports FaucetPay.Models
Imports FaucetPay.Config

Namespace Http
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
    Public Interface IRequester
        ReadOnly Property Configuration As ApiConfig
        Function PostAsync(Of T As FaucetPayResponse)(ByVal resource As String, ByVal Optional parameters As Dictionary(Of String, String) = Nothing, ByVal Optional noThrow As Boolean = False) As Task(Of T)
    End Interface
End Namespace
