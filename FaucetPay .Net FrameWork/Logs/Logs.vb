Namespace FaucetPayLogs
    Friend Class FLog
        Friend Sub Loggs(Logs As String)
            Try
                Dim Folder As String = Environment.CurrentDirectory & "\Logs"
                Dim DateFile As String = DateTime.Now.ToShortDateString.Replace("\", "-").Replace("/", "-")
                Dim DateServer As String = DateTime.Now
                Dim FileLog As String = Folder & "\Log_" & DateFile & ".log"
                Dim Message As String = DateServer & ": " & Logs


                If Not IO.Directory.Exists(Folder) Then
                    IO.Directory.CreateDirectory(Folder)
                End If

                If IO.File.Exists(FileLog) Then
                    IO.File.AppendAllText(FileLog, vbCrLf & Message)
                Else
                    IO.File.AppendAllText(FileLog, Message)
                End If


            Catch ex As Exception
            End Try

        End Sub
    End Class
End Namespace
