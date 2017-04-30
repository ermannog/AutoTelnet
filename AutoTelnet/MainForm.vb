Public Class MainForm
    Private FormInitializing As Boolean = True
    Private CurrentScriptFile As String = String.Empty
    Private CurrentAutoTelnetScript As AutoTelnetScript = Nothing
    Private ScriptRunnig As Boolean = False

    Private Sub MailForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Inizializzazioni
        Me.Icon = Util.GetApplicationIcon()
        Me.cmbSendEndOfLine.BindEnum(GetType(TelnetClient.EndOfLineValues), False, False)
        Me.cmbLogMode.BindEnum(GetType(UtilLogFileWriter.LogModes), False, False)
        Me.cmbLogMode.SelectedValue = UtilLogFileWriter.LogModeDefault
        Me.cmbBatchOuputMode.BindEnum(GetType(UtilBatchOutputFileWriter.OutputModes), False, False)
        Me.cmbBatchOuputMode.SelectedValue = UtilBatchOutputFileWriter.OutputModeDefault


        Me.FormInitializing = False

        If String.IsNullOrWhiteSpace(My.Application.StartupConfigurationFile) Then
            Me.nudPort.Value = TelnetSession.DefaultTelnetPort
            Me.cmbSendEndOfLine.SelectedValue = TelnetSession.EndOfLineDefault
            Me.nudDelayReadTime.Value = TelnetSession.DelayReadTimeDefault
        Else
            Try
                Me.btnOpen.Enabled = False
                Me.OpenScript(My.Application.StartupConfigurationFile)
                Me.mniActionsRun.PerformClick()
            Catch ex As Exception
                UtilMsgBox.ShowErrorException(ex, False)
            End Try
        End If

        Me.SetFormText()

        'Set ToolTip
        Me.tipMain.SetToolTip(Me.txtHost, "Host name or IP address, in this field is possible use parameters")
        Me.tipMain.SetToolTip(Me.txtScript, "Script commands, in this field is possible use parameters")
        Me.tipMain.SetToolTip(Me.txtLogFile, "Path of log file, in this field is possible use parameters")
        Me.tipMain.SetToolTip(Me.txtBatchSuccessfulOutputText, "Output returned in a batch successful execution, if is not set default text will be used, in this field is possible use parameters")
        Me.tipMain.SetToolTip(Me.txtBatchFailedOutputText, "Output returned in a batch failed execution, if is not set default text will be used, in this field is possible use parameters")
        Me.tipMain.SetToolTip(Me.txtBatchOutputFile, "Path of batch execution output file, in this field is possible use parameters")
    End Sub

    Private Sub SetFormText()
        Me.Text = My.Application.Info.AssemblyName & " " &
            String.Format("{0}.{1}.{2}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build) & " - " &
            My.Application.Info.Description

        If Not String.IsNullOrWhiteSpace(Me.CurrentScriptFile) Then
            Me.Text &= " [" & Me.CurrentScriptFile & "]"
        End If
    End Sub

#Region "Gestione Menu File"
    Private Sub mniFileNew_Click(sender As Object, e As EventArgs) Handles mniFileNew.Click
        Me.SetWaitCursor(True)

        Try
            Me.txtOutput.ResetText()

            Me.CurrentScriptFile = String.Empty
            Me.CurrentAutoTelnetScript = New AutoTelnetScript()
            Me.FillControlsFromData()
        Catch ex As Exception
            UtilMsgBox.ShowErrorException(ex, False)
        End Try

        Me.SetWaitCursor(False)
    End Sub

    Private Sub mniFileOpen_Click(sender As Object, e As EventArgs) Handles mniFileOpen.Click
        Me.SetWaitCursor(True)

        'Show Dialog Openfile
        Try
            If Me.ofdScript.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Me.OpenScript(Me.ofdScript.FileName)
            End If
        Catch ex As Exception
            UtilMsgBox.ShowErrorException(ex, False)
        End Try

        'Reimpostazione Form Text
        Me.SetFormText()

        Me.SetWaitCursor(False)
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Me.mniFileOpen.PerformClick()
    End Sub

    Private Sub OpenScript(file As String)
        'Read File
        Me.CurrentAutoTelnetScript = New AutoTelnetScript()
        Me.CurrentAutoTelnetScript.Deserialize(file)

        'Fill Controls
        Me.FillControlsFromData()

        'Set script file corrente
        Me.CurrentScriptFile = file
    End Sub

    Private Sub mniFileSaveAs_Click(sender As Object, e As EventArgs) Handles mniFileSaveAs.Click
        Me.SetWaitCursor(True)

        Try
            If Not String.IsNullOrWhiteSpace(Me.CurrentScriptFile) Then
                Me.sfdScript.FileName = Me.CurrentScriptFile
            End If

            If Me.sfdScript.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                'Update Data
                Me.LoadDataFromControls()

                'Write file
                Me.CurrentAutoTelnetScript.Serialize(Me.sfdScript.FileName)

                'Set script file corrente
                Me.CurrentScriptFile = Me.sfdScript.FileName

                'Reimpostazione Form Text
                Me.SetFormText()
            End If
        Catch ex As Exception
            UtilMsgBox.ShowErrorException(ex, False)
        End Try

        Me.SetWaitCursor(False)
    End Sub

    Private Sub mniFileSave_Click(sender As Object, e As EventArgs) Handles mniFileSave.Click
        If String.IsNullOrWhiteSpace(Me.CurrentScriptFile) Then
            Me.mniFileSaveAs.PerformClick()
        Else
            Me.SetWaitCursor(True)
            Try
                Me.SaveScript(Me.CurrentScriptFile)
            Catch ex As Exception
                UtilMsgBox.ShowErrorException(ex, False)
            End Try
            Me.SetWaitCursor(False)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.mniFileSave.PerformClick()
    End Sub

    Private Sub SaveScript(file As String)
        'Update Data
        Me.LoadDataFromControls()

        'Write file
        Me.CurrentAutoTelnetScript.Serialize(file)

        'Set script file corrente
        Me.CurrentScriptFile = file

        'Reimpostazione Form Text
        Me.SetFormText()
    End Sub

    Private Sub ActivateSave(enabled As Boolean)
        Me.mniFileSave.Enabled = enabled
        Me.mniFileSaveAs.Enabled = enabled

        Me.btnSave.Enabled = Me.mniFileSave.Enabled
        Me.tlsMain.Refresh()
    End Sub

    Private Sub mniFileExit_Click(sender As Object, e As EventArgs) Handles mniFileExit.Click
        System.Environment.Exit(0)
    End Sub
#End Region

#Region "Gestione Controlli"
    Private Sub txtHost_txtScript_TextChanged(sender As Object, e As EventArgs) Handles txtHost.TextChanged, txtScript.TextChanged
        Me.ActivateRun(Not String.IsNullOrWhiteSpace(Me.txtHost.Text))
        Me.ActivateSave(Not String.IsNullOrWhiteSpace(Me.txtHost.Text))
    End Sub

    Private Sub chkSendUser_CheckedChanged(sender As Object, e As EventArgs) Handles chkSendUser.CheckedChanged
        Me.txtUser.Enabled = Me.chkSendUser.Checked
        If Me.chkSendUser.Checked Then Me.txtUser.Focus()
    End Sub

    Private Sub chkSendPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkSendPassword.CheckedChanged
        Me.txtPassword.Enabled = Me.chkSendPassword.Checked
        If Me.chkSendPassword.Checked Then Me.txtPassword.Focus()
    End Sub
#End Region

#Region "Gestione Log"
    Private Sub ActivateLogViewer()
        Me.mniToolsLogViewer.Enabled = Me.chkLogFile.Checked AndAlso Not String.IsNullOrWhiteSpace(Me.txtLogFile.Text)
        Me.btnLogViewer.Enabled = Me.mniToolsLogViewer.Enabled
        Me.tlsMain.Refresh()
    End Sub

    Private Sub mniToolsLogViewer_Click(sender As Object, e As EventArgs) Handles mniToolsLogViewer.Click
        Me.SetWaitCursor(True)
        Try
            Using dlg As New LogDialog
                'dlg.LogFile = Me.txtLogFile.Text
                Dim parameters = Me.GetParametersValuesFromControls()
                Dim logFile = Util.ReplaceParameter(Me.txtLogFile.Text, Me.CurrentAutoTelnetScript, parameters)
                dlg.LogFile = logFile
                dlg.LogCommandAndResponseEntriesEncrypted = Me.chkLogEncryptCommandResponseEntries.Checked
                dlg.ShowDialog(Me)
            End Using
        Catch ex As Exception
            UtilMsgBox.ShowErrorException(ex, False)
        End Try
        Me.SetWaitCursor(False)
    End Sub

    Private Sub btnLogViewer_Click(sender As Object, e As EventArgs) Handles btnLogViewer.Click
        Me.mniToolsLogViewer.PerformClick()
    End Sub

    Private Sub chkLog_CheckedChanged(sender As Object, e As EventArgs) Handles chkLogFile.CheckedChanged
        Me.txtLogFile.Enabled = Me.chkLogFile.Checked
        Me.btnBrowseLogFile.Enabled = Me.chkLogFile.Checked
        Me.lblLogMode.Enabled = Me.chkLogFile.Checked
        Me.cmbLogMode.Enabled = Me.chkLogFile.Checked
        Me.chkLogEncryptCommandResponseEntries.Enabled = Me.chkLogFile.Checked
        Me.chkLogOnlyExecutionStatus.Enabled = Me.chkLogFile.Checked

        If Me.chkLogFile.Checked AndAlso String.IsNullOrWhiteSpace(Me.txtLogFile.Text) Then
            Me.txtLogFile.Text = System.IO.Path.Combine(
                System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Application.ProductName & ".log")
        End If

        Me.ActivateLogViewer()
    End Sub

    Private Sub txtLogFile_TextChanged(sender As Object, e As EventArgs) Handles txtLogFile.TextChanged
        Me.ActivateLogViewer()
    End Sub

    Private Sub btnBrowseLogFile_Click(sender As Object, e As EventArgs) Handles btnBrowseLogFile.Click
        Me.SetWaitCursor(True)

        Try
            If Not String.IsNullOrWhiteSpace(Me.txtLogFile.Text) Then
                Me.sfdLog.InitialDirectory = System.IO.Path.GetFullPath(Me.txtLogFile.Text)
                Me.sfdLog.FileName = System.IO.Path.GetFileName(Me.txtLogFile.Text)
            End If

            If Me.sfdLog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Me.txtLogFile.Text = Me.sfdLog.FileName
            End If
        Catch ex As Exception
            UtilMsgBox.ShowErrorException(ex, False)
        End Try

        Me.SetWaitCursor(False)
    End Sub
#End Region

#Region "Gestione Batch"
    Private Sub chkBatchOutputFile_CheckedChanged(sender As Object, e As EventArgs) Handles chkBatchOutputFile.CheckedChanged
        Me.txtBatchOutputFile.Enabled = Me.chkBatchOutputFile.Checked
        Me.btnBrowseBatchOutputFile.Enabled = Me.chkBatchOutputFile.Checked
        Me.lblBatchOutputMode.Enabled = Me.chkBatchOutputFile.Checked
        Me.cmbBatchOuputMode.Enabled = Me.chkBatchOutputFile.Checked

        If Me.chkBatchOutputFile.Checked AndAlso String.IsNullOrWhiteSpace(Me.txtBatchOutputFile.Text) Then
            Me.txtBatchOutputFile.Text = System.IO.Path.Combine(
                System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Application.ProductName & ".out")
        End If
    End Sub

    Private Sub btnBrowseBatchOutputFile_Click(sender As Object, e As EventArgs) Handles btnBrowseBatchOutputFile.Click
        Me.SetWaitCursor(True)

        Try
            If Not String.IsNullOrWhiteSpace(Me.txtBatchOutputFile.Text) Then
                Me.sfdBatchOutputFile.InitialDirectory = System.IO.Path.GetFullPath(Me.txtBatchOutputFile.Text)
                Me.sfdBatchOutputFile.FileName = System.IO.Path.GetFileName(Me.txtBatchOutputFile.Text)
            End If

            If Me.sfdBatchOutputFile.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Me.txtBatchOutputFile.Text = Me.sfdBatchOutputFile.FileName
            End If
        Catch ex As Exception
            UtilMsgBox.ShowErrorException(ex, False)
        End Try

        Me.SetWaitCursor(False)
    End Sub
#End Region

#Region "Gestione Menu Actions"
    Private Sub ActivateRun(enabled As Boolean)
        Me.mniActionsRun.Enabled = enabled
        Me.mniActionsStop.Enabled = Not enabled AndAlso Me.ScriptRunnig

        Me.btnRun.Enabled = Me.mniActionsRun.Enabled
        Me.btnStop.Enabled = Me.mniActionsStop.Enabled
        Me.tlsMain.Refresh()
    End Sub

    Private Sub mniActionsRun_Click(sender As Object, e As EventArgs) Handles mniActionsRun.Click
        'Set Wait Cursor
        Me.SetWaitCursor(True)

        'Set Flag Running
        Me.ScriptRunnig = True

        'Gestione ToolBar
        Me.ActivateRun(False)

        'Reset Output
        Me.txtOutput.ResetText()

        'Creazione oggetti sessione Telnet
        Try
            'Aggiornamento Dati da  Controlli
            Me.LoadDataFromControls()
            Dim parameters = Me.GetParametersValuesFromControls()

            'Gestione abilitazione Log
            Dim logFile = Util.ReplaceParameter(Me.CurrentAutoTelnetScript.LogFile, Me.CurrentAutoTelnetScript, parameters)
            If Not String.IsNullOrWhiteSpace(logFile) Then
                UtilLogFileWriter.Enable(logFile, Me.CurrentAutoTelnetScript.LogMode, Me.CurrentAutoTelnetScript.LogCommandAndResponseEntriesEncrypted)
            Else
                UtilLogFileWriter.Disable()
            End If

            'Creazione telnet session
            Me.bkwScriptSession = Util.CreateTelnetSession(Me.CurrentAutoTelnetScript, parameters)
            Me.bkwScriptCommands = Util.CreateTelnetSessionCommands(Me.CurrentAutoTelnetScript, parameters)

            'Aggiunta handler eventi
            AddHandler Me.bkwScriptSession.OutputInformationAdded, AddressOf Me.bkwScriptSession_OutputInformationAdded
            AddHandler Me.bkwScriptSession.OutputCommandAdded, AddressOf Me.bkwScriptSession_OutputCommandAdded
            AddHandler Me.bkwScriptSession.OutputResponseAdded, AddressOf Me.bkwScriptSession_OutputResponseAdded
            AddHandler Me.bkwScriptSession.OutputErrorAdded, AddressOf Me.bkwScriptSession_OutputErrorAdded
        Catch ex As Exception
            UtilMsgBox.ShowErrorException(ex, False)

            Me.ActivateRun(True)
            Me.SetWaitCursor(False)
        End Try

        'Avvio Backgroud Worker
        Me.bkwScript.RunWorkerAsync()
    End Sub

    Private Sub mniActionsStop_Click(sender As Object, e As EventArgs) Handles mniActionsStop.Click
        Me.bkwScriptSession.StopExecuteCommandsFlag = True
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        Me.mniActionsRun.PerformClick()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Me.mniActionsStop.PerformClick()
    End Sub
#End Region

#Region "Gestione Menu Help"
    Private Sub mniHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniHelpAbout.Click
        Using frm As New AboutBox
            frm.ShowDialog(Me)
        End Using
    End Sub
#End Region

#Region "Gestione Dati"
    Private Sub LoadDataFromControls()
        Me.CurrentAutoTelnetScript = New AutoTelnetScript()

        'Commands
        Me.CurrentAutoTelnetScript.Host = Me.txtHost.Text

        Me.CurrentAutoTelnetScript.SendUser = Me.chkSendUser.Checked
        If Me.chkSendUser.Checked Then
            Me.CurrentAutoTelnetScript.User = Me.txtUser.Text
        End If

        Me.CurrentAutoTelnetScript.SendPassword = Me.chkSendPassword.Checked
        If Me.chkSendPassword.Checked Then
            Me.CurrentAutoTelnetScript.PasswordDecrypted = Me.txtPassword.Text
        End If

        Me.CurrentAutoTelnetScript.Text = Me.txtScript.Text

        Me.CurrentAutoTelnetScript.SendEndOfLine = DirectCast(Me.cmbSendEndOfLine.SelectedValue, TelnetClient.EndOfLineValues)

        'Parameters (Nome e DefaultValue)
        For Each r As System.Windows.Forms.DataGridViewRow In Me.grdParameters.Rows
            If r.Cells(Me.colParametersName.Index).Value IsNot Nothing AndAlso
                Not String.IsNullOrWhiteSpace(r.Cells(Me.colParametersName.Index).Value.ToString()) Then
                Dim name = r.Cells(Me.colParametersName.Index).Value.ToString()

                Dim defaultValue = String.Empty
                If r.Cells(Me.colParametersDefaultValue.Index).Value IsNot Nothing AndAlso
                Not String.IsNullOrWhiteSpace(r.Cells(Me.colParametersDefaultValue.Index).Value.ToString()) Then
                    defaultValue = r.Cells(Me.colParametersDefaultValue.Index).Value.ToString()
                End If

                Me.CurrentAutoTelnetScript.Parameters.Add(name, defaultValue)
            End If
        Next

        'Settings - Connection
        Me.CurrentAutoTelnetScript.Port = System.Convert.ToUInt16(Me.nudPort.Value)
        Me.CurrentAutoTelnetScript.DelayReadTime = System.Convert.ToUInt16(Me.nudDelayReadTime.Value)
        Me.CurrentAutoTelnetScript.AttemptsRetryReading = System.Convert.ToUInt16(Me.nudAttemptsRetryReading.Value)

        'Settings - Security
        Me.CurrentAutoTelnetScript.Encrypted = Me.chkEncryptAutoTelnetScriptFile.Checked

        'Settings - Output
        Me.CurrentAutoTelnetScript.RemoveRemoveANSIEscapeSequencesFromOutput = Me.chkRemoveRemoveANSIEscapeSequencesFromOutput.Checked

        'Settings - Log
        If Me.chkLogFile.Checked AndAlso Not String.IsNullOrWhiteSpace(Me.txtLogFile.Text) Then
            Me.CurrentAutoTelnetScript.LogFile = Me.txtLogFile.Text
            Me.CurrentAutoTelnetScript.LogMode = DirectCast(Me.cmbLogMode.SelectedValue, UtilLogFileWriter.LogModes)
            Me.CurrentAutoTelnetScript.LogCommandAndResponseEntriesEncrypted = Me.chkLogEncryptCommandResponseEntries.Checked
        End If

        'Settings - Batch
        Me.CurrentAutoTelnetScript.BatchSuccessfulOutputText = Me.txtBatchSuccessfulOutputText.Text
        Me.CurrentAutoTelnetScript.BatchFailedOutputText = Me.txtBatchFailedOutputText.Text
        If Me.chkBatchOutputFile.Checked AndAlso Not String.IsNullOrWhiteSpace(Me.txtBatchOutputFile.Text) Then
            Me.CurrentAutoTelnetScript.BatchOutputFile = Me.txtBatchOutputFile.Text
            Me.CurrentAutoTelnetScript.BatchOutputMode = DirectCast(Me.cmbBatchOuputMode.SelectedValue, UtilBatchOutputFileWriter.OutputModes)
        End If

        'Notes
        If String.IsNullOrWhiteSpace(Me.txtNotes.Text) Then
            Me.CurrentAutoTelnetScript.NotesRtf = String.Empty
        Else
            Me.CurrentAutoTelnetScript.NotesRtf = Me.txtNotes.Rtf
        End If
    End Sub

    Private Sub FillControlsFromData()
        'Controls ConnectionInfo
        Me.txtHost.Text = Me.CurrentAutoTelnetScript.Host

        Me.chkSendUser.Checked = Me.CurrentAutoTelnetScript.SendUser
        If Me.CurrentAutoTelnetScript.SendUser Then
            Me.txtUser.Text = Me.CurrentAutoTelnetScript.User
        Else
            Me.txtUser.ResetText()
        End If

        Me.chkSendPassword.Checked = Me.CurrentAutoTelnetScript.SendPassword
        If Me.CurrentAutoTelnetScript.SendPassword Then
            Me.txtPassword.Text = Me.CurrentAutoTelnetScript.PasswordDecrypted
        Else
            Me.txtPassword.ResetText()
        End If

        Me.cmbSendEndOfLine.SelectedValue = Me.CurrentAutoTelnetScript.SendEndOfLine

        'Controls Script
        Me.txtScript.Text = Me.CurrentAutoTelnetScript.Text

        'Parameters
        Me.grdParameters.Rows.Clear()
        For Each p As AutoTelnetScriptParameter In Me.CurrentAutoTelnetScript.Parameters
            With Me.grdParameters.Rows(Me.grdParameters.Rows.Add())
                .Cells(Me.colParametersName.Index).Value = p.Name
                .Cells(Me.colParametersDefaultValue.Index).Value = p.DefaultValue
            End With
        Next
        Me.grdParameters.ClearSelection()

        'Settings - Port
        Me.nudPort.Value = Me.CurrentAutoTelnetScript.Port
        Me.nudDelayReadTime.Value = Me.CurrentAutoTelnetScript.DelayReadTime
        Me.nudAttemptsRetryReading.Value = Me.CurrentAutoTelnetScript.AttemptsRetryReading

        'Settings - Security
        Me.chkEncryptAutoTelnetScriptFile.Checked = Me.CurrentAutoTelnetScript.Encrypted

        'Settings - Output
        Me.chkRemoveRemoveANSIEscapeSequencesFromOutput.Checked = Me.CurrentAutoTelnetScript.RemoveRemoveANSIEscapeSequencesFromOutput

        'Settings - Log
        If String.IsNullOrWhiteSpace(Me.CurrentAutoTelnetScript.LogFile) Then
            Me.chkLogFile.Checked = False
            Me.txtLogFile.ResetText()
            Me.cmbLogMode.SelectedValue = UtilLogFileWriter.LogModeDefault
            Me.chkLogEncryptCommandResponseEntries.Checked = False
            Me.chkLogOnlyExecutionStatus.Checked = False
        Else
            Me.chkLogFile.Checked = True
            Me.txtLogFile.Text = Me.CurrentAutoTelnetScript.LogFile
            Me.cmbLogMode.SelectedValue = Me.CurrentAutoTelnetScript.LogMode
            Me.chkLogEncryptCommandResponseEntries.Checked = Me.CurrentAutoTelnetScript.LogCommandAndResponseEntriesEncrypted
        End If

        'Settings - Batch
        Me.txtBatchSuccessfulOutputText.Text = Me.CurrentAutoTelnetScript.BatchSuccessfulOutputText
        Me.txtBatchFailedOutputText.Text = Me.CurrentAutoTelnetScript.BatchFailedOutputText
        If String.IsNullOrWhiteSpace(Me.CurrentAutoTelnetScript.BatchOutputFile) Then
            Me.chkBatchOutputFile.Checked = False
            Me.txtBatchOutputFile.ResetText()
            Me.cmbBatchOuputMode.SelectedValue = UtilBatchOutputFileWriter.OutputModeDefault
        Else
            Me.chkBatchOutputFile.Checked = True
            Me.txtBatchOutputFile.Text = Me.CurrentAutoTelnetScript.BatchOutputFile
            Me.cmbBatchOuputMode.SelectedValue = Me.CurrentAutoTelnetScript.BatchOutputMode
        End If


        'Notes
        If Not String.IsNullOrWhiteSpace(Me.CurrentAutoTelnetScript.NotesRtf) Then
            Me.txtNotes.Rtf = Me.CurrentAutoTelnetScript.NotesRtf
        Else
            Me.txtNotes.ResetText()
        End If
    End Sub
#End Region

#Region "Gestione Output"
    Private Enum OutputTypes As Integer
        Information
        Command
        Response
        [Error]
    End Enum

    Private Overloads Sub AddOutput(type As OutputTypes, text As String)
        'Impostazione Colore e sezione log
        Dim logEntryType As UtilLogFileWriter.EntryTypes = Nothing
        Select Case type
            Case OutputTypes.Information
                Me.txtOutput.SelectionColor = Color.Yellow
                logEntryType = UtilLogFileWriter.EntryTypes.Information
            Case OutputTypes.Command
                Me.txtOutput.SelectionColor = Color.White
                logEntryType = UtilLogFileWriter.EntryTypes.Command
            Case OutputTypes.Response
                Me.txtOutput.SelectionColor = Color.GreenYellow
                logEntryType = UtilLogFileWriter.EntryTypes.Response
            Case OutputTypes.Error
                Me.txtOutput.SelectionColor = Color.Red
                logEntryType = UtilLogFileWriter.EntryTypes.Error
        End Select

        Me.txtOutput.SelectedText &= text.TrimNewLine() & System.Environment.NewLine
        Me.txtOutput.ScrollToCaret()
        Me.txtOutput.Refresh()

        If UtilLogFileWriter.LogEnabled Then UtilLogFileWriter.WriteNewEntry(logEntryType, text.TrimNewLine())
    End Sub
#End Region

#Region "Gestione Parametri"
    Private Sub btnAddParameter_Click(sender As Object, e As EventArgs) Handles btnAddParameter.Click
        Me.grdParameters.Rows(Me.grdParameters.Rows.Add(New String() {"@Parameter" & Me.grdParameters.Rows.Count, Nothing})).Selected = True
    End Sub

    Private Sub grdParameters_SelectionChanged(sender As Object, e As EventArgs) Handles grdParameters.SelectionChanged
        Me.btnRemoveParameter.Enabled = Me.grdParameters.SelectedRows.Count > 0
        Me.btnInsertSelectedParameter.Enabled = Me.grdParameters.SelectedRows.Count = 1
    End Sub

    Private Sub btnRemoveParameter_Click(sender As Object, e As EventArgs) Handles btnRemoveParameter.Click
        Me.grdParameters.Rows.Remove(Me.grdParameters.SelectedRows(0))
        Me.grdParameters.ClearSelection()
    End Sub

    Private Function GetParametersValuesFromControls() As System.Collections.Generic.Dictionary(Of String, String)
        Dim parameters As New System.Collections.Generic.Dictionary(Of String, String)

        For Each r As System.Windows.Forms.DataGridViewRow In Me.grdParameters.Rows
            If r.Cells(Me.colParametersValue.Index).Value IsNot Nothing AndAlso
                Not String.IsNullOrWhiteSpace(r.Cells(Me.colParametersValue.Index).Value.ToString()) Then
                parameters.Add(r.Cells(Me.colParametersName.Index).Value.ToString(),
                               r.Cells(Me.colParametersValue.Index).Value.ToString())
            End If
        Next

        Return parameters
    End Function

    Private Sub grdParameters_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles grdParameters.CellEnter
        Me.btnExpression.Enabled = e.ColumnIndex = Me.colParametersDefaultValue.Index OrElse e.ColumnIndex = Me.colParametersValue.Index
    End Sub

    Private Sub grdParameters_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdParameters.CellDoubleClick
        If Me.btnExpression.Enabled AndAlso
            (Me.grdParameters.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() = String.Empty OrElse
                Me.grdParameters.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString().StartsWith(UtilExpression.ExpressionPrefix)) Then
            Me.btnExpression.PerformClick()
        End If
    End Sub

    Private Sub btnExpression_Click(sender As Object, e As EventArgs) Handles btnExpression.Click
        Using dlg As New ExpressionDialog

            'Gestione selezione ID e impostazione formate parameter dell'eventuale cella da editare
            If Me.grdParameters.SelectedRows.Count = 1 Then
                Dim expression As String = String.Empty

                If Me.grdParameters.CurrentCell.Value IsNot Nothing Then
                    If Me.grdParameters.CurrentCell.ColumnIndex = Me.colParametersDefaultValue.Index OrElse
                        Me.grdParameters.CurrentCell.ColumnIndex = Me.colParametersValue.Index Then
                        expression = Me.grdParameters.CurrentCell.Value.ToString()
                    End If
                End If

                If Not String.IsNullOrEmpty(expression) Then
                    dlg.SelectIDOnLoad = UtilExpression.GetID(expression)
                    dlg.SetFormatOnLoad = UtilExpression.GetFormat(expression)
                    dlg.SetParameterOnLoad = UtilExpression.GetFormat(expression)
                End If
            End If

            'Visualizzazione dialog
            If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Me.grdParameters.CurrentCell.Value = dlg.Expression
            End If
        End Using
    End Sub

    Private Sub btnInsertSelectedParameter_Click(sender As Object, e As EventArgs) Handles btnInsertSelectedParameter.Click
        Dim startIndex = Me.txtScript.SelectionStart
        If Me.txtScript.SelectionLength > 0 Then
            Me.txtScript.Text = Me.txtScript.Text.Remove(startIndex, Me.txtScript.SelectionLength)
        End If
        Me.txtScript.Text = Me.txtScript.Text.Insert(startIndex, Me.grdParameters.SelectedRows(0).Cells(Me.colParametersName.Index).Value.ToString())
    End Sub
#End Region

#Region "Gestione BackgroundWorker TelnetSession"
    'https://msdn.microsoft.com/it-it/library/cc221403(v=vs.95).aspx

    Private bkwScriptSession As TelnetSession = Nothing
    Private bkwScriptCommands As System.Collections.Specialized.StringCollection = Nothing

    Private Sub bkwScript_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bkwScript.DoWork
        Try
            Me.lblStatus.Text = "Execution script in progress..."
            Me.bkwScriptSession.SendCommands(Me.bkwScriptCommands)
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub bkwScript_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bkwScript.RunWorkerCompleted
        'Reset Flag Running
        Me.ScriptRunnig = False

        'Gestione StatusBar
        If e.Cancelled Then
            Me.lblStatus.Text = "Execution script cancelled"
        Else
            Me.lblStatus.Text = "Execution script completed"
        End If

        'Gestione ToolBar
        Me.ActivateRun(True)

        'Reset Wait Cursor
        Me.SetWaitCursor(False)
    End Sub

    Private Sub bkwScriptSession_OutputInformationAdded(sender As Object, e As TelnetSessionOutputInformationAddedEventArgs)
        Me.bkwScript.ReportProgress(Nothing, e)
    End Sub

    Private Sub bkwScriptSession_OutputCommandAdded(sender As Object, e As TelnetSessionOutputCommandAddedEventArgs)
        Me.bkwScript.ReportProgress(Nothing, e)
    End Sub

    Private Sub bkwScriptSession_OutputResponseAdded(sender As Object, e As TelnetSessionOutputResponseAddedEventArgs)
        Me.bkwScript.ReportProgress(Nothing, e)
    End Sub

    Private Sub bkwScriptSession_OutputErrorAdded(sender As Object, e As TelnetSessionOutputErrorAddedEventArgs)
        Me.bkwScript.ReportProgress(Nothing, e)
    End Sub

    Private Sub bkwScript_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bkwScript.ProgressChanged
        If TypeOf e.UserState Is TelnetSessionOutputInformationAddedEventArgs Then
            Me.AddOutput(OutputTypes.Information, DirectCast(e.UserState, TelnetSessionOutputInformationAddedEventArgs).Text)
        ElseIf TypeOf e.UserState Is TelnetSessionOutputCommandAddedEventArgs Then
            Me.AddOutput(OutputTypes.Command, DirectCast(e.UserState, TelnetSessionOutputCommandAddedEventArgs).Text)
        ElseIf TypeOf e.UserState Is TelnetSessionOutputResponseAddedEventArgs Then
            Me.AddOutput(OutputTypes.Response, DirectCast(e.UserState, TelnetSessionOutputResponseAddedEventArgs).Text)
        ElseIf TypeOf e.UserState Is TelnetSessionOutputErrorAddedEventArgs Then
            Me.AddOutput(OutputTypes.Error, DirectCast(e.UserState, TelnetSessionOutputErrorAddedEventArgs).Text)
        End If
    End Sub
#End Region

#Region "Gestione Notes"
    Private Sub btnBold_Click(sender As Object, e As EventArgs) Handles chkBold.Click
        Try
            If Me.txtNotes.SelectionFont.Bold Then
                Me.txtNotes.SelectionFont = New Font(Me.txtNotes.SelectionFont, Me.txtNotes.SelectionFont.Style And Not FontStyle.Bold)
            Else
                Me.txtNotes.SelectionFont = New Font(Me.txtNotes.SelectionFont, Me.txtNotes.SelectionFont.Style Or FontStyle.Bold)
            End If
        Catch ex As Exception
            UtilMsgBox.ShowErrorException(ex, False)
        End Try
    End Sub

    Private Sub btnItalic_Click(sender As Object, e As EventArgs) Handles chkItalic.Click
        Try
            If Me.txtNotes.SelectionFont.Italic Then
                Me.txtNotes.SelectionFont = New Font(Me.txtNotes.SelectionFont, Me.txtNotes.SelectionFont.Style And Not FontStyle.Italic)
            Else
                Me.txtNotes.SelectionFont = New Font(Me.txtNotes.SelectionFont, Me.txtNotes.SelectionFont.Style Or FontStyle.Italic)
            End If
        Catch ex As Exception
            UtilMsgBox.ShowErrorException(ex, False)
        End Try
    End Sub

    Private Sub btnUnderline_Click(sender As Object, e As EventArgs) Handles chkUnderline.Click
        Try
            If Me.txtNotes.SelectionFont.Underline Then
                Me.txtNotes.SelectionFont = New Font(Me.txtNotes.SelectionFont, Me.txtNotes.SelectionFont.Style And Not FontStyle.Underline)
            Else
                Me.txtNotes.SelectionFont = New Font(Me.txtNotes.SelectionFont, Me.txtNotes.SelectionFont.Style Or FontStyle.Underline)
            End If
        Catch ex As Exception
            UtilMsgBox.ShowErrorException(ex, False)
        End Try
    End Sub

    Private Sub txtNotes_SelectionChanged(sender As Object, e As EventArgs) Handles txtNotes.SelectionChanged
        If String.IsNullOrWhiteSpace(Me.txtNotes.SelectedText) Then
            Me.chkBold.Enabled = False
            Me.chkBold.Checked = False

            Me.chkItalic.Enabled = False
            Me.chkItalic.Checked = False

            Me.chkUnderline.Enabled = False
            Me.chkUnderline.Checked = False
        Else
            Me.chkBold.Enabled = True
            Me.chkBold.Checked = Me.txtNotes.SelectionFont.Bold

            Me.chkItalic.Enabled = True
            Me.chkItalic.Checked = Me.txtNotes.SelectionFont.Italic

            Me.chkUnderline.Enabled = True
            Me.chkUnderline.Checked = Me.txtNotes.SelectionFont.Underline
        End If
    End Sub
#End Region

End Class