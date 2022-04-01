Imports System.Timers

Module InPlay
    Const TotalTime = 60
    Private timeLeft As Long
    Private window As Window
    Sub Run()
        window = New Window("(title)")
        timeLeft = TotalTime
        Dim timer As New Timer With {
            .Interval = 1000
        }
        AddHandler timer.Elapsed, AddressOf HandleTimer
        timer.Start()
        Application.Run(window)
    End Sub
    Private Sub HandleTimer(source As Object, e As ElapsedEventArgs)
        timeLeft -= 1
        UpdateTimeLeft()
        If timeLeft <= 0 Then
            CType(source, Timer).Stop()
            HandleGameOver()
        End If
    End Sub

    Private Sub UpdateTimeLeft()
        Console.Title = $"Time Left: {timeLeft}"
    End Sub

    Private Sub HandleGameOver()
        Application.RequestStop()
    End Sub
End Module
