Imports System.Net
Imports System.Text
Imports System.IO

Namespace FaucetPayPost
    Friend Class PostRequest
        Enum Method
            POST_
            GET_
            HEAD_
            PUT_
            DELETE_
            CONNECT_
            OPTIONS_
            TRACE_
            PATCH_
        End Enum

        Enum Secure
            SSL3
            TLS
            TLS11
            TLS12
            Unsecure
        End Enum

        Friend Function SEND(ByRef URL As String, ByVal Post As String, Optional ByVal Method As Method = Method.POST_, Optional ByVal Secure As Secure = Secure.TLS12) As String

            'FAZ O SERVIÇO FICAR SEGURO CRIPTOGRAFADO
            Select Case Secure
                Case Secure.SSL3
                    ServicePointManager.SecurityProtocol = DirectCast(48, SecurityProtocolType)
                Case Secure.TLS
                    ServicePointManager.SecurityProtocol = DirectCast(192, SecurityProtocolType)
                Case Secure.TLS11
                    ServicePointManager.SecurityProtocol = DirectCast(768, SecurityProtocolType)
                Case Secure.TLS12
                    ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
                Case Secure.Unsecure
            End Select


            Try
                Dim REQUESTWEB As HttpWebRequest = DirectCast(HttpWebRequest.Create(URL), HttpWebRequest)
                Dim TempCookies As New CookieContainer
                Dim Encoding_UTF8() As Byte = Encoding.UTF8.GetBytes(Post)
                Dim DataStream As Stream
                Dim Response As WebResponse
                Dim Reader As StreamReader
                Dim ResponseFromServer As String = Nothing

                With REQUESTWEB

                    Select Case Method
                        Case Method.POST_
                            .Method = "POST"
                        Case Method.GET_
                            .Method = "GET"
                        Case Method.HEAD_
                            .Method = "HEAD"
                        Case Method.PUT_
                            .Method = "PUT"
                        Case Method.DELETE_
                            .Method = "DELETE"
                        Case Method.CONNECT_
                            .Method = "CONNECT"
                        Case Method.OPTIONS_
                            .Method = "OPTIONS"
                        Case Method.TRACE_
                            .Method = "TRACE"
                        Case Method.PATCH_
                            .Method = "PATCH"
                    End Select

                    .ContentType = "application/x-www-form-urlencoded"
                    .UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:64.0) Gecko/20100101 Firefox/64.0"
                    .KeepAlive = True
                    .CookieContainer = TempCookies
                    .ContentLength = Encoding_UTF8.Length
                    DataStream = .GetRequestStream
                    DataStream.Write(Encoding_UTF8, 0, Encoding_UTF8.Length)
                    DataStream.Close()

                    Response = .GetResponse
                    DataStream = Response.GetResponseStream()

                    Reader = New StreamReader(DataStream)
                    ResponseFromServer = Reader.ReadToEnd()
                    Reader.Close()
                    DataStream.Close()
                    Response.Close()
                    Return ResponseFromServer
                End With

            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        Friend Async Function SENDASYNC(ByVal URL As String, ByVal Post As String, Optional ByVal Method As Method = Method.POST_, Optional ByVal Secure As Secure = Secure.TLS12) As Task(Of String)

            'FAZ O SERVIÇO FICAR SEGURO CRIPTOGRAFADO
            Select Case Secure
                Case Secure.SSL3
                    ServicePointManager.SecurityProtocol = DirectCast(48, SecurityProtocolType)
                Case Secure.TLS
                    ServicePointManager.SecurityProtocol = DirectCast(192, SecurityProtocolType)
                Case Secure.TLS11
                    ServicePointManager.SecurityProtocol = DirectCast(768, SecurityProtocolType)
                Case Secure.TLS12
                    ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
                Case Secure.Unsecure
            End Select


            Try
                Dim REQUESTWEB As HttpWebRequest = DirectCast(HttpWebRequest.Create(URL), HttpWebRequest)
                Dim TempCookies As New CookieContainer
                Dim Encoding_UTF8() As Byte = Encoding.UTF8.GetBytes(Post)
                Dim DataStream As Stream
                Dim Response As WebResponse
                Dim Reader As StreamReader
                Dim ResponseFromServer As String = Nothing

                With REQUESTWEB

                    Select Case Method
                        Case Method.POST_
                            .Method = "POST"
                        Case Method.GET_
                            .Method = "GET"
                        Case Method.HEAD_
                            .Method = "HEAD"
                        Case Method.PUT_
                            .Method = "PUT"
                        Case Method.DELETE_
                            .Method = "DELETE"
                        Case Method.CONNECT_
                            .Method = "CONNECT"
                        Case Method.OPTIONS_
                            .Method = "OPTIONS"
                        Case Method.TRACE_
                            .Method = "TRACE"
                        Case Method.PATCH_
                            .Method = "PATCH"
                    End Select

                    .ContentType = "application/x-www-form-urlencoded"
                    .UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:64.0) Gecko/20100101 Firefox/64.0"
                    .KeepAlive = True
                    .CookieContainer = TempCookies
                    .ContentLength = Encoding_UTF8.Length
                    DataStream = .GetRequestStream
                    DataStream.Write(Encoding_UTF8, 0, Encoding_UTF8.Length)
                    DataStream.Close()

                    Response = Await .GetResponseAsync
                    DataStream = Response.GetResponseStream

                    Reader = New StreamReader(DataStream)
                    ResponseFromServer = Await Reader.ReadToEndAsync
                    Reader.Close()
                    DataStream.Close()
                    Response.Close()
                    Return ResponseFromServer
                End With

            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

    End Class
End Namespace

