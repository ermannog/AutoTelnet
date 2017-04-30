Class TelnetSessionOld

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
    Private portValue As UInt16 = TelnetSessionOld.DefaultTelnetPort
    Public ReadOnly Property Port As UInt16
        Get
            Return Me.portValue
        End Get
    End Property
#End Region

#Region "Property DelayReadTime"
    Public Const DelayReadTimeDefault As UInt16 = TelnetClient.DelayReadTimeDefault

    ''' <summary>
    ''' Millisecond wait before read data when invoke Read method
    ''' </summary>
    ''' <remarks></remarks>
    Public DelayReadTime As UInt16 = TelnetSessionOld.DelayReadTimeDefault
#End Region

    Public Property WriteLogFile As Boolean = False
    Public Property LogFile As String = String.Empty
    Public Property LogfileAppend As Boolean = False

    Public Property ShowOutputDialog As Boolean = False
    Public Property OutputDialogOwner As System.Windows.Forms.IWin32Window = Nothing
    Private outputDialog As OutputForm = Nothing

    Public Sub New(hostName As String)
        Me.hostnameValue = hostName
        Me.portValue = Port

        Me.LogFile = System.IO.Path.Combine(Application.StartupPath, Application.ProductName & ".log")

        Me.OutputDialogOwner = System.Windows.Forms.Form.ActiveForm
    End Sub

    Public Sub SendCommands(commands As System.Collections.Specialized.StringCollection)
        'Inizializzazione OutputForm
        If Me.ShowOutputDialog Then
            Me.outputDialog = New OutputForm
            Me.outputDialog.Show(Me.OutputDialogOwner)
        End If

        Try
            'Creazione sessione Telnet
            Dim telnet As New TelnetClient(Me.hostnameValue, Me.portValue)
            telnet.DelayReadTime = Me.DelayReadTime

            'Connessione
            Try
                Me.ManageOutputInformation(String.Format("Connecting to {0} on TCP port {1}...", Me.hostnameValue, Me.portValue))
                telnet.Connect()
                Me.ManageOutputInformation("Connection established.")

                'Lettura risposta
                telnet.Read()
                Me.ManageOutputResponse(telnet.Response)
            Catch ex As Exception
                Me.ManageOutputError("Error during connection:", ex)
            End Try

            'Invio Comandi
            If commands IsNot Nothing AndAlso commands.Count > 0 Then
                For Each cmd In commands
                    'Invio comando
                    Try
                        Me.ManageOutputCommand(cmd)
                        telnet.Write(cmd)
                    Catch ex As Exception
                        Me.ManageOutputError("Error during send command:", ex)
                    End Try

                    'Lettura risposta
                    Try
                        telnet.Read()
                        Me.ManageOutputResponse(telnet.Response)
                    Catch ex As Exception
                        Me.ManageOutputError("Error during read response:", ex)
                    End Try
                Next
            End If

            'Lettura risposta
            If commands IsNot Nothing AndAlso commands.Count > 0 Then

            End If

            'Chiusura connessione
            Try
                Me.ManageOutputInformation("Connection closing...")
                telnet.Close()
                Me.ManageOutputInformation("Connection closed.")
            Catch ex As Exception
                Me.ManageOutputError("Error during close connection:", ex)
            End Try
        Catch ex As Exception
            Me.ManageOutputError("Error during telnet session:", ex)
        End Try
    End Sub

    Private Sub ManageOutputInformation(messagetext As String)
        If Not Me.ShowOutputDialog AndAlso Not Me.WriteLogFile Then Exit Sub

        Dim logText = messagetext

        If Me.ShowOutputDialog Then
            Me.outputDialog.AddLineInformation(logText)
        End If
    End Sub

    Private Sub ManageOutputCommand(messagetext As String)
        If Not Me.ShowOutputDialog AndAlso Not Me.WriteLogFile Then Exit Sub

        Dim logText = messagetext

        If Me.ShowOutputDialog Then
            Me.outputDialog.AddTextCommand(logText)
        End If
    End Sub

    Private Sub ManageOutputResponse(messagetext As String)
        If Not Me.ShowOutputDialog AndAlso Not Me.WriteLogFile Then Exit Sub

        Dim logText = messagetext

        If Me.ShowOutputDialog Then
            Me.outputDialog.AddLineResponse(logText)
        End If
    End Sub

    Private Sub ManageOutputError(messagetext As String, ex As System.Exception)
        If Not Me.ShowOutputDialog AndAlso Not Me.WriteLogFile Then Exit Sub

        Dim logText = messagetext

        If ex IsNot Nothing Then
            If Not String.IsNullOrWhiteSpace(logText) Then
                logText &= " " & ex.Message
            End If
        End If

        If Me.ShowOutputDialog Then
            Me.outputDialog.AddLineError(logText)
        End If
    End Sub



End Class
