Imports System.Reflection
Imports DevCase.Core.IO

Public NotInheritable Class Form1 : Inherits Form

    ' Flag to avoid closing the application until all the hard-drive information are properlly loaded.
    Private isBusy As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MinimumSize = Me.Size

        Task.Run(Sub()
                     Me.isBusy = True
                     Try
                         For Each hdd As HardDriveInfo In HardDriveInfo.GetDrives()
                             Dim tabPage As New TabPage(hdd.Name)
                             Dim propGrid As New PropertyGrid() With {
                                 .Dock = DockStyle.Fill,
                                 .HelpVisible = True,
                                 .ToolbarVisible = False,
                                 .PropertySort = PropertySort.CategorizedAlphabetical,
                                 .SelectedObject = hdd
                             }

                             tabPage.Controls.Add(propGrid)
                             Me.TabControl1.Invoke(Sub() Me.TabControl1.TabPages.Add(tabPage))
                         Next hdd

                     Catch ex As Exception
                         MessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)

                     Finally
                         Me.isBusy = False

                     End Try
                 End Sub)
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = Me.isBusy
    End Sub

End Class