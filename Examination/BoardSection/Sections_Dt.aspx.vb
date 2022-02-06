'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Master of Sections form
'   AUTHOR                            : KISHORE
'   INITIAL BASELINE DATE             : 22 Dec 2011
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Web.Services.Protocols
Imports CollegeBoardDLL
Imports System.Data.OracleClient
Imports CommonDLL
Imports System.Math
Public Class Sections_Dt
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtlblCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents iBtnAdd As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Table4 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtorgSci As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtorgarts As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents txtorgtot As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents txtaddsci As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtaddarts As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtaddtot As System.Web.UI.WebControls.TextBox
    Protected WithEvents imgBtnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Txtccode As System.Web.UI.WebControls.TextBox
    Protected WithEvents LBLCLGNAME As System.Web.UI.WebControls.Label
    Protected WithEvents dgGridSection As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtgtotal As System.Web.UI.WebControls.TextBox
    Protected WithEvents Imagebutton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lstmCode As System.Web.UI.WebControls.TextBox
    'Protected WithEvents lstmCode As System.Web.UI.HtmlControls.HtmlSelect

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
    Private objMaster As ClsBoarddt
    Private objMas As Masters
    Private ObjResult As Utility
    Private DsSearchResult As DataSet
    Public From As String
    Public Str, StrSql As String
    Private DsSearch, DsResult As DataSet
    Public PageIndex As Integer
    Public SLNO, MNO, RtnVal As Integer
    Private FormName As String = "Form1"
    Private MODE As String
    Private objReport As Utility
    Dim DSet As New DataSet
#End Region

