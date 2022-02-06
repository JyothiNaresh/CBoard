'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is Presentation Layer For Client Mac Address
'   ACTIVITY                          : Getting Client System's Mac Address
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 16-APR-2008
'   FINAL BASELINE DATE               : 16-APR-2008
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Imports System.Data.OracleClient
Public Class MacRegister
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents TxtMacadd1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtMacadd2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtMacadd3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents BtnRegistr As System.Web.UI.WebControls.Button
    Protected WithEvents LblDisUserId As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region


#Region " Class Varialbles "

    Private Formname As String = "Form1"
    Private Utl As Utility
    Private ClsUs As UserClass

#End Region

#Region " Methods"

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

    Private Function GettingUserMacAdd() As Boolean
        Try

            'Dim StrSql As String
            'Dim DS As DataSet

            'StrSql = " SELECT  MACUSERSLNO,	USERSLNO,MACADD,ADMOREXAM FROM  MAC_USERMAC_MT " & _
            '          " WHERE ADMOREXAM='E' AND USERSLNO=" & Session("USERSLNO")

            'Utl = New Utility
            'DS = Utl.DataSet_OneFetch(StrSql)

            'If DS.Tables(0).Rows.Count > 0 Then
            '    StartUpScript(Me.ID, " Already Register ")
            '    Return False
            'Else
            '    Return True
            'End If


            If Val(Session("ISMACCHECK")) = 1 Then
                StartUpScript(Me.ID, " Already Register ")
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function SetEnteries() As DataSet
        Try
            Dim dsMac As New DataSet
            Dim dt As New DataTable
            Dim dRow As DataRow


            dt.Columns.Add("USERSLNO", GetType(System.Int16))
            dt.Columns.Add("MACADD", GetType(System.String))
            dt.Columns.Add("ADMOREXAM", GetType(System.String))

            dsMac.Tables.Add(dt)

            If (Not Trim(TxtMacadd1.Text) Is Nothing) AndAlso Trim(TxtMacadd1.Text) <> "" Then
                dRow = dsMac.Tables(0).NewRow
                dRow("USERSLNO") = Val(Session("USERSLNO"))
                dRow("MACADD") = Trim(TxtMacadd1.Text)
                dRow("ADMOREXAM") = "E"
                dsMac.Tables(0).Rows.Add(dRow)
            End If


            If (Not Trim(TxtMacadd2.Text) Is Nothing) AndAlso Trim(TxtMacadd2.Text) <> "" Then
                dRow = dsMac.Tables(0).NewRow
                dRow("USERSLNO") = Val(Session("USERSLNO"))
                dRow("MACADD") = Trim(TxtMacadd2.Text)
                dRow("ADMOREXAM") = "E"
                dsMac.Tables(0).Rows.Add(dRow)
            End If

            If (Not Trim(TxtMacadd3.Text) Is Nothing) AndAlso Trim(TxtMacadd3.Text) <> "" Then
                dRow = dsMac.Tables(0).NewRow
                dRow("USERSLNO") = Val(Session("USERSLNO"))
                dRow("MACADD") = Trim(TxtMacadd3.Text)
                dRow("ADMOREXAM") = "E"
                dsMac.Tables(0).Rows.Add(dRow)
            End If


            Return dsMac

        Catch ex As Exception

        End Try

    End Function

#End Region

#Region " Events "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Session("USERSLNO") = 161
            'Session("USERID") = "ASREDDY"

            If Session("USERSLNO") Is Nothing Then Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                LblDisUserId.Text = Session("USERID")
                Session("ISMACCHECK") = 0
            End If

        Catch Oex As OracleException
            StartUpScript("", DataBaseErrorMessage(Oex.Message))
        Catch ex As Exception
            If GeneralErrorMessage(ex.Message) <> "" Then
                StartUpScript("", GeneralErrorMessage(ex.Message))
            End If
        End Try



    End Sub

    Private Sub BtnRegistr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegistr.Click
        Try

            If GettingUserMacAdd() Then
                ClsUs = New UserClass
                Dim RtnStr As String

                RtnStr = ClsUs.ClientMac_Save(SetEnteries())
                If Val(RtnStr) = 1 Then
                    Session("ISMACCHECK") = 1
                    StartUpScript(Me.ID, " You Are Registered ")
                End If

            End If
        Catch ORAEX As OracleException
            UpdateOraLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                         "Source := " & ORAEX.Source & vbCrLf & "StackTrace:= " & ORAEX.StackTrace & vbCrLf & "Message:=" & ORAEX.Message)
            StartUpScript(Me.ID, " Transaction  Failed ")

        Catch ex As Exception
            UpdateLogFile(IIf(Session("USERID") Is Nothing, " ", " USERID := " & Session("USERID").ToString) & vbCrLf & "DATE TIME := " & Today & TimeString & vbCrLf & _
                                    "Source := " & ex.Source & vbCrLf & "StackTrace:= " & ex.StackTrace & vbCrLf & "Message:=" & ex.Message)
            StartUpScript(Me.ID, " Transaction  Failed ")

        End Try
    End Sub

#End Region
    
End Class
