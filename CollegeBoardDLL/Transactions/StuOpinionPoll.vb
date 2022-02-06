Imports System.Data.OracleClient
Public Class StuOpinionPoll

#Region "Class Variables"
    Private oConn As OracleConnection 'Connection Object Declaration.
    Private oComm As OracleCommand 'Command Object Declaration.
    Private oTrans As OracleTransaction 'Transaction Object Declaration.
    Private oAdap As OracleDataAdapter 'Adapter Object Declaration.
    Private oParam As OracleParameter 'Parameter Object Declaration.
    Private Ds As DataSet
    Private ConObj As Connection
    Private rtnMessage As String
    Private ReturnOpnstmtslno As Long
#End Region

#Region " StuOpinion Poll"

    Public Function EXAM_OPINION_STUWISE_INSERTS(ByVal Arr As ArrayList) As Long
        Try

            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter

            oComm = New OracleCommand

            oComm = New OracleCommand("EXAM_OPINION_STUWISE_INSERT")
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)


            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iPOLLDATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)


            oParam = oComm.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)


            oParam = oComm.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)


            oParam = oComm.Parameters.Add("iREMARKS", OracleType.VarChar, 2000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)


            oComm.Parameters.Add(New OracleParameter("oRtnValid", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()
            ReturnOpnstmtslno = oComm.Parameters("oRtnValid").Value

            Return ReturnOpnstmtslno

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function EXAM_OPINION_STUWISE_UPDATE(ByVal pMtno As Long, ByVal pRemark As String, ByVal pUserslno As Integer) As Long
        Try

            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter

            oComm = New OracleCommand

            oComm = New OracleCommand("EXAM_OPINION_STUWISE_UPDATE")
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iOPNSTMTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pMtno

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUserslno

            oParam = oComm.Parameters.Add("iREMARKS", OracleType.VarChar, 2000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pRemark


            oComm.ExecuteNonQuery()


        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function EXAM_OPINION_STUWISEDETAILS_INSERTS(ByVal pDSet As DataSet) As Integer
        Try

            Dim adap As New OracleDataAdapter
            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter

            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oTrans = oConn.BeginTransaction()
            oComm.Transaction = oTrans

            oComm.CommandText = "EXAM_OPN_STUWISEDTLS_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'Dim adap As New OracleDataAdapter
            'ConObj = New Connection
            'oConn = ConObj.GetConnection()

            'oTrans = oConn.BeginTransaction()
            'oComm.Transaction = oTrans

            'oComm = New OracleClient.OracleCommand
            'oParam = New OracleClient.OracleParameter

            'oComm = New OracleCommand

            'oComm.CommandText = "EXAM_OPN_STUWISEDTLS_INSERT"
            'oComm.Connection = oConn
            'oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iOPNSTMTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OPNSTMTSLNO"

            oParam = oComm.Parameters.Add("iOPNSETSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OPNSETSLNO"

            oParam = oComm.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "EMPSLNO"

            oParam = oComm.Parameters.Add("iCOMP_POOR", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMP_POOR"

            oParam = oComm.Parameters.Add("iCOMP_AVG", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMP_AVG"


            oParam = oComm.Parameters.Add("iCOMP_GOOD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMP_GOOD"


            oParam = oComm.Parameters.Add("iCOMP_EXEC", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMP_EXEC"


            oParam = oComm.Parameters.Add("iIPE_POOR", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "IPE_POOR"


            oParam = oComm.Parameters.Add("iIPE_AVG", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "IPE_AVG"


            oParam = oComm.Parameters.Add("iIPE_GOOD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "IPE_GOOD"


            oParam = oComm.Parameters.Add("iIPE_EXEC", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "IPE_EXEC"

            adap.InsertCommand = oComm

            adap.Update(pDSet, "TEACHALLOTD")

            oTrans.Commit()

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function
    Public Function SchEXAM_OPINION_STUWISEDETAILS_INSERTS(ByVal pDSet As DataSet) As Integer
        Try

            Dim adap As New OracleDataAdapter
            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter

            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oTrans = oConn.BeginTransaction()
            oComm.Transaction = oTrans

            oComm.CommandText = "EXAM_OPN_STUWISEDTLS_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'Dim adap As New OracleDataAdapter
            'ConObj = New Connection
            'oConn = ConObj.GetConnection()

            'oTrans = oConn.BeginTransaction()
            'oComm.Transaction = oTrans

            'oComm = New OracleClient.OracleCommand
            'oParam = New OracleClient.OracleParameter

            'oComm = New OracleCommand

            'oComm.CommandText = "EXAM_OPN_STUWISEDTLS_INSERT"
            'oComm.Connection = oConn
            'oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iOPNSTMTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OPNSTMTSLNO"

            oParam = oComm.Parameters.Add("iOPNSETSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OPNSETSLNO"

            oParam = oComm.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "EMPSLNO"

            oParam = oComm.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SUBJECTSLNO"


            oParam = oComm.Parameters.Add("iIPE_POOR", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "IPE_POOR"


            oParam = oComm.Parameters.Add("iIPE_AVG", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "IPE_AVG"


            oParam = oComm.Parameters.Add("iIPE_GOOD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "IPE_GOOD"


            oParam = oComm.Parameters.Add("iIPE_EXEC", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "IPE_EXEC"

            adap.InsertCommand = oComm

            adap.Update(pDSet, "TEACHALLOTD")

            oTrans.Commit()

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function EXAM_OPINION_STUWISE_DELETE(ByVal pSLNO As Integer) As Integer

        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oComm = New OracleCommand

            oComm.CommandText = "EXAM_OPINION_STUWISE_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function EXAM_OPINION_STUWISE_UPDATE(ByVal pSLNO As Integer, ByVal pREMARKS As String) As Integer
        Try

            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oComm = New OracleCommand

            oComm.CommandText = "EXAM_OPINION_STUWISE_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("iREMARKS", OracleType.VarChar, 2000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pREMARKS


            oComm.ExecuteNonQuery()

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

#End Region


End Class
