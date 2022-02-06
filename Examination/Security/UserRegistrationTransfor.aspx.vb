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

Public Class UserRegistrationTransfor
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpCSSearch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtUserNameId As System.Web.UI.WebControls.TextBox
    Protected WithEvents IbtnUserSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpToUser As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtNoofHours As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpSearch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents LblDisplaySearch As System.Web.UI.WebControls.Label
    Protected WithEvents TxtEmpNameNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents ImgEmpNameNoSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpFromUser As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtUid As System.Web.UI.WebControls.TextBox
    Protected WithEvents ibtSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ibtnRevote As System.Web.UI.WebControls.ImageButton
    Protected WithEvents PnlRevert As System.Web.UI.WebControls.Panel
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpReSearch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtRevUseId As System.Web.UI.WebControls.TextBox
    Protected WithEvents IbtnRevSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Imagebutton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents IbtnCancle As System.Web.UI.WebControls.ImageButton
    Protected WithEvents DrpRevUsers As System.Web.UI.WebControls.DropDownList

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
            If DrpToUser.SelectedValue = 0 OrElse DrpToUser.SelectedIndex = -1 Then
                StartUpScript(DrpToUser.ID, " Select To User ")
                Return False
            ElseIf Val(Trim(TxtNoofHours.Text)) <= 0 Then
                StartUpScript(TxtNoofHours.ID, " Enter No.Of Hours ")
                Return False
            ElseIf DrpFromUser.SelectedValue = 0 OrElse DrpFromUser.SelectedIndex = -1 Then
                StartUpScript(DrpFromUser.ID, " Select From User ")
                Return False
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " Load Event "

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
                FillToUsers(1)
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

    Private Sub FillToUsers(ByVal SFor As Integer)
        Try
            Dim StrWhere As String
            DrpFromUser.Items.Clear()


            If SFor = 2 Then
                If DrpSearch.SelectedValue = 1 Then
                    StrWhere = " AND NAME LIKE '%" & UCase(Trim(TxtEmpNameNo.Text)) & "%'"
                ElseIf DrpSearch.SelectedValue = 2 Then
                    StrWhere = " AND USERID  LIKE '%" & UCase(Trim(TxtEmpNameNo.Text)) & "%'"
                End If
            End If

            ClsUty = New Utility
            ds = ClsUty.DataSet_OneFetch("SELECT USERSLNO,USERID||'-->'||NAME USERID,NAME  " & _
                              " FROM EXAM_USER_MT WHERE STATUS='A' AND USERTRANS=0 " & StrWhere & _
                              " ORDER  BY NAME ")

            If ds.Tables(0).Rows.Count > 0 Then
                DrpFromUser.DataSource = ds
                DrpFromUser.DataTextField = "USERID"
                DrpFromUser.DataValueField = "USERSLNO"
                DrpFromUser.DataBind()
            End If


            DrpFromUser.Items.Insert(0, New ListItem("  ---- Select ---  ", 0))

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillUsers(ByVal SFor As Integer)
        Try
            Dim StrWhere As String
            DrpToUser.Items.Clear()


            If SFor = 2 Then
                If DrpSearch.SelectedValue = 1 Then
                    StrWhere = " AND  NAME LIKE '%" & UCase(Trim(TxtUserNameId.Text)) & "%'"
                ElseIf DrpSearch.SelectedValue = 2 Then
                    StrWhere = " AND USERID LIKE '%" & UCase(Trim(TxtUserNameId.Text)) & "%'"
                End If
            End If

            ClsUty = New Utility
            ds = ClsUty.DataSet_OneFetch("SELECT USERSLNO,USERID||'-->'||NAME USERID,NAME  " & _
                                         " FROM EXAM_USER_MT  WHERE STATUS='A' AND  USERTRANS=0 " & StrWhere & _
                                         " ORDER  BY NAME ")

            If ds.Tables(0).Rows.Count > 0 Then
                DrpToUser.DataSource = ds
                DrpToUser.DataTextField = "USERID"
                DrpToUser.DataValueField = "USERSLNO"
                DrpToUser.DataBind()
            End If

            DrpToUser.Items.Insert(0, New ListItem("  ---- Select ---  ", 0))

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillReventsUsers(ByVal SFor As Integer)
        Try
            Dim StrWhere As String
            DrpFromUser.Items.Clear()


            If SFor = 2 Then
                If DrpSearch.SelectedValue = 1 Then
                    StrWhere = " AND NAME LIKE '%" & UCase(Trim(TxtRevUseId.Text)) & "%'"
                ElseIf DrpSearch.SelectedValue = 2 Then
                    StrWhere = " AND USERID  LIKE '%" & UCase(Trim(TxtRevUseId.Text)) & "%'"
                End If
            End If

            ClsUty = New Utility
            ds = ClsUty.DataSet_OneFetch("SELECT USERSLNO,USERID||'-->'||NAME USERID,NAME  " & _
                              " FROM EXAM_USER_MT WHERE STATUS='A' AND USERTRANS=1 " & StrWhere & _
                              " ORDER  BY NAME ")

            If ds.Tables(0).Rows.Count > 0 Then
                DrpRevUsers.DataSource = ds
                DrpRevUsers.DataTextField = "USERID"
                DrpRevUsers.DataValueField = "USERSLNO"
                DrpRevUsers.DataBind()
            End If


            DrpFromUser.Items.Insert(0, New ListItem("  ---- Select ---  ", 0))

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " Button Events "

    Private Sub ibtSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtSave.Click
        Try
            If PageValidations() Then
                objUscls = New UserClass
                RtnStr = objUscls.UserRegistrationTrans(DrpToUser.SelectedValue, DrpFromUser.SelectedValue, Val(TxtNoofHours.Text))
                If RtnStr = "SUCCESS" Then
                    FillUsers(2)
                    StartUpScript(DrpFromUser.ID, " User Registration Transfers Successfully..")
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
            FillToUsers(2)
        Catch ex As Exception

        End Try
    End Sub

#End Region


    Private Sub ibtnRevote_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnRevote.Click
        Try
            FillReventsUsers(1)
            PnlRevert.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Imagebutton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Imagebutton1.Click
        Try
            If DrpRevUsers.SelectedIndex = -1 Then
                StartUpScript(DrpRevUsers.ID, " Select Revent User ")
                Exit Sub
            End If

            objUscls = New UserClass
            RtnStr = objUscls.UserRegistrationRevents(DrpRevUsers.SelectedValue)
            If RtnStr = "SUCCESS" Then
                PnlRevert.Visible = False
                StartUpScript(DrpFromUser.ID, " User Registration Revents Successfully..")
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
