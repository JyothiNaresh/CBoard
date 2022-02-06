'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating SOCIETY
'   ACTIVITY                          : 
'   AUTHOR                            : G KISHORE
'   INITIAL BASELINE DATE             : 11-JAN-2012
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration
Public Class ClsBoarddt

#Region "Class Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As New OracleClient.OracleCommand
    Private oParameter As New OracleClient.OracleParameter
    Private oAdapter As New OracleClient.OracleDataAdapter
    Private OraTrans As OracleTransaction
    Dim ds As New Data.DataSet
    Private oTrans As OracleTransaction
    Private ObjConn As Connection

#End Region

#Region "Society Methods"

    Public Function SOCIETY_DELETE(ByVal pSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "SOCIETY_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

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
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function SOCIETY_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oAdapter = New OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "SOCIETY_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oParameter = New OracleParameter

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

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

    Public Function SOCIETY_Insert(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "SOCIETY_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iREGISTERED_NO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iREGISTERED_DATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iSOCT_NAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iADDRESS1", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iADDRESS2", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iCORRESPONDENTNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iMOBILE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)


            oParameter = oCommand.Parameters.Add("iYEAROFSTART", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iAFFILT_EXT_UPTO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)


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

    Public Function SOCIETY_Update(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand


            oCommand.CommandText = "SOCIETY_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iREGISTERED_NO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iREGISTERED_DATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iSOCT_NAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iADDRESS1", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iADDRESS2", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iCORRESPONDENTNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iMOBILE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)


            oParameter = oCommand.Parameters.Add("iYEAROFSTART", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iAFFILT_EXT_UPTO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

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

#Region "SOCIETY COLLEGE MAP"

    Public Function SocietyCollegeMap1(ByVal SpName As String, ByVal Dset As DataSet, ByVal DTable As String, ByVal Arr As ArrayList) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = SpName
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter 
            oParameter = oCommand.Parameters.Add("iFLAG", OracleType.Number, 6)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            If Arr(0) = 1 Then
                oParameter = oCommand.Parameters.Add("iSOCNAME", OracleType.VarChar)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = Arr(1)

                oParameter = oCommand.Parameters.Add("iDISTSLNO", OracleType.Number, 6)
                oParameter.Direction = ParameterDirection.Input
                oParameter.Value = Arr(2)

            End If

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Dset, DTable) '"SOCIETY")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Dset

    End Function

    Public Function SocietyCollegeMap(ByVal SpName As String, ByVal Dset As DataSet, ByVal DTable As String) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = SpName
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            ''--- NEW ADD iFLAG
            ''Add In Parameter 
            ''oParameter = oCommand.Parameters.Add("iFLAG", OracleType.Number, 6)
            ''oParameter.Direction = ParameterDirection.Input
            ''oParameter.SourceColumn = "FLAG"

            'oParameter = oCommand.Parameters.Add("iSOCNAME", OracleType.VarChar)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "SOCNAME"

            'oParameter = oCommand.Parameters.Add("iDISTSLNO", OracleType.Number, 6)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "DISTSLNO"

            ''--- NEW ADD 

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output




            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Dset, DTable) '"SOCIETY")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Dset

    End Function

    Public Function SocTaget_Save(ByVal DsStudents As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudents) AndAlso DsStudents.Tables("SOCIETY").Rows.Count > 0 Then
                SocietyTargetSave(DsStudents, oConn, oTrans)
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

    Private Function SocietyTargetSave(ByVal DsStudents As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "SOCIETY_COLLOGE_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iADDRESSSLNO
            oParameter = uCommand.Parameters.Add("iCCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CODE"


            'Add In Parameter as iPHONE1
            oParameter = uCommand.Parameters.Add("iSRNO", OracleType.Number, 6)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SOCIETY_REGISTER_NO"


            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudents, "SOCIETY")

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function SOC_CLG_MAP_Insert(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "SOC_CLG_MAP_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iSOCITYSLNO
            oParameter = oCommand.Parameters.Add("iSOCITYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'Add In Parameter as iCCODE
            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            'Add In Parameter as iCLGNAME
            oParameter = oCommand.Parameters.Add("iCLGNAME", OracleType.VarChar, 50)
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

    Public Function SOC_CLG_MAP_DELETE(ByVal pSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "SOCIETY_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

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
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function SOC_CLG_MAP_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oAdapter = New OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "SOCIETY_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oParameter = New OracleParameter

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

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

    Public Function SOC_CLG_MAP_Insert1(ByVal DsStudents As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudents) AndAlso DsStudents.Tables("SOCTCLG").Rows.Count > 0 Then
                SOC_CLG_MAP_SAVE(DsStudents, oConn, oTrans)
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

    Private Function SOC_CLG_MAP_SAVE(ByVal DsStudents As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "SOC_CLG_MAP_INSERT"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as iSOCITYSLNO
            oParameter = uCommand.Parameters.Add("iSOCITYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SOCITYSLNO"

            'Add In Parameter as iCCODE
            oParameter = uCommand.Parameters.Add("iCCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CCODE"


            'Add In Parameter as iCLGNAME
            oParameter = uCommand.Parameters.Add("iCLGNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CLGNAME"


            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudents, "SOCTCLG")

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function COLLEGESOCIETYMAP(ByVal SpName As String, ByVal Dset As DataSet, ByVal DTable As String, ByVal SqlString1 As String) As DataSet
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


            ''ADD IN PARAMETER NAME iDISTSLNO
            'oParameter = oCommand.Parameters.Add("iDISTSLNO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = iDISTSLNO


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Dset, DTable) '"Society")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Dset

    End Function

    Public Function COLLEGESOCIETYMAPK(ByVal SqlString1 As String) As Data.DataSet
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
#End Region

#Region "Section Methods"

    Public Function Secction_DELETE(ByVal pSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "SECTIONS_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

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
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function Secction_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oAdapter = New OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "SECTIONS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oParameter = New OracleParameter

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

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

    Public Function Secction_Insert(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "SECTIONS_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iORG_SCIENCE_SEC", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iORG_ARTS_SEC", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iORG_TOTAL_SEC", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iADD_SCIENCE_SEC", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iADD_ARTS_SEC", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iADD_TOTAL_SEC", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)


            oParameter = oCommand.Parameters.Add("iGRANDTOTAL", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

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

    Public Function Secction_Update(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand


            oCommand.CommandText = "SECTIONS_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iORG_SCIENCE_SEC", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iORG_ARTS_SEC", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iORG_TOTAL_SEC", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iADD_SCIENCE_SEC", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iADD_ARTS_SEC", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iADD_TOTAL_SEC", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)


            oParameter = oCommand.Parameters.Add("iGRANDTOTAL", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

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

#Region "Building PG Methods"

    Public Function BLDPG_DELETE(ByVal pSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "BLDPG_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

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
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function



    Public Function BRDCOL_DELETE(ByVal pSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "BRDCOL_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.Number)
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

    Public Function BLDPG_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oAdapter = New OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "BLDPG_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oParameter = New OracleParameter

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

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

    Public Function BRDCOL_SELECT(ByVal pSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oAdapter = New OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "BRDCOL_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oParameter = New OracleParameter

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

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

    Public Function BLDPG_Insert(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "BLDPG_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iBUILDING", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iBLD_RL_PERIOD_FROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iBLD_RL_PERIOD_TO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iPLINTH_AREA", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iPLAYGROUNDTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iPG_RL_PERIOD_FROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iPG_RL_PERIOD_TO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)


            oParameter = oCommand.Parameters.Add("iLANDTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iDIST_PG", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)


            oParameter = oCommand.Parameters.Add("iPARK_AREA", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iBUILDINGTYPE", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)


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

    Public Function BLDPG_Update(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand


            oCommand.CommandText = "BLDPG_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iBUILDING", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iBLD_RL_PERIOD_FROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iBLD_RL_PERIOD_TO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iPLINTH_AREA", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iPLAYGROUNDTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iPG_RL_PERIOD_FROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iPG_RL_PERIOD_TO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)


            oParameter = oCommand.Parameters.Add("iLANDTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iDIST_PG", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)


            oParameter = oCommand.Parameters.Add("iPARK_AREA", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)



            oParameter = oCommand.Parameters.Add("iBUILDINGTYPE", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)


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


    Public Function BRDCOL_Update(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand


            oCommand.CommandText = "BRDCOL_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

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

#Region "Certificates PG Methods"

    Public Function CERTIFICT_DELETE(ByVal pSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "CERTIFICATE_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

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
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function CERTIFICT_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oAdapter = New OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "CERTIFICATE_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oParameter = New OracleParameter

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

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

    Public Function CERTIFICT_SelectNew(ByVal pSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oAdapter = New OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "CERTIFICATE_SELECTNEW"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oParameter = New OracleParameter

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

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

    Public Function CERTIFICT_Insert(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "CERTIFICATE_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iFIRESLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iSANITORYSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iSTRUCTURALSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iNOCSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iFIRESLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iSANITORYSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iSTRUCTURALSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iNOCSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)


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

    Public Function CERTIFICT_Update(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand


            oCommand.CommandText = "CERTIFICATE_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iFIRESLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iSANITORYSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iSTRUCTURALSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iNOCSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iFIRESLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iSANITORYSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iSTRUCTURALSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iNOCSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)


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

    Public Function CERTIFICT_InsertNew(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "CERTIFICATE_INSERTNEW"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iFIRESLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iSANITORYSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iSTRUCTURALSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iNOCSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iFIRESLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iSANITORYSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iSTRUCTURALSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iNOCSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iFIREFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iFIRETO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iSANITORYFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iSANITORYTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iSTRUCTURALFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iSTRUCTURALTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iNOCFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iNOCTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)


            oParameter = oCommand.Parameters.Add("iAcadamicAff", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("iAcadamicAffsub", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            oParameter = oCommand.Parameters.Add("iAcadamicafffrom", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            oParameter = oCommand.Parameters.Add("iAcadamicaffto", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            oParameter = oCommand.Parameters.Add("iSectionAddsec", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("iSectionsubadd", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            oParameter = oCommand.Parameters.Add("iSectionfrom", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("iSectionTo", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

            oParameter = oCommand.Parameters.Add("iReglease", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)

            oParameter = oCommand.Parameters.Add("iRegleasesub", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)

            oParameter = oCommand.Parameters.Add("iLeasefrom", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(27)

            oParameter = oCommand.Parameters.Add("iLeaseto", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(28)

            oParameter = oCommand.Parameters.Add("iFdr", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(29)

            oParameter = oCommand.Parameters.Add("iFdrsub", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(30)

            oParameter = oCommand.Parameters.Add("iFdrfrom", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(31)

            oParameter = oCommand.Parameters.Add("iFdrto", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(32)

         

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

    Public Function CERTIFICT_UpdateNew(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand


            oCommand.CommandText = "CERTIFICATE_UPDATENEW"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iFIRESLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iSANITORYSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iSTRUCTURALSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iNOCSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iFIRESLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iSANITORYSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iSTRUCTURALSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iNOCSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iFIREFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iFIRETO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iSANITORYFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iSANITORYTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iSTRUCTURALFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iSTRUCTURALTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iNOCFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            oParameter = oCommand.Parameters.Add("iNOCTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("IACADAMICAFF", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            oParameter = oCommand.Parameters.Add("IACADAMICAFFSUB", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            oParameter = oCommand.Parameters.Add("IACADAMICAFFFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            oParameter = oCommand.Parameters.Add("IACADAMICAFFTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("ISECTIONADDSEC", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            oParameter = oCommand.Parameters.Add("ISECTIONSUBADD", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("ISECTIONFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)

            oParameter = oCommand.Parameters.Add("ISECTIONTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)

            oParameter = oCommand.Parameters.Add("IREGLEASE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)

            oParameter = oCommand.Parameters.Add("IREGLEASESUB", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(27)

            oParameter = oCommand.Parameters.Add("ILEASEFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(28)

            oParameter = oCommand.Parameters.Add("ILEASETO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(29)

            oParameter = oCommand.Parameters.Add("IFDR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(30)

            oParameter = oCommand.Parameters.Add("IFDRSUB", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(31)

            oParameter = oCommand.Parameters.Add("IFDRFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(32)

            oParameter = oCommand.Parameters.Add("IFDRTO", OracleType.DateTime)
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





    Public Function CERTIFICT_InsertNewSCHOOL(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "CERTIFICATE_INSERTNEW"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iFIRESLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iSANITORYSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iTRAFFICSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iNOCSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)


            oParameter = oCommand.Parameters.Add("iPLAYGROUND1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iADDSEC1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iLEASE1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iBUILDING1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iSKETCH1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iPP1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)
            oParameter = oCommand.Parameters.Add("iOF1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)
            oParameter = oCommand.Parameters.Add("iST1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)
            oParameter = oCommand.Parameters.Add("iAMOUNT1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)


            oParameter = oCommand.Parameters.Add("iFIRESLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iSANITORYSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            oParameter = oCommand.Parameters.Add("iTRAFFIC2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("iNOCSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            oParameter = oCommand.Parameters.Add("iPLAYGROUND2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            oParameter = oCommand.Parameters.Add("iADDSEC2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            oParameter = oCommand.Parameters.Add("iLEASE2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("iBUILDING2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            oParameter = oCommand.Parameters.Add("iSKETCH2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("iPP2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)
            oParameter = oCommand.Parameters.Add("iOF2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)
            oParameter = oCommand.Parameters.Add("iST2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)
            oParameter = oCommand.Parameters.Add("iAMOUNT2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(27)

            oParameter = oCommand.Parameters.Add("iFIREFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(28)

            oParameter = oCommand.Parameters.Add("iFIRETO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(29)

            oParameter = oCommand.Parameters.Add("iSANITORYFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(30)

            oParameter = oCommand.Parameters.Add("iSANITORYTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(31)

            oParameter = oCommand.Parameters.Add("iTRAFFICFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(32)

            oParameter = oCommand.Parameters.Add("iTRAFFICFTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(33)

            oParameter = oCommand.Parameters.Add("iNOCFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(34)

            oParameter = oCommand.Parameters.Add("iNOCTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(35)

            oParameter = oCommand.Parameters.Add("IPLAYGROUNDFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(36)

            oParameter = oCommand.Parameters.Add("IPLAYGROUNDTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(37)

            oParameter = oCommand.Parameters.Add("IADDSECFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(38)

            oParameter = oCommand.Parameters.Add("IADDSECTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(39)

            oParameter = oCommand.Parameters.Add("ILEASEFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(40)

            oParameter = oCommand.Parameters.Add("ILEASETO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(41)

            oParameter = oCommand.Parameters.Add("IBUILDINGFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(42)

            oParameter = oCommand.Parameters.Add("IBUILDINGTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(43)

            oParameter = oCommand.Parameters.Add("ISKETCHFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(44)

            oParameter = oCommand.Parameters.Add("ISKETCHTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(45)

            oParameter = oCommand.Parameters.Add("IPPFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(46)

            oParameter = oCommand.Parameters.Add("IPPTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(47)

            oParameter = oCommand.Parameters.Add("IOFFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(48)

            oParameter = oCommand.Parameters.Add("IOFTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(49)

            oParameter = oCommand.Parameters.Add("ISTFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(50)

            oParameter = oCommand.Parameters.Add("ISTTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(51)

            oParameter = oCommand.Parameters.Add("IAMOUNTFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(52)

            oParameter = oCommand.Parameters.Add("IAMOUNTTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(53)



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

    Public Function CERTIFICT_UpdateNewSCHOOL(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand


            oCommand.CommandText = "CERTIFICATE_UPDATENEW"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iFIRESLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iSANITORYSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iTRAFFICSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iNOCSLNO1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)


            oParameter = oCommand.Parameters.Add("iPLAYGROUND1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iADDSEC1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iLEASE1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("BUILDING1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("SKETCH1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("PP1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)
            oParameter = oCommand.Parameters.Add("OF1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)
            oParameter = oCommand.Parameters.Add("ST1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)
            oParameter = oCommand.Parameters.Add("AMOUNT1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)


            oParameter = oCommand.Parameters.Add("iFIRESLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

            oParameter = oCommand.Parameters.Add("iSANITORYSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

            oParameter = oCommand.Parameters.Add("iTRAFFIC2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(17)

            oParameter = oCommand.Parameters.Add("iNOCSLNO2", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(18)

            oParameter = oCommand.Parameters.Add("iPLAYGROUND1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(19)

            oParameter = oCommand.Parameters.Add("iADDSEC1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(20)

            oParameter = oCommand.Parameters.Add("iLEASE1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(21)

            oParameter = oCommand.Parameters.Add("BUILDING1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(22)

            oParameter = oCommand.Parameters.Add("SKETCH1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(23)

            oParameter = oCommand.Parameters.Add("PP1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(24)
            oParameter = oCommand.Parameters.Add("OF1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(25)
            oParameter = oCommand.Parameters.Add("ST1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(26)
            oParameter = oCommand.Parameters.Add("AMOUNT1", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(27)

            oParameter = oCommand.Parameters.Add("iFIREFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(28)

            oParameter = oCommand.Parameters.Add("iFIRETO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(29)

            oParameter = oCommand.Parameters.Add("iSANITORYFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(30)

            oParameter = oCommand.Parameters.Add("iSANITORYTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(31)

            oParameter = oCommand.Parameters.Add("iTRAFFICFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(32)

            oParameter = oCommand.Parameters.Add("iTRAFFICFTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(33)

            oParameter = oCommand.Parameters.Add("iNOCFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(34)

            oParameter = oCommand.Parameters.Add("iNOCTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(35)

            oParameter = oCommand.Parameters.Add("IPLAYGROUNDFROM", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(36)

            oParameter = oCommand.Parameters.Add("IPLAYGROUNDTO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(37)

            oParameter = oCommand.Parameters.Add("IADDSECFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(38)

            oParameter = oCommand.Parameters.Add("IADDSECTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(39)

            oParameter = oCommand.Parameters.Add("ILEASEFROM", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(40)

            oParameter = oCommand.Parameters.Add("ILEASETO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(41)

            oParameter = oCommand.Parameters.Add("IBUILDINGFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(42)

            oParameter = oCommand.Parameters.Add("IBUILDINGTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(43)

            oParameter = oCommand.Parameters.Add("ISKETCHFROM", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(44)

            oParameter = oCommand.Parameters.Add("ISKETCHTO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(45)

            oParameter = oCommand.Parameters.Add("IPPFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(46)

            oParameter = oCommand.Parameters.Add("IPPTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(47)

            oParameter = oCommand.Parameters.Add("IOFFROM", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(48)

            oParameter = oCommand.Parameters.Add("IOFTO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(49)

            oParameter = oCommand.Parameters.Add("ISTFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(50)

            oParameter = oCommand.Parameters.Add("ISTTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(51)

            oParameter = oCommand.Parameters.Add("IAMOUNTFROM", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(52)

            oParameter = oCommand.Parameters.Add("IAMOUNTTO", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(53)
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

#Region "Penalties PG Methods"

    Public Function PENALTY_DELETE(ByVal pSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "PENALTY_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

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
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function PENALTY_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oAdapter = New OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "PENALTY_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oParameter = New OracleParameter

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

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

    Public Function PENALTY_Insert(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "PENALTY_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iSHIFTING", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iSHIFTING_PEN_AMT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iSOC_NAME_CHANGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iSOC_NAME_CH_AMT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iCOURT_CASES", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iCOURT_CASES_AMT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)


            oParameter = oCommand.Parameters.Add("iRESTART", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iRESTART_AMT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)


            oParameter = oCommand.Parameters.Add("iPENT_YEAR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iPENT_IMPOSED", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iPENT_PAID", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iPENT_DUE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)


            oParameter = oCommand.Parameters.Add("iCLG_CH_NAME", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iCLG_PEN_AMT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

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

    Public Function PENALTY_Update(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand


            oCommand.CommandText = "PENALTY_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iSHIFTING", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iSHIFTING_PEN_AMT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iSOC_NAME_CHANGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iSOC_NAME_CH_AMT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iCOURT_CASES", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iCOURT_CASES_AMT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)


            oParameter = oCommand.Parameters.Add("iRESTART", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iRESTART_AMT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)


            oParameter = oCommand.Parameters.Add("iPENT_YEAR", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iPENT_IMPOSED", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iPENT_PAID", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iPENT_DUE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iCLG_CH_NAME", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iCLG_PEN_AMT", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)

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

#Region "FDR Methods"

    Public Function FDR_DELETE(ByVal pSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "FDR_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

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
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function FDR_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oAdapter = New OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "FDR_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oParameter = New OracleParameter

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

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

    Public Function FDR_Insert(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "FDR_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iFDRNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iFDRACNO", OracleType.VarChar, 16)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iMATURITY_AMT", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iRATEOF_INT", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iBANKNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iAMOUNT", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iFDRDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iMATURITY_DATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)


            oParameter = oCommand.Parameters.Add("iFDRRELEASE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iRELEASEDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

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

    Public Function FDR_Update(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand


            oCommand.CommandText = "FDR_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iFDRNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iFDRACNO", OracleType.VarChar, 16)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iMATURITY_AMT", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iRATEOF_INT", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iBANKNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iAMOUNT", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iFDRDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iMATURITY_DATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iFDRRELEASE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iRELEASEDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

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

#Region "Affilation PG Methods"

    Public Function AFFLT_DELETE(ByVal pSLNO As Integer) As Integer
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "AFFL_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

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
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function AFFLT_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oAdapter = New OracleDataAdapter

            ds = New DataSet

            oCommand.CommandText = "AFFL_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oParameter = New OracleParameter

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNO

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

    Public Function AFFLT_Insert(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand

            oCommand.CommandText = "AFFL_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iMAG_AMONT", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iDUE_MAG_AMT", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iSURPLUS_BIE_AMT", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iAFFYEAR", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iAPPLICATION_FEE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iORG_SEC_FEE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)


            oParameter = oCommand.Parameters.Add("iADD_SEC_FEE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("iINSP_FEE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)


            oParameter = oCommand.Parameters.Add("iLATE_FEE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)

            oParameter = oCommand.Parameters.Add("iPAY_TYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iDD_NO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iDD_DATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)


            oParameter = oCommand.Parameters.Add("iDD_AMT", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)

            oParameter = oCommand.Parameters.Add("iAFFEXTDUPTO", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iBANKNAME", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)


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

    Public Function AFFLT_Update(ByVal Arr As ArrayList) As Integer
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oCommand = New OracleCommand


            oCommand.CommandText = "AFFL_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iCCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iMAG_AMONT", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iDUE_MAG_AMT", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iSURPLUS_BIE_AMT", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iAFFYEAR", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iAPPLICATION_FEE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("iORG_SEC_FEE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)


            oParameter = oCommand.Parameters.Add("iADD_SEC_FEE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oParameter = oCommand.Parameters.Add("iINSP_FEE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(9)


            oParameter = oCommand.Parameters.Add("iLATE_FEE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(10)

            oParameter = oCommand.Parameters.Add("iPAY_TYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(11)

            oParameter = oCommand.Parameters.Add("iDD_NO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(12)

            oParameter = oCommand.Parameters.Add("iDD_DATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(13)


            oParameter = oCommand.Parameters.Add("iDD_AMT", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(14)

            oParameter = oCommand.Parameters.Add("iAFFEXTDUPTO", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(15)


            oParameter = oCommand.Parameters.Add("iBANKNAME", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(16)

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

#Region " School_TC"

    Public Function BOARDSCHTCDETAILS_INSERT(ByVal Arr As ArrayList) As Integer
        Try
            oCommand = New OracleCommand
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "BOARD_SCH_TCDET_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iTCBOOKNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iTCNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("iTCFILEPATH", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("iINSUPD", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oCommand.ExecuteNonQuery()

            Return 1

        Catch ex As Exception

        End Try
    End Function

    Public Function BOARDSCHTCREQUEST_ERA(ByVal Arr As ArrayList) As Integer
        Try
            oCommand = New OracleCommand
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "SCHOOLTC_REQUEST_DT_ERA"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("IREQENTRYUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("IREQENTRY_DESC", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oParameter = oCommand.Parameters.Add("IREQREJECTUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            oParameter = oCommand.Parameters.Add("IREQREJECT_DESC", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)

            oParameter = oCommand.Parameters.Add("IREQAPPROVEDUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)

            oParameter = oCommand.Parameters.Add("IERA", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oCommand.ExecuteNonQuery()

            Return 1

        Catch ex As Exception

        End Try
    End Function

    Public Function PATH_SAVE(ByVal pQuery As String) As String
        Dim rtnString As String
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()


            rtnString = IMG_PATH_Save(pQuery, oConn, oTrans)
            oTrans.Commit()




        Catch ex As Exception
            oTrans.Rollback()
            'rtnString = ex.Message.ToString
            Throw ex
            'rtnString = "Set Not Saved"
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

    Private Function IMG_PATH_Save(ByVal pDEXAMSLNO As String, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oCommand = New OracleCommand
            oCommand.CommandText = "EXAM_PRGSENT_UPD"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iQUERY", OracleType.VarChar, 500)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO



            oCommand.ExecuteNonQuery()
            Return 1
        Catch ORAEX As OracleException
            Throw ORAEX
        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

End Class
