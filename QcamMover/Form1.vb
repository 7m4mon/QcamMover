Public Class Form1
    Dim aPan As Integer = 0
    Dim aTilt As Integer = 0

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        'Left
        QcamMover(8, 0)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        'up
        QcamMover(0, -6)
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        'down
        QcamMover(0, 6)
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        'Right
        QcamMover(-8, 0)

    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        'reset
        QcamMover(180, 180)
        System.Threading.Thread.Sleep(3000)
        QcamMover(-64, -27)
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        'move
        QcamMover(NumericUpDown1.Value, NumericUpDown2.Value) ' 引数

    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        '絶対値移動
        QcamMover(NumericUpDown3.Value - aPan, NumericUpDown4.Value - aTilt)
    End Sub

    Private Sub QcamMover(ByVal rPan As Integer, ByVal rTilt As Integer)
        Dim psInfo As New ProcessStartInfo()
        psInfo.FileName = "Q200_PTR.exe" ' 実行するファイル
        '引数の指定
        psInfo.Arguments = rPan & " " & rTilt ' 引数
        psInfo.CreateNoWindow = True ' コンソール・ウィンドウを開かない
        psInfo.UseShellExecute = False ' シェル機能を使用しない

        Process.Start(psInfo)

        aPan = aPan + rPan
        If aPan > NumericUpDown3.Maximum Then
            aPan = NumericUpDown3.Maximum
        ElseIf aPan < NumericUpDown3.Minimum Then
            aPan = NumericUpDown3.Minimum
        Else
            'aPan = NumericUpDown3.Value + rPan
        End If
        NumericUpDown3.Value = aPan

        aTilt = aTilt + rTilt
        If aTilt > NumericUpDown4.Maximum Then
            aTilt = NumericUpDown4.Maximum
        ElseIf aTilt < NumericUpDown4.Minimum Then
            aTilt = NumericUpDown4.Minimum
        Else
            'aTilt = NumericUpDown4.Value + rTilt
        End If
        NumericUpDown4.Value = aTilt
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        AboutBox1.Show()
    End Sub
End Class

