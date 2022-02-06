'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is Presentation Layer For ModifyTreeNodes Creation
'   ACTIVITY                          :Modify Nodes 
'   AUTHOR                            : Srikanth
'   INITIAL BASELINE DATE             : 04-MAR-2006
'   FINAL BASELINE DATE               : 04-MAR-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Imports CollegeBoardDLL.WebTree
Imports System.Data.OracleClient
Public Class ModifyNodes
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfVDesc As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents rbtType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ftype As System.Web.UI.HtmlControls.HtmlInputFile

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
    Private nodeDesc, Filepath As String
    Private ds As DataSet
    ' Private webcls As New WebTree
    Private maxid, idParNode, parid, nodeType, isparent As Integer
    Private Formname As String = "Form1"
    Private objUcls As UserClass


#End Region

#Region "Common Methods"
    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")
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
#End Region

#Region "Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim parNode As String
        Try
            'If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)

                'TextBox1.Visible = False

                parid = Request.QueryString("Parid")
                idParNode = Request.QueryString("IdparNode")
                parNode = Request.QueryString("parNode")
                nodeDesc = Request.QueryString("Nodedesc")
                isparent = Request.QueryString("isparent")

                If parid <> 0 Then
                    If isparent = 0 Then
                        rbtType.SelectedValue = 0
                    ElseIf isparent = 1 Then
                        rbtType.SelectedValue = 1
                    End If
                    TextBox2.Text = nodeDesc
                End If

                TextBox1.Text = parNode


                If (rbtType.SelectedValue = 0) Then
                    Panel1.Visible = False
                    Panel2.Visible = False
                End If

            End If


        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try

    End Sub

    Private Sub rbtType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtType.SelectedIndexChanged
        Try

            If rbtType.SelectedValue = 0 Then
                Panel1.Visible = False
                Panel2.Visible = False
            Else
                Panel1.Visible = True
                Panel2.Visible = True
            End If

        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try

    End Sub



#End Region

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Try
            Dim ds As New DataSet
            objUcls = New UserClass

            nodeDesc = TextBox2.Text
            nodeType = rbtType.SelectedValue
            Filepath = ftype.Value
            If rbtType.SelectedValue = 1 AndAlso Filepath = "" Then
                StartUpScript("", "Must Give FilePath")
                Exit Sub
            End If

            If Not Filepath = "" Then
                Filepath = Filepath.Replace("\", "/")
                Filepath = Filepath.Replace("C:/Inetpub/wwwroot/CollegeAdm", "..")
            End If

            idParNode = Request.QueryString("idparnode")
            parid = Request.QueryString("parid")
            objUcls.Tree_Update(parid, nodeDesc, nodeType, Filepath)
            Response.Write("<script language=Javascript>Javascript:window.open('../Html/Home.Htm','_top');</script>")



        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub
End Class
