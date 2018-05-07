Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Text

Namespace Includes

  Public Class FormBuilder2
    Private _ConnectionString As String

    Public Sub Build_Form(ByRef TableRec As Types.TableFmt)
      Dim DB As New clsDBGlobal(_ConnectionString)
      TableRec.aylPrimaryKey = DB.Get_Primary_Keys(TableRec)
      TableRec.aylColumn = DB.Get_Columns(TableRec)

      Select Case TableRec.sFormType
        Case "RO"
          TableRec.sForm = Create_RO_Form(TableRec)
        Case "RW"
          TableRec.sForm = Create_RW_Form(TableRec)
      End Select


    End Sub


    Private Function Create_RO_Form(ByVal TableRec As Types.TableFmt) As String
      Dim sbType As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim iPntr As Int32
      Dim sFieldName As String

      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      With sbType

        .Append("<h1>Page Description</h1>")
        .Append(ControlChars.CrLf)

        If TableRec.FormOptions And Types.enuFormOptions.FieldSet Then
          .Append("<fieldset>")
          .Append(ControlChars.CrLf)
          .Append("<legend>")
          .Append(TableRec.sTable)
          .Append("</legend>")
          .Append(ControlChars.CrLf)
        End If

        If TableRec.FormOptions And Types.enuFormOptions.ValidationSummary Then
          .Append(CreateValidationSummary())
        End If

        If TableRec.FormOptions And Types.enuFormOptions.YesNo Then
          .Append(CreateYesNoPanel)
        End If

        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          sFieldName = String.Format("lbl{0}", ColumnRec(iPntr).sColumnName)

          .Append("<div class=""control-group"">")
          .Append(ControlChars.CrLf)

          'Create Label
          .Append(ControlChars.Tab)
          .Append("<label class=""control-label"" for=""cphBody_")
          .Append(sFieldName)
          .Append(""">")
          .Append(sFieldName)
          .Append("</label>")
          .Append(ControlChars.CrLf)

          'Create Control div
          .Append("<div class=""controls"">")
          .Append(ControlChars.CrLf)

          'Create Label
          .Append(ControlChars.Tab)
          .Append("<asp:Label ID=""")
          .Append(sFieldName)
          .Append(""" runat=""server""></asp:Label>")
          If TableRec.FormOptions And Types.enuFormOptions.Tips Then
            .Append(ControlChars.CrLf)
            .Append(ControlChars.Tab)
            .Append("<p>Information about above box</p>")
          End If
          .Append(ControlChars.CrLf)

          .Append("</div>")
          .Append(ControlChars.CrLf)

          .Append("</div>")
          .Append(ControlChars.CrLf)
        Next

        If (TableRec.FormOptions And Types.enuFormOptions.Submit) Or
    TableRec.FormOptions And Types.enuFormOptions.Edit Or
    TableRec.FormOptions And Types.enuFormOptions.Cancel Or
    TableRec.FormOptions And Types.enuFormOptions.Delete Then
          .Append("<div class=""control-button"">")
          .Append(ControlChars.CrLf)

          .Append("<div class=""controls"">")
          .Append(ControlChars.CrLf)

          If TableRec.FormOptions And Types.enuFormOptions.Cancel Then
            .Append("<asp:HyperLink ID=""hlnkCancel"" runat=""server"" CssClass=""btn btn-cancel"">Cancel</asp:HyperLink>")
            .Append(ControlChars.CrLf)
          End If
          If TableRec.FormOptions And Types.enuFormOptions.Edit Then
            .Append("<asp:HyperLink ID=""hlnkEdit"" runat=""server"" CssClass=""btn btn-main"">Edit</asp:HyperLink>")
            .Append(ControlChars.CrLf)
          End If
          If TableRec.FormOptions And Types.enuFormOptions.Delete Then
            .Append("<asp:LinkButton ID=""btnDelete"" runat=""server"" CssClass=""btn btn-danger"">Delete</asp:LinkButton>")
            .Append(ControlChars.CrLf)
          End If
          If TableRec.FormOptions And Types.enuFormOptions.Submit Then
            .Append("<asp:LinkButton ID=""btnSubmit"" runat=""server"" CssClass=""btn btn-main"">Submit</asp:LinkButton>")
            .Append(ControlChars.CrLf)
          End If
          .Append("</div>")
          .Append(ControlChars.CrLf)

          .Append("</div>")
          .Append(ControlChars.CrLf)
        End If

        If TableRec.FormOptions And Types.enuFormOptions.FieldSet Then
          .Append(ControlChars.CrLf)
          .Append("</fieldset>")
        End If
      End With

      Return sbType.ToString

    End Function


    Private Function Create_RW_Form(ByVal TableRec As Types.TableFmt) As String
      Dim sbType As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim iPntr As Int32
      Dim sFieldName As String

      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      With sbType

        .Append("<h1>Page Description</h1>")
        .Append(ControlChars.CrLf)

        If TableRec.FormOptions And Types.enuFormOptions.FieldSet Then
          .Append("<fieldset>")
          .Append(ControlChars.CrLf)
          .Append("<legend>")
          .Append(TableRec.sTable)
          .Append("</legend>")
          .Append(ControlChars.CrLf)
        End If


        If TableRec.FormOptions And Types.enuFormOptions.ValidationSummary Then
          .Append(CreateValidationSummary())
        End If

        If TableRec.FormOptions And Types.enuFormOptions.YesNo Then
          .Append(CreateYesNoPanel)
        End If

        For iPntr = 0 To ColumnRec.GetUpperBound(0)

          Select Case ColumnRec(iPntr).sColumnType
            Case "bit"
              sFieldName = String.Format("ddl{0}", ColumnRec(iPntr).sColumnName)
            Case Else
              sFieldName = String.Format("txt{0}", ColumnRec(iPntr).sColumnName)
          End Select

          .Append("<div class=""control-group"">")
          .Append(ControlChars.CrLf)

          'Create Label
          .Append(ControlChars.Tab)
          .Append("<label class=""control-label"" for=""cphBody_")
          .Append(sFieldName)
          .Append(""">")
          .Append(sFieldName)
          .Append("</label>")
          .Append(ControlChars.CrLf)


          'Create Input Box
          .Append(ControlChars.Tab)
          Select Case ColumnRec(iPntr).sColumnType
            Case "bit"
              .Append("<div class=""radio"">")
              .Append(ControlChars.CrLf)
              .Append("<asp:RadioButtonList runat=""server"" RepeatColumns=""2"" cssClass=""checkboxWidth"" ID=""")
            Case Else
              .Append("<div class=""controls"">")
              .Append(ControlChars.CrLf)
              .Append("<asp:TextBox runat=""server"" ID=""")
          End Select
          .Append(sFieldName)
          Select Case ColumnRec(iPntr).sColumnType
            Case "bit"
              .Append(""">")
              .Append(ControlChars.CrLf)
              .Append("<asp:ListItem Text=""Yes"" Value=""1""></asp:ListItem>")
              .Append(ControlChars.CrLf)
              .Append("<asp:ListItem Text=""No"" Value=""0""></asp:ListItem>")
              .Append("</asp:RadioButtonList>")
              .Append(ControlChars.CrLf)
            Case Else
              .Append("""></asp:TextBox>")
          End Select
          .Append(ControlChars.CrLf)

          'Required Field Validator
          Select Case ColumnRec(iPntr).sColumnType
            Case "bit"
              'Don't do Required Field
            Case Else
              .Append(ControlChars.Tab)
              .Append("<asp:RequiredFieldValidator ID=""req")
              .Append(ColumnRec(iPntr).sColumnName)
              .Append(""" runat=""server"" Text=""*"" ErrorMessage=""")
              .Append(ColumnRec(iPntr).sColumnName)
              .Append(" is Required"" ControlToValidate=""")
              .Append(sFieldName)
              .Append("""></asp:RequiredFieldValidator>")
              .Append(ControlChars.CrLf)
          End Select

          Select Case ColumnRec(iPntr).sColumnType
            Case "decimal", "numeric", "real", "money", "float"
              .Append(ControlChars.Tab)
              .Append("<asp:RegularExpressionValidator ID=""reg")
              .Append(ColumnRec(iPntr).sColumnName)
              .Append(""" runat=""server"" Text=""*"" ErrorMessage=""")
              .Append(ColumnRec(iPntr).sColumnName)
              .Append(" is not formatted correctly"" ControlToValidate=""")
              .Append(sFieldName)
              .Append("""  ValidationExpression=""^-?((\d{1,8}(\.\d{1,2})?)|(\.\d{1,2}))$")
              .Append("""></asp:RegularExpressionValidator>")
              .Append(ControlChars.CrLf)
            Case "int", "smallint", "tinyint"
              .Append(ControlChars.Tab)
              .Append("<asp:RegularExpressionValidator ID=""reg")
              .Append(ColumnRec(iPntr).sColumnName)
              .Append(""" runat=""server"" Text=""*"" ErrorMessage=""")
              .Append(ColumnRec(iPntr).sColumnName)
              .Append(" is not formatted correctly"" ControlToValidate=""")
              .Append(sFieldName)
              .Append("""  ValidationExpression=""^-?\d{1,8}$")
              .Append("""></asp:RegularExpressionValidator>")
              .Append(ControlChars.CrLf)
            Case "char", "varchar", "nchar", "nvarchar", "text", "time"
              .Append(ControlChars.Tab)
              .Append("<asp:RegularExpressionValidator ID=""reg")
              .Append(ColumnRec(iPntr).sColumnName)
              .Append(""" runat=""server"" Text=""*"" ErrorMessage=""")
              .Append(ColumnRec(iPntr).sColumnName)
              .Append(" is not formatted correctly"" ControlToValidate=""")
              .Append(sFieldName)
              .Append("""  ValidationExpression=""^.{1,")
              .Append(ColumnRec(iPntr).iColumnLength.ToString)
              .Append("}$""></asp:RegularExpressionValidator>")
              .Append(ControlChars.CrLf)
            Case "datetime", "smalldatetime", "date", "datetime2", "datetimeoffset"
              .Append(ControlChars.Tab)
              .Append("<asp:CompareValidator ID=""cmp")
              .Append(ColumnRec(iPntr).sColumnName)
              .Append(""" runat=""server"" Text=""*"" ErrorMessage=""")
              .Append(ColumnRec(iPntr).sColumnName)
              .Append(" is not formatted correctly"" ControlToValidate=""")
              .Append(sFieldName)
              .Append("""  Operator=""DataTypeCheck"" Type=""Date""></asp:CompareValidator>")
              .Append(ControlChars.CrLf)
            Case "bit"
              'Do nothing for DLL's
          End Select
          If TableRec.FormOptions And Types.enuFormOptions.Tips Then
            .Append(ControlChars.Tab)
            .Append("<p>Information about above box</p>")
            .Append(ControlChars.CrLf)
          End If
          .Append("</div>")
          .Append(ControlChars.CrLf)
          .Append("</div>")
          .Append(ControlChars.CrLf)
        Next

        If (TableRec.FormOptions And Types.enuFormOptions.Submit) Or
            (TableRec.FormOptions And Types.enuFormOptions.Edit) Or
            (TableRec.FormOptions And Types.enuFormOptions.Cancel) Or
            (TableRec.FormOptions And Types.enuFormOptions.Delete) Then
          .Append("<div class=""control-button"">")
          .Append(ControlChars.CrLf)
          .Append("<div class=""controls"">")
          .Append(ControlChars.CrLf)
          If TableRec.FormOptions And Types.enuFormOptions.Cancel Then
            .Append("<asp:HyperLink ID=""hlnkCancel"" runat=""server"" CssClass=""btn btn-cancel"">Cancel</asp:HyperLink>")
            .Append(ControlChars.CrLf)
          End If
          If TableRec.FormOptions And Types.enuFormOptions.Edit Then
            .Append("<asp:HyperLink ID=""hlnkEdit"" runat=""server"" CssClass=""btn btn-main"">Edit</asp:HyperLink>")
            .Append(ControlChars.CrLf)
          End If
          If TableRec.FormOptions And Types.enuFormOptions.Delete Then
            .Append("<asp:LinkButton ID=""btnDelete"" runat=""server"" CssClass=""btn btn-danger"">Delete</asp:LinkButton>")
            .Append(ControlChars.CrLf)
          End If
          If TableRec.FormOptions And Types.enuFormOptions.Submit Then
            .Append("<asp:LinkButton ID=""btnSubmit"" runat=""server"" CssClass=""btn btn-main"">Submit</asp:LinkButton>")
            .Append(ControlChars.CrLf)
          End If
          .Append("</div>")
          .Append(ControlChars.CrLf)
          .Append("</div>")
          .Append(ControlChars.CrLf)
        End If

        If TableRec.FormOptions And Types.enuFormOptions.FieldSet Then
          .Append(ControlChars.CrLf)
          .Append("</fieldset>")
        End If
      End With

      Return sbType.ToString

    End Function

    Private Function CreateValidationSummary() As String
      Dim sbHTML As New StringBuilder

      With sbHTML
        .Append("<div class=""ErrorList"">")
        .Append(ControlChars.CrLf)
        .Append("<asp:ValidationSummary ID=""ValidationSummary1"" runat=""server"" />")
        .Append(ControlChars.CrLf)
        .Append("</div>")
        .Append(ControlChars.CrLf)
      End With

      Return sbHTML.ToString

    End Function

    Private Function CreateYesNoPanel() As String
      Dim sbHTML As New StringBuilder

      With sbHTML
        .Append("<asp:Panel runat=""server"" ID=""pnlYeNo"" Visible=""false"">")
        .Append(ControlChars.CrLf)
        .Append("<div class=""controls"">")
        .Append(ControlChars.CrLf)
        .Append("<div class=""center"">Are you sure you want to delete this record?</div>")
        .Append(ControlChars.CrLf)
        .Append("<div class=""buttons"">")
        .Append(ControlChars.CrLf)
        .Append("<asp:LinkButton ID=""btnNo"" runat=""server"" CssClass=""btn btn-primary"">No, Don't Delete</asp:LinkButton>")
        .Append(ControlChars.CrLf)
        .Append("<asp:LinkButton ID=""btnYes"" runat=""server"" CssClass=""btn btn-danger"">Yes, Do Delete</asp:LinkButton>")
        .Append(ControlChars.CrLf)
        .Append("</div>")
        .Append(ControlChars.CrLf)
        .Append("</div>")
        .Append(ControlChars.CrLf)
        .Append("</asp:Panel>")
        .Append(ControlChars.CrLf)
      End With

      Return sbHTML.ToString

    End Function

    Public Sub New(ByVal strServer As String, ByVal strDatabase As String, ByVal sConnectionString As String)
      _ConnectionString = String.Format(sConnectionString, strServer, strDatabase)
    End Sub

    Public Sub New(ByVal strDatabase As String, ByVal sConnectionString As String)
      _ConnectionString = String.Format(sConnectionString, strDatabase)
    End Sub


    Public Sub New(ByVal sConnectionString As String)
      _ConnectionString = sConnectionString
    End Sub

  End Class

End Namespace