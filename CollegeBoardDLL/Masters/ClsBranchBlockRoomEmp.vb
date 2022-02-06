'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating Branch Block Room Emp
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 11-OCT-2006
'   FINAL BASELINE DATE               : 11-OCT-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsBranchBlockRoomEmp

#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As New OracleClient.OracleCommand
    Private oParameter As New OracleClient.OracleParameter
    Private oAdapter As New OracleClient.OracleDataAdapter
    Private OraTrans As OracleTransaction
    Dim ds As New Data.DataSet
    Private ObjConn As Connection

#End Region

#Region "Fill Methods"


    Public Function BranchBlockRoomEmp_Fill(ByVal iCode As Integer, ByVal From As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet


            If From = "BranchHostelEmp" Then
                oCommand.CommandText = "M_BRANWISEHOSTEL_FETCH"
            ElseIf From = "HostelBlockEmp" Then
                oCommand.CommandText = "M_HOSTELWISEBLOCK_FETCH"
            ElseIf From = "BlockRoomEmp" Then
                oCommand.CommandText = "M_BLOCKWISEROOM_FETCH"
            End If

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCode

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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

#Region "Single Mode Methods"


    Public Function BranchBlockRoomEmp_Code(ByVal iCode As Integer, ByVal From As String) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "BranchHostelEmp" Then
                oCommand.CommandText = "M_BRANCHHOSTELEMP_FETCH"
            ElseIf From = "HostelBlockEmp" Then
                oCommand.CommandText = "M_HOSTELBLOCKEMP_FETCH"
            ElseIf From = "BlockRoomEmp" Then
                oCommand.CommandText = "M_BLOCKROOMEMP_FETCH"
            End If

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCode

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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


    Public Function BranchBlockRoomEmp_Update(ByVal PKeySlno As Integer, ByVal iiSlno As Integer, ByVal iEmpSlno As Integer, ByVal iDesc As String, ByVal From As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "BranchHostelEmp" Then
                oCommand.CommandText = "F_BRANCHHOSTELEMP_UPDATE"
            ElseIf From = "HostelBlockEmp" Then
                oCommand.CommandText = "F_HOSTELBLOCKEMP_UPDATE"
            ElseIf From = "BlockRoomEmp" Then
                oCommand.CommandText = "F_BLOCKROOMEMP_UPDATE"
            End If

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS Primary Key Slno
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PKeySlno

            'ADD IN PARAMETER NAME AS Hostelslno,BlockSlno,RoomSlno
            oParameter = oCommand.Parameters.Add("iiSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iiSlno


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEmpSlno

            'ADD IN PARAMETER NAME DESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDesc

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function


    Public Function BranchBlockRoomEmp_Insert(ByVal iiSlno As Integer, ByVal iEmpslno As Integer, ByVal iDescription As String, ByVal From As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "BranchHostelEmp" Then
                oCommand.CommandText = "F_BRANCHHOSTELEMP_INSERT"
            ElseIf From = "HostelBlockEmp" Then
                oCommand.CommandText = "F_HOSTELBLOCKEMP_INSERT"
            ElseIf From = "BlockRoomEmp" Then
                oCommand.CommandText = "F_BLOCKROOMEMP_INSERT"
            End If

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME AS HostelSlno,BlockSlno,Room Slno
            oParameter = oCommand.Parameters.Add("iiSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iiSlno


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEmpslno


            'ADD IN PARAMETER NAME DESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDescription

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function


    Public Function BranchBlockRoomEmp_Delete(ByVal KeySlNo As String, ByVal From As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "BranchHostelEmp" Then
                oCommand.CommandText = "F_BRANCHHOSTELEMP_DELETE"
            ElseIf From = "HostelBlockEmp" Then
                oCommand.CommandText = "F_HOSTELBLOCKEMP_DELETE"
            ElseIf From = "BlockRoomEmp" Then
                oCommand.CommandText = "F_BLOCKROOMEMP_DELETE"
            End If

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME as slno
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = KeySlNo

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function


#End Region

#Region "Batch Mode Methods"


    Public Function BranchBlockRoomEmp_BatchInsert(ByRef PDataSet As DataSet, ByVal From As String) As String

        Dim adap As New OracleDataAdapter
        Dim Cmd As New OracleClient.OracleCommand
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()



            If From = "BranchHostelEmp" Then
                Cmd.CommandText = "M_BRANCHHOSTELEMP_BATCHINSERT"
            ElseIf From = "HostelBlockEmp" Then
                Cmd.CommandText = "M_HOSTELBLOCKEMP_BATCHINSERT"
            ElseIf From = "BlockRoomEmp" Then
                Cmd.CommandText = "M_BLOCKROOMEMP_BATCHINSERT"
            End If


            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLNO"

            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EMPSLNO"


            'ADD IN PARAMETER NAME AS DESCRIPTION
            oParameter = Cmd.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            adap.InsertCommand = Cmd
            adap.Update(PDataSet, "BranchBlockRoomEmp")

            OraTrans.Commit()

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return 1
    End Function



#End Region

#Region "Hostel InCharge"

    Public Function HostelInChargeSave(ByVal DsEBHE As DataSet) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()



            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            iCommand.Transaction = OraTrans
            iCommand.CommandText = "P_EBHINCHARGE_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            uCommand.Transaction = OraTrans
            uCommand.CommandText = "P_EBHINCHARGE_UPDATE"
            uCommand.Connection = oConn
            uCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME AS iEXAMBRANCHSLNO
            oParameter = iCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"


            'ADD IN PARAMETER NAME AS iBRANHOSTELSLNO
            oParameter = iCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANHOSTELSLNO"

            'ADD IN PARAMETER NAME AS iEMPSLNO
            oParameter = iCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EMPSLNO"

            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = iCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.InsertCommand = iCommand


            'ADD IN PARAMETER NAME AS iEBHEMPSLNO
            oParameter = uCommand.Parameters.Add("iEBHEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EBHEMPSLNO"

            'ADD IN PARAMETER NAME AS HostelSlno,BlockSlno,Room Slno
            oParameter = uCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"


            'ADD IN PARAMETER NAME AS iBRANHOSTELSLNO
            oParameter = uCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANHOSTELSLNO"

            'ADD IN PARAMETER NAME AS iEMPSLNO
            oParameter = uCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EMPSLNO"

            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsEBHE, "EBHE")
            OraTrans.Commit()
            Return "0-Record Saved"
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    Public Function GetHostelInCharge(ByVal StrSql As String) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet



            oCommand.CommandText = "P_EBHINCHARGE_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStrSQL", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StrSql

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand

            oAdapter.Fill(ds, "EBHE")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function GetHostelInChargeDetails(ByVal iEBHEMPSLNO As Long) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "P_EBHINCHARGEDETAILS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iEBHEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEBHEMPSLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand

            oAdapter.Fill(ds, "EBHE")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function DeleteHostelIncharge(ByVal KeySlNo As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            OraTrans = oConn.BeginTransaction()

            oCommand.Transaction = OraTrans
            oCommand.CommandText = "F_BRANCHHOSTELEMP_DELETE"

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME as slno
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = KeySlNo

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

            OraTrans.Commit()

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function

#End Region

End Class
