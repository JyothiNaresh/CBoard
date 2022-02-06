'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Master BoardEnrollments
'   ACTIVITY                          : 
'   AUTHOR                            : J.Himavantha Rao
'   INITIAL BASELINE DATE             : 13-10-2009
'   FINAL BASELINE DATE               : 
'   MODIFICATIONS LOG                 : KISHORE
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration
Public Class ClsBoardEnrollment

#Region "Class Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As New OracleClient.OracleCommand
    Private iCommand As New OracleClient.OracleCommand
    Private oParameter As New OracleClient.OracleParameter
    Private oAdapter As New OracleClient.OracleDataAdapter
    Private OraTrans As OracleTransaction
    Dim ds As New Data.DataSet
    Private oTrans As OracleTransaction
    Private ObjConn As Connection

#End Region

#Region "Methods"

    Public Function Masters_Selectall(ByVal pBENO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "P_BOARDMASTER_SELECTALL"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iBENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBENO

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

    Public Function Masters_Selectone(ByVal pSLNO As Integer, ByVal pBENO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            ds = New DataSet

            oConn = ObjConn.GetConnection()
            oCommand.CommandText = "P_BOARDMASTER_SELECTONE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

            oParameter = oCommand.Parameters.Add("iBENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBENO

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

    Public Function Masters_Update(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_BOARDMASTER_UPDATE"
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

            oParameter = oCommand.Parameters.Add("iBENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iCODE", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)


            oParameter = oCommand.Parameters.Add("iCODE1", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

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

    Public Function Masters_Insert(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_BOARDMASTER_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            ''----------------------- 1 ------------------------------------


            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iBENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iCODE", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iCODE1", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

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



    Public Function Master_Delete(ByVal pBENO As Integer, ByVal pSLNO As String) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_BOARDMASTER_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iBENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBENO

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

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

    Public Function MastersBatch(ByVal PDset As DataSet) As String
        Dim rtnString As String

        Try
            Dim setResult As String
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            If Not IsNothing(PDset) AndAlso PDset.Tables(0).Rows.Count > 0 Then
                MastersBatch_Insert(PDset, oConn, oTrans)
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

    Public Function MastersBatch_Insert(ByVal SPDset As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim adap As New OracleDataAdapter

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()
            oCommand.Transaction = OraTrans
            oCommand.CommandText = "P_BOARDMASTER_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iCode
            oParameter = oCommand.Parameters.Add("iCODE", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CODE"

            'Add In Parameter as iName
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NAME"

            'Add In Parameter as iDescription
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oParameter = oCommand.Parameters.Add("iBENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BENO"

            'Add In Parameter as iCode
            oParameter = oCommand.Parameters.Add("iCODE1", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CODE1"

            adap.InsertCommand = oCommand

            adap.Update(SPDset, "Name")

            OraTrans.Commit()

            Return 1


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function College_Insert(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_BOARDCOLLEGE_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCODE", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iCOLLEGENAME", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iBOARDCOLLTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iBOARDDISTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iYEAROFSTART", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iOLDCODE", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iISNARAYANA", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iISOWN", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iBOARDCORPCOLLSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iSTATESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iMANDALSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iADDR3", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iADDR2", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iADDR1", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iADDR4", OracleType.VarChar, 6)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            oParameter = oCommand.Parameters.Add("iPHONE1", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("iPHONE2", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)


            oParameter = oCommand.Parameters.Add("iMOBILE1", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            oParameter = oCommand.Parameters.Add("iMOBILE2", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            oParameter = oCommand.Parameters.Add("ieMail", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)
            ''gk add
            oParameter = oCommand.Parameters.Add("iLOC_COLLEGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("iPRIIC_NAME", OracleType.VarChar, 30)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

            oParameter = oCommand.Parameters.Add("iPRIIC_MOBILE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)

            oParameter = oCommand.Parameters.Add("iBIEZONE", OracleType.VarChar, 30)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)

            oParameter = oCommand.Parameters.Add("iBANK_BRNACH", OracleType.VarChar, 30)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(27)


            oParameter = oCommand.Parameters.Add("iRUN_STATUS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(28)

            oParameter = oCommand.Parameters.Add("iIC_NAME", OracleType.VarChar, 30)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(29)

            oParameter = oCommand.Parameters.Add("iIC_MOBILE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(30)

            oParameter = oCommand.Parameters.Add("iBIE_CLERK_NAME", OracleType.VarChar, 30)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(31)

            oParameter = oCommand.Parameters.Add("iBIE_CLERK_MOBILE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(32)


            oParameter = oCommand.Parameters.Add("iLOI_GO_NO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(33)

            oParameter = oCommand.Parameters.Add("iLOI_GO_DATE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(34)

            oParameter = oCommand.Parameters.Add("iLATEST_SUB_AFF", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(35)


            oParameter = oCommand.Parameters.Add("iCLG_SC_TYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(36)

            oParameter = oCommand.Parameters.Add("iCLG_AFF_15", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(37)


            oParameter = oCommand.Parameters.Add("iCLG_AFF_610", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(38)


            oParameter = oCommand.Parameters.Add("iPLAN_BRS_PROC_NO", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(39)


            oParameter = oCommand.Parameters.Add("iSC_AFF_15", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(40)

            oParameter = oCommand.Parameters.Add("iSC_AFF_610", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(41)


            ''gk add
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

    Public Function college_select(ByVal PCODE As String) As DataSet
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            ds = New DataSet

            oConn = ObjConn.GetConnection()
            oCommand.CommandText = "P_BOARDCOLLEGE_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCODE", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCODE

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
            ObjConn.Free()
        End Try
    End Function

    Public Function GetDataForStudent(ByVal PADMSNO As Integer, ByVal PBRANCHSLNO As Integer, ByVal PCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            ds = New DataSet

            oConn = ObjConn.GetConnection()
            oCommand.CommandText = "P_BOARDSTUDENT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iADMSNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PADMSNO

            oParameter = oCommand.Parameters.Add("iEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANCHSLNO

            oParameter = oCommand.Parameters.Add("iCACYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOMACADEMICSLNO

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
            ObjConn.Free()
        End Try

    End Function

    Public Function GetDataForStudent_Mumbai(ByVal PADMSNO As Integer, ByVal PBRANCHSLNO As Integer, ByVal PCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            ds = New DataSet

            oConn = ObjConn.GetConnection()
            oCommand.CommandText = "P_BOARDSTUDENT_MUMBAI"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iADMSNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PADMSNO

            oParameter = oCommand.Parameters.Add("iEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANCHSLNO

            oParameter = oCommand.Parameters.Add("iCACYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOMACADEMICSLNO

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
            ObjConn.Free()
        End Try

    End Function

    Public Function GetDataForStudent_CBSE(ByVal PADMSNO As Integer, ByVal PBRANCHSLNO As Integer, ByVal PCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            ds = New DataSet

            oConn = ObjConn.GetConnection()
            oCommand.CommandText = "P_BOARDSTUDENT_CBSE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iADMSNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PADMSNO

            oParameter = oCommand.Parameters.Add("iEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANCHSLNO

            oParameter = oCommand.Parameters.Add("iCACYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOMACADEMICSLNO

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
            ObjConn.Free()
        End Try

    End Function

    Public Function GetDataForStudent_Chennai(ByVal PADMSNO As Integer, ByVal PBRANCHSLNO As Integer, ByVal PCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            ds = New DataSet

            oConn = ObjConn.GetConnection()
            oCommand.CommandText = "P_BOARDSTUDENT_CHENNAI"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iADMSNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PADMSNO

            oParameter = oCommand.Parameters.Add("iEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANCHSLNO

            oParameter = oCommand.Parameters.Add("iCACYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOMACADEMICSLNO

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
            ObjConn.Free()
        End Try

    End Function

    Public Function GetDataForStudent_Res(ByVal PADMSNO As Integer, ByVal PBRANCHSLNO As Integer, ByVal PCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            ds = New DataSet

            oConn = ObjConn.GetConnection()
            oCommand.CommandText = "P_BOARDSTUDENT_RES_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iADMSNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PADMSNO

            oParameter = oCommand.Parameters.Add("iEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANCHSLNO

            oParameter = oCommand.Parameters.Add("iCACYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOMACADEMICSLNO

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
            ObjConn.Free()
        End Try

    End Function

    Public Function GetDataForStudentDummy(ByVal PBRANCHSLNO As Integer, ByVal PCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            ds = New DataSet

            oConn = ObjConn.GetConnection()
            oCommand.CommandText = "PD_BOARDSTUDENT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANCHSLNO

            oParameter = oCommand.Parameters.Add("iCACYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOMACADEMICSLNO

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
            ObjConn.Free()
        End Try

    End Function

    Public Function GetDataForStudent_NA(ByVal PADMSNO As Integer, ByVal PBRANCHSLNO As Integer, ByVal PCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            ds = New DataSet

            oConn = ObjConn.GetConnection()
            oCommand.CommandText = "P_BOARDSTUDENTNA_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iADMSNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PADMSNO

            oParameter = oCommand.Parameters.Add("iEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANCHSLNO

            oParameter = oCommand.Parameters.Add("iCACYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOMACADEMICSLNO

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
            ObjConn.Free()
        End Try

    End Function
    Public Function P_AcaEbCol_Insert(ByVal SPDset As DataSet) As String

        Try
            Dim adap As New OracleDataAdapter

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()
            oCommand.Transaction = OraTrans
            oCommand.CommandText = "P_EXAM_BC_EB_ACADEMIC_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            oParameter = oCommand.Parameters.Add("iBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BOARDCOLLEGESLNO"

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"



            adap.InsertCommand = oCommand

            adap.Update(SPDset, "ACEBCOLDT")

            OraTrans.Commit()

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function P_AcaEbCol_Select(ByVal pBENO As Integer, ByVal pACNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "P_EXAM_BC_EB_ACADEMIC_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBENO

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACNO

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

    Public Function P_AcaEbCol_Delete(ByVal pBOARDCOLACASLNO As Integer) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "P_EXAM_BC_EB_ACADEMIC_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iBOARDCOLACASLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBOARDCOLACASLNO

            oCommand.ExecuteNonQuery()
            Return 1

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function Student_Update(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_BOARDSTUDENT_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iBOARDID", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iBOARDADMNO", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iBOARDNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iFATHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iMOTHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

            oParameter = oCommand.Parameters.Add("iDOB", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iPRV_HTNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iPHPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iMOTHERTONGUESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iMOLE1", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iMOLE2", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iBOARDRELIGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iBOARDCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iBOARDPRVEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iBOARDYOPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iBOARDCATEGORYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iBOARDFIRSTLANGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            oParameter = oCommand.Parameters.Add("iBOARDSECLANGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("iBOARDPHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("iDOJ", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            oParameter = oCommand.Parameters.Add("iJOINEDCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("iBOARDSUBCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)

            oParameter = oCommand.Parameters.Add("iAADHAR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)

            oParameter = oCommand.Parameters.Add("iADMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(27)


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


    Public Function GetDataForStudent_Benglore(ByVal PADMSNO As Integer, ByVal PBRANCHSLNO As Integer, ByVal PCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            ds = New DataSet

            oConn = ObjConn.GetConnection()
            oCommand.CommandText = "P_BOARDSTUDENT_BANGLORE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iADMSNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PADMSNO

            oParameter = oCommand.Parameters.Add("iEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANCHSLNO

            oParameter = oCommand.Parameters.Add("iCACYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOMACADEMICSLNO

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
            ObjConn.Free()
        End Try

    End Function


    Public Function Student_Chennai_Update(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_BOARDSTUDENT_CHENNAI_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iBOARDADMNO", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iBOARDNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iFATHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iMOTHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iNATIONALITY", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iSCHEDULE_CASTE", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iSCHOOL_CLASS", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iDOB", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iDOB_WORDS", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iLAST_STUDIED", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iLAST_STUDIED_WORDS", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iBOARD_LASTEXAM", OracleType.Varchar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iTWICE_CLASS", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iSUBJECT1", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iSUBJECT2", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iSUBJECT3", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            oParameter = oCommand.Parameters.Add("iSUBJECT4", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("iSUBJECT5", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            oParameter = oCommand.Parameters.Add("iSUBJECT6", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            oParameter = oCommand.Parameters.Add("iQUAL_CLASS", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            oParameter = oCommand.Parameters.Add("iQUAL_CLASS_WORDS", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("iDUES_PAID", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            oParameter = oCommand.Parameters.Add("iCONCESSION", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("iTOT_WORKDAYS", OracleType.VarChar, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

            oParameter = oCommand.Parameters.Add("iWORK_DAYSPRE", OracleType.VarChar, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)

            oParameter = oCommand.Parameters.Add("iNCC", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)

            oParameter = oCommand.Parameters.Add("iGAMES_ACTIV", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(27)

            oParameter = oCommand.Parameters.Add("iCONDUCT", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(28)

            oParameter = oCommand.Parameters.Add("iAPPL_CERT", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(29)

            oParameter = oCommand.Parameters.Add("iISSUE_CERT", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(30)

            oParameter = oCommand.Parameters.Add("iREASON_LEAVING", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(31)

            oParameter = oCommand.Parameters.Add("iOTHER_REMARKS", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(32)

            oParameter = oCommand.Parameters.Add("iAADHAR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(33)

            oParameter = oCommand.Parameters.Add("iADMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(34)

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(35)

            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(36)

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(37)

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

    


    Public Function Student_UpdateTC(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_BOARDSTUDENTMUMBAI_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            oParameter = oCommand.Parameters.Add("iBOARDNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iFATHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iDOB", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)


            oParameter = oCommand.Parameters.Add("iMOTHERTONGUESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iBOARDRELIGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iBOARDCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iBOARDYOPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iDOJ", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iJOINEDCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iMOTHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iBOARDSUBCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iAADHAR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iADMBRANCHSLNO", OracleType.NVarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iNspiradmno", OracleType.NVarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            oParameter = oCommand.Parameters.Add("iGRO", OracleType.NVarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("iUDISE", OracleType.NVarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            oParameter = oCommand.Parameters.Add("iINDEXNUM", OracleType.NVarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            oParameter = oCommand.Parameters.Add("iBOARDMEDIUMSLNO", OracleType.NVarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            ' oParameter = oCommand.Parameters.Add("iDatereleving", OracleType.DateTime)
            ' oParameter.Direction = ParameterDirection.Input
            ' oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("iBOARDADMNO", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("iPRV_SCHOOL", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            oParameter = oCommand.Parameters.Add("iPRV_CLASS", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("iVILLAGE", OracleType.VarChar, 35)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

            oParameter = oCommand.Parameters.Add("iDISTRICT", OracleType.VarChar, 35)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)

            oParameter = oCommand.Parameters.Add("iSTATE", OracleType.VarChar, 35)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)

            oParameter = oCommand.Parameters.Add("iCOUNTRY", OracleType.VarChar, 35)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(27)

            oParameter = oCommand.Parameters.Add("iSURNAME", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(28)

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

    Public Function Student_Update_CBSE(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_BOARD_CBSE_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iBOARDADMNO", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iBOARDNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iFATHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iMOTHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iDOB", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iNATIONALITY", OracleType.VarChar, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iBOARDRELIGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iBOARDCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iBOARDYOPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iDOJ", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iMOTHERTONGUESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iJOINEDCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iNCC", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iGAMES", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iPRES_DAYS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iWRK_DAYS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iSUBJECT1", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            oParameter = oCommand.Parameters.Add("iSUBJECT2", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("iSUBJECT3", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            oParameter = oCommand.Parameters.Add("iSUBJECT4", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            oParameter = oCommand.Parameters.Add("iSUBJECT5", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            oParameter = oCommand.Parameters.Add("iBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("iADMBRANCHSLNO", OracleType.NVarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

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

    Public Function StudentNonAdmitted_Update(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_BOARDNONADMITTED_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iBOARDID", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iBOARDADMNO", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iBOARDNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iFATHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iMOTHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

            oParameter = oCommand.Parameters.Add("iDOB", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iPRV_HTNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iPHPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iMOTHERTONGUESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iMOLE1", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iMOLE2", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iBOARDRELIGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iBOARDCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iBOARDPRVEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iBOARDYOPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iBOARDCATEGORYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iBOARDFIRSTLANGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            oParameter = oCommand.Parameters.Add("iBOARDSECLANGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("iBOARDPHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            'oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = Arr(20)

            'oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("iDOJ", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            oParameter = oCommand.Parameters.Add("iJOINEDCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("iBOARDSUBCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)

            oParameter = oCommand.Parameters.Add("iAADHAR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)

            oParameter = oCommand.Parameters.Add("iADMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(27)

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
    Public Function StudentSupply_Update(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_BOARDSTUDENTSUPPLY_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iBOARDID", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iBOARDADMNO", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iBOARDNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iFATHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iMOTHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

            oParameter = oCommand.Parameters.Add("iDOB", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iPRV_HTNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iPHPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iMOTHERTONGUESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iMOLE1", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iMOLE2", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iBOARDRELIGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iBOARDCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iBOARDPRVEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iBOARDYOPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iBOARDCATEGORYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iBOARDFIRSTLANGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            oParameter = oCommand.Parameters.Add("iBOARDSECLANGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("iBOARDPHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("iDOJ", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            oParameter = oCommand.Parameters.Add("iJOINEDCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("iBOARDSUBCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)

            oParameter = oCommand.Parameters.Add("iAADHAR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)

            oParameter = oCommand.Parameters.Add("iADMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(27)

            oParameter = oCommand.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(28)


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

    Public Function Student_Res_Update(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_BOARDSTUDENT_RES_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iBOARDID", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iBOARDADMNO", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iBOARDNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iFATHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iMOTHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

            oParameter = oCommand.Parameters.Add("iDOB", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iPRV_HTNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iPHPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iMOTHERTONGUESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iMOLE1", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iMOLE2", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iBOARDRELIGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iBOARDCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iBOARDPRVEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iBOARDYOPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iBOARDCATEGORYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iBOARDFIRSTLANGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            oParameter = oCommand.Parameters.Add("iBOARDSECLANGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("iBOARDPHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("iDOJ", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            oParameter = oCommand.Parameters.Add("iJOINEDCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("iBOARDSUBCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)

            oParameter = oCommand.Parameters.Add("iAADHAR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)

            oParameter = oCommand.Parameters.Add("iADMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(27)


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

    Public Function Student_InsertDummy(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "PD_BOARDSTUDENT_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iBOARDID", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iBOARDADMNO", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iBOARDNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iFATHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iMOTHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("iDOB", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iPRV_HTNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iPHPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iMOTHERTONGUESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iMOLE1", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iMOLE2", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iBOARDRELIGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iBOARDCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iBOARDPRVEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iBOARDYOPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iBOARDCATEGORYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iBOARDGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            oParameter = oCommand.Parameters.Add("iBOARDSECLANGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("iBOARDPHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            oParameter = oCommand.Parameters.Add("iDOJ", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("iJOINEDCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            oParameter = oCommand.Parameters.Add("iBOARDSUBCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

            oParameter = oCommand.Parameters.Add("iBOARDMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)






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

    'gk
    Public Function GROUP_Insert(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "BOARD_GRP_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME sub batch name
            oParameter = oCommand.Parameters.Add("iGRPCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GRPCODE"

            oParameter = oCommand.Parameters.Add("iCODE", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CODE"


            'oParameter = oCommand.Parameters.Add("iSLGCODE", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "SLGCODE"

            'oParameter = oCommand.Parameters.Add("iMDMCODE", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "MDMCODE"


            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "GROUP")

            oTrans.Commit()
            Return 1

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function SCLG_Insert(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "BOARD_SCLG_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLGCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLGCODE"

            oParameter = oCommand.Parameters.Add("iCODE", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CODE"


            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "SCLG")

            oTrans.Commit()
            Return 1

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function MDM_Insert(ByRef PDataSet As DataSet) As String

        Dim adap As New OracleDataAdapter
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans
            oCommand.CommandText = "BOARD_MDM_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iMDMCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MDMCODE"

            oParameter = oCommand.Parameters.Add("iCODE", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CODE"


            adap.InsertCommand = oCommand
            adap.Update(PDataSet, "MEDIUM")

            oTrans.Commit()
            Return 1

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function College_Update(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()
            oCommand.Transaction = oTrans

            oCommand.CommandText = "P_BOARDCOLLEGE_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iorcode", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(43)

            oParameter = oCommand.Parameters.Add("iCODE", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 150)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iCOLLEGENAME", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iBOARDCOLLTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iBOARDDISTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iYEAROFSTART", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iOLDCODE", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iISNARAYANA", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iISOWN", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iBOARDCORPCOLLSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iSTATESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iMANDALSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iADDR3", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iADDR2", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iADDR1", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iADDR4", OracleType.VarChar, 6)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            oParameter = oCommand.Parameters.Add("iPHONE1", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("iPHONE2", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)


            oParameter = oCommand.Parameters.Add("iMOBILE1", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            oParameter = oCommand.Parameters.Add("iMOBILE2", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            oParameter = oCommand.Parameters.Add("ieMail", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)
            ''gk add
            oParameter = oCommand.Parameters.Add("iLOC_COLLEGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("iPRIIC_NAME", OracleType.VarChar, 30)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

            oParameter = oCommand.Parameters.Add("iPRIIC_MOBILE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)

            oParameter = oCommand.Parameters.Add("iBIEZONE", OracleType.VarChar, 30)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)

            oParameter = oCommand.Parameters.Add("iBANK_BRNACH", OracleType.VarChar, 30)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(27)


            oParameter = oCommand.Parameters.Add("iRUN_STATUS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(28)

            oParameter = oCommand.Parameters.Add("iIC_NAME", OracleType.VarChar, 30)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(29)

            oParameter = oCommand.Parameters.Add("iIC_MOBILE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(30)

            oParameter = oCommand.Parameters.Add("iBIE_CLERK_NAME", OracleType.VarChar, 30)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(31)

            oParameter = oCommand.Parameters.Add("iBIE_CLERK_MOBILE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(32)


            oParameter = oCommand.Parameters.Add("iLOI_GO_NO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(33)

            oParameter = oCommand.Parameters.Add("iLOI_GO_DATE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(34)

            oParameter = oCommand.Parameters.Add("iLATEST_SUB_AFF", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(35)


            oParameter = oCommand.Parameters.Add("iCLG_SC_TYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(36)

            oParameter = oCommand.Parameters.Add("iCLG_AFF_15", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(37)


            oParameter = oCommand.Parameters.Add("iCLG_AFF_610", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(38)


            oParameter = oCommand.Parameters.Add("iPLAN_BRS_PROC_NO", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(39)

            oParameter = oCommand.Parameters.Add("iSC_AFF_15", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(40)

            oParameter = oCommand.Parameters.Add("iSC_AFF_610", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(41)


            oTrans.Commit()
            ''gk add
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

    Public Function GMSL_DELETE(ByVal pSLNO As String) As Integer
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "GMSL_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

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

    Public Function TCGetDataForStudent(ByVal PADMSNO As Integer, ByVal PBRANCHSLNO As Integer, ByVal PCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            ds = New DataSet

            oConn = ObjConn.GetConnection()
            oCommand.CommandText = "P_TCBOARDSTUDENT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iADMSNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PADMSNO

            oParameter = oCommand.Parameters.Add("iEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANCHSLNO

            oParameter = oCommand.Parameters.Add("iCACYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOMACADEMICSLNO

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
            ObjConn.Free()
        End Try

    End Function

    Public Function TCStudent_Update(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_TCBOARDSTUDENT_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iTCREMARK", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iTCREQUESTEDUSERSLNO", OracleType.Number)
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

#End Region

#Region "TC Generation"

    Public Function P_TCStudentDetails(ByVal pUniqueno As Integer)
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "TC_STUDETAILS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            'iagreeslno
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function

    Public Function P_TCStudentDetailCBSE(ByVal pUniqueno As Integer)
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "TC_STUDETAILSCBSE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            'iagreeslno
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function

    Public Function P_TCgeneration(ByVal pUniqueno As Integer, ByVal pComacademicslno As Integer, ByVal pscholarship As String, ByVal pqualify_iiyear As String, ByVal pqualify_univercity As String, ByVal pconcession As String, ByVal pconduct As String, ByVal pdateofleaving As DateTime, ByVal ptcdate As DateTime, ByVal pboardcollegeslno As Integer, ByVal Pagreeslno As Integer, ByVal tctype As Integer, ByVal ReadingWhenLeavingSlno As Integer, ByVal Bieucs As Integer, ByVal Tcpoint11 As Integer, ByVal iUSERSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            iCommand = New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATETC"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            iCommand.CommandText = "EXAM_TCISSUED_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            oParameter = iCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = iCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno

            oParameter = iCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            oParameter = iCommand.Parameters.Add("ITCTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = oCommand.Parameters.Add("icomacademicslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno


            oParameter = oCommand.Parameters.Add("ischolarship", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pscholarship


            oParameter = oCommand.Parameters.Add("iqualify_iiyear", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_iiyear


            oParameter = oCommand.Parameters.Add("iqualify_univercity", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_univercity


            oParameter = oCommand.Parameters.Add("iconcession", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconcession


            oParameter = oCommand.Parameters.Add("iconduct", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconduct


            oParameter = oCommand.Parameters.Add("idateofleaving", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pdateofleaving

            oParameter = oCommand.Parameters.Add("ITCDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ptcdate

            oParameter = oCommand.Parameters.Add("iboardcollegeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pboardcollegeslno

            oParameter = oCommand.Parameters.Add("iagreeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Pagreeslno

            oParameter = oCommand.Parameters.Add("itctype", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            oParameter = oCommand.Parameters.Add("IREADINGWHENLEAVING", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ReadingWhenLeavingSlno

            oParameter = oCommand.Parameters.Add("IBIEUCS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Bieucs

            oParameter = oCommand.Parameters.Add("IPOINT11", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Tcpoint11

            oParameter = oCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'iagreeslno iRemarks
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "TransferCertificate")

            iCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function P_TCgeneration_Others(ByVal pUniqueno As Integer, ByVal pComacademicslno As Integer, ByVal pscholarship As String, ByVal pqualify_iiyear As String, ByVal pqualify_univercity As String, ByVal pconcession As String, ByVal pconduct As String, ByVal pdateofleaving As DateTime, ByVal ptcdate As DateTime, ByVal pboardcollegeslno As Integer, ByVal Pagreeslno As Integer, ByVal tctype As Integer, ByVal ReadingWhenLeavingSlno As Integer, ByVal Bieucs As Integer, ByVal Tcpoint11 As Integer, ByVal iUSERSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            iCommand = New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATETC_OTHERS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            iCommand.CommandText = "EXAM_TCISSUED_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            oParameter = iCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = iCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno

            oParameter = iCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            oParameter = iCommand.Parameters.Add("ITCTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = oCommand.Parameters.Add("icomacademicslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno


            oParameter = oCommand.Parameters.Add("ischolarship", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pscholarship


            oParameter = oCommand.Parameters.Add("iqualify_iiyear", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_iiyear


            oParameter = oCommand.Parameters.Add("iqualify_univercity", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_univercity


            oParameter = oCommand.Parameters.Add("iconcession", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconcession


            oParameter = oCommand.Parameters.Add("iconduct", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconduct


            oParameter = oCommand.Parameters.Add("idateofleaving", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pdateofleaving

            oParameter = oCommand.Parameters.Add("ITCDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ptcdate

            oParameter = oCommand.Parameters.Add("iboardcollegeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pboardcollegeslno

            oParameter = oCommand.Parameters.Add("iagreeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Pagreeslno

            oParameter = oCommand.Parameters.Add("itctype", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            oParameter = oCommand.Parameters.Add("IREADINGWHENLEAVING", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ReadingWhenLeavingSlno

            oParameter = oCommand.Parameters.Add("IBIEUCS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Bieucs

            oParameter = oCommand.Parameters.Add("IPOINT11", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Tcpoint11

            oParameter = oCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'iagreeslno iRemarks
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "TransferCertificate")

            iCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function P_TCgenerationMumbai(ByVal pUniqueno As Integer, ByVal pComacademicslno As Integer, ByVal pscholarship As String, ByVal pqualify_iiyear As String, ByVal pqualify_univercity As String, ByVal pconcession As String, ByVal pconduct As String, ByVal pdateofleaving As DateTime, ByVal ptcdate As DateTime, ByVal pboardcollegeslno As Integer, ByVal Pagreeslno As Integer, ByVal tctype As Integer, ByVal ReadingWhenLeavingSlno As Integer, ByVal Bieucs As Integer, ByVal Tcpoint11 As Integer, ByVal iUSERSLNO As Integer, ByVal IPROGRESSINSTUDEY As String, ByVal ISTUDYSINCE As String, ByVal IREASONLEAVING As String, ByVal IREMARKS As String, ByVal ICLASSTEACHER As String, ByVal ICLEAR As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            iCommand = New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATETC_MUMBAI"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            iCommand.CommandText = "EXAM_TCISSUED_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            oParameter = iCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = iCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno

            oParameter = iCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            oParameter = iCommand.Parameters.Add("ITCTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = oCommand.Parameters.Add("icomacademicslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno


            oParameter = oCommand.Parameters.Add("ischolarship", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pscholarship


            oParameter = oCommand.Parameters.Add("iqualify_iiyear", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_iiyear


            oParameter = oCommand.Parameters.Add("iqualify_univercity", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_univercity


            oParameter = oCommand.Parameters.Add("iconcession", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconcession


            oParameter = oCommand.Parameters.Add("iconduct", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconduct


            oParameter = oCommand.Parameters.Add("idateofleaving", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pdateofleaving

            oParameter = oCommand.Parameters.Add("ITCDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ptcdate

            oParameter = oCommand.Parameters.Add("iboardcollegeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pboardcollegeslno

            oParameter = oCommand.Parameters.Add("iagreeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Pagreeslno

            oParameter = oCommand.Parameters.Add("itctype", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            oParameter = oCommand.Parameters.Add("IREADINGWHENLEAVING", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ReadingWhenLeavingSlno

            oParameter = oCommand.Parameters.Add("IBIEUCS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Bieucs

            oParameter = oCommand.Parameters.Add("IPOINT11", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Tcpoint11

            oParameter = oCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            oParameter = oCommand.Parameters.Add("IPROGRESSINSTUDEY", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = IPROGRESSINSTUDEY

            oParameter = oCommand.Parameters.Add("ISTUDYSINCE", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ISTUDYSINCE

            oParameter = oCommand.Parameters.Add("IREASONLEAVING", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = IREASONLEAVING

            oParameter = oCommand.Parameters.Add("ICLASSTEACHER", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ICLASSTEACHER

            oParameter = oCommand.Parameters.Add("ICLEAR", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ICLEAR

            'iagreeslno iRemarks
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

            iCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function
    

    Public Function P_TCgenerationCBSE_Dummy(ByVal pUniqueno As Integer, ByVal pComacademicslno As Integer, ByVal pscholarship As String, ByVal pqualify_iiyear As String, ByVal pqualify_univercity As String, ByVal pconcession As String, ByVal pconduct As String, ByVal pdateofleaving As DateTime, ByVal ptcdate As DateTime, ByVal pboardcollegeslno As Integer, ByVal Pagreeslno As Integer, ByVal tctype As Integer, ByVal ReadingWhenLeavingSlno As Integer, ByVal Bieucs As Integer, ByVal Tcpoint11 As Integer, ByVal iUSERSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            iCommand = New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATETCCBSE_DUMMY"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            iCommand.CommandText = "EXAM_TCISSUED_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            oParameter = iCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = iCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno

            oParameter = iCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            oParameter = iCommand.Parameters.Add("ITCTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = oCommand.Parameters.Add("icomacademicslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno


            oParameter = oCommand.Parameters.Add("ischolarship", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pscholarship


            oParameter = oCommand.Parameters.Add("iqualify_iiyear", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_iiyear


            oParameter = oCommand.Parameters.Add("iqualify_univercity", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_univercity


            oParameter = oCommand.Parameters.Add("iconcession", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconcession


            oParameter = oCommand.Parameters.Add("iconduct", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconduct


            oParameter = oCommand.Parameters.Add("idateofleaving", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pdateofleaving

            oParameter = oCommand.Parameters.Add("ITCDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ptcdate

            oParameter = oCommand.Parameters.Add("iboardcollegeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pboardcollegeslno

            oParameter = oCommand.Parameters.Add("iagreeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Pagreeslno

            oParameter = oCommand.Parameters.Add("itctype", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            oParameter = oCommand.Parameters.Add("IREADINGWHENLEAVING", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ReadingWhenLeavingSlno

            oParameter = oCommand.Parameters.Add("IBIEUCS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Bieucs

            oParameter = oCommand.Parameters.Add("IPOINT11", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Tcpoint11

            oParameter = oCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'iagreeslno iRemarks
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "TransferCertificate")

            iCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function
    Public Function P_TCgenerationNewCBSE(ByVal pUniqueno As Integer, ByVal pComacademicslno As Integer, ByVal pscholarship As String, ByVal pqualify_iiyear As String, ByVal pqualify_univercity As String, ByVal pconcession As String, ByVal pconduct As String, ByVal pdateofleaving As DateTime, ByVal ptcdate As DateTime, ByVal pboardcollegeslno As Integer, ByVal Pagreeslno As Integer, ByVal tctype As Integer, ByVal ReadingWhenLeavingSlno As Integer, ByVal Bieucs As Integer, ByVal Tcpoint11 As Integer, ByVal iUSERSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            iCommand = New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATETC_NEWCBSE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            iCommand.CommandText = "EXAM_TCISSUED_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            oParameter = iCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = iCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno

            oParameter = iCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            oParameter = iCommand.Parameters.Add("ITCTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = oCommand.Parameters.Add("icomacademicslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno


            oParameter = oCommand.Parameters.Add("ischolarship", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pscholarship


            oParameter = oCommand.Parameters.Add("iqualify_iiyear", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_iiyear


            oParameter = oCommand.Parameters.Add("iqualify_univercity", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_univercity


            oParameter = oCommand.Parameters.Add("iconcession", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconcession


            oParameter = oCommand.Parameters.Add("iconduct", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconduct


            oParameter = oCommand.Parameters.Add("idateofleaving", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pdateofleaving

            oParameter = oCommand.Parameters.Add("ITCDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ptcdate

            oParameter = oCommand.Parameters.Add("iboardcollegeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pboardcollegeslno

            oParameter = oCommand.Parameters.Add("iagreeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Pagreeslno

            oParameter = oCommand.Parameters.Add("itctype", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            oParameter = oCommand.Parameters.Add("IREADINGWHENLEAVING", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ReadingWhenLeavingSlno

            oParameter = oCommand.Parameters.Add("IBIEUCS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Bieucs

            oParameter = oCommand.Parameters.Add("IPOINT11", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Tcpoint11

            oParameter = oCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'iagreeslno iRemarks
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "TransferCertificate")

            iCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function P_TCgenerationNew(ByVal pUniqueno As Integer, ByVal pComacademicslno As Integer, ByVal pscholarship As String, ByVal pqualify_iiyear As String, ByVal pqualify_univercity As String, ByVal pconcession As String, ByVal pconduct As String, ByVal pdateofleaving As DateTime, ByVal ptcdate As DateTime, ByVal pboardcollegeslno As Integer, ByVal Pagreeslno As Integer, ByVal tctype As Integer, ByVal ReadingWhenLeavingSlno As Integer, ByVal Bieucs As Integer, ByVal Tcpoint11 As Integer, ByVal iUSERSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            iCommand = New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATETC_NEW"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            iCommand.CommandText = "EXAM_TCISSUED_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            oParameter = iCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = iCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno

            oParameter = iCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            oParameter = iCommand.Parameters.Add("ITCTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = oCommand.Parameters.Add("icomacademicslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno


            oParameter = oCommand.Parameters.Add("ischolarship", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pscholarship


            oParameter = oCommand.Parameters.Add("iqualify_iiyear", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_iiyear


            oParameter = oCommand.Parameters.Add("iqualify_univercity", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_univercity


            oParameter = oCommand.Parameters.Add("iconcession", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconcession


            oParameter = oCommand.Parameters.Add("iconduct", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconduct


            oParameter = oCommand.Parameters.Add("idateofleaving", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pdateofleaving

            oParameter = oCommand.Parameters.Add("ITCDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ptcdate

            oParameter = oCommand.Parameters.Add("iboardcollegeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pboardcollegeslno

            oParameter = oCommand.Parameters.Add("iagreeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Pagreeslno

            oParameter = oCommand.Parameters.Add("itctype", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            oParameter = oCommand.Parameters.Add("IREADINGWHENLEAVING", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ReadingWhenLeavingSlno

            oParameter = oCommand.Parameters.Add("IBIEUCS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Bieucs

            oParameter = oCommand.Parameters.Add("IPOINT11", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Tcpoint11

            oParameter = oCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'iagreeslno iRemarks
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "TransferCertificate")

            iCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function P_TCgenerationNew_Others(ByVal pUniqueno As Integer, ByVal pComacademicslno As Integer, ByVal pscholarship As String, ByVal pqualify_iiyear As String, ByVal pqualify_univercity As String, ByVal pconcession As String, ByVal pconduct As String, ByVal pdateofleaving As DateTime, ByVal ptcdate As DateTime, ByVal pboardcollegeslno As Integer, ByVal Pagreeslno As Integer, ByVal tctype As Integer, ByVal ReadingWhenLeavingSlno As Integer, ByVal Bieucs As Integer, ByVal Tcpoint11 As Integer, ByVal iUSERSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            iCommand = New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATETC_NEW_OTHERS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            iCommand.CommandText = "EXAM_TCISSUED_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            oParameter = iCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = iCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno

            oParameter = iCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            oParameter = iCommand.Parameters.Add("ITCTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = oCommand.Parameters.Add("icomacademicslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno


            oParameter = oCommand.Parameters.Add("ischolarship", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pscholarship


            oParameter = oCommand.Parameters.Add("iqualify_iiyear", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_iiyear


            oParameter = oCommand.Parameters.Add("iqualify_univercity", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_univercity


            oParameter = oCommand.Parameters.Add("iconcession", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconcession


            oParameter = oCommand.Parameters.Add("iconduct", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconduct


            oParameter = oCommand.Parameters.Add("idateofleaving", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pdateofleaving

            oParameter = oCommand.Parameters.Add("ITCDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ptcdate

            oParameter = oCommand.Parameters.Add("iboardcollegeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pboardcollegeslno

            oParameter = oCommand.Parameters.Add("iagreeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Pagreeslno

            oParameter = oCommand.Parameters.Add("itctype", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            oParameter = oCommand.Parameters.Add("IREADINGWHENLEAVING", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ReadingWhenLeavingSlno

            oParameter = oCommand.Parameters.Add("IBIEUCS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Bieucs

            oParameter = oCommand.Parameters.Add("IPOINT11", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Tcpoint11

            oParameter = oCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'iagreeslno iRemarks
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "TransferCertificate")

            iCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function P_TCgeneration_Dummy(ByVal pUniqueno As Integer, ByVal pComacademicslno As Integer, ByVal pscholarship As String, ByVal pqualify_iiyear As String, ByVal pqualify_univercity As String, ByVal pconcession As String, ByVal pconduct As String, ByVal pdateofleaving As DateTime, ByVal ptcdate As DateTime, ByVal pboardcollegeslno As Integer, ByVal Pagreeslno As Integer, ByVal tctype As Integer, ByVal ReadingWhenLeavingSlno As Integer, ByVal Bieucs As Integer, ByVal Tcpoint11 As Integer, ByVal iUSERSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            iCommand = New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATETC_DUMMY"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            iCommand.CommandText = "EXAM_TCISSUED_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            oParameter = iCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = iCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno

            oParameter = iCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            oParameter = iCommand.Parameters.Add("ITCTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = oCommand.Parameters.Add("icomacademicslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno


            oParameter = oCommand.Parameters.Add("ischolarship", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pscholarship


            oParameter = oCommand.Parameters.Add("iqualify_iiyear", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_iiyear


            oParameter = oCommand.Parameters.Add("iqualify_univercity", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_univercity


            oParameter = oCommand.Parameters.Add("iconcession", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconcession


            oParameter = oCommand.Parameters.Add("iconduct", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconduct


            oParameter = oCommand.Parameters.Add("idateofleaving", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pdateofleaving

            oParameter = oCommand.Parameters.Add("ITCDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ptcdate

            oParameter = oCommand.Parameters.Add("iboardcollegeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pboardcollegeslno

            oParameter = oCommand.Parameters.Add("iagreeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Pagreeslno

            oParameter = oCommand.Parameters.Add("itctype", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            oParameter = oCommand.Parameters.Add("IREADINGWHENLEAVING", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ReadingWhenLeavingSlno

            oParameter = oCommand.Parameters.Add("IBIEUCS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Bieucs

            oParameter = oCommand.Parameters.Add("IPOINT11", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Tcpoint11

            oParameter = oCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'iagreeslno iRemarks
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "TransferCertificate")

            iCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function



    Public Function P_TCgenerationMUMBAI_Dummy(ByVal pUniqueno As Integer, ByVal pComacademicslno As Integer, ByVal pscholarship As String, ByVal pqualify_iiyear As String, ByVal pqualify_univercity As String, ByVal pconcession As String, ByVal pconduct As String, ByVal pdateofleaving As DateTime, ByVal ptcdate As DateTime, ByVal pboardcollegeslno As Integer, ByVal Pagreeslno As Integer, ByVal tctype As Integer, ByVal ReadingWhenLeavingSlno As Integer, ByVal Bieucs As Integer, ByVal Tcpoint11 As Integer, ByVal iUSERSLNO As Integer, ByVal IPROGRESSINSTUDEY As String, ByVal ISTUDYSINCE As String, ByVal IREASONLEAVING As String, ByVal IREMARKS As String, ByVal ICLASSTEACHER As String, ByVal ICLEAR As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            iCommand = New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATETCMUMBAI_DUMMY"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            iCommand.CommandText = "EXAM_TCISSUED_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            oParameter = iCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = iCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno

            oParameter = iCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            oParameter = iCommand.Parameters.Add("ITCTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = oCommand.Parameters.Add("icomacademicslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno


            oParameter = oCommand.Parameters.Add("ischolarship", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pscholarship


            oParameter = oCommand.Parameters.Add("iqualify_iiyear", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_iiyear


            oParameter = oCommand.Parameters.Add("iqualify_univercity", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_univercity


            oParameter = oCommand.Parameters.Add("iconcession", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconcession


            oParameter = oCommand.Parameters.Add("iconduct", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconduct


            oParameter = oCommand.Parameters.Add("idateofleaving", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pdateofleaving

            oParameter = oCommand.Parameters.Add("ITCDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ptcdate

            oParameter = oCommand.Parameters.Add("iboardcollegeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pboardcollegeslno

            oParameter = oCommand.Parameters.Add("iagreeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Pagreeslno

            oParameter = oCommand.Parameters.Add("itctype", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            oParameter = oCommand.Parameters.Add("IREADINGWHENLEAVING", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ReadingWhenLeavingSlno

            oParameter = oCommand.Parameters.Add("IBIEUCS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Bieucs

            oParameter = oCommand.Parameters.Add("IPOINT11", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Tcpoint11

            oParameter = oCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            oParameter = oCommand.Parameters.Add("IPROGRESSINSTUDEY", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = IPROGRESSINSTUDEY

            oParameter = oCommand.Parameters.Add("ISTUDYSINCE", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ISTUDYSINCE

            oParameter = oCommand.Parameters.Add("IREASONLEAVING", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = IREASONLEAVING

            oParameter = oCommand.Parameters.Add("ICLASSTEACHER", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ICLASSTEACHER

            oParameter = oCommand.Parameters.Add("ICLEAR", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ICLEAR

            'iagreeslno iRemarks
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "TransferCertificate")

            iCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function P_TCSTUDENTS_SELECT(ByVal pCaslno As Integer, ByVal pEbslno As Integer, ByVal pBoardClgSlno As Integer, ByVal pAdmno As String) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAM_EBTCSTUDENTS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCaslno

            oParameter = oCommand.Parameters.Add("IEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEbslno

            oParameter = oCommand.Parameters.Add("IBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBoardClgSlno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function P_TCSTUDENTSCBSE_SELECT(ByVal pCaslno As Integer, ByVal pEbslno As Integer, ByVal pBoardClgSlno As Integer, ByVal pAdmno As String) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAM_EBTCSTUDENTSCBSE_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCaslno

            oParameter = oCommand.Parameters.Add("IEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEbslno

            oParameter = oCommand.Parameters.Add("IBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBoardClgSlno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function P_DTCSTUDENTS_SELECT(ByVal pCaslno As Integer, ByVal pEbslno As Integer, ByVal pBoardClgSlno As Integer, ByVal pAdmno As String) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAM_DEBTCSTUDENTS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCaslno

            oParameter = oCommand.Parameters.Add("IEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEbslno

            oParameter = oCommand.Parameters.Add("IBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBoardClgSlno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function P_DTCSTUDENTS_SELECTChennai(ByVal pCaslno As Integer, ByVal pEbslno As Integer, ByVal pBoardClgSlno As Integer, ByVal pAdmno As String) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAM_EBTC_SELECT_CHENNAI"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCaslno

            oParameter = oCommand.Parameters.Add("IEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEbslno

            oParameter = oCommand.Parameters.Add("IBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBoardClgSlno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function P_DTCSTUDENTS_SELECTBENGALORE(ByVal pCaslno As Integer, ByVal pEbslno As Integer, ByVal pBoardClgSlno As Integer, ByVal pAdmno As String) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAM_EBTCSTUDENTSBANGLORE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCaslno

            oParameter = oCommand.Parameters.Add("IEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEbslno

            oParameter = oCommand.Parameters.Add("IBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBoardClgSlno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function P_TCgenerationNewchennai(ByVal pUniqueno As Integer, ByVal pComacademicslno As Integer, ByVal pboardcollegeslno As Integer, ByVal Pagreeslno As Integer, ByVal tctype As Integer, ByVal iUSERSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            iCommand = New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATETC_CHENNAI"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            iCommand.CommandText = "EXAM_TCISSUED_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            oParameter = iCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = iCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno

            oParameter = iCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            oParameter = iCommand.Parameters.Add("ITCTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            oParameter = oCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = oCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno


            oParameter = oCommand.Parameters.Add("IBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pboardcollegeslno

            oParameter = oCommand.Parameters.Add("IAGREESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Pagreeslno

            oParameter = oCommand.Parameters.Add("ITCTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            oParameter = oCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'iagreeslno iRemarks
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "TransferCertificate")

            iCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function P_TCgeneration_DummyChennai(ByVal pUniqueno As Integer, ByVal pComacademicslno As Integer, ByVal pboardcollegeslno As Integer, ByVal Pagreeslno As Integer, ByVal tctype As Integer, ByVal iUSERSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            iCommand = New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATETC_CHENNAI_DUMMY"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'iCommand.CommandText = "EXAM_TCISSUED_INSERT"
            'iCommand.Connection = oConn
            'iCommand.CommandType = CommandType.StoredProcedure

            oParameter = iCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = iCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno
            oParameter = oCommand.Parameters.Add("IBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pboardcollegeslno

            oParameter = oCommand.Parameters.Add("IAGREESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Pagreeslno

            oParameter = oCommand.Parameters.Add("ITCTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            oParameter = oCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'iagreeslno iRemarks
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "TransferCertificate")

            iCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function
#End Region

#Region " CONDUCT CERTIFICATE"

    Public Function P_CCgeneration(ByVal pUniqueno As Integer, ByVal pSTDYEAR As String, ByVal pACYYEARFROM As String, ByVal pACYYEARTO As String, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATECC"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("ISTDYEAR", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSTDYEAR

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("IACYYEARFROM", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACYYEARFROM

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("IACYYEARTO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACYYEARTO

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO


            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ConductCertificatek")


        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function
    Public Function P_CCgeneration_Dummy(ByVal pUniqueno As Integer, ByVal pSTDYEAR As String, ByVal pACYYEARFROM As String, ByVal pACYYEARTO As String, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATECC_DUMMY"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("ISTDYEAR", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSTDYEAR

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("IACYYEARFROM", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACYYEARFROM

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("IACYYEARTO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACYYEARTO

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO


            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ConductCertificatek")


        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function P_CCgenerationChina(ByVal pUniqueno As Integer, ByVal pSTDYEAR As String, ByVal pACYYEARFROM As String, ByVal pACYYEARTO As String, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATECC_NEW"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("ISTDYEAR", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSTDYEAR

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("IACYYEARFROM", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACYYEARFROM

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("IACYYEARTO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACYYEARTO

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO


            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ConductCertificatek")


        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function P_CCgeneration_DummyCBSE(ByVal pUniqueno As Integer, ByVal pSTDYEAR As String, ByVal pACYYEARFROM As String, ByVal pACYYEARTO As String, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATECCBSE_DUMMY"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("ISTDYEAR", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSTDYEAR

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("IACYYEARFROM", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACYYEARFROM

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("IACYYEARTO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACYYEARTO

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO


            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ConductCertificatek")


        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function P_CCgenerationCBSE(ByVal pUniqueno As Integer, ByVal pSTDYEAR As String, ByVal pACYYEARFROM As String, ByVal pACYYEARTO As String, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATECC_CBSE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("ISTDYEAR", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSTDYEAR

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("IACYYEARFROM", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACYYEARFROM

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("IACYYEARTO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACYYEARTO

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO


            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ConductCertificatek")


        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function P_CCgenerationMumbai(ByVal pUniqueno As Integer, ByVal pSTDYEAR As String, ByVal pACYYEARFROM As String, ByVal pACYYEARTO As String, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATECC_MUMBAI"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("ISTDYEAR", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSTDYEAR

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("IACYYEARFROM", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACYYEARFROM

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("IACYYEARTO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pACYYEARTO

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO


            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ConductCertificatek")


        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function
#Region "Conduct Certificate 4 School By Anil"

    Public Function CONDUCT_STUDENTS_SELECT(ByVal pCaslno As Integer, ByVal pEbslno As Integer, ByVal pBoardClgSlno As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAM_STUCERTSTUDENTS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCaslno

            oParameter = oCommand.Parameters.Add("IEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pEbslno

            oParameter = oCommand.Parameters.Add("ICOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pBoardClgSlno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function School_ConductDetails(ByVal pUniqueno As Integer, ByVal pComacademicslno As Integer)
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "CONDUCT_STUCERT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno


            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno

            'iagreeslno
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function

#End Region

#End Region

#Region " TC REQUEST"

    Public Function TcRequrest(ByVal SpName As String, ByVal Dset As DataSet, ByVal DTable As String, ByVal SqlString1 As String) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = SpName
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlString1

            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output



            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Dset, DTable)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Dset

    End Function

    Public Function TcRequrest1(ByVal SqlString1 As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "PARSE_SQLSTRING1"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlString1

            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
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

    Public Function TcRequest_Save(ByVal DsStudents As DataSet, ByVal pCOMACADEMICSLNO As Integer, ByVal pTcRequestApprovedSlno As Integer) As String

        Dim rtnString As String
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudents) AndAlso DsStudents.Tables("TCREQUEST").Rows.Count > 0 Then
                TcRequestSave(DsStudents, oConn, oTrans, pCOMACADEMICSLNO, pTcRequestApprovedSlno)
            End If

            oTrans.Commit()
            rtnString = "Saved"

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString

    End Function

    Private Function TcRequestSave(ByVal DsStudents As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction, ByVal pCOMACADEMICSLNO As Integer, ByVal pTcRequestApprovedSlno As Integer) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "TCREQUESTAPROLL"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            oParameter = uCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "UNIQUENO"


            oParameter = uCommand.Parameters.Add("iSRNO", OracleType.Number, 6)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TCREQAPPROVED"

            oParameter = uCommand.Parameters.Add("iORIGINAL", OracleType.Number, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TCISSUEDCOUNT"

            oParameter = uCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number, 6)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oParameter = uCommand.Parameters.Add("ITCREQUESTAPPROVEDSLNO", OracleType.Number, 8)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pTcRequestApprovedSlno

            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudents, "TCREQUEST")

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function FillUserWise_TcRequest(ByVal UserSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "USERWISETCREQUESTDATA"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME USERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = UserSLNO


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

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

#End Region

#Region "School Borad Details Entry"

    Public Function Sch_Student_Update(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_BOARDSTUDENT_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iBOARDID", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iBOARDADMNO", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iBOARDNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iFATHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iMOTHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

            oParameter = oCommand.Parameters.Add("iDOB", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iPRV_HTNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iPHPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iMOTHERTONGUESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iMOLE1", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iMOLE2", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iBOARDRELIGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iBOARDCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iBOARDPRVEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iBOARDYOPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iBOARDCATEGORYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iBOARDFIRSTLANGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            oParameter = oCommand.Parameters.Add("iBOARDSECLANGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("iBOARDPHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("iDOJ", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            oParameter = oCommand.Parameters.Add("iJOINEDCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("iBOARDSUBCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)

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
#End Region

    Public Function Sch_TCgeneration(ByVal pUniqueno As Integer, ByVal pComacademicslno As Integer, ByVal pscholarship As String, ByVal pqualify_iiyear As String, ByVal pqualify_univercity As String, ByVal pconcession As String, ByVal pconduct As String, ByVal pdateofleaving As DateTime, ByVal ptcdate As DateTime, ByVal pboardcollegeslno As Integer, ByVal Pagreeslno As Integer, ByVal tctype As Integer, ByVal ReadingWhenLeavingSlno As Integer, ByVal Bieucs As Integer, ByVal Tcpoint11 As Integer, ByVal iUSERSLNO As Integer, ByVal INOD As Integer, ByVal INAD As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            iCommand = New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATETC_NEW"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            iCommand.CommandText = "EXAM_TCISSUED_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            oParameter = iCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = iCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno

            oParameter = iCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            oParameter = iCommand.Parameters.Add("ITCTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = oCommand.Parameters.Add("icomacademicslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno


            oParameter = oCommand.Parameters.Add("ischolarship", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pscholarship


            oParameter = oCommand.Parameters.Add("iqualify_iiyear", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_iiyear


            oParameter = oCommand.Parameters.Add("iqualify_univercity", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_univercity


            oParameter = oCommand.Parameters.Add("iconcession", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconcession


            oParameter = oCommand.Parameters.Add("iconduct", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconduct


            oParameter = oCommand.Parameters.Add("idateofleaving", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pdateofleaving

            oParameter = oCommand.Parameters.Add("ITCDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ptcdate

            oParameter = oCommand.Parameters.Add("iboardcollegeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pboardcollegeslno

            oParameter = oCommand.Parameters.Add("iagreeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Pagreeslno

            oParameter = oCommand.Parameters.Add("itctype", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            oParameter = oCommand.Parameters.Add("IREADINGWHENLEAVING", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ReadingWhenLeavingSlno

            oParameter = oCommand.Parameters.Add("IBIEUCS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Bieucs

            oParameter = oCommand.Parameters.Add("IPOINT11", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Tcpoint11

            oParameter = oCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO



            oParameter = oCommand.Parameters.Add("INAD", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = INAD


            oParameter = oCommand.Parameters.Add("INOD", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = INOD


            'iagreeslno iRemarks
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "TransferCertificate")

            iCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function Student_Bengalore_Update(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "P_BOARDSTUDENT_BANGLORE_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iBOARDADMNO", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iBOARDNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iFATHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iMOTHERNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iNATIONALITY", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iRELIGION", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iCASTE", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iSCHEDULE_CASTE", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iGENDER", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iQUAL_CLASS_WORDS", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iLAST_STUDIED", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iDUES_PAID", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iCONCESSION", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iTOT_WORKDAYS", OracleType.VarChar, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iWORK_DAYSPRE", OracleType.VarChar, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iLASTATTEND", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iCONDUCT", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            oParameter = oCommand.Parameters.Add("iISSUE_CERT", OracleType.VarChar, 25)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            oParameter = oCommand.Parameters.Add("iBOARDCOLLEGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            oParameter = oCommand.Parameters.Add("iDATEOFADMISSION", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("iDOB", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            oParameter = oCommand.Parameters.Add("iSUBJECT1", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("iSUBJECT2", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

            oParameter = oCommand.Parameters.Add("iSUBJECT3", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)

            oParameter = oCommand.Parameters.Add("iSUBJECT4", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)

            oParameter = oCommand.Parameters.Add("iSUBJECT5", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(27)

            oParameter = oCommand.Parameters.Add("iMEDIUM", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(28)

            oParameter = oCommand.Parameters.Add("iSUBCASTE", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(29)

            oParameter = oCommand.Parameters.Add("iSTUDENTSAT", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(30)

            oParameter = oCommand.Parameters.Add("iSTUDENTUNIQNO", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(31)

            oParameter = oCommand.Parameters.Add("iLanguageSecond", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(32)

            oParameter = oCommand.Parameters.Add("iOTHER", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(33)

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


    Public Function P_TCgenerationNewBengalore(ByVal pUniqueno As Integer, ByVal pComacademicslno As Integer, ByVal pscholarship As String, ByVal pqualify_iiyear As String, ByVal pqualify_univercity As String, ByVal pconcession As String, ByVal pconduct As String, ByVal pdateofleaving As DateTime, ByVal ptcdate As DateTime, ByVal pboardcollegeslno As Integer, ByVal Pagreeslno As Integer, ByVal tctype As Integer, ByVal ReadingWhenLeavingSlno As Integer, ByVal Bieucs As Integer, ByVal Tcpoint11 As Integer, ByVal iUSERSLNO As Integer) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            iCommand = New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "GENERATETC_NEWBANGLORE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            iCommand.CommandText = "EXAM_TCISSUED_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            oParameter = iCommand.Parameters.Add("IUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = iCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno

            oParameter = iCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            oParameter = iCommand.Parameters.Add("ITCTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            'ADD IN PARAMETER NAME
            oParameter = oCommand.Parameters.Add("iuniqueno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUniqueno

            oParameter = oCommand.Parameters.Add("icomacademicslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pComacademicslno


            oParameter = oCommand.Parameters.Add("ischolarship", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pscholarship


            oParameter = oCommand.Parameters.Add("iqualify_iiyear", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_iiyear


            oParameter = oCommand.Parameters.Add("iqualify_univercity", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pqualify_univercity


            oParameter = oCommand.Parameters.Add("iconcession", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconcession


            oParameter = oCommand.Parameters.Add("iconduct", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pconduct


            oParameter = oCommand.Parameters.Add("idateofleaving", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pdateofleaving

            oParameter = oCommand.Parameters.Add("ITCDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ptcdate

            oParameter = oCommand.Parameters.Add("iboardcollegeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pboardcollegeslno

            oParameter = oCommand.Parameters.Add("iagreeslno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Pagreeslno

            oParameter = oCommand.Parameters.Add("itctype", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = tctype

            oParameter = oCommand.Parameters.Add("IREADINGWHENLEAVING", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ReadingWhenLeavingSlno

            oParameter = oCommand.Parameters.Add("IBIEUCS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Bieucs

            oParameter = oCommand.Parameters.Add("IPOINT11", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Tcpoint11

            oParameter = oCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'iagreeslno iRemarks
            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "TransferCertificate")

            iCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function
End Class
