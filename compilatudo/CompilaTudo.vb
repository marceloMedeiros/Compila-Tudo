Imports System.Xml
''' <summary>
'''  Programa para compilar em Lote
''' </summary>
''' <remarks></remarks>
Public Class CompilaTudo

#Region " Variaveis Globais "

    Dim dirList As New ArrayList
    Dim pathFrameWork As String = "C:\Windows\Microsoft.NET\Framework\v3.5\"

    Enum opcao
        gerarBat
        executar
    End Enum

    Dim vopcao As New opcao
    Dim battemp As String = ""

    Public Shared config As New DS

#End Region

#Region " Eventos Click "

    Private Sub btnPastaDestino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPastaDestino.Click
        procurarPasta.ShowDialog()
        txtPastaDestino.Text = procurarPasta.SelectedPath
    End Sub

    Private Sub btnPastaRaiz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPastaRaiz.Click
        procurarPasta.ShowDialog()
        txtPastaRaiz.Text = procurarPasta.SelectedPath
    End Sub

    Private Sub btnGerarBat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGerarBat.Click
        Try
            vopcao = opcao.gerarBat

            dirList.Clear()
            terminal.Clear()

            '   If vopcao = opcao.gerarBat Then salvarArquivo.ShowDialog()
            '  procurarPasta.ShowDialog()
            faz_tudo()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCompilar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompilar.Click
        Try
            vopcao = opcao.executar

            dirList.Clear()
            terminal.Clear()

            '    procurarPasta.ShowDialog()


            BackgroundWorker1.RunWorkerAsync()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ParametrosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParametrosToolStripMenuItem.Click
        Dim telaDeConfiguracoes As New configuracoes()
        telaDeConfiguracoes.StartPosition = FormStartPosition.CenterScreen
        telaDeConfiguracoes.ShowDialog()
        aplicaConfigs()
        salvarConfigs()
    End Sub

#End Region

#Region " Outros Eventos "

    Private Sub txtsDePath_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPastaRaiz.TextChanged, txtPastaDestino.TextChanged
        Dim habilitado As Boolean = IIf(My.Computer.FileSystem.DirectoryExists(txtPastaRaiz.Text), True, False) _
                          And IIf(My.Computer.FileSystem.DirectoryExists(txtPastaDestino.Text), True, False)
        btnGerarBat.Enabled = habilitado
        btnCompilar.Enabled = habilitado
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPastaRaiz.Text = "c:\Grapes.v4.1\Fontes\Sistema CBA"
        txtPastaDestino.Text = "C:\Users\Marcelo\Documents\DLLs cba"

        If Not carregarConfigs() Then salvarConfigs()

    End Sub

#End Region

