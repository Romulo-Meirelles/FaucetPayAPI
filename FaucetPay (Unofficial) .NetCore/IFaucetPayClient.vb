Imports FaucetPay.Models

Namespace IPayClient
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
    Public Interface IFaucetPayClient
        Inherits IDisposable
#Region "Async Method"
        Function GetBalanceAsync(ByVal Currency As String) As Task(Of BalanceResponse)
        Function GetCurrenciesAsync() As Task(Of CurrenciesResponse)
        Function FaucetListAsync(ByVal Currency As String) As Task(Of IDictionary(Of String, String()))
        Function CheckAddressBooleanAsync(ByVal Address As String, ByVal Currency As String) As Task(Of Boolean)
        Function SendAsync(ByVal SatoshiAmount As Long, ByVal [To] As String, ByVal Currency As String, ByVal Optional IsReferral As Boolean = False) As Task(Of SendResponse)
        Function GetPayoutsAsync(ByVal TransactionCount As Integer, ByVal Currency As String) As Task(Of IEnumerable(Of Payout))
        Function CheckAddressAsync(ByVal Address As String, ByVal Currency As String) As Task(Of CheckAddressResponse)
#End Region

#Region "Simple Method"
        Function GetBalance(ByVal Currency As String) As BalanceResponse
        Function GetCurrencies() As CurrenciesResponse
        Function FaucetList(ByVal Currency As String) As IDictionary(Of String, String())
        Function CheckAddressBoolean(ByVal Address As String, ByVal Currency As String) As Boolean
        Function Send(ByVal SatoshiAmount As Long, ByVal [To] As String, ByVal Currency As String, ByVal Optional IsReferral As Boolean = False) As SendResponse
        Function GetPayouts(ByVal TransactionCount As Integer, ByVal Currency As String) As IEnumerable(Of Payout)
        Function CheckAddress(ByVal Address As String, ByVal Currency As String) As CheckAddressResponse
#End Region
    End Interface
End Namespace
