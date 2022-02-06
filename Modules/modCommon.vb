Imports System.IO
Imports System.Data.OleDb
Imports System.Collections
Imports CollegeBoardDLL
Module modCommon

#Region "Module Level variables"
    Public PubMsg As String = "Sorry!You don't have access permission to this page."
    Public CompanyName As String = "NIMS"
#End Region

#Region "Class varibles"


    Private DSUser As DataSet
    Private objUser As New UserClass
    Private _ch As Char() = {"/", ".", "-"}
#End Region

#Region "Common Methos"

    Public Function isNIMSDate(ByVal txtDate As String, Optional ByVal isMust As Boolean = False) As Boolean
        Try


            Dim str() As String

            If txtDate.ToString = "" And isMust Then
                Return False
            ElseIf txtDate.ToString = "" And Not isMust Then
                Return True
            End If

            str = txtDate.Split(_ch)

            If str.Length <> 3 Then
                Return False
            End If

            If Val(str(0)) < 0 Or Val(str(0) > 31) Then
                Return False
            End If

            If Val(str(1)) < 0 Or Val(str(1) > 12) Then
                Return False
            End If

            If Val(str(2)) < 1900 Or Val(str(2) > 3000) Then
                Return False
            End If
            'Date.Parse(txtDate.text)
            Try
                Dim dt As Date

                Dim strFormat() As String = {"M/dd/yyyy", "dd/M/yyyy", "d/MM/yyyy", "d-MM-yyyy", "dd-M-yyyy", "d-M-yyyy", "d/M/yyyy", "d.M.yyyy", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy", "dd-MM/yyyy", "dd.MM/yyyy", "dd/MM.yyyy", "dd/MM-yyyy", "dd.MM-yyyy", "dd-MM.yyyy"}
                dt = Date.ParseExact(txtDate, strFormat, Nothing, Nothing)
                Return True

            Catch ex As FormatException
                Return False
            Catch ex As Exception
                Return False
            End Try
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    'Public Function DateConversion(ByVal Txtdate As String)
    '    Dim Dt As Date
    '    Dim str() As String
    '    If Txtdate <> Nothing Then
    '        If InStr(Txtdate, "/") <> 0 Then
    '            If InStr(InStr(Txtdate, "/") + 1, Txtdate, "/") <> 0 Then
    '                str = Txtdate.Split("/")
    '            End If
    '        ElseIf InStr(Txtdate, "-") <> 0 Then
    '            If InStr(InStr(Txtdate, "-") + 1, Txtdate, "-") <> 0 Then
    '                str = Txtdate.Split("-")
    '            End If
    '        End If

    '        Dt = DateSerial(str(2), str(1), str(0))
    '    Else
    '        Dt = "1/1/1900"
    '    End If

    '    Dt = DateSerial(str(2), str(1), str(0))
    '    Return Format(Dt, "dd-MMM-yyyy")

    'End Function

    'Public Function PrintLines(Optional ByVal pChar As Char = " ", Optional ByVal NoOfCols As Integer = 0, Optional ByVal NoOfRows As Integer = 1) As String
    '    Dim iCount As Integer
    '    Dim iRow As Integer
    '    Dim lStr As String = ""
    '    For iRow = 1 To NoOfRows
    '        If NoOfCols = 0 Then
    '            lStr = lStr & vbCrLf
    '        Else
    '            For iCount = 1 To NoOfCols
    '                lStr = lStr & pChar
    '            Next
    '        End If
    '    Next
    '    PrintLines = lStr
    'End Function

    'Public Function StrPadding(ByVal Input As String, ByVal NoOfCols As Integer, ByVal LRM As String) As String
    '    Dim iCount As Integer
    '    Dim lPad As String = ""

    '    lPad = Input
    '    If Len(lPad) >= NoOfCols Then
    '        StrPadding = Left(lPad, NoOfCols)
    '        Exit Function
    '    End If

    '    Try
    '        If LRM = "L" Then
    '            For iCount = 1 To NoOfCols - Len(lPad)

    '                lPad = lPad & " "
    '            Next
    '        ElseIf LRM = "R" Then
    '            For iCount = 1 To NoOfCols - Len(lPad)
    '                lPad = " " & lPad
    '            Next

    '        ElseIf LRM = "M" Then
    '            NoOfCols = NoOfCols - Len(lPad)
    '            Dim MidCol As Integer = CInt(NoOfCols / 2)


    '            For iCount = 1 To NoOfCols - MidCol
    '                lPad = " " & lPad
    '            Next

    '            For iCount = (NoOfCols - MidCol) To NoOfCols - 1
    '                lPad = lPad & " "
    '            Next
    '        End If
    '    Catch ex As Exception

    '    Finally
    '        StrPadding = lPad

    '    End Try

    'End Function

    Public Function IS_NUMERIC_NUMBER(ByVal ADMSNO As String) As Boolean

        Try
            Dim i As Integer
            If ADMSNO <> "" Then
                For i = 0 To ADMSNO.Length - 1
                    If ((Asc(ADMSNO.Substring(i, 1)) < 45 Or Asc(ADMSNO.Substring(i, 1)) > 57) And (Asc(ADMSNO.Substring(i, 1)) <> 8)) And (Asc(ADMSNO.Substring(i, 1)) <> 13) Then
                        Return False
                    End If
                Next
            End If
            Return True

        Catch ex As Exception

        End Try

    End Function
    

#End Region

#Region "User Manager"

    Public Function User_PageAccess_Check(ByVal USERID As String, ByVal FORMID As String) As Boolean
        Try
            'objWSUser = New WSUserManager.UserManager
            'DSUser = objWSUser.USERFORMACCESS_Fetch(USERID, FORMID)
            'If DSUser.Tables(0).Rows.Count = 0 Then
            '    Return True
            'Else
            '    Return False
            'End If
        Catch ex As Exception

        End Try
    End Function

    Public Function User_PageActivity_Check(ByVal USERID As String, ByVal BRANCHID As Integer, ByVal FORMID As String, ByVal ACTIVITYID As Integer) As Boolean
        Try
            'objWSUser = New WSUserManager.UserManager
            'DSUser = objWSUser.USERFORMACTIVITY_Fetch(USERID, BRANCHID, FORMID, ACTIVITYID)
            'If DSUser.Tables(0).Rows.Count = 0 Then
            '    Return True
            'Else
            '    Return False
            'End If
        Catch ex As Exception

        End Try
    End Function

    Public Function User_Type_Check(ByVal USERSLNO As Integer, ByVal COMACADEMICSLNO As Integer, ByVal USERTYPESLNO As Integer) As Boolean
        Try
            DSUser = objUser.User_Types_Fill(USERSLNO, COMACADEMICSLNO, USERTYPESLNO)
            If DSUser.Tables(0).Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception

        End Try
    End Function

#End Region

#Region "Error Log "

    Public Sub UpdateLogFile(ByVal str As String)

        Try

            Dim stream As StreamWriter, fileName As String, appPath As String

            appPath = "d:\LOGFILE\" 'Application.ExecutablePath()
            If appPath.IndexOf("\") > 0 Then
                fileName = Left(appPath, appPath.LastIndexOf("\"))
            Else
                fileName = Left(appPath, appPath.LastIndexOf("/"))
            End If

            'fileName = "F:"

            If Not Directory.Exists(fileName & "\EXAMINATION") Then
                Directory.CreateDirectory(fileName & "\EXAMINATION")
            End If

            stream = File.AppendText(fileName & "\EXAMINATION\ERRORLOG" & Format(Today, "dd-MM-yyyy") & ".TXT")
            stream.WriteLine(str)
            stream.Close()

        Catch ex As Exception
        End Try

    End Sub

    Public Sub UpdateOraLogFile(ByVal str As String)

        Try

            Dim stream As StreamWriter, fileName As String, appPath As String

            appPath = "d:\LOGFILE\" 'Application.ExecutablePath()
            If appPath.IndexOf("\") > 0 Then
                fileName = Left(appPath, appPath.LastIndexOf("\"))
            Else
                fileName = Left(appPath, appPath.LastIndexOf("/"))
            End If

            'fileName = "F:"

            If Not Directory.Exists(fileName & "\EXAMINATION") Then
                Directory.CreateDirectory(fileName & "\EXAMINATION")
            End If

            stream = File.AppendText(fileName & "\EXAMINATION\ORAERRORLOG" & Format(Today, "dd-MM-yyyy") & ".TXT")
            stream.WriteLine(str)
            stream.Close()

        Catch ex As Exception
        End Try

    End Sub
    Public Sub UpdateLogFile(ByVal str As OracleClient.OracleException)

        Try

            Dim stream As StreamWriter, fileName As String, appPath As String

            appPath = "d:\LOGFILE\" 'Application.ExecutablePath()
            If appPath.IndexOf("\") > 0 Then
                fileName = Left(appPath, appPath.LastIndexOf("\"))
            Else
                fileName = Left(appPath, appPath.LastIndexOf("/"))
            End If

            'fileName = "F:"

            If Not Directory.Exists(fileName & "\EXAMINATION") Then
                Directory.CreateDirectory(fileName & "\EXAMINATION")
            End If

            stream = File.AppendText(fileName & "\EXAMINATION\ERRORLOG" & Format(Today, "dd-MM-yyyy") & ".TXT")
            stream.WriteLine(str)
            stream.Close()

        Catch ex As Exception
        End Try

    End Sub

    Public Sub UpdateLogFile(ByVal str As Exception)

        Try

            Dim stream As StreamWriter, fileName As String, appPath As String

            appPath = "d:\LOGFILE\" 'Application.ExecutablePath()
            If appPath.IndexOf("\") > 0 Then
                fileName = Left(appPath, appPath.LastIndexOf("\"))
            Else
                fileName = Left(appPath, appPath.LastIndexOf("/"))
            End If

            'fileName = "F:"

            If Not Directory.Exists(fileName & "\EXAMINATION") Then
                Directory.CreateDirectory(fileName & "\EXAMINATION")
            End If

            stream = File.AppendText(fileName & "\EXAMINATION\ERRORLOG" & Format(Today, "dd-MM-yyyy") & ".TXT")
            stream.WriteLine(str)
            stream.Close()

        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region "Error Log File"

    Public Sub OracleLogFile(ByVal str As String)
        Try
            Dim stream As StreamWriter
            Dim fileName, appPath As String

            appPath = "D:\LOGFILE\"
            If appPath.IndexOf("\") > 0 Then
                fileName = Left(appPath, appPath.LastIndexOf("\"))
            Else
                fileName = Left(appPath, appPath.LastIndexOf("/"))
            End If

            If Not Directory.Exists(fileName & "\ATTENDANCE") Then
                Directory.CreateDirectory(fileName & "\ATTENDANCE")
            End If

            stream = File.AppendText(fileName & "\ATTENDANCE\ORACLELOG " & Format(Today, "dd-MM-yyyy") & ".TXT")
            stream.WriteLine(str)
            stream.Close()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub IISLogFile(ByVal str As String)
        Try
            Dim stream As StreamWriter, fileName As String, appPath As String
            appPath = "D:\LOGFILE\"
            If appPath.IndexOf("\") > 0 Then
                fileName = Left(appPath, appPath.LastIndexOf("\"))
            Else
                fileName = Left(appPath, appPath.LastIndexOf("/"))
            End If

            If Not Directory.Exists(fileName & "\ATTENDANCE") Then
                Directory.CreateDirectory(fileName & "\ATTENDANCE")
            End If

            stream = File.AppendText(fileName & "\ATTENDANCE\IISLOG " & Format(Today, "dd-MM-yyyy") & ".TXT")
            stream.WriteLine(str)
            stream.Close()

        Catch ex As Exception

        End Try
    End Sub

#End Region

End Module
