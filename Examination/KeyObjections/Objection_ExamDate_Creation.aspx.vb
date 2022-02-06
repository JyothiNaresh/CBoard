'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : ENTRY FORM FOR OBJECTION_TEST_CREATION
'   AUTHOR                            : P.VENU
'   INITIAL BASELINE DATE             : 15.07.2011
'   FINAL BASELINE DATE               : 15.07.2011
'   COMPLETED DATE                    : 16.07.2011
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Public Class Objection_ExamEntry
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents RdbTest As System.Web.UI.WebControls.RadioButton
    Protected WithEvents RdbTestEntry As System.Web.UI.WebControls.RadioButton
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents DgTestView As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DrpExamName As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpExamName1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TxtDesc As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtTestDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents IBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents PnlEntry As System.Web.UI.WebControls.Panel
    Protected WithEvents PnlView As System.Web.UI.WebControls.Panel
    Protected WithEvents IbtnCancel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LblHelp As System.Web.UI.WebControls.Label
    Protected WithEvents DgSubjects As System.Web.UI.WebControls.DataGrid
    Protected WithEvents IbtnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents TxtNsub As System.Web.UI.WebControls.TextBox
    Protected WithEvents LblNSub As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpPaperSetter As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " Form Variables"

    Dim RtnVal As Integer
    Private objTrans As NOETransaction
    Private objFetch As Utility
    Dim ObjStr As String
    Public PageIndex As Integer
    Dim Dset, DsSbj As New DataSet
    Private DsSearchResult As DataSet

#End Region

#Region " Page.Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Try
            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                ButtonsHiding(Me.Page)
            End If
        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)

            StartUpScript(IBtnSave.ID, " Transaction  Failed ")

            Throw ORAEX

        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)

            StartUpScript(IBtnSave.ID, " Transaction  Failed ")

            Throw ex

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)

            StartUpScript(IBtnSave.ID, " Transaction  Failed ")

            Throw OmEx
        End Try


    End Sub

#End Region

#Region " Fill Methods"

    Private Sub FillExamNames()
        Try
            ObjStr = " SELECT OBJEXAMSLNO,OBJEXAMNAME FROM OBJECTIONS_EXAMNAME_MT "

            objFetch = New Utility
            Dset = objFetch.DataSet_OneFetch(ObjStr)

            DrpExamName.DataTextField = "OBJEXAMNAME"
            DrpExamName.DataValueField = "OBJEXAMSLNO"

            DrpExamName.DataSource = Dset.Tables(0)
            DrpExamName.DataBind()

            DrpExamName1.DataTextField = "OBJEXAMNAME"
            DrpExamName1.DataValueField = "OBJEXAMSLNO"

            DrpExamName1.DataSource = Dset.Tables(0)
            DrpExamName1.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillExamBranch()
        Try
            ObjStr = "SELECT EXAMBRANCHSLNO,EXAMBRANCHNAME FROM EXAM_EXAMBRANCH WHERE EXAMBRANCHSLNO IN (SELECT EXAMBRANCHSLNO FROM E_USER_BRANCH_ACADEMIC_MT WHERE COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND USERSLNO=" & Session("USERSLNO") & ") ORDER BY EXAMBRANCHNAME"
            objFetch = New Utility
            Dset = objFetch.DataSet_OneFetch(ObjStr)
            DrpPaperSetter.DataTextField = "EXAMBRANCHNAME"
            DrpPaperSetter.DataValueField = "EXAMBRANCHSLNO"
            DrpPaperSetter.DataSource = Dset
            DrpPaperSetter.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillGridSubejcts()
        Try
            DgSubjects.Visible = True
            PrepareDatatable()
            GridDrpFilling()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrepareDatatable()
        Try
            Dim dt As New DataTable
            Dim i As Int32
            dt.Columns.Add("SNO", Type.GetType("System.Int32"))
            For i = 1 To Val(TxtNsub.Text)
                Dim dRow As DataRow
                dRow = dt.NewRow
                dRow("SNO") = i
                dt.Rows.Add(dRow)
            Next
            DgSubjects.DataSource = dt
            DgSubjects.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridDrpFilling()
        Try

            Dim i As Byte
            Dim dr As DataRow

            ObjStr = " SELECT SUBJECTSLNO,NAME FROM T_SUBJECT_MT WHERE STATUS='A' ORDER BY NAME "

            objFetch = New Utility
            DsSbj = objFetch.DataSet_OneFetch(ObjStr)

            For DgRcnt As Integer = 0 To DgSubjects.Items.Count - 1
                Dim DrpDum As DropDownList = CType(DgSubjects.Items(DgRcnt).Cells(1).FindControl("DrpSbj"), DropDownList)
                DrpDum.DataSource = DsSbj
                DrpDum.DataTextField = "NAME"
                DrpDum.DataValueField = "SUBJECTSLNO"
                DrpDum.DataBind()
            Next

        Catch ex As Exception
            StartUpScript(Me.ID, ex.Message)
        End Try
    End Sub

