Public Class CreateTypeFromTable
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

  End Sub

  Private Sub btnBuild_Click(sender As Object, e As EventArgs) Handles btnBuild.Click
    Dim TypeBuilder As New Includes.TypeBuilder(txtConnString.Text)
    Dim TableRec As New Includes.Types.TableFmt

    TableRec.sConnString = txtConnString.Text
    TableRec.sTable = cbxTable.Text

    If cbxLanguage.Text = "C#" Then
      TableRec.Language = Includes.Types.enLanguage.CS
    Else
      TableRec.Language = Includes.Types.enLanguage.VB
    End If

    TableRec.sUsername = My.User.Name

    For Each item In clbOptions.CheckedItems
      Select Case item.ToString
        Case "Use properties to set values"
          TableRec.bProperties = True
        Case "Include class definition"
          TableRec.bIncludeClassDefinition = True
        Case "Include region"
          TableRec.bIncludeRegion = True

        Case Else

      End Select
    Next


    TypeBuilder.Build_Type(TableRec)

    txtCode.Text = TableRec.sTypeClass

  End Sub

  Private Sub SPBuild_Load(sender As Object, e As EventArgs) Handles Me.Load

    If My.Settings.langDefault = "C#" Then
      cbxLanguage.SelectedIndex = 0
    Else
      cbxLanguage.SelectedIndex = 1
    End If



  End Sub
End Class