'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : Board Enrollment List(Branch Wise)
'   AUTHOR                            : I.CHANDRA
'   INITIAL BASELINE DATE             : 11-Mar-2010
'   MODIFICATIONS LOG                 : Reservations Fomrat - Chandra - 31-10-2017
'----------------------------------------------------------------------------------------------
Imports System.IO
Imports System.Threading
Imports System.Text
Imports CollegeBoardDLL

Public Class TxtBoardReportAll
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents PageY As System.Web.UI.WebControls.TextBox
    Protected WithEvents PageX As System.Web.UI.WebControls.TextBox
    Protected WithEvents iBtnReport As System.Web.UI.WebControls.ImageButton
    Protected WithEvents rdbZone As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdbDos As System.Web.UI.WebControls.RadioButton
    Protected WithEvents lblRZ As System.Web.UI.WebControls.Label
    Protected WithEvents drpRZ As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents LSTSelEBranch As System.Web.UI.WebControls.ListBox
    Protected WithEvents BtnSelEB As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelEBAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemEB As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemEBAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LSTExamBranch As System.Web.UI.WebControls.ListBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents LSTBoardDist As System.Web.UI.WebControls.ListBox
    Protected WithEvents LSTSelBoardDist As System.Web.UI.WebControls.ListBox
    Protected WithEvents BtnRemBoardDistAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemBoardDist As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelBoardDistAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelBoardDist As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LSTBoardCode As System.Web.UI.WebControls.ListBox
    Protected WithEvents BtnRemBoardCodeAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemBoardCode As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelBoardCodeAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelBoardCode As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LSTSelBoardCode As System.Web.UI.WebControls.ListBox
    Protected WithEvents LstCourse As System.Web.UI.WebControls.ListBox
    Protected WithEvents LstSelCourse As System.Web.UI.WebControls.ListBox
    Protected WithEvents BtnRemCourseAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemCourse As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelCourseAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelCourse As System.Web.UI.WebControls.ImageButton
    Protected WithEvents rdbDivision As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdbRegion As System.Web.UI.WebControls.RadioButton
    Protected WithEvents drpFormat As System.Web.UI.WebControls.DropDownList

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

    Private objReport As DoRegionZone
    Private ObjResult As Utility
    Dim SqlStr As String
    Dim SqlMed As String
    Dim DSet As New DataSet
    Dim DRW() As DataRow
    Dim DsResult As DataSet
    Private FormName As String = "Form1"
    Dim SelExamBranch As String
    Dim StrBoardCode, StrExams, StrExamBranch, StrBoardDist, StrSection, StrSubj, StrBatch, StrSelExam, StrCourse As String
    Private UserSLNo As Integer
    Dim strsqlquery As String

#End Region

