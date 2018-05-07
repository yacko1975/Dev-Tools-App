Public Class LoadFormFromTable
  Private Sub btnCreateConnStr_Click(sender As Object, e As EventArgs) Handles btnCreateConnStr.Click
    Dim csBuilder As New SqlClient.SqlConnectionStringBuilder

    If String.IsNullOrWhiteSpace(txtConnString.Text) Then
      csBuilder.IntegratedSecurity = True
      csBuilder.InitialCatalog = "master"
    Else
      Try
        csBuilder.ConnectionString = txtConnString.Text



      Catch ex As Exception
        csBuilder.IntegratedSecurity = True
        csBuilder.InitialCatalog = "master"
      End Try
    End If


    Dim dcDialog As New SQLDialog(csBuilder)




    If (DialogResult.OK = dcDialog.ShowDialog()) Then
      txtConnString.Text = dcDialog.ConnStrBuilder.ConnectionString
      UpdateTableViews()


    End If




  End Sub

  Private Sub btnRefreshTbl_Click(sender As Object, e As EventArgs) Handles btnRefreshTbl.Click

    UpdateTableViews()


  End Sub

  Private Sub UpdateTableViews()
    Dim DBGlobal As New Includes.clsDBGlobal(txtConnString.Text)


    cbxTable.DataSource = DBGlobal.Get_ViewsandTables()

  End Sub

  Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
    Clipboard.SetText(txtCode.Text)
  End Sub

  Private Sub SPBuild_Resize(sender As Object, e As EventArgs) Handles Me.Resize
    txtCode.Height = Me.Size.Height - txtCode.Location.Y - (40) 'Border
    txtCode.Width = Me.Size.Width - 28 'Border
  End Sub

  Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
    txtCode.Text = String.Empty
    cbxFormType.SelectedText = "Load Labels from Type Class"
  End Sub

  Private Sub btnBuild_Click(sender As Object, e As EventArgs) Handles btnBuild.Click
    Dim FormBuilder As New Includes.BuildForm(txtConnString.Text)
    Dim TableRec As New Includes.Types.TableFmt

    TableRec.sConnString = txtConnString.Text
    TableRec.sTable = cbxTable.Text

    Select Case cbxFormType.Text
      Case "Load Labels from Type Class"
        TableRec.sFormType = "TOLBL"
      Case "Load Text Boxes from Type Class"
        TableRec.sFormType = "TOTXT"
      Case Else
        TableRec.sFormType = "TOLBL"
    End Select

    If cbxLanguage.Text = "C#" Then
      TableRec.Language = Includes.Types.enLanguage.CS
    Else
      TableRec.Language = Includes.Types.enLanguage.VB
    End If

    TableRec.sUsername = My.User.Name

    FormBuilder.Build_Form(TableRec)

    txtCode.Text = TableRec.sForm

  End Sub

  Private Sub SPBuild_Load(sender As Object, e As EventArgs) Handles Me.Load

    If My.Settings.langDefault = "C#" Then
      cbxLanguage.SelectedIndex = 0
    Else
      cbxLanguage.SelectedIndex = 1
    End If

    cbxFormType.SelectedIndex = 0

  End Sub
End Class