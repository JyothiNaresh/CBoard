Imports System.Web.Services.Protocols
Imports CollegeBoardDLL
Imports System.IO
Imports System.Text
Imports System.Math
Public Class ExamInfoSelection
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label21 As System.Web.UI.WebControls.Label
    Protected WithEvents drpExamBranch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label37 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpCrExam As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label22 As System.Web.UI.WebControls.Label
    Protected WithEvents cboCombiantion As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label24 As System.Web.UI.WebControls.Label
    Protected WithEvents Label25 As System.Web.UI.WebControls.Label
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    Protected WithEvents LSTPeriodicity As System.Web.UI.WebControls.ListBox
    Protected WithEvents BtnPeriodicity As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnPeriodicityAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemPeriodicity As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemPeriodicityAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LSTSelPeriodicity As System.Web.UI.WebControls.ListBox
    Protected WithEvents lstExam As System.Web.UI.WebControls.ListBox
    Protected WithEvents BtnExam As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnExamAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemExam As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lstSelExam As System.Web.UI.WebControls.ListBox
    Protected WithEvents LSTCourse As System.Web.UI.WebControls.ListBox
    Protected WithEvents BtnSelCourse As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelCourseAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemCourse As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemCourseAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LSTSelCourse As System.Web.UI.WebControls.ListBox
    Protected WithEvents lblERZ As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents LSTExamBranch As System.Web.UI.WebControls.ListBox
    Protected WithEvents BtnSelEB As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelEBAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemEB As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemEBAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lstSelExamBranch As System.Web.UI.WebControls.ListBox
    Protected WithEvents LSTGroup As System.Web.UI.WebControls.ListBox
    Protected WithEvents BtnSelGroup As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelGroupAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemGroup As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemGroupAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lstSelGroup As System.Web.UI.WebControls.ListBox
    Protected WithEvents LSTBatch As System.Web.UI.WebControls.ListBox
    Protected WithEvents BtnSelBatch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelBatchAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemBatch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemBatchAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LSTSelBatch As System.Web.UI.WebControls.ListBox
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents Label18 As System.Web.UI.WebControls.Label
    Protected WithEvents Label26 As System.Web.UI.WebControls.Label
    Protected WithEvents Label27 As System.Web.UI.WebControls.Label
    Protected WithEvents Label30 As System.Web.UI.WebControls.Label
    Protected WithEvents Label40 As System.Web.UI.WebControls.Label
    Protected WithEvents LSTSubject As System.Web.UI.WebControls.ListBox
    Protected WithEvents BtnSelsubject As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelsubjectAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemsubject As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemsubjectAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LSTSelSubjects As System.Web.UI.WebControls.ListBox
    Protected WithEvents LstTrack As System.Web.UI.WebControls.ListBox
    Protected WithEvents BtnSelTrack As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelTrackAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemTrack As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemTackAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LstSelTrack As System.Web.UI.WebControls.ListBox
    Protected WithEvents LSTCaste As System.Web.UI.WebControls.ListBox
    Protected WithEvents BtnSelCaste As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelCasteAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemCaste As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemCasteAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LSTSelCaste As System.Web.UI.WebControls.ListBox
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents drpStuType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents drpMedium As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents drpGender As System.Web.UI.WebControls.DropDownList
    Protected WithEvents RdbFailWithAbs As System.Web.UI.WebControls.RadioButton
    Protected WithEvents RdbFailWithOutAbs As System.Web.UI.WebControls.RadioButton
    Protected WithEvents Label23 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpPreCourseMedium As System.Web.UI.WebControls.DropDownList
    Protected WithEvents datagrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents TabStrip1 As Microsoft.Web.UI.WebControls.TabStrip
    Protected WithEvents FileterSel As Microsoft.Web.UI.WebControls.MultiPage
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid

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

    Private ObjResult As Utility
    Private SqlStr As String
    Private DSet As DataSet
    Private USERSLNO As Integer
    Dim DrpSRptVal, DrpSRzval, RdbSbtn As Integer

    Dim StrSelExam As String
    Dim StrCourses, StrExamBranch, StrGroup, StrSection, StrSubj, StrSubjwhere, StrBatch, StrSubBatch, StrPrecourse, StrTracks As String
    Dim StrCoursesh, StrGrouph, StrSubjh, StrBatchh, StrTracksh, StrExamsh As String
    Dim drpvrtpval As Integer

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IsPostBack Then
                FillCourseExam()
                FillExamLevel()
                FillExamNames()
                FillPeriodicity()
                FillCaste()
                FillMedium()
                'datatable()
            End If
            datatable()
        Catch ex As Exception

        End Try

        USERSLNO = Session("USERSLNO")

        ' FillExamLevel()
        'FillExamNames()
        'FillPeriodicity()
        'FillStuType()
        'FillSponsor()
        'ExamBranch_Region_Zone_Fill()
        'FillSubSections()
    End Sub

#Region "Common Methods"
#End Region

