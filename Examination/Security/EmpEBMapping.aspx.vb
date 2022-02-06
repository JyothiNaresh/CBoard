'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is Presentation Layer For Mapping Emplyoee Wise Users View
'   ACTIVITY                          : UsersView
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 13-Aug-2008
'   FINAL BASELINE DATE               : 
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Imports System.Data.OracleClient
Public Class EmpEBMapping
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents drpAcaSlno As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpExamBranch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpDepartment As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ibtnSingle As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpEmployees As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpUser As System.Web.UI.WebControls.DropDownList
    Protected WithEvents iBtnBatchUpdate As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpUserTypes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpDesignation As System.Web.UI.WebControls.DropDownList

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

    Dim EMPSLNO As Integer
    Dim UNIQUENO As Integer

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


    Private Sub SetValue()
        Try
            If DrpEmployees.SelectedIndex <> -1 Then

                Dim ASR() As String

                ASR = DrpEmployees.SelectedValue.ToString.Split(",")

                EMPSLNO = ASR(0)
                Me.ViewState("EMPSLNO") = EMPSLNO

                UNIQUENO = ASR(1)
                Me.ViewState("UNIQUENO") = UNIQUENO


            End If


        Catch ex As Exception

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
                FillDepartments()
                FillDesignations()
                FillExamBranchs()
                FillUsersType()
                FillEmployees()
                FillUsers()
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


    Private Sub FillUsersType()
        Try
            Dim dsStuType As DataSet
            dsStuType = ClsUty.DataSet_Fetch("SELECT USERTYPESLNO,NAME FROM E_USERTYPE_MT WHERE USERTYPESLNO<>1 ORDER BY NAME")
            DrpUserTypes.DataSource = dsStuType
            DrpUserTypes.DataTextField = "NAME"
            DrpUserTypes.DataValueField = "USERTYPESLNO"
            DrpUserTypes.DataBind()
            'DrpUserTypes.SelectedValue = UserTypeslno
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillDepartments()
        Try
            Dim Ds As DataSet
            ClsUty = New Utility

            If Me.Session("CORS") = "C" Then
                Ds = ClsUty.DataSet_OneFetch(" SELECT DISTINCT A.DEPARTMENTSLNO ,A.NAME FROM " & _
                                            " PAYROLLNEW.P_DEPARTMENT_MT A,PAYROLLNEW.P_OFF_CAT_SC_DEPT_DESIG_MT B WHERE B.OFFICETYPESLNO IN (1,9) " & _
                                            " AND A.DEPARTMENTSLNO=B.DEPARTMENTSLNO ORDER BY NAME ")
            ElseIf Me.Session("CORS") = "S" Then
                Ds = ClsUty.DataSet_OneFetch(" SELECT DISTINCT A.DEPARTMENTSLNO ,A.NAME FROM " & _
                            " PAYROLLNEW.P_DEPARTMENT_MT A,PAYROLLNEW.P_OFF_CAT_SC_DEPT_DESIG_MT B WHERE B.OFFICETYPESLNO IN (2) " & _
                            " AND A.DEPARTMENTSLNO=B.DEPARTMENTSLNO ORDER BY NAME ")
            End If



            DrpDepartment.DataSource = Ds.Tables(0)
            DrpDepartment.DataTextField = "NAME"
            DrpDepartment.DataValueField = "DEPARTMENTSLNO"
            DrpDepartment.DataBind()

            DrpDepartment.Items.Insert(0, New ListItem("All", 0))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub FillDesignations()
        Try
            Dim Ds As DataSet
            ClsUty = New Utility

            Dim IDES As String

            If DrpDepartment.SelectedValue > 0 AndAlso DrpDepartment.SelectedIndex <> -1 Then
                IDES = " AND B.DEPARTMENTSLNO=" & DrpDepartment.SelectedValue
            End If


            If Me.Session("CORS") = "C" Then
                Ds = ClsUty.DataSet_OneFetch(" SELECT DISTINCT A.DESIGNATIONSLNO ,A.NAME FROM " & _
                                            " PAYROLLNEW.P_DESIGNATION_MT A,PAYROLLNEW.P_OFF_CAT_SC_DEPT_DESIG_MT B WHERE B.OFFICETYPESLNO IN (1,9) " & _
                                            " AND A.DESIGNATIONSLNO=B.DESIGNATIONSLNO " & IDES & " ORDER BY NAME ")
            ElseIf Me.Session("CORS") = "S" Then
                Ds = ClsUty.DataSet_OneFetch(" SELECT DISTINCT A.DESIGNATIONSLNO ,A.NAME FROM " & _
                            " PAYROLLNEW.P_DESIGNATION_MT A,PAYROLLNEW.P_OFF_CAT_SC_DEPT_DESIG_MT B WHERE B.OFFICETYPESLNO IN (2) " & _
                            " AND A.DESIGNATIONSLNO=B.DESIGNATIONSLNO  " & IDES & "  ORDER BY NAME ")
            End If



            DrpDesignation.DataSource = Ds.Tables(0)
            DrpDesignation.DataTextField = "NAME"
            DrpDesignation.DataValueField = "DESIGNATIONSLNO"
            DrpDesignation.DataBind()
            DrpDesignation.Items.Insert(0, New ListItem("All", 0))
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'Private Function FillEmployees()
    '    Try
    '        objUcls = New UserClass


    '        'dsV = ClsUty.DataSet_Fetch("SELECT UM.USERSLNO,UM.USERID,UM.NAME,TO_CHAR(UM.FROMDATE,'dd/MM/yyyy') FROMDATE,TO_CHAR(UM.TOFATE,'dd/MM/yyyy') TOFATE ," & _
    '        '                          " ( CASE WHEN UM.STATUS='A' THEN 'Acitve' ELSE 'Deleted' END) USERSTATUS," & _
    '        '                          " ( CASE WHEN UM.ISMACCHECK=0 THEN 'Un Register' ELSE 'Register' END) REGISTER ," & _
    '        '                          " EMP.CATEGORYNAME ||'-->'||EMP.SUBCATEGORYNAME ||'-->'||EMP.DEPARTMENTNAME ||'-->'||EMP.DESIGNATIONNAME EMPCODE , " & _
    '        '                          " EMP.DEPARTMENTNAME,EMP.EMPNO,EMP.EMPNO||' - '||EMP.SURNAME||' '||EMP.NAME EMPNAME," & _
    '        '                          " FROM EXAM_USER_MT UM,E_USER_BRANCH_ACADEMIC_MT U,PAYROLLNEW.V_EMP_DT EMP   " & _
    '        '                          " WHERE EMP.OFFICETYPESLNO IN (1,9) AND UM.EMPSLNO=EMP.USERSLNO AND UM.USERSLNO = U.USERSLNO AND " & _
    '        '                          " U.EXAMBRANCHSLNO=" & DrpExamBranch.SelectedValue.ToString & _
    '        '                          " AND U.COMACADEMICSLNO =" & drpAcaSlno.SelectedValue.ToString & _
    '        '                          " AND DEPARTMENTSLNO=" & DrpDepartment.SelectedValue.ToString & _
    '        '                          "  ORDER BY UM.USERID")



    '        If Me.Session("CORS") = "C" Then

    '            dsV = ClsUty.DataSet_Fetch("SELECT UM.USERSLNO,UM.USERID,UM.NAME,TO_CHAR(UM.FROMDATE,'dd/MM/yyyy') FROMDATE,TO_CHAR(UM.TOFATE,'dd/MM/yyyy') TOFATE ," & _
    '                                    " ( CASE WHEN UM.STATUS='A' THEN 'Acitve' ELSE 'Deleted' END) USERSTATUS," & _
    '                                    " ( CASE WHEN UM.ISMACCHECK=0 THEN 'Un Register' ELSE 'Register' END) REGISTER ," & _
    '                                    " EMP.CATEGORYNAME ||'-->'||EMP.SUBCATEGORYNAME ||'-->'||EMP.DEPARTMENTNAME ||'-->'||EMP.DESIGNATIONNAME EMPCODE , " & _
    '                                    " EMP.DEPARTMENTNAME,EMP.EMPNO,EMP.EMPNO||' - '||EMP.SURNAME||' '||EMP.NAME EMPNAME," & _
    '                                    " FROM EXAM_USER_MT UM,E_USER_BRANCH_ACADEMIC_MT U,PAYROLLNEW.V_EMP_DT EMP   " & _
    '                                    " WHERE EMP.OFFICETYPESLNO IN (1,9) AND UM.EMPSLNO=EMP.USERSLNO AND UM.USERSLNO = U.USERSLNO AND " & _
    '                                    " U.EXAMBRANCHSLNO=" & DrpExamBranch.SelectedValue.ToString & _
    '                                    " AND U.COMACADEMICSLNO =" & drpAcaSlno.SelectedValue.ToString & _
    '                                    " AND DEPARTMENTSLNO=" & DrpDepartment.SelectedValue.ToString & _
    '                                    "  ORDER BY UM.USERID")


    '        ElseIf Me.Session("CORS") = "S" Then

    '            dsV = ClsUty.DataSet_Fetch("SELECT UM.USERSLNO,UM.USERID,UM.NAME,TO_CHAR(UM.FROMDATE,'dd/MM/yyyy') FROMDATE,TO_CHAR(UM.TOFATE,'dd/MM/yyyy') TOFATE ," & _
    '                    " ( CASE WHEN UM.STATUS='A' THEN 'Acitve' ELSE 'Deleted' END) USERSTATUS," & _
    '                    " ( CASE WHEN UM.ISMACCHECK=0 THEN 'Un Register' ELSE 'Register' END) REGISTER ," & _
    '                    " EMP.CATEGORYNAME ||'-->'||EMP.SUBCATEGORYNAME ||'-->'||EMP.DEPARTMENTNAME ||'-->'||EMP.DESIGNATIONNAME EMPCODE , " & _
    '                    " EMP.DEPARTMENTNAME,EMP.EMPNO,EMP.EMPNO||' - '||EMP.SURNAME||' '||EMP.NAME EMPNAME," & _
    '                    " FROM EXAM_USER_MT UM,E_USER_BRANCH_ACADEMIC_MT U,PAYROLLNEW.V_EMP_DT EMP   " & _
    '                    " WHERE EMP.OFFICETYPESLNO =2 AND UM.EMPSLNO=EMP.USERSLNO AND UM.USERSLNO = U.USERSLNO AND " & _
    '                    " U.EXAMBRANCHSLNO=" & DrpExamBranch.SelectedValue.ToString & _
    '                    " AND U.COMACADEMICSLNO =" & drpAcaSlno.SelectedValue.ToString & _
    '                    " AND DEPARTMENTSLNO=" & DrpDepartment.SelectedValue.ToString & _
    '                    "  ORDER BY UM.USERID")

    '        End If



    '        If Not dsV Is Nothing Then
    '            If (dsV.Tables(0).Rows.Count - 1) / 10 < PageIndex Then
    '                If ((dsV.Tables(0).Rows.Count - 1) / 10) <= 1 Then
    '                    PageIndex = 0
    '                Else
    '                    PageIndex = PageIndex - 1
    '                End If
    '            End If

    '        End If
    '    Catch oex As OracleException
    '        Throw oex
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Private Sub FillEmployees()
        Try
            If DrpExamBranch.SelectedIndex <> -1 Then
                Dim Ds As New DataSet
                ClsUty = New Utility

                Dim StrWhere As String

                If DrpDepartment.SelectedValue > 0 Then
                    StrWhere = " AND DEPARTMENTSLNO=" & DrpDepartment.SelectedValue.ToString
                End If

                If DrpDesignation.SelectedValue > 0 Then
                    StrWhere &= " AND DESIGNATIONSLNO=" & DrpDesignation.SelectedValue.ToString
                End If

                If Me.Session("CORS") = "C" Then

                    Ds = ClsUty.DataSet_OneFetch("SELECT EMPSLNO||','||UNIQUENO||','||OFFICETYPESLNO SLNO, EMPSLNO,BIOEMPNO,UNIQUENO,OFFICETYPESLNO,CATEGORYNAME ||'-->'||SUBCATEGORYNAME ||'-->'||DEPARTMENTNAME ||'-->'||DESIGNATIONNAME EMPCODE,DEPARTMENTNAME,EMPNO,EMPNO||' --> '||SURNAME||' '||NAME||'-->'||DEPARTMENTNAME ||'-->'||DESIGNATIONNAME NAME,  " & _
                                                " PBRANCHSLNO,CATEGORYSLNO,SUBCATEGORYSLNO,DEPARTMENTSLNO,DESIGNATIONSLNO, " & _
                                                " CATEGORYNAME,SUBCATEGORYNAME,DEPARTMENTNAME,DESIGNATIONNAME " & _
                                                " FROM PAYROLLNEW.V_EMP_DT " & _
                                                " WHERE OFFICETYPESLNO IN (1,9) AND EXAMBRANCHSLNO=" & DrpExamBranch.SelectedValue.ToString & StrWhere)

                ElseIf Me.Session("CORS") = "S" Then

                    Ds = ClsUty.DataSet_OneFetch("SELECT EMPSLNO||','||UNIQUENO||','||OFFICETYPESLNO SLNO, EMPSLNO,BIOEMPNO,UNIQUENO,OFFICETYPESLNO,CATEGORYNAME ||'-->'||SUBCATEGORYNAME ||'-->'||DEPARTMENTNAME ||'-->'||DESIGNATIONNAME EMPCODE,DEPARTMENTNAME,EMPNO,EMPNO||' - '||SURNAME||' '||NAME||'-->'||DEPARTMENTNAME ||'-->'||DESIGNATIONNAME NAME,  " & _
                                     " PBRANCHSLNO,CATEGORYSLNO,SUBCATEGORYSLNO,DEPARTMENTSLNO,DESIGNATIONSLNO, " & _
                                     " CATEGORYNAME,SUBCATEGORYNAME,DEPARTMENTNAME,DESIGNATIONNAME " & _
                                     " FROM PAYROLLNEW.V_EMP_DT " & _
                                     " WHERE OFFICETYPESLNO=2 AND EXAMBRANCHSLNO=" & DrpExamBranch.SelectedValue.ToString & StrWhere)

                End If


                If Ds.Tables(0).Rows.Count > 0 Then

                    DrpEmployees.DataSource = Ds.Tables(0)
                    DrpEmployees.DataTextField = "NAME"
                    DrpEmployees.DataValueField = "EMPSLNO"
                    DrpEmployees.DataBind()

                    EMPSLNO = Ds.Tables(0).Rows(0)("EMPSLNO").ToString
                    Me.ViewState("EMPSLNO") = EMPSLNO

                    UNIQUENO = Ds.Tables(0).Rows(0)("UNIQUENO").ToString
                    Me.ViewState("UNIQUENO") = UNIQUENO

                Else

                    DrpEmployees.Items.Clear()

                End If
            Else
                StartUpScript(DrpExamBranch.ID, " Select Exam Branch ")
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
            If drpAcaSlno.SelectedIndex <> -1 Then
                Dim dsStuType As DataSet
                dsStuType = ClsUty.DataSet_Fetch("SELECT DISTINCT C.EXAMBRANCHSLNO,(C.EXAMBRANCHNAME || '-' || B.BRANCHSLNO) NAME FROM T_COMPANY_BRANCH_COURSE_MT A,T_BRANCH_MT B, EXAM_EXAMBRANCH C ,EXAM_ACYEXAMBRANCH_DT ACY WHERE ACY.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO AND ACY.COMACADEMICSLNO=A.COMACADEMICSLNO AND A.BRANCHSLNO=B.BRANCHSLNO AND C.BRANCHSLNO=B.BRANCHSLNO AND A.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " ORDER BY NAME")
                DrpExamBranch.DataSource = dsStuType
                DrpExamBranch.DataTextField = "NAME"
                DrpExamBranch.DataValueField = "EXAMBRANCHSLNO"
                DrpExamBranch.DataBind()

            Else
                drpAcaSlno.Items.Clear()
            End If

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillUsers()
        Try
            If drpAcaSlno.SelectedIndex <> -1 AndAlso DrpExamBranch.SelectedIndex <> -1 Then
                Dim Strng As String
                Strng = "SELECT UM.USERSLNO,UM.USERID||'-->'||UM.NAME||'-->'||EMP.EMPNO NAME ,TO_CHAR(UM.FROMDATE,'dd/MM/yyyy') FROMDATE,TO_CHAR(UM.TOFATE,'dd/MM/yyyy') TOFATE ," & _
                                        " ( CASE WHEN UM.STATUS='A' THEN 'Acitve' ELSE 'Deleted' END) USERSTATUS," & _
                                        " ( CASE WHEN UM.ISMACCHECK=0 THEN 'Un Register' ELSE 'Register' END) REGISTER " & _
                                        " FROM EXAM_USER_MT UM,E_USER_BRANCH_ACADEMIC_MT U,E_USER_USERTYPE_MT UUM ,PAYROLLNEW.V_EMP_DT EMP   " & _
                                        " WHERE UM.STATUS='A' AND EMP.EMPSLNO(+)=UM.EMPSLNO AND UM.USERSLNO = U.USERSLNO AND  UM.USERSLNO = UUM.USERSLNO AND UUM.COMACADEMICSLNO=U.COMACADEMICSLNO " & _
                                        "AND U.EXAMBRANCHSLNO=" & DrpExamBranch.SelectedValue.ToString & _
                                        " AND UUM.USERTYPESLNO=" & DrpUserTypes.SelectedValue.ToString & _
                                        " AND U.COMACADEMICSLNO =" & drpAcaSlno.SelectedValue.ToString & "  ORDER BY UM.USERID"
                objUcls = New UserClass
                dsV = ClsUty.DataSet_Fetch(Strng)

                DrpUser.DataSource = dsV.Tables(0)
                DrpUser.DataTextField = "NAME"
                DrpUser.DataValueField = "USERSLNO"
                DrpUser.DataBind()

            Else
                DrpUser.Items.Clear()
            End If

        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Image Buttons"

    Private Sub ibtnSingle_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnSingle.Click
        Try
            If DrpUser.SelectedIndex = -1 Then
                StartUpScript(DrpUser.ID, " Select User ")
                Exit Sub
            ElseIf DrpEmployees.SelectedIndex = -1 Then
                StartUpScript(DrpEmployees.ID, " Select DrpEmployee ")
                Exit Sub
            End If
            objUcls = New UserClass
            objUcls.EmpEbMapping(Val(DrpUser.SelectedValue), Val(DrpEmployees.SelectedValue))
            StartUpScript(DrpUser.ID, " Record Saved ")
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub iBtnBatchUpdate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnBatchUpdate.Click
        Response.Redirect("../Security/EmpEbMappingView.aspx?Mode=New")
    End Sub

#End Region

#Region " Combo Events "


    Private Sub drpAcaSlno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpAcaSlno.SelectedIndexChanged
        Try
            FillExamBranchs()
            FillEmployees()
            FillUsers()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrpDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpDepartment.SelectedIndexChanged
        Try
            FillDesignations()
            FillEmployees()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub drpExamBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpExamBranch.SelectedIndexChanged
        Try
            FillEmployees()
            FillUsers()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrpEmployees_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpEmployees.SelectedIndexChanged
        Try
            SetValue()
        Catch ex As Exception

        End Try
    End Sub



#End Region

   
    Private Sub DrpUserTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpUserTypes.SelectedIndexChanged
        FillUsers()
    End Sub

    Private Sub DrpDesignation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpDesignation.SelectedIndexChanged
        FillEmployees()
    End Sub
End Class
