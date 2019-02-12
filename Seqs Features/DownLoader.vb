Imports System.IO
Imports HtmlAgilityPack
Imports Szunyi.Common
Imports Szunyi.IO

Public Class DownLoader
    Public Property Setting As DownloadSetting
    Private Sub DownLoader_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(DownloadSetting As DownloadSetting)



        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Setting = DownloadSetting
    End Sub
    Public Sub Start()
        WebBrowser1.Navigate(Me.Setting.baseurl)
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If e.Url.ToString <> Me.Setting.baseurl Then
            If Me.Setting.Files.Count = 0 Then Me.Close()
            ' Save
            Dim doc As New HtmlDocument()
            doc.LoadHtml(WebBrowser1.DocumentText)
            Dim str As New System.Text.StringBuilder
            Dim nodes = doc.DocumentNode.SelectNodes("//table/tr")
            Dim rows = nodes.Skip(Me.Setting.FirstRow).[Select](Function(tr) tr.Elements("td").[Select](Function(td) td.InnerText.Trim()).ToArray())
            For Each row() As String In rows
                str.Append(row.GetText(vbTab)).AppendLine()
                '     str.Append(row.i)
            Next
            If str.Length > 0 Then
                str.Length -= 2
                Dim nFIle = Me.Setting.Files.Last.Change_Directory(Me.Setting.Dir).ChangeExtension(".tsv")
                nFIle.Export_Text(str)
            End If
            Me.Setting.Files.RemoveAt(Me.Setting.Files.Count - 1)
            WebBrowser1.GoBack()
        Else
            NextFIle()
        End If
    End Sub
    Private Sub NextFIle()
        Dim elements = WebBrowser1.Document.GetElementsByTagName("INPUT")
        If Me.Setting.Files.Count <> 0 Then
            For Each ex As HtmlElement In elements
                Dim f = Get_Html_Element(elements, Me.Setting.FileInputSelection)
                Dim s = Get_Html_Element(elements, Me.Setting.Submit)
                SelectFile(Me.Setting.Files.Last)
                f.InvokeMember("Click")

                s.InvokeMember("Click")
                Exit For
            Next
        Else
            Me.Close()
        End If
    End Sub
    Private Function Get_Html_Element(elements As HtmlElementCollection, s As String) As HtmlElement
        For Each ex As HtmlElement In elements
            If ex.Name = s Then Return ex
        Next
        Return Nothing
    End Function
    Public Async Sub SelectFile(File As FileInfo)
        Await Task.Delay(2000)
        SendKeys.Send(File.FullName & "{ENTER}")
        Await Task.Delay(2000)
    End Sub

End Class
Public Class DownloadSetting
    Public Property Files As List(Of FileInfo)
    Public Property Dir As DirectoryInfo
    Public Property extension As String
    Public Property baseurl As String
    Public Property FileInputSelection As String
    Public Property Submit As String
    Public Property FirstRow As Integer
    Public Sub New(Files As List(Of FileInfo), Dir As DirectoryInfo, extension As String, baseurl As String, FileInputSelection As String, Submit As String, FIrstRow As Integer)
        Me.FileInputSelection = FileInputSelection
        Me.Files = Files
        Me.Dir = Dir
        Me.extension = extension
        Me.baseurl = baseurl
        Me.Submit = Submit
        Me.FirstRow = FIrstRow

    End Sub
    Public Sub New()

    End Sub

End Class