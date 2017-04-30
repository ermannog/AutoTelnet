Public NotInheritable Class UtilMsgBox
    Private Sub New()
        MyBase.New()
    End Sub

    Public Shared Function GetExceptionMessage(ByVal message As String, ByVal exception As System.Exception) As String
        Dim text As String = message

        Dim ex As System.Exception = exception

        While ex IsNot Nothing
            'Aggiunta Message
            If Not String.IsNullOrEmpty(ex.Message) Then
                If Not String.IsNullOrEmpty(text) Then _
                    text &= ControlChars.NewLine & ControlChars.NewLine
                text &= ex.Message
            End If

            'Aggiunta Source
            If Not String.IsNullOrEmpty(ex.Source) Then
                If Not String.IsNullOrEmpty(text) Then _
                    text &= ControlChars.NewLine
                text &= ex.GetType().ToString()
            End If

            'Aggiunta Error code
            Dim lastWin32Error = GetLastWin32Error(String.Empty)
            If Not String.IsNullOrEmpty(lastWin32Error) Then
                text &= ControlChars.NewLine & ControlChars.NewLine
                text &= "Last Win32 Error: " & lastWin32Error
            End If

            'Aggiunta StackTrace
            If Not String.IsNullOrEmpty(ex.StackTrace) Then
                If Not String.IsNullOrEmpty(text) Then _
                    text &= ControlChars.NewLine & ControlChars.NewLine
                text &= ex.StackTrace.Trim()
            End If

            ex = ex.InnerException
        End While

        Return text
    End Function

#Region "Method ShowErrorException"
    Public Overloads Shared Sub ShowErrorException(ByVal exception As System.Exception, ByVal abort As Boolean)
        ShowError(GetExceptionMessage(String.Empty, exception), abort)
    End Sub

    Public Overloads Shared Sub ShowErrorException(ByVal message As String, ByVal exception As System.Exception, ByVal abort As Boolean)
        ShowError(GetExceptionMessage(message, exception), abort)
    End Sub
#End Region

    Public Shared Function GetLastWin32Error(ByVal message As String) As String
        Dim text As String = message

        Dim ex As New System.ComponentModel.Win32Exception( _
            System.Runtime.InteropServices.Marshal.GetLastWin32Error())


        'Aggiunta Error code
        If ex.NativeErrorCode <> 0 Then
            If Not String.IsNullOrEmpty(text) Then _
                text &= ControlChars.NewLine & ControlChars.NewLine
            text &= "Error code: " & Hex(ex.NativeErrorCode) & " (" & ex.Message & ")"
        End If

        Return text
    End Function

#Region "Method ShowLastWin32Error"
    Public Overloads Shared Sub ShowLastWin32Error(ByVal abort As Boolean)
        ShowLastWin32Error(String.Empty, abort)
    End Sub

    Public Overloads Shared Sub ShowLastWin32Error(ByVal message As String, ByVal abort As Boolean)

        ShowMessage(GetLastWin32Error(message), _
            "Error", _
            System.Windows.Forms.MessageBoxIcon.Stop)

        If abort Then
            System.Environment.Exit(0)
        End If
    End Sub
#End Region

#Region "Method ShowMessage"
    Public Overloads Shared Function ShowMessage(ByVal text As String) As System.Windows.Forms.DialogResult
        If My.Application.Modalita = My.MyApplication.ModalitaApplicative.Batch Then
            UtilMsgBox.GUIConsoleWriter.WriteLine(text)
            Return DialogResult.None
        End If

        Return ShowMessage(text, String.Empty)
    End Function

    Public Overloads Shared Function ShowMessage(ByVal text As String, ByVal title As String) As System.Windows.Forms.DialogResult
        Return ShowMessage(text, title, System.Windows.Forms.MessageBoxIcon.None)
    End Function

    Public Overloads Shared Function ShowMessage(ByVal text As String, _
                ByVal icon As System.Windows.Forms.MessageBoxIcon) As System.Windows.Forms.DialogResult
        Return ShowMessage(text, String.Empty, icon)
    End Function

    Public Overloads Shared Function ShowMessage(ByVal text As String, _
                                  ByVal title As String, _
                                  ByVal icon As System.Windows.Forms.MessageBoxIcon) As System.Windows.Forms.DialogResult
        Return ShowMessage(text, title, System.Windows.Forms.MessageBoxButtons.OK, icon, System.Windows.Forms.MessageBoxDefaultButton.Button1)
    End Function

    Public Overloads Shared Function ShowMessage(ByVal text As String, _
                                  ByVal title As String, _
                                  ByVal buttons As System.Windows.Forms.MessageBoxButtons, _
                                  ByVal icon As System.Windows.Forms.MessageBoxIcon, _
                                  ByVal defaultButton As System.Windows.Forms.MessageBoxDefaultButton) As System.Windows.Forms.DialogResult
        ShowMessage = System.Windows.Forms.MessageBox.Show(text, _
            My.Application.Info.Title & " " & title, _
            buttons, icon, defaultButton)
    End Function
