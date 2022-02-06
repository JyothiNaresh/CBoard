'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS ATTENDANCE 3.0
'   OBJECTIVE                         : This is the Middle layer for All Attendance v 3.0 Reports.
'   ACTIVITY                          : Select\Insert\Update\Delete
'   AUTHOR                            : AMARENDRA B.V
'   INITIAL BASELINE DATE             : 26-11-2007
'   FINAL BASELINE DATE               : 26-11-2007
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data
Imports System.Data.OracleClient
Public Class DoRegionZone

#Region "Common Variables"

    Private oConn As OracleConnection
    Private oComm As OracleCommand
    Private oAdap As OracleDataAdapter
    Private oParam As OracleParameter
    Private Ds, dset As DataSet
    Private ConObj As Connection

#End Region

#Region "ComboBox Filling"

    Public Function Exam_UserWise_ExamBranch(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
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

    Public Function Exam_UserWise_Vcs(ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

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

    Public Function Exam_UserRegionWise_ExamBranch(ByVal pREGIONSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            dset = New Data.DataSet

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
            oAdap.Fill(dset)

            Return dset

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

    Public Function Exam_UserVcWise_ExamBranch(ByVal pVCSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

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

    Public Function Attnd_UserExRegionWise_EB(ByVal pREGIONSLNO As Integer, ByVal pUSERSLNO As Integer, ByVal pCOMACADEMICSLNO As Integer) As Data.DataSet

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
#End Region

#Region "Comman DataSets"

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

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 25000)
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
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "PARSE_SQLSTRING2"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 15000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 15000)
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

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 8000)
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

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString3


            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 8000)
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

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString3


            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString4

            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 8000)
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

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString3


            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString4

            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString5

            oParam = oComm.Parameters.Add("iSqlString6", OracleType.VarChar, 8000)
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

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString3


            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString4

            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString5

            oParam = oComm.Parameters.Add("iSqlString6", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString6

            oParam = oComm.Parameters.Add("iSqlString7", OracleType.VarChar, 8000)
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

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString3


            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString4

            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString5

            oParam = oComm.Parameters.Add("iSqlString6", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString6

            oParam = oComm.Parameters.Add("iSqlString7", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString7

            oParam = oComm.Parameters.Add("iSqlString8", OracleType.VarChar, 8000)
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

            oParam = oComm.Parameters.Add("iSqlString1", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString1


            oParam = oComm.Parameters.Add("iSqlString2", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString2

            oParam = oComm.Parameters.Add("iSqlString3", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString3


            oParam = oComm.Parameters.Add("iSqlString4", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString4

            oParam = oComm.Parameters.Add("iSqlString5", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString5

            oParam = oComm.Parameters.Add("iSqlString6", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString6

            oParam = oComm.Parameters.Add("iSqlString7", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString7

            oParam = oComm.Parameters.Add("iSqlString8", OracleType.VarChar, 8000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = SqlString8

            oParam = oComm.Parameters.Add("iSqlString9", OracleType.VarChar, 8000)
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

#End Region

#Region "Single Student Summary"

    Public Function Attnd_StudentEnquiry_Select(ByVal pEXAMBRANCHSLNO As Integer, ByVal pADMSNO As Integer, ByVal pCOMACADEMICSLNO As Integer, ByVal pFROMDATE As Date, ByVal pTODATE As Date, ByVal pTYPE As Integer) As Data.DataSet
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "ATTND_STUDENTENQUIRY_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParam = oComm.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pEXAMBRANCHSLNO


            'ADD IN PARAMETER NAME iADMSNO
            oParam = oComm.Parameters.Add("iADMSNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pADMSNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pCOMACADEMICSLNO

            'ADD IN PARAMETER NAME iFROMDATE
            oParam = oComm.Parameters.Add("iFROMDATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pFROMDATE

            'ADD IN PARAMETER NAME iTODATE
            oParam = oComm.Parameters.Add("iTODATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pTODATE

            'ADD IN PARAMETER NAME iTYPE
            oParam = oComm.Parameters.Add("iTYPE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pTYPE

            oParam = oComm.Parameters.Add("DATACUR1", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DATACUR2", OracleType.Cursor)
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
