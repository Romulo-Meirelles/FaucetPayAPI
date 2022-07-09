
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
    Public Class LimitSendInterceptor
        Implements ISendInterceptor

        Public ReadOnly Property Currency As String
        Public ReadOnly Property SatoshiLimit As Long

        <Obsolete>
        Public Sub New(ByVal currency As String, ByVal satoshiLimit As Long)
            Me.Currency = If(currency, CSharpImpl.[Throw](Of String)(New ArgumentNullException(NameOf(currency))))
            Me.SatoshiLimit = satoshiLimit
        End Sub
        Public Async Function CheckSendRequestAsync(ByVal satoshiAmount As Long, ByVal [to] As String, ByVal currency As String, ByVal isReferral As Boolean) As Task(Of InterceptorResult) Implements ISendInterceptor.CheckSendRequestAsync
            If Not Me.Currency.Equals(currency, StringComparison.OrdinalIgnoreCase) Then Return Await Task.FromResult(InterceptorResult.Success())
            Return Await Task.FromResult(InterceptorResult.IfFailure(satoshiAmount > SatoshiLimit, Function() $"The send value ({satoshiAmount} {currency} satoshi) is higher than limit ({SatoshiLimit} {currency} satoshi)."))
        End Function
        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal throw statements")>
            Shared Function [Throw](Of T)(ByVal e As Exception) As T
                Throw e
            End Function
        End Class
    End Class
End Namespace
