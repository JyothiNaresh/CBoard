'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : ENTRY FORM FOR KEY OBJECTIONS FROM BRANCHES
'   AUTHOR                            : P.VENU
'   INITIAL BASELINE DATE             : 18.07.2011
'   FINAL BASELINE DATE               : 19.07.2011
'   COMPLETED DATE                    : 21.07.2011
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL

Public Class Objection_ObjectionEntry
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtPrince As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtLandLine As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtPrinceMob As System.Web.UI.WebControls.TextBox
    Protected WithEvents IbtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ImageButton2 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents DgTrans As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DrpExamBranch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpExamName As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpExamDate As System.Web.UI.WebControls.DropDownList
    Protected WithEvents IbtGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtCorrections As System.Web.UI.WebControls.TextBox
    Protected WithEvents LblSbjDetail As System.Web.UI.WebControls.Label
    Protected WithEvents LblPS As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " ==> FormVariables"

    Dim SqlStr, StrSplit, StrSplitStr(), StrSplitData, SplitStr, RtnVal, rtnString As String
    Dim objWSCombo As Utility
    Dim objTrans As NOETransaction
    Private DsSbj As DataSet
    Dim ObjFetch As Utility
    Dim Dset, DsSplit, DsQDet, MaindSet As New DataSet
    Dim i As Integer
    Public StrDet, StrDet1 As String
    Public DtQDet As New DataTable
    Dim Dgindex, StrPaperSetter As Integer
    Dim DrSbj() As DataRow

#End Region

