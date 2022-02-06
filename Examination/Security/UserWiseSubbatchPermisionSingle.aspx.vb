'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is Presentation Layer For Users View
'   ACTIVITY                          : User Wise Subbatch Permission View
'   AUTHOR                            : K.SHANKAR SUDERSHAN RAO
'   INITIAL BASELINE DATE             : 08-March-2010
'   FINAL BASELINE DATE               : 09-March-2010
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Public Class UserWiseSubbatchPermisionSingle
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpUserTypes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpAcaSlno As System.Web.UI.WebControls.DropDownList
    Protected WithEvents iBtnSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ibtSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ibtnCancel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents drpCourse As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblCourse As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents drpGroup As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ChkSubbatches As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents ibtnSBSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ChkCheckbatch As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ChkCheckSubbatch As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ChkBatches As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents TblBatch As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents TblSubbatch As System.Web.UI.HtmlControls.HtmlTable

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

    Private ds As New DataSet
    Private webcls As New WebTree
    Private Formname As String = "Form2"
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Private Mode As String
    Private userslno As Integer
    Private objUscls As UserClass
    Private RtnStr, SqlStr As String
    Private objWS As ClsBCEGBS
    Private objWSCombo As ClsComboBoxFilling
    Private ClsUty As New Utility
    Private UserTypeslno As Integer = 0
    Dim DSet As DataSet
    Dim COURSESLNO, GROUPSLNO, BATCHSLNO As Integer
#End Region

#Region "General Methods"

    Private Sub ClearControls()
        Try
           
            FillBatch()

            DrpUserTypes.SelectedIndex = 0
            drpCourse.SelectedIndex = 0
            drpGroup.SelectedIndex = 0

            TblSubbatch.Visible = False

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")
        Try
            If focusCtrl <> "" And strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & Formname & "." & focusCtrl & " == '[object]') { document." & Formname & "." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf focusCtrl <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & Formname & "." & focusCtrl & " == '[object]') { document." & Formname & "." & focusCtrl & ".focus(); } </script>")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Methods"

    Private Function SetEntriesBranch() As DataSet
        Dim dsBranch As New DataSet

        Dim dt As New DataTable
        Dim dtU As New DataTable
        Dim dRow As DataRow
        Dim drowu As DataRow
        Try

            dt.Columns.Add("USERSLNO", GetType(System.Int16))
            dt.Columns.Add("COURSESLNO", GetType(System.Int16))
            dt.Columns.Add("GROUPSLNO", GetType(System.Int16))
            dt.Columns.Add("BATCHSLNO", GetType(System.Int16))
            dt.Columns.Add("SUBBATCHSLNO", GetType(System.Int16))
            dt.Columns.Add("COMACADEMICSLNO", GetType(System.Int16))
            dsBranch.Tables.Add(dt)

            If ChkBatches.Items.Count > 0 Then
                If ChkSubbatches.Items.Count > 0 Then
                    For i As Integer = 0 To ChkBatches.Items.Count - 1 'THis Loop For Combinations Checked
                        For j As Integer = 0 To ChkSubbatches.Items.Count - 1 'THis Loop For Combinations Checked
                            If ChkBatches.Items(i).Selected = True Then
                                If ChkSubbatches.Items(j).Selected = True Then
                                    dRow = dsBranch.Tables(0).NewRow
                                    dRow("USERSLNO") = userslno
                                    dRow("COURSESLNO") = drpCourse.SelectedValue
                                    dRow("GROUPSLNO") = drpGroup.SelectedValue
                                    dRow("BATCHSLNO") = ChkBatches.Items(i).Value
                                    dRow("SUBBATCHSLNO") = ChkSubbatches.Items(j).Value
                                    dRow("COMACADEMICSLNO") = drpAcaSlno.SelectedValue
                                    dsBranch.Tables(0).Rows.Add(dRow)
                                End If
                            End If
                        Next
                    Next
                End If
            End If


            Return dsBranch

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function PageValidations1() As Boolean
        Try
            Dim i, j As Integer
            If drpAcaSlno.SelectedIndex = -1 Then
                StartUpScript(drpAcaSlno.ID, "Select Academic Year.")
                Return False
            End If

            For i = 0 To ChkBatches.Items.Count - 1
                If ChkBatches.Items(i).Selected Then
                    j = 1
                    Exit For
                End If
            Next
            If j = 0 Then
                TblSubbatch.Visible = False
                StartUpScript(ChkBatches.ID, "Please check atleast one Batch.")
                Return False
            End If

            Return True

        Catch ex As Exception

        End Try
    End Function
    Private Function PageValidations2() As Boolean
        Try
            Dim i, j As Integer

            For i = 0 To ChkSubbatches.Items.Count - 1
                If ChkSubbatches.Items(i).Selected Then
                    j = 1
                    Exit For
                End If
            Next
            If j = 0 Then
                StartUpScript(ChkSubbatches.ID, "Please check atleast one SubBatch.")
                Return False
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "Load Event"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim str As String = ""
        ds = New DataSet
        Dim dsBranch As New DataSet
        Dim dsAcaYr As New DataSet
        Try
            If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
            Mode = Request.QueryString("Mode")
            userslno = CInt(Request.QueryString("userslno"))
            UserTypeslno = CInt(Request.QueryString("USERTYPESLNO"))

            If Not Request.QueryString("COURSESLNO") Is Nothing AndAlso Request.QueryString("COURSESLNO") <> "" Then COURSESLNO = CInt(Request.QueryString("COURSESLNO"))
            If Not Request.QueryString("GROUPSLNO") Is Nothing AndAlso Request.QueryString("GROUPSLNO") <> "" Then GROUPSLNO = CInt(Request.QueryString("GROUPSLNO"))

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                TblBatch.Visible = False
                TblSubbatch.Visible = False
                FillAcademiyears()
                FillCourse()
                FillGroup()
                FillBatch()
                FillEditCombinations(userslno)
                Dim iCOMACASLNO As Integer = drpAcaSlno.SelectedValue
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

