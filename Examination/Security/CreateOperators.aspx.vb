'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is Presentation Layer For UserCreation
'   ACTIVITY                          : New UserCreation
'   AUTHOR                            : Srikanth
'   INITIAL BASELINE DATE             : -JAN-2006
'   FINAL BASELINE DATE               : -JAN-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Imports PasswordEncrypt
Imports CollegeBoardDLL.WebTree
Imports System.Data.OracleClient

Public Class CreateOperators
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents drpAcaSlno As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chklBranch As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents chklStuType As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents ibtSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ibtnCancel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents txtFrDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCrDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUid As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUname As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPasswd As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkUserTypes As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkBranchs As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtPasswdCon As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblRZ As System.Web.UI.WebControls.Label
    Protected WithEvents drpRZ As System.Web.UI.WebControls.DropDownList
    Protected WithEvents RbtnNormalUser As System.Web.UI.WebControls.RadioButton
    Protected WithEvents RbtnPayRollUser As System.Web.UI.WebControls.RadioButton
    Protected WithEvents DrpEmployees As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
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
    Dim ClsUty As New Utility
#End Region

#Region "General Methods"

    Private Sub ClearControls()
        Try
            txtUid.Text = ""
            txtUname.Text = ""
            txtPasswd.Text = ""
            txtCrDate.Text = ""
            txtFrDate.Text = ""
            txtToDate.Text = ""
            chkUserTypes.Checked = False
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

    Private Function SetEntriesArray() As ArrayList
        Dim arr As New ArrayList
        Try
            If Mode = "New" Then

                arr.Add(txtUid.Text.ToUpper.Trim)
                arr.Add(PasswordEncrypt.PasswordEncrypt.EncriptText(txtPasswd.Text.Trim))
                arr.Add(txtUname.Text.ToUpper.Trim)
                arr.Add(DateConversion(txtCrDate.Text))
                arr.Add(DateConversion(txtFrDate.Text))
                arr.Add(DateConversion(txtToDate.Text))
                arr.Add(drpAcaSlno.SelectedValue)
            ElseIf Mode = "Edit" Then
                arr.Add(userslno)
                arr.Add(txtUid.Text.ToUpper.Trim)
                arr.Add(txtPasswd.Text.Trim)
                arr.Add(txtUname.Text.ToUpper.Trim)
                arr.Add(DateConversion(txtCrDate.Text))
                arr.Add(DateConversion(txtFrDate.Text))
                arr.Add(DateConversion(txtToDate.Text))
                arr.Add(drpAcaSlno.SelectedValue)
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
                StartUpScript(txtUid.ID, "Enter User ID.")
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
            ElseIf Trim(txtFrDate.Text) = "" Then
                StartUpScript(txtFrDate.ID, "Enter From Date.")
                Return False
            ElseIf Not IsDate(Trim(txtFrDate.Text)) Then
                StartUpScript(txtFrDate.ID, "Enter From Date correct format.")
                Return False
            ElseIf Trim(txtToDate.Text) = "" Then
                StartUpScript(txtToDate.ID, "Enter To Date.")
                Return False
            ElseIf Not IsDate(Trim(txtToDate.Text)) Then
                StartUpScript(txtToDate.ID, "Enter To Date correct format.")
                Return False
            ElseIf Trim(txtCrDate.Text) = "" Then
                StartUpScript(txtCrDate.ID, "Enter Create Date.")
                Return False
            ElseIf Not IsDate(Trim(txtCrDate.Text)) Then
                StartUpScript(txtCrDate.ID, "Enter Create Date correct format.")
                Return False
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

            j = 0
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
            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                FillAcademiyears()
                OfficetypecomboxFill()
                FillPayrollBranches()
                FillEmployees(1)

                FillRegions()
                FillBranchs()
                FillUserType()
                drpAcaSlno.SelectedValue = Session("COMACADEMICSLNO")
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
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
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

            If DsUser.Tables(0).Rows.Count > 0 Then

                txtUid.Text = DsUser.Tables(0).Rows(0)("USERID")
                txtUname.Text = DsUser.Tables(0).Rows(0)("NAME")
                If Not IsDBNull(DsUser.Tables(0).Rows(0)("CREATEDATE")) Then
                    txtCrDate.Text = DsUser.Tables(0).Rows(0)("CREATEDATE")
                End If
                If Not IsDBNull(DsUser.Tables(0).Rows(0)("FROMDATE")) Then
                    txtFrDate.Text = DsUser.Tables(0).Rows(0)("FROMDATE")
                End If
                If Not IsDBNull(DsUser.Tables(0).Rows(0)("TOFATE")) Then
                    txtToDate.Text = DsUser.Tables(0).Rows(0)("TOFATE")
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

            End If



        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillAcademiyears()
        Try
            Dim dsAcaYr As DataSet
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

    Private Sub FillBranchs()
        Try
            Dim dsBranch As DataSet
            If drpAcaSlno.SelectedIndex <> -1 Then

                If drpRZ.SelectedValue = 0 Then
                    dsBranch = ClsUty.DataSet_Fetch(" SELECT DISTINCT B.EXAMBRANCHSLNO,B.EXAMBRANCHNAME FROM T_COMPANY_BRANCH_COURSE_MT A,EXAM_EXAMBRANCH B ,EXAM_ACYEXAMBRANCH_DT ACY WHERE ACY.EXAMBRANCHSLNO=B.EXAMBRANCHSLNO AND ACY.COMACADEMICSLNO=A.COMACADEMICSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " ORDER BY B.EXAMBRANCHNAME ")
                Else
                    dsBranch = ClsUty.DataSet_Fetch(" SELECT DISTINCT B.EXAMBRANCHSLNO,B.EXAMBRANCHNAME FROM T_COMPANY_BRANCH_COURSE_MT A,EXAM_EXAMBRANCH B,T_BRANCH_MT BRA ,EXAM_ACYEXAMBRANCH_DT ACY WHERE ACY.EXAMBRANCHSLNO=B.EXAMBRANCHSLNO AND ACY.COMACADEMICSLNO=A.COMACADEMICSLNO AND  BRA.BRANCHSLNO=A.BRANCHSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " AND BRA.REGIONSLNO=" & drpRZ.SelectedValue & " ORDER BY B.EXAMBRANCHNAME ")
                End If


                chklBranch.DataSource = dsBranch
                chklBranch.DataTextField = "EXAMBRANCHNAME"
                chklBranch.DataValueField = "EXAMBRANCHSLNO"
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
            dsStuType = ClsUty.DataSet_Fetch("SELECT USERTYPESLNO,NAME FROM E_USERTYPE_MT WHERE USERTYPESLNO<>1 ORDER BY NAME")
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

    Private Sub FillRegions()
        Try
            Dim dsRegion As DataSet

            dsRegion = ClsUty.DataSet_Fetch(" SELECT DISTINCT A.REGIONSLNO,A.NAME FROM T_REGION_MT A, T_BRANCH_MT BRA WHERE BRA.REGIONSLNO=A.REGIONSLNO  ORDER BY A.NAME ")
            drpRZ.DataSource = dsRegion
            drpRZ.DataTextField = "NAME"
            drpRZ.DataValueField = "REGIONSLNO"
            drpRZ.DataBind()
            drpRZ.Items.Insert(0, New ListItem("All", 0))

        Catch ex As Exception

        End Try
    End Sub

    Private Sub OfficetypecomboxFill()
        Try
            Dim cs As DataSet
            ClsUty = New Utility
            ds = ClsUty.DataSet_OneFetch("SELECT OFFICETYPESLNO SLNO,NAME FROM MASTERS.M_OFFICETYPE_MT ORDER BY SLNO")
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
            ClsUty = New Utility
            ds = ClsUty.DataSet_OneFetch("SELECT PBRANCHSLNO,NAME FROM V_BRANCH_MT WHERE OFFICETYPESLNO=" & drpCStype.SelectedValue.ToString & " ORDER BY NAME ")

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
                        StrWhere = " AND EMPNO = " & Val(Trim(TxtEmpNameNo.Text))
                    End If
                End If

                ClsUty = New Utility
                ds = ClsUty.DataSet_OneFetch("SELECT EMPSLNO,BIOEMPNO, NAME, NAME||' '||SURNAME||'-->'||EMPNO||'-->'||CATEGORYNAME ||'-->'||SUBCATEGORYNAME||'-->'||DEPARTMENTNAME||'-->'||DESIGNATIONNAME EMPNAME ,  " & _
                                             " PBRANCHSLNO,CATEGORYSLNO,SUBCATEGORYSLNO,DEPARTMENTSLNO,DESIGNATIONSLNO, " & _
                                             " CATEGORYNAME,SUBCATEGORYNAME,DEPARTMENTNAME,DESIGNATIONNAME " & _
                                             " FROM V_EMP_DT " & _
                                             " WHERE PBRANCHSLNO=" & DrpParolBarnch.SelectedValue.ToString & StrWhere & _
                                             " ORDER  BY NAME ")

                If ds.Tables(0).Rows.Count > 0 Then
                    DrpEmployees.DataSource = ds
                    DrpEmployees.DataTextField = "EMPNAME"
                    DrpEmployees.DataValueField = "BIOEMPNO"
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

#Region "Button Events"

    Private Sub ibtSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtSave.Click
        Try
            If PageValidations() Then
                objUscls = New UserClass
                RtnStr = objUscls.User_Save(Mode, SetEntriesArray(), SetEntriesBranch(), SetEntriesUserType())
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

    Private Sub ImgEmpNameNoSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgEmpNameNoSearch.Click
        Try
            FillEmployees(2)
        Catch ex As Exception

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

#Region "Combo Events"

    Private Sub drpAcaSlno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpAcaSlno.SelectedIndexChanged
        Try
            If drpAcaSlno.SelectedIndex <> -1 Then
                FillBranchs()
                FillEditModeControls(userslno)
            End If
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub drpRZ_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpRZ.SelectedIndexChanged
        FillBranchs()
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
                txtUid.Text = Trim(DrpEmployees.SelectedValue)
                txtUid.ReadOnly = True
                'DrpEmployees.ToolTip = DrpEmployees.SelectedItem.Text
                Dim ASR() As String
                ASR = DrpEmployees.SelectedItem.Text.Split("-->")
                txtUname.Text = Trim(ASR(0))
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
