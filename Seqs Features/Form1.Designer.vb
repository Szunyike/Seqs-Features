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
        Me.SplitSequncesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenBankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileNameCommonNameEtcToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GFFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WithFastaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MultiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeqsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeqsContainsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JGIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WholeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WholeDictionaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WholeIIIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromJellyfishToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CDSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NAAAFromGenBankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IllegalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveTermianLStpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HasTermi9nalStopsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HasInternalStopsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InterProScanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InternetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrediGPIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContecenateToolStripMenuItem, Me.GenBankToolStripMenuItem, Me.GFFToolStripMenuItem, Me.ReNameToolStripMenuItem, Me.CompressToolStripMenuItem, Me.CDSToolStripMenuItem, Me.IllegalToolStripMenuItem, Me.InterProScanToolStripMenuItem, Me.InternetToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1240, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ContecenateToolStripMenuItem
        '
        Me.ContecenateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FromFilesToolStripMenuItem, Me.ReMergeToolStripMenuItem, Me.BySeqPositionsToolStripMenuItem, Me.SplitSequncesToolStripMenuItem})
        Me.ContecenateToolStripMenuItem.Name = "ContecenateToolStripMenuItem"
        Me.ContecenateToolStripMenuItem.Size = New System.Drawing.Size(86, 20)
        Me.ContecenateToolStripMenuItem.Text = "Contecenate"
        '
        'FromFilesToolStripMenuItem
        '
        Me.FromFilesToolStripMenuItem.Name = "FromFilesToolStripMenuItem"
        Me.FromFilesToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.FromFilesToolStripMenuItem.Text = "From Files"
        '
        'ReMergeToolStripMenuItem
        '
        Me.ReMergeToolStripMenuItem.Name = "ReMergeToolStripMenuItem"
        Me.ReMergeToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ReMergeToolStripMenuItem.Text = "ReMerge"
        '
        'BySeqPositionsToolStripMenuItem
        '
        Me.BySeqPositionsToolStripMenuItem.Name = "BySeqPositionsToolStripMenuItem"
        Me.BySeqPositionsToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.BySeqPositionsToolStripMenuItem.Text = "By Seq Positions"
        '
        'SplitSequncesToolStripMenuItem
        '
        Me.SplitSequncesToolStripMenuItem.Name = "SplitSequncesToolStripMenuItem"
        Me.SplitSequncesToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.SplitSequncesToolStripMenuItem.Text = "Split Sequnces"
        '
        'GenBankToolStripMenuItem
        '
        Me.GenBankToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileNameCommonNameEtcToolStripMenuItem})
        Me.GenBankToolStripMenuItem.Name = "GenBankToolStripMenuItem"
        Me.GenBankToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.GenBankToolStripMenuItem.Text = "GenBank"
        '
        'FileNameCommonNameEtcToolStripMenuItem
        '
        Me.FileNameCommonNameEtcToolStripMenuItem.Name = "FileNameCommonNameEtcToolStripMenuItem"
        Me.FileNameCommonNameEtcToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.FileNameCommonNameEtcToolStripMenuItem.Text = "FileName Common Name etc"
        '
        'GFFToolStripMenuItem
        '
        Me.GFFToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WithFastaToolStripMenuItem, Me.MultiToolStripMenuItem})
        Me.GFFToolStripMenuItem.Name = "GFFToolStripMenuItem"
        Me.GFFToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.GFFToolStripMenuItem.Text = "GFF"
        '
        'WithFastaToolStripMenuItem
        '
        Me.WithFastaToolStripMenuItem.Name = "WithFastaToolStripMenuItem"
        Me.WithFastaToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.WithFastaToolStripMenuItem.Text = "1-1 With Fasta"
        '
        'MultiToolStripMenuItem
        '
        Me.MultiToolStripMenuItem.Name = "MultiToolStripMenuItem"
        Me.MultiToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.MultiToolStripMenuItem.Text = "Multi"
        '
        'ReNameToolStripMenuItem
        '
        Me.ReNameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeqsToolStripMenuItem, Me.SeqsContainsToolStripMenuItem, Me.JGIToolStripMenuItem})
        Me.ReNameToolStripMenuItem.Name = "ReNameToolStripMenuItem"
        Me.ReNameToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.ReNameToolStripMenuItem.Text = "ReName"
        '
        'SeqsToolStripMenuItem
        '
        Me.SeqsToolStripMenuItem.Name = "SeqsToolStripMenuItem"
        Me.SeqsToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.SeqsToolStripMenuItem.Text = "Seqs Match"
        '
        'SeqsContainsToolStripMenuItem
        '
        Me.SeqsContainsToolStripMenuItem.Name = "SeqsContainsToolStripMenuItem"
        Me.SeqsContainsToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.SeqsContainsToolStripMenuItem.Text = "Seqs Contains"
        '
        'JGIToolStripMenuItem
        '
        Me.JGIToolStripMenuItem.Name = "JGIToolStripMenuItem"
        Me.JGIToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.JGIToolStripMenuItem.Text = "JGI"
        '
        'CompressToolStripMenuItem
        '
        Me.CompressToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WholeToolStripMenuItem, Me.WholeDictionaryToolStripMenuItem, Me.WholeIIIToolStripMenuItem, Me.FromJellyfishToolStripMenuItem})
        Me.CompressToolStripMenuItem.Name = "CompressToolStripMenuItem"
        Me.CompressToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.CompressToolStripMenuItem.Text = "Compress"
        '
        'WholeToolStripMenuItem
        '
        Me.WholeToolStripMenuItem.Name = "WholeToolStripMenuItem"
        Me.WholeToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.WholeToolStripMenuItem.Text = "Whole"
        '
        'WholeDictionaryToolStripMenuItem
        '
        Me.WholeDictionaryToolStripMenuItem.Name = "WholeDictionaryToolStripMenuItem"
        Me.WholeDictionaryToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.WholeDictionaryToolStripMenuItem.Text = "Whole Dictionary"
        '
        'WholeIIIToolStripMenuItem
        '
        Me.WholeIIIToolStripMenuItem.Name = "WholeIIIToolStripMenuItem"
        Me.WholeIIIToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.WholeIIIToolStripMenuItem.Text = "Whole III"
        '
        'FromJellyfishToolStripMenuItem
        '
        Me.FromJellyfishToolStripMenuItem.Name = "FromJellyfishToolStripMenuItem"
        Me.FromJellyfishToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.FromJellyfishToolStripMenuItem.Text = "From jellyfish"
        '
        'CDSToolStripMenuItem
        '
        Me.CDSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NAAAFromGenBankToolStripMenuItem})
        Me.CDSToolStripMenuItem.Name = "CDSToolStripMenuItem"
        Me.CDSToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.CDSToolStripMenuItem.Text = "CDS"
        '
        'NAAAFromGenBankToolStripMenuItem
        '
        Me.NAAAFromGenBankToolStripMenuItem.Name = "NAAAFromGenBankToolStripMenuItem"
        Me.NAAAFromGenBankToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.NAAAFromGenBankToolStripMenuItem.Text = "NA AA From GenBank"
        '
        'IllegalToolStripMenuItem
        '
        Me.IllegalToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveTermianLStpToolStripMenuItem, Me.HasTermi9nalStopsToolStripMenuItem, Me.HasInternalStopsToolStripMenuItem})
        Me.IllegalToolStripMenuItem.Name = "IllegalToolStripMenuItem"
        Me.IllegalToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.IllegalToolStripMenuItem.Text = "Illegal"
        '
        'RemoveTermianLStpToolStripMenuItem
        '
        Me.RemoveTermianLStpToolStripMenuItem.Name = "RemoveTermianLStpToolStripMenuItem"
        Me.RemoveTermianLStpToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.RemoveTermianLStpToolStripMenuItem.Text = "Remove Termian lStp"
        '
        'HasTermi9nalStopsToolStripMenuItem
        '
        Me.HasTermi9nalStopsToolStripMenuItem.Name = "HasTermi9nalStopsToolStripMenuItem"
        Me.HasTermi9nalStopsToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.HasTermi9nalStopsToolStripMenuItem.Text = "Has Termi9nal Stops"
        '
        'HasInternalStopsToolStripMenuItem
        '
        Me.HasInternalStopsToolStripMenuItem.Name = "HasInternalStopsToolStripMenuItem"
        Me.HasInternalStopsToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.HasInternalStopsToolStripMenuItem.Text = "Has Internal Stops"
        '
        'InterProScanToolStripMenuItem
        '
        Me.InterProScanToolStripMenuItem.Name = "InterProScanToolStripMenuItem"
        Me.InterProScanToolStripMenuItem.Size = New System.Drawing.Size(86, 20)
        Me.InterProScanToolStripMenuItem.Text = "InterProScan"
        '
        'InternetToolStripMenuItem
        '
        Me.InternetToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrediGPIToolStripMenuItem, Me.TestToolStripMenuItem, Me.ToolStripMenuItem2})
        Me.InternetToolStripMenuItem.Name = "InternetToolStripMenuItem"
        Me.InternetToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.InternetToolStripMenuItem.Text = "Internet"
        '
        'PrediGPIToolStripMenuItem
        '
        Me.PrediGPIToolStripMenuItem.Name = "PrediGPIToolStripMenuItem"
        Me.PrediGPIToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PrediGPIToolStripMenuItem.Text = "PrediGPI"
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TestToolStripMenuItem.Text = "Test"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 24)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1240, 608)
        Me.WebBrowser1.TabIndex = 1
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem2.Text = "3"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1240, 632)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2)
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
    Friend WithEvents JGIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IllegalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveTermianLStpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HasTermi9nalStopsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HasInternalStopsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InterProScanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitSequncesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InternetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrediGPIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
End Class
