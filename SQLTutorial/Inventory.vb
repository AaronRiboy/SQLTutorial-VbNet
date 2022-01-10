Public Class Inventory
    Public SQL As New SQLControl

    Public Sub LoadGrid(Optional Query As String = "")

        If Query = "" Then
            SQL.ExecQuery("SELECT * FROM Products;")
        Else
            SQL.ExecQuery(Query)
        End If

        'Error handling
        If SQL.HasException(True) Then Exit Sub

        dgvData.DataSource = SQL.DBDT
    End Sub

    Private Sub LoadCBX()
        'Refresh combobox
        cbxItems.Items.Clear()

        'Run Query
        SQL.ExecQuery("SELECT username FROM members ORDER BY username ASC;")

        If SQL.HasException(True) Then Exit Sub

        'Loop row and to combobox

        For Each r As DataRow In SQL.DBDT.Rows
            cbxItems.Items.Add(r("username").ToString)
        Next

    End Sub

    Private Sub FindItem()
        SQL.AddParam("@item", "%" & txtSearch.Text & "%")
        LoadGrid("Select PartNo,PartDesc FROM Products WHERE PartNo LIKE @item;")
    End Sub


    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MdiParent = Form1.ActiveForm
        LoadGrid()
        LoadCBX()
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        FindItem()
    End Sub
End Class