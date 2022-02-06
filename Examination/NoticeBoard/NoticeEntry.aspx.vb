Imports System.IO
Imports System.Data
Imports System.Data.OracleClient
Imports CollegeBoardDLL
Public Class NoticeEntry
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    Protected WithEvents txtCaption As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNotice As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents fileNoticeboard As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " Class Variables "

    Dim msgSlno, actDeactive As Integer
    Dim CID, DorQS As String
    Dim filePath As String = ""
    Dim strMessage As String
    Dim dsMsgEdit As New DataSet
    Dim objMessage As ClsMessageBoard

#End Region

#Region " Page Load "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IsPostBack Then
            Dim s As String
        End If
        If Request.QueryString("CID") = Nothing Then
            getData()
            addTable()
        Else
            CID = Request.QueryString("CID")
            getData()
            addTable()
            If CID = "nr" Then
                Panel1.Visible = True
            ElseIf CID = "EDT" Then
                If btnSave.ToolTip = "Save" Then
                    msgSlno = Request.QueryString("MSGSLNO")
                Else
                    msgSlno = Request.QueryString("MSGSLNO")
                    Dim r As String = CID.Substring(3)
                    Dim DR() As DataRow
                    DR = dsMsgEdit.Tables(0).Select("MSGSLNO=" & msgSlno)
                    txtCaption.Text = DR(0)("SUBJECT")
                    If Not IsDBNull(DR(0)("DESCRIPTION")) Then
                        txtNotice.Text = DR(0)("DESCRIPTION")
                    End If
                    actDeactive = DR(0)("ISACTIVE")
                    Panel1.Visible = True
                    btnSave.ToolTip = "Save"
                End If
            ElseIf CID = "ACT" Then
                msgSlno = Request.QueryString("MSGSLNO")
                actDeactive = 1
                objMessage = New ClsMessageBoard
                objMessage.MB_Message_ActiveDeactive(msgSlno, Session("USERSLNO"), actDeactive)
                Panel1.Visible = False
                getData()
                addTable()
            ElseIf CID = "DAC" Then
                msgSlno = Request.QueryString("MSGSLNO")
                actDeactive = 0
                objMessage = New ClsMessageBoard
                objMessage.MB_Message_ActiveDeactive(msgSlno, Session("USERSLNO"), actDeactive)
                Panel1.Visible = False
                getData()
                addTable()
            End If
        End If
    End Sub

#End Region

