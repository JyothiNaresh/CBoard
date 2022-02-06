Imports System.Drawing.Printing
Imports System.Drawing.Size
Imports System.Drawing.Printing.PageSettings
Imports System.Drawing
Public Class TcGenerateCBSE
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    'Protected WithEvents lblClgNameCode As System.Web.UI.WebControls.Label
    'Protected WithEvents lblClgAddress1 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblClgAddress2 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label47 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblStuName As System.Web.UI.WebControls.Label
    'Protected WithEvents Label48 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblStuFname As System.Web.UI.WebControls.Label
    'Protected WithEvents Label49 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblStuMname As System.Web.UI.WebControls.Label
    'Protected WithEvents Label50 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblNationality As System.Web.UI.WebControls.Label
    'Protected WithEvents Label51 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblCaste As System.Web.UI.WebControls.Label
    'Protected WithEvents Label52 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblDob As System.Web.UI.WebControls.Label
    'Protected WithEvents lblDobwords As System.Web.UI.WebControls.Label
    Protected WithEvents Label53 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint8a As System.Web.UI.WebControls.Label
    Protected WithEvents Label38 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint8b As System.Web.UI.WebControls.Label
    'Protected WithEvents Label39 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint8c As System.Web.UI.WebControls.Label
    'Protected WithEvents Label40 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint8d As System.Web.UI.WebControls.Label
    'Protected WithEvents Label57 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblMedium As System.Web.UI.WebControls.Label
    'Protected WithEvents Label58 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblDoa As System.Web.UI.WebControls.Label
    Protected WithEvents Label59 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label45 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblAdmyear As System.Web.UI.WebControls.Label
    Protected WithEvents Label60 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label18 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint12 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label61 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label70 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label69 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label68 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblpoint13a As System.Web.UI.WebControls.Label
    'Protected WithEvents Label62 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label73 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label72 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint14a As System.Web.UI.WebControls.Label
    'Protected WithEvents Label76 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label75 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint14b As System.Web.UI.WebControls.Label
    'Protected WithEvents Label24 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label23 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint15a As System.Web.UI.WebControls.Label

    'Protected WithEvents lblPoint15b As System.Web.UI.WebControls.Label
    'Protected WithEvents Label65 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label82 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint16 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label66 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label85 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint17 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label88 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPoint18 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label67 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label34 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label37 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label41 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label42 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    Protected WithEvents Label21 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label22 As System.Web.UI.WebControls.Label
    'Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    'Protected WithEvents lblDocumentId As System.Web.UI.WebControls.Label
    'Protected WithEvents lblTCColName As System.Web.UI.WebControls.Label
    'Protected WithEvents Label35 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label36 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblTCRCNO As System.Web.UI.WebControls.Label
    'Protected WithEvents Label33 As System.Web.UI.WebControls.Label
    'Protected WithEvents lblTcno As System.Web.UI.WebControls.Label
    'Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    'Protected WithEvents LblAdmno As System.Web.UI.WebControls.Label

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            DsPriview = Session("DsPriview")
            FillLables(DsPriview)
            StartUpScript("", "1.Set Margins and Select Legal Paper for Printing")
        End If
    End Sub

#Region " * Fill Methods"

    Private Sub FillLables(ByVal ds As DataSet)
        Try
            If DsPriview.Tables(0).Rows(0)("DOCUMENTID") <= 1 Then
                lblDocumentId.Text = "ORIGINAL"
            ElseIf DsPriview.Tables(0).Rows(0)("DOCUMENTID") = 2 Then
                lblDocumentId.Text = "DUPLICATE"
            ElseIf DsPriview.Tables(0).Rows(0)("DOCUMENTID") > 2 Then
                lblDocumentId.Text = "TRIPLICATE"
            End If

            lblTCColName.Text = DsPriview.Tables(0).Rows(0)("COLNAME_HEADING").ToString
            ' lblTCRCNO.Text = DsPriview.Tables(0).Rows(0)("RCNO").ToString
            lblTcno.Text = DsPriview.Tables(0).Rows(0)("CERTIFICATENO").ToString
            'lblRcno.Text = DsPriview.Tables(0).Rows(0)("RCNO").ToString
            LblAdmno.Text = DsPriview.Tables(0).Rows(0)("ADMNO").ToString

            'lblClgNameCode.Text = DsPriview.Tables(0).Rows(0)("COLNAME").ToString
            LblColAddr.Text = DsPriview.Tables(0).Rows(0)("TCADDR1").ToString + "" + DsPriview.Tables(0).Rows(0)("TCADDR2").ToString
            ' lblClgAddress2.Text = DsPriview.Tables(0).Rows(0)("TCADDR2").ToString

            lblStuName.Text = DsPriview.Tables(0).Rows(0)("PUPILNAME").ToString
            lblStuFname.Text = DsPriview.Tables(0).Rows(0)("PARENTNAME").ToString
            lblStuMname.Text = DsPriview.Tables(0).Rows(0)("MOTHERNAME").ToString

            lblNationality.Text = DsPriview.Tables(0).Rows(0)("RELIGION").ToString
            lblCaste.Text = DsPriview.Tables(0).Rows(0)("CASTE").ToString
            lblDob.Text = DsPriview.Tables(0).Rows(0)("DOB").ToString
            lblDobwords.Text = DsPriview.Tables(0).Rows(0)("DOBWORDS").ToString

            'lblPoint8a.Text = DsPriview.Tables(0).Rows(0)("PASS").ToString
            'lblPoint8b.Text = DsPriview.Tables(0).Rows(0)("FIRTLANG").ToString
            'lblPoint8c.Text = DsPriview.Tables(0).Rows(0)("SECLANG").ToString
            'lblPoint8d.Text = DsPriview.Tables(0).Rows(0)("PART3").ToString()

            'lblMedium.Text = DsPriview.Tables(0).Rows(0)("MOTHERTANGUE").ToString()
            lblPoint17.Text = DsPriview.Tables(0).Rows(0)("TCISSUEDDATE").ToString()
            lblgameplayed.Text = DsPriview.Tables(0).Rows(0)("GAMES").ToString()

            lblncc.Text = DsPriview.Tables(0).Rows(0)("NCC").ToString()
            lblpoint13a.Text = DsPriview.Tables(0).Rows(0)("DATEOFJOIN").ToString()

            lblsubjectstudied.Text = DsPriview.Tables(0).Rows(0)("SUBJECTS").ToString()
            'lblPoint14b.Text = DsPriview.Tables(0).Rows(0)("CERTIFICATENO").ToString()

            lbltotworkingdays.Text = DsPriview.Tables(0).Rows(0)("WRK_DAYS").ToString()
            Label46.Text = DsPriview.Tables(0).Rows(0)("PRES_DAYS").ToString()
            lblPoint16.Text = DsPriview.Tables(0).Rows(0)("DATEOFLEAVING").ToString()
            Label55.Text = DsPriview.Tables(0).Rows(0)("TCISSUEDDATE").ToString()
            lblPoint18.Text = DsPriview.Tables(0).Rows(0)("CONDUCT").ToString()
            Image1.ImageUrl = DsPriview.Tables(0).Rows(0)("LOGOPATH")


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