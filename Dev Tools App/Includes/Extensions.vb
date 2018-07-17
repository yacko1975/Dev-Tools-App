Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions

Namespace Extensions

  Module Extensions

    <Extension()>
    Public Function FormatWith(ByVal format As String, ParamArray args As Object()) As String
      If format Is Nothing Then Throw New ArgumentNullException("format")
      Return String.Format(format, args)
    End Function

    <Extension()>
    Public Function FormatWith(ByVal format As String, ByVal provider As IFormatProvider, ParamArray args As Object()) As String
      If format Is Nothing Then Throw New ArgumentNullException("format")
      Return String.Format(provider, format, args)
    End Function

    <Extension()>
    Public Function SetFlags(value As [Enum], ParamArray flags() As [Enum]) As [Enum]
      If flags.Length = 0 Then Throw New Exception("Please send at least one flag")
      For Each flag In flags
        value = CObj(value) Or CObj(flag)
      Next
      Return value
    End Function

    <Extension()>
    Public Function RemoveFlags(value As [Enum], ParamArray flags() As [Enum]) As [Enum]
      If flags.Length = 0 Then Throw New Exception("Please send at least one flag")
      For Each flag In flags
        value = CObj(value) And Not CObj(flag)
      Next
      Return value
    End Function

    <Extension()>
    Public Function IsSet(value As [Enum], flag As [Enum]) As Boolean
      Return value.HasFlag(flag)
    End Function

    <Extension()>
    Public Function IsAnySet(value As [Enum], ParamArray flags() As [Enum]) As Boolean
      For Each flag In flags
        If value.HasFlag(flag) Then
          Return True
        End If
      Next
      Return False
    End Function

    <Extension()>
    Public Function IsAllSet(value As [Enum], ParamArray flags() As [Enum]) As Boolean
      For Each flag In flags
        If value.HasFlag(flag) Then
        Else
          Return False
        End If
      Next
      Return True
    End Function

  End Module


End Namespace
