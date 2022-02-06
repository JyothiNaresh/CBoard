'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : Board Enrollment College Code List
'                                       
'                                       
'   AUTHOR                            : I.CHANDRA
'   INITIAL BASELINE DATE             : 19-Dec-2017
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.IO
Imports System.Threading
Imports System.Text
Imports CollegeBoardDLL

Public Class CollegeCodeWiseReport
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents PageY As System.Web.UI.WebControls.TextBox
    Protected WithEvents PageX As System.Web.UI.WebControls.TextBox
    Protected WithEvents iBtnReport As System.Web.UI.WebControls.ImageButton
    Protected WithEvents drpFormat As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpOrder As System.Web.UI.WebControls.DropDownList

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

            End If

        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
            StartUpScript(iBtnReport.ID, " Transaction  Failed ")

        End Try

    End Sub

#End Region

    Protected Sub txtCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged

    End Sub
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

#End Region

#Region "Sql Query"
    Private Sub GetReportsDetails()
        Try
            Dim DTStudent As String
            Dim I As Integer
            Dim FilterString As String
           
            Dim Ord As String
            If drpOrder.SelectedValue = 1 Then
                If drpFormat.SelectedValue = 1 Then
                    Ord = "ADM.ADMNO"
                ElseIf drpFormat.SelectedValue = 2 Then
                    Ord = "ADM.RESNO"
                End If

            ElseIf drpOrder.SelectedValue = 2 Then
                Ord = "ADM.NAME"
            ElseIf drpOrder.SelectedValue = 3 Then
                Ord = "BRD.PRV_HTNO"
            End If

            FilterString &= " AND BC.CODE='" & txtCode.Text & "' AND EUA.USERSLNO=" + UserSLNo.ToString & " AND EUA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO")

            If drpFormat.SelectedValue = 1 Then
                DTStudent = " SELECT DISTINCT ADM.ADMSLNO,ADM.ADMNO,ADM.NAME,ADM.NAME||'.'||ADM.SURNAME STUDENTNAME,ADM.FATHERNAME,BRD.PRV_HTNO,ADM.GENDER,CST.CODE COMCODE, " & _
                            " ADM.EXAMBRANCHSLNO,EXAMBRANCH.EXAMBRANCHNAME,ADM.COURSESLNO,COU.NAME COURSE,ADM.GROUPSLNO,ADM.BATCHSLNO,BRD.BOARDADMSLNO,BRD.BOARDADMNO, " & _
                            " CAT.CODE CATEGORY,ADM.MEDIUMSLNO MEDIUM,'01' ILANG,SEC.CODE IILANG,BC.CODE,BC.NAME COL_NAME,BC.BOARDDISTSLNO,BC.BOARDCOLLEGESLNO,BYP.CODE BYPCODE, BYP.BOARDYOPSLNO " & _
                            " FROM T_ADM_DT ADM,T_COURSE_MT COU,EXAM_BOARDSTUDENT_DT BRD,EXAM_BOARDCASTE_MT CST,EXAM_BOARDCATEOGORY_MT CAT,EXAM_BOARDSECLANG_MT SEC, " & _
                            " EXAM_EXAMBRANCH EXAMBRANCH,E_USER_BRANCH_ACADEMIC_MT EUA,T_BRANCH_MT BRANCH,EXAM_BOARDCOLLEGE_MT BC,EXAM_BOARDYOP_MT BYP " & _
                            " WHERE ADM.STATUS IN(1,8) AND ADM.COURSESLNO=COU.COURSESLNO AND ADM.UNIQUENO(+)=BRD.UNIQUENO AND BRD.BOARDCOLLEGESLNO=BC.BOARDCOLLEGESLNO AND CST.BOARDCASTESLNO(+)=BRD.BOARDCASTESLNO AND CAT.BOARDCATEGORYSLNO(+)=BRD.BOARDCATEGORYSLNO " & _
                            " AND SEC.BOARDSECLANGSLNO(+)=BRD.BOARDSECLANGSLNO AND ADM.BRANCHSLNO = BRANCH.BRANCHSLNO AND EUA.EXAMBRANCHSLNO=EXAMBRANCH.EXAMBRANCHSLNO  AND ADM.EXAMBRANCHSLNO=EUA.EXAMBRANCHSLNO " & _
                            " AND BRD.BOARDYOPSLNO=BYP.BOARDYOPSLNO(+) AND ADM.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & " " & FilterString & " ORDER BY " & Ord

            ElseIf drpFormat.SelectedValue = 2 Then
                DTStudent = " SELECT DISTINCT ADM.RESSLNO,ADM.RESNO ADMNO,ADM.NAME,ADM.NAME||'.'||ADM.SURNAME STUDENTNAME,ADM.FATHERNAME,BRD.PRV_HTNO,ADM.GENDER,CST.CODE COMCODE, " & _
                            " ADM.EXAMBRANCHSLNO,EXAMBRANCH.EXAMBRANCHNAME,ADM.COURSESLNO,COU.NAME COURSE,ADM.GROUPSLNO,ADM.BATCHSLNO,BRD.BOARDADMSLNO,BRD.BOARDADMNO, " & _
                            " CAT.CODE CATEGORY,ADM.MEDIUMSLNO MEDIUM,'01' ILANG,SEC.CODE IILANG,BC.CODE,BC.NAME COL_NAME,BC.BOARDDISTSLNO,BC.BOARDCOLLEGESLNO,BYP.CODE BYPCODE, BYP.BOARDYOPSLNO " & _
                            " FROM T_RES_DT ADM,T_COURSE_MT COU,EXAM_BOARDSTUDENT_DT BRD,EXAM_BOARDCASTE_MT CST,EXAM_BOARDCATEOGORY_MT CAT,EXAM_BOARDSECLANG_MT SEC, " & _
                            " EXAM_EXAMBRANCH EXAMBRANCH,E_USER_BRANCH_ACADEMIC_MT EUA,T_BRANCH_MT BRANCH,EXAM_BOARDCOLLEGE_MT BC,EXAM_BOARDYOP_MT BYP " & _
                            " WHERE ADM.STATUS ='N' AND ADM.COURSESLNO=COU.COURSESLNO AND ADM.RESSLNO(+)=BRD.UNIQUENO AND BRD.BOARDCOLLEGESLNO=BC.BOARDCOLLEGESLNO AND CST.BOARDCASTESLNO(+)=BRD.BOARDCASTESLNO AND CAT.BOARDCATEGORYSLNO(+)=BRD.BOARDCATEGORYSLNO " & _
                            " AND SEC.BOARDSECLANGSLNO(+)=BRD.BOARDSECLANGSLNO AND ADM.RESFORBRANCHSLNO = BRANCH.BRANCHSLNO AND EUA.EXAMBRANCHSLNO=EXAMBRANCH.EXAMBRANCHSLNO  AND ADM.EXAMBRANCHSLNO=EUA.EXAMBRANCHSLNO " & _
                            " AND BRD.BOARDYOPSLNO=BYP.BOARDYOPSLNO(+) AND BRD.ISRES=1 AND ADM.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & " " & FilterString & " ORDER BY " & Ord

            End If
            '" ORDER BY ADM.NAME||'.'||ADM.SURNAME"
            ObjResult = New Utility
            DsResult = ObjResult.DataSet_OneFetch(DTStudent)


            If Not DsResult Is Nothing Then
                If DsResult.Tables(0).Rows.Count > 0 Then
                    FormatReportstringCode(DsResult)
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

    Private Function FormatReportstringCode(ByVal Ds As DataSet) As StringBuilder
        Try
            Dim strfile As New StringBuilder

            Dim strdata As New StringBuilder
            Dim srw As StreamWriter
            Dim FinalString As New StringBuilder
            'Dim ireportwidth As Integer = 183
            Dim iReportWidth As Integer
            Dim i, K, J, L, SE, E As Integer
            Dim compare As New ArrayList
            Dim count As Integer = 0
            Dim StrHead1, StrHead2, StrHead3, StrHead4 As String

            Dim Admno As String


            iReportWidth = 250

            strfile.Append(StrPadding("I.P.E MARCH, 2018 ", 20, "M") & vbCrLf)
            strfile.Append(StrPadding(" ", 35, "L"))

            strfile.Append(StrPadding("NAME OF THE COLLEGE  : " & DsResult.Tables(0).Rows(0)("COL_NAME") & ")", 79, "L"))
            strfile.Append(StrPadding(" ", 38, "L"))
            strfile.Append(StrPadding("COLLEGE CODE  : " & txtCode.Text, 30, "R") & vbCrLf)

            'Starting Heading - 1
            StrHead1 = StrPadding("SL.NO", 6, "L") & "|"
            StrHead1 &= StrPadding("  ADMNO  ", 9, "M") & "|"
            StrHead1 &= StrPadding("BOARD ADMNO", 11, "M") & "|"

            StrHead1 &= StrPadding("Name of the Candidate(in 30 Spaces)", 36, "L") & "|"
            StrHead1 &= StrPadding("Name of the Parent(in 25 Spaces)", 34, "L") & "|"
            StrHead1 &= StrPadding("Intermediate Prev", 18, "L") & "|"
            StrHead1 &= StrPadding("Sex", 5, "M") & "|"
            StrHead1 &= StrPadding("Com-Code", 8, "M") & "|"
            StrHead1 &= StrPadding("Category", 8, "M") & "|"
            StrHead1 &= StrPadding("Medium", 7, "M") & "|"
            StrHead1 &= StrPadding("Part-I", 7, "M") & "|"
            StrHead1 &= StrPadding("Part-II", 7, "M") & "|"
            StrHead1 &= StrPadding("Part-III", 27, "M") & "|"
            StrHead1 &= StrPadding("No.of Tot", 9, "M") & "|"
            StrHead1 &= StrPadding("Course", 10, "L") & "|"
            StrHead1 &= StrPadding("Branch", 35, "L") & "|"
            StrHead1 &= vbCrLf


            'Starting Heading - 2
            StrHead2 = StrPadding(" ", 6, "L") & "|"
            StrHead2 &= StrPadding(" ", 9, "M") & "|"
            StrHead2 &= StrPadding(" ", 11, "M") & "|"

            StrHead2 &= StrPadding("(Capital Letters in Blue Ink)", 36, "L") & "|"
            StrHead2 &= StrPadding("(Capital Letters in Red Ink)", 34, "L") & "|"
            StrHead2 &= StrPadding("Examn.Reg.No", 18, "L") & "|"
            StrHead2 &= StrPadding(" ", 5, "M") & "|"
            StrHead2 &= StrPadding(" ", 8, "M") & "|"
            StrHead2 &= StrPadding(" ", 8, "M") & "|"
            StrHead2 &= StrPadding(" ", 7, "M") & "|"
            StrHead2 &= StrPadding(" ", 7, "M") & "|"
            StrHead2 &= StrPadding(" ", 7, "M") & "|"
            StrHead2 &= StrPadding("-----------------------------", 27, "M") & "|"
            StrHead2 &= StrPadding("Papers", 9, "M") & "|"
            StrHead2 &= vbCrLf


            'Starting Heading - 3
            StrHead3 = StrPadding(" ", 6, "L") & "|"
            StrHead3 &= StrPadding(" ", 9, "M") & "|"
            StrHead3 &= StrPadding(" ", 11, "M") & "|"

            StrHead3 &= StrPadding("(As in SSC or equivalent of exam)", 36, "L") & "|"
            StrHead3 &= StrPadding("(As in SSC or equivalent of exam)", 34, "L") & "|"
            StrHead3 &= StrPadding("Month & Year", 18, "L") & "|"
            StrHead3 &= StrPadding(" ", 5, "M") & "|"
            StrHead3 &= StrPadding(" ", 8, "M") & "|"
            StrHead3 &= StrPadding(" ", 8, "M") & "|"
            StrHead3 &= StrPadding(" ", 7, "M") & "|"
            StrHead3 &= StrPadding(" ", 7, "M") & "|"
            StrHead3 &= StrPadding(" ", 7, "M") & "|"
            StrHead3 &= StrPadding("M-1/B", 6, "M") & "|"
            StrHead3 &= StrPadding("M-2/Z", 6, "M") & "|"
            StrHead3 &= StrPadding("PHY", 6, "M") & "|"
            StrHead3 &= StrPadding("CHE", 6, "M") & "|"
            StrHead3 &= StrPadding("Appearing", 9, "M") & "|"
            StrHead3 &= vbCrLf

            'Starting Heading - 4
            StrHead4 = StrPadding("1", 6, "M") & "|"
            StrHead4 &= StrPadding(" ", 9, "M") & "|"
            StrHead4 &= StrPadding(" ", 11, "M") & "|"

            StrHead4 &= StrPadding("2", 36, "M") & "|"
            StrHead4 &= StrPadding("3", 34, "M") & "|"
            StrHead4 &= StrPadding("4", 18, "M") & "|"
            StrHead4 &= StrPadding("5", 5, "M") & "|"
            StrHead4 &= StrPadding("6", 8, "M") & "|"
            StrHead4 &= StrPadding("7", 8, "M") & "|"
            StrHead4 &= StrPadding("8", 7, "M") & "|"
            StrHead4 &= StrPadding("9", 7, "M") & "|"
            StrHead4 &= StrPadding("10", 7, "M") & "|"
            StrHead4 &= StrPadding("11", 6, "M") & "|"
            StrHead4 &= StrPadding("12", 6, "M") & "|"
            StrHead4 &= StrPadding("13", 6, "M") & "|"
            StrHead4 &= StrPadding("14", 6, "M") & "|"
            StrHead4 &= StrPadding("15", 9, "M") & "|"
            StrHead4 &= StrPadding(" ", 10, "M") & "|"
            StrHead4 &= StrPadding(" ", 35, "M") & "|"
            'StrHead4 &= vbCrLf

            strfile.Append(PrintLines("-", iReportWidth))
            strfile.Append(StrHead1)
            strfile.Append(StrHead2)
            strfile.Append(StrHead3)
            strfile.Append(PrintLines("-", iReportWidth))
            strfile.Append(StrHead4)

            strfile.Append(vbCrLf)
            strfile.Append(PrintLines("-", iReportWidth))
            Dim S As Integer
            S = 0
            For i = 0 To DsResult.Tables(0).Rows.Count - 1

                S = S + 1

                strfile = strfile.Append(StrPadding(S, 6, "L") & "|")
                strfile.Append(StrPadding(DsResult.Tables(0).Rows(i)("ADMNO").ToString, 9, "M") & "|")
                strfile.Append(StrPadding(DsResult.Tables(0).Rows(i)("BOARDADMNO").ToString, 11, "M") & "|")
                strfile = strfile.Append(StrPadding(DsResult.Tables(0).Rows(i)("STUDENTNAME").ToString, 36, "L") & "|")
                strfile = strfile.Append(StrPadding(DsResult.Tables(0).Rows(i)("FATHERNAME").ToString, 34, "L") & "|")
                strfile = strfile.Append(StrPadding(DsResult.Tables(0).Rows(i)("PRV_HTNO").ToString & "(" & DsResult.Tables(0).Rows(0)("BYPCODE").ToString & ")", 18, "M") & "|")
                strfile = strfile.Append(StrPadding(DsResult.Tables(0).Rows(i)("GENDER").ToString, 5, "M") & "|")
                strfile = strfile.Append(StrPadding(DsResult.Tables(0).Rows(i)("COMCODE").ToString, 8, "M") & "|")
                strfile = strfile.Append(StrPadding(DsResult.Tables(0).Rows(i)("CATEGORY").ToString, 8, "M") & "|")
                strfile = strfile.Append(StrPadding(DsResult.Tables(0).Rows(i)("MEDIUM").ToString, 7, "M") & "|")
                strfile = strfile.Append(StrPadding(DsResult.Tables(0).Rows(i)("ILANG").ToString, 7, "M") & "|")
                strfile = strfile.Append(StrPadding(DsResult.Tables(0).Rows(i)("IILANG").ToString, 7, "M") & "|")

                If DsResult.Tables(0).Rows(0)("GROUPSLNO") = 1 Then
                    strfile.Append(StrPadding(("31").ToString, 6, "M") & "|")
                    strfile.Append(StrPadding(("32").ToString, 6, "M") & "|")
                    strfile.Append(StrPadding(("41").ToString, 6, "M") & "|")
                    strfile.Append(StrPadding(("42").ToString, 6, "M") & "|")
                    strfile.Append(StrPadding(("6").ToString, 9, "M") & "|")
                Else
                    strfile.Append(StrPadding(("38").ToString, 6, "M") & "|")
                    strfile.Append(StrPadding(("39").ToString, 6, "M") & "|")
                    strfile.Append(StrPadding(("41").ToString, 6, "M") & "|")
                    strfile.Append(StrPadding(("42").ToString, 6, "M") & "|")
                    strfile.Append(StrPadding(("6").ToString, 9, "M") & "|")
                End If
                strfile = strfile.Append(StrPadding(DsResult.Tables(0).Rows(i)("COURSE").ToString, 10, "L") & "|")
                strfile = strfile.Append(StrPadding(DsResult.Tables(0).Rows(i)("EXAMBRANCHNAME").ToString, 35, "L") & "|")
                strfile = strfile.Append(vbCrLf & PrintLines("-", iReportWidth))
                ' Next
                '                    End If
                '        Next
                '            End If
                ''    Next
                ''End If
                '        Next
                strfile.Append("")
                strfile.Append(vbCrLf)
            Next
           
            '    End If
            'Next


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

#Region "ImgEvents"

    Private Sub iBtnReport_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnReport.Click
        Try
            GetReportsDetails()

        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                StartUpScript(iBtnReport.ID, " Transaction  Failed ")
            End If
        End Try
    End Sub

#End Region

End Class