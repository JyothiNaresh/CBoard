Imports System.Web.Mail
Public Class MailsRd
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Dim msg As New Mail.MailMessage

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IsPostBack Then
                msg.To = "asreddyv@gmail.com"
                msg.From = "somesh@narayanainfo.com"
                msg.Subject = "Testing"
                msg.Body = "Testing Mail From E-mail System "

                SmtpMail.SmtpServer.Insert(0, "220.225.138.172")
                'SmtpMail.SmtpServer = "192.100.100.10"
                SmtpMail.Send(msg)

            End If
            
        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try
        

    End Sub

End Class
