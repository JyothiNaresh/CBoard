'-------------------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : CENTRAL OFFICE COMMUNICATION (COC)
'   OBJECTIVE                         : This is the Middle Layer for COC Masters,Transaction and Reports.
'   ACTIVITY                          : Select\Insert\Update\Delete
'   AUTHOR                            : AMARENDRA B.V
'   INITIAL BASELINE DATE             : 5-8-2008
'   FINAL BASELINE DATE               : 5-8-2008
'   MODIFICATIONS LOG                 : Nil
'--------------------------------------------------------------------------------------------------------

Imports System.Data
Imports System.Data.OracleClient
Public Class ClsCoc

#Region "Common Variables"

    Private oConn As OracleConnection
    Private oCommand As OracleCommand
    Private oAdapter As OracleDataAdapter
    Private oParameter As OracleParameter
    Private oTrans As OracleTransaction
    Private objConn As Connection
    Private Ds As DataSet
    Private rtnMessage As String
    Private rtnNum As Integer

#End Region

#Region "Common Function"

    Public Function DataSet_OneFetch(ByVal SqlString1 As String) As Data.DataSet
        Try
            objConn = New Connection
            oConn = objConn.GetConnection()

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oCommand.CommandText = "MASTERS.PARSE_SQLSTRING1"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSqlString1", OracleType.VarChar, 15000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlString1

            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try
    End Function

#End Region

