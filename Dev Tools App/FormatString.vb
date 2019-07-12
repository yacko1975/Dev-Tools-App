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
    Dim sbOutput As New Text.StringBuilder()
    Dim sFormat As String = txtFormat.Text

    Dim asLine = txtCSVData.Text.Replace(ControlChars.CrLf, ControlChars.Cr).Replace(ControlChars.Lf, ControlChars.Cr).Split(ControlChars.Cr)

    For Each sLine In asLine
      Dim asData = sLine.Split(txtSeparator.Text)

      sbOutput.AppendFormat(sFormat, asData)
      sbOutput.AppendLine()

    Next



    txtResults.Text = sbOutput.ToString()



  End Sub


End Class