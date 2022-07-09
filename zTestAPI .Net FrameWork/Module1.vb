Imports FaucetPay.FaucetPayClient
Imports FaucetPay.Config
Imports FaucetPay.Exceptions

Module Module1
    Sub Main()
        Call Start()
        While True
        End While
    End Sub
    Async Sub Start()
        Try
            Using Client = FaucetPayClient.Create(New ApiConfig With {.ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d"})

                '----- ASYNC COMMANDS -----

                'Dim BalanceAsync = Await Client.GetBalanceAsync(FaucetPayClient.Bitcoin)
                'Console.WriteLine("Balance Satoshis: " & BalanceAsync.SatoshiBalance)
                'Console.WriteLine("Actual Balance: " & BalanceAsync.ActualBalance)
                'Console.WriteLine("Currency: " & BalanceAsync.Currency)


                'Dim CurrenciesAsync = Await Client.GetCurrenciesAsync()
                'For Each Item In CurrenciesAsync.Currencies
                '    Console.WriteLine("Currencies: " & Item.Name)
                '    Console.WriteLine("Acronym: " & Item.Acronym)
                '    Console.WriteLine(vbCrLf)
                'Next


                'Dim CheckAddressBooleanAsync = Await Client.CheckAddressBooleanAsync("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.Bitcoin)
                'Console.WriteLine("Is Valid: " & CheckAddressBooleanAsync.ToString)


                'Dim CheckAddressAsync = Await Client.CheckAddressAsync("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.Bitcoin)
                'Console.WriteLine("User Hash: " & CheckAddressAsync.PayoutUserHash)


                'Dim GetPayoutAsync = Await Client.GetPayoutsAsync(10, FaucetPayClient.Bitcoin)
                'For Each Item In GetPayoutAsync
                '    Console.WriteLine("Date: " & Item.Date)
                '    Console.WriteLine("To: " & Item.To)
                '    Console.WriteLine("Satoshi Amount: " & Item.SatoshiAmount)
                'Next

                'Dim SendAsync = Await Client.SendAsync(10, "19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.Bitcoin, IsReferral:=False)
                'Console.WriteLine("PayoutID: " & SendAsync.PayoutId)
                'Console.WriteLine("Payout User Hash: " & SendAsync.PayoutUserHash)
                'Console.WriteLine("Rate Limit Remaining: " & SendAsync.RateLimitRemaining)
                'Console.WriteLine("Satoshi Balance: " & SendAsync.RemainingSatoshiBalance)


                Dim FaucetListAsync = Await Client.FaucetListAsync(FaucetPayClient.Feyorra)
                For Each Item In FaucetListAsync.Values
                    Console.WriteLine("ID: " & Item.SyncRoot(0).ToString)
                    Console.WriteLine("Name: " & Item.SyncRoot(1).ToString)
                    Console.WriteLine("URL: " & Item.SyncRoot(2).ToString)
                    Console.WriteLine("Owner ID: " & Item.SyncRoot(3).ToString)
                    Console.WriteLine("Owner Name: " & Item.SyncRoot(4).ToString)
                    Console.WriteLine("Currency: " & Item.SyncRoot(5).ToString)
                    Console.WriteLine("Timer in Minutes: " & Item.SyncRoot(6).ToString)
                    Console.WriteLine("Reward: " & Item.SyncRoot(7).ToString)
                    Console.WriteLine("Is Enabled: " & Item.SyncRoot(8).ToString)
                    Console.WriteLine("Creation Date: " & Item.SyncRoot(9).ToString)
                    Console.WriteLine("Category: " & Item.SyncRoot(10).ToString)
                    Console.WriteLine("Paid Today: " & Item.SyncRoot(11).ToString)
                    Console.WriteLine("Total User Paid: " & Item.SyncRoot(12).ToString)
                    Console.WriteLine("Active Users: " & Item.SyncRoot(13).ToString)
                    Console.WriteLine("Balance: " & Item.SyncRoot(14).ToString)
                    Console.WriteLine("Health: " & Item.SyncRoot(15).ToString)
                    Console.WriteLine(vbCrLf)
                Next

                Exit Sub
                '------ SIMPLE COMMANDS ------

                Dim Balance = Client.GetBalance(FaucetPayClient.Bitcoin)
                Console.WriteLine("Balance Satoshis: " & Balance.SatoshiBalance)
                Console.WriteLine("Actual Balance: " & Balance.ActualBalance)
                Console.WriteLine("Currency: " & Balance.Currency)

                Dim Currencies = Client.GetCurrencies
                For Each Item In Currencies.Currencies
                    Console.WriteLine("Currencies: " & Item.Name)
                    Console.WriteLine("Acronym: " & Item.Acronym)
                    Console.WriteLine(vbCrLf)
                Next

                Dim CheckAddressBoolean = Client.CheckAddressBoolean("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.Bitcoin)
                Console.WriteLine("Is Valid: " & CheckAddressBoolean.ToString)


                Dim CheckAddress = Client.CheckAddress("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.Bitcoin)
                Console.WriteLine("User Hash: " & CheckAddress.PayoutUserHash)


                Dim GetPayout = Client.GetPayouts(10, FaucetPayClient.Bitcoin)
                For Each Item In GetPayout
                    Console.WriteLine("Date: " & Item.Date)
                    Console.WriteLine("To: " & Item.To)
                    Console.WriteLine("Satoshi Amount: " & Item.SatoshiAmount)
                Next

                Dim Send = Client.Send(10, "19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.Bitcoin, IsReferral:=False)
                Console.WriteLine("PayoutID: " & Send.PayoutId)
                Console.WriteLine("Payout User Hash: " & Send.PayoutUserHash)
                Console.WriteLine("Rate Limit Remaining: " & Send.RateLimitRemaining)
                Console.WriteLine("Satoshi Balance: " & Send.RemainingSatoshiBalance)


                Dim FaucetList = Client.FaucetList(FaucetPayClient.Feyorra)
                For Each Item In FaucetList.Values
                    Console.WriteLine("ID: " & Item.SyncRoot(0).ToString)
                    Console.WriteLine("Name: " & Item.SyncRoot(1).ToString)
                    Console.WriteLine("URL: " & Item.SyncRoot(2).ToString)
                    Console.WriteLine("Owner ID: " & Item.SyncRoot(3).ToString)
                    Console.WriteLine("Owner Name: " & Item.SyncRoot(4).ToString)
                    Console.WriteLine("Currency: " & Item.SyncRoot(5).ToString)
                    Console.WriteLine("Timer in Minutes: " & Item.SyncRoot(6).ToString)
                    Console.WriteLine("Reward: " & Item.SyncRoot(7).ToString)
                    Console.WriteLine("Is Enabled: " & Item.SyncRoot(8).ToString)
                    Console.WriteLine("Creation Date: " & Item.SyncRoot(9).ToString)
                    Console.WriteLine("Category: " & Item.SyncRoot(10).ToString)
                    Console.WriteLine("Paid Today: " & Item.SyncRoot(11).ToString)
                    Console.WriteLine("Total User Paid: " & Item.SyncRoot(12).ToString)
                    Console.WriteLine("Active Users: " & Item.SyncRoot(13).ToString)
                    Console.WriteLine("Balance: " & Item.SyncRoot(14).ToString)
                    Console.WriteLine("Health: " & Item.SyncRoot(15).ToString)
                    Console.WriteLine(vbCrLf)
                Next
            End Using

        Catch ex As FaucetPayException
            Console.WriteLine("Error: " & ex.Message)
            Console.ReadLine()
        End Try

    End Sub
End Module
