'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Student TC Summary and Details Form
'   AUTHOR                            : KISHORE
'   INITIAL BASELINE DATE             : 07-MAY-2013
'   MODIFICATIONS LOG                 : DETAILS & COURSE WISE SPLIT - CHANDRA 26/07/2014
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Imports System.Math
Public Class TCSummary
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents drpRZ As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblRZ As System.Web.UI.WebControls.Label
    Protected WithEvents rdbZone As System.Web.UI.WebControls.RadioButton
    Protected WithEvents drpReportType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents TableMain1 As System.Web.UI.WebControls.Table
    Protected WithEvents TableMain2 As System.Web.UI.WebControls.Table
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents LSTExamBranch As System.Web.UI.WebControls.ListBox
    Protected WithEvents BtnSelEB As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnSelEBAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemEB As System.Web.UI.WebControls.ImageButton
    Protected WithEvents BtnRemEBAll As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LSTSelExamBranch As System.Web.UI.WebControls.ListBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpReporton As System.Web.UI.WebControls.DropDownList
    Protected WithEvents iBtnReport As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents rdbVC As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdbDos As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdbRegion As System.Web.UI.WebControls.RadioButton
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpCourse As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ChkDetails As System.Web.UI.WebControls.CheckBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Class Variabales"
    Private USERSLNO As Integer
    Dim Util As New Utility
    Dim DsStudents, Ds As New DataSet
    Dim StrExamBranch, StrSql, StrSql1, StrSql2, StrSql3, SELECTEDBRANCHSLNO As String
    Private SORTCOLUMN, SORTTYPE As String
    Dim i, j, k As Integer
    'Private ReturnStr2 As String
    'Private dsReport2 As New DataSet
    'Private dvReport2 As New DataView
    'Private strSort As String
    Dim frmName As String
#End Region

#Region " PageEvents"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Put user code to initialize the page here
            If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
            USERSLNO = Session("USERSLNO")
            If Request.QueryString("SORTCOLUMN") <> "" Then
                Session("SORTCOLUMN") = Request.QueryString("SORTCOLUMN")
                SORTTYPE = Session("SORTTYPE")
                Session("SORTTYPE") = IIf(SORTTYPE = " DESC", " ASC", " DESC")
                DsStudents = Session("DsStudents")
                BranchWiseSummaryReportFormat()
                Table1.Visible = False
            Else
                If Not IsPostBack Then
                    FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                    'Region_Zone_Fill()
                    'FillExambranch()
                    ExamBranch_Region_Zone_Fill()
                    Table1.Visible = True
                    Session("SORTCOLUMN") = "NAME"
                    Session("SORTTYPE") = " ASC"
                End If
            End If
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

