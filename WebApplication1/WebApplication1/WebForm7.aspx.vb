Imports System.Data.SqlClient

Public Class WebForm7
    Inherits System.Web.UI.Page
    Dim connect As New SqlConnection("Data Source=DESKTOP-K0D6NM4\SQLEXPRESS;Initial Catalog=allowancs_db;Integrated Security=True")
    Dim searchsno As String


    Public Function searchregistration(searchsno As String) As DataTable
        Dim command As New SqlCommand("select * from claimtbl where sno like @searchsno", connect)
        Dim adapter As New SqlDataAdapter(command)
        Dim datatable As New DataTable()
        Try
            connect.Open()
            command.Parameters.AddWithValue("@searchsno", "%" & searchsno & "%")
            adapter.Fill(datatable)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            connect.Close()
        End Try
        Return datatable
    End Function

    Private Function DataTable() As DataTable
        Throw New NotImplementedException
    End Function

    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Dim searchsno As String = InputBox("Enter Service Number to search")
        Dim filtereddata As DataTable = searchregistration(searchsno)

        ' Check if any records were found
        If filtereddata.Rows.Count > 0 Then
            ' Display filtered data in the GridView
            GridView2.DataSource = filtereddata
            GridView2.DataSourceID = Nothing
            GridView2.DataBind()
        Else
            MsgBox("No records found")
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("webform3.aspx")
    End Sub

   
    Protected Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Response.Redirect("webform3.aspx")
    End Sub
End Class