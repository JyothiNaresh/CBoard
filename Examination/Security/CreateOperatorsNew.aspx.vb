Imports CollegeBoardDLL
Imports PasswordEncrypt
Imports CollegeBoardDLL.WebTree
Imports System.Data
Imports System.Data.OracleClient
Public Class CreateOperatorsNew
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtUid As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtUname As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents drpAcaSlno As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtPasswd As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtPasswdCon As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkUserTypes As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chklStuType As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents drpType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblType As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents lstAllBranch As System.Web.UI.WebControls.ListBox
    Protected WithEvents cmdBranchSelect As System.Web.UI.WebControls.ImageButton
    Protected WithEvents cmdBranchSelectAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents cmdBranchRemove As System.Web.UI.WebControls.ImageButton
    Protected WithEvents cmdBranchRemoveAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lstSelBranch As System.Web.UI.WebControls.ListBox
    Protected WithEvents chkBranchs As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chklBranch As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents ibtSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ibtnCancel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents txtCrDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents RbtnNormalUser As System.Web.UI.WebControls.RadioButton
    Protected WithEvents RbtnPayRollUser As System.Web.UI.WebControls.RadioButton
    Protected WithEvents DrpEmployees As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents ImgEmpNameNoSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents TxtEmpNameNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents LblDisplaySearch As System.Web.UI.WebControls.Label
    Protected WithEvents DrpSearch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpParolBarnch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents drpCStype As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label22 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents chkAreaTypes As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chklAreaType As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents chkSegment As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chklSegment As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents ibtGo As System.Web.UI.WebControls.ImageButton

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

    Private ds As New DataSet
    Private webcls As New WebTree
    Private Mode As String
    Private userslno As Integer
    Private objUscls As UserClass
    Private Utl As Utility
    Private RtnStr As String
    Dim dsSegment As New DataSet
#End Region

#Region "General Methods"

    Private Sub ClearControls()
        txtUid.Text = ""
        txtUname.Text = ""
        txtPasswd.Text = ""
        txtCrDate.Text = ""
        chkUserTypes.Checked = False
        chkAreaTypes.Checked = False
        chkBranchs.Checked = False

    End Sub

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")
        If focusCtrl <> "" And strMessage <> "" Then
            RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & FormName & "." & focusCtrl & " == '[object]') { document." & FormName & "." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
        ElseIf strMessage <> "" Then
            RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
        ElseIf focusCtrl <> "" Then
            RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & FormName & "." & focusCtrl & " == '[object]') { document." & FormName & "." & focusCtrl & ".focus(); } </script>")
        End If
    End Sub

#End Region

