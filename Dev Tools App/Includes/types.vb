Imports System

Namespace Includes.Types

  Public Class TableFmt
    Public sConnString As String
    Public sServer As String
    Public sDatabase As String
    Public sTable As String
    Public aylPrimaryKey As ArrayList
    Public aylColumn As ArrayList
    Public sFormType As String
    Public sForm As String
    Public sTypeClass As String
    Public sCode As String
    Public bInfo As Boolean
    Public bProperties As Boolean
    Public bPropertiesOnly As Boolean
    Public sSQL As String
    Public Action As Int32
    Public FormOptions As Int32
    Public bPermission As Boolean
    Public bIncludeClassDefinition As Boolean
    Public bIncludeRegion As Boolean
    Public sUsername As String
    Public bArchived As Boolean = False
    Public bUsePrivate As Boolean = False
    Public Language As enLanguage = enLanguage.VB
    Public SPOptions As CallBuilder
    Private sSPName As String
    Public User As String
    Public sSchema As String
    Public DataAnnotations As enDataAnnotationFlags


    Public ReadOnly Property FullSPName As String
      Get
        If String.IsNullOrWhiteSpace(sSchema) Then
          Return "[dbo].{0}".FormatWith(sSPName)
        Else
          Return "{0}.{1}".FormatWith(sSchema, sSPName)
        End If
      End Get
    End Property

    Public ReadOnly Property FullTableName As String
      Get
        If String.IsNullOrWhiteSpace(sSchema) Then
          Return "[dbo].{0}".FormatWith(sTable)
        Else
          Return "{0}.{1}".FormatWith(sSchema, sTable)
        End If
      End Get
    End Property

    Public Property Schema As String
      Get
        Return sSchema
      End Get
      Set(value As String)
        sSchema = value
      End Set
    End Property


    Public Property SPName As String
      Get
        Return sSPName
      End Get
      Set(value As String)
        Dim asParts() As String
        Dim _sName As String

        If value.Contains(".") Then
          asParts = value.Split(".")
          _sName = asParts.Last
          sSchema = asParts.First.Replace("[", String.Empty).Replace("]", String.Empty)
        Else
          _sName = value
          sSchema = "dbo"
        End If

        sSPName = _sName.Replace("[", String.Empty).Replace("]", String.Empty).Trim

      End Set
    End Property

    Public Function SPNameOnly() As String
      Dim lParts As List(Of String)

      If sSPName.Contains(".") Then
        lParts = sSPName.Split(".").ToList
        Return lParts.Last
      Else
        Return sSPName
      End If

    End Function


    Public Function isAnyOptionSet(ByVal ParamArray BuildOptions() As CallBuilder) As Boolean

      For Each BuildOption As CallBuilder In BuildOptions
        If (SPOptions And BuildOption) = BuildOption Then
          Return True
        Else
          'Not Set Try the next one
        End If
      Next
      'None were false so entire thing is False
      Return False

    End Function

    Public Function isAllOptionSet(ByVal ParamArray BuildOptions() As CallBuilder) As Boolean
      For Each BuildOption As CallBuilder In BuildOptions
        If (SPOptions And BuildOption) = BuildOption Then
          'Value is true continue
        Else
          Return False
        End If
      Next
      'None were false so entire thing is true
      Return True
    End Function

    Public Sub addOption(ByVal ParamArray BuildOptions() As CallBuilder)
      For Each BuildOption As CallBuilder In BuildOptions
        SPOptions = SPOptions Or BuildOption
      Next
    End Sub

  End Class

  Public Class ColumnFmt
    Public sColumnName As String
    Public bColumnPK As Boolean
    Public sColumnType As String
    Public iColumnLength As Int32
    Public iColumnPrecision As Int32
    Public iColumnScale As Int32
    Public bColumnIdentity As Boolean
    Public bNullable As Boolean

    'Added by Theo; 02/06/2017
    Public sTableOwner As String
  End Class

  Public Enum enLanguage
    VB = 1
    CS = 2
  End Enum

  Public Enum Action
    Select_One = 16
    Select_All = 1
    Insert = 2
    Update = 4
    Delete = 8
  End Enum

  Public Enum enuFormOptions
    FieldSet = 1
    ValidationSummary = 2
    Tips = 4
    Submit = 8
    Cancel = 16
    Edit = 32
    Delete = 64
    YesNo = 128
  End Enum


  <Flags()>
  Public Enum enDataAnnotationFlags
    Display = 1
    Required = 2
    Format = 4
    Validation = 8
  End Enum

  <Serializable()>
  Public Class clsStoredProc
    Public sName As String
    Public bDataReader As Boolean
    Public bRemoveNulls As Boolean
    Public bPassNulls As Boolean
    Public bPassOptArg As Boolean
    Public bUseTransaction As Boolean
    Public bGlobalConn As Boolean


    Public Sub New(ByVal Name As String)
      sName = Name
    End Sub

    Public Property Name() As String
      Get
        Return sName
      End Get
      Set(ByVal value As String)
        sName = value
      End Set
    End Property

    Public Property DataReader() As Boolean
      Get
        Return bDataReader
      End Get
      Set(ByVal value As Boolean)
        bDataReader = value
      End Set
    End Property

    Public Property PassOptArg() As Boolean
      Get
        Return bPassOptArg
      End Get
      Set(ByVal value As Boolean)
        bPassOptArg = value
      End Set
    End Property

    Public Property RemoveNulls() As Boolean
      Get
        Return bRemoveNulls
      End Get
      Set(ByVal value As Boolean)
        bRemoveNulls = value
      End Set
    End Property

    Public Property PassNulls() As Boolean
      Get
        Return bPassNulls
      End Get
      Set(ByVal value As Boolean)
        bPassNulls = value
      End Set
    End Property

    Public Property GlobalConn() As Boolean
      Get
        Return bGlobalConn
      End Get
      Set(ByVal value As Boolean)
        bGlobalConn = value
      End Set
    End Property

    Public Property UseTransaction() As Boolean
      Get
        Return bUseTransaction
      End Get
      Set(ByVal value As Boolean)
        bUseTransaction = value
      End Set
    End Property

  End Class

  <Flags()>
  Public Enum CallBuilder As Integer
    ExceptionHandling = 1
    DataReader = 2
    'OpenConnection = 4
    RemoveNulls = 8
    SendNulls = 16
    DotNetV2 = 32
    TableCls = 64
    UseLocal = 128
    PrivateConnectionString = 256
    CreateNewClass = 512
    CreateOptionalArgument = 1024
    UseTransaction = 2048
    UseGlobalConnection = 4096
    UseArchive = 8192
    UseOutput = 16384
  End Enum

  Public Enum enApp_Roles
    Home = 1
    Applications = 2
    Groups = 3
    AppRoles = 4
  End Enum

  Public Enum enSaveModes
    Add = 0
    Save = 1
  End Enum


End Namespace