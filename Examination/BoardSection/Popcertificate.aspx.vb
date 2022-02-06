Public Class Popcertificate
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Request.QueryString("image1") = String.Empty) Then
        
            Dim path As String
            path = Request.QueryString("image1").ToString().Replace("F:/", "")
            Response.Redirect("http://apps.narayanagroup.org/" + path)

        End If


    End Sub

End Class