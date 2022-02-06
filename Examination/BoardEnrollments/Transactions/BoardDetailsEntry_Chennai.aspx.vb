'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : Board Enrollment Entry Details(Chennai)
'                                       
'                                       
'   AUTHOR                            : I.CHANDRA
'   INITIAL BASELINE DATE             : 14-NOV-2019
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Public Class BoardDetailsEntry_Chennai
    Inherits System.Web.UI.Page


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    'Protected WithEvents txtAdmno As System.Web.UI.WebControls.TextBox
    'Protected WithEvents lblFound As System.Web.UI.WebControls.Label
    'Protected WithEvents LblAdmNoSearch As System.Web.UI.WebControls.Label
    'Protected WithEvents txtAdmNoSearch As System.Web.UI.WebControls.TextBox
    'Protected WithEvents lblBranchSearch As System.Web.UI.WebControls.Label
    'Protected WithEvents drpBranchSearch As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents iBtnSearch As System.Web.UI.WebControls.ImageButton
    'Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    'Protected WithEvents txtSurName As System.Web.UI.WebControls.TextBox
    'Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    'Protected WithEvents txtSName As System.Web.UI.WebControls.TextBox
    'Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    'Protected WithEvents txtFname As System.Web.UI.WebControls.TextBox
    'Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    'Protected WithEvents LblCode As System.Web.UI.WebControls.Label
    'Protected WithEvents Label25 As System.Web.UI.WebControls.Label
    'Protected WithEvents DrpDist As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents Label26 As System.Web.UI.WebControls.Label
    'Protected WithEvents DrpColl As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    'Protected WithEvents TxtBid As System.Web.UI.WebControls.TextBox
    'Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    'Protected WithEvents TxtBAdmno As System.Web.UI.WebControls.TextBox
    'Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    'Protected WithEvents TxtBName As System.Web.UI.WebControls.TextBox
    'Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    'Protected WithEvents DrpComm As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    'Protected WithEvents DrpCaste As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents Label21 As System.Web.UI.WebControls.Label
    'Protected WithEvents TxtBFname As System.Web.UI.WebControls.TextBox
    'Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    'Protected WithEvents TxtDob As System.Web.UI.WebControls.TextBox
    'Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    'Protected WithEvents DrpPrvExm As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents Label22 As System.Web.UI.WebControls.Label
    'Protected WithEvents TxtBhtno As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtAadhar As System.Web.UI.WebControls.TextBox
    'Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    'Protected WithEvents DrpYOp As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents Label18 As System.Web.UI.WebControls.Label
    'Protected WithEvents DrpCateg As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents Label23 As System.Web.UI.WebControls.Label
    'Protected WithEvents DrpPh As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents TxtPhper As System.Web.UI.WebControls.TextBox
    'Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    'Protected WithEvents DrpFlang As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents drpAdmBranch As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    'Protected WithEvents DrpSlang As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents Label24 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    'Protected WithEvents TxtDtAdm As System.Web.UI.WebControls.TextBox
    'Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    'Protected WithEvents DrpCourse As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    'Protected WithEvents TxtMole1 As System.Web.UI.WebControls.TextBox
    'Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    'Protected WithEvents TxtMole2 As System.Web.UI.WebControls.TextBox
    'Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    'Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    'Protected WithEvents TxtBMname As System.Web.UI.WebControls.TextBox
    'Protected WithEvents Label27 As System.Web.UI.WebControls.Label
    'Protected WithEvents DrpMotherTounge As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents Label28 As System.Web.UI.WebControls.Label
    'Protected WithEvents DrpSubCaste As System.Web.UI.WebControls.DropDownList

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
    Private BrdStu As ClsBoardEnrollment
    Private USERSLNO As Integer
    Dim ClsUty As New Utility
#End Region

#Region " PageEvents"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
        USERSLNO = Session("USERSLNO")

        If Not IsPostBack Then
            FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
            BranchComboFill()
        End If
    End Sub

#End Region

