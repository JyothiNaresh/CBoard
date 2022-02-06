'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Master of Penalties form
'   AUTHOR                            : KISHORE
'   INITIAL BASELINE DATE             : 22 Dec 2011
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Web.Services.Protocols
Imports CollegeBoardDLL
Imports System.Data.OracleClient
Imports CommonDLL
Imports System.Math
Public Class PENALTIES_DT
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtlblCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents dgGridSection As System.Web.UI.WebControls.DataGrid
    Protected WithEvents iBtnAdd As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Txtccode As System.Web.UI.WebControls.TextBox
    Protected WithEvents imgBtnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LBLCLGNAME As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Table4 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents drpshift As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtshtamt As System.Web.UI.WebControls.TextBox
    Protected WithEvents drpsoc As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtsocamt As System.Web.UI.WebControls.TextBox
    Protected WithEvents drpcourt As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtcouramt As System.Web.UI.WebControls.TextBox
    Protected WithEvents drprestart As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtrestamt As System.Web.UI.WebControls.TextBox
    Protected WithEvents tblsht As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Tblsoc As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblcourt As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblrest As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents drpclg As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents Tblclg As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtclgpenamt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents txtpentyear As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents txtpenpaidamt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents txtpendueamt As System.Web.UI.WebControls.TextBox
    Protected WithEvents drpptype As System.Web.UI.WebControls.DropDownList
    Protected WithEvents imgBtnGoo1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lstmCode As System.Web.UI.WebControls.TextBox

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
    Private DsSearch, DsResult As DataSet
    Public PageIndex As Integer
    Public SLNO, MNO, RtnVal As Integer
    Private FormName As String = "Form1"
    Private MODE As String
    Dim SqlStr As String
    Private objReport As Utility
    Dim DSet As New DataSet
#End Region

