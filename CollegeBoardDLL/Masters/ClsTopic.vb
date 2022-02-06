'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating TOPICS
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 11-OCT-2006
'   FINAL BASELINE DATE               : 11-OCT-2006
'   MODIFICATIONS LOG                 : SUBTOPICS [Venu on 09.Oct.2012]
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsTopic

#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As New OracleClient.OracleCommand
    Private oParameter As New OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ds As Data.DataSet
    Private oTrans As OracleTransaction
    Private Result As String
    Private ObjConn As Connection

#End Region

#Region "Method"

    Public Function TopicsSave(ByVal PDset As DataSet) As String
        Dim rtnString As String

        Try
            Dim setResult As String
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            If Not IsNothing(PDset) AndAlso PDset.Tables(0).Rows.Count > 0 Then
                TopicsSave(PDset, oConn, oTrans)
            End If


            oTrans.Commit()
            rtnString = "Topics Saved"

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString

    End Function

    Public Function SubTopicsSave(ByVal PDset As DataSet) As String
        Dim rtnString As String

        Try
            Dim setResult As String
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            If Not IsNothing(PDset) AndAlso PDset.Tables(0).Rows.Count > 0 Then
                SubTopicsSave(PDset, oConn, oTrans)
            End If

            oTrans.Commit()
            rtnString = "SubTopics Saved"

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString

    End Function

    Private Function TopicsSave(ByVal SPDset As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            iCommand.Transaction = pTrans
            iCommand.CommandText = "T_TOPICS_MT_INSERT"
            iCommand.Connection = pConn
            iCommand.CommandType = CommandType.StoredProcedure

            uCommand.Transaction = pTrans
            uCommand.CommandText = "T_TOPICS_MT_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure

            dCommand.Transaction = pTrans
            dCommand.CommandText = "T_TOPICS_MT_DELETE"
            dCommand.Connection = pConn
            dCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as iCourseSLNo
            oParameter = iCommand.Parameters.Add("iCourseSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CourseSlNo"

            'Add In Parameter as iSubjectSLNo
            oParameter = iCommand.Parameters.Add("iSubjectSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SubjectSLNo"

            'Add In Parameter as iName
            oParameter = iCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "Name"

            'Add In Parameter as iDescription
            oParameter = iCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"


            oAdapter.InsertCommand = iCommand

            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iTopicSLNo
            oParameter = uCommand.Parameters.Add("iTopicSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TopicSLNo"

            'Add In Parameter as iCourseSLNo
            oParameter = uCommand.Parameters.Add("iCourseSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CourseSlNo"

            'Add In Parameter as iSubjectSLNo
            oParameter = uCommand.Parameters.Add("iSubjectSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SubjectSLNo"

            'Add In Parameter as iName
            oParameter = uCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "Name"

            'Add In Parameter as iDescription
            oParameter = uCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"



            oAdapter.UpdateCommand = uCommand


            ''''''''''DELETE''''''''''''''''

            'Add In Parameter as TopicSLNo
            oParameter = dCommand.Parameters.Add("iTopicSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TopicSLNo"


            oAdapter.DeleteCommand = dCommand


            oAdapter.Update(SPDset, "Topics")


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function SubTopicsSave(ByVal SPDset As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String

        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            iCommand.Transaction = pTrans
            iCommand.CommandText = "T_SUBTOPICS_MT_INSERT"
            iCommand.Connection = pConn
            iCommand.CommandType = CommandType.StoredProcedure

            uCommand.Transaction = pTrans
            uCommand.CommandText = "T_SUBTOPICS_MT_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure

            dCommand.Transaction = pTrans
            dCommand.CommandText = "T_SUBTOPICS_MT_DELETE"
            dCommand.Connection = pConn
            dCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iCourseSLNo
            oParameter = iCommand.Parameters.Add("iTopicSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TopicSlNo"

            'Add In Parameter as iName
            oParameter = iCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "Name"

            'Add In Parameter as iDescription
            oParameter = iCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"


            oAdapter.InsertCommand = iCommand

            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iTopicSLNo
            oParameter = uCommand.Parameters.Add("iSUBTopicSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SubTopicSLNo"

            'Add In Parameter as iName
            oParameter = uCommand.Parameters.Add("iName", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "Name"

            'Add In Parameter as iDescription
            oParameter = uCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"



            oAdapter.UpdateCommand = uCommand


            ''''''''''DELETE''''''''''''''''

            'Add In Parameter as TopicSLNo
            oParameter = dCommand.Parameters.Add("iSUBTopicSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SubTopicSLNo"


            oAdapter.DeleteCommand = dCommand


            oAdapter.Update(SPDset, "SubTopics")


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function SelectTopicc(ByVal TopicSLNo As Integer) As DataSet
        Try
            'ByVal PCSlno As Integer,
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "T_TOPICS_EDIT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            'ADD IN PARAMETER NAME iSTR
            oParameter = oCommand.Parameters.Add("iTopicSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TopicSLNo


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "Topics")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function SelectSubTopic(ByVal SUBTopicSLNo As Integer) As DataSet
        Try
            'ByVal PCSlno As Integer,
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "T_SUBTOPICS_EDIT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            'ADD IN PARAMETER NAME iSTR
            oParameter = oCommand.Parameters.Add("iSubTopicSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SUBTopicSLNo


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "SubTopics")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function SelectTopicsNew(ByVal COURSESLNO As Integer, ByVal SUBJECTSLNO As Integer) As DataSet
        Try
            'ByVal PCSlno As Integer,
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "T_TOPICS_SELECT_CS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME icourseslno
            oParameter = oCommand.Parameters.Add("ICOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COURSESLNO

            'ADD IN PARAMETER NAME isubjectslno
            oParameter = oCommand.Parameters.Add("ISUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SUBJECTSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "Topics")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function Course_Fetch() As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAMCOURSE_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
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

    Public Function Subject_Fetch(ByVal PCSlno As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAMCOURSEsUBJECT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iCourseSLNo
            oParameter = oCommand.Parameters.Add("iCGSSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCSlno


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function Fetch_Topics(ByVal iSTR As String) As DataSet
        Try
            'ByVal PCSlno As Integer,
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "T_TOPICS_MT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            ''ADD IN PARAMETER NAME iCourseSLNo
            'oParameter = oCommand.Parameters.Add("iCourseSLNo", OracleType.Number, 4)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = PCSlno

            'ADD IN PARAMETER NAME iSTR
            oParameter = oCommand.Parameters.Add("iSTR", OracleType.VarChar, 500)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSTR


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "Topics")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function Fetch_SubTopics(ByVal iSTR As String) As DataSet
        Try
            'ByVal PCSlno As Integer,
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "T_SUBTOPICS_MT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            ''ADD IN PARAMETER NAME iCourseSLNo
            'oParameter = oCommand.Parameters.Add("iCourseSLNo", OracleType.Number, 4)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = PCSlno

            'ADD IN PARAMETER NAME iSTR
            oParameter = oCommand.Parameters.Add("iSTR", OracleType.VarChar, 500)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSTR


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "Topics")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function Fetch_SubTopics_Against_Topic(ByVal iTopicslno As String) As DataSet
        Try
            'ByVal PCSlno As Integer,
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAM_SUBTOPICS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            ''ADD IN PARAMETER NAME iCourseSLNo
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number, 6)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iTopicslno

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "Topics")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function TopicsDelete(ByVal PTSLNo As Integer) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "T_TOPICS_MT_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iTopicSLNo
            oParameter = oCommand.Parameters.Add("iTopicSLNo", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PTSLNo


            ' oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            'strReturn = oCommand.Parameters("oRtnValid").Value.ToString
            strReturn = "Record Deleted"
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return strReturn

    End Function

    Public Function SubTopicsDelete(ByVal PTSLNo As Integer) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "T_SUBTOPICS_MT_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iTopicSLNo
            oParameter = oCommand.Parameters.Add("iSubTopicSLNo", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PTSLNo


            ' oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            'strReturn = oCommand.Parameters("oRtnValid").Value.ToString
            strReturn = "Record Deleted"
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return strReturn

    End Function

    Public Function TopicSubTopicMaterialMap_Insert(ByVal MapDs As DataSet) As Integer
        Dim adap As New OracleDataAdapter
        Try
            oCommand = New OracleClient.OracleCommand
            
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            oCommand.Transaction = oTrans
            oCommand.CommandText = "EXAM_TPCSTPCMATERAILMAP_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMSLNO"

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"

            'ADD IN PARAMETER NAME iQUESTIONNO
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'ADD IN PARAMETER NAME iTOPICSLNO
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'ADD IN PARAMETER NAME iSUBTOPICSLNO
            oParameter = oCommand.Parameters.Add("iSUBTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBTOPICSLNO"

            'ADD IN PARAMETER NAME iMATERIALSLNO
            oParameter = oCommand.Parameters.Add("iMATERIALSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MATERIALSLNO"

            'ADD IN PARAMETER NAME iUSERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "USERSLNO"

            'ADD IN PARAMETER NAME iMAPDATETIME
            oParameter = oCommand.Parameters.Add("iMAPDATETIME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MAPDATETIME"

            'ADD IN PARAMETER NAME iUSERSLNO
            oParameter = oCommand.Parameters.Add("iCHWSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CHWSLNO"

            adap.InsertCommand = oCommand

            adap.Update(MapDs, "TSTMT")

            oTrans.Commit()

            Return 1

        Catch ex As Exception

        End Try

    End Function

    Public Function TopicSubTopicMaterialMap_Delete(ByVal ESlno As Integer, ByVal SbjSlno As Integer, ByVal TrkSlno As Integer) As Integer
        Dim adap As New OracleDataAdapter
        Try
            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            oCommand.Transaction = oTrans
            oCommand.CommandText = "EXAM_TPCSTPCMATERAILMAP_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ESlno

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SbjSlno

            'ADD IN PARAMETER NAME iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TrkSlno

            oCommand.ExecuteNonQuery()

            oTrans.Commit()

            Return 1

        Catch ex As Exception

        End Try

    End Function

#End Region

End Class
