'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Board details Report
'   ACTIVITY                          : 
'   AUTHOR                            : ANIL KUMAR PODILI
'   INITIAL BASELINE DATE             : 20-MAR-2013
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Public Class BoardReport_1
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Table4 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Table8 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Table0 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblSecAdopt As System.Web.UI.WebControls.Table
    Protected WithEvents Table7 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Table9 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Table5 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents datebldfrmpicker As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents datebldtopicker As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents datefdrfrmpicker As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents datefdrtopicker As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents ChkBldng As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ChkAfl As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ChkFdr As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ChkCert As System.Web.UI.WebControls.CheckBox
    Protected WithEvents CHKSOCIETY As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblFdrletter As System.Web.UI.WebControls.Label
    Protected WithEvents RdYes As System.Web.UI.WebControls.RadioButton
    Protected WithEvents RdNo As System.Web.UI.WebControls.RadioButton
    Protected WithEvents Chkblddate As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Chkfdrdate As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ChkAffilidate As System.Web.UI.WebControls.CheckBox
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Table121 As System.Web.UI.HtmlControls.HtmlTable
    'Protected WithEvents LstSelDistrict As System.Web.UI.HtmlControls.HtmlSelect
    Protected WithEvents LstDistrict As System.Web.UI.WebControls.ListBox
    Protected WithEvents LstSelDistrict As System.Web.UI.WebControls.ListBox
    Protected WithEvents LstSociety As System.Web.UI.WebControls.ListBox
    Protected WithEvents LstSelSociety As System.Web.UI.WebControls.ListBox
    Protected WithEvents LstYear As System.Web.UI.WebControls.ListBox
    Protected WithEvents LstSelYear As System.Web.UI.WebControls.ListBox
    'Protected WithEvents LstSelSociety As System.Web.UI.HtmlControls.HtmlSelect

    Protected WithEvents bldtodate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Bldfromdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents PNL1 As System.Web.UI.WebControls.Panel
    Protected WithEvents fdrtodate As System.Web.UI.WebControls.TextBox
    Protected WithEvents FDRFROMDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents PNL2 As System.Web.UI.WebControls.Panel
    Protected WithEvents Affilitodate As System.Web.UI.WebControls.TextBox
    Protected WithEvents AFFILFROMDATE As System.Web.UI.WebControls.TextBox
    Protected WithEvents PNL3 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtfilename As System.Web.UI.WebControls.TextBox
    Protected WithEvents CHKYearStart As System.Web.UI.WebControls.CheckBox
    'Protected WithEvents LstSelYear As System.Web.UI.HtmlControls.HtmlSelect
    Protected WithEvents BtnSelDistrict As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelDistrictAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemDistrict As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemDistrictAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelSociety As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelSocietyAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemSociety As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemSocietyAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelYear As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelYearAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemYear As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemYearAll As System.Web.UI.WebControls.ImageButton

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " $ Class Variables"

    Private ObjResult As Utility
    Dim StrSql As String
    Dim DS, DsResult As DataSet
    Dim USERSLNO As Integer
    Dim ObjReport As New ClsBankChallan
    Dim dvresult As New DataView

#End Region

#Region " $ Page Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            FillDistrict()
            FillSociety()
            FillYearofstart()
            PNL1.Visible = False
            PNL2.Visible = False
            PNL3.Visible = False
            Table8.Visible = False
        End If
    End Sub

#End Region

#Region " $ Fill Methods"

    Private Sub FillSociety()
        Try
            StrSql = "SELECT  REGISTERED_NO,SUBSTR(SOCT_NAME,1,20) SOCT_NAME FROM M_SOCIETY_DT ORDER BY  REGISTERED_NO"

            ObjResult = New Utility
            DS = ObjResult.GetCommDataSet(StrSql)

          

            LstSociety.DataSource = DS.Tables(0)
            LstSociety.DataTextField = "SOCT_NAME"
            LstSociety.DataValueField = "REGISTERED_NO"
            LstSociety.DataBind()
            ' selsociety.Items.Insert(0, New ListItem("All", 0))

        Catch ex As Exception
            StartUpScript("", ex.Message)
        End Try
    End Sub

    Private Sub FillYearofstart()
        Try
            StrSql = " SELECT DISTINCT YEAROFSTART   FROM EXAM_BOARDCOLLEGE_MT WHERE  BOARDCORPCOLLSLNO = 1 AND YEAROFSTART IS NOT NULL ORDER BY YEAROFSTART ASC  "

            ObjResult = New Utility
            DS = ObjResult.GetCommDataSet(StrSql)

            LstYear.DataSource = DS.Tables(0)
            LstYear.DataTextField = "YEAROFSTART"
            LstYear.DataValueField = "YEAROFSTART"
            LstYear.DataBind()

        Catch ex As Exception
            StartUpScript("", ex.Message)
        End Try
    End Sub

    Private Sub FillDistrict()
        Try
            StrSql = "SELECT CODE,NAME FROM EXAM_BOARDDIST_MT ORDER BY BOARDDISTSLNO"

            ObjResult = New Utility
            DS = ObjResult.GetCommDataSet(StrSql)

            LstDistrict.DataSource = DS.Tables(0)
            LstDistrict.DataTextField = "NAME"
            LstDistrict.DataValueField = "CODE"
            LstDistrict.DataBind()
            ' seldistrict.Items.Insert(0, New ListItem("Select", 0))

        Catch ex As Exception
            StartUpScript("", ex.Message)
        End Try
    End Sub

#End Region

#Region "ListButtonEvents"
   
