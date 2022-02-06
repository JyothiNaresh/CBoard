'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : Master Single
'   AUTHOR                            : 
'   INITIAL BASELINE DATE             : 
'   MODIFICATIONS LOG                 : Adding  Sub Caste by Kishore [09.Apr.2013]
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL

Public Class MasterSingle
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtlblCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents LblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents LblTopic As System.Web.UI.WebControls.Label
    Protected WithEvents LblDescription As System.Web.UI.WebControls.Label
    Protected WithEvents TxtDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents iBtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnDelete As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnCancel As System.Web.UI.WebControls.ImageButton
    Protected WithEvents cmdDelete As System.Web.UI.WebControls.Button
    Protected WithEvents cmdCancel As System.Web.UI.WebControls.Button
    Protected WithEvents cmdSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtDeleteStatus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSetfocus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMessage As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Ibtn As System.Web.UI.WebControls.Label
    Protected WithEvents TxtCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents DrpCaste As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Table4 As System.Web.UI.HtmlControls.HtmlTable

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

    Private objBoardEnrollment As ClsBoardEnrollment
    Private PageIndex, RtnVal As Integer
    Private MODE, HEAD As String
    Private StrSql As String
    Public SLNO, BENO As Integer
    Private ObjResult As Utility
    Dim DS As New DataSet

#End Region

#Region "Methods"

    Private Function SetEntries() As ArrayList
        Try
            Dim Arr As New ArrayList
            
            If MODE = "NEW" Then
                Arr.Add(Trim(TxtName.Text))
                Arr.Add(Trim(TxtDescription.Text))
                Arr.Add(Val(BENO))
                Arr.Add(Trim(TxtCode.Text))
                If DrpCaste.SelectedValue > 0 Then
                    Arr.Add(Val(DrpCaste.SelectedValue))
                Else
                    Arr.Add(Val(0))
                End If

            ElseIf MODE = "EDIT" Then
                Arr.Add(Val(Trim(SLNO)))
                Arr.Add(Trim(TxtName.Text))
                Arr.Add(Trim(TxtDescription.Text))
                Arr.Add(Val(BENO))
                Arr.Add(Trim(TxtCode.Text))
                If DrpCaste.SelectedValue > 0 Then
                    Arr.Add(Val(DrpCaste.SelectedValue))
                Else
                    Arr.Add(Val(0))
                End If

            End If



            Return Arr

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub FillControls()
        Try

            Dim DsGA As DataSet
            objBoardEnrollment = New ClsBoardEnrollment
            DsGA = objBoardEnrollment.Masters_Selectone(SLNO, BENO)

            If DsGA.Tables(0).Rows.Count > 0 Then
                TxtCode.Text = DsGA.Tables(0).Rows(0)("CODE").ToString
                TxtName.Text = DsGA.Tables(0).Rows(0)("NAME").ToString
                TxtDescription.Text = DsGA.Tables(0).Rows(0)("DESCRIPTION").ToString
                If BENO = 14 Then DrpCaste.SelectedValue = DsGA.Tables(0).Rows(0)("CASTECODE").ToString

            Else
            ClearFields()
            End If

        Catch Oex As Exception
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ClearFields()
        Txtcode.Text = ""
        TxtName.Text = ""
        TxtDescription.Text = ""

    End Sub


    Private Function FormValidations() As Boolean
        Try
            If Trim(TxtName.Text) = "" Or Trim(TxtName.Text) Is Nothing Or Trim(Txtcode.Text) Is Nothing Then
                StartUpScript("TxtGaName", "Enter Name")
                Return False
            End If
            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function

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

    Private Sub SetViewStateVariables()
        Try
            If Not Request.QueryString("MODE") Is Nothing Then MODE = Request.QueryString("MODE")
            If Not Request.QueryString("SLNO") Is Nothing Then SLNO = Request.QueryString("SLNO")
            If Not Request.QueryString("BENO") Is Nothing Then BENO = Request.QueryString("BENO")
            If Not Request.QueryString("HEAD") Is Nothing Then HEAD = Request.QueryString("HEAD")
            If Not Request.QueryString("PageIndex") Is Nothing Then PageIndex = Request.QueryString("PageIndex")

            Me.ViewState("MODE") = MODE
            Me.ViewState("SLNO") = SLNO
            Me.ViewState("GANO") = BENO
            Me.ViewState("PageIndex") = PageIndex
            LblHeading.Text = "Board&nbsp;" + HEAD + "&nbsp;(Single&nbsp;Mode)"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetViewStateVariables()
        Try
            MODE = Me.ViewState("MODE")
            SLNO = Me.ViewState("SLNO")
            BENO = Me.ViewState("GANO")
            HEAD = Me.ViewState("HEAD")
            PageIndex = Me.ViewState("PageIndex")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub




#End Region

#Region "Fill Methods"

    Private Sub FillCaste()
        Try
            StrSql = "SELECT BOARDCASTESLNO SLNO, NAME ,CODE  FROM EXAM_BOARDCASTE_MT ORDER BY NAME"

            ObjResult = New Utility
            DS = ObjResult.GetCommDataSet(StrSql)

            DrpCaste.DataSource = DS.Tables(0)
            DrpCaste.DataTextField = "NAME"
            DrpCaste.DataValueField = "SLNO"
            DrpCaste.DataBind()
            DrpCaste.Items.Insert(0, New ListItem("Select", 0))

        Catch ex As Exception
            StartUpScript("", ex.Message)
        End Try
    End Sub
#End Region

#Region "Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        iBtnDelete.Attributes.Add("OnClick", "return Delete()")
        Try
            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                ButtonsHiding(Me.Page)
                SetViewStateVariables()
                Table4.Visible = False
                FillCaste()
                If BENO = Val(14) Then
                    Table4.Visible = True
                    FillCaste()
                End If
                If MODE = "EDIT" Then
                    FillControls()
                End If

                StartUpScript(TxtCode.ID, "")
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

#Region "Image Buttons"

    Private Sub iBtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnSave.Click
        Try
            If Not FormValidations() Then Exit Sub
            objBoardEnrollment = New ClsBoardEnrollment
           
                If MODE = "EDIT" Then
                    RtnVal = objBoardEnrollment.Masters_Update(SetEntries())
                    If RtnVal = 1 Then
                        Me.ViewState("MODE") = "NEW"
                        StartUpScript(iBtnSave.ID, "Record Updated Successfully.")
                        ClearFields()
                        Response.Redirect("MastersHome.aspx?PageIndex=" & PageIndex & "&BENO=" & BENO)
                    Else
                        StartUpScript(iBtnSave.ID, "Record Not Updated.")
                    End If
                ElseIf MODE = "NEW" Then
                RtnVal = objBoardEnrollment.Masters_Insert(SetEntries())
                    If RtnVal = 1 Then
                        StartUpScript(iBtnSave.ID, "Record Saved Successfully.")
                        ClearFields()
                    Else
                        StartUpScript(iBtnSave.ID, "Record Not Saved.")
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

    Private Sub iBtnDelete_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnDelete.Click
        Try

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

    Private Sub iBtnCancel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnCancel.Click
        Try
            Response.Redirect("MastersHome.aspx?PageIndex=" & PageIndex & "&BENO=" & BENO)
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

End Class
