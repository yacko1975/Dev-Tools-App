Imports Microsoft.VisualBasic
Imports System.Text

Namespace Includes

  Public Class clsCommon

#Region "Private Variables"
    Private _ConnectionString As String
#End Region

    Public Shared Function getSPUsers() As List(Of String)
      Dim lUser As New List(Of String)

      For Each sName As String In My.Settings.SPUsers.Split("|")
        If String.IsNullOrWhiteSpace(sName) Then
        Else
          lUser.Add(sName.Trim)
        End If
      Next

      Return lUser

    End Function

    Public Shared Function getServers() As Dictionary(Of Int32, String)
      Dim sValues As String = My.Settings.histServer
      Dim slSer As New Dictionary(Of Int32, String)
      Dim iPos As Int32 = 1
      Dim bs As New BindingSource

      If String.IsNullOrWhiteSpace(sValues) Then
      Else
        For Each sServer In sValues.Split("|")
          slSer.Add(iPos, sServer)
          iPos += 1
        Next

      End If

      Return slSer

    End Function

    Public Shared Sub saveServers(ByVal dServers As Dictionary(Of Int32, String))
      Dim sServers As String

      sServers = String.Join("|", dServers.OrderBy(Function(x) x.Key).Select(Function(x) x.Value))

      My.Settings.histServer = sServers
      My.Settings.Save()


    End Sub



    Public Shared Function GetPrefix(ByVal sType As String) As String
      Dim sbPrefix As New StringBuilder
      Select Case sType
        Case "decimal", "numeric", "money", "smallmoney"
          sbPrefix.Append("d")
        Case "int"
          sbPrefix.Append("i")
        Case "smallint", "tinyint"
          sbPrefix.Append("i")
        Case "bigint"
          sbPrefix.Append("i")
        Case "float", "real"
          sbPrefix.Append("f")
        Case "char", "varchar", "nchar", "nvarchar", "text"
          sbPrefix.Append("s")
        Case "binary", "varbinary"
          sbPrefix.Append("byt")
        Case "datetime", "smalldatetime", "date", "datetime2"
          sbPrefix.Append("dt")
        Case "datetimeoffset"
          sbPrefix.Append("dto")
        Case "time"
          sbPrefix.Append("ts")
        Case "bit"
          sbPrefix.Append("b")
        Case Else
          'This is Unknown

      End Select

      Return sbPrefix.ToString

    End Function

    Public Shared Function GetDefaultForType_VB(ByVal sType As String, Optional ByVal bIncludeComparison As Boolean = False) As String
      Dim sbType As New StringBuilder

      With sbType
        Select Case sType.ToLower
          Case "decimal", "numeric", "money", "smallmoney", "smallint", "tinyint", "int", "bigint", "float", "real"
            If bIncludeComparison Then
              .Append(" = ")
            End If
            .Append("0")
          Case "char", "varchar", "nchar", "nvarchar", "text", "datetime", "smalldatetime", "date", "datetime2", "datetimeoffset", "time", "binary", "varbinary"
            If bIncludeComparison Then
              .Append(" is ")
            End If
            .Append("nothing")
          Case "bit"
            If bIncludeComparison Then
              .Append(" = ")
            End If
            .Append("False")
          Case Else
            .Append("**Unknown**")
        End Select
      End With

      Return sbType.ToString

    End Function

    Public Shared Function GetDefaultForType_CS(ByVal sType As String, Optional ByVal bIncludeComparison As Boolean = False) As String
      Dim sbType As New StringBuilder

      With sbType
        Select Case sType.ToLower
          Case "decimal", "numeric", "money", "smallmoney", "smallint", "tinyint", "int", "bigint", "float", "real"
            If bIncludeComparison Then
              .Append(" == ")
            End If
            .Append("0")
          Case "char", "varchar", "nchar", "nvarchar", "text", "datetime", "smalldatetime", "date", "datetime2", "datetimeoffset", "time", "binary", "varbinary"
            If bIncludeComparison Then
              .Append(" == ")
            End If
            .Append("null")
          Case "bit"
            If bIncludeComparison Then
              .Append(" == ")
            End If
            .Append("False")
          Case Else
            .Append("**Unknown**")
        End Select
      End With

      Return sbType.ToString

    End Function

    Public Shared Function GetType_VB(ByVal sType As String, Optional ByVal bAppendSpace As Boolean = False) As String
      Dim sbType As New StringBuilder

      With sbType
        Select Case sType.ToLower
          Case "decimal", "numeric", "money", "smallmoney"
            .Append("decimal")
          Case "smallint", "tinyint"
            .Append("short")
          Case "int"
            .Append("Integer")
          Case "bigint"
            .Append("long")
          Case "char", "varchar", "nchar", "nvarchar", "text"
            .Append("string")
          Case "float", "real"
            .Append("double")
          Case "datetime", "smalldatetime", "date", "datetime2"
            .Append("DateTime")
          Case "datetimeoffset"
            .Append("DateTimeOffset")
          Case "time"
            .Append("TimeSpan")
          Case "bit"
            .Append("Boolean")
          Case "binary", "varbinary", "image"
            .Append("byte()")
          Case Else
            .Append("**Unknown**")
        End Select
      End With

      If bAppendSpace Then
        sbType.Append(Space(1))
      End If


      Return sbType.ToString

    End Function


    Public Shared Function GetType_CS(ByVal sType As String, Optional ByVal bAppendSpace As Boolean = False) As String
      Dim sbType As New StringBuilder

      With sbType
        Select Case sType
          Case "decimal", "numeric", "money", "smallmoney"
            .Append("decimal")
          Case "smallint", "tinyint"
            .Append("short")
          Case "int"
            .Append("int")
          Case "bigint"
            .Append("long")
          Case "char", "varchar", "nchar", "nvarchar", "text"
            .Append("string")
          Case "float", "real"
            .Append("double")
          Case "datetime", "smalldatetime", "date", "datetime2"
            .Append("DateTime")
          Case "datetimeoffset"
            .Append("DateTimeOffset")
          Case "time"
            .Append("TimeSpan")
          Case "bit"
            .Append("bool")
          Case "binary", "varbinary", "image"
            .Append("byte[]")
          Case Else
            .Append("**Unknown**")
        End Select
      End With

      If bAppendSpace Then
        sbType.Append(Space(1))
      End If


      Return sbType.ToString

    End Function

    Public Shared Function GetModelInfo_CS(ByVal sType As String, Optional ByVal bAppendSpace As Boolean = False) As String
      Dim sbType As New StringBuilder

      With sbType
        Select Case sType
          Case "decimal", "numeric", "money", "smallmoney"
            .Append("decimal")
          Case "smallint", "tinyint"
            .Append("short")
          Case "int"
            .Append("int")
          Case "bigint"
            .Append("long")
          Case "char", "varchar", "nchar", "nvarchar", "text"
            .Append("string")
          Case "float", "real"
            .Append("double")
          Case "datetime", "smalldatetime", "date", "datetime2"
            .Append("[")
          Case "datetimeoffset"
            .Append("DateTimeOffset")
          Case "time"
            .Append("TimeSpan")
          Case "bit"
            .Append("bool")
          Case "binary", "varbinary", "image"
            .Append("byte[]")
          Case Else
            .Append("**Unknown**")
        End Select
      End With

      If bAppendSpace Then
        sbType.Append(Space(1))
      End If


      Return sbType.ToString

    End Function

    Public Shared Function CreateOutputParameter_CS(ByVal sParameterName As String, ByVal sColumnType As String, Optional ByVal bRemoveNulls As Boolean = False) As String
      Dim sbParameter As New StringBuilder

      'sSP.Append("DBCmd.Parameters[""")
      'sSP.Append(row("PARAMETER_NAME"))
      'sSP.Append("""].Value;" & ControlChars.CrLf)
      With sbParameter

        Select Case sColumnType
          Case "decimal", "numeric", "money", "smallmoney"
            If bRemoveNulls Then
              .AppendFormat("Convert.ToDecimal(KDOR.DBFunctions.RemoveNulls(DBCmd.Parameters[""{0}""].Value, KDOR.DBFunctions.ObjectTypes.Numbers, 0))", sParameterName)
            Else
              .AppendFormat("Convert.ToDecimal(DBCmd.Parameters[""{0}""].Value)", sParameterName)
            End If
          Case "int"
            If bRemoveNulls Then
              .AppendFormat("Convert.ToInt32(KDOR.DBFunctions.RemoveNulls(DBCmd.Parameters[""{0}""].Value,KDOR.DBFunctions.ObjectTypes.Numbers, 0))", sParameterName)
            Else
              .AppendFormat("Convert.ToInt32(DBCmd.Parameters[""{0}""].Value)", sParameterName)

            End If

          Case "smallint", "tinyint"
            If bRemoveNulls Then
              .AppendFormat("Convert.ToInt16(KDOR.DBFunctions.RemoveNulls(DBCmd.Parameters[""{0}""].Value,KDOR.DBFunctions.ObjectTypes.Numbers, 0))", sParameterName)
            Else
              .AppendFormat("Convert.ToInt16(DBCmd.Parameters[""{0}""].Value)", sParameterName)

            End If
          Case "bigint"
            If bRemoveNulls Then
              .AppendFormat("Convert.ToInt64(KDOR.DBFunctions.RemoveNulls(DBCmd.Parameters[""{0}""].Value,KDOR.DBFunctions.ObjectTypes.Numbers, 0))", sParameterName)
            Else
              .AppendFormat("Convert.ToInt64(DBCmd.Parameters[""{0}""].Value)", sParameterName)

            End If
          Case "char", "varchar", "nchar", "nvarchar", "text"
            If bRemoveNulls Then
              .AppendFormat("KDOR.DBFunctions.RemoveNulls(DBCmd.Parameters[""{0}""].Value,KDOR.DBFunctions.ObjectTypes.Strings).ToString()", sParameterName)
            Else
              .AppendFormat("DBCmd.Parameters[""{0}""].Value.ToString()", sParameterName)
            End If
          Case "float", "real"
            If bRemoveNulls Then
              .AppendFormat("Convert.ToDouble(KDOR.DBFunctions.RemoveNulls(DBCmd.Parameters[""{0}""].Value,KDOR.DBFunctions.ObjectTypes.Numbers, 0))", sParameterName)
            Else
              .AppendFormat("Convert.ToDouble(DBCmd.Parameters[""{0}""].Value)", sParameterName)

            End If
          Case "datetime", "smalldatetime", "date", "datetime2"
            If bRemoveNulls Then
              .AppendFormat("Convert.ToDateTime(KDOR.DBFunctions.RemoveNulls(DBCmd.Parameters[""{0}""].Value,KDOR.DBFunctions.ObjectTypes.Dates, null))", sParameterName)
            Else
              .AppendFormat("Convert.ToDateTime(DBCmd.Parameters[""{0}""].Value)", sParameterName)

            End If
          Case "time"
            If bRemoveNulls Then
              .AppendFormat("TimeSpan.Parse(KDOR.DBFunctions.RemoveNulls(DBCmd.Parameters[""{0}""].Value,KDOR.DBFunctions.ObjectTypes.Dates, null).ToString())", sParameterName)
            Else
              .AppendFormat("TimeSpan.Parse(DBCmd.Parameters[""{0}""].Value.ToString())", sParameterName)

            End If
          Case "datetimeoffset"
            If bRemoveNulls Then
              .AppendFormat("DateTimeOffset.Parse(KDOR.DBFunctions.RemoveNulls(DBCmd.Parameters[""{0}""].Value,KDOR.DBFunctions.ObjectTypes.Dates, null).ToString())", sParameterName)
            Else
              .AppendFormat("DateTimeOffset.Parse(DBCmd.Parameters[""{0}""].Value.ToString())", sParameterName)

            End If
          Case "geography"
            .Append("//Geography is not supported on forms")
          Case "binary", "varbinary"
            'If bRemoveNulls Then
            '  .AppendFormat("KDOR.DBFunctions.RemoveNulls(DBCmd.Parameters[""{0}""].Value,KDOR.DBFunctions.ObjectTypes.Strings).ToString()", sParameterName)
            'Else
            .AppendFormat("DBCmd.Parameters[""{0}""].Value", sParameterName)
            'End If
          Case "bit"
            If bRemoveNulls Then
              .AppendFormat("Convert.ToBoolean(KDOR.DBFunctions.RemoveNulls(DBCmd.Parameters[""{0}""].Value,KDOR.DBFunctions.ObjectTypes.Booleans, false))", sParameterName)
            Else
              .AppendFormat("Convert.ToBoolean(DBCmd.Parameters[""{0}""].Value)", sParameterName)

            End If
        End Select

      End With

      Return sbParameter.ToString

    End Function

    Public Shared Function CreateOutputParameter_VB(ByVal sParameterName As String, ByVal sColumnType As String) As String
      Dim sbParameter As New StringBuilder

      'sSP.Append("DBCmd.Parameters[""")
      'sSP.Append(row("PARAMETER_NAME"))
      'sSP.Append("""].Value;" & ControlChars.CrLf)
      With sbParameter

        Select Case sColumnType
          Case "decimal", "numeric", "money", "smallmoney"
            .AppendFormat("Convert.ToDecimal(DBCmd.Parameters(""{0}"").Value)", sParameterName)
          Case "int"
            .AppendFormat("Convert.ToInt32(DBCmd.Parameters(""{0}"").Value)", sParameterName)
          Case "smallint", "tinyint"
            .AppendFormat("Convert.ToInt16(DBCmd.Parameters(""{0}"").Value)", sParameterName)
          Case "bigint"
            .AppendFormat("Convert.ToInt64(DBCmd.Parameters(""{0}"").Value)", sParameterName)
          Case "char", "varchar", "nchar", "nvarchar", "text"
            .AppendFormat("DBCmd.Parameters(""{0}"").Value.ToString()", sParameterName)
          Case "float", "real"
            .AppendFormat("Convert.ToDouble(DBCmd.Parameters(""{0}"").Value)", sParameterName)
          Case "datetime", "smalldatetime", "date", "datetime2"
            .AppendFormat("Convert.ToDateTime(DBCmd.Parameters(""{0}"").Value)", sParameterName)
          Case "time"
            .AppendFormat("TimeSpan.Parse(DBCmd.Parameters(""{0}"").Value.ToString())", sParameterName)
          Case "datetimeoffset"
            .AppendFormat("DateTimeOffset.Parse(DBCmd.Parameters(""{0}"").Value.ToString())", sParameterName)
          Case "binary", "varbinary", "image"
            .AppendFormat("ctype(DBCmd.Parameters(""{0}"").Value, byte())", sParameterName)
          Case "geography"
            .Append("//Geography is not supported on forms")
          Case "bit"
            .AppendFormat("Convert.ToBoolean(DBCmd.Parameters(""{0}"").Value)", sParameterName)
        End Select

      End With

      Return sbParameter.ToString


    End Function

    Public Shared Function CreateOptionalArgCode_VB(ByVal sParameterName As String, ByVal sColumnType As String) As String
      Dim sbOutput As New StringBuilder()
      Dim sPreFixedParameter As String

      sPreFixedParameter = String.Format("{0}{1}", GetPrefix(sColumnType), sParameterName)

      sbOutput.AppendFormat("If {0} {1} Then", sParameterName, GetDefaultForType_VB(sColumnType, True))
      sbOutput.AppendLine()
      sbOutput.AppendFormat("  {0} = {1}", sParameterName, sPreFixedParameter)
      sbOutput.AppendLine()
      sbOutput.AppendLine("Else")
      sbOutput.AppendFormat("  {0} = {1}", sPreFixedParameter, sParameterName)
      sbOutput.AppendLine()
      sbOutput.AppendLine("End If")
      sbOutput.AppendLine()

      Return sbOutput.ToString

    End Function

    Public Shared Function CreateOptionalArgCode_CS(ByVal sParameterName As String, ByVal sColumnType As String) As String
      Dim sbOutput As New StringBuilder()
      Dim sPreFixedParameter As String

      sPreFixedParameter = String.Format("{0}{1}", GetPrefix(sColumnType), sParameterName)

      sbOutput.AppendFormat("if ({0} {1}) ", sParameterName, GetDefaultForType_CS(sColumnType, True))
      sbOutput.AppendLine()
      sbOutput.AppendFormat("  {0} = {1};", sParameterName, sPreFixedParameter)
      sbOutput.AppendLine()
      sbOutput.AppendLine(" else ")
      sbOutput.AppendFormat("  {0} = {1};", sPreFixedParameter, sParameterName)
      sbOutput.AppendLine()
      sbOutput.AppendLine()

      Return sbOutput.ToString

    End Function

    Public Shared Function GetSQLDbType(ByVal InputString As String) As String
      Dim sbOutput As New StringBuilder()

      Select Case InputString
        Case "numeric"
          'Yes this is correct
          sbOutput.Append("Decimal")
        Case "smallint"
          sbOutput.Append("SmallInt")
        Case "tinyint"
          sbOutput.Append("TinyInt")
        Case "bigint"
          sbOutput.Append("BigInt")
        Case "varchar", "text"
          sbOutput.Append("VarChar")
        Case "nchar"
          sbOutput.Append("NChar")
        Case "nvarchar"
          sbOutput.Append("NVarChar")
        Case "smallmoney"
          sbOutput.Append("SmallMoney")
        Case "datetime"
          sbOutput.Append("DateTime")
        Case "smalldatetime"
          sbOutput.Append("SmallDateTime")
        Case "datetime2"
          sbOutput.Append("DateTime2")
        Case "datetimeoffset"
          sbOutput.Append("DateTimeOffset")
        Case "varbinary", "image"
          sbOutput.Append("VarBinary")
        Case "binary"
          sbOutput.Append("Binary")
        Case Else
          sbOutput.Append(InputString.Substring(0, 1).ToUpper)
          sbOutput.Append(InputString.Substring(1).ToLower)

      End Select

      Return sbOutput.ToString

    End Function

    Public Shared Function CreatePrivateVariables_VB(ByRef TableRec As Types.TableFmt) As String
      Dim sbCode As New StringBuilder

      sbCode.AppendLine("#Region ""Private Variables""")
      sbCode.AppendLine("    Private _ConnectionString As String")
      If TableRec.isAnyOptionSet(Types.CallBuilder.UseGlobalConnection) Then
        sbCode.AppendLine("    Private _DBConn As SqlConnection")
      End If
      If TableRec.isAnyOptionSet(Types.CallBuilder.UseTransaction) Then
        sbCode.AppendLine("    Private _DBTrans As SqlTransaction")
        sbCode.AppendLine("    Private _TransName As string")
      End If
      sbCode.Append("#End Region")
      sbCode.AppendLine()
      sbCode.AppendLine()

      Return sbCode.ToString

    End Function

    Public Shared Function CreatePrivateVariables_CS(ByRef TableRec As Types.TableFmt) As String
      Dim sbCode As New StringBuilder

      sbCode.AppendLine("#region Private Variables")
      sbCode.AppendLine("private string _ConnectionString;")
      If TableRec.isAnyOptionSet(Types.CallBuilder.UseGlobalConnection) Then
        sbCode.AppendLine("    private SqlConnection _DBConn;")
      End If
      If TableRec.isAnyOptionSet(Types.CallBuilder.UseTransaction) Then
        sbCode.AppendLine("    private SqlTransaction _DBTrans;")
        sbCode.AppendLine("    private string _TransName;")
      End If
      sbCode.Append("#endregion")
      sbCode.AppendLine()
      sbCode.AppendLine()

      Return sbCode.ToString

    End Function

    Public Shared Function CreateDBOpenClose_VB(ByRef TableRec As Types.TableFmt) As String
      Dim sbCode As New StringBuilder

      sbCode.AppendLine("#Region ""Connection and Transaction Handling""")
      sbCode.AppendLine()
      If TableRec.isAllOptionSet(Types.CallBuilder.UseTransaction) Then
        sbCode.AppendLine("Public Function Open_DB(Optional ByVal bBeginTrans As Boolean = False) As Boolean")
      Else
        sbCode.AppendLine("Public Function Open_DB() As Boolean")
      End If
      sbCode.AppendLine()
      sbCode.AppendLine("Try")
      sbCode.AppendLine("_DBConn = New SqlConnection(_ConnectionString)")
      sbCode.AppendLine("_DBConn.Open()")
      If TableRec.isAllOptionSet(Types.CallBuilder.UseTransaction) Then
        sbCode.AppendLine("If bBeginTrans Then")
        sbCode.AppendLine("StartNewTransaction()")
        sbCode.AppendLine("End If")
      End If
      sbCode.AppendLine("Return True")
      sbCode.AppendLine("Catch ex As Exception")
      sbCode.AppendLine("Throw")
      sbCode.AppendLine("End Try")
      sbCode.AppendLine()
      sbCode.AppendLine("End Function")
      sbCode.AppendLine()

      If TableRec.isAllOptionSet(Types.CallBuilder.UseTransaction) Then
        sbCode.AppendLine("Private Sub StartNewTransaction()")
        sbCode.AppendLine()
        sbCode.AppendLine("_TransName = KDOR.clsGeneralFunctions.GenerateRandomID(10, 10)")
        sbCode.AppendLine("_DBTrans = _DBConn.BeginTransaction(IsolationLevel.ReadCommitted, _TransName)")
        sbCode.AppendLine()
        sbCode.AppendLine("End Sub")
        sbCode.AppendLine()

        sbCode.AppendLine("Public Function Commit_Db(Optional ByVal bStartNewTrans As Boolean = False) As Boolean")
        sbCode.AppendLine()
        sbCode.AppendLine("Try")
        sbCode.AppendLine("_DBTrans.Commit()")
        sbCode.AppendLine("_TransName = Nothing")
        sbCode.AppendLine("If bStartNewTrans Then")
        sbCode.AppendLine("StartNewTransaction()")
        sbCode.AppendLine("End If")
        sbCode.AppendLine("Return True")
        sbCode.AppendLine("Catch ex As Exception")
        sbCode.AppendLine("Throw")
        sbCode.AppendLine("End Try")
        sbCode.AppendLine()
        sbCode.AppendLine("End Function")
        sbCode.AppendLine()

        sbCode.AppendLine("Public Function RollBack_DB() As Boolean")
        sbCode.AppendLine()
        sbCode.AppendLine("Try")
        sbCode.AppendLine("_DBTrans.Rollback(_TransName)")
        sbCode.AppendLine("_TransName = Nothing")
        sbCode.AppendLine("Return True")
        sbCode.AppendLine("Catch ex As Exception")
        sbCode.AppendLine("Throw")
        sbCode.AppendLine("End Try")
        sbCode.AppendLine()
        sbCode.AppendLine("End Function")
        sbCode.AppendLine()

        sbCode.AppendLine("Public Function BeginTrans_DB() As Boolean")
        sbCode.AppendLine()
        sbCode.AppendLine("Try")
        sbCode.AppendLine("If _TransName IsNot Nothing Then")
        sbCode.AppendLine("Throw New Exception(""Existing transaction exists, commit or rollback before starting a new transaction"")")
        sbCode.AppendLine("End If")
        sbCode.AppendLine("StartNewTransaction()")
        sbCode.AppendLine("Return True")
        sbCode.AppendLine("Catch ex As Exception")
        sbCode.AppendLine("Throw")
        sbCode.AppendLine("End Try")
        sbCode.AppendLine()
        sbCode.AppendLine("End Function")
        sbCode.AppendLine()

        sbCode.AppendLine("Public Function isDBOpen() As Boolean")
        sbCode.AppendLine()
        sbCode.AppendLine("If _DBConn Is Nothing Then")
        sbCode.AppendLine("Return False")
        sbCode.AppendLine("ElseIf _DBConn.State = ConnectionState.Open Then")
        sbCode.AppendLine("Return True")
        sbCode.AppendLine("Else")
        sbCode.AppendLine("Return False")
        sbCode.AppendLine("End If")
        sbCode.AppendLine()
        sbCode.AppendLine("End Function")
        sbCode.AppendLine()

        sbCode.AppendLine("Public Function isTransactionStarted() As Boolean")
        sbCode.AppendLine()
        sbCode.AppendLine("If _TransName Is Nothing Then")
        sbCode.AppendLine("Return False")
        sbCode.AppendLine("Else")
        sbCode.AppendLine("Return True")
        sbCode.AppendLine("End If")
        sbCode.AppendLine()
        sbCode.AppendLine("End Function")
        sbCode.AppendLine()

      End If

      If TableRec.isAllOptionSet(Types.CallBuilder.UseTransaction) Then
        sbCode.AppendLine("Public Function Close_DB(ByVal bCommitTransaction As Boolean) As Boolean")
      Else
        sbCode.AppendLine("Public Function Close_DB() As Boolean")
      End If
      sbCode.AppendLine()
      sbCode.AppendLine("Try")
      If TableRec.isAllOptionSet(Types.CallBuilder.UseTransaction) Then
        sbCode.AppendLine("If bCommitTransaction Then")
        sbCode.AppendLine("_DBTrans.Commit()")
        sbCode.AppendLine("ElseIf _TransName IsNot Nothing Then")
        sbCode.AppendLine("_DBTrans.Rollback(_TransName)")
        sbCode.AppendLine("End If")
      End If
      sbCode.AppendLine("_DBConn.Close()")
      sbCode.AppendLine("Return True")
      sbCode.AppendLine("Catch ex As Exception")
      sbCode.AppendLine("Throw")
      sbCode.AppendLine("End Try")
      sbCode.AppendLine()
      sbCode.AppendLine("End Function")
      sbCode.AppendLine()

      sbCode.AppendLine("#End Region")

      Return sbCode.ToString

    End Function


    Public Shared Function CreateDBOpenClose_CS(ByRef TableRec As Types.TableFmt) As String
      Dim sbCode As New StringBuilder

      sbCode.AppendLine("#region Connection and Transaction Handling")
      sbCode.AppendLine()
      If TableRec.isAllOptionSet(Types.CallBuilder.UseTransaction) Then
        sbCode.AppendLine("public bool Open_DB(bool bBeginTrans = false) {")
      Else
        sbCode.AppendLine("public bool Open_DB() {")
      End If
      sbCode.AppendLine()
      sbCode.AppendLine("try {")
      sbCode.AppendLine("_DBConn = new SqlConnection(_ConnectionString);")
      sbCode.AppendLine("_DBConn.Open();")
      If TableRec.isAllOptionSet(Types.CallBuilder.UseTransaction) Then
        sbCode.AppendLine("if (bBeginTrans)")
        sbCode.AppendLine("StartNewTransaction();")
      End If
      sbCode.AppendLine("return true;")
      sbCode.AppendLine("}")
      sbCode.AppendLine("catch {")
      sbCode.AppendLine("throw;")
      sbCode.AppendLine("}")
      sbCode.AppendLine()
      sbCode.AppendLine("}")
      sbCode.AppendLine()

      If TableRec.isAllOptionSet(Types.CallBuilder.UseTransaction) Then
        sbCode.AppendLine("private void StartNewTransaction() {")
        sbCode.AppendLine()
        sbCode.AppendLine("_TransName = KDOR.clsGeneralFunctions.GenerateRandomID(10, 10);")
        sbCode.AppendLine("_DBTrans = _DBConn.BeginTransaction(IsolationLevel.ReadCommitted, _TransName);")
        sbCode.AppendLine()
        sbCode.AppendLine("}")
        sbCode.AppendLine()

        sbCode.AppendLine("public bool Commit_Db(bool bStartNewTrans = false) {")
        sbCode.AppendLine()
        sbCode.AppendLine("try {")
        sbCode.AppendLine("_DBTrans.Commit();")
        sbCode.AppendLine("_TransName = null;")
        sbCode.AppendLine("if (bStartNewTrans) ")
        sbCode.AppendLine("StartNewTransaction();")
        sbCode.AppendLine("return true;")
        sbCode.AppendLine("}")
        sbCode.AppendLine("catch {")
        sbCode.AppendLine("throw;")
        sbCode.AppendLine("}")
        sbCode.AppendLine()
        sbCode.AppendLine("}")
        sbCode.AppendLine()

        sbCode.AppendLine("public bool RollBack_DB() {")
        sbCode.AppendLine()
        sbCode.AppendLine("try {")
        sbCode.AppendLine("_DBTrans.Rollback(_TransName);")
        sbCode.AppendLine("_TransName = null;")
        sbCode.AppendLine("return true;")
        sbCode.AppendLine("}")
        sbCode.AppendLine("catch {")
        sbCode.AppendLine("throw;")
        sbCode.AppendLine("}")
        sbCode.AppendLine()
        sbCode.AppendLine("}")
        sbCode.AppendLine()

        sbCode.AppendLine("public bool BeginTrans_DB() {")
        sbCode.AppendLine()
        sbCode.AppendLine("try {")
        sbCode.AppendLine("if (_TransName != null)")
        sbCode.AppendLine("throw new Exception(""Existing transaction exists, commit or rollback before starting a new transaction"");")
        sbCode.AppendLine("StartNewTransaction();")
        sbCode.AppendLine("return true;")
        sbCode.AppendLine("}")
        sbCode.AppendLine("catch {")
        sbCode.AppendLine("throw;")
        sbCode.AppendLine("}")
        sbCode.AppendLine()
        sbCode.AppendLine("}")
        sbCode.AppendLine()

      End If

      If TableRec.isAllOptionSet(Types.CallBuilder.UseTransaction) Then
        sbCode.AppendLine("public bool Close_DB(bool bCommitTransaction) {")
      Else
        sbCode.AppendLine("public bool Close_DB() {")
      End If
      sbCode.AppendLine()
      sbCode.AppendLine("try {")
      If TableRec.isAllOptionSet(Types.CallBuilder.UseTransaction) Then
        sbCode.AppendLine("if (bCommitTransaction)")
        sbCode.AppendLine("_DBTrans.Commit();")
        sbCode.AppendLine("else if (_TransName != null)")
        sbCode.AppendLine("_DBTrans.Rollback(_TransName);")
        sbCode.AppendLine()
      End If
      sbCode.AppendLine("_DBConn.Close();")
      sbCode.AppendLine("return true;")
      sbCode.AppendLine("}")
      sbCode.AppendLine("catch {")
      sbCode.AppendLine("throw;")
      sbCode.AppendLine("}")
      sbCode.AppendLine()
      sbCode.AppendLine("}")
      sbCode.AppendLine()

      sbCode.AppendLine("#endregion")

      Return sbCode.ToString

    End Function


  End Class

End Namespace