'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is Presentation Layer For UsersPermissions
'   ACTIVITY                          : UserPermission
'   AUTHOR                            : Srikanth
'   INITIAL BASELINE DATE             : -JAN-2006
'   FINAL BASELINE DATE               : -JAN-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports Microsoft.Web.UI.WebControls
Imports CollegeBoardDLL
Imports System.Data.OracleClient

Public Class UserAccess
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents TreeView1 As Microsoft.Web.UI.WebControls.TreeView
    Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents drpUserType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblUserType As System.Web.UI.WebControls.Label
    Protected WithEvents PageY As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents PageX As System.Web.UI.HtmlControls.HtmlInputHidden

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

    Private sqltree, userid, idstring As String
    Private webcls As WebTree
    Private ds As DataSet
    Private dv As New DataView
    Private FormName As String = "Form1"
    Private dsPer As New DataSet
    Private dRow As DataRow
    Private dt As New DataTable
    Private objUscls As UserClass
    Private RtnStr As String
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
            If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                FillUsertype()
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

    Private Function FillUsertype()
        Try
            ds = New DataSet
            ds = ClsUty.DataSet_Fetch("SELECT USERTYPESLNO,NAME FROM E_USERTYPE_MT WHERE USERTYPESLNO<>1")
            drpUserType.DataSource = ds
            drpUserType.DataTextField = "NAME"
            drpUserType.DataValueField = "USERTYPESLNO"
            drpUserType.DataBind()
            drpUserType.Items.Insert(0, New ListItem("SELECT", 0))
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "Combo Events"

    Private Sub drpUserType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpUserType.SelectedIndexChanged
        Try
            FillDataset()
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try

    End Sub

#End Region

