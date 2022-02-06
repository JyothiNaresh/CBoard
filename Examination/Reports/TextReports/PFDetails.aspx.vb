'Author : P.Venu
Imports System.IO
Imports System.Text
Public Class PFDetails
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DgDetails As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Table2 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " Class Variables"

    'ViewState Variables
    ' PFAnal
    Dim ExSlno, EbSlno, CVal, i, j, DetTrgt As Integer : Dim ResType, DvSort, StrRepFilt As String
    Dim DivSlno As Integer : Dim FiltStr As String

    'Session Datasets
    ' PFAnal
    Dim DsResult, DsNcNe, MyDsNENC, DsStudents As DataSet
    Dim MyDtView As DataView

    'General
    Dim Rtype As String ' Get Report 
    Dim FiltStrng As String
    Dim Ln As Integer

#End Region

#Region " Page_Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
            GetReport()
        End If
    End Sub

#End Region

#Region " Common_Methods"

    Private Sub GetReport()
        Try
            Rtype = Session("Rtype")

            If Rtype = "PFDet" Then ' PassFail Anlaysis 
                Table2.Visible = False
                FillGrid()
            ElseIf Rtype = "TrgtDet" Then ' Target99 Details
                Table2.Visible = False
                FillGridTarget()
            ElseIf Rtype = "FixedSecSubMap" Then
                Table2.Visible = True
                FillGridFixedSbSec()
            ElseIf Rtype = "EstRchdPrmtd" Then
                Table2.Visible = False
                FillGridEstRchdPrmtd()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillGrid()
        Try
            If Not Request.QueryString("EbSlno") Is Nothing AndAlso Request.QueryString("EbSlno") <> "" Then EbSlno = CInt(Request.QueryString("EbSlno"))
            
            DsStudents = Session("DsStudents")
            If EbSlno > 0 Then
                MyDtView = New DataView(DsStudents.Tables(1))
                MyDtView.RowFilter = "EXAMBRANCHSLNO='" & EbSlno & "'"
                Dim ColName As String
                For i = 0 To MyDtView.Table.Columns.Count - 1
                    If MyDtView.Table.Columns(i).ColumnName = "EXAMBRANCHSLNO" Or MyDtView.Table.Columns(i).ColumnName = "ADMSLNO" Or MyDtView.Table.Columns(i).ColumnName = "EXAMBRANCHNAME" Then
                    Else
                        j += 1
                        ColName = MyDtView.Table.Columns(i).ColumnName.ToString
                        Dim Col As BoundColumn = New BoundColumn
                        If ColName = "EXAMBRANCHNAME" Or ColName = "ADMNO" Or ColName = "NAME" Or ColName = "COURSE" Or ColName = "PAIDPER" Then
                            Col.HeaderText = ColName
                            Col.DataField = ColName
                            Col.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                        Else
                            Col.HeaderText = Left(ColName, 3)
                            Col.DataField = ColName
                            Col.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                        End If
                        DgDetails.Columns.Add(Col)
                        DgDetails.Columns(j).ItemStyle.Wrap = False
                        DvSort = "ADMNO ASC"
                    End If
                Next
                MyDtView.Sort = DvSort
                DgDetails.DataSource = MyDtView
                DgDetails.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub ' PassFailAnlaysis 

    Private Sub FillGridTarget()
        Try

            If Not Request.QueryString("ExSlno") Is Nothing AndAlso Request.QueryString("ExSlno") <> "" Then ExSlno = CInt(Request.QueryString("ExSlno"))
            If Not Request.QueryString("DivSlno") Is Nothing AndAlso Request.QueryString("DivSlno") <> "" Then DivSlno = CInt(Request.QueryString("DivSlno"))
            If Not Request.QueryString("EbSlno") Is Nothing AndAlso Request.QueryString("EbSlno") <> "" Then EbSlno = CInt(Request.QueryString("EbSlno"))
            If Not Request.QueryString("FiltStr") Is Nothing AndAlso Request.QueryString("FiltStr") <> "" Then FiltStr = Request.QueryString("FiltStr")
            If Not Request.QueryString("DetTrgt") Is Nothing AndAlso Request.QueryString("DetTrgt") <> "" Then DetTrgt = CInt(Request.QueryString("DetTrgt"))

            DsResult = Session("DsResult")
            MyDtView = New DataView(DsResult.Tables(1)) 'Target Details

            If ExSlno <> 1 Then
                FiltStrng = "DEXAMSLNO='" & ExSlno & "' AND "
            End If

            If DivSlno > 0 Then
                FiltStrng += "EXAMREGIONSLNO='" & DivSlno & "' AND "
            End If

            If EbSlno > 0 Then
                FiltStrng += "EXAMBRANCHSLNO='" & EbSlno & "' AND "
            End If

            If FiltStr.Length > 0 Then
                FiltStrng += FiltStr
            End If

            FiltStrng = FiltStrng.TrimEnd(" AND ")

            MyDtView.RowFilter = FiltStrng
            Dim ColName As String
            For i = 0 To MyDtView.Table.Columns.Count - 1
                If MyDtView.Table.Columns(i).ColumnName = "EXAMBRANCHSLNO" Or MyDtView.Table.Columns(i).ColumnName = "EXAMREGIONSLNO" Or MyDtView.Table.Columns(i).ColumnName = "DEXAMSLNO" Or MyDtView.Table.Columns(i).ColumnName = "UNIQUENO" Or MyDtView.Table.Columns(i).ColumnName = "ISTARGET" Or MyDtView.Table.Columns(i).ColumnName = "TRGT" Or MyDtView.Table.Columns(i).ColumnName = "TRGT1" Or MyDtView.Table.Columns(i).ColumnName = "ISTARGET1" Then
                Else
                    j += 1
                    ColName = MyDtView.Table.Columns(i).ColumnName.ToString
                    Dim Col As BoundColumn = New BoundColumn
                    Col.HeaderText = ColName
                    Col.DataField = ColName
                    Col.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    DgDetails.Columns.Add(Col)
                    DgDetails.Columns(j).ItemStyle.Wrap = False
                End If
            Next
            DvSort = "DIFF DESC"
            MyDtView.Sort = DvSort
            DgDetails.DataSource = MyDtView
            DgDetails.DataBind()
            For i = 0 To DgDetails.Items.Count - 1
                If DgDetails.Items(i).Cells(4).Text < DetTrgt Then
                    'DgDetails.Items(i).Cells(4).Attributes.Add("ForeColor", "Red")
                    DgDetails.Items(i).Cells(4).ForeColor = Color.Red
                ElseIf DgDetails.Items(i).Cells(5).Text >= 0 Then
                    'DgDetails.Items(i).Cells(4).Attributes.Add("ForeColor", "Green")
                    DgDetails.Items(i).Cells(4).ForeColor = Color.Green
                ElseIf DgDetails.Items(i).Cells(4).Text >= DetTrgt And DgDetails.Items(i).Cells(5).Text < 0 Then
                    DgDetails.Items(i).Cells(4).Attributes.Add("ForeColor", "Blue")
                    DgDetails.Items(i).Cells(4).ForeColor = Color.Blue
                End If
                DgDetails.Items(i).Cells(4).Font.Bold = True
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub ' Target99 Details

    Private Sub FillGridFixedSbSec()
        Try
            DsResult = Session("DsResult")
            MyDtView = New DataView(DsResult.Tables(0)) '

            MyDtView.RowFilter = FiltStrng
            Dim ColName As String
            For i = 0 To MyDtView.Table.Columns.Count - 1
                j += 1
                ColName = MyDtView.Table.Columns(i).ColumnName.ToString
                Dim Col As BoundColumn = New BoundColumn
                Col.HeaderText = ColName
                Col.DataField = ColName
                If j > 1 Then
                    Col.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                Else
                    Col.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                End If
                DgDetails.Columns.Add(Col)
                DgDetails.Columns(j).ItemStyle.Wrap = False
            Next
            DgDetails.DataSource = MyDtView
            DgDetails.DataBind()
            For i = 0 To DgDetails.Items.Count - 1
                For j = 0 To DgDetails.Items(i).Cells.Count - 1
                    If j > 1 Then
                        DgDetails.Items(i).Cells(j).ForeColor = Color.Blue
                        DgDetails.Items(i).Cells(j).Font.Bold = True
                    End If
                Next
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub ' FixedStrenght Subbatch Section

    Private Sub FillGridEstRchdPrmtd()
        Try
            Dim Ds_Level5, Ds_Level4, Ds_Level3, Ds_Level2, Ds_Level1, Ds_ExamBranch As DataSet
            Ds_Level1 = Session("Ds_Level1")
            Ds_Level2 = Session("Ds_Level2")
            Ds_Level3 = Session("Ds_Level3")
            Ds_Level4 = Session("Ds_Level4")
            Ds_Level5 = Session("Ds_Level5")

            Dim StrSB, StrLv, StrEb As String
            Dim StrEA As Integer

            If Not Request.QueryString("StrLv") Is Nothing AndAlso Request.QueryString("StrLv") <> "" Then StrLv = CInt(Request.QueryString("StrLv"))
            If Not Request.QueryString("StrEb") Is Nothing AndAlso Request.QueryString("StrEb") <> "" Then StrEb = CInt(Request.QueryString("StrEb"))
            If Not Request.QueryString("StrSB") Is Nothing AndAlso Request.QueryString("StrSB") <> "" Then StrSB = Request.QueryString("StrSB")

            If Not Request.QueryString("StrEA") Is Nothing AndAlso Request.QueryString("StrEA") <> "" Then StrEA = CInt(Request.QueryString("StrEA"))
            'If Not Request.QueryString("ResType") Is Nothing AndAlso Request.QueryString("ResType") <> "" Then ResType = Request.QueryString("ResType")

            If StrEb <> "" Then
                FiltStr = "EXAMBRANCHSLNO=" & StrEb
            End If
            If StrSB <> "" Then
                If FiltStr <> "" Then
                    FiltStr = FiltStr + " AND SBNAME<>'" & StrSB & "'"
                Else
                    FiltStr = "SBNAME<>'" & StrSB & "'"
                End If
            End If

            If StrEA > 0 Then
                If FiltStr <> "" Then
                    FiltStr = FiltStr + " AND EAVGTOTAL>=" & StrEA.ToString
                Else
                    FiltStr = "EAVGTOTAL>=" & StrEA.ToString
                End If
            End If

            If StrLv = 1 Then
                MyDtView = New DataView(Ds_Level1.Tables(3))
                MyDtView.RowFilter = FiltStr
            ElseIf StrLv = 2 Then
                MyDtView = New DataView(Ds_Level2.Tables(3))
                MyDtView.RowFilter = FiltStr
            ElseIf StrLv = 3 Then
                MyDtView = New DataView(Ds_Level3.Tables(3))
                MyDtView.RowFilter = FiltStr
            ElseIf StrLv = 4 Then
                MyDtView = New DataView(Ds_Level4.Tables(3))
                MyDtView.RowFilter = FiltStr
            ElseIf StrLv = 5 Then
                MyDtView = New DataView(Ds_Level5.Tables(3))
                MyDtView.RowFilter = FiltStr
            End If

            Dim ColName As String
            For i = 0 To MyDtView.Table.Columns.Count - 1
                j += 1
                ColName = MyDtView.Table.Columns(i).ColumnName.ToString

                If ColName = "SBNAME" Or ColName = "ADMNO" Or ColName = "NAME" Or ColName = "TOTALMARKS" Or ColName = "EAVGTOTAL" Then
                    Dim Col As BoundColumn = New BoundColumn
                    Col.HeaderText = ColName
                    Col.DataField = ColName
                    If j > 1 Then
                        Col.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                    Else
                        Col.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    End If
                    DgDetails.Columns.Add(Col)
                    'DgDetails.Columns(j).ItemStyle.Wrap = False
                End If
            Next
            DgDetails.DataSource = MyDtView
            DgDetails.DataBind()
            For i = 0 To DgDetails.Items.Count - 1
                For j = 0 To DgDetails.Items(i).Cells.Count - 1
                    If j > 1 Then
                        DgDetails.Items(i).Cells(j).ForeColor = Color.Blue
                        DgDetails.Items(i).Cells(j).Font.Bold = True
                    End If
                Next
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub ' EstimatedAvg Reached Promoted

