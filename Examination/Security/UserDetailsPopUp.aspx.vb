Imports CollegeBoardDLL
Imports System.Data
Imports System.Data.OracleClient
Imports System.Web.UI.WebControls

Public Class UserDetailsPopUp
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblnote As System.Web.UI.WebControls.Label
    Protected WithEvents tabDetails As System.Web.UI.WebControls.Table

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Class Vars"
    Dim userslno As Integer


#End Region

#Region "Page Load"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If Session("USERSLNO") Is Nothing Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not Request.QueryString("uno") = Nothing Then
                userslno = Request.QueryString("uno")

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

#End Region

#Region "Html Functions"

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

    Private Function addTablesTocells(ByVal dataBras As DataSet)
        Try
            Dim tab As New Table
            If dataBras.Tables(0).Rows.Count > 0 Then

                lblnote.Visible = False
                tabDetails.Visible = True
                tabDetails.Rows.Clear()

                Dim i, j, uid, rowSpan, tempVar As Integer
                Dim rowcolor As Integer
                Dim repoBackColor As String

                For i = 0 To dataBras.Tables(0).Rows.Count - 1   '''rows

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
                    tr.Cells.Add(getTextColoumn("", dataBras.Tables(0).Rows(i).Item("NAME"), , HorizontalAlign.Left))

                    tab.Rows.Add(tr)

                Next

            Else
                lblnote.Visible = False
                tabDetails.Visible = False
                lblnote.Visible = True
                lblnote.Text = "No Branchs found, in your selection ."

            End If

            Return tab

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex

        End Try
    End Function

    Private Function htmlReport()

        Try
            Dim dataBras As New DataSet
            Dim dataUserType As New DataSet
            Dim strSqlBras, strSqlType As String


            strSqlBras = "  SELECT  DISTINCT UBA.USERSLNO, UBA.EXAMBRANCHSLNO, BM.EXAMBRANCHNAME NAME  FROM E_USER_BRANCH_ACADEMIC_MT UBA, EXAM_EXAMBRANCH BM " & _
                         " WHERE BM.EXAMBRANCHSLNO = UBA.EXAMBRANCHSLNO AND UBA.USERSLNO=" & userslno & " AND UBA.COMACADEMICSLNO=" & Session("COMACADEMICSLNO")

            strSqlType = " SELECT  DISTINCT UTM.NAME,UUTM.USERTYPESLNO, UUTM.USERSLNO, UTM.DESCRIPTION  FROM E_USER_USERTYPE_MT UUTM, E_USERTYPE_MT UTM " & _
                        "  WHERE UTM.USERTYPESLNO = UUTM.USERTYPESLNO And UUTM.USERSLNO=" & userslno



            'tabDetails.Rows.Add(CommonHeading(2, "USer Branches,User Type"))
           
            Dim Utl As Utility
            Utl = New Utility


            Dim TR As New TableRow
            Dim rowcolor As Integer
            Dim repoBackColor As String

            If rowcolor = 0 Then
                repoBackColor = "GridItem"
                rowcolor = 1
            Else
                repoBackColor = "GridAlternateItem"
                rowcolor = 0
            End If
            TR.CssClass = repoBackColor


            Dim TC1 As New TableCell
            Dim TC2 As New TableCell

            TC1.Controls.Add(addTablesTocells(Utl.DataSet_OneFetch(strSqlBras)))

            TC2.Controls.Add(addTablesTocells(Utl.DataSet_OneFetch(strSqlType)))
            TR.Cells.Add(TC1)
            TR.Cells.Add(TC2)

            tabDetails.Rows.Add(TR)
            tabDetails.Rows.AddAt(0, CommonHeading(2, "USer Branches,User Type"))


        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
   

End Class