#Region "Methods"

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

    Private Function ValidateFunction() As Boolean
        If LSTSelExamBranch.Items.Count = 0 Then
            StartUpScript(LSTExamBranch.ID, "Select ExamBranch")
            Return False
        End If
        Return True
    End Function

    Private Function AddingColsToDataset(ByVal ds As DataSet) As DataSet
        Try
            Dim DtColCnt As Integer
            DtColCnt = ds.Tables(0).Columns.Count - 1
            ds.Tables(0).Columns.Add("1_ISSPER", Type.GetType("System.Double"))
            ds.Tables(0).Columns.Add("2_ISSPER", Type.GetType("System.Double"))
            ds.Tables(0).Columns.Add("TOT_STRN", Type.GetType("System.Int32"))
            ds.Tables(0).Columns.Add("TOT_ISSUED", Type.GetType("System.Int32"))
            ds.Tables(0).Columns.Add("TOT_ISSPER", Type.GetType("System.Double"))

            ds.Tables(0).Columns.Add("TOT_BAL", Type.GetType("System.Int32"))
            ds.Tables(0).Columns.Add("TOT_BALPER", Type.GetType("System.Double"))

            ds.Tables(0).Columns.Add("BAL_2", Type.GetType("System.Int32"))
            ds.Tables(0).Columns.Add("2_BALPER", Type.GetType("System.Double"))

            ds.Tables(0).Columns.Add("BAL_1", Type.GetType("System.Int32"))
            ds.Tables(0).Columns.Add("1_BALPER", Type.GetType("System.Double"))

            ds.Tables(0).Columns.Add("STRN_1", Type.GetType("System.Int32"))
            ds.Tables(0).Columns.Add("STRN_2", Type.GetType("System.Int32"))

            ds.Tables(0).Columns.Add("ISSUED_1", Type.GetType("System.Int32"))
            ds.Tables(0).Columns.Add("ISSUED_2", Type.GetType("System.Int32"))

            ds.Tables(0).Columns.Add("TOT_ENTER", Type.GetType("System.Int32"))
            ds.Tables(0).Columns.Add("ENTER_1", Type.GetType("System.Int32"))
            ds.Tables(0).Columns.Add("ENTER_2", Type.GetType("System.Int32"))

            ds.Tables(0).Columns.Add("TOT_ENTPER", Type.GetType("System.Double"))
            ds.Tables(0).Columns.Add("ENTPER_1", Type.GetType("System.Double"))
            ds.Tables(0).Columns.Add("ENTPER_2", Type.GetType("System.Double"))
            Dim Dr As DataRow
            Dim DblVal As Double = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dr = ds.Tables(0).Rows(i)

                If (IsDBNull(Dr(2)) Or Dr(2) = DblVal) Then
                    Dr(DtColCnt + 1) = 0
                Else
                    Dr(DtColCnt + 1) = (IIf(Not IsDBNull(Dr(5)), Dr(5), 0) / Dr(2).ToString * 100)
                End If

                If (IsDBNull(Dr(3)) Or Dr(3) = DblVal) Then
                    Dr(DtColCnt + 2) = 0
                Else
                    Dr(DtColCnt + 2) = (IIf(Not IsDBNull(Dr(6)), Dr(6), 0) / Dr(3).ToString * 100)
                End If

                Dr(DtColCnt + 3) = (IIf(Not IsDBNull(Dr(2)), Dr(2), 0) + IIf(Not IsDBNull(Dr(3)), Dr(3), 0))
                Dr(DtColCnt + 4) = (IIf(Not IsDBNull(Dr(5)), Dr(5), 0) + IIf(Not IsDBNull(Dr(6)), Dr(6), 0))

                If IsDBNull(Dr(9)) Or IsDBNull(Dr(10)) Then
                    'Val(Dr(9)) = 0 Or Val(Dr(10)) = 0
                    Dr(DtColCnt + 5) = 0
                ElseIf Dr(9) = 0.0 Or Dr(10) = DblVal Then
                    Dr(DtColCnt + 5) = (IIf(Not IsDBNull(Dr(13)), Dr(13), 0) / IIf(Not IsDBNull(Dr(12)), Dr(12), 0) * 100)
                    'Dr(DtColCnt + 5) = 0
                Else
                    Dr(DtColCnt + 5) = (IIf(Not IsDBNull(Dr(13)), Dr(13), 0) / IIf(Not IsDBNull(Dr(12)), Dr(12), 0) * 100)
                End If

                'Balance
                Dr(DtColCnt + 6) = (IIf(Not IsDBNull(Dr(12)), Dr(12), 0) - IIf(Not IsDBNull(Dr(13)), Dr(13), 0))
                'Dr(DtColCnt + 6) = (IIf(Not IsDBNull(Dr(9)), Dr(9), 0) - IIf(Not IsDBNull(Dr(10)), Dr(10), 0))
                If IsDBNull(Dr(11)) Or IsDBNull(Dr(9)) Then
                    Dr(DtColCnt + 7) = (IIf(Not IsDBNull(Dr(15)), Dr(15), 0) / IIf(Not IsDBNull(Dr(12)), Dr(12), 0) * 100)
                    'Dr(DtColCnt + 7) = 0
                ElseIf Dr(11) = DblVal Or Dr(8) = DblVal Then
                    Dr(DtColCnt + 7) = (IIf(Not IsDBNull(Dr(15)), Dr(15), 0) / IIf(Not IsDBNull(Dr(12)), Dr(12), 0) * 100)
                    'Dr(DtColCnt + 7) = 0
                Else
                    Dr(DtColCnt + 7) = (IIf(Not IsDBNull(Dr(15)), Dr(15), 0) / IIf(Not IsDBNull(Dr(12)), Dr(12), 0) * 100)
                End If

                Dr(DtColCnt + 8) = (IIf(Not IsDBNull(Dr(3)), Dr(3), 0) - IIf(Not IsDBNull(Dr(6)), Dr(6), 0))
                If IsDBNull(Dr(3)) Or IsDBNull(Dr(14)) Then
                    Dr(DtColCnt + 9) = 0
                ElseIf Dr(3) = DblVal Or Dr(14) = DblVal Then
                    Dr(DtColCnt + 9) = 0
                Else
                    Dr(DtColCnt + 9) = (IIf(Not IsDBNull(Dr(17)), Dr(17), 0) / IIf(Not IsDBNull(Dr(3)), Dr(3), 0) * 100)
                End If

                Dr(DtColCnt + 10) = (IIf(Not IsDBNull(Dr(2)), Dr(2), 0) - IIf(Not IsDBNull(Dr(5)), Dr(5), 0))
                If IsDBNull(Dr(2)) Or IsDBNull(Dr(16)) Then
                    Dr(DtColCnt + 11) = 0
                ElseIf Dr(2) = DblVal Or Dr(16) = DblVal Then
                    Dr(DtColCnt + 11) = 0
                Else
                    Dr(DtColCnt + 11) = (IIf(Not IsDBNull(Dr(19)), Dr(19), 0) / IIf(Not IsDBNull(Dr(2)), Dr(2), 0) * 100)
                End If
                Dr(DtColCnt + 12) = Dr(2)
                Dr(DtColCnt + 13) = Dr(3)

                Dr(DtColCnt + 14) = Dr(5)
                Dr(DtColCnt + 15) = Dr(6)
                Dr(DtColCnt + 16) = IIf(Not IsDBNull(Dr(8)), Dr(8), 0) + IIf(Not IsDBNull(Dr(9)), Dr(9), 0)
                Dr(DtColCnt + 17) = IIf(Not IsDBNull(Dr(8)), Dr(8), 0)
                Dr(DtColCnt + 18) = IIf(Not IsDBNull(Dr(9)), Dr(9), 0)

                If IsDBNull(Dr(DtColCnt + 3)) Or IsDBNull(Dr(DtColCnt + 16)) Then
                    Dr(DtColCnt + 19) = 0
                ElseIf Dr(DtColCnt + 3) = DblVal Or Dr(DtColCnt + 16) = DblVal Then
                    Dr(DtColCnt + 19) = 0
                Else
                    Dr(DtColCnt + 19) = (Dr(DtColCnt + 16) / Dr(DtColCnt + 3) * 100)
                End If

                If IsDBNull(Dr(DtColCnt + 16)) Or IsDBNull(Dr(DtColCnt + 17)) Or IsDBNull(Dr(DtColCnt + 18)) Then
                    Dr(DtColCnt + 20) = 0
                    Dr(DtColCnt + 21) = 0
                ElseIf Dr(DtColCnt + 16) = DblVal Or Dr(DtColCnt + 17) = DblVal Or Dr(DtColCnt + 18) = DblVal Then
                    Dr(DtColCnt + 20) = 0
                    Dr(DtColCnt + 21) = 0
                Else
                    Dr(DtColCnt + 20) = (Dr(8) / Dr(2) * 100)
                    Dr(DtColCnt + 21) = (Dr(9) / Dr(3) * 100)
                End If


                'Dr(DtColCnt + 20) = (Dr(DtColCnt + 17) / Dr(DtColCnt + 16) * 100)
                'Dr(DtColCnt + 21) = (Dr(DtColCnt + 18) / Dr(DtColCnt + 16) * 100)
            Next
            ds.Tables(0).AcceptChanges()
            Return ds
        Catch ex As Exception
            StartUpScript(iBtnReport.ID, " Error In Report / Contact Administrator ")
        End Try
    End Function

    Private Sub TblCellAlign(ByVal Tr As TableRow, ByVal str As String, ByVal NoE As Integer, ByVal Coltype As Integer, ByVal EbSlno As Integer, ByVal ResType As String, ByVal CVal As Integer)
        Try
            If str <> "." Then
                Dim StrPm As String
                'StrPm = "?ExSlno=" & ExSlno.ToString & " &EbSlno=" & EbSlno.ToString & " &ResType=" & ResType & "&CVal=" & IIf(CVal = 3, 1, CVal)
                StrPm = "&EbSlno=" & EbSlno.ToString & " &ResType=" & ResType & "&CVal=" & IIf(CVal = 3, 1, CVal)
                If Len(Trim(str)) = 1 Then
                    Tr.Cells.Add(EnteredstyleMul(str, 1, "M", Coltype, "", StrPm, frmName))
                Else
                    If NoE = 1 Then
                        Tr.Cells.Add(EnteredstyleMul(str, 1, "L", Coltype, "", StrPm, frmName))
                    ElseIf NoE = 2 Then
                        Tr.Cells.Add(EnteredstyleMul(str, 1, "M", Coltype, "", StrPm, frmName))
                    Else
                        Tr.Cells.Add(EnteredstyleMul(str, 1, "R", Coltype, "", StrPm, frmName))
                    End If
                End If
            Else
                Tr.Cells.Add(Enteredstyle("", 1, ""))
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Fill Methods"

    Private Sub ExamBranch_Region_Zone_Fill()
        ''DrpDisplay.Items.Clear()
        Try
            Dim dsERZ As DataSet
            Util = New Utility
            LSTExamBranch.Items.Clear()
            LSTSelExamBranch.Items.Clear()

            drpRZ.Items.Clear()


            If drpReportType.SelectedValue = 1 Then          '''THIS FOR EXAMBRANCH WISE 


                rdbZone.Enabled = True
                rdbDos.Enabled = True
                rdbVC.Enabled = True
                lblRZ.Enabled = True
                drpRZ.Enabled = True
                ChkDetails.Visible = True

                If rdbRegion.Checked Then   '''THIS FOR REGION SELECT

                    dsERZ = Util.Exam_UserWise_ExRegions(Session("USERSLNO"), Session("COMACADEMICSLNO"))
                    lblRZ.Text = vbCr & vbCr & vbCr & vbCr & "Division"
                    drpRZ.DataSource = dsERZ
                    drpRZ.DataTextField = "NAME"
                    drpRZ.DataValueField = "SLNO"
                    drpRZ.DataBind()
                    drpRZ.Items.Insert(0, New ListItem("All", 0))

                    dsERZ = Util.Exam_UserExRegionWise_EB(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))

                ElseIf rdbZone.Checked Then '''THIS FOR ZONE SELECT

                    dsERZ = Util.Exam_UserWise_Zones(Session("USERSLNO"), Session("COMACADEMICSLNO"))
                    lblRZ.Text = vbCr & vbCr & vbCr & vbCr & vbCr & vbCr & "Zone"
                    drpRZ.DataSource = dsERZ
                    drpRZ.DataTextField = "NAME"
                    drpRZ.DataValueField = "SLNO"
                    drpRZ.DataBind()
                    drpRZ.Items.Insert(0, New ListItem("All", 0))

                    dsERZ = Util.Exam_UserZoneWise_ExamBranch(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))

                ElseIf rdbDos.Checked Then '''THIS FOR D.Os SELECT

                    dsERZ = Util.Exam_UserWise_Dos(Session("USERSLNO"), Session("COMACADEMICSLNO"))
                    lblRZ.Text = vbCr & vbCr & vbCr & vbCr & vbCr & vbCr & "D.Os"
                    drpRZ.DataSource = dsERZ
                    drpRZ.DataTextField = "NAME"
                    drpRZ.DataValueField = "SLNO"
                    drpRZ.DataBind()
                    drpRZ.Items.Insert(0, New ListItem("All", 0))

                    dsERZ = Util.Exam_UserDosWise_ExamBranch(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))

                ElseIf rdbVC.Checked Then '''THIS FOR V.Cs SELECT

                    dsERZ = Util.Exam_UserWise_VC(Session("USERSLNO"), Session("COMACADEMICSLNO"))
                    lblRZ.Text = vbCr & vbCr & vbCr & vbCr & vbCr & vbCr & "V.C."
                    drpRZ.DataSource = dsERZ
                    drpRZ.DataTextField = "NAME"
                    drpRZ.DataValueField = "SLNO"
                    drpRZ.DataBind()
                    drpRZ.Items.Insert(0, New ListItem("All", 0))

                    dsERZ = Util.Exam_UserVCWise_ExamBranch(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))

                End If

            ElseIf drpReportType.SelectedValue = 2 Then     '''THIS FOR REGION WISE

                rdbRegion.Enabled = False
                rdbZone.Enabled = False
                rdbDos.Enabled = False
                rdbVC.Enabled = False
                lblRZ.Enabled = False
                drpRZ.Enabled = False
                ChkDetails.Visible = False

                dsERZ = Util.Exam_UserWise_ExRegions(Session("USERSLNO"), Session("COMACADEMICSLNO"))

            ElseIf drpReportType.SelectedValue = 3 Then     '''THIS FOR ZONE WISE

                rdbRegion.Enabled = False
                rdbZone.Enabled = False
                rdbDos.Enabled = False
                rdbVC.Enabled = False
                lblRZ.Enabled = False
                drpRZ.Enabled = False
                ChkDetails.Visible = False

                dsERZ = Util.Exam_UserWise_Zones(Session("USERSLNO"), Session("COMACADEMICSLNO"))

            ElseIf drpReportType.SelectedValue = 4 Then     '''THIS FOR D.Os WISE

                rdbRegion.Enabled = False
                rdbZone.Enabled = False
                rdbDos.Enabled = False
                rdbVC.Enabled = False
                lblRZ.Enabled = False
                drpRZ.Enabled = False
                ChkDetails.Visible = False

                dsERZ = Util.Exam_UserWise_Dos(Session("USERSLNO"), Session("COMACADEMICSLNO"))

            ElseIf drpReportType.SelectedValue = 2 Then     '''THIS FOR D.Os WISE

                rdbRegion.Enabled = False
                rdbZone.Enabled = False
                rdbDos.Enabled = False
                rdbVC.Enabled = False
                lblRZ.Enabled = False
                drpRZ.Enabled = False
                ChkDetails.Visible = False

                dsERZ = Util.Exam_UserWise_VC(Session("USERSLNO"), Session("COMACADEMICSLNO"))

            End If
            'End If

            LSTExamBranch.DataSource = dsERZ
            LSTExamBranch.DataTextField = "NAME"
            LSTExamBranch.DataValueField = "SLNO"
            LSTExamBranch.DataBind()

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Region_Zone_Fill()
        Try
            Dim dsRZ As DataSet
            Util = New Utility

            drpRZ.Items.Clear()

            If rdbDos.Checked Then
                dsRZ = Util.Exam_UserWise_ExRegions(Session("USERSLNO"), Session("COMACADEMICSLNO"))
                lblRZ.Text = "Division"
            ElseIf rdbZone.Checked Then
                dsRZ = Util.Exam_UserWise_Zones(Session("USERSLNO"), Session("COMACADEMICSLNO"))
                lblRZ.Text = "Zone"
            ElseIf rdbDos.Checked Then
                dsRZ = Util.Exam_UserWise_Dos(Session("USERSLNO"), Session("COMACADEMICSLNO"))
                lblRZ.Text = "VC"
            End If

            drpRZ.DataSource = dsRZ
            drpRZ.DataTextField = "NAME"
            drpRZ.DataValueField = "SLNO"
            drpRZ.DataBind()
            drpRZ.Items.Insert(0, New ListItem("All", 0))

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillExambranch1()
        Try
            Dim DsExambranch As DataSet
            Util = New Utility

            LSTExamBranch.Items.Clear()
            LSTSelExamBranch.Items.Clear()

            'If rdbDos.Checked Then
            '    DsExambranch = Util.Exam_UserExRegionWise_EB(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))
            'ElseIf rdbZone.Checked Then
            '    DsExambranch = Util.Exam_UserZoneWise_ExamBranch(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))
            'ElseIf rdbDos.Checked Then
            '    DsExambranch = Util.Exam_UserDosWise_ExamBranch(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))
            'End If

            If rdbRegion.Checked Then
                DsExambranch = Util.Exam_UserRegionWise_ExamBranch(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))
            ElseIf rdbDos.Checked Then
                DsExambranch = Util.Exam_UserExRegionWise_EB(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))
            ElseIf rdbZone.Checked Then
                DsExambranch = Util.Exam_UserZoneWise_ExamBranch(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))
            ElseIf rdbDos.Checked Then
                DsExambranch = Util.Exam_UserDosWise_ExamBranch(drpRZ.SelectedValue, Session("USERSLNO"), Session("COMACADEMICSLNO"))
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

    Private Sub FillExambranch()

        Try
            Dim SqlStr As String

            Dim DsExambranch As DataSet

            If drpReportType.SelectedValue = 1 Then ''Exam Branch Wise 

                If rdbRegion.Checked Then

                    SqlStr = " SELECT  DISTINCT EB.EXAMBRANCHSLNO,EB.EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE,EXAM_EXAMBRANCH BRA,EXAM_REGION_MT RM ," & _
                            " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & Session("USERSLNO") & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                            " AND BRA.EXAMBRANCHSLNO=EB.EXAMBRANCHSLNO  AND RM.EXAMREGIONSLNO=BRA.EXAMREGIONSLNO AND DE.DEXAMSLNO=EB.DEXAMSLNO AND RM.EXAMREGIONSLNO=" & drpRZ.SelectedValue.ToString & "  ORDER BY EXAMBRANCHNAME"


                ElseIf rdbZone.Checked Then

                    SqlStr = " SELECT  DISTINCT EB.EXAMBRANCHSLNO,EB.EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE,T_BRANCH_MT BRA,T_ZONE_MT RM ," & _
                            " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & Session("USERSLNO") & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                            " AND BRA.BRANCHSLNO=EB.BRANCHSLNO  AND RM.ZONESLNO=BRA.ZONESLNO AND DE.DEXAMSLNO=EB.DEXAMSLNO AND RM.ZONESLNO=" & drpRZ.SelectedValue.ToString & " ORDER BY EXAMBRANCHNAME"

                ElseIf rdbDos.Checked Then
                    SqlStr = " SELECT  DISTINCT EB.EXAMBRANCHSLNO,EB.EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE,T_BRANCH_MT BRA,T_DO_MT RM ," & _
                            " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & Session("USERSLNO") & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                            " AND BRA.BRANCHSLNO=EB.BRANCHSLNO  AND RM.DOSLNO=BRA.DOSLNO AND DE.DEXAMSLNO=EB.DEXAMSLNO AND RM.DOSLNO=" & drpRZ.SelectedValue.ToString & " ORDER BY EXAMBRANCHNAME"

                ElseIf rdbVC.Checked Then
                    SqlStr = " SELECT  DISTINCT EB.EXAMBRANCHSLNO,EB.EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE,T_BRANCH_MT BRA,T_VC_MT RM ," & _
                            " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & Session("USERSLNO") & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                            " AND BRA.BRANCHSLNO=EB.BRANCHSLNO  AND RM.VCSLNO=BRA.VCSLNO AND DE.DEXAMSLNO=EB.DEXAMSLNO  AND RM.VCSLNO=" & drpRZ.SelectedValue.ToString & "  ORDER BY EXAMBRANCHNAME"

                End If

                If drpRZ.SelectedValue = 0 Then

                    SqlStr = " SELECT  DISTINCT EB.EXAMBRANCHSLNO,EB.EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE," & _
                             " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & Session("USERSLNO") & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                             " AND DE.DEXAMSLNO=EB.DEXAMSLNO ORDER BY EB.EXAMBRANCHNAME"

                End If

            ElseIf drpReportType.SelectedValue = 2 Then ''Region Wise 

                SqlStr = " SELECT  DISTINCT RM.EXAMREGIONSLNO EXAMBRANCHSLNO,RM.NAME EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE,EXAM_EXAMBRANCH BRA,EXAM_REGION_MT RM ," & _
                         " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & Session("USERSLNO") & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                         " AND BRA.EXAMBRANCHSLNO=EB.EXAMBRANCHSLNO    AND RM.EXAMREGIONSLNO=BRA.EXAMREGIONSLNO AND DE.DEXAMSLNO=EB.DEXAMSLNO   ORDER BY EXAMBRANCHNAME "


            ElseIf drpReportType.SelectedValue = 3 Then ''Zone Wise 

                SqlStr = " SELECT  DISTINCT RM.ZONESLNO EXAMBRANCHSLNO,RM.NAME EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE,T_BRANCH_MT BRA,T_ZONE_MT RM ," & _
                         " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & Session("USERSLNO") & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                         " AND BRA.BRANCHSLNO=EB.BRANCHSLNO   AND RM.ZONESLNO=BRA.ZONESLNO AND DE.DEXAMSLNO=EB.DEXAMSLNO ORDER BY EXAMBRANCHNAME"

            ElseIf drpReportType.SelectedValue = 4 Then ''D.O's Wise 

                SqlStr = " SELECT  DISTINCT RM.DOSLNO EXAMBRANCHSLNO,RM.NAME EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE,T_BRANCH_MT BRA,T_DO_MT RM ," & _
                         " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & Session("USERSLNO") & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                         " AND BRA.BRANCHSLNO=EB.BRANCHSLNO   AND RM.DOSLNO=BRA.DOSLNO AND DE.DEXAMSLNO=EB.DEXAMSLNO ORDER BY EXAMBRANCHNAME"
            ElseIf drpReportType.SelectedValue = 2 Then ''V.C's Wise 

                SqlStr = " SELECT  DISTINCT RM.VCSLNO EXAMBRANCHSLNO,RM.NAME EXAMBRANCHNAME FROM EXAM_ECGB_MV EB,EXAM_DFINEEXAM DE,T_BRANCH_MT BRA,T_VC_MT RM ," & _
                         " E_USER_BRANCH_ACADEMIC_MT UEA WHERE UEA.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO AND UEA.USERSLNO=" & Session("USERSLNO") & " AND UEA.COMACADEMICSLNO= " & Session("COMACADEMICSLNO") & _
                         " AND BRA.BRANCHSLNO=EB.BRANCHSLNO   AND RM.VCSLNO=BRA.VCSLNO AND DE.DEXAMSLNO=EB.DEXAMSLNO ORDER BY EXAMBRANCHNAME"

            End If


            Util = New Utility
            DsExambranch = Util.GetCommDataSet(SqlStr)

            LSTExamBranch.DataSource = DsExambranch.Tables(0)
            LSTExamBranch.DataTextField = "EXAMBRANCHNAME"
            LSTExamBranch.DataValueField = "EXAMBRANCHSLNO"
            LSTExamBranch.DataBind()
            LSTExamBranch.SelectedIndex = 0

            LSTSelExamBranch.Items.Clear()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClearAllListBoxes()

        Commonfunctions.ClearListBox(LSTExamBranch)
        Commonfunctions.ClearListBox(LSTSelExamBranch)


    End Sub

#End Region

#Region "Selected Index Changed Events"

    Private Sub drpReportType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpReportType.SelectedIndexChanged
        Try
            ExamBranch_Region_Zone_Fill()
            'Region_Zone_Fill()
            'FillExambranch()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub rdbZone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbZone.CheckedChanged
        ExamBranch_Region_Zone_Fill()
        ClearAllListBoxes()
        'Region_Zone_Fill()
        FillExambranch()
    End Sub

    Private Sub rdbDos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDos.CheckedChanged
        ExamBranch_Region_Zone_Fill()
        ClearAllListBoxes()
        'Region_Zone_Fill()
        FillExambranch()
    End Sub

    Private Sub drpRZ_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpRZ.SelectedIndexChanged

        ClearAllListBoxes()
        FillExambranch()
        'ExamBranch_Region_Zone_Fill()
    End Sub

    Private Sub rdbRegion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbRegion.CheckedChanged
        ExamBranch_Region_Zone_Fill()
        ClearAllListBoxes()

        FillExambranch()
    End Sub

    Private Sub rdbVC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbVC.CheckedChanged
        ExamBranch_Region_Zone_Fill()
        ClearAllListBoxes()
        FillExambranch()
    End Sub

#End Region

#Region "ListButtonEvents"

#Region "Exam Branch"

    Private Sub BtnSelEB_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelEB.Click
        Try
            Dim i As Integer

            If Not LSTExamBranch.SelectedItem Is Nothing Then
                For i = 0 To LSTExamBranch.Items.Count - 1
                    If LSTExamBranch.Items(i).Selected = True Then
                        LSTSelExamBranch.Items.Add(LSTExamBranch.Items(i))
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

        Catch ex As Exception
            StartUpScript(BtnSelEB.ID, ex.Message)

        End Try
    End Sub

    Private Sub BtnSelEBAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSelEBAll.Click
        Try
            Dim iTotItems As Integer = LSTExamBranch.Items.Count - 1
            Dim i As Integer

            For i = 0 To iTotItems
                LSTSelExamBranch.Items.Add(LSTExamBranch.Items(i))
            Next
            LSTExamBranch.Items.Clear()

        Catch ex As Exception
            StartUpScript(BtnSelEBAll.ID, ex.Message)

        End Try
    End Sub

    Private Sub BtnRemEB_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemEB.Click
        Try
            Dim i As Integer
            If Not LSTSelExamBranch.SelectedItem Is Nothing Then
                For i = 0 To LSTSelExamBranch.Items.Count - 1
                    If LSTSelExamBranch.Items(i).Selected = True Then
                        LSTExamBranch.Items.Add(LSTSelExamBranch.Items(i))
                    End If
                Next

                i = 0
                Do
                    If LSTSelExamBranch.Items(i).Selected = True Then
                        LSTSelExamBranch.Items.Remove(LSTSelExamBranch.Items(i))
                    Else
                        i = i + 1
                    End If

                    If i = LSTSelExamBranch.Items.Count Then Exit Do
                Loop


            End If
            'Commonfunctions.ClearListBox(LSTSelEBranch)

        Catch ex As Exception
            StartUpScript(BtnRemEB.ID, ex.Message)

        End Try
    End Sub

    Private Sub BtnRemEBAll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRemEBAll.Click
        Try
            Dim i As Integer
            Dim iTotItems As Integer = LSTSelExamBranch.Items.Count - 1

            For i = 0 To iTotItems
                LSTExamBranch.Items.Add(LSTSelExamBranch.Items(i))
            Next
            LSTSelExamBranch.Items.Clear()
        Catch ex As Exception
            StartUpScript(BtnRemEBAll.ID, ex.Message)

        End Try
    End Sub

#End Region

#End Region

#Region "Sql Query"

    Private Function GenerateSqlQuery()

        Dim I As Integer
        Dim filterstring As String

        If drpReportType.SelectedValue = 1 Then
            StrExamBranch &= " AND ADM.EXAMBRANCHSLNO IN ("
        ElseIf drpReportType.SelectedValue = 3 Then
            StrExamBranch &= " AND Z.ZONESLNO IN ("
        ElseIf drpReportType.SelectedValue = 4 Then
            StrExamBranch &= " AND Z.VCSLNO IN ("
        ElseIf drpReportType.SelectedValue = 2 Then
            StrExamBranch &= " AND REG.EXAMREGIONSLNO IN (" 'Z.DIVISIONSLNO

        End If
        'EXAM BRANCHES
        If LSTSelExamBranch.Items.Count > 0 Then
            For I = 0 To LSTSelExamBranch.Items.Count - 1
                StrExamBranch &= Val(LSTSelExamBranch.Items(I).Value.ToString) & IIf(I = LSTSelExamBranch.Items.Count - 1, ")", ",")
            Next
        End If
        If DrpReporton.SelectedValue = 1 Then 'summary

            If drpReportType.SelectedValue = 1 Then ' EB
                

                StrSql = " SELECT A.EXAMBRANCHSLNO,A.EXAMBRANCHNAME NAME,A.TOTALSTRN,B.TCISSCOUNT,(A.TOTALSTRN - B.TCISSCOUNT) TCBAL,ROUND ( (B.TCISSCOUNT / A.TOTALSTRN) * 100, 2) ISSPER,ROUND ( ( (A.TOTALSTRN - B.TCISSCOUNT) / A.TOTALSTRN) * 100, 2) BALPER FROM (" & _
                         " SELECT ADM.EXAMBRANCHSLNO,EBN.EXAMBRANCHNAME,COUNT (ADM.ADMSLNO) TOTALSTRN FROM T_ADM_DT ADM, EXAM_EXAMBRANCH EBN WHERE     ADM.EXAMBRANCHSLNO = EBN.EXAMBRANCHSLNO AND ADM.STATUS IN (1, 5, 8) AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & " " & _
                         " GROUP BY ADM.EXAMBRANCHSLNO, EBN.EXAMBRANCHNAME ORDER BY ADM.EXAMBRANCHSLNO, EBN.EXAMBRANCHNAME) A,(SELECT ADM.EXAMBRANCHSLNO ,COUNT(EBD.TCISSUEDCOUNT) TCISSCOUNT FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD " & _
                         " WHERE   ADM.UNIQUENO = EBD.UNIQUENO(+) " & StrExamBranch & " AND ADM.STATUS IN (1, 5, 8)  AND ADM.COMACADEMICSLNO =  " & Session("COMACADEMICSLNO") & "   AND EBD.TCISSUEDCOUNT>0 AND ADM.COURSESLNO IN (1,2)  GROUP BY ADM.EXAMBRANCHSLNO)B " & _
                         " WHERE A.EXAMBRANCHSLNO = B.EXAMBRANCHSLNO(+) ORDER BY A.EXAMBRANCHSLNO, A.EXAMBRANCHNAME"


            ElseIf drpReportType.SelectedValue = 3 Then 'ZONE

                StrSql = "  SELECT A.ZONESLNO,A.NAME NAME,A.TOTALSTRN,B.TCISSCOUNT,(A.TOTALSTRN - B.TCISSCOUNT) TCBAL,ROUND ( (B.TCISSCOUNT / A.TOTALSTRN) * 100, 2) ISSPER,ROUND ( ( (A.TOTALSTRN - B.TCISSCOUNT) / A.TOTALSTRN) * 100, 2) BALPER" & _
                         "  FROM (  SELECT Z.ZONESLNO, Z.NAME, COUNT (ADM.ADMSLNO) TOTALSTRN FROM T_ADM_DT ADM, T_BRANCH_MT EBN, T_ZONE_MT Z WHERE     ADM.BRANCHSLNO = EBN.BRANCHSLNO AND EBN.ZONESLNO = Z.ZONESLNO AND ADM.STATUS IN (1, 5, 8) AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & " " & _
                         "  GROUP BY Z.ZONESLNO, Z.NAME ORDER BY Z.ZONESLNO, Z.NAME) A, (  SELECT Z.ZONESLNO, COUNT (EBD.TCISSUEDCOUNT) TCISSCOUNT FROM T_ADM_DT ADM, EXAM_BOARDSTUDENT_DT EBD, T_BRANCH_MT EBN, T_ZONE_MT Z " & _
                         "  WHERE  ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO AND EBN.ZONESLNO = Z.ZONESLNO AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & "  AND ADM.STATUS IN (1, 5, 8)    AND ADM.COMACADEMICSLNO=EBD.COMACADEMICSLNO(+)" & _
                         "  AND ADM.COURSESLNO IN (1, 2)  AND EBD.TCISSUEDCOUNT > 0     GROUP BY Z.ZONESLNO) B WHERE A.ZONESLNO = B.ZONESLNO(+)   ORDER BY A.ZONESLNO, A.NAME"


            ElseIf drpReportType.SelectedValue = 4 Then 'VC

                StrSql = " SELECT A.VCSLNO,A.NAME NAME,A.TOTALSTRN,B.TCISSCOUNT,(A.TOTALSTRN - B.TCISSCOUNT) TCBAL,ROUND ( (B.TCISSCOUNT / A.TOTALSTRN) * 100, 2) ISSPER,ROUND ( ( (A.TOTALSTRN - B.TCISSCOUNT) / A.TOTALSTRN) * 100, 2) BALPER" & _
                         " FROM (  SELECT Z.VCSLNO, Z.NAME, COUNT (ADM.ADMSLNO) TOTALSTRN FROM T_ADM_DT ADM, T_BRANCH_MT EBN, T_VC_MT Z WHERE     ADM.BRANCHSLNO = EBN.BRANCHSLNO AND EBN.VCSLNO = Z.VCSLNO AND ADM.STATUS IN (1, 5, 8) AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & "  " & _
                         " GROUP BY Z.VCSLNO, Z.NAME ORDER BY Z.VCSLNO, Z.NAME) A, (  SELECT Z.VCSLNO, COUNT (EBD.TCISSUEDCOUNT) TCISSCOUNT FROM T_ADM_DT ADM, EXAM_BOARDSTUDENT_DT EBD, T_BRANCH_MT EBN, T_VC_MT Z" & _
                         " WHERE  ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO AND EBN.VCSLNO = Z.VCSLNO AND ADM.COMACADEMICSLNO =  " & Session("COMACADEMICSLNO") & " AND ADM.STATUS IN (1, 5, 8)    AND ADM.COMACADEMICSLNO=EBD.COMACADEMICSLNO(+)" & _
                         " AND ADM.COURSESLNO IN (1, 2)  AND EBD.TCISSUEDCOUNT > 0     GROUP BY Z.VCSLNO) B WHERE A.VCSLNO = B.VCSLNO(+)   ORDER BY A.VCSLNO, A.NAME"



            ElseIf drpReportType.SelectedValue = 2 Then 'DIVION
                


                'StrSql = " SELECT A.DIVISIONSLNO,A.NAME NAME,A.TOTALSTRN,B.TCISSCOUNT,(A.TOTALSTRN - B.TCISSCOUNT) TCBAL,ROUND ( (B.TCISSCOUNT / A.TOTALSTRN) * 100, 2) ISSPER,ROUND ( ( (A.TOTALSTRN - B.TCISSCOUNT) / A.TOTALSTRN) * 100, 2) BALPER" & _
                '        " FROM (  SELECT Z.DIVISIONSLNO, Z.NAME, COUNT (ADM.ADMSLNO) TOTALSTRN FROM T_ADM_DT ADM, T_BRANCH_MT EBN, T_DIVISION_MT Z WHERE     ADM.BRANCHSLNO = EBN.BRANCHSLNO AND EBN.DIVISIONSLNO = Z.DIVISIONSLNO AND ADM.STATUS IN (1, 5, 8) AND ADM.COMACADEMICSLNO =" & Session("COMACADEMICSLNO") & StrExamBranch & " " & _
                '        " GROUP BY Z.DIVISIONSLNO, Z.NAME ORDER BY Z.DIVISIONSLNO, Z.NAME) A, (  SELECT Z.DIVISIONSLNO, COUNT (EBD.TCISSUEDCOUNT) TCISSCOUNT FROM T_ADM_DT ADM, EXAM_BOARDSTUDENT_DT EBD, T_BRANCH_MT EBN, T_DIVISION_MT Z" & _
                '        " WHERE  ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO AND EBN.DIVISIONSLNO = Z.DIVISIONSLNO AND ADM.COMACADEMICSLNO =  " & Session("COMACADEMICSLNO") & " AND ADM.STATUS IN (1, 5, 8)    AND ADM.COMACADEMICSLNO=EBD.COMACADEMICSLNO(+)" & _
                '        " AND ADM.COURSESLNO IN (1, 2)  AND EBD.TCISSUEDCOUNT > 0     GROUP BY Z.DIVISIONSLNO) B WHERE A.DIVISIONSLNO = B.DIVISIONSLNO(+)   ORDER BY A.DIVISIONSLNO, A.NAME"

                StrSql = " SELECT A.EXAMREGIONSLNO DIVISIONSLNO,A.NAME NAME,A.TOTALSTRN,B.TCISSCOUNT,(A.TOTALSTRN - B.TCISSCOUNT) TCBAL,ROUND ( (B.TCISSCOUNT / A.TOTALSTRN) * 100, 2) ISSPER,ROUND ( ( (A.TOTALSTRN - B.TCISSCOUNT) / A.TOTALSTRN) * 100, 2) BALPER" & _
                         " FROM ( SELECT EB.EXAMREGIONSLNO, REG.NAME, COUNT (ADM.ADMSLNO) TOTALSTRN FROM T_ADM_DT ADM, EXAM_REGION_MT REG, EXAM_EXAMBRANCH EB WHERE   ADM.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO" & _
                         " AND EB.EXAMREGIONSLNO = REG.EXAMREGIONSLNO AND ADM.STATUS IN (1, 5, 8) AND ADM.COURSESLNO IN (1, 2) AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & "   GROUP BY EB.EXAMREGIONSLNO, REG.NAME ORDER BY REG.EXAMREGIONSLNO, REG.NAME) A," & _
                         " (SELECT EB.EXAMREGIONSLNO, COUNT (EBD.TCISSUEDCOUNT) TCISSCOUNT FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,EXAM_REGION_MT REG,EXAM_EXAMBRANCH EB" & _
                         " WHERE ADM.UNIQUENO = EBD.UNIQUENO And ADM.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO And EB.EXAMREGIONSLNO = REG.EXAMREGIONSLNO And ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & " " & _
                         " AND ADM.STATUS IN (1, 5, 8) AND ADM.COMACADEMICSLNO = EBD.COMACADEMICSLNO(+)AND ADM.COURSESLNO IN (1, 2) AND EBD.TCISSUEDCOUNT > 0  " & StrExamBranch & "  GROUP BY EB.EXAMREGIONSLNO) B " & _
                         " WHERE A.EXAMREGIONSLNO = B.EXAMREGIONSLNO(+) ORDER BY A.EXAMREGIONSLNO, A.NAME"



            End If


        ElseIf DrpReporton.SelectedValue = 2 Then 'details


            If DrpCourse.SelectedValue <> 0 Then

                filterstring &= " and adm.courseslno=" & DrpCourse.SelectedValue
            End If

            If drpReportType.SelectedValue = 1 Then ' EB

                StrSql = " SELECT EBD.BOARDADMNO,ADM.ADMNO,ADM.NAME || '   ' || ADM.SURNAME BOARDNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME|| ' / '|| SEC.SECTION|| ' / '|| TYP.NAME|| ' / '|| MED.NAME CODE,ADM.EXAMBRANCHSLNO,EBN.EXAMBRANCHNAME,EBD.TCISSUEDCOUNT TCISSUE,TO_CHAR(EBD.TCISSUEDDATE,'DD/MM/YYYY') TCDATE " & _
                        " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,EXAM_EXAMBRANCH EBN,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED" & _
                        " WHERE     ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.EXAMBRANCHSLNO = EBN.EXAMBRANCHSLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                        " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+) AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+) AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO AND ADM.STATUS IN (1, 5, 8)  AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & filterstring & " " & _
                        " GROUP BY EBD.BOARDADMNO,ADM.ADMNO,ADM.NAME || '   ' || ADM.SURNAME, ADM.EXAMBRANCHSLNO, EBN.EXAMBRANCHNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME|| ' / '|| SEC.SECTION|| ' / '|| TYP.NAME|| ' / '|| MED.NAME,EBD.TCISSUEDCOUNT,EBD.TCISSUEDDATE ORDER BY EBN.EXAMBRANCHNAME  "
                'StrSql += filterstring + " ORDER BY EBN.EXAMBRANCHNAME "

            ElseIf drpReportType.SelectedValue = 3 Then 'ZONE

                StrSql = " SELECT EBD.BOARDADMNO,ADM.ADMNO,  ADM.NAME || '   ' || ADM.SURNAME BOARDNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME CODE, Z.ZONESLNO, Z.NAME,EBD.TCISSUEDCOUNT TCISSUE,TO_CHAR(EBD.TCISSUEDDATE,'DD/MM/YYYY') TCDATE" & _
                         " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,T_BRANCH_MT EBN,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED,T_ZONE_MT Z" & _
                         " WHERE     ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO(+) AND EBN.ZONESLNO = Z.ZONESLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO  AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                         " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+)  AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+)  AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO  AND ADM.STATUS IN (1, 5, 8)   AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & filterstring & " GROUP BY EBD.BOARDADMNO," & _
                         " Z.NAME,ADM.ADMNO, ADM.NAME || '   ' || ADM.SURNAME,Z.ZONESLNO, COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME , EBD.TCISSUEDCOUNT,EBD.TCISSUEDDATE ORDER BY Z.NAME "

                'StrSql += filterstring + " ORDER BY Z.NAME "

            ElseIf drpReportType.SelectedValue = 4 Then 'VC

                StrSql = " SELECT EBD.BOARDADMNO,ADM.ADMNO, ADM.NAME || '   ' || ADM.SURNAME BOARDNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME CODE, Z.VCSLNO, Z.NAME,EBD.TCISSUEDCOUNT TCISSUE,TO_CHAR(EBD.TCISSUEDDATE,'DD/MM/YYYY') TCDATE" & _
                        " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,T_BRANCH_MT EBN,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED,T_VC_MT Z" & _
                        " WHERE     ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO(+) AND EBN.VCSLNO = Z.VCSLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO  AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                        " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+)  AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+)  AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO  AND ADM.STATUS IN (1, 5, 8)   AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & filterstring & "  GROUP BY EBD.BOARDADMNO," & _
                        " Z.NAME,ADM.ADMNO, ADM.NAME || '   ' || ADM.SURNAME,Z.VCSLNO, COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME , EBD.TCISSUEDCOUNT,EBD.TCISSUEDDATE ORDER BY Z.NAME "

                'StrSql += filterstring + " ORDER BY Z.NAME "

            ElseIf drpReportType.SelectedValue = 2 Then 'DIVION

                'StrSql = " SELECT EBD.BOARDADMNO,ADM.ADMNO,  ADM.NAME || '   ' || ADM.SURNAME BOARDNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME CODE, Z.DIVISIONSLNO, Z.NAME,EBD.TCISSUEDCOUNT TCISSUE" & _
                '         " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,T_BRANCH_MT EBN,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED,T_DIVISION_MT Z " & _
                '         " WHERE     ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO(+) AND EBN.DIVISIONSLNO = Z.DIVISIONSLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO  AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                '         " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+)  AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+)  AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO  AND ADM.STATUS IN (1, 5, 8)   AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & "  GROUP BY EBD.BOARDADMNO," & _
                '         " Z.NAME,ADM.ADMNO, ADM.NAME || '   ' || ADM.SURNAME,Z.DIVISIONSLNO, COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME , EBD.TCISSUEDCOUNT ORDER BY Z.NAME"

                StrSql = " SELECT EBD.BOARDADMNO,ADM.ADMNO,ADM.NAME || '   ' || ADM.SURNAME BOARDNAME,COR.NAME|| ' / '|| GRP.NAME || ' / '|| BAT.NAME || ' / '|| SBT.NAME || ' / ' || SEC.SECTION|| ' / ' || TYP.NAME || ' / ' || MED.NAME CODE,EB.EXAMREGIONSLNO,REG.NAME,EBD.TCISSUEDCOUNT TCISSUE,TO_CHAR(EBD.TCISSUEDDATE,'DD/MM/YYYY') TCDATE" & _
                         " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,T_BRANCH_MT EBN,T_COURSE_MT COR,T_GROUP_MT GRP, T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC, T_STUTYPE_MT TYP,T_MEDIUM_MT MED,EXAM_REGION_MT REG, EXAM_EXAMBRANCH EB" & _
                         " WHERE ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO(+) AND ADM.EXAMBRANCHSLNO=EB.EXAMBRANCHSLNO AND EB.EXAMREGIONSLNO = REG.EXAMREGIONSLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO  AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                         " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+) AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+) AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO AND ADM.STATUS IN (1, 5, 8) AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & filterstring & " GROUP BY EBD.BOARDADMNO,REG.NAME,ADM.ADMNO," & _
                         " ADM.NAME || '   ' || ADM.SURNAME,EB.EXAMREGIONSLNO,COR.NAME|| ' / '|| GRP.NAME || ' / '|| BAT.NAME|| ' / ' || SBT.NAME || ' / '|| SEC.SECTION|| ' / ' || TYP.NAME|| ' / '|| MED.NAME,EBD.TCISSUEDCOUNT,EBD.TCISSUEDDATE ORDER BY REG.NAME "

                'StrSql += filterstring + " ORDER BY REG.NAME "

            End If


            End If

        'StrSql += filterstring



    End Function

    Private Function GenerateSqlQueryMod()

        Dim I As Integer

        If drpReportType.SelectedValue = 1 Then
            StrExamBranch &= " EXAMBRANCHSLNO IN ("
        ElseIf drpReportType.SelectedValue = 3 Then
            StrExamBranch &= " ZONESLNO IN ("
        ElseIf drpReportType.SelectedValue = 4 Then
            StrExamBranch &= " AND Z.VCSLNO IN ("
        ElseIf drpReportType.SelectedValue = 2 Then
            StrExamBranch &= " EXAMREGIONSLNO IN (" 'Z.DIVISIONSLNO

        End If
        'EXAM BRANCHES
        If LSTSelExamBranch.Items.Count > 0 Then
            For I = 0 To LSTSelExamBranch.Items.Count - 1
                StrExamBranch &= Val(LSTSelExamBranch.Items(I).Value.ToString) & IIf(I = LSTSelExamBranch.Items.Count - 1, ")", ",")
            Next
        End If

        'Dim SqlCourse As String
        'SqlCourse = "SELECT COURSESLNO FROM T_COURSE_MT WHERE TCSTATUS=1"
        'Util = New Utility
        'Ds = Util.DataSet_OneFetch(SqlCourse)

        'For I = 0 To Ds.Tables(0).Rows.Count - 1

        'Next
        Dim StrCourse As String

        If DrpCourse.SelectedValue = 0 Then
            StrCourse = "COURSESLNO IN(1,2,6,7)"
        ElseIf DrpCourse.SelectedValue = 1 Then
            StrCourse = "COURSESLNO IN(1,6)"
        ElseIf DrpCourse.SelectedValue = 2 Then
            StrCourse = "COURSESLNO IN(2,7)"
        End If
        If DrpReporton.SelectedValue = 1 Then 'summary

            StrSql = " SELECT C.EXAMBRANCHNAME NAME,A.*,B.*,D.*  FROM (SELECT * FROM (SELECT C.EXAMBRANCHSLNO,C.COURSESLNO FROM DO_ZON_REG_ADMDT C WHERE C.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND C." & StrExamBranch & " AND C." & StrCourse & ") PIVOT (COUNT(*) AS STRN" & _
                     " FOR " & StrCourse & ")) A,(SELECT * FROM (SELECT B.EXAMBRANCHSLNO,B.COURSESLNO,A.TCISSUEDCOUNT FROM EXAM_BOARDSTUDENT_DT A,DO_ZON_REG_ADMDT B WHERE A.UNIQUENO=B.UNIQUENO AND B.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND B." & StrExamBranch & " AND A.TCISSUEDCOUNT>0 AND B." & StrCourse & " ) PIVOT (COUNT(TCISSUEDCOUNT) ISSUED" & _
                     " FOR " & StrCourse & ")) B,(SELECT * FROM (SELECT B.EXAMBRANCHSLNO,B.COURSESLNO,A.TCISSUEDCOUNT FROM EXAM_BOARDSTUDENT_DT A,DO_ZON_REG_ADMDT B WHERE A.UNIQUENO=B.UNIQUENO AND B.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND B." & StrExamBranch & " AND B." & StrCourse & ") PIVOT (COUNT(TCISSUEDCOUNT) ENTER " & _
                     " FOR " & StrCourse & ")) D, EXAM_EXAMBRANCH C WHERE A.EXAMBRANCHSLNO=B.EXAMBRANCHSLNO(+) AND A.EXAMBRANCHSLNO=D.EXAMBRANCHSLNO(+) AND A.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO"


            'StrSql = " SELECT C.EXAMBRANCHNAME NAME,A.*,B.*,D.*  FROM (SELECT * FROM (SELECT C.EXAMBRANCHSLNO,C.COURSESLNO FROM DO_ZON_REG_ADMDT C WHERE C.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND C." & StrExamBranch & " AND C." & StrCourse & ") PIVOT (COUNT(*) AS STRN" & _
            '         " FOR (COURSESLNO) IN (1,2))) A,(SELECT * FROM (SELECT B.EXAMBRANCHSLNO,B.COURSESLNO,A.TCISSUEDCOUNT FROM EXAM_BOARDSTUDENT_DT A,DO_ZON_REG_ADMDT B WHERE A.UNIQUENO=B.UNIQUENO AND B.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND B." & StrExamBranch & " AND A.TCISSUEDCOUNT>0 AND B." & StrCourse & " ) PIVOT (COUNT(TCISSUEDCOUNT) ISSUED" & _
            '         " FOR (COURSESLNO) IN (1,2))) B,(SELECT * FROM (SELECT B.EXAMBRANCHSLNO,B.COURSESLNO,A.TCISSUEDCOUNT FROM EXAM_BOARDSTUDENT_DT A,DO_ZON_REG_ADMDT B WHERE A.UNIQUENO=B.UNIQUENO AND B.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND B." & StrExamBranch & " AND B." & StrCourse & ") PIVOT (COUNT(TCISSUEDCOUNT) ENTER " & _
            '         " FOR (COURSESLNO) IN (1,2))) D, EXAM_EXAMBRANCH C WHERE A.EXAMBRANCHSLNO=B.EXAMBRANCHSLNO(+) AND A.EXAMBRANCHSLNO=D.EXAMBRANCHSLNO(+) AND A.EXAMBRANCHSLNO=C.EXAMBRANCHSLNO"

            If drpReportType.SelectedValue = 1 Then ' EB


                'StrSql = " SELECT A.EXAMBRANCHSLNO,A.EXAMBRANCHNAME NAME,A.TOTALSTRN,B.TCISSCOUNT,(A.TOTALSTRN - B.TCISSCOUNT) TCBAL,ROUND ( (B.TCISSCOUNT / A.TOTALSTRN) * 100, 2) ISSPER,ROUND ( ( (A.TOTALSTRN - B.TCISSCOUNT) / A.TOTALSTRN) * 100, 2) BALPER FROM (" & _
                '         " SELECT ADM.EXAMBRANCHSLNO,EBN.EXAMBRANCHNAME,COUNT (ADM.ADMSLNO) TOTALSTRN FROM T_ADM_DT ADM, EXAM_EXAMBRANCH EBN WHERE     ADM.EXAMBRANCHSLNO = EBN.EXAMBRANCHSLNO AND ADM.STATUS IN (1, 5, 8) AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & " " & _
                '         " GROUP BY ADM.EXAMBRANCHSLNO, EBN.EXAMBRANCHNAME ORDER BY ADM.EXAMBRANCHSLNO, EBN.EXAMBRANCHNAME) A,(SELECT ADM.EXAMBRANCHSLNO ,COUNT(EBD.TCISSUEDCOUNT) TCISSCOUNT FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD " & _
                '         " WHERE   ADM.UNIQUENO = EBD.UNIQUENO(+) " & StrExamBranch & " AND ADM.STATUS IN (1, 5, 8)  AND ADM.COMACADEMICSLNO =  " & Session("COMACADEMICSLNO") & "   AND EBD.TCISSUEDCOUNT>0 AND ADM.COURSESLNO IN (1,2)  GROUP BY ADM.EXAMBRANCHSLNO)B " & _
                '         " WHERE A.EXAMBRANCHSLNO = B.EXAMBRANCHSLNO(+) ORDER BY A.EXAMBRANCHSLNO, A.EXAMBRANCHNAME"


            ElseIf drpReportType.SelectedValue = 3 Then 'ZONE

                StrSql = StrSql.Replace("EXAMBRANCHSLNO", "ZONESLNO")
                StrSql = StrSql.Replace("EXAMBRANCHNAME", "NAME")
                StrSql = StrSql.Replace("EXAM_EXAMBRANCH", "T_ZONE_MT")

                'StrSql = "  SELECT A.ZONESLNO,A.NAME NAME,A.TOTALSTRN,B.TCISSCOUNT,(A.TOTALSTRN - B.TCISSCOUNT) TCBAL,ROUND ( (B.TCISSCOUNT / A.TOTALSTRN) * 100, 2) ISSPER,ROUND ( ( (A.TOTALSTRN - B.TCISSCOUNT) / A.TOTALSTRN) * 100, 2) BALPER" & _
                '         "  FROM (  SELECT Z.ZONESLNO, Z.NAME, COUNT (ADM.ADMSLNO) TOTALSTRN FROM T_ADM_DT ADM, T_BRANCH_MT EBN, T_ZONE_MT Z WHERE     ADM.BRANCHSLNO = EBN.BRANCHSLNO AND EBN.ZONESLNO = Z.ZONESLNO AND ADM.STATUS IN (1, 5, 8) AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & " " & _
                '         "  GROUP BY Z.ZONESLNO, Z.NAME ORDER BY Z.ZONESLNO, Z.NAME) A, (  SELECT Z.ZONESLNO, COUNT (EBD.TCISSUEDCOUNT) TCISSCOUNT FROM T_ADM_DT ADM, EXAM_BOARDSTUDENT_DT EBD, T_BRANCH_MT EBN, T_ZONE_MT Z " & _
                '         "  WHERE  ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO AND EBN.ZONESLNO = Z.ZONESLNO AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & "  AND ADM.STATUS IN (1, 5, 8)    AND ADM.COMACADEMICSLNO=EBD.COMACADEMICSLNO(+)" & _
                '         "  AND ADM.COURSESLNO IN (1, 2)  AND EBD.TCISSUEDCOUNT > 0     GROUP BY Z.ZONESLNO) B WHERE A.ZONESLNO = B.ZONESLNO(+)   ORDER BY A.ZONESLNO, A.NAME"


            ElseIf drpReportType.SelectedValue = 4 Then 'VC

                'StrSql = " SELECT A.VCSLNO,A.NAME NAME,A.TOTALSTRN,B.TCISSCOUNT,(A.TOTALSTRN - B.TCISSCOUNT) TCBAL,ROUND ( (B.TCISSCOUNT / A.TOTALSTRN) * 100, 2) ISSPER,ROUND ( ( (A.TOTALSTRN - B.TCISSCOUNT) / A.TOTALSTRN) * 100, 2) BALPER" & _
                '         " FROM (  SELECT Z.VCSLNO, Z.NAME, COUNT (ADM.ADMSLNO) TOTALSTRN FROM T_ADM_DT ADM, T_BRANCH_MT EBN, T_VC_MT Z WHERE     ADM.BRANCHSLNO = EBN.BRANCHSLNO AND EBN.VCSLNO = Z.VCSLNO AND ADM.STATUS IN (1, 5, 8) AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & "  " & _
                '         " GROUP BY Z.VCSLNO, Z.NAME ORDER BY Z.VCSLNO, Z.NAME) A, (  SELECT Z.VCSLNO, COUNT (EBD.TCISSUEDCOUNT) TCISSCOUNT FROM T_ADM_DT ADM, EXAM_BOARDSTUDENT_DT EBD, T_BRANCH_MT EBN, T_VC_MT Z" & _
                '         " WHERE  ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO AND EBN.VCSLNO = Z.VCSLNO AND ADM.COMACADEMICSLNO =  " & Session("COMACADEMICSLNO") & " AND ADM.STATUS IN (1, 5, 8)    AND ADM.COMACADEMICSLNO=EBD.COMACADEMICSLNO(+)" & _
                '         " AND ADM.COURSESLNO IN (1, 2)  AND EBD.TCISSUEDCOUNT > 0     GROUP BY Z.VCSLNO) B WHERE A.VCSLNO = B.VCSLNO(+)   ORDER BY A.VCSLNO, A.NAME"



            ElseIf drpReportType.SelectedValue = 2 Then 'DIVION

                StrSql = StrSql.Replace("EXAMBRANCHSLNO", "EXAMREGIONSLNO")
                StrSql = StrSql.Replace("EXAMBRANCHNAME", "NAME")
                StrSql = StrSql.Replace("EXAM_EXAMBRANCH", "EXAM_REGION_MT")

                'StrSql = " SELECT A.DIVISIONSLNO,A.NAME NAME,A.TOTALSTRN,B.TCISSCOUNT,(A.TOTALSTRN - B.TCISSCOUNT) TCBAL,ROUND ( (B.TCISSCOUNT / A.TOTALSTRN) * 100, 2) ISSPER,ROUND ( ( (A.TOTALSTRN - B.TCISSCOUNT) / A.TOTALSTRN) * 100, 2) BALPER" & _
                '        " FROM (  SELECT Z.DIVISIONSLNO, Z.NAME, COUNT (ADM.ADMSLNO) TOTALSTRN FROM T_ADM_DT ADM, T_BRANCH_MT EBN, T_DIVISION_MT Z WHERE     ADM.BRANCHSLNO = EBN.BRANCHSLNO AND EBN.DIVISIONSLNO = Z.DIVISIONSLNO AND ADM.STATUS IN (1, 5, 8) AND ADM.COMACADEMICSLNO =" & Session("COMACADEMICSLNO") & StrExamBranch & " " & _
                '        " GROUP BY Z.DIVISIONSLNO, Z.NAME ORDER BY Z.DIVISIONSLNO, Z.NAME) A, (  SELECT Z.DIVISIONSLNO, COUNT (EBD.TCISSUEDCOUNT) TCISSCOUNT FROM T_ADM_DT ADM, EXAM_BOARDSTUDENT_DT EBD, T_BRANCH_MT EBN, T_DIVISION_MT Z" & _
                '        " WHERE  ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO AND EBN.DIVISIONSLNO = Z.DIVISIONSLNO AND ADM.COMACADEMICSLNO =  " & Session("COMACADEMICSLNO") & " AND ADM.STATUS IN (1, 5, 8)    AND ADM.COMACADEMICSLNO=EBD.COMACADEMICSLNO(+)" & _
                '        " AND ADM.COURSESLNO IN (1, 2)  AND EBD.TCISSUEDCOUNT > 0     GROUP BY Z.DIVISIONSLNO) B WHERE A.DIVISIONSLNO = B.DIVISIONSLNO(+)   ORDER BY A.DIVISIONSLNO, A.NAME"

                'StrSql = " SELECT A.EXAMREGIONSLNO DIVISIONSLNO,A.NAME NAME,A.TOTALSTRN,B.TCISSCOUNT,(A.TOTALSTRN - B.TCISSCOUNT) TCBAL,ROUND ( (B.TCISSCOUNT / A.TOTALSTRN) * 100, 2) ISSPER,ROUND ( ( (A.TOTALSTRN - B.TCISSCOUNT) / A.TOTALSTRN) * 100, 2) BALPER" & _
                '         " FROM ( SELECT EB.EXAMREGIONSLNO, REG.NAME, COUNT (ADM.ADMSLNO) TOTALSTRN FROM T_ADM_DT ADM, EXAM_REGION_MT REG, EXAM_EXAMBRANCH EB WHERE   ADM.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO" & _
                '         " AND EB.EXAMREGIONSLNO = REG.EXAMREGIONSLNO AND ADM.STATUS IN (1, 5, 8) AND ADM.COURSESLNO IN (1, 2) AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & "   GROUP BY EB.EXAMREGIONSLNO, REG.NAME ORDER BY REG.EXAMREGIONSLNO, REG.NAME) A," & _
                '         " (SELECT EB.EXAMREGIONSLNO, COUNT (EBD.TCISSUEDCOUNT) TCISSCOUNT FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,EXAM_REGION_MT REG,EXAM_EXAMBRANCH EB" & _
                '         " WHERE ADM.UNIQUENO = EBD.UNIQUENO And ADM.EXAMBRANCHSLNO = EB.EXAMBRANCHSLNO And EB.EXAMREGIONSLNO = REG.EXAMREGIONSLNO And ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & " " & _
                '         " AND ADM.STATUS IN (1, 5, 8) AND ADM.COMACADEMICSLNO = EBD.COMACADEMICSLNO(+)AND ADM.COURSESLNO IN (1, 2) AND EBD.TCISSUEDCOUNT > 0  " & StrExamBranch & "  GROUP BY EB.EXAMREGIONSLNO) B " & _
                '         " WHERE A.EXAMREGIONSLNO = B.EXAMREGIONSLNO(+) ORDER BY A.EXAMREGIONSLNO, A.NAME"



            End If


        ElseIf DrpReporton.SelectedValue = 2 Then 'details

            If drpReportType.SelectedValue = 1 Then ' EB

                StrSql = " SELECT EBD.BOARDADMNO,ADM.ADMNO,ADM.NAME || '   ' || ADM.SURNAME BOARDNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME|| ' / '|| SEC.SECTION|| ' / '|| TYP.NAME|| ' / '|| MED.NAME CODE,ADM.EXAMBRANCHSLNO,EBN.EXAMBRANCHNAME,EBD.TCISSUEDCOUNT TCISSUE" & _
                        " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,EXAM_EXAMBRANCH EBN,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED" & _
                        " WHERE     ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.EXAMBRANCHSLNO = EBN.EXAMBRANCHSLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                        " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+) AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+) AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO AND ADM.STATUS IN (1, 5, 8)  AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & " " & _
                        " GROUP BY EBD.BOARDADMNO,ADM.ADMNO,ADM.NAME || '   ' || ADM.SURNAME, ADM.EXAMBRANCHSLNO, EBN.EXAMBRANCHNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME|| ' / '|| SEC.SECTION|| ' / '|| TYP.NAME|| ' / '|| MED.NAME,EBD.TCISSUEDCOUNT  ORDER BY EBN.EXAMBRANCHNAME "

            ElseIf drpReportType.SelectedValue = 3 Then 'ZONE

                StrSql = " SELECT EBD.BOARDADMNO,ADM.ADMNO,  ADM.NAME || '   ' || ADM.SURNAME BOARDNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME CODE, Z.ZONESLNO, Z.NAME,EBD.TCISSUEDCOUNT TCISSUE" & _
                         " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,T_BRANCH_MT EBN,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED,T_ZONE_MT Z" & _
                         " WHERE     ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO(+) AND EBN.ZONESLNO = Z.ZONESLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO  AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                         " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+)  AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+)  AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO  AND ADM.STATUS IN (1, 5, 8)   AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & "  GROUP BY EBD.BOARDADMNO," & _
                         " Z.NAME,ADM.ADMNO, ADM.NAME || '   ' || ADM.SURNAME,Z.ZONESLNO, COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME , EBD.TCISSUEDCOUNT ORDER BY Z.NAME"

            ElseIf drpReportType.SelectedValue = 4 Then 'VC

                StrSql = " SELECT EBD.BOARDADMNO,ADM.ADMNO, ADM.NAME || '   ' || ADM.SURNAME BOARDNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME CODE, Z.VCSLNO, Z.NAME,EBD.TCISSUEDCOUNT TCISSUE" & _
                        " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,T_BRANCH_MT EBN,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED,T_VC_MT Z" & _
                        " WHERE     ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO(+) AND EBN.VCSLNO = Z.VCSLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO  AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                        " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+)  AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+)  AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO  AND ADM.STATUS IN (1, 5, 8)   AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & "  GROUP BY EBD.BOARDADMNO," & _
                        " Z.NAME,ADM.ADMNO, ADM.NAME || '   ' || ADM.SURNAME,Z.VCSLNO, COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME , EBD.TCISSUEDCOUNT ORDER BY Z.NAME"

            ElseIf drpReportType.SelectedValue = 2 Then 'DIVION

                'StrSql = " SELECT EBD.BOARDADMNO,ADM.ADMNO,  ADM.NAME || '   ' || ADM.SURNAME BOARDNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME CODE, Z.DIVISIONSLNO, Z.NAME,EBD.TCISSUEDCOUNT TCISSUE" & _
                '         " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,T_BRANCH_MT EBN,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED,T_DIVISION_MT Z " & _
                '         " WHERE     ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO(+) AND EBN.DIVISIONSLNO = Z.DIVISIONSLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO  AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                '         " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+)  AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+)  AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO  AND ADM.STATUS IN (1, 5, 8)   AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & "  GROUP BY EBD.BOARDADMNO," & _
                '         " Z.NAME,ADM.ADMNO, ADM.NAME || '   ' || ADM.SURNAME,Z.DIVISIONSLNO, COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME , EBD.TCISSUEDCOUNT ORDER BY Z.NAME"

                StrSql = " SELECT EBD.BOARDADMNO,ADM.ADMNO,ADM.NAME || '   ' || ADM.SURNAME BOARDNAME,COR.NAME|| ' / '|| GRP.NAME || ' / '|| BAT.NAME || ' / '|| SBT.NAME || ' / ' || SEC.SECTION|| ' / ' || TYP.NAME || ' / ' || MED.NAME CODE,EB.EXAMREGIONSLNO,REG.NAME,EBD.TCISSUEDCOUNT TCISSUE" & _
                         " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,T_BRANCH_MT EBN,T_COURSE_MT COR,T_GROUP_MT GRP, T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC, T_STUTYPE_MT TYP,T_MEDIUM_MT MED,EXAM_REGION_MT REG, EXAM_EXAMBRANCH EB" & _
                         " WHERE ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO(+) AND ADM.EXAMBRANCHSLNO=EB.EXAMBRANCHSLNO AND EB.EXAMREGIONSLNO = REG.EXAMREGIONSLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO  AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                         " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+) AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+) AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO AND ADM.STATUS IN (1, 5, 8) AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & " GROUP BY EBD.BOARDADMNO,REG.NAME,ADM.ADMNO," & _
                         " ADM.NAME || '   ' || ADM.SURNAME,EB.EXAMREGIONSLNO,COR.NAME|| ' / '|| GRP.NAME || ' / '|| BAT.NAME|| ' / ' || SBT.NAME || ' / '|| SEC.SECTION|| ' / ' || TYP.NAME|| ' / '|| MED.NAME,EBD.TCISSUEDCOUNT ORDER BY REG.NAME"
            End If


        End If

        Return StrSql

        Dim StrTotNc, StrExNC, StrFilt As String

        'If ChkDetails.Checked = True Then
        '    For I = 0 To RptSelExam.Length - 1
        '        StrTotNc = "(" + DtTotalStu.Replace("COUNT(ADM.ADMSLNO) TOTALSTU", RptSelExam(I).ToString + " DEXAMSLNO,ADM.ADMNO,ADM.NAME") : StrTotNc = StrTotNc.Replace(NCStr, "") : StrTotNc = StrTotNc.Replace(NCStr1, "")
        '        StrTotNc += " MINUS " + DtPFA.Replace(",B.RESULT", "")
        '        StrTotNc = StrTotNc.Replace("," + StRepl + ",RESULT", "") + " MINUS " + DTEbNE.Replace(Session("frmSelExams"), RptSelExam(I).ToString)
        '        If drpReportType.SelectedValue = 1 OrElse drpReportType.SelectedValue = 7 Then '''FOR EXAMBRANCH
        '            StrFilt = "EXAMBRANCHSLNO"
        '        ElseIf drpReportType.SelectedValue = 2 Then '''FOR REGION
        '            StrFilt = "REGIONSLNO"
        '        ElseIf drpReportType.SelectedValue = 6 Then '''FOR DIVISION
        '            StrFilt = "EXAMREGIONSLNO"
        '        ElseIf drpReportType.SelectedValue = 3 Then '''FOR ZONE
        '            StrFilt = "ZONESLNO"
        '        ElseIf drpReportType.SelectedValue = 4 Then '''FOR DOS
        '            StrFilt = "DOSLNO"
        '        ElseIf drpReportType.SelectedValue = 5 Then '''FOR VCS
        '            StrFilt = "VCSLNO"
        '        End If
        '        If StrFilt <> "" Then StrTotNc = StrTotNc.Replace("EXAMBRANCHSLNO", StrFilt)
        '        DTEbNC += StrTotNc + ")" + IIf(I <> RptSelExam.Length - 1, " UNION ", "")
        '    Next
        '    DTEbNC = DTEbNC.Replace("ESR." + StrFilt, "ESR.EXAMBRANCHSLNO")
        '    DTEbNC = DTEbNC.Replace("ADM." + StrFilt, "ADM.EXAMBRANCHSLNO")
        '    DTEbNC = DTEbNC.Replace("EB." + StrFilt + " " + StrFilt, "EB." + StrFilt + " EXAMBRANCHSLNO")
        '    DTEbNE = DTEbNE.Replace(",C.SUBSECTION SS", "") : DTEbNC = DTEbNC.Replace(",C.SUBSECTION SS", "")
        'End If

        'ObjResult = New Utility
        'DSet = ObjResult.Parse_Fetch(DTTotal)
        'If ChkDetails.Checked = True Then
        '    DtPFA = DtPFA.Replace("-", "_") : DtPFA = DtPFA.Replace("_1", "-1")
        '    DsResult = ObjResult.DataSet_EightFetchNew(DtTotalStu, DTStudent, DTSubjects, EsTPassTOTAL, EsTFailTOTAL, EsTAbsentTOTAL, DtPFA, DtEbStu)
        '    MyDsNENC = ObjResult.DataSet_TwoFetch(DTEbNE, DTEbNC)
        'Else
        '    DsResult = ObjResult.DataSet_SixFetchNew(DtTotalStu, DTStudent, DTSubjects, EsTPassTOTAL, EsTFailTOTAL, EsTAbsentTOTAL)
        'End If

        'If DsResult Is Nothing Or DsResult.Tables(0).Rows.Count = 0 Then
        '    StartUpScript("", " Data Not Found..!")
        'End If
        'If ChkDetails.Checked = True Then
        '    If drpReportType.SelectedItem.Value = 1 Then
        '        StrSql2 = " SELECT EBD.BOARDADMNO,ADM.ADMNO,ADM.NAME || '   ' || ADM.SURNAME BOARDNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME|| ' / '|| SEC.SECTION|| ' / '|| TYP.NAME|| ' / '|| MED.NAME CODE,ADM.EXAMBRANCHSLNO,EBN.EXAMBRANCHNAME,EBD.TCISSUEDCOUNT TCISSUE" & _
        '               " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,EXAM_EXAMBRANCH EBN,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED" & _
        '               " WHERE     ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.EXAMBRANCHSLNO = EBN.EXAMBRANCHSLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
        '               " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+) AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+) AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO AND ADM.STATUS IN (1, 5, 8)  AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & " " & _
        '               " GROUP BY EBD.BOARDADMNO,ADM.ADMNO,ADM.NAME || '   ' || ADM.SURNAME, ADM.EXAMBRANCHSLNO, EBN.EXAMBRANCHNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME|| ' / '|| SEC.SECTION|| ' / '|| TYP.NAME|| ' / '|| MED.NAME,EBD.TCISSUEDCOUNT  ORDER BY EBN.EXAMBRANCHNAME "
        '    End If

        'End If
        Return StrSql2

    End Function

    Private Function GettingBranchSqlQueryFormat()
        Try



            If drpReportType.SelectedValue = 1 Then
                SELECTEDBRANCHSLNO = " EXAMBRANCHSLNO IN("
            ElseIf drpReportType.SelectedValue = 3 Then
                SELECTEDBRANCHSLNO = " ZONESLNO IN("
            ElseIf drpReportType.SelectedValue = 4 Then
                SELECTEDBRANCHSLNO = " VCSLNO IN("
            ElseIf drpReportType.SelectedValue = 2 Then
                SELECTEDBRANCHSLNO = " EXAMREGIONSLNO IN("
            End If


            For i As Integer = 0 To LSTSelExamBranch.Items.Count - 1
                SELECTEDBRANCHSLNO &= LSTSelExamBranch.Items(i).Value & ","
            Next

            SELECTEDBRANCHSLNO = SELECTEDBRANCHSLNO.TrimEnd(",") & ")"


            If drpReportType.SelectedValue = 1 Then
                StrSql1 = "SELECT DISTINCT EXAMBRANCHSLNO , EXAMBRANCHNAME ||'-'||EXAMBRANCHSLNO  NAME FROM EXAM_EXAMBRANCH WHERE" & SELECTEDBRANCHSLNO & " ORDER BY NAME"
            ElseIf drpReportType.SelectedValue = 3 Then
                StrSql1 = "SELECT DISTINCT ZONESLNO , NAME FROM T_ZONE_MT WHERE" & SELECTEDBRANCHSLNO & " ORDER BY NAME"
            ElseIf drpReportType.SelectedValue = 4 Then
                StrSql1 = "SELECT DISTINCT VCSLNO ,  NAME FROM T_VC_MT WHERE" & SELECTEDBRANCHSLNO & " ORDER BY NAME"
            ElseIf drpReportType.SelectedValue = 2 Then
                'StrSql1 = "SELECT DISTINCT DIVISIONSLNO , NAME FROM T_DIVISION_MT WHERE" & SELECTEDBRANCHSLNO & " ORDER BY NAME"
                StrSql1 = "SELECT DISTINCT EXAMREGIONSLNO,NAME FROM EXAM_REGION_MT  WHERE " & SELECTEDBRANCHSLNO & " ORDER BY NAME"
            End If


            Return StrSql1

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GenerateSqlQueryDetails()

        Dim I As Integer

        If drpReportType.SelectedValue = 1 Then
            StrExamBranch &= " EXAMBRANCHSLNO IN ("
        ElseIf drpReportType.SelectedValue = 3 Then
            StrExamBranch &= " ZONESLNO IN ("
        ElseIf drpReportType.SelectedValue = 4 Then
            StrExamBranch &= " AND Z.VCSLNO IN ("
        ElseIf drpReportType.SelectedValue = 2 Then
            StrExamBranch &= " EXAMREGIONSLNO IN (" 'Z.DIVISIONSLNO

        End If
        'EXAM BRANCHES
        If LSTSelExamBranch.Items.Count > 0 Then
            For I = 0 To LSTSelExamBranch.Items.Count - 1
                StrExamBranch &= Val(LSTSelExamBranch.Items(I).Value.ToString) & IIf(I = LSTSelExamBranch.Items.Count - 1, ")", ",")
            Next
        End If

        


        If drpReportType.SelectedValue = 1 Then ' EB

            StrSql = " SELECT EBD.BOARDADMNO,ADM.ADMNO,ADM.NAME || '   ' || ADM.SURNAME BOARDNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME|| ' / '|| SEC.SECTION|| ' / '|| TYP.NAME|| ' / '|| MED.NAME CODE,ADM.EXAMBRANCHSLNO,EBN.EXAMBRANCHNAME,EBD.TCISSUEDCOUNT TCISSUE" & _
                    " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,EXAM_EXAMBRANCH EBN,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED" & _
                    " WHERE     ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.EXAMBRANCHSLNO = EBN.EXAMBRANCHSLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                    " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+) AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+) AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO AND ADM.STATUS IN (1, 5, 8)  AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & " " & _
                    " GROUP BY EBD.BOARDADMNO,ADM.ADMNO,ADM.NAME || '   ' || ADM.SURNAME, ADM.EXAMBRANCHSLNO, EBN.EXAMBRANCHNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME|| ' / '|| SEC.SECTION|| ' / '|| TYP.NAME|| ' / '|| MED.NAME,EBD.TCISSUEDCOUNT  ORDER BY EBN.EXAMBRANCHNAME "

        ElseIf drpReportType.SelectedValue = 3 Then 'ZONE

            StrSql = " SELECT EBD.BOARDADMNO,ADM.ADMNO,  ADM.NAME || '   ' || ADM.SURNAME BOARDNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME CODE, Z.ZONESLNO, Z.NAME,EBD.TCISSUEDCOUNT TCISSUE" & _
                     " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,T_BRANCH_MT EBN,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED,T_ZONE_MT Z" & _
                     " WHERE     ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO(+) AND EBN.ZONESLNO = Z.ZONESLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO  AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                     " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+)  AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+)  AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO  AND ADM.STATUS IN (1, 5, 8)   AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & "  GROUP BY EBD.BOARDADMNO," & _
                     " Z.NAME,ADM.ADMNO, ADM.NAME || '   ' || ADM.SURNAME,Z.ZONESLNO, COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME , EBD.TCISSUEDCOUNT ORDER BY Z.NAME"

        ElseIf drpReportType.SelectedValue = 4 Then 'VC

            StrSql = " SELECT EBD.BOARDADMNO,ADM.ADMNO, ADM.NAME || '   ' || ADM.SURNAME BOARDNAME,COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME CODE, Z.VCSLNO, Z.NAME,EBD.TCISSUEDCOUNT TCISSUE" & _
                    " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,T_BRANCH_MT EBN,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED,T_VC_MT Z" & _
                    " WHERE     ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO(+) AND EBN.VCSLNO = Z.VCSLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO  AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                    " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+)  AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+)  AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO  AND ADM.STATUS IN (1, 5, 8)   AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & "  GROUP BY EBD.BOARDADMNO," & _
                    " Z.NAME,ADM.ADMNO, ADM.NAME || '   ' || ADM.SURNAME,Z.VCSLNO, COR.NAME|| ' / '|| GRP.NAME|| ' / '|| BAT.NAME|| ' / '|| SBT.NAME || ' / ' || SEC.SECTION || ' / '|| TYP.NAME || ' / ' || MED.NAME , EBD.TCISSUEDCOUNT ORDER BY Z.NAME"

        ElseIf drpReportType.SelectedValue = 2 Then 'DIVION
          
            StrSql = " SELECT EBD.BOARDADMNO,ADM.ADMNO,ADM.NAME || '   ' || ADM.SURNAME BOARDNAME,COR.NAME|| ' / '|| GRP.NAME || ' / '|| BAT.NAME || ' / '|| SBT.NAME || ' / ' || SEC.SECTION|| ' / ' || TYP.NAME || ' / ' || MED.NAME CODE,EB.EXAMREGIONSLNO,REG.NAME,EBD.TCISSUEDCOUNT TCISSUE" & _
                     " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,T_BRANCH_MT EBN,T_COURSE_MT COR,T_GROUP_MT GRP, T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC, T_STUTYPE_MT TYP,T_MEDIUM_MT MED,EXAM_REGION_MT REG, EXAM_EXAMBRANCH EB" & _
                     " WHERE ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO(+) AND ADM.EXAMBRANCHSLNO=EB.EXAMBRANCHSLNO AND EB.EXAMREGIONSLNO = REG.EXAMREGIONSLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO  AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                     " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+) AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+) AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO AND ADM.STATUS IN (1, 5, 8) AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & StrExamBranch & " GROUP BY EBD.BOARDADMNO,REG.NAME,ADM.ADMNO," & _
                     " ADM.NAME || '   ' || ADM.SURNAME,EB.EXAMREGIONSLNO,COR.NAME|| ' / '|| GRP.NAME || ' / '|| BAT.NAME|| ' / ' || SBT.NAME || ' / '|| SEC.SECTION|| ' / ' || TYP.NAME|| ' / '|| MED.NAME,EBD.TCISSUEDCOUNT ORDER BY REG.NAME"
        End If




        Return StrSql


    End Function

    Private Function GenerateSqlQueryModDetails()
        Try

            Dim filterstring As String

            If drpReportType.SelectedValue = 1 Then
                SELECTEDBRANCHSLNO = " AND EBN.EXAMBRANCHSLNO IN("
            ElseIf drpReportType.SelectedValue = 3 Then
                SELECTEDBRANCHSLNO = " AND Z.ZONESLNO IN("
            ElseIf drpReportType.SelectedValue = 4 Then
                SELECTEDBRANCHSLNO = " AND Z.VCSLNO IN("
            ElseIf drpReportType.SelectedValue = 2 Then
                SELECTEDBRANCHSLNO = " AND EB.EXAMREGIONSLNO IN("
            End If


            For i As Integer = 0 To LSTSelExamBranch.Items.Count - 1
                SELECTEDBRANCHSLNO &= LSTSelExamBranch.Items(i).Value & ","
            Next

            If DrpCourse.SelectedValue = 1 Then
                filterstring &= " AND ADM.COURSESLNO IN(1,6)"
            ElseIf DrpCourse.SelectedValue = 2 Then
                filterstring &= " AND ADM.COURSESLNO IN(2,7) "
            ElseIf DrpCourse.SelectedValue = 0 Then
                filterstring &= " AND ADM.COURSESLNO IN(1,2,6,7)"
            End If

            SELECTEDBRANCHSLNO = SELECTEDBRANCHSLNO.TrimEnd(",") & ")"


            If drpReportType.SelectedValue = 1 Then ' EB

                StrSql1 = " SELECT ADM.ADMNO,ADM.NAME || '   ' || ADM.SURNAME NAME,COR.NAME COURSE,ADM.EXAMBRANCHSLNO,EBN.EXAMBRANCHNAME,CASE WHEN ADM.TOTALAMTPAID > 0 THEN TRUNC (  ADM.TOTALAMTPAID / (ADM.TOTALAMTTOBEPAID - ADM.TOTALLESSAMTRECEIVED)* 100,2) ELSE 0END PAIDPER" & _
                        " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,EXAM_EXAMBRANCH EBN,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED" & _
                        " WHERE     ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.EXAMBRANCHSLNO = EBN.EXAMBRANCHSLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                        " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+) AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+) AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO AND ADM.STATUS IN (1, 8) AND (EBD.TCISSUEDCOUNT= 0 OR EBD.TCISSUEDCOUNT IS NULL) AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & SELECTEDBRANCHSLNO & filterstring & " " & _
                        " ORDER BY EBN.EXAMBRANCHNAME "

            ElseIf drpReportType.SelectedValue = 3 Then 'ZONE

                StrSql1 = " SELECT ADM.ADMNO,  ADM.NAME || '   ' || ADM.SURNAME NAME,COR.NAME COURSE, Z.ZONESLNO, Z.NAME,CASE WHEN ADM.TOTALAMTPAID > 0 THEN TRUNC (  ADM.TOTALAMTPAID / (ADM.TOTALAMTTOBEPAID - ADM.TOTALLESSAMTRECEIVED)* 100,2) ELSE 0END PAIDPER" & _
                         " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,T_BRANCH_MT EBN,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED,T_ZONE_MT Z" & _
                         " WHERE     ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO(+) AND EBN.ZONESLNO = Z.ZONESLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO  AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                         " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+)  AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+)  AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO  AND ADM.STATUS IN (1, 8) AND (EBD.TCISSUEDCOUNT= 0 OR EBD.TCISSUEDCOUNT IS NULL)  AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & SELECTEDBRANCHSLNO & filterstring & " " & _
                         " ORDER BY Z.NAME"

            ElseIf drpReportType.SelectedValue = 4 Then 'VC

                StrSql1 = " SELECT ADM.ADMNO, ADM.NAME || '   ' || ADM.SURNAME NAME,COR.NAME COURSE, Z.VCSLNO, Z.NAME" & _
                        " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,T_BRANCH_MT EBN,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED,T_VC_MT Z,CASE WHEN ADM.TOTALAMTPAID > 0 THEN TRUNC (  ADM.TOTALAMTPAID / (ADM.TOTALAMTTOBEPAID - ADM.TOTALLESSAMTRECEIVED)* 100,2) ELSE 0END PAIDPER" & _
                        " WHERE     ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO(+) AND EBN.VCSLNO = Z.VCSLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO  AND ADM.BATCHSLNO = BAT.BATCHSLNO" & _
                        " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+)  AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+)  AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO  AND ADM.STATUS IN (1, 8) AND (EBD.TCISSUEDCOUNT= 0 OR EBD.TCISSUEDCOUNT IS NULL)  AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & SELECTEDBRANCHSLNO & filterstring & " " & _
                        " ORDER BY Z.NAME"

            ElseIf drpReportType.SelectedValue = 2 Then 'DIVION

                StrSql1 = " SELECT ADM.ADMNO,ADM.NAME || '   ' || ADM.SURNAME NAME,COR.NAME COURSE,EB.EXAMREGIONSLNO,REG.NAME,CASE WHEN ADM.TOTALAMTPAID > 0 THEN TRUNC (  ADM.TOTALAMTPAID / (ADM.TOTALAMTTOBEPAID - ADM.TOTALLESSAMTRECEIVED)* 100,2) ELSE 0END PAIDPER" & _
                         " FROM T_ADM_DT ADM,EXAM_BOARDSTUDENT_DT EBD,T_BRANCH_MT EBN,T_COURSE_MT COR,T_GROUP_MT GRP, T_BATCH_MT BAT,EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC, T_STUTYPE_MT TYP,T_MEDIUM_MT MED,EXAM_REGION_MT REG, EXAM_EXAMBRANCH EB" & _
                         " WHERE ADM.UNIQUENO = EBD.UNIQUENO(+) AND ADM.BRANCHSLNO = EBN.BRANCHSLNO(+) AND ADM.EXAMBRANCHSLNO=EB.EXAMBRANCHSLNO AND EB.EXAMREGIONSLNO = REG.EXAMREGIONSLNO(+) AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO  AND ADM.BATCHSLNO = BAT.BATCHSLNO " & _
                         " AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+) AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+) AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO AND ADM.STATUS IN (1, 8) AND (EBD.TCISSUEDCOUNT= 0 OR EBD.TCISSUEDCOUNT IS NULL) AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & SELECTEDBRANCHSLNO & filterstring & " " & _
                         " ORDER BY REG.NAME"
            End If


            Return StrSql1

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "Report Format"

    Private Function BranchWiseSummaryReportFormat()
        Try
            Dim i, j As Integer
            Dim rowcolor As Integer
            Dim rowBackColor As String
            Dim Dr1() As DataRow
            Dim REPORTON As String
            frmName = "../../Reports/TextReports/PFDetails.aspx"
            Session("Rtype") = "PFDet"
            Dim Tr1 As New TableRow
            Dim Tr2 As New TableRow
            Dim Tr3 As New TableRow
            Dim Tr3_1 As New TableRow
            Dim Tr5 As New TableRow

            If drpReportType.SelectedValue = 1 Then
                REPORTON = "Branch"
            ElseIf drpReportType.SelectedValue = 3 Then
                REPORTON = "Zone"
            ElseIf drpReportType.SelectedValue = 4 Then
                REPORTON = "VC"
            ElseIf drpReportType.SelectedValue = 2 Then
                REPORTON = "Division"
            End If



            Tr3_1.Cells.Add(DataLeftAllignmentStyle("", "", "", 2, "", "", "True", 10, 9, "", ""))

            Tr3_1.Cells.Add(DatacenterAlignstyle("TOTAL", "", "", 7, "", "", "True", 10, 9, "TOTAL", ""))
            Tr3_1.Cells.Add(DatacenterAlignstyle("SENIOR", "", "", 7, "", "", "True", 10, 9, "SENIOR", ""))
            Tr3_1.Cells.Add(DatacenterAlignstyle("JUNIOR", "", "", 7, "", "", "True", 10, 9, "JUNIOR", ""))

            Tr3.Cells.Add(DataLeftAllignmentStyle("Sno", "", "", 1, "", "", "True", 10, 9, "Sno", ""))
            Tr3.Cells.Add(DataLeftAllignmentStyle(REPORTON, "", "White", 1, "White", "", "True", 10, 9, REPORTON, "TCSummary.aspx?SORTCOLUMN=NAME"))

            Tr3.Cells.Add(DataRightAllignmentStyle("STRN", "", "White", 1, "White", "", "true", 10, 9, "Total Strength", "TCSummary.aspx?SORTCOLUMN=TOT_STRN"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ENTER", "", "White", 1, "White", "", "true", 10, 9, "Total Entered Strength", "TCSummary.aspx?SORTCOLUMN=TOT_ENTER"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ENT(%)", "", "White", 1, "White", "", "true", 10, 9, "Entered Strength Pers", "TCSummary.aspx?SORTCOLUMN=TOT_ENTPER"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ISD", "", "White", 1, "White", "", "true", 10, 9, "Total Issued", "TCSummary.aspx?SORTCOLUMN=TOT_ISSUED"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ISD(%)", "", "White", 1, "White", "", "true", 10, 9, "Total Issued Pers", "TCSummary.aspx?SORTCOLUMN=TOT_ISSPER"))
            Tr3.Cells.Add(DataRightAllignmentStyle("BAL", "", "White", 1, "White", "", "true", 10, 9, "Balance", "TCSummary.aspx?SORTCOLUMN=TOT_BAL"))
            Tr3.Cells.Add(DataRightAllignmentStyle("BAL(%)", "", "White", 1, "White", "", "true", 10, 9, "Balace Pers", "TCSummary.aspx?SORTCOLUMN=TOT_BALPER"))

            Tr3.Cells.Add(DataRightAllignmentStyle("STRN", "", "White", 1, "White", "", "true", 10, 9, "SR Total Strength", "TCSummary.aspx?SORTCOLUMN=2_STRN"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ENTER", "", "White", 1, "White", "", "true", 10, 9, "Total Entered Strength", "TCSummary.aspx?SORTCOLUMN=2_ENTER"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ENT(%)", "", "White", 1, "White", "", "true", 10, 9, "Entered Strength%", "TCSummary.aspx?SORTCOLUMN=ENTPER_2"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ISD", "", "White", 1, "White", "", "true", 10, 9, "Total Issued", "TCSummary.aspx?SORTCOLUMN=2_ISSUED"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ISD(%)", "", "White", 1, "White", "", "true", 10, 9, "Total Issued%", "TCSummary.aspx?SORTCOLUMN=2_ISSPER"))
            Tr3.Cells.Add(DataRightAllignmentStyle("BAL", "", "White", 1, "White", "", "true", 10, 9, "Balance", "TCSummary.aspx?SORTCOLUMN=BAL_2"))
            Tr3.Cells.Add(DataRightAllignmentStyle("BAL(%)", "", "White", 1, "White", "", "true", 10, 9, "Balance%", "TCSummary.aspx?SORTCOLUMN=2_BALPER"))

            Tr3.Cells.Add(DataRightAllignmentStyle("STRN", "", "White", 1, "White", "", "true", 10, 9, "JR Total Strength", "TCSummary.aspx?SORTCOLUMN=1_STRN"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ENTER", "", "White", 1, "White", "", "true", 10, 9, "Total Entered Strength", "TCSummary.aspx?SORTCOLUMN=1_ENTER"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ENT(%)", "", "White", 1, "White", "", "true", 10, 9, "Entered Strength%", "TCSummary.aspx?SORTCOLUMN=ENTPER_1"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ISD", "", "White", 1, "White", "", "true", 10, 9, "Total Issued", "TCSummary.aspx?SORTCOLUMN=1_ISSUED"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ISD(%)", "", "White", 1, "White", "", "true", 10, 9, "Total Issued%", "TCSummary.aspx?SORTCOLUMN=1_ISSPER"))
            Tr3.Cells.Add(DataRightAllignmentStyle("BAL", "", "White", 1, "White", "", "true", 10, 9, "Balance", "TCSummary.aspx?SORTCOLUMN=BAL_1"))
            Tr3.Cells.Add(DataRightAllignmentStyle("BAL(%)", "", "White", 1, "White", "", "true", 10, 9, "Balance%", "TCSummary.aspx?SORTCOLUMN=1_BALPER"))

            'Tr3.Cells.Add(DataRightAllignmentStyle("Tot.Balance ", "", "White", 1, "White", "", "true", 10, 9, "Total Balance", "TCSummary.aspx?SORTCOLUMN=TCBAL"))
            'Tr3.Cells.Add(DataRightAllignmentStyle("Issued (%)", "", "White", 1, "White", "", "true", 10, 9, "Issued (%)", "TCSummary.aspx?SORTCOLUMN=ISSPER"))
            'Tr3.Cells.Add(DataRightAllignmentStyle("Balance (%)", "", "White", 1, "White", "", "true", 10, 9, "Balance  (%)", "TCSummary.aspx?SORTCOLUMN=BALPER"))

            Tr2.CssClass = "SubHeading1"
            Tr3_1.CssClass = "gridheader"
            Tr3.CssClass = "gridheader"

            'Tr1.Cells.Add(DataRightAllignmentStyle("BACK", PUB_BACK1FORE_COLOR, PUB_BACK1_COLOR, Tr3.Cells.Count, PUB_BACK1_COLOR, "Verdana", "true", 90, 10, "", "javascript:b()"))
            Tr2.Cells.Add(DataCenterAllignmentStyle(REPORTON & " Wise TC Summary Report", "", "", Tr3.Cells.Count, "", "Verdana", "true", 90, 10, "", ""))

            'TableMain1.Rows.Add(Tr1)
            TableMain1.Rows.Add(Tr2)
            TableMain1.Rows.Add(Tr3_1)
            TableMain1.Rows.Add(Tr3)

            Dr1 = DsStudents.Tables(0).Select("", Session("SORTCOLUMN") & Session("SORTTYPE"))

            For i = 0 To Dr1.Length - 1
                Dim Tr4 As New TableRow
                If rowcolor = 0 Then
                    rowBackColor = "GridItem"
                    rowcolor = 1
                Else
                    rowBackColor = "GridAlternateItem"
                    rowcolor = 0
                End If



                Tr4.Cells.Add(DataLeftAllignmentStyle(i + 1, "", "", 1, "", "", "False", 10, 8, "Sno", "", , rowBackColor))
                Tr4.Cells.Add(DataLeftAllignmentStyle(Dr1(i)("NAME").ToString, "", "", 1, "", "", "False", 10, 8, REPORTON, "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("TOT_STRN").ToString, "", "", 1, "", "", "False", 10, 8, "Total Strength", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("TOT_ENTER").ToString, "", "", 1, "", "", "False", 10, 8, "Total Entered", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Format(Dr1(i)("TOT_ENTPER"), "0.00").ToString, "", "", 1, "", "", "False", 10, 8, "Total Entered (%)", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("TOT_ISSUED").ToString, "", "", 1, "", "", "False", 10, 8, "Total Issued", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Format(Dr1(i)("TOT_ISSPER"), "0.00").ToString, "", "", 1, "", "", "False", 10, 8, "Total Issued  (%)", "", , rowBackColor))
                If ChkDetails.Checked = True Then
                    Tr4.Cells.Add(EnteredstyleMul(Dr1(i)("TOT_BAL"), 1, "R", 2, "", "?Ebslno=" & Dr1(i)("EXAMBRANCHSLNO").ToString & " ", frmName))
                Else
                    Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("TOT_BAL"), "", "", 1, "", "", "False", 10, 8, "Total Bal", "", , rowBackColor))
                End If
                Tr4.Cells.Add(DataRightAllignmentStyle(Format(Dr1(i)("TOT_BALPER"), "0.00").ToString, "", "", 1, "", "", "False", 10, 8, "Balace (%)", "", , rowBackColor))

                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("2_STRN").ToString, "", "", 1, "", "", "False", 10, 8, "Senior Strength", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("2_ENTER").ToString, "", "", 1, "", "", "False", 10, 8, "Senior Entered", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Format(Dr1(i)("ENTPER_2"), "0.00").ToString, "", "", 1, "", "", "False", 10, 8, "Senior Enter(%)", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("2_ISSUED").ToString, "", "", 1, "", "", "False", 10, 8, "Issued (%)", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Format(Dr1(i)("2_ISSPER"), "0.00").ToString, "", "", 1, "", "", "False", 10, 8, "Balance  (%)", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("BAL_2").ToString, "", "", 1, "", "", "False", 10, 8, "Issued (%)", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Format(Dr1(i)("2_BALPER"), "0.00").ToString, "", "", 1, "", "", "False", 10, 8, "Balance  (%)", "", , rowBackColor))

                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("1_STRN").ToString, "", "", 1, "", "", "False", 10, 8, "Junior Strength", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("1_ENTER").ToString, "", "", 1, "", "", "False", 10, 8, "Junior Entered", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Format(Dr1(i)("ENTPER_1"), "0.00").ToString, "", "", 1, "", "", "False", 10, 8, "Junior Entered (%)", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("1_ISSUED").ToString, "", "", 1, "", "", "False", 10, 8, "Issued (%)", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Format(Dr1(i)("1_ISSPER"), "0.00").ToString, "", "", 1, "", "", "False", 10, 8, "Balance  (%)", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentHyperLinkStyle(Dr1(i)("BAL_1").ToString, "", "", 1, "", "", "False", 10, 8, "Issued (%)", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Format(Dr1(i)("1_BALPER"), "0.00").ToString, "", "", 1, "", "", "False", 10, 8, "Balance  (%)", "", , rowBackColor))

                TableMain1.Rows.Add(Tr4)
            Next

            Tr5.Cells.Add(DataRightAllignmentStyle("Totals", "", "", 2, "", "", "True", 10, 8, "Totals", "", , rowBackColor))
            Dim TOTALSTRN, TOTALENTER, TOTALISSED, STRN_1, STRN_2, ISSD_1, ISSD_2, ENTER_1, ENTER_2, TOTALBAL, BAL_1, BAL_2 As String
            Dim TOT_ENTPER, TOT_ISSPER, TOT_BALPER, ISSPER_1, BALPER_1, ENTPER_1, ISSPER_2, BALPER_2, ENTPER_2 As Double

            'TOTAL
            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TOT_STRN)", "")) Then
                TOTALSTRN = DsStudents.Tables(0).Compute("SUM(TOT_STRN)", "")
            Else
                TOTALSTRN = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TOT_ENTER)", "")) Then
                TOTALENTER = DsStudents.Tables(0).Compute("SUM(TOT_ENTER)", "")
                TOT_ENTPER = Format((TOTALENTER / TOTALSTRN) * 100, "0.00")
            Else
                TOTALENTER = 0
                TOT_ENTPER = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TOT_ISSUED)", "")) Then
                TOTALISSED = DsStudents.Tables(0).Compute("SUM(TOT_ISSUED)", "")
                TOT_ISSPER = Format((TOTALISSED / TOTALSTRN) * 100, "0.00")
            Else
                TOTALISSED = 0
                TOT_ISSPER = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TOT_BAL)", "")) Then
                TOTALBAL = DsStudents.Tables(0).Compute("SUM(TOT_BAL)", "")
                TOT_BALPER = Format((TOTALBAL / TOTALSTRN) * 100, "0.00")
            Else
                TOTALBAL = 0
                TOT_BALPER = 0
            End If

            'SENIOR
            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(STRN_2)", "")) Then
                STRN_2 = DsStudents.Tables(0).Compute("SUM(STRN_2)", "")
            Else
                STRN_2 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(ENTER_2)", "")) Then
                ENTER_2 = DsStudents.Tables(0).Compute("SUM(ENTER_2)", "")
                ENTPER_2 = Format((ENTER_2 / STRN_2) * 100, "0.00")
            Else
                ENTER_2 = 0
                ENTPER_2 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(ISSUED_2)", "")) Then
                ISSD_2 = DsStudents.Tables(0).Compute("SUM(ISSUED_2)", "")
                ISSPER_2 = Format((ISSD_2 / STRN_2) * 100, "0.00")
            Else
                ISSD_2 = 0
                ISSPER_2 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(BAL_2)", "")) Then
                BAL_2 = DsStudents.Tables(0).Compute("SUM(BAL_2)", "")
                BALPER_2 = Format((BAL_2 / STRN_2) * 100, "0.00")
            Else
                BAL_2 = 0
                BALPER_2 = 0
            End If

            'JUNIOR

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(STRN_1)", "")) Then
                STRN_1 = DsStudents.Tables(0).Compute("SUM(STRN_1)", "")
            Else
                STRN_1 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(ENTER_1)", "")) Then
                ENTER_1 = DsStudents.Tables(0).Compute("SUM(ENTER_1)", "")
                ENTPER_1 = Format((ENTER_1 / STRN_1) * 100, "0.00")
            Else
                ENTER_1 = 0
                ENTPER_1 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(ISSUED_1)", "")) Then
                ISSD_1 = DsStudents.Tables(0).Compute("SUM(ISSUED_1)", "")
                ISSPER_1 = Format((ISSD_1 / STRN_1) * 100, "0.00")
            Else
                ISSD_1 = 0
                ISSPER_1 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(BAL_1)", "")) Then
                BAL_1 = DsStudents.Tables(0).Compute("SUM(BAL_1)", "")
                BALPER_1 = Format((BAL_1 / STRN_1) * 100, "0.00")
            Else
                BAL_1 = 0
                BALPER_1 = 0
            End If

            'Tr5.Cells.Add(DataRightAllignmentStyle(DsStudents.Tables(0).Compute("SUM(TOTALSTRN)", ""), "", "", 1, "", "", "True", 10, 8, "Total Strength", "", , rowBackColor))
            ''Tr5.Cells.Add(DataRightAllignmentStyle(DsStudents.Tables(0).Compute("SUM(TCISSCOUNT)", ""), "", "", 1, "", "", "True", 10, 8, "Total Issued", "", , rowBackColor))
            ''Tr5.Cells.Add(DataRightAllignmentStyle(DsStudents.Tables(0).Compute("SUM(TCBAL)", ""), "", "", 1, "", "", "True", 10, 8, "Total Balance", "", , rowBackColor))

            Tr5.Cells.Add(DataRightAllignmentStyle(TOTALSTRN.ToString, "", "", 1, "", "", "True", 10, 8, "Total Strength", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(TOTALENTER.ToString, "", "", 1, "", "", "True", 10, 8, "Total Entered", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(TOT_ENTPER.ToString, "", "", 1, "", "", "True", 10, 8, "Total Entered %", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(TOTALISSED.ToString, "", "", 1, "", "", "True", 10, 8, "Total Issued", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(TOT_ISSPER.ToString, "", "", 1, "", "", "True", 10, 8, "Total Issued %", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(TOTALBAL.ToString, "", "", 1, "", "", "True", 10, 8, "Total Balance", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(TOT_BALPER.ToString, "", "", 1, "", "", "True", 10, 8, "Total Balance %", "", , rowBackColor))

            Tr5.Cells.Add(DataRightAllignmentStyle(STRN_2.ToString, "", "", 1, "", "", "True", 10, 8, "SENIOR Strength", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ENTER_2.ToString, "", "", 1, "", "", "True", 10, 8, "SENIOR Entered", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ENTPER_2.ToString, "", "", 1, "", "", "True", 10, 8, "SENIOR Entered %", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ISSD_2.ToString, "", "", 1, "", "", "True", 10, 8, "SENIOR Issued", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ISSPER_2.ToString, "", "", 1, "", "", "True", 10, 8, "SENIOR Issued", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(BAL_2.ToString, "", "", 1, "", "", "True", 10, 8, "SENIOR Balance", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(BALPER_2.ToString, "", "", 1, "", "", "True", 10, 8, "SENIOR Balance %", "", , rowBackColor))

            Tr5.Cells.Add(DataRightAllignmentStyle(STRN_1.ToString, "", "", 1, "", "", "True", 10, 8, "JUNIOR Strength", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ENTER_1.ToString, "", "", 1, "", "", "True", 10, 8, "JUNIOR Entered", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ENTPER_1.ToString, "", "", 1, "", "", "True", 10, 8, "JUNIOR Entered %", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ISSD_1.ToString, "", "", 1, "", "", "True", 10, 8, "JUNIOR Issued", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ISSPER_1.ToString, "", "", 1, "", "", "True", 10, 8, "JUNIOR Issued", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(BAL_1.ToString, "", "", 1, "", "", "True", 10, 8, "JUNIOR Balance", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(BALPER_1.ToString, "", "", 1, "", "", "True", 10, 8, "JUNIOR Balance %", "", , rowBackColor))
            TableMain1.Rows.Add(Tr5)
            TableMain1.GridLines = GridLines.Both

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function BranchWiseSummaryReportFormatJR()
        Try
            Dim i, j As Integer
            Dim rowcolor As Integer
            Dim rowBackColor As String
            Dim Dr1() As DataRow
            Dim REPORTON As String
            frmName = "../../Reports/TextReports/PFDetails.aspx"
            Session("Rtype") = "PFDet"
            Dim Tr1 As New TableRow
            Dim Tr2 As New TableRow
            Dim Tr3 As New TableRow
            Dim Tr3_1 As New TableRow
            Dim Tr5 As New TableRow

            If drpReportType.SelectedValue = 1 Then
                REPORTON = "Branch"
            ElseIf drpReportType.SelectedValue = 3 Then
                REPORTON = "Zone"
            ElseIf drpReportType.SelectedValue = 4 Then
                REPORTON = "VC"
            ElseIf drpReportType.SelectedValue = 2 Then
                REPORTON = "Division"
            End If



            Tr3_1.Cells.Add(DataLeftAllignmentStyle("", "", "", 2, "", "", "True", 10, 9, "", ""))

            Tr3_1.Cells.Add(DatacenterAlignstyle("JUNIOR", "", "", 7, "", "", "True", 10, 9, "JUNIOR", ""))

            Tr3.Cells.Add(DataLeftAllignmentStyle("Sno", "", "", 1, "", "", "True", 10, 9, "Sno", ""))
            Tr3.Cells.Add(DataLeftAllignmentStyle(REPORTON, "", "White", 1, "White", "", "True", 10, 9, REPORTON, "TCSummary.aspx?SORTCOLUMN=NAME"))

            Tr3.Cells.Add(DataRightAllignmentStyle("STRN", "", "White", 1, "White", "", "true", 10, 9, "JR Total Strength", "TCSummary.aspx?SORTCOLUMN=1_STRN"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ENTER", "", "White", 1, "White", "", "true", 10, 9, "Total Entered Strength", "TCSummary.aspx?SORTCOLUMN=1_ENTER"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ENT(%)", "", "White", 1, "White", "", "true", 10, 9, "Entered Strength%", "TCSummary.aspx?SORTCOLUMN=ENTPER_1"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ISD", "", "White", 1, "White", "", "true", 10, 9, "Total Issued", "TCSummary.aspx?SORTCOLUMN=1_ISSUED"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ISD(%)", "", "White", 1, "White", "", "true", 10, 9, "Total Issued%", "TCSummary.aspx?SORTCOLUMN=1_ISSPER"))
            Tr3.Cells.Add(DataRightAllignmentStyle("BAL", "", "White", 1, "White", "", "true", 10, 9, "Balance", "TCSummary.aspx?SORTCOLUMN=BAL_1"))
            Tr3.Cells.Add(DataRightAllignmentStyle("BAL(%)", "", "White", 1, "White", "", "true", 10, 9, "Balance%", "TCSummary.aspx?SORTCOLUMN=1_BALPER"))


            Tr2.CssClass = "SubHeading1"
            Tr3_1.CssClass = "gridheader"
            Tr3.CssClass = "gridheader"

            'Tr1.Cells.Add(DataRightAllignmentStyle("BACK", PUB_BACK1FORE_COLOR, PUB_BACK1_COLOR, Tr3.Cells.Count, PUB_BACK1_COLOR, "Verdana", "true", 90, 10, "", "javascript:b()"))
            Tr2.Cells.Add(DataCenterAllignmentStyle(REPORTON & " Wise TC Summary Report", "", "", Tr3.Cells.Count, "", "Verdana", "true", 90, 10, "", ""))

            ' TableMain1.Rows.Add(Tr1)
            TableMain1.Rows.Add(Tr2)
            TableMain1.Rows.Add(Tr3_1)
            TableMain1.Rows.Add(Tr3)

            Dr1 = DsStudents.Tables(0).Select("", Session("SORTCOLUMN") & Session("SORTTYPE"))

            For i = 0 To Dr1.Length - 1
                Dim Tr4 As New TableRow
                If rowcolor = 0 Then
                    rowBackColor = "GridItem"
                    rowcolor = 1
                Else
                    rowBackColor = "GridAlternateItem"
                    rowcolor = 0
                End If


                Tr4.Cells.Add(DataLeftAllignmentStyle(i + 1, "", "", 1, "", "", "False", 10, 8, "Sno", "", , rowBackColor))
                Tr4.Cells.Add(DataLeftAllignmentStyle(Dr1(i)("NAME").ToString, "", "", 1, "", "", "False", 10, 8, REPORTON, "", , rowBackColor))

                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("1_STRN").ToString, "", "", 1, "", "", "False", 10, 8, "Junior Strength", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("1_ENTER").ToString, "", "", 1, "", "", "False", 10, 8, "Junior Entered", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Format(Dr1(i)("ENTPER_1"), "0.00").ToString, "", "", 1, "", "", "False", 10, 8, "Junior Entered (%)", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("1_ISSUED").ToString, "", "", 1, "", "", "False", 10, 8, "Issued (%)", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Format(Dr1(i)("1_ISSPER"), "0.00").ToString, "", "", 1, "", "", "False", 10, 8, "Balance  (%)", "", , rowBackColor))
                If ChkDetails.Checked = True Then
                    Tr4.Cells.Add(EnteredstyleMul(Dr1(i)("BAL_1"), 1, "R", 2, "", "?Ebslno=" & Dr1(i)("EXAMBRANCHSLNO").ToString & " ", frmName))
                Else
                    Tr4.Cells.Add(DataRightAllignmentHyperLinkStyle(Dr1(i)("BAL_1").ToString, "", "", 1, "", "", "False", 10, 8, "Issued (%)", "", , rowBackColor))
                End If
                Tr4.Cells.Add(DataRightAllignmentStyle(Format(Dr1(i)("1_BALPER"), "0.00").ToString, "", "", 1, "", "", "False", 10, 8, "Balance  (%)", "", , rowBackColor))

                TableMain1.Rows.Add(Tr4)
            Next

            Tr5.Cells.Add(DataRightAllignmentStyle("Totals", "", "", 2, "", "", "True", 10, 8, "Totals", "", , rowBackColor))
            Dim TOTALSTRN, TOTALENTER, TOTALISSED, STRN_1, STRN_2, ISSD_1, ISSD_2, ENTER_1, ENTER_2, TOTALBAL, BAL_1, BAL_2 As String
            Dim TOT_ENTPER, TOT_ISSPER, TOT_BALPER, ISSPER_1, BALPER_1, ENTPER_1, ISSPER_2, BALPER_2, ENTPER_2 As Double

            'TOTAL
            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TOT_STRN)", "")) Then
                TOTALSTRN = DsStudents.Tables(0).Compute("SUM(TOT_STRN)", "")
            Else
                TOTALSTRN = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TOT_ENTER)", "")) Then
                TOTALENTER = DsStudents.Tables(0).Compute("SUM(TOT_ENTER)", "")
                TOT_ENTPER = Format((TOTALENTER / TOTALSTRN) * 100, "0.00")
            Else
                TOTALENTER = 0
                TOT_ENTPER = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TOT_ISSUED)", "")) Then
                TOTALISSED = DsStudents.Tables(0).Compute("SUM(TOT_ISSUED)", "")
                TOT_ISSPER = Format((TOTALISSED / TOTALSTRN) * 100, "0.00")
            Else
                TOTALISSED = 0
                TOT_ISSPER = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TOT_BAL)", "")) Then
                TOTALBAL = DsStudents.Tables(0).Compute("SUM(TOT_BAL)", "")
                TOT_BALPER = Format((TOTALBAL / TOTALSTRN) * 100, "0.00")
            Else
                TOTALBAL = 0
                TOT_BALPER = 0
            End If

            'SENIOR
            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(STRN_2)", "")) Then
                STRN_2 = DsStudents.Tables(0).Compute("SUM(STRN_2)", "")
            Else
                STRN_2 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(ENTER_2)", "")) Then
                ENTER_2 = DsStudents.Tables(0).Compute("SUM(ENTER_2)", "")
                ENTPER_2 = Format((ENTER_2 / STRN_2) * 100, "0.00")
            Else
                ENTER_2 = 0
                ENTPER_2 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(ISSUED_2)", "")) Then
                ISSD_2 = DsStudents.Tables(0).Compute("SUM(ISSUED_2)", "")
                ISSPER_2 = Format((ISSD_2 / STRN_2) * 100, "0.00")
            Else
                ISSD_2 = 0
                ISSPER_2 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(BAL_2)", "")) Then
                BAL_2 = DsStudents.Tables(0).Compute("SUM(BAL_2)", "")
                BALPER_2 = Format((BAL_2 / STRN_2) * 100, "0.00")
            Else
                BAL_2 = 0
                BALPER_2 = 0
            End If

            'JUNIOR

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(STRN_1)", "")) Then
                STRN_1 = DsStudents.Tables(0).Compute("SUM(STRN_1)", "")
            Else
                STRN_1 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(ENTER_1)", "")) Then
                ENTER_1 = DsStudents.Tables(0).Compute("SUM(ENTER_1)", "")
                ENTPER_1 = Format((ENTER_1 / STRN_1) * 100, "0.00")
            Else
                ENTER_1 = 0
                ENTPER_1 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(ISSUED_1)", "")) Then
                ISSD_1 = DsStudents.Tables(0).Compute("SUM(ISSUED_1)", "")
                ISSPER_1 = Format((ISSD_1 / STRN_1) * 100, "0.00")
            Else
                ISSD_1 = 0
                ISSPER_1 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(BAL_1)", "")) Then
                BAL_1 = DsStudents.Tables(0).Compute("SUM(BAL_1)", "")
                BALPER_1 = Format((BAL_1 / STRN_1) * 100, "0.00")
            Else
                BAL_1 = 0
                BALPER_1 = 0
            End If

            Tr5.Cells.Add(DataRightAllignmentStyle(STRN_1.ToString, "", "", 1, "", "", "True", 10, 8, "JUNIOR Strength", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ENTER_1.ToString, "", "", 1, "", "", "True", 10, 8, "JUNIOR Entered", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ENTPER_1.ToString, "", "", 1, "", "", "True", 10, 8, "JUNIOR Entered %", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ISSD_1.ToString, "", "", 1, "", "", "True", 10, 8, "JUNIOR Issued", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ISSPER_1.ToString, "", "", 1, "", "", "True", 10, 8, "JUNIOR Issued", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(BAL_1.ToString, "", "", 1, "", "", "True", 10, 8, "JUNIOR Balance", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(BALPER_1.ToString, "", "", 1, "", "", "True", 10, 8, "JUNIOR Balance %", "", , rowBackColor))
            TableMain1.Rows.Add(Tr5)
            TableMain1.GridLines = GridLines.Both

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function BranchWiseSummaryReportFormatSR()
        Try
            Dim i, j As Integer
            Dim rowcolor As Integer
            Dim rowBackColor As String
            Dim Dr1() As DataRow
            Dim REPORTON As String
            frmName = "../../Reports/TextReports/PFDetails.aspx"
            Session("Rtype") = "PFDet"
            Dim Tr1 As New TableRow
            Dim Tr2 As New TableRow
            Dim Tr3 As New TableRow
            Dim Tr3_1 As New TableRow
            Dim Tr5 As New TableRow

            If drpReportType.SelectedValue = 1 Then
                REPORTON = "Branch"
            ElseIf drpReportType.SelectedValue = 3 Then
                REPORTON = "Zone"
            ElseIf drpReportType.SelectedValue = 4 Then
                REPORTON = "VC"
            ElseIf drpReportType.SelectedValue = 2 Then
                REPORTON = "Division"
            End If



            Tr3_1.Cells.Add(DataLeftAllignmentStyle("", "", "", 2, "", "", "True", 10, 9, "", ""))

            Tr3_1.Cells.Add(DatacenterAlignstyle("SENIOR", "", "", 7, "", "", "True", 10, 9, "SENIOR", ""))


            Tr3.Cells.Add(DataLeftAllignmentStyle("Sno", "", "", 1, "", "", "True", 10, 9, "Sno", ""))
            Tr3.Cells.Add(DataLeftAllignmentStyle(REPORTON, "", "White", 1, "White", "", "True", 10, 9, REPORTON, "TCSummary.aspx?SORTCOLUMN=NAME"))


            Tr3.Cells.Add(DataRightAllignmentStyle("STRN", "", "White", 1, "White", "", "true", 10, 9, "SR Total Strength", "TCSummary.aspx?SORTCOLUMN=2_STRN"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ENTER", "", "White", 1, "White", "", "true", 10, 9, "Total Entered Strength", "TCSummary.aspx?SORTCOLUMN=2_ENTER"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ENT(%)", "", "White", 1, "White", "", "true", 10, 9, "Entered Strength%", "TCSummary.aspx?SORTCOLUMN=ENTPER_2"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ISD", "", "White", 1, "White", "", "true", 10, 9, "Total Issued", "TCSummary.aspx?SORTCOLUMN=2_ISSUED"))
            Tr3.Cells.Add(DataRightAllignmentStyle("ISD(%)", "", "White", 1, "White", "", "true", 10, 9, "Total Issued%", "TCSummary.aspx?SORTCOLUMN=2_ISSPER"))
            Tr3.Cells.Add(DataRightAllignmentStyle("BAL", "", "White", 1, "White", "", "true", 10, 9, "Balance", "TCSummary.aspx?SORTCOLUMN=BAL_2"))
            Tr3.Cells.Add(DataRightAllignmentStyle("BAL(%)", "", "White", 1, "White", "", "true", 10, 9, "Balance%", "TCSummary.aspx?SORTCOLUMN=2_BALPER"))


            Tr2.CssClass = "SubHeading1"
            Tr3_1.CssClass = "gridheader"
            Tr3.CssClass = "gridheader"

            'Tr1.Cells.Add(DataRightAllignmentStyle("BACK", PUB_BACK1FORE_COLOR, PUB_BACK1_COLOR, Tr3.Cells.Count, PUB_BACK1_COLOR, "Verdana", "true", 90, 10, "", "javascript:b()"))
            Tr2.Cells.Add(DataCenterAllignmentStyle(REPORTON & " Wise TC Summary Report", "", "", Tr3.Cells.Count, "", "Verdana", "true", 90, 10, "", ""))

            'TableMain1.Rows.Add(Tr1)
            TableMain1.Rows.Add(Tr2)
            TableMain1.Rows.Add(Tr3_1)
            TableMain1.Rows.Add(Tr3)

            Dr1 = DsStudents.Tables(0).Select("", Session("SORTCOLUMN") & Session("SORTTYPE"))

            For i = 0 To Dr1.Length - 1
                Dim Tr4 As New TableRow
                If rowcolor = 0 Then
                    rowBackColor = "GridItem"
                    rowcolor = 1
                Else
                    rowBackColor = "GridAlternateItem"
                    rowcolor = 0
                End If


                Tr4.Cells.Add(DataLeftAllignmentStyle(i + 1, "", "", 1, "", "", "False", 10, 8, "Sno", "", , rowBackColor))
                Tr4.Cells.Add(DataLeftAllignmentStyle(Dr1(i)("NAME").ToString, "", "", 1, "", "", "False", 10, 8, REPORTON, "", , rowBackColor))

 
                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("2_STRN").ToString, "", "", 1, "", "", "False", 10, 8, "Senior Strength", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("2_ENTER").ToString, "", "", 1, "", "", "False", 10, 8, "Senior Entered", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Format(Dr1(i)("ENTPER_2"), "0.00").ToString, "", "", 1, "", "", "False", 10, 8, "Senior Enter(%)", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("2_ISSUED").ToString, "", "", 1, "", "", "False", 10, 8, "Issued (%)", "", , rowBackColor))
                Tr4.Cells.Add(DataRightAllignmentStyle(Format(Dr1(i)("2_ISSPER"), "0.00").ToString, "", "", 1, "", "", "False", 10, 8, "Balance  (%)", "", , rowBackColor))
                If ChkDetails.Checked = True Then
                    Tr4.Cells.Add(EnteredstyleMul(Dr1(i)("BAL_2"), 1, "R", 2, "", "?Ebslno=" & Dr1(i)("EXAMBRANCHSLNO").ToString & " ", frmName))
                Else
                    Tr4.Cells.Add(DataRightAllignmentStyle(Dr1(i)("BAL_2").ToString, "", "", 1, "", "", "False", 10, 8, "Issued (%)", "", , rowBackColor))
                End If
                Tr4.Cells.Add(DataRightAllignmentStyle(Format(Dr1(i)("2_BALPER"), "0.00").ToString, "", "", 1, "", "", "False", 10, 8, "Balance  (%)", "", , rowBackColor))

                TableMain1.Rows.Add(Tr4)
            Next

            Tr5.Cells.Add(DataRightAllignmentStyle("Totals", "", "", 2, "", "", "True", 10, 8, "Totals", "", , rowBackColor))
            Dim TOTALSTRN, TOTALENTER, TOTALISSED, STRN_1, STRN_2, ISSD_1, ISSD_2, ENTER_1, ENTER_2, TOTALBAL, BAL_1, BAL_2 As String
            Dim TOT_ENTPER, TOT_ISSPER, TOT_BALPER, ISSPER_1, BALPER_1, ENTPER_1, ISSPER_2, BALPER_2, ENTPER_2 As Double

            'TOTAL
            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TOT_STRN)", "")) Then
                TOTALSTRN = DsStudents.Tables(0).Compute("SUM(TOT_STRN)", "")
            Else
                TOTALSTRN = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TOT_ENTER)", "")) Then
                TOTALENTER = DsStudents.Tables(0).Compute("SUM(TOT_ENTER)", "")
                TOT_ENTPER = Format((TOTALENTER / TOTALSTRN) * 100, "0.00")
            Else
                TOTALENTER = 0
                TOT_ENTPER = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TOT_ISSUED)", "")) Then
                TOTALISSED = DsStudents.Tables(0).Compute("SUM(TOT_ISSUED)", "")
                TOT_ISSPER = Format((TOTALISSED / TOTALSTRN) * 100, "0.00")
            Else
                TOTALISSED = 0
                TOT_ISSPER = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TOT_BAL)", "")) Then
                TOTALBAL = DsStudents.Tables(0).Compute("SUM(TOT_BAL)", "")
                TOT_BALPER = Format((TOTALBAL / TOTALSTRN) * 100, "0.00")
            Else
                TOTALBAL = 0
                TOT_BALPER = 0
            End If

            'SENIOR
            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(STRN_2)", "")) Then
                STRN_2 = DsStudents.Tables(0).Compute("SUM(STRN_2)", "")
            Else
                STRN_2 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(ENTER_2)", "")) Then
                ENTER_2 = DsStudents.Tables(0).Compute("SUM(ENTER_2)", "")
                ENTPER_2 = Format((ENTER_2 / STRN_2) * 100, "0.00")
            Else
                ENTER_2 = 0
                ENTPER_2 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(ISSUED_2)", "")) Then
                ISSD_2 = DsStudents.Tables(0).Compute("SUM(ISSUED_2)", "")
                ISSPER_2 = Format((ISSD_2 / STRN_2) * 100, "0.00")
            Else
                ISSD_2 = 0
                ISSPER_2 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(BAL_2)", "")) Then
                BAL_2 = DsStudents.Tables(0).Compute("SUM(BAL_2)", "")
                BALPER_2 = Format((BAL_2 / STRN_2) * 100, "0.00")
            Else
                BAL_2 = 0
                BALPER_2 = 0
            End If

            'JUNIOR

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(STRN_1)", "")) Then
                STRN_1 = DsStudents.Tables(0).Compute("SUM(STRN_1)", "")
            Else
                STRN_1 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(ENTER_1)", "")) Then
                ENTER_1 = DsStudents.Tables(0).Compute("SUM(ENTER_1)", "")
                ENTPER_1 = Format((ENTER_1 / STRN_1) * 100, "0.00")
            Else
                ENTER_1 = 0
                ENTPER_1 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(ISSUED_1)", "")) Then
                ISSD_1 = DsStudents.Tables(0).Compute("SUM(ISSUED_1)", "")
                ISSPER_1 = Format((ISSD_1 / STRN_1) * 100, "0.00")
            Else
                ISSD_1 = 0
                ISSPER_1 = 0
            End If

            If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(BAL_1)", "")) Then
                BAL_1 = DsStudents.Tables(0).Compute("SUM(BAL_1)", "")
                BALPER_1 = Format((BAL_1 / STRN_1) * 100, "0.00")
            Else
                BAL_1 = 0
                BALPER_1 = 0
            End If


            Tr5.Cells.Add(DataRightAllignmentStyle(STRN_2.ToString, "", "", 1, "", "", "True", 10, 8, "SENIOR Strength", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ENTER_2.ToString, "", "", 1, "", "", "True", 10, 8, "SENIOR Entered", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ENTPER_2.ToString, "", "", 1, "", "", "True", 10, 8, "SENIOR Entered %", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ISSD_2.ToString, "", "", 1, "", "", "True", 10, 8, "SENIOR Issued", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(ISSPER_2.ToString, "", "", 1, "", "", "True", 10, 8, "SENIOR Issued", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(BAL_2.ToString, "", "", 1, "", "", "True", 10, 8, "SENIOR Balance", "", , rowBackColor))
            Tr5.Cells.Add(DataRightAllignmentStyle(BALPER_2.ToString, "", "", 1, "", "", "True", 10, 8, "SENIOR Balance %", "", , rowBackColor))

            TableMain1.Rows.Add(Tr5)
            TableMain1.GridLines = GridLines.Both

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function BranchWiseDetailReportFormat()
        Try
            Dim i, j As Integer
            Dim rowcolor As Integer
            Dim rowBackColor As String
            Dim Dr1(), Dr2(), Dr3() As DataRow
            Dim REPORTON As String
            Dim TCYCOUNT As String
            For i = 0 To DsStudents.Tables(1).Rows.Count - 1
                If drpReportType.SelectedValue = 1 Then
                    REPORTON = "Branch"
                    Dr1 = DsStudents.Tables(0).Select("EXAMBRANCHSLNO=" & DsStudents.Tables(1).Rows(i)("EXAMBRANCHSLNO"), "")
                ElseIf drpReportType.SelectedValue = 3 Then
                    REPORTON = "Zone"
                    Dr1 = DsStudents.Tables(0).Select("ZONESLNO=" & DsStudents.Tables(1).Rows(i)("ZONESLNO"), "")
                ElseIf drpReportType.SelectedValue = 4 Then
                    REPORTON = "VC"
                    Dr1 = DsStudents.Tables(0).Select("VCSLNO=" & DsStudents.Tables(1).Rows(i)("VCSLNO"), "")
                ElseIf drpReportType.SelectedValue = 2 Then
                    REPORTON = "Division"
                    Dr1 = DsStudents.Tables(0).Select("EXAMREGIONSLNO=" & DsStudents.Tables(1).Rows(i)("EXAMREGIONSLNO"), "")
                End If

                If Dr1.Length > 0 Then
                    Dim Tr1 As New TableRow
                    Dim Tr2 As New TableRow
                    Dim Tr3 As New TableRow
                    Dim Tr5 As New TableRow
                    Dim Tr6 As New TableRow

                    Tr1.Cells.Add(DataRightAllignmentStyle("BACK", PUB_BACK1FORE_COLOR, PUB_BACK1_COLOR, 23, PUB_BACK1_COLOR, "Verdana", "true", 230, 10, "", "javascript:b()"))
                    TableMain1.Rows.Add(Tr1)

                    Tr2.Cells.Add(DataCenterAllignmentStyle(REPORTON & "Wise T C Details Report   (" & REPORTON & " Name : " & DsStudents.Tables(1).Rows(i)("NAME") & ")", "", "", 23, "", "Verdana", "true", 230, 10, "", ""))
                    Tr2.CssClass = "SubHeading1"
                    TableMain1.Rows.Add(Tr2)

                    Tr3.Cells.Add(DataLeftAllignmentStyle("Sno", "", "", 1, "", "", "True", 10, 9, "Sno", ""))
                    Tr3.Cells.Add(DataLeftAllignmentStyle("Board Admno", "", "White", 1, "White", "", "True", 10, 9, "Board Admno", ""))
                    Tr3.Cells.Add(DataLeftAllignmentStyle("Admno", "", "White", 1, "White", "", "True", 10, 9, "Admno", ""))
                    Tr3.Cells.Add(DataLeftAllignmentStyle("Name", "", "White", 1, "White", "", "True", 10, 9, "Student Name", ""))
                    Tr3.Cells.Add(DataLeftAllignmentStyle("Code", "", "White", 1, "White", "", "True", 10, 9, "Code", ""))
                    Tr3.Cells.Add(DataLeftAllignmentStyle("Issued", "", "White", 1, "White", "", "True", 10, 9, "Tot.Issued", ""))
                    Tr3.Cells.Add(DataLeftAllignmentStyle("Date", "", "White", 1, "White", "", "True", 10, 9, "Issued Date", ""))

                    Tr3.CssClass = "gridheader"
                    TableMain1.Rows.Add(Tr3)

                    For j = 0 To Dr1.Length - 1
                        Dim Tr4 As New TableRow
                        If rowcolor = 0 Then
                            rowBackColor = "GridItem"
                            rowcolor = 1
                        Else
                            rowBackColor = "GridAlternateItem"
                            rowcolor = 0
                        End If

                        Tr4.Cells.Add(DataLeftAllignmentStyle(j + 1, "", "", 1, "", "", "False", 10, 8, "Sno", "", , rowBackColor))
                        Tr4.Cells.Add(DataLeftAllignmentStyle(Dr1(j)("BOARDADMNO").ToString, "", "", 1, "", "", "False", 10, 8, "Board Admno", "", , rowBackColor))
                        Tr4.Cells.Add(DataLeftAllignmentStyle(Dr1(j)("ADMNO").ToString, "", "", 1, "", "", "False", 10, 8, "Admno", "", , rowBackColor))
                        Tr4.Cells.Add(DataLeftAllignmentStyle(Dr1(j)("BOARDNAME").ToString, "", "", 1, "", "", "False", 10, 8, "Student Name", "", , rowBackColor))
                        Tr4.Cells.Add(DataLeftAllignmentStyle(Dr1(j)("CODE").ToString, "", "", 1, "", "", "False", 10, 8, "Code", "", , rowBackColor))


                        If Not IsDBNull(Dr1(j)("TCISSUE")) Then
                            If Dr1(j)("TCISSUE").ToString > 0 Then
                                TCYCOUNT = " Y  [ " & Val(Dr1(j)("TCISSUE")).ToString & " ]"
                                Tr4.Cells.Add(DataRightAllignmentStyle(TCYCOUNT.ToString, "", "", 1, "", "", "False", 10, 8, "Tot.Issued", "", , rowBackColor))
                                Tr4.Cells.Add(DataLeftAllignmentStyle(Dr1(j)("TCDATE").ToString, "", "", 1, "", "", "False", 10, 8, "TC.Issued Date", "", , rowBackColor))
                            Else
                                TCYCOUNT = "   " ' N  [ " & Val(Dr1(j)("TCISSUE")).ToString & " ]"
                                Tr4.Cells.Add(DataRightAllignmentStyle(TCYCOUNT.ToString, "", "", 1, "", "", "False", 10, 8, "Tot.Issued", "", , rowBackColor))
                                Tr4.Cells.Add(DataLeftAllignmentStyle(Dr1(j)("TCDATE").ToString, "", "", 1, "", "", "False", 10, 8, "TC.Issued Date", "", , rowBackColor))
                            End If
                        Else
                            Tr4.Cells.Add(DataRightAllignmentStyle(" ", "", "", 1, "", "", "False", 10, 8, "Tot.Issued", "", , rowBackColor))
                            Tr4.Cells.Add(DataRightAllignmentStyle(" ", "", "", 1, "", "", "False", 10, 8, "Tot.Issued", "", , rowBackColor))
                        End If
                        TableMain1.Rows.Add(Tr4)
                    Next
                    Tr5.Cells.Add(DataRightAllignmentStyle("Totals", "", "", 5, "", "", "True", 10, 8, "Totals", "", , rowBackColor))
                    Dim TOTALTCYCOUNT, TOTALTCYCOUNT1 As String

                    ''
                    If drpReportType.SelectedValue = 1 Then
                        If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TCISSUE)", "EXAMBRANCHSLNO=" & DsStudents.Tables(1).Rows(i)("EXAMBRANCHSLNO"))) Then
                            TOTALTCYCOUNT = DsStudents.Tables(0).Compute("SUM(TCISSUE)", "EXAMBRANCHSLNO=" & DsStudents.Tables(1).Rows(i)("EXAMBRANCHSLNO"))
                            TOTALTCYCOUNT1 = " Y  [ " & TOTALTCYCOUNT & " ]"
                            Tr5.Cells.Add(DataRightAllignmentStyle(TOTALTCYCOUNT1, "", "", 1, "", "", "True", 10, 8, DsStudents.Tables(1).Rows(i)("NAME") & " Branch Total Issued", "", , rowBackColor))
                        Else
                            Tr5.Cells.Add(DataRightAllignmentStyle(" ", "", "", 1, "", "", "True", 10, 8, DsStudents.Tables(1).Rows(i)("NAME") & " Branch Total Issued", "", , rowBackColor))
                        End If
                    ElseIf drpReportType.SelectedValue = 3 Then
                        If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TCISSUE)", "ZONESLNO=" & DsStudents.Tables(1).Rows(i)("ZONESLNO"))) Then
                            TOTALTCYCOUNT = DsStudents.Tables(0).Compute("SUM(TCISSUE)", "ZONESLNO=" & DsStudents.Tables(1).Rows(i)("ZONESLNO"))
                            TOTALTCYCOUNT1 = " Y  [ " & TOTALTCYCOUNT & " ]"
                            Tr5.Cells.Add(DataRightAllignmentStyle(TOTALTCYCOUNT1, "", "", 1, "", "", "True", 10, 8, DsStudents.Tables(1).Rows(i)("NAME") & " Zone Total Issued", "", , rowBackColor))
                        Else
                            Tr5.Cells.Add(DataRightAllignmentStyle(" ", "", "", 1, "", "", "True", 10, 8, DsStudents.Tables(1).Rows(i)("NAME") & " Branch Total Issued", "", , rowBackColor))
                        End If
                    ElseIf drpReportType.SelectedValue = 4 Then
                        If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TCISSUE)", "VCSLNO=" & DsStudents.Tables(1).Rows(i)("VCSLNO"))) Then
                            TOTALTCYCOUNT = DsStudents.Tables(0).Compute("SUM(TCISSUE)", "VCSLNO=" & DsStudents.Tables(1).Rows(i)("VCSLNO"))
                            TOTALTCYCOUNT1 = " Y  [ " & TOTALTCYCOUNT & " ]"
                            Tr5.Cells.Add(DataRightAllignmentStyle(TOTALTCYCOUNT1, "", "", 1, "", "", "True", 10, 8, DsStudents.Tables(1).Rows(i)("NAME") & " VC Total Issued", "", , rowBackColor))
                        Else
                            Tr5.Cells.Add(DataRightAllignmentStyle(" ", "", "", 1, "", "", "True", 10, 8, DsStudents.Tables(1).Rows(i)("NAME") & " Branch Total Issued", "", , rowBackColor))
                        End If
                    ElseIf drpReportType.SelectedValue = 2 Then
                        If Not IsDBNull(DsStudents.Tables(0).Compute("SUM(TCISSUE)", "EXAMREGIONSLNO=" & DsStudents.Tables(1).Rows(i)("EXAMREGIONSLNO"))) Then
                            TOTALTCYCOUNT = DsStudents.Tables(0).Compute("SUM(TCISSUE)", "EXAMREGIONSLNO=" & DsStudents.Tables(1).Rows(i)("EXAMREGIONSLNO"))
                            TOTALTCYCOUNT1 = " Y  [ " & TOTALTCYCOUNT & " ]"
                            Tr5.Cells.Add(DataRightAllignmentStyle(TOTALTCYCOUNT1, "", "", 1, "", "", "True", 10, 8, DsStudents.Tables(1).Rows(i)("NAME") & " Division Total Issued", "", , rowBackColor))
                        Else
                            Tr5.Cells.Add(DataRightAllignmentStyle(" ", "", "", 1, "", "", "True", 10, 8, DsStudents.Tables(1).Rows(i)("NAME") & " Branch Total Issued", "", , rowBackColor))
                        End If
                    End If
                    ''



                    TableMain1.Rows.Add(Tr5)
                End If
            Next

            TableMain1.GridLines = GridLines.Both

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "ImgEvents"

    Private Sub iBtnReport_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnReport.Click
        Try
            If Not ValidateFunction() Then Exit Sub

            Util = New Utility

            If DrpReporton.SelectedValue = 1 Then 'summary
                GenerateSqlQueryMod()
                GenerateSqlQueryModDetails()
                DsStudents = Util.DataSet_TwoFetch(StrSql, StrSql1)
                AddingColsToDataset(DsStudents)
                Me.Session("DsStudents") = DsStudents
                If DsStudents.Tables(0).Rows.Count > 0 Then
                    Table1.Visible = False
                    Session("SORTCOLUMN") = "NAME"
                    Session("SORTTYPE") = " ASC"
                    Session("DsStudents") = DsStudents
                    If DrpCourse.SelectedValue = 1 Then
                        BranchWiseSummaryReportFormatJR()
                    ElseIf DrpCourse.SelectedValue = 2 Then
                        BranchWiseSummaryReportFormatSR()
                    Else
                        BranchWiseSummaryReportFormat()
                    End If

                Else
                        StartUpScript(iBtnReport.ID, "No Data Found.")
                    End If

                ElseIf DrpReporton.SelectedValue = 2 Then 'details
                GenerateSqlQuery()
                GettingBranchSqlQueryFormat()
                DsStudents = Util.DataSet_TwoFetch(StrSql, StrSql1)
                Me.Session("DsStudents") = DsStudents
                If DsStudents.Tables(0).Rows.Count > 0 Then
                    Table1.Visible = False
                    BranchWiseDetailReportFormat()

                Else
                    StartUpScript(iBtnReport.ID, "No Data Found.")
                End If
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

End Class
