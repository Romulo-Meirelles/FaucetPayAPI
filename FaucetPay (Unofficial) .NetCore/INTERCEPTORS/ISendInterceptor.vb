
Namespace Interceptors
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
    Public Interface IInterceptor
    End Interface
    Public Interface ISendInterceptor
        Inherits IInterceptor
        Function CheckSendRequestAsync(ByVal satoshiAmount As Long, ByVal [to] As String, ByVal currency As String, ByVal isReferral As Boolean) As Task(Of InterceptorResult)
    End Interface
End Namespace
