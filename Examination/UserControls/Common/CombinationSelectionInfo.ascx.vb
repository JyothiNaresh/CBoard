Imports System.Data.OracleClient
Imports CollegeBoardDLL
Imports System.Web.UI.Page
Public Class CombinationSelectionInfo
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents LblCourseExam As System.Web.UI.WebControls.Label
    Protected WithEvents LblCombinationkey As System.Web.UI.WebControls.Label
    Protected WithEvents LblSelection As System.Web.UI.WebControls.Label

    Protected WithEvents NewSelection As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents ListSelection As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents DisplaySelection As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Label24 As System.Web.UI.WebControls.Label
    Protected WithEvents Label25 As System.Web.UI.WebControls.Label
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    Protected WithEvents BtnExam As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnExamAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemExam As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSubject As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSubjectAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemSubject As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemSubjectAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents TrPeriodicity As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents LstTrack As System.Web.UI.WebControls.ListBox
    Protected WithEvents LstSelTrack As System.Web.UI.WebControls.ListBox
    Protected WithEvents BtnTrack As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnTrackAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemTrack As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemTrackAll As System.Web.UI.WebControls.ImageButton

    Public WithEvents DrpCourseExam As System.Web.UI.WebControls.DropDownList
    Public WithEvents DrpCombinationKey As System.Web.UI.WebControls.DropDownList
    Public WithEvents DrpSelection As System.Web.UI.WebControls.DropDownList
    Public WithEvents LstSelSubject As System.Web.UI.WebControls.ListBox
    Public WithEvents LstSelExams As System.Web.UI.WebControls.ListBox
    Public WithEvents LstSubject As System.Web.UI.WebControls.ListBox
    Public WithEvents LstExams As System.Web.UI.WebControls.ListBox
    Public WithEvents ChkLstPeriodicity As System.Web.UI.WebControls.CheckBoxList

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

    Private ObjResult As ClsFillControls
    Dim SqlStr As String
    Dim DSet As New DataSet

#End Region

#Region "Page Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            If Not IsPostBack Then
                FillCourseExam()
                FillExamNames()
                FillPeriodicity()
            End If
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Common"


#End Region

