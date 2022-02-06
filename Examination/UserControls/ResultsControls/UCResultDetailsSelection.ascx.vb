'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : User Control For Result Details Selection
'   ACTIVITY                          : New/Edit
'   AUTHOR                            : Hemanth
'   INITIAL BASELINE DATE             : 21-JUN-2010
'   FINAL BASELINE DATE               : 21-JUN-2010
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------

Imports System.Data
Imports System.String
Imports System.Data.OracleClient
Imports CollegeBoardDLL
Public Class UCResultDetailsSelection
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents PnlIIT As System.Web.UI.WebControls.Panel
    Protected WithEvents PnlAIEEE As System.Web.UI.WebControls.Panel
    Protected WithEvents PnlEAMCET As System.Web.UI.WebControls.Panel
    Protected WithEvents PnlIPE As System.Web.UI.WebControls.Panel
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Checkbox29 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Checkbox30 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Checkbox32 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpResultExam As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpResultExamType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Checkbox34 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents PnlOTH As System.Web.UI.WebControls.Panel
    Protected WithEvents IIT_TOTALRANK As System.Web.UI.WebControls.CheckBox
    Protected WithEvents IIT_CATRANK As System.Web.UI.WebControls.CheckBox
    Protected WithEvents IIT_CATSUBPCRANK As System.Web.UI.WebControls.CheckBox
    Protected WithEvents IIT_CATSUBPTRANK As System.Web.UI.WebControls.CheckBox
    Protected WithEvents IIT_PREPARATORYRANK As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ISPREPARATORYRANK As System.Web.UI.WebControls.CheckBox
    Protected WithEvents IIT_PAPERWISE As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIEEE_BTECHTOTAL As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIEEE_BTECHAIR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIEEE_BTECHCATRANKAIR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIEEE_BTECHCATRANKSR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIEEE_BRACHTOTAL As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIEEE_BRACHAIR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIEEE_BRACHSR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIEEE_BARCHCATRANKAIR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIEEE_BARCHCATRANKSR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIEEE_BPHARTOTAL As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIEEE_BPHARAIR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIEEE_BPHARSR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIEEE_BPHARCATRANKAIR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents EAM_EAM_WT As System.Web.UI.WebControls.CheckBox
    Protected WithEvents EAM_IPE_GT As System.Web.UI.WebControls.CheckBox
    Protected WithEvents EAM_TOT_WT As System.Web.UI.WebControls.CheckBox
    Protected WithEvents EAM_TOTALRANK As System.Web.UI.WebControls.CheckBox
    Protected WithEvents BtnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents EAM_TOTALMARKS As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIEEE_BTECHSR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents IPE_IPE_GT As System.Web.UI.WebControls.CheckBox
    Protected WithEvents OTH_TOTALMARKS As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIEEE_BPHARMCATraSR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents IIT_ISPREPARATORYRANK As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIE_BTECHTOTAL As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIE_BTECHAIR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIE_BTECHSR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIE_BTECHCATRANKAIR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIE_BTECHCATRANKSR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIE_BRACHTOTAL As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIE_BRACHAIR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIE_BRACHSR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIE_BARCHCATRANKAIR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIE_BARCHCATRANKSR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIE_BPHARTOTAL As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIE_BPHARAIR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIE_BPHARSR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIE_BPHARCATRANKAIR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents AIE_BPHARMCATRANKSR As System.Web.UI.WebControls.CheckBox
    Protected WithEvents IPE_TOTALMARKS As System.Web.UI.WebControls.CheckBox
    Protected WithEvents IPE_GRADE As System.Web.UI.WebControls.CheckBox
    Protected WithEvents OTH_TOTALRANK As System.Web.UI.WebControls.CheckBox
    Protected WithEvents IIT_EML As System.Web.UI.WebControls.DropDownList
    Protected WithEvents LblSelExm As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents IPE_GROUP As System.Web.UI.WebControls.DropDownList
    Protected WithEvents EAM_INT_WT As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpOrder As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " Code"

#Region "Class Variables"

    Private ObjResult As Utility
    Dim sqlstr, SBjqry As String
    Dim DSet, Sset As DataSet
    Public DsSel As DataSet
    Dim Cnt As Integer = 0
    Public GrpSelStr, ResSelStr As String
    Public SelExams, SelExamslno, OrdText, OrdVal As String
    Dim SelExamcnt As Integer
    Public Sbjset As DataSet
    Public LblHead As String
    Public GRPNO As Integer
