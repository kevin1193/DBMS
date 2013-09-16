Imports MySql.Data.MySqlClient
Imports MySql.Data
Module Connection
    Public MysqlConn As MySqlConnection
    Public Command As MySqlCommand
    Public Adapter As MySqlDataAdapter
    Public emp_profileData As DataTable
    Public SqlQuery As String
    Public ds As DataSet
    Public dr As MySqlDataReader
    Public Sub Connect()
        MysqlConn = New MySqlConnection() ''Connection String
        Dim name As String = "payroll_system"
        Dim server As String = "localhost"
        Dim user As String = "root"
        Dim pwd As String = ""
        MysqlConn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, user, pwd, name)
    End Sub
End Module
