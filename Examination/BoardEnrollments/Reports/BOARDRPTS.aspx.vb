'   OBJECTIVE                         : This is the College Informatin Details .
'   AUTHOR                            : G.KISHORE
'   INITIAL BASELINE DATE             : 21-JAN-2013
'   MODIFICATIONS LOG                 : NILL
'----------------------------------------------------------------------------------------------
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
Imports System.TypeLoadException
Imports System
Public Class BOARDRPTS
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Txtccode As System.Web.UI.WebControls.TextBox
    Protected WithEvents ImgCCode As System.Web.UI.WebControls.ImageButton
    Protected WithEvents rdbAffil As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdbcert As System.Web.UI.WebControls.RadioButton
    Protected WithEvents TblBrdRpt As System.Web.UI.WebControls.Table

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

    Private objBoardEnrollment As ClsBoardEnrollment
    Dim EXP As ExportOptions
    Dim FILESTR As New DiskFileDestinationOptions
    Private ObjResult As Utility
    Public From As String
    Private DsSearch, DsResult As DataSet
    Public PageIndex As Integer
    Private FormName As String = "Form1"
    Dim ObjReport As New ClsBankChallan
    Private DsSearchResult As DataSet
    Dim USERSLNO As Integer
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

    Private Sub fillBoardDist()
        Try
            Dim DS As DataSet

            ObjResult = New Utility

            DS = ObjResult.DataSet_OneFetch("SELECT BOARDDISTSLNO SLNO,NAME FROM EXAM_BOARDDIST_MT ORDER BY NAME")

            'DrpBoardDist.DataSource = DS.Tables(0)
            'DrpBoardDist.DataTextField = "NAME"
            'DrpBoardDist.DataValueField = "SLNO"
            'DrpBoardDist.DataBind()
            'DrpBoardDist.Items.Insert(0, New ListItem("ALL", 0))

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fillBoardDist1()

        objBoardEnrollment = New ClsBoardEnrollment

        DsSearchResult = objBoardEnrollment.Masters_Selectall(1)
        'DrpBoardDist.DataSource = DsSearchResult.Tables(0)
        'DrpBoardDist.DataTextField = "NAME"
        'DrpBoardDist.DataValueField = "BOARDDISTSLNO"
        'DrpBoardDist.DataBind()
        'DrpBoardDist.Items.Insert(0, New ListItem("Select", 0))

    End Sub

    Private Sub FillFDRS()

        Dim SqlStr As String

        Try

            SqlStr = "SELECT FDRNO,AMOUNT,FDRDATE,MATURITY_DATE,RELEASEDATE FROM M_FDR_DT "

            ObjResult = New Utility

            DsSearch = ObjResult.GetCommDataSet(SqlStr)
            '
            '  ChkFDRS.Items.Clear()
            If DsSearch.Tables(0).Rows.Count > 0 Then

                ' ChkFDRS.DataSource = DsSearch.Tables(0).Columns

                ' ChkFDRS.DataTextField = "ColumnNAME"
                'ChkFDRS.DataValueField = "SLNO"
                ' ChkFDRS.DataBind()


                'Dim i, J As Integer
                'If DSet.Tables(0).Rows.Count > 0 Then

                'For J = 0 To DsSearch.Tables(0).Rows.Count - 1
                '    For i = 0 To ChkFDRS.Items.Count - 1
                '        If Val(ChkFDRS.Items(i).Value) = Val(DsSearch.Tables(0).Rows(J)("SLNO")) And Val(DsSearch.Tables(0).Rows(J)("MAPSLNO")) > 0 Then
                '            ChkFDRS.Items(i).Selected = True
                '        End If
                '    Next
                'Next

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function FormValidations() As Boolean
        Try
            'If Trim(Txtccode.Text) = "" AndAlso Trim(Txtccode.Text) Is Nothing AndAlso DrpBoardDist.SelectedItem.Text = "Select" Then
            '    StartUpScript("", "Enter College Code. Or Select Board Dist.")
            '    Return False

            '    'ElseIf DrpBoardDist.SelectedItem.Text = "Select" Then
            '    '    StartUpScript(DrpBoardDist.ID, "Select Board Dist.")
            '    '    Return False



            'End If
            'Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

