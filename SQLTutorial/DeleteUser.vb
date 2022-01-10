Imports System.Text
Public Class DeleteUser
    Private SQL As New SQLControl
    Private Sub DeleteUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = Form1.ActiveForm
        FetchUser()
    End Sub


    Private Sub FetchUser()
        'refresh user list
        clbUsers.Items.Clear()

        'add params and run query
        SQL.AddParam("@users", "%" & txtFilter.Text & "%")
        SQL.ExecQuery("SELECT username " &
                      "FROM members " &
                      "WHERE username Like @users " &
                      "ORDER BY username ASC;")

        'loop rows and return user to the list 
        For Each r As DataRow In SQL.DBDT.Rows
            clbUsers.Items.Add(r("username"))
        Next
    End Sub

    Private Sub DeleteUsers()

        Dim result As DialogResult = MessageBox.Show("The selected user will be deleted! Are you sure you wish to continue", "caption", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            MessageBox.Show("No pressed")
        ElseIf result = DialogResult.Yes Then
            'generate a mass delete command

            Dim c As Integer 'unique ID for auto generated numbers

            Dim DelString As String = "" 'query string builder

            Dim sbDelete As New StringBuilder
            sbDelete.Append("(")
            For Each i As String In clbUsers.CheckedItems
                sbDelete.Append(String.Format("'{0}'", i))
                sbDelete.Append(",")
                'SQL.AddParam("@users" & c, i)
                'DelString += "DELETE FROM members WHERE username=@users" & c & ","
                'c += 1
            Next
            sbDelete.Append("'')")

            Dim strQuery As String = String.Format("DELETE FROM members WHERE username IN {0}", sbDelete.ToString)

            SQL.ExecQuery(strQuery)

            'report and abort  on error
            If SQL.HasException(True) Then Exit Sub

            'report success 
            MessageBox.Show("The selected users have been deleted successfully.")

            'refresh user list
            FetchUser()
        End If

    End Sub
    Private Sub txtFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            FetchUser()
            e.Handled = True
            'supress ding sound
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        If clbUsers.CheckedItems.Count > 0 Then DeleteUsers()

    End Sub
End Class