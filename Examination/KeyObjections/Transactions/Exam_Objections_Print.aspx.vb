'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : OBJECTIONS PRINT
'   AUTHOR                            : P.VENU
'   INITIAL BASELINE DATE             : 25.08.2011
'   FINAL BASELINE DATE               : 26.08.2011
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Public Class Exam_Objections_Print
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Tblresult As System.Web.UI.WebControls.Table
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpExamDate As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpExam As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " * Form Variables "

    Dim Examslno, i As Integer
    Dim SqlStr, SqlStr1, SqlStr2 As String
    Dim DsUse1, DsUse2, Dset, DSSesion As New DataSet
    Dim ObjFetchDs As Utility

#End Region

#Region " * Page Events "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Try
            If Not IsPostBack = True Then
                FillExamDate()
                ' FillExamNames()
            End If
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " * Fill Methods "

    Private Sub FillExamNames()
        Try
            Dim ObjExams As String
            SqlStr = "SELECT OBJTESTSLNO FROM OBJECTIONS_OBJECTION_MT WHERE OBJCOMACADEMICSLNO=" & Session("COMACADEMICSLNO")
            ObjFetchDs = New Utility
            Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
            If Dset.Tables(0).Rows.Count <> 0 Then
                For i As Integer = 0 To Dset.Tables(0).Rows.Count - 1
                    ObjExams += Dset.Tables(0).Rows(i).Item(0).ToString + IIf(Dset.Tables(0).Rows.Count - 1 <> i, ",", "")
                Next
                'SqlStr = "SELECT EXAMNAME||'/'||DESCRIPTION OBJEXAMNAME,DEXAMSLNO OBJTESTSLNO FROM EXAM_DFINEEXAM WHERE EXAMTYPE NOT IN('IPE') AND EXAMDATE=TO_DATE('" & DrpExamDate.SelectedItem.Value & "','DD/MM/YYYY') AND DEXAMSLNO IN(" + ObjExams + ") AND COMACADEMICSLNO=" & Session("COMACADEMICSLNO")
                'SqlStr = "SELECT EXAMNAME||'/'||DESCRIPTION OBJEXAMNAME,DEXAMSLNO OBJTESTSLNO FROM EXAM_DFINEEXAM WHERE COMBINATIONKEY IN(SELECT COMBINATIONKEY FROM EXAM_USERCOMBINATIONKEY_MT WHERE USERSLNO=" & Session("USERSLNO") & " AND COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & ") AND EXAMDATE=TO_DATE('" & DrpExamDate.SelectedItem.Value & "','DD/MM/YYYY') AND COMACADEMICSLNO=" & Session("COMACADEMICSLNO") + " ORDER BY EXAMNAME"
                SqlStr = "SELECT A.EXAMNAME || '/' || A.DESCRIPTION OBJEXAMNAME, A.DEXAMSLNO OBJTESTSLNO FROM EXAM_DFINEEXAM A,(SELECT OBJTESTSLNO,COUNT(*) FROM OBJECTIONS_OBJECTION_MT GROUP BY OBJTESTSLNO) B " & _
                         "WHERE A.COMBINATIONKEY IN (SELECT COMBINATIONKEY FROM EXAM_USERCOMBINATIONKEY_MT WHERE USERSLNO=" & Session("USERSLNO") & " AND COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & ") AND A.DEXAMSLNO = B.OBJTESTSLNO AND EXAMDATE=TO_DATE('" & DrpExamDate.SelectedItem.Value & "','DD/MM/YYYY') AND COMACADEMICSLNO=" & Session("COMACADEMICSLNO") + " ORDER BY EXAMNAME"

                ObjFetchDs = New Utility
                Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
                If Dset.Tables(0).Rows.Count <> 0 Then
                    DrpExam.DataTextField = "OBJEXAMNAME"
                    DrpExam.DataValueField = "OBJTESTSLNO"
                    DrpExam.DataSource = Dset
                    DrpExam.DataBind()
                    SqlQueryandReportForamt()
                Else
                    DrpExam.Items.Clear()
                    StartUpScript("Data", " No Exams Found..!")
                End If
            Else
                DrpExam.Items.Clear()
                StartUpScript("Data", " No Exams Found..!")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillExamDate()
        Try
            SqlStr = "SELECT DISTINCT TO_CHAR(EXAMDATE,'DD/MM/YYYY') OBJTESTDATE,EXAMDATE DT FROM EXAM_DFINEEXAM WHERE COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND EXAMDATE>=TO_DATE('" & System.DateTime.Today.AddDays(-7).ToString("dd/MM/yyyy") & "','DD/MM/YYYY') ORDER BY DT DESC"
            ObjFetchDs = New Utility
            Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
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

