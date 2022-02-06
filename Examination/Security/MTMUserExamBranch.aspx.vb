'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is Presentation Layer For UserCreation
'   ACTIVITY                          : Many To Many ExamBranch Permission To Users
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 08-APR-2008
'   FINAL BASELINE DATE               : 08-APR-2008
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Imports PasswordEncrypt
Imports CollegeBoardDLL.WebTree
Imports System.Data.OracleClient

Public Class MTMUserExamBranch
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label

    Protected WithEvents drpAcaSlno As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chklStuType As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents chkBranchs As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chklBranch As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents ibtSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ibtnCancel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents DrpUserTypes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents iBtnSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents chkUser As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lstSelBranch As System.Web.UI.WebControls.ListBox
    Protected WithEvents cmdBranchRemoveAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents cmdBranchRemove As System.Web.UI.WebControls.ImageButton
    Protected WithEvents cmdBranchSelectAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents cmdBranchSelect As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lstAllBranch As System.Web.UI.WebControls.ListBox
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents lblType As System.Web.UI.WebControls.Label
    Protected WithEvents drpType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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
    Private Formname As String = "Form1"
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Private Mode As String
    Private userslno As Integer
    Private objUscls As UserClass
    Private RtnStr As String
    Private ClsUty As New Utility
    Private UserTypeslno As Integer

#End Region

#Region "General Methods"

    Private Sub ClearControls()
        Try

            chkBranchs.Checked = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")
        Try
            If focusCtrl <> "" And strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & Formname & "." & focusCtrl & " == '[object]') { document." & Formname & "." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf focusCtrl <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & Formname & "." & focusCtrl & " == '[object]') { document." & Formname & "." & focusCtrl & ".focus(); } </script>")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Methods"

    Private Function SetEntriesBranch() As DataSet
        Dim dsBranch As New DataSet

        Dim dt As New DataTable
        Dim dtU As New DataTable
        Dim dRow As DataRow
        Dim drowu As DataRow
        Try

            dt.Columns.Add("USERSLNO", GetType(System.Int16))
            dt.Columns.Add("BRANCHSLNO", GetType(System.Int16))
            dt.Columns.Add("COMACADEMICSLNO", GetType(System.Int16))
            dsBranch.Tables.Add(dt)

            dtU.Columns.Add("USERSLNO", GetType(System.Int16))
            dtU.Columns.Add("COMACADEMICSLNO", GetType(System.Int16))
            dsBranch.Tables.Add(dtU)

            If chklStuType.Items.Count - 1 Then

                For u As Integer = 0 To chklStuType.Items.Count - 1 ''This  Loop For Users

                    If chklStuType.Items(u).Selected = True Then
                        drowu = dsBranch.Tables(1).NewRow
                        drowu("USERSLNO") = chklStuType.Items(u).Value
                        drowu("COMACADEMICSLNO") = drpAcaSlno.SelectedValue
                        dsBranch.Tables(1).Rows.Add(drowu)

                        If chklBranch.Items.Count > 0 Then
                            For i As Integer = 0 To chklBranch.Items.Count - 1 'THis Loop For Exam Branchs
                                If chklBranch.Items(i).Selected = True Then
                                    dRow = dsBranch.Tables(0).NewRow
                                    dRow("USERSLNO") = chklStuType.Items(u).Value
                                    dRow("BRANCHSLNO") = chklBranch.Items(i).Value
                                    dRow("COMACADEMICSLNO") = drpAcaSlno.SelectedValue
                                    dsBranch.Tables(0).Rows.Add(dRow)
                                End If
                            Next
                        End If

                    End If



                Next

            End If

            Return dsBranch

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Private Function SetEntriesUserType() As DataSet
    '    Dim dsUsType As New DataSet
    '    Dim dt As New DataTable
    '    Dim dRow As DataRow
    '    Try
    '        dt.Columns.Add("USERTYPESLNO", GetType(System.Int16))
    '        dt.Columns.Add("COMACADEMICSLNO", GetType(System.Int16))
    '        dsUsType.Tables.Add(dt)
    '        If chklStuType.Items.Count > 0 Then
    '            For i As Integer = 0 To chklStuType.Items.Count - 1
    '                If chklStuType.Items(i).Selected = True Then
    '                    dRow = dsUsType.Tables(0).NewRow
    '                    dRow("USERTYPESLNO") = chklStuType.Items(i).Value
    '                    dRow("COMACADEMICSLNO") = drpAcaSlno.SelectedValue
    '                    dsUsType.Tables(0).Rows.Add(dRow)
    '                End If
    '            Next
    '        End If
    '        Return dsUsType
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Private Function SetEntriesArray() As ArrayList
    '    Dim arr As New ArrayList
    '    Try
    '        If Mode = "New" Then

    '            arr.Add(txtUid.Text.ToUpper.Trim)
    '            arr.Add(PasswordEncrypt.PasswordEncrypt.EncriptText(txtPasswd.Text.Trim))
    '            arr.Add(txtUname.Text.ToUpper.Trim)
    '            arr.Add(DateConversion(txtCrDate.Text))
    '            arr.Add(DateConversion(txtFrDate.Text))
    '            arr.Add(DateConversion(txtToDate.Text))
    '            arr.Add(drpAcaSlno.SelectedValue)
    '        ElseIf Mode = "Edit" Then
    '            arr.Add(userslno)
    '            arr.Add(txtUid.Text.ToUpper.Trim)
    '            arr.Add(txtPasswd.Text.Trim)
    '            arr.Add(txtUname.Text.ToUpper.Trim)
    '            arr.Add(DateConversion(txtCrDate.Text))
    '            arr.Add(DateConversion(txtFrDate.Text))
    '            arr.Add(DateConversion(txtToDate.Text))
    '            arr.Add(drpAcaSlno.SelectedValue)
    '        End If
    '        Return arr
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Private Function PageValidations() As Boolean
        Try
            Dim i, j As Integer
            If drpAcaSlno.SelectedIndex = -1 Then
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
        Dim str As String = ""
        ds = New DataSet
        Dim dsBranch As New DataSet
        Dim dsAcaYr As New DataSet
        Try
            If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
            Mode = Request.QueryString("Mode")
            userslno = CInt(Request.QueryString("userslno"))
            UserTypeslno = CInt(Request.QueryString("USERTYPESLNO"))
            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                FillAcademiyears()
                FillBranchs()
                FillUsersType()
                FillUsers()
                StartUpScript("txtUid", "")
                Dim iCOMACASLNO As Integer = drpAcaSlno.SelectedValue

            End If
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

