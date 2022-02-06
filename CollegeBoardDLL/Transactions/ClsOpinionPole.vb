'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS EXAMINATION 2.0
'   OBJECTIVE                         : THIS IS MIDDLE LAYER FOR Opinion Pole
'   ACTIVITY                          : ALL
'   AUTHOR                            : A.SURENDAR REDDY
'   INITIAL BASELINE DATE             : 06-08-2008
'   FINAL BASELINE DATE               : 06-08-2008
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration
Public Class ClsOpinionPole

#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private uCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ds As New Data.DataSet
    Private oTrans As OracleTransaction
    Private ObjConn As Connection
    Private ReturnStr As Integer

#End Region

    Public Sub OpinionPole_Save(ByVal Iarry As ArrayList)
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "PAYROLLNEW.P_OPINIONPOLE_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iOPNIONDATE
            oParameter = oCommand.Parameters.Add("iOPNIONDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(0)

            'ADD IN PARAMETER NAME iTRANSDATE 
            oParameter = oCommand.Parameters.Add("iTRANSDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(1)


            'ADD IN PARAMETER NAME iEMPSLNO  
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(2)


            'ADD IN PARAMETER NAME iUNIQUENO  
            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(3)

            'ADD IN PARAMETER NAME iTEACHINGSLNO  
            oParameter = oCommand.Parameters.Add("iTEACHINGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(4)

            'ADD IN PARAMETER NAME iPOOR  
            oParameter = oCommand.Parameters.Add("iPOOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(5)

            'ADD IN PARAMETER NAME iSVERAGE  
            oParameter = oCommand.Parameters.Add("iSVERAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(6)

            'ADD IN PARAMETER NAME iGOOD  
            oParameter = oCommand.Parameters.Add("iGOOD", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(7)

            'ADD IN PARAMETER NAME iEXCELLENT  
            oParameter = oCommand.Parameters.Add("iEXCELLENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(8)

            'ADD IN PARAMETER NAME iTOTAL  
            oParameter = oCommand.Parameters.Add("iTOTAL", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(9)

            'ADD IN PARAMETER NAME iUSERSLNO  
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(10)

            'ADD IN PARAMETER NAME iPOLLBY  
            oParameter = oCommand.Parameters.Add("iPOLLBY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(11)

            oCommand.ExecuteNonQuery()



        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub OpinionPole_UpDate(ByVal Iarry As ArrayList)
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "PAYROLLNEW.P_OPINIONPOLE_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iPOLESLNO
            oParameter = oCommand.Parameters.Add("iPOLESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(0)

            'ADD IN PARAMETER NAME iOPNIONDATE
            oParameter = oCommand.Parameters.Add("iOPNIONDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(1)

            'ADD IN PARAMETER NAME iTRANSDATE 
            oParameter = oCommand.Parameters.Add("iTRANSDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(2)


            'ADD IN PARAMETER NAME iEMPSLNO  
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(3)


            'ADD IN PARAMETER NAME iUNIQUENO  
            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(4)

            'ADD IN PARAMETER NAME iTEACHINGSLNO  
            oParameter = oCommand.Parameters.Add("iTEACHINGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(5)

            'ADD IN PARAMETER NAME iPOOR  
            oParameter = oCommand.Parameters.Add("iPOOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(6)

            'ADD IN PARAMETER NAME iSVERAGE  
            oParameter = oCommand.Parameters.Add("iSVERAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(7)

            'ADD IN PARAMETER NAME iGOOD  
            oParameter = oCommand.Parameters.Add("iGOOD", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(8)

            'ADD IN PARAMETER NAME iEXCELLENT  
            oParameter = oCommand.Parameters.Add("iEXCELLENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(9)

            'ADD IN PARAMETER NAME iTOTAL  
            oParameter = oCommand.Parameters.Add("iTOTAL", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(10)

            'ADD IN PARAMETER NAME iUSERSLNO  
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(11)


            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub EmpTeachingHours_Save(ByVal Iarry As ArrayList)
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "PAYROLLNEW.F_EMPTEACHCOUNSEING_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure




            'ADD IN PARAMETER NAME iEMPSLNO  
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(0)


            'ADD IN PARAMETER NAME iTEACHINGHOURS  
            oParameter = oCommand.Parameters.Add("iTEACHINGHOURS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(1)

            'ADD IN PARAMETER NAME iCOUNSELINGHOURS  
            oParameter = oCommand.Parameters.Add("iCOUNSELINGHOURS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(2)


            oCommand.ExecuteNonQuery()



        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub SecOpinionPole_Save(ByVal Iarry As ArrayList)
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "PAYROLLNEW.P_OPINIONPOLE_SEC_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iOPNIONDATE
            oParameter = oCommand.Parameters.Add("iOPNIONDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(0)

            'ADD IN PARAMETER NAME iTRANSDATE 
            oParameter = oCommand.Parameters.Add("iTRANSDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(1)

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO  
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(2)

            'ADD IN PARAMETER NAME iCOURSESLNO  
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(3)

            'ADD IN PARAMETER NAME iGROUPSLNO  
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(4)

            'ADD IN PARAMETER NAME iBATCHSLNO  
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(5)

            'ADD IN PARAMETER NAME iSECTIONSLNO  
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(6)

            'ADD IN PARAMETER NAME iEMPSLNO  
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(7)


            'ADD IN PARAMETER NAME iUNIQUENO  
            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(8)

            'ADD IN PARAMETER NAME iTEACHINGSLNO  
            oParameter = oCommand.Parameters.Add("iTEACHINGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(9)

            'ADD IN PARAMETER NAME iPOOR  
            oParameter = oCommand.Parameters.Add("iPOOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(10)

            'ADD IN PARAMETER NAME iSVERAGE  
            oParameter = oCommand.Parameters.Add("iSVERAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(11)

            'ADD IN PARAMETER NAME iGOOD  
            oParameter = oCommand.Parameters.Add("iGOOD", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(12)

            'ADD IN PARAMETER NAME iEXCELLENT  
            oParameter = oCommand.Parameters.Add("iEXCELLENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(13)

            'ADD IN PARAMETER NAME iTOTAL  
            oParameter = oCommand.Parameters.Add("iTOTAL", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(14)

            'ADD IN PARAMETER NAME iUSERSLNO  
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(15)

            'ADD IN PARAMETER NAME iPOLLBY  
            oParameter = oCommand.Parameters.Add("iPOLLBY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(16)

            oCommand.ExecuteNonQuery()



        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub SecOpinionPole_UpDate(ByVal Iarry As ArrayList)
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "PAYROLLNEW.P_OPINIONPOLE_SEC_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iPOLESLNO
            oParameter = oCommand.Parameters.Add("iPOLESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(0)

            'ADD IN PARAMETER NAME iOPNIONDATE
            oParameter = oCommand.Parameters.Add("iOPNIONDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(1)

            'ADD IN PARAMETER NAME iTRANSDATE 
            oParameter = oCommand.Parameters.Add("iTRANSDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(2)



            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO  
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(3)

            'ADD IN PARAMETER NAME iCOURSESLNO  
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(4)

            'ADD IN PARAMETER NAME iGROUPSLNO  
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(5)

            'ADD IN PARAMETER NAME iBATCHSLNO  
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(6)

            'ADD IN PARAMETER NAME iSECTIONSLNO  
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(7)


            'ADD IN PARAMETER NAME iEMPSLNO  
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(8)


            'ADD IN PARAMETER NAME iUNIQUENO  
            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(9)

            'ADD IN PARAMETER NAME iTEACHINGSLNO  
            oParameter = oCommand.Parameters.Add("iTEACHINGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(10)

            'ADD IN PARAMETER NAME iPOOR  
            oParameter = oCommand.Parameters.Add("iPOOR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(11)

            'ADD IN PARAMETER NAME iSVERAGE  
            oParameter = oCommand.Parameters.Add("iSVERAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(12)

            'ADD IN PARAMETER NAME iGOOD  
            oParameter = oCommand.Parameters.Add("iGOOD", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(13)

            'ADD IN PARAMETER NAME iEXCELLENT  
            oParameter = oCommand.Parameters.Add("iEXCELLENT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(14)

            'ADD IN PARAMETER NAME iTOTAL  
            oParameter = oCommand.Parameters.Add("iTOTAL", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(15)

            'ADD IN PARAMETER NAME iUSERSLNO  
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(16)


            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub EmpSubMapping_Save(ByVal Iarry As ArrayList)
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAM_EMPCRSUB_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(0)

            'ADD IN PARAMETER NAME iCOURSESLNO 
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(1)


            'ADD IN PARAMETER NAME iSUBJECTSLNO  
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(2)

            'ADD IN PARAMETER NAME iEMPSLNO 
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(3)

            oCommand.ExecuteNonQuery()



        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub EmpSubMapping_UpDate(ByVal iEECSSLNO As Integer, ByVal Iarry As ArrayList)
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAM_EMPCRSUB_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iEECSSLNO
            oParameter = oCommand.Parameters.Add("iEECSSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEECSSLNO

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(0)

            'ADD IN PARAMETER NAME iCOURSESLNO 
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(1)


            'ADD IN PARAMETER NAME iSUBJECTSLNO  
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(2)

            'ADD IN PARAMETER NAME iEMPSLNO 
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Iarry(3)


            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub EmpSubMapping_Delete(ByVal EECSSLNO As Integer)
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAM_EMPCRSUB_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEECSSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EECSSLNO


            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub
End Class
