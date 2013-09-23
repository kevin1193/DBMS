Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class NewUser

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles password2.TextChanged

    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        SqlQuery = "SELECT username, password FROM user WHERE username = '" & username.Text & "'"
        Call Connect()
        MysqlConn.Open()
        Command = New MySqlCommand(SqlQuery, MysqlConn)
        dr = Command.ExecuteReader
        If dr.HasRows Then 'check if username exist
            MsgBox("Username exists, Change username then try again")
            username.Text = " "
            password1.Text = " "
            password2.Text = " "
            MysqlConn.Close()
        Else
            Try
                Dim addcmd As New MySqlCommand
                SqlQuery = "INSERT INTO `user`(`user_ID`, `username`, `password`) VALUES (NULL, '" + username.Text + "', '" + password1.Text + "')"
                MysqlConn.Close()
                If (password1.Text = password2.Text) Then 'confirm password
                    Try
                        MysqlConn.Open()
                        addcmd.Connection = MysqlConn
                        addcmd.CommandText = SqlQuery
                        addcmd.ExecuteNonQuery()
                        MysqlConn.Close()
                        MsgBox("New user added ")
                        Me.Close()

                    Catch ex As Exception
                        MsgBox("Error in saving to Database. Error is :" & ex.Message)

                    End Try

                Else
                    MsgBox("Password did not match!")
                    password1.Text = " "
                    password2.Text = " "

                End If
            Catch
            End Try
        End If
    End Sub

    Private Sub NewUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class