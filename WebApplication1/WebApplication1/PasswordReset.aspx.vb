Imports System.Data.SqlClient
Public Class PasswordReset
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Dim connect As New SqlConnection("Data Source=DESKTOP-K0D6NM4\SQLEXPRESS;Initial Catalog=allowancs_db;Integrated Security=True")
    Protected Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        If Txtnewpass.Text <> Txtconfirmpassword.Text Then
            MsgBox("password do not match")
        End If
        Dim usernameoremail As String = Txxnewuser.Text
        Dim newPassword As String = Txtnewpass.Text

        connect.Open()
        Try
            Dim command As New SqlCommand("UPDATE regstbl SET password=@newpassword WHERE username=@username OR Email=@email", connect)
            command.Parameters.AddWithValue("@email", usernameoremail)
            command.Parameters.AddWithValue("@username", usernameoremail)
            command.Parameters.AddWithValue("@newpassword", newpassword)
            ' Execute the SQL command
            command.ExecuteNonQuery()
            ' Optionally, display a success message
            MsgBox("Password reset successful")
        Catch ex As Exception
            MsgBox("error:" & ex.Message)
        Finally
            connect.Close()
        End Try
        Response.Redirect("homefrm.aspx")
    End Sub

    Protected Sub BtnReset0_Click(sender As Object, e As EventArgs) Handles BtnReset0.Click
        Response.Redirect("homefrm.aspx")

    End Sub
End Class