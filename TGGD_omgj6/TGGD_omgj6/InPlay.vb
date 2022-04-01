﻿Module InPlay
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
    End Sub

    Private Sub UpdateBoard()
        MovePlayer()
        DrawBoard()
        ShowTimeLeft()
        ShowScore()
    End Sub

    Private Sub DrawBoard()
        For row = 0 To BoardRows - 1
            For column = 0 To BoardColumns - 1
                Console.CursorLeft = column
                Console.CursorTop = row
                If column = playerColumn And row = playerRow Then
                    Console.Write("@")
                ElseIf column = targetColumn And row = targetRow Then
                    Console.Write("$")
                Else
                    Console.Write(".")
                End If
            Next
        Next
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
        Console.CursorLeft = BoardColumns + 1
        Console.CursorTop = 1
        Console.Write($"Score: {score} ")
    End Sub
    Private Sub ShowTimeLeft()
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
        timeStarted = DateTime.Now
        playerColumn = random.Next(0, BoardColumns - 1)
        playerRow = random.Next(0, BoardRows - 1)
        SpawnTarget()
        score = 0
    End Sub
End Module
