Imports FaucetPay.FaucetPayPost
Imports FaucetPay.FaucetPayLogs
Imports System.Text.Json
Imports System.Text

Namespace Models
    Friend Class GetBalance
        Private Class BalanceItems
            Public Property status As Int32
            Public Property message As String
            Public Property currency As String
            Public Property balance As String
            Public Property balance_bitcoin As String

        End Class

        Private Class CurrenciesItems
            Public Property status As Int32
            Public Property message As String
            Public Property currencies As String()
            Public Property currencies_names As CurrenciesNames()

            Class CurrenciesNames
                Public Property name As String
                Public Property acronym As String
            End Class
        End Class

        Friend Function Balance(API As String, ByVal Logs As Boolean, Optional Currency As String = "BTC", Optional AllCurrencies As Boolean = False) As List(Of String)
            Balance = New List(Of String)
            Dim Request As String = Nothing
            Dim Post = New PostRequest()
            Dim Site As String
            Try
                If AllCurrencies = True Then

                    Dim ListOfCurrencies As New List(Of String)
                    Site = "https://faucetpay.io/api/v1/currencies"
                    Request = Post.SEND(Site, "&api_key=" & API, PostRequest.Method.POST_, PostRequest.Secure.TLS12)
                    Dim DeserealizedCur = JsonSerializer.Deserialize(Of CurrenciesItems)(Request)

                    If DeserealizedCur.status <> 200 Then
                        Balance.Add("Error: " & DeserealizedCur.status & " " & DeserealizedCur.message)
                        Dim LOG As New FLog
                        If Logs = True Then
                            LOG.Loggs("Error: " & DeserealizedCur.status & " " & DeserealizedCur.message)
                        End If
                        Return Balance
                    End If

                    Site = "https://faucetpay.io/api/v1/balance"
                    For Each Element In DeserealizedCur.currencies
                        Request = Post.SEND(Site, "&api_key=" & API & "&currency=" & Element, PostRequest.Method.POST_, PostRequest.Secure.TLS12)
                        Dim Deserealized = JsonSerializer.Deserialize(Of BalanceItems)(Request)

                        If Deserealized.status <> 200 Then
                            Balance.Add("Error: " & Deserealized.status & " " & Deserealized.message)
                            Dim LOG As New FLog
                            If Logs = True Then
                                LOG.Loggs("Error: " & Deserealized.status & " " & Deserealized.message)
                            End If
                            Return Balance
                        End If

                        Balance.Add(Deserealized.currency)
                        Balance.Add(Deserealized.balance)
                        Balance.Add(Deserealized.balance_bitcoin)

                        If Logs = True Then
                            Dim LOG As New FLog
                            LOG.Loggs("Currency: " & Deserealized.currency)
                            LOG.Loggs("Balance: " & Deserealized.balance)
                            LOG.Loggs("Balance Cripto: " & Deserealized.balance_bitcoin)
                        End If
                    Next

                    Return Balance
                Else
                    Site = "https://faucetpay.io/api/v1/balance"
                    Request = Post.SEND(Site, "&api_key=" & API & "&currency=" & Currency, PostRequest.Method.POST_, PostRequest.Secure.TLS12)
                    Dim Deserealized = JsonSerializer.Deserialize(Of BalanceItems)(Request)

                    If Deserealized.status <> 200 Then
                        Balance.Add("Error: " & Deserealized.status & " " & Deserealized.message)
                        Dim LOG As New FLog
                        If Logs = True Then
                            LOG.Loggs("Error: " & Deserealized.status & " " & Deserealized.message)
                        End If
                        Return Balance
                    End If

                    Balance.Add(Deserealized.currency)
                    Balance.Add(Deserealized.balance)
                    Balance.Add(Deserealized.balance_bitcoin)

                    If Logs = True Then
                            Dim LOG As New FLog
                            LOG.Loggs("Currency: " & Deserealized.currency)
                            LOG.Loggs("Balance: " & Deserealized.balance)
                            LOG.Loggs("Balance Cripto: " & Deserealized.balance_bitcoin)
                        End If
                    Return Balance
                End If
            Catch ex As Exception
                Try
                    Site = "https://faucetpay.io/api/v1/getbalance"
                    Request = Post.SEND(Site, "&api_key=" & API & "&currency=" & Currency, PostRequest.Method.POST_, PostRequest.Secure.TLS12)
                    Dim Deserealized = JsonSerializer.Deserialize(Of BalanceItems)(Request)
                    Balance.Add(Deserealized.currency)
                    Balance.Add(Deserealized.balance)
                    Balance.Add(Deserealized.balance_bitcoin)
                    If Logs = True Then
                        Dim LOG As New FLog
                        LOG.Loggs("Currency: " & Deserealized.currency)
                        LOG.Loggs("Balance: " & Deserealized.balance)
                        LOG.Loggs("Balance Cripto: " & Deserealized.balance_bitcoin)
                    End If
                    Return Balance
                Catch exs As Exception
                    Try
                        Dim Deserealized = JsonSerializer.Deserialize(Of BalanceItems)(Request)
                        Balance.Add(Deserealized.message)
                        If Logs = True Then
                            Dim LOG As New FLog
                            LOG.Loggs("Error Message: " & Deserealized.message)
                        End If
                        Return Balance
                    Catch exz As Exception
                        Balance.Add(exz.Message)
                        If Logs = True Then
                            Dim LOG As New FLog
                            LOG.Loggs("Error Message: " & exz.Message)
                        End If
                        Return Balance
                    End Try
                End Try
            End Try
        End Function
    End Class
End Namespace