#Region " Funções "

    Private Sub faz_tudo(Optional ByVal diretorio As String = Nothing)
        Try
            If diretorio Is Nothing Then
                msg("Procurando pastas")
                Dim vcomand As String = ""
                Dim vStep As Integer = 0

                dirList.AddRange(My.Computer.FileSystem.GetDirectories(txtPastaRaiz.Text))

                'Efetua a explosão dos subdiretórios da pasta raiz
                While vStep < dirList.Count
                    msg("Procurando pastas. Faltam:" & dirList.Count - vStep)
                    faz_tudo(dirList(vStep))
                    vStep += 1
                End While
                ''
                filtra()

                vcomand = gerarComandos(txtPastaDestino.Text)

                If vopcao = opcao.gerarBat Then
                    My.Computer.FileSystem.WriteAllText(txtPastaDestino.Text & "\compilar.bat", vcomand, False)
                End If

                'chamando a funcao recursivamente
            Else
                If Not sttb.Text.StartsWith("Procurando sub-pastas em:") Then
                    msg("Procurando sub-pastas em: " & diretorio)
                End If
                msg(sttb.Text.Split(":").First & ": " & diretorio)
                dirList.AddRange(My.Computer.FileSystem.GetDirectories(diretorio))
                Exit Sub
                End If
                If vopcao = opcao.executar Then
                    MsgBox("Projetos compilados com sucesso")
                ElseIf vopcao = opcao.gerarBat Then
                    MsgBox("Arquivo .bat gerado com sucesso")
                End If
                val(0)
                msg("")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub filtra()
        'Filtra os diretórios deixando apenas os que contém solutions
        Dim vcont As Integer = dirList.Count
        For Each linha As Object In dirList
            msg("Selecionando pastas de Solution.Faltam: " & vcont)
            Dim vTem As Boolean = False
            For Each arquivo As Object In My.Computer.FileSystem.GetFiles(linha)
                If arquivo.ToString.Contains(".sln") Then
                    vTem = True
                End If
            Next
            If vTem And vopcao = opcao.gerarBat Then
                terminal.Text &= linha & vbNewLine
            End If
            vcont -= 1
        Next

    End Sub

    Private Function gerarComandos(ByVal vcopiar As String) As String
        Dim vRetorno As String = ""
        Dim vComand1 As String = ""
        Dim vComand2 As String = ""
        Dim vSloution As String = ""
        Dim aleatorio As New Random
        Dim arquivoTemp As String = "c:\windows\temp\tmp" & aleatorio.Next(99999)
        battemp = "c:\windows\temp\tmp" & aleatorio.Next(99999) & ".bat"

        My.Computer.FileSystem.WriteAllText(arquivoTemp, "", False)
        My.Computer.FileSystem.WriteAllText(battemp, "", False)

        val(0)
        max(maxDll)

        For Each linha As Object In dirList
            msg("Compilando. Faltam:" & pbar.Maximum - pbar.Value)
            Dim vTem As Boolean = False
            For Each arquivo As Object In My.Computer.FileSystem.GetFiles(linha)
                If arquivo.ToString.Contains(".sln") Then
                    If Not arquivo.ToString.Contains(".sln.") Then
                        vTem = True
                        vSloution = arquivo
                    End If
                End If

            Next

            If vTem Then
                Dim nomeDLL As String = pegaNomeDLL(vSloution)
                '' Coloquei isso pra nao travar quando o caminho pro project no arquivo .sln tiver errado.
                '' Arrumar uma solução melhor no futuro. (Quando for arrumar, procurar todos os lugares
                '' retornando essa string 'ZICA'. la que vai ter q mecher

                If Not nomeDLL = "ZICA" Then

                    vComand1 = pathFrameWork & "msbuild.exe """ & vSloution & """ /t:rebuild"
                    vComand2 = "copy.exe /Y """ & nomeDLL & """ """ & vcopiar & """"
                    vRetorno &= vComand1 & vbNewLine & vComand2 & vbNewLine

                    If vopcao = opcao.executar Then

                        My.Computer.FileSystem.WriteAllText(battemp, vbNewLine & vComand1 & " > " & arquivoTemp & vbNewLine, False)
                        Shell(battemp, AppWinStyle.Hide, True)
                        Txt(My.Computer.FileSystem.ReadAllText(arquivoTemp))

                        Try
                            Dim pathArquivo As String = nomeDLL
                            Dim nomeArquivo As String = pathArquivo.Split("\").Last
                            My.Computer.FileSystem.CopyFile(pathArquivo, vcopiar & "\" & nomeArquivo, True)
                        Catch
                        End Try
                    End If
                End If
            End If

            Invoke(perf)
        Next

        My.Computer.FileSystem.DeleteFile(arquivoTemp)
        My.Computer.FileSystem.DeleteFile(battemp)

        vRetorno &= "pause"
        Return vRetorno
    End Function

    Private Function pegaNomeDLL(ByVal solution As String, Optional ByVal soNome As Boolean = False) As String
        Dim vpastaRaiz As String = ""
        Dim vExtensao As String = ""
        Dim vOutputPath As String = ""
        Dim vAssemblyName As String = ""
        Dim vprojectRoot As String = ""
        Dim projectFile As String = ""

        Dim vSplit() As String = solution.ToString.Split("\")
        Dim vcont As Integer = 0
        While vcont < vSplit.Length - 1
            vpastaRaiz &= vSplit(vcont) & "\"
            vcont += 1
        End While

        vprojectRoot = procuraProject(solution)
        projectFile = vpastaRaiz & vprojectRoot

        Dim xmlProject As Object = abrirXML(projectFile)
        If xmlProject.GetType Is GetType(XmlDocument) Then

            Dim dsProject As DataSet = xmlParaDataset(xmlProject)

            vExtensao = IIf(dsProject.Tables(0).Rows(0).Item("OutputType") = "Library", ".dll", ".exe")
            vAssemblyName = dsProject.Tables(0).Rows(0).Item("Assemblyname")
            vOutputPath = dsProject.Tables(1).Rows(0).Item("OutputPath")


            Return vpastaRaiz & vprojectRoot.Split("\").First & "\" & vOutputPath & vAssemblyName & vExtensao
        Else
            Return "ZICA"
        End If
    End Function

    Private Function maxDll() As Integer
        Dim vQtd As Integer = 0
        For Each linha As Object In dirList
            For Each arquivo As Object In My.Computer.FileSystem.GetFiles(linha)
                If arquivo.ToString.Contains(".sln") Then
                    If Not arquivo.ToString.Contains(".sln.") Then
                        vQtd += 1
                    End If
                End If
            Next
        Next
        Return vQtd
    End Function

    Private Function procuraProject(ByVal arquivoSolution As String) As String

        Dim leitorTXT As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(arquivoSolution)
        Dim linha As String = ""
        Dim vRetorno As String = ""

        While Not leitorTXT.EndOfStream
            linha = leitorTXT.ReadLine
            If linha.StartsWith("Project(""") Then
                Dim vPropriedades() As String = linha.Split("""")
                vRetorno = vPropriedades(5)
                Exit While
            End If
        End While

        leitorTXT.Close()
        Return vRetorno
    End Function

    Private Function carregarConfigs() As Boolean
        If My.Computer.FileSystem.FileExists("cfg.xml") Then
            config.ReadXml("cfg.xml")
            aplicaConfigs()
            carregarHistoricos()
            Return True
        End If
        Return False
    End Function

    Public Function salvarConfigs() As Boolean
        Try
            config.WriteXml("cfg.xml", XmlWriteMode.WriteSchema)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Sub aplicaConfigs()
        If Not config.ConfigUsu.Rows.Count = 0 Then
            With config.ConfigUsu.Rows(0)
                pathFrameWork = .Item("pathFrameWork3.5")
                terminal.BackColor = Color.FromArgb(.Item("corTerminalFundo"))
                terminal.ForeColor = Color.FromArgb(.Item("corTerminalFonte"))
            End With
        End If
    End Sub

    Private Sub carregarHistoricos()

    End Sub

#End Region

#Region " threading "

    Delegate Sub TxtBx(ByVal value As String)
    Private Sub Txt(ByVal value As String)
        If terminal.InvokeRequired Then
            Dim d As New TxtBx(AddressOf Txt)
            terminal.Invoke(d, value)
        Else
            terminal.AppendText(value)
            terminal.Refresh()
        End If
    End Sub

    Delegate Sub Stb(ByVal value As String)
    Private Sub msg(ByVal value As String)
        If terminal.InvokeRequired Then
            Dim d As New Stb(AddressOf msg)
            sttb.Invoke(d, value)
        Else
            sttb.Text = value
            sttb.Refresh()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        faz_tudo()
    End Sub

    Delegate Sub maxPbar(ByVal value As Integer)
    Delegate Sub valPbar(ByVal value As Integer)
    Dim perf As New MethodInvoker(AddressOf perfStep)


    Private Sub max(ByVal value As Integer)
        If pbar.InvokeRequired Then
            Dim d As New maxPbar(AddressOf max)
            pbar.Invoke(d, value)
        Else
            pbar.Maximum = value
            pbar.Refresh()
        End If
    End Sub
    Private Sub val(ByVal value As Integer)
        If pbar.InvokeRequired Then
            Dim d As New valPbar(AddressOf val)
            pbar.Invoke(d, value)
        Else
            pbar.Value = value
            pbar.Refresh()
        End If
    End Sub
    Private Sub perfStep()
        pbar.PerformStep()
    End Sub

#End Region

#Region " Interface com XML "

    Private Function abrirXML(ByVal filename As String) As Object
        Try
            Dim xmlF As New Xml.XmlDocument
            xmlF.Load(filename)
            Return xmlF
        Catch ex As Exception
            Return "ZICA"
        End Try
    End Function

    Private Function salvarXML(ByRef xmlDoc As XDocument, _
                               ByVal filename As String) As Boolean
        xmlDoc.Save(filename)
    End Function

    Private Function xmlParaDataset(ByVal docXML As XmlDocument) As DataSet

        '1ª parte - Criar um dataset dinamicamente para receber o conteúdo do XML
        ' Para cada node do XML será adicinado um datatable correspondente no dataset
        ' Para cada element dentro do node, será criado uma coluna correspondente no datatable 

        Dim datasetRet = New DataSet

        For Each todosNodes As XmlNode In docXML

            Dim incrementaNomeTabela As String = ""
            ''adicionar cada node como uma datatable no dataset
            For Each cadaNode As XmlNode In todosNodes.ChildNodes

                'Esse while é para impedir que tente-se criar 
                'dois dataset com o mesmo nome (caso hajam nodes com
                'o mesmo nome no XML)
                While Not datasetRet.Tables(cadaNode.Name & incrementaNomeTabela) Is Nothing
                    If incrementaNomeTabela = "" Then incrementaNomeTabela = 0
                    incrementaNomeTabela += 1
                End While
                'adiciona a datatable
                datasetRet.Tables.Add(cadaNode.Name & incrementaNomeTabela)

                Dim incrementaNomeColuna As String = ""
                '' adicionar as colunas das tabelas
                For Each item As XmlElement In cadaNode
                    'Esse while é para impedir que tente-se criar 
                    'dois datacolums com o mesmo nome (caso hajam elements com
                    'o mesmo nome no XML)
                    While Not datasetRet.Tables(cadaNode.Name & incrementaNomeTabela).Columns(item.Name & incrementaNomeColuna) Is Nothing
                        If incrementaNomeColuna = "" Then incrementaNomeColuna = 0
                        incrementaNomeColuna += 1
                    End While
                    'adiciona a datacolum
                    datasetRet.Tables(cadaNode.Name & incrementaNomeTabela).Columns.Add(item.Name & incrementaNomeColuna)
                Next
                incrementaNomeColuna = ""
            Next
            incrementaNomeTabela = ""
        Next


        '2ª Parte - Popular o dataset com os dados do XML

        For Each todosNodes As XmlNode In docXML
            ''
            Dim nodecount As Integer = 0
            For Each cadaNode As XmlNode In todosNodes.ChildNodes
                Dim columcount As Integer = 0
                '' 
                Dim novalinha As DataRow = datasetRet.Tables(nodecount).NewRow
                For Each item As XmlElement In cadaNode
                    '
                    novalinha.Item(columcount) = item.InnerXml
                    '
                    columcount += 1
                Next
                datasetRet.Tables(nodecount).Rows.Add(novalinha)
                nodecount += 1
            Next
        Next

        Return datasetRet
    End Function

#End Region

End Class
