Imports CollegeBoardDLL
Public Class SchoolTcHome
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents LblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpExamBranch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpCourse As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Rbtncc As System.Web.UI.WebControls.RadioButton
    Protected WithEvents Rbtntc As System.Web.UI.WebControls.RadioButton

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

#Region "Page Load Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Session("USERID") Is Nothing OrElse Session("USERSLNO") Is Nothing Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            End If
            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                FillExamBranch()
                FillCourse()
                FillGrid()
            Else
            End If
        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region "FillMethods"

    Private Sub FillGrid()
        Try
            SearchingData()
            'Dim FilterString As String

            'If Val(DrpBoardCollege.SelectedValue) <> 0 Then
            '    FilterString = " AND BRDCOL.BOARDCOLLEGESLNO = " & DrpBoardCollege.SelectedValue
            'Else
            '    FilterString = ""
            'End If

            'FilterString &= " AND (ADMDT.PAIDPER=100 OR ADMDT.TCREQAPPROVED=1) "

            'sqlString = " SELECT EXMBRN.EXAMBRANCHNAME EXAMBRANCH, ADMDT.ADMNO ADMNO,BRDSTU.UNIQUENO UNIQUENO,ADMDT.ADMSLNO ADMSLNO, BRDSTU.BOARDCOLLEGESLNO, BRDSTU.BOARDADMNO BADMNO, BRDCOL.CODE BOARDCOLLEGE, ADMDT.NAME STUDENTNAME, " & _
            '            " ADMDT.COURSENAME||'/'||ADMDT.GROUPNAME|| '/'||ADMDT.BATCHNAME||'/'||ADMDT.SECTION CODE " & _
            '            " FROM   DO_ZON_REG_ADMDT ADMDT, EXAM_BOARDSTUDENT_DT BRDSTU, EXAM_EXAMBRANCH EXMBRN, EXAM_BOARDCOLLEGE_MT BRDCOL,T_COURSE_MT COR " & _
            '            " WHERE  ADMDT.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & " AND BRDSTU.TCNO=0 AND ADMDT.UNIQUENO = BRDSTU.UNIQUENO AND ADMDT.EXAMBRANCHSLNO = EXMBRN.EXAMBRANCHSLNO AND BRDCOL.BOARDCOLLEGESLNO = BRDSTU.BOARDCOLLEGESLNO AND COR.TCSTATUS=1 AND ADMDT.COURSESLNO=COR.COURSESLNO" & _
            '            " AND ADMDT.EXAMBRANCHSLNO = " & DrpExamBranch.SelectedValue & FilterString & " ORDER BY ADMDT.NAME"
            ''" AND BRDSTU.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") &
            'objBEfill = New Utility
            'dsResult = objBEfill.DataSet_OneFetch(sqlString)

            'Session("BECOLLEGE") = dsResult

            'Me.ViewState("sqlString") = sqlString

            'If Not dsResult Is Nothing Then

            '    '' Setting Page Indexs
            '    'If (dsResult.Tables(0).Rows.Count - 1) / 20 < PageIndex Then

            '    '    PageIndex = (dsResult.Tables(0).Rows.Count - 1) / 20

            '    '    If ((dsResult.Tables(0).Rows.Count - 1) / 20) <= 1 Then
            '    '        PageIndex = 0
            '    '    Else
            '    '        PageIndex = PageIndex - 1
            '    '    End If
            '    'End If

            '    'dgGrid.CurrentPageIndex = PageIndex
            '    dgGrid.DataSource = dsResult
            '    dgGrid.DataBind()
            'End If

        Catch ex As Exception
        End Try

    End Sub


    Private Sub FillCourse()
        Try
            Dim dsExamBranch As DataSet
            Dim SqlStr As String
            objWSCombo = New ClsComboBoxFilling
            SqlStr = "SELECT COURSESLNO,NAME FROM T_COURSE_MT ORDER BY COURSESLNO"
            objBEfill = New Utility
            dsResult = objBEfill.GetCommDataSet(SqlStr)
            DrpCourse.DataSource = dsResult.Tables(0)
            DrpCourse.DataTextField = "NAME"
            DrpCourse.DataValueField = "COURSESLNO"
            DrpCourse.DataBind()
        Catch ex As Exception
            StartUpScript(DrpExamBranch.ID, ex.Message)
        End Try

    End Sub

    Private Sub FillExamBranch()
        Try
            Dim dsExamBranch As DataSet

            objWSCombo = New ClsComboBoxFilling
            dsExamBranch = objWSCombo.USERWISEEB(Session("USERSLNO"), Session("COMACADEMICSLNO"))
            DrpExamBranch.DataSource = dsExamBranch.Tables(0)
            DrpExamBranch.DataTextField = "EXAMBRANCHNAME"
            DrpExamBranch.DataValueField = "EXAMBRANCHSLNO"
            DrpExamBranch.DataBind()

        Catch ex As Exception
            StartUpScript(DrpExamBranch.ID, ex.Message)
        End Try
    End Sub

    Private Sub SearchingData()
        Try
            Dim DS As DataSet
            Dim sqlstring As String
            Dim FilterString As String
            objBE = New ClsBoardEnrollment
            dsResult = objBE.CONDUCT_STUDENTS_SELECT(Session("COMACADEMICSLNO"), DrpExamBranch.SelectedItem.Value, DrpCourse.SelectedItem.Value)
            If Rbtntc.Checked = True Then
                FLAG = 1
                Session("FLAG") = FLAG
            End If
            If Rbtncc.Checked = True Then
                FLAG = 2
                Session("FLAG") = FLAG
            End If
            'Session("BECOLLEGE") = dsResult
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

    Private Sub iBtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        FillGrid()
    End Sub

    Private Sub IbtnSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            SearchingData()
        Catch ex As Exception

        End Try


    End Sub

