Imports System.Collections.Concurrent
Imports System.IO
Imports Bio.IO.GenBank
Imports Szunyi.Common
Imports Szunyi.Sequences
Imports Szunyi.Features
Imports Szunyi.IO
Imports System.Net
Imports System.Threading
Imports System.Text.RegularExpressions
Imports System.Text
Imports HtmlAgilityPack

Public Class Form1
    Dim log As New System.Text.StringBuilder
    Public Property WB As String
    Public Property cFIle As FileInfo
    Public Property cDIr As DirectoryInfo
    Public oSignalEvent = New ManualResetEvent(False)
    Private Sub FromFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromFilesToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.Fasta.ToList
        Dim SaveFile = Szunyi.IO.Pick_Up.File(Szunyi.IO.File_Extensions.Fasta)
        If IsNothing(Files) = True Then Exit Sub
        If IsNothing(SaveFile) = True Then Exit Sub
        Dim log As New System.Text.StringBuilder
        Dim Str As New System.Text.StringBuilder
        For Each File In Files

            Str.Append(">").Append(File.Name).AppendLine()
            For Each Seq As Bio.Sequence In Szunyi.IO.Import.Parse_Sequence(File)
                Str.Append(Seq.ConvertToString)
                log.Append(Seq.Count).Append(vbTab)
            Next
            log.AppendLine()
            Str.AppendLine()
        Next
        Clipboard.SetText(Str.ToString)
    End Sub

    Private Sub FileNameCommonNameEtcToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileNameCommonNameEtcToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.GenBank.ToList
        Dim str As New System.Text.StringBuilder
        For Each File In Files
            Dim Seqs = Szunyi.IO.Import.Parse_Sequence(File).ToList
            str.Append(File.Name).Append(vbTab)
            str.Append((Seqs.First).CommonName).Append(vbTab)
            str.Append((Seqs.First).Strain).Append(vbTab)
            str.Append(Seqs.First.TaxId).AppendLine()
        Next
        Clipboard.SetText(str.ToString)
    End Sub
    Private Sub MultiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MultiToolStripMenuItem.Click
        Dim Gff_Files = Szunyi.IO.Pick_Up.Gff().ToList
        If IsNothing(Gff_Files) = True Then Exit Sub
        Dim Seq_Files = Szunyi.IO.Pick_Up.Sequence().ToList
        If IsNothing(Seq_Files) = True Then Exit Sub
        Dim Basic_Seq_Names = Seq_Files.woExtension.ToList

        For i1 = 0 To Basic_Seq_Names.Count - 1
            Dim r = From x In Gff_Files Where x.Name.Contains(Basic_Seq_Names(i1).Name)

            If r.Count = 1 Then
                Dim Seqs = Szunyi.IO.Import.Parse_Sequence(Seq_Files(i1)).ToList
                Dim GBK_Seqs = Seqs.ConvertTo_GenBank
                Seqs.Delete(StandardFeatureKeys.CodingSequence)
                Dim GFF_Annotations = Szunyi.Features.GFF.Get_Annotations(r.First)
                Dim AA = Szunyi.Features.GFF.Parse(Seqs, GFF_Annotations)
                Dim t As New System.IO.FileInfo(r.First.FullName & ".gbk")
                Szunyi.IO.Export_GenBank(AA, t)
                Dim NA_Seqs = Seqs.Get_Features(StandardFeatureKeys.CodingSequence)
                '     Szunyi.Sequences.IDs.Increment_at_End(NA_Seqs)
                '     Dim AA_seqs = Szunyi.Sequences.Translate.TranaslateSeqs(NA_Seqs)
                '     Szunyi.IO.Export_FASTA(NA_Seqs, t.Append_Before_Extension("_CDS_NA.fa"))
                '    Szunyi.IO.Export_FASTA(AA_seqs, t.Append_Before_Extension("_CDS_AA.fa"))
            Else
                Dim kj As Int16 = 54
            End If
        Next
    End Sub
    Private Sub WithFastaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WithFastaToolStripMenuItem.Click
        Dim Gff_File = Szunyi.IO.Pick_Up.Gff().ToList
        If IsNothing(Gff_File) = True Then Exit Sub
        Dim Fasta_File = Szunyi.IO.Pick_Up.Fasta.ToList
        If IsNothing(Fasta_File) = True Then Exit Sub

        Dim Seqs = Szunyi.IO.Import.Parse_Sequence(Fasta_File).ToList
        Dim GBK_Seqs = Seqs.ConvertTo_GenBank
        Dim GFF_Annotations = Szunyi.Features.GFF.Get_Annotations(Gff_File)
        Dim AA = Szunyi.Features.GFF.Parse(Seqs, GFF_Annotations)
        Dim t = Fasta_File.ChangeExtension(Szunyi.IO.File_Extension.GenBank).First
        Szunyi.IO.Export_GenBank(AA, t)
    End Sub

    Private Sub SeqsIDs_ReName_Match(sender As Object, e As EventArgs) Handles SeqsToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.Sequence().ToList
        Dim Tdt = Szunyi.IO.Pick_Up.TabLikes.ToList
        Dim Header = Tdt.First.GetHeader(vbTab, 1)
        Dim x As New Szunyi.IO.CheckBoxForStringsFull(Header, 1, "Select Seq IDs", "A")
        Dim tmp As New Bio.Sequence(Bio.Alphabets.DNA, "T")
        Dim SeqIDs = Szunyi.IO.Import.Parse_SequenceIDs(Files)
        Dim kj = SeqIDs.GetText(vbCrLf)
        If x.ShowDialog = DialogResult.OK Then
            Dim z As New Szunyi.IO.CheckBoxForStringsFull(Header, 1, "Select new Name", "A")
            If z.ShowDialog = DialogResult.OK Then

                Dim IndexOfSeqID = Header.Get_Index(x.SelectedStrings.First)
                Dim IndexOfNewName = Header.Get_Index(z.SelectedStrings.First)
                Dim NofChanged As Integer = 0
                Dim Seqs = Szunyi.IO.Import.Parse_Sequence(Files).ToList
                Dim c As New Szunyi.Sequences.Sorters.ByID
                Seqs.Sort(c)
                Dim Out As New List(Of Bio.Sequence)
                For Each Line In Tdt.First.Parse_Lines
                    Dim s = Split(Line, vbTab)
                    tmp.ID = s(IndexOfSeqID)
                    Dim Index = Seqs.BinarySearch(tmp, c)
                    If Index > -1 Then
                        Dim Seq = Seqs(Index)
                        Dim x1 As New Bio.Sequence(Seq.Alphabet, Seq.ToArray)
                        x1.ID = s(IndexOfNewName)
                        Out.Add(x1)

                        NofChanged += 1
                    Else
                        Dim kj5 As Int16 = 54
                    End If
                Next
                Szunyi.IO.Export_FASTA(Out)
            End If
        End If

    End Sub

    Private Sub ReMergeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReMergeToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.Sequence()
        Dim tmp As New List(Of List(Of Bio.ISequence))
        For Each File In Files

            tmp.Add(Szunyi.IO.Import.Parse_Sequence(File).ToList)
            For Each Item In tmp.Last
                Item.ID = File.Name
            Next
        Next
        Dim OutDIr = Szunyi.IO.Pick_Up.Directory()
        For i1 = 0 To tmp.First.Count - 1
            Dim out As New List(Of Bio.ISequence)
            For Each Item In tmp
                out.Add(Item(i1))
            Next
            Szunyi.IO.Export_FASTA(out, New IO.FileInfo(OutDIr.FullName & "\" & i1 & ".fa"))
        Next
    End Sub

    Private Sub NAAAFromGenBankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NAAAFromGenBankToolStripMenuItem.Click

        Dim Tdt = Szunyi.IO.Pick_Up.TabLikes().First
        Dim Header = Tdt.GetHeader(vbTab, 1).ToList

        Dim IndexOfSeqID = Header.Get_Index(Szunyi.IO.Pick_Up.String(Header, "Select SeqID Column"))
        Dim IndexOfNewName = Header.Get_Index(Szunyi.IO.Pick_Up.String(Header, "Select NewID Column"))
        Dim dir = Szunyi.IO.Pick_Up.Directory()
        Dim Lines = Tdt.ParseToArray(vbTab, 1).ToList
        Dim newID_oldID = Lines.ToDictionary(IndexOfSeqID, IndexOfNewName)
        Dim j As New Szunyi.Common.Common_Classes.partialIDs(newID_oldID)
        '        Dim j1 As New Szunyi.Common.Common_Classes.partialIDs(Lines, IndexOfSeqID, IndexOfNewName)
        Dim NAFIlesToMerge As New List(Of FileInfo)
        Dim AAFIlesToMerge As New List(Of FileInfo)
        Dim str As New System.Text.StringBuilder
        Dim str2 As New System.Text.StringBuilder
        Dim Index As Integer = 0
        For Each File In Szunyi.IO.Pick_Up.GenBank()
            Dim Seqs = Szunyi.IO.Import.Parse_Sequence(File)
            Dim NA_Seqs As New List(Of Bio.ISequence)
            Dim AA_Seqs As New List(Of Bio.ISequence)
            Dim Name = j.GetID(File.Name)
            If Name.Count = 1 Then
                str.AppendLine()
                str.Append("#" & Name.First).AppendLine()
                str.Append("#")
                For Each Seq In Seqs
                    str.AppendLine()
                    str.Append(Seq.ID).Append(vbTab).Append(Seq.Count).Append(vbTab).Append(Name.First)
                    Dim Feats = Seq.Get_Features(Bio.IO.GenBank.StandardFeatureKeys.CodingSequence)
                    If IsNothing(Feats) = False Then
                        For Each CDS In Feats
                            Index += 1
                            Dim NA = CDS.GetSubSequence(Seq)
                            If CDS.Location.Operator = LocationOperator.Complement Then NA = NA.GetReversedSequence
                            NA_Seqs.Add(NA)
                            NA_Seqs.Last.ID = CDS.CommonName & "_" & Index
                            str2.Append(NA_Seqs.Last.ID).Append(vbTab).Append(Name.First).AppendLine()
                            AA_Seqs.Add(NA.Translate)
                            AA_Seqs.Last.ID = NA_Seqs.Last.ID

                        Next
                    End If
                Next
                Dim NaFile = File.Append_Before_Extension("_CDS_NA.fa").Change_Directory(dir)
                Dim AaFile = File.Append_Before_Extension("_CDS_AA.fa").Change_Directory(dir)
                Szunyi.IO.Export_FASTA(NA_Seqs, NaFile)
                Szunyi.IO.Export_FASTA(AA_Seqs, AaFile)
                NAFIlesToMerge.Add(NaFile)
                AAFIlesToMerge.Add(AaFile)
            End If

        Next
        str2.Length -= 2
        Szunyi.IO.Export_Text(str2.ToString, dir.Add_File("HitsByCDS.txt"))
        Szunyi.IO.Merge(NAFIlesToMerge, New FileInfo(NAFIlesToMerge.First.DirectoryName & "\" & "All_CDS_NA.fa"))
        Szunyi.IO.Merge(AAFIlesToMerge, New FileInfo(AAFIlesToMerge.First.DirectoryName & "\" & "All_CDS_AA.fa"))
        Szunyi.IO.Export_Text(str.ToString, dir.Add_File("HitsBySeq.txt"))

    End Sub

    Private Sub SeqsContainsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeqsContainsToolStripMenuItem.Click
        ' Get Files
        ' Select OutPut Folder
        ' Select tab File
        ' Index IDs

        Dim Files = Szunyi.IO.Pick_Up.Sequence().ToList
        Dim Tdt = Szunyi.IO.Pick_Up.TabLikes().First
        Dim Header = Tdt.GetHeader(vbTab, 1)

        Dim IndexOfSeqID = Header.Get_Index(Szunyi.IO.Pick_Up.String(Header, "Select SeqID Column"))
        Dim IndexOfNewName = Header.Get_Index(Szunyi.IO.Pick_Up.String(Header, "Select NewID Column"))
        Dim dir = Szunyi.IO.Pick_Up.Directory()
        Dim Lines = Tdt.ParseToArray(vbTab, 1)
        Dim newID_oldID = Lines.ToDictionary(IndexOfSeqID, IndexOfNewName)
        For Each File In Files
            Dim NofChanged As Integer = 0
            Dim Seqs = Szunyi.IO.Import.Parse_Sequence(File).ToList
            For Each Seq In Seqs
                For Each Item In newID_oldID
                    If Seq.ID.IndexOf(Item.Key, StringComparison.InvariantCultureIgnoreCase) > -1 Then
                        Seq.ID = Item.Value
                        NofChanged += 1
                    End If
                Next
            Next
            Szunyi.IO.Export_FASTA(Seqs, File.Change_Directory(dir))

        Next

    End Sub

    Private Sub BySeqPositionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BySeqPositionsToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.Sequence()
        Dim tmp As New List(Of List(Of Bio.ISequence))
        For Each File In Files

            tmp.Add(Szunyi.IO.Import.Parse_Sequence(File).ToList)
            For Each Item In tmp.Last

            Next
        Next
        Dim str As New System.Text.StringBuilder
        For i1 = 0 To tmp.First.Count - 1
            str.Append(">").Append(tmp.First()(i1).ID).AppendLine()
            For Each Item In tmp
                Dim t As Bio.Sequence = Item(i1)
                str.Append(t.ConvertToString)
            Next
            str.AppendLine()
        Next
        Clipboard.SetText(str.ToString)
    End Sub


    Private Sub JGIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JGIToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.Fasta.ToList
        For Each File In Files
            Dim nFIle = File.Append_Before_Extension("_RN")
            Using x As New Szunyi.IO.Exporters.Fasta_Exporter(nFIle)
                For Each Seq In File.Parse_Sequence
                    Dim t = Split(Seq.ID, "|")
                    Seq.ID = t(1) & "_" & t(2)
                    x.Write(Seq)
                Next
            End Using
        Next
    End Sub

    Private Sub RemoveTermianLStpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveTermianLStpToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.Fasta.ToList
        For Each File In Files
            Dim Seqs = File.Parse_Sequence.ToList
            Dim RT_Seqs = Seqs.Remove_Terminal_Stop.ToList
            RT_Seqs.Export_FASTA(File.Append_Before_Extension("_RT"))
        Next
    End Sub

    Private Sub HasTermi9nalStopsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HasTermi9nalStopsToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.Fasta.ToList
        For Each File In Files
            For Each Seq In File.Parse_Sequence
                If Seq.Has_Terminal_Stop Then
                    Dim kj As Int16 = 54
                End If
            Next
        Next
    End Sub

    Private Sub HasInternalStopsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HasInternalStopsToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.Fasta.ToList
        For Each File In Files
            For Each Seq In File.Parse_Sequence
                If Seq.Has_Internal_Stop Then
                    Dim kj As Int16 = 54
                End If
            Next
        Next
    End Sub

    Private Sub InterProScanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InterProScanToolStripMenuItem.Click
        Dim s = Split("CDD,COILS,Gene3D,HAMAP,MobiDBLite,PANTHER,Pfam,PIRSF,PRINTS,ProDom,PROSITEPATTERNS,PROSITEPROFILES,SFLD,SMART,SUPERFAMILY,TIGRFAM,Phobius", ",")

        Dim Sel As New Szunyi.IO.CheckBoxForStringsFull(s.ToList, -1, "", "")
        Dim str As New System.Text.StringBuilder
        Dim Files = Szunyi.IO.Pick_Up.Fasta.ToList
        Dim Out = Szunyi.IO.Pick_Up.Directory
        If IsNothing(Out) = True Then Exit Sub
        If Sel.ShowDialog = DialogResult.OK Then
            For Each FIle In Files
                For Each s1 In Sel.SelectedStrings
                    str.Append("./interproscan.sh -appl ").Append(s1)
                    str.Append(" -i ").Append(FIle.FullName_Linux)
                    str.Append(" -iprlookup ")
                    str.Append(" -goterm ")
                    str.Append(" -pa ")
                    str.Append(" -b ")
                    Dim nFIle As New FileInfo(Out.FullName & "/" & FIle.woExtension.Name & "_" & s1)
                    str.Append(nFIle.FullName_Linux).AppendLine()
                Next
            Next
        End If
        Clipboard.SetText(str.ToString)
    End Sub

    Private Sub SplitSequncesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SplitSequncesToolStripMenuItem.Click
        Dim d As New Szunyi.Sequences.Splitter
        Dim props As IEnumerable(Of Object) = Szunyi.Common.Util_Helpers.Get_All_Properties_Values(d)
        Dim out As New List(Of Szunyi.Sequences.Spliter_Property)
        For Each Item In props
            out.Add(Item)
        Next
        Dim Names = From x In out Select x.Name

        Dim f1 As New CheckBoxForStringsFull(Names, -1, "", "")
        If f1.ShowDialog = DialogResult.OK Then
            Dim Files = Szunyi.IO.Pick_Up.Fasta.ToList
            Dim DIr = Szunyi.IO.Pick_Up.Directory
            If IsNothing(DIr) = True Then
                DIr = Files.First.Directory
            Else
            If DIr.Exists = False Then DIr.Create()
            End If
            For Each F In Files
                Dim Seqs = F.Parse_Sequence
                For Each s In f1.SelectedStrings
                    Dim Index As Integer = 0
                    Dim p As Szunyi.Sequences.Spliter_Property = d.Get_Property_Value(s)
                    For Each Group In Seqs.Split_Sequences(p)
                        Dim nFIle = F.Append_Before_Extension("_" & p.Name & "_" & Index).Change_Directory(DIr)
                        Group.Export_FASTA(nFIle)
                        Index += 1
                    Next
                Next
            Next
        End If
    End Sub


    Public Async Sub SelectFile(File As FileInfo)
        Await Task.Delay(2000)
        SendKeys.Send(File.FullName & "{ENTER}")
        Await Task.Delay(2000)
    End Sub




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
    Private Sub WebBrowser1_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs)
        log.Append(e.Url).AppendLine()
        Select Case WB
            Case "Upload"
                WB = "Submit"
                Dim c = WebBrowser1.Document.Cookie.Split(";".ToCharArray())

                Dim cookiecol = New CookieCollection()

                For Each Cook In c
                    Dim Name = Cook.Trim().Split("=".ToCharArray())(0)
                    Dim value = Cook.Trim().Split("=".ToCharArray())(1)
                    cookiecol.Add(New Cookie(Name, value))
                Next





        End Select
    End Sub
    Private Sub test(File As FileInfo)
        If IsNothing(WebBrowser1.Document) = False Then
            Dim elements = WebBrowser1.Document.GetElementsByTagName("INPUT")
            For Each ex As HtmlElement In elements

                If ex.Name = "upfile" Then
                    SelectFile(File)
                    ex.InvokeMember("Click")
                    Dim HE = Get_DOwnLoad()
                    If IsNothing(HE) = False Then
                        HE.InvokeMember("Click")
                        WB = "Navigating"
                    End If
                End If
            Next

        End If


    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        Dim FIles = Szunyi.IO.Pick_Up.Fasta.ToList
        cDIr = Szunyi.IO.Pick_Up.Directory
        For Each FIle In FIles
            WB = "Upload"
            cFIle = FIle

            test(FIle)

        Next
    End Sub
    Private Function Get_DOwnLoad() As HtmlElement
        If IsNothing(WebBrowser1.Document) = False Then
            Dim elements = WebBrowser1.Document.GetElementsByTagName("INPUT")
            For Each ex As HtmlElement In elements

                If ex.Name = "Display" Then
                    Return ex
                End If
            Next

        End If
        Return Nothing
    End Function

    Private Sub PrediGPIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrediGPIToolStripMenuItem.Click
        WebBrowser1.Navigate("http://gpcr.biocomp.unibo.it/predgpi/pred.htm")

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If e.Url.ToString.Contains("cgi") Then
            Dim w As WebBrowser = sender
            Dim d = w.DocumentText
            Dim d1 = w.Document

            Dim doc As New HtmlDocument()
            doc.LoadHtml(w.DocumentText)
            Dim nodes = doc.DocumentNode.SelectNodes("//table/tr")
            Dim table = New DataTable("MyTable")
            Dim headers = nodes(4).Elements("td").[Select](Function(th) th.InnerText.Trim())

            For Each header In headers
                table.Columns.Add(header)
            Next
            Dim str As New System.Text.StringBuilder
            Dim rows = nodes.Skip(4).[Select](Function(tr) tr.Elements("td").[Select](Function(td) td.InnerText.Trim()).ToArray())

            For Each row() As String In rows
                str.Append(row.GetText(vbTab)).AppendLine()
                '     str.Append(row.i)
            Next
            If str.Length > 0 Then
                str.Length -= 2
                Dim nFIle = cFIle.Change_Directory(cDIr).ChangeExtension(".tsv")
                nFIle.Export_Text(str)
            End If
            Dim kj As Int16 = 54
            oSignalEvent.set

            w.GoBack()
        Else

        End If


    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Dim x As New DownloadSetting With {.baseurl = "http://gpcr.biocomp.unibo.it/predgpi/pred.htm", .Dir = Szunyi.IO.Pick_Up.Directory, .Files = Szunyi.IO.Pick_Up.Files.ToList, .extension = ".tsv", .FileInputSelection = "upfile", .Submit = "Display", .FirstRow = 4}
        Dim f2 As New DownLoader(x)
        f2.Show()
        f2.Start()
    End Sub
End Class
