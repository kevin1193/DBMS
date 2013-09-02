Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class FormView
    Public MysqlConn As MySqlConnection
    Public Command As New MySqlCommand
    Public Adapter As New MySqlDataAdapter
    Public emp_profileData As New DataTable
    Public SQL As String
    Public ds As New DataSet
    Public dr As MySqlDataReader
    Dim a, b, c, d, e, f, g, h, i, j, k, l, m

    Private Sub FormView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()
    End Sub

    Private Sub buttonAdd_Click(sender As Object, e As EventArgs) Handles buttonAdd.Click
        FormAdd.Show()
    End Sub

    Private Sub buttonSave_Click(sender As Object, e As EventArgs)
        Adapter.Update(DataSet1)
    End Sub

    Public Sub list()

        MysqlConn = New MySqlConnection()
        ' Define the SQL to grab data from table.
        SQL = "SELECT * FROM `emp_profile` "
        'Connection String
        Dim name As String = "payroll_system"
        Dim server As String = "localhost"
        Dim user As String = "root"
        Dim pwd As String = ""
        MysqlConn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, user, pwd, name)

        MysqlConn.Open()
        Command = New MySqlCommand(SQL, MysqlConn)
        dr = Command.ExecuteReader()
        ListView1.Items.Clear()

        Do While dr.Read()
            a = (dr.Item("emp_ID").ToString())
            b = (dr.Item("emp_FirstN").ToString())
            c = (dr.Item("emp_MiddleN").ToString())
            d = (dr.Item("emp_lastN").ToString())
            f = (dr.Item("emp_Address").ToString())
            m = (dr.Item("emp_ContactNo").ToString())

            Dim lview As ListViewItem = ListView1.Items.Add(a)
            lview.SubItems.Add(b)
            lview.SubItems.Add(c)
            lview.SubItems.Add(d)
            lview.SubItems.Add(f)
            lview.SubItems.Add(m)
            
            

        Loop
        dr.Close()
        Command.Dispose()
        MysqlConn.Close()
    End Sub


    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Form2.TextBox1.Text = ListView1.SelectedItems(0).SubItems(1).Text
        Form2.TextBox2.Text = ListView1.SelectedItems(0).SubItems(2).Text
        Form2.TextBox3.Text = ListView1.SelectedItems(0).SubItems(3).Text
        Form2.TextBox4.Text = ListView1.SelectedItems(0).SubItems(4).Text
        Form2.TextBox5.Text = ListView1.SelectedItems(0).SubItems(5).Text
        Form2.TextBox6.Text = ListView1.SelectedItems(0).Text
        Form2.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        list()
    End Sub
End Class