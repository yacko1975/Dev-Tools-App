Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Dev_Tools_App.Includes
Imports Dev_Tools_App.Includes.Types

Namespace Includes

  Public Class DBBuilder
    Private _ConnectionString As String

    Public Function Build_SP_Debug_Script(ByRef TableRec As Types.TableFmt) As String
      Dim DBConn As New SqlConnection(_ConnectionString)
      Dim tb As DataTable
      Dim sSP As New System.Text.StringBuilder
      Dim bComma As Boolean
      Dim dvTbl As DataView


      DBConn.Open()

      tb = DBConn.GetSchema("ProcedureParameters", New String() {Nothing, TableRec.Schema, TableRec.SPName, Nothing})
      'Build our DataRow and StringBuilder objects
      dvTbl = New DataView(tb)
      dvTbl.Sort = "Ordinal_Position asc"
      DBConn.Close()
      'For intPntr = 0 To tb.Columns.Count - 1
      '  System.Diagnostics.Trace.WriteLine(tb.Columns(intPntr).ColumnName & " " & intPntr)
      'Next
      'Create our stored procedure heading information

      sSP.AppendLine("DECLARE @ReturnCode int;")

      For Each dvRow As DataRowView In dvTbl

        If dvRow("ORDINAL_POSITION") <> 0 Then
          sSP.Append("Declare ")
          sSP.Append(dvRow("PARAMETER_NAME").ToString)
          sSP.Append(Space(1))
          sSP.Append(dvRow("DATA_TYPE"))

          If IsDBNull(dvRow("CHARACTER_MAXIMUM_LENGTH")) Then

          Else
            'Special Cases
            If dvRow("CHARACTER_MAXIMUM_LENGTH") = 2147483647 Then

            Else
              sSP.Append("(")
              sSP.Append(dvRow("CHARACTER_MAXIMUM_LENGTH"))
              sSP.Append("")
              sSP.Append(")")
            End If



          End If

          sSP.AppendLine(";")
        End If
      Next

      sSP.AppendLine()
      sSP.AppendLine()

      sSP.AppendLine("Select ")
      bComma = False
      For Each dvRow As DataRowView In dvTbl
        If dvRow("PARAMETER_MODE").ToString.Contains("IN") Then
          If bComma Then
            sSP.Append(",")
          Else
            bComma = True
          End If

          sSP.Append(dvRow("PARAMETER_NAME").ToString)
          sSP.AppendLine(" = <value>")
        End If
      Next
      sSP.Remove(sSP.Length - 2, 2)
      sSP.Append(";")
      sSP.AppendLine()
      sSP.AppendLine()

      sSP.Append("EXECUTE @ReturnCode = ")
      sSP.Append(TableRec.FullSPName)
      sSP.AppendLine(" ")

      bComma = False
      For Each dvRow As DataRowView In dvTbl
        If dvRow("ORDINAL_POSITION") <> 0 Then
          If bComma Then
            sSP.Append(", ")
          Else
            bComma = True
          End If

          sSP.Append(dvRow("PARAMETER_NAME").ToString)

          If dvRow("PARAMETER_MODE") = "OUT" Then
            sSP.AppendLine(" OUTPUT")
          Else
            sSP.AppendLine()
          End If
        End If
      Next

      sSP.Remove(sSP.Length - 2, 2)
      sSP.Append(";")

      sSP.AppendLine()
      sSP.AppendLine()


      sSP.AppendLine("Select ")
      sSP.AppendLine("  'ReturnCode'=@ReturnCode")

      For Each dvRow As DataRowView In dvTbl
        If dvRow("ORDINAL_POSITION") <> 0 Then
          sSP.Append(" ,")
          sSP.Append(dvRow("PARAMETER_NAME").ToString.Substring(1))
          sSP.Append(" = ")
          sSP.AppendLine(dvRow("PARAMETER_NAME").ToString)
        End If
      Next
      sSP.Remove(sSP.Length - 2, 2)
      sSP.Append(";")

      Return sSP.ToString

    End Function

    Public Function Build_SP_Code_VB(ByRef TableRec As Types.TableFmt) As String
      Dim DBConn As New SqlConnection(_ConnectionString)
      Dim tb As DataTable
      Dim sSP As New System.Text.StringBuilder
      Dim bTemp As Boolean
      Dim dvTbl As DataView



      DBConn.Open()

      tb = DBConn.GetSchema("ProcedureParameters", New String() {Nothing, TableRec.Schema, TableRec.SPName, Nothing})
      dvTbl = New DataView(tb)
      dvTbl.Sort = "Ordinal_Position asc"
      'Build our DataRow and StringBuilder objects
      DBConn.Close()
      'For intPntr = 0 To tb.Columns.Count - 1
      '  System.Diagnostics.Trace.WriteLine(tb.Columns(intPntr).ColumnName & " " & intPntr)
      'Next
      'Create our stored procedure heading information
      If TableRec.isAnyOptionSet(CallBuilder.CreateNewClass) Then
        sSP.AppendLine("Public Class cls[Class Name]")
        sSP.AppendLine()
        sSP.Append(clsCommon.CreatePrivateVariables_VB(TableRec))
        If TableRec.isAnyOptionSet(Types.CallBuilder.UseTransaction, Types.CallBuilder.UseGlobalConnection) Then
          sSP.AppendLine(clsCommon.CreateDBOpenClose_VB(TableRec))
        End If
      End If
      sSP.Append("Public Function ")
      sSP.Append(TableRec.SPName.Substring(0, 1).ToUpper)
      sSP.Append(TableRec.SPName.Substring(1))
      Select Case True
        Case TableRec.isAnyOptionSet(CallBuilder.CreateOptionalArgument)
          bTemp = False
          sSP.Append("(")
          For Each dvRow As DataRowView In dvTbl
            If dvRow("PARAMETER_MODE").ToString.Contains("IN") Then
              If bTemp Then
                sSP.Append(",")
              Else

              End If
              sSP.Append("Optional Byval ")
              sSP.Append(dvRow("PARAMETER_NAME").ToString.Substring(1))
              sSP.Append(" as ")
              sSP.Append(clsCommon.GetType_VB(dvRow("DATA_TYPE")))
              sSP.AppendFormat(" = {0}", clsCommon.GetDefaultForType_VB(dvRow("DATA_TYPE")))
              bTemp = True
            End If
          Next
          sSP.Append(")")
        Case Else
          sSP.Append("() ")
      End Select
      If TableRec.isAnyOptionSet(CallBuilder.DataReader) Then
        sSP.Append("as SqlDataReader")
      Else
        sSP.Append("as Boolean")
      End If
      sSP.Append(ControlChars.CrLf)
      Select Case True
        Case TableRec.isAnyOptionSet(CallBuilder.UseGlobalConnection)

        Case TableRec.isAnyOptionSet(CallBuilder.PrivateConnectionString)
          sSP.AppendLine("Dim DBConn as new SQLConnection(_ConnectionString)")
        Case Else
          sSP.Append("Dim DBConn as new SQLConnection(configurationmanager.ConnectionStrings(""")
          sSP.Append(TableRec.sDatabase)
          sSP.AppendLine(""").ConnectionString)")
      End Select
      sSP.Append("Dim DBCmd as new SqlClient.SQLCommand(""")
      sSP.Append(TableRec.FullSPName)
      If TableRec.isAnyOptionSet(CallBuilder.UseGlobalConnection) Then
        sSP.AppendLine(""", _DBConn)")
      Else
        sSP.AppendLine(""", DBConn)")
      End If
      sSP.AppendLine()

      If TableRec.isAnyOptionSet(CallBuilder.ExceptionHandling) Then
        sSP.AppendLine("Try")
        sSP.AppendLine()
      End If
      If TableRec.isAnyOptionSet(CallBuilder.CreateOptionalArgument) Then
        For Each dvRow As DataRowView In dvTbl
          If dvRow("PARAMETER_MODE") = "IN" Then
            sSP.Append(clsCommon.CreateOptionalArgCode_VB(dvRow("PARAMETER_NAME").ToString.Substring(1), dvRow("DATA_TYPE")))
          End If
        Next

      End If


      sSP.AppendLine("DBCmd.CommandType = CommandType.StoredProcedure")
      If TableRec.isAnyOptionSet(CallBuilder.UseTransaction) Then
        sSP.AppendLine("DBCmd.Transaction = _DBTrans")
      End If
      sSP.AppendLine()

      If TableRec.isAnyOptionSet(CallBuilder.TableCls) Then
        sSP.AppendLine("With [VALUE]")
      End If

      For Each dvRow As DataRowView In dvTbl
        '        If dvRow("PARAMETER_TYPE") <> 4 Then
        sSP.Append("DBCmd.Parameters.Add(""" & dvRow("PARAMETER_NAME") & """")
        sSP.Append(", SqlDBType." & clsCommon.GetSQLDbType(dvRow("DATA_TYPE")))
        If IsDBNull(dvRow("CHARACTER_MAXIMUM_LENGTH")) Then

        Else
          'Special Cases
          If dvRow("CHARACTER_MAXIMUM_LENGTH") = 2147483647 Then
            sSP.Append(", -1")
          Else
            sSP.Append(", " & dvRow("CHARACTER_MAXIMUM_LENGTH"))
          End If
        End If
        If dvRow("PARAMETER_MODE") = "IN" Then
          sSP.Append(").Value = ")
          If TableRec.isAnyOptionSet(CallBuilder.SendNulls) Then
            sSP.Append("KDOR.dbFunctions.SendNulls(")
          End If
          Select Case True
            Case TableRec.isAnyOptionSet(CallBuilder.CreateOptionalArgument)
              sSP.Append(dvRow("PARAMETER_NAME").ToString.Substring(1))
            Case TableRec.isAnyOptionSet(CallBuilder.TableCls)
              sSP.Append(".")
              sSP.Append(clsCommon.GetPrefix(dvRow("DATA_TYPE")))
              sSP.Append(dvRow("PARAMETER_NAME").ToString.Substring(1))
            Case TableRec.isAnyOptionSet(CallBuilder.UseLocal)
              sSP.Append(clsCommon.GetPrefix(dvRow("DATA_TYPE")))
              sSP.Append(dvRow("PARAMETER_NAME").ToString.Substring(1))
            Case Else
              sSP.Append("[VALUE]")
          End Select

          If TableRec.isAnyOptionSet(CallBuilder.SendNulls) Then
            sSP.Append(", ")
            Select Case dvRow("DATA_TYPE")
              Case "decimal", "numeric", "int", "smallint", "tinyint", "money", "bigint", "smallmoney", "float", "real"
                sSP.Append("KDOR.dbFunctions.ObjectTypes.Numbers, 0)")
              Case "char", "varchar", "nchar", "nvarchar", "binary", "varbinary", "text"
                sSP.Append("KDOR.dbFunctions.ObjectTypes.Strings)")
              Case "datetime", "smalldatetime", "date", "datetime2", "datetimeoffset", "time"
                sSP.Append("KDOR.dbFunctions.ObjectTypes.Dates)")
              Case "bit"
                sSP.Append("KDOR.dbFunctions.ObjectTypes.Booleans, False)")
              Case Else
                'Do Nothing
            End Select
          End If

        Else
          sSP.Append(")")
        End If
        sSP.Append(ControlChars.CrLf)
        If dvRow("DATA_TYPE") = "decimal" Then
          sSP.Append("DBCmd.Parameters(""")
          sSP.Append(dvRow("PARAMETER_NAME"))
          sSP.Append(""").Precision = ")
          sSP.Append(dvRow("NUMERIC_PRECISION"))
          sSP.Append(ControlChars.CrLf)
          sSP.Append("DBCmd.Parameters(""")
          sSP.Append(dvRow("PARAMETER_NAME"))
          sSP.Append(""").Scale = ")
          sSP.Append(dvRow("NUMERIC_SCALE"))
          sSP.Append(ControlChars.CrLf)
        End If

        If dvRow("PARAMETER_MODE") = "IN" Then
          'Skipping Input parameters
        Else
          sSP.Append("DBCmd.Parameters(""")
          sSP.Append(dvRow("PARAMETER_NAME"))
          sSP.Append(""").Direction = ")
          If dvRow("ORDINAL_POSITION") = 0 Then
            sSP.Append(" parameterdirection.ReturnValue")
          Else
            Select Case dvRow("PARAMETER_MODE")
              Case "IN"
                sSP.Append(" ParameterDirection.Input")
              Case Else
                sSP.Append(" ParameterDirection.Output")
            End Select
          End If
          sSP.Append(ControlChars.CrLf)
        End If
      Next


      'We can finish up our string concatenation with our footer information

      sSP.Append(ControlChars.CrLf)
      If TableRec.isAnyOptionSet(CallBuilder.UseTransaction, CallBuilder.UseGlobalConnection) Then
      Else
        sSP.Append("DBConn.Open" & ControlChars.CrLf)
      End If
      If TableRec.isAnyOptionSet(CallBuilder.DataReader) Then

        sSP.Append("Return DBcmd.ExecuteReader(CommandBehavior.CloseConnection)" & ControlChars.CrLf)

      Else
        sSP.Append("DBcmd.ExecuteNonQuery" & ControlChars.CrLf)
        If TableRec.isAnyOptionSet(CallBuilder.UseTransaction, CallBuilder.UseGlobalConnection, CallBuilder.ExceptionHandling) Then

          sSP.Append(ControlChars.CrLf)
        Else
          sSP.Append("DBConn.Close")
          sSP.Append(ControlChars.CrLf)
          sSP.Append(ControlChars.CrLf)
        End If


        For Each dvRow As DataRowView In dvTbl
          If dvRow("PARAMETER_MODE") <> "IN" Then
            If (TableRec.SPOptions And CallBuilder.TableCls) And dvRow("ORDINAL_POSITION") > 0 Then
              sSP.Append(".")
              sSP.Append(clsCommon.GetPrefix(dvRow("DATA_TYPE")))
              sSP.Append(dvRow("PARAMETER_NAME").ToString.Substring(1))
            Else
              If TableRec.SPOptions And CallBuilder.UseLocal And dvRow("ORDINAL_POSITION") > 0 Then
                sSP.Append(clsCommon.GetPrefix(dvRow("DATA_TYPE")))
                sSP.Append(dvRow("PARAMETER_NAME").ToString.Substring(1))
              Else
                sSP.Append("[VALUE]")
              End If
            End If
            sSP.Append(" = ")
            If TableRec.SPOptions And CallBuilder.RemoveNulls Then
              sSP.AppendFormat("KDOR.DBFunctions.RemoveNulls(DBCmd.Parameters(""{0}"").Value,", dvRow("PARAMETER_NAME"))
              Select Case dvRow("DATA_TYPE")
                Case "decimal", "numeric", "int", "smallint", "tinyint", "money", "smallmoney", "bigint", "float", "real"
                  sSP.Append("KDOR.DBFunctions.ObjectTypes.Numbers, 0)")
                Case "char", "varchar", "nchar", "nvarchar", "binary", "varbinary", "text"
                  sSP.Append("KDOR.DBFunctions.ObjectTypes.Strings)")
                Case "datetime", "smalldatetime", "date", "datetime2", "datetimeoffset", "time"
                  sSP.Append("KDOR.DBFunctions.ObjectTypes.Dates, nothing)")
                Case "bit"
                  sSP.Append("KDOR.dbFunctions.ObjectTypes.Booleans, False)")
                Case Else
                  'Do Nothing
              End Select

              sSP.Append(ControlChars.CrLf)

            Else
              sSP.Append(clsCommon.CreateOutputParameter_VB(dvRow("PARAMETER_NAME"), dvRow("DATA_TYPE")))
              sSP.AppendLine()
            End If
          End If
        Next
        If TableRec.SPOptions And CallBuilder.TableCls Then
          sSP.Append("End With")
          sSP.Append(ControlChars.CrLf)
        End If

        sSP.Append(ControlChars.CrLf)
        sSP.Append("Return True")
        sSP.Append(ControlChars.CrLf)
      End If



      'Error Handling

      If TableRec.SPOptions And CallBuilder.ExceptionHandling Then
        sSP.Append(ControlChars.CrLf)
        sSP.Append("Catch ex As Exception" & ControlChars.CrLf)
        sSP.Append("Throw")
        sSP.Append(ControlChars.CrLf)
        sSP.Append(ControlChars.CrLf)
        If TableRec.isAnyOptionSet(CallBuilder.UseTransaction, CallBuilder.UseGlobalConnection, CallBuilder.DataReader) Then
        Else
          sSP.Append("Finally" & ControlChars.CrLf)
          sSP.Append(ControlChars.CrLf)
          sSP.Append("If DBConn.State = ConnectionState.Open Then" & ControlChars.CrLf)
          sSP.Append("DBConn.Close()" & ControlChars.CrLf)
          sSP.Append("End If" & ControlChars.CrLf)
        End If

        sSP.Append("End Try" & ControlChars.CrLf)
      End If

      sSP.Append(ControlChars.CrLf)
      sSP.Append("End Function")

      If TableRec.SPOptions And CallBuilder.CreateNewClass Then
        sSP.AppendLine()
        sSP.AppendLine()
        sSP.Append("Public Sub New(ByVal ConnectionString As String)")
        sSP.AppendLine()
        sSP.Append("_ConnectionString = ConnectionString")
        sSP.AppendLine()
        sSP.Append("End Sub")
        sSP.AppendLine()
        sSP.AppendLine()
        sSP.Append("End Class")
      End If

      Return sSP.ToString

    End Function

    Public Function Build_SP_Code_CS(ByRef TableRec As Types.TableFmt) As String
      Dim DBConn As New SqlConnection(_ConnectionString)
      Dim tb As DataTable

      Dim sSP As New System.Text.StringBuilder

      Dim bTemp As Boolean
      Dim dvTbl As DataView




      DBConn.Open()

      tb = DBConn.GetSchema("ProcedureParameters", New String() {Nothing, TableRec.Schema, TableRec.SPName, Nothing})
      dvTbl = New DataView(tb)
      dvTbl.Sort = "Ordinal_Position asc"
      'Build our DataRow and StringBuilder objects
      DBConn.Close()
      'For intPntr = 0 To tb.Columns.Count - 1
      '  System.Diagnostics.Trace.WriteLine(tb.Columns(intPntr).ColumnName & " " & intPntr)
      'Next
      'Create our stored procedure heading information
      If TableRec.isAnyOptionSet(CallBuilder.CreateNewClass) Then
        sSP.Append("public class cls")
        sSP.AppendLine("[Class Name] {")
        sSP.AppendLine()
        sSP.Append(clsCommon.CreatePrivateVariables_CS(TableRec))
        If TableRec.isAnyOptionSet(Types.CallBuilder.UseTransaction, Types.CallBuilder.UseGlobalConnection) Then
          sSP.AppendLine(clsCommon.CreateDBOpenClose_CS(TableRec))
        End If
      End If
      sSP.Append("public ")
      If TableRec.SPOptions And CallBuilder.DataReader Then
        sSP.Append("SqlDataReader ")
      Else
        sSP.Append("bool ")
      End If
      sSP.Append(TableRec.SPName.Substring(0, 1).ToUpper)
      sSP.Append(TableRec.SPName.Substring(1))
      Select Case True
        Case TableRec.isAnyOptionSet(CallBuilder.CreateOptionalArgument)
          bTemp = False
          sSP.Append("(")
          For Each dvRow As DataRowView In dvTbl
            If dvRow("PARAMETER_MODE").ToString.Contains("IN") Then
              If bTemp Then
                sSP.Append(",")
              Else

              End If
              sSP.Append(clsCommon.GetType_CS(dvRow("DATA_TYPE"), True))
              sSP.Append(dvRow("PARAMETER_NAME").ToString.Substring(1))
              sSP.AppendFormat(" = {0}", clsCommon.GetDefaultForType_CS(dvRow("DATA_TYPE")))
              bTemp = True
            End If
          Next
          sSP.Append(") {")
        Case Else
          sSP.Append("() {")
      End Select
      sSP.AppendLine()
      Select Case True
        Case TableRec.isAnyOptionSet(CallBuilder.UseGlobalConnection)

        Case TableRec.isAllOptionSet(CallBuilder.DataReader, CallBuilder.PrivateConnectionString)
          sSP.AppendLine("var DBConn = new SqlConnection(_ConnectionString);")

        Case TableRec.isAllOptionSet(CallBuilder.DataReader)
          sSP.AppendLine("var DBConn = new SqlConnection(Properties.Settings.Default.")
          sSP.Append(TableRec.sDatabase)
          sSP.AppendLine("DB);")
        Case TableRec.isAnyOptionSet(CallBuilder.PrivateConnectionString)
          sSP.AppendLine("using (var DBConn = new SqlConnection(_ConnectionString))")
          sSP.AppendLine("  {")
        Case Else
          sSP.Append("using (var DBConn = new SqlConnection(Properties.Settings.Default.")
          sSP.Append(TableRec.sDatabase)
          sSP.AppendLine("DB))")
          sSP.AppendLine("{")
      End Select

      Select Case True
        Case TableRec.isAnyOptionSet(CallBuilder.DataReader)
          sSP.Append("var DBCmd = new SqlCommand(""")
          sSP.Append(TableRec.FullSPName)
          sSP.AppendLine(""", DBConn);")
        Case Else

          sSP.Append("using (var DBCmd = new SqlCommand(""")
          sSP.Append(TableRec.FullSPName)
          If TableRec.isAnyOptionSet(CallBuilder.UseGlobalConnection) Then
            sSP.AppendLine(""", _DBConn))")
          Else
            sSP.AppendLine(""", DBConn))")
          End If
          sSP.Append("{")
          sSP.Append(ControlChars.CrLf)

      End Select



      If TableRec.isAnyOptionSet(CallBuilder.ExceptionHandling) Then
        sSP.AppendLine("try")
        sSP.Append("{")
        sSP.AppendLine()
      End If
      If TableRec.isAnyOptionSet(CallBuilder.CreateOptionalArgument) Then
        For Each dvRow As DataRowView In dvTbl

          If dvRow("PARAMETER_MODE").ToString.Contains("IN") Then
            sSP.Append(clsCommon.CreateOptionalArgCode_CS(dvRow("PARAMETER_NAME").ToString.Substring(1), dvRow("DATA_TYPE")))
          End If
        Next
      End If

      sSP.AppendLine("DBCmd.CommandType = CommandType.StoredProcedure;")
      sSP.AppendLine()
      If TableRec.isAnyOptionSet(CallBuilder.UseTransaction) Then
        sSP.AppendLine("DBCmd.Transaction = _DBTrans;")
      End If

      'If iOptions And CallBuilder.TableCls Then
      '  sSP.Append("With [VALUE]" & ControlChars.CrLf)
      'End If

      For Each dvRow As DataRowView In dvTbl
        'row = tb.Rows(intPntr)
        '        If dvRow("PARAMETER_TYPE") <> 4 Then
        sSP.Append("DBCmd.Parameters.Add(""" & dvRow("PARAMETER_NAME") & """")
        sSP.Append(", SqlDbType." & clsCommon.GetSQLDbType(dvRow("DATA_TYPE")))
        If IsDBNull(dvRow("CHARACTER_MAXIMUM_LENGTH")) Then

        Else
          sSP.Append(", " & dvRow("CHARACTER_MAXIMUM_LENGTH"))
        End If
        If dvRow("PARAMETER_MODE") = "IN" Then
          sSP.Append(").Value = ")
          If TableRec.isAnyOptionSet(CallBuilder.SendNulls) Then
            sSP.Append("KDOR.DBFunctions.SendNulls(")
          End If
          Select Case True
            Case TableRec.isAnyOptionSet(CallBuilder.CreateOptionalArgument)
              sSP.Append(dvRow("PARAMETER_NAME").ToString.Substring(1))
            Case TableRec.isAnyOptionSet(CallBuilder.TableCls)
              sSP.Append("[CLASSNAME].")
              sSP.Append(clsCommon.GetPrefix(dvRow("DATA_TYPE")))
              sSP.Append(dvRow("PARAMETER_NAME").ToString.Substring(1))
            Case TableRec.isAnyOptionSet(CallBuilder.UseLocal)
              sSP.Append(clsCommon.GetPrefix(dvRow("DATA_TYPE")))
              sSP.Append(dvRow("PARAMETER_NAME").ToString.Substring(1))
            Case Else
              sSP.Append("[VALUE]")
          End Select

          If TableRec.SPOptions And CallBuilder.SendNulls Then
            sSP.Append(", ")
            Select Case dvRow("DATA_TYPE")
              Case "decimal", "numeric", "int", "smallint", "tinyint", "money", "bigint", "smallmoney", "float", "real"
                sSP.Append("KDOR.DBFunctions.ObjectTypes.Numbers, 0);")
              Case "char", "varchar", "nchar", "nvarchar", "binary", "varbinary", "text"
                sSP.Append("KDOR.DBFunctions.ObjectTypes.Strings);")
              Case "datetime", "smalldatetime", "date", "datetime2", "datetimeoffset", "time"
                sSP.Append("KDOR.DBFunctions.ObjectTypes.Dates);")
              Case "bit"
                sSP.Append("KDOR.DBFunctions.ObjectTypes.Booleans, false);")
              Case Else
                'Do Nothing
            End Select
          Else
            sSP.Append(";")
          End If

        Else
          sSP.Append(");")
        End If
        sSP.Append(ControlChars.CrLf)
        If dvRow("DATA_TYPE") = "decimal" Or dvRow("DATA_TYPE") = "numeric" Then
          sSP.Append("DBCmd.Parameters[""")
          sSP.Append(dvRow("PARAMETER_NAME"))
          sSP.Append("""].Precision = ")
          sSP.Append(dvRow("NUMERIC_PRECISION"))
          sSP.Append(";")
          sSP.Append(ControlChars.CrLf)
          sSP.Append("DBCmd.Parameters[""")
          sSP.Append(dvRow("PARAMETER_NAME"))
          sSP.Append("""].Scale = ")
          sSP.Append(dvRow("NUMERIC_SCALE"))
          sSP.Append(";")
          sSP.Append(ControlChars.CrLf)
        End If
        If dvRow("PARAMETER_MODE") = "IN" Then
        Else
          sSP.Append("DBCmd.Parameters[""")
          sSP.Append(dvRow("PARAMETER_NAME"))
          sSP.Append("""].Direction = ")
          If dvRow("ORDINAL_POSITION") = 0 Then
            sSP.Append(" ParameterDirection.ReturnValue;")
          Else
            Select Case dvRow("PARAMETER_MODE")
              Case "IN"
                sSP.Append(" ParameterDirection.Input;")
              Case Else
                sSP.Append(" ParameterDirection.Output;")
            End Select
          End If
          sSP.Append(ControlChars.CrLf)
        End If
      Next


      'We can finish up our string concatenation with our footer information

      If TableRec.isAnyOptionSet(CallBuilder.UseTransaction, CallBuilder.UseGlobalConnection) Then
      Else
        sSP.Append("DBConn.Open();" & ControlChars.CrLf)
      End If

      If TableRec.isAnyOptionSet(CallBuilder.DataReader) Then

        sSP.AppendLine("return DBCmd.ExecuteReader(CommandBehavior.CloseConnection);")

      Else
        sSP.AppendLine("DBCmd.ExecuteNonQuery();")
        'Handled by the using statements now
        'If TableRec.isAnyOptionSet(CallBuilder.ExceptionHandling, CallBuilder.UseTransaction, CallBuilder.UseGlobalConnection) Then
        '  sSP.AppendLine()
        'Else
        '  'sSP.AppendLine("DBConn.Close();")
        '  sSP.AppendLine()
        'End If


        For Each dvRow As DataRowView In dvTbl
          If dvRow("PARAMETER_MODE") <> "IN" Then
            If (TableRec.SPOptions And CallBuilder.TableCls) And dvRow("ORDINAL_POSITION") > 0 Then
              sSP.Append("[CLASSNAME].")
              sSP.Append(clsCommon.GetPrefix(dvRow("DATA_TYPE")))
              sSP.Append(dvRow("PARAMETER_NAME").ToString.Substring(1))
            Else
              If TableRec.SPOptions And CallBuilder.UseLocal And dvRow("ORDINAL_POSITION") > 0 Then
                sSP.Append(clsCommon.GetPrefix(dvRow("DATA_TYPE")))
                sSP.Append(dvRow("PARAMETER_NAME").ToString.Substring(1))
              Else
                sSP.Append("// [VALUE]")
              End If
            End If
            sSP.Append(" = ")
            sSP.Append(clsCommon.CreateOutputParameter_CS(dvRow("PARAMETER_NAME"), dvRow("DATA_TYPE"), TableRec.SPOptions And CallBuilder.RemoveNulls))
            sSP.AppendLine(";")
          End If
        Next

        sSP.Append(ControlChars.CrLf)
        sSP.Append("return true;")
        sSP.Append(ControlChars.CrLf)
      End If



      'Error Handling

      If TableRec.isAnyOptionSet(CallBuilder.ExceptionHandling) Then
        sSP.AppendFormat("{0}}}  // End try{1}", ControlChars.Tab, ControlChars.CrLf)
        sSP.Append(ControlChars.CrLf)
        sSP.Append("catch" & ControlChars.CrLf)
        sSP.AppendFormat("{{{0}", ControlChars.CrLf)
        sSP.AppendFormat("{0}throw;{1}", ControlChars.Tab, ControlChars.CrLf)
        sSP.AppendLine("} // End Catch")
        sSP.Append(ControlChars.CrLf)
      End If


      Select Case True
        Case TableRec.isAnyOptionSet(CallBuilder.DataReader)

        Case Else
          sSP.Append(ControlChars.CrLf)
          sSP.Append("} // End sqlCommand Using")

      End Select

      Select Case True
        Case TableRec.isAnyOptionSet(CallBuilder.DataReader, CallBuilder.UseGlobalConnection)
        Case Else
          sSP.Append(ControlChars.CrLf)
          sSP.Append("} // End SQLConnection Using")
      End Select



      sSP.Append(ControlChars.CrLf)
      sSP.Append("} // End Function")

      If TableRec.isAnyOptionSet(CallBuilder.CreateNewClass) Then
        sSP.AppendLine()
        sSP.AppendLine()
        sSP.Append("public cls[Class Name](string ConnectionString) {")
        sSP.AppendLine()
        sSP.Append("_ConnectionString = ConnectionString;")
        sSP.AppendLine()
        sSP.Append("}} // End Declaration Function")

      End If

      Return sSP.ToString

    End Function

    Public Sub New(ByVal sConnectionString As String)
      _ConnectionString = sConnectionString
    End Sub


  End Class




End Namespace
