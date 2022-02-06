'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : Master Batch
'   AUTHOR                            : 
'   INITIAL BASELINE DATE             : 
'   MODIFICATIONS LOG                 : Adding  Sub Caste by Kishore [09.Apr.2013]
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL

Public Class MastersBatch
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtSetfocus As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents LblCourse As System.Web.UI.WebControls.Label
    Protected WithEvents dgACT As System.Web.UI.WebControls.DataGrid
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnCancel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents DrpBoardMaster As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpCaste As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Table4 As System.Web.UI.HtmlControls.HtmlTable

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

    Private objBoardEnrollment As ClsBoardEnrollment
    Public From As String
    Public Str As String
    Private Edit As String
    Private DsSearch As DataSet
    Public PageIndex As Integer
    Public SelCourse As String
    Public SelSubject As String
    Private objError As clsError
    Public BEMset As New DataSet
    Public SLNO, BENO As Integer
    Private MODE, HEAD As String
    Private ObjResult As Utility
    Dim DS As New DataSet
    Private StrSql As String
#End Region

#Region "Methods"
    Private Sub PrepareTable()
        Try

            Dim Dt As DataTable
            Dim I As Int16

            BEMset.Tables.Add(New DataTable("BEMAS"))

            Dt = BEMset.Tables("BEMAS")
            Dt.Columns.Add("DGSLNO")
            Dt.Columns.Add("CODE")
            Dt.Columns.Add("NAME")
            Dt.Columns.Add("DESCRIPTION")
            Dt.Columns.Add("BENO")


            For I = 1 To 10
                Dim dRow As DataRow
                dRow = Dt.NewRow
                dRow("DGSLNO") = I
                Dt.Rows.Add(dRow)
            Next

            Me.ViewState("BEMset") = BEMset

            dgACT.DataSource = Dt
            dgACT.DataBind()



        Catch ex As Exception
            objError = New clsError
            StartUpScript(Me.ID, objError.errHandler(ex))
        End Try
    End Sub

    Private Function setEnties() As DataSet

        Try
            Dim i As Integer
            Dim DsBE As New DataSet
            Dim dt As DataTable
            Dim dr As DataRow

            DsBE.Tables.Add(New DataTable("Name"))

            dt = DsBE.Tables("Name")

            dt.Columns.Add("CODE", GetType(System.String))
            dt.Columns.Add("NAME", GetType(System.String))
            dt.Columns.Add("DESCRIPTION", GetType(System.String))
            dt.Columns.Add("BENO", GetType(System.Int32))
            dt.Columns.Add("CODE1", GetType(System.String))

            For i = 0 To 9
                Dim gtxtT, gtxtD, gtxtC As TextBox
                'Dim gdrpAct As DropDownList
                'gdrpAct = dgACT.Items(i).Cells(1).Controls(1)
                gtxtC = dgACT.Items(i).Cells(1).Controls(1)
                gtxtT = dgACT.Items(i).Cells(2).Controls(1)
                gtxtD = dgACT.Items(i).Cells(3).Controls(1)

                If Trim(gtxtC.Text) <> "" AndAlso Not Trim(gtxtC.Text) Is Nothing Then
                    dr = DsBE.Tables("Name").NewRow
                    dr("CODE") = UCase(Trim(gtxtC.Text))
                    dr("NAME") = UCase(Trim(gtxtT.Text))
                    dr("DESCRIPTION") = UCase(Trim(gtxtD.Text))
                    dr("BENO") = Val(DrpBoardMaster.SelectedValue)

                    If DrpCaste.SelectedValue > 0 Then
                        dr("CODE1") = Val(DrpCaste.SelectedValue)
                    Else
                        dr("CODE1") = Val(0)
                    End If
                    DsBE.Tables("Name").Rows.Add(dr)

                End If

            Next
            Me.ViewState("DsBE") = DsBE
            Return DsBE

        Catch ex As Exception
            objError = New clsError
            StartUpScript(Me.ID, objError.errHandler(ex))
        End Try

    End Function

    Private Function FormValidations() As Boolean
        BEMset = Me.ViewState("BEMset")
        If (BEMset Is Nothing) Or (BEMset.Tables(0).Rows.Count = 0) Then
            StartUpScript("", "Enter Name For Atleast one Row In The Grid")
            Return False
        End If
        Return True
    End Function

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")

        Try
            If focusCtrl <> "" And strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.Topics." & focusCtrl & " == '[object]') { document.Topics." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf focusCtrl <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.Topics." & focusCtrl & " == '[object]') { document.Topics." & focusCtrl & ".focus(); } </script>")
            Else

            End If

        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region "Fill Methods"

    Private Sub FillCaste()
        Try
            StrSql = "SELECT BOARDCASTESLNO SLNO, NAME ,CODE  FROM EXAM_BOARDCASTE_MT ORDER BY NAME"

            ObjResult = New Utility
            DS = ObjResult.GetCommDataSet(StrSql)

            DrpCaste.DataSource = DS.Tables(0)
            DrpCaste.DataTextField = "NAME"
            DrpCaste.DataValueField = "SLNO"
            DrpCaste.DataBind()
            DrpCaste.Items.Insert(0, New ListItem("Select", 0))

        Catch ex As Exception
            StartUpScript("", ex.Message)
        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                ButtonsHiding(Me.Page)
                SetViewStateVariables()
                Table4.Visible = False
                FillCaste()
                If BENO = Val(14) Then
                    Table4.Visible = True
                    FillCaste()
                End If

                If Not Request.QueryString("PageIndex") Is Nothing AndAlso Request.QueryString("PageIndex") <> "" Then
                    PageIndex = CInt(Request.QueryString("PageIndex"))
                Else
                    PageIndex = 0
                End If
                Me.ViewState("PageIndex") = PageIndex


                PrepareTable()

            Else
                GetViewStateVariables()
                BEMset = Me.ViewState("BEMSET")
                SelSubject = Me.ViewState("SelSubject")
                SelCourse = Me.ViewState("SelCourse")
                PageIndex = CInt(Me.ViewState("PageIndex"))
                From = Me.ViewState("From")
                Str = Me.ViewState("Str")

            End If
        Catch ex As Exception
            objError = New clsError
            StartUpScript(Me.ID, objError.errHandler(ex))
        End Try
    End Sub

    Private Sub SetViewStateVariables()
        Try
            If Not Request.QueryString("MODE") Is Nothing Then MODE = Request.QueryString("MODE")
            If Not Request.QueryString("SLNO") Is Nothing Then SLNO = Request.QueryString("SLNO")
            If Not Request.QueryString("BENO") Is Nothing Then BENO = Request.QueryString("BENO")
            If Not Request.QueryString("HEAD") Is Nothing Then HEAD = Request.QueryString("HEAD")
            If Not Request.QueryString("PageIndex") Is Nothing Then PageIndex = Request.QueryString("PageIndex")

            Me.ViewState("MODE") = MODE
            Me.ViewState("SLNO") = SLNO
            Me.ViewState("BENO") = BENO
            Me.ViewState("HEAD") = HEAD
            Me.ViewState("PageIndex") = PageIndex
            lblHeading.Text = "Board&nbsp;" + HEAD + "&nbsp;(Batch&nbsp;Mode)"
            DrpBoardMaster.SelectedValue = BENO
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetViewStateVariables()
        Try
            MODE = Me.ViewState("MODE")
            SLNO = Me.ViewState("SLNO")
            BENO = Me.ViewState("BENO")
            PageIndex = Me.ViewState("PageIndex")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Buttons"

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Response.Redirect("GroupActivityHome.aspx?PageIndex=" & PageIndex & "&GANO=" & DrpActivity.SelectedValue)
        Catch ex As Exception
            objError = New clsError
            StartUpScript(Me.ID, objError.errHandler(ex))
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strReturnValue As String = ""
        Try

            If Not FormValidations() Then Exit Sub
            objBoardEnrollment = New ClsBoardEnrollment

            strReturnValue = objBoardEnrollment.MastersBatch(setEnties)
            StartUpScript(Me.ID, strReturnValue)
            BEMset.Tables.Clear()
            PrepareTable()

            Me.ViewState("GADset") = BEMset


        Catch ex As Exception
            objError = New clsError
            StartUpScript(Me.ID, objError.errHandler(ex))

        End Try
    End Sub


#End Region

#Region "Image Buttons"

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Try
            cmdSave_Click(sender, e)
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


    Private Sub iBtnCancel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnCancel.Click
        Try
            Response.Redirect("MastersHome.aspx?PageIndex=" & PageIndex & "&BENO=" & BENO)
            cmdCancel_Click(sender, e)
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                StartUpScript(iBtnCancel.ID, " Transaction  Failed ")
            End If
        End Try
    End Sub

#End Region


End Class
