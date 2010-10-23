Public Class configuracoes

    Dim config As DataTable = CompilaTudo.config.ConfigUsu

    Private Sub procurarPasta(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click, Button2.Click, Button1.Click
        procuraPasta.Reset()
        Dim txt As TextBox
        Select Case sender.name
            Case "Button3"
                procuraPasta.Description = "Path do Msbuild VS2008"
                txt = txt2008
            Case "Button2"
                procuraPasta.Description = "Path do Msbuild VS2002 (Não implementado)"
                txt = txt2002
            Case "Button1"
                procuraPasta.Description = "Path do Msbuild VS2010 (Não implementado)"
                txt = txt2010
        End Select
        If procuraPasta.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txt.Text = procuraPasta.SelectedPath
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click, Button7.Click
        escolherCor.Reset()
        If escolherCor.ShowDialog = Windows.Forms.DialogResult.OK Then
            sender.backcolor = escolherCor.Color
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        le_configuracoes()
    End Sub

    Private Sub le_configuracoes()
        If Not config.Rows.Count = 0 Then
            Button8.BackColor = Color.FromArgb(config.Rows(0).Item("corTerminalFonte"))
            Button7.BackColor = Color.FromArgb(config.Rows(0).Item("corTerminalFundo"))
            txt2008.Text = config.Rows(0).Item("pathFrameWork3.5")
            ' config.Rows(0).Item("Usuario") = ""
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        pegaValores()
        CompilaTudo.aplicaConfigs()
        CompilaTudo.salvarConfigs()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        pegaValores()
        CompilaTudo.aplicaConfigs()
        CompilaTudo.salvarConfigs()
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub pegaValores()
        If config.Rows.Count = 0 Then
            Dim novaLinha As DataRow = config.NewRow
            With novaLinha
                .Item("corTerminalFundo") = Button7.BackColor.ToArgb
                .Item("corTerminalFonte") = Button8.BackColor.ToArgb
                .Item("pathFrameWork3.5") = txt2008.Text
                .Item("Usuario") = ""
            End With
            config.Rows.Add(novaLinha)
        Else
            With config.Rows(0)
                .Item("corTerminalFundo") = Button7.BackColor.ToArgb
                .Item("corTerminalFonte") = Button8.BackColor.ToArgb
                .Item("pathFrameWork3.5") = txt2008.Text
                .Item("Usuario") = ""
            End With
        End If
    End Sub

End Class