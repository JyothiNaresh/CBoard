'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Students Board Details Entry Screen
'   AUTHOR                            : K.SHANKAR SUDERSHAN RAO
'   INITIAL BASELINE DATE             : 22-07-2009
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Public Class BoardDetailsEntry
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents LblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents drpExamBranch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblCourse As System.Web.UI.WebControls.Label
    Protected WithEvents drpCourse As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents drpGroup As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblBatch As System.Web.UI.WebControls.Label
    Protected WithEvents drpBatch As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents drpSection As System.Web.UI.WebControls.DropDownList
    Protected WithEvents iBtnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnCancle As System.Web.UI.WebControls.ImageButton
    Protected WithEvents cmdCancel As System.Web.UI.WebControls.Button
    Protected WithEvents DGStuBoardMap As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DrpDummayStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpDummyGender As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtAdmNo As System.Web.UI.WebControls.TextBox

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

    Private objWSCombo As ClsComboBoxFilling

    Private objStuSec As ClsStudentSection    ''''''For Getting Section Based On Selection Criterias


    Private From, FromWhere As String
    Private objError As clsError
    Dim PageIndex As String
    Dim objPD As ClsStuBoardMap
    Private objWS As ClsBCEGBS
    Dim DS As DataSet

    Dim DsStudents As New DataSet
    Dim Setslno As Integer
    Dim DExamSlno As Integer
    Private strSQL As String
    Dim ChkChecked As String
    Dim cELLNo As Integer
    Dim UserSLNo As Integer
    Dim DSet As DataSet
    Dim DSetGender As DataSet
    ''''ViewState Variables
    Dim ADMBRANCHSLNO, COURSESLNO, GROUPSLNO, BATCHSLNO, SECTIONSLNO, MEDIUMSLNO, STUTYPESLNO, EXAMBRANCHSLNO As Integer

#End Region

#Region "Fill Methods"



    Private Sub FillCourse()
        Try
            Dim dsCourse As DataSet

            objWSCombo = New ClsComboBoxFilling
            dsCourse = objWSCombo.EXAMBranchWiseCourse_Fetch(drpExamBranch.SelectedValue)
            drpCourse.DataSource = dsCourse.Tables(0)
            drpCourse.DataTextField = "NAME"
            drpCourse.DataValueField = "SLNO"
            drpCourse.DataBind()
            'drpCourse.Items.Insert(0, New ListItem("ALL", 0))

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

    Private Sub FillExambranch()
        Try

            Dim dsExamBranch As DataSet
            objWSCombo = New ClsComboBoxFilling
            dsExamBranch = objWSCombo.USERWISEEB(UserSLNo, Session("COMACADEMICSLNO"))
            drpExamBranch.DataSource = dsExamBranch.Tables(0)
            drpExamBranch.DataTextField = "EXAMBRANCHNAME"
            drpExamBranch.DataValueField = "EXAMBRANCHSLNO"
            drpExamBranch.DataBind()

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

    Private Sub FillGroup()
        Try
            Dim dsGroup As DataSet
            objWS = New ClsBCEGBS
            dsGroup = objWS.Group_Fill(drpCourse.SelectedValue)
            drpGroup.DataSource = dsGroup.Tables(0)
            drpGroup.DataTextField = "GROUPNAME"
            drpGroup.DataValueField = "GROUPSLNO"
            drpGroup.DataBind()
            If GROUPSLNO <> 0 Then drpGroup.SelectedValue = GROUPSLNO

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

    Private Sub FillBatch()
        Try
            Dim dsBatch As DataSet
            objWS = New ClsBCEGBS
            dsBatch = objWS.Batch_Fill(drpCourse.SelectedValue, drpGroup.SelectedValue)
            drpBatch.DataSource = dsBatch.Tables(0)
            drpBatch.DataTextField = "BATCHNAME"
            drpBatch.DataValueField = "BATCHSLNO"
            drpBatch.DataBind()
            If BATCHSLNO <> 0 Then drpBatch.SelectedValue = BATCHSLNO
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

    Private Sub FillSection()
        Try
            Dim dsSection As DataSet
            objStuSec = New ClsStudentSection
            dsSection = objStuSec.AssignedSection_Fill(drpExamBranch.SelectedValue, drpCourse.SelectedValue, drpGroup.SelectedValue, drpBatch.SelectedValue)
            drpSection.DataSource = dsSection.Tables(0)
            drpSection.DataTextField = "NAME"
            drpSection.DataValueField = "SLNO"
            drpSection.DataBind()

            If SECTIONSLNO <> 0 Then drpSection.SelectedValue = SECTIONSLNO

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

    Private Sub FillCaste()
        Try
            strSQL = "SELECT CASTESLNO,CASTENAME FROM T_CASTE_MT ORDER BY CASTENAME"

            objWSCombo = New ClsComboBoxFilling
            DSet = objWSCombo.Parse_Fetch(strSQL)
            Me.ViewState("DSet") = DSet


            Dim Dr As DataRow
            Dr = DSet.Tables(0).NewRow
            Dr("CASTESLNO") = Val(0)
            Dr("CASTENAME") = "--Select--"
            DSet.Tables(0).Rows.InsertAt(Dr, 0)

            Me.Session("DSet") = DSet

            DrpDummayStatus.DataSource = DSet
            DrpDummayStatus.DataTextField = "CASTENAME"
            DrpDummayStatus.DataValueField = "CASTESLNO"
            DrpDummayStatus.DataBind()



        Catch ORAEX As OracleException
            UpdateOraLogFile(" USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")

            Throw ORAEX

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(" USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")

            Throw OmEx


        Catch ex As Exception

            UpdateLogFile(" USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")

            Throw ex
        End Try
    End Sub

    Public Function FileCasteDataset() As DataSet
        Try
            Return DSet
        Catch OrlEx As OracleException
            Throw OrlEx
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CasteGetGridCombIndex(ByVal strSLNo As String) As Integer
        Try
            If strSLNo <> "" Then
                Return DrpDummayStatus.Items.IndexOf(DrpDummayStatus.Items.FindByValue(strSLNo))
            Else
                Return 0
            End If
        Catch OrlEx As OracleException
            Throw OrlEx
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub FillGender()
        Try
            ''strSQL = "SELECT CASTESLNO,CASTENAME FROM T_CASTE_MT ORDER BY CASTENAME"

            ''objWSCombo = New ClsComboBoxFilling
            ''DSet = objWSCombo.Parse_Fetch(strSQL)

            Dim Dt As DataTable
            DSetGender = New DataSet
            DSetGender.Tables.Add(New DataTable("Gender"))
            Dt = DSetGender.Tables("Gender")

            Dt.Columns.Add("SEX")
            Dt.Columns.Add("GENDER")

            Me.Session("DSetGender") = DSetGender

            Dim Dr As DataRow
            Dr = DSetGender.Tables(0).NewRow
            Dr("SEX") = "M"
            Dr("GENDER") = "Male"
            DSetGender.Tables(0).Rows.InsertAt(Dr, 0)

            ''Me.Session("DSetGender") = DSetGender

            Dr = DSetGender.Tables(0).NewRow
            Dr("SEX") = "F"
            Dr("GENDER") = "Female"
            DSetGender.Tables(0).Rows.InsertAt(Dr, 1)

            Me.Session("DSetGender") = DSetGender

            DrpDummyGender.DataSource = DSetGender
            DrpDummyGender.DataTextField = "GENDER"
            DrpDummyGender.DataValueField = "SEX"
            DrpDummyGender.DataBind()



        Catch ORAEX As OracleException
            UpdateOraLogFile(" USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")

            Throw ORAEX

        Catch OmEx As OutOfMemoryException
            UpdateLogFile(" USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & OmEx.Source & vbCrLf & "StackTrace:= " & OmEx.StackTrace & vbCrLf & "Message:=" & OmEx.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")

            Throw OmEx


        Catch ex As Exception

            UpdateLogFile(" USERID := " & Session("USERID").ToString & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)

            StartUpScript(Me.ID, " Transaction  Failed ")

            Throw ex
        End Try
        

    End Sub

    Public Function FileGenderDataset() As DataSet
        Try
            Return DSetGender
        Catch OrlEx As OracleException
            Throw OrlEx
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GenderGetGridCombIndex(ByVal strSLNo As String) As Integer
        Try
            If strSLNo <> "" Then
                Return DrpDummyGender.Items.IndexOf(DrpDummyGender.Items.FindByValue(strSLNo))
            Else
                Return 0
            End If
        Catch OrlEx As OracleException
            Throw OrlEx
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Private Sub Fillcombos()
        Try
            FillExambranch()
            FillCourse()
            FillGroup()
            FillBatch()
            FillSection()
            FillCaste()
            FillGender()

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

#End Region

#Region "Methods"

    Private Sub PrepareTableForstudent()
        Try
            Dim Dt As DataTable
            DsStudents.Tables.Add(New DataTable("Students"))
            Dt = DsStudents.Tables("Students")

            Dt.Columns.Add("ADMSLNO")
            Dt.Columns.Add("ADMNO")
            Dt.Columns.Add("STUNAME")
            Dt.Columns.Add("FATHERNAME")
            Dt.Columns.Add("BOARDIDNO")
            Dt.Columns.Add("BOARDCOLLCODE")
            Dt.Columns.Add("DOB")
            Dt.Columns.Add("CASTESLNO")
            Dt.Columns.Add("GENDER")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetStudentSectionsWise()
        Try
            Dim i As Integer
            Dim dr, dr1 As DataRow
            Dim DropDown As DropDownList

            If ValidateGo() = True Then

                DGStuBoardMap.Visible = True
                objPD = New ClsStuBoardMap
                DsStudents = Me.Session("DsStudents")
                If DsStudents.Tables("Students").Rows.Count > 0 Then DsStudents.Tables("Students").Rows.Clear()
                DsStudents = objPD.StudentBoardMapSelect("EXAM_STUBOARDMAP", DsStudents, "Students", drpExamBranch.SelectedValue, drpCourse.SelectedValue, drpGroup.SelectedValue, drpBatch.SelectedValue, drpSection.SelectedValue, Trim(txtAdmNo.Text), Session("COMACADEMICSLNO"))

                Me.Session("DsStudents") = DsStudents
                DSet = Me.ViewState("DSet")

                DGStuBoardMap.DataSource = DsStudents.Tables("Students")
                DGStuBoardMap.DataBind()

                ''For i = 0 To DsStudents.Tables(0).Rows.Count - 1

                ''    If IsNothing(DSet) Then
                ''        dr1 = DSet.Tables(0).NewRow
                ''        dr1("CASTENAME") = ""
                ''        dr1("CASTESLNO") = -1
                ''        DSet.Tables(0).Rows.InsertAt(dr1, 0)
                ''        Me.ViewState("DSet") = DSet
                ''    Else
                ''        DropDown = CType(DGStuBoardMap.Items(i).Cells(7).FindControl("DrpCaste"), DropDownList)
                ''        DropDown.DataSource = DSet
                ''        DropDown.DataTextField = "CASTENAME"
                ''        DropDown.DataValueField = "CASTESLNO"
                ''        DropDown.DataBind()
                ''    End If

                ''Next
            Else
                DGStuBoardMap.Visible = False
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

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")

        Try
            If focusCtrl <> "" And strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.frmStuBoard." & focusCtrl & " == '[object]') { document.frmStuBoard." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf focusCtrl <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document.frmStuBoard." & focusCtrl & " == '[object]') { document.frmStuBoard." & focusCtrl & ".focus(); } </script>")
            Else

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function ValidateGo() As Boolean
        Try
            If drpExamBranch.SelectedValue Is Nothing OrElse drpExamBranch.SelectedValue = "" Then
                StartUpScript(drpExamBranch.ID, "Select Exam Branch")
                Return False
            ElseIf drpExamBranch.SelectedValue Is Nothing OrElse drpExamBranch.SelectedValue = "" Then
                StartUpScript(drpExamBranch.ID, "Select Exam Branch")
                Return False
            ElseIf drpCourse.SelectedValue Is Nothing OrElse drpCourse.SelectedValue = "" Then
                StartUpScript(drpCourse.ID, "Select Course")
                Return False
            ElseIf drpGroup.SelectedValue Is Nothing OrElse drpGroup.SelectedValue = "" Then
                StartUpScript(drpGroup.ID, "Select Group")
                Return False
            ElseIf drpBatch.SelectedValue Is Nothing OrElse drpBatch.SelectedValue = "" Then
                StartUpScript(drpBatch.ID, "Select Batch")
                Return False
            ElseIf drpSection.SelectedValue Is Nothing OrElse drpSection.SelectedValue = "" Then
                StartUpScript(drpSection.ID, "Select Section")
                Return False
            End If
            Return True
        Catch ex As Exception

        End Try
    End Function



    Private Function ValidateData(ByVal txtMobile1 As TextBox, ByVal txtMobile2 As TextBox) As Boolean


    End Function


    Private Function SetEntires() As Boolean
        Try

            Dim i As Integer

            DsStudents = Me.Session("DsStudents")

            For i = 0 To DsStudents.Tables("Students").Rows.Count - 1
                Dim txtBoardIdCtrl As TextBox
                Dim txtBoardCollCode As TextBox
                Dim drpCaste As DropDownList
                Dim txtDOB As TextBox
                Dim drpGender As DropDownList

                txtBoardIdCtrl = DGStuBoardMap.Items(i).Cells(5).Controls(1)
                txtBoardCollCode = DGStuBoardMap.Items(i).Cells(6).Controls(1)
                drpCaste = DGStuBoardMap.Items(i).Cells(7).Controls(1)
                txtDOB = DGStuBoardMap.Items(i).Cells(8).Controls(1)
                drpGender = DGStuBoardMap.Items(i).Cells(9).Controls(1)

                ''board id
                If Trim(txtBoardIdCtrl.Text) <> "" Then
                    If Not IsNumeric(Trim(txtBoardIdCtrl.Text)) Then
                        StartUpScript("DGStuBoardMap__ctl" & i + 2 & "_txtBoardId", "Enter Board Id Numbers only.")
                        Return False
                    End If
                    DsStudents.Tables("Students").Rows(i)("BOARDIDNO") = CDec(Trim(txtBoardIdCtrl.Text))
                Else
                    DsStudents.Tables("Students").Rows(i)("BOARDIDNO") = DBNull.Value
                End If

                ''board college id

                If Trim(txtBoardCollCode.Text) <> "" Then
                    If Not IsNumeric(Trim(txtBoardCollCode.Text)) Then
                        StartUpScript("DGStuBoardMap__ctl" & i + 2 & "_txtBoardCollCode", "Enter Board College Code Numbers only.")
                        Return False
                    End If
                    DsStudents.Tables("Students").Rows(i)("BOARDCOLLCODE") = CDec(Trim(txtBoardCollCode.Text))
                Else
                    DsStudents.Tables("Students").Rows(i)("BOARDCOLLCODE") = DBNull.Value
                End If

                ''Caste

                If Trim(drpCaste.SelectedIndex) <> -1 Then
                    DsStudents.Tables("Students").Rows(i)("CASTESLNO") = Val(drpCaste.SelectedValue)
                Else
                    DsStudents.Tables("Students").Rows(i)("CASTESLNO") = DBNull.Value
                End If

                ''date of birth

                If Trim(txtDOB.Text) <> "" Then
                    If Not IsDate(Trim(txtDOB.Text), True) Then
                        StartUpScript("DGStuBoardMap__ctl" & i + 2 & "_txtDOB", "Enter  Date of Birth In Correct Format. Ex:(DD/MM/YYYY).")
                        Return False
                    End If
                    DsStudents.Tables("Students").Rows(i)("DOB") = DateConversion(Trim(txtDOB.Text))
                Else
                    DsStudents.Tables("Students").Rows(i)("DOB") = DBNull.Value
                End If

                ''Sex

                If Trim(drpGender.SelectedIndex) <> -1 Then
                    DsStudents.Tables("Students").Rows(i)("GENDER") = drpGender.SelectedValue.ToUpper
                Else
                    DsStudents.Tables("Students").Rows(i)("GENDER") = DBNull.Value
                End If


            Next

            Me.Session("DsStudents") = DsStudents

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Events"

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Session("USERID") Is Nothing OrElse Session("USERSLNO") Is Nothing Then
            Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
            Exit Sub
        Else
            UserSLNo = Session("USERSLNO")
        End If

        If Not IsPostBack Then
            FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
            'If User_PageAccess_Check(Session("USERID"), "108") Then
            '    Response.Redirect("../../RedirectPage.aspx?Msg=" & PubMsg)
            '    Exit Sub
            'End If

            From = Request.QueryString("From")

            FromWhere = Request.QueryString("FromWhere")
            Me.ViewState("FromWhere") = FromWhere

            If Not Request.QueryString("PageIndex") Is Nothing AndAlso Request.QueryString("PageIndex") <> "" Then
                PageIndex = CInt(Request.QueryString("PageIndex"))
            Else
                PageIndex = 0
            End If

            Me.ViewState("PageIndex") = PageIndex
            Me.ViewState("From") = From


            '''If Not Request.QueryString("ADMBRANCHSLNO") Is Nothing AndAlso Request.QueryString("ADMBRANCHSLNO") <> "" Then ADMBRANCHSLNO = CInt(Request.QueryString("ADMBRANCHSLNO"))
            '''If Not Request.QueryString("COURSESLNO") Is Nothing AndAlso Request.QueryString("COURSESLNO") <> "" Then COURSESLNO = CInt(Request.QueryString("COURSESLNO"))
            '''If Not Request.QueryString("EXAMBRANCHSLNO") Is Nothing AndAlso Request.QueryString("EXAMBRANCHSLNO") <> "" Then EXAMBRANCHSLNO = CInt(Request.QueryString("EXAMBRANCHSLNO"))
            '''If Not Request.QueryString("GROUPSLNO") Is Nothing AndAlso Request.QueryString("GROUPSLNO") <> "" Then GROUPSLNO = CInt(Request.QueryString("GROUPSLNO"))
            '''If Not Request.QueryString("BATCHSLNO") Is Nothing AndAlso Request.QueryString("BATCHSLNO") <> "" Then BATCHSLNO = CInt(Request.QueryString("BATCHSLNO"))
            '''If Not Request.QueryString("SECTIONSLNO") Is Nothing AndAlso Request.QueryString("SECTIONSLNO") <> "" Then SECTIONSLNO = CInt(Request.QueryString("SECTIONSLNO"))

            PrepareTableForstudent()

            Me.Session("DsStudents") = DsStudents

            Fillcombos()

            Me.ViewState("strSQL") = strSQL

            If ValidateGo() Then
                GetStudentSectionsWise()
            End If

        Else

            PageIndex = Me.ViewState("PageIndex")
            From = Me.ViewState("From")
            DsStudents = Me.Session("DsStudents")
            ''DSet = Me.Session("DSet")
            DSetGender = Me.Session("DSetGender")
            FromWhere = Me.ViewState("FromWhere")
        End If

    End Sub

#End Region


#Region "DropDown Events"


    Private Sub drpCourse_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpCourse.SelectedIndexChanged
        Try
            FillGroup()
            FillBatch()
            FillSection()
            GetStudentSectionsWise()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub drpExamBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpExamBranch.SelectedIndexChanged
        Try
            FillCourse()
            GetStudentSectionsWise()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub drpGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpGroup.SelectedIndexChanged
        Try
            FillBatch()
            FillSection()
            GetStudentSectionsWise()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub drpBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpBatch.SelectedIndexChanged
        FillSection()
        GetStudentSectionsWise()
    End Sub
    Private Sub drpSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpSection.SelectedIndexChanged
        GetStudentSectionsWise()
    End Sub
#End Region

#Region "ImgBtnEvents"

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Dim Result As String
        Try
            If Not SetEntires() Then Exit Sub

            DsStudents = Me.Session("DsStudents")
            If DsStudents.Tables("Students").Rows.Count > 0 Then
                objPD = New ClsStuBoardMap
                Result = objPD.StuBoardMap_Save(DsStudents)
                If Result = "Saved" Then
                    StartUpScript(iBtnGo.ID, "Data Saved Successfully")
                    DsStudents.Tables("Students").Rows.Clear()
                    GetStudentSectionsWise()
                End If
            Else
                StartUpScript(Me.ID, "No Record For Save")
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

    Private Sub iBtnCancle_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnCancle.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub iBtnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnGo.Click
        Try
            If ValidateGo() Then
                GetStudentSectionsWise()
                txtAdmNo.Text = ""
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

#End Region

    
End Class
