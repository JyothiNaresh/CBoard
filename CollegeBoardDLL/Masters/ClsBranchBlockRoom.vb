'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating BCSEMP
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 11-OCT-2006
'   FINAL BASELINE DATE               : 11-OCT-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsBranchBlockRoom


#Region "class Variables"
    Private oConn As OracleClient.OracleConnection
    Private oCommand As New OracleClient.OracleCommand
    Private oParameter As New OracleClient.OracleParameter
    Private oAdapter As New OracleClient.OracleDataAdapter
    Private OraTrans As OracleTransaction
    Dim ds As New Data.DataSet
    Private ObjConn As Connection
#End Region

#Region "Single Mode Methods"


    Public Function BranchBlockRoom_Code(ByVal iCode As Integer, ByVal From As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "BranchHostel" Then
                oCommand.CommandText = "M_BRANCHHOSTEL_FETCH"
            ElseIf From = "HostelBlock" Then
                oCommand.CommandText = "M_HOSTELBLOCK_FETCH"
            ElseIf From = "BlockRoom" Then
                oCommand.CommandText = "M_BLOCKROOM_FETCH"
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

    Public Function BranchBlockRoom_Update(ByVal PKeySlno As Integer, ByVal iSlno As Integer, ByVal iName As String, ByVal iDesc As String, ByVal From As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "BranchHostel" Then
                oCommand.CommandText = "F_BRANCHHOSTEL_UPDATE"
            ElseIf From = "HostelBlock" Then
                oCommand.CommandText = "F_HOSTELBLOCK_UPDATE"
            ElseIf From = "BlockRoom" Then
                oCommand.CommandText = "F_BLOCKROOM_UPDATE"
            End If

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS Primary Key Slno
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PKeySlno

            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = oCommand.Parameters.Add("iiSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSlno

            'ADD IN PARAMETER NAME DESCRIPTION
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iName


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

    Public Function BranchBlockRoom_Insert(ByVal dsResult As DataSet, ByVal From As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "BranchHostel" Then
                oCommand.CommandText = "F_BRANCHHOSTEL_INSERT"
            ElseIf From = "HostelBlock" Then
                oCommand.CommandText = "F_HOSTELBLOCK_INSERT"
            ElseIf From = "BlockRoom" Then
                oCommand.CommandText = "F_BLOCKROOM_INSERT"
            End If

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLNO"

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NAME"


            'ADD IN PARAMETER NAME DESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"


            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue

            oAdapter.InsertCommand = oCommand

            oAdapter.Update(dsResult, "BBR")

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function


    Public Function BranchBlockRoom_Delete(ByVal PSlNo As String, ByVal From As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            If From = "BranchHostel" Then
                oCommand.CommandText = "F_BRANCHHOSTEL_DELETE"
            ElseIf From = "HostelBlock" Then
                oCommand.CommandText = "F_HOSTELBLOCK_DELETE"
            ElseIf From = "BlockRoom" Then
                oCommand.CommandText = "F_BLOCKROOM_DELETE"
            End If

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME as slno
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

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

    Public Function BranchBlockRoom_BatchInsert(ByRef PDataSet As DataSet, ByVal From As String) As String

        Dim adap As New OracleDataAdapter
        Dim Cmd As New OracleClient.OracleCommand
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()

            Cmd.Transaction = OraTrans

            If From = "BranchHostel" Then
                Cmd.CommandText = "M_BRANCHHOSTEL_BATCHINSERT"
            ElseIf From = "HostelBlock" Then
                Cmd.CommandText = "M_HOSTELBLOCK_BATCHINSERT"
            ElseIf From = "BlockRoom" Then
                Cmd.CommandText = "M_BLOCKROOM_BATCHINSERT"
            End If


            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLNO"


            'ADD IN PARAMETER AS NAME
            oParameter = Cmd.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NAME"

            'ADD IN PARAMETER NAME AS DESCRIPTION
            oParameter = Cmd.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            adap.InsertCommand = Cmd
            adap.Update(PDataSet, "BBR")

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

#Region "Direct Fill Method"

    Public Function Hostel_Fetch(ByVal PStatus As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_HOSTEL_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME IUSERID
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



    Public Function Block_Fetch(ByVal PStatus As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_BLOCK_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME IUSERID
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

#Region "Hostels"

    Public Function GetExamBranches() As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EBIdName_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
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

    Public Function HostelsSave(ByVal dsResult As DataSet) As String
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
            iCommand.CommandText = "P_EBHOSTEL_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            uCommand.Transaction = OraTrans
            uCommand.CommandText = "P_EBHOSTEL_UPDATE"
            uCommand.Connection = oConn
            uCommand.CommandType = CommandType.StoredProcedure



            ''ADD IN PARAMETER NAME AS BRANCHSLNO
            'oParameter = iCommand.Parameters.Add("iSLNO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "SLNO"

            'ADD IN PARAMETER NAME 
            oParameter = iCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"


            'ADD IN PARAMETER NAME iHOSTELNAME
            oParameter = iCommand.Parameters.Add("iHOSTELNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "HOSTELNAME"

            'ADD IN PARAMETER NAME DESCRIPTION
            oParameter = iCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.InsertCommand = iCommand


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = uCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANHOSTELSLNO"

            'ADD IN PARAMETER NAME 
            oParameter = uCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"


            'ADD IN PARAMETER NAME iHOSTELNAME
            oParameter = uCommand.Parameters.Add("iHOSTELNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "HOSTELNAME"

            'ADD IN PARAMETER NAME DESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"



            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(dsResult, "Hostels")

            OraTrans.Commit()

            Return "0-Record Saved"

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
            Return strReturn
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    Public Function GetHostel(ByVal StrSql As String) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_HOSTEL_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iStr", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StrSql

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "Hostels")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function

    Public Function GetHostelDeatails(ByVal iBRANHOSTELSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_HOSTELDETAILS_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBRANHOSTELSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "Hostels")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function DeleteHostels(ByVal iBRANHOSTELSLNO As Integer) As String
        Try
            Dim strReturn As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet


            oCommand.CommandText = "F_BRANCHHOSTEL_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME as slno
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBRANHOSTELSLNO

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

            ' Return "0-Record Deleted"
            Return strReturn

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region "Rooms"

    '<WebMethod(Description:="Featch Data")> _
    '  Public Function GetBlocks(ByVal iEXAMBRANCHSLNO As Integer, ByVal iBRANHOSTELSLNO As Integer) As DataSet

    '    Try
    '        oConn = Common.GetConnection()
    '        oConn.Open()

    '        oCommand = New OracleClient.OracleCommand
    '        oParameter = New OracleClient.OracleParameter
    '        oAdapter = New OracleClient.OracleDataAdapter
    '        ds = New Data.DataSet

    '        oCommand.CommandText = "M_HOSTEL_FETCH"
    '        oCommand.Connection = oConn
    '        oCommand.CommandType = CommandType.StoredProcedure

    '        oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
    '        oParameter.Direction = ParameterDirection.Input
    '        oParameter.Value = iEXAMBRANCHSLNO

    '        oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
    '        oParameter.Direction = ParameterDirection.Input
    '        oParameter.Value = iBRANHOSTELSLNO

    '        'ADD IN PARAMETER NAME IUSERID
    '        oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
    '        oParameter.Direction = ParameterDirection.Output

    '        oAdapter.SelectCommand = oCommand
    '        oAdapter.Fill(ds, "Hostels")

    '    Catch ex As Exception
    '        Throw EX
    '    Finally
    '        If Not ObjConn Is Nothing Then ObjConn.Free()
    '    End Try
    '    Return ds

    'End Function

    Public Function RoomsSave(ByVal dsResult As DataSet) As String
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
            iCommand.CommandText = "P_EXAM_BLKROOM_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            uCommand.Transaction = OraTrans
            uCommand.CommandText = "P_EXAM_BLKROOM_UPDATE"
            uCommand.Connection = oConn
            uCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER iEXAMBRANCHSLNO 
            oParameter = iCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER iBRANHOSTELSLNO 
            oParameter = iCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANHOSTELSLNO"

            'ADD IN PARAMETER iHOSBLOCKSLNO 
            oParameter = iCommand.Parameters.Add("iHOSBLOCKSLNO", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "HOSBLOCKSLNO"

            'ADD IN PARAMETER NAME iROOMNAME
            oParameter = iCommand.Parameters.Add("iROOMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ROOMNAME"

            'ADD IN PARAMETER NAME DESCRIPTION
            oParameter = iCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.InsertCommand = iCommand


            'ADD IN PARAMETER NAME AS iBLKROOMSLNO
            oParameter = uCommand.Parameters.Add("iBLKROOMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BLKROOMSLNO"

            'ADD IN PARAMETER iEXAMBRANCHSLNO 
            oParameter = uCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER iBRANHOSTELSLNO 
            oParameter = uCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANHOSTELSLNO"

            'ADD IN PARAMETER iHOSBLOCKSLNO 
            oParameter = uCommand.Parameters.Add("iHOSBLOCKSLNO", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "HOSBLOCKSLNO"


            'ADD IN PARAMETER NAME iROOMNAME
            oParameter = uCommand.Parameters.Add("iROOMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ROOMNAME"

            'ADD IN PARAMETER NAME DESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"


            oAdapter.UpdateCommand = uCommand
            oAdapter.Update(dsResult, "Rooms")
            OraTrans.Commit()
            Return "0-Record Saved"

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
            Return strReturn
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    Public Function GetRoomDeatails(ByVal iBLKROOMSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "P_ROOMDETAILS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iBLKROOMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBLKROOMSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "Rooms")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function



    Public Function GetRooms(ByVal StrSql As String) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "P_HBROOMS_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iStr", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StrSql

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "Rooms")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function



    Public Function DeleteRooms(ByVal PSlNo As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "F_BLOCKROOM_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME as slno
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

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

End Class
