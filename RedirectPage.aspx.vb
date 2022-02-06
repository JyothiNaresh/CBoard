Public Class RedirectPage
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private strErrMessage As String = "Error"

#Region "Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
            '''Response.Write("<script language=Javascript>Javascript:window.open('http://localhost/prototypefinal/Home.aspx','_top');</script>")
            Response.Write("<script language=Javascript>Javascript:window.open('Home.aspx','_top');</script>")
            Exit Sub
        End If

        If Not IsNothing(Request.QueryString("Msg")) Then
            strErrMessage = Request.QueryString("Msg")
        End If

        '''Response.Write("<H1>" & strErrMessage & "</H1>")
        Label1.Text = strErrMessage

    End Sub

#End Region

End Class
