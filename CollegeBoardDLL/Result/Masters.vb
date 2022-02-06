Imports System.Data
Imports System.Data.OracleClient
Public Class Masters

#Region "Class Variables"

    Private oConn As OracleConnection  'Connection Object Declaration.
    Private oComm As OracleCommand  'Command Object Declaration.
    Private oAdap As OracleDataAdapter  'Adapter Object Declaration.
    Private oParam As OracleParameter  'Parameter Object Declaration.
    Private Ds As DataSet
    Private ConObj As ResultConn
    Private oTrans As OracleTransaction
    Dim J As Integer
    Private rtnMessage As String
#End Region

#Region "Comman DataSet"

    Public Function DataSet_OneFetch(ByVal SqlString1 As String) As Data.DataSet
        Try
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "PARSE_SQLSTRING1"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1

            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function DataSet_TwoFetch(ByVal SqlString1 As String, ByVal SqlString2 As String) As Data.DataSet
        Try
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "PARSE_SQLSTRING2"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function DataSet_ThreeFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String) As Data.DataSet
        Try
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "PARSE_SQLSTRING3"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString3

            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function DataSet_FoureFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String) As Data.DataSet
        Try
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "PARSE_SQLSTRING4"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString3


            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString4

            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur4", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function DataSet_FiveFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String) As Data.DataSet
        Try
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "PARSE_SQLSTRING5"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString3


            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString4

            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString5

            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur4", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur5", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function DataSet_SixFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String) As Data.DataSet
        Try
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "PARSE_SQLSTRING6"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString3


            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString4

            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString5

            oParam = oComm.Parameters.Add("iSqlString6", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString6

            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur4", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur5", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur6", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function DataSet_SevenFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String, ByVal SqlString7 As String) As Data.DataSet
        Try
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "PARSE_SQLSTRING7"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString3


            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString4

            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString5

            oParam = oComm.Parameters.Add("iSqlString6", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString6

            oParam = oComm.Parameters.Add("iSqlString7", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString7

            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur4", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur5", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur6", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur7", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function DataSet_EightFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String, ByVal SqlString7 As String, ByVal SqlString8 As String) As Data.DataSet
        Try
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "PARSE_SQLSTRING8"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString3


            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString4

            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString5

            oParam = oComm.Parameters.Add("iSqlString6", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString6

            oParam = oComm.Parameters.Add("iSqlString7", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString7

            oParam = oComm.Parameters.Add("iSqlString8", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString8

            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur4", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur5", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur6", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur7", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output


            oParam = oComm.Parameters.Add("DataCur8", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function DataSet_NineFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String, ByVal SqlString7 As String, ByVal SqlString8 As String, ByVal SqlString9 As String) As Data.DataSet
        Try
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "PARSE_SQLSTRING9"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString3


            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString4

            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString5

            oParam = oComm.Parameters.Add("iSqlString6", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString6

            oParam = oComm.Parameters.Add("iSqlString7", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString7

            oParam = oComm.Parameters.Add("iSqlString8", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString8

            oParam = oComm.Parameters.Add("iSqlString9", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString9

            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur4", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur5", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur6", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur7", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output


            oParam = oComm.Parameters.Add("DataCur8", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output


            oParam = oComm.Parameters.Add("DataCur9", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function DataSet_TenFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String, ByVal SqlString7 As String, ByVal SqlString8 As String, ByVal SqlString9 As String, ByVal SqlString10 As String) As Data.DataSet
        Try
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "PARSE_SQLSTRING10"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString3


            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString4

            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString5

            oParam = oComm.Parameters.Add("iSqlString6", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString6

            oParam = oComm.Parameters.Add("iSqlString7", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString7

            oParam = oComm.Parameters.Add("iSqlString8", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString8

            oParam = oComm.Parameters.Add("iSqlString9", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString9

            oParam = oComm.Parameters.Add("iSqlString10", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString10

            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur4", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur5", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur6", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur7", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output


            oParam = oComm.Parameters.Add("DataCur8", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output


            oParam = oComm.Parameters.Add("DataCur9", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur10", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

#End Region

#Region "Insert/Update/Delete Methods"

#Region "ExamType Table"

    Public Function EXAMTYPE_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New ResultConn
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand

            oComm.CommandText = "EXAMMTYPE_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function ExamType_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New ResultConn
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            Ds = New DataSet

            oConn = ConObj.GetConnection()

            oComm.CommandText = "EXAMTYPE_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oParam = New OracleParameter
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function ExamType_Insert(ByVal Arr As ArrayList) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm.CommandText = "EXAMTYPE_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function ExamType_Update(ByVal Arr As ArrayList) As Integer
        Try
            ConObj = New ResultConn
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "EXAMTYPE_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function
#End Region

#Region "ComAcademic Table"

    Public Function COMACADEMIC_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New ResultConn
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand

            oComm.CommandText = "COMACADEMIC_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function COMACADEMIC_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New ResultConn
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            Ds = New DataSet

            oConn = ConObj.GetConnection()

            oComm.CommandText = "COMACADEMIC_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oParam = New OracleParameter
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function COMACADEMIC_Insert(ByVal Arr As ArrayList) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm.CommandText = "COMACADEMIC_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function COMACADEMIC_Update(ByVal Arr As ArrayList) As Integer
        Try
            ConObj = New ResultConn
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "COMACADEMIC_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

#End Region

#Region "Group Table"

    Public Function RESGROUP_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New ResultConn
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand

            oComm.CommandText = "RESGROUP_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESGROUP_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New ResultConn
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            Ds = New DataSet

            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESGROUP_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oParam = New OracleParameter
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESGROUP_Insert(ByVal Arr As ArrayList) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESGROUP_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)


            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESGROUP_Update(ByVal Arr As ArrayList) As Integer
        Try
            ConObj = New ResultConn
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESGROUP_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function
#End Region

#Region "Subject Table"

    Public Function RESSUBJECT_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New ResultConn
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand

            oComm.CommandText = "RESSUBJECT_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESSUBJECT_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New ResultConn
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            Ds = New DataSet

            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESSUBJECT_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oParam = New OracleParameter
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESSUBJECT_Insert(ByVal Arr As ArrayList) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESSUBJECT_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iCODE", OracleType.VarChar, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iREPORTORDER", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESSUBJECT_Update(ByVal Arr As ArrayList) As Integer
        Try
            ConObj = New ResultConn
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESSUBJECT_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iCODE", OracleType.VarChar, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iREPORTORDER", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function
#End Region

#Region "Paper Table"

    Public Function RESPAPER_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New ResultConn
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand

            oComm.CommandText = "RESPAPER_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESPAPER_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New ResultConn
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            Ds = New DataSet

            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESPAPER_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oParam = New OracleParameter
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESPAPER_Insert(ByVal Arr As ArrayList) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESPAPER_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESPAPER_Update(ByVal Arr As ArrayList) As Integer
        Try
            ConObj = New ResultConn
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESPAPER_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function
#End Region

#Region "Corp College Table"

    Public Function RESCORPCOLG_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New ResultConn
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand

            oComm.CommandText = "RESCORPCOLG_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESCORPCOLG_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New ResultConn
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            Ds = New DataSet

            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESCORPCOLG_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oParam = New OracleParameter
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESCORPCOLG_Insert(ByVal Arr As ArrayList) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESCORPCOLG_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESCORPCOLG_Update(ByVal Arr As ArrayList) As Integer
        Try
            ConObj = New ResultConn
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESCORPCOLG_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function
#End Region

#Region "Result Types Table"

    Public Function RESULTTYPE_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New ResultConn
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand

            oComm.CommandText = "RESULTTYPE_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESULTTYPE_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New ResultConn
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            Ds = New DataSet

            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESULTTYPE_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oParam = New OracleParameter
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESULTTYPE_Insert(ByVal Arr As ArrayList) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESULTTYPE_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iCODE", OracleType.VarChar, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)


            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESULTTYPE_Update(ByVal Arr As ArrayList) As Integer
        Try
            ConObj = New ResultConn
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESULTTYPE_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iCODE", OracleType.VarChar, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

#End Region

#Region "Report Table"

    Public Function RESREPORT_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New ResultConn
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand

            oComm.CommandText = "RESREPORT_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESREPORT_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New ResultConn
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            Ds = New DataSet

            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESREPORT_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oParam = New OracleParameter
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESREPORT_Insert(ByVal Arr As ArrayList) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESREPORT_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESREPORT_Update(ByVal Arr As ArrayList) As Integer
        Try
            ConObj = New ResultConn
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESREPORT_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function
#End Region

#Region "Category Table"

    Public Function RESRESCAT_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New ResultConn
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand

            oComm.CommandText = "RESRESCAT_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESRESCAT_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New ResultConn
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            Ds = New DataSet

            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESRESCAT_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oParam = New OracleParameter
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESRESCAT_Insert(ByVal Arr As ArrayList) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESRESCAT_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iRESREPSLNO", OracleType.Number, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESRESCAT_Update(ByVal Arr As ArrayList) As Integer
        Try
            ConObj = New ResultConn
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESRESCAT_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iRESREPSLNO", OracleType.Number, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function
#End Region

#Region "State Table"

    Public Function RESSTATE_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New ResultConn
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand

            oComm.CommandText = "RESSTATE_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESSTATE_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New ResultConn
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            Ds = New DataSet

            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESSTATE_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oParam = New OracleParameter
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESSTATE_Insert(ByVal Arr As ArrayList) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESSTATE_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iSTATESLNO", OracleType.Number, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESSTATE_Update(ByVal Arr As ArrayList) As Integer
        Try
            ConObj = New ResultConn
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESSTATE_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iSTATESLNO", OracleType.Number, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function
#End Region

#Region "Disttict Table"

    Public Function RESDIST_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New ResultConn
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand

            oComm.CommandText = "RESDIST_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESDIST_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New ResultConn
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            Ds = New DataSet

            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESDIST_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oParam = New OracleParameter
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESDIST_Insert(ByVal Arr As ArrayList) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESDIST_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iCODE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iDISTRICTSLNO", OracleType.Number, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iSTATESLNO", OracleType.Number, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESDIST_Update(ByVal Arr As ArrayList) As Integer
        Try
            ConObj = New ResultConn
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESDIST_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iCODE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iDISTRICTSLNO", OracleType.Number, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iSTATESLNO", OracleType.Number, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function
#End Region

#Region "RESULT EXAMTYPE COLUMN Table"

    Public Function RESEXMCOLM_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New ResultConn
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand

            oComm.CommandText = "RESEXMCOLM_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESEXMCOLM_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New ResultConn
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            Ds = New DataSet

            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESEXMCOLM_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oParam = New OracleParameter
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESEXMCOLM_Insert(ByVal Arr As ArrayList) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESEXMCOLM_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iRESEXAMTYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iRESGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iCOLUMNNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iCOLUMNTYPE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESEXMCOLM_Update(ByVal Arr As ArrayList) As Integer
        Try
            ConObj = New ResultConn
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESEXMCOLM_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iRESEXAMTYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iRESGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iCOLUMNNAME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iCOLUMNTYPE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function
#End Region

#Region "RESULT RESULTEXAM  Table"

    Public Function RESEXM_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New ResultConn
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand

            oComm.CommandText = "RESEXM_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESEXM_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New ResultConn
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            Ds = New DataSet

            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESEXM_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oParam = New OracleParameter
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESEXM_Insert(ByVal Arr As ArrayList) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New ResultConn
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESEXM_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'oParam = oComm.Parameters.Add("iRESEXAMSLNO", OracleType.Number)
            'oParam.Direction = ParameterDirection.Input
            'oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iRESEXAMTYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iRESCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iENTSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iREPSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESEXM_Update(ByVal Arr As ArrayList) As Integer
        Try
            ConObj = New ResultConn
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESEXM_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            'oParam = oComm.Parameters.Add("iRESEXAMSLNO", OracleType.Number)
            'oParam.Direction = ParameterDirection.Input
            'oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iRESEXAMTYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iRESCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iENTSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iREPSTATUS", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function
#End Region

#Region "Subjects"
    Public Function RESEXMSUBMAP_Insert(ByVal SPDset As DataSet) As String

        Try
            Dim adap As New OracleDataAdapter
            ConObj = New ResultConn
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oParam = New OracleClient.OracleParameter

            oTrans = oConn.BeginTransaction()
            oComm.Transaction = oTrans
            oComm.CommandText = "RESEXMSUBMAP_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oParam = New OracleParameter

            oParam = oComm.Parameters.Add("iRESEXAMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "RESEXAMSLNO"

            oParam = oComm.Parameters.Add("iRESACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "RESACADEMICSLNO"

            oParam = oComm.Parameters.Add("iRESGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "RESGROUPSLNO"

            oParam = oComm.Parameters.Add("iRESSUBJECTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "RESSUBJECTSLNO"

            oParam = oComm.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SUBJECTSLNO"

            oParam = oComm.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "MAXMARKS"

            oParam = oComm.Parameters.Add("iMINMARKS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "MINMARKS"

            oParam = oComm.Parameters.Add("iRESPAPERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "RESPAPERSLNO"

            oParam = oComm.Parameters.Add("iRESEXAMSUBSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "RESEXAMSUBSLNO"

            oParam = oComm.Parameters.Add("iRESEXAMSUBORDER", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "RESEXAMSUBORDER"

            adap.InsertCommand = oComm
            adap.Update(SPDset, "SUBJECT")

            oTrans.Commit()

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function RESEXMSUBMAP_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New ResultConn
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand

            oComm.CommandText = "RESEXMSUBMAP_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESEXMSUBMAP_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New ResultConn
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            Ds = New DataSet

            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESEXMSUBMAP_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oParam = New OracleParameter
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function RESEXMSUBMAP_Update(ByVal SPDset As DataSet) As String
        Try
            Dim adap As New OracleDataAdapter
            ConObj = New ResultConn
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "RESEXMSUBMAP_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "RESEXAMGRPSUBMAPSLNO"

            oParam = oComm.Parameters.Add("iRESEXAMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "RESEXAMSLNO"

            oParam = oComm.Parameters.Add("iRESACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "RESACADEMICSLNO"

            oParam = oComm.Parameters.Add("iRESGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "RESGROUPSLNO"

            oParam = oComm.Parameters.Add("iRESSUBJECTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "RESSUBJECTSLNO"

            oParam = oComm.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SUBJECTSLNO"

            oParam = oComm.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "MAXMARKS"

            oParam = oComm.Parameters.Add("iMINMARKS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "MINMARKS"

            oParam = oComm.Parameters.Add("iRESPAPERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "RESPAPERSLNO"

            oParam = oComm.Parameters.Add("iRESEXAMSUBSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "RESEXAMSUBSLNO"

            oParam = oComm.Parameters.Add("iRESEXAMSUBORDER", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "RESEXAMSUBORDER"

            adap.UpdateCommand = oComm
            adap.Update(SPDset, "SUBJECT")

            oTrans.Commit()

            Return 1
            'oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function
#End Region

#End Region

End Class
