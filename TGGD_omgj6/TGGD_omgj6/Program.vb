Enum MainMenuResult
    Running
    Quit
End Enum
Module Program
    Private result As MainMenuResult = MainMenuResult.Running
    Sub Main(args As String())
        Console.Title = "A Game in VB.NET About High Scores"
        Application.Init()
        While result <> MainMenuResult.Quit
            Dim quitButton As New Button("Quit")
            AddHandler quitButton.Clicked, AddressOf HandleQuit
            Dim startButton As New Button("Start")
            Dim dialog As New Dialog With {.Title = "A Game in VB.NET About High Scores"}
            dialog.AddButton(startButton)
            dialog.AddButton(quitButton)
            dialog.Add(New Label(1, 1, $"High Score: {ReadHighScore()}"))
            dialog.Add(New Label(1, 2, $"Games Played: {ReadGamesPlayed()}"))
            dialog.Add(New Label(1, 3, $"Total Score: {ReadTotalScore()}"))
            dialog.Add(New Label(1, 4, $"Average Score: {ReadAverageScore()}"))
            Application.Run(dialog)
        End While
    End Sub
    Private Sub HandleQuit()
        If MessageBox.Query("Are you sure?", "Are you sure you want to quit?", "No", "Yes") = 1 Then
            Application.RequestStop()
            result = MainMenuResult.Quit
        End If
    End Sub
End Module
