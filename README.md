# <a href="https://faucetpay.io/?r=4070094"><img src="/Pictures/faucetpay.png"> FaucetPayAPI. (UNOFFICIAL)

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
<br><h1> ✨ Some examples of how to use. ✨</h1><br>

<h2>Visual Basic </h1>

```VB 

Sub Main(args As String())
     Try
            Using Client = FaucetPayClient.Create(New ApiConfig With {.ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d"})

                '----- ASYNC COMMANDS -----

                Dim BalanceAsync = Await Client.GetBalanceAsync(FaucetPayClient.Bitcoin)
                Console.WriteLine("Balance Satoshis: " & BalanceAsync.SatoshiBalance)
                Console.WriteLine("Actual Balance: " & BalanceAsync.ActualBalance)
                Console.WriteLine("Currency: " & BalanceAsync.Currency)


                Dim CurrenciesAsync = Await Client.GetCurrenciesAsync()
                For Each Item In CurrenciesAsync.Currencies
                    Console.WriteLine("Currencies: " & Item.Name)
                    Console.WriteLine("Acronym: " & Item.Acronym)
                    Console.WriteLine(vbCrLf)
                Next


                Dim CheckAddressBooleanAsync = Await Client.CheckAddressBooleanAsync("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.Bitcoin)
                Console.WriteLine("Is Valid: " & CheckAddressBooleanAsync.ToString)


                Dim CheckAddressAsync = Await Client.CheckAddressAsync("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.Bitcoin)
                Console.WriteLine("User Hash: " & CheckAddressAsync.PayoutUserHash)


                Dim GetPayoutAsync = Await Client.GetPayoutsAsync(10, FaucetPayClient.Bitcoin)
                For Each Item In GetPayoutAsync
                    Console.WriteLine("Date: " & Item.Date)
                    Console.WriteLine("To: " & Item.To)
                    Console.WriteLine("Satoshi Amount: " & Item.SatoshiAmount)
                Next

                Dim SendAsync = Await Client.SendAsync(10, "19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.Bitcoin, IsReferral:=False)
                Console.WriteLine("PayoutID: " & SendAsync.PayoutId)
                Console.WriteLine("Payout User Hash: " & SendAsync.PayoutUserHash)
                Console.WriteLine("Rate Limit Remaining: " & SendAsync.RateLimitRemaining)
                Console.WriteLine("Satoshi Balance: " & SendAsync.RemainingSatoshiBalance)


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
 ```
        
 <h1> BALANCE.</h1>

```VB
         Using Client = FaucetPayClient.Create(New ApiConfig With {.ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d"})
                Dim BalanceAsync = Await Client.GetBalanceAsync(FaucetPayClient.Bitcoin)
                Console.WriteLine("Balance Satoshis: " & BalanceAsync.SatoshiBalance)
                Console.WriteLine("Actual Balance: " & BalanceAsync.ActualBalance)
                Console.WriteLine("Currency: " & BalanceAsync.Currency)
         End Using
 ```
  
          
  <h1> LIST CURRENCIES.</h1>

```VB
          Using Client = FaucetPayClient.Create(New ApiConfig With {.ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d"})
               Dim CurrenciesAsync = Await Client.GetCurrenciesAsync()
                For Each Item In CurrenciesAsync.Currencies
                    Console.WriteLine("Currencies: " & Item.Name)
                    Console.WriteLine("Acronym: " & Item.Acronym)
                    Console.WriteLine(vbCrLf)
                Next
         End Using
```
   
  <h1> RECENT PAYOUT.</h1>

```VB
        Using Client = FaucetPayClient.Create(New ApiConfig With {.ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d"})
                For Each Item In GetPayoutAsync
                    Console.WriteLine("Date: " & Item.Date)
                    Console.WriteLine("To: " & Item.To)
                    Console.WriteLine("Satoshi Amount: " & Item.SatoshiAmount)
                Next
         End Using
```
   <h1> CHECK ADDRESS EXIST.</h1>
        
```VB
         Using Client = FaucetPayClient.Create(New ApiConfig With {.ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d"})
                Dim CheckAddressBooleanAsync = Await Client.CheckAddressBooleanAsync("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.Bitcoin)
                Console.WriteLine("Is Valid: " & CheckAddressBooleanAsync.ToString)
         End Using
```

 <h1> CHECK USER HASH.</h1>
        
```VB
          Using Client = FaucetPayClient.Create(New ApiConfig With {.ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d"})
                Dim CheckAddressAsync = Await Client.CheckAddressAsync("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.Bitcoin)
                Console.WriteLine("User Hash: " & CheckAddressAsync.PayoutUserHash)
          End Using
```

   <h1> SEND PAYMENTS.</h1>
                
