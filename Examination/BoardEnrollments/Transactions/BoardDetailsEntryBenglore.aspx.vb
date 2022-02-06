Imports CollegeBoardDLL
Public Class BoardDetailsEntryBenglore
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
        Ds = ClsUty.FillUserWise_ExamBranchBanglore(USERSLNO, Session("COMACADEMICSLNO"))
        drpBranchSearch.DataSource = Ds
        drpBranchSearch.DataTextField = "EXAMBRANCHNAME"
        drpBranchSearch.DataValueField = "EXAMBRANCHSLNO"
        drpBranchSearch.DataBind()
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

    Private Sub FillControls(ByVal Ds As DataSet)
        Try
            txtSurName.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SURNAME")), "", Ds.Tables(0).Rows(0)("SURNAME"))
            txtSName.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("NAME")), "", Ds.Tables(0).Rows(0)("NAME"))
            txtFname.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("FNAME")), "", Ds.Tables(0).Rows(0)("FNAME"))

            TxtBAdmno.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDADMNO")), "", Ds.Tables(0).Rows(0)("BOARDADMNO"))
            txtDateofAdm.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("DATEOFADMISSION")), "", Ds.Tables(0).Rows(0)("DATEOFADMISSION"))
            TxtBName.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDNAME")), "", Ds.Tables(0).Rows(0)("BOARDNAME"))
            TxtBFname.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("FATHERNAME")), "", Ds.Tables(0).Rows(0)("FATHERNAME"))
            TxtBMname.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("MOTHERNAME")), "", Ds.Tables(0).Rows(0)("MOTHERNAME"))
            txtNationality.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("NATIONALITY")), "", Ds.Tables(0).Rows(0)("NATIONALITY"))

            radSCST.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SCHEDULE_CASTE")), "", Ds.Tables(0).Rows(0)("SCHEDULE_CASTE"))


            txtcaste.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("CASTE")), "", Ds.Tables(0).Rows(0)("CASTE"))
            txtreligion.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("RELIGION")), "", Ds.Tables(0).Rows(0)("RELIGION"))
            TxtDob.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("DOB")), "", Ds.Tables(0).Rows(0)("DOB"))


            ddlLastStudied.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("LAST_STUDIED")), "", Ds.Tables(0).Rows(0)("LAST_STUDIED"))

            drpgender.SelectedItem.Value = IIf(IsDBNull(Ds.Tables(0).Rows(0)("GENDER")), "", Ds.Tables(0).Rows(0)("GENDER"))
            ddlQualClass_words.SelectedItem.Value = IIf(IsDBNull(Ds.Tables(0).Rows(0)("QUAL_CLASS_WORDS")), "", Ds.Tables(0).Rows(0)("QUAL_CLASS_WORDS"))
            RadioPaid.SelectedItem.Value = IIf(IsDBNull(Ds.Tables(0).Rows(0)("DUES_PAID")), "", Ds.Tables(0).Rows(0)("DUES_PAID"))
            txtConcession.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("CONCESSION")), "", Ds.Tables(0).Rows(0)("CONCESSION"))
            txtTotWork.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("TOT_WORKDAYS")), "", Ds.Tables(0).Rows(0)("TOT_WORKDAYS"))
            txtWorkPre.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("WORK_DAYSPRE")), "", Ds.Tables(0).Rows(0)("WORK_DAYSPRE"))
            txtlastattend.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("LASTATTEND")), "", Ds.Tables(0).Rows(0)("LASTATTEND"))
            txtConduct.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("CONDUCT")), "", Ds.Tables(0).Rows(0)("CONDUCT"))
            txtIssueCert.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("ISSUE_CERT")), "", Ds.Tables(0).Rows(0)("ISSUE_CERT"))
            LblCode.Text = Ds.Tables(0).Rows(0)("COURSE").ToString & " / " & Ds.Tables(0).Rows(0)("GROUP1").ToString & " / " & Ds.Tables(0).Rows(0)("BATCH").ToString & _
                           " / " & Ds.Tables(0).Rows(0)("MEDIUM").ToString & " / " + Ds.Tables(0).Rows(0)("TYPE").ToString & " / " & Ds.Tables(0).Rows(0)("SECTION").ToString
            txtstudent.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("STUDENTSAT")), "", Ds.Tables(0).Rows(0)("STUDENTSAT"))
            txtSAT.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("STUDENTUNIQNO")), "", Ds.Tables(0).Rows(0)("STUDENTUNIQNO"))
            txtSubject1.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SUBJECT1")), "", Ds.Tables(0).Rows(0)("SUBJECT1"))
            txtSubject2.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SUBJECT2")), "", Ds.Tables(0).Rows(0)("SUBJECT2"))
            txtSubject3.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SUBJECT3")), "", Ds.Tables(0).Rows(0)("SUBJECT3"))
            txtSubject4.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SUBJECT4")), "", Ds.Tables(0).Rows(0)("SUBJECT4"))
            radlanguage.SelectedItem.Value = IIf(IsDBNull(Ds.Tables(0).Rows(0)("LAST_STUDIED")), "", Ds.Tables(0).Rows(0)("LAST_STUDIED"))
            txtmedium.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("MEDIUM")), "", Ds.Tables(0).Rows(0)("MEDIUM"))

            txtsubcaste.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SUBCASTE")), "", Ds.Tables(0).Rows(0)("SUBCASTE"))
            txtother.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("OTHER")), "", Ds.Tables(0).Rows(0)("OTHER"))
            fillDrpColl(drpBranchSearch.SelectedValue)
            'AdmBranchComboFill()
            ' RadioButtonList1.SelectedItem.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("LANGUAGESECOND")), "", Ds.Tables(0).Rows(0)("LANGUAGESECOND"))
            RadioButtonList2.SelectedItem.Value = 3
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

    'Private Sub fillscsctrad()

    '    Dim Ds As DataSet
    '    BrdStu = New ClsBoardEnrollment
    '    Ds = BrdStu.P_AcaEbCol_Select(EBSLNO, Session("comacademicslno"))
    '    DrpColl.DataSource = Ds.Tables(0)
    '    DrpColl.DataTextField = "COLLEGENAME"
    '    DrpColl.DataValueField = "BOARDCOLLEGESLNO"
    '    DrpColl.DataBind()
    '    Session("DrpCollDs") = Ds
    '    DrpColl.Items.Insert(0, New ListItem("-Select-", 0))
    '    DrpColl.Items.Insert(0, New ListItem("-Select-", 0))
    '    DrpColl.Items.Insert(0, New ListItem("-Select-", 0))

    'End Sub


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

        TxtBName.Text = ""
        TxtBFname.Text = ""
        TxtBMname.Text = ""
        txtNationality.Text = ""
        txtcaste.Text = ""
        TxtDob.Text = ""
        'ddlLastStudied.SelectedValue = ""
        '' txtLastStudies_words.Text = ""
        'ddlQualClass_words.SelectedValue = ""
        ' txtPaid.Text = ""
        txtConcession.Text = ""
        txtTotWork.Text = ""
        txtWorkPre.Text = ""
        txtConduct.Text = ""
        txtIssueCert.Text = ""

    End Sub

    Private Function SetEntries() As ArrayList
        Dim Arr As New ArrayList

        '''''''''''''''''''''' 1 '''''''''''''''''''''''''
        If Trim(TxtBAdmno.Text) = "" Then                  '--1
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBAdmno.Text)))
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

        If Trim(txtreligion.Text) = "" Then              '--6
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtreligion.Text)))
        End If

        If Trim(txtcaste.Text) = "" Then                    '--7
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtcaste.Text)))
        End If

        If Trim(radSCST.SelectedItem.Value) = "" Then                    '--8
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(radSCST.SelectedItem.Value))
        End If


        If Trim(drpgender.SelectedItem.Value) = "" Then                    '--9
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(drpgender.SelectedItem.Value)))
        End If

        If Trim(ddlQualClass_words.SelectedItem.Value) = "" Then          '--10
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(ddlQualClass_words.SelectedItem.Value))
        End If

        If Trim(ddlLastStudied.SelectedItem.Value) = "" Then              '--11
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(ddlLastStudied.SelectedItem.Value))
        End If

        If Trim(RadioPaid.SelectedValue) = "" Then                     '--12
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(RadioPaid.SelectedValue)))
        End If

        If Trim(txtConcession.Text) = "" Then               '--13
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtConcession.Text)))
        End If

        If Trim(txtTotWork.Text) = "" Then                  '--14
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtTotWork.Text)))
        End If

        If Trim(txtWorkPre.Text) = "" Then                  '--15
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtWorkPre.Text)))
        End If

        If Trim(txtlastattend.Text) = "" Then                     '--16
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtlastattend.Text)))
        End If
        If Trim(txtConduct.Text) = "" Then                  '--17
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtConduct.Text)))
        End If
        If Trim(txtIssueCert.Text) = "" Then                '--18
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(txtIssueCert.Text))
        End If
        Arr.Add(Session("COMACADEMICSLNO"))                 '--19
        Arr.Add(ViewState("UNIQUENO"))                      '--20

        If DrpColl.SelectedItem.Value <= 0 Then             '--21
            Arr.Add(System.DBNull.Value)
            ' Arr.Add("25")
        Else
            Arr.Add(Trim(DrpColl.SelectedValue))
        End If

        If Trim(txtDateofAdm.Text) = "" Then                     '--22
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtDateofAdm.Text)))

        End If
        If Trim(TxtDob.Text) = "" Then                      '--23
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtDob.Text)))
        End If

        If Trim(txtSubject1.Text) = "" Then                  '--24
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtSubject1.Text)))
        End If
        If Trim(txtSubject2.Text) = "" Then                  '--25
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtSubject2.Text)))
        End If
        If Trim(txtSubject3.Text) = "" Then                  '--26
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtSubject3.Text)))
        End If
        If Trim(txtSubject4.Text) = "" Then                  '--27
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtSubject4.Text)))
        End If
        If Trim(radlanguage.SelectedItem.Text) = "" Then                  '--28
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(radlanguage.SelectedItem.Value)))
        End If
        If Trim(txtmedium.Text) = "" Then                  '--29
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtmedium.Text)))
        End If
        If Trim(txtsubcaste.Text) = "" Then                  '--30
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtsubcaste.Text)))
        End If

        If Trim(txtSAT.Text) = "" Then                  '--31
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtSAT.Text)))
        End If

        If Trim(txtstudent.Text) = "" Then                  '--32
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtstudent.Text)))
        End If
        If Trim(RadioButtonList2.SelectedItem.Value) = "" Then                  '--28
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(RadioButtonList2.SelectedItem.Value)))
        End If

        If Trim(txtother.Text) = "" Then                  '--28
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtother.Text)))
        End If


        Return Arr
    End Function

    Private Function ValidateForm() As Boolean
        Try

            If TxtBName.Text.Trim = "" Then
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
            Ds = BrdStu.GetDataForStudent_Benglore(txtAdmNoSearch.Text, drpBranchSearch.SelectedValue, Session("COMACADEMICSLNO"))
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
            RtnValue = BrdStu.Student_Bengalore_Update(SetEntries())
            If RtnValue = 1 Then

                ClearControls(0)
                StartUpScript("", "Board Details Updated Sucessfully..!")
                ' Page.Response.Redirect(Request.RawUrl.ToString(), False)
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

    'Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
    '    If RadioButtonList1.SelectedValue = 5 Then
    '        txtother.ReadOnly = False
    '    Else
    '        txtother.ReadOnly = True
    '    End If
    'End Sub


    Protected Sub RadioButtonList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList2.SelectedIndexChanged
        If RadioButtonList2.SelectedValue = 5 Then
            txtother.ReadOnly = False
        Else
            txtother.ReadOnly = True
        End If
    End Sub
End Class