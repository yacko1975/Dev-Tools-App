Public Class SPBuilder
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
    End If

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
    clbOptions.SetItemChecked(0, True)
  End Sub

  Private Sub btnBuild_Click(sender As Object, e As EventArgs) Handles btnBuild.Click
    Dim DBBuilder As New Includes.DBBuilder(txtConnString.Text)
    Dim TableRec As New Includes.Types.TableFmt

    TableRec.sConnString = txtConnString.Text


    For Each item In clbOptions.CheckedItems
      Select Case item.ToString
        Case "Include Exception Handling"
          TableRec.addOption(Includes.Types.CallBuilder.ExceptionHandling)
        Case "This function returns a data reader"
          TableRec.addOption(Includes.Types.CallBuilder.DataReader)
        Case "Remove Nulls from output using KDOR.clsdbfunctions.RemoveNulls"
          TableRec.addOption(Includes.Types.CallBuilder.RemoveNulls)
        Case "Pass Nulls using KDOR.clsdbfunctions.SendNulls"
          TableRec.addOption(Includes.Types.CallBuilder.SendNulls)
        Case "Use Local Variables based on the table for variables"
          TableRec.addOption(Includes.Types.CallBuilder.TableCls)
        Case "Use Type Class Generated on a table for variables"
          TableRec.addOption(Includes.Types.CallBuilder.UseLocal)
        Case "Use private connection string (_ConnectionString)"
          TableRec.addOption(Includes.Types.CallBuilder.PrivateConnectionString)
        Case "Create the entire class, not just the function"
          TableRec.addOption(Includes.Types.CallBuilder.CreateNewClass)
        Case "Use Transactions in the Generated Code"
          TableRec.addOption(Includes.Types.CallBuilder.UseTransaction, Includes.Types.CallBuilder.UseGlobalConnection)
        Case "Use Global Connection in the Generated Code"
          TableRec.addOption(Includes.Types.CallBuilder.UseGlobalConnection)
        Case "Use Optional Arguements for Inputs"
          TableRec.addOption(Includes.Types.CallBuilder.CreateOptionalArgument)
      End Select
    Next

    TableRec.SPName = txtProc.Text


    TableRec.sUsername = My.User.Name

    If cbxLanguage.Text = "C#" Then
      txtCode.Text = DBBuilder.Build_SP_Code_CS(TableRec)
    Else
      txtCode.Text = DBBuilder.Build_SP_Code_VB(TableRec)
    End If



  End Sub

  Private Sub SPBuild_Load(sender As Object, e As EventArgs) Handles Me.Load

    If My.Settings.langDefault = "C#" Then
      cbxLanguage.SelectedIndex = 0
    Else
      cbxLanguage.SelectedIndex = 1
    End If

    clbOptions.SetItemChecked(0, True)

  End Sub


End Class