Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Includes

  Public Class clsDBGlobal
    Private _ConnectionString As String


    Public ReadOnly Property CurrentConnectionString() As String
      Get
        Return _ConnectionString
      End Get
    End Property

    Public Function Get_Available_DBs() As SqlDataReader
      Dim DBConn As New SqlConnection(_ConnectionString)
      'Dim DBCMD As New SqlCommand("select Name from sys.databases where owner_sid <> 0x01 and state=0 order by name asc", DBConn)
      Dim DBCMD As New SqlCommand("select Name from sys.databases where state=0 order by name asc", DBConn)

      DBCMD.CommandType = CommandType.Text

      DBConn.Open()
      Return DBCMD.ExecuteReader

    End Function

    Public Function Get_Available_Tables() As SqlDataReader
      Dim DBConn As New SqlConnection(_ConnectionString)
      Dim DBCMD As New SqlCommand("SELECT name FROM sys.tables where type='u' order by Name Asc", DBConn)

      DBCMD.CommandType = CommandType.Text
      'DBCMD.Parameters.Add("@Table_Type", OleDbType.VarChar, 100).Value = "TABLE"

      DBConn.Open()
      Return DBCMD.ExecuteReader

    End Function

    Public Function get_Available_Views() As SqlDataReader
      Dim DBConn As New SqlConnection(_ConnectionString)
      Dim DBCMD As New SqlCommand("SELECT name FROM sys.views where type='v' order by Name Asc", DBConn)

      DBCMD.CommandType = CommandType.Text
      'DBCMD.Parameters.Add("@Table_Type", OleDbType.VarChar, 100).Value = "TABLE"

      DBConn.Open()
      Return DBCMD.ExecuteReader


    End Function

    Public Function Get_ViewsandTables() As ArrayList
      Dim alVwTbl As New ArrayList
      Dim drNames As SqlDataReader


      drNames = Get_Available_Tables()

      While drNames.Read
        alVwTbl.Add(drNames.GetString(0))
      End While

      drNames.Close()

      drNames = get_Available_Views()

      While drNames.Read
        alVwTbl.Add(drNames.GetString(0))
      End While

      drNames.Close()

      Return alVwTbl

    End Function


    Public Function Get_Stored_Procs() As DataTable
      Dim DBConn As New SqlConnection(_ConnectionString)
      Dim tbData As DataTable
      DBConn.Open()
      tbData = DBConn.GetSchema("Procedures")
      DBConn.Close()
      Return tbData

    End Function

    Public Function GetSelect(ByVal sSQL As String) As SqlDataReader
      Dim DBConn As New SqlConnection(_ConnectionString)
      Dim dbCMD As New SqlCommand(sSQL, DBConn)

      dbCMD.CommandType = CommandType.Text

      DBConn.Open()
      Return dbCMD.ExecuteReader(behavior:=CommandBehavior.CloseConnection)

    End Function


    Public Function Get_Login() As SqlDataReader
      Dim DBConn As New SqlConnection(_ConnectionString)
      Dim dbCMD As New SqlCommand("sp_helpuser", DBConn)


      dbCMD.CommandType = CommandType.StoredProcedure

      DBConn.Open()
      Return dbCMD.ExecuteReader(CommandBehavior.CloseConnection)

    End Function

    Public Function RunCommand(ByVal sSQL As String) As String
      Dim DBConn As New SqlConnection(_ConnectionString)
      Dim dbCMD As New SqlCommand(sSQL, DBConn)


      dbCMD.CommandType = CommandType.Text

      Try

        DBConn.Open()
        dbCMD.ExecuteNonQuery()

        Return String.Empty

      Catch ex As Exception
        Return ex.Message
      Finally
        If DBConn.State = ConnectionState.Open Then
          DBConn.Close()
        End If
      End Try

    End Function

    Public Function Get_Primary_Keys(ByVal TableRec As Types.TableFmt) As ArrayList
      Dim DBConn As New SqlConnection(_ConnectionString)
      Dim DBCMD As New SqlCommand(String.Format("exec sp_pkeys [{0}]", TableRec.sTable), DBConn)
      Dim dbRdr As SqlDataReader
      Dim aylPKs As New ArrayList

      DBConn.Open()
      dbRdr = DBCMD.ExecuteReader

      While dbRdr.Read
        aylPKs.Add(dbRdr.GetString(3).Trim)
      End While
      dbRdr.Close()
      DBConn.Close()

      Return aylPKs

    End Function

    Public Function Get_Columns(ByVal TableRec As Types.TableFmt) As ArrayList
      Dim DBConn As New SqlConnection(_ConnectionString)
      Dim DBCMD As New SqlCommand(String.Format("exec sp_columns [{0}]", TableRec.sTable), DBConn)
      Dim dbRdr As SqlDataReader
      Dim aylColumns As New ArrayList
      Dim asPKName() As String = TableRec.aylPrimaryKey.ToArray(GetType(String))


      DBConn.Open()
      dbRdr = DBCMD.ExecuteReader

      While dbRdr.Read
        Dim ColumnRec As New Types.ColumnFmt
        With ColumnRec
          .sTableOwner = dbRdr.GetString(1)
          .sColumnName = dbRdr.GetString(3).Trim
          'If asPKName.IndexOf(asPKName, .sColumnName) > -1 Then
          If Array.IndexOf(asPKName, .sColumnName) > -1 Then
            .bColumnPK = True
          Else
            .bColumnPK = False
          End If
          .sColumnType = dbRdr.GetString(5).Replace("identity", "").Trim
          If dbRdr.GetString(5).IndexOf("identity") > -1 Then
            .bColumnIdentity = True
          Else
            .bColumnIdentity = False
          End If
          .iColumnLength = dbRdr.GetInt32(7)
          .iColumnPrecision = dbRdr.GetInt32(6)
          .bNullable = dbRdr.GetString(17).Equals("YES")
          If IsDBNull(dbRdr(8)) Then
            .iColumnScale = 0
          Else
            .iColumnScale = dbRdr.GetInt16(8)
          End If
          'Lets modify the fields on anything that has special considerations
          Select Case .sColumnType
            Case "nchar", "nvarchar"
              'Length is  2*(Char count)
              .iColumnLength = .iColumnPrecision
          End Select

        End With
        aylColumns.Add(ColumnRec)
      End While
      dbRdr.Close()
      DBConn.Close()

      Return aylColumns

    End Function

    Public Function Get_Columns_From_SQL(ByVal sSQL As String) As ArrayList
      Dim DBConn As New SqlConnection(_ConnectionString)
      Dim DBCMD As New SqlCommand(sSQL, DBConn)
      Dim dbRdr As SqlDataReader
      Dim schema As DataTable
      Dim aylColumns As New ArrayList

      DBConn.Open()
      dbRdr = DBCMD.ExecuteReader

      schema = dbRdr.GetSchemaTable


      For Each Row In schema.Rows
        Dim ColumnRec As New Types.ColumnFmt
        With ColumnRec
          '.sTableOwner = dbRdr.GetString(1)
          .sColumnName = Row("ColumnName")
          'If asPKName.IndexOf(asPKName, .sColumnName) > -1 Then
          .bColumnPK = False
          .sColumnType = Row("DataType").Name
          .iColumnLength = Row("ColumnSize")
          .iColumnPrecision = Row("NumericPrecision")
          If IsDBNull(Row("NumericScale")) Then
            .iColumnScale = 0
          Else
            .iColumnScale = Row("NumericScale")
          End If
          'Lets modify the fields on anything that has special considerations
          Select Case .sColumnType
            Case "nchar", "nvarchar"
              'Length is  2*(Char count)
              .iColumnLength = .iColumnPrecision
          End Select

        End With
        aylColumns.Add(ColumnRec)
      Next
      dbRdr.Close()
      DBConn.Close()

      Return aylColumns

    End Function

    'Public Function DB_Get_ServerList(Optional ByVal sEnvironment As String = Nothing) As Generic.Dictionary(Of String, String)
    '  Dim DBConn As New SqlClient.SqlConnection(My.Settings.IntranetDB)
    '  Dim DBCmd As New SqlClient.SqlCommand("", DBConn)
    '  Dim dicServers As New Generic.Dictionary(Of String, String)
    '  Dim rdrServers As SqlClient.SqlDataReader
    '  Dim sSQL As String

    '  If IsNothing(sEnvironment) Then
    '    sSQL = "select Description, DatabaseServerName from databaseserver"
    '  Else
    '    sSQL = String.Format("select Description, DatabaseServerName from databaseserver where enviroment='{0}'", sEnvironment)
    '  End If

    '  DBCmd.CommandType = CommandType.Text
    '  DBCmd.CommandText = sSQL

    '  DBConn.Open()

    '  rdrServers = DBCmd.ExecuteReader(CommandBehavior.CloseConnection)

    '  While rdrServers.Read
    '    If dicServers.ContainsKey(rdrServers.GetString(1)) Then

    '    Else
    '      dicServers.Add(rdrServers.GetString(1), rdrServers.GetString(0))
    '    End If

    '  End While

    '  rdrServers.Close()

    '  Return dicServers

    'End Function

    'Public Function DB_Get_ConnectionString(ByVal sDatabaseServerName As String) As String
    '  Dim DBConn As New SqlClient.SqlConnection(My.Settings.IntranetDB)
    '  Dim DBCmd As New SqlClient.SqlCommand("", DBConn)
    '  Dim sConString As String

    '  DBCmd.CommandText = String.Format("select top 1 connectionstring from databaseserver where databaseservername='{0}'", sDatabaseServerName)
    '  DBCmd.CommandType = CommandType.Text

    '  DBConn.Open()

    '  sConString = DBCmd.ExecuteScalar

    '  DBConn.Close()

    '  Return sConString

    'End Function


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