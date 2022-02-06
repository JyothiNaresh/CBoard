
' Modified Author : P.Venu Mar-2013 [ TC Generate ]
' Modified Author : KISHORE G 11-Apr-2013 [ CC Generate ]

Imports System.Web.UI
Imports System.Web.UI.WebControls
'Imports System.Web.UI.Page
'Imports System.Web.HttpWorkerRequest
'Imports System.Web.HttpUtility
Imports System.Data
Imports System.Data.OracleClient
Imports System.Web
Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.CrystalReports
Imports System.Drawing.Printing
Imports System.IO
Imports CollegeBoardDLL

Public Class BoardTCReportMumbai
    Inherits System.Web.UI.Page


#Region " $ Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents TxtDateleaving As System.Web.UI.WebControls.TextBox
    Protected WithEvents DrpIIyear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents BtnTc As System.Web.UI.WebControls.Button
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpCourse As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpQualifiedUniv As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnGenerate As System.Web.UI.WebControls.Button
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Drpbieucs As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Table4 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Dropdownlist1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Txtto As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Txtfrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpStdYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Tablecc As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents d As System.Web.UI.WebControls.DropDownList
    Protected WithEvents BtnCc As System.Web.UI.WebControls.Button
    Protected WithEvents btnCCGenerate As System.Web.UI.WebControls.Button
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtTcDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnGeneratenewTC As System.Web.UI.WebControls.Button
    Protected WithEvents btnGeneratenewCC As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " $ Class Variables"
    Private oConn As OracleConnection 'Connection Object Declaration.
    Private oComm As OracleCommand 'Command Object Declaration.
    Private oTrans As OracleTransaction 'Transaction Object Declaration.
    Private oAdap As OracleDataAdapter 'Adapter Object Declaration.
    Private oParam As OracleParameter 'Parameter Object Declaration.
    Private Ds, DsPrinter, DsPriview, DsCCPriview As DataSet
    Private ClsBE As New ClsBoardEnrollment
    Private _AdmSlno, _Uniqueno, _BoardCollegeSlno As Integer
    Private rptutl As Utility
    Private rtnMessage As String 'Result of the return type.
    Dim i, j, FLAG As Integer

    Dim VDrpCourse, VDrpIIyear, VDrpbieucs As Integer
    Dim vTxtDateleaving, PdfFileName As String
    Dim TcDum As Integer
#End Region

