Public NotInheritable Class Util
    'http://www.csharp411.com/the-proper-way-to-show-the-wait-cursor/
    Private Sub New()
        MyBase.New()
    End Sub

    Public Shared Sub SetStyle(ByVal control As System.Windows.Forms.Control, ByVal style As System.Windows.Forms.ControlStyles, ByVal value As Boolean)
        Dim setStyleMethodInfo As System.Reflection.MethodInfo

        setStyleMethodInfo = control.GetType().GetMethod("SetStyle", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        setStyleMethodInfo.Invoke(control, New System.Object() {style, value})

        setStyleMethodInfo = Nothing
    End Sub

    Public Shared Function GetApplicationIcon() As System.Drawing.Icon
        Return System.Drawing.Icon.ExtractAssociatedIcon(
            System.Reflection.Assembly.GetEntryAssembly().Location)
    End Function

    Public Shared Function CreateTelnetSession(ats As AutoTelnetScript, parameters As System.Collections.Generic.Dictionary(Of String, String)) As TelnetSession
        Dim host = Util.ReplaceParameter(ats.Host, ats, parameters)
        Dim session = New TelnetSession(host, ats.Port)
        session.DelayReadTime = ats.DelayReadTime
        session.AttemptsRetryReading = ats.AttemptsRetryReading
        session.RemoveRemoveANSIEscapeSequencesFromOutput = ats.RemoveRemoveANSIEscapeSequencesFromOutput
        Return session
    End Function

    Public Shared Function CreateTelnetSessionCommands(ats As AutoTelnetScript, parameters As System.Collections.Generic.Dictionary(Of String, String)) As System.Collections.Specialized.StringCollection
        Dim commands As New System.Collections.Specialized.StringCollection

        If ats.SendUser Then commands.Add(ats.User)

        If ats.SendPassword Then commands.Add(ats.PasswordDecrypted)


        If Not String.IsNullOrEmpty(ats.Text) Then
            For Each line In ats.Text.Split(New String() {ControlChars.Lf}, StringSplitOptions.None)
                'Sostituzione parametri
                line = Util.ReplaceParameter(line, ats, parameters)

                commands.Add(line)
            Next
        End If

        Return commands
    End Function

    Public Shared Function ReplaceParameter(text As String, ats As AutoTelnetScript, parameters As System.Collections.Generic.Dictionary(Of String, String)) As String
        Dim value = text
        If ats.Parameters IsNot Nothing AndAlso ats.Parameters.Count > 0 Then
            For Each p As AutoTelnetScriptParameter In ats.Parameters
                Dim parameterValue = UtilExpression.Evaluate(p.DefaultValue)
                If parameters.ContainsKey(p.Name) AndAlso Not String.IsNullOrWhiteSpace(parameters(p.Name)) Then
                    parameterValue = UtilExpression.Evaluate(parameters(p.Name))
                End If

                value = value.Replace(p.Name, parameterValue)
            Next
        End If

        Return value
    End Function

    Public Shared Sub Copy(ByVal sourceObject As Object, ByVal destinationObject As Object)

        For Each p As System.Reflection.PropertyInfo In destinationObject.GetType().GetProperties()
            Dim setValueFlag As Boolean = p.CanWrite

            'Esclusione proprietà la cui serializzazione
            'è mappata su un'altra proprietà
            If setValueFlag Then
                For Each a As Object In p.GetCustomAttributes(False)
                    If TypeOf a Is System.Xml.Serialization.XmlElementAttribute Then
                        setValueFlag = False
                        Exit For
                    End If
                Next
            End If

            If setValueFlag Then
                Dim sourceValue As Object = _
                    sourceObject.GetType.GetProperty(p.Name).GetValue(sourceObject, Nothing)
                p.SetValue(destinationObject, sourceValue, Nothing)
            End If
        Next
    End Sub

    Public Shared Function IsDisposable(ByVal obj As Object) As Boolean
        Return obj.GetType.GetInterface(GetType(System.IDisposable).Name) IsNot Nothing
    End Function

    ''' <summary>
    ''' If obj is an COM object call ReleaseComObject.
    ''' If obj is an disposable object call Dispose.
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Shared Sub RealeaseResources(ByVal obj As Object)
        If obj IsNot Nothing Then
            If obj.GetType().IsCOMObject Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            End If

            If Util.IsDisposable(obj) Then
                DirectCast(obj, System.IDisposable).Dispose()
            End If
        End If
    End Sub

    'Public Shared ReadOnly DefaultNullValue As Object = System.DBNull.Value
    'Public Shared ReadOnly DefaultNullValueDescription As String = "Not selected"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="enumType"></param>
    ''' <param name="allowNullValue"></param>
    ''' <param name="useUnderlyingType">True use the UnderlyingType of the Enum for the value, False use Enum Type for the value</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Overloads Shared Function GetDictionaryBindingSource( _
        ByVal enumType As System.Type, _
        ByVal allowNullValue As Boolean, _
        ByVal useUnderlyingType As Boolean) As System.Windows.Forms.BindingSource
        Dim dictionary As New System.Collections.Generic.Dictionary(Of Object, String)

        If allowNullValue Then
            dictionary.Add(System.DBNull.Value, "Not selected")
        End If

        For Each value As [Enum] In System.Enum.GetValues(enumType)
            If useUnderlyingType Then
                dictionary.Add( _
                    System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(enumType)), value.GetDescription())
            Else
                dictionary.Add(value, value.GetDescription())
            End If
        Next

        Return New System.Windows.Forms.BindingSource(dictionary, String.Empty)
    End Function

#Region "Gestione Licenza"
    Public Shared Function CheckEulaAccepted(ByVal companyName As String, ByVal productName As String) As Boolean
        Const EulaAcceptedValueName As String = "EulaAccepted"
        Dim registryKey As String = String.Format("Software\{0}\{1}", _
            companyName, productName)

        Dim key = My.Computer.Registry.CurrentUser.OpenSubKey(registryKey, True)
        Dim value As Object = Nothing

        If key IsNot Nothing Then
            value = key.GetValue(EulaAcceptedValueName)
        End If

        If key Is Nothing OrElse _
            value Is Nothing OrElse _
            String.IsNullOrEmpty(value.ToString()) OrElse _
            value.ToString <> "1" Then

            'Visualizzazione Dialog
            Using frm As New LicenseForm
                If frm.ShowDialog() <> DialogResult.OK Then
                    Return False
                End If
            End Using

            'Creazione Key
            If key Is Nothing Then
                key = My.Computer.Registry.CurrentUser.CreateSubKey(registryKey)
            End If

            'Impostazione Valore
            If value Is Nothing OrElse _
                String.IsNullOrEmpty(value.ToString()) OrElse _
                value.ToString <> "1" Then
                key.SetValue(EulaAcceptedValueName, 1, Microsoft.Win32.RegistryValueKind.DWord)
            End If
        End If

        Return True
    End Function
#End Region

End Class
