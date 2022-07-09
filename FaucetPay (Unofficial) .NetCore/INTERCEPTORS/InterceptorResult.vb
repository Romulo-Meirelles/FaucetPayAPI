
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
    Public Class InterceptorResult
        Public ReadOnly Property IsSuccess As Boolean
        Public ReadOnly Property Message As String

        Private Sub New(ByVal isSuccess As Boolean, ByVal message As String)
            Me.IsSuccess = isSuccess
            Me.Message = message
        End Sub
        Public Shared Function Success() As InterceptorResult
            Return New InterceptorResult(True, Nothing)
        End Function

        Public Shared Function Fail(ByVal message As String) As InterceptorResult
            Return New InterceptorResult(False, message)
        End Function

        Public Shared Function IfFailure(ByVal failed As Boolean, ByVal message As String) As InterceptorResult
            If failed Then Return Fail(message)
            Return Success()
        End Function

        Public Shared Function IfFailure(ByVal failed As Boolean, ByVal message As Func(Of String)) As InterceptorResult
            If failed Then Return Fail(message())
            Return Success()
        End Function
    End Class
End Namespace
