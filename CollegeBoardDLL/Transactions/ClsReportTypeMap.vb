' FIELE CREATED BY          : k.shankar sudershan rao
' PURPOSE                   : using for exambranch/region/zone/do/vc/unit ic wise report type map
' DATE                      : 2-11-2010

Public Class ClsReportTypeMap

    Private oConn As OracleConnection  'Connection Object Declaration.
    Private oComm As OracleCommand  'Command Object Declaration.
    Private oAdap As OracleDataAdapter  'Adapter Object Declaration.
    Private oParam As OracleParameter  'Parameter Object Declaration.
    Private Ds As DataSet
    Private ConObj As Connection
    Private oTrans As OracleTransaction

#Region "EXAMBRANCH/REGION/ZONE/DO/VC/UNIT IC MAP SCREEN"

    Public Function F_EBRZDVUREPORTTYPEMAP_INSERT(ByVal pDs As DataSet) As Integer
        Try
            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleDataAdapter

            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oTrans = oConn.BeginTransaction()

            oComm.CommandText = "P_EREPORTTYPEMAP_INSERT"
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iREPTYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "REPTYPESLNO"

            oParam = oComm.Parameters.Add("iREPTYPEDTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "REPTYPEDTSLNO"

            oParam = oComm.Parameters.Add("iEXAMBATCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "EXAMBATCHSLNO"

            oParam = oComm.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "EXAMBRANCHSLNO"

            oParam = oComm.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COURSESLNO"


            oParam = oComm.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "GROUPSLNO"


            oAdap.InsertCommand = oComm
            oAdap.Update(pDs, pDs.Tables(0).TableName)

            oTrans.Commit()

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function F_EBRZDVUREPORTTYPEMAP_DELETE(ByVal pSLNO As Integer) As Integer

        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "P_EREPORTTYPEMAP_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iREPMAPSLNO", OracleType.Number)
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

    Public Function F_EBRZDVUREPORTTYPEMAP_DELETEBATCH(ByVal pDS As DataSet) As Integer

        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleDataAdapter

            oConn = ConObj.GetConnection()

            oComm.CommandText = "P_EREPORTTYPEMAP_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iREPMAPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "REPMAPSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(pDS, pDS.Tables(0).TableName)

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