#Region "Fill Methods"

    Private Sub ExamBranch_Region_Zone_Fill()
        Try
            Dim dsERZ As DataSet
            objReport = New DoRegionZone

            LSTExamBranch.Items.Clear()
            LSTSelEBranch.Items.Clear()
            drpRZ.Items.Clear()

            rdbDivision.Visible = True
            rdbRegion.Visible = True
            rdbZone.Visible = True
            rdbDos.Visible = True
            lblRZ.Visible = True
            drpRZ.Visible = True

            If rdbDivision.Checked Then   '''THIS FOR DIVISION SELECT

                dsERZ = objReport.Exam_UserWise_ExRegions(Session("USERSLNO"), Session("COMACADEMICSLNO"))
                lblRZ.Text = vbCr & vbCr & vbCr & vbCr & "Division"
                drpRZ.DataSource = dsERZ
                drpRZ.DataTextField = "NAME"
                drpRZ.DataValueField = "SLNO"
                drpRZ.DataBind()
                drpRZ.Items.Insert(0, New ListItem("All", 0))

                dsERZ = objReport.Exam_UserExRegionWise_EB(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))

            ElseIf rdbRegion.Checked Then   '''THIS FOR REGION SELECT

                dsERZ = objReport.Exam_UserWise_Regions(Session("USERSLNO"), Session("COMACADEMICSLNO"))
                lblRZ.Text = vbCr & vbCr & vbCr & vbCr & "Region"
                drpRZ.DataSource = dsERZ
                drpRZ.DataTextField = "NAME"
                drpRZ.DataValueField = "SLNO"
                drpRZ.DataBind()
                drpRZ.Items.Insert(0, New ListItem("All", 0))

                dsERZ = objReport.Exam_UserRegionWise_ExamBranch(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))

            ElseIf rdbZone.Checked Then '''THIS FOR ZONE SELECT

                dsERZ = objReport.Exam_UserWise_Zones(Session("USERSLNO"), Session("COMACADEMICSLNO"))
                lblRZ.Text = vbCr & vbCr & vbCr & vbCr & vbCr & vbCr & "Zone"
                drpRZ.DataSource = dsERZ
                drpRZ.DataTextField = "NAME"
                drpRZ.DataValueField = "SLNO"
                drpRZ.DataBind()
                drpRZ.Items.Insert(0, New ListItem("All", 0))

                dsERZ = objReport.Exam_UserZoneWise_ExamBranch(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))

            ElseIf rdbDos.Checked Then '''THIS FOR D.Os SELECT

                dsERZ = objReport.Exam_UserWise_Dos(Session("USERSLNO"), Session("COMACADEMICSLNO"))
                lblRZ.Text = vbCr & vbCr & vbCr & vbCr & vbCr & vbCr & "D.Os"
                drpRZ.DataSource = dsERZ
                drpRZ.DataTextField = "NAME"
                drpRZ.DataValueField = "SLNO"
                drpRZ.DataBind()
                drpRZ.Items.Insert(0, New ListItem("All", 0))

                dsERZ = objReport.Exam_UserDosWise_ExamBranch(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))

            End If

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillExambranch()
        Try
            Dim DsExambranch As DataSet
            objReport = New DoRegionZone

            LSTExamBranch.Items.Clear()
            LSTSelEBranch.Items.Clear()

            If rdbDivision.Checked Then
                DsExambranch = objReport.Exam_UserExRegionWise_EB(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))
            ElseIf rdbRegion.Checked Then
                DsExambranch = objReport.Exam_UserRegionWise_ExamBranch(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))
            ElseIf rdbZone.Checked Then
                DsExambranch = objReport.Exam_UserZoneWise_ExamBranch(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))
            ElseIf rdbDos.Checked Then
                DsExambranch = objReport.Exam_UserDosWise_ExamBranch(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))
            End If

            LSTExamBranch.DataSource = DsExambranch
            LSTExamBranch.DataTextField = "NAME"
            LSTExamBranch.DataValueField = "SLNO"
            LSTExamBranch.DataBind()

        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw ORAEX

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw OmEx

        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw ex
        End Try

    End Sub

    Private Sub FillCourse()
        Try
            Dim I As Integer
            Commonfunctions.ClearListBox(LstCourse)
            Commonfunctions.ClearListBox(LstSelCourse)

            StrCourse = Nothing
            StrExamBranch = Nothing

            'EXAM BRANCHES
            If LSTSelEBranch.Items.Count > 0 Then
                StrExamBranch = " AND ESR.EXAMBRANCHSLNO IN ("
                For I = 0 To LSTSelEBranch.Items.Count - 1
                    StrExamBranch &= Val(LSTSelEBranch.Items(I).Value.ToString) & IIf(I = LSTSelEBranch.Items.Count - 1, ")", ",")
                Next
            Else
                Commonfunctions.ClearListBox(LstCourse)
                Commonfunctions.ClearListBox(LSTSelEBranch)
                Exit Sub
            End If


            SqlStr = "SELECT DISTINCT ESR.COURSESLNO, COU.NAME FROM T_COURSE_MT COU,T_ADM_DT ESR WHERE COU.COURSESLNO=ESR.COURSESLNO " & _
                     "AND ESR.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & StrExamBranch & "ORDER BY ESR.COURSESLNO"

            ObjResult = New Utility
            DSet = ObjResult.GetCommDataSet(SqlStr)

            LstCourse.DataSource = DSet.Tables(0)
            LstCourse.DataTextField = "NAME"
            LstCourse.DataValueField = "COURSESLNO"
            LstCourse.DataBind()
            LstCourse.SelectedIndex = 0

        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw ORAEX

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw OmEx

        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw ex


        End Try
    End Sub

    Private Sub FillBoardCode()
        Try
            Dim I As Integer
            Commonfunctions.ClearListBox(LSTBoardCode)
            Commonfunctions.ClearListBox(LSTSelBoardCode)

            StrBoardCode = Nothing
            StrExamBranch = Nothing

            'EXAM BRANCHES
            If LSTSelEBranch.Items.Count > 0 Then
                StrExamBranch = " AND ESR.EXAMBRANCHSLNO IN ("
                For I = 0 To LSTSelEBranch.Items.Count - 1
                    StrExamBranch &= Val(LSTSelEBranch.Items(I).Value.ToString) & IIf(I = LSTSelEBranch.Items.Count - 1, ")", ",")
                Next
            Else
                Commonfunctions.ClearListBox(LSTBoardCode)
                Commonfunctions.ClearListBox(LSTSelEBranch)
                Exit Sub
            End If

            ''COURSE
            'If LstSelCourse.Items.Count > 0 Then
            '    StrCourse = " AND ADM.COURSESLNO IN ("
            '    For I = 0 To LstSelCourse.Items.Count - 1
            '        StrCourse &= Val(LstSelCourse.Items(I).Value.ToString) & IIf(I = LstSelCourse.Items.Count - 1, ")", ",")
            '    Next
            'End If

            ''BOARD CODE
            'If LSTSelBoardCode.Items.Count > 0 Then
            '    StrBoardCode = " AND ESR.BOARDCOLLEGESLNO IN ("
            '    For I = 0 To LSTSelBoardCode.Items.Count - 1
            '        StrBoardCode &= Val(LSTSelBoardCode.Items(I).Value.ToString) & IIf(I = LSTSelBoardCode.Items.Count - 1, ")", ",")
            '    Next
            'End If

            SqlStr = "SELECT DISTINCT ESR.BOARDCOLLEGESLNO,TO_CHAR(GM.CODE)||'-'||TO_CHAR(GM.NAME) NAME FROM EXAM_BOARDCOLLEGE_MT GM,EXAM_BC_EB_ACADEMIC_MT ESR WHERE GM.BOARDCOLLEGESLNO=ESR.BOARDCOLLEGESLNO  " & _
                     "AND ESR.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & StrExamBranch & "ORDER BY NAME"

            ObjResult = New Utility
            DSet = ObjResult.GetCommDataSet(SqlStr)

            LSTBoardCode.DataSource = DSet.Tables(0)
            LSTBoardCode.DataTextField = "NAME"
            LSTBoardCode.DataValueField = "BOARDCOLLEGESLNO"
            LSTBoardCode.DataBind()
            LSTBoardCode.SelectedIndex = 0

        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw ORAEX

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw OmEx

        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw ex


        End Try
    End Sub

    Private Sub FillBoardDist()
        Try
            Dim I As Integer
            Commonfunctions.ClearListBox(LSTBoardDist)
            Commonfunctions.ClearListBox(LSTSelBoardDist)
            StrExamBranch = Nothing

            'EXAM BRANCHES
            If LSTSelEBranch.Items.Count > 0 Then
                StrExamBranch = " AND EX.EXAMBRANCHSLNO IN ("
                For I = 0 To LSTSelEBranch.Items.Count - 1
                    StrExamBranch &= Val(LSTSelEBranch.Items(I).Value.ToString) & IIf(I = LSTSelEBranch.Items.Count - 1, ")", ",")
                Next
            Else
                Commonfunctions.ClearListBox(LSTBoardCode)
                Commonfunctions.ClearListBox(LSTSelEBranch)
                Exit Sub
            End If

            StrBoardCode = Nothing
            'BOARD CODE
            If LSTSelBoardCode.Items.Count > 0 Then
                StrBoardCode = " AND ESR.BOARDCOLLEGESLNO IN ("
                For I = 0 To LSTSelBoardCode.Items.Count - 1
                    StrBoardCode &= Val(LSTSelBoardCode.Items(I).Value.ToString) & IIf(I = LSTSelBoardCode.Items.Count - 1, ")", ",")
                Next
            End If

            'StrBoardDist = Nothing
            ''BOARD DIST
            'If LSTSelBoardDist.Items.Count > 0 Then
            '    StrBoardDist = " AND ESR.BOARDDISTSLNO IN ("
            '    For I = 0 To LSTSelBoardDist.Items.Count - 1
            '        StrBoardDist &= Val(LSTSelBoardDist.Items(I).Value.ToString) & IIf(I = LSTSelBoardDist.Items.Count - 1, ")", ",")
            '    Next
            'End If

            SqlStr = "SELECT DISTINCT ESR.BOARDDISTSLNO,TO_CHAR(GM.CODE)||'-'||TO_CHAR(GM.NAME) NAME FROM EXAM_BOARDDIST_MT GM,EXAM_BOARDCOLLEGE_MT ESR,EXAM_BC_EB_ACADEMIC_MT EX WHERE  " & _
                     "GM.BOARDDISTSLNO=ESR.BOARDDISTSLNO AND EX.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & StrBoardCode + StrExamBranch & "ORDER BY NAME"

            ObjResult = New Utility
            DSet = ObjResult.GetCommDataSet(SqlStr)

            LSTBoardDist.DataSource = DSet.Tables(0)
            LSTBoardDist.DataTextField = "NAME"
            LSTBoardDist.DataValueField = "BOARDDISTSLNO"
            LSTBoardDist.DataBind()
            LSTBoardDist.SelectedIndex = 0

        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw ORAEX

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw OmEx

        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            Throw ex


        End Try
    End Sub

