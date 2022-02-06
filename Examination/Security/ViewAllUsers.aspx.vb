'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is Presentation Layer For Users View
'   ACTIVITY                          : UsersView
'   AUTHOR                            : Srikanth
'   INITIAL BASELINE DATE             : 09-MAY-2006
'   FINAL BASELINE DATE               : -JAN-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Imports System.Data.OracleClient

Public Class ViewAllUsers
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents ibtnSingle As System.Web.UI.WebControls.ImageButton
    Protected WithEvents dgVusers As System.Web.UI.WebControls.DataGrid
    Protected WithEvents iBtnBatchUpdate As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents drpAcaSlno As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpUserTypes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents iBtnUser As System.Web.UI.WebControls.ImageButton
    Protected WithEvents TxtUserID As System.Web.UI.WebControls.TextBox
    Protected WithEvents DrpSearch As System.Web.UI.WebControls.DropDownList

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
                FillUsersType()
                SetViewStateData()
                FilldataGrid(PageIndex, 1)
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

    Private Function FilldataGrid(ByVal PageIndex As Integer, ByVal searchfor As Integer)
        Try
            objUcls = New UserClass
            Dim StrWhere As String = " AND UUM.USERTYPESLNO=" & DrpUserTypes.SelectedValue.ToString
            If searchfor = 2 Then
                If DrpSearch.SelectedValue = 1 Then
                    StrWhere = " AND UM.NAME LIKE '%" & UCase(Trim(TxtUserID.Text)) & "%'"
                ElseIf DrpSearch.SelectedValue = 2 Then
                    StrWhere = " AND UM.USERID LIKE '%" & UCase(Trim(TxtUserID.Text)) & "%'"
                ElseIf DrpSearch.SelectedValue = 3 Then
                    StrWhere = " AND DECODE(EB.EXAMBRANCHNAME,NULL,'-',EB.EXAMBRANCHNAME) LIKE '%" & UCase(Trim(TxtUserID.Text)) & "%'"
                ElseIf DrpSearch.SelectedValue = 4 Then
                    StrWhere = " AND DECODE(EMP.BRANCHNAME,NULL,'-',EMP.BRANCHNAME) LIKE '%" & UCase(Trim(TxtUserID.Text)) & "%'"
                End If
            End If
            dsV = ClsUty.DataSet_Fetch("SELECT UM.USERSLNO,UM.USERID,UM.NAME,TO_CHAR(UM.FROMDATE,'dd/MM/yyyy') FROMDATE,TO_CHAR(UM.TOFATE,'dd/MM/yyyy') TOFATE , UM.PASSWORD HINT, " & _
                                       " ( CASE WHEN UM.STATUS='A' THEN 'Active' WHEN UM.STATUS='R' THEN 'Resigned' WHEN UM.STATUS='T' THEN 'Transferred'  ELSE 'Deleted' END) USERSTATUS, ( CASE WHEN UM.ISMACCHECK=0 THEN 'Un-Reg' ELSE 'Register' END) REGISTER," & _
                                       " ( CASE WHEN UM.ISIPCHECK=0 THEN 'No' ELSE 'Yes' END) VSATSTATUS, DECODE(EB.EXAMBRANCHNAME,NULL,'-',EB.EXAMBRANCHNAME) EBRANCH,DECODE(EMP.BRANCHNAME,NULL,'-',EMP.BRANCHNAME) PBRANCH " & _
                                       " FROM EXAM_USER_MT UM,E_USER_USERTYPE_MT UUM,PAYROLLNEW.V_EMP_DT EMP, EXAM_EXAMBRANCH EB  " & _
                                       " WHERE UM.USERSLNO = UUM.USERSLNO AND NVL(UM.EMPSLNO,0)=EMP.EMPSLNO(+) AND EMP.EXAMBRANCHSLNO=EB.EXAMBRANCHSLNO(+) AND " & _
                                       " UUM.COMACADEMICSLNO =" & drpAcaSlno.SelectedValue.ToString & StrWhere & " ORDER BY UM.USERID")
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
                FilldataGrid(PageIndex, 1)
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
            RtnStr = objUcls.ClientMac_Delete(UserSlno, Session("USERSLNO"))
            If RtnStr = "SUCCESS" Then
                FilldataGrid(PageIndex,1)
                StartUpScript("", " User UnRegistered ")
            End If

        End If

    End Sub

#End Region

#Region "Image Buttons"

    Private Sub ibtnSingle_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnSingle.Click
        Try
            Response.Redirect("../Security/CreateOperatorsNew.aspx?Mode=New")
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub iBtnBatchUpdate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnBatchUpdate.Click
        Try
            Server.Transfer("MTMUserExamBranch.aspx?USERTYPESLNO=" & DrpUserTypes.SelectedValue.ToString)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub iBtnSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSearch.Click
        Try
            FilldataGrid(0, 1)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub iBtnUser_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnUser.Click
        Try
            FilldataGrid(0, 2)
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