#Region " $ Page Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load

        Try
            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                ButtonsHiding(Me.Page)
                SetViewStateVariables()
                ' fillDrpCourse()
                fillDetails(_Uniqueno)
                GettingUsertype()
                Table4.Visible = False
                Tablecc.Visible = False
                FLAG = CInt(Request.QueryString("FLAG"))
                If FLAG = 1 Then
                    Table4.Visible = True
                Else
                    Table4.Visible = False
                End If
                If FLAG = 2 Then
                    Tablecc.Visible = True
                Else
                    Tablecc.Visible = False
                End If
            Else
                Table4.Visible = False
                Tablecc.Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " $ DataSet"

    Public Function TransferCertificate(ByVal genprv As Integer) As DataSet

        Try
            TcDum = Session("TcDum")
            Ds = New DataSet
            If TcDum = 1 Then
                Ds = ClsBE.P_TCgenerationMumbai(Me.ViewState("_Uniqueno"), Session("COMACADEMICSLNO"), "", DrpCourse.SelectedItem.Text, DrpQualifiedUniv.SelectedItem.Text, "", "GOOD", DateConversion(TxtDateleaving.Text), DateConversion(TxtTcDate.Text), Me.ViewState("_BoardCollegeSlno"), 1, genprv, DrpCourse.SelectedItem.Value, Drpbieucs.SelectedValue, DrpIIyear.SelectedItem.Value, Session("USERSLNO"), TXTPISTUDIES.Text, TXTSTUDSINCE.Text, TXTREASON.Text, TXTREMARK.Text, TXTCLASSTEACHER.Text, TXTCLEARK.Text)
            Else
                Ds = ClsBE.P_TCgenerationMumbai(Me.ViewState("_Uniqueno"), Session("COMACADEMICSLNO"), "", DrpCourse.SelectedItem.Text, DrpQualifiedUniv.SelectedItem.Text, "", "GOOD", DateConversion(TxtDateleaving.Text), DateConversion(TxtTcDate.Text), Me.ViewState("_BoardCollegeSlno"), 1, genprv, DrpCourse.SelectedItem.Value, Drpbieucs.SelectedValue, DrpIIyear.SelectedItem.Value, Session("USERSLNO"), TXTPISTUDIES.Text, TXTSTUDSINCE.Text, TXTREASON.Text, TXTREMARK.Text, TXTCLASSTEACHER.Text, TXTCLEARK.Text)
            End If
            
            Return Ds
        Catch oex As OracleException
            Throw (oex)
        Catch ex As Exception
            Throw (ex)

        End Try

    End Function

    Public Function TransferCertificateNew(ByVal genprv As Integer) As DataSet

        Try
            TcDum = Session("TcDum")
            Ds = New DataSet

            ' Ds = ClsBE.P_TCgenerationMumbai(Me.ViewState("_Uniqueno"), Session("COMACADEMICSLNO"), "NONE", DrpCourse.SelectedItem.Text, DrpQualifiedUniv.SelectedItem.Text, "NONE", "GOOD", DateConversion(TxtDateleaving.Text), DateConversion(TxtTcDate.Text), Me.ViewState("_BoardCollegeSlno"), 1, genprv, DrpCourse.SelectedItem.Value, Drpbieucs.SelectedValue, DrpIIyear.SelectedItem.Value, Session("USERSLNO"), TXTPISTUDIES.Text, TXTSTUDSINCE.Text, TXTREASON.Text, TXTREMARK.Text, TXTCLASSTEACHER.Text, TXTCLEARK.Text)
            If TcDum = 1 Then
                Ds = ClsBE.P_TCgenerationMUMBAI_Dummy(Me.ViewState("_Uniqueno"), Session("COMACADEMICSLNO"), "NONE", DrpCourse.SelectedItem.Text, DrpQualifiedUniv.SelectedItem.Text, "NONE", "GOOD", DateConversion(TxtDateleaving.Text), DateConversion(TxtTcDate.Text), Me.ViewState("_BoardCollegeSlno"), 1, genprv, DrpCourse.SelectedItem.Value, Drpbieucs.SelectedValue, DrpIIyear.SelectedItem.Value, Session("USERSLNO"), TXTPISTUDIES.Text, TXTSTUDSINCE.Text, TXTREASON.Text, TXTREMARK.Text, TXTCLASSTEACHER.Text, TXTCLEARK.Text)
            Else
                Ds = ClsBE.P_TCgenerationMumbai(Me.ViewState("_Uniqueno"), Session("COMACADEMICSLNO"), "NONE", DrpCourse.SelectedItem.Text, DrpQualifiedUniv.SelectedItem.Text, "NONE", "GOOD", DateConversion(TxtDateleaving.Text), DateConversion(TxtTcDate.Text), Me.ViewState("_BoardCollegeSlno"), 1, genprv, DrpCourse.SelectedItem.Value, Drpbieucs.SelectedValue, DrpIIyear.SelectedItem.Value, Session("USERSLNO"), TXTPISTUDIES.Text, TXTSTUDSINCE.Text, TXTREASON.Text, TXTREMARK.Text, TXTCLASSTEACHER.Text, TXTCLEARK.Text)
            End If
            Return Ds
        Catch oex As OracleException
            Throw (oex)
        Catch ex As Exception
            Throw (ex)

        End Try

    End Function

    Public Function ConductCertificate() As DataSet

        Try

            TcDum = Session("TcDum")
            Ds = New DataSet
            If TcDum = 1 Then
                Ds = ClsBE.P_CCgeneration_Dummy(Me.ViewState("_Uniqueno"), DrpStdYear.SelectedItem.Text, Txtfrom.Text, Txtto.Text, Session("COMACADEMICSLNO"))
            Else
                Ds = ClsBE.P_CCgenerationChina(Me.ViewState("_Uniqueno"), DrpStdYear.SelectedItem.Text, Txtfrom.Text, Txtto.Text, Session("COMACADEMICSLNO"))
            End If

            Return Ds
        Catch oex As OracleException
            Throw (oex)
        Catch ex As Exception
            Throw (ex)

        End Try

    End Function


    Public Function ConductCertificateChina() As DataSet

        Try
            TcDum = Session("TcDum")
            Ds = New DataSet
            If TcDum = 1 Then
                Ds = ClsBE.P_CCgeneration_Dummy(Me.ViewState("_Uniqueno"), DrpStdYear.SelectedItem.Text, Txtfrom.Text, Txtto.Text, Session("COMACADEMICSLNO"))
            Else
                Ds = ClsBE.P_CCgenerationMumbai(Me.ViewState("_Uniqueno"), DrpStdYear.SelectedItem.Text, Txtfrom.Text, Txtto.Text, Session("COMACADEMICSLNO"))
            End If

            Return Ds
        Catch oex As OracleException
            Throw (oex)
        Catch ex As Exception
            Throw (ex)

        End Try

    End Function

   

#End Region

