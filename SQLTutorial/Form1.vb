Public Class Form1

    Private Sub miInventory_Click(sender As Object, e As EventArgs) Handles miInventory.Click
        Dim inventory As New Inventory()
        inventory.Show()

    End Sub

    Private Sub msiNewUser_Click(sender As Object, e As EventArgs) Handles msiNewUser.Click
        Dim newUser As New NewUser()
        newUser.Show()
    End Sub

    Private Sub msiEditUser_Click(sender As Object, e As EventArgs) Handles msiEditUser.Click
        Dim editUser As New EditUser()
        editUser.Show()
    End Sub

    Private Sub msiDeleteUser_Click(sender As Object, e As EventArgs) Handles msiDeleteUser.Click
        Dim deleteUser As New DeleteUser()
        deleteUser.Show()
    End Sub
End Class
