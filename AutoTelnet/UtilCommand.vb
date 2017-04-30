Public NotInheritable Class UtilCommand
    Private Sub New()
        MyBase.New()

    End Sub

    Public Const CommandPrefix = "["c
    Public Const CommandSuffix = "]"c
    Public Const ValueSeparator = "|"c

    Public Enum CommandIDs
        <System.ComponentModel.Description("Wait for a specified number of milliseconds from Value1")>
        Wait

        <System.ComponentModel.Description("Wait until read a string specified in Value1 for a maximum number of milliseconds specified in Value2 (Specifiy 0 to wait for string indefinitely")>
        WaitFor
    End Enum
End Class
