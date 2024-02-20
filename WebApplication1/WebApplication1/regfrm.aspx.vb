Imports System.Data.SqlClient

Public Class regfrm
    Inherits System.Web.UI.Page
    Dim connect As New SqlConnection("Data Source=DESKTOP-K0D6NM4\SQLEXPRESS;Initial Catalog=allowancs_db;Integrated Security=True;Connect Timeout=60")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    'Check if the password meets the required format
    Private Function ValidatePasswordFormat(password As String) As Boolean
        ' Check if the password meets the required format
        Dim hasUppercase As Boolean = False
        Dim hasLowercase As Boolean = False
        Dim hasDigit As Boolean = False
        Dim hasSpecialChar As Boolean = False

        ' Define the valid special characters for the password
        Dim validChars As String = "!@#$%^&*()_-+=<>?/{}~"

        For Each c As Char In password
            If Char.IsUpper(c) Then
                hasUppercase = True
            ElseIf Char.IsLower(c) Then
                hasLowercase = True
            ElseIf Char.IsDigit(c) Then
                hasDigit = True
            ElseIf validChars.Contains(c) Then
                hasSpecialChar = True
            End If
        Next
        ' Password must include at least one uppercase letter, one lowercase letter, one digit, and one special character
        Return hasUppercase AndAlso hasLowercase AndAlso hasDigit AndAlso hasSpecialChar
    End Function
    Private Function GenerateRandomUsername(firstName As String, lastName As String) As String
        ' Generate a random username based on firstname and lastname
        Dim random As New Random()
        Dim randomNumber As Integer = random.Next(10, 100) ' Generate random number
        Dim username As String = firstName.ToLower() & lastName.ToLower() & randomNumber.ToString()
        Return username
    End Function

    Public Function regexists(sno As String, idno As String) As Boolean
        Dim command As New SqlCommand("Select * From regstbl where (sno=@sno or idno=@idno)", connect)
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
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        'validate registration form
        'Dim pattern As String = "^[a-zA-Z]+$"
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MsgBox("please enter your service number")
            Return
        End If
        If String.IsNullOrEmpty(TextBox2.Text) Then
            MsgBox("please enter your firstname")
            Return
        End If
        If String.IsNullOrEmpty(TextBox3.Text) Then
            MsgBox("please enter your secondname")
            Return
        End If
        If String.IsNullOrEmpty(TextBox4.Text) Then
            MsgBox("please enter your lastname")
            Return
        End If
        If String.IsNullOrEmpty(TextBox5.Text) Then
            MsgBox("please enter your idno")
            Return
        End If
        If String.IsNullOrEmpty(TextBox7.Text) Then
            MsgBox("please enter your D.O.B")
            Return
        End If
        If String.IsNullOrEmpty(TextBox6.Text) Then
            MsgBox("please enter your accountno")
            Return
        End If
        If String.IsNullOrEmpty(CheckBox1.Checked) Then
            MsgBox("please select your gender")
            Return
        End If
       

        Dim firstname As String = TextBox2.Text
        Dim lastname As String = TextBox4.Text
        Dim username As String = GenerateRandomUsername(firstname, lastname)
        Dim sno As String = TextBox1.Text
        Dim idno As String = TextBox5.Text
        Dim secondname As String = TextBox3.Text
        Dim dob As String = TextBox7.Text
        Dim phnno As String = TextBox11.Text
        Dim email As String = TextBox9.Text
        Dim accno As String = TextBox6.Text
        Dim gender As String = ""
        Dim password As String = TextBox10.Text
        Dim isValidPassword As Boolean = ValidatePasswordFormat(password)

        If CheckBox1.Checked Then
            gender = "male"
        Else
            gender = "female"
        End If
        Dim regexist As Boolean = regexists(sno, idno)
        If Not isValidPassword Then
            ' Register JavaScript to show an alert
            'ClientScript.RegisterStartupScript(Me.GetType(), "InvalidPasswordAlert", "alert('Invalid password format. Password must include at least one uppercase letter, one lowercase letter, one digit, and one special character.');", True)
            MsgBox("Invalid password format. Password must include at least one uppercase letter, one lowercase letter, one digit, and one special character.")
        ElseIf regexist Then
            MsgBox("registration details exists")
        Else
            Dim command As New SqlCommand("insert into regstbl values('" & sno & "','" & firstname & "','" & secondname & "','" & lastname & "','" & idno & "','" & accno & "','" & dob & "','" & gender & "','" & phnno & "','" & email & "','" & username & "','" & password & "');", connect)
            connect.Open()
            command.ExecuteNonQuery()
            MsgBox("Registration saved successfully!your new username is:" & username.Insert(username.Length - 3, ""))
            Response.Redirect("homefrm.aspx")
            connect.Close()
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("homefrm.aspx")
    End Sub
End Class