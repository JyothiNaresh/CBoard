'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is Presentation Layer For Emplyoee Wise Users View
'   ACTIVITY                          : UsersView
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 13-Aug-2008
'   FINAL BASELINE DATE               : 
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Imports System.Data.OracleClient
Public Class EmpEbMappingView
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents drpAcaSlno As System.Web.UI.WebControls.DropDownList
    Protected WithEvents iBtnSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents dgVusers As System.Web.UI.WebControls.DataGrid
    Protected WithEvents iBtnBatchUpdate As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ibtnSingle As System.Web.UI.WebControls.ImageButton
    Protected WithEvents DrpExamBranch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpDepartment As System.Web.UI.WebControls.DropDownList

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
    Private dsV As New DataSet
    Private Formname As String = "Form1"
    Private objUcls As New UserClass
    Private PageIndex As Integer = 0
    Private Mode As String
    Dim ClsUty As New Utility
#End Region

#Region "Common Methods"

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

    Protected Sub DeleteConformationMessage(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        Try
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem

                    Dim btnE As Button = CType(e.Item.Cells(8).Controls(0), Button)
                    btnE.Attributes.Add("onclick", "return confirm('Are You Sure To Edit This Record ?')")

                    Dim btn As Button = CType(e.Item.Cells(9).Controls(0), Button)
                    btn.Attributes.Add("onclick", "return confirm('Are You Sure To Delete / Add This Record ?')")

                    'Dim btn1 As Button = CType(e.Item.Cells(8).Controls(0), Button)
                    'btn1.Attributes.Add("onclick", "return confirm('Are you sure you want to UnRegister This User ?')")


                    Exit Select
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetViewStateData()
        Try
            Me.ViewState("PageIndex") = PageIndex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetViewStateData()
        Try
            PageIndex = CInt(Me.ViewState("PageIndex"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Load Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                If Not Request.QueryString("PageIndex") Is Nothing AndAlso Request.QueryString("PageIndex") <> "" Then
                    PageIndex = CInt(Request.QueryString("PageIndex"))
                Else
                    PageIndex = 0
                End If
                FillAcademiyears()
                FillExamBranchs()
                FillDepartments()
                SetViewStateData()
                FilldataGrid(PageIndex)
            Else
                GetViewStateData()
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

    Private Sub FillDepartments()
        Try
            Dim Ds As DataSet
            ClsUty = New Utility
            Ds = ClsUty.DataSet_OneFetch(" SELECT DEPARTMENTSLNO ,NAME FROM PAYROLLNEW.P_DEPARTMENT_MT ORDER BY NAME  ")

            DrpDepartment.DataSource = Ds.Tables(0)
            DrpDepartment.DataTextField = "NAME"
            DrpDepartment.DataValueField = "DEPARTMENTSLNO"
            DrpDepartment.DataBind()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function FilldataGrid(ByVal PageIndex)
        Try
            objUcls = New UserClass


            'dsV = ClsUty.DataSet_Fetch("SELECT UM.USERSLNO,UM.USERID,UM.NAME,TO_CHAR(UM.FROMDATE,'dd/MM/yyyy') FROMDATE,TO_CHAR(UM.TOFATE,'dd/MM/yyyy') TOFATE ," & _
            '                          " ( CASE WHEN UM.STATUS='A' THEN 'Acitve' ELSE 'Deleted' END) USERSTATUS," & _
            '                          " ( CASE WHEN UM.ISMACCHECK=0 THEN 'Un Register' ELSE 'Register' END) REGISTER ," & _
            '                          " EMP.CATEGORYNAME ||'-->'||EMP.SUBCATEGORYNAME ||'-->'||EMP.DEPARTMENTNAME ||'-->'||EMP.DESIGNATIONNAME EMPCODE , " & _
            '                          " EMP.DEPARTMENTNAME,EMP.EMPNO,EMP.EMPNO||' - '||EMP.SURNAME||' '||EMP.NAME EMPNAME," & _
            '                          " FROM EXAM_USER_MT UM,E_USER_BRANCH_ACADEMIC_MT U,PAYROLLNEW.V_EMP_DT EMP   " & _
            '                          " WHERE EMP.OFFICETYPESLNO IN (1,9) AND UM.EMPSLNO=EMP.USERSLNO AND UM.USERSLNO = U.USERSLNO AND " & _
            '                          " U.EXAMBRANCHSLNO=" & DrpExamBranch.SelectedValue.ToString & _
            '                          " AND U.COMACADEMICSLNO =" & drpAcaSlno.SelectedValue.ToString & _
            '                          " AND DEPARTMENTSLNO=" & DrpDepartment.SelectedValue.ToString & _
            '                          "  ORDER BY UM.USERID")



            If Me.Session("CORS") = "C" Then

                dsV = ClsUty.DataSet_Fetch("SELECT UM.USERSLNO,UM.USERID,UM.NAME,TO_CHAR(UM.FROMDATE,'dd/MM/yyyy') FROMDATE,TO_CHAR(UM.TOFATE,'dd/MM/yyyy') TOFATE ," & _
                                        " ( CASE WHEN UM.STATUS='A' THEN 'Acitve' ELSE 'Deleted' END) USERSTATUS," & _
                                        " ( CASE WHEN UM.ISMACCHECK=0 THEN 'Un Register' ELSE 'Register' END) REGISTER ," & _
                                        " EMP.CATEGORYNAME ||'-->'||EMP.SUBCATEGORYNAME ||'-->'||EMP.DEPARTMENTNAME ||'-->'||EMP.DESIGNATIONNAME EMPCODE , " & _
                                        " EMP.DEPARTMENTNAME,EMP.EMPNO,EMP.EMPNO||' --> '||EMP.SURNAME||' '||EMP.NAME EMPNAME" & _
                                        " FROM EXAM_USER_MT UM,E_USER_BRANCH_ACADEMIC_MT U,PAYROLLNEW.V_EMP_DT EMP   " & _
                                        " WHERE EMP.OFFICETYPESLNO IN (1,9) AND UM.EMPSLNO=EMP.EMPSLNO AND UM.USERSLNO = U.USERSLNO AND " & _
                                        " U.EXAMBRANCHSLNO=" & DrpExamBranch.SelectedValue.ToString & _
                                        " AND U.COMACADEMICSLNO =" & drpAcaSlno.SelectedValue.ToString & _
                                        " AND DEPARTMENTSLNO=" & DrpDepartment.SelectedValue.ToString & _
                                        "  ORDER BY UM.USERID")


            ElseIf Me.Session("CORS") = "S" Then

                dsV = ClsUty.DataSet_Fetch("SELECT UM.USERSLNO,UM.USERID,UM.NAME,TO_CHAR(UM.FROMDATE,'dd/MM/yyyy') FROMDATE,TO_CHAR(UM.TOFATE,'dd/MM/yyyy') TOFATE ," & _
                        " ( CASE WHEN UM.STATUS='A' THEN 'Acitve' ELSE 'Deleted' END) USERSTATUS," & _
                        " ( CASE WHEN UM.ISMACCHECK=0 THEN 'Un Register' ELSE 'Register' END) REGISTER ," & _
                        " EMP.CATEGORYNAME ||'-->'||EMP.SUBCATEGORYNAME ||'-->'||EMP.DEPARTMENTNAME ||'-->'||EMP.DESIGNATIONNAME EMPCODE , " & _
                        " EMP.DEPARTMENTNAME,EMP.EMPNO,EMP.EMPNO||' - '||EMP.SURNAME||' '||EMP.NAME EMPNAME " & _
                        " FROM EXAM_USER_MT UM,E_USER_BRANCH_ACADEMIC_MT U,PAYROLLNEW.V_EMP_DT EMP   " & _
                        " WHERE EMP.OFFICETYPESLNO =2 AND UM.EMPSLNO=EMP.EMPSLNO AND UM.USERSLNO = U.USERSLNO AND " & _
                        " U.EXAMBRANCHSLNO=" & DrpExamBranch.SelectedValue.ToString & _
                        " AND U.COMACADEMICSLNO =" & drpAcaSlno.SelectedValue.ToString & _
                        " AND DEPARTMENTSLNO=" & DrpDepartment.SelectedValue.ToString & _
                        "  ORDER BY UM.USERID")

            End If



            If Not dsV Is Nothing Then
                If (dsV.Tables(0).Rows.Count - 1) / 10 < PageIndex Then
                    If ((dsV.Tables(0).Rows.Count - 1) / 10) <= 1 Then
                        PageIndex = 0
                    Else
                        PageIndex = PageIndex - 1
                    End If
                End If
                Session("ViewAllUsers_DataSet") = dsV
                dgVusers.CurrentPageIndex = PageIndex
                dgVusers.DataSource = dsV.Tables(0)
                dgVusers.DataBind()
            End If
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

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


    Private Sub FillExamBranchs()
        Try
            Dim dsStuType As DataSet
            dsStuType = ClsUty.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C ,EXAM_ACYEXAMBRANCH_DT ACY WHERE ACY.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO AND ACY.COMACADEMICSLNO=A.COMACADEMICSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " ORDER BY NAME")
            DrpExamBranch.DataSource = dsStuType
            DrpExamBranch.DataTextField = "NAME"
            DrpExamBranch.DataValueField = "EXAMBRANCHSLNO"
            DrpExamBranch.DataBind()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Grid Events"

    Private Sub dgVusers_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgVusers.EditCommand
        Try
            Dim UserSlno As Integer = dgVusers.Items(e.Item.ItemIndex).Cells(1).Text
            Mode = "Edit"
            If UserSlno = 1 Then
                StartUpScript("", "Admin user can not modify.")
                Exit Sub
            Else
                Response.Redirect("../Security/CreateOperatorsNew.aspx?UserSlno=" & UserSlno & "&Mode=" & Mode)
            End If
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub dgVusers_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgVusers.DeleteCommand
        Try
            Dim UserSlno As Integer = dgVusers.Items(e.Item.ItemIndex).Cells(1).Text
            Dim RtnStr As String = ""
            If UserSlno = 1 Then
                StartUpScript("", "Admin user can not Delete.")
                Exit Sub
            End If
            RtnStr = objUcls.Operators_Delete(UserSlno)
            If RtnStr = "SUCCESS" Then
                FilldataGrid(PageIndex)
                StartUpScript("", "Record Deleted Successfully")
            Else
                StartUpScript("", RtnStr)
            End If

        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try

    End Sub

    Private Sub dgVusers_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgVusers.PageIndexChanged
        Try
            dsV = Session("ViewAllUsers_DataSet")
            dgVusers.CurrentPageIndex = e.NewPageIndex
            PageIndex = e.NewPageIndex
            Me.ViewState("PageIndex") = PageIndex
            dgVusers.DataSource = dsV.Tables(0)
            dgVusers.DataBind()
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub dgVusers_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgVusers.SortCommand
        Try
            dsV = Session("ViewAllUsers_DataSet")
            dsV.Tables(0).DefaultView.Sort = e.SortExpression
            dgVusers.DataSource = dsV.Tables(0)
            dgVusers.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgVusers_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgVusers.ItemCommand

        If e.CommandSource.id = "BtnUnRegister" Then

            Dim UserSlno As Integer = dgVusers.Items(e.Item.ItemIndex).Cells(1).Text
            Dim RtnStr As String = ""
            If UserSlno = 1 Then
                StartUpScript("", "Admin user can not Modify.")
                Exit Sub
            End If
            RtnStr = objUcls.ClientMac_Delete(UserSlno)
            If RtnStr = "SUCCESS" Then
                FilldataGrid(PageIndex)
                StartUpScript("", " User UnRegistered ")
            End If

        End If

    End Sub

#End Region

#Region "Image Buttons"

    Private Sub ibtnSingle_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnSingle.Click
        Try
            Response.Redirect("../Security/EmpEBMapping.aspx?Mode=New")
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub drpAcaSlno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpAcaSlno.SelectedIndexChanged
        Try
            FillExamBranchs()
            FilldataGrid(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub iBtnSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSearch.Click
        Try
            FilldataGrid(0)
        Catch ex As Exception

        End Try
    End Sub

#End Region


#Region " ASR R & d "



    'If e.CommandSource.id = "BtnUnRegister" Then
    '    'Dim BTN1 As Button = CType(CType((e.CommandSource).CommandSource, Object), System.Web.UI.WebControls.Button)
    '    'BTN1.Attributes.Add("onclick", "return confirm('Are you sure you want to UnRegister This User ?')")

    '    'RegisterStartupScript("JavaScript", "<script language=javascript>  return confirm('Are you sure you want to UnRegister This User ?' ); </script>")


    'End If






    'Dim confirmResult As Boolean
    'RegisterStartupScript("JavaScript", "<script language=JavaScript> " & confirmResult = "return confirm( 'The applicant has been sent a form. Send another?' );</script>")

    'If confirmResult Then
    '    StartUpScript("", " OK ")
    'Else
    '    StartUpScript("", " Cancel ")
    'End If


    '        ButtonClickEvent()
    '{
    '    bool validationResult = PerformValidation(); 

    '    if(validationResult == true)
    '    {
    '      bool confirmResult = ClientScript.RegisterStartupScript(this.GetType(), "msgbxConfirm", "<script language=JavaScript>"
    '                    + "return confirm( 'The applicant has been sent a form. Send another?' );</script>");

    '      if(confirmResult == true)
    '      {
    '            // Perform task
    '      }
    '            Else
    '      {
    '            // Do Nothing
    '      }
    '    }
    '}

#End Region


End Class
