Imports System.Data.OracleClient
Imports CollegeBoardDLL

Public Class ReportMainSelection
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents LblRptType As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents SelectionRow As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents LblSel As System.Web.UI.WebControls.Label
    Protected WithEvents LblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblFilter As System.Web.UI.WebControls.Label
    Protected WithEvents BtnSelection As System.Web.UI.WebControls.Button

    Public WithEvents DrpFilter As System.Web.UI.WebControls.DropDownList
    Public WithEvents DrpSelection As System.Web.UI.WebControls.DropDownList
    Public WithEvents ChkLstSel As System.Web.UI.WebControls.CheckBoxList
    Public WithEvents DrpFilterItems As System.Web.UI.WebControls.DropDownList


    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " CODE "

#Region "Class Variables"
    Private ObjResult As ClsFillControls

#End Region

#Region " On Load"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'ChkLstSel.Attributes.Add("onclick", "ChangeCheckBox();")

        

        Try
            If Not IsPostBack Then
                FillReportType()
                FillFilterType()
                ChkLstSel.Visible = False
            End If
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " Filling Methods"

    Private Sub FillReportType()

        Dim Ds As New DataSet
        ObjResult = New ClsFillControls
        Ds = ObjResult.MainSelection_Fetch(1)

        DrpSelection.DataSource = Ds
        DrpSelection.DataValueField = "SLNO"
        DrpSelection.DataTextField = "NAME"
        DrpSelection.DataBind()
        'Me.ViewState("PDs") = Ds
        'Session("DrpRptVal") = DrpSelection.SelectedValue

    End Sub

    Private Sub FillFilterType()

        Dim Ds As New DataSet
        ObjResult = New ClsFillControls
        Ds = ObjResult.MainSelection_Fetch(1)

        DrpFilter.DataSource = Ds
        DrpFilter.DataValueField = "SLNO"
        DrpFilter.DataTextField = "NAME"
        DrpFilter.DataBind()
        'Me.ViewState("PDs") = Ds
        'Session("DrpRptVal") = DrpSelection.SelectedValue

    End Sub

    Private Sub FillFilterItems()
        Dim Ds As New DataSet
        ObjResult = New ClsFillControls
        Ds = ObjResult.FilterSelection_Fetch(Val(DrpFilter.SelectedItem.Value))

        ChkLstSel.DataSource = Ds
        ChkLstSel.DataValueField = "SLNO"
        ChkLstSel.DataTextField = "NAME"
        ChkLstSel.DataBind()

    End Sub
#End Region


#Region "Dropdown Selected Changed events"

    Private Sub DrpFilterItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            If DrpFilterItems.SelectedValue = 2 Then
                ChkLstSel.Visible = True
                FillFilterItems()
                SelectionRow.Visible = True
                BtnSelection.Text = "Selection Hide"
                LblSel.Text = DrpFilter.SelectedItem.Text + " ==> "
            Else
                ChkLstSel.Visible = False
                LblSel.Text = DrpFilter.SelectedItem.Text + " ==> All"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrpFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            lblFilter.Text = StrConv(DrpFilter.SelectedItem.Text, VbStrConv.ProperCase)
            If DrpFilterItems.SelectedValue = 2 Then
                ChkLstSel.Visible = True
                FillFilterItems()
                SelectionRow.Visible = True
                BtnSelection.Text = "Selection Hide"
                LblSel.Text = DrpFilter.SelectedItem.Text + " ==> "
            Else
                ChkLstSel.Visible = False
                LblSel.Text = DrpFilter.SelectedItem.Text + " ==> All"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkLstSel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrpSelection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            RaiseEvent DrpSelection_SelIndChg(sender, e)
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Events"

    Public Event DrpSelection_SelIndChg(ByVal sender As Object, ByVal e As System.EventArgs)

#End Region

#Region "Button Click "

    Private Sub BtnSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelection.Click
        Try

            If SelectionRow.Visible Then
                SelectionRow.Visible = False
                BtnSelection.Text = "Selection Show"
            Else
                SelectionRow.Visible = True
                BtnSelection.Text = "Selection Hide"
            End If
            If DrpFilterItems.SelectedValue = 2 Then

                Dim Selstr As String = ""
                For i As Integer = 0 To ChkLstSel.Items.Count - 1
                    If ChkLstSel.Items(i).Selected Then
                        Selstr = Selstr + ChkLstSel.Items(i).Text + "; "
                    End If
                    'ChkLstSel.Items(i).Attributes()
                Next
                LblSel.Text = DrpFilter.SelectedItem.Text + " ==> " + Selstr
            End If


        Catch ex As Exception

        End Try
    End Sub

#End Region

#End Region

End Class
