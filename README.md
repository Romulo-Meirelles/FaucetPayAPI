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


<br> Some examples of how to use.<br>

<picture>
     Sub Main(args As String())

        Using API As New FaucetPayAPIClient("880bcd6696e47c9472e18bf986e8bb33448bfa10")

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
  </picture>
