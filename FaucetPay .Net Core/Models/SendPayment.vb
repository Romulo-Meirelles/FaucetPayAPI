Imports FaucetPay.FaucetPayPost
Imports FaucetPay.FaucetPayLogs
Imports System.Text.Json

Namespace Models
    Friend Class SendPayment
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

        Friend Function Send(API As String, Amount As String, To_ As String, ByVal Logs As Boolean, Optional Currency As String = "BTC", Optional Referral As Boolean = False, Optional IPAddress As String = "") As List(Of String)
            Send = New List(Of String)
            Dim Calc As String
            If Amount.Contains(".") Or Amount.Contains(",") Then
                Calc = CDbl(Amount.Replace(".", ",")) * 100000000
            Else
                Calc = Amount
            End If

            Dim Request As String = Nothing
            Try
                Dim Post = New PostRequest()
                Dim Site As String = "https://faucetpay.io/api/v1/send"
                Request = Post.SEND(Site, "&api_key=" & API & "&amont=" & Calc.Replace(",", ".") & "&to=" & To_ & "&currency=" & Currency & "&referral=" & Referral.ToString & "&ip_address=" & IPAddress, PostRequest.Method.POST_, PostRequest.Secure.TLS12)
                Dim Deserealized = JsonSerializer.Deserialize(Of SendPaymentItems)(Request)

                If Deserealized.status <> 200 Then
                    Send.Add("Error: " & Deserealized.status & " " & Deserealized.message)
                    Dim LOG As New FLog
                    If Logs = True Then
                        LOG.Loggs("Error: " & Deserealized.status & " " & Deserealized.message)
                    End If
                    Return Send
                End If

                Send.Add(Deserealized.rate_limit_remaining)
                Send.Add(Deserealized.currency)
                Send.Add(Deserealized.balance)
                Send.Add(Deserealized.balance_bitcoin)
                Send.Add(Deserealized.payout_id)
                Send.Add(Deserealized.payout_user_hash)

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
                Return Send
            Catch ex As Exception
                Try
                    Dim Deserealized = JsonSerializer.Deserialize(Of SendPaymentItems)(Request)

                    If Deserealized.status <> 200 Then
                        Send.Add("Error: " & Deserealized.status & " " & Deserealized.message)
                        Dim LOG As New FLog
                        If Logs = True Then
                            LOG.Loggs("Error: " & Deserealized.status & " " & Deserealized.message)
                        End If
                        Return Send
                    End If

                    Send.Add(Deserealized.message)
                    If Logs = True Then
                        Dim LOG As New FLog
                        LOG.Loggs("Error Message: " & Deserealized.message)
                    End If
                    Return Send
                Catch exz As Exception
                    Send.Add(exz.Message)
                    If Logs = True Then
                        Dim LOG As New FLog
                        LOG.Loggs("Error Message: " & exz.Message)
                    End If
                    Return Send
                End Try
            End Try

        End Function
    End Class
End Namespace
