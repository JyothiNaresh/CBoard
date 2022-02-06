Imports System.Data
Imports System.Data.OracleClient
Public Class OutProcessClass

#Region " Class Variables "
    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ObjConn As Connection
    Dim Ds As New DataSet

#End Region


#Region "Process"

    Public Function isPRCRunning(ByVal pMODULENAME As String, ByVal pPROCESSNAME As String) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            'oConn.Open()
            Dim sql As String = "SELECT STATUSSLNO FROM PRC_STATUS_DT WHERE MODULENAME='" & pMODULENAME & "' AND PROCESSNAME = '" & pPROCESSNAME & "' AND PROCESSSTATUS NOT IN ( 'COMPLETED','ABNORMALABORT','NORMALABORT')"
            Dim oAdapter As New OracleDataAdapter(sql, oConn)

            oAdapter.Fill(Ds)

            Return Ds

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    Public Function RefreshStatus() As DataSet
        Try

            Dim sql As String
            Dim ds As New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            sql = "SELECT ROWNUM SLNO, S.STATUSSLNO, S.MODULENAME, S.PROCESSNAME, S.USERSLNO, U.USERID USERNAME, S.STARTTIME, S.ENDTIME, S.PROCESSEDPERCENTAGE, S.PROCESSEDROWS, S.PROCESSSTATUS, " & _
                    " TO_CHAR(TRUNC(MOD( (S.ENDTIME-S.STARTTIME) * 24,24) )) || ':' || TO_CHAR(TRUNC(MOD( (S.ENDTIME-S.STARTTIME) * 24 * 60 ,60) )) || ':' || TO_CHAR(TRUNC(MOD( (S.ENDTIME-S.STARTTIME) * 24 * 60 * 60 ,60) )) ELAPSETIME , S.PROCESSID " & _
                    " FROM PRC_STATUS_DT S, EXAM_USER_MT U WHERE S.USERSLNO = U.USERSLNO AND S.PROCESSSTATUS NOT IN ('COMPLETED','ABNORMALABORT','NORMALABORT')"

            Dim adap As New OracleDataAdapter(sql, oConn)
            adap.Fill(ds)

            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try


    End Function

    Public Function ShowStatus() As DataSet
        Try

            Dim sql As String
            Dim ds As New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            sql = "SELECT ROWNUM SLNO, S.STATUSSLNO, S.MODULENAME, S.PROCESSNAME, S.USERSLNO, U.USERID USERNAME, S.STARTTIME, S.ENDTIME, S.PROCESSEDPERCENTAGE, S.PROCESSEDROWS, S.PROCESSSTATUS, " & _
                    " TO_CHAR(TRUNC(MOD( (S.ENDTIME-S.STARTTIME) * 24,24) )) || ':' || TO_CHAR(TRUNC(MOD( (S.ENDTIME-S.STARTTIME) * 24 * 60 ,60) )) || ':' || TO_CHAR(TRUNC(MOD( (S.ENDTIME-S.STARTTIME) * 24 * 60 * 60 ,60) )) ELAPSETIME , S.PROCESSID " & _
                    " FROM PRC_STATUS_DT S, EXAM_USER_MT U WHERE S.USERSLNO = U.USERSLNO"  ' AND S.PROCESSSTATUS NOT IN ('COMPLETED','ABNORMALABORT','NORMALABORT')"

            Dim adap As New OracleDataAdapter(sql, oConn)
            adap.Fill(ds)

            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try


    End Function

    Public Function insertStatus(ByVal pModuleName As String, ByVal pProcessName As String, ByVal pCurrentTime As DateTime, ByVal MachineProcessName As String, ByVal UserSLNo As Integer) As Integer
        Try
            'Get Max Status ID
            Dim sql As String, MaxStatusID As Integer, cmd As OracleCommand

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            sql = "SELECT NVL(MAX(STATUSSLNO),0) + 1 FROM  PRC_STATUS_DT"
            cmd = New OracleCommand(sql, oConn)
            MaxStatusID = cmd.ExecuteScalar()

            'Updating Status 
            sql = "INSERT INTO PRC_STATUS_DT (STATUSSLNO, MODULENAME, PROCESSNAME, USERSLNO, STARTTIME, ENDTIME, PROCESSEDPERCENTAGE, PROCESSEDROWS, PROCESSSTATUS, STATUS) VALUES " & _
                    " (" & MaxStatusID & " ,'" & pModuleName & "','" & pProcessName & "'," & UserSLNo & ",TO_DATE('" & Format(pCurrentTime, "dd-MM-yyyy hh:mm:ss tt") & "','DD-MM-YYYY HH:MI:SS AM'),TO_DATE('" & Format(DateTime.Now, "dd-MM-yyyy hh:mm:ss tt") & "','DD-MM-YYYY HH:MI:SS AM'),0,0,'INITIATED','A')"

            cmd = New OracleCommand(sql, oConn)
            cmd.ExecuteNonQuery()


            Return MaxStatusID

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Sub UpdateStatus(ByVal pStatusID As Integer, ByVal pStatus As String)
        Try

            Dim sql As String = "UPDATE PRC_STATUS_DT SET ENDTIME = TO_DATE('" & Format(DateTime.Now, "dd-MM-yyyy hh:mm:ss tt") & "','DD-MM-YYYY HH:MI:SS AM'), PROCESSSTATUS ='" & pStatus & "'  WHERE STATUSSLNO=" & pStatusID

            Dim cmd As OracleCommand
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            cmd = New OracleCommand(sql, oConn)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Sub

#End Region

End Class
