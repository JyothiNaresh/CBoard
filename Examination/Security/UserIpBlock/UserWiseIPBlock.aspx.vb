Imports System.Data
Imports System.Data.OracleClient
Imports CollegeBoardDLL

Public Class UserWiseIPBlock
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents ibtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents drpAdmExam As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpUser As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtIP As System.Web.UI.WebControls.TextBox

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
    Private objBBS As UserIPBlock
    Private Utl As Utility
    Private FormName As String = "Form1"
    Private RtnString, MODE, SLNO As String
#End Region

#Region "Methos"

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

    Private Function SetEntries() As ArrayList
        Try
            Dim Arr As New ArrayList
            If MODE = "NEW" Then
                Arr.Add(drpAdmExam.SelectedValue)
                Arr.Add(DrpUser.SelectedValue)
                Arr.Add(Trim(txtIP.Text))

            ElseIf MODE = "EDIT" Then
                Arr.Add(SLNO)
                Arr.Add(Trim(txtIP.Text))
            End If

            Return Arr
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function Pagevalidations() As Boolean
        Try
            If Trim(txtIP.Text) = "" Then
                StartUpScript(txtIP.ID, "Please Enter IP Address")
                Return False
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub SetViewStateVariables()
        Try
            If Not Request.QueryString("MODE") Is Nothing Then MODE = Request.QueryString("MODE")
            If Not Request.QueryString("SLNO") Is Nothing Then SLNO = Request.QueryString("SLNO")
            Me.ViewState("MODE") = MODE
            Me.ViewState("SLNO") = SLNO
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetViewStateVariables()
        Try
            MODE = Me.ViewState("MODE")
            SLNO = Me.ViewState("SLNO")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ClearFields()
        Try
            txtIP.Text = ""
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Fill Methos"

    Private Sub FillUserCombo()
        Try
            Dim Ds As DataSet
            Utl = New Utility
            If drpAdmExam.SelectedValue = "A" Then
                Ds = Utl.DataSet_Fetch("SELECT USERSLNO SLNO,USERID NAME FROM T_USER_MT")
            Else
                Ds = Utl.DataSet_Fetch("SELECT USERSLNO SLNO,USERID NAME FROM EXAM_USER_MT")
            End If

            DrpUser.DataSource = Ds
            DrpUser.DataTextField = "NAME"
            DrpUser.DataValueField = "SLNO"
            DrpUser.DataBind()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillControls()
        Try
            Dim Ds As DataSet
            objBBS = New UserIPBlock
            Ds = objBBS.UserWiseIpBlock_Select(SLNO, drpAdmExam.SelectedValue)
            If drpAdmExam.SelectedValue = "A" Then
                drpAdmExam.SelectedValue = "A"
            Else
                drpAdmExam.SelectedValue = "B"
            End If

            FillUserCombo()
            DrpUser.SelectedValue = Ds.Tables(0).Rows(0)("USERSLNO")
            txtIP.Text = Ds.Tables(0).Rows(0)("IPADDR")
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Page Load Event"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                SetViewStateVariables()

                If MODE = "EDIT" Then
                    drpAdmExam.Enabled = False
                    FillControls()
                Else
                    drpAdmExam.Enabled = True
                    FillUserCombo()
                End If
            Else
                GetViewStateVariables()
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

#Region "Image Buttons"

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnSave.Click

        Try
            objBBS = New UserIPBlock
            If Pagevalidations() Then
                If MODE = "EDIT" Then
                    RtnString = objBBS.UserWiseIPBlock_Update(SetEntries())
                    If RtnString = "SUCCESS" Then
                        ClearFields()
                        Me.ViewState("MODE") = "NEW"
                        StartUpScript(ibtnSave.ID, "Record Updated Successfully")
                    Else
                        StartUpScript(ibtnSave.ID, RtnString)
                    End If
                ElseIf MODE = "NEW" Then
                    RtnString = objBBS.UserWiseIPBlock_Insert(SetEntries())
                    If RtnString = "SUCCESS" Then
                        ClearFields()
                        StartUpScript(ibtnSave.ID, "Record Saved Successfully")
                    Else
                        StartUpScript(ibtnSave.ID, RtnString)
                    End If
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

#Region "Index Change"

    Private Sub drpAdmExam_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpAdmExam.SelectedIndexChanged
        Try
            FillUserCombo()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class
