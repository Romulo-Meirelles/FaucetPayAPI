Imports System.Runtime.Serialization

Namespace Exceptions

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
    Public Class FaucetPayException
        Inherits Exception
        Public ReadOnly Property StatusCode As Integer
        Public Sub New()
        End Sub

        Public Sub New(ByVal statusCode As Integer)
            Me.StatusCode = statusCode
        End Sub

        Public Sub New(ByVal message As String)
            MyBase.New(message)

        End Sub
        Public Sub New(ByVal message As String, ByVal statusCode As Integer)
            MyBase.New(message)
            Me.StatusCode = statusCode
        End Sub
        Public Sub New(ByVal message As String, ByVal innerException As Exception)
            MyBase.New(message, innerException)
        End Sub
        Public Sub New(ByVal message As String, ByVal statusCode As Integer, ByVal innerException As Exception)
            MyBase.New(message, innerException)
            Me.StatusCode = statusCode
        End Sub
        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub

        Public Function HasError(ByVal [error] As FaucetPayError) As Boolean
            Return StatusCode = [error]
        End Function
        Public Function HasError(ByVal [error] As FaucetPayError, ParamArray errors As FaucetPayError()) As Boolean
            Return errors.Concat({[error]}).Any(Function(e) StatusCode = e)
        End Function
    End Class

    Public Enum FaucetPayError
        AccessDenied = 401
        InsufficientFunds = 402
        InvalidApiKey = 403
        NotFound = 404
        InvalidPaymentAmount = 405
        InvalidCurrency = 410
        SendLimitReached = 450
        InvalidAddress = 456
        BlackListedAPI = 457
    End Enum
End Namespace
