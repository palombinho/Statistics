Imports System.Text


Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim builder As New System.Text.StringBuilder
        For Each item As String In ListBox1.Items
            builder.Append(item.ToString())
            builder.Append(" ")

        Next
        MessageBox.Show(ListBox1.SelectedItem.ToString())

    End Sub


    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click
        If Me.ProgressBar1.Value <> 100 Then
            Me.ProgressBar1.Value += 1
        End If
        If Me.ProgressBar1.Value = 20 Then
            Me.BackColor = Color.Red
        End If
        If Me.ProgressBar1.Value = 40 Then
            Me.BackColor = Color.Yellow
        End If
        If Me.ProgressBar1.Value = 60 Then
            Me.BackColor = Color.Blue
        End If
        If Me.ProgressBar1.Value = 80 Then
            Me.BackColor = Color.Brown
        End If
        If Me.ProgressBar1.Value = 100 Then
            Me.BackColor = Color.Wheat
        End If

    End Sub
End Class
