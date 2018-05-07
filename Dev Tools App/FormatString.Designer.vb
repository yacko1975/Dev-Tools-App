<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormatString
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.txtFormat = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.txtCSVData = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.txtSeparator = New System.Windows.Forms.TextBox()
    Me.cbxSingleLine = New System.Windows.Forms.CheckBox()
    Me.btnGenerate = New System.Windows.Forms.Button()
    Me.btnClear = New System.Windows.Forms.Button()
    Me.btnCopy = New System.Windows.Forms.Button()
    Me.txtResults = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'txtFormat
    '
    Me.txtFormat.Location = New System.Drawing.Point(12, 29)
    Me.txtFormat.Multiline = True
    Me.txtFormat.Name = "txtFormat"
    Me.txtFormat.Size = New System.Drawing.Size(824, 74)
    Me.txtFormat.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(13, 13)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(173, 13)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Format String Used to Create String"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(13, 110)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(170, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "CSV Data to used to create strings"
    '
    'txtCSVData
    '
    Me.txtCSVData.Location = New System.Drawing.Point(16, 127)
    Me.txtCSVData.Multiline = True
    Me.txtCSVData.Name = "txtCSVData"
    Me.txtCSVData.Size = New System.Drawing.Size(820, 128)
    Me.txtCSVData.TabIndex = 3
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(16, 262)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(94, 13)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Element Separator"
    '
    'txtSeparator
    '
    Me.txtSeparator.Location = New System.Drawing.Point(117, 262)
    Me.txtSeparator.Name = "txtSeparator"
    Me.txtSeparator.Size = New System.Drawing.Size(100, 20)
    Me.txtSeparator.TabIndex = 5
    '
    'cbxSingleLine
    '
    Me.cbxSingleLine.AutoSize = True
    Me.cbxSingleLine.Location = New System.Drawing.Point(256, 264)
    Me.cbxSingleLine.Name = "cbxSingleLine"
    Me.cbxSingleLine.Size = New System.Drawing.Size(112, 17)
    Me.cbxSingleLine.TabIndex = 7
    Me.cbxSingleLine.Text = "Create Single Line"
    Me.cbxSingleLine.UseVisualStyleBackColor = True
    '
    'btnGenerate
    '
    Me.btnGenerate.Location = New System.Drawing.Point(539, 264)
    Me.btnGenerate.Name = "btnGenerate"
    Me.btnGenerate.Size = New System.Drawing.Size(75, 23)
    Me.btnGenerate.TabIndex = 8
    Me.btnGenerate.Text = "Generate"
    Me.btnGenerate.UseVisualStyleBackColor = True
    '
    'btnClear
    '
    Me.btnClear.Location = New System.Drawing.Point(620, 264)
    Me.btnClear.Name = "btnClear"
    Me.btnClear.Size = New System.Drawing.Size(75, 23)
    Me.btnClear.TabIndex = 9
    Me.btnClear.Text = "Clear"
    Me.btnClear.UseVisualStyleBackColor = True
    '
    'btnCopy
    '
    Me.btnCopy.Location = New System.Drawing.Point(701, 264)
    Me.btnCopy.Name = "btnCopy"
    Me.btnCopy.Size = New System.Drawing.Size(135, 23)
    Me.btnCopy.TabIndex = 10
    Me.btnCopy.Text = "Copy To Clipboard"
    Me.btnCopy.UseVisualStyleBackColor = True
    '
    'txtResults
    '
    Me.txtResults.Location = New System.Drawing.Point(19, 300)
    Me.txtResults.Multiline = True
    Me.txtResults.Name = "txtResults"
    Me.txtResults.Size = New System.Drawing.Size(817, 269)
    Me.txtResults.TabIndex = 11
    '
    'FormatString
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(848, 581)
    Me.Controls.Add(Me.txtResults)
    Me.Controls.Add(Me.btnCopy)
    Me.Controls.Add(Me.btnClear)
    Me.Controls.Add(Me.btnGenerate)
    Me.Controls.Add(Me.cbxSingleLine)
    Me.Controls.Add(Me.txtSeparator)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtCSVData)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtFormat)
    Me.Name = "FormatString"
    Me.Text = "FormatString"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents txtFormat As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents Label2 As Label
  Friend WithEvents txtCSVData As TextBox
  Friend WithEvents Label3 As Label
  Friend WithEvents txtSeparator As TextBox
  Friend WithEvents cbxSingleLine As CheckBox
  Friend WithEvents btnGenerate As Button
  Friend WithEvents btnClear As Button
  Friend WithEvents btnCopy As Button
  Friend WithEvents txtResults As TextBox
End Class
