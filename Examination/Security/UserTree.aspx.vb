'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : UserTree
'   ACTIVITY                          : Users View
'   AUTHOR                            : Srikanth
'   INITIAL BASELINE DATE             : -JAN-2006
'   FINAL BASELINE DATE               : -JAN-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports Microsoft.Web.UI.WebControls
Imports CollegeBoardDLL
Public Class UserTree
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
    Private Dv As New DataView
    Private Formname As String = "Form1"
    Private objUcls As UserClass
#End Region

#Region "Common Methods"

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")
        Try
            If focusCtrl <> "" And strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & Formname & "." & focusCtrl & " == '[object]') { document." & Formname & "." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf focusCtrl <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & Formname & "." & focusCtrl & " == '[object]') { document." & Formname & "." & focusCtrl & ".focus(); } </script>")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Load Methods"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
            If Not IsPostBack Then
                FillDataset()
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
            Dim dsN As DataSet
            objUcls = New UserClass
            dsN = objUcls.FillTreeUserWise(Session("USERSLNO"), Session("COMACADEMICSLNO"))
            Dv = dsN.Tables(0).DefaultView
            FillParentTree("-1", TreeView1.Nodes)
        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function FillParentTree(ByVal PNodeId As String, ByVal Nodes As TreeNodeCollection)
        Try
            Dv.RowFilter = "idParentnode=" & PNodeId
            Dim dr As DataRowView

            For Each dr In Dv
                If dr("isparent") = 0 Then
                    Nodes.Add(NodeCreation(dr("nodecaption"), dr("idnode"), False, ""))
                Else
                    Nodes.Add(NodeCreation(dr("nodecaption"), dr("idnode"), False, dr("nodeaction")))
                End If
            Next

            Dim j As Integer

            For j = 0 To Nodes.Count - 1
                If (Nodes(j).ID <> "") Then
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
            'Node.Expandable = ExpandableValue.Auto
            'If Trim(text) = "NIMS" Then
            '    Node.Expanded = True
            'Else
            '    Node.Expanded = False
            'End If

            Node.Target = "right"
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
