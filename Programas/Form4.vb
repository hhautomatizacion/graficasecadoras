Public Class Form4

   

    Private Sub MonthCalendar1_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        Form1.ToolStripStatusLabel3.Text = e.Start.ToString("yyyy-MM-dd") & " 00:00:00"
        Form1.ToolStripStatusLabel1.Text = e.End.ToString("yyyy-MM-dd") & " 23:59:59"
        If CDate(Form1.ToolStripStatusLabel1.Text) >= Now Then
            Form1.Timer1.Enabled = True
        Else
            Form1.Timer1.Enabled = False
        End If
        Me.Close()
    End Sub

    Private Sub MonthCalendar1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MonthCalendar1.Resize
        Me.Width = Me.Width - (Me.ClientSize.Width - MonthCalendar1.Width)
        Me.Height = Me.Height - (Me.ClientSize.Height - MonthCalendar1.Height)
    End Sub

  
End Class