#Region " $ Button Click Events"

    Private Sub BtnTc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTc.Click

        Dim slevel As Integer
        Dim iPCType As Integer
        Dim i As Integer
        Dim LevelType As String
        Dim DS As DataSet


        Try

            DsPriview = New DataSet
            DsPriview = TransferCertificate(1)
            Session("DsPriview") = DsPriview

            Response.Redirect("BoardTCPreviewMumbai.aspx")

        Catch oex As OracleException
            Throw (oex)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim slevel As Integer
        Dim iPCType As Integer
        Dim i As Integer
        Dim LevelType As String
        Dim DS As DataSet
        Dim temp As TCRPTv2


        Dim pgm As PageMargins
        Dim eo As ExportOptions
        Dim dfile As DiskFileDestinationOptions

        Try
            PdfFileName = Session("USERSLNO").ToString + "_Tc.Pdf"
            DS = New DataSet
            temp = New TCRPTv2
            dfile = New DiskFileDestinationOptions
            DS = TransferCertificate(2)

            temp.SetDataSource(DS)
            pgm = temp.PrintOptions.PageMargins
            pgm.leftMargin = 0.25
            pgm.rightMargin = 0.25
            temp.PrintOptions.ApplyPageMargins(pgm)
            eo = temp.ExportOptions
            eo.ExportFormatType = ExportFormatType.PortableDocFormat
            eo.UExportDestinationType = ExportDestinationType.DiskFile
            dfile.DiskFileName = "C:\Inetpub\wwwroot\CollegeBoard\Examination\Reports\BoardReports\" & PdfFileName
            eo.DestinationOptions = dfile

            temp.Export()

            Response.Redirect(PdfFileName & "#navpanes=0&toolbar=0&scrollbar=0")

        Catch oex As OracleException
            Throw (oex)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

#End Region

#Region " $ Fill Methods"

    Private Sub fillDrpCourse()

        Dim Ds As DataSet
        ClsBE = New ClsBoardEnrollment
        Ds = ClsBE.Masters_Selectall(15)
        DrpCourse.DataSource = Ds.Tables(0)
        DrpCourse.DataTextField = "NAME"
        DrpCourse.DataValueField = "SLNO"
        DrpCourse.DataBind()
        DrpCourse.Items.Insert(0, New ListItem("-Select-", 0))


        '  DrpStdYear.DataSource = Ds.Tables(0)
        'DrpStdYear.DataTextField = "NAME"
        'DrpStdYear.DataValueField = "SLNO"
        'DrpStdYear.DataBind()
        'DrpStdYear.Items.Insert(0, New ListItem("-Select-", 0))
        'DrpStdYear.Items.Insert(DrpStdYear.Items.Count, New ListItem("INTERMEDIATE", DrpStdYear.Items.Count))


    End Sub

    Private Sub fillDetails(ByVal _Uniqueno As Integer)
        Try
            Dim ds As DataSet
            ClsBE = New ClsBoardEnrollment
            ds = ClsBE.P_TCStudentDetails(_Uniqueno)

            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                If ds.Tables(0).Rows(0).Item(0).ToString > 0 Then
                    DrpCourse.SelectedValue = ds.Tables(0).Rows(0).Item(0).ToString ': DrpCourse.Enabled = False
                End If
            Else
                'DrpCourse.Enabled = True
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item(1)) Then
                If ds.Tables(0).Rows(0).Item(1).ToString <> "" Then
                    TxtDateleaving.Text = ds.Tables(0).Rows(0).Item(1).ToString ': TxtDateleaving.Enabled = False
                End If
            Else
                'TxtDateleaving.Enabled = True
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item(2)) Then
                If ds.Tables(0).Rows(0).Item(2).ToString > 0 Then
                    Drpbieucs.SelectedValue = ds.Tables(0).Rows(0).Item(2).ToString ': Drpbieucs.Enabled = False
                End If
            Else
                'Drpbieucs.Enabled = True
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item(3)) Then
                If ds.Tables(0).Rows(0).Item(3).ToString > 0 Then
                    DrpIIyear.SelectedValue = ds.Tables(0).Rows(0).Item(3).ToString ': DrpIIyear.Enabled = False
                End If
            Else
                'DrpIIyear.Enabled = True
            End If

          

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    

#End Region