#Region "Fill Methods"

    Private Sub FillCourseExam()
        Try

           
            SqlStr = "SELECT DISTINCT CREXSLNO,COURSEEXAM FROM EXAM_CREXAM_MT ORDER BY COURSEEXAM "

            ObjResult = New ClsFillControls

            DSet = ObjResult.GetCommDataSet(SqlStr)

            DrpCourseExam.DataTextField = "COURSEEXAM"
            DrpCourseExam.DataValueField = "CREXSLNO"
            DrpCourseExam.DataSource = DSet.Tables(0)
            DrpCourseExam.DataBind()

            DrpCourseExam.Items.Insert(0, New ListItem("ALL", "ALL"))


        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)
            Throw ORAEX
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                Throw ex
            End If

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)
            Throw OmEx
        End Try

    End Sub

    Private Sub FillPeriodicity()
        Try

            If DrpSelection.SelectedItem.Value <> 0 Then


                'SqlStr = "SELECT PERIODICITY SLNO, PERIODICITY NAME  FROM T_EXAM_CATEGORY_MT WHERE COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND  EXAMCATESLNO IN(SELECT DISTINCT EXAMCATESLNO FROM EXAM_DFINEEXAM WHERE COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & "  AND COMBINATIONKEY=" & DrpCombinationKey.SelectedItem.Value & " )"
                SqlStr = "SELECT PERIODICITY SLNO, PERIODICITY NAME  FROM T_EXAM_CATEGORY_MT WHERE COMACADEMICSLNO=7 AND  EXAMCATESLNO IN(SELECT DISTINCT EXAMCATESLNO FROM EXAM_DFINEEXAM WHERE COMACADEMICSLNO=7  AND COMBINATIONKEY=" & DrpCombinationKey.SelectedItem.Value & " )"

                ObjResult = New ClsFillControls

                DSet = ObjResult.GetCommDataSet(SqlStr)

                ChkLstPeriodicity.DataTextField = "NAME"
                ChkLstPeriodicity.DataValueField = "SLNO"
                ChkLstPeriodicity.DataSource = DSet.Tables(0)
                ChkLstPeriodicity.DataBind()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillExamNames()
        Try
            Dim ds As DataSet

            ' If DrpCourseExam.SelectedValue <> "ALL" Then
            ' SqlStr = " SELECT  DISTINCT E.SLNO,E.EXAMNAME FROM EXAM_EXAMNAME E,EXAM_DFINEEXAM D,EXAM_USERCOMBINATIONKEY_MT UC WHERE E.EXAMNAME=D.EXAMNAME  AND D.EXAMTYPE IN('IPE') AND " & _
            '   " E.SLNO=UC.COMBINATIONKEY AND  UC.USERSLNO=" & Session("USERSLNO") & " AND UC.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & _
            '   " AND E.CREXSLNO=" & DrpCourseExam.SelectedValue.ToString & " AND UC.COMBINATIONKEY IN (" & Session("COMBINATIONKEY") & ") ORDER BY E.EXAMNAME"

            ' Else
            '    SqlStr = " SELECT  DISTINCT E.SLNO,E.EXAMNAME FROM EXAM_EXAMNAME E,EXAM_DFINEEXAM D,EXAM_USERCOMBINATIONKEY_MT UC WHERE E.EXAMNAME=D.EXAMNAME  AND D.EXAMTYPE IN('IPE') AND " & _
            '    " E.SLNO=UC.COMBINATIONKEY AND  UC.USERSLNO=" & Session("USERSLNO") & " AND UC.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & _
            '    " AND UC.COMBINATIONKEY IN (" & Session("COMBINATIONKEY") & ") ORDER BY E.EXAMNAME"

            'End If

            If DrpCourseExam.SelectedValue <> "ALL" Then
                SqlStr = " SELECT  DISTINCT E.SLNO,E.EXAMNAME FROM EXAM_EXAMNAME E,EXAM_DFINEEXAM D,EXAM_USERCOMBINATIONKEY_MT UC WHERE E.EXAMNAME=D.EXAMNAME  AND D.EXAMTYPE IN('IPE') AND " & _
                  " E.SLNO=UC.COMBINATIONKEY AND  UC.USERSLNO=308  AND UC.COMACADEMICSLNO=7 " & _
                  " AND E.CREXSLNO=" & DrpCourseExam.SelectedValue.ToString & "  ORDER BY E.EXAMNAME"

            Else
                SqlStr = " SELECT  DISTINCT E.SLNO,E.EXAMNAME FROM EXAM_EXAMNAME E,EXAM_DFINEEXAM D,EXAM_USERCOMBINATIONKEY_MT UC WHERE E.EXAMNAME=D.EXAMNAME  AND D.EXAMTYPE IN('IPE') AND " & _
                " E.SLNO=UC.COMBINATIONKEY AND  UC.USERSLNO= 308  AND UC.COMACADEMICSLNO= 7 " & _
                " ORDER BY E.EXAMNAME"

            End If

            ObjResult = New ClsFillControls
            ds = ObjResult.GetCommDataSet(SqlStr)

            DrpCombinationKey.DataSource = ds
            DrpCombinationKey.DataTextField = "EXAMNAME"
            DrpCombinationKey.DataValueField = "SLNO"
            DrpCombinationKey.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillExams()
        Try
            Dim I As Integer
            Dim StrCourses As String
            Dim PERIODICITY As String

            LstSelExams.Items.Clear()
            LstExams.Items.Clear()

            StrCourses = " "

            PERIODICITY = " AND EC.PERIODICITY IN ("

            For I = 0 To ChkLstPeriodicity.Items.Count - 1
                If ChkLstPeriodicity.Items(I).Selected Then
                    PERIODICITY &= "'" & ChkLstPeriodicity.Items(I).Text & "',"
                End If
            Next
            PERIODICITY = PERIODICITY.TrimEnd(",")
            PERIODICITY = PERIODICITY + ")"

            'SqlStr = "SELECT DISTINCT DE.DEXAMSLNO,DE.DEXAMNO||'('||TO_CHAR(DE.EXAMDATE,'DD/MM/YYYY') ||')' EXAMNAME,DE.EXAMDATE FROM EXAM_DFINEEXAM DE,T_EXAM_CATEGORY_MT EC " & _
            '               " WHERE  DE.EXAMCATESLNO = EC.EXAMCATESLNO AND DE.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND DE.EXAMTYPE IN ('IPE')  " & _
            '              PERIODICITY + " AND DE.EXAMNAME='" & Trim(DrpCombinationKey.SelectedItem.Text) + "'  ORDER BY DE.EXAMDATE "


            'DE.EXAMNAME||'/'||DE.DEXAMNO
            If DrpSelection.SelectedItem.Value = 1 Then
                SqlStr = "SELECT DISTINCT DE.DEXAMSLNO,DE.DEXAMNO||'('||TO_CHAR(DE.EXAMDATE,'DD/MM/YYYY') ||')' EXAMNAME,DE.EXAMDATE FROM EXAM_DFINEEXAM DE,T_EXAM_CATEGORY_MT EC " & _
                         " WHERE  DE.EXAMCATESLNO = EC.EXAMCATESLNO AND DE.COMACADEMICSLNO=7  AND DE.EXAMTYPE IN ('IPE')  " & _
                         " AND DE.EXAMNAME='" & Trim(DrpCombinationKey.SelectedItem.Text) + "'  ORDER BY DE.EXAMDATE "

            Else
                SqlStr = "SELECT DISTINCT DE.DEXAMSLNO,DE.DEXAMNO||'('||TO_CHAR(DE.EXAMDATE,'DD/MM/YYYY') ||')' EXAMNAME,DE.EXAMDATE FROM EXAM_DFINEEXAM DE,T_EXAM_CATEGORY_MT EC " & _
                         " WHERE  DE.EXAMCATESLNO = EC.EXAMCATESLNO AND DE.COMACADEMICSLNO=7  AND DE.EXAMTYPE IN ('IPE')  " & _
                          PERIODICITY + " AND DE.EXAMNAME='" & Trim(DrpCombinationKey.SelectedItem.Text) + "'  ORDER BY DE.EXAMDATE "

            End If

            ObjResult = New ClsFillControls
            DSet = ObjResult.GetCommDataSet(SqlStr)

            LstExams.DataSource = DSet.Tables(0)
            LstExams.DataTextField = "EXAMNAME"
            LstExams.DataValueField = "DEXAMSLNO"
            LstExams.DataBind()
            LstExams.SelectedIndex = 0


        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillSubjects()
        Dim I As Integer
        Try
            Dim StrSelExam As String
            StrSelExam = Nothing
            Commonfunctions.ClearListBox(LstSubject)
            Commonfunctions.ClearListBox(LstSelSubject)

            If LstSelExams.Items.Count > 0 Then

                StrSelExam = " AND ESR.DEXAMSLNO IN ("

                For I = 0 To LstSelExams.Items.Count - 1
                    StrSelExam &= Val(LstSelExams.Items(I).Value.ToString) & IIf(I = LstSelExams.Items.Count - 1, ")", ",")
                Next

            End If

            'SqlStr = " SELECT DISTINCT ESR.SUBJECTSLNO,SUBJ.NAME FROM EXAM_SUBJECTRANKS ESR,T_SUBJECT_MT SUBJ " & _
            '                                 " WHERE SUBJ.SUBJECTSLNO=ESR.SUBJECTSLNO AND  ESR.DEXAMSLNO= " + CStr(lstExam.SelectedValue)
            SqlStr = " SELECT DISTINCT ESR.SUBJECTSLNO,SUBJ.NAME,SUBJ.REPORTORDER FROM EXAM_QPTTAILOR ESR,T_SUBJECT_MT SUBJ " & _
                                             " WHERE SUBJ.SUBJECTSLNO=ESR.SUBJECTSLNO " + StrSelExam & " ORDER BY SUBJ.REPORTORDER "
            ObjResult = New ClsFillControls

            DSet = ObjResult.GetCommDataSet(SqlStr)

            LstSubject.DataSource = DSet.Tables(0)
            LstSubject.DataTextField = "NAME"
            LstSubject.DataValueField = "SUBJECTSLNO"

            LstSubject.DataBind()

            LstSelSubject.Items.Clear()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillTracks()
        Dim I As Integer
        Try
            Dim StrSelExam, StrSubjects As String
            StrSelExam = Nothing
            Commonfunctions.ClearListBox(LstTrack)
            Commonfunctions.ClearListBox(LstSelTrack)

            If LstSelExams.Items.Count > 0 Then

                StrSelExam = " AND ESR.DEXAMSLNO IN ("

                For I = 0 To LstSelExams.Items.Count - 1
                    StrSelExam &= Val(LstSelExams.Items(I).Value.ToString) & IIf(I = LstSelExams.Items.Count - 1, ")", ",")
                Next

            End If

            StrSubjects = Nothing

            If LstSelSubject.Items.Count > 0 Then
                StrSubjects = " AND ESR.SUBJECTSLNO IN ( "
                For I = 0 To LstSelSubject.Items.Count - 1
                    StrSubjects &= Val(LstSelSubject.Items(I).Value.ToString) & IIf(I = LstSelSubject.Items.Count - 1, ")", ",")
                Next
            End If


            'SqlStr = " SELECT DISTINCT ESR.SUBJECTSLNO,SUBJ.NAME FROM EXAM_SUBJECTRANKS ESR,T_SUBJECT_MT SUBJ " & _
            '                                 " WHERE SUBJ.SUBJECTSLNO=ESR.SUBJECTSLNO AND  ESR.DEXAMSLNO= " + CStr(lstExam.SelectedValue)
            SqlStr = " SELECT DISTINCT ESR.TRACKSLNO,SUB.NAME||'/'||TR.NAME NAME,SUB.REPORTORDER FROM EXAM_QPTTAILOR ESR,T_TRACK_MT TR,T_SUBJECT_MT SUB " & _
                                             " WHERE TR.TRACKSLNO=ESR.TRACKSLNO AND ESR.SUBJECTSLNO=SUB.SUBJECTSLNO " & StrSelExam & StrSubjects & " ORDER BY SUB.REPORTORDER "
            ObjResult = New ClsFillControls

            DSet = ObjResult.GetCommDataSet(SqlStr)

            LstTrack.DataSource = DSet.Tables(0)
            LstTrack.DataTextField = "NAME"
            LstTrack.DataValueField = "TRACKSLNO"

            LstTrack.DataBind()
            LstSelTrack.Items.Clear()
        Catch ex As Exception

        End Try
    End Sub



