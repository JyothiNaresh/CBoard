Public Class CCGenerateMumbai
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    'Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    'Protected WithEvents Label35 As System.Web.UI.WebControls.Label
    'Protected WithEvents LblAdmno As System.Web.UI.WebControls.Label
    'Protected WithEvents LblDate As System.Web.UI.WebControls.Label
    'Protected WithEvents lblCCColName As System.Web.UI.WebControls.Label
    'Protected WithEvents LblFather As System.Web.UI.WebControls.Label
    'Protected WithEvents lBLgRP As System.Web.UI.WebControls.Label
    'Protected WithEvents LblCourse As System.Web.UI.WebControls.Label
    'Protected WithEvents LblMed As System.Web.UI.WebControls.Label
    'Protected WithEvents LblFrom As System.Web.UI.WebControls.Label
    'Protected WithEvents Image6 As System.Web.UI.WebControls.Image
    'Protected WithEvents Image8 As System.Web.UI.WebControls.Image
    'Protected WithEvents Image10 As System.Web.UI.WebControls.Image
    'Protected WithEvents Image11 As System.Web.UI.WebControls.Image
    'Protected WithEvents Image2 As System.Web.UI.WebControls.Image
    'Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    'Protected WithEvents Image3 As System.Web.UI.WebControls.Image
    'Protected WithEvents Image4 As System.Web.UI.WebControls.Image
    'Protected WithEvents Image5 As System.Web.UI.WebControls.Image
    'Protected WithEvents Lblname As System.Web.UI.WebControls.Label
    'Protected WithEvents Label36 As System.Web.UI.WebControls.Label
    'Protected WithEvents LblColAddr As System.Web.UI.WebControls.Label

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
    Dim DsCCPriview As DataSet
    Dim FROM As String
    Dim TODATE As String
    Dim CRS As String
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            DsCCPriview = Session("DsCCPriview")
            FROM = Session("FROM")
            CRS = Session("CRS")
            TODATE = Session("TODATE")
            FillLables(DsCCPriview)
            StartUpScript("", "Set Margins and Select Legal Paper for Printing")
        End If
    End Sub

    Private Sub FillLables(ByVal ds As DataSet)
        Try
            lblCCColName.Text = DsCCPriview.Tables(0).Rows(0)("COLNAME_HEADING").ToString
            LblAdmno.Text = DsCCPriview.Tables(0).Rows(0)("ADMNO").ToString
            LblDate.Text = DsCCPriview.Tables(0).Rows(0)("PRNDATE").ToString
            Lblname.Text = DsCCPriview.Tables(0).Rows(0)("STDNAME").ToString
            LblFather.Text = DsCCPriview.Tables(0).Rows(0)("FATHERNAME").ToString
            LblFrom.Text = FROM.ToString + " - " + TODATE.ToString
            LblColAddr.Text = DsCCPriview.Tables(0).Rows(0)("ADDR").ToString()
            LblCourse.Text = CRS.ToString
            '  Image1.ImageUrl = DsCCPriview.Tables(0).Rows(0)("LOGOPATH")
            '  lBLgRP.Text = DsCCPriview.Tables(0).Rows(0)("GRP").ToString()
            LblMed.Text = DsCCPriview.Tables(0).Rows(0)("MEDIUMS").ToString()
            lblphone.Text = DsCCPriview.Tables(0).Rows(0)("PHONE1").ToString
            lblemailid.Text = DsCCPriview.Tables(0).Rows(0)("EMAIL").ToString
            lbludise.Text = DsCCPriview.Tables(0).Rows(0)("UDISENO").ToString
            lblindexno.Text = DsCCPriview.Tables(0).Rows(0)("INDEXNUMBER").ToString()
            lblGrno.Text = DsCCPriview.Tables(0).Rows(0)("GRNO").ToString
        Catch ex As Exception

        End Try
    End Sub

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