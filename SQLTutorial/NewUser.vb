Public Class NewUser
    Private SQL As New SQLControl
    Private Sub NewUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = Form1.ActiveForm

    End Sub

    Private Sub InsertUser()
        'Add sql params  & run the command
        SQL.AddParam("@username", txtUser.Text)
        SQL.AddParam("@password", txtPassword.Text)
        SQL.AddParam("@active", cbActive.Checked)
        SQL.AddParam("@admin", cbAdmin.Checked)

        SQL.ExecQuery("INSERT INTO members (username,password,active,admin,joindate)" &
                      "Values (@username,@password,@active,@admin,GETDATE());", True)

        'Report & abort on errors
        If SQL.HasException(True) Then Exit Sub

        If SQL.DBDT.Rows.Count > 0 Then
            Dim r As DataRow = SQL.DBDT.Rows(0)
            MessageBox.Show(r("LastID").ToString)
        End If
        MessageBox.Show("User created successfully")



    End Sub

    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        InsertUser()

        'clear field
        txtUser.Clear()
        txtPassword.Clear()
        cbActive.Checked = False
        cbActive.Checked = False
        cmdSubmit.Enabled = False
    End Sub

    Private Sub txtFields_TextChanged(sender As Object, e As EventArgs) Handles txtUser.TextChanged, txtPassword.TextChanged
        'Basic validation
        If Not String.IsNullOrWhiteSpace(txtUser.Text) AndAlso Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
            cmdSubmit.Enabled = True

        End If

    End Sub
End Class