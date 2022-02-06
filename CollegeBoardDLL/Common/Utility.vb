'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is the Middle layer for Utility.
'   ACTIVITY                          : ---------
'   AUTHOR                            : A.SURENDAR REDDY
'   INITIAL BASELINE DATE             : 10-JUN-2006
'   FINAL BASELINE DATE               : 10-JUN-2006
'   MODIFICATIONS LOG                 : REGIONS,ZONES,DOS WISE EXAMBRANCHES [17-DEC-2011, P.VENU]
'----------------------------------------------------------------------------------------------

Imports System.Data
Imports System.Data.OracleClient
Imports System.Data.OleDb

Public Class Utility

#Region "Class Variables"

    Private oConn As OracleConnection  'Connection Object Declaration.
    Private oComm As OracleCommand  'Command Object Declaration.
    Private oAdap As OracleDataAdapter  'Adapter Object Declaration.
    Private oParam As OracleParameter  'Parameter Object Declaration.
    Private Ds As DataSet
    Private ConObj As Connection
    Private oTrans As OracleTransaction

    Private OledbCmd As OleDbCommand
    Private OleCon As OleDbConnection
    Dim OleStr As String
    Private OleDa As OleDbDataAdapter

#End Region

#Region "Methods"

    Public Function DataSet_Fetch(ByVal pSqlString As String) As Data.DataSet
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "PARSE_SQLSTRING"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSqlString", OracleType.VarChar, 20000)
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
            ConObj = New Connection
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
            ConObj = New Connection
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
            ConObj = New Connection
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
            ConObj = New Connection
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
            ConObj = New Connection
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
    'Mumbai

    Public Function FillUserWise_ExamBranch(ByVal UserSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As Data.DataSet
        Try
            ConObj = New Connection
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


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO

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

    Public Function FillUserWise_ExamBranchMumbai(ByVal UserSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As Data.DataSet
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "USERWISE_MUMBAI"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME USERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = UserSLNO


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO

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

    Public Function FillUserWiseADM_ExamBranchMumbai(ByVal iCOMACADEMICSLNO As Integer) As Data.DataSet
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "USERWISEADM_MUMBAI"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO

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

    Public Function FillUserWise_ExamBranchCBSE(ByVal UserSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As Data.DataSet
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "USERWISE_CBSE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME USERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = UserSLNO


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO

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

    Public Function FillUserWiseADM_ExamBranchCBSE(ByVal iCOMACADEMICSLNO As Integer) As Data.DataSet
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "USERWISEADM_CBSE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO

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

    Public Function FillUserWise_ExamBranchChennai(ByVal UserSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As Data.DataSet
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "USERWISE_CHENNAI"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME USERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = UserSLNO


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO

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

    Public Function FillUserWiseADM_ExamBranchChennai(ByVal iCOMACADEMICSLNO As Integer) As Data.DataSet
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "USERWISEADM_CHENNAI"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO

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


    Public Function FillUserWise_ExamBranchBanglore(ByVal UserSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As Data.DataSet
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "USERWISE_BANGLORE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME USERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = UserSLNO


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO

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

    Public Function FillUserWise_AdmBranch(ByVal iCOMACADEMICSLNO As Integer) As Data.DataSet
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "USERWISE_ADMBRANCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            ''ADD IN PARAMETER NAME USERSLNO
            'oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            'oParam.Direction = ParameterDirection.Input
            'oParam.Value = UserSLNO


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO

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
    Public Function TopperSelection_Save(ByVal sQuery As String, ByVal iCOMBINATIONKEY As Integer) As String
        'by prakash on oct 23'07 for toppers selection report 
        Try
            ConObj = New Connection
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
    Public Function BranchTopperSelection_Save(ByVal sQuery As String, ByVal iCOMBINATIONKEY As Integer) As String
        'by prakash on oct 23'07 for toppers selection report 
        Try
            ConObj = New Connection
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
            BranchTopperSelection_Save = "SUCCESS"
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
    Public Function ExamTopperSelection_Save(ByVal sQuery As String, ByVal iCOMBINATIONKEY As Integer) As String
        'by prakash on oct 23'07 for toppers selection report 
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection


            oAdap = New OracleDataAdapter
            oComm = New OracleCommand

            oTrans = oConn.BeginTransaction()
            oComm.Transaction = oTrans


            oComm.CommandText = "P_EXAMTOPSEL_INS"
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
            ExamTopperSelection_Save = "SUCCESS"
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
            ConObj = New Connection
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
#End Region

#Region "Comman DataSet"

    Public Function DataSet_OneFetch(ByVal SqlString1 As String) As Data.DataSet
        Try
            ConObj = New Connection
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
    Public Function DataSet_OneFetch(ByVal SqlString1 As String, ByVal Dset As Data.DataSet, ByVal DTable As String) As Data.DataSet
        Try
            ConObj = New Connection
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
            oAdap.Fill(Dset, DTable)

            Return Dset

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
            ConObj = New Connection
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
            ConObj = New Connection
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
            ConObj = New Connection
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
            ConObj = New Connection
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
            ConObj = New Connection
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
            ConObj = New Connection
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
            ConObj = New Connection
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
            ConObj = New Connection
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
            ConObj = New Connection
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

#Region "Data set fetches New "
    Public Function DataSet_TwoFetchNew(ByVal SqlString1 As String, ByVal SqlString2 As String) As Data.DataSet
        Try

            Ds = New DataSet

            Dim StrAsr As New ArrayList

            StrAsr.Add(SqlString1)
            StrAsr.Add(SqlString2)

            ConObj = New Connection
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

            ConObj = New Connection
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

            ConObj = New Connection
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

            ConObj = New Connection
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

            ConObj = New Connection
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

            ConObj = New Connection
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

            ConObj = New Connection
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

#End Region

#Region "From Rpt Utility"

    Public Function GetEnteredNotEntered(ByVal iDTStudent As String, ByVal iDTTotal As String, ByVal iDTSubjects As String, ByVal iDTAvgRank As String, ByVal iDTESTAvgRank As String, ByVal iDtNotEntered As String, ByVal iDtTotalStu As String) As DataSet
        Try

            Ds = New DataSet

            ConObj = New Connection
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

    Public Function GetCommDataSet(ByVal SqlStr As String) As DataSet
        'TAKEN FROM CLSRPTCOMBOBOXFILLING
        Try
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            ConObj = New Connection
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
            ConObj = New Connection
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

    Public Function Parse_Fetch(ByVal pSqlString As String) As Data.DataSet
        Try
            ConObj = New Connection
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

            ConObj = New Connection
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

#End Region

#Region "Vc Region Zone Filterings"
    Public Function Exam_UserWise_ExamBranch(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERWISE_EXAMBRANCHES"
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
            ConObj = New Connection
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

    Public Function Exam_UserWise_ExRegions(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
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

    Public Function Exam_UserWise_Zones(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
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

    Public Function Exam_UserWise_ExZones(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
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

    Public Function Exam_UserWise_Dos(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
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

    Public Function Exam_UserWise_ExDos(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
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

    Public Function Exam_UserWise_VC(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
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

    Public Function Exam_UserWise_ExVC(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
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

    Public Function Exam_UserRegionWise_ExamBranch(ByVal pREGIONSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
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
    Public Function Exam_UserExRegionWise_EB(ByVal pREGIONSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
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
    Public Function Exam_UserZoneWise_ExamBranch(ByVal pZONESLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
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

    Public Function Exam_UserExZoneWise_EB(ByVal pZONESLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
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

    Public Function Exam_UserDosWise_ExamBranch(ByVal pDOSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
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


    Public Function Exam_UserExDosWise_EB(ByVal pDOSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
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

    Public Function Exam_UserRegionWise_Branch(ByVal pREGIONSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
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
            ConObj = New Connection
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
            ConObj = New Connection
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

    Public Function Exam_UserVCWise_ExamBranch(ByVal pVCSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERVCWISE_EXAMBRANCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDOSLNO
            oParam = oComm.Parameters.Add("iVCSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pVCSLNO

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
    Public Function Exam_UserExVCWise_EB(ByVal pVCSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USEREXVCWISE_EB"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDOSLNO
            oParam = oComm.Parameters.Add("iVCSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pVCSLNO

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

    ' Added By Venu on 17-Dec-2011
    Public Function Exam_UserExamBranches_ExamBranches(ByVal pRZD As String, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USEREBS_EXAMBRANCHES"
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

            'ADD IN PARAMETER NAME iREGIONSLNOS
            oParam = oComm.Parameters.Add("IRZD", OracleType.VarChar, 200)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pRZD

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

    Public Function Exam_UserRegions_ExamBranches(ByVal pRZD As String, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERREGIONS_EXAMBRANCHES"
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

            'ADD IN PARAMETER NAME iREGIONSLNOS
            oParam = oComm.Parameters.Add("IRZD", OracleType.VarChar, 200)
            oParam.Direction = ParameterDirection.Input
            'oParam.SourceColumn = "ERZDSLNO"
            oParam.Value = pRZD

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

    Public Function Exam_UserZones_ExamBranches(ByVal pRZD As String, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERZONES_EXAMBRANCHES"
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

            'ADD IN PARAMETER NAME iREGIONSLNOS
            oParam = oComm.Parameters.Add("IRZD", OracleType.VarChar, 200)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pRZD

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

    Public Function Exam_UserDos_ExamBranches(ByVal pRZD As String, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oComm.CommandText = "ATTND_USERDOS_EXAMBRANCHES"
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

            'ADD IN PARAMETER NAME IRZD
            oParam = oComm.Parameters.Add("IRZD", OracleType.VarChar, 200)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pRZD

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

    Public Function getApperYear(ByVal ApperYear As String, ByVal Table As String) As String
        Try
            Dim AppYear__1 As String() = ApperYear.Split("|")
            Dim sqlstr As String = ""
            Dim Appyear__2 As String = ""

            Dim cmd As OracleCommand
            For i As Integer = 0 To AppYear__1.Length - 1
                sqlstr = ""
                If Table = "YEAR" Then
                    sqlstr = " Select Code from M_APPEAREDYEAR WHERE APPEARYEAR_ID=" & AppYear__1(i).ToString()
                Else
                    sqlstr = " Select Code from M_APPEAREDEXAM WHERE APPEAREEXAM_ID=" & AppYear__1(i).ToString()
                End If
                cmd = New OracleCommand(sqlstr, oConn)
                ConObj = New Connection
                oConn = ConObj.GetConnection
                cmd = New OracleCommand(sqlstr, oConn)
                Appyear__2 = Appyear__2 + cmd.ExecuteScalar() & ","
                oConn.Close()
            Next
            Appyear__2 = Appyear__2.Substring(0, Appyear__2.Length - 1)
            Return Appyear__2

        Catch ex As Exception
        Finally
            ConObj.Free()
        End Try
    End Function

    Public Function NOE_PS_REMARKS_Insert(ByVal SPDset As DataSet) As String

        Try
            Dim adap As New OracleDataAdapter

            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleDataAdapter

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter

            oTrans = oConn.BeginTransaction()
            oComm.Transaction = oTrans
            oComm.CommandText = "NOE_PS_REMARKS_DT_INSERT"

            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iiPSTATUSSLNO
            oParam = oComm.Parameters.Add("iPSTATUSSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "PSTATUSSLNO"

            'Add In Parameter as iUNIQUENO
            oParam = oComm.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "UNIQUENO"

            'Add In Parameter as iPACKAGE_ID
            oParam = oComm.Parameters.Add("iPACKAGE_ID", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "PACKAGE_ID"

            'Add In Parameter as iPAPERNAME
            oParam = oComm.Parameters.Add("iPAPERNAME", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "PAPERNAME"

            'Add In Parameter as iREMARKS
            oParam = oComm.Parameters.Add("iREMARKS", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "REMARKS"

            adap.InsertCommand = oComm

            adap.Update(SPDset, "Name")

            oTrans.Commit()

            Return 1


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function NOE_PS_REMARKS_Delete(ByVal Setslno As Integer) As String
        Dim strReturn As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter

            oComm.CommandText = "NOE_PS_REMARKS_DT_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER UNIQUENO 
            oParam = oComm.Parameters.Add("iUNIQUENO", OracleType.Number, 4)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Setslno

            oComm.ExecuteNonQuery()
            strReturn = "0-DELETE"
        Catch ex As Exception
            Throw ex
        Finally
            'If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function

#Region " Excel-Dataset"

    Public Function ExceltoDataset(ByVal NFilePath As String, ByVal FileExtn As String) As DataSet
        Try
            If FileExtn = ".xls" Then
                OleStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + NFilePath + ";Extended Properties=Excel 8.0;"
            Else
                FileExtn = ".xlsx"
                OleStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + NFilePath + ";Extended Properties=Excel 8.0;HDR=YES;IMEX=1;"
            End If
            'connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";

            Dim Oledbcon As New OleDbConnection(OleStr)
            Oledbcon.Open()
            Dim OleDa As New OleDbDataAdapter("SELECT * FROM [Sheet1$]", Oledbcon)
            Dim ds As New DataSet
            Dim Dt As New DataTable("SMSEX")
            OleDa.Fill(ds)
            Oledbcon.Close()
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class

