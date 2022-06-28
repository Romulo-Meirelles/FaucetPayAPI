# <a href="https://faucetpay.io/?r=4070094"><img src="/Pictures/faucetpay.png"> FaucetPayAPI.

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://github.com/Romulo-Meirelles) <br>
API for you to make a cryptocurrency management platform on FaucetPay, Through the API you can make payments, see faucet lists, see your balance, Check if a wallet or user exists and check payment HASH. Enjoy

## Features

- Make payments.
- See faucet lists.
- See your balance.
- Check if a wallet or user exists.
- Check payment HASH.
- Manage your cryptocurrencies
- Easy to Use

<br><h1> Some examples of how to use.</h1><br>

```VB
     Sub Main(args As String())

        Using API As New FaucetPayAPIClient("880bcd6696e47c9472e18bf986e8bb33448bfa10") '<-- Your API FaucetPay

            Try

                Dim MyBalanceBTC = API.GetBalance("BTC")
                For i = 0 To MyBalanceBTC.Count - 1
                    Console.WriteLine("My Balance: " & MyBalanceBTC(i))
                Next

                Dim MyBalance = API.GetBalanceAll()
                For i = 0 To MyBalance.Count - 1
                    Console.WriteLine("My Balance: " & MyBalance(i))
                Next

                Dim ListOfCurrencies = API.GetListCurrencies
                For i = 0 To ListOfCurrencies.Count - 1
                    Console.WriteLine("Currencies: " & ListOfCurrencies(i))
                Next

                Dim RecentPayout = API.RecentPayout("BTC", 10)
                For i = 0 To RecentPayout.Count - 1
                    Console.WriteLine("Recent Payout: " & RecentPayout(i))
                Next

                Dim CheckAddress = API.CheckAddressExist("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", "BTC")
                Console.WriteLine("Check Wallet Exist: " & CheckAddress.ToString)

                Dim SendPayment = API.SendPay("1", "19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", "BTC")
                For i = 0 To SendPayment.Count - 1
                    Console.WriteLine("Send: " & SendPayment(i))
                Next

                Dim FaucetList = API.FaucetList()

                For Each Item In FaucetList
                    Console.WriteLine("Currency Name: " & Item.Key)
                    For i = 0 To Item.Value.Count - 1
                        Console.WriteLine("Items List: " & Item.Value(i))
                    Next
                Next

            Catch ex As Exception
                Console.WriteLine("Error: " & ex.Message)
            End Try
        End Using
     End Sub
 ```
        
 <h1> BALANCE.</h1>

```VB
         Using API As New FaucetPayAPIClient("880bcd6696e47c9472e18bf986e8bb33448bfa10") '<-- Your API FaucetPay
                Dim MyBalanceBTC = API.GetBalance("BTC")
                For i = 0 To MyBalanceBTC.Count - 1
                    Console.WriteLine("My Balance: " & MyBalanceBTC(i))
                Next

                Dim MyBalance = API.GetBalanceAll()
                For i = 0 To MyBalance.Count - 1
                    Console.WriteLine("My Balance: " & MyBalance(i))
                Next
        End Using
 ```
        
        
  <h1> LIST CURRENCIES.</h1>

```VB
         Using API As New FaucetPayAPIClient("880bcd6696e47c9472e18bf986e8bb33448bfa10") '<-- Your API FaucetPay
                Dim ListOfCurrencies = API.GetListCurrencies
                For i = 0 To ListOfCurrencies.Count - 1
                    Console.WriteLine("Currencies: " & ListOfCurrencies(i))
                Next
        End Using
```
   
  <h1> RECENT PAYOUT.</h1>

```VB
         Using API As New FaucetPayAPIClient("880bcd6696e47c9472e18bf986e8bb33448bfa10") '<-- Your API FaucetPay
                Dim RecentPayout = API.RecentPayout("BTC", 10) '<-- Optional Defaults to "BTC", can be explicitly set. And Number of transactions you want to fetch, a value between 0 and 100.
                For i = 0 To RecentPayout.Count - 1
                    Console.WriteLine("Recent Payout: " & RecentPayout(i))
                Next
        End Using
```
   <h1> CHECK ADDRESS EXIST.</h1>
        
```VB
         Using API As New FaucetPayAPIClient("880bcd6696e47c9472e18bf986e8bb33448bfa10") '<-- Your API FaucetPay
                Dim CheckAddress = API.CheckAddressExist("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", "BTC") '<-- Wallet Required and Currency Optional
                Console.WriteLine("Check Wallet Exist: " & CheckAddress.ToString) '<-- Boolean
         End Using
```
   <h1> SEND PAYMENTS.</h1>
                
```VB
         Using API As New FaucetPayAPIClient("880bcd6696e47c9472e18bf986e8bb33448bfa10") '<-- Your API FaucetPay
                Dim SendPayment = API.SendPay("10", "19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", "BTC") 'Number Satoshis Required, Wallet Required and Currency Optional Defaults to "BTC", can be explicitly set
                For i = 0 To SendPayment.Count - 1
                    Console.WriteLine("Send: " & SendPayment(i))
                Next
        End Using
```
   <h1> FAUCET LIST.</h1>
               
```VB
         Using API As New FaucetPayAPIClient("880bcd6696e47c9472e18bf986e8bb33448bfa10") '<-- Your API FaucetPay
                Dim FaucetList = API.FaucetList()
                For Each Item In FaucetList
                    Console.WriteLine("Currency Name: " & Item.Key)
                    For i = 0 To Item.Value.Count - 1
                        Console.WriteLine("Items List: " & Item.Value(i))
                    Next
                Next
        End Using
```
        
