'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : ENTRY FORM FOR OBJECTION_EXAM_CREATION
'   AUTHOR                            : P.VENU
'   INITIAL BASELINE DATE             : 15.07.2011
'   FINAL BASELINE DATE               : 15.07.2011
'   COMPLETED DATE                    : 15.07.2011
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Public Class Objection_Exam_Entry
    Inherits System.Web.UI.Page

#Region " Form.Variables"

    Dim RtnVal As Integer
    Private objTrans As NOETransaction
    Private objFetch As Utility
    Dim ObjStr As String
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Public PageIndex As Integer
    Private DsSearchResult As DataSet

#End Region

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents RdbExamEntry As System.Web.UI.WebControls.RadioButton
    Protected WithEvents RdbExams As System.Web.UI.WebControls.RadioButton
    Protected WithEvents PnlEntry As System.Web.UI.WebControls.Panel
    Protected WithEvents PnlView As System.Web.UI.WebControls.Panel
    Protected WithEvents IbtnCancel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents IBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents DrpActive As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtDesc As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtExamName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents DgExamView As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " Page Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
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
            If TxtExamName.Text = Nothing Then
                StartUpScript(TxtExamName.ID, " Enter ExamName..")
                Return False
            ElseIf TxtDesc.Text = Nothing Then
                StartUpScript(TxtDesc.ID, " Enter Description..")
                Return False
            End If
            Return True
        Catch ex As Exception

        End Try
    End Function

    Private Function SetEntries() As ArrayList
        Try
            Dim Arr As New ArrayList

            Arr.Add(Trim(TxtExamName.Text.ToString))
            Arr.Add(Trim(TxtDesc.Text.ToString))
            Arr.Add(Trim(DrpActive.SelectedItem.Value))

            Return Arr

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GridDataset(ByVal PageIndex As Integer)
        Try
            ObjStr = "SELECT * FROM OBJECTIONS_EXAMNAME_MT WHERE OBJEXAMSTATUS='ACTIVE'"
            objFetch = New Utility
            DsSearchResult = objFetch.DataSet_OneFetch(ObjStr)
            If Not DsSearchResult Is Nothing Then
                '' Setting Page Indexs
                If (DsSearchResult.Tables(0).Rows.Count - 1) / 10 < pageindex Then
                    If ((DsSearchResult.Tables(0).Rows.Count - 1) / 10) <= 1 Then
                        PageIndex = 0
                    Else
                        PageIndex = PageIndex - 1
                    End If
                End If
                DgExamView.CurrentPageIndex = PageIndex
                DgExamView.DataSource = DsSearchResult
                DgExamView.DataBind()

                Me.ViewState("DsSearchResult") = DsSearchResult
            Else
                StartUpScript(DgExamView.ID, " No ExamNames Created...!")
            End If

        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " IBtn Events"

    Private Sub IBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnSave.Click
        Try
            If FormValidation() Then
                objTrans = New NOETransaction
                RtnVal = objTrans.OBJECTIONEXAMNAME_INSERT(SetEntries)
                If RtnVal = 1 Then
                    StartUpScript(IBtnSave.ID, " ExamName.Created Successfully..")
                Else
                    StartUpScript(IBtnSave.ID, " Error in ExamName.Creation..!")
                End If
            End If
        Catch ex As Exception
            StartUpScript(IBtnSave.ID, " Save : " + ex.Message)
        End Try
    End Sub

    Private Sub IbtnCancel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            TxtExamName.Text = Nothing
            TxtDesc.Text = Nothing
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " RadioButtion.Events"

    Private Sub RdbExamEntry_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbExamEntry.CheckedChanged
        Try
            If PnlView.Visible = True Then
                PnlView.Visible = False
            End If
            PnlEntry.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RdbExams_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbExams.CheckedChanged
        Try
            If PnlEntry.Visible = True Then
                PnlEntry.Visible = False
            End If
            PnlView.Visible = True
            DgExamView.Visible = True
            GridDataset(PageIndex)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " DataGrid Events"

    Private Sub DgExamView_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DgExamView.PageIndexChanged
        Try
            DgExamView.CurrentPageIndex = e.NewPageIndex
            Me.ViewState("PageIndex") = e.NewPageIndex
            DsSearchResult = Me.ViewState("DsSearchResult")
            DgExamView.DataSource = DsSearchResult
            DgExamView.DataBind()
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

End Class
