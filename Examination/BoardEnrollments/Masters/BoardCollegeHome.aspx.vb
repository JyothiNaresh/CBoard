Imports CollegeBoardDLL

Public Class BoardCollegeHome
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtDeleteStatus As System.Web.UI.WebControls.TextBox
    Protected WithEvents LblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblCourse As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents lblBatch As System.Web.UI.WebControls.Label
    Protected WithEvents dgGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents iBtnSingleMode As System.Web.UI.WebControls.ImageButton
    Protected WithEvents txtSetfocus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMessage As System.Web.UI.WebControls.TextBox
    Protected WithEvents iBtnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents iBtnCancel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents drpDistrict As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpCorpColl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpNarayana As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpColltype As System.Web.UI.WebControls.DropDownList
    Protected WithEvents IbtnSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents drpSelect As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TxtSelect As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Code"

#Region "common Varaibles"
    Private objBE As ClsBoardEnrollment
    Private objBEfill As Utility
    Private UserSLNo As Integer
    Private OBJERROR As clsError
    Public PageIndex As Integer
    Private sqlString As String
    Private dsResult As DataSet

#End Region

#Region "Page Load Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Session("USERID") Is Nothing OrElse Session("USERSLNO") Is Nothing Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
                Exit Sub
            Else
                UserSLNo = Session("USERSLNO")
            End If


            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                OBJERROR = New clsError
                OBJERROR.Session_Nothing()

                PageIndex = CInt(Request.QueryString("PageIndex"))
                Me.ViewState("PageIndex") = PageIndex

                FillDistricts()
                FillColltype()
                FillCorpColl()
                FillGrid(PageIndex)
            Else
                PageIndex = Me.ViewState("PageIndex")

            End If

        Catch ex As Exception
            OBJERROR = New clsError
            DisplayMessage(OBJERROR.errHandler(ex))
        End Try

    End Sub

#End Region

#Region "Common Methods"

    Sub DisplayFocus(ByVal strMsg As String)
        txtSetfocus.Text = strMsg
    End Sub

    Sub DisplayMessage(ByVal strMsg As String)
        txtMessage.Text = txtMessage.Text & vbNewLine & strMsg
    End Sub

#End Region

#Region "Methods"

    'Private Sub FillGrid(ByVal PageIndex As Integer)
    '    Try

    '        Dim FilterString As String



    '        If drpCourse.SelectedValue <> 0 Then
    '            FilterString &= drpCourse.SelectedValue
    '        Else
    '            FilterString &= "0"
    '        End If

    '        If drpGroup.SelectedValue <> 0 Then
    '            FilterString &= "~" + drpGroup.SelectedValue
    '        Else
    '            FilterString &= "~" + "0"
    '        End If

    '        If drpBatch.SelectedValue <> 0 Then
    '            FilterString &= "~" + drpBatch.SelectedValue
    '        Else
    '            FilterString &= "~" + "0"
    '        End If

    '        If drpMedium.SelectedValue <> 0 Then
    '            FilterString &= "~" + drpMedium.SelectedValue
    '        Else
    '            FilterString &= "~" + "0"
    '        End If

    '        If drpStuType.SelectedValue <> 0 Then
    '            FilterString &= "~" + drpStuType.SelectedValue
    '        Else
    '            FilterString &= "~" + "0"
    '        End If

    '        If drpGender.SelectedValue.ToString <> "0" Then
    '            FilterString &= "~" + drpGender.SelectedValue.ToString
    '        Else
    '            FilterString &= "~" + "0"
    '        End If

    '        If drpExamBranch.SelectedValue <> 0 Then
    '            FilterString &= "~" + drpExamBranch.SelectedValue
    '        Else
    '            FilterString &= "~" + "0"
    '        End If

    '        If drpSection.SelectedValue <> 0 Then
    '            FilterString &= "~" + drpSection.SelectedValue
    '        Else
    '            FilterString &= "~" + "0"
    '        End If

    '        FilterString &= "~" + UserSLNo.ToString

    '        FilterString &= "~" + Session("COMACADEMICSLNO")

    '        If drpSubBatch.SelectedValue <> 0 Then
    '            FilterString &= "~" + drpSubBatch.SelectedValue
    '        Else
    '            FilterString &= "~" + "0"
    '        End If

    '        objStudSubSec = New ClsStudentSubSection

    '        dsResult = objStudSubSec.StudentSubBatchDetail_Search(FilterString)

    '        Session("E_STUDENTSUBSECTIONS") = dsResult

    '        Me.ViewState("sqlString") = sqlString

    '        If Not dsResult Is Nothing Then

    '            '' Setting Page Indexs
    '            If (dsResult.Tables(0).Rows.Count - 1) / 10 < PageIndex Then

    '                PageIndex = (dsResult.Tables(0).Rows.Count - 1) / 10

    '                If ((dsResult.Tables(0).Rows.Count - 1) / 10) <= 1 Then
    '                    PageIndex = 0
    '                Else
    '                    PageIndex = PageIndex - 1
    '                End If
    '            End If

    '            dgGrid.CurrentPageIndex = PageIndex
    '            dgGrid.DataSource = dsResult
    '            dgGrid.DataBind()
    '        End If

    '    Catch ex As Exception
    '        objError = New clsError
    '        DisplayMessage(objError.errHandler(ex))
    '    End Try

    'End Sub

