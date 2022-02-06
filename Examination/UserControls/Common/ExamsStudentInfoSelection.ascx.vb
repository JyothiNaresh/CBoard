Public Class ExamsStudentInfoSelection
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents LblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents Label25 As System.Web.UI.WebControls.Label
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    Protected WithEvents BtnRemAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LblExb As System.Web.UI.WebControls.Label
    Protected WithEvents BtnExb As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnExbAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemExb As System.Web.UI.WebControls.ImageButton
    Protected WithEvents PrvCourse As System.Web.UI.WebControls.Label


    Public WithEvents LstExb As System.Web.UI.WebControls.ListBox
    Public WithEvents LstSelExb As System.Web.UI.WebControls.ListBox
    Public WithEvents ChkLstCourse As System.Web.UI.WebControls.CheckBoxList
    Public WithEvents ChkLstGroup As System.Web.UI.WebControls.CheckBoxList
    Public WithEvents ChkLstBatch As System.Web.UI.WebControls.CheckBoxList
    Public WithEvents ChkLstSubBatch As System.Web.UI.WebControls.CheckBoxList
    Public WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Public WithEvents CheckBoxList1 As System.Web.UI.WebControls.CheckBoxList
    Public WithEvents DrpPrvCourse As System.Web.UI.WebControls.DropDownList
    Public WithEvents ChkLstPrvCourse As System.Web.UI.WebControls.CheckBoxList

    Public WithEvents UcMainSelection As ReportMainSelection
    Public WithEvents UcCombSelection As CombinationSelectionInfo

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Code"

#Region "Class Variables"

#End Region

#Region "Page Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then

            'LblExb.Text = UcMainSelection.DrpSelection.SelectedItem.Text
        End If
    End Sub

#End Region