#Region "Fill Methods"

    Private Sub FillCourseExam()
        Try

            SqlStr = "SELECT DISTINCT CREXSLNO,COURSEEXAM FROM EXAM_CREXAM_MT ORDER BY COURSEEXAM "

            ObjResult = New Utility

            DSet = ObjResult.GetCommDataSet(SqlStr)

            DrpCrExam.DataTextField = "COURSEEXAM"
            DrpCrExam.DataValueField = "CREXSLNO"
            DrpCrExam.DataSource = DSet.Tables(0)
            DrpCrExam.DataBind()

            DrpCrExam.Items.Insert(0, New ListItem("ALL", "ALL"))


        Catch ex As Exception


        End Try

    End Sub

    Private Sub FillExamLevel()
        Try

            Dim dsExamBranch As DataSet
            ObjResult = New Utility
            dsExamBranch = ObjResult.USERWISEEB(USERSLNO, Session("COMACADEMICSLNO"))
            drpExamBranch.DataSource = dsExamBranch.Tables(0)
            drpExamBranch.DataTextField = "EXAMBRANCHNAME"
            drpExamBranch.DataValueField = "EXAMBRANCHSLNO"
            drpExamBranch.DataBind()

            drpExamBranch.Items.Insert(0, New ListItem("COMMON", 9999))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillPeriodicity()
        Try
            SqlStr = "SELECT DISTINCT PERIODICITY SLNO,PERIODICITY NAME FROM T_EXAM_CATEGORY_MT "
            ObjResult = New Utility

            DSet = ObjResult.GetCommDataSet(SqlStr)

            LSTPeriodicity.DataTextField = "NAME"
            LSTPeriodicity.DataValueField = "SLNO"
            LSTPeriodicity.DataSource = DSet.Tables(0)
            LSTPeriodicity.DataBind()
            
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillExamNames()
        Try
            

            Dim ds As DataSet
            'SqlStr = " SELECT DISTINCT EXAM.SLNO,EXAM.EXAMNAME FROM EXAM_EXAMNAME EXAM,EXAM_DFINEEXAM DE WHERE " & _
            '         " EXAM.EXAMNAME=DE.EXAMNAME AND DE.EXAMTYPE IN('IPE') ORDER BY EXAMNAME"

            If DrpCrExam.SelectedValue <> "ALL" Then
                SqlStr = " SELECT  DISTINCT E.SLNO,E.EXAMNAME FROM EXAM_EXAMNAME E,EXAM_DFINEEXAM D,EXAM_USERCOMBINATIONKEY_MT UC WHERE E.EXAMNAME=D.EXAMNAME  AND D.EXAMTYPE IN('IPE') AND " & _
                     " E.SLNO=UC.COMBINATIONKEY AND  UC.USERSLNO=" & Session("USERSLNO") & " AND UC.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & _
                     " AND E.CREXSLNO=" & DrpCrExam.SelectedValue.ToString & " AND UC.COMBINATIONKEY IN (" & Session("COMBINATIONKEY") & ") ORDER BY E.EXAMNAME"

            Else
                SqlStr = " SELECT  DISTINCT E.SLNO,E.EXAMNAME FROM EXAM_EXAMNAME E,EXAM_DFINEEXAM D,EXAM_USERCOMBINATIONKEY_MT UC WHERE E.EXAMNAME=D.EXAMNAME  AND D.EXAMTYPE IN('IPE') AND " & _
                     " E.SLNO=UC.COMBINATIONKEY AND  UC.USERSLNO=" & Session("USERSLNO") & " AND UC.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & _
                     " AND UC.COMBINATIONKEY IN (" & Session("COMBINATIONKEY") & ") ORDER BY E.EXAMNAME"

            End If
   

            ObjResult = New Utility
            ds = ObjResult.GetCommDataSet(SqlStr)

            cboCombiantion.DataSource = ds
            cboCombiantion.DataTextField = "EXAMNAME"
            cboCombiantion.DataValueField = "SLNO"
            cboCombiantion.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub datatable()
        Dim crnum As Integer
        Dim crstrng As String

        Dim Dumdt As DataTable
        Dumdt = New DataTable("Crtable")
        Dim row1 As DataRow

        Try
            Dim sno As DataColumn = New DataColumn("Sno")
            sno.DataType = System.Type.GetType("System.String")
            Dumdt.Columns.Add(sno)
            Dim description As DataColumn = New DataColumn("Description")
            description.DataType = System.Type.GetType("System.String")
            Dumdt.Columns.Add(description)
            Dim selectioninfo As DataColumn = New DataColumn("selectioninfo")
            Dumdt.Columns.Add(selectioninfo)
            row1 = Dumdt.NewRow
            row1.Item("Sno") = "1"
            row1.Item("Description") = "Course"
            row1.Item("Selectioninfo") = DrpCrExam.SelectedItem.Text
            'DrpCrExam.SelectedValue()
            'DrpCrExam.Items(DrpCrExam.SelectedValue)
            Dumdt.Rows.Add(row1)
            Dim ds As New DataSet
            ds = New DataSet
            ds.Tables.Add(Dumdt)
            DataGrid2.DataSource = ds.Tables(0)
            DataGrid2.DataBind()
        Catch ex As Exception

        End Try
        

    End Sub

    Private Sub FillCourses()
        Try

            Dim I As Integer

            StrSelExam = Nothing

            If lstSelExam.Items.Count > 0 Then

                StrSelExam = " DEXAMSLNO IN ("

                For I = 0 To lstSelExam.Items.Count - 1
                    StrSelExam &= Val(lstSelExam.Items(I).Value.ToString) & IIf(I = lstSelExam.Items.Count - 1, ")", ",")
                Next

            End If


            'SqlStr = "SELECT DISTINCT CM.COURSESLNO,CM.NAME FROM T_COURSE_MT CM,EXAM_EXAMTAILORED_MASS ESR,T_ADM_DT ADM " & _
            '         " WHERE ADM.STATUS IN(1,8) AND ADM.ADMSLNO=ESR.ADMSLNO AND CM.COURSESLNO=ADM.COURSESLNO " & _
            '           StrSelExam & " ORDER BY COURSESLNO"

            SqlStr = "SELECT DISTINCT COURSESLNO,COURSENAME  FROM EXAM_ECGB_MV " & _
                    " WHERE " & StrSelExam & " ORDER BY COURSESLNO"


            ObjResult = New Utility
            DSet = ObjResult.GetCommDataSet(SqlStr)

            LSTCourse.DataTextField = "COURSENAME"
            LSTCourse.DataValueField = "COURSESLNO"
            LSTCourse.DataSource = DSet.Tables(0)
            LSTCourse.DataBind()

            LSTSelCourse.Items.Clear()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillSubjects()
        Dim I As Integer
        Try

            StrSelExam = Nothing
            Commonfunctions.ClearListBox(LSTSubject)
            Commonfunctions.ClearListBox(LSTSelSubjects)

            If lstSelExam.Items.Count > 0 Then

                StrSelExam = " AND ESR.DEXAMSLNO IN ("

                For I = 0 To lstSelExam.Items.Count - 1
                    StrSelExam &= Val(lstSelExam.Items(I).Value.ToString) & IIf(I = lstSelExam.Items.Count - 1, ")", ",")
                Next

            End If

            'SqlStr = " SELECT DISTINCT ESR.SUBJECTSLNO,SUBJ.NAME FROM EXAM_SUBJECTRANKS ESR,T_SUBJECT_MT SUBJ " & _
            '                                 " WHERE SUBJ.SUBJECTSLNO=ESR.SUBJECTSLNO AND  ESR.DEXAMSLNO= " + CStr(lstExam.SelectedValue)
            SqlStr = " SELECT DISTINCT ESR.SUBJECTSLNO,SUBJ.NAME,SUBJ.REPORTORDER FROM EXAM_QPTTAILOR ESR,T_SUBJECT_MT SUBJ " & _
                                             " WHERE SUBJ.SUBJECTSLNO=ESR.SUBJECTSLNO " + StrSelExam & " ORDER BY SUBJ.REPORTORDER "
            ObjResult = New Utility

            DSet = ObjResult.GetCommDataSet(SqlStr)

            LSTSubject.DataSource = DSet.Tables(0)
            LSTSubject.DataTextField = "NAME"
            LSTSubject.DataValueField = "SUBJECTSLNO"

            LSTSubject.DataBind()

            LSTSelSubjects.Items.Clear()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillExamsANDSubjects()
        Try
            Dim I As Integer

            Dim PERIODICITY As String

            StrCourses = " "

            If LSTSelPeriodicity.Items.Count > 0 Then
                PERIODICITY = " AND EC.PERIODICITY IN ("

                For I = 0 To LSTSelPeriodicity.Items.Count - 1
                    PERIODICITY &= ("'" & LSTSelPeriodicity.Items(I).Text) & "'" & IIf(I = LSTSelPeriodicity.Items.Count - 1, ")", ",")
                Next
            Else
                Commonfunctions.ClearListBox(lstExam)
                Commonfunctions.ClearListBox(lstSelExam)
                Exit Sub
            End If




            'DE.EXAMNAME||'/'||DE.DEXAMNO
            SqlStr = "SELECT DISTINCT DE.DEXAMSLNO,DE.DEXAMNO||'('||TO_CHAR(DE.EXAMDATE,'DD/MM/YYYY') ||')' EXAMNAME,DE.EXAMDATE FROM EXAM_DFINEEXAM DE,T_EXAM_CATEGORY_MT EC " & _
                     " WHERE  DE.EXAMCATESLNO = EC.EXAMCATESLNO AND DE.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND DE.EXAMTYPE IN ('IPE')  " & _
                      PERIODICITY + " AND DE.EXAMNAME='" & Trim(cboCombiantion.SelectedItem.Text) + "'  ORDER BY DE.EXAMDATE "

            ObjResult = New Utility
            DSet = ObjResult.GetCommDataSet(SqlStr)

            lstExam.DataSource = DSet.Tables(0)
            lstExam.DataTextField = "EXAMNAME"
            lstExam.DataValueField = "DEXAMSLNO"
            lstExam.DataBind()
            lstExam.SelectedIndex = 0

            lstSelExam.Items.Clear()

            'If lstExam.SelectedValue <> "" And Not lstExam.SelectedValue Is Nothing Then
            'FillSubjects()
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillExambranch()

        Try
            If lstSelExam.SelectedValue = "" Or lstSelExam.SelectedValue Is Nothing Then
                'StartUpScript(lstExam.ID, " Select Exam ")
                Exit Sub
            End If

            Dim I As Integer

            StrCourses = " "

            If LSTSelCourse.Items.Count > 0 Then

                StrCourses = "  AND EB.COURSESLNO IN ("

                For I = 0 To LSTSelCourse.Items.Count - 1
                    StrCourses &= Val(LSTSelCourse.Items(I).Value.ToString) & IIf(I = LSTSelCourse.Items.Count - 1, ")", ",")
                Next

            End If
            'EXAM BRANCHES
            StrExamBranch = Nothing
            If lstSelExam.Items.Count > 0 Then

                StrExamBranch = " AND EB.DEXAMSLNO IN ("

                For I = 0 To lstSelExam.Items.Count - 1
                    StrExamBranch &= Val(lstSelExam.Items(I).Value.ToString) & IIf(I = lstSelExam.Items.Count - 1, ")", ",")
                Next

            End If

            'SqlStr = " SELECT  DISTINCT ADM.EXAMBRANCHSLNO,EB.EXAMBRANCHNAME FROM EXAM_EXAMBRANCH EB,EXAM_EXAMTAILORED_MASS ESR,T_ADM_DT ADM ,EXAM_DFINEEXAM DE, " & _
            '            " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & USERSLNO & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
            '            " AND DE.DEXAMSLNO=ESR.DEXAMSLNO AND DE.EXAMBRANCHSLNO=" & drpExamBranch.SelectedValue & _
            '            " AND ADM.STATUS IN(1,8) AND ADM.ADMSLNO = ESR.ADMSLNO AND EB.EXAMBRANCHSLNO = ADM.EXAMBRANCHSLNO  " + StrExamBranch + StrCourses + " ORDER BY EB.EXAMBRANCHNAME"

            DrpSRptVal = Session("DrpRptval")
            DrpSRzval = Session("DrpRzval")

            If DrpSRptVal = 0 OrElse DrpSRptVal = 1 Then ''Exam Branch Wise 
                RdbSbtn = Session("Rdbbtn")
                'If rdbRegion.Checked Then
                If RdbSbtn = 1 Then
                    SqlStr = " SELECT  DISTINCT EB.EXAMBRANCHSLNO,EB.EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE,T_BRANCH_MT BRA,T_REGION_MT RM ," & _
                            " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & USERSLNO & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                            " AND BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.REGIONSLNO=BRA.REGIONSLNO AND DE.DEXAMSLNO=EB.DEXAMSLNO AND DE.EXAMBRANCHSLNO=" & drpExamBranch.SelectedValue & _
                            " AND RM.REGIONSLNO=" & DrpSRzval.ToString & _
                              StrExamBranch & StrCourses + " ORDER BY EXAMBRANCHNAME"

                    'ElseIf rdbZone.Checked Then
                ElseIf RdbSbtn = 2 Then
                    SqlStr = " SELECT  DISTINCT EB.EXAMBRANCHSLNO,EB.EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE,T_BRANCH_MT BRA,T_ZONE_MT RM ," & _
                           " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & USERSLNO & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                            " AND BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.ZONESLNO=BRA.ZONESLNO AND DE.DEXAMSLNO=EB.DEXAMSLNO AND DE.EXAMBRANCHSLNO=" & drpExamBranch.SelectedValue & _
                            " AND RM.ZONESLNO=" & DrpSRzval.ToString & _
                             StrExamBranch & StrCourses & " ORDER BY EXAMBRANCHNAME"
                ElseIf RdbSbtn = 3 Then
                    'ElseIf rdbDos.Checked Then
                    SqlStr = " SELECT  DISTINCT EB.EXAMBRANCHSLNO,EB.EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE,T_BRANCH_MT BRA,T_DO_MT RM ," & _
                            " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & USERSLNO & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                            " AND BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.DOSLNO=BRA.DOSLNO AND DE.DEXAMSLNO=EB.DEXAMSLNO AND DE.EXAMBRANCHSLNO=" & drpExamBranch.SelectedValue & _
                             " AND RM.DOSLNO=" & DrpSRzval.ToString & _
                             StrExamBranch + StrCourses + " ORDER BY EXAMBRANCHNAME"

                End If

                If DrpSRzval = 0 Then
                    SqlStr = " SELECT  DISTINCT EB.EXAMBRANCHSLNO,EB.EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE," & _
                             " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & USERSLNO & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                             " AND DE.DEXAMSLNO=EB.DEXAMSLNO AND DE.EXAMBRANCHSLNO=" & drpExamBranch.SelectedValue & _
                             StrExamBranch + StrCourses + " ORDER BY EB.EXAMBRANCHNAME"
                End If


            ElseIf DrpSRptVal = 2 Then ''Region Wise 
                lblERZ.Text = "Region"
                SqlStr = " SELECT  DISTINCT RM.REGIONSLNO EXAMBRANCHSLNO,RM.NAME EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE,T_BRANCH_MT BRA,T_REGION_MT RM ," & _
                         " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & USERSLNO & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                         " AND BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.REGIONSLNO=BRA.REGIONSLNO AND DE.DEXAMSLNO=EB.DEXAMSLNO AND DE.EXAMBRANCHSLNO=" & drpExamBranch.SelectedValue & _
                         StrExamBranch + StrCourses + " ORDER BY EXAMBRANCHNAME"

            ElseIf DrpSRptVal = 3 Then ''Zone Wise 
                lblERZ.Text = "Zone"
                SqlStr = " SELECT  DISTINCT RM.ZONESLNO EXAMBRANCHSLNO,RM.NAME EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE,T_BRANCH_MT BRA,T_ZONE_MT RM ," & _
                         " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & USERSLNO & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                         " AND BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.ZONESLNO=BRA.ZONESLNO AND DE.DEXAMSLNO=EB.DEXAMSLNO AND DE.EXAMBRANCHSLNO=" & drpExamBranch.SelectedValue & _
                         StrExamBranch + StrCourses + " ORDER BY EXAMBRANCHNAME"

            ElseIf DrpSRptVal = 4 Then ''D.O's Wise 
                lblERZ.Text = "D.O"
                SqlStr = " SELECT  DISTINCT RM.DOSLNO EXAMBRANCHSLNO,RM.NAME EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE,T_BRANCH_MT BRA,T_DO_MT RM ," & _
                         " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & USERSLNO & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                         " AND BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.DOSLNO=BRA.DOSLNO AND DE.DEXAMSLNO=EB.DEXAMSLNO AND DE.EXAMBRANCHSLNO=" & drpExamBranch.SelectedValue & _
                          StrExamBranch + StrCourses + " ORDER BY EXAMBRANCHNAME"
            End If

            ObjResult = New Utility
            DSet = ObjResult.GetCommDataSet(SqlStr)

            LSTExamBranch.DataSource = DSet.Tables(0)
            LSTExamBranch.DataTextField = "EXAMBRANCHNAME"
            LSTExamBranch.DataValueField = "EXAMBRANCHSLNO"
            LSTExamBranch.DataBind()
            LSTExamBranch.SelectedIndex = 0

            lstSelExamBranch.Items.Clear()
            'Filling Exam Subjects
            If lstExam.SelectedValue <> "" And Not lstExam.SelectedValue Is Nothing Then
                FillSubjects()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Fillgroup()
        Try
            Dim I As Integer

            StrCourses = Nothing

            'COURSES
            If LSTSelCourse.Items.Count > 0 Then
                StrCourses = " AND EB.COURSESLNO IN ("
                For I = 0 To LSTSelCourse.Items.Count - 1
                    StrCourses &= Val(LSTSelCourse.Items(I).Value.ToString) & IIf(I = LSTSelCourse.Items.Count - 1, ")", ",")
                Next
            End If

            'EXAM BRANCHES
            StrExamBranch = Nothing
            'If lstSelExamBranch.Items.Count > 0 Then
            '    StrExamBranch = " AND EXAMBRANCHSLNO IN ("
            '    For I = 0 To lstSelExamBranch.Items.Count - 1
            '        StrExamBranch &= Val(lstSelExamBranch.Items(I).Value.ToString) & IIf(I = lstSelExamBranch.Items.Count - 1, ")", ",")
            '    Next
            'Else
            '    Commonfunctions.ClearListBox(LSTGroup)
            '    Commonfunctions.ClearListBox(lstSelExamBranch)
            '    Exit Sub
            'End If
            DrpSRptVal = Session("DrpRptval")


            If lstSelExamBranch.Items.Count > 0 Then

                If DrpSRptVal = 0 OrElse DrpSRptVal = 1 OrElse DrpSRptVal = 5 Then '''FOR EXAMBRANCH
                    StrExamBranch &= "  EB.EXAMBRANCHSLNO IN ("
                ElseIf DrpSRptVal = 2 Then '''FOR REGION
                    StrExamBranch &= "  BRA.REGIONSLNO IN ("
                ElseIf DrpSRptVal = 3 Then   '''FOR ZONE
                    StrExamBranch &= "  BRA.ZONESLNO IN ("
                ElseIf DrpSRptVal = 4 Then   '''FOR DOS
                    StrExamBranch &= "  BRA.DOSLNO IN ("
                End If

                For I = 0 To lstSelExamBranch.Items.Count - 1
                    StrExamBranch &= Val(lstSelExamBranch.Items(I).Value.ToString) & IIf(I = lstSelExamBranch.Items.Count - 1, ")", ",")
                Next

            End If

            'Exams
            StrSelExam = Nothing
            If lstSelExam.Items.Count > 0 Then
                StrSelExam = " AND EB.DEXAMSLNO IN ("
                For I = 0 To lstSelExam.Items.Count - 1
                    StrSelExam &= Val(lstSelExam.Items(I).Value.ToString) & IIf(I = lstSelExam.Items.Count - 1, ")", ",")
                Next
            End If


            'SqlStr = "SELECT DISTINCT ESR.GROUPSLNO,GM.NAME FROM T_GROUP_MT GM,EXAM_SUBJECTRANKS ESR WHERE GM.GROUPSLNO=ESR.GROUPSLNO " & _
            '         StrSelExam + StrCourses + StrExamBranch

            'SqlStr = "SELECT DISTINCT GROUPSLNO,GROUPNAME FROM EXAM_ECGB_MV WHERE " & _
            '        StrSelExam + StrCourses + StrExamBranch

            If DrpSRptVal = 0 OrElse DrpSRptVal = 1 Then ''Exam Branch Wise 

                SqlStr = "SELECT DISTINCT GROUPSLNO,GROUPNAME FROM EXAM_ECGB_MV EB WHERE " & _
                         StrExamBranch & StrSelExam & StrCourses

            ElseIf DrpSRptVal = 2 Then ''Region Wise 

                SqlStr = " SELECT DISTINCT EB.GROUPSLNO,EB.GROUPNAME FROM EXAM_ECGB_MV EB,T_BRANCH_MT BRA,T_REGION_MT RM " & _
                         " WHERE  BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.REGIONSLNO=BRA.REGIONSLNO  AND " & _
                          StrExamBranch & StrSelExam & StrCourses

            ElseIf DrpSRptVal = 3 Then ''Zone Wise 

                SqlStr = " SELECT DISTINCT EB.GROUPSLNO,EB.GROUPNAME FROM EXAM_ECGB_MV EB,T_BRANCH_MT BRA,T_ZONE_MT RM " & _
                        " WHERE  BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.ZONESLNO=BRA.ZONESLNO  AND " & _
                        StrExamBranch & StrSelExam & StrCourses


            ElseIf DrpSRptVal = 4 Then ''D.O's Wise 

                SqlStr = " SELECT DISTINCT EB.GROUPSLNO,EB.GROUPNAME FROM EXAM_ECGB_MV EB,T_BRANCH_MT BRA,T_DO_MT RM " & _
                        " WHERE  BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.DOSLNO=BRA.DOSLNO AND " & _
                         StrExamBranch & StrSelExam & StrCourses
            End If


            ObjResult = New Utility
            DSet = ObjResult.GetCommDataSet(SqlStr)

            LSTGroup.DataSource = DSet.Tables(0)
            LSTGroup.DataTextField = "GROUPNAME"
            LSTGroup.DataValueField = "GROUPSLNO"
            LSTGroup.DataBind()
            LSTGroup.SelectedIndex = 0
            lstSelGroup.Items.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillBatches()
        Try
            Dim I As Integer

            StrCourses = Nothing

            'COURSES
            If LSTSelCourse.Items.Count > 0 Then
                StrCourses = " AND EB.COURSESLNO IN ("
                For I = 0 To LSTSelCourse.Items.Count - 1
                    StrCourses &= Val(LSTSelCourse.Items(I).Value.ToString) & IIf(I = LSTSelCourse.Items.Count - 1, ")", ",")
                Next
            End If

            ''EXAM BRANCHES
            'StrExamBranch = Nothing
            'If lstSelExamBranch.Items.Count > 0 Then
            '    StrExamBranch = " AND EXAMBRANCHSLNO IN ("
            '    For I = 0 To lstSelExamBranch.Items.Count - 1
            '        StrExamBranch &= Val(lstSelExamBranch.Items(I).Value.ToString) & IIf(I = lstSelExamBranch.Items.Count - 1, ")", ",")
            '    Next
            'End If

            DrpSRptVal = Session("DrpRptval")

            If lstSelExamBranch.Items.Count > 0 Then

                If DrpSRptVal = 1 OrElse DrpSRptVal = 0 OrElse DrpSRptVal = 5 Then '''FOR EXAMBRANCH
                    StrExamBranch &= "  EB.EXAMBRANCHSLNO IN ("
                ElseIf DrpSRptVal = 2 Then '''FOR REGION
                    StrExamBranch &= "  BRA.REGIONSLNO IN ("
                ElseIf DrpSRptVal = 3 Then   '''FOR ZONE
                    StrExamBranch &= "  BRA.ZONESLNO IN ("
                ElseIf DrpSRptVal = 4 Then   '''FOR DOS
                    StrExamBranch &= "  BRA.DOSLNO IN ("
                End If

                For I = 0 To lstSelExamBranch.Items.Count - 1
                    StrExamBranch &= Val(lstSelExamBranch.Items(I).Value.ToString) & IIf(I = lstSelExamBranch.Items.Count - 1, ")", ",")
                Next

            End If

            'Exams
            StrSelExam = Nothing
            If lstSelExam.Items.Count > 0 Then
                StrSelExam = " AND EB.DEXAMSLNO IN ("
                For I = 0 To lstSelExam.Items.Count - 1
                    StrSelExam &= Val(lstSelExam.Items(I).Value.ToString) & IIf(I = lstSelExam.Items.Count - 1, ")", ",")
                Next

            End If
            'SqlStr = "SELECT DISTINCT ESR.BATCHSLNO,BAT.NAME FROM T_BATCH_MT BAT,EXAM_SUBJECTRANKS ESR WHERE BAT.BATCHSLNO=ESR.BATCHSLNO " & _
            '          StrSelExam + StrCourses + StrExamBranch

            'SqlStr = "SELECT DISTINCT BATCHSLNO,BATCHNAME FROM EXAM_ECGB_MV WHERE " & _
            '          StrExamBranch & StrSelExam & StrCourses

            If DrpSRptVal = 0 OrElse DrpSRptVal = 1 Then ''Exam Branch Wise 

                SqlStr = "SELECT DISTINCT BATCHSLNO,BATCHNAME FROM EXAM_ECGB_MV EB WHERE " & _
                          StrExamBranch & StrSelExam & StrCourses

            ElseIf DrpSRptVal = 2 Then ''Region Wise 

                SqlStr = " SELECT DISTINCT BATCHSLNO,BATCHNAME FROM EXAM_ECGB_MV EB,T_BRANCH_MT BRA,T_REGION_MT RM " & _
                         " WHERE  BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.REGIONSLNO=BRA.REGIONSLNO  AND " & _
                           StrExamBranch & StrSelExam & StrCourses

            ElseIf DrpSRptVal = 3 Then ''Zone Wise 

                SqlStr = " SELECT DISTINCT BATCHSLNO,BATCHNAME FROM EXAM_ECGB_MV EB,T_BRANCH_MT BRA,T_ZONE_MT RM " & _
                        " WHERE  BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.ZONESLNO=BRA.ZONESLNO AND " & _
                         StrExamBranch & StrSelExam & StrCourses


            ElseIf DrpSRptVal = 4 Then ''D.O's Wise 

                SqlStr = " SELECT DISTINCT BATCHSLNO,BATCHNAME FROM EXAM_ECGB_MV EB,T_BRANCH_MT BRA,T_DO_MT RM " & _
                        " WHERE  BRA.BRANCHSLNO=EB.BRANCHSLNO AND RM.DOSLNO=BRA.DOSLNO  AND " & _
                         StrExamBranch & StrSelExam & StrCourses

            End If

            ObjResult = New Utility
            DSet = ObjResult.GetCommDataSet(SqlStr)

            LSTBatch.DataSource = DSet.Tables(0)
            LSTBatch.DataTextField = "BATCHNAME"
            LSTBatch.DataValueField = "BATCHSLNO"
            LSTBatch.DataBind()
            LSTBatch.SelectedIndex = 0
            LSTSelBatch.Items.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillTracks()
        Dim I As Integer
        Try

            StrSelExam = Nothing
            Commonfunctions.ClearListBox(LstTrack)
            Commonfunctions.ClearListBox(LstSelTrack)

            If lstSelExam.Items.Count > 0 Then

                StrSelExam = " AND ESR.DEXAMSLNO IN ("

                For I = 0 To lstSelExam.Items.Count - 1
                    StrSelExam &= Val(lstSelExam.Items(I).Value.ToString) & IIf(I = lstSelExam.Items.Count - 1, ")", ",")
                Next

            End If

            StrTracks = Nothing

            If LSTSelSubjects.Items.Count > 0 Then
                StrTracks = " AND ESR.SUBJECTSLNO IN ( "
                For I = 0 To LSTSelSubjects.Items.Count - 1
                    StrTracks &= Val(LSTSelSubjects.Items(I).Value.ToString) & IIf(I = LSTSelSubjects.Items.Count - 1, ")", ",")
                Next
            End If


            'SqlStr = " SELECT DISTINCT ESR.SUBJECTSLNO,SUBJ.NAME FROM EXAM_SUBJECTRANKS ESR,T_SUBJECT_MT SUBJ " & _
            '                                 " WHERE SUBJ.SUBJECTSLNO=ESR.SUBJECTSLNO AND  ESR.DEXAMSLNO= " + CStr(lstExam.SelectedValue)
            SqlStr = " SELECT DISTINCT ESR.TRACKSLNO,SUB.NAME||'/'||TR.NAME NAME,SUB.REPORTORDER FROM EXAM_QPTTAILOR ESR,T_TRACK_MT TR,T_SUBJECT_MT SUB " & _
                                             " WHERE TR.TRACKSLNO=ESR.TRACKSLNO AND ESR.SUBJECTSLNO=SUB.SUBJECTSLNO " & StrSelExam & StrTracks & " ORDER BY SUB.REPORTORDER "
            ObjResult = New Utility

            DSet = ObjResult.GetCommDataSet(SqlStr)

            LstTrack.DataSource = DSet.Tables(0)
            LstTrack.DataTextField = "NAME"
            LstTrack.DataValueField = "TRACKSLNO"

            LstTrack.DataBind()
            LstSelTrack.Items.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillCaste()
        Try
            SqlStr = "SELECT CASTESLNO,CASTENAME FROM T_CASTE_MT ORDER BY CASTENAME"

            ObjResult = New Utility
            DSet = ObjResult.GetCommDataSet(SqlStr)

            LSTCaste.DataSource = DSet.Tables(0)
            LSTCaste.DataTextField = "CASTENAME"
            LSTCaste.DataValueField = "CASTESLNO"
            LSTCaste.DataBind()


        Catch ex As Exception
            'StartUpScript(LSTCaste.ID, ex.Message)
        End Try
    End Sub

    Private Sub FillMedium()
        Try
            SqlStr = "SELECT MEDIUMSLNO,NAME FROM T_MEDIUM_MT ORDER BY NAME"

            ObjResult = New Utility
            DSet = ObjResult.GetCommDataSet(SqlStr)

            drpMedium.DataSource = DSet.Tables(0)
            drpMedium.DataTextField = "NAME"
            drpMedium.DataValueField = "MEDIUMSLNO"
            drpMedium.DataBind()

            drpMedium.Items.Insert(0, New ListItem("ALL", 0))

            'For Previous Course Medium

            DrpPreCourseMedium.DataSource = DSet.Tables(0)
            DrpPreCourseMedium.DataTextField = "NAME"
            DrpPreCourseMedium.DataValueField = "MEDIUMSLNO"
            DrpPreCourseMedium.DataBind()

            DrpPreCourseMedium.Items.Insert(0, New ListItem("ALL", 0))
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

        'Catch ex As Exception
        '    StartUpScript(drpStuType.ID, ex.Message)
        'End Try
    End Sub


