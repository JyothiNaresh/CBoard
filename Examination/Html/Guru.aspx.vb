Imports System.IO
Imports System.Threading
Imports System.Text
Imports CollegeBoardDLL
Imports System.Math

Public Class Guru
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents HtmlTable As System.Web.UI.WebControls.Table

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
    Private ObjResult As Utility
    Dim SqlStr As String
    Dim DsResult As DataSet
    Dim dvresult As New DataView
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SqlStr = "SELECT BRANCHSLNO,DISTRICTSLNO,COMACADEMICSLNO,COUNT(ADMSLNO) STN FROM T_ADM_DT WHERE STATUS=1 AND BRANCHSLNO IN(101,102,103) GROUP BY BRANCHSLNO,DISTRICTSLNO,COMACADEMICSLNO"
        ObjResult = New Utility
        DsResult = ObjResult.DataSet_OneFetch(SqlStr)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        HtmlTable.Visible = True
        Dim I As Integer
        Dim slno As Integer = 1
        Dim TRow1 As New TableRow
        TRow1.Cells.Add(Headingstyle("Sl.No.", 1))
        TRow1.Cells.Add(Headingstyle("BRANCHSLNO", 1))
        TRow1.Cells.Add(Headingstyle("DISTRICTSLNO", 1))
        TRow1.Cells.Add(Headingstyle("COMACADEMICSLNO", 1))
        TRow1.Cells.Add(Headingstyle("STRENGTH", 2))
        HtmlTable.Rows.Add(TRow1)
        For I = 0 To DsResult.Tables(0).Rows.Count - 1
            Dim Trow As New TableRow
            Trow.Cells.Add(Enteredstyle(slno, 1, "Guru"))
            Trow.Cells.Add(Enteredstyle(DsResult.Tables(0).Rows(I)("BRANCHSLNO").ToString, 1, "Branchslno"))
            Trow.Cells.Add(Enteredstyle(DsResult.Tables(0).Rows(I)("DISTRICTSLNO").ToString, 1, "dISTRICT"))
            Trow.Cells.Add(Enteredstyle(DsResult.Tables(0).Rows(I)("COMACADEMICSLNO").ToString, 1, "COMACADMIS"))
            Trow.Cells.Add(Enteredstyle(DsResult.Tables(0).Rows(I)("STN").ToString, 1, "Branchslno"))
            Trow.Cells.Add(Enteredstyle(DsResult.Tables(0).Rows(I)("STN").ToString, 1, "Branchslno"))
            HtmlTable.Rows.Add(Trow)
        Next

    End Sub
End Class