#End Region

#Region "Selection Index Changed Event"

    Private Sub DrpCourseExam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpCourseExam.SelectedIndexChanged
        FillExamNames()
    End Sub

    Private Sub DrpCombinationKey_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpCombinationKey.SelectedIndexChanged
        FillPeriodicity()
    End Sub

    Private Sub ChkLstPeriodicity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLstPeriodicity.SelectedIndexChanged
        FillExams()
    End Sub

    Private Sub DrpSelection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpSelection.SelectedIndexChanged
        Try

            If DrpSelection.SelectedItem.Value = 2 Then
                TrPeriodicity.Visible = True
                FillPeriodicity()
                For I As Integer = 0 To ChkLstPeriodicity.Items.Count - 1
                    ChkLstPeriodicity.Items(I).Selected = False
                Next
            ElseIf DrpSelection.SelectedItem.Value = 1 Then
                TrPeriodicity.Visible = False
                FillPeriodicity()
                For I As Integer = 0 To ChkLstPeriodicity.Items.Count - 1
                    ChkLstPeriodicity.Items(I).Selected = True
                Next
                FillExams()
            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " ListBox Button Events"

#Region " EXAMS "

    Private Sub BtnExam_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnExam.Click
        If (Not LstExams.SelectedValue Is Nothing) Then
            Commonfunctions.FillListSel(LstExams, LstSelExams)
            FillSubjects()
        End If

    End Sub

    Private Sub BtnExamAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnExamAll.Click
        If (Not LstExams.SelectedValue Is Nothing) Then
            Commonfunctions.FillListAll(LstExams, LstSelExams)
            FillSubjects()
        End If
    End Sub

    Private Sub BtnRemExam_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemExam.Click
        If (Not LstSelExams.SelectedValue Is Nothing) Then
            Commonfunctions.FillListSel(LstSelExams, LstExams)

            FillSubjects()
        End If


    End Sub

    Private Sub BtnRemAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemAll.Click
        If (Not LstSelExams.SelectedValue Is Nothing) Then
            Commonfunctions.FillListAll(LstSelExams, LstExams)


            Commonfunctions.ClearListBox(LstSubject)
            Commonfunctions.ClearListBox(LstSelSubject)
            Commonfunctions.ClearListBox(LstTrack)
            Commonfunctions.ClearListBox(LstSelTrack)
        End If
    End Sub



