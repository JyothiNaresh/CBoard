Imports System
Imports System.Web.UI
Imports System.Web.UI.Page
Imports System.Web.HttpWorkerRequest
Imports System.Web.HttpUtility
Imports System.Text
Imports System.IO
Imports CollegeBoardDLL

Module Common

#Region "Module Level variables"
    Private objUcls As UserClass
    Private _ch As Char() = {"/", ".", "-"}
    Public FormName As String = "Form1"
#End Region

#Region "Common Methos"

    Public Function IsDate(ByVal txtDate As String, Optional ByVal isMust As Boolean = False) As Boolean
        Try

            Dim str() As String

            If txtDate.ToString = "" And isMust Then
                Return False
            ElseIf txtDate.ToString = "" And Not isMust Then
                Return True
            End If

            str = txtDate.Split(_ch)

            If str.Length <> 3 Then
                Return False
            End If

            If Val(str(0)) < 0 Or Val(str(0) > 31) Then
                Return False
            End If

            If Val(str(1)) < 0 Or Val(str(1) > 12) Then
                Return False
            End If

            If Val(str(2)) < 1900 Or Val(str(2) > 3000) Then
                Return False
            End If
            'Date.Parse(txtDate.text)
            Try
                Dim dt As Date

                Dim strFormat() As String = {"M/dd/yyyy", "dd/M/yyyy", "d/MM/yyyy", "d-MM-yyyy", "dd-M-yyyy", "d-M-yyyy", "d/M/yyyy", "d.M.yyyy", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy", "dd-MM/yyyy", "dd.MM/yyyy", "dd/MM.yyyy", "dd/MM-yyyy", "dd.MM-yyyy", "dd-MM.yyyy"}
                dt = Date.ParseExact(txtDate, strFormat, Nothing, Nothing)
                Return True

            Catch ex As FormatException
                Return False
            Catch ex As Exception
                Return False
            End Try
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function IsDate1(ByVal txtDate As String, Optional ByVal isMust As Boolean = False) As Boolean
        Try

            Dim str() As String

            If txtDate.ToString = "" And isMust Then
                Return False
            ElseIf txtDate.ToString = "" And Not isMust Then
                Return True
            End If

            str = txtDate.Split(_ch)

            If str.Length <> 3 Then
                Return False
            End If

            If Val(str(1)) < 0 Or Val(str(1) > 31) Then
                Return False
            End If

            If Val(str(0)) < 0 Or Val(str(0) > 12) Then
                Return False
            End If

            If Val(str(2)) < 1900 Or Val(str(2) > 3000) Then
                Return False
            End If
            'Date.Parse(txtDate.text)
            Try
                Dim dt As Date

                Dim strFormat() As String = {"M/dd/yyyy", "dd/M/yyyy", "d/MM/yyyy", "d-MM-yyyy", "dd-M-yyyy", "d-M-yyyy", "d/M/yyyy", "d.M.yyyy", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy", "dd-MM/yyyy", "dd.MM/yyyy", "dd/MM.yyyy", "dd/MM-yyyy", "dd.MM-yyyy", "dd-MM.yyyy"}
                dt = Date.ParseExact(txtDate, strFormat, Nothing, Nothing)
                Return True

            Catch ex As FormatException
                Return False
            Catch ex As Exception
                Return False
            End Try
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function DateConversion(ByVal Txtdate As String) As Date

        Dim Dt As Date
        Dim str() As String
        Try
            str = Txtdate.Split(_ch)

            If str.Length <> 3 Then
                Throw New ArgumentException("Invalid Date")
            End If

            If Val(str(2)) < 1900 Or Val(str(2) > 3000) Then
                Throw New ArgumentException("Invalid Date")
            End If

            If Not IsDate1(DateSerial(str(2), str(1), str(0))) Then
                Throw New ArgumentException("Invalid Date")
            End If

            Dt = DateSerial(str(2), str(1), str(0))

        Catch EX As Exception
            Dt = "1/1/1900"
        End Try

        Return Dt

    End Function

    Public Function ReportDateConversion(ByVal Txtdate As String) As String

        Dim Dt As Date
        Dim str() As String
        Dim DtStr As String
        Try
            str = Txtdate.Split(_ch)

            If str.Length <> 3 Then
                Throw New ArgumentException("Invalid Date")
            End If

            If Val(str(2)) < 1900 Or Val(str(2) > 3000) Then
                Throw New ArgumentException("Invalid Date")
            End If

            If Not IsDate1(DateSerial(str(2), str(1), str(0))) Then
                Throw New ArgumentException("Invalid Date")
            End If

            Dt = DateSerial(str(2), str(1), str(0))
            DtStr = Format(Dt, "dd-MMM-yyyy")

        Catch EX As Exception
            Dt = "1/1/1900"
        End Try

        Return DtStr

    End Function

    Public Function IsNumeric(ByVal ADMSNO As String) As Boolean

        Try
            Dim i As Integer
            If ADMSNO <> "" Then
                For i = 0 To ADMSNO.Length - 1
                    If ((Asc(ADMSNO.Substring(i, 1)) < 44 Or Asc(ADMSNO.Substring(i, 1)) > 57) And (Asc(ADMSNO.Substring(i, 1)) <> 8)) And (Asc(ADMSNO.Substring(i, 1)) <> 13) Then
                        Return False
                    End If
                Next
            End If
            Return True

        Catch ex As Exception

        End Try

    End Function

    Public Function IsNumeric2(ByVal ADMSNO As String) As Boolean

        Try
            Dim i As Integer
            If ADMSNO <> "" Then
                For i = 0 To ADMSNO.Length - 1
                    If Asc(ADMSNO.Substring(i, 1)) = 45 Then
                        Return False
                    End If
                Next
            End If
            Return True

        Catch ex As Exception

        End Try

    End Function

    Public Function IsPhoneNumber(ByVal Number As String) As Boolean
        Try
            Dim i As Integer
            If Number <> "" Then
                For i = 0 To Number.Length - 1
                    If ((Asc(Number.Substring(i, 1)) < 48 Or Asc(Number.Substring(i, 1)) > 57) And (Asc(Number.Substring(i, 1)) <> 8)) And (Asc(Number.Substring(i, 1)) <> 13) And (Asc(Number.Substring(i, 1)) <> 45) And (Asc(Number.Substring(i, 1)) <> 32) Then
                        '''45 Is For - (Hyphen)
                        '''32 is For Space
                        Return False
                    End If
                Next
            End If
            Return True
        Catch ex As Exception

        End Try
    End Function

    Public Function IsDecimal(ByVal ActualNumber As String) As Boolean
        Try
            Dim ValidateString As String = ".0123456789"
            Dim Str() As String = ActualNumber.Split(".")

            For i As Integer = 0 To Len(ActualNumber) - 1
                Dim Temp As Char = ActualNumber.Substring(i, 1)
                If (ValidateString.IndexOf(Temp) = -1) Then
                    Return False
                End If
            Next

            If (Str.Length - 1 > 1) Then
                Return False
            ElseIf Str.Length > 1 Then
                If (Str(1).Length > 2) Then
                    Return False
                End If
            End If

            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function IsNegitiveDecimal(ByVal ActualNumber As String) As Boolean
        Try
            Dim ValidateString As String = "-.0123456789"
            Dim Str() As String = ActualNumber.Split(".")

            For i As Integer = 0 To Len(ActualNumber) - 1
                Dim Temp As Char = ActualNumber.Substring(i, 1)
                If (ValidateString.IndexOf(Temp) = -1) Then
                    Return False
                End If
            Next

            If (Str.Length - 1 > 1) Then
                Return False
            ElseIf Str.Length > 1 Then
                If (Str(1).Length > 2) Then
                    Return False
                End If
            End If

            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function isEmail(ByVal Stremail As String) As Boolean
        Dim myAt As Integer
        Dim myDot As Integer
        Dim myDotDot As Integer

        myAt = InStr(1, Stremail, "@", vbTextCompare)
        myDot = InStr(myAt + 2, Stremail, ".", vbTextCompare)
        myDotDot = InStr(myAt + 2, Stremail, "..", vbTextCompare)
        If myAt = 0 Or myDot = 0 Or Not myDotDot = 0 Or Right(Stremail, 1) = "." Then
            isEmail = False
        Else
            isEmail = True
        End If

    End Function

    Public Sub FormInfo(ByVal pUserslno As Integer, ByVal pLogSlno As Integer, ByVal pFormName As String)
        Dim dsUser As String
        objUcls = New UserClass
        dsUser = objUcls.UserAccess(pUserslno, pLogSlno, pFormName)
    End Sub
#End Region

#Region "Report Methods"
    Public Function PrintLinesWithoutVBCRLF(Optional ByVal pChar As Char = " ", Optional ByVal NoOfCols As Integer = 0, Optional ByVal NoOfRows As Integer = 1) As String
        'prakash on aug 30 '07
        Dim iCount As Integer
        Dim iRow As Integer
        Dim lStr As String = ""
        For iRow = 1 To NoOfRows
            If NoOfCols = 0 Then
                lStr = lStr
            Else
                For iCount = 1 To NoOfCols
                    lStr = lStr & pChar
                Next
                lStr = lStr
            End If
        Next
        PrintLinesWithoutVBCRLF = lStr
    End Function
    Public Function PrintLines(Optional ByVal pChar As Char = " ", Optional ByVal NoOfCols As Integer = 0, Optional ByVal NoOfRows As Integer = 1) As String
        Dim iCount As Integer
        Dim iRow As Integer
        Dim lStr As String = ""
        For iRow = 1 To NoOfRows
            If NoOfCols = 0 Then
                lStr = lStr & vbCrLf
            Else
                For iCount = 1 To NoOfCols
                    lStr = lStr & pChar
                Next
                lStr = lStr & vbCrLf
            End If
        Next
        PrintLines = lStr
    End Function

    Public Function StrPaddingHeading(ByVal Input As String, ByVal NoOfCols As Integer, ByVal LRM As String) As String
        Dim iCount As Integer
        Dim lPad As String = ""

        lPad = Input
        ''If Len(lPad) >= NoOfCols Then
        ''    StrPaddingHeading = Left(lPad, NoOfCols)
        ''    Exit Function
        ''End If

        Try
            If LRM = "L" Then
                For iCount = 1 To NoOfCols - Len(lPad)

                    lPad = lPad & " "
                Next
            ElseIf LRM = "R" Then
                For iCount = 1 To NoOfCols - Len(lPad)
                    lPad = " " & lPad
                Next

            ElseIf LRM = "M" Then
                NoOfCols = NoOfCols - Len(lPad)
                Dim MidCol As Integer = CInt(NoOfCols / 2)


                For iCount = 1 To NoOfCols - MidCol
                    lPad = " " & lPad
                Next

                For iCount = (NoOfCols - MidCol) To NoOfCols - 1
                    lPad = lPad & " "
                Next
            End If
        Catch ex As Exception

        Finally
            StrPaddingHeading = lPad

        End Try

    End Function

    Public Function StrPadding(ByVal Input As String, ByVal NoOfCols As Integer, ByVal LRM As String) As String
        Dim iCount As Integer
        Dim lPad As String = ""

        lPad = Input
        If Len(lPad) >= NoOfCols Then
            StrPadding = Left(lPad, NoOfCols)
            Exit Function
        End If

        Try
            If LRM = "L" Then
                For iCount = 1 To NoOfCols - Len(lPad)

                    lPad = lPad & " "
                Next
            ElseIf LRM = "R" Then
                For iCount = 1 To NoOfCols - Len(lPad)
                    lPad = " " & lPad
                Next

            ElseIf LRM = "M" Then
                NoOfCols = NoOfCols - Len(lPad)
                Dim MidCol As Integer = CInt(NoOfCols / 2)


                For iCount = 1 To NoOfCols - MidCol
                    lPad = " " & lPad
                Next

                For iCount = (NoOfCols - MidCol) To NoOfCols - 1
                    lPad = lPad & " "
                Next
            End If
        Catch ex As Exception

        Finally
            StrPadding = lPad

        End Try

    End Function


#End Region

#Region "Alert"

    'Private Sub StartUpScript(ByVal FormName As String, Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")
    '    Try
    '        If focusCtrl <> "" And strMessage <> "" Then
    '            RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & FormName & "." & focusCtrl & " == '[object]') { document." & FormName & "." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
    '        ElseIf strMessage <> "" Then
    '            RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
    '        ElseIf focusCtrl <> "" Then
    '            RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & FormName & "." & focusCtrl & " == '[object]') { document." & FormName & "." & focusCtrl & ".focus(); } </script>")
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub



#End Region

#Region "FillListBox"

    Public Sub FillListAll(ByVal ListBox_From As ListBox, ByVal ListBox_To As ListBox)
        Dim intCounter As Integer = 0

        For intCounter = 0 To ListBox_From.Items.Count - 1
            ListBox_To.Items.Add(ListBox_From.Items(intCounter))
        Next
        ListBox_From.Items.Clear()
    End Sub

    Public Sub FillListSel(ByVal ListBox_From As ListBox, ByVal ListBox_To As ListBox)
        Dim intCouter As Integer = 0
        Try

            If (Not ListBox_From.SelectedItem Is Nothing) Then

                Dim itmList As ListItem
                For Each itmList In ListBox_From.Items
                    If itmList.Selected Then
                        ListBox_To.Items.Add(itmList)
                    End If
                Next

                Dim i As Byte = 0
                Do
                    If ListBox_From.Items(i).Selected = True Then
                        ListBox_From.Items.Remove(ListBox_From.Items(i))
                    Else
                        i = i + 1
                    End If
                Loop Until (i = ListBox_From.Items.Count)

            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub ClearListBox(ByVal ListBox_Clear As ListBox)
        ListBox_Clear.Items.Clear()
    End Sub

#End Region

#Region "Button Hiding Procedure"
    Public Sub ButtonsHiding(ByVal webPage As Page)
        'added by prakash on oct 15 2007
        Try
            Dim ctlImageButton As ImageButton
            Dim objc As Control
            Dim objchildc As Control

            For Each objc In webPage.Controls
                For Each objchildc In objc.Controls
                    If TypeOf objchildc Is ImageButton Then
                        ctlImageButton = CType(objchildc, ImageButton)
                        ctlImageButton.Attributes.Add("OnClick", "return Reports_ButtonsHide()")
                    End If
                Next
            Next

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region

#Region "Smart Navigation using java script"


    'Note: There are two methods SetScroll,SaveScroll for implementing smart navigation feature 
    ' SaveScrollLocation() need to be called for every scroll event fired so add the below 
    '<body onscroll="return SaveScrollLocation();">
    Public Sub SetScroll(ByVal webPage As Page)
        'added by prakash on Jan 31 2008
        'setting the scroll location 
        'call this method in page_load 
        'Ex: - If IsPostBack Then SetScroll(Me.Page)

        webPage.RegisterStartupScript("setScroll", "<script language='javascript'>" & "function SetScrollLocation () {" & "     document.body.scrollTop = " & webPage.Request("__SCROLLLOC") & ";" & "}" & "document.body.onload=SetScrollLocation ;" & "</script>")

    End Sub
    Public Sub SaveScroll(ByVal webPage As Page)
        'added by prakash on Jan 31 2008
        'save scroll location 
        'call this method in Page_Init
        'Ex:- SaveScroll(Me.Page)
        webPage.RegisterHiddenField("__SCROLLLOC", "0")

        webPage.RegisterStartupScript("saveScroll", "<script language='javascript'>" & "function SaveScrollLocation () {" & "     document.forms[0].__SCROLLLOC.value = document.body.scrollTop;" & "}" & "document.body.onscroll=SaveScrollLocation ;" & "</script>")

    End Sub

#End Region

#Region "Graph Variables"

    Public PUB_PAID_COLOR_BRUSH As New System.Drawing.SolidBrush(Color.Green)

    Public PUB_LESS_COLOR_BRUSH As New System.Drawing.SolidBrush(Color.Red)

    Public PUB_BALANCE_COLOR_BRUSH As New System.Drawing.SolidBrush(Color.Blue)

    Public PUB_NET_COLOR_BRUSH As New System.Drawing.SolidBrush(Color.Pink)

    Public PUB_STRENGTH_COLOR_BRUSH As New System.Drawing.SolidBrush(Color.CadetBlue)

    Public PUB_LABEL_COLOR As New System.Drawing.SolidBrush(Color.Black)

    Public PUB_LABEL_FONT_BOLD_VALUES As New Font("arial", FontSize.Large, FontStyle.Bold)

    Public PUB_LABEL_FONT_BOLD_NAMES As New Font("arial", FontSize.XXLarge, FontStyle.Bold)

    Public PUB_LABEL_FONT_NORMAL_VALUES As New Font("arial", FontSize.Large, FontStyle.Regular)

    Public PUB_LABEL_FONT_NORMAL_NAMES As New Font("arial", FontSize.XXLarge, FontStyle.Regular)

    Public PUB_LINE_COLOR As New System.Drawing.Pen(Color.RosyBrown, 1)

    Public PUB_TEXT_COLOR As New System.Drawing.SolidBrush(Color.Black)

#End Region

#Region "HTML ALLIGNMENTS FORMATS"

#Region "CENTER ALIGNMENTS FORMATS"

    Public Function DatacenterAlignstyleSmallhight(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0) As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("text-align", "center")
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            myAttributes.CssStyle.Add("color", fcolor)
            tcell.ColumnSpan = icolspan
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            tcell.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = pNavigateUrl
            tcell.Height = Unit.Pixel(3)
            tcell.RowSpan = rowSpan
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DatacenterAlignstyle(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0) As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("text-align", "center")
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            myAttributes.CssStyle.Add("color", fcolor)
            tcell.ColumnSpan = icolspan
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            ' tcell.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            tcell.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = pNavigateUrl
            tcell.Height = Unit.Pixel(14)
            tcell.RowSpan = rowSpan
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '(DataCenterAlignstyleHlink
    Public Function DatacenterAlignstyle2(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0) As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("text-align", "center")
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            myAttributes.CssStyle.Add("color", fcolor)
            tcell.ColumnSpan = icolspan
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            ' tcell.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            tcell.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = pNavigateUrl
            tcell.Height = Unit.Pixel(14)
            tcell.RowSpan = rowSpan
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "LEFTT ALIGNMENTS FORMATS"

    Public Function DataleftAlignstyleHlinkSmallhight(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            myAttributes.CssStyle.Add("text-align", "left")
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            'TLink.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            tcell.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            tcell.RowSpan = rowSpan
            TLink.NavigateUrl = pNavigateUrl
            tcell.Height = Unit.Pixel(3)
            TLink.CssClass = "link"
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Top
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DataleftAlignstyleHlink(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            myAttributes.CssStyle.Add("text-align", "left")
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            'TLink.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            tcell.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            tcell.RowSpan = rowSpan
            TLink.NavigateUrl = pNavigateUrl
            tcell.Height = Unit.Pixel(14)
            TLink.CssClass = "link"
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function DataCenterAlignstyleHlink(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            myAttributes.CssStyle.Add("text-align", "center")
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            'TLink.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            tcell.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            tcell.RowSpan = rowSpan
            TLink.NavigateUrl = pNavigateUrl
            tcell.Height = Unit.Pixel(14)
            TLink.CssClass = "link"
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass

            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function DataCenterAlignstyleHlink11(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            myAttributes.CssStyle.Add("text-align", "center")
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            'TLink.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            tcell.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            tcell.RowSpan = rowSpan
            TLink.NavigateUrl = pNavigateUrl
            tcell.Height = Unit.Pixel(14)
            TLink.CssClass = "link"
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function DataleftAlignstyleHlink1(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("text-align", "left")
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            'tcell.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            tcell.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = "javascript:VEditN('" & pNavigateUrl & "')"
            TLink.CssClass = "link"
            tcell.Wrap = False
            tcell.Height = Unit.Pixel(14)
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.CssClass = cssClass
            tcell.Controls.Add(TLink)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function DataCenterAlignstyleHlink1(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("text-align", "center")
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            'tcell.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            tcell.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            '  TLink.NavigateUrl = "javascript:VEditN('" & pNavigateUrl & "')"

            TLink.NavigateUrl = pNavigateUrl

            TLink.CssClass = "link"
            tcell.Wrap = False
            tcell.Height = Unit.Pixel(14)
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.CssClass = cssClass
            tcell.Controls.Add(TLink)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DataleftAlignstyleHlinkNew(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("text-align", "Left")
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            TLink.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = "javascript:VEdit('" & pNavigateUrl & "')"
            tcell.RowSpan = rowSpan
            tcell.Height = Unit.Pixel(14)
            TLink.CssClass = "link"
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.CssClass = cssClass
            tcell.Controls.Add(TLink)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DataleftAlignstyleHlinkwordwrap(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            myAttributes.CssStyle.Add("text-align", "left")
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("word-wrap", "break-word")
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            TLink.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            tcell.RowSpan = rowSpan
            TLink.NavigateUrl = "javascript:VEditN('" & pNavigateUrl & "')"
            tcell.Height = Unit.Pixel(14)
            TLink.CssClass = "link"
            tcell.Wrap = True
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "NARRATION FORMATS"

    Public Function DataleftNarration(ByVal iText As String, ByVal iText1 As String) As TableCell
        Try
            Dim TABPARTICULAR As New Table
            Dim PTR1 As New TableRow
            Dim PTR2 As New TableRow

            Dim PTCE1 As New TableCell
            Dim PTCE2 As New TableCell
            Dim STR, STR1 As String

            PTCE1.Text = iText.Replace("<BR>", " ")
            ' PTCE1.Font.Bold = True
            PTCE1.ForeColor = Color.Blue
            PTCE1.Font.Size = FontUnit.Point(7)
            PTCE1.Wrap = True
            PTCE1.ToolTip = "Particulars"
            PTCE1.VerticalAlign = VerticalAlign.Bottom


            Dim myAttributes As AttributeCollection = PTCE2.Attributes
            myAttributes.CssStyle.Add("word-wrap", "break-word")
            PTCE2.Text = iText1.Replace("<BR>", " ")
            PTCE2.ForeColor = Color.Black
            PTCE2.Wrap = True
            'PTCE2.Width = Unit.Pixel(340)
            PTCE2.Width = Unit.Pixel(400)
            PTCE2.Font.Size = FontUnit.Point(7)
            PTCE2.VerticalAlign = VerticalAlign.Top
            PTR1.Cells.Add(PTCE1)
            PTR2.Cells.Add(PTCE2)


            PTR1.VerticalAlign = VerticalAlign.Bottom
            PTR2.VerticalAlign = VerticalAlign.Top

            TABPARTICULAR.Rows.Add(PTR1)
            TABPARTICULAR.Rows.Add(PTR2)

            TABPARTICULAR.HorizontalAlign = HorizontalAlign.Left
            Dim tcell As New TableCell
            tcell.Controls.Add(TABPARTICULAR)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Dataleft(ByVal iText As String, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim TABPARTICULAR As New Table
            Dim PTR1 As New TableRow
            Dim PTCE1 As New TableCell
            Dim myAttributes As AttributeCollection = PTCE1.Attributes
            myAttributes.CssStyle.Add("word-wrap", "break-word")
            PTCE1.Text = iText
            PTCE1.ForeColor = Color.Black
            PTCE1.Wrap = True
            PTCE1.Width = Unit.Pixel(320)
            PTCE1.Font.Size = FontUnit.Point(7)
            PTCE1.VerticalAlign = VerticalAlign.Top
            PTR1.Cells.Add(PTCE1)
            PTR1.VerticalAlign = VerticalAlign.Top
            TABPARTICULAR.Rows.Add(PTR1)
            TABPARTICULAR.HorizontalAlign = HorizontalAlign.Left
            Dim tcell As New TableCell
            tcell.Controls.Add(TABPARTICULAR)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Dataleftalign(ByVal iText As String, ByVal isize As Integer, ByVal fcolor As String, ByVal bcolor As String, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim TABPARTICULAR As New Table
            Dim PTR1 As New TableRow
            Dim PTCE1 As New TableCell
            Dim myAttributes As AttributeCollection = PTCE1.Attributes
            'myAttributes.CssStyle.Add("word-wrap", "break-word")
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("background-color", bcolor)
            PTCE1.Text = iText
            ''PTCE1.ForeColor = Color.Black
            PTCE1.Wrap = True
            PTCE1.Width = Unit.Pixel(isize)
            PTCE1.Font.Size = FontUnit.Point(7)
            PTCE1.VerticalAlign = VerticalAlign.Top
            PTR1.Cells.Add(PTCE1)
            PTR1.VerticalAlign = VerticalAlign.Top
            TABPARTICULAR.Rows.Add(PTR1)
            TABPARTICULAR.HorizontalAlign = HorizontalAlign.Left
            Dim tcell As New TableCell
            tcell.Controls.Add(TABPARTICULAR)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Dataleft1(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor) ''lcolor means link color 
            tcell.ColumnSpan = icolspan
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("text-align", "left")
            tcell.Font.Name = ifontname
            TLink.Width = Unit.Pixel(iwidth)
            'TLink.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            TLink.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = pNavigateUrl
            tcell.RowSpan = rowSpan
            tcell.Height = Unit.Pixel(10)
            TLink.CssClass = "link" ''this statement is reqired to omit the underline
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Top
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Dataleft12(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor) ''lcolor means link color 
            tcell.ColumnSpan = icolspan
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("text-align", "left")
            tcell.Font.Name = ifontname
            TLink.Width = Unit.Pixel(iwidth)
            'TLink.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            TLink.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = pNavigateUrl
            tcell.RowSpan = rowSpan
            tcell.Height = Unit.Pixel(10)
            TLink.CssClass = "link" ''this statement is reqired to omit the underline
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "RIGHT ALIGNMENTS FORMATS"

    Public Function DataRightAlignstyleHlinkSmallhight(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("text-align", "right")
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            'TLink.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            TLink.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = pNavigateUrl
            tcell.Height = Unit.Pixel(3)
            tcell.RowSpan = rowSpan
            TLink.CssClass = "link"
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DataRightAlignstyleHlink(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("text-align", "right")
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            'TLink.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            TLink.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = pNavigateUrl

            tcell.Height = Unit.Pixel(14)
            tcell.RowSpan = rowSpan
            TLink.CssClass = "link"
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DataRightAlignstyleHlink1(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("text-align", "right")
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            tcell.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            tcell.Height = Unit.Pixel(14)
            tcell.RowSpan = rowSpan
            TLink.NavigateUrl = "javascript:VEditN('" & pNavigateUrl & "')"
            TLink.CssClass = "link"
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.CssClass = cssClass
            tcell.Controls.Add(TLink)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DataRightAlignstyleHlinkNew(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("text-align", "right")
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            tcell.Width = Unit.Pixel(iwidth)
            tcell.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = "javascript:VEdit('" & pNavigateUrl & "')"
            tcell.RowSpan = rowSpan
            TLink.CssClass = "link"
            tcell.Height = Unit.Pixel(14)
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.CssClass = cssClass
            tcell.Controls.Add(TLink)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "KVR FORMATS"

    Public Function DataleftAlignwrapword(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            myAttributes.CssStyle.Add("text-align", "left")
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("word-wrap", "break-word")
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            TLink.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            tcell.RowSpan = rowSpan
            TLink.NavigateUrl = pNavigateUrl
            tcell.Height = Unit.Pixel(14)
            TLink.CssClass = "link"
            tcell.Wrap = True
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DataRightAlignwrapword(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("text-align", "right")
            myAttributes.CssStyle.Add("word-wrap", "break-word")
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            TLink.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = pNavigateUrl
            tcell.Height = Unit.Pixel(14)
            tcell.RowSpan = rowSpan
            TLink.CssClass = "link"
            tcell.Wrap = True
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

    Public Function CommonHeading(ByVal noOfColoumns As Integer, ByVal ColHeadings As String, Optional ByVal CssStyle As String = "SubHeading", Optional ByVal icolspan As Integer = 1, Optional ByVal HorizantalAlign As HorizontalAlign = HorizontalAlign.Center) As TableRow
        Dim temp As Integer = 1
        Dim intHeadingLength As Integer
        Dim tr As New TableRow
        tr.CssClass = CssStyle '"SubHeading"


        For i As Integer = 1 To noOfColoumns
            Dim tc As New TableCell
            tc.HorizontalAlign = HorizantalAlign
            tc.Wrap = False
            tc.ColumnSpan = icolspan
            'If i = 1 Then
            '    tc.Width = Unit.Pixel(150)
            'End If

            intHeadingLength = InStr(1, ColHeadings, ",")
            If intHeadingLength > 0 Then
                tc.Text = ColHeadings.Substring(0, intHeadingLength - 1)
                ColHeadings = ColHeadings.Substring(intHeadingLength)
            Else
                tc.Text = ColHeadings
            End If

            tr.Cells.Add(tc)

        Next

        Return tr

    End Function

    Public Function getTextColoumn(ByVal cssStyle As String, ByVal Text As String, Optional ByVal ColumnSpan As Int64 = 0, Optional ByVal HorizantalAlign As HorizontalAlign = HorizontalAlign.Center, Optional ByVal rowSpan As Integer = 0, Optional ByVal toolTip As String = "") As TableCell

        Dim tc As New TableCell
        tc.ColumnSpan = ColumnSpan
        tc.RowSpan = rowSpan
        tc.ToolTip = toolTip
        tc.HorizontalAlign = HorizantalAlign
        tc.CssClass = cssStyle
        tc.Controls.Add(New LiteralControl(Text))
        Return tc

    End Function

    Private Function getLinkColoumn(ByVal cssStyle As String, ByVal Text As String, ByVal url As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal coloumnSpan As Int16 = 0, Optional ByVal toolTip As String = "") As TableCell

        Dim tc As New TableCell
        Dim hypLi As New HyperLink

        hypLi.Text = Text
        hypLi.NavigateUrl = url
        tc.CssClass = cssStyle
        tc.RowSpan = rowSpan
        tc.ToolTip = toolTip
        tc.ColumnSpan = coloumnSpan
        tc.Controls.Add(hypLi)

        Return tc

    End Function

#End Region

#Region "HTML Allignment Formats GK"     ' 06-05-13

#Region "Left Allignment Formats"

    Public Function DataLeftAllignmentStyle(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink

            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes

            myAttributes.CssStyle.Add("text-align", "left")
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes.CssStyle.Add("color", fcolor)

            myAttributes1.CssStyle.Add("Color", lcolor)

            TLink.Text = iText
            TLink.Width = Unit.Pixel(iwidth)
            TLink.NavigateUrl = pNavigateUrl
            TLink.CssClass = "link"

            tcell.ColumnSpan = icolspan
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            tcell.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            tcell.RowSpan = rowSpan
            tcell.Height = Unit.Pixel(14)
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass

            Return tcell

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DataLeftAllignmentHyperLinkStyle(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("text-align", "left")
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            tcell.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = "javascript:Open_New_Window('" & pNavigateUrl & "')"
            TLink.CssClass = "link"
            tcell.Wrap = False
            tcell.Height = Unit.Pixel(14)
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.CssClass = cssClass
            tcell.Controls.Add(TLink)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DataLeftAllignmentWordWrapStyle(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink

            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes

            myAttributes.CssStyle.Add("text-align", "left")
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes.CssStyle.Add("color", fcolor)

            myAttributes1.CssStyle.Add("Color", lcolor)

            TLink.Text = iText
            TLink.Width = Unit.Pixel(iwidth)
            TLink.NavigateUrl = pNavigateUrl
            TLink.CssClass = "link"

            tcell.ColumnSpan = icolspan
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            tcell.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            tcell.RowSpan = rowSpan
            tcell.Height = Unit.Pixel(14)
            tcell.Wrap = True
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass

            Return tcell

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "Center Allignment Formats"

    Public Function DataCenterAllignmentStyle(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0) As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("text-align", "center")
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            myAttributes.CssStyle.Add("color", fcolor)
            tcell.ColumnSpan = icolspan
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            tcell.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = pNavigateUrl
            tcell.Height = Unit.Pixel(14)
            tcell.RowSpan = rowSpan
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DataCenterAllignmentHyperLinkStyle(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("text-align", "center")
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            tcell.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = "javascript:Open_New_Window('" & pNavigateUrl & "')"
            TLink.CssClass = "link"
            tcell.Wrap = False
            tcell.Height = Unit.Pixel(14)
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.CssClass = cssClass
            tcell.Controls.Add(TLink)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DataCenterAllignmentWordWrapStyle(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink

            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes

            myAttributes.CssStyle.Add("text-align", "center")
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes.CssStyle.Add("color", fcolor)

            myAttributes1.CssStyle.Add("Color", lcolor)

            TLink.Text = iText
            TLink.Width = Unit.Pixel(iwidth)
            TLink.NavigateUrl = pNavigateUrl
            TLink.CssClass = "link"

            tcell.ColumnSpan = icolspan
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            tcell.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            tcell.RowSpan = rowSpan
            tcell.Height = Unit.Pixel(14)
            tcell.Wrap = True
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass

            Return tcell

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "Right Allignment Formats"

    Public Function DataRightAllignmentStyle(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("text-align", "right")
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            TLink.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = pNavigateUrl

            tcell.Height = Unit.Pixel(14)
            tcell.RowSpan = rowSpan
            TLink.CssClass = "link"
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DataRightAllignmentHyperLinkStyle(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("text-align", "right")
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            tcell.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            tcell.Height = Unit.Pixel(14)
            tcell.RowSpan = rowSpan
            TLink.NavigateUrl = "javascript:Open_New_Window('" & pNavigateUrl & "')"
            TLink.CssClass = "link"
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.CssClass = cssClass
            tcell.Controls.Add(TLink)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DataRightAllignmentWordWrapStyle(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal cssClass As String = "") As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            tcell.ColumnSpan = icolspan
            myAttributes.CssStyle.Add("color", fcolor)
            myAttributes.CssStyle.Add("text-align", "right")
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            TLink.Font.Size = FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = pNavigateUrl

            tcell.Height = Unit.Pixel(14)
            tcell.RowSpan = rowSpan
            TLink.CssClass = "link"
            tcell.Wrap = True
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            tcell.CssClass = cssClass
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "Module Level variables"

    Public PUB_BACK1_COLOR As String = "#B8773D" '"#1C9CCD"   

    Public PUB_BACK1FORE_COLOR As String = "WHITE"

    Public PUB_BACK2_COLOR As String = "#A2DCF2"

    Public PUB_BACK2FORE_COLOR As String = "BLACK"

    Public PUB_LEVEL1_COLOR As String = "Red"

    Public PUB_LEVEL2_COLOR As String = "DarkRed"

    Public PUB_LEVEL3_COLOR As String = "Green"

    Public PUB_LEVEL4_COLOR As String = "Blue"

    Public PUB_LEVEL5_COLOR As String = "Black"

    Public PUB_GRANDTOT_COLOR As String = "Green"
    '----------------*-----------------------------------------
    'THIS COLORS ARE USED IN NORMAL REPORT PURPOSE
    Public PUB_HEADBACK_COLOR As String = "PERU"
    Public PUB_HEADFORE_COLOR As String = "WHITE"
    Public PUB_DATABACK_COLOR As String = "#EBDED6"
    Public PUB_DATAFORE_COLOR As String = "#663300"

#End Region


#End Region

    '#Region " * LISTBOX MOVING By Venu"

    '    Public Sub FillListAll(ByVal ListBox_From As ListBox, ByVal ListBox_To As ListBox)
    '        Dim intCounter As Integer = 0

    '        For intCounter = 0 To ListBox_From.Items.Count - 1
    '            ListBox_To.Items.Add(ListBox_From.Items(intCounter))
    '        Next
    '        ListBox_From.Items.Clear()
    '    End Sub

    '    Public Sub FillListSel(ByVal ListBox_From As ListBox, ByVal ListBox_To As ListBox)
    '        Dim intCouter As Integer = 0
    '        Try

    '            If (Not ListBox_From.SelectedItem Is Nothing) Then

    '                Dim itmList As ListItem
    '                For Each itmList In ListBox_From.Items
    '                    If itmList.Selected Then
    '                        ListBox_To.Items.Add(itmList)
    '                    End If
    '                Next

    '                Dim i As Byte = 0
    '                Do
    '                    If ListBox_From.Items(i).Selected = True Then
    '                        ListBox_From.Items.Remove(ListBox_From.Items(i))
    '                    Else
    '                        i = i + 1
    '                    End If
    '                Loop Until (i = ListBox_From.Items.Count)

    '            End If
    '        Catch ex As Exception

    '        End Try

    '    End Sub

    '#End Region

End Module
