Module Program
    Sub Main(args As String())
        Console.Title = "A Game in VB.NET About High Scores"
        Console.CursorVisible = False
        Dim done = False
        While Not done
            Console.Clear()
            Console.WriteLine()
            Console.WriteLine("Main Menu:")
            Console.WriteLine("Pro Tip: Don't hold the movement keys down!")
            Console.WriteLine("[S]tart")
            Console.WriteLine("[Q]uit")
            Select Case WaitKey(ConsoleKey.Q, ConsoleKey.S)
                Case ConsoleKey.S
                    InPlay.Run()
                Case ConsoleKey.Q
                    done = ConfirmQuit()
                Case Else
                    Throw New NotImplementedException
            End Select
        End While
    End Sub

    Private Function ConfirmQuit() As Boolean
        Console.Clear()
        Console.WriteLine()
        Console.WriteLine("Are you sure you want to quit?")
        Console.WriteLine("[N]o")
        Console.WriteLine("[Y]es")
        Return WaitKey(ConsoleKey.Y, ConsoleKey.N) = ConsoleKey.Y
    End Function
End Module
