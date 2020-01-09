Public Class Usuario

    Private _nombre As String
    Private _password As String

    Public Property nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property
End Class