#End Region

#Region "Page Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IsPostBack Then
                SbjPrepTable()
                FillResultExamsType()
                FillResultExams()
                PrepareTable()
                FillGroups()
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Fill Methods"

    Private Sub PrepareTable()
        DsSel = New DataSet
        DsSel.Tables.Add(New DataTable("DtResSel"))
        Dim dt As New DataTable
        dt = DsSel.Tables(0)

        dt.Columns.Add("TBLSLNO", Type.GetType("System.Int64"))
        dt.Columns.Add("EXAMTYPESLNO", Type.GetType("System.Int64"))
        dt.Columns.Add("EXAMTYPE", Type.GetType("System.String"))
        dt.Columns.Add("RESLNO", Type.GetType("System.Int64"))
        dt.Columns.Add("RESEXAMNAME", Type.GetType("System.String"))
        dt.Columns.Add("COLNAME", Type.GetType("System.String"))
        dt.Columns.Add("COLTEXT", Type.GetType("System.String"))
        dt.Columns.Add("GROUPSLNO", Type.GetType("System.Int64"))
        dt.Columns.Add("SELCOLN", Type.GetType("System.String"))
        dt.Columns.Add("TBLASNAME", Type.GetType("System.String"))
        dt.Columns.Add("VENCOL", Type.GetType("System.String"))
        dt.Columns.Add("COLFRM", Type.GetType("System.Int64"))
        Session("DsSel") = DsSel
    End Sub

    Private Sub FillResultExamsType()
        Try
            sqlstr = " SELECT EXAMTYPESLNO, NAME FROM RESULT_EXAMTYPE_MT WHERE STATUS = 0 "

            ObjResult = New Utility
            DSet = ObjResult.DataSet_OneFetch(sqlstr)
            DrpResultExamType.DataSource = DSet.Tables(0)
            DrpResultExamType.DataTextField = "NAME"
            DrpResultExamType.DataValueField = "EXAMTYPESLNO"
            DrpResultExamType.DataBind()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillResultExams()
        Try
            sqlstr = " SELECT DISTINCT A.RESLNO,A.RE_NAME REXNAME FROM RESULT_RESULTEXAMS_MT A,RESULT_ERGS_MT B WHERE A.RESLNO=B.RESLNO AND A.ACADEMICSLNO= B.ACADEMICSLNO AND EXAMTYPESLNO=" & DrpResultExamType.SelectedValue & _
                     " AND A.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " ORDER BY A.RE_NAME"

            ObjResult = New Utility
            DSet = ObjResult.DataSet_OneFetch(sqlstr)
            PnlIIT.Visible = False
            PnlAIEEE.Visible = False
            PnlEAMCET.Visible = False
            PnlIPE.Visible = False
            PnlOTH.Visible = False
            If DSet.Tables(0).Rows.Count() <> 0 Then
                DrpResultExam.DataSource = DSet.Tables(0)
                DrpResultExam.DataTextField = "REXNAME"
                DrpResultExam.DataValueField = "RESLNO"
                DrpResultExam.DataBind()
                Select Case DrpResultExamType.SelectedValue
                    Case 1
                        PnlIIT.Visible = True
                    Case 2
                        PnlAIEEE.Visible = True
                    Case 3
                        PnlEAMCET.Visible = True
                    Case 4
                        PnlIPE.Visible = True
                    Case 5
                        PnlOTH.Visible = True
                End Select
            Else
                DrpResultExam.Items.Clear()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillGroups()
        Try
            sqlstr = " SELECT GROUPSLNO, NAME FROM T_GROUP_MT ORDER BY GROUPSLNO "

            ObjResult = New Utility
            DSet = ObjResult.DataSet_OneFetch(sqlstr)

            IPE_GROUP.DataSource = DSet.Tables(0)
            IPE_GROUP.DataTextField = "NAME"
            IPE_GROUP.DataValueField = "GROUPSLNO"
            IPE_GROUP.DataBind()

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Button Click"

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        PnlIIT.Visible = False
        PnlAIEEE.Visible = False
        PnlEAMCET.Visible = False
        PnlIPE.Visible = False
        PnlOTH.Visible = False
        Dim Dr As DataRow
        Dim ExmSelstr As String
        OrdVal = Session("OrdVal")
        OrdText = Session("OrdText")
        SelExams = Session("Selexams")
        SelExamslno = Session("SelExamslno")
        DsSel = Session("DsSel")
        Sbjset = Session("Sbjset")
        ExmSelstr = LblSelExm.Text
        LblHead = Session("LblHead")
        If ExmSelstr.IndexOf(DrpResultExam.SelectedItem.Text) > -1 Then
            Exit Sub
        Else
            Select Case DrpResultExamType.SelectedValue
                Case 1
                    For Each ctrl As Control In Me.PnlIIT.Controls
                        If TypeOf ctrl Is CheckBox And Left(ctrl.ID, 3) = "IIT" Then
                            Dim TmpChk As CheckBox
                            TmpChk = ctrl
                            If Tmpchk.Checked Then
                                Dr = DsSel.Tables(0).NewRow
                                Cnt += 1
                                Dr("TBLSLNO") = Cnt
                                Dr("EXAMTYPESLNO") = DrpResultExamType.SelectedValue
                                Dr("EXAMTYPE") = DrpResultExamType.SelectedItem.Text
                                Dr("RESLNO") = DrpResultExam.SelectedValue
                                Dr("RESEXAMNAME") = DrpResultExam.SelectedItem.Text
                                Dr("COLNAME") = Right(ctrl.ID, Len(ctrl.ID) - 4)
                                Dr("COLTEXT") = TmpChk.Text
                                Dr("GROUPSLNO") = 1
                                Dr("SELCOLN") = "RES" + DrpResultExam.SelectedValue.ToString + "." + Right(ctrl.ID, Len(ctrl.ID) - 4) + " RES" + DrpResultExam.SelectedValue.ToString + "_" + Right(ctrl.ID, Len(ctrl.ID) - 4)
                                Dr("TBLASNAME") = "RES" + DrpResultExam.SelectedValue.ToString
                                Dr("VENCOL") = "RES" + DrpResultExam.SelectedValue.ToString + "_" + Right(ctrl.ID, Len(ctrl.ID) - 4)
                                Dr("COLFRM") = 1
                                DsSel.Tables(0).Rows.Add(Dr)
                                OrdText += DrpResultExam.SelectedItem.ToString + "_" + TmpChk.Text + ","
                                OrdVal += "RES" + DrpResultExam.SelectedValue.ToString + "_" + Right(ctrl.ID, Len(ctrl.ID) - 4) + ","
                            End If
                        End If
                    Next
                    SBjqry = "SELECT DISTINCT REM.RESLNO,REM.SUBJECTSLNO, SUB.NAME SUBJECT, SUB.REPORTORDER,'" + DrpResultExam.SelectedItem.ToString & "'||" & "'_'" & "||SUB.NAME SBJCOL,'" + "RES" + "'||REM.RESLNO||SUB.NAME SBJORDCOL FROM RESULT_ERGS_MT REM, T_SUBJECT_MT SUB " & _
                                                 "WHERE REM.SUBJECTSLNO = SUB.SUBJECTSLNO AND RESLNO=" & DrpResultExam.SelectedValue & " ORDER BY REM.RESLNO,SUB.REPORTORDER"
                    Dim sset As New DataSet
                    ObjResult = New Utility
                    Sset = ObjResult.DataSet_OneFetch(SBjqry)
                    DatasetMerge(Sbjset, Sset)
                Case 2
                    For Each ctrl As Control In Me.PnlAIEEE.Controls
                        If TypeOf ctrl Is CheckBox And Left(ctrl.ID, 3) = "AIE" Then
                            Dim TmpChk As CheckBox
                            TmpChk = ctrl
                            If Tmpchk.Checked Then
                                Dr = DsSel.Tables(0).NewRow
                                Cnt += 1
                                Dr("TBLSLNO") = Cnt
                                Dr("EXAMTYPESLNO") = DrpResultExamType.SelectedValue
                                Dr("EXAMTYPE") = DrpResultExamType.SelectedItem.Text
                                Dr("RESLNO") = DrpResultExam.SelectedValue
                                Dr("RESEXAMNAME") = DrpResultExam.SelectedItem.Text
                                Dr("COLNAME") = Right(ctrl.ID, Len(ctrl.ID) - 4)
                                Dr("COLTEXT") = TmpChk.Text
                                Dr("SELCOLN") = "RES" + DrpResultExam.SelectedValue.ToString + "." + Right(ctrl.ID, Len(ctrl.ID) - 4) + " RES" + DrpResultExam.SelectedValue.ToString + "_" + Right(ctrl.ID, Len(ctrl.ID) - 4)
                                Dr("TBLASNAME") = "RES" + DrpResultExam.SelectedValue.ToString
                                Dr("VENCOL") = "RES" + DrpResultExam.SelectedValue.ToString + "_" + Right(ctrl.ID, Len(ctrl.ID) - 4)
                                Dr("COLFRM") = 1
                                DsSel.Tables(0).Rows.Add(Dr)
                                OrdText += DrpResultExam.SelectedItem.ToString + "_" + TmpChk.Text + ","
                                OrdVal += "RES" + DrpResultExam.SelectedValue.ToString + "_" + Right(ctrl.ID, Len(ctrl.ID) - 4) + ","
                            End If
                        End If
                    Next
                    SBjqry = "SELECT DISTINCT REM.RESLNO,REM.SUBJECTSLNO, SUB.NAME SUBJECT, SUB.REPORTORDER,'" + DrpResultExam.SelectedItem.ToString & "'||" & "'_'" & "||SUB.NAME SBJCOL,'" + "RES" + "'||REM.RESLNO||SUB.NAME SBJORDCOL FROM RESULT_ERGS_MT REM, T_SUBJECT_MT SUB " & _
                                                 "WHERE REM.SUBJECTSLNO = SUB.SUBJECTSLNO AND RESLNO=" & DrpResultExam.SelectedValue & " ORDER BY REM.RESLNO,SUB.REPORTORDER"
                    Dim sset As New DataSet
                    ObjResult = New Utility
                    Sset = ObjResult.DataSet_OneFetch(SBjqry)
                    DatasetMerge(Sbjset, Sset)
                Case 3
                    For Each ctrl As Control In Me.PnlEAMCET.Controls
                        If TypeOf ctrl Is CheckBox And Left(ctrl.ID, 3) = "EAM" Then
                            Dim TmpChk As CheckBox
                            TmpChk = ctrl
                            If Tmpchk.Checked Then
                                Dr = DsSel.Tables(0).NewRow
                                Cnt += 1
                                Dr("TBLSLNO") = Cnt
                                Dr("EXAMTYPESLNO") = DrpResultExamType.SelectedValue
                                Dr("EXAMTYPE") = DrpResultExamType.SelectedItem.Text
                                Dr("RESLNO") = DrpResultExam.SelectedValue
                                Dr("RESEXAMNAME") = DrpResultExam.SelectedItem.Text
                                Dr("COLNAME") = Right(ctrl.ID, Len(ctrl.ID) - 4)
                                Dr("COLTEXT") = TmpChk.Text
                                Dr("SELCOLN") = "RES" + DrpResultExam.SelectedValue.ToString + "." + Right(ctrl.ID, Len(ctrl.ID) - 4) + " RES" + DrpResultExam.SelectedValue.ToString + "_" + Right(ctrl.ID, Len(ctrl.ID) - 4)
                                Dr("TBLASNAME") = "RES" + DrpResultExam.SelectedValue.ToString
                                Dr("VENCOL") = "RES" + DrpResultExam.SelectedValue.ToString + "_" + Right(ctrl.ID, Len(ctrl.ID) - 4)
                                If Cnt <> 1 And Cnt <> 3 And Cnt <> 6 Then
                                    Dr("COLFRM") = 2
                                Else
                                    Dr("COLFRM") = 1
                                End If
                                DsSel.Tables(0).Rows.Add(Dr)
                                OrdText += DrpResultExam.SelectedItem.ToString + "_" + TmpChk.Text + ","
                                OrdVal += "RES" + DrpResultExam.SelectedValue.ToString + "_" + Right(ctrl.ID, Len(ctrl.ID) - 4) + ","
                            End If
                        End If
                    Next
                    SBjqry = "SELECT DISTINCT REM.RESLNO,REM.SUBJECTSLNO, SUB.NAME SUBJECT, SUB.REPORTORDER,'" + DrpResultExam.SelectedItem.ToString & "'||" & "'_'" & "||SUB.NAME SBJCOL,'" + "RES" + "'||REM.RESLNO||SUB.NAME SBJORDCOL FROM RESULT_ERGS_MT REM, T_SUBJECT_MT SUB " & _
                                                 "WHERE REM.SUBJECTSLNO = SUB.SUBJECTSLNO AND RESLNO=" & DrpResultExam.SelectedValue & " ORDER BY REM.RESLNO,SUB.REPORTORDER"
                    Dim sset As New DataSet
                    ObjResult = New Utility
                    Sset = ObjResult.DataSet_OneFetch(SBjqry)
                    DatasetMerge(Sbjset, Sset)
                Case 4
                    For Each ctrl As Control In Me.PnlIPE.Controls
                        If TypeOf ctrl Is CheckBox And Left(ctrl.ID, 3) = "IPE" Then
                            Dim TmpChk As CheckBox
                            TmpChk = ctrl
                            If Tmpchk.Checked Then
                                Dr = DsSel.Tables(0).NewRow
                                Cnt += 1
                                Dr("TBLSLNO") = Cnt
                                Dr("EXAMTYPESLNO") = DrpResultExamType.SelectedValue
                                Dr("EXAMTYPE") = DrpResultExamType.SelectedItem.Text
                                Dr("RESLNO") = DrpResultExam.SelectedValue
                                Dr("RESEXAMNAME") = DrpResultExam.SelectedItem.Text
                                Dr("COLNAME") = Right(ctrl.ID, Len(ctrl.ID) - 4)
                                Dr("COLTEXT") = TmpChk.Text
                                Dr("SELCOLN") = "RES" + DrpResultExam.SelectedValue.ToString + "." + Right(ctrl.ID, Len(ctrl.ID) - 4) + " RES" + DrpResultExam.SelectedValue.ToString + "_" + Right(ctrl.ID, Len(ctrl.ID) - 4)
                                Dr("TBLASNAME") = "RES" + DrpResultExam.SelectedValue.ToString
                                Dr("VENCOL") = "RES" + DrpResultExam.SelectedValue.ToString + "_" + Right(ctrl.ID, Len(ctrl.ID) - 4)
                                Dr("COLFRM") = 1
                                DsSel.Tables(0).Rows.Add(Dr)
                                OrdText += DrpResultExam.SelectedItem.ToString + "_" + TmpChk.Text + ","
                                OrdVal += "RES" + DrpResultExam.SelectedValue.ToString + "_" + Right(ctrl.ID, Len(ctrl.ID) - 4) + ","
                            End If
                        End If
                    Next
                    SBjqry = "SELECT DISTINCT REM.RESLNO,REM.SUBJECTSLNO, SUB.NAME SUBJECT, SUB.REPORTORDER,'" + DrpResultExam.SelectedItem.ToString & "'||" & "'_'" & "||SUB.NAME SBJCOL,'" + "RES" + "'||REM.RESLNO||SUB.NAME SBJORDCOL FROM RESULT_ERGS_MT REM, T_SUBJECT_MT SUB " & _
                                                 "WHERE REM.SUBJECTSLNO = SUB.SUBJECTSLNO AND RESLNO=" & DrpResultExam.SelectedValue & " AND GROUPSLNO=" & IPE_GROUP.SelectedValue & " ORDER BY REM.RESLNO,SUB.REPORTORDER"
                    Dim sset As New DataSet
                    ObjResult = New Utility
                    Sset = ObjResult.DataSet_OneFetch(SBjqry)
                    DatasetMerge(Sbjset, Sset)
                    GRPNO = IPE_GROUP.SelectedValue
                Case 5
                    For Each ctrl As Control In Me.PnlOTH.Controls
                        If TypeOf ctrl Is CheckBox And Left(ctrl.ID, 3) = "OTH" Then
                            Dim TmpChk As CheckBox
                            TmpChk = ctrl
                            If Tmpchk.Checked Then
                                Dr = DsSel.Tables(0).NewRow
                                Cnt += 1
                                Dr("TBLSLNO") = Cnt
                                Dr("EXAMTYPESLNO") = DrpResultExamType.SelectedValue
                                Dr("EXAMTYPE") = DrpResultExamType.SelectedItem.Text
                                Dr("RESLNO") = DrpResultExam.SelectedValue
                                Dr("RESEXAMNAME") = DrpResultExam.SelectedItem.Text
                                Dr("COLNAME") = Right(ctrl.ID, Len(ctrl.ID) - 4)
                                Dr("COLTEXT") = TmpChk.Text
                                Dr("SELCOLN") = "RES" + DrpResultExam.SelectedValue.ToString + "." + Right(ctrl.ID, Len(ctrl.ID) - 4) + " RES" + DrpResultExam.SelectedValue.ToString + "_" + Right(ctrl.ID, Len(ctrl.ID) - 4)
                                Dr("TBLASNAME") = "RES" + DrpResultExam.SelectedValue.ToString
                                Dr("VENCOL") = "RES" + DrpResultExam.SelectedValue.ToString + "_" + Right(ctrl.ID, Len(ctrl.ID) - 4)
                                Dr("COLFRM") = 1
                                DsSel.Tables(0).Rows.Add(Dr)
                                OrdText += DrpResultExam.SelectedItem.ToString + "_" + TmpChk.Text + ","
                                OrdVal += "RES" + DrpResultExam.SelectedValue.ToString + "_" + Right(ctrl.ID, Len(ctrl.ID) - 4) + ","
                            End If
                        End If
                    Next
                    SBjqry = "SELECT DISTINCT REM.RESLNO,REM.SUBJECTSLNO, SUB.NAME SUBJECT, SUB.REPORTORDER,'" + DrpResultExam.SelectedItem.ToString & "'||" & "'_'" & "||SUB.NAME SBJCOL,'" + "RES" + "'||REM.RESLNO||SUB.NAME SBJORDCOL FROM RESULT_ERGS_MT REM, T_SUBJECT_MT SUB " & _
                                                 "WHERE REM.SUBJECTSLNO = SUB.SUBJECTSLNO AND RESLNO=" & DrpResultExam.SelectedValue & " ORDER BY REM.RESLNO,SUB.REPORTORDER"
                    Dim sset As New DataSet
                    ObjResult = New Utility
                    Sset = ObjResult.DataSet_OneFetch(SBjqry)
                    DatasetMerge(Sbjset, Sset)
            End Select
            SelExams += DrpResultExam.SelectedItem.Text + ","
            SelExamslno += DrpResultExam.SelectedValue.ToString + ","
            LblSelExm.Text += " " + DrpResultExam.SelectedItem.Text + "; "
            LblHead += DrpResultExam.SelectedItem.ToString + ","
            Session("DsSel") = DsSel
            Session("SelExams") = SelExams
            Session("SelExamslno") = SelExamslno
            Session("OrdText") = OrdText
            Session("OrdVal") = OrdVal
            Session("Sbjset") = Sbjset
            Session("LblHead") = LblHead
            If GRPNO = 0 Then
                GRPNO = 1
            End If
            Session("GRPNO") = GRPNO
        End If
    End Sub

