
Imports System.Data
Imports System.Data.OracleClient
Imports System.IO
Imports CollegeBoardDLL
Imports System.Text
Imports System.Web.UI.WebControls
Public Class MumbaiStudentMarksReport
    Inherits System.Web.UI.Page


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Variables"

    Private dsSchedule As DataSet
    Private From As String, strSQL As String

    Private objWSCombo As ClsComboBoxFilling
    Private objWSSchedule As ClsExamSchedule
    Dim objExam As New ClsDefineExam

    Private ObjResult As Utility
    Private dsReport As DataSet

    Dim UserSLNo As Long
    Dim UserName As String
    Private EXAMTYPE As String
    Private sModuleName, sProcessName As String
    Private ObjClEs As ClsExamSchedule


    Dim InDs As New DataSet

    Dim RtnStr As String
    Dim ClsMark As New ClsMarksEntry
    Private ClsUty As New Utility
    Dim ExamBraC As Integer = 0
    Dim ExamLckC As Integer = 0
    Dim x As Integer
    Dim strFile As New StringBuilder
#End Region
#Region "Methods"



    Private Sub FillExambranch()
        Try

            Dim dsExamBranch As DataSet
            objWSCombo = New ClsComboBoxFilling
            dsExamBranch = objWSCombo.USERWISEEB(UserSLNo, Session("COMACADEMICSLNO"))
            drpExamBranch.DataSource = dsExamBranch.Tables(0)
            drpExamBranch.DataTextField = "EXAMBRANCHNAME"
            drpExamBranch.DataValueField = "EXAMBRANCHSLNO"
            drpExamBranch.DataBind()

            drpExamBranch.Items.Insert(0, New ListItem("COMMAN", 9999))

            ''This For Results Upload
            drpExamBranch.DataSource = dsExamBranch.Tables(0)
            drpExamBranch.DataTextField = "EXAMBRANCHNAME"
            drpExamBranch.DataValueField = "EXAMBRANCHSLNO"
            drpExamBranch.DataBind()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")

        Try
            If focusCtrl <> "" And strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.frmExamScheduleHome." & focusCtrl & " == '[object]') { document.frmExamScheduleHome." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf focusCtrl <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.frmExamScheduleHome." & focusCtrl & " == '[object]') { document.frmExamScheduleHome." & focusCtrl & ".focus(); } </script>")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'If date is over then update the status to DATEOVER











    Private Function FormatSqlString() As String
        Try


            Dim sqlString As String

            ''sqlString = "SELECT  DISTINCT 0 DGSLNo,	ED.EXAMCATESLNO, ED.DEXAMSLNO, ED.EXAMNAME, ED.EXAMDATE, 	ED.MTSETSLNO, 	ED.QPTMTSLNO,  ED.DESCRIPTION, ED.STATUS  , ED.DESSTATUS  , " & _
            ''    " EC.EXAMCATENAME, EC.PERIODICITY, ( CASE EC.EXAMTYPESLNO WHEN 1 THEN 'Objectvie' WHEN 2 THEN 'Descriptive' END ) ExamType,  EC.EXAMLEVEL, EC.COURSESLNO, " & _
            ''    " C.NAME COURSENAME ,ST.NAME SETNAME, QPT.QPNAME QPTNAME,ED.MRKENTRYLEVEL FROM T_COURSE_MT C , T_EXAM_CATEGORY_MT EC,	EXAM_DFINEEXAM ED , EXAM_EXAMTAILORED_MASS EM, V_ACTIVE_ACADEMIC_BRANCH_MV VA ,	EXAM_QPTYPE_MT QPT, T_SET_MT ST WHERE " & _
            ''    " ED.EXAMCATESLNO = EC.EXAMCATESLNO AND	EC.COURSESLNO=C.COURSESLNO AND	ED.DEXAMSLNO=EM.DEXAMSLNO(+) AND 	EM.BRANCHSLNO = VA.BRANCHSLNO AND	ST.MTSETSLNO = ED.MTSETSLNO AND	QPT.QPTMTSLNO = ED.QPTMTSLNO"

            sqlString = "SELECT  DISTINCT 	ED.EXAMCATESLNO, ED.DEXAMSLNO, ED.EXAMNAME||'/'||DEXAMNO EXAMNAME, ED.EXAMDATE, 	ED.MTSETSLNO, 	ED.QPTMTSLNO,  ED.DESCRIPTION, ED.STATUS  , ED.DESSTATUS ,ED.LOCKSTATUS ,ED.EXAMTYPE, " & _
                " EC.EXAMCATENAME||'/'||EC.EXAMCATENO EXAMCATENAME, EC.PERIODICITY, ( CASE WHEN ED.EXAMBRANCHSLNO=9999 THEN 'Comman' ELSE 'Branch' END ) EXAMLEVEL,( CASE WHEN ED.LOCKSTATUS='OPEN' THEN 'Open' ELSE 'Locked' END ) LSTATUS,ED.LOCKSTATUS, EC.COURSESLNO, " & _
                " C.NAME COURSENAME ,ST.NAME||'/'||ST.MTSETNO SETNAME, QPT.QPNAME||'/'||QPT.QPTMTNO QPTNAME,ED.MRKENTRYLEVEL,ED.DESCRIPTION FROM T_COURSE_MT C , T_EXAM_CATEGORY_MT EC,	EXAM_DFINEEXAM ED , EXAM_QPTYPE_MT QPT, T_SET_MT ST WHERE " & _
                " ED.EXAMCATESLNO = EC.EXAMCATESLNO AND	EC.COURSESLNO=C.COURSESLNO AND	ST.MTSETSLNO = ED.MTSETSLNO AND	QPT.QPTMTSLNO = ED.QPTMTSLNO AND ED.EXAMTYPE IN ('EAMCET','AIEEE','IIT') AND ED.COMACADEMICSLNO= " & Session("COMACADEMICSLNO")


            Return sqlString

        Catch ex As Exception
            Throw ex
        End Try
    End Function



