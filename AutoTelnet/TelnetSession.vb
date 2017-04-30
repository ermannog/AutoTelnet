Public Class TelnetSession

#Region "Property Hostname"
    Private hostnameValue As String = String.Empty
    Public ReadOnly Property Hostname As String
        Get
            Return Me.hostnameValue
        End Get
    End Property
#End Region

#Region "Property Port"
    Public Const DefaultTelnetPort As UInt16 = 23
    Private portValue As UInt16 = TelnetSession.DefaultTelnetPort
    Public ReadOnly Property Port As UInt16
        Get
            Return Me.portValue
        End Get
    End Property
#End Region

#Region "Property DelayReadTime"
    Public Const DelayReadTimeDefault As UInt16 = 500 'TelnetClient.DelayReadTimeDefault

    ''' <summary>
    ''' Millisecond wait before read data when invoke Read method
    ''' </summary>
    ''' <remarks></remarks>
    Public DelayReadTime As UInt16 = TelnetSession.DelayReadTimeDefault
#End Region

#Region "Property AttemptsRetryReading"
    Public Const AttemptsRetryReadingDefault As UInt16 = 0 'TelnetClient.AttemptsRetryReadingDefault

    ''' <summary>
    ''' Number of retry reading attempts with no data before quit read method
    ''' </summary>
    ''' <remarks></remarks>
    Public AttemptsRetryReading As UInt16 = TelnetSession.AttemptsRetryReadingDefault
#End Region

#Region "Property SendEndOfLine"
    Public Const EndOfLineDefault As TelnetClient.EndOfLineValues = TelnetClient.EndOfLineValues.CrLf

    Public Property SendEndOfLine As TelnetClient.EndOfLineValues = TelnetSession.EndOfLineDefault
#End Region

#Region "Property RemoveRemoveANSIEscapeSequencesFromResponse"
    Public Const RemoveRemoveANSIEscapeSequencesFromOutputDefault As Boolean = True

    Public Property RemoveRemoveANSIEscapeSequencesFromOutput As Boolean = TelnetSession.RemoveRemoveANSIEscapeSequencesFromOutputDefault
#End Region

#Region "Property OutputExecutionTerminatedSuccessfulText"
    Public Const OutputExecutionTerminatedSuccessfulTextDefault = "Script execution successful."

    Public Property OutputExecutionTerminatedSuccessfulText As String = TelnetSession.OutputExecutionTerminatedSuccessfulTextDefault
#End Region

#Region "Property OutputExecutionTerminatedFailedText"
    Public Const OutputExecutionTerminatedFailedTextDefault = "Script execution failed."

    Public Property OutputExecutionTerminatedFailedText As String = TelnetSession.OutputExecutionTerminatedFailedTextDefault
#End Region

#Region "Gestione Evento OutputInformationAdded"
    'Definizione Evento
    Public Event OutputInformationAdded As System.EventHandler(Of TelnetSessionOutputInformationAddedEventArgs)

    'Definizione Sub per il Raise dell'evento
    Protected Overridable Sub OnOutputInformationAdded(ByVal sender As Object, ByVal e As TelnetSessionOutputInformationAddedEventArgs)
        RaiseEvent OutputInformationAdded(sender, e)
    End Sub
#End Region

#Region "Gestione Evento OutputCommandAdded"
    'Definizione Evento
    Public Event OutputCommandAdded As System.EventHandler(Of TelnetSessionOutputCommandAddedEventArgs)

    'Definizione Sub per il Raise dell'evento
    Protected Overridable Sub OnOutputCommandAdded(ByVal sender As Object, ByVal e As TelnetSessionOutputCommandAddedEventArgs)
        RaiseEvent OutputCommandAdded(sender, e)
    End Sub
#End Region

#Region "Gestione Evento OutputResponseAdded"
    'Definizione Evento
    Public Event OutputResponseAdded As System.EventHandler(Of TelnetSessionOutputResponseAddedEventArgs)

    'Definizione Sub per il Raise dell'evento
    Protected Overridable Sub OnOutputResponseAdded(ByVal sender As Object, ByVal e As TelnetSessionOutputResponseAddedEventArgs)
        RaiseEvent OutputResponseAdded(sender, e)
    End Sub
#End Region

#Region "Gestione Evento OutputErrorAdded"
    'Definizione Evento
    Public Event OutputErrorAdded As System.EventHandler(Of TelnetSessionOutputErrorAddedEventArgs)

    'Definizione Sub per il Raise dell'evento
    Protected Overridable Sub OnOutputErrorAdded(ByVal sender As Object, ByVal e As TelnetSessionOutputErrorAddedEventArgs)
        Me.hasErrorsValue = True
        RaiseEvent OutputErrorAdded(sender, e)
    End Sub
