Imports System.IO

Module Statistics
    Const HighScoreFilename = "HighScore.txt"
    Const GamesPlayedFilename = "GamesPlayed.txt"
    Const TotalScoreFilename = "TotalScore.txt"
    Function ReadHighScore() As Long
        Try
            Return CLng(File.ReadAllText(HighScoreFilename))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Function ReadGamesPlayed() As Long
        Try
            Return CLng(File.ReadAllText(GamesPlayedFilename))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Function ReadTotalScore() As Long
        Try
            Return CLng(File.ReadAllText(TotalScoreFilename))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Sub WriteHighScore(score As Long)
        Try
            File.WriteAllText(HighScoreFilename, $"{score}")
        Catch ex As Exception
            'do nothin!
        End Try
    End Sub
    Sub WriteGamesPlayed(games As Long)
        Try
            File.WriteAllText(GamesPlayedFilename, $"{games}")
        Catch ex As Exception
            'do nothin!
        End Try
    End Sub
    Sub WriteTotalScore(score As Long)
        Try
            File.WriteAllText(TotalScoreFilename, $"{score}")
        Catch ex As Exception
            'do nothin!
        End Try
    End Sub
    Function ReadAverageScore() As Double
        Dim games = ReadGamesPlayed()
        Return If(games = 0, 0, ReadTotalScore() / games)
    End Function
End Module
