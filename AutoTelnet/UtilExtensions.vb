Public Module UtilExtensions
    <System.Runtime.CompilerServices.Extension()>
    Public Sub SetWaitCursor(control As System.Windows.Forms.Control, ByVal state As Boolean)
        If state Then
            control.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Else
            control.Cursor = System.Windows.Forms.Cursors.Default
        End If

        For Each c As System.Windows.Forms.Control In control.Controls
            c.SetWaitCursor(state)
        Next
    End Sub

    <System.Runtime.CompilerServices.Extension()>
    Public Function SplitLines(text As String) As System.Collections.Specialized.StringCollection
        If String.IsNullOrWhiteSpace(text) Then Return Nothing

        Dim lines As New System.Collections.Specialized.StringCollection

        Using sr As New System.IO.StringReader(text)
            Dim line As String = Nothing
            Do
                line = sr.ReadLine()

                If line Is Nothing Then Exit Do

                lines.Add(line & ControlChars.NewLine)
            Loop
        End Using

        Return lines
    End Function

    '<System.Runtime.CompilerServices.Extension()>
    'Public Function StripExtended(text As String) As String
    '    Dim buffer As New System.Text.StringBuilder(text.Length)

    '    For Each c In text
    '        'In .NET chars are UTF-16
    '        Dim i = Convert.ToUInt16(c)
    '        ' The basic characters have the same code points as ASCII, and the extended characters are bigger
    '        If ((i >= 32) And (i <= 126)) Then buffer.Append(c)
    '    Next

    '    Return buffer.ToString()
    'End Function

    '<System.Runtime.CompilerServices.Extension()>
    'Public Function RemoveANSIEscapeSequences(text As String) As String
    '    'http://www.ecma-international.org/publications/files/ECMA-ST/Ecma-048.pdf
    '    'https://en.wikipedia.org/wiki/ANSI_escape_code#CSI_codes

    '    'Regular Expression: (\x9B|\x1B\[)[0-?]*[ -\/]*[@-~]

    '    'Return System.Text.RegularExpressions.Regex.Replace(text, "(\x9B|\x1B\[)[0-?]*[ -\/]*[@-~]", String.Empty)
    '    'Dim value = System.Text.RegularExpressions.Regex.Replace(text, "s/\x1B\[([0-9]{1,2}(;[0-9]{1,2})?)?[m|K]//g", String.Empty)
    '    Dim g = System.Text.RegularExpressions.Regex.IsMatch(text, "\x1b\[[0-9;]*m")
    '    Dim value = System.Text.RegularExpressions.Regex.Replace(text, "\x1b\[[0-9;]*m", String.Empty)
    '    Return value
    'End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function RemoveANSIEscapeSequences(text As String) As String
        'http://ascii-table.com/ansi-escape-sequences.php
        'http://www.ascii-code.com/

        Dim sb As New System.Text.StringBuilder()
        Dim i = 0
        Dim iMax = text.Length

        Const ESC = ChrW(27)

        While i < iMax
            Dim c = AscW(text(i))

            If text(i) = ESC Then
                i += 1

                While i < iMax AndAlso "HfABCDsuJKmhlp".IndexOf(text(i)) = -1
                    i += 1
                End While

                i += 1
            ElseIf Char.IsControl(text(i)) AndAlso
                (text(i) <> ControlChars.Tab And text(i) <> ControlChars.Lf And text(i) <> ControlChars.Cr) Then
                i += 1
            Else
                sb.Append(text(i))
                i += 1
            End If
        End While

        Return sb.ToString()
    End Function



    <System.Runtime.CompilerServices.Extension()> _
    Public Sub Unbind(ByVal combobox As System.Windows.Forms.ComboBox)
        If combobox.DataSource IsNot Nothing Then
            If Util.IsDisposable(combobox.DataSource) Then
                Util.RealeaseResources(combobox.DataSource)
            End If

            combobox.DataSource = Nothing
            combobox.DisplayMember = String.Empty
            combobox.ValueMember = String.Empty
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="combobox"></param>
    ''' <param name="enumType"></param>
    ''' <param name="allowNullValue"></param>
    ''' <param name="useUnderlyingType">True use the UnderlyingType of the Enum for the value (useful if is necessary compare the SelectedValue with a value that are not an enum member, for example property of Linq class), False use Enum Type for the value</param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub BindEnum(ByVal combobox As System.Windows.Forms.ComboBox, _
                  ByVal enumType As System.Type, _
                  ByVal allowNullValue As Boolean, _
                  ByVal useUnderlyingType As Boolean)
        Dim source As System.Windows.Forms.BindingSource = _
            Util.GetDictionaryBindingSource(enumType, allowNullValue, useUnderlyingType)

        'Reset Bind
        If combobox.DataSource IsNot Nothing Then combobox.Unbind()

        'Bind combobox
        combobox.DisplayMember = "Value"
        combobox.ValueMember = "Key"
        combobox.DataSource = source

        'Impostazione Combobox
        combobox.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
    End Sub


    <System.Runtime.CompilerServices.Extension()> _
    Public Function GetDescription(ByVal enumValue As [Enum]) As String
        Dim description As String = enumValue.GetDescriptionAttributeValue()

        If String.IsNullOrEmpty(description) Then
            description = System.Enum.GetName(enumValue.GetType(), enumValue)
        End If

        Return description
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function GetDescriptionAttributeValue(ByVal enumValue As [Enum]) As String
        Dim name As String = System.Enum.GetName(enumValue.GetType(), enumValue)

        Dim field As System.Reflection.FieldInfo = _
            enumValue.GetType().GetField(System.Enum.GetName(enumValue.GetType(), enumValue), _
                Reflection.BindingFlags.Public Or Reflection.BindingFlags.Static)

        Dim description As String = String.Empty
        Dim fieldDescriptions() As Object = _
            field.GetCustomAttributes( _
                GetType(System.ComponentModel.DescriptionAttribute), False)
        If fieldDescriptions.Length > 0 Then
            description = DirectCast(fieldDescriptions(0),  _
                System.ComponentModel.DescriptionAttribute).Description
        End If

        Return description
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function GetDefautFormatAttributeValue(ByVal enumValue As [Enum]) As String
        Dim name As String = System.Enum.GetName(enumValue.GetType(), enumValue)

        Dim field As System.Reflection.FieldInfo = _
            enumValue.GetType().GetField(System.Enum.GetName(enumValue.GetType(), enumValue), _
                Reflection.BindingFlags.Public Or Reflection.BindingFlags.Static)

        Dim format As String = String.Empty
        Dim fieldDefaultFormats() As Object = field.GetCustomAttributes(GetType(UtilExpression.DefaultFormatAttribute), False)
        If fieldDefaultFormats.Length > 0 Then
            format = DirectCast(fieldDefaultFormats(0), UtilExpression.DefaultFormatAttribute).Format
        End If

        Return format
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function GetFormattableAttributeValue(ByVal enumValue As [Enum]) As Boolean
        Dim name As String = System.Enum.GetName(enumValue.GetType(), enumValue)

        Dim field As System.Reflection.FieldInfo = _
            enumValue.GetType().GetField(System.Enum.GetName(enumValue.GetType(), enumValue),
                Reflection.BindingFlags.Public Or Reflection.BindingFlags.Static)

        Dim formattable As Boolean = False
        Dim fieldFormattables() As Object = field.GetCustomAttributes(GetType(UtilExpression.FormattableAttribute), False)
        If fieldFormattables.Length > 0 Then
            formattable = DirectCast(fieldFormattables(0), UtilExpression.FormattableAttribute).Formattable
        End If

        Return formattable
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function GetDefautParameterAttributeValue(ByVal enumValue As [Enum]) As String
        Dim name As String = System.Enum.GetName(enumValue.GetType(), enumValue)

        Dim field As System.Reflection.FieldInfo = _
            enumValue.GetType().GetField(System.Enum.GetName(enumValue.GetType(), enumValue), _
                Reflection.BindingFlags.Public Or Reflection.BindingFlags.Static)

        Dim parameter As String = String.Empty
        Dim fieldDefaultParameters() As Object = field.GetCustomAttributes(GetType(UtilExpression.DefaultParameterAttribute), False)
        If fieldDefaultParameters.Length > 0 Then
            parameter = DirectCast(fieldDefaultParameters(0), UtilExpression.DefaultParameterAttribute).Parameter
        End If

        Return parameter
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function GetParameterableAttributeValue(ByVal enumValue As [Enum]) As Boolean
        Dim name As String = System.Enum.GetName(enumValue.GetType(), enumValue)

        Dim field As System.Reflection.FieldInfo = _
            enumValue.GetType().GetField(System.Enum.GetName(enumValue.GetType(), enumValue),
                Reflection.BindingFlags.Public Or Reflection.BindingFlags.Static)

        Dim Parameterable As Boolean = False
        Dim fieldParameterables() As Object = field.GetCustomAttributes(GetType(UtilExpression.ParameterableAttribute), False)
        If fieldParameterables.Length > 0 Then
            Parameterable = DirectCast(fieldParameterables(0), UtilExpression.ParameterableAttribute).Parameterable
        End If

        Return Parameterable
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function GetHiddenAttributeValue(ByVal enumValue As [Enum]) As Boolean
        Dim name As String = System.Enum.GetName(enumValue.GetType(), enumValue)

        Dim field As System.Reflection.FieldInfo = _
            enumValue.GetType().GetField(System.Enum.GetName(enumValue.GetType(), enumValue),
                Reflection.BindingFlags.Public Or Reflection.BindingFlags.Static)

        Dim hidden As Boolean = False
        Dim fieldHiddens() As Object = field.GetCustomAttributes(GetType(UtilExpression.HiddenAttribute), False)
        If fieldHiddens.Length > 0 Then
            Hidden = DirectCast(fieldHiddens(0), UtilExpression.HiddenAttribute).Hidden
        End If

        Return hidden
    End Function

#Region "Metodo CreateItem per ListView"
    <System.Runtime.CompilerServices.Extension()> _
    Public Function CreateItem(ByVal listView As System.Windows.Forms.ListView) As System.Windows.Forms.ListViewItem
        Return CreateItem(listView, String.Empty, Nothing)
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function CreateItem(ByVal listView As System.Windows.Forms.ListView, ByVal text As String) As System.Windows.Forms.ListViewItem
        Return CreateItem(listView, text, Nothing)
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function CreateItem(ByVal listView As System.Windows.Forms.ListView, ByVal text As String, ByVal subItemsText() As String) As System.Windows.Forms.ListViewItem
        Dim item As New System.Windows.Forms.ListViewItem

        If Not String.IsNullOrEmpty(text) Then
            item.Text = text
        End If

        For Each column As System.Windows.Forms.ColumnHeader In listView.Columns
            If subItemsText IsNot Nothing AndAlso subItemsText.Length - 1 >= column.Index Then
                item.SubItems.Add(subItemsText(column.Index))
            Else
                item.SubItems.Add(String.Empty)
            End If

        Next

        Return item
    End Function
#End Region

#Region "Metodo AddItem per ListView"
    <System.Runtime.CompilerServices.Extension()> _
    Public Function AddItem(ByVal listView As System.Windows.Forms.ListView, ByVal text As String) As System.Windows.Forms.ListViewItem
        Return listView.Items.Add(listView.CreateItem(text, Nothing))
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function AddItem(ByVal listView As System.Windows.Forms.ListView, ByVal text As String, ByVal subItemsText() As String) As System.Windows.Forms.ListViewItem
        Return listView.Items.Add(listView.CreateItem(text, subItemsText))
    End Function
#End Region

    <System.Runtime.CompilerServices.Extension()>
    Public Function TrimNewLine(text As String) As String
        Dim value = text

        While value.EndsWith(Environment.NewLine)
            value = value.Remove(value.LastIndexOf(Environment.NewLine))
        End While

        Return value
    End Function
End Module
