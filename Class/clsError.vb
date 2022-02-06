Public Class clsError
    Inherits System.Web.UI.Page

    Public Function errHandler(ByVal strErrMessage As String) As String
        Dim strExMessage As String
        Dim strCase As String
        strCase = strErrMessage.Substring(0, 9)

        Select Case strCase

            Case "ORA-00001"
                strExMessage = "Record Already Exists With This Name"
            Case "ORA-06510"
                If InStr(strErrMessage, "M_INSERT_COMFINYR") > 0 Or InStr(strErrMessage, "M_UPDATE_COMFINYR") > 0 Then
                    strExMessage = "Financial Year already defined for this dates"
                End If
            Case "ORA-02292"
                strExMessage = "Child Record Found"
            Case "ORA-06550"
                strExMessage = "Invalid Object (i.e Table,Procedure,Parameters)"
            Case "ORA-00903"
                strExMessage = "Invalid Table Name"
            Case "ORA-00904"
                strExMessage = "Invalid Identifier"
            Case "ORA-00933"
                strExMessage = "SQL Command Not Properly Ended"
            Case "ORA-12154"
                strExMessage = "TNS could not resolve service name"
            Case Else
                strExMessage = "New Error Add In Error Class"
        End Select

        Return strExMessage

    End Function

    Public Function errHandler(ByVal ex As Exception) As String
        Dim strExMessage As String
        Dim strCase As String

        If ex.Message.Substring(0, 18) = "Access to the path" Then  ''''By Naidu On 18/10/2005.For report purpose to give the permissions to All people
            strExMessage = "Please Give the Folder Level Permissions"
            Return strExMessage
        End If

        strCase = ex.Message.Substring(0, 9)

        'Dim X = ex.GetBaseException
        'Dim Y = ex.StackTrace
        'Dim Z = ex.InnerException
        'Dim A = ex.Message.IndexOfAny(":", 2)
        Select Case strCase
            Case "d"
                strExMessage = ""
            Case "ORA-00001"
                strExMessage = "Record Already Existed"
            Case "d"
            Case "d"
            Case "d"
            Case "d"
            Case "d"
            Case "d"
            Case "d"
            Case "d"
            Case "d"
            Case "d"
            Case "d"
            Case "d"
            Case "d"
            Case "Thread was being aborted."
                strExMessage = ""

            Case Else
                strExMessage = "Error"

        End Select

        Return strExMessage

    End Function

    Public Sub Session_Nothing()
        Session("E_EBSTUDENTDS") = Nothing          '''ExamBranchWise Student
        Session("E_EBSTUDENTBATCHDS") = Nothing     '''ExamBranchStudent BatchMode
        Session("E_EBSTUDENTSINGLE") = Nothing      '''ExamBranchStudentSingmode
        Session("STUDENTSEARCHDS") = Nothing        '''Admission Search 
        Session("E_STUDENTSECTIONDS") = Nothing     '''Student SectionDetails
        Session("E_EBSTUDENTSECTIONBDS") = Nothing  '''StudentSectionBatchMode
        Session("E_STUSECTIONSINGLE") = Nothing     '''StudentSectionSinglemode
        Session("E_STUDENTSUBSECTIONS") = Nothing   '''student sub section details mode 
    End Sub

End Class
