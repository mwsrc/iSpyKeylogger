Public Class NativeMethods

    Public Shared Function RotateRight(ByVal [string] As [String]) As [String]
        Dim [retstr] As [String] = [string].Empty
        For i As [Int32] = 0 To [string].Length - 1 Step 1
            [retstr] += Chr(Asc([string].Chars(i)) + 5)
        Next
        Return [retstr]
    End Function
    Public Shared Function RotateLeft(ByVal Str As String) As String
        Dim Output As String = String.Empty
        For I As Int32 = 0 To Str.Length - 1
            Output &= Chr(Asc(Str.Chars(I)) - 5)
        Next
        Return Output
    End Function

End Class