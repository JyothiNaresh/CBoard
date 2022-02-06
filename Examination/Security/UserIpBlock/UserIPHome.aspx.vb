Imports System.Data
Imports System.Data.OracleClient
Imports CollegeBoardDLL

Public Class UserIPHome
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents LblBranch As System.Web.UI.WebControls.Label
    Protected WithEvents DrpAdmExam As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgBBS As System.Web.UI.WebControls.DataGrid
    Protected WithEvents iBtnSingleMode As System.Web.UI.WebControls.ImageButton
    Protected WithEvents txtDeleteStatus As System.Web.UI.WebControls.TextBox

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
    Private RtnString As String
    Private DsGrid As DataSet
    Dim PageIndex As Integer = 0
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

    Protected Sub DeleteConformationMessage(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        Try
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Dim btn As Button = CType(e.Item.Cells(8).Controls(0), Button)
                    btn.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this record ?')")
                    Exit Select
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Fill Methos"

    Private Sub FillGrid(ByVal PgIndex As Integer)
        Try
            Dim i As Integer
            Dim Str As String

            If DrpAdmExam.SelectedValue = 1 Then
                Str = " SELECT UM.USERID,UM.USERSLNO,GWIP.GWUSERSLNO,GWIP.IPADDR,SCUT.IPCOUNT,GWIP.ADMOREXAM FROM T_USER_MT UM,GW_USERIP_MT GWIP, " & _
                      "	(SELECT USERSLNO,COUNT(*) IPCOUNT FROM GW_USERIP_MT WHERE FLAG=1 AND ADMOREXAM='A' GROUP BY USERSLNO) SCUT " & _
                      " WHERE UM.USERSLNO=GWIP.USERSLNO AND	UM.USERSLNO=SCUT.USERSLNO AND UM.ISIPCHECK<>0 AND GWIP.ADMOREXAM='A' AND GWIP.FLAG=1 ORDER BY UM.USERID"
            ElseIf DrpAdmExam.SelectedValue = 2 Then
                Str = " SELECT UM.USERID,UM.USERSLNO,GWIP.GWUSERSLNO,GWIP.IPADDR,SCUT.IPCOUNT,GWIP.ADMOREXAM FROM EXAM_USER_MT UM,GW_USERIP_MT GWIP, " & _
                      "	(SELECT USERSLNO,COUNT(*) IPCOUNT FROM GW_USERIP_MT WHERE FLAG=1 AND ADMOREXAM='E' GROUP BY USERSLNO) SCUT " & _
                      " WHERE UM.USERSLNO=GWIP.USERSLNO AND	UM.USERSLNO=SCUT.USERSLNO AND UM.ISIPCHECK<>0 AND GWIP.ADMOREXAM='E' AND GWIP.FLAG=1 ORDER BY UM.USERID"
            End If

            Utl = New Utility
            DsGrid = Utl.DataSet_Fetch(Str)
            Session("BranchWiseBankStatementHome_DataSet") = DsGrid

            If Not DsGrid Is Nothing Then
                '' Setting Page Indexs
                If (DsGrid.Tables(0).Rows.Count - 1) / 10 < PgIndex Then

                    If ((DsGrid.Tables(0).Rows.Count - 1) / 10) <= 1 Then
                        PgIndex = 0
                    Else
                        PgIndex = PgIndex - 1
                    End If
                End If
            End If

            dgBBS.DataSource = DsGrid
            dgBBS.DataBind()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Drop Down index changed events"

    Private Sub DrpAdmExam_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpAdmExam.SelectedIndexChanged
        Try
            FillGrid(PageIndex)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "Page Load Event"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Session("USERSLNO") Is Nothing Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                If Not Request.QueryString("PageIndex") Is Nothing Then PageIndex = Val(Request.QueryString("PageIndex"))
                Me.ViewState("PageIndex") = PageIndex
                FillGrid(PageIndex)
            Else
                PageIndex = Me.ViewState("PageIndex")
            End If
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
            If Session("USERID") Is Nothing Then
                OracleLogFile("USERID := " & "SRIHARI" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            Else
                OracleLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            End If
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                If Not Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                    "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                    StartUpScript("", GeneralErrorMessage(ex.Message))
                End If
            End If
        End Try
    End Sub

#End Region

#Region "Image Buttons"

    Private Sub iBtnSingleMode_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSingleMode.Click
        Try
            Response.Redirect("UserWiseIPBlock.aspx?MODE=NEW")
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                If Not Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                    "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                    StartUpScript("", GeneralErrorMessage(ex.Message))
                End If
            End If
        End Try
    End Sub

#End Region

#Region "Grid Events"

    Private Sub dgBBS_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgBBS.EditCommand
        Try
            Response.Redirect("UserWiseIPBlock.aspx?MODE=EDIT&SLNO=" & dgBBS.Items(e.Item.ItemIndex).Cells(1).Text)
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub dgBBS_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgBBS.DeleteCommand
        Try
            objBBS = New UserIPBlock
            RtnString = objBBS.UserWiseIPBlock_Delete(dgBBS.Items(e.Item.ItemIndex).Cells(1).Text, dgBBS.Items(e.Item.ItemIndex).Cells(2).Text, dgBBS.Items(e.Item.ItemIndex).Cells(5).Text, dgBBS.Items(e.Item.ItemIndex).Cells(6).Text)
            If RtnString = "SUCCESS" Then
                FillGrid(PageIndex)
                StartUpScript("", "Record Deleted Successfully")
            Else
                StartUpScript("", RtnString)
            End If
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub dgBBS_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgBBS.PageIndexChanged
        Try
            DsGrid = Session("BranchWiseBankStatementHome_DataSet")
            dgBBS.CurrentPageIndex = e.NewPageIndex
            dgBBS.DataSource = DsGrid
            dgBBS.DataBind()
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

#End Region

End Class
