Imports System.Web.Services.Protocols
Imports CollegeBoardDLL
Imports System.Data.OracleClient
Imports CommonDLL
Imports System.Math
Public Class BoardCollegeBranchMapping
    Inherits System.Web.UI.Page



#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtlblCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents dgGridSection As System.Web.UI.WebControls.DataGrid
    Protected WithEvents iBtnAdd As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Txtccode As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents imgBtnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LBLCLGNAME As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents drpBranch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtrlpfrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtrlpto As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents txtplingarea As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents drppgtype As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents txtpgpfrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents txtpgpto As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents drplandtype As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents txtdistpg As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents txtparkarea As System.Web.UI.WebControls.TextBox
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Table4 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblbuld As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Tblpg As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents Drpbuldtype As System.Web.UI.WebControls.DropDownList
    Protected WithEvents imgBtnGoo1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lstmCode As System.Web.UI.WebControls.TextBox

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
    Private dsBranch As DataSet
    Private FormName As String = "Form1"
    Private MODE As String
    Private objReport As Utility
    Dim ClsUty As New Utility

    Private objWSCombo As ClsComboBoxFilling
    Dim ADMBRANCHSLNO, BATCHSLNO, EXAMBRANCHSLNO As Integer
    Dim DSet As New DataSet
    Private UserSLNo As Integer
#End Region