#Region "Coc Master"

    Public Function A_CocMasters_Select(ByVal pMASTERTYPE As String, ByVal pSLNO As Integer) As Data.DataSet

        Try
            objConn = New Connection
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            Ds = New DataSet

            oConn = objConn.GetConnection()

            oCommand.CommandText = "MASTERS.COC_MASTER_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iMASTERTYPE 
            oParameter = oCommand.Parameters.Add("iMASTERTYPE", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pMASTERTYPE

            'ADD IN PARAMETER iSLNO 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

            'ADD OUT PARAMETER NAME DATACUR
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function A_CocMasters_Insert(ByVal pMASTERTYPE As String, ByVal pNAME As String, ByVal pDESCRIPTION As String) As Byte
        Try

            objConn = New Connection
            oCommand = New OracleCommand
            oParameter = New OracleParameter

            oConn = objConn.GetConnection()

            oCommand.CommandText = "MASTERS.COC_MASTER_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iMASTERTYPE 
            oParameter = oCommand.Parameters.Add("iMASTERTYPE", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pMASTERTYPE

            'ADD IN PARAMETER iNAME 
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pNAME

            'ADD IN PARAMETER iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDESCRIPTION

            oCommand.ExecuteNonQuery()

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function A_CocMasters_BatchInsert(ByVal pDSMASTERTYPE As DataSet) As Byte

        Try

            objConn = New Connection
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oConn = objConn.GetConnection()
            oTrans = oConn.BeginTransaction

            oCommand.CommandText = "MASTERS.COC_MASTER_INSERT"
            oCommand.Connection = oConn
            oCommand.Transaction = oTrans
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER iMASTERTYPE 
            oParameter = oCommand.Parameters.Add("iMASTERTYPE", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MASTERTYPE"

            'ADD IN PARAMETER iNAME 
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NAME"

            'ADD IN PARAMETER iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(pDSMASTERTYPE.Tables("COCMASTERS"))
            oTrans.Commit()

            Return 1

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function A_CocMasters_Update(ByVal pMASTERTYPE As String, ByVal pSLNO As Integer, ByVal pNAME As String, ByVal pDESCRIPTION As String) As Byte

        Try

            objConn = New Connection
            oCommand = New OracleCommand
            oParameter = New OracleParameter

            oConn = objConn.GetConnection()

            oCommand.CommandText = "MASTERS.COC_MASTER_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iMASTERTYPE 
            oParameter = oCommand.Parameters.Add("iMASTERTYPE", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pMASTERTYPE

            'ADD IN PARAMETER iSLNO 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

            'ADD IN PARAMETER iNAME 
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pNAME

            'ADD IN PARAMETER iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDESCRIPTION

            oCommand.ExecuteNonQuery()

            Return 1

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function A_CocMasters_Delete(ByVal pMASTERTYPE As String, ByVal pSLNO As Integer) As Byte

        Try

            objConn = New Connection
            oCommand = New OracleCommand
            oParameter = New OracleParameter

            oConn = objConn.GetConnection()

            oCommand.CommandText = "MASTERS.COC_MASTER_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iMASTERTYPE 
            oParameter = oCommand.Parameters.Add("iMASTERTYPE", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pMASTERTYPE

            'ADD IN PARAMETER iSLNO 
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

            oCommand.ExecuteNonQuery()

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

#End Region

#Region "Coc Transaction"

    Public Function A_CocDtl_Select(ByVal pDEPARTMENTSLNO As Integer, ByVal pSUBDEPARTMENTSLNO As Integer, ByVal pSTATUS As Integer) As Data.DataSet

        Try
            objConn = New Connection
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            Ds = New DataSet

            oConn = objConn.GetConnection()

            oCommand.CommandText = "MASTERS.COC_COMDTL_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iDEPARTMENTSLNO 
            oParameter = oCommand.Parameters.Add("iDEPARTMENTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEPARTMENTSLNO

            'ADD IN PARAMETER iSUBDEPARTMENTSLNO 
            oParameter = oCommand.Parameters.Add("iSUBDEPARTMENTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSUBDEPARTMENTSLNO

            'ADD IN PARAMETER iSTATUS 
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSTATUS

            'ADD OUT PARAMETER NAME DATACUR
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function A_CocDtl_Insert(ByVal Arr As ArrayList) As Byte
        Try

            objConn = New Connection
            oCommand = New OracleCommand
            oParameter = New OracleParameter

            oConn = objConn.GetConnection()

            oCommand.CommandText = "MASTERS.COC_COMDTL_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iDEPARTMENTSLNO 
            oParameter = oCommand.Parameters.Add("iDEPARTMENTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'ADD IN PARAMETER iSUBDEPARTMENTSLNO 
            oParameter = oCommand.Parameters.Add("iSUBDEPARTMENTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'ADD IN PARAMETER iCOMACADEMICSLNO 
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            'ADD IN PARAMETER iNAME 
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            'ADD IN PARAMETER iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            'ADD IN PARAMETER iPHONE1 
            oParameter = oCommand.Parameters.Add("iPHONE1", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            'ADD IN PARAMETER iPHONE2 
            oParameter = oCommand.Parameters.Add("iPHONE2", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            'ADD IN PARAMETER iMOBILE1 
            oParameter = oCommand.Parameters.Add("iMOBILE1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            'ADD IN PARAMETER iMOBILE2 
            oParameter = oCommand.Parameters.Add("iMOBILE2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            'ADD IN PARAMETER iEMAIL 
            oParameter = oCommand.Parameters.Add("iEMAIL", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            'ADD IN PARAMETER iSTATUS 
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oCommand.ExecuteNonQuery()

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function A_CocDtl_BatchInsert(ByVal pDSCOCDTL As DataSet) As Byte

        Try

            objConn = New Connection
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oConn = objConn.GetConnection()
            oTrans = oConn.BeginTransaction

            oCommand.CommandText = "MASTERS.COC_COMDTL_INSERT"
            oCommand.Connection = oConn
            oCommand.Transaction = oTrans
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iDEPARTMENTSLNO 
            oParameter = oCommand.Parameters.Add("iDEPARTMENTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEPARTMENTSLNO"

            'ADD IN PARAMETER iSUBDEPARTMENTSLNO 
            oParameter = oCommand.Parameters.Add("iSUBDEPARTMENTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBDEPARTMENTSLNO"

            'ADD IN PARAMETER iCOMACADEMICSLNO 
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            'ADD IN PARAMETER iNAME 
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NAME"

            'ADD IN PARAMETER iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            'ADD IN PARAMETER iPHONE1 
            oParameter = oCommand.Parameters.Add("iPHONE1", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PHONE1"

            'ADD IN PARAMETER iPHONE2 
            oParameter = oCommand.Parameters.Add("iPHONE2", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PHONE2"

            'ADD IN PARAMETER iMOBILE1 
            oParameter = oCommand.Parameters.Add("iMOBILE1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MOBILE1"

            'ADD IN PARAMETER iMOBILE2 
            oParameter = oCommand.Parameters.Add("iMOBILE2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MOBILE2"

            'ADD IN PARAMETER iEMAIL 
            oParameter = oCommand.Parameters.Add("iEMAIL", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EMAIL"

            'ADD IN PARAMETER iSTATUS 
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(pDSCOCDTL.Tables("COCDTL"))
            oTrans.Commit()

            Return 1

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function A_CocDtl_Update(ByVal Arr As ArrayList) As Byte

        Try

            objConn = New Connection
            oCommand = New OracleCommand
            oParameter = New OracleParameter

            oConn = objConn.GetConnection()

            oCommand.CommandText = "MASTERS.COC_COMDTL_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iDEPARTMENTSLNO 
            oParameter = oCommand.Parameters.Add("iDEPARTMENTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'ADD IN PARAMETER iSUBDEPARTMENTSLNO 
            oParameter = oCommand.Parameters.Add("iSUBDEPARTMENTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'ADD IN PARAMETER iCOMACADEMICSLNO 
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            'ADD IN PARAMETER iNAME 
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            'ADD IN PARAMETER iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            'ADD IN PARAMETER iPHONE1 
            oParameter = oCommand.Parameters.Add("iPHONE1", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            'ADD IN PARAMETER iPHONE2 
            oParameter = oCommand.Parameters.Add("iPHONE2", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            'ADD IN PARAMETER iMOBILE1 
            oParameter = oCommand.Parameters.Add("iMOBILE1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            'ADD IN PARAMETER iMOBILE2 
            oParameter = oCommand.Parameters.Add("iMOBILE2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            'ADD IN PARAMETER iEMAIL 
            oParameter = oCommand.Parameters.Add("iEMAIL", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            'ADD IN PARAMETER iSTATUS 
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            'ADD IN PARAMETER iCOMDTLSLNO 
            oParameter = oCommand.Parameters.Add("iCOMDTLSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oCommand.ExecuteNonQuery()

            Return 1

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

    Public Function A_CocDtl_Delete(ByVal pCOMDTLSLNO As Integer, ByVal pSTATUS As Integer) As Byte

        Try

            objConn = New Connection
            oCommand = New OracleCommand
            oParameter = New OracleParameter

            oConn = objConn.GetConnection()

            oCommand.CommandText = "MASTERS.COC_COMDTL_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iCOMDTLSLNO 
            oParameter = oCommand.Parameters.Add("iCOMDTLSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMDTLSLNO

            'ADD IN PARAMETER iSTATUS 
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSTATUS

            oCommand.ExecuteNonQuery()

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not objConn Is Nothing Then objConn.Free()
        End Try

    End Function

#End Region

End Class
