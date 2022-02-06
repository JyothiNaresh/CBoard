'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is Presentation Layer For Key Objections for Combinations Mapping
'   ACTIVITY                          : Many To Many Users Wise Key Objections for Combinations Mapping
'   AUTHOR                            : G.KISHORE
'   INITIAL BASELINE DATE             : 29-AUG-2012
'   FINAL BASELINE DATE               : 29-AUG-2012
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Imports PasswordEncrypt
Imports CollegeBoardDLL.WebTree
Imports System.Data.OracleClient
Public Class KeyObj_Combinations
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnCancel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpUserTypes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpAcaSlno As System.Web.UI.WebControls.DropDownList
    Protected WithEvents iBtnSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents chkUser As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chklStuType As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents chklAreaType As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents ibtGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents chkAreaTypes As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkBranchs As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chklBranch As System.Web.UI.WebControls.CheckBoxList

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

    Private ds As New DataSet
    Private webcls As New WebTree
    Private Formname As String = "Form1"
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Private Mode As String
    Private userslno As Integer
    Private objUscls As UserClass
    Private RtnStr As String
    Private ClsUty As New Utility
    Private UserTypeslno As Integer = 0

#End Region

#Region "General Methods"

    Private Sub ClearControls()
        Try

            chkBranchs.Checked = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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

#End Region

#Region "Methods"

    Private Function SetEntriesBranch() As DataSet
        Dim dsBranch As New DataSet

        Dim dt As New DataTable
        Dim dtU As New DataTable
        Dim dRow As DataRow
        Dim drowu As DataRow
        Try

            dt.Columns.Add("USERSLNO", GetType(System.Int16))
            dt.Columns.Add("COMBINATIONKEY", GetType(System.Int16))
            dt.Columns.Add("COMACADEMICSLNO", GetType(System.Int16))
            dsBranch.Tables.Add(dt)

            dtU.Columns.Add("USERSLNO", GetType(System.Int16))
            dtU.Columns.Add("COMACADEMICSLNO", GetType(System.Int16))
            dsBranch.Tables.Add(dtU)

            If chklStuType.Items.Count - 1 Then

                For u As Integer = 0 To chklStuType.Items.Count - 1 ''This  Loop For Users

                    If chklStuType.Items(u).Selected = True Then
                        drowu = dsBranch.Tables(1).NewRow
                        drowu("USERSLNO") = chklStuType.Items(u).Value
                        drowu("COMACADEMICSLNO") = drpAcaSlno.SelectedValue
                        dsBranch.Tables(1).Rows.Add(drowu)

                        If chklBranch.Items.Count > 0 Then
                            For i As Integer = 0 To chklBranch.Items.Count - 1 'THis Loop For Exam Branchs
                                If chklBranch.Items(i).Selected = True Then
                                    dRow = dsBranch.Tables(0).NewRow
                                    dRow("USERSLNO") = chklStuType.Items(u).Value
                                    dRow("COMBINATIONKEY") = chklBranch.Items(i).Value
                                    dRow("COMACADEMICSLNO") = drpAcaSlno.SelectedValue
                                    dsBranch.Tables(0).Rows.Add(dRow)
                                End If
                            Next
                        End If

                    End If



                Next

            End If

            Return dsBranch

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function PageValidations() As Boolean
        Try
            Dim i, j As Integer
            If drpAcaSlno.SelectedIndex = -1 Then
                StartUpScript(drpAcaSlno.ID, "Select Academic Year.")
                Return False
            End If
            If chklBranch.Items.Count > 0 Then
                For i = 0 To chklBranch.Items.Count - 1
                    If chklBranch.Items(i).Selected Then
                        j = 1
                        Exit For
                    End If
                Next
                If j = 0 Then
                    StartUpScript(chklBranch.ID, "Please check atleast one Branch.")
                    Return False
                End If
            Else
                StartUpScript(chklBranch.ID, "Please check Branches.")
                Return False
            End If

            If chklStuType.Items.Count > 0 Then
                For i = 0 To chklStuType.Items.Count - 1
                    If chklStuType.Items(i).Selected Then
                        j = 1
                        Exit For
                    End If
                Next
                If j = 0 Then
                    StartUpScript(chklStuType.ID, "Please check atleast one User Type.")
                    Return False
                End If
            Else
                StartUpScript(chklStuType.ID, "Please check User Types.")
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function



#End Region