#End Region

#Region "ListButton Events"

#Region "Periodicity"

    Private Sub BtnPeriodicity_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnPeriodicity.Click
        Try

            Commonfunctions.ClearListBox(LSTCourse)
            Commonfunctions.ClearListBox(LSTSelCourse)

            Commonfunctions.ClearListBox(lstSelExam)
            Commonfunctions.ClearListBox(lstExam)

            Commonfunctions.ClearListBox(LSTExamBranch)
            Commonfunctions.ClearListBox(lstSelExamBranch)

            Commonfunctions.ClearListBox(LSTGroup)
            Commonfunctions.ClearListBox(lstSelGroup)

            Commonfunctions.ClearListBox(LSTBatch)
            Commonfunctions.ClearListBox(LSTSelBatch)

            Commonfunctions.ClearListBox(LSTSubject)
            Commonfunctions.ClearListBox(LSTSelSubjects)


            Commonfunctions.FillListSel(LSTPeriodicity, LSTSelPeriodicity)
            FillExamsANDSubjects()

            'FillSubjects()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnPeriodicityAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnPeriodicityAll.Click
        Try

            Commonfunctions.ClearListBox(LSTCourse)
            Commonfunctions.ClearListBox(LSTSelCourse)

            Commonfunctions.ClearListBox(lstSelExam)
            Commonfunctions.ClearListBox(lstExam)

            Commonfunctions.ClearListBox(LSTExamBranch)
            Commonfunctions.ClearListBox(lstSelExamBranch)

            Commonfunctions.ClearListBox(LSTGroup)
            Commonfunctions.ClearListBox(lstSelGroup)

            Commonfunctions.ClearListBox(LSTBatch)
            Commonfunctions.ClearListBox(LSTSelBatch)

            Commonfunctions.ClearListBox(LSTSubject)
            Commonfunctions.ClearListBox(LSTSelSubjects)

            Commonfunctions.FillListAll(LSTPeriodicity, LSTSelPeriodicity)
            FillExamsANDSubjects()
            'FillSubjects()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRemPeriodicity_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemPeriodicity.Click
        Try

            Commonfunctions.ClearListBox(LSTCourse)
            Commonfunctions.ClearListBox(LSTSelCourse)

            Commonfunctions.ClearListBox(lstSelExam)
            Commonfunctions.ClearListBox(lstExam)

            Commonfunctions.ClearListBox(LSTExamBranch)
            Commonfunctions.ClearListBox(lstSelExamBranch)

            Commonfunctions.ClearListBox(LSTGroup)
            Commonfunctions.ClearListBox(lstSelGroup)

            Commonfunctions.ClearListBox(LSTBatch)
            Commonfunctions.ClearListBox(LSTSelBatch)

            Commonfunctions.ClearListBox(LSTSubject)
            Commonfunctions.ClearListBox(LSTSelSubjects)

            Commonfunctions.FillListSel(LSTSelPeriodicity, LSTPeriodicity)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRemPeriodicityAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemPeriodicityAll.Click
        Try

            Commonfunctions.ClearListBox(LSTCourse)
            Commonfunctions.ClearListBox(LSTSelCourse)

            Commonfunctions.ClearListBox(lstSelExam)
            Commonfunctions.ClearListBox(lstExam)

            Commonfunctions.ClearListBox(LSTExamBranch)
            Commonfunctions.ClearListBox(lstSelExamBranch)

            Commonfunctions.ClearListBox(LSTGroup)
            Commonfunctions.ClearListBox(lstSelGroup)

            Commonfunctions.ClearListBox(LSTBatch)
            Commonfunctions.ClearListBox(LSTSelBatch)

            Commonfunctions.ClearListBox(LSTSubject)
            Commonfunctions.ClearListBox(LSTSelSubjects)

            Commonfunctions.FillListAll(LSTSelPeriodicity, LSTPeriodicity)

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "EXAMS "

    Private Sub BtnExam_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnExam.Click
        If (Not lstExam.SelectedValue Is Nothing) Then
            Commonfunctions.FillListSel(lstExam, lstSelExam)
            'FillExambranch()
            FillCourses()
            FillSubjects()
        End If

    End Sub

    Private Sub BtnExamAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnExamAll.Click
        If (Not lstExam.SelectedValue Is Nothing) Then
            Commonfunctions.FillListAll(lstExam, lstSelExam)
            FillCourses()
            ' FillExambranch()
            FillSubjects()
        End If
    End Sub

    Private Sub BtnRemExam_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemExam.Click
        If (Not lstSelExam.SelectedValue Is Nothing) Then
            Commonfunctions.FillListSel(lstSelExam, lstExam)
            Commonfunctions.ClearListBox(LSTExamBranch)

            FillCourses()
            'FillExambranch()
            FillSubjects()
        End If


    End Sub

    Private Sub BtnRemAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemAll.Click
        If (Not lstSelExam.SelectedValue Is Nothing) Then
            Commonfunctions.FillListAll(lstSelExam, lstExam)

            Commonfunctions.ClearListBox(LSTCourse)
            Commonfunctions.ClearListBox(LSTSelCourse)

            Commonfunctions.ClearListBox(LSTExamBranch)
            Commonfunctions.ClearListBox(lstSelExamBranch)

            Commonfunctions.ClearListBox(LSTGroup)
            Commonfunctions.ClearListBox(lstSelGroup)

            Commonfunctions.ClearListBox(LSTBatch)
            Commonfunctions.ClearListBox(LSTSelBatch)

            Commonfunctions.ClearListBox(LSTSubject)
            Commonfunctions.ClearListBox(LSTSelSubjects)
        End If
    End Sub



