'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : ENTRY FORM FOR KEY OBJECTIONS FROM BRANCHES
'   AUTHOR                            : P.VENU
'   INITIAL BASELINE DATE             : 18.07.2011
'   FINAL BASELINE DATE               : 19.07.2011
'   COMPLETED DATE                    : 21.07.2011
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Public Class Exam_Objections_Entry
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpExamBranch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtLandLine As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtPrince As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtPrinceMob As System.Web.UI.WebControls.TextBox
    Protected WithEvents LblPS As System.Web.UI.WebControls.Label
    Protected WithEvents DgTrans As System.Web.UI.WebControls.DataGrid
    Protected WithEvents IbtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ImageButton2 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpExamDate As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpExamName As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TxtCorrections As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents IbtGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents dgUserObj As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " ==> FormVariables"

    Dim SqlStr, SqlStr1, StrSplit, StrSplitStr(), StrSplitData, SplitStr, RtnVal, rtnString As String
    Dim objWSCombo As Utility
    Dim objTrans As NOETransaction
    Private DsSbj As DataSet
    Dim ObjFetch As Utility
    Dim Dset, DsSplit, DsQDet, MaindSet As New DataSet
    Dim i, j, k, l As Integer
    Public StrDet, StrDet1 As String
    Public DtQDet As New DataTable
    Dim Dgindex, StrPaperSetter As Integer
    Dim DrSbj() As DataRow
    Dim EamorIit As Integer

#End Region

