Imports CollegeBoardDLL
Public Class StudentBoardDetailsRes
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtAdmno As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblFound As System.Web.UI.WebControls.Label
    Protected WithEvents LblAdmNoSearch As System.Web.UI.WebControls.Label
    Protected WithEvents txtAdmNoSearch As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblBranchSearch As System.Web.UI.WebControls.Label
    Protected WithEvents drpBranchSearch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents iBtnSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSurName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtFname As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents LblCode As System.Web.UI.WebControls.Label
    Protected WithEvents Label25 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpDist As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label26 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpColl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtBid As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtBAdmno As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtBName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpComm As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpCaste As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label21 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtBFname As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtDob As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpPrvExm As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label22 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtBhtno As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpYOp As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label18 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpCateg As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label23 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpPh As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TxtPhper As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpFlang As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpSlang As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label24 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtDtAdm As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpCourse As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtMole1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtMole2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtBMname As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label27 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpMotherTounge As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label28 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpSubCaste As System.Web.UI.WebControls.DropDownList
    ' Protected WithEvents txtAadhar As System.Web.UI.WebControls.TextBox
    ' Protected WithEvents drpAdmBranch As System.Web.UI.WebControls.DropDownList

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
        Ds = ClsUty.FillUserWise_ExamBranch(USERSLNO, Session("COMACADEMICSLNO"))
        drpBranchSearch.DataSource = Ds
        drpBranchSearch.DataTextField = "EXAMBRANCHNAME"
        drpBranchSearch.DataValueField = "EXAMBRANCHSLNO"
        drpBranchSearch.DataBind()
    End Sub

    Private Sub AdmBranchComboFill()
        Dim Ds As DataSet
        Ds = ClsUty.FillUserWise_AdmBranch(Session("COMACADEMICSLNO"))
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
            TxtBid.Text = ""
            TxtBAdmno.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDADMNO")), "", Ds.Tables(0).Rows(0)("BOARDADMNO"))
            TxtBName.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDNAME")), "", Ds.Tables(0).Rows(0)("BOARDNAME"))
            TxtBFname.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("FATHERNAME")), "", Ds.Tables(0).Rows(0)("FATHERNAME"))
            TxtBMname.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("MOTHERNAME")), "", Ds.Tables(0).Rows(0)("MOTHERNAME"))
            TxtDob.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("DOB")), "", Ds.Tables(0).Rows(0)("DOB"))
            TxtDtAdm.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("dateofjoin")), "", Ds.Tables(0).Rows(0)("dateofjoin"))
            TxtBhtno.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("PRV_HTNO")), "", Ds.Tables(0).Rows(0)("PRV_HTNO"))
            TxtPhper.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("PHPER")), "", Ds.Tables(0).Rows(0)("PHPER"))
            'TxtMtongue.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("MATHER_TONGUE")), "", Ds.Tables(0).Rows(0)("MATHER_TONGUE"))
            TxtMole1.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("MOLE1")), "", Ds.Tables(0).Rows(0)("MOLE1"))
            TxtMole2.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("MOLE2")), "", Ds.Tables(0).Rows(0)("MOLE2"))
            txtAadhar.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("AADHAR")), "", Ds.Tables(0).Rows(0)("AADHAR"))
            LblCode.Text = Ds.Tables(0).Rows(0)("COURSE").ToString & " / " & Ds.Tables(0).Rows(0)("GROUP1").ToString & " / " & Ds.Tables(0).Rows(0)("BATCH").ToString & _
                           " / " & Ds.Tables(0).Rows(0)("MEDIUM").ToString & " / " + Ds.Tables(0).Rows(0)("TYPE").ToString & " / " & Ds.Tables(0).Rows(0)("SECTION").ToString

            'DrpDist.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("MANDALSLNO")), 0, Ds.Tables(0).Rows(0)("MANDALSLNO"))
            fillDrpColl(drpBranchSearch.SelectedValue)
            fillDrpComm()
            fillDrpCaste()
            fillDrpPrvExm()
            fillDrpYOp()
            fillDrpCateg()
            fillDrpFlang()
            fillDrpSlang() 'MotherTongue also
            fillDrpPHStatus()
            fillDrpCourse()
            AdmBranchComboFill()

            DrpComm.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDRELIGIONSLNO")), 1, Ds.Tables(0).Rows(0)("BOARDRELIGIONSLNO"))
            DrpCaste.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDCASTESLNO")), 0, Ds.Tables(0).Rows(0)("BOARDCASTESLNO"))
            fillDrpSubCaste()
            DrpPrvExm.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDPRVEXAMSLNO")), 1, Ds.Tables(0).Rows(0)("BOARDPRVEXAMSLNO"))
            DrpYOp.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDYOPSLNO")), 13, Ds.Tables(0).Rows(0)("BOARDYOPSLNO"))
            DrpCateg.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDCATEGORYSLNO")), 1, Ds.Tables(0).Rows(0)("BOARDCATEGORYSLNO"))
            DrpFlang.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDFIRSTLANGSLNO")), 0, Ds.Tables(0).Rows(0)("BOARDFIRSTLANGSLNO"))
            DrpSlang.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDSECLANGSLNO")), 8, Ds.Tables(0).Rows(0)("BOARDSECLANGSLNO"))
            DrpPh.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDPHSLNO")), 3, Ds.Tables(0).Rows(0)("BOARDPHSLNO"))
            DrpCourse.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("joinedcourseslno")), 0, Ds.Tables(0).Rows(0)("joinedcourseslno"))
            DrpSubCaste.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDSUBCASTESLNO")), 0, Ds.Tables(0).Rows(0)("BOARDSUBCASTESLNO"))
            drpAdmBranch.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("ADMBRANCHSLNO")), 0, Ds.Tables(0).Rows(0)("ADMBRANCHSLNO"))

            If IsDBNull(Ds.Tables(0).Rows(0)("mothertongueslno")) Then
                DrpMotherTounge.Items.Insert(0, New ListItem("-Select-", 0))
            Else
                DrpMotherTounge.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("mothertongueslno")), 0, Ds.Tables(0).Rows(0)("mothertongueslno"))
            End If

            viewState("ADMNO") = Ds.Tables(0).Rows(0)("ADMNO")
            viewState("ADMSNO") = Ds.Tables(0).Rows(0)("ADMSNO")
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

    Private Sub fillDrpDist()

        Dim Ds As DataSet
        BrdStu = New ClsBoardEnrollment
        Ds = BrdStu.Masters_Selectall(1)
        DrpDist.DataSource = Ds.Tables(0)
        DrpDist.DataTextField = "NAME"
        DrpDist.DataValueField = "SLNO"
        DrpDist.DataBind()
        DrpDist.Items.Insert(0, New ListItem("-Select-", 0))

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

    Private Sub fillDrpComm()

        Dim Ds As DataSet
        BrdStu = New ClsBoardEnrollment
        Ds = BrdStu.Masters_Selectall(6)
        DrpComm.DataSource = Ds.Tables(0)
        DrpComm.DataTextField = "NAME"
        DrpComm.DataValueField = "SLNO"
        DrpComm.DataBind()

    End Sub

    Private Sub fillDrpCaste()

        Dim Ds As DataSet
        BrdStu = New ClsBoardEnrollment
        Ds = BrdStu.Masters_Selectall(7)
        DrpCaste.DataSource = Ds.Tables(0)
        DrpCaste.DataTextField = "NAME"
        DrpCaste.DataValueField = "SLNO"
        DrpCaste.DataBind()
        DrpCaste.Items.Insert(0, New ListItem("-Select-", 0))
        fillDrpSubCaste()

    End Sub

    Private Sub fillDrpCourse()

        Dim Ds As DataSet
        BrdStu = New ClsBoardEnrollment
        Ds = BrdStu.Masters_Selectall(17)
        DrpCourse.DataSource = Ds.Tables(0)
        DrpCourse.DataTextField = "NAME"
        DrpCourse.DataValueField = "SLNO"
        DrpCourse.DataBind()
        DrpCourse.Items.Insert(0, New ListItem("-Select-", 0))

    End Sub

    Private Sub fillDrpPrvExm()

        Dim Ds As DataSet
        BrdStu = New ClsBoardEnrollment
        Ds = BrdStu.Masters_Selectall(2)
        DrpPrvExm.DataSource = Ds.Tables(0)
        DrpPrvExm.DataTextField = "NAME"
        DrpPrvExm.DataValueField = "SLNO"
        DrpPrvExm.DataBind()

    End Sub

    Private Sub fillDrpYOp()

        Dim Ds As DataSet
        BrdStu = New ClsBoardEnrollment
        Ds = BrdStu.Masters_Selectall(3)
        DrpYOp.DataSource = Ds.Tables(0)
        DrpYOp.DataTextField = "NAME"
        DrpYOp.DataValueField = "SLNO"
        DrpYOp.DataBind()

    End Sub

    Private Sub fillDrpCateg()

        Dim Ds As DataSet
        BrdStu = New ClsBoardEnrollment
        Ds = BrdStu.Masters_Selectall(4)
        DrpCateg.DataSource = Ds.Tables(0)
        DrpCateg.DataTextField = "NAME"
        DrpCateg.DataValueField = "SLNO"
        DrpCateg.DataBind()

    End Sub

    Private Sub fillDrpSubCaste()


        Dim Ds As DataSet
        ClsUty = New Utility
        Ds = ClsUty.DataSet_OneFetch("SELECT BOARDSUBCASTESLNO SLNO,NAME FROM EXAM_BOARDSUBCASTE_MT WHERE CASTECODE=" & DrpCaste.SelectedItem.Value)

        'BrdStu = New ClsBoardEnrollment
        'Ds = BrdStu.Masters_Selectall(16)
        DrpSubCaste.DataSource = Ds.Tables(0)
        DrpSubCaste.DataTextField = "NAME"
        DrpSubCaste.DataValueField = "SLNO"
        DrpSubCaste.DataBind()
        DrpSubCaste.Items.Insert(0, New ListItem("-Select-", 0))

    End Sub

    Private Sub fillDrpFlang()

        Dim Ds As DataSet
        BrdStu = New ClsBoardEnrollment
        Ds = BrdStu.Masters_Selectall(11)
        DrpFlang.DataSource = Ds.Tables(0)
        DrpFlang.DataTextField = "NAME"
        DrpFlang.DataValueField = "SLNO"
        DrpFlang.DataBind()
        DrpFlang.Items.Insert(0, New ListItem("-Select-", 0))

    End Sub

    Private Sub fillDrpSlang()

        Dim Ds As DataSet
        BrdStu = New ClsBoardEnrollment
        Ds = BrdStu.Masters_Selectall(11)
        DrpSlang.DataSource = Ds.Tables(0) : DrpMotherTounge.DataSource = Ds.Tables(0)
        DrpSlang.DataTextField = "NAME" : DrpMotherTounge.DataTextField = "NAME"
        DrpSlang.DataValueField = "SLNO" : DrpMotherTounge.DataValueField = "SLNO"
        DrpSlang.DataBind() : DrpMotherTounge.DataBind()

    End Sub

    Private Sub fillDrpPHStatus()

        Dim Ds As DataSet
        BrdStu = New ClsBoardEnrollment
        Ds = BrdStu.Masters_Selectall(8)
        DrpPh.DataSource = Ds.Tables(0)
        DrpPh.DataTextField = "NAME"
        DrpPh.DataValueField = "SLNO"
        DrpPh.DataBind()
        DrpPh.Items.Insert(0, New ListItem("-Select-", 0))

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

        TxtBid.Text = ""
        TxtBAdmno.Text = ""
        TxtBName.Text = ""
        TxtBFname.Text = ""
        TxtBMname.Text = ""
        TxtDob.Text = ""
        TxtDtAdm.Text = ""
        TxtBhtno.Text = ""
        TxtPhper.Text = ""
        'TxtMtongue.Text = ""
        TxtMole1.Text = ""
        TxtMole2.Text = ""
        LblCode.Text = ""

        DrpCaste.Items.Clear()
        DrpSubCaste.Items.Clear()
        DrpCateg.Items.Clear()
        DrpColl.Items.Clear()
        DrpComm.Items.Clear()
        DrpCourse.Items.Clear()
        DrpDist.Items.Clear()
        DrpFlang.Items.Clear()
        DrpPh.Items.Clear()
        DrpPrvExm.Items.Clear()
        DrpSlang.Items.Clear()
        DrpYOp.Items.Clear()

    End Sub

    Private Function SetEntries2() As ArrayList
        Dim Arr As New ArrayList

        '''''''''''''''''''''' 1 '''''''''''''''''''''''''

        'TxtBid         --0
        'TxtBAdmno      --1
        'TxtBName       --2
        'TxtBFname      --3
        'TxtDob         --4
        'TxtBhtno       --5
        'TxtPhper       --6
        'TxtMtongue     --7
        'TxtMole1       --8
        'TxtMole2       --9

        If Trim(TxtBid.Text) = "" Then                  '--0
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBid.Text)))
        End If

        If Trim(TxtBAdmno.Text) = "" Then               '--1
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBAdmno.Text)))
        End If

        If Trim(TxtBName.Text) = "" Then                '--2
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBName.Text)))
        End If

        If Trim(TxtBFname.Text) = "" Then               '--3
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBFname.Text)))
        End If



        If Trim(TxtDob.Text) = "" Then                  '--4
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(DateConversion(Trim(TxtDob.Text)))
        End If

        If Trim(TxtBhtno.Text) = "" Then                '--5
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBhtno.Text)))
        End If

        If Trim(TxtPhper.Text) = "" Then                '--6
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtPhper.Text)))
        End If

        If DrpMotherTounge.SelectedIndex <= 0 Then              '--7
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpMotherTounge.SelectedValue))
        End If

        If Trim(TxtMole1.Text) = "" Then                '--8
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtMole1.Text)))
        End If

        If Trim(TxtMole2.Text) = "" Then                '--9
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtMole2.Text)))
        End If
        'DrpMotherTongue--07
        'DrpColl        --10    
        'DrpComm        --11    
        'DrpCaste       --12   
        'DrpPrvExm      --13  
        'DrpYOp         --14     
        'DrpCateg       --15   
        'DrpFlang       --16   
        'DrpSlang       --17   
        'DrpPh          --18      

        If DrpColl.SelectedIndex <= 0 Then              '--10
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpColl.SelectedValue))
        End If

        If DrpComm.SelectedItem.Value <= 0 Then              '--11
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpComm.SelectedValue))
        End If

        'If DrpComm.SelectedIndex <= 0 Then              '--11
        '    Arr.Add(System.DBNull.Value)
        'Else
        '    Arr.Add(Trim(DrpComm.SelectedValue))
        'End If

        If DrpCaste.SelectedIndex <= 0 Then              '--12
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpCaste.SelectedValue))
        End If

        If DrpPrvExm.SelectedItem.Value <= 0 Then              '--13
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpPrvExm.SelectedValue))
        End If

        If DrpYOp.SelectedIndex <= 0 Then              '--14
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpYOp.SelectedValue))
        End If

        If DrpCateg.SelectedIndex <= 0 Then              '--15
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpCateg.SelectedValue))
        End If

        If DrpFlang.SelectedIndex <= 0 Then              '--16
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpFlang.SelectedValue))
        End If

        If DrpSlang.SelectedIndex <= 0 Then              '--17
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpSlang.SelectedValue))
        End If

        If DrpPh.SelectedIndex <= 0 Then                '--18
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpPh.SelectedValue))
        End If
        Arr.Add(Session("COMACADEMICSLNO"))             '--19
        Arr.Add(ViewState("UNIQUENO"))                  '--20
        Arr.Add(ViewState("ADMSLNO"))                   '--21

        If Trim(TxtDtAdm.Text) = "" Then                  '--22
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(DateConversion(Trim(TxtDtAdm.Text)))
        End If

        If DrpCourse.SelectedIndex <= 0 Then              '--23
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpCourse.SelectedValue))
        End If


        If Trim(TxtBMname.Text) = "" Then               '--24
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBMname.Text)))
        End If

        If DrpSubCaste.SelectedIndex <= 0 Then              '--25
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpSubCaste.SelectedValue))
        End If


        Return Arr
        'Arr.Add()
        'Arr.Add()


        'viewState("ADMNO")
        'viewState("ADMSNO")
        'ViewState("BRANCHSLNO")
        'ViewState("ADMSLNO")
        'ViewState("UNIQUENO")

    End Function

    Private Function SetEntries() As ArrayList
        Dim Arr As New ArrayList

        '''''''''''''''''''''' 1 '''''''''''''''''''''''''

        'TxtBid         --0
        'TxtBAdmno      --1
        'TxtBName       --2
        'TxtBFname      --3
        'TxtDob         --4
        'TxtBhtno       --5
        'TxtPhper       --6
        'TxtMtongue     --7
        'TxtMole1       --8
        'TxtMole2       --9

        If Trim(TxtBid.Text) = "" Then                  '--0
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBid.Text)))
        End If

        If Trim(TxtBAdmno.Text) = "" Then               '--1
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBAdmno.Text)))
        End If

        If Trim(TxtBName.Text) = "" Then                '--2
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBName.Text)))
        End If

        If Trim(TxtBFname.Text) = "" Then               '--3
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBFname.Text)))
        End If



        If Trim(TxtDob.Text) = "" Then                  '--4
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(DateConversion(Trim(TxtDob.Text)))
        End If

        If Trim(TxtBhtno.Text) = "" Then                '--5
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBhtno.Text)))
        End If

        If Trim(TxtPhper.Text) = "" Then                '--6
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtPhper.Text)))
        End If

        If DrpMotherTounge.SelectedItem.Value <= 0 Then              '--7
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpMotherTounge.SelectedValue))
        End If

        If Trim(TxtMole1.Text) = "" Then                '--8
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtMole1.Text)))
        End If

        If Trim(TxtMole2.Text) = "" Then                '--9
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtMole2.Text)))
        End If
        'DrpMotherTongue--07
        'DrpColl        --10    
        'DrpComm        --11    
        'DrpCaste       --12   
        'DrpPrvExm      --13  
        'DrpYOp         --14     
        'DrpCateg       --15   
        'DrpFlang       --16   
        'DrpSlang       --17   
        'DrpPh          --18      

        If DrpColl.SelectedItem.Value <= 0 Then              '--10
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpColl.SelectedValue))
        End If

        If DrpComm.SelectedItem.Value <= 0 Then              '--11
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpComm.SelectedValue))
        End If

        'If DrpComm.SelectedIndex <= 0 Then              '--11
        '    Arr.Add(System.DBNull.Value)
        'Else
        '    Arr.Add(Trim(DrpComm.SelectedValue))
        'End If

        If DrpCaste.SelectedItem.Value <= 0 Then              '--12
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpCaste.SelectedValue))
        End If

        If DrpPrvExm.SelectedItem.Value <= 0 Then              '--13
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpPrvExm.SelectedValue))
        End If

        If DrpYOp.SelectedItem.Value <= 0 Then              '--14
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpYOp.SelectedValue))
        End If

        If DrpCateg.SelectedItem.Value <= 0 Then              '--15
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpCateg.SelectedValue))
        End If

        If DrpFlang.SelectedItem.Value <= 0 Then              '--16
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpFlang.SelectedValue))
        End If

        If DrpSlang.SelectedItem.Value <= 0 Then              '--17
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpSlang.SelectedValue))
        End If

        If DrpPh.SelectedItem.Value <= 0 Then                '--18
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpPh.SelectedValue))
        End If
        Arr.Add(Session("COMACADEMICSLNO"))             '--19
        Arr.Add(ViewState("UNIQUENO"))                  '--20
        Arr.Add(ViewState("ADMSLNO"))                   '--21

        If Trim(TxtDtAdm.Text) = "" Then                  '--22
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(DateConversion(Trim(TxtDtAdm.Text)))
        End If

        If DrpCourse.SelectedItem.Value <= 0 Then              '--23
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpCourse.SelectedValue))
        End If


        If Trim(TxtBMname.Text) = "" Then               '--24
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtBMname.Text)))
        End If

        If DrpSubCaste.SelectedItem.Value <= 0 Then              '--25
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpSubCaste.SelectedValue))
        End If

        If Trim(txtAadhar.Text) = "" Then                '--5
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(txtAadhar.Text)))
        End If

        If drpAdmBranch.SelectedValue <= 0 Then
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(drpAdmBranch.SelectedValue))
        End If

        Return Arr
        'Arr.Add()
        'Arr.Add()


        'viewState("ADMNO")
        'viewState("ADMSNO")
        'ViewState("BRANCHSLNO")
        'ViewState("ADMSLNO")
        'ViewState("UNIQUENO")

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
            ElseIf TxtDtAdm.Text.Trim = "" Then
                StartUpScript(TxtDtAdm.ID, " Enter DateofAdmission.")
                Return False
            ElseIf DrpMotherTounge.SelectedValue = 0 Then
                StartUpScript(DrpMotherTounge.ID, " Select MotherToungue")
                Return False
            ElseIf TxtDob.Text.Trim = "" Then
                StartUpScript(TxtDob.ID, " Enter Date of Birth ")
                Return False
            ElseIf DrpColl.SelectedValue = 0 Then
                StartUpScript(DrpColl.ID, " Select Board College ")
                Return False
            ElseIf DrpComm.SelectedValue = 0 Then
                StartUpScript(DrpComm.ID, " Select Community ")
                Return False
            ElseIf DrpPrvExm.SelectedValue = 0 Then
                StartUpScript(DrpPrvExm.ID, " Select Previous Exam ")
                Return False
            ElseIf TxtMole1.Text.Trim = "" Or TxtMole1.Text.Trim Is Nothing Or TxtMole2.Text.Trim = "" Or TxtMole2.Text.Trim Is Nothing Then
                StartUpScript(TxtMole1.ID, "Enter any one of Identification i.e Moles ")
                Return False
            ElseIf DrpCaste.SelectedValue = 0 Then
                StartUpScript(DrpCaste.ID, " Select Caste")
                Return False
            ElseIf DrpCourse.SelectedValue = 0 Then
                StartUpScript(DrpCourse.ID, " Select Admited Class")
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
            Ds = BrdStu.GetDataForStudent_Res(txtAdmNoSearch.Text, drpBranchSearch.SelectedValue, Session("COMACADEMICSLNO"))
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
            RtnValue = BrdStu.Student_Res_Update(SetEntries())
            If RtnValue = 1 Then
                StartUpScript("", "Board Details Updated Sucessfully..!")
                ClearControls(0)

            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub DrpCaste_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpCaste.SelectedIndexChanged
        fillDrpSubCaste()
    End Sub

End Class