#End Region

#Region "Property HasErrors"
    Private hasErrorsValue As Boolean = False

    Public ReadOnly Property HasErrors As Boolean
        Get
            Return Me.hasErrorsValue
        End Get
    End Property
#End Region

#Region "Metodo New"
    Public Sub New(hostName As String)
        Me.hostnameValue = hostName
    End Sub

    Public Sub New(hostName As String, port As UInt16)
        Me.New(hostName)
        Me.portValue = port
    End Sub
#End Region

    Public Property StopExecuteCommandsFlag As Boolean = False

    Public Sub SendCommands(commands As System.Collections.Specialized.StringCollection)
        Me.StopExecuteCommandsFlag = False
        Me.hasErrorsValue = False

        Try
            'Creazione sessione Telnet
            Using telnet = New TelnetClient(Me.hostnameValue, Me.portValue)
                'telnet.SendEndOfLine = Me.SendEndOfLine
                'telnet.DelayReadTime = Me.DelayReadTime
                'telnet.AttemptsRetryReading = Me.AttemptsRetryReading

                'Connessione
                Try
                    Me.AddOutputInformation(String.Format("Connecting to {0} on TCP port {1}...", Me.hostnameValue, Me.portValue))
                    telnet.Connect()
                    Me.AddOutputInformation("Connection established.")

                    'Lettura risposta
                    telnet.Read(Me.DelayReadTime, Me.AttemptsRetryReading)

                    If Me.RemoveRemoveANSIEscapeSequencesFromOutput Then
                        Me.AddOutputResponse(telnet.Response.RemoveANSIEscapeSequences())
                    Else
                        Me.AddOutputResponse(telnet.Response)
                    End If
                Catch ex As Exception
                    Me.AddOutputError("Connection", ex)
                    Exit Sub
                End Try

                'Invio Comandi
                If commands IsNot Nothing AndAlso commands.Count > 0 Then
                    For Each cmd In commands
                        'Check flag Stop Execute
                        If Me.StopExecuteCommandsFlag Then
                            Me.AddOutputInformation("The command execution has been interrupted.")
                            Exit For
                        End If

                        'Invio comando
                        Try
                            Me.AddOutputCommand(cmd) ' & System.Environment.NewLine)
                            telnet.Write(cmd, Me.SendEndOfLine)
                            'telnet.Write(Me.AddEndOfLineChar(cmd))
                        Catch ex As Exception
                            Me.AddOutputError("Send command", ex)
                            Exit For
                        End Try

                        'Lettura risposta
                        Try
                            telnet.Read(Me.DelayReadTime, Me.AttemptsRetryReading)
                            'Me.AddOutputResponse(telnet.Response)

                            If Me.RemoveRemoveANSIEscapeSequencesFromOutput Then
                                Me.AddOutputResponse(telnet.Response.RemoveANSIEscapeSequences())
                            Else
                                Me.AddOutputResponse(telnet.Response)
                            End If
                        Catch ex As Exception
                            Me.AddOutputError("Read response", ex)
                        End Try
                    Next
                End If

                'Chiusura connessione
                Try
                    Me.AddOutputInformation("Connection closing...")
                    telnet.Close()
                    Me.AddOutputInformation("Connection closed.")
                Catch ex As Exception
                    Me.AddOutputError("Close connection", ex)
                End Try
            End Using
        Catch ex As Exception
            Me.AddOutputError("Telnet session", ex)
        End Try
    End Sub

    Private Sub AddOutputInformation(text As String)
        Me.OnOutputInformationAdded(Me, New TelnetSessionOutputInformationAddedEventArgs(text))
    End Sub

    Private Sub AddOutputCommand(text As String)
        'Me.outputValue.Append(text)
        Me.OnOutputCommandAdded(Me, New TelnetSessionOutputCommandAddedEventArgs(text))
    End Sub

    Private Sub AddOutputResponse(text As String)
        Me.OnOutputResponseAdded(Me, New TelnetSessionOutputResponseAddedEventArgs(text))
    End Sub

    Private Sub AddOutputError(operation As String, ex As System.Exception)
        Me.OnOutputErrorAdded(Me, New TelnetSessionOutputErrorAddedEventArgs("Error during " & operation & ":" & ex.Message, ex))
    End Sub

End Class

