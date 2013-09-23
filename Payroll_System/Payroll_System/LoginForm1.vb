Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class LoginForm1

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.
    Dim ctr As Integer = 0
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        SqlQuery = "SELECT username, password FROM user WHERE username = '" & UsernameTextBox.Text & "' and password = '" & PasswordTextBox.Text & "'"
        Call Connect()

        Try
            MysqlConn.Open()
            Command = New MySqlCommand(SqlQuery, MysqlConn)
            dr = Command.ExecuteReader
        Catch ex As Exception
            MysqlConn.Close()

        End Try

        ctr += 1

        If dr.HasRows Then
            MysqlConn.Close()
            Me.Hide()
            FormView.Show()


        ElseIf Not dr.HasRows And ctr = 1 Then
            MsgBox("Wrong Username or password.", MsgBoxStyle.Information)
            UsernameTextBox.Text = ""
            PasswordTextBox.Text = ""
            UsernameTextBox.Focus()

        ElseIf Not dr.HasRows And ctr = 2 Then
            MsgBox("Wrong Username or password.", MsgBoxStyle.Information)
            UsernameTextBox.Text = ""
            PasswordTextBox.Text = ""
            UsernameTextBox.Focus()


        ElseIf Not dr.HasRows And ctr = 3 Then
            MsgBox("Wrong Username or password." & vbCrLf & "Please restart the program!", MsgBoxStyle.Information)

        End If

        If ctr = 3 Then
            Me.Close()
            MysqlConn.Close()
        End If

    End Sub
        

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        MysqlConn.Close()
    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
