Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.IO

Namespace folderSelect
    ''' <summary> class FolderSelect
    ''' <para>An example on how to build a folder browser dialog window using C# and the .Net framework.</para>
    ''' </summary>
    Public Class FolderSelect
        Inherits System.Windows.Forms.Form
        Private Shared driveLetters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Private folder As DirectoryInfo
        Private panel1 As System.Windows.Forms.Panel
        Private panel3 As System.Windows.Forms.Panel
        Private textBox1 As System.Windows.Forms.TextBox
        Private label1 As System.Windows.Forms.Label
        Friend WithEvents treeView1 As System.Windows.Forms.TreeView
        Friend WithEvents cancelBtn As System.Windows.Forms.Button
        Friend WithEvents selectBtn As System.Windows.Forms.Button
        Private imageList1 As System.Windows.Forms.ImageList
        Private components As System.ComponentModel.IContainer

        Public vResultado As String = String.Empty

        ''' <summary> method fillTree
        ''' <para>This method is used to initially fill the treeView control with a list
        ''' of available drives from which you can search for the desired folder.</para>
        ''' </summary>
        Private Sub fillTree()
            Dim directory As DirectoryInfo
            Dim sCurPath As String = ""

            ' clear out the old values
            treeView1.Nodes.Clear()
            Dim c As Char

            ' loop through the drive letters and find the available drives.
            For Each c In driveLetters
                sCurPath = c + ":\"
                Try
                    ' get the directory informaiton for this path.
                    directory = New DirectoryInfo(sCurPath)

                    ' if the retrieved directory information points to a valid
                    ' directory or drive in this case, add it to the root of the
                    ' treeView.
                    If directory.Exists = True Then
                        Dim newNode As New TreeNode(directory.FullName)
                        treeView1.Nodes.Add(newNode)
                        ' add the new node to the root level.
                        ' scan for any sub folders on this drive.
                        getSubDirs(newNode)
                    End If
                Catch doh As Exception
                    Console.WriteLine(doh.Message)
                End Try
            Next
        End Sub

        ''' <summary> method getSubDirs
        ''' <para>this function will scan the specified parent for any subfolders
        ''' if they exist. To minimize the memory usage, we only scan a single
        ''' folder level down from the existing, and only if it is needed.</para>
        ''' <param name="parent">the parent folder in which to search for sub-folders.</param>
        ''' </summary>
        Private Sub getSubDirs(ByVal parent As TreeNode)
            Dim directory As DirectoryInfo
            Try
                ' if we have not scanned this folder before
                If parent.Nodes.Count = 0 Then
                    directory = New DirectoryInfo(parent.FullPath)
                    Dim dir As DirectoryInfo
                    For Each dir In directory.GetDirectories()
                        Dim newNode As New TreeNode(dir.Name)
                        parent.Nodes.Add(newNode)
                    Next
                End If

                ' now that we have the children of the parent, see if they
                ' have any child members that need to be scanned. Scanning
                ' the first level of sub folders insures that you properly
                ' see the '+' or '-' expanding controls on each node that represents
                ' a sub folder with it's own children.
                Dim node As TreeNode
                For Each node In parent.Nodes
                    ' if we have not scanned this node before.
                    If node.Nodes.Count = 0 Then
                        ' get the folder information for the specified path.
                        directory = New DirectoryInfo(node.FullPath)

                        ' check this folder for any possible sub-folders
                        Dim dir As DirectoryInfo
                        For Each dir In directory.GetDirectories()
                            ' make a new TreeNode and add it to the treeView.
                            Dim newNode As New TreeNode(dir.Name)
                            node.Nodes.Add(newNode)
                        Next
                    End If
                Next
            Catch doh As Exception
                Console.WriteLine(doh.Message)
            End Try
        End Sub

        ''' <summary> method fixPath
        ''' <para>For some reason, the treeView will only work with paths constructed like the following example.
        ''' "c:\\Program Files\Microsoft\...". What this method does is strip the leading "\\" next to the drive
        ''' letter.</para>
        ''' <param name="node">the folder that needs it's path fixed for display.</param>
        ''' <returns>The correctly formatted full path to the selected folder.</returns>
        ''' </summary>
        Private Function fixPath(ByVal node As TreeNode) As String
            Dim sRet As String = ""
            Try
                sRet = node.FullPath
                Dim index As Integer = sRet.IndexOf("\\")
                If index > 1 Then
                    sRet = node.FullPath.Remove(index, 1)
                End If
            Catch doh As Exception
                Console.WriteLine(doh.Message)
            End Try
            Return sRet
        End Function
        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not components Is Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()

            '
            ' TODO: Add any constructor code after InitializeComponent call
            '

            ' initialize the treeView
            fillTree()
        End Sub

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private WithEvents panel2 As System.Windows.Forms.Panel
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FolderSelect))
            Me.panel1 = New System.Windows.Forms.Panel()
            Me.label1 = New System.Windows.Forms.Label()
            Me.textBox1 = New System.Windows.Forms.TextBox()
            Me.cancelBtn = New System.Windows.Forms.Button()
            Me.selectBtn = New System.Windows.Forms.Button()
            Me.panel3 = New System.Windows.Forms.Panel()
            Me.treeView1 = New System.Windows.Forms.TreeView()
            Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
            Me.panel2 = New System.Windows.Forms.Panel()
            Me.panel1.SuspendLayout()
            Me.panel3.SuspendLayout()
            Me.panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'panel1
            '
            Me.panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.label1})
            Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.panel1.DockPadding.All = 10
            Me.panel1.Location = New System.Drawing.Point(6, 6)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(310, 26)
            Me.panel1.TabIndex = 0
            '
            'label1
            '
            Me.label1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.label1.ForeColor = System.Drawing.SystemColors.Desktop
            Me.label1.Location = New System.Drawing.Point(8, 7)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(96, 16)
            Me.label1.TabIndex = 1
            Me.label1.Text = "Selecione a Pasta:"
            '
            'textBox1
            '
            Me.textBox1.BackColor = System.Drawing.SystemColors.Window
            Me.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.textBox1.Location = New System.Drawing.Point(8, 10)
            Me.textBox1.Name = "textBox1"
            Me.textBox1.ReadOnly = True
            Me.textBox1.Size = New System.Drawing.Size(292, 20)
            Me.textBox1.TabIndex = 0
            Me.textBox1.Text = ""
            '
            'cancelBtn
            '
            Me.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.cancelBtn.Location = New System.Drawing.Point(225, 36)
            Me.cancelBtn.Name = "cancelBtn"
            Me.cancelBtn.Size = New System.Drawing.Size(75, 21)
            Me.cancelBtn.TabIndex = 3
            Me.cancelBtn.Text = "&Cancelar"
            '
            'selectBtn
            '
            Me.selectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.selectBtn.Location = New System.Drawing.Point(145, 36)
            Me.selectBtn.Name = "selectBtn"
            Me.selectBtn.Size = New System.Drawing.Size(75, 21)
            Me.selectBtn.TabIndex = 2
            Me.selectBtn.Text = "&Selecionar"
            '
            'panel3
            '
            Me.panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.treeView1})
            Me.panel3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.panel3.Location = New System.Drawing.Point(6, 32)
            Me.panel3.Name = "panel3"
            Me.panel3.Size = New System.Drawing.Size(310, 166)
            Me.panel3.TabIndex = 2
            '
            'treeView1
            '
            Me.treeView1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.treeView1.ImageList = Me.imageList1
            Me.treeView1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.treeView1.Name = "treeView1"
            Me.treeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node0", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node1", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Node2")})})})
            Me.treeView1.Size = New System.Drawing.Size(310, 166)
            Me.treeView1.TabIndex = 0
            '
            'imageList1
            '
            Me.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
            Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
            Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
            '
            'panel2
            '
            Me.panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox1, Me.cancelBtn, Me.selectBtn})
            Me.panel2.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.panel2.DockPadding.All = 10
            Me.panel2.Location = New System.Drawing.Point(6, 198)
            Me.panel2.Name = "panel2"
            Me.panel2.Size = New System.Drawing.Size(310, 64)
            Me.panel2.TabIndex = 1
            '
            'FolderSelect
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(322, 268)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.panel3, Me.panel2, Me.panel1})
            Me.DockPadding.All = 6
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.MinimumSize = New System.Drawing.Size(230, 300)
            Me.Name = "FolderSelect"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Escolha a pasta"
            Me.panel1.ResumeLayout(False)
            Me.panel3.ResumeLayout(False)
            Me.panel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
