Imports FaucetPay.Interceptors

Namespace Config
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
    Public Class ApiConfig
        Public Property ApiKey As String
        Public Property BaseUrl As String = "https://faucetpay.io/api/v1/"
        Public Property BaseFaucetList As String = "https://faucetpay.io/api/listv1/"
        Public Property SendInterceptors As IEnumerable(Of ISendInterceptor) = Array.Empty(Of ISendInterceptor)()
        Public Sub Check()
            If String.IsNullOrEmpty(ApiKey) Then Throw New ArgumentException("The API key is missing.", NameOf(ApiConfig.ApiKey))
        End Sub
    End Class
End Namespace
