Imports System.Data.SqlClient
Public Class WebForm5
    Inherits System.Web.UI.Page
    Dim connect As New SqlConnection("Data Source=DESKTOP-K0D6NM4\SQLEXPRESS;Initial Catalog=allowancs_db;Integrated Security=True")

    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Try

            connect.Open()


            If Integer.TryParse(TextBox1.Text, Nothing) Then
                Dim sno As Integer = Convert.ToInt32(TextBox1.Text)

                Dim command As New SqlCommand("SELECT * FROM claimtbl WHERE sno = @sno", connect)
                command.Parameters.AddWithValue("@sno", sno)

                Dim reader As SqlDataReader = command.ExecuteReader
                If reader.HasRows Then
                    While reader.Read()
                        TextBox2.Text = reader("name").ToString()
                        TextBox3.Text = reader("accno").ToString()
                        TextBox4.Text = reader("idno").ToString()
                        TextBox5.Text = reader("phno").ToString()
                        TextBox6.Text = reader("month").ToString()
                        TextBox7.Text = reader("Amount").ToString()
                        TextBox8.Text = reader("monthno").ToString()
                        TextBox12.Text = reader("date").ToString()
                        CheckBoxList2.SelectedValue = reader("levels").ToString()
                    End While
                Else
                    MsgBox("No data found for the specified service number.", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Please enter a valid service number.", MsgBoxStyle.Exclamation)
            End If

        Catch ex As SqlException
            MsgBox("A database error occurred: " & ex.Message, MsgBoxStyle.Exclamation)

        Catch ex As Exception
            MsgBox("An unexpected error occurred: " & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            connect.Close()

        End Try
    End Sub
    Protected Sub ImageButton2_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Response.Redirect("homefrm.aspx")
    End Sub

    Protected Sub btnsearch0_Click(sender As Object, e As EventArgs) Handles btnsearch0.Click
        Response.Redirect("homefrm.aspx")
    End Sub
End Class