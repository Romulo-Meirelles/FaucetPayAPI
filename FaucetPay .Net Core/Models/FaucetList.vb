Imports FaucetPay.FaucetPayPost
Imports FaucetPay.FaucetPayLogs
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Serialization
Imports Newtonsoft.Json.Converters
Imports Newtonsoft.Json.Linq
Imports System.Text.Json.Serialization

Namespace Models
    Friend Class FaucetList
        Private Class FaucetItems

            <JsonPropertyName("status")>
            Public Property status As Int32

            <JsonPropertyName("message")>
            Public Property message As String

            <JsonPropertyName("list_data")>
            Public Property list_data As Dictionary(Of String, Object)
        End Class
        Private Class Items

            Public Property id As Int32
            Public Property name As String
            Public Property url As String
            Public Property owner_id As Int32
            Public Property owner_name As String
            Public Property currency As String
            Public Property timer_in_minutes As Int32
            Public Property reward As Int32
            Public Property is_enabled As Int32
            Public Property creation_date As String
            Public Property category As String
            Public Property paid_today As String
            Public Property total_users_paid As Int32
            Public Property active_users As String
            Public Property balance As String
            Public Property health As Int32
        End Class

        Friend Async Function ListAsync(ByVal Logs As Boolean, Optional API As String = "") As Task(Of Dictionary(Of String, String()))
            Dim MyList = New Dictionary(Of String, String())
            Dim Request As String = Nothing
            Try
                Dim Post = New PostRequest()
                Dim Site As String = "https://faucetpay.io/api/listv1/faucetlist"
                Request = Await Post.SENDASYNC(Site, "&api_key=" & API, PostRequest.Method.POST_, PostRequest.Secure.TLS12)
                'Dim Json As String = IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\listfaucets.json")

                Dim Deserealized = JsonConvert.DeserializeObject(Of Object)(Request)

                If Deserealized("status").ToString <> "200" Then
                    MyList.Add("Error: ", {Deserealized("status").ToString & " " & Deserealized("message").ToString})
                    Dim LOG As New FLog
                    If Logs = True Then
                        LOG.Loggs("Error: " & Deserealized("status").ToString & " " & Deserealized("message").ToString)
                    End If
                    Return MyList
                End If


                For Each MyItem As JProperty In Deserealized("list_data")
                    For Each MyCurr As JProperty In Deserealized("list_data")(MyItem.Name)
                        For Each MyNumber As JProperty In Deserealized("list_data")(MyItem.Name)(MyCurr.Name)
                            Dim Des = JsonConvert.DeserializeObject(Of Items)(Deserealized("list_data")(MyItem.Name)(MyCurr.Name)(MyNumber.Name).ToString)
                            MyList.Add(MyCurr.Name & "_" & MyNumber.Name, {Des.id, Des.name, Des.url, Des.owner_id, Des.owner_name, Des.currency, Des.timer_in_minutes, Des.reward, Des.is_enabled, Des.creation_date, Des.category, Des.paid_today, Des.total_users_paid, Des.active_users, Des.balance, Des.health})
                        Next
                    Next
                Next

                Return MyList
            Catch ex As Exception

                MyList.Add("Error: ", {ex.Message.ToString})
                Dim LOG As New FLog
                If Logs = True Then
                    LOG.Loggs("Error: " & ex.Message.ToString)
                End If
                Return MyList
            End Try

        End Function

        Friend Function List(ByVal Logs As Boolean, Optional API As String = "") As Dictionary(Of String, String())
            Dim MyList = New Dictionary(Of String, String())
            Dim Request As String = Nothing
            Try
                Dim Post = New PostRequest()
                Dim Site As String = "https://faucetpay.io/api/listv1/faucetlist"
                Request = Post.SEND(Site, "&api_key=" & API, PostRequest.Method.POST_, PostRequest.Secure.TLS12)
                'Request = IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\listfaucets.json")

                Dim Deserealized = JsonConvert.DeserializeObject(Of Object)(Request)

                If Deserealized("status").ToString <> "200" Then
                    MyList.Add("Error: ", {Deserealized("status").ToString & " " & Deserealized("message").ToString})
                    Dim LOG As New FLog
                    If Logs = True Then
                        LOG.Loggs("Error: " & Deserealized("status").ToString & " " & Deserealized("message").ToString)
                    End If
                    Return MyList
                End If


                For Each MyItem As JProperty In Deserealized("list_data")
                    For Each MyCurr As JProperty In Deserealized("list_data")(MyItem.Name)
                        For Each MyNumber As JProperty In Deserealized("list_data")(MyItem.Name)(MyCurr.Name)
                            Dim Des = JsonConvert.DeserializeObject(Of Items)(Deserealized("list_data")(MyItem.Name)(MyCurr.Name)(MyNumber.Name).ToString)
                            MyList.Add(MyCurr.Name & "_" & MyNumber.Name, {Des.id, Des.name, Des.url, Des.owner_id, Des.owner_name, Des.currency, Des.timer_in_minutes, Des.reward, Des.is_enabled, Des.creation_date, Des.category, Des.paid_today, Des.total_users_paid, Des.active_users, Des.balance, Des.health})
                        Next
                    Next
                Next

                Return MyList
            Catch ex As Exception

                MyList.Add("Error: ", {ex.Message.ToString})
                Dim LOG As New FLog
                If Logs = True Then
                    LOG.Loggs("Error: " & ex.Message.ToString)
                End If
                Return MyList
            End Try

        End Function

    End Class
End Namespace
