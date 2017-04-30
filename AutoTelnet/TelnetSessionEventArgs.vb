Public Class TelnetSessionReadEventArgs
    Inherits System.EventArgs

    Public Sub New(response As String)
        MyBase.New()
        Me.responseValue = response
    End Sub

#Region "Property Response"
    Private responseValue As String = String.Empty
    Public ReadOnly Property Response As String
        Get
            Return Me.responseValue
        End Get
    End Property
#End Region
End Class

'Public Class TelnetSessionOutputAddedEventArgs
'    Inherits System.EventArgs

'    Public Sub New(text As String)
'        MyBase.New()
'        Me.textValue = text
'    End Sub

'#Region "Property Text"
'    Private textValue As String = String.Empty
'    Public ReadOnly Property Text As String
'        Get
'            Return Me.textValue
'        End Get
'    End Property
'#End Region
'End Class

Public Class TelnetSessionOutputInformationAddedEventArgs
    Inherits System.EventArgs

    Public Sub New(text As String)
        MyBase.New()
        Me.textValue = text
    End Sub

#Region "Property Text"
    Private textValue As String = String.Empty
    Public ReadOnly Property Text As String
        Get
            Return Me.textValue
        End Get
    End Property
#End Region
End Class

Public Class TelnetSessionOutputCommandAddedEventArgs
    Inherits System.EventArgs

    Public Sub New(text As String)
        MyBase.New()
        Me.textValue = text
    End Sub

#Region "Property Text"
    Private textValue As String = String.Empty
    Public ReadOnly Property Text As String
        Get
            Return Me.textValue
        End Get
    End Property
#End Region
End Class

Public Class TelnetSessionOutputResponseAddedEventArgs
    Inherits System.EventArgs

    Public Sub New(text As String)
        MyBase.New()
        Me.textValue = text
    End Sub

#Region "Property Text"
    Private textValue As String = String.Empty
    Public ReadOnly Property Text As String
        Get
            Return Me.textValue
        End Get
    End Property
#End Region
End Class

Public Class TelnetSessionOutputErrorAddedEventArgs
    Inherits System.EventArgs

    Public Sub New(text As String, ex As System.Exception)
        MyBase.New()
        Me.textValue = text
    End Sub

#Region "Property Text"
    Private textValue As String = String.Empty
    Public ReadOnly Property Text As String
        Get
            Return Me.textValue
        End Get
    End Property
#End Region

#Region "Property Exception"
    Private exceptionValue As System.Exception = Nothing
    Public ReadOnly Property Exception As System.Exception
        Get
            Return Me.exceptionValue
        End Get
    End Property
#End Region
End Class
