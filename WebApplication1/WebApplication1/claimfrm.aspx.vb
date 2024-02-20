Imports System.Data.SqlClient
Public Class claimfrm
    Inherits System.Web.UI.Page
    Dim connect As New SqlConnection("Data Source=DESKTOP-K0D6NM4\SQLEXPRESS;Initial Catalog=allowancs_db;Integrated Security=True")
    'function to check for characters in the input boxes
    Private Function isalphaonly(input As String) As Boolean
        For Each c As Char In input
            If Not (Char.IsLetter(c) Or Char.IsLower(c)) Then
                Return False
            End If

        Next
        Return True
    End Function
    Public Function claimexists(sno As Integer, idno As Integer) As Boolean
        Dim command As New SqlCommand("Select * From claimtbl where (sno=@sno or idno=@idno)", connect)
        command.Parameters.AddWithValue("@sno", sno)
        command.Parameters.AddWithValue("@idno", idno)
        'execution and error handling
        Dim count As Integer = 0
        Try
            connect.Open()
            count = Convert.ToInt32(command.ExecuteScalar())
            If count > 0 Then
                'user exists
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("error:" & ex.Message)
            Return False
        Finally
            connect.Close()
        End Try
    End Function

    Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        'validate the form
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MsgBox("please enter your service number")
            Return
        ElseIf Not IsNumeric(TextBox1.Text) Then
            MsgBox("please enter a valid numeric service number")
            Return
        End If
        If String.IsNullOrEmpty(TextBox2.Text) Then
            MsgBox("please enter your name")
            Return
            ' ElseIf Not isalphaonly(TextBox2.Text) Then
            '    MsgBox("please enter a valid name with alphabetic characters")
            'End If
            If String.IsNullOrEmpty(TextBox3.Text) Then
                MsgBox("please enter your account number")
                Return
            ElseIf Not IsNumeric(TextBox3.Text) Then
                MsgBox("please enter a valid numeric account number")
                Return
            End If
            If String.IsNullOrEmpty(TextBox4.Text) Then
                MsgBox("please enter your id number")
                Return
            ElseIf Not IsNumeric(TextBox4.Text) Then
                MsgBox("please enter a valid numeric id number")
                Return
            End If
            If String.IsNullOrEmpty(TextBox5.Text) Then
                MsgBox("please enter your phone number")
                Return
            ElseIf Not IsNumeric(TextBox5.Text) Then
                MsgBox("please enter a valid numeric phone number")
                Return
            End If
            If String.IsNullOrEmpty(CheckBoxList2.SelectedValue) Then
                MsgBox("please select level")
                Return
            End If
            If String.IsNullOrEmpty(TextBox8.Text) Then
                MsgBox("please select month number")
                Return
            ElseIf Not IsNumeric(TextBox8.Text) Then
                MsgBox("please enter a valid numeric month number")
                Return
            End If
           
            End If
            Dim sno As Integer = TextBox1.Text
            Dim name As String = TextBox2.Text
            Dim accno As Integer = TextBox3.Text
            Dim idno As Integer = TextBox4.Text
            Dim month As String = ""
            Dim phoneno As Integer = TextBox5.Text
            Dim level As String = CheckBoxList2.SelectedValue
            Dim monthno As Integer = TextBox8.Text
            Dim amount As Integer
            Dim dates As Date = DateTime.Now
            amount = monthno * 1500

            ' Iterate through ListBox items to get selected months
            For Each selecteditem As ListItem In ListBox1.Items
                If selecteditem.Selected Then
                    month += selecteditem.Text + ","
                End If
            Next
            'remove trailing comma
            month = month.TrimEnd(","c)
            'For Each month As String 
            Dim checkclaim As Boolean = claimexists(sno, idno)
            If checkclaim Then
                MsgBox("claim details already exists,choose another service no or idno")
            Else
                connect.Open()
                Dim cmd As New SqlCommand("insert into claimtbl values('" & sno & "','" & name & "','" & accno & "','" & idno & "','" & phoneno & "','" & month & "','" & level & "','" & monthno & "','" & amount & "','" & dates & "')", connect)
                cmd.ExecuteNonQuery()
                MsgBox("Claims submitted successfully. Your total claim amount is: " & vbTab & amount, MsgBoxStyle.Information, "Claim Submission")

                Response.Redirect("claimfrm.aspx")
            End If
            'Next
            connect.Close()
            'clear the controls
            TextBox1.Text = ""
            TextBox4.Text = " "
            TextBox2.Text = ""
            'TextBox6.Text = ""
            TextBox3.Text = ""
            TextBox5.Text = ""
            TextBox8.Text = ""
            CheckBoxList2.SelectedValue = Nothing

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("homefrm.aspx")
    End Sub

    Protected Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        For Each selectedItem As ListItem In ListBox1.Items
            If selectedItem.Selected Then
                selectedItem.Attributes("style") = "background-color: DarkGray;"
            Else
                selectedItem.Attributes("style") = ""
            End If
        Next
        Dim selectedcount As Integer = 0
        For Each Item As ListItem In ListBox1.Items
            If Item.Selected Then
                selectedcount += 1
            End If
        Next
        TextBox8.Text = selectedcount.ToString
    End Sub

    Protected Sub Button3_Click1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim connect As New SqlConnection("Data Source=DESKTOP-K0D6NM4\SQLEXPRESS;Initial Catalog=allowancs_db;Integrated Security=True")
        Try
            connect.Open()
            If Integer.TryParse(TextBox1.Text, Nothing) Then
                Dim sno As Integer = Convert.ToInt32(TextBox1.Text)

                Dim command As New SqlCommand("SELECT * FROM regstbl WHERE sno = @sno", connect)
                command.Parameters.AddWithValue("@sno", sno)

                Dim reader As SqlDataReader = command.ExecuteReader
                If reader.HasRows Then
                    While reader.Read()
                        TextBox2.Text = reader("firstname").ToString()
                        TextBox9.Text = reader("secondname").ToString()
                        TextBox10.Text = reader("lastname").ToString()
                        TextBox3.Text = reader("accno").ToString()
                        TextBox4.Text = reader("idno").ToString()
                        TextBox5.Text = reader("phnno").ToString()
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

    Protected Sub btnview_Click(sender As Object, e As EventArgs) Handles btnview.Click
        Response.Redirect("webform5.aspx")
    End Sub
End Class