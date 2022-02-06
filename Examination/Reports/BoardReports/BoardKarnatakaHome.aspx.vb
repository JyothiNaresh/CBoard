Imports CollegeBoardDLL
Public Class BoardKarnatakaHome
    Inherits System.Web.UI.Page
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    'Protected WithEvents LblHeading As System.Web.UI.WebControls.Label
    'Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblCourse As System.Web.UI.WebControls.Label
    'Protected WithEvents iBtnGo As System.Web.UI.WebControls.ImageButton
    'Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    'Protected WithEvents drpSelect As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents TxtSelect As System.Web.UI.WebControls.TextBox
    'Protected WithEvents IbtnSearch As System.Web.UI.WebControls.ImageButton
    'Protected WithEvents DrpExamBranch As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents DrpBoardCollege As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents dgGrid As System.Web.UI.WebControls.DataGrid
    'Protected WithEvents Rbtntc As System.Web.UI.WebControls.RadioButton
    'Protected WithEvents Rbtncc As System.Web.UI.WebControls.RadioButton

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "common Varaibles"
    Private objReport As DoRegionZone
    Private objBE As ClsBoardEnrollment
    Private objBEfill As Utility
    Private objWSCombo As ClsComboBoxFilling
    Private UserSLNo As Integer
    Public PageIndex As Integer
    Private sqlString As String
    Private dsResult As DataSet
    Private FLAG As Integer
    'Dim IEHisDel As Integer
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("USERID") Is Nothing OrElse Session("USERSLNO") Is Nothing Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then

                FillExamBranch()
                fillBoardColleges()
                FillGrid()
            Else


            End If

        Catch ex As Exception
        End Try
    End Sub

#Region "FillMethods"

    Private Sub FillGrid()
        Try
            SearchingData()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub FillExamBranch()
        Try
            Dim Ds As DataSet
            objBEfill = New Utility 'objBEfill As Utility
            Ds = objBEfill.FillUserWise_ExamBranchBanglore(Session("USERSLNO"), Session("COMACADEMICSLNO"))
            DrpExamBranch.DataSource = Ds
            DrpExamBranch.DataTextField = "EXAMBRANCHNAME"
            DrpExamBranch.DataValueField = "EXAMBRANCHSLNO"
            DrpExamBranch.DataBind()

        Catch ex As Exception
            StartUpScript(DrpExamBranch.ID, ex.Message)
        End Try
    End Sub

    Private Sub fillBoardColleges()
        Try
            Dim SqlStr As String
            SqlStr = "SELECT DISTINCT ESR.BOARDCOLLEGESLNO,TO_CHAR(GM.CODE)||'-'||TO_CHAR(GM.NAME) NAME ,GM.TSTATESLNO FROM EXAM_BOARDCOLLEGE_MT GM,EXAM_BC_EB_ACADEMIC_MT ESR WHERE GM.BOARDCOLLEGESLNO=ESR.BOARDCOLLEGESLNO  " & _
                     "AND ESR.EXAMBRANCHSLNO=" & DrpExamBranch.SelectedValue & " AND ESR.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " ORDER BY NAME"

            objBEfill = New Utility
            dsResult = objBEfill.GetCommDataSet(SqlStr)

            DrpBoardCollege.DataSource = dsResult.Tables(0)
            DrpBoardCollege.DataTextField = "NAME"
            DrpBoardCollege.DataValueField = "BOARDCOLLEGESLNO"
            DrpBoardCollege.DataBind()

            SearchingData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SearchingData()
        Try
            Dim DS As DataSet
            Dim sqlstring As String
            Dim FilterString As String
            If drpSelect.SelectedValue = 1 Then
                FilterString = " AND ADMDT.ADMNO LIKE '%" + TxtSelect.Text + "%' "
            Else
                FilterString = " AND ADMDT.NAME LIKE '%" + TxtSelect.Text + "%' "
            End If

            If Val(DrpBoardCollege.SelectedValue) <> 0 Then
                FilterString = FilterString + " AND BRDCOL.BOARDCOLLEGESLNO = " & DrpBoardCollege.SelectedValue
            End If

            objBE = New ClsBoardEnrollment
            dsResult = objBE.P_DTCSTUDENTS_SELECTBENGALORE(Session("COMACADEMICSLNO"), DrpExamBranch.SelectedValue, DrpBoardCollege.SelectedValue, TxtSelect.Text)
            If Rbtntc.Checked = True Then

                FLAG = 1
                Session("FLAG") = FLAG

            End If


            If Rbtncc.Checked = True Then
                FLAG = 2
                Session("FLAG") = FLAG

            End If



            Session("BECOLLEGE") = dsResult

            Me.ViewState("sqlString") = sqlstring

            If Not dsResult Is Nothing Then


                dgGrid.DataSource = dsResult
                dgGrid.DataBind()
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Img Events"

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")

        Try
            If focusCtrl <> "" And strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.StudentSectionBatch." & focusCtrl & " == '[object]') { document.StudentSectionBatch." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf focusCtrl <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.StudentSectionBatch." & focusCtrl & " == '[object]') { document.StudentSectionBatch." & focusCtrl & ".focus(); } </script>")
            Else

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub iBtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnGo.Click
        FillGrid()
    End Sub

    Private Sub IbtnSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnSearch.Click
        Try
            SearchingData()
        Catch ex As Exception

        End Try


    End Sub

#End Region

