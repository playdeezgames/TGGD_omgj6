Module Utility
    Function PollKey() As ConsoleKey?
        If Console.KeyAvailable Then
            Dim key = Console.ReadKey(True)
            Return key.Key
        End If
        Return Nothing
    End Function
    Function WaitKey(ParamArray keyFilter As ConsoleKey()) As ConsoleKey
        Do
            Dim key = PollKey()
            If key.HasValue AndAlso keyFilter.Contains(key.Value) Then
                Return key.Value
            End If
        Loop
    End Function
    Sub Beep(frequency As Integer, duration As Integer)
        Try
#Disable Warning CA1416 ' Validate platform compatibility
            Console.Beep(frequency, duration)
#Enable Warning CA1416 ' Validate platform compatibility
        Catch ex As Exception

        End Try
    End Sub
End Module
