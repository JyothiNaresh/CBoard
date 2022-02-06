'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : Changing the Existing Password
'   ACTIVITY                          : Change Password
'   AUTHOR                            : Srikanth
'   INITIAL BASELINE DATE             : 04-FEB-2006
'   FINAL BASELINE DATE               : 04-FEB-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports CollegeBoardDLL
Public Class ChangePassword
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtOpasswd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNpasswd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCpasswd As System.Web.UI.WebControls.TextBox
    Protected WithEvents ibtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ibtnCancel As System.Web.UI.WebControls.ImageButton

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
    Private FormName = "Form1"
    Private objUcls As UserClass
    Private RtnMsg As String
#End Region

#Region "Page Load Methods"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                StartUpScript(txtOpasswd.ID, "")
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

#Region "Common Methods"

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

    Private Function PageValidation() As Boolean
        Try
            If txtOpasswd.Text = "" Then
                StartUpScript(txtOpasswd.ID, "Please Enter Old Password")
                Return False
            ElseIf txtNpasswd.Text = "" Then
                StartUpScript(txtNpasswd.ID, "Please Enter New Password")
                Return False
            ElseIf txtCpasswd.Text = "" Then
                StartUpScript(txtCpasswd.ID, "Please Enter Confirm Password")
                Return False
            End If
            If Trim(txtNpasswd.Text) <> Trim(txtCpasswd.Text) Then
                StartUpScript(txtCpasswd.ID, "Confirm Password Not Matched")
                Return False
            End If
            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub ClearControls()
        Try
            txtOpasswd.Text = ""
            txtNpasswd.Text = ""
            txtCpasswd.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "ImageButton Events"

    Private Sub ibtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnSave.Click
        Try
            If PageValidation() Then
                objUcls = New UserClass
                RtnMsg = objUcls.CheckPasswd(Session("USERSLNO"), PasswordEncrypt.PasswordEncrypt.EncriptText(Trim(txtOpasswd.Text)), PasswordEncrypt.PasswordEncrypt.EncriptText(Trim(txtNpasswd.Text)))
                If RtnMsg = "SUCCESS" Then
                    StartUpScript("", "Your Password Updated SuccessFully")
                    Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
                ElseIf RtnMsg = "FAIL" Then
                    StartUpScript(txtOpasswd.ID, "Your Old Password is Incorrect")
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
            ClearControls()
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try

    End Sub

#End Region

End Class

