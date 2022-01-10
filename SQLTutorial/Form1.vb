Public Class Form1

    Private Sub miInventory_Click(sender As Object, e As EventArgs) Handles miInventory.Click
        Dim inventory As New Inventory()
        inventory.Show()

    End Sub

    Private Sub msiNewUser_Click(sender As Object, e As EventArgs) Handles msiNewUser.Click
        Dim newUser As New NewUser()
        newUser.Show()
    End Sub
End Class