#Region " ==> Page Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                FillExamBranch()
                FillExamNames()
            Else
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " ==> Fill Methods"

    Private Sub FillExamBranch()
        Try
            SqlStr = "SELECT EXAMBRANCHSLNO,EXAMBRANCHNAME FROM EXAM_EXAMBRANCH WHERE EXAMBRANCHSLNO IN (SELECT EXAMBRANCHSLNO FROM E_USER_BRANCH_ACADEMIC_MT WHERE COMACADEMICSLNO=" & Session("COMACADEMICSLNO") & " AND USERSLNO=" & Session("USERSLNO") & ") ORDER BY EXAMBRANCHNAME"
            objWSCombo = New Utility
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)
            DrpExamBranch.DataTextField = "EXAMBRANCHNAME"
            DrpExamBranch.DataValueField = "EXAMBRANCHSLNO"
            DrpExamBranch.DataSource = Dset
            DrpExamBranch.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillExamNames()
        Try
            SqlStr = "SELECT OBJEXAMSLNO,OBJEXAMNAME FROM OBJECTIONS_EXAMNAME_MT"
            'SqlStr = "SELECT OBJEXAMSLNO,OBJEXAMNAME FROM OBJECTIONS_EXAMNAME_MT"
            objWSCombo = New Utility
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)
            DrpExamName.DataTextField = "OBJEXAMNAME"
            DrpExamName.DataValueField = "OBJEXAMSLNO"
            DrpExamName.DataSource = Dset
            DrpExamName.DataBind()

            'FillEmptyGrid()
            FillExamDate()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillExamDate()
        Try
            SqlStr = "SELECT OBJTESTSLNO,TO_CHAR(OBJTESTDATE,'DD/MM/YYYY')||'/'||OBJTESTDESC OBJTESTDATE FROM OBJECTIONS_EXAM_DATE_MAP WHERE OBJEXAMSLNO=" & DrpExamName.SelectedItem.Value
            objWSCombo = New Utility
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)
            If Dset.Tables(0).Rows.Count <> 0 Then
                DrpExamDate.BackColor = Color.Empty
                DrpExamDate.DataTextField = "OBJTESTDATE"
                DrpExamDate.DataValueField = "OBJTESTSLNO"
                DrpExamDate.DataSource = Dset
                DrpExamDate.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillEmptyGrid()
        Try
            Dim dt As New DataTable
            dt.Columns.Add("SNO", Type.GetType("System.Int32"))
            For i As Integer = 1 To Val(TxtCorrections.Text)
                Dim dRow As DataRow
                dRow = dt.NewRow
                dRow("SNO") = i
                dt.Rows.Add(dRow)
            Next
            DgTrans.DataSource = dt
            DgTrans.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillDrpSubject()
        Try
            Dim i As Integer
            Dim dr As DataRow

            StrSplit = "SELECT SUBJECTS FROM OBJECTIONS_EXAM_DATE_MAP WHERE OBJTESTSLNO=" & DrpExamDate.SelectedItem.Value
            objWSCombo = New Utility
            DsSplit = objWSCombo.DataSet_OneFetch(StrSplit)

            SplitStr = DsSplit.Tables(0).Rows(0).Item(0).ToString
            StrSplitStr = SplitStr.Split(",")
            For i = 0 To StrSplitStr.Length - 1
                StrSplitData += StrSplitStr(i).ToString + IIf(StrSplitStr.Length - 1 <> i, ",", "")
            Next

            SqlStr = "SELECT SUBJECTSLNO,NAME FROM T_SUBJECT_MT WHERE SUBJECTSLNO IN(" & StrSplitData & ")"

            objWSCombo = New Utility
            If IsNothing(DsSbj) Then
                DsSbj = objWSCombo.DataSet_OneFetch(SqlStr)
                'Me.ViewState("DsSbj") = DsSbj
            End If

            Dim drpDown1 As DropDownList
            For i = 0 To Val(TxtCorrections.Text) - 1
                drpDown1 = CType(DgTrans.Items(i).Cells(1).FindControl("DrpSbj"), DropDownList)
                drpDown1.DataSource = DsSbj
                drpDown1.DataTextField = "NAME"
                drpDown1.DataValueField = "SUBJECTSLNO"
                drpDown1.DataBind()
            Next

            For i = 0 To DgTrans.Items.Count - 1
                Dim ddllist As DropDownList = CType(DgTrans.Items(i).Controls(1).FindControl("DrpQstn"), DropDownList)
                Dim cell As TableCell = CType(ddllist.Parent, TableCell)
                Dim item As DataGridItem = CType(cell.Parent, DataGridItem)
                Dim content As String = item.ItemIndex
                Dim ddlType As DropDownList = CType(item.Cells(1).FindControl("DrpSbj"), DropDownList)
                ExamQstnFrmto()
                DrSbj = DsQDet.Tables(0).Select("SUBJECTSLNO=" & ddlType.SelectedItem.Value)
                Dim ddlItem As DropDownList = CType(item.Cells(2).FindControl("DrpQstn"), DropDownList)
                If ddlItem.Items.Count <> 0 Then
                    ddlItem.Items.Clear()
                End If
                For j As Integer = DrSbj(0)(2) To DrSbj(0)(3)
                    ddlItem.Items.Add(New ListItem("Q" + j.ToString, j))
                Next
                ddlItem.DataBind()
            Next

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " ==> Methods"

    Private Function FormValidation()
        Try
            Dim FormVal As Integer = 0
            If DrpExamBranch.Items.Count = 0 Then
                DrpExamBranch.BackColor = Color.Red
                FormVal = 1
            Else
                DrpExamBranch.BackColor = Color.Empty
            End If

            If DrpExamName.Items.Count = 0 Then
                DrpExamName.BackColor = Color.Red
                FormVal = 1
            Else
                DrpExamName.BackColor = Color.Empty
            End If

            If DrpExamDate.Items.Count = 0 Then
                DrpExamDate.BackColor = Color.Red
                FormVal = 1
            Else
                DrpExamDate.BackColor = Color.Empty
            End If

            If TxtLandLine.Text = "" Then
                TxtLandLine.BorderColor = Color.Red
                FormVal = 1
            Else
                TxtLandLine.BorderColor = Color.Empty
            End If

            If TxtPrince.Text = "" Then
                TxtPrince.BorderColor = Color.Red
                FormVal = 1
            Else
                TxtPrince.BorderColor = Color.Empty
            End If

            If TxtPrinceMob.Text = "" Then
                TxtPrinceMob.BorderColor = Color.Red
                FormVal = 1
            Else
                TxtPrinceMob.BorderColor = Color.Empty
            End If

            If Val(TxtCorrections.Text) = 0 Then
                TxtCorrections.BorderColor = Color.Red
                FormVal = 1
            Else
                TxtCorrections.BorderColor = Color.Empty
            End If

            If FormVal = 1 Then
                StartUpScript("Validation", " Verify Your Selection (Red Marked..!)")
                Return False
            Else
                Return True
            End If

        Catch ex As Exception

        End Try
    End Function

    Private Function GridValidation()
        Try
            Dim VDrpSbj As DropDownList
            Dim VTxtQstn, VTxtWk, VTxtCk, VTxtRem, VTxtLect, VTxtLMob As TextBox
            Dim StrSubjects, StrQFrom, StrQto As String
            Dim GridVal As Integer = 0

            For i As Integer = 0 To DgTrans.Items.Count - 1
                'VDrpSbj = DgTrans.Items(i).Cells(1).Controls(1)
                'VTxtQstn = DgTrans.Items(i).Cells(2).Controls(1)
                VTxtWk = DgTrans.Items(i).Cells(4).Controls(1)
                VTxtCk = DgTrans.Items(i).Cells(5).Controls(1)
                VTxtRem = DgTrans.Items(i).Cells(6).Controls(1)
                VTxtLect = DgTrans.Items(i).Cells(7).Controls(1)
                VTxtLMob = DgTrans.Items(i).Cells(8).Controls(1)

                'If VDrpSbj.Items.Count = 0 Then
                '    VDrpSbj.BackColor = Color.Red
                '    GridVal = 1
                'Else
                '    VDrpSbj.BackColor = Color.Empty
                'End If

                'If VTxtQstn.Text = "" Then
                '    VTxtQstn.BorderColor = Color.Red
                '    GridVal = 1
                'Else
                '    VTxtQstn.BorderColor = Color.Empty
                'End If

                If VTxtWk.Text = "" Then
                    VTxtWk.BorderColor = Color.Red
                    GridVal = 1
                Else
                    VTxtWk.BorderColor = Color.Empty
                End If

                If VTxtCk.Text = "" Then
                    VTxtCk.BorderColor = Color.Red
                    GridVal = 1
                Else
                    VTxtCk.BorderColor = Color.Empty
                End If

                If Trim(VTxtWk.Text) = Trim(VTxtCk.Text) Then
                    VTxtWk.BorderColor = Color.Red
                    VTxtCk.BorderColor = Color.Red
                    VTxtWk.ToolTip = "WrongKey and CorrectKey should not be Same...!"
                    VTxtCk.ToolTip = "WrongKey and CorrectKey should not be Same...!"
                    GridVal = 1
                Else
                    VTxtWk.BorderColor = Color.Empty
                    VTxtWk.BorderColor = Color.Empty
                    VTxtWk.ToolTip = ""
                    VTxtCk.ToolTip = ""
                End If

                If VTxtRem.Text = "" Then
                    VTxtRem.BorderColor = Color.Red
                    GridVal = 1
                Else
                    VTxtRem.BorderColor = Color.Empty
                End If
                If VTxtLect.Text = "" Then
                    VTxtLect.BorderColor = Color.Red
                    GridVal = 1
                Else
                    VTxtLect.BorderColor = Color.Empty
                End If

                If VTxtLMob.Text = "" Then
                    VTxtLMob.BorderColor = Color.Red
                    GridVal = 1
                Else
                    VTxtLMob.BorderColor = Color.Empty
                End If
            Next

            If GridVal = 1 Then
                StartUpScript("Validation", " Verify Your Selection (Red Marked..!)")
                Return False
            Else
                Return True
            End If

        Catch ex As Exception

        End Try
    End Function

    Private Function ExamQstnFrmto()
        Try
            Dim VSb, SelSbjs(), VQf, SelQfrom(), VQt, SelQto(), SelSbjsName(), Str1, Str2, Str3 As String

            SqlStr = "SELECT SUBJECTS,QFROM,QTO FROM OBJECTIONS_EXAM_DATE_MAP WHERE OBJTESTSLNO=" & DrpExamDate.SelectedItem.Value
            objWSCombo = New Utility
            Dim Drow() As DataRow
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)
            VSb = Dset.Tables(0).Rows(0).Item(0).ToString
            VQf = Dset.Tables(0).Rows(0).Item(1).ToString
            VQt = Dset.Tables(0).Rows(0).Item(2).ToString
            SelSbjs = VSb.Split(",")
            For i = 0 To SelSbjs.Length - 1
                Str1 += SelSbjs(i).ToString + IIf(i <> SelSbjs.Length - 1, ",", "")
            Next
            SqlStr = "SELECT NAME,SUBJECTSLNO FROM T_SUBJECT_MT WHERE SUBJECTSLNO IN(" & Str1 & ")"
            objWSCombo = New Utility
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)

            For i = 0 To SelSbjs.Length - 1
                Drow = Dset.Tables(0).Select("SUBJECTSLNO=" & SelSbjs(i))
                Str2 += Drow(0)("NAME").ToString + IIf(i <> SelSbjs.Length - 1, ",", "")
            Next
            SelSbjsName = Str2.Split(",")
            SelQfrom = VQf.Split(",")
            SelQto = VQt.Split(",")
            DtQDet.Columns.Add("SUBJECTSLNO", Type.GetType("System.Int32"))
            DtQDet.Columns.Add("SUBJECTNAME", Type.GetType("System.String"))
            DtQDet.Columns.Add("QFROM", Type.GetType("System.Int32"))
            DtQDet.Columns.Add("QTO", Type.GetType("System.Int32"))

            For i = 0 To SelSbjs.Length - 1
                Dim dr As DataRow
                dr = DtQDet.NewRow
                dr("SUBJECTSLNO") = SelSbjs(i)
                dr("SUBJECTNAME") = SelSbjsName(i).ToString
                dr("QFROM") = SelQfrom(i)
                dr("QTO") = SelQto(i)
                DtQDet.Rows.Add(dr)
            Next

            For i = 0 To DtQDet.Rows.Count - 1
                Str3 += DtQDet.Rows(i).Item(1).ToString + " - (" + DtQDet.Rows(i).Item(2).ToString + " - " + DtQDet.Rows(i).Item(3).ToString + ")" + IIf(i <> Dset.Tables(0).Rows.Count - 1, " ; ", "")
            Next
            StrDet = " SUBJECTS : " + Str3

            SqlStr = "SELECT EXAMBRANCHSLNO,EXAMBRANCHNAME FROM EXAM_EXAMBRANCH WHERE EXAMBRANCHSLNO IN(SELECT OBJEXAMPAPERSETTER FROM OBJECTIONS_EXAM_DATE_MAP WHERE OBJTESTSLNO=" & DrpExamDate.SelectedItem.Value & ")"
            objWSCombo = New Utility
            Dset = objWSCombo.DataSet_OneFetch(SqlStr)
            If Dset.Tables(0).Rows.Count <> 0 Then
                StrPaperSetter = Dset.Tables(0).Rows(0).Item(0)
                strDet1 = " PAPERSETTER : " + Dset.Tables(0).Rows(0).Item(1).ToString
            End If
            DsQDet.Tables.Add(DtQDet)
            Session("StrPaperSetter") = StrPaperSetter
            Return DtQDet
            Return StrDet
            Return DsQDet
            Return StrPaperSetter
        Catch ex As Exception

        End Try
    End Function

    Private Function GridDataforSave()
        Try
            Dim ArrMt As New ArrayList
            Dim ArrDt As New ArrayList
            Dim S_Sbj, S_Qno As DropDownList
            Dim S_Wk, S_Ck, S_Rem, S_Lect, S_LMob As TextBox
            Dim GridValidation As Boolean = True
            Dim RtnSave As Integer
            StrPaperSetter = Session("StrPaperSetter")

            'Master
            ArrMt.Add(DrpExamBranch.SelectedItem.Value)
            ArrMt.Add(TxtLandLine.Text)
            ArrMt.Add(TxtPrince.Text)
            ArrMt.Add(TxtPrinceMob.Text)
            ArrMt.Add(DrpExamName.SelectedItem.Value)
            ArrMt.Add(DrpExamDate.SelectedItem.Value)
            ArrMt.Add(Val(TxtCorrections.Text))
            ArrMt.Add(Session("COMACADEMICSLNO"))
            ArrMt.Add(StrPaperSetter)

            'Details
            Dim VDt As New DataTable("GridData")
            Dim VDr As DataRow
            VDt.Columns.Add("OBJTESTSLNO", Type.GetType("System.Int32"))
            VDt.Columns.Add("OBJSUBJECTSLNO", Type.GetType("System.Int32"))
            VDt.Columns.Add("OBJQUESTIONNO", Type.GetType("System.Int32"))
            VDt.Columns.Add("OBJGIVENKEY", Type.GetType("System.String"))
            VDt.Columns.Add("OBJCORRECTKEY", Type.GetType("System.String"))
            VDt.Columns.Add("OBJREMARKS", Type.GetType("System.String"))
            VDt.Columns.Add("OBJLECTURER", Type.GetType("System.String"))
            VDt.Columns.Add("OBJLECTMOBILE", Type.GetType("System.String"))
            VDt.Columns.Add("OBJCOMACADEMICSLNO", Type.GetType("System.Int32"))

            For i As Integer = 0 To DgTrans.Items.Count - 1
                S_Sbj = DgTrans.Items(i).Cells(1).Controls(1)
                S_Qno = DgTrans.Items(i).Cells(2).Controls(1)
                S_Wk = DgTrans.Items(i).Cells(4).Controls(1)
                S_Ck = DgTrans.Items(i).Cells(5).Controls(1)
                S_Rem = DgTrans.Items(i).Cells(6).Controls(1)
                S_Lect = DgTrans.Items(i).Cells(7).Controls(1)
                S_LMob = DgTrans.Items(i).Cells(8).Controls(1)

                VDr = VDt.NewRow
                VDr("OBJTESTSLNO") = DrpExamDate.SelectedItem.Value
                VDr("OBJSUBJECTSLNO") = S_Sbj.SelectedItem.Value
                VDr("OBJQUESTIONNO") = S_Qno.SelectedItem.Value
                VDr("OBJGIVENKEY") = S_Wk.Text
                VDr("OBJCORRECTKEY") = S_Ck.Text
                VDr("OBJREMARKS") = Trim(S_Rem.Text)
                VDr("OBJLECTURER") = S_Lect.Text
                VDr("OBJLECTMOBILE") = S_LMob.Text
                VDr("OBJCOMACADEMICSLNO") = Session("COMACADEMICSLNO")
                VDt.Rows.Add(VDr)
            Next

            MaindSet.Tables.Add(VDt)

            RtnSave = objTrans.OBJECTION_INSERT(MaindSet, ArrMt)

            Return RtnSave

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ClearScreen()
        Try
            DgTrans.Visible = False
            TxtLandLine.Text = Nothing
            TxtPrince.Text = Nothing
            TxtPrinceMob.Text = Nothing
            TxtCorrections.Text = Nothing
            LblSbjDetail.Visible = False
            LblPS.Visible = False
        Catch ex As Exception

        End Try

    End Function

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