#Region "Fill Methods"

    Private Sub BranchComboFill()
        Dim Ds As DataSet
        Ds = ClsUty.FillUserWise_ExamBranchChennai(USERSLNO, Session("COMACADEMICSLNO"))
        drpBranchSearch.DataSource = Ds
        drpBranchSearch.DataTextField = "EXAMBRANCHNAME"
        drpBranchSearch.DataValueField = "EXAMBRANCHSLNO"
        drpBranchSearch.DataBind()
    End Sub
    Private Sub AdmBranchComboFill()
        Dim Ds As DataSet
        Ds = ClsUty.FillUserWiseADM_ExamBranchChennai(Session("COMACADEMICSLNO"))
        drpAdmBranch.DataSource = Ds
        drpAdmBranch.DataTextField = "BRANCHNAME"
        drpAdmBranch.DataValueField = "ADMBRANCHSLNO"
        drpAdmBranch.DataBind()
    End Sub

    Private Sub FillControls(ByVal Ds As DataSet)
        Try
            txtSurName.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SURNAME")), "", Ds.Tables(0).Rows(0)("SURNAME"))
            txtSName.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("NAME")), "", Ds.Tables(0).Rows(0)("NAME"))
            txtFname.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("FNAME")), "", Ds.Tables(0).Rows(0)("FNAME"))

            ''TxtBid.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDID")), "", Ds.Tables(0).Rows(0)("BOARDID"))
            TxtBAdmno.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDADMNO")), "", Ds.Tables(0).Rows(0)("BOARDADMNO"))
            TxtBName.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDNAME")), "", Ds.Tables(0).Rows(0)("BOARDNAME"))
            TxtBFname.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("FATHERNAME")), "", Ds.Tables(0).Rows(0)("FATHERNAME"))
            TxtBMname.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("MOTHERNAME")), "", Ds.Tables(0).Rows(0)("MOTHERNAME"))
            txtNationality.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("NATIONALITY")), "", Ds.Tables(0).Rows(0)("NATIONALITY"))
            txtCaste.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SCHEDULE_CASTE")), "", Ds.Tables(0).Rows(0)("SCHEDULE_CASTE"))
            txtSchool_Class.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SCHOOL_CLASS")), "", Ds.Tables(0).Rows(0)("SCHOOL_CLASS"))
            TxtDob.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("DOB")), "", Ds.Tables(0).Rows(0)("DOB"))
            txtDobwords.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("DOB_WORDS")), "", Ds.Tables(0).Rows(0)("DOB_WORDS"))
            txtLastStudied.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("LAST_STUDIED")), "", Ds.Tables(0).Rows(0)("LAST_STUDIED"))
            txtLastStudies_words.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("LAST_STUDIED_WORDS")), "", Ds.Tables(0).Rows(0)("LAST_STUDIED_WORDS"))
            txtBoardLastExam.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARD_LASTEXAM")), "", Ds.Tables(0).Rows(0)("BOARD_LASTEXAM"))
            txtTwiceClass.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("TWICE_CLASS")), "", Ds.Tables(0).Rows(0)("TWICE_CLASS"))
            txtSubject1.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SUBJECT1")), "", Ds.Tables(0).Rows(0)("SUBJECT1"))
            txtSubject2.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SUBJECT2")), "", Ds.Tables(0).Rows(0)("SUBJECT2"))
            txtSubject3.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SUBJECT3")), "", Ds.Tables(0).Rows(0)("SUBJECT3"))
            txtSubject4.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SUBJECT4")), "", Ds.Tables(0).Rows(0)("SUBJECT4"))
            txtSubject5.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SUBJECT5")), "", Ds.Tables(0).Rows(0)("SUBJECT5"))
            txtSubject6.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SUBJECT6")), "", Ds.Tables(0).Rows(0)("SUBJECT6"))
            txtQualClass.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("QUAL_CLASS")), "", Ds.Tables(0).Rows(0)("QUAL_CLASS"))
            txtQualClass_words.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("QUAL_CLASS_WORDS")), "", Ds.Tables(0).Rows(0)("QUAL_CLASS_WORDS"))
            txtPaid.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("DUES_PAID")), "", Ds.Tables(0).Rows(0)("DUES_PAID"))
            txtConcession.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("CONCESSION")), "", Ds.Tables(0).Rows(0)("CONCESSION"))
            txtTotWork.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("TOT_WORKDAYS")), "", Ds.Tables(0).Rows(0)("TOT_WORKDAYS"))
            txtWorkPre.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("WORK_DAYSPRE")), "", Ds.Tables(0).Rows(0)("WORK_DAYSPRE"))
            txtNCC.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("NCC")), "", Ds.Tables(0).Rows(0)("NCC"))
            txtGames.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("GAMES_ACTIV")), "", Ds.Tables(0).Rows(0)("GAMES_ACTIV"))
            txtConduct.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("CONDUCT")), "", Ds.Tables(0).Rows(0)("CONDUCT"))
            txtApplCert.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("APPL_CERT")), "", Ds.Tables(0).Rows(0)("APPL_CERT"))
            txtIssueCert.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("ISSUE_CERT")), "", Ds.Tables(0).Rows(0)("ISSUE_CERT"))
            txtLeaving.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("REASON_LEAVING")), "", Ds.Tables(0).Rows(0)("REASON_LEAVING"))
            txtRemarks.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("OTHER_REMARKS")), "", Ds.Tables(0).Rows(0)("OTHER_REMARKS"))

            txtAadhar.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("AADHAR")), "", Ds.Tables(0).Rows(0)("AADHAR"))
            LblCode.Text = Ds.Tables(0).Rows(0)("COURSE").ToString & " / " & Ds.Tables(0).Rows(0)("GROUP1").ToString & " / " & Ds.Tables(0).Rows(0)("BATCH").ToString & _
                           " / " & Ds.Tables(0).Rows(0)("MEDIUM").ToString & " / " + Ds.Tables(0).Rows(0)("TYPE").ToString & " / " & Ds.Tables(0).Rows(0)("SECTION").ToString

            fillDrpColl(drpBranchSearch.SelectedValue)
            AdmBranchComboFill()

            drpAdmBranch.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("ADMBRANCHSLNO")), 0, Ds.Tables(0).Rows(0)("ADMBRANCHSLNO"))

            ViewState("ADMNO") = Ds.Tables(0).Rows(0)("ADMNO")
            ViewState("ADMSNO") = Ds.Tables(0).Rows(0)("ADMSNO")
            ViewState("BRANCHSLNO") = Ds.Tables(0).Rows(0)("BRANCHSLNO")
            ViewState("ADMSLNO") = Ds.Tables(0).Rows(0)("ADMSLNO")
            ViewState("UNIQUENO") = Ds.Tables(0).Rows(0)("UNIQUENO")
            Dim drpcollds As DataSet
            drpcollds = Session("DrpCollDs")
            Dim Dr1() As DataRow
            Dr1 = drpcollds.Tables(0).Select("BOARDCOLLEGESLNO=" & Ds.Tables(0).Rows(0)("BOARDCOLLEGESLNO"))
            If Dr1.Length > 0 Then
                DrpColl.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDCOLLEGESLNO")), 0, Ds.Tables(0).Rows(0)("BOARDCOLLEGESLNO"))
            Else
                DrpColl.SelectedValue = 0
            End If

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub fillDrpColl(ByVal EBSLNO As Integer)

        Dim Ds As DataSet
        BrdStu = New ClsBoardEnrollment
        Ds = BrdStu.P_AcaEbCol_Select(EBSLNO, Session("comacademicslno"))
        DrpColl.DataSource = Ds.Tables(0)
        DrpColl.DataTextField = "COLLEGENAME"
        DrpColl.DataValueField = "BOARDCOLLEGESLNO"
        DrpColl.DataBind()
        Session("DrpCollDs") = Ds
        DrpColl.Items.Insert(0, New ListItem("-Select-", 0))

    End Sub


