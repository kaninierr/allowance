Imports System.Data.SqlClient
Public Class WebForm2
    Inherits System.Web.UI.Page
    Dim connect As New SqlConnection("Data Source=DESKTOP-K0D6NM4\SQLEXPRESS;Initial Catalog=allowancs_db;Integrated Security=True;Connect Timeout=60")

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("WebForm3.aspx")
    End Sub

    

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Response.Redirect("homefrm.aspx")
    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Response.Redirect("webform6.aspx")
    End Sub
End Class