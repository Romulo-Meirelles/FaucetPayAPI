Imports System.Net.Http
Imports FaucetPay.Config
Imports FaucetPay.Http
Imports FaucetPay.Interceptors
Imports FaucetPay.Exceptions
Imports FaucetPay.IPayClient
Imports FaucetPay.AddressException
Imports FaucetPay.Models

Namespace FaucetPayClient
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
    Public Class FaucetPayClient : Implements IFaucetPayClient

        Public Const Bitcoin As String = "BTC"
        Public Const BitcoinCash As String = "BCH"
        Public Const Binance_BEP20 As String = "BNB"
        Public Const Ethereum As String = "ETH"
        Public Const Litecoin As String = "LTC"
        Public Const Dogecoin As String = "DOGE"
        Public Const Dash As String = "DASH"
        Public Const DigiByte As String = "DBG"
        Public Const Feyorra As String = "FEY"
        Public Const Solana As String = "SOL"
        Public Const Tron As String = "TRX"
        Public Const Tether_TRC20 As String = "USDT"
        Public Const ZCash As String = "ZEC"

        Private ReadOnly _Requester As IRequester
        Public Sub New(ByVal Requester As IRequester)
            _Requester = Requester
        End Sub

        Public Shared Function Create(ByVal Config As ApiConfig, ByVal Optional Client As HttpClient = Nothing) As FaucetPayClient
            Dim Requester = HttpClientRequester.Create(Config, Client)
            Return New FaucetPayClient(Requester)
        End Function

#Region " Async Method "
        Public Async Function SendAsync(ByVal SatoshiAmount As Long, ByVal [To] As String, ByVal Currency As String, ByVal Optional IsReferral As Boolean = False) As Task(Of SendResponse) Implements IFaucetPayClient.SendAsync
            Await _Requester.Configuration.SendInterceptors.ThrowInterceptorErrorsAsync(Function(i) i.CheckSendRequestAsync(SatoshiAmount, [To], Currency, IsReferral))
            Return Await _Requester.PostAsync(Of SendResponse)("send", New Dictionary(Of String, String) From {{"amount", SatoshiAmount.ToString()}, {"to", [To]}, {"currency", Currency}, {"referral", If(IsReferral, "true", "false")}}).ConfigureAwait(False)
        End Function
        Public Async Function GetPayoutsAsync(TransactionCount As Integer, ByVal Currency As String) As Task(Of IEnumerable(Of Payout)) Implements IFaucetPayClient.GetPayoutsAsync
            If TransactionCount < 0 OrElse TransactionCount > 100 Then Throw New ArgumentOutOfRangeException($"The transaction count is out of range (0-100), got {TransactionCount}.", NameOf(TransactionCount))
            Return (Await _Requester.PostAsync(Of PayoutsResponse)("payouts", New Dictionary(Of String, String) From {{"currency", Currency}, {"count", TransactionCount.ToString()}}).ConfigureAwait(False)).Payouts
        End Function

        Public Async Function GetBalanceAsync(ByVal Currency As String) As Task(Of BalanceResponse) Implements IFaucetPayClient.GetBalanceAsync
            Return Await _Requester.PostAsync(Of BalanceResponse)("balance", New Dictionary(Of String, String) From {{"currency", Currency}}).ConfigureAwait(False)
        End Function

        Public Async Function GetCurrenciesAsync() As Task(Of CurrenciesResponse) Implements IFaucetPayClient.GetCurrenciesAsync
            Return Await _Requester.PostAsync(Of CurrenciesResponse)("currencies").ConfigureAwait(False)
        End Function

        Public Async Function FaucetListAsync(Currency As String) As Task(Of IDictionary(Of String, String())) Implements IFaucetPayClient.FaucetListAsync
            Dim Received = Await _Requester.PostAsync(Of FaucetListResponse)("faucetlist").ConfigureAwait(False)
            Dim MyList = New Dictionary(Of String, String())
            Dim obj As Object = Nothing
            If Currency = "BCH" Then
                obj = Received.DataList.Item("normal").BitCoin_Cash
            ElseIf Currency = "BNB" Then
                obj = Received.DataList.Item("normal").Binance
            ElseIf Currency = "BTC" Then
                obj = Received.DataList.Item("normal").BitCoin
            ElseIf Currency = "DASH" Then
                obj = Received.DataList.Item("normal").Dash
            ElseIf Currency = "DGB" Then
                obj = Received.DataList.Item("normal").DigiByte
            ElseIf Currency = "DOGE" Then
                obj = Received.DataList.Item("normal").DogeCoin
            ElseIf Currency = "ETH" Then
                obj = Received.DataList.Item("normal").Ethereum
            ElseIf Currency = "FEY" Then
                obj = Received.DataList.Item("normal").Feyorra
            ElseIf Currency = "LTC" Then
                obj = Received.DataList.Item("normal").LiteCoin
            ElseIf Currency = "SOL" Then
                obj = Received.DataList.Item("normal").Solana
            ElseIf Currency = "TRX" Then
                obj = Received.DataList.Item("normal").Tron
            ElseIf Currency = "USDT" Then
                obj = Received.DataList.Item("normal").Tether
            ElseIf Currency = "ZEC" Then
                obj = Received.DataList.Item("normal").ZCash
            End If

            For i = 0 To obj.Count - 1
                Dim ID = obj.Item(i).Id.ToString
                MyList.Add(ID, {obj.Item(i).Id.ToString,
                           obj.Item(i).Name.ToString,
                           obj.Item(i).URL.ToString,
                           obj.Item(i).Owner_Id.ToString,
                           obj.Item(i).Owner_Name.ToString,
                           obj.Item(i).Currency_Symbol.ToString,
                           obj.Item(i).Timer_In_Minutes.ToString,
                           obj.Item(i).Reward.ToString,
                           obj.Item(i).Is_Enabled.ToString,
                           obj.Item(i).Creation_Date.ToString,
                           obj.Item(i).Category.ToString,
                           obj.Item(i).Paid_Today.ToString,
                           obj.Item(i).Total_Users_Paid.ToString,
                           obj.Item(i).Active_Users.ToString,
                           obj.Item(i).Balance.ToString,
                           obj.Item(i).Health.ToString})
            Next

            Return MyList
        End Function

        Public Async Function CheckAddressBooleanAsync(ByVal Address As String, ByVal Currency As String) As Task(Of Boolean) Implements IFaucetPayClient.CheckAddressBooleanAsync
            Dim result = Await CheckAddressRequestAsync(Address, Currency, True).ConfigureAwait(False)
            If result.Status <> 200 Then
                Return False
            Else
                Return True
            End If
        End Function

        Public Async Function CheckAddressAsync(ByVal Address As String, ByVal Currency As String) As Task(Of CheckAddressResponse) Implements IFaucetPayClient.CheckAddressAsync
            Try
                Return Await CheckAddressRequestAsync(Address, Currency).ConfigureAwait(False)
            Catch e As FaucetPayException When e.HasError(FaucetPayError.InvalidAddress)
                Throw New InvalidCryptocurrencyAddressException(e.Message, e)
            End Try
        End Function

        Private Async Function CheckAddressRequestAsync(ByVal Address As String, ByVal Currency As String, ByVal Optional NoThrow As Boolean = False) As Task(Of CheckAddressResponse)
            Return Await _Requester.PostAsync(Of CheckAddressResponse)("checkaddress", New Dictionary(Of String, String) From {{"address", Address}, {"currency", Currency}}, NoThrow)
        End Function