#End Region

#Region "Methods"

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")

        If focusCtrl <> "" And strMessage <> "" Then
            RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & FormName & "." & focusCtrl & " == '[object]') { document." & FormName & "." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
        ElseIf strMessage <> "" Then
            RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
        ElseIf focusCtrl <> "" Then
            RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & FormName & "." & focusCtrl & " == '[object]') { document." & FormName & "." & focusCtrl & ".focus(); } </script>")
        End If


    End Sub

    Private Sub ClearControls(ByVal PL As Integer)
        If PL = 0 Then
            txtAdmNoSearch.Text = ""
        End If

        txtSurName.Text = ""
        txtSName.Text = ""
        txtFname.Text = ""
        LblCode.Text = ""

        TxtBAdmno.Text = ""
        TxtBName.Text = ""
        TxtBFname.Text = ""
        TxtBMname.Text = ""
        txtNationality.Text = ""
        txtCaste.Text = ""
        txtSchool_Class.Text = ""
        TxtDob.Text = ""
        txtDobwords.Text = ""
        txtLastStudied.Text = ""
        txtLastStudies_words.Text = ""
        txtBoardLastExam.Text = ""
        txtTwiceClass.Text = ""
        txtSubject1.Text = ""
        txtSubject2.Text = ""
        txtSubject3.Text = ""
        txtSubject4.Text = ""
        txtSubject5.Text = ""
        txtSubject6.Text = ""
        txtQualClass.Text = ""
        txtQualClass_words.Text = ""
        txtPaid.Text = ""
        txtConcession.Text = ""
        txtTotWork.Text = ""
        txtWorkPre.Text = ""
        txtNCC.Text = ""
        txtGames.Text = ""
        txtConduct.Text = ""
        txtApplCert.Text = ""
        txtIssueCert.Text = ""
        txtLeaving.Text = ""
        txtRemarks.Text = ""
        txtAadhar.Text = ""
        DrpColl.Items.Clear()

    End Sub

    Private Function SetEntries() As ArrayList
        Dim Arr As New ArrayList

        '''''''''''''''''''''' 1 '''''''''''''''''''''''''

        If Trim(TxtBAdmno.Text) = "" Then                   '--0
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBAdmno.Text)))
        End If

        If DrpColl.SelectedItem.Value <= 0 Then             '--1
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpColl.SelectedValue))
        End If

        If Trim(TxtBName.Text) = "" Then                    '--2
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBName.Text)))
        End If

        If Trim(TxtBFname.Text) = "" Then                   '--3
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBFname.Text)))
        End If

        If Trim(TxtBMname.Text) = "" Then                   '--4
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBMname.Text)))
        End If

        If Trim(txtNationality.Text) = "" Then              '--5
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtNationality.Text)))
        End If

        If Trim(txtCaste.Text) = "" Then                    '--6
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtCaste.Text)))
        End If

        If Trim(txtSchool_Class.Text) = "" Then             '--7
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtSchool_Class.Text)))
        End If

        If Trim(TxtDob.Text) = "" Then                      '--8
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(DateConversion(Trim(TxtDob.Text)))
        End If

        If Trim(txtDobwords.Text) = "" Then                 '--9
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtDobwords.Text)))
        End If

        If Trim(txtLastStudied.Text) = "" Then              '--10
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtLastStudied.Text)))
        End If

        If Trim(txtLastStudies_words.Text) = "" Then        '--11
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtLastStudies_words.Text)))
        End If

        If Trim(txtBoardLastExam.Text) = "" Then            '--12
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtBoardLastExam.Text)))
        End If

        If Trim(txtTwiceClass.Text) = "" Then               '--13
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtTwiceClass.Text)))
        End If

        If Trim(txtSubject1.Text) = "" Then                 '--14
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtSubject1.Text)))
        End If

        If Trim(txtSubject2.Text) = "" Then                 '--15
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtSubject2.Text)))
        End If

        If Trim(txtSubject3.Text) = "" Then                 '--16
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtSubject3.Text)))
        End If

        If Trim(txtSubject4.Text) = "" Then                 '--17
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtSubject4.Text)))
        End If

        If Trim(txtSubject5.Text) = "" Then                 '--18
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtSubject5.Text)))
        End If

        If Trim(txtSubject6.Text) = "" Then                 '--19
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtSubject6.Text)))
        End If

        If Trim(txtQualClass.Text) = "" Then                '--20
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtQualClass.Text)))
        End If

        If Trim(txtQualClass_words.Text) = "" Then          '--21
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtQualClass_words.Text)))
        End If

        If Trim(txtPaid.Text) = "" Then                     '--22
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtPaid.Text)))
        End If

        If Trim(txtConcession.Text) = "" Then               '--23
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtConcession.Text)))
        End If

        If Trim(txtTotWork.Text) = "" Then                  '--24
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtTotWork.Text)))
        End If

        If Trim(txtWorkPre.Text) = "" Then                  '--25
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtWorkPre.Text)))
        End If

        If Trim(txtNCC.Text) = "" Then                      '--26
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtNCC.Text)))
        End If

        If Trim(txtGames.Text) = "" Then                    '--27
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtGames.Text)))
        End If

        If Trim(txtConduct.Text) = "" Then                  '--28
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtConduct.Text)))
        End If

        If Trim(txtApplCert.Text) = "" Then                 '--29
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtApplCert.Text)))
        End If

        If Trim(txtIssueCert.Text) = "" Then                '--30
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtIssueCert.Text)))
        End If

        If Trim(txtLeaving.Text) = "" Then                  '--31
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtLeaving.Text)))
        End If

        If Trim(txtRemarks.Text) = "" Then                  '--32
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtRemarks.Text)))
        End If

        If Trim(txtAadhar.Text) = "" Then                   '--33
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtAadhar.Text)))
        End If

        If drpAdmBranch.SelectedValue <= 0 Then             '--34 
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(drpAdmBranch.SelectedValue))
        End If

        Arr.Add(Session("COMACADEMICSLNO"))                 '--35
        Arr.Add(ViewState("UNIQUENO"))                      '--36
        Arr.Add(ViewState("ADMSLNO"))                       '--37

        Return Arr
    End Function

    Private Function ValidateForm() As Boolean
        Try
            If TxtBAdmno.Text.Trim = "" Then
                StartUpScript(TxtBAdmno.ID, " Enter BoardAdmno with year ")
                Return False
            ElseIf TxtBName.Text.Trim = "" Then
                StartUpScript(TxtBName.ID, " Enter BoardName")
                Return False
            ElseIf TxtBFname.Text.Trim = "" Then
                StartUpScript(TxtBFname.ID, " Enter Father Name")
                Return False
            ElseIf TxtBMname.Text.Trim = "" Then
                StartUpScript(TxtBMname.ID, " Enter Mother Name")
                Return False
            ElseIf TxtDob.Text.Trim = "" Then
                StartUpScript(TxtDob.ID, " Enter Date of Birth ")
                Return False
            ElseIf DrpColl.SelectedValue = 0 Then
                StartUpScript(DrpColl.ID, " Select Board College ")
                Return False            
            ElseIf Trim(txtAadhar.Text) <> "" Then
                If Not IsNumeric(Trim(txtAadhar.Text)) Then
                    StartUpScript(txtAadhar.ID, "Enter Numbers only.")
                    Return False
                End If
            End If
            If Len(Trim(txtAadhar.Text)) <> 12 Then
                StartUpScript(txtAadhar.ID, "Aadhar Must Be 12 Digits.")
                Return False
            End If

            Return True
        Catch ex As Exception

        End Try

    End Function

#End Region

#Region "Button Events"

    Private Sub iBtnSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSearch.Click
        Try
            Dim Ds As DataSet
            ClearControls(1)

            If Trim(txtAdmNoSearch.Text) = "" Then
                StartUpScript(txtAdmNoSearch.ID, "Enter Adm.No.")
                Exit Sub
            ElseIf Not IsNumeric(Trim(txtAdmNoSearch.Text)) Then
                StartUpScript(txtAdmNoSearch.ID, "Enter numbers only.")
                Exit Sub
            End If
            BrdStu = New ClsBoardEnrollment
            Ds = BrdStu.GetDataForStudent_Chennai(txtAdmNoSearch.Text, drpBranchSearch.SelectedValue, Session("COMACADEMICSLNO"))
            If Not Ds Is Nothing Then
                If Ds.Tables(0).Rows.Count > 0 Then
                    FillControls(Ds)
                    lblFound.Text = "Student found."
                Else
                    lblFound.Text = "Student not found."
                End If
            Else
                lblFound.Text = "Student not found."

            End If
            ' AdmBranchComboFill()
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Try
            Dim RtnValue As Integer
            If Not ValidateForm() Then Exit Sub

            BrdStu = New ClsBoardEnrollment
            RtnValue = BrdStu.Student_Chennai_Update(SetEntries())
            If RtnValue = 1 Then
                StartUpScript("", "Board Details Updated Sucessfully..!")
                ClearControls(0)

            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
