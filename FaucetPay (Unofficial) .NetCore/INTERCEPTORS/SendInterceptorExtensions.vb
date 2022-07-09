Imports System.Runtime.CompilerServices

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
    Public Module SendInterceptorExtensions
        <Extension()>
        Public Async Function ThrowInterceptorErrorsAsync(Of T As IInterceptor)(ByVal interceptors As IEnumerable(Of T), ByVal checker As Func(Of T, Task(Of InterceptorResult))) As Task
            For Each interceptor In interceptors
                Dim result = Await checker(interceptor).ConfigureAwait(False)
                If Not result.IsSuccess Then Throw New InterceptorFailException(result, interceptor.GetType())
            Next
        End Function

        <Extension()>
        Public Function ThrowInterceptorErrors(Of T As IInterceptor)(ByVal interceptors As IEnumerable(Of T), ByVal checker As Func(Of T, InterceptorResult))
            For Each interceptor In interceptors
                Dim result = checker(interceptor)
                If Not result.IsSuccess Then Throw New InterceptorFailException(result, interceptor.GetType())
            Next
            Return Nothing
        End Function
    End Module
End Namespace
