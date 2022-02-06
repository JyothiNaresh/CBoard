'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Mapping  of Society wise College form
'   AUTHOR                            : KISHORE
'   INITIAL BASELINE DATE             : 22 Dec 2011
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Web.Services.Protocols
Imports CollegeBoardDLL
Imports System.Data.OracleClient
Imports CommonDLL
Imports System.Math
Public Class Society_Clg_Mapping
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtSetfocus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMessage As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtlblCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents iBtnDelete As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents drpSociety As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgGridCollege As System.Web.UI.WebControls.DataGrid
    Protected WithEvents imgBtnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtccname As System.Web.UI.WebControls.TextBox
    Protected WithEvents DrpDistrict As System.Web.UI.WebControls.DropDownList

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
    Private objError As clsError
    Dim DS As DataSet
    Dim DsStudents As New DataSet
    Dim Setslno As Integer
    Dim DExamSlno As Integer
    Dim ChkChecked As String
    Dim cELLNo As Integer
    Dim UserSLNo As Integer
    Private objMaster As ClsBoarddt
    Private objMas As Masters
    Private ObjResult As Utility
    Private DsSearchResult As DataSet
    Public From, FromWhere As String
    Public Str, StrSql As String
    Private DsSearch As DataSet
    Public PageIndex As Integer
    Public SLNO, MNO, RtnVal As Integer
    Private FormName As String = "Form1"
    Private MODE As String
    Private FLAG As Integer = 0
#End Region

