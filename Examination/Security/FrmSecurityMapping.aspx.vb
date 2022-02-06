'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : File Management V 1.0
'   OBJECTIVE                         : This is Presentation Layer For UserCreation
'   ACTIVITY                          : New UserCreation
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 21-Oct-2008
'   FINAL BASELINE DATE               : 21-Oct-2008
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Imports PasswordEncrypt
Imports CollegeBoardDLL.WebTree
Imports System.Data.OracleClient

Public Class FrmSecurityMapping
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpSearch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents LblDisplaySearch As System.Web.UI.WebControls.Label
    Protected WithEvents TxtEmpNameNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents ImgEmpNameNoSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpEmployees As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtUid As System.Web.UI.WebControls.TextBox

    Protected WithEvents ibtSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ibtnCancel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpCSSearch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TxtUserNameId As System.Web.UI.WebControls.TextBox
    Protected WithEvents IbtnUserSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents DrpCoScUsers As System.Web.UI.WebControls.DropDownList

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
    Private Mode As String
    Private userslno As Integer
    Private objUscls As UserClass
    Private RtnStr As String
    Private ClsUty As Utility
#End Region

#Region "General Methods"

 

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

    Private Function PageValidations() As Boolean
        Try
            Dim i, j As Integer

            If DrpEmployees.SelectedValue = 0 OrElse DrpEmployees.SelectedIndex = -1 Then
                StartUpScript(DrpEmployees.ID, " Select Employee ")
                Return False
            ElseIf DrpCoScUsers.SelectedValue = 0 OrElse DrpCoScUsers.SelectedIndex = -1 Then
                StartUpScript(DrpCoScUsers.ID, " Select User ")
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
            If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../Home.aspx','_top');</script>")
            Mode = Request.QueryString("Mode")
            userslno = CInt(Request.QueryString("userslno"))
            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                'OfficetypecomboxFill()
                'FillPayrollBranches()
                FillEmployees(1)
                FillUsers(1)

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

    'Private Sub OfficetypecomboxFill()
    '    Try
    '        Dim cs As DataSet
    '        ClsUty = New Utility
    '        ds = ClsUty.DataSet_OneFetch("SELECT OFFICETYPESLNO SLNO,NAME FROM MASTERS.M_OFFICETYPE_MT ORDER BY SLNO")
    '        drpCStype.DataSource = ds
    '        drpCStype.DataTextField = "NAME"
    '        drpCStype.DataValueField = "SLNO"
    '        drpCStype.DataBind()
    '        ' drpCStype.Items.Insert(0, New ListItem("All", 0))
    '    Catch oex As OracleException
    '        Throw oex
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub FillPayrollBranches()
    '    Try
    '        ClsUty = New Utility
    '        ds = ClsUty.DataSet_OneFetch("SELECT PBRANCHSLNO,NAME FROM PAYROLLNEW.V_BRANCH_MT WHERE OFFICETYPESLNO=" & drpCStype.SelectedValue.ToString & " ORDER BY NAME ")

    '        If ds.Tables(0).Rows.Count > 0 Then
    '            DrpParolBarnch.DataSource = ds
    '            DrpParolBarnch.DataTextField = "NAME"
    '            DrpParolBarnch.DataValueField = "PBRANCHSLNO"
    '            DrpParolBarnch.DataBind()
    '        End If

    '    Catch Oex As OracleException
    '        Throw Oex
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub FillEmployees(ByVal SFor As Integer)
        Try
            Dim StrWhere As String
            DrpEmployees.Items.Clear()


            If SFor = 2 Then
                If DrpSearch.SelectedValue = 1 Then
                    StrWhere = " AND UM.NAME LIKE '%" & UCase(Trim(TxtEmpNameNo.Text)) & "%'"
                ElseIf DrpSearch.SelectedValue = 2 Then
                    StrWhere = " AND UM.BIOEMPNO = " & Val(Trim(TxtEmpNameNo.Text))
                End If
            End If

            ClsUty = New Utility
            ds = ClsUty.DataSet_OneFetch("SELECT TO_CHAR(NVL(EMP.EMPSLNO,0))||','||TO_CHAR(NVL(EMP.BIOEMPNO,0))||','||TO_CHAR(UM.USERSLNO) USERSLNO,EMP.BIOEMPNO, EMP.NAME,UM.USERSLNO, UM.USERID||'-->'||UM.NAME||'-->'||EMP.EMPNO||'-->'||EMP.CATEGORYNAME ||'-->'||EMP.SUBCATEGORYNAME||'-->'||EMP.DEPARTMENTNAME||'-->'||EMP.DESIGNATIONNAME EMPNAME ,  " & _
                                         " EMP.PBRANCHSLNO,EMP.CATEGORYSLNO,EMP.SUBCATEGORYSLNO,EMP.DEPARTMENTSLNO,EMP.DESIGNATIONSLNO, " & _
                                         " EMP.CATEGORYNAME,EMP.SUBCATEGORYNAME,EMP.DEPARTMENTNAME,EMP.DESIGNATIONNAME " & _
                                         " FROM PAYROLLNEW.V_EMP_DT EMP,FILESMANAGER.FM_USER_MT UM " & _
                                         " WHERE EMP.BIOEMPNO(+)=UM.BIOEMPNO " & StrWhere & " ORDER  BY EMP.NAME ")

            If ds.Tables(0).Rows.Count > 0 Then
                DrpEmployees.DataSource = ds
                DrpEmployees.DataTextField = "EMPNAME"
                DrpEmployees.DataValueField = "USERSLNO"
                DrpEmployees.DataBind()
            End If
          

            DrpEmployees.Items.Insert(0, New ListItem("  ---- Select ---  ", "0,0,0"))

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillUsers(ByVal SFor As Integer)
        Try
            Dim StrWhere As String
            DrpCoScUsers.Items.Clear()


            If SFor = 2 Then
                If DrpSearch.SelectedValue = 1 Then
                    StrWhere = " AND  NAME LIKE '%" & UCase(Trim(TxtUserNameId.Text)) & "%'"
                ElseIf DrpSearch.SelectedValue = 2 Then
                    StrWhere = " AND USERID LIKE '%" & UCase(Trim(TxtUserNameId.Text)) & "%'"
                End If
            End If

            ClsUty = New Utility
            ds = ClsUty.DataSet_OneFetch("SELECT TO_CHAR(NVL(USERSLNO,0))||','||TO_CHAR(NVL(EMPSLNO,0)) USERSLNO,USERID||'-->'||NAME USERID,NAME  " & _
                                         " FROM EXAM_USER_MT WHERE STATUS='A'  " & StrWhere & _
                                         " ORDER  BY USERID ")

            If ds.Tables(0).Rows.Count > 0 Then
                DrpCoScUsers.DataSource = ds
                DrpCoScUsers.DataTextField = "USERID"
                DrpCoScUsers.DataValueField = "USERSLNO"
                DrpCoScUsers.DataBind()
            End If

            DrpCoScUsers.Items.Insert(0, New ListItem("  ---- Select ---  ", "0,0"))

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
                RtnStr = objUscls.UserMacVastTrans(DrpEmployees.SelectedValue, Val(txtUid.Text))
                If RtnStr = "SUCCESS" Then
                    FillUsers(2)
                    StartUpScript(DrpEmployees.ID, " User Mapped Successfully..")
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

    Private Sub IbtnUserSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnUserSearch.Click
        Try
            FillUsers(2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImgEmpNameNoSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgEmpNameNoSearch.Click
        Try
            FillEmployees(2)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Combo Events"

    Private Sub DrpCoScUsers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpCoScUsers.SelectedIndexChanged
        Try
            If DrpCoScUsers.SelectedIndex <> -1 Then
                Dim ASR() As String
                ASR = Trim(DrpCoScUsers.SelectedValue.ToString).Split(",")
                txtUid.Text = ASR(0)
                If Val(ASR(1)) > 0 Then
                    StartUpScript(DrpCoScUsers.ID, " This User Already Mapped ")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class
