'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is the Middle layer for NTR Student Infomation.
'   ACTIVITY                          : New/Edit
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 02-MAY-2006
'   FINAL BASELINE DATE               : 02-MAY-2006
'   MODIFICATIONS LOG                 : Nil
'   SCRIPT FILE PATH                  : 
'----------------------------------------------------------------------------------------------

Imports System.Data
Imports System.Data.OracleClient

Public Class NTRStudent

#Region "Class Variables"

    Private oConn As OracleConnection 'Connection Object Declaration.
    Private oComm As OracleCommand 'Command Object Declaration.
    Private oTrans As OracleTransaction 'Transaction Object Declaration.
    Private oAdap As OracleDataAdapter 'Adapter Object Declaration.
    Private oParam As OracleParameter 'Parameter Object Declaration.
    Private Ds As DataSet
    Private ConObj As Connection
    Private rtnMessage As String 'Result of the return type.

#End Region

#Region "Insert Update Methods"

    Public Function NTRStuInfo_Insert(ByVal Arr As ArrayList) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("NTRSTUINFORMATION_INSERT")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iFNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iFSTATUS", OracleType.VarChar, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iFQUALIFICATION", OracleType.VarChar, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iFPROFESSIN", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)


            oParam = oComm.Parameters.Add("iFINCOME", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iFDATEOFEXPIRED", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iFCAUSEOFDEATH", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oParam = oComm.Parameters.Add("iMNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            oParam = oComm.Parameters.Add("iMSTATUS", OracleType.VarChar, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            oParam = oComm.Parameters.Add("iMQUALIFICATION", OracleType.VarChar, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(10)

            oParam = oComm.Parameters.Add("iMPROFESSIN", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(11)


            oParam = oComm.Parameters.Add("iMINCOME", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(12)

            oParam = oComm.Parameters.Add("iMDATEOFEXPIRED", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(13)

            oParam = oComm.Parameters.Add("iMCAUSEOFDEATH", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(14)

            oParam = oComm.Parameters.Add("iADMREF", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(15)

            oParam = oComm.Parameters.Add("iADMTYPE", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(16)

            oParam = oComm.Parameters.Add("iCONREF", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(17)

            '' NEW COLUMN

            oParam = oComm.Parameters.Add("iADMREFCONTACTNO", OracleType.Number, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(18)


            oParam = oComm.Parameters.Add("iCAUSE", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(19)

            oParam = oComm.Parameters.Add("iPBLONGS", OracleType.VarChar, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(20)

            oParam = oComm.Parameters.Add("iDESIGNATION", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(21)


            ''GK
            oParam = oComm.Parameters.Add("iMPBLONGS", OracleType.VarChar, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(22)

            oParam = oComm.Parameters.Add("iMDESIGNATION", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(23)
            ''GK

            oParam = oComm.Parameters.Add("iNOOFBROTHERS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(24)

            oParam = oComm.Parameters.Add("iNOOFSISTERS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(25)

            '' NEW COLUMN

            oParam = oComm.Parameters.Add("iSTUPREVCLASS", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(26)

            oParam = oComm.Parameters.Add("iCOUNTRYSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(27)

            oParam = oComm.Parameters.Add("iSTATESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(28)

            oParam = oComm.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(29)

            ''NEW
            oParam = oComm.Parameters.Add("iMANDALSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(30)

            ''NEW

            oParam = oComm.Parameters.Add("iCONSTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(31)


            oParam = oComm.Parameters.Add("iMANDAL_AREA", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(32)

            oParam = oComm.Parameters.Add("iSTREET_VILL", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(33)

            oParam = oComm.Parameters.Add("iHNO", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(34)

            oParam = oComm.Parameters.Add("iPIN", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(35)

            oParam = oComm.Parameters.Add("iPHONERES", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(36)

            oParam = oComm.Parameters.Add("iPHONEOFF", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(37)

            oParam = oComm.Parameters.Add("iMOBILE1", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(38)

            oParam = oComm.Parameters.Add("iMOBILE2", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(39)

            oParam = oComm.Parameters.Add("iEMAIL", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(40)

            ''GK
            oParam = oComm.Parameters.Add("iPRVCLJOINYEAR", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(41)
            ''GK

            ' oComm.Parameters.Add(New OracleParameter("oRtnValue", OracleType.VarChar, 200)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()

            'rtnMessage = oComm.Parameters("oRtnValue").Value

            oTrans.Commit()

            Return " Record Saved "

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

#Region "Search"

    Public Function GetDataForSearch(ByVal STR As String) As DataSet
        Try

            Dim BRANCHSLNO, COURSESLNO, GROUPSLNO, ADMSNO, FORMNO, COMACADEMICSLNO As Long
            Dim NAME, FATHERNAME, STATUS As String

            Dim Str_Split() As String

            If STR <> "" Then
                Str_Split = STR.Split("~")
                BRANCHSLNO = Str_Split(0)
                COURSESLNO = Str_Split(1)
                GROUPSLNO = Str_Split(2)
                NAME = Str_Split(3)
                FATHERNAME = Str_Split(4)
                ADMSNO = Str_Split(5)
                FORMNO = Str_Split(6)
                STATUS = Str_Split(7)
                COMACADEMICSLNO = Str_Split(8)
            End If

            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "M_NTRADM_SELECT_SEARCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = BRANCHSLNO

            oParam = oComm.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COURSESLNO

            oParam = oComm.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = GROUPSLNO

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = NAME

            oParam = oComm.Parameters.Add("iFATHERNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = FATHERNAME

            oParam = oComm.Parameters.Add("iADMSNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ADMSNO

            oParam = oComm.Parameters.Add("iFORMNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = FORMNO

            oParam = oComm.Parameters.Add("iSTATUS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = STATUS

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

    Public Function GetDataForUpdate(ByVal PADMSLNO As Long) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "M_NTRADM_SELECT_FOR_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PADMSLNO

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
