Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class Form1
    ' <DllImport("user32.dll")>
    ' Private Shared Sub mouse_event(dwFlags As UInteger, dx As UInteger, dy As UInteger, dwData As UInteger, dwExtraInfo As Integer)
    'End Sub

    '  Declare Function mc Lib "user32.dll" Alias "mouse_event" (flag, x, y, button, extra)

    Public Declare Auto Function SetCursorPos Lib "User32.dll" (ByVal X As Integer, ByVal Y As Integer) As Long
    Public Declare Auto Function GetCursorPos Lib "User32.dll" (ByRef lpPoint As Point) As Long
    Public Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Long, ByVal dx As Long, ByVal dy As Long, ByVal cButtons As Long, ByVal dwExtraInfo As Long)
    Public Const MOUSEEVENTF_LEFTDOWN = &H2 ' left button down
    Public Const MOUSEEVENTF_LEFTUP = &H4 ' left button up
    Public Const MOUSEEVENTF_MIDDLEDOWN = &H20 ' middle button down
    Public Const MOUSEEVENTF_MIDDLEUP = &H40 ' middle button up
    Public Const MOUSEEVENTF_RIGHTDOWN = &H8 ' right button down
    Public Const MOUSEEVENTF_RIGHTUP = &H10 ' right button up


    ' Const MOUSEEVENTF_MOVE As Int32 = &H1 '  mouse move
    ' Const MOUSEEVENTF_LEFTDOWN As Int32 = &H2 '  left button down
    ' Const MOUSEEVENTF_LEFTUP As Int32 = &H4 '  left button up
    ' Const MOUSEEVENTF_RIGHTDOWN As Int32 = &H8 '  right button down
    ' Const MOUSEEVENTF_RIGHTUP As Int32 = &H10 '  right button up
    ' Const MOUSEEVENTF_MIDDLEDOWN As Int32 = &H20 '  middle button down
    ' Const MOUSEEVENTF_MIDDLEUP As Int32 = &H40 '  middle button up
    ' Const MOUSEEVENTF_ABSOLUTE As Int32 = &H8000 '  absolute move
    ' Const MOUSEEVENTF_WHEEL As Int32 = &H800 ' wheel button rolled

    Public Fermati As Boolean = False
    Public CheckBox1Value As Boolean = False
    'Sub main()
    '    Console.WriteLine("ciao")
    '    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        System.Diagnostics.Debug.WriteLine("btn Avvia")
        System.Diagnostics.Debug.WriteLine("sender=" & sender.ToString)
        System.Diagnostics.Debug.WriteLine("e=" & e.ToString)
        System.Diagnostics.Debug.WriteLine("Raffy")
        REM Me.MousePosition.X = 10

        Dim Giro As Integer = 0
        Dim Azione As String = ""

        Giro = 1
        Azione = "SEL"
        Do
            ' inizio giro
            TextBox2.Text = "" & Giro
            TextBox4.Text = "Begin"

            ' azione
            If Azione = "SEL" Then
                TextBox1.Text = "Seleziono..."
                Cursor.Position = New System.Drawing.Point(350, 190)
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
                Azione = "CANC"
            ElseIf Azione = "CANC" Then
                TextBox1.Text = "Cancello..."
                TextBox3.Text = "" & (Giro * 100)
                Cursor.Position = New System.Drawing.Point(500, 190)
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
                Azione = "SEL"
            End If

            ' pausa
            Application.DoEvents()
            Threading.Thread.Sleep(5000) ' 1000 milliseconds = 1.0 seconds

            ' fine giro
            System.Diagnostics.Debug.WriteLine("giro n° " & Giro)
            TextBox4.Text = "End"
            Application.DoEvents()
            Threading.Thread.Sleep(1000) ' 1000 milliseconds = 1.0 seconds

            ' Next
            Giro += 1
        Loop While Giro <= 1 Or Fermati = False

        REM mouse_event(MOUSEEVENTF_LEFTDOWN, 20, 20, 0, 0)

        REM Me.mouse.Cursor.Position.X = 1
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Diagnostics.Debug.WriteLine("Carico")
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Console.WriteLine("btn Ferma")
        Fermati = True
    End Sub
End Class
