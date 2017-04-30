<Serializable()>
Public Class AutoTelnetScriptParameterCollection
    Inherits Collections.CollectionBase

    Public Sub New()
        MyBase.New()
    End Sub

    Public Overridable Function Add(ByVal name As String, ByVal defaultValue As String) As Integer
        Return MyBase.List.Add(New AutoTelnetScriptParameter(name, defaultValue))
    End Function

    Public Overridable Function Add(ByVal item As AutoTelnetScriptParameter) As Integer
        Return MyBase.List.Add(item)
    End Function

    Friend Overloads Sub Remove(ByVal name As String)
        MyBase.List.Remove(Me.Item(name))
    End Sub

    Friend Overloads Sub Remove(ByVal item As AutoTelnetScriptParameter)
        MyBase.List.Remove(item)
    End Sub

    Public Function ContainsName(name As String) As Boolean
        ' If value is not of type Int16, this will return false.
        'Return MyBase.List.Contain(value)
        Return (From p In MyBase.List.AsQueryable()
                Where DirectCast(p, AutoTelnetScriptParameter).Name.ToLower = name.ToLower).SingleOrDefault() IsNot Nothing
    End Function

#Region "Proprietà Item"
    Default Public Overloads ReadOnly Property Item(ByVal name As String) As AutoTelnetScriptParameter
        Get
            For Each innerItem In MyBase.List
                'Confronto indipendente da convenzioni linguistiche
                'e senza distinzione tra maiuscole e minuscole
                If String.Equals(DirectCast(innerItem, AutoTelnetScriptParameter).Name, name, StringComparison.OrdinalIgnoreCase) Then
                    Return DirectCast(innerItem, AutoTelnetScriptParameter)
                End If
            Next

            Throw New ArgumentOutOfRangeException("name", name, _
                Me.GetType.Name & "." & System.Reflection.MethodBase.GetCurrentMethod().Name)
        End Get
    End Property

    Default Public Overloads ReadOnly Property Item(ByVal index As Integer) As AutoTelnetScriptParameter
        Get
            Return DirectCast(MyBase.List.Item(index), AutoTelnetScriptParameter)
        End Get
    End Property
#End Region

End Class

<Serializable()>
Public Class AutoTelnetScriptParameter
    Public Sub New()
    End Sub

    Public Sub New(ByVal name As String, ByVal defaultValue As String)
        'Si imposta direttamente la proprietà per lanciare
        'l'eccezione in caso di name null
        Me.Name = name
        Me.DefaultValue = defaultValue
    End Sub

    <System.ComponentModel.DefaultValue("")>
    Public Property Name As String = String.Empty

    <System.ComponentModel.DefaultValue("")>
    Public Property DefaultValue As String = String.Empty
End Class

