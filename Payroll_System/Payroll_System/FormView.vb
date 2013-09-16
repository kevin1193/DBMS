Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class FormView
    Dim a, b, c, d, e, f, g, h, i, j, k, l, m

    Private Sub FormView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list()
    End Sub

    

    Private Sub buttonSave_Click(sender As Object, e As EventArgs)
        Adapter.Update(DataSet1)
    End Sub

    Public Sub list()
        'Define the SQL to grab data from table.
        SqlQuery = "SELECT * FROM `employee`"
        Call Connect() 'Call the connection function in Module Connection
        MysqlConn.Open()
        Command = New MySqlCommand(SqlQuery, MysqlConn)
        dr = Command.ExecuteReader()
        ListView1.Items.Clear()

        Do While dr.Read()
            a = (dr.Item("emp_ID").ToString())
            b = (dr.Item("firstname").ToString())
            c = (dr.Item("middlename").ToString())
            d = (dr.Item("lastname").ToString())

            Dim lview As ListViewItem = ListView1.Items.Add(a)
            lview.SubItems.Add(b)
            lview.SubItems.Add(c)
            lview.SubItems.Add(d)



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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        list()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub SettingsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem1.Click

    End Sub

    Private Sub EmployeeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EmployeeToolStripMenuItem1.Click
        FormAdd.Show()
    End Sub

    
    Private Sub buttonSearch_Click(sender As Object, e As EventArgs) Handles buttonSearch.Click

    End Sub
End Class