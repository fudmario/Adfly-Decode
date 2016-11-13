  Public Function AdflyUrlDecode(url As String) As String
        Try
            Dim data As String = GetSource(url:=url)
            Dim rt As String() = {"ysmm = '", "'"c}
            Dim a As Integer = data.IndexOf(rt(0), StringComparison.Ordinal) + rt(0).Length + 1
            Dim b As Integer = data.Substring(a).IndexOf(rt(1), StringComparison.Ordinal) + 1
            Dim s As String = Mid(data, a, b)
            Dim m As String = ""
            Dim l As String = ""
            For i As Integer = 0 To s.Length - 1
                If (i Mod 2) Then l = s(i) + l Else m += s(i)
            Next
            Return Encoding.UTF8.GetString(Convert.FromBase64String(m + l)).Substring(2)
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    Private Function GetSource(url As String) As String
        Try
            Using wc As New WebClient()
                wc.Encoding = Encoding.UTF8
                Return wc.DownloadString(url)
            End Using
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
