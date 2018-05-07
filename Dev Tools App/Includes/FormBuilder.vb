Imports System
Imports System.Data
Imports System.Data.OleDb

Namespace Includes

  Public Class BuildForm
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
        Case "TOTYP", "TOTXT", "TOLBL"
          Select Case TableRec.Language
            Case Types.enLanguage.VB
              TableRec.sForm = Create_Load_Form_vb(TableRec)
            Case Types.enLanguage.CS
              TableRec.sForm = Create_Load_Form_CS(TableRec)
          End Select
      End Select


    End Sub


    Private Function Create_RO_Form(ByVal TableRec As Types.TableFmt) As String
      Dim sbType As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim iPntr As Int32
      Dim sFieldName As String

      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      With sbType

        If TableRec.FormOptions And Types.enuFormOptions.FieldSet Then
          .Append("<fieldset class=""main"">")
          .Append(ControlChars.CrLf)
          .Append("<legend class=""main"">")
          .Append(TableRec.sTable)
          .Append("</legend>")
          .Append(ControlChars.CrLf)
        End If

        If TableRec.FormOptions And Types.enuFormOptions.ValidationSummary Then
          .Append("<div class=""errorlist"">")
          .Append(ControlChars.CrLf)
          .Append("<asp:ValidationSummary ID=""ValidationSummary1"" runat=""server"" />")
          .Append(ControlChars.CrLf)
          .Append("</div>")
          .Append(ControlChars.CrLf)
        End If

        If TableRec.FormOptions And Types.enuFormOptions.YesNo Then
          .Append("<asp:Panel runat=""server"" ID=""pnlYeNo"" Visible=""false"">")
          .Append(ControlChars.CrLf)
          .Append("<div class=""center"">Are you sure you want to delete this record?</div>")
          .Append(ControlChars.CrLf)
          .Append("<div class=""buttons"">")
          .Append(ControlChars.CrLf)
          .Append("<asp:LinkButton ID=""btnNo"" runat=""server"" CssClass=""aspbutton"">No, Don't Delete</asp:LinkButton>")
          .Append(ControlChars.CrLf)
          .Append("<asp:LinkButton ID=""btnYes"" runat=""server"" CssClass=""aspbutton"">Yes, Do Delete</asp:LinkButton>")
          .Append(ControlChars.CrLf)
          .Append("</div>")
          .Append(ControlChars.CrLf)
          .Append("</asp:Panel>")
          .Append(ControlChars.CrLf)
        End If

        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          sFieldName = String.Format("lbl{0}", ColumnRec(iPntr).sColumnName)

          .Append("<div class=""layout"">")
          .Append(ControlChars.CrLf)

          'Create Label
          .Append(ControlChars.Tab)
          .Append("<label class=""default"" for=""")
          .Append(sFieldName)
          .Append(""">")
          .Append(sFieldName)
          .Append("</label>")
          .Append(ControlChars.CrLf)

          'Create Label
          .Append(ControlChars.Tab)
          .Append("<asp:Label ID=""")
          .Append(sFieldName)
          .Append(""" runat=""server"" CssClass=""wrap""></asp:Label>")
          If TableRec.FormOptions And Types.enuFormOptions.Tips Then
            .Append(ControlChars.CrLf)
            .Append(ControlChars.Tab)
            .Append("<span class=""info"">Information about above box</span>")
          End If
          .Append(ControlChars.CrLf)

          .Append("</div>")
          .Append(ControlChars.CrLf)
        Next

        If (TableRec.FormOptions And Types.enuFormOptions.Submit) Or
    TableRec.FormOptions And Types.enuFormOptions.Edit Or
    TableRec.FormOptions And Types.enuFormOptions.Cancel Or
    TableRec.FormOptions And Types.enuFormOptions.Delete Then
          .Append("<div class=""buttons"">")
          .Append(ControlChars.CrLf)

          If TableRec.FormOptions And Types.enuFormOptions.Submit Then
            .Append("<asp:HyperLink ID=""hlnkCancel"" runat=""server"" CssClass=""aspbutton"">Cancel</asp:HyperLink>")
            .Append(ControlChars.CrLf)
          End If
          If TableRec.FormOptions And Types.enuFormOptions.Edit Then
            .Append("<asp:HyperLink ID=""hlnkEdit"" runat=""server"" CssClass=""aspbutton"">Edit</asp:HyperLink>")
            .Append(ControlChars.CrLf)
          End If
          If TableRec.FormOptions And Types.enuFormOptions.Delete Then
            .Append("<asp:LinkButton ID=""btnDelete"" runat=""server"" CssClass=""aspbutton"">Delete</asp:LinkButton>")
            .Append(ControlChars.CrLf)
          End If
          If TableRec.FormOptions And Types.enuFormOptions.Submit Then
            .Append("<asp:LinkButton ID=""btnSubmit"" runat=""server"" CssClass=""aspbutton"">Submit</asp:LinkButton>")
            .Append(ControlChars.CrLf)
          End If
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
        If TableRec.FormOptions And Types.enuFormOptions.FieldSet Then
          .Append("<fieldset class=""main"">")
          .Append(ControlChars.CrLf)
          .Append("<legend class=""main"">")
          .Append(TableRec.sTable)
          .Append("</legend>")
          .Append(ControlChars.CrLf)
        End If

        If TableRec.FormOptions And Types.enuFormOptions.ValidationSummary Then
          .Append("<div class=""errorlist"">")
          .Append(ControlChars.CrLf)
          .Append("<asp:ValidationSummary ID=""ValidationSummary1"" runat=""server"" />")
          .Append(ControlChars.CrLf)
          .Append("</div>")
          .Append(ControlChars.CrLf)
        End If

        If TableRec.FormOptions And Types.enuFormOptions.YesNo Then
          .Append("<asp:Panel runat=""server"" ID=""pnlYeNo"" Visible=""false"">")
          .Append(ControlChars.CrLf)
          .Append("<div class=""center"">Are you sure you want to delete this record?</div>")
          .Append(ControlChars.CrLf)
          .Append("<div class=""buttons"">")
          .Append(ControlChars.CrLf)
          .Append("<asp:LinkButton ID=""btnNo"" runat=""server"" CssClass=""aspbutton"">No, Don't Delete</asp:LinkButton>")
          .Append(ControlChars.CrLf)
          .Append("<asp:LinkButton ID=""btnYes"" runat=""server"" CssClass=""aspbutton"">Yes, Do Delete</asp:LinkButton>")
          .Append(ControlChars.CrLf)
          .Append("</div>")
          .Append(ControlChars.CrLf)
          .Append("</asp:Panel>")
          .Append(ControlChars.CrLf)
        End If

        For iPntr = 0 To ColumnRec.GetUpperBound(0)

          Select Case ColumnRec(iPntr).sColumnType
            Case "bit"
              sFieldName = String.Format("ddl{0}", ColumnRec(iPntr).sColumnName)
            Case Else
              sFieldName = String.Format("txt{0}", ColumnRec(iPntr).sColumnName)
          End Select

          .Append("<div class=""layout"">")
          .Append(ControlChars.CrLf)

          'Create Label
          .Append(ControlChars.Tab)
          .Append("<label class=""default"" for=""")
          .Append(sFieldName)
          .Append(""">")
          .Append(sFieldName)
          .Append("</label>")
          .Append(ControlChars.CrLf)

          'Create Input Box
          .Append(ControlChars.Tab)
          Select Case ColumnRec(iPntr).sColumnType
            Case "bit"
              .Append("<asp:DropDownList runat=""server"" ID=""")
            Case Else
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
              .Append("</asp:DropDownList>")
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
            .Append("<span class=""info"">Information about above box</span>")
            .Append(ControlChars.CrLf)
          End If
          .Append("</div>")
          .Append(ControlChars.CrLf)
        Next

        If (TableRec.FormOptions And Types.enuFormOptions.Submit) Or
            (TableRec.FormOptions And Types.enuFormOptions.Edit) Or
            (TableRec.FormOptions And Types.enuFormOptions.Cancel) Or
            (TableRec.FormOptions And Types.enuFormOptions.Delete) Then
          .Append("<div class=""buttons"">")
          .Append(ControlChars.CrLf)

          If TableRec.FormOptions And Types.enuFormOptions.Cancel Then
            .Append("<asp:HyperLink ID=""hlnkCancel"" runat=""server"" CssClass=""aspbutton"">Cancel</asp:HyperLink>")
            .Append(ControlChars.CrLf)
          End If
          If TableRec.FormOptions And Types.enuFormOptions.Edit Then
            .Append("<asp:HyperLink ID=""hlnkEdit"" runat=""server"" CssClass=""aspbutton"">Edit</asp:HyperLink>")
            .Append(ControlChars.CrLf)
          End If
          If TableRec.FormOptions And Types.enuFormOptions.Delete Then
            .Append("<asp:LinkButton ID=""btnDelete"" runat=""server"" CssClass=""aspbutton"">Delete</asp:LinkButton>")
            .Append(ControlChars.CrLf)
          End If
          If TableRec.FormOptions And Types.enuFormOptions.Submit Then
            .Append("<asp:LinkButton ID=""btnSubmit"" runat=""server"" CssClass=""aspbutton"">Submit</asp:LinkButton>")
            .Append(ControlChars.CrLf)
          End If
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

    Private Function Create_Load_Form_vb(ByVal TableRec As Types.TableFmt) As String
      Dim sbType As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim iPntr As Int32

      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      With sbType
        .Append("With [TypeClass]")
        .Append(ControlChars.CrLf)
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          .Append(ControlChars.Tab)


          Select Case TableRec.sFormType
            Case "TOTYP"
              Select Case ColumnRec(iPntr).sColumnType
                Case "decimal", "numeric", "money", "smallmoney"
                  .Append(String.Format(".d{0} = cdec(txt{0}.text)", ColumnRec(iPntr).sColumnName))
                Case "int"
                  .Append(String.Format(".i{0} = cint(txt{0}.text)", ColumnRec(iPntr).sColumnName))
                Case "smallint", "tinyint"
                  .Append(String.Format(".i{0} = cint(txt{0}.text)", ColumnRec(iPntr).sColumnName))
                Case "bigint"
                  .Append(String.Format(".i{0} = cint(txt{0}.text)", ColumnRec(iPntr).sColumnName))
                Case "char", "varchar", "nchar", "nvarchar", "text"
                  .Append(String.Format(".s{0} = txt{0}.text", ColumnRec(iPntr).sColumnName))
                Case "float", "real"
                  .Append(String.Format(".f{0} = convert.todouble(txt{0}.text) 'You really shouldn't be using a float", ColumnRec(iPntr).sColumnName))
                Case "datetime", "smalldatetime", "date", "datetime2"
                  .Append(String.Format(".dt{0} = convert.todatetime(txt{0}.text)", ColumnRec(iPntr).sColumnName))
                Case "datetimeoffset"
                  .Append(String.Format(".dto{0} = DateTimeOffset.Parse(txt{0}.text)", ColumnRec(iPntr).sColumnName))
                Case "time"
                  .Append(String.Format(".ts{0} = TimeSpan.Parse(txt{0}.text)", ColumnRec(iPntr).sColumnName))
                Case "binary", "varbinary"
                  .Append("'Binary is not supported on forms")
                Case "geography"
                  .Append("'Geography DataTypes are not supported on forms")
                Case "bit"
                  .Append(String.Format(".b{0} = ddl{0}.SelectedValue.Equals(""1"")", ColumnRec(iPntr).sColumnName))
              End Select
            Case "TOTXT"
              Select Case ColumnRec(iPntr).sColumnType
                Case "decimal", "numeric", "money", "smallmoney"
                  .Append(String.Format("txt{0}.text = .d{0}.tostring()", ColumnRec(iPntr).sColumnName))
                Case "smallint", "tinyint"
                  .Append(String.Format("txt{0}.text = .i{0}.tostring()", ColumnRec(iPntr).sColumnName))
                Case "int"
                  .Append(String.Format("txt{0}.text = .i{0}.tostring()", ColumnRec(iPntr).sColumnName))
                Case "bigint"
                  .Append(String.Format("txt{0}.text = .i{0}.tostring()", ColumnRec(iPntr).sColumnName))
                Case "char", "varchar", "nchar", "nvarchar", "text"
                  .Append(String.Format("txt{0}.text = .s{0}", ColumnRec(iPntr).sColumnName))
                Case "float", "real"
                  .Append(String.Format("txt{0}.text = .f{0}.tostring() 'You really shouldn't be using a float", ColumnRec(iPntr).sColumnName))
                Case "datetime", "smalldatetime", "date", "datetime2"
                  .Append(String.Format("txt{0}.text = .dt{0}.tostring(""MM/dd/yyyy"")", ColumnRec(iPntr).sColumnName))
                Case "datetimeoffset"
                  .Append(String.Format("txt{0}.text = .dto{0}.tostring(""zzz"")", ColumnRec(iPntr).sColumnName))
                Case "time"
                  .Append(String.Format("txt{0}.text = .ts{0}.tostring(""c"")", ColumnRec(iPntr).sColumnName))
                Case "binary", "varbinary"
                  .Append("'Binary is not supported on forms")
                Case "geography"
                  .Append("'Geography DataTypes are not supported on forms")
                Case "bit"
                  .Append(String.Format("ddl{0}.Items.FindByValue(IIf(.b{0},""1"",""0""))", ColumnRec(iPntr).sColumnName))
              End Select
            Case "TOLBL"
              Select Case ColumnRec(iPntr).sColumnType
                Case "decimal", "numeric", "money", "smallmoney"
                  .Append(String.Format("lbl{0}.text = .d{0}.tostring(""c"")", ColumnRec(iPntr).sColumnName))
                Case "smallint", "tinyint"
                  .Append(String.Format("lbl{0}.text = .i{0}.tostring(""n"")", ColumnRec(iPntr).sColumnName))
                Case "int"
                  .Append(String.Format("lbl{0}.text = .i{0}.tostring(""n"")", ColumnRec(iPntr).sColumnName))
                Case "bigint"
                  .Append(String.Format("lbl{0}.text = .i{0}.tostring(""n"")", ColumnRec(iPntr).sColumnName))
                Case "char", "varchar", "nchar", "nvarchar", "text"
                  .Append(String.Format("lbl{0}.text = .s{0}", ColumnRec(iPntr).sColumnName))
                Case "float", "real"
                  .Append(String.Format("lbl{0}.text = .f{0}.tostring(""g"") 'You really shouldn't be using a float", ColumnRec(iPntr).sColumnName))
                Case "datetime", "smalldatetime", "date", "datetime2"
                  .Append(String.Format("lbl{0}.text = .dt{0}.tostring(""MM/dd/yyyy"")", ColumnRec(iPntr).sColumnName))
                Case "datetimeoffset"
                  .Append(String.Format("lbl{0}.text = .dto{0}.tostring(""zzz"")", ColumnRec(iPntr).sColumnName))
                Case "time"
                  .Append(String.Format("lbl{0}.text = .ts{0}.tostring(""c"")", ColumnRec(iPntr).sColumnName))
                Case "binary", "varbinary"
                  .Append("'Binary is not supported on forms")
                Case "geography"
                  .Append("'Geography DataTypes are not supported on forms")
                Case "bit"
                  .Append(String.Format("lbl{0}.text = .b{0}.tostring()", ColumnRec(iPntr).sColumnName))
              End Select
          End Select
          .Append(ControlChars.CrLf)

        Next
        .Append("End With")
        .Append(ControlChars.CrLf)

      End With

      Return sbType.ToString

    End Function

    Private Function Create_Load_Form_CS(ByVal TableRec As Types.TableFmt) As String
      Dim sbType As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim iPntr As Int32

      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      With sbType
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          .Append(ControlChars.Tab)


          Select Case TableRec.sFormType
            Case "TOTYP"
              Select Case ColumnRec(iPntr).sColumnType
                Case "decimal", "numeric", "money", "smallmoney"
                  .Append(String.Format("{0}.d{1} = Convert.ToDecimal(txt{1}.Text);", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "int"
                  .Append(String.Format("{0}.i{1} = Convert.ToInt32(txt{1}.Text);", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "smallint", "tinyint"
                  .Append(String.Format("{0}.i{1} = Convert.ToInt16(txt{1}.Text);", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "bigint"
                  .Append(String.Format("{0}.i{1} = Convert.ToInt64(txt{1}.Text);", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "char", "varchar", "nchar", "nvarchar", "text"
                  .Append(String.Format("{0}.s{1} = txt{1}.Text;", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "float", "real"
                  .Append(String.Format("{0}.f{1} = Convert.ToDouble(txt{1}.Text); //You really shouldn't be using a float", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "datetime", "smalldatetime", "date", "datetime2"
                  .Append(String.Format("{0}.dt{1} = Convert.ToDateTime(txt{1}.Text);", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "time"
                  .Append(String.Format("{0}.ts{1} = TimeSpan.Parse(txt{1}.Text);", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "datetimeoffset"
                  .Append(String.Format("{0}.dto{1} = DateTimeOffset.Parse(txt{1}.Text);", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "binary", "varbinary"
                  .Append("//Binary is not supported on forms")
                Case "geography"
                  .Append("//Geography datatypes are not supported on forms")
                Case "bit"
                  .Append(String.Format("{0}.b{1} = ddl{1}.SelectedValue.Equals(""1"");", TableRec.sTable, ColumnRec(iPntr).sColumnName))
              End Select
            Case "TOTXT"
              Select Case ColumnRec(iPntr).sColumnType
                Case "decimal", "numeric", "money", "smallmoney"
                  .Append(String.Format("txt{1}.Text = {0}.d{1}.ToString();", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "int", "smallint", "tinyint", "bigint"
                  .Append(String.Format("txt{1}.Text = {0}.i{1}.ToString();", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "char", "varchar", "nchar", "nvarchar", "text"
                  .Append(String.Format("txt{1}.Text = {0}.s{1};", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "float", "real"
                  .Append(String.Format("txt{1}.Text = {0}.f{1}.ToString(); //You really shouldn't be using a float", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "datetime", "smalldatetime", "date", "datetime2"
                  .Append(String.Format("txt{1}.Text = {0}.dt{1}.ToString(""MM/dd/yyyy"");", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "datetimeoffset"
                  .Append(String.Format("txt{1}.Text = {0}.dto{1}.ToString(""zzz"");", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "time"
                  .Append(String.Format("txt{1}.Text = {0}.ts{1}.ToString(""c"");", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "bit"
                  .Append(String.Format("ddl{1}.Items.FindByValue( {0}.b{1} == true ? ""1"":""0"").Selected = true;", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "binary", "varbinary"
                  .Append("//Binary is not supported on forms")
                Case "geography"
                  .Append("//Geography datatypes are not supported on forms")
              End Select
            Case "TOLBL"
              Select Case ColumnRec(iPntr).sColumnType
                Case "decimal", "numeric", "money", "smallmoney"
                  .Append(String.Format("lbl{1}.Text = {0}.d{1}.ToString(""c"");", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "int", "smallint", "tinyint", "bigint"
                  .Append(String.Format("lbl{1}.Text = {0}.i{1}.ToString(""n"");", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "char", "varchar", "nchar", "nvarchar", "text"
                  .Append(String.Format("lbl{1}.Text = {0}.s{1};", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "float", "real"
                  .Append(String.Format("lbl{1}.Text = {0}.f{1}.ToString(""g""); //You really shouldn't be using a float", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "datetime", "smalldatetime", "date", "datetime2"
                  .Append(String.Format("lbl{1}.Text = {0}.dt{1}.ToString(""MM/dd/yyyy"");", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "datetimeoffset"
                  .Append(String.Format("lbl{1}.Text = {0}.dto{1}.ToString(""zzz"");", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "time"
                  .Append(String.Format("lbl{1}.Text = {0}.ts{1}.ToString(""c"");", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "bit"
                  .Append(String.Format("lbl{1}.Text = {0}.b{1}.ToString();", TableRec.sTable, ColumnRec(iPntr).sColumnName))
                Case "binary", "varbinary"
                  .Append("//Binary is not supported on forms")
                Case "geography"
                  .Append("//Geography datatypes are not supported on forms")
              End Select
          End Select
          .Append(ControlChars.CrLf)

        Next


      End With

      Return sbType.ToString

    End Function

    Public Sub New(ByVal sConnectionString As String)
      _ConnectionString = sConnectionString
    End Sub

  End Class

End Namespace