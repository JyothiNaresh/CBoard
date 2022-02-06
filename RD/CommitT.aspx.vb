Imports System.EnterpriseServices

Public Class CommitT
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents iBtnGo As System.Web.UI.WebControls.Button
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Session("A") = 10
            ContextUtil.SetComplete()
            Response.Write(Session("A"))
            Dim A As Integer

            A = Asc(TextBox1.Text)

        Catch ex As Exception

            ContextUtil.SetAbort()

        End Try
    End Sub

    Private Sub Page_CommitTransaction(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.CommitTransaction
        Response.Write("COMMITTED")
    End Sub

    Private Sub Page_AbortTransaction(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.AbortTransaction
        Response.Write("ABORTED")
    End Sub

    Private Sub iBtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iBtnGo.Click
        Try
            Server.Transfer("SSC.ASPX")
            Session("A") = 20
        Catch ex As Exception
            '''''Page_AbortTransaction(sender, e)
        End Try
    End Sub

End Class