#End Region

#Region "Metodo Question"
    Public Overloads Shared Function ShowQuestion(ByVal text As String) As System.Windows.Forms.DialogResult
        Return ShowQuestion(text, System.Windows.Forms.MessageBoxButtons.YesNo)
    End Function

    Public Overloads Shared Function ShowQuestion(ByVal text As String, ByVal defaultButton As System.Windows.Forms.MessageBoxDefaultButton) As System.Windows.Forms.DialogResult
        Return ShowQuestion(text, System.Windows.Forms.MessageBoxButtons.YesNo, defaultButton)
    End Function

    Public Overloads Shared Function ShowQuestion(ByVal text As String, _
                                    ByVal buttons As System.Windows.Forms.MessageBoxButtons) As System.Windows.Forms.DialogResult
        Return ShowQuestion(text, buttons, System.Windows.Forms.MessageBoxDefaultButton.Button2)
    End Function

    Public Overloads Shared Function ShowQuestion(ByVal text As String, _
                                              ByVal buttons As System.Windows.Forms.MessageBoxButtons, _
                                              ByVal defaultButton As System.Windows.Forms.MessageBoxDefaultButton) As System.Windows.Forms.DialogResult
        Return ShowMessage(text, String.Empty, buttons, System.Windows.Forms.MessageBoxIcon.Question, defaultButton)
    End Function
#End Region

#Region "Metodo ShowError"
    Public Overloads Shared Sub ShowError(ByVal message As String, ByVal abort As Boolean)
        If My.Application.Modalita = My.MyApplication.ModalitaApplicative.Batch Then
            UtilMsgBox.GUIConsoleWriter.WriteLine(message)
        Else
            ShowMessage(message, "Error", System.Windows.Forms.MessageBoxIcon.Stop)
        End If

        If UtilLogFileWriter.LogEnabled AndAlso Not UtilLogFileWriter.WriteFailed Then
            UtilLogFileWriter.WriteNewEntry(UtilLogFileWriter.EntryTypes.Error, message)
        End If

        If abort Then System.Environment.Exit(0)
    End Sub
#End Region

    Private NotInheritable Class GUIConsoleWriter
        Private Declare Function AttachConsole Lib "kernel32.dll" (dwProcessId As System.Int64) As Boolean
        Private Declare Function GetConsoleWindow Lib "kernel32.dll" () As IntPtr


        Private Const ATTACH_PARENT_PROCESS As Integer = -1

        Private Shared isConsoleAttached As Boolean = False

        Public Shared Sub WriteLine(line As String)
            If Not GUIConsoleWriter.isConsoleAttached Then
                GUIConsoleWriter.AttachConsole(ATTACH_PARENT_PROCESS)
                GUIConsoleWriter.isConsoleAttached = True
            End If

            Console.WriteLine(line)
        End Sub

        'Public Shared Sub WriteLine(line As String)
        '    'Non viene visualizzato ma se redirezinato su file viene scritto
        '    Console.WriteLine(line)

        '    'Si risolverà con un output file parametrizzabile
        '    'così si può usare la OLD per la risposta a video e scrivere su file lo stesso output 
        'End Sub

    End Class

End Class
