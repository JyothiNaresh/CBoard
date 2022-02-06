Imports CollegeBoardDLL
Public Class AcaEbBrdColMapBatch
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblCourse As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnCancel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents txtSetfocus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMessage As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents DgColl As System.Web.UI.WebControls.DataGrid
    Protected WithEvents drpBranchSearch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpDist As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpAcaSlno As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSearch As System.Web.UI.WebControls.TextBox
    Protected WithEvents IbtnSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Ibtngo As System.Web.UI.WebControls.ImageButton

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
    Private USERSLNO, EBNO, ACANO As Integer
    Dim ClsUty As New Utility
    Public PageIndex As Integer
    Private dsACEBCOL As DataSet
    Private objError As clsError

#End Region

#Region "Load Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            USERSLNO = Session("USERSLNO")
            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                ButtonsHiding(Me.Page)
                FillAcademiyears()
                BranchComboFill()
                fillDrpDist()
                SetViewStateVariables()
                'FillGrid(PageIndex)
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

#Region "FillMethods"

    Private Sub BranchComboFill()
        Dim Ds As DataSet
        Ds = ClsUty.FillUserWise_ExamBranch(USERSLNO, Session("COMACADEMICSLNO"))
        drpBranchSearch.DataSource = Ds
        drpBranchSearch.DataTextField = "EXAMBRANCHNAME"
        drpBranchSearch.DataValueField = "EXAMBRANCHSLNO"
        drpBranchSearch.DataBind()
    End Sub

    Private Sub fillDrpDist()

        Dim Ds As DataSet
        objBoardEnrollment = New ClsBoardEnrollment
        Ds = objBoardEnrollment.Masters_Selectall(1)
        DrpDist.DataSource = Ds.Tables(0)
        DrpDist.DataTextField = "NAME"
        DrpDist.DataValueField = "SLNO"
        DrpDist.DataBind()

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
            Dim Sqlstr, FltStr As String
            ClsUty = New Utility
            If DrpDist.SelectedValue <> 0 Then
                FltStr = " AND DIST.BOARDDISTSLNO = " & DrpDist.SelectedValue
            Else
                FltStr = " "
            End If

            If txtSearch.Text.Trim.ToUpper <> "" Then
                FltStr = FltStr & " AND (COLL.COLLEGENAME LIKE '%" & txtSearch.Text.Trim.ToUpper & "%' OR COLL.CODE LIKE '%" & txtSearch.Text.Trim.ToUpper & "%')"
            Else
                FltStr = FltStr & " "
            End If
            Sqlstr = " SELECT 0 SLNO, COLL.BOARDCOLLEGESLNO COLLSLNO, DIST.NAME DIST, COLL.CODE, COLL.COLLEGENAME FROM EXAM_BOARDCOLLEGE_MT COLL, EXAM_BOARDDIST_MT DIST " & _
                     " WHERE DIST.BOARDDISTSLNO=COLL.BOARDDISTSLNO AND BOARDCOLLEGESLNO NOT IN (SELECT BOARDCOLLEGESLNO FROM EXAM_BC_EB_ACADEMIC_MT " & _
                     " WHERE COMACADEMICSLNO = " & drpAcaSlno.SelectedValue.ToString & " AND EXAMBRANCHSLNO = " & drpBranchSearch.SelectedValue.ToString & ") " & FltStr & " ORDER BY DIST.NAME,COLL.COLLEGENAME "


            DsSearchResult = ClsUty.DataSet_Fetch(Sqlstr)

            Me.ViewState("DataSet") = DsSearchResult

            If Not DsSearchResult Is Nothing Then
                j = 1
                For i = 0 To DsSearchResult.Tables(0).Rows.Count - 1
                    DsSearchResult.Tables(0).Rows(i)("SLNO") = j
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

                DgColl.CurrentPageIndex = PageIndex
                DgColl.DataSource = DsSearchResult
                DgColl.DataBind()
                Me.ViewState("DsSearchResult") = DsSearchResult
            End If
        Catch ex As Exception
            objError = New clsError
            StartUpScript(Me.ID, objError.errHandler(ex))
        End Try

    End Sub

    Private Sub SetViewStateVariables()
        Try
            If Not Request.QueryString("ACANO") Is Nothing Then ACANO = Request.QueryString("ACANO")
            If Not Request.QueryString("EBNO") Is Nothing Then EBNO = Request.QueryString("EBNO")

            Me.ViewState("ACANO") = ACANO
            Me.ViewState("EBNO") = EBNO
            drpAcaSlno.SelectedValue = ACANO
        Catch ex As Exception
            Throw ex
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

    Private Sub prepareTableForSave()
        Try
            Dim dt As DataTable
            dsACEBCOL = New DataSet
            dsACEBCOL.Tables.Add(New DataTable("ACEBCOLDT"))
            dt = dsACEBCOL.Tables("ACEBCOLDT")
            dt.Columns.Add("BOARDCOLLEGESLNO", Type.GetType("System.Int32"))
            dt.Columns.Add("EXAMBRANCHSLNO", Type.GetType("System.Int32"))
            dt.Columns.Add("COMACADEMICSLNO", Type.GetType("System.Int32"))
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

#End Region

#Region "DropdownChange Events"

    Private Sub DrpDist_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpDist.SelectedIndexChanged
        Try
            FillGrid(PageIndex)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub drpBranchSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpBranchSearch.SelectedIndexChanged
        Try
            FillGrid(PageIndex)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "ImageButton Events"

    Private Sub Ibtngo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Ibtngo.Click
        Try
            FillGrid(PageIndex)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IbtnSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnSearch.Click
        Try
            FillGrid(PageIndex)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Dim i As Int32
        Dim dRow As DataRow
        Dim strReturn As String
        Dim Count As Integer = 0
        Dim ChkGAMap As CheckBox
        Dim txtDesc As TextBox
        Dim txtEBSection As TextBox
        Try
            prepareTableForSave()

            dsACEBCOL.Tables("ACEBCOLDT").Rows.Clear()
            For i = 0 To DgColl.Items.Count - 1
                ChkGAMap = DgColl.Items(i).Cells(5).Controls(1)
                If ChkGAMap.Checked = True Then
                    dRow = dsACEBCOL.Tables("ACEBCOLDT").NewRow
                    dRow("BOARDCOLLEGESLNO") = DgColl.Items(i).Cells(1).Text
                    dRow("EXAMBRANCHSLNO") = CInt(drpBranchSearch.SelectedValue)
                    dRow("COMACADEMICSLNO") = CInt(drpAcaSlno.SelectedValue)
                    dsACEBCOL.Tables("ACEBCOLDT").Rows.Add(dRow)
                    Count += 1
                End If
            Next

            If Count > 0 Then
                objBoardEnrollment = New ClsBoardEnrollment
                strReturn = objBoardEnrollment.P_AcaEbCol_Insert(dsACEBCOL)

                If strReturn = "1" Then
                    StartUpScript(Me.ID, "Records Saved Successfully")
                    FillGrid(0)
                    ''PrepareTable()
                    ''ComboFillingAtRuntime()
                Else
                    StartUpScript(Me.ID, "Records Not Saved ")
                End If
            Else
                StartUpScript(Me.ID, "Please Check Atleast One Selection ")
            End If
            FillGrid(0)

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



#End Region

End Class
