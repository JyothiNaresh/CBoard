Imports System.Data
Imports System.Data.OracleClient
Imports CollegeBoardDLL
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.Unit
Public Class NoticeDisplay
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Table1 As System.Web.UI.WebControls.Table

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Class Variables"
    Dim dsMessages As New DataSet
    Dim objMessage As ClsMessageBoard
    Dim strMessage As String
    Dim QS As String
    Dim sRowbackcolor, sRowForecolor, sRowfamily, rBullet, rAlert As String
    Dim iRowfontsize As Integer
    Dim rowDiSet As String

    Dim tc As TableCell
    Dim tcImg As TableCell
    Dim tcFDWN As TableCell
    Dim tcHand As TableCell
    Dim clink As HyperLink
    Dim fileDwLoad As New HyperLink
    Dim nDis As New TableHeaderCell
    Dim nFile As New TableHeaderCell

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Request.QueryString("CH") = Nothing Then
            If Not Request.QueryString("FD") = "" Then
                Dim FILENAME As String = Request.QueryString("FD")
                FileSaveAs(FILENAME)
            End If
            getData()
            If dsMessages.Tables(0).Rows.Count > 0 Then
                notices()
            Else
                Response.Redirect("../Security/NewForm.aspx")
            End If
        Else
            QS = Request.QueryString("CH")
            Dim ROWNO As Integer = Request.QueryString("RN")
            getData()
            notices()
            Dim DR() As DataRow
            DR = dsMessages.Tables(0).Select("MSGSLNO=" & QS)
            nDis = New TableHeaderCell
            nFile = New TableHeaderCell
            nFile.VerticalAlign = VerticalAlign.Bottom
            nFile.HorizontalAlign = HorizontalAlign.Center
            nDis.BorderStyle = BorderStyle.Solid
            nDis.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
            nDis.BorderColor = Color.White
            nDis.ColumnSpan = 3
            Dim dicr As New TableRow
            If Not IsDBNull(DR(0)("DESCRIPTION")) Then
                nDis.Text = DR(0)("DESCRIPTION")
            Else
                nDis.Text = "--"
            End If
            'nDis.BackColor = Color.FromArgb(51, 204, 204)
            nDis.BackColor = Color.DarkBlue
            nDis.Font.Name = "Verdana"
            nDis.ForeColor = Color.White
            If Not IsDBNull(DR(0)("FONTS")) Then
                rowDiSet = DR(0)("FONTS")
                rowFonts(rowDiSet)
                If Not sRowbackcolor = "" Then
                    nDis.BackColor = Color.FromName(sRowbackcolor)
                End If
                If Not sRowForecolor = "" Then
                    nDis.ForeColor = Color.FromName(sRowForecolor)
                End If
                If Not sRowfamily = "" Then
                    nDis.Font.Name = sRowfamily
                End If



            End If
            nDis.CssClass.PadLeft(25)
            nDis.HorizontalAlign = HorizontalAlign.Left
            nDis.Font.Size = FontUnit.Point(10)
            dicr.Cells.Add(nDis)
            Table1.CellPadding = 7
            Table1.Rows.AddAt(ROWNO + 2, dicr)
        End If
    End Sub

    Private Function notices()
        Try
            Table1.Rows.Clear()
            Table1.CellPadding = 7
            Dim I, J, L As Integer
            For I = 0 To dsMessages.Tables(0).Rows.Count - 1

                Dim tr As New TableRow
                ' tr.BackColor = Color.FromArgb(51, 204, 204)
                tr.BackColor = Color.DarkBlue
                tr.ForeColor = Color.White
                tr.BorderColor = Color.White
                tr.BorderStyle = BorderStyle.Solid
                tr.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
                tc = New TableCell
                tcImg = New TableCell
                tcFDWN = New TableCell
                clink = New HyperLink
                clink.ForeColor = Color.White
                tcHand = New TableCell
                Dim imgDown As New HyperLink
                fileDwLoad = New HyperLink
                Dim hand As New Image
                If Not IsDBNull(dsMessages.Tables(0).Rows(I)("FONTS")) Then
                    rowDiSet = dsMessages.Tables(0).Rows(I)("FONTS")
                    rowFonts(rowDiSet)
                    addColorsToRow()
                End If
                If rBullet = "," Then
                    hand.ImageUrl = "../../Images/noticeArrow.gif"
                ElseIf rBullet = "" Then
                    hand.ImageUrl = "../../Images/hand.gif"
                Else
                    hand.ImageUrl = "../../Images/" & rBullet
                End If
                tcImg.HorizontalAlign = HorizontalAlign.Right
                tcHand.VerticalAlign = VerticalAlign.Bottom
                tcHand.Width = Pixel(17)
                tcHand.HorizontalAlign = HorizontalAlign.Left
                tcHand.Controls.Add(hand)
                Dim newImg As New Image
                clink.Text = dsMessages.Tables(0).Rows(I)("SUBJECT")
                clink.ToolTip = "Click Here To View Notice"
                clink.Font.Name = "Verdana"
                clink.NavigateUrl = "NoticeDisplay.aspx?CH=" & dsMessages.Tables(0).Rows(I)("MSGSLNO") & "&RN=" & I
                imgDown.NavigateUrl = "NoticeDisplay.aspx?CH=" & dsMessages.Tables(0).Rows(I)("MSGSLNO") & "&RN=" & I
                tc.VerticalAlign = VerticalAlign.Bottom
                tr.Cells.Add(tcHand)
                tc.Controls.Add(clink)
                If rAlert = "," Then
                ElseIf rAlert = "" Then
                Else
                    Dim NE As New Image
                    NE.Width = Unit.Pixel(32)
                    NE.Height = Unit.Pixel(16)
                    NE.ImageUrl = "../../Images/" & rAlert
                    tc.Controls.Add(NE)
                End If
                tr.Cells.Add(tc)
                If IsDBNull(dsMessages.Tables(0).Rows(I)("FILEPATH")) Then
                Else
                    fileDwLoad.Text = "Download"
                    fileDwLoad.ForeColor = Color.White
                    fileDwLoad.NavigateUrl = "NoticeDisplay.aspx?CH=" & "&FD=" & dsMessages.Tables(0).Rows(I)("FILEPATH")
                    tcImg.Controls.Add(fileDwLoad)
                    tr.Cells.Add(tcImg)
                End If
                tr.Cells.Add(tcImg)
                Table1.Rows.Add(tr)
            Next


            Dim TH As New TableHeaderCell
            TH.ColumnSpan = 3
            Dim THR As New TableRow
            TH.BackColor = Color.FromArgb(255, 102, 0)
            TH.ForeColor = Color.White
            'TH.Font.Name = "Calibri"
            TH.Height = System.Web.UI.WebControls.Unit.Pixel(45)
            TH.Font.Size = System.Web.UI.WebControls.FontUnit.Large
            TH.Controls.Add(New LiteralControl("Notice Board"))
            TH.Font.Name = "Verdana"
            THR.Cells.Add(TH)
            Table1.Rows.AddAt(0, THR)
            ''------------------------------------------------------
            ''First message description will be displayed

            If Request.QueryString("CH") = Nothing Then

                'Dim DR() As DataRow
                'DR = dsMessages.Tables(0).Rows(0)
                nDis = New TableHeaderCell
                nFile = New TableHeaderCell
                nFile.VerticalAlign = VerticalAlign.Bottom
                nFile.HorizontalAlign = HorizontalAlign.Center
                nDis.BorderStyle = BorderStyle.Solid
                nDis.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
                nDis.BorderColor = Color.White
                nDis.ColumnSpan = 3
                Dim dicr As New TableRow
                If Not IsDBNull(dsMessages.Tables(0).Rows(0)("DESCRIPTION")) Then
                    nDis.Text = dsMessages.Tables(0).Rows(0)("DESCRIPTION")
                Else
                    nDis.Text = "--"
                End If
                ' nDis.BackColor = Color.FromArgb(51, 204, 204)
                nDis.BackColor = Color.DarkBlue
                nDis.Font.Name = "Verdana"
                nDis.ForeColor = Color.White
                If Not IsDBNull(dsMessages.Tables(0).Rows(0)("FONTS")) Then
                    rowDiSet = dsMessages.Tables(0).Rows(0)("FONTS")
                    rowFonts(rowDiSet)
                    'nDis.BackColor = Color.FromName(sRowbackcolor)
                    'nDis.Font.Name = sRowfamily
                    'nDis.ForeColor = Color.FromName(sRowForecolor)

                    If Not sRowbackcolor = "" Then
                        nDis.BackColor = Color.FromName(sRowbackcolor)
                    End If
                    If Not sRowForecolor = "" Then
                        nDis.ForeColor = Color.FromName(sRowForecolor)
                    End If
                    If Not sRowfamily = "" Then
                        nDis.Font.Name = sRowfamily
                    End If

                End If
                nDis.CssClass.PadLeft(25)
                nDis.HorizontalAlign = HorizontalAlign.Left
                nDis.Font.Size = FontUnit.Point(10)
                dicr.Cells.Add(nDis)
                Table1.CellPadding = 7
                Table1.Rows.AddAt(2, dicr)


            End If
            ''-------------------------------------------------------


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getData()
        strMessage = " SELECT MSGSLNO,SUBJECT,DESCRIPTION,FILEPATH,FONTS  FROM  MASTERS.T_MESSAGEBOARD_DT WHERE ISACTIVE=1 AND MODULESLNO=" & Session("MODULESLNO") & " ORDER BY MSGSLNO DESC"
        objMessage = New ClsMessageBoard
        dsMessages = objMessage.dataSet_Fetch(strMessage)
    End Function

    Private Sub FileSaveAs(ByVal strRequesti As String)
        If strRequesti <> "" Then
            Dim path As String = strRequesti
            path = "F:\NOTICEBOARD\" & strRequesti
            Dim file As System.IO.FileInfo = New System.IO.FileInfo(path)
            If file.Exists Then
                Response.Clear()
                Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
                Response.AddHeader("Content-Length", file.Length.ToString())
                Response.ContentType = "application/octet-stream"
                Response.WriteFile(file.FullName)
                Response.End()
            Else
            End If
        Else
        End If
    End Sub

    Private Function rowFonts(ByVal rowDispSettings As String)
        For I As Integer = 0 To 5
            Dim intFileNameLength As Integer = InStr(1, rowDispSettings, ",")
            If I = 0 Then
                sRowbackcolor = rowDispSettings.Substring(0, intFileNameLength - 1)
            ElseIf I = 1 Then
                sRowForecolor = rowDispSettings.Substring(0, intFileNameLength - 1)
            ElseIf I = 2 Then
                sRowfamily = rowDispSettings.Substring(0, intFileNameLength - 1)
            ElseIf I = 3 Then
                iRowfontsize = CInt(rowDispSettings.Substring(0, intFileNameLength - 1))
            ElseIf I = 4 Then
                rBullet = rowDispSettings.Substring(0, intFileNameLength - 1)
            ElseIf I = 5 Then
                If Not rowDispSettings = "" Then
                    rAlert = rowDispSettings
                Else
                    rAlert = ""
                End If
            End If
            rowDispSettings = rowDispSettings.Substring(intFileNameLength)
        Next
    End Function

    Private Function addColorsToRow()


        If Not sRowbackcolor = "" Then
            tc.BackColor = Color.FromName(sRowbackcolor)
            tcHand.BackColor = Color.FromName(sRowbackcolor)
            tcImg.BackColor = Color.FromName(sRowbackcolor)
            nDis.BackColor = Color.FromName(sRowbackcolor)

        End If

        If Not sRowForecolor = "" Then
            clink.ForeColor = Color.FromName(sRowForecolor)
            tc.ForeColor = Color.FromName(sRowForecolor)
            tcImg.ForeColor = Color.FromName(sRowForecolor)
            tcHand.ForeColor = Color.FromName(sRowForecolor)
            nDis.ForeColor = Color.FromName(sRowForecolor)
            fileDwLoad.ForeColor = Color.FromName(sRowForecolor)
        End If

        If iRowfontsize > 8 Then
            tc.Font.Size = FontUnit.Point(iRowfontsize)
            clink.Font.Size = System.Web.UI.WebControls.FontUnit.Point(iRowfontsize)
            tcImg.Font.Size = FontUnit.Point(iRowfontsize)
            tcHand.Font.Size = FontUnit.Point(iRowfontsize)

        End If

        If Not sRowfamily = "" Then

            tc.Font.Name = "sRowfamily"
            clink.Font.Name = "sRowfamily"
            tcImg.Font.Name = "sRowfamily"
            tcHand.Font.Name = "sRowfamily"
            nDis.Font.Name = "sRowfamily"
            fileDwLoad.Font.Name = "sRowfamily"

        End If

    End Function
End Class