#End Region

#Region "Simple Method "
        Public Function Send(ByVal SatoshiAmount As Long, ByVal [To] As String, ByVal Currency As String, ByVal Optional IsReferral As Boolean = False) As SendResponse Implements IFaucetPayClient.Send
            _Requester.Configuration.SendInterceptors.ThrowInterceptorErrorsAsync(Function(i) i.CheckSendRequestAsync(SatoshiAmount, [To], Currency, IsReferral)).Wait()
            Return _Requester.PostAsync(Of SendResponse)("send", New Dictionary(Of String, String) From {{"amount", SatoshiAmount.ToString()}, {"to", [To]}, {"currency", Currency}, {"referral", If(IsReferral, "true", "false")}}).Result
        End Function
        Public Function GetPayouts(TransactionCount As Integer, ByVal Currency As String) As IEnumerable(Of Payout) Implements IFaucetPayClient.GetPayouts
            If TransactionCount < 0 OrElse TransactionCount > 100 Then Throw New ArgumentOutOfRangeException($"The transaction count is out of range (0-100), got {TransactionCount}.", NameOf(TransactionCount))
            Return _Requester.PostAsync(Of PayoutsResponse)("payouts", New Dictionary(Of String, String) From {{"currency", Currency}, {"count", TransactionCount.ToString()}}).Result.Payouts
        End Function
        Public Function GetBalance(ByVal Currency As String) As BalanceResponse Implements IFaucetPayClient.GetBalance
            Return _Requester.PostAsync(Of BalanceResponse)("balance", New Dictionary(Of String, String) From {{"currency", Currency}}).Result
        End Function
        Public Function GetCurrencies() As CurrenciesResponse Implements IFaucetPayClient.GetCurrencies
            Return _Requester.PostAsync(Of CurrenciesResponse)("currencies").Result
        End Function
        Public Function FaucetList(Currency As String) As IDictionary(Of String, String()) Implements IFaucetPayClient.FaucetList
            Dim Received = _Requester.PostAsync(Of FaucetListResponse)("faucetlist").Result
            Dim MyList = New Dictionary(Of String, String())
            Dim obj As Object = Nothing
            If Currency = "BCH" Then
                obj = Received.DataList.Item("normal").BitCoin_Cash
            ElseIf Currency = "BNB" Then
                obj = Received.DataList.Item("normal").Binance
            ElseIf Currency = "BTC" Then
                obj = Received.DataList.Item("normal").BitCoin
            ElseIf Currency = "DASH" Then
                obj = Received.DataList.Item("normal").Dash
            ElseIf Currency = "DGB" Then
                obj = Received.DataList.Item("normal").DigiByte
            ElseIf Currency = "DOGE" Then
                obj = Received.DataList.Item("normal").DogeCoin
            ElseIf Currency = "ETH" Then
                obj = Received.DataList.Item("normal").Ethereum
            ElseIf Currency = "FEY" Then
                obj = Received.DataList.Item("normal").Feyorra
            ElseIf Currency = "LTC" Then
                obj = Received.DataList.Item("normal").LiteCoin
            ElseIf Currency = "SOL" Then
                obj = Received.DataList.Item("normal").Solana
            ElseIf Currency = "TRX" Then
                obj = Received.DataList.Item("normal").Tron
            ElseIf Currency = "USDT" Then
                obj = Received.DataList.Item("normal").Tether
            ElseIf Currency = "ZEC" Then
                obj = Received.DataList.Item("normal").ZCash
            End If

            For i = 0 To obj.Count - 1
                Dim ID = obj.Item(i).Id.ToString
                MyList.Add(ID, {obj.Item(i).Id.ToString,
                           obj.Item(i).Name.ToString,
                           obj.Item(i).URL.ToString,
                           obj.Item(i).Owner_Id.ToString,
                           obj.Item(i).Owner_Name.ToString,
                           obj.Item(i).Currency_Symbol.ToString,
                           obj.Item(i).Timer_In_Minutes.ToString,
                           obj.Item(i).Reward.ToString,
                           obj.Item(i).Is_Enabled.ToString,
                           obj.Item(i).Creation_Date.ToString,
                           obj.Item(i).Category.ToString,
                           obj.Item(i).Paid_Today.ToString,
                           obj.Item(i).Total_Users_Paid.ToString,
                           obj.Item(i).Active_Users.ToString,
                           obj.Item(i).Balance.ToString,
                           obj.Item(i).Health.ToString})
            Next

            Return MyList
        End Function

        Public Function CheckAddressBoolean(ByVal Address As String, ByVal Currency As String) As Boolean Implements IFaucetPayClient.CheckAddressBoolean
            Dim result = CheckAddressRequest(Address, Currency, True)
            If result.Status <> 200 Then
                Return False
            Else
                Return True
            End If
        End Function

        Public Function CheckAddress(ByVal Address As String, ByVal Currency As String) As CheckAddressResponse Implements IFaucetPayClient.CheckAddress
            Try
                Return CheckAddressRequest(Address, Currency)
            Catch e As FaucetPayException When e.HasError(FaucetPayError.InvalidAddress)
                Throw New InvalidCryptocurrencyAddressException(e.Message, e)
            End Try
        End Function

        Private Function CheckAddressRequest(ByVal Address As String, ByVal Currency As String, ByVal Optional NoThrow As Boolean = False) As CheckAddressResponse
            Return _Requester.PostAsync(Of CheckAddressResponse)("checkaddress", New Dictionary(Of String, String) From {{"address", Address}, {"currency", Currency}}, NoThrow).Result
        End Function
#End Region

        Public Sub Dispose() Implements IFaucetPayClient.Dispose
            Dim Disposable As IDisposable = Nothing

            If [Implements].Assign(Disposable, TryCast(_Requester, IDisposable)) IsNot Nothing Then
                Disposable.Dispose()
            End If
        End Sub
        Private Class [Implements]
            Shared Function Assign(Of T)(ByRef Target As T, Value As T) As T
                Target = Value
                Return Value
            End Function
        End Class
    End Class
End Namespace
