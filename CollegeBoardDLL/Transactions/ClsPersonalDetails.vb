'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating Exams
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 16-AUG-2006
'   FINAL BASELINE DATE               : 16-AUG-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration
Public Class ClsPersonalDetails

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

#Region "Personal Details"


    Public Function PersonalDetails_select(ByVal Admslno As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet("SPDTable")

            oCommand.CommandText = "SPDETAILS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Admslno

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "SPDTable")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function PersonalDetails_Save(ByVal SPDset As DataSet) As String
        Dim rtnString As String

        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(SPDset) AndAlso SPDset.Tables(0).Rows.Count > 0 Then
                SPDSave(SPDset, oConn, oTrans)
            End If


            oTrans.Commit()
            rtnString = "Record Saved"

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

    Private Function SPDSave(ByVal SPDset As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            iCommand.Transaction = pTrans
            iCommand.CommandText = "SPDETAILS_INSERT"
            iCommand.Connection = pConn
            iCommand.CommandType = CommandType.StoredProcedure

            uCommand.Transaction = pTrans
            uCommand.CommandText = "SPDETAILS_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure

            dCommand.Transaction = pTrans
            dCommand.CommandText = "SPDETAILS_DELETE"
            dCommand.Connection = pConn
            dCommand.CommandType = CommandType.StoredProcedure



            'Add In Parameter as iADMSLNO
            oParameter = iCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add In Parameter as iBLOODGROUP
            oParameter = iCommand.Parameters.Add("iBLOODGROUP", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BLOODGROUP"

            'Add In Parameter as iIDMARKS
            oParameter = iCommand.Parameters.Add("iIDMARKS", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "IDMARKS"

            'Add In Parameter as iDESCRIPTION
            oParameter = iCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.InsertCommand = iCommand

            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iSPDSLNO
            oParameter = uCommand.Parameters.Add("iSPDSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SPDSLNO"

            'Add In Parameter as iADMSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add In Parameter as iBLOODGROUP
            oParameter = uCommand.Parameters.Add("iBLOODGROUP", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BLOODGROUP"

            'Add In Parameter as iIDMARKS
            oParameter = uCommand.Parameters.Add("iIDMARKS", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "IDMARKS"

            'Add In Parameter as iDESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.UpdateCommand = uCommand


            ''''''''''DELETE''''''''''''''''

            'Add In Parameter as iSPDSLNO
            oParameter = dCommand.Parameters.Add("iSPDSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SPDSLNO"

            'Add In Parameter as iADMSLNO
            oParameter = dCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            oAdapter.DeleteCommand = dCommand


            oAdapter.Update(SPDset, "SPDTable")


        Catch ex As Exception
            Throw ex
        End Try

    End Function


#End Region

#Region "Previous Course Details"


    Public Function Select_Data(ByVal PCMDDset As DataSet, ByVal SpName As String, ByVal DTable As String, ByVal Slno As Double) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ' ds = New Data.DataSet("SPDTable")

            oCommand.CommandText = SpName '"SPCMDETAILS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Slno

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(PCMDDset, DTable)

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return PCMDDset

    End Function


    Public Function PreviouscourseSelect(ByVal SpName As String, ByVal Slno As Double) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet("SPDTable")

            oCommand.CommandText = SpName '"SPCMDETAILS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Slno

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function


    Public Function PCM_Save(ByVal PCMDDset As DataSet, ByVal PCMHSLNO As Integer, ByVal Saveas As String) As String
        Dim rtnString As String
        Dim RtnVal As Integer
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(PCMDDset) AndAlso PCMDDset.Tables(0).Rows.Count > 0 Then

                If Saveas = "NEW" Then
                    RtnVal = PcmHeader_Insert(PCMDDset, oConn, oTrans)
                    PCMHSLNO = RtnVal
                Else
                    PcmHeader_Save(PCMDDset, oConn, oTrans)
                End If

                PcMDetails_Save(PCMDDset, PCMHSLNO, oConn, oTrans)

            End If


            oTrans.Commit()
            rtnString = "Record Saved"

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

    Private Function PcmHeader_Save(ByVal PCMDDset As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As Integer

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "EXAM_SPCMHEADER_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as iPCMHSLNO
            oParameter = uCommand.Parameters.Add("iPCMHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PCMHSLNO"


            'Add In Parameter as iPCSLNO
            oParameter = uCommand.Parameters.Add("iPCSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PCSLNO"

            'Add In Parameter as iADMSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add In Parameter as iMEDIUMSLNO
            oParameter = uCommand.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MEDIUMSLNO"

            'Add In Parameter as iHALLTICKETNO
            oParameter = uCommand.Parameters.Add("iHALLTICKETNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "HALLTICKETNO"

            'Add In Parameter as iTOTALMARKS
            oParameter = uCommand.Parameters.Add("iTOTALMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOTALMARKS"

            'Add In Parameter as iOBTAINMARKS
            oParameter = uCommand.Parameters.Add("iTOTALOBTAINMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOTALOBTAINMARKS"


            'Add In Parameter as iRANK
            oParameter = uCommand.Parameters.Add("iRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RANK"

            'Add In Parameter as iPERCENTAGE
            oParameter = uCommand.Parameters.Add("iPERCENTAGE", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PERCENTAGE"

            'Add In Parameter as iPERCENTAGE
            oParameter = uCommand.Parameters.Add("iPRVGRADESLNO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GRADESLNO"

            'Add In Parameter as iRaisedMarks
            oParameter = uCommand.Parameters.Add("iRAISEDMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("RAISEDMARKS"))

            'Add In Parameter as iResultStudentName
            oParameter = uCommand.Parameters.Add("iRESSTUDENT", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCMDDset.Tables("PCMDTable").Rows(0)("RESNAME")

            'Add In Parameter as iResultFatherName
            oParameter = uCommand.Parameters.Add("iRESFATHER", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCMDDset.Tables("PCMDTable").Rows(0)("RESFNAME")

            'Add In Parameter as iDESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(PCMDDset, "PCMDTable")

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function PcmHeader_Insert(ByVal PCMDDset As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As Long

        Try
            Dim iCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            iCommand.Transaction = pTrans
            iCommand.CommandText = "EXAM_SPCMHEADER_INSERT"
            iCommand.Connection = pConn
            iCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as iPCSLNO
            oParameter = iCommand.Parameters.Add("iPCSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            If IsDBNull(PCMDDset.Tables("PCMDTable").Rows(0)("PCSLNO")) Then
                oParameter.Value = PCMDDset.Tables("PCMDTable").Rows(0)("PCSLNO")
            Else
                oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("PCSLNO"))
            End If


            'Add In Parameter as iADMSLNO
            oParameter = iCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("ADMSLNO"))

            'Add In Parameter as MediumSlno
            oParameter = iCommand.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            If IsDBNull(PCMDDset.Tables("PCMDTable").Rows(0)("MEDIUMSLNO")) Then
                oParameter.Value = PCMDDset.Tables("PCMDTable").Rows(0)("MEDIUMSLNO")
            Else
                oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("MEDIUMSLNO"))
            End If


            'Add In Parameter as iHallTicketSlno
            oParameter = iCommand.Parameters.Add("iHALLTICKETNO", OracleType.VarChar, 15)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCMDDset.Tables("PCMDTable").Rows(0)("HALLTICKETNO")

            'Add In Parameter as iTOTALMARKS
            oParameter = iCommand.Parameters.Add("iTOTALMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("TOTALMARKS"))

            'Add In Parameter as iTOTALOBTAINMARKS
            oParameter = iCommand.Parameters.Add("iTOTALOBTAINMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("TOTALOBTAINMARKS"))

            'Add In Parameter as Rank
            oParameter = iCommand.Parameters.Add("iRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("RANK"))

            'Add In Parameter as iPERCENTAGE
            oParameter = iCommand.Parameters.Add("iPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("PERCENTAGE"))

            'Add In Parameter as iGradeslno
            oParameter = iCommand.Parameters.Add("iPRVGRADESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("GRADESLNO"))


            'Add In Parameter as iPERCENTAGE
            oParameter = iCommand.Parameters.Add("iRAISEDMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("RAISEDMARKS"))


            'Add In Parameter as iDESCRIPTION
            oParameter = iCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCMDDset.Tables("PCMDTable").Rows(0)("DESCRIPTION")

            'Add In Parameter as iDESCRIPTION
            oParameter = iCommand.Parameters.Add("iRESSTUDENT", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCMDDset.Tables("PCMDTable").Rows(0)("RESNAME")

            'Add In Parameter as iDESCRIPTION
            oParameter = iCommand.Parameters.Add("iRESFATHER", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCMDDset.Tables("PCMDTable").Rows(0)("RESFNAME")

            iCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            iCommand.ExecuteNonQuery()

            Result = iCommand.Parameters("oRtnValid").Value

            Return Result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function PcmHeader_Update(ByVal PCMDDset As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim uCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "EXAM_SPCMHEADER_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as iPCMHSLNO
            oParameter = uCommand.Parameters.Add("iPCMHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("PCMHSLNO"))


            'Add In Parameter as iPCSLNO
            oParameter = uCommand.Parameters.Add("iPCSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("PCSLNO"))

            'Add In Parameter as iADMSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("ADMSLNO"))


            'Add In Parameter as iTOTALMARKS
            oParameter = uCommand.Parameters.Add("iTOTALMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("TOTALMARKS"))

            'Add In Parameter as iOBTAINMARKS
            oParameter = uCommand.Parameters.Add("iTOTALOBTAINMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("TOTALOBTAINMARKS"))


            'Add In Parameter as iRANK
            oParameter = uCommand.Parameters.Add("iRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("RANK"))

            'Add In Parameter as iPERCENTAGE
            oParameter = uCommand.Parameters.Add("iPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("PERCENTAGE"))

            'Add In Parameter as iPERCENTAGE
            oParameter = uCommand.Parameters.Add("iRAISEDMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("RAISEDMARKS"))


            'Add In Parameter as iPERCENTAGE
            oParameter = uCommand.Parameters.Add("iPRVGRADESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("GRADESLNO"))


            'Add In Parameter as iDESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCMDDset.Tables("PCMDTable").Rows(0)("DESCRIPTION")

            'uCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            uCommand.ExecuteNonQuery()

            Result = uCommand.Parameters("oRtnValid").Value
            Return Result


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function PcMDetails_Save(ByVal PCMDDset As DataSet, ByVal PcmSlno As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            iCommand.Transaction = pTrans
            iCommand.CommandText = "SPCMDETAILS_INSERT"
            iCommand.Connection = pConn
            iCommand.CommandType = CommandType.StoredProcedure

            uCommand.Transaction = pTrans
            uCommand.CommandText = "SPCMDETAILS_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure



            'Add In Parameter as iPCMHSLNO
            oParameter = iCommand.Parameters.Add("iPCMHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PcmSlno

            'Add In Parameter as iSUBJECTSLNO
            oParameter = iCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'Add In Parameter as iMAXMARKS
            oParameter = iCommand.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MAXMARKS"

            'Add In Parameter as iOBTAINEDMARKS
            oParameter = iCommand.Parameters.Add("iOBTAINEDMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "OBTAINEDMARKS"

            'Add In Parameter as iRANK
            oParameter = iCommand.Parameters.Add("iRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RANK"

            'Add In Parameter as iPERCENTAGE
            oParameter = iCommand.Parameters.Add("iPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PERCENTAGE"

            'Add In Parameter as iPRVGRADESLNO
            oParameter = iCommand.Parameters.Add("iPRVGRADESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GRADESLNO"

            'Add In Parameter as iDESCRIPTION
            oParameter = iCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.InsertCommand = iCommand


            '''''''''''''''''''''''''''UPDATE''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Add In Parameter as iPCMDSLNO
            oParameter = uCommand.Parameters.Add("iPCMDSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PCMDSLNO"

            'Add In Parameter as iPCMHSLNO
            oParameter = uCommand.Parameters.Add("iPCMHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PCMHSLNO"

            'Add In Parameter as iSUBJECTSLNO
            oParameter = uCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'Add In Parameter as iMAXMARKS
            oParameter = uCommand.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MAXMARKS"

            'Add In Parameter as iOBTAINEDMARKS
            oParameter = uCommand.Parameters.Add("iOBTAINEDMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "OBTAINEDMARKS"

            'Add In Parameter as iRANK
            oParameter = uCommand.Parameters.Add("iRANK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "RANK"

            'Add In Parameter as iPERCENTAGE
            oParameter = uCommand.Parameters.Add("iPERCENTAGE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PERCENTAGE"

            'Add In Parameter as iPRVGRADESLNO
            oParameter = uCommand.Parameters.Add("iPRVGRADESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GRADESLNO"

            'Add In Parameter as iDESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(PCMDDset, "MarksTable")


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Pcmiew_delete(ByVal PCMHSLNO As Integer) As String
        Try
            Dim Dcommand As New OracleCommand
            ds = New DataSet

            Dim strReturn As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            Dcommand.CommandText = "EXAM_SPCMHEADER_DELETE"
            Dcommand.Connection = oConn
            Dcommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iPCMHSLNO
            oParameter = Dcommand.Parameters.Add("iPCMHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCMHSLNO

            Dcommand.ExecuteNonQuery()

            strReturn = "Delete"

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function EB_DESIG_delete(ByVal EMPMAPSLNO As Integer) As String
        Try
            Dim Dcommand As New OracleCommand
            ds = New DataSet

            Dim strReturn As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            Dcommand.CommandText = "EXAM_EB_DESIG_DELETE"
            Dcommand.Connection = oConn
            Dcommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iPCMHSLNO
            oParameter = Dcommand.Parameters.Add("iEMPMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EMPMAPSLNO

            Dcommand.ExecuteNonQuery()

            strReturn = "Delete"

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function EB_DESIG_Save(ByVal PCMDDset As DataSet, ByVal EMPSLNO As Integer, ByVal Saveas As String) As String
        Dim rtnString As String
        Dim RtnVal As Integer
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(PCMDDset) AndAlso PCMDDset.Tables(0).Rows.Count > 0 Then

                If Saveas = "NEW" Then
                    RtnVal = EB_DESIG_Insert(PCMDDset, oConn, oTrans)
                    EMPSLNO = RtnVal
                    'Else
                    '    PcmHeader_Save(PCMDDset, oConn, oTrans)
                End If

                'PcMDetails_Save(PCMDDset, EMPSLNO, oConn, oTrans)

            End If


            oTrans.Commit()
            rtnString = "Record Saved"

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

    Private Function EB_DESIG_Insert(ByVal PCMDDset As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As Long

        Try
            Dim iCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            iCommand.Transaction = pTrans
            iCommand.CommandText = "EXAM_EB_DESIG_INSERT"
            iCommand.Connection = pConn
            iCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = iCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("COMACADEMICSLNO"))

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = iCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            If IsDBNull(PCMDDset.Tables("PCMDTable").Rows(0)("EXAMBRANCHSLNO")) Then
                oParameter.Value = PCMDDset.Tables("PCMDTable").Rows(0)("PCSLNO")
            Else
                oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("EXAMBRANCHSLNO"))
            End If


            'Add In Parameter as iEXAMDESIGSLNO
            oParameter = iCommand.Parameters.Add("iEXAMDESIGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("DESIGNATIONSLNO"))


            'Add In Parameter as iEMPSLNO
            oParameter = iCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("EMPSLNO"))


            'Add In Parameter as iHallTicketSlno
            oParameter = iCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCMDDset.Tables("PCMDTable").Rows(0)("STATUS")


            'Add In Parameter as iUSERSLNO
            oParameter = iCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCMDDset.Tables("PCMDTable").Rows(0)("USERSLNO"))


            iCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            iCommand.ExecuteNonQuery()

            Result = iCommand.Parameters("oRtnValid").Value

            Return Result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function EB_DESIG_Insert1(ByVal Arr As ArrayList) As Integer
        Try

            Dim iCommand As New OracleClient.OracleCommand

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            iCommand.CommandText = "EXAM_EB_DESIG_INSERT"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = iCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = iCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)


            'Add In Parameter as iEXAMDESIGSLNO
            oParameter = iCommand.Parameters.Add("iEXAMDESIGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)


            'Add In Parameter as iEMPSLNO
            oParameter = iCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)


            'Add In Parameter as iHallTicketSlno
            oParameter = iCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)


            'Add In Parameter as iUSERSLNO
            oParameter = iCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)

            iCommand.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function

#End Region

#Region "StudentCasteAddressPCM"


    Public Function CasteAddressMarks_Insertions(ByVal ds As DataSet) As String
        Dim Trans As OracleTransaction
        Dim rtnString As String
        Try
            Dim AddressSlno As Integer

            Dim SaveAs As String
            Dim RtnVal As Long
            Dim PCMHSLNO As Integer = 0


            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.Connection = oConn
            oCommand.Transaction = Trans
            Trans = oConn.BeginTransaction()

            'Update Student Details
            UpdateSTUDETAILS(ds, oConn, Trans)

            If ds.Tables("StudentAddress").Rows.Count > 0 Then
                If ds.Tables("StudentAddress").Rows(0)("ADDRESSSLNO") = 0 Then
                    AddressSlno = Address_Insert(ds, oConn, Trans)
                Else
                    AddressSlno = ds.Tables("StudentAddress").Rows(0)("ADDRESSSLNO")
                    Address_UpDate(ds, oConn, Trans)
                End If
                UpdateStudent(ds, oConn, Trans, AddressSlno)   ''''Inserting AddressSlno Into Student Table
            End If


            If ds.Tables("PCMDTable").Rows.Count > 0 Then
                If ds.Tables("PCMDTable").Rows(0)("PCMHSLNO").ToString = "0" And (Not IsDBNull(ds.Tables("PCMDTable").Rows(0)("PCSLNO"))) Then
                    RtnVal = PcmHeader_Insert(ds, oConn, Trans)
                    PCMHSLNO = RtnVal
                Else
                    If (Not IsDBNull(ds.Tables("PCMDTable").Rows(0)("PCSLNO"))) Then PcmHeader_Save(ds, oConn, Trans)
                End If

                PcMDetails_Save(ds, PCMHSLNO, oConn, Trans)
            End If

            Trans.Commit()

            rtnString = "Record Saved"

        Catch SqlEx As OracleException
            Trans.Rollback()
            Throw SqlEx
        Catch ex As Exception
            Trans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString

    End Function

    Private Function Address_Insert(ByVal PDataSet As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As Integer
        Dim AddressSlno As Integer

        oCommand = New OracleCommand
        Dim uCommand As New OracleCommand

        oParameter = New OracleParameter
        Try
            oCommand.CommandText = "M_INSERT_ADDRESS_NEW"
            oCommand.Connection = pConn
            oCommand.Transaction = pTrans
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME Country SLNo
            oParameter = oCommand.Parameters.Add("iCountrySLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDataSet.Tables("StudentAddress").Rows(0)("CountrySLNo")

            'ADD IN PARAMETER NAME State SLNo
            oParameter = oCommand.Parameters.Add("iStateSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDataSet.Tables("StudentAddress").Rows(0)("StateSLNo")

            'ADD IN PARAMETER NAME District SLNo
            oParameter = oCommand.Parameters.Add("iDistrictSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDataSet.Tables("StudentAddress").Rows(0)("DistrictSLNo")

            'ADD IN PARAMETER NAME Place SLNo
            oParameter = oCommand.Parameters.Add("iPlaceSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDataSet.Tables("StudentAddress").Rows(0)("PlaceSLNo")

            'ADD IN PARAMETER NAME Address Line1
            oParameter = oCommand.Parameters.Add("iAddLine1", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDataSet.Tables("StudentAddress").Rows(0)("AddLine1")

            'ADD IN PARAMETER NAME Phone 1
            oParameter = oCommand.Parameters.Add("iPhone1", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDataSet.Tables("StudentAddress").Rows(0)("Phone1")

            'ADD IN PARAMETER NAME Fax 1
            oParameter = oCommand.Parameters.Add("iFax1", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDataSet.Tables("StudentAddress").Rows(0)("FAX1")

            'ADD IN PARAMETER NAME Email 1
            oParameter = oCommand.Parameters.Add("iEmail1", OracleType.VarChar, 30)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDataSet.Tables("StudentAddress").Rows(0)("Email1")

            'ADD IN PARAMETER NAME Mobile 1
            oParameter = oCommand.Parameters.Add("iMobile1", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDataSet.Tables("StudentAddress").Rows(0)("Mobile1")

            'ADD IN PARAMETER NAME AddressSLNo
            oParameter = oCommand.Parameters.Add("oAddressSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Output

            oCommand.ExecuteNonQuery()

            AddressSlno = oCommand.Parameters("oAddressSLNo").Value.ToString()


            Return AddressSlno


        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Function

    Private Sub Address_UpDate(ByVal PDataSet As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)

        Try

            oCommand = New OracleCommand
            Dim uCommand As New OracleCommand

            oParameter = New OracleParameter

            uCommand.CommandText = "M_UPDATE_ADDRESS_NEW"
            uCommand.Connection = pConn
            uCommand.Transaction = pTrans
            uCommand.CommandType = CommandType.StoredProcedure


            ''''''''Address UpDate''''

            'ADD IN PARAMETER NAME Address SLNo
            oParameter = uCommand.Parameters.Add("iAddressSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADDRESSSLNO"

            'ADD IN PARAMETER NAME Country SLNo
            oParameter = uCommand.Parameters.Add("iCountrySLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CountrySLNo"

            'ADD IN PARAMETER NAME State SLNo
            oParameter = uCommand.Parameters.Add("iStateSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StateSLNo"

            'ADD IN PARAMETER NAME District SLNo
            oParameter = uCommand.Parameters.Add("iDistrictSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DistrictSLNo"

            'ADD IN PARAMETER NAME Place SLNo
            oParameter = uCommand.Parameters.Add("iPlaceSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PlaceSLNo"

            'ADD IN PARAMETER NAME Address Line1
            oParameter = uCommand.Parameters.Add("iAddLine1", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "AddLine1"


            'ADD IN PARAMETER NAME Phone 1
            oParameter = uCommand.Parameters.Add("iPhone1", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "Phone1"

            'ADD IN PARAMETER NAME Fax 1
            oParameter = uCommand.Parameters.Add("iFax1", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "Fax1"


            'ADD IN PARAMETER NAME Email 1
            oParameter = uCommand.Parameters.Add("iEmail1", OracleType.VarChar, 30)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "Email1"


            'ADD IN PARAMETER NAME Mobile 1
            oParameter = uCommand.Parameters.Add("iMobile1", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "Mobile1"

            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(PDataSet, "StudentAddress")


        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Private Sub UpdateStudent(ByVal ds As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction, ByVal iAddressSlno As Integer)
        Try
            oCommand = New OracleCommand
            oParameter = New OracleParameter

            oCommand.CommandText = "SP_STUUPDATE"
            oCommand.Connection = pConn
            oCommand.Transaction = pTrans
            oCommand.CommandType = CommandType.StoredProcedure

            '''''STUDENT SLNO
            oParameter = oCommand.Parameters.Add("iSTUDENTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(ds.Tables("StudentAddress").Rows(0)("StudentSLNo"))

            '''''ADDRESSSLNO
            oParameter = oCommand.Parameters.Add("iADDRESSSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAddressSlno

            '''''ADDRESSSLNO
            oParameter = oCommand.Parameters.Add("iCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(ds.Tables("StudentAddress").Rows(0)("CASTESLNO"))


            oCommand.ExecuteNonQuery()

        Catch ex As Exception

        End Try
    End Sub

    'Updating Student surname,Name,Gender
    Private Sub UpdateSTUDETAILS(ByVal PCMDDset As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try

            oCommand = New OracleCommand
            Dim uCommand As New OracleCommand

            oParameter = New OracleParameter

            uCommand.CommandText = "P_STUDENT_UPDATE"
            uCommand.Connection = pConn
            uCommand.Transaction = pTrans
            uCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME Address iSTUDENTSLNO
            oParameter = uCommand.Parameters.Add("iSTUDENTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUDENTSLNO"

            'ADD IN PARAMETER NAME Country iINITIALNAME
            oParameter = uCommand.Parameters.Add("iINITIALNAME", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "INITIALNAME"

            'ADD IN PARAMETER NAME State iSURNAME
            oParameter = uCommand.Parameters.Add("iSURNAME", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SURNAME"

            'ADD IN PARAMETER NAME District iFIRSTNAME
            oParameter = uCommand.Parameters.Add("iFIRSTNAME", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "FIRSTNAME"

            'ADD IN PARAMETER NAME Place iGENDER
            oParameter = uCommand.Parameters.Add("iGENDER", OracleType.Char)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GENDER"

            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(PCMDDset, "STUDETAILS")

        Catch SqlEx As Exception
            Throw SqlEx
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub



    Public Function getStudata(ByVal PCMDDset As DataSet, ByVal PCSLNO As Integer, ByVal AdmSlno As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "ASR_EXAM_SPCMHEADER_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iPCSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCSLNO


            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = AdmSlno

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(PCMDDset, "PCMDTable")

        Catch ex As Exception

        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return PCMDDset

    End Function

#End Region

#Region "Subject"

    Public Function StudentForSubject(ByVal SpName As String, ByVal Dset As DataSet, ByVal DTable As String, ByVal iEXAMBRANCHSLNO As Integer, ByVal iCOURSESLNO As Integer, ByVal iGROUPSLNO As Integer, ByVal iBATCHSLNO As Integer, ByVal iSECTIONSLNO As Integer, ByVal iSUBJECTSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
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

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSUBJECTSLNO


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

    Public Function Subject_Save(ByVal DsSET As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsSET) AndAlso DsSET.Tables("STUSUBMAP").Rows.Count > 0 Then
                SubjectSave(DsSET, oConn, oTrans)
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

    Private Function SubjectSave(ByVal DsSET As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            iCommand.Transaction = pTrans
            '  uCommand.CommandText = "EXAM_SUBJECTSAVE"
            iCommand.CommandText = "EXAM_MAPSUBJECTSAVE"
            iCommand.Connection = pConn
            iCommand.CommandType = CommandType.StoredProcedure


            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iADMSLNO
            oParameter = iCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add In Parameter as iSUBJECTSLNO

            oParameter = iCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'Add In Parameter as iSUBJECTMAPSLNO
            oParameter = iCommand.Parameters.Add("iSUBJECTMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTMAPSLNO"

            oAdapter.InsertCommand = iCommand

            oAdapter.Update(DsSET, "STUSUBMAP")

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function StudentForSubjectUpdate(ByVal SpName As String, ByVal Dset As DataSet, ByVal iADMSLNO As Long) As DataSet
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

            'ADD IN PARAMETER NAME iSTUDENTSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iADMSLNO


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Dset, "Subject") '"Students")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Dset

    End Function

    Public Function Subject_Update(ByVal iADMSLNO As Long, ByVal iSUBJECTSLNO As Integer, ByVal iSUBJECTMAPSLNO As Long) As String
        Dim rtnString As String
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            Dim uCommand As New OracleClient.OracleCommand

            uCommand.Transaction = oTrans
            uCommand.CommandText = "EXAM_SUBJECTSAVE"
            uCommand.Connection = oConn
            uCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as iADMSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iADMSLNO

            'Add In Parameter as iSUBJECTSLNO
            oParameter = uCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSUBJECTSLNO

            'Add In Parameter as iSUBJECTMAPSLNO
            oParameter = uCommand.Parameters.Add("iSUBJECTMAPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSUBJECTMAPSLNO

            uCommand.ExecuteNonQuery()

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

    Public Function STUDENTSUBJECTMAP_Delete(ByVal pSLNo As Integer) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "STUDENTSUBJECTMAPPING_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBASLNo
            oParameter = oCommand.Parameters.Add("iKEYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSLNo

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function

#End Region

#Region "Caste"

    Public Function StudentForCaste(ByVal SpName As String, ByVal Dset As DataSet, ByVal DTable As String, ByVal iEXAMBRANCHSLNO As Integer, ByVal iCOURSESLNO As Integer, ByVal iGROUPSLNO As Integer, ByVal iBATCHSLNO As Integer, ByVal iSECTIONSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
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

    Public Function Caste_Save(ByVal DsStudents As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String


            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudents) AndAlso DsStudents.Tables("Students").Rows.Count > 0 Then
                CasteSave(DsStudents, oConn, oTrans)
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

    Private Function CasteSave(ByVal DsStudents As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "EXAM_CASTESAVE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iSTUDENTSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add In Parameter as iCASTESLNO
            oParameter = uCommand.Parameters.Add("iCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CASTESLNO"

            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudents, "Students")

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function SubSectionInchargeMap(ByVal Arr As ArrayList)

        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAM_SUBSEC_INCH_MAP"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iSTUDENTSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            'Add In Parameter as iCASTESLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)



            'Add In Parameter as iSTUDENTSLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)


            'Add In Parameter as iCASTESLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)



            'Add In Parameter as iSTUDENTSLNO
            oParameter = oCommand.Parameters.Add("iSUBSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)


            'Add In Parameter as iCASTESLNO
            oParameter = oCommand.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(5)



            'Add In Parameter as iSTUDENTSLNO
            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(6)


            'Add In Parameter as iCASTESLNO
            oParameter = oCommand.Parameters.Add("iDISPLAYNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(7)


            'Add In Parameter as iCASTESLNO
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(8)

            oCommand.ExecuteNonQuery()
            Return 1

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function StudentForCasteUpdate(ByVal SpName As String, ByVal Dset As DataSet, ByVal iADMSLNO As Long, ByVal iCOMACADEMICSLNO As Integer) As DataSet
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

            'ADD IN PARAMETER NAME iSTUDENTSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iADMSLNO


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Dset, "Caste") '"Students")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Dset

    End Function


    Public Function Caste_Update(ByVal iADMSLNO As Long, ByVal iCASTESLNO As Long) As String
        Dim rtnString As String
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            Dim uCommand As New OracleClient.OracleCommand

            uCommand.Transaction = oTrans
            uCommand.CommandText = "EXAM_CASTESAVE"
            uCommand.Connection = oConn
            uCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as iSTUDENTSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iADMSLNO

            'Add In Parameter as iCASTESLNO
            oParameter = uCommand.Parameters.Add("iCASTESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCASTESLNO

            uCommand.ExecuteNonQuery()

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

#End Region

#Region "Father Occupation"

    Public Function Occup_Save(ByVal DsStudents As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String


            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudents) AndAlso DsStudents.Tables("Students").Rows.Count > 0 Then
                OccupSave(DsStudents, oConn, oTrans)
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

    Private Function OccupSave(ByVal DsStudents As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "EXAM_OCCUPSAVE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iSTUDENTSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add In Parameter as iCASTESLNO
            oParameter = uCommand.Parameters.Add("iOCCUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "OCCUPATIONSLNO"

            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudents, "Students")

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

#Region "Blood Group"

    Public Function bloodgroup_Save(ByVal DsStudents As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String


            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudents) AndAlso DsStudents.Tables("Students").Rows.Count > 0 Then
                BLOODGROUPSave(DsStudents, oConn, oTrans)
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

    Private Function BLOODGROUPSave(ByVal DsStudents As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "EXAM_BLOODGROUPSAVE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iSTUDENTSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add In Parameter as iCASTESLNO
            oParameter = uCommand.Parameters.Add("iBLOODGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BLOODGROUPSLNO"

            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudents, "Students")

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "SubBatch"
    Public Function SUBBATCH_SECTION_Save(ByVal DsStudents As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String


            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudents) AndAlso DsStudents.Tables("Students").Rows.Count > 0 Then
                SUBBATCH_SECTIONSAVE(DsStudents, oConn, oTrans)
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

    Private Function SUBBATCH_SECTIONSAVE(ByVal DsStudents As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "SUBBATCH_SECTIONSAVE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iSUBBATCHSLNO
            oParameter = uCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBBATCHSLNO"

            'Add In Parameter as iCOURSESLNO
            oParameter = uCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'Add In Parameter as iGROUPSLNO
            oParameter = uCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'Add In Parameter as iBATCHSLNO
            oParameter = uCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BATCHSLNO"

            'Add In Parameter as iSECTIONSLNO
            oParameter = uCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"

            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudents, "Students")

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

#Region "AHBRS"

    Public Function FillHBR(ByVal SPName As String, ByVal Slno As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = SPName '"SPDETAILS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Slno

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function FillSection(ByVal BranchSlno As Integer, ByVal CourseSlno As Integer, ByVal ExamBranchslno As Integer, ByVal GroupSlno As Integer, ByVal BatchSlno As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "SECTIONS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BranchSlno

            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchslno


            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function FindStudentSection(ByVal AdmSlno As Integer, ByVal BranchSlno As Integer, ByVal CourseSlno As Integer, ByVal GroupSlno As Integer, ByVal BatchSlno As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet("SHBRSDTable")

            oCommand.CommandText = "STUDENTSECTION_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BranchSlno

            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno

            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = AdmSlno

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "SHBRSDTable")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function FillStudent_Batch(ByVal BranchSlno As Integer, ByVal CourseSlno As Integer, ByVal ExamBranchSlno As Integer, ByVal GroupSlno As Integer, ByVal BatchSlno As Integer, ByVal SectionSlno As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "M_BRACOUGRPBAT_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BranchSlno

            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno


            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SectionSlno

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


#End Region

#Region "AHBRS Done By Naidu.G"

    Public Function StudentHBRS_Save(ByVal Dset As DataSet, ByVal HostelSlno As Integer, ByVal BlockSlno As Integer, ByVal RoomSlno As Integer) As String
        Dim rtnString As String
        Try
            oCommand = New OracleCommand
            Dim uCommand As New OracleCommand

            oAdapter = New OracleDataAdapter
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            ''''For Insertion
            oCommand.Transaction = oTrans
            oCommand.CommandText = "SHBRSHEADER_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            ''''For Updating
            uCommand.Transaction = oTrans
            uCommand.CommandText = "MHBRSHEADER_UPDATE"
            uCommand.Connection = oConn
            uCommand.CommandType = CommandType.StoredProcedure

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''INSERTION PARAMETERS'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Add In Parameter as iBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANCHSLNO"

            'Add In Parameter as iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"


            'Add In Parameter as iexambranchslno
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"


            'Add In Parameter as iGROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'Add In Parameter as iBATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BATCHSLNO"


            'Add In Parameter as iSECTIONSLNO
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"

            'Add In Parameter as iBRANHOSTELSLNO
            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANHOSTELSLNO"

            'Add In Parameter as iHOSBLOCKSLNO
            oParameter = oCommand.Parameters.Add("iHOSBLOCKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "HOSBLOCKSLNO"

            'Add In Parameter as iBLKROOMSLNO
            oParameter = oCommand.Parameters.Add("iBLKROOMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BLKROOMSLNO"

            'Add In Parameter as iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"


            'Add In Parameter as iDESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.InsertCommand = oCommand

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''UPDATION PARAMETERS''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Add In Parameter as iBRANCHSLNO
            oParameter = uCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANCHSLNO"

            'Add In Parameter as iCOURSESLNO
            oParameter = uCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"


            'Add In Parameter as iexambranchslno
            oParameter = uCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"


            'Add In Parameter as iGROUPSLNO
            oParameter = uCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'Add In Parameter as iBATCHSLNO
            oParameter = uCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BATCHSLNO"


            'Add In Parameter as iSECTIONSLNO
            oParameter = uCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"

            'Add In Parameter as iBRANHOSTELSLNO
            oParameter = uCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANHOSTELSLNO"

            'Add In Parameter as iHOSBLOCKSLNO
            oParameter = uCommand.Parameters.Add("iHOSBLOCKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "HOSBLOCKSLNO"

            'Add In Parameter as iBLKROOMSLNO
            oParameter = uCommand.Parameters.Add("iBLKROOMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BLKROOMSLNO"

            'Add In Parameter as iADMSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add In Parameter as iDESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"


            ''''''These three Are To Store Previous Values Into Dummy Table 
            'Add In Parameter as HostelSlno
            oParameter = uCommand.Parameters.Add("iHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = HostelSlno

            'Add In Parameter as BlockSlno
            oParameter = uCommand.Parameters.Add("iBLOCKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BlockSlno

            'Add In Parameter as RoomSlno
            oParameter = uCommand.Parameters.Add("iROOMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = RoomSlno


            oAdapter.UpdateCommand = uCommand


            oAdapter.Update(Dset, "SHBRSDTable")
            oTrans.Commit()

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return 1
    End Function

    Public Function ExamBranchSection_Fetch(ByVal iADMSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "SECTION_EB_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iADMSLNO

            'ADD IN PARAMETER NAME DataCur
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

    Public Function StudentHBRS_Delete(ByVal iADMSLNO As String) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "FHBRSHEADER_DELETE"

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS PRIMARY KEYSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iADMSLNO

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function


#End Region

#Region "Student Phone No BY SURENDAR REDDY"

    Public Function StuPhone_Save(ByVal DsStudents As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudents) AndAlso DsStudents.Tables("Students").Rows.Count > 0 Then
                StuPhoneSave(DsStudents, oConn, oTrans)
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

    Private Function StuPhoneSave(ByVal DsStudents As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "EXAM_STUPHONE_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iADDRESSSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"


            'Add In Parameter as iPHONE1
            oParameter = uCommand.Parameters.Add("iPHONE1", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PHONE1"


            'Add In Parameter as iPHONE2
            oParameter = uCommand.Parameters.Add("iPHONE2", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PHONE2"

            'Add In Parameter as iMOBILE1
            oParameter = uCommand.Parameters.Add("iMOBILE1", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MOBILE1"

            'Add In Parameter as iMOBILE2
            oParameter = uCommand.Parameters.Add("iMOBILE2", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MOBILE2"


            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudents, "Students")

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "Student Pincode&ScholarshipAppno BY HEMANTH"

    Public Function StuPincode_Save(ByVal DsStudents As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudents) AndAlso DsStudents.Tables("Students").Rows.Count > 0 Then
                StuPincodeSave(DsStudents, oConn, oTrans)
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

    Private Function StuPincodeSave(ByVal DsStudents As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "EXAM_STUPIN_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iADDRESSSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"


            'Add In Parameter as iPHONE1
            oParameter = uCommand.Parameters.Add("iPINCODE", OracleType.Number, 6)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PINCODE"


            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudents, "Students")

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function StuTaget_Save(ByVal DsStudents As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudents) AndAlso DsStudents.Tables("Students").Rows.Count > 0 Then
                StuTargetSave(DsStudents, oConn, oTrans)
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
    Private Function StuTargetSave(ByVal DsStudents As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "EXAM_TARGET_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iADDRESSSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"


            'Add In Parameter as iPHONE1
            oParameter = uCommand.Parameters.Add("iTARGET", OracleType.Number, 6)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TARGET"


            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudents, "Students")

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function StuSchlrp_appno_Save(ByVal DsStudents As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudents) AndAlso DsStudents.Tables("Students").Rows.Count > 0 Then
                StuSchlrpappnoSave(DsStudents, oConn, oTrans)
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


    Private Function StuSchlrpappnoSave(ByVal DsStudents As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "EXAM_STUSCHAPPNO_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iADDRESSSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"


            'Add In Parameter as iPHONE1
            oParameter = uCommand.Parameters.Add("iSCHAPPNO", OracleType.Number, 6)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SCHLRP_APPNO"


            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudents, "Students")

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function RegionStrn_Save(ByVal dsDes As DataSet, ByVal ComAcaslno As Integer) As String
        Dim rtnString As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            If Not dsDes Is Nothing Then
                For I = 0 To dsDes.Tables(0).Rows.Count - 1
                    RegionStrnSave(Val(dsDes.Tables(0).Rows(I)("REGIONSLNO").ToString), Val(dsDes.Tables(0).Rows(I)("DISTRICTSLNO").ToString), Val(dsDes.Tables(0).Rows(I)("COURSESLNO").ToString), Val(dsDes.Tables(0).Rows(I)("GROUPSLNO").ToString), Val(dsDes.Tables(0).Rows(I)("MANDALSLNO").ToString), Val(dsDes.Tables(0).Rows(I)("TARGET_STRN").ToString), ComAcaslno, oConn, oTrans)
                Next
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
    Private Function RegionStrnSave(ByVal pREGIONSLNO As Integer, ByVal pDISTRICTSLNO As Integer, ByVal pCOURSESLNO As Integer, ByVal pGROUPSLNO As Integer, ByVal pMANDALSLNO As Integer, ByVal pTARGET_STRN As Integer, ByVal pCOMACADEMICSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand

            oCommand.CommandText = "EXAM_REGDISTMANDALSTRN_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            oParameter = oCommand.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDISTRICTSLNO


            oParameter = oCommand.Parameters.Add("iREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pREGIONSLNO


            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOURSESLNO


            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pGROUPSLNO

            oParameter = oCommand.Parameters.Add("iMANDALSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pMANDALSLNO


            oParameter = oCommand.Parameters.Add("iTARGET_STRN", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pTARGET_STRN

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Catch oex As OracleException
            Throw oex
        End Try

    End Function


#End Region

#Region "Students DOB By SURENDAR REDDY ON 25-JAN-2006"

    Public Function StuDOB_Save(ByVal DsStudents As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String


            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudents) AndAlso DsStudents.Tables("Students").Rows.Count > 0 Then
                StuDOBSave(DsStudents, oConn, oTrans)
            End If

            oTrans.Commit()
            rtnString = "Saved"

        Catch SqlEx As OracleException
            oTrans.Rollback()
            Throw SqlEx
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString

    End Function

    Private Function StuDOBSave(ByVal DsStudents As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "EXAM_STUDOB_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iADDRESSSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add In Parameter as iDOB
            oParameter = uCommand.Parameters.Add("iDOB", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DOB"

            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudents, "Students")
        Catch SqlEx As OracleException
            Throw SqlEx
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "StudentPhoto Update"

    Public Function StuPhoto_Update(ByVal UNIQUENO As Integer, ByVal YN As Integer)
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            ds = New DataSet

            oConn = ObjConn.GetConnection()
            oCommand.CommandText = "UPDATE T_ADM_DT SET ISPHOTOUPLOADED=" & YN & " WHERE UNIQUENO=" & UNIQUENO
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.Text

            oCommand.ExecuteNonQuery()

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function
#End Region

#Region "Student EMail BY CHANDRA"

    Public Function StuMail_Save(ByVal DsStudents As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudents) AndAlso DsStudents.Tables("Students").Rows.Count > 0 Then
                StuMailSave(DsStudents, oConn, oTrans)
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

    Private Function StuMailSave(ByVal DsStudents As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "EXAM_EMAIL_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iADDRESSSLNO
            oParameter = uCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"


            'Add In Parameter as iPHONE1
            oParameter = uCommand.Parameters.Add("iEMAIL", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MAIL"


            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudents, "Students")

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "Region District Mandal Wise Target Strength Entry"

    Public Function MandalsForRegionDistrict(ByVal Dset As DataSet, ByVal DTable As String, ByVal iREGIONSLNO As Integer, ByVal iDISTRICTSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer, ByVal iCOURSESLNO As Integer, ByVal iGROUPSLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "EXAM_MANDALSFORREGIONDISTRICT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO 
            oParameter = oCommand.Parameters.Add("iREGIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iREGIONSLNO

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDISTRICTSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO 
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'ADD IN PARAMETER NAME iCOURSESLNO 
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOURSESLNO

            'ADD IN PARAMETER NAME iGROUPSLNO 
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iGROUPSLNO

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


    Public Function StudentForSubBatch(ByVal SpName As String, ByVal Dset As DataSet, ByVal DTable As String, ByVal iEXAMBRANCHSLNO As Integer, ByVal iCOURSESLNO As Integer, ByVal iGROUPSLNO As Integer, ByVal iSUBBATCHSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
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
            oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSUBBATCHSLNO

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


#Region "Sub Batch Mapping"

    Public Function SUBBATCH_MAPP_SAVE(ByVal DsStudents As DataSet) As String
        Dim rtnString As String
        Try
            Dim setResult As String


            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            If Not IsNothing(DsStudents) AndAlso DsStudents.Tables("Students").Rows.Count > 0 Then
                SUBBATCH_MAPP(DsStudents, oConn, oTrans)
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

    Private Function SUBBATCH_MAPP(ByVal DsStudents As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            uCommand.Transaction = pTrans
            uCommand.CommandText = "SUBBATCH_MAPP_SAVE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as iCOURSESLNO
            oParameter = uCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'Add In Parameter as iGROUPSLNO
            oParameter = uCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'Add In Parameter as iBATCHSLNO
            oParameter = uCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BATCHSLNO"

            'Add In Parameter as iSECTIONSLNO
            oParameter = uCommand.Parameters.Add("iPACKAGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PACKAGESLNO"

            'Add In Parameter as iSUBBATCHSLNO
            oParameter = uCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBBATCHSLNO"

            oAdapter.UpdateCommand = uCommand

            oAdapter.Update(DsStudents, "Students")

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region
End Class
