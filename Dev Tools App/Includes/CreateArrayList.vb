Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Text

Namespace Includes

  Public Class clsCreateArrayList
    Private _ConnectionString As String


    Public Sub Build_SQLToArrayList(ByRef TableRec As Types.TableFmt)
      Dim DB As New clsDBGlobal(_ConnectionString)
      TableRec.aylPrimaryKey = DB.Get_Primary_Keys(TableRec)
      TableRec.aylColumn = DB.Get_Columns(TableRec)

      Select Case TableRec.Language
        Case Types.enLanguage.VB
          TableRec.sCode = Create_SQL_To_ArrayList(TableRec)
        Case Types.enLanguage.CS
          TableRec.sCode = Create_SQL_To_ArrayList(TableRec)
      End Select

    End Sub


    Private Function Create_SQL_To_ArrayList(ByVal TableRec As Types.TableFmt) As String
      Dim sbFunction As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt


      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      With sbFunction
        .AppendLine("Public Function ReadSQLtoArrayList() as ArrayList")
        .Append("Dim sSQL as string = """)
        .Append(CreateSQL(TableRec))
        .AppendLine("""")
        .AppendLine("Dim dbQuery As New KDOR.clsDatabaseQueries(_ConnectionString)")
        .AppendLine("Dim dbrSelect As SqlClient.SqlDataReader")
        .AppendFormat("Dim al{0} As New ArrayList()", TableRec.sTable)
        .AppendLine()
        .AppendFormat("Dim {0} As New cls{0}(_ConnectionString)", TableRec.sTable)
        .AppendLine()
        .AppendLine()
        .AppendLine("dbrSelect = dbQuery.SQL_Return_Reader(sSQL)")
        .AppendLine()
        .AppendLine("While dbrSelect.Read")
        .AppendFormat("  With {0}", TableRec.sTable)
        .AppendLine()
        .Append(CreateItemsFromReader(TableRec))
        .AppendLine("  End With")
        .AppendFormat("  al{0}.Add({0})", TableRec.sTable)
        .AppendLine()
        .AppendLine("End While")
        .AppendLine()

        .AppendLine("dbrSelect.Close()")
        .AppendFormat("Return al{0}", TableRec.sTable)
        .AppendLine()
        .AppendLine()
        .AppendLine("End Function")
      End With

      Return sbFunction.ToString

    End Function

    Private Function CreateSQL(ByVal TableRec As Types.TableFmt) As String
      Dim sbSQL As New StringBuilder

      sbSQL.Append("Select")
      For Each ColumnRec As Types.ColumnFmt In TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))
        sbSQL.AppendFormat(" {0},", ColumnRec.sColumnName)
      Next
      sbSQL.Remove(sbSQL.Length - 1, 1)
      sbSQL.Append(" From ")
      sbSQL.Append(TableRec.sTable)
      If TableRec.bArchived Then
        sbSQL.AppendFormat(" LEFT JOIN (SELECT [{0}_UID] AS {0}_UID2, MAX([Revision_Id]) AS MAX_Revision_Id FROM {0} GROUP BY {0}_UID) AS A ON [{0}_UID] = [{0}_UID2] AND [Status] = 'ACT'", TableRec.sTable)
      End If

      Return sbSQL.ToString

    End Function

    Private Function CreateItemsFromReader(ByVal TableRec As Types.TableFmt) As String
      Dim sbSQL As New StringBuilder
      Dim iPosition As Int32 = 0

      For Each ColumnRec As Types.ColumnFmt In TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

        With sbSQL
          .Append("    .")
          .Append(clsCommon.GetPrefix(ColumnRec.sColumnType))
          .Append(ColumnRec.sColumnName)
          .Append(" = ")
          If TableRec.SPOptions And Types.CallBuilder.RemoveNulls Then
            .AppendFormat("KDOR.DBFunctions.RemoveNulls(dbrSelect({0}),", iPosition)
            Select Case ColumnRec.sColumnType
              Case "decimal", "numeric", "int", "smallint", "tinyint", "money", "smallmoney", "bigint", "float", "real"
                .Append("KDOR.DBFunctions.ObjectTypes.Numbers, 0)")
              Case "char", "varchar", "nchar", "nvarchar", "binary", "varbinary", "text"
                .Append("KDOR.DBFunctions.ObjectTypes.Strings)")
              Case "datetime", "smalldatetime", "date", "datetime2", "datetimeoffset", "time"
                .Append("KDOR.DBFunctions.ObjectTypes.Dates, nothing)")
              Case "bit"
                .Append("KDOR.dbFunctions.ObjectTypes.Booleans, False)")
              Case Else
                'Do Nothing
            End Select
          Else
            .Append(CreateTypedReader(ColumnRec.sColumnName, ColumnRec.sColumnType, iPosition))

          End If
          .AppendLine()
        End With
        iPosition += 1
      Next

      Return sbSQL.ToString

    End Function

    Private Function CreateTypedReader(ByVal sParameterName As String, ByVal sColumnType As String, ByVal iPosition As Int32) As String
      Dim sbReader As New Text.StringBuilder


      sbReader.Append("dbrSelect.")
      Select Case sColumnType
        Case "decimal", "numeric", "money", "smallmoney"
          sbReader.AppendFormat("GetDecimal({0})", iPosition)
        Case "int"
          sbReader.AppendFormat("GetInt32({0})", iPosition)
        Case "smallint", "tinyint"
          sbReader.AppendFormat("GetInt16({0})", iPosition)
        Case "bigint"
          sbReader.AppendFormat("GetInt64({0})", iPosition)
        Case "float", "real"
          sbReader.AppendFormat("GetDouble({0})", iPosition)
        Case "char", "varchar", "nchar", "nvarchar", "text"
          sbReader.AppendFormat("GetString({0})", iPosition)
        Case "binary", "varbinary"
          sbReader.AppendFormat("' Not Implemented")
        Case "datetime", "smalldatetime", "date", "datetime2", "time"
          sbReader.AppendFormat("GetDateTime({0})", iPosition)
        Case "datetimeoffset"
          sbReader.AppendFormat("GetDateTimeOffset({0})", iPosition)
        Case "char", "varchar", "nchar", "nvarchar", "text"
          sbReader.AppendFormat("GetString({0})", iPosition)
        Case "bit"
          sbReader.AppendFormat("GetBoolean({0})", iPosition)
        Case Else
          'Do Nothing
      End Select

      Return sbReader.ToString

    End Function

    Public Sub New(ByVal ConnectionString As String)
      _ConnectionString = ConnectionString
    End Sub

    Public Sub New(ByVal sDatabase As String, ByVal sConnectionString As String)
      _ConnectionString = String.Format(sConnectionString, sDatabase)
    End Sub

  End Class

End Namespace