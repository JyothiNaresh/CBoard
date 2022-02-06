Imports CollegeBoardDLL
Public Class SchoolCCPreview
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents lblClgNameCode As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents LblSchAddr As System.Web.UI.WebControls.Label
    Protected WithEvents LblSchAddr2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Lblname As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents lblFname As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents LblJoinCrs As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents LblLeftCrs As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents LblJoindate As System.Web.UI.WebControls.Label
    Protected WithEvents Label30 As System.Web.UI.WebControls.Label
    Protected WithEvents Lblleftdate As System.Web.UI.WebControls.Label
    Protected WithEvents Lbldob As System.Web.UI.WebControls.Label
    Protected WithEvents Label32 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint18 As System.Web.UI.WebControls.Label
    Protected WithEvents LblAdmno As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "used variables"
    Private oConn As OracleConnection 'Connection Object Declaration.
    Private oComm As OracleCommand 'Command Object Declaration.
    Private oTrans As OracleTransaction 'Transaction Object Declaration.
    Private oAdap As OracleDataAdapter 'Adapter Object Declaration.
    Private oParam As OracleParameter 'Parameter Object Declaration.
    Private Ds, DsPrinter, DsPriview, DsCCPriview As DataSet
    Private ClsBE As New ClsBoardEnrollment
    Private _AdmSlno, _Uniqueno, _BoardCollegeSlno As Integer
    Private rptutl As Utility
    Private rtnMessage As String 'Result of the return type.
    Dim i, j, FLAG As Integer
    Private objBE As ClsBoardEnrollment
    Private objBEfill As Utility
    Dim VDrpCourse, VDrpIIyear, VDrpbieucs As Integer
    Dim vTxtDateleaving, PdfFileName As String
    Private objWSCombo As ClsComboBoxFilling
    Dim brdsch, crsl, crsj, FROM, TODATE As String
#End Region

#Region "Load Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            DsCCPriview = Session("DsCCPriview")
            brdsch = Session("brdsch")
            crsl = Session("CRSl")
            crsj = Session("CRSj")
            FROM = Session("FROM")
            TODATE = Session("TODATE")
            FillLables(DsCCPriview)
        End If
    End Sub

#End Region

#Region "Fillings"

    Private Sub FillLables(ByVal Dset As DataSet)
        Try
            Dim Ds As DataSet
            ClsBE = New ClsBoardEnrollment
            Dim dsExamBranch As DataSet
            Dim SqlStr As String
            objWSCombo = New ClsComboBoxFilling
            SqlStr = "SELECT * from SCH_BOARDNAMES_MT where SBSLNO=" & Session("brdsch")
            objBEfill = New Utility
            Ds = objBEfill.GetCommDataSet(SqlStr)
            lblClgNameCode.Text = Ds.Tables(0).Rows(0)("SBNAME").ToString
            LblSchAddr.Text = Ds.Tables(0).Rows(0)("SBRECOGNITION").ToString
            LblSchAddr2.Text = Ds.Tables(0).Rows(0)("SBADDRESS").ToString
            LblAdmno.Text = DsCCPriview.Tables(0).Rows(0)("ADMNO").ToString
            Lblname.Text = DsCCPriview.Tables(0).Rows(0)("NAME").ToString
            lblFname.Text = DsCCPriview.Tables(0).Rows(0)("FNAME").ToString
            LblJoindate.Text = Session("from")
            Lblleftdate.Text = Session("todate")
            LblJoinCrs.Text = Session("CRSJ")
            Lbldob.Text = DsCCPriview.Tables(0).Rows(0)("DOBWORDS").ToString
            LblLeftCrs.Text = Session("CRSL")
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
