Imports CollegeBoardDLL

Public Class AcademicYearExambranchBoardcollegeMapping
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblBatch As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents iBtnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnBatchMode As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnCancel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents txtSetfocus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMessage As System.Web.UI.WebControls.TextBox
    Protected WithEvents drpBranchSearch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpAcaSlno As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgGridBatch As System.Web.UI.WebControls.DataGrid

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

    Private objBoardEnrollment As ClsBoardEnrollment
    Private ClsUty As Utility
    Private DsSearchResult As DataSet
    Public From As String
    Public Str, StrSql As String
    Private Edit As String
    Private DsSearch As DataSet
    Public PageIndex As Integer
    Public SLNO, USERSLNO, RtnVal As Integer
    Private objError As clsError
    Private DsFiles As New DataSet

#End Region

#Region "Load Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dgGridBatch.AllowPaging = True
            USERSLNO = Session("USERSLNO")
            From = Request.QueryString("From")
            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                ButtonsHiding(Me.Page)
                If Not Request.QueryString("SLNO") Is Nothing AndAlso Request.QueryString("SLNO") <> "" Then SLNO = Request.QueryString("SLNO")
                Me.ViewState("SLNO") = SLNO


                If Not Request.QueryString("PageIndex") Is Nothing AndAlso Request.QueryString("PageIndex") <> "" Then
                    PageIndex = CInt(Request.QueryString("PageIndex"))
                Else
                    PageIndex = 0
                End If


                Me.ViewState("PageIndex") = PageIndex
                BranchComboFill()
                FillAcademiyears()
                FillGrid(PageIndex)

            Else
                PageIndex = CInt(Me.ViewState("PageIndex"))
            End If
        Catch Oex As OracleException
            'StartUpScript("", DataBaseErrorMessage(Oex.Message))
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
                    'StartUpScript("", GeneralErrorMessage(ex.Message))
                End If
            End If
        End Try
    End Sub

#End Region

#Region "Fill Methods"

    Private Sub BranchComboFill()
        Try
            Dim DS As DataSet
            ClsUty = New Utility
            DS = ClsUty.FillUserWise_ExamBranch(USERSLNO, Session("COMACADEMICSLNO"))
            drpBranchSearch.DataSource = DS
            drpBranchSearch.DataTextField = "EXAMBRANCHNAME"
            drpBranchSearch.DataValueField = "EXAMBRANCHSLNO"
            drpBranchSearch.DataBind()

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillAcademiyears()
        Try
            Dim dsAcaYr As DataSet
            ClsUty = New Utility
            dsAcaYr = ClsUty.DataSet_Fetch("SELECT COMACADEMICSLNO,NAME FROM T_COMPANYACADEMICYEAR_MT")
            If dsAcaYr.Tables(0).Rows.Count > 0 Then
                drpAcaSlno.DataSource = dsAcaYr
                drpAcaSlno.DataTextField = "NAME"
                drpAcaSlno.DataValueField = "COMACADEMICSLNO"
                drpAcaSlno.DataBind()
            End If
            drpAcaSlno.SelectedValue = Session("COMACADEMICSLNO")
        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillGrid(ByVal PageIndex As Integer)

        Dim i, j As Integer
        Try

            objBoardEnrollment = New ClsBoardEnrollment

            Dim DsSearchResult As DataSet
            Dim Sqlstr As String
            ClsUty = New Utility
            Sqlstr = "SELECT 0 BESLNO, MAP.BOARDCOLACASLNO, DST.NAME DIST, COL.CODE CODE, COL.COLLEGENAME COLLNAME,EB.EXAMBRANCHNAME EBNAME  FROM EXAM_BC_EB_ACADEMIC_MT MAP, EXAM_BOARDCOLLEGE_MT COL, EXAM_BOARDDIST_MT DST, EXAM_EXAMBRANCH EB " & _
                     " WHERE MAP.BOARDCOLLEGESLNO = COL.BOARDCOLLEGESLNO And MAP.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND COL.BOARDDISTSLNO = DST.BOARDDISTSLNO AND MAP.COMACADEMICSLNO = " & drpAcaSlno.SelectedValue & " AND EB.EXAMBRANCHSLNO=" & drpBranchSearch.SelectedValue

            DsSearchResult = ClsUty.DataSet_Fetch(Sqlstr)

            Me.ViewState("DataSet") = DsSearchResult

            If Not DsSearchResult Is Nothing Then
                j = 1
                For i = 0 To DsSearchResult.Tables(0).Rows.Count - 1
                    DsSearchResult.Tables(0).Rows(i)("BESLNO") = j
                    j += 1
                Next
                '' Setting Page Indexs
                If (DsSearchResult.Tables(0).Rows.Count - 1) / 10 < PageIndex Then

                    If ((DsSearchResult.Tables(0).Rows.Count - 1) / 10) <= 1 Then
                        PageIndex = 0
                    Else
                        PageIndex = PageIndex - 1
                    End If
                End If

                dgGridBatch.CurrentPageIndex = PageIndex
                dgGridBatch.DataSource = DsSearchResult
                dgGridBatch.DataBind()
                Me.ViewState("DsSearchResult") = DsSearchResult
            End If
        Catch ex As Exception
            objError = New clsError
            StartUpScript(Me.ID, objError.errHandler(ex))
        End Try

    End Sub

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")

        Try
            If focusCtrl <> "" And strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.TopicDetails." & focusCtrl & " == '[object]') { document.TopicDetails." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf focusCtrl <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.TopicDetails." & focusCtrl & " == '[object]') { document.TopicDetails." & focusCtrl & ".focus(); } </script>")
            Else

            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Button Events"

    Private Sub iBtnBatchMode_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnBatchMode.Click
        Try

            Response.Redirect("AcaEbBrdColMapBatch.aspx?EBNO=" & drpBranchSearch.SelectedValue & "&ACANO=" & drpAcaSlno.SelectedValue)
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                StartUpScript(iBtnBatchMode.ID, " Transaction  Failed ")
            End If
        End Try

    End Sub

    Private Sub iBtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnGo.Click

        FillGrid(0)

    End Sub

#End Region

#Region "Grid Events"

    Private Sub dgGridBatch_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGridBatch.DeleteCommand
        Try
            objBoardEnrollment = New ClsBoardEnrollment
            RtnVal = objBoardEnrollment.P_AcaEbCol_Delete(Val(dgGridBatch.Items(e.Item.ItemIndex).Cells(1).Text))
            If RtnVal = 1 Then
                FillGrid(PageIndex)
                StartUpScript("", "Record Deleted Successfully")
            Else
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
    Private Sub dgGridBatch_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgGridBatch.PageIndexChanged
        Try
            dgGridBatch.CurrentPageIndex = e.NewPageIndex
            Me.ViewState("PageIndex") = e.NewPageIndex

            PageIndex = Me.ViewState("PageIndex")
            DsSearchResult = Me.ViewState("DsSearchResult")
            dgGridBatch.DataSource = DsSearchResult
            dgGridBatch.DataBind()
        Catch ex As Exception
            objError = New clsError
            StartUpScript(dgGridBatch.ID, objError.errHandler(ex))
        End Try
    End Sub

#End Region

End Class
