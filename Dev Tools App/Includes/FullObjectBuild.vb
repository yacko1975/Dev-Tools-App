Imports System
Imports System.Data
Imports System.Data.OleDb

Namespace Includes


  Public Class clsFull_Object_Build
    Private _ConnectionString As String
    Private _MasterConnectionString As String
    Private _DatabaseName As String

    Public Function Build_VB(ByRef TableRec As Types.TableFmt, ByRef alStoredProc As ArrayList) As String
      Dim sSP As New System.Text.StringBuilder
      Dim StoredProc As Types.clsStoredProc
      Dim DBBuilder As New Includes.DBBuilder(_ConnectionString)
      Dim SPTableRec As Types.TableFmt

      sSP.Append(ClassName_VB(TableRec))

      For Each StoredProc In alStoredProc.ToArray(GetType(Types.clsStoredProc))
        SPTableRec = New Types.TableFmt
        SPTableRec.addOption(Types.CallBuilder.ExceptionHandling, Types.CallBuilder.UseLocal, Types.CallBuilder.PrivateConnectionString)

        SPTableRec.SPName = StoredProc.Name
        SPTableRec.sDatabase = TableRec.sDatabase

        With StoredProc
          If .bDataReader Then
            SPTableRec.addOption(Types.CallBuilder.DataReader)
          End If
          If .bPassNulls Then
            SPTableRec.addOption(Types.CallBuilder.SendNulls)
          End If
          If .bRemoveNulls Then
            SPTableRec.addOption(Types.CallBuilder.RemoveNulls)
          End If
          If .bUseTransaction Then
            SPTableRec.addOption(Types.CallBuilder.UseTransaction)
          End If
          If .bGlobalConn Then
            SPTableRec.addOption(Types.CallBuilder.UseGlobalConnection)
          End If
          If .bPassOptArg Then
            SPTableRec.addOption(Types.CallBuilder.CreateOptionalArgument)
          End If

          sSP.Append(DBBuilder.Build_SP_Code_VB(SPTableRec))
          sSP.AppendLine()
          sSP.AppendLine()
        End With

      Next

      sSP.Append(EndClassName_VB)

      Return sSP.ToString

    End Function

    Public Function Build_CS(ByRef TableRec As Types.TableFmt, ByRef alStoredProc As ArrayList) As String
      Dim sSP As New System.Text.StringBuilder
      Dim StoredProc As Types.clsStoredProc
      Dim DBBuilder As New DBBuilder(_ConnectionString)
      Dim SPTableRec As Types.TableFmt


      sSP.Append(ClassName_CS(TableRec))

      For Each StoredProc In alStoredProc.ToArray(GetType(Types.clsStoredProc))
        SPTableRec = New Types.TableFmt
        SPTableRec.addOption(Types.CallBuilder.ExceptionHandling, Types.CallBuilder.UseLocal, Types.CallBuilder.PrivateConnectionString)

        SPTableRec.SPName = StoredProc.Name
        SPTableRec.sDatabase = TableRec.sDatabase

        With StoredProc
          If .bDataReader Then
            SPTableRec.addOption(Types.CallBuilder.DataReader)
          End If
          If .bPassNulls Then
            SPTableRec.addOption(Types.CallBuilder.SendNulls)
          End If
          If .bRemoveNulls Then
            SPTableRec.addOption(Types.CallBuilder.RemoveNulls)
          End If
          If .bUseTransaction Then
            SPTableRec.addOption(Types.CallBuilder.UseTransaction)
          End If
          If .bGlobalConn Then
            SPTableRec.addOption(Types.CallBuilder.UseGlobalConnection)
          End If
          If .bPassOptArg Then
            SPTableRec.addOption(Types.CallBuilder.CreateOptionalArgument)
          End If

          sSP.Append(DBBuilder.Build_SP_Code_CS(SPTableRec))
          sSP.AppendLine()
          sSP.AppendLine()
        End With

      Next

      sSP.Append(EndClassName_CS(TableRec))

      Return sSP.ToString

    End Function

    Public Function ClassName_VB(ByRef TableRec As Types.TableFmt) As String
      Dim sSP As New System.Text.StringBuilder
      Dim TypeBuilder As New Includes.TypeBuilder(_ConnectionString)
      sSP.AppendLine("Imports System.Data")
      sSP.AppendLine("Imports System.Data.SqlClient")
      sSP.AppendLine()
      sSP.AppendLine("Namespace [Namespace]")
      sSP.AppendLine()
      sSP.Append("Public Class cls")
      sSP.AppendLine(TableRec.sTable)
      sSP.AppendLine()
      sSP.Append(clsCommon.CreatePrivateVariables_VB(TableRec))
      sSP.AppendLine()
      sSP.Append("#Region ""Public Variables""")
      sSP.AppendLine()
      TypeBuilder.Build_Type(TableRec)
      sSP.Append(TableRec.sTypeClass)
      sSP.AppendLine("#End Region")
      sSP.AppendLine()

      If TableRec.isAnyOptionSet(Types.CallBuilder.UseTransaction, Types.CallBuilder.UseGlobalConnection) Then
        sSP.Append(clsCommon.CreateDBOpenClose_VB(TableRec))
      End If
      sSP.AppendLine()

      Return sSP.ToString

    End Function

    Private Function EndClassName_VB() As String
      Dim sSP As New System.Text.StringBuilder

      sSP.Append("Public Sub New(ByVal ConnectionString As String)")
      sSP.AppendLine()
      sSP.Append("_ConnectionString = ConnectionString")
      sSP.AppendLine()
      sSP.AppendLine("End Sub")
      sSP.AppendLine()
      sSP.AppendLine("End Class")
      sSP.AppendLine()
      sSP.AppendLine("End Namespace")
      Return sSP.ToString

    End Function


    Public Function ClassName_CS(ByRef TableRec As Types.TableFmt) As String
      Dim sSP As New System.Text.StringBuilder
      Dim TypeBuilder As New Includes.TypeBuilder(_ConnectionString)
      sSP.AppendLine("using System;")
      sSP.AppendLine("using System.Data;")
      sSP.AppendLine("using System.Data.SqlClient;")
      sSP.AppendLine()
      sSP.AppendLine("namespace [Namespace]")
      sSP.AppendLine("{")
      sSP.AppendLine()
      sSP.Append("class cls")
      sSP.AppendLine(TableRec.sTable)
      sSP.AppendLine("{")
      sSP.AppendLine()
      sSP.Append(clsCommon.CreatePrivateVariables_CS(TableRec))

      sSP.AppendLine("#region Public Variables")
      TypeBuilder.Build_Type(TableRec)
      sSP.Append(TableRec.sTypeClass)
      sSP.AppendLine("#endregion")
      sSP.AppendLine()

      If TableRec.isAnyOptionSet(Types.CallBuilder.UseTransaction, Types.CallBuilder.UseGlobalConnection) Then
        sSP.Append(clsCommon.CreateDBOpenClose_CS(TableRec))
      End If
      sSP.AppendLine()

      Return sSP.ToString

    End Function

    Private Function EndClassName_CS(ByRef TableRec As Types.TableFmt) As String
      Dim sSP As New System.Text.StringBuilder

      sSP.AppendFormat("public cls{0}(string ConnectionString)", TableRec.sTable).AppendLine()
      sSP.AppendLine("{")
      sSP.Append(ControlChars.Tab)
      sSP.Append("_ConnectionString = ConnectionString;")
      sSP.AppendLine()
      sSP.AppendLine("}")
      sSP.AppendLine()
      sSP.AppendLine("}")
      sSP.AppendLine()
      sSP.AppendLine("}")
      Return sSP.ToString

    End Function

    Public Sub New(ByVal Database As String, ByVal ConnectionString As String)
      _ConnectionString = String.Format(ConnectionString, Database)
    End Sub

  End Class

End Namespace