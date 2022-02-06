Imports CollegeBoardDLL
Public Class BoardCollegeEntry
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents UcAddress As AddressInfo
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents drpCorpColl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpColltype As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpBoardDist As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TxtCollcode As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtCollName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txtoldcode As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtColadr As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtYos As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtDesc As System.Web.UI.WebControls.TextBox
    Protected WithEvents DrpNarayana As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpGroup As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label25 As System.Web.UI.WebControls.Label
    Protected WithEvents Label26 As System.Web.UI.WebControls.Label
    Protected WithEvents Label27 As System.Web.UI.WebControls.Label
    Protected WithEvents Label29 As System.Web.UI.WebControls.Label
    Protected WithEvents Label30 As System.Web.UI.WebControls.Label
    Protected WithEvents Label31 As System.Web.UI.WebControls.Label
    Protected WithEvents Label32 As System.Web.UI.WebControls.Label
    Protected WithEvents Label33 As System.Web.UI.WebControls.Label
    Protected WithEvents Label34 As System.Web.UI.WebControls.Label
    Protected WithEvents Label37 As System.Web.UI.WebControls.Label
    Protected WithEvents Label38 As System.Web.UI.WebControls.Label
    Protected WithEvents Label39 As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents Label18 As System.Web.UI.WebControls.Label
    Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    Protected WithEvents ChkSLang As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents ChkMedium As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents Chkgroup As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents Label22 As System.Web.UI.WebControls.Label
    Protected WithEvents Label23 As System.Web.UI.WebControls.Label
    Protected WithEvents Label21 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox9 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox10 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox11 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox12 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox13 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox14 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox15 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox16 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Table6 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Table7 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents drploc As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpclgrun As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpafflatest As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpclgsch As System.Web.UI.WebControls.DropDownList

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

    Private objBoardEnrollment As ClsBoardEnrollment
    Private objError As clsError
    Private MODE, CODE, DCODE As String
    Public SLNO, MNO As Integer
    Private Rtnvalue, PageIndex As Integer
    Private DsSearchResult, DS, dsSet As DataSet
    Dim BrdcolDset As New DataSet
    Public StrSql, StrSql1, StrSql2, StrSql3 As String

    Private ObjResult As Utility
    Private dsSetIns, dsSetIns1, dsSetIns2 As New DataSet
#End Region

#Region "Page Load Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            End If


            If Not IsPostBack Then
                ButtonsHiding(Me.Page)
                SetViewStateVariables()

                'MODE = Request.QueryString("MODE")

                FillSecondLang()
                FillMedium()
                FillGroup()
                fillCollType()
                fillBoardDist()
                fillCorpColl()
                FillDrops()
                Table6.Visible = False
                Table7.Visible = False
                If MODE = "EDIT" Then
                    Dim Ds As DataSet
                    objBoardEnrollment = New ClsBoardEnrollment
                    Ds = objBoardEnrollment.college_select(CODE)
                    If Not Ds Is Nothing Then
                        If Ds.Tables(0).Rows.Count > 0 Then
                            FillControls(Ds)
                        End If
                    End If
                Else
                    'fillCollType()
                    'fillBoardDist()
                    'fillCorpColl()
                    
                End If
                'StartUpScript(TxtGaName.ID, "")
                Session("MODE") = MODE
            Else
                
                GetViewStateVariables()
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

