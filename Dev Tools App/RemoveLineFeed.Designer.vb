<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RemoveLineFeed
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
    Me.txtResults = New System.Windows.Forms.TextBox()
    Me.btnCopy = New System.Windows.Forms.Button()
    Me.btnClear = New System.Windows.Forms.Button()
    Me.btnGenerate = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'txtResults
    '
    Me.txtResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtResults.Location = New System.Drawing.Point(12, 12)
    Me.txtResults.Multiline = True
    Me.txtResults.Name = "txtResults"
    Me.txtResults.Size = New System.Drawing.Size(868, 451)
    Me.txtResults.TabIndex = 12
    '
    'btnCopy
    '
    Me.btnCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnCopy.Location = New System.Drawing.Point(745, 469)
    Me.btnCopy.Name = "btnCopy"
    Me.btnCopy.Size = New System.Drawing.Size(135, 23)
    Me.btnCopy.TabIndex = 15
    Me.btnCopy.Text = "Copy To Clipboard"
    Me.btnCopy.UseVisualStyleBackColor = True
    '
    'btnClear
    '
    Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnClear.Location = New System.Drawing.Point(539, 469)
    Me.btnClear.Name = "btnClear"
    Me.btnClear.Size = New System.Drawing.Size(75, 23)
    Me.btnClear.TabIndex = 14
    Me.btnClear.Text = "Clear"
    Me.btnClear.UseVisualStyleBackColor = True
    '
    'btnGenerate
    '
    Me.btnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnGenerate.Location = New System.Drawing.Point(620, 469)
    Me.btnGenerate.Name = "btnGenerate"
    Me.btnGenerate.Size = New System.Drawing.Size(119, 23)
    Me.btnGenerate.TabIndex = 13
    Me.btnGenerate.Text = "Remove Linefeeds"
    Me.btnGenerate.UseVisualStyleBackColor = True
    '
    'RemoveLineFeed
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(892, 504)
    Me.Controls.Add(Me.btnCopy)
    Me.Controls.Add(Me.btnClear)
    Me.Controls.Add(Me.btnGenerate)
    Me.Controls.Add(Me.txtResults)
    Me.Name = "RemoveLineFeed"
    Me.Text = "RemoveLineFeed"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents txtResults As TextBox
  Friend WithEvents btnCopy As Button
  Friend WithEvents btnClear As Button
  Friend WithEvents btnGenerate As Button
End Class
