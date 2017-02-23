<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SourcePictureBox = New System.Windows.Forms.PictureBox()
        Me.CodeRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageNameTextBox = New System.Windows.Forms.TextBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SourcePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SourcePictureBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ImageNameTextBox)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.CodeRichTextBox)
        Me.SplitContainer1.Size = New System.Drawing.Size(745, 469)
        Me.SplitContainer1.SplitterDistance = 356
        Me.SplitContainer1.TabIndex = 0
        '
        'SourcePictureBox
        '
        Me.SourcePictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SourcePictureBox.Location = New System.Drawing.Point(0, 22)
        Me.SourcePictureBox.Name = "SourcePictureBox"
        Me.SourcePictureBox.Size = New System.Drawing.Size(356, 447)
        Me.SourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.SourcePictureBox.TabIndex = 0
        Me.SourcePictureBox.TabStop = False
        '
        'CodeRichTextBox
        '
        Me.CodeRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CodeRichTextBox.Font = New System.Drawing.Font("Consolas", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodeRichTextBox.Location = New System.Drawing.Point(0, 0)
        Me.CodeRichTextBox.Name = "CodeRichTextBox"
        Me.CodeRichTextBox.Size = New System.Drawing.Size(385, 469)
        Me.CodeRichTextBox.TabIndex = 0
        Me.CodeRichTextBox.Text = ""
        Me.CodeRichTextBox.WordWrap = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(745, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(129, 26)
        Me.OpenToolStripMenuItem.Text = "Open..."
        '
        'ImageNameTextBox
        '
        Me.ImageNameTextBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.ImageNameTextBox.Location = New System.Drawing.Point(0, 0)
        Me.ImageNameTextBox.Name = "ImageNameTextBox"
        Me.ImageNameTextBox.Size = New System.Drawing.Size(356, 22)
        Me.ImageNameTextBox.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 497)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "img2code"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.SourcePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SourcePictureBox As PictureBox
    Friend WithEvents CodeRichTextBox As RichTextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageNameTextBox As TextBox
End Class
