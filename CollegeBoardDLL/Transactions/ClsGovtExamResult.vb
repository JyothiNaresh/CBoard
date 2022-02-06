Imports System.Data.OracleClient
Imports System.Data
Public Class ClsGovtExamResult

#Region "Common Variables"

    Private oConn As OracleConnection
    Private oCommand As OracleCommand
    Private oAdapter As OracleDataAdapter
    Private oParameter As OracleParameter
    Private oTrans As OracleTransaction
    Private objConn As Connection
    Private Ds As New DataSet
    Private Drow As OracleDataReader
    Private rtnMessage As String
    Private ReturnStr As Integer
    Private RetValue As Double

#End Region

#Region "ComboBox Filling"

    Public Function Govt_UserWise_ExamBranch(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "ATTND_USERWISE_EXAMBRANCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iUSERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            objConn.Free()
        End Try

    End Function

    Public Function Govt_Exams_Fill() As Data.DataSet

        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "GOVT_EXAMS_FILL"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DATACUR
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            objConn.Free()
        End Try

    End Function

    Public Function Govt_SearchData(ByRef DsSearchData As DataSet, ByVal pSEARCHTYPE As Integer, ByVal pEXAMSLNO As Integer, ByVal pEXAMBRANCHSLNO As Integer, ByVal pNO As String, ByVal pCOMACADEMICSLNO As Integer) As Byte

        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "GOVT_SEARCHDATA"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSEARCHTYPE
            oParameter = oCommand.Parameters.Add("iSEARCHTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSEARCHTYPE

            'ADD IN PARAMETER NAME iEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iNO
            oParameter = oCommand.Parameters.Add("iNO", OracleType.VarChar, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR1", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR2", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oCommand.Parameters.Add(New OracleParameter("oRtnValue", OracleType.Number)).Direction = ParameterDirection.ReturnValue

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(DsSearchData)

            Return oCommand.Parameters("oRtnValue").Value

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function Govt_SearchUpdateData(ByRef DsSearchData As DataSet, ByVal pSEARCHTYPE As Integer, ByVal pEXAMSLNO As Integer, ByVal pEXAMBRANCHSLNO As Integer, ByVal pNO As String, ByVal pCOMACADEMICSLNO As Integer) As Byte

        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "GOVT_SEARCHUPDATEDATA"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSEARCHTYPE
            oParameter = oCommand.Parameters.Add("iSEARCHTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSEARCHTYPE

            'ADD IN PARAMETER NAME iEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iNO
            oParameter = oCommand.Parameters.Add("iNO", OracleType.VarChar, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR1", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR2", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oCommand.Parameters.Add(New OracleParameter("oRtnValue", OracleType.Number)).Direction = ParameterDirection.ReturnValue

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(DsSearchData)

            Return oCommand.Parameters("oRtnValue").Value

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

#End Region

#Region "Govt ExamResultData Inser/Update"

    Public Function Govt_ExamData_Save(ByVal DsGovtExam As DataSet, ByVal Arr As ArrayList) As String

        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oTrans = oConn.BeginTransaction

            Govt_ExamTotalData_Save(Arr, oConn, oTrans)

            Govt_ExamSubjectData_Save(DsGovtExam, oConn, oTrans)

            oTrans.Commit()

            rtnMessage = 1

            Return rtnMessage

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Private Sub Govt_ExamTotalData_Save(ByVal Arr As ArrayList, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "GOVT_EXAMTOTALDATA_INSERT"
            oCommand.Connection = pConn
            oCommand.Transaction = pTrans
            oCommand.CommandType = CommandType.StoredProcedure

            ''''''''''''''''''''''''''''''''''''''''''''' 1 '''''''''''''''''''''''''''''''''''''''''''''''''''''

            'ADD IN PARAMETER NAME iTRANSDATE
            oParameter = oCommand.Parameters.Add("iTRANSDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'ADD IN PARAMETER NAME iUSERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)


            'ADD IN PARAMETER NAME iEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            'ADD IN PARAMETER NAME iHTNO
            oParameter = oCommand.Parameters.Add("iHTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            'ADD IN PARAMETER NAME iAPPNO
            oParameter = oCommand.Parameters.Add("iAPPNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)


            'ADD IN PARAMETER NAME iREGNO
            oParameter = oCommand.Parameters.Add("iREGNO", OracleType.VarChar, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            'ADD IN PARAMETER NAME iTOTALMARKS
            oParameter = oCommand.Parameters.Add("iTOTALMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            'ADD IN PARAMETER NAME iOBTAINMARKS
            oParameter = oCommand.Parameters.Add("iOBTAINMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            'ADD IN PARAMETER NAME iPERCENTAGE
            oParameter = oCommand.Parameters.Add("iPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            'ADD IN PARAMETER NAME iRANK
            oParameter = oCommand.Parameters.Add("iRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            'ADD IN PARAMETER NAME iRESULT
            oParameter = oCommand.Parameters.Add("iRESULT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Govt_ExamSubjectData_Save(ByVal pDtGovtExam As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "GOVT_EXAMSUBJECTDATA_INSERT"
            oCommand.Connection = pConn
            oCommand.Transaction = pTrans
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iTRANSDATE
            oParameter = oCommand.Parameters.Add("iTRANSDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRANSDATE"

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            'ADD IN PARAMETER NAME iUSERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "USERSLNO"

            'ADD IN PARAMETER NAME iEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMSLNO"

            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'ADD IN PARAMETER NAME iHTNO
            oParameter = oCommand.Parameters.Add("iHTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "HTNO"

            'ADD IN PARAMETER NAME iAPPNO
            oParameter = oCommand.Parameters.Add("iAPPNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "APPNO"

            'ADD IN PARAMETER NAME iREGNO
            oParameter = oCommand.Parameters.Add("iREGNO", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "REGNO"

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME iMAXMARKS
            oParameter = oCommand.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MAXMARKS"

            'ADD IN PARAMETER NAME iMINIMARKS
            oParameter = oCommand.Parameters.Add("iMINIMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MINIMARKS"

            'ADD IN PARAMETER NAME iOBTAINMARKS
            oParameter = oCommand.Parameters.Add("iOBTAINMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "OBTAINMARKS"

            'ADD IN PARAMETER NAME iPERCENTAGE
            oParameter = oCommand.Parameters.Add("iPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PERCENTAGE"

            'ADD IN PARAMETER NAME iRANK
            oParameter = oCommand.Parameters.Add("iRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RANK"

            'ADD IN PARAMETER NAME iRESULT
            oParameter = oCommand.Parameters.Add("iRESULT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RESULT"

            'ADD IN PARAMETER NAME iACTRESULT
            oParameter = oCommand.Parameters.Add("iACTRESULT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ACTRESULT"

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(pDtGovtExam.Tables("GovtExamData"))

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function Govt_ExamData_Upadte(ByVal DsGovtExam As DataSet, ByVal Arr As ArrayList) As String

        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oTrans = oConn.BeginTransaction

            Govt_ExamTotalData_Update(Arr, oConn, oTrans)

            Govt_ExamSubjectData_Update(DsGovtExam, oConn, oTrans)

            oTrans.Commit()

            rtnMessage = 1

            Return rtnMessage

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Private Sub Govt_ExamTotalData_Update(ByVal Arr As ArrayList, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "GOVT_EXAMTOTALDATA_UPDATE"
            oCommand.Connection = pConn
            oCommand.Transaction = pTrans
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEGMSLNO
            oParameter = oCommand.Parameters.Add("iEGMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'ADD IN PARAMETER NAME iEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'ADD IN PARAMETER NAME iTOTALMARKS
            oParameter = oCommand.Parameters.Add("iTOTALMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            'ADD IN PARAMETER NAME iOBTAINMARKS
            oParameter = oCommand.Parameters.Add("iOBTAINMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            'ADD IN PARAMETER NAME iPERCENTAGE
            oParameter = oCommand.Parameters.Add("iPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            'ADD IN PARAMETER NAME iRANK
            oParameter = oCommand.Parameters.Add("iRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            'ADD IN PARAMETER NAME iRESULT
            oParameter = oCommand.Parameters.Add("iRESULT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Govt_ExamSubjectData_Update(ByVal pDtGovtExam As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "GOVT_EXAMSUBJECTDATA_UPDATE"
            oCommand.Connection = pConn
            oCommand.Transaction = pTrans
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEGDSLNO
            oParameter = oCommand.Parameters.Add("iEGDSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EGDSLNO"

            'ADD IN PARAMETER NAME iEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMSLNO"

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME iMAXMARKS
            oParameter = oCommand.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MAXMARKS"

            'ADD IN PARAMETER NAME iMINIMARKS
            oParameter = oCommand.Parameters.Add("iMINIMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MINIMARKS"

            'ADD IN PARAMETER NAME iOBTAINMARKS
            oParameter = oCommand.Parameters.Add("iOBTAINMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "OBTAINMARKS"

            'ADD IN PARAMETER NAME iPERCENTAGE
            oParameter = oCommand.Parameters.Add("iPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PERCENTAGE"

            'ADD IN PARAMETER NAME iRANK
            oParameter = oCommand.Parameters.Add("iRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RANK"

            'ADD IN PARAMETER NAME iRESULT
            oParameter = oCommand.Parameters.Add("iRESULT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RESULT"

            'ADD IN PARAMETER NAME iACTRESULT
            oParameter = oCommand.Parameters.Add("iACTRESULT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ACTRESULT"

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(pDtGovtExam.Tables("GovtExamData"))

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

#Region "Govt Exam Result Report"

    Public Function Govt_ExamResult_AllFill(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "GOVT_EXAMRESULT_ALLFILL"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iUSERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR1", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR2", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR3", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR4", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR5", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR6", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            objConn.Free()
        End Try

    End Function

#End Region

#Region "Comman DataSets"

    Public Function DataSet_OneFetch(ByVal SqlString1 As String) As Data.DataSet
        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oCommand.CommandText = "PARSE_SQLSTRING1"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSqlString1", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlString1

            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try
    End Function

    Public Function DataSet_TwoFetch(ByVal SqlString1 As String, ByVal SqlString2 As String) As Data.DataSet
        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oCommand.CommandText = "PARSE_SQLSTRING2"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSqlString1", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlString1


            oParameter = oCommand.Parameters.Add("iSqlString2", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlString2

            oParameter = oCommand.Parameters.Add("DataCur1", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("DataCur2", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try
    End Function

    Public Function DataSet_ThreeFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String) As Data.DataSet
        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oCommand.CommandText = "PARSE_SQLSTRING3"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSqlString1", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlString1

            oParameter = oCommand.Parameters.Add("iSqlString2", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlString2

            oParameter = oCommand.Parameters.Add("iSqlString3", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlString3

            oParameter = oCommand.Parameters.Add("DataCur1", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("DataCur2", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("DataCur3", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try
    End Function

    Public Function DataSet_FourFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String) As Data.DataSet
        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oCommand.CommandText = "PARSE_SQLSTRING4"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSqlString1", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlString1

            oParameter = oCommand.Parameters.Add("iSqlString2", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlString2

            oParameter = oCommand.Parameters.Add("iSqlString3", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlString3

            oParameter = oCommand.Parameters.Add("iSqlString4", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlString4

            oParameter = oCommand.Parameters.Add("DataCur1", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("DataCur2", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("DataCur3", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("DataCur4", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try
    End Function

#End Region

#Region " Result Modules "

#Region " Masters For Exam Results "
    Public Function ExamResult_Insert(ByVal pEXAMSLNO As Integer, ByVal pREXNAME As String, ByVal pEXAMTYPE As String, ByVal pACADEMICSLNO As Integer, ByVal pTOTALMARKS As Integer) As String
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand.CommandText = "RESULT_RESULTEXAMS_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            'ADD IN PARAMETER NAME iRENAME
            oParameter = oCommand.Parameters.Add("iRENAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pREXNAME

            'ADD IN PARAMETER NAME iEXAMTYPE
            oParameter = oCommand.Parameters.Add("iEXAMTYPE", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMTYPE

            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACADEMICSLNO

            'ADD IN PARAMETER NAME iTOTALMARKS
            oParameter = oCommand.Parameters.Add("iTOTALMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pTOTALMARKS

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function ExamResult_Update(ByVal RSLNO As Long, ByVal pEXAMSLNO As Integer, ByVal pREXNAME As String, ByVal pEXAMTYPE As String, ByVal pACADEMICSLNO As Integer, ByVal pTOTALMARKS As Integer) As String
        Dim strReturn As String
        Try

            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "RESULT_RESULTEXAMS_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME RSLNO
            oParameter = oCommand.Parameters.Add("iRESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = RSLNO

            'ADD IN PARAMETER Examslno
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            'ADD IN PARAMETER Reslut Exam NAME 
            oParameter = oCommand.Parameters.Add("iRENAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pREXNAME

            'ADD IN PARAMETER Reslut Exam Type 
            oParameter = oCommand.Parameters.Add("iEXAMTYPE", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMTYPE

            'ADD IN PARAMETER ACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACADEMICSLNO

            'ADD IN PARAMETER TOTALMARKS
            oParameter = oCommand.Parameters.Add("iTOTALMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pTOTALMARKS

            oCommand.ExecuteNonQuery()
            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function ExamResult_Delete(ByVal pRSLNO As Integer) As String
        Dim strReturn As String
        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "RESULT_RESULTEXAMS_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iRESLNO
            oParameter = oCommand.Parameters.Add("iRESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pRSLNO

            'oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try
        Return strReturn
    End Function

    Public Function ExamResult_InsertBatch(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            objConn = New Connection
            oConn = objConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "RESULT_RESULTEXAMS_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMSLNO"

            'ADD IN PARAMETER NAME iRENAME
            oParameter = oCommand.Parameters.Add("iRENAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RE_NAME"

            'ADD IN PARAMETER NAME iEXAMTYPE
            oParameter = oCommand.Parameters.Add("iEXAMTYPE", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPE"

            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ACADEMICSLNO"

            'ADD IN PARAMETER NAME iTOTALMARKS
            oParameter = oCommand.Parameters.Add("iTOTALMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOTALMARKS"

            ''ADD IN PARAMETER subject
            'oParameter = oCommand.Parameters.Add("iRENAME", OracleType.VarChar)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "RE_NAME"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "Client")

            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function
#End Region

#Region " Masters For ResulERGS "

    Public Function ResultERGS_Insert(ByVal pEXAMSLNO As Integer, ByVal pRESLNO As Integer, ByVal pACADEMIC As Integer, ByVal pGROUPSLNO As Integer, ByVal pSUBJECTSLNO As Integer) As String
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand.CommandText = "RESULT_ERGS_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            'ADD IN PARAMETER NAME iRESLNO
            oParameter = oCommand.Parameters.Add("iRESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pRESLNO

            'ADD IN PARAMETER NAME iACADEMIC
            oParameter = oCommand.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACADEMIC

            'ADD IN PARAMETER NAME iGROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pGROUPSLNO

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSUBJECTSLNO

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function ResultERGS_Update(ByVal pERGSLNO As Long, ByVal pEXAMSLNO As Integer, ByVal pRESLNO As Integer, ByVal pACADEMIC As Integer, ByVal pGROUPSLNO As Integer, ByVal pSUBJECTSLNO As Integer) As String
        Dim strReturn As String
        Try

            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "RESULT_ERGS_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME ERGSLNO
            oParameter = oCommand.Parameters.Add("iERGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pERGSLNO

            'ADD IN PARAMETER NAME iEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMSLNO

            'ADD IN PARAMETER NAME iRESLNO
            oParameter = oCommand.Parameters.Add("iRESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pRESLNO

            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACADEMIC

            'ADD IN PARAMETER NAME iGROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pGROUPSLNO

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSUBJECTSLNO




            oCommand.ExecuteNonQuery()
            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function ResultERGS_Delete(ByVal pERGSLNO As Integer) As String
        Dim strReturn As String
        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "RESULT_ERGS_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBASLNo
            oParameter = oCommand.Parameters.Add("iERGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pERGSLNO

            'oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try
        Return strReturn
    End Function

    Public Function ResultERGS_InsertBatch(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            objConn = New Connection
            oConn = objConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "RESULT_ERGS_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME exam name
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMSLNO"

            'ADD IN PARAMETER iRESLNO
            oParameter = oCommand.Parameters.Add("iRESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RESLNO"

            'ADD IN PARAMETER iACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ACADEMICSLNO"

            'ADD IN PARAMETER subject
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'ADD IN PARAMETER subject
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "Client")

            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function
#End Region

#Region " Masters For Corporate College "

    Public Function CORPCOLLEGE_Insert(ByVal pCORPNAME As String, ByVal pDESCRIPTION As String) As String
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand.CommandText = "RESULT_CORPCOLLEGE_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCORPNAME

            'ADD IN PARAMETER NAME iDESCRPITION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDESCRIPTION

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function CORPCOLLEGE_Update(ByVal CORPSLNO As Long, ByVal pCORPNAME As String, ByVal pDESCRIPTION As String) As String
        Dim strReturn As String
        Try

            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "RESULT_CORPCOLLEGE_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME RSLNO
            oParameter = oCommand.Parameters.Add("iCORPCOLSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CORPSLNO

            'ADD IN PARAMETER Examslno
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCORPNAME

            'ADD IN PARAMETER Reslut Exam NAME 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDESCRIPTION

            oCommand.ExecuteNonQuery()
            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function CORPCOLLEGE_Delete(ByVal CORPSLNO As Integer) As String
        Dim strReturn As String
        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "RESULT_CORPCOLLEGE_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCORPCOLSLNO
            oParameter = oCommand.Parameters.Add("iCORPCOLSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CORPSLNO


            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try
        Return strReturn
    End Function

    Public Function CORPCOLLEGE_InsertBatch(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            objConn = New Connection
            oConn = objConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "RESULT_CORPCOLLEGE_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NAME"

            'ADD IN PARAMETER NAME iDESCRPITION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "Client")

            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function
#End Region

#Region " Masters For College Results "
    Public Function CollegeResult_Insert(ByVal pCORPCOLSLNO As Integer, ByVal pCOLLEGENAME As String, ByVal pCOLLEGECODE As Integer) As String
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand.CommandText = "RESULT_COLLEGE_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCORPCOLSLNO
            oParameter = oCommand.Parameters.Add("iCORPCOLSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCORPCOLSLNO

            'ADD IN PARAMETER NAME iCOLLEGENAME
            oParameter = oCommand.Parameters.Add("iCOLLEGENAME", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOLLEGENAME

            'ADD IN PARAMETER NAME iCOLLEGECODE
            oParameter = oCommand.Parameters.Add("iCOLLEGECODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOLLEGECODE

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function CollegeResult_Update(ByVal pCORPCOLSLNO As Integer, ByVal pCOLSLNO As Integer, ByVal pCOLLEGENAME As String, ByVal pCOLLEGECODE As Integer) As String
        Dim strReturn As String
        Try

            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "RESULT_COLLEGE_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCORPCOLSLNO
            oParameter = oCommand.Parameters.Add("iCORPCOLSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCORPCOLSLNO

            'ADD IN PARAMETER NAME iCORPCOLSLNO
            oParameter = oCommand.Parameters.Add("iCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOLSLNO


            'ADD IN PARAMETER NAME iCOLLEGENAME
            oParameter = oCommand.Parameters.Add("iCOLLEGENAME", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOLLEGENAME

            'ADD IN PARAMETER NAME iCOLLEGECODE
            oParameter = oCommand.Parameters.Add("iCOLLEGECODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOLLEGECODE

            oCommand.ExecuteNonQuery()
            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function CollegeResult_Delete(ByVal pCOLSLNO As Integer) As String
        Dim strReturn As String
        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "RESULT_COLLEGE_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCOLLEGESLNO
            oParameter = oCommand.Parameters.Add("iCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOLSLNO

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try
        Return strReturn
    End Function

    Public Function CollegeResult_InsertBatch(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            objConn = New Connection
            oConn = objConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "RESULT_COLLEGE_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCORPCOLSLNO
            oParameter = oCommand.Parameters.Add("iCORPCOLSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORPCOLSLNO"

            'ADD IN PARAMETER NAME iCOLLEGENAME
            oParameter = oCommand.Parameters.Add("iCOLLEGENAME", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COLLEGENAME"

            'ADD IN PARAMETER NAME iCOLLEGECODE
            oParameter = oCommand.Parameters.Add("iCOLLEGECODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COLLEGECODE"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "Client")

            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function CollegeResult_UpdateBatch(ByRef PDataSet As DataSet) As String
        Dim strReturn As String
        Try

            objConn = New Connection
            oAdapter = New OracleDataAdapter
            oConn = objConn.GetConnection()
            oTrans = oConn.BeginTransaction()


            'objConn = New Connection
            'oConn = objConn.GetConnection()
            'oAdapter = New OracleDataAdapter
            'oTrans = oConn.BeginTransaction()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "RESULT_COLLEGE_UPDATE"
            oCommand.Connection = oConn
            oCommand.Transaction = oTrans
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCORPCOLSLNO
            oParameter = oCommand.Parameters.Add("iCORPCOLSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORPCOLSLNO"

            'ADD IN PARAMETER NAME COLLEGESLNO
            oParameter = oCommand.Parameters.Add("iCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COLLEGESLNO"


            'ADD IN PARAMETER NAME iCOLLEGENAME
            oParameter = oCommand.Parameters.Add("iCOLLEGENAME", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COLLEGENAME"

            'ADD IN PARAMETER NAME iCOLLEGECODE
            oParameter = oCommand.Parameters.Add("iCOLLEGECODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COLLEGECODE"

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(PDataSet, "Client")
            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function
#End Region

#Region " Masters For Academic Year "

    Public Function AcademicYear_Insert(ByVal pACADEMICNAME As String, ByVal pDESCRIPTION As String) As String
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand.CommandText = "RESULT_ACADEMIC_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iACADEMICNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACADEMICNAME

            'ADD IN PARAMETER NAME iDESCRPITION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDESCRIPTION

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function AcademicYear_Update(ByVal CORPSLNO As Long, ByVal pACADEMICNAME As String, ByVal pDESCRIPTION As String) As String
        Dim strReturn As String
        Try

            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "RESULT_ACADEMIC_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME RSLNO
            oParameter = oCommand.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CORPSLNO

            'ADD IN PARAMETER Examslno
            oParameter = oCommand.Parameters.Add("iACADEMICNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACADEMICNAME

            'ADD IN PARAMETER Reslut Exam NAME 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDESCRIPTION

            oCommand.ExecuteNonQuery()
            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function AcademicYear_Delete(ByVal ACADEMICSLNO As Integer) As String
        Dim strReturn As String
        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "RESULT_ACADEMIC_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ACADEMICSLNO


            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try
        Return strReturn
    End Function

    Public Function AcademicYear_InsertBatch(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            objConn = New Connection
            oConn = objConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "RESULT_ACADEMIC_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iACADEMICNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NAME"

            'ADD IN PARAMETER NAME iDESCRPITION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "Client")

            oTrans.Commit()

            ReturnStr = 1

            Return ReturnStr

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function
#End Region

#Region "Transactions"

    Public Function GovtStuMarks_SearchData(ByVal pSEARCHTYPE As Integer, ByVal pCOMACADEMICSLNO As Integer, ByVal pNO As String, ByVal pMarksFor As Integer, ByVal pResultExamSlNo As Integer, ByVal pACADEMICSLNO As Integer) As DataSet
        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "GOVTSTUMARKS_SEARCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSEARCHTYPE
            oParameter = oCommand.Parameters.Add("iRtnValue", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSEARCHTYPE

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME iNO
            oParameter = oCommand.Parameters.Add("iNO", OracleType.VarChar, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pNO

            'ADD IN PARAMETER NAME iMarksFor
            oParameter = oCommand.Parameters.Add("iMARKSFOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pMarksFor



            'ADD IN PARAMETER NAME iResultExamSlNo
            oParameter = oCommand.Parameters.Add("iRESULTEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pResultExamSlNo


            'ADD IN PARAMETER NAME pACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACADEMICSLNO


            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("DATACURSTU", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try
        Return Ds

    End Function

    Public Function Govt_StudentData_Save(ByVal Arr As ArrayList, ByVal DsGovtStuMarks As DataSet) As String

        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oTrans = oConn.BeginTransaction

            RetValue = Govt_StudentHeaderData_Save(Arr, oConn, oTrans)

            Govt_StudentDetailData_Save(DsGovtStuMarks, RetValue, oConn, oTrans)

            oTrans.Commit()

            rtnMessage = 1

            Return rtnMessage

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function Govt_StudentData_Verified(ByVal Arr As ArrayList, ByVal DsGovtStuMarks As DataSet, ByVal iUSERSLNO As Integer) As String

        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oTrans = oConn.BeginTransaction

            RetValue = Govt_StudentHeaderData_Verification(Arr, oConn, oTrans, iUSERSLNO)

            Govt_StudentDetailData_Save(DsGovtStuMarks, RetValue, oConn, oTrans)

            oTrans.Commit()

            rtnMessage = 1

            Return rtnMessage

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try
    End Function
    Private Function Govt_StudentHeaderData_Save(ByVal Arr As ArrayList, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As Double
        Try

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "GOVT_STUDENTRESMARKSMT_INSERT"
            'GOVT_STUDENTRESMARKSVF_INSERT
            oCommand.Connection = pConn
            oCommand.Transaction = pTrans
            oCommand.CommandType = CommandType.StoredProcedure

            ''''''''''''''''''''''''''''''''''''''''''''' 1 '''''''''''''''''''''''''''''''''''''''''''''''''''''

            'ADD IN PARAMETER NAME iEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'ADD IN PARAMETER NAME iRESLNO
            oParameter = oCommand.Parameters.Add("iRESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)


            'ADD IN PARAMETER NAME iCOLLEGESLNO
            oParameter = oCommand.Parameters.Add("iCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)


            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            'ADD IN PARAMETER NAME iCOLLEGESLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)


            'ADD IN PARAMETER NAME iHTNO
            oParameter = oCommand.Parameters.Add("iHTNO", OracleType.VarChar, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            'ADD IN PARAMETER NAME iAPPNO
            oParameter = oCommand.Parameters.Add("iAPPNO", OracleType.VarChar, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            'ADD IN PARAMETER NAME iREGNO
            oParameter = oCommand.Parameters.Add("iREGNO", OracleType.VarChar, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            'ADD IN PARAMETER NAME iCASTESLNO
            oParameter = oCommand.Parameters.Add("iCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            'ADD IN PARAMETER NAME iTOTALMARKS
            oParameter = oCommand.Parameters.Add("iTOTALMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            'ADD IN PARAMETER NAME iTOTALRANK
            oParameter = oCommand.Parameters.Add("iTOTALRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            'ADD IN PARAMETER NAME iGRADE
            oParameter = oCommand.Parameters.Add("iGRADE", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            'ADD IN PARAMETER NAME iRESULT
            oParameter = oCommand.Parameters.Add("iRESULT", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            'ADD IN PARAMETER NAME iBTECHTOTAL
            oParameter = oCommand.Parameters.Add("iBTECHTOTAL", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            'ADD IN PARAMETER NAME iBTECHAIR
            oParameter = oCommand.Parameters.Add("iBTECHAIR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            'ADD IN PARAMETER NAME iBTECHSR
            oParameter = oCommand.Parameters.Add("iBTECHSR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            'ADD IN PARAMETER NAME iBRACHTOTAL
            oParameter = oCommand.Parameters.Add("iBRACHTOTAL", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            'ADD IN PARAMETER NAME iBRACHAIR
            oParameter = oCommand.Parameters.Add("iBRACHAIR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            'ADD IN PARAMETER NAME iBRACHSR
            oParameter = oCommand.Parameters.Add("iBRACHSR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            'ADD IN PARAMETER NAME iBPHARTOTAL
            oParameter = oCommand.Parameters.Add("iBPHARTOTAL", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            'ADD IN PARAMETER NAME iBPHARAIR
            oParameter = oCommand.Parameters.Add("iBPHARAIR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            'ADD IN PARAMETER NAME iBPHARSR
            oParameter = oCommand.Parameters.Add("iBPHARSR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            'ADD IN PARAMETER NAME iCATRANK
            oParameter = oCommand.Parameters.Add("iCATRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(29)

            'ADD IN PARAMETER NAME iCATSUBPCRANK
            oParameter = oCommand.Parameters.Add("iCATSUBPCRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(30)

            'ADD IN PARAMETER NAME iCATSUBPTRANK
            oParameter = oCommand.Parameters.Add("iCATSUBPTRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(31)

            'ADD IN PARAMETER NAME iCATSUBPTRANK
            oParameter = oCommand.Parameters.Add("iISPREPARATORYRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(32)

            'ADD IN PARAMETER NAME iCATSUBPTRANK
            oParameter = oCommand.Parameters.Add("iPREPARATORYRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(33)

            'ADD IN PARAMETER NAME iRSMSLNO
            oParameter = oCommand.Parameters.Add("iRSMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(36)

            'ADD IN PARAMETER NAME iMARKSFOR
            oParameter = oCommand.Parameters.Add("iMARKSFOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(37)

            'ADD IN PARAMETER NAME iIITPAPER1
            oParameter = oCommand.Parameters.Add("iIITPAPER1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(34)

            'ADD IN PARAMETER NAME iIITPAPER2
            oParameter = oCommand.Parameters.Add("iIITPAPER2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(35)

            'ADD IN PARAMETER NAME iBTECHAIRCAT
            oParameter = oCommand.Parameters.Add("iBTECHAIRCAT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            'ADD IN PARAMETER NAME iBTECHSRCAT
            oParameter = oCommand.Parameters.Add("iBTECHSRCAT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

            'ADD IN PARAMETER NAME iBARCHAIRCAT
            oParameter = oCommand.Parameters.Add("iBARCHAIRCAT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)

            'ADD IN PARAMETER NAME iBTECHSRCAT
            oParameter = oCommand.Parameters.Add("iBARCHSRCAT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)

            'ADD IN PARAMETER NAME iBPHARAIRCAT
            oParameter = oCommand.Parameters.Add("iBPHARAIRCAT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(27)

            'ADD IN PARAMETER NAME iBPHARSRCAT
            oParameter = oCommand.Parameters.Add("iBPHARSRCAT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(28)

            oCommand.Parameters.Add(New OracleParameter("oRtnValue", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            Return oCommand.Parameters("oRtnValue").Value

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function Govt_StudentHeaderData_Verification(ByVal Arr As ArrayList, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction, ByVal IUSERSLNO As Integer) As Double
        Try
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "GOVT_STUDENTRESMARKSVF_INSERT"
            oCommand.Connection = pConn
            oCommand.Transaction = pTrans
            oCommand.CommandType = CommandType.StoredProcedure

            ''''''''''''''''''''''''''''''''''''''''''''' 1 '''''''''''''''''''''''''''''''''''''''''''''''''''''

            'ADD IN PARAMETER NAME iEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'ADD IN PARAMETER NAME iRESLNO
            oParameter = oCommand.Parameters.Add("iRESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)


            'ADD IN PARAMETER NAME iCOLLEGESLNO
            oParameter = oCommand.Parameters.Add("iCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)


            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            'ADD IN PARAMETER NAME iCOLLEGESLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)


            'ADD IN PARAMETER NAME iHTNO
            oParameter = oCommand.Parameters.Add("iHTNO", OracleType.VarChar, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            'ADD IN PARAMETER NAME iAPPNO
            oParameter = oCommand.Parameters.Add("iAPPNO", OracleType.VarChar, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            'ADD IN PARAMETER NAME iREGNO
            oParameter = oCommand.Parameters.Add("iREGNO", OracleType.VarChar, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            'ADD IN PARAMETER NAME iCASTESLNO
            oParameter = oCommand.Parameters.Add("iCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            'ADD IN PARAMETER NAME iTOTALMARKS
            oParameter = oCommand.Parameters.Add("iTOTALMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            'ADD IN PARAMETER NAME iTOTALRANK
            oParameter = oCommand.Parameters.Add("iTOTALRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            'ADD IN PARAMETER NAME iGRADE
            oParameter = oCommand.Parameters.Add("iGRADE", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            'ADD IN PARAMETER NAME iRESULT
            oParameter = oCommand.Parameters.Add("iRESULT", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            'ADD IN PARAMETER NAME iBTECHTOTAL
            oParameter = oCommand.Parameters.Add("iBTECHTOTAL", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            'ADD IN PARAMETER NAME iBTECHAIR
            oParameter = oCommand.Parameters.Add("iBTECHAIR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            'ADD IN PARAMETER NAME iBTECHSR
            oParameter = oCommand.Parameters.Add("iBTECHSR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            'ADD IN PARAMETER NAME iBRACHTOTAL
            oParameter = oCommand.Parameters.Add("iBRACHTOTAL", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            'ADD IN PARAMETER NAME iBRACHAIR
            oParameter = oCommand.Parameters.Add("iBRACHAIR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            'ADD IN PARAMETER NAME iBRACHSR
            oParameter = oCommand.Parameters.Add("iBRACHSR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            'ADD IN PARAMETER NAME iBPHARTOTAL
            oParameter = oCommand.Parameters.Add("iBPHARTOTAL", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            'ADD IN PARAMETER NAME iBPHARAIR
            oParameter = oCommand.Parameters.Add("iBPHARAIR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            'ADD IN PARAMETER NAME iBPHARSR
            oParameter = oCommand.Parameters.Add("iBPHARSR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            'ADD IN PARAMETER NAME iCATRANK
            oParameter = oCommand.Parameters.Add("iCATRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(29)

            'ADD IN PARAMETER NAME iCATSUBPCRANK
            oParameter = oCommand.Parameters.Add("iCATSUBPCRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(30)

            'ADD IN PARAMETER NAME iCATSUBPTRANK
            oParameter = oCommand.Parameters.Add("iCATSUBPTRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(31)

            'ADD IN PARAMETER NAME iCATSUBPTRANK
            oParameter = oCommand.Parameters.Add("iISPREPARATORYRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(32)

            'ADD IN PARAMETER NAME iCATSUBPTRANK
            oParameter = oCommand.Parameters.Add("iPREPARATORYRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(33)

            'ADD IN PARAMETER NAME iRSMSLNO
            oParameter = oCommand.Parameters.Add("iRSMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(36)

            'ADD IN PARAMETER NAME iMARKSFOR
            oParameter = oCommand.Parameters.Add("iMARKSFOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(37)

            'ADD IN PARAMETER NAME iIITPAPER1
            oParameter = oCommand.Parameters.Add("iIITPAPER1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(34)

            'ADD IN PARAMETER NAME iIITPAPER2
            oParameter = oCommand.Parameters.Add("iIITPAPER2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(35)

            'ADD IN PARAMETER NAME iBTECHAIRCAT
            oParameter = oCommand.Parameters.Add("iBTECHAIRCAT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            'ADD IN PARAMETER NAME iBTECHSRCAT
            oParameter = oCommand.Parameters.Add("iBTECHSRCAT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

            'ADD IN PARAMETER NAME iBARCHAIRCAT
            oParameter = oCommand.Parameters.Add("iBARCHAIRCAT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)

            'ADD IN PARAMETER NAME iBTECHSRCAT
            oParameter = oCommand.Parameters.Add("iBARCHSRCAT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)

            'ADD IN PARAMETER NAME iBPHARAIRCAT
            oParameter = oCommand.Parameters.Add("iBPHARAIRCAT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(27)

            'ADD IN PARAMETER NAME iBPHARSRCAT
            oParameter = oCommand.Parameters.Add("iBPHARSRCAT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(28)

            oParameter = oCommand.Parameters.Add("IVERIFIED_USER", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = IUSERSLNO

            oCommand.Parameters.Add(New OracleParameter("oRtnValue", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            Return oCommand.Parameters("oRtnValue").Value

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function Govt_StudentDetailData_Save(ByVal pDtGovtExam As DataSet, ByVal pRSMSLNO As Double, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As Double
        Try

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "GOVT_STUDENTRESMARKSDT_INSERT"
            oCommand.Connection = pConn
            oCommand.Transaction = pTrans
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iRSMSLNO 
            oParameter = oCommand.Parameters.Add("iRSMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pRSMSLNO

            'ADD IN PARAMETER NAME iEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMSLNO"

            'ADD IN PARAMETER NAME iRESLNO
            oParameter = oCommand.Parameters.Add("iRESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RESLNO"

            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"


            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iAPPNO
            oParameter = oCommand.Parameters.Add("iAPPNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "APPNO"

            'ADD IN PARAMETER NAME iHTNO
            oParameter = oCommand.Parameters.Add("iHTNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "HTNO"

            'ADD IN PARAMETER NAME iREGNO
            oParameter = oCommand.Parameters.Add("iREGNO", OracleType.VarChar, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "REGNO"

            'ADD IN PARAMETER NAME iCASTESLNO
            oParameter = oCommand.Parameters.Add("iCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CASTESLNO"

            'ADD IN PARAMETER NAME iTOTALMARKS
            oParameter = oCommand.Parameters.Add("iSUBJECTMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTMARKS"

            'ADD IN PARAMETER NAME iTOTALRANK
            oParameter = oCommand.Parameters.Add("iSUBJECTRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTRANK"

            'ADD IN PARAMETER NAME iRESULT
            oParameter = oCommand.Parameters.Add("iRESULT", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RESULT"

            'ADD IN PARAMETER NAME iBTECHTOTAL
            oParameter = oCommand.Parameters.Add("iBTECHTOTAL", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BTECHTOTAL"

            'ADD IN PARAMETER NAME iBTECHAIR
            oParameter = oCommand.Parameters.Add("iBTECHAIR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BTECHAIR"

            'ADD IN PARAMETER NAME iBTECHSR
            oParameter = oCommand.Parameters.Add("iBTECHSR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BTECHSR"

            'ADD IN PARAMETER NAME iBRACHTOTAL
            oParameter = oCommand.Parameters.Add("iBRACHTOTAL", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRACHTOTAL"

            'ADD IN PARAMETER NAME iBRACHAIR
            oParameter = oCommand.Parameters.Add("iBRACHAIR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRACHAIR"

            'ADD IN PARAMETER NAME iBRACHSR
            oParameter = oCommand.Parameters.Add("iBRACHSR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRACHSR"

            'ADD IN PARAMETER NAME iBPHARTOTAL
            oParameter = oCommand.Parameters.Add("iBPHARTOTAL", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BPHARTOTAL"

            'ADD IN PARAMETER NAME iBPHARAIR
            oParameter = oCommand.Parameters.Add("iBPHARAIR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BPHARAIR"

            'ADD IN PARAMETER NAME iBPHARSR
            oParameter = oCommand.Parameters.Add("iBPHARSR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BPHARSR"

            'ADD IN PARAMETER NAME iCATRANK
            oParameter = oCommand.Parameters.Add("iCATRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CATRANK"

            'ADD IN PARAMETER NAME iCATSUBPCRANK
            oParameter = oCommand.Parameters.Add("iCATSUBPCRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CATSUBPCRANK"

            'ADD IN PARAMETER NAME iCATSUBPTRANK
            oParameter = oCommand.Parameters.Add("iCATSUBPTRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CATSUBPTRANK"


            'ADD IN PARAMETER NAME iIITPAPER1
            oParameter = oCommand.Parameters.Add("iIITPAPER1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "IITPAPER1"

            'ADD IN PARAMETER NAME iIITPAPER2
            oParameter = oCommand.Parameters.Add("iIITPAPER2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "IITPAPER2"




            oAdapter.InsertCommand = oCommand
            oAdapter.Update(pDtGovtExam.Tables("Student"))

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#End Region


End Class
