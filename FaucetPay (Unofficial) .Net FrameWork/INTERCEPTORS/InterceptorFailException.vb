Imports System.Runtime.Serialization

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
    Public Class InterceptorFailException
        Inherits Exception
        Public ReadOnly Property InterceptorType As Type
        Public ReadOnly Property Result As InterceptorResult

        Public Sub New()
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal result As InterceptorResult, ByVal Optional interceptorType As Type = Nothing)
            MyBase.New(message)
            Me.InterceptorType = interceptorType
            Me.Result = result
        End Sub
        Public Sub New(ByVal result As InterceptorResult, ByVal Optional interceptorType As Type = Nothing)
            MyBase.New(result.Message)
            Me.InterceptorType = interceptorType
            Me.Result = result
        End Sub
        Public Sub New(ByVal message As String, ByVal innerException As Exception, ByVal Optional interceptorType As Type = Nothing)
            MyBase.New(message, innerException)
            Me.InterceptorType = interceptorType
        End Sub
        Public Sub New(ByVal message As String, ByVal result As InterceptorResult, ByVal innerException As Exception, ByVal Optional interceptorType As Type = Nothing)
            MyBase.New(message, innerException)
            Me.InterceptorType = interceptorType
            Me.Result = result
        End Sub
    End Class
End Namespace
