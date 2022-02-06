'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : ENTRY FORM FOR OBJECTIONS FROM BRANCHES
'   AUTHOR                            : P.VENU
'   INITIAL BASELINE DATE             : 18.07.2011
'   FINAL BASELINE DATE               : 19.07.2011
'   COMPLETED DATE                    :   .07.2011
'----------------------------------------------------------------------------------------------

Imports CollegeBoardDLL
Public Class Objection_ObjectionsEntry
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ImageButton2 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpEB As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpEN As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpED As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DgSubject As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DgObjections As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "FormVariables"

    Dim SqlStr, StrSplit, StrSplitStr(), StrSplitData, SplitStr As String
    Dim objWSCombo As Utility
    Private DsSbj As DataSet
    Dim ObjFetch As Utility
    Dim Dset, DsSplit As New DataSet
    Dim i As Integer

#End Region

#Region " Page Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Try

            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                ' FillExamBranch()
                ' FillExamNames()
                'FillDrpSubject()
                FillEmptyGrid()
                FillDrpSubject()
            Else
                FillEmptyGrid()
                FillDrpSubject()
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " DropDown Events"

    'Protected Sub DrpSubject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        'Dim pagerRow As GridViewRow = CustomersGridView.BottomPagerRow
    '        Dim drp1 As DropDownList = CType(DgObjection.Items(0).Controls(1).FindControl("drpSubject"), DropDownList)
    '        Response.Write(drp1.SelectedItem.Value)
    '    Catch ex As Exception
    '    End Try
    'End Sub

#End Region

#Region " Fill Methods"

    Private Sub FillExamBranch()
        Try
            SqlStr = "SELECT EXAMBRANCHSLNO,EXAMBRANCHNAME FROM EXAM_EXAMBRANCH WHERE EXAMBRANCHSLNO IN (SELECT EXAMBRANCHSLNO FROM E_USER_BRANCH_ACADEMIC_MT WHERE COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND USERSLNO=" & Session("USERSLNO") & ") ORDER BY EXAMBRANCHNAME"
            objWSCombo = New Utility
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)
            DrpEB.DataTextField = "EXAMBRANCHNAME"
            DrpEB.DataValueField = "EXAMBRANCHSLNO"
            DrpEB.DataSource = Dset
            DrpEB.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillExamNames()
        Try
            SqlStr = "SELECT OBJEXAMSLNO,OBJEXAMNAME FROM OBJECTIONS_EXAMNAME_MT"
            objWSCombo = New Utility
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)
            DrpEN.DataTextField = "OBJEXAMNAME"
            DrpEN.DataValueField = "OBJEXAMSLNO"
            DrpEN.DataSource = Dset
            DrpEN.DataBind()

            FillEmptyGrid()
            FillExamDate()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillExamDate()
        Try
            SqlStr = "SELECT OBJTESTSLNO,OBJTESTDATE FROM OBJECTIONS_EXAM_DATE_MAP WHERE OBJEXAMSLNO=" & DrpEN.SelectedItem.Value
            objWSCombo = New Utility
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)
            DrpED.DataTextField = "OBJTESTDATE"
            DrpED.DataValueField = "OBJTESTSLNO"
            DrpED.DataSource = Dset
            DrpED.DataBind()

            FillEmptyGrid()
            FillDrpSubject()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillDrpSubject()
        Try
            Dim i As Integer
            Dim dr As DataRow

            StrSplit = "SELECT SUBJECTS FROM OBJECTIONS_EXAM_DATE_MAP WHERE OBJTESTSLNO=20" ' & DrpED.SelectedItem.Value
            objWSCombo = New Utility
            DsSplit = objWSCombo.DataSet_OneFetch(StrSplit)

            SplitStr = DsSplit.Tables(0).Rows(0).Item(0).ToString
            StrSplitStr = SplitStr.Split(",")
            For i = 0 To StrSplitStr.Length - 1
                StrSplitData += StrSplitStr(i).ToString + IIf(StrSplitStr.Length - 1 <> i, ",", "")
            Next

            SqlStr = "SELECT SUBJECTSLNO,NAME FROM T_SUBJECT_MT WHERE SUBJECTSLNO IN(" & StrSplitData & ")"

            objWSCombo = New Utility
            If IsNothing(DsSbj) Then
                DsSbj = objWSCombo.DataSet_OneFetch(SqlStr)
                'Me.ViewState("DsSbj") = DsSbj
            End If

            Dim drpDown1 As DropDownList
            For i = 0 To 9
                drpDown1 = CType(DgObjections.Items(i).Cells(1).FindControl("DrpSubject"), DropDownList)
                drpDown1.DataSource = DsSbj
                drpDown1.DataTextField = "NAME"
                drpDown1.DataValueField = "SUBJECTSLNO"
                drpDown1.DataBind()
            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillEmptyGrid()
        Try
            Dim dt As New DataTable
            dt.Columns.Add("SNO", Type.GetType("System.Int32"))
            For i As Integer = 1 To 10
                Dim dRow As DataRow
                dRow = dt.NewRow
                dRow("SNO") = i
                dt.Rows.Add(dRow)
            Next
            DgObjections.DataSource = dt
            DgObjections.DataBind()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Grid Events"

    'Private Sub DgObjection_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DgObjection.ItemDataBound
    '    Try
    '        'Response.Write("Item")
    '        Dim Drp1 As DropDownList = CType(DgObjection.Items(e.Item.ItemIndex).Controls(1).FindControl("DrpSub"), DropDownList)
    '        Response.Write(Drp1.SelectedItem.Value)
    '    Catch ex As Exception

    '    End Try
    'End Sub

#End Region

    'Protected Sub Drpsub_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    Try
    '        'Dim Drp As DropDownList = CType(DgObjection.Items(0).Controls(1).FindControl("DrpSub"), DropDownList)
    '        'Response.Write(Drp.SelectedItem.Value)
    '        Response.Write("Event Fired..")
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub DrpSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim DrpS As DropDownList = CType(DgObjections.Items(0).Controls(1).FindControl("DrpSubject"), DropDownList)
            Dim DrpSV As Integer = DrpS.SelectedItem.Value

            SqlStr = "SELECT SUBJECTS,QFROM,QTO FROM OBJECTIONS_EXAM_DATE_MAP WHERE OBJTESTSLNO=" & DrpED.SelectedItem.Value
            objWSCombo = New Utility
            DsSplit = objWSCombo.DataSet_OneFetch(SqlStr)

            SplitStr = DsSplit.Tables(0).Rows(0).Item(0).ToString
            StrSplitStr = SplitStr.Split(",")
            For i = 0 To StrSplitStr.Length - 1
                StrSplitData += StrSplitStr(i).ToString + IIf(StrSplitStr.Length - 1 <> i, ",", "")
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrpEN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpEN.SelectedIndexChanged
        Try
            FillExamDate()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrpED_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpED.SelectedIndexChanged
        Try
            FillEmptyGrid()
            FillDrpSubject()
        Catch ex As Exception

        End Try
    End Sub

End Class