#End Region

#Region " * Report Format "

    Private Function AddHD1() As TableRow
        Dim HD1 As New TableRow
        Dim i As Integer

        HD1.Cells.Add(Headingstyle("S.NO", 1))
        HD1.Cells.Add(Headingstyle("QNO", 1))
        'HD1.Cells.Add(Headingstyle("GIVEN.KEY", 1))
        HD1.Cells.Add(Headingstyle("BRANCH", 1))
        HD1.Cells.Add(Headingstyle("LECT.NAME", 1))
        HD1.Cells.Add(Headingstyle("LECT.MOBILE", 1))
        HD1.Cells.Add(Headingstyle("REF.KEY", 1))
        HD1.Cells.Add(Headingstyle("REMARKS", 1))
        Return HD1

    End Function

    Private Sub ObjectionPrint()
        Try
            Dim i, j, k, uid, rowSpan, SNO As Integer
            Dim rowcolor As Integer
            Dim STRNPERCENT As Double
            Dim StrHeader, repoBackColor As String
            Dim HD As New TableRow
            Dim StrCorpColl, StrSubject1, StrResultType1 As String
            Dim HD2 As TableRow
            Dim BROW As New TableRow
            Dim Dr1(), Dr2() As DataRow
            Dim H1 As New TableRow
            Dim DvResult As DataView
            Dim DrROW() As DataRow
            Dim ColSpan As Integer = 0

            HD.Cells.Add(Headingstyle(DrpExam.SelectedItem.Text + "(" + DrpExamDate.SelectedItem.Text + ")", 8))
            Tblresult.Rows.Add(HD)


            For i = 0 To DsUse1.Tables(2).Rows.Count - 1
                HD2 = New TableRow
                Dr1 = DsUse1.Tables(0).Select("OBJSUBJECTSLNO=" & DsUse1.Tables(2).Rows(i).Item(0), "")
                ' & " AND OBJQUESTIONNO=" & DsUse1.Tables(0).Rows(i).Item(2)
                If Dr1.Length > 0 Then
                    HD2.Cells.Add(Headingstyle(Dr1(0)("SBJNAME"), 8))
                    Tblresult.Rows.Add(HD2)      '' SUBJECT HEADING     
                    Tblresult.Rows.Add(AddHD1)   '' FUNCTION FOR COLUMNS HEADING
                    ' checking the condtn for noofrows greater to dr1 length
                    For j = 0 To Dr1.Length - 1 ''Dr1.Length - 1
                        Dr2 = DsUse1.Tables(1).Select("OBJQUESTIONNO='" & Dr1(j)("QUESTIONNO") & "'", "")
                        If Dr2.Length > 0 Then
                            For k = 0 To Dr2.Length - 1
                                Dim tr As New TableRow
                                If k = 0 Then
                                    tr.Cells.Add(CenterAlignstyle(j + 1, 1, ""))
                                    tr.Cells.Add(CenterAlignstyle(Dr2(k)("OBJQUESTIONNO").ToString, 1, ""))
                                    'tr.Cells.Add(CenterAlignstyle(Dr1(j)("OBJGIVENKEY"), 1, ""))
                                Else
                                    tr.Cells.Add(Enteredstyle("", 1, ""))
                                    tr.Cells.Add(Enteredstyle("", 1, ""))
                                    'tr.Cells.Add(Enteredstyle("", 1, ""))
                                End If
                                tr.Cells.Add(LeftAlignstyle(Dr2(k)("EB").ToString, 1, ""))
                                tr.Cells.Add(LeftAlignstyle(Dr2(k)("LCTN").ToString, 1, ""))
                                tr.Cells.Add(LeftAlignstyle(Dr2(k)("LCTMB").ToString, 1, ""))
                                tr.Cells.Add(CenterAlignstyle(Dr2(k)("REFKEY").ToString, 1, ""))
                                tr.Cells.Add(LeftAlignstyle(Dr2(k)("RMRK").ToString, 1, ""))
                                Tblresult.Rows.Add(tr)
                            Next
                        End If
                    Next
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " * QueryGeneration"

    Private Sub SqlQueryandReportForamt()
        Try
            
            'SqlStr = " SELECT OBJ.OBJSUBJECTSLNO,SBJ.NAME SBJNAME, OBJ.OBJQUESTIONNO QUESTIONNO,OBJ.OQUESTIONNO, OBJGIVENKEY,  OBJ.CNT OBJCNT FROM T_SUBJECT_MT SBJ," & _
            '         " (SELECT OBJSUBJECTSLNO,OBJGIVENKEY,OBJQUESTIONNO,OQUESTIONNO,COUNT(*) CNT FROM OBJECTIONS_OBJECTION_DT WHERE " & _
            '         " OBJMTSLNO IN(SELECT OBJMTSLNO FROM OBJECTIONS_OBJECTION_MT WHERE OBJTESTSLNO=" & DrpExam.SelectedItem.Value & ") GROUP BY OBJSUBJECTSLNO, OBJGIVENKEY,OBJQUESTIONNO,OQUESTIONNO) OBJ WHERE OBJ.OBJSUBJECTSLNO = SBJ.SUBJECTSLNO ORDER BY OBJ.OQUESTIONNO"

            SqlStr = " SELECT OBJ.OBJSUBJECTSLNO,SBJ.NAME SBJNAME, OBJ.OBJQUESTIONNO QUESTIONNO,OBJ.OQUESTIONNO, OBJ.CNT OBJCNT FROM T_SUBJECT_MT SBJ," & _
                     " (SELECT OBJSUBJECTSLNO,OBJQUESTIONNO,OQUESTIONNO,COUNT(*) CNT FROM OBJECTIONS_OBJECTION_DT WHERE " & _
                     " OBJMTSLNO IN(SELECT OBJMTSLNO FROM OBJECTIONS_OBJECTION_MT WHERE OBJTESTSLNO=" & DrpExam.SelectedItem.Value & ") GROUP BY OBJSUBJECTSLNO, OBJQUESTIONNO,OQUESTIONNO) OBJ WHERE OBJ.OBJSUBJECTSLNO = SBJ.SUBJECTSLNO ORDER BY OBJ.OQUESTIONNO"


            SqlStr1 = "SELECT OBJDT.OBJSUBJECTSLNO,OBJDT.OBJQUESTIONNO,OBJDT.OQUESTIONNO,EB.EXAMBRANCHNAME EB, OBJDT.OBJLECTURER LCTN,OBJDT.OBJLECTMOBILE LCTMB, OBJDT.OBJCORRECTKEY REFKEY,OBJDT.OBJREMARKS RMRK, ROW_NUMBER () OVER (ORDER BY EB.EXAMBRANCHNAME) AS SNO " & _
                      "FROM OBJECTIONS_OBJECTION_DT OBJDT, OBJECTIONS_OBJECTION_MT OBJMT, EXAM_EXAMBRANCH EB " & _
                      "WHERE OBJMT.OBJEBSLNO = EB.EXAMBRANCHSLNO AND OBJDT.OBJMTSLNO = OBJMT.OBJMTSLNO AND OBJDT.OBJTESTSLNO = " & DrpExam.SelectedItem.Value & " ORDER BY OBJDT.OQUESTIONNO"

            SqlStr2 = "SELECT DISTINCT OBJSUBJECTSLNO FROM OBJECTIONS_OBJECTION_DT WHERE OBJTESTSLNO=" & DrpExam.SelectedItem.Value

            ObjFetchDs = New Utility
            DsUse1 = ObjFetchDs.DataSet_ThreeFetch(SqlStr, SqlStr1, SqlStr2)
            If DsUse1.Tables(0).Rows.Count <> 0 Then
                ObjectionPrint()
            Else
                StartUpScript("", " NoData Found..!")
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " * Common Methods "

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")

        Try
            If focusCtrl <> "" And strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.TxtSectionWiseReports." & focusCtrl & " == '[object]') { document.TxtSectionWiseReports." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf focusCtrl <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.TxtSectionWiseReports." & focusCtrl & " == '[object]') { document.TxtSectionWiseReports." & focusCtrl & ".focus(); } </script>")
            Else

            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " * Ibtn Events "

    'Private Sub IbtnReport_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    Try
    '        SqlQueryandReportForamt()
    '    Catch ex As Exception

    '    End Try
    'End Sub

#End Region

#Region " * DropDown Events "

    Private Sub DrpExamDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpExamDate.SelectedIndexChanged
        Try
            FillExamNames()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrpExam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpExam.SelectedIndexChanged
        Try
            SqlQueryandReportForamt()
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
