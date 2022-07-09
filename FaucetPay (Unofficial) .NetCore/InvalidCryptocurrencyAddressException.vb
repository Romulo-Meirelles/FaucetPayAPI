Imports FaucetPay.Exceptions
Namespace AddressException
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
    Public Class InvalidCryptocurrencyAddressException
        Inherits FaucetPayException
        Private Const ErrorCode As Integer = CInt(FaucetPayError.InvalidAddress)
        Public Sub New()
            MyBase.New(ErrorCode)

        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message, ErrorCode)
        End Sub

        Public Sub New(ByVal message As String, ByVal innerException As Exception)
            MyBase.New(message, ErrorCode, innerException)
        End Sub
    End Class
End Namespace