#Region "Methods"

    Private Function SetEntriesBranch() As DataSet
        Dim dsBranch As New DataSet
        Dim dt As New DataTable
        Dim dRow As DataRow
        Try
            dt.Columns.Add("BRANCHSLNO", GetType(System.Int16))
            dt.Columns.Add("COMACADEMICSLNO", GetType(System.Int16))
            dsBranch.Tables.Add(dt)
            If chklBranch.Items.Count > 0 Then
                For i As Integer = 0 To chklBranch.Items.Count - 1
                    If chklBranch.Items(i).Selected = True Then
                        dRow = dsBranch.Tables(0).NewRow
                        dRow("BRANCHSLNO") = chklBranch.Items(i).Value
                        dRow("COMACADEMICSLNO") = drpAcaSlno.SelectedValue
                        dsBranch.Tables(0).Rows.Add(dRow)
                    End If
                Next
            End If
            Return dsBranch
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function SetEntriesUserType() As DataSet
        Dim dsUsType As New DataSet
        Dim dt As New DataTable
        Dim dRow As DataRow
        Try
            dt.Columns.Add("USERTYPESLNO", GetType(System.Int16))
            dt.Columns.Add("COMACADEMICSLNO", GetType(System.Int16))
            dsUsType.Tables.Add(dt)
            If chklStuType.Items.Count > 0 Then
                For i As Integer = 0 To chklStuType.Items.Count - 1
                    If chklStuType.Items(i).Selected = True Then
                        dRow = dsUsType.Tables(0).NewRow
                        dRow("USERTYPESLNO") = chklStuType.Items(i).Value
                        dRow("COMACADEMICSLNO") = drpAcaSlno.SelectedValue
                        dsUsType.Tables(0).Rows.Add(dRow)
                    End If
                Next
            End If
            Return dsUsType
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function SetEntriesSegment() As DataSet
        'Dim dsSegment As New DataSet
        Dim dt As New DataTable
        Dim dRow As DataRow
        Try
            dt.Columns.Add("SEGMENTSLNO", GetType(System.Int16))
            dt.Columns.Add("COMACADEMICSLNO", GetType(System.Int16))
            dsSegment.Tables.Add(dt)
            If chklSegment.Items.Count > 0 Then
                For i As Integer = 0 To chklSegment.Items.Count - 1
                    If chklSegment.Items(i).Selected = True Then
                        dRow = dsSegment.Tables(0).NewRow
                        dRow("SEGMENTSLNO") = chklSegment.Items(i).Value
                        dRow("COMACADEMICSLNO") = drpAcaSlno.SelectedValue
                        dsSegment.Tables(0).Rows.Add(dRow)
                    End If
                Next
            End If
            Return dsSegment
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function SetEntriesArray() As ArrayList
        Dim arr As New ArrayList
        Try
            If Mode = "New" Then

                arr.Add(txtUid.Text.ToUpper.Trim)
                arr.Add(PasswordEncrypt.PasswordEncrypt.EncriptText(txtPasswd.Text.Trim))
                arr.Add(txtUname.Text.ToUpper.Trim)
                arr.Add(DateConversion(Session("SERVERDATE")))
                arr.Add(DateConversion(Session("SERVERDATE")))
                arr.Add(DateConversion(Session("SERVERDATE")))
                arr.Add(drpAcaSlno.SelectedValue)

                If RbtnPayRollUser.Checked = True Then
                    arr.Add("1")
                    arr.Add(Val(DrpEmployees.SelectedValue))
                Else
                    arr.Add(Val(0))
                    arr.Add(System.DBNull.Value)
                End If


            ElseIf Mode = "Edit" Then
                arr.Add(userslno)
                arr.Add(txtUid.Text.ToUpper.Trim)
                arr.Add(txtPasswd.Text.Trim)
                arr.Add(txtUname.Text.ToUpper.Trim)
                arr.Add(DateConversion(Session("SERVERDATE")))
                arr.Add(DateConversion(Session("SERVERDATE")))
                arr.Add(DateConversion(Session("SERVERDATE")))
                arr.Add(drpAcaSlno.SelectedValue)
                arr.Add(System.DBNull.Value)

            End If
            Return arr
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function PageValidations() As Boolean
        Try
            Dim i, j As Integer
            If Trim(txtUid.Text) = "" Then
                StartUpScript(txtUid.ID, "Enter UserID.")
                Return False
            ElseIf Trim(txtPasswd.Text) = "" AndAlso Mode = "New" Then
                StartUpScript(txtPasswd.ID, "Enter Password. ")
                Return False
            ElseIf Trim(txtUname.Text) = "" Then
                StartUpScript(txtUname.ID, "Please Enter User Name.")
                Return False
            ElseIf (Trim(txtPasswd.Text) <> Trim(txtPasswdCon.Text)) AndAlso Mode = "New" Then
                StartUpScript(txtPasswd.ID, "Password is not matching.")
                Return False
                'ElseIf Trim(txtFrDate.Text) = "" Then
                '    StartUpScript(txtFrDate.ID, "Enter Form Date.")
                '    Return False
                'ElseIf Not IsDate(Trim(txtFrDate.Text)) Then
                '    StartUpScript(txtFrDate.ID, "Enter From Date correct format.")
                '    Return False
                'ElseIf Trim(txtToDate.Text) = "" Then
                '    StartUpScript(txtToDate.ID, "Enter To Date.")
                '    Return False
                'ElseIf Not IsDate(Trim(txtToDate.Text)) Then
                '    StartUpScript(txtToDate.ID, "Enter To Date correct format.")
                '    Return False
            ElseIf drpAcaSlno.SelectedIndex = -1 Then
                StartUpScript(drpAcaSlno.ID, "Select Academic Year.")
                Return False
            End If
            If chklBranch.Items.Count > 0 Then
                For i = 0 To chklBranch.Items.Count - 1
                    If chklBranch.Items(i).Selected Then
                        j = 1
                        Exit For
                    End If
                Next
                If j = 0 Then
                    StartUpScript(chklBranch.ID, "Please check atleast one Branch.")
                    Return False
                End If
            Else
                StartUpScript(chklBranch.ID, "Please check Branches.")
                Return False
            End If

            If chklStuType.Items.Count > 0 Then
                For i = 0 To chklStuType.Items.Count - 1
                    If chklStuType.Items(i).Selected Then
                        j = 1
                        Exit For
                    End If
                Next
                If j = 0 Then
                    StartUpScript(chklStuType.ID, "Please check atleast one User Type.")
                    Return False
                End If
            Else
                StartUpScript(chklStuType.ID, "Please check User Types.")
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "Load Event"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim str As String = ""
            ds = New DataSet
            Dim dsBranch As New DataSet
            Dim dsAcaYr As New DataSet
            If Session("USERSLNO") Is Nothing Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
                Exit Sub
            End If
            Mode = Request.QueryString("Mode")
            userslno = CInt(Request.QueryString("userslno"))
            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                FillAcademiyears()
                drpAcaSlno.SelectedValue = Session("COMACADEMICSLNO")

                OfficetypecomboxFill()
                FillPayrollBranches()
                FillEmployees(1)
                'FillSegments()
                FillTypes()
                FillBranchs()
                FillUserType()
                FillAreaType()
                If Mode = "New" Then
                    StartUpScript("txtUid", "")
                    Dim iCOMACASLNO As Integer = drpAcaSlno.SelectedValue
                ElseIf Mode = "Edit" Then
                    txtPasswd.ReadOnly = True
                    txtPasswdCon.ReadOnly = True
                    FillEditModeControls(userslno)
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
                If Not Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                    "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                    StartUpScript("", GeneralErrorMessage(ex.Message))
                End If
            End If
        End Try
    End Sub

