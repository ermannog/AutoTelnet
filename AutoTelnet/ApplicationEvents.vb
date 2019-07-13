Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Public Modalita As ModalitaApplicative = ModalitaApplicative.GUI
        Public Enum ModalitaApplicative As Integer
            GUI = 0
            Batch = 1
        End Enum

        Const CommandLineOptionIDHelp As String = "/?"
        Const CommandLineOptionIDNoGUI As String = "/nogui"
        Const CommandLineOptionIDConfigurationFile As String = "/f:"
        Const CommandLineOptionIDParameter As String = "/p:"

        Private startupConfigurationFileValue As String = String.Empty
        Public ReadOnly Property StartupConfigurationFile As String
            Get
                Return Me.startupConfigurationFileValue
            End Get
        End Property

        Private startupParametersValue As New System.Collections.Generic.Dictionary(Of String, String)
        Public ReadOnly Property StartupParameters As System.Collections.Generic.Dictionary(Of String, String)
            Get
                Return Me.startupParametersValue
            End Get
        End Property


        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            '*** Start Test ***
            'Me.Modalita = ModalitaApplicative.Batch
            'e.Cancel = True
            'UtilMsgBox.ShowMessage("Test")
            'UtilBatchOutputFileWriter.Initialize("out.txt", UtilBatchOutputFileWriter.OutputModes.Append)
            'UtilBatchOutputFileWriter.Write("Test")
            'Exit Sub
            '*** End Test ***

            'Controllo licenza 
            Try
                If Not Util.CheckEulaAccepted(My.Application.Info.CompanyName, My.Application.Info.ProductName) Then
                    e.Cancel = True
                    System.Environment.Exit(0)
                End If
            Catch ex As Exception
                UtilMsgBox.ShowErrorException("Error during check EULA accepted.", ex, True)
                e.Cancel = True
                Exit Sub
            End Try

            'Se l'applicativo viene avviato senza parametri si visualizza la form di configurazione
            If e.CommandLine.Count = 0 Then
                Me.Modalita = ModalitaApplicative.GUI
                Exit Sub
            End If

            'Gestione Help
            If e.CommandLine.Contains(MyApplication.CommandLineOptionIDHelp, StringComparer.OrdinalIgnoreCase) Then
                Dim helpText As String = String.Format("AutoTelnet [{0}] [{1}""file path""] [{2}ParameterName=""ParameterValue""]",
                                                       MyApplication.CommandLineOptionIDNoGUI,
                                                       MyApplication.CommandLineOptionIDConfigurationFile,
                                                       MyApplication.CommandLineOptionIDParameter) & ControlChars.NewLine
                helpText &= MyApplication.CommandLineOptionIDNoGUI & " - Batch mode" & ControlChars.NewLine
                helpText &= MyApplication.CommandLineOptionIDConfigurationFile & " - AutoTelnet configuration file" & ControlChars.NewLine
                helpText &= MyApplication.CommandLineOptionIDParameter & " - Parameter"

                UtilMsgBox.ShowMessage(helpText)
                e.Cancel = True
                Exit Sub
            End If

            Dim commandlineOptionsProcessed = 0

            'Gestione Modalità Batch
            Try
                If e.CommandLine.Contains(MyApplication.CommandLineOptionIDNoGUI, StringComparer.OrdinalIgnoreCase) Then
                    Me.Modalita = ModalitaApplicative.Batch
                    commandlineOptionsProcessed += 1
                    e.Cancel = True
                End If
            Catch ex As Exception
                UtilMsgBox.ShowErrorException("Error processing Batch Mode", ex, True)
            End Try

            'AutoTelnet Configuration File
            Try
                Dim commandLineConfigurationFile = e.CommandLine.Where(Function(p) p.IndexOf(MyApplication.CommandLineOptionIDConfigurationFile, StringComparison.CurrentCultureIgnoreCase) >= 0).SingleOrDefault()
                If Not String.IsNullOrWhiteSpace(commandLineConfigurationFile) Then
                    commandlineOptionsProcessed += 1
                    Me.startupConfigurationFileValue = System.Environment.ExpandEnvironmentVariables(commandLineConfigurationFile.Remove(0, MyApplication.CommandLineOptionIDConfigurationFile.Length))
                    If Not System.IO.File.Exists(Me.startupConfigurationFileValue) Then
                        UtilMsgBox.ShowError(String.Format("AutoTelnet configuration file {0} not exists.", Me.startupConfigurationFileValue), True)
                    End If
                End If
            Catch ex As Exception
                UtilMsgBox.ShowErrorException("Error processing AutoTelnet configuration file", ex, True)
            End Try

            'Estrazione Parametri
            Try
                Dim commandLineParameters = e.CommandLine.Where(Function(p) p.IndexOf(MyApplication.CommandLineOptionIDParameter, StringComparison.CurrentCultureIgnoreCase) >= 0)
                For Each clp In commandLineParameters
                    Dim parameterNameValue = clp.Remove(0, MyApplication.CommandLineOptionIDParameter.Length)
                    Dim equalSignIndex = parameterNameValue.IndexOf("="c)
                    If equalSignIndex >= 0 Then
                        Dim name = parameterNameValue.Substring(0, equalSignIndex)
                        Dim value = parameterNameValue.Substring(equalSignIndex + 1, parameterNameValue.Length - equalSignIndex - 1)
                        Me.startupParametersValue.Add(name, value)
                        commandlineOptionsProcessed += 1
                    Else
                        UtilMsgBox.ShowError(String.Format("Incorrect parameter option {0}", parameterNameValue), True)
                    End If
                Next
            Catch ex As Exception
                UtilMsgBox.ShowErrorException("Error processing parameters", ex, True)
            End Try

            'Check opzioni a riga di comando sconosciute
            If commandlineOptionsProcessed < e.CommandLine.Count Then
                UtilMsgBox.ShowError(String.Format("Error unknown options {0}", e.CommandLine.Count - commandlineOptionsProcessed), True)
            End If

            'Esecuzione script
            If Me.Modalita = ModalitaApplicative.Batch Then
                Dim successfulOutputText = String.Empty
                Dim failedOutputText = String.Empty

                Try
                    Dim ats As New AutoTelnetScript()

                    If ats.Deserialize(Me.startupConfigurationFileValue) Then
                        Dim logFile = Util.ReplaceParameter(ats.LogFile, ats, Me.startupParametersValue)
                        If Not String.IsNullOrWhiteSpace(logFile) Then
                            UtilLogFileWriter.Enable(logFile, ats.LogMode, ats.LogCommandAndResponseEntriesEncrypted)
                        End If

                        Dim outputFile = Util.ReplaceParameter(ats.BatchOutputFile, ats, Me.startupParametersValue)
                        If Not String.IsNullOrWhiteSpace(outputFile) Then
                            UtilBatchOutputFileWriter.Initialize(outputFile, ats.BatchOutputMode)
                        End If

                        successfulOutputText = Util.ReplaceParameter(ats.BatchSuccessfulOutputText, ats, Me.startupParametersValue)
                        failedOutputText = Util.ReplaceParameter(ats.BatchFailedOutputText, ats, Me.startupParametersValue)

                        'Creazione telnet session
                        Dim ts = Util.CreateTelnetSession(ats, Me.startupParametersValue)
                        Dim tsc = Util.CreateTelnetSessionCommands(ats, Me.startupParametersValue)

                        'Aggiunta handler eventi per gestione log
                        AddHandler ts.OutputInformationAdded, AddressOf My.Application.LogWriteNewEntryOnTelnetSessionOutputEvents
                        AddHandler ts.OutputCommandAdded, AddressOf My.Application.LogWriteNewEntryOnTelnetSessionOutputEvents
                        AddHandler ts.OutputResponseAdded, AddressOf My.Application.LogWriteNewEntryOnTelnetSessionOutputEvents
                        AddHandler ts.OutputErrorAdded, AddressOf My.Application.LogWriteNewEntryOnTelnetSessionOutputEvents

                        'Invio comandi
                        ts.SendCommands(tsc)

                        'Gestione Output
                        If Not ts.HasErrors Then
                            If String.IsNullOrWhiteSpace(successfulOutputText) Then
                                successfulOutputText = AutoTelnetScript.BatchSuccessfulOutputTextDefault
                            End If

                            UtilMsgBox.ShowMessage(successfulOutputText)

                            If UtilBatchOutputFileWriter.Enable Then
                                UtilBatchOutputFileWriter.Write(successfulOutputText)
                            End If
                        Else
                            If String.IsNullOrWhiteSpace(failedOutputText) Then
                                failedOutputText = AutoTelnetScript.BatchFailedOutputTextDefault
                            End If

                            UtilMsgBox.ShowMessage(failedOutputText)

                            If UtilBatchOutputFileWriter.Enable Then
                                UtilBatchOutputFileWriter.Write(failedOutputText)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    If String.IsNullOrWhiteSpace(failedOutputText) Then
                        failedOutputText = AutoTelnetScript.BatchFailedOutputTextDefault
                    End If
                    failedOutputText = UtilMsgBox.GetExceptionMessage(failedOutputText, ex)

                    UtilMsgBox.ShowErrorException(failedOutputText, ex, True)

                    If UtilBatchOutputFileWriter.Enable Then
                        UtilBatchOutputFileWriter.Write(failedOutputText)
                    End If
                End Try
            End If
        End Sub