#End Region

#Region "Rough"

        'Private Sub TableHeader(ByRef sb As StringBuilder, ByRef dt As DataTable)
        '    Dim sbRows As New StringBuilder
        '    With sb
        '        .Append("<TR class=""head"">")
        '        sbRows.Append("<TR class=""head"">")
        '        For i As Integer = 0 To dt.Columns.Count - 3
        '            If i = 0 Then
        '                sbRows.Append("<TD align=""center"" style=""BORDER-RIGHT: black 1px solid; FONT-WEIGHT: bold; BORDER-BOTTOM: black 1px solid"">")
        '            Else
        '                sbRows.Append("<TD style=""BORDER-RIGHT: black 1px solid; FONT-WEIGHT: bold; BORDER-BOTTOM: black 1px solid"">")
        '            End If
        '            sbRows.Append(String.Format("{0}</TD>", dt.Columns(i).ColumnName))
        '        Next
        '        sbRows.Append("</TR>")
        '        .Append("</TR>")
        '    End With
        '    sb.Append(sbRows.ToString)
        'End Sub

        'Private Sub TableItems(ByRef sb As StringBuilder, ByVal CellData As String, ByVal Colnum As Integer)
        '    If sb Is Nothing Then
        '        Throw New ApplicationException("String builder is nothing")
        '    End If
        '    With sb
        '        '.Append("<TD>")
        '        If Colnum = 0 Then
        '            .Append("<TD align=""center"" style=""BORDER-RIGHT: black 1px solid;  FONT-WEIGHT: bold; BORDER-BOTTOM: black 1px solid"">")
        '        Else
        '            .Append("<TD style=""BORDER-RIGHT: black 1px solid;  FONT-WEIGHT: bold; BORDER-BOTTOM: black 1px solid"">")
        '        End If
        '        .Append(String.Format("{0}", CellData))
        '        .Append("</TD>")
        '    End With
        'End Sub

        'Private Sub FillGrid1(ByVal Dv As DataView)
        '    Try

        '        If Dv.Count > 0 Then
        '            Placeholder2.Controls.Clear()
        '            Dim sbPart2 As New StringBuilder
        '            TableHeader(sbPart2, SelExDt)
        '            For Each dr As DataRow In Dv.rows
        '                With sbPart2
        '                    .Append(String.Format("<TR class=""{0}"">", ""))
        '                    For i As Integer = 0 To SelExDt.Columns.Count - 3
        '                        TableItems(sbPart2, dr(i).ToString, i)
        '                    Next
        '                    .Append("</TR>")
        '                End With
        '            Next
        '            Placeholder2.Controls.Add(New LiteralControl(sbPart2.ToString))
        '        End If
        '    Catch ex As Exception
        '        StartUpScript("", "DgFill : " + ex.Message)
        '    End Try

        'End Sub

#End Region

End Class
