'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is Presentation Layer For User Type Creation
'   ACTIVITY                          : New UserType
'   AUTHOR                            : Amarendra
'   INITIAL BASELINE DATE             : 10-FEB-2006
'   FINAL BASELINE DATE               : 10-FEB-2006
'   MODIFICATIONS LOG                 : Nil
'   CLASS FILE PATH                   : CollegeAdmitionDLL/Security/UserClass.vb
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Imports CollegeBoardDLL.WebTree
Imports System.Data.OracleClient
Imports System.Data

Public Class CreateUsers
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents dgUserType As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ibtnAdd As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblUserType As System.Web.UI.WebControls.Label
    Protected WithEvents txtUserName As System.Web.UI.WebControls.TextBox
    Protected WithEvents UserPanel As System.Web.UI.WebControls.Panel
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtDesc As System.Web.UI.WebControls.TextBox
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
    Private username As String
    Private ds As New DataSet
    Private webcls As New WebTree
    Private Formname As String = "Form1"
    Private objUcls As UserClass
    Private DsGrid As DataSet
    Private RtnString, MODE As String
    Private SLNO, PageIndex As Integer
    Dim ClsUty As New Utility
#End Region

#Region "Fill Methods"

    Private Sub FillGrid(ByVal PageIndex As Integer)
        Try
            Dim i As Integer
            Dim str As String
            str = "SELECT 0 DGSLNO,USERTYPESLNO,NAME,DESCRIPTION FROM E_USERTYPE_MT ORDER BY USERTYPESLNO"
            DsGrid = ClsUty.DataSet_Fetch(str)
            Session("UserType_DataSet") = DsGrid
            For i = 0 To DsGrid.Tables(0).Rows.Count - 1
                DsGrid.Tables(0).Rows(i)("DGSLNO") = i + 1
            Next

            If (DsGrid.Tables(0).Rows.Count - 1) / 10 < PageIndex Then

                If ((DsGrid.Tables(0).Rows.Count - 1) / 10) <= 1 Then
                    PageIndex = 0
                Else
                    PageIndex = PageIndex - 1
                End If
            End If

            dgUserType.CurrentPageIndex = PageIndex
            dgUserType.DataSource = DsGrid
            dgUserType.DataBind()

            If PageIndex = 0 Then
                For i = 0 To 3
                    Dim btn As Button = CType(dgUserType.Items(i).Cells(5).Controls(0), Button)
                    btn.Enabled = False
                Next
            End If

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Load Methods"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                If Not Request.QueryString("PageIndex") Is Nothing Then
                    PageIndex = CInt(Request.QueryString("PageIndex"))
                Else
                    PageIndex = 0
                End If
                Me.ViewState("PageIndex") = PageIndex
                FillGrid(PageIndex)
                UserPanel.Visible = False
            Else
                PageIndex = Me.ViewState("PageIndex")
            End If
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

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
                    Dim btn As Button = CType(e.Item.Cells(5).Controls(0), Button)
                    btn.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this record?')")
                    Exit Select
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function SetEntries() As ArrayList
        Try
            Dim Arr As New ArrayList

            If MODE = "EDIT" Then
                Arr.Add(SLNO)
                Arr.Add(UCase(Trim(txtUserName.Text)))

                If Trim(txtDesc.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(txtDesc.Text)))
                End If
            Else
                Arr.Add(UCase(Trim(txtUserName.Text)))
                If Trim(txtDesc.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(txtDesc.Text)))
                End If
            End If
            Return Arr
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function PageValidation() As Boolean
        Try
            If txtUserName.Text = "" Then
                StartUpScript(txtUserName.ID, "Please Enter UserType")
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub ClearFields()
        Try
            txtUserName.Text = ""
            txtDesc.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

#Region "Button Events"

    Private Sub ibtnAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnAdd.Click
        Try
            UserPanel.Visible = True
            StartUpScript(txtUserName.ID, "")
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ibtnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnSave.Click
        Try
            objUcls = New UserClass
            MODE = Me.ViewState("MODE")
            If PageValidation() Then
                If MODE = "EDIT" Then
                    RtnString = objUcls.UserType_Update(SetEntries())
                    If RtnString = "SUCCESS" Then
                        Me.ViewState("MODE") = "NEW"
                        StartUpScript(ibtnAdd.ID, "Record Updated Successfully")
                        ClearFields()
                        UserPanel.Visible = False
                        FillGrid(PageIndex)
                    Else
                        StartUpScript(ibtnSave.ID, RtnString)
                    End If
                Else
                    RtnString = objUcls.UserType_Insert(SetEntries())
                    If RtnString = "SUCCESS" Then
                        StartUpScript(ibtnAdd.ID, "Record Saved Successfully")
                        ClearFields()
                        UserPanel.Visible = False
                        FillGrid(PageIndex)
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

    Private Sub ibtnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnCancel.Click
        Try
            UserPanel.Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Grid Events"

    Private Sub dgUserType_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgUserType.EditCommand
        Try
            Dim Ds As DataSet
            MODE = "EDIT"
            Me.ViewState("MODE") = MODE
            objUcls = New UserClass
            Ds = objUcls.UserType_Select(dgUserType.Items(e.Item.ItemIndex).Cells(1).Text)
            txtUserName.Text = Ds.Tables(0).Rows(0)("NAME")
            If Not IsDBNull(Ds.Tables(0).Rows(0)("DESCRIPTION")) Then
                txtDesc.Text = Ds.Tables(0).Rows(0)("DESCRIPTION")
            End If
            UserPanel.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgUserType_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgUserType.DeleteCommand
        Try
            objUcls = New UserClass
            RtnString = objUcls.UserType_Delete(dgUserType.Items(e.Item.ItemIndex).Cells(1).Text)
            If RtnString = "SUCCESS" Then
                StartUpScript(ibtnAdd.ID, "Record Deleted Successfully")
                FillGrid(PageIndex)
            Else
                StartUpScript(ibtnAdd.ID, RtnString)
            End If
        Catch oex As OracleException
            StartUpScript("", DataBaseErrorMessage(oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub dgUserType_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgUserType.PageIndexChanged
        Try
            Dim i As Integer
            DsGrid = Session("UserType_DataSet")
            dgUserType.CurrentPageIndex = e.NewPageIndex
            Me.ViewState("PageIndex") = e.NewPageIndex
            PageIndex = Me.ViewState("PageIndex")
            dgUserType.DataSource = DsGrid
            dgUserType.DataBind()

            If PageIndex = 0 Then
                For i = 0 To 3
                    Dim btn As Button = CType(dgUserType.Items(i).Cells(5).Controls(0), Button)
                    btn.Enabled = False
                Next
            End If
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

#End Region






End Class
