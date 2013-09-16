Imports MySql.Data.MySqlClient
Imports MySql.Data
Module Module1
    Public Class Connection 'Function to call for connecting into the database
        Public Sub Connect()
            Dim MysqlConn As MySqlConnection
            Dim Command As New MySqlCommand
            Dim Adapter As New MySqlDataAdapter
            MysqlConn = New MySqlConnection()
            'Connection String
            Dim name As String = "payroll_system"
            Dim server As String = "localhost"
            Dim user As String = "root"
            Dim pwd As String = ""
            MysqlConn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, user, pwd, name)
            Try
                MysqlConn.Open()
            Catch ex As Exception
                MsgBox("Error in saving to connection :" & ex.Message)
            End Try
        End Sub
    End Class

    Public Sub Add()

    End Sub
    Public Sub Update()

    End Sub
    Public Sub
End Module
