<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.msMain = New System.Windows.Forms.MenuStrip()
        Me.miInventory = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.msiNewUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.msiDeleteUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.msiEditUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'msMain
        '
        Me.msMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miInventory, Me.ManageToolStripMenuItem})
        Me.msMain.Location = New System.Drawing.Point(0, 0)
        Me.msMain.Name = "msMain"
        Me.msMain.Size = New System.Drawing.Size(981, 33)
        Me.msMain.TabIndex = 1
        Me.msMain.Text = "MenuStrip1"
        '
        'miInventory
        '
        Me.miInventory.Name = "miInventory"
        Me.miInventory.Size = New System.Drawing.Size(103, 29)
        Me.miInventory.Text = "Inventory"
        '
        'ManageToolStripMenuItem
        '
        Me.ManageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msiNewUser, Me.msiDeleteUser, Me.msiEditUser})
        Me.ManageToolStripMenuItem.Name = "ManageToolStripMenuItem"
        Me.ManageToolStripMenuItem.Size = New System.Drawing.Size(132, 29)
        Me.ManageToolStripMenuItem.Text = "Manage User"
        '
        'msiNewUser
        '
        Me.msiNewUser.Name = "msiNewUser"
        Me.msiNewUser.Size = New System.Drawing.Size(270, 34)
        Me.msiNewUser.Text = "New User"
        '
        'msiDeleteUser
        '
        Me.msiDeleteUser.Name = "msiDeleteUser"
        Me.msiDeleteUser.Size = New System.Drawing.Size(270, 34)
        Me.msiDeleteUser.Text = "Delete User"
        '
        'msiEditUser
        '
        Me.msiEditUser.Name = "msiEditUser"
        Me.msiEditUser.Size = New System.Drawing.Size(270, 34)
        Me.msiEditUser.Text = "Edit User"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(981, 759)
        Me.Controls.Add(Me.msMain)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.msMain
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.msMain.ResumeLayout(False)
        Me.msMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents msMain As MenuStrip
    Friend WithEvents miInventory As ToolStripMenuItem
    Friend WithEvents ManageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents msiNewUser As ToolStripMenuItem
    Friend WithEvents msiDeleteUser As ToolStripMenuItem
    Friend WithEvents msiEditUser As ToolStripMenuItem
End Class
