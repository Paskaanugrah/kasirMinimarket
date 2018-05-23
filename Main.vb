Imports MySql.Data.MySqlClient
Public Class Main
    Public DA As MySqlDataAdapter
    Public DS As DataSet
    Sub tampilCombo()
        Call bukaDB()
        CMD = New MySqlCommand("select id from barang", conn)
        RD = CMD.ExecuteReader
        ComboBox1.Items.Clear()
        Do While RD.Read
            ComboBox1.Items.Add(RD.Item(0))
        Loop
        CMD.Dispose()
        RD.Close()
        conn.Close()
    End Sub
    Sub tampilBarang()
        Call bukaDB()
        CMD = New MySqlCommand("select * from barang where id='" & ComboBox1.Text & "'", conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            Call bukaDB()
            CMD = New MySqlCommand("insert into listbarang (id, nama_brg, harga, jumlah) select id, nama_barang, harga, '" & txt_jmlh.Text & "' from barang where id='" & ComboBox1.Text & "'", conn)
            RD = CMD.ExecuteReader
            RD.Read()

            MessageBox.Show("Data Berhasil Ditambah", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If MsgBoxResult.Ok Then
                Call bukaDB()
                CMD = New MySqlCommand("update listbarang set total=harga*jumlah where id='" & ComboBox1.Text & "'", conn)
                RD = CMD.ExecuteReader
                RD.Read()
                RD.Close()
                DA = New MySqlDataAdapter("select nama_brg 'Nama Barang', harga 'Harga', jumlah 'Jumlah', total 'Total'  from listbarang", conn)
                DS = New DataSet
                DA.Fill(DS, "listbarang")
                DataGridView1.DataSource = DS.Tables("listbarang")
                DataGridView1.ReadOnly = True
            End If
        End If
    End Sub
    Sub totalBarang()
        Call bukaDB()
        CMD = New MySqlCommand("insert into totaltab (total) select sum(total) from listbarang;", conn)
        RD = CMD.ExecuteReader
        RD.Read()

        MessageBox.Show("Data Berhasil Ditambah", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        If MsgBoxResult.Ok Then
            Call bukaDB()
            CMD = New MySqlCommand("select total from totaltab where id in (select max(id) from totaltab)", conn)
            RD = CMD.ExecuteReader
            RD.Read()
            txt_total.Text = RD.Item("total")
        End If
    End Sub
    'End Sub'
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Format(Now, "HH:mm:ss")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call bukaDB()
        Call tampilCombo()
        txt_total.Enabled = False
        txt_kmbl.Enabled = False
    End Sub

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        Call bukaDB()
        Call tampilBarang()
        Call totalBarang()
        txt_total.Enabled = True
        ComboBox1.Text = ""
        txt_jmlh.Text = ""
        txt_total.Enabled = True
        txt_kmbl.Enabled = True
    End Sub

    Private Sub btn_cetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call bukaDB()
        CMD = New MySqlCommand("insert into transaksi(tanggal,jumlah, jmlh_total,jam) select now(),sum(jumlah), sum(total), now() from listbarang", conn)
        RD = CMD.ExecuteReader
        RD.Read()
        txt_kmbl.Text = Val(txt_byr.Text) - Val(txt_total.Text)

        MessageBox.Show("Kembali " & txt_kmbl.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        If MsgBoxResult.Ok Then
            Call bukaDB()
            CMD = New MySqlCommand("delete from listbarang", conn)
            RD = CMD.ExecuteReader
            RD.Read()
            txt_total.Text = ""
            txt_byr.Text = ""
            txt_kmbl.Text = ""
            RD.Close()
            DA = New MySqlDataAdapter("select nama_brg 'Nama Barang', harga 'Harga', jumlah 'Jumlah', total 'Total'  from listbarang", conn)
            DS = New DataSet
            DA.Fill(DS, "listbarang")
            DataGridView1.DataSource = DS.Tables("listbarang")
            DataGridView1.ReadOnly = True
        End If
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub
End Class