#Region "Fill Methods"

    Private Sub FillExamBranches()
        Try



            'If UcCombSelection.LstSelExams.SelectedValue = "" Or UcCombSelection.LstSelExams.SelectedValue Is Nothing Then
            '    'StartUpScript(UcCombSelection.LstExams.ID, " Select Exam ")
            '    Exit Sub
            'End If

            Dim I, K As Integer

            'StrCourses = " "

            'If LSTSelCourse.Items.Count > 0 Then

            '    StrCourses = "  AND EB.COURSESLNO IN ("

            '    For I = 0 To LSTSelCourse.Items.Count - 1
            '        StrCourses &= Val(LSTSelCourse.Items(I).Value.ToString) & IIf(I = LSTSelCourse.Items.Count - 1, ")", ",")
            '    Next

            'End If
            'EXAM BRANCHES
            Dim SelStrExams As String = ""
            'If UcCombSelection.LstSelExams.Items.Count > 0 Then

            '    SelStrExams = " AND EB.DEXAMSLNO IN ("

            '    For I = 0 To UcCombSelection.LstSelExams.Items.Count - 1
            '        SelStrExams &= Val(UcCombSelection.LstSelExams.Items(I).Value.ToString) & IIf(I = UcCombSelection.LstSelExams.Items.Count - 1, ")", ",")
            '    Next

            'End If



            'SqlStr = " SELECT  DISTINCT EB.EXAMBRANCHSLNO,EB.EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE,T_BRANCH_MT BRA,T_REGION_MT RM ," & _
            '        " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & USERSLNO & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
            '        " AND BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.REGIONSLNO=BRA.REGIONSLNO AND DE.DEXAMSLNO=EB.DEXAMSLNO AND DE.EXAMBRANCHSLNO=" & drpExamBranch.SelectedValue & _
            '        " AND RM.REGIONSLNO=" & drpRZ.SelectedValue.ToString & _
            '          StrExamBranch + StrCourses + " ORDER BY EXAMBRANCHNAME"


            'ObjResult = New Utility
            'DSet = ObjResult.GetCommDataSet(SqlStr)

            'LstExb.DataSource = DSet.Tables(0)
            'LstExb.DataTextField = "EXAMBRANCHNAME"
            'LstExb.DataValueField = "EXAMBRANCHSLNO"
            'LstExb.DataBind()
            'LstExb.SelectedIndex = 0

            'LstSelExb.Items.Clear()
            ''Filling Exam Subjects
            'If lstExam.SelectedValue <> "" And Not lstExam.SelectedValue Is Nothing Then
            '    FillSubjects()
            'End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillCourses()
        Try

            'Dim I As Integer

            'StrSelExam = Nothing

            'If lstSelExam.Items.Count > 0 Then

            '    StrSelExam = " DEXAMSLNO IN ("

            '    For I = 0 To lstSelExam.Items.Count - 1
            '        StrSelExam &= Val(lstSelExam.Items(I).Value.ToString) & IIf(I = lstSelExam.Items.Count - 1, ")", ",")
            '    Next

            'End If


            'SqlStr = "SELECT DISTINCT CM.COURSESLNO,CM.NAME FROM T_COURSE_MT CM,EXAM_EXAMTAILORED_MASS ESR,T_ADM_DT ADM " & _
            '         " WHERE ADM.STATUS IN(1,8) AND ADM.ADMSLNO=ESR.ADMSLNO AND CM.COURSESLNO=ADM.COURSESLNO " & _
            '           StrSelExam & " ORDER BY COURSESLNO"

            'SqlStr = "SELECT DISTINCT COURSESLNO,COURSENAME  FROM EXAM_ECGB_MV " & _
            '        " WHERE " & StrSelExam & " ORDER BY COURSESLNO"


            'ObjResult = New Utility
            'DSet = ObjResult.GetCommDataSet(SqlStr)

            'LSTCourse.DataTextField = "COURSENAME"
            'LSTCourse.DataValueField = "COURSESLNO"
            'LSTCourse.DataSource = DSet.Tables(0)
            'LSTCourse.DataBind()

            'LSTSelCourse.Items.Clear()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Fillgroup()
        Try
            'Dim I As Integer

            'StrCourses = Nothing

            ''COURSES
            'If LSTSelCourse.Items.Count > 0 Then
            '    StrCourses = " AND EB.COURSESLNO IN ("
            '    For I = 0 To LSTSelCourse.Items.Count - 1
            '        StrCourses &= Val(LSTSelCourse.Items(I).Value.ToString) & IIf(I = LSTSelCourse.Items.Count - 1, ")", ",")
            '    Next
            'End If

            ''EXAM BRANCHES
            'StrExamBranch = Nothing
            ''If lstSelExamBranch.Items.Count > 0 Then
            ''    StrExamBranch = " AND EXAMBRANCHSLNO IN ("
            ''    For I = 0 To lstSelExamBranch.Items.Count - 1
            ''        StrExamBranch &= Val(lstSelExamBranch.Items(I).Value.ToString) & IIf(I = lstSelExamBranch.Items.Count - 1, ")", ",")
            ''    Next
            ''Else
            ''    Commonfunctions.ClearListBox(LSTGroup)
            ''    Commonfunctions.ClearListBox(lstSelExamBranch)
            ''    Exit Sub
            ''End If


            'If lstSelExamBranch.Items.Count > 0 Then

            '    If drpReportType.SelectedValue = 1 Then   '''FOR EXAMBRANCH --KOrElse drpReportType.SelectedValue = 5
            '        StrExamBranch &= "  EB.EXAMBRANCHSLNO IN ("
            '    ElseIf drpReportType.SelectedValue = 2 Then '''FOR REGION
            '        StrExamBranch &= "  BRA.REGIONSLNO IN ("
            '    ElseIf drpReportType.SelectedValue = 6 Then '''FOR REGION
            '        StrExamBranch &= "  BRA.REGIONSLNO IN ("

            '    ElseIf drpReportType.SelectedValue = 3 Then   '''FOR ZONE
            '        StrExamBranch &= "  BRA.ZONESLNO IN ("
            '    ElseIf drpReportType.SelectedValue = 4 Then   '''FOR DOS
            '        StrExamBranch &= "  BRA.DOSLNO IN ("
            '    ElseIf drpReportType.SelectedValue = 5 Then   '''FOR VCS
            '        StrExamBranch &= "  BRA.VCSLNO IN ("

            '    End If

            '    For I = 0 To lstSelExamBranch.Items.Count - 1
            '        StrExamBranch &= Val(lstSelExamBranch.Items(I).Value.ToString) & IIf(I = lstSelExamBranch.Items.Count - 1, ")", ",")
            '    Next

            'End If

            ''Exams
            'StrSelExam = Nothing
            'If lstSelExam.Items.Count > 0 Then
            '    StrSelExam = " AND EB.DEXAMSLNO IN ("
            '    For I = 0 To lstSelExam.Items.Count - 1
            '        StrSelExam &= Val(lstSelExam.Items(I).Value.ToString) & IIf(I = lstSelExam.Items.Count - 1, ")", ",")
            '    Next
            'End If





            ''SqlStr = "SELECT DISTINCT ESR.GROUPSLNO,GM.NAME FROM T_GROUP_MT GM,EXAM_SUBJECTRANKS ESR WHERE GM.GROUPSLNO=ESR.GROUPSLNO " & _
            ''         StrSelExam + StrCourses + StrExamBranch

            ''SqlStr = "SELECT DISTINCT GROUPSLNO,GROUPNAME FROM EXAM_ECGB_MV WHERE " & _
            ''        StrSelExam + StrCourses + StrExamBranch



            'If drpReportType.SelectedValue = 1 Then ''Exam Branch Wise 

            '    SqlStr = "SELECT DISTINCT GROUPSLNO,GROUPNAME FROM EXAM_ECGB_MV EB WHERE " & _
            '             StrExamBranch & StrSelExam & StrCourses

            'ElseIf drpReportType.SelectedValue = 2 Then ''Region Wise 

            '    SqlStr = " SELECT DISTINCT EB.GROUPSLNO,EB.GROUPNAME FROM EXAM_ECGB_MV EB,T_BRANCH_MT BRA,T_REGION_MT RM " & _
            '             " WHERE  BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.REGIONSLNO=BRA.REGIONSLNO  AND " & _
            '              StrExamBranch & StrSelExam & StrCourses

            'ElseIf drpReportType.SelectedValue = 6 Then ''Region Wise 

            '    SqlStr = " SELECT DISTINCT EB.GROUPSLNO,EB.GROUPNAME FROM EXAM_ECGB_MV EB,EXAM_BRANCH_VIEW BRA,EXAM_REGION_VIEW RM " & _
            '             " WHERE  BRA.EXAMBRANCHSLNO=EB.EXAMBRANCHSLNO AND RM.REGIONSLNO=BRA.REGIONSLNO  AND " & _
            '              StrExamBranch & StrSelExam & StrCourses

            'ElseIf drpReportType.SelectedValue = 3 Then ''Zone Wise 

            '    SqlStr = " SELECT DISTINCT EB.GROUPSLNO,EB.GROUPNAME FROM EXAM_ECGB_MV EB,T_BRANCH_MT BRA,T_ZONE_MT RM " & _
            '            " WHERE  BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.ZONESLNO=BRA.ZONESLNO  AND " & _
            '            StrExamBranch & StrSelExam & StrCourses


            'ElseIf drpReportType.SelectedValue = 4 Then ''D.O's Wise 

            '    SqlStr = " SELECT DISTINCT EB.GROUPSLNO,EB.GROUPNAME FROM EXAM_ECGB_MV EB,T_BRANCH_MT BRA,T_DO_MT RM " & _
            '            " WHERE  BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.DOSLNO=BRA.DOSLNO AND " & _
            '             StrExamBranch & StrSelExam & StrCourses
            'ElseIf drpReportType.SelectedValue = 5 Then ''V.C's Wise 

            '    SqlStr = " SELECT DISTINCT EB.GROUPSLNO,EB.GROUPNAME FROM EXAM_ECGB_MV EB,T_BRANCH_MT BRA,T_VC_MT RM " & _
            '            " WHERE  BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.VCSLNO=BRA.VCSLNO AND " & _
            '             StrExamBranch & StrSelExam & StrCourses
            'End If






            'ObjResult = New Utility
            'DSet = ObjResult.GetCommDataSet(SqlStr)

            'LSTGroup.DataSource = DSet.Tables(0)
            'LSTGroup.DataTextField = "GROUPNAME"
            'LSTGroup.DataValueField = "GROUPSLNO"
            'LSTGroup.DataBind()
            'LSTGroup.SelectedIndex = 0
            'lstSelGroup.Items.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillBatches()
        Try
            'Dim I As Integer

            'StrCourses = Nothing

            ''COURSES
            'If LSTSelCourse.Items.Count > 0 Then
            '    StrCourses = " AND EB.COURSESLNO IN ("
            '    For I = 0 To LSTSelCourse.Items.Count - 1
            '        StrCourses &= Val(LSTSelCourse.Items(I).Value.ToString) & IIf(I = LSTSelCourse.Items.Count - 1, ")", ",")
            '    Next
            'End If

            '''EXAM BRANCHES
            ''StrExamBranch = Nothing
            ''If lstSelExamBranch.Items.Count > 0 Then
            ''    StrExamBranch = " AND EXAMBRANCHSLNO IN ("
            ''    For I = 0 To lstSelExamBranch.Items.Count - 1
            ''        StrExamBranch &= Val(lstSelExamBranch.Items(I).Value.ToString) & IIf(I = lstSelExamBranch.Items.Count - 1, ")", ",")
            ''    Next
            ''End If
            'If lstSelExamBranch.Items.Count > 0 Then

            '    If drpReportType.SelectedValue = 1 OrElse drpReportType.SelectedValue = 5 Then  '''FOR EXAMBRANCH
            '        StrExamBranch &= "  EB.EXAMBRANCHSLNO IN ("
            '    ElseIf drpReportType.SelectedValue = 2 Then '''FOR REGION
            '        StrExamBranch &= "  BRA.REGIONSLNO IN ("
            '    ElseIf drpReportType.SelectedValue = 6 Then '''FOR REGION
            '        StrExamBranch &= "  BRA.REGIONSLNO IN ("

            '    ElseIf drpReportType.SelectedValue = 3 Then   '''FOR ZONE
            '        StrExamBranch &= "  BRA.ZONESLNO IN ("
            '    ElseIf drpReportType.SelectedValue = 4 Then   '''FOR DOS
            '        StrExamBranch &= "  BRA.DOSLNO IN ("
            '    ElseIf drpReportType.SelectedValue = 5 Then   '''FOR VCS
            '        StrExamBranch &= "  BRA.VCSLNO IN ("
            '    End If

            '    For I = 0 To lstSelExamBranch.Items.Count - 1
            '        StrExamBranch &= Val(lstSelExamBranch.Items(I).Value.ToString) & IIf(I = lstSelExamBranch.Items.Count - 1, ")", ",")
            '    Next

            'End If



            ''Exams
            'StrSelExam = Nothing
            'If lstSelExam.Items.Count > 0 Then
            '    StrSelExam = " AND EB.DEXAMSLNO IN ("
            '    For I = 0 To lstSelExam.Items.Count - 1
            '        StrSelExam &= Val(lstSelExam.Items(I).Value.ToString) & IIf(I = lstSelExam.Items.Count - 1, ")", ",")
            '    Next

            'End If
            ''SqlStr = "SELECT DISTINCT ESR.BATCHSLNO,BAT.NAME FROM T_BATCH_MT BAT,EXAM_SUBJECTRANKS ESR WHERE BAT.BATCHSLNO=ESR.BATCHSLNO " & _
            ''          StrSelExam + StrCourses + StrExamBranch

            ''SqlStr = "SELECT DISTINCT BATCHSLNO,BATCHNAME FROM EXAM_ECGB_MV WHERE " & _
            ''          StrExamBranch & StrSelExam & StrCourses

            'If drpReportType.SelectedValue = 1 Then ''Exam Branch Wise 

            '    SqlStr = "SELECT DISTINCT BATCHSLNO,BATCHNAME FROM EXAM_ECGB_MV EB WHERE " & _
            '              StrExamBranch & StrSelExam & StrCourses

            'ElseIf drpReportType.SelectedValue = 2 Then ''Region Wise 

            '    SqlStr = " SELECT DISTINCT BATCHSLNO,BATCHNAME FROM EXAM_ECGB_MV EB,T_BRANCH_MT BRA,T_REGION_MT RM " & _
            '             " WHERE  BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.REGIONSLNO=BRA.REGIONSLNO  AND " & _
            '               StrExamBranch & StrSelExam & StrCourses

            'ElseIf drpReportType.SelectedValue = 6 Then ''Region Wise 

            '    SqlStr = " SELECT DISTINCT BATCHSLNO,BATCHNAME FROM EXAM_ECGB_MV EB,EXAM_BRANCH_VIEW BRA,EXAM_REGION_VIEW RM " & _
            '             " WHERE  BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.REGIONSLNO=BRA.REGIONSLNO  AND " & _
            '               StrExamBranch & StrSelExam & StrCourses



            'ElseIf drpReportType.SelectedValue = 3 Then ''Zone Wise 

            '    SqlStr = " SELECT DISTINCT BATCHSLNO,BATCHNAME FROM EXAM_ECGB_MV EB,T_BRANCH_MT BRA,T_ZONE_MT RM " & _
            '            " WHERE  BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.ZONESLNO=BRA.ZONESLNO AND " & _
            '             StrExamBranch & StrSelExam & StrCourses


            'ElseIf drpReportType.SelectedValue = 4 Then ''D.O's Wise 

            '    SqlStr = " SELECT DISTINCT BATCHSLNO,BATCHNAME FROM EXAM_ECGB_MV EB,T_BRANCH_MT BRA,T_DO_MT RM " & _
            '            " WHERE  BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.DOSLNO=BRA.DOSLNO  AND " & _
            '             StrExamBranch & StrSelExam & StrCourses
            'ElseIf drpReportType.SelectedValue = 5 Then ''V.C's Wise 

            '    SqlStr = " SELECT DISTINCT BATCHSLNO,BATCHNAME FROM EXAM_ECGB_MV EB,T_BRANCH_MT BRA,T_VC_MT RM " & _
            '            " WHERE  BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.VCSLNO=BRA.VCSLNO  AND " & _
            '             StrExamBranch & StrSelExam & StrCourses


            'End If





            'ObjResult = New Utility
            'DSet = ObjResult.GetCommDataSet(SqlStr)

            'LSTBatch.DataSource = DSet.Tables(0)
            'LSTBatch.DataTextField = "BATCHNAME"
            'LSTBatch.DataValueField = "BATCHSLNO"
            'LSTBatch.DataBind()
            'LSTBatch.SelectedIndex = 0
            'LSTSelBatch.Items.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillSubBatch()

        Try
            'Dim I As Integer

            ''COURSES
            'If LSTSelCourse.Items.Count > 0 Then
            '    StrCourses = " AND ESR.COURSESLNO IN ("
            '    For I = 0 To LSTSelCourse.Items.Count - 1
            '        StrCourses &= Val(LSTSelCourse.Items(I).Value.ToString) & IIf(I = LSTSelCourse.Items.Count - 1, ")", ",")
            '    Next
            'End If

            ''EXAM group
            'StrGroup = Nothing
            'If lstSelGroup.Items.Count > 0 Then
            '    StrGroup = " AND ESR.GROUPSLNO IN ("
            '    For I = 0 To lstSelGroup.Items.Count - 1
            '        StrGroup &= Val(lstSelGroup.Items(I).Value.ToString) & IIf(I = lstSelGroup.Items.Count - 1, ")", ",")
            '    Next
            'Else
            '    Exit Sub
            'End If

            ''EXAM Batch
            'StrBatch = Nothing
            'If LSTSelBatch.Items.Count > 0 Then
            '    StrBatch = " AND ESR.BATCHSLNO IN ("
            '    For I = 0 To LSTSelBatch.Items.Count - 1
            '        StrBatch &= Val(LSTSelBatch.Items(I).Value.ToString) & IIf(I = LSTSelBatch.Items.Count - 1, ")", ",")
            '    Next
            'Else
            '    Exit Sub
            'End If

            ''EXAM BRANCHES
            'StrExamBranch = Nothing
            'If lstSelExamBranch.Items.Count > 0 Then
            '    StrExamBranch = " AND ESR.EXAMBRANCHSLNO IN ("
            '    For I = 0 To lstSelExamBranch.Items.Count - 1
            '        StrExamBranch &= Val(lstSelExamBranch.Items(I).Value.ToString) & IIf(I = lstSelExamBranch.Items.Count - 1, ")", ",")
            '    Next
            'End If


            'If lstSelExam.Items.Count > 0 Then
            '    StrSelExam = Nothing
            '    StrSelExam = " ESR.DEXAMSLNO IN ("
            '    For I = 0 To lstSelExam.Items.Count - 1
            '        StrSelExam &= Val(lstSelExam.Items(I).Value.ToString) & IIf(I = lstSelExam.Items.Count - 1, ")", ",")
            '    Next

            '    If drpReportType.SelectedValue = 6 Then
            '        SqlStr = "SELECT  DISTINCT ESR.SUBBATCHSLNO,ESR.SUBBATCH FROM  EXAM_SUBBATCH_MT SUB,EXAM_ESUBBATCH_MV ESR,EXAM_EXAMBRANCH BR " & _
            '                              " WHERE BR.EXAMBRANCHSLNO=ESR.EXAMBRANCHSLNO AND SUB.SUBBATCHSLNO=ESR.SUBBATCHSLNO AND " & _
            '                              StrSelExam + StrCourses + Replace(StrExamBranch, "ESR.EXAMBRANCHSLNO", "BR.EXAMREGIONSLNO") & StrGroup & StrBatch
            '    Else

            '        SqlStr = " SELECT  DISTINCT SUBBATCHSLNO,SUBBATCH FROM EXAM_ESUBBATCH_MV ESR WHERE " & _
            '               StrSelExam & StrExamBranch & StrCourses & StrGroup & StrBatch & _
            '                " ORDER BY SUBBATCHSLNO "
            '    End If

            '    ObjResult = New Utility
            '    DSet = ObjResult.GetCommDataSet(SqlStr)
            '    LstSubBatch.DataSource = DSet.Tables(0)
            '    LstSubBatch.DataTextField = "SUBBATCH"
            '    LstSubBatch.DataValueField = "SUBBATCHSLNO"
            '    LstSubBatch.DataBind()
            '    LstSubBatch.SelectedIndex = 0

            'End If



        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)
            'StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw ORAEX
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                'StartUpScript(iBtnReport.ID, " Transaction  Failed ")
                Throw ex
            End If

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)
            ' StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw OmEx
        End Try


    End Sub

    Private Sub fillPretype()
        Try
            Dim Ds1 As DataSet

            'ObjResult = New Utility

            'Ds1 = ObjResult.Parse_Fetch("SELECT PRESLNO,NAME FROM EXAM_PRETYPE_MT ORDER BY PRESLNO")
            'DrpPrvType.DataSource = Ds1
            'DrpPrvType.DataTextField = "NAME"
            'DrpPrvType.DataValueField = "PRESLNO"
            'DrpPrvType.DataBind()
            'DrpPrvType.Items.Insert(0, New ListItem("ALL", 0))

        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)
            'StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw ORAEX

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)
            'StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw OmEx

        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
            'StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw ex

        End Try
    End Sub

    Private Sub FillPreviousCourses()
        Try

            Dim I As Integer



            'SqlStr = "SELECT DISTINCT PCPC.PVCOURSESLNO , PC.NAME FROM 	T_COURSE_PREVIOUS_COURSE_MT PCPC ,T_PREVIOUS_COURSE_MT PC WHERE PCPC.PVCOURSESLNO=PC.PVCOURSESLNO AND PCPC.PRESLNO=" & DrpPrvType.SelectedValue

            'ObjResult = New Utility
            'DSet = ObjResult.GetCommDataSet(SqlStr)

            'DrpPrvCourse.DataSource = DSet.Tables(0)
            'DrpPrvCourse.DataTextField = "NAME"
            'DrpPrvCourse.DataValueField = "PVCOURSESLNO"
            'DrpPrvCourse.DataBind()
            'DrpPrvCourse.Items.Insert(0, New ListItem("ALL", 0))

        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)
            'StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw ORAEX
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                ' StartUpScript(iBtnReport.ID, " Transaction  Failed ")
                Throw ex
            End If

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)
            'StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw OmEx
        End Try

    End Sub



#End Region

#Region "User Control Events"

    Protected Sub UcMainSelection_DrpSelection_SelIndChg(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcMainSelection.DrpSelection_SelIndChg

        LblExb.Text = UcMainSelection.DrpSelection.SelectedItem.Text

    End Sub

#End Region

#End Region

End Class
