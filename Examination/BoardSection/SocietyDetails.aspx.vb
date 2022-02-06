'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Master of Society form
'   AUTHOR                            : KISHORE
'   INITIAL BASELINE DATE             : 22 Dec 2011
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Web.Services.Protocols
Imports CollegeBoardDLL
Imports System.Data.OracleClient
Imports CommonDLL
Imports System.Math
Public Class SocietyDetails
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtlblCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtaffextupto As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents txtmobile As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents txtcorpname As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents txtaddr2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents txtaddr1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtname As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtyos As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents txtregno As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents dgGridScoiety As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Table4 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents iBtnAdd As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Txtregdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    Protected WithEvents Txtccode1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents imgBtnGoo As System.Web.UI.WebControls.ImageButton

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
    Private objMaster As ClsBoarddt
    Private objMas As Masters
    Private ObjResult As Utility
    Private DsSearchResult As DataSet
    Public From As String
    Public Str, StrSql As String
    Private DsSearch As DataSet
    Public PageIndex As Integer
    Public SLNO, MNO, RtnVal As Integer
    Private FormName As String = "Form1"
    Private MODE As String
#End Region

#Region "Common Methods"

    Protected Sub DeleteConformationMessage(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        Try
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Dim btn As Button = CType(e.Item.Cells(12).Controls(0), Button)
                    btn.Attributes.Add("onclick", "return confirm('Are you sure to delete this record ?')")
                    Exit Select
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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
#End Region

#Region "Methods"

    Private Function SetEntries() As ArrayList
        Try
            Dim Arr As New ArrayList

            If Me.ViewState("MODE") = "NEW" Then
                Arr.Add(Val(txtregno.Text))
                Arr.Add(Trim(Txtregdate.Text))
                Arr.Add(Trim(txtname.Text))
                Arr.Add(Trim(txtaddr1.Text))
                Arr.Add(Trim(txtaddr2.Text))
                Arr.Add(Trim(txtcorpname.Text))
                Arr.Add(Val(txtmobile.Text))
                Arr.Add(Trim(txtyos.Text))
                Arr.Add(Trim(txtaffextupto.Text))
                Arr.Add(Val(MNO))
            ElseIf Me.ViewState("MODE") = "EDIT" Then
                Arr.Add(Val(Trim(Me.ViewState("SLNO"))))
                Arr.Add(Val(txtregno.Text))
                Arr.Add(Trim(Txtregdate.Text))
                Arr.Add(Trim(txtname.Text))
                Arr.Add(Trim(txtaddr1.Text))
                Arr.Add(Trim(txtaddr2.Text))
                Arr.Add(Trim(txtcorpname.Text))
                Arr.Add(Val(txtmobile.Text))
                Arr.Add(Trim(txtyos.Text))
                Arr.Add(Trim(txtaffextupto.Text))
                Arr.Add(Val(MNO))
            End If

            Return Arr

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub FillControls()
        Try

            Dim DsGA As DataSet
            DsGA = New DataSet
            objMaster = New ClsBoarddt


            DsGA = objMaster.SOCIETY_Select(SLNO)

            If DsGA.Tables(0).Rows.Count > 0 Then

                txtregno.Text = DsGA.Tables(0).Rows(0)("REGISTERED_NO").ToString
                Txtregdate.Text = DsGA.Tables(0).Rows(0)("REGISTERED_DATE").ToString
                txtname.Text = DsGA.Tables(0).Rows(0)("SOCT_NAME").ToString
                txtaddr1.Text = DsGA.Tables(0).Rows(0)("ADDRESS1").ToString
                txtaddr2.Text = DsGA.Tables(0).Rows(0)("ADDRESS2").ToString
                txtcorpname.Text = DsGA.Tables(0).Rows(0)("CORRESPONDENTNAME").ToString
                txtmobile.Text = DsGA.Tables(0).Rows(0)("MOBILE").ToString
                txtyos.Text = DsGA.Tables(0).Rows(0)("YEAROFSTART").ToString
                txtaffextupto.Text = DsGA.Tables(0).Rows(0)("AFFILT_EXT_UPTO").ToString

            Else

            End If

        Catch Oex As Exception
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ClearControls()
        Try
            txtregno.Text = ""
            Txtregdate.Text = ""
            txtyos.Text = ""
            txtname.Text = ""
            txtaddr1.Text = ""
            txtaddr2.Text = ""
            txtcorpname.Text = ""
            txtmobile.Text = ""
            txtaffextupto.Text = ""
        Catch ex As Exception

        End Try

    End Sub

    Private Function FormValidations() As Boolean
        Try
            If Trim(txtregno.Text) = "" Or Trim(txtregno.Text) Is Nothing Then
                StartUpScript("txtregno", "Enter Registration Number.")
                Return False
            ElseIf Trim(Txtregdate.Text) = "" Or Trim(Txtregdate.Text) Is Nothing Then
                StartUpScript("Txtregdate", "Enter Registration Date.")
                Return False
            ElseIf Trim(txtyos.Text) = "" Or Trim(txtyos.Text) Is Nothing Then
                StartUpScript("txtyos", "Enter Year of Starting.")
                Return False

            ElseIf Trim(txtname.Text) = "" Or Trim(txtname.Text) Is Nothing Then
                StartUpScript("txtname", "Enter Society Name.")
                Return False

            ElseIf Trim(txtaddr1.Text) = "" Or Trim(txtaddr1.Text) Is Nothing Then
                StartUpScript("txtaddr1", "Enter Address1.")
                Return False

            ElseIf Trim(txtaddr2.Text) = "" Or Trim(txtaddr2.Text) Is Nothing Then
                StartUpScript("txtaddr2", "Enter Address2.")
                Return False

            ElseIf Trim(txtcorpname.Text) = "" Or Trim(txtcorpname.Text) Is Nothing Then
                StartUpScript("txtcorpname", "Enter Corespendent Name.")
                Return False

            ElseIf Trim(txtmobile.Text) = "" Or Trim(txtmobile.Text) Is Nothing Then
                StartUpScript("txtmobile", "Enter Mobile Number.")
                Return False

            ElseIf Trim(txtaffextupto.Text) = "" Or Trim(txtaffextupto.Text) Is Nothing Then
                StartUpScript("txtaffextupto", "Enter Affilation  ext Upto.")
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
            If Not Request.QueryString("MNO") Is Nothing Then MNO = Request.QueryString("MNO")
            If Not Request.QueryString("PageIndex") Is Nothing Then PageIndex = Request.QueryString("PageIndex")

            Me.ViewState("MODE") = MODE
            Me.ViewState("SLNO") = SLNO
            Me.ViewState("MNO") = MNO
            Me.ViewState("PageIndex") = PageIndex

            If MNO = 1 Then
                lblHeading.Text = "Society Details&nbsp;"
                'Else
                '   lblHeading.Text = "Death&nbsp;Cause&nbsp;(Single Mode)"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetViewStateVariables()
        Try
            MODE = Me.ViewState("MODE")
            SLNO = Me.ViewState("SLNO")
            MNO = Me.ViewState("MNO")

            PageIndex = Me.ViewState("PageIndex")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Fill Methods"

    Private Sub FillGrid(ByVal PageIndex As Integer)
        Dim i, j As Integer

        Try

            If Txtccode1.Text <> "" Then

                StrSql = "SELECT SOCIETYSLNO,REGISTERED_NO,TO_CHAR(REGISTERED_DATE,'DD/MM/YY') REGISTERED_DATE,SOCT_NAME,ADDRESS1,ADDRESS2,CORRESPONDENTNAME,MOBILE,YEAROFSTART,AFFILT_EXT_UPTO FROM M_SOCIETY_DT  where REGISTERED_NO = " & Txtccode1.Text & " ORDER BY  REGISTERED_NO"

            Else
                StrSql = "SELECT SOCIETYSLNO,REGISTERED_NO,TO_CHAR(REGISTERED_DATE,'DD/MM/YY') REGISTERED_DATE,SOCT_NAME,ADDRESS1,ADDRESS2,CORRESPONDENTNAME,MOBILE,YEAROFSTART,AFFILT_EXT_UPTO FROM M_SOCIETY_DT ORDER BY  REGISTERED_NO"
            End If


            ObjResult = New Utility

            DsSearchResult = ObjResult.DataSet_OneFetch(StrSql)

            Me.ViewState("DsSearchResult") = DsSearchResult

            If Not DsSearchResult Is Nothing Then
                '' Setting Page Indexs
                If (DsSearchResult.Tables(0).Rows.Count - 1) / 10 < PageIndex Then

                    If ((DsSearchResult.Tables(0).Rows.Count - 1) / 10) <= 1 Then
                        PageIndex = 0
                    Else
                        PageIndex = PageIndex - 1
                    End If
                End If

                dgGridScoiety.CurrentPageIndex = PageIndex
                dgGridScoiety.DataSource = DsSearchResult
                dgGridScoiety.DataBind()

                Me.ViewState("DsSearchResult") = DsSearchResult
            End If
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub FillTitle()
        lblHeading.Text = "Society Dtails  "
    End Sub
#End Region

#Region "Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Try
            dgGridScoiety.AllowPaging = True
            From = Request.QueryString("From")

            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                ButtonsHiding(Me.Page)
                'SLNO, MNO
                'If Not Request.QueryString("SLNO") Is Nothing AndAlso Request.QueryString("SLNO") <> "" Then SLNO = Request.QueryString("SLNO")
                'Me.ViewState("SLNO") = SLNO

                'If Not Request.QueryString("MNO") Is Nothing AndAlso Request.QueryString("MNO") <> "" Then MNO = Request.QueryString("MNO")
                'Me.ViewState("MNO") = MNO

                'If Not Request.QueryString("PageIndex") Is Nothing AndAlso Request.QueryString("PageIndex") <> "" Then
                '    PageIndex = CInt(Request.QueryString("PageIndex"))
                'Else
                '    PageIndex = 0
                'End If

                Me.ViewState("PageIndex") = PageIndex

                'SetViewStateVariables()

                If Me.ViewState("MODE") = "EDIT" Then
                    FillControls()
                End If
                StartUpScript(txtregno.ID, "")
                FillGrid(PageIndex)
                Table4.Visible = False
            Else
                PageIndex = dgGridScoiety.CurrentPageIndex
                GetViewStateVariables()
                'MODE = "NEW"
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

    Private Sub iBtnCancel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            'Response.Write("<script language=Javascript>Javascript:window.open('../../welcome.htm','MainTextPart');</script>")
            Table4.Visible = False
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                'StartUpScript(iBtnCancel.ID, " Transaction  Failed ")
            End If
        End Try
    End Sub

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Try

            If Not FormValidations() Then Exit Sub
            objMaster = New ClsBoarddt

            If (Me.ViewState("MODE")) = "EDIT" Then
                RtnVal = objMaster.SOCIETY_Update(SetEntries())
                If RtnVal = 1 Then
                    StartUpScript(iBtnSave.ID, "Record Updated Successfully.")
                    ClearControls()
                    FillGrid(PageIndex)
                    Table4.Visible = False
                    '                    Response.Redirect("ExamTarget.aspx?PageIndex=" & PageIndex & "&MNO=" & MNO)
                Else
                    StartUpScript(iBtnSave.ID, "Record Not Updated.")
                End If
            ElseIf (Me.ViewState("MODE")) = "NEW" Then
                'ElseIf FLAG = Val(1) Then
                RtnVal = objMaster.SOCIETY_Insert(SetEntries())
                If RtnVal = 1 Then
                    StartUpScript(iBtnSave.ID, "Record Saved Successfully.")
                    ClearControls()
                    FillGrid(PageIndex)
                    Table4.Visible = False
                Else
                    StartUpScript(iBtnSave.ID, "Record Not Saved.")
                End If

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
                StartUpScript("", GeneralErrorMessage(ex.Message))
                If Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & "ADMIN" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                     "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                Else
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                     "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                End If
            End If
        End Try
    End Sub

    Private Sub iBtnAdd_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnAdd.Click
        Try
            Me.ViewState("MODE") = "NEW"
            Table4.Visible = True
            ClearControls()
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                StartUpScript(iBtnAdd.ID, " Transaction  Failed ")
            End If
        End Try
    End Sub
#End Region

#Region "Grid Events"

    Private Sub dgGridScoiety_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGridScoiety.EditCommand
        Try
            '  Response.Redirect("ExamTargerMappingSingleMode.aspx?MODE=EDIT&SLNO=" & dgGridScoiety.Items(e.Item.ItemIndex).Cells(1).Text & "&PageIndex=" & CStr(PageIndex) & "")
            Me.ViewState("MODE") = "EDIT"
            SLNO = Val(dgGridScoiety.Items(e.Item.ItemIndex).Cells(1).Text)
            Me.ViewState("SLNO") = SLNO
            Table4.Visible = True
            ClearControls()
            FillControls()
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

    Private Sub dgGridScoiety_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGridScoiety.DeleteCommand
        Try
            objMaster = New ClsBoarddt
            RtnVal = objMaster.SOCIETY_DELETE(dgGridScoiety.Items(e.Item.ItemIndex).Cells(1).Text)

            If RtnVal = 1 Then
                FillGrid(PageIndex)
                StartUpScript("", "Record Deleted Successfully")
            Else
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

    Private Sub dgGridScoiety_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgGridScoiety.PageIndexChanged
        Try
            dgGridScoiety.CurrentPageIndex = e.NewPageIndex
            Me.ViewState("PageIndex") = e.NewPageIndex
            DsSearchResult = Me.ViewState("DsSearchResult")
            dgGridScoiety.DataSource = DsSearchResult
            dgGridScoiety.DataBind()
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

    Private Sub imgBtnGoo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnGoo.Click
        Try
            FillGrid(PageIndex)
        Catch ex As Exception

        End Try
    End Sub
End Class