#Region "Common Methods"

    Protected Sub DeleteConformationMessage(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        Try
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Dim btn As Button = CType(e.Item.Cells(5).Controls(0), Button)
                    btn.Attributes.Add("onclick", "return confirm('Are you sure to delete this record ?')")
                    Exit Select
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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

#Region "Methods"

    Private Function SetEntries() As ArrayList
        Try
            Dim Arr As New ArrayList

            If Me.ViewState("MODE") = "NEW" Then
                Arr.Add(Val(Txtccode.Text))
                Arr.Add(Val(txtorgSci.Text))
                Arr.Add(Val(txtorgarts.Text))
                Arr.Add(Val(txtorgtot.Text))
                Arr.Add(Val(txtaddsci.Text))
                Arr.Add(Val(txtaddarts.Text))
                Arr.Add(Val(txtaddtot.Text))
                Arr.Add(Val(txtgtotal.Text))
                Arr.Add(Val(MNO))
            ElseIf Me.ViewState("MODE") = "EDIT" Then
                Arr.Add(Val(Trim(Me.ViewState("SLNO"))))
                Arr.Add(Val(Txtccode.Text))
                Arr.Add(Val(txtorgSci.Text))
                Arr.Add(Val(txtorgarts.Text))
                Arr.Add(Val(txtorgtot.Text))
                Arr.Add(Val(txtaddsci.Text))
                Arr.Add(Val(txtaddarts.Text))
                Arr.Add(Val(txtaddtot.Text))
                Arr.Add(Val(txtgtotal.Text))
                Arr.Add(Val(MNO))
            End If

            Return Arr

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub FillControls()
        Try

            Dim DsGA As DataSet
            DsGA = New DataSet
            objMaster = New ClsBoarddt


            DsGA = objMaster.Secction_Select(SLNO)

            If DsGA.Tables(0).Rows.Count > 0 Then

                Txtccode.Text = DsGA.Tables(0).Rows(0)("CCODE").ToString
                LBLCLGNAME.Text = DsGA.Tables(0).Rows(0)("COLLEGENAME").ToString
                txtorgSci.Text = DsGA.Tables(0).Rows(0)("ORG_SCIENCE_SEC").ToString
                txtorgarts.Text = DsGA.Tables(0).Rows(0)("ORG_ARTS_SEC").ToString
                txtorgtot.Text = DsGA.Tables(0).Rows(0)("ORG_TOTAL_SEC").ToString
                txtaddsci.Text = DsGA.Tables(0).Rows(0)("ADD_SCIENCE_SEC").ToString
                txtaddarts.Text = DsGA.Tables(0).Rows(0)("ADD_ARTS_SEC").ToString
                txtaddtot.Text = DsGA.Tables(0).Rows(0)("ADD_TOTAL_SEC").ToString
                txtgtotal.Text = DsGA.Tables(0).Rows(0)("GRANDTOTAL").ToString
            Else

            End If

        Catch Oex As Exception
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ClearControls()
        Try
            Txtccode.Text = ""
            txtorgSci.Text = ""
            txtorgarts.Text = ""
            txtorgtot.Text = ""
            txtaddsci.Text = ""
            txtaddarts.Text = ""
            txtaddtot.Text = ""
            txtgtotal.Text = ""
           

        Catch ex As Exception

        End Try

    End Sub

    Private Function FormValidations() As Boolean
        Try
            If Trim(txtorgSci.Text) = "" Or Trim(txtorgSci.Text) Is Nothing Then
                StartUpScript("txtregno", "Enter Original Science Sections.")
                Return False
            ElseIf Trim(txtorgarts.Text) = "" Or Trim(txtorgarts.Text) Is Nothing Then
                StartUpScript("txtorgarts", "Enter Original Arts Sections.")
                Return False
            ElseIf Trim(txtorgtot.Text) = "" Or Trim(txtorgtot.Text) Is Nothing Then
                StartUpScript("txtorgtot", "Enter Original Total Sections.")
                Return False

            ElseIf Trim(txtaddsci.Text) = "" Or Trim(txtaddsci.Text) Is Nothing Then
                StartUpScript("txtaddsci", "Enter Additinal Science Sections.")
                Return False

            ElseIf Trim(txtaddarts.Text) = "" Or Trim(txtaddarts.Text) Is Nothing Then
                StartUpScript("txtaddarts", "Enter Additinal Arts Sections.")
                Return False

            ElseIf Trim(txtaddtot.Text) = "" Or Trim(txtaddtot.Text) Is Nothing Then
                StartUpScript("txtaddtot", "Enter Applying Science Sections.")
                Return False

            ElseIf Trim(txtgtotal.Text) = "" Or Trim(txtgtotal.Text) Is Nothing Then
                StartUpScript("txtappsci", "Enter Grand Total.")
                Return False



            End If
            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub SetViewStateVariables()
        Try
            If Not Request.QueryString("MODE") Is Nothing Then MODE = Request.QueryString("MODE")
            If Not Request.QueryString("SLNO") Is Nothing Then SLNO = Request.QueryString("SLNO")
            If Not Request.QueryString("MNO") Is Nothing Then MNO = Request.QueryString("MNO")
            If Not Request.QueryString("PageIndex") Is Nothing Then PageIndex = Request.QueryString("PageIndex")

            Me.ViewState("MODE") = MODE
            Me.ViewState("SLNO") = SLNO
            Me.ViewState("MNO") = MNO
            Me.ViewState("PageIndex") = PageIndex

            If MNO = 1 Then
                lblHeading.Text = "Society Details&nbsp;"
                'Else
                '   lblHeading.Text = "Death&nbsp;Cause&nbsp;(Single Mode)"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetViewStateVariables()
        Try
            MODE = Me.ViewState("MODE")
            SLNO = Me.ViewState("SLNO")
            MNO = Me.ViewState("MNO")

            PageIndex = Me.ViewState("PageIndex")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Fill Methods"

    Private Sub FillGrid(ByVal PageIndex As Integer)
        Dim i, j As Integer
        Dim SqlStr1 As String

        Try
            If lstmCode.Text <> "" Then

                'For m As Integer = 0 To lstmCode.Items.Count - 1
                '    If lstmCode.Items(m).Selected Then
                '        SqlStr1 += lstmCode.Items(m).Value + ","
                '    End If
                'Next
                'SqlStr1 = SqlStr1.TrimEnd(",")

                StrSql = "SELECT SEC.SECSLNO,SEC.CCODE,CLG.COLLEGENAME FROM  M_SECTIONS_DT SEC,EXAM_BOARDCOLLEGE_MT CLG WHERE SEC.CCODE=CLG.CODE AND SEC.CCODE = " & lstmCode.Text & " ORDER BY SEC.CCODE"
                'If Txtccode1.Text <> "" Then
                'StrSql = "SELECT SEC.SECSLNO,SEC.CCODE,CLG.COLLEGENAME FROM  M_SECTIONS_DT SEC,EXAM_BOARDCOLLEGE_MT CLG WHERE SEC.CCODE=CLG.CODE AND SEC.CCODE= " & Txtccode1.Text & " ORDER BY SEC.CCODE"
            Else
                StrSql = "SELECT SEC.SECSLNO,SEC.CCODE,CLG.COLLEGENAME FROM  M_SECTIONS_DT SEC,EXAM_BOARDCOLLEGE_MT CLG WHERE SEC.CCODE=CLG.CODE ORDER BY SEC.CCODE"
            End If


            ObjResult = New Utility

            DsSearchResult = ObjResult.DataSet_OneFetch(StrSql)

            Me.ViewState("DsSearchResult") = DsSearchResult

            If Not DsSearchResult Is Nothing Then
                '' Setting Page Indexs
                If (DsSearchResult.Tables(0).Rows.Count - 1) / 10 < PageIndex Then

                    If ((DsSearchResult.Tables(0).Rows.Count - 1) / 10) <= 1 Then
                        PageIndex = 0
                    Else
                        PageIndex = PageIndex - 1
                    End If
                End If

                dgGridSection.CurrentPageIndex = PageIndex
                dgGridSection.DataSource = DsSearchResult
                dgGridSection.DataBind()

                Me.ViewState("DsSearchResult") = DsSearchResult
            End If
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub FillTitle()
        lblHeading.Text = "Society Dtails  "
    End Sub

    'Private Sub MultiFillCode()
    '    Try
    '        Dim SqlStr As String
    '        Dim I As Integer

    '        SqlStr = "SELECT SEC.CCODE FROM  M_SECTIONS_DT SEC,EXAM_BOARDCOLLEGE_MT CLG WHERE SEC.CCODE=CLG.CODE ORDER BY SEC.CCODE"
    '        objReport = New Utility
    '        DSet = objReport.DataSet_OneFetch(SqlStr)
    '        lstmCode.DataSource = DSet.Tables(0)
    '        lstmCode.DataTextField = "CCODE"
    '        lstmCode.DataValueField = "CCODE"
    '        lstmCode.DataBind()

    '        lstmCode.

    '    Catch ex As Exception

    '    End Try

    'End Sub

#End Region

#Region "Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Try
            dgGridSection.AllowPaging = True
            From = Request.QueryString("From")

            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                ButtonsHiding(Me.Page)
                'SLNO, MNO
                'If Not Request.QueryString("SLNO") Is Nothing AndAlso Request.QueryString("SLNO") <> "" Then SLNO = Request.QueryString("SLNO")
                'Me.ViewState("SLNO") = SLNO

                'If Not Request.QueryString("MNO") Is Nothing AndAlso Request.QueryString("MNO") <> "" Then MNO = Request.QueryString("MNO")
                'Me.ViewState("MNO") = MNO

                'If Not Request.QueryString("PageIndex") Is Nothing AndAlso Request.QueryString("PageIndex") <> "" Then
                '    PageIndex = CInt(Request.QueryString("PageIndex"))
                'Else
                '    PageIndex = 0
                'End If

                Me.ViewState("PageIndex") = PageIndex

                'SetViewStateVariables()

                If Me.ViewState("MODE") = "EDIT" Then
                    FillControls()
                End If
                'StartUpScript(txtregno.ID, "")
                FillGrid(PageIndex)
                'MultiFillCode()
                Table4.Visible = False
            Else
                PageIndex = dgGridSection.CurrentPageIndex
                GetViewStateVariables()
                'MODE = "NEW"
                PageIndex = CInt(Me.ViewState("PageIndex"))
            End If

        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
            If Session("USERID") Is Nothing Then
                OracleLogFile("USERID := " & "SRIHARI" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            Else
                OracleLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            End If
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                If Not Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                    "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                    StartUpScript("", GeneralErrorMessage(ex.Message))
                End If
            End If
        End Try
    End Sub

    Private Sub iBtnCancel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            'Response.Write("<script language=Javascript>Javascript:window.open('../../welcome.htm','MainTextPart');</script>")
            Table4.Visible = False
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                'StartUpScript(iBtnCancel.ID, " Transaction  Failed ")
            End If
        End Try
    End Sub

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Try

            If Not FormValidations() Then Exit Sub
            objMaster = New ClsBoarddt

            If (Me.ViewState("MODE")) = "EDIT" Then
                RtnVal = objMaster.Secction_Update(SetEntries())
                If RtnVal = 1 Then
                    StartUpScript(iBtnSave.ID, "Record Updated Successfully.")
                    ClearControls()
                    FillGrid(PageIndex)
                    Table4.Visible = False

                Else
                    StartUpScript(iBtnSave.ID, "Record Not Updated.")
                End If
            ElseIf (Me.ViewState("MODE")) = "NEW" Then
                'ElseIf FLAG = Val(1) Then
                RtnVal = objMaster.Secction_Insert(SetEntries())
                If RtnVal = 1 Then
                    StartUpScript(iBtnSave.ID, "Record Saved Successfully.")
                    ClearControls()
                    FillGrid(PageIndex)
                    Table4.Visible = False
                Else
                    StartUpScript(iBtnSave.ID, "Record Not Saved.")
                End If

            End If

        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
            If Session("USERID") Is Nothing Then
                OracleLogFile("USERID := " & "SRIHARI" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            Else
                OracleLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            End If
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
                If Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & "ADMIN" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                     "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                Else
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                     "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                End If
            End If
        End Try
    End Sub

    Private Sub iBtnAdd_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnAdd.Click
        Try
            Me.ViewState("MODE") = "NEW"
            Table4.Visible = True
            ClearControls()
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                StartUpScript(iBtnAdd.ID, " Transaction  Failed ")
            End If
        End Try
    End Sub

    Private Sub imgBtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnGo.Click
        Try

            If Trim(Txtccode.Text) <> "" Then
                GenerateSqlQuery()
                'If rdbyes.Checked = True Then
                '    FillGrid(PageIndex)
                'Else
                '    FillGrid_dt(PageIndex)
                'End If

            Else
                'StartUpScript(txtempid.ID, "Given Employee ID is Not Existed ")

                Exit Sub
            End If

        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
            If Session("USERID") Is Nothing Then
                OracleLogFile("USERID := " & "SRIHARI" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            Else
                OracleLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            End If
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
                If Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & "ADMIN" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                     "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                Else
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                     "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                End If
            End If
        End Try
    End Sub

    Private Sub imgBtnGoo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            FillGrid(PageIndex)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Sql Query"

    Private Sub GenerateSqlQuery()
        Try

            Dim SqlStr, SqlStr1 As String
            Dim I As Integer

            SqlStr = "SELECT COLLEGENAME FROM EXAM_BOARDCOLLEGE_MT WHERE CODE=" & Val(Txtccode.Text)

            ObjResult = New Utility

            DsResult = ObjResult.DataSet_Fetch(SqlStr)
            If DsResult.Tables(0).Rows.Count > 0 Then
                LBLCLGNAME.Text = DsResult.Tables(0).Rows(0)("COLLEGENAME")

                Session("DsResult") = DsResult.Tables(0)
            Else
                StartUpScript("", " Given College Code is Not Existed")

            End If

        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)
            StartUpScript("", " Transaction  Failed ")

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)
            StartUpScript("", " Transaction  Failed ")

        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
            StartUpScript("", " Transaction  Failed ")


        End Try
    End Sub

#End Region

#Region "Grid Events"

    Private Sub dgGridSection_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGridSection.EditCommand
        Try
            '  Response.Redirect("ExamTargerMappingSingleMode.aspx?MODE=EDIT&SLNO=" & dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text & "&PageIndex=" & CStr(PageIndex) & "")
            Me.ViewState("MODE") = "EDIT"
            SLNO = Val(dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text)
            Me.ViewState("SLNO") = SLNO
            Table4.Visible = True
            ClearControls()
            FillControls()
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                If Not Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                    "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                    StartUpScript("", GeneralErrorMessage(ex.Message))
                End If
            End If
        End Try
    End Sub

    Private Sub dgGridSection_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGridSection.DeleteCommand
        Try
            objMaster = New ClsBoarddt
            RtnVal = objMaster.Secction_DELETE(dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text)

            If RtnVal = 1 Then
                FillGrid(PageIndex)
                StartUpScript("", "Record Deleted Successfully")
            Else
            End If
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
            If Session("USERID") Is Nothing Then
                OracleLogFile("USERID := " & "SRIHARI" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            Else
                OracleLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            End If
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                If Not Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                    "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                    StartUpScript("", GeneralErrorMessage(ex.Message))
                End If
            End If
        End Try
    End Sub

    Private Sub dgGridSection_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgGridSection.PageIndexChanged
        Try
            dgGridSection.CurrentPageIndex = e.NewPageIndex
            Me.ViewState("PageIndex") = e.NewPageIndex
            DsSearchResult = Me.ViewState("DsSearchResult")
            dgGridSection.DataSource = DsSearchResult
            dgGridSection.DataBind()
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                If Not Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                    "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                    StartUpScript("", GeneralErrorMessage(ex.Message))
                End If
            End If
        End Try
    End Sub

    'Private Sub dgGridSection_DetailsCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
    '    Try
    '        '  Response.Redirect("ExamTargerMappingSingleMode.aspx?MODE=EDIT&SLNO=" & dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text & "&PageIndex=" & CStr(PageIndex) & "")
    '        Me.ViewState("MODE") = "EDIT"
    '        SLNO = Val(dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text)
    '        Me.ViewState("SLNO") = SLNO
    '        Table4.Visible = True
    '        ClearControls()
    '        FillControls()
    '    Catch ex As Exception
    '        If GeneralErrorMessage(ex.Message) <> "" Then
    '            If Not Session("USERID") Is Nothing Then
    '                IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
    '                "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
    '                StartUpScript("", GeneralErrorMessage(ex.Message))
    '            End If
    '        End If
    '    End Try
    'End Sub

    Public Sub DoView(ByVal sender As Object, ByVal e As DataGridCommandEventArgs)
        Try

            If (e.CommandName = "Detail") Then
                SLNO = Val(dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text)
                Me.ViewState("SLNO") = SLNO
                Table4.Visible = True
                ClearControls()
                FillControls()
            End If


        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then

                If Not Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                    "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                    StartUpScript("", GeneralErrorMessage(ex.Message))
                End If
            End If

        End Try

    End Sub

#End Region


    

    Private Sub Imagebutton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Imagebutton1.Click
        Try
            FillGrid(PageIndex)
        Catch ex As Exception

        End Try
    End Sub
End Class
