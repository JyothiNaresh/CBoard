Imports System.Web.Services.Protocols
Imports CollegeBoardDLL
Imports System.Data.OracleClient
Imports CommonDLL
Imports System.Math
Imports System.IO
Imports System.IO.Path

Public Class Cetificates_Dtnew
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtlblCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents dgGridSection As System.Web.UI.WebControls.DataGrid
    Protected WithEvents iBtnAdd As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents imgBtnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LBLCLGNAME As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Drpfire1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Drpfire2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents drpsant1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpsant2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents drpstruc1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpstruc2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents drpnoc1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpnoc2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Table4 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents HyperLink2 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents HyperLink3 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink4 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Hyperlink5 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Txtccode As System.Web.UI.WebControls.TextBox
    Protected WithEvents Hyp As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents txtfirfmdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtfirtodate As System.Web.UI.WebControls.TextBox
    Protected WithEvents cerfirepath1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents HypNew As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtstfmdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtsttodate As System.Web.UI.WebControls.TextBox
    Protected WithEvents cersanpath1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents HypNew2 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtstrfmdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtstrtodate As System.Web.UI.WebControls.TextBox
    Protected WithEvents cerstrpath1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents HypNew3 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents txtmunfmdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtmuntodate As System.Web.UI.WebControls.TextBox
    Protected WithEvents cermunpath1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents HypNew4 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Table12 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Table13 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Table14 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Table15 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents imgBtnGoo1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lstmCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents but1 As System.Web.UI.WebControls.Button


    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Protected WithEvents Button4 As System.Web.UI.WebControls.Button
    Protected WithEvents cerAffpath1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents cersecpath1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents cerleasepath1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents cerfdrpath1 As System.Web.UI.HtmlControls.HtmlInputFile

    Protected WithEvents ButAff As System.Web.UI.WebControls.Button

    Protected WithEvents butsec As System.Web.UI.WebControls.Button
    Protected WithEvents butlease As System.Web.UI.WebControls.Button
    Protected WithEvents Butfdr As System.Web.UI.WebControls.Button

    Protected WithEvents drpAff As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpaffsub As System.Web.UI.WebControls.DropDownList

    Protected WithEvents drpaddsec As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpsubadd As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drplease As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpleasesub As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpfdr As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpfdrsub As System.Web.UI.WebControls.DropDownList



    Protected WithEvents txtafffrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtaffto As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtsecfrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtsecto As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtleasefrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtleaseto As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtfdrfrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtfdrto As System.Web.UI.WebControls.TextBox

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
    Private objMaster As ClsBoarddt
    Private objMas As Masters
    Private ObjResult As Utility
    Private DsSearchResult As DataSet
    Public From As String
    Public Str, StrSql As String
    Private DsSearch, DsResult As DataSet
    Public PageIndex As Integer
    Public SLNO, MNO, RtnVal As Integer
    Private FormName As String = "Form1"
    Private MODE As String
    Private FileExtension As String
    Private FILENAME, FILEPATH As String
    Private USERFILENAME As String
    Private objReport As Utility
    Dim DSet As New DataSet
    Dim bool, bool1, bool2, bool3, bool4, bool5, bool6, bool7 As Boolean
#End Region