#End Region

        ''' <summary> method treeView1_BeforeSelect
        ''' <para>Before we select a tree node we want to make sure that we scan the soon to be selected
        ''' tree node for any sub-folders. this insures proper tree construction on the fly.</para>
        ''' <param name="sender">The object that invoked this event</param>
        ''' <param name="e">The TreeViewCancelEventArgs event arguments.</param>
        ''' <see cref="System.Windows.Forms.TreeViewCancelEventArgs"/>
        ''' <see cref="System.Windows.Forms.TreeView"/>
        ''' </summary>
        Private Sub treeView1_BeforeSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles treeView1.BeforeSelect
            getSubDirs(e.Node)
            ' get the sub-folders for the selected node.
            textBox1.Text = fixPath(e.Node)
            ' update the user selection text box.
            folder = New DirectoryInfo(e.Node.FullPath)
            ' get it's Directory info.
        End Sub

        ''' <summary> method treeView1_BeforeExpand
        ''' <para>Before we expand a tree node we want to make sure that we scan the soon to be expanded
        ''' tree node for any sub-folders. this insures proper tree construction on the fly.</para>
        ''' <param name="sender">The object that invoked this event</param>
        ''' <param name="e">The TreeViewCancelEventArgs event arguments.</param>
        ''' <see cref="System.Windows.Forms.TreeViewCancelEventArgs"/>
        ''' <see cref="System.Windows.Forms.TreeView"/>
        ''' </summary>
        Private Sub treeView1_BeforeExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles treeView1.BeforeExpand
            getSubDirs(e.Node)
            ' get the sub-folders for the selected node.
            textBox1.Text = fixPath(e.Node)
            ' update the user selection text box.
            folder = New DirectoryInfo(e.Node.FullPath)
            ' get it's Directory info.
        End Sub

        ''' <summary> method cancelBtn_Click
        ''' <para>This method cancels the folder browsing.</para>
        ''' </summary>
        Private Sub cancelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelBtn.Click
            folder = Nothing
            Me.Close()
        End Sub

        ''' <summary> method selectBtn_Click
        ''' <para>This method accepts which ever folder is selected and closes this application
        ''' with a DialogResult.OK result if you invoke this form though Form.ShowDialog().
        ''' In this example this method simply looks up the selected folder, and presents the
        ''' user with a message box displaying the name and path of the selected folder.
        ''' </para>
        ''' </summary>
        Private Sub selectBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selectBtn.Click
            Me.vResultado = textBox1.Text
            Me.Close()
        End Sub

        ''' <summary> method name
        ''' <para>A method to retrieve the short name for the selected folder.</para>
        ''' <returns>The folder name for the selected folder.</returns>
        ''' </summary>
        Public ReadOnly Property Names() As String
            Get
                Return IIf(((Not folder Is Nothing AndAlso folder.Exists)), folder.Name, Nothing)
            End Get
        End Property

        ''' <summary> method fullPath
        ''' <para>Retrieve the full path for the selected folder.</para>
        '''
        ''' <returns>The correctly formatted full path to the selected folder.</returns>
        ''' <seealso cref="FolderSelect.fixPath"/>
        ''' </summary>
        Public ReadOnly Property fullPath() As String
            Get
                Return IIf(((Not folder Is Nothing AndAlso folder.Exists AndAlso Not treeView1.SelectedNode Is Nothing)), fixPath(treeView1.SelectedNode), Nothing)
            End Get
        End Property

        ''' <summary> method info
        ''' <para>Retrieve the full DirectoryInfo object associated with the selected folder. Note
        ''' that this will not have the corrected full path string.</para>
        ''' <returns>The full DirectoryInfo object associated with the selected folder.</returns>
        ''' <see cref="System.IO.DirectoryInfo"/>
        ''' </summary>
        Public ReadOnly Property info() As DirectoryInfo
            Get
                Return IIf(((Not folder Is Nothing AndAlso folder.Exists)), folder, Nothing)
            End Get
        End Property
    End Class
End Namespace