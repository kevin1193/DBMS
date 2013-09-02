Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class FormAdd
    Dim Conn As MySqlConnection
    Dim addcmd As New MySqlCommand
    Dim AddQuery As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        AddQuery = "INSERT INTO `payroll_system`.`emp_profile` (`emp_ID`, `emp_FirstN`, `emp_MiddleN`, `emp_LastN`, `emp_Address`, `emp_ContactNo`) VALUES (NULL, '" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "')"
        Conn = New MySqlConnection()
        ' Define the SQL to grab data from table.
        'Connection String
        Dim name As String = "payroll_system"
        Dim server As String = "localhost"
        Dim user As String = "root"
        Dim pwd As String = ""
        Conn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=true", server, user, pwd, name)

        Try
            Conn.Open()
            addcmd.Connection = Conn
            addcmd.CommandText = AddQuery
            addcmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Error in saving to Database. Error is :" & ex.Message)
        End Try
        MsgBox("New employee was added")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()


    End Sub
    Private Sub TextBox5_Keypresss(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then e.Handled = True
        End If
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then e.Handled = True
        End If
    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then e.Handled = True
        End If
    End Sub



End Class