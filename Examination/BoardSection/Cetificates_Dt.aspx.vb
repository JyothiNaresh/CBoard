'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Master of Certificates form
'   AUTHOR                            : KISHORE
'   INITIAL BASELINE DATE             : 22 Dec 2011
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Web.Services.Protocols
Imports CollegeBoardDLL
Imports System.Data.OracleClient
Imports CommonDLL
Imports System.Math
Public Class Cetificates_Dt
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents iBtnAdd As System.Web.UI.WebControls.ImageButton
    Protected WithEvents txtlblCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgGridSection As System.Web.UI.WebControls.DataGrid
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents LBLCLGNAME As System.Web.UI.WebControls.Label
    Protected WithEvents imgBtnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Txtccode As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Table4 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Drpfire1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Drpfire2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpsant1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpstruc1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpnoc1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpsant2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpstruc2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpnoc2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents imgBtnGoo1 As System.Web.UI.WebControls.ImageButton
    'Protected WithEvents lstmCode As System.Web.UI.HtmlControls.HtmlSelect
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
                Arr.Add(Val(Drpfire1.SelectedValue))
                Arr.Add(Val(drpsant1.SelectedValue))
                Arr.Add(Val(drpstruc1.SelectedValue))
                Arr.Add(Val(drpnoc1.SelectedValue))
                Arr.Add(Val(Drpfire2.SelectedValue))
                Arr.Add(Val(drpsant2.SelectedValue))
                Arr.Add(Val(drpstruc2.SelectedValue))
                Arr.Add(Val(drpnoc2.SelectedValue))
                Arr.Add(Val(MNO))
            ElseIf Me.ViewState("MODE") = "EDIT" Then
                Arr.Add(Val(Trim(Me.ViewState("SLNO"))))
                Arr.Add(Val(Txtccode.Text))
                Arr.Add(Val(Drpfire1.SelectedValue))
                Arr.Add(Val(drpsant1.SelectedValue))
                Arr.Add(Val(drpstruc1.SelectedValue))
                Arr.Add(Val(drpnoc1.SelectedValue))
                Arr.Add(Val(Drpfire2.SelectedValue))
                Arr.Add(Val(drpsant2.SelectedValue))
                Arr.Add(Val(drpstruc2.SelectedValue))
                Arr.Add(Val(drpnoc2.SelectedValue))
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
            DsGA = objMaster.CERTIFICT_Select(SLNO)
            FillFire()
            If DsGA.Tables(0).Rows.Count > 0 Then
                Txtccode.Text = Val(DsGA.Tables(0).Rows(0)("CCODE").ToString)
                LBLCLGNAME.Text = DsGA.Tables(0).Rows(0)("COLLEGENAME").ToString
                Drpfire1.SelectedValue = Val(DsGA.Tables(0).Rows(0)("FIRESLNO1").ToString)
                drpsant1.SelectedValue = Val(DsGA.Tables(0).Rows(0)("SANITORYSLNO1").ToString)
                drpstruc1.SelectedValue = Val(DsGA.Tables(0).Rows(0)("STRUCTURALSLNO1").ToString)
                drpnoc1.SelectedValue = Val(DsGA.Tables(0).Rows(0)("NOCSLNO1").ToString)


                If drpsant1.SelectedValue = 1 Then
                    drpsant2.Visible = True
                Else
                    drpsant2.Visible = False
                End If

                If Drpfire1.SelectedValue = 1 Then
                    Drpfire2.Visible = True
                Else
                    Drpfire2.Visible = False
                End If
                If drpstruc1.SelectedValue = 1 Then
                    drpstruc2.Visible = True
                Else
                    drpstruc2.Visible = False
                End If
                If drpnoc1.SelectedValue = 1 Then
                    drpnoc2.Visible = True
                Else
                    drpnoc2.Visible = False
                End If

                Drpfire2.SelectedValue = Val(DsGA.Tables(0).Rows(0)("FIRESLNO2").ToString)
                drpsant2.SelectedValue = Val(DsGA.Tables(0).Rows(0)("SANITORYSLNO2").ToString)
                drpstruc2.SelectedValue = Val(DsGA.Tables(0).Rows(0)("STRUCTURALSLNO2").ToString)
                drpnoc2.SelectedValue = Val(DsGA.Tables(0).Rows(0)("NOCSLNO2").ToString)


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
            Drpfire1.SelectedItem.Text = "Select"
            drpsant1.SelectedItem.Text = "Select"
            drpstruc1.SelectedItem.Text = "Select"
            drpnoc1.SelectedItem.Text = "Select"

            drpsant2.SelectedItem.Text = "Select"
            drpstruc2.SelectedItem.Text = "Select"
            drpnoc2.SelectedItem.Text = "Select"

        Catch ex As Exception

        End Try

    End Sub

    Private Function FormValidations() As Boolean
        Try
            If Trim(Txtccode.Text) = "" Or Trim(Txtccode.Text) Is Nothing Then
                StartUpScript("Txtccode", "Enter College Code.")
                Return False
                'ElseIf drpfire.SelectedItem.Text = "Select" Then
                '    StartUpScript(drpfire.ID, "Select Fire Safety Certificate.")
                '    Return False
            ElseIf drpstruc1.SelectedItem.Text = "Select" Then
                StartUpScript(drpstruc1.ID, "Select Fire Certificate.")
                Return False

            ElseIf drpsant1.SelectedItem.Text = "Select" Then
                StartUpScript(drpsant1.ID, "Select Sanitory Certificate.")
                Return False
            ElseIf drpnoc1.SelectedItem.Text = "Select" Then
                StartUpScript(drpnoc1.ID, "Select NOC Certificate.")
                Return False

                'ElseIf drpstruc2.SelectedItem.Text = "Select" Then
                '    StartUpScript(drpstruc2.ID, "Select Fire Certificate Sub/Not Sub.")
                '    Return False

                'ElseIf drpsant2.SelectedItem.Text = "Select" Then
                '    StartUpScript(drpsant2.ID, "Select Sanitory Certificate Sub/Not Sub. ")
                '    Return False
                'ElseIf drpnoc2.SelectedItem.Text = "Select" Then
                '    StartUpScript(drpnoc2.ID, "Select NOC Certificate Sub/Not Sub.")
                '    Return False
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

    '        SqlStr = "SELECT CER.CCODE FROM M_CERTIFICATES_DT CER,EXAM_BOARDCOLLEGE_MT CLG WHERE  CER.CCODE=CLG.CODE ORDER BY CER.CCODE"
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
                'StrSql = "SELECT CER.CERTFSLNO, CER.CCODE,CLG.COLLEGENAME  FROM M_CERTIFICATES_DT CER,EXAM_BOARDCOLLEGE_MT CLG WHERE  CER.CCODE=CLG.CODE AND CER.CCODE IN (" & SqlStr1 & ") ORDER BY CER.CCODE"
                StrSql = "SELECT CER.CERTFSLNO, CER.CCODE,CLG.COLLEGENAME  FROM M_CERTIFICATES_DT CER,EXAM_BOARDCOLLEGE_MT CLG WHERE  CER.CCODE=CLG.CODE AND CER.CCODE=" & lstmCode.Text & " ORDER BY CER.CCODE"
            Else
                StrSql = "SELECT CER.CERTFSLNO, CER.CCODE,CLG.COLLEGENAME  FROM M_CERTIFICATES_DT CER,EXAM_BOARDCOLLEGE_MT CLG WHERE  CER.CCODE=CLG.CODE ORDER BY CER.CCODE"
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
                FillFire()
            Else
                PageIndex = dgGridSection.CurrentPageIndex
                GetViewStateVariables()
                'FillFire()
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
                RtnVal = objMaster.CERTIFICT_Update(SetEntries())
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
                RtnVal = objMaster.CERTIFICT_Insert(SetEntries())
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
            FillFire()
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
            Me.ViewState("MODE") = "EDIT"
            SLNO = Val(dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text)
            Me.ViewState("SLNO") = SLNO
            Table4.Visible = True

            'drpsant2.Visible = True
            'Drpfire2.Visible = True
            'drpstruc2.Visible = True
            'drpnoc2.Visible = True
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
            RtnVal = objMaster.CERTIFICT_DELETE(dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text)

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
            'drpfire.Items.Clear()
            'drpfire.Items.Insert(0, New ListItem("--Select--", 0))
            'drpfire.Items.Insert(1, New ListItem("Challan Paid", 1))
            'drpfire.Items.Insert(2, New ListItem("Challan Not Paid", 2))
            'drpfire.Items.Insert(3, New ListItem("NOC-Submitted", 1))
            'drpfire.Items.Insert(4, New ListItem("NOC-Not Submitted", 2))

            Drpfire1.Items.Clear()
            Drpfire1.Items.Insert(0, New ListItem("--Select--", 0))
            Drpfire1.Items.Insert(1, New ListItem("Yes", 1))
            Drpfire1.Items.Insert(2, New ListItem("No", 2))

            drpsant1.Items.Clear()
            drpsant1.Items.Insert(0, New ListItem("--Select--", 0))
            drpsant1.Items.Insert(1, New ListItem("Yes", 1))
            drpsant1.Items.Insert(2, New ListItem("No", 2))

            drpstruc1.Items.Clear()
            drpstruc1.Items.Insert(0, New ListItem("--Select--", 0))
            drpstruc1.Items.Insert(1, New ListItem("Yes", 1))
            drpstruc1.Items.Insert(2, New ListItem("No", 2))

            drpnoc1.Items.Clear()
            drpnoc1.Items.Insert(0, New ListItem("--Select--", 0))
            drpnoc1.Items.Insert(1, New ListItem("Yes", 1))
            drpnoc1.Items.Insert(2, New ListItem("No", 2))

            Drpfire2.Items.Clear()
            Drpfire2.Items.Insert(0, New ListItem("--Select--", 0))
            Drpfire2.Items.Insert(1, New ListItem("Submitted", 1))
            Drpfire2.Items.Insert(2, New ListItem("Not Submitted", 2))


            drpsant2.Items.Clear()
            drpsant2.Items.Insert(0, New ListItem("--Select--", 0))
            drpsant2.Items.Insert(1, New ListItem("Submitted", 1))
            drpsant2.Items.Insert(2, New ListItem("Not Submitted", 2))

            drpstruc2.Items.Clear()
            drpstruc2.Items.Insert(0, New ListItem("--Select--", 0))
            drpstruc2.Items.Insert(1, New ListItem("Submitted", 1))
            drpstruc2.Items.Insert(2, New ListItem("Not Submitted", 2))

            drpnoc2.Items.Clear()
            drpnoc2.Items.Insert(0, New ListItem("--Select--", 0))
            drpnoc2.Items.Insert(1, New ListItem("Submitted", 1))
            drpnoc2.Items.Insert(2, New ListItem("Not Submitted", 2))
        Catch ex As Exception
            StartUpScript("", ex.Message)
        End Try
    End Sub

    Private Sub drpsant1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpsant1.SelectedIndexChanged
        If drpsant1.SelectedValue = 1 Then
            drpsant2.Visible = True
        Else
            drpsant2.Visible = False
        End If

    End Sub

    Private Sub Drpfire1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Drpfire1.SelectedIndexChanged
        Try

            If Drpfire1.SelectedValue = 1 Then
                Drpfire2.Visible = True

            Else
                Drpfire2.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub drpstruc1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpstruc1.SelectedIndexChanged
        If drpstruc1.SelectedValue = 1 Then
            drpstruc2.Visible = True

        Else
            drpstruc2.Visible = False
        End If
    End Sub

    Private Sub drpnoc1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpnoc1.SelectedIndexChanged
        If drpnoc1.SelectedValue = 1 Then
            drpnoc2.Visible = True

        Else
            drpnoc2.Visible = False
        End If
    End Sub
#End Region



End Class
