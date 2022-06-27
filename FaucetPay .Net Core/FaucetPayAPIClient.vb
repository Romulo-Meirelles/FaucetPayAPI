Imports FaucetPay.Models
Imports FaucetPay.Utilities
Namespace FaucetPayAPI
    Public Class FaucetPayAPIClient
        Implements IDisposable
        Private Protected MyAPI As String
        Public Sub New(API As String)
            MyAPI = API
        End Sub

        Public Function CheckAddress(Address As String, Optional Currency As String = "BTC", Optional Log As Boolean = True) As String
            Dim MyAddress As New CheckAddress
            Dim Response As String = MyAddress.CheckHashPayout(MyAPI, Address, Log, Currency)
            Return Response
        End Function

        Public Function CheckAddressExist(Address As String, Optional Currency As String = "BTC", Optional Log As Boolean = True) As Boolean
            Dim MyAddressExist As New CheckAddress
            Dim Response As Boolean = MyAddressExist.CheckAddressExist(MyAPI, Address, Log, Currency)
            Return Response
        End Function
        Public Function GetBalance(Optional Currency As String = "BTC", Optional Log As Boolean = True) As List(Of String)
            Dim MyGetBalance As New GetBalance
            Dim Response As List(Of String) = MyGetBalance.Balance(MyAPI, Log, Currency)
            Return Response
        End Function

        Public Function GetBalanceAll(Optional Log As Boolean = True) As List(Of String)
            Dim MyGetBalance As New GetBalance
            Dim Response As List(Of String) = MyGetBalance.Balance(MyAPI, Log, "BTC", True)
            Return Response
        End Function
        Public Function GetListCurrencies(Optional Log As Boolean = True) As List(Of String)
            Dim MyListCurrencies As New GetListOfCurrencies
            Dim Response As List(Of String) = MyListCurrencies.GetListCurrencies(MyAPI, Log)
            Return Response
        End Function
        Public Function GetListCurrenciesNames(Optional Log As Boolean = True) As List(Of String)
            Dim MyGetListCurrenciesNames As New GetListOfCurrencies
            Dim Response As List(Of String) = MyGetListCurrenciesNames.GetListCurrenciesNames(MyAPI, Log)
            Return Response
        End Function
        Public Function SendPay(Amount As String, To_ As String, Optional Currency As String = "BTC", Optional Referral As Boolean = False, Optional Log As Boolean = True) As List(Of String)
            Dim MySendPayment As New SendPayment
            Dim Response As List(Of String) = MySendPayment.Send(MyAPI, Amount, To_, Log, Currency, Referral)
            Return Response
        End Function
        Public Function RecentPayout(Optional Currency As String = "BTC", Optional Count As String = "", Optional Log As Boolean = True) As List(Of String)
            Dim MyRecentPayout As New RecentPayouts
            Dim Response As List(Of String) = MyRecentPayout.Payouts(MyAPI, Log, Currency, Count)
            Return Response
        End Function
        Public Async Function FaucetListAsync(Optional Log As Boolean = True) As Task(Of Dictionary(Of String, String()))
            Dim MyFaucetList As New FaucetList
            Dim Response As Dictionary(Of String, String()) = Await MyFaucetList.ListAsync(Log, MyAPI)
            Return Response
        End Function
        Public Function FaucetList(Optional Log As Boolean = True) As Dictionary(Of String, String())
            Dim MyFaucetList As New FaucetList
            Dim Response As Dictionary(Of String, String()) = MyFaucetList.List(Log, MyAPI)
            Return Response
        End Function
        Public Function Donation(Optional Amount As String = "0.00000010", Optional Log As Boolean = True, Optional Currency As Donation.Wallets = 0, Optional Referral As Boolean = True, Optional IPAddrees As String = "") As List(Of String)
            Dim MyDonation As New Donation
            Dim Response As List(Of String) = MyDonation.Donation(MyAPI, Amount, Log, Currency, Referral, IPAddrees)
            Return Response
        End Function
        Public Sub Dispose() Implements IDisposable.Dispose
            GC.SuppressFinalize(Me)
        End Sub
        Protected Overrides Sub Finalize()
            Dispose()
        End Sub
    End Class
End Namespace
