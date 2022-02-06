'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : FINAL KEY CORRECTINS
'   AUTHOR                            : P.VENU
'   INITIAL BASELINE DATE             : 25.07.2011
'   FINAL BASELINE DATE               : 25.07.2011
'   COMPLETED DATE                    : 25.07.2011
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Public Class Exam_Objections_FinalKeyCorrections
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents IbtnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LblPs As System.Web.UI.WebControls.Label
    Protected WithEvents dgFinal As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DrpExamDate As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpExamName As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " -> Form Variables"

    Dim SqlStr As String
    Dim ObjFetchDs As Utility
    Dim objTrans As NOETransaction
    Dim Dset, DNilMist, MaindSet As New DataSet
    Dim StrPaperSetter, EamorIit As Integer

#End Region

#Region " -> Page Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Try
            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                FillExamDate()
            Else
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " -> Fill Methods"

    Private Sub FillExamNames()
        Try
            SqlStr = " SELECT EXAMNAME||'/'||DESCRIPTION OBJEXAMNAME,DEXAMSLNO OBJTESTSLNO FROM EXAM_DFINEEXAM WHERE COMBINATIONKEY IN(SELECT COMBINATIONKEY FROM EXAM_USERCOMBINATIONKEY_MT WHERE USERSLNO=" & Session("USERSLNO") & " AND COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & ") AND " & _
                     " DEXAMSLNO IN (SELECT OBJTESTSLNO FROM OBJECTIONS_FINALKEY WHERE OBJCOMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " GROUP BY OBJTESTSLNO) AND EXAMTYPE NOT IN('IPE') AND EXAMDATE=TO_DATE('" & DrpExamDate.SelectedItem.Value & "','DD/MM/YYYY') AND COMACADEMICSLNO=" & Session("COMACADEMICSLNO") + " ORDER BY OBJEXAMNAME"
            ObjFetchDs = New Utility
            Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
            If Dset.Tables(0).Rows.Count <> 0 Then
                DrpExamName.DataTextField = "OBJEXAMNAME"
                DrpExamName.DataValueField = "OBJTESTSLNO"
                DrpExamName.DataSource = Dset
                DrpExamName.DataBind()
            Else
                StartUpScript(DrpExamName.ID, " No Exams Found..!")
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillExamDate()
        Try
            'SqlStr = "SELECT DISTINCT TO_CHAR(EXAMDATE,'DD/MM/YYYY') OBJTESTDATE,EXAMDATE DT FROM EXAM_DFINEEXAM WHERE COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND EXAMDATE>=TO_DATE('" & System.DateTime.Today.AddDays(-7).ToString("dd/MM/yyyy") & "','DD/MM/YYYY') ORDER BY DT DESC"
            SqlStr = "SELECT DISTINCT TO_CHAR(EXAMDATE,'DD/MM/YYYY') OBJTESTDATE,EXAMDATE DT FROM EXAM_DFINEEXAM WHERE COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND OBJLOCKSTATUS=1 AND DEXAMSLNO IN (SELECT OBJTESTSLNO FROM OBJECTIONS_FINALKEY WHERE OBJCOMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " GROUP BY OBJTESTSLNO) ORDER BY DT DESC"
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

    Private Sub FillGrid()
        Try
            SqlStr = " SELECT OBJFINALKEY FROM OBJECTIONS_FINALKEY WHERE OBJFINALKEY='Nil Mistakes' AND OBJTESTSLNO=" & DrpExamName.SelectedItem.Value
            ObjFetchDs = New Utility
            DNilMist = ObjFetchDs.DataSet_OneFetch(SqlStr)

            If DNilMist.Tables(0).Rows.Count = 1 Then
                SqlStr = " SELECT '' SBJNAME, OBJQUESTIONNO, OBJGIVENKEY, OBJCOUNT,OBJACTION, OBJFINALKEY, OBJREMARKS, USER1.NAME USERNAME" & _
                         " FROM (SELECT OBJSUBJECTSLNO, OBJQSTN OBJQUESTIONNO, OBJGIVENKEY, OBJCOUNT, DECODE (OBJACTION, 1, 'CHANGEKEY', 0, 'DELETE') OBJACTION, UPPER (OBJFINALKEY) OBJFINALKEY, OBJREMARKS, USERSLNO " & _
                         " FROM OBJECTIONS_FINALKEY WHERE OBJTESTSLNO=" & DrpExamName.SelectedItem.Value & ") OBJFIN, EXAM_USER_MT USER1 WHERE OBJFIN.USERSLNO = USER1.USERSLNO ORDER BY OBJQUESTIONNO"
                ObjFetchDs = New Utility
                Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
                If dgFinal.Visible = False Then
                    dgFinal.Visible = True
                End If
                dgFinal.DataSource = Dset.Tables(0)
                dgFinal.DataBind()
                Papersetter()
            Else
                SqlStr = " SELECT   SBJ.NAME SBJNAME, OBJFIN.OBJQUESTIONNO,OBJFIN.OBJQ, OBJFIN.OBJGIVENKEY, OBJFIN.OBJCOUNT,OBJFIN.OBJACTION, OBJFIN.OBJFINALKEY, OBJFIN.OBJFINALKEY FINKEY,OBJFIN.OBJREMARKS, USER1.NAME USERNAME" & _
                         " FROM (SELECT OBJSUBJECTSLNO, OBJQSTN OBJQUESTIONNO,OBJQUESTIONNO OBJQ, OBJGIVENKEY, OBJCOUNT, DECODE (OBJACTION, 1, 'CHANGEKEY', 0, 'DELETE') OBJACTION, UPPER (OBJFINALKEY) OBJFINALKEY, OBJREMARKS, USERSLNO " & _
                         " FROM OBJECTIONS_FINALKEY WHERE OBJTESTSLNO=" & DrpExamName.SelectedItem.Value & ") OBJFIN,T_SUBJECT_MT SBJ, EXAM_USER_MT USER1 WHERE OBJFIN.OBJSUBJECTSLNO = SBJ.SUBJECTSLNO AND OBJFIN.USERSLNO = USER1.USERSLNO ORDER BY OBJQ"

                ObjFetchDs = New Utility
                Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
                If Dset.Tables(0).Rows.Count <> 0 Then
                    If dgFinal.Visible = False Then
                        dgFinal.Visible = True
                    End If
                    Dim Dr() As DataRow
                    Dr = Dset.Tables(0).Select("OBJFINALKEY LIKE 'R%'", "")

                    For i As Integer = 0 To Dr.Length - 1
                        'Converting FinalKey
                        Dim Str, Ven, Ven1 As String
                        Ven = Dr(i)("OBJFINALKEY").ToString
                        Str = Mid(Ven, 2, 1) + "/" + Mid(Ven, 3, 1)
                        Dr(i)("OBJFINALKEY") = Str
                    Next
                    dgFinal.DataSource = Dset.Tables(0)
                    dgFinal.DataBind()
                    Papersetter()
                Else
                    StartUpScript(dgFinal.ID, " No Key Corrections Found..!")
                End If
            End If
            'If Dset.Tables(0).Rows.Count <> 0 And DNilMist.Tables(0).Rows.Count <> 0 Then
            '    If dgFinal.Visible = False Then
            '        dgFinal.Visible = True
            '    End If
            '    dgFinal.DataSource = Dset.Tables(0)
            '    dgFinal.DataBind()
            '    Papersetter()
            'Else
            'End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " -> Methods"

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

    Private Function Papersetter()
        Try
            SqlStr = " SELECT EXAMBRANCHSLNO,EXAMBRANCHNAME FROM EXAM_EXAMBRANCH WHERE EXAMBRANCHSLNO IN (SELECT PAPERSETTEREBSLNO FROM EXAM_DFINEEXAM WHERE DEXAMSLNO=" & DrpExamName.SelectedItem.Value & ")"
            ObjFetchDs = New Utility
            Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
            If Dset.Tables(0).Rows.Count <> 0 Then
                LblPs.Visible = True
                If Dset.Tables(0).Rows(0).Item(1) = Nothing Then
                    LblPs.Text = "PAPER SETTER : ***"
                Else
                    LblPs.Text = "PAPER SETTER : " + Dset.Tables(0).Rows(0).Item(1).ToString
                End If
            Else
                LblPs.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " -> DrpDown Events"

    Private Sub DrpExamName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpExamName.SelectedIndexChanged
        Try
            LblPs.Visible = False
            dgFinal.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrpExamDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpExamDate.SelectedIndexChanged
        Try
            LblPs.Visible = False
            dgFinal.Visible = False
            FillExamNames()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " -> Ibtn Events"

    Private Sub IbtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnGo.Click
        Try
            FillGrid()
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
