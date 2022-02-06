Imports CollegeBoardDLL
Imports System.Data
Imports System.Data.OracleClient
Imports System.Web.UI.WebControls
Public Class UsertypewiseUserDetails
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents tabMain As System.Web.UI.WebControls.Table
    Protected WithEvents lblnote As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents DrpDo As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Class vars"
    Dim Utl As Utility
#End Region

#Region "Page Load"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Session("USERSLNO") Is Nothing Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                DoFill()
                htmlReport()
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

#Region "Fill Drp"

    Private Sub DoFill()
        Try
            Dim Ds As DataSet
            Utl = New Utility

            '' Ds = Utl.DataSet_OneFetch("SELECT 	DISTINCT A.DOSLNO SLNO ,A.NAME NAME FROM T_DO_MT A, T_BRANCH_MT B, T_COMPANY_BRANCH_COURSE_MT C WHERE A.DOSLNO=B.DOSLNO AND B.BRANCHSLNO=C.BRANCHSLNO AND C.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " ORDER BY A.NAME ")
            Ds = Utl.DataSet_OneFetch("SELECT 	A.EXAMBRANCHSLNO SLNO,A.EXAMBRANCHNAME NAME FROM EXAM_EXAMBRANCH A,EXAM_ACYEXAMBRANCH_DT B WHERE A.EXAMBRANCHSLNO=B.EXAMBRANCHSLNO AND B.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " ORDER BY EXAMBRANCHNAME ")
            DrpDo.DataSource = Ds
            DrpDo.DataTextField = "NAME"
            DrpDo.DataValueField = "SLNO"
            DrpDo.DataBind()
            'DrpDo.Items.Insert(0, New ListItem("All", 0))
        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Html Methods"

    Private Function getTextColoumn(ByVal cssStyle As String, ByVal Text As String, Optional ByVal ColumnSpan As Int64 = 0, Optional ByVal HorizantalAlign As HorizontalAlign = HorizontalAlign.Center, Optional ByVal rowSpan As Integer = 0, Optional ByVal toolTip As String = "") As TableCell

        Dim tc As New TableCell
        tc.ColumnSpan = ColumnSpan
        tc.RowSpan = rowSpan
        tc.ToolTip = toolTip
        tc.HorizontalAlign = HorizantalAlign
        tc.CssClass = cssStyle
        tc.Controls.Add(New LiteralControl(Text))
        Return tc

    End Function

    Private Function getLinkColoumn(ByVal cssStyle As String, ByVal Text As String, ByVal url As String, Optional ByVal rowSpan As Int16 = 0, Optional ByVal coloumnSpan As Int16 = 0, Optional ByVal toolTip As String = "") As TableCell

        Dim tc As New TableCell
        Dim hypLi As New HyperLink

        hypLi.Text = Text
        hypLi.NavigateUrl = url
        tc.CssClass = cssStyle
        tc.RowSpan = rowSpan
        tc.ToolTip = toolTip
        tc.ColumnSpan = coloumnSpan
        tc.Controls.Add(hypLi)

        Return tc

    End Function

    Private Function CommonHeading(ByVal noOfColoumns As Integer, ByVal ColHeadings As String, Optional ByVal HorizantalAlign As HorizontalAlign = HorizontalAlign.Center) As TableRow

        Dim temp As Integer = 1
        Dim intHeadingLength As Integer
        Dim tr As New TableRow
        tr.CssClass = "SubHeading1"


        'tr.BackColor = Color.FromArgb(66, 33, 0)
        'tr.ForeColor = Color.White
        'tr.Height = Unit.Pixel(20)
        'tr.Font.Bold = True
        'tr.HorizontalAlign = HorizontalAlign.Center

        For i As Integer = 1 To noOfColoumns
            Dim tc As New TableCell
            tc.HorizontalAlign = HorizantalAlign
            tc.Wrap = False

            intHeadingLength = InStr(1, ColHeadings, ",")
            If intHeadingLength > 0 Then
                tc.Text = ColHeadings.Substring(0, intHeadingLength - 1)
                ColHeadings = ColHeadings.Substring(intHeadingLength)
            Else
                tc.Text = ColHeadings
            End If

            tr.Cells.Add(tc)

        Next

        Return tr

    End Function

    Private Function htmlReport()

        Try
            Dim data As New DataSet
            Dim strSqlUsers As String

            strSqlUsers = "SELECT DISTINCT USR.USERSLNO SLNO,USR.USERID USERID,EMP.NAME||' '||EMP.SURNAME NAME,USR.STATUS STATUS,(CASE WHEN USR.ISMACCHECK=0 THEN 'Un Register' ELSE 'Register' END) REG,EMP.MOBILE PHONE,	EBR.EXAMBRANCHNAME EBRANCH," & _
                          " EMP.BRANCHNAME PBRANCH,EMP.DESIGNATIONNAME DESIG,TO_CHAR(USR.CREATEDATE,'DD/MM/YYYY') CDATE FROM EXAM_USER_MT USR, PAYROLLNEW.V_EMP_DT EMP, EXAM_EXAMBRANCH EBR, E_USER_USERTYPE_MT UUM WHERE USR.EMPSLNO=EMP.EMPSLNO AND	EMP.EXAMBRANCHSLNO=EBR.EXAMBRANCHSLNO AND " & _
                          " USR.USERSLNO=UUM.USERSLNO AND	UUM.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND USR.USERSLNO IN(SELECT DISTINCT UBA.USERSLNO FROM E_USER_BRANCH_ACADEMIC_MT UBA,  T_BRANCH_MT BMT, EXAM_EXAMBRANCH EBM,	E_USER_USERTYPE_MT UUM WHERE   " & _
                          " EBM.BRANCHSLNO=BMT.BRANCHSLNO AND EBM.EXAMBRANCHSLNO=UBA.EXAMBRANCHSLNO AND UBA.EXAMBRANCHSLNO=" & DrpDo.SelectedValue & " AND UBA.COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " ) ORDER BY USERID"

            Utl = New Utility
            data = Utl.DataSet_OneFetch(strSqlUsers)


            If data.Tables(0).Rows.Count > 0 Then

                lblnote.Visible = False
                tabMain.Visible = True
                tabMain.Rows.Clear()

                tabMain.Rows.Add(CommonHeading(10, "Sno.,User ID,Name,Status,Registerd,Phone,EBranch,PBranch,Designation,Created Date"))

                Dim i, j, uid, rowSpan, tempVar As Integer
                Dim rowcolor As Integer
                Dim repoBackColor As String

                For i = 0 To data.Tables(0).Rows.Count - 1   '''rows

                    Dim tr As New TableRow
                    If rowcolor = 0 Then
                        repoBackColor = "GridItem"
                        rowcolor = 1
                    Else
                        repoBackColor = "GridAlternateItem"
                        rowcolor = 0
                    End If
                    tr.CssClass = repoBackColor

                    tr.Cells.Add(getTextColoumn("", i + 1, , HorizontalAlign.Left))
                    tr.Cells.Add(getLinkColoumn("", data.Tables(0).Rows(i).Item("USERID"), "javascript:disDetails(" & data.Tables(0).Rows(i).Item("SLNO") & ")"))
                    tr.Cells.Add(getTextColoumn("", data.Tables(0).Rows(i).Item("NAME"), , HorizontalAlign.Left))
                    tr.Cells.Add(getTextColoumn("", data.Tables(0).Rows(i).Item("STATUS"), , HorizontalAlign.Left))
                    tr.Cells.Add(getTextColoumn("", data.Tables(0).Rows(i).Item("REG"), , HorizontalAlign.Left))
                    If Not IsDBNull(data.Tables(0).Rows(i).Item("PHONE")) Then
                        tr.Cells.Add(getTextColoumn("", data.Tables(0).Rows(i).Item("PHONE"), , HorizontalAlign.Left))
                    Else
                        tr.Cells.Add(getTextColoumn("", "--", , HorizontalAlign.Left))
                    End If
                    tr.Cells.Add(getTextColoumn("", data.Tables(0).Rows(i).Item("EBRANCH"), , HorizontalAlign.Left))
                    tr.Cells.Add(getTextColoumn("", data.Tables(0).Rows(i).Item("PBRANCH"), , HorizontalAlign.Left))
                    tr.Cells.Add(getTextColoumn("", data.Tables(0).Rows(i).Item("DESIG"), , HorizontalAlign.Left))
                    tr.Cells.Add(getTextColoumn("", data.Tables(0).Rows(i).Item("CDATE"), , HorizontalAlign.Left))
                    tabMain.Rows.Add(tr)

                Next

            Else
                lblnote.Visible = False
                tabMain.Visible = False
                lblnote.Visible = True
                lblnote.Text = "No Users found, in your selection ."

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "Drp Changed"

    Private Sub DrpDo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpDo.SelectedIndexChanged
        htmlReport()
    End Sub

#End Region



End Class
