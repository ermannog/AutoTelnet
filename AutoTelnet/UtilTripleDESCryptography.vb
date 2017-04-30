'https://msdn.microsoft.com/it-it/library/ms172831.aspx

Public NotInheritable Class UtilTripleDESCryptography
    Private tripleDESProvider As New System.Security.Cryptography.TripleDESCryptoServiceProvider

    Sub New(ByVal key As String)
        ' Initialize the crypto provider
        Me.tripleDESProvider.Key = Me.TruncateHash(key, Me.tripleDESProvider.KeySize \ 8)
        Me.tripleDESProvider.IV = Me.TruncateHash(String.Empty, Me.tripleDESProvider.BlockSize \ 8)
    End Sub

    Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()
        Dim sha1 As New System.Security.Cryptography.SHA1CryptoServiceProvider

        ' Hash the key
        Dim keyBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ' Truncate or pad the hash.
        ReDim Preserve hash(length - 1)
        Return hash
    End Function

    Public Function EncryptData(ByVal plaintext As String) As String
        ' Convert the plaintext string to a byte array.
        Dim plaintextBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(plaintext)
        Dim encryptedtext = String.Empty

        ' Create the stream
        Using ms As New System.IO.MemoryStream
            'Create the encoder to write to the stream.
            Using encStream As New System.Security.Cryptography.CryptoStream(
                ms, Me.tripleDESProvider.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

                ' Use the crypto stream to write the byte array to the stream.
                encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
                encStream.FlushFinalBlock()
            End Using

            encryptedtext = Convert.ToBase64String(ms.ToArray)
        End Using

        Return encryptedtext
    End Function

    Public Function DecryptData(ByVal encryptedtext As String) As String
        ' Convert the encrypted text string to a byte array.
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)
        Dim plainText = String.Empty

        ' Create the stream
        Using ms As New System.IO.MemoryStream
            ' Create the decoder to write to the stream
            Using decStream As New System.Security.Cryptography.CryptoStream(
                ms, Me.tripleDESProvider.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

                ' Use the crypto stream to write the byte array to the stream.
                decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
                decStream.FlushFinalBlock()
            End Using

            ' Convert the plaintext stream to a string
            plainText = System.Text.Encoding.Unicode.GetString(ms.ToArray)
        End Using

        Return plainText
    End Function

#Region "Metodo Encoding"
    Public Overloads Shared Function Encoding(plainText As String) As String
        Return UtilTripleDESCryptography.Encoding(My.Application.Info.CompanyName & My.Application.Info.ProductName.GetHashCode(), plainText)
    End Function

    Public Overloads Shared Function Encoding(key As String, plainText As String) As String
        Dim wrapper As New UtilTripleDESCryptography(key)
        Dim cipherText As String = wrapper.EncryptData(plainText)
        wrapper = Nothing
        Return cipherText
    End Function
#End Region

#Region "Metodo Decoding"
    Public Overloads Shared Function Decoding(cipherText As String) As String
        Return UtilTripleDESCryptography.Decoding(My.Application.Info.CompanyName & My.Application.Info.ProductName.GetHashCode(), cipherText)
    End Function

    Public Overloads Shared Function Decoding(key As String, cipherText As String) As String
        Dim wrapper As New UtilTripleDESCryptography(key)
        Dim plainText As String = wrapper.DecryptData(cipherText)
        wrapper = Nothing
        Return plainText
    End Function
#End Region
End Class
