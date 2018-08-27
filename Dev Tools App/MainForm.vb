Public Class MainForm
  Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
    End

  End Sub

  Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
    Dim frmAbout As New AboutBox
    frmAbout.MdiParent = Me
    frmAbout.Show()
  End Sub


  Private Sub ResetSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetSettingsToolStripMenuItem.Click
    My.Settings.Reset()
  End Sub

  Private Sub CreateFormFromTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateFormFromTableToolStripMenuItem.Click
    Dim frmFormBuild As New FormCreate
    frmFormBuild.MdiParent = Me
    frmFormBuild.Show()
  End Sub

  Private Sub LoadFormFromTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadFormFromTableToolStripMenuItem.Click
    Dim frmLoad As New LoadFormFromTable
    frmLoad.MdiParent = Me
    frmLoad.Show()

  End Sub

  Private Sub ScriptMultipleStoredProcedureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScriptMultipleStoredProcedureToolStripMenuItem.Click
    Dim frmSPBuild As New SPBuild
    frmSPBuild.MdiParent = Me
    frmSPBuild.Show()
  End Sub

  Private Sub CreateTypeFromTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateTypeFromTableToolStripMenuItem.Click
    Dim frmType As New CreateTypeFromTable
    frmType.MdiParent = Me
    frmType.Show()
  End Sub



  Private Sub StringFromCSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StringFromCSVToolStripMenuItem.Click
    Dim frmFStr As New FormatString
    frmFStr.MdiParent = Me
    frmFStr.Show()
  End Sub

  Private Sub BuildNetProcCallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuildNetProcCallToolStripMenuItem.Click
    Dim frmBuild As New SPBuilder
    frmBuild.MdiParent = Me
    frmBuild.Show()
  End Sub

  Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
    Dim frmOptions As New Options
    frmOptions.MdiParent = Me
    frmOptions.Show()
  End Sub
End Class
