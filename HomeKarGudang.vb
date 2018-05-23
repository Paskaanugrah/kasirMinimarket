Imports MySql.Data.MySqlClient
Public Class HomeKarGudang
    Public DA As MySqlDataAdapter
    Public DS As DataSet
    Sub tampilCombo()
        Call bukaDB()
        CMD = New MySqlCommand("select id from barang", conn)
        RD = CMD.ExecuteReader
        idBarang.Items.Clear()
        Do While RD.Read
            idBarang.Items.Add(RD.Item(0))
        Loop
        CMD.Dispose()
        RD.Close()
        conn.Close()
    End Sub
    Sub tampilBarang()
        Call bukaDB()
        DA = New MySqlDataAdapter("select nama_barang 'Nama_Barang', stock 'Stock', expired_date 'Expired_date'  from barang where id='" & idBarang.Text & "'", conn)
        DS = New DataSet
        DA.Fill(DS, "barang")
        DataGridView1.DataSource = DS.Tables("barang")
        DataGridView1.ReadOnly = True
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label4.Text = Format(Now, "HH:mm:ss")
    End Sub

    Private Sub HomeKarGudang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call bukaDB()
        tampilCombo()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        Login.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call bukaDB()
        Call tampilBarang()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call bukaDB()
        ubah = "update barang set stock = stock + '" & txt_stk.Text & "' where id = '" & idBarang.Text & "'"
        With CMD
            .CommandText = ubah
            .Connection = conn
            .ExecuteNonQuery()
        End With

        If RD.HasRows Then
            Call bukaDB()
            CMD = New MySqlCommand("insert into barang (stock) values ('" & txt_stk.Text & "','Peng-update-an Data')", conn)
            RD = CMD.ExecuteReader
            RD.Read()
        End If
        MessageBox.Show("Data Berhasil di-Update", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        If MsgBoxResult.Ok Then
            Call bukaDB()
            DA = New MySqlDataAdapter("select nama_barang 'Nama_Barang', stock 'Stock', expired_date 'Expired_date'  from barang where id='" & idBarang.Text & "'", conn)
            DS = New DataSet
            DA.Fill(DS, "barang")
            DataGridView1.DataSource = DS.Tables("barang")
        End If
        txt_stk.Text = ""
        idBarang.Text = ""
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub txt_stk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_stk.TextChanged

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
End Class