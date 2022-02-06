'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Student TC Request Entry Aprolls Form
'   AUTHOR                            : KISHORE
'   INITIAL BASELINE DATE             : 01-MAY-2013
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Public Class TcRequetAprolls
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents imgBtnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents drpBranch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgGridTcReqst As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Class Variabales"
    Private BrdStu As ClsBoardEnrollment
    Private USERSLNO As Integer
    Dim Util As New Utility
    Dim DsStudents As New DataSet
    Dim i, j, k As Integer
#End Region

#Region " PageEvents"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Put user code to initialize the page here
            If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
            USERSLNO = Session("USERSLNO")

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                BranchComboFill()
                PapareTableForTCRequest()
                FillGrid()
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

#Region "Fill Methods"

    Private Sub BranchComboFill()
        Try
            Dim Ds As DataSet
            Ds = Util.FillUserWise_ExamBranch(USERSLNO, Session("COMACADEMICSLNO"))
            drpBranch.DataSource = Ds
            drpBranch.DataTextField = "EXAMBRANCHNAME"
            drpBranch.DataValueField = "EXAMBRANCHSLNO"
            drpBranch.DataBind()
            drpBranch.Items.Insert(0, New ListItem("-All Branches-", 0))
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

    Private Sub FillGrid()

        Dim sqlQuery As String

        Try
            If drpBranch.SelectedValue > 0 Then

                sqlQuery = " SELECT adm.admslno, adm.admno, ebd.boardadmno || '/' || adm.admno boardadmno,adm.uniqueno, adm.NAME NAME, adm.exambranchslno branchslno," & _
                           " (adm.totalamttobepaid - adm.totallessamtreceived) - adm.totalamtpaid balance, adm.tcreqapproved, ebd.tcremark," & _
                           " code.ebname || '/' || code.code code,ebd.tcissuedcount FROM t_adm_dt adm,exam_studentcode code,exam_boardstudent_dt ebd," & _
                           " t_stutype_mt typ,t_medium_mt med WHERE adm.uniqueno = ebd.uniqueno AND adm.uniqueno = code.uniqueno AND adm.stutypeslno = typ.stutypeslno" & _
                           " AND adm.mediumslno = med.mediumslno AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & "  AND ADM.TCREQAPPROVED = 2" & _
                           " AND  ADM.EXAMBRANCHSLNO=" & drpBranch.SelectedItem.Value

                'sqlQuery = " SELECT ADM.ADMSLNO,ADM.ADMNO,EBD.BOARDADMNO,ADM.UNIQUENO,ADM.NAME NAME,ADM.EXAMBRANCHSLNO " & _
                '           " BRANCHSLNO,ADM.BALANCE,ADM.TCREQAPPROVED,EBD.TCREMARK FROM DO_ZON_REG_ADMDT ADM, EXAM_BOARDSTUDENT_DT EBD" & _
                '           " WHERE ADM.UNIQUENO = EBD.UNIQUENO  AND ADM.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & "   AND ADM.TCREQAPPROVED = 2 AND  ADM.EXAMBRANCHSLNO=" & drpBranch.SelectedItem.Value


            Else

                sqlQuery = " SELECT adm.admslno, adm.admno, ebd.boardadmno || '/' || adm.admno boardadmno,adm.uniqueno, adm.NAME NAME, adm.exambranchslno branchslno," & _
                           " (adm.totalamttobepaid - adm.totallessamtreceived) - adm.totalamtpaid balance, adm.tcreqapproved, ebd.tcremark," & _
                           " code.ebname || '/' || code.code code,ebd.tcissuedcount FROM t_adm_dt adm,exam_studentcode code,exam_boardstudent_dt ebd," & _
                           " t_stutype_mt typ,t_medium_mt med WHERE adm.uniqueno = ebd.uniqueno AND adm.uniqueno = code.uniqueno AND adm.stutypeslno = typ.stutypeslno" & _
                           " AND adm.mediumslno = med.mediumslno AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & "" & _
                           " AND ADM.TCREQAPPROVED = 2"


            End If

            i = GettingUsertype() ' Getting TC-APPROVAL ONLINE USERTYPE
            If i = 0 Then
                sqlQuery += " AND (adm.totalamttobepaid - adm.totallessamtreceived) - adm.totalamtpaid =0 "
            End If

            BrdStu = New ClsBoardEnrollment

            DsStudents = BrdStu.TcRequrest("TcRequrest1", DsStudents, "TCREQUEST", sqlQuery)

            If DsStudents.Tables("TCREQUEST").Rows.Count > 0 Then
                dgGridTcReqst.DataSource = DsStudents
                dgGridTcReqst.DataBind()

            Else
                DsStudents.Tables("TCREQUEST").Rows.Clear()
                dgGridTcReqst.DataSource = DsStudents
                dgGridTcReqst.DataBind()
                StartUpScript(iBtnSave.ID, "Data Not Found.")
            End If


            Me.Session("DsStudents") = DsStudents

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

    Private Sub FillGridData()

        Dim sqlQuery As String

        Try
            If drpBranch.SelectedValue > 0 Then

                sqlQuery = " SELECT ADM.ADMSLNO,ADM.ADMNO,EBD.BOARDADMNO||'/'||ADM.ADMNO BOARDADMNO,ADM.UNIQUENO,ADM.NAME NAME,ADM.EXAMBRANCHSLNO BRANCHSLNO,ADM.BALANCE,ADM.TCREQAPPROVED,EBD.TCREMARK," & _
                           " COR.NAME ||' / '|| GRP.NAME ||' / '|| BAT.NAME ||' / '|| SBT.NAME  ||' / '|| SEC.SECTION  ||' / '||  TYP.NAME  ||' / '||   MED.NAME||'/'||ADM.SPON_NAME CODE,EBD.TCISSUEDCOUNT FROM DO_ZON_REG_ADMDT ADM, EXAM_BOARDSTUDENT_DT EBD,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT," & _
                           " EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED WHERE     ADM.UNIQUENO = EBD.UNIQUENO AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO" & _
                           " AND ADM.BATCHSLNO = BAT.BATCHSLNO AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+) AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+) AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO" & _
                           " AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & "  AND ADM.TCREQAPPROVED = 2 AND  ADM.EXAMBRANCHSLNO=" & drpBranch.SelectedItem.Value

            Else

                sqlQuery = " SELECT ADM.ADMSLNO,ADM.ADMNO,EBD.BOARDADMNO||'/'||ADM.ADMNO BOARDADMNO,ADM.UNIQUENO,ADM.NAME NAME,ADM.EXAMBRANCHSLNO BRANCHSLNO,ADM.BALANCE,ADM.TCREQAPPROVED,EBD.TCREMARK, " & _
                           " COR.NAME ||' / '|| GRP.NAME ||' / '|| BAT.NAME ||' / '|| SBT.NAME  ||' / '|| SEC.SECTION  ||' / '||  TYP.NAME  ||' / '||   MED.NAME||'/'||ADM.SPON_NAME CODE,EBD.TCISSUEDCOUNT FROM DO_ZON_REG_ADMDT ADM, EXAM_BOARDSTUDENT_DT EBD,T_COURSE_MT COR,T_GROUP_MT GRP,T_BATCH_MT BAT," & _
                           " EXAM_SUBBATCH_MT SBT,EXAM_CGBSECTION SEC,T_STUTYPE_MT TYP,T_MEDIUM_MT MED WHERE     ADM.UNIQUENO = EBD.UNIQUENO AND ADM.COURSESLNO = COR.COURSESLNO AND ADM.GROUPSLNO = GRP.GROUPSLNO" & _
                           " AND ADM.BATCHSLNO = BAT.BATCHSLNO AND ADM.SUBBATCHSLNO = SBT.SUBBATCHSLNO(+) AND ADM.SECTIONSLNO = SEC.SECTIONSLNO(+) AND ADM.STUTYPESLNO = TYP.STUTYPESLNO AND ADM.MEDIUMSLNO = MED.MEDIUMSLNO" & _
                           " AND ADM.COMACADEMICSLNO = " & Session("COMACADEMICSLNO") & "  AND ADM.TCREQAPPROVED = 2"


            End If


            BrdStu = New ClsBoardEnrollment
            DsStudents = Me.Session("DsStudents")
            If DsStudents.Tables("TCREQUEST").Rows.Count > 0 Then DsStudents.Tables("TCREQUEST").Rows.Clear()
            DsStudents = BrdStu.TcRequrest("TcRequrest1", DsStudents, "TCREQUEST", sqlQuery)
            dgGridTcReqst.DataSource = DsStudents
            dgGridTcReqst.DataBind()


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

    Private Function SetEntires() As Boolean
        Try

            Dim i As Integer

            DsStudents = Me.Session("DsStudents")
            Me.Session("TC_REQAPPRVOEDUSERSLNO") = Session("USERSLNO")

            For i = 0 To DsStudents.Tables("TCREQUEST").Rows.Count - 1
                Dim gtxtP1, vtxtb1 As CheckBox
                gtxtP1 = dgGridTcReqst.Items(i).Cells(12).Controls(1)
                vtxtb1 = dgGridTcReqst.Items(i).Cells(11).Controls(1)
                If gtxtP1.Checked Then
                    DsStudents.Tables("TCREQUEST").Rows(i)("TCREQAPPROVED") = Val(1)
                Else
                    DsStudents.Tables("TCREQUEST").Rows(i)("TCREQAPPROVED") = Val(2)
                End If
                If vtxtb1.Checked = True Then DsStudents.Tables("TCREQUEST").Rows(i)("TCISSUEDCOUNT") = Val(0)
            Next
            Me.Session("DsStudents") = DsStudents
            'Dr("TC_REQAPPRVOEDUSERSLNO") = Session("USERSLNO")

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function DelSetEntires() As Boolean
        Try

            Dim i As Integer

            DsStudents = Me.Session("DsStudents")

            For i = 0 To DsStudents.Tables("TCREQUEST").Rows.Count - 1
                Dim gtxtP1 As CheckBox
                gtxtP1 = dgGridTcReqst.Items(i).Cells(10).Controls(1)

                If gtxtP1.Checked Then
                    DsStudents.Tables("TCREQUEST").Rows(i)("TCREQAPPROVED") = DBNull.Value
                End If
            Next
            Me.Session("DsStudents") = DsStudents

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Common Methods"

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")

        If focusCtrl <> "" And strMessage <> "" Then
            RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & FormName & "." & focusCtrl & " == '[object]') { document." & FormName & "." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
        ElseIf strMessage <> "" Then
            RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
        ElseIf focusCtrl <> "" Then
            RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & FormName & "." & focusCtrl & " == '[object]') { document." & FormName & "." & focusCtrl & ".focus(); } </script>")
        End If


    End Sub

