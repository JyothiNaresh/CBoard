'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Master of Affilation form
'   AUTHOR                            : KISHORE
'   INITIAL BASELINE DATE             : 22 Dec 2011
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Web.Services.Protocols
Imports CollegeBoardDLL
Imports System.Data.OracleClient
Imports CommonDLL
Imports System.Math
Public Class Affilation_Dt
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
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Table4 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblbuld As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox9 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents drppgtype As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox10 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox11 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox12 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox13 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label18 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox14 As System.Web.UI.WebControls.TextBox
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
                Arr.Add(Val(Textbox1.Text))
                Arr.Add(Val(Textbox2.Text))
                Arr.Add(Val(Textbox3.Text))
                Arr.Add(Trim(Textbox4.Text))
                Arr.Add(Val(Textbox5.Text))
                Arr.Add(Val(Textbox6.Text))
                Arr.Add(Val(Textbox7.Text))
                Arr.Add(Val(Textbox8.Text))
                Arr.Add(Val(Textbox9.Text))


                If drppgtype.SelectedValue = 2 Then
                    Arr.Add(Val(drppgtype.SelectedValue))
                    Arr.Add(Val(Textbox10.Text))
                    Arr.Add(Trim(Textbox11.Text))
                    Arr.Add(Val(Textbox12.Text))

                ElseIf drppgtype.SelectedValue = 1 Then
                    Arr.Add(Val(drppgtype.SelectedValue))
                    If Trim(Textbox10.Text) <> "" Then
                        Arr.Add((Val(Textbox10.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If
                    If Trim(Textbox11.Text) <> "" Then
                        Arr.Add((Trim(Textbox11.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If
                    If Trim(Textbox12.Text) <> "" Then
                        Arr.Add((Val(Textbox12.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If

                End If
                Arr.Add(Trim(Textbox13.Text))
                Arr.Add(Trim(Textbox14.Text))
                Arr.Add(Val(MNO))

            ElseIf Me.ViewState("MODE") = "EDIT" Then
                Arr.Add(Val(Val(Me.ViewState("SLNO"))))
                Arr.Add(Val(Txtccode.Text))
                Arr.Add(Val(Textbox1.Text))
                Arr.Add(Val(Textbox2.Text))
                Arr.Add(Val(Textbox3.Text))
                Arr.Add(Trim(Textbox4.Text))
                Arr.Add(Val(Textbox5.Text))
                Arr.Add(Val(Textbox6.Text))
                Arr.Add(Val(Textbox7.Text))
                Arr.Add(Val(Textbox8.Text))
                Arr.Add(Val(Textbox9.Text))


                If drppgtype.SelectedValue = 2 Then
                    Arr.Add(Val(drppgtype.SelectedValue))
                    Arr.Add(Val(Textbox10.Text))
                    Arr.Add(Trim(Textbox11.Text))
                    Arr.Add(Val(Textbox12.Text))

                ElseIf drppgtype.SelectedValue = 1 Then
                    Arr.Add(Val(drppgtype.SelectedValue))
                    If Trim(Textbox10.Text) <> "" Then
                        Arr.Add((Val(Textbox10.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If
                    If Trim(Textbox11.Text) <> "" Then
                        Arr.Add((Trim(Textbox11.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If
                    If Trim(Textbox12.Text) <> "" Then
                        Arr.Add((Val(Textbox12.Text)))
                    Else
                        Arr.Add(System.DBNull.Value)
                    End If

                End If
                Arr.Add(Trim(Textbox13.Text))
                Arr.Add(Trim(Textbox14.Text))
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
            DsGA = objMaster.AFFLT_Select(SLNO)
            FillFire()
            If DsGA.Tables(0).Rows.Count > 0 Then
                Txtccode.Text = Val(DsGA.Tables(0).Rows(0)("CCODE").ToString)
                LBLCLGNAME.Text = DsGA.Tables(0).Rows(0)("COLLEGENAME").ToString
                Textbox1.Text = DsGA.Tables(0).Rows(0)("MAG_AMONT").ToString
                Textbox2.Text = DsGA.Tables(0).Rows(0)("DUE_MAG_AMT").ToString
                Textbox3.Text = DsGA.Tables(0).Rows(0)("SURPLUS_BIE_AMT").ToString
                Textbox4.Text = DsGA.Tables(0).Rows(0)("AFFYEAR").ToString
                Textbox5.Text = DsGA.Tables(0).Rows(0)("APPLICATION_FEE").ToString
                Textbox6.Text = DsGA.Tables(0).Rows(0)("ORG_SEC_FEE").ToString
                Textbox7.Text = DsGA.Tables(0).Rows(0)("ADD_SEC_FEE").ToString
                Textbox8.Text = DsGA.Tables(0).Rows(0)("INSP_FEE").ToString
                Textbox9.Text = DsGA.Tables(0).Rows(0)("LATE_FEE").ToString
                drppgtype.SelectedValue = Val(DsGA.Tables(0).Rows(0)("PAY_TYPE").ToString)
                If drppgtype.SelectedValue = 2 Then
                    tblbuld.Visible = True
                Else
                    tblbuld.Visible = False
                End If
                Textbox10.Text = DsGA.Tables(0).Rows(0)("DD_NO").ToString
                Textbox11.Text = DsGA.Tables(0).Rows(0)("DD_DATE").ToString
                Textbox12.Text = DsGA.Tables(0).Rows(0)("DD_AMT").ToString
                Textbox13.Text = DsGA.Tables(0).Rows(0)("AFFEXTDUPTO").ToString
                Textbox14.Text = DsGA.Tables(0).Rows(0)("BANKNAME").ToString
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
            Textbox1.Text = ""
            Textbox2.Text = ""
            Textbox3.Text = ""
            Textbox4.Text = ""
            Textbox5.Text = ""
            Textbox6.Text = ""
            Textbox7.Text = ""
            Textbox8.Text = ""
            Textbox9.Text = ""
            Textbox10.Text = ""
            Textbox11.Text = ""
            Textbox12.Text = ""
            Textbox13.Text = ""
            Textbox14.Text = ""
            drppgtype.SelectedValue = 0

        Catch ex As Exception

        End Try

    End Sub

    Private Function FormValidations() As Boolean
        Try
            If Trim(Txtccode.Text) = "" Or Trim(Txtccode.Text) Is Nothing Then
                StartUpScript("Txtccode", "Enter College Code.")
                Return False
            ElseIf Trim(Textbox1.Text) = "" Or Trim(Textbox1.Text) Is Nothing Then
                StartUpScript("Textbox1", "Enter Paid  By Manegement Amount.")
                Return False
            ElseIf Trim(Textbox2.Text) = "" Or Trim(Textbox2.Text) Is Nothing Then
                StartUpScript("Textbox2", "Enter Due From Manegement Amount.")
                Return False
            
            ElseIf Trim(Textbox3.Text) = "" Or Trim(Textbox3.Text) Is Nothing Then
                StartUpScript("Textbox3", "Enter Surplus BIE Amount.")
                Return False
            ElseIf Trim(Textbox4.Text) = "" Or Trim(Textbox4.Text) Is Nothing Then
                StartUpScript("Textbox4", "Enter Affilication Year.")
                Return False
            ElseIf Trim(Textbox5.Text) = "" Or Trim(Textbox5.Text) Is Nothing Then
                StartUpScript("Textbox5", "Enter Applilcation Fee.")
                Return False
            ElseIf Trim(Textbox6.Text) = "" Or Trim(Textbox6.Text) Is Nothing Then
                StartUpScript("Textbox6", "Enter Original Science Sections Fee.")
                Return False
            ElseIf Trim(Textbox7.Text) = "" Or Trim(Textbox7.Text) Is Nothing Then
                StartUpScript("Textbox7", "Enter Additional Science Sections Fee.")
                Return False
            ElseIf Trim(Textbox8.Text) = "" Or Trim(Textbox8.Text) Is Nothing Then
                StartUpScript("Textbox8", "Enter Inspiction Fee.")
                Return False
            ElseIf Trim(Textbox9.Text) = "" Or Trim(Textbox9.Text) Is Nothing Then
                StartUpScript("Textbox9", "Enter Late Fee.")
                Return False
            ElseIf Trim(Textbox13.Text) = "" Or Trim(Textbox13.Text) Is Nothing Then
                StartUpScript("Textbox13", "Enter Aff.Extd. Upto.")
                Return False

            ElseIf Trim(Textbox14.Text) = "" Or Trim(Textbox14.Text) Is Nothing Then
                StartUpScript("Textbox14", "Enter Bank Name.")
                Return False

            ElseIf drppgtype.SelectedItem.Text = "Select" Then
                StartUpScript(drppgtype.ID, "Select Payment Mode .")
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

    '        SqlStr = "SELECT AFF.CCODE FROM  M_AFFILIATION_DT AFF,EXAM_BOARDCOLLEGE_MT CLG WHERE AFF.CCODE=CLG.CODE ORDER BY AFF.CCODE"
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

            If lstmCode.TEXT <> "" Then

                'For m As Integer = 0 To lstmCode.Items.Count - 1
                '    If lstmCode.Items(m).Selected Then
                '        SqlStr1 += lstmCode.Items(m).Value + ","
                '    End If
                'Next
                'SqlStr1 = SqlStr1.TrimEnd(",")

                'StrSql = "SELECT AFF.AFFLSLNO,AFF.CCODE,CLG.COLLEGENAME  FROM  M_AFFILIATION_DT AFF,EXAM_BOARDCOLLEGE_MT CLG WHERE AFF.CCODE=CLG.CODE  AND  AFF.CCODE IN ( " & SqlStr1 & " ) ORDER BY AFF.CCODE"

                StrSql = "SELECT AFF.AFFLSLNO,AFF.CCODE,CLG.COLLEGENAME  FROM  M_AFFILIATION_DT AFF,EXAM_BOARDCOLLEGE_MT CLG WHERE AFF.CCODE=CLG.CODE  AND  AFF.CCODE=" & lstmCode.Text & " ORDER BY AFF.CCODE"
            Else
                StrSql = "SELECT AFF.AFFLSLNO,AFF.CCODE,CLG.COLLEGENAME  FROM  M_AFFILIATION_DT AFF,EXAM_BOARDCOLLEGE_MT CLG WHERE AFF.CCODE=CLG.CODE ORDER BY AFF.CCODE"
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
                ButtonsHiding(Me.Page)

                Me.ViewState("PageIndex") = PageIndex

                If Me.ViewState("MODE") = "EDIT" Then
                    FillControls()
                End If

                FillGrid(PageIndex)
                'MultiFillCode()
                Table4.Visible = False
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
                RtnVal = objMaster.AFFLT_Update(SetEntries())
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
                RtnVal = objMaster.AFFLT_Insert(SetEntries())
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
            MODE = "NEW"
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
            RtnVal = objMaster.AFFLT_DELETE(dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text)

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
            drppgtype.Items.Clear()
            drppgtype.Items.Insert(0, New ListItem("Select", 0))
            drppgtype.Items.Insert(1, New ListItem("Cash", 1))
            drppgtype.Items.Insert(2, New ListItem("DD", 2))


        Catch ex As Exception
            StartUpScript("", ex.Message)
        End Try
    End Sub
#End Region

#Region "Drop Down Events"

    Private Sub drppgtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drppgtype.SelectedIndexChanged
        If drppgtype.SelectedValue = 2 Then
            tblbuld.Visible = True
        Else
            tblbuld.Visible = True
        End If
    End Sub
#End Region


End Class
