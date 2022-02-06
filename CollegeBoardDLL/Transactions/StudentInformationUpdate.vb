'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is the Middle layer for Studentinfo Update.
'   ACTIVITY                          : Update
'   AUTHOR                            : Srikanth
'   INITIAL BASELINE DATE             : 24-FEB-2006
'   FINAL BASELINE DATE               : 24-FEB-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------

Imports System.Data
Imports System.Data.OracleClient
Public Class StudentInformationUpdate

#Region "Class Variables"

    Private oConn As OracleConnection 'Connection Object Declaration.
    Private oComm As OracleCommand 'Command Object Declaration.
    Private oTrans As OracleTransaction 'Transaction Object Declaration.
    Private oAdap As OracleDataAdapter 'Adapter Object Declaration.
    Private oParam As OracleParameter 'Parameter Object Declaration.
    Private Ds As DataSet
    Private ConObj As Connection
    Private rtnMessage As String 'Result of the return type.

#End Region

#Region "Select Methods"

    Public Function GetDataForStudentInfo(ByVal PADMSNO As Integer, ByVal PBRANCHSLNO As Integer) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "M_STUDADMINFO_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iADMSNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PADMSNO

            oParam = oComm.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PBRANCHSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output
            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            ConObj.Free()
        End Try
    End Function

    Public Function GetDataForStudentAddress(ByVal PADMSNO As Integer, ByVal PBRANCHSLNO As Integer, ByVal PCOMACADEMICSLNO As Integer) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "EXAM_STUDADDRESSINFO_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iADMSNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PADMSNO

            oParam = oComm.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PBRANCHSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PCOMACADEMICSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output
            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            ConObj.Free()
        End Try
    End Function

    Public Function GetDataForStudentAddress(ByVal PADMSNO As Integer, ByVal PCOMACADEMICSLNO As Integer) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "COMP_STUDADDRESSINFO_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iADMSNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PADMSNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PCOMACADEMICSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output
            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            ConObj.Free()
        End Try
    End Function
#End Region

#Region "Upadate Methods"
    Public Function StudentInfo_Update(ByVal Arr As ArrayList) As String
        Try


            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("M_STUDADMINFO_UPDATE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSURNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iFATHERNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iMOTHERNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)


            oParam = oComm.Parameters.Add("iGENDER", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iDOB", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iPVCOURSESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)


            oParam = oComm.Parameters.Add("iTOTALMARKS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oParam = oComm.Parameters.Add("iHTNO", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            oParam = oComm.Parameters.Add("iCOLLEGESCHOOL", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            oParam = oComm.Parameters.Add("iCASTESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(10)

            oParam = oComm.Parameters.Add("iFATHEROCCUPATION", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(11)

            oParam = oComm.Parameters.Add("iADMSNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(12)

            oParam = oComm.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(13)

            oComm.ExecuteNonQuery()
            oTrans.Commit()

            Return "SUCCESS"

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            ConObj.Free()
        End Try

    End Function

    Public Function StudentAddress_Update(ByVal Arr As ArrayList) As String
        Try


            ConObj = New Connection
            'oAdap = New OracleDataAdapter
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("EXAM_STUDADDRESS_UPDATE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            '''----------------------------- 1 -------------------------------

            oParam = oComm.Parameters.Add("iADMSNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iCOUNTRYSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iSTATESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iMANDALSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)


            oParam = oComm.Parameters.Add("iMANDAL_AREA", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            '''----------------------------- 2 -------------------------------

            oParam = oComm.Parameters.Add("iSTREET_VILL", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iHNO", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oParam = oComm.Parameters.Add("iPIN", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            oParam = oComm.Parameters.Add("iPHONERES", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            oParam = oComm.Parameters.Add("iPHONEOFF", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(10)

            '''----------------------------- 3 -------------------------------

            oParam = oComm.Parameters.Add("iMOBILE1", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(11)

            oParam = oComm.Parameters.Add("iMOBILE2", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(12)

            oParam = oComm.Parameters.Add("iEMAIL", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(13)

            oParam = oComm.Parameters.Add("iADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(14)

            oComm.ExecuteNonQuery()
            oTrans.Commit()

            Return "SUCCESS"

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            ConObj.Free()
        End Try

    End Function

    Public Function StudentAddress_UpdateComp(ByVal Arr As ArrayList) As String
        Try


            ConObj = New Connection
            'oAdap = New OracleDataAdapter
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("COMP_STUDADDRESS_UPDATE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            '''----------------------------- 1 -------------------------------

            oParam = oComm.Parameters.Add("iADMNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iCOUNTRYSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iSTATESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iMANDALSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)


            oParam = oComm.Parameters.Add("iMANDAL_AREA", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            '''----------------------------- 2 -------------------------------

            oParam = oComm.Parameters.Add("iSTREET_VILL", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iHNO", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oParam = oComm.Parameters.Add("iPIN", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            oParam = oComm.Parameters.Add("iPHONERES", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            oParam = oComm.Parameters.Add("iPHONEOFF", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(10)

            '''----------------------------- 3 -------------------------------

            oParam = oComm.Parameters.Add("iMOBILE1", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(11)

            oParam = oComm.Parameters.Add("iMOBILE2", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(12)

            oParam = oComm.Parameters.Add("iEMAIL", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(13)

            oParam = oComm.Parameters.Add("iIPE_MARKS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(14)

            oParam = oComm.Parameters.Add("iEAM_EXPMARKS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(15)

            oParam = oComm.Parameters.Add("iCASTE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(16)

            oParam = oComm.Parameters.Add("iCOLLEGE", OracleType.VarChar, 200)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(17)

            oParam = oComm.Parameters.Add("iISLT_JOIN", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(18)

            oComm.ExecuteNonQuery()
            oTrans.Commit()

            Return "SUCCESS"

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            ConObj.Free()
        End Try

    End Function


    Public Function StudentCaste_Update_Batch(ByVal ds As DataSet) As String
        Try
            ConObj = New Connection
            oAdap = New OracleDataAdapter
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("M_STUDENTCASTE_BATCH_UPDATE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ADMSLNO"



            oParam = oComm.Parameters.Add("iCASTESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "CASTESLNO"


            oParam = oComm.Parameters.Add("iDOB", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "DOB"



            oAdap.InsertCommand = oComm
            oAdap.Update(ds, "Name")

            oTrans.Commit()


            rtnMessage = "SUCCESS"
            Return rtnMessage

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            ConObj.Free()
        End Try

    End Function

#End Region

#Region "Form No Update"

    Public Function GetDataForFormNoUpdate(ByVal PADMSNO As Integer, ByVal PBRANCHSLNO As Integer, ByVal PCOMACADEMICSLNO As Integer) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "M_ADMFORMNO_SEARCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iADMSNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PADMSNO

            oParam = oComm.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PBRANCHSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PCOMACADEMICSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            ConObj.Free()
        End Try
    End Function

    Public Function FormNo_Update(ByVal PADMSLNO As Long, ByVal PFORMNO As Long) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("F_FORMNOUPDATE_UPDATE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PADMSLNO

            oParam = oComm.Parameters.Add("iFORMNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PFORMNO

            oComm.Parameters.Add(New OracleParameter("oRtnValue", OracleType.Char, 1)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()

            rtnMessage = oComm.Parameters("oRtnValue").Value

            oTrans.Commit()

            Return rtnMessage

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            ConObj.Free()
        End Try

    End Function

#End Region

End Class
