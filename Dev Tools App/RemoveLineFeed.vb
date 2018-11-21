Public Class RemoveLineFeed
  Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
    Clipboard.SetText(txtResults.Text)
  End Sub

  Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
    txtResults.Text = String.Empty
  End Sub

  Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
    txtResults.Text = txtResults.Text.Replace(vbCrLf, String.Empty).Replace(vbLf, String.Empty).Replace(vbCr, String.Empty)
  End Sub
End Class