#End Region

#Region "Subject"

    Private Sub BtnSubject_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSubject.Click
        Try
            Dim i As Integer
            If Not LstSubject.SelectedItem Is Nothing Then
                For i = 0 To LstSubject.Items.Count - 1
                    If LstSubject.Items(i).Selected = True Then
                        LstSelSubject.Items.Add(LstSubject.Items(i))
                    End If
                Next
                i = 0
                Do
                    If LstSubject.Items(i).Selected = True Then
                        LstSubject.Items.Remove(LstSubject.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LstSubject.Items.Count Then Exit Do
                Loop
                FillTracks()
            End If
        Catch ex As Exception
            'StartUpScript(BtnSelsubject.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnsubjectAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSubjectAll.Click
        Try
            Dim iTotItems As Integer = LstSubject.Items.Count - 1
            Dim i As Integer

            For i = 0 To iTotItems
                LstSelSubject.Items.Add(LstSubject.Items(i))
            Next
            LstSubject.Items.Clear()
            FillTracks()
        Catch ex As Exception
            'StartUpScript(BtnSelsubject.ID, ex.Message)
        End Try
    End Sub

    Private Sub BtnRemsubject_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemSubject.Click
        Try
            Dim i As Integer
            If Not LstSelSubject.SelectedItem Is Nothing Then
                For i = 0 To LstSelSubject.Items.Count - 1
                    If LstSelSubject.Items(i).Selected = True Then
                        LstSubject.Items.Add(LstSelSubject.Items(i))
                    End If
                Next

                i = 0
                Do
                    If LstSelSubject.Items(i).Selected = True Then
                        LstSelSubject.Items.Remove(LstSelSubject.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LstSelSubject.Items.Count Then Exit Do
                Loop
                FillTracks()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRemsubjectAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemSubjectAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = LstSelSubject.Items.Count - 1

            For i = 0 To iTotItems
                LstSubject.Items.Add(LstSelSubject.Items(i))
            Next
            LstSelSubject.Items.Clear()
            LstSelTrack.Items.Clear()
            LstTrack.Items.Clear()

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Track"

    Private Sub BtnTrack_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnTrack.Click
        Try
            Commonfunctions.FillListSel(LstTrack, LstSelTrack)
            'FillALLTracks()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnTrackAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnTrackAll.Click
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

    Private Sub BtnRemTrackAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemTrackAll.Click
        Try
            Commonfunctions.FillListAll(LstSelTrack, LstTrack)
            ' LSTTotalTrack.Items.Clear()
        Catch ex As Exception

        End Try
    End Sub

#End Region
#End Region



#End Region

End Class
