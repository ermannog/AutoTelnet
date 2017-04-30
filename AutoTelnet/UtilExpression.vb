Public NotInheritable Class UtilExpression
    Private Sub New()
        MyBase.New()
    End Sub

    Public Const ExpressionPrefix = "{"c
    Public Const ExpressionSuffix = "}"c
    Public Const FormatSeparator = ":"c
    Public Const ParameterSeparator = "="c

    Public Enum ExpressionIDs As Integer
        <UtilExpression.Hidden(True)>
        Unknown = System.Int32.MinValue

        <System.ComponentModel.Description("Current date and time")>
        <UtilExpression.Formattable(True)>
        <UtilExpression.DefaultFormat("yyyy-MM-dd-HH-mm")>
        [Now]

        <System.ComponentModel.Description("Nework domain name of current user")>
        CurrentDomain

        <System.ComponentModel.Description("Domain in which the local computer is registered")>
        DomainName

        <System.ComponentModel.Description("NetBIOS name of this local computer")>
        MachineName

        '<System.ComponentModel.Description("Suspends execution for the specified number of milliseconds")>
        '<UtilExpression.Parameterable(True)>
        '<UtilExpression.DefaultParameter("1000")>
        'Sleep
    End Enum

    Public Shared Function GetValue(id As ExpressionIDs, format As String, parameter As String) As String
        Dim value = String.Empty
        Dim stringFormat As String = String.Empty
        If String.IsNullOrWhiteSpace(format) Then
            stringFormat = "{0}"
        Else
            stringFormat = "{0:" & format & "}"
        End If

        Select Case id
            Case ExpressionIDs.Now
                value = String.Format(stringFormat, Now)
            Case ExpressionIDs.CurrentDomain
                value = System.Environment.UserDomainName
            Case ExpressionIDs.MachineName
                value = System.Environment.MachineName
            Case ExpressionIDs.DomainName
                value = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName
        End Select

        Return value
    End Function

    Public Shared Function Evaluate(expression As String) As String
        Dim value = expression

        Dim id = UtilExpression.GetID(expression)
        If id <> ExpressionIDs.Unknown Then
            Dim format = UtilExpression.GetFormat(expression)
            Dim parameter = UtilExpression.GetParameter(expression)

            value = UtilExpression.GetValue(id, format, parameter)
        End If

        Return value
    End Function

    Public Shared Function GetExpression(id As ExpressionIDs, format As String, parameter As String) As String
        Dim expression = UtilExpression.ExpressionPrefix & id.ToString()

        If Not String.IsNullOrWhiteSpace(format) Then
            expression &= UtilExpression.FormatSeparator & format
        End If

        If Not String.IsNullOrWhiteSpace(parameter) Then
            expression &= UtilExpression.ParameterSeparator & parameter
        End If

        expression &= UtilExpression.ExpressionSuffix

        Return expression
    End Function

    Public Shared Function GetID(expression As String) As UtilExpression.ExpressionIDs
        For Each id As UtilExpression.ExpressionIDs In GetType(UtilExpression.ExpressionIDs).GetEnumValues()
            Dim name = System.Enum.GetName(GetType(UtilExpression.ExpressionIDs), id)

            If expression.StartsWith(UtilExpression.ExpressionPrefix & name) AndAlso expression.EndsWith(UtilExpression.ExpressionSuffix) Then
                Return id
            End If
        Next

        Return UtilExpression.ExpressionIDs.Unknown
    End Function

    Public Shared Function GetFormat(expression As String) As String
        If expression.StartsWith(UtilExpression.ExpressionPrefix) AndAlso expression.EndsWith(UtilExpression.ExpressionSuffix) Then
            Dim expressionWithoutPrefixSuffix = expression.TrimStart(UtilExpression.ExpressionPrefix)
            expressionWithoutPrefixSuffix = expressionWithoutPrefixSuffix.TrimEnd(UtilExpression.ExpressionSuffix)

            Dim formatSeparatorIndex = expressionWithoutPrefixSuffix.IndexOf(UtilExpression.FormatSeparator)
            If formatSeparatorIndex <> -1 Then
                Return expressionWithoutPrefixSuffix.Substring(formatSeparatorIndex + 1, expressionWithoutPrefixSuffix.Length - formatSeparatorIndex - 1)
            End If
        End If

        Return String.Empty
    End Function

    Public Shared Function GetParameter(expression As String) As String
        If expression.StartsWith(UtilExpression.ExpressionPrefix) AndAlso expression.EndsWith(UtilExpression.ExpressionSuffix) Then
            Dim expressionWithoutPrefixSuffix = expression.TrimStart(UtilExpression.ExpressionPrefix)
            expressionWithoutPrefixSuffix = expressionWithoutPrefixSuffix.TrimEnd(UtilExpression.ExpressionSuffix)

            If expressionWithoutPrefixSuffix.IndexOf(UtilExpression.ParameterSeparator) <> -1 Then
                Return expressionWithoutPrefixSuffix.Split(UtilExpression.ParameterSeparator)(1)
            End If
        End If

        Return String.Empty
    End Function

    <System.AttributeUsage(System.AttributeTargets.Field)>
    Public Class HiddenAttribute
        Inherits System.Attribute

        Private hiddenValue As Boolean = False

        Public ReadOnly Property Hidden As Boolean
            Get
                Return Me.hiddenValue
            End Get
        End Property

        Public Sub New(ByVal hidden As Boolean)
            Me.hiddenValue = hidden
        End Sub
    End Class

    <System.AttributeUsage(System.AttributeTargets.Field)>
    Public Class DefaultFormatAttribute
        Inherits System.Attribute

        Private formatValue As String = String.Empty

        Public ReadOnly Property Format As String
            Get
                Return Me.formatValue
            End Get
        End Property

        Public Sub New(ByVal format As String)
            Me.formatValue = format
        End Sub
    End Class

    <System.AttributeUsage(System.AttributeTargets.Field)>
    Public Class FormattableAttribute
        Inherits System.Attribute

        Private formattableValue As Boolean = False

        Public ReadOnly Property Formattable As Boolean
            Get
                Return Me.formattableValue
            End Get
        End Property

        Public Sub New(ByVal formattable As Boolean)
            Me.formattableValue = formattable
        End Sub
    End Class

    <System.AttributeUsage(System.AttributeTargets.Field)>
    Public Class DefaultParameterAttribute
        Inherits System.Attribute

        Private parameterValue As String = String.Empty

        Public ReadOnly Property Parameter As String
            Get
                Return Me.parameterValue
            End Get
        End Property

        Public Sub New(ByVal parameter As String)
            Me.parameterValue = parameter
        End Sub
    End Class

    <System.AttributeUsage(System.AttributeTargets.Field)>
    Public Class ParameterableAttribute
        Inherits System.Attribute

        Private parameterableValue As Boolean = False

        Public ReadOnly Property Parameterable As Boolean
            Get
                Return Me.parameterableValue
            End Get
        End Property

        Public Sub New(ByVal parameterable As Boolean)
            Me.parameterableValue = parameterable
        End Sub
    End Class
End Class