```VB
         Using Client = FaucetPayClient.Create(New ApiConfig With {.ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d"})
             Dim SendAsync = Await Client.SendAsync(10, "19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.Bitcoin, IsReferral:=False)
                Console.WriteLine("PayoutID: " & SendAsync.PayoutId)
                Console.WriteLine("Payout User Hash: " & SendAsync.PayoutUserHash)
                Console.WriteLine("Rate Limit Remaining: " & SendAsync.RateLimitRemaining)
                Console.WriteLine("Satoshi Balance: " & SendAsync.RemainingSatoshiBalance)
         End Using
```
   <h1> FAUCET LIST.</h1>
               
```VB
           Using Client = FaucetPayClient.Create(New ApiConfig With {.ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d"})
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
         End Using
```
       
       
<h2>C#</h1>

```CSharp 
 public static void Main()
        {
           
 using (var Client = FaucetPayClient.FaucetPayClient.Create(new ApiConfig() { ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d" }))
                {

                    try
                    {
                        //-----ASYNC COMMANDS---- -
                        var BalanceAsync = await Client.GetBalanceAsync(FaucetPayClient.FaucetPayClient.Bitcoin);
                        Console.WriteLine("Balance Satoshis: " + BalanceAsync.SatoshiBalance);
                        Console.WriteLine("Actual Balance: " + BalanceAsync.ActualBalance);
                        Console.WriteLine("Currency: " + BalanceAsync.Currency);


                        var CurrenciesAsync = await Client.GetCurrenciesAsync();
                        foreach (var Item in CurrenciesAsync.Currencies)
                        {
                            Console.WriteLine("Currencies: ", Item.Name);
                            Console.WriteLine("Acronym: ", Item.Acronym);
                            Console.WriteLine("\n");
                        }

                        var CheckAddressBooleanAsync = await Client.CheckAddressBooleanAsync("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.FaucetPayClient.Bitcoin);
                        Console.WriteLine("Is Valid: " + CheckAddressBooleanAsync.ToString());

                        var CheckAddressAsync = await Client.CheckAddressAsync("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.FaucetPayClient.Bitcoin);
                        Console.WriteLine("User Hash: " + CheckAddressAsync.PayoutUserHash);

                        var GetPayoutAsync = await Client.GetPayoutsAsync(10, FaucetPayClient.FaucetPayClient.Bitcoin);
                        foreach (var Item in GetPayoutAsync)
                        {
                            Console.WriteLine("Date: ", Item.Date);
                            Console.WriteLine("To: ", Item.To);
                            Console.WriteLine("Satoshi Amount: ", Item.SatoshiAmount);
                        }

                        var SendAsync = await Client.SendAsync(10, "19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.FaucetPayClient.Bitcoin, IsReferral: false);
                        Console.WriteLine("PayoutID: " + SendAsync.PayoutId);
                        Console.WriteLine("Payout User Hash: " + SendAsync.PayoutUserHash);
                        Console.WriteLine("Rate Limit Remaining: " + SendAsync.RateLimitRemaining);
                        Console.WriteLine("Satoshi Balance: " + SendAsync.RemainingSatoshiBalance);

                        var FaucetListAsync = await Client.FaucetListAsync();
                        foreach (var Item in FaucetListAsync.DataList.Values)
                        {
                            Console.WriteLine("ID: " + Item.BitCoin["id"].Id.ToString());
                            Console.WriteLine("Name: " + Item.BitCoin["name"].Id.ToString());
                            Console.WriteLine("URL: " + Item.BitCoin["url"].Id.ToString());
                            Console.WriteLine("Owner ID: " + Item.BitCoin["owner_id"].Id.ToString());
                            Console.WriteLine("Owner Name: " + Item.BitCoin["owner_name"].Id.ToString());
                            Console.WriteLine("Currency: " + Item.BitCoin["currency"].Id.ToString());
                            Console.WriteLine("Timer in Minutes: " + Item.BitCoin["timer_in_minutes"].Id.ToString());
                            Console.WriteLine("Reward: " + Item.BitCoin["reward"].Id.ToString());
                            Console.WriteLine("Is Enabled: " + Item.BitCoin["is_enabled"].Id.ToString());
                            Console.WriteLine("Creation Date: " + Item.BitCoin["creation_date"].Id.ToString());
                            Console.WriteLine("Category: " + Item.BitCoin["category"].Id.ToString());
                            Console.WriteLine("Paid Today: " + Item.BitCoin["paid_today"].Id.ToString());
                            Console.WriteLine("Total User Paid: " + Item.BitCoin["total_users_paid"].Id.ToString());
                            Console.WriteLine("Active Users: " + Item.BitCoin["active_users"].Id.ToString());
                            Console.WriteLine("Balance: " + Item.BitCoin["balance"].Id.ToString());
                            Console.WriteLine("Health: " + Item.BitCoin["health"].Id.ToString());
                            Console.WriteLine("\n");
                        }

                        //    // ------ SIMPLE COMMANDS ------

                        var Balance = Client.GetBalance(FaucetPayClient.FaucetPayClient.Bitcoin);
                        Console.WriteLine("Balance Satoshis: " + Balance.SatoshiBalance);
                        Console.WriteLine("Actual Balance: " + Balance.ActualBalance);
                        Console.WriteLine("Currency: " + Balance.Currency);

                        var Currencies = Client.GetCurrencies();
                        foreach (var Item in Currencies.Currencies)
                        {
                            Console.WriteLine("Currencies: ", Item.Name);
                            Console.WriteLine("Acronym: ", Item.Acronym);
                            Console.WriteLine("\n");
                        }

                        var CheckAddressBoolean = Client.CheckAddressBoolean("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.FaucetPayClient.Bitcoin);
                        Console.WriteLine("Is Valid: " + CheckAddressBoolean.ToString());


                        var CheckAddress = Client.CheckAddress("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.FaucetPayClient.Bitcoin);
                        Console.WriteLine("User Hash: " + CheckAddress.PayoutUserHash);


                        var GetPayout = Client.GetPayouts(10, FaucetPayClient.FaucetPayClient.Bitcoin);
                        foreach (var Item in GetPayout)
                        {
                            Console.WriteLine("Date: ", Item.Date);
                            Console.WriteLine("To: ", Item.To);
                            Console.WriteLine("Satoshi Amount: ", Item.SatoshiAmount);
                        }

                        var Send = Client.Send(10, "19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.FaucetPayClient.Bitcoin, IsReferral: false);
                        Console.WriteLine("PayoutID: " + Send.PayoutId);
                        Console.WriteLine("Payout User Hash: " + Send.PayoutUserHash);
                        Console.WriteLine("Rate Limit Remaining: " + Send.RateLimitRemaining);
                        Console.WriteLine("Satoshi Balance: " + Send.RemainingSatoshiBalance);


                        var FaucetList = Client.FaucetList();
                        foreach (var Item in FaucetList.DataList.Values)
                        {
                            Console.WriteLine("ID: " + Item.BitCoin["id"].Id.ToString());
                            Console.WriteLine("Name: " + Item.BitCoin["name"].Id.ToString());
                            Console.WriteLine("URL: " + Item.BitCoin["url"].Id.ToString());
                            Console.WriteLine("Owner ID: " + Item.BitCoin["owner_id"].Id.ToString());
                            Console.WriteLine("Owner Name: " + Item.BitCoin["owner_name"].Id.ToString());
                            Console.WriteLine("Currency: " + Item.BitCoin["currency"].Id.ToString());
                            Console.WriteLine("Timer in Minutes: " + Item.BitCoin["timer_in_minutes"].Id.ToString());
                            Console.WriteLine("Reward: " + Item.BitCoin["reward"].Id.ToString());
                            Console.WriteLine("Is Enabled: " + Item.BitCoin["is_enabled"].Id.ToString());
                            Console.WriteLine("Creation Date: " + Item.BitCoin["creation_date"].Id.ToString());
                            Console.WriteLine("Category: " + Item.BitCoin["category"].Id.ToString());
                            Console.WriteLine("Paid Today: " + Item.BitCoin["paid_today"].Id.ToString());
                            Console.WriteLine("Total User Paid: " + Item.BitCoin["total_users_paid"].Id.ToString());
                            Console.WriteLine("Active Users: " + Item.BitCoin["active_users"].Id.ToString());
                            Console.WriteLine("Balance: " + Item.BitCoin["balance"].Id.ToString());
                            Console.WriteLine("Health: " + Item.BitCoin["health"].Id.ToString());
                            Console.WriteLine("\n");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
        }
```

