<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SQLDialog
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
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
    Me.OK_Button = New System.Windows.Forms.Button()
    Me.Cancel_Button = New System.Windows.Forms.Button()
    Me.btnTest = New System.Windows.Forms.Button()
    Me.cbDataSource = New System.Windows.Forms.ComboBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.cbCatalog = New System.Windows.Forms.ComboBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.cbAuth = New System.Windows.Forms.ComboBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.txtUsername = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.txtPassword = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.btnList = New System.Windows.Forms.Button()
    Me.lblTestResult = New System.Windows.Forms.Label()
    Me.TableLayoutPanel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 274)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'OK_Button
    '
    Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.OK_Button.Location = New System.Drawing.Point(3, 3)
    Me.OK_Button.Name = "OK_Button"
    Me.OK_Button.Size = New System.Drawing.Size(67, 23)
    Me.OK_Button.TabIndex = 0
    Me.OK_Button.Text = "Save"
    '
    'Cancel_Button
    '
    Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "Cancel"
    '
    'btnTest
    '
    Me.btnTest.Location = New System.Drawing.Point(13, 276)
    Me.btnTest.Name = "btnTest"
    Me.btnTest.Size = New System.Drawing.Size(75, 23)
    Me.btnTest.TabIndex = 1
    Me.btnTest.Text = "Test Connection"
    Me.btnTest.UseVisualStyleBackColor = True
    '
    'cbDataSource
    '
    Me.cbDataSource.FormattingEnabled = True
    Me.cbDataSource.Location = New System.Drawing.Point(117, 13)
    Me.cbDataSource.Name = "cbDataSource"
    Me.cbDataSource.Size = New System.Drawing.Size(303, 21)
    Me.cbDataSource.TabIndex = 2
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(19, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(69, 13)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Server Name"
    '
    'cbCatalog
    '
    Me.cbCatalog.FormattingEnabled = True
    Me.cbCatalog.Location = New System.Drawing.Point(117, 160)
    Me.cbCatalog.Name = "cbCatalog"
    Me.cbCatalog.Size = New System.Drawing.Size(230, 21)
    Me.cbCatalog.TabIndex = 4
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(19, 163)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(84, 13)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "Database Name"
    '
    'cbAuth
    '
    Me.cbAuth.FormattingEnabled = True
    Me.cbAuth.Items.AddRange(New Object() {"Windows Authentication", "SQL Server Authentication"})
    Me.cbAuth.Location = New System.Drawing.Point(117, 40)
    Me.cbAuth.Name = "cbAuth"
    Me.cbAuth.Size = New System.Drawing.Size(303, 21)
    Me.cbAuth.TabIndex = 6
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(19, 43)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(75, 13)
    Me.Label3.TabIndex = 7
    Me.Label3.Text = "Authentication"
    '
    'txtUsername
    '
    Me.txtUsername.Location = New System.Drawing.Point(169, 67)
    Me.txtUsername.Name = "txtUsername"
    Me.txtUsername.Size = New System.Drawing.Size(251, 20)
    Me.txtUsername.TabIndex = 8
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(101, 70)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(60, 13)
    Me.Label4.TabIndex = 9
    Me.Label4.Text = "User Name"
    '
    'txtPassword
    '
    Me.txtPassword.Location = New System.Drawing.Point(169, 94)
    Me.txtPassword.Name = "txtPassword"
    Me.txtPassword.Size = New System.Drawing.Size(251, 20)
    Me.txtPassword.TabIndex = 10
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(101, 97)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(53, 13)
    Me.Label5.TabIndex = 11
    Me.Label5.Text = "Password"
    '
    'btnList
    '
    Me.btnList.Location = New System.Drawing.Point(353, 158)
    Me.btnList.Name = "btnList"
    Me.btnList.Size = New System.Drawing.Size(75, 23)
    Me.btnList.TabIndex = 12
    Me.btnList.Text = "List"
    Me.btnList.UseVisualStyleBackColor = True
    '
    'lblTestResult
    '
    Me.lblTestResult.Location = New System.Drawing.Point(13, 201)
    Me.lblTestResult.Name = "lblTestResult"
    Me.lblTestResult.Size = New System.Drawing.Size(410, 69)
    Me.lblTestResult.TabIndex = 13
    Me.lblTestResult.Text = "Label6"
    '
    'SQLDialog
    '
    Me.AcceptButton = Me.OK_Button
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel_Button
    Me.ClientSize = New System.Drawing.Size(435, 315)
    Me.Controls.Add(Me.lblTestResult)
    Me.Controls.Add(Me.btnList)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.txtPassword)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.txtUsername)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.cbAuth)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.cbCatalog)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.cbDataSource)
    Me.Controls.Add(Me.btnTest)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "SQLDialog"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "SQLDialog"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents btnTest As Button
  Friend WithEvents cbDataSource As ComboBox
  Friend WithEvents Label1 As Label
  Friend WithEvents cbCatalog As ComboBox
  Friend WithEvents Label2 As Label
  Friend WithEvents cbAuth As ComboBox
  Friend WithEvents Label3 As Label
  Friend WithEvents txtUsername As TextBox
  Friend WithEvents Label4 As Label
  Friend WithEvents txtPassword As TextBox
  Friend WithEvents Label5 As Label
  Friend WithEvents btnList As Button
  Friend WithEvents lblTestResult As Label
End Class
