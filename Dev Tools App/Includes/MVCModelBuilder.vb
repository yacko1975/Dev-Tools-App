Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Dev_Tools_App.Includes.Types

Namespace Includes

  Public Class clsMVCModelBuilder

    Private _ConnectionString As String


    Public Sub Build_Model(ByRef TableRec As Types.TableFmt)
      Dim DB As New clsDBGlobal(_ConnectionString)
      TableRec.aylPrimaryKey = DB.Get_Primary_Keys(TableRec)
      TableRec.aylColumn = DB.Get_Columns(TableRec)

      TableRec.sTypeClass = Create_Model_CS(TableRec)

    End Sub

    Private Function Create_Model_CS(ByVal TableRec As Types.TableFmt) As String
      Dim sbType As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim iPntr As Int32
      'Dim iIndexCnt As Int32

      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      With sbType

        If TableRec.bIncludeClassDefinition Then
          .Append("class cls")
          .Append(TableRec.sTable)
          .Append("Model")
          .Append(ControlChars.CrLf)
          .Append(ControlChars.Tab)
          .Append("{")
          .Append(ControlChars.CrLf)
        End If

        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          .Append(ControlChars.Tab)
          .Append("[Required]")
          'Select Case ColumnRec(iPntr).sColumnType
          '  Case 
          'End Select


          .Append(ControlChars.Tab)
          .Append("public ")
          .Append(clsCommon.GetType_CS(ColumnRec(iPntr).sColumnType, True))
          .Append(ColumnRec(iPntr).sColumnName)
          .Append(" { get; set; }")
          .Append(ControlChars.CrLf)
        Next
        If TableRec.bIncludeRegion Then
          .Append("#endregion")
          .AppendLine()
        End If
        If TableRec.bIncludeClassDefinition Then
          .Append("}")
        End If
      End With

      Return sbType.ToString

    End Function


  End Class

End Namespace