#Region "Grid Events"

    Private Sub dgGrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgGrid.PageIndexChanged
        Try
            dgGrid.CurrentPageIndex = e.NewPageIndex
            Me.ViewState("PageIndex") = e.NewPageIndex
            PageIndex = Me.ViewState("PageIndex")
            dsResult = Session("BECOLLEGE")
            dgGrid.DataSource = dsResult
            dgGrid.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgGrid_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGrid.DeleteCommand
        Try

            Dim Tcgen As String = dgGrid.Items(e.Item.ItemIndex).Cells(16).Text.ToString

            'If Tcgen = 1 Then
            '    Response.Redirect("BoardTCReportMumbai.aspx?ADMSLNO=" & dgGrid.Items(e.Item.ItemIndex).Cells(1).Text.ToString & "&UNIQUENO=" & dgGrid.Items(e.Item.ItemIndex).Cells(0).Text.ToString & "&BOARDCOLLEGESLNO=" & dgGrid.Items(e.Item.ItemIndex).Cells(2).Text.ToString & "&FLAG=" & Session("FLAG"))
            'ElseIf Tcgen = 2 Then
            '    Response.Redirect("BoardTCReportMumbai.aspx?ADMSLNO=" & dgGrid.Items(e.Item.ItemIndex).Cells(1).Text.ToString & "&UNIQUENO=" & dgGrid.Items(e.Item.ItemIndex).Cells(0).Text.ToString & "&BOARDCOLLEGESLNO=" & dgGrid.Items(e.Item.ItemIndex).Cells(2).Text.ToString & "&FLAG=" & Session("FLAG"))
            'End If
            Response.Redirect("BoardkarnatakReport.aspx?ADMSLNO=" & dgGrid.Items(e.Item.ItemIndex).Cells(1).Text.ToString & "&UNIQUENO=" & dgGrid.Items(e.Item.ItemIndex).Cells(0).Text.ToString & "&BOARDCOLLEGESLNO=" & dgGrid.Items(e.Item.ItemIndex).Cells(2).Text.ToString & "&FLAG=" & Session("FLAG"))


        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgGrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgGrid.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                'Dim Chk As CheckBox = CType(e.Item.Cells(10).Controls(1).FindControl("ChkTarget"), CheckBox)
                If Session("FLAG") = 1 Then

                    dgGrid.Columns(10).Visible = True
                    dgGrid.Columns(11).Visible = True

                    If (Val(e.Item.Cells(13).Text)) <> 2 Then ' Drda Student
                        If (Val(e.Item.Cells(15).Text) <> 1) Then
                            If (Val(e.Item.Cells(10).Text) < 100 Or Val(e.Item.Cells(11).Text) > 1 Or Val(e.Item.Cells(14).Text) > 0) Then  'Or Val(e.Item.Cells(15).Text) = 2
                                e.Item.Cells(12).Enabled = False
                                'Fee Pending
                                If Val(e.Item.Cells(10).Text) < 100 Then
                                    e.Item.Cells(10).ForeColor = Color.Red
                                    e.Item.Cells(10).ToolTip = " Fee Pending or Concession Student, Put Request for TC-Generation "
                                End If
                                'Student Status
                                If Val(e.Item.Cells(11).Text) = 5 Then
                                    e.Item.Cells(11).ForeColor = Color.Blue
                                    e.Item.Cells(11).Text = " Pending "
                                ElseIf Val(e.Item.Cells(11).Text) = 1 Then
                                    e.Item.Cells(11).Text = " Active "
                                ElseIf Val(e.Item.Cells(11).Text) = 2 Then
                                    e.Item.Cells(11).ForeColor = Color.Purple
                                    e.Item.Cells(11).Font.Bold = True
                                    e.Item.Cells(11).Text = " Adm.Cancel "
                                End If
                                'TC Issued 
                                If Val(e.Item.Cells(14).Text) > 0 Then
                                    e.Item.Cells(11).Text += " / TC Issued"
                                End If
                                ' Requst Approval
                                If Val(e.Item.Cells(15).Text) = 2 Then
                                    e.Item.Cells(11).Text += " / Request Pending"
                                End If

                            Else
                                e.Item.Cells(12).Enabled = True
                                e.Item.Cells(11).Text = " Active "
                                If Val(e.Item.Cells(15).Text) = 1 Then
                                    e.Item.Cells(11).Text += " / Request Approved"
                                End If
                            End If
                        Else
                            e.Item.Cells(12).Enabled = True
                            e.Item.Cells(11).Text = " Active "
                            If Val(e.Item.Cells(15).Text) = 1 Then
                                e.Item.Cells(11).Text += " / Request Approved"
                            End If
                        End If
                    Else
                        If Val(e.Item.Cells(11).Text) > 1 Then
                            e.Item.Cells(12).Enabled = False
                            e.Item.Cells(11).ForeColor = Color.Blue
                            e.Item.Cells(11).Text = " Pending "
                        Else
                            e.Item.Cells(12).Enabled = True
                            e.Item.Cells(11).Text = " Active "
                        End If

                        If Val(e.Item.Cells(13).Text) = 2 Then
                            e.Item.Cells(12).Enabled = True
                            e.Item.Cells(11).Text += " / DRDA Student"
                        End If
                    End If
                Else
                    dgGrid.Columns(10).Visible = False
                    dgGrid.Columns(11).Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "DropDown Events"

    Private Sub DrpExamBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpExamBranch.SelectedIndexChanged
        fillBoardColleges()
    End Sub

    Private Sub DrpBoardCollege_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpBoardCollege.SelectedIndexChanged
        Try
            SearchingData()

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Readio Buttons"

    Private Sub Rbtntc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbtntc.CheckedChanged
        SearchingData()
    End Sub

    Private Sub Rbtncc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbtncc.CheckedChanged
        SearchingData()
    End Sub

#End Region

#Region "Scrub"



#End Region


End Class