#End Region

#Region "Grid Events"

    Private Sub dgGrid_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgGrid.PageIndexChanged
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

    Private Sub dgGrid_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGrid.DeleteCommand
        Try
            If Rbtntc.Checked = True Then

                Response.Redirect("SchTcDetailsEntry.aspx?ADMSLNO=" & dgGrid.Items(e.Item.ItemIndex).Cells(1).Text.ToString & "&UNIQUENO=" & dgGrid.Items(e.Item.ItemIndex).Cells(0).Text.ToString & "&FLAG=" & Session("FLAG"))

            Else

                Response.Redirect("SchoolCCGeneratenew.aspx?ADMSLNO=" & dgGrid.Items(e.Item.ItemIndex).Cells(1).Text.ToString & "&UNIQUENO=" & dgGrid.Items(e.Item.ItemIndex).Cells(0).Text.ToString & "&FLAG=" & Session("FLAG"))

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgGrid_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgGrid.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

                If Session("FLAG") = 1 Then

                    dgGrid.Columns(7).Visible = True
                    'dgGrid.Columns(10).Visible = True

                    If (Val(e.Item.Cells(11).Text)) <> 2 Then ' Drda Student
                        If (Val(e.Item.Cells(3).Text) <> 1) Then
                            If (Val(e.Item.Cells(7).Text) < 100 Or Val(e.Item.Cells(8).Text) > 1) Then 'Or Val(e.Item.Cells(14).Text) > 0) Then  'Or Val(e.Item.Cells(15).Text) = 2
                                e.Item.Cells(9).Enabled = False
                                'Fee Pending
                                If Val(e.Item.Cells(7).Text) < 100 Then
                                    e.Item.Cells(7).ForeColor = Color.Red
                                    e.Item.Cells(7).ToolTip = " Fee Pending or Concession Student, Put Request for TC-Generation "
                                End If
                                'Student Status
                                If Val(e.Item.Cells(8).Text) = 5 Then
                                    e.Item.Cells(8).ForeColor = Color.Blue
                                    e.Item.Cells(8).Text = " Pending "
                                ElseIf Val(e.Item.Cells(8).Text) = 1 Then
                                    e.Item.Cells(8).Text = " Active "
                                ElseIf Val(e.Item.Cells(11).Text) = 2 Then
                                    e.Item.Cells(8).ForeColor = Color.Purple
                                    e.Item.Cells(8).Font.Bold = True
                                    e.Item.Cells(8).Text = " Adm.Cancel "
                                End If
                                'TC Issued 
                                'If Val(e.Item.Cells(14).Text) > 0 Then
                                '    e.Item.Cells(11).Text += " / TC Issued"
                                'End If
                                ' Requst Approval
                                If Val(e.Item.Cells(11).Text) = 2 Then
                                    e.Item.Cells(8).Text += " / Request Pending"
                                End If

                            Else
                                e.Item.Cells(11).Enabled = True
                                e.Item.Cells(8).Text = " Active "
                                If Val(e.Item.Cells(8).Text) = 1 Then
                                    e.Item.Cells(11).Text += " / Request Approved"
                                End If
                            End If
                        Else
                            e.Item.Cells(9).Enabled = True
                            e.Item.Cells(8).Text = " Active "
                            If Val(e.Item.Cells(12).Text) = 1 Then
                                e.Item.Cells(8).Text += " / Request Approved"
                            End If
                        End If
                    Else
                        If Val(e.Item.Cells(8).Text) > 1 Then
                            e.Item.Cells(9).Enabled = False
                            e.Item.Cells(8).ForeColor = Color.Blue
                            e.Item.Cells(8).Text = " Pending "
                        Else
                            e.Item.Cells(9).Enabled = True
                            e.Item.Cells(8).Text = " Active "
                        End If

                        If Val(e.Item.Cells(13).Text) = 2 Then
                            e.Item.Cells(11).Enabled = True
                            e.Item.Cells(8).Text += " / DRDA Student"
                        End If
                    End If
                Else
                    dgGrid.Columns(8).Visible = False
                    dgGrid.Columns(10).Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "DropDown Events"

    Private Sub DrpExamBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpExamBranch.SelectedIndexChanged
        SearchingData()
    End Sub

    Private Sub DrpBoardCollege_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            SearchingData()
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub DrpCourse_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpCourse.SelectedIndexChanged
        SearchingData()
    End Sub

    Private Sub Rbtntc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbtntc.CheckedChanged
        SearchingData()
    End Sub

    Private Sub Rbtncc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbtncc.CheckedChanged
        SearchingData()
    End Sub
End Class
