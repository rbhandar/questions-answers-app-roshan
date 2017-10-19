Imports System.Data.SqlClient

Public Class welcome
    Private Sub LoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem.Click
        Dim sqlcon As New SqlConnection With {.ConnectionString = "Server=essql1.walton.uark.edu;Database=isys4283-2017fa;Trusted_Connection=yes;"}
        Dim sqlcmd As SqlCommand   'Like New query window in sql server
        Dim sqlda As SqlDataAdapter
        Dim sqldataset As DataSet  'like a table

        Dim query As String
        query = "SELECT * FROM questions ORDER BY created_at DESC;"

        Try 'try means we are going to try this code, catch means if anything goes wrong, the exception going to be catched. Finally happens no matter what.. so in case of try to catch, Finally happens
            sqlcon.Open()
            sqlcmd = New SqlCommand(query, sqlcon)
            sqlda = New SqlDataAdapter(sqlcmd)
            sqldataset = New DataSet
            sqlda.Fill(sqldataset)
            If sqldataset.Tables.Count > 0 Then
                dgvQuestions.Refresh()
                dgvQuestions.DataSource = sqldataset.Tables(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Throw ex
        Finally
            If sqlcon.State = ConnectionState.Open Then
                sqlcon.Close()
            End If
        End Try
    End Sub
End Class
