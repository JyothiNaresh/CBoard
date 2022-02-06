Imports System.Data
Imports System.Data.OracleClient
Public Class StudentDetailsChangeNew

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

#Region "SectionWiseStudentInfoUpdate"

    Public Function StudentInfoBatch_Insert(ByVal Ds As DataSet) As Integer
        Try
            ConObj = New Connection
            oAdap = New OracleDataAdapter
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("STUDENINFOBATCH_INSERT")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iEXAMBRANCHSLNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "EXAMBRANCHSLNO_OLD"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oParam = oComm.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "UNIQUENO"

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "USERSLNO"

            oParam = oComm.Parameters.Add("iADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ADMSLNO"

            '-------------------OLD FIELDS---------------------

            oParam = oComm.Parameters.Add("iCASTESLNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "CASTESLNO_OLD"

            oParam = oComm.Parameters.Add("iDOB_OLD", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "DOB_OLD"


            oParam = oComm.Parameters.Add("iUNIVERSITYSLNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "UNIVERSITYSLNO_OLD"


            oParam = oComm.Parameters.Add("iEMAIL_OLD", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "EMAIL_OLD"


            oParam = oComm.Parameters.Add("iSPONSORDISTRICT_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SPONSORDISTRICT_OLD"

            oParam = oComm.Parameters.Add("iPHONERES_OLD", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "PHONERES_OLD"

            oParam = oComm.Parameters.Add("iPHONEOFF_OLD", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "PHONEOFF_OLD"


            oParam = oComm.Parameters.Add("iMOBILE1_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "MOBILE1_OLD"

            oParam = oComm.Parameters.Add("iMOBILE2_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "MOBILE2_OLD"

            oParam = oComm.Parameters.Add("iFATHEROCCUPATION_OLD", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "FATHEROCCUPATION_OLD"

            oParam = oComm.Parameters.Add("iSUBBATCHSLNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SUBBATCHSLNO_OLD"

            oParam = oComm.Parameters.Add("iSUBSECTIONSLNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SUBSECTIONSLNO_OLD"

            oParam = oComm.Parameters.Add("iPIN_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "PIN_OLD"

            oParam = oComm.Parameters.Add("iISPHOTOUPLOADED_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ISPHOTOUPLOADED_OLD"

            oParam = oComm.Parameters.Add("iSCHLRP_APPNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SCHLRP_APPNO_OLD"

            '-------------------NEW FIELDS---------------------

            oParam = oComm.Parameters.Add("iCASTESLNO_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "CASTESLNO_NEW"

            oParam = oComm.Parameters.Add("iDOB_NEW", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "DOB_NEW"


            oParam = oComm.Parameters.Add("iUNIVERSITYSLNO_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "UNIVERSITYSLNO_NEW"


            oParam = oComm.Parameters.Add("iEMAIL_NEW", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "EMAIL_NEW"

            oParam = oComm.Parameters.Add("iSPONSORDISTRICT_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SPONSORDISTRICT_NEW"

            oParam = oComm.Parameters.Add("iPHONERES_NEW", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "PHONERES_NEW"

            oParam = oComm.Parameters.Add("iPHONEOFF_NEW", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "PHONEOFF_NEW"


            oParam = oComm.Parameters.Add("iMOBILE1_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "MOBILE1_NEW"

            oParam = oComm.Parameters.Add("iMOBILE2_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "MOBILE2_NEW"

            oParam = oComm.Parameters.Add("iFATHEROCCUPATION_NEW", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "FATHEROCCUPATION_NEW"

            oParam = oComm.Parameters.Add("iSUBBATCHSLNO_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SUBBATCHSLNO_NEW"

            oParam = oComm.Parameters.Add("iSUBSECTIONSLNO_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SUBSECTIONSLNO_NEW"

            oParam = oComm.Parameters.Add("iPIN_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "PIN_NEW"

            oParam = oComm.Parameters.Add("iISPHOTOUPLOADED_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ISPHOTOUPLOADED_NEW"

            oParam = oComm.Parameters.Add("iSCHLRP_APPNO_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SCHLRP_APPNO_NEW"

            oAdap.InsertCommand = oComm
            oAdap.Update(Ds.Tables(0))

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

    Public Function StudentInfoSingle_InsertK(ByVal Arr As ArrayList) As String
        Try

            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand
            oComm.CommandText = "STUDENTINFO_INSERTNEW"
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iEXAMBRANCHSLNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            '-------------------OLD FIELDS------------------------------------

            oParam = oComm.Parameters.Add("iCOUNTRYSLNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iSTATESLNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iDISTRICTSLNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oParam = oComm.Parameters.Add("iMANDALSLNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            oParam = oComm.Parameters.Add("iHNO_OLD", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            oParam = oComm.Parameters.Add("iPIN_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(10)

            oParam = oComm.Parameters.Add("iPHONERES_OLD", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(11)

            oParam = oComm.Parameters.Add("iPHONEOFF_OLD", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(12)

            oParam = oComm.Parameters.Add("iMOBILE1_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(13)

            oParam = oComm.Parameters.Add("iMOBILE2_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(14)

            oParam = oComm.Parameters.Add("iEMAIL_OLD", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(15)

            oParam = oComm.Parameters.Add("iCASTESLNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(16)

            oParam = oComm.Parameters.Add("iDOB_OLD", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(17)

            oParam = oComm.Parameters.Add("iSPONSORDISTRICT_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(18)

            oParam = oComm.Parameters.Add("iUNIVERSITYSLNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(19)

            oParam = oComm.Parameters.Add("iISPHOTOUPLOADED_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(20)

            oParam = oComm.Parameters.Add("iFATHEROCCUPATION_OLD", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(21)

            oParam = oComm.Parameters.Add("iSCHLRP_APPNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(22)

            oParam = oComm.Parameters.Add("iSUBBATCHSLNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(23)

            oParam = oComm.Parameters.Add("iSUBSECTIONSLNO_OLD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(24)

            '-------------------NEW FIELDS---------------------------------------

            oParam = oComm.Parameters.Add("iEXAMBRANCHSLNO_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(25)

            oParam = oComm.Parameters.Add("iCOUNTRYSLNO_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(26)

            oParam = oComm.Parameters.Add("iSTATESLNO_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(27)

            oParam = oComm.Parameters.Add("iDISTRICTSLNO_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(28)

            oParam = oComm.Parameters.Add("iMANDALSLNO_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(29)

            oParam = oComm.Parameters.Add("iHNO_NEW", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(30)

            oParam = oComm.Parameters.Add("iPIN_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(31)

            oParam = oComm.Parameters.Add("iPHONERES_NEW", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(32)

            oParam = oComm.Parameters.Add("iPHONEOFF_NEW", OracleType.VarChar, 12)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(33)

            oParam = oComm.Parameters.Add("iMOBILE1_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(34)

            oParam = oComm.Parameters.Add("iMOBILE2_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(35)


            oParam = oComm.Parameters.Add("iEMAIL_NEW", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(36)

            oParam = oComm.Parameters.Add("iCASTESLNO_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(37)

            oParam = oComm.Parameters.Add("iDOB_NEW", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(38)

            oParam = oComm.Parameters.Add("iSPONSORDISTRICT_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(39)


            oParam = oComm.Parameters.Add("iUNIVERSITYSLNO_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(40)

            oParam = oComm.Parameters.Add("iISPHOTOUPLOADED_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(41)

            oParam = oComm.Parameters.Add("iFATHEROCCUPATION_NEW", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(42)

            oParam = oComm.Parameters.Add("iSCHLRP_APPNO_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(43)


            oParam = oComm.Parameters.Add("iSUBBATCHSLNO_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(44)

            oParam = oComm.Parameters.Add("iSUBSECTIONSLNO_NEW", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(45)

            oComm.ExecuteNonQuery()
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

    Public Function PRVSCHOOL_Save(ByVal Arr As ArrayList) As String
        Dim rtnString As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand
            oComm.CommandText = "EXAM_PRVSCHOOLSAVE"

            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iCORPSCHOOLSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iPRVDISTRICTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iPRVSCHOOLSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)


            oComm.ExecuteNonQuery()
            oTrans.Commit()

            Return 1

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return rtnString

    End Function

    Public Function EXAMHtno_Save(ByVal Arr As ArrayList) As String
        Dim rtnString As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand
            oComm.CommandText = "EXAM_HTNOSAVEREMARK"

            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iHTNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)


            oParam = oComm.Parameters.Add("iREMARK", OracleType.VarChar, 200)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)


            oComm.ExecuteNonQuery()
            oTrans.Commit()

            Return 1

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return rtnString

    End Function

#End Region

End Class