#Region "Gestione Log in modalità batch"
        Friend Sub LogWriteNewEntryOnTelnetSessionOutputEvents(sender As Object, e As System.EventArgs)
            If Not UtilLogFileWriter.LogEnabled Then Exit Sub

            If TypeOf e Is TelnetSessionOutputInformationAddedEventArgs Then
                With DirectCast(e, TelnetSessionOutputInformationAddedEventArgs)
                    UtilLogFileWriter.WriteNewEntry(UtilLogFileWriter.EntryTypes.Information, .Text.TrimNewLine())
                End With
            ElseIf TypeOf e Is TelnetSessionOutputCommandAddedEventArgs Then
                With DirectCast(e, TelnetSessionOutputCommandAddedEventArgs)
                    UtilLogFileWriter.WriteNewEntry(UtilLogFileWriter.EntryTypes.Command, .Text.TrimNewLine())
                End With
            ElseIf TypeOf e Is TelnetSessionOutputResponseAddedEventArgs Then
                With DirectCast(e, TelnetSessionOutputResponseAddedEventArgs)
                    UtilLogFileWriter.WriteNewEntry(UtilLogFileWriter.EntryTypes.Response, .Text.TrimNewLine())
                End With
            ElseIf TypeOf e Is TelnetSessionOutputErrorAddedEventArgs Then
                With DirectCast(e, TelnetSessionOutputErrorAddedEventArgs)
                    UtilLogFileWriter.WriteNewEntry(UtilLogFileWriter.EntryTypes.Error, .Text.TrimNewLine())
                End With
            End If
        End Sub
#End Region
    End Class

End Namespace