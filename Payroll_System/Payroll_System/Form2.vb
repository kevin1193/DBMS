Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class Form2
    Public MysqlConn As MySqlConnection
    Public Command As New MySqlCommand
    Public Adapter As New MySqlDataAdapter
    Public emp_profileData As New DataTable
    Public SQL As String
    Public ds As New DataSet
    Public dr As MySqlDataReader


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            MysqlConn = New MySqlConnection()
            Dim name As String = "payroll_system"
            Dim server As String = "localhost"
            Dim user As String = "root"
            Dim pwd As String = ""
            MysqlConn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, user, pwd, name)

            SQL = "Update emp_profile set emp_FirstN = '" & TextBox1.Text & "', emp_MiddleN = '" & TextBox2.Text & "', emp_LastN = '" & TextBox3.Text & "', emp_Address = '" & TextBox4.Text & "',  emp_ContactNo = '" & TextBox5.Text & "' WHERE emp_ID = '" & TextBox6.Text & "' "
            Dim da As New MySqlDataAdapter(SQL, MysqlConn)
            da.Fill(ds)
            Me.Hide()

            FormView.list()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Dialog", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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