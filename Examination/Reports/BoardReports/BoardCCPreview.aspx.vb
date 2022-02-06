Public Class BoardCCPreview
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblRcno As System.Web.UI.WebControls.Label
    Protected WithEvents LblAdmno As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblClgNameCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblClgAddress1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblClgAddress2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblStuName As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents lblStuFname As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint8b As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint8c As System.Web.UI.WebControls.Label
    Protected WithEvents lblStydin As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents lblMedium As System.Web.UI.WebControls.Label
    Protected WithEvents Label32 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPoint18 As System.Web.UI.WebControls.Label
    Protected WithEvents lblAcdFrom As System.Web.UI.WebControls.Label
    Protected WithEvents lblAcdTo As System.Web.UI.WebControls.Label
    Protected WithEvents lblConduct As System.Web.UI.WebControls.Label
    Protected WithEvents TableBack As System.Web.UI.WebControls.Table

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Class Variables"
    Dim DsCCPriview As DataSet
    Dim HD1 As New TableRow
#End Region

#Region " Page Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            DsCCPriview = Session("DsCCPriview")
            FillLables(DsCCPriview)
        End If
       
    End Sub

#End Region

#Region " Fill Methods"

    Private Sub FillLables(ByVal ds As DataSet)
        Try
            Dim gk As String

            HD1.Cells.Add(DataRightAlignstyle("BACK", "", "WHITE", 5, "", "Verdana", "true", 140, 10, "", "javascript:history.back()")) 'history.go(-1)
            'HD1.Cells.Add(DataRightAlignstyle("BACK", "", "WHITE", 5, "", "Verdana", "true", 140, 10, "", "javascript:b()"))
            TableBack.Rows.Add(HD1)

            'lblCcno.Text = DsCCPriview.Tables(0).Rows(0)("CERTIFICATENO").ToString
            lblRcno.Text = DsCCPriview.Tables(0).Rows(0)("PLAN_BRS_PROC_NO").ToString
            LblAdmno.Text = DsCCPriview.Tables(0).Rows(0)("ADMNO").ToString

            lblClgNameCode.Text = DsCCPriview.Tables(0).Rows(0)("COLNAME").ToString
            
            lblClgAddress1.Text = DsCCPriview.Tables(0).Rows(0)("ADDRS").ToString
            lblClgAddress2.Text = DsCCPriview.Tables(0).Rows(0)("ADDRS1").ToString

            lblStuName.Text = DsCCPriview.Tables(0).Rows(0)("STDNAME").ToString
            lblStuFname.Text = DsCCPriview.Tables(0).Rows(0)("FATHERNAME").ToString
            lblStydin.Text = DsCCPriview.Tables(0).Rows(0)("STDYEAR").ToString
            lblAcdFrom.Text = DsCCPriview.Tables(0).Rows(0)("ACYYEARFROM").ToString
            lblAcdTo.Text = DsCCPriview.Tables(0).Rows(0)("ACYYEARTO").ToString
            lblGroup.Text = DsCCPriview.Tables(0).Rows(0)("GRP").ToString
            lblMedium.Text = DsCCPriview.Tables(0).Rows(0)("MEDIUMS").ToString



        Catch ex As Exception

        End Try
    End Sub
    
    Public Function DataRightAlignstyle(ByVal iText As String, ByVal bcolor As String, ByVal lcolor As String, ByVal icolspan As Integer, ByVal fcolor As String, ByVal ifontname As String, ByVal ibold As Boolean, ByVal iwidth As Integer, ByVal isize As Integer, ByVal itooltip As String, ByVal pNavigateUrl As String, Optional ByVal rowSpan As Int16 = 0) As TableCell
        Try
            Dim tcell As New TableCell
            Dim TLink As New System.Web.UI.WebControls.HyperLink
            Dim myAttributes As AttributeCollection = tcell.Attributes
            Dim myAttributes1 As AttributeCollection = TLink.Attributes
            TLink.Text = iText
            myAttributes.CssStyle.Add("text-align", "right")
            myAttributes.CssStyle.Add("background-color", bcolor)
            myAttributes1.CssStyle.Add("Color", lcolor)
            myAttributes.CssStyle.Add("color", fcolor)
            tcell.ColumnSpan = icolspan
            tcell.Font.Name = ifontname
            tcell.Font.Bold = ibold
            TLink.Width = Unit.Pixel(iwidth)
            tcell.Font.Size = System.Web.UI.WebControls.FontUnit.Point(isize)
            tcell.ToolTip = itooltip
            TLink.NavigateUrl = pNavigateUrl
            tcell.Height = Unit.Pixel(20)
            tcell.RowSpan = rowSpan
            tcell.Wrap = False
            tcell.VerticalAlign = VerticalAlign.Middle
            tcell.Controls.Add(TLink)
            Return tcell
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