#End Region

#Region "Course"

    Private Sub BtnSelCourse_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelCourse.Click
        Try
            Dim i As Integer
            If Not LSTCourse.SelectedItem Is Nothing Then
                For i = 0 To LSTCourse.Items.Count - 1
                    If LSTCourse.Items(i).Selected = True Then
                        LSTSelCourse.Items.Add(LSTCourse.Items(i))
                    End If
                Next
                i = 0
                Do
                    If LSTCourse.Items(i).Selected = True Then
                        LSTCourse.Items.Remove(LSTCourse.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTCourse.Items.Count Then Exit Do
                Loop

            End If
            'FillExamsANDSubjects()
            FillExambranch()
        Catch ex As Exception
            'StartUpScript(BtnSelCourse.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnSelCourseAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelCourseAll.Click
        Try
            Dim iTotItems As Integer = LSTCourse.Items.Count - 1
            Dim i As Integer

            For i = 0 To iTotItems
                LSTSelCourse.Items.Add(LSTCourse.Items(i))
            Next
            LSTCourse.Items.Clear()
            'FillExamsANDSubjects()
            FillExambranch()
        Catch ex As Exception
            'StartUpScript(BtnSelCourseAll.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemCourse_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemCourse.Click
        Try
            Dim i As Integer
            If Not LSTSelCourse.SelectedItem Is Nothing Then
                For i = 0 To LSTSelCourse.Items.Count - 1
                    If LSTSelCourse.Items(i).Selected = True Then
                        LSTCourse.Items.Add(LSTSelCourse.Items(i))
                    End If
                Next

                i = 0
                Do
                    If LSTSelCourse.Items(i).Selected = True Then
                        LSTSelCourse.Items.Remove(LSTSelCourse.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTSelCourse.Items.Count Then Exit Do
                Loop

                Commonfunctions.ClearListBox(lstSelExam)
                Commonfunctions.ClearListBox(lstExam)
                Commonfunctions.ClearListBox(LSTExamBranch)
                Commonfunctions.ClearListBox(lstSelExamBranch)

                Commonfunctions.ClearListBox(LSTGroup)
                Commonfunctions.ClearListBox(lstSelGroup)
                Commonfunctions.ClearListBox(LSTBatch)
                Commonfunctions.ClearListBox(LSTBatch)
                Commonfunctions.ClearListBox(LSTSelBatch)
                Commonfunctions.ClearListBox(LSTSubject)
                Commonfunctions.ClearListBox(LSTExamBranch)
                Commonfunctions.ClearListBox(LSTSelSubjects)
            End If
            ' FillExamsANDSubjects()
            FillExambranch()
        Catch ex As Exception
            ' StartUpScript(BtnRemCourse.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemCourseAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemCourseAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = LSTSelCourse.Items.Count - 1

            For i = 0 To iTotItems
                LSTCourse.Items.Add(LSTSelCourse.Items(i))
            Next
            'LSTSelCourse.Items.Clear()
            Commonfunctions.ClearListBox(LSTSelCourse)

            Commonfunctions.ClearListBox(LSTExamBranch)
            Commonfunctions.ClearListBox(lstSelExamBranch)

            Commonfunctions.ClearListBox(LSTGroup)
            Commonfunctions.ClearListBox(lstSelGroup)
            Commonfunctions.ClearListBox(LSTBatch)
            Commonfunctions.ClearListBox(LSTBatch)
            Commonfunctions.ClearListBox(LSTSelBatch)
            Commonfunctions.ClearListBox(LSTExamBranch)
            'FillExamsANDSubjects()
            FillExambranch()
        Catch ex As Exception
            ' StartUpScript(BtnRemCourse.ID, ex.Message)
        End Try
    End Sub

#End Region

#Region "Exam Branch"

    Private Sub BtnSelEB_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelEB.Click
        Try
            Dim i As Integer

            If Not LSTExamBranch.SelectedItem Is Nothing Then
                For i = 0 To LSTExamBranch.Items.Count - 1
                    If LSTExamBranch.Items(i).Selected = True Then
                        lstSelExamBranch.Items.Add(LSTExamBranch.Items(i))
                    End If
                Next
                i = 0
                Do
                    If LSTExamBranch.Items(i).Selected = True Then
                        LSTExamBranch.Items.Remove(LSTExamBranch.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTExamBranch.Items.Count Then Exit Do
                Loop

            End If
            Fillgroup()
        Catch ex As Exception
            'StartUpScript(BtnSelEB.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnSelEBAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelEBAll.Click
        Try
            Dim iTotItems As Integer = LSTExamBranch.Items.Count - 1
            Dim i As Integer

            For i = 0 To iTotItems
                lstSelExamBranch.Items.Add(LSTExamBranch.Items(i))
            Next
            LSTExamBranch.Items.Clear()
            Fillgroup()
        Catch ex As Exception
            'StartUpScript(BtnSelEBAll.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemEB_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemEB.Click
        Try
            Dim i As Integer
            If Not lstSelExamBranch.SelectedItem Is Nothing Then
                For i = 0 To lstSelExamBranch.Items.Count - 1
                    If lstSelExamBranch.Items(i).Selected = True Then
                        LSTExamBranch.Items.Add(lstSelExamBranch.Items(i))
                    End If
                Next

                i = 0
                Do
                    If lstSelExamBranch.Items(i).Selected = True Then
                        lstSelExamBranch.Items.Remove(lstSelExamBranch.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = lstSelExamBranch.Items.Count Then Exit Do
                Loop


            End If
            Commonfunctions.ClearListBox(LSTGroup)
            Commonfunctions.ClearListBox(lstSelExamBranch)
            Fillgroup()
        Catch ex As Exception
            'StartUpScript(BtnRemEB.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemEBAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemEBAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = lstSelExamBranch.Items.Count - 1

            For i = 0 To iTotItems
                LSTExamBranch.Items.Add(lstSelExamBranch.Items(i))
            Next
            'lstSelExamBranch.Items.Clear()
            Commonfunctions.ClearListBox(lstSelExamBranch)
            Commonfunctions.ClearListBox(LSTGroup)
            Commonfunctions.ClearListBox(lstSelGroup)
            Commonfunctions.ClearListBox(LSTBatch)
            Commonfunctions.ClearListBox(LSTBatch)
            Commonfunctions.ClearListBox(LSTSelBatch)
            'Commonfunctions.ClearListBox(LSTSubject)
            'Commonfunctions.ClearListBox(LSTSelSubjects)
            Fillgroup()
        Catch ex As Exception
            'StartUpScript(BtnRemEBAll.ID, ex.Message)
        End Try
    End Sub

#End Region

#Region "Group"

    Private Sub BtnSelGroup_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelGroup.Click
        Try
            Dim i As Integer
            If Not LSTGroup.SelectedItem Is Nothing Then
                For i = 0 To LSTGroup.Items.Count - 1
                    If LSTGroup.Items(i).Selected = True Then
                        lstSelGroup.Items.Add(LSTGroup.Items(i))
                    End If
                Next
                i = 0
                Do
                    If LSTGroup.Items(i).Selected = True Then
                        LSTGroup.Items.Remove(LSTGroup.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTGroup.Items.Count Then Exit Do
                Loop
            End If
            FillBatches()
        Catch ex As Exception
            'StartUpScript(BtnSelGroup.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnSelGroupAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelGroupAll.Click
        Try
            Dim iTotItems As Integer = LSTGroup.Items.Count - 1
            Dim i As Integer

            For i = 0 To iTotItems
                lstSelGroup.Items.Add(LSTGroup.Items(i))
            Next
            LSTGroup.Items.Clear()
            FillBatches()
        Catch ex As Exception
            'StartUpScript(BtnSelGroupAll.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemGroup_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemGroup.Click
        Try
            Dim i As Integer
            If Not lstSelGroup.SelectedItem Is Nothing Then
                For i = 0 To lstSelGroup.Items.Count - 1
                    If lstSelGroup.Items(i).Selected = True Then
                        LSTGroup.Items.Add(lstSelGroup.Items(i))
                    End If
                Next

                i = 0
                Do
                    If lstSelGroup.Items(i).Selected = True Then
                        lstSelGroup.Items.Remove(lstSelGroup.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = lstSelGroup.Items.Count Then Exit Do
                Loop

            End If
            Commonfunctions.ClearListBox(lstSelGroup)
            Commonfunctions.ClearListBox(LSTBatch)
            FillBatches()
        Catch ex As Exception
            'StartUpScript(BtnRemGroup.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemGroupAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemGroupAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = lstSelGroup.Items.Count - 1

            For i = 0 To iTotItems
                LSTGroup.Items.Add(lstSelGroup.Items(i))
            Next
            'lstSelGroup.Items.Clear()
            Commonfunctions.ClearListBox(LSTBatch)
            Commonfunctions.ClearListBox(lstSelGroup)
            Commonfunctions.ClearListBox(LSTSelBatch)
            FillBatches()

        Catch ex As Exception
            'StartUpScript(BtnRemGroupAll.ID, ex.Message)
        End Try
    End Sub

#End Region

#Region "Batch"

    Private Sub BtnSelBatch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelBatch.Click
        Try
            Dim i As Integer
            If Not LSTBatch.SelectedItem Is Nothing Then
                For i = 0 To LSTBatch.Items.Count - 1
                    If LSTBatch.Items(i).Selected = True Then
                        LSTSelBatch.Items.Add(LSTBatch.Items(i))
                    End If
                Next
                i = 0
                Do
                    If LSTBatch.Items(i).Selected = True Then
                        LSTBatch.Items.Remove(LSTBatch.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTBatch.Items.Count Then Exit Do
                Loop
                'Commonfunctions.ClearListBox(LstSubBatch)
                'Commonfunctions.ClearListBox(LstselSubbatch)
                'FillSubBatch()
            End If

        Catch ex As Exception
            'StartUpScript(BtnSelBatch.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnSelBatchAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelBatchAll.Click
        Try
            Dim iTotItems As Integer = LSTBatch.Items.Count - 1
            Dim i As Integer

            For i = 0 To iTotItems
                LSTSelBatch.Items.Add(LSTBatch.Items(i))
            Next
            Commonfunctions.ClearListBox(LSTBatch)
            'Commonfunctions.ClearListBox(LstSubBatch)
            'Commonfunctions.ClearListBox(LstselSubbatch)
            'FillSubBatch()
        Catch ex As Exception
            'StartUpScript(BtnSelBatchAll.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemBatch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemBatch.Click
        Try
            Dim i As Integer
            If Not LSTSelBatch.SelectedItem Is Nothing Then
                For i = 0 To LSTSelBatch.Items.Count - 1
                    If LSTSelBatch.Items(i).Selected = True Then
                        LSTBatch.Items.Add(LSTSelBatch.Items(i))
                    End If
                Next

                i = 0
                Do
                    If LSTSelBatch.Items(i).Selected = True Then
                        LSTSelBatch.Items.Remove(LSTSelBatch.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTSelBatch.Items.Count Then Exit Do
                Loop
                'Commonfunctions.ClearListBox(LstselSubbatch)
                'Commonfunctions.ClearListBox(LstSubBatch)
                'FillSubBatch()
            End If

        Catch ex As Exception
            'StartUpScript(BtnRemBatch.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemBatchAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemBatchAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = LSTSelBatch.Items.Count - 1

            For i = 0 To iTotItems
                LSTBatch.Items.Add(LSTSelBatch.Items(i))
            Next
            'LSTSelBatch.Items.Clear()
            Commonfunctions.ClearListBox(LSTSelBatch)
        Catch ex As Exception
            'StartUpScript(BtnRemBatchAll.ID, ex.Message)
        End Try

    End Sub

#End Region

#Region "Subject"

    Private Sub BtnSelsubject_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelsubject.Click
        Try
            Dim i As Integer
            If Not LSTSubject.SelectedItem Is Nothing Then
                For i = 0 To LSTSubject.Items.Count - 1
                    If LSTSubject.Items(i).Selected = True Then
                        LSTSelSubjects.Items.Add(LSTSubject.Items(i))
                    End If
                Next
                i = 0
                Do
                    If LSTSubject.Items(i).Selected = True Then
                        LSTSubject.Items.Remove(LSTSubject.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTSubject.Items.Count Then Exit Do
                Loop
                FillTracks()
            End If
        Catch ex As Exception
            'StartUpScript(BtnSelsubject.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnSelsubjectAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelsubjectAll.Click
        Try
            Dim iTotItems As Integer = LSTSubject.Items.Count - 1
            Dim i As Integer

            For i = 0 To iTotItems
                LSTSelSubjects.Items.Add(LSTSubject.Items(i))
            Next
            LSTSubject.Items.Clear()
            FillTracks()
        Catch ex As Exception
            'StartUpScript(BtnSelsubject.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemsubject_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemsubject.Click
        Try
            Dim i As Integer
            If Not LSTSelSubjects.SelectedItem Is Nothing Then
                For i = 0 To LSTSelSubjects.Items.Count - 1
                    If LSTSelSubjects.Items(i).Selected = True Then
                        LSTSubject.Items.Add(LSTSelSubjects.Items(i))
                    End If
                Next

                i = 0
                Do
                    If LSTSelSubjects.Items(i).Selected = True Then
                        LSTSelSubjects.Items.Remove(LSTSelSubjects.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTSelSubjects.Items.Count Then Exit Do
                Loop
                FillTracks()
            End If
        Catch ex As Exception
            'StartUpScript(BtnSelsubject.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemsubjectAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemsubjectAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = LSTSelSubjects.Items.Count - 1

            For i = 0 To iTotItems
                LSTSubject.Items.Add(LSTSelSubjects.Items(i))
            Next
            LSTSelSubjects.Items.Clear()
            LstSelTrack.Items.Clear()
            LstTrack.Items.Clear()

        Catch ex As Exception
            'StartUpScript(BtnSelsubject.ID, ex.Message)
        End Try
    End Sub

#End Region

#Region "Track Btn Events"

    Private Sub BtnSelTrack_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelTrack.Click
        Try
            Commonfunctions.FillListSel(LstTrack, LstSelTrack)
            'FillALLTracks()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSelTrackAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelTrackAll.Click
        Try
            Commonfunctions.FillListAll(LstTrack, LstSelTrack)
            'FillALLTracks()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnRemTrack_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemTrack.Click
        Try
            Commonfunctions.FillListSel(LstSelTrack, LstTrack)
            'FillALLTracks()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnRemTackAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemTackAll.Click
        Try
            Commonfunctions.FillListAll(LstSelTrack, LstTrack)
            ' LSTTotalTrack.Items.Clear()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Caste "

    Private Sub BtnSelCaste_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelCaste.Click
        Try
            Dim i As Integer
            If Not LSTCaste.SelectedItem Is Nothing Then
                For i = 0 To LSTCaste.Items.Count - 1
                    If LSTCaste.Items(i).Selected = True Then
                        LSTSelCaste.Items.Add(LSTCaste.Items(i))
                    End If
                Next
                i = 0
                Do
                    If LSTCaste.Items(i).Selected = True Then
                        LSTCaste.Items.Remove(LSTCaste.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTCaste.Items.Count Then Exit Do
                Loop
                'FillSubjects()
            End If
        Catch ex As Exception
            ' StartUpScript(BtnSelCaste.ID, ex.Message)

        End Try
    End Sub

    Private Sub BtnSelCasteAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelCasteAll.Click
        Try
            Dim iTotItems As Integer = LSTCaste.Items.Count - 1
            Dim i As Integer

            For i = 0 To iTotItems
                LSTSelCaste.Items.Add(LSTCaste.Items(i))
            Next
            LSTCaste.Items.Clear()
            ' FillSubjects()
        Catch ex As Exception
            'StartUpScript(BtnSelCasteAll.ID, ex.Message)

        End Try
    End Sub

    Private Sub BtnRemCaste_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemCaste.Click
        Try
            Dim i As Integer
            If Not LSTSelCaste.SelectedItem Is Nothing Then
                For i = 0 To LSTSelCaste.Items.Count - 1
                    If LSTSelCaste.Items(i).Selected = True Then
                        LSTCaste.Items.Add(LSTSelCaste.Items(i))
                    End If
                Next

                i = 0
                Do
                    If LSTSelCaste.Items(i).Selected = True Then
                        LSTSelCaste.Items.Remove(LSTSelCaste.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTSelCaste.Items.Count Then Exit Do
                Loop

                ' FillSubjects()
            End If
        Catch ex As Exception
            'StartUpScript(BtnRemCaste.ID, ex.Message)

        End Try
    End Sub

    Private Sub BtnRemCasteAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemCasteAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = LSTSelCaste.Items.Count - 1

            For i = 0 To iTotItems
                LSTCaste.Items.Add(LSTSelCaste.Items(i))
            Next
            'LSTSelCaste.Items.Clear()
            Commonfunctions.ClearListBox(LSTSelCaste)
        Catch ex As Exception
            'StartUpScript(BtnRemCasteAll.ID, ex.Message)

        End Try
    End Sub

#End Region

#End Region

#Region "Methods"

    'Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")
    '    Try
    '        If focusCtrl <> "" And strMessage <> "" Then
    '            RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & FormName & "." & focusCtrl & " == '[object]') { document." & FormName & "." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
    '        ElseIf strMessage <> "" Then
    '            RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
    '        ElseIf focusCtrl <> "" Then
    '            RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & FormName & "." & focusCtrl & " == '[object]') { document." & FormName & "." & focusCtrl & ".focus(); } </script>")
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

#End Region

#Region "Selected IndexChanged Events"
    Private Sub DrpCrExam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpCrExam.SelectedIndexChanged
        Try
            Commonfunctions.ClearListBox(LSTCourse)
            Commonfunctions.ClearListBox(LSTSelCourse)

            Commonfunctions.ClearListBox(lstSelExam)
            Commonfunctions.ClearListBox(lstExam)

            Commonfunctions.ClearListBox(LSTExamBranch)
            Commonfunctions.ClearListBox(lstSelExamBranch)

            Commonfunctions.ClearListBox(LSTGroup)
            Commonfunctions.ClearListBox(lstSelGroup)

            Commonfunctions.ClearListBox(LSTBatch)
            Commonfunctions.ClearListBox(LSTSelBatch)

            Commonfunctions.ClearListBox(LSTSubject)
            Commonfunctions.ClearListBox(LSTSelSubjects)

            Commonfunctions.ClearListBox(LstTrack)
            Commonfunctions.ClearListBox(LstSelTrack)

            Commonfunctions.FillListAll(LSTSelPeriodicity, LSTPeriodicity)

            FillExamNames()

        Catch ex As Exception

        End Try

    End Sub
#End Region

    Private Sub drpExamBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpExamBranch.SelectedIndexChanged
        Response.Write("x")
    End Sub

End Class