#Region " IMAGE BUTTONS"

    Private Sub chkStatus1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Dim i As Integer
            'If Not ChkFDRS Is Nothing AndAlso ChkFDRS.Items.Count > 0 Then
            '    If chkStatus1.Checked Then
            '        For i = 0 To ChkFDRS.Items.Count - 1
            '            ChkFDRS.Items(i).Selected = True
            '        Next
            '    Else
            '        For i = 0 To ChkFDRS.Items.Count - 1
            '            ChkFDRS.Items(i).Selected = False
            '        Next

            '    End If


            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub imgBtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim pgm As PageMargins
        Dim eo As ExportOptions
        Dim dfile As New DiskFileDestinationOptions
        Dim cr As BOARDRPT
        Dim cr3 As BOARDRPT3
        Dim FLAG As Integer
        Dim CODE As String
        Dim Strdistrict, strsociety As String

        Try

            'If Val(Txtccode.Text) > 0 OrElse DrpBoardDist.SelectedValue > 0 Then
            '    StartUpScript("", "Please Select College Code or District Only")
            'End If
            'If Not FormValidations() Then Exit Sub
            DsResult = New DataSet
            ObjReport = New ClsBankChallan

            'If Val(Txtccode.Text) > 0 Then
            '    FLAG = 0
            '    CODE = Val(Txtccode.Text)
            '    'DrpBoardDist.SelectedValue = 0

            'ElseIf DrpBoardDist.SelectedValue > 0 Then
            '    FLAG = 1
            '    CODE = DrpBoardDist.SelectedValue
            '    Txtccode.Text = ""
            'End If



            DsResult = ObjReport.COLLEGEINFOALL()

            If DsResult.Tables(0).Rows.Count > 0 Then

                cr3 = New BOARDRPT3
                cr3.SetDataSource(DsResult)
                pgm = cr3.PrintOptions.PageMargins
                pgm.leftMargin = 5
                pgm.rightMargin = 2
                cr3.PrintOptions.ApplyPageMargins(pgm)
                '
                'Dim oStream As MemoryStream = DirectCast(cr2.ExportToStream(CrystalDecisions.[Shared].ExportFormatType.Excel), MemoryStream)
                'Response.Clear()
                'Response.Buffer = True
                'Response.ContentType = "application/vnd.ms-excel"
                'Response.BinaryWrite(oStream.ToArray())
                'Response.End()
                '
                eo = cr3.ExportOptions
                eo.ExportFormatType = ExportFormatType.Excel
                eo.UExportDestinationType = ExportDestinationType.DiskFile

                Dim FILENAME As String = System.DateTime.Today & ".xls"

                dfile.DiskFileName = "C:\Inetpub\wwwroot\CollegeBoard\Examination\BoardEnrollments\Reports\" & FILENAME
                eo.DestinationOptions = dfile
                cr3.Export()
                'cr2.ExportToDisk(ExportFormatType.Excel, FILENAME)
                Response.Clear()
                Response.Redirect(FILENAME)
            Else
                StartUpScript("", "No Data")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Imagebutton2_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim pgm As PageMargins
        Dim eo As ExportOptions
        Dim dfile As New DiskFileDestinationOptions
        Dim cr As BOARDRPT
        Dim cr2 As BOARDRPT2
        Dim FLAG As Integer
        Dim CODE As String

        Try

            'If Val(Txtccode.Text) > 0 OrElse DrpBoardDist.SelectedValue > 0 Then
            '    StartUpScript("", "Please Select College Code or District Only")
            'End If
            'If Not FormValidations() Then Exit Sub
            DsResult = New DataSet
            ObjReport = New ClsBankChallan

            'If Val(Txtccode.Text) > 0 Then
            '    FLAG = 0
            '    CODE = Val(Txtccode.Text)
            '    DrpBoardDist.SelectedValue = 0

            'ElseIf DrpBoardDist.SelectedValue > 0 Then
            '    FLAG = 1
            '    CODE = DrpBoardDist.SelectedValue
            '    Txtccode.Text = ""
            'End If



            DsResult = ObjReport.COLLEGEINFO(CODE.ToString, FLAG)

            If DsResult.Tables(0).Rows.Count > 0 Then

                If FLAG = 0 Then

                    cr = New BOARDRPT
                    cr.SetDataSource(DsResult)
                    pgm = cr.PrintOptions.PageMargins
                    pgm.leftMargin = 5
                    pgm.rightMargin = 2
                    cr.PrintOptions.ApplyPageMargins(pgm)
                    eo = cr.ExportOptions
                    eo.ExportFormatType = ExportFormatType.PortableDocFormat
                    eo.UExportDestinationType = ExportDestinationType.DiskFile

                    'If Not Directory.Exists(Server.MapPath(Request.ApplicationPath) & "/Board/COLLEGEINFO/") Then
                    '    Directory.CreateDirectory(Server.MapPath(Request.ApplicationPath) & "/Board/COLLEGEINFO/")
                    'End If

                    Dim FILENAME As String = Val(Txtccode.Text) & ".PDF"
                    dfile.DiskFileName = "C:\Inetpub\wwwroot\CollegeBoard\Examination\BoardEnrollments\Reports\" & FILENAME
                    eo.DestinationOptions = dfile

                    cr.Export()
                    Response.Clear()
                    Response.Redirect(FILENAME, False)


                    'ElseIf FLAG = 1 Then

                    '    cr2 = New BOARDRPT2
                    '    cr2.SetDataSource(DsResult)
                    '    pgm = cr2.PrintOptions.PageMargins
                    '    pgm.leftMargin = 5
                    '    pgm.rightMargin = 2
                    '    cr2.PrintOptions.ApplyPageMargins(pgm)
                    '    '
                    '    'Dim oStream As MemoryStream = DirectCast(cr2.ExportToStream(CrystalDecisions.[Shared].ExportFormatType.Excel), MemoryStream)
                    '    'Response.Clear()
                    '    'Response.Buffer = True
                    '    'Response.ContentType = "application/vnd.ms-excel"
                    '    'Response.BinaryWrite(oStream.ToArray())
                    '    'Response.End()
                    '    '
                    '    eo = cr2.ExportOptions
                    '    eo.ExportFormatType = ExportFormatType.Excel
                    '    eo.UExportDestinationType = ExportDestinationType.DiskFile

                    '    Dim FILENAME As String = DrpBoardDist.SelectedItem.Text & ".xls"
                    '    dfile.DiskFileName = "C:\Inetpub\wwwroot\CollegeBoard\Examination\BoardEnrollments\Reports\" & FILENAME
                    '    eo.DestinationOptions = dfile
                    '    cr2.Export()
                    '    'cr2.ExportToDisk(ExportFormatType.Excel, FILENAME)
                    '    Response.Clear()
                    '    Response.Redirect(FILENAME, False)



                End If




            Else
                StartUpScript("", "No Data")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub ImgDist_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    Dim pgm As PageMargins
    '    Dim eo As ExportOptions
    '    Dim dfile As New DiskFileDestinationOptions
    '    Dim cr As BOARDRPT
    '    Dim cr2 As BOARDRPT2
    '    Dim FLAG As Integer
    '    Dim CODE As String

    '    Try

    '        'If Val(Txtccode.Text) > 0 OrElse DrpBoardDist.SelectedValue > 0 Then
    '        '    StartUpScript("", "Please Select College Code or District Only")
    '        'End If
    '        'If Not FormValidations() Then Exit Sub
    '        DsResult = New DataSet
    '        ObjReport = New ClsBankChallan

    '        'If Val(Txtccode.Text) > 0 Then
    '        '    FLAG = 0
    '        '    CODE = Val(Txtccode.Text)
    '        '    DrpBoardDist.SelectedValue = 0

    '        'ElseIf DrpBoardDist.SelectedValue > 0 Then
    '        '    FLAG = 1
    '        '    CODE = DrpBoardDist.SelectedValue
    '        '    Txtccode.Text = ""
    '        'End If



    '        DsResult = ObjReport.COLLEGEINFO(CODE.ToString, FLAG)

    '        If DsResult.Tables(0).Rows.Count > 0 Then

    '            If FLAG = 0 Then

    '                'cr = New BOARDRPT
    '                'cr.SetDataSource(DsResult)
    '                'pgm = cr.PrintOptions.PageMargins
    '                'pgm.leftMargin = 5
    '                'pgm.rightMargin = 2
    '                'cr.PrintOptions.ApplyPageMargins(pgm)
    '                'eo = cr.ExportOptions
    '                'eo.ExportFormatType = ExportFormatType.PortableDocFormat
    '                'eo.UExportDestinationType = ExportDestinationType.DiskFile

    '                ''If Not Directory.Exists(Server.MapPath(Request.ApplicationPath) & "/Board/COLLEGEINFO/") Then
    '                ''    Directory.CreateDirectory(Server.MapPath(Request.ApplicationPath) & "/Board/COLLEGEINFO/")
    '                ''End If

    '                'Dim FILENAME As String = Val(Txtccode.Text) & ".PDF"
    '                'dfile.DiskFileName = "C:\Inetpub\wwwroot\CollegeBoard\Examination\BoardEnrollments\Reports\" & FILENAME
    '                'eo.DestinationOptions = dfile

    '                'cr.Export()
    '                'Response.Clear()
    '                'Response.Redirect(FILENAME, False)


    '            ElseIf FLAG = 1 Then

    '                cr2 = New BOARDRPT2
    '                cr2.SetDataSource(DsResult)
    '                pgm = cr2.PrintOptions.PageMargins
    '                pgm.leftMargin = 5
    '                pgm.rightMargin = 2
    '                cr2.PrintOptions.ApplyPageMargins(pgm)
    '                '
    '                'Dim oStream As MemoryStream = DirectCast(cr2.ExportToStream(CrystalDecisions.[Shared].ExportFormatType.Excel), MemoryStream)
    '                'Response.Clear()
    '                'Response.Buffer = True
    '                'Response.ContentType = "application/vnd.ms-excel"
    '                'Response.BinaryWrite(oStream.ToArray())
    '                'Response.End()
    '                '
    '                eo = cr2.ExportOptions
    '                eo.ExportFormatType = ExportFormatType.Excel
    '                eo.UExportDestinationType = ExportDestinationType.DiskFile

    '                'Dim FILENAME As String = DrpBoardDist.SelectedItem.Text & ".xls"
    '                ' dfile.DiskFileName = "C:\Inetpub\wwwroot\CollegeBoard\Examination\BoardEnrollments\Reports\" & FILENAME
    '                eo.DestinationOptions = dfile
    '                cr2.Export()
    '                'cr2.ExportToDisk(ExportFormatType.Excel, FILENAME)
    '                Response.Clear()
    '                'Response.Redirect(FILENAME, False)



    '            End If




    '        Else
    '            StartUpScript("", "No Data")
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub ImgCCode_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgCCode.Click

        Dim pgm As PageMargins
        Dim eo As ExportOptions
        Dim dfile As New DiskFileDestinationOptions
        Dim cr As BOARDRPT
        Dim cr2 As BOARDRPT2
        Dim FLAG As Integer
        Dim CODE As String

        Try

            rdbAffil.Checked = False
            rdbcert.Checked = False

            DsResult = New DataSet


            If Val(Txtccode.Text) > 0 Then
                FLAG = 0
                CODE = Val(Txtccode.Text)
            End If

            ObjReport = New ClsBankChallan
            DsResult = ObjReport.COLLEGEINFO(CODE.ToString, FLAG)

            If DsResult.Tables(0).Rows.Count > 0 Then

                If FLAG = 0 Then

                    cr = New BOARDRPT
                    cr.SetDataSource(DsResult)
                    pgm = cr.PrintOptions.PageMargins
                    pgm.leftMargin = 5
                    pgm.rightMargin = 2
                    cr.PrintOptions.ApplyPageMargins(pgm)
                    eo = cr.ExportOptions
                    eo.ExportFormatType = ExportFormatType.PortableDocFormat
                    eo.UExportDestinationType = ExportDestinationType.DiskFile

                    'If Not Directory.Exists(Server.MapPath(Request.ApplicationPath) & "/Board/COLLEGEINFO/") Then
                    '    Directory.CreateDirectory(Server.MapPath(Request.ApplicationPath) & "/Board/COLLEGEINFO/")
                    'End If

                    Dim FILENAME As String = Val(Txtccode.Text) & ".PDF"
                    dfile.DiskFileName = "C:\Inetpub\wwwroot\CollegeBoard\Examination\BoardEnrollments\Reports\" & FILENAME
                    eo.DestinationOptions = dfile

                    cr.Export()
                    Response.Clear()
                    Response.Redirect(FILENAME, False)

                End If
            Else
                StartUpScript("", "No Data")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub rdbAffil_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAffil.CheckedChanged



        Dim pgm As PageMargins
        Dim eo As ExportOptions
        Dim dfile As New DiskFileDestinationOptions
        Dim cr As BOARDRPT
        Dim cr3 As BOARDRPT3
        Dim FLAG As Integer
        Dim CODE As String
        Dim Strdistrict, strsociety As String

        Try
            If rdbAffil.Checked = True Then
                Session("USERSLNO") = USERSLNO

                DsResult = New DataSet
                ObjReport = New ClsBankChallan


                DsResult = ObjReport.COLLEGEINFOALL()

                If DsResult.Tables(0).Rows.Count > 0 Then

                    cr3 = New BOARDRPT3
                    cr3.SetDataSource(DsResult)
                    pgm = cr3.PrintOptions.PageMargins
                    pgm.leftMargin = 5
                    pgm.rightMargin = 2
                    cr3.PrintOptions.ApplyPageMargins(pgm)
                    eo = cr3.ExportOptions
                    eo.ExportFormatType = ExportFormatType.Excel
                    eo.UExportDestinationType = ExportDestinationType.DiskFile

                    Dim FILENAME As String = USERSLNO & ".xls"

                    dfile.DiskFileName = "C:\Inetpub\wwwroot\CollegeBoard\Examination\BoardEnrollments\Reports\" & FILENAME
                    eo.DestinationOptions = dfile
                    cr3.Export()
                    'cr2.ExportToDisk(ExportFormatType.Excel, FILENAME)
                    Response.Clear()
                    Response.Redirect(FILENAME, False)
                Else
                    StartUpScript("", "No Data")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub rdbcert_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbcert.CheckedChanged

        Dim pgm As PageMargins
        Dim eo As ExportOptions
        Dim dfile As New DiskFileDestinationOptions
        Dim cr As BOARDRPT
        Dim cr2 As BOARDRPT2
        Dim FLAG As Integer
        Dim CODE As String

        Try
            If rdbcert.Checked = True Then
                Session("USERSLNO") = USERSLNO

                DsResult = New DataSet
                ObjReport = New ClsBankChallan


                DsResult = ObjReport.COLLEGEINFOALL()

                If DsResult.Tables(0).Rows.Count > 0 Then

                    cr2 = New BOARDRPT2
                    cr2.SetDataSource(DsResult)
                    pgm = cr2.PrintOptions.PageMargins
                    pgm.leftMargin = 5
                    pgm.rightMargin = 2
                    cr2.PrintOptions.ApplyPageMargins(pgm)
                    eo = cr2.ExportOptions
                    eo.ExportFormatType = ExportFormatType.Excel
                    eo.UExportDestinationType = ExportDestinationType.DiskFile

                    Dim FILENAME As String = USERSLNO & ".xls"

                    dfile.DiskFileName = "C:\Inetpub\wwwroot\CollegeBoard\Examination\BoardEnrollments\Reports\" & FILENAME
                    eo.DestinationOptions = dfile
                    cr2.Export()
                    'cr2.ExportToDisk(ExportFormatType.Excel, FILENAME)
                    Response.Clear()
                    Response.Redirect(FILENAME, False)
                Else
                    StartUpScript("", "No Data")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Page Load Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            USERSLNO = Session("USERSLNO")

            If Not IsPostBack Then
                'ButtonsHiding(Me.Page)
                'fillBoardDist()
                'FillFDRS()
                rdbAffil.Checked = False
                rdbcert.Checked = False
            Else
            End If

        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
            If Session("USERID") Is Nothing Then
                OracleLogFile("USERID := " & "SRIHARI" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            Else
                OracleLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            End If
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                If Not Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                    "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                    StartUpScript("", GeneralErrorMessage(ex.Message))
                End If
            End If
        End Try
    End Sub

#End Region


End Class