#Region "Fill Methods"

    Private Sub FillSociety()
        Try
            StrSql = "SELECT  REGISTERED_NO,SOCT_NAME FROM M_SOCIETY_DT ORDER BY  REGISTERED_NO"

            ObjResult = New Utility
            DS = ObjResult.GetCommDataSet(StrSql)

            drpSociety.DataSource = DS.Tables(0)
            drpSociety.DataTextField = "SOCT_NAME"
            drpSociety.DataValueField = "REGISTERED_NO"
            drpSociety.DataBind()
            drpSociety.Items.Insert(0, New ListItem("All", 0))

        Catch ex As Exception
            StartUpScript("", ex.Message)
        End Try
    End Sub

    Private Sub FillDistrict()
        Try
            StrSql = "SELECT CODE,NAME FROM EXAM_BOARDDIST_MT ORDER BY BOARDDISTSLNO"

            ObjResult = New Utility
            DS = ObjResult.GetCommDataSet(StrSql)

            DrpDistrict.DataSource = DS.Tables(0)
            DrpDistrict.DataTextField = "NAME"
            DrpDistrict.DataValueField = "CODE"
            DrpDistrict.DataBind()
            DrpDistrict.Items.Insert(0, New ListItem("Select", 0))

        Catch ex As Exception
            StartUpScript("", ex.Message)
        End Try
    End Sub

    Private Sub FillGrid() 'ByVal PageIndex As Integer
        Dim i, j As Integer
        Dim gk As String

        Try
            gk = txtccname.Text
            gk = "%" + gk + "%"

            If Len(txtccname.Text) > 0 AndAlso DrpDistrict.SelectedValue > 0 Then
                StrSql = " SELECT EBM.CODE, EBM.NAME,SOC.SOCT_NAME,SOCIETY_REGISTER_NO  FROM EXAM_BOARDCOLLEGE_MT EBM, M_SOCIETY_DT SOC " & _
                         " WHERE EBM.SOCIETY_REGISTER_NO = SOC.REGISTERED_NO(+)  AND EBM.NAME LIKE   " & gk.ToString & "  AND EBM.BOARDDISTSLNO=" & DrpDistrict.SelectedValue.ToString & " ORDER BY CODE"

            ElseIf Len(txtccname.Text) = 0 AndAlso DrpDistrict.SelectedValue > 0 Then
                StrSql = " SELECT EBM.CODE, EBM.NAME,SOC.SOCT_NAME,SOCIETY_REGISTER_NO  FROM EXAM_BOARDCOLLEGE_MT EBM, M_SOCIETY_DT SOC " & _
                         " WHERE EBM.SOCIETY_REGISTER_NO = SOC.REGISTERED_NO(+) AND EBM.BOARDDISTSLNO=" & DrpDistrict.SelectedValue.ToString & " ORDER BY CODE"
            Else
                StrSql = "SELECT EBM.CODE, EBM.NAME, SOC.SOCT_NAME,SOCIETY_REGISTER_NO FROM EXAM_BOARDCOLLEGE_MT EBM, M_SOCIETY_DT SOC WHERE EBM.SOCIETY_REGISTER_NO = SOC.REGISTERED_NO(+) ORDER BY CODE"
            End If


            ObjResult = New Utility

            DsStudents = ObjResult.DataSet_OneFetch(StrSql)

            Me.ViewState("DsStudents") = DsStudents
            Me.Session("DsStudents") = DsStudents
            'DsSearchResult = ObjResult.DataSet_OneFetch(StrSql)

            'Me.ViewState("DsSearchResult") = DsSearchResult


            ''If Not DsSearchResult Is Nothing Then  DsStudents
            '    '' Setting Page Indexs
            '    If (DsSearchResult.Tables(0).Rows.Count - 1) / 10 < PageIndex Then

            '        If ((DsSearchResult.Tables(0).Rows.Count - 1) / 10) <= 1 Then
            '            PageIndex = 0
            '        Else
            '            PageIndex = PageIndex - 1
            '        End If
            '    End If

            dgGridCollege.CurrentPageIndex = PageIndex
            dgGridCollege.DataSource = DsStudents
            dgGridCollege.DataBind()

            'Me.ViewState("DsStudents") = DsStudents
            'Me.ViewState("DsSearchResult") = DsSearchResult

            'End If
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub COLLEGESOCIETYMAPK1() 'ByVal PageIndex As Integer
        Dim i, j As Integer
        Dim gk As String

        Try
            gk = txtccname.Text
            gk = "%" + gk + "%"

            If Len(txtccname.Text) > 0 AndAlso DrpDistrict.SelectedValue > 0 Then
                StrSql = " SELECT EBM.CODE, EBM.NAME,SOC.SOCT_NAME,SOCIETY_REGISTER_NO  FROM EXAM_BOARDCOLLEGE_MT EBM, M_SOCIETY_DT SOC " & _
                         " WHERE EBM.SOCIETY_REGISTER_NO = SOC.REGISTERED_NO(+)  AND EBM.NAME LIKE   " & gk.ToString & "  AND EBM.BOARDDISTSLNO=" & DrpDistrict.SelectedValue.ToString & " ORDER BY CODE"

            ElseIf Len(txtccname.Text) = 0 AndAlso DrpDistrict.SelectedValue > 0 Then
                StrSql = " SELECT EBM.CODE, EBM.NAME,SOC.SOCT_NAME,SOCIETY_REGISTER_NO  FROM EXAM_BOARDCOLLEGE_MT EBM, M_SOCIETY_DT SOC " & _
                         " WHERE EBM.SOCIETY_REGISTER_NO = SOC.REGISTERED_NO(+) AND EBM.BOARDDISTSLNO=" & DrpDistrict.SelectedValue.ToString & " ORDER BY CODE"
            Else
                StrSql = "SELECT EBM.CODE, EBM.NAME, SOC.SOCT_NAME,SOCIETY_REGISTER_NO FROM EXAM_BOARDCOLLEGE_MT EBM, M_SOCIETY_DT SOC WHERE EBM.SOCIETY_REGISTER_NO = SOC.REGISTERED_NO(+) ORDER BY CODE"
            End If


            ObjResult = New Utility

            DsStudents = ObjResult.DataSet_OneFetch(StrSql)

            Me.ViewState("DsStudents") = DsStudents
            Me.Session("DsStudents") = DsStudents

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub FillTitle()
        lblHeading.Text = "Society  Wise College Mapping "
    End Sub

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

#Region "Events"

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Session("USERID") Is Nothing OrElse Session("USERSLNO") Is Nothing Then
            Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
            Exit Sub
        Else
            UserSLNo = Session("USERSLNO")
        End If

        If Not IsPostBack Then
            FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
            From = Request.QueryString("From")

            FromWhere = Request.QueryString("FromWhere")
            Me.ViewState("FromWhere") = FromWhere

            If Not Request.QueryString("PageIndex") Is Nothing AndAlso Request.QueryString("PageIndex") <> "" Then
                PageIndex = CInt(Request.QueryString("PageIndex"))
            Else
                PageIndex = 0
            End If

            Me.ViewState("PageIndex") = PageIndex
            Me.ViewState("From") = From


            PapareTableForSociety()

            Me.Session("DsStudents") = DsStudents

            FillSociety()
            FillDistrict()

            Me.ViewState("strSQL") = strSQL

            If ValidateGo() Then
                'FLAG = 0
                GetSocietyCollegeMap()
            End If
            'FillGrid(PageIndex)
        Else
            'FLAG = 1
            'GetSocietyCollegeMap()
            PageIndex = Me.ViewState("PageIndex")
            From = Me.ViewState("From")
            DsStudents = Me.Session("DsStudents")
            FromWhere = Me.ViewState("FromWhere")
        End If

    End Sub

