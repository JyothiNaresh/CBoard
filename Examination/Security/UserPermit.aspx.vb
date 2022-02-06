
Imports System.Data
Imports System.Data.OracleClient
Imports Microsoft.Web.UI.WebControls
Imports CollegeBoardDLL
Imports CollegeBoardDLL.UserClass


Public Class UserPermit
    Inherits System.Web.UI.Page

#Region "Class Variables"
    Private cls1 As New CollegeBoardDLL.UserClass
    Private ds As New DataSet
    Protected WithEvents TreeView1 As Microsoft.Web.UI.WebControls.TreeView
    Private sql As String
    Private Dv As New DataView
    Private sqltree As String
    Private Formname As String = "Form1"
    Dim ClsUty As New Utility
#End Region

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

#Region "Load Methods"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                Dim Node As New TreeNode
                TreeView1.Nodes.Add(Node)

                Call FillDataset()
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

#Region "Fill Methods"

    Private Function FillDataset()
        Try
            sqltree = "select idnode,idparentnode,nodecaption,isparent,nodeaction from E_TREECONTENTS_MT "
            ds = ClsUty.DataSet_Fetch(sqltree)
            Dv = ds.Tables(0).DefaultView
            Call FillParentTree("-1", TreeView1.Nodes)
        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function FillParentTree(ByVal PNodeId As String, ByVal Nodes As TreeNodeCollection)
        Try
            Dv.RowFilter = "idParentnode=" & PNodeId
            Dim n As New TreeNode
            Dim dr As DataRowView

            For Each dr In Dv
                If dr("isparent") = 0 Then
                    Nodes.Add(Node(dr("nodecaption"), dr("idnode"), False, ""))
                Else
                    Nodes.Add(Node(dr("nodecaption"), dr("idnode"), False, dr("nodeaction")))
                End If
            Next
            Dim j As Integer

            For j = 0 To Nodes.Count - 1
                If Nodes.Count = 0 Then
                    Exit For
                End If
                If (Nodes(j).ID <> "") Then
                    Call FillParentTree(Nodes(j).ID, Nodes(j).Nodes)
                End If

            Next

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function Node(ByVal text As String, ByVal id As String, ByVal check As Boolean, ByVal nurl As String) As TreeNode
        Try
            Dim n As TreeNode
            n = New TreeNode
            n.CheckBox = check
            n.Expandable = ExpandableValue.Auto
            n.Expanded = False
            n.Target = "right"
            n.NavigateUrl = nurl
            n.Text = text
            n.ID = id

            Return n
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