#Region "District"
    Protected Sub BtnSelDistrict_Click(sender As Object, e As ImageClickEventArgs) Handles BtnSelDistrict.Click
        Try
            Dim i As Integer
            'SelDistrict = Nothing
            If Not LstDistrict.SelectedItem Is Nothing Then
                For i = 0 To LstDistrict.Items.Count - 1
                    If LstDistrict.Items(i).Selected = True Then
                        LstSelDistrict.Items.Add(LstDistrict.Items(i))
                    End If
                Next
                i = 0
                Do
                    If LstDistrict.Items(i).Selected = True Then
                        LstDistrict.Items.Remove(LstDistrict.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LstDistrict.Items.Count Then Exit Do
                Loop

            End If
        Catch ex As Exception
            StartUpScript(BtnSelDistrict.ID, ex.Message)
        End Try
    End Sub

    Protected Sub BtnSelDistrictAll_Click(sender As Object, e As ImageClickEventArgs) Handles BtnSelDistrictAll.Click
        Try
            Dim iTotItems As Integer = LstDistrict.Items.Count - 1
            Dim i As Integer

            For i = 0 To iTotItems
                LstSelDistrict.Items.Add(LstDistrict.Items(i))
            Next
            LstDistrict.Items.Clear()

        Catch ex As Exception
            StartUpScript(BtnSelDistrictAll.ID, ex.Message)
        End Try
    End Sub

    Protected Sub BtnRemDistrict_Click(sender As Object, e As ImageClickEventArgs) Handles BtnRemDistrict.Click
        Try
            Dim i As Integer
            If Not LstSelDistrict.SelectedItem Is Nothing Then
                For i = 0 To LstSelDistrict.Items.Count - 1
                    If LstSelDistrict.Items(i).Selected = True Then
                        LstDistrict.Items.Add(LstSelDistrict.Items(i))
                    End If
                Next

                i = 0
                Do
                    If LstSelDistrict.Items(i).Selected = True Then
                        LstSelDistrict.Items.Remove(LstSelDistrict.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LstSelDistrict.Items.Count Then Exit Do
                Loop
            End If
        Catch ex As Exception
            StartUpScript(BtnRemDistrict.ID, ex.Message)
        End Try
    End Sub

    Protected Sub BtnRemDistrictAll_Click(sender As Object, e As ImageClickEventArgs) Handles BtnRemDistrictAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = LstSelDistrict.Items.Count - 1

            For i = 0 To iTotItems
                LstDistrict.Items.Add(LstSelDistrict.Items(i))
            Next
            Commonfunctions.ClearListBox(LstSelDistrict)
        Catch ex As Exception
            StartUpScript(BtnRemDistrictAll.ID, ex.Message)
        End Try
    End Sub
#End Region

#Region "Society"

    Protected Sub BtnSelSociety_Click(sender As Object, e As ImageClickEventArgs) Handles BtnSelSociety.Click
        Try
            Dim i As Integer
            'SelDistrict = Nothing
            If Not LstSociety.SelectedItem Is Nothing Then
                For i = 0 To LstSociety.Items.Count - 1
                    If LstSociety.Items(i).Selected = True Then
                        LstSelSociety.Items.Add(LstSociety.Items(i))
                    End If
                Next
                i = 0
                Do
                    If LstSociety.Items(i).Selected = True Then
                        LstSociety.Items.Remove(LstSociety.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LstSociety.Items.Count Then Exit Do
                Loop

            End If
        Catch ex As Exception
            StartUpScript(BtnSelSociety.ID, ex.Message)
        End Try
    End Sub

    Protected Sub BtnSelSocietyAll_Click(sender As Object, e As ImageClickEventArgs) Handles BtnSelSocietyAll.Click
        Try
            Dim iTotItems As Integer = LstSociety.Items.Count - 1
            Dim i As Integer

            For i = 0 To iTotItems
                LstSelSociety.Items.Add(LstSociety.Items(i))
            Next
            LstSociety.Items.Clear()

        Catch ex As Exception
            StartUpScript(BtnSelSocietyAll.ID, ex.Message)
        End Try
    End Sub

    Protected Sub BtnRemSociety_Click(sender As Object, e As ImageClickEventArgs) Handles BtnRemSociety.Click
        Try
            Dim i As Integer
            If Not LstSelSociety.SelectedItem Is Nothing Then
                For i = 0 To LstSelSociety.Items.Count - 1
                    If LstSelSociety.Items(i).Selected = True Then
                        LstSociety.Items.Add(LstSelSociety.Items(i))
                    End If
                Next

                i = 0
                Do
                    If LstSelSociety.Items(i).Selected = True Then
                        LstSelSociety.Items.Remove(LstSelSociety.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LstSelSociety.Items.Count Then Exit Do
                Loop
            End If
        Catch ex As Exception
            StartUpScript(BtnRemSociety.ID, ex.Message)
        End Try
    End Sub

    Protected Sub BtnRemSocietyAll_Click(sender As Object, e As ImageClickEventArgs) Handles BtnRemSocietyAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = LstSelSociety.Items.Count - 1

            For i = 0 To iTotItems
                LstSociety.Items.Add(LstSelSociety.Items(i))
            Next
            Commonfunctions.ClearListBox(LstSelSociety)
        Catch ex As Exception
            StartUpScript(BtnRemSocietyAll.ID, ex.Message)
        End Try
    End Sub

#End Region

#Region "Year of Start"
    Protected Sub BtnSelYear_Click(sender As Object, e As ImageClickEventArgs) Handles BtnSelYear.Click
        Try
            Dim i As Integer
            'SelDistrict = Nothing
            If Not LstYear.SelectedItem Is Nothing Then
                For i = 0 To LstYear.Items.Count - 1
                    If LstYear.Items(i).Selected = True Then
                        LstSelSociety.Items.Add(LstYear.Items(i))
                    End If
                Next
                i = 0
                Do
                    If LstYear.Items(i).Selected = True Then
                        LstYear.Items.Remove(LstYear.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LstYear.Items.Count Then Exit Do
                Loop

            End If
        Catch ex As Exception
            StartUpScript(BtnSelYear.ID, ex.Message)
        End Try
    End Sub

    Protected Sub BtnSelYearAll_Click(sender As Object, e As ImageClickEventArgs) Handles BtnSelYearAll.Click
        Try
            Dim iTotItems As Integer = LstYear.Items.Count - 1
            Dim i As Integer

            For i = 0 To iTotItems
                LstSelYear.Items.Add(LstYear.Items(i))
            Next
            LstYear.Items.Clear()

        Catch ex As Exception
            StartUpScript(BtnSelYearAll.ID, ex.Message)
        End Try
    End Sub

    Protected Sub BtnRemYear_Click(sender As Object, e As ImageClickEventArgs) Handles BtnRemYear.Click
        Try
            Dim i As Integer
            If Not LstSelYear.SelectedItem Is Nothing Then
                For i = 0 To LstSelYear.Items.Count - 1
                    If LstSelYear.Items(i).Selected = True Then
                        LstYear.Items.Add(LstSelYear.Items(i))
                    End If
                Next

                i = 0
                Do
                    If LstSelYear.Items(i).Selected = True Then
                        LstSelYear.Items.Remove(LstSelYear.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LstSelYear.Items.Count Then Exit Do
                Loop
            End If
        Catch ex As Exception
            StartUpScript(BtnRemYear.ID, ex.Message)
        End Try
    End Sub

    Protected Sub BtnRemYearAll_Click(sender As Object, e As ImageClickEventArgs) Handles BtnRemYearAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = LstSelYear.Items.Count - 1

            For i = 0 To iTotItems
                LstYear.Items.Add(LstSelYear.Items(i))
            Next
            Commonfunctions.ClearListBox(LstSelYear)
        Catch ex As Exception
            StartUpScript(BtnRemYearAll.ID, ex.Message)
        End Try
    End Sub
#End Region
#End Region

#Region " $ Common Methods"

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")
        Try
            If focusCtrl <> "" And strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & FormName & "." & focusCtrl & " == '[object]') { document." & FormName & "." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf focusCtrl <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & FormName & "." & focusCtrl & " == '[object]') { document." & FormName & "." & focusCtrl & ".focus(); } </script>")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " $ Common Methods"

    Private Function FormValidations() As Boolean
        Try
            If LstSelDistrict.Items.Count = 0 Then
                StartUpScript("", "Select Atleast One District.")
                Return False
            ElseIf LstSelSociety.Items.Count = 0 Then
                StartUpScript("", "Select Atleast One Society.")
                Return False
            ElseIf LstSelYear.Items.Count = 0 Then
                StartUpScript("", "Select Atleast One Date")
                Return False

                'ElseIf LstSelSociety.Value = "" Then
                'ElseIf Chkfdrdate.Checked = True And FDRFROMDATE.Text = "" And todate.Text = "" Then
                '    StartUpScript("", "Enter FromDate")
                '    Return False
                'ElseIf ChkFdr.Checked = False And Chkfdrdate.Checked = True Then
                '    StartUpScript("", "Enter FromDate")
                '    Return False
                'ElseIf ChkFdr.Checked = False And Chkfdrdate.Checked = True Then
                '    StartUpScript("", "select Fdr Deltails Also ")
                '    Return False
                'ElseIf ChkBldng.Checked = False And Chkblddate.Checked = True Then
                '    StartUpScript("", "select Building Deltails Also")
                '    Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

#Region " $ Printing Styles"

    Public Function HypFontStylestyleNew(ByVal iText As String, ByVal iId As String, ByVal icolspan As Integer, ByVal iOrdtxt As String, ByVal iordtyp As String, ByVal pNavigateUrl As String, ByVal TCellWidth As Integer) As TableCell

        Dim TCell As New TableCell
        Dim myStrIF As String
        Dim TLink As New System.Web.UI.WebControls.HyperLink
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "white")
        TLink.Text = iText
        TLink.ForeColor = Color.Green
        TLink.NavigateUrl = pNavigateUrl '"Secwisestudentanalysis.aspx?ORD=" + iOrdtxt + "&ORDSTR=" + iordtyp
        'myAttributes.CssStyle.Add("onClick", "return hs.expand(this)")
        TLink.Attributes("onclick") = "return hs.expand(this)"
        TCell.Controls.Add(TLink)
        TCell.ID = iId
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.Font.Bold = True
        TCell.ColumnSpan = icolspan
        TCell.Height = Unit.Pixel(25)
        TCell.Width = Unit.Pixel(TCellWidth)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Center
        TCell.VerticalAlign = VerticalAlign.Middle

        


        Return TCell
    End Function

    Public Function ExpirEnteredstyle(ByVal iText As String, ByVal colspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "EBDED6")
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.Text = iText
        TCell.CssClass = "GridItem"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ToolTip = itooltip
        TCell.ColumnSpan = colspan
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleMulRequest(ByVal iText As String, ByVal icolspan As Integer, ByVal RAlign As String, ByVal ColType As Integer, ByVal itooltip As String, ByVal Param As String, ByVal frmName As String, ByVal ifrmHeight As Integer, ByVal ifrmWidth As Integer) As TableCell
        Dim TCell As New TableCell
        ' Dim TLink As New System.Web.UI.WebControls.HyperLink
        If iText = "." Then
            TCell.Text = ""
        Else
            Dim myStrIF, CellTxt, CalStr As String
            Dim CalNum, IfrHt As Integer
            'Total(0),Subtotal(1),General(2)
            If ColType = 0 Then
                CellTxt = "<font color='#FF0000'>" + iText + "</font>"
            ElseIf ColType = 1 Then
                CellTxt = "<font color='#FF00FF'>" + iText + "</font>"
            ElseIf ColType = 2 Then
                CellTxt = "<font color='#0000FF'>" + iText + "</font>"
            End If
            CalNum = Trim(iText).Length
            If CalNum = 9 Or CalNum = 10 Or Trim(Left(iText, 1)) = "(" Then
                CalStr = iText.Replace("(", "") : CalStr = CalStr.Replace(")", "") : CalNum = Val(CalStr)
            ElseIf CalNum < 9 Or CalNum > 13 Then
                CalNum = Val(Trim(Left(iText, 8)))
            End If
            'TLink.NavigateUrl = "../BoardSection/Popcertificate.aspx?image1="
            '"<iframe src=*D:\335-POSANI.jpg* height=*300* width=*700* frameborder=*1* vspace=*0* hspace=*0* marginwidth=*0* marginheight=*0* noresize></iframe>" & _
            ' HtmlExapnd with Iframe
            myStrIF = "<div><A class=*branchlinks* href=*#* onclick=*return hs.htmlExpand(this,{ headingText: 'NARAYANA ' })*>" + CellTxt + "</A>" & _
            "<div class=*highslide-maincontent*>" & _
            "<img src=*" & frmName.ToString & "*  alt=**/></div></div>"

            myStrIF = myStrIF.Replace("*", """")

            Dim myAttributes As AttributeCollection = TCell.Attributes : myAttributes.CssStyle.Add("background-color", "#EBDED6")
            TCell.Text = myStrIF : TCell.ToolTip = itooltip + " Entered" : TCell.Font.Size = FontUnit.XSmall : TCell.Font.Name = "Courier New" : TCell.ColumnSpan = icolspan : TCell.ForeColor = Color.Blue : TCell.Wrap = False

            If RAlign = "M" Then
                TCell.HorizontalAlign = HorizontalAlign.Center
            ElseIf RAlign = "R" Then
                TCell.HorizontalAlign = HorizontalAlign.Right
            ElseIf RAlign = "L" Then
                TCell.HorizontalAlign = HorizontalAlign.Left
            End If
            TCell.VerticalAlign = VerticalAlign.Middle
        End If

        Return TCell
    End Function

#End Region

#Region " $ CHECKBOX"

    Private Sub Chkblddate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkblddate.CheckedChanged
        Try
            If Chkblddate.Checked = True Then
                PNL1.Visible = True
            Else
                If Chkblddate.Checked = False Then
                    PNL1.Visible = False
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Chkfdrdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkfdrdate.CheckedChanged
        Try
            If Chkfdrdate.Checked = True Then
                PNL2.Visible = True
            Else
                If Chkfdrdate.Checked = False Then
                    PNL2.Visible = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ChkAffilidate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAffilidate.CheckedChanged
        Try
            If ChkAffilidate.Checked = True Then
                PNL3.Visible = True
            Else
                If ChkAffilidate.Checked = False Then
                    PNL3.Visible = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region " $ PRINTING"

    Private Sub ReportFormatAllNew()
        Try
            Dim TRow1 As New TableRow
            Dim TRow2 As New TableRow
            Dim TRowH As New TableRow
            Dim TRowH1 As New TableRow
            Dim View As HyperLinkColumn
            Dim EBSTU() As DataRow
            Dim Mitem, Msort As String
            Dim EBTOTAL, Mnumb, C, DvTotal As Integer
            Dim Mperc As Double
            Dim SLNO As Integer = 0
            Dim i, j, Col As Integer
            Dim MSlno As Integer = 0
            Dim Targethd As String
            TRowH.Cells.Add(Headingstyle(lblHeading.Text, 44))
            TRowH1.Cells.Add(Headingstyle("", 3))
            TRowH1.Cells.Add(Headingstyle("COLLEGE CODE", 2))
            TRowH1.Cells.Add(Headingstyle("SEC.CNT", 1))
            If CHKYearStart.Checked = True Then
                TRowH1.Cells.Add(Headingstyle("Year Of Start", 1))
            End If

            If CHKSOCIETY.Checked = True Then
                TRowH1.Cells.Add(Headingstyle("SOCIETY NAME", 1))
            End If
            If ChkBldng.Checked = True Then
                TRowH1.Cells.Add(Headingstyle(" BUILDING(DETAILS)", 2))
                TRowH1.Cells.Add(Headingstyle(" PLAYGROUND", 2))
            End If
            If ChkAfl.Checked = True Then
                TRowH1.Cells.Add(Headingstyle("AFIILATION", 2))
                TRowH1.Cells.Add(Headingstyle("SHIFTING", 1))

            End If
            If ChkFdr.Checked = True Then
                TRowH1.Cells.Add(Headingstyle("FDR DETAILS", 9))
            End If
            If ChkCert.Checked = True Then
                TRowH1.Cells.Add(Headingstyle("CERTIFICATES DETAILS", 32))
            End If

            tblSecAdopt.Rows.Add(TRowH)
            tblSecAdopt.Rows.Add(TRowH1)
            TRow1.Cells.Add(Headingstyle("Sno.", 1))
            TRow1.Cells.Add(Headingstyle("District", 1))
            TRow1.Cells.Add(Headingstyle("College Name", 1))
            TRow1.Cells.Add(Headingstyle("New code", 1))
            TRow1.Cells.Add(Headingstyle("Old Code", 1))
            TRow1.Cells.Add(Headingstyle(" ", 1))

            If CHKYearStart.Checked = True Then
                TRow1.Cells.Add(Headingstyle(" ", 1))
            End If

            If CHKSOCIETY.Checked = True Then
                TRow1.Cells.Add(Headingstyle(" ", 1))
            End If
            If ChkBldng.Checked = True Then
                TRow1.Cells.Add(Headingstyle("Area(SFT)", 1))
                TRow1.Cells.Add(Headingstyle("Building Expiry", 1))
                TRow1.Cells.Add(Headingstyle("FromDate", 1))
                TRow1.Cells.Add(Headingstyle("ToDate", 1))
            End If
            If ChkAfl.Checked = True Then
                TRow1.Cells.Add(Headingstyle("Affiliation", 1))
                TRow1.Cells.Add(Headingstyle("Addl.Sections", 1))
                TRow1.Cells.Add(Headingstyle("", 1))
            End If
            If ChkFdr.Checked = True Then
                TRow1.Cells.Add(Headingstyle("Number", 1))
                TRow1.Cells.Add(Headingstyle("Accountno", 1))
                TRow1.Cells.Add(Headingstyle("Date", 1))
                TRow1.Cells.Add(Headingstyle("Amount", 1))
                TRow1.Cells.Add(Headingstyle("Maturity Date", 1))
                TRow1.Cells.Add(Headingstyle("Maturity Amount", 1))
                TRow1.Cells.Add(Headingstyle("Bankname", 1))
                TRow1.Cells.Add(Headingstyle("Interest", 1))
                TRow1.Cells.Add(Headingstyle("Released", 1))
            End If
            If ChkCert.Checked = True Then
                TRow1.Cells.Add(Headingstyle("Fire.Cert", 1))
                TRow1.Cells.Add(Headingstyle("Fire.Subm", 1))
                TRow1.Cells.Add(Headingstyle("Fire.ValFrom", 1))
                TRow1.Cells.Add(Headingstyle("Fire.ValTo", 1))
                'TRow1.Cells.Add(Headingstyle("View", 1))
                TRow1.Cells.Add(Headingstyle("N.O.C.Cert", 1))
                TRow1.Cells.Add(Headingstyle("N.O.C.Subm", 1))
                TRow1.Cells.Add(Headingstyle("N.O.C.ValFrom", 1))
                TRow1.Cells.Add(Headingstyle("N.O.C.ValTo", 1))
                'TRow1.Cells.Add(Headingstyle("View", 1))
                TRow1.Cells.Add(Headingstyle("Sanitary.Cert", 1))
                TRow1.Cells.Add(Headingstyle("Sanitary.Subm", 1))
                TRow1.Cells.Add(Headingstyle("Sanitary.ValFrom", 1))
                TRow1.Cells.Add(Headingstyle("Sanitary.ValTo", 1))
                'TRow1.Cells.Add(Headingstyle("View", 1))
                TRow1.Cells.Add(Headingstyle("Structural.Cert", 1))
                TRow1.Cells.Add(Headingstyle("Structural.Subm", 1))
                TRow1.Cells.Add(Headingstyle("Structural.ValFrom", 1))
                TRow1.Cells.Add(Headingstyle("Structural.ValTo", 1))
                'TRow1.Cells.Add(Headingstyle("View", 1))
                TRow1.Cells.Add(Headingstyle("Affiliation.Cert", 1))
                TRow1.Cells.Add(Headingstyle("Affiliation.Subm", 1))
                TRow1.Cells.Add(Headingstyle("Affiliation.ValFrom", 1))
                TRow1.Cells.Add(Headingstyle("Affiliation.ValTo", 1))
                'TRow1.Cells.Add(Headingstyle("View", 1))
                TRow1.Cells.Add(Headingstyle("Addl.Sections.Cert", 1))
                TRow1.Cells.Add(Headingstyle("Addl.Sections.Subm", 1))
                TRow1.Cells.Add(Headingstyle("Addl.Sections.ValFrom", 1))
                TRow1.Cells.Add(Headingstyle("Addl.Sections.ValTo", 1))
                'TRow1.Cells.Add(Headingstyle("View", 1))
                TRow1.Cells.Add(Headingstyle("Reg.LeesDeed.Cert", 1))
                TRow1.Cells.Add(Headingstyle("Reg.LeesDeed.Subm", 1))
                TRow1.Cells.Add(Headingstyle("Reg.LeesDeed.ValFrom", 1))
                TRow1.Cells.Add(Headingstyle("Reg.LeesDeed.ValTo", 1))
                'TRow1.Cells.Add(Headingstyle("View", 1))
                TRow1.Cells.Add(Headingstyle("FDR.Cert", 1))
                TRow1.Cells.Add(Headingstyle("FDR.Subm", 1))
                TRow1.Cells.Add(Headingstyle("FDR.ValFrom", 1))
                TRow1.Cells.Add(Headingstyle("FDR.ValTo", 1))
                'TRow1.Cells.Add(Headingstyle("View", 1))
            End If
            tblSecAdopt.Rows.Add(TRow1)

            For E As Integer = 0 To dvresult.Count - 1
                Dim TRow As New TableRow
                Dim Mstn As Integer
                Dim MEnt As Integer
                Dim strsydat As Date = dvresult(E)("SYSDAT")
                Dim Mtxt1, Mtxt2, Mtxt3, Mtxt4, Mtxt5, Mtxt6, Mtxt7, Mtxt8, Mtxt9, Mtxt10, Mtxt11, Mtxt12, Mtxt13, Mtxt14, Mtxt15, Mtxt16, Mtxt17, Mtxt18, Mtxt19, Mtxt20, Mtxt21, Mtxt22, Mtxt23, Mtxt24, Mtxt25 As String
                Dim Mtxt26, Mtxt27, Mtxt28, Mtxt29, Mtxt30, Mtxt31, Mtxt32, Mtxt33, Mtxt34, Mtxt35, Mtxt36, Mtxt37, Mtxt38, Mtxt39, Mtxt40, Mtxt41, Mtxt42, Mtxt43, Mtxt44, Mtxt45, Mtxt46, Mtxt47, Mtxt48, Mtxt49 As String
                Dim Mtxt50, Mtxt51, Mtxt52, Mtxt53, Mtxt54, Mtxt55, Mtxt56, Mtxt57, Mtxt58, Mtxt59, Mtxt60, Mtxt61, Mtxt62, Mtxt63, Mtxt64, Mtxt65, Mtxt66, Mtxt67, Mtxt68, Mtxt69, Mtxt70 As String
                MSlno += 1
                SLNO = SLNO + 1
                Mtxt1 = " "
                Mtxt2 = " "
                Mtxt3 = " "
                Mtxt4 = " "
                Mtxt5 = " "
                Mtxt6 = " "
                Mtxt7 = " "
                Mtxt8 = " "
                Mtxt9 = " "
                Mtxt10 = " "
                Mtxt11 = " "
                Mtxt12 = " "
                Mtxt13 = " "
                Mtxt14 = " "
                Mtxt15 = " "
                Mtxt16 = " "
                Mtxt17 = " "
                Mtxt18 = " "
                Mtxt19 = " "
                Mtxt20 = ""
                Mtxt21 = " "
                Mtxt22 = " "
                Mtxt23 = " "
                Mtxt24 = " "
                Mtxt25 = " "
                Mtxt26 = " "
                Mtxt27 = " "
                Mtxt28 = " "
                Mtxt29 = " "
                Mtxt30 = " "
                Mtxt31 = " "
                Mtxt32 = " "
                Mtxt33 = " "
                Mtxt34 = " "
                Mtxt35 = " "
                Mtxt36 = " "
                Mtxt37 = " "
                Mtxt38 = " "
                Mtxt39 = " "
                Mtxt40 = " "
                Mtxt41 = " "
                Mtxt42 = " "
                Mtxt43 = " "
                Mtxt44 = " "
                Mtxt45 = " "
                Mtxt50 = " "
                Mtxt51 = " "
                Mtxt52 = " "
                Mtxt53 = " "
                Mtxt54 = " "
                Mtxt55 = " "
                Mtxt56 = " "
                Mtxt57 = " "
                Mtxt58 = " "
                Mtxt59 = " "
                Mtxt60 = " "
                Mtxt61 = " "
                Mtxt62 = " "
                Mtxt63 = " "
                Mtxt64 = " "
                Mtxt65 = " "
                Mtxt66 = " "
                Mtxt67 = " "
                Mtxt68 = " "
                Mtxt69 = " "

                If Not IsDBNull(dvresult(E)("DISTNAME")) Then Mtxt23 = dvresult(E)("DISTNAME")
                If Not IsDBNull(dvresult(E)("NAME")) Then Mtxt1 = dvresult(E)("NAME")
                If Not IsDBNull(dvresult(E)("CODE")) Then Mtxt2 = dvresult(E)("CODE")
                If Not IsDBNull(dvresult(E)("OLDCODE")) Then Mtxt3 = dvresult(E)("OLDCODE")
                If Not IsDBNull(dvresult(E)("GRANDTOTAL")) Then Mtxt24 = dvresult(E)("GRANDTOTAL")

                If CHKYearStart.Checked = True Then
                    If Not IsDBNull(dvresult(E)("YEAROFSTART")) Then Mtxt25 = dvresult(E)("YEAROFSTART")
                End If
                If CHKSOCIETY.Checked = True Then
                    If Not IsDBNull(dvresult(E)("SOCT_NAME")) Then Mtxt4 = dvresult(E)("SOCT_NAME")
                End If
                If ChkBldng.Checked = True Then
                    If Not IsDBNull(dvresult(E)("PLINTH_AREA")) Then Mtxt5 = dvresult(E)("PLINTH_AREA")
                    If Not IsDBNull(dvresult(E)("BLD_RL_PERIOD_TO")) Then Mtxt6 = dvresult(E)("BLD_RL_PERIOD_TO")
                    If Not IsDBNull(dvresult(E)("PG_RL_PERIOD_FROM")) Then Mtxt46 = dvresult(E)("PG_RL_PERIOD_FROM")
                    If Not IsDBNull(dvresult(E)("PG_RL_PERIOD_TO")) Then Mtxt47 = dvresult(E)("PG_RL_PERIOD_TO")
                End If
                If ChkAfl.Checked = True Then
                    If Not IsDBNull(dvresult(E)("AFFYEAR")) Then Mtxt7 = dvresult(E)("AFFYEAR")
                    If Not IsDBNull(dvresult(E)("AFFEXTDUPTO")) Then Mtxt8 = dvresult(E)("AFFEXTDUPTO")
                    If Not IsDBNull(dvresult(E)("SHIFTING")) Then Mtxt9 = dvresult(E)("SHIFTING")
                End If
                If ChkFdr.Checked = True Then
                    If Not IsDBNull(dvresult(E)("FDRNO")) Then Mtxt10 = dvresult(E)("FDRNO")
                    If Not IsDBNull(dvresult(E)("FDRACNO".ToString)) Then Mtxt11 = dvresult(E)("FDRACNO".ToString)
                    If Not IsDBNull(dvresult(E)("FDRDATE")) Then Mtxt12 = dvresult(E)("FDRDATE")
                    If Not IsDBNull(dvresult(E)("AMOUNT")) Then Mtxt13 = dvresult(E)("AMOUNT")
                    If Not IsDBNull(dvresult(E)("FDRMATURITY_DATE")) Then Mtxt14 = dvresult(E)("FDRMATURITY_DATE")
                    If Not IsDBNull(dvresult(E)("MATURITY_AMT")) Then Mtxt15 = dvresult(E)("MATURITY_AMT")
                    If Not IsDBNull(dvresult(E)("FDRBANK")) Then Mtxt16 = dvresult(E)("FDRBANK")
                    If Not IsDBNull(dvresult(E)("RATEOF_INT")) Then Mtxt17 = dvresult(E)("RATEOF_INT")
                    If Not IsDBNull(dvresult(E)("FDRRELEASE")) Then Mtxt18 = dvresult(E)("FDRRELEASE")
                End If

                If ChkCert.Checked = True Then

                    If Not IsDBNull(dvresult(E)("FIRECERT")) Then Mtxt26 = dvresult(E)("FIRECERT")
                    If Not IsDBNull(dvresult(E)("FIRESUB")) Then Mtxt27 = dvresult(E)("FIRESUB")
                    If Not IsDBNull(dvresult(E)("FIRFROM")) Then Mtxt28 = dvresult(E)("FIRFROM")
                    If Not IsDBNull(dvresult(E)("FIRTO")) Then Mtxt29 = dvresult(E)("FIRTO")
                    ' If Not IsDBNull(dvresult(E)("FIREPATH")) Then Mtxt30 = dvresult(E)("FIREPATH")
                    'If Not IsDBNull(dvresult(E)("FIREPATH")) Then Mtxt30 = dvresult(E)("CODE") + 1

                    If Not IsDBNull(dvresult(E)("SANITORYCERT")) Then Mtxt31 = dvresult(E)("SANITORYCERT")
                    If Not IsDBNull(dvresult(E)("SANITORYSUB")) Then Mtxt32 = dvresult(E)("SANITORYSUB")
                    If Not IsDBNull(dvresult(E)("SANITORYFROM")) Then Mtxt33 = dvresult(E)("SANITORYFROM")
                    If Not IsDBNull(dvresult(E)("SANTO")) Then Mtxt34 = dvresult(E)("SANTO")
                    ' If Not IsDBNull(dvresult(E)("SANITORYPATH")) Then Mtxt35 = dvresult(E)("SANITORYPATH")
                    'If Not IsDBNull(dvresult(E)("SANITORYPATH")) Then Mtxt35 = dvresult(E)("CODE") + 2


                    If Not IsDBNull(dvresult(E)("NOCCERT")) Then Mtxt36 = dvresult(E)("NOCCERT")
                    If Not IsDBNull(dvresult(E)("NOCSUB")) Then Mtxt37 = dvresult(E)("NOCSUB")
                    If Not IsDBNull(dvresult(E)("NOCFROM")) Then Mtxt38 = dvresult(E)("NOCFROM")
                    If Not IsDBNull(dvresult(E)("NOCTO")) Then Mtxt39 = dvresult(E)("NOCTO")
                    'If Not IsDBNull(dvresult(E)("NOCPATH")) Then Mtxt40 = dvresult(E)("NOCPATH")
                    'If Not IsDBNull(dvresult(E)("NOCPATH")) Then Mtxt40 = dvresult(E)("CODE") + 3


                    If Not IsDBNull(dvresult(E)("STRUCTURALSLNO")) Then Mtxt41 = dvresult(E)("STRUCTURALSLNO")
                    If Not IsDBNull(dvresult(E)("STRUCTURALSUB")) Then Mtxt42 = dvresult(E)("STRUCTURALSUB")
                    If Not IsDBNull(dvresult(E)("STRUCTURALFROM")) Then Mtxt43 = dvresult(E)("STRUCTURALFROM")
                    If Not IsDBNull(dvresult(E)("STRUCTURALTO")) Then Mtxt44 = dvresult(E)("STRUCTURALTO")
                    'If Not IsDBNull(dvresult(E)("STRUCTURALPATH")) Then Mtxt45 = dvresult(E)("STRUCTURALPATH")
                    'If Not IsDBNull(dvresult(E)("STRUCTURALPATH")) Then Mtxt45 = dvresult(E)("CODE") + 4

                    If Not IsDBNull(dvresult(E)("AFFACADAMICSLNO")) Then Mtxt50 = dvresult(E)("AFFACADAMICSLNO")
                    If Not IsDBNull(dvresult(E)("AFFACADAMICSUB")) Then Mtxt51 = dvresult(E)("AFFACADAMICSUB")
                    If Not IsDBNull(dvresult(E)("AFFFROM")) Then Mtxt52 = dvresult(E)("AFFFROM")
                    If Not IsDBNull(dvresult(E)("AFFTO")) Then Mtxt53 = dvresult(E)("AFFTO")
                    'If Not IsDBNull(dvresult(E)("AFFPATH")) Then Mtxt54 = dvresult(E)("AFFPATH")

                    If Not IsDBNull(dvresult(E)("ADDISECTIONSLNO")) Then Mtxt55 = dvresult(E)("ADDISECTIONSLNO")
                    If Not IsDBNull(dvresult(E)("ADDISECTIONSUB")) Then Mtxt56 = dvresult(E)("ADDISECTIONSUB")
                    If Not IsDBNull(dvresult(E)("SECFROM")) Then Mtxt57 = dvresult(E)("SECFROM")
                    If Not IsDBNull(dvresult(E)("SECTO")) Then Mtxt58 = dvresult(E)("SECTO")
                    'If Not IsDBNull(dvresult(E)("SECTIONSPATH")) Then Mtxt59 = dvresult(E)("SECTIONSPATH")

                    If Not IsDBNull(dvresult(E)("REGLEASEDEEDSLNO")) Then Mtxt60 = dvresult(E)("REGLEASEDEEDSLNO")
                    If Not IsDBNull(dvresult(E)("REGLEASEDEEDSUB")) Then Mtxt61 = dvresult(E)("REGLEASEDEEDSUB")
                    If Not IsDBNull(dvresult(E)("LEASEFROM")) Then Mtxt62 = dvresult(E)("LEASEFROM")
                    If Not IsDBNull(dvresult(E)("LEASETO")) Then Mtxt63 = dvresult(E)("LEASETO")
                    'If Not IsDBNull(dvresult(E)("LEASEPATH")) Then Mtxt64 = dvresult(E)("LEASEPATH")

                    If Not IsDBNull(dvresult(E)("FDRSLNO")) Then Mtxt65 = dvresult(E)("FDRSLNO")
                    If Not IsDBNull(dvresult(E)("FDRSUB")) Then Mtxt66 = dvresult(E)("FDRSUB")
                    If Not IsDBNull(dvresult(E)("FDRFROM")) Then Mtxt67 = dvresult(E)("FDRFROM")
                    If Not IsDBNull(dvresult(E)("FDRTO")) Then Mtxt68 = dvresult(E)("FDRTO")
                    ' If Not IsDBNull(dvresult(E)("FDRPATH")) Then Mtxt69 = dvresult(E)("FDRPATH")

                End If
                TRow.Cells.Add(Enteredstyle(SLNO.ToString, 1, ""))
                TRow.Cells.Add(SideHeadingstyle(Mtxt23, "", 1))
                TRow.Cells.Add(SideHeadingstyle(Mtxt1, "", 1))
                TRow.Cells.Add(RightAlignstyle(Mtxt2, 1, ""))
                TRow.Cells.Add(RightAlignstyle(Mtxt3, 1, ""))
                TRow.Cells.Add(RightAlignstyle(Mtxt24, 1, ""))

                If CHKYearStart.Checked = True Then
                    TRow.Cells.Add(RightAlignstyle(Mtxt25, 1, ""))
                End If

                If CHKSOCIETY.Checked = True Then
                    TRow.Cells.Add(SideHeadingstyle(Mtxt4, "", 1))
                End If
                If ChkBldng.Checked = True Then
                    TRow.Cells.Add(RightAlignstyle(Mtxt5, 1, ""))

                    If Mtxt6 = " " Then
                        TRow.Cells.Add(RightAlignstyle(Mtxt6, 1, ""))
                    ElseIf Mtxt6 > strsydat Then
                        TRow.Cells.Add(RightAlignstyle(Mtxt6, 1, ""))
                    Else
                        TRow.Cells.Add(ExpirEnteredstyle(Mtxt6, 1, "DateExpired"))
                    End If

                    'TRow.Cells.Add(RightAlignstyle(Mtxt6, 1, ""))
                    TRow.Cells.Add(RightAlignstyle(Mtxt46, 1, ""))
                    'Expiry Date  Checking
                    If Mtxt47 = "" Then
                        TRow.Cells.Add(RightAlignstyle(Mtxt47, 1, ""))
                    ElseIf Mtxt47 > strsydat Then
                        TRow.Cells.Add(RightAlignstyle(Mtxt47, 1, ""))
                    Else
                        TRow.Cells.Add(ExpirEnteredstyle(Mtxt47, 1, "DateExpired"))
                    End If

                End If

                If ChkAfl.Checked = True Then
                    TRow.Cells.Add(RightAlignstyle(Mtxt7, 1, ""))
                    TRow.Cells.Add(RightAlignstyle(Mtxt8, 1, ""))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt9, "", 1))
                    'TRow.Cells.Add(SideHeadingstyle("", "", 1))
                End If
                If ChkFdr.Checked = True Then
                    TRow.Cells.Add(RightAlignstyle(Mtxt10, 1, "FDRNO"))
                    TRow.Cells.Add(RightAlignstyle(Mtxt11, 1, "FDR ACCOUNT NUMBER"))
                    TRow.Cells.Add(RightAlignstyle(Mtxt12, 1, "FDR DATE"))
                    TRow.Cells.Add(RightAlignstyle(Mtxt13, 1, "FDR DEPOSITED AMOUNT"))
                    TRow.Cells.Add(RightAlignstyle(Mtxt14, 1, "FDR MATURITY DATE"))
                    TRow.Cells.Add(RightAlignstyle(Mtxt15, 1, "FDR MATURITY AMT"))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt16, "", 1))
                    TRow.Cells.Add(RightAlignstyle(Mtxt17, 1, "RATE OF INTEREST"))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt18, "", 1))
                End If

                If ChkCert.Checked = True Then
                    TRow.Cells.Add(SideHeadingstyle(Mtxt26, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt27, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt28, "", 1))

                    If Mtxt29 = " " Then
                        TRow.Cells.Add(SideHeadingstyle(Mtxt29, "", 1))
                    ElseIf Mtxt29 < strsydat Then
                        TRow.Cells.Add(ExpirEnteredstyle(Mtxt29, 1, "DateExpired"))
                    Else
                        TRow.Cells.Add(SideHeadingstyle(Mtxt29, "", 1))
                    End If
                    'TRow.Cells.Add(SideHeadingstyle(Mtxt30, "", 1))
                    'If Mtxt30 = " " Then
                    '    TRow.Cells.Add(SideHeadingstyle(Mtxt30, "", 1))
                    'Else
                    '    TRow.Cells.Add(EnteredstyleMulRequest("View", 1, "", 1, "", "", Mtxt30, 200, 700))
                    'End If

                    TRow.Cells.Add(SideHeadingstyle(Mtxt31, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt32, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt33, "", 1))

                    If Mtxt34 = " " Then
                        TRow.Cells.Add(SideHeadingstyle(Mtxt34, "", 1))
                    ElseIf Mtxt34 < strsydat Then
                        TRow.Cells.Add(ExpirEnteredstyle(Mtxt34, 1, "DateExpired"))
                    Else
                        TRow.Cells.Add(SideHeadingstyle(Mtxt34, "", 1))
                    End If

                    'If Mtxt35 = " " Then
                    '    TRow.Cells.Add(SideHeadingstyle(Mtxt35, "", 1))
                    'Else
                    '    TRow.Cells.Add(EnteredstyleMulRequest("View", 1, "", 1, "", "", Mtxt35, 200, 700))
                    'End If

                    'TRow.Cells.Add(SideHeadingstyle(Mtxt35, "", 1))
                    'TRow.Cells.Add(EnteredstyleMulRequest("view", "", 1, "", "", Mtxt35, 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt36, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt37, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt38, "", 1))

                    If Mtxt39 = " " Then
                        TRow.Cells.Add(SideHeadingstyle(Mtxt39, "", 1))
                    ElseIf Mtxt39 < strsydat Then
                        TRow.Cells.Add(ExpirEnteredstyle(Mtxt39, 1, "DateExpired"))
                    Else
                        TRow.Cells.Add(SideHeadingstyle(Mtxt39, "", 1))
                    End If

                    'If Mtxt40 = " " Then
                    '    TRow.Cells.Add(SideHeadingstyle(Mtxt40, "", 1))
                    'Else
                    '    TRow.Cells.Add(EnteredstyleMulRequest("View", 1, "", 1, "", "", Mtxt40, 200, 700))
                    'End If

                    'TRow.Cells.Add(SideHeadingstyle(Mtxt40, "", 1))
                    'TRow.Cells.Add(HypFontStylestyleNew("view", "", 1, "", "", Mtxt40, 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt41, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt42, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt43, "", 1))

                    If Mtxt44 = " " Then
                        TRow.Cells.Add(SideHeadingstyle(Mtxt44, "", 1))
                    ElseIf Mtxt44 < strsydat Then
                        TRow.Cells.Add(ExpirEnteredstyle(Mtxt44, 1, "DateExpired"))
                    Else
                        TRow.Cells.Add(SideHeadingstyle(Mtxt44, "", 1))
                    End If

                    'If Mtxt45 = " " Then
                    '    TRow.Cells.Add(SideHeadingstyle(Mtxt45, "", 1))
                    'Else
                    '    TRow.Cells.Add(EnteredstyleMulRequest("View", 1, "", 1, "", "", Mtxt45, 200, 700))
                    'End If

                    'TRow.Cells.Add(SideHeadingstyle(Mtxt45, "", 1))
                    'TRow.Cells.Add(HypFontStylestyleNew("view", "", 1, "", "", Mtxt45, 1))

                    'AFFILIATION ACADEMIC
                    TRow.Cells.Add(SideHeadingstyle(Mtxt50, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt51, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt52, "", 1))

                    If Mtxt53 = " " Then
                        TRow.Cells.Add(SideHeadingstyle(Mtxt53, "", 1))
                    ElseIf Mtxt53 < strsydat Then
                        TRow.Cells.Add(ExpirEnteredstyle(Mtxt53, 1, "DateExpired"))
                    Else
                        TRow.Cells.Add(SideHeadingstyle(Mtxt53, "", 1))
                    End If

                    'If Mtxt54 = " " Then
                    '    TRow.Cells.Add(SideHeadingstyle(Mtxt54, "", 1))
                    'Else
                    '    TRow.Cells.Add(EnteredstyleMulRequest("View", 1, "", 1, "", "", Mtxt54, 200, 700))
                    'End If

                    'ADDITIONAL SECTIONS
                    TRow.Cells.Add(SideHeadingstyle(Mtxt55, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt56, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt57, "", 1))

                    If Mtxt58 = " " Then
                        TRow.Cells.Add(SideHeadingstyle(Mtxt58, "", 1))
                    ElseIf Mtxt58 < strsydat Then
                        TRow.Cells.Add(ExpirEnteredstyle(Mtxt58, 1, "DateExpired"))
                    Else
                        TRow.Cells.Add(SideHeadingstyle(Mtxt58, "", 1))
                    End If

                    'If Mtxt59 = " " Then
                    '    TRow.Cells.Add(SideHeadingstyle(Mtxt59, "", 1))
                    'Else
                    '    TRow.Cells.Add(EnteredstyleMulRequest("View", 1, "", 1, "", "", Mtxt59, 200, 700))
                    'End If

                    'REGISTERD LEES DEED
                    TRow.Cells.Add(SideHeadingstyle(Mtxt60, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt61, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt62, "", 1))

                    If Mtxt63 = " " Then
                        TRow.Cells.Add(SideHeadingstyle(Mtxt63, "", 1))
                    ElseIf Mtxt63 < strsydat Then
                        TRow.Cells.Add(ExpirEnteredstyle(Mtxt63, 1, "DateExpired"))
                    Else
                        TRow.Cells.Add(SideHeadingstyle(Mtxt63, "", 1))
                    End If

                    'If Mtxt64 = " " Then
                    '    TRow.Cells.Add(SideHeadingstyle(Mtxt64, "", 1))
                    'Else
                    '    TRow.Cells.Add(EnteredstyleMulRequest("View", 1, "", 1, "", "", Mtxt64, 200, 700))
                    'End If

                    'FDR
                    TRow.Cells.Add(SideHeadingstyle(Mtxt65, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt66, "", 1))
                    TRow.Cells.Add(SideHeadingstyle(Mtxt67, "", 1))

                    If Mtxt68 = " " Then
                        TRow.Cells.Add(SideHeadingstyle(Mtxt68, "", 1))
                    ElseIf Mtxt68 < strsydat Then
                        TRow.Cells.Add(ExpirEnteredstyle(Mtxt68, 1, "DateExpired"))
                    Else
                        TRow.Cells.Add(SideHeadingstyle(Mtxt68, "", 1))
                    End If

                    'If Mtxt69 = " " Then
                    '    TRow.Cells.Add(SideHeadingstyle(Mtxt69, "", 1))
                    'Else
                    '    TRow.Cells.Add(EnteredstyleMulRequest("View", 1, "", 1, "", "", Mtxt69, 200, 700))
                    'End If

                End If
                tblSecAdopt.Rows.Add(TRow)

            Next
        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)
            StartUpScript(iBtnSave.ID, " Transaction  Failed ")

        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                StartUpScript(iBtnSave.ID, " Transaction  Failed ")

            End If
        End Try
    End Sub


#End Region

#Region " $ BUTTONS"

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Try
            If FormValidations() Then
                Session("USERSLNO") = USERSLNO
                DsResult = New DataSet
                ObjReport = New ClsBankChallan
                Dim Strdistrict, strsociety, strblddate, strfdrdate, strrelease As String
                Dim i As Integer
                If RdYes.Checked = True Then
                    strrelease = " And FDRRELEASE = 1  "
                ElseIf RdNo.Checked = True Then
                    strrelease = " And FDRRELEASE = 2  "
                End If
                'If LstSelDistrict.Items.Count > 0 Then
                '    Strdistrict = " AND  MBDIST.CODE IN ("
                '    For i = 0 To LstSelDistrict.Items.Count - 1
                '        If LstSelDistrict.Items(i).Selected = True Then
                '            Strdistrict &= Val(LstSelDistrict.Items(i).Value.ToString) & ","
                '        End If
                '    Next
                '    Strdistrict &= " 0) "
                'End If

                If LstSelDistrict.Items.Count > 0 Then
                    Strdistrict &= " AND MBDIST.CODE IN ("
                    For i = 0 To LstSelDistrict.Items.Count - 1
                        Strdistrict &= Val(LstSelDistrict.Items(i).Value.ToString) & IIf(i = LstSelDistrict.Items.Count - 1, ")", ",")
                    Next
                End If


                If LstSelSociety.Items.Count > 0 Then
                    strsociety &= " AND SOCT.REGISTERED_NO IN ("
                    For i = 0 To LstSelSociety.Items.Count - 1
                        strsociety &= Val(LstSelSociety.Items(i).Value.ToString) & IIf(i = LstSelSociety.Items.Count - 1, ")", ",")
                    Next
                End If

                'If LstSelSociety.Items.Count > 0 Then
                '    strsociety = "AND SOCT.REGISTERED_NO IN ("
                '    For i = 0 To LstSelSociety.Items.Count - 1
                '        If LstSelSociety.Items(i).Selected = True Then
                '            strsociety &= Val(LstSelSociety.Items(i).Value.ToString) & ", "
                '        End If
                '    Next
                '    strsociety &= " 0) "
                'End If

                Dim strdatefilter, strdatefilter1, strdatefilter2, stryear As String
                If Chkblddate.Checked Then
                    If Bldfromdate.Text = "" Then
                        strdatefilter = " AND  (BLIDG.BLD_RL_PERIOD_TO IS NULL OR BLIDG.BLD_RL_PERIOD_TO<='" & ReportDateConversion(Trim(bldtodate.Text)) & "') "
                    Else
                        strdatefilter = " AND  BLIDG.BLD_RL_PERIOD_TO  BETWEEN  '" & ReportDateConversion(Trim(Bldfromdate.Text)) & "' AND  '" & ReportDateConversion(Trim(bldtodate.Text)) & "' "
                    End If
                End If
                If Chkfdrdate.Checked Then
                    If FDRFROMDATE.Text = "" Then
                        strdatefilter1 = " AND  (FDR.MATURITY_DATE IS NULL OR FDR.MATURITY_DATE <='" & ReportDateConversion(Trim(fdrtodate.Text)) & "') "
                    Else
                        strdatefilter1 = " AND FDR.MATURITY_DATE  BETWEEN  '" & ReportDateConversion(Trim(FDRFROMDATE.Text)) & "' AND  '" & ReportDateConversion(Trim(fdrtodate.Text)) & "' "
                    End If
                End If
                If ChkAffilidate.Checked Then
                    If AFFILFROMDATE.Text = "" Then
                        strdatefilter2 = " AND  (AFF.AFFYEAR IS NULL OR AFF.AFFYEAR <='" & ReportDateConversion(Trim(Affilitodate.Text)) & "') "
                    Else
                        strdatefilter2 = " AND AFF.AFFYEAR  BETWEEN  '" & Trim(AFFILFROMDATE.Text) & "' AND  '" & Trim(Affilitodate.Text) & "' "

                    End If
                End If

                If LstSelYear.Items.Count > 0 Then
                    stryear &= " AND MB.YEAROFSTART IN ("
                    For i = 0 To LstSelYear.Items.Count - 1
                        stryear &= "'" & Val(LstSelYear.Items(i).Value.ToString) & "'" & IIf(i = LstSelYear.Items.Count - 1, ")", ",")
                    Next
                End If

                'If LstSelYear.Items.Count > 0 Then
                '    stryear = "AND MB.YEAROFSTART IN ("
                '    For i = 0 To LstSelYear.Items.Count - 1
                '        If LstSelYear.Items(i).Selected = True Then
                '            stryear &= "'" & LstSelYear.Items(i).Text.ToString & "',"
                '        End If
                '    Next
                '    stryear = stryear.Remove(stryear.Length - 1, 1) + ")"
                'End If


                strdatefilter = strdatefilter + strdatefilter1 + strdatefilter2
                DsResult = ObjReport.COLLEGEINFONEW(Strdistrict, strsociety, strdatefilter, strrelease)
                'DsResult = ObjReport.COLLEGEINFONEW(Strdistrict, strsociety, strdatefilter, strrelease, stryear)
                Table8.Visible = True
                Table4.Visible = False
                dvresult = DsResult.Tables(0).DefaultView

                If DsResult.Tables(0).Rows.Count = 0 Then
                    StartUpScript("", "No records Found")
                Else
                    tblSecAdopt.Visible = True
                    ReportFormatAllNew()

                End If
                'Dim Script_Str As String
                'Script_Str = "<script language='javascript'>excelExp('tblSecAdopt','BOARD');</script>"

                'RegisterStartupScript("JavaScript", Script_Str)


                txtfilename.Text = "D:\CollegeBoard.xlsx"
                'Dim Tr As TableRow
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region

End Class

