'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : EXAM LOCK - OBJECTIONS
'   AUTHOR                            : P.VENU
'   INITIAL BASELINE DATE             : 27.07.2011
'   FINAL BASELINE DATE               : 27.07.2011
'   COMPLETED DATE                    : 27.07.2011
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Public Class Exam_Objections_Lock
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents DgEntryLock As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ImageButton3 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents DrpExamDate As System.Web.UI.WebControls.DropDownList
    Protected WithEvents IbntGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents IbtbLock As System.Web.UI.WebControls.ImageButton

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
    Dim Dset As New DataSet
    Dim RtnVal As Integer
    Dim ExamLst, ExamLstUnlock As New ArrayList

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
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillGrid()
        Try
            Dim ObjExams As String
            SqlStr = "SELECT OBJTESTSLNO FROM OBJECTIONS_OBJECTION_MT WHERE OBJCOMACADEMICSLNO=" & Session("COMACADEMICSLNO")
            ObjFetchDs = New Utility
            Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
            If Dset.Tables(0).Rows.Count <> 0 Then
                For i As Integer = 0 To Dset.Tables(0).Rows.Count - 1
                    ObjExams += Dset.Tables(0).Rows(i).Item(0).ToString + IIf(Dset.Tables(0).Rows.Count - 1 <> i, ",", "")
                Next
                'SqlStr = " SELECT DEXAMSLNO OBJTESTSLNO,EXAMNAME,TO_CHAR(EXAMDATE,'DD/MM/YYYY') EXAMDATE,DESCRIPTION FROM EXAM_DFINEEXAM WHERE EXAMDATE=TO_DATE('" & DrpExamDate.SelectedItem.Value & "','DD/MM/YYYY') AND DEXAMSLNO IN(" + ObjExams + ") AND OBJLOCKSTATUS=1"
                'SqlStr = " SELECT DEXAMSLNO OBJTESTSLNO,EXAMNAME,TO_CHAR(EXAMDATE,'DD/MM/YYYY') EXAMDATE,DESCRIPTION,OBJLOCKSTATUS, NVL(FIN.OBJTESTSLNO,0) ISAPP FROM EXAM_DFINEEXAM, (SELECT DISTINCT OBJTESTSLNO FROM OBJECTIONS_OBJECTION_DT WHERE ISFINAL=1) FIN WHERE EXAMTYPE NOT IN('IPE') AND FIN.OBJTESTSLNO(+)=DEXAMSLNO AND COMBINATIONKEY IN(SELECT COMBINATIONKEY FROM EXAM_KEYOBJ_COMB_MAP WHERE USERSLNO=" & Session("USERSLNO") & " AND COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & ") AND EXAMDATE=TO_DATE('" & DrpExamDate.SelectedItem.Value & "','DD/MM/YYYY') ORDER BY EXAMNAME"
                'MODIFIED BY ANIL BECAUSE FOR  LOCK TEXT HIDE WHEN NO OBJECTIONS IN TABLE 
                SqlStr = " SELECT DEXAMSLNO OBJTESTSLNO,EXAMNAME,TO_CHAR(EXAMDATE,'DD/MM/YYYY') EXAMDATE,DESCRIPTION,OBJLOCKSTATUS, NVL(FIN.OBJTESTSLNO,0) ISAPP FROM EXAM_DFINEEXAM, (SELECT DISTINCT DEXAMSLNO OBJTESTSLNO  FROM EXAM_DFINEEXAM WHERE ISFINAL=1) FIN WHERE EXAMTYPE NOT IN('IPE') AND FIN.OBJTESTSLNO(+)=DEXAMSLNO AND COMBINATIONKEY IN(SELECT COMBINATIONKEY FROM EXAM_KEYOBJ_COMB_MAP WHERE USERSLNO=" & Session("USERSLNO") & " AND COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & ") AND EXAMDATE=TO_DATE('" & DrpExamDate.SelectedItem.Value & "','DD/MM/YYYY') ORDER BY EXAMNAME"
            ObjFetchDs = New Utility
            Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
            If Dset.Tables(0).Rows.Count <> 0 Then
                If DgEntryLock.Visible = False Then
                    DgEntryLock.Visible = True
                End If
                DgEntryLock.DataSource = Dset.Tables(0)
                DgEntryLock.DataBind()
            Else
                DgEntryLock.Visible = False
                StartUpScript(DgEntryLock.ID, " No Exams Found..!")
                End If
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

    Private Function SetValues() As ArrayList
        Try
            Dim i As Integer
            For i = 0 To DgEntryLock.Items.Count - 1
                Dim chk As CheckBox = CType(DgEntryLock.Items(i).Controls(1).FindControl("ChkLock"), CheckBox)
                If chk.Checked = True Then
                    ExamLst.Add(Val(DgEntryLock.Items(i).Cells(1).Text))
                Else
                    ExamLstUnlock.Add(Val(DgEntryLock.Items(i).Cells(1).Text))
                End If
            Next
        Catch ex As Exception

        End Try
    End Function

    Private Function DataSaving()
        Try
            'Dim DDset As New DataSet
            'Dim Dtbl As New DataTable("GridData")
            'Dim Drow As DataRow
            'Dtbl.Columns.Add("OBJTESTSLNO", Type.GetType("System.Int32"))
            'Dtbl.Columns.Add("USERSLNO", Type.GetType("System.Int32"))

            'For i As Integer = 0 To DgEntryLock.Items.Count - 1
            '    Dim ChkDyn As CheckBox = CType(DgEntryLock.Items(i).Controls(1).FindControl("ChkLock"), CheckBox)
            '    If ChkDyn.Checked = True Then
            '        Drow = Dtbl.NewRow
            '        Drow("OBJTESTSLNO") = Val(DgEntryLock.Items(i).Cells(1).Text)
            '        Drow("USERSLNO") = Session("UserSlno")
            '        Dtbl.Rows.Add(Drow)
            '    End If
            'Next
            'DDset.Tables.Add(Dtbl)
            SetValues()
            objTrans = New NOETransaction
            RtnVal = objTrans.ExamObjLock(Session("USERSLNO"), ExamLst, ExamLstUnlock)

            Return RtnVal

        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " -> Ibtn Events"

    Private Sub IbntGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbntGo.Click
        Try
            FillGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IbtbLock_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtbLock.Click
        Try
            RtnVal = DataSaving()
            FillGrid()
            If RtnVal = 1 Then
                StartUpScript(IbtbLock.ID, " Exams Locked Successfully..!")
            Else
                StartUpScript(IbtbLock.ID, " Transaction Failed..!")
            End If
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " -> Grid Events"

    Private Sub DgEntryLock_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DgEntryLock.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim Chk As CheckBox = CType(e.Item.Cells(5).Controls(1).FindControl("Chklock"), CheckBox)
                If Val(e.Item.Cells(6).Text) = 1 Then
                    ' Modified by Hemanth on 17th Nov 2011
                    'Chk.Enabled = False
                    If Val(e.Item.Cells(7).Text) = 0 Then
                        Chk.Enabled = True
                    Else
                        Chk.Enabled = False
                    End If
                    'Chk.Enabled = True
                    Chk.Checked = True
                    Chk.Text = "Lock"
                Else
                    Chk.Text = "Open"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
