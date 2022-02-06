'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : Master Home
'   AUTHOR                            : 
'   INITIAL BASELINE DATE             : 
'   MODIFICATIONS LOG                 : Adding  Sub Caste by Kishore [09.Apr.2013]
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL

Public Class MastersHome
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtSetfocus As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents LblCourse As System.Web.UI.WebControls.Label
    Protected WithEvents dgGridBatch As System.Web.UI.WebControls.DataGrid
    Protected WithEvents iBtnSingle As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnBatch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnCancel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents cmdCancel As System.Web.UI.WebControls.Button
    Protected WithEvents txtMessage As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDeleteStatus As System.Web.UI.WebControls.TextBox
    Protected WithEvents DrpBoardMaster As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "CODE"

#Region "Class Variables"

    Private objBoardEnrollment As ClsBoardEnrollment
    Private Util As Utility
    Private DsSearchResult As DataSet
    Public From As String
    Public Str, StrSql As String
    Private Edit As String
    Private DsSearch As DataSet
    Public PageIndex As Integer
    Public SLNO, GANO, RtnVal As Integer
    Private objError As clsError
    Private DsFiles As New DataSet

#End Region

#Region "Page Load Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dgGridBatch.AllowPaging = True
            From = Request.QueryString("From")
            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                ButtonsHiding(Me.Page)
                'SLNO, GANO
                If Not Request.QueryString("SLNO") Is Nothing AndAlso Request.QueryString("SLNO") <> "" Then SLNO = Request.QueryString("SLNO")
                Me.ViewState("SLNO") = SLNO

                If Not Request.QueryString("GANO") Is Nothing AndAlso Request.QueryString("GANO") <> "" Then GANO = Request.QueryString("GANO")
                Me.ViewState("GANO") = GANO

                If Not Request.QueryString("PageIndex") Is Nothing AndAlso Request.QueryString("PageIndex") <> "" Then
                    PageIndex = CInt(Request.QueryString("PageIndex"))
                Else
                    PageIndex = 0
                End If
                If GANO <> 0 Then
                    DrpBoardMaster.SelectedValue = GANO
                End If

                Me.ViewState("PageIndex") = PageIndex

                FillGrid(PageIndex)

            Else
                PageIndex = CInt(Me.ViewState("PageIndex"))
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

#Region "ImageButton Events"

    Private Sub iBtnSingle_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSingle.Click
        Try
            Response.Redirect("MasterSingle.aspx?MODE=NEW&BENO=" & DrpBoardMaster.SelectedValue & "&HEAD=" & DrpBoardMaster.SelectedItem.Text)
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                StartUpScript(iBtnSingle.ID, " Transaction  Failed ")
            End If
        End Try

    End Sub

    Private Sub iBtnBatch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnBatch.Click

        Try
            Response.Redirect("MastersBatch.aspx?MODE=NEW&BENO=" & DrpBoardMaster.SelectedValue & "&HEAD=" & DrpBoardMaster.SelectedItem.Text)
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                StartUpScript(iBtnBatch.ID, " Transaction  Failed ")
            End If
        End Try

    End Sub

#End Region

#Region "Selected Change Events"

    Private Sub DrpBoardMaster_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpBoardMaster.SelectedIndexChanged
        Try

            FillGrid(PageIndex)

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Fill Methods"

    Private Sub FillGrid(ByVal PageIndex As Integer)
        Dim i, j As Integer

        Try

            objBoardEnrollment = New ClsBoardEnrollment

            DsSearchResult = objBoardEnrollment.Masters_Selectall(DrpBoardMaster.SelectedValue)

            Me.ViewState("DataSet") = DsSearchResult

            If Not DsSearchResult Is Nothing Then
                j = 1
                For i = 0 To DsSearchResult.Tables(0).Rows.Count - 1
                    DsSearchResult.Tables(0).Rows(i)("BESLNO") = j
                    j += 1
                Next
                '' Setting Page Indexs
                If (DsSearchResult.Tables(0).Rows.Count - 1) / 10 < PageIndex Then

                    If ((DsSearchResult.Tables(0).Rows.Count - 1) / 10) <= 1 Then
                        PageIndex = 0
                    Else
                        PageIndex = PageIndex - 1
                    End If
                End If

                dgGridBatch.CurrentPageIndex = PageIndex
                dgGridBatch.DataSource = DsSearchResult
                dgGridBatch.DataBind()
                Me.ViewState("DsSearchResult") = DsSearchResult
            End If
        Catch ex As Exception
            objError = New clsError
            StartUpScript(Me.ID, objError.errHandler(ex))
        End Try

    End Sub

#End Region

#Region "Methods"

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")

        Try
            If focusCtrl <> "" And strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.TopicDetails." & focusCtrl & " == '[object]') { document.TopicDetails." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf focusCtrl <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.TopicDetails." & focusCtrl & " == '[object]') { document.TopicDetails." & focusCtrl & ".focus(); } </script>")
            Else

            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub DeleteConformationMessage(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        Try
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Dim btn As Button = CType(e.Item.Cells(5).Controls(0), Button)
                    btn.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this record ?')")
                    Exit Select
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Grid Events"

    Private Sub dgGridBatch_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGridBatch.DeleteCommand
        Try
            objBoardEnrollment = New ClsBoardEnrollment
            RtnVal = objBoardEnrollment.Master_Delete(DrpBoardMaster.SelectedValue, dgGridBatch.Items(e.Item.ItemIndex).Cells(1).Text)
            If RtnVal = 1 Then
                FillGrid(PageIndex)
                StartUpScript("", "Record Deleted Successfully")
            Else
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

    Private Sub dgGridBatch_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgGridBatch.PageIndexChanged
        Try
            dgGridBatch.CurrentPageIndex = e.NewPageIndex
            Me.ViewState("PageIndex") = e.NewPageIndex

            PageIndex = Me.ViewState("PageIndex")
            DsSearchResult = Me.ViewState("DsSearchResult")
            dgGridBatch.DataSource = DsSearchResult
            dgGridBatch.DataBind()
        Catch ex As Exception
            objError = New clsError
            StartUpScript(dgGridBatch.ID, objError.errHandler(ex))
        End Try
    End Sub

    Private Sub dgGridBatch_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGridBatch.EditCommand
        Try
            Response.Redirect("MasterSingle.aspx?MODE=EDIT&SLNO=" & dgGridBatch.Items(e.Item.ItemIndex).Cells(4).Text & "&HEAD=" & DrpBoardMaster.SelectedItem.Text & "&PageIndex=" & CStr(PageIndex) & "&BENO=" & DrpBoardMaster.SelectedValue)
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

    Private Sub dgGridBatch_SortCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgGridBatch.SortCommand
        Try
            DsFiles = Session("DsFiles")
            DsFiles.Tables(0).DefaultView.Sort = e.SortExpression
            dgGridBatch.DataSource = DsFiles.Tables(0)
            dgGridBatch.DataBind()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#End Region

   
   
End Class
