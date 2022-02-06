'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : STUDY (OR) CONDUCT CERTIFICATE FORSTUDENTS
'   AUTHOR                            : ANILKUMAR PODILI
'   INITIAL BASELINE DATE             : 26.05.2014
'   FINAL BASELINE DATE               : 28.05.2014
'   COMPLETED DATE                    : 28.05.2014
'----------------------------------------------------------------------------------------------
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.OracleClient
Imports System.Web
Imports System.Text
Imports System.Drawing.Printing
Imports System.IO
Imports CollegeBoardDLL
Public Class SchoolCCGeneratenew
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents LblAmdno As System.Web.UI.WebControls.Label
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents LblStuname As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents lBLFname As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpCourseLeav As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Drpjoinedfrm As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents txtfrm As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtDateleaving As System.Web.UI.WebControls.TextBox
    Protected WithEvents DrpBoardCollege As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnGenerate As System.Web.UI.WebControls.Button
    Protected WithEvents DrpQualifiedUniv As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Table4 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents BtnPreview As System.Web.UI.WebControls.Button

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
    Private objBE As ClsBoardEnrollment
    Private objBEfill As Utility
    Dim VDrpCourse, VDrpIIyear, VDrpbieucs As Integer
    Dim vTxtDateleaving, PdfFileName As String
    Private objWSCombo As ClsComboBoxFilling
    Dim TcDum As Integer
#End Region

#Region " LOAD EVENTS"

    Private Sub SetViewStateVariables()
        Try
            If Session("TcDum") = 0 Then
                If Not Request.QueryString("AdmSlno") Is Nothing Then _AdmSlno = Request.QueryString("ADMSLNO")
                Me.ViewState("_AdmSlno") = _AdmSlno
            End If
            If Not Request.QueryString("Uniqueno") Is Nothing Then _Uniqueno = Request.QueryString("UNIQUENO")
            Me.ViewState("_Uniqueno") = _Uniqueno
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                ButtonsHiding(Me.Page)
                SetViewStateVariables()
                fillDrpCourse()
                fillDetails(_Uniqueno)
                fillBoardColleges()
                GettingUsertype()
            End If

        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Fill Methods"

    Private Sub fillDrpCourse()

        Dim Ds As DataSet
        ClsBE = New ClsBoardEnrollment
        Dim dsExamBranch As DataSet
        Dim SqlStr As String
        objWSCombo = New ClsComboBoxFilling
        SqlStr = "SELECT COURSESLNO,NAME FROM T_COURSE_MT ORDER BY COURSESLNO"
        objBEfill = New Utility
        Ds = objBEfill.GetCommDataSet(SqlStr)
        DrpCourseLeav.DataSource = Ds.Tables(0)
        DrpCourseLeav.DataTextField = "NAME"
        DrpCourseLeav.DataValueField = "COURSESLNO"
        DrpCourseLeav.DataBind()
        DrpCourseLeav.Items.Insert(0, New ListItem("-Select-", 0))
        Drpjoinedfrm.DataSource = Ds.Tables(0)
        Drpjoinedfrm.DataTextField = "NAME"
        Drpjoinedfrm.DataValueField = "COURSESLNO"
        Drpjoinedfrm.DataBind()

    End Sub

    Private Sub fillDetails(ByVal _Uniqueno As Integer)
        Try
            Dim ds As DataSet
            ClsBE = New ClsBoardEnrollment
            ds = ClsBE.School_ConductDetails(_Uniqueno, Session("comacademicslno"))
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(1)) Then
                If ds.Tables(0).Rows(0).Item(1).ToString <> "" Then
                    LblAmdno.Text = ds.Tables(0).Rows(0).Item(2).ToString ': TxtDateleaving.Enabled = False

                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(1)) Then
                    If ds.Tables(0).Rows(0).Item(1).ToString <> "" Then
                        LblStuname.Text = ds.Tables(0).Rows(0).Item(3).ToString ': TxtDateleaving.Enabled = False
                    End If
                Else
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(1)) Then
                    If ds.Tables(0).Rows(0).Item(1).ToString <> "" Then
                        lBLFname.Text = ds.Tables(0).Rows(0).Item(4).ToString ': TxtDateleaving.Enabled = False
                    End If
                Else
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    If ds.Tables(0).Rows(0).Item(0).ToString > 0 Then
                        DrpCourseLeav.SelectedValue = ds.Tables(0).Rows(0).Item(7).ToString ': DrpCourse.Enabled = False
                    End If
                Else
                End If
            Else
            End If

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
                            If DS1.Tables(0).Rows(j).Item(i) = 41 Then
                                TCGEN += 1
                               
                            End If

                        Next
                        If TCGEN = 0 Then

                            btnGenerate.Visible = False
                            btnGenerate.Visible = False

                        End If
                       
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fillBoardColleges()
        Try
            Dim SqlStr As String
            SqlStr = "SELECT SBSLNO,SBNAME||SBADDRESS SBNAME FROM SCH_BOARDNAMES_MT ORDER BY SBSLNO"
            objBEfill = New Utility
            Ds = objBEfill.GetCommDataSet(SqlStr)
            DrpBoardCollege.DataSource = Ds.Tables(0)
            DrpBoardCollege.DataTextField = "SBNAME"
            DrpBoardCollege.DataValueField = "SBSLNO"
            DrpBoardCollege.DataBind()
            DrpBoardCollege.Items.Insert(0, New ListItem("-----------Select SchoolBoard---------------", 0))
        Catch ex As Exception
        End Try
    End Sub

#End Region


#Region "C C Buttons"

    Public Function SchConductCertificate() As DataSet
        Try
            Ds = New DataSet
            Ds = ClsBE.School_ConductDetails(Me.ViewState("_Uniqueno"), Session("COMACADEMICSLNO"))
            Return Ds
        Catch oex As OracleException
            Throw (oex)
        Catch ex As Exception
            Throw (ex)

        End Try

    End Function


    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Try
            DsCCPriview = New DataSet
            DsCCPriview = SchConductCertificate()
            Session("DsCCPriview") = DsCCPriview
            Session("DPR") = DsCCPriview
            Dim crsj, crsl As String

            crsj = Drpjoinedfrm.SelectedItem.Text
            crsl = DrpCourseLeav.SelectedItem.Text
            Dim brdsch As String = DrpBoardCollege.SelectedValue
            Dim FROM As String = txtfrm.Text
            Dim TODATE As String = TxtDateleaving.Text

            Session("brdsch") = brdsch
            Session("CRSl") = crsl
            Session("CRSj") = crsj
            Session("FROM") = FROM
            Session("TODATE") = TODATE

            Response.Redirect("SchoolCndCertNew.aspx")

        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPreview.Click
        Try
            DsCCPriview = New DataSet
            DsCCPriview = SchConductCertificate()
            Session("DsCCPriview") = DsCCPriview
            Session("DPR") = DsCCPriview
            Dim crsj, crsl As String

            crsj = Drpjoinedfrm.SelectedItem.Text
            crsl = DrpCourseLeav.SelectedItem.Text
            Dim brdsch As String = DrpBoardCollege.SelectedValue
            Dim FROM As String = txtfrm.Text
            Dim TODATE As String = TxtDateleaving.Text
            Session("brdsch") = brdsch
            Session("CRSl") = crsl
            Session("CRSj") = crsj
            Session("FROM") = FROM
            Session("TODATE") = TODATE
            Response.Redirect("SchoolCCPreview.aspx")

        Catch ex As Exception

        End Try
    End Sub
#End Region
End Class
