Imports System.Data
Imports System.Data.OracleClient
Imports CollegeBoardDLL
Public Class StudentBoardDetailsEntry
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
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents Label18 As System.Web.UI.WebControls.Label
    Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    Protected WithEvents Label21 As System.Web.UI.WebControls.Label
    Protected WithEvents Label22 As System.Web.UI.WebControls.Label
    Protected WithEvents Label23 As System.Web.UI.WebControls.Label
    Protected WithEvents Label24 As System.Web.UI.WebControls.Label
    Protected WithEvents Label25 As System.Web.UI.WebControls.Label
    Protected WithEvents Label26 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtBid As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtBAdmno As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtBName As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtBFname As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtDob As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtBhtno As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtPhper As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtMtongue As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtMole1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtMole2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents DrpDist As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpColl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpComm As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpCaste As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpPrvExm As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpYOp As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpCateg As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpFlang As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpSlang As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpPh As System.Web.UI.WebControls.DropDownList
    Protected WithEvents LblCode As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpCourse As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TxtDtAdm As System.Web.UI.WebControls.TextBox

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

#Region "Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
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
            TxtDob.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("DOB")), "", Ds.Tables(0).Rows(0)("DOB"))
            TxtDtAdm.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("dateofjoin")), "", Ds.Tables(0).Rows(0)("dateofjoin"))
            TxtBhtno.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("PRV_HTNO")), "", Ds.Tables(0).Rows(0)("PRV_HTNO"))
            TxtPhper.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("PHPER")), "", Ds.Tables(0).Rows(0)("PHPER"))
            TxtMtongue.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("MATHER_TONGUE")), "", Ds.Tables(0).Rows(0)("MATHER_TONGUE"))
            TxtMole1.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("MOLE1")), "", Ds.Tables(0).Rows(0)("MOLE1"))
            TxtMole2.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("MOLE2")), "", Ds.Tables(0).Rows(0)("MOLE2"))
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
            fillDrpSlang()
            fillDrpPHStatus()
            fillDrpCourse()
            DrpComm.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDRELIGIONSLNO")), 1, Ds.Tables(0).Rows(0)("BOARDRELIGIONSLNO"))
            DrpCaste.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDCASTESLNO")), 0, Ds.Tables(0).Rows(0)("BOARDCASTESLNO"))
            DrpPrvExm.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDPRVEXAMSLNO")), 1, Ds.Tables(0).Rows(0)("BOARDPRVEXAMSLNO"))
            DrpYOp.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDYOPSLNO")), 1, Ds.Tables(0).Rows(0)("BOARDYOPSLNO"))
            DrpCateg.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDCATEGORYSLNO")), 1, Ds.Tables(0).Rows(0)("BOARDCATEGORYSLNO"))
            DrpFlang.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDFIRSTLANGSLNO")), 0, Ds.Tables(0).Rows(0)("BOARDFIRSTLANGSLNO"))
            DrpSlang.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDSECLANGSLNO")), 8, Ds.Tables(0).Rows(0)("BOARDSECLANGSLNO"))
            DrpPh.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDPHSLNO")), 0, Ds.Tables(0).Rows(0)("BOARDPHSLNO"))
            DrpCourse.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("joinedcourseslno")), 0, Ds.Tables(0).Rows(0)("joinedcourseslno"))

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

    End Sub

    Private Sub fillDrpCourse()

        Dim Ds As DataSet
        BrdStu = New ClsBoardEnrollment
        Ds = BrdStu.Masters_Selectall(14)
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
        DrpSlang.DataSource = Ds.Tables(0)
        DrpSlang.DataTextField = "NAME"
        DrpSlang.DataValueField = "SLNO"
        DrpSlang.DataBind()
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

    Private Sub ClearControls()

        txtSurName.Text = ""
        txtSName.Text = ""
        txtFname.Text = ""

        TxtBid.Text = ""
        TxtBAdmno.Text = ""
        TxtBName.Text = ""
        TxtBFname.Text = ""
        TxtDob.Text = ""
        TxtBhtno.Text = ""
        TxtPhper.Text = ""
        TxtMtongue.Text = ""
        TxtMole1.Text = ""
        TxtMole2.Text = ""
        LblCode.Text = ""
    End Sub


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

        If Trim(TxtMtongue.Text) = "" Then              '--7
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(UCase(Trim(TxtMtongue.Text)))
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

        'DrpColl    --10    
        'DrpComm    --11    
        'DrpCaste   --12   
        'DrpPrvExm  --13  
        'DrpYOp     --14     
        'DrpCateg   --15   
        'DrpFlang   --16   
        'DrpSlang   --17   
        'DrpPh      --18      

        If DrpColl.SelectedIndex <= 0 Then              '--10
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpColl.SelectedValue))
        End If

        If DrpComm.SelectedIndex <= 0 Then              '--11
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpComm.SelectedValue))
        End If

        If DrpCaste.SelectedIndex <= 0 Then              '--12
            Arr.Add(System.DBNull.Value)
        Else
            Arr.Add(Trim(DrpCaste.SelectedValue))
        End If

        If DrpPrvExm.SelectedIndex <= 0 Then              '--13
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
            ClearControls()

            If Trim(txtAdmNoSearch.Text) = "" Then
                StartUpScript(txtAdmNoSearch.ID, "Enter Adm.No.")
                Exit Sub
            ElseIf Not IsNumeric(Trim(txtAdmNoSearch.Text)) Then
                StartUpScript(txtAdmNoSearch.ID, "Enter numbers only.")
                Exit Sub
            End If
            BrdStu = New ClsBoardEnrollment
            Ds = BrdStu.GetDataForStudent(txtAdmNoSearch.Text, drpBranchSearch.SelectedValue, Session("COMACADEMICSLNO"))
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
            RtnValue = BrdStu.Student_Update(SetEntries())
            If Rtnvalue = 1 Then
                StartUpScript("", "Board Details Updated Sucessfully..!")
                ClearControls()

            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region


End Class
