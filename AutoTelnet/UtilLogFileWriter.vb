Public NotInheritable Class UtilLogFileWriter
    Private Sub New()
        MyBase.New()
    End Sub

    Private Shared fileValue As String = String.Empty
    Public Shared ReadOnly Property File As String
        Get
            Return UtilLogFileWriter.fileValue
        End Get
    End Property

    Private Shared logTable As LogSchema.EntryDataTable = Nothing

    Public Shared ReadOnly Property LogEnabled As Boolean
        Get
            Return Not String.IsNullOrWhiteSpace(UtilLogFileWriter.fileValue)
        End Get
    End Property

    Public Const LogModeDefault As LogModes = LogModes.Overwrite
    Private Shared modeValue As LogModes = UtilLogFileWriter.LogModeDefault
    Public Shared ReadOnly Property Mode As LogModes
        Get
            Return UtilLogFileWriter.modeValue
        End Get
    End Property

    Public Enum LogModes As Integer
        Overwrite
        Append
    End Enum

    Public Enum EntryTypes As Integer
        Command
        Response
        Information
        Warning
        [Error]
    End Enum

    Private Shared Property ClearExistingFile As Boolean = False

    Private Shared writeFailedValue As Boolean = False
    Public Shared ReadOnly Property WriteFailed As Boolean
        Get
            Return UtilLogFileWriter.writeFailedValue
        End Get
    End Property

    Private Shared EncryptCommandAndResponseEntries As Boolean = False

    Public Shared Sub Enable(file As String, mode As LogModes, encryptCommandAndResponseEntries As Boolean)
        UtilLogFileWriter.fileValue = file
        UtilLogFileWriter.modeValue = mode

        If mode = LogModes.Overwrite Then UtilLogFileWriter.ClearExistingFile = True

        UtilLogFileWriter.writeFailedValue = False
        UtilLogFileWriter.EncryptCommandAndResponseEntries = encryptCommandAndResponseEntries
    End Sub

    Public Shared Sub Disable()
        UtilLogFileWriter.fileValue = String.Empty
        UtilLogFileWriter.modeValue = UtilLogFileWriter.LogModeDefault
        UtilLogFileWriter.ClearExistingFile = False
        UtilLogFileWriter.writeFailedValue = False
        UtilLogFileWriter.EncryptCommandAndResponseEntries = False

        If UtilLogFileWriter.logTable IsNot Nothing Then
            UtilLogFileWriter.logTable.Dispose()
            UtilLogFileWriter.logTable = Nothing
        End If
    End Sub

    Public Shared Sub WriteNewEntry(type As UtilLogFileWriter.EntryTypes, text As String)
        If UtilLogFileWriter.writeFailedValue Then Exit Sub

        Try
            If UtilLogFileWriter.logTable Is Nothing Then
                UtilLogFileWriter.logTable = New LogSchema.EntryDataTable

                If Not UtilLogFileWriter.ClearExistingFile AndAlso System.IO.File.Exists(UtilLogFileWriter.fileValue) Then
                    UtilLogFileWriter.logTable.ReadXml(UtilLogFileWriter.fileValue)
                End If
            End If

            Dim entryText = text
            If UtilLogFileWriter.EncryptCommandAndResponseEntries Then
                If type = EntryTypes.Command OrElse type = EntryTypes.Response Then
                    entryText = UtilTripleDESCryptography.Encoding(entryText)
                End If
            End If

            UtilLogFileWriter.logTable.AddEntryRow(Now, System.Enum.GetName(GetType(UtilLogFileWriter.EntryTypes), type), entryText)
            UtilLogFileWriter.logTable.WriteXml(UtilLogFileWriter.fileValue, XmlWriteMode.IgnoreSchema)
        Catch ex As Exception
            UtilLogFileWriter.writeFailedValue = True
            UtilMsgBox.ShowErrorException("Error writing log file " & UtilLogFileWriter.fileValue, ex, False)
        End Try
    End Sub
End Class