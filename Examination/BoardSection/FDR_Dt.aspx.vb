'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Master of FDR form
'   AUTHOR                            : KISHORE
'   INITIAL BASELINE DATE             : 22 Dec 2011
'   MODIFICATIONS LOG                 : KISHORE ADD DATE FORMATE ETC..,30-04-2013,
'                                      Srikanth Modified Date ETC......17/07/2013
'----------------------------------------------------------------------------------------------
Imports System.Web.Services.Protocols
Imports CollegeBoardDLL
Imports System.Data.OracleClient
Imports CommonDLL
Imports System.Math
Public Class FDR_DT
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
    Protected WithEvents Table4 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents tblbuld As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Drprels As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Table10 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtfdrno As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents txtbkname As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents txtamt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents txtfdracno As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents txtMaturityamt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents txtInterest As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtfdrdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtfdrmdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtreldate As System.Web.UI.WebControls.TextBox
    Protected WithEvents regexpDate As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents RegularExpressionValidator15 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents RegularExpressionValidator2 As System.Web.UI.WebControls.RegularExpressionValidator
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
                Arr.Add(Trim(Txtccode.Text))
                Arr.Add(Val(txtfdrno.Text))
                Arr.Add(Trim(txtfdracno.Text))
                Arr.Add(Val(txtMaturityamt.Text))
                Arr.Add(Val(txtInterest.Text))
                Arr.Add(Trim(txtbkname.Text))
                Arr.Add(Val(txtamt.Text))
                'Arr.Add(DateConversion(Trim(txtfdrdate.Text)))
                'Arr.Add(DateConversion(Trim(txtfdrmdate.Text)))

                If Trim(txtfdrdate.Text) <> "" Then
                    'Arr.Add(DateConversion(Trim(txtfdrdate.Text)))
                    Arr.Add(DateConversion(Trim(txtfdrdate.Text)))

                Else
                    'Arr.Add(System.DBNull.Value)
                    Arr.Add(System.DBNull.Value)

                End If

                If Trim(txtfdrmdate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtfdrmdate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If

                Arr.Add(Val(Drprels.SelectedValue))
                'Arr.Add(DateConversion(Trim(txtreldate.Text)))
                If Trim(txtreldate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtreldate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If

                Arr.Add(Val(MNO))
            ElseIf Me.ViewState("MODE") = "EDIT" Then
                Arr.Add(Val(Val(Me.ViewState("SLNO"))))
                'Arr.Add(Val(Txtccode.Text))
                Arr.Add(Trim(Txtccode.Text))
                Arr.Add(Val(txtfdrno.Text))
                Arr.Add(Trim(txtfdracno.Text))
                Arr.Add(Val(txtMaturityamt.Text))
                Arr.Add(Val(txtInterest.Text))
                Arr.Add(Trim(txtbkname.Text))
                Arr.Add(Val(txtamt.Text))

                If Trim(txtfdrdate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtfdrdate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                If Trim(txtfdrmdate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtfdrmdate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If

                Arr.Add(Val(Drprels.SelectedValue))
                If Trim(txtreldate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtreldate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
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
            DsGA = objMaster.FDR_Select(SLNO)

            If DsGA.Tables(0).Rows.Count > 0 Then
                Txtccode.Text = DsGA.Tables(0).Rows(0)("CCODE").ToString
                LBLCLGNAME.Text = DsGA.Tables(0).Rows(0)("COLLEGENAME").ToString
                txtfdrno.Text = Val(DsGA.Tables(0).Rows(0)("FDRNO").ToString)
                txtfdracno.Text = Trim(DsGA.Tables(0).Rows(0)("FDRACNO").ToString)
                txtMaturityamt.Text = Trim(DsGA.Tables(0).Rows(0)("MATURITY_AMT").ToString)
                txtInterest.Text = Trim(DsGA.Tables(0).Rows(0)("RATEOF_INT").ToString)
                txtbkname.Text = Trim(DsGA.Tables(0).Rows(0)("BANKNAME").ToString)
                txtamt.Text = Val(DsGA.Tables(0).Rows(0)("AMOUNT").ToString)
                txtfdrdate.Text = Trim(DsGA.Tables(0).Rows(0)("FDRDATE").ToString)
                txtfdrmdate.Text = Trim(DsGA.Tables(0).Rows(0)("MATURITY_DATE").ToString)

                If txtfdrdate.Text = "1/1/1900" Or txtfdrdate.Text = "01-JAN-1900" Then
                    txtfdrdate.Text = ""
                Else
                    txtfdrdate.Text = Trim(DsGA.Tables(0).Rows(0)("FDRDATE").ToString)
                End If
                If txtfdrmdate.Text = "1/1/1900" Or txtfdrmdate.Text = "01-JAN-1900" Then
                    txtfdrmdate.Text = ""
                Else
                    txtfdrmdate.Text = Trim(DsGA.Tables(0).Rows(0)("MATURITY_DATE").ToString)
                End If
                Drprels.SelectedValue = Val(DsGA.Tables(0).Rows(0)("FDRRELEASE").ToString)

                If Drprels.SelectedValue Then
                    Table10.Visible = True
                    txtreldate.Text = Trim(DsGA.Tables(0).Rows(0)("RELEASEDATE").ToString)
                    If txtreldate.Text = "1/1/1900" Or txtreldate.Text = "01-JAN-1900" Then
                        txtreldate.Text = ""
                    Else
                        txtreldate.Text = Trim(DsGA.Tables(0).Rows(0)("RELEASEDATE").ToString)
                    End If
                End If

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
            txtfdrno.Text = ""
            txtfdracno.Text = ""
            txtMaturityamt.Text = ""
            txtInterest.Text = ""
            txtbkname.Text = ""
            txtamt.Text = ""
            txtfdrdate.Text = ""
            txtfdrmdate.Text = ""

        Catch ex As Exception

        End Try

    End Sub

    Private Function FormValidations() As Boolean
        Try
            If Trim(Txtccode.Text) = "" Or Trim(Txtccode.Text) Is Nothing Then
                StartUpScript("Txtccode", "Enter College Code.")
                Return False
            ElseIf Trim(txtfdrno.Text) = "" Or Trim(txtfdrno.Text) Is Nothing Then
                StartUpScript("txtfdrno", "Enter FDR No.")
                Return False
            ElseIf Trim(txtfdracno.Text) = "" Or Trim(txtfdracno.Text) Is Nothing Then
                StartUpScript("txtfdracno", "Enter FDR A/C No.")
                Return False
            ElseIf Trim(txtbkname.Text) = "" Or Trim(txtbkname.Text) Is Nothing Then
                StartUpScript("txtbkname", "Enter Bank Name.")
                Return False

            ElseIf Trim(txtamt.Text) = "" Or Trim(txtamt.Text) Is Nothing Then
                StartUpScript("txtamt", "Enter Amount.")
                Return False

            ElseIf Not IsDate(Trim(txtfdrdate.Text)) Then
                StartUpScript(txtfdrdate.ID, "Enter Date in Correct Formate. Ex:DD/MM/YYYY")
                Return False

            ElseIf Not IsDate(Trim(txtfdrmdate.Text)) Then
                StartUpScript(txtfdrmdate.ID, "Enter Date in Correct Formate. Ex:DD/MM/YYYY")
                Return False

            ElseIf Not IsDate(Trim(txtreldate.Text)) Then
                StartUpScript(txtreldate.ID, "Enter Date in Correct Formate. Ex:DD/MM/YYYY")
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
                lblHeading.Text = "FDR Details&nbsp;"
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

    '        SqlStr = "SELECT FD.CCODE  FROM   M_FDR_DT FD,EXAM_BOARDCOLLEGE_MT CLG WHERE FD.CCODE=CLG.CODE ORDER BY FD.CCODE "
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
                'StrSql = "SELECT FD.FDRSLNO,FD.CCODE,CLG.COLLEGENAME  FROM   M_FDR_DT FD,EXAM_BOARDCOLLEGE_MT CLG WHERE FD.CCODE=CLG.CODE  and FD.CCODE IN (" & SqlStr1 & ") ORDER BY FD.CCODE, FDRSLNO "
                StrSql = "SELECT FD.FDRSLNO,FD.CCODE,CLG.COLLEGENAME  FROM   M_FDR_DT FD,EXAM_BOARDCOLLEGE_MT CLG WHERE FD.CCODE=CLG.CODE  and FD.CCODE= " & lstmCode.Text & " ORDER BY FD.CCODE, FDRSLNO "

            Else
                StrSql = "SELECT FD.FDRSLNO,FD.CCODE,CLG.COLLEGENAME  FROM   M_FDR_DT FD,EXAM_BOARDCOLLEGE_MT CLG WHERE FD.CCODE=CLG.CODE ORDER BY FD.CCODE, FDRSLNO "

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

#Region " Page Events"

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
                Table10.Visible = False
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

#End Region

#Region "Img Buttons"

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Try

            If Not FormValidations() Then Exit Sub
            objMaster = New ClsBoarddt

            If (Me.ViewState("MODE")) = "EDIT" Then
                RtnVal = objMaster.FDR_Update(SetEntries())
                If RtnVal = 1 Then
                    StartUpScript(iBtnSave.ID, "Record Updated Successfully.")
                    ClearControls()
                    FillGrid(PageIndex)
                    Table4.Visible = False
                    Table10.Visible = True


                Else
                    StartUpScript(iBtnSave.ID, "Record Not Updated.")
                End If
            ElseIf (Me.ViewState("MODE")) = "NEW" Then
                'ElseIf FLAG = Val(1) Then
                RtnVal = objMaster.FDR_Insert(SetEntries())
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

            SqlStr = "SELECT COLLEGENAME FROM EXAM_BOARDCOLLEGE_MT WHERE CODE='" & Txtccode.Text & "'"

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
            Table10.Visible = True
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
            RtnVal = objMaster.FDR_DELETE(dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text)

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

#Region "DROP DOWN"

    Private Sub Drprels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Drprels.SelectedIndexChanged
        Try
            If Drprels.SelectedValue = 1 Then
                Table10.Visible = True
            Else
                Table10.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

    

   
End Class
