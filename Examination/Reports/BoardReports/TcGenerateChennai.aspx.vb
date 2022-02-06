
Imports System.Drawing
Imports System.Drawing.Printing
Imports CollegeBoardDLL

Public Class TcGenerateChennai
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    '  Protected WithEvents lblClgNameCode As System.Web.UI.WebControls.Label
    ' Protected WithEvents lblClgAddress1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblClgAddress2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label47 As System.Web.UI.WebControls.Label
    ' Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    '  Protected WithEvents lblStuName As System.Web.UI.WebControls.Label
    Protected WithEvents Label48 As System.Web.UI.WebControls.Label
    '  Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents lblStuFname As System.Web.UI.WebControls.Label
    Protected WithEvents Label49 As System.Web.UI.WebControls.Label
    '  Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    ' Protected WithEvents lblStuMname As System.Web.UI.WebControls.Label
    Protected WithEvents Label50 As System.Web.UI.WebControls.Label
    ' Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    '  Protected WithEvents lblNationality As System.Web.UI.WebControls.Label
    Protected WithEvents Label51 As System.Web.UI.WebControls.Label
    '   Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    ' Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblCaste As System.Web.UI.WebControls.Label
    Protected WithEvents Label52 As System.Web.UI.WebControls.Label
    ' Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDob As System.Web.UI.WebControls.Label
    '  Protected WithEvents lblDobwords As System.Web.UI.WebControls.Label
    Protected WithEvents Label53 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint8a As System.Web.UI.WebControls.Label
    Protected WithEvents Label38 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint8b As System.Web.UI.WebControls.Label
    Protected WithEvents Label39 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint8c As System.Web.UI.WebControls.Label
    ' Protected WithEvents Label40 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint8d As System.Web.UI.WebControls.Label
    Protected WithEvents Label57 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMedium As System.Web.UI.WebControls.Label
    Protected WithEvents Label58 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDoa As System.Web.UI.WebControls.Label
    Protected WithEvents Label59 As System.Web.UI.WebControls.Label
    Protected WithEvents Label45 As System.Web.UI.WebControls.Label
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents lblAdmyear As System.Web.UI.WebControls.Label
    Protected WithEvents Label60 As System.Web.UI.WebControls.Label
    Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents Label18 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint12 As System.Web.UI.WebControls.Label
    Protected WithEvents Label61 As System.Web.UI.WebControls.Label
    Protected WithEvents Label70 As System.Web.UI.WebControls.Label
    Protected WithEvents Label69 As System.Web.UI.WebControls.Label
    Protected WithEvents Label68 As System.Web.UI.WebControls.Label
    Protected WithEvents lblpoint13a As System.Web.UI.WebControls.Label
    Protected WithEvents Label62 As System.Web.UI.WebControls.Label
    Protected WithEvents Label73 As System.Web.UI.WebControls.Label
    Protected WithEvents Label72 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint14a As System.Web.UI.WebControls.Label
    Protected WithEvents Label76 As System.Web.UI.WebControls.Label
    Protected WithEvents Label75 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint14b As System.Web.UI.WebControls.Label
    Protected WithEvents Label24 As System.Web.UI.WebControls.Label
    Protected WithEvents Label23 As System.Web.UI.WebControls.Label
    Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint15a As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint15b As System.Web.UI.WebControls.Label
    Protected WithEvents Label65 As System.Web.UI.WebControls.Label
    Protected WithEvents Label82 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint16 As System.Web.UI.WebControls.Label
    Protected WithEvents Label66 As System.Web.UI.WebControls.Label
    Protected WithEvents Label85 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint17 As System.Web.UI.WebControls.Label
    Protected WithEvents Label88 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint18 As System.Web.UI.WebControls.Label
    Protected WithEvents Label67 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label34 As System.Web.UI.WebControls.Label
    Protected WithEvents Label37 As System.Web.UI.WebControls.Label
    ' Protected WithEvents Label41 As System.Web.UI.WebControls.Label
    Protected WithEvents Label42 As System.Web.UI.WebControls.Label
    Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    ' Protected WithEvents Label21 As System.Web.UI.WebControls.Label
    Protected WithEvents Label22 As System.Web.UI.WebControls.Label
    'Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    'Protected WithEvents lblDocumentId As System.Web.UI.WebControls.Label
    'Protected WithEvents lblTCColName As System.Web.UI.WebControls.Label
    'Protected WithEvents Label35 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label36 As System.Web.UI.WebControls.Label
    Protected WithEvents lblTCRCNO As System.Web.UI.WebControls.Label
    '  Protected WithEvents Label33 As System.Web.UI.WebControls.Label
    Protected WithEvents lblTcno As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents LblAdmno As System.Web.UI.WebControls.Label
    Protected WithEvents lblzip As System.Web.UI.WebControls.Label
    Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " * Class Variables"
    Dim DsPriview As DataSet
    Private ClsBE As New ClsBoardEnrollment
    Dim i, j, FLAG As Integer
    Dim Ds As DataSet
    Dim TcDum As Integer
    Private _AdmSlno, _Uniqueno, _BoardCollegeSlno As Integer
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        SetViewStateVariables()
        FLAG = CInt(Request.QueryString("FLAG"))

        If Not IsPostBack Then
            Dim slevel As Integer
            Dim iPCType As Integer
            Dim i As Integer
            Dim LevelType As String

            Try

                DsPriview = New DataSet
                DsPriview = TransferCertificateNew(2)
                'Session("DsPriview") = DsPriview
                FillLables(DsPriview)

            Catch oex As OracleException
                Throw (oex)
            Catch ex As Exception
                Throw (ex)
            End Try

            StartUpScript("", "1.Set Margins and Select Legal Paper for Printing")
        End If
    End Sub

    Private Sub SetViewStateVariables()
        Try
            If Session("TcDum") = 0 Then
                If Not Request.QueryString("AdmSlno") Is Nothing Then _AdmSlno = Request.QueryString("ADMSLNO")
                Me.ViewState("_AdmSlno") = _AdmSlno
            End If

            If Not Request.QueryString("Uniqueno") Is Nothing Then _Uniqueno = Request.QueryString("UNIQUENO")
            If Not Request.QueryString("BOARDCOLLEGESLNO") Is Nothing Then _BoardCollegeSlno = Request.QueryString("BOARDCOLLEGESLNO")
            Me.ViewState("_Uniqueno") = _Uniqueno
            Me.ViewState("_BoardCollegeSlno") = _BoardCollegeSlno

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function TransferCertificateNew(ByVal genprv As Integer) As DataSet

        Try
            TcDum = Session("TcDum")

            If TcDum = 1 Then
                Ds = ClsBE.P_TCgeneration_DummyChennai(Me.ViewState("_Uniqueno"), Session("COMACADEMICSLNO"), Me.ViewState("_BoardCollegeSlno"), 1, genprv, Session("USERSLNO"))


            Else
                Ds = ClsBE.P_TCgenerationNewchennai(Me.ViewState("_Uniqueno"), Session("COMACADEMICSLNO"), Me.ViewState("_BoardCollegeSlno"), 1, genprv, Session("USERSLNO"))
            End If

            Return Ds
        Catch oex As OracleException
            Throw (oex)
        Catch ex As Exception
            Throw (ex)

        End Try

    End Function
