'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : FINAL KEY CORRECTINS
'   AUTHOR                            : P.VENU
'   INITIAL BASELINE DATE             : 25.07.2011
'   FINAL BASELINE DATE               : 25.07.2011
'   COMPLETED DATE                    : 25.07.2011
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Public Class Objection_FinalKey
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents LblPs As System.Web.UI.WebControls.Label
    Protected WithEvents dgFinal As System.Web.UI.WebControls.DataGrid
    Protected WithEvents IbtnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents DrpExamName As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpExamDate As System.Web.UI.WebControls.DropDownList

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
    Dim Dset, MaindSet As New DataSet
    Dim StrPaperSetter As Integer

#End Region

#Region " -> Fill Methods"

    Private Sub FillExamNames()
        Try
            SqlStr = "SELECT OBJEXAMSLNO,OBJEXAMNAME FROM OBJECTIONS_EXAMNAME_MT"
            ObjFetchDs = New Utility
            Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
            DrpExamName.DataTextField = "OBJEXAMNAME"
            DrpExamName.DataValueField = "OBJEXAMSLNO"
            DrpExamName.DataSource = Dset
            DrpExamName.DataBind()

            FillExamDate()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillExamDate()
        Try
            SqlStr = "SELECT OBJTESTSLNO,TO_CHAR(OBJTESTDATE,'DD/MM/YYYY')||'/'||OBJTESTDESC OBJTESTDATE FROM OBJECTIONS_EXAM_DATE_MAP WHERE OBJEXAMSLNO=" & DrpExamName.SelectedItem.Value
            ObjFetchDs = New Utility
            Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
            If Dset.Tables(0).Rows.Count <> 0 Then
                DrpExamDate.BackColor = Color.Empty
                DrpExamDate.DataTextField = "OBJTESTDATE"
                DrpExamDate.DataValueField = "OBJTESTSLNO"
                DrpExamDate.DataSource = Dset
                DrpExamDate.DataBind()
            Else
                If DrpExamDate.Items.Count <> 0 Then
                    DrpExamDate.Items.Clear()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillGrid()
        Try
            SqlStr = " SELECT   SBJ.NAME SBJNAME, OBJFIN.OBJQUESTIONNO, OBJFIN.OBJGIVENKEY, OBJFIN.OBJCOUNT,OBJFIN.OBJACTION, OBJFIN.OBJFINALKEY, OBJFIN.OBJREMARKS, USER1.NAME USERNAME" & _
                     " FROM (SELECT OBJSUBJECTSLNO, OBJQUESTIONNO, OBJGIVENKEY, OBJCOUNT, DECODE (OBJACTION, 1, 'CHANGEKEY', 0, 'DELETE') OBJACTION, UPPER (OBJFINALKEY) OBJFINALKEY, OBJREMARKS, USERSLNO " & _
                     " FROM OBJECTIONS_FINALKEY WHERE OBJTESTSLNO=" & DrpExamDate.SelectedItem.Value & ") OBJFIN,T_SUBJECT_MT SBJ, EXAM_USER_MT USER1 WHERE OBJFIN.OBJSUBJECTSLNO = SBJ.SUBJECTSLNO AND OBJFIN.USERSLNO = USER1.USERSLNO ORDER BY SBJ.REPORTORDER, OBJQUESTIONNO"

            ObjFetchDs = New Utility
            Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
            If Dset.Tables(0).Rows.Count <> 0 Then
                If dgFinal.Visible = False Then
                    dgFinal.Visible = True
                End If
                dgFinal.DataSource = Dset.Tables(0)
                dgFinal.DataBind()
                Papersetter()
            Else
                StartUpScript(dgFinal.ID, " No Key Corrections Found..!")
            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " -> Page Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                FillExamNames()
                FillExamDate()
            Else
            End If

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
            SqlStr = " SELECT EXAMBRANCHNAME,EXAMBRANCHSLNO FROM EXAM_EXAMBRANCH WHERE EXAMBRANCHSLNO IN (SELECT OBJEXAMPAPERSETTER FROM OBJECTIONS_OBJECTION_MT WHERE OBJTESTSLNO=" & DrpExamDate.SelectedItem.Value & ")"
            ObjFetchDs = New Utility
            Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
            LblPs.Visible = True
            LblPs.Text = "PAPER SETTER : " + Dset.Tables(0).Rows(0).Item(0).ToString
        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " -> DrpDown Events"

    Private Sub DrpExamName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpExamName.SelectedIndexChanged
        Try
            LblPs.Visible = False
            dgFinal.Visible = False
            FillExamDate()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrpExamDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpExamDate.SelectedIndexChanged
        Try
            LblPs.Visible = False
            dgFinal.Visible = False
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
