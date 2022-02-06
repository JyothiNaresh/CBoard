'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is Presentation Layer For Users View
'   ACTIVITY                          : User Wise Subbatch Permission View
'   AUTHOR                            : K.SHANKAR SUDERSHAN RAO
'   INITIAL BASELINE DATE             : 08-March-2010
'   FINAL BASELINE DATE               : 09-March-2010
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Public Class UserWiseSubbatchPermissionView
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpUserTypes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents drpAcaSlno As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpUsers As System.Web.UI.WebControls.DropDownList
    Protected WithEvents iBtnSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents dgVusers As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ibtnEdit As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ibtnBatch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents drpCourse As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpGroup As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpBatch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblCourse As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents lblBatch As System.Web.UI.WebControls.Label

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
    Private dsV As New DataSet
    Private Formname As String = "Form1"
    Private objUcls As New UserClass
    Private objWS As ClsBCEGBS
    Private objWSCombo As ClsComboBoxFilling
    Private PageIndex As Integer = 0
    Private Mode, cMode As String
    Private USERTYPESLNO As Integer = 0
    Dim COURSESLNO, GROUPSLNO, BATCHSLNO As Integer
    Dim ClsUty As New Utility
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
                    Dim btn As Button = CType(e.Item.Cells(11).Controls(0), Button)
                    btn.Attributes.Add("onclick", "return confirm('Are You Sure To Delete This Record ?')")
                    Exit Select
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetViewStateData()
        Try
            Me.ViewState("PageIndex") = PageIndex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetViewStateData()
        Try
            PageIndex = CInt(Me.ViewState("PageIndex"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Load Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                If Not Request.QueryString("PageIndex") Is Nothing AndAlso Request.QueryString("PageIndex") <> "" Then
                    PageIndex = CInt(Request.QueryString("PageIndex"))
                Else
                    PageIndex = 0
                End If

                If Not Request.QueryString("USERTYPESLNO") Is Nothing AndAlso Request.QueryString("USERTYPESLNO") <> "" Then
                    PageIndex = CInt(Request.QueryString("USERTYPESLNO"))
                Else
                    PageIndex = 0
                End If

                USERTYPESLNO = CInt(Request.QueryString("USERTYPESLNO"))

                If Not Request.QueryString("COURSESLNO") Is Nothing AndAlso Request.QueryString("COURSESLNO") <> "" Then COURSESLNO = CInt(Request.QueryString("COURSESLNO"))
                If Not Request.QueryString("GROUPSLNO") Is Nothing AndAlso Request.QueryString("GROUPSLNO") <> "" Then GROUPSLNO = CInt(Request.QueryString("GROUPSLNO"))
                If Not Request.QueryString("BATCHSLNO") Is Nothing AndAlso Request.QueryString("BATCHSLNO") <> "" Then BATCHSLNO = CInt(Request.QueryString("BATCHSLNO"))

                SetViewStateData()

                FillAcademiyears()
                FillUsersType()
                FillUsers()
                fillCourse()
                FillGroup()
                FillBatch()
                FilldataGrid(PageIndex)
            Else
                GetViewStateData()
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

    Private Function FillUsers()
        Try
            objUcls = New UserClass

            ' dsV = ClsUty.DataSet_Fetch("SELECT USERSLNO,USERID,NAME,TO_CHAR(FROMDATE,'dd/MM/yyyy') FROMDATE,TO_CHAR(TOFATE,'dd/MM/yyyy') TOFATE  FROM EXAM_USER_MT ORDER BY USERSLNO")
            dsV = ClsUty.DataSet_Fetch("SELECT UM.USERSLNO,UM.USERID,UM.NAME,TO_CHAR(UM.FROMDATE,'dd/MM/yyyy') FROMDATE,TO_CHAR(UM.TOFATE,'dd/MM/yyyy') TOFATE  FROM EXAM_USER_MT UM,E_USER_USERTYPE_MT UUM   " & _
                                         " WHERE UM.USERSLNO = UUM.USERSLNO AND UUM.USERTYPESLNO=" & DrpUserTypes.SelectedValue.ToString & " AND UUM.COMACADEMICSLNO =" & drpAcaSlno.SelectedValue.ToString & "  ORDER BY USERID")


            DrpUsers.DataSource = dsV.Tables(0)
            DrpUsers.DataTextField = "USERID"
            DrpUsers.DataValueField = "USERSLNO"
            DrpUsers.DataBind()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub FillUsersType()
        Try
            Dim dsStuType As DataSet
            dsStuType = ClsUty.DataSet_Fetch("SELECT USERTYPESLNO,NAME FROM E_USERTYPE_MT WHERE USERTYPESLNO<>1 ORDER BY NAME")
            DrpUserTypes.DataSource = dsStuType
            DrpUserTypes.DataTextField = "NAME"
            DrpUserTypes.DataValueField = "USERTYPESLNO"
            DrpUserTypes.DataBind()

            If USERTYPESLNO > 0 Then
                DrpUserTypes.SelectedValue = USERTYPESLNO
            Else
                DrpUserTypes.SelectedValue = 3
            End If

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub fillCourse()
        Try
            Dim dsCourse As DataSet
            objWSCombo = New ClsComboBoxFilling
            dsCourse = objWSCombo.Course_Fetch("A")
            drpCourse.DataSource = dsCourse.Tables(0)
            drpCourse.DataTextField = "NAME"
            drpCourse.DataValueField = "SLNO"
            drpCourse.DataBind()

            drpCourse.Items.Insert(0, New ListItem("All", 0))

            If COURSESLNO <> 0 Then
                drpCourse.SelectedValue = COURSESLNO
                FillGroup()
            End If

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub FillGroup()
        Try
            Dim dsGroup As DataSet
            objWS = New ClsBCEGBS
            dsGroup = objWS.Group_Fill(drpCourse.SelectedValue)
            drpGroup.DataSource = dsGroup.Tables(0)
            drpGroup.DataTextField = "GROUPNAME"
            drpGroup.DataValueField = "GROUPSLNO"
            drpGroup.DataBind()

            drpGroup.Items.Insert(0, New ListItem("All", 0))

            If GROUPSLNO <> 0 Then
                drpGroup.SelectedValue = GROUPSLNO
            End If

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub FillBatch()
        Try
            Dim dsBatch As DataSet
            objWS = New ClsBCEGBS
            dsBatch = objWS.Batch_Fill(drpCourse.SelectedValue, drpGroup.SelectedValue)
            drpBatch.DataSource = dsBatch.Tables(0)
            drpBatch.DataTextField = "BATCHNAME"
            drpBatch.DataValueField = "BATCHSLNO"
            drpBatch.DataBind()

            drpBatch.Items.Insert(0, New ListItem("All", 0))

            If BATCHSLNO <> 0 Then
                drpBatch.SelectedValue = BATCHSLNO
            End If
        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function FilldataGrid(ByVal PageIndex)
        Try
            objUcls = New UserClass


            Dim SqlStr As String = " SELECT EUSB.EUSBMAPSLNO,EUSB.USERSLNO,EUSB.COURSESLNO,CR.NAME COURSE,EUSB.GROUPSLNO,GR.NAME GROUPNAME," & _
                                   " EUSB.BATCHSLNO,BCH.NAME BATCH,EUSB.SUBBATCHSLNO,SB.NAME SUBBATCH " & _
                                   " FROM " & _
                                   " T_COURSE_MT CR,T_GROUP_MT GR,T_BATCH_MT BCH,EXAM_SUBBATCH_MT SB,EXAM_USERSUBBATCH_MT EUSB " & _
                                   " WHERE " & _
                                   " EUSB.COURSESLNO=CR.COURSESLNO " & _
                                   " AND EUSB.GROUPSLNO=GR.GROUPSLNO " & _
                                   " AND EUSB.BATCHSLNO=BCH.BATCHSLNO  " & _
                                   " AND EUSB.SUBBATCHSLNO=SB.SUBBATCHSLNO "

            If Not DrpUsers.SelectedValue Is Nothing Then
                SqlStr = SqlStr & " AND  EUSB.USERSLNO=" & DrpUsers.SelectedValue.ToString
            End If

            If drpCourse.SelectedIndex <> 0 AndAlso Not drpCourse.SelectedValue Is Nothing Then
                SqlStr = SqlStr & " AND  EUSB.COURSESLNO=" & drpCourse.SelectedValue.ToString
            End If

            If drpGroup.SelectedIndex <> 0 AndAlso Not drpGroup.SelectedValue Is Nothing Then
                SqlStr = SqlStr & " AND  EUSB.GROUPSLNO=" & drpGroup.SelectedValue.ToString
            End If

            If drpBatch.SelectedIndex <> 0 AndAlso Not drpBatch.SelectedValue Is Nothing Then
                SqlStr = SqlStr & " AND  EUSB.BATCHSLNO=" & drpBatch.SelectedValue.ToString
            End If

            SqlStr = SqlStr & "  AND EUSB.COMACADEMICSLNO =" & drpAcaSlno.SelectedValue.ToString & "  ORDER BY USERSLNO"

            dsV = ClsUty.DataSet_OneFetch(SqlStr)

            If Not dsV Is Nothing Then
                If (dsV.Tables(0).Rows.Count - 1) / 10 < PageIndex Then
                    If ((dsV.Tables(0).Rows.Count - 1) / 10) <= 1 Then
                        PageIndex = 0
                    Else
                        PageIndex = PageIndex - 1
                    End If
                End If
                Session("ViewAllUsers_DataSet") = dsV
                dgVusers.CurrentPageIndex = PageIndex
                dgVusers.DataSource = dsV.Tables(0)
                dgVusers.DataBind()
            End If
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub FillAcademiyears()
        Try
            Dim dsAcaYr As DataSet
            dsAcaYr = ClsUty.DataSet_Fetch("SELECT COMACADEMICSLNO,NAME FROM T_COMPANYACADEMICYEAR_MT")
            If dsAcaYr.Tables(0).Rows.Count > 0 Then
                drpAcaSlno.DataSource = dsAcaYr
                drpAcaSlno.DataTextField = "NAME"
                drpAcaSlno.DataValueField = "COMACADEMICSLNO"
                drpAcaSlno.DataBind()

                drpAcaSlno.SelectedValue = Session("COMACADEMICSLNO")

            End If
        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex

        End Try
    End Sub



#End Region

#Region "Grid Events"

    Private Sub dgVusers_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgVusers.EditCommand
        Try
            Dim UserSlno As Integer = dgVusers.Items(e.Item.ItemIndex).Cells(1).Text
            Mode = "Edit"
            If UserSlno = 1 Then
                StartUpScript("", "Admin user can not modify.")
                Exit Sub
            Else
                Response.Redirect("../Security/CreateOperators.aspx?UserSlno=" & UserSlno & "&Mode=" & Mode)
            End If
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub dgVusers_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgVusers.DeleteCommand
        Try
            Dim iEUSBMAPSLNO As Integer = dgVusers.Items(e.Item.ItemIndex).Cells(1).Text
            Dim UserSlno As Integer = dgVusers.Items(e.Item.ItemIndex).Cells(2).Text
            Dim RtnStr As String = ""
            If UserSlno = 1 Then
                StartUpScript("", "Admin user can not Delete.")
                Exit Sub
            End If
            RtnStr = objUcls.UserSubbatch_Delete(iEUSBMAPSLNO)
            If RtnStr = 1 Then
                FilldataGrid(0)
                StartUpScript("", "Record Deleted Successfully")
            Else
                StartUpScript("", RtnStr)
            End If

        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try

    End Sub

    Private Sub dgVusers_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgVusers.PageIndexChanged
        Try
            dsV = Session("ViewAllUsers_DataSet")
            dgVusers.CurrentPageIndex = e.NewPageIndex
            PageIndex = e.NewPageIndex
            Me.ViewState("PageIndex") = PageIndex
            dgVusers.DataSource = dsV.Tables(0)
            dgVusers.DataBind()
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub dgVusers_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgVusers.SortCommand
        Try
            dsV = Session("ViewAllUsers_DataSet")
            dsV.Tables(0).DefaultView.Sort = e.SortExpression
            dgVusers.DataSource = dsV.Tables(0)
            dgVusers.DataBind()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Image Buttons"

    Private Sub ibtnbatch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnBatch.Click
        Try
            Response.Redirect("UserWiseSubbatchPermisionBatch.aspx?USERTYPESLNO=" & DrpUserTypes.SelectedValue.ToString)
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

#End Region

    Private Sub iBtnSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSearch.Click
        Try
            FilldataGrid(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrpUserTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpUserTypes.SelectedIndexChanged
        Try
            FillUsers()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ibtnEdit_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnEdit.Click
        Try
            Response.Redirect("UserWiseSubbatchPermisionSingle.aspx?UserSlno=" & DrpUsers.SelectedValue.ToString & "&COURSESLNO=" & drpCourse.SelectedValue & "&GROUPSLNO=" & drpGroup.SelectedValue)
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

#Region "DropDown Events"
    Private Sub drpCourse_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpCourse.SelectedIndexChanged
        Try
            FillGroup()
            FillBatch()

        Catch ex As Exception
            StartUpScript(drpCourse.ID, ex.Message)
        End Try
    End Sub

    Private Sub drpGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpGroup.SelectedIndexChanged
        Try
            FillBatch()

        Catch ex As Exception
            StartUpScript(drpGroup.ID, ex.Message)
        End Try
    End Sub
#End Region

End Class
