Imports System.Windows.Forms

Public Class ExpressionDialog
    Public Expression As String = String.Empty

    Public Property SelectIDOnLoad As UtilExpression.ExpressionIDs = UtilExpression.ExpressionIDs.Unknown
    Public Property SetFormatOnLoad As String = String.Empty
    Public Property SetParameterOnLoad As String = String.Empty

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Expression = UtilExpression.GetExpression(DirectCast(Me.lsvMain.SelectedItems(0).Tag, UtilExpression.ExpressionIDs), Me.txtFormat.Text, Me.txtParameter.Text)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub VariablesDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Fill ListView
        For Each id As UtilExpression.ExpressionIDs In GetType(UtilExpression.ExpressionIDs).GetEnumValues()

            If Not id.GetHiddenAttributeValue() Then
                With Me.lsvMain.AddItem(System.Enum.GetName(GetType(UtilExpression.ExpressionIDs), id))
                    .Tag = id
                    .SubItems(Me.colDescription.Index).Text = id.GetDescriptionAttributeValue()
                    .SubItems(Me.colDefaultFormat.Index).Text = id.GetDefautFormatAttributeValue()
                    .SubItems(Me.colDefaultParameter.Index).Text = id.GetDefautParameterAttributeValue().ToString()

                    'Selezione ID
                    If Me.SelectIDOnLoad = id Then .Selected = True
                End With
            End If
        Next

        'Set Format
        If Me.txtFormat.Enabled AndAlso String.IsNullOrEmpty(Me.SetFormatOnLoad) Then
            Me.txtFormat.Text = Me.SetFormatOnLoad
        End If

        'Set Parameter
        If Me.txtParameter.Enabled AndAlso Not String.IsNullOrEmpty(Me.SetParameterOnLoad) Then
            Me.txtParameter.Text = Me.SetParameterOnLoad
        End If
    End Sub

    Private Sub btnEvaluate_Click(sender As Object, e As EventArgs) Handles btnEvaluate.Click
        Try
            Me.txtValue.ResetText()
            Me.txtValue.Text = UtilExpression.GetValue(DirectCast(Me.lsvMain.SelectedItems(0).Tag, UtilExpression.ExpressionIDs), Me.txtFormat.Text, Me.txtParameter.Text)
        Catch ex As Exception
            UtilMsgBox.ShowErrorException(ex, False)
        End Try
    End Sub

    Private Sub lsvMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvMain.SelectedIndexChanged
        If lsvMain.SelectedItems.Count = 1 Then
            Me.txtFormat.Text = Me.lsvMain.SelectedItems(0).SubItems(Me.colDefaultFormat.Index).Text
            Me.txtFormat.Enabled = DirectCast(Me.lsvMain.SelectedItems(0).Tag, UtilExpression.ExpressionIDs).GetFormattableAttributeValue()
            Me.txtParameter.Text = Me.lsvMain.SelectedItems(0).SubItems(Me.colDefaultParameter.Index).Text
            Me.txtParameter.Enabled = DirectCast(Me.lsvMain.SelectedItems(0).Tag, UtilExpression.ExpressionIDs).GetParameterableAttributeValue()

            Me.btnEvaluate.Enabled = True
            Me.btnEvaluate.PerformClick()
            Me.txtFormat.Focus()
        Else
            Me.txtFormat.ResetText()
            Me.txtFormat.Enabled = False
            Me.txtValue.ResetText()
            Me.btnEvaluate.Enabled = False
        End If
    End Sub
End Class