<h1> BALANCE.</h1>

```CSharp
       using (var Client = FaucetPayClient.FaucetPayClient.Create(new ApiConfig() { ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d" }))
                {
                 var BalanceAsync = await Client.GetBalanceAsync(FaucetPayClient.FaucetPayClient.Bitcoin);
                        Console.WriteLine("Balance Satoshis: " + BalanceAsync.SatoshiBalance);
                        Console.WriteLine("Actual Balance: " + BalanceAsync.ActualBalance);
                        Console.WriteLine("Currency: " + BalanceAsync.Currency);
                }
 ```
  
          
  <h1> LIST CURRENCIES.</h1>

```CSharp
          using (var Client = FaucetPayClient.FaucetPayClient.Create(new ApiConfig() { ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d" }))
                {
                 var CurrenciesAsync = await Client.GetCurrenciesAsync();
                        foreach (var Item in CurrenciesAsync.Currencies)
                        {
                            Console.WriteLine("Currencies: ", Item.Name);
                            Console.WriteLine("Acronym: ", Item.Acronym);
                            Console.WriteLine("\n");
                        }
                }
```
   
  <h1> RECENT PAYOUT.</h1>

```CSharp
         using (var Client = FaucetPayClient.FaucetPayClient.Create(new ApiConfig() { ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d" }))
                {
                 var GetPayoutAsync = await Client.GetPayoutsAsync(10, FaucetPayClient.FaucetPayClient.Bitcoin);
                        foreach (var Item in GetPayoutAsync)
                        {
                            Console.WriteLine("Date: ", Item.Date);
                            Console.WriteLine("To: ", Item.To);
                            Console.WriteLine("Satoshi Amount: ", Item.SatoshiAmount);
                        }
                }
```
   <h1> CHECK ADDRESS EXIST.</h1>
        
