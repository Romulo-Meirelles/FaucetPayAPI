Imports FaucetPay.FaucetPayPost
Imports FaucetPay.FaucetPayLogs
Imports System.Text.Json
Imports System.Text
Imports System.Text.Json.Serialization

Namespace Models
    Friend Class RecentPayouts

        Private Class PayoutsItems
            Public Property status As Int32
            Public Property message As String
            Public Property rewards As RewardsSubItems()

            Class RewardsSubItems
                <JsonPropertyName("to")>
                Public Property _to As String
                <JsonPropertyName("amount")>
                Public Property amount As String
                <JsonPropertyName("date")>
                Public Property _date As String
            End Class
        End Class

        Friend Function Payouts(API As String, ByVal Logs As Boolean, Optional Currency As String = "BTC", Optional Count As String = "") As List(Of String)
            Payouts = Nothing
            Dim Request As String = Nothing

            If Int(Count) > 100 Then
                Count = Str(100)
            End If

            Try
                Dim Post = New PostRequest()
                Dim Site As String = "https://faucetpay.io/api/v1/payouts"
                Request = Post.SEND(Site, "&api_key=" & API & "&currency=" & Currency & "&count=" & Count, PostRequest.Method.POST_, PostRequest.Secure.TLS12)
                Dim Deserealized = JsonSerializer.Deserialize(Of PayoutsItems)(Request)

                If Deserealized.status <> 200 Then
                    Payouts.Add("Error: " & Deserealized.status & " " & Deserealized.message)
                    Dim LOG As New FLog
                    If Logs = True Then
                        LOG.Loggs("Error: " & Deserealized.status & " " & Deserealized.message)
                    End If
                    Return Payouts
                End If

                For I = 0 To Deserealized.rewards.Count - 1
                    Payouts.Append(Deserealized.rewards(I)._to)
                    Payouts.Append(Deserealized.rewards(I).amount)
                    Payouts.Append(Deserealized.rewards(I)._date)

                    If Logs = True Then
                        Dim LOG As New FLog
                        LOG.Loggs("To: " & Deserealized.rewards(I)._to)
                        LOG.Loggs("Amount: " & Deserealized.rewards(I).amount)
                        LOG.Loggs("Date: " & Deserealized.rewards(I)._date & vbCrLf)
                    End If
                Next

                Return Payouts
            Catch ex As Exception

                Try
                    Dim Deserealized = JsonSerializer.Deserialize(Of PayoutsItems)(Request)

                    If Deserealized.status <> 200 Then
                        Payouts.Add("Error: " & Deserealized.status & " " & Deserealized.message)
                        Dim LOG As New FLog
                        If Logs = True Then
                            LOG.Loggs("Error: " & Deserealized.status & " " & Deserealized.message)
                        End If
                        Return Payouts
                    End If

                    Payouts.Append(Deserealized.message)
                    If Logs = True Then
                        Dim LOG As New FLog
                        LOG.Loggs("Error Message: " & Deserealized.message)
                    End If
                    Return Payouts
                Catch exz As Exception
                    Payouts.Append(exz.Message)
                    If Logs = True Then
                        Dim LOG As New FLog
                        LOG.Loggs("Error Message: " & exz.Message)
                    End If
                    Return Payouts
                End Try
            End Try

        End Function
    End Class
End Namespace