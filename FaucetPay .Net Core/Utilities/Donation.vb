Imports System.Text.Json
Imports FaucetPay.FaucetPayPost
Imports FaucetPay.FaucetPayLogs
Namespace Utilities
    Public Class Donation
        Private Class SendPaymentItems
            Public Property status As Int32
            Public Property message As String
            Public Property rate_limit_remaining As String
            Public Property currency As String
            Public Property balance As String
            Public Property balance_bitcoin As String
            Public Property payout_id As String
            Public Property payout_user_hash As String
        End Class

        Enum Wallets
            BitCoin = 0
            BitCoinCash = 1
            Ethereum = 2
            LiteCoin = 3
            DogeCoin = 4
            DigiByte = 5
            Dash = 6
            Tron = 7
            Binance = 8
            ZCash = 9
            Solana = 10
            Tether = 11
        End Enum
        Friend Function Donation(API As String, Amount As String, ByVal Logs As Boolean, ByVal Currency As Wallets, Optional Referral As Boolean = True, Optional IPAddress As String = "") As List(Of String)
            Donation = New List(Of String)
            Dim Request As String = Nothing
            Try
                Dim Post = New PostRequest()
                Dim Site As String = "https://faucetpay.io/api/v1/send"
                Dim Wallet As String = Nothing
                Dim Cur As String = Nothing
                Select Case Currency
                    Case Wallets.BitCoin
                        Wallet = System.Text.Encoding.UTF8.GetString({&H31, &H39, &H45, &H73, &H44, &H79, &H32, &H6B, &H7A, &H53, &H31, &H6A, &H41, &H4E, &H67, &H6D, &H37, &H4D, &H35, &H68, &H64, &H59, &H76, &H67, &H68, &H32, &H36, &H75, &H4D, &H73, &H67, &H47, &H7A, &H75})
                        Cur = "BTC"
                    Case Wallets.BitCoinCash
                        Wallet = System.Text.Encoding.UTF8.GetString({&H71, &H72, &H6B, &H7A, &H70, &H6A, &H37, &H33, &H61, &H36, &H36, &H6C, &H61, &H6D, &H6A, &H70, &H39, &H76, &H70, &H71, &H30, &H71, &H6D, &H6B, &H38, &H39, &H70, &H71, &H35, &H30, &H65, &H6C, &H76, &H79, &H63, &H34, &H63, &H33, &H30, &H6E, &H73, &H7A})
                        Cur = "BCH"
                    Case Wallets.Ethereum
                        Wallet = System.Text.Encoding.UTF8.GetString({&H30, &H78, &H36, &H39, &H64, &H63, &H36, &H39, &H45, &H34, &H36, &H43, &H33, &H62, &H34, &H43, &H38, &H37, &H33, &H30, &H41, &H35, &H30, &H64, &H30, &H43, &H65, &H63, &H39, &H38, &H33, &H39, &H33, &H37, &H37, &H39, &H37, &H61, &H39, &H38, &H39, &H35})
                        Cur = "ETH"
                    Case Wallets.LiteCoin
                        Wallet = System.Text.Encoding.UTF8.GetString({&H4C, &H59, &H52, &H71, &H51, &H7A, &H61, &H37, &H70, &H4C, &H58, &H70, &H43, &H38, &H42, &H32, &H75, &H59, &H6B, &H76, &H70, &H64, &H34, &H63, &H4B, &H76, &H79, &H66, &H34, &H74, &H32, &H64, &H57, &H4B})
                        Cur = "LTC"
                    Case Wallets.DogeCoin
                        Wallet = System.Text.Encoding.UTF8.GetString({&H44, &H46, &H69, &H66, &H57, &H44, &H43, &H37, &H50, &H78, &H72, &H53, &H52, &H31, &H6A, &H54, &H6B, &H4D, &H76, &H70, &H6E, &H73, &H64, &H35, &H59, &H78, &H6E, &H5A, &H68, &H42, &H39, &H56, &H43, &H36})
                        Cur = "DOGE"
                    Case Wallets.DigiByte
                        Wallet = System.Text.Encoding.UTF8.GetString({&H64, &H67, &H62, &H31, &H71, &H65, &H36, &H33, &H72, &H74, &H65, &H73, &H73, &H75, &H6E, &H77, &H67, &H77, &H6B, &H7A, &H61, &H30, &H6B, &H6C, &H34, &H78, &H74, &H35, &H39, &H6A, &H70, &H6E, &H64, &H38, &H74, &H6C, &H70, &H6E, &H74, &H74, &H6D, &H6D, &H71})
                        Cur = "DGB"
                    Case Wallets.Dash
                        Wallet = System.Text.Encoding.UTF8.GetString({&H58, &H66, &H72, &H63, &H69, &H4A, &H52, &H39, &H54, &H46, &H54, &H57, &H37, &H53, &H63, &H38, &H4E, &H63, &H4A, &H7A, &H7A, &H73, &H37, &H61, &H54, &H52, &H35, &H41, &H4E, &H46, &H37, &H75, &H71, &H66})
                        Cur = "DASH"
                    Case Wallets.Tron
                        Wallet = System.Text.Encoding.UTF8.GetString({&H54, &H4D, &H79, &H51, &H58, &H62, &H57, &H59, &H4C, &H37, &H7A, &H65, &H6A, &H74, &H4A, &H31, &H63, &H76, &H75, &H4A, &H55, &H78, &H66, &H74, &H37, &H4A, &H43, &H62, &H72, &H63, &H70, &H50, &H78, &H6D})
                        Cur = "TRX"
                    Case Wallets.Binance
                        Wallet = System.Text.Encoding.UTF8.GetString({&H30, &H78, &H36, &H39, &H64, &H63, &H36, &H39, &H45, &H34, &H36, &H43, &H33, &H62, &H34, &H43, &H38, &H37, &H33, &H30, &H41, &H35, &H30, &H64, &H30, &H43, &H65, &H63, &H39, &H38, &H33, &H39, &H33, &H37, &H37, &H39, &H37, &H61, &H39, &H38, &H39, &H35})
                        Cur = "BNB"
                    Case Wallets.ZCash
                        Wallet = System.Text.Encoding.UTF8.GetString({&H74, &H31, &H5A, &H66, &H46, &H52, &H78, &H44, &H4D, &H54, &H72, &H52, &H4D, &H76, &H50, &H70, &H5A, &H71, &H73, &H32, &H76, &H32, &H6D, &H5A, &H79, &H6F, &H66, &H74, &H37, &H52, &H78, &H31, &H50, &H48, &H65})
                        Cur = "ZEC"
                    Case Wallets.Solana
                        Wallet = System.Text.Encoding.UTF8.GetString({&H37, &H6E, &H41, &H5A, &H74, &H4D, &H5A, &H6B, &H34, &H70, &H35, &H6E, &H53, &H6A, &H48, &H75, &H74, &H4A, &H70, &H4B, &H41, &H63, &H65, &H77, &H51, &H31, &H59, &H69, &H4A, &H6F, &H59, &H78, &H51, &H44, &H69, &H71, &H6B, &H38, &H4E, &H74, &H76, &H46, &H4A, &H72})
                        Cur = "SOL"
                    Case Wallets.Tether
                        Wallet = System.Text.Encoding.UTF8.GetString({&H54, &H4D, &H79, &H51, &H58, &H62, &H57, &H59, &H4C, &H37, &H7A, &H65, &H6A, &H74, &H4A, &H31, &H63, &H76, &H75, &H4A, &H55, &H78, &H66, &H74, &H37, &H4A, &H43, &H62, &H72, &H63, &H70, &H50, &H78, &H6D})
                        Cur = "USDT"
                End Select

                Request = Post.SEND(Site, "&api_key=" & API & "&amont=" & Amount & "&to=" & Wallet & "&currency=" & Cur & "&referral=" & Referral.ToString & "&ip_address=" & IPAddress, PostRequest.Method.POST_, PostRequest.Secure.TLS12)
                Dim Deserealized = JsonSerializer.Deserialize(Of SendPaymentItems)(Request)
                Donation.Add(Deserealized.rate_limit_remaining)
                Donation.Add(Deserealized.currency)
                Donation.Add(Deserealized.balance)
                Donation.Add(Deserealized.balance_bitcoin)
                Donation.Add(Deserealized.payout_id)
                Donation.Add(Deserealized.payout_user_hash)

                If Logs = True Then
                    Dim LOG As New FLog
                    LOG.Loggs("Rate Limit Remaining: " & Deserealized.rate_limit_remaining)
                    LOG.Loggs("Currency: " & Deserealized.currency)
                    LOG.Loggs("Balance: " & Deserealized.balance)
                    LOG.Loggs("Balance: " & Deserealized.balance)
                    LOG.Loggs("Balance Crypto: " & Deserealized.balance_bitcoin)
                    LOG.Loggs("Payout ID: " & Deserealized.payout_id)
                    LOG.Loggs("Payout User Hash: " & Deserealized.payout_user_hash)
                End If
                Return Donation
            Catch ex As Exception
                Try
                    Dim Deserealized = JsonSerializer.Deserialize(Of SendPaymentItems)(Request)
                    Donation.Add(Deserealized.message)
                    If Logs = True Then
                        Dim LOG As New FLog
                        LOG.Loggs("Error Message: " & Deserealized.message)
                    End If
                    Return Donation
                Catch exz As Exception
                    Donation.Add(exz.Message)
                    If Logs = True Then
                        Dim LOG As New FLog
                        LOG.Loggs("Error Message: " & exz.Message)
                    End If
                    Return Donation
                End Try
            End Try

        End Function
    End Class

End Namespace