#End Region

#Region "ListButtonEvents"

#Region "Exam Branch"

    Private Sub BtnSelEB_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelEB.Click
        Try
            Dim i As Integer
            SelExamBranch = Nothing
            If Not LSTExamBranch.SelectedItem Is Nothing Then
                For i = 0 To LSTExamBranch.Items.Count - 1
                    If LSTExamBranch.Items(i).Selected = True Then
                        LSTSelEBranch.Items.Add(LSTExamBranch.Items(i))
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
            FillCourse()
        Catch ex As Exception
            StartUpScript(BtnSelEB.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnSelEBAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelEBAll.Click
        Try
            Dim iTotItems As Integer = LSTExamBranch.Items.Count - 1
            Dim i As Integer

            For i = 0 To iTotItems
                LSTSelEBranch.Items.Add(LSTExamBranch.Items(i))
            Next
            LSTExamBranch.Items.Clear()
            FillCourse()
        Catch ex As Exception
            StartUpScript(BtnSelEBAll.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemEB_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemEB.Click
        Try
            Dim i As Integer
            If Not LSTSelEBranch.SelectedItem Is Nothing Then
                For i = 0 To LSTSelEBranch.Items.Count - 1
                    If LSTSelEBranch.Items(i).Selected = True Then
                        LSTExamBranch.Items.Add(LSTSelEBranch.Items(i))
                    End If
                Next

                i = 0
                Do
                    If LSTSelEBranch.Items(i).Selected = True Then
                        LSTSelEBranch.Items.Remove(LSTSelEBranch.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTSelEBranch.Items.Count Then Exit Do
                Loop


            End If
            Commonfunctions.ClearListBox(LstCourse)
            Commonfunctions.ClearListBox(LstSelCourse)
            Commonfunctions.ClearListBox(LSTBoardCode)
            Commonfunctions.ClearListBox(LSTSelBoardCode)
            Commonfunctions.ClearListBox(LSTBoardDist)
            Commonfunctions.ClearListBox(LSTSelBoardDist)
            FillCourse()
        Catch ex As Exception
            StartUpScript(BtnRemEB.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemEBAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemEBAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = LSTSelEBranch.Items.Count - 1

            For i = 0 To iTotItems
                LSTExamBranch.Items.Add(LSTSelEBranch.Items(i))
            Next
            'LSTSelEBranch.Items.Clear()
            Commonfunctions.ClearListBox(LSTSelEBranch)
            Commonfunctions.ClearListBox(LstCourse)
            Commonfunctions.ClearListBox(LstSelCourse)
            Commonfunctions.ClearListBox(LSTBoardCode)
            Commonfunctions.ClearListBox(LSTSelBoardCode)
            Commonfunctions.ClearListBox(LSTBoardDist)
            Commonfunctions.ClearListBox(LSTSelBoardDist)
        Catch ex As Exception
            StartUpScript(BtnRemEBAll.ID, ex.Message)
        End Try
    End Sub

#End Region

#Region "Course"

    Private Sub BtnSelCourse_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelCourse.Click
        Try
            Dim i As Integer
            If Not LstCourse.SelectedItem Is Nothing Then
                For i = 0 To LstCourse.Items.Count - 1
                    If LstCourse.Items(i).Selected = True Then
                        LstSelCourse.Items.Add(LstCourse.Items(i))
                    End If
                Next
                i = 0
                Do
                    If LstCourse.Items(i).Selected = True Then
                        LstCourse.Items.Remove(LstCourse.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LstCourse.Items.Count Then Exit Do
                Loop
            End If
            FillBoardCode()
        Catch ex As Exception
            StartUpScript(BtnSelCourse.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnSelCourseAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelCourseAll.Click
        Try
            Dim iTotItems As Integer = LstCourse.Items.Count - 1
            Dim i As Integer

            For i = 0 To iTotItems
                LstSelCourse.Items.Add(LstCourse.Items(i))
            Next
            LstCourse.Items.Clear()
            FillBoardCode()
        Catch ex As Exception
            StartUpScript(BtnSelCourseAll.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemCourse_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemCourse.Click
        Try
            Dim i As Integer
            If Not LstSelCourse.SelectedItem Is Nothing Then
                For i = 0 To LstSelCourse.Items.Count - 1
                    If LstSelCourse.Items(i).Selected = True Then
                        LstCourse.Items.Add(LstSelCourse.Items(i))
                    End If
                Next

                i = 0
                Do
                    If LstSelCourse.Items(i).Selected = True Then
                        LstSelCourse.Items.Remove(LstSelCourse.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LstSelCourse.Items.Count Then Exit Do
                Loop

            End If

            Commonfunctions.ClearListBox(LSTBoardCode)
            Commonfunctions.ClearListBox(LSTSelBoardCode)
            FillBoardCode()
        Catch ex As Exception
            StartUpScript(BtnRemCourse.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemCourseAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemCourseAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = LstSelCourse.Items.Count - 1

            For i = 0 To iTotItems
                LstCourse.Items.Add(LstSelCourse.Items(i))
            Next
            'lstSelCourse.Items.Clear()
            Commonfunctions.ClearListBox(LstSelCourse)
            Commonfunctions.ClearListBox(LSTBoardCode)
            Commonfunctions.ClearListBox(LSTSelBoardCode)
            Commonfunctions.ClearListBox(LSTBoardDist)
            Commonfunctions.ClearListBox(LSTSelBoardDist)

        Catch ex As Exception
            StartUpScript(BtnRemCourseAll.ID, ex.Message)
        End Try
    End Sub

#End Region

#Region "Board Code"

    Private Sub BtnSelBoardCode_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelBoardCode.Click
        Try
            Dim i As Integer
            If Not LSTBoardCode.SelectedItem Is Nothing Then
                For i = 0 To LSTBoardCode.Items.Count - 1
                    If LSTBoardCode.Items(i).Selected = True Then
                        LSTSelBoardCode.Items.Add(LSTBoardCode.Items(i))
                    End If
                Next
                i = 0
                Do
                    If LSTBoardCode.Items(i).Selected = True Then
                        LSTBoardCode.Items.Remove(LSTBoardCode.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTBoardCode.Items.Count Then Exit Do
                Loop
            End If
            FillBoardDist()
        Catch ex As Exception
            StartUpScript(BtnSelBoardCode.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnSelBoardCodeAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelBoardCodeAll.Click
        Try
            Dim iTotItems As Integer = LSTBoardCode.Items.Count - 1
            Dim i As Integer

            For i = 0 To iTotItems
                LSTSelBoardCode.Items.Add(LSTBoardCode.Items(i))
            Next
            LSTBoardCode.Items.Clear()
            FillBoardDist()
        Catch ex As Exception
            StartUpScript(BtnSelBoardCodeAll.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemBoardCode_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemBoardCode.Click
        Try
            Dim i As Integer
            If Not LSTSelBoardCode.SelectedItem Is Nothing Then
                For i = 0 To LSTSelBoardCode.Items.Count - 1
                    If LSTSelBoardCode.Items(i).Selected = True Then
                        LSTBoardCode.Items.Add(LSTSelBoardCode.Items(i))
                    End If
                Next

                i = 0
                Do
                    If LSTSelBoardCode.Items(i).Selected = True Then
                        LSTSelBoardCode.Items.Remove(LSTSelBoardCode.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTSelBoardCode.Items.Count Then Exit Do
                Loop

            End If

            Commonfunctions.ClearListBox(LSTBoardDist)
            Commonfunctions.ClearListBox(LSTSelBoardDist)
            FillBoardDist()
        Catch ex As Exception
            StartUpScript(BtnRemBoardCode.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemBoardCodeAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemBoardCodeAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = LSTSelBoardCode.Items.Count - 1

            For i = 0 To iTotItems
                LSTBoardCode.Items.Add(LSTSelBoardCode.Items(i))
            Next
            'lstSelBoardCode.Items.Clear()
            Commonfunctions.ClearListBox(LSTSelBoardCode)
            Commonfunctions.ClearListBox(LSTBoardDist)
            Commonfunctions.ClearListBox(LSTSelBoardDist)

        Catch ex As Exception
            StartUpScript(BtnRemBoardCodeAll.ID, ex.Message)
        End Try
    End Sub

#End Region

#Region "Board Dist"

    Private Sub BtnSelBoardDist_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelBoardDist.Click
        Try
            Dim i As Integer
            If Not LSTBoardDist.SelectedItem Is Nothing Then
                For i = 0 To LSTBoardDist.Items.Count - 1
                    If LSTBoardDist.Items(i).Selected = True Then
                        LSTSelBoardDist.Items.Add(LSTBoardDist.Items(i))
                    End If
                Next
                i = 0
                Do
                    If LSTBoardDist.Items(i).Selected = True Then
                        LSTBoardDist.Items.Remove(LSTBoardDist.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTBoardDist.Items.Count Then Exit Do
                Loop
            End If
            'FillBatches()
        Catch ex As Exception
            StartUpScript(BtnSelBoardDist.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnSelBoardDistAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelBoardDistAll.Click
        Try
            Dim iTotItems As Integer = LSTBoardDist.Items.Count - 1
            Dim i As Integer

            For i = 0 To iTotItems
                LSTSelBoardDist.Items.Add(LSTBoardDist.Items(i))
            Next
            LSTBoardDist.Items.Clear()
            'FillBatches()
        Catch ex As Exception
            StartUpScript(BtnSelBoardDistAll.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemBoardDist_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemBoardDist.Click
        Try
            Dim i As Integer
            If Not LSTSelBoardDist.SelectedItem Is Nothing Then
                For i = 0 To LSTSelBoardDist.Items.Count - 1
                    If LSTSelBoardDist.Items(i).Selected = True Then
                        LSTBoardDist.Items.Add(LSTSelBoardDist.Items(i))
                    End If
                Next

                i = 0
                Do
                    If LSTSelBoardDist.Items(i).Selected = True Then
                        LSTSelBoardDist.Items.Remove(LSTSelBoardDist.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTSelBoardDist.Items.Count Then Exit Do
                Loop

            End If

        Catch ex As Exception
            StartUpScript(BtnRemBoardDist.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemBoardDistAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemBoardDistAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = LSTSelBoardDist.Items.Count - 1

            For i = 0 To iTotItems
                LSTBoardDist.Items.Add(LSTSelBoardDist.Items(i))
            Next
            'lstSelBoardDist.Items.Clear()
            Commonfunctions.ClearListBox(LSTSelBoardDist)

        Catch ex As Exception
            StartUpScript(BtnRemBoardDistAll.ID, ex.Message)
        End Try
    End Sub

#End Region


#End Region

#Region "Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Try
            If Session("USERID") Is Nothing OrElse Session("USERSLNO") Is Nothing Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            Else
                UserSLNo = Session("USERSLNO")
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                ButtonsHiding(Me.Page)
                ExamBranch_Region_Zone_Fill()
                FillExambranch()
                FillCourse()
                FillBoardCode()
                FillBoardDist()

            End If

        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")

        End Try

    End Sub

#End Region

#Region "Methods"

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")

        Try
            If focusCtrl <> "" And strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.Form1." & focusCtrl & " == '[object]') { document.Form1." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf focusCtrl <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.Form1." & focusCtrl & " == '[object]') { document.Form1." & focusCtrl & ".focus(); } </script>")
            Else

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function FormValidate() As Boolean

        If LSTSelEBranch.Items.Count = 0 Then
            StartUpScript("LSTSelEBranch", "Select ExamBranch")
            Return False
        ElseIf LSTSelBoardCode.Items.Count = 0 Then
            StartUpScript("LSTSelBoardCode", "Select Board Code")
            Return False
        ElseIf LSTSelBoardDist.Items.Count = 0 Then
            StartUpScript("LSTSelBoarddIST", "Select Board District")
            Return False
        End If
        Return True
    End Function
#End Region

#Region "Sql Query"
    Private Sub GetReportsDetails()
        Try
            Dim DTStudent As String
            Dim I As Integer

            Dim FilterString As String

            'EXAM BRANCHES
            If LSTSelEBranch.Items.Count > 0 Then
                FilterString &= " AND ADM.EXAMBRANCHSLNO IN ("
                For I = 0 To LSTSelEBranch.Items.Count - 1
                    FilterString &= Val(LSTSelEBranch.Items(I).Value.ToString) & IIf(I = LSTSelEBranch.Items.Count - 1, ")", ",")
                Next
            End If

            'COURSE
            If LstSelCourse.Items.Count > 0 Then
                FilterString &= " AND ADM.COURSESLNO IN ("
                For I = 0 To LstSelCourse.Items.Count - 1
                    FilterString &= Val(LstSelCourse.Items(I).Value.ToString) & IIf(I = LstSelCourse.Items.Count - 1, ")", ",")
                Next
            End If

            'BOARD CODE
            If LSTSelBoardCode.Items.Count > 0 Then
                FilterString &= " AND BC.BOARDCOLLEGESLNO IN ("
                For I = 0 To LSTSelBoardCode.Items.Count - 1
                    FilterString &= Val(LSTSelBoardCode.Items(I).Value.ToString) & IIf(I = LSTSelBoardCode.Items.Count - 1, ")", ",")
                Next
            End If

            'BOARD DISTRICT
            If LSTSelBoardDist.Items.Count > 0 Then
                FilterString &= " AND BC.BOARDDISTSLNO IN ("
                For I = 0 To LSTSelBoardDist.Items.Count - 1
                    FilterString &= Val(LSTSelBoardDist.Items(I).Value.ToString) & IIf(I = LSTSelBoardDist.Items.Count - 1, ")", ",")
                Next
            End If


            FilterString &= " AND EUA.USERSLNO=" + UserSLNo.ToString & " AND EUA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO")

            If drpFormat.SelectedValue = 1 Then
                DTStudent = " SELECT DISTINCT ADM.ADMSLNO,ADM.ADMNO,ADM.NAME||'.'||ADM.SURNAME STUDENTNAME,ADM.FATHERNAME,BRD.PRV_HTNO,ADM.GENDER,CST.CODE COMCODE, " & _
                           " ADM.EXAMBRANCHSLNO,EXAMBRANCH.EXAMBRANCHNAME||'-'||EXAMBRANCH.BRANCHSLNO EXAMBRANCHNAME,ADM.COURSESLNO,COU.NAME COURSENAME,ADM.GROUPSLNO,GRP.NAME GROUPNAME,ADM.BATCHSLNO,BRD.BOARDADMSLNO,BRD.BOARDADMNO, " & _
                           " CAT.CODE CATEGORY,ADM.MEDIUMSLNO MEDIUM,'01' ILANG,SEC.CODE IILANG,BC.CODE BOARDCODE,BC.BOARDDISTSLNO,BC.BOARDCOLLEGESLNO,BYP.CODE BYPCODE, BYP.BOARDYOPSLNO " & _
                           " FROM T_ADM_DT ADM,T_COURSE_MT COU,T_GROUP_MT GRP,EXAM_BOARDSTUDENT_DT BRD,EXAM_BOARDCASTE_MT CST,EXAM_BOARDCATEOGORY_MT CAT,EXAM_BC_EB_ACADEMIC_MT ESR,EXAM_BOARDSECLANG_MT SEC, " & _
                           " EXAM_EXAMBRANCH EXAMBRANCH,E_USER_BRANCH_ACADEMIC_MT EUA,T_BRANCH_MT BRANCH,EXAM_BOARDCOLLEGE_MT BC,EXAM_BOARDYOP_MT BYP " & _
                           " WHERE ADM.STATUS IN(1,8) AND ADM.COURSESLNO=COU.COURSESLNO AND ADM.GROUPSLNO=GRP.GROUPSLNO AND ADM.UNIQUENO(+)=BRD.UNIQUENO AND BRD.BOARDCOLLEGESLNO=BC.BOARDCOLLEGESLNO AND CST.BOARDCASTESLNO(+)=BRD.BOARDCASTESLNO AND CAT.BOARDCATEGORYSLNO(+)=BRD.BOARDCATEGORYSLNO " & _
                           " AND SEC.BOARDSECLANGSLNO(+)=BRD.BOARDSECLANGSLNO AND ADM.BRANCHSLNO = BRANCH.BRANCHSLNO AND EUA.EXAMBRANCHSLNO=EXAMBRANCH.EXAMBRANCHSLNO  AND ADM.EXAMBRANCHSLNO=EUA.EXAMBRANCHSLNO AND BC.BOARDCOLLEGESLNO=ESR.BOARDCOLLEGESLNO(+) " & _
                           " AND BRD.BOARDYOPSLNO=BYP.BOARDYOPSLNO(+) AND ADM.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & " " & FilterString & " ORDER BY ADM.ADMNO"

            ElseIf drpFormat.SelectedValue = 2 Then
                DTStudent = " SELECT DISTINCT ADM.RESSLNO,ADM.RESNO ADMNO,ADM.NAME||'.'||ADM.SURNAME STUDENTNAME,ADM.FATHERNAME,BRD.PRV_HTNO,ADM.GENDER,CST.CODE COMCODE, " & _
                           " ADM.EXAMBRANCHSLNO,EXAMBRANCH.EXAMBRANCHNAME||'-'||EXAMBRANCH.BRANCHSLNO EXAMBRANCHNAME,ADM.COURSESLNO,COU.NAME COURSENAME,ADM.GROUPSLNO,GRP.NAME GROUPNAME,ADM.BATCHSLNO,BRD.BOARDADMSLNO,BRD.BOARDADMNO, " & _
                           " CAT.CODE CATEGORY,ADM.MEDIUMSLNO MEDIUM,'01' ILANG,SEC.CODE IILANG,BC.CODE BOARDCODE,BC.BOARDDISTSLNO,BC.BOARDCOLLEGESLNO,BYP.CODE BYPCODE, BYP.BOARDYOPSLNO " & _
                           " FROM T_RES_DT ADM,T_COURSE_MT COU,T_GROUP_MT GRP,EXAM_BOARDSTUDENT_DT BRD,EXAM_BOARDCASTE_MT CST,EXAM_BOARDCATEOGORY_MT CAT,EXAM_BC_EB_ACADEMIC_MT ESR,EXAM_BOARDSECLANG_MT SEC, " & _
                           " EXAM_EXAMBRANCH EXAMBRANCH,E_USER_BRANCH_ACADEMIC_MT EUA,T_BRANCH_MT BRANCH,EXAM_BOARDCOLLEGE_MT BC,EXAM_BOARDYOP_MT BYP " & _
                           " WHERE ADM.STATUS ='N' AND ADM.COURSESLNO=COU.COURSESLNO AND ADM.GROUPSLNO=GRP.GROUPSLNO AND ADM.RESSLNO(+)=BRD.UNIQUENO AND BRD.BOARDCOLLEGESLNO=BC.BOARDCOLLEGESLNO AND CST.BOARDCASTESLNO(+)=BRD.BOARDCASTESLNO AND CAT.BOARDCATEGORYSLNO(+)=BRD.BOARDCATEGORYSLNO " & _
                           " AND SEC.BOARDSECLANGSLNO(+)=BRD.BOARDSECLANGSLNO AND ADM.RESFORBRANCHSLNO = BRANCH.BRANCHSLNO AND EUA.EXAMBRANCHSLNO=EXAMBRANCH.EXAMBRANCHSLNO  AND ADM.EXAMBRANCHSLNO=EUA.EXAMBRANCHSLNO AND BC.BOARDCOLLEGESLNO=ESR.BOARDCOLLEGESLNO(+) " & _
                           " AND BRD.BOARDYOPSLNO=BYP.BOARDYOPSLNO(+) AND BRD.ISRES=1 AND ADM.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & " " & FilterString & " ORDER BY ADM.RESNO"

            End If


            '" ORDER BY ADM.NAME||'.'||ADM.SURNAME"
            ObjResult = New Utility
            DsResult = ObjResult.DataSet_OneFetch(DTStudent)


            If Not DsResult Is Nothing Then
                If DsResult.Tables(0).Rows.Count > 0 Then
                    FormatReportstring(DsResult)
                Else
                    StartUpScript("iBtnReport.ID", "No Data Found")
                    Exit Sub
                End If

            End If


        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")



        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")

        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")


        End Try

    End Sub

#End Region

#Region "Report String"

    Private Function FormatReportstring(ByVal Ds As DataSet) As StringBuilder
        Try
            Dim strfile As New StringBuilder

            Dim strdata As New StringBuilder
            Dim srw As StreamWriter
            Dim FinalString As New StringBuilder
            Dim ireportwidth As Integer = 175
            Dim i, K, J, L, SE, E As Integer
            Dim compare As New ArrayList
            Dim count As Integer = 0
            Dim StrHead1, StrHead2, StrHead3, StrHead4 As String
            Dim Admno As String

            For i = 0 To LSTSelEBranch.Items.Count - 1
                DRW = Ds.Tables(0).Select("EXAMBRANCHSLNO='" & LSTSelEBranch.Items(i).Value.ToString & "'")
                If DRW.Length > 0 Then
                    For Z As Integer = 0 To LstSelCourse.Items.Count - 1
                        Dim DRC() As DataRow
                        DRC = Ds.Tables(0).Select("EXAMBRANCHSLNO='" & LSTSelEBranch.Items(i).Value.ToString & _
                                                        "' AND COURSESLNO='" & LstSelCourse.Items(Z).Value.ToString & "'")

                        If DRC.Length > 0 Then
                            strfile.Append(StrPadding(" <* Board Of Intermediate Education, A.P., Hyderabad * >", ireportwidth, "M") & vbCrLf)
                            'strfile.Append(StrPadding(" <* NOMINAL ROLL * >", iReportWidth, "M") & vbCrLf)



                            strfile.Append(StrPadding("Branch Name  : " & "(" & LSTSelEBranch.Items(i).Text & ")", 79, "L") & vbCrLf)

                            'Starting Heading - 1
                            StrHead1 = StrPadding("Sl.No", 6, "L")
                            StrHead1 &= StrPadding("  Admno  ", 9, "M")
                            StrHead1 &= StrPadding("Board Admno", 12, "M")
                            StrHead1 &= StrPadding("Board Code", 12, "M")
                            StrHead1 &= StrPadding("Student Name", 36, "L")
                            StrHead1 &= StrPadding("Father's Name", 34, "L")
                            StrHead1 &= StrPadding("Course", 10, "L")
                            StrHead1 &= StrPadding("Group", 8, "L")
                            StrHead1 &= StrPadding("Prv.Htno", 12, "L")
                            StrHead1 &= StrPadding("Branch ", 35, "L")
                            'StrHead1 &= vbCrLf

                            strfile.Append(PrintLines("-", ireportwidth))
                            strfile.Append(StrHead1)

                            strfile.Append(vbCrLf)
                            strfile.Append(PrintLines("-", ireportwidth))
                            For S As Integer = 0 To DRC.Length - 1

                                strfile = strfile.Append(StrPadding(S + 1, 6, "L"))
                                strfile.Append(StrPadding(DRC(S)("ADMNO").ToString, 9, "M"))
                                strfile.Append(StrPadding(DRC(S)("BOARDADMNO").ToString, 12, "M"))
                                strfile = strfile.Append(StrPadding(DRC(S)("BOARDCODE").ToString, 12, "M"))
                                strfile = strfile.Append(StrPadding(DRC(S)("STUDENTNAME").ToString, 36, "L"))
                                strfile = strfile.Append(StrPadding(DRC(S)("FATHERNAME").ToString, 34, "L"))
                                strfile = strfile.Append(StrPadding(DRC(S)("COURSENAME").ToString, 10, "L"))
                                strfile = strfile.Append(StrPadding(DRC(S)("GROUPNAME").ToString, 8, "L"))
                                strfile = strfile.Append(StrPadding(DRC(S)("PRV_HTNO").ToString, 10, "L"))
                                strfile = strfile.Append(StrPadding("", 2, "L"))
                                strfile = strfile.Append(StrPadding(DRC(S)("EXAMBRANCHNAME").ToString, 35, "L"))
                                strfile = strfile.Append(vbCrLf & PrintLines("-", ireportwidth))
                            Next
                        End If
                    Next

                    strfile.Append("")
                    strfile.Append(vbCrLf)
                End If
            Next


            If Not Directory.Exists(Server.MapPath(Request.ApplicationPath) & "/ExaminationReports") Then
                Directory.CreateDirectory(Server.MapPath(Request.ApplicationPath) & "/ExaminationReports")
            End If

            srw = File.CreateText(Server.MapPath(Request.ApplicationPath) & "/ExaminationReports/NIMSEXAMS" & Session("USERSLNO") & ".txt")

            srw.Write(strfile)
            srw.Close()


            Response.Redirect("../../../ExaminationReports/NIMSEXAMS" & Session("USERSLNO") & ".txt")

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")


        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                StartUpScript(iBtnReport.ID, " Transaction  Failed ")

            End If


        End Try

    End Function
#End Region

#Region "ImgEvents"

    Private Sub iBtnReport_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnReport.Click
        Try
            If FormValidate() Then
                GetReportsDetails()
            End If
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            End If
        End Try
    End Sub

#End Region

#Region "Selected Index Changed Events"

    Private Sub rdbDivision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDivision.CheckedChanged
        ExamBranch_Region_Zone_Fill()
        FillExambranch()
    End Sub

    Private Sub rdbRegion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbRegion.CheckedChanged
        ExamBranch_Region_Zone_Fill()
        FillExambranch()
    End Sub

    Private Sub rdbZone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbZone.CheckedChanged
        ExamBranch_Region_Zone_Fill()
        FillExambranch()
    End Sub

    Private Sub rdbDos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDos.CheckedChanged
        ExamBranch_Region_Zone_Fill()
        FillExambranch()
    End Sub

    Private Sub drpRZ_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpRZ.SelectedIndexChanged
        FillExambranch()
    End Sub

#End Region

End Class
