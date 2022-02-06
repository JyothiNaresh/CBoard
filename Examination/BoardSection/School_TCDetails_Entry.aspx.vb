'++++++++++++++++++++++++++++++++++++++++++++++++++++++
'AUTHOR         : P.VENU
'DESCRIPTION    : SCHOOL TC DETAILS ENTRY & UPLOAD
'++++++++++++++++++++++++++++++++++++++++++++++++++++++

Imports System.IO
Imports System.IO.Path
Imports CollegeBoardDLL

Public Class School_TCDetails_Entry
    Inherits System.Web.UI.Page

#Region " % Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtSetfocus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMessage As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtlblCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents imgBtnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents dgTCDetails As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lstmdEBranch As System.Web.UI.HtmlControls.HtmlSelect
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents rdbRequetAprvl As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdbRequestEntry As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rdbDetailsEntry As System.Web.UI.WebControls.RadioButton

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " % Class_Variables"

    Private objWSCombo As ClsComboBoxFilling
    Private ds_Gen, ds_Prepare As DataSet
    Private SqlStr As String
    Private clsUtil As Utility
    Private clsSchoolTc As ClsBoarddt
    Private i, j, PageIndex As Integer

#End Region

#Region " % Page_Methods"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Try
            If Not IsPostBack Then
                Fill_ExamBranch()
                GettingUsertype()
                'PrepareTable()
            Else
                PageIndex = viewstate("PageIndex")
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

#Region " % Fill_Methods"

    Private Sub Fill_ExamBranch()
        Try

            objWSCombo = New ClsComboBoxFilling
            ds_Gen = objWSCombo.USERWISEEB(Session("USERSLNO"), Session("COMACADEMICSLNO"))

            lstmdEBranch.DataSource = ds_Gen.Tables(0)
            lstmdEBranch.DataTextField = "EXAMBRANCHNAME"
            lstmdEBranch.DataValueField = "EXAMBRANCHSLNO"
            lstmdEBranch.DataBind()

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

    Private Sub Fill_Grid(ByVal PageIndex As Integer)
        Try
            If lstmdEBranch.Value <> "" Then

                SqlStr = " SELECT  A.UNIQUENO,A.ADMSLNO,A.EXAMBRANCHSLNO,A.COMACADEMICSLNO,A.ADMNO,A.NAME,A.CODE,B.TCBOOKNO,B.TCNO,TCFILEPATH,DECODE(TCFILEPATH,NULL,0,1) TCFLAG,to_CHAR(A.PAIDPER, '999.99') PAIDPER,C.REQSLNO,C.REQENTRY_DESC " & _
                         " FROM EXAM_STUDENTCODE A,BOARD_SCH_TCGIVEN_DT B ,SCHOOLTC_REQUEST_DT C,T_COURSE_MT D " & _
                         " WHERE A.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & " AND A.STATUS IN (1,7,8) AND A.EXAMBRANCHSLNO=" & lstmdEBranch.Value & " AND D.TCUPLOAD=1 AND A.ADMSLNO=B.ADMSLNO(+) AND A.ADMSLNO=C.ADMSLNO(+) AND A.COURSESLNO=D.COURSESLNO "

                'If rdbDetailsEntry.Checked Then
                '    SqlStr += " AND C.REQSLNO(+) = 2"
                'End If

                If rdbRequestEntry.Checked = True Then
                    SqlStr += " AND A.PAIDPER < 100 AND REQSLNO IS NULL "
                End If

                If rdbRequetAprvl.Checked Then
                    SqlStr += " AND C.REQSLNO = 1  "
                End If

                SqlStr += "ORDER BY A.ADMNO"

                clsUtil = New Utility
                ds_Gen = clsUtil.DataSet_OneFetch(SqlStr)

                If Not ds_Gen Is Nothing Then

                    If ds_Gen.Tables(0).Rows.Count > 0 Then

                        '' Setting Page Indexs
                        If (ds_Gen.Tables(0).Rows.Count - 1) / 50 < PageIndex Then

                            If ((ds_Gen.Tables(0).Rows.Count - 1) / 50) <= 1 Then
                                PageIndex = 0
                            Else
                                PageIndex = PageIndex - 1
                            End If
                        End If
                    Else
                        'Dim dRow As DataRow
                        'For i = 0 To 49
                        '    dRow = ds_Gen.Tables(0).NewRow
                        '    dRow(0) = i + 1
                        '    ds_Gen.Tables(0).Rows.Add(dRow)
                        'Next
                    End If

                End If

                dgTCDetails.CurrentPageIndex = PageIndex
                dgTCDetails.DataSource = ds_Gen
                dgTCDetails.DataBind()

                If rdbDetailsEntry.Checked Then

                    dgTCDetails.Columns(5).Visible = True
                    dgTCDetails.Columns(6).Visible = True
                    dgTCDetails.Columns(7).Visible = True
                    dgTCDetails.Columns(8).Visible = True

                    dgTCDetails.Columns(9).Visible = False
                Else
                    dgTCDetails.Columns(5).Visible = False
                    dgTCDetails.Columns(6).Visible = False
                    dgTCDetails.Columns(7).Visible = False
                    dgTCDetails.Columns(8).Visible = False

                    dgTCDetails.Columns(9).Visible = True
                End If

            Else
                StartUpScript(lstmdEBranch.ID, " Select ExamBranch")
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

