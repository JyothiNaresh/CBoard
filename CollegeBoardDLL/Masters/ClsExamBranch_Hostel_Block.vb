'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating TOPICS
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 11-OCT-2006
'   FINAL BASELINE DATE               : 11-OCT-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsExamBranch_Hostel_Block


#Region "class Variables"
    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private OTrans As OracleTransaction
    Dim Ds As New Data.DataSet
    Private ObjConn As Connection
#End Region

#Region "Single Mode Methods"

    Public Function ExamBranchHostelBlock_FetchBySLNO(ByVal PSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_HOSTELBLOCK_EDIT_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSLNO
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ExamBranchHostelBlock_Update(ByVal PSLNO As Long, ByVal PEXAMBRANCHSLNO As Long, ByVal PBRANHOSTELSLNO As Long, ByVal PNAME As String, ByVal PDESCRIPTION As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "F_HOSTELBLOCK_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSLNO
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSLNO

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iBRANHOSTELSLNO
            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANHOSTELSLNO

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PNAME


            'ADD IN PARAMETER NAME DESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDESCRIPTION

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


    Public Function ExamBranchHostelBlock_Insert(ByVal dsResult As DataSet) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "F_HOSTELBLOCK_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = dsResult.Tables("BBR").Rows(0)("EXAMBRANCHSLNO")

            'ADD IN PARAMETER NAME iBRANHOSTELSLNO
            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = dsResult.Tables("BBR").Rows(0)("BRANHOSTELSLNO")

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = dsResult.Tables("BBR").Rows(0)("NAME")


            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = dsResult.Tables("BBR").Rows(0)("DESCRIPTION")


            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()
            '''oAdapter.InsertCommand = oCommand

            '''oAdapter.Update(dsResult, "BBR")

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString
            Return strReturn

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    Public Function ExamBranchHostelBlock_Delete(ByVal PSlNO As Long) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "F_HOSTELBLOCK_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME as slno
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNO

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString
            Return strReturn
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region "Batch Mode Methods"


    Public Function ExamBranchHostelBlock_BatchInsert(ByRef PDataSet As DataSet) As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand.CommandText = "M_HOSTELBLOCK_BATCHINSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER NAME AS iBRANHOSTELSLNO
            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANHOSTELSLNO"


            'ADD IN PARAMETER AS NAME
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NAME"

            'ADD IN PARAMETER NAME AS DESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(PDataSet, "BBR")

            Return 1

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function



#End Region

#Region "Direct Fill Method"
    'iEXAMBRANCHSLNO IN NUMBER,iBRANHOSTELSLNO
    Public Function ExamBranchHostelBlock_Fetch(ByVal PEXAMBRANCHSLNO As Long, ByVal PBRANHOSTELSLNO As Long) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_HOSTELBLOCK_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iSLNO
            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANHOSTELSLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    '''<WebMethod(Description:="Fetches the DataSet of Hostel Table")> _
    '''             Public Function Hostel_Fetch(ByVal PStatus As String) As Data.DataSet

    '''    Try
    '''        oConn = Common.GetConnection()
    '''        oConn.Open()

    '''        oCommand = New OracleClient.OracleCommand
    '''        oParameter = New OracleClient.OracleParameter
    '''        oAdapter = New OracleClient.OracleDataAdapter
    '''        Ds = New Data.DataSet

    '''        oCommand.CommandText = "M_HOSTEL_FETCH"
    '''        oCommand.Connection = oConn
    '''        oCommand.CommandType = CommandType.StoredProcedure

    '''        'ADD IN PARAMETER NAME IUSERID
    '''        oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Char, 1)
    '''        oParameter.Direction = ParameterDirection.Input
    '''        oParameter.Value = PStatus

    '''        'ADD IN PARAMETER NAME IUSERID
    '''        oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
    '''        oParameter.Direction = ParameterDirection.Output

    '''        oAdapter.SelectCommand = oCommand
    '''        oAdapter.Fill(Ds)

    '''    Catch ex As Exception
    '''        Throw   EX
    '''    Finally
    '''        If Not ObjConn Is Nothing Then ObjConn.Free()
    '''    End Try
    '''    Return Ds
    '''End Function


    '''<WebMethod(Description:="Fetches the DataSet of Block Table")> _
    '''             Public Function Block_Fetch(ByVal PStatus As String) As Data.DataSet
    '''    Try
    '''        oConn = Common.GetConnection()
    '''        oConn.Open()

    '''        oCommand = New OracleClient.OracleCommand
    '''        oParameter = New OracleClient.OracleParameter
    '''        oAdapter = New OracleClient.OracleDataAdapter
    '''        Ds = New Data.DataSet

    '''        oCommand.CommandText = "M_BLOCK_FETCH"
    '''        oCommand.Connection = oConn
    '''        oCommand.CommandType = CommandType.StoredProcedure

    '''        'ADD IN PARAMETER NAME IUSERID
    '''        oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Char, 1)
    '''        oParameter.Direction = ParameterDirection.Input
    '''        oParameter.Value = PStatus

    '''        'ADD IN PARAMETER NAME IUSERID
    '''        oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
    '''        oParameter.Direction = ParameterDirection.Output

    '''        oAdapter.SelectCommand = oCommand
    '''        oAdapter.Fill(Ds)

    '''    Catch ex As Exception
    '''        Throw   EX
    '''    Finally
    '''        If Not ObjConn Is Nothing Then ObjConn.Free()
    '''    End Try
    '''    Return Ds
    '''End Function