#End Region

#Region "Button Events"

    Public Event BtnAdd_Clik(ByVal sender As Object, ByVal e As System.EventArgs)

#End Region

#Region "Selected Index Changed Events"
    Private Sub DrpResultExamType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpResultExamType.SelectedIndexChanged
        FillResultExams()
    End Sub
#End Region

#Region "Properties"

    Public Property X() As Integer

        Get
            Return X
        End Get

        Set(ByVal Value As Integer)
            X = Value
        End Set

    End Property

#End Region

#Region "Methods"

    Private Sub SbjPrepTable()
        Sbjset = New DataSet
        Sbjset.Tables.Add(New DataTable("SbjResSel"))
        Dim Sbjdt As New DataTable
        Sbjdt = Sbjset.Tables(0)

        Sbjdt.Columns.Add("RESLNO", Type.GetType("System.Int64"))
        Sbjdt.Columns.Add("SUBJECTSLNO", Type.GetType("System.Int64"))
        Sbjdt.Columns.Add("SUBJECT", Type.GetType("System.String"))
        Sbjdt.Columns.Add("REPORTORDER", Type.GetType("System.Int64"))
        Sbjdt.Columns.Add("SBJCOL", Type.GetType("System.String"))
        Sbjdt.Columns.Add("SBJORDCOL", Type.GetType("System.String"))

        Session("Sbjset") = Sbjset

    End Sub

    Private Function DatasetMerge(ByVal Maindataset As DataSet, ByVal Childdataset As DataSet)
        Dim i, j As Integer
        Dim Dsm As DataRow
        For i = 0 To Childdataset.Tables(0).Rows.Count - 1
            Dsm = Maindataset.Tables(0).NewRow
            For j = 0 To Maindataset.Tables(0).Columns.Count - 1
                Dsm(Maindataset.Tables(0).Columns(j).ColumnName) = Childdataset.Tables(0).Rows(i).Item(j)
            Next
            Maindataset.Tables(0).Rows.Add(Dsm)
        Next
    End Function

#End Region

#End Region

End Class
