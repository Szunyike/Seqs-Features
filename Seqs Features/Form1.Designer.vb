<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ContecenateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReMergeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BySeqPositionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenBankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileNameCommonNameEtcToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GFFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WithFastaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MultiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeqsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeqsContainsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WholeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CDSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NAAAFromGenBankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WholeDictionaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WholeIIIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromJellyfishToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContecenateToolStripMenuItem, Me.GenBankToolStripMenuItem, Me.GFFToolStripMenuItem, Me.ReNameToolStripMenuItem, Me.CompressToolStripMenuItem, Me.CDSToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ContecenateToolStripMenuItem
        '
        Me.ContecenateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FromFilesToolStripMenuItem, Me.ReMergeToolStripMenuItem, Me.BySeqPositionsToolStripMenuItem})
        Me.ContecenateToolStripMenuItem.Name = "ContecenateToolStripMenuItem"
        Me.ContecenateToolStripMenuItem.Size = New System.Drawing.Size(104, 24)
        Me.ContecenateToolStripMenuItem.Text = "Contecenate"
        '
        'FromFilesToolStripMenuItem
        '
        Me.FromFilesToolStripMenuItem.Name = "FromFilesToolStripMenuItem"
        Me.FromFilesToolStripMenuItem.Size = New System.Drawing.Size(191, 26)
        Me.FromFilesToolStripMenuItem.Text = "From Files"
        '
        'ReMergeToolStripMenuItem
        '
        Me.ReMergeToolStripMenuItem.Name = "ReMergeToolStripMenuItem"
        Me.ReMergeToolStripMenuItem.Size = New System.Drawing.Size(191, 26)
        Me.ReMergeToolStripMenuItem.Text = "ReMerge"
        '
        'BySeqPositionsToolStripMenuItem
        '
        Me.BySeqPositionsToolStripMenuItem.Name = "BySeqPositionsToolStripMenuItem"
        Me.BySeqPositionsToolStripMenuItem.Size = New System.Drawing.Size(191, 26)
        Me.BySeqPositionsToolStripMenuItem.Text = "By Seq Positions"
        '
        'GenBankToolStripMenuItem
        '
        Me.GenBankToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileNameCommonNameEtcToolStripMenuItem})
        Me.GenBankToolStripMenuItem.Name = "GenBankToolStripMenuItem"
        Me.GenBankToolStripMenuItem.Size = New System.Drawing.Size(79, 24)
        Me.GenBankToolStripMenuItem.Text = "GenBank"
        '
        'FileNameCommonNameEtcToolStripMenuItem
        '
        Me.FileNameCommonNameEtcToolStripMenuItem.Name = "FileNameCommonNameEtcToolStripMenuItem"
        Me.FileNameCommonNameEtcToolStripMenuItem.Size = New System.Drawing.Size(280, 26)
        Me.FileNameCommonNameEtcToolStripMenuItem.Text = "FileName Common Name etc"
        '
        'GFFToolStripMenuItem
        '
        Me.GFFToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WithFastaToolStripMenuItem, Me.MultiToolStripMenuItem})
        Me.GFFToolStripMenuItem.Name = "GFFToolStripMenuItem"
        Me.GFFToolStripMenuItem.Size = New System.Drawing.Size(45, 24)
        Me.GFFToolStripMenuItem.Text = "GFF"
        '
        'WithFastaToolStripMenuItem
        '
        Me.WithFastaToolStripMenuItem.Name = "WithFastaToolStripMenuItem"
        Me.WithFastaToolStripMenuItem.Size = New System.Drawing.Size(178, 26)
        Me.WithFastaToolStripMenuItem.Text = "1-1 With Fasta"
        '
        'MultiToolStripMenuItem
        '
        Me.MultiToolStripMenuItem.Name = "MultiToolStripMenuItem"
        Me.MultiToolStripMenuItem.Size = New System.Drawing.Size(178, 26)
        Me.MultiToolStripMenuItem.Text = "Multi"
        '
        'ReNameToolStripMenuItem
        '
        Me.ReNameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeqsToolStripMenuItem, Me.SeqsContainsToolStripMenuItem})
        Me.ReNameToolStripMenuItem.Name = "ReNameToolStripMenuItem"
        Me.ReNameToolStripMenuItem.Size = New System.Drawing.Size(78, 24)
        Me.ReNameToolStripMenuItem.Text = "ReName"
        '
        'SeqsToolStripMenuItem
        '
        Me.SeqsToolStripMenuItem.Name = "SeqsToolStripMenuItem"
        Me.SeqsToolStripMenuItem.Size = New System.Drawing.Size(176, 26)
        Me.SeqsToolStripMenuItem.Text = "Seqs Match"
        '
        'SeqsContainsToolStripMenuItem
        '
        Me.SeqsContainsToolStripMenuItem.Name = "SeqsContainsToolStripMenuItem"
        Me.SeqsContainsToolStripMenuItem.Size = New System.Drawing.Size(176, 26)
        Me.SeqsContainsToolStripMenuItem.Text = "Seqs Contains"
        '
        'CompressToolStripMenuItem
        '
        Me.CompressToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WholeToolStripMenuItem, Me.WholeDictionaryToolStripMenuItem, Me.WholeIIIToolStripMenuItem, Me.FromJellyfishToolStripMenuItem})
        Me.CompressToolStripMenuItem.Name = "CompressToolStripMenuItem"
        Me.CompressToolStripMenuItem.Size = New System.Drawing.Size(86, 24)
        Me.CompressToolStripMenuItem.Text = "Compress"
        '
        'WholeToolStripMenuItem
        '
        Me.WholeToolStripMenuItem.Name = "WholeToolStripMenuItem"
        Me.WholeToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.WholeToolStripMenuItem.Text = "Whole"
        '
        'CDSToolStripMenuItem
        '
        Me.CDSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NAAAFromGenBankToolStripMenuItem})
        Me.CDSToolStripMenuItem.Name = "CDSToolStripMenuItem"
        Me.CDSToolStripMenuItem.Size = New System.Drawing.Size(49, 24)
        Me.CDSToolStripMenuItem.Text = "CDS"
        '
        'NAAAFromGenBankToolStripMenuItem
        '
        Me.NAAAFromGenBankToolStripMenuItem.Name = "NAAAFromGenBankToolStripMenuItem"
        Me.NAAAFromGenBankToolStripMenuItem.Size = New System.Drawing.Size(229, 26)
        Me.NAAAFromGenBankToolStripMenuItem.Text = "NA AA From GenBank"
        '
        'WholeDictionaryToolStripMenuItem
        '
        Me.WholeDictionaryToolStripMenuItem.Name = "WholeDictionaryToolStripMenuItem"
        Me.WholeDictionaryToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.WholeDictionaryToolStripMenuItem.Text = "Whole Dictionary"
        '
        'WholeIIIToolStripMenuItem
        '
        Me.WholeIIIToolStripMenuItem.Name = "WholeIIIToolStripMenuItem"
        Me.WholeIIIToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.WholeIIIToolStripMenuItem.Text = "Whole III"
        '
        'FromJellyfishToolStripMenuItem
        '
        Me.FromJellyfishToolStripMenuItem.Name = "FromJellyfishToolStripMenuItem"
        Me.FromJellyfishToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.FromJellyfishToolStripMenuItem.Text = "From jellyfish"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ContecenateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FromFilesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenBankToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileNameCommonNameEtcToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GFFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WithFastaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReNameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeqsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReMergeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompressToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WholeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MultiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CDSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NAAAFromGenBankToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeqsContainsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BySeqPositionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WholeDictionaryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WholeIIIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FromJellyfishToolStripMenuItem As ToolStripMenuItem
End Class
