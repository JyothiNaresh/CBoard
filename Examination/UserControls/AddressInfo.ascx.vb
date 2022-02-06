'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : User Control for Address Info.
'   ACTIVITY                          : New/Edit
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 26-JUN-2006
'   FINAL BASELINE DATE               : 26-JUN-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------

Imports System.Data
Imports System.Data.OracleClient
Imports CollegeBoardDLL

Public Class AddressInfo
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblCountry As System.Web.UI.WebControls.Label
    Public WithEvents drpCountry As System.Web.UI.WebControls.DropDownList
    Public WithEvents txtHNO As System.Web.UI.WebControls.TextBox
    Public WithEvents txtStreetVill As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblState As System.Web.UI.WebControls.Label
    Protected WithEvents lblDistrict As System.Web.UI.WebControls.Label
    Public WithEvents drpState As System.Web.UI.WebControls.DropDownList
    Public WithEvents drpDistrict As System.Web.UI.WebControls.DropDownList
    Public WithEvents txtMobile1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Public WithEvents txtMandalArea As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Public WithEvents txtPIN As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Public WithEvents txtPhoneRes As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Public WithEvents txtPhoneOff As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Public WithEvents txtMobile2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Public WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Public WithEvents DrpMandal As System.Web.UI.WebControls.DropDownList
    Public WithEvents lblMandal As System.Web.UI.WebControls.Label




    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " Variables "
    Dim ClsUty As New Utility
    Dim MODE As String
#End Region

