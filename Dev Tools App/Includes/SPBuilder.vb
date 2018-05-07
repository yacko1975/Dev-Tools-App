Imports System
Imports System.Data
Imports System.Data.OleDb
Imports KDOR.Extensions

Namespace Includes

  Public Class SPBuilder
    Private _ConnectionString As String

    Public Sub Create_SP(ByRef TableRec As Types.TableFmt)
      Dim DB As New clsDBGlobal(_ConnectionString)
      TableRec.aylPrimaryKey = DB.Get_Primary_Keys(TableRec)
      TableRec.aylColumn = DB.Get_Columns(TableRec)


      Select Case TableRec.Action
        Case Types.Action.Select_All
          TableRec.sSQL = Create_SP_Select(TableRec)
        Case Types.Action.Select_One
          TableRec.sSQL = Create_SP_Select_One(TableRec)
        Case Types.Action.Update
          TableRec.sSQL = Create_SP_Update(TableRec)
        Case Types.Action.Insert
          TableRec.sSQL = Create_SP_Insert(TableRec)
        Case Types.Action.Delete
          TableRec.sSQL = Create_SP_Delete(TableRec)
        Case Else
          TableRec.sSQL = Create_SP_Select(TableRec)
      End Select



    End Sub

    Public Sub Create_Multiple_SP(ByRef TableRec As Types.TableFmt)
      Dim DB As New clsDBGlobal(_ConnectionString)
      TableRec.aylPrimaryKey = DB.Get_Primary_Keys(TableRec)
      TableRec.aylColumn = DB.Get_Columns(TableRec)
      Dim sbSQL As New Text.StringBuilder

      If (TableRec.Action And Types.Action.Select_All) = Types.Action.Select_All Then
        sbSQL.Append(Create_SP_Select(TableRec))
        sbSQL.AppendLine()
        sbSQL.AppendLine("GO")
        sbSQL.AppendLine()
      End If
      If (TableRec.Action And Types.Action.Select_One) = Types.Action.Select_One Then
        sbSQL.Append(Create_SP_Select_One(TableRec))
        sbSQL.AppendLine()
        sbSQL.AppendLine("GO")
        sbSQL.AppendLine()
      End If
      If (TableRec.Action And Types.Action.Delete) = Types.Action.Delete Then
        sbSQL.Append(Create_SP_Delete(TableRec))
        sbSQL.AppendLine()
        sbSQL.AppendLine("GO")
        sbSQL.AppendLine()
      End If
      If (TableRec.Action And Types.Action.Insert) = Types.Action.Insert Then
        sbSQL.Append(Create_SP_Insert(TableRec))
        sbSQL.AppendLine()
        sbSQL.AppendLine("GO")
        sbSQL.AppendLine()
      End If
      If (TableRec.Action And Types.Action.Update) = Types.Action.Update Then
        sbSQL.Append(Create_SP_Update(TableRec))
        sbSQL.AppendLine()
        sbSQL.AppendLine("GO")
        sbSQL.AppendLine()
      End If

      TableRec.sSQL = sbSQL.ToString

    End Sub


    Private Function Create_Comment(ByVal sUsername As String) As String
      Dim sbSQL As New Text.StringBuilder

      sbSQL.AppendLine("-- =============================================")
      sbSQL.AppendFormat("-- Author:      {0}", sUsername)
      sbSQL.AppendLine()
      sbSQL.AppendFormat("-- Create date: {0:MM/dd/yyyy}", Now)
      sbSQL.AppendLine()
      sbSQL.AppendLine("-- Description:	[Description]")
      sbSQL.AppendLine("-- =============================================")

      Return sbSQL.ToString

    End Function

    Private Function Create_SP_Select(ByVal TableRec As Types.TableFmt) As String
      Dim sbSQL As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim iPntr As Int32

      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      sbSQL.Append(Create_Comment(TableRec.sUsername))

      'Commented by Theo; 02/06/2017
      'sbSQL.Append("CREATE PROCEDURE dbo.")

      'Added by Theo; 02/06/2017
      sbSQL.Append(String.Format("CREATE PROCEDURE [{0}].[", ColumnRec(0).sTableOwner))
      sbSQL.Append(TableRec.User)
      sbSQL.Append("_")
      sbSQL.Append(TableRec.sTable)
      sbSQL.Append("_List]")
      sbSQL.Append(vbCrLf)
      sbSQL.Append("AS")
      sbSQL.Append(vbCrLf)
      sbSQL.Append("Select")
      sbSQL.Append(vbCrLf)
      For iPntr = 0 To ColumnRec.GetUpperBound(0)
        sbSQL.AppendFormat("  {0},", ColumnRec(iPntr).sColumnName)
        sbSQL.Append(vbCrLf)
      Next
      sbSQL.Remove(sbSQL.Length - 3, 3)
      sbSQL.Append(vbCrLf)
      sbSQL.Append("From")
      sbSQL.Append(vbCrLf)
      sbSQL.AppendFormat("  [{0}].[{1}]", ColumnRec(0).sTableOwner, TableRec.sTable)
      If TableRec.isAnyOptionSet(Includes.Types.CallBuilder.UseArchive) Then
        sbSQL.AppendFormat(" LEFT JOIN (SELECT [{0}_UID] AS {0}_UID2, MAX([Revision_Id]) AS MAX_Revision_Id FROM {0} GROUP BY {0}_UID) AS A ON [{0}_UID] = [{0}_UID2] AND [Status] = 'ACT'", TableRec.sTable)
      End If
      If TableRec.bPermission Then
        sbSQL.Append(vbCrLf)
        sbSQL.Append(vbCrLf)
        sbSQL.AppendFormat("Grant Execute on [{0}].[{1}] to [UserID]", ColumnRec(0).sTableOwner, TableRec.sTable)
      End If

      Return sbSQL.ToString

    End Function

    Private Function Create_SP_Select_One(ByVal TableRec As Types.TableFmt) As String
      Dim sbSQL As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim iPntr As Int32
      Dim iIndexCnt As Int32

      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      With sbSQL

        .Append(Create_Comment(TableRec.sUsername))


        'Commented by Theo; 02/06/2017; To get an appropiate Schema
        '.Append("CREATE PROCEDURE dbo.")

        'Added by Theo; 02/06/2017
        .Append(String.Format("CREATE PROCEDURE [{0}].[", ColumnRec(0).sTableOwner))

        sbSQL.Append(TableRec.User)
        sbSQL.Append("_")
        .Append(TableRec.sTable)
        .Append("_Info]")
        .Append(vbCrLf)
        .Append("(")
        .Append(vbCrLf)
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          .Append("  @")
          .Append(ColumnRec(iPntr).sColumnName)
          .Append(" ")
          Select Case ColumnRec(iPntr).sColumnType
            Case "image"
              'Probably really a varbinary or binary
              .Append("varbinary(max)")
            Case "text"
              .Append("varchar(max)")
            Case Else
              .Append(ColumnRec(iPntr).sColumnType)

          End Select
          Select Case ColumnRec(iPntr).sColumnType
            Case "decimal", "numeric"
              .Append("(")
              .Append(ColumnRec(iPntr).iColumnPrecision)
              .Append(",")
              .Append(ColumnRec(iPntr).iColumnScale)
              .Append(")")
            Case "char", "varchar", "float", "nchar", "nvarchar", "binary", "varbinary"
              .Append("(")
              If ColumnRec(iPntr).iColumnLength > 8000 Then
                .Append("max")
              Else
                .Append(ColumnRec(iPntr).iColumnLength)
              End If
              .Append(")")
            Case Else
              'Do Nothing

          End Select
          If ColumnRec(iPntr).bColumnPK Then
            .Append(",")
          Else
            .Append(" output,")
          End If
          .Append(vbCrLf)
        Next
        .Remove(sbSQL.Length - 3, 3)
        .Append(vbCrLf)
        .Append(")")
        .Append(vbCrLf)
        .Append("AS")
        .Append(vbCrLf)
        .Append("Select")
        .Append(vbCrLf)
        Dim pkIndex As String = String.Empty
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          If ColumnRec(iPntr).bColumnPK Then
            If String.IsNullOrEmpty(pkIndex) AndAlso ColumnRec(iPntr).sColumnName.ToLower.IndexOf("_uid") Then
              pkIndex = ColumnRec(iPntr).sColumnName
            End If
          Else
            .AppendFormat("  @{0}={1},", ColumnRec(iPntr).sColumnName, ColumnRec(iPntr).sColumnName)
            .Append(vbCrLf)
          End If
        Next
        .Remove(sbSQL.Length - 3, 3)
        .Append(vbCrLf)
        .Append("From")
        .Append(vbCrLf)
        .AppendFormat("  [{0}].[{1}]", ColumnRec(0).sTableOwner, TableRec.sTable)
        .Append(vbCrLf)
        If TableRec.isAnyOptionSet(Includes.Types.CallBuilder.UseArchive) Then
          If String.IsNullOrEmpty(pkIndex) Then
            .AppendFormat(" LEFT JOIN (SELECT [{0}_UID] AS {0}_UID2, MAX([Revision_Id]) AS MAX_Revision_Id FROM {0} GROUP BY {0}_UID) AS A ON [{0}_UID] = [{0}_UID2] AND [Status] = 'ACT'", TableRec.sTable)
          Else
            .AppendFormat(" LEFT JOIN (SELECT [{1}] AS {1}2, MAX([Revision_Id]) AS MAX_Revision_Id FROM {0} GROUP BY {1}) AS A ON [{1}] = [{1}2] AND [Status] = 'ACT'", TableRec.sTable, pkIndex)
          End If
          .Append(vbCrLf)
        End If
        .Append("Where")
        .Append(vbCrLf)
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          If ColumnRec(iPntr).bColumnPK Then
            .AppendFormat("  {0}=@{1}", ColumnRec(iPntr).sColumnName, ColumnRec(iPntr).sColumnName)
            .Append(vbCrLf)
            .Append("And")
            .Append(vbCrLf)
            iIndexCnt += 1
          Else

          End If
        Next
        If iIndexCnt = 0 Then
          .Remove(sbSQL.Length - 8, 8)
        Else
          .Remove(sbSQL.Length - 7, 7)
        End If

      End With

      Return sbSQL.ToString



    End Function

    Private Function Create_SP_Update(ByVal tablerec As Types.TableFmt) As String
      Dim sbSQL As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim iPntr As Int32
      Dim iIndexCnt As Int32

      ColumnRec = tablerec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      With sbSQL

        sbSQL.Append(Create_Comment(tablerec.sUsername))

        'Commented by Theo; 02/06/2017
        '.Append("CREATE PROCEDURE dbo.")

        'Added by Theo; 02/06/2017
        .Append(String.Format("CREATE PROCEDURE [{0}].[", ColumnRec(0).sTableOwner))

        sbSQL.Append(tablerec.User)
        sbSQL.Append("_")
        sbSQL.Append(tablerec.sTable)
        sbSQL.Append("_Updt]")
        .Append(vbCrLf)
        .Append("(")
        .Append(vbCrLf)
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          .Append("  @")
          .Append(ColumnRec(iPntr).sColumnName)
          .Append(" ")
          Select Case ColumnRec(iPntr).sColumnType
            Case "image"
              'Probably really a varbinary or binary
              .Append("varbinary(max)")
            Case "text"
              .Append("varchar(max)")
            Case Else
              .Append(ColumnRec(iPntr).sColumnType)

          End Select
          Select Case ColumnRec(iPntr).sColumnType
            Case "decimal", "numeric"
              .Append("(")
              .Append(ColumnRec(iPntr).iColumnPrecision)
              .Append(",")
              .Append(ColumnRec(iPntr).iColumnScale)
              .Append(")")
            Case "char", "varchar", "float", "nchar", "nvarchar", "binary", "varbinary"
              .Append("(")
              .Append(ColumnRec(iPntr).iColumnLength)
              .Append(")")
            Case Else
              'Do Nothing
          End Select
          sbSQL.Append(",")
          sbSQL.Append(vbCrLf)
        Next
        If tablerec.isAnyOptionSet(Includes.Types.CallBuilder.UseOutput) Then
          sbSQL.AppendLine("  @Update_UserID varchar(32)")
        Else
          .Remove(sbSQL.Length - 3, 3)
        End If
        .Append(vbCrLf)
        .Append(")")
        .Append(vbCrLf)
        .Append("AS")
        .Append(vbCrLf)
        .Append("Update")
        .Append(vbCrLf)
        .AppendFormat("  [{0}].[{1}]", ColumnRec(0).sTableOwner, tablerec.sTable)
        .Append(vbCrLf)
        .Append("Set")
        .Append(vbCrLf)
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          If ColumnRec(iPntr).bColumnPK Then

          Else
            .AppendFormat("  {0}=@{1},", ColumnRec(iPntr).sColumnName, ColumnRec(iPntr).sColumnName)
            .Append(vbCrLf)
          End If
        Next
        .Remove(sbSQL.Length - 3, 3)
        .AppendLine()
        If tablerec.isAnyOptionSet(Includes.Types.CallBuilder.UseOutput) Then
          .Append("Output")
          .Append(vbCrLf)
          For iPntr = 0 To ColumnRec.GetUpperBound(0)
            If ColumnRec(iPntr).bColumnPK Then
              .AppendFormat("  inserted.{0},", ColumnRec(iPntr).sColumnName)
              .AppendLine()
            Else
              .AppendFormat("  inserted.{0},", ColumnRec(iPntr).sColumnName)
              .Append(vbCrLf)
            End If
          Next
          .AppendLine("  @Update_UserID,")
          .AppendLine("  getdate()")
          .AppendLine("Into")
          .AppendFormat("[{0}].[{1}_history]", ColumnRec(0).sTableOwner, tablerec.sTable)
          .AppendLine()
          .AppendFormat("(")
          For iPntr = 0 To ColumnRec.GetUpperBound(0)
            .AppendFormat("  {0},", ColumnRec(iPntr).sColumnName)
            .Append(vbCrLf)
          Next
          .AppendLine("  Last_Modified_ID,")
          .AppendLine("  Last_Modified_TS")
          .AppendFormat(")")
          .AppendLine()
        End If
        .Append(vbCrLf)
        .Append("Where")
        .Append(vbCrLf)
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          If ColumnRec(iPntr).bColumnPK Then
            .AppendFormat("  {0}=@{1}", ColumnRec(iPntr).sColumnName, ColumnRec(iPntr).sColumnName)
            .Append(vbCrLf)
            .Append("And")
            .Append(vbCrLf)
            iIndexCnt += 1
          End If
        Next
        If iIndexCnt = 0 Then
          .Remove(sbSQL.Length - 8, 8)
        Else
          .Remove(sbSQL.Length - 7, 7)
        End If

        If tablerec.bPermission Then
          sbSQL.Append(vbCrLf)
          sbSQL.Append(vbCrLf)
          sbSQL.AppendFormat("Grant Execute on [{0}].[{1}] to [UserID]", ColumnRec(0).sTableOwner, tablerec.sTable)
        End If

      End With

      Return sbSQL.ToString

    End Function

    Private Function Create_SP_Insert(ByVal TableRec As Types.TableFmt) As String
      Dim sbSQL As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim iPntr As Int32
      Dim bIdentity As Boolean

      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      With sbSQL

        sbSQL.Append(Create_Comment(TableRec.sUsername))

        'Commented by Theo; 02/06/2017
        '.Append("CREATE PROCEDURE dbo.")

        'Added by Theo; 02/06/2017
        .Append(String.Format("CREATE PROCEDURE [{0}].[", ColumnRec(0).sTableOwner))
        sbSQL.Append(TableRec.User)
        sbSQL.Append("_")
        sbSQL.Append(TableRec.sTable)
        sbSQL.Append("_Insrt]")
        .Append(vbCrLf)
        .Append("(")
        .Append(vbCrLf)
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          If ColumnRec(iPntr).bColumnIdentity Then
            bIdentity = True
          Else
            .Append("  @")
            .Append(ColumnRec(iPntr).sColumnName)
            .Append(" ")
            Select Case ColumnRec(iPntr).sColumnType
              Case "image"
                'Probably really a varbinary or binary
                .Append("varbinary(max)")
              Case "text"
                .Append("varchar(max)")
              Case Else
                .Append(ColumnRec(iPntr).sColumnType)

            End Select
            Select Case ColumnRec(iPntr).sColumnType
              Case "decimal", "numeric"
                .Append("(")
                .Append(ColumnRec(iPntr).iColumnPrecision)
                .Append(",")
                .Append(ColumnRec(iPntr).iColumnScale)
                .Append(")")
              Case "char", "varchar", "float", "nchar", "nvarchar", "binary", "varbinary"
                .Append("(")
                .Append(ColumnRec(iPntr).iColumnLength)
                .Append(")")
              Case Else
                'Do Nothing
            End Select
            sbSQL.Append(",")
            sbSQL.Append(vbCrLf)
          End If
        Next
        If TableRec.isAnyOptionSet(Includes.Types.CallBuilder.UseOutput) Then
          sbSQL.AppendLine("  @Update_UserID varchar(32)")
        Else
          .Remove(sbSQL.Length - 3, 3)
        End If
        .Append(vbCrLf)
        .Append(")")
        .Append(vbCrLf)
        .Append("AS")
        .Append(vbCrLf)
        .Append("Insert Into")
        .Append(vbCrLf)
        .AppendFormat("  [{0}].[{1}]", ColumnRec(0).sTableOwner, TableRec.sTable)
        .Append(vbCrLf)
        .Append("(")
        .Append(vbCrLf)
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          If ColumnRec(iPntr).bColumnIdentity Then

          Else
            .AppendFormat("  {0},", ColumnRec(iPntr).sColumnName)
            .Append(vbCrLf)
          End If
        Next
        .Remove(sbSQL.Length - 3, 3)
        .Append(vbCrLf)
        .Append(")")
        .Append(vbCrLf)
        If TableRec.isAnyOptionSet(Includes.Types.CallBuilder.UseOutput) Then
          .Append("Output")
          .Append(vbCrLf)
          For iPntr = 0 To ColumnRec.GetUpperBound(0)
            If ColumnRec(iPntr).bColumnPK Then
              .AppendFormat("  inserted.{0},", ColumnRec(iPntr).sColumnName)
              .AppendLine()
            Else
              .AppendFormat("  inserted.{0},", ColumnRec(iPntr).sColumnName)
              .Append(vbCrLf)
            End If
          Next
          .AppendLine("  @Update_UserID,")
          .AppendLine("  getdate()")
          .AppendLine("Into")
          .AppendFormat("[{0}].[{1}_history]", ColumnRec(0).sTableOwner, TableRec.sTable)
          .AppendLine()
          .AppendFormat("(")
          For iPntr = 0 To ColumnRec.GetUpperBound(0)
            .AppendFormat("  {0},", ColumnRec(iPntr).sColumnName)
            .Append(vbCrLf)
          Next
          .AppendLine("  Last_Modified_ID,")
          .AppendLine("  Last_Modified_TS")
          .AppendFormat(")")
          .AppendLine()
        End If
        .Append("Values")
        .Append(vbCrLf)
        .Append("(")
        .Append(vbCrLf)
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          If ColumnRec(iPntr).bColumnIdentity Then

          Else
            .AppendFormat("  @{0},", ColumnRec(iPntr).sColumnName)
            .Append(vbCrLf)
          End If
        Next
        .Remove(sbSQL.Length - 3, 3)
        .Append(vbCrLf)
        .Append(")")
        If bIdentity Then
          .Append(vbCrLf)
          .Append("Return @@Identity")
        End If

        If TableRec.bPermission Then
          sbSQL.Append(vbCrLf)
          sbSQL.Append(vbCrLf)
          sbSQL.AppendFormat("Grant Execute on [{0}].[{1}] to [UserID]", ColumnRec(0).sTableOwner, TableRec.sTable)
        End If

      End With

      Return sbSQL.ToString
    End Function

    Private Function Create_SP_Delete(ByVal TableRec As Types.TableFmt) As String
      Dim sbSQL As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim iPntr As Int32
      Dim iIndexCnt As Int32

      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      With sbSQL

        .Append(Create_Comment(TableRec.sUsername))

        'Commented by Theo; 02/06/2017
        '.Append("CREATE PROCEDURE dbo.")

        'Added by Theo; 02/06/2017
        .Append(String.Format("CREATE PROCEDURE [{0}].[", ColumnRec(0).sTableOwner))
        sbSQL.Append(TableRec.User)
        sbSQL.Append("_")
        .Append(TableRec.sTable)
        .Append("_Del]")
        .Append(vbCrLf)
        .Append("(")
        .Append(vbCrLf)
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          If ColumnRec(iPntr).bColumnPK Then
            .Append("  @")
            .Append(ColumnRec(iPntr).sColumnName)
            .Append(" ")
            Select Case ColumnRec(iPntr).sColumnType
              Case "image"
                'Probably really a varbinary or binary
                .Append("varbinary(max)")
              Case "text"
                .Append("varchar(max)")
              Case Else
                .Append(ColumnRec(iPntr).sColumnType)

            End Select
            Select Case ColumnRec(iPntr).sColumnType
              Case "decimal", "numeric"
                .Append("(")
                .Append(ColumnRec(iPntr).iColumnPrecision)
                .Append(",")
                .Append(ColumnRec(iPntr).iColumnScale)
                .Append(")")
              Case "char", "varchar", "float", "nchar", "nvarchar", "binary", "varbinary"
                .Append("(")
                .Append(ColumnRec(iPntr).iColumnLength)
                .Append(")")
              Case Else
                'Do Nothing
            End Select
            .Append(",")
            .Append(vbCrLf)
            iIndexCnt += 1
          End If
        Next
        If TableRec.isAnyOptionSet(Includes.Types.CallBuilder.UseOutput) Then
          sbSQL.AppendLine("  @Update_UserID varchar(32)")
        Else
          .Remove(sbSQL.Length - 3, 3)
        End If
        .Append(vbCrLf)
        .Append(")")
        .Append(vbCrLf)
        .Append("AS")
        .Append(vbCrLf)
        .Append("Delete")
        .Append(vbCrLf)
        .Append("From")
        .Append(vbCrLf)
        If TableRec.isAnyOptionSet(Includes.Types.CallBuilder.UseOutput) Then
          .Append("Output")
          .Append(vbCrLf)
          For iPntr = 0 To ColumnRec.GetUpperBound(0)
            If ColumnRec(iPntr).bColumnPK Then
              .AppendFormat("  deleted.{0},", ColumnRec(iPntr).sColumnName)
              .Append(vbCrLf)
            End If
          Next
          .AppendLine("  @Update_UserID,")
          .AppendLine("  getdate()")
          .AppendLine("Into")
          .AppendFormat("[{0}].[{1}_history]", ColumnRec(0).sTableOwner, TableRec.sTable)
          .AppendLine()
          .AppendFormat("(")
          For iPntr = 0 To ColumnRec.GetUpperBound(0)
            .AppendFormat("  {0},", ColumnRec(iPntr).sColumnName)
            .Append(vbCrLf)
          Next
          .AppendLine("  Last_Modified_ID,")
          .AppendLine("  Last_Modified_TS")
          .AppendFormat(")")
          .AppendLine()
        End If
        .AppendFormat("  [{0}].[{1}]", ColumnRec(0).sTableOwner, TableRec.sTable)
        .Append(vbCrLf)
        .Append("Where")
        .Append(vbCrLf)
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          If ColumnRec(iPntr).bColumnPK Then
            .AppendFormat("  {0}=@{1}", ColumnRec(iPntr).sColumnName, ColumnRec(iPntr).sColumnName)
            .Append(vbCrLf)
            .Append("And")
            .Append(vbCrLf)
            iIndexCnt += 1
          Else

          End If
        Next
        If iIndexCnt = 0 Then
          .Remove(sbSQL.Length - 8, 8)
        Else
          .Remove(sbSQL.Length - 7, 7)
        End If

        If TableRec.bPermission Then
          sbSQL.Append(vbCrLf)
          sbSQL.Append(vbCrLf)
          sbSQL.AppendFormat("Grant Execute on [{0}].[{1}] to [UserID]", ColumnRec(0).sTableOwner, TableRec.sTable)
        End If

      End With

      Return sbSQL.ToString

    End Function


    Public Sub New(ByVal sConnectionString As String)
      _ConnectionString = sConnectionString
    End Sub

  End Class

End Namespace