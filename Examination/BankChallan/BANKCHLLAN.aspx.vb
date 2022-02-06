Imports System.Data.OracleClient
Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.CrystalReports
Imports System.IO
Imports System.Web.Services.Protocols
Imports CollegeBoardDLL
Imports CommonDLL
Imports System.Math
Public Class BANKCHLLAN
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents iBtnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents RbtnAxis As System.Web.UI.WebControls.RadioButton
    Protected WithEvents RbtnICICI As System.Web.UI.WebControls.RadioButton

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

    Dim EXP As ExportOptions
    Dim FILESTR As New DiskFileDestinationOptions
    Private ObjResult As Utility
    Public From As String
    Private DsSearch, DsResult As DataSet
    Public PageIndex As Integer
    Private FormName As String = "Form1"
    Dim ObjReport As ClsBankChallan

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

#Region " METHODS"

    Private Function FormValidations() As Boolean
        Try
            If RbtnAxis.Checked = False AndAlso RbtnICICI.Checked = False Then
                StartUpScript(RbtnAxis.ClientID, "Select Atleast One Bank .")
                Return False
            End If
            Return True

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

#Region "Sql Query"

    Private Sub GenerateSqlQuery()
        Try
            Dim CMD As OracleCommand
            Dim ADP As OracleDataAdapter
            Dim SqlStr, SqlStr1 As String
            Dim I As Integer

            ObjResult = New Utility

            'DsResult = ObjResult.DataSet_Fetch(SqlStr)
            'Me.ViewState("DsResult") = DsResult

            SqlStr = "SELECT '711010001' ADMNO, 'STUDENT NAME' STUNAME, 'FATHER NAME' FNAME,'JUNIOR-SECTION' COURSE,'2012-13' YEAR FROM DUAL"
            CMD.CommandText = SqlStr
            ADP.SelectCommand = CMD
            ADP.Fill(DsResult, "BANKSTUDENT")


        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)
            StartUpScript("", " Transaction  Failed ")

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)
            StartUpScript("", " Transaction  Failed ")

        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
            StartUpScript("", " Transaction  Failed ")


        End Try
    End Sub

#End Region

#Region " IMAGE BUTTONS"

    Private Sub iBtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnGo.Click
        Dim pgm As PageMargins
        Dim eo As ExportOptions
        Dim dfile As New DiskFileDestinationOptions
        Dim cr As BANKSTUDENTCHALLAN
        Dim cr1 As ICICIBANKCHALLAN

        Try
            If Not FormValidations() Then Exit Sub

            DsResult = New DataSet
            ObjReport = New ClsBankChallan
            DsResult = ObjReport.BANKCHALLAN()
            If DsResult.Tables(0).Rows.Count > 0 Then

                If RbtnAxis.Checked = True AndAlso RbtnICICI.Checked = False Then
                    cr = New BANKSTUDENTCHALLAN
                    cr.SetDataSource(DsResult)
                    pgm = cr.PrintOptions.PageMargins
                    pgm.leftMargin = 5
                    pgm.rightMargin = 2
                    cr.PrintOptions.ApplyPageMargins(pgm)
                    eo = cr.ExportOptions
                    eo.ExportFormatType = ExportFormatType.PortableDocFormat
                    eo.UExportDestinationType = ExportDestinationType.DiskFile

                    If Not Directory.Exists(Server.MapPath(Request.ApplicationPath) & "/BankChallan/AXISBANK/") Then
                        Directory.CreateDirectory(Server.MapPath(Request.ApplicationPath) & "/BankChallan/AXISBANK/")
                    End If

                    dfile.DiskFileName = "C:\Inetpub\wwwroot\CollegeBoard\Examination\BankChallan\AXISBANK\AXISBANKCHALLAN.PDF"
                    eo.DestinationOptions = dfile
                    cr.Export()
                    Response.Clear()
                    'Response.Redirect("AXISBANKCHALLAN.pdf")
                    Response.Redirect("../BankChallan/AXISBANK/AXISBANKCHALLAN.PDF", False)

                ElseIf RbtnAxis.Checked = False AndAlso RbtnICICI.Checked = True Then
                    cr1 = New ICICIBANKCHALLAN
                    cr1.SetDataSource(DsResult)
                    pgm = cr1.PrintOptions.PageMargins
                    pgm.leftMargin = 5
                    pgm.rightMargin = 2
                    cr1.PrintOptions.ApplyPageMargins(pgm)
                    eo = cr1.ExportOptions
                    eo.ExportFormatType = ExportFormatType.PortableDocFormat
                    eo.UExportDestinationType = ExportDestinationType.DiskFile

                    If Not Directory.Exists(Server.MapPath(Request.ApplicationPath) & "/BankChallan/ICICIBANK/") Then
                        Directory.CreateDirectory(Server.MapPath(Request.ApplicationPath) & "/BankChallan/ICICIBANK/")
                    End If

                    dfile.DiskFileName = "C:\Inetpub\wwwroot\CollegeBoard\Examination\BankChallan\ICICIBANK\ICICIBANKCHALLAN.PDF"
                    eo.DestinationOptions = dfile
                    cr1.Export()
                    Response.Clear()
                    'Response.Redirect("ICICIBANKCHALLAN.pdf")
                    Response.Redirect("../BankChallan/ICICIBANK/ICICIBANKCHALLAN.PDF", False)

                End If



            Else
                StartUpScript("", "No Data")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

   
End Class
