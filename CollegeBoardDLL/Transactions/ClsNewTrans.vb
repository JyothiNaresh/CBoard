'-------------------------------------------------------------
' Author                :   Venu.P  
' Description           :   For Sms-ExcelFile Uploading
' StartDate             :   03-Sep-2011
' InitialBaselineDate   :   04-Sep-2011
' Modification Log      :   Dept adding [13-Dec-2011]- Venu.P
'-------------------------------------------------------------
Public Class ClsNewTrans

#Region " * Class Variables"

    Private oConn As OracleConnection 'Connection Object Declaration.
    Private oComm As OracleCommand 'Command Object Declaration.
    Private oTrans As OracleTransaction 'Transaction Object Declaration.
    Private oAdap As OracleDataAdapter 'Adapter Object Declaration.
    Private oParam As OracleParameter 'Parameter Object Declaration.
    Private Ds As DataSet
    Private ConObj As Connection
    Private rtnMessage As String 'Result of the return type.
    Private rtnVal As Integer 'Result of the return type.
    Dim UMText As String
    Private Objfetch As Utility
    Private OraStr, OraStr_1, OraStr_2, OraStr_3, OraStr_4 As String

#End Region

#Region " * SMS_EXCEL_UPLOAD"

    Public Function SMSEXCEL_INSERT(ByVal IFILENAME As String, ByVal IFILEPATH As String, ByVal IUSERSLNO As Integer, ByVal IUPDTIME As String, ByVal ISUBJECT As String, ByVal IUPLDUSERMOBILE As Double, ByVal DS As DataSet, ByVal SMSDEPTSLNO As Integer) As Integer

        Dim rtnString As Integer
        Dim RtnVal As Integer
        Try
            Dim setResult As String

            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oTrans = oConn.BeginTransaction()

            RtnVal = SMSEXCEL_MTINSERT(IFILENAME, IFILEPATH, IUSERSLNO, IUPDTIME, ISUBJECT, IUPLDUSERMOBILE, SMSDEPTSLNO)

            rtnString = SMSEXCEL_DTINSERT(DS, RtnVal, SMSDEPTSLNO)

            oTrans.Commit()

            Return rtnString

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function SMSEXCEL_MTINSERT(ByVal IFILENAME As String, ByVal IFILEPATH As String, ByVal IUSERSLNO As Integer, ByVal IUPDTIME As String, ByVal ISUBJECT As String, ByVal IUPLDUSERMOBILE As Double, ByVal ISMSDEPTSLNO As Integer) As Integer
        Try
            oComm = New OracleCommand
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm.CommandText = "SMSEXCEL_INSERT_MT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("IFILENAME", OracleType.VarChar, 1000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = IFILENAME

            oParam = oComm.Parameters.Add("IFILEPATH", OracleType.VarChar, 1000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = IFILEPATH

            oParam = oComm.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = IUSERSLNO

            oParam = oComm.Parameters.Add("IUPLOADTIME", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = IUPDTIME

            oParam = oComm.Parameters.Add("ISUBJECT", OracleType.VarChar, 1000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ISUBJECT

            oParam = oComm.Parameters.Add("IUPLDUSERMOBILE", OracleType.Double, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = IUPLDUSERMOBILE

            oParam = oComm.Parameters.Add("ISMSDEPTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ISMSDEPTSLNO

            oComm.Parameters.Add(New OracleParameter("SeqMt", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()

            rtnVal = oComm.Parameters("SeqMt").Value

            Return rtnVal

            'oParam = oComm.Parameters.Add("ISMSNO", OracleType.Number)
            'oParam.Direction = ParameterDirection.Input
            'oParam.SourceColumn = "ISMSNO"

            'oParam = oComm.Parameters.Add("ISMSNO", OracleType.VarChar, 1000)
            'oParam.Direction = ParameterDirection.Input
            'oParam.SourceColumn = "ISMSTEXT"

            'oAdap.InsertCommand = oComm
            'oAdap.Update(DS, "NewDt")

            'oComm.ExecuteNonQuery()

            ' oTrans.Commit()
        Catch ex As Exception

        End Try
    End Function

    Public Function SMSEXCEL_DTINSERT(ByVal DS As DataSet, ByVal RTN As Integer, ByVal SMSDEPTSLNO As Integer) As Integer
        Try
            oComm = New OracleCommand
            ConObj = New Connection
            oAdap = New OracleDataAdapter
            oConn = ConObj.GetConnection()

            oComm.CommandText = "SMSEXCEL_INSERT_DT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("ISMSEXCELSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = rtnVal

            oParam = oComm.Parameters.Add("ISMSNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ISMSNO"

            oParam = oComm.Parameters.Add("ISMSTEXT", OracleType.VarChar, 1000)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ISMSTEXT"

            oParam = oComm.Parameters.Add("ISMSDEPTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SMSDEPTSLNO

            oAdap.InsertCommand = oComm
            oAdap.Update(DS, "NEWdT")

            Return 1

        Catch ex As Exception

        End Try
    End Function


#End Region

#Region " * SMS_APPROVAL"

    Public Function SMS_APPROVE(ByVal Strn As String, ByVal Userslno As Integer, ByVal DS As DataSet) As Integer
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oTrans = oConn.BeginTransaction()

            Dim myOracleCommand As New OracleClient.OracleCommand

            myOracleCommand.Connection = oConn

            myOracleCommand.Transaction = oTrans

            myOracleCommand.CommandText = "UPDATE SMS_EXCEL_MT SET STATUS=1,APPROVEDTIME='" & System.DateTime.Today.Now.ToShortDateString + " " + System.DateTime.Today.Now.ToShortTimeString & "',APPROVEDBY=" & Userslno & " WHERE SMSEXCELSLNO IN (" & Strn & ")"

            myOracleCommand.ExecuteNonQuery()

            rtnVal = SMS_INSERT_NARAYANAMOBILE(DS)

            If rtnVal = 1 Then
                oTrans.Commit()
            Else
                oTrans.Rollback()
            End If

            Return rtnVal

        Catch ex As Exception

        End Try
    End Function

    Public Function SMS_INSERT_NARAYANAMOBILE(ByVal DSET As DataSet) As Integer
        Try
            oComm = New OracleCommand
            ConObj = New Connection
            oAdap = New OracleDataAdapter
            oConn = ConObj.GetConnection()

            oComm.CommandText = "SMSMOBILE_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("ISMS", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SMSNO"

            oParam = oComm.Parameters.Add("IDESC", OracleType.VarChar, 500)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SMSDESC"

            oAdap.InsertCommand = oComm
            oAdap.Update(DSET, "Sms")

            Return 1
        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " * USERMOBILE-LABLE"

    Public Function UserMobile(ByVal sqlstr As String) As String
        Try
            Objfetch = New Utility
            Ds = Objfetch.DataSet_OneFetch(sqlstr)
            If Ds.Tables(0).Rows.Count <> 0 Then
                UMText = Ds.Tables(0).Rows(0).Item(0).ToString
                UMText += ",After Sending SMS Verification Message Send to this Mobile..!"
            Else
                UMText = "No Mobile"
                UMText += ",Mobile Not found..! "
            End If
            Return UMText
        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " * SMS-DEPT & MAPPING"

    Public Function DeptInsert(ByVal Deptname As String, ByVal DeptDesc As String) As String
        Try

            oComm = New OracleCommand
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm.CommandText = "EXAM_SMSDEPT_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("INAME", OracleType.VarChar, 1000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Deptname

            oParam = oComm.Parameters.Add("IDESC", OracleType.VarChar, 1000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = DeptDesc

            rtnVal = oComm.ExecuteNonQuery()

            Return rtnVal

        Catch ex As Exception

        End Try
    End Function

    Public Function DeptUserMapInsert(ByVal dset As DataSet, ByVal Userslno As Integer, ByVal Comacademicslno As Integer) As Integer
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            rtnVal = DeptUserDelete(Userslno, Comacademicslno, oConn, oTrans)

            If rtnVal <> 1 Then
                oTrans.Rollback()
                Return rtnVal
            End If

            rtnVal = DeptUserInsert(dset, oConn, oTrans)
            If rtnVal <> 1 Then
                oTrans.Rollback()
                Return rtnVal
            End If

            oTrans.Commit()
            Return 1
        Catch ex As Exception

        End Try
    End Function

    Public Function DeptUserInsert(ByVal Dset As DataSet, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As Integer
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand("EXAM_SMSDEPTMAP_INSERT")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("ISMSDEPTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ISMSDEPTSLNO"

            oParam = oComm.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "IUSERSLNO"

            oParam = oComm.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ICOMACADEMICSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(Dset, Dset.Tables(0).TableName)

            Return 1

        Catch ex As Exception

        End Try
    End Function

    Public Function DeptUserDelete(ByVal UserSlno As Integer, ByVal Comacademicslno As Integer, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction)
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("EXAM_SMSDEPTMAP_DELETE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = UserSlno

            oParam = oComm.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Comacademicslno

            rtnVal = oComm.ExecuteNonQuery()

            Return 1

        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " * C_EXCEL_UPLOAD"

    'Public Function CEXCEL_INSERT(ByVal C_DS As DataSet, ByVal DEXAMSLNO As Integer) As Integer

    '    Dim rtnString As Integer
    '    Dim RtnVal As Integer
    '    Try
    '        Dim setResult As String

    '        ConObj = New Connection
    '        oConn = ConObj.GetConnection()

    '        RtnVal = C_TAILORANDRESULT_INSERT(C_DS, DEXAMSLNO)

    '        Return rtnString

    '    Catch ex As Exception
    '        oTrans.Rollback()
    '        Throw ex
    '    Finally
    '        If Not ConObj Is Nothing Then ConObj.Free()
    '    End Try

    'End Function

    Public Function C_TAILORANDRESULT_INSERT(ByVal C_DS As DataSet, ByVal IDEXAMSLNO As Integer) As Integer
        Try
            oComm = New OracleCommand
            ConObj = New Connection
            oAdap = New OracleDataAdapter
            oConn = ConObj.GetConnection()

            oComm.CommandText = "C_TAILORING_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "DEXAMSLNO"

            oParam = oComm.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "UNIQUENO"

            oParam = oComm.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SUBJECTSLNO"

            oParam = oComm.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "STUMARKS"

            oParam = oComm.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "MAXMARKS"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(C_DS, "CIns")

            'oComm.Parameters.Add(New OracleParameter("SeqMt", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            'oComm.ExecuteNonQuery()

            'rtnVal = oComm.Parameters("SeqMt").Value

            Return 1

        Catch ex As Exception

        End Try
    End Function

    Public Function C_TAILORING_UPDATE(ByVal C_DS As DataSet) As Integer
        Try
            oComm = New OracleCommand
            ConObj = New Connection
            oAdap = New OracleDataAdapter
            oConn = ConObj.GetConnection()

            oComm.CommandText = "C_TAILOR_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "DEXAMSLNO"

            oParam = oComm.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "UNIQUENO"

            oAdap.InsertCommand = oComm
            'oAdap.UpdateCommand = oComm
            'oAdapter.UpdateCommand = UCommand
            'oAdapter.Update(dsDes, dsDes.Tables(0).TableName)
            oAdap.Update(C_DS, "CIns")
            'adap.InsertCommand = oComm

            'adap.Update(SPDset, "Name")
            'oComm.ExecuteNonQuery()

            Return 1

        Catch ex As Exception

        End Try
    End Function

    'Public Function CEXCEL_DTINSERT(ByVal C_DS As DataSet, ByVal IDEXAMSLNO As Integer) As Integer
    '    Try
    '        oComm = New OracleCommand
    '        ConObj = New Connection
    '        oAdap = New OracleDataAdapter
    '        oConn = ConObj.GetConnection()

    '        oComm.CommandText = "CEXCEL_INSERT_DT"
    '        oComm.Connection = oConn
    '        oComm.CommandType = CommandType.StoredProcedure

    '        oParam = oComm.Parameters.Add("ISMSEXCELSLNO", OracleType.Number)
    '        oParam.Direction = ParameterDirection.Input
    '        oParam.Value = rtnVal

    '        oParam = oComm.Parameters.Add("ISMSNO", OracleType.Number)
    '        oParam.Direction = ParameterDirection.Input
    '        oParam.SourceColumn = "ISMSNO"

    '        oParam = oComm.Parameters.Add("ISMSTEXT", OracleType.VarChar, 1000)
    '        oParam.Direction = ParameterDirection.Input
    '        oParam.SourceColumn = "ISMSTEXT"

    '        oParam = oComm.Parameters.Add("IDEXAMSLNO", OracleType.Number)
    '        oParam.Direction = ParameterDirection.Input
    '        oParam.Value = IDEXAMSLNO

    '        oAdap.InsertCommand = oComm
    '        oAdap.Update(Ds, "NEWdT")

    '        Return 1

    '    Catch ex As Exception

    '    End Try
    'End Function

    Public Function C_EBSLNOUPDATE(ByVal DsEbSlno As DataSet) As Integer
        Dim rtnString As String
        Try
            Dim uCommand As New OracleClient.OracleCommand
            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oTrans = oConn.BeginTransaction()

            uCommand.CommandText = "CEXAM_EBSLNO_UPDATE"
            uCommand.Connection = oConn
            uCommand.CommandType = CommandType.StoredProcedure
            uCommand.Transaction = oTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParam = uCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iUNIQUENO
            oParam = uCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "UNIQUENO"

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParam = uCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER NAME iUPDATETABLE
            oParam = uCommand.Parameters.Add("iUPDATETABLE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "UPDATETABLE"

            oAdap.InsertCommand = uCommand
            oAdap.UpdateCommand = uCommand
            oAdap.Update(DsEbSlno, "DtEbslno")

            oTrans.Commit()

            Return 1

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return rtnString
    End Function


#End Region

#Region " * SMS OPINION "

    Public Function SMSOPINION_DTINSERT(ByVal DS As DataSet, ByVal SMSOPINIONSLNO As Integer) As Integer
        Try
            oComm = New OracleCommand
            ConObj = New Connection
            oAdap = New OracleDataAdapter
            oConn = ConObj.GetConnection()

            oComm.CommandText = "SMSOPINION_DT_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSMSOPINIONSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SMSOPINIONSLNO

            oParam = oComm.Parameters.Add("iSMSNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ismsNo"

            oParam = oComm.Parameters.Add("iSMSTEXT", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ismsText"

            oParam = oComm.Parameters.Add("iSMSADMNO", OracleType.VarChar, 8)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ismsAdmno"

            oParam = oComm.Parameters.Add("iSMSANS", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ismsAns"

            oAdap.InsertCommand = oComm
            oAdap.Update(DS, "NewDt")

            Return 1

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetOpinionQuestion() As DataSet
        Try
            Objfetch = New Utility
            Ds = Objfetch.DataSet_OneFetch("SELECT OPINIONSLNO SLNO,OPINIONQSTN NAME FROM SMS_OPINION_MT")
            Return Ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetOpinionReportQuery(ByVal OpinionSlno As Integer, ByVal ComAcaSlno As Integer) As DataSet
        Try

            OraStr = " SELECT DECODE(GROUPING(EXAMBRANCHSLNO),1,'GRAND',EXAMBRANCHSLNO) EXAMBRANCHSLNO,decode(grouping(EXAMBRANCHNAME), 1, 'TOTAL', EXAMBRANCHNAME) EXAMBRANCHNAME,SUM(YOLD)+SUM(YNEW)+SUM(NOLD)+SUM(NNEW)TOT,SUM(YOLD)+SUM(NOLD) OREPL,SUM(YOLD) YOCNT,SUM(NOLD) NOCNT,SUM(YNEW)+SUM(NNEW) NREPL,SUM(YNEW) YNCNT,SUM(NNEW) NNCNT FROM (" & _
                     " SELECT * FROM (SELECT A.EXAMBRANCHSLNO, C.EXAMBRANCHNAME,B.OPINIONANS, A.OLDORNEW FROM T_ADM_DT A, SMS_OPINION_DT B, EXAM_EXAMBRANCH C" & _
                     " WHERE A.ADMNO = B.OPINIONADMNO AND A.EXAMBRANCHSLNO = C.EXAMBRANCHSLNO AND B.OPINIONSLNO=" & OpinionSlno.ToString & " AND A.COMACADEMICSLNO = " & ComAcaSlno.ToString & ")" & _
                     " PIVOT (COUNT(OPINIONANS) FOR (OPINIONANS,OLDORNEW) IN(('YES','O') AS YOLD,('YES','N') AS YNEW,('NO','O') AS NOLD,('NO','N') AS NNEW))) GROUP BY ROLLUP(EXAMBRANCHSLNO,EXAMBRANCHNAME)"

            OraStr_1 = "SELECT A1.EXAMBRANCHSLNO,COUNT(A1.ADMSLNO) STRN FROM T_ADM_DT A1 WHERE A1.COMACADEMICSLNO=" & ComAcaSlno.ToString & " AND A1.STATUS IN (1,8) GROUP BY EXAMBRANCHSLNO"

            OraStr_3 = "SELECT OPINIONDATE,OPINIONMOBILE,OPINIONTEXT FROM SMS_OPINION_DT WHERE OPINIONANS NOT IN ('YES','NO') AND OPINIONSLNO=" & OpinionSlno.ToString

            OraStr_2 = "SELECT * FROM (SELECT OPINIONDATE,OPINIONMOBILE,OPINIONTEXT FROM SMS_OPINION_DT WHERE OPINIONANS NOT IN ('YES','NO') AND OPINIONSLNO=" & OpinionSlno.ToString & ") WHERE ROWNUM<101"

            OraStr_4 = "SELECT REPORTON FROM SMS_OPINION_MT WHERE OPINIONSLNO=" & OpinionSlno.ToString

            Objfetch = New Utility
            Ds = Objfetch.DataSet_FiveFetch(OraStr, OraStr_1, OraStr_2, OraStr_3, OraStr_4)

            Return Ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
