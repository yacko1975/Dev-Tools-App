Imports System
Imports System.Data
Imports System.Data.OleDb

Namespace Includes

  Public Class TypeBuilder
    Private _ConnectionString As String


    Public Sub Build_Type(ByRef TableRec As Types.TableFmt)
      Dim DB As New clsDBGlobal(_ConnectionString)
      TableRec.aylPrimaryKey = DB.Get_Primary_Keys(TableRec)
      TableRec.aylColumn = DB.Get_Columns(TableRec)

      Select Case TableRec.Language
        Case Types.enLanguage.VB
          If TableRec.bProperties Then
            TableRec.sTypeClass = Create_Type_w_Properties_VB(TableRec)
          Else
            TableRec.sTypeClass = Create_Type_VB(TableRec)
          End If
        Case Types.enLanguage.CS
          If TableRec.bProperties Then
            TableRec.sTypeClass = Create_Type_w_Properties_CS(TableRec)
          ElseIf TableRec.bPropertiesOnly Then
            TableRec.sTypeClass = Create_Type_w_PropertiesOnly_CS(TableRec)
          Else
            TableRec.sTypeClass = Create_Type_CS(TableRec)
          End If
      End Select

    End Sub

    Private Function Create_Type_CS(ByVal TableRec As Types.TableFmt) As String
      Dim sbType As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim iPntr As Int32
      'Dim iIndexCnt As Int32

      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      With sbType

        If TableRec.bIncludeClassDefinition Then
          .Append("class cls")
          .Append(TableRec.sTable)
          .Append(ControlChars.CrLf)
          .Append(ControlChars.Tab)
          .Append("{")
          .Append(ControlChars.CrLf)
        End If

        If TableRec.bIncludeRegion Then
          .Append("#region Public Variables")
          .AppendLine()
        End If

        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          .Append(ControlChars.Tab)
          If TableRec.bUsePrivate Then
            .Append("private ")
          Else
            .Append("public ")
          End If
          .Append(clsCommon.GetType_CS(ColumnRec(iPntr).sColumnType, True))
          .Append(clsCommon.GetPrefix(ColumnRec(iPntr).sColumnType))
          .Append(ColumnRec(iPntr).sColumnName)
          .Append(";")
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

    Private Function Create_Type_w_Properties_CS(ByVal TableRec As Types.TableFmt) As String
      Dim sbType As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim bCreateClass As Boolean = TableRec.bIncludeClassDefinition

      Dim iPntr As Int32
      'Dim iIndexCnt As Int32

      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      With sbType

        If TableRec.bIncludeClassDefinition Then
          .Append("class ")
          .Append(TableRec.sTable)
          .Append(ControlChars.CrLf)
          .Append("{")
          .Append(ControlChars.CrLf)
          .Append(ControlChars.CrLf)
        End If
        'Creates the Items
        TableRec.bIncludeClassDefinition = False
        .Append(Create_Type_CS(TableRec))
        TableRec.bIncludeClassDefinition = bCreateClass
        .Append(ControlChars.CrLf)
        If TableRec.bIncludeRegion Then
          .Append("#region Properties")
          .AppendLine()
          .AppendLine()
        End If
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          .Append("public  ")
          .Append(clsCommon.GetType_CS(ColumnRec(iPntr).sColumnType, True))
          .Append(ColumnRec(iPntr).sColumnName)
          .Append(ControlChars.CrLf)
          .Append(ControlChars.Tab)
          .Append("{")
          .Append(ControlChars.CrLf)
          .Append(ControlChars.Tab)
          .Append("get { ")
          .Append("return ")
          .Append(clsCommon.GetPrefix(ColumnRec(iPntr).sColumnType))
          .Append(ColumnRec(iPntr).sColumnName)
          .Append("; }")
          .Append(ControlChars.CrLf)
          .Append(ControlChars.Tab)
          .Append("set { ")
          .Append(clsCommon.GetPrefix(ColumnRec(iPntr).sColumnType))
          .Append(ColumnRec(iPntr).sColumnName)
          .Append(" = value; }")
          .Append(ControlChars.CrLf)
          .Append(ControlChars.Tab)
          .Append("}")
          .Append(ControlChars.CrLf)
          .Append(ControlChars.CrLf)
        Next
        If TableRec.bIncludeRegion Then
          .Append("#region Properties")
          .AppendLine()
          .AppendLine()
        End If
        If TableRec.bIncludeClassDefinition Then
          .Append("}")
        End If
      End With

      Return sbType.ToString

    End Function

    Private Function Create_Type_w_PropertiesOnly_CS(ByVal TableRec As Types.TableFmt) As String
      Dim sbType As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim bCreateClass As Boolean = TableRec.bIncludeClassDefinition

      Dim iPntr As Int32
      'Dim iIndexCnt As Int32

      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      With sbType

        If TableRec.bIncludeClassDefinition Then
          .Append("class ")
          .Append(TableRec.sTable)
          .Append(ControlChars.CrLf)
          .Append("{")
          .Append(ControlChars.CrLf)
          .Append(ControlChars.CrLf)
        End If
        'Creates the Items
        'TableRec.bIncludeClassDefinition = False
        ''.Append(Create_Type_CS(TableRec))
        'TableRec.bIncludeClassDefinition = bCreateClass
        '.Append(ControlChars.CrLf)
        If TableRec.bIncludeRegion Then
          .Append("#region Properties")
          .AppendLine()
          .AppendLine()
        End If
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          .Append("public  ")
          .Append(clsCommon.GetNullableType_CS(ColumnRec(iPntr).sColumnType, ColumnRec(iPntr).bNullable, True))
          .Append(ColumnRec(iPntr).sColumnName)
          .Append("{ get; set; }")
          .Append(ControlChars.CrLf)
        Next
        If TableRec.bIncludeRegion Then
          .Append("#region Properties")
          .AppendLine()
          .AppendLine()
        End If
        If TableRec.bIncludeClassDefinition Then
          .Append("}")
        End If
      End With

      Return sbType.ToString

    End Function


    Private Function Create_Type_VB(ByVal TableRec As Types.TableFmt) As String
      Dim sbType As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim iPntr As Int32
      'Dim iIndexCnt As Int32

      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))


      With sbType

        If TableRec.bIncludeClassDefinition Then
          .Append("Public Class cls")
          .Append(TableRec.sTable)
          .Append(ControlChars.CrLf)
          .Append(ControlChars.CrLf)
        End If
        If TableRec.bIncludeRegion Then
          .Append("#Region ""Public Variables""")
          .AppendLine()
        End If
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          .Append(ControlChars.Tab)
          If TableRec.bUsePrivate Then
            .Append("Private ")
          Else
            .Append("Public ")
          End If
          .Append(clsCommon.GetPrefix(ColumnRec(iPntr).sColumnType))
          .Append(ColumnRec(iPntr).sColumnName)
          .Append(" as ")
          .Append(clsCommon.GetType_VB(ColumnRec(iPntr).sColumnType, True))
          .Append(ControlChars.CrLf)
        Next
        If TableRec.bIncludeRegion Then
          .Append("#End Region")
          .AppendLine()
          .AppendLine()
        End If
        If TableRec.bIncludeClassDefinition Then
          .Append("End Class")
        End If
      End With

      Return sbType.ToString

    End Function

    Private Function Create_Type_w_Properties_VB(ByVal TableRec As Types.TableFmt) As String
      Dim sbType As New Text.StringBuilder
      Dim ColumnRec() As Types.ColumnFmt
      Dim bCreateClass As Boolean = TableRec.bIncludeClassDefinition

      Dim iPntr As Int32
      'Dim iIndexCnt As Int32

      ColumnRec = TableRec.aylColumn.ToArray(GetType(Types.ColumnFmt))

      With sbType

        If TableRec.bIncludeClassDefinition Then
          .Append("Public Class ")
          .Append(TableRec.sTable)
          .Append(ControlChars.CrLf)
        End If
        'Creates the Items
        TableRec.bIncludeClassDefinition = False
        .Append(Create_Type_VB(TableRec))
        TableRec.bIncludeClassDefinition = bCreateClass
        .Append(ControlChars.CrLf)
        If TableRec.bIncludeRegion Then
          .Append("#Region ""Public Properties""")
          .AppendLine()
          .AppendLine()
        End If
        For iPntr = 0 To ColumnRec.GetUpperBound(0)
          .Append("Public Property ")
          .Append(ColumnRec(iPntr).sColumnName)
          .Append(" as ")
          .Append(clsCommon.GetType_VB(ColumnRec(iPntr).sColumnType, False))
          .Append(ControlChars.CrLf)
          .Append("Get")
          .Append(ControlChars.CrLf)
          .Append("Return ")
          .Append(clsCommon.GetPrefix(ColumnRec(iPntr).sColumnType))
          .Append(ColumnRec(iPntr).sColumnName)
          .Append(ControlChars.CrLf)
          .Append("End Get")
          .Append(ControlChars.CrLf)
          .Append("Set(ByVal value As ")
          .Append(clsCommon.GetType_VB(ColumnRec(iPntr).sColumnType, False))
          .Append(")")
          .Append(ControlChars.CrLf)
          .Append(clsCommon.GetPrefix(ColumnRec(iPntr).sColumnType))
          .Append(ColumnRec(iPntr).sColumnName)
          .Append(" = value")
          .Append(ControlChars.CrLf)
          .Append("End Set")
          .Append(ControlChars.CrLf)
          .Append("End Property")
          .Append(ControlChars.CrLf)
          .Append(ControlChars.CrLf)
        Next
        If TableRec.bIncludeRegion Then
          .Append("#End Region")
          .AppendLine()
          .AppendLine()
        End If
        If TableRec.bIncludeClassDefinition Then
          .Append("End Class")
        End If
      End With

      Return sbType.ToString

    End Function

    Public Sub New(ByVal ConnectionString As String)
      _ConnectionString = ConnectionString
    End Sub

    Public Sub New(ByVal sDatabase As String, ByVal sConnectionString As String)
      _ConnectionString = String.Format(sConnectionString, sDatabase)
    End Sub

  End Class

End Namespace