#Region "Common Methods"

    Protected Sub DeleteConformationMessage(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        Try
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Dim btn As Button = CType(e.Item.Cells(5).Controls(0), Button)
                    btn.Attributes.Add("onclick", "return confirm('Are you sure to delete this record ?')")
                    Exit Select
            End Select

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

#Region "Methods"

    Private Function SetEntries() As ArrayList
        Try
            Dim Arr As New ArrayList
            Dim gk As String
            gk = "System.DBNull.Value"
            If Me.ViewState("MODE") = "NEW" Then
                Arr.Add(Txtccode.Text)
                Session("CCODE") = Txtccode.Text
                Arr.Add(Val(Drpfire1.SelectedValue))
                Arr.Add(Val(drpsant1.SelectedValue))
                Arr.Add(Val(drpstruc1.SelectedValue))
                Arr.Add(Val(drpnoc1.SelectedValue))
                Arr.Add(Val(Drpfire2.SelectedValue))
                Arr.Add(Val(drpsant2.SelectedValue))
                Arr.Add(Val(drpstruc2.SelectedValue))
                Arr.Add(Val(drpnoc2.SelectedValue))
                If Trim(txtfirfmdate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtfirfmdate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If

                If Trim(txtfirtodate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtfirtodate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                If Trim(txtstfmdate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtstfmdate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                If Trim(txtsttodate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtsttodate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                If Trim(txtstrfmdate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtstrfmdate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                If Trim(txtstrtodate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtstrtodate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                If Trim(txtmunfmdate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtmunfmdate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                If Trim(txtmuntodate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtmuntodate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If

                Arr.Add(Val(drpAff.SelectedValue))
                Arr.Add(Val(drpaffsub.SelectedValue))
                If Trim(txtafffrom.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtafffrom.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If

                If Trim(txtaffto.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtaffto.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                Arr.Add(Val(drpaddsec.SelectedValue))
                Arr.Add(Val(drpsubadd.SelectedValue))
                If Trim(txtsecfrom.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtsecfrom.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If

                If Trim(txtsecto.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtsecto.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                Arr.Add(Val(drplease.SelectedValue))
                Arr.Add(Val(drpleasesub.SelectedValue))
                If Trim(txtleasefrom.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtleasefrom.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If

                If Trim(txtleaseto.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtleaseto.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                Arr.Add(Val(drpfdr.SelectedValue))
                Arr.Add(Val(drpfdrsub.SelectedValue))

                If Trim(txtfdrfrom.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtfdrfrom.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                If Trim(txtfdrto.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtfdrto.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                Arr.Add(Val(MNO))
            ElseIf Me.ViewState("MODE") = "EDIT" Then
                Arr.Add(Val(Trim(Me.ViewState("SLNO"))))
                Arr.Add(Txtccode.Text)
                Arr.Add(Val(Drpfire1.SelectedValue))
                Arr.Add(Val(drpsant1.SelectedValue))
                Arr.Add(Val(drpstruc1.SelectedValue))
                Arr.Add(Val(drpnoc1.SelectedValue))
                Arr.Add(Val(Drpfire2.SelectedValue))
                Arr.Add(Val(drpsant2.SelectedValue))
                Arr.Add(Val(drpstruc2.SelectedValue))
                Arr.Add(Val(drpnoc2.SelectedValue))


                If Trim(txtfirfmdate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtfirfmdate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If

                If Trim(txtfirtodate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtfirtodate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                If Trim(txtstfmdate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtstfmdate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                If Trim(txtsttodate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtsttodate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                If Trim(txtstrfmdate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtstrfmdate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                If Trim(txtstrtodate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtstrtodate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                If Trim(txtmunfmdate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtmunfmdate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                If Trim(txtmuntodate.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtmuntodate.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If

                Arr.Add(Val(drpAff.SelectedValue))
                Arr.Add(Val(drpaffsub.SelectedValue))
                If Trim(txtafffrom.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtafffrom.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If

                If Trim(txtaffto.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtaffto.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                Arr.Add(Val(drpaddsec.SelectedValue))
                Arr.Add(Val(drpsubadd.SelectedValue))
                If Trim(txtsecfrom.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtsecfrom.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If

                If Trim(txtsecto.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtsecto.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                Arr.Add(Val(drplease.SelectedValue))
                Arr.Add(Val(drpleasesub.SelectedValue))
                If Trim(txtleasefrom.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtleasefrom.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If

                If Trim(txtleaseto.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtleaseto.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                Arr.Add(Val(drpfdr.SelectedValue))
                Arr.Add(Val(drpfdrsub.SelectedValue))

                If Trim(txtfdrfrom.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtfdrfrom.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                If Trim(txtfdrto.Text) <> "" Then
                    Arr.Add(DateConversion(Trim(txtfdrto.Text)))
                Else
                    Arr.Add(System.DBNull.Value)
                End If
                Arr.Add(Val(MNO))
            End If

            Return Arr

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub FillControls()
        Try

            Dim DsGA As DataSet
            DsGA = New DataSet
            objMaster = New ClsBoarddt
            DsGA = objMaster.CERTIFICT_SelectNew(SLNO)
            FillFire()
            If DsGA.Tables(0).Rows.Count > 0 Then
                Txtccode.Text = DsGA.Tables(0).Rows(0)("CCODE").ToString
                Session("CCODE") = Txtccode.Text
                LBLCLGNAME.Text = DsGA.Tables(0).Rows(0)("COLLEGENAME").ToString
                Drpfire1.SelectedValue = Val(DsGA.Tables(0).Rows(0)("FIRESLNO1").ToString)
                drpsant1.SelectedValue = Val(DsGA.Tables(0).Rows(0)("SANITORYSLNO1").ToString)
                drpstruc1.SelectedValue = Val(DsGA.Tables(0).Rows(0)("STRUCTURALSLNO1").ToString)
                drpnoc1.SelectedValue = Val(DsGA.Tables(0).Rows(0)("NOCSLNO1").ToString)

                drpAff.SelectedValue = Val(DsGA.Tables(0).Rows(0)("AFFACADAMICSLNO").ToString)
                drpaddsec.SelectedValue = Val(DsGA.Tables(0).Rows(0)("ADDISECTIONSLNO").ToString)
                drplease.SelectedValue = Val(DsGA.Tables(0).Rows(0)("REGLEASEDEEDSLNO").ToString)
                drpfdr.SelectedValue = Val(DsGA.Tables(0).Rows(0)("FDRSLNO").ToString)

                If drpAff.SelectedValue = 1 Then
                    drpaffsub.Enabled = True
                    txtafffrom.Enabled = True
                    txtaffto.Enabled = True
                    'cersanpath1.Disabled = False
                    HyperLink1.Enabled = True
                Else
                    drpaffsub.Enabled = False
                    txtafffrom.Enabled = False
                    txtaffto.Enabled = False
                    'cersanpath1.Disabled = True
                    HyperLink1.Enabled = False

                End If

                If drpaddsec.SelectedValue = 1 Then
                    drpsubadd.Enabled = True
                    txtsecfrom.Enabled = True
                    txtsecto.Enabled = True
                    'cersanpath1.Disabled = False
                    HyperLink2.Enabled = True
                Else
                    drpsubadd.Enabled = False
                    txtsecfrom.Enabled = False
                    txtsecto.Enabled = False
                    'cersanpath1.Disabled = True
                    HyperLink2.Enabled = False

                End If


                If drplease.SelectedValue = 1 Then
                    drpleasesub.Enabled = True
                    txtleasefrom.Enabled = True
                    txtleaseto.Enabled = True
                    'cersanpath1.Disabled = False
                    HyperLink3.Enabled = True
                Else
                    drpleasesub.Enabled = False
                    txtleasefrom.Enabled = False
                    txtleaseto.Enabled = False
                    'cersanpath1.Disabled = True
                    HyperLink3.Enabled = False

                End If

                If drpfdr.SelectedValue = 1 Then
                    drpfdrsub.Enabled = True
                    txtfdrfrom.Enabled = True
                    txtfdrto.Enabled = True
                    'cersanpath1.Disabled = False
                    Hyperlink5.Enabled = True
                Else
                    drpfdrsub.Enabled = False
                    txtfdrfrom.Enabled = False
                    txtfdrto.Enabled = False
                    'cersanpath1.Disabled = True
                    Hyperlink5.Enabled = False

                End If

                If Drpfire1.SelectedValue = 1 Then
                    Drpfire2.Enabled = True
                    txtfirfmdate.Enabled = True
                    txtfirtodate.Enabled = True
                    'cerfirepath1.Disabled = False
                    HypNew.Enabled = True

                Else
                    Drpfire2.Enabled = False
                    txtfirfmdate.Enabled = False
                    txtfirtodate.Enabled = False
                    'cerfirepath1.Disabled = True
                    HypNew.Enabled = False

                End If

                If drpstruc1.SelectedValue = 1 Then
                    drpstruc2.Enabled = True
                    txtstrfmdate.Enabled = True
                    txtstrtodate.Enabled = True
                    'cerstrpath1.Disabled = False
                    HypNew3.Enabled = True

                Else
                    drpstruc2.Enabled = False
                    txtstrfmdate.Enabled = False
                    txtstrtodate.Enabled = False
                    'cerstrpath1.Disabled = True
                    HypNew3.Enabled = False

                End If

                If drpnoc1.SelectedValue = 1 Then
                    drpnoc2.Enabled = True
                    txtmunfmdate.Enabled = True
                    txtmuntodate.Enabled = True
                    'cermunpath1.Disabled = False
                    HypNew4.Enabled = True

                Else
                    drpnoc2.Enabled = False
                    txtmunfmdate.Enabled = False
                    txtmuntodate.Enabled = False
                    ' cermunpath1.Disabled = True
                    HypNew4.Enabled = False

                End If
                If drpaffsub.SelectedValue = 1 Then

                Else

                End If

                Drpfire2.SelectedValue = Val(DsGA.Tables(0).Rows(0)("FIRESLNO2").ToString)
                drpsant2.SelectedValue = Val(DsGA.Tables(0).Rows(0)("SANITORYSLNO2").ToString)
                drpstruc2.SelectedValue = Val(DsGA.Tables(0).Rows(0)("STRUCTURALSLNO2").ToString)
                drpnoc2.SelectedValue = Val(DsGA.Tables(0).Rows(0)("NOCSLNO2").ToString)


                drpaffsub.SelectedValue = Val(DsGA.Tables(0).Rows(0)("AFFACADAMICSUB").ToString)
                drpsubadd.SelectedValue = Val(DsGA.Tables(0).Rows(0)("ADDISECTIONSUB").ToString)
                drpleasesub.SelectedValue = Val(DsGA.Tables(0).Rows(0)("REGLEASEDEEDSUB").ToString)
                drpfdrsub.SelectedValue = Val(DsGA.Tables(0).Rows(0)("FDRSUB").ToString)

                txtfirfmdate.Text = Trim(DsGA.Tables(0).Rows(0)("FIREFROM").ToString)
                txtfirtodate.Text = Trim(DsGA.Tables(0).Rows(0)("FIRETO").ToString)
                txtstfmdate.Text = Trim(DsGA.Tables(0).Rows(0)("SANITORYFROM").ToString)
                txtsttodate.Text = Trim(DsGA.Tables(0).Rows(0)("SANITORYTO").ToString)
                txtstrfmdate.Text = Trim(DsGA.Tables(0).Rows(0)("STRUCTURALFROM").ToString)
                txtstrtodate.Text = Trim(DsGA.Tables(0).Rows(0)("STRUCTURALTO").ToString)
                txtmunfmdate.Text = Trim(DsGA.Tables(0).Rows(0)("NOCFROM").ToString)
                txtmuntodate.Text = Trim(DsGA.Tables(0).Rows(0)("NOCTO").ToString)


                txtafffrom.Text = Trim(DsGA.Tables(0).Rows(0)("AFFFROM").ToString)
                txtaffto.Text = Trim(DsGA.Tables(0).Rows(0)("AFFTO").ToString)
                txtsecfrom.Text = Trim(DsGA.Tables(0).Rows(0)("SECFROM").ToString)
                txtsecto.Text = Trim(DsGA.Tables(0).Rows(0)("SECTO").ToString)
                txtleasefrom.Text = Trim(DsGA.Tables(0).Rows(0)("LEASEFROM").ToString)
                txtleaseto.Text = Trim(DsGA.Tables(0).Rows(0)("LEASETO").ToString)
                txtfdrfrom.Text = Trim(DsGA.Tables(0).Rows(0)("FDRFROM").ToString)
                txtfdrto.Text = Trim(DsGA.Tables(0).Rows(0)("FDRTO").ToString)


                'Dim imgurl, imgfile As String
                'imgurl = "http://" & Request.ServerVariables("HTTP_HOST") & "/BOARD_CERT/"
                'imgurl = "http://" & Request.ServerVariables("HTTP_HOST") & "/" & Trim(DsGA.Tables(0).Rows(0)("SANITORYPATH").ToString)
                'HypNew.NavigateUrl = imgurl
                HypNew.NavigateUrl = Trim(DsGA.Tables(0).Rows(0)("FIREPATH").ToString)
                HypNew2.NavigateUrl = Trim(DsGA.Tables(0).Rows(0)("SANITORYPATH").ToString)
                HypNew3.NavigateUrl = Trim(DsGA.Tables(0).Rows(0)("STRUCTURALPATH").ToString)
                HypNew4.NavigateUrl = Trim(DsGA.Tables(0).Rows(0)("NOCPATH").ToString)
                HyperLink1.NavigateUrl = Trim(DsGA.Tables(0).Rows(0)("AFFPATH").ToString)
                HyperLink2.NavigateUrl = Trim(DsGA.Tables(0).Rows(0)("SECTIONSPATH").ToString)
                Hyperlink4.NavigateUrl = Trim(DsGA.Tables(0).Rows(0)("LEASEPATH").ToString)
                Hyperlink5.NavigateUrl = Trim(DsGA.Tables(0).Rows(0)("FDRPATH").ToString)

            Else

            End If

        Catch Oex As Exception
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ClearControls()
        Try
            Txtccode.Text = ""
            LBLCLGNAME.Text = ""
            Drpfire1.SelectedItem.Text = "Select"
            drpsant1.SelectedItem.Text = "Select"
            drpstruc1.SelectedItem.Text = "Select"
            drpnoc1.SelectedItem.Text = "Select"

            drpsant2.SelectedItem.Text = "Select"
            drpstruc2.SelectedItem.Text = "Select"
            drpnoc2.SelectedItem.Text = "Select"

        Catch ex As Exception

        End Try

    End Sub

    Private Function FormValidations() As Boolean
        Try
            Dim extension, Fcerfirepath1, Fcersanpath1, Fcerstrpath1, Fcermunpath1 As String
            Fcerfirepath1 = Path.GetFileName(cerfirepath1.PostedFile.FileName)
            Dim contentType1 As String = cerfirepath1.PostedFile.ContentType
            Fcersanpath1 = Path.GetFileName(cersanpath1.PostedFile.FileName)
            Dim contentType2 As String = cersanpath1.PostedFile.ContentType
            Fcerstrpath1 = Path.GetFileName(cerstrpath1.PostedFile.FileName)
            Dim contentType3 As String = cerstrpath1.PostedFile.ContentType
            Fcermunpath1 = Path.GetFileName(cermunpath1.PostedFile.FileName)
            Dim contentType4 As String = cermunpath1.PostedFile.ContentType

            If Trim(Txtccode.Text) = "" Or Trim(Txtccode.Text) Is Nothing Then
                StartUpScript("Txtccode", "Enter College Code.")
                Return False
                'ElseIf drpfire.SelectedItem.Text = "Select" Then
                '    StartUpScript(drpfire.ID, "Select Fire Safety Certificate.")
                '    Return False
            ElseIf drpstruc1.SelectedItem.Text = "Select" Then
                StartUpScript(drpstruc1.ID, "Select Fire Certificate.")
                Return False

            ElseIf drpsant1.SelectedItem.Text = "Select" Then
                StartUpScript(drpsant1.ID, "Select Sanitory Certificate.")
                Return False
            ElseIf drpnoc1.SelectedItem.Text = "Select" Then
                StartUpScript(drpnoc1.ID, "Select NOC Certificate.")
                Return False

            ElseIf Not IsDate(Trim(txtfirfmdate.Text)) Then
                StartUpScript(txtfirfmdate.ID, "Enter Date in Correct Formate. Ex:DD/MM/YYYY")
                Return False

            ElseIf Not IsDate(Trim(txtfirtodate.Text)) Then
                StartUpScript(txtfirtodate.ID, "Enter Date in Correct Formate. Ex:DD/MM/YYYY")
                Return False

            ElseIf Not IsDate(Trim(txtstfmdate.Text)) Then
                StartUpScript(txtstfmdate.ID, "Enter Date in Correct Formate. Ex:DD/MM/YYYY")
                Return False

            ElseIf Not IsDate(Trim(txtsttodate.Text)) Then
                StartUpScript(txtsttodate.ID, "Enter Date in Correct Formate. Ex:DD/MM/YYYY")
                Return False

            ElseIf Not IsDate(Trim(txtstrfmdate.Text)) Then
                StartUpScript(txtstrfmdate.ID, "Enter Date in Correct Formate. Ex:DD/MM/YYYY")
                Return False

            ElseIf Not IsDate(Trim(txtstrtodate.Text)) Then
                StartUpScript(txtstrtodate.ID, "Enter Date in Correct Formate. Ex:DD/MM/YYYY")
                Return False

            ElseIf Not IsDate(Trim(txtmunfmdate.Text)) Then
                StartUpScript(txtmunfmdate.ID, "Enter Date in Correct Formate. Ex:DD/MM/YYYY")
                Return False

            ElseIf Not IsDate(Trim(txtmuntodate.Text)) Then
                StartUpScript(txtmuntodate.ID, "Enter Date in Correct Formate. Ex:DD/MM/YYYY")
                Return False

                'ElseIf Not (extension = ".pdf") Then
                '    StartUpScript("", "Please upload only PDF file..")
                '    Return False
                'ElseIf (cerfirepath1.PostedFile.ContentLength / 1024) > 2000 Then
                '    StartUpScript("", "Image Size Exceeds 500KB..ToResize Images Goto : http://www.picresize.com")
                '    Return False
                'ElseIf (cersanpath1.PostedFile.ContentLength / 1024) > 2000 Then
                '    StartUpScript("", "Image Size Exceeds 500KB..ToResize Images Goto : http://www.picresize.com")
                '    Return False
                'ElseIf (cerstrpath1.PostedFile.ContentLength / 1024) > 2000 Then
                '    StartUpScript("", "Image Size Exceeds 500KB..ToResize Images Goto : http://www.picresize.com")
                '    Return False
                'ElseIf (cermunpath1.PostedFile.ContentLength / 1024) > 2000 Then
                '    StartUpScript("", "Image Size Exceeds 500KB..ToResize Images Goto : http://www.picresize.com")
                '    Return False
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub SetViewStateVariables()
        Try
            If Not Request.QueryString("MODE") Is Nothing Then MODE = Request.QueryString("MODE")
            If Not Request.QueryString("SLNO") Is Nothing Then SLNO = Request.QueryString("SLNO")
            If Not Request.QueryString("MNO") Is Nothing Then MNO = Request.QueryString("MNO")
            If Not Request.QueryString("PageIndex") Is Nothing Then PageIndex = Request.QueryString("PageIndex")

            Me.ViewState("MODE") = MODE
            Me.ViewState("SLNO") = SLNO
            Me.ViewState("MNO") = MNO
            Me.ViewState("PageIndex") = PageIndex

            If MNO = 1 Then
                lblHeading.Text = "Society Details&nbsp;"
                'Else
                '   lblHeading.Text = "Death&nbsp;Cause&nbsp;(Single Mode)"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetViewStateVariables()
        Try
            MODE = Me.ViewState("MODE")
            SLNO = Me.ViewState("SLNO")
            MNO = Me.ViewState("MNO")

            PageIndex = Me.ViewState("PageIndex")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GettingFileExtension() As String
        Try
            Dim UpLoadFilePath As String = cerfirepath1.PostedFile.FileName

            If UpLoadFilePath <> "" Then
                Dim SplitFilePath() As String = StrReverse(UpLoadFilePath).Split(".")
                If SplitFilePath.Length > 0 Then
                    Return "." & StrReverse(SplitFilePath(0))
                Else
                    Return ""
                End If
            Else
                Return ""
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function SaveText2() As Boolean
        Try

            Dim x As File
            Dim StrSql As String

            If Not Directory.Exists("F:/BOARD_CERT/") Then
                Directory.CreateDirectory("F:/BOARD_CERT/")
            End If

            Dim FileDum As File
            objMaster = New ClsBoarddt

            If cerfirepath1.PostedFile.FileName <> "" Then

                Dim FileExtn As String = GetExtension(cerfirepath1.PostedFile.FileName)
                Dim STRFIR As String = Session("CCODE") + "-1"

                If Not Directory.Exists("F:/BOARD_CERT") Then
                    Directory.CreateDirectory("F:/BOARD_CERT")
                End If
                If FileDum.Exists("F:/BOARD_CERT/" & STRFIR + FileExtn.ToString) Then
                    FileDum.Delete("F:/BOARD_CERT/" & STRFIR + FileExtn.ToString)
                End If
                cerfirepath1.PostedFile.SaveAs("F:/BOARD_CERT/" & STRFIR + FileExtn.ToString)
                FILEPATH = "HTTP://" & Request.ServerVariables("HTTP_HOST") & "\BOARD_CERT\" & STRFIR + FileExtn.ToString
                StrSql = objMaster.PATH_SAVE("UPDATE M_CERTIFICATES_DT SET FIREPATH='" & " F:/BOARD_CERT/" & STRFIR + FileExtn.ToString & "' WHERE CCODE=" & Session("CCODE"))
            End If
            If cersanpath1.PostedFile.FileName <> "" Then

                Dim FileExtnSan As String = GetExtension(cersanpath1.PostedFile.FileName)
                Dim STRSAN As String = Session("CCODE") + "-2"

                If Not Directory.Exists("F:/BOARD_CERT") Then
                    Directory.CreateDirectory("F:/BOARD_CERT")
                End If
                If FileDum.Exists("F:/BOARD_CERT/" & STRSAN + FileExtnSan.ToString) Then
                    FileDum.Delete("F:/BOARD_CERT/" & STRSAN + FileExtnSan.ToString)
                End If
                cersanpath1.PostedFile.SaveAs("F:/BOARD_CERT/" & STRSAN + FileExtnSan.ToString)
                FILEPATH = "HTTP://" & Request.ServerVariables("HTTP_HOST") & "\BOARD_CERT\" & STRSAN + FileExtnSan.ToString
                StrSql = objMaster.PATH_SAVE("UPDATE M_CERTIFICATES_DT SET SANITORYPATH='" & " F:/BOARD_CERT/" & STRSAN + FileExtnSan.ToString & "' WHERE CCODE=" & Session("CCODE"))
            End If

            If cerstrpath1.PostedFile.FileName <> "" Then

                Dim FileExtnStr As String = GetExtension(cerstrpath1.PostedFile.FileName)
                Dim STRSTR As String = Session("CCODE") + "-3"

                If Not Directory.Exists("F:/BOARD_CERT") Then
                    Directory.CreateDirectory("F:/BOARD_CERT")
                End If
                If FileDum.Exists("F:/BOARD_CERT/" & STRSTR + FileExtnStr.ToString) Then
                    FileDum.Delete("F:/BOARD_CERT/" & STRSTR + FileExtnStr.ToString)
                End If
                cerstrpath1.PostedFile.SaveAs("F:/BOARD_CERT/" & STRSTR + FileExtnStr.ToString)
                FILEPATH = "HTTP://" & Request.ServerVariables("HTTP_HOST") & "\BOARD_CERT\" & STRSTR + FileExtnStr.ToString
                StrSql = objMaster.PATH_SAVE("UPDATE M_CERTIFICATES_DT SET STRUCTURALPATH='" & " F:/BOARD_CERT/" & STRSTR + FileExtnStr.ToString & "' WHERE CCODE=" & Session("CCODE"))
            End If

            If cermunpath1.PostedFile.FileName <> "" Then
                Dim FileExtnMun As String = GetExtension(cermunpath1.PostedFile.FileName)
                Dim STRMUN As String = Session("CCODE") + "-4"
                If Not Directory.Exists("F:/BOARD_CERT") Then
                    Directory.CreateDirectory("F:/BOARD_CERT")
                End If
                If FileDum.Exists("F:/BOARD_CERT/" & STRMUN + FileExtnMun.ToString) Then
                    FileDum.Delete("F:/BOARD_CERT/" & STRMUN + FileExtnMun.ToString)
                End If
                cermunpath1.PostedFile.SaveAs("F:/BOARD_CERT/" & STRMUN + FileExtnMun.ToString)
                FILEPATH = "HTTP://" & Request.ServerVariables("HTTP_HOST") & "\BOARD_CERT\" & STRMUN + FileExtnMun.ToString
                StrSql = objMaster.PATH_SAVE("UPDATE M_CERTIFICATES_DT SET NOCPATH='" & " F:/BOARD_CERT/" & STRMUN + FileExtnMun.ToString & "' WHERE CCODE=" & Session("CCODE"))
            End If


            Return True

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function SaveText() As Boolean
        Try

            Dim x As File
            Dim StrSql As String

            If Not Directory.Exists("F:/BOARD_CERT/") Then
                Directory.CreateDirectory("F:/BOARD_CERT/")
            End If

            Dim FileDum As File
            objMaster = New ClsBoarddt



            If cerfirepath1.PostedFile.FileName <> "" Then

                Dim FlName As String
                Dim FlLen As Integer

                If Not IsNothing(cerfirepath1.PostedFile) Then
                    FlLen = cerfirepath1.PostedFile.ContentLength
                Else
                    FlLen = 0
                End If

                Dim FileExtn As String = GetExtension(cerfirepath1.PostedFile.FileName)
                Dim STRFIR As String = Session("CCODE") + "-1"

                If Not Directory.Exists("F:/BOARD_CERT") Then
                    Directory.CreateDirectory("F:/BOARD_CERT")
                End If
                If FileDum.Exists("F:/BOARD_CERT/" & STRFIR + FileExtn.ToString) Then
                    FileDum.Delete("F:/BOARD_CERT/" & STRFIR + FileExtn.ToString)
                End If
                cerfirepath1.PostedFile.SaveAs("F:/BOARD_CERT/" & STRFIR + FileExtn.ToString)
                'FILEPATH = "HTTP://" & Request.ServerVariables("HTTP_HOST") & "\BOARD_CERT\" & STRFIR + FileExtn.ToString
                StrSql = objMaster.PATH_SAVE("UPDATE M_CERTIFICATES_DT SET FIREPATH='" & " F:/BOARD_CERT/" & STRFIR + FileExtn.ToString & "' WHERE CCODE=" & Session("CCODE"))
            Else
                StartUpScript(iBtnSave.ID, "Image Size Exceeds 500KB..ToResize Images Goto : http://www.picresize.com")
            End If

            If cersanpath1.PostedFile.FileName <> "" Then

                Dim FileExtnSan As String = GetExtension(cersanpath1.PostedFile.FileName)
                Dim STRSAN As String = Session("CCODE") + "-2"

                If Not Directory.Exists("F:/BOARD_CERT") Then
                    Directory.CreateDirectory("F:/BOARD_CERT")
                End If
                If FileDum.Exists("F:/BOARD_CERT/" & STRSAN + FileExtnSan.ToString) Then
                    FileDum.Delete("F:/BOARD_CERT/" & STRSAN + FileExtnSan.ToString)
                End If
                cersanpath1.PostedFile.SaveAs("F:/BOARD_CERT/" & STRSAN + FileExtnSan.ToString)
                '  FILEPATH = "HTTP://" & Request.ServerVariables("HTTP_HOST") & "\BOARD_CERT\" & STRSAN + FileExtnSan.ToString
                StrSql = objMaster.PATH_SAVE("UPDATE M_CERTIFICATES_DT SET SANITORYPATH='" & " F:/BOARD_CERT/" & STRSAN + FileExtnSan.ToString & "' WHERE CCODE=" & Session("CCODE"))
            Else
                StartUpScript(iBtnSave.ID, "Image Size Exceeds 500KB..ToResize Images Goto : http://www.picresize.com")
            End If

            If cerstrpath1.PostedFile.FileName <> "" Then

                Dim FileExtnStr As String = GetExtension(cerstrpath1.PostedFile.FileName)
                Dim STRSTR As String = Session("CCODE") + "-3"

                If Not Directory.Exists("F:/BOARD_CERT") Then
                    Directory.CreateDirectory("F:/BOARD_CERT")
                End If
                If FileDum.Exists("F:/BOARD_CERT/" & STRSTR + FileExtnStr.ToString) Then
                    FileDum.Delete("F:/BOARD_CERT/" & STRSTR + FileExtnStr.ToString)
                End If
                cerstrpath1.PostedFile.SaveAs("F:/BOARD_CERT/" & STRSTR + FileExtnStr.ToString)
                'FILEPATH = "HTTP://" & Request.ServerVariables("HTTP_HOST") & "\BOARD_CERT\" & STRSTR + FileExtnStr.ToString
                StrSql = objMaster.PATH_SAVE("UPDATE M_CERTIFICATES_DT SET STRUCTURALPATH='" & " F:/BOARD_CERT/" & STRSTR + FileExtnStr.ToString & "' WHERE CCODE=" & Session("CCODE"))
            Else
                StartUpScript(iBtnSave.ID, "Image Size Exceeds 500KB..ToResize Images Goto : http://www.picresize.com")
            End If

            If cermunpath1.PostedFile.FileName <> "" Then
                Dim FileExtnMun As String = GetExtension(cermunpath1.PostedFile.FileName)
                Dim STRMUN As String = Session("CCODE") + "-4"
                If Not Directory.Exists("F:/BOARD_CERT") Then
                    Directory.CreateDirectory("F:/BOARD_CERT")
                End If
                If FileDum.Exists("F:/BOARD_CERT/" & STRMUN + FileExtnMun.ToString) Then
                    FileDum.Delete("F:/BOARD_CERT/" & STRMUN + FileExtnMun.ToString)
                End If
                cermunpath1.PostedFile.SaveAs("F:/BOARD_CERT/" & STRMUN + FileExtnMun.ToString)
                'FILEPATH = "HTTP://" & Request.ServerVariables("HTTP_HOST") & "\BOARD_CERT\" & STRMUN + FileExtnMun.ToString
                StrSql = objMaster.PATH_SAVE("UPDATE M_CERTIFICATES_DT SET NOCPATH='" & " F:/BOARD_CERT/" & STRMUN + FileExtnMun.ToString & "' WHERE CCODE=" & Session("CCODE"))
            Else
                StartUpScript(iBtnSave.ID, "Image Size Exceeds 500KB..ToResize Images Goto : http://www.picresize.com")
            End If

            'NEW 

            If cerAffpath1.PostedFile.FileName <> "" Then
                Dim FileExtnAff As String = GetExtension(cerAffpath1.PostedFile.FileName)
                Dim STRMUN As String = Session("CCODE") + "-5"
                If Not Directory.Exists("F:/BOARD_CERT") Then
                    Directory.CreateDirectory("F:/BOARD_CERT")
                End If
                If FileDum.Exists("F:/BOARD_CERT/" & STRMUN + FileExtnAff.ToString) Then
                    FileDum.Delete("F:/BOARD_CERT/" & STRMUN + FileExtnAff.ToString)
                End If
                cerAffpath1.PostedFile.SaveAs("F:/BOARD_CERT/" & STRMUN + FileExtnAff.ToString)
                'FILEPATH = "HTTP://" & Request.ServerVariables("HTTP_HOST") & "\BOARD_CERT\" & STRMUN + FileExtnMun.ToString
                StrSql = objMaster.PATH_SAVE("UPDATE M_CERTIFICATES_DT SET AFFPATH='" & " F:/BOARD_CERT/" & STRMUN + FileExtnAff.ToString & "' WHERE CCODE=" & Session("CCODE"))
            Else
                StartUpScript(iBtnSave.ID, "Image Size Exceeds 500KB..ToResize Images Goto : http://www.picresize.com")
            End If

            If cersecpath1.PostedFile.FileName <> "" Then
                Dim FileExtnsec As String = GetExtension(cersecpath1.PostedFile.FileName)
                Dim STRMUN As String = Session("CCODE") + "-6"
                If Not Directory.Exists("F:/BOARD_CERT") Then
                    Directory.CreateDirectory("F:/BOARD_CERT")
                End If
                If FileDum.Exists("F:/BOARD_CERT/" & STRMUN + FileExtnsec.ToString) Then
                    FileDum.Delete("F:/BOARD_CERT/" & STRMUN + FileExtnsec.ToString)
                End If
                cersecpath1.PostedFile.SaveAs("F:/BOARD_CERT/" & STRMUN + FileExtnsec.ToString)
                'FILEPATH = "HTTP://" & Request.ServerVariables("HTTP_HOST") & "\BOARD_CERT\" & STRMUN + FileExtnMun.ToString
                StrSql = objMaster.PATH_SAVE("UPDATE M_CERTIFICATES_DT SET SECTIONSPATH='" & " F:/BOARD_CERT/" & STRMUN + FileExtnsec.ToString & "' WHERE CCODE=" & Session("CCODE"))
            Else
                StartUpScript(iBtnSave.ID, "Image Size Exceeds 500KB..ToResize Images Goto : http://www.picresize.com")
            End If

            If cerleasepath1.PostedFile.FileName <> "" Then
                Dim FileExtnlease As String = GetExtension(cerleasepath1.PostedFile.FileName)
                Dim STRMUN As String = Session("CCODE") + "-7"
                If Not Directory.Exists("F:/BOARD_CERT") Then
                    Directory.CreateDirectory("F:/BOARD_CERT")
                End If
                If FileDum.Exists("F:/BOARD_CERT/" & STRMUN + FileExtnlease.ToString) Then
                    FileDum.Delete("F:/BOARD_CERT/" & STRMUN + FileExtnlease.ToString)
                End If
                cerleasepath1.PostedFile.SaveAs("F:/BOARD_CERT/" & STRMUN + FileExtnlease.ToString)
                'FILEPATH = "HTTP://" & Request.ServerVariables("HTTP_HOST") & "\BOARD_CERT\" & STRMUN + FileExtnMun.ToString
                StrSql = objMaster.PATH_SAVE("UPDATE M_CERTIFICATES_DT SET LEASEPATH='" & " F:/BOARD_CERT/" & STRMUN + FileExtnlease.ToString & "' WHERE CCODE=" & Session("CCODE"))
            Else
                StartUpScript(iBtnSave.ID, "Image Size Exceeds 500KB..ToResize Images Goto : http://www.picresize.com")
            End If

            If cerfdrpath1.PostedFile.FileName <> "" Then
                Dim FileExtnfdr As String = GetExtension(cerfdrpath1.PostedFile.FileName)
                Dim STRMUN As String = Session("CCODE") + "-8"
                If Not Directory.Exists("F:/BOARD_CERT") Then
                    Directory.CreateDirectory("F:/BOARD_CERT")
                End If
                If FileDum.Exists("F:/BOARD_CERT/" & STRMUN + FileExtnfdr.ToString) Then
                    FileDum.Delete("F:/BOARD_CERT/" & STRMUN + FileExtnfdr.ToString)
                End If
                cerfdrpath1.PostedFile.SaveAs("F:/BOARD_CERT/" & STRMUN + FileExtnfdr.ToString)
                'FILEPATH = "HTTP://" & Request.ServerVariables("HTTP_HOST") & "\BOARD_CERT\" & STRMUN + FileExtnMun.ToString
                StrSql = objMaster.PATH_SAVE("UPDATE M_CERTIFICATES_DT SET FDRPATH='" & " F:/BOARD_CERT/" & STRMUN + FileExtnfdr.ToString & "' WHERE CCODE=" & Session("CCODE"))
            Else
                StartUpScript(iBtnSave.ID, "Image Size Exceeds 500KB..ToResize Images Goto : http://www.picresize.com")
            End If

            Return True

        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
            If Session("USERID") Is Nothing Then
                OracleLogFile("USERID := " & "SRIHARI" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            Else
                OracleLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
            End If
        End Try

    End Function


    Private Sub SaveFilePath(ByVal pFILENO As Long, ByVal pFILEEXTENSION As String)
        Try


            Dim pFILEPATH As String = "F:\BOARD_CERT\"

            If pFILENO > 0 AndAlso pFILEEXTENSION <> "" Then
                If Not Directory.Exists(pFILEPATH) Then
                    Directory.CreateDirectory(pFILEPATH)
                End If
                cerfirepath1.PostedFile.SaveAs(pFILEPATH & pFILENO & pFILEEXTENSION)
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


#End Region

#Region "Fill Methods"

    Private Sub FillGrid(ByVal PageIndex As Integer)
        Dim i, j As Integer
        Dim SqlStr1 As String
        Try

            If lstmCode.Text <> "" Then

                'For m As Integer = 0 To lstmCode.Items.Count - 1
                '    If lstmCode.Items(m).Selected Then
                '        SqlStr1 += lstmCode.Items(m).Value + ","
                '    End If
                'Next
                'SqlStr1 = SqlStr1.TrimEnd(",")
                'StrSql = "SELECT CER.CERTFSLNO, CER.CCODE,CLG.COLLEGENAME  FROM M_CERTIFICATES_DT CER,EXAM_BOARDCOLLEGE_MT CLG WHERE  CER.CCODE=CLG.CODE AND CER.CCODE IN (" & SqlStr1 & ") ORDER BY CER.CCODE"
                StrSql = "SELECT CER.CERTFSLNO, CER.CCODE,CLG.COLLEGENAME  FROM M_CERTIFICATES_DT CER,EXAM_BOARDCOLLEGE_MT CLG WHERE  CER.CCODE=CLG.CODE AND CER.CCODE=" & lstmCode.Text & " ORDER BY CER.CCODE"
            Else
                StrSql = "SELECT CER.CERTFSLNO, CER.CCODE,CLG.COLLEGENAME  FROM M_CERTIFICATES_DT CER,EXAM_BOARDCOLLEGE_MT CLG WHERE  CER.CCODE=CLG.CODE ORDER BY CER.CCODE"
            End If


            ObjResult = New Utility

            DsSearchResult = ObjResult.DataSet_OneFetch(StrSql)

            Me.ViewState("DsSearchResult") = DsSearchResult

            If Not DsSearchResult Is Nothing Then
                '' Setting Page Indexs
                If (DsSearchResult.Tables(0).Rows.Count - 1) / 10 < PageIndex Then

                    If ((DsSearchResult.Tables(0).Rows.Count - 1) / 10) <= 1 Then
                        PageIndex = 0
                    Else
                        PageIndex = PageIndex - 1
                    End If
                End If

                dgGridSection.CurrentPageIndex = PageIndex
                dgGridSection.DataSource = DsSearchResult
                dgGridSection.DataBind()

                Me.ViewState("DsSearchResult") = DsSearchResult
            End If
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'Private Sub MultiFillCode()
    '    Try
    '        Dim SqlStr As String
    '        Dim I As Integer

    '        SqlStr = "SELECT CER.CCODE FROM M_CERTIFICATES_DT CER,EXAM_BOARDCOLLEGE_MT CLG WHERE  CER.CCODE=CLG.CODE ORDER BY CER.CCODE"
    '        objReport = New Utility
    '        DSet = objReport.DataSet_OneFetch(SqlStr)
    '        lstmCode.DataSource = DSet.Tables(0)
    '        lstmCode.DataTextField = "CCODE"
    '        lstmCode.DataValueField = "CCODE"
    '        lstmCode.DataBind()

    '    Catch ex As Exception

    '    End Try

    'End Sub

#End Region

#Region "Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Try
            dgGridSection.AllowPaging = True
            From = Request.QueryString("From")

            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                ButtonsHiding(Me.Page)

                Me.ViewState("PageIndex") = PageIndex

                If Me.ViewState("MODE") = "EDIT" Then
                    FillControls()
                End If
                'MultiFillCode()
                FillGrid(PageIndex)
                Table4.Visible = False
                FillFire()
            Else
                PageIndex = dgGridSection.CurrentPageIndex
                GetViewStateVariables()
                'FillFire()
                'MODE = "NEW"
                PageIndex = CInt(Me.ViewState("PageIndex"))
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

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Try
           

            If Not FormValidations() Then Exit Sub
            objMaster = New ClsBoarddt
            
            Dim extension, Fcerfirepath1, Fcersanpath1, Fcerstrpath1, Fcermunpath1, FcerAffiliationpath1, FcerSectionspath1, FcerRegisteredpath1, FcerFDRpath1 As String
            Fcerfirepath1 = Path.GetFileName(cerfirepath1.PostedFile.FileName)
            Dim contentType1 As String = cerfirepath1.PostedFile.ContentType
            Fcersanpath1 = Path.GetFileName(cersanpath1.PostedFile.FileName)
            Dim contentType2 As String = cersanpath1.PostedFile.ContentType
            Fcerstrpath1 = Path.GetFileName(cerstrpath1.PostedFile.FileName)
            Dim contentType3 As String = cerstrpath1.PostedFile.ContentType
            Fcermunpath1 = Path.GetFileName(cermunpath1.PostedFile.FileName)
            Dim contentType4 As String = cermunpath1.PostedFile.ContentType

            FcerAffiliationpath1 = Path.GetFileName(cerAffpath1.PostedFile.FileName)
            Dim contentType5 As String = cerAffpath1.PostedFile.ContentType

            FcerSectionspath1 = Path.GetFileName(cersecpath1.PostedFile.FileName)
            Dim contentType6 As String = cersecpath1.PostedFile.ContentType

            FcerRegisteredpath1 = Path.GetFileName(cerleasepath1.PostedFile.FileName)
            Dim contentType7 As String = cerleasepath1.PostedFile.ContentType

            FcerFDRpath1 = Path.GetFileName(cerfdrpath1.PostedFile.FileName)
            Dim contentType8 As String = cerfdrpath1.PostedFile.ContentType



            If Fcerfirepath1 = "" Then

                bool = True

            Else
                If contentType1 = "application/pdf" Then

                    bool = True

                Else
                    bool = False

                End If
            End If

            If Fcersanpath1 = "" Then

                bool1 = True

            Else
                If contentType2 = "application/pdf" Then

                    bool1 = True

                Else
                    bool1 = False

                End If
            End If

            If Fcerstrpath1 = "" Then

                bool2 = True

            Else
                If contentType3 = "application/pdf" Then

                    bool2 = True

                Else
                    bool2 = False

                End If
            End If
            If Fcermunpath1 = "" Then

                bool3 = True

            Else
                If contentType4 = "application/pdf" Then

                    bool3 = True

                Else
                    bool3 = False

                End If
            End If

            If FcerAffiliationpath1 = "" Then

                bool4 = True

            Else
                If contentType5 = "application/pdf" Then

                    bool4 = True

                Else
                    bool4 = False

                End If
            End If


            If FcerSectionspath1 = "" Then

                bool5 = True

            Else
                If contentType6 = "application/pdf" Then

                    bool5 = True

                Else
                    bool5 = False

                End If
            End If


            If FcerRegisteredpath1 = "" Then

                bool6 = True

            Else
                If contentType7 = "application/pdf" Then

                    bool6 = True

                Else
                    bool6 = False

                End If
            End If

            If FcerFDRpath1 = "" Then

                bool7 = True

            Else
                If contentType8 = "application/pdf" Then

                    bool7 = True

                Else
                    bool7 = False

                End If
            End If

            If (bool = True And bool1 = True And bool2 = True And bool3 = True And bool4 = True And bool5 = True And bool6 = True And bool7 = True) Then

                If (Me.ViewState("MODE")) = "EDIT" Then

                    ' FileExtension = GettingFileExtension()

                    RtnVal = objMaster.CERTIFICT_UpdateNew(SetEntries())
                    If RtnVal = 1 Then
                        'SaveFilePath(RtnVal, FileExtension)
                        StartUpScript(iBtnSave.ID, "Record Updated Successfully.")
                        ClearControls()
                        FillGrid(PageIndex)
                        Table4.Visible = False
                    Else
                        StartUpScript(iBtnSave.ID, "Record Not Updated.")
                    End If
                    SaveText()
                ElseIf (Me.ViewState("MODE")) = "NEW" Then
                    'ElseIf FLAG = Val(1) Then
                    RtnVal = objMaster.CERTIFICT_InsertNew(SetEntries())
                    If RtnVal = 1 Then
                        StartUpScript(iBtnSave.ID, "Record Saved Successfully.")
                        ClearControls()
                        FillGrid(PageIndex)
                        Table4.Visible = False
                    Else
                        StartUpScript(iBtnSave.ID, "Record Not Saved.")
                    End If
                    SaveText()
                End If

            Else
                StartUpScript(iBtnSave.ID, "Please upload Pdf File only.")
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
                StartUpScript("", GeneralErrorMessage(ex.Message))
                If Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & "ADMIN" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                     "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                Else
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                     "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                End If
            End If
        End Try
    End Sub

    Private Sub iBtnAdd_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnAdd.Click
        Try
            FillFire()
            Me.ViewState("MODE") = "NEW"
            Table4.Visible = True
            ClearControls()
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                StartUpScript(iBtnAdd.ID, " Transaction  Failed ")
            End If
        End Try
    End Sub

    Private Sub imgBtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnGo.Click
        Try

            If Trim(Txtccode.Text) <> "" Then
                GenerateSqlQuery()
            Else
                Exit Sub
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
                StartUpScript("", GeneralErrorMessage(ex.Message))
                If Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & "ADMIN" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                     "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                Else
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                     "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                End If
            End If
        End Try
    End Sub

    Private Sub imgBtnGoo1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnGoo1.Click
        Try
            FillGrid(PageIndex)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Sql Query"

    Private Sub GenerateSqlQuery()
        Try

            Dim SqlStr, SqlStr1 As String
            Dim I As Integer

            SqlStr = "SELECT COLLEGENAME FROM EXAM_BOARDCOLLEGE_MT WHERE CODE=" & Val(Txtccode.Text)

            ObjResult = New Utility

            DsResult = ObjResult.DataSet_Fetch(SqlStr)
            If DsResult.Tables(0).Rows.Count > 0 Then
                LBLCLGNAME.Text = DsResult.Tables(0).Rows(0)("COLLEGENAME")

                Session("DsResult") = DsResult.Tables(0)
            Else
                StartUpScript("", " Given College Code is Not Existed")

            End If

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

#Region "Grid Events"

    Private Sub dgGridSection_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGridSection.EditCommand
        Try
            Me.ViewState("MODE") = "EDIT"
            SLNO = Val(dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text)
            Me.ViewState("SLNO") = SLNO
            Table4.Visible = True

            'drpsant2.Visible = True
            'Drpfire2.Visible = True
            'drpstruc2.Visible = True
            'drpnoc2.Visible = True
            ClearControls()
            FillControls()
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

    Private Sub dgGridSection_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGridSection.DeleteCommand
        Try
            objMaster = New ClsBoarddt
            RtnVal = objMaster.CERTIFICT_DELETE(dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text)

            If RtnVal = 1 Then
                FillGrid(PageIndex)
                StartUpScript("", "Record Deleted Successfully")
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

    Private Sub dgGridSection_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgGridSection.PageIndexChanged
        Try
            dgGridSection.CurrentPageIndex = e.NewPageIndex
            Me.ViewState("PageIndex") = e.NewPageIndex
            DsSearchResult = Me.ViewState("DsSearchResult")
            dgGridSection.DataSource = DsSearchResult
            dgGridSection.DataBind()
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

#Region "DROPS"
    Private Sub FillFire()
        Try
            'drpfire.Items.Clear()
            'drpfire.Items.Insert(0, New ListItem("--Select--", 0))
            'drpfire.Items.Insert(1, New ListItem("Challan Paid", 1))
            'drpfire.Items.Insert(2, New ListItem("Challan Not Paid", 2))
            'drpfire.Items.Insert(3, New ListItem("NOC-Submitted", 1))
            'drpfire.Items.Insert(4, New ListItem("NOC-Not Submitted", 2))

            Drpfire1.Items.Clear()
            Drpfire1.Items.Insert(0, New ListItem("--Select--", 0))
            Drpfire1.Items.Insert(1, New ListItem("Yes", 1))
            Drpfire1.Items.Insert(2, New ListItem("No", 2))

            drpsant1.Items.Clear()
            drpsant1.Items.Insert(0, New ListItem("--Select--", 0))
            drpsant1.Items.Insert(1, New ListItem("Yes", 1))
            drpsant1.Items.Insert(2, New ListItem("No", 2))

            drpstruc1.Items.Clear()
            drpstruc1.Items.Insert(0, New ListItem("--Select--", 0))
            drpstruc1.Items.Insert(1, New ListItem("Yes", 1))
            drpstruc1.Items.Insert(2, New ListItem("No", 2))

            drpnoc1.Items.Clear()
            drpnoc1.Items.Insert(0, New ListItem("--Select--", 0))
            drpnoc1.Items.Insert(1, New ListItem("Yes", 1))
            drpnoc1.Items.Insert(2, New ListItem("No", 2))

            drpAff.Items.Clear()
            drpAff.Items.Insert(0, New ListItem("--Select--", 0))
            drpAff.Items.Insert(1, New ListItem("Yes", 1))
            drpAff.Items.Insert(2, New ListItem("No", 2))

            drpaddsec.Items.Clear()
            drpaddsec.Items.Insert(0, New ListItem("--Select--", 0))
            drpaddsec.Items.Insert(1, New ListItem("Yes", 1))
            drpaddsec.Items.Insert(2, New ListItem("No", 2))


            drplease.Items.Clear()
            drplease.Items.Insert(0, New ListItem("--Select--", 0))
            drplease.Items.Insert(1, New ListItem("Yes", 1))
            drplease.Items.Insert(2, New ListItem("No", 2))

            drpfdr.Items.Clear()
            drpfdr.Items.Insert(0, New ListItem("--Select--", 0))
            drpfdr.Items.Insert(1, New ListItem("Yes", 1))
            drpfdr.Items.Insert(2, New ListItem("No", 2))

            Drpfire2.Items.Clear()
            Drpfire2.Items.Insert(0, New ListItem("--Select--", 0))
            Drpfire2.Items.Insert(1, New ListItem("Submitted", 1))
            Drpfire2.Items.Insert(2, New ListItem("Not Submitted", 2))


            drpsant2.Items.Clear()
            drpsant2.Items.Insert(0, New ListItem("--Select--", 0))
            drpsant2.Items.Insert(1, New ListItem("Submitted", 1))
            drpsant2.Items.Insert(2, New ListItem("Not Submitted", 2))

            drpstruc2.Items.Clear()
            drpstruc2.Items.Insert(0, New ListItem("--Select--", 0))
            drpstruc2.Items.Insert(1, New ListItem("Submitted", 1))
            drpstruc2.Items.Insert(2, New ListItem("Not Submitted", 2))

            drpnoc2.Items.Clear()
            drpnoc2.Items.Insert(0, New ListItem("--Select--", 0))
            drpnoc2.Items.Insert(1, New ListItem("Submitted", 1))
            drpnoc2.Items.Insert(2, New ListItem("Not Submitted", 2))

            drpaffsub.Items.Clear()
            drpaffsub.Items.Insert(0, New ListItem("--Select--", 0))
            drpaffsub.Items.Insert(1, New ListItem("Submitted", 1))
            drpaffsub.Items.Insert(2, New ListItem("Not Submitted", 2))

            drpsubadd.Items.Clear()
            drpsubadd.Items.Insert(0, New ListItem("--Select--", 0))
            drpsubadd.Items.Insert(1, New ListItem("Submitted", 1))
            drpsubadd.Items.Insert(2, New ListItem("Not Submitted", 2))

            drpleasesub.Items.Clear()
            drpleasesub.Items.Insert(0, New ListItem("--Select--", 0))
            drpleasesub.Items.Insert(1, New ListItem("Submitted", 1))
            drpleasesub.Items.Insert(2, New ListItem("Not Submitted", 2))

            drpfdrsub.Items.Clear()
            drpfdrsub.Items.Insert(0, New ListItem("--Select--", 0))
            drpfdrsub.Items.Insert(1, New ListItem("Submitted", 1))
            drpfdrsub.Items.Insert(2, New ListItem("Not Submitted", 2))
        Catch ex As Exception
            StartUpScript("", ex.Message)
        End Try
    End Sub

    Private Sub drpsant1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpsant1.SelectedIndexChanged

        If drpsant1.SelectedValue = 1 Then
            drpsant2.Enabled = True
            txtstfmdate.Enabled = True
            txtsttodate.Enabled = True
            'cersanpath1.Disabled = False
            HypNew2.Enabled = True
        Else
            drpsant2.Enabled = False
            txtstfmdate.Enabled = False
            txtsttodate.Enabled = False
            'cersanpath1.Disabled = True
            HypNew2.Enabled = False

        End If


    End Sub

    Private Sub Drpfire1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Drpfire1.SelectedIndexChanged
        Try

            If Drpfire1.SelectedValue = 1 Then
                Drpfire2.Enabled = True
                txtfirfmdate.Enabled = True
                txtfirtodate.Enabled = True
                'cerfirepath1.Disabled = False
                HypNew.Enabled = True

            Else
                Drpfire2.Enabled = False
                txtfirfmdate.Enabled = False
                txtfirtodate.Enabled = False
                ' cerfirepath1.Disabled = True
                HypNew.Enabled = False

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub drpstruc1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpstruc1.SelectedIndexChanged
        If drpstruc1.SelectedValue = 1 Then
            drpstruc2.Enabled = True
            txtstrfmdate.Enabled = True
            txtstrtodate.Enabled = True
            'cerstrpath1.Disabled = False
            HypNew3.Enabled = True

        Else
            drpstruc2.Enabled = False
            txtstrfmdate.Enabled = False
            txtstrtodate.Enabled = False
            'cerstrpath1.Disabled = True
            HypNew3.Enabled = False

        End If
    End Sub

    Private Sub drpnoc1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpnoc1.SelectedIndexChanged
        If drpnoc1.SelectedValue = 1 Then
            drpnoc2.Enabled = True
            txtmunfmdate.Enabled = True
            txtmuntodate.Enabled = True
            'cermunpath1.Disabled = False
            HypNew4.Enabled = True

        Else
            drpnoc2.Enabled = False
            txtmunfmdate.Enabled = False
            txtmuntodate.Enabled = False
            'cermunpath1.Disabled = True
            HypNew4.Enabled = False

        End If
    End Sub
#End Region


    Protected Sub but1_Click(sender As Object, e As EventArgs) Handles but1.Click

        Dim queryString As String = "../BoardSection/Popcertificate.aspx?image1=" + HypNew.NavigateUrl
        Dim newWin As String = " window.open('" & queryString & "', null,'status:no;dialogWidth:250px;dialogHeight:300px;dialogHide:true;help:no;scroll:yes');"
        ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
    End Sub

   

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim queryString As String = "../BoardSection/Popcertificate.aspx?image1=" + HypNew2.NavigateUrl
        Dim newWin As String = " window.open('" & queryString & "', null,'status:no;dialogWidth:250px;dialogHeight:300px;dialogHide:true;help:no;scroll:yes');"
        ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim queryString As String = "../BoardSection/Popcertificate.aspx?image1=" + HypNew3.NavigateUrl
        Dim newWin As String = " window.open('" & queryString & "', null,'status:no;dialogWidth:250px;dialogHeight:300px;dialogHide:true;help:no;scroll:yes');"
        ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim queryString As String = "../BoardSection/Popcertificate.aspx?image1=" + HypNew4.NavigateUrl
        Dim newWin As String = " window.open('" & queryString & "', null,'status:no;dialogWidth:250px;dialogHeight:300px;dialogHide:true;help:no;scroll:yes');"
        ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
    End Sub

    Protected Sub ButAff_Click(sender As Object, e As EventArgs) Handles ButAff.Click
        Dim queryString As String = "../BoardSection/Popcertificate.aspx?image1=" + HyperLink1.NavigateUrl
        Dim newWin As String = " window.open('" & queryString & "', null,'status:no;dialogWidth:250px;dialogHeight:300px;dialogHide:true;help:no;scroll:yes');"
        ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
    End Sub

    Protected Sub butsec_Click(sender As Object, e As EventArgs) Handles butsec.Click
        Dim queryString As String = "../BoardSection/Popcertificate.aspx?image1=" + HyperLink2.NavigateUrl
        Dim newWin As String = " window.open('" & queryString & "', null,'status:no;dialogWidth:250px;dialogHeight:300px;dialogHide:true;help:no;scroll:yes');"
        ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
    End Sub

    Protected Sub butlease_Click(sender As Object, e As EventArgs) Handles butlease.Click
        Dim queryString As String = "../BoardSection/Popcertificate.aspx?image1=" + HyperLink3.NavigateUrl
        Dim newWin As String = " window.open('" & queryString & "', null,'status:no;dialogWidth:250px;dialogHeight:300px;dialogHide:true;help:no;scroll:yes');"
        ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
    End Sub

    Protected Sub Butfdr_Click(sender As Object, e As EventArgs) Handles Butfdr.Click
        Dim queryString As String = "../BoardSection/Popcertificate.aspx?image1=" + HyperLink5.NavigateUrl
        Dim newWin As String = " window.open('" & queryString & "', null,'status:no;dialogWidth:250px;dialogHeight:300px;dialogHide:true;help:no;scroll:yes');"
        ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
    End Sub

    Protected Sub drpAff_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpAff.SelectedIndexChanged
        If drpAff.SelectedValue = 1 Then
            drpaffsub.Enabled = True
            txtafffrom.Enabled = True
            txtaffto.Enabled = True
            'cersanpath1.Disabled = False
            HyperLink1.Enabled = True
        Else
            drpaffsub.Enabled = False
            txtafffrom.Enabled = False
            txtaffto.Enabled = False
            'cersanpath1.Disabled = True
            HyperLink1.Enabled = False

        End If
    End Sub

    Protected Sub drpaddsec_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpaddsec.SelectedIndexChanged
        If drpaddsec.SelectedValue = 1 Then
            drpsubadd.Enabled = True
            txtsecfrom.Enabled = True
            txtsecto.Enabled = True
            'cersanpath1.Disabled = False
            HyperLink2.Enabled = True
        Else
            drpsubadd.Enabled = False
            txtsecfrom.Enabled = False
            txtsecto.Enabled = False
            'cersanpath1.Disabled = True
            HyperLink2.Enabled = False

        End If
    End Sub

    Protected Sub drplease_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drplease.SelectedIndexChanged
        If drplease.SelectedValue = 1 Then
            drpleasesub.Enabled = True
            txtleasefrom.Enabled = True
            txtleaseto.Enabled = True
            'cersanpath1.Disabled = False
            HyperLink3.Enabled = True
        Else
            drpleasesub.Enabled = False
            txtleasefrom.Enabled = False
            txtleaseto.Enabled = False
            'cersanpath1.Disabled = True
            HyperLink3.Enabled = False

        End If
    End Sub

    Protected Sub drpfdr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpfdr.SelectedIndexChanged
        If drpfdr.SelectedValue = 1 Then
            drpfdrsub.Enabled = True
            txtfdrfrom.Enabled = True
            txtfdrto.Enabled = True
            'cersanpath1.Disabled = False
            Hyperlink5.Enabled = True
        Else
            drpfdrsub.Enabled = False
            txtfdrfrom.Enabled = False
            txtfdrto.Enabled = False
            'cersanpath1.Disabled = True
            Hyperlink5.Enabled = False

        End If
    End Sub
End Class
