<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SPBuild
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
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
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Me.txtConnString = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.btnCreateConnStr = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.cbxTable = New System.Windows.Forms.ComboBox()
    Me.btnRefreshTbl = New System.Windows.Forms.Button()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.clbType = New System.Windows.Forms.CheckedListBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.clbOptions = New System.Windows.Forms.CheckedListBox()
    Me.btnBuild = New System.Windows.Forms.Button()
    Me.btnReset = New System.Windows.Forms.Button()
    Me.btnCopy = New System.Windows.Forms.Button()
    Me.txtCode = New System.Windows.Forms.TextBox()
    Me.cbxUser = New System.Windows.Forms.ComboBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'txtConnString
    '
    Me.txtConnString.Location = New System.Drawing.Point(110, 22)
    Me.txtConnString.Name = "txtConnString"
    Me.txtConnString.Size = New System.Drawing.Size(582, 20)
    Me.txtConnString.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(13, 29)
    Me.Label1.Name = "Label1"
    Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
    Me.Label1.Size = New System.Drawing.Size(91, 13)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Connection String"
    '
    'btnCreateConnStr
    '
    Me.btnCreateConnStr.Location = New System.Drawing.Point(699, 18)
    Me.btnCreateConnStr.Name = "btnCreateConnStr"
    Me.btnCreateConnStr.Size = New System.Drawing.Size(147, 23)
    Me.btnCreateConnStr.TabIndex = 2
    Me.btnCreateConnStr.Text = "Create Connection String"
    Me.btnCreateConnStr.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(32, 54)
    Me.Label2.Name = "Label2"
    Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
    Me.Label2.Size = New System.Drawing.Size(72, 13)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "Table or View"
    '
    'cbxTable
    '
    Me.cbxTable.FormattingEnabled = True
    Me.cbxTable.Location = New System.Drawing.Point(110, 49)
    Me.cbxTable.Name = "cbxTable"
    Me.cbxTable.Size = New System.Drawing.Size(582, 21)
    Me.cbxTable.TabIndex = 4
    '
    'btnRefreshTbl
    '
    Me.btnRefreshTbl.Location = New System.Drawing.Point(699, 49)
    Me.btnRefreshTbl.Name = "btnRefreshTbl"
    Me.btnRefreshTbl.Size = New System.Drawing.Size(147, 23)
    Me.btnRefreshTbl.TabIndex = 5
    Me.btnRefreshTbl.Text = "Refresh Tables"
    Me.btnRefreshTbl.UseVisualStyleBackColor = True
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(73, 77)
    Me.Label3.Name = "Label3"
    Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
    Me.Label3.Size = New System.Drawing.Size(31, 13)
    Me.Label3.TabIndex = 7
    Me.Label3.Text = "Type"
    '
    'clbType
    '
    Me.clbType.FormattingEnabled = True
    Me.clbType.Items.AddRange(New Object() {"Select Single Record", "Select All Records", "Insert", "Update", "Delete"})
    Me.clbType.Location = New System.Drawing.Point(111, 77)
    Me.clbType.Name = "clbType"
    Me.clbType.Size = New System.Drawing.Size(200, 79)
    Me.clbType.TabIndex = 8
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(317, 77)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(43, 13)
    Me.Label4.TabIndex = 9
    Me.Label4.Text = "Options"
    '
    'clbOptions
    '
    Me.clbOptions.FormattingEnabled = True
    Me.clbOptions.Items.AddRange(New Object() {"Archived Table", "Output to History Table"})
    Me.clbOptions.Location = New System.Drawing.Point(366, 77)
    Me.clbOptions.Name = "clbOptions"
    Me.clbOptions.Size = New System.Drawing.Size(212, 79)
    Me.clbOptions.TabIndex = 10
    '
    'btnBuild
    '
    Me.btnBuild.Location = New System.Drawing.Point(609, 133)
    Me.btnBuild.Name = "btnBuild"
    Me.btnBuild.Size = New System.Drawing.Size(75, 23)
    Me.btnBuild.TabIndex = 11
    Me.btnBuild.Text = "Build"
    Me.btnBuild.UseVisualStyleBackColor = True
    '
    'btnReset
    '
    Me.btnReset.Location = New System.Drawing.Point(690, 133)
    Me.btnReset.Name = "btnReset"
    Me.btnReset.Size = New System.Drawing.Size(75, 23)
    Me.btnReset.TabIndex = 12
    Me.btnReset.Text = "Reset"
    Me.btnReset.UseVisualStyleBackColor = True
    '
    'btnCopy
    '
    Me.btnCopy.Location = New System.Drawing.Point(771, 133)
    Me.btnCopy.Name = "btnCopy"
    Me.btnCopy.Size = New System.Drawing.Size(75, 23)
    Me.btnCopy.TabIndex = 13
    Me.btnCopy.Text = "Copy"
    Me.btnCopy.UseVisualStyleBackColor = True
    '
    'txtCode
    '
    Me.txtCode.Location = New System.Drawing.Point(4, 193)
    Me.txtCode.Multiline = True
    Me.txtCode.Name = "txtCode"
    Me.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.txtCode.Size = New System.Drawing.Size(854, 361)
    Me.txtCode.TabIndex = 14
    '
    'cbxUser
    '
    Me.cbxUser.FormattingEnabled = True
    Me.cbxUser.Location = New System.Drawing.Point(609, 97)
    Me.cbxUser.Name = "cbxUser"
    Me.cbxUser.Size = New System.Drawing.Size(237, 21)
    Me.cbxUser.TabIndex = 15
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(609, 77)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(38, 13)
    Me.Label5.TabIndex = 16
    Me.Label5.Text = "Owner"
    '
    'SPBuild
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(858, 576)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.cbxUser)
    Me.Controls.Add(Me.txtCode)
    Me.Controls.Add(Me.btnCopy)
    Me.Controls.Add(Me.btnReset)
    Me.Controls.Add(Me.btnBuild)
    Me.Controls.Add(Me.clbOptions)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.clbType)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.btnRefreshTbl)
    Me.Controls.Add(Me.cbxTable)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.btnCreateConnStr)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtConnString)
    Me.Name = "SPBuild"
    Me.Text = "Build Stored Procedure"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents txtConnString As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents btnCreateConnStr As Button
  Friend WithEvents Label2 As Label
  Friend WithEvents cbxTable As ComboBox
  Friend WithEvents btnRefreshTbl As Button
  Friend WithEvents Label3 As Label
  Friend WithEvents clbType As CheckedListBox
  Friend WithEvents Label4 As Label
  Friend WithEvents clbOptions As CheckedListBox
  Friend WithEvents btnBuild As Button
  Friend WithEvents btnReset As Button
  Friend WithEvents btnCopy As Button
  Friend WithEvents txtCode As TextBox
  Friend WithEvents cbxUser As ComboBox
  Friend WithEvents Label5 As Label
End Class