#Region "Common Methods"

    Protected Sub DeleteConformationMessage(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        Try
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Dim btn As Button = CType(e.Item.Cells(6).Controls(0), Button)
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

    Private Sub FillBranch()
        Dim Ds As DataSet
        Ds = ClsUty.FillUserWise_AdmBranch(Session("COMACADEMICSLNO"))
        drpBranch.DataSource = Ds
        drpBranch.DataTextField = "BRANCHNAME"
        drpBranch.DataValueField = "BRANCHSLNO"
        drpBranch.DataBind()
    End Sub

    Private Function SetEntries() As ArrayList
        Try
            Dim Arr As New ArrayList
            Dim gk As String
            gk = "System.DBNull.Value"
            If Me.ViewState("MODE") = "NEW" Then
                Arr.Add(Val(drpBranch.SelectedValue))
                Arr.Add(Val(Txtccode.Text))
            Else
                Arr.Add(Val(drpBranch.SelectedValue))
                Arr.Add(Val(Txtccode.Text))
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
            FillBranch()

            DsGA = objMaster.BRDCOL_SELECT(SLNO)

            If DsGA.Tables(0).Rows.Count > 0 Then

                Txtccode.Text = DsGA.Tables(0).Rows(0)("CCODE").ToString
                LBLCLGNAME.Text = DsGA.Tables(0).Rows(0)("COLLEGENAME").ToString
                drpBranch.SelectedValue = DsGA.Tables(0).Rows(0)("BRANCHSLNO").ToString

                'If drpBranch.SelectedValue = 2 Then
                '    tblbuld.Visible = True
                'Else
                '    tblbuld.Visible = False
                'End If

                'If drppgtype.SelectedValue = 2 Then
                '    Tblpg.Visible = True
                'Else
                '    Tblpg.Visible = False
                'End If


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
            ' drpBranch.SelectedValue = 0
           
        Catch ex As Exception

        End Try

    End Sub

    Private Function FormValidations() As Boolean
        Try
            If Trim(Txtccode.Text) = "" Or Trim(Txtccode.Text) Is Nothing Then
                StartUpScript("Txtccode", "Enter College Code.")
                Return False
            ElseIf drpBranch.SelectedValue = 0 Then
                StartUpScript(drpBranch.ID, "Select Building.")
                Return False
                'ElseIf drppgtype.SelectedValue = 0 Then
                '    StartUpScript(drppgtype.ID, "Select PlayGround Type.")
                '    Return False
                'ElseIf Trim(txtdistpg.Text) = "" Or Trim(txtdistpg.Text) Is Nothing Then
                '    StartUpScript("txtdistpg", "Enter Distnace of Play Ground.")
                '    Return False
                'ElseIf Trim(txtparkarea.Text) = "" Or Trim(txtparkarea.Text) Is Nothing Then
                '    StartUpScript("txtparkarea", "Enter Pariking Area.")
                '    Return False
                'ElseIf drplandtype.SelectedValue = 0 Then
                '    StartUpScript(drplandtype.ID, "Select Land Type.")
                '    Return False

                'ElseIf Drpbuldtype.SelectedValue = 0 Then
                '    StartUpScript(Drpbuldtype.ID, "Select Building Type.")
                '    Return False


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
    'Private Sub MultiFillCode()
    '    Try
    '        Dim SqlStr As String
    '        Dim I As Integer

    '        SqlStr = "SELECT BPG.CCODE FROM M_BUILDING_PLGROUND_DT BPG,EXAM_BOARDCOLLEGE_MT CLG WHERE BPG.CCODE=CLG.CODE ORDER BY BPG.CCODE"
    '        objReport = New Utility
    '        DSet = objReport.DataSet_OneFetch(SqlStr)
    '        lstmCode.DataSource = DSet.Tables(0)
    '        lstmCode.DataTextField = "CCODE"
    '        lstmCode.DataValueField = "CCODE"
    '        lstmCode.DataBind()

    '    Catch ex As Exception

    '    End Try

    'End Sub

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
                'StrSql = "SELECT BPG.BLDSLNO,BPG.CCODE,CLG.COLLEGENAME  FROM M_BUILDING_PLGROUND_DT BPG,EXAM_BOARDCOLLEGE_MT CLG WHERE BPG.CCODE=CLG.CODE AND BPG.CCODE IN ( " & SqlStr1 & " ) ORDER BY BPG.CCODE"
                StrSql = "SELECT BR.BRANCHSLNO,BR.NAME BRANCHNAME,CLG.CODE CCODE,CLG.COLLEGENAME  FROM T_BRANCH_MT BR,EXAM_BOARDCOLLEGE_MT CLG WHERE BR.BRANCHSLNO(+)=CLG.BRANCHSLNO AND CLG.ISNARAYANA=2 AND AND CLG.CODE= " & lstmCode.Text & " ORDER BY BR.BRANCHSLNO"
            Else
                StrSql = "SELECT BR.BRANCHSLNO,BR.NAME BRANCHNAME,CLG.CODE CCODE,CLG.COLLEGENAME FROM T_BRANCH_MT BR,EXAM_BOARDCOLLEGE_MT CLG WHERE BR.BRANCHSLNO(+)=CLG.BRANCHSLNO AND CLG.ISNARAYANA=2  ORDER BY BR.BRANCHSLNO"
            End If



            ObjResult = New Utility

            DsSearchResult = ObjResult.DataSet_OneFetch(StrSql)

            Me.ViewState("DsSearchResult") = DsSearchResult

            If Not DsSearchResult Is Nothing Then
                '' Setting Page Indexs
                If (DsSearchResult.Tables(0).Rows.Count - 1) / 50 < PageIndex Then

                    If ((DsSearchResult.Tables(0).Rows.Count - 1) / 50) <= 1 Then
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

                Me.ViewState("PageIndex") = PageIndex

                If Me.ViewState("MODE") = "EDIT" Then
                    FillControls()
                End If
                FillGrid(PageIndex)
                Table4.Visible = False
                'tblbuld.Visible = False
                'Tblpg.Visible = False
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

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Try

            If Not FormValidations() Then Exit Sub
            objMaster = New ClsBoarddt

            If (Me.ViewState("MODE")) = "EDIT" Then
                'tblbuld.Visible = False
                'Tblpg.Visible = False
                RtnVal = objMaster.BRDCOL_Update(SetEntries())
                If RtnVal = 1 Then
                    StartUpScript(iBtnSave.ID, "Record Updated Successfully.")
                    ClearControls()
                    FillGrid(PageIndex)
                    Table4.Visible = False

                Else
                    StartUpScript(iBtnSave.ID, "Record Not Updated.")
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

    'Private Sub iBtnAdd_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnAdd.Click
    '    Try
    '        Me.ViewState("MODE") = "NEW"
    '        Table4.Visible = True
    '        ClearControls()
    '        FillBranch()
    '    Catch ex As Exception
    '        If GeneralErrorMessage(ex.Message) <> "" Then
    '            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
    '                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
    '            StartUpScript(iBtnAdd.ID, " Transaction  Failed ")
    '        End If
    '    End Try
    'End Sub

    Private Sub imgBtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnGo.Click
        Try

            If Trim(Txtccode.Text) <> "" Then
                GenerateSqlQuery()
            Else
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

    Private Sub imgBtnGoo1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnGoo1.Click
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
            RtnVal = objMaster.BRDCOL_DELETE(dgGridSection.Items(e.Item.ItemIndex).Cells(2).Text)

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

#End Region

#Region "DROPS"

   

    'Private Sub FillBranch()

    '    Try
    '        Dim dsBuilding As DataSet
    '        ClsUty = New Utility
    '        dsBuilding = ClsUty.FillBranchUserWise_Fetch(UserSLNo, Session("COMACADEMICSLNO"))
    '        If dsBuilding.Tables(0).Rows.Count > 0 Then
    '            drpBranch.DataSource = dsBuilding
    '            drpBranch.DataTextField = "NAME"
    '            drpBranch.DataValueField = "SLNO"
    '            drpBranch.DataBind()
    '        End If
    '    Catch Oex As OracleException
    '        Throw Oex
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub
#End Region

#Region "Drop Down Events"

    Private Sub drpBuilding_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpBranch.SelectedIndexChanged
        'If drpBranch.SelectedValue = 2 Then
        '    tblbuld.Visible = True
        'Else
        '    tblbuld.Visible = False
        'End If
    End Sub

    Private Sub drppgtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drppgtype.SelectedIndexChanged
        If drppgtype.SelectedValue = 2 Then
            Tblpg.Visible = True
        Else
            Tblpg.Visible = False
        End If
    End Sub

#End Region



End Class