#Region " * Fill Methods"

    Private Sub FillLables(ByVal DsPriview As DataSet)
        Try
            If DsPriview.Tables(0).Rows(0)("DOCUMENTID").ToString <> "" Then
                If DsPriview.Tables(0).Rows(0)("DOCUMENTID") <= 1 Then
                    lblDocumentId.Text = "ORIGINAL"
                ElseIf DsPriview.Tables(0).Rows(0)("DOCUMENTID") = 2 Then
                    lblDocumentId.Text = "DUPLICATE"
                ElseIf DsPriview.Tables(0).Rows(0)("DOCUMENTID") > 2 Then
                    lblDocumentId.Text = "TRIPLICATE"
                End If
            Else
                lblDocumentId.Text = "NO DOCUMENTID FOUND"
            End If

            lblTCColName.Text = DsPriview.Tables(0).Rows(0)("COLNAME").ToString

            lblzip.Text = DsPriview.Tables(0).Rows(0)("TCADDR2").ToString
            lblAdress.Text = DsPriview.Tables(0).Rows(0)("TCADDR1").ToString
            lblstudentname.Text = DsPriview.Tables(0).Rows(0)("STUNAME").ToString
            lblfathername.Text = DsPriview.Tables(0).Rows(0)("PARENTNAME").ToString
            lblnationalty.Text = "INDIAN"
            lblscheduleTribe.Text = DsPriview.Tables(0).Rows(0)("SCHEDULE_CASTE").ToString
            lblfirstadmission.Text = DsPriview.Tables(0).Rows(0)("SCHOOL_CLASS").ToString
            lblwords.Text = DsPriview.Tables(0).Rows(0)("DOB_WORDS").ToString
            lblinfigure.Text = DsPriview.Tables(0).Rows(0)("LAST_STUDIED").ToString
            Label13.Text = DsPriview.Tables(0).Rows(0)("LAST_STUDIED_WORDS").ToString
            lblschoolanualexamination.Text = DsPriview.Tables(0).Rows(0)("BOARD_LASTEXAM").ToString
            lblfailed.Text = DsPriview.Tables(0).Rows(0)("TWICE_CLASS").ToString
            lblsubject1.Text = DsPriview.Tables(0).Rows(0)("SUBJECT1").ToString
            ' lblboard.Text = DsPriview.Tables(0).Rows(0)("TSTATENAME").ToString
            lblsubject2.Text = DsPriview.Tables(0).Rows(0)("SUBJECT2").ToString
            lblsubject3.Text = DsPriview.Tables(0).Rows(0)("SUBJECT3").ToString
            lblsubject4.Text = DsPriview.Tables(0).Rows(0)("SUBJECT4").ToString
            lblsubject5.Text = DsPriview.Tables(0).Rows(0)("SUBJECT5").ToString
            lblsubject6.Text = DsPriview.Tables(0).Rows(0)("SUBJECT6").ToString
            lblpromotion.Text = DsPriview.Tables(0).Rows(0)("QUAL_CLASS").ToString

            lblpromowords.Text = DsPriview.Tables(0).Rows(0)("QUAL_CLASS_WORDS").ToString
            lblschooldues.Text = DsPriview.Tables(0).Rows(0)("DUES_PAID").ToString
            lblfeeconcetion.Text = DsPriview.Tables(0).Rows(0)("CONCESSION").ToString
            lbltotworkingdays.Text = DsPriview.Tables(0).Rows(0)("TOT_WORKDAYS").ToString
            lbltotworkingdayspresent.Text = DsPriview.Tables(0).Rows(0)("WORK_DAYSPRE").ToString
            'lbldist.Text = DsPriview.Tables(0).Rows(0)("DISTRICT").ToString
            lblncccandiate.Text = DsPriview.Tables(0).Rows(0)("NCC").ToString
            lblGAMESACTIV.Text = DsPriview.Tables(0).Rows(0)("GAMESACTIV").ToString
            lblgconduct.Text = DsPriview.Tables(0).Rows(0)("CONDUCT").ToString
            lbldateofapplication.Text = DsPriview.Tables(0).Rows(0)("APPL_CERT").ToString
            lblissuecertificate.Text = DsPriview.Tables(0).Rows(0)("ISSUE_CERT").ToString
            lblreason.Text = DsPriview.Tables(0).Rows(0)("REASON_LEAVING").ToString
            lblanydesk.Text = DsPriview.Tables(0).Rows(0)("OTHER_REMARKS").ToString
            Image1.ImageUrl = DsPriview.Tables(0).Rows(0)("LOGOPATH")
            lblbookno.Text = DsPriview.Tables(0).Rows(0)("BOOKNO").ToString
            LblAdmno.Text = DsPriview.Tables(0).Rows(0)("BOARDADMNO").ToString
            lblsno.Text = DsPriview.Tables(0).Rows(0)("TCNO").ToString
            ' lblTcno.Text = DsPriview.Tables(0).Rows(0)("CERTIFICATENO").ToString
            'lblsurname.Text = DsPriview.Tables(0).Rows(0)("SURNAME").ToString
            '' LblAdmno.Text = DsPriview.Tables(0).Rows(0)("ADMNO").ToString
            'lblpis.Text = DsPriview.Tables(0).Rows(0)("Progress").ToString
            'lblconduct.Text = DsPriview.Tables(0).Rows(0)("CONDUCT").ToString
            'lblDLC.Text = DsPriview.Tables(0).Rows(0)("POINT15").ToString
            'lblstdword.Text = DsPriview.Tables(0).Rows(0)("SINCESTUDY").ToString
            'lblresonlevingcol.Text = DsPriview.Tables(0).Rows(0)("REASONLEAVING").ToString
            'lblremarks.Text = DsPriview.Tables(0).Rows(0)("CONDUCT").ToString

            'lbldate.Text = Date.Now.Day
            'lblmonth.Text = Date.Now.Month
            'lblyear.Text = Date.Now.Year
            ''  Image1.ImageUrl = DsPriview.Tables(0).Rows(0)("LOGOPATH")
            'lblclassteacher.Text = DsPriview.Tables(0).Rows(0)("CLASSTEACHER").ToString
            'lblcleark.Text = DsPriview.Tables(0).Rows(0)("CLERK").ToString

            'lblClgNameCode.Text = DsPriview.Tables(0).Rows(0)("COLNAME").ToString
            ' lblClgAddress1.Text = DsPriview.Tables(0).Rows(0)("TCADDR1").ToString
            ' lblClgAddress2.Text = DsPriview.Tables(0).Rows(0)("TCADDR2").ToString



            'lblNationality.Text = DsPriview.Tables(0).Rows(0)("RELIGION").ToString
            'lblCaste.Text = DsPriview.Tables(0).Rows(0)("CASTE").ToString
            'lblDob.Text = DsPriview.Tables(0).Rows(0)("DOB").ToString
            'lblDobwords.Text = DsPriview.Tables(0).Rows(0)("DOBWORDS").ToString

            'lblPoint8a.Text = DsPriview.Tables(0).Rows(0)("PASS").ToString
            'lblPoint8b.Text = DsPriview.Tables(0).Rows(0)("FIRTLANG").ToString
            'lblPoint8c.Text = DsPriview.Tables(0).Rows(0)("SECLANG").ToString
            'lblPoint8d.Text = DsPriview.Tables(0).Rows(0)("PART3").ToString()

            'lblMedium.Text = DsPriview.Tables(0).Rows(0)("MOTHERTANGUE").ToString()
            'lblDoa.Text = DsPriview.Tables(0).Rows(0)("ADMDT").ToString()
            'lblAdmyear.Text = DsPriview.Tables(0).Rows(0)("CLASSYEAR").ToString()

            'lblPoint12.Text = DsPriview.Tables(0).Rows(0)("POINT11").ToString()
            'lblpoint13a.Text = DsPriview.Tables(0).Rows(0)("POINT12").ToString()

            ''lblPoint14a.Text = DsPriview.Tables(0).Rows(0)("CERTIFICATENO").ToString()
            ''lblPoint14b.Text = DsPriview.Tables(0).Rows(0)("CERTIFICATENO").ToString()

            'lblPoint15a.Text = DsPriview.Tables(0).Rows(0)("MOLE1").ToString()
            'lblPoint15b.Text = DsPriview.Tables(0).Rows(0)("MOLE2").ToString()

            'lblPoint16.Text = DsPriview.Tables(0).Rows(0)("POINT15").ToString()
            'lblPoint17.Text = DsPriview.Tables(0).Rows(0)("POINT16").ToString()
            'lblPoint18.Text = DsPriview.Tables(0).Rows(0)("CONDUCT").ToString()



        Catch ex As Exception

        End Try
    End Sub


#End Region

    Private Sub StartUpScript(ByVal FormName As String, Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")
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
End Class