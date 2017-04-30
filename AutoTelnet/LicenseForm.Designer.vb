<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LicenseForm
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
        Me.btnDecline = New System.Windows.Forms.Button
        Me.btnAgree = New System.Windows.Forms.Button
        Me.rtbLicense = New System.Windows.Forms.RichTextBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnDecline
        '
        Me.btnDecline.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDecline.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDecline.Location = New System.Drawing.Point(405, 231)
        Me.btnDecline.Name = "btnDecline"
        Me.btnDecline.Size = New System.Drawing.Size(75, 23)
        Me.btnDecline.TabIndex = 0
        Me.btnDecline.Text = "Decline"
        Me.btnDecline.UseVisualStyleBackColor = True
        '
        'btnAgree
        '
        Me.btnAgree.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgree.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAgree.Location = New System.Drawing.Point(324, 231)
        Me.btnAgree.Name = "btnAgree"
        Me.btnAgree.Size = New System.Drawing.Size(75, 23)
        Me.btnAgree.TabIndex = 1
        Me.btnAgree.Text = "Agree"
        Me.btnAgree.UseVisualStyleBackColor = True
        '
        'rtbLicense
        '
        Me.rtbLicense.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbLicense.Location = New System.Drawing.Point(12, 12)
        Me.rtbLicense.Name = "rtbLicense"
        Me.rtbLicense.Size = New System.Drawing.Size(468, 213)
        Me.rtbLicense.TabIndex = 2
        Me.rtbLicense.Text = ""
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(12, 231)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'LicenseForm
        '
        Me.AcceptButton = Me.btnAgree
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnDecline
        Me.ClientSize = New System.Drawing.Size(492, 266)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.rtbLicense)
        Me.Controls.Add(Me.btnAgree)
        Me.Controls.Add(Me.btnDecline)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LicenseForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "{0} License Agreement"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDecline As System.Windows.Forms.Button
    Friend WithEvents btnAgree As System.Windows.Forms.Button
    Friend WithEvents rtbLicense As System.Windows.Forms.RichTextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