#End Region

#Region "Fill Methods"

    Private Sub FillEditModeControls(ByVal userslno As Integer)
        Dim DsUser, DsBranchUserType As DataSet
        Dim i, j As Integer
        Try
            objUscls = New UserClass
            DsUser = objUscls.GetUserInformation(userslno)

            txtUid.Text = DsUser.Tables(0).Rows(0)("USERID")
            txtUname.Text = DsUser.Tables(0).Rows(0)("NAME")
            If Not IsDBNull(DsUser.Tables(0).Rows(0)("CREATEDATE")) Then
                txtCrDate.Text = DsUser.Tables(0).Rows(0)("CREATEDATE")
            End If

            DsBranchUserType = objUscls.GetBranchUserTypeInformation(userslno, drpAcaSlno.SelectedValue)

            For j = 0 To DsBranchUserType.Tables(0).Rows.Count - 1
                For i = 0 To chklBranch.Items.Count - 1
                    If chklBranch.Items(i).Value = DsBranchUserType.Tables(0).Rows(j)("EXAMBRANCHSLNO") Then
                        chklBranch.Items(i).Selected = True
                    End If
                Next
            Next

            For j = 0 To DsBranchUserType.Tables(1).Rows.Count - 1
                For i = 0 To chklStuType.Items.Count - 1
                    If chklStuType.Items(i).Value = DsBranchUserType.Tables(1).Rows(j)("USERTYPESLNO") Then
                        chklStuType.Items(i).Selected = True
                    End If
                Next
            Next

            For j = 0 To DsBranchUserType.Tables(2).Rows.Count - 1
                For i = 0 To chklSegment.Items.Count - 1
                    If chklSegment.Items(i).Value = DsBranchUserType.Tables(2).Rows(j)("SEGMENTSLNO") Then
                        chklSegment.Items(i).Selected = True
                    End If
                Next
            Next

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillAcademiyears()
        Try
            Dim dsAcaYr As DataSet
            Utl = New Utility
            dsAcaYr = Utl.DataSet_Fetch("SELECT COMACADEMICSLNO,NAME FROM T_COMPANYACADEMICYEAR_MT")
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

    Private Sub FillTypes()
        Try
            Dim dsType As DataSet
            Utl = New Utility

            lstSelBranch.Items.Clear()
            lstAllBranch.Items.Clear()

            If drpType.SelectedValue = 0 Then       ''For All
                lblType.Text = "All"
            ElseIf drpType.SelectedValue = 1 Then   ''For Region
                dsType = Utl.DataSet_Fetch("SELECT REGIONSLNO SLNO, NAME FROM T_REGION_MT ORDER BY NAME")
                lblType.Text = "Region"
            ElseIf drpType.SelectedValue = 2 Then   ''For Zone
                dsType = Utl.DataSet_Fetch("SELECT ZONESLNO SLNO, NAME FROM T_ZONE_MT ORDER BY NAME")
                lblType.Text = "Zone"
            ElseIf drpType.SelectedValue = 3 Then   ''For Addl-Region
                dsType = Utl.DataSet_Fetch("SELECT ADDLREGIONSLNO SLNO, NAME FROM T_ADDLREGION_MT ORDER BY NAME")
                lblType.Text = "Addle-Region"
            ElseIf drpType.SelectedValue = 4 Then   ''For Vc
                dsType = Utl.DataSet_Fetch("SELECT DOSLNO SLNO, NAME FROM T_DO_MT ORDER BY NAME")
                lblType.Text = "Vc"
            ElseIf drpType.SelectedValue = 5 Then   ''For Divisional Auditor
                dsType = Utl.DataSet_Fetch("SELECT DIVISIONSLNO SLNO, NAME FROM T_DIVISION_MT ORDER BY NAME")
                lblType.Text = "Divisional Auditor"
            ElseIf drpType.SelectedValue = 6 Then   ''For Divisional Auditor
                dsType = Utl.DataSet_Fetch("SELECT VCSLNO SLNO, NAME FROM T_VC_MT ORDER BY NAME")
                lblType.Text = "VC"
            End If

            If Not dsType Is Nothing AndAlso dsType.Tables(0).Rows.Count > 0 Then
                lstAllBranch.DataSource = dsType
                lstAllBranch.DataTextField = "NAME"
                lstAllBranch.DataValueField = "SLNO"
                lstAllBranch.DataBind()
            End If

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillBranchs()
        Try
            Dim i As Integer
            Dim SelectionStr As String = ""
            Dim dsBranch As DataSet
            Utl = New Utility

            chklBranch.Items.Clear()

            If lstSelBranch.Items.Count > 0 Then
                For i = 0 To lstSelBranch.Items.Count - 1
                    SelectionStr &= lstSelBranch.Items(i).Value & ","
                Next
                SelectionStr = SelectionStr.TrimEnd(",")
            End If

            If drpAcaSlno.SelectedIndex <> -1 Then

                If drpType.SelectedValue = 0 Then       ''For All
                    dsBranch = Utl.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C ,EXAM_ACYEXAMBRANCH_DT ACY WHERE ACY.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO AND ACY.COMACADEMICSLNO=A.COMACADEMICSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " ORDER BY NAME")
                ElseIf drpType.SelectedValue = 1 AndAlso SelectionStr <> "" Then   ''For Region
                    dsBranch = Utl.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C ,EXAM_ACYEXAMBRANCH_DT ACY WHERE ACY.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO AND ACY.COMACADEMICSLNO=A.COMACADEMICSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " AND B.REGIONSLNO IN(" & SelectionStr & ") ORDER BY NAME")
                ElseIf drpType.SelectedValue = 2 AndAlso SelectionStr <> "" Then   ''For Zone
                    dsBranch = Utl.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C ,EXAM_ACYEXAMBRANCH_DT ACY WHERE ACY.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO AND ACY.COMACADEMICSLNO=A.COMACADEMICSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " AND B.ZONESLNO IN(" & SelectionStr & ") ORDER BY NAME")
                ElseIf drpType.SelectedValue = 3 AndAlso SelectionStr <> "" Then   ''For Addl-Region
                    dsBranch = Utl.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C ,EXAM_ACYEXAMBRANCH_DT ACY WHERE ACY.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO AND ACY.COMACADEMICSLNO=A.COMACADEMICSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " AND B.ADDLREGIONSLNO IN(" & SelectionStr & ") ORDER BY NAME")
                ElseIf drpType.SelectedValue = 4 AndAlso SelectionStr <> "" Then   ''For Vc
                    dsBranch = Utl.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C ,EXAM_ACYEXAMBRANCH_DT ACY WHERE ACY.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO AND ACY.COMACADEMICSLNO=A.COMACADEMICSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " AND B.DOSLNO IN(" & SelectionStr & ") ORDER BY NAME")
                ElseIf drpType.SelectedValue = 5 AndAlso SelectionStr <> "" Then   ''For Divisional Auditor
                    dsBranch = Utl.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C ,EXAM_ACYEXAMBRANCH_DT ACY WHERE ACY.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO AND ACY.COMACADEMICSLNO=A.COMACADEMICSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " AND B.DIVISIONSLNO IN(" & SelectionStr & ") ORDER BY NAME")
                ElseIf drpType.SelectedValue = 6 AndAlso SelectionStr <> "" Then   ''For Vice Chairman
                    dsBranch = Utl.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C ,EXAM_ACYEXAMBRANCH_DT ACY WHERE ACY.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO AND ACY.COMACADEMICSLNO=A.COMACADEMICSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " AND B.VC IN(" & SelectionStr & ") ORDER BY NAME")
                End If

            End If

            If Not dsBranch Is Nothing AndAlso dsBranch.Tables(0).Rows.Count > 0 Then
                chklBranch.DataSource = dsBranch
                chklBranch.DataTextField = "NAME"
                chklBranch.DataValueField = "EXAMBRANCHSLNO"
                chklBranch.DataBind()
            End If

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillSegments()
        Try
            Dim i As Integer
            Dim SelectionStr As String = ""
            Dim dsSegment As DataSet
            Utl = New Utility

            chklSegment.Items.Clear()

            dsSegment = Utl.DataSet_Fetch("SELECT DISTINCT SEGMENTSLNO,NAME FROM MASTERS.M_SEGMENT_MT WHERE COLLEGE=1 ORDER BY SEGMENTSLNO")

            If Not dsSegment Is Nothing AndAlso dsSegment.Tables(0).Rows.Count > 0 Then
                chklSegment.DataSource = dsSegment
                chklSegment.DataTextField = "NAME"
                chklSegment.DataValueField = "SEGMENTSLNO"
                chklSegment.DataBind()
            End If

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillAreaBranchs()
        Try
            Dim i As Integer
            Dim SelectionStr As String = ""
            Dim dsBranch As DataSet
            Utl = New Utility

            chklBranch.Items.Clear()

            'If lstSelBranch.Items.Count > 0 Then
            '    For i = 0 To lstSelBranch.Items.Count - 1
            '        SelectionStr &= lstSelBranch.Items(i).Value & ","
            '    Next
            '    SelectionStr = SelectionStr.TrimEnd(",")
            'End If

            If drpAcaSlno.SelectedIndex <> -1 Then
                dsBranch = Utl.DataSet_Fetch("SELECT SLNO,NAME FROM EXAM_AREA_EXAMBRANCH_MT WHERE STATUS='A' ORDER BY SLNO")
                'dsBranch = Utl.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C ,EXAM_ACYEXAMBRANCH_DT ACY,EXAM_AREA_EXAMBRANCH_MAP D WHERE ACY.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO AND D.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO AND ACY.COMACADEMICSLNO=A.COMACADEMICSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " ORDER BY NAME")
            End If

            If Not dsBranch Is Nothing AndAlso dsBranch.Tables(0).Rows.Count > 0 Then
                chklBranch.DataSource = dsBranch
                chklBranch.DataTextField = "NAME"
                chklBranch.DataValueField = "SLNO"
                chklBranch.DataBind()
            End If

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillUserType()
        Try
            Dim dsStuType As DataSet
            Utl = New Utility
            If (Session("USERID") = "75600044" Or Session("USERID") = "75600042" Or Session("USERID") = "75600049") Then
                dsStuType = Utl.DataSet_Fetch("SELECT USERTYPESLNO,NAME FROM E_USERTYPE_MT WHERE USERTYPESLNO>1 ORDER BY NAME")
            Else
                dsStuType = Utl.DataSet_Fetch("SELECT USERTYPESLNO,NAME FROM E_USERTYPE_MT WHERE USERTYPESLNO>2 ORDER BY NAME")
            End If
            chklStuType.DataSource = dsStuType
            chklStuType.DataTextField = "NAME"
            chklStuType.DataValueField = "USERTYPESLNO"
            chklStuType.DataBind()
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillAreaType()
        Try
            Dim dsAreaType As DataSet
            Utl = New Utility
            'If (Session("USERID") = "39200128" Or Session("USERID") = "39200121" Or Session("USERID") = "39200126") Then
            dsAreaType = Utl.DataSet_Fetch("SELECT SLNO,NAME FROM EXAM_AREA_EXAMBRANCH_MT WHERE STATUS='A' ORDER BY NAME")
            'Else
            '   dsStuType = Utl.DataSet_Fetch("SELECT SLNO,NAME FROM E_USERTYPE_MT WHERE USERTYPESLNO>2 ORDER BY NAME")
            'End If
            chklAreaType.DataSource = dsAreaType
            chklAreaType.DataTextField = "NAME"
            chklAreaType.DataValueField = "SLNO"
            chklAreaType.DataBind()
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillEditModeControls2nd(ByVal userslno As Integer)
        Dim DsUser, DsBranchUserType As DataSet
        Dim i, j As Integer
        Try
            objUscls = New UserClass

            DsBranchUserType = objUscls.GetBranchUserTypeInformation(userslno, drpAcaSlno.SelectedValue)

            For j = 0 To DsBranchUserType.Tables(0).Rows.Count - 1
                For i = 0 To chklBranch.Items.Count - 1
                    If chklBranch.Items(i).Value = DsBranchUserType.Tables(0).Rows(j)("EXAMBRANCHSLNO") Then
                        chklBranch.Items(i).Selected = True
                    End If
                Next
            Next

            For j = 0 To DsBranchUserType.Tables(1).Rows.Count - 1
                For i = 0 To chklStuType.Items.Count - 1
                    If chklStuType.Items(i).Value = DsBranchUserType.Tables(1).Rows(j)("USERTYPESLNO") Then
                        chklStuType.Items(i).Selected = True
                    End If
                Next
            Next
            For j = 0 To DsBranchUserType.Tables(2).Rows.Count - 1
                For i = 0 To chklSegment.Items.Count - 1
                    If chklSegment.Items(i).Value = DsBranchUserType.Tables(2).Rows(j)("SEGMENTSLNO") Then
                        chklSegment.Items(i).Selected = True
                    End If
                Next
            Next

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OfficetypecomboxFill()
        Try
            Dim cs As DataSet
            Utl = New Utility
            ds = Utl.DataSet_OneFetch("SELECT OFFICETYPESLNO SLNO,NAME FROM MASTERS.M_OFFICETYPE_MT ORDER BY SLNO")
            drpCStype.DataSource = ds
            drpCStype.DataTextField = "NAME"
            drpCStype.DataValueField = "SLNO"
            drpCStype.DataBind()
            ' drpCStype.Items.Insert(0, New ListItem("All", 0))
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillPayrollBranches()
        Try
            Utl = New Utility
            ds = Utl.DataSet_OneFetch("SELECT PBRANCHSLNO,NAME||'-'||PBRANCHSLNO NAME FROM PAYROLLNEW.V_BRANCH_MT WHERE OFFICETYPESLNO=" & drpCStype.SelectedValue.ToString & " ORDER BY NAME ")

            If ds.Tables(0).Rows.Count > 0 Then
                DrpParolBarnch.DataSource = ds
                DrpParolBarnch.DataTextField = "NAME"
                DrpParolBarnch.DataValueField = "PBRANCHSLNO"
                DrpParolBarnch.DataBind()
            End If

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillEmployees(ByVal SFor As Integer)
        Try
            Dim StrWhere As String
            DrpEmployees.Items.Clear()

            If DrpParolBarnch.SelectedIndex <> -1 Then
                If SFor = 2 Then
                    If DrpSearch.SelectedValue = 1 Then
                        StrWhere = " AND NAME LIKE '%" & UCase(Trim(TxtEmpNameNo.Text)) & "%'"
                    ElseIf DrpSearch.SelectedValue = 2 Then
                        StrWhere = " AND EMPNO = '" & Trim(TxtEmpNameNo.Text) & "'"
                    End If
                End If

                Utl = New Utility
                ds = Utl.DataSet_OneFetch("SELECT EMPSLNO,BIOEMPNO, NAME, NAME||' '||SURNAME||'-->'||BIOEMPNO||'-->'||CATEGORYNAME ||'-->'||SUBCATEGORYNAME||'-->'||DEPARTMENTNAME||'-->'||DESIGNATIONNAME EMPNAME ,  " & _
                                             " PBRANCHSLNO,CATEGORYSLNO,SUBCATEGORYSLNO,DEPARTMENTSLNO,DESIGNATIONSLNO, " & _
                                             " CATEGORYNAME,SUBCATEGORYNAME,DEPARTMENTNAME,DESIGNATIONNAME " & _
                                             " FROM PAYROLLNEW.V_EMP_DT " & _
                                             " WHERE STATUS=1 AND PBRANCHSLNO=" & DrpParolBarnch.SelectedValue.ToString & StrWhere & _
                                             " ORDER  BY NAME ")

                If ds.Tables(0).Rows.Count > 0 Then
                    DrpEmployees.DataSource = ds
                    DrpEmployees.DataTextField = "EMPNAME"
                    DrpEmployees.DataValueField = "EMPSLNO"
                    DrpEmployees.DataBind()
                End If
            Else
                StartUpScript(DrpEmployees.ID, " Select Payroll Branch ")
            End If

            DrpEmployees.Items.Insert(0, New ListItem("  ---- Select ---  ", 0))

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "ListBox Events"

    Private Sub cmdBranchSelect_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdBranchSelect.Click
        Try
            Dim i As Integer
            If Not lstAllBranch.SelectedItem Is Nothing Then
                For i = 0 To lstAllBranch.Items.Count - 1
                    If lstAllBranch.Items(i).Selected = True Then
                        lstSelBranch.Items.Add(lstAllBranch.Items(i))
                    End If
                Next
                i = 0
                Do
                    If lstAllBranch.Items(i).Selected = True Then
                        lstAllBranch.Items.Remove(lstAllBranch.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = lstAllBranch.Items.Count Then Exit Do
                Loop
            End If

            FillBranchs()
            If Mode = "Edit" Then
                FillEditModeControls(userslno)
            End If

        Catch ex As Exception
            StartUpScript("", GeneralErrorMessage(ex.Message))
        End Try
    End Sub

    Private Sub cmdBranchSelectAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdBranchSelectAll.Click
        Try
            Dim iTotItems As Integer = lstAllBranch.Items.Count - 1
            Dim i As Integer
            For i = 0 To iTotItems
                lstSelBranch.Items.Add(lstAllBranch.Items(i))
            Next
            lstAllBranch.Items.Clear()

            FillBranchs()
            If Mode = "Edit" Then
                FillEditModeControls(userslno)
            End If

        Catch ex As Exception
            StartUpScript("", GeneralErrorMessage(ex.Message))
        End Try
    End Sub

    Private Sub cmdBranchRemove_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdBranchRemove.Click
        Try
            Dim i As Integer
            If Not lstSelBranch.SelectedItem Is Nothing Then
                For i = 0 To lstSelBranch.Items.Count - 1
                    If lstSelBranch.Items(i).Selected = True Then
                        lstAllBranch.Items.Add(lstSelBranch.Items(i))
                    End If
                Next

                i = 0
                Do
                    If lstSelBranch.Items(i).Selected = True Then
                        lstSelBranch.Items.Remove(lstSelBranch.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = lstSelBranch.Items.Count Then Exit Do
                Loop
            End If

            FillBranchs()
            If Mode = "Edit" Then
                FillEditModeControls(userslno)
            End If

        Catch ex As Exception
            StartUpScript("", GeneralErrorMessage(ex.Message))
        End Try
    End Sub

    Private Sub cmdBranchRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdBranchRemoveAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = lstSelBranch.Items.Count - 1

            For i = 0 To iTotItems
                lstAllBranch.Items.Add(lstSelBranch.Items(i))

            Next
            lstSelBranch.Items.Clear()

            FillBranchs()
            If Mode = "Edit" Then
                FillEditModeControls(userslno)
            End If

        Catch ex As Exception
            StartUpScript("", GeneralErrorMessage(ex.Message))
        End Try
    End Sub


#End Region

#Region "Button Events"

    Private Sub ibtSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtSave.Click
        Try
            If PageValidations() Then
                objUscls = New UserClass
                SetEntriesSegment()

                If dsSegment.Tables(0).Rows.Count > 0 Then
                    RtnStr = objUscls.User_Segment_Save(Mode, SetEntriesArray(), SetEntriesBranch(), SetEntriesUserType(), dsSegment)
                Else
                    RtnStr = objUscls.User_Save(Mode, SetEntriesArray(), SetEntriesBranch(), SetEntriesUserType())
                End If
                'RtnStr = objUscls.User_Save(Mode, SetEntriesArray(), SetEntriesBranch(), SetEntriesUserType())
                If RtnStr = "SUCCESS" Then
                    If Mode = "Edit" Then
                        Response.Redirect("../Security/ViewAllUsers.aspx")
                    Else
                        ClearControls()
                        StartUpScript("txtUid", "Record Saved Successfully.")
                    End If
                Else
                    StartUpScript("", RtnStr)
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
                If Not Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                    "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                    StartUpScript("", GeneralErrorMessage(ex.Message))
                End If
            End If
        End Try
    End Sub

    Private Sub ibtnCancel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnCancel.Click
        '''Try
        Response.Redirect("../Security/ViewAllUsers.aspx")
        '''Catch Oex As OracleException
        '''    StartUpScript("", DataBaseErrorMessage(Oex.Message))
        '''Catch ex As Exception
        '''    If GeneralErrorMessage(ex.Message) <> "" Then
        '''        StartUpScript("", GeneralErrorMessage(ex.Message))
        '''    End If
        '''End Try
    End Sub

    Private Sub ImgEmpNameNoSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgEmpNameNoSearch.Click
        Try
            FillEmployees(2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ibtGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtGo.Click
        Try
            Dim dsSelBranch As DataSet
            Dim k As Integer
            Dim areaslno As String
            Utl = New Utility

            For k = 0 To chklAreaType.Items.Count - 1
                If chklAreaType.Items(k).Selected Then
                    areaslno &= chklAreaType.Items(k).Value & ","
                End If

            Next

            chklBranch.Items.Clear()
            If Len(areaslno) > 0 Then
                areaslno = areaslno.TrimEnd(",")
                dsSelBranch = Utl.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C ,EXAM_ACYEXAMBRANCH_DT ACY,EXAM_AREA_EXAMBRANCH_MAP D WHERE ACY.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO AND D.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO AND ACY.COMACADEMICSLNO=A.COMACADEMICSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND  D.AREAEXAMBRANCHSLNO IN (" & areaslno.ToString & ") AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & "  ORDER BY NAME")
            Else
                ' dsSelBranch = Utl.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C ,EXAM_ACYEXAMBRANCH_DT ACY,EXAM_AREA_EXAMBRANCH_MAP D WHERE ACY.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO AND D.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO AND ACY.COMACADEMICSLNO=A.COMACADEMICSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & "  ORDER BY NAME")
                FillBranchs()
            End If


            If Not dsSelBranch Is Nothing AndAlso dsSelBranch.Tables(0).Rows.Count > 0 Then
                chklBranch.Items.Clear()
                chklBranch.DataSource = dsSelBranch
                chklBranch.DataTextField = "NAME"
                chklBranch.DataValueField = "EXAMBRANCHSLNO"
                chklBranch.DataBind()
            End If

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Check Box Events"

    Private Sub chkUserTypes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkUserTypes.CheckedChanged
        Try
            Dim i As Integer
            If chkUserTypes.Checked Then
                For i = 0 To chklStuType.Items.Count - 1
                    chklStuType.Items(i).Selected = True
                Next
            Else
                For i = 0 To chklStuType.Items.Count - 1
                    chklStuType.Items(i).Selected = False
                Next
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

    Private Sub chkBranchs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBranchs.CheckedChanged
        Try
            Dim i As Integer
            If chkBranchs.Checked Then
                For i = 0 To chklBranch.Items.Count - 1
                    chklBranch.Items(i).Selected = True
                Next
            Else
                For i = 0 To chklBranch.Items.Count - 1
                    chklBranch.Items(i).Selected = False
                Next
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

    Private Sub chkAreaTypes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAreaTypes.CheckedChanged
        Try
            Dim i As Integer
            'FillAreaBranchs()
            If chkAreaTypes.Checked Then
                For i = 0 To chklAreaType.Items.Count - 1
                    chklAreaType.Items(i).Selected = True
                Next
            Else
                For i = 0 To chklAreaType.Items.Count - 1
                    chklAreaType.Items(i).Selected = False
                Next
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

#End Region

#Region "Combo Events"

    Private Sub drpAcaSlno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpAcaSlno.SelectedIndexChanged
        Try
            If drpAcaSlno.SelectedIndex <> -1 Then
                FillBranchs()
                If userslno > 0 Then
                    FillEditModeControls2nd(userslno)
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
                If Not Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                    "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                    StartUpScript("", GeneralErrorMessage(ex.Message))
                End If
            End If
        End Try
    End Sub

    Private Sub drpType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpType.SelectedIndexChanged
        Try
            FillTypes()
            FillBranchs()
            If Mode = "Edit" Then
                FillEditModeControls(userslno)
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DrpParolBarnch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpParolBarnch.SelectedIndexChanged
        Try
            FillEmployees(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RbtnPayRollUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtnPayRollUser.CheckedChanged, RbtnNormalUser.CheckedChanged
        If sender.ID = "RbtnPayRollUser" Then
            Panel1.Visible = True
            txtUid.ReadOnly = True
            txtUname.ReadOnly = True

            txtUid.Text = ""
            txtUname.Text = ""
        Else
            txtUid.Text = ""
            txtUname.Text = ""

            Panel1.Visible = False
            txtUid.ReadOnly = False
            txtUname.ReadOnly = False
        End If
    End Sub

    Private Sub DrpEmployees_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpEmployees.SelectedIndexChanged
        Try
            If DrpEmployees.SelectedIndex <> -1 AndAlso Val(DrpEmployees.SelectedValue) > 0 Then
                txtUid.ReadOnly = True
                'DrpEmployees.ToolTip = DrpEmployees.SelectedItem.Text
                Dim ASR() As String
                ASR = DrpEmployees.SelectedItem.Text.Split("-->")
                txtUname.Text = Trim(ASR(0))
                txtUid.Text = Right(ASR(2), 9).TrimStart(">")

                txtUname.ReadOnly = True
            Else
                txtUid.Text = ""
                txtUid.ReadOnly = True
                txtUname.Text = ""
                txtUname.ReadOnly = True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub drpCStype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpCStype.SelectedIndexChanged
        FillPayrollBranches()
        FillEmployees(1)
    End Sub

#End Region

    
End Class