#End Region

#Region "Fill Methods"

    Private Sub FillAcademiyears()
        Try
            Dim dsAcaYr As DataSet
            dsAcaYr = ClsUty.DataSet_Fetch("SELECT COMACADEMICSLNO,NAME FROM T_COMPANYACADEMICYEAR_MT")
            If dsAcaYr.Tables(0).Rows.Count > 0 Then
                drpAcaSlno.DataSource = dsAcaYr
                drpAcaSlno.DataTextField = "NAME"
                drpAcaSlno.DataValueField = "COMACADEMICSLNO"
                drpAcaSlno.DataBind()

                drpAcaSlno.SelectedValue = Session("COMACADEMICSLNO")

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
            ClsUty = New Utility

            lstSelBranch.Items.Clear()
            lstAllBranch.Items.Clear()

            If drpType.SelectedValue = 0 Then       ''For All
                lblType.Text = "All"
            ElseIf drpType.SelectedValue = 1 Then   ''For Region
                dsType = ClsUty.DataSet_Fetch("SELECT REGIONSLNO SLNO, NAME FROM T_REGION_MT ORDER BY NAME")
                lblType.Text = "Region"
            ElseIf drpType.SelectedValue = 2 Then   ''For Zone
                dsType = ClsUty.DataSet_Fetch("SELECT ZONESLNO SLNO, NAME FROM T_ZONE_MT ORDER BY NAME")
                lblType.Text = "Zone"
            ElseIf drpType.SelectedValue = 3 Then   ''For Addl-Region
                dsType = ClsUty.DataSet_Fetch("SELECT ADDLREGIONSLNO SLNO, NAME FROM T_ADDLREGION_MT ORDER BY NAME")
                lblType.Text = "Addle-Region"
            ElseIf drpType.SelectedValue = 4 Then   ''For Vc
                dsType = ClsUty.DataSet_Fetch("SELECT DOSLNO SLNO, NAME FROM T_DO_MT ORDER BY NAME")
                lblType.Text = "Vc"
            ElseIf drpType.SelectedValue = 5 Then   ''For Divisional Auditor
                dsType = ClsUty.DataSet_Fetch("SELECT DIVISIONSLNO SLNO, NAME FROM T_DIVISION_MT ORDER BY NAME")
                lblType.Text = "Divisional Auditor"
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
            ClsUty = New Utility

            chklBranch.Items.Clear()

            If lstSelBranch.Items.Count > 0 Then
                For i = 0 To lstSelBranch.Items.Count - 1
                    SelectionStr &= lstSelBranch.Items(i).Value & ","
                Next
                SelectionStr = SelectionStr.TrimEnd(",")
            End If

            If drpAcaSlno.SelectedIndex <> -1 Then

                If drpType.SelectedValue = 0 Then       ''For All
                    dsBranch = ClsUty.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C, EXAM_ACYEXAMBRANCH_DT D WHERE C.EXAMBRANCHSLNO=D.EXAMBRANCHSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " AND D.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue & "ORDER BY NAME")
                ElseIf drpType.SelectedValue = 1 AndAlso SelectionStr <> "" Then   ''For Region
                    dsBranch = ClsUty.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C, EXAM_ACYEXAMBRANCH_DT D WHERE C.EXAMBRANCHSLNO=D.EXAMBRANCHSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " AND D.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue & " B.REGIONSLNO IN(" & SelectionStr & ") ORDER BY NAME")
                ElseIf drpType.SelectedValue = 2 AndAlso SelectionStr <> "" Then   ''For Zone
                    dsBranch = ClsUty.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C, EXAM_ACYEXAMBRANCH_DT D WHERE C.EXAMBRANCHSLNO=D.EXAMBRANCHSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " AND D.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue & " B.ZONESLNO IN(" & SelectionStr & ") ORDER BY NAME")
                ElseIf drpType.SelectedValue = 3 AndAlso SelectionStr <> "" Then   ''For Addl-Region
                    dsBranch = ClsUty.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C, EXAM_ACYEXAMBRANCH_DT D WHERE C.EXAMBRANCHSLNO=D.EXAMBRANCHSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " AND D.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue & " B.ADDLREGIONSLNO IN(" & SelectionStr & ") ORDER BY NAME")
                ElseIf drpType.SelectedValue = 4 AndAlso SelectionStr <> "" Then   ''For Vc
                    dsBranch = ClsUty.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C, EXAM_ACYEXAMBRANCH_DT D WHERE C.EXAMBRANCHSLNO=D.EXAMBRANCHSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " AND D.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue & " B.DOSLNO IN(" & SelectionStr & ") ORDER BY NAME")
                ElseIf drpType.SelectedValue = 5 AndAlso SelectionStr <> "" Then   ''For Divisional Auditor
                    dsBranch = ClsUty.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C, EXAM_ACYEXAMBRANCH_DT D WHERE C.EXAMBRANCHSLNO=D.EXAMBRANCHSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " AND D.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue & " B.DIVISIONSLNO IN(" & SelectionStr & ") ORDER BY NAME")
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

    Private Sub FillUsersType()
        Try
            Dim dsStuType As DataSet
            dsStuType = ClsUty.DataSet_Fetch("SELECT USERTYPESLNO,NAME FROM E_USERTYPE_MT WHERE USERTYPESLNO<>1")
            DrpUserTypes.DataSource = dsStuType
            DrpUserTypes.DataTextField = "NAME"
            DrpUserTypes.DataValueField = "USERTYPESLNO"
            DrpUserTypes.DataBind()
            DrpUserTypes.SelectedValue = UserTypeslno
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillUsers()
        Dim DsUsers As DataSet
        ClsUty = New Utility
        DsUsers = ClsUty.DataSet_OneFetch("SELECT UM.USERSLNO,UM.USERID  FROM EXAM_USER_MT UM,E_USER_USERTYPE_MT UUM   " & _
                                         " WHERE UM.USERSLNO = UUM.USERSLNO AND UUM.USERTYPESLNO=" & DrpUserTypes.SelectedValue.ToString & " AND UUM.COMACADEMICSLNO =" & drpAcaSlno.SelectedValue.ToString & "  ORDER BY UM.USERSLNO")
        chklStuType.DataSource = DsUsers
        chklStuType.DataTextField = "USERID"
        chklStuType.DataValueField = "USERSLNO"
        chklStuType.DataBind()

    End Sub

#End Region

#Region "Button Events"

    Private Sub iBtnSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSearch.Click
        Try
            FillUsers()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ibtSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtSave.Click
        Try
            If PageValidations() Then
                objUscls = New UserClass
                RtnStr = objUscls.MToMExamBranchUser_Save(SetEntriesBranch())
                If RtnStr = "SUCCESS" Then
                    ClearControls()
                    StartUpScript("txtUid", "Record Saved Successfully.")
                Else
                    StartUpScript("", RtnStr)
                End If
            End If
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub ibtnCancel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnCancel.Click
        Try
            Response.Redirect("../Security/ViewAllUsers.aspx")
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

#End Region

#Region "Check Box Events"

    Private Sub chkUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUser.CheckedChanged
        Try
            Dim i As Integer
            If chkUser.Checked Then
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
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
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
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
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

        Catch ex As Exception
            StartUpScript("", GeneralErrorMessage(ex.Message))
        End Try
    End Sub


#End Region

#Region " ComboBox Evnets "

    ' Private Sub drpRZ_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FillBranchs()
    'End Sub

    Private Sub drpType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpType.SelectedIndexChanged
        Try
            FillTypes()
            FillBranchs()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

End Class