#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("USERID") Is Nothing Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then

                FillExambranches()
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                ButtonsHiding(Me.Page)

            End If

        Catch Oex As OracleException

            If Session("USERSLNO") Is Nothing Then
                OracleLogFile("USERID := " & "SRIHARI" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                 "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            Else
                OracleLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                 "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            End If

        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                If Not Session("USERSLNO") Is Nothing Then
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                     "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                End If
            End If
        End Try
    End Sub

    Protected Sub ibtnReport_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnReport.Click

        Dim SqlStr1, SqlStr2 As String
        Dim DTStudent, DTsubject, SqlStr As String
        Dim ADMSLNO As Integer
        Try
            If Not PageValidation() Then Exit Sub

            ' This Is For Tracking Report Viewers Count
            Dim strformname As String = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName
            If strformname.StartsWith("CollegeExam.") Then
                'strformname = strformname.Remove(0, 12)
            Else
                'strformname = strformname.Remove(0, 11)
            End If
            SqlStr = " SELECT ADM.ADMSLNO,ADM.ADMNO,ADM.NAME||''||ADM.SURNAME NAME,BATCH.NAME|| '/'|| CR.NAME|| ''|| GR.NAME|| '/'|| SM.SECTION|| '/'|| ADM.GENDER CODE FROM T_ADM_DT ADM,EXAM_EXAMBRANCH EB,T_COURSE_MT CR,T_GROUP_MT GR,T_BATCH_MT BATCH,T_MEDIUM_MT MT,EXAM_CGBSECTION SM  WHERE ADM.STATUS IN (1, 8)  AND ADM.ADMNO='" & txtadmno.Text & "' AND  ADM.EXAMBRANCHSLNO=" & drpExamBranch.SelectedValue & "  AND EB.EXAMBRANCHSLNO = ADM.EXAMBRANCHSLNO  AND ADM.COURSESLNO=CR.COURSESLNO AND ADM.GROUPSLNO=GR.GROUPSLNO AND ADM.BATCHSLNO = BATCH.BATCHSLNO  AND ADM.MEDIUMSLNO = MT.MEDIUMSLNO AND ADM.SECTIONSLNO = SM.SECTIONSLNO AND ADM.COMACADEMICSLNO=13 "
            ClsUty = New Utility
            dsSchedule = ClsUty.DataSet_OneFetch(SqlStr)
            If dsSchedule.Tables(0).Rows.Count > 0 Then
                ADMSLNO = dsSchedule.Tables(0).Rows(0)("ADMSLNO").ToString
                DTStudent = "  SELECT EM.SUBJECTSLNO,EM.ADMSLNO,EM.COMACADEMICSLNO,ADM.ADMSNO,SUB.NAME SUBJECTNAME,STUMAR.OBTAINSTUMARKS ,STUMAR.MAXMARKS ,STUMAR.MINMARKS,STUMAR.TRANSDATE FROM COLLEGENEW.EXAM_SUBJECT_MAP_MUMBAI EM,COLLEGENEW.T_SUBJECT_MT SUB,COLLEGENEW.T_ADM_DT ADM ,COLLEGENEW.EXAM_MARKS_MUMBAI STUMAR" & _
                            " WHERE EM.SUBJECTSLNO=SUB.SUBJECTSLNO AND ADM.ADMSLNO=EM.ADMSLNO  AND EM.SUBJECTSLNO=SUB.SUBJECTSLNO  AND EM.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & "" & _
                            " AND EM.ADMSLNO=" & ADMSLNO & " and EM.ADMSLNO=STUMAR.ADMSLNO and   EM.SUBJECTSLNO=STUMAR.SUBJECTSLNO group by EM.SUBJECTSLNO,EM.ADMSLNO,EM.COMACADEMICSLNO,ADM.ADMSNO,SUB.NAME ,STUMAR.OBTAINSTUMARKS ,STUMAR.MAXMARKS ,STUMAR.MINMARKS,STUMAR.TRANSDATE"

                DTsubject = "SELECT row_number() over (order by SUB.SUBJECTSLNO) as ID,SUB.SUBJECTSLNO,SUB.NAME SUBJECTNAME FROM COLLEGENEW.T_SUBJECT_MT SUB,COLLEGENEW.EXAM_MARKS_MUMBAI STUMAR WHERE SUB.SUBJECTSLNO=STUMAR.SUBJECTSLNO AND STUMAR.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND STUMAR.ADMSLNO=" & ADMSLNO & " group by SUB.SUBJECTSLNO,SUB.NAME  "

                DTsubject = "SELECT SUB.SUBJECTSLNO,SUB.NAME SUBJECTNAME FROM COLLEGENEW.T_SUBJECT_MT SUB,COLLEGENEW.EXAM_MARKS_MUMBAI STUMAR WHERE SUB.SUBJECTSLNO=STUMAR.SUBJECTSLNO AND STUMAR.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND STUMAR.ADMSLNO=" & ADMSLNO & " group by SUB.SUBJECTSLNO,SUB.NAME  "

                ObjResult = New Utility
                dsReport = ObjResult.DataSet_TwoFetch(DTStudent, DTsubject)



                If dsReport.Tables(0).Rows.Count > 0 Then

                    StudentrankReportFormatHTML()

                    tblHide.Visible = False
                    'Dim FielName As String
                    'FielName = CompanyName & Session("USERSLNO") & ".TXT"
                    'Dim srw As StreamWriter

                    'If Not Directory.Exists(Server.MapPath(Request.ApplicationPath) & "/ExaminationReports") Then
                    '    Directory.CreateDirectory(Server.MapPath(Request.ApplicationPath) & "/ExaminationReports")
                    'End If

                    'srw = File.CreateText(Server.MapPath(Request.ApplicationPath) & "/ExaminationReports/NIMSEXAMS" & Session("USERSLNO") & ".txt")

                    'srw.Write(strFile)
                    'srw.Close()


                    'Response.Redirect("../../../ExaminationReports/NIMSEXAMS" & Session("USERSLNO") & ".txt")
                    'Response.Redirect("../AttendanceNewReports\" & FielName)
                Else
                    StartUpScript(ibtnReport.ID, "No Records found.")
                End If
            End If

        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
            If Session("USERSLNO") Is Nothing Then
                OracleLogFile("USERID := " & "SRIHARI" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                 "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            Else
                OracleLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                 "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            End If

        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                If Not Session("USERSLNO") Is Nothing Then
                    StartUpScript("", GeneralErrorMessage(ex.Message))
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                     "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                End If
            End If
        End Try




    End Sub

    Private Sub FillExambranches()
        Try
            Dim dsExamBranch As DataSet

            objWSCombo = New ClsComboBoxFilling
            dsExamBranch = objWSCombo.TCUSERWISEEBAP(Session("USERSLNO"), Session("COMACADEMICSLNO"))
            drpExamBranch.DataSource = dsExamBranch.Tables(0)
            drpExamBranch.DataTextField = "EXAMBRANCHNAME"
            drpExamBranch.DataValueField = "EXAMBRANCHSLNO"
            drpExamBranch.DataBind()

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Function PageValidation() As Boolean


        If drpExamBranch.SelectedValue = 1 Then
            StartUpScript(drpExamBranch.ID, "Select ExamBranch.")

            Return False
        ElseIf Trim(txtadmno.Text) = "" Then
            StartUpScript(txtadmno.ID, "ENTER ADMNO")
            Return False
        End If

        Return True

    End Function

    Private Function StudentrankReportFormatHTML()
        Try
            Dim i, j, k, m, n As Integer
            Dim iReportWidth As Integer = 112
            Dim strTitle As String = ""
            Dim strHeading As String = ""
            Dim StrCampus As String = ""
            Dim EXBACTSTR, EXBHOLSTR, EXBWRKSTR, EXBPRESTR, EXBABSSTR As Double
            Dim TOTACTSTR, TOTHOLSTR, TOTWRKSTR, TOTPRESTR, TOTABSSTR As Double
            Dim S_ACTSTR, S_HOLSTR, S_WRKSTR, S_PRESTR, S_ABSSTR As Double
            Dim S_MAXMARKS, S_OBMARKS, PER As Double


            Dim TRow1 As New TableRow
            Dim TRow2 As New TableRow
            Dim TRow3 As New TableRow
            Dim TRow4 As New TableRow
            Dim TRow5 As New TableRow
            Dim TRow6 As New TableRow
            Dim Img As New Image

            Dim Img_Tc As New TableCell
            Dim Img_Tc1 As New TableCell
            Img.ImageUrl = "../../../Images/tcimage.png"
            Img.Height = "50"
            Img.Width = "50"
            Img_Tc.RowSpan = 6
            Img_Tc.HorizontalAlign = HorizontalAlign.Center
            Img_Tc.VerticalAlign = VerticalAlign.Top
            Img_Tc.Controls.Add(Img)
            TRow1 = New TableRow
            TRow1.Cells.Add(Img_Tc)
            TRow1.Cells.Add(DataCenterAlignstyleHlink("SMT SHYAMPATIDEVI MISHURA EDUCATIONAL TRUST ", "", "black", 2, "black", "Times New Roman", "True", 10, 10, "", ""))
            TRow2.Cells.Add(DataCenterAlignstyleHlink("SHRI G.P.M DEGREE COLLEGE OF SCIENCE&COMMERCE ", "", "RED", 2, "RED", "Times New Roman", "True", 30, 16, "", ""))
            TRow3.Cells.Add(DataCenterAlignstyleHlink("DEGREE COLLEGE : AFFLIATED TO UNIVERSITY OF MUMBAI. ", "", "black", 2, "black", "Times New Roman", "True", 25, 16, "", ""))
            TRow4.Cells.Add(DataCenterAlignstyleHlink("Junior College:State Board of Secondary & High Secondary Education,Pune. ", "", "black", 2, "black", "Times New Roman", "True", 25, 16, "", ""))

            TRow5.Cells.Add(DataCenterAlignstyleHlink("RAJARSHI SHAHU MAHARAJ ROAD ,BMC SCHOOL BLOG,TELLI GALLI,ANDHERI(E),MUMBAI-400049 ", "", "black", 2, "black", "Times New Roman", "True", 15, 15, "", ""))

            TRow6.Cells.Add(DataCenterAlignstyleHlink("STATEMENT OF AVG MARKS", "", "black", 2, "black", "Times New Roman", "false", 20, 20, "", ""))
          
            ReportDataTable.Rows.Add(TRow1)
            ReportDataTable.Rows.Add(TRow2)
            ReportDataTable.Rows.Add(TRow3)
            ReportDataTable.Rows.Add(TRow4)

            ReportDataTable.Rows.Add(TRow5)
            ReportDataTable.Rows.Add(TRow6)
            Dim TR1 As New TableRow
            TR1.Cells.Add(DataleftAlignstyleHlink("", "", "black", 6, "black", "Times New Roman", "false", 30, 30, "", ""))
            ReportDataTable.Rows.Add(TR1)
            Dim TRow7, TRow8 As New TableRow
            If dsReport.Tables(0).Rows.Count > 0 Then
                TRow7.Cells.Add(DataleftAlignstyleHlink("FIRST YEAR JUNIOR COLLGE:SCIENCE", "", "black", 0, "black", "Times New Roman", "false", 0, 15, "", ""))
                ReportDataTable.Rows.Add(TRow7)
                TRow8.Cells.Add(DataleftAlignstyleHlink("STUDENT'S NAME:TRIVEDI SAMARTH SURYASH", "", "black", 0, "black", "Times New Roman", "false", 5, 10, "", ""))
                TRow8.Cells.Add(DataleftAlignstyleHlink("DIV:C", "", "black", 0, "black", "Times New Roman", "false", 5, 10, "", ""))
                TRow8.Cells.Add(DataleftAlignstyleHlink("ROLLNO:3", "", "black", 0, "black", "Times New Roman", "false", 5, 10, "", ""))
                TRow8.Cells.Add(DataleftAlignstyleHlink("GRNO:13189", "", "black", 0, "black", "Times New Roman", "false", 5, 10, "", ""))
                TRow8.Cells.Add(DataRightAlignstyleHlink("STUDENT CODE:13473", "", "black", 0, "black", "Times New Roman", "false", 5, 10, "", ""))

                ReportDataTable.Rows.Add(TRow8)



           
                If dsReport.Tables(1).Rows.Count > 0 Then
                    For i = 0 To dsReport.Tables(1).Rows.Count - 1
                        Dim TRow9 As New TableRow
                        If i = 0 Then
                            TRow9.Cells.Add(DataRightAlignstyleHlink("HEADS OF PASSING", "", "black", 0, "black", "Times New Roman", "false", 10, 10, "", "", dsReport.Tables(1).Rows.Count))
                        End If
                        TRow9.Cells.Add(DataleftAlignstyleHlink(i + 1, "", "black", 0, "black", "Times New Roman", "false", 2, 10, "", ""))
                        TRow9.Cells.Add(DataleftAlignstyleHlink(dsReport.Tables(1).Rows(i)("SUBJECTNAME"), "", "black", 0, "black", "Times New Roman", "false", 2, 10, "", ""))

                        ReportDataTable.Rows.Add(TRow9)

                    Next
                End If

                Dim TRow10 As New TableRow
                TRow10.Cells.Add(DataRightAlignstyleHlink("SUBJECT CODE", 3, "black", 0, "black", "Times New Roman", "false", 10, 10, "", ""))
                For i = 0 To dsReport.Tables(1).Rows.Count - 1
                    TRow10.Cells.Add(DataleftAlignstyleHlink(i + 1, "", "black", 0, "black", "Times New Roman", "false", 2, 10, "", ""))

                Next
                TRow10.Cells.Add(DataRightAlignstyleHlink("GRAND TOTAL", "", "black", 0, "black", "Times New Roman", "false", 10, 10, "", ""))
                TRow10.Cells.Add(DataRightAlignstyleHlink("PERC%", "", "black", 0, "black", "Times New Roman", "false", 10, 10, "", ""))

                ReportDataTable.Rows.Add(TRow10)
                Dim TRow11 As New TableRow

                TRow11.Cells.Add(DataRightAlignstyleHlink("MAXIMUM MARKS", 3, "black", 0, "black", "Times New Roman", "false", 10, 10, "", ""))
                Dim Dr1() As DataRow
                For i = 0 To dsReport.Tables(1).Rows.Count - 1
                    Dr1 = dsReport.Tables(0).Select("SUBJECTSLNO=" & dsReport.Tables(1).Rows(i)("SUBJECTSLNO"))

                    TRow11.Cells.Add(DataleftAlignstyleHlink(Dr1(0)("MAXMARKS"), "", "black", 0, "black", "Times New Roman", "false", 2, 10, "", ""))

                Next
                S_MAXMARKS = dsReport.Tables(0).Compute("SUM(MAXMARKS)", "ADMSNO=" & dsReport.Tables(0).Rows(k)("ADMSNO"))
                TRow11.Cells.Add(DataleftAlignstyleHlink(S_MAXMARKS, "", "black", 0, "black", "Times New Roman", "false", 2, 10, "", "", 2))

                S_OBMARKS = dsReport.Tables(0).Compute("SUM(MINMARKS)", "ADMSNO=" & dsReport.Tables(0).Rows(k)("ADMSNO"))
                PER = (S_OBMARKS * 100) / S_MAXMARKS
                TRow11.Cells.Add(DataCenterAlignstyleHlink(Math.Round(PER, 2), "", "black", 0, "black", "Times New Roman", "True", 2, 10, "", "", 2))

                ReportDataTable.Rows.Add(TRow11)

                Dim TRow12 As New TableRow
                TRow12.Cells.Add(DataRightAlignstyleHlink("MINMARKS", 3, "black", 0, "black", "Times New Roman", "false", 10, 10, "", ""))
                Dim Dr2() As DataRow
                For j = 0 To dsReport.Tables(1).Rows.Count - 1
                    Dr2 = dsReport.Tables(0).Select("SUBJECTSLNO=" & dsReport.Tables(1).Rows(j)("SUBJECTSLNO"))
                    TRow12.Cells.Add(DataleftAlignstyleHlink(Dr2(0)("MINMARKS"), "", "black", 0, "black", "Times New Roman", "false", 2, 10, "", ""))
                   
                Next
                ' S_WRKSTR = dsReport.Tables(0).Compute("SUM(MINMARKS)", "ADMSNO=" & dsReport.Tables(0).Rows(k)("ADMSNO"))
                'TRow12.Cells.Add(DataleftAlignstyleHlink(S_WRKSTR, "", "black", 0, "black", "Times New Roman", "false", 2, 10, "", ""))
                'PER = (S_PRESTR * 100) / S_WRKSTR
                'TRow12.Cells.Add(DataCenterAlignstyleHlink(PER, "", "black", 0, "black", "Times New Roman", "True", 2, 10, "", ""))
                ReportDataTable.Rows.Add(TRow12)

                Dim TRow13 As New TableRow

                TRow13.Cells.Add(DataRightAlignstyleHlink("MARKS Obtained", 3, "black", 0, "black", "Times New Roman", "false", 10, 10, "", ""))
                Dim Dr3() As DataRow
                For k = 0 To dsReport.Tables(1).Rows.Count - 1
                    Dr3 = dsReport.Tables(0).Select("SUBJECTSLNO=" & dsReport.Tables(1).Rows(k)("SUBJECTSLNO"))
                    TRow13.Cells.Add(DataleftAlignstyleHlink(Dr1(0)("OBTAINSTUMARKS"), "", "black", 0, "black", "Times New Roman", "false", 2, 10, "", ""))
                  
                Next

                TRow13.Cells.Add(DataRightAlignstyleHlink(S_OBMARKS, "", "black", 0, "black", "Times New Roman", "false", 2, 10, "", ""))
                TRow13.Cells.Add(DataRightAlignstyleHlink("RESULTS PASSED PROMOTED TO 12th STD", "", "black", 0, "black", "Times New Roman", "false", 2, 10, "", ""))
                ReportDataTable.Rows.Add(TRow13)
                Dim TRSP As New TableRow
                TRSP.Cells.Add(DataRightAlignstyleHlink("", "", "black", 3, "black", "Times New Roman", "false", 30, 10, "", ""))
                Dim TRow14 As New TableRow
                TRow14.Cells.Add(DataRightAlignstyleHlink("PHYSICAL EDUCATION :B", "", "black", 0, "black", "Times New Roman", "false", 15, 10, "", ""))
                ReportDataTable.Rows.Add(TRow14)
                Dim TRSP1 As New TableRow
                TRSP1.Cells.Add(DataRightAlignstyleHlink("", "", "black", 0, "black", "Times New Roman", "false", 30, 10, "", ""))
                ReportDataTable.Rows.Add(TRSP1)
                Dim TRow15 As New TableRow
                TRow15.Cells.Add(DataRightAlignstyleHlink("Date:04/04/2019", "", "black", 0, "black", "Times New Roman", "true", 5, 10, "", ""))
                ' TRow15.Cells.Add(DataRightAlignstyleHlink(dsReport.Tables(0).Rows(0)("TRANSDATE").ToString, "", "black", 0, "black", "Times New Roman", "true", 15, 10, "", "", 3))

                TRow15.Cells.Add(DataRightAlignstyleHlink("Checked By", "", "black", 0, "black", "Times New Roman", "true", 15, 10, "", ""))
                TRow15.Cells.Add(DataRightAlignstyleHlink("Class Teacher", "", "black", 0, "black", "Times New Roman", "true", 15, 10, "", ""))
                TRow15.Cells.Add(DataRightAlignstyleHlink("Principal", "", "black", 0, "black", "Times New Roman", "true", 15, 10, "", ""))
                'TRow20.Cells.Add(EnteredstyleLeft("05/05/2019", 1, ""))
                ReportDataTable.Rows.Add(TRow15)
                Dim TRow16 As New TableRow
                TRow16.Cells.Add(DataRightAlignstyleHlink("F-HEAD OF FAILURE+MARKS CARRIED  E-EXEMPTION IN THE HEAD-NOT APPLICABALE AB-ABSENT", "", "black", 3, "black", "Times New Roman", "true", 15, 10, "", ""))
                ReportDataTable.Rows.Add(TRow16)
                Dim TRSP2 As New TableRow
                TRSP2.Cells.Add(DataRightAlignstyleHlink("", "", "black", 0, "black", "Times New Roman", "false", 30, 10, "", ""))
                Dim TRow17 As New TableRow
                TRow17.Cells.Add(DataRightAlignstyleHlink("No Change in this Statement of  marks shall be made except by  authority issuing it,Anyinfrigement of this requirement will result in ", "", "black", 3, "black", "Times New Roman", "true", 30, 10, "", ""))
                ReportDataTable.Rows.Add(TRow17)
                Dim TRow18 As New TableRow
                TRow18.Cells.Add(DataRightAlignstyleHlink("Cancellation of the statement in question and may also involve imposition of the appropraite penalty as may be declared by the college ", "", "black", 3, "black", "Times New Roman", "true", 30, 10, "", ""))
                ReportDataTable.Rows.Add(TRow18)
            End If





        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class