<Serializable()>
Public Class AutoTelnetScript
    Friend Sub New()
        'Costruttore senza parametri per consentire la serializzazione
        'http://support.microsoft.com/kb/816225/en-us
        'E per impedire la creazione
    End Sub

    <System.Xml.Serialization.XmlIgnore()>
    Public Property Encrypted As Boolean = False

    Public Sub Serialize(ByVal filePath As String)
        'Dim serializer As System.Xml.Serialization.XmlSerializer

        'Creazione directory se inesistente
        If Not System.IO.Directory.Exists( _
            System.IO.Path.GetDirectoryName(filePath)) Then
            System.IO.Directory.CreateDirectory( _
                System.IO.Path.GetDirectoryName(filePath))
        End If

        Using writer = New System.IO.StringWriter()
            Dim serializer = New System.Xml.Serialization.XmlSerializer(Me.GetType())
            serializer.Serialize(writer, Me)

            Dim text = writer.ToString()
            If Me.Encrypted Then
                text = UtilTripleDESCryptography.Encoding(text)
            End If

            System.IO.File.WriteAllText(filePath, text)

            serializer = Nothing
        End Using

        ''Creazione/Sovrascrittura File
        'Using stream = New System.IO.FileStream(filePath, System.IO.FileMode.Create)
        '    serializer = New System.Xml.Serialization.XmlSerializer(Me.GetType())
        '    serializer.Serialize(stream, Me)
        '    serializer = Nothing
        'End Using
    End Sub

    Public Function Deserialize(ByVal filePath As String) As Boolean
        Dim deserializedObj As Object = Nothing
        'Dim serializer As System.Xml.Serialization.XmlSerializer

        If Not System.IO.File.Exists(filePath) Then Return False

        'Read text file
        Dim text = System.IO.File.ReadAllText(filePath)

        'Decriptazione se necessario
        Dim encrypted = Not text.EndsWith("</AutoTelnetScript>")
        If encrypted Then
            text = UtilTripleDESCryptography.Decoding(text)
        End If

        'Deserializzazione
        Using reader = New System.IO.StringReader(text)
            Dim serializer = New System.Xml.Serialization.XmlSerializer(Me.GetType())
            deserializedObj = serializer.Deserialize(reader)
            serializer = Nothing
        End Using
        Util.Copy(deserializedObj, Me)

        'Impostazione flag Encryped
        Me.Encrypted = encrypted

        Return True
    End Function

    <System.ComponentModel.DefaultValue("")>
    Public Property Host As String = String.Empty

    <System.ComponentModel.DefaultValue(TelnetSession.DefaultTelnetPort)>
    Public Property Port As UInt16 = TelnetSession.DefaultTelnetPort

    <System.ComponentModel.DefaultValue(False)>
    Public Property SendUser As Boolean = False

    <System.ComponentModel.DefaultValue("")>
    Public Property User As String = String.Empty

    <System.ComponentModel.DefaultValue(False)>
    Public Property SendPassword As Boolean = False

#Region "Proprietà PasswordDecrypted"
    <System.ComponentModel.DefaultValue("")>
    <System.ComponentModel.Browsable(False)>
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Property Password As String = String.Empty

    <System.Xml.Serialization.XmlIgnore()>
    Public Property PasswordDecrypted As String
        Get
            If String.IsNullOrEmpty(Me.Password) Then Return String.Empty
            Return UtilTripleDESCryptography.Decoding(Me.Password)
        End Get
        Set(value As String)
            Me.Password = UtilTripleDESCryptography.Encoding(value)
        End Set
    End Property
#End Region

    <System.ComponentModel.DefaultValue("")>
    Public Property Text As String = String.Empty

    Public Property SendEndOfLine As TelnetClient.EndOfLineValues = TelnetSession.EndOfLineDefault 'TelnetClient.EndOfLineDefault

    <System.ComponentModel.DefaultValue(TelnetSession.DelayReadTimeDefault)>
    Public Property DelayReadTime As UInt16 = TelnetSession.DelayReadTimeDefault

    <System.ComponentModel.DefaultValue(TelnetSession.AttemptsRetryReadingDefault)>
    Public Property AttemptsRetryReading As UInt16 = TelnetSession.AttemptsRetryReadingDefault

    <System.ComponentModel.DefaultValue(TelnetSession.RemoveRemoveANSIEscapeSequencesFromOutputDefault)>
    Public Property RemoveRemoveANSIEscapeSequencesFromOutput As Boolean = TelnetSession.RemoveRemoveANSIEscapeSequencesFromOutputDefault

    <System.ComponentModel.DefaultValue("")>
    Public Property LogFile As String = String.Empty

    <System.ComponentModel.DefaultValue(UtilLogFileWriter.LogModeDefault)>
    Public Property LogMode As UtilLogFileWriter.LogModes = UtilLogFileWriter.LogModeDefault

    <System.ComponentModel.DefaultValue(False)>
    Public Property LogCommandAndResponseEntriesEncrypted As Boolean = False

#Region "Proprietà BatchSuccessfulOutputText"
    Public Const BatchSuccessfulOutputTextDefault = "Script execution successful."

    <System.ComponentModel.DefaultValue("")>
   Public Property BatchSuccessfulOutputText As String =string.Empty
#End Region

#Region "Proprietà BatchFailedOutputText"
    Public Const BatchFailedOutputTextDefault = "Script execution failed."

    <System.ComponentModel.DefaultValue("")>
    Public Property BatchFailedOutputText As String = String.Empty
#End Region

    <System.ComponentModel.DefaultValue("")>
    Public Property BatchOutputFile As String = String.Empty

    <System.ComponentModel.DefaultValue(UtilBatchOutputFileWriter.OutputModeDefault)>
    Public Property BatchOutputMode As UtilBatchOutputFileWriter.OutputModes = UtilBatchOutputFileWriter.OutputModeDefault

#Region "Proprietà Parameters"
    Private parametersInternal As AutoTelnetScriptParameterCollection = Nothing

    Public Property Parameters() As AutoTelnetScriptParameterCollection
        Get
            If Me.parametersInternal Is Nothing Then
                Me.parametersInternal = New AutoTelnetScriptParameterCollection
            End If
            Return Me.parametersInternal
        End Get
        Set(value As AutoTelnetScriptParameterCollection)
            Me.parametersInternal = value
        End Set
    End Property


#End Region

    <System.ComponentModel.DefaultValue("")>
    Public Property NotesRtf As String = String.Empty
End Class
