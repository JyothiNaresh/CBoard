'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : STUDY (OR) CONDUCT CERTIFICATE FORSTUDENTS
'   AUTHOR                            : ANILKUMAR PODILI
'   INITIAL BASELINE DATE             : 26.05.2014
'   FINAL BASELINE DATE               : 28.05.2014
'   COMPLETED DATE                    : 28.05.2014
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Public Class SchoolCndCertNew
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Image15 As System.Web.UI.WebControls.Image
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Image14 As System.Web.UI.WebControls.Image
    Protected WithEvents LblDob As System.Web.UI.WebControls.Label
    Protected WithEvents Image13 As System.Web.UI.WebControls.Image
    Protected WithEvents LblToyear As System.Web.UI.WebControls.Label
    Protected WithEvents Image12 As System.Web.UI.WebControls.Image
    Protected WithEvents LblFrmYear As System.Web.UI.WebControls.Label
    Protected WithEvents Image11 As System.Web.UI.WebControls.Image
    Protected WithEvents LblTocls As System.Web.UI.WebControls.Label
    Protected WithEvents Image10 As System.Web.UI.WebControls.Image
    Protected WithEvents LblfrmCls As System.Web.UI.WebControls.Label
    Protected WithEvents Image9 As System.Web.UI.WebControls.Image
    Protected WithEvents LblFname As System.Web.UI.WebControls.Label
    Protected WithEvents Image8 As System.Web.UI.WebControls.Image
    Protected WithEvents LblStuname As System.Web.UI.WebControls.Label
    Protected WithEvents LblprintDate As System.Web.UI.WebControls.Label
    Protected WithEvents Label35 As System.Web.UI.WebControls.Label
    Protected WithEvents LblebAddr As System.Web.UI.WebControls.Label
    Protected WithEvents LblColAddr As System.Web.UI.WebControls.Label
    Protected WithEvents Label36 As System.Web.UI.WebControls.Label
    Protected WithEvents lblCCColName As System.Web.UI.WebControls.Label
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    Protected WithEvents Image3 As System.Web.UI.WebControls.Image
    Protected WithEvents LblAdmno As System.Web.UI.WebControls.Label
    Protected WithEvents Image4 As System.Web.UI.WebControls.Image

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "variables"
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

#Region "Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            DsCCPriview = Session("DsCCPriview")
            brdsch = Session("brdsch")
            crsl = Session("CRSl")
            crsj = Session("CRSj")
            FROM = Session("FROM")
            TODATE = Session("TODATE")
            getboraddatat()
            FillLables(DsCCPriview)
        End If
    End Sub

#End Region

#Region "Fillings"

    Private Sub getboraddatat()
        Try


            Dim Ds As DataSet
            ClsBE = New ClsBoardEnrollment
            Dim dsExamBranch As DataSet
            Dim SqlStr As String
            objWSCombo = New ClsComboBoxFilling
            SqlStr = "SELECT * from SCH_BOARDNAMES_MT where SBSLNO=" & Session("brdsch")
            objBEfill = New Utility
            Ds = objBEfill.GetCommDataSet(SqlStr)
            lblCCColName.Text = Ds.Tables(0).Rows(0)("SBNAME").ToString
            LblColAddr.Text = Ds.Tables(0).Rows(0)("SBRECOGNITION").ToString
            LblebAddr.Text = Ds.Tables(0).Rows(0)("SBADDRESS").ToString

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillLables(ByVal Dset As DataSet)
        Try

            LblAdmno.Text = DsCCPriview.Tables(0).Rows(0)("ADMNO").ToString
            LblprintDate.Text = DsCCPriview.Tables(0).Rows(0)("LEAVING").ToString
            LblStuname.Text = DsCCPriview.Tables(0).Rows(0)("NAME").ToString
            LblFname.Text = DsCCPriview.Tables(0).Rows(0)("FNAME").ToString
            LblFrmYear.Text = Session("from")
            LblToyear.Text = Session("todate")
            LblfrmCls.Text = Session("CRSJ")
            LblDob.Text = DsCCPriview.Tables(0).Rows(0)("DOBWORDS").ToString
            LblTocls.Text = Session("CRSL")
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