#Region " % Common_Methods"

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

    'Private Sub PrepareTable()
    '    Try
    '        Dim dt As DataTable
    '        ds_Prepare = New DataSet
    '        ds_Prepare.Tables.Add(New DataTable("TCDET"))
    '        dt = ds_Prepare.Tables("TCDET")
    '        dt.Columns.Add("iUNIQUENO", Type.GetType("System.Int32"))
    '        dt.Columns.Add("iADMSLNO", Type.GetType("System.Int32"))
    '        dt.Columns.Add("iEXAMBRANCHSLNO", Type.GetType("System.Int32"))
    '        dt.Columns.Add("iTCBOOKNO", Type.GetType("System.Int32"))
    '        dt.Columns.Add("iTCNO", Type.GetType("System.Int32"))
    '        dt.Columns.Add("iTCFILEPATH", Type.GetType("System.String"))
    '        dt.Columns.Add("iCOMACADEMICSLNO", Type.GetType("System.Int32"))
    '        dt.Columns.Add("iINSUPD", Type.GetType("System.Int32"))

    '        Session("ds_Prepare") = ds_Prepare

    '    Catch Oex As OracleException
    '        StartUpScript("", DataBaseErrorMessage(Oex.Message))
    '        If Session("USERID") Is Nothing Then
    '            OracleLogFile("USERID := " & "SRIHARI" & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
    '            "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
    '        Else
    '            OracleLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
    '            "Page Info := " & Oex.StackTrace & vbCrLf & "Database Info :=" & Oex.Message & vbCrLf)
    '        End If
    '    Catch ex As Exception
    '        If GeneralErrorMessage(ex.Message) <> "" Then
    '            If Not Session("USERID") Is Nothing Then
    '                IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
    '                "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
    '                StartUpScript("", GeneralErrorMessage(ex.Message))
    '            End If
    '        End If
    '    End Try
    'End Sub

    'Private Sub Upload_Tc(ByVal Fup As HtmlInputFile, ByVal Admslno As Integer)
    '    Try

    '        Dim FileExtn As String = GetExtension(Fup.PostedFile.FileName)
    '        Dim FileName As String = Admslno.ToString + "-" + GetFileName(Fup.PostedFile.FileName)
    '        If FileExtn = ".jpeg" Or FileExtn = ".gif" Then
    '            If Not Directory.Exists("D:/SCH_TC/" & Session("ACYEAR") & "/" & FldName) Then
    '                Directory.CreateDirectory("D:/SMSUPLOAD_EXCEL/" & Session("ACYEAR") & "/" & FldName)
    '            End If
    '            USERFILENAME = fileupload.PostedFile.FileName.Substring(fileupload.PostedFile.FileName.LastIndexOf("\", fileupload.PostedFile.FileName.Length) + 1)

    '            If Not FileDum.Exists("D:/SMSUPLOAD_EXCEL/" & Session("ACYEAR") & "/" & FldName & "/" & Session("USERSLNO").ToString & "-" & fileupload.PostedFile.FileName.Substring(fileupload.PostedFile.FileName.LastIndexOf("\", fileupload.PostedFile.FileName.Length) + 1)) Then
    '                fileupload.PostedFile.SaveAs("D:/SMSUPLOAD_EXCEL/" & Session("ACYEAR") & "/" & FldName & "/" & Session("USERSLNO").ToString & "-" & fileupload.PostedFile.FileName.Substring(fileupload.PostedFile.FileName.LastIndexOf("\", fileupload.PostedFile.FileName.Length) + 1))

    '                FileName = fileupload.PostedFile.FileName.Substring(fileupload.PostedFile.FileName.LastIndexOf("\", fileupload.PostedFile.FileName.Length) + 1)
    '                FilePath = "D:\SMSUPLOAD_EXCEL\" & Session("ACYEAR") & "\" & FldName & "\" & Session("USERSLNO").ToString & "-" & fileupload.PostedFile.FileName.Substring(fileupload.PostedFile.FileName.LastIndexOf("\", fileupload.PostedFile.FileName.Length) + 1)
    '                RtnVal = Saving2DataBase(FileName, FilePath, FileUpdTime, LblUserMobile.Text, TxtSmsSubject.Text, DrpDept.SelectedItem.Value)
    '                If RtnVal = 1 Then
    '                    StartUpScript(IbtnSave.ID, " DataSaved Successfully..!")
    '                Else
    '                    File.Delete(FilePath)
    '                End If
    '            Else
    '                StartUpScript(fileupload.ID, "  Already File Name Exists  ")
    '            End If
    '        Else
    '            StartUpScript(IbtnSave.ID, " Please Upload Excel File Only ")
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Function FrmValidate(ByVal TcBookNo As String, ByVal TcNo As String, ByVal filp As String, ByVal fillen As Integer, ByVal TCReqDesc As String) As Boolean
        Try

            If rdbDetailsEntry.Checked Then
                If TcBookNo = "" Then
                    StartUpScript("", "Enter TcBookNo")
                    Return False
                End If

                If TcNo = "" Then
                    StartUpScript("", "Enter TcNo")
                    Return False
                End If

                If filp = "" Then
                    StartUpScript("", "Select TcImage ")
                    Return False
                End If

                If (fillen / 1024) > 500 Then
                    StartUpScript("", "Image Size Exceeds 500KB..ToResize Images Goto : http://www.picresize.com")
                    Return False
                End If

            ElseIf rdbRequestEntry.Checked Then
                If TCReqDesc = "" Then
                    StartUpScript("", "Enter Description")
                    Return False
                End If
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
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                If Not Session("USERID") Is Nothing Then
                    IISLogFile("USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Format(Today, "dd/MM/yyyy") & "  " & TimeString & vbCrLf & _
                    "Page Info := " & ex.StackTrace & vbCrLf & "Database Info :=" & ex.Message & vbCrLf)
                    StartUpScript("", GeneralErrorMessage(ex.Message))
                End If
            End If
        End Try
    End Function

    Private Function GettingUsertype() As Integer
        Try
            Dim Tc_i, Tc_j, Tc_k, Tc_l As Integer

            Dim Ds, DS1 As DataSet
            clsUtil = New Utility

            DS1 = clsUtil.DataSet_OneFetch("SELECT   MT.USERTYPESLNO,MT.TC_DET FROM E_USER_USERTYPE_MT DT,E_USERTYPE_MT MT WHERE DT.USERSLNO = " & Session("USERSLNO") & " AND DT.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & " AND MT.USERTYPESLNO=DT.USERTYPESLNO AND MT.TC_DET IS NOT NULL ORDER BY MT.USERTYPESLNO")
            i = 0

            For j = 0 To DS1.Tables(0).Rows.Count - 1
                If DS1.Tables(0).Rows(j).Item(1) = 1 Then
                    Tc_i += 1
                End If
                If DS1.Tables(0).Rows(j).Item(1) = 2 Then
                    Tc_j += 1
                End If
                If DS1.Tables(0).Rows(j).Item(1) = 3 Then
                    Tc_k += 1
                End If
                If Not IsDBNull(DS1.Tables(0).Rows(j).Item(1)) Then
                    Tc_l += 1
                Else
                    Tc_l = ""
                End If
            Next

            If Tc_k > 0 Then
                rdbRequetAprvl.Visible = True
            Else
                rdbRequetAprvl.Visible = False
            End If

            If Tc_i > 0 Then
                rdbDetailsEntry.Visible = True
            Else
                rdbDetailsEntry.Visible = False
            End If

            If Tc_j > 0 Then
                rdbRequestEntry.Visible = True
            Else
                rdbRequestEntry.Visible = False
            End If

            If Tc_l = 0 Then
                lstmdEBranch.Visible = False
                imgBtnGo.Visible = False
            Else
                lstmdEBranch.Visible = True
            End If

            Return i

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " % ImgBtn_Events"

    Private Sub imgBtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnGo.Click
        Try
            Fill_Grid(0)
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

#Region " % Grid_Events"

    Private Sub dgTCDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgTCDetails.ItemDataBound
        Try

            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim txtTcBookno As TextBox = CType(e.Item.Cells(5).Controls(1).FindControl("txtTCBookNO"), TextBox)
                Dim txtTcno As TextBox = CType(e.Item.Cells(6).Controls(1).FindControl("txtTCNO"), TextBox)
                Dim txtReqDesc As TextBox = CType(e.Item.Cells(9).Controls(1).FindControl("txtTCDESC"), TextBox)
                Dim fuUpload As HtmlInputFile = CType(e.Item.Cells(7).Controls(1).FindControl("tcfilepath1"), HtmlInputFile)

                If Val(e.Item.Cells(4).Text) < 100 Then
                    If Val(e.Item.Cells(15).Text) = 2 Then
                        e.Item.Cells(5).Enabled = True : txtTcBookno.Enabled = True
                        e.Item.Cells(6).Enabled = True : txtTcno.Enabled = True
                        e.Item.Cells(7).Enabled = True : fuUpload.Disabled = False
                        e.Item.Cells(8).Enabled = True
                        Dim HypNew1 As HyperLink = CType(e.Item.Cells(8).Controls(1).FindControl("HypNew"), HyperLink)
                        If Val(e.Item.Cells(11).Text) = 1 Then
                            e.Item.Cells(8).Enabled = True
                            HypNew1.Enabled = True
                        Else
                            e.Item.Cells(8).Enabled = False
                            HypNew1.Enabled = False
                        End If
                        e.Item.Cells(9).Enabled = True
                        e.Item.Cells(10).Enabled = True
                        e.Item.Cells(11).Enabled = True
                        e.Item.Cells(4).ForeColor = Color.Purple
                        e.Item.Cells(4).ToolTip = "Request Approved"
                    Else
                        e.Item.Cells(5).Enabled = False : txtTcBookno.Enabled = False
                        e.Item.Cells(6).Enabled = False : txtTcno.Enabled = False
                        e.Item.Cells(7).Enabled = False : fuUpload.Disabled = True
                        e.Item.Cells(8).Enabled = False
                        Dim HypNew1 As HyperLink = CType(e.Item.Cells(8).Controls(1).FindControl("HypNew"), HyperLink)
                        HypNew1.Enabled = False
                        e.Item.Cells(9).Enabled = False : txtReqDesc.Enabled = False
                        e.Item.Cells(10).Enabled = False
                        e.Item.Cells(11).Enabled = False
                        If Val(e.Item.Cells(15).Text) = 1 Then
                            e.Item.Cells(4).ForeColor = Color.Orange
                            e.Item.Cells(4).ToolTip = "Request Pending Contact Central Office"
                        Else
                            e.Item.Cells(4).ForeColor = Color.Red
                            e.Item.Cells(4).ToolTip = "Fee Peding Contact Central Office"
                        End If
                    End If
                Else
                    Dim HypNew1 As HyperLink = CType(e.Item.Cells(8).Controls(1).FindControl("HypNew"), HyperLink)
                    If Val(e.Item.Cells(11).Text) = 1 Then
                        e.Item.Cells(8).Enabled = True
                        HypNew1.Enabled = True
                    Else
                        e.Item.Cells(8).Enabled = False
                        HypNew1.Enabled = False
                    End If
                    e.Item.Cells(4).ForeColor = Color.Green
                End If
                If rdbRequestEntry.Checked Or rdbRequetAprvl.Checked Then
                    'Request/Approved
                    e.Item.Cells(10).Enabled = True
                    e.Item.Cells(9).Enabled = True : txtReqDesc.Enabled = True
                End If
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

    Private Sub dgTCDetails_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTCDetails.EditCommand
        Try
            Dim RtnVal As Integer
            Dim FileExtn, FileName, FldName, USERFILENAME, FilePath As String

            Dim StrUse As String = dgTCDetails.Items(e.Item.ItemIndex).Cells(1).Text
            Dim stu_Flag As Integer = dgTCDetails.Items(e.Item.ItemIndex).Cells(11).Text
            Dim stu_Uniqueno As Integer = dgTCDetails.Items(e.Item.ItemIndex).Cells(12).Text
            Dim stu_Admslno As Integer = dgTCDetails.Items(e.Item.ItemIndex).Cells(13).Text
            Dim stu_ExamBranchslno As Integer = dgTCDetails.Items(e.Item.ItemIndex).Cells(14).Text
            Dim txtTcBookno As TextBox = CType(e.Item.Cells(5).Controls(1).FindControl("txtTCBookNO"), TextBox)
            Dim txtTcno As TextBox = CType(e.Item.Cells(6).Controls(1).FindControl("txtTCNO"), TextBox)
            Dim txtReqDesc As TextBox = CType(e.Item.Cells(9).Controls(1).FindControl("txtTCDESC"), TextBox)

            Dim FlName As String
            Dim FlLen As Integer

            Dim fuUpload As HtmlInputFile = CType(e.Item.Cells(7).Controls(1).FindControl("tcfilepath1"), HtmlInputFile)
            If Not IsNothing(fuUpload.PostedFile) Then
                FlName = fuUpload.PostedFile.FileName
                FlLen = fuUpload.PostedFile.ContentLength
            Else
                FlName = ""
                FlLen = 0
            End If
            If FrmValidate(txtTcBookno.Text, txtTcno.Text, FlName, FlLen, txtReqDesc.Text) Then

                Dim Arr As New ArrayList

                If rdbDetailsEntry.Checked Then
                    Dim FileDum As File
                    FileExtn = GetExtension(fuUpload.PostedFile.FileName)
                    FileName = Session("USERSLNO").ToString + "-" + GetFileName(fuUpload.PostedFile.FileName)

                    If FileExtn = ".jpeg" Or FileExtn = ".jpg" Or FileExtn = ".gif" Then

                        If Not Directory.Exists("E:/SCHOOLTCS/" & Session("ACYEAR")) Then
                            Directory.CreateDirectory("E:/SCHOOLTCS/" & Session("ACYEAR"))
                        End If
                        If FileDum.Exists("E:/SCHOOLTCS/" & Session("ACYEAR") & "/" & stu_Admslno.ToString + FileExtn.ToString) Then
                            FileDum.Delete("E:/SCHOOLTCS/" & Session("ACYEAR") & "/" & stu_Admslno.ToString + FileExtn.ToString)
                        End If
                        fuUpload.PostedFile.SaveAs("E:/SCHOOLTCS/" & Session("ACYEAR") & "/" & stu_Admslno.ToString + FileExtn.ToString)
                        FilePath = "http:\\192.168.111.11\SCHOOLTCS\" & Session("ACYEAR") & "\" & stu_Admslno.ToString + FileExtn.ToString
                        'FilePath = "http:\\192.100.100.47\SCHOOLTCS\" & Session("ACYEAR") & "\" & stu_Admslno.ToString + FileExtn.ToString

                    Else
                        StartUpScript("", " Please Upload Images Only ")
                    End If
                    Arr.Add(stu_Uniqueno)
                    Arr.Add(stu_Admslno)
                    Arr.Add(stu_ExamBranchslno)
                    Arr.Add(CInt(txtTcBookno.Text))
                    Arr.Add(CInt(txtTcno.Text))
                    Arr.Add(FilePath.ToString)
                    Arr.Add(stu_Flag)

                    clsSchoolTc = New ClsBoarddt
                    RtnVal = clsSchoolTc.BOARDSCHTCDETAILS_INSERT(Arr)

                Else
                    Arr.Add(stu_Uniqueno)
                    Arr.Add(stu_Admslno)
                    Arr.Add(Session("COMACADEMICSLNO"))
                    If rdbRequestEntry.Checked Then
                        Arr.Add(Session("USERSLNO"))
                        Arr.Add(txtReqDesc.Text)
                        Arr.Add(System.DBNull.Value)
                        Arr.Add("")
                        Arr.Add(System.DBNull.Value)
                        Arr.Add(1)
                    ElseIf rdbRequetAprvl.Checked Then
                        Arr.Add(System.DBNull.Value)
                        Arr.Add("")
                        Arr.Add(System.DBNull.Value)
                        Arr.Add("")
                        Arr.Add(Session("USERSLNO"))
                        Arr.Add(2)
                    End If
                    clsSchoolTc = New ClsBoarddt
                    RtnVal = clsSchoolTc.BOARDSCHTCREQUEST_ERA(Arr)

                End If

                Fill_Grid(PageIndex)

                If RtnVal = 1 Then
                    If rdbDetailsEntry.Checked Then
                        StartUpScript("", " Tc Saved Successfully...!")
                    ElseIf rdbRequestEntry.Checked Then
                        StartUpScript("", " Request Saved Successfully...!")
                    ElseIf rdbRequetAprvl.Checked Then
                        StartUpScript("", " Request Approved Successfully...!")
                    End If
                Else
                    StartUpScript("", " Error While Saving..!")
                End If

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

    Private Sub dgTCDetails_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgTCDetails.PageIndexChanged
        Try
            PageIndex = e.NewPageIndex
            ViewState("PageIndex") = PageIndex

            Fill_Grid(PageIndex)
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

#Region " % RadioButton_Events"

    Private Sub rdbDetailsEntry_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDetailsEntry.CheckedChanged
        Try
            If lstmdEBranch.Value <> "" Then
                Fill_Grid(0)
            Else
                StartUpScript(lstmdEBranch.ID, " Select ExamBranch")
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

    Private Sub rdbRequestEntry_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbRequestEntry.CheckedChanged
        Try
            If lstmdEBranch.Value <> "" Then
                Fill_Grid(0)
            Else
                StartUpScript(lstmdEBranch.ID, " Select ExamBranch")
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

    Private Sub rdbRequetAprvl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbRequetAprvl.CheckedChanged
        Try
            If lstmdEBranch.Value <> "" Then
                Fill_Grid(0)
            Else
                StartUpScript(lstmdEBranch.ID, " Select ExamBranch")
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

    Protected Sub chkVerify_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim chkver As CheckBox = CType(sender, CheckBox)
            Dim cell As TableCell = CType(chkver.Parent, TableCell)
            Dim item As DataGridItem = CType(cell.Parent, DataGridItem)

            Dim stu_Admslno As Integer = item.Cells(6).Text

        Catch ex As Exception

        End Try
    End Sub
End Class
