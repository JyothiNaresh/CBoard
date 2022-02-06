Public Class PasswordFound
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Claas Variables"
    Dim a As PasswordEncrypt.PasswordEncrypt
#End Region

#Region "Methods"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            a = New PasswordEncrypt.PasswordEncrypt
            If Trim(TextBox1.Text) <> "" Then
                TextBox2.Text = a.EncriptText(Trim(TextBox1.Text))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            a = New PasswordEncrypt.PasswordEncrypt
            If Trim(TextBox2.Text) <> "" Then
                TextBox1.Text = a.DecriptText(Trim(TextBox2.Text))
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

    
End Class
