Public Class Options


  Private Sub btnCancel_Click(sender As Object, e As EventArgs)

  End Sub

  Private Sub Options_Load(sender As Object, e As EventArgs) Handles Me.Load

    txtRemoveNullsFuncName.Text = My.Settings.RemoveNullsFunction
    txtSendNullsFuncName.Text = My.Settings.SendNullsFunction
    txtServerNames.Text = My.Settings.histServer
    txtConnStrings.Text = My.Settings.histConnectionString
    cbxLanguage.SelectedItem = My.Settings.langDefault

  End Sub

  Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
    If MsgBox("This will reset all settings to the default are you sure you want to do this?", MsgBoxStyle.YesNo, "Reset to Default?") = MsgBoxResult.Yes Then
      My.Settings.Reset()
      txtRemoveNullsFuncName.Text = My.Settings.RemoveNullsFunction
      txtSendNullsFuncName.Text = My.Settings.SendNullsFunction
      txtServerNames.Text = My.Settings.histServer
      txtConnStrings.Text = My.Settings.histConnectionString
      cbxLanguage.SelectedItem = My.Settings.langDefault
    End If


  End Sub

  Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    My.Settings.langDefault = cbxLanguage.SelectedItem
    My.Settings.RemoveNullsFunction = txtRemoveNullsFuncName.Text.Trim
    My.Settings.SendNullsFunction = txtSendNullsFuncName.Text.Trim
    My.Settings.histServer = txtServerNames.Text.Trim
    My.Settings.histConnectionString = txtConnStrings.Text.Trim

    My.Settings.Save()
    Me.Close()

  End Sub
End Class