Public Class EditUser
    Private SQL As New SQLControl

    Private Sub FetchUser()
        'Refresh user list
        lbUsers.Items.Clear()

        'add  params and run query
        SQL.AddParam("@users", "%" & txtFilter.Text & "%")
        SQL.ExecQuery("SELECT username " &
                      "FROM members " &
                      "WHERE username LIKE @users " &
                      "ORDER BY user ASC;")

        'report and abort on error  
        If SQL.HasException(True) Then Exit Sub

        'loop row  and return users to list
        For Each r As DataRow In SQL.DBDT.Rows
            lbUsers.Items.Add(r("username"))
        Next
    End Sub

    Private Sub GetUserDetails(Username As String)
        SQL.AddParam("@user", Username)
        SQL.ExecQuery("SELECT TOP 1 * " &
                      "FROM members " &
                      "WHERE username = @user;")

        If SQL.RecordCount < 1 Then Exit Sub

        For Each r As DataRow In SQL.DBDT.Rows
            txtID.Text = r("ID")
            txtUser.Text = r("username")
            txtPassword.Text = r("password")
            cbActive.Checked = r("active")
            cbAdmin.Checked = r("admin")
        Next

    End Sub

    Private Sub UpdateUser()
        SQL.AddParam("@password", txtPassword.Text)
        SQL.AddParam("@active", cbActive.Checked)
        SQL.AddParam("@admin", cbAdmin.Checked)
        SQL.AddParam("@id", txtID.Text)

        SQL.ExecQuery("UPDATE members " &
                      "SET password=@password, active=@active, admin=@admin " &
                      "WHERE ID=@id;")

        If SQL.HasException(True) Then Exit Sub

        MessageBox.Show("User has been updated")

        cmdSave.Enabled = False


    End Sub


    Private Sub EditUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = Form1.ActiveForm
        FetchUser()
    End Sub

    Private Sub txtFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            FetchUser()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub lbUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbUsers.SelectedIndexChanged
        GetUserDetails(lbUsers.Text)
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        UpdateUser()

    End Sub
End Class