#End Region

#Region "Block Employee"

#Region "Single Mode Methods"

    Public Function ExamBranchHostelBlockEMP_FetchBySLNO(ByVal PSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_HOSTELBLOCKEMP_EDIT_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSLNO
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ExamBranchHostelBlockEMP_Update(ByVal PSLNO As Long, ByVal PEXAMBRANCHSLNO As Long, ByVal PBRANHOSTELSLNO As Long, ByVal PHOSBLOCKSLNO As Long, ByVal PEMPSLNO As Long, ByVal PDESCRIPTION As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "F_HOSTELBLOCKEMP_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSLNO
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSLNO

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iBRANHOSTELSLNO
            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANHOSTELSLNO

            'ADD IN PARAMETER NAME iHOSBLOCKSLNO
            oParameter = oCommand.Parameters.Add("iHOSBLOCKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PHOSBLOCKSLNO

            'ADD IN PARAMETER NAME iEMPSLNO
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PEMPSLNO

            'ADD IN PARAMETER NAME DESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDESCRIPTION

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

    Public Function ExamBranchHostelBlockEMP_Insert(ByVal dsResult As DataSet) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "F_HOSTELBLOCKEMP_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = dsResult.Tables("BBRE").Rows(0)("EXAMBRANCHSLNO")

            'ADD IN PARAMETER NAME iBRANHOSTELSLNO
            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = dsResult.Tables("BBRE").Rows(0)("BRANHOSTELSLNO")

            'ADD IN PARAMETER NAME iHOSBLOCKSLNO
            oParameter = oCommand.Parameters.Add("iHOSBLOCKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = dsResult.Tables("BBRE").Rows(0)("HOSBLOCKSLNO")

            'ADD IN PARAMETER NAME iEMPSLNO
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = dsResult.Tables("BBRE").Rows(0)("EMPSLNO")

            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = dsResult.Tables("BBRE").Rows(0)("DESCRIPTION")


            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()
            '''oAdapter.InsertCommand = oCommand

            '''oAdapter.Update(dsResult, "BBR")

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString
            Return strReturn

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ExamBranchHostelBlockEMP_Delete(ByVal PSlNO As Long) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "F_HOSTELBLOCKEMP_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME as slno
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNO

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString
            Return strReturn
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region "Batch Mode Methods"


       Public Function ExamBranchHostelBlockEMP_BatchInsert(ByRef PDataSet As DataSet) As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OTrans = oConn.BeginTransaction

            oCommand.Transaction = OTrans
            oCommand.CommandText = "M_HOSTELBLOCKEMP_BATCHINSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER NAME AS iBRANHOSTELSLNO
            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANHOSTELSLNO"

            'ADD IN PARAMETER NAME iHOSBLOCKSLNO
            oParameter = oCommand.Parameters.Add("iHOSBLOCKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "HOSBLOCKSLNO"

            'ADD IN PARAMETER NAME iEMPSLNO
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EMPSLNO"

            'ADD IN PARAMETER NAME AS DESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(PDataSet, "BBRE")
            OTrans.Commit()

            Return 1

        Catch ex As Exception
            OTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function



#End Region

#Region "Direct Fill Method"

    Public Function ExamBranchHostelBlockEMP_Fetch(ByVal PEXAMBRANCHSLNO As Long, ByVal PBRANHOSTELSLNO As Long, ByVal PHOSBLOCKSLNO As Long) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_HOSTELBLOCKEMP_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iSLNO
            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANHOSTELSLNO

            'ADD IN PARAMETER NAME iHOSBLOCKSLNO
            oParameter = oCommand.Parameters.Add("iHOSBLOCKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PHOSBLOCKSLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region


#End Region

#Region "Room Employee"

#Region "Single Mode Methods"


    Public Function ExamBranchHostelBlockRoomEMP_FetchBySLNO(ByVal PSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_BLOCKROOMEMP_EDIT_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSLNO
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ExamBranchHostelBlockRoomEMP_Update(ByVal PSLNO As Long, ByVal PEXAMBRANCHSLNO As Long, ByVal PBRANHOSTELSLNO As Long, ByVal PHOSBLOCKSLNO As Long, ByVal PBLKROOMSLNO As Long, ByVal PEMPSLNO As Long, ByVal PDESCRIPTION As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "F_BLOCKROOMEMP_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSLNO
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSLNO

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iBRANHOSTELSLNO
            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANHOSTELSLNO

            'ADD IN PARAMETER NAME iHOSBLOCKSLNO
            oParameter = oCommand.Parameters.Add("iHOSBLOCKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PHOSBLOCKSLNO

            'ADD IN PARAMETER NAME iBLKROOMSLNO
            oParameter = oCommand.Parameters.Add("iBLKROOMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBLKROOMSLNO

            'ADD IN PARAMETER NAME iEMPSLNO
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PEMPSLNO

            'ADD IN PARAMETER NAME DESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDESCRIPTION

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

    Public Function ExamBranchHostelBlockRoomEMP_Insert(ByVal dsResult As DataSet) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "F_BLOCKROOMEMP_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = dsResult.Tables("BBRE").Rows(0)("EXAMBRANCHSLNO")

            'ADD IN PARAMETER NAME iBRANHOSTELSLNO
            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = dsResult.Tables("BBRE").Rows(0)("BRANHOSTELSLNO")

            'ADD IN PARAMETER NAME iHOSBLOCKSLNO
            oParameter = oCommand.Parameters.Add("iHOSBLOCKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = dsResult.Tables("BBRE").Rows(0)("HOSBLOCKSLNO")

            'ADD IN PARAMETER NAME iBLKROOMSLNO
            oParameter = oCommand.Parameters.Add("iBLKROOMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = dsResult.Tables("BBRE").Rows(0)("BLKROOMSLNO")


            'ADD IN PARAMETER NAME iEMPSLNO
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = dsResult.Tables("BBRE").Rows(0)("EMPSLNO")

            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = dsResult.Tables("BBRE").Rows(0)("DESCRIPTION")


            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()
            '''oAdapter.InsertCommand = oCommand

            '''oAdapter.Update(dsResult, "BBR")

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString
            Return strReturn

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ExamBranchHostelBlockRoomEMP_Delete(ByVal PSlNO As Long) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "F_BLOCKROOMEMP_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME as slno
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNO

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString
            Return strReturn
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region "Batch Mode Methods"


    Public Function ExamBranchHostelBlockRoomEMP_BatchInsert(ByRef PDataSet As DataSet) As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OTrans = oConn.BeginTransaction()

            oCommand.Transaction = OTrans
            oCommand.CommandText = "M_BLOCKROOMEMP_BATCHINSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER NAME AS iBRANHOSTELSLNO
            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANHOSTELSLNO"

            'ADD IN PARAMETER NAME iHOSBLOCKSLNO
            oParameter = oCommand.Parameters.Add("iHOSBLOCKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "HOSBLOCKSLNO"

            'ADD IN PARAMETER NAME iBLKROOMSLNO
            oParameter = oCommand.Parameters.Add("iBLKROOMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BLKROOMSLNO"

            'ADD IN PARAMETER NAME iEMPSLNO
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EMPSLNO"

            'ADD IN PARAMETER NAME AS DESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(PDataSet, "ROOM")
            OTrans.Commit()
            Return 1

        Catch ex As Exception
            OTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function



#End Region

#Region "Direct Fill Method"


    Public Function ExamBranchHostelBlockRoomEMP_Fetch(ByVal PEXAMBRANCHSLNO As Long, ByVal PBRANHOSTELSLNO As Long, ByVal PHOSBLOCKSLNO As Long) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_BLOCKROOMEMP_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iSLNO
            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANHOSTELSLNO

            'ADD IN PARAMETER NAME iHOSBLOCKSLNO
            oParameter = oCommand.Parameters.Add("iHOSBLOCKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PHOSBLOCKSLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region


#End Region
End Class
