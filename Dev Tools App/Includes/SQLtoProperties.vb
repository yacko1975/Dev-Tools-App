Imports System.Data
Imports System.Data.OleDb
Imports System.Text
Imports Dev_Tools_App.Includes.Types


Namespace Includes

  Public Class clsSQLtoProperties

    Private _ConnectionString As String

    Public Function CreateProperties(ByRef TableRec As Includes.Types.TableFmt) As String
      Dim DB As New clsDBGlobal(_ConnectionString)
      Dim sb As New StringBuilder

      TableRec.aylColumn = DB.Get_Columns_From_SQL(TableRec.sSQL)

      For Each Col In TableRec.aylColumn

        sb.Append(processCol(Col, TableRec.DataAnnotations))

      Next

      Return sb.ToString

    End Function






    Private Function processCol(ByRef col As Types.ColumnFmt, ByVal iFlags As enDataAnnotationFlags) As String
      Dim sb As New StringBuilder
      Dim iMax, iMin As Int64

      If iFlags.HasFlag(enDataAnnotationFlags.Display) Then
        sb.AppendFormat("[Display(Description = ""{0}"", ShortName = ""{0}"")]", col.sColumnName)
        sb.AppendLine()
      End If

      If iFlags.HasFlag(enDataAnnotationFlags.Required) Then
        sb.AppendFormat("[Required(ErrorMessage = ""Value for {0} is required"")]", col.sColumnName)
        sb.AppendLine()
      End If

      If iFlags.HasFlag(enDataAnnotationFlags.Validation) Then
        Select Case col.sColumnType.ToLower
          Case "decimal", "double", "single", "double"
            sb.AppendLine("//[Range( 0.01, 100.00, ErrorMessage =""Value for {0} must be between {1} And {2}"")]")
            sb.AppendLine("[RegularExpression(@""^-?((\d{1,8}(\.\d{1,2})?)|(\.\d{1,2}))$"", ErrorMessage =""Value for {0} is not correctly formatted"")]")
          Case "int32", "int16", "byte", "int64"
            Select Case col.sColumnType
              Case "byte"
                iMax = 256
                iMin = 0
              Case "int16"
                iMax = Int16.MaxValue
                iMin = Int16.MinValue
              Case "int64"
                iMax = Int64.MaxValue
                iMin = Int64.MinValue
              Case Else
                iMax = Integer.MaxValue
                iMin = Integer.MinValue
            End Select
            sb.Append("[Range(")
            sb.Append(iMin)
            sb.Append(",")
            sb.Append(iMax)
            sb.AppendLine(",ErrorMessage =""Value for {0} must be between {1} And {2}"")]")

          Case "string"
            iMax = col.iColumnLength
            If iMax < 0 Then
              iMax = Integer.MaxValue
            End If
            sb.AppendLine("//[DataType(DataType.EmailAddress)] // Others Available based on type")
            sb.Append("[StringLength(")
            sb.Append(iMax)
            sb.AppendLine(", ErrorMessage = ""{0} can Not be longer than {1}"")]")

          Case "datetime"
            sb.AppendLine("//[Range(typeof(DateTime), ""01/01/1999"",""12/31/2099"",ErrorMessage =""Value for {0} must be between {1} And {2}"")]")
            sb.AppendLine("[DataType(DataType.DateTime)]")
          Case Else
            'Do nothing for DLL's
        End Select
      End If

      If iFlags.HasFlag(enDataAnnotationFlags.Format) Then
        Select Case col.sColumnType.ToLower
          Case "decimal"
            sb.AppendLine("[DisplayFormat(DataFormatString=""{0:C}"", ApplyFormatInEditMode = false )]")
          Case "int32", "int16", "byte", "int64"
            sb.AppendLine("[DisplayFormat(DataFormatString=""{0:d}"", ApplyFormatInEditMode = false)]")
          Case "Date"
            sb.AppendLine("[DisplayFormat(DataFormatString=""{0:MM/dd/yyyy}"", ApplyFormatInEditMode = false)]")
          Case "datetime"
            sb.AppendLine("//[DisplayFormat(DataFormatString=""{0:MM/dd/yyyy}"", ApplyFormatInEditMode = false)]")
          Case Else

        End Select
      End If

      sb.Append("public ")
      sb.Append(col.sColumnType)
      sb.Append(" ")
      sb.Append(col.sColumnName)
      sb.AppendLine(" { get; set; }")
      sb.AppendLine()

      Return sb.ToString


    End Function

    Public Sub New(ByVal strDatabase As String, ByVal sConnectionString As String)
      _ConnectionString = String.Format(sConnectionString, strDatabase)
    End Sub

  End Class

End Namespace