#Region " $ Methods"

    Private Function Agree() As Boolean

        Try

        Catch ex As Exception

        End Try
    End Function

    Private Sub SetViewStateVariables()
        Try
            If Session("TcDum") = 0 Then
                If Not Request.QueryString("AdmSlno") Is Nothing Then _AdmSlno = Request.QueryString("ADMSLNO")
                Me.ViewState("_AdmSlno") = _AdmSlno
            End If

            If Not Request.QueryString("Uniqueno") Is Nothing Then _Uniqueno = Request.QueryString("UNIQUENO")
            If Not Request.QueryString("BOARDCOLLEGESLNO") Is Nothing Then _BoardCollegeSlno = Request.QueryString("BOARDCOLLEGESLNO")
            Me.ViewState("_Uniqueno") = _Uniqueno
            Me.ViewState("_BoardCollegeSlno") = _BoardCollegeSlno

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GettingUsertype()
        Try
            Dim Ds, DS1 As DataSet
            rptutl = New Utility
            Dim TCGEN, TCCHIANA As Integer
            Ds = rptutl.DataSet_OneFetch("SELECT CONTROL1,CONTROL2 FROM EXAM_FORMCONTROL_DISPLAY WHERE IDNODE=999")
            DS1 = rptutl.DataSet_OneFetch("SELECT USERTYPESLNO FROM E_USER_USERTYPE_MT WHERE USERSLNO=" & Session("USERSLNO") & " AND COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " ORDER BY USERTYPESLNO")

            For I = 0 To Ds.Tables(0).Rows.Count - 1
                If Ds.Tables(0).Rows(i).Item(0).ToString = 2 Then
                    If DS1.Tables(0).Rows(0).Item(0) > 2 Then
                        For j = 0 To DS1.Tables(0).Rows.Count - 1
                            If DS1.Tables(0).Rows(j).Item(i) = 41 Or DS1.Tables(0).Rows(j).Item(i) = 88 Then
                                TCGEN += 1
                                'ElseIf DS1.Tables(0).Rows(j).Item(0) = 54 Then
                                '    TCCHIANA += 1
                            End If

                        Next
                        If TCGEN = 0 Then

                            btnGeneratenewTC.Visible = False
                            'btnGeneratenewCC.Visible = False
                            btnGenerate.Visible = False ': BtnCc.Visible = False
                        End If
                      
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    

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

#Region " $ Rough"


    

#End Region


#Region "C C Buttons"

    Private Sub BtnCc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCc.Click
        Try
            DsCCPriview = New DataSet
            DsCCPriview = ConductCertificate()
            Session("DsCCPriview") = DsCCPriview
            Response.Redirect("BoardCCPreview.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCCGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCGenerate.Click
        Dim KDS As New DataSet
        Dim temp As ConductcertK3
        Dim pgm As PageMargins
        Dim eo As ExportOptions
        Dim dfile As DiskFileDestinationOptions

        Try
            PdfFileName = Session("USERSLNO").ToString + "_cc.Pdf"
            KDS = New DataSet
            temp = New ConductcertK3

            dfile = New DiskFileDestinationOptions

            KDS = ConductCertificate()

            temp.SetDataSource(KDS)
            pgm = temp.PrintOptions.PageMargins
            pgm.leftMargin = 5
            pgm.rightMargin = 2
            eo = temp.ExportOptions
            eo.ExportFormatType = ExportFormatType.PortableDocFormat

            eo.UExportDestinationType = ExportDestinationType.DiskFile
            dfile.DiskFileName = "C:\Inetpub\wwwroot\CollegeBoard\Examination\Reports\BoardReports\" & PdfFileName
            eo.DestinationOptions = dfile

            temp.Export()

            Response.Redirect(PdfFileName & "#navpanes=0&toolbar=0&scrollbar=0")

        Catch oex As OracleException
            Throw (oex)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

#End Region



#Region "Buttons"

    Private Sub btnGeneratenewTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneratenewTC.Click
        Dim slevel As Integer
        Dim iPCType As Integer
        Dim i As Integer
        Dim LevelType As String
        Dim DS As DataSet
        Try

            DsPriview = New DataSet
            DsPriview = TransferCertificateNew(2)
            Session("DsPriview") = DsPriview
            Response.Redirect("TcGenerateMumbai.aspx")

        Catch oex As OracleException
            Throw (oex)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Sub btnGeneratenewCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneratenewCC.Click
        Try
            DsCCPriview = New DataSet
            DsCCPriview = ConductCertificateChina()
            Session("DsCCPriview") = DsCCPriview
            Session("DPR") = DsCCPriview
            Dim crs As String
            'If DrpStdYear.SelectedItem.Value = DrpStdYear.Items.Count Then
            '    crs = "INTERMEDIATE"
            'Else
            '    crs = DrpStdYear.SelectedItem.Text
            'End If


            Dim FROM As String = Txtfrom.Text
            Dim TODATE As String = Txtto.Text
            Session("CRS") = DrpStdYear.SelectedItem.Text
            Session("FROM") = FROM
            Session("TODATE") = TODATE

            Response.Redirect("CCGenerateMumbai.aspx")
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class