#Region "Properties"

    Public Property Country() As String
        Get
            Try
                Return drpCountry.SelectedValue
            Catch ex As Exception
                Throw ex
            End Try
        End Get
        Set(ByVal Value As String)
            Try
                drpCountry.SelectedValue = Value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Property State() As String
        Get
            Try
                Return drpState.SelectedValue
            Catch ex As Exception
                Throw ex
            End Try
        End Get
        Set(ByVal Value As String)
            Try
                drpState.SelectedValue = Value
                If drpState.SelectedValue <> "" Then FillDistrict(drpState.SelectedValue)
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Property District() As String
        Get
            Try
                If drpDistrict.SelectedIndex = -1 Then
                    Return "-1"
                Else
                    Return drpDistrict.SelectedValue
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Get
        Set(ByVal Value As String)
            Try
                drpDistrict.SelectedValue = Value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Property Mandal() As String
        Get
            Try
                If DrpMandal.SelectedIndex = -1 Then
                    Return "-1"
                Else
                    Return DrpMandal.SelectedValue
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Get
        Set(ByVal Value As String)
            Try
                DrpMandal.SelectedValue = Value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Property StreetVill() As String
        Get
            Try
                Return Trim(txtStreetVill.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Get
        Set(ByVal Value As String)
            Try
                txtStreetVill.Text = Value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Property MandalArea() As String
        Get
            Try
                Return Trim(txtMandalArea.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Get
        Set(ByVal Value As String)
            Try
                txtMandalArea.Text = Value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Property HNO() As String
        Get
            Try
                Return Trim(txtHNO.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Get
        Set(ByVal Value As String)
            Try
                txtHNO.Text = Value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Property PIN() As String
        Get
            Try
                Return Trim(txtPIN.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Get
        Set(ByVal Value As String)
            Try
                txtPIN.Text = Value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Property PhoneRes() As String
        Get
            Try
                Return Trim(txtPhoneRes.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Get
        Set(ByVal Value As String)
            Try
                txtPhoneRes.Text = Value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Property PhoneOff() As String
        Get
            Try
                Return Trim(txtPhoneOff.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Get
        Set(ByVal Value As String)
            Try
                txtPhoneOff.Text = Value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Property Mobile1() As String
        Get
            Try
                Return Trim(txtMobile1.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Get
        Set(ByVal Value As String)
            Try
                txtMobile1.Text = Value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Property Mobile2() As String
        Get
            Try
                Return Trim(txtMobile2.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Get
        Set(ByVal Value As String)
            Try
                txtMobile2.Text = Value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Property Email() As String
        Get
            Try
                Return Trim(txtEmail.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Get
        Set(ByVal Value As String)
            Try
                txtEmail.Text = Value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub FillCountry()
        Try
            Dim Ds As DataSet
            Ds = ClsUty.DataSet_Fetch("SELECT COUNTRYSLNO SLNO,NAME FROM T_COUNTRY_MT WHERE COUNTRYSLNO=1 ORDER BY NAME")
            drpCountry.DataSource = Ds
            drpCountry.DataTextField = "NAME"
            drpCountry.DataValueField = "SLNO"
            drpCountry.DataBind()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillState(ByVal CountrySLNO As Integer)
        Try
            Dim Ds As DataSet
            'If drpCountry.SelectedIndex = -1 Then
            '    drpState.Items.Clear()
            '    Exit Sub
            'End If
            'Ds = ClsUty.DataSet_Fetch("SELECT STATESLNO SLNO,NAME FROM T_STATE_MT WHERE COUNTRYSLNO=" & CountrySLNO.ToString & " ORDER BY NAME")
            Ds = ClsUty.DataSet_Fetch("SELECT STATESLNO SLNO,NAME FROM T_STATE_MT WHERE COUNTRYSLNO=1 ORDER BY NAME")
            drpState.DataSource = Ds
            drpState.DataTextField = "NAME"
            drpState.DataValueField = "SLNO"
            drpState.DataBind()
            drpState.Items.Insert(0, New ListItem("-Select-", 0))
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillDistrict(ByVal StateSLNO As Integer)
        Try
            Dim Ds As DataSet
            If drpState.SelectedIndex = -1 Then
                drpDistrict.Items.Clear()
                Exit Sub
            End If
            Ds = ClsUty.DataSet_Fetch("SELECT DISTRICTSLNO SLNO,NAME FROM EXAM_DISTRICT_MT WHERE STATESLNO=" & StateSLNO.ToString & " ORDER BY NAME")
            drpDistrict.DataSource = Ds
            drpDistrict.DataTextField = "NAME"
            drpDistrict.DataValueField = "SLNO"
            drpDistrict.DataBind()
            drpDistrict.Items.Insert(0, New ListItem("-Select-", 0))
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillMandal(ByVal DistrictSLNO As Integer)
        Try
            Dim Ds As DataSet
            If drpDistrict.SelectedIndex = -1 Then
                DrpMandal.Items.Clear()
                Exit Sub
            End If
            Ds = ClsUty.DataSet_Fetch("SELECT MANDALSLNO SLNO,NAME FROM EXAM_MANDAL_MT WHERE DISTRICTSLNO=" & DistrictSLNO.ToString & " ORDER BY NAME")
            DrpMandal.DataSource = Ds
            DrpMandal.DataTextField = "NAME"
            DrpMandal.DataValueField = "SLNO"
            DrpMandal.DataBind()
            DrpMandal.Items.Insert(0, New ListItem("-Select-", 0))
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Page Load Event"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IsPostBack Then
                MODE = Session("MODE")
                FillCountry()
                If MODE = "NEW" Then
                    FillState(drpCountry.SelectedValue)
                    FillDistrict(drpState.SelectedValue)
                    FillMandal(drpDistrict.SelectedValue)
                End If
            End If
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Combo Events"

    Private Sub drpCountry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpCountry.SelectedIndexChanged
        Try
            FillState(drpCountry.SelectedValue)
            FillDistrict(drpState.SelectedValue)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub drpState_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpState.SelectedIndexChanged
        Try
            FillDistrict(drpState.SelectedValue)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub drpDistrict_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpDistrict.SelectedIndexChanged
        Try
            FillMandal(drpDistrict.SelectedValue)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

   
End Class

