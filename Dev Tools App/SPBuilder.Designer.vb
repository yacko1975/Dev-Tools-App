<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SPBuilder
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
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.btnBuild = New System.Windows.Forms.Button()
    Me.btnReset = New System.Windows.Forms.Button()
    Me.btnCopy = New System.Windows.Forms.Button()
    Me.txtCode = New System.Windows.Forms.TextBox()
    Me.cbxLanguage = New System.Windows.Forms.ComboBox()
    Me.txtProc = New System.Windows.Forms.TextBox()
    Me.clbOptions = New System.Windows.Forms.CheckedListBox()
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
    Me.Label1.Location = New System.Drawing.Point(13, 22)
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
    Me.Label2.Location = New System.Drawing.Point(10, 52)
    Me.Label2.Name = "Label2"
    Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
    Me.Label2.Size = New System.Drawing.Size(94, 13)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "Stored Proc Name"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(61, 83)
    Me.Label3.Name = "Label3"
    Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
    Me.Label3.Size = New System.Drawing.Size(43, 13)
    Me.Label3.TabIndex = 7
    Me.Label3.Text = "Options"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(509, 83)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(55, 13)
    Me.Label4.TabIndex = 9
    Me.Label4.Text = "Language"
    '
    'btnBuild
    '
    Me.btnBuild.Location = New System.Drawing.Point(572, 184)
    Me.btnBuild.Name = "btnBuild"
    Me.btnBuild.Size = New System.Drawing.Size(75, 23)
    Me.btnBuild.TabIndex = 11
    Me.btnBuild.Text = "Build"
    Me.btnBuild.UseVisualStyleBackColor = True
    '
    'btnReset
    '
    Me.btnReset.Location = New System.Drawing.Point(653, 184)
    Me.btnReset.Name = "btnReset"
    Me.btnReset.Size = New System.Drawing.Size(75, 23)
    Me.btnReset.TabIndex = 12
    Me.btnReset.Text = "Reset"
    Me.btnReset.UseVisualStyleBackColor = True
    '
    'btnCopy
    '
    Me.btnCopy.Location = New System.Drawing.Point(734, 184)
    Me.btnCopy.Name = "btnCopy"
    Me.btnCopy.Size = New System.Drawing.Size(75, 23)
    Me.btnCopy.TabIndex = 13
    Me.btnCopy.Text = "Copy"
    Me.btnCopy.UseVisualStyleBackColor = True
    '
    'txtCode
    '
    Me.txtCode.Location = New System.Drawing.Point(10, 258)
    Me.txtCode.Multiline = True
    Me.txtCode.Name = "txtCode"
    Me.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.txtCode.Size = New System.Drawing.Size(848, 296)
    Me.txtCode.TabIndex = 14
    '
    'cbxLanguage
    '
    Me.cbxLanguage.AutoCompleteCustomSource.AddRange(New String() {"C#", "VB.Net"})
    Me.cbxLanguage.FormattingEnabled = True
    Me.cbxLanguage.Items.AddRange(New Object() {"C#", "VB.Net", "C# Dapper"})
    Me.cbxLanguage.Location = New System.Drawing.Point(572, 80)
    Me.cbxLanguage.Name = "cbxLanguage"
    Me.cbxLanguage.Size = New System.Drawing.Size(121, 21)
    Me.cbxLanguage.TabIndex = 18
    '
    'txtProc
    '
    Me.txtProc.Location = New System.Drawing.Point(110, 51)
    Me.txtProc.Name = "txtProc"
    Me.txtProc.Size = New System.Drawing.Size(583, 20)
    Me.txtProc.TabIndex = 19
    '
    'clbOptions
    '
    Me.clbOptions.FormattingEnabled = True
    Me.clbOptions.Items.AddRange(New Object() {"Include Exception Handling", "This function returns a data reader", "Remove Nulls from output using KDOR.clsdbfunctions.RemoveNulls", "Pass Nulls using KDOR.clsdbfunctions.SendNulls", "Use Local Variables based on the table for variables", "Use Type Class Generated on a table for variables", "Use private connection string (_ConnectionString)", "Create the entire class, not just the function", "Use Transactions in the Generated Code", "Use Global Connection in the Generated Code", "Use Optional Arguements for Inputs"})
    Me.clbOptions.Location = New System.Drawing.Point(110, 83)
    Me.clbOptions.Name = "clbOptions"
    Me.clbOptions.Size = New System.Drawing.Size(373, 169)
    Me.clbOptions.TabIndex = 20
    '
    'SPBuilder
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(858, 576)
    Me.Controls.Add(Me.clbOptions)
    Me.Controls.Add(Me.txtProc)
    Me.Controls.Add(Me.cbxLanguage)
    Me.Controls.Add(Me.txtCode)
    Me.Controls.Add(Me.btnCopy)
    Me.Controls.Add(Me.btnReset)
    Me.Controls.Add(Me.btnBuild)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.btnCreateConnStr)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtConnString)
    Me.Name = "SPBuilder"
    Me.Text = "Create .Net Stored Proc Call"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents txtConnString As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents btnCreateConnStr As Button
  Friend WithEvents Label2 As Label
  Friend WithEvents Label3 As Label
  Friend WithEvents Label4 As Label
  Friend WithEvents btnBuild As Button
  Friend WithEvents btnReset As Button
  Friend WithEvents btnCopy As Button
  Friend WithEvents txtCode As TextBox
  Friend WithEvents cbxLanguage As ComboBox
  Friend WithEvents txtProc As TextBox
  Friend WithEvents clbOptions As CheckedListBox
End Class