#Region " Methods"

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")

        Try
            If focusCtrl <> "" And strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.GroupActivitySingle." & focusCtrl & " == '[object]') { document.GroupActivitySingle." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf focusCtrl <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.GroupActivitySingle." & focusCtrl & " == '[object]') { document.GroupActivitySingle." & focusCtrl & ".focus(); } </script>")
            Else

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function ValidateForm() As Boolean
        Try
            If TxtCollcode.Text.Trim = "" Then
                StartUpScript(TxtCollcode.ID, " Enter 5 Digit College Code ")
                Return False
            ElseIf TxtCollName.Text.Trim = "" Then
                StartUpScript(TxtCollcode.ID, " Enter 5 Digit College Code ")
                Return False
            ElseIf TxtColadr.Text.Trim = "" Then
                StartUpScript(TxtCollcode.ID, " Enter 5 Digit College Code ")
                Return False
            End If
            Return True
        Catch ex As Exception

        End Try

    End Function

    Private Function SetEntries() As ArrayList
        Try
            Dim I As Integer
            Dim dr As DataRow

            ''''''''''''''MARKS DETAILS''''''''''''''''''''''
            Dim txtObtMarks As TextBox
            Dim MaxMarks As Integer
            Dim DObtainMarks As Double

            Dim Arr As New ArrayList
            BrdcolDset = Me.ViewState("BrdcolDset")
            If MODE = "NEW" Then


                '''''''''''''''''''''' 1 '''''''''''''''''''''''''
               


                If Trim(TxtCollcode.Text) = "" Then                 '--0
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(TxtCollcode.Text)))
                End If

                If Trim(TxtCollName.Text) = "" Then                 '--1
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(TxtCollName.Text)))
                End If

                If Trim(TxtColadr.Text) = "" Then                   '--2
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(TxtColadr.Text)))
                End If

                Arr.Add(Val(DrpColltype.SelectedValue))            '--3
                Arr.Add(Val(DrpBoardDist.SelectedValue))           '--4

                If Trim(TxtYos.Text) = "" Then                      '--5
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(TxtYos.Text)))
                End If

                If Trim(Txtoldcode.Text) = "" Then                  '--6
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(Txtoldcode.Text)))
                End If

                Arr.Add(Trim(DrpNarayana.SelectedValue))            '--7
                Arr.Add(Trim(DrpGroup.SelectedValue))               '--8
                Arr.Add(Trim(drpCorpColl.SelectedValue))            '--9


                If UcAddress.drpState.SelectedIndex = -1 Then       '--10
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Trim(UcAddress.drpState.SelectedValue))
                End If

                If UcAddress.drpDistrict.SelectedIndex = -1 Then    '--11
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Trim(UcAddress.drpDistrict.SelectedValue))
                End If

                If UcAddress.DrpMandal.SelectedIndex = -1 Then      '--12
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Trim(UcAddress.DrpMandal.SelectedValue))
                End If

                If Trim(UcAddress.txtMandalArea.Text) = "" Then     '--13
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(UcAddress.txtMandalArea.Text))
                End If

                '''''''''''''''''''''' 2 '''''''''''''''''''''''''

                If Trim(UcAddress.txtStreetVill.Text) = "" Then     '--14
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(UcAddress.txtStreetVill.Text))
                End If

                If Trim(UcAddress.txtHNO.Text) = "" Then            '--15
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtHNO.Text)
                End If

                If Trim(UcAddress.txtPIN.Text) = "" Then            '--16
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtPIN.Text)
                End If

                If Trim(UcAddress.txtPhoneRes.Text) = "" Then       '--17
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtPhoneRes.Text)
                End If

                If Trim(UcAddress.txtPhoneOff.Text) = "" Then       '--18
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtPhoneOff.Text)
                End If

                '''''''''''''''''''''' 3 '''''''''''''''''''''''''

                If Trim(UcAddress.txtMobile1.Text) = "" Then        '--19
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtMobile1.Text)
                End If

                If Trim(UcAddress.txtMobile2.Text) = "" Then        '--20
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtMobile2.Text)
                End If

                If Trim(UcAddress.txtEmail.Text) = "" Then          '--21
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtEmail.Text)
                End If

                If Trim(TxtDesc.Text) = "" Then                     '--22
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(TxtDesc.Text)))
                End If

                ''gk add
                Arr.Add(Val(drploc.SelectedValue))

                If Trim(Textbox2.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(Textbox2.Text)))
                End If

                If Trim(Textbox3.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox3.Text)))
                End If

                If Trim(Textbox4.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(Textbox4.Text)))
                End If

                If Trim(Textbox5.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(Textbox5.Text)))
                End If

                Arr.Add(Val(drpclgrun.SelectedValue))


                If Trim(Textbox6.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(Textbox6.Text)))
                End If

                If Trim(Textbox7.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox7.Text)))
                End If

                If Trim(Textbox8.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(Textbox8.Text)))
                End If

                If Trim(Textbox9.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox9.Text)))
                End If


                If Trim(Textbox10.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox10.Text)))
                End If
                If Trim(Textbox11.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox11.Text)))
                End If

                Arr.Add(Val(drpafflatest.SelectedValue))
                Arr.Add(Val(drpclgsch.SelectedValue))

                If Trim(Textbox14.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox14.Text)))
                End If

                If Trim(Textbox15.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox15.Text)))
                End If

                If Trim(Textbox16.Text) = "" Then
                    Arr.Add("")
                Else
                    Arr.Add((Trim(Textbox16.Text)))
                End If

                If Trim(Textbox12.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox12.Text)))
                End If


                If Trim(Textbox13.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox13.Text)))
                End If
                Arr.Add(Val(MNO))
                ''gk add
            ElseIf MODE = "EDIT" Then
                'Arr.Add(Val(Trim(SLNO)))
                If Trim(TxtCollcode.Text) = "" Then                 '--0
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(TxtCollcode.Text)))
                End If

                If Trim(TxtCollName.Text) = "" Then                 '--1
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(TxtCollName.Text)))
                End If

                If Trim(TxtColadr.Text) = "" Then                   '--2
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(TxtColadr.Text)))
                End If

                Arr.Add(Val(DrpColltype.SelectedValue))            '--3
                Arr.Add(Val(DrpBoardDist.SelectedValue))           '--4

                If Trim(TxtYos.Text) = "" Then                      '--5
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(TxtYos.Text)))
                End If

                If Trim(Txtoldcode.Text) = "" Then                  '--6
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(Txtoldcode.Text)))
                End If

                Arr.Add(Trim(DrpNarayana.SelectedValue))            '--7
                Arr.Add(Trim(DrpGroup.SelectedValue))               '--8
                Arr.Add(Trim(drpCorpColl.SelectedValue))            '--9


                If UcAddress.drpState.SelectedIndex = -1 Then       '--10
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Trim(UcAddress.drpState.SelectedValue))
                End If

                If UcAddress.drpDistrict.SelectedIndex = -1 Then    '--11
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Trim(UcAddress.drpDistrict.SelectedValue))
                End If

                If UcAddress.DrpMandal.SelectedIndex = -1 Then      '--12
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Trim(UcAddress.DrpMandal.SelectedValue))
                End If

                If Trim(UcAddress.txtMandalArea.Text) = "" Then     '--13
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(UcAddress.txtMandalArea.Text))
                End If

                '''''''''''''''''''''' 2 '''''''''''''''''''''''''

                If Trim(UcAddress.txtStreetVill.Text) = "" Then     '--14
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(UcAddress.txtStreetVill.Text))
                End If

                If Trim(UcAddress.txtHNO.Text) = "" Then            '--15
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtHNO.Text)
                End If

                If Trim(UcAddress.txtPIN.Text) = "" Then            '--16
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtPIN.Text)
                End If

                If Trim(UcAddress.txtPhoneRes.Text) = "" Then       '--17
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtPhoneRes.Text)
                End If

                If Trim(UcAddress.txtPhoneOff.Text) = "" Then       '--18
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtPhoneOff.Text)
                End If

                '''''''''''''''''''''' 3 '''''''''''''''''''''''''

                If Trim(UcAddress.txtMobile1.Text) = "" Then        '--19
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtMobile1.Text)
                End If

                If Trim(UcAddress.txtMobile2.Text) = "" Then        '--20
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtMobile2.Text)
                End If

                If Trim(UcAddress.txtEmail.Text) = "" Then          '--21
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtEmail.Text)
                End If

                If Trim(TxtDesc.Text) = "" Then                     '--22
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(TxtDesc.Text)))
                End If

                ''gk add
                Arr.Add(Val(drploc.SelectedValue))

                If Trim(Textbox2.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(Textbox2.Text)))
                End If

                If Trim(Textbox3.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox3.Text)))
                End If

                If Trim(Textbox4.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(Textbox4.Text)))
                End If

                If Trim(Textbox5.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(Textbox5.Text)))
                End If

                Arr.Add(Val(drpclgrun.SelectedValue))


                If Trim(Textbox6.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(Textbox6.Text)))
                End If

                If Trim(Textbox7.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox7.Text)))
                End If

                If Trim(Textbox8.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(Textbox8.Text)))
                End If

                If Trim(Textbox9.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox9.Text)))
                End If


                If Trim(Textbox10.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox10.Text)))
                End If
                If Trim(Textbox11.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox11.Text)))
                End If

                Arr.Add(Val(drpafflatest.SelectedValue))
                Arr.Add(Val(drpclgsch.SelectedValue))

                If Trim(Textbox14.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox14.Text)))
                End If

                If Trim(Textbox15.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox15.Text)))
                End If

                If Trim(Textbox16.Text) = "" Then
                    Arr.Add("")
                Else
                    Arr.Add(Trim(Textbox16.Text))
                End If

                If Trim(Textbox12.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox12.Text)))
                End If


                If Trim(Textbox13.Text) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Val(Trim(Textbox13.Text)))
                End If
                Arr.Add(Val(MNO))

                If Trim(CODE) = "" Then
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(CODE)))
                End If

            End If
            Return Arr
        Catch ex As Exception
            objError = New clsError

        End Try

    End Function

    Private Function SetEntries_ORG() As ArrayList
        Try
            Dim I As Integer
            Dim dr As DataRow

            ''''''''''''''MARKS DETAILS''''''''''''''''''''''
            Dim txtObtMarks As TextBox
            Dim MaxMarks As Integer
            Dim DObtainMarks As Double

            'If PCMDDset.Tables("MarksTable").Rows.Count = 0 Then   ''''When No Subjects are available then He Press Save that time
            '''If dgExam.Items.Count = 0 Then
            '''    DisplayMessage("No Subjects Available For This Course")
            '''    Return False
            '''End If

            '''If From = "NEW" Then

            '''    For I = 0 To dgExam.Items.Count - 1
            '''        dr = PCMDDset.Tables("MarksTable").NewRow
            '''        txtObtMarks = dgExam.Items(I).Cells(4).Controls(1)
            '''        dr("PCMHSLNO") = 0
            '''        dr("PCMDSLNO") = 0
            '''        dr("SUBJECTSLNO") = dgExam.Items(I).Cells(1).Text()  '''SubjectSlno
            '''        dr("MAXMARKS") = dgExam.Items(I).Cells(3).Text()  '''MaxMarks
            '''        If Not Validation(txtObtMarks, CDec(dr("MAXMARKS"))) Then
            '''            Return False
            '''        End If
            '''        dr("OBTAINEDMARKS") = CDec(txtObtMarks.Text)
            '''        'If Not (TxtRank.Text) Is Nothing Then
            '''        '    dr("RANK") = Val(TxtRank.Text)
            '''        'Else
            '''        dr("RANK") = 0
            '''        'End If
            '''        dr("PERCENTAGE") = ROUND((CDec(txtObtMarks.Text) / dr("MAXMARKS")) * 100, 2)
            '''        dr("DESCRIPTION") = "Subject Wise Marks"
            '''        PCMDDset.Tables("MarksTable").Rows.Add(dr)
            '''        DObtainMarks += Val(txtObtMarks.Text)
            '''        MaxMarks += dgExam.Items(I).Cells(3).Text()   '''For HeaderTable Purpose
            '''    Next
            '''Else
            '''    For I = 0 To PCMDDset.Tables("MarksTable").Rows.Count - 1
            '''        dr = PCMDDset.Tables("MarksTable").Rows(I)
            '''        txtObtMarks = dgExam.Items(I).Cells(4).Controls(1)
            '''        dr("PCMHSLNO") = dr("PCMHSLNO")
            '''        dr("PCMDSLNO") = dr("PCMDSLNO")
            '''        dr("SUBJECTSLNO") = dgExam.Items(I).Cells(1).Text()
            '''        dr("MAXMARKS") = dgExam.Items(I).Cells(3).Text()
            '''        If Not Validation(txtObtMarks, CDec(dr("MAXMARKS"))) Then
            '''            Return False
            '''        End If
            '''        dr("OBTAINEDMARKS") = CDec(txtObtMarks.Text)
            '''        'If Not (TxtRank.Text) Is Nothing Then
            '''        '    dr("RANK") = Val(TxtRank.Text)
            '''        'Else
            '''        dr("RANK") = 0
            '''        ' End If
            '''        dr("PERCENTAGE") = Round(CDec(txtObtMarks.Text) / dr("MAXMARKS") * 100, 2)
            '''        dr("DESCRIPTION") = "Subject Wise Marks"
            '''        DObtainMarks += CDec(txtObtMarks.Text)
            '''        MaxMarks += dgExam.Items(I).Cells(3).Text()   '''For HeaderTable Purpose
            '''    Next
            '''End If

            ''''Header Table Insertions
            BrdcolDset = Me.ViewState("BrdcolDset")
            'If PCMDDset.Tables("PCMDTable").Rows.Count = 0 Then
            If MODE = "NEW" Then
                '''BrdcolDset.Tables("BrdcolTable").Rows.Clear()
                '''dr = BrdcolDset.Tables("BrdcolDset").NewRow
                '''dr("CODE") = TxtCollcode.Text
                '''dr("NAME") = TxtCollName.Text
                '''dr("COLLEGENAME") = TxtColadr.Text
                '''dr("CATEGORYSLNO") = DrpColltype.SelectedValue
                '''dr("BOARDDISTSLNO") = DrpBoardDist.SelectedValue
                '''dr("YEAROFSTART") = TxtYos.Text
                '''dr("OLDCODE") = Txtoldcode.Text
                '''dr("ISNARAYANA") = DrpNarayana.SelectedValue
                '''dr("ISOWN") = DrpGroup.SelectedValue
                '''dr("BOARDCORPCOLLSLNO") = drpCorpColl.SelectedValue
                '''dr("ADDR1") = UCase(UcAddress.txtStreetVill.Text)
                '''dr("ADDR2") = UcAddress.txtHNO.Text
                '''dr("ADDR3") = UcAddress.txtMandalArea.Text
                '''dr("ADDR4") = UcAddress.txtPIN.Text
                '''dr("MANDALSLNO") = UcAddress.DrpMandal.SelectedValue
                '''dr("DISTRICTSLNO") = UcAddress.drpDistrict.SelectedValue
                '''dr("STATESLNO") = UcAddress.drpState.SelectedValue
                '''dr("PHONE1") = UcAddress.txtPhoneRes.Text
                '''dr("PHONE2") = UcAddress.txtPhoneOff.Text
                '''dr("MOBILE1") = UcAddress.txtMobile1.Text
                '''dr("MOBILE2") = UcAddress.txtMobile2.Text
                '''dr("eMail") = UcAddress.txtEmail.Text
                '''dr("DESCRIPTION") = TxtDesc.Text

                '''BrdcolDset.Tables("BrdcolTable").Rows.Add(dr)

                Dim Arr As New ArrayList

                '''''''''''''''''''''' 1 '''''''''''''''''''''''''

                If Trim(TxtCollcode.Text) = "" Then                 '--0
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(TxtCollcode.Text)))
                End If

                If Trim(TxtCollName.Text) = "" Then                 '--1
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(TxtCollName.Text)))
                End If

                If Trim(TxtColadr.Text) = "" Then                   '--2
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(TxtColadr.Text)))
                End If

                Arr.Add(Trim(DrpColltype.SelectedValue))            '--3
                Arr.Add(Trim(DrpBoardDist.SelectedValue))           '--4

                If Trim(TxtYos.Text) = "" Then                      '--5
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(TxtYos.Text)))
                End If

                If Trim(Txtoldcode.Text) = "" Then                  '--6
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(Txtoldcode.Text)))
                End If

                Arr.Add(Trim(DrpNarayana.SelectedValue))            '--7
                Arr.Add(Trim(DrpGroup.SelectedValue))               '--8
                Arr.Add(Trim(drpCorpColl.SelectedValue))            '--9


                If UcAddress.drpState.SelectedIndex = -1 Then       '--10
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Trim(UcAddress.drpState.SelectedValue))
                End If

                If UcAddress.drpDistrict.SelectedIndex = -1 Then    '--11
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Trim(UcAddress.drpDistrict.SelectedValue))
                End If

                If UcAddress.DrpMandal.SelectedIndex = -1 Then      '--12
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(Trim(UcAddress.DrpMandal.SelectedValue))
                End If

                If Trim(UcAddress.txtMandalArea.Text) = "" Then     '--13
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(UcAddress.txtMandalArea.Text))
                End If

                '''''''''''''''''''''' 2 '''''''''''''''''''''''''

                If Trim(UcAddress.txtStreetVill.Text) = "" Then     '--14
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(UcAddress.txtStreetVill.Text))
                End If

                If Trim(UcAddress.txtHNO.Text) = "" Then            '--15
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtHNO.Text)
                End If

                If Trim(UcAddress.txtPIN.Text) = "" Then            '--16
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtPIN.Text)
                End If

                If Trim(UcAddress.txtPhoneRes.Text) = "" Then       '--17
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtPhoneRes.Text)
                End If

                If Trim(UcAddress.txtPhoneOff.Text) = "" Then       '--18
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtPhoneOff.Text)
                End If

                '''''''''''''''''''''' 3 '''''''''''''''''''''''''

                If Trim(UcAddress.txtMobile1.Text) = "" Then        '--19
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtMobile1.Text)
                End If

                If Trim(UcAddress.txtMobile2.Text) = "" Then        '--20
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtMobile2.Text)
                End If

                If Trim(UcAddress.txtEmail.Text) = "" Then          '--21
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UcAddress.txtEmail.Text)
                End If

                If Trim(TxtDesc.Text) = "" Then                     '--22
                    Arr.Add(System.DBNull.Value)
                Else
                    Arr.Add(UCase(Trim(TxtDesc.Text)))
                End If

                Return Arr
            Else
                '''    dr = PCMDDset.Tables("PCMDTable").Rows(0)
                '''    dr("PCMHSLNO") = PCMHSLNO
                '''    dr("PCSLNO") = cboCourse.SelectedValue
                '''    dr("ADMSLNO") = ADMSLNO
                '''    dr("MEDIUMSLNO") = drpMedium.SelectedValue
                '''    dr("HALLTICKETNO") = Trim(txtHallTicket.Text)

                '''    If Trim(txtHallTicket.Text) <> "" Then
                '''        dr("HALLTICKETNO") = Trim(txtHallTicket.Text)
                '''    Else
                '''        dr("HALLTICKETNO") = System.DBNull.Value
                '''    End If

                '''    dr("TOTALMARKS") = TxtCTotal.Text
                '''    dr("TOTALOBTAINMARKS") = DObtainMarks
                '''    If Not (TxtRank.Text) Is Nothing Then
                '''        dr("RANK") = Val(TxtRank.Text)
                '''    Else
                '''        dr("RANK") = 0
                '''    End If
                '''    dr("PERCENTAGE") = Round(DObtainMarks / MaxMarks * 100, 2) '''Percentage Calculation
                '''    dr("RAISEDMARKS") = 0
                '''    dr("DESCRIPTION") = UCase(Trim(TxtDescription.Text))
            End If

            '''Me.ViewState("PCMDDset") = PCMDDset
            '''Return True
        Catch ex As Exception
            objError = New clsError
            'DisplayMessage(objError.errHandler(ex))
        End Try

    End Function

    Private Sub SetViewStateVariables()
        Try
            If Not Request.QueryString("MODE") Is Nothing Then MODE = Request.QueryString("MODE")
            If Not Request.QueryString("CODE") Is Nothing Then CODE = Request.QueryString("CODE")
            If Not Request.QueryString("PageIndex") Is Nothing Then PageIndex = Request.QueryString("PageIndex")

            Me.ViewState("MODE") = MODE
            Me.ViewState("CODE") = CODE
            Me.ViewState("MNO") = MNO
            'Me.ViewState("PageIndex") = PageIndex

            'Me.ViewState("HEAD") = HEAD
            'Me.ViewState("PageIndex") = PageIndex
            'lblHeading.Text = "Board&nbsp;" + HEAD + "&nbsp;(Batch&nbsp;Mode)"
            'DrpBoardMaster.SelectedValue = BENO
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetViewStateVariables()
        Try
            MODE = Me.ViewState("MODE")
            CODE = Me.ViewState("CODE")
            MNO = Me.ViewState("MNO")

            PageIndex = Me.ViewState("PageIndex")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrepareTableForGroups()
        Try
            Dim dt As DataTable
            dsSet = New DataSet
            dsSet.Tables.Add(New DataTable("GROUP"))
            dt = dsSet.Tables("GROUP")

            dt.Columns.Add("GRPCODE", Type.GetType("System.Int32"))
            dt.Columns.Add("CODE", Type.GetType("System.String"))
            'dt.Columns.Add("MDMCODE", Type.GetType("System.Int32"))

        Catch ex As Exception
            objError = New clsError
            StartUpScript(Me.ID, objError.errHandler(ex))
        End Try
    End Sub

    Private Sub PrepareTableForSecondLang()
        Try
            Dim dt As DataTable
            dsSet = New DataSet
            dsSet.Tables.Add(New DataTable("SCLG"))
            dt = dsSet.Tables("SCLG")
            dt.Columns.Add("SLGCODE", Type.GetType("System.Int32"))
            dt.Columns.Add("CODE", Type.GetType("System.String"))
        Catch ex As Exception
            objError = New clsError
            StartUpScript(Me.ID, objError.errHandler(ex))
        End Try
    End Sub

    Private Sub PrepareTableForMedium()
        Try
            Dim dt As DataTable
            dsSet = New DataSet
            dsSet.Tables.Add(New DataTable("MEDIUM"))
            dt = dsSet.Tables("MEDIUM")
            dt.Columns.Add("MDMCODE", Type.GetType("System.Int32"))
            dt.Columns.Add("CODE", Type.GetType("System.String"))
        Catch ex As Exception
            objError = New clsError
            StartUpScript(Me.ID, objError.errHandler(ex))
        End Try
    End Sub

    Private Sub ClearText()
        Dim I, J, K As Integer
        Try
            TxtCollcode.Text = ""
            TxtCollName.Text = ""
            TxtColadr.Text = ""
            TxtDesc.Text = ""
            TxtYos.Text = ""
            Txtoldcode.Text = ""
            Textbox2.Text = ""
            Textbox3.Text = ""
            Textbox4.Text = ""
            Textbox5.Text = ""
            Textbox6.Text = ""
            Textbox7.Text = ""
            Textbox8.Text = ""
            Textbox9.Text = ""
            Textbox10.Text = ""
            Textbox11.Text = ""
            Textbox12.Text = ""
            Textbox13.Text = ""
            Textbox14.Text = ""
            Textbox15.Text = ""
            Textbox16.Text = ""

            For I = 0 To Chkgroup.Items.Count - 1
                Chkgroup.Items(I).Selected = False
            Next

            For I = 0 To ChkMedium.Items.Count - 1
                ChkMedium.Items(I).Selected = False
            Next

            For I = 0 To ChkSLang.Items.Count - 1
                ChkSLang.Items(I).Selected = False
            Next
            'DrpColltype.Items.Clear()
            'DrpColltype.SelectedValue = 0
            'DrpNarayana.Items.Clear()
            'DrpNarayana.SelectedValue = 0
            'DrpGroup.SelectedValue = 0
            'drpCorpColl.SelectedValue = 0
            'DrpBoardDist.SelectedValue = 0
            'drploc.SelectedValue = 0
        Catch ex As Exception

        End Try


    End Sub

