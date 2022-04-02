Module InPlay
    Const BoardColumns = 56
    Const BoardRows = 28
    Private timeStarted As DateTime
    Private playerColumn As Integer
    Private playerRow As Integer
    Private targetColumn As Integer
    Private targetRow As Integer
    Private score As Long
    Private ReadOnly random As New Random
    Private ReadOnly Property TimeLeft As Integer
        Get
            Dim delta = DateTime.Now - timeStarted
            If delta.TotalSeconds >= 60 Then
                Return 0
            Else
                Return CInt(60.0 - delta.TotalSeconds)
            End If
        End Get
    End Property
    Sub Run()
        InitializeBoard()
        While TimeLeft > 0
            UpdateBoard()
        End While
        FinishBoard()
    End Sub

    Private Sub FinishBoard()
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Gray
        Console.WriteLine("Time's up!")
        Console.WriteLine($"Final Score: {score}")
        If score > ReadHighScore() Then
            Console.WriteLine("New high score!")
            WriteHighScore(score)
        End If
        WriteTotalScore(ReadTotalScore() + score)
        WriteGamesPlayed(ReadGamesPlayed() + 1)
        Console.WriteLine("<space> to continue")
        WaitKey(ConsoleKey.Spacebar)
    End Sub

    Private Sub DrawBoardBackground()
        Console.ForegroundColor = ConsoleColor.DarkGray
        For row = 0 To BoardRows - 1
            For column = 0 To BoardColumns - 1
                Console.CursorLeft = column
                Console.CursorTop = row
                Console.Write(".")
            Next
        Next
    End Sub

    Private Sub UpdateBoard()
        HideThingies()
        MovePlayer()
        ShowThingies()
        ShowTimeLeft()
        ShowScore()
    End Sub

    Private Sub HideThingies()
        Console.ForegroundColor = ConsoleColor.DarkGray
        Console.CursorLeft = targetColumn
        Console.CursorTop = targetRow
        Console.Write(".")
        Console.CursorLeft = playerColumn
        Console.CursorTop = playerRow
        Console.Write(".")
    End Sub

    Private Sub ShowThingies()
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.CursorLeft = targetColumn
        Console.CursorTop = targetRow
        Console.Write("$")
        Console.ForegroundColor = ConsoleColor.White
        Console.CursorLeft = playerColumn
        Console.CursorTop = playerRow
        Console.Write("@")
    End Sub
    Private Sub MovePlayer()
        If playerColumn = targetColumn And playerRow = targetRow Then
            Beep(1000, 100)
            SpawnTarget()
            score += 1
        End If
        Dim key = PollKey()
        If key.HasValue Then
            Select Case key.Value
                Case ConsoleKey.LeftArrow
                    playerColumn = If(playerColumn > 0, playerColumn - 1, playerColumn)
                Case ConsoleKey.RightArrow
                    playerColumn = If(playerColumn < BoardColumns - 1, playerColumn + 1, playerColumn)
                Case ConsoleKey.UpArrow
                    playerRow = If(playerRow > 0, playerRow - 1, playerRow)
                Case ConsoleKey.DownArrow
                    playerRow = If(playerRow < BoardRows - 1, playerRow + 1, playerRow)
            End Select
        End If
    End Sub
    Private Sub ShowScore()
        Console.ForegroundColor = ConsoleColor.Green
        Console.CursorLeft = BoardColumns + 1
        Console.CursorTop = 1
        Console.Write($"Score: {score} ")
    End Sub
    Private Sub ShowTimeLeft()
        Select Case TimeLeft
            Case Is < 5
                Console.ForegroundColor = ConsoleColor.Red
            Case Is < 10
                Console.ForegroundColor = ConsoleColor.DarkYellow
            Case Else
                Console.ForegroundColor = ConsoleColor.DarkGreen
        End Select
        Console.CursorLeft = BoardColumns + 1
        Console.CursorTop = 0
        Console.Write($"Time Left: {TimeLeft} ")
    End Sub
    Private Sub SpawnTarget()
        targetColumn = random.Next(0, BoardColumns - 1)
        targetRow = random.Next(0, BoardRows - 1)
    End Sub
    Private Sub InitializeBoard()
        Console.Clear()
        DrawBoardBackground()
        timeStarted = DateTime.Now
        playerColumn = random.Next(0, BoardColumns - 1)
        playerRow = random.Next(0, BoardRows - 1)
        SpawnTarget()
        score = 0
    End Sub
End Module