#Region "Button Events"

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Try
            objUscls = New UserClass
            webcls = New WebTree
            dsPer = New DataSet
            dt = New DataTable
            Dim dRow As DataRow
            dt.Columns.Add("IDNODE", GetType(System.Int16))
            dt.Columns.Add("IDPARENTNODE", GetType(System.Int16))
            dsPer.Tables.Add(dt)

            idstring = ""
            If drpUserType.SelectedValue = 0 Then
                StartUpScript("", GeneralErrorMessage("Must Select UserType"))
                Exit Sub
            Else
                Dim j As Integer
                For j = 0 To TreeView1.Nodes.Count - 1
                    If (TreeView1.Nodes(j).Checked) Then
                        ''' idstring = idstring & "," & TreeView1.Nodes(j).ID
                        dRow = dsPer.Tables(0).NewRow
                        dRow("IDNODE") = 1
                        dRow("IDPARENTNODE") = -1
                        dsPer.Tables(0).Rows.Add(dRow)
                    End If

                    If TreeView1.Nodes(j).ID <> "" Then
                        FillparentTree(TreeView1.Nodes(j).ID, TreeView1.Nodes(j).Nodes)
                    End If
                Next

                RtnStr = objUscls.User_Permissions_Save(dsPer, drpUserType.SelectedValue)
                If RtnStr = "SUCCESS" Then
                    StartUpScript("", "Record Saved")

                End If
                'Response.Write("<script language=Javascript>Javascript:window.open('../Html/Home.Htm','_top');</script>")
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

#Region "TreeView Methods"

    Private Function FillDataset()
        Try
            objUscls = New UserClass
            '  webcls = New WebTree
            ds = objUscls.GetUserAccessTree(drpUserType.SelectedValue)
            '  ds = webcls.GetUserAccessTree(drpUserType.SelectedValue)
            If Not ds Is Nothing Then
                dv = ds.Tables(0).DefaultView
                TreeView1.Nodes.Clear()
                FillparentTree(-1, TreeView1.Nodes)
            End If

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function FillparentTree(ByVal PNodeId As Integer, ByVal Nodes As TreeNodeCollection)
        Try
            Dim j As Integer
            Dim dr As DataRowView

            dt = New DataTable
            Dim dRow As DataRow
            dt.Columns.Add("IDNODE", GetType(System.Int16))
            dt.Columns.Add("IDPARENTNODE", GetType(System.Int16))
            dsPer.Tables.Add(dt)

            dv.RowFilter = "idParentnode=" & PNodeId

            For Each dr In dv
                ' Dim ret As String = webcls.GetUserRights(dr("idnode"), usertypeslno)
                If (dr("ISPARENT") = 0) Then

                    Nodes.Add(NodeCreation(dr("nodecaption"), dr("idnode"), True, IIf(IsDBNull(dr("nodeaction")), "", dr("nodeaction")), dr("SS")))
                Else
                    Nodes.Add(NodeCreation(dr("nodecaption"), dr("idnode"), True, IIf(IsDBNull(dr("nodeaction")), "", dr("nodeaction")), dr("SS")))
                End If
            Next

            For j = 0 To Nodes.Count - 1
                If (Nodes(j).Checked = True) Then
                    idstring = idstring & "," & Nodes(j).ID

                    dRow = dsPer.Tables(0).NewRow
                    dRow("IDNODE") = Nodes(j).ID
                    dRow("IDPARENTNODE") = PNodeId
                    dsPer.Tables(0).Rows.Add(dRow)

                End If
                If Nodes(j).ID <> "" Then
                    FillparentTree(Nodes(j).ID, Nodes(j).Nodes)
                End If
            Next

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function NodeCreation(ByVal Text As String, ByVal IDNODE As String, ByVal isCheckBox As Boolean, ByVal Nurl As String, ByVal ret As Integer) As TreeNode
        Try
            Dim ret1 As Boolean
            Dim Node As TreeNode
            Node = New TreeNode
            Node.CheckBox = isCheckBox
            Node.Expandable = ExpandableValue.Auto
            'Node.Expanded = True
            Node.Target = "right"
            Node.NavigateUrl = Nurl
            Node.Text = Text
            Node.ID = IDNODE
            If ret = 1 Then
                ret1 = True
            Else
                ret = False
            End If
            Node.Checked = ret1
            'If ID = 1 Then
            '    Node.Checked = True
            'End If
            Return Node

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub TigerCheck(ByVal Str As String)
        Try
            Dim i, j As Integer
            Dim StrSplit() As String
            Dim Node, ParentNode As TreeNode
            Dim Flag As Integer
            StrSplit = Str.Split(".")
            j = StrSplit.Length

            If j = 2 Then
                If TreeView1.Nodes(CInt(StrSplit(0))).Nodes(CInt(StrSplit(1))).Checked Then
                    Node = TreeView1.Nodes(CInt(StrSplit(0))).Nodes(CInt(StrSplit(1)))
                    CheckParentCheckedOrNot(Node)
                Else
                    Node = TreeView1.Nodes(CInt(StrSplit(0))).Nodes(CInt(StrSplit(1)))
                    If CheckChildCheckedOrNot(Node.Nodes) Then
                        Node.Checked = True
                        StartUpScript("", "Not possible")
                    End If
                End If
            ElseIf j = 3 Then
                If TreeView1.Nodes(CInt(StrSplit(0))).Nodes(CInt(StrSplit(1))).Nodes(CInt(StrSplit(2))).Checked Then
                    Node = TreeView1.Nodes(CInt(StrSplit(0))).Nodes(CInt(StrSplit(1))).Nodes(CInt(StrSplit(2)))
                    CheckParentCheckedOrNot(Node)
                Else
                    Node = TreeView1.Nodes(CInt(StrSplit(0))).Nodes(CInt(StrSplit(1))).Nodes(CInt(StrSplit(2)))
                    If CheckChildCheckedOrNot(Node.Nodes) Then
                        Node.Checked = True
                        StartUpScript("", "Not possible")
                    End If
                End If
            ElseIf j = 4 Then
                If TreeView1.Nodes(CInt(StrSplit(0))).Nodes(CInt(StrSplit(1))).Nodes(CInt(StrSplit(2))).Nodes(CInt(StrSplit(3))).Checked Then
                    Node = TreeView1.Nodes(CInt(StrSplit(0))).Nodes(CInt(StrSplit(1))).Nodes(CInt(StrSplit(2))).Nodes(CInt(StrSplit(3)))
                    CheckParentCheckedOrNot(Node)
                Else
                    Node = TreeView1.Nodes(CInt(StrSplit(0))).Nodes(CInt(StrSplit(1))).Nodes(CInt(StrSplit(2))).Nodes(CInt(StrSplit(3)))
                    If CheckChildCheckedOrNot(Node.Nodes) Then
                        Node.Checked = True
                        StartUpScript("", "Not possible")
                    End If
                End If
            ElseIf j = 5 Then
                If TreeView1.Nodes(CInt(StrSplit(0))).Nodes(CInt(StrSplit(1))).Nodes(CInt(StrSplit(2))).Nodes(CInt(StrSplit(3))).Nodes(CInt(StrSplit(4))).Checked Then
                    Node = TreeView1.Nodes(CInt(StrSplit(0))).Nodes(CInt(StrSplit(1))).Nodes(CInt(StrSplit(2))).Nodes(CInt(StrSplit(3))).Nodes(CInt(StrSplit(4)))
                    CheckParentCheckedOrNot(Node)
                Else
                    Node = TreeView1.Nodes(CInt(StrSplit(0))).Nodes(CInt(StrSplit(1))).Nodes(CInt(StrSplit(2))).Nodes(CInt(StrSplit(3))).Nodes(CInt(StrSplit(4)))
                    If CheckChildCheckedOrNot(Node.Nodes) Then
                        Node.Checked = True
                        StartUpScript("", "Not possible")
                    End If
                End If
            ElseIf j = 6 Then
                If TreeView1.Nodes(CInt(StrSplit(0))).Nodes(CInt(StrSplit(1))).Nodes(CInt(StrSplit(2))).Nodes(CInt(StrSplit(3))).Nodes(CInt(StrSplit(4))).Nodes(CInt(StrSplit(5))).Checked Then
                    Node = TreeView1.Nodes(CInt(StrSplit(0))).Nodes(CInt(StrSplit(1))).Nodes(CInt(StrSplit(2))).Nodes(CInt(StrSplit(3))).Nodes(CInt(StrSplit(4))).Nodes(CInt(StrSplit(5)))
                    CheckParentCheckedOrNot(Node)
                Else
                    Node = TreeView1.Nodes(CInt(StrSplit(0))).Nodes(CInt(StrSplit(1))).Nodes(CInt(StrSplit(2))).Nodes(CInt(StrSplit(3))).Nodes(CInt(StrSplit(4))).Nodes(CInt(StrSplit(5)))
                    If CheckChildCheckedOrNot(Node.Nodes) Then
                        Node.Checked = True
                        StartUpScript("", "Not possible")
                    End If
                End If
            End If
        Catch aex As ArgumentOutOfRangeException

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Private Sub CheckParentCheckedOrNot(ByVal Node As TreeNode)
        Try
            Dim ParentNode As TreeNode
            ParentNode = Node.Parent
            ParentNode.Checked = True
            If ParentNode.ID <> 1 Then
                CheckParentCheckedOrNot(ParentNode)
            End If
        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CheckChildCheckedOrNot(ByVal Nodes As TreeNodeCollection) As Boolean
        Try
            Dim Node As TreeNode
            For Each Node In Nodes
                If Node.Checked Then
                    Return True
                End If
                CheckChildCheckedOrNot(Node.Nodes)
            Next
            Return False
        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "TreeView Events"

    Private Sub TreeView1_Check(ByVal sender As Object, ByVal e As Microsoft.Web.UI.WebControls.TreeViewClickEventArgs) Handles TreeView1.Check
        Try
            If e.Node = "0" Then
                TreeView1.Nodes(0).Checked = True
                StartUpScript("", "Can not modify.")
                Exit Sub
            End If
            TigerCheck(e.Node)
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

#End Region

End Class
