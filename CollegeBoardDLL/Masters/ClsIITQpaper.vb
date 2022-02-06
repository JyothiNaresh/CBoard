'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : Class file for IIT Qpaper Creation
'   AUTHOR                            : Prakash
'   MODIFICATION LOG                  : Venu (FinalKey Corrections Update)
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsIITQpaper
#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private UCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private OraTrans As OracleTransaction
    Dim ds As Data.DataSet
    Dim ObjConn As Connection

#End Region

#Region "IIT QPAPER CREATION USE CASE PROCEDURES"

#Region "IITQpaper Delete"
    Public Function IITQpaper_Delete(ByVal intQPTMTSLNO As Integer, ByVal intQuesNo As Integer, ByVal intCOMACADEMICSLNO As Integer) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter


            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "M_IITQPC_DELETE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            'ADD IN PARAMETER intQPTMTSLNO
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intQPTMTSLNO

            'ADD IN PARAMETER intQuesNo
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intQuesNo

            'ADD IN PARAMETER intCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO


            oCommand.ExecuteNonQuery()

            OraTrans.Commit()
            IITQpaper_Delete = "SUCCESS"

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function
#End Region

#Region "IITQpaper Fetch"

    Public Function IITQpaper_Fetch(ByVal intQPTMTSLNO As Integer, ByVal intCOMACADEMICSLNO As Integer, ByVal IDs As DataSet) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter


            oCommand.CommandText = "M_IITQPC_FETCH"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intQPTMTSLNO

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO

            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(IDs, "IITQP")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return IDs

    End Function
#End Region

