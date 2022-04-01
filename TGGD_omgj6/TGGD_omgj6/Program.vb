Enum ProgramState
    MainMenu
    InPlay
    Quit
End Enum
Module Program
    Private programState As ProgramState = ProgramState.MainMenu
    Sub Main(args As String())
        Console.Title = "A Game in VB.NET About High Scores"
        Application.Init()
        While programState <> ProgramState.Quit
            Select Case programState
                Case ProgramState.MainMenu
                    ShowMainMenu()
                Case ProgramState.InPlay
                    InPlay.Run()
                    programState = ProgramState.MainMenu
            End Select
        End While
    End Sub
    Sub ShowMainMenu()
        Dim quitButton As New Button("Quit")
        AddHandler quitButton.Clicked, AddressOf HandleQuit
        Dim startButton As New Button("Start")
        AddHandler startButton.Clicked, AddressOf HandleStart
        Dim dialog As New Dialog With {.Title = "A Game in VB.NET About High Scores"}
        dialog.AddButton(startButton)
        dialog.AddButton(quitButton)
        dialog.Add(New Label(1, 1, $"High Score: {ReadHighScore()}"))
        dialog.Add(New Label(1, 2, $"Games Played: {ReadGamesPlayed()}"))
        dialog.Add(New Label(1, 3, $"Total Score: {ReadTotalScore()}"))
        dialog.Add(New Label(1, 4, $"Average Score: {ReadAverageScore()}"))
        Application.Run(dialog)
    End Sub
    Private Sub HandleQuit()
        If MessageBox.Query("Are you sure?", "Are you sure you want to quit?", "No", "Yes") = 1 Then
            Application.RequestStop()
            programState = ProgramState.Quit
        End If
    End Sub
    Private Sub HandleStart()
        Application.RequestStop()
        programState = programState.InPlay
    End Sub
End Module
