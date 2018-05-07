Public Class SPBuild
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
    clbType.ClearSelected()
    clbOptions.ClearSelected()
  End Sub

  Private Sub btnBuild_Click(sender As Object, e As EventArgs) Handles btnBuild.Click
    Dim DBBuilder As New Includes.SPBuilder(txtConnString.Text)
    Dim TableRec As New Includes.Types.TableFmt

    TableRec.sConnString = txtConnString.Text
    TableRec.sTable = cbxTable.Text

    For Each item In clbType.CheckedItems
      Select Case item.ToString.ToLower
        Case "Delete"
          TableRec.Action += 8
        Case "Select All Records"
          TableRec.Action += 1
        Case "Insert"
          TableRec.Action += 2
        Case "Update"
          TableRec.Action += 4
        Case Else
          TableRec.Action += 16
      End Select
    Next

    TableRec.User = cbxUser.SelectedValue

    For Each item In clbOptions.CheckedItems
      Select Case item.ToString.ToLower
        Case "Archived Table"
          TableRec.addOption(Includes.Types.CallBuilder.UseArchive)
        Case "Output to History Table"
          TableRec.addOption(Includes.Types.CallBuilder.UseOutput)
      End Select
    Next

    TableRec.sUsername = My.User.Name

    DBBuilder.Create_Multiple_SP(TableRec)

    txtCode.Text = TableRec.sSQL

  End Sub

  Private Sub SPBuild_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim bs As New BindingSource

    bs.DataSource = Includes.clsCommon.getSPUsers
    cbxUser.DataSource = bs


  End Sub
End Class