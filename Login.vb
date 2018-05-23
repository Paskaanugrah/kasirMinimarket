Imports MySql.Data.MySqlClient
Public Class Login
    Dim HostConn As New MySqlConnection
    Dim da As MySqlDataAdapter

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Admin")
        ComboBox1.Items.Add("Kasir")
        ComboBox1.Items.Add("Karyawan Gudang")
        ComboBox1.Focus()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call bukaDB()
        If ComboBox1.SelectedItem = "Kasir" Then
            CMD = New MySqlCommand("SELECT Nama from kasir where Username='" & txt_username.Text & "' and Password='" & txt_password.Text & "'", conn)
            RD = CMD.ExecuteReader
            RD.Read()
            If RD.HasRows Then
                MsgBox("Login Berhasil", MsgBoxStyle.Information)
                Main.Label10.Text = RD.Item("Nama")
                Main.Show()
                Me.Hide()
            ElseIf RD.HasRows = 0 Then
                RD.Close()
                MsgBox("Username/password salah!", MsgBoxStyle.Critical)
            End If
        End If
        If ComboBox1.SelectedItem = "Admin" Then
            CMD = New MySqlCommand("SELECT Nama from admin where Username='" & txt_username.Text & "' and Password='" & txt_password.Text & "'", conn)
            RD = CMD.ExecuteReader
            RD.Read()
            If RD.HasRows Then
                MsgBox("Login Berhasil", MsgBoxStyle.Information)
                AdminDashboard.Label3.Text = RD.Item("Nama")
                AdminDashboard.Show()
                Me.Hide()
            ElseIf RD.HasRows = 0 Then
                RD.Close()
                MsgBox("Username/password salah!", MsgBoxStyle.Critical)
            End If
        End If
        If ComboBox1.SelectedItem = "Karyawan Gudang" Then
            CMD = New MySqlCommand("SELECT Nama from k_gudang where Username='" & txt_username.Text & "' and Password='" & txt_password.Text & "'", conn)
            RD = CMD.ExecuteReader
            RD.Read()
            If RD.HasRows Then
                MsgBox("Login Berhasil", MsgBoxStyle.Information)
                HomeKarGudang.Label2.Text = RD.Item("Nama")
                HomeKarGudang.Show()
                Me.Hide()
            ElseIf RD.HasRows = 0 Then
                RD.Close()
                MsgBox("Username/password salah!", MsgBoxStyle.Critical)
            End If
        End If
        ComboBox1.Text = ""
        txt_username.Clear()
        txt_password.Clear()
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label5.Text = Format(Now, "HH:mm:ss")
    End Sub
End Class