#Region "IITQpaper Save/Update"

    Public Function IITQpaper_Save(ByVal dsSet As DataSet, ByVal intCOMACADEMICSLNO As Integer) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            UCommand = New OracleCommand

            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter


            OraTrans = oConn.BeginTransaction


            oCommand.CommandText = "M_IITQPC_SAVE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn
            oCommand.Transaction = OraTrans

            UCommand.CommandText = "M_IITQPC_UPDATE"
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Connection = oConn
            UCommand.Transaction = OraTrans



            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"



            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            oParameter = oCommand.Parameters.Add("iPAPERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PAPERSLNO"


            oParameter = oCommand.Parameters.Add("iQTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QTYPESLNO"

            oParameter = oCommand.Parameters.Add("iPAPERQNO", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PAPERQNO"

            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            oParameter = oCommand.Parameters.Add("iPARENTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PARENTNO"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER8"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER9"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER10"

            

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO

            oParameter = oCommand.Parameters.Add("iISPARENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ISPARENT"


            oAdapter.InsertCommand = oCommand

            '---------------------UPDATE COMMAND---------------------------------

            oParameter = UCommand.Parameters.Add("iQPCSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPCSLNO"


            oParameter = UCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"



            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            oParameter = UCommand.Parameters.Add("iPAPERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PAPERSLNO"

            oParameter = UCommand.Parameters.Add("iQYTPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QTYPESLNO"

            oParameter = UCommand.Parameters.Add("iPAPERQNO", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PAPERQNO"


            oParameter = UCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            oParameter = UCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            oParameter = UCommand.Parameters.Add("iPARENTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PARENTNO"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER8"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER9"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER10"

            oParameter = UCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO

            oParameter = UCommand.Parameters.Add("iISPARENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ISPARENT"



            oAdapter.UpdateCommand = UCommand

            oAdapter.Update(dsSet, "IITQP")

            OraTrans.Commit()
            IITQpaper_Save = "SUCCESS"
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function
#End Region

#End Region

#Region "Copies Fetch"
    Public Function IITQPTCopies_Fetch(ByVal pDEXAMSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_IITCOPIES_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME pCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function
#End Region

#Region "FETCH FROM IIT TAILOR TABLE"
    Public Function IITQPTTailor_Fetch(ByVal pDEXAMSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_IITQPTTAILOR_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME pCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function
#End Region

#Region "IIT Temp Table for Key Entry FETCH/SAVE"
    Public Function IITQpaperTEMP_Save(ByVal dsSet As DataSet, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String, ByVal pCOMACADEMICSLNO As Integer) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            UCommand = New OracleCommand

            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter


            OraTrans = oConn.BeginTransaction


            oCommand.CommandText = "M_IITQPCTEMP_SAVE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn
            oCommand.Transaction = OraTrans

            UCommand.CommandText = "M_IITQPCTEMP_UPDATE"
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Connection = oConn
            UCommand.Transaction = OraTrans



            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"

            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"



            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            oParameter = oCommand.Parameters.Add("iPAPERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PAPERSLNO"

            oParameter = oCommand.Parameters.Add("iQTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QTYPESLNO"


            oParameter = oCommand.Parameters.Add("iPAPERQNO", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PAPERQNO"

            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            oParameter = oCommand.Parameters.Add("iPARENTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PARENTNO"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER8"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER9"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER10"

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oParameter = oCommand.Parameters.Add("iISPARENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ISPARENT"


            oAdapter.InsertCommand = oCommand

            '---------------------UPDATE COMMAND---------------------------------
            oParameter = UCommand.Parameters.Add("iQPCTEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPCTEMPSLNO"


            oParameter = UCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            oParameter = UCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"

            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            oParameter = UCommand.Parameters.Add("iPAPERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PAPERSLNO"

            oParameter = UCommand.Parameters.Add("iQTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QTYPESLNO"

            oParameter = UCommand.Parameters.Add("iPAPERQNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PAPERQNO"

            oParameter = UCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            oParameter = UCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            oParameter = UCommand.Parameters.Add("iPARENTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PARENTNO"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"


            oParameter = UCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER8"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER9"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER10"

            oParameter = UCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oParameter = UCommand.Parameters.Add("iISPARENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ISPARENT"


            oAdapter.UpdateCommand = UCommand

            oAdapter.Update(dsSet, "IITQP")


            If pStatus <> "" Then
                ExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, OraTrans)
            End If

            OraTrans.Commit()
            IITQpaperTEMP_Save = "SUCCESS"
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function
    Private Function ExamDefine_Status_Update(ByVal pDEXAMSLNO As Integer, ByVal pStatus As String, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oCommand = New OracleCommand
            oCommand.CommandText = "M_UPDATE_EXAMDEFINE_STATUS"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iSTATUS 2
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pStatus

            oCommand.ExecuteNonQuery()

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function IITQpaperTemp_Fetch(ByVal iDEXAMSLNO As Integer, ByVal iCopyNo As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_IITQPCTEMP_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            'ADD IN PARAMETER NAME iCOPYNO
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCopyNo

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "IITQP")

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function
    Public Function IITQpaperTemp_FetchAllCopies(ByVal pDEXAMSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_IITQPCTEMP_FETCHCOPIES"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME pCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "IITQP")

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function
    Public Function IITQpaperTEMP_SaveKeyComp(ByVal dsSet As DataSet, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String, ByVal pCOMACADEMICSLNO As Integer) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            UCommand = New OracleCommand

            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            OraTrans = oConn.BeginTransaction

            UCommand.CommandText = "M_IITQPCTEMPKEYCOMP_UPDATE"
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Connection = oConn
            UCommand.Transaction = OraTrans

            '---------------------UPDATE COMMAND---------------------------------
            oParameter = UCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER8"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER9"


            oParameter = UCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER10"


            oParameter = UCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oAdapter.UpdateCommand = UCommand

            oAdapter.Update(dsSet, "IITQP")


            If pStatus <> "" Then
                ExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, OraTrans)
            End If

            OraTrans.Commit()
            IITQpaperTEMP_SaveKeyComp = "SUCCESS"
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function
#End Region

#Region "IIT Qpaper Tailor Procedures"

    Public Function IITQpaperTailor_Save(ByVal dsSet As DataSet, ByVal intCOMACADEMICSLNO As Integer) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            UCommand = New OracleCommand

            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter


            OraTrans = oConn.BeginTransaction


            oCommand.CommandText = "M_IITQPCTAILOR_SAVE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn
            oCommand.Transaction = OraTrans

            UCommand.CommandText = "M_IITQPCTAILOR_UPDATE"
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Connection = oConn
            UCommand.Transaction = OraTrans



            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"



            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            oParameter = oCommand.Parameters.Add("iPARENTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PARENTNO"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER8"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER9"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER10"

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO

            oParameter = oCommand.Parameters.Add("iISPARENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ISPARENT"




            oAdapter.InsertCommand = oCommand

            '---------------------UPDATE COMMAND---------------------------------

            oParameter = UCommand.Parameters.Add("iQPCTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPCTSLNO"


            oParameter = UCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"



            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            oParameter = UCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            oParameter = UCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            oParameter = UCommand.Parameters.Add("iPARENTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PARENTNO"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER8"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER9"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER10"

            oParameter = UCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO

            oParameter = UCommand.Parameters.Add("iISPARENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ISPARENT"



            oAdapter.UpdateCommand = UCommand

            oAdapter.Update(dsSet, "IITQP")

            OraTrans.Commit()
            IITQpaperTailor_Save = "SUCCESS"
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function IITQpaperTailor_Delete(ByVal intQPTMTSLNO As Integer, ByVal intDEXAMSLNO As Integer, ByVal intQuesNo As Integer, ByVal intCOMACADEMICSLNO As Integer) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter


            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "M_IITQPCTAILOR_DELETE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            'ADD IN PARAMETER intQPTMTSLNO
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intQPTMTSLNO

            'ADD IN PARAMETER intDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intDEXAMSLNO

            'ADD IN PARAMETER intQuesNo
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intQuesNo

            'ADD IN PARAMETER intCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO


            oCommand.ExecuteNonQuery()

            OraTrans.Commit()
            IITQpaperTailor_Delete = "SUCCESS"

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function
    Public Function IITQpaperTailor_Fetch(ByVal intQPTMTSLNO As Integer, ByVal intDEXAMSLNO As Integer, ByVal intCOMACADEMICSLNO As Integer, ByVal IDs As DataSet) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter


            oCommand.CommandText = "M_IITQPCTAILOR_FETCH"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intQPTMTSLNO

            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intDEXAMSLNO

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO

            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(IDs, "IITQP")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return IDs

    End Function
#End Region

#Region "IIT Qpaper Upload Table Procedures"
    Public Function IITQpaperUpload_Fetch(ByVal iDEXAMSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_IITQPCUPLOAD_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "IITQP")

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function
    Public Function IITQpaperUpload_Save(ByVal dsSet As DataSet, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String, ByVal pCOMACADEMICSLNO As Integer) As String
        'saves the data set records into upload table EXAM_IITQPAPER_UPLOAD_DT AND DELETES RECORD FROM TEMP TABLE 

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            OraTrans = oConn.BeginTransaction()

            If Not IsNothing(dsSet) Then
                If Not IsNothing(dsSet.Tables("IITQP")) AndAlso dsSet.Tables("IITQP").Rows.Count > 0 Then
                    oAdapter = New OracleDataAdapter
                    oCommand = New OracleCommand

                    oCommand.CommandText = "M_IITQPCUPLOAD_SAVE"
                    oCommand.Connection = oConn
                    oCommand.CommandType = CommandType.StoredProcedure
                    oCommand.Transaction = OraTrans


                    oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "QPTMTSLNO"

                    oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "DEXAMSLNO"


                    oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "QUESTIONNO"

                    oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "SUBJECTSLNO"


                    oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "TRACKSLNO"


                    oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "TOPICSLNO"

                    oParameter = oCommand.Parameters.Add("iPAPERSLNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "PAPERSLNO"

                    oParameter = oCommand.Parameters.Add("iPAPERQNO", OracleType.VarChar, 5)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "PAPERQNO"

                    oParameter = oCommand.Parameters.Add("iQTYPESLNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "QTYPESLNO"

                    oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTMARK"

                    oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "NEGATIVEMARK"

                    oParameter = oCommand.Parameters.Add("iPARENTNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "PARENTNO"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER1"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER2"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER3"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER4"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER5"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER6"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER7"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER8"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER9"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER10"

                    oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.Value = pCOMACADEMICSLNO

                    oParameter = oCommand.Parameters.Add("iISPARENT", OracleType.VarChar, 20)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "ISPARENT"


                    oAdapter.InsertCommand = oCommand
                    oAdapter.Update(dsSet, "IITQP")

                    ExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, OraTrans)
                Else
                    ExamDefine_Status_Update(pDEXAMSLNO, "RESULTSCOMPARIED", oConn, OraTrans)
                End If
            End If

            OraTrans.Commit()
            IITQpaperUpload_Save = "SUCCESS"
        Catch ORAEX As OracleException
            OraTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function IITQpaperUpload_Delete(ByVal pDEXAMSLNO As Integer, ByVal pStatus As String, ByVal pCOMACADEMICSLNO As Integer) As String
        'Delete from temporary table  and upload final table
        'EXAM_IITQPAPER_TEMP_DT,EXAM_IITQPAPER_UPLOAD_DT 

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oCommand = New OracleCommand

            OraTrans = oConn.BeginTransaction()


            oCommand.Transaction = OraTrans

            oCommand.CommandText = "M_IITQPCUPLOAD_DELETE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            'ADD IN PARAMETER pDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER pCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO


            oCommand.ExecuteNonQuery()

            'Update status of Define Table
            ExamDefine_Status_Update(pDEXAMSLNO, pStatus, oConn, OraTrans)

            OraTrans.Commit()
            IITQpaperUpload_Delete = "SUCCESS"


        Catch ORAEX As OracleException
            OraTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try



    End Function
#End Region

#Region " EAM/IIT FINALKEY CORRECTIONS UPDATE"

    Public Function FINALKEYCORRECTIONS(ByVal iDexamSlno As Integer, ByVal EamorIit As Integer, ByVal DS As DataSet) As String
        'EXAM_IITQPAPER_UPLOAD_DT,EXAM_QPT_UPLOAD_DT,EXAM_DFINEEXAM
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oCommand = New OracleCommand

            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            OraTrans = oConn.BeginTransaction()

            'For V As Integer = 0 To DS.Tables(0).Rows.Count - 1
            '    Dim Vfkey As String
            '    Dim ArrMt As New ArrayList
            '    ArrMt.Add(DS.Tables(0).Rows(V).Item(0))
            '    ArrMt.Add(DS.Tables(0).Rows(V).Item(1).ToString)
            '    ArrMt.Add(DS.Tables(0).Rows(V).Item(2).ToString)
            '    ArrMt.Add(DS.Tables(0).Rows(V).Item(3).ToString)
            '    ArrMt.Add(DS.Tables(0).Rows(V).Item(4).ToString)
            '    ArrMt.Add(DS.Tables(0).Rows(V).Item(5).ToString)
            '    ArrMt.Add(DS.Tables(0).Rows(V).Item(6).ToString)
            '    For k As Integer = 1 To 6
            '        Vfkey += ArrMt(k)
            '    Next
            '    ArrMt.Add(Vfkey)

            oCommand.CommandText = "EXAM_FINALKEY_CORRECTIONS"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn
            oCommand.Transaction = OraTrans

            oParameter = oCommand.Parameters.Add("IOBJEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDexamSlno

            oParameter = oCommand.Parameters.Add("IEAMORIIT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EamorIit

            oParameter = oCommand.Parameters.Add("IOBJQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            oParameter = oCommand.Parameters.Add("IOBJKEY1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            oParameter = oCommand.Parameters.Add("IOBJKEY2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            oParameter = oCommand.Parameters.Add("IOBJKEY3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            oParameter = oCommand.Parameters.Add("IOBJKEY4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            oParameter = oCommand.Parameters.Add("IOBJKEY5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            oParameter = oCommand.Parameters.Add("IOBJKEY6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            oParameter = oCommand.Parameters.Add("IOBJFKEY", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "OBJFKEY"

            oAdapter.UpdateCommand = oCommand
            oAdapter.Update(DS, "Table")

            OraTrans.Commit()

            Return " KeyCorrection Updated Successfully..!"

        Catch ex As Exception
            Return " Error in Updation Contact Administrator..!"
        End Try
    End Function

    Public Function FINALKEYCORRECTIONS1(ByVal iDexamSlno As Integer, ByVal EamorIit As Integer, ByVal DS As DataSet) As String
        'EXAM_IITQPAPER_UPLOAD_DT,EXAM_QPT_UPLOAD_DT,EXAM_DFINEEXAM
        Try

            For V As Integer = 0 To DS.Tables(0).Rows.Count - 1

                ObjConn = New Connection
                oConn = ObjConn.GetConnection
                oCommand = New OracleCommand


                'OraTrans = oConn.BeginTransaction()

                oCommand.CommandText = "EXAM_FINALKEY_CORRECTIONS"
                oCommand.CommandType = CommandType.StoredProcedure
                oCommand.Connection = oConn
                'oCommand.Transaction = OraTrans

                oParameter = New OracleParameter
                oAdapter = New OracleDataAdapter

                Dim Vfkey As String = ""
                Dim ArrMt As New ArrayList
                ArrMt.Add(DS.Tables(0).Rows(V).Item(0))
                ArrMt.Add(DS.Tables(0).Rows(V).Item(1).ToString)
                ArrMt.Add(DS.Tables(0).Rows(V).Item(2).ToString)
                ArrMt.Add(DS.Tables(0).Rows(V).Item(3).ToString)
                ArrMt.Add(DS.Tables(0).Rows(V).Item(4).ToString)
                ArrMt.Add(DS.Tables(0).Rows(V).Item(5).ToString)
                ArrMt.Add(DS.Tables(0).Rows(V).Item(6).ToString)
                For k As Integer = 1 To 6
                    Vfkey += ArrMt(k)
                Next
                ArrMt.Add(Vfkey)

                oParameter = oCommand.Parameters.Add("IOBJEXAMSLNO", OracleType.Number)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = iDexamSlno

                oParameter = oCommand.Parameters.Add("IEAMORIIT", OracleType.Number)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = EamorIit

                oParameter = oCommand.Parameters.Add("IOBJQUESTIONNO", OracleType.Number)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = ArrMt(0)

                oParameter = oCommand.Parameters.Add("IOBJKEY1", OracleType.VarChar, 2)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = ArrMt(1)

                oParameter = oCommand.Parameters.Add("IOBJKEY2", OracleType.VarChar, 2)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = ArrMt(2)

                oParameter = oCommand.Parameters.Add("IOBJKEY3", OracleType.VarChar, 2)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = ArrMt(3)

                oParameter = oCommand.Parameters.Add("IOBJKEY4", OracleType.VarChar, 2)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = ArrMt(4)

                oParameter = oCommand.Parameters.Add("IOBJKEY5", OracleType.VarChar, 2)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = ArrMt(5)

                oParameter = oCommand.Parameters.Add("IOBJKEY6", OracleType.VarChar, 2)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = ArrMt(6)

                oParameter = oCommand.Parameters.Add("IOBJFKEY", OracleType.VarChar, 20)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = ArrMt(7)

                oCommand.ExecuteNonQuery()
            Next
            'OraTrans.Commit()

            Return " KeyCorrection Updated Successfully..!"

        Catch ex As Exception
            Return " Error in Updation Contact Administrator..!"
        End Try
    End Function


#End Region ' Written By Venu on 12.Sep.11 

#Region "STAFF QPAPER CREATION USE CASE PROCEDURES"

#Region "STAFF Qpaper Delete"

    Public Function Staff_Qpaper_Delete(ByVal intQPTMTSLNO As Integer, ByVal intQuesNo As Integer, ByVal intCOMACADEMICSLNO As Integer) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter


            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans
            'M_IITQPC_DELETE
            oCommand.CommandText = "STAFF_QPC_DELETE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            'ADD IN PARAMETER intQPTMTSLNO
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intQPTMTSLNO

            'ADD IN PARAMETER intQuesNo
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intQuesNo

            'ADD IN PARAMETER intCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO


            oCommand.ExecuteNonQuery()

            OraTrans.Commit()
            Return "SUCCESS"

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region "STAFF Qpaper Fetch"

    Public Function Staff_Qpaper_Fetch(ByVal intQPTMTSLNO As Integer, ByVal intCOMACADEMICSLNO As Integer, ByVal IDs As DataSet) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            'M_IITQPC_FETCH()

            oCommand.CommandText = "STAFF_QPC_FETCH"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intQPTMTSLNO

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO

            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(IDs, "IITQP")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return IDs

    End Function
#End Region

#Region "Staff Qpaper Save/Update"

    Public Function Staff_Qpaper_Save(ByVal dsSet As DataSet, ByVal intCOMACADEMICSLNO As Integer) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            UCommand = New OracleCommand

            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter


            OraTrans = oConn.BeginTransaction

            'M_IITQPC_SAVE
            oCommand.CommandText = "STAFF_QPC_SAVE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn
            oCommand.Transaction = OraTrans

            'M_IITQPC_UPDATE
            UCommand.CommandText = "STAFF_QPC_UPDATE"
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Connection = oConn
            UCommand.Transaction = OraTrans



            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"



            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            oParameter = oCommand.Parameters.Add("iPARENTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PARENTNO"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER8"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER9"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER10"



            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO

            oParameter = oCommand.Parameters.Add("iISPARENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ISPARENT"


            oAdapter.InsertCommand = oCommand

            '---------------------UPDATE COMMAND---------------------------------

            oParameter = UCommand.Parameters.Add("iQPCSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPCSLNO"


            oParameter = UCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"



            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            oParameter = UCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            oParameter = UCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            oParameter = UCommand.Parameters.Add("iPARENTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PARENTNO"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER8"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER9"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER10"

            oParameter = UCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO

            oParameter = UCommand.Parameters.Add("iISPARENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ISPARENT"



            oAdapter.UpdateCommand = UCommand

            oAdapter.Update(dsSet, "IITQP")

            OraTrans.Commit()
            Return "SUCCESS"

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function
#End Region

#End Region

#Region "STAFF Temp Table for Key Entry FETCH/SAVE"

    Public Function Staff_QpaperTEMP_Save(ByVal dsSet As DataSet, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String, ByVal pCOMACADEMICSLNO As Integer) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            UCommand = New OracleCommand

            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter


            OraTrans = oConn.BeginTransaction

            'M_IITQPCTEMP_SAVE
            oCommand.CommandText = "STAFF_QPCTEMP_SAVE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn
            oCommand.Transaction = OraTrans

            'M_IITQPCTEMP_UPDATE
            UCommand.CommandText = "STAFF_QPCTEMP_UPDATE"
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Connection = oConn
            UCommand.Transaction = OraTrans



            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"

            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"



            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            oParameter = oCommand.Parameters.Add("iPARENTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PARENTNO"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER8"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER9"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER10"

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oParameter = oCommand.Parameters.Add("iISPARENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ISPARENT"


            oAdapter.InsertCommand = oCommand

            '---------------------UPDATE COMMAND---------------------------------
            oParameter = UCommand.Parameters.Add("iQPCTEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPCTEMPSLNO"


            oParameter = UCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            oParameter = UCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"

            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            oParameter = UCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            oParameter = UCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            oParameter = UCommand.Parameters.Add("iPARENTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PARENTNO"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"


            oParameter = UCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER8"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER9"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER10"

            oParameter = UCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oParameter = UCommand.Parameters.Add("iISPARENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ISPARENT"


            oAdapter.UpdateCommand = UCommand

            oAdapter.Update(dsSet, "IITQP")


            If pStatus <> "" Then
                Staff_ED_Status_Update(pDEXAMSLNO, pStatus, oConn, OraTrans)
            End If

            OraTrans.Commit()
            Return "SUCCESS"
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Private Function Staff_ED_Status_Update(ByVal pDEXAMSLNO As Integer, ByVal pStatus As String, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oCommand = New OracleCommand
            'M_UPDATE_EXAMDEFINE_STATUS
            oCommand.CommandText = "STAFF_EDSTATUS_UPDATE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME iSTATUS 2
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pStatus

            oCommand.ExecuteNonQuery()

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function Staff_QpaperTemp_Fetch(ByVal iDEXAMSLNO As Integer, ByVal iCopyNo As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            'M_IITQPCTEMP_FETCH
            oCommand.CommandText = "STAFF_QPCTEMP_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            'ADD IN PARAMETER NAME iCOPYNO
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCopyNo

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "IITQP")

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function

    Public Function Staff_QpaperTemp_FetchAllCopies(ByVal pDEXAMSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            'M_IITQPCTEMP_FETCHCOPIES
            oCommand.CommandText = "STAFF_QPCTEMP_FETCHCOPIES"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME pCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "IITQP")

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function Staff_QpaperTEMP_SaveKeyComp(ByVal dsSet As DataSet, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String, ByVal pCOMACADEMICSLNO As Integer) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            UCommand = New OracleCommand

            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            OraTrans = oConn.BeginTransaction
            'M_IITQPCTEMPKEYCOMP_UPDATE
            UCommand.CommandText = "STAFF_QPCTEMPKEYCOMP_UPDATE"
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Connection = oConn
            UCommand.Transaction = OraTrans

            '---------------------UPDATE COMMAND---------------------------------
            oParameter = UCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER8"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER9"


            oParameter = UCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER10"


            oParameter = UCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oAdapter.UpdateCommand = UCommand

            oAdapter.Update(dsSet, "IITQP")


            If pStatus <> "" Then
                Staff_ED_Status_Update(pDEXAMSLNO, pStatus, oConn, OraTrans)
            End If

            OraTrans.Commit()

            Return "SUCCESS"

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

#End Region

#Region "FETCH FROM STAFF TAILOR TABLE"

    Public Function Staff_QPTTailor_Fetch(ByVal pDEXAMSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            'M_IITQPTTAILOR_FETCH
            oCommand.CommandText = "STAFF_QPTTAILOR_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME pCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function
#End Region

#Region " StaffCopies Fetch"

    Public Function Staff_QPTCopies_Fetch(ByVal pDEXAMSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            'M_IITCOPIES_SELECT
            oCommand.CommandText = "STAFF_COPIES_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER NAME pCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function
#End Region

#Region " Staff Qpaper Upload Table Procedures"

    Public Function Staff_QpaperUpload_Fetch(ByVal iDEXAMSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            'M_IITQPCUPLOAD_FETCH
            oCommand.CommandText = "STAFF_QPCUPLOAD_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "IITQP")

        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function
    Public Function Staff_QpaperUpload_Save(ByVal dsSet As DataSet, ByVal pDEXAMSLNO As Integer, ByVal pStatus As String, ByVal pCOMACADEMICSLNO As Integer) As String
        'saves the data set records into upload table EXAM_IITQPAPER_UPLOAD_DT AND DELETES RECORD FROM TEMP TABLE 

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            OraTrans = oConn.BeginTransaction()

            If Not IsNothing(dsSet) Then
                If Not IsNothing(dsSet.Tables("IITQP")) AndAlso dsSet.Tables("IITQP").Rows.Count > 0 Then
                    oAdapter = New OracleDataAdapter
                    oCommand = New OracleCommand

                    'M_IITQPCUPLOAD_SAVE
                    oCommand.CommandText = "STAFF_QPCUPLOAD_SAVE"
                    oCommand.Connection = oConn
                    oCommand.CommandType = CommandType.StoredProcedure
                    oCommand.Transaction = OraTrans


                    oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "QPTMTSLNO"

                    oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "DEXAMSLNO"


                    oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "QUESTIONNO"

                    oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "SUBJECTSLNO"


                    oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "TRACKSLNO"


                    oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "TOPICSLNO"


                    oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTMARK"

                    oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "NEGATIVEMARK"

                    oParameter = oCommand.Parameters.Add("iPARENTNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "PARENTNO"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER1"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER2"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER3"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER4"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER5"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER6"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER7"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER8"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER9"

                    oParameter = oCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "CORRECTANSWER10"

                    oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.Value = pCOMACADEMICSLNO

                    oParameter = oCommand.Parameters.Add("iISPARENT", OracleType.VarChar, 20)
                    oParameter.Direction = ParameterDirection.Input
                    oParameter.SourceColumn = "ISPARENT"


                    oAdapter.InsertCommand = oCommand
                    oAdapter.Update(dsSet, "IITQP")

                    Staff_ED_Status_Update(pDEXAMSLNO, pStatus, oConn, OraTrans)
                Else
                    Staff_ED_Status_Update(pDEXAMSLNO, "RESULTSCOMPARIED", oConn, OraTrans)
                End If
            End If

            OraTrans.Commit()
            Return "SUCCESS"
        Catch ORAEX As OracleException
            OraTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Staff_QpaperUpload_Delete(ByVal pDEXAMSLNO As Integer, ByVal pStatus As String, ByVal pCOMACADEMICSLNO As Integer) As String
        'Delete from temporary table  and upload final table
        'STAFF_QPAPER_TEMP_DT,STAFF_QPAPER_UPLOAD_DT 

        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oCommand = New OracleCommand

            OraTrans = oConn.BeginTransaction()


            oCommand.Transaction = OraTrans
            'M_IITQPCUPLOAD_DELETE
            oCommand.CommandText = "STAFF_QPCUPLOAD_DELETE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            'ADD IN PARAMETER pDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            'ADD IN PARAMETER pCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO


            oCommand.ExecuteNonQuery()

            'Update status of Define Table
            Staff_ED_Status_Update(pDEXAMSLNO, pStatus, oConn, OraTrans)

            OraTrans.Commit()
            Return "SUCCESS"


        Catch ORAEX As OracleException
            OraTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try



    End Function
#End Region

#Region " Staff Qpaper Tailor Procedures"

    Public Function Staff_QpaperTailor_Save(ByVal dsSet As DataSet, ByVal intCOMACADEMICSLNO As Integer) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            UCommand = New OracleCommand

            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter


            OraTrans = oConn.BeginTransaction

            'M_IITQPCTAILOR_SAVE
            oCommand.CommandText = "STAFF_QPCTAILOR_SAVE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn
            oCommand.Transaction = OraTrans

            'M_IITQPCTAILOR_UPDATE
            UCommand.CommandText = "STAFF_QPCTAILOR_UPDATE"
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Connection = oConn
            UCommand.Transaction = OraTrans



            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"



            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            oParameter = oCommand.Parameters.Add("iPARENTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PARENTNO"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER8"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER9"

            oParameter = oCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER10"

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO

            oParameter = oCommand.Parameters.Add("iISPARENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ISPARENT"




            oAdapter.InsertCommand = oCommand

            '---------------------UPDATE COMMAND---------------------------------

            oParameter = UCommand.Parameters.Add("iQPCTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPCTSLNO"


            oParameter = UCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"



            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            oParameter = UCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            oParameter = UCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            oParameter = UCommand.Parameters.Add("iPARENTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PARENTNO"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER1", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER1"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER2", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER2"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER3", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER3"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER4", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER4"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER5", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER5"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER6", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER6"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER7", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER7"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER8", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER8"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER9", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER9"

            oParameter = UCommand.Parameters.Add("iCORRECTANSWER10", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER10"

            oParameter = UCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO

            oParameter = UCommand.Parameters.Add("iISPARENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ISPARENT"



            oAdapter.UpdateCommand = UCommand

            oAdapter.Update(dsSet, "IITQP")

            OraTrans.Commit()

            Return "SUCCESS"

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function Staff_QpaperTailor_Delete(ByVal intQPTMTSLNO As Integer, ByVal intDEXAMSLNO As Integer, ByVal intQuesNo As Integer, ByVal intCOMACADEMICSLNO As Integer) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter


            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            'M_IITQPCTAILOR_DELETE
            oCommand.CommandText = "STAFF_QPCTAILOR_DELETE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            'ADD IN PARAMETER intQPTMTSLNO
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intQPTMTSLNO

            'ADD IN PARAMETER intDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intDEXAMSLNO

            'ADD IN PARAMETER intQuesNo
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intQuesNo

            'ADD IN PARAMETER intCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO


            oCommand.ExecuteNonQuery()

            OraTrans.Commit()

            Return "SUCCESS"

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Staff_QpaperTailor_Fetch(ByVal intQPTMTSLNO As Integer, ByVal intDEXAMSLNO As Integer, ByVal intCOMACADEMICSLNO As Integer, ByVal IDs As DataSet) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            'M_IITQPCTAILOR_FETCH
            oCommand.CommandText = "STAFF_QPCTAILOR_FETCH"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intQPTMTSLNO

            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intDEXAMSLNO

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = intCOMACADEMICSLNO

            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(IDs, "IITQP")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return IDs

    End Function
#End Region
End Class