#Region "Fill Methods"

    Private Sub FillAcademiyears()
        Try
            Dim dsAcaYr As DataSet
            dsAcaYr = ClsUty.DataSet_Fetch("SELECT COMACADEMICSLNO,NAME FROM T_COMPANYACADEMICYEAR_MT")
            If dsAcaYr.Tables(0).Rows.Count > 0 Then
                drpAcaSlno.DataSource = dsAcaYr
                drpAcaSlno.DataTextField = "NAME"
                drpAcaSlno.DataValueField = "COMACADEMICSLNO"
                drpAcaSlno.DataBind()

                drpAcaSlno.SelectedValue = Session("COMACADEMICSLNO")

            End If
        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")


        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")


        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")

        End Try
    End Sub

    Private Sub FillCourse()
        Try
            Dim dsCourse As DataSet
            objWSCombo = New ClsComboBoxFilling
            dsCourse = objWSCombo.Course_Fetch("A")
            drpCourse.DataSource = dsCourse.Tables(0)
            drpCourse.DataTextField = "NAME"
            drpCourse.DataValueField = "SLNO"
            drpCourse.DataBind()

            ''drpCourse.Items.Insert(0, New ListItem("All", 0))

            If COURSESLNO <> 0 Then
                drpCourse.SelectedValue = COURSESLNO
            End If

        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")


        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")


        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")

        End Try

    End Sub

    Private Sub FillGroup()
        Try
            Dim dsGroup As DataSet
            objWS = New ClsBCEGBS
            dsGroup = objWS.Group_Fill(drpCourse.SelectedValue)
            drpGroup.DataSource = dsGroup.Tables(0)
            drpGroup.DataTextField = "GROUPNAME"
            drpGroup.DataValueField = "GROUPSLNO"
            drpGroup.DataBind()

            ''drpGroup.Items.Insert(0, New ListItem("All", 0))

            If GROUPSLNO <> 0 Then
                drpGroup.SelectedValue = GROUPSLNO
            End If

        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")


        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")


        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")

        End Try

    End Sub

    Private Sub FillBatch()
        Try
            Dim dsBatch As DataSet
            Dim str1 As String
            objWS = New ClsBCEGBS
            'dsBatch = objWS.Batch_Fill(drpCourse.SelectedValue, drpGroup.SelectedValue)

            str1 = "SELECT DISTINCT NAME BATCHNAME, BATCHSLNO FROM T_BATCH_MT WHERE BATCHSLNO IN(SELECT DISTINCT BATCHSLNO FROM T_ADM_DT WHERE COMACADEMICSLNO=" & drpAcaSlno.SelectedValue & " AND COURSESLNO=" & drpCourse.SelectedValue & " AND GROUPSLNO=" & drpGroup.SelectedValue & "  AND STATUS IN(1,5,8)) ORDER BY NAME"

            dsBatch = ClsUty.DataSet_Fetch(str1)


            If Not dsBatch Is Nothing AndAlso dsBatch.Tables(0).Rows.Count > 0 Then

                TblBatch.Visible = True
                ChkBatches.DataSource = dsBatch.Tables(0)
                ChkBatches.DataTextField = "BATCHNAME"
                ChkBatches.DataValueField = "BATCHSLNO"
                ChkBatches.DataBind()
            Else
                TblBatch.Visible = False
            End If

            'ChkBatches.Items.Insert(0, New ListItem("All", 0))

            ''If BATCHSLNO <> 0 Then
            ''    ChkBatches.SelectedValue = BATCHSLNO
            ''End If

        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")


        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")


        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")

        End Try

    End Sub

    Private Sub FillSubBatch()
        Dim I As Integer
        Dim StrBatch As String
        Try
            If drpCourse.SelectedIndex <> -1 AndAlso drpGroup.SelectedIndex <> -1 And ChkBatches.Items.Count > 0 Then

                If ChkBatches.Items.Count > 0 Then
                    StrBatch &= " AND BATCHSLNO IN (" 'CGBS.
                    For I = 0 To ChkBatches.Items.Count - 1
                        If ChkBatches.Items(I).Selected = True Then
                            StrBatch &= Val(ChkBatches.Items(I).Value.ToString) & IIf(I = ChkBatches.Items.Count - 1, " ", ",")
                        End If
                    Next
                End If

                StrBatch = StrBatch.TrimEnd(",") & ")"

                'SqlStr = "SELECT DISTINCT CGBS.SUBBATCHSLNO,SB.NAME SUBBATCHNAME FROM EXAM_CGBSUBBATCH_MT CGBS,EXAM_SUBBATCH_MT SB WHERE " & _
                '         " CGBS.SUBBATCHSLNO=SB.SUBBATCHSLNO AND CGBS.COURSESLNO=" & drpCourse.SelectedValue & " AND CGBS.GROUPSLNO=" & drpGroup.SelectedValue & StrBatch

                SqlStr = " SELECT  DISTINCT SUBBATCHSLNO,NAME SUBBATCHNAME FROM EXAM_SUBBATCH_MT WHERE SUBBATCHSLNO IN(SELECT DISTINCT SUBBATCHSLNO FROM T_ADM_DT" & _
                      " WHERE COMACADEMICSLNO=" & drpAcaSlno.SelectedValue & " AND COURSESLNO=" & drpCourse.SelectedValue & " AND GROUPSLNO=" & drpGroup.SelectedValue & "  " & StrBatch & " AND STATUS IN(1,5,8))"


                DSet = ClsUty.GetCommDataSet(SqlStr)
                If Not DSet Is Nothing AndAlso DSet.Tables(0).Rows.Count > 0 Then
                    TblSubbatch.Visible = True
                    ChkSubbatches.DataSource = DSet
                    ChkSubbatches.DataTextField = "SUBBATCHNAME"
                    ChkSubbatches.DataValueField = "SUBBATCHSLNO"
                    ChkSubbatches.DataBind()
                Else
                    TblSubbatch.Visible = False
                End If

            End If

        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)
            StartUpScript(Me.ID, " Transaction  Failed ")
            Throw ORAEX
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                        "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
                StartUpScript(Me.ID, " Transaction  Failed ")
                Throw ex
            End If

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)
            StartUpScript(Me.ID, " Transaction  Failed ")
            Throw OmEx
        End Try


    End Sub

    Private Sub FillUsersType()
        Try
            Dim dsStuType As DataSet
            dsStuType = ClsUty.DataSet_Fetch("SELECT USERTYPESLNO,NAME FROM E_USERTYPE_MT WHERE USERTYPESLNO<>1 ORDER BY NAME")
            DrpUserTypes.DataSource = dsStuType
            DrpUserTypes.DataTextField = "NAME"
            DrpUserTypes.DataValueField = "USERTYPESLNO"
            DrpUserTypes.DataBind()
            If UserTypeslno > 0 Then
                DrpUserTypes.SelectedValue = UserTypeslno
            Else
                DrpUserTypes.SelectedValue = 3
            End If

        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")


        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")


        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")

        End Try
    End Sub

    Private Sub FillEditCombinations(ByVal userslno As Integer)
        Dim DsUser, Dscomb As DataSet
        Dim i, j As Integer
        Try
            objUscls = New UserClass

            ''DsUser = objUscls.GetUserInformation(userslno)

            Dscomb = objUscls.GetUserSubbatchInformation(userslno, drpCourse.SelectedValue, drpGroup.SelectedValue, drpAcaSlno.SelectedValue)


            TblBatch.Visible = True
            TblSubbatch.Visible = True

            If Dscomb.Tables(0).Rows.Count > 0 Then
                For i = 0 To Dscomb.Tables(0).Rows.Count - 1
                    For j = 0 To ChkBatches.Items.Count - 1
                        If ChkBatches.Items(j).Value = Dscomb.Tables(0).Rows(i)("BATCHSLNO") Then
                            ChkBatches.Items(j).Selected = True
                        End If
                    Next
                Next

                FillSubBatch()

                For i = 0 To Dscomb.Tables(0).Rows.Count - 1
                    For j = 0 To ChkSubbatches.Items.Count - 1
                        If ChkSubbatches.Items(j).Value = Dscomb.Tables(0).Rows(i)("SUBBATCHSLNO") Then
                            ChkSubbatches.Items(j).Selected = True
                        End If
                    Next
                Next
            End If

            

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Button Events"

    Private Sub iBtnSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSearch.Click
        Try
            FillCourse()
            FillGroup()
            FillUsersType()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ibtSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtSave.Click
        Try
            If PageValidations1() AndAlso PageValidations2() Then
                objUscls = New UserClass
                RtnStr = objUscls.UserSubbatch_Save(SetEntriesBranch())
                If RtnStr = "SUCCESS" Then
                    ClearControls()
                    StartUpScript("txtUid", "Record Saved Successfully.")
                Else
                    StartUpScript("", RtnStr)
                End If
            End If
        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")


        Catch OmEx As OutOfMemoryException
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")


        Catch ex As Exception

            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")

        End Try
    End Sub

    Private Sub ibtnCancel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnCancel.Click
        Try
            Response.Redirect("UserWiseSubbatchPermissionView.aspx?USERTYPESLNO=" & UserTypeslno.ToString)
        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try
    End Sub

    Private Sub ibtnSBSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnSBSearch.Click
        Try
            If PageValidations1() Then

                FillSubBatch()
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Check Box Events"

    Private Sub ChkCheckbatch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCheckbatch.CheckedChanged
        Dim i As Integer
        If ChkCheckbatch.Checked Then
            For i = 0 To ChkBatches.Items.Count - 1
                ChkBatches.Items(i).Selected = True
            Next
        Else
            For i = 0 To ChkBatches.Items.Count - 1
                ChkBatches.Items(i).Selected = False
            Next
        End If
    End Sub

    Private Sub ChkCheckSubbatch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCheckSubbatch.CheckedChanged
        Dim i As Integer
        If ChkCheckSubbatch.Checked Then
            For i = 0 To ChkSubbatches.Items.Count - 1
                ChkSubbatches.Items(i).Selected = True
            Next
        Else
            For i = 0 To ChkSubbatches.Items.Count - 1
                ChkSubbatches.Items(i).Selected = False
            Next
        End If
    End Sub


#End Region

#Region "DropDownEvent"
    Private Sub drpCourse_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpCourse.SelectedIndexChanged
        Try
            TblBatch.Visible = True
            FillGroup()
            FillBatch()
            FillSubBatch()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub drpGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpGroup.SelectedIndexChanged
        Try
            FillBatch()
            FillSubBatch()
        Catch ex As Exception

        End Try
    End Sub
#End Region
    

   
End Class
