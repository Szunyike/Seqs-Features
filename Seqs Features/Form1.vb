Imports System.Collections.Concurrent
Imports System.IO
Imports Bio.IO.GenBank

Public Class Form1
    Private Sub FromFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromFilesToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.Fasta.ToList
        Dim SaveFile = Szunyi.IO.Export.File_To_Save(Szunyi.IO.File_Extensions.Fasta)
        If IsNothing(Files) = True Then Exit Sub
        If IsNothing(SaveFile) = True Then Exit Sub
        Dim log As New System.Text.StringBuilder
        Dim Str As New System.Text.StringBuilder
        For Each File In Files

            Str.Append(">").Append(File.Name).AppendLine()
            For Each Seq As Bio.Sequence In Szunyi.IO.Import.Sequences.Parse(File)
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
            Dim Seqs = Szunyi.IO.Import.Sequences.Parse(File).ToList
            str.Append(File.Name).Append(vbTab)
            str.Append(Szunyi.Features.GenBankMetaDataManipulation.Get_Common_Name(Seqs.First)).Append(vbTab)
            str.Append(Szunyi.Features.GenBankMetaDataManipulation.Get_Strain(Seqs.First)).Append(vbTab)
            str.Append(Szunyi.Features.GenBankMetaDataManipulation.Get_TaxID(Seqs.First)).AppendLine()
        Next
        Clipboard.SetText(str.ToString)
    End Sub
    Private Sub MultiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MultiToolStripMenuItem.Click
        Dim Gff_Files = Szunyi.IO.Pick_Up.Gff().ToList
        If IsNothing(Gff_Files) = True Then Exit Sub
        Dim Seq_Files = Szunyi.IO.Pick_Up.Sequence().ToList
        If IsNothing(Seq_Files) = True Then Exit Sub
        Dim Basic_Seq_Names = Szunyi.IO.Rename.woExtension(Seq_Files).ToList

        For i1 = 0 To Basic_Seq_Names.Count - 1
            Dim r = From x In Gff_Files Where x.Name.Contains(Basic_Seq_Names(i1).Name)

            If r.Count = 1 Then
                Dim Seqs = Szunyi.IO.Import.Sequences.Parse(Seq_Files(i1)).ToList
                Dim GBK_Seqs = Szunyi.Sequences.Common.ConvertTo_GenBank(Seqs)
                Szunyi.Features.Keys.Delete(Seqs, StandardFeatureKeys.CodingSequence)
                Dim GFF_Annotations = Szunyi.Features.GFF.Get_Annotations(r.First)
                Dim AA = Szunyi.Features.GFF.Parse(Seqs, GFF_Annotations)
                Dim t As New System.IO.FileInfo(r.First.FullName & ".gbk")
                Szunyi.IO.Export.GenBank(AA, t)
                Dim NA_Seqs = Szunyi.Features.Keys.Get_Sequence(Seqs, StandardFeatureKeys.CodingSequence)
                Szunyi.Sequences.IDs.Increment_at_End(NA_Seqs)
                Dim AA_seqs = Szunyi.Sequences.Translate.TranaslateSeqs(NA_Seqs)
                Szunyi.IO.Export.Fasta(NA_Seqs, Szunyi.IO.Rename.Append_Before_Extension_wNew_Extension(t, "_CDS_NA.fa"))
                Szunyi.IO.Export.Fasta(AA_seqs, Szunyi.IO.Rename.Append_Before_Extension_wNew_Extension(t, "_CDS_AA.fa"))
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

        Dim Seqs = Szunyi.IO.Import.Sequences.Parse(Fasta_File).ToList
        Dim GBK_Seqs = Szunyi.Sequences.Common.ConvertTo_GenBank(Seqs)
        Dim GFF_Annotations = Szunyi.Features.GFF.Get_Annotations(Gff_File)
        Dim AA = Szunyi.Features.GFF.Parse(Seqs, GFF_Annotations)
        Dim t = Szunyi.IO.Rename.ChangeExtension(Fasta_File, Szunyi.IO.File_Extension.GenBank).First
        Szunyi.IO.Export.GenBank(AA, t)
    End Sub

    Private Sub SeqsIDs_ReName_Match(sender As Object, e As EventArgs) Handles SeqsToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.Sequence().ToList
        Dim Tdt = Szunyi.IO.Pick_Up.TabLike().ToList
        Dim Header = Szunyi.IO.Import.Text.GetHeader(Tdt.First, 1)
        Dim x As New Szunyi.IO.CheckBoxForStringsFull(Header, 1, "Select Seq IDs", "A")
        Dim tmp As New Bio.Sequence(Bio.Alphabets.DNA, "T")
        Dim SeqIDs = Szunyi.IO.Import.SequenceIDs.All_Full(Files)
        Dim kj = Szunyi.Common.Text.General.GetText(SeqIDs.ToList)
        If x.ShowDialog = DialogResult.OK Then
            Dim z As New Szunyi.IO.CheckBoxForStringsFull(Header, 1, "Select new Name", "A")
            If z.ShowDialog = DialogResult.OK Then

                Dim IndexOfSeqID = Szunyi.Common.Text.Lists.Get_Index(Header, x.SelectedStrings.First)
                Dim IndexOfNewName = Szunyi.Common.Text.Lists.Get_Index(Header, z.SelectedStrings.First)
                Dim NofChanged As Integer = 0
                Dim Seqs = Szunyi.IO.Import.Sequences.Parse(Files).ToList
                Dim c As New Szunyi.Sequences.Sorters.ByID
                Seqs.Sort(c)
                Dim Out As New List(Of Bio.Sequence)
                For Each Line In Szunyi.IO.Import.Text.Parse(Tdt.First)
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
                Szunyi.IO.Export.Fasta(Out)
            End If
        End If

    End Sub

    Private Sub ReMergeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReMergeToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.Sequence()
        Dim tmp As New List(Of List(Of Bio.ISequence))
        For Each File In Files

            tmp.Add(Szunyi.IO.Import.Sequences.Parse(File).ToList)
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
            Szunyi.IO.Export.Fasta(out, New IO.FileInfo(OutDIr.FullName & "\" & i1 & ".fa"))
        Next
    End Sub
    Private Sub WholeIIIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WholeIIIToolStripMenuItem.Click
        Dim sg As New List(Of Byte())

        Dim SeqCount As Integer = 0
        Dim FragmentCount As Integer = 0
        Dim KmerCount As Integer = 0
        Dim Seqs = Szunyi.IO.Import.Sequences.Parse
        Parallel.ForEach(Seqs, Sub(Seq)
                                   SeqCount += 1
                                   Dim Fragments = Szunyi.Sequences.Compress.Break(Seq)
                                   FragmentCount += Fragments.Count
                                   For Each Fragment In Fragments
                                       Dim Shorts = Szunyi.Sequences.Compress.ToByteArray(Seq)

                                       Dim Kmers = Szunyi.Sequences.Compress.Kmers(Shorts, 12)
                                       SyncLock sg
                                           sg.AddRange(Kmers)
                                       End SyncLock

                                   Next

                               End Sub)

        Dim k As New Szunyi.Common.Sorters.ByteArray
        sg.Sort(k)
    End Sub
    Private Sub WholeDictionaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WholeDictionaryToolStripMenuItem.Click
        Dim sg As New ConcurrentDictionary(Of Byte(), Integer)(New Szunyi.Common.Sorters.ByteArray)
        Dim SeqCount As Integer = 0
        Dim FragmentCount As Integer = 0
        Dim KmerCount As Integer = 0
        Dim Seqs = Szunyi.IO.Import.Sequences.Parse
        Parallel.ForEach(Seqs, Sub(Seq)
                                   SeqCount += 1
                                   Dim Fragments = Szunyi.Sequences.Compress.Break(Seq)
                                   FragmentCount += Fragments.Count
                                   For Each Fragment In Fragments
                                       Dim Shorts = Szunyi.Sequences.Compress.ToByteArray(Seq)

                                       Dim Kmers = Szunyi.Sequences.Compress.Kmers(Shorts, 12)

                                       For Each kmer In Kmers
                                           KmerCount += 1

                                           If sg.ContainsKey(kmer) = False Then
                                               sg.TryAdd(kmer, 1)
                                           Else
                                               sg(kmer) += 1
                                           End If

                                       Next
                                   Next

                               End Sub)



        For Each Seq As Bio.ISequence In Szunyi.IO.Import.Sequences.Parse
            SeqCount += 1
            Dim Fragments = Szunyi.Sequences.Compress.Break(Seq)
            FragmentCount += Fragments.Count
            For Each Fragment In Fragments
                Dim Shorts = Szunyi.Sequences.Compress.ToByteArray(Seq)

                Dim Kmers = Szunyi.Sequences.Compress.Kmers(Shorts, 12)

                For Each kmer In Kmers
                    KmerCount += 1

                    If sg.ContainsKey(kmer) = False Then
                        sg.TryAdd(kmer, 1)
                    Else
                        sg(kmer) += 1
                    End If

                Next
            Next

        Next
    End Sub

    Private Sub WholeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WholeToolStripMenuItem.Click
        Dim sg As New SortedList(Of Byte(), Integer)(New Szunyi.Common.Sorters.ByteArray)
        Dim SeqCount As Integer = 0
        Dim FragmentCount As Integer = 0
        Dim KmerCount As Integer = 0
        For Each Seq As Bio.ISequence In Szunyi.IO.Import.Sequences.Parse
            SeqCount += 1
            Dim Fragments = Szunyi.Sequences.Compress.Break(Seq)
            FragmentCount += Fragments.Count
            For Each Fragment In Fragments
                Dim Shorts = Szunyi.Sequences.Compress.ToByteArray(Seq)

                Dim Kmers = Szunyi.Sequences.Compress.Kmers(Shorts, 12)

                For Each kmer In Kmers
                    KmerCount += 1
                    Dim Index = sg.IndexOfKey(kmer)
                    If Index < 0 Then
                        sg.Add(kmer, 0)
                    End If
                    sg(kmer) += 1
                Next
            Next

        Next
        Dim jh As Int16 = 54
    End Sub

    Private Sub NAAAFromGenBankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NAAAFromGenBankToolStripMenuItem.Click
        Dim Index As Integer = 0
        Dim Tdt = Szunyi.IO.Pick_Up.TabLike().First
        Dim Header = Szunyi.IO.Import.Text.GetHeader(Tdt, 1)

        Dim IndexOfSeqID = Szunyi.Common.Text.Lists.Get_Index(Header, Szunyi.IO.Pick_Up.String(Header, "Select SeqID Column"))
        Dim IndexOfNewName = Szunyi.Common.Text.Lists.Get_Index(Header, Szunyi.IO.Pick_Up.String(Header, "Select NewID Column"))
        Dim dir = Szunyi.IO.Pick_Up.Directory()
        Dim Lines = Szunyi.IO.Import.Text.ParseNotFirst(Tdt, 1)
        Dim newID_oldID = Szunyi.Common.Text.Dict.FromLines(Lines, IndexOfSeqID, IndexOfNewName)
        Dim j As New Szunyi.Common.Common_Classes.partialIDs(newID_oldID)
        Dim j1 As New Szunyi.Common.Common_Classes.partialIDs(Lines, IndexOfSeqID, IndexOfNewName)
        Dim NAFIlesToMerge As New List(Of FileInfo)
        Dim AAFIlesToMerge As New List(Of FileInfo)
        Dim str As New System.Text.StringBuilder
        For Each File In Szunyi.IO.Pick_Up.GenBank()
            Dim Seqs = Szunyi.IO.Import.Sequences.Parse(File)
            Dim NA_Seqs As New List(Of Bio.ISequence)
            Dim AA_Seqs As New List(Of Bio.ISequence)
            Dim Name = j1.GetID(File.Name)
            If Name.Count = 1 Then
                str.AppendLine()
                str.Append("#" & Name.First).AppendLine()
                str.Append("#")
                For Each Seq In Seqs
                    str.AppendLine()
                    str.Append(Seq.ID).Append(vbTab).Append(Seq.Count).Append(vbTab).Append(Name)
                    Dim Feats = Szunyi.Features.Keys.Get(Seq, Bio.IO.GenBank.StandardFeatureKeys.CodingSequence)
                    If IsNothing(Feats) = False Then
                        For Each CDS In Feats
                            Index += 1
                            Dim NA = CDS.GetSubSequence(Seq)
                            If CDS.Location.Operator = LocationOperator.Complement Then NA = NA.GetReversedSequence
                            NA_Seqs.Add(NA)
                            NA_Seqs.Last.ID = Szunyi.Features.Common.GetName(CDS).First.Replace(Chr(34), "").Replace(".", "_") & "_" & Index
                            AA_Seqs.Add(Szunyi.Sequences.Translate.TranaslateSeq(NA))
                            AA_Seqs.Last.ID = NA_Seqs.Last.ID

                        Next
                    End If
                Next
                Dim NaFile = Szunyi.IO.Rename.Append_Before_Extension_wNew_Extension(File, "_CDS_NA.fa")
                Dim AaFile = Szunyi.IO.Rename.Append_Before_Extension_wNew_Extension(File, "_CDS_AA.fa")
                Szunyi.IO.Export.Fasta(NA_Seqs, NaFile)
                Szunyi.IO.Export.Fasta(AA_Seqs, AaFile)
                NAFIlesToMerge.Add(NaFile)
                AAFIlesToMerge.Add(AaFile)
            End If

        Next

        Szunyi.IO.Export.Text(str.ToString, Szunyi.IO.Rename.Merge(dir, "Hits.txt"))

    End Sub

    Private Sub SeqsContainsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeqsContainsToolStripMenuItem.Click
        ' Get Files
        ' Select OutPut Folder
        ' Select tab File
        ' Index IDs

        Dim Files = Szunyi.IO.Pick_Up.Sequence().ToList
        Dim Tdt = Szunyi.IO.Pick_Up.TabLike().First
        Dim Header = Szunyi.IO.Import.Text.GetHeader(Tdt, 1)

        Dim IndexOfSeqID = Szunyi.Common.Text.Lists.Get_Index(Header, Szunyi.IO.Pick_Up.String(Header, "Select SeqID Column"))
        Dim IndexOfNewName = Szunyi.Common.Text.Lists.Get_Index(Header, Szunyi.IO.Pick_Up.String(Header, "Select NewID Column"))
        Dim dir = Szunyi.IO.Pick_Up.Directory()
        Dim Lines = Szunyi.IO.Import.Text.ParseNotFirst(Tdt, 1)
        Dim newID_oldID = Szunyi.Common.Text.Dict.FromLines(Lines, IndexOfSeqID, IndexOfNewName)
        For Each File In Files
            Dim NofChanged As Integer = 0
            Dim Seqs = Szunyi.IO.Import.Sequences.Parse(File).ToList
            For Each Seq In Seqs
                For Each Item In newID_oldID
                    If Seq.ID.IndexOf(Item.Key, StringComparison.InvariantCultureIgnoreCase) > -1 Then
                        Seq.ID = Item.Value
                        NofChanged += 1
                    End If
                Next
            Next
            Szunyi.IO.Export.Fasta(Seqs, Szunyi.IO.Rename.Change_Directory(File, dir))

        Next

    End Sub

    Private Sub BySeqPositionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BySeqPositionsToolStripMenuItem.Click
        Dim Files = Szunyi.IO.Pick_Up.Sequence()
        Dim tmp As New List(Of List(Of Bio.ISequence))
        For Each File In Files

            tmp.Add(Szunyi.IO.Import.Sequences.Parse(File).ToList)
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

    Private Sub FromJellyfishToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromJellyfishToolStripMenuItem.Click
        Dim sg As New List(Of Bio.Sequence)

        Dim SeqCount As Integer = 0
        Dim FragmentCount As Integer = 0
        Dim KmerCount As Integer = 0
        Dim Seqs = Szunyi.IO.Import.Sequences.Parse
        Parallel.ForEach(Seqs, Sub(Seq)
                                   SeqCount += 1
                                   SyncLock sg
                                       sg.Add(Seq)

                                   End SyncLock
                               End Sub)

        Dim k As New Szunyi.Common.Sorters.ByteArray
        sg.Sort(k)
    End Sub
End Class
