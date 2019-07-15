<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.mnsMain = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniFileNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniFileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssFile1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mniFileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniFileSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssFile2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mniFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniActions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniActionsRun = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniActionsStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniToolsLogViewer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mniHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlsMain = New System.Windows.Forms.ToolStrip()
        Me.btnOpen = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnRun = New System.Windows.Forms.ToolStripButton()
        Me.btnStop = New System.Windows.Forms.ToolStripButton()
        Me.btnLogViewer = New System.Windows.Forms.ToolStripButton()
        Me.cmbSendEndOfLine = New System.Windows.Forms.ComboBox()
        Me.lblSendEndOfLineChar = New System.Windows.Forms.Label()
        Me.nudDelayReadTime = New System.Windows.Forms.NumericUpDown()
        Me.lblDelayReadTime = New System.Windows.Forms.Label()
        Me.nudPort = New System.Windows.Forms.NumericUpDown()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.lblHost = New System.Windows.Forms.Label()
        Me.stsMain = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tbpCommands = New System.Windows.Forms.TabPage()
        Me.spcCommands1 = New System.Windows.Forms.SplitContainer()
        Me.spcCommands2 = New System.Windows.Forms.SplitContainer()
        Me.txtScript = New System.Windows.Forms.RichTextBox()
        Me.pnlCommandsDown = New System.Windows.Forms.Panel()
        Me.btnInsertSelectedParameter = New System.Windows.Forms.Button()
        Me.pnlCommandsUp = New System.Windows.Forms.Panel()
        Me.chkSendPassword = New System.Windows.Forms.CheckBox()
        Me.chkSendUser = New System.Windows.Forms.CheckBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.grdParameters = New System.Windows.Forms.DataGridView()
        Me.colParametersName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colParametersDefaultValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colParametersValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlParametersDown = New System.Windows.Forms.Panel()
        Me.btnRemoveParameter = New System.Windows.Forms.Button()
        Me.btnAddParameter = New System.Windows.Forms.Button()
        Me.btnExpression = New System.Windows.Forms.Button()
        Me.pnlParametersUp = New System.Windows.Forms.Panel()
        Me.lblParameters = New System.Windows.Forms.Label()
        Me.txtOutput = New System.Windows.Forms.RichTextBox()
        Me.tbpSettings = New System.Windows.Forms.TabPage()
        Me.grpSettingsBatch = New System.Windows.Forms.GroupBox()
        Me.cmbBatchOuputMode = New System.Windows.Forms.ComboBox()
        Me.lblBatchOutputMode = New System.Windows.Forms.Label()
        Me.btnBrowseBatchOutputFile = New System.Windows.Forms.Button()
        Me.txtBatchOutputFile = New System.Windows.Forms.TextBox()
        Me.chkBatchOutputFile = New System.Windows.Forms.CheckBox()
        Me.lblBatchFailedOutputText = New System.Windows.Forms.Label()
        Me.txtBatchFailedOutputText = New System.Windows.Forms.TextBox()
        Me.lblBatchSuccessfulOutputText = New System.Windows.Forms.Label()
        Me.txtBatchSuccessfulOutputText = New System.Windows.Forms.TextBox()
        Me.grpOutput = New System.Windows.Forms.GroupBox()
        Me.chkRemoveRemoveANSIEscapeSequencesFromOutput = New System.Windows.Forms.CheckBox()
        Me.grpSecurity = New System.Windows.Forms.GroupBox()
        Me.chkEncryptAutoTelnetScriptFile = New System.Windows.Forms.CheckBox()
        Me.grpSettingsLog = New System.Windows.Forms.GroupBox()
        Me.chkLogOnlyExecutionStatus = New System.Windows.Forms.CheckBox()
        Me.chkLogEncryptCommandResponseEntries = New System.Windows.Forms.CheckBox()
        Me.cmbLogMode = New System.Windows.Forms.ComboBox()
        Me.lblLogMode = New System.Windows.Forms.Label()
        Me.btnBrowseLogFile = New System.Windows.Forms.Button()
        Me.chkLogFile = New System.Windows.Forms.CheckBox()
        Me.txtLogFile = New System.Windows.Forms.TextBox()
        Me.grpSettingsConnection = New System.Windows.Forms.GroupBox()
        Me.nudAttemptsRetryReading = New System.Windows.Forms.NumericUpDown()
        Me.lblAttemptsRetryReading = New System.Windows.Forms.Label()
        Me.tbpNotes = New System.Windows.Forms.TabPage()
        Me.chkUnderline = New System.Windows.Forms.CheckBox()
        Me.chkItalic = New System.Windows.Forms.CheckBox()
        Me.chkBold = New System.Windows.Forms.CheckBox()
        Me.txtNotes = New System.Windows.Forms.RichTextBox()
        Me.sfdLog = New System.Windows.Forms.SaveFileDialog()
        Me.bkwScript = New System.ComponentModel.BackgroundWorker()
        Me.ofdScript = New System.Windows.Forms.OpenFileDialog()
        Me.sfdScript = New System.Windows.Forms.SaveFileDialog()
        Me.tipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.sfdBatchOutputFile = New System.Windows.Forms.SaveFileDialog()
        Me.ofdLog = New System.Windows.Forms.OpenFileDialog()
        Me.mnsMain.SuspendLayout()
        Me.tlsMain.SuspendLayout()
        CType(Me.nudDelayReadTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsMain.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tbpCommands.SuspendLayout()
        CType(Me.spcCommands1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcCommands1.Panel1.SuspendLayout()
        Me.spcCommands1.Panel2.SuspendLayout()
        Me.spcCommands1.SuspendLayout()
        CType(Me.spcCommands2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcCommands2.Panel1.SuspendLayout()
        Me.spcCommands2.Panel2.SuspendLayout()
        Me.spcCommands2.SuspendLayout()
        Me.pnlCommandsDown.SuspendLayout()
        Me.pnlCommandsUp.SuspendLayout()
        CType(Me.grdParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametersDown.SuspendLayout()
        Me.pnlParametersUp.SuspendLayout()
        Me.tbpSettings.SuspendLayout()
        Me.grpSettingsBatch.SuspendLayout()
        Me.grpOutput.SuspendLayout()
        Me.grpSecurity.SuspendLayout()
        Me.grpSettingsLog.SuspendLayout()
        Me.grpSettingsConnection.SuspendLayout()
        CType(Me.nudAttemptsRetryReading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpNotes.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnsMain
        '
        Me.mnsMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.mniActions, Me.mniTools, Me.mniHelp})
        Me.mnsMain.Location = New System.Drawing.Point(0, 0)
        Me.mnsMain.Name = "mnsMain"
        Me.mnsMain.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.mnsMain.Size = New System.Drawing.Size(982, 24)
        Me.mnsMain.TabIndex = 0
        Me.mnsMain.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniFileNew, Me.mniFileOpen, Me.tssFile1, Me.mniFileSave, Me.mniFileSaveAs, Me.tssFile2, Me.mniFileExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'mniFileNew
        '
        Me.mniFileNew.Image = CType(resources.GetObject("mniFileNew.Image"), System.Drawing.Image)
        Me.mniFileNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mniFileNew.Name = "mniFileNew"
        Me.mniFileNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.mniFileNew.Size = New System.Drawing.Size(146, 22)
        Me.mniFileNew.Text = "&New"
        '
        'mniFileOpen
        '
        Me.mniFileOpen.Image = CType(resources.GetObject("mniFileOpen.Image"), System.Drawing.Image)
        Me.mniFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mniFileOpen.Name = "mniFileOpen"
        Me.mniFileOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.mniFileOpen.Size = New System.Drawing.Size(146, 22)
        Me.mniFileOpen.Text = "&Open"
        '
        'tssFile1
        '
        Me.tssFile1.Name = "tssFile1"
        Me.tssFile1.Size = New System.Drawing.Size(143, 6)
        '
        'mniFileSave
        '
        Me.mniFileSave.Image = CType(resources.GetObject("mniFileSave.Image"), System.Drawing.Image)
        Me.mniFileSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mniFileSave.Name = "mniFileSave"
        Me.mniFileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mniFileSave.Size = New System.Drawing.Size(146, 22)
        Me.mniFileSave.Text = "&Save"
        '
        'mniFileSaveAs
        '
        Me.mniFileSaveAs.Name = "mniFileSaveAs"
        Me.mniFileSaveAs.Size = New System.Drawing.Size(146, 22)
        Me.mniFileSaveAs.Text = "Save &As"
        '
        'tssFile2
        '
        Me.tssFile2.Name = "tssFile2"
        Me.tssFile2.Size = New System.Drawing.Size(143, 6)
        '
        'mniFileExit
        '
        Me.mniFileExit.Name = "mniFileExit"
        Me.mniFileExit.Size = New System.Drawing.Size(146, 22)
        Me.mniFileExit.Text = "E&xit"
        '
        'mniActions
        '
        Me.mniActions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniActionsRun, Me.mniActionsStop})
        Me.mniActions.Name = "mniActions"
        Me.mniActions.Size = New System.Drawing.Size(59, 20)
        Me.mniActions.Text = "&Actions"
        '
        'mniActionsRun
        '
        Me.mniActionsRun.Enabled = False
        Me.mniActionsRun.Image = CType(resources.GetObject("mniActionsRun.Image"), System.Drawing.Image)
        Me.mniActionsRun.Name = "mniActionsRun"
        Me.mniActionsRun.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.mniActionsRun.Size = New System.Drawing.Size(136, 22)
        Me.mniActionsRun.Text = "&Run"
        '
        'mniActionsStop
        '
        Me.mniActionsStop.Enabled = False
        Me.mniActionsStop.Image = CType(resources.GetObject("mniActionsStop.Image"), System.Drawing.Image)
        Me.mniActionsStop.Name = "mniActionsStop"
        Me.mniActionsStop.Size = New System.Drawing.Size(136, 22)
        Me.mniActionsStop.Text = "&Stop"
        '
        'mniTools
        '
        Me.mniTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniToolsLogViewer})
        Me.mniTools.Name = "mniTools"
        Me.mniTools.Size = New System.Drawing.Size(47, 20)
        Me.mniTools.Text = "&Tools"
        '
        'mniToolsLogViewer
        '
        Me.mniToolsLogViewer.Image = CType(resources.GetObject("mniToolsLogViewer.Image"), System.Drawing.Image)
        Me.mniToolsLogViewer.Name = "mniToolsLogViewer"
        Me.mniToolsLogViewer.Size = New System.Drawing.Size(156, 26)
        Me.mniToolsLogViewer.Text = "&Log Viewer..."
        Me.mniToolsLogViewer.ToolTipText = "Open log file"
        '
        'mniHelp
        '
        Me.mniHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mniHelpAbout})
        Me.mniHelp.Name = "mniHelp"
        Me.mniHelp.Size = New System.Drawing.Size(44, 20)
        Me.mniHelp.Text = "&Help"
        '
        'mniHelpAbout
        '
        Me.mniHelpAbout.Name = "mniHelpAbout"
        Me.mniHelpAbout.Size = New System.Drawing.Size(116, 22)
        Me.mniHelpAbout.Text = "&About..."
        '
        'tlsMain
        '
        Me.tlsMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tlsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpen, Me.btnSave, Me.btnRun, Me.btnStop, Me.btnLogViewer})
        Me.tlsMain.Location = New System.Drawing.Point(0, 24)
        Me.tlsMain.Name = "tlsMain"
        Me.tlsMain.Size = New System.Drawing.Size(982, 27)
        Me.tlsMain.TabIndex = 1
        Me.tlsMain.Text = "ToolStrip1"
        '
        'btnOpen
        '
        Me.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnOpen.Image = CType(resources.GetObject("btnOpen.Image"), System.Drawing.Image)
        Me.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(24, 24)
        Me.btnOpen.Text = "Open script..."
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(24, 24)
        Me.btnSave.Text = "Save"
        '
        'btnRun
        '
        Me.btnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRun.Enabled = False
        Me.btnRun.Image = CType(resources.GetObject("btnRun.Image"), System.Drawing.Image)
        Me.btnRun.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(24, 24)
        Me.btnRun.Text = "Run script"
        '
        'btnStop
        '
        Me.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnStop.Enabled = False
        Me.btnStop.Image = CType(resources.GetObject("btnStop.Image"), System.Drawing.Image)
        Me.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(24, 24)
        Me.btnStop.Text = "Stop script"
        '
        'btnLogViewer
        '
        Me.btnLogViewer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLogViewer.Image = CType(resources.GetObject("btnLogViewer.Image"), System.Drawing.Image)
        Me.btnLogViewer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLogViewer.Name = "btnLogViewer"
        Me.btnLogViewer.Size = New System.Drawing.Size(24, 24)
        Me.btnLogViewer.Text = "Open log file"
        '
        'cmbSendEndOfLine
        '
        Me.cmbSendEndOfLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSendEndOfLine.FormattingEnabled = True
        Me.cmbSendEndOfLine.Location = New System.Drawing.Point(132, 11)
        Me.cmbSendEndOfLine.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbSendEndOfLine.Name = "cmbSendEndOfLine"
        Me.cmbSendEndOfLine.Size = New System.Drawing.Size(300, 21)
        Me.cmbSendEndOfLine.TabIndex = 21
        '
        'lblSendEndOfLineChar
        '
        Me.lblSendEndOfLineChar.AutoSize = True
        Me.lblSendEndOfLineChar.Location = New System.Drawing.Point(5, 15)
        Me.lblSendEndOfLineChar.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblSendEndOfLineChar.Name = "lblSendEndOfLineChar"
        Me.lblSendEndOfLineChar.Size = New System.Drawing.Size(87, 13)
        Me.lblSendEndOfLineChar.TabIndex = 20
        Me.lblSendEndOfLineChar.Text = "Send end of line:"
        '
        'nudDelayReadTime
        '
        Me.nudDelayReadTime.Location = New System.Drawing.Point(299, 22)
        Me.nudDelayReadTime.Margin = New System.Windows.Forms.Padding(5)
        Me.nudDelayReadTime.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudDelayReadTime.Name = "nudDelayReadTime"
        Me.nudDelayReadTime.Size = New System.Drawing.Size(80, 20)
        Me.nudDelayReadTime.TabIndex = 19
        Me.nudDelayReadTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudDelayReadTime.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'lblDelayReadTime
        '
        Me.lblDelayReadTime.AutoSize = True
        Me.lblDelayReadTime.Location = New System.Drawing.Point(172, 25)
        Me.lblDelayReadTime.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDelayReadTime.Name = "lblDelayReadTime"
        Me.lblDelayReadTime.Size = New System.Drawing.Size(86, 13)
        Me.lblDelayReadTime.TabIndex = 18
        Me.lblDelayReadTime.Text = "Read delay (ms):"
        '
        'nudPort
        '
        Me.nudPort.Location = New System.Drawing.Point(83, 22)
        Me.nudPort.Margin = New System.Windows.Forms.Padding(5)
        Me.nudPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudPort.Name = "nudPort"
        Me.nudPort.Size = New System.Drawing.Size(80, 20)
        Me.nudPort.TabIndex = 17
        Me.nudPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudPort.Value = New Decimal(New Integer() {23, 0, 0, 0})
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(9, 25)
        Me.lblPort.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(29, 13)
        Me.lblPort.TabIndex = 16
        Me.lblPort.Text = "Port:"
        '
        'txtHost
        '
        Me.txtHost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHost.Location = New System.Drawing.Point(119, 5)
        Me.txtHost.Margin = New System.Windows.Forms.Padding(5)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(477, 20)
        Me.txtHost.TabIndex = 15
        '
        'lblHost
        '
        Me.lblHost.AutoSize = True
        Me.lblHost.Location = New System.Drawing.Point(5, 9)
        Me.lblHost.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblHost.Name = "lblHost"
        Me.lblHost.Size = New System.Drawing.Size(32, 13)
        Me.lblHost.TabIndex = 14
        Me.lblHost.Text = "Host:"
        '
        'stsMain
        '
        Me.stsMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.stsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.stsMain.Location = New System.Drawing.Point(0, 631)
        Me.stsMain.Name = "stsMain"
        Me.stsMain.Padding = New System.Windows.Forms.Padding(1, 0, 25, 0)
        Me.stsMain.Size = New System.Drawing.Size(982, 22)
        Me.stsMain.TabIndex = 22
        Me.stsMain.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(956, 17)
        Me.lblStatus.Spring = True
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tbpCommands)
        Me.tabMain.Controls.Add(Me.tbpSettings)
        Me.tabMain.Controls.Add(Me.tbpNotes)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.Location = New System.Drawing.Point(0, 51)
        Me.tabMain.Margin = New System.Windows.Forms.Padding(4)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(982, 580)
        Me.tabMain.TabIndex = 23
        '
        'tbpCommands
        '
        Me.tbpCommands.Controls.Add(Me.spcCommands1)
        Me.tbpCommands.Location = New System.Drawing.Point(4, 22)
        Me.tbpCommands.Margin = New System.Windows.Forms.Padding(4)
        Me.tbpCommands.Name = "tbpCommands"
        Me.tbpCommands.Padding = New System.Windows.Forms.Padding(4)
        Me.tbpCommands.Size = New System.Drawing.Size(974, 554)
        Me.tbpCommands.TabIndex = 0
        Me.tbpCommands.Text = "Commands"
        Me.tbpCommands.UseVisualStyleBackColor = True
        '
        'spcCommands1
        '
        Me.spcCommands1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcCommands1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.spcCommands1.Location = New System.Drawing.Point(4, 4)
        Me.spcCommands1.Margin = New System.Windows.Forms.Padding(4)
        Me.spcCommands1.Name = "spcCommands1"
        Me.spcCommands1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spcCommands1.Panel1
        '
        Me.spcCommands1.Panel1.Controls.Add(Me.spcCommands2)
        '
        'spcCommands1.Panel2
        '
        Me.spcCommands1.Panel2.Controls.Add(Me.txtOutput)
        Me.spcCommands1.Size = New System.Drawing.Size(966, 546)
        Me.spcCommands1.SplitterDistance = 345
        Me.spcCommands1.SplitterWidth = 5
        Me.spcCommands1.TabIndex = 0
        '
        'spcCommands2
        '
        Me.spcCommands2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcCommands2.Location = New System.Drawing.Point(0, 0)
        Me.spcCommands2.Margin = New System.Windows.Forms.Padding(4)
        Me.spcCommands2.Name = "spcCommands2"
        '
        'spcCommands2.Panel1
        '
        Me.spcCommands2.Panel1.Controls.Add(Me.txtScript)
        Me.spcCommands2.Panel1.Controls.Add(Me.pnlCommandsDown)
        Me.spcCommands2.Panel1.Controls.Add(Me.pnlCommandsUp)
        '
        'spcCommands2.Panel2
        '
        Me.spcCommands2.Panel2.Controls.Add(Me.grdParameters)
        Me.spcCommands2.Panel2.Controls.Add(Me.pnlParametersDown)
        Me.spcCommands2.Panel2.Controls.Add(Me.pnlParametersUp)
        Me.spcCommands2.Size = New System.Drawing.Size(966, 345)
        Me.spcCommands2.SplitterDistance = 614
        Me.spcCommands2.SplitterWidth = 5
        Me.spcCommands2.TabIndex = 0
        '
        'txtScript
        '
        Me.txtScript.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtScript.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScript.Location = New System.Drawing.Point(0, 74)
        Me.txtScript.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.txtScript.Name = "txtScript"
        Me.txtScript.Size = New System.Drawing.Size(614, 227)
        Me.txtScript.TabIndex = 1
        Me.txtScript.Text = ""
        '
        'pnlCommandsDown
        '
        Me.pnlCommandsDown.Controls.Add(Me.btnInsertSelectedParameter)
        Me.pnlCommandsDown.Controls.Add(Me.cmbSendEndOfLine)
        Me.pnlCommandsDown.Controls.Add(Me.lblSendEndOfLineChar)
        Me.pnlCommandsDown.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCommandsDown.Location = New System.Drawing.Point(0, 301)
        Me.pnlCommandsDown.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlCommandsDown.Name = "pnlCommandsDown"
        Me.pnlCommandsDown.Size = New System.Drawing.Size(614, 44)
        Me.pnlCommandsDown.TabIndex = 1
        '
        'btnInsertSelectedParameter
        '
        Me.btnInsertSelectedParameter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertSelectedParameter.Enabled = False
        Me.btnInsertSelectedParameter.Location = New System.Drawing.Point(449, 9)
        Me.btnInsertSelectedParameter.Name = "btnInsertSelectedParameter"
        Me.btnInsertSelectedParameter.Size = New System.Drawing.Size(147, 28)
        Me.btnInsertSelectedParameter.TabIndex = 22
        Me.btnInsertSelectedParameter.Text = "Insert parameter"
        Me.btnInsertSelectedParameter.UseVisualStyleBackColor = True
        '
        'pnlCommandsUp
        '
        Me.pnlCommandsUp.Controls.Add(Me.chkSendPassword)
        Me.pnlCommandsUp.Controls.Add(Me.chkSendUser)
        Me.pnlCommandsUp.Controls.Add(Me.txtPassword)
        Me.pnlCommandsUp.Controls.Add(Me.txtUser)
        Me.pnlCommandsUp.Controls.Add(Me.txtHost)
        Me.pnlCommandsUp.Controls.Add(Me.lblHost)
        Me.pnlCommandsUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCommandsUp.Location = New System.Drawing.Point(0, 0)
        Me.pnlCommandsUp.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlCommandsUp.Name = "pnlCommandsUp"
        Me.pnlCommandsUp.Size = New System.Drawing.Size(614, 74)
        Me.pnlCommandsUp.TabIndex = 0
        '
        'chkSendPassword
        '
        Me.chkSendPassword.AutoSize = True
        Me.chkSendPassword.Location = New System.Drawing.Point(303, 42)
        Me.chkSendPassword.Margin = New System.Windows.Forms.Padding(5)
        Me.chkSendPassword.Name = "chkSendPassword"
        Me.chkSendPassword.Size = New System.Drawing.Size(102, 17)
        Me.chkSendPassword.TabIndex = 13
        Me.chkSendPassword.Text = "Send password:"
        Me.chkSendPassword.UseVisualStyleBackColor = True
        '
        'chkSendUser
        '
        Me.chkSendUser.AutoSize = True
        Me.chkSendUser.Location = New System.Drawing.Point(5, 42)
        Me.chkSendUser.Margin = New System.Windows.Forms.Padding(5)
        Me.chkSendUser.Name = "chkSendUser"
        Me.chkSendUser.Size = New System.Drawing.Size(77, 17)
        Me.chkSendUser.TabIndex = 12
        Me.chkSendUser.Text = "Send user:"
        Me.chkSendUser.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Enabled = False
        Me.txtPassword.Location = New System.Drawing.Point(449, 39)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(5)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(146, 20)
        Me.txtPassword.TabIndex = 11
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtUser
        '
        Me.txtUser.Enabled = False
        Me.txtUser.Location = New System.Drawing.Point(119, 39)
        Me.txtUser.Margin = New System.Windows.Forms.Padding(5)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(172, 20)
        Me.txtUser.TabIndex = 10
        '
        'grdParameters
        '
        Me.grdParameters.AllowUserToAddRows = False
        Me.grdParameters.AllowUserToDeleteRows = False
        Me.grdParameters.AllowUserToResizeRows = False
        Me.grdParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdParameters.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colParametersName, Me.colParametersDefaultValue, Me.colParametersValue})
        Me.grdParameters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParameters.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.grdParameters.Location = New System.Drawing.Point(0, 34)
        Me.grdParameters.Margin = New System.Windows.Forms.Padding(5)
        Me.grdParameters.MultiSelect = False
        Me.grdParameters.Name = "grdParameters"
        Me.grdParameters.RowHeadersVisible = False
        Me.grdParameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdParameters.Size = New System.Drawing.Size(347, 267)
        Me.grdParameters.TabIndex = 12
        '
        'colParametersName
        '
        Me.colParametersName.HeaderText = "Name"
        Me.colParametersName.Name = "colParametersName"
        '
        'colParametersDefaultValue
        '
        Me.colParametersDefaultValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colParametersDefaultValue.HeaderText = "Default value"
        Me.colParametersDefaultValue.Name = "colParametersDefaultValue"
        '
        'colParametersValue
        '
        Me.colParametersValue.HeaderText = "Value"
        Me.colParametersValue.Name = "colParametersValue"
        '
        'pnlParametersDown
        '
        Me.pnlParametersDown.Controls.Add(Me.btnRemoveParameter)
        Me.pnlParametersDown.Controls.Add(Me.btnAddParameter)
        Me.pnlParametersDown.Controls.Add(Me.btnExpression)
        Me.pnlParametersDown.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlParametersDown.Location = New System.Drawing.Point(0, 301)
        Me.pnlParametersDown.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlParametersDown.Name = "pnlParametersDown"
        Me.pnlParametersDown.Size = New System.Drawing.Size(347, 44)
        Me.pnlParametersDown.TabIndex = 1
        '
        'btnRemoveParameter
        '
        Me.btnRemoveParameter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveParameter.Enabled = False
        Me.btnRemoveParameter.Location = New System.Drawing.Point(239, 9)
        Me.btnRemoveParameter.Margin = New System.Windows.Forms.Padding(5)
        Me.btnRemoveParameter.Name = "btnRemoveParameter"
        Me.btnRemoveParameter.Size = New System.Drawing.Size(100, 28)
        Me.btnRemoveParameter.TabIndex = 17
        Me.btnRemoveParameter.Text = "Remove"
        Me.btnRemoveParameter.UseVisualStyleBackColor = True
        '
        'btnAddParameter
        '
        Me.btnAddParameter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddParameter.Location = New System.Drawing.Point(129, 9)
        Me.btnAddParameter.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAddParameter.Name = "btnAddParameter"
        Me.btnAddParameter.Size = New System.Drawing.Size(100, 28)
        Me.btnAddParameter.TabIndex = 16
        Me.btnAddParameter.Text = "Add"
        Me.btnAddParameter.UseVisualStyleBackColor = True
        '
        'btnExpression
        '
        Me.btnExpression.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExpression.Enabled = False
        Me.btnExpression.Location = New System.Drawing.Point(9, 9)
        Me.btnExpression.Margin = New System.Windows.Forms.Padding(5)
        Me.btnExpression.Name = "btnExpression"
        Me.btnExpression.Size = New System.Drawing.Size(100, 28)
        Me.btnExpression.TabIndex = 18
        Me.btnExpression.Text = "Expression..."
        Me.btnExpression.UseVisualStyleBackColor = True
        '
        'pnlParametersUp
        '
        Me.pnlParametersUp.Controls.Add(Me.lblParameters)
        Me.pnlParametersUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametersUp.Location = New System.Drawing.Point(0, 0)
        Me.pnlParametersUp.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlParametersUp.Name = "pnlParametersUp"
        Me.pnlParametersUp.Size = New System.Drawing.Size(347, 34)
        Me.pnlParametersUp.TabIndex = 0
        '
        'lblParameters
        '
        Me.lblParameters.AutoSize = True
        Me.lblParameters.Location = New System.Drawing.Point(5, 9)
        Me.lblParameters.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblParameters.Name = "lblParameters"
        Me.lblParameters.Size = New System.Drawing.Size(63, 13)
        Me.lblParameters.TabIndex = 13
        Me.lblParameters.Text = "Parameters:"
        '
        'txtOutput
        '
        Me.txtOutput.BackColor = System.Drawing.Color.DarkBlue
        Me.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOutput.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutput.Location = New System.Drawing.Point(0, 0)
        Me.txtOutput.Margin = New System.Windows.Forms.Padding(5)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.Size = New System.Drawing.Size(966, 196)
        Me.txtOutput.TabIndex = 1
        Me.txtOutput.Text = ""
        '
        'tbpSettings
        '
        Me.tbpSettings.Controls.Add(Me.grpSettingsBatch)
        Me.tbpSettings.Controls.Add(Me.grpOutput)
        Me.tbpSettings.Controls.Add(Me.grpSecurity)
        Me.tbpSettings.Controls.Add(Me.grpSettingsLog)
        Me.tbpSettings.Controls.Add(Me.grpSettingsConnection)
        Me.tbpSettings.Location = New System.Drawing.Point(4, 22)
        Me.tbpSettings.Margin = New System.Windows.Forms.Padding(4)
        Me.tbpSettings.Name = "tbpSettings"
        Me.tbpSettings.Padding = New System.Windows.Forms.Padding(4)
        Me.tbpSettings.Size = New System.Drawing.Size(974, 550)
        Me.tbpSettings.TabIndex = 1
        Me.tbpSettings.Text = "Settings"
        Me.tbpSettings.UseVisualStyleBackColor = True
        '
        'grpSettingsBatch
        '
        Me.grpSettingsBatch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSettingsBatch.Controls.Add(Me.cmbBatchOuputMode)
        Me.grpSettingsBatch.Controls.Add(Me.lblBatchOutputMode)
        Me.grpSettingsBatch.Controls.Add(Me.btnBrowseBatchOutputFile)
        Me.grpSettingsBatch.Controls.Add(Me.txtBatchOutputFile)
        Me.grpSettingsBatch.Controls.Add(Me.chkBatchOutputFile)
        Me.grpSettingsBatch.Controls.Add(Me.lblBatchFailedOutputText)
        Me.grpSettingsBatch.Controls.Add(Me.txtBatchFailedOutputText)
        Me.grpSettingsBatch.Controls.Add(Me.lblBatchSuccessfulOutputText)
        Me.grpSettingsBatch.Controls.Add(Me.txtBatchSuccessfulOutputText)
        Me.grpSettingsBatch.Location = New System.Drawing.Point(8, 264)
        Me.grpSettingsBatch.Name = "grpSettingsBatch"
        Me.grpSettingsBatch.Size = New System.Drawing.Size(958, 109)
        Me.grpSettingsBatch.TabIndex = 19
        Me.grpSettingsBatch.TabStop = False
        Me.grpSettingsBatch.Text = "Batch"
        '
        'cmbBatchOuputMode
        '
        Me.cmbBatchOuputMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbBatchOuputMode.Enabled = False
        Me.cmbBatchOuputMode.FormattingEnabled = True
        Me.cmbBatchOuputMode.Location = New System.Drawing.Point(804, 73)
        Me.cmbBatchOuputMode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbBatchOuputMode.Name = "cmbBatchOuputMode"
        Me.cmbBatchOuputMode.Size = New System.Drawing.Size(144, 21)
        Me.cmbBatchOuputMode.TabIndex = 18
        '
        'lblBatchOutputMode
        '
        Me.lblBatchOutputMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBatchOutputMode.AutoSize = True
        Me.lblBatchOutputMode.Enabled = False
        Me.lblBatchOutputMode.Location = New System.Drawing.Point(758, 76)
        Me.lblBatchOutputMode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBatchOutputMode.Name = "lblBatchOutputMode"
        Me.lblBatchOutputMode.Size = New System.Drawing.Size(37, 13)
        Me.lblBatchOutputMode.TabIndex = 18
        Me.lblBatchOutputMode.Text = "Mode:"
        '
        'btnBrowseBatchOutputFile
        '
        Me.btnBrowseBatchOutputFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseBatchOutputFile.Enabled = False
        Me.btnBrowseBatchOutputFile.Location = New System.Drawing.Point(676, 71)
        Me.btnBrowseBatchOutputFile.Margin = New System.Windows.Forms.Padding(5)
        Me.btnBrowseBatchOutputFile.Name = "btnBrowseBatchOutputFile"
        Me.btnBrowseBatchOutputFile.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseBatchOutputFile.TabIndex = 18
        Me.btnBrowseBatchOutputFile.Text = "Browse..."
        Me.btnBrowseBatchOutputFile.UseVisualStyleBackColor = True
        '
        'txtBatchOutputFile
        '
        Me.txtBatchOutputFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBatchOutputFile.Enabled = False
        Me.txtBatchOutputFile.Location = New System.Drawing.Point(161, 73)
        Me.txtBatchOutputFile.Margin = New System.Windows.Forms.Padding(5)
        Me.txtBatchOutputFile.Name = "txtBatchOutputFile"
        Me.txtBatchOutputFile.Size = New System.Drawing.Size(504, 20)
        Me.txtBatchOutputFile.TabIndex = 18
        '
        'chkBatchOutputFile
        '
        Me.chkBatchOutputFile.AutoSize = True
        Me.chkBatchOutputFile.Location = New System.Drawing.Point(12, 75)
        Me.chkBatchOutputFile.Margin = New System.Windows.Forms.Padding(5)
        Me.chkBatchOutputFile.Name = "chkBatchOutputFile"
        Me.chkBatchOutputFile.Size = New System.Drawing.Size(77, 17)
        Me.chkBatchOutputFile.TabIndex = 18
        Me.chkBatchOutputFile.Text = "Output file:"
        Me.chkBatchOutputFile.UseVisualStyleBackColor = True
        '
        'lblBatchFailedOutputText
        '
        Me.lblBatchFailedOutputText.AutoSize = True
        Me.lblBatchFailedOutputText.Location = New System.Drawing.Point(9, 48)
        Me.lblBatchFailedOutputText.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblBatchFailedOutputText.Name = "lblBatchFailedOutputText"
        Me.lblBatchFailedOutputText.Size = New System.Drawing.Size(120, 13)
        Me.lblBatchFailedOutputText.TabIndex = 19
        Me.lblBatchFailedOutputText.Text = "Failed execution output:"
        '
        'txtBatchFailedOutputText
        '
        Me.txtBatchFailedOutputText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBatchFailedOutputText.Location = New System.Drawing.Point(161, 45)
        Me.txtBatchFailedOutputText.Name = "txtBatchFailedOutputText"
        Me.txtBatchFailedOutputText.Size = New System.Drawing.Size(787, 20)
        Me.txtBatchFailedOutputText.TabIndex = 18
        '
        'lblBatchSuccessfulOutputText
        '
        Me.lblBatchSuccessfulOutputText.AutoSize = True
        Me.lblBatchSuccessfulOutputText.Location = New System.Drawing.Point(9, 22)
        Me.lblBatchSuccessfulOutputText.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblBatchSuccessfulOutputText.Name = "lblBatchSuccessfulOutputText"
        Me.lblBatchSuccessfulOutputText.Size = New System.Drawing.Size(144, 13)
        Me.lblBatchSuccessfulOutputText.TabIndex = 17
        Me.lblBatchSuccessfulOutputText.Text = "Successful execution output:"
        '
        'txtBatchSuccessfulOutputText
        '
        Me.txtBatchSuccessfulOutputText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBatchSuccessfulOutputText.Location = New System.Drawing.Point(161, 19)
        Me.txtBatchSuccessfulOutputText.Name = "txtBatchSuccessfulOutputText"
        Me.txtBatchSuccessfulOutputText.Size = New System.Drawing.Size(787, 20)
        Me.txtBatchSuccessfulOutputText.TabIndex = 0
        '
        'grpOutput
        '
        Me.grpOutput.Controls.Add(Me.chkRemoveRemoveANSIEscapeSequencesFromOutput)
        Me.grpOutput.Location = New System.Drawing.Point(8, 121)
        Me.grpOutput.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpOutput.Name = "grpOutput"
        Me.grpOutput.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpOutput.Size = New System.Drawing.Size(981, 50)
        Me.grpOutput.TabIndex = 18
        Me.grpOutput.TabStop = False
        Me.grpOutput.Text = "Output"
        '
        'chkRemoveRemoveANSIEscapeSequencesFromOutput
        '
        Me.chkRemoveRemoveANSIEscapeSequencesFromOutput.AutoSize = True
        Me.chkRemoveRemoveANSIEscapeSequencesFromOutput.Checked = True
        Me.chkRemoveRemoveANSIEscapeSequencesFromOutput.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRemoveRemoveANSIEscapeSequencesFromOutput.Location = New System.Drawing.Point(5, 21)
        Me.chkRemoveRemoveANSIEscapeSequencesFromOutput.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkRemoveRemoveANSIEscapeSequencesFromOutput.Name = "chkRemoveRemoveANSIEscapeSequencesFromOutput"
        Me.chkRemoveRemoveANSIEscapeSequencesFromOutput.Size = New System.Drawing.Size(244, 17)
        Me.chkRemoveRemoveANSIEscapeSequencesFromOutput.TabIndex = 22
        Me.chkRemoveRemoveANSIEscapeSequencesFromOutput.Text = "Remove ANSI Escape sequences from output"
        Me.chkRemoveRemoveANSIEscapeSequencesFromOutput.UseVisualStyleBackColor = True
        '
        'grpSecurity
        '
        Me.grpSecurity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSecurity.Controls.Add(Me.chkEncryptAutoTelnetScriptFile)
        Me.grpSecurity.Location = New System.Drawing.Point(8, 64)
        Me.grpSecurity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpSecurity.Name = "grpSecurity"
        Me.grpSecurity.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpSecurity.Size = New System.Drawing.Size(958, 50)
        Me.grpSecurity.TabIndex = 17
        Me.grpSecurity.TabStop = False
        Me.grpSecurity.Text = "Security"
        '
        'chkEncryptAutoTelnetScriptFile
        '
        Me.chkEncryptAutoTelnetScriptFile.AutoSize = True
        Me.chkEncryptAutoTelnetScriptFile.Location = New System.Drawing.Point(5, 18)
        Me.chkEncryptAutoTelnetScriptFile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkEncryptAutoTelnetScriptFile.Name = "chkEncryptAutoTelnetScriptFile"
        Me.chkEncryptAutoTelnetScriptFile.Size = New System.Drawing.Size(472, 17)
        Me.chkEncryptAutoTelnetScriptFile.TabIndex = 0
        Me.chkEncryptAutoTelnetScriptFile.Text = "Encrypt AutoTelnet script file (the password field will be encrypted without rega" &
    "rd to this setting)"
        Me.chkEncryptAutoTelnetScriptFile.UseVisualStyleBackColor = True
        '
        'grpSettingsLog
        '
        Me.grpSettingsLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSettingsLog.Controls.Add(Me.chkLogOnlyExecutionStatus)
        Me.grpSettingsLog.Controls.Add(Me.chkLogEncryptCommandResponseEntries)
        Me.grpSettingsLog.Controls.Add(Me.cmbLogMode)
        Me.grpSettingsLog.Controls.Add(Me.lblLogMode)
        Me.grpSettingsLog.Controls.Add(Me.btnBrowseLogFile)
        Me.grpSettingsLog.Controls.Add(Me.chkLogFile)
        Me.grpSettingsLog.Controls.Add(Me.txtLogFile)
        Me.grpSettingsLog.Location = New System.Drawing.Point(8, 177)
        Me.grpSettingsLog.Margin = New System.Windows.Forms.Padding(4)
        Me.grpSettingsLog.Name = "grpSettingsLog"
        Me.grpSettingsLog.Padding = New System.Windows.Forms.Padding(4)
        Me.grpSettingsLog.Size = New System.Drawing.Size(958, 80)
        Me.grpSettingsLog.TabIndex = 16
        Me.grpSettingsLog.TabStop = False
        Me.grpSettingsLog.Text = "Log"
        '
        'chkLogOnlyExecutionStatus
        '
        Me.chkLogOnlyExecutionStatus.AutoSize = True
        Me.chkLogOnlyExecutionStatus.Enabled = False
        Me.chkLogOnlyExecutionStatus.Location = New System.Drawing.Point(219, 50)
        Me.chkLogOnlyExecutionStatus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkLogOnlyExecutionStatus.Name = "chkLogOnlyExecutionStatus"
        Me.chkLogOnlyExecutionStatus.Size = New System.Drawing.Size(146, 17)
        Me.chkLogOnlyExecutionStatus.TabIndex = 18
        Me.chkLogOnlyExecutionStatus.Text = "Log only execution status"
        Me.chkLogOnlyExecutionStatus.UseVisualStyleBackColor = True
        '
        'chkLogEncryptCommandResponseEntries
        '
        Me.chkLogEncryptCommandResponseEntries.AutoSize = True
        Me.chkLogEncryptCommandResponseEntries.Enabled = False
        Me.chkLogEncryptCommandResponseEntries.Location = New System.Drawing.Point(9, 50)
        Me.chkLogEncryptCommandResponseEntries.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkLogEncryptCommandResponseEntries.Name = "chkLogEncryptCommandResponseEntries"
        Me.chkLogEncryptCommandResponseEntries.Size = New System.Drawing.Size(204, 17)
        Me.chkLogEncryptCommandResponseEntries.TabIndex = 17
        Me.chkLogEncryptCommandResponseEntries.Text = "Encrypt command and response entry"
        Me.chkLogEncryptCommandResponseEntries.UseVisualStyleBackColor = True
        '
        'cmbLogMode
        '
        Me.cmbLogMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbLogMode.Enabled = False
        Me.cmbLogMode.FormattingEnabled = True
        Me.cmbLogMode.Location = New System.Drawing.Point(804, 22)
        Me.cmbLogMode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbLogMode.Name = "cmbLogMode"
        Me.cmbLogMode.Size = New System.Drawing.Size(144, 21)
        Me.cmbLogMode.TabIndex = 16
        '
        'lblLogMode
        '
        Me.lblLogMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLogMode.AutoSize = True
        Me.lblLogMode.Enabled = False
        Me.lblLogMode.Location = New System.Drawing.Point(758, 25)
        Me.lblLogMode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLogMode.Name = "lblLogMode"
        Me.lblLogMode.Size = New System.Drawing.Size(37, 13)
        Me.lblLogMode.TabIndex = 15
        Me.lblLogMode.Text = "Mode:"
        '
        'btnBrowseLogFile
        '
        Me.btnBrowseLogFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseLogFile.Enabled = False
        Me.btnBrowseLogFile.Location = New System.Drawing.Point(676, 21)
        Me.btnBrowseLogFile.Margin = New System.Windows.Forms.Padding(5)
        Me.btnBrowseLogFile.Name = "btnBrowseLogFile"
        Me.btnBrowseLogFile.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseLogFile.TabIndex = 14
        Me.btnBrowseLogFile.Text = "Browse..."
        Me.btnBrowseLogFile.UseVisualStyleBackColor = True
        '
        'chkLogFile
        '
        Me.chkLogFile.AutoSize = True
        Me.chkLogFile.Location = New System.Drawing.Point(9, 25)
        Me.chkLogFile.Margin = New System.Windows.Forms.Padding(5)
        Me.chkLogFile.Name = "chkLogFile"
        Me.chkLogFile.Size = New System.Drawing.Size(63, 17)
        Me.chkLogFile.TabIndex = 12
        Me.chkLogFile.Text = "Log file:"
        Me.chkLogFile.UseVisualStyleBackColor = True
        '
        'txtLogFile
        '
        Me.txtLogFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLogFile.Enabled = False
        Me.txtLogFile.Location = New System.Drawing.Point(99, 22)
        Me.txtLogFile.Margin = New System.Windows.Forms.Padding(5)
        Me.txtLogFile.Name = "txtLogFile"
        Me.txtLogFile.Size = New System.Drawing.Size(566, 20)
        Me.txtLogFile.TabIndex = 13
        '
        'grpSettingsConnection
        '
        Me.grpSettingsConnection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSettingsConnection.Controls.Add(Me.nudAttemptsRetryReading)
        Me.grpSettingsConnection.Controls.Add(Me.lblAttemptsRetryReading)
        Me.grpSettingsConnection.Controls.Add(Me.lblDelayReadTime)
        Me.grpSettingsConnection.Controls.Add(Me.nudDelayReadTime)
        Me.grpSettingsConnection.Controls.Add(Me.nudPort)
        Me.grpSettingsConnection.Controls.Add(Me.lblPort)
        Me.grpSettingsConnection.Location = New System.Drawing.Point(8, 7)
        Me.grpSettingsConnection.Margin = New System.Windows.Forms.Padding(4)
        Me.grpSettingsConnection.Name = "grpSettingsConnection"
        Me.grpSettingsConnection.Padding = New System.Windows.Forms.Padding(4)
        Me.grpSettingsConnection.Size = New System.Drawing.Size(958, 50)
        Me.grpSettingsConnection.TabIndex = 15
        Me.grpSettingsConnection.TabStop = False
        Me.grpSettingsConnection.Text = "Connection"
        '
        'nudAttemptsRetryReading
        '
        Me.nudAttemptsRetryReading.Location = New System.Drawing.Point(549, 22)
        Me.nudAttemptsRetryReading.Margin = New System.Windows.Forms.Padding(5)
        Me.nudAttemptsRetryReading.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nudAttemptsRetryReading.Name = "nudAttemptsRetryReading"
        Me.nudAttemptsRetryReading.Size = New System.Drawing.Size(80, 20)
        Me.nudAttemptsRetryReading.TabIndex = 21
        Me.nudAttemptsRetryReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAttemptsRetryReading
        '
        Me.lblAttemptsRetryReading.AutoSize = True
        Me.lblAttemptsRetryReading.Location = New System.Drawing.Point(388, 25)
        Me.lblAttemptsRetryReading.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblAttemptsRetryReading.Name = "lblAttemptsRetryReading"
        Me.lblAttemptsRetryReading.Size = New System.Drawing.Size(112, 13)
        Me.lblAttemptsRetryReading.TabIndex = 20
        Me.lblAttemptsRetryReading.Text = "Attempts retry reading:"
        '
        'tbpNotes
        '
        Me.tbpNotes.Controls.Add(Me.chkUnderline)
        Me.tbpNotes.Controls.Add(Me.chkItalic)
        Me.tbpNotes.Controls.Add(Me.chkBold)
        Me.tbpNotes.Controls.Add(Me.txtNotes)
        Me.tbpNotes.Location = New System.Drawing.Point(4, 22)
        Me.tbpNotes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbpNotes.Name = "tbpNotes"
        Me.tbpNotes.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbpNotes.Size = New System.Drawing.Size(974, 550)
        Me.tbpNotes.TabIndex = 2
        Me.tbpNotes.Text = "Notes"
        Me.tbpNotes.UseVisualStyleBackColor = True
        '
        'chkUnderline
        '
        Me.chkUnderline.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkUnderline.Enabled = False
        Me.chkUnderline.Image = CType(resources.GetObject("chkUnderline.Image"), System.Drawing.Image)
        Me.chkUnderline.Location = New System.Drawing.Point(69, 6)
        Me.chkUnderline.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkUnderline.Name = "chkUnderline"
        Me.chkUnderline.Size = New System.Drawing.Size(25, 25)
        Me.chkUnderline.TabIndex = 3
        Me.chkUnderline.UseVisualStyleBackColor = True
        '
        'chkItalic
        '
        Me.chkItalic.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkItalic.Enabled = False
        Me.chkItalic.Image = CType(resources.GetObject("chkItalic.Image"), System.Drawing.Image)
        Me.chkItalic.Location = New System.Drawing.Point(39, 6)
        Me.chkItalic.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkItalic.Name = "chkItalic"
        Me.chkItalic.Size = New System.Drawing.Size(25, 25)
        Me.chkItalic.TabIndex = 2
        Me.chkItalic.UseVisualStyleBackColor = True
        '
        'chkBold
        '
        Me.chkBold.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkBold.Enabled = False
        Me.chkBold.Image = CType(resources.GetObject("chkBold.Image"), System.Drawing.Image)
        Me.chkBold.Location = New System.Drawing.Point(8, 6)
        Me.chkBold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkBold.Name = "chkBold"
        Me.chkBold.Size = New System.Drawing.Size(25, 25)
        Me.chkBold.TabIndex = 1
        Me.chkBold.UseVisualStyleBackColor = True
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotes.Location = New System.Drawing.Point(8, 37)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(960, 506)
        Me.txtNotes.TabIndex = 0
        Me.txtNotes.Text = ""
        '
        'sfdLog
        '
        Me.sfdLog.DefaultExt = "log"
        Me.sfdLog.Filter = "Log files (*.log)|*.log|All files|*.*"
        Me.sfdLog.Title = "Choose AutoTelnet log file"
        '
        'bkwScript
        '
        Me.bkwScript.WorkerReportsProgress = True
        Me.bkwScript.WorkerSupportsCancellation = True
        '
        'ofdScript
        '
        Me.ofdScript.DefaultExt = "ats"
        Me.ofdScript.Filter = "AutoTelnet script files|*.ats"
        Me.ofdScript.Title = "Open AutoTelnet script"
        '
        'sfdScript
        '
        Me.sfdScript.DefaultExt = "ats"
        Me.sfdScript.Filter = "AutoTelnet script files (*.ats)|*.ats"
        Me.sfdScript.Title = "Save AutoTelnet script"
        '
        'sfdBatchOutputFile
        '
        Me.sfdBatchOutputFile.DefaultExt = "log"
        Me.sfdBatchOutputFile.Filter = "Output files (*.out)|*.out|All files|*.*"
        Me.sfdBatchOutputFile.Title = "Choose AutoTelnet output file"
        '
        'ofdLog
        '
        Me.ofdLog.DefaultExt = "log"
        Me.ofdLog.Filter = "Log files (*.log)|*.log|All files|*.*"
        Me.ofdLog.Title = "Choose AutoTelnet log file"
        '
        'MainForm
        '
        Me.ClientSize = New System.Drawing.Size(982, 653)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.stsMain)
        Me.Controls.Add(Me.tlsMain)
        Me.Controls.Add(Me.mnsMain)
        Me.MainMenuStrip = Me.mnsMain
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.mnsMain.ResumeLayout(False)
        Me.mnsMain.PerformLayout()
        Me.tlsMain.ResumeLayout(False)
        Me.tlsMain.PerformLayout()
        CType(Me.nudDelayReadTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsMain.ResumeLayout(False)
        Me.stsMain.PerformLayout()
        Me.tabMain.ResumeLayout(False)
        Me.tbpCommands.ResumeLayout(False)
        Me.spcCommands1.Panel1.ResumeLayout(False)
        Me.spcCommands1.Panel2.ResumeLayout(False)
        CType(Me.spcCommands1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcCommands1.ResumeLayout(False)
        Me.spcCommands2.Panel1.ResumeLayout(False)
        Me.spcCommands2.Panel2.ResumeLayout(False)
        CType(Me.spcCommands2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcCommands2.ResumeLayout(False)
        Me.pnlCommandsDown.ResumeLayout(False)
        Me.pnlCommandsDown.PerformLayout()
        Me.pnlCommandsUp.ResumeLayout(False)
        Me.pnlCommandsUp.PerformLayout()
        CType(Me.grdParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametersDown.ResumeLayout(False)
        Me.pnlParametersUp.ResumeLayout(False)
        Me.pnlParametersUp.PerformLayout()
        Me.tbpSettings.ResumeLayout(False)
        Me.grpSettingsBatch.ResumeLayout(False)
        Me.grpSettingsBatch.PerformLayout()
        Me.grpOutput.ResumeLayout(False)
        Me.grpOutput.PerformLayout()
        Me.grpSecurity.ResumeLayout(False)
        Me.grpSecurity.PerformLayout()
        Me.grpSettingsLog.ResumeLayout(False)
        Me.grpSettingsLog.PerformLayout()
        Me.grpSettingsConnection.ResumeLayout(False)
        Me.grpSettingsConnection.PerformLayout()
        CType(Me.nudAttemptsRetryReading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpNotes.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnsMain As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniFileNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniFileOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tssFile1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mniFileSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniFileSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tssFile2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mniFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniToolsLogViewer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tlsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRun As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLogViewer As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbSendEndOfLine As System.Windows.Forms.ComboBox
    Friend WithEvents lblSendEndOfLineChar As System.Windows.Forms.Label
    Friend WithEvents nudDelayReadTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDelayReadTime As System.Windows.Forms.Label
    Friend WithEvents nudPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents lblHost As System.Windows.Forms.Label
    Friend WithEvents stsMain As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tbpCommands As System.Windows.Forms.TabPage
    Friend WithEvents tbpSettings As System.Windows.Forms.TabPage
    Friend WithEvents spcCommands1 As System.Windows.Forms.SplitContainer
    Friend WithEvents spcCommands2 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtOutput As System.Windows.Forms.RichTextBox
    Friend WithEvents pnlCommandsUp As System.Windows.Forms.Panel
    Friend WithEvents pnlCommandsDown As System.Windows.Forms.Panel
    Friend WithEvents chkSendPassword As System.Windows.Forms.CheckBox
    Friend WithEvents chkSendUser As System.Windows.Forms.CheckBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtScript As System.Windows.Forms.RichTextBox
    Friend WithEvents pnlParametersUp As System.Windows.Forms.Panel
    Friend WithEvents lblParameters As System.Windows.Forms.Label
    Friend WithEvents pnlParametersDown As System.Windows.Forms.Panel
    Friend WithEvents grdParameters As System.Windows.Forms.DataGridView
    Friend WithEvents colParametersName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colParametersDefaultValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colParametersValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnRemoveParameter As System.Windows.Forms.Button
    Friend WithEvents btnAddParameter As System.Windows.Forms.Button
    Friend WithEvents btnExpression As System.Windows.Forms.Button
    Friend WithEvents grpSettingsLog As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowseLogFile As System.Windows.Forms.Button
    Friend WithEvents chkLogFile As System.Windows.Forms.CheckBox
    Friend WithEvents txtLogFile As System.Windows.Forms.TextBox
    Friend WithEvents grpSettingsConnection As System.Windows.Forms.GroupBox
    Friend WithEvents sfdLog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents bkwScript As System.ComponentModel.BackgroundWorker
    Friend WithEvents ofdScript As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sfdScript As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cmbLogMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblLogMode As System.Windows.Forms.Label
    Friend WithEvents mniActions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniActionsRun As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mniActionsStop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkLogEncryptCommandResponseEntries As System.Windows.Forms.CheckBox
    Friend WithEvents grpSecurity As System.Windows.Forms.GroupBox
    Friend WithEvents chkEncryptAutoTelnetScriptFile As System.Windows.Forms.CheckBox
    Friend WithEvents tbpNotes As System.Windows.Forms.TabPage
    Friend WithEvents txtNotes As System.Windows.Forms.RichTextBox
    Friend WithEvents chkBold As System.Windows.Forms.CheckBox
    Friend WithEvents chkUnderline As System.Windows.Forms.CheckBox
    Friend WithEvents chkItalic As System.Windows.Forms.CheckBox
    Friend WithEvents lblAttemptsRetryReading As System.Windows.Forms.Label
    Friend WithEvents nudAttemptsRetryReading As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkRemoveRemoveANSIEscapeSequencesFromOutput As System.Windows.Forms.CheckBox
    Friend WithEvents grpOutput As System.Windows.Forms.GroupBox
    Friend WithEvents btnInsertSelectedParameter As System.Windows.Forms.Button
    Friend WithEvents tipMain As System.Windows.Forms.ToolTip
    Friend WithEvents grpSettingsBatch As System.Windows.Forms.GroupBox
    Friend WithEvents lblBatchSuccessfulOutputText As System.Windows.Forms.Label
    Friend WithEvents txtBatchSuccessfulOutputText As System.Windows.Forms.TextBox
    Friend WithEvents lblBatchFailedOutputText As System.Windows.Forms.Label
    Friend WithEvents txtBatchFailedOutputText As System.Windows.Forms.TextBox
    Friend WithEvents txtBatchOutputFile As System.Windows.Forms.TextBox
    Friend WithEvents chkBatchOutputFile As System.Windows.Forms.CheckBox
    Friend WithEvents cmbBatchOuputMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblBatchOutputMode As System.Windows.Forms.Label
    Friend WithEvents btnBrowseBatchOutputFile As System.Windows.Forms.Button
    Friend WithEvents sfdBatchOutputFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents chkLogOnlyExecutionStatus As System.Windows.Forms.CheckBox
    Friend WithEvents ofdLog As OpenFileDialog
End Class
