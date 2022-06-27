Imports FaucetPay.FaucetPayPost
Imports FaucetPay.FaucetPayLogs
Imports System.Text.Json

Namespace Models
    Friend Class GetListOfCurrencies
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

        Friend Function GetListCurrencies(API As String, ByVal Logs As Boolean) As List(Of String)
            Dim Request As String = Nothing
            GetListCurrencies = New List(Of String)
            Try
                Dim Post = New PostRequest()
                Dim Site As String = "https://faucetpay.io/api/v1/currencies"
                Request = Post.SEND(Site, "&api_key=" & API, PostRequest.Method.POST_, PostRequest.Secure.TLS12)
                Dim Deserealized = JsonSerializer.Deserialize(Of CurrenciesItems)(Request)

                If Deserealized.status <> 200 Then
                    GetListCurrencies.Add("Error: " & Deserealized.status & " " & Deserealized.message)
                    Dim LOG As New FLog
                    If Logs = True Then
                        LOG.Loggs("Error: " & Deserealized.status & " " & Deserealized.message)
                    End If
                    Return GetListCurrencies
                End If

                For I = 0 To Deserealized.currencies.Count - 1
                    GetListCurrencies.Add(Deserealized.currencies(I))
                    If Logs = True Then
                        Dim LOG As New FLog
                        LOG.Loggs("Currencies Supported: " & Deserealized.currencies(I))
                    End If
                Next

                Return GetListCurrencies
            Catch ex As Exception
                Try
                    Dim Deserealized = JsonSerializer.Deserialize(Of CurrenciesItems)(Request)

                    If Deserealized.status <> 200 Then
                        GetListCurrencies.Add("Error: " & Deserealized.status & " " & Deserealized.message)
                        Dim LOG As New FLog
                        If Logs = True Then
                            LOG.Loggs("Error: " & Deserealized.status & " " & Deserealized.message)
                        End If
                        Return GetListCurrencies
                    End If

                    Return GetListCurrencies

                Catch exz As Exception
                    GetListCurrencies.Add(exz.Message)
                    If Logs = True Then
                        Dim LOG As New FLog
                        LOG.Loggs("Error Message: " & exz.Message)
                    End If
                    Return GetListCurrencies
                End Try
            End Try
        End Function

        Friend Function GetListCurrenciesNames(API As String, ByVal Logs As Boolean) As List(Of String)
            Dim Request As String = Nothing
            GetListCurrenciesNames = New List(Of String)

            Try
                Dim Post = New PostRequest()
                Dim Site As String = "https://faucetpay.io/api/v1/currencies"
                Request = Post.SEND(Site, "&api_key=" & API, PostRequest.Method.POST_, PostRequest.Secure.TLS12)
                Dim Deserealized = JsonSerializer.Deserialize(Of CurrenciesItems)(Request)

                If Deserealized.status <> 200 Then
                    GetListCurrenciesNames.Add("Error: " & Deserealized.status & " " & Deserealized.message)
                    Dim LOG As New FLog
                    If Logs = True Then
                        LOG.Loggs("Error: " & Deserealized.status & " " & Deserealized.message)
                    End If
                    Return GetListCurrenciesNames
                End If

                For I = 0 To Deserealized.currencies_names.Count - 1
                    GetListCurrenciesNames.Add(Deserealized.currencies_names(I).name)
                    If Logs = True Then
                        Dim LOG As New FLog
                        LOG.Loggs("Currencies Names Supported: " & Deserealized.currencies(I))
                    End If
                Next
                Return GetListCurrenciesNames

            Catch ex As Exception
                Try
                    Dim Deserealized = JsonSerializer.Deserialize(Of CurrenciesItems)(Request)
                    GetListCurrenciesNames.Add(Deserealized.message)

                    If Deserealized.status <> 200 Then
                        GetListCurrenciesNames.Add("Error: " & Deserealized.status & " " & Deserealized.message)
                        Dim LOG As New FLog
                        If Logs = True Then
                            LOG.Loggs("Error: " & Deserealized.status & " " & Deserealized.message)
                        End If
                        Return GetListCurrenciesNames
                    End If

                    If Logs = True Then
                        Dim LOG As New FLog
                        LOG.Loggs("Error Message: " & Deserealized.message)
                    End If
                    Return GetListCurrenciesNames

                Catch exz As Exception
                    GetListCurrenciesNames.Add(exz.Message)
                    If Logs = True Then
                        Dim LOG As New FLog
                        LOG.Loggs("Error Message: " & exz.Message)
                    End If
                    Return GetListCurrenciesNames
                End Try
            End Try
        End Function
    End Class
End Namespace
