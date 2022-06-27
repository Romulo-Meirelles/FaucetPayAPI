Imports FaucetPay.FaucetPayPost
Imports FaucetPay.FaucetPayLogs
Imports System.Text.Json

Namespace Models
    Friend Class CheckAddress

        Private Class CheckAddressItems
            Public Property status As Int32
            Public Property message As String
            Public Property payout_user_hash As String
        End Class

        Friend Function CheckHashPayout(API As String, Address As String, ByVal Logs As Boolean, Optional Currency As String = "BTC") As String
            Dim Request As String = Nothing
            Try
                Dim Post = New PostRequest()
                Dim Site As String = "https://faucetpay.io/api/v1/checkaddress"
                Request = Post.SEND(Site, "&api_key=" & API & "&address=" & Address & "&currency=" & Currency, PostRequest.Method.POST_, PostRequest.Secure.TLS12)
                Dim Deserealized = JsonSerializer.Deserialize(Of CheckAddressItems)(Request)

                If Deserealized.status <> 200 Then
                    Dim LOG As New FLog
                    If Logs = True Then
                        LOG.Loggs("Error: " & Deserealized.status & " " & Deserealized.message)
                    End If
                    Return "Error: " & Deserealized.status & " " & Deserealized.message
                End If

                If Logs = True Then
                    Dim LOG As New FLog
                    LOG.Loggs("Payout User Hash: " & Deserealized.payout_user_hash)
                End If
                Return Deserealized.payout_user_hash

            Catch ex As Exception
                Dim Deserealized = JsonSerializer.Deserialize(Of CheckAddressItems)(Request)
                Return Deserealized.message
            End Try
        End Function

        Friend Function CheckAddressExist(API As String, Address As String, ByVal Logs As Boolean, Optional Currency As String = "BTC") As Boolean
            Dim Request As String = Nothing
            Try
                Dim Post = New PostRequest()
                Dim Site As String = "https://faucetpay.io/api/v1/checkaddress"
                Request = Post.SEND(Site, "&api_key=" & API & "&address=" & Address & "&currency=" & Currency, PostRequest.Method.POST_, PostRequest.Secure.TLS12)
                Dim Deserealized = JsonSerializer.Deserialize(Of CheckAddressItems)(Request)


                If Deserealized.status <> 200 Then
                    Dim LOG As New FLog
                    If Logs = True Then
                        LOG.Loggs("Ckeck Address Exist: " & Address & " is False")
                    End If
                    Return False
                Else
                    If Logs = True Then
                        Dim LOG As New FLog
                        LOG.Loggs("Ckeck Address Exist: " & Address & " is True")
                    End If
                    Return True
                End If

            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class
End Namespace
