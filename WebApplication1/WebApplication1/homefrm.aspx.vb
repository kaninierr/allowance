Imports System.Data.SqlClient
Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim connect As New SqlConnection("Data Source=DESKTOP-K0D6NM4\SQLEXPRESS;Initial Catalog=allowancs_db;Integrated Security=True")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Function verifyadmin(input As String, password As String) As Boolean
        Dim command As New SqlCommand("SELECT COUNT(*) FROM admintbl WHERE username = @input  AND password = @password", connect)
        command.Parameters.AddWithValue("@input", input)
        command.Parameters.AddWithValue("@password", password)
        Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
        Return count > 0
    End Function

    Public Function verifyuser(input As String, password As String) As Boolean
        Dim command As New SqlCommand("SELECT COUNT(*) FROM regstbl WHERE (username = @input OR email = @input) AND password = @password", connect)
        command.Parameters.AddWithValue("@input", input)
        command.Parameters.AddWithValue("@password", password)
        Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
        Return count > 0
    End Function

    Protected Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text
        connect.Open()
        If verifyadmin(username, password) Then
            MsgBox("admin Logged In")
            Response.Redirect("WebForm2.aspx")
        ElseIf verifyuser(username, password) Then
            MsgBox("user Logged In")
            Response.Redirect("claimfrm.aspx")
        Else
            MsgBox("invalid username or Password")
        End If
        connect.Close()
    End Sub

    Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click

    End Sub
End Class