#End Region

#Region "FillMethods"


    Private Sub FillDistricts()
        Try
            Dim DS As DataSet

            objBEfill = New Utility
            DS = objBEfill.DataSet_OneFetch("SELECT CODE||'-'||NAME TEXT, BOARDDISTSLNO SLNO FROM EXAM_BOARDDIST_MT ORDER BY NAME")


            drpDistrict.DataSource = DS.Tables(0)
            drpDistrict.DataTextField = "TEXT"
            drpDistrict.DataValueField = "SLNO"
            drpDistrict.DataBind()
            drpDistrict.Items.Insert(0, New ListItem("ALL", 0))

        Catch ex As Exception
            OBJERROR = New clsError
            DisplayMessage(OBJERROR.errHandler(ex))
        End Try

    End Sub

    Private Sub FillColltype()
        Try
            Dim DS As DataSet

            objBEfill = New Utility
            DS = objBEfill.DataSet_OneFetch("SELECT NAME, BOARDCOLLTYPESLNO SLNO FROM EXAM_BOARDCOLLTYPE_MT ORDER BY NAME")


            drpColltype.DataSource = DS.Tables(0)
            drpColltype.DataTextField = "NAME"
            drpColltype.DataValueField = "SLNO"
            drpColltype.DataBind()
            drpColltype.Items.Insert(0, New ListItem("ALL", 0))

        Catch ex As Exception
            OBJERROR = New clsError
            DisplayMessage(OBJERROR.errHandler(ex))
        End Try

    End Sub

    Private Sub FillCorpColl()
        Try
            Dim DS As DataSet

            objBEfill = New Utility
            DS = objBEfill.DataSet_OneFetch("SELECT NAME, BOARDCORPCOLLSLNO SLNO FROM EXAM_BOARDCORPCOLL_MT ORDER BY NAME")


            drpCorpColl.DataSource = DS.Tables(0)
            drpCorpColl.DataTextField = "NAME"
            drpCorpColl.DataValueField = "SLNO"
            drpCorpColl.DataBind()
            drpCorpColl.Items.Insert(0, New ListItem("ALL", 0))

        Catch ex As Exception
            OBJERROR = New clsError
            DisplayMessage(OBJERROR.errHandler(ex))
        End Try

    End Sub

    Private Sub FillGrid(ByVal PageIndex As Integer)
        Try

            Dim FilterString As String

            If drpDistrict.SelectedValue <> 0 Then
                FilterString &= " And BORD.BOARDDISTSLNO = " + drpDistrict.SelectedValue
            End If

            If drpNarayana.SelectedValue = 1 Then
                FilterString &= " And ISNARAYANA = 1 "
            End If

            If drpColltype.SelectedValue <> 0 Then
                FilterString &= " And BORD.BOARDCOLLTYPESLNO = " + drpColltype.SelectedValue
            End If

            If drpCorpColl.SelectedValue <> 0 Then
                FilterString &= " And BORD.BOARDCORPCOLLSLNO = " + drpCorpColl.SelectedValue
            End If

            sqlString = " SELECT DIST.CODE||'-'||DIST.NAME DISTRICT, BORD.CODE, BORD.COLLEGENAME, CORP.NAME CORPCOLLNAME, COLLTYPE.NAME COLLTYPE " & _
                        " FROM EXAM_BOARDCOLLEGE_MT BORD, EXAM_BOARDDIST_MT DIST, EXAM_BOARDCORPCOLL_MT CORP, EXAM_BOARDCOLLTYPE_MT COLLTYPE " & _
                        " WHERE BORD.BOARDDISTSLNO = DIST.BOARDDISTSLNO AND	BORD.BOARDCORPCOLLSLNO=CORP.BOARDCORPCOLLSLNO(+) AND BORD.BOARDCOLLTYPESLNO=COLLTYPE.BOARDCOLLTYPESLNO(+) "

            sqlString += FilterString + " ORDER BY DIST.NAME,BORD.COLLEGENAME "

            objBEfill = New Utility
            dsResult = objBEfill.DataSet_OneFetch(sqlString)

            Session("BECOLLEGE") = dsResult

            Me.ViewState("sqlString") = sqlString

            If Not dsResult Is Nothing Then

                '' Setting Page Indexs
                If (dsResult.Tables(0).Rows.Count - 1) / 10 < PageIndex Then

                    PageIndex = (dsResult.Tables(0).Rows.Count - 1) / 10

                    If ((dsResult.Tables(0).Rows.Count - 1) / 10) <= 1 Then
                        PageIndex = 0
                    Else
                        PageIndex = PageIndex - 1
                    End If
                End If

                dgGrid.CurrentPageIndex = PageIndex
                dgGrid.DataSource = dsResult
                dgGrid.DataBind()
            End If

        Catch ex As Exception
            objError = New clsError
            DisplayMessage(objError.errHandler(ex))
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

    Private Sub iBtnSingleMode_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSingleMode.Click
        Try
            'Response.Redirect("BoardCollegeHome.aspx?PageIndex=" & CStr(PageIndex) & "&Mode=Add" & "&COURSESLNO=" & CStr(drpCourse.SelectedValue) & "&EXAMBRANCHSLNO=" & CStr(drpExamBranch.SelectedValue & "&GROUPSLNO=" & CStr(drpGroup.SelectedValue) & "&BATCHSLNO=" & CInt(drpBatch.SelectedValue) & "&MEDIUMSLNO=" & CStr(drpMedium.SelectedValue) & "&STUDENTYPESLNO=" & CStr(drpStuType.SelectedValue) & "&GENDER=" & drpGender.SelectedValue) & "&SECTIONSLNO=" & CStr(drpSection.SelectedValue))
            Response.Redirect("BoardCollegeEntry.aspx?MODE=NEW")
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(" USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)

                StartUpScript(iBtnSingleMode.ID, " Transaction  Failed ")
            End If
        End Try

    End Sub

    Private Sub iBtnCancel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnCancel.Click
        Try
            'Response.Write("<script language=Javascript>Javascript:window.open('../../welcome.htm','MainTextPart');</script>")
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(" USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)

                StartUpScript(iBtnCancel.ID, " Transaction  Failed ")
            End If
        End Try
    End Sub

    Private Sub iBtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnGo.Click
        FillGrid(0)
    End Sub

    Private Sub IbtnSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnSearch.Click

        Try
            Dim DS As DataSet
            Dim sqlstring As String
            Dim FilterString As String
            If drpSelect.SelectedValue = 1 Then
                FilterString = " AND BORD.CODE LIKE '%" + TxtSelect.Text + "%' "
            Else
                FilterString = " AND BORD.COLLEGENAME LIKE '%" + TxtSelect.Text + "%' "
            End If

            sqlstring = " SELECT DIST.CODE||'-'||DIST.NAME DISTRICT, BORD.CODE, BORD.COLLEGENAME, CORP.NAME CORPCOLLNAME, COLLTYPE.NAME COLLTYPE " & _
                        " FROM EXAM_BOARDCOLLEGE_MT BORD, EXAM_BOARDDIST_MT DIST, EXAM_BOARDCORPCOLL_MT CORP, EXAM_BOARDCOLLTYPE_MT COLLTYPE " & _
                        " WHERE BORD.BOARDDISTSLNO = DIST.BOARDDISTSLNO AND	BORD.BOARDCORPCOLLSLNO=CORP.BOARDCORPCOLLSLNO(+) AND BORD.BOARDCOLLTYPESLNO=COLLTYPE.BOARDCOLLTYPESLNO(+) "

            sqlstring += FilterString + " ORDER BY DIST.NAME,BORD.COLLEGENAME "

            objBEfill = New Utility
            dsResult = objBEfill.DataSet_OneFetch(sqlstring)

            Session("BECOLLEGE") = dsResult

            Me.ViewState("sqlString") = sqlstring

            If Not dsResult Is Nothing Then

                '' Setting Page Indexs
                If (dsResult.Tables(0).Rows.Count - 1) / 10 < PageIndex Then

                    PageIndex = (dsResult.Tables(0).Rows.Count - 1) / 10

                    If ((dsResult.Tables(0).Rows.Count - 1) / 10) <= 1 Then
                        PageIndex = 0
                    Else
                        PageIndex = PageIndex - 1
                    End If
                End If

                dgGrid.CurrentPageIndex = PageIndex
                dgGrid.DataSource = dsResult
                dgGrid.DataBind()
            End If

        Catch ex As Exception
            OBJERROR = New clsError
            DisplayMessage(OBJERROR.errHandler(ex))
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
            OBJERROR = New clsError
            DisplayMessage(OBJERROR.errHandler(ex))
        End Try

    End Sub

#End Region

#Region "DropDown Events"


#End Region

#End Region

End Class
