Public NotInheritable Class UtilBatchOutputFileWriter
    Private Sub New()
        MyBase.New()
    End Sub

    Private Shared fileValue As String = String.Empty
    Public Shared ReadOnly Property File As String
        Get
            Return UtilBatchOutputFileWriter.fileValue
        End Get
    End Property

    Public Const OutputModeDefault As OutputModes = OutputModes.Append
    Private Shared modeValue As OutputModes = UtilBatchOutputFileWriter.OutputModeDefault
    Public Shared ReadOnly Property Mode As OutputModes
        Get
            Return UtilBatchOutputFileWriter.modeValue
        End Get
    End Property

    Public Enum OutputModes As Integer
        Overwrite
        Append
    End Enum

    Private Shared enableValue As Boolean = False
    Public Shared ReadOnly Property Enable As Boolean
        Get
            Return UtilBatchOutputFileWriter.enableValue
        End Get
    End Property

    Private Shared writeFailedValue As Boolean = False
    Public Shared ReadOnly Property WriteFailed As Boolean
        Get
            Return UtilBatchOutputFileWriter.writeFailedValue
        End Get
    End Property


    Public Shared Sub Initialize(file As String, mode As OutputModes)
        If Not String.IsNullOrWhiteSpace(file) Then
            UtilBatchOutputFileWriter.fileValue = file
            UtilBatchOutputFileWriter.modeValue = mode
            UtilBatchOutputFileWriter.enableValue = True
        End If
    End Sub

    Public Shared Sub Write(text As String)
        If UtilBatchOutputFileWriter.writeFailedValue Then Exit Sub

        Try
            If UtilBatchOutputFileWriter.modeValue = OutputModes.Append AndAlso System.IO.File.Exists(UtilBatchOutputFileWriter.fileValue) Then
                System.IO.File.AppendAllLines(UtilBatchOutputFileWriter.fileValue, New String() {text})
            Else
                System.IO.File.WriteAllLines(UtilBatchOutputFileWriter.fileValue, New String() {text})
            End If
        Catch ex As Exception
            UtilBatchOutputFileWriter.writeFailedValue = True
            UtilMsgBox.ShowErrorException("Error writing output file " & UtilBatchOutputFileWriter.fileValue, ex, False)
        End Try
    End Sub
End Class