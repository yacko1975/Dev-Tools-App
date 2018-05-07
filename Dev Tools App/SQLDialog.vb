Imports System.ComponentModel
Imports System.Security.Principal
Imports System.Windows.Forms

Public Class SQLDialog



  Friend Class csProperties
    Implements INotifyPropertyChanged

    Friend Class Tags

      Public Shared ReadOnly DataSource As String = "DataSource"

      Public Shared ReadOnly InitialCatalog As String = "InitialCatalog"

      Public Shared ReadOnly UserName As String = "UserName"

      Public Shared ReadOnly Password As String = "Password"

      Public Shared ReadOnly IntegratedSecurity As String = "IntegratedSecurity"

      Public Shared ReadOnly DataSourceValid As String = "DataSourceValid"

      Public Shared ReadOnly UserNameEnabled As String = "UserNameEnabled"

      Public Shared ReadOnly WindowsAuthentication As String = "Windows Authentication"

      Public Shared ReadOnly SQLServerAuthentication As String = "SQL Server Authentication"

      Public Shared ReadOnly AuthenticationMode As String = "AuthenticationMode"

      Public Shared ReadOnly TestingEnabled As String = "TestingEnabled"

      Public Shared ReadOnly TestResult As String = "TestResult"
    End Class

    Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Property ConnectionStringBuilder As SqlClient.SqlConnectionStringBuilder

    Public Property DataSource As String
      Get
        Return ConnectionStringBuilder.DataSource
      End Get

      Set(ByVal value As String)
        ConnectionStringBuilder.DataSource = value
        NotifyPropertyChanged(Tags.DataSource)
        NotifyPropertyChanged(Tags.DataSourceValid)
        NotifyPropertyChanged(Tags.TestingEnabled)
        TestResult = String.Empty
      End Set
    End Property

    Public ReadOnly Property DataSourceValid As Boolean
      Get
        Return Not String.IsNullOrEmpty(DataSource)
      End Get
    End Property

    Public Property IntegratedSecurity As Boolean
      Get
        Return ConnectionStringBuilder.IntegratedSecurity
      End Get

      Set(ByVal value As Boolean)
        If value <> ConnectionStringBuilder.IntegratedSecurity Then
          ConnectionStringBuilder.IntegratedSecurity = value
          NotifyPropertyChanged(Tags.IntegratedSecurity)
          NotifyPropertyChanged(Tags.UserNameEnabled)
          NotifyPropertyChanged(Tags.AuthenticationMode)
          TestResult = String.Empty
        End If
      End Set
    End Property

    Public Property InitialCatalog As String
      Get
        Return ConnectionStringBuilder.InitialCatalog
      End Get
      Set(value As String)
        ConnectionStringBuilder.InitialCatalog = value
        NotifyPropertyChanged(Tags.InitialCatalog)
        NotifyPropertyChanged(Tags.TestingEnabled)
        TestResult = String.Empty
      End Set
    End Property

    Public Property UserName As String
      Get
        Return If(IntegratedSecurity, WindowsUserName, ConnectionStringBuilder.UserID)
      End Get

      Set(ByVal value As String)
        ConnectionStringBuilder.UserID = value
        NotifyPropertyChanged(Tags.UserName)
        TestResult = String.Empty
      End Set
    End Property

    Public Property Password As String
      Get
        Return If(IntegratedSecurity, String.Empty, ConnectionStringBuilder.Password)
      End Get

      Set(ByVal value As String)
        ConnectionStringBuilder.Password = value
        NotifyPropertyChanged(Tags.Password)
        TestResult = String.Empty
      End Set
    End Property

    Public ReadOnly Property UserNameEnabled As Boolean
      Get
        Return Not IntegratedSecurity
      End Get
    End Property

    Public Property AuthenticationMode As String
      Get
        Return If(IntegratedSecurity, Tags.WindowsAuthentication, Tags.SQLServerAuthentication)
      End Get

      Set(ByVal value As String)
        IntegratedSecurity = (value = Tags.WindowsAuthentication)
      End Set
    End Property

    Private _isTesting As Boolean = False

    Public Property IsTesting As Boolean
      Get
        Return _isTesting
      End Get

      Set(ByVal value As Boolean)
        _isTesting = value
        NotifyPropertyChanged(Tags.TestingEnabled)
      End Set
    End Property

    Public ReadOnly Property TestingEnabled As Boolean
      Get
        Return DataSourceValid AndAlso Not IsTesting
      End Get
    End Property

    Private _testResult As String = ""

    Public Property TestResult As String
      Get
        Return _testResult
      End Get

      Set(ByVal value As String)
        _testResult = value
        NotifyPropertyChanged(Tags.TestResult)
      End Set
    End Property

    Friend Property WindowsUserName As String

    Friend Sub NotifyPropertyChanged(ByVal propertyName As String)
      RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Sub New(ByVal scsb As SqlClient.SqlConnectionStringBuilder)
      ConnectionStringBuilder = scsb

      WindowsUserName = WindowsIdentity.GetCurrent().Name
    End Sub

  End Class

  Private Property FormProperties As csProperties
  Private Property slServers As SortedList(Of Int32, String)

  Private _ConnStrBuilder As SqlClient.SqlConnectionStringBuilder
  Public Property ConnStrBuilder As SqlClient.SqlConnectionStringBuilder
    Get
      Return _ConnStrBuilder
    End Get
    Private Set(value As SqlClient.SqlConnectionStringBuilder)
      _ConnStrBuilder = value
    End Set
  End Property







  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    SaveUserServer()
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub getUserServers()
    Dim bs As New BindingSource()

    bs.DataSource = Includes.clsCommon.getServers.Values

    cbDataSource.DataSource = bs
    cbDataSource.DisplayMember = "Value"

  End Sub

  Private Sub SaveUserServer()
    Dim dSer As New Dictionary(Of Int32, String)
    Dim iPos As Int32 = 1
    Dim bs As New BindingSource

    For Each sValue In cbDataSource.Items
      If dSer.ContainsValue(sValue.ToString) Then
      Else
        dSer.Add(iPos, sValue.ToString)
        iPos += 1

      End If
    Next

    Includes.clsCommon.saveServers(dSer)



  End Sub



  Sub New(ByVal scSB As SqlClient.SqlConnectionStringBuilder)
    InitializeComponent()

    If scSB Is Nothing Then
      ConnStrBuilder = New SqlClient.SqlConnectionStringBuilder() With {
        .IntegratedSecurity = True,
        .DataSource = "."
      }
    Else
      ConnStrBuilder = scSB
    End If

    FormProperties = New csProperties(scSB)

    cbDataSource.DataBindings.Add("Text", FormProperties, csProperties.Tags.DataSource, False, DataSourceUpdateMode.OnPropertyChanged)
    cbCatalog.DataBindings.Add("Text", FormProperties, csProperties.Tags.InitialCatalog, False, DataSourceUpdateMode.OnPropertyChanged)
    txtUsername.DataBindings.Add("Text", FormProperties, csProperties.Tags.UserName, False, DataSourceUpdateMode.OnPropertyChanged)
    txtPassword.DataBindings.Add("Text", FormProperties, csProperties.Tags.Password, False, DataSourceUpdateMode.OnPropertyChanged)

    txtUsername.DataBindings.Add("Enabled", FormProperties, csProperties.Tags.UserNameEnabled)
    txtPassword.DataBindings.Add("Enabled", FormProperties, csProperties.Tags.UserNameEnabled)
    lblTestResult.DataBindings.Add("Text", FormProperties, csProperties.Tags.TestResult)

    cbAuth.DataBindings.Add("Text", FormProperties, csProperties.Tags.AuthenticationMode, False, DataSourceUpdateMode.OnPropertyChanged)

    getUserServers()

  End Sub

  Private Sub UpdateCatalogList()
    Dim lstCatalog As New List(Of String)
    Dim dbGlobal As New Includes.clsDBGlobal(ConnStrBuilder.ConnectionString)
    Dim bs As New BindingSource

    Try
      Using oleRdr As SqlClient.SqlDataReader = dbGlobal.Get_Available_DBs()

        While oleRdr.Read()
          lstCatalog.Add(oleRdr.GetString(0))
        End While
      End Using

      bs.DataSource = lstCatalog

      cbCatalog.DataSource = bs

    Catch ex As Exception

    End Try


  End Sub

  Private Sub TestConnection()
    Using dbConn As New SqlClient.SqlConnection(ConnStrBuilder.ConnectionString)

      Try
        FormProperties.IsTesting = True
        FormProperties.TestResult = "Testing..."
        dbConn.Open()
        FormProperties.TestResult = "Success!"
      Catch ex As Exception
        FormProperties.TestResult = ex.Message
      Finally
        FormProperties.IsTesting = False
      End Try


    End Using

  End Sub

  Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
    TestConnection()
  End Sub

  Private Sub btnList_Click(sender As Object, e As EventArgs) Handles btnList.Click
    UpdateCatalogList()
  End Sub
End Class
