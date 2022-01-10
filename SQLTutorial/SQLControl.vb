Imports System.Data.SqlClient
Public Class SQLControl
    Private DBCon As New SqlConnection("Server=LAPTOP-8C4OUA60\MSSQLSERVER2;Database=SQLTutorial;User=tutorial;Pwd=1234;")
    Private DBCmd As SqlCommand

    'DBData
    Public DBDA As SqlDataAdapter
    Public DBDT As DataTable

    'QueryParameter 
    Public Params As New List(Of SqlParameter)

    'Query Statistics
    Public RecordCount As Integer
    Public Exception As String

    Public Sub New()

    End Sub

    'Allow connection string override
    Public Sub New(ConnectionString As String)
        DBCon = New SqlConnection(ConnectionString)
    End Sub

    'Excute  query sub
    Public Sub ExecQuery(Query As String, Optional ReturnIdentity As Boolean = False)
        'Reset query stats
        RecordCount = 0
        Exception = ""

        Try
            DBCon.Open()

            'Create db command
            DBCmd = New SqlCommand(Query, DBCon)

            'Load params into DB Command
            Params.ForEach(Sub(p) DBCmd.Parameters.Add(p))

            'Clear param list
            Params.Clear()

            'Execute the command and fill dataset
            DBDT = New DataTable
            DBDA = New SqlDataAdapter(DBCmd)
            RecordCount = DBDA.Fill(DBDT)

            If ReturnIdentity = True Then
                Dim ReturnQuery As String = "SELECT @@IDENTITY as LastID;"
                '@@IDENTITY - SESSION
                'SCOPE_IDENTITY() - SESSION & SCOPE
                'IDEN_CURRENT(tablename) - LAST IDENT IN TABLE, ANY SCOPE, ANY SESSION
                DBCmd = New SqlCommand(ReturnQuery, DBCon)
                DBDT = New DataTable
                DBDA = New SqlDataAdapter(DBCmd)
                RecordCount = DBDA.Fill(DBDT)


            End If

        Catch ex As Exception
            'Capture  error
            Exception = "Exec Error" & vbNewLine & ex.Message
        Finally
            'Close Connection
            If DBCon.State = ConnectionState.Open Then DBCon.Close()
        End Try
    End Sub

    'Add params
    Public Sub AddParam(Name As String, Value As Object)
        Dim NewParams As New SqlParameter(Name, Value)
        Params.Add(NewParams)
    End Sub

    'Error checking
    Public Function HasException(Optional Report As Boolean = False) As Boolean
        If String.IsNullOrEmpty(Exception) Then Return False
        If Report = True Then MessageBox.Show(Exception, CStr(MsgBoxStyle.Critical), CType("Exception:", MessageBoxButtons))
        Return True
    End Function
End Class
