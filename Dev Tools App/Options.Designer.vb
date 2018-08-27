<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options
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
    Me.btnSave = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.txtRemoveNullsFuncName = New System.Windows.Forms.TextBox()
    Me.txtSendNullsFuncName = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.txtServerNames = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.btnReset = New System.Windows.Forms.Button()
    Me.txtConnStrings = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.cbxLanguage = New System.Windows.Forms.ComboBox()
    Me.SuspendLayout()
    '
    'btnSave
    '
    Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnSave.Location = New System.Drawing.Point(527, 415)
    Me.btnSave.Name = "btnSave"
    Me.btnSave.Size = New System.Drawing.Size(75, 23)
    Me.btnSave.TabIndex = 0
    Me.btnSave.Text = "Save"
    Me.btnSave.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(13, 13)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(156, 13)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Make changes to settings here,"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(16, 84)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(148, 13)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "Remove Nulls Function Name"
    '
    'txtRemoveNullsFuncName
    '
    Me.txtRemoveNullsFuncName.Location = New System.Drawing.Point(217, 81)
    Me.txtRemoveNullsFuncName.Name = "txtRemoveNullsFuncName"
    Me.txtRemoveNullsFuncName.Size = New System.Drawing.Size(245, 20)
    Me.txtRemoveNullsFuncName.TabIndex = 4
    '
    'txtSendNullsFuncName
    '
    Me.txtSendNullsFuncName.Location = New System.Drawing.Point(217, 112)
    Me.txtSendNullsFuncName.Name = "txtSendNullsFuncName"
    Me.txtSendNullsFuncName.Size = New System.Drawing.Size(245, 20)
    Me.txtSendNullsFuncName.TabIndex = 6
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(16, 115)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(133, 13)
    Me.Label3.TabIndex = 5
    Me.Label3.Text = "Send Nulls Function Name"
    '
    'txtServerNames
    '
    Me.txtServerNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtServerNames.Location = New System.Drawing.Point(217, 149)
    Me.txtServerNames.Multiline = True
    Me.txtServerNames.Name = "txtServerNames"
    Me.txtServerNames.Size = New System.Drawing.Size(391, 57)
    Me.txtServerNames.TabIndex = 8
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(16, 149)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(195, 13)
    Me.Label4.TabIndex = 7
    Me.Label4.Text = "DB Server Names (Seperate with Pipes)"
    '
    'btnReset
    '
    Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.btnReset.Location = New System.Drawing.Point(12, 415)
    Me.btnReset.Name = "btnReset"
    Me.btnReset.Size = New System.Drawing.Size(96, 23)
    Me.btnReset.TabIndex = 9
    Me.btnReset.Text = "Reset to Default"
    Me.btnReset.UseVisualStyleBackColor = True
    '
    'txtConnStrings
    '
    Me.txtConnStrings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtConnStrings.Location = New System.Drawing.Point(217, 218)
    Me.txtConnStrings.Multiline = True
    Me.txtConnStrings.Name = "txtConnStrings"
    Me.txtConnStrings.Size = New System.Drawing.Size(391, 109)
    Me.txtConnStrings.TabIndex = 11
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(16, 218)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(194, 13)
    Me.Label5.TabIndex = 10
    Me.Label5.Text = "Connection String (Seperate with Pipes)"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(16, 57)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(92, 13)
    Me.Label6.TabIndex = 12
    Me.Label6.Text = "Default Language"
    '
    'cbxLanguage
    '
    Me.cbxLanguage.FormattingEnabled = True
    Me.cbxLanguage.Items.AddRange(New Object() {"C#", "VB.Net"})
    Me.cbxLanguage.Location = New System.Drawing.Point(217, 48)
    Me.cbxLanguage.Name = "cbxLanguage"
    Me.cbxLanguage.Size = New System.Drawing.Size(121, 21)
    Me.cbxLanguage.TabIndex = 13
    '
    'Options
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(620, 450)
    Me.Controls.Add(Me.cbxLanguage)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.txtConnStrings)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.btnReset)
    Me.Controls.Add(Me.txtServerNames)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.txtSendNullsFuncName)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtRemoveNullsFuncName)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.btnSave)
    Me.Name = "Options"
    Me.Text = "Options"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents btnSave As Button
  Friend WithEvents Label1 As Label
  Friend WithEvents Label2 As Label
  Friend WithEvents txtRemoveNullsFuncName As TextBox
  Friend WithEvents txtSendNullsFuncName As TextBox
  Friend WithEvents Label3 As Label
  Friend WithEvents txtServerNames As TextBox
  Friend WithEvents Label4 As Label
  Friend WithEvents btnReset As Button
  Friend WithEvents txtConnStrings As TextBox
  Friend WithEvents Label5 As Label
  Friend WithEvents Label6 As Label
  Friend WithEvents cbxLanguage As ComboBox
End Class
