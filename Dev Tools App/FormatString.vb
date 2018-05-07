Public Class FormatString
  Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
    txtCSVData.Text = String.Empty
    txtFormat.Text = String.Empty
    txtResults.Text = String.Empty
    txtSeparator.Text = String.Empty
    cbxSingleLine.Checked = False

  End Sub

  Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
    Clipboard.SetText(txtResults.Text)
  End Sub

  Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click

  End Sub
End Class