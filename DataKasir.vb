﻿Imports MySql.Data.MySqlClient
Public Class DataKasir
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Format(Now, "HH:mm:ss")
    End Sub
    Dim HostConn As New MySqlConnection
    Dim da As MySqlDataAdapter 'varibel ini berguna untuk mengupdate dataset dan datasource'
    Dim dst As New DataSet 'miniatur dari tabel yang terdapat pada MySql/cache tabel pada client'
    Dim State As StateEnum 'status apakah data ditambah, diedit, ataukah idle'
    'Enum merupakan kumpulan konstan yang saling berhubungan'
    Private Enum StateEnum
        StateIdle = 0
        StateNew = 1
        StateEdit = 2
    End Enum
    Private Sub EnableText()
        txt_username.Enabled = True
        txt_nama.Enabled = True
        txt_pass.Enabled = True
        txt_alamat.Enabled = True
        txt_nop.Enabled = True
    End Sub
    Private Sub DisableText()
        txt_username.Enabled = False
        txt_nama.Enabled = False
        txt_pass.Enabled = False
        txt_alamat.Enabled = False
        txt_nop.Enabled = False
    End Sub
    Private Sub ClearText()
        txt_username.Clear()
        txt_nama.Clear()
        txt_pass.Clear()
        txt_alamat.Clear()
        txt_nop.Clear()
    End Sub
    Private Sub DisableButton()
        btn_add.Enabled = False
        btn_edit.Enabled = False
        btn_save.Enabled = False
        btn_delete.Enabled = False
        btn_Cancel.Enabled = False
    End Sub
    Private Sub StateChange()
        Select Case State
            Case Is = StateEnum.StateIdle
                Call ClearText()
                Call DisableText()
                Call DisableButton()
                btn_add.Enabled = True
                btn_edit.Enabled = True
                btn_delete.Enabled = True
                DataGridView1.Enabled = True
            Case Is = StateEnum.StateNew
                Call EnableText()
                Call ClearText()
                Call DisableButton()
                btn_cancel.Enabled = True
                btn_save.Enabled = True
            Case Is = StateEnum.StateEdit
                Call EnableText()
                Call DisableButton()
                btn_cancel.Enabled = True
                btn_save.Enabled = True
        End Select
    End Sub
    Private Sub RemoveDataBindings()
        Dim Ctrl As Control
        For Each Ctrl In GroupBox1.Controls
            Ctrl.DataBindings.Clear()
        Next Ctrl
    End Sub

    Private Sub DataKasir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RD.Close()
        connect("localhost", "root", "", "db_minimarket")
        State = StateEnum.StateIdle
        Call StateChange()
        Try
            da = New MySqlDataAdapter("SELECT * FROM kasir", conn)
            da.Fill(dst, "kasir")
            DataGridView1.DataSource = dst.Tables("kasir")
            DataGridView1.Text = "Record no. " & DataGridView1.CurrentRow.Index() + 1 & " of " & dst.Tables("kasir").Rows.Count()
        Catch myerror As MySqlException
            MessageBox.Show("Error Connecting to Database: " & myerror.Message)
        End Try
    End Sub

    Private Sub DataKasir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        AdminDashboard.Show()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        State = StateEnum.StateEdit
        Call StateChange()
        Me.BindingContext(dst.Tables("kasir")).Position = DataGridView1.CurrentRow.Index()
        txt_username.DataBindings.Add("text", dst.Tables("kasir"), "Username")
        txt_nama.DataBindings.Add("text", dst.Tables("kasir"), "Nama")
        txt_pass.DataBindings.Add("text", dst.Tables("kasir"), "Password")
        txt_alamat.DataBindings.Add("text", dst.Tables("kasir"), "Alamat")
        txt_nop.DataBindings.Add("text", dst.Tables("kasir"), "No_hp")
        Call RemoveDataBindings()
        DataGridView1.Enabled = False
    End Sub

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        State = StateEnum.StateNew
        Call StateChange()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        dst.Tables("kasir").Rows(DataGridView1.CurrentRow.Index()).Delete()
        Dim MyCommBuilder As New MySqlCommandBuilder(da)
        da.Update(dst, "kasir")
    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        State = StateEnum.StateIdle
        Call StateChange()
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Select Case State
            Case Is = StateEnum.StateNew 'add record'
                Dim MyNewRow As DataRow = dst.Tables("kasir").NewRow()
                Try
                    MyNewRow("Username") = txt_username.Text
                    MyNewRow("Nama") = txt_nama.Text
                    MyNewRow("Password") = txt_pass.Text
                    MyNewRow("Alamat") = txt_alamat.Text
                    MyNewRow("No_hp") = txt_nop.Text
                    dst.Tables("kasir").Rows.Add(MyNewRow)
                    Dim MyCommBuild As New MySqlCommandBuilder(da)
                    da.Update(dst, "kasir")
                    MsgBox("New record has been added", MsgBoxStyle.Information)
                Catch err As Exception
                    MsgBox(err.Message, MsgBoxStyle.Exclamation, "error")
                    dst = New DataSet
                    da = New MySqlDataAdapter("SELECT * FROM kasir", conn)
                    da.Fill(dst, "kasir")
                    DataGridView1.DataSource = dst.Tables("kasir")
                    Exit Sub
                End Try
            Case Is = StateEnum.StateEdit 'edit Record'
                Dim MyEditRow As DataRow = dst.Tables("kasir").Rows(DataGridView1.CurrentRow.Index())
                MyEditRow.BeginEdit()
                MyEditRow("Username") = txt_username.Text
                MyEditRow("Nama") = txt_nama.Text
                MyEditRow("Password") = txt_pass.Text
                MyEditRow("alamat") = txt_alamat.Text
                MyEditRow("No_hp") = txt_nop.Text
                Dim MyCommBuild As New MySqlCommandBuilder(da)
                da.Update(dst, "kasir")
                MsgBox("Record has been updated", MsgBoxStyle.Information)
                DataGridView1.Enabled = True
        End Select
        State = StateEnum.StateIdle
        Call StateChange()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        AdminDashboard.Show()
        Me.Hide()
    End Sub
End Class