Public Class Form10

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Format(Now, "hh:mm:ss")
    End Sub
End Class