#End Region

#Region "Methods"

    Private Function FormValidations() As Boolean
        Try
            If drpSociety.SelectedValue = 0 Then
                StartUpScript(drpSociety.ID, "Select Society Name.")
                Return True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub PapareTableForSociety()
        Try
            Dim Dt As DataTable
            DsStudents.Tables.Add(New DataTable("SOCIETY"))
            Dt = DsStudents.Tables("SOCIETY")

            Dt.Columns.Add("CCODE")
            Dt.Columns.Add("NAME")
            Dt.Columns.Add("SOCIETY_REGISTER_NO")
            Dt.Columns.Add("CHECK")
        Catch ex As Exception

        End Try
    End Sub

    Private Function ValidateGo() As Boolean
        Try
            If drpSociety.SelectedValue Is Nothing OrElse drpSociety.SelectedValue = "" Then
                StartUpScript(drpSociety.ID, "Select Society Name")
                Return False

            End If
            Return True
        Catch ex As Exception

        End Try
    End Function

    Private Sub GetSocietyCollegeMap()
        Try

            Dim GK As String = ""
            GK &= "'%"
            GK &= UCase(Trim(txtccname.Text))
            GK &= "%'"

            'If Len(txtccname.Text) > 0 And DrpDistrict.SelectedValue > 0 Then
            '    StrSql = " SELECT EBM.CODE, EBM.NAME,SOC.SOCT_NAME,SOCIETY_REGISTER_NO  FROM EXAM_BOARDCOLLEGE_MT EBM, M_SOCIETY_DT SOC " & _
            '             " WHERE EBM.SOCIETY_REGISTER_NO = SOC.REGISTERED_NO(+)  AND EBM.NAME LIKE   " & GK.ToString & "  AND EBM.BOARDDISTSLNO=" & DrpDistrict.SelectedValue.ToString & " ORDER BY CODE"
            If Len(txtccname.Text) > 0 AndAlso DrpDistrict.SelectedValue > 0 Then
                StrSql = " SELECT EBM.CODE, EBM.NAME,SOC.SOCT_NAME,SOCIETY_REGISTER_NO  FROM EXAM_BOARDCOLLEGE_MT EBM, M_SOCIETY_DT SOC " & _
                         " WHERE EBM.SOCIETY_REGISTER_NO = SOC.REGISTERED_NO(+)  AND EBM.NAME LIKE   " & GK.ToString & "  AND EBM.BOARDDISTSLNO=" & DrpDistrict.SelectedValue.ToString & " ORDER BY CODE"

            ElseIf Len(txtccname.Text) = 0 AndAlso DrpDistrict.SelectedValue > 0 Then
                StrSql = " SELECT EBM.CODE, EBM.NAME,SOC.SOCT_NAME,SOCIETY_REGISTER_NO  FROM EXAM_BOARDCOLLEGE_MT EBM, M_SOCIETY_DT SOC " & _
                         " WHERE EBM.SOCIETY_REGISTER_NO = SOC.REGISTERED_NO(+) AND EBM.BOARDDISTSLNO=" & DrpDistrict.SelectedValue.ToString & " ORDER BY CODE"

            Else
                StrSql = "SELECT EBM.CODE, EBM.NAME, SOC.SOCT_NAME,SOCIETY_REGISTER_NO FROM EXAM_BOARDCOLLEGE_MT EBM, M_SOCIETY_DT SOC WHERE EBM.SOCIETY_REGISTER_NO = SOC.REGISTERED_NO(+) ORDER BY CODE"
            End If


            objMaster = New ClsBoarddt
            DsStudents = Me.Session("DsStudents")
            If DsStudents.Tables("SOCIETY").Rows.Count > 0 Then DsStudents.Tables("SOCIETY").Rows.Clear()
            DsStudents = objMaster.COLLEGESOCIETYMAP("COLLEGESOCIETYMAPK", DsStudents, "SOCIETY", StrSql)

            dgGridCollege.DataSource = DsStudents.Tables("SOCIETY")
            dgGridCollege.DataBind()


        Catch ex As Exception

        End Try
    End Sub

    Private Function SetEntires() As Boolean
        Try

            Dim i As Integer

            DsStudents = Me.Session("DsStudents")

            For i = 0 To DsStudents.Tables("SOCIETY").Rows.Count - 1 'dgGridCollege.Items.Count - 1       '                '
                Dim gtxtP1 As CheckBox
                gtxtP1 = dgGridCollege.Items(i).Cells(4).Controls(1)

                If gtxtP1.Checked Then
                    DsStudents.Tables("SOCIETY").Rows(i)("SOCIETY_REGISTER_NO") = drpSociety.SelectedValue.ToString
                    'Else
                    '    DsStudents.Tables("SOCIETY").Rows(i)("SOCIETY_REGISTER_NO") = DBNull.Value
                End If
            Next
            Me.Session("DsStudents") = DsStudents

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function SetEntries1() As ArrayList
        Try
            Dim Arr As New ArrayList

            'If Me.ViewState("MODE") = "NEW" Then
            '    'Arr.Add(Val(txtregno.Text))
            '    'Arr.Add(Trim(Txtregdate.Text))
            '    'Arr.Add(Trim(txtname.Text))
            '    'Arr.Add(Trim(txtaddr1.Text))
            '    'Arr.Add(Trim(txtaddr2.Text))
            '    'Arr.Add(Trim(txtcorpname.Text))
            '    'Arr.Add(Val(txtmobile.Text))
            '    'Arr.Add(Trim(txtyos.Text))
            '    'Arr.Add(Trim(txtaffextupto.Text))
            '    Arr.Add(Val(MNO))
            'End If
            If FLAG = 1 Then
                Arr.Add(Val(1))
                Arr.Add(Val(drpSociety.SelectedValue.ToString))
                Arr.Add(Val(DrpDistrict.SelectedValue.ToString))
            End If
            FLAG = 0
            Arr.Add(Val(0))
            Return Arr

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function DelSetEntires() As Boolean
        Try

            Dim i As Integer

            DsStudents = Me.Session("DsStudents")

            For i = 0 To DsStudents.Tables("SOCIETY").Rows.Count - 1
                Dim gtxtP1 As CheckBox
                gtxtP1 = dgGridCollege.Items(i).Cells(4).Controls(1)

                If gtxtP1.Checked Then
                    DsStudents.Tables("SOCIETY").Rows(i)("SOCIETY_REGISTER_NO") = DBNull.Value
                End If
            Next
            Me.Session("DsStudents") = DsStudents

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "ImgBtnEvents"

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Try
            Dim Result As String
            If FormValidations() Then Exit Sub
            If Not SetEntires() Then Exit Sub

            DsStudents = Me.Session("DsStudents")
            If DsStudents.Tables("SOCIETY").Rows.Count > 0 Then
                objMaster = New ClsBoarddt
                Result = objMaster.SocTaget_Save(DsStudents)
                If Result = "Saved" Then
                    StartUpScript(iBtnSave.ID, "Data Saved Successfully")
                    DsStudents.Tables("SOCIETY").Rows.Clear()
                    GetSocietyCollegeMap()
                    'FillGrid()

                End If
            Else
                StartUpScript(iBtnSave.ID, "Record Not Saved.")
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

    Private Sub iBtnDelete_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnDelete.Click
        Dim Result As String
        Try
            If Not DelSetEntires() Then Exit Sub

            DsStudents = Me.Session("DsStudents")
            If DsStudents.Tables("SOCIETY").Rows.Count > 0 Then
                objMaster = New ClsBoarddt
                Result = objMaster.SocTaget_Save(DsStudents)
                If Result = "Saved" Then
                    StartUpScript(iBtnDelete.ID, "Data Saved Successfully")
                    DsStudents.Tables("SOCIETY").Rows.Clear()
                    GetSocietyCollegeMap()
                End If
            Else
                StartUpScript(iBtnSave.ID, "No Record For Save.")
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

    Private Sub imgBtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnGo.Click
        'FillGrid()
        GetSocietyCollegeMap()
    End Sub

#End Region

#Region "Grid Events"

    Private Sub dgGridCollege_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgGridCollege.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim Chk As CheckBox = CType(e.Item.Cells(4).Controls(1).FindControl("ChkTarget"), CheckBox)
                If Val(e.Item.Cells(4).Text) = 1 Then
                    Chk.Checked = True
                Else
                    Chk.Checked = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
