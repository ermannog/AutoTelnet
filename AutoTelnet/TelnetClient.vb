'http://www.vbforums.com/showthread.php?522157-2005-Telnet-client-with-vb-net
'http://www.networksorcery.com/enp/protocol/telnet.htm#Description
'http://myhead-online.blogspot.it/2009/05/vb-2008net-but-anything-really-telnet.html
'http://myhead-online.blogspot.it/2009/05/vb-net2008-express-telnet-to-sun.html
'http://stackoverflow.com/questions/9113632/test-telnet-communication-on-remote-computer-using-vb-net

Public Class TelnetClient
    Implements System.IDisposable

#Region "Property Hostname"
    Private hostnameValue As String = String.Empty
    Public ReadOnly Property Hostname As String
        Get
            Return Me.hostnameValue
        End Get
    End Property
#End Region

#Region "Property Port"
    Private portValue As UInt16
    Public ReadOnly Property Port As UInt16
        Get
            Return Me.portValue
        End Get
    End Property
#End Region

#Region "Property Response"
    Private responseValue As String = String.Empty
    Public ReadOnly Property Response As String
        Get
            Return Me.responseValue
        End Get
    End Property
#End Region

    '#Region "Property DelayReadTime"
    '    Public Const DelayReadTimeDefault As UInt16 = 500

    '    ''' <summary>
    '    ''' Millisecond wait before read data when invoke Read method
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public DelayReadTime As UInt16 = TelnetClient.DelayReadTimeDefault
    '#End Region

    '#Region "Property AttemptsRetryReading"
    '    Public Const AttemptsRetryReadingDefault As UInt16 = 0

    '    ''' <summary>
    '    ''' Number of retry reading attempts with no data before quit read method
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public AttemptsRetryReading As UInt16 = TelnetClient.AttemptsRetryReadingDefault
    '#End Region

    '#Region "Property SendEndOfLine"
    Public Enum EndOfLineValues As Integer
        <System.ComponentModel.Description("Linefeed character")>
        Lf = 1
        <System.ComponentModel.Description("Carriage return character")>
        Cr = 2
        <System.ComponentModel.Description("Carriage return and Linefeed character combination")>
        CrLf = 3
    End Enum

    '    Public Const EndOfLineDefault As TelnetClient.EndOfLineValues = TelnetClient.EndOfLineValues.CrLf

    '    ''' <summary>
    '    ''' End of line char send after a command
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public SendEndOfLine As TelnetClient.EndOfLineValues = TelnetClient.EndOfLineDefault
    '#End Region

    Private client As System.Net.Sockets.TcpClient = Nothing
    Private stream As System.Net.Sockets.NetworkStream = Nothing

    Public Sub New(hostname As String, port As UInt16)
        Me.hostnameValue = hostname
        Me.portValue = port
    End Sub

    Public Sub Connect()
        Me.client = New System.Net.Sockets.TcpClient()
        Me.client.Connect(Me.hostnameValue, Me.portValue)
        Me.stream = client.GetStream()
    End Sub

    Public Sub Close()
        If Me.stream IsNot Nothing Then
            Me.stream.Close()
        End If

        If Me.client IsNot Nothing Then
            Me.client.Close()
            Me.client = Nothing
        End If

        Me.Dispose(True)
    End Sub

    Public Sub Read(delayReadTime As UInt16, attemptsRetryReading As UInt16)
        'https://msdn.microsoft.com/it-it/library/system.net.sockets.tcpclient.getstream(v=vs.110).aspx

        Dim stringBuilder As New System.Text.StringBuilder

        Dim counterReadingAttempts = 1 + attemptsRetryReading
        Do
            'Reset flag dati letti
            Dim dataRead As Boolean = False

            'Attesa tempo di ritardo
            System.Threading.Thread.Sleep(delayReadTime)

            Do
                Dim buffer(Me.client.ReceiveBufferSize) As Byte
                Dim bytesRead As Integer = 0

                'System.Threading.Thread.Sleep(Me.DelayReadTime)

                If Me.stream.CanRead AndAlso Me.stream.DataAvailable Then
                    SyncLock Me.stream
                        bytesRead = Me.stream.Read(buffer, 0, buffer.Length)
                    End SyncLock

                    If bytesRead > 0 Then
                        Dim data = Me.Negotiate(buffer, bytesRead)
                        If data.Length > 0 Then
                            stringBuilder.AppendFormat("{0}", System.Text.Encoding.Default.GetString(data, 0, data.Length))
                            dataRead = True
                        End If
                    End If
                End If

                buffer = Nothing
            Loop While Me.stream.DataAvailable

            'Gestione rilettura
            If dataRead Then
                counterReadingAttempts = attemptsRetryReading
            Else
                counterReadingAttempts -= System.Convert.ToUInt16(1)
            End If
        Loop Until counterReadingAttempts = 0

        Me.responseValue = stringBuilder.ToString()

        stringBuilder = Nothing
    End Sub

    'Public Sub Read()
    '    'https://msdn.microsoft.com/it-it/library/system.net.sockets.tcpclient.getstream(v=vs.110).aspx

    '    Dim stringBuilder As New System.Text.StringBuilder

    '    Dim counterReadingAttempts = 1 + Me.AttemptsRetryReading
    '    Do
    '        'Reset flag dati letti
    '        Dim dataRead As Boolean = False

    '        'Attesa tempo di ritardo
    '        System.Threading.Thread.Sleep(Me.DelayReadTime)

    '        Do
    '            Dim buffer(Me.client.ReceiveBufferSize) As Byte
    '            Dim bytesRead As Integer = 0

    '            'System.Threading.Thread.Sleep(Me.DelayReadTime)

    '            If Me.stream.CanRead AndAlso Me.stream.DataAvailable Then
    '                SyncLock Me.stream
    '                    bytesRead = Me.stream.Read(buffer, 0, buffer.Length)
    '                End SyncLock

    '                If bytesRead > 0 Then
    '                    Dim data = Me.Negotiate(buffer, bytesRead)
    '                    If data.Length > 0 Then
    '                        stringBuilder.AppendFormat("{0}", System.Text.Encoding.Default.GetString(data, 0, data.Length))
    '                        dataRead = True
    '                    End If
    '                End If
    '            End If

    '            buffer = Nothing
    '        Loop While Me.stream.DataAvailable

    '        'Gestione rilettura
    '        If dataRead Then
    '            counterReadingAttempts = Me.AttemptsRetryReading
    '        Else
    '            counterReadingAttempts -= System.Convert.ToUInt16(1)
    '        End If
    '    Loop Until counterReadingAttempts = 0

    '    Me.responseValue = stringBuilder.ToString()
    '    stringBuilder = Nothing
    'End Sub

    Private Enum TelnetCommands As Byte
        GA = 249 'Go ahead
        WILL = 251
        WONT = 252
        [DO] = 253
        DONT = 254
        IAC = 255
    End Enum

    Private Enum TelnetOptions As Byte
        BinaryTransmission = 0
        Echo = 1
        SuppressGoAhead = 3
        TerminalType = 24
        WindowsSize = 31
        RemoteFlowControl = 33
        LineMode = 34
    End Enum

    'Private Function AddEndOfLineChar(text As String) As String
    '    Dim textEOL = text
    '    Select Case Me.SendEndOfLine
    '        Case EndOfLineValues.Lf
    '            textEOL &= Microsoft.VisualBasic.ControlChars.Lf
    '        Case EndOfLineValues.Cr
    '            textEOL &= Microsoft.VisualBasic.ControlChars.Cr
    '        Case EndOfLineValues.CrLf
    '            textEOL &= Microsoft.VisualBasic.ControlChars.CrLf
    '    End Select

    '    Return textEOL
    'End Function

    Private Function Negotiate(ByVal buffer As Byte(), ByVal length As Int32) As Byte()
        'Descrizione della negoziazione (RFC 854 https://www.ietf.org/rfc/rfc854.txt)
        'In summary, WILL XXX is sent, by either party, to indicate that
        'party's desire (offer) to begin performing option XXX, DO XXX and
        'DON'T XXX being its positive and negative acknowledgments; similarly,
        'DO XXX is sent to indicate a desire (request) that the other party
        '(i.e., the recipient of the DO) begin performing option XXX, WILL XXX
        'and WON'T XXX being the positive and negative acknowledgments.

        'Since the NVT is what is left when no options are enabled, the DON'T and
        'WON'T responses are guaranteed to leave the connection in a state
        'which both ends can handle.  Thus, all hosts may implement their
        'TELNET processes to be totally unaware of options that are not
        'supported, simply returning a rejection to (i.e., refusing) any
        'option request that cannot be understood.

        'Di conseguenza si risponde come segue:
        '- DONT ai WILL e WONT
        '- WONT ai DO e DONT 

        'L'opzione WindowsSize quando offerta dal server contiene 2 byte di dati (Height e Width) e non uno come le altre opzioni

        Dim dataBeginIndex As Integer = 0

        Dim index = 0
        While (index < length)
            If buffer(index) = TelnetCommands.IAC Then
                Dim telnetOption = buffer(index + 2)

                Select Case buffer(index + 1)
                    Case TelnetCommands.WONT
                        Dim dataCommand(2) As Byte
                        dataCommand(0) = TelnetCommands.IAC
                        dataCommand(1) = TelnetCommands.DONT
                        dataCommand(2) = telnetOption 'buffer(index + 2)
                        SyncLock Me.stream
                            stream.Write(dataCommand, 0, dataCommand.Length)
                        End SyncLock
                    Case TelnetCommands.WILL
                        Dim dataCommand(2) As Byte
                        dataCommand(0) = TelnetCommands.IAC

                        'Select Case buffer(index + 2)
                        '    Case TelnetOptions.Echo, TelnetOptions.SuppressGoAhead
                        '        dataCommand(1) = TelnetCommands.DO
                        '    Case Else
                        '        dataCommand(1) = TelnetCommands.DONT
                        'End Select

                        dataCommand(1) = TelnetCommands.DONT
                        dataCommand(2) = telnetOption 'buffer(index + 2)

                        SyncLock Me.stream
                            stream.Write(dataCommand, 0, dataCommand.Length)
                        End SyncLock
                    Case TelnetCommands.DO
                        Dim dataCommand(2) As Byte
                        dataCommand(0) = TelnetCommands.IAC
                        dataCommand(1) = TelnetCommands.WONT
                        dataCommand(2) = telnetOption 'buffer(index + 2)

                        SyncLock Me.stream
                            stream.Write(dataCommand, 0, dataCommand.Length)
                        End SyncLock
                    Case TelnetCommands.DONT
                        Dim dataCommand(2) As Byte
                        dataCommand(0) = TelnetCommands.IAC
                        dataCommand(1) = TelnetCommands.WONT
                        dataCommand(2) = telnetOption 'buffer(index + 2)

                        SyncLock Me.stream
                            stream.Write(dataCommand, 0, dataCommand.Length)
                        End SyncLock
                End Select

                'Gestione Indice
                Select Case buffer(index + 1)
                    Case TelnetCommands.IAC, TelnetCommands.GA
                        index += 2
                    Case TelnetCommands.WILL, TelnetCommands.DO
                        'Select Case buffer(index + 2)
                        '    Case TelnetOptions.WindowsSize
                        '        index += 5
                        '    Case Else
                        '        index += 3
                        'End Select
                        index += 3
                    Case TelnetCommands.WONT, TelnetCommands.DONT
                        index += 3
                    Case Else
                        index += 1
                End Select

                dataBeginIndex = index
            ElseIf index = 0 Then
                Exit While
            Else
                index += 1
            End If
        End While


        Dim dataWithoutNegotiate(length - dataBeginIndex - 1) As Byte
        System.Array.Copy(buffer, dataBeginIndex, dataWithoutNegotiate, 0, dataWithoutNegotiate.Length)
        Return dataWithoutNegotiate
    End Function

    Public Sub Write(message As String, endOfLine As EndOfLineValues)

        'https://msdn.microsoft.com/it-it/library/system.net.sockets.tcpclient.getstream(v=vs.110).aspx
        'Dim buffer() As Byte = System.Text.Encoding.ASCII.GetBytes(Me.AddEndOfLineChar(message))

        'Gestione End of Line
        Dim messageEOL = message
        Select Case endOfLine
            Case EndOfLineValues.Lf
                messageEOL &= Microsoft.VisualBasic.ControlChars.Lf
            Case EndOfLineValues.Cr
                messageEOL &= Microsoft.VisualBasic.ControlChars.Cr
            Case EndOfLineValues.CrLf
                messageEOL &= Microsoft.VisualBasic.ControlChars.CrLf
        End Select

        'Impostazione buffer di scrittura
        Dim buffer() As Byte = System.Text.Encoding.ASCII.GetBytes(messageEOL)

        'Scrittura
        SyncLock Me.stream
            stream.Write(buffer, 0, buffer.Length)
        End SyncLock

        buffer = Nothing
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                If Me.stream IsNot Nothing Then Me.stream.Dispose()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