#Region "Common Methods"

    Protected Sub DeleteConformationMessage(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        Try
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Dim btn As Button = CType(e.Item.Cells(5).Controls(0), Button)
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
            Dim gk As String
            gk = "System.DBNull.Value"
            If Me.ViewState("MODE") = "NEW" Then
                Arr.Add(Val(Txtccode.Text))
                'shft
                If drpshift.SelectedValue = 1 Then
                    Arr.Add(Val(drpshift.SelectedValue))
                    Arr.Add(Val(txtshtamt.Text))

                Else
                    Arr.Add(Val(drpshift.SelectedValue))
                    If Trim(txtshtamt.Text) <> "" Then
                        Arr.Add((Val(txtshtamt.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If
                End If

               
                'soc
                If drpsoc.SelectedValue = 1 Then
                    Arr.Add(Val(drpsoc.SelectedValue))
                    Arr.Add(Val(txtsocamt.Text))

                Else
                    Arr.Add(Val(drpsoc.SelectedValue))
                    If Trim(txtsocamt.Text) <> "" Then
                        Arr.Add((Val(txtsocamt.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If
                End If
                'court
                If drpcourt.SelectedValue = 1 Then
                    Arr.Add(Val(drpcourt.SelectedValue))
                    Arr.Add(Val(txtcouramt.Text))

                Else
                    Arr.Add(Val(drpcourt.SelectedValue))
                    If Trim(txtcouramt.Text) <> "" Then
                        Arr.Add((Val(txtcouramt.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If
                End If
                'rest
                If drprestart.SelectedValue = 1 Then
                    Arr.Add(Val(drprestart.SelectedValue))
                    Arr.Add(Val(txtrestamt.Text))

                Else
                    Arr.Add(Val(drprestart.SelectedValue))
                    If Trim(txtrestamt.Text) <> "" Then
                        Arr.Add((Val(txtrestamt.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If
                End If
                Arr.Add(Val(txtpentyear.Text))
                Arr.Add(Val(drpptype.SelectedValue))
                Arr.Add(Val(txtpenpaidamt.Text))
                Arr.Add(Val(txtpendueamt.Text))
                'college
                If drpclg.SelectedValue = 1 Then
                    Arr.Add(Val(drpclg.SelectedValue))
                    Arr.Add(Val(txtclgpenamt.Text))

                Else
                    Arr.Add(Val(drpclg.SelectedValue))
                    If Trim(txtclgpenamt.Text) <> "" Then
                        Arr.Add((Val(txtclgpenamt.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If
                End If

                Arr.Add(Val(MNO))

            ElseIf Me.ViewState("MODE") = "EDIT" Then
                Arr.Add(Val(Val(Me.ViewState("SLNO"))))
                Arr.Add(Val(Txtccode.Text))

                'shft
                If drpshift.SelectedValue = 1 Then
                    Arr.Add(Val(drpshift.SelectedValue))
                    Arr.Add(Val(txtshtamt.Text))

                Else
                    Arr.Add(Val(drpshift.SelectedValue))
                    If Trim(txtshtamt.Text) <> "" Then
                        Arr.Add((Val(txtshtamt.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If
                End If
                'soc
                If drpsoc.SelectedValue = 1 Then
                    Arr.Add(Val(drpsoc.SelectedValue))
                    Arr.Add(Val(txtsocamt.Text))

                Else
                    Arr.Add(Val(drpsoc.SelectedValue))
                    If Trim(txtsocamt.Text) <> "" Then
                        Arr.Add((Val(txtsocamt.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If
                End If
                'court
                If drpcourt.SelectedValue = 1 Then
                    Arr.Add(Val(drpcourt.SelectedValue))
                    Arr.Add(Val(txtcouramt.Text))

                Else
                    Arr.Add(Val(drpcourt.SelectedValue))
                    If Trim(txtcouramt.Text) <> "" Then
                        Arr.Add((Val(txtcouramt.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If
                End If
                'rest
                If drprestart.SelectedValue = 1 Then
                    Arr.Add(Val(drprestart.SelectedValue))
                    Arr.Add(Val(txtrestamt.Text))

                Else
                    Arr.Add(Val(drprestart.SelectedValue))
                    If Trim(txtrestamt.Text) <> "" Then
                        Arr.Add((Val(txtrestamt.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If
                End If
                Arr.Add(Val(txtpentyear.Text))
                Arr.Add(Val(drpptype.SelectedValue))
                Arr.Add(Val(txtpenpaidamt.Text))
                Arr.Add(Val(txtpendueamt.Text))
                'college
                If drpclg.SelectedValue = 1 Then
                    Arr.Add(Val(drpclg.SelectedValue))
                    Arr.Add(Val(txtclgpenamt.Text))

                Else
                    Arr.Add(Val(drpclg.SelectedItem.Text))
                    If Trim(txtclgpenamt.Text) <> "" Then
                        Arr.Add((Val(txtclgpenamt.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If
                End If

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
            DsGA = objMaster.PENALTY_Select(SLNO)
            FillFire()
            If DsGA.Tables(0).Rows.Count > 0 Then
                Txtccode.Text = Val(DsGA.Tables(0).Rows(0)("CCODE").ToString)
                LBLCLGNAME.Text = DsGA.Tables(0).Rows(0)("COLLEGENAME").ToString
                drpshift.SelectedValue = DsGA.Tables(0).Rows(0)("SHIFTING").ToString

                If drpshift.SelectedValue = 1 Then
                    tblsht.Visible = True
                Else
                    tblsht.Visible = False
                End If
                txtshtamt.Text = Val(DsGA.Tables(0).Rows(0)("SHIFTING_PEN_AMT").ToString)

                drpsoc.SelectedValue = Val(DsGA.Tables(0).Rows(0)("SOC_NAME_CHANGE").ToString)

                If drpsoc.SelectedValue = 1 Then
                    Tblsoc.Visible = True
                Else
                    Tblsoc.Visible = False
                End If
                txtsocamt.Text = Val(DsGA.Tables(0).Rows(0)("SOC_NAME_CH_AMT").ToString)
                drpcourt.SelectedValue = Val(DsGA.Tables(0).Rows(0)("COURT_CASES").ToString)
                If drpcourt.SelectedValue = 1 Then
                    tblcourt.Visible = True
                Else
                    tblcourt.Visible = False
                End If
                txtcouramt.Text = Val(DsGA.Tables(0).Rows(0)("COURT_CASES_AMT").ToString)
                drprestart.SelectedValue = Val(DsGA.Tables(0).Rows(0)("RESTART").ToString)
                If drprestart.SelectedValue = 1 Then
                    tblrest.Visible = True
                Else
                    tblrest.Visible = False
                End If
                txtrestamt.Text = Val(DsGA.Tables(0).Rows(0)("RESTART_AMT").ToString)
                txtpentyear.Text = Val(DsGA.Tables(0).Rows(0)("PENT_YEAR").ToString)
                drpptype.SelectedValue = DsGA.Tables(0).Rows(0)("PENT_IMPOSED").ToString
                txtpenpaidamt.Text = Val(DsGA.Tables(0).Rows(0)("PENT_PAID").ToString)
                txtpendueamt.Text = Val(DsGA.Tables(0).Rows(0)("PENT_DUE").ToString)
                drpclg.SelectedValue = Val(DsGA.Tables(0).Rows(0)("CLG_CH_NAME").ToString)
                If drpclg.SelectedValue = 1 Then
                    Tblclg.Visible = True
                Else
                    Tblclg.Visible = False
                End If
                txtclgpenamt.Text = Val(DsGA.Tables(0).Rows(0)("CLG_PEN_AMT").ToString)
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
            Txtccode.Text = ""
            LBLCLGNAME.Text = ""
            drpshift.SelectedValue = 0
            txtshtamt.Text = ""
            drpsoc.SelectedValue = 0
            txtsocamt.Text = ""
            drpcourt.SelectedValue = 0
            txtcouramt.Text = ""
            drprestart.SelectedValue = 0
            txtrestamt.Text = ""
            txtpentyear.Text = ""
            drpptype.SelectedValue = 0
            txtpenpaidamt.Text = ""
            txtpendueamt.Text = ""
            drpclg.SelectedValue = 0
            txtclgpenamt.Text = ""
        Catch ex As Exception

        End Try

    End Sub

    Private Function FormValidations() As Boolean
        Try
            If Trim(Txtccode.Text) = "" Or Trim(Txtccode.Text) Is Nothing Then
                StartUpScript("Txtccode", "Enter College Code.")
                Return False
            ElseIf drpshift.SelectedItem.Text = "Select" Then
                StartUpScript(drpshift.ID, "Select Shifiting .")
                Return False
            ElseIf drpsoc.SelectedItem.Text = "Select" Then
                StartUpScript(drpsoc.ID, "Select Society Name Change.")
                Return False

            ElseIf drpcourt.SelectedItem.Text = "Select" Then
                StartUpScript(drpcourt.ID, "Select Court Cases.")
                Return False
            ElseIf drprestart.SelectedItem.Text = "Select" Then
                StartUpScript(drprestart.ID, "Select Restart .")
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

    'Private Sub MultiFillCode()
    '    Try
    '        Dim SqlStr As String
    '        Dim I As Integer

    '        SqlStr = "SELECT PENT.CCODE,CLG.COLLEGENAME  FROM  M_PENALTIES_DT PENT,EXAM_BOARDCOLLEGE_MT CLG WHERE PENT.CCODE=CLG.CODE ORDER BY PENT.CCODE"

    '        objReport = New Utility
    '        DSet = objReport.DataSet_OneFetch(SqlStr)
    '        lstmCode.DataSource = DSet.Tables(0)
    '        lstmCode.DataTextField = "CCODE"
    '        lstmCode.DataValueField = "CCODE"
    '        lstmCode.DataBind()

    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub FillGrid(ByVal PageIndex As Integer)
        Dim i, j As Integer

        Dim SqlStr1 As String

        Try

            If lstmCode.Text <> "" Then

                'For m As Integer = 0 To lstmCode.Items.Count - 1
                '    If lstmCode.Items(m).Selected Then
                '        SqlStr1 += lstmCode.Items(m).Value + ","
                '    End If
                'Next
                'SqlStr1 = SqlStr1.TrimEnd(",")
                'StrSql = "SELECT PENT.PENT_SLNO,PENT.CCODE,CLG.COLLEGENAME  FROM  M_PENALTIES_DT PENT,EXAM_BOARDCOLLEGE_MT CLG WHERE PENT.CCODE=CLG.CODE AND PENT.CCODE IN ( " & SqlStr1 & ") ORDER BY PENT.CCODE"
                StrSql = "SELECT PENT.PENT_SLNO,PENT.CCODE,CLG.COLLEGENAME  FROM  M_PENALTIES_DT PENT,EXAM_BOARDCOLLEGE_MT CLG WHERE PENT.CCODE=CLG.CODE AND PENT.CCODE = " & lstmCode.Text & "ORDER BY PENT.CCODE"
            Else
                StrSql = "SELECT PENT.PENT_SLNO,PENT.CCODE,CLG.COLLEGENAME  FROM  M_PENALTIES_DT PENT,EXAM_BOARDCOLLEGE_MT CLG WHERE PENT.CCODE=CLG.CODE ORDER BY PENT.CCODE"
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

                dgGridSection.CurrentPageIndex = PageIndex
                dgGridSection.DataSource = DsSearchResult
                dgGridSection.DataBind()

                Me.ViewState("DsSearchResult") = DsSearchResult
            End If
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Try
            dgGridSection.AllowPaging = True
            From = Request.QueryString("From")

            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                ButtonsHiding(Me.Page)

                Me.ViewState("PageIndex") = PageIndex

                If Me.ViewState("MODE") = "EDIT" Then
                    FillControls()
                End If
                'MultiFillCode()
                FillGrid(PageIndex)
                Table4.Visible = False
                tblsht.Visible = False
                Tblsoc.Visible = False
                tblcourt.Visible = False
                tblrest.Visible = False
                Tblclg.Visible = False
                FillFire()
            Else
                PageIndex = dgGridSection.CurrentPageIndex
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

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Try

            If Not FormValidations() Then Exit Sub
            objMaster = New ClsBoarddt

            If (Me.ViewState("MODE")) = "EDIT" Then
                RtnVal = objMaster.PENALTY_Update(SetEntries())
                If RtnVal = 1 Then
                    StartUpScript(iBtnSave.ID, "Record Updated Successfully.")
                    ClearControls()
                    FillGrid(PageIndex)
                    Table4.Visible = False

                Else
                    StartUpScript(iBtnSave.ID, "Record Not Updated.")
                End If
            ElseIf (Me.ViewState("MODE")) = "NEW" Then
                'ElseIf FLAG = Val(1) Then
                RtnVal = objMaster.PENALTY_Insert(SetEntries())
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
            tblsht.Visible = False
            Tblsoc.Visible = False
            tblcourt.Visible = False
            tblrest.Visible = False
            Tblclg.Visible = False
            ClearControls()
            FillFire()
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                StartUpScript(iBtnAdd.ID, " Transaction  Failed ")
            End If
        End Try
    End Sub

    Private Sub imgBtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnGo.Click
        Try

            If Trim(Txtccode.Text) <> "" Then
                GenerateSqlQuery()
            Else
                Exit Sub
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

    Private Sub imgBtnGoo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            FillGrid(PageIndex)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub imgBtnGoo1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnGoo1.Click
        Try
            FillGrid(PageIndex)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Sql Query"

    Private Sub GenerateSqlQuery()
        Try

            Dim SqlStr, SqlStr1 As String
            Dim I As Integer

            SqlStr = "SELECT COLLEGENAME FROM EXAM_BOARDCOLLEGE_MT WHERE CODE=" & Val(Txtccode.Text)

            ObjResult = New Utility

            DsResult = ObjResult.DataSet_Fetch(SqlStr)
            If DsResult.Tables(0).Rows.Count > 0 Then
                LBLCLGNAME.Text = DsResult.Tables(0).Rows(0)("COLLEGENAME")

                Session("DsResult") = DsResult.Tables(0)
            Else
                StartUpScript("", " Given College Code is Not Existed")

            End If

        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)
            StartUpScript("", " Transaction  Failed ")

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)
            StartUpScript("", " Transaction  Failed ")

        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
            StartUpScript("", " Transaction  Failed ")


        End Try
    End Sub

#End Region

#Region "Grid Events"

    Private Sub dgGridSection_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGridSection.EditCommand
        Try
            '  Response.Redirect("ExamTargerMappingSingleMode.aspx?MODE=EDIT&SLNO=" & dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text & "&PageIndex=" & CStr(PageIndex) & "")
            Me.ViewState("MODE") = "EDIT"
            SLNO = Val(dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text)
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

    Private Sub dgGridSection_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGridSection.DeleteCommand
        Try
            objMaster = New ClsBoarddt
            RtnVal = objMaster.PENALTY_DELETE(dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text)

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

    Private Sub dgGridSection_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgGridSection.PageIndexChanged
        Try
            dgGridSection.CurrentPageIndex = e.NewPageIndex
            Me.ViewState("PageIndex") = e.NewPageIndex
            DsSearchResult = Me.ViewState("DsSearchResult")
            dgGridSection.DataSource = DsSearchResult
            dgGridSection.DataBind()
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

#Region "DROPS"
    Private Sub FillFire()
        Try
            drpshift.Items.Clear()
            drpshift.Items.Insert(0, New ListItem("Select", 0))
            drpshift.Items.Insert(1, New ListItem("Yes", 1))
            drpshift.Items.Insert(2, New ListItem("No", 2))

            drpsoc.Items.Clear()
            drpsoc.Items.Insert(0, New ListItem("Select", 0))
            drpsoc.Items.Insert(1, New ListItem("Yes", 1))
            drpsoc.Items.Insert(2, New ListItem("No", 2))

            drpcourt.Items.Clear()
            drpcourt.Items.Insert(0, New ListItem("Select", 0))
            drpcourt.Items.Insert(1, New ListItem("Yes", 1))
            drpcourt.Items.Insert(2, New ListItem("No", 2))

            drprestart.Items.Clear()
            drprestart.Items.Insert(0, New ListItem("Select", 0))
            drprestart.Items.Insert(1, New ListItem("Yes", 1))
            drprestart.Items.Insert(2, New ListItem("No", 2))

        Catch ex As Exception
            StartUpScript("", ex.Message)
        End Try
    End Sub
#End Region

#Region "Drop Down Events"

    Private Sub drpshift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpshift.SelectedIndexChanged
        If drpshift.SelectedValue = 1 Then
            tblsht.Visible = True
        Else
            tblsht.Visible = False
        End If
    End Sub

    Private Sub drpsoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpsoc.SelectedIndexChanged
        If drpsoc.SelectedValue = 1 Then
            Tblsoc.Visible = True
        Else
            Tblsoc.Visible = False
        End If
    End Sub

    Private Sub drpcourt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpcourt.SelectedIndexChanged
        If drpcourt.SelectedValue = 1 Then
            tblcourt.Visible = True
        Else
            tblcourt.Visible = False
        End If
    End Sub

    Private Sub drprestart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drprestart.SelectedIndexChanged
        If drprestart.SelectedValue = 1 Then
            tblrest.Visible = True
        Else
            tblrest.Visible = False
        End If
    End Sub

    Private Sub drpclg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpclg.SelectedIndexChanged
        If drpclg.SelectedValue = 1 Then
            Tblclg.Visible = True
        Else
            Tblclg.Visible = False
        End If
    End Sub
#End Region

    'Protected Sub Submit(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim ccode As String = Request.Form(Txtccode1.UniqueID)
    'End Sub


    'Public Shared Function GetAutoCompleteData(ByVal username As String) As ListItem(Of, String)
    'Dim result As New List(Of, String)().
    ' SqlStr = "SELECT CCODE FROM  M_PENALTIES_DT WHERE CCODE LIKE '%'+@SearchText+'%"




End Class
