Imports CollegeBoardDLL
Imports PasswordEncrypt
Imports System.Data.OracleClient

Public Class home
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'Test comment.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hlChangePassword As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlForgetPassword As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtUserId As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPwd As System.Web.UI.WebControls.TextBox
    Protected WithEvents drpAcyear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents iBtnSubmit As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Txt1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txt2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txt3 As System.Web.UI.WebControls.TextBox

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

    Private FormName As String = "Form1"
    Private ds As DataSet
    Private objUcls As UserClass

#End Region

#Region "Page Load Event"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IsPostBack Then
                If Not Session("USERLOGSLNO") Is Nothing Then
                    'UserLogOut
                    Dim dsUser As String
                    dsUser = Me.ID
                    objUcls = New UserClass
                    dsUser = objUcls.UserLogOut(Session("USERLOGSLNO"))
                End If
                Session.RemoveAll()
                Session.Abandon()
                FillAcademicyear()
                StartUpScript(txtUserId.ID)
            End If
            '''StartUpScript(txtUserId.ID, "")
        Catch Oex As OracleException
            lblMessage.Text = DataBaseErrorMessage(Oex.Message)
            OracleLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
             "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                lblMessage.Text = GeneralErrorMessage(ex.Message)
            End If
            IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
             "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
        End Try
    End Sub

#End Region

#Region "Methods"

    Private Sub FillAcademicyear()
        '''Try
        '''    ds = New DataSet
        '''    ds = Utility.DataSet_Fetch("SELECT COMACADEMICSLNO,NAME FROM MASTERS.T_COMPANYACADEMICYEAR_MT")
        '''    drpAcyear.DataSource = ds
        '''    drpAcyear.DataTextField = "COMACADEMICSLNO"
        '''    drpAcyear.DataValueField = "COMACADEMICSLNO"
        '''    drpAcyear.DataBind()
        '''Catch Oex As OracleException
        '''    Throw Oex
        '''Catch ex As Exception
        '''    Throw ex
        '''End Try
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

    Private Function PageValidation() As Boolean
        If Trim(txtUserId.Text) = "" Then
            lblMessage.Text = "Enter UserName."
            StartUpScript(txtUserId.ID, "")
            Return False
        ElseIf Trim(txtPwd.Text) = "" Then
            lblMessage.Text = "Enter Password."
            StartUpScript(txtPwd.ID, "")
            Return False
        ElseIf drpAcyear.SelectedValue = 0 Then
            lblMessage.Text = "Select Code."
            StartUpScript(drpAcyear.ID, "")
            Return False
        End If

        Return True

    End Function

#End Region

#Region "Image Buttons"

    Private Sub iBtnSubmit_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSubmit.Click
        Try
            If Not PageValidation() Then Exit Sub

            Dim dsUser As DataSet
            Dim isadmin As Integer = 0
            objUcls = New UserClass
            dsUser = objUcls.CheckUser(Trim(txtUserId.Text), PasswordEncrypt.PasswordEncrypt.EncriptText(Trim(txtPwd.Text)), drpAcyear.SelectedValue, Request.ServerVariables("REMOTE_HOST"), Trim(Txt1.Text), Trim(Txt2.Text), Trim(Txt3.Text))
            If Trim(txtUserId.Text) <> "ADMIN" Then
                If drpAcyear.SelectedIndex = -1 Then
                    lblMessage.Text = "Select Academic Year."
                    Exit Sub
                End If
            End If
            If Not dsUser Is Nothing Then
                If dsUser.Tables(0).Rows.Count > 0 Then
                    Session("USERSLNO") = dsUser.Tables(0).Rows(0)("USERSLNO")
                    Session("USERTYPESLNO") = dsUser.Tables(0).Rows(0)("USERTYPESLNO")
                    Session("USERID") = dsUser.Tables(0).Rows(0)("USERID")
                    Session("SERVERDATE") = dsUser.Tables(0).Rows(0)("SERVERDATE")
                    Session("COMACADEMICSLNO") = drpAcyear.SelectedValue
                    Session("ACYEAR") = drpAcyear.SelectedItem.Text
                    Session("USERSUBBATCH") = dsUser.Tables(0).Rows(0)("USERSUBBATCH")
                    ' Session("TRANSDATE") = dsUser.Tables(0).Rows(0)
                    Session("ISMACCHECK") = dsUser.Tables(0).Rows(0)("ISMACCHECK")

                    If Not IsDBNull(dsUser.Tables(0).Rows(0)("COMBINATIONKEY")) Then
                        Session("COMBINATIONKEY") = dsUser.Tables(0).Rows(0)("COMBINATIONKEY")
                    Else
                        Session("COMBINATIONKEY") = 0
                    End If

                    Session("CORS") = dsUser.Tables(0).Rows(0)("COLLEGEORSCHOOL")

                    If Session("CORS") = "C" Then
                        Me.Session("MODULESLNO") = 2
                        Me.Session("APPLICATIONSLNO") = 5
                        'If Session("USERSLNO") = 79 Or Session("USERSLNO") = 98 Or Session("USERSLNO") = 269 Or Session("USERSLNO") = 270 Or Session("USERSLNO") = 308 Then
                        '    isadmin = 1
                        'End If
                    ElseIf Session("CORS") = "S" Then
                        Me.Session("MODULESLNO") = 4
                        Me.Session("APPLICATIONSLNO") = 6

                        'If Session("USERSLNO") = 19 Or Session("USERSLNO") = 20 Or Session("USERSLNO") = 83 Or Session("USERSLNO") = 84 Then
                        '    isadmin = 1
                        'End If
                    End If
                    If Val(dsUser.Tables(0).Rows(0)("ISMACCHECK")) = 0 Then
                        Response.Redirect("../CollegeBoard/Examination/Security/ValidationsUsTo.aspx")
                    Else
                        objUcls = New UserClass
                        Dim LOGSLNO As Integer = objUcls.UserLogin(Session("USERSLNO"), Session("APPLICATIONSLNO"), Session("USERID"), Session("COMACADEMICSLNO"))
                        Session("USERLOGSLNO") = LOGSLNO
                        FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), "home")
                        ''Response.Redirect("../CollegeBoard/Examination/ExamBranchs/Exam_EBDesigMAP.aspx")
                        Response.Redirect("../CollegeBoard/Examination/Html/Content.aspx")
                    End If
                    ''Response.Redirect("../CollegeBoard/Examination/Html/Content.aspx")
                Else
                    lblMessage.Text = "Login Information failed"
                    StartUpScript(txtUserId.ID, "")
                End If
            Else
                lblMessage.Text = "Login Information failed"
                StartUpScript(txtUserId.ID, "")
            End If
        Catch Oex As OracleException
            lblMessage.Text = DataBaseErrorMessage(Oex.Message)
            If Session("USERID") Is Nothing Then
                OracleLogFile("USERID := " & "SRIHARI" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                             "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            Else
                OracleLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                             "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            End If

        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                lblMessage.Text = GeneralErrorMessage(ex.Message)
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

#End Region

End Class
