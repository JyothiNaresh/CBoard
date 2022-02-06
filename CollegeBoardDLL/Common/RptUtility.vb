'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is the Middle layer for Utility For Reports.
'   ACTIVITY                          : ---------
'   AUTHOR                            : A.SURENDAR REDDY
'   INITIAL BASELINE DATE             : 14-NOV-2006
'   FINAL BASELINE DATE               : 14-NOV-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------

Imports System.Data
Imports System.Data.OracleClient

Public Class RptUtility

#Region "Class Variables"

    Private oConn As OracleConnection  'Connection Object Declaration.
    Private oComm As OracleCommand  'Command Object Declaration.
    Private oAdap As OracleDataAdapter  'Adapter Object Declaration.
    Private oParam As OracleParameter  'Parameter Object Declaration.
    Private Ds As DataSet
    Private ConObj As ReportConnection
    Private oTrans As OracleTransaction

#End Region

#Region "Methods"

    Public Function TopperSelection_Save(ByVal sQuery As String, ByVal iCOMBINATIONKEY As Integer) As String
        'by prakash on oct 23'07 for toppers selection report 
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection


            oAdap = New OracleDataAdapter
            oComm = New OracleCommand

            oTrans = oConn.BeginTransaction()
            oComm.Transaction = oTrans


            oComm.CommandText = "P_TOPSEL_INS"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure
            oComm.Transaction = oTrans


            oParam = oComm.Parameters.Add("iQUERY", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = sQuery

            oParam = oComm.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMBINATIONKEY

            oComm.ExecuteNonQuery()

            oTrans.Commit()
            TopperSelection_Save = "SUCCESS"
        Catch ORAEX As OracleException
            oTrans.Rollback()
            Throw ORAEX
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function ExamGetStudenAdmslnoUniqueNo(ByVal iEXAMBRANCHSLNO As Integer, ByVal iADMSNO As String, ByVal iCOMACADEMICSLNO As Integer) As String

        Try

            Dim Result As String

            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection 'establishing the Connection .


            oComm = New OracleCommand
            oComm.CommandText = "EXAM_UNIQUENO_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParam = oComm.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iEXAMBRANCHSLNO


            'ADD IN PARAMETER NAME iADMNO
            oParam = oComm.Parameters.Add("iADMSNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iADMSNO


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO


            oComm.Parameters.Add(New OracleParameter("oRtnValid", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()

            Result = oComm.Parameters("oRtnValid").Value
            Return Result


        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try



    End Function

    Public Function GetStudenAdmslnoUniqNo(ByVal iADMNO As String, ByVal iCOMACADEMICSLNO As Integer) As String

        Try

            Dim Result As String

            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection 'establishing the Connection .


            oComm = New OracleCommand
            oComm.CommandText = "EXAM_GETSUNIQUENO_SELET"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iADMNO
            oParam = oComm.Parameters.Add("iADMNO", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iADMNO


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO


            oComm.Parameters.Add(New OracleParameter("oRtnValid", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()

            Result = oComm.Parameters("oRtnValid").Value
            Return Result


        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try



    End Function


    Public Function DataSet_Fetch(ByVal pSqlString As String) As Data.DataSet
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "PARSE_SQLSTRING"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSqlString", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSqlString

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

    Public Function FillPayModes_Fetch(ByVal TransType As String) As Data.DataSet
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "M_TRANSPAYMODE_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iTRANSTYPE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = TransType

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

    Public Function FillBranchUserWise_Fetch(ByVal COMACADEMICSLNO As Integer, ByVal UserSLNO As Integer) As Data.DataSet
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "M_USERWISEBRANCH_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = UserSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COMACADEMICSLNO

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

    Public Function FillBranchAll_Fetch(ByVal COMACADEMICSLNO As Integer) As Data.DataSet
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "M_BRANCHALL_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COMACADEMICSLNO

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

    Public Function FillZoneUserWise_Fetch(ByVal COMACADEMICSLNO As Integer, Optional ByVal UserSLNO As Integer = 0) As Data.DataSet
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "M_USERWISEZONE_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = UserSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COMACADEMICSLNO

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

    Public Function FillRegionUserWise_Fetch(ByVal COMACADEMICSLNO As Integer, Optional ByVal UserSLNO As Integer = 0) As Data.DataSet
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "M_USERWISEREGION_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = UserSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COMACADEMICSLNO

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

    Public Function FillUserWise_ExamBranch(ByVal UserSLNO As Integer) As Data.DataSet
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "USERWISEEB"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME USERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = UserSLNO

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

#End Region

#Region "Comman DataSet"

    Public Function DataSet_OneFetch(ByVal SqlString1 As String) As Data.DataSet
        Try
            ConObj = New ReportConnection
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
            ConObj = New ReportConnection
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
            ConObj = New ReportConnection
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
            ConObj = New ReportConnection
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
            ConObj = New ReportConnection
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
            ConObj = New ReportConnection
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
            ConObj = New ReportConnection
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
            ConObj = New ReportConnection
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
            ConObj = New ReportConnection
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
            ConObj = New ReportConnection
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

    Public Function DataSet_ThirteenFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String, ByVal SqlString7 As String, ByVal SqlString8 As String, ByVal SqlString9 As String, ByVal SqlString10 As String, ByVal SqlString11 As String, ByVal SqlString12 As String, ByVal SqlString13 As String) As Data.DataSet
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "PARSE_SQLSTRING13"
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

            oParam = oComm.Parameters.Add("iSqlString11", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString11

            oParam = oComm.Parameters.Add("iSqlString12", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString12

            oParam = oComm.Parameters.Add("iSqlString13", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString13

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

            oParam = oComm.Parameters.Add("DataCur11", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur12", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DataCur13", OracleType.Cursor)
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

#Region "COMMON METHODS"
    Public Function GetSubTotalRank(ByVal iDTStudent As String, ByVal iDTTotal As String, ByVal iDTSubjects As String, ByVal iDTAvgRank As String, ByVal iDTESTAvgRank As String, ByVal iDtTotalStu As String) As DataSet
        Try

            Ds = New DataSet

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleDataAdapter

            oComm.CommandText = "EXAM_SUBTOTALRANK_SELECT"
            oComm.CommandType = CommandType.StoredProcedure
            oComm.Connection = oConn

            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("SUBJDataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("SNDataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("ARDataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output


            oParam = oComm.Parameters.Add("ESTARDataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("ToTalStuDataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("iDTStudent", OracleType.VarChar, 9000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDTStudent

            oParam = oComm.Parameters.Add("iDTTotal", OracleType.VarChar, 9000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDTTotal

            oParam = oComm.Parameters.Add("iDTSubjects", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDTSubjects

            oParam = oComm.Parameters.Add("iDTAvgRank", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDTAvgRank

            oParam = oComm.Parameters.Add("iDTESTAvgRank", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDTESTAvgRank

            oParam = oComm.Parameters.Add("iDtTotalStu", OracleType.VarChar, 9000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDtTotalStu

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds

    End Function

    Public Function GetProgressReport(ByVal iDTStudent As String, ByVal iDTSubjects As String) As DataSet
        Try

            Ds = New DataSet

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleDataAdapter


            oComm.CommandText = "EXAM_PROGRESSPRT_SELECT"
            oComm.CommandType = CommandType.StoredProcedure
            oComm.Connection = oConn

            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("SUBJDataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output


            oParam = oComm.Parameters.Add("iDTStudent", OracleType.VarChar, 15000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDTStudent


            oParam = oComm.Parameters.Add("iDTSubjects", OracleType.VarChar, 15000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDTSubjects


            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds

    End Function

    Public Function GetEnteredNotEntered(ByVal iDTStudent As String, ByVal iDTTotal As String, ByVal iDTSubjects As String, ByVal iDTAvgRank As String, ByVal iDTESTAvgRank As String, ByVal iDtNotEntered As String, ByVal iDtTotalStu As String) As DataSet
        Try

            Ds = New DataSet

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleDataAdapter


            oComm.CommandText = "EXAM_ENTEREDNOT_SELECT"
            oComm.CommandType = CommandType.StoredProcedure
            oComm.Connection = oConn

            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("SUBJDataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("SNDataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("ARDataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output


            oParam = oComm.Parameters.Add("ESTARDataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("NOTEDataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output


            oParam = oComm.Parameters.Add("ToTalStuDataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output



            oParam = oComm.Parameters.Add("iDTStudent", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDTStudent

            oParam = oComm.Parameters.Add("iDTTotal", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDTTotal

            oParam = oComm.Parameters.Add("iDTSubjects", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDTSubjects

            oParam = oComm.Parameters.Add("iDTAvgRank", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDTAvgRank

            oParam = oComm.Parameters.Add("iDTESTAvgRank", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDTESTAvgRank

            oParam = oComm.Parameters.Add("iDtNotEntered", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDtNotEntered


            oParam = oComm.Parameters.Add("iDtTotalStu", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDtTotalStu

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds

    End Function

    Public Function GetReportData(ByVal iDTStudent As String, ByVal iDTSubjects As String, ByVal iDTDetails As String) As DataSet
        Try
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()


            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleDataAdapter


            oComm.CommandText = "EXAM_RPTPREMKS_SELECT"
            oComm.CommandType = CommandType.StoredProcedure
            oComm.Connection = oConn

            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("SUBJDataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output


            oParam = oComm.Parameters.Add("DetailsDataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output


            oParam = oComm.Parameters.Add("iDTStudent", OracleType.VarChar, 15000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDTStudent


            oParam = oComm.Parameters.Add("iDTSubjects", OracleType.VarChar, 15000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDTSubjects

            oParam = oComm.Parameters.Add("iDTDetails", OracleType.VarChar, 15000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDTDetails

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds

    End Function

    Public Function Parse_Fetch(ByVal pSqlString As String) As Data.DataSet
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()



            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleDataAdapter

            Ds = New Data.DataSet

            oComm.CommandText = "PARSE_SQLSTRING"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'Add IN Parameter to Accept the Sql String
            oParam = oComm.Parameters.Add("iSqlString", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSqlString

            'ADD IN PARAMETER NAME CURSOR
            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return Ds
    End Function

    Public Function GetCommDataSet(ByVal SqlStr As String) As DataSet
        'TAKEN FROM CLSRPTCOMBOBOXFILLING
        Try
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter

            oComm.CommandText = "GETCOMMANDATASET"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("iSqlStr", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlStr

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds
    End Function

    Public Function USERWISEEB(ByVal USERSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As Data.DataSet
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()


            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "USERWISEEB"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME USERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO

            'ADD IN PARAMETER NAME DATACUR
            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return Ds
    End Function

#End Region

#Region "Define Exam"
    Public Function ExamName_Select() As DataSet
        Try

            Ds = New DataSet

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            oParam = New OracleParameter

            oComm.CommandText = "M_EXAMNAME_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return Ds
    End Function

#End Region

#Region "Other Methods"


    Public Function GetStudentAdmslno(ByVal iADMNO As String, ByVal iCOMACADEMICSLNO As Integer) As String
        'author :Mahesh jan 09'08
        Try
            Dim Result As String
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection 'establishing the Connection .

            oComm = New OracleCommand
            oComm.CommandText = "EXAM_GETADMSLNO_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iADMNO
            oParam = oComm.Parameters.Add("iADMNO", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iADMNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO

            oComm.Parameters.Add(New OracleParameter("oRtnValid", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()

            Result = oComm.Parameters("oRtnValid").Value
            Return Result

        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function EXAMBranchWiseCourse_Fetch(ByVal eBranchSLNO As Integer) As Data.DataSet
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()


            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "P_EBWISECOURSE_FILL"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBranchSLNO
            oParam = oComm.Parameters.Add("iEBRANCHSLNO", OracleType.Number, 4)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = eBranchSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return Ds
    End Function

    Public Function Batch_Fill(ByVal iCourseSlno As Integer, ByVal iGroupSlno As Integer) As Data.DataSet
        Try

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "BCEGBS_BATCH_FETCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME COURSESLNO
            oParam = oComm.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCourseSlno

            'ADD IN PARAMETER NAME GROUPSLNO
            oParam = oComm.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iGroupSlno

            'ADD IN PARAMETER NAME DATACUR
            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return Ds
    End Function

    Public Function Group_Fill(ByVal iCourseSlno As Integer) As Data.DataSet
        Try

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "BCEGBS_GROUP_FETCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME COURSESLNO
            oParam = oComm.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCourseSlno

            'ADD IN PARAMETER NAME DATACUR
            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return Ds
    End Function

    Public Function AssignedSection_Fill(ByVal iEXAMBRANCHSLNO As Integer, ByVal iCourseSlno As Integer, ByVal iGroupSlno As Integer, ByVal iBatchslno As Integer) As Data.DataSet
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet


            oComm.CommandText = "ASSIGNEDSECTION_FETCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure


            'Add in parameter as CourseSlno
            oParam = oComm.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iEXAMBRANCHSLNO

            'Add in parameter as CourseSlno
            oParam = oComm.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCourseSlno


            'Add in parameter as Group slno
            oParam = oComm.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iGroupSlno

            'Add in parameter as Batch Slno
            oParam = oComm.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iBatchslno

            'ADD IN PARAMETER NAME 
            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output


            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return Ds

    End Function

    Public Function StudentForCaste(ByVal SpName As String, ByVal Dset As DataSet, ByVal DTable As String, ByVal iEXAMBRANCHSLNO As Integer, ByVal iCOURSESLNO As Integer, ByVal iGROUPSLNO As Integer, ByVal iBATCHSLNO As Integer, ByVal iSECTIONSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter


            oComm.CommandText = SpName
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output


            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO 
            oParam = oComm.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParam = oComm.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOURSESLNO

            'ADD IN PARAMETER NAME iGROUPSLNO 
            oParam = oComm.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iGROUPSLNO

            'ADD IN PARAMETER NAME iBATCHSLNO
            oParam = oComm.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iBATCHSLNO

            'ADD IN PARAMETER NAME iSECTIONSLNO 
            oParam = oComm.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iSECTIONSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO 
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO

            oAdap.SelectCommand = oComm
            oAdap.Fill(Dset, DTable) '"Students")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return Dset

    End Function

    Public Function StudentType_Fetch() As Data.DataSet
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()


            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "M_STUDENTTYPE_SELECT_SLNO_NAME"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return Ds
    End Function

    Public Function EXAMBranchWiseMedium_Fetch(ByVal eBranchSLNO As Integer) As Data.DataSet
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "P_EBWISEMEDIUM_FILL"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBranchSLNO
            oParam = oComm.Parameters.Add("iEBranchSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = eBranchSLNO


            'ADD IN PARAMETER NAME IUSERID
            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return Ds
    End Function


    Public Function DataSet_TestFetch(ByVal SqlString1 As String, ByVal PDset As DataSet, ByVal PdtIndex As Integer) As Data.DataSet
        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter

            oComm.CommandText = "PARSE_SQLSTRING1"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1

            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm
            oAdap.Fill(PDset, PDset.Tables(PdtIndex).TableName)

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

#Region "Data set fetches New "
    Public Function DataSet_TwoFetchNew(ByVal SqlString1 As String, ByVal SqlString2 As String) As Data.DataSet
        Try

            Ds = New DataSet

            Dim StrAsr As New ArrayList

            StrAsr.Add(SqlString1)
            StrAsr.Add(SqlString2)

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            For X As Int16 = 0 To 1

                oAdap = New OracleDataAdapter(StrAsr(X).ToString, oConn)
                oAdap.Fill(Ds, X.ToString)

            Next

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds
    End Function
    Public Function DataSet_ThreeFetchNew(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String) As Data.DataSet
        Try

            Ds = New DataSet

            Dim StrAsr As New ArrayList

            StrAsr.Add(SqlString1)
            StrAsr.Add(SqlString2)
            StrAsr.Add(SqlString3)

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            For X As Int16 = 0 To 2

                oAdap = New OracleDataAdapter(StrAsr(X).ToString, oConn)
                oAdap.Fill(Ds, X.ToString)

            Next

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds
    End Function
    Public Function DataSet_FoureFetchNew(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String) As Data.DataSet
        Try

            Ds = New DataSet

            Dim StrAsr As New ArrayList

            StrAsr.Add(SqlString1)
            StrAsr.Add(SqlString2)
            StrAsr.Add(SqlString3)
            StrAsr.Add(SqlString4)

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            For X As Int16 = 0 To 3

                oAdap = New OracleDataAdapter(StrAsr(X).ToString, oConn)
                oAdap.Fill(Ds, X.ToString)

            Next


        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds
    End Function
    Public Function DataSet_FiveFetchNew(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String) As Data.DataSet
        Try

            Ds = New DataSet

            Dim StrAsr As New ArrayList

            StrAsr.Add(SqlString1)
            StrAsr.Add(SqlString2)
            StrAsr.Add(SqlString3)
            StrAsr.Add(SqlString4)
            StrAsr.Add(SqlString5)

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            For X As Int16 = 0 To 4

                oAdap = New OracleDataAdapter(StrAsr(X).ToString, oConn)
                oAdap.Fill(Ds, X.ToString)

            Next


        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds
    End Function
    Public Function DataSet_SixFetchNew(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String) As Data.DataSet
        Try

            Ds = New DataSet

            Dim StrAsr As New ArrayList

            StrAsr.Add(SqlString1)
            StrAsr.Add(SqlString2)
            StrAsr.Add(SqlString3)
            StrAsr.Add(SqlString4)
            StrAsr.Add(SqlString5)
            StrAsr.Add(SqlString6)

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            For X As Int16 = 0 To 5

                oAdap = New OracleDataAdapter(StrAsr(X).ToString, oConn)
                oAdap.Fill(Ds, X.ToString)

            Next

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds
    End Function
    Public Function DataSet_SevenFetchNew(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String, ByVal SqlString7 As String) As Data.DataSet
        Try

            Ds = New DataSet

            Dim StrAsr As New ArrayList

            StrAsr.Add(SqlString1)
            StrAsr.Add(SqlString2)
            StrAsr.Add(SqlString3)
            StrAsr.Add(SqlString4)
            StrAsr.Add(SqlString5)
            StrAsr.Add(SqlString6)
            StrAsr.Add(SqlString7)

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            For X As Int16 = 0 To 6
                oAdap = New OracleDataAdapter(StrAsr(X).ToString, oConn)
                oAdap.Fill(Ds, X.ToString)
            Next


        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds

    End Function
    Public Function DataSet_EightFetchNew(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String, ByVal SqlString7 As String, ByVal SqlString8 As String) As DataSet
        Try

            Ds = New DataSet

            Dim StrAsr As New ArrayList

            StrAsr.Add(SqlString1)
            StrAsr.Add(SqlString2)
            StrAsr.Add(SqlString3)
            StrAsr.Add(SqlString4)
            StrAsr.Add(SqlString5)
            StrAsr.Add(SqlString6)
            StrAsr.Add(SqlString7)
            StrAsr.Add(SqlString8)

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            For X As Int16 = 0 To 7

                oAdap = New OracleDataAdapter(StrAsr(X).ToString, oConn)
                oAdap.Fill(Ds, X.ToString)

            Next




        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds

    End Function
    Public Function DataSet_NineFetchNew(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String, ByVal SqlString7 As String, ByVal SqlString8 As String, ByVal SqlString9 As String) As DataSet
        Try

            Ds = New DataSet

            Dim StrAsr As New ArrayList

            StrAsr.Add(SqlString1)
            StrAsr.Add(SqlString2)
            StrAsr.Add(SqlString3)
            StrAsr.Add(SqlString4)
            StrAsr.Add(SqlString5)
            StrAsr.Add(SqlString6)
            StrAsr.Add(SqlString7)
            StrAsr.Add(SqlString8)
            StrAsr.Add(SqlString9)

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            For X As Int16 = 0 To 8

                oAdap = New OracleDataAdapter(StrAsr(X).ToString, oConn)
                oAdap.Fill(Ds, X.ToString)

            Next

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds

    End Function
    Public Function DataSet_TenFetchNew(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String, ByVal SqlString7 As String, ByVal SqlString8 As String, ByVal SqlString9 As String, ByVal SqlString10 As String) As DataSet
        Try

            Ds = New DataSet

            Dim StrAsr As New ArrayList

            StrAsr.Add(SqlString1)
            StrAsr.Add(SqlString2)
            StrAsr.Add(SqlString3)
            StrAsr.Add(SqlString4)
            StrAsr.Add(SqlString5)
            StrAsr.Add(SqlString6)
            StrAsr.Add(SqlString7)
            StrAsr.Add(SqlString8)
            StrAsr.Add(SqlString9)
            StrAsr.Add(SqlString10)

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            For X As Int16 = 0 To 9

                oAdap = New OracleDataAdapter(StrAsr(X).ToString, oConn)
                oAdap.Fill(Ds, X.ToString)

            Next

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds

    End Function
    Public Function DataSet_ElevenFetchNew(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String, ByVal SqlString7 As String, ByVal SqlString8 As String, ByVal SqlString9 As String, ByVal SqlString10 As String, ByVal SqlString11 As String) As DataSet
        Try

            Ds = New DataSet

            Dim StrAsr As New ArrayList

            StrAsr.Add(SqlString1)
            StrAsr.Add(SqlString2)
            StrAsr.Add(SqlString3)
            StrAsr.Add(SqlString4)
            StrAsr.Add(SqlString5)
            StrAsr.Add(SqlString6)
            StrAsr.Add(SqlString7)
            StrAsr.Add(SqlString8)
            StrAsr.Add(SqlString9)
            StrAsr.Add(SqlString10)
            StrAsr.Add(SqlString11)

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            For X As Int16 = 0 To 10

                oAdap = New OracleDataAdapter(StrAsr(X).ToString, oConn)
                oAdap.Fill(Ds, X.ToString)

            Next

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds

    End Function
    Public Function DataSet_TwelveFetchNew(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String, ByVal SqlString7 As String, ByVal SqlString8 As String, ByVal SqlString9 As String, ByVal SqlString10 As String, ByVal SqlString11 As String, ByVal SqlString12 As String) As DataSet
        Try

            Ds = New DataSet

            Dim StrAsr As New ArrayList

            StrAsr.Add(SqlString1)
            StrAsr.Add(SqlString2)
            StrAsr.Add(SqlString3)
            StrAsr.Add(SqlString4)
            StrAsr.Add(SqlString5)
            StrAsr.Add(SqlString6)
            StrAsr.Add(SqlString7)
            StrAsr.Add(SqlString8)
            StrAsr.Add(SqlString9)
            StrAsr.Add(SqlString10)
            StrAsr.Add(SqlString11)
            StrAsr.Add(SqlString12)

            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            For X As Int16 = 0 To 11

                oAdap = New OracleDataAdapter(StrAsr(X).ToString, oConn)
                oAdap.Fill(Ds, X.ToString)

            Next

        Catch OrEx As OracleException
            Throw OrEx
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

        Return Ds

    End Function

#End Region

#Region "commented by surender on nov 21'07 removed shared from the functions and variables"
    '#Region "Class Variables"

    '    Private Shared oConn As OracleConnection 'Connection Object Declaration.
    '    Private Shared oComm As OracleCommand 'Command Object Declaration.
    '    Private Shared oAdap As OracleDataAdapter 'Adapter Object Declaration.
    '    Private Shared oParam As OracleParameter 'Parameter Object Declaration.
    '    Private Shared Ds As DataSet
    '    Private Shared ConObj As ReportConnection
    '    Private oTrans As OracleTransaction

    '#End Region

    '#Region "Methods"

    '    Public Function TopperSelection_Save(ByVal sQuery As String) As String
    '        'by prakash on oct 23'07 for toppers selection report 
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection


    '            oAdap = New OracleDataAdapter
    '            oComm = New OracleCommand

    '            oTrans = oConn.BeginTransaction()
    '            oComm.Transaction = oTrans


    '            oComm.CommandText = "P_TOPSEL_INS"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure
    '            oComm.Transaction = oTrans


    '            oParam = oComm.Parameters.Add("iQUERY", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = sQuery

    '            oComm.ExecuteNonQuery()

    '            oTrans.Commit()
    '            TopperSelection_Save = "SUCCESS"
    '        Catch ORAEX As OracleException
    '            oTrans.Rollback()
    '            Throw ORAEX
    '        Catch ex As Exception
    '            oTrans.Rollback()
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try

    '    End Function

    '    Public Shared Function GetStudenAdmslnoUniqNo(ByVal iADMNO As String, ByVal iCOMACADEMICSLNO As Integer) As String

    '        Try

    '            Dim Result As String

    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection 'establishing the Connection .


    '            oComm = New OracleCommand
    '            oComm.CommandText = "EXAM_GETSUNIQUENO_SELET"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure


    '            'ADD IN PARAMETER NAME iADMNO
    '            oParam = oComm.Parameters.Add("iADMNO", OracleType.VarChar, 50)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iADMNO


    '            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
    '            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iCOMACADEMICSLNO


    '            oComm.Parameters.Add(New OracleParameter("oRtnValid", OracleType.Number)).Direction = ParameterDirection.ReturnValue
    '            oComm.ExecuteNonQuery()

    '            Result = oComm.Parameters("oRtnValid").Value
    '            Return Result


    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try



    '    End Function


    '    Public Shared Function DataSet_Fetch(ByVal pSqlString As String) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "PARSE_SQLSTRING"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iSqlString", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = pSqlString

    '            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '    Public Shared Function FillPayModes_Fetch(ByVal TransType As String) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "M_TRANSPAYMODE_SELECT"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iTRANSTYPE", OracleType.VarChar, 20)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = TransType

    '            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '    Public Shared Function FillBranchUserWise_Fetch(ByVal COMACADEMICSLNO As Integer, ByVal UserSLNO As Integer) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "M_USERWISEBRANCH_SELECT"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = UserSLNO

    '            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = COMACADEMICSLNO

    '            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '    Public Shared Function FillBranchAll_Fetch(ByVal COMACADEMICSLNO As Integer) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "M_BRANCHALL_SELECT"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = COMACADEMICSLNO

    '            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '    Public Shared Function FillZoneUserWise_Fetch(ByVal COMACADEMICSLNO As Integer, Optional ByVal UserSLNO As Integer = 0) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "M_USERWISEZONE_SELECT"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = UserSLNO

    '            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = COMACADEMICSLNO

    '            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '    Public Shared Function FillRegionUserWise_Fetch(ByVal COMACADEMICSLNO As Integer, Optional ByVal UserSLNO As Integer = 0) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "M_USERWISEREGION_SELECT"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = UserSLNO

    '            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = COMACADEMICSLNO

    '            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '    Public Shared Function FillUserWise_ExamBranch(ByVal UserSLNO As Integer) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "USERWISEEB"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            'ADD IN PARAMETER NAME USERSLNO
    '            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = UserSLNO

    '            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '#End Region

    '#Region "Comman DataSet"

    '    Public Shared Function DataSet_OneFetch(ByVal SqlString1 As String) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "PARSE_SQLSTRING1"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString1

    '            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '    Public Shared Function DataSet_TwoFetch(ByVal SqlString1 As String, ByVal SqlString2 As String) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "PARSE_SQLSTRING2"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString1


    '            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString2

    '            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '    Public Shared Function DataSet_ThreeFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "PARSE_SQLSTRING3"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString1


    '            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString2

    '            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString3

    '            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '    Public Shared Function DataSet_FoureFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "PARSE_SQLSTRING4"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString1


    '            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString2

    '            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString3


    '            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString4

    '            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur4", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '    Public Shared Function DataSet_FiveFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "PARSE_SQLSTRING5"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString1


    '            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString2

    '            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString3


    '            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString4

    '            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString5

    '            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur4", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur5", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '    Public Shared Function DataSet_SixFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "PARSE_SQLSTRING6"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString1


    '            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString2

    '            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString3


    '            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString4

    '            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString5

    '            oParam = oComm.Parameters.Add("iSqlString6", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString6

    '            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur4", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur5", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur6", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '    Public Shared Function DataSet_SevenFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String, ByVal SqlString7 As String) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "PARSE_SQLSTRING7"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString1


    '            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString2

    '            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString3


    '            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString4

    '            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString5

    '            oParam = oComm.Parameters.Add("iSqlString6", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString6

    '            oParam = oComm.Parameters.Add("iSqlString7", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString7

    '            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur4", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur5", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur6", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur7", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '    Public Shared Function DataSet_EightFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String, ByVal SqlString7 As String, ByVal SqlString8 As String) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "PARSE_SQLSTRING8"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString1


    '            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString2

    '            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString3


    '            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString4

    '            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString5

    '            oParam = oComm.Parameters.Add("iSqlString6", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString6

    '            oParam = oComm.Parameters.Add("iSqlString7", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString7

    '            oParam = oComm.Parameters.Add("iSqlString8", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString8

    '            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur4", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur5", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur6", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur7", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output


    '            oParam = oComm.Parameters.Add("DataCur8", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '    Public Shared Function DataSet_NineFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String, ByVal SqlString7 As String, ByVal SqlString8 As String, ByVal SqlString9 As String) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "PARSE_SQLSTRING9"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString1


    '            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString2

    '            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString3


    '            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString4

    '            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString5

    '            oParam = oComm.Parameters.Add("iSqlString6", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString6

    '            oParam = oComm.Parameters.Add("iSqlString7", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString7

    '            oParam = oComm.Parameters.Add("iSqlString8", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString8

    '            oParam = oComm.Parameters.Add("iSqlString9", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString9

    '            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur4", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur5", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur6", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur7", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output


    '            oParam = oComm.Parameters.Add("DataCur8", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output


    '            oParam = oComm.Parameters.Add("DataCur9", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '    Public Shared Function DataSet_TenFetch(ByVal SqlString1 As String, ByVal SqlString2 As String, ByVal SqlString3 As String, ByVal SqlString4 As String, ByVal SqlString5 As String, ByVal SqlString6 As String, ByVal SqlString7 As String, ByVal SqlString8 As String, ByVal SqlString9 As String, ByVal SqlString10 As String) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleClient.OracleDataAdapter
    '            Ds = New DataSet

    '            oComm.CommandText = "PARSE_SQLSTRING10"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString1


    '            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString2

    '            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString3


    '            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString4

    '            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString5

    '            oParam = oComm.Parameters.Add("iSqlString6", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString6

    '            oParam = oComm.Parameters.Add("iSqlString7", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString7

    '            oParam = oComm.Parameters.Add("iSqlString8", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString8

    '            oParam = oComm.Parameters.Add("iSqlString9", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString9

    '            oParam = oComm.Parameters.Add("iSqlString10", OracleType.VarChar, 50000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlString10

    '            oParam = oComm.Parameters.Add("DataCur1", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur2", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur3", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur4", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur5", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur6", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur7", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output


    '            oParam = oComm.Parameters.Add("DataCur8", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output


    '            oParam = oComm.Parameters.Add("DataCur9", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("DataCur10", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '            Return Ds

    '        Catch oex As OracleException
    '            Throw oex
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '    End Function

    '#End Region

    '#Region "COMMON METHODS"
    '    Public Function GetSubTotalRank(ByVal iDTStudent As String, ByVal iDTTotal As String, ByVal iDTSubjects As String, ByVal iDTAvgRank As String, ByVal iDTESTAvgRank As String, ByVal iDtTotalStu As String) As DataSet
    '        Try

    '            Ds = New DataSet

    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleDataAdapter

    '            oComm.CommandText = "EXAM_SUBTOTALRANK_SELECT"
    '            oComm.CommandType = CommandType.StoredProcedure
    '            oComm.Connection = oConn

    '            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("SUBJDataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("SNDataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("ARDataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output


    '            oParam = oComm.Parameters.Add("ESTARDataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("ToTalStuDataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("iDTStudent", OracleType.VarChar, 9000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDTStudent

    '            oParam = oComm.Parameters.Add("iDTTotal", OracleType.VarChar, 9000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDTTotal

    '            oParam = oComm.Parameters.Add("iDTSubjects", OracleType.VarChar, 8000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDTSubjects

    '            oParam = oComm.Parameters.Add("iDTAvgRank", OracleType.VarChar, 8000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDTAvgRank

    '            oParam = oComm.Parameters.Add("iDTESTAvgRank", OracleType.VarChar, 8000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDTESTAvgRank

    '            oParam = oComm.Parameters.Add("iDtTotalStu", OracleType.VarChar, 9000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDtTotalStu

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '        Catch OrEx As OracleException
    '            Throw OrEx
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try

    '        Return Ds

    '    End Function
    '    Public Function GetProgressReport(ByVal iDTStudent As String, ByVal iDTSubjects As String) As DataSet
    '        Try

    '            Ds = New DataSet

    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleDataAdapter


    '            oComm.CommandText = "EXAM_PROGRESSPRT_SELECT"
    '            oComm.CommandType = CommandType.StoredProcedure
    '            oComm.Connection = oConn

    '            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("SUBJDataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output


    '            oParam = oComm.Parameters.Add("iDTStudent", OracleType.VarChar, 15000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDTStudent


    '            oParam = oComm.Parameters.Add("iDTSubjects", OracleType.VarChar, 15000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDTSubjects


    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '        Catch OrEx As OracleException
    '            Throw OrEx
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try

    '        Return Ds

    '    End Function

    '    Public Function GetEnteredNotEntered(ByVal iDTStudent As String, ByVal iDTTotal As String, ByVal iDTSubjects As String, ByVal iDTAvgRank As String, ByVal iDTESTAvgRank As String, ByVal iDtNotEntered As String, ByVal iDtTotalStu As String) As DataSet
    '        Try

    '            Ds = New DataSet

    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleDataAdapter


    '            oComm.CommandText = "EXAM_ENTEREDNOT_SELECT"
    '            oComm.CommandType = CommandType.StoredProcedure
    '            oComm.Connection = oConn

    '            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("SUBJDataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("SNDataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("ARDataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output


    '            oParam = oComm.Parameters.Add("ESTARDataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("NOTEDataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output


    '            oParam = oComm.Parameters.Add("ToTalStuDataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output



    '            oParam = oComm.Parameters.Add("iDTStudent", OracleType.VarChar, 8000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDTStudent

    '            oParam = oComm.Parameters.Add("iDTTotal", OracleType.VarChar, 8000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDTTotal

    '            oParam = oComm.Parameters.Add("iDTSubjects", OracleType.VarChar, 8000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDTSubjects

    '            oParam = oComm.Parameters.Add("iDTAvgRank", OracleType.VarChar, 8000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDTAvgRank

    '            oParam = oComm.Parameters.Add("iDTESTAvgRank", OracleType.VarChar, 8000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDTESTAvgRank

    '            oParam = oComm.Parameters.Add("iDtNotEntered", OracleType.VarChar, 8000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDtNotEntered


    '            oParam = oComm.Parameters.Add("iDtTotalStu", OracleType.VarChar, 8000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDtTotalStu

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '        Catch OrEx As OracleException
    '            Throw OrEx
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try

    '        Return Ds

    '    End Function

    '    Public Function GetReportData(ByVal iDTStudent As String, ByVal iDTSubjects As String, ByVal iDTDetails As String) As DataSet
    '        Try
    '            oAdap = New OracleDataAdapter
    '            Ds = New DataSet

    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()


    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleDataAdapter


    '            oComm.CommandText = "EXAM_RPTPREMKS_SELECT"
    '            oComm.CommandType = CommandType.StoredProcedure
    '            oComm.Connection = oConn

    '            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("SUBJDataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output


    '            oParam = oComm.Parameters.Add("DetailsDataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output


    '            oParam = oComm.Parameters.Add("iDTStudent", OracleType.VarChar, 15000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDTStudent


    '            oParam = oComm.Parameters.Add("iDTSubjects", OracleType.VarChar, 15000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDTSubjects

    '            oParam = oComm.Parameters.Add("iDTDetails", OracleType.VarChar, 15000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iDTDetails

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '        Catch OrEx As OracleException
    '            Throw OrEx
    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try

    '        Return Ds

    '    End Function

    '    Public Function Parse_Fetch(ByVal pSqlString As String) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()



    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleDataAdapter

    '            Ds = New Data.DataSet

    '            oComm.CommandText = "PARSE_SQLSTRING"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            'Add IN Parameter to Accept the Sql String
    '            oParam = oComm.Parameters.Add("iSqlString", OracleType.VarChar, 8000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = pSqlString

    '            'ADD IN PARAMETER NAME CURSOR
    '            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '        Return Ds
    '    End Function

    '    Public Function GetCommDataSet(ByVal SqlStr As String) As DataSet
    '        'TAKEN FROM CLSRPTCOMBOBOXFILLING
    '        Try
    '            oAdap = New OracleDataAdapter
    '            Ds = New DataSet

    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oParam = New OracleParameter

    '            oComm.CommandText = "GETCOMMANDATASET"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            'ADD IN PARAMETER NAME DataCur
    '            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oParam = oComm.Parameters.Add("iSqlStr", OracleType.VarChar, 8000)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = SqlStr

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try

    '        Return Ds
    '    End Function

    '    Public Function USERWISEEB(ByVal USERSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As Data.DataSet
    '        Try
    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()


    '            oComm = New OracleCommand
    '            oParam = New OracleParameter
    '            oAdap = New OracleDataAdapter
    '            Ds = New Data.DataSet

    '            oComm.CommandText = "USERWISEEB"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            'ADD IN PARAMETER NAME USERSLNO
    '            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = USERSLNO

    '            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
    '            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
    '            oParam.Direction = ParameterDirection.Input
    '            oParam.Value = iCOMACADEMICSLNO

    '            'ADD IN PARAMETER NAME DATACUR
    '            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '        Return Ds
    '    End Function

    '#End Region

    '#Region "Define Exam"
    '    Public Function ExamName_Select() As DataSet
    '        Try

    '            Ds = New DataSet

    '            ConObj = New ReportConnection
    '            oConn = ConObj.GetConnection()

    '            oComm = New OracleCommand
    '            oAdap = New OracleDataAdapter
    '            oParam = New OracleParameter

    '            oComm.CommandText = "M_EXAMNAME_SELECT"
    '            oComm.Connection = oConn
    '            oComm.CommandType = CommandType.StoredProcedure

    '            'ADD IN PARAMETER NAME DataCur
    '            oParam = oComm.Parameters.Add("DataCur", OracleType.Cursor)
    '            oParam.Direction = ParameterDirection.Output

    '            oAdap.SelectCommand = oComm
    '            oAdap.Fill(Ds)

    '        Catch ex As Exception
    '            Throw ex
    '        Finally
    '            If Not ConObj Is Nothing Then ConObj.Free()
    '        End Try
    '        Return Ds
    '    End Function

    '#End Region
#End Region

#Region "Vc,Region,Zone,Unit I/c Filterings"

    Public Function Exam_UserWise_ExamBranch(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERWISE_EXAMBRANCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
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
            ConObj.Free()
        End Try

    End Function

    Public Function Exam_UserWise_Regions(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERWISE_REGIONS"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
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

    Public Function Exam_UserWise_Zones(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERWISE_ZONES"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
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

    Public Function Exam_UserWise_Dos(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERWISE_DOS"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME DATACUR
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

    Public Function Exam_UserRegionWise_ExamBranch(ByVal pREGIONSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERREGWISE_EXAMBRANCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iREGIONSLNO
            oParam = oComm.Parameters.Add("iREGIONSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pREGIONSLNO

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
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

    Public Function Exam_UserZoneWise_ExamBranch(ByVal pZONESLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERZONEWISE_EXAMBRANCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iZONESLNO
            oParam = oComm.Parameters.Add("iZONESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pZONESLNO

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
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

    Public Function Exam_UserDosWise_ExamBranch(ByVal pDOSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERDOSWISE_EXAMBRANCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDOSLNO
            oParam = oComm.Parameters.Add("iDOSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pDOSLNO

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME DATACUR
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

    Public Function Exam_UserRegionWise_Branch(ByVal pREGIONSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERREGWISE_BRANCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iREGIONSLNO
            oParam = oComm.Parameters.Add("iREGIONSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pREGIONSLNO

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
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

    Public Function Exam_UserZoneWise_Branch(ByVal pZONESLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERZONEWISE_BRANCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iZONESLNO
            oParam = oComm.Parameters.Add("iZONESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pZONESLNO

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
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

    Public Function Exam_UserDosWise_Branch(ByVal pDOSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERDOSWISE_BRANCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iZONESLNO
            oParam = oComm.Parameters.Add("iDOSSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pDOSLNO

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME DATACUR
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

    Public Function Exam_UserWise_VC(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERWISE_VC"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME DATACUR
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

    Public Function Exam_UserVCWise_ExamBranch(ByVal pUNITICSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERUNITWISE_EXAMBRANCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDOSLNO
            oParam = oComm.Parameters.Add("iUNITICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUNITICSLNO

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME DATACUR
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

    Public Function Exam_UserWise_UnitIC(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERWISE_UNITIC"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME DATACUR
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

    Public Function Exam_UserUnitICWise_ExamBranch(ByVal pUNITICSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERUNITWISE_EXAMBRANCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDOSLNO
            oParam = oComm.Parameters.Add("iUNITICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUNITICSLNO

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME DATACUR
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


#End Region

#Region "Examwise Vc,Region,Zone,Unit I/c Filterings "

    Public Function Exam_UserWise_ExRegions(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERWISE_EXREGIONS"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
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

    Public Function Exam_UserWise_ExZones(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERWISE_EXZONES"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
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

    Public Function Exam_UserWise_ExDos(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERWISE_EXDOS"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME DATACUR
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

    Public Function Exam_UserExRegionWise_EB(ByVal pREGIONSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USEREXREGWISE_EB"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iREGIONSLNO
            oParam = oComm.Parameters.Add("iREGIONSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pREGIONSLNO

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
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

    Public Function Exam_UserExZoneWise_EB(ByVal pZONESLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USEREXZONEWISE_EB"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iZONESLNO
            oParam = oComm.Parameters.Add("iZONESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pZONESLNO

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
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

    Public Function Exam_UserExDosWise_EB(ByVal pDOSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USEREXDOSWISE_EB"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDOSLNO
            oParam = oComm.Parameters.Add("iDOSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pDOSLNO

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME DATACUR
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

    Public Function Exam_UserWise_ExVC(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERWISE_EXVC"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME DATACUR
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

    Public Function Exam_UserExVCWise_EB(ByVal pUNITICSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New ReportConnection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USEREXUNITWISE_EB"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDOSLNO
            oParam = oComm.Parameters.Add("iUNITICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUNITICSLNO

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME DATACUR
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

#End Region

End Class
