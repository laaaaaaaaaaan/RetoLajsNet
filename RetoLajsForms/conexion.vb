Imports MySql.Data.MySqlClient

Public Class conexion
    Public MysqlConnString As String = "server=192.168.101.35; user id= lajs ; password=lajs ; database=alojamientos;Convert Zero Datetime=True"
    Public MysqlConexion As MySqlConnection = New MySqlConnection(MysqlConnString)
End Class