#End Region

#Region " Methods"

    Private Sub PapareTableForTCRequest()
        Try
            Dim Dt As DataTable
            DsStudents.Tables.Add(New DataTable("TCREQUEST"))
            Dt = DsStudents.Tables("TCREQUEST")
            Dt.Columns.Add("ADMSLNO")
            Dt.Columns.Add("ADMNO")
            Dt.Columns.Add("BOARDADMNO")
            'Dt.Columns.Add("CODE")
            Dt.Columns.Add("UNIQUENO")
            Dt.Columns.Add("NAME")
            Dt.Columns.Add("BRANCHSLNO")
            Dt.Columns.Add("BALANCE")
            Dt.Columns.Add("TCREMARK")
            Dt.Columns.Add("TCREQAPPROVED")
            Dt.Columns.Add("CHECK")
            Me.Session("TC_REQAPPRVOEDUSERSLNO") = Session("USERSLNO")
            Me.Session("DsStudents") = DsStudents


        Catch ex As Exception

        End Try
    End Sub

    Private Function GettingUsertype() As Integer
        Try
            Dim Ds, DS1 As DataSet
            Util = New Utility

            DS1 = Util.DataSet_OneFetch("SELECT USERTYPESLNO FROM E_USER_USERTYPE_MT WHERE USERSLNO=" & Session("USERSLNO") & " AND COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " ORDER BY USERTYPESLNO")
            i = 0
            If DS1.Tables(0).Rows(0).Item(0) > 2 Then
                For j = 0 To DS1.Tables(0).Rows.Count - 1
                    If DS1.Tables(0).Rows(j).Item(0) = 42 Then
                        i += 1
                    End If
                Next
            End If
            Return i
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "ImgBtnEvents"

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Try
            Dim Result As String
            If Not SetEntires() Then Exit Sub

            DsStudents = Me.Session("DsStudents")
            If DsStudents.Tables("TCREQUEST").Rows.Count > 0 Then
                BrdStu = New ClsBoardEnrollment
                Result = BrdStu.TcRequest_Save(DsStudents, Session("COMACADEMICSLNO"), Session("USERSLNO"))
                If Result = "Saved" Then
                    StartUpScript(iBtnSave.ID, "Data Saved Successfully")
                    DsStudents.Tables("TCREQUEST").Rows.Clear()
                    'PapareTableForTCRequest()
                    FillGridData()

                End If
            Else
                StartUpScript(iBtnSave.ID, "Record Not Saved.")
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

    Private Sub imgBtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnGo.Click
        Try
            FillGrid()
        Catch ex As Exception

        End Try
    End Sub

#End Region

    
End Class
