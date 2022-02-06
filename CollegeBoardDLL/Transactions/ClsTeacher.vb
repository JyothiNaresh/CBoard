'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is the Middle layer for Teacherinfo Update.
'   AUTHOR                            : G.KISHORE
'   INITIAL BASELINE DATE             : 12-09-2011
'   FINAL BASELINE DATE               : 
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data
Imports System.Data.OracleClient
Imports System.Configuration
Public Class ClsTeacher

#Region "Class Variables"

    Private oConn As OracleConnection 'Connection Object Declaration.
    Private oComm As OracleCommand 'Command Object Declaration.
    Private oTrans As OracleTransaction 'Transaction Object Declaration.
    Private oAdap As OracleDataAdapter 'Adapter Object Declaration.
    Private oParam As OracleParameter 'Parameter Object Declaration.
    Private Ds As DataSet
    Private ConObj As Connection
    Private rtnMessage As String 'Result of the return type.
    Private rtnVal As Integer

#End Region

#Region "Teacher"
    Public Function Teacher_DDT_Insert(ByVal Arr As ArrayList) As Integer
        Try


            ConObj = New Connection
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "TEACHER_DDT_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iSCHOOLTYPE
            oParam = oComm.Parameters.Add("iSCHOOLTYPE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            'ADD IN PARAMETER NAME iBRANCHCODE
            oParam = oComm.Parameters.Add("iBRANCHCODE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            'ADD IN PARAMETER NAME iMONTHYEAR
            oParam = oComm.Parameters.Add("iMONTHYEAR", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            'ADD IN PARAMETER NAME iEMPID
            oParam = oComm.Parameters.Add("iEMPID", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            'ADD IN PARAMETER NAME iEMPNAME
            oParam = oComm.Parameters.Add("iEMPNAME", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            'ADD IN PARAMETER NAME iTEACHSUBSLNO
            oParam = oComm.Parameters.Add("iTEACHSUB", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            'ADD IN PARAMETER NAME iECLASSTYPE
            oParam = oComm.Parameters.Add("iECLASSTYPE", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            'ADD IN PARAMETER NAME iECLASSSLNO
            oParam = oComm.Parameters.Add("iECLASSSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)


            'ADD IN PARAMETER NAME iESECTION
            oParam = oComm.Parameters.Add("iESECTION", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            'ADD IN PARAMETER NAME iSTRENGTH
            oParam = oComm.Parameters.Add("iSTRENGTH", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParam = oComm.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(10)


            'ADD IN PARAMETER NAME iELEARN 
            oParam = oComm.Parameters.Add("iELEARN", OracleType.VarChar, 3)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(11)

            'ADD IN PARAMETER NAME iMODULE  
            oParam = oComm.Parameters.Add("iMODULE", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(12)

            'ADD IN PARAMETER NAME iSCHEDULETIME 
            oParam = oComm.Parameters.Add("iSCHEDULETIME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(13)

            'ADD IN PARAMETER NAMEiREMARKS_SCH  
            oParam = oComm.Parameters.Add("iREMARKS_SCH", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(14)

            'ADD IN PARAMETER NAME iCONCEPUT  
            oParam = oComm.Parameters.Add("iCONCEPUT", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(15)

            'ADD IN PARAMETER NAME iREMARKS_CON   
            oParam = oComm.Parameters.Add("iREMARKS_CON", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(16)

            'ADD IN PARAMETER NAME iUSERFRD 
            oParam = oComm.Parameters.Add("iUSERFRD", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(17)

            'ADD IN PARAMETER NAME iREMARKS_UFRD  
            oParam = oComm.Parameters.Add("iREMARKS_UFRD", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(18)

            'ADD IN PARAMETER NAME iCOMPTMODULE
            oParam = oComm.Parameters.Add("iCOMPTMODULE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(19)

            'ADD IN PARAMETER NAME iREMARKS_COMPT  
            oParam = oComm.Parameters.Add("iREMARKS_COMPT", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(20)

            'ADD IN PARAMETER NAME iENGUSED  
            oParam = oComm.Parameters.Add("iENGUSED", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(21)

            'ADD IN PARAMETER NAME iREMARKS_ENGU
            oParam = oComm.Parameters.Add("iREMARKS_ENGU", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(22)

            'ADD IN PARAMETER NAME iVOICE
            oParam = oComm.Parameters.Add("iVOICE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(23)

            'ADD IN PARAMETER NAME iREMARKS_VOICE  
            oParam = oComm.Parameters.Add("iREMARKS_VOICE", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(24)

            'ADD IN PARAMETER NAME iCOLOR   
            oParam = oComm.Parameters.Add("iCOLOR", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(25)

            'ADD IN PARAMETER NAME iREMARKS_COLOR  
            oParam = oComm.Parameters.Add("iREMARKS_COLOR", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(26)

            'ADD IN PARAMETER NAMEiNAVIGATION  
            oParam = oComm.Parameters.Add("iNAVIGATION", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(27)

            'ADD IN PARAMETER NAME iREMARKS_NVG 
            oParam = oComm.Parameters.Add("iREMARKS_NVG", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(28)

            'ADD IN PARAMETER NAME iVISIBILITY 
            oParam = oComm.Parameters.Add("iVISIBILITY", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(29)

            'ADD IN PARAMETER NAME iREMARKS_VISIB 
            oParam = oComm.Parameters.Add("iREMARKS_VISIB", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(30)
            'ADD IN PARAMETER NAME iCONDUCT 
            oParam = oComm.Parameters.Add("iCONDUCT", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(31)

            'ADD IN PARAMETER NAME iEXTLIGHT 
            oParam = oComm.Parameters.Add("iEXTLIGHT", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(32)

            'ADD IN PARAMETER NAME iROOMACCOMD 
            oParam = oComm.Parameters.Add("iROOMACCOMD", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(33)

            'ADD IN PARAMETER NAME iMODULE  
            oParam = oComm.Parameters.Add("iLIGHTAVR", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(34)

            'ADD IN PARAMETER NAME iAUDIODISTURIB
            oParam = oComm.Parameters.Add("iAUDIODISTURIB", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(35)

            'ADD IN PARAMETER NAME iMONITERING  
            oParam = oComm.Parameters.Add("iMONITERING", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(36)

            'ADD IN PARAMETER NAME iSUGG1 
            oParam = oComm.Parameters.Add("iSUGG1", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(37)

            'ADD IN PARAMETER NAME iPRIORITY1  
            oParam = oComm.Parameters.Add("iPRIORITY1", OracleType.VarChar, 5)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(38)

            'ADD IN PARAMETER NAME iSUGG2 
            oParam = oComm.Parameters.Add("iSUGG2", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(39)

            'ADD IN PARAMETER NAME iPRIORITY2  
            oParam = oComm.Parameters.Add("iPRIORITY2", OracleType.VarChar, 5)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(40)


            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParam = oComm.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(41)

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(42)

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

    Public Function Teacher_Insert(ByVal Arr As ArrayList) As Integer
        Try


            ConObj = New Connection
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "TEACHER_CLASSS_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iMONTHYEAR
            oParam = oComm.Parameters.Add("iMONTHYEAR", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            'ADD IN PARAMETER NAME iEMPID
            oParam = oComm.Parameters.Add("iEMPID", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            'ADD IN PARAMETER NAME iECLASSSLNO
            oParam = oComm.Parameters.Add("iECLASSSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)


            'ADD IN PARAMETER NAME iESECTION
            oParam = oComm.Parameters.Add("iESECTION", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            'ADD IN PARAMETER NAME iSTRENGTH
            oParam = oComm.Parameters.Add("iSTRENGTH", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParam = oComm.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)


            'ADD IN PARAMETER NAME iELEARN 
            oParam = oComm.Parameters.Add("iELEARN", OracleType.VarChar, 3)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParam = oComm.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

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

    Public Function Teacher_DT_Insert(ByVal Arr As ArrayList) As Integer
        Try


            ConObj = New Connection
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "TEACHER_DT_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSCHOOLTYPE
            oParam = oComm.Parameters.Add("iSCHOOLTYPE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            'ADD IN PARAMETER NAME iBRANCHCODE
            oParam = oComm.Parameters.Add("iBRANCHCODE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            'ADD IN PARAMETER NAME iMONTHYEAR
            oParam = oComm.Parameters.Add("iMONTHYEAR", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            'ADD IN PARAMETER NAME iEMPID
            oParam = oComm.Parameters.Add("iEMPID", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            'ADD IN PARAMETER NAME iEMPNAME
            oParam = oComm.Parameters.Add("iEMPNAME", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            'ADD IN PARAMETER NAME iTEACHSUBSLNO
            oParam = oComm.Parameters.Add("iTEACHSUB", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            'ADD IN PARAMETER NAME iECLASSTYPE
            oParam = oComm.Parameters.Add("iECLASSTYPE", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            'ADD IN PARAMETER NAME iECLASSSLNO
            oParam = oComm.Parameters.Add("iECLASSSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)


            'ADD IN PARAMETER NAME iESECTION
            oParam = oComm.Parameters.Add("iESECTION", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            'ADD IN PARAMETER NAME iSTRENGTH
            oParam = oComm.Parameters.Add("iSTRENGTH", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParam = oComm.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(10)


            'ADD IN PARAMETER NAME iELEARN 
            oParam = oComm.Parameters.Add("iELEARN", OracleType.VarChar, 3)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(11)

            'ADD IN PARAMETER NAME iMODULE  
            oParam = oComm.Parameters.Add("iMODULE", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(12)


            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParam = oComm.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(13)

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(14)

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

    Public Function Module_DT_Insert(ByVal Arr As ArrayList) As Integer
        Try


            ConObj = New Connection
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "MODULE_DT_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSCHOOLTYPE
            oParam = oComm.Parameters.Add("iSCHOOLTYPE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)


            'ADD IN PARAMETER NAME iECLASSTYPE
            oParam = oComm.Parameters.Add("iECLASSTYPE", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            'ADD IN PARAMETER NAME iECLASSSLNO
            oParam = oComm.Parameters.Add("iECLASSSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)


            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParam = oComm.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)


            'ADD IN PARAMETER NAME iMODULE  
            oParam = oComm.Parameters.Add("iMODULE", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)


            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParam = oComm.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
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

    Public Function Module_dt_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New Connection
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "MODULE_DT_DELETE"
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
    '--
    Public Function Subject_DT_Insert(ByVal Arr As ArrayList) As Integer
        Try


            ConObj = New Connection
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "SUBJECT_DT_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSCHOOLTYPE
            oParam = oComm.Parameters.Add("iSCHOOLTYPE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)


            'ADD IN PARAMETER NAME iECLASSTYPE
            oParam = oComm.Parameters.Add("iECLASSTYPE", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            'ADD IN PARAMETER NAME iECLASSSLNO
            oParam = oComm.Parameters.Add("iECLASSSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)


            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParam = oComm.Parameters.Add("iSUBJECT", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)


            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParam = oComm.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
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

    Public Function Subject_dt_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New Connection
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "SUBJECTE_DT_DELETE"
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
    '--
    Public Function Teacher_CLS_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New Connection
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "TEACHER_CLS_DELETE"
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

    Public Function Teacher_DT_DELETE(ByVal pSLNO As Integer) As Integer
        Try

            ConObj = New Connection
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "TEACHER_DT_DELETE"
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

    Public Function Teacher_DDT_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "TEACHER_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSADMSLNO
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

            'ConObj = New Connection
            'oComm = New OracleCommand
            'oParam = New OracleParameter
            'oConn = ConObj.GetConnection()

            'Ds = New DataSet

            'oComm.CommandText = "TEACHER_SELECT"
            'oComm.Connection = oConn
            'oComm.CommandType = CommandType.StoredProcedure

            'oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            'oParam.Direction = ParameterDirection.Input
            'oParam.Value = pSLNO

            'oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            'oParam.Direction = ParameterDirection.Output

            'oAdap.SelectCommand = oComm
            'oAdap.Fill(Ds)

            'Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function Module_Select(ByVal pSLNO As Integer) As DataSet
        Try

            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "MODULE_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSADMSLNO
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

    Public Function Teacher_DDT_Update(ByVal Arr As ArrayList) As Integer
        Try


            ConObj = New Connection
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()

            oComm.CommandText = "TEACHER_DDT_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSLNO
            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            'ADD IN PARAMETER NAME iMODULE  
            oParam = oComm.Parameters.Add("iMODULE", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            'ADD IN PARAMETER NAME iSCHEDULETIME 
            oParam = oComm.Parameters.Add("iSCHEDULETIME", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            'ADD IN PARAMETER NAMEiREMARKS_SCH  
            oParam = oComm.Parameters.Add("iREMARKS_SCH", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            'ADD IN PARAMETER NAME iCONCEPUT  
            oParam = oComm.Parameters.Add("iCONCEPUT", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            'ADD IN PARAMETER NAME iREMARKS_CON   
            oParam = oComm.Parameters.Add("iREMARKS_CON", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            'ADD IN PARAMETER NAME iUSERFRD 
            oParam = oComm.Parameters.Add("iUSERFRD", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            'ADD IN PARAMETER NAME iREMARKS_UFRD  
            oParam = oComm.Parameters.Add("iREMARKS_UFRD", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            'ADD IN PARAMETER NAME iCOMPTMODULE
            oParam = oComm.Parameters.Add("iCOMPTMODULE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            'ADD IN PARAMETER NAME iREMARKS_COMPT  
            oParam = oComm.Parameters.Add("iREMARKS_COMPT", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            'ADD IN PARAMETER NAME iENGUSED  
            oParam = oComm.Parameters.Add("iENGUSED", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(10)

            'ADD IN PARAMETER NAME iREMARKS_ENGU
            oParam = oComm.Parameters.Add("iREMARKS_ENGU", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(11)

            'ADD IN PARAMETER NAME iVOICE
            oParam = oComm.Parameters.Add("iVOICE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(12)

            'ADD IN PARAMETER NAME iREMARKS_VOICE  
            oParam = oComm.Parameters.Add("iREMARKS_VOICE", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(13)

            'ADD IN PARAMETER NAME iCOLOR   
            oParam = oComm.Parameters.Add("iCOLOR", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(14)

            'ADD IN PARAMETER NAME iREMARKS_COLOR  
            oParam = oComm.Parameters.Add("iREMARKS_COLOR", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(15)

            'ADD IN PARAMETER NAMEiNAVIGATION  
            oParam = oComm.Parameters.Add("iNAVIGATION", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(16)

            'ADD IN PARAMETER NAME iREMARKS_NVG 
            oParam = oComm.Parameters.Add("iREMARKS_NVG", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(17)

            'ADD IN PARAMETER NAME iVISIBILITY 
            oParam = oComm.Parameters.Add("iVISIBILITY", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(18)

            'ADD IN PARAMETER NAME iREMARKS_VISIB 
            oParam = oComm.Parameters.Add("iREMARKS_VISIB", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(19)

            'ADD IN PARAMETER NAME iCONDUCT 
            oParam = oComm.Parameters.Add("iCONDUCT", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(20)

            'ADD IN PARAMETER NAME iEXTLIGHT 
            oParam = oComm.Parameters.Add("iEXTLIGHT", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(21)

            'ADD IN PARAMETER NAME iROOMACCOMD 
            oParam = oComm.Parameters.Add("iROOMACCOMD", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(22)

            'ADD IN PARAMETER NAME iMODULE  
            oParam = oComm.Parameters.Add("iLIGHTAVR", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(23)

            'ADD IN PARAMETER NAME iAUDIODISTURIB
            oParam = oComm.Parameters.Add("iAUDIODISTURIB", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(24)

            'ADD IN PARAMETER NAME iMONITERING  
            oParam = oComm.Parameters.Add("iMONITERING", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(25)

            'ADD IN PARAMETER NAME iSUGG1 
            oParam = oComm.Parameters.Add("iSUGG1", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(26)

            'ADD IN PARAMETER NAME iPRIORITY1  
            oParam = oComm.Parameters.Add("iPRIORITY1", OracleType.VarChar, 5)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(27)

            'ADD IN PARAMETER NAME iSUGG2 
            oParam = oComm.Parameters.Add("iSUGG2", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(28)

            'ADD IN PARAMETER NAME iPRIORITY2  
            oParam = oComm.Parameters.Add("iPRIORITY2", OracleType.VarChar, 5)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(29)

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

    Public Function Teacher_InsertOLD(ByVal Arr1 As ArrayList, ByVal pDs As DataSet) As Byte
        'Public Function Teacher_Insert(ByVal Arr As ArrayList, ByVal Arr1 As ArrayList, ByVal pDs As DataSet) As Byte
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction

            rtnVal = Teacher_Subjects_Insert(pDs, oConn, oTrans)
            If rtnVal = 1 Then
                rtnVal = Teacher_DT_Insert(Arr1, oConn, oTrans)
                If rtnVal <> 1 Then
                    oTrans.Rollback()
                    Return 2
                End If
            Else
                oTrans.Rollback()
                Return rtnVal
            End If

            oTrans.Commit()
            Return 1

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function Teacher_FB_Insert(ByVal pDs As DataSet) As Byte
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction

            rtnVal = Teacher_FB_Insert(pDs, oConn, oTrans)
            If rtnVal = 1 Then

                If rtnVal <> 1 Then
                    oTrans.Rollback()
                    Return 2
                End If
            Else
                oTrans.Rollback()
                Return rtnVal
            End If

            oTrans.Commit()
            Return 1

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function Teacher_Dt_Insert(ByVal Arr1 As ArrayList, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            oConn = ConObj.GetConnection() 'Establishing the Connection .
            oComm.CommandText = "TEACHERS_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSCHOOLTYPE 
            oParam = oComm.Parameters.Add("iSCHOOLTYPE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            'oParam.SourceColumn = "SCHOOLTYPE"
            oParam.Value = Arr1(0)

            'ADD IN PARAMETER NAME iBRANCHCODE
            oParam = oComm.Parameters.Add("iBRANCHCODE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            'oParam.SourceColumn = "BRANCHCODE"
            oParam.Value = Arr1(1)

            'ADD IN PARAMETER NAME iMONTHYEAR
            oParam = oComm.Parameters.Add("iMONTHYEAR", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            'oParam.SourceColumn = "MONTHYEAR"
            oParam.Value = Arr1(2)

            'ADD IN PARAMETER NAME iEMPID
            oParam = oComm.Parameters.Add("iEMPID", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            'oParam.SourceColumn = "EMPID"
            oParam.Value = Arr1(3)

            'ADD IN PARAMETER NAME iNAME
            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            'oParam.SourceColumn = "NAME"
            oParam.Value = Arr1(4)

            'ADD IN PARAMETER NAME iSUBJECT 
            oParam = oComm.Parameters.Add("iSUBJECTSLNO", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            'oParam.SourceColumn = "SUBJECTSLNO"
            oParam.Value = Arr1(5)


            'ADD IN PARAMETER NAME iSCHOOLS 
            oParam = oComm.Parameters.Add("iSCHOOLS", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            'oParam.SourceColumn = "SCHOOLS"
            oParam.Value = Arr1(6)

            ' ADD IN PARAMETER NAME iCLASS 
            oParam = oComm.Parameters.Add("iECLASS", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            'oParam.SourceColumn = "ECLASS"
            oParam.Value = Arr1(7)

            ''ADD IN PARAMETER NAME iTEACHERSUBJECT 
            'oParam = oComm.Parameters.Add("iTEACHERSUBJECT", OracleType.VarChar, 20)
            'oParam.Direction = ParameterDirection.Input
            'oParam.SourceColumn = "TEACHERSUBJECT"

            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParam = oComm.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            'oParam.SourceColumn = "ACADEMICSLNO"
            oParam.Value = Arr1(8)

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            'oParam.SourceColumn = "USERSLNO"
            oParam.Value = Arr1(9)

            oComm.ExecuteNonQuery()

            Return 1

            'oAdap.InsertCommand = oComm
            'oAdap.Update(Ds.Tables(0))

            'Return 1

        Catch Oex As OracleException
            rtnMessage = Oex.Message
            Throw Oex
        Catch ex As Exception
            rtnMessage = ex.Message
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return rtnMessage

    End Function

    Public Function Teacher_Subjects_InsertOLD(ByVal Arr As ArrayList, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            oConn = ConObj.GetConnection() 'establishing the Connection .
            oComm.CommandText = "TEACHERS_SUBJECTS_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iTRANSDATE
            oParam = oComm.Parameters.Add("iMONTH_YEAR", OracleType.VarChar, 25)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            'ADD IN PARAMETER NAME iSERVERDATE
            ''oParam = oComm.Parameters.Add("iSERVERDATE", OracleType.DateTime)
            ''oParam.Direction = ParameterDirection.Input
            ''oParam.Value = Arr(1)

            'ADD IN PARAMETER NAME iEMPID
            oParam = oComm.Parameters.Add("iEMPID", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)


            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParam = oComm.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            'ADD IN PARAMETER NAME iUSERSLNO
            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)


            'ADD IN PARAMETER NAME iCLASS
            oParam = oComm.Parameters.Add("iECLASS", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            'ADD IN PARAMETER NAME iSECTION
            oParam = oComm.Parameters.Add("iSSECTION", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            'ADD IN PARAMETER NAME iSTRENGTH
            oParam = oComm.Parameters.Add("iSTRENGTH", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            'ADD IN PARAMETER NAME iSUBJECT
            oParam = oComm.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            'ADD IN PARAMETER NAME iELCLASS
            oParam = oComm.Parameters.Add("iELCLASS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)



            oComm.ExecuteNonQuery()

            Return 1

        Catch Oex As OracleException
            rtnMessage = Oex.Message
            Throw Oex
        Catch ex As Exception
            rtnMessage = ex.Message
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return rtnMessage

    End Function

    Public Function Teacher_Subjects_Insert(ByVal Gds As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            oConn = ConObj.GetConnection() 'establishing the Connection .
            'oComm.CommandText = "TEACHERS_SUBJECTS_INSERT"
            'oComm.Connection = oConn
            'oComm.CommandType = CommandType.StoredProcedure

            If Gds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To Gds.Tables(0).Rows.Count - 1

                    oComm = New OracleCommand
                    oComm.CommandText = "TEACHERS_SUBJECTS_INSERT"
                    oComm.Connection = oConn
                    oComm.CommandType = CommandType.StoredProcedure
                    oParam = New OracleParameter


                    'ADD IN PARAMETER NAME iTRANSDATE
                    oParam = oComm.Parameters.Add("iMONTH_YEAR", OracleType.VarChar, 25)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToString(Gds.Tables(0).Rows(i)("MONTH_YEAR"))

                    'ADD IN PARAMETER NAME iEMPID
                    oParam = oComm.Parameters.Add("iEMPID", OracleType.Number)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToInt64(Gds.Tables(0).Rows(i)("EMPID"))


                    'ADD IN PARAMETER NAME iACADEMICSLNO
                    oParam = oComm.Parameters.Add("iACADEMICSLNO", OracleType.Number)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToInt64(Gds.Tables(0).Rows(i)("ACADEMICSLNO"))

                    'ADD IN PARAMETER NAME iUSERSLNO
                    oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToInt64(Gds.Tables(0).Rows(i)("USERSLNO"))


                    'ADD IN PARAMETER NAME iCLASS
                    oParam = oComm.Parameters.Add("iECLASS", OracleType.VarChar, 20)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToString(Gds.Tables(0).Rows(i)("ECLASS"))

                    'ADD IN PARAMETER NAME iSECTION
                    oParam = oComm.Parameters.Add("iSSECTION", OracleType.VarChar, 20)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToString(Gds.Tables(0).Rows(i)("SSECTION"))

                    'ADD IN PARAMETER NAME iSTRENGTH
                    oParam = oComm.Parameters.Add("iSTRENGTH", OracleType.Number)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToInt64(Gds.Tables(0).Rows(i)("STRENGTH"))

                    'ADD IN PARAMETER NAME iSUBJECT
                    oParam = oComm.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToInt64(Gds.Tables(0).Rows(i)("SUBJECTSLNO"))


                    'ADD IN PARAMETER NAME iELCLASS
                    oParam = oComm.Parameters.Add("iELCLASS", OracleType.Number)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToInt64(Gds.Tables(0).Rows(i)("ELCLASS"))

                    Dim J As Integer
                    J = J + oComm.ExecuteNonQuery()
                    oParam = Nothing

                    ' oComm.ExecuteNonQuery()
                Next
            End If
            Return 1
        Catch Oex As OracleException
            rtnMessage = Oex.Message
            Throw Oex
        Catch ex As Exception
            rtnMessage = ex.Message
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return rtnMessage

    End Function

    Public Function Teacher_FB_Insert(ByVal Gds As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            oConn = ConObj.GetConnection() 'establishing the Connection .

            If Gds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To Gds.Tables(0).Rows.Count - 1

                    oComm = New OracleCommand
                    oComm.CommandText = "TEACHERS_FEEDBACK_INSERT"
                    oComm.Connection = oConn
                    oComm.CommandType = CommandType.StoredProcedure
                    oParam = New OracleParameter


                    'ADD IN PARAMETER NAME iEMPID
                    oParam = oComm.Parameters.Add("iEMPID", OracleType.Number)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToInt64(Gds.Tables(0).Rows(i)("EMPID"))


                    'ADD IN PARAMETER NAME iACADEMICSLNO
                    oParam = oComm.Parameters.Add("iACADEMICSLNO", OracleType.Number)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToInt64(Gds.Tables(0).Rows(i)("ACADEMICSLNO"))

                    'ADD IN PARAMETER NAME iUSERSLNO
                    oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToInt64(Gds.Tables(0).Rows(i)("USERSLNO"))


                    'ADD IN PARAMETER NAME iCLASS
                    oParam = oComm.Parameters.Add("iECLASS", OracleType.VarChar, 20)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToString(Gds.Tables(0).Rows(i)("ECLASS"))

                    'ADD IN PARAMETER NAME iSECTION
                    oParam = oComm.Parameters.Add("iSSECTION", OracleType.VarChar, 20)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToString(Gds.Tables(0).Rows(i)("SSECTION"))

                    'ADD IN PARAMETER NAME iSTRENGTH
                    oParam = oComm.Parameters.Add("iSTRENGTH", OracleType.Number)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToInt64(Gds.Tables(0).Rows(i)("STRENGTH"))

                    'ADD IN PARAMETER NAME iSUBJECT
                    oParam = oComm.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToInt64(Gds.Tables(0).Rows(i)("SUBJECTSLNO"))

                    'ADD IN PARAMETER NAME iMODULE
                    oParam = oComm.Parameters.Add("iMODULE", OracleType.VarChar, 50)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToString(Gds.Tables(0).Rows(i)("MODULE"))

                    'ADD IN PARAMETER NAME iCONCEPTSLNO
                    oParam = oComm.Parameters.Add("iCONCEPTSLNO", OracleType.Number)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToInt64(Gds.Tables(0).Rows(i)("CONCEPTSLNO"))

                    'ADD IN PARAMETER NAME iSECTION
                    oParam = oComm.Parameters.Add("iNEED", OracleType.VarChar, 50)
                    oParam.Direction = ParameterDirection.Input
                    oParam.Value = Convert.ToString(Gds.Tables(0).Rows(i)("NEED"))

                    Dim J As Integer
                    J = J + oComm.ExecuteNonQuery()
                    oParam = Nothing

                    ' oComm.ExecuteNonQuery()
                Next
            End If
            Return 1
        Catch Oex As OracleException
            rtnMessage = Oex.Message
            Throw Oex
        Catch ex As Exception
            rtnMessage = ex.Message
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return rtnMessage

    End Function

    Public Function Teacher_Select(ByVal PSADMSLNO As Integer, ByVal PACADEMICSLNO As Byte) As DataSet
        Try

            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "P_STUDENT_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSADMSLNO
            oParam = oComm.Parameters.Add("iSADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PSADMSLNO

            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParam = oComm.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PACADEMICSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function Teacher_Delect(ByVal PSADMSLNO As Integer, ByVal PACADEMICSLNO As Byte) As DataSet
        Try

            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "P_STUDENTEDUDTLS_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSADMSLNO
            oParam = oComm.Parameters.Add("iSADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PSADMSLNO

            'ADD IN PARAMETER NAME iACADEMICSLNO
            oParam = oComm.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PACADEMICSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function Teacher_Update(ByVal Arr As ArrayList) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("F_STUDENT_UPDATE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iGENDER", OracleType.Char, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iCASTESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)


            oParam = oComm.Parameters.Add("iDOB", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iDOJ", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iTRANSDATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iSADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oParam = oComm.Parameters.Add("iTRUSTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            '----------------------FATHER DETAILS------------------------

            oParam = oComm.Parameters.Add("iFNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            oParam = oComm.Parameters.Add("iFSTATUSSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(10)

            oParam = oComm.Parameters.Add("iFQUALIFICATION", OracleType.VarChar, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(11)

            oParam = oComm.Parameters.Add("iFPROFESSION", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(12)


            oParam = oComm.Parameters.Add("iFINCOME", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(13)

            oParam = oComm.Parameters.Add("iFDATEOFEXPIRED", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(14)

            oParam = oComm.Parameters.Add("iFCAUSEOFDEATH", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(15)

            oParam = oComm.Parameters.Add("iFPBELONGS", OracleType.Char, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(16)

            oParam = oComm.Parameters.Add("iFPDESIGNATIONSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(17)

            oParam = oComm.Parameters.Add("iFPJOINDATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(18)

            '----------------------MOTHER DETAILS------------------------

            oParam = oComm.Parameters.Add("iMNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(19)

            oParam = oComm.Parameters.Add("iMSTATUSSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(20)

            oParam = oComm.Parameters.Add("iMQUALIFICATION", OracleType.VarChar, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(21)

            oParam = oComm.Parameters.Add("iMPROFESSION", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(22)

            oParam = oComm.Parameters.Add("iMINCOME", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(23)

            oParam = oComm.Parameters.Add("iMDATEOFEXPIRED", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(24)

            oParam = oComm.Parameters.Add("iMCAUSEOFDEATH", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(25)

            oParam = oComm.Parameters.Add("iMPBELONGS", OracleType.Char, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(26)

            oParam = oComm.Parameters.Add("iMPDESIGNATIONSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(27)

            oParam = oComm.Parameters.Add("iMPJOINDATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(28)

            ''-------------------ADDRESS DETAILS-------------------------

            oParam = oComm.Parameters.Add("iHNO", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(29)

            oParam = oComm.Parameters.Add("iSTREET_VILL", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(30)

            oParam = oComm.Parameters.Add("iMANDALSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(31)

            oParam = oComm.Parameters.Add("iCONSTITUTIONSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(32)

            oParam = oComm.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(33)

            oParam = oComm.Parameters.Add("iSTATESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(34)

            oParam = oComm.Parameters.Add("iCOUNTRYSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(35)

            oParam = oComm.Parameters.Add("iPINCODE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(36)


            oParam = oComm.Parameters.Add("iPHONE1", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(37)

            oParam = oComm.Parameters.Add("iPHONE2", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(38)

            oParam = oComm.Parameters.Add("iMOBILE1", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(39)

            oParam = oComm.Parameters.Add("iMOBILE2", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(40)


            oParam = oComm.Parameters.Add("iEMAILID", OracleType.VarChar, 150)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(41)

            ''---------------REFERED PERSON PARTY DETAILS-----------------

            oParam = oComm.Parameters.Add("iNOOFBROTHERS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(42)

            oParam = oComm.Parameters.Add("iNOOFSISTERS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(43)

            oParam = oComm.Parameters.Add("iREFPERSON", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(44)

            oParam = oComm.Parameters.Add("iRPDESIGNATIONSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(45)

            oParam = oComm.Parameters.Add("iRCONTACTNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(46)

            oParam = oComm.Parameters.Add("iPREVSTUREF", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(47)

            oParam = oComm.Parameters.Add("iPREVSTUCOURSESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(48)

            oParam = oComm.Parameters.Add("iPREVSTUDOJ", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(49)


            ''---------------Teacher GENERAL INFORMATION------------------

            oParam = oComm.Parameters.Add("iPREVCLASS", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(50)

            oParam = oComm.Parameters.Add("iPREVSTUDIES", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(51)

            oParam = oComm.Parameters.Add("iPERFORMANCE", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(52)

            oParam = oComm.Parameters.Add("iREMARKS", OracleType.VarChar, 250)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(53)

            ''NEW
            oParam = oComm.Parameters.Add("iACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(54)

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(55)

            oParam = oComm.Parameters.Add("iSTUTYPE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(56)


            oComm.Parameters.Add(New OracleParameter("oRtnValue", OracleType.VarChar, 200)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()

            rtnMessage = oComm.Parameters("oRtnValue").Value

            oTrans.Commit()

            Return rtnMessage

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function
#End Region

End Class
