Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Collections.Specialized
Imports System.Diagnostics
Imports System.Data
Imports System.Xml
Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.EnterpriseServices

Imports System
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Microsoft.Win32


'Imports System.Web.UI.WebControls.WebParts
'Imports Office = Microsoft.Office.Core
'Imports Word = Microsoft.Office.Interop.Word
'Imports System.Management
'Imports System.Net.NetworkInformation

Public Class Results
    Inherits System.Web.UI.Page


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents FileUpload As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents AddRows As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents AddingTextBox As System.Web.UI.WebControls.Button
    Protected WithEvents PHTxtboxes As System.Web.UI.WebControls.PlaceHolder
    Protected WithEvents BtnPrint As System.Web.UI.WebControls.Button
    Protected WithEvents DGFiles As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
    End Sub


#Region " R & D ASREDDY "

    Private Sub ReadTxt()
        Try

            ' Dim fs As New FileStream("ConString.txt", FileMode.Open, FileAccess.Read)
            'Dim fxa As New FileStream(FileUpload.PostedFile.FileName, FileMode.Open, FileAccess.Read)

            'Dim r As New StreamReader(fxa)
            ''FileUpload.PostedFile.FileName()
            'Response.Write(fxa.Name())

            'Validation 'Here It Accept Only Text Files
            If Not FileUpload.PostedFile.ContentType = "text/plain" Then
                Exit Sub
            End If
            'End of Validation

            Dim x As File
            If Not Directory.Exists(Server.MapPath(Request.ApplicationPath) & "/Results") Then
                Directory.CreateDirectory(Server.MapPath(Request.ApplicationPath) & "/Results")

            End If

            'x.CreateText(Server.MapPath(Request.ApplicationPath) & "/Results/" & "asr.Text")
            ' x.Copy(FileUpload.PostedFile.FileName, Server.MapPath(Request.ApplicationPath) & "/Results/" & FileUpload.PostedFile.FileName.IndexOf(FileUpload.PostedFile.FileName.LastIndexOf("\")))

            '''''For Over write Remove below  if .. end condtions
            If Not x.Exists(Server.MapPath(Request.ApplicationPath) & "/Results/" & FileUpload.PostedFile.FileName.Substring(FileUpload.PostedFile.FileName.LastIndexOf("\", FileUpload.PostedFile.FileName.Length) + 1)) Then

                FileUpload.PostedFile.SaveAs(Server.MapPath(Request.ApplicationPath) & "/Results/" & FileUpload.PostedFile.FileName.Substring(FileUpload.PostedFile.FileName.LastIndexOf("\", FileUpload.PostedFile.FileName.Length) + 1))
                x.Copy(FileUpload.PostedFile.FileName, Server.MapPath(Request.ApplicationPath) & "/Results/" & FileUpload.PostedFile.FileName.Substring(FileUpload.PostedFile.FileName.LastIndexOf("\", FileUpload.PostedFile.FileName.Length) + 1))

                '''Saving as .pdf
                '''FileUpload.PostedFile.SaveAs((Server.MapPath(Request.ApplicationPath) & "/Results/tpdf.pdf"))
                '''Saving as .doc (word file)
                '''FileUpload.PostedFile.SaveAs((Server.MapPath(Request.ApplicationPath) & "/Results/tpdf.doc"))

            End If

            ' Dim rd As New StreamReader(fxa)
            Dim fxa As New FileStream(Server.MapPath(Request.ApplicationPath) & "/Results/" & FileUpload.PostedFile.FileName.Substring(FileUpload.PostedFile.FileName.LastIndexOf("\", FileUpload.PostedFile.FileName.Length) + 1), FileMode.Open, FileAccess.Read)

            Dim r As New StreamReader(fxa)
            'FileUpload.PostedFile.FileName()

            Response.Write(fxa.Name())
            Response.Write("<br>  ContentLength :" & FileUpload.PostedFile.ContentLength.ToString)
            Response.Write("<br>  ContentType :" & FileUpload.PostedFile.ContentType)

            Dim str As String
            Dim ssp() As String

            str = Trim(r.ReadToEnd)

            Dim i, j As Long

            ssp = str.Split(";")

            For i = 0 To ssp.Length - 1

                Dim msp() As String

                'Student wise 
                Response.Write(" <br> " & "Student Wise :: " & ssp(i).ToString)

                msp = ssp(i).Split(",")

                'Question Wise

                Response.Write(" <br> " & "ADMSLNO  :  " & msp(0).ToString)

                For j = 1 To msp.Length - 1
                    Response.Write(" <br> " & "Qno & Ans : " & msp(j))
                Next

                Response.Write(" <br> ")

            Next


            'For i = 0 To str.Join(";", str)
            '    Response.Write(ssp(i))
            'Next

            'Response.Write("<br>" & r.ReadToEnd.IndexOf(";").ToString)
            'Response.Write("<br>" & r.ReadToEnd.LastIndexOfAny(";").ToString)

            r.Close()
            fxa.Close()

        Catch ex As IOException

            Response.Write("<br> IOException " & ex.Message)
        Catch ex As Exception
            ErrorLog.Log(ex)
            Response.Write("<br> Exception " & ex.Message)
        End Try

    End Sub

    Private Sub ReadTxtSERVERPATH()
        Try

            ' Dim fs As New FileStream("ConString.txt", FileMode.Open, FileAccess.Read)
            'Dim fxa As New FileStream(FileUpload.PostedFile.FileName, FileMode.Open, FileAccess.Read)

            'Dim r As New StreamReader(fxa)
            ''FileUpload.PostedFile.FileName()
            'Response.Write(fxa.Name())

            'Validation 'Here It Accept Only Text Files
            If Not FileUpload.PostedFile.ContentType = "text/plain" Then
                Exit Sub
            End If
            'End of Validation

            Dim x As File
            'If Not Directory.Exists(Server.MapPath("D:/Results")) Then
            '    Directory.CreateDirectory(Server.MapPath(Request.ApplicationPath) & "/Results")

            'End If

            'x.CreateText(Server.MapPath(Request.ApplicationPath) & "/Results/" & "asr.Text")
            ' x.Copy(FileUpload.PostedFile.FileName, Server.MapPath(Request.ApplicationPath) & "/Results/" & FileUpload.PostedFile.FileName.IndexOf(FileUpload.PostedFile.FileName.LastIndexOf("\")))

            '''''For Over write Remove below  if .. end condtions
            ''''D:/Results \\10.101.3.28\S$\Results
            If Not x.Exists(Server.MapPath("D:/Results") & FileUpload.PostedFile.FileName.Substring(FileUpload.PostedFile.FileName.LastIndexOf("\", FileUpload.PostedFile.FileName.Length) + 1)) Then

                FileUpload.PostedFile.SaveAs(Server.MapPath("D:/Results") & FileUpload.PostedFile.FileName.Substring(FileUpload.PostedFile.FileName.LastIndexOf("\", FileUpload.PostedFile.FileName.Length) + 1))
                x.Copy(FileUpload.PostedFile.FileName, Server.MapPath(Request.ApplicationPath) & "/Results/" & FileUpload.PostedFile.FileName.Substring(FileUpload.PostedFile.FileName.LastIndexOf("\", FileUpload.PostedFile.FileName.Length) + 1))

                '''Saving as .pdf
                ''' FileUpload.PostedFile.SaveAs((Server.MapPath(Request.ApplicationPath) & "/Results/tpdf.pdf"))
                '''Saving as .doc (word file)
                '''FileUpload.PostedFile.SaveAs((Server.MapPath(Request.ApplicationPath) & "/Results/tpdf.doc"))

            End If

            ' Dim rd As New StreamReader(fxa)
            Dim fxa As New FileStream(Server.MapPath("D:/Results") & FileUpload.PostedFile.FileName.Substring(FileUpload.PostedFile.FileName.LastIndexOf("\", FileUpload.PostedFile.FileName.Length) + 1), FileMode.Open, FileAccess.Read)

            Dim r As New StreamReader(fxa)
            'FileUpload.PostedFile.FileName()

            Response.Write(fxa.Name())
            Response.Write("<br>  ContentLength :" & FileUpload.PostedFile.ContentLength.ToString)
            Response.Write("<br>  ContentType :" & FileUpload.PostedFile.ContentType)

            Dim str As String
            Dim ssp() As String

            str = Trim(r.ReadToEnd)

            Dim i, j As Long

            ssp = str.Split(";")

            For i = 0 To ssp.Length - 1

                Dim msp() As String

                'Student wise 
                Response.Write(" <br> " & "Student Wise :: " & ssp(i).ToString)

                msp = ssp(i).Split(",")

                'Question Wise

                Response.Write(" <br> " & "ADMSLNO  :  " & msp(0).ToString)

                For j = 1 To msp.Length - 1
                    Response.Write(" <br> " & "Qno & Ans : " & msp(j))
                Next

                Response.Write(" <br> ")

            Next


            'For i = 0 To str.Join(";", str)
            '    Response.Write(ssp(i))
            'Next

            'Response.Write("<br>" & r.ReadToEnd.IndexOf(";").ToString)
            'Response.Write("<br>" & r.ReadToEnd.LastIndexOfAny(";").ToString)

            r.Close()
            fxa.Close()

        Catch ex As IOException

            Response.Write("<br> IOException " & ex.Message)
        Catch ex As Exception
            ErrorLog.Log(ex)
            Response.Write("<br> Exception " & ex.Message)
        End Try

    End Sub

    Private Sub convertintopdf()
        Dim FS As FileStream
        Dim W As StreamWriter
        Dim R As StreamReader
        Try

            If Not Directory.Exists(Server.MapPath(Request.ApplicationPath) & "/Pdf") Then
                Directory.CreateDirectory(Server.MapPath(Request.ApplicationPath) & "/Pdf")
            End If

            Dim F As File

            If Not File.Exists(Server.MapPath(Request.ApplicationPath) & "/Pdf/TPDF.PDF") Then
                File.Create(Server.MapPath(Request.ApplicationPath) & "/Pdf/TPDF.PDF")
            End If

            FS = New FileStream(Server.MapPath(Request.ApplicationPath) & "/Pdf/TPDF.PDF", FileMode.OpenOrCreate, FileAccess.ReadWrite)

            'R = New StreamReader(FS)
            'Response.Write("<BR> " & R.ReadToEnd())
            'R.Close()

            Dim DOC As New ReportDocument

            DOC.ExportOptions.DestinationOptions.DiskFileName = Server.MapPath(Request.ApplicationPath) & "/Pdf/TPDF.PDF"
            DOC.Export()

            'W = New StreamWriter(FS)
            'W.Write("TESTING IN PDF")

        Catch RE As ExportException
            Response.Write("<br> <br><br><br> Exception " & RE.ToString)
        Catch ex As IOException
            Response.Write("<br> IOException " & ex.Message)
        Catch ex As Exception
            Response.Write("<br> <br><br><br> Exception " & ex.ToString)
        Finally
            'R.Close()
            'W.Close()
            'FS.Close()
        End Try

    End Sub

    Private Sub FileexportOpts()
        Try

            If Not Directory.Exists(Server.MapPath(Request.ApplicationPath) & "/Pdf") Then
                Directory.CreateDirectory(Server.MapPath(Request.ApplicationPath) & "/Pdf")
            End If

            If Not File.Exists(Server.MapPath(Request.ApplicationPath) & "/Pdf/TPDF.PDF") Then
                File.Create(Server.MapPath(Request.ApplicationPath) & "/Pdf/TPDF.PDF")
            End If

            Dim exportOpts1 As ExportOptions
            Dim doc As New ReportDocument

            doc.Load(Server.MapPath(Request.ApplicationPath) & "/Pdf/TPDF.pdf")

            exportOpts1.ExportFormatType = ExportFormatType.PortableDocFormat
            exportOpts1.ExportDestinationType = ExportDestinationType.DiskFile
            exportOpts1.DestinationOptions = New DiskFileDestinationOptions
            doc.ExportOptions.DestinationOptions.filename = Server.MapPath("TPDF.pdf")
            doc.Export()

            'ExportOptions exportOpts = doc.ExportOptions;
        Catch RE As ExportException
            Response.Write("<br> <br><br><br> Exception " & RE.ToString)
        Catch ex As IOException
            Response.Write("<br> IOException " & ex.Message)
        Catch ex As Exception
            Response.Write("<br> <br><br><br> Exception " & ex.ToString)
        Finally

        End Try

    End Sub


    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            Dim fPath As String
            fPath = Server.MapPath(Request.ApplicationPath) & "/Reports/asr.txt"

            Response.Write("<script language=Javascript>Javascript:;</script>")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetSystemFiles()
      
    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            ReadTxt()
            'convertintopdf()
            'FileexportOpts()
            'ReadTxtSERVERPATH()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            'Execute the .exe in asp.net
            Dim f As String
            Dim t As Integer
            Dim p As New Process
            f = Server.MapPath((Request.ApplicationPath) & "/Examination/WindowsApplication1.exe")
            't = Shell(f)
            'Response.Write(t.ToString)
            p.Start(f)
            'p.EnterDebugMode()
            p.Kill()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i As Integer

        Dim txt As New TextBox

        '''''Adding Controls to a Form Using Table Control

        For i = 0 To 5

            Dim tr As New TableRow
            Dim td As New TableCell

            Dim _label As New Label

            _label.ID = "lbl" + i.ToString
            _label.Text = "lbl" + i.ToString

            td.Controls.Add(_label)

            Dim td1 As New TableCell
            Dim _text As New TextBox

            _text.ID = "txt_" + i.ToString

            _text.Text = "ASR"

            td1.Controls.Add(_text)

            tr.Cells.Add(td)
            tr.Cells.Add(td1)

            Table1.Rows.Add(tr)
        Next
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            Asc(sender.text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.PreRender
        Try

        Catch ex As Exception
            ErrorLog.Log(ex)
        Catch SqlEx As OracleClient.OracleException
            ErrorLog.Log(SqlEx)
        End Try
    End Sub

    Private Sub TextBox1_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Unload
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddRows.Click
        Try
            Dim dBound As New TemplateColumn
            dBound.HeaderText = "aaa"
            dBound.EditItemTemplate = New TextBox
            dBound.ItemStyle.Width = New Unit(100)
            DataGrid1.Columns.Add(dBound)
            DataGrid1.DataBind()

        Catch ex As Exception
            ErrorLog.Log(ex)
        End Try
    End Sub

    Private Sub Page_AbortTransaction(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.AbortTransaction

    End Sub

    Private Sub Page_CommitTransaction(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.CommitTransaction

    End Sub

    Private Sub AddingTextBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddingTextBox.Click
        Try
            Dim i As Integer
            For i = 0 To 5
                Dim ObjTxt As New TextBox
                PHTxtboxes.Controls.Add(ObjTxt)
            Next

        Catch ex As Exception

        End Try
    End Sub

  
End Class
