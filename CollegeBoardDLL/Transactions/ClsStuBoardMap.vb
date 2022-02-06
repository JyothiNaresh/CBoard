'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is for Mappings
'   ACTIVITY                          :  
'   AUTHOR                            : K.SHANKAR SUDERSHAN RAO
'   INITIAL BASELINE DATE             : 22-JULY-2009
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration
Public Class ClsStuBoardMap
#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ds As New Data.DataSet
    Private oTrans As OracleTransaction
    Private ObjConn As Connection
    Private Result As String

#End Region

#Region "Students Board Mappings"

    Public Function StudentBoardMapSelect(ByVal SpName As String, ByVal Dset As DataSet, ByVal DTable As String, ByVal iEXAMBRANCHSLNO As Integer, ByVal iCOURSESLNO As Integer, ByVal iGROUPSLNO As Integer, ByVal iBATCHSLNO As Integer, ByVal iSECTIONSLNO As Integer, ByVal iADMNO As String, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = SpName
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO 
            oParameter = oCommand.Parameters.Add("iADMNO", OracleType.VarChar, 8)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iADMNO


            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO 
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOURSESLNO

            'ADD IN PARAMETER NAME iGROUPSLNO 
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iGROUPSLNO

            'ADD IN PARAMETER NAME iBATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBATCHSLNO

            'ADD IN PARAMETER NAME iSECTIONSLNO 
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSECTIONSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO 
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Dset, DTable) '"Students")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Dset

    End Function
#End Region

#Region "Student Board Mapping BY KSSR"

    Public Function StuBoardMap_Save(ByVal DsStudents As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudents) AndAlso DsStudents.Tables("Students").Rows.Count > 0 Then
                StuBoardMapUpdate(DsStudents, oConn, oTrans)
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

    Private Function StuBoardMapUpdate(ByVal DsStudents As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "EXAM_STUBOARDMAP_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iADDRESSSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"


            'Add In Parameter as iBOARDIDNO
            oParameter = uCommand.Parameters.Add("iBOARDIDNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BOARDIDNO"

            'Add In Parameter as iBOARDCOLLCODE
            oParameter = uCommand.Parameters.Add("iBOARDCOLLCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BOARDCOLLCODE"

            'Add In Parameter as iPHONE1
            oParameter = uCommand.Parameters.Add("iCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CASTESLNO"

            'Add In Parameter as iPHONE1
            oParameter = uCommand.Parameters.Add("iDOB", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DOB"

            'Add In Parameter as iPHONE1
            oParameter = uCommand.Parameters.Add("iGENDER", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GENDER"


            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudents, "Students")

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "School Tc Details Entry"

    Public Function StuTcDet_Save(ByVal DsStudent As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudent) AndAlso DsStudent.Tables(0).Rows.Count > 0 Then
                StuBoardMapUpdate(DsStudent, oConn, oTrans)
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

    Private Function StuTcDetailsUpdate(ByVal DsStudent As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "EXAM_STUTCDETAILS_INSERT"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iADDRESSSLNO
            oParameter = uCommand.Parameters.Add("UNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "UNIQUENO"


            'Add In Parameter as iBOARDIDNO
            oParameter = uCommand.Parameters.Add("iADMNO", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMNO"

            'Add In Parameter as iBOARDCOLLCODE
            oParameter = uCommand.Parameters.Add("iADDR1", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADDR1"

            'Add In Parameter as iPHONE1
            oParameter = uCommand.Parameters.Add("iADDR2", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADDR2"

            'Add In Parameter as iPHONE1
            oParameter = uCommand.Parameters.Add("iADDR3", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADDR3"

            'Add In Parameter as iPHONE1
            oParameter = uCommand.Parameters.Add("iADDR4", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADDR4"


            oParameter = uCommand.Parameters.Add("iSNAME", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SNAME"

            oParameter = uCommand.Parameters.Add("iFNAME", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "FNAME"

            oParameter = uCommand.Parameters.Add("iRELIGION", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RELIGION"


            oParameter = uCommand.Parameters.Add("iCASTE", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CASTE"


            oParameter = uCommand.Parameters.Add("iSUBCASTE", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBCASTE"


            oParameter = uCommand.Parameters.Add("iDOB", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DOB"


            oParameter = uCommand.Parameters.Add("iHIGHESTCLASS", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "HIGHESTCLASS"

            oParameter = uCommand.Parameters.Add("ipresentcourse", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "presentcourse"

            oParameter = uCommand.Parameters.Add("iFLANG", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "FLANG"

            oParameter = uCommand.Parameters.Add("iSLANG", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLANG"


            oParameter = uCommand.Parameters.Add("iCOURSEOFJOIN", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "iCOURSEOFJOIN"

            oParameter = uCommand.Parameters.Add("iMOLE1", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "iMOLE1"


            oParameter = uCommand.Parameters.Add("iMOLE2", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "iMOLE2"

            oParameter = uCommand.Parameters.Add("iMTONG", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "iMTONG"


            oParameter = uCommand.Parameters.Add("iYOJ", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "iYOJ"

            oParameter = uCommand.Parameters.Add("iPHYSICAL", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "iPHYSICAL"

            oParameter = uCommand.Parameters.Add("iATTENDANCE", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "iATTENDANCE"


            oParameter = uCommand.Parameters.Add("iNOFDAYS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "iNOFDAYS"


            oParameter = uCommand.Parameters.Add("TCDATE", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TCDATE"


            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudent, "Students")

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function STUTC_MTINSERT(ByVal ArrMt As ArrayList) As Integer
        Try
            oCommand = New OracleCommand
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAM_STUTC_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'OBJEBSLNO
            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ArrMt(0)

            'OBJEBLANDLINE
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ArrMt(1)



            'OBJEBLANDLINE
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ArrMt(2)


            'OBJEBLANDLINE
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ArrMt(3)




            'OBJEBLANDLINE
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ArrMt(4)


            oCommand.Parameters.Add(New OracleParameter("SeqMt", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            Result = oCommand.Parameters("SeqMt").Value

            Return Result

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function
#End Region

End Class
