<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
    Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
    Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.DatabaseBuildersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ScriptMultipleStoredProcedureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.CreateFormFromTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.LoadFormFromTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.CreateTypeFromTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.BuildNetProcCallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.UtilitiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.StringFromCSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.SingleLineStringToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.CreateHashToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.EncodeDecodeURlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.CreateRandomKeyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.RandomeStringGeneratorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.CheckDigitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.DecodeEncryptDictionaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.SQLToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.FormatSQLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.DebutStoredProcedureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ScriptSQLMoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ResetSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.MenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'MenuStrip1
    '
    Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.DatabaseBuildersToolStripMenuItem, Me.UtilitiesToolStripMenuItem, Me.SQLToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
    Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
    Me.MenuStrip1.Name = "MenuStrip1"
    Me.MenuStrip1.Size = New System.Drawing.Size(1197, 24)
    Me.MenuStrip1.TabIndex = 0
    Me.MenuStrip1.Text = "MenuStrip1"
    '
    'FileToolStripMenuItem
    '
    Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.SettingsToolStripMenuItem})
    Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
    Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
    Me.FileToolStripMenuItem.Text = "File"
    '
    'ExitToolStripMenuItem
    '
    Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
    Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
    Me.ExitToolStripMenuItem.Text = "Exit"
    '
    'DatabaseBuildersToolStripMenuItem
    '
    Me.DatabaseBuildersToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScriptMultipleStoredProcedureToolStripMenuItem, Me.CreateFormFromTableToolStripMenuItem, Me.LoadFormFromTableToolStripMenuItem, Me.CreateTypeFromTableToolStripMenuItem, Me.BuildNetProcCallToolStripMenuItem})
    Me.DatabaseBuildersToolStripMenuItem.Name = "DatabaseBuildersToolStripMenuItem"
    Me.DatabaseBuildersToolStripMenuItem.Size = New System.Drawing.Size(112, 20)
    Me.DatabaseBuildersToolStripMenuItem.Text = "Database Builders"
    '
    'ScriptMultipleStoredProcedureToolStripMenuItem
    '
    Me.ScriptMultipleStoredProcedureToolStripMenuItem.Name = "ScriptMultipleStoredProcedureToolStripMenuItem"
    Me.ScriptMultipleStoredProcedureToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
    Me.ScriptMultipleStoredProcedureToolStripMenuItem.Text = "Script Stored Procedure"
    '
    'CreateFormFromTableToolStripMenuItem
    '
    Me.CreateFormFromTableToolStripMenuItem.Name = "CreateFormFromTableToolStripMenuItem"
    Me.CreateFormFromTableToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
    Me.CreateFormFromTableToolStripMenuItem.Text = "Create Form From Table"
    '
    'LoadFormFromTableToolStripMenuItem
    '
    Me.LoadFormFromTableToolStripMenuItem.Name = "LoadFormFromTableToolStripMenuItem"
    Me.LoadFormFromTableToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
    Me.LoadFormFromTableToolStripMenuItem.Text = "Load Form From Table"
    '
    'CreateTypeFromTableToolStripMenuItem
    '
    Me.CreateTypeFromTableToolStripMenuItem.Name = "CreateTypeFromTableToolStripMenuItem"
    Me.CreateTypeFromTableToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
    Me.CreateTypeFromTableToolStripMenuItem.Text = "Create Type From Table"
    '
    'BuildNetProcCallToolStripMenuItem
    '
    Me.BuildNetProcCallToolStripMenuItem.Name = "BuildNetProcCallToolStripMenuItem"
    Me.BuildNetProcCallToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
    Me.BuildNetProcCallToolStripMenuItem.Text = "Build .Net Proc Call"
    '
    'UtilitiesToolStripMenuItem
    '
    Me.UtilitiesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StringFromCSVToolStripMenuItem, Me.SingleLineStringToolStripMenuItem, Me.CreateHashToolStripMenuItem, Me.EncodeDecodeURlToolStripMenuItem, Me.CreateRandomKeyToolStripMenuItem, Me.RandomeStringGeneratorToolStripMenuItem, Me.CheckDigitToolStripMenuItem, Me.DecodeEncryptDictionaryToolStripMenuItem})
    Me.UtilitiesToolStripMenuItem.Name = "UtilitiesToolStripMenuItem"
    Me.UtilitiesToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
    Me.UtilitiesToolStripMenuItem.Text = "Utilities"
    '
    'StringFromCSVToolStripMenuItem
    '
    Me.StringFromCSVToolStripMenuItem.Name = "StringFromCSVToolStripMenuItem"
    Me.StringFromCSVToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
    Me.StringFromCSVToolStripMenuItem.Text = "String From CSV"
    '
    'SingleLineStringToolStripMenuItem
    '
    Me.SingleLineStringToolStripMenuItem.Name = "SingleLineStringToolStripMenuItem"
    Me.SingleLineStringToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
    Me.SingleLineStringToolStripMenuItem.Text = "Single Line String"
    '
    'CreateHashToolStripMenuItem
    '
    Me.CreateHashToolStripMenuItem.Name = "CreateHashToolStripMenuItem"
    Me.CreateHashToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
    Me.CreateHashToolStripMenuItem.Text = "Create Hash"
    '
    'EncodeDecodeURlToolStripMenuItem
    '
    Me.EncodeDecodeURlToolStripMenuItem.Name = "EncodeDecodeURlToolStripMenuItem"
    Me.EncodeDecodeURlToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
    Me.EncodeDecodeURlToolStripMenuItem.Text = "Encode/Decode URL"
    '
    'CreateRandomKeyToolStripMenuItem
    '
    Me.CreateRandomKeyToolStripMenuItem.Name = "CreateRandomKeyToolStripMenuItem"
    Me.CreateRandomKeyToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
    Me.CreateRandomKeyToolStripMenuItem.Text = "Create Random Key"
    '
    'RandomeStringGeneratorToolStripMenuItem
    '
    Me.RandomeStringGeneratorToolStripMenuItem.Name = "RandomeStringGeneratorToolStripMenuItem"
    Me.RandomeStringGeneratorToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
    Me.RandomeStringGeneratorToolStripMenuItem.Text = "Randome String Generator"
    '
    'CheckDigitToolStripMenuItem
    '
    Me.CheckDigitToolStripMenuItem.Name = "CheckDigitToolStripMenuItem"
    Me.CheckDigitToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
    Me.CheckDigitToolStripMenuItem.Text = "Check Digit"
    '
    'DecodeEncryptDictionaryToolStripMenuItem
    '
    Me.DecodeEncryptDictionaryToolStripMenuItem.Name = "DecodeEncryptDictionaryToolStripMenuItem"
    Me.DecodeEncryptDictionaryToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
    Me.DecodeEncryptDictionaryToolStripMenuItem.Text = "Decode/Encrypt Dictionary"
    '
    'SQLToolsToolStripMenuItem
    '
    Me.SQLToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FormatSQLToolStripMenuItem, Me.DebutStoredProcedureToolStripMenuItem, Me.ScriptSQLMoveToolStripMenuItem})
    Me.SQLToolsToolStripMenuItem.Name = "SQLToolsToolStripMenuItem"
    Me.SQLToolsToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
    Me.SQLToolsToolStripMenuItem.Text = "SQL Tools"
    '
    'FormatSQLToolStripMenuItem
    '
    Me.FormatSQLToolStripMenuItem.Name = "FormatSQLToolStripMenuItem"
    Me.FormatSQLToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
    Me.FormatSQLToolStripMenuItem.Text = "Format SQL"
    '
    'DebutStoredProcedureToolStripMenuItem
    '
    Me.DebutStoredProcedureToolStripMenuItem.Name = "DebutStoredProcedureToolStripMenuItem"
    Me.DebutStoredProcedureToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
    Me.DebutStoredProcedureToolStripMenuItem.Text = "Debug Stored Procedure"
    '
    'ScriptSQLMoveToolStripMenuItem
    '
    Me.ScriptSQLMoveToolStripMenuItem.Name = "ScriptSQLMoveToolStripMenuItem"
    Me.ScriptSQLMoveToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
    Me.ScriptSQLMoveToolStripMenuItem.Text = "Script SQL Move"
    '
    'HelpToolStripMenuItem
    '
    Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResetSettingsToolStripMenuItem, Me.AboutToolStripMenuItem})
    Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
    Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
    Me.HelpToolStripMenuItem.Text = "Help"
    '
    'ResetSettingsToolStripMenuItem
    '
    Me.ResetSettingsToolStripMenuItem.Name = "ResetSettingsToolStripMenuItem"
    Me.ResetSettingsToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
    Me.ResetSettingsToolStripMenuItem.Text = "Reset Settings"
    '
    'AboutToolStripMenuItem
    '
    Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
    Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
    Me.AboutToolStripMenuItem.Text = "About"
    '
    'SettingsToolStripMenuItem
    '
    Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
    Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
    Me.SettingsToolStripMenuItem.Text = "Settings"
    '
    'MainForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1197, 812)
    Me.Controls.Add(Me.MenuStrip1)
    Me.IsMdiContainer = True
    Me.MainMenuStrip = Me.MenuStrip1
    Me.Name = "MainForm"
    Me.Text = "Development Tools"
    Me.MenuStrip1.ResumeLayout(False)
    Me.MenuStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents MenuStrip1 As MenuStrip
  Friend WithEvents DatabaseBuildersToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ScriptMultipleStoredProcedureToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents UtilitiesToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents SQLToolsToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents CreateFormFromTableToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents LoadFormFromTableToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents CreateTypeFromTableToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents StringFromCSVToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents SingleLineStringToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents CreateHashToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents EncodeDecodeURlToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents CreateRandomKeyToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents RandomeStringGeneratorToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents CheckDigitToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents DecodeEncryptDictionaryToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents FormatSQLToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents DebutStoredProcedureToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ScriptSQLMoveToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ResetSettingsToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents BuildNetProcCallToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
End Class