#Region " ==> Page Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                FillExamDate()
                FillExamBranch()
                'FillExamNames()
            Else
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " ==> Fill Methods"

    Private Sub FillExamBranch()
        Try
            SqlStr = "SELECT EXAMBRANCHSLNO,EXAMBRANCHNAME FROM EXAM_EXAMBRANCH WHERE EXAMBRANCHSLNO IN (SELECT EXAMBRANCHSLNO FROM E_USER_BRANCH_ACADEMIC_MT WHERE COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND USERSLNO=" & Session("USERSLNO") & ") ORDER BY EXAMBRANCHNAME"
            objWSCombo = New Utility
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)
            DrpExamBranch.DataTextField = "EXAMBRANCHNAME"
            DrpExamBranch.DataValueField = "EXAMBRANCHSLNO"
            DrpExamBranch.DataSource = Dset
            DrpExamBranch.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillExamNames()
        Try
            SqlStr = "SELECT EXAMNAME||'/'||DESCRIPTION OBJEXAMNAME,DEXAMSLNO OBJTESTSLNO FROM EXAM_DFINEEXAM WHERE COMBINATIONKEY IN(SELECT COMBINATIONKEY FROM EXAM_USERCOMBINATIONKEY_MT WHERE USERSLNO=" & Session("USERSLNO") & " AND COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & ") AND EXAMTYPE NOT IN('IPE')" & _
                     " AND EXAMDATE=TO_DATE('" & DrpExamDate.SelectedItem.Value & "','DD/MM/YYYY') AND COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " ORDER BY OBJEXAMNAME DESC"
            objWSCombo = New Utility
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)
            DrpExamName.DataTextField = "OBJEXAMNAME"
            DrpExamName.DataValueField = "OBJTESTSLNO"
            DrpExamName.DataSource = Dset
            DrpExamName.DataBind()
            SqlStr = "SELECT OBJLOCKSTATUS FROM EXAM_DFINEEXAM WHERE DEXAMSLNO=" & DrpExamName.SelectedItem.Value
            objWSCombo = New Utility
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)
            If Not IsDBNull(Dset.Tables(0).Rows(0).Item(0)) Then
                ImageButtonsHiding(False)
                StartUpScript("LockStatus", "Exam Locked..!")
                dgUserObj.Visible = False
            Else
                ImageButtonsHiding(True)
                FillUserObjections()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillExamDate()
        Try
            SqlStr = "SELECT DISTINCT TO_CHAR(EXAMDATE,'DD/MM/YYYY') OBJTESTDATE,EXAMDATE DT FROM EXAM_DFINEEXAM WHERE COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND EXAMDATE BETWEEN TO_DATE('" & System.DateTime.Today.AddDays(-7).ToString("dd/MM/yyyy") & "','DD/MM/YYYY') AND TO_DATE('" & System.DateTime.Today.ToString("dd/MM/yyyy") & "','DD/MM/YYYY') ORDER BY DT DESC"
            objWSCombo = New Utility
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)
            If Dset.Tables(0).Rows.Count <> 0 Then
                DrpExamDate.BackColor = Color.Empty
                DrpExamDate.DataTextField = "OBJTESTDATE"
                DrpExamDate.DataValueField = "OBJTESTDATE"
                DrpExamDate.DataSource = Dset
                DrpExamDate.DataBind()
                FillExamNames()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillEmptyGrid()
        Try
            Dim dt As New DataTable
            dt.Columns.Add("SNO", Type.GetType("System.Int32"))
            For i As Integer = 1 To Val(TxtCorrections.Text)
                Dim dRow As DataRow
                dRow = dt.NewRow
                dRow("SNO") = i
                dt.Rows.Add(dRow)
            Next
            DgTrans.DataSource = dt
            DgTrans.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillDrpSubject(ByVal EamorIit As Integer)
        Try
            Dim i As Integer
            Dim dr As DataRow

            If EamorIit = 0 Then
                SqlStr = "SELECT SUBJECTSLNO,COUNT(*) FROM EXAM_QPTTAILOR WHERE DEXAMSLNO=" & DrpExamName.SelectedItem.Value & " GROUP BY SUBJECTSLNO "
            Else
                SqlStr = "SELECT SUBJECTSLNO,COUNT(*) FROM EXAM_IITQPAPER_TAILOR_DT WHERE DEXAMSLNO=" & DrpExamName.SelectedItem.Value & " GROUP BY SUBJECTSLNO"
            End If

            objWSCombo = New Utility
            DsSplit = objWSCombo.DataSet_OneFetch(SqlStr)

            For i = 0 To DsSplit.Tables(0).Rows.Count - 1
                StrSplitData += DsSplit.Tables(0).Rows(i).Item(0).ToString + IIf(DsSplit.Tables(0).Rows.Count - 1 <> i, ",", "")
            Next

            SqlStr = "SELECT SUBJECTSLNO,NAME FROM T_SUBJECT_MT WHERE SUBJECTSLNO IN(" & StrSplitData & ")"

            objWSCombo = New Utility
            If IsNothing(DsSbj) Then
                DsSbj = objWSCombo.DataSet_OneFetch(SqlStr)
            End If

            Dim drpDown1 As DropDownList
            For i = 0 To Val(TxtCorrections.Text) - 1
                drpDown1 = CType(DgTrans.Items(i).Cells(1).FindControl("DrpSbj"), DropDownList)
                drpDown1.DataSource = DsSbj
                drpDown1.DataTextField = "NAME"
                drpDown1.DataValueField = "SUBJECTSLNO"
                drpDown1.DataBind()
            Next

            For i = 0 To DgTrans.Items.Count - 1
                Dim ddllist As DropDownList = CType(DgTrans.Items(i).Controls(1).FindControl("DrpQstn"), DropDownList)
                Dim cell As TableCell = CType(ddllist.Parent, TableCell)
                Dim item As DataGridItem = CType(cell.Parent, DataGridItem)
                Dim content As String = item.ItemIndex
                Dim ddlType As DropDownList = CType(item.Cells(1).FindControl("DrpSbj"), DropDownList)
                ExamQstnFrmto()
                DrSbj = DsQDet.Tables(0).Select("SUBJECTSLNO=" & ddlType.SelectedItem.Value)
                Dim ddlItem As DropDownList = CType(item.Cells(2).FindControl("DrpQstn"), DropDownList)
                If ddlItem.Items.Count <> 0 Then
                    ddlItem.Items.Clear()
                End If
                'Dim VenDtbl As New DataTable
                'VenDtbl.Columns.Add("QUESTIONNO", Type.GetType("System.Int32"))
                'VenDtbl.Columns.Add("QUESTIONNO", Type.GetType("System.Int32"))

                For j As Integer = 0 To DrSbj.Length - 1
                    'Dim Vdr As DataRow
                    'Dim dRow As DataRow
                    'dRow = VenDtbl.NewRow
                    'dRow("SNO") = i
                    'dt.Rows.Add(dRow)
                    ddlItem.Items.Add(New ListItem(DrSbj(j)("QUESTIONNO").ToString, DrSbj(j)("VENQSTN")))
                Next
                ddlItem.DataBind()
            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillUserObjections()
        Try
            SqlStr = "SELECT SBJ.NAME,OBJ.OBJQUESTIONNO,OBJ.OBJGIVENKEY,OBJ.OBJCORRECTKEY,OBJ.OBJREMARKS,OBJ.OBJLECTURER,OBJ.OBJLECTMOBILE FROM T_SUBJECT_MT SBJ,OBJECTIONS_OBJECTION_DT OBJ WHERE OBJ.OBJTESTSLNO=" & DrpExamName.SelectedItem.Value & " AND OBJ.OBJSUBJECTSLNO=SBJ.SUBJECTSLNO AND OBJEBSLNO=" & DrpExamBranch.SelectedItem.Value
            objWSCombo = New Utility
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)
            If dgUserObj.Visible = False Then
                dgUserObj.Visible = True
            End If
            If Dset.Tables(0).Rows.Count <> 0 Then
                dgUserObj.DataSource = Dset.Tables(0)
                dgUserObj.DataBind()
            Else
                dgUserObj.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " ==> Methods"

    Private Function FormValidation()
        Try
            Dim FormVal As Integer = 0
            If DrpExamBranch.Items.Count = 0 Then
                DrpExamBranch.BackColor = Color.Red
                FormVal = 1
            Else
                DrpExamBranch.BackColor = Color.Empty
            End If

            If DrpExamName.Items.Count = 0 Then
                DrpExamName.BackColor = Color.Red
                FormVal = 1
            Else
                DrpExamName.BackColor = Color.Empty
            End If

            If DrpExamDate.Items.Count = 0 Then
                DrpExamDate.BackColor = Color.Red
                FormVal = 1
            Else
                DrpExamDate.BackColor = Color.Empty
            End If

            If TxtLandLine.Text = "" Then
                TxtLandLine.BorderColor = Color.Red
                FormVal = 1
            Else
                TxtLandLine.BorderColor = Color.Empty
            End If

            If TxtPrince.Text = "" Then
                TxtPrince.BorderColor = Color.Red
                FormVal = 1
            Else
                TxtPrince.BorderColor = Color.Empty
            End If

            If TxtPrinceMob.Text = "" Then
                TxtPrinceMob.BorderColor = Color.Red
                FormVal = 1
            Else
                TxtPrinceMob.BorderColor = Color.Empty
            End If

            If Val(TxtCorrections.Text) = 0 Then
                TxtCorrections.BorderColor = Color.Red
                FormVal = 1
            Else
                TxtCorrections.BorderColor = Color.Empty
            End If

            If FormVal = 1 Then
                StartUpScript("Validation", " Verify Your Selection (Red Marked..!)")
                Return False
            Else
                Return True
            End If

        Catch ex As Exception

        End Try
    End Function

    Private Function GridValidation()
        Try
            Dim VDrpSbj As DropDownList
            Dim VTxtQstn, VTxtWk, VTxtCk, VTxtRem, VTxtLect, VTxtLMob As TextBox
            Dim StrSubjects, StrQFrom, StrQto As String
            Dim GridVal As Integer = 0

            For i As Integer = 0 To DgTrans.Items.Count - 1
                VTxtWk = DgTrans.Items(i).Cells(4).Controls(1)
                VTxtCk = DgTrans.Items(i).Cells(5).Controls(1)
                VTxtRem = DgTrans.Items(i).Cells(6).Controls(1)
                VTxtLect = DgTrans.Items(i).Cells(7).Controls(1)
                VTxtLMob = DgTrans.Items(i).Cells(8).Controls(1)

                If VTxtWk.Text = "" Then
                    VTxtWk.BorderColor = Color.Red
                    GridVal = 1
                Else
                    VTxtWk.BorderColor = Color.Empty
                End If

                If VTxtCk.Text = "" Then
                    VTxtCk.BorderColor = Color.Red
                    GridVal = 1
                Else
                    VTxtCk.BorderColor = Color.Empty
                End If

                If Trim(VTxtWk.Text) = Trim(VTxtCk.Text) Then
                    VTxtWk.BorderColor = Color.Red
                    VTxtCk.BorderColor = Color.Red
                    VTxtWk.ToolTip = "WrongKey and CorrectKey should not be Same...!"
                    VTxtCk.ToolTip = "WrongKey and CorrectKey should not be Same...!"
                    GridVal = 1
                Else
                    VTxtWk.BorderColor = Color.Empty
                    VTxtWk.BorderColor = Color.Empty
                    VTxtWk.ToolTip = ""
                    VTxtCk.ToolTip = ""
                End If

                If VTxtRem.Text = "" Then
                    VTxtRem.BorderColor = Color.Red
                    GridVal = 1
                Else
                    VTxtRem.BorderColor = Color.Empty
                End If
                If VTxtLect.Text = "" Then
                    VTxtLect.BorderColor = Color.Red
                    GridVal = 1
                Else
                    VTxtLect.BorderColor = Color.Empty
                End If

                If VTxtLMob.Text = "" Then
                    VTxtLMob.BorderColor = Color.Red
                    GridVal = 1
                Else
                    VTxtLMob.BorderColor = Color.Empty
                End If
            Next

            If GridVal = 1 Then
                StartUpScript("Validation", " Verify Your Selection (Red Marked..!)")
                Return False
            Else
                Return True
            End If

        Catch ex As Exception

        End Try
    End Function

    Private Function ReturnEamorIIT()
        Try
            EamorIit = FindEAMorIIT(DrpExamName.SelectedItem.Value)
            Session("EamorIit") = EamorIit
        Catch ex As Exception

        End Try
    End Function

    Private Function ExamQstnFrmto()
        Try

            If EamorIit = 0 Then
                SqlStr = "SELECT QPTTSLNO,SUBJECTSLNO,NOOFQUESTIONS QSTN FROM EXAM_QPTTAILOR WHERE DEXAMSLNO=" & DrpExamName.SelectedItem.Value & " ORDER BY QPTTSLNO"
            Else
                'SqlStr = "SELECT SUBJECTSLNO,TRACKSLNO,QUESTIONNO FROM EXAM_IITQPAPER_TAILOR_DT WHERE DEXAMSLNO=" & DrpExamName.SelectedItem.Value
                SqlStr = "SELECT SUBJECTSLNO,TRACKSLNO,'P'||TO_CHAR(PAPERSLNO)||'-Q'||TO_CHAR(PAPERQNO) QSTNO,'' QUESTIONNO,QUESTIONNO VENQSTN FROM EXAM_IITQPAPER_TAILOR_DT WHERE DEXAMSLNO=" & DrpExamName.SelectedItem.Value & " ORDER BY VENQSTN"
                SqlStr1 = "SELECT PAPERQNO,'P'||TO_CHAR(PAPERSLNO)||'-Q'||TO_CHAR(PAPERQNO) QSTNO,COUNT(*) CNT FROM EXAM_IITQPAPER_TAILOR_DT WHERE DEXAMSLNO=" & DrpExamName.SelectedItem.Value & " GROUP BY PAPERSLNO,PAPERQNO,'P'||TO_CHAR(PAPERSLNO)||'-Q'||TO_CHAR(PAPERQNO) ORDER BY PAPERSLNO,TO_NUMBER(PAPERQNO)"
            End If

            DsQDet = SubjectWiseQuestions(EamorIit, SqlStr, SqlStr1)

            Return DsQDet
            Return EamorIit
        Catch ex As Exception

        End Try
    End Function

    Private Function GridDataforSave()
        Try
            Dim ArrMt As New ArrayList
            Dim ArrDt As New ArrayList
            Dim S_Sbj, S_Qno As DropDownList
            Dim S_Wk, S_Ck, S_Rem, S_Lect, S_LMob As TextBox
            Dim GridValidation As Boolean = True
            Dim RtnSave As Integer
            StrPaperSetter = Session("StrPaperSetter")

            'Master
            ArrMt.Add(DrpExamBranch.SelectedItem.Value)
            ArrMt.Add(TxtLandLine.Text)
            ArrMt.Add(TxtPrince.Text)
            ArrMt.Add(TxtPrinceMob.Text)
            ArrMt.Add(DrpExamName.SelectedItem.Value)
            ArrMt.Add(DrpExamName.SelectedItem.Value)
            ArrMt.Add(Val(TxtCorrections.Text))
            ArrMt.Add(Session("COMACADEMICSLNO"))
            ArrMt.Add(StrPaperSetter)

            'Details
            Dim VDt As New DataTable("GridData")
            Dim VDr As DataRow
            VDt.Columns.Add("OBJTESTSLNO", Type.GetType("System.Int32"))
            VDt.Columns.Add("OBJSUBJECTSLNO", Type.GetType("System.Int32"))
            VDt.Columns.Add("OBJQUESTIONNO", Type.GetType("System.String"))
            VDt.Columns.Add("OBJGIVENKEY", Type.GetType("System.String"))
            VDt.Columns.Add("OBJCORRECTKEY", Type.GetType("System.String"))
            VDt.Columns.Add("OBJREMARKS", Type.GetType("System.String"))
            VDt.Columns.Add("OBJLECTURER", Type.GetType("System.String"))
            VDt.Columns.Add("OBJLECTMOBILE", Type.GetType("System.String"))
            VDt.Columns.Add("OBJCOMACADEMICSLNO", Type.GetType("System.Int32"))
            VDt.Columns.Add("OQUESTIONNO", Type.GetType("System.Int32"))

            For i As Integer = 0 To DgTrans.Items.Count - 1
                S_Sbj = DgTrans.Items(i).Cells(1).Controls(1)
                S_Qno = DgTrans.Items(i).Cells(2).Controls(1)
                S_Wk = DgTrans.Items(i).Cells(4).Controls(1)
                S_Ck = DgTrans.Items(i).Cells(5).Controls(1)
                S_Rem = DgTrans.Items(i).Cells(6).Controls(1)
                S_Lect = DgTrans.Items(i).Cells(7).Controls(1)
                S_LMob = DgTrans.Items(i).Cells(8).Controls(1)

                VDr = VDt.NewRow
                VDr("OBJTESTSLNO") = DrpExamName.SelectedItem.Value
                VDr("OBJSUBJECTSLNO") = S_Sbj.SelectedItem.Value
                VDr("OBJQUESTIONNO") = S_Qno.SelectedItem.Text
                VDr("OBJGIVENKEY") = S_Wk.Text
                VDr("OBJCORRECTKEY") = S_Ck.Text
                VDr("OBJREMARKS") = Trim(S_Rem.Text)
                VDr("OBJLECTURER") = S_Lect.Text
                VDr("OBJLECTMOBILE") = S_LMob.Text
                VDr("OBJCOMACADEMICSLNO") = Session("COMACADEMICSLNO")
                VDr("OQUESTIONNO") = Val(S_Qno.SelectedItem.Value)
                VDt.Rows.Add(VDr)
            Next

            MaindSet.Tables.Add(VDt)

            RtnSave = objTrans.OBJECTION_INSERT(MaindSet, ArrMt)

            Return RtnSave

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ClearScreen()
        Try
            DgTrans.Visible = False
            TxtLandLine.Text = Nothing
            TxtPrince.Text = Nothing
            TxtPrinceMob.Text = Nothing
            TxtCorrections.Text = Nothing
            LblPS.Visible = False
        Catch ex As Exception

        End Try

    End Function

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

    Private Function FindEAMorIIT(ByVal Dexamslno As Integer)
        Try
            SqlStr = "SELECT EXAMTYPE FROM EXAM_EXAMTYPE_DT WHERE EXAMTYPEDTSLNO IN(SELECT EXAMTYPEDTSLNO FROM EXAM_DFINEEXAM WHERE DEXAMSLNO=" & Dexamslno & ")"
            ObjFetch = New Utility
            Dset = ObjFetch.DataSet_OneFetch(SqlStr)
            If Dset.Tables(0).Rows(0).Item(0) <> "IIT" Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Function SubjectWiseQuestions(ByVal EamorIit As Integer, ByVal SqlStr As String, ByVal SqlStr1 As String)
        Try
            Dim ExDS As New DataSet

            If EamorIit = 1 Then ' IIT EXAMS
                ObjFetch = New Utility
                ExDS = ObjFetch.DataSet_TwoFetch(SqlStr, SqlStr1)
                Dim VenDt As New DataTable

                VenDt.Columns.Add("QSTNNO", Type.GetType("System.String"))
                For i = 0 To ExDS.Tables(1).Rows.Count - 1
                    j = ExDS.Tables(1).Rows(i).Item(2)
                    Dim Dr As DataRow
                    If j > 1 Then
                        For k = 0 To j - 1
                            Dr = VenDt.NewRow
                            If k = 0 Then
                                Dr("QSTNNO") = ExDS.Tables(1).Rows(i).Item(1).ToString + "a"
                            ElseIf k = 1 Then
                                Dr("QSTNNO") = ExDS.Tables(1).Rows(i).Item(1).ToString + "b"
                            ElseIf k = 2 Then
                                Dr("QSTNNO") = ExDS.Tables(1).Rows(i).Item(1).ToString + "c"
                            ElseIf k = 3 Then
                                Dr("QSTNNO") = ExDS.Tables(1).Rows(i).Item(1).ToString + "d"
                            ElseIf k = 4 Then
                                Dr("QSTNNO") = ExDS.Tables(1).Rows(i).Item(1).ToString + "e"
                            End If
                            VenDt.Rows.Add(Dr)
                        Next
                    Else
                        Dr = VenDt.NewRow
                        Dr("QSTNNO") = ExDS.Tables(1).Rows(i).Item(1)
                        VenDt.Rows.Add(Dr)
                    End If
                Next
                For l = 0 To VenDt.Rows.Count - 1
                    ExDS.Tables(0).Rows(l)("QUESTIONNO") = VenDt.Rows(l)("QSTNNO")
                Next
            Else                 ' NON-IIT EXAMS
                ObjFetch = New Utility
                Dset = ObjFetch.DataSet_OneFetch(SqlStr)
                Dim ExDt As New DataTable
                ExDt.Columns.Add("SUBJECTSLNO", Type.GetType("System.Int32"))
                ExDt.Columns.Add("QUESTIONNO", Type.GetType("System.Int32"))
                ExDt.Columns.Add("VENQSTN", Type.GetType("System.Int32"))
                Dim Exdr As DataRow
                Dim x As Integer
                Dim y As Integer
                For i = 0 To Dset.Tables(0).Rows.Count - 1
                    If i = 0 Then
                        x = 1
                    Else
                        x += Dset.Tables(0).Rows(i - 1).Item(2)
                    End If
                    y += Dset.Tables(0).Rows(i).Item(2)
                    For j As Integer = x To y
                        Exdr = ExDt.NewRow
                        Exdr("SUBJECTSLNO") = Dset.Tables(0).Rows(i).Item(1)
                        Exdr("QUESTIONNO") = j
                        Exdr("VENQSTN") = j
                        ExDt.Rows.Add(Exdr)
                    Next
                Next
                ExDS.Tables.Add(ExDt)
            End If

            Return ExDS
        Catch ex As Exception

        End Try
    End Function

    Private Function PaperSetter()
        Try
            SqlStr = "SELECT EXAMBRANCHSLNO,EXAMBRANCHNAME FROM EXAM_EXAMBRANCH WHERE EXAMBRANCHSLNO IN(SELECT PAPERSETTEREBSLNO FROM EXAM_DFINEEXAM WHERE DEXAMSLNO=" & DrpExamName.SelectedItem.Value & ")"
            objWSCombo = New Utility
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)
            If Dset.Tables(0).Rows.Count <> 0 Then
                StrPaperSetter = Dset.Tables(0).Rows(0).Item(0)
                StrDet1 = " PAPERSETTER : " + Dset.Tables(0).Rows(0).Item(1).ToString
            Else
                StrDet1 = "***"
            End If
            Session("StrPaperSetter") = StrPaperSetter
            Return StrDet1
        Catch ex As Exception

        End Try
    End Function

    Private Function ImageButtonsHiding(ByVal Val As Boolean)
        Try
            Dim i As Integer
            Dim ImgBtn As ImageButton
            Dim objc As Control
            Dim objchildc As Control
            For Each objc In Page.Controls
                For Each objchildc In objc.Controls
                    If TypeOf objchildc Is ImageButton Then
                        ImgBtn = CType(objchildc, ImageButton)
                        ImgBtn.Enabled = Val
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " ==> Ibtn Events"

    Private Sub IbtGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtGo.Click
        Try
            If FormValidation() Then
                LblPS.Visible = True
                ReturnEamorIIT()
                ExamQstnFrmto()
                PaperSetter()
                LblPS.Text = StrDet1.ToString
                DgTrans.Visible = True
                FillEmptyGrid()
                FillDrpSubject(EamorIit)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IbtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnSave.Click
        Try
            Dim ValRtn As Integer
            If GridValidation() Then
                objTrans = New NOETransaction
                ValRtn = GridDataforSave()
                If ValRtn = 1 Then
                    StartUpScript(IbtnSave.ID, " Data Inserted Successfully..!")
                Else
                    StartUpScript(IbtnSave.ID, " Error in Insertion..!")
                End If
                ClearScreen()
                FillUserObjections()
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " ==> DropDown Events"

    Private Sub DrpExamName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpExamName.SelectedIndexChanged
        Try
            ClearScreen()
            SqlStr = "SELECT OBJLOCKSTATUS FROM EXAM_DFINEEXAM WHERE DEXAMSLNO=" & DrpExamName.SelectedItem.Value
            objWSCombo = New Utility
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)
            If Not IsDBNull(Dset.Tables(0).Rows(0).Item(0)) Then
                dgUserObj.Visible = False
                ImageButtonsHiding(False)
                StartUpScript("LockStatus", "Exam Locked..!")
            Else
                FillUserObjections()
                ImageButtonsHiding(True)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DrpSbj_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim ddllist As DropDownList = CType(sender, DropDownList)
            Dim cell As TableCell = CType(ddllist.Parent, TableCell)
            Dim item As DataGridItem = CType(cell.Parent, DataGridItem)
            Dim content As String = item.ItemIndex
            Dim ddlType As DropDownList = CType(item.Cells(1).FindControl("DrpSbj"), DropDownList)
            ReturnEamorIIT()
            ExamQstnFrmto()
            DrSbj = DsQDet.Tables(0).Select("SUBJECTSLNO=" & ddlType.SelectedItem.Value)
            Dim ddlItem As DropDownList = CType(item.Cells(2).FindControl("DrpQstn"), DropDownList)
            If ddlItem.Items.Count <> 0 Then
                ddlItem.Items.Clear()
            End If
            For i = 0 To DrSbj.Length - 1
                ddlItem.Items.Add(New ListItem(DrSbj(i)("QUESTIONNO").ToString, DrSbj(i)("VENQSTN")))
            Next
            ddlItem.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrpExamDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpExamDate.SelectedIndexChanged
        FillExamNames()
    End Sub

#End Region

End Class