#End Region

#Region "Fill Methods"

    Private Sub fillCollType()

        objBoardEnrollment = New ClsBoardEnrollment

        DsSearchResult = objBoardEnrollment.Masters_Selectall(12)
        DrpColltype.DataSource = DsSearchResult.Tables(0)
        DrpColltype.DataTextField = "NAME"
        DrpColltype.DataValueField = "SLNO"
        DrpColltype.DataBind()
        DrpColltype.Items.Insert(0, New ListItem("Select", 0))
    End Sub

    Private Sub fillBoardDist()

        objBoardEnrollment = New ClsBoardEnrollment

        DsSearchResult = objBoardEnrollment.Masters_Selectall(1)
        DrpBoardDist.DataSource = DsSearchResult.Tables(0)
        DrpBoardDist.DataTextField = "NAME"
        DrpBoardDist.DataValueField = "SLNO"
        DrpBoardDist.DataBind()
        DrpBoardDist.Items.Insert(0, New ListItem("Select", 0))
        DCODE = Session("DCODE")
        DrpBoardDist.SelectedValue = DCODE
    End Sub

    Private Sub fillCorpColl()

        objBoardEnrollment = New ClsBoardEnrollment

        DsSearchResult = objBoardEnrollment.Masters_Selectall(13)
        drpCorpColl.DataSource = DsSearchResult.Tables(0)
        drpCorpColl.DataTextField = "NAME"
        drpCorpColl.DataValueField = "SLNO"
        drpCorpColl.DataBind()
        drpCorpColl.Items.Insert(0, New ListItem("Select", 0))
    End Sub

    Private Sub FillControls(ByVal Ds As DataSet)
        Try
            FillDrops()
            TxtCollcode.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("CODE")), "", Ds.Tables(0).Rows(0)("CODE"))
            TxtCollName.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("NAME")), "", Ds.Tables(0).Rows(0)("NAME"))
            Txtoldcode.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("OLDCODE")), "", Ds.Tables(0).Rows(0)("OLDCODE"))
            TxtColadr.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("COLLEGENAME")), "", Ds.Tables(0).Rows(0)("COLLEGENAME"))
            TxtYos.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("YEAROFSTART")), "", Ds.Tables(0).Rows(0)("YEAROFSTART"))
            TxtDesc.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("DESCRIPTION")), "", Ds.Tables(0).Rows(0)("DESCRIPTION"))

            DrpColltype.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDCOLLTYPESLNO")), 0, Ds.Tables(0).Rows(0)("BOARDCOLLTYPESLNO"))
            DrpNarayana.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("ISNARAYANA")), 0, Ds.Tables(0).Rows(0)("ISNARAYANA"))
            DrpGroup.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("ISOWN")), 0, Ds.Tables(0).Rows(0)("ISOWN"))
            drpCorpColl.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDCORPCOLLSLNO")), 0, Ds.Tables(0).Rows(0)("BOARDCORPCOLLSLNO"))
            DrpBoardDist.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BOARDDISTSLNO")), 0, Ds.Tables(0).Rows(0)("BOARDDISTSLNO"))
            'gk 06-02-2012
            'UcAddress.FillCountry()
            'UcAddress.drpCountry.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("COUNTRYSLNO")), 0, Ds.Tables(0).Rows(0)("COUNTRYSLNO"))
            'gk 06-02-2012

            UcAddress.FillState(1)
            UcAddress.drpState.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("STATESLNO")), 0, Ds.Tables(0).Rows(0)("STATESLNO"))
            UcAddress.FillDistrict(IIf(IsDBNull(Ds.Tables(0).Rows(0)("STATESLNO")), 0, Ds.Tables(0).Rows(0)("STATESLNO")))
            UcAddress.drpDistrict.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("DISTRICTSLNO")), 0, Ds.Tables(0).Rows(0)("DISTRICTSLNO"))
            UcAddress.FillMandal(IIf(IsDBNull(Ds.Tables(0).Rows(0)("DISTRICTSLNO")), 0, Ds.Tables(0).Rows(0)("DISTRICTSLNO")))
            UcAddress.DrpMandal.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("MANDALSLNO")), 0, Ds.Tables(0).Rows(0)("MANDALSLNO"))
            UcAddress.txtMandalArea.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("ADDR3")), "", Ds.Tables(0).Rows(0)("ADDR3"))
            UcAddress.txtStreetVill.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("ADDR2")), "", Ds.Tables(0).Rows(0)("ADDR2"))
            UcAddress.txtHNO.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("ADDR1")), "", Ds.Tables(0).Rows(0)("ADDR1"))
            UcAddress.txtPIN.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("ADDR4")), "", Ds.Tables(0).Rows(0)("ADDR4"))
            UcAddress.txtPhoneRes.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("PHONE1")), "", Ds.Tables(0).Rows(0)("PHONE1"))
            UcAddress.txtPhoneOff.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("PHONE2")), "", Ds.Tables(0).Rows(0)("PHONE2"))
            UcAddress.txtMobile1.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("MOBILE1")), "", Ds.Tables(0).Rows(0)("MOBILE1"))
            UcAddress.txtMobile2.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("MOBILE2")), "", Ds.Tables(0).Rows(0)("MOBILE2"))
            UcAddress.txtEmail.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("EMAIL")), "", Ds.Tables(0).Rows(0)("EMAIL"))
            'gk 06-02-2012
            drploc.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("LOC_COLLEGE")), "SELECT", Ds.Tables(0).Rows(0)("LOC_COLLEGE"))
            Textbox2.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("PRIIC_NAME")), "", Ds.Tables(0).Rows(0)("PRIIC_NAME"))
            Textbox3.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("PRIIC_MOBILE")), "", Ds.Tables(0).Rows(0)("PRIIC_MOBILE"))
            Textbox4.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BIEZONE")), "", Ds.Tables(0).Rows(0)("BIEZONE"))
            Textbox5.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BANK_BRNACH")), "", Ds.Tables(0).Rows(0)("BANK_BRNACH"))
            drpclgrun.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("RUN_STATUS")), "SELECT", Ds.Tables(0).Rows(0)("RUN_STATUS"))
            Textbox6.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("IC_NAME")), "", Ds.Tables(0).Rows(0)("IC_NAME"))
            Textbox7.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("IC_MOBILE")), "", Ds.Tables(0).Rows(0)("IC_MOBILE"))
            Textbox8.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BIE_CLERK_NAME")), "", Ds.Tables(0).Rows(0)("BIE_CLERK_NAME"))
            Textbox9.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("BIE_CLERK_MOBILE")), "", Ds.Tables(0).Rows(0)("BIE_CLERK_MOBILE"))
            Textbox10.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("LOI_GO_NO")), "", Ds.Tables(0).Rows(0)("LOI_GO_NO"))
            Textbox11.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("LOI_GO_DATE")), "", Ds.Tables(0).Rows(0)("LOI_GO_DATE"))
            drpafflatest.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("LATEST_SUB_AFF")), "SELECT", Ds.Tables(0).Rows(0)("LATEST_SUB_AFF"))
            drpclgsch.SelectedValue = IIf(IsDBNull(Ds.Tables(0).Rows(0)("CLG_SC_TYPE")), "SELECT", Ds.Tables(0).Rows(0)("CLG_SC_TYPE"))

            If drpclgsch.SelectedValue = 1 Then
                Table7.Visible = True
                Table6.Visible = False
            ElseIf drpclgsch.SelectedValue = 2 Then
                Table6.Visible = True
                Table7.Visible = False
            End If

            Textbox14.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("CLG_AFF_15")), "", Ds.Tables(0).Rows(0)("CLG_AFF_15"))
            Textbox15.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("CLG_AFF_610")), "", Ds.Tables(0).Rows(0)("CLG_AFF_610"))
            Textbox16.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("PLAN_BRS_PROC_NO")), "", Ds.Tables(0).Rows(0)("PLAN_BRS_PROC_NO"))
            Textbox12.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SC_AFF_15")), "", Ds.Tables(0).Rows(0)("SC_AFF_15"))
            Textbox13.Text = IIf(IsDBNull(Ds.Tables(0).Rows(0)("SC_AFF_610")), "", Ds.Tables(0).Rows(0)("SC_AFF_610"))
            GetCheckMedium()
            'gk 06-02-2012
        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillSecondLang()
        Try
            StrSql = "SELECT CODE,NAME FROM EXAM_BOARDSECLANG_MT ORDER BY CODE"

            ObjResult = New Utility
            DS = ObjResult.GetCommDataSet(StrSql)

            If Not DS Is Nothing Then

                ChkSLang.DataSource = DS.Tables(0)

                ChkSLang.DataTextField = "NAME"
                ChkSLang.DataValueField = "CODE"
                ChkSLang.DataBind()


                Dim i, J As Integer
                'If DS.Tables(1).Rows.Count > 0 Then

                '    'For J = 0 To DS.Tables(1).Rows.Count - 1
                '    '    For i = 0 To ChkSLang.Items.Count - 1
                '    '        If Val(ChkSLang.Items(i).Value) = Val(DS.Tables(1).Rows(J)("EXAMBRANCHSLNO")) Then
                '    '            ChkSLang.Items(i).Selected = True
                '    '        End If
                '    '    Next
                '    'Next


                'End If

            Else
                StartUpScript(ChkSLang.ID, " Second Languages Are Not Available")
            End If


        Catch ex As Exception
            StartUpScript("", ex.Message)
        End Try
    End Sub

    Private Sub FillMedium()
        Try
            StrSql = "SELECT CODE,NAME FROM EXAM_BOARDMEDIUM_MT ORDER BY CODE"

            ObjResult = New Utility
            DS = ObjResult.GetCommDataSet(StrSql)

            If Not DS Is Nothing Then

                ChkMedium.DataSource = DS.Tables(0)

                ChkMedium.DataTextField = "NAME"
                ChkMedium.DataValueField = "CODE"
                ChkMedium.DataBind()


                Dim i, J As Integer
                'If DS.Tables(1).Rows.Count > 0 Then

                '    'For J = 0 To DS.Tables(1).Rows.Count - 1
                '    '    For i = 0 To ChkMedium.Items.Count - 1
                '    '        If Val(ChkMedium.Items(i).Value) = Val(DS.Tables(1).Rows(J)("EXAMBRANCHSLNO")) Then
                '    '            ChkMedium.Items(i).Selected = True
                '    '        End If
                '    '    Next
                '    'Next


                'End If

            Else
                StartUpScript(ChkMedium.ID, " Mediums is Not Available")
            End If


        Catch ex As Exception
            StartUpScript("", ex.Message)
        End Try
    End Sub

    Private Sub FillGroup()
        Try
            StrSql = "SELECT CODE,NAME FROM EXAM_BOARDGROUP_MT ORDER BY CODE"

            ObjResult = New Utility
            DS = ObjResult.GetCommDataSet(StrSql)

            If Not DS Is Nothing Then

                Chkgroup.DataSource = DS.Tables(0)

                Chkgroup.DataTextField = "NAME"
                Chkgroup.DataValueField = "CODE"
                Chkgroup.DataBind()


                Dim i, J As Integer
                'If DS.Tables(1).Rows.Count > 0 Then

                '    'For J = 0 To DS.Tables(1).Rows.Count - 1
                '    '    For i = 0 To Chkgroup.Items.Count - 1
                '    '        If Val(Chkgroup.Items(i).Value) = Val(DS.Tables(1).Rows(J)("EXAMBRANCHSLNO")) Then
                '    '            Chkgroup.Items(i).Selected = True
                '    '        End If
                '    '    Next
                '    'Next


                'End If

            Else
                StartUpScript(Chkgroup.ID, " Groups are Not Available")
            End If


        Catch ex As Exception
            StartUpScript("", ex.Message)
        End Try
    End Sub

    Private Sub GetCheckMedium()

        Dim DS As DataSet
        Dim StrSql1, StrSql2, StrSql3 As String
        Dim i, J As Integer

        Try
            FillGroup()
            FillMedium()
            FillSecondLang()

            StrSql1 = "SELECT GRP.GRPCODE FROM M_GROUP_DT GRP WHERE (GRP.CODE=(SELECT EBC.CODE  FROM  EXAM_BOARDCOLLEGE_MT EBC WHERE EBC.CODE=" & TxtCollcode.Text & "))" 'BOARDCOLLEGESLNO

            StrSql2 = "SELECT MDM.MDMCODE FROM M_MEDIUM_DT MDM WHERE (MDM.CODE=(SELECT EBC.CODE  FROM  EXAM_BOARDCOLLEGE_MT EBC WHERE EBC.CODE=" & TxtCollcode.Text & "))"

            StrSql3 = "SELECT SL.SLGCODE FROM M_SECONDLANG_DT SL WHERE (SL.CODE=(SELECT EBC.CODE  FROM  EXAM_BOARDCOLLEGE_MT EBC WHERE EBC.CODE=" & TxtCollcode.Text & "))"


            ObjResult = New Utility
            DS = ObjResult.DataSet_ThreeFetch(StrSql1, StrSql2, StrSql3)

            If DS.Tables(0).Rows.Count > 0 Then

                For J = 0 To DS.Tables(0).Rows.Count - 1
                    For i = 0 To Chkgroup.Items.Count - 1
                        If Val(Chkgroup.Items(i).Value) = DS.Tables(0).Rows(J)("GRPCODE") Then
                            Chkgroup.Items(i).Selected = True
                        End If
                    Next
                Next

            End If

            'MEDIUM

            If DS.Tables(1).Rows.Count > 0 Then

                For J = 0 To DS.Tables(1).Rows.Count - 1
                    For i = 0 To ChkMedium.Items.Count - 1
                        If Val(ChkMedium.Items(i).Value) = DS.Tables(1).Rows(J)("MDMCODE") Then
                            ChkMedium.Items(i).Selected = True
                        End If
                    Next
                Next

            End If
            'SECOND LANG
            If DS.Tables(2).Rows.Count > 0 Then

                For J = 0 To DS.Tables(2).Rows.Count - 1
                    For i = 0 To ChkSLang.Items.Count - 1
                        If Val(ChkSLang.Items(i).Value) = DS.Tables(2).Rows(J)("SLGCODE") Then
                            ChkSLang.Items(i).Selected = True
                        End If
                    Next
                Next

            End If


            'StrSql1 = "SELECT CODE,NAME FROM EXAM_BOARDMEDIUM_MT ORDER BY CODE"

            'StrSql2 = "SELECT GRP.GRPCODE FROM M_GROUP_DT GRP WHERE (GRP.BOARDCOLLEGESLNO=(SELECT EBC.BOARDCOLLEGESLNO  FROM  EXAM_BOARDCOLLEGE_MT EBC WHERE EBC.CODE=" & TxtCollcode.Text & "))"

            'ObjResult = New Utility
            'DS = ObjResult.DataSet_TwoFetch(StrSql1, StrSql2)


            'If Not DS Is Nothing Then

            '    ChkMedium.DataSource = DS.Tables(0)

            '    ChkMedium.DataTextField = "NAME"
            '    ChkMedium.DataValueField = "CODE"
            '    ChkMedium.DataBind()

            '    Dim i, J As Integer
            '    If DS.Tables(1).Rows.Count > 0 Then

            '        For J = 0 To DS.Tables(1).Rows.Count - 1
            '            For i = 0 To ChkMedium.Items.Count - 1
            '                If Val(ChkMedium.Items(i).Value) = Val(DS.Tables(1).Rows(J)("GRPCODE")) Then
            '                    ChkMedium.Items(i).Selected = True
            '                End If
            '            Next
            '        Next


            '    End If

            'Else
            '    StartUpScript(ChkMedium.ID, " Medium is Not Selected")
            '    End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetUpdate()

        Try
            objBoardEnrollment = New ClsBoardEnrollment
            Rtnvalue = objBoardEnrollment.GMSL_DELETE(TxtCollcode.Text)

            If Rtnvalue = 1 Then
                ' StartUpScript("", "Record Deleted Successfully")
                'ClearText()
            End If


            'RtnVal = objMaster.FDR_DELETE(dgGridSection.Items(e.Item.ItemIndex).Cells(1).Text)

            'If RtnVal = 1 Then
            '    FillGrid(PageIndex)
            '    StartUpScript("", "Record Deleted Successfully")
            'Else
            'End If

            'Dim DS As DataSet
            'Dim StrSql1, StrSql2, StrSql3 As String



            '    StrSql1 = "DELETE FROM M_GROUP_DT GRP WHERE (GRP.BOARDCOLLEGESLNO=(SELECT EBC.BOARDCOLLEGESLNO  FROM  EXAM_BOARDCOLLEGE_MT EBC WHERE EBC.CODE=" & TxtCollcode.Text & "))"

            '    StrSql2 = "DELETE FROM M_MEDIUM_DT MDM WHERE (MDM.BOARDCOLLEGESLNO=(SELECT EBC.BOARDCOLLEGESLNO  FROM  EXAM_BOARDCOLLEGE_MT EBC WHERE EBC.CODE=" & TxtCollcode.Text & "))"

            '    StrSql3 = "DELETE FROM M_SECONDLANG_DT SL WHERE (SL.BOARDCOLLEGESLNO=(SELECT EBC.BOARDCOLLEGESLNO  FROM  EXAM_BOARDCOLLEGE_MT EBC WHERE EBC.CODE=" & TxtCollcode.Text & "))"


            '    ObjResult = New Utility
            '    DS = ObjResult.DataSet_ThreeFetch(StrSql1, StrSql2, StrSql3)

            'If DS.Tables(0).Rows.Count > 0 Then

            '    Session("DS") = DS.Tables(0)
            'Else
            '    StartUpScript("", " Given College Code is Not Existed")

            'End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "DROPS"

    Private Sub FillDrops()
        Try
            drploc.Items.Clear()
            drploc.Items.Insert(0, New ListItem("Select", 0))
            drploc.Items.Insert(1, New ListItem("CROP", 1))
            drploc.Items.Insert(2, New ListItem("MUNC", 2))
            drploc.Items.Insert(3, New ListItem("MDL", 3))
            drploc.Items.Insert(4, New ListItem("PAN", 4))

            drpclgrun.Items.Clear()
            drpclgrun.Items.Insert(0, New ListItem("Select", 0))
            drpclgrun.Items.Insert(1, New ListItem("FUNCTIONING", 1))
            drpclgrun.Items.Insert(2, New ListItem("NON FUNCTIONING", 2))

            drpafflatest.Items.Clear()
            drpafflatest.Items.Insert(0, New ListItem("Select", 0))
            drpafflatest.Items.Insert(1, New ListItem("YES", 1))
            drpafflatest.Items.Insert(2, New ListItem("NO", 2))

            drpclgsch.Items.Clear()
            drpclgsch.Items.Insert(0, New ListItem("Select", 0))
            drpclgsch.Items.Insert(1, New ListItem("COLLEGE", 1))
            drpclgsch.Items.Insert(2, New ListItem("SCHOOL", 2))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Button Events"

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Dim i As Integer
        Dim Dr As DataRow
        Try

            MODE = Request.QueryString("MODE")
            If TxtCollcode.Text <> "" And TxtCollName.Text <> "" Then
                If Not ValidateForm() Then Exit Sub

                If MODE = "NEW" Then

                    'objBoardEnrollment.GRPMEMSL_Delete(TxtCollcode.Text)

                    objBoardEnrollment = New ClsBoardEnrollment
                    Rtnvalue = objBoardEnrollment.College_Insert(SetEntries())
                    GetUpdate()
                    ''GROUP
                    PrepareTableForGroups()
                    For i = 0 To Chkgroup.Items.Count - 1
                        If Chkgroup.Items(i).Selected Then
                            Dr = dsSet.Tables("GROUP").NewRow
                            Dr("GRPCODE") = CInt(Chkgroup.Items(i).Value)
                            Dr("CODE") = TxtCollcode.Text
                            dsSet.Tables("GROUP").Rows.Add(Dr)
                        End If
                    Next
                    dsSetIns = dsSet.Copy()
                    Rtnvalue = objBoardEnrollment.GROUP_Insert(dsSetIns)

                    ''GROUP
                    ''SL
                    PrepareTableForSecondLang()
                    For i = 0 To ChkSLang.Items.Count - 1
                        If ChkSLang.Items(i).Selected Then
                            Dr = dsSet.Tables("SCLG").NewRow
                            Dr("SLGCODE") = CInt(ChkSLang.Items(i).Value)
                            Dr("CODE") = TxtCollcode.Text
                            dsSet.Tables("SCLG").Rows.Add(Dr)
                        End If
                    Next
                    dsSetIns1 = dsSet.Copy()
                    Rtnvalue = objBoardEnrollment.SCLG_Insert(dsSetIns1)
                    ''SL
                    ''MDM
                    PrepareTableForMedium()
                    For i = 0 To ChkMedium.Items.Count - 1
                        If ChkMedium.Items(i).Selected Then
                            Dr = dsSet.Tables("MEDIUM").NewRow
                            Dr("MDMCODE") = CInt(ChkMedium.Items(i).Value)
                            Dr("CODE") = TxtCollcode.Text
                            dsSet.Tables("MEDIUM").Rows.Add(Dr)
                        End If
                    Next
                    dsSetIns2 = dsSet.Copy()
                    Rtnvalue = objBoardEnrollment.MDM_Insert(dsSetIns2)
                    ''MDM
                    If Rtnvalue = 1 Then
                        StartUpScript("", "Record Saved Successfully")
                        ClearText()
                    End If
                ElseIf MODE = "EDIT" Then
                    objBoardEnrollment = New ClsBoardEnrollment
                    ' objBoardEnrollment.GRPMEMSL_Delete(TxtCollcode.Text)
                    Rtnvalue = objBoardEnrollment.College_Update(SetEntries())
                    GetUpdate()
                    ''GROUP
                    PrepareTableForGroups()
                    For i = 0 To Chkgroup.Items.Count - 1
                        If Chkgroup.Items(i).Selected Then
                            Dr = dsSet.Tables("GROUP").NewRow
                            Dr("GRPCODE") = CInt(Chkgroup.Items(i).Value)
                            Dr("CODE") = TxtCollcode.Text
                            dsSet.Tables("GROUP").Rows.Add(Dr)
                        End If
                    Next
                    dsSetIns = dsSet.Copy()
                    Rtnvalue = objBoardEnrollment.GROUP_Insert(dsSetIns)

                    ''GROUP
                    ''SL
                    PrepareTableForSecondLang()
                    For i = 0 To ChkSLang.Items.Count - 1
                        If ChkSLang.Items(i).Selected Then
                            Dr = dsSet.Tables("SCLG").NewRow
                            Dr("SLGCODE") = CInt(ChkSLang.Items(i).Value)
                            Dr("CODE") = TxtCollcode.Text
                            dsSet.Tables("SCLG").Rows.Add(Dr)
                        End If
                    Next
                    dsSetIns1 = dsSet.Copy()
                    Rtnvalue = objBoardEnrollment.SCLG_Insert(dsSetIns1)
                    ''SL
                    ''MDM
                    PrepareTableForMedium()
                    For i = 0 To ChkMedium.Items.Count - 1
                        If ChkMedium.Items(i).Selected Then
                            Dr = dsSet.Tables("MEDIUM").NewRow
                            Dr("MDMCODE") = CInt(ChkMedium.Items(i).Value)
                            Dr("CODE") = TxtCollcode.Text
                            dsSet.Tables("MEDIUM").Rows.Add(Dr)
                        End If
                    Next
                    dsSetIns2 = dsSet.Copy()
                    Rtnvalue = objBoardEnrollment.MDM_Insert(dsSetIns2)
                    ''MDM
                    If Rtnvalue = 1 Then
                        StartUpScript("", "Record Update Successfully")
                        ClearText()
                    End If

                End If

            Else
                StartUpScript(TxtCollcode.ID, "Must Enter Admission no")
            End If


        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try

    End Sub

#End Region

#Region "DROPS"

    Private Sub drpclgsch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpclgsch.SelectedIndexChanged
        If drpclgsch.SelectedValue = 1 Then
            Table7.Visible = True
            Table6.Visible = False
        ElseIf drpclgsch.SelectedValue = 2 Then
            Table6.Visible = True
            Table7.Visible = False
        End If
    End Sub

#End Region

#End Region

  
End Class