```CSharp
         using (var Client = FaucetPayClient.FaucetPayClient.Create(new ApiConfig() { ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d" }))
                {
                 var CheckAddressBooleanAsync = await Client.CheckAddressBooleanAsync("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.FaucetPayClient.Bitcoin);
                 Console.WriteLine("Is Valid: " + CheckAddressBooleanAsync.ToString());
                }
```

 <h1> CHECK USER HASH.</h1>
        
```CSharp
         using (var Client = FaucetPayClient.FaucetPayClient.Create(new ApiConfig() { ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d" }))
                {
                var CheckAddressAsync = await Client.CheckAddressAsync("19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.FaucetPayClient.Bitcoin);
                Console.WriteLine("User Hash: " + CheckAddressAsync.PayoutUserHash);
                }
```

   <h1> SEND PAYMENTS.</h1>
                
```CSharp
         using (var Client = FaucetPayClient.FaucetPayClient.Create(new ApiConfig() { ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d" }))
                {
                var SendAsync = await Client.SendAsync(10, "19EsDy2kzS1jANgm7M5hdYvgh26uMsgGzu", FaucetPayClient.FaucetPayClient.Bitcoin, IsReferral: false);
                        Console.WriteLine("PayoutID: " + SendAsync.PayoutId);
                        Console.WriteLine("Payout User Hash: " + SendAsync.PayoutUserHash);
                        Console.WriteLine("Rate Limit Remaining: " + SendAsync.RateLimitRemaining);
                        Console.WriteLine("Satoshi Balance: " + SendAsync.RemainingSatoshiBalance);
                }
```
   <h1> FAUCET LIST.</h1>
               
```CSharp
           using (var Client = FaucetPayClient.FaucetPayClient.Create(new ApiConfig() { ApiKey = "889bcd6696e47c9472e18bf986e8bb33448bfa9d" }))
                {
                 var FaucetListAsync = await Client.FaucetListAsync();
                        foreach (var Item in FaucetListAsync.DataList.Values)
                        {
                            Console.WriteLine("ID: " + Item.BitCoin["id"].Id.ToString());
                            Console.WriteLine("Name: " + Item.BitCoin["name"].Id.ToString());
                            Console.WriteLine("URL: " + Item.BitCoin["url"].Id.ToString());
                            Console.WriteLine("Owner ID: " + Item.BitCoin["owner_id"].Id.ToString());
                            Console.WriteLine("Owner Name: " + Item.BitCoin["owner_name"].Id.ToString());
                            Console.WriteLine("Currency: " + Item.BitCoin["currency"].Id.ToString());
                            Console.WriteLine("Timer in Minutes: " + Item.BitCoin["timer_in_minutes"].Id.ToString());
                            Console.WriteLine("Reward: " + Item.BitCoin["reward"].Id.ToString());
                            Console.WriteLine("Is Enabled: " + Item.BitCoin["is_enabled"].Id.ToString());
                            Console.WriteLine("Creation Date: " + Item.BitCoin["creation_date"].Id.ToString());
                            Console.WriteLine("Category: " + Item.BitCoin["category"].Id.ToString());
                            Console.WriteLine("Paid Today: " + Item.BitCoin["paid_today"].Id.ToString());
                            Console.WriteLine("Total User Paid: " + Item.BitCoin["total_users_paid"].Id.ToString());
                            Console.WriteLine("Active Users: " + Item.BitCoin["active_users"].Id.ToString());
                            Console.WriteLine("Balance: " + Item.BitCoin["balance"].Id.ToString());
                            Console.WriteLine("Health: " + Item.BitCoin["health"].Id.ToString());
                            Console.WriteLine("\n");
                        }
                }
```