#Region "Load Event"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim str As String = ""
        ds = New DataSet
        Dim dsBranch As New DataSet
        Dim dsAcaYr As New DataSet
        Try
            If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
            Mode = Request.QueryString("Mode")
            userslno = CInt(Request.QueryString("userslno"))
            UserTypeslno = CInt(Request.QueryString("USERTYPESLNO"))
            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                FillAcademiyears()
                FillCombinationKeys()
                FillUsersType()
                FillUsers()
                FillAreaType()
                StartUpScript("txtUid", "")
                Dim iCOMACASLNO As Integer = drpAcaSlno.SelectedValue

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

    Private Sub FillCombinationKeys()
        Try
            Dim dsBranch As DataSet
            If drpAcaSlno.SelectedIndex <> -1 Then
                dsBranch = ClsUty.DataSet_Fetch(" SELECT A.SLNO,A.EXAMNAME FROM EXAM_EXAMNAME A, " & _
                      " EXAM_ACCCOMBKEY_DT B WHERE A.SLNO=B.COMBINATIONKEY AND B.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & " ORDER BY A.EXAMNAME ")
                chklBranch.DataSource = dsBranch
                chklBranch.DataTextField = "EXAMNAME"
                chklBranch.DataValueField = "SLNO"
                chklBranch.DataBind()
            End If
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillUsersType()
        Try
            Dim dsStuType As DataSet
            dsStuType = ClsUty.DataSet_Fetch("SELECT USERTYPESLNO,NAME FROM E_USERTYPE_MT WHERE USERTYPESLNO<>1 ORDER BY NAME")
            DrpUserTypes.DataSource = dsStuType
            DrpUserTypes.DataTextField = "NAME"
            DrpUserTypes.DataValueField = "USERTYPESLNO"
            DrpUserTypes.DataBind()
            If UserTypeslno > 0 Then
                DrpUserTypes.SelectedValue = UserTypeslno
            Else
                DrpUserTypes.SelectedValue = 3
            End If

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillUsers()
        Dim DsUsers As DataSet
        ClsUty = New Utility
        DsUsers = ClsUty.DataSet_OneFetch("SELECT UM.USERSLNO,UM.USERID  FROM EXAM_USER_MT UM,E_USER_USERTYPE_MT UUM   " & _
                                         " WHERE UM.USERSLNO = UUM.USERSLNO AND UUM.USERTYPESLNO=" & DrpUserTypes.SelectedValue.ToString & " AND UUM.COMACADEMICSLNO =" & drpAcaSlno.SelectedValue.ToString & "  ORDER BY UM.USERID")
        chklStuType.DataSource = DsUsers
        chklStuType.DataTextField = "USERID"
        chklStuType.DataValueField = "USERSLNO"
        chklStuType.DataBind()

    End Sub

    Private Sub FillAreaType()
        Try
            Dim dsAreaType As DataSet
            ClsUty = New Utility

            dsAreaType = ClsUty.DataSet_Fetch("SELECT SLNO,NAME FROM EXAM_AREA_COMB_MT WHERE STATUS='A' ORDER BY NAME")

            chklAreaType.DataSource = dsAreaType
            chklAreaType.DataTextField = "NAME"
            chklAreaType.DataValueField = "SLNO"
            chklAreaType.DataBind()
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Button Events"

    Private Sub iBtnSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSearch.Click
        Try
            FillUsers()
            FillCombinationKeys()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Try
            If PageValidations() Then
                objUscls = New UserClass
                RtnStr = objUscls.CombinationKeyObjections_Save(SetEntriesBranch())
                If RtnStr = "SUCCESS" Then
                    ClearControls()
                    StartUpScript("txtUid", "Record Saved Successfully.")
                Else
                    StartUpScript("", RtnStr)
                End If
            End If
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub ibtnCancel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnCancel.Click
        Try
            Response.Redirect("KeyObj_Comb_View.aspx?USERTYPESLNO=" & DrpUserTypes.SelectedValue.ToString) '../Security/
            'Response.Redirect("KeyObjCombSingle.aspx?UserSlno=" & DrpUsers.SelectedValue.ToString)
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub ibtGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtGo.Click
        Try
            Dim dsSelBranch As DataSet
            Dim k As Integer
            Dim areaslno As String
            ClsUty = New Utility

            For k = 0 To chklAreaType.Items.Count - 1
                If chklAreaType.Items(k).Selected Then
                    areaslno &= chklAreaType.Items(k).Value & ","
                End If

            Next

            chklBranch.Items.Clear()
            If Len(areaslno) > 0 Then
                areaslno = areaslno.TrimEnd(",")
                dsSelBranch = ClsUty.DataSet_Fetch("SELECT A.SLNO,A.EXAMNAME FROM EXAM_EXAMNAME A,EXAM_ACCCOMBKEY_DT B , EXAM_AREA_COMB_MAP CMAP WHERE A.SLNO=B.COMBINATIONKEY" & _
                                                   " AND A.SLNO=CMAP.COMBINATIONKEY AND B.COMBINATIONKEY =CMAP.COMBINATIONKEY AND B.COMACADEMICSLNO=CMAP.COMACADEMICSLNO" & _
                                                   " AND B.COMACADEMICSLNO=" & drpAcaSlno.SelectedValue.ToString & "  AND CMAP.COMBAREASLNO IN (" & areaslno.ToString & ") ORDER BY A.EXAMNAME ")
            Else
                FillCombinationKeys()
            End If


            If Not dsSelBranch Is Nothing AndAlso dsSelBranch.Tables(0).Rows.Count > 0 Then
                chklBranch.Items.Clear()
                chklBranch.DataSource = dsSelBranch
                chklBranch.DataTextField = "EXAMNAME"
                chklBranch.DataValueField = "SLNO"
                chklBranch.DataBind()
            End If

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Check Box Events"

    Private Sub chkUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUser.CheckedChanged
        Try
            Dim i As Integer
            If chkUser.Checked Then
                For i = 0 To chklStuType.Items.Count - 1
                    chklStuType.Items(i).Selected = True
                Next
            Else
                For i = 0 To chklStuType.Items.Count - 1
                    chklStuType.Items(i).Selected = False
                Next
            End If
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub chkBranchs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBranchs.CheckedChanged
        Try
            Dim i As Integer
            If chkBranchs.Checked Then
                For i = 0 To chklBranch.Items.Count - 1
                    chklBranch.Items(i).Selected = True
                Next
            Else
                For i = 0 To chklBranch.Items.Count - 1
                    chklBranch.Items(i).Selected = False
                Next
            End If
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub chkAreaTypes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAreaTypes.CheckedChanged
        Try
            Dim i As Integer
            If chkAreaTypes.Checked Then
                For i = 0 To chklAreaType.Items.Count - 1
                    chklAreaType.Items(i).Selected = True
                Next
            Else
                For i = 0 To chklAreaType.Items.Count - 1
                    chklAreaType.Items(i).Selected = False
                Next
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


End Class
