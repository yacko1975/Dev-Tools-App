Public Class FormCreate
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
    cbxFormType.SelectedText = "Read Only (Labels)"
    clbOptions.ClearSelected()
  End Sub

  Private Sub btnBuild_Click(sender As Object, e As EventArgs) Handles btnBuild.Click
    Dim FormBuilder As New Includes.BuildForm(txtConnString.Text)
    Dim TableRec As New Includes.Types.TableFmt

    TableRec.sConnString = txtConnString.Text
    TableRec.sTable = cbxTable.Text


    If cbxFormType.Text = "Read Only (Labels)" Then
      TableRec.sFormType = "RO"
    Else
      TableRec.sFormType = "RW"
    End If

    For Each item In clbOptions.CheckedItems
      Select Case item.ToString
        Case "Include FieldSet Fields"
          TableRec.FormOptions += 1
        Case "Include Validation Summary Control"
          TableRec.FormOptions += 2
        Case "Create Tips Below Textboxes or Labels"
          TableRec.FormOptions += 4
        Case "Include Submit Button"
          TableRec.FormOptions += 8
        Case "Include Cancel Link"
          TableRec.FormOptions += 16
        Case "Include Edit Link"
          TableRec.FormOptions += 32
        Case "Include Delete Button"
          TableRec.FormOptions += 64
        Case "Include Yes/No Section"
          TableRec.FormOptions += 128
      End Select
    Next

    TableRec.sUsername = My.User.Name

    FormBuilder.Build_Form(TableRec)

    txtCode.Text = TableRec.sForm

  End Sub

  Private Sub SPBuild_Load(sender As Object, e As EventArgs) Handles Me.Load


  End Sub
End Class