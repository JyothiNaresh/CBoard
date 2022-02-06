'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : User Control Report Type and Region,Zone,Vc,Do Selection.
'   ACTIVITY                          : New/Edit
'   AUTHOR                            : Hemanth
'   INITIAL BASELINE DATE             : 20-JUN-2010
'   FINAL BASELINE DATE               : 20-JUN-2010
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------

Imports System.Data
Imports System.Data.OracleClient
Imports CollegeBoardDLL


Public Class VcDoZoneRegionSelection
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents drpReportType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rdbRegion As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdbZone As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdbDos As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdbVC As System.Web.UI.WebControls.RadioButton
    Protected WithEvents lblRZ As System.Web.UI.WebControls.Label
    Protected WithEvents drpRZ As System.Web.UI.WebControls.DropDownList
    Protected WithEvents LblRptType As System.Web.UI.WebControls.Label
    Protected WithEvents Chkcommon As System.Web.UI.WebControls.CheckBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Code"

#Region "Class Variables"
    Private ObjResult As ClsFillControls
    Private ObjR As Utility
    Private m_minValue As Integer = 0
    Private m_maxValue As Integer = 100
    Private m_currentNumber As Integer = 0
    Private RefTblName As String
    Private PDs As DataSet
    Dim DrpRptVal, DrpRzval As String
    Dim Rdbtn As Integer
    Public ChkCom As Integer

#End Region

#Region "Fill Methods"

    Private Sub FillReportType()

        Dim Ds As New DataSet
        ObjResult = New ClsFillControls
        Ds = ObjResult.ReportType_Fetch(1)

        drpReportType.DataSource = Ds
        drpReportType.DataValueField = "SLNO"
        drpReportType.DataTextField = "NAME"
        drpReportType.DataBind()
        Me.ViewState("PDs") = Ds
        Session("DrpRptVal") = drpReportType.SelectedValue

    End Sub

    Private Sub Region_Zone_Fill()
        Dim dsERZ As DataSet
        ObjResult = New ClsFillControls
        If rdbRegion.Checked Then   '''THIS FOR REGION SELECT
            dsERZ = ObjResult.Exam_UserWise_RepType(Session("USERSLNO"), Session("COMACADEMICSLNO"), 1)
            lblRZ.Text = vbCr & vbCr & vbCr & vbCr & "Region"
            drpRZ.DataSource = dsERZ
            drpRZ.DataTextField = "NAME"
            drpRZ.DataValueField = "SLNO"
            drpRZ.DataBind()
            drpRZ.Items.Insert(0, New ListItem("All", 0))
            Session("rdbbtn") = 1
            Session("DrpRzval") = drpRZ.SelectedValue
        ElseIf rdbZone.Checked Then '''THIS FOR ZONE SELECT

            dsERZ = ObjResult.Exam_UserWise_RepType(Session("USERSLNO"), Session("COMACADEMICSLNO"), 2)
            lblRZ.Text = vbCr & vbCr & vbCr & vbCr & vbCr & vbCr & "Zone"
            drpRZ.DataSource = dsERZ
            drpRZ.DataTextField = "NAME"
            drpRZ.DataValueField = "SLNO"
            drpRZ.DataBind()
            drpRZ.Items.Insert(0, New ListItem("All", 0))
            Session("rdbbtn") = 2
            Session("DrpRzval") = drpRZ.SelectedValue

        ElseIf rdbDos.Checked Then '''THIS FOR D.Os SELECT

            dsERZ = ObjResult.Exam_UserWise_RepType(Session("USERSLNO"), Session("COMACADEMICSLNO"), 3)
            lblRZ.Text = vbCr & vbCr & vbCr & vbCr & vbCr & vbCr & "D.Os"
            drpRZ.DataSource = dsERZ
            drpRZ.DataTextField = "NAME"
            drpRZ.DataValueField = "SLNO"
            drpRZ.DataBind()
            drpRZ.Items.Insert(0, New ListItem("All", 0))
            Session("rdbbtn") = 3
            Session("DrpRzval") = drpRZ.SelectedValue

        ElseIf rdbVC.Checked Then '''THIS FOR V.Cs SELECT

            dsERZ = ObjResult.Exam_UserWise_RepType(Session("USERSLNO"), Session("COMACADEMICSLNO"), 4)
            lblRZ.Text = vbCr & vbCr & vbCr & vbCr & vbCr & vbCr & "V.C."
            drpRZ.DataSource = dsERZ
            drpRZ.DataTextField = "NAME"
            drpRZ.DataValueField = "SLNO"
            drpRZ.DataBind()
            drpRZ.Items.Insert(0, New ListItem("All", 0))
            Session("rdbbtn") = 4
            Session("DrpRzval") = drpRZ.SelectedValue
        End If

      


    End Sub

#End Region

#Region "Page Load Event"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            If Not IsPostBack Then
                FillReportType()
                drpRZ.Enabled = True
                rdbDos.Enabled = True
                rdbZone.Enabled = True
                rdbVC.Enabled = True
                rdbRegion.Enabled = True
                Region_Zone_Fill()
            End If
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "SelectedIndex Changed Events"

    Private Sub drpReportType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpReportType.SelectedIndexChanged
        PDs = Me.ViewState("PDs")

        If drpReportType.SelectedValue <> 1 Then
            drpRZ.Enabled = False
            rdbDos.Enabled = False
            rdbZone.Enabled = False
            rdbVC.Enabled = False
            rdbRegion.Enabled = False
        Else
            drpRZ.Enabled = True
            rdbDos.Enabled = True
            rdbZone.Enabled = True
            rdbVC.Enabled = True
            rdbRegion.Enabled = True
        End If
        RefTblName = PDs.Tables(0).Rows(drpReportType.SelectedIndex)("REFTBLNAME").ToString
        Region_Zone_Fill()
        Session("DrpRptVal") = drpReportType.SelectedValue
        RaiseEvent DrpRptType_SelIndChg(sender, e)

    End Sub

    Private Sub drpRZ_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpRZ.SelectedIndexChanged
        Session("DrpRzval") = drpRZ.SelectedValue
        RaiseEvent drpRZ_SelIndChg(sender, e)
    End Sub

#End Region

#Region "Checked Changed Events"

    Private Sub rdbRegion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbRegion.CheckedChanged
        Region_Zone_Fill()
        RaiseEvent drpRZ_SelIndChg(sender, e)

    End Sub

    Private Sub rdbZone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbZone.CheckedChanged

        Region_Zone_Fill()
        RaiseEvent drpRZ_SelIndChg(sender, e)

    End Sub

    Private Sub rdbDos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDos.CheckedChanged

        Region_Zone_Fill()
        RaiseEvent drpRZ_SelIndChg(sender, e)

    End Sub

    Private Sub rdbVC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbVC.CheckedChanged

        Region_Zone_Fill()
        RaiseEvent drpRZ_SelIndChg(sender, e)

    End Sub

    Private Sub ChkCommon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chkcommon.CheckedChanged
        Try
            If Chkcommon.Checked = True Then
                ChkCom = 1
            Else
                ChkCom = 0
            End If
            Session("Chkcom") = ChkCom
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Events"

    Public Event DrpRptType_SelIndChg(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Event drpRZ_SelIndChg(ByVal sender As Object, ByVal e As System.EventArgs)

#End Region

#End Region


End Class