#Region " Methods "

    Private Function addTable()
        Try
            Dim i, j, k As Integer
            Table1.Rows.Clear()
            Dim hc As New TableRow
            hc.Height = System.Web.UI.WebControls.Unit.Pixel(30)
            For k = 0 To 4
                Dim heading As New TableCell
                heading.Font.Size = System.Web.UI.WebControls.FontUnit.Medium
                If k = 0 Then
                    heading.Controls.Add(New LiteralControl("Caption"))
                ElseIf k = 1 Then
                    heading.Controls.Add(New LiteralControl("Discription"))
                ElseIf k = 2 Then
                    heading.Controls.Add(New LiteralControl("Edit"))
                ElseIf k = 3 Then
                    heading.Controls.Add(New LiteralControl("Status"))
                ElseIf k = 4 Then
                    heading.Controls.Add(New LiteralControl("Display Prop"))
                    heading.Width = System.Web.UI.WebControls.Unit.Pixel(120)
                End If
                hc.Cells.Add(heading)
            Next
            hc.BackColor = Color.FromArgb(185, 119, 61)
            hc.ForeColor = Color.White
            Table1.Rows.AddAt(0, hc)
            For i = 0 To dsMsgEdit.Tables(0).Rows.Count - 1
                Dim tr As New TableRow
                tr.BackColor = Color.FromArgb(242, 238, 235)
                tr.ForeColor = Color.FromArgb(102, 51, 0)
                tr.Height.Pixel(25)
                For j = 0 To 4
                    Dim tc As New TableCell
                    Dim btn As New System.Web.UI.WebControls.HyperLink
                    Dim text As New System.Web.UI.WebControls.Label
                    tc.Font.Size = System.Web.UI.WebControls.FontUnit.Point(10)
                    If j = 0 Then
                        tc.Controls.Add(New LiteralControl(dsMsgEdit.Tables(0).Rows(i)("SUBJECT")))
                    ElseIf j = 1 Then
                        If Not IsDBNull(dsMsgEdit.Tables(0).Rows(i)("DESCRIPTION")) Then
                            text.Text = dsMsgEdit.Tables(0).Rows(i)("DESCRIPTION")
                        Else
                            text.Text = "  "
                        End If
                        tc.Controls.Add(text)
                    ElseIf j = 2 Then
                        btn.Text = "Edit"
                        btn.ID = i
                        btn.NavigateUrl = "NoticeEntry.aspx?CID=EDT" & "&MSGSLNO=" & dsMsgEdit.Tables(0).Rows(i)("MSGSLNO")
                        tc.Controls.Add(btn)
                    ElseIf j = 3 Then
                        If dsMsgEdit.Tables(0).Rows(i)("ISACTIVE") = 0 Then
                            btn.Text = "Deactive"
                            btn.ID = "A" & i
                            btn.NavigateUrl = "NoticeEntry.aspx?CID=ACT" & "&MSGSLNO=" & dsMsgEdit.Tables(0).Rows(i)("MSGSLNO")
                        ElseIf dsMsgEdit.Tables(0).Rows(i)("ISACTIVE") = 1 Then
                            btn.Text = "Active"
                            btn.ForeColor = Color.Blue
                            btn.ID = "A" & i
                            btn.NavigateUrl = "NoticeEntry.aspx?CID=DAC" & "&MSGSLNO=" & dsMsgEdit.Tables(0).Rows(i)("MSGSLNO")
                        End If
                        tc.Controls.Add(btn)
                    ElseIf j = 4 Then
                        btn.Text = "Display Prop"
                        btn.ForeColor = Color.Red
                        Dim mslno As String = dsMsgEdit.Tables(0).Rows(i)("MSGSLNO").ToString
                        btn.NavigateUrl = "javascript:disProp(" & mslno & ")"
                        tc.Controls.Add(btn)
                    End If
                    tr.Cells.Add(tc)
                Next
                Table1.Rows.Add(tr)
            Next
            Dim newrow As New TableHeaderCell
            newrow.ColumnSpan = 4
            Dim nrow As New HyperLink
            nrow.Text = "Click Here To Add New Notice..!"
            nrow.NavigateUrl = "NoticeEntry.aspx?CID=nr"
            newrow.Controls.Add(nrow)
            Dim nr As New TableRow
            nr.Cells.Add(newrow)
            Table1.Rows.Add(nr)
        Catch ex As Exception

        End Try
    End Function

    Private Function editNotice(ByVal CID As String)
        Try
            Dim rNotic As New TableRow
            Dim editNotText As New TableHeaderCell
            rNotic.VerticalAlign = VerticalAlign.Middle
            Dim txt As New System.Web.UI.WebControls.TextBox
            Dim txtC As New System.Web.UI.WebControls.TextBox
            Dim save As New System.Web.UI.WebControls.Button
            save.ID = "Snotice"
            txt.Width = System.Web.UI.WebControls.Unit.Percentage(60)
            txtC.Width = System.Web.UI.WebControls.Unit.Percentage(30)
            save.Text = "Save"
            txt.ID = "t" & CID
            txt.TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine
            txt.Rows = 3
            txtC.Rows = 3
            editNotText.ColumnSpan = 3
            editNotText.Controls.Add(txtC)
            editNotText.Controls.Add(txt)
            editNotText.Controls.Add(save)
            rNotic.Cells.Add(editNotText)
            Table1.Rows.AddAt(Table1.Rows.Count, rNotic)
        Catch ex As Exception

        End Try
    End Function

    Private Sub UploadFile()
        Try
            If Not (fileNoticeboard.PostedFile Is Nothing) Then
                Dim imageSize As Double = fileNoticeboard.PostedFile.ContentLength
                Dim strLongFilePath As String = fileNoticeboard.PostedFile.FileName
                Dim intFileNameLength As Integer = InStr(1, StrReverse(strLongFilePath), "\")
                Dim strFileName As String = Mid(strLongFilePath, (Len(strLongFilePath) - intFileNameLength) + 2)
                If strFileName = Nothing Then
                    Exit Sub
                Else
                    Dim sloc As String
                    sloc = "\\10.101.3.28\S$\noticefiles\"
                    If Not Directory.Exists(sloc) Then
                        Directory.CreateDirectory(sloc)
                    End If
                    sloc = sloc & strFileName
                    fileNoticeboard.PostedFile.SaveAs(sloc)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function attach(ByVal path As String)
        Dim c As New TableCell
        Dim r As New TableRow
        Dim lb As New HyperLink
        lb.NavigateUrl = path
        lb.Target = "_blank"
        lb.Text = "Click here to download file"
        c.Controls.Add(lb)
        r.Cells.Add(c)
        Table1.Rows.Add(r)
    End Function

    Private Function getData()
        Try
            strMessage = " SELECT MSGSLNO,SUBJECT,DESCRIPTION,FILEPATH,ISACTIVE FROM masters.T_MESSAGEBOARD_DT WHERE  MODULESLNO=" & Session("MODULESLNO") & " AND USERSLNO=" & Session("USERSLNO")
            objMessage = New ClsMessageBoard
            dsMsgEdit = objMessage.dataSet_Fetch(strMessage)
        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " Image Buttons "

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If CID = "nr" Then
                Dim strLongFilePath As String = fileNoticeboard.PostedFile.FileName
                Dim intFileNameLength As Integer = InStr(1, StrReverse(strLongFilePath), "\")
                filePath = Mid(strLongFilePath, (Len(strLongFilePath) - intFileNameLength) + 2)
                Dim sloc As String = "F:\NOTICEBOARD\"
                If Not Directory.Exists(sloc) Then
                    Directory.CreateDirectory(sloc)
                End If
                If Not filePath = "" Then
                    fileNoticeboard.PostedFile.SaveAs(sloc & filePath)
                End If
                Dim CaptinNew As String
                If txtCaption.Text = Nothing Then
                    Exit Sub
                Else
                    CaptinNew = txtCaption.Text
                End If
                Dim DescriptionNew As String = txtNotice.Text
                actDeactive = 0
                objMessage = New ClsMessageBoard
                objMessage.MB_Message_Save(Session("MODULESLNO"), CaptinNew, DescriptionNew, filePath, actDeactive, Session("USERSLNO"))
                getData()
                addTable()
                Panel1.Visible = False
            ElseIf CID = "EDT" Then
                If fileNoticeboard.Value = Nothing Then
                    filePath = ""
                Else
                    Dim strLongFilePath As String = fileNoticeboard.PostedFile.FileName
                    Dim intFileNameLength As Integer = InStr(1, StrReverse(strLongFilePath), "\")
                    filePath = Mid(strLongFilePath, (Len(strLongFilePath) - intFileNameLength) + 2)
                    Dim sloc As String = "F:\NOTICEBOARD\"
                    If Not Directory.Exists(sloc) Then
                        Directory.CreateDirectory(sloc)
                    End If
                    If Not filePath = "" Then
                        fileNoticeboard.PostedFile.SaveAs(sloc & filePath)
                    End If
                End If
                Dim Captin As String
                If txtCaption.Text = Nothing Then
                    Exit Sub
                Else
                    Captin = txtCaption.Text
                End If
                Dim Description As String = txtNotice.Text
                objMessage = New ClsMessageBoard
                objMessage.MB_Message_Update(msgSlno, Session("MODULESLNO"), Captin, Description, filePath, actDeactive, Session("USERSLNO"))
                getData()
                addTable()
                Panel1.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Panel1.Visible = False
    End Sub

#End Region

End Class
