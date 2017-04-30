Imports System.Windows.Forms

Public Class LogDialog

    Public Property LogFile As String = String.Empty

    Public Property LogCommandAndResponseEntriesEncrypted As Boolean = False

    Private Sub LogDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Text = String.Format(Me.Text, Me.LogFile)
            If System.IO.File.Exists(Me.LogFile) Then
                Using table As New LogSchema.EntryDataTable
                    table.ReadXml(Me.LogFile)
                    table.AcceptChanges()
                    For Each row As LogSchema.EntryRow In table.Rows
                        Dim entryText = row.Text

                        If Me.LogCommandAndResponseEntriesEncrypted Then
                            If row.Type = System.Enum.GetName(GetType(UtilLogFileWriter.EntryTypes), UtilLogFileWriter.EntryTypes.Command) OrElse
                                                       row.Type = System.Enum.GetName(GetType(UtilLogFileWriter.EntryTypes), UtilLogFileWriter.EntryTypes.Response) Then
                                entryText = UtilTripleDESCryptography.Decoding(row.Text)
                            End If
                        End If

                        Me.grdMain.Rows.Add(New String() {
                                            row._Date.ToShortDateString() & " " & row._Date.ToShortTimeString(),
                                            row.Type,
                                            entryText})
                    Next
                End Using
            Else
                UtilMsgBox.ShowError(String.Format("Log file {0} not found.", Me.LogFile), False)
            End If
        Catch ex As Exception
            UtilMsgBox.ShowErrorException(ex, False)
        End Try

        Me.btnCopy.Enabled = Me.grdMain.Rows.Count > 0
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Clipboard.SetDataObject(Me.grdMain.GetClipboardContent())
    End Sub

    Private Sub btnCancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
