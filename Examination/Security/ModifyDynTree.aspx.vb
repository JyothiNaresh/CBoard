'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is Presentation Layer For ModifyDynamicTree
'   ACTIVITY                          : ModDynamicTreeView
'   AUTHOR                            : Srikanth
'   INITIAL BASELINE DATE             : 04-mar-2006
'   FINAL BASELINE DATE               : 04-mar-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data
Imports System.Data.OracleClient
Imports Microsoft.Web.UI.WebControls
Imports CollegeBoardDLL
Imports CollegeBoardDLL.UserClass
Public Class ModifyDynTree
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents TreeView1 As Microsoft.Web.UI.WebControls.TreeView

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
    Private ds As DataSet
    Private Dv As New DataView
    Private Formname As String = "Form1"
    Dim ClsUty As New Utility
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
            Dim sqltree As String
            sqltree = "SELECT IDNODE,IDPARENTNODE,NODECAPTION,ISPARENT,NODEACTION FROM E_TREECONTENTS_MT ORDER BY IDNODE "
            ds = ClsUty.DataSet_Fetch(sqltree)
            Dv = ds.Tables(0).DefaultView
            FillParentTree("-1", TreeView1.Nodes)
        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function FillParentTree(ByVal PNodeId As String, ByVal Nodes As TreeNodeCollection)
        Try
            Dim j As Integer
            Dim dr As DataRowView

            Dv.RowFilter = "idParentnode=" & PNodeId

            For Each dr In Dv
                If dr("isparent") = 0 Then
                    Nodes.Add(NodeCreation(dr("nodecaption"), dr("idnode"), False, "ModifyNodes.aspx?parId=" & dr("idnode") & "&NodeDesc=" & dr("nodecaption") & "&IdparNode=" & dr("idparentnode") & "&isparent=" & dr("isparent")))
                Else
                    Nodes.Add(NodeCreation(dr("nodecaption"), dr("idnode"), False, "ModifyNodes.aspx?parId=" & dr("idnode") & "&NodeDesc=" & dr("nodecaption") & "&IdparNode=" & dr("idparentnode") & "&isparent=" & dr("isparent")))
                End If
            Next

            For j = 0 To Nodes.Count - 1
                If Nodes(j).ID <> "" Then
                    FillParentTree(Nodes(j).ID, Nodes(j).Nodes)
                End If
            Next
        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function NodeCreation(ByVal text As String, ByVal IDNODE As String, ByVal IsCheckBox As Boolean, ByVal nurl As String) As TreeNode
        Try
            Dim Node As New TreeNode

            Node.CheckBox = IsCheckBox
            Node.Expandable = ExpandableValue.Auto
            ' Node.Expanded = True
            Node.Target = "f2"
            Node.NavigateUrl = nurl
            Node.Text = text
            Node.ID = IDNODE
            Return Node
        Catch ex As Exception
            Throw ex

        End Try

    End Function
#End Region
End Class
