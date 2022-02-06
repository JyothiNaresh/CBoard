Public Class BoardTCPreviewMumbai
    Inherits System.Web.UI.Page
#Region " * Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    'Protected WithEvents lblClgNameCode As System.Web.UI.WebControls.Label
    'Protected WithEvents lblStuName As System.Web.UI.WebControls.Label
    'Protected WithEvents lblStuFname As System.Web.UI.WebControls.Label
    'Protected WithEvents lblStuMname As System.Web.UI.WebControls.Label
    'Protected WithEvents lblNationality As System.Web.UI.WebControls.Label
    'Protected WithEvents lblCaste As System.Web.UI.WebControls.Label
    'Protected WithEvents lblDob As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint8a As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint8b As System.Web.UI.WebControls.Label
    'Protected WithEvents lblMedium As System.Web.UI.WebControls.Label
    'Protected WithEvents lblDoa As System.Web.UI.WebControls.Label
    'Protected WithEvents lblAdmyear As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint12 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblpoint13a As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint14a As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint14b As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint16 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint17 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint18 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblTcno As System.Web.UI.WebControls.Label
    'Protected WithEvents LblAdmno As System.Web.UI.WebControls.Label
    'Protected WithEvents lblRcno As System.Web.UI.WebControls.Label
    'Protected WithEvents lblClgAddress1 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblClgAddress2 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint8c As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint8d As System.Web.UI.WebControls.Label
    'Protected WithEvents lblDobwords As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint15a As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint15b As System.Web.UI.WebControls.Label
    'Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label18 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label21 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label24 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label23 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label22 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label27 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label26 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label25 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label28 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label29 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label30 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label31 As System.Web.UI.WebControls.Label
    Protected WithEvents lblstuid As System.Web.UI.WebControls.Label

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
#End Region
#Region " * Page Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            DsPriview = Session("DsPriview")
            FillLables(DsPriview)
            'btnPriview.Attributes.Add("Onclick", "getPrint('print_area');")
        End If

    End Sub

#End Region

#Region " * Fill Methods"

    Private Sub FillLables(ByVal ds As DataSet)
        Try
            lblTcno.Text = DsPriview.Tables(0).Rows(0)("CERTIFICATENO").ToString
            lblRcno.Text = DsPriview.Tables(0).Rows(0)("RCNO").ToString
            LblAdmno.Text = DsPriview.Tables(0).Rows(0)("ADMNO").ToString

            lblClgNameCode.Text = DsPriview.Tables(0).Rows(0)("COLNAME").ToString
            lblClgAddress1.Text = DsPriview.Tables(0).Rows(0)("TCADDR1").ToString
            lblClgAddress2.Text = DsPriview.Tables(0).Rows(0)("TCADDR2").ToString

            lblStuName.Text = DsPriview.Tables(0).Rows(0)("STUNAME").ToString
            lblStuFname.Text = DsPriview.Tables(0).Rows(0)("PARENTNAME").ToString
            lblStuMname.Text = DsPriview.Tables(0).Rows(0)("MOTHERNAME").ToString

            lblNationality.Text = DsPriview.Tables(0).Rows(0)("RELIGION").ToString
            lblCaste.Text = DsPriview.Tables(0).Rows(0)("CASTE").ToString
            lblDob.Text = DsPriview.Tables(0).Rows(0)("DOB").ToString
            lblDobwords.Text = DsPriview.Tables(0).Rows(0)("DOBWORDS").ToString

            lblPoint8a.Text = DsPriview.Tables(0).Rows(0)("PASS").ToString
            'lblPoint8b.Text = DsPriview.Tables(0).Rows(0)("FIRTLANG").ToString
            'lblPoint8c.Text = DsPriview.Tables(0).Rows(0)("SECLANG").ToString
            'lblPoint8d.Text = DsPriview.Tables(0).Rows(0)("PART3").ToString()

            lblMedium.Text = DsPriview.Tables(0).Rows(0)("MOTHERTANGUE").ToString()
            lblDoa.Text = DsPriview.Tables(0).Rows(0)("ADMDT").ToString()


            lbluid.Text = DsPriview.Tables(0).Rows(0)("AADHAR").ToString()
            'lblpoint13a.Text = DsPriview.Tables(0).Rows(0)("POINT12").ToString()

            ''lblPoint14a.Text = DsPriview.Tables(0).Rows(0)("CERTIFICATENO").ToString()
            ''lblPoint14b.Text = DsPriview.Tables(0).Rows(0)("CERTIFICATENO").ToString()

            'lblPoint15a.Text = DsPriview.Tables(0).Rows(0)("MOLE1").ToString()
            'lblPoint15b.Text = DsPriview.Tables(0).Rows(0)("MOLE2").ToString()

            'lblPoint16.Text = DsPriview.Tables(0).Rows(0)("POINT15").ToString()
            lblPoint17.Text = DsPriview.Tables(0).Rows(0)("POINT16").ToString()
            lblPoint18.Text = DsPriview.Tables(0).Rows(0)("CONDUCT").ToString()


        Catch ex As Exception

        End Try
    End Sub


#End Region


End Class