#Region " ==> Ibtn Events"

    Private Sub IbtGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtGo.Click
        Try
            If FormValidation() Then
                LblSbjDetail.Visible = True
                LblPS.Visible = True
                ExamQstnFrmto()
                LblSbjDetail.Text = StrDet.ToString
                LblPS.Text = StrDet1.ToString
                DgTrans.Visible = True
                FillEmptyGrid()
                FillDrpSubject()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IbtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnSave.Click
        Try
            Dim ValRtn As Integer
            If GridValidation() Then
                objTrans = New NOETransaction
                ValRtn = GridDataforSave()
                If ValRtn = 1 Then
                    StartUpScript(IbtnSave.ID, "Data Inserted Successfully..!")
                Else
                    StartUpScript(IbtnSave.ID, " Error in Error in Insertion..!")
                End If
                ClearScreen()
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " ==> DropDown Events"

    Private Sub DrpExamName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpExamName.SelectedIndexChanged
        Try
            LblSbjDetail.Visible = False
            LblPS.Visible = False
            DgTrans.Visible = False
            FillExamDate()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DrpSbj_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            'Dgindex = Session("Dgindex")
            'Dim DrpGSbj As DropDownList = CType(DgTrans.Items(Dgindex + 1).Controls(1).FindControl("DrpSbj"), DropDownList)
            'Dim DrpSbjslno As Integer = DrpGSbj.SelectedItem.Value
            'ExamQstnFrmto()
            'Dim DrpGQstn As DropDownList = CType(DgTrans.Items(Dgindex + 1).Controls(1).FindControl("DrpQstn"), DropDownList)
            'If DrpGQstn.Items.Count <> 0 Then
            '    DrpGQstn.Items.Clear()
            'End If
            'For i = 0 To DtQDet.Rows.Count
            '    DrpGQstn.Items.Add(New ListItem("Q" + DtQDet.Rows(i).Item(2).ToString, i))
            'Next
            'DrpGQstn.DataBind()
            ' Response.Write(DrpSbjslno.ToString)
            Dim ddllist As DropDownList = CType(sender, DropDownList)
            Dim cell As TableCell = CType(ddllist.Parent, TableCell)
            Dim item As DataGridItem = CType(cell.Parent, DataGridItem)
            Dim content As String = item.ItemIndex
            Dim ddlType As DropDownList = CType(item.Cells(1).FindControl("DrpSbj"), DropDownList)
            ExamQstnFrmto()
            DrSbj = DsQDet.Tables(0).Select("SUBJECTSLNO=" & ddlType.SelectedItem.Value)
            Dim ddlItem As DropDownList = CType(item.Cells(2).FindControl("DrpQstn"), DropDownList)
            If ddlItem.Items.Count <> 0 Then
                ddlItem.Items.Clear()
            End If
            For i = DrSbj(0)(2) To DrSbj(0)(3)
                ddlItem.Items.Add(New ListItem("Q" + i.ToString, i))
            Next
            ddlItem.DataBind()

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " ==> Rough"

    Private Sub DgTrans_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DgTrans.ItemDataBound
        Try
            Dim dr As DataRowView = CType(e.Item.DataItem, DataRowView)
            If ((e.Item.ItemType = ListItemType.Item) OrElse (e.Item.ItemType = ListItemType.AlternatingItem)) Then
                Dim DrpGsbj As DropDownList = CType(e.Item.FindControl("DrpSbj"), DropDownList)
                Dim DrpGQstn As DropDownList = CType(e.Item.FindControl("DrpQstn"), DropDownList)
                Dim cell As TableCell = CType(DrpGQstn.Parent, TableCell)
                Dim item As DataGridItem = CType(cell.Parent, DataGridItem)
                Dim content As String = item.ItemIndex
                'Dim ddlType As DropDownList = CType(item.Cells(1).FindControl("DrpSbj"), DropDownList)
                ' ExamQstnFrmto()
                DrSbj = DsQDet.Tables(0).Select("SUBJECTSLNO=" & DrpGsbj.SelectedItem.Value)
                'Dim ddlItem As DropDownList = CType(item.Cells(2).FindControl("DrpQstn"), DropDownList)

                For i = DrSbj(0)(2) To DrSbj(0)(3)
                    DrpGQstn.Items.Add(New ListItem("Q" + i.ToString, i))
                Next
                DrpGQstn.DataBind()
            End If
            'Dgindex = e.Item.DataSetIndex
            ''StartUpScript("", e.Item.ItemIndex.ToString + "-" + e.Item.DataSetIndex.ToString)
            'Session("Dgindex") = Dgindex
            'Dim DrpVq As DropDownList = e.Item.FindControl("DrpQstn")

        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
