Imports CollegeBoardDLL
Public Class DataGridRelation
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgSets As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Datagrid1 As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " Class Varilables "
    Dim DSet As New DataSet
    Dim ClsRep As New Utility
#End Region

#Region " Methods "

#Region " PrePareTable"

    Private Sub PrepareTable()
        Try

            Dim dTable As New DataTable("subjects")


            dTable.Columns.Add("SUBJECTSLNO", Type.GetType("System.String"))
            dTable.Columns.Add("SUBJECTNAME", Type.GetType("System.String"))


            DSet.Tables.Add(dTable)
            ' Me.Session("DSet") = DSet

           

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrepareTableTopic()
        Try

            Dim dTable As New DataTable("topics")

            dTable.Columns.Add("SUBJECTSLNO", Type.GetType("System.String"))
            dTable.Columns.Add("TOPICSLNO", Type.GetType("System.String"))
            dTable.Columns.Add("TOPICNAME", Type.GetType("System.String"))

            DSet.Tables.Add(dTable)



         

          
            


        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataRelation()
        Try

            Dim dRelate As DataRelation
            dRelate = New DataRelation("ParentChild", DSet.Tables("subjects").Columns("SUBJECTSLNO"), DSet.Tables("topics").Columns("SUBJECTSLNO"), False)
            DSet.Relations.Add(dRelate)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillDataSet()
        Try
            Dim StRSql As String
            StRSql = " SELECT SUBJECTSLNO,NAME SUBJECTNAME FROM T_SUBJECT_MT "
            Dim DS As DataSet
            DS = ClsRep.DataSet_OneFetch(StRSql)

            Dim dr As DataRow

            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                dr = DSet.Tables("subjects").NewRow
                dr("SUBJECTSLNO") = DS.Tables(0).Rows(i)("SUBJECTSLNO")
                dr("SUBJECTNAME") = DS.Tables(0).Rows(i)("SUBJECTNAME")
                DSet.Tables("subjects").Rows.Add(dr)
            Next

            StRSql = " SELECT SUBJECTSLNO,TOPICSLNO,NAME TOPICNAME FROM T_TOPICS_MT "
            DS = ClsRep.DataSet_OneFetch(StRSql)

            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                dr = DSet.Tables("topics").NewRow
                dr("SUBJECTSLNO") = DS.Tables(0).Rows(i)("SUBJECTSLNO")
                dr("TOPICSLNO") = DS.Tables(0).Rows(i)("TOPICSLNO")
                dr("TOPICNAME") = DS.Tables(0).Rows(i)("TOPICNAME")
                DSet.Tables("topics").Rows.Add(dr)
            Next


            dgSets.DataSource = DSet.Tables("subjects")
            dgSets.DataBind()

            'Datagrid1.DataSource = DSet.Tables("subjects")
            'Datagrid1.DataBind()


            Me.Session("DSet") = DSet


        Catch ex As Exception

        End Try
    End Sub

#End Region

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IsPostBack() Then
                PrepareTable()
                PrepareTableTopic()
                DataRelation()
                FillDataSet()
            Else
                DSet = Me.Session("DSet")
            End If

        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub Datagrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles Datagrid1.ItemCommand
        Try
            If e.CommandName = "LbtnUnRead" Then
                Dim Dr() As DataRow
                Dr = DSet.Tables("topics").Select("SUBJECTSLNO='" & Trim(Datagrid1.Items(e.Item.ItemIndex).Cells(2).Text) & "'")

                Dim DsT As New DataSet

                Dim dTable As New DataTable("topics")

                dTable.Columns.Add("SUBJECTSLNO", Type.GetType("System.String"))
                dTable.Columns.Add("TOPICSLNO", Type.GetType("System.String"))
                dTable.Columns.Add("TOPICNAME", Type.GetType("System.String"))

                DsT.Tables.Add(dTable)

                If Dr.LongLength > 0 Then

                    For i As Integer = 0 To Dr.LongLength - 1
                        Dim Drc As DataRow
                        Drc = DsT.Tables("topics").NewRow

                        Drc("SUBJECTSLNO") = Dr(i)("SUBJECTSLNO")
                        Drc("TOPICSLNO") = Dr(i)("TOPICSLNO")
                        Drc("TOPICNAME") = Dr(i)("TOPICNAME")

                        DsT.Tables("topics").Rows.Add(Drc)

                    Next

                End If

                'Dim DVIEW As DataView
                'DVIEW = New DataView(DSet.Tables("topics"), "SUBJECTSLNO='" & Trim(Datagrid1.Items(e.Item.ItemIndex).Cells(2).Text) & "'")

                Dim Drg As DataGrid
                Drg = CType(Datagrid1.Items(e.Item.ItemIndex).Cells(4).FindControl("DataGrid2"), DataGrid)
                Drg.DataSource = DsT.Tables("topics")
                Drg.DataBind()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Datagrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles Datagrid1.PageIndexChanged
        Try

            Datagrid1.CurrentPageIndex = e.NewPageIndex
            Datagrid1.DataSource = DSet.Tables("subjects")
            Datagrid1.DataBind()

        Catch ex As Exception

        End Try
    End Sub



    Private Sub dgSets_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgSets.ItemCommand
        Try
            If e.CommandName = "LbtnUnRead" Then
                Dim Dr() As DataRow
                Dr = DSet.Tables("topics").Select("SUBJECTSLNO='" & Trim(dgSets.Items(e.Item.ItemIndex).Cells(0).Text) & "'")

                Dim DsT As New DataSet

                Dim dTable As New DataTable("topics")

                dTable.Columns.Add("SUBJECTSLNO", Type.GetType("System.String"))
                dTable.Columns.Add("TOPICSLNO", Type.GetType("System.String"))
                dTable.Columns.Add("TOPICNAME", Type.GetType("System.String"))

                DsT.Tables.Add(dTable)

                If Dr.LongLength > 0 Then

                    For i As Integer = 0 To Dr.LongLength - 1
                        Dim Drc As DataRow
                        Drc = DsT.Tables("topics").NewRow

                        Drc("SUBJECTSLNO") = Dr(i)("SUBJECTSLNO")
                        Drc("TOPICSLNO") = Dr(i)("TOPICSLNO")
                        Drc("TOPICNAME") = Dr(i)("TOPICNAME")

                        DsT.Tables("topics").Rows.Add(Drc)

                    Next

                End If

                'Dim DVIEW As DataView
                'DVIEW = New DataView(DSet.Tables("topics"), "SUBJECTSLNO='" & Trim(Datagrid1.Items(e.Item.ItemIndex).Cells(2).Text) & "'")

                Dim Drg As DataGrid
                Drg = CType(dgSets.Items(e.Item.ItemIndex).Cells(2).FindControl("Datagrid4"), DataGrid)
                Drg.DataSource = DsT.Tables("topics")
                Drg.DataBind()

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
