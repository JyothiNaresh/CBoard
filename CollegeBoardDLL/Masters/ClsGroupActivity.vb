Imports System.Data.OracleClient
Imports System.Configuration
Public Class ClsGroupActivity

#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As New OracleClient.OracleCommand
    Private oParameter As New OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private OraTrans As OracleTransaction
    Private ds As Data.DataSet
    Private oTrans As OracleTransaction
    Private Result As String
    Private RtnVal As Integer
    Private ObjConn As Connection

#End Region

#Region "Insert/Update Methods"

    Public Function P_GroupActivity_Select(ByVal pSLNO As Integer, ByVal pGANO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            ds = New DataSet

            oConn = ObjConn.GetConnection()
            oCommand.CommandText = "P_GASGDT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

            oParameter = oCommand.Parameters.Add("iGANO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pGANO

            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

            Return ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function P_GroupActivity_Update(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_GASGDT_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            '''''''''''''''''''''''''''''''  1  '''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)


            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iGANO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)



            oCommand.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function P_GroupActivity_Insert(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_GASGDT_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            ''----------------------- 1 ------------------------------------


            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iGANO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oCommand.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function GroupActivityBatch(ByVal PDset As DataSet) As String
        Dim rtnString As String

        Try
            Dim setResult As String
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            If Not IsNothing(PDset) AndAlso PDset.Tables(0).Rows.Count > 0 Then
                P_GroupActivityBatch_Insert(PDset, oConn, oTrans)
            End If

            oTrans.Commit()
            rtnString = "Records Saved Successfully"

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString

    End Function

    Public Function P_GroupActivityBatch_Insert(ByVal SPDset As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim adap As New OracleDataAdapter

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()
            oCommand.Transaction = OraTrans
            oCommand.CommandText = "P_GASGDT_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as iName
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NAME"

            'Add In Parameter as iDescription
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oParameter = oCommand.Parameters.Add("iGANO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GANO"


            adap.InsertCommand = oCommand

            adap.Update(SPDset, "Name")

            OraTrans.Commit()

            Return 1


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function P_GroupActivity_Delete(ByVal pSLNO As Integer, ByVal pGANO As Integer) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_GASGDT_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

            oParameter = oCommand.Parameters.Add("iGANO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pGANO


            oCommand.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function P_GroupActivityDTLock(ByVal pEBGADMAPDTSLNO As Integer, ByVal pEBGADMAPSLNO As Integer, ByVal pLockStatus As String) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "P_EBCGAMAPLOCK_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEBGADMAPDTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEBGADMAPDTSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEBGADMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEBGADMAPSLNO

            oParameter = oCommand.Parameters.Add("iLOCKSTATUS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pLockStatus

            oCommand.ExecuteNonQuery()

            oTrans.Commit()
            Return " SAVED "
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function P_GroupActivityLock(ByVal pEBGADMAPSLNO As Integer, ByVal pLockStatus As String) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "P_EBCGALOCK_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEBGADMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEBGADMAPSLNO

            oParameter = oCommand.Parameters.Add("iLOCKSTATUS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pLockStatus

            oCommand.ExecuteNonQuery()

            oTrans.Commit()
            Return " SAVED "
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function
#End Region

#Region "Mapping"

    Public Function EBWiseGroupActivty_Save(ByVal ArrListGA As ArrayList, ByVal pDs As DataSet) As String
        Dim rtnString As String
        Dim RtnVal1, RtnVal2 As Integer
        Try
            Dim setResult As String


            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()

            If Not IsNothing(pDs) AndAlso pDs.Tables(0).Rows.Count > 0 Then
                RtnVal1 = EBWiseGroupActivityMap_Insert(ArrListGA)   '' inserting into master

                If RtnVal1 <> 0 Then
                    RtnVal2 = EBWiseGroupActivityMapDetail_Insert(RtnVal1, pDs)
                    OraTrans.Commit()
                Else
                    OraTrans.Rollback()
                    rtnString = "Record Not Saved"
                End If
                rtnString = "Record Saved"
            End If

            Return 1

        Catch oex As OracleException
            If Not OraTrans Is Nothing Then OraTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not OraTrans Is Nothing Then OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function EBWiseGroupActivityMap_Insert(ByVal Arr As ArrayList) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "F_EBCGAMAPMT_INSERT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iPERIODICITY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iTRANSDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)


            oCommand.Parameters.Add(New OracleParameter("oRtnValue", OracleType.Number, 25)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            RtnVal = oCommand.Parameters("oRtnValue").Value

            Return RtnVal

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return 1

    End Function

    Public Function EBWiseGroupActivityMapDetail_Insert(ByVal iEBGADMAPSLNO As Integer, ByVal dsSet As DataSet) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "P_EBCGAMAPDT_INSERT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            oParameter = oCommand.Parameters.Add("iEBGADMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEBGADMAPSLNO

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            oParameter = oCommand.Parameters.Add("iGAMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GAMAPSLNO"

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"



            oAdapter.InsertCommand = oCommand

            oAdapter.Update(dsSet, "GADT")

            Return 1

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return 1

    End Function

    Public Function P_GroupActSubGroupDetailMap_Insert(ByVal SPDset As DataSet) As String

        Try
            Dim adap As New OracleDataAdapter

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()
            oCommand.Transaction = OraTrans
            oCommand.CommandText = "P_SUBGROUPDTMAP_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            oParameter = oCommand.Parameters.Add("iGASLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GASLNO"

            oParameter = oCommand.Parameters.Add("iGASGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GASGSLNO"

            oParameter = oCommand.Parameters.Add("iGASGDTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GASGDTSLNO"



            adap.InsertCommand = oCommand

            adap.Update(SPDset, "GASGDT")

            OraTrans.Commit()

            Return 1


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function P_AccYearWiseGASGDTMap_Insert(ByVal SPDset As DataSet) As String

        Try
            Dim adap As New OracleDataAdapter

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()
            oCommand.Transaction = OraTrans
            oCommand.CommandText = "P_ACYSGDTMAP_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            ''oParameter = oCommand.Parameters.Add("iACYGAMAPSLNO", OracleType.Number)
            ''oParameter.Direction = ParameterDirection.Input
            ''oParameter.SourceColumn = "ACYGAMAPSLNO"

            oParameter = oCommand.Parameters.Add("iGAMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GAMAPSLNO"

            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"



            adap.InsertCommand = oCommand

            adap.Update(SPDset, "GASGDT")

            OraTrans.Commit()

            Return 1


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function P_EBWiseGroupActivityMapDetail_Delete(ByVal pEBGADMAPSLNO As Integer, ByVal pEBGADMAPDTSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_EBGAMAPDEFINE_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEBGADMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEBGADMAPSLNO

            oParameter = oCommand.Parameters.Add("iEBGADMAPDTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEBGADMAPDTSLNO

            oParameter = oCommand.Parameters.Add("iRtnVal", OracleType.Number)
            oParameter.Direction = ParameterDirection.Output


            oCommand.ExecuteNonQuery()

            Return oCommand.Parameters("iRtnVal").Value

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function P_GroupActSubGroupDetailMap_Delete(ByVal pGAMAPSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_SUBGROUPDTMAP_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iGAMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pGAMAPSLNO



            oCommand.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function P_EBCGAMAP_Insert(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_EBCGAMAP_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            ''----------------------- 1 ------------------------------------

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iGASLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iGASGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iGASGDTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iPERIODICITY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oCommand.ExecuteNonQuery()

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function P_EBCGAMAP_Delete(ByVal PSlNo As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "P_EBCGAMAP_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME as slno
            oParameter = oCommand.Parameters.Add("iEBCGAMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            oCommand.ExecuteNonQuery()

            strReturn = 1

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function

    Public Function P_GASGDTMAP_Select(ByVal pADMNO As String, ByVal pCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            ds = New DataSet

            oConn = ObjConn.GetConnection()
            oCommand.CommandText = "P_GASGDTMAP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iADMNO", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMNO

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

            Return ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function GroupActivityGradeEntry_Insert(ByVal dsSet As DataSet) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "P_GRADEENTRY_INSERT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn


            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "UNIQUENO"

            oParameter = oCommand.Parameters.Add("iEBGADMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EBGADMAPSLNO"

            oParameter = oCommand.Parameters.Add("iGRADESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GRADESLNO"

            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            oParameter = oCommand.Parameters.Add("iMONTHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MONTHSLNO"

            oParameter = oCommand.Parameters.Add("iPERIODICITY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PERIODICITY"

            oParameter = oCommand.Parameters.Add("iTRANSDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRANSDATE"

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"



            oAdapter.InsertCommand = oCommand

            oAdapter.Update(dsSet, "GRADE")

            Return 1

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return 1

    End Function

    Public Function GroupActivityGradeEntry_Update(ByVal dsSet As DataSet) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "P_GRADEENTRY_UPDATE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iGAENTRYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GAENTRYSLNO"

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "UNIQUENO"

            oParameter = oCommand.Parameters.Add("iEBGADMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EBGADMAPSLNO"

            oParameter = oCommand.Parameters.Add("iGRADESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GRADESLNO"

            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            oParameter = oCommand.Parameters.Add("iMONTHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MONTHSLNO"

            oParameter = oCommand.Parameters.Add("iPERIODICITY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PERIODICITY"

            oParameter = oCommand.Parameters.Add("iTRANSDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRANSDATE"

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"



            oAdapter.InsertCommand = oCommand

            oAdapter.Update(dsSet, "GRADE")

            Return 1

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return 1

    End Function

#End Region

#Region "POSTING"
    Public Function GroupActivity_Parent_Posting(ByVal pCOMACADEMICSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_GAMASTERPOSTING_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            ''----------------------- 1 ------------------------------------

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

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

    Public Function GroupActivityDefine_Parent_Posting(ByVal pCOMACADEMICSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_GADEFINEPOSTING_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            ''----------------------- 1 ------------------------------------

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

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

    Public Function GroupActivityGrades_Parent_Posting(ByVal pCOMACADEMICSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_GAGRADEENTRYPOSTING_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            ''----------------------- 1 ------------------------------------

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

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

End Class