#End Region

#Region " Common Methods"

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

    Private Function FormValidation()
        Try
            If TxtTestDate.Text = Nothing Then
                StartUpScript(TxtTestDate.ID, " Enter TestDate..")
                Return False
            ElseIf TxtDesc.Text = Nothing Then
                StartUpScript(TxtDesc.ID, " Enter Description..")
                Return False
            ElseIf TxtNsub.Text = Nothing Then
                StartUpScript(TxtNsub.ID, " Enter No.of Subjects..")
                Return False
            End If
            Return True
        Catch ex As Exception

        End Try
    End Function

    Private Function SetEntries() As ArrayList
        Try
            Dim Arr As New ArrayList
            Dim DrpSubject1 As DropDownList
            Dim TxtQFrom, TxtQto As TextBox
            Dim StrSubjects, StrQFrom, StrQto As String
            Dim GridValidation As Boolean = True

            Arr.Add(DrpExamName.SelectedItem.Value)
            Arr.Add(Commonfunctions.ConvertToDate(Trim(TxtTestDate.Text)))
            Arr.Add(Trim(TxtDesc.Text.ToString))
            Arr.Add(Session("COMACADEMICSLNO"))

            For i As Integer = 0 To DgSubjects.Items.Count - 1
                DrpSubject1 = DgSubjects.Items(i).Cells(1).Controls(1)
                TxtQFrom = DgSubjects.Items(i).Cells(2).Controls(1)
                TxtQto = DgSubjects.Items(i).Cells(3).Controls(1)
                If TxtQFrom.Text = Nothing Then
                    GridValidation = False
                    StartUpScript(TxtQFrom.ID, "Enter From Que.Num..'")
                    Exit Function
                End If

                If TxtQto.Text = Nothing Then
                    GridValidation = False
                    StartUpScript(TxtQto.ID, "Enter To Que.Num..'")
                    Exit Function
                End If

                StrSubjects += DrpSubject1.SelectedItem.Value + IIf(i <> DgSubjects.Items.Count - 1, ",", "")

                StrQFrom += TxtQFrom.Text + IIf(i <> DgSubjects.Items.Count - 1, ",", "")
                StrQto += TxtQto.Text + IIf(i <> DgSubjects.Items.Count - 1, ",", "")
            Next

            Arr.Add(StrSubjects)
            Arr.Add(StrQFrom)
            Arr.Add(StrQto)
            Arr.Add(DrpPaperSetter.SelectedItem.Value)

            Return Arr

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GridDataset(ByVal PageIndex As Integer)
        Try
            ObjStr = "SELECT EXAM.OBJEXAMNAME,EXAM.OBJEXAMSLNO,TEST.OBJTESTSLNO OBJTESTSLNO,TO_CHAR(TEST.OBJTESTDATE,'DD/MM/YYYY') OBJTESTDATE,TEST.OBJTESTDESC OBJTESTDESC,EB.EXAMBRANCHNAME EBNAME FROM OBJECTIONS_EXAM_DATE_MAP TEST, OBJECTIONS_EXAMNAME_MT EXAM,EXAM_EXAMBRANCH EB WHERE TEST.OBJEXAMSLNO=" & DrpExamName1.SelectedItem.Value & " And TEST.OBJEXAMSLNO = Exam.OBJEXAMSLNO AND TEST.OBJEXAMPAPERSETTER=EB.EXAMBRANCHSLNO ORDER BY OBJTESTDATE DESC"
            objFetch = New Utility
            DsSearchResult = objFetch.DataSet_OneFetch(ObjStr)
            If Not DsSearchResult Is Nothing Then
                '' Setting Page Indexs
                If (DsSearchResult.Tables(0).Rows.Count - 1) / 10 < PageIndex Then
                    If ((DsSearchResult.Tables(0).Rows.Count - 1) / 10) <= 1 Then
                        PageIndex = 0
                    Else
                        PageIndex = PageIndex - 1
                    End If
                End If
                DgTestView.CurrentPageIndex = PageIndex
                DgTestView.DataSource = DsSearchResult
                DgTestView.DataBind()

                Me.ViewState("DsSearchResult") = DsSearchResult
            Else
                StartUpScript(DgTestView.ID, " No Tests Created...!")
            End If

        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " IBtn Events"

    Private Sub IbtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnGo.Click
        Try
            FillGridSubejcts()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnSave.Click
        Try
            If FormValidation() Then
                objTrans = New NOETransaction
                RtnVal = objTrans.OBJECTIONTESTDATE_INSERT(SetEntries)
                If RtnVal = 1 Then
                    StartUpScript(IBtnSave.ID, " Test.Created Successfully..")
                Else
                    StartUpScript(IBtnSave.ID, " Error in Test.Creation..!")
                End If
            End If
        Catch ex As Exception
            StartUpScript(IBtnSave.ID, " Save : " + ex.Message)
        End Try
    End Sub

    Private Sub IbtnCancel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnCancel.Click
        Try
            TxtTestDate.Text = Nothing
            TxtDesc.Text = Nothing
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " RadioButtion.Events"

    Private Sub RdbTestEntry_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbTestEntry.CheckedChanged
        Try
            If PnlView.Visible = True Then
                PnlView.Visible = False
            End If
            FillExamNames()
            FillExamBranch()
            PnlEntry.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RdbTests_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbTest.CheckedChanged
        Try
            If PnlEntry.Visible = True Then
                PnlEntry.Visible = False
            End If
            PnlView.Visible = True
            DgTestView.Visible = True
            FillExamNames()

            Me.ViewState("DsSearchResult") = DsSearchResult

            If Not IsNothing(DsSearchResult) Then
                DsSearchResult.Tables.Clear()
                Me.ViewState("DsSearchResult") = DsSearchResult
            End If

            GridDataset(PageIndex)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " DataGrid Events"

    Private Sub DgTestView_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DgTestView.PageIndexChanged
        Try
            DgTestView.CurrentPageIndex = e.NewPageIndex
            Me.ViewState("PageIndex") = e.NewPageIndex
            DsSearchResult = Me.ViewState("DsSearchResult")
            DgTestView.DataSource = DsSearchResult
            DgTestView.DataBind()
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                If Not Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                    "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                    StartUpScript("", GeneralErrorMessage(ex.Message))
                End If
            End If
        End Try
    End Sub

#End Region

#Region " DrpDown Events"

    Private Sub DrpExamName1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpExamName1.SelectedIndexChanged
        Try
            DgTestView.Visible = True

            DsSearchResult = Me.ViewState("DsSearchResult")

            If Not IsNothing(DsSearchResult) Then
                DsSearchResult.Tables.Clear()
                Me.ViewState("DsSearchResult") = DsSearchResult
            End If

            GridDataset(PageIndex)
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
