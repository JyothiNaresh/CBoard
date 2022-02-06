'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS EXAMINATION 2.0
'   OBJECTIVE                         : THIS IS MIDDLE LAYER FOR ACTIVITY QUESTION PAPER
'   ACTIVITY                          : ALL
'   AUTHOR                            : AMARENDRA B.V
'   INITIAL BASELINE DATE             : 22-5-2008
'   FINAL BASELINE DATE               : 22-5-2008
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration
Public Class ClsActivity

#Region "Common Variables"
    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ds As New Data.DataSet
    Private oTrans As OracleTransaction
    Private ObjConn As Connection
    Private ReturnStr As Integer

#End Region

#Region "DataSetFetch"

    Public Function dataSet_Fetch(ByVal pSqlString As String) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "PARSE_SQLSTRING"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add IN Parameter to Accept the Sql String
            oParameter = oCommand.Parameters.Add("iSqlString", OracleType.VarChar, 5000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSqlString

            'ADD IN PARAMETER NAME CURSOR
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

#End Region

#Region "Masters"

#Region " Activity "

    Public Function Activity_Insert(ByVal pACTIVITYNAME As String, ByVal pDESCRIPTION As String) As String
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "ACT_ACTIVITY_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iACTIVITY", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACTIVITYNAME

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
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Activity_Update(ByVal ACTSLNO As Long, ByVal pACTIVITYNAME As String, ByVal pDESCRIPTION As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "ACT_ACTIVITY_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME RSLNO
            oParameter = oCommand.Parameters.Add("iACTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ACTSLNO

            'ADD IN PARAMETER Examslno
            oParameter = oCommand.Parameters.Add("iACTIVITY", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACTIVITYNAME

            'ADD IN PARAMETER Reslut Exam NAME 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDESCRIPTION

            oCommand.ExecuteNonQuery()
            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Activity_Delete(ByVal ACTSLNO As Integer) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "ACT_ACTIVITY_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iACTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ACTSLNO


            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function

    Public Function Activity_InsertBatch(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "ACT_ACTIVITY_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iACTIVITY", OracleType.VarChar, 100)
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
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region " Group Header "
    Public Function ActivityGroupHeader_Insert(ByVal pExambranchslno As Integer, ByVal pCourseslno As Integer, ByVal pGROUPHEADERNAME As String, ByVal pDESCRIPTION As String, ByVal pCOMACADEMICSLNO As Integer) As String
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "ACT_GROUPHEADER_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pExambranchslno

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCourseslno

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iGROUPHEADERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pGROUPHEADERNAME

            'ADD IN PARAMETER NAME iDESCRPITION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDESCRIPTION

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ActivityGroupHeader_Update(ByVal GHSLNO As Long, ByVal pExambranchslno As Integer, ByVal pCourseslno As Integer, ByVal pGROUPHEADERNAME As String, ByVal pDESCRIPTION As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "ACT_GROUPHEADER_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME RSLNO
            oParameter = oCommand.Parameters.Add("iGHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GHSLNO

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pExambranchslno

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCourseslno

            'ADD IN PARAMETER Examslno
            oParameter = oCommand.Parameters.Add("iGROUPHEADERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pGROUPHEADERNAME

            'ADD IN PARAMETER Reslut Exam NAME 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDESCRIPTION

            oCommand.ExecuteNonQuery()
            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ActivityGroupHeader_Delete(ByVal GHSLNO As Integer) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "ACT_GROUPHEADER_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iGHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GHSLNO


            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function

    Public Function ActivityGroupHeader_InsertBatch(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "ACT_GROUPHEADER_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iGROUPHEADERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NAME"

            'ADD IN PARAMETER NAME iDESCRPITION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

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
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region "Group Header Mapping"

    Public Function Act_GroupHeaderMapping_Insert(ByVal Arr As ArrayList) As Integer
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "ACT_BSSGH_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'ADD IN PARAMETER NAME iGROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            'ADD IN PARAMETER NAME iBATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            'ADD IN PARAMETER NAME iSECTIONSLNO
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            'ADD IN PARAMETER NAME iSUBSECTIONSLNO
            oParameter = oCommand.Parameters.Add("iGRPACTIVITYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            'ADD IN PARAMETER NAME iGHSLNO
            oParameter = oCommand.Parameters.Add("iGHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oCommand.ExecuteNonQuery()

            Return 1

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Act_GroupHeaderMapping_Update(ByVal Arr As ArrayList) As Integer
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "ACT_BSSGH_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBSSGHSLNO
            oParameter = oCommand.Parameters.Add("iBSSGHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            'ADD IN PARAMETER NAME iGROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            'ADD IN PARAMETER NAME iBATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            'ADD IN PARAMETER NAME iSECTIONSLNO
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            'ADD IN PARAMETER NAME iSUBSECTIONSLNO
            oParameter = oCommand.Parameters.Add("iGRPACTIVITYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            'ADD IN PARAMETER NAME iGHSLNO
            oParameter = oCommand.Parameters.Add("iGHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oCommand.ExecuteNonQuery()

            Return 1

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Act_GroupHeaderMapping_Delete(ByVal pBSSGHSLNO As Integer) As Integer
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "ACT_BSSGH_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBSSGHSLNO
            oParameter = oCommand.Parameters.Add("iBSSGHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBSSGHSLNO

            oCommand.ExecuteNonQuery()

            Return 1

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#End Region

#Region "Transactions"

#Region " Question Paper "

    Public Function Act_QuestionPaperMt_Insert(ByVal Arr As ArrayList) As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "ACT_QUESPAPERMT_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iTYPESLNO
            oParameter = oCommand.Parameters.Add("iTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'ADD IN PARAMETER NAME iQUSPNAME
            oParameter = oCommand.Parameters.Add("iQUSPNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            'ADD IN PARAMETER NAME iACTSLNO
            oParameter = oCommand.Parameters.Add("iACTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)


            'ADD IN PARAMETER NAME iDESCRPITION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)


            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 50)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            Return oCommand.Parameters("oRtnValid").Value


        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Act_QuestionPaperMt_Update(ByVal Arr As ArrayList) As Integer
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "ACT_QUESPAPERMT_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iQUSPMSLNO
            oParameter = oCommand.Parameters.Add("iQUSPMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'ADD IN PARAMETER NAME iACTSLNO
            oParameter = oCommand.Parameters.Add("iACTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            'ADD IN PARAMETER NAME iQUSPNAME
            oParameter = oCommand.Parameters.Add("iQUSPNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            'ADD IN PARAMETER NAME iDESCRPITION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oCommand.ExecuteNonQuery()

            Return 1

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Act_QuestionPaperMt_Delete(ByVal pQUSPMSLNO As Integer) As Integer
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "ACT_QUESPAPERMT_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iQUSPMSLNO
            oParameter = oCommand.Parameters.Add("iQUSPMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pQUSPMSLNO

            oCommand.ExecuteNonQuery()

            Return 1

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Act_QuestionPaperDt_Insert(ByVal Arr As ArrayList) As Integer
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "ACT_QUESTIONPAPER_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iQUSPMSLNO
            oParameter = oCommand.Parameters.Add("iQUSPMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'ADD IN PARAMETER NAME iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            'ADD IN PARAMETER NAME iNOOFQUESTIONS
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            'ADD IN PARAMETER NAME iMAXMARKS
            oParameter = oCommand.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            'ADD IN PARAMETER NAME iMINMARKS
            oParameter = oCommand.Parameters.Add("iMINMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            'ADD IN PARAMETER NAME iNEGMARKS
            oParameter = oCommand.Parameters.Add("iNEGMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oCommand.ExecuteNonQuery()

            Return 1

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Act_QuestionPaperDt_Update(ByVal Arr As ArrayList) As Integer
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "ACT_QUESTIONPAPER_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iQUSPSLNO
            oParameter = oCommand.Parameters.Add("iQUSPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'ADD IN PARAMETER NAME iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            'ADD IN PARAMETER NAME iNOOFQUESTIONS
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            'ADD IN PARAMETER NAME iMAXMARKS
            oParameter = oCommand.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            'ADD IN PARAMETER NAME iMINMARKS
            oParameter = oCommand.Parameters.Add("iMINMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            'ADD IN PARAMETER NAME iNEGMARKS
            oParameter = oCommand.Parameters.Add("iNEGMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oCommand.ExecuteNonQuery()

            Return 1

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Act_QuestionPaperDt_Delete(ByVal pQUSPSLNO As Integer) As Integer
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "ACT_QUESTIONPAPER_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iQUSPSLNO
            oParameter = oCommand.Parameters.Add("iQUSPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pQUSPSLNO

            oCommand.ExecuteNonQuery()

            Return 1

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region " Define Activity "

    Public Function DefineAct_Insert(ByVal Arr As ArrayList) As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "ACT_DEFINEACT_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iTYPESLNO
            oParameter = oCommand.Parameters.Add("iTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'ADD IN PARAMETER NAME iACTSLNO
            oParameter = oCommand.Parameters.Add("iACTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            'ADD IN PARAMETER NAME iQUSPNAME
            oParameter = oCommand.Parameters.Add("iDACTNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            'ADD IN PARAMETER NAME iQUSPMSLNO
            oParameter = oCommand.Parameters.Add("iQUSPMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            'ADD IN PARAMETER NAME iDADATE
            oParameter = oCommand.Parameters.Add("iDADATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            'ADD IN PARAMETER NAME iDESCRPITION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 50)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            Return oCommand.Parameters("oRtnValid").Value

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Sub DefineAct_Update(ByVal Arr As ArrayList)
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "ACT_DEFINEACT_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDACTSLNO
            oParameter = oCommand.Parameters.Add("iDACTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'ADD IN PARAMETER NAME iACTSLNO
            oParameter = oCommand.Parameters.Add("iACTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'ADD IN PARAMETER NAME iQUSPNAME
            oParameter = oCommand.Parameters.Add("iDACTNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            'ADD IN PARAMETER NAME iQUSPMSLNO
            oParameter = oCommand.Parameters.Add("iQUSPMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)


            'ADD IN PARAMETER NAME iDADATE
            oParameter = oCommand.Parameters.Add("iDADATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)


            'ADD IN PARAMETER NAME iDESCRPITION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oCommand.ExecuteNonQuery()



        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub DefineAct_Delete(ByVal pDACTSLNO As Integer)
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "ACT_DEFINEACT_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iQUSPMSLNO
            oParameter = oCommand.Parameters.Add("iDACTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDACTSLNO

            oCommand.ExecuteNonQuery()


        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

#End Region

#Region " Marks Entry"
    Public Function ActivityMarks_InsertBatch(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "ACT_MARKS_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDACTSLNO
            oParameter = oCommand.Parameters.Add("iDACTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DACTSLNO"

            'ADD IN PARAMETER NAME iACTSLNO
            oParameter = oCommand.Parameters.Add("iACTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ACTSLNO"

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'ADD IN PARAMETER NAME iGROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'ADD IN PARAMETER NAME iBATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BATCHSLNO"


            'ADD IN PARAMETER NAME iSECTIONSLNO
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"

            'ADD IN PARAMETER NAME iSUBSECTIONSLNO
            oParameter = oCommand.Parameters.Add("iGRPACTIVITYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GRPACTIVITYSLNO"

            'ADD IN PARAMETER NAME iQUSPMSLNO
            oParameter = oCommand.Parameters.Add("iQUSPMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUSPMSLNO"

            'ADD IN PARAMETER NAME iQUSPSLNO
            oParameter = oCommand.Parameters.Add("iQUSPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUSPSLNO"

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"

            'ADD IN PARAMETER NAME iMAXMARKS
            oParameter = oCommand.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MAXMARKS"

            'ADD IN PARAMETER NAME iMINMARKS
            oParameter = oCommand.Parameters.Add("iMINMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MINMARKS"

            'ADD IN PARAMETER NAME iOBPOSMARKS
            oParameter = oCommand.Parameters.Add("iOBPOSMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "OBPOSMARKS"

            'ADD IN PARAMETER NAME iOBNEGMARKS
            oParameter = oCommand.Parameters.Add("iOBNEGMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "OBNEGMARKS"

            'ADD IN PARAMETER NAME iOBTAINEDMARKS
            oParameter = oCommand.Parameters.Add("iOBTAINEDMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "OBTAINEDMARKS"

            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "Activity")

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
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ActivityMarks_Delete(ByVal pDACTSLNO As Integer, ByVal pACTSLNO As Integer, ByVal pEXAMBRANCHSLNO As Integer, ByVal pCOURSESLNO As Integer, ByVal pGROUPSLNO As Integer, ByVal pBATCHSLNO As Integer, ByVal pSECTIONSLNO As Integer, ByVal pGRPACTIVITYSLNO As Integer, ByVal pQUSPMSLNO As Integer) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "ACT_MARKS_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDACTSLNO
            oParameter = oCommand.Parameters.Add("iDACTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDACTSLNO

            'ADD IN PARAMETER NAME iACTSLNO
            oParameter = oCommand.Parameters.Add("iACTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACTSLNO

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOURSESLNO

            'ADD IN PARAMETER NAME iGROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pGROUPSLNO

            'ADD IN PARAMETER NAME iBATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBATCHSLNO


            'ADD IN PARAMETER NAME iSECTIONSLNO
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSECTIONSLNO

            'ADD IN PARAMETER NAME iSUBSECTIONSLNO
            oParameter = oCommand.Parameters.Add("iGRPACTIVITYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pGRPACTIVITYSLNO

            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iQUSPMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pQUSPMSLNO


            oCommand.ExecuteNonQuery()

            ReturnStr = 1

            Return ReturnStr

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function
#End Region

#End Region

#Region "Reports"

#End Region


End Class
