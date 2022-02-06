'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating Exams
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 19-AUG-2006
'   FINAL BASELINE DATE               : 19-AUG-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsMarksEntry

#Region "Common Variables"

    Private oConn As OracleConnection
    Private oCommand As OracleCommand
    Private oParameter As OracleParameter
    Private oAdapter As OracleDataAdapter
    Private oTrans As OracleTransaction
    Dim ds As DataSet
    Dim ObjConn As Connection

#End Region

#Region "Fetch"


    Public Function TailoredMass_Section_Fetch(ByVal COURSESLNO As Integer, ByVal DExamSLNo As Integer, ByVal ExamBranchSLNo As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            ds = New Data.DataSet

            oCommand.CommandText = "M_DEXAMSLNO_SECTION_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add in parameter as iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COURSESLNO

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DExamSLNo

            'Add in parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSLNo

            'ADD IN PARAMETER NAME 
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


    Public Function QPT_Upload_Subject_Fetch(ByVal DExamSLNo As Integer, ByVal EXAMTYPESLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            ds = New Data.DataSet

            oCommand.CommandText = "M_QPTUPLOAD_SUBJECT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DExamSLNo

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMTYPESLNO

            'ADD IN PARAMETER NAME 
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

    Public Function QPT_UploadSubjectTRACK_Fetch(ByVal DExamSLNo As Integer, ByVal EXAMTYPESLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            ds = New Data.DataSet

            oCommand.CommandText = "M_QPT_SUBJECTTRACK_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DExamSLNo

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMTYPESLNO

            'ADD IN PARAMETER NAME 
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

    Public Function QPT_Upload_Track_Fetch(ByVal DExamSLNo As Integer, ByVal EXAMTYPESLNO As Integer, ByVal SubjectSLNo As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            ds = New Data.DataSet

            oCommand.CommandText = "M_QPTUPLOAD_TRACK_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DExamSLNo

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMTYPESLNO

            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SubjectSLNo

            'ADD IN PARAMETER NAME 
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

    Public Function QPT_Upload_Topic_Fetch(ByVal DExamSLNo As Integer, ByVal EXAMTYPESLNO As Integer, ByVal SubjectSLNo As Integer, ByVal TrackSLNo As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            ds = New Data.DataSet

            oCommand.CommandText = "M_QPTUPLOAD_TOPIC_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DExamSLNo

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMTYPESLNO

            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SubjectSLNo

            'Add in parameter as iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TrackSLNo

            'ADD IN PARAMETER NAME 
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


    Public Function QPT_Upload_Question_Fetch(ByVal DExamSLNo As Integer, ByVal EXAMTYPESLNO As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            ds = New Data.DataSet

            oCommand.CommandText = "M_QPTUPLOAD_QUS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DExamSLNo

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMTYPESLNO

            'ADD IN PARAMETER NAME 
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


    Public Function TailoredMass_Adm_Fetch(ByVal DExamSLNo As Integer, ByVal EXAMBRANCHSLNO As Integer, ByVal COURSESLNO As Integer, ByVal SectionSLNo As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            ds = New Data.DataSet

            oCommand.CommandText = "M_TAILORMASS_ADM_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DExamSLNo

            'Add in parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMBRANCHSLNO

            'Add in parameter as iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COURSESLNO

            'Add in parameter as iSECTIONSLNO
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SectionSLNo

            'ADD IN PARAMETER NAME 
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


    Public Function ResultTemp_Adm_Fetch(ByVal DExamSLNo As Integer, ByVal ExamTypeSLNo As Integer, ByVal EXAMBRANCHSLNO As Integer, ByVal COURSESLNO As Integer, ByVal SectionSLNo As Integer, ByVal SubjectSLNo As Integer, ByVal TrackSLNo As Integer, ByVal TopicSLNo As Integer, ByVal QuesSLNo As Integer, ByVal SPName As String) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            ds = New Data.DataSet

            '"M_RESULTTEMP_ADM_SELECT" : For New Students i.e Mass  stuedents
            '"M_NOTINRESULTTEMP_ADM_SELECT" : This is For Students Add to Mass after Results Entery 

            oCommand.CommandText = SPName ' "M_RESULTTEMP_ADM_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DExamSLNo

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamTypeSLNo


            'Add in parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMBRANCHSLNO

            'Add in parameter as iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COURSESLNO

            'Add in parameter as iSECTIONSLNO
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SectionSLNo

            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SubjectSLNo

            'Add in parameter as iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TrackSLNo

            'Add in parameter as iTOPICSLNO
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TopicSLNo

            'Add in parameter as iQUESTIONSLNO
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QuesSLNo

            'ADD IN PARAMETER NAME 
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


    Public Function QPT_Upload_Fetch(ByVal DExamSLNo As Integer, ByVal ExamTypeSLNo As Integer, ByVal SubjectSLNo As Integer, ByVal TrackSLNo As Integer, ByVal TopicSLNo As Integer, ByVal QuestionSLNo As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            ds = New Data.DataSet

            oCommand.CommandText = "M_RESULT_QPTUPLOAD_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DExamSLNo

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamTypeSLNo

            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SubjectSLNo

            'Add in parameter as iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TrackSLNo

            'Add in parameter as iTOPICSLNO
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TopicSLNo

            'Add in parameter as iQUESTIONSLNO
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QuestionSLNo

            'ADD IN PARAMETER NAME 
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


    Public Function Result_Temp_Fetch(ByVal DExamSLNo As Integer, ByVal ExamTypeSLNo As Integer, ByVal SectionSLNo As Integer, ByVal SubjectSLNo As Integer, ByVal TrackSLNo As Integer, ByVal TopicSLNo As Integer, ByVal QuestionSLNo As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            ds = New Data.DataSet

            oCommand.CommandText = "M_RESULT_TEMP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DExamSLNo

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamTypeSLNo

            'Add in parameter as iSECTIONSLNO
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SectionSLNo

            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SubjectSLNo

            'Add in parameter as iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TrackSLNo

            'Add in parameter as iTOPICSLNO
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TopicSLNo

            'Add in parameter as iQUESTIONSLNO
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QuestionSLNo

            'ADD IN PARAMETER NAME 
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

    Public Function STAFFQPT_Upload_Subject_Fetch(ByVal DExamSLNo As Integer, ByVal EXAMTYPESLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            ds = New Data.DataSet

            oCommand.CommandText = "STAFF_QPTUPLOAD_SUBJECT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DExamSLNo

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMTYPESLNO

            'ADD IN PARAMETER NAME 
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

    Public Function STAFFQPT_Upload_Track_Fetch(ByVal DExamSLNo As Integer, ByVal EXAMTYPESLNO As Integer, ByVal SubjectSLNo As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            ds = New Data.DataSet

            oCommand.CommandText = "STAFF_QPTUPLOAD_TRACK_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DExamSLNo

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMTYPESLNO

            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SubjectSLNo

            'ADD IN PARAMETER NAME 
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

    Public Function STAFFQPT_Upload_Fetch(ByVal DExamSLNo As Integer, ByVal ExamTypeSLNo As Integer, ByVal SubjectSLNo As Integer, ByVal TrackSLNo As Integer, ByVal TopicSLNo As Integer, ByVal QuestionSLNo As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            ds = New Data.DataSet

            oCommand.CommandText = "STAFF_RESULT_QPTUPLOAD_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DExamSLNo

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamTypeSLNo

            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SubjectSLNo

            'Add in parameter as iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TrackSLNo

            'Add in parameter as iTOPICSLNO
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TopicSLNo

            'Add in parameter as iQUESTIONSLNO
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QuestionSLNo

            'ADD IN PARAMETER NAME 
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

    Public Function STAFFResult_Temp_Fetch(ByVal DExamSLNo As Integer, ByVal ExamTypeSLNo As Integer, ByVal SectionSLNo As Integer, ByVal SubjectSLNo As Integer, ByVal TrackSLNo As Integer, ByVal TopicSLNo As Integer, ByVal QuestionSLNo As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            ds = New Data.DataSet

            oCommand.CommandText = "STAFF_RESULT_TEMP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DExamSLNo

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamTypeSLNo

            'Add in parameter as iSECTIONSLNO
            'oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = SectionSLNo

            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SubjectSLNo

            'Add in parameter as iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TrackSLNo

            'Add in parameter as iTOPICSLNO
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TopicSLNo

            'Add in parameter as iQUESTIONSLNO
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QuestionSLNo

            'ADD IN PARAMETER NAME 
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

#End Region

#Region "Descriptive Marks Entry"


    Public Function Descriptive_ResultTemp_Save(ByVal dsDes As DataSet) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleCommand
            Dim UCommand As New OracleCommand


            ''Insert command
            oCommand.CommandText = "M_RESULT_TEMP_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'Update Command
            UCommand.CommandText = "M_RESULT_TEMP_UPDATE"
            UCommand.Connection = oConn
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Transaction = oTrans

            '



            'Add in parameter as ADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add in parameter as ADMSLNO
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"

            'Add in parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'Add in parameter as iCOPYNO
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"

            'Add in parameter as iQPTTSLNO
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNO"

            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iMINIMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MINIMARKS"


            'Add in parameter as iTOPICSLNO
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'Add in parameter as iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"

            'Add in parameter as iNOOFQUESTIONS
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"

            'Add in parameter as iQUESTIONSLNO
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"

            'Add in parameter as iQUESTIONNO
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'Add in parameter as iCORRECTANSWER
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER"

            'Add in parameter as iCORRECTMARK
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'Add in parameter as iNEGATIVEMARK
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"



            'Add in parameter as iSTUSTATUS
            oParameter = oCommand.Parameters.Add("iSTUSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"

            'Add in parameter as iSTUMARKS
            oParameter = oCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUMARKS"

            'Add in parameter as iSTATUS
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"
            oAdapter.InsertCommand = oCommand




            'Add in parameter as iRESULTTEMPSLNO
            oParameter = UCommand.Parameters.Add("iRESULTTEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = dsDes.Tables(0).Rows(0)("RESULTTEMPSLNO")
            oParameter.SourceColumn = "RESULTTEMPSLNO"

            'Add in parameter as iSTUANS
            oParameter = UCommand.Parameters.Add("iSTUANS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUANS"

            'Add in parameter as iSTUSTATUS
            oParameter = UCommand.Parameters.Add("iSTUSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"


            oParameter = UCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUMARKS"

            'oCommand.ExecuteNonQuery()

            oAdapter.UpdateCommand = UCommand

            oAdapter.Update(dsDes, dsDes.Tables(0).TableName)

            oTrans.Commit()

        Catch ex As Exception
            oTrans.Rollback()
            'Throw ex
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    Public Function StudentTRACKDescriptive_Save(ByVal dsDes As DataSet) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            If Not dsDes Is Nothing Then
                For I = 0 To dsDes.Tables(0).Rows.Count - 1
                    StuDescDelete(Val(dsDes.Tables(0).Rows(I)("ADMSLNO").ToString), Val(dsDes.Tables(0).Rows(I)("DEXAMSLNO").ToString), Val(dsDes.Tables(0).Rows(I)("SUBJECTSLNO").ToString), Val(dsDes.Tables(0).Rows(I)("TRACKSLNO").ToString), oConn, oTrans)
                Next
            End If

            StuTRACKWiseDesc_Save(dsDes, oConn, oTrans)
            oTrans.Commit()

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    Public Function StuTRACKWiseDesc_Save(ByVal dsDes As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try


            oCommand = New OracleCommand
            Dim UCommand As New OracleCommand


            ''Insert command
            oCommand.CommandText = "M_RESULT_TEMP_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans



            'Add in parameter as ADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add in parameter as ADMSLNO
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"

            'Add in parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'Add in parameter as iCOPYNO
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"

            'Add in parameter as iQPTTSLNO
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNO"

            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iMINIMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MINIMARKS"


            'Add in parameter as iTOPICSLNO
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'Add in parameter as iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"

            'Add in parameter as iNOOFQUESTIONS
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"

            'Add in parameter as iQUESTIONSLNO
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"

            'Add in parameter as iQUESTIONNO
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'Add in parameter as iCORRECTANSWER
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER"

            'Add in parameter as iCORRECTMARK
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'Add in parameter as iNEGATIVEMARK
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"



            'Add in parameter as iSTUSTATUS
            oParameter = oCommand.Parameters.Add("iSTUSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"

            'Add in parameter as iSTUMARKS
            oParameter = oCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUMARKS"

            'Add in parameter as iSTATUS
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"
            oAdapter.InsertCommand = oCommand


            oAdapter.UpdateCommand = UCommand

            oAdapter.Update(dsDes, dsDes.Tables(0).TableName)



        Catch ex As Exception
            'oTrans.Rollback()
            'Throw ex
            Throw ex
        Finally

        End Try

    End Function

    Public Function StudentWiseDescriptive_Save(ByVal dsDes As DataSet, ByVal SubjArrlst As ArrayList) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            If Not dsDes Is Nothing AndAlso Not SubjArrlst Is Nothing Then
                For I = 0 To dsDes.Tables(0).Rows.Count - 1
                    StuDescDelete(Val(dsDes.Tables(0).Rows(I)("ADMSLNO").ToString), Val(dsDes.Tables(0).Rows(I)("DEXAMSLNO").ToString), Val(dsDes.Tables(0).Rows(I)("SUBJECTSLNO").ToString), Val(dsDes.Tables(0).Rows(I)("TRACKSLNO").ToString), oConn, oTrans)
                Next
            End If

            StudentWiseDescriptiveSave(dsDes, oConn, oTrans)
            oTrans.Commit()

        Catch ex As Exception
            oTrans.Rollback()
            'Throw ex
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Private Function StuDescDelete(ByVal pADMSLNO As Long, ByVal pDEXAMSLNO As Integer, ByVal pSUBJECTSLNO As Integer, ByVal pTRACKSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand

            oCommand.CommandText = "EXAM_STUDESC_DELETE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO


            oParameter = oCommand.Parameters.Add("iADMSNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO


            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSUBJECTSLNO


            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pTRACKSLNO

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Catch OrEx As OracleClient.OracleException
            Throw OrEx
        End Try

    End Function

    Private Function StudentWiseDescriptiveSave(ByVal dsDes As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            oAdapter = New OracleDataAdapter
            oCommand = New OracleCommand

            Dim UCommand As New OracleCommand

            ''Insert command
            oCommand.CommandText = "M_RESULT_TEMP_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'Update Command
            UCommand.CommandText = "M_RESULT_TEMP_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Transaction = pTrans


            'Add in parameter as ADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add in parameter as ADMSLNO
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"

            'Add in parameter as EXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"


            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'Add in parameter as iCOPYNO
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"

            'Add in parameter as iQPTTSLNO
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNO"

            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iMINIMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MINIMARKS"


            'Add in parameter as iTOPICSLNO
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'Add in parameter as iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"

            'Add in parameter as iNOOFQUESTIONS
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"

            'Add in parameter as iQUESTIONSLNO
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"

            'Add in parameter as iQUESTIONNO
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'Add in parameter as iCORRECTANSWER
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER"

            'Add in parameter as iCORRECTMARK
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'Add in parameter as iNEGATIVEMARK
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"



            'Add in parameter as iSTUSTATUS
            oParameter = oCommand.Parameters.Add("iSTUSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"

            'Add in parameter as iSTUMARKS
            oParameter = oCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUMARKS"

            'Add in parameter as iSTATUS
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"
            oAdapter.InsertCommand = oCommand




            'Add in parameter as iRESULTTEMPSLNO
            oParameter = UCommand.Parameters.Add("iRESULTTEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = dsDes.Tables(0).Rows(0)("RESULTTEMPSLNO")
            oParameter.SourceColumn = "RESULTTEMPSLNO"

            'Add in parameter as iSTUANS
            oParameter = UCommand.Parameters.Add("iSTUANS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUANS"

            'Add in parameter as iSTUSTATUS
            oParameter = UCommand.Parameters.Add("iSTUSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"


            oParameter = UCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUMARKS"

            'oCommand.ExecuteNonQuery()

            oAdapter.UpdateCommand = UCommand

            oAdapter.Update(dsDes, dsDes.Tables(0).TableName)

            ''oTrans.Commit()

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function StaffTRACKDescriptive_Save(ByVal dsDes As DataSet) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            If Not dsDes Is Nothing Then
                For I = 0 To dsDes.Tables(0).Rows.Count - 1
                    StaffDescDelete(Val(dsDes.Tables(0).Rows(I)("UNIQUENO").ToString), Val(dsDes.Tables(0).Rows(I)("DEXAMSLNO").ToString), Val(dsDes.Tables(0).Rows(I)("SUBJECTSLNO").ToString), Val(dsDes.Tables(0).Rows(I)("TRACKSLNO").ToString), oConn, oTrans)
                Next
            End If

            StaffTRACKWiseDesc_Save(dsDes, oConn, oTrans)
            oTrans.Commit()

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function StaffTRACKWiseDesc_Save(ByVal dsDes As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try


            oCommand = New OracleCommand
            Dim UCommand As New OracleCommand


            ''Insert command
            oCommand.CommandText = "STAFF_RESULT_TEMP_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans



            'Add in parameter as ADMSLNO
            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "UNIQUENO"

            'Add in parameter as ADMSLNO
            'oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "SECTIONSLNO"

            'Add in parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'Add in parameter as iCOPYNO
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"

            'Add in parameter as iQPTTSLNO
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNO"

            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iMINIMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MINIMARKS"


            'Add in parameter as iTOPICSLNO
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'Add in parameter as iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"

            'Add in parameter as iNOOFQUESTIONS
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"

            'Add in parameter as iQUESTIONSLNO
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"

            'Add in parameter as iQUESTIONNO
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'Add in parameter as iCORRECTANSWER
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER"

            'Add in parameter as iCORRECTMARK
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'Add in parameter as iNEGATIVEMARK
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"



            'Add in parameter as iSTUSTATUS
            oParameter = oCommand.Parameters.Add("iSTUSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"

            'Add in parameter as iSTUMARKS
            oParameter = oCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUMARKS"

            'Add in parameter as iSTATUS
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"
            oAdapter.InsertCommand = oCommand


            oAdapter.UpdateCommand = UCommand

            oAdapter.Update(dsDes, dsDes.Tables(0).TableName)



        Catch ex As Exception
            'oTrans.Rollback()
            'Throw ex
            Throw ex
        Finally

        End Try

    End Function

    Private Function StaffDescDelete(ByVal pUNIQUENO As Long, ByVal pDEXAMSLNO As Integer, ByVal pSUBJECTSLNO As Integer, ByVal pTRACKSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand

            oCommand.CommandText = "STAFF_STUDESC_DELETE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO


            oParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pUNIQUENO


            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSUBJECTSLNO


            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pTRACKSLNO

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Catch OrEx As OracleClient.OracleException
            Throw OrEx
        End Try

    End Function

#End Region

#Region "Objective Marks Entry"


    Public Function Objective_ResultTemp_Save(ByVal dsUpload As DataSet, ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal CopyNo As Integer, ByVal pStatus As String, ByVal EXAMBRANCHSLNO As Integer, ByVal SECTIONSLNO As Integer) As String
        Dim rtnString As String

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsUpload) Then

                ResultTempSave(dsUpload, pADMSLNO, EXAMBRANCHSLNO, SECTIONSLNO, oConn, oTrans)
                If CopyNo = 2 Then ResultAutoCompare(pADMSLNO, pDEXAMSLNO, oConn, oTrans)

            End If

            oTrans.Commit()
            rtnString = "Result Temp Saved"

        Catch ex As Exception
            oTrans.Rollback()
            rtnString = ex.Message.ToString
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Private Function ResultTempSave(ByVal dsupload As DataSet, ByVal pADMSLNO As Integer, ByVal EXAMBRANCHSLNO As Integer, ByVal SECTIONSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand

            oCommand.CommandText = "RESULT_TEMP_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            UCommand.CommandText = "RESULT_TEMP_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iADMSLNO 0
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME EXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMBRANCHSLNO


            'ADD IN PARAMETER NAME SECTIONSLNO
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SECTIONSLNO

            'ADD IN PARAMETER NAME iCOPYNO 0
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 2
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 3
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 4
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 5
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 6
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 7
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 8
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 9
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'ADD IN PARAMETER NAME iCORRECTANSWER 10
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER"

            'ADD IN PARAMETER NAME iCORRECTMARK 11
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'ADD IN PARAMETER NAME iNEGATIVEMARK 12
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            'ADD IN PARAMETER NAME iSTUANS 14
            oParameter = oCommand.Parameters.Add("iSTUANS1", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns1"

            'ADD IN PARAMETER NAME iSTUANS 15
            oParameter = oCommand.Parameters.Add("iSTUANS2", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns2"

            'ADD IN PARAMETER NAME iSTUANS 16
            oParameter = oCommand.Parameters.Add("iSTUANS3", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns3"

            'ADD IN PARAMETER NAME iSTUANS 17
            oParameter = oCommand.Parameters.Add("iSTUANS4", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns4"

            'ADD IN PARAMETER NAME iSTUANS 18
            oParameter = oCommand.Parameters.Add("iSTUANS5", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns5"

            'ADD IN PARAMETER NAME iSTUANS 19
            oParameter = oCommand.Parameters.Add("iSTUANS6", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns6"

            'ADD IN PARAMETER NAME iSTUANS 20
            oParameter = oCommand.Parameters.Add("iSTUANS7", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns7"

            'ADD IN PARAMETER NAME iSTUMARKS 14
            oParameter = oCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'Add in parameter as iSTUSTATUS
            oParameter = oCommand.Parameters.Add("iSTUSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"

            'ADD IN PARAMETER NAME iSTATUS 15
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.InsertCommand = oCommand

            ''''''''''''''''''''''''''''UPDATE''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'ADD IN PARAMETER NAME iRESULTTEMPSLNO 0
            oParameter = UCommand.Parameters.Add("iRESULTTEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTUPLOADSLNO"

            'ADD IN PARAMETER NAME iADMSLNO 1
            oParameter = UCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 2
            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iCOPYNO 3
            oParameter = UCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 4
            oParameter = UCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 5
            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 6
            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 7
            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 8
            oParameter = UCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 9
            oParameter = UCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 10
            oParameter = UCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 11
            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"


            'ADD IN PARAMETER NAME iSTUANS 14
            oParameter = UCommand.Parameters.Add("iSTUANS1", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns1"

            'ADD IN PARAMETER NAME iSTUANS 15
            oParameter = UCommand.Parameters.Add("iSTUANS2", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns2"

            'ADD IN PARAMETER NAME iSTUANS 16
            oParameter = UCommand.Parameters.Add("iSTUANS3", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns3"

            'ADD IN PARAMETER NAME iSTUANS 17
            oParameter = UCommand.Parameters.Add("iSTUANS4", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns4"

            'ADD IN PARAMETER NAME iSTUANS 18
            oParameter = UCommand.Parameters.Add("iSTUANS5", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns5"

            'ADD IN PARAMETER NAME iSTUANS 19
            oParameter = UCommand.Parameters.Add("iSTUANS6", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns6"

            'ADD IN PARAMETER NAME iSTUANS 20
            oParameter = UCommand.Parameters.Add("iSTUANS7", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns7"

            'ADD IN PARAMETER NAME iSTUMARKS 13
            oParameter = UCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'Add in parameter as iSTUSTATUS
            oParameter = UCommand.Parameters.Add("iSTUSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"

            'ADD IN PARAMETER NAME iSTATUS 14
            oParameter = UCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.UpdateCommand = UCommand
            oAdapter.Update(dsupload, "Objective")

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Private Function ResultAutoCompare(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand

            oCommand.CommandText = "AUTOMATICRESULTCOMP_CURSORE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iADMSLNO 0
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try

    End Function


#End Region

#Region "Report Files Upload save/delete"
    'written by prakash 

    Public Function ReportFiles_Delete(ByVal iSLNO As Integer) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleCommand
            Dim UCommand As New OracleCommand


            ''Insert command
            oCommand.CommandText = "EXAM_RPTUPLOADFILES_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans


            'Add in parameter as iUSERSLNO
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSLNO

            oCommand.ExecuteNonQuery()

            oTrans.Commit()

            Return " File Deleted "

        Catch ex As Exception
            oTrans.Rollback()
            'Throw ex
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function



    Public Function ReportFiles_Save(ByVal iDEXAMSLNO As Integer, ByVal iREPORTNAME As String, ByVal iDESC As String, ByVal iFILEPATH As String, ByVal iUSERSLNO As Integer, ByVal iFILENAME As String) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleCommand
            Dim UCommand As New OracleCommand


            ''Insert command
            oCommand.CommandText = "EXAM_RPTUPLOADFILES_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans



            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            'Add in parameter as iREPORTNAME
            oParameter = oCommand.Parameters.Add("iRPTNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iREPORTNAME

            'Add in parameter as iDESC
            oParameter = oCommand.Parameters.Add("iDESC", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDESC

            'Add in parameter as iFILEPATH
            oParameter = oCommand.Parameters.Add("iFILEPATH", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFILEPATH

            'Add in parameter as iUSERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'Add in parameter as iFile name
            oParameter = oCommand.Parameters.Add("iFILENAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFILENAME



            oCommand.ExecuteNonQuery()

            oTrans.Commit()
            Return " File Saved Successfully "
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function
#End Region

#Region " Objective Files Upload"

    Public Function ObjectiveFiles_Save(ByVal iUSERSLNO As Integer, ByVal iDEXAMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal iFILENAME As String, ByVal iFILEPATH As String, ByVal iUSERFILENAME As String) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleCommand
            Dim UCommand As New OracleCommand


            ''Insert command
            oCommand.CommandText = "EXAM_OBJECTIVEFILES_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans


            'Add in parameter as iUSERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            'Add in parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'Add in parameter as iFILENAME
            oParameter = oCommand.Parameters.Add("iFILENAME", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFILENAME

            'Add in parameter as iFILEPATH
            oParameter = oCommand.Parameters.Add("iFILEPATH", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFILEPATH

            'Add in parameter as iUSERFILENAME
            oParameter = oCommand.Parameters.Add("iUSERFILENAME", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERFILENAME


            'Add in parameter as iLOCKED
            oParameter = oCommand.Parameters.Add("iLOCKED", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = 0


            oCommand.ExecuteNonQuery()

            oTrans.Commit()
            Return " File Saved "
        Catch ex As Exception
            oTrans.Rollback()
            'Throw ex
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ObjectiveFiles_Update(ByVal iUSERSLNO As Integer, ByVal iDEXAMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleCommand
            Dim UCommand As New OracleCommand


            ''Insert command
            oCommand.CommandText = "EXAM_OBJECTIVEFILES_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans


            'Add in parameter as iUSERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            'Add in parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO


            oCommand.ExecuteNonQuery()

            oTrans.Commit()
            Return " Exam Locked "
        Catch ex As Exception
            oTrans.Rollback()
            'Throw ex
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function ObjectiveFiles_Delete(ByVal iOBJFILESLNO As Integer) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleCommand
            Dim UCommand As New OracleCommand


            ''Insert command
            oCommand.CommandText = "EXAM_OBJECTIVEFILES_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans


            'Add in parameter as iUSERSLNO
            oParameter = oCommand.Parameters.Add("iOBJFILESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iOBJFILESLNO

            oCommand.ExecuteNonQuery()

            oTrans.Commit()

            Return " File Deleted "

        Catch ex As Exception
            oTrans.Rollback()
            'Throw ex
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


#End Region


#Region " IIT Files Upload V2.0"

    Public Function IITFiles_Save(ByVal iUSERSLNO As Integer, ByVal iDEXAMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal iFILENAME As String, ByVal iFILEPATH As String, ByVal iUSERFILENAME As String) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleCommand
            Dim UCommand As New OracleCommand


            ''Insert command
            oCommand.CommandText = "EXAM_IITFILES_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans


            'Add in parameter as iUSERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            'Add in parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'Add in parameter as iFILENAME
            oParameter = oCommand.Parameters.Add("iFILENAME", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFILENAME

            'Add in parameter as iFILEPATH
            oParameter = oCommand.Parameters.Add("iFILEPATH", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFILEPATH

            'Add in parameter as iUSERFILENAME
            oParameter = oCommand.Parameters.Add("iUSERFILENAME", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERFILENAME


            'Add in parameter as iLOCKED
            oParameter = oCommand.Parameters.Add("iLOCKED", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = 0


            oCommand.ExecuteNonQuery()

            oTrans.Commit()
            Return " File Saved "
        Catch ex As Exception
            oTrans.Rollback()
            'Throw ex
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function IITFiles_Update(ByVal iUSERSLNO As Integer, ByVal iDEXAMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleCommand
            Dim UCommand As New OracleCommand


            ''Insert command
            oCommand.CommandText = "EXAM_IITFILES_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans


            'Add in parameter as iUSERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            'Add in parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO


            oCommand.ExecuteNonQuery()

            oTrans.Commit()
            Return " Exam Locked "
        Catch ex As Exception
            oTrans.Rollback()
            'Throw ex
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function IITFiles_Delete(ByVal iOBJFILESLNO As Integer) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleCommand
            Dim UCommand As New OracleCommand


            ''Insert command
            oCommand.CommandText = "EXAM_IITFILES_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans


            'Add in parameter as iUSERSLNO
            oParameter = oCommand.Parameters.Add("iOBJFILESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iOBJFILESLNO

            oCommand.ExecuteNonQuery()

            oTrans.Commit()

            Return " File Deleted "

        Catch ex As Exception
            oTrans.Rollback()
            'Throw ex
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


#End Region


#Region "IIT Objective Marks Entry"


    Public Function IIT_Objective_ResultTemp_Save(ByVal dsUpload As DataSet, ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal CopyNo As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()


            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsUpload) Then

                IIT_ResultTempSave(dsUpload, pADMSLNO, oConn, oTrans)
                If CopyNo = 2 Then IIT_ResultAutoCompare(pADMSLNO, pDEXAMSLNO, oConn, oTrans)

            End If

            oTrans.Commit()
            rtnString = "Result Temp Saved"

        Catch ex As Exception
            oTrans.Rollback()
            rtnString = ex.Message.ToString
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Private Function IIT_ResultTempSave(ByVal dsupload As DataSet, ByVal pADMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand

            oCommand.CommandText = "IIT_RESULT_TEMP_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            UCommand.CommandText = "IIT_RESULT_TEMP_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iADMSLNO 0
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iCOPYNO 0
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 2
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 3
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 4
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 5
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 6
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 7
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 8
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 9
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'ADD IN PARAMETER NAME iCORRECTANSWER 10
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER"

            'ADD IN PARAMETER NAME iCORRECTMARK 11
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'ADD IN PARAMETER NAME iNEGATIVEMARK 12
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            'ADD IN PARAMETER NAME iSTUANS 14
            oParameter = oCommand.Parameters.Add("iSTUANS1", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns1"

            'ADD IN PARAMETER NAME iSTUANS 15
            oParameter = oCommand.Parameters.Add("iSTUANS2", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns2"

            'ADD IN PARAMETER NAME iSTUANS 16
            oParameter = oCommand.Parameters.Add("iSTUANS3", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns3"

            'ADD IN PARAMETER NAME iSTUANS 17
            oParameter = oCommand.Parameters.Add("iSTUANS4", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns4"

            'ADD IN PARAMETER NAME iSTUANS 18
            oParameter = oCommand.Parameters.Add("iSTUANS5", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns5"

            'ADD IN PARAMETER NAME iSTUANS 19
            oParameter = oCommand.Parameters.Add("iSTUANS6", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns6"

            'ADD IN PARAMETER NAME iSTUANS 20
            oParameter = oCommand.Parameters.Add("iSTUANS7", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns7"

            'ADD IN PARAMETER NAME iSTUMARKS 14
            oParameter = oCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'Add in parameter as iSTUSTATUS
            oParameter = oCommand.Parameters.Add("iSTUSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"

            'ADD IN PARAMETER NAME iSTATUS 15
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.InsertCommand = oCommand

            ''''''''''''''''''''''''''''UPDATE''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'ADD IN PARAMETER NAME iRESULTTEMPSLNO 0
            oParameter = UCommand.Parameters.Add("iRESULTTEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTUPLOADSLNO"

            'ADD IN PARAMETER NAME iADMSLNO 1
            oParameter = UCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 2
            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iCOPYNO 3
            oParameter = UCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 4
            oParameter = UCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 5
            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 6
            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 7
            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 8
            oParameter = UCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 9
            oParameter = UCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 10
            oParameter = UCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 11
            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"


            'ADD IN PARAMETER NAME iSTUANS 14
            oParameter = UCommand.Parameters.Add("iSTUANS1", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns1"

            'ADD IN PARAMETER NAME iSTUANS 15
            oParameter = UCommand.Parameters.Add("iSTUANS2", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns2"

            'ADD IN PARAMETER NAME iSTUANS 16
            oParameter = UCommand.Parameters.Add("iSTUANS3", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns3"

            'ADD IN PARAMETER NAME iSTUANS 17
            oParameter = UCommand.Parameters.Add("iSTUANS4", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns4"

            'ADD IN PARAMETER NAME iSTUANS 18
            oParameter = UCommand.Parameters.Add("iSTUANS5", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns5"

            'ADD IN PARAMETER NAME iSTUANS 19
            oParameter = UCommand.Parameters.Add("iSTUANS6", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns6"

            'ADD IN PARAMETER NAME iSTUANS 20
            oParameter = UCommand.Parameters.Add("iSTUANS7", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns7"

            'ADD IN PARAMETER NAME iSTUMARKS 13
            oParameter = UCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'Add in parameter as iSTUSTATUS
            oParameter = UCommand.Parameters.Add("iSTUSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"

            'ADD IN PARAMETER NAME iSTATUS 14
            oParameter = UCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.UpdateCommand = UCommand
            oAdapter.Update(dsupload, "Objective")

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ' THIS IS FOR AUTOMATIC RESULT COMPAIRE WHEN COPY NO 2 IS SAVING
    Private Function IIT_ResultAutoCompare(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand

            oCommand.CommandText = "IIT_ARCOMP_CURSORE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iADMSLNO 0
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try

    End Function


#End Region

#Region "AIEEE Objective Marks Entry"


    Public Function AIE_Objective_ResultTemp_Save(ByVal dsUpload As DataSet, ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal CopyNo As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsUpload) Then

                AIE_ResultTempSave(dsUpload, pADMSLNO, oConn, oTrans)
                If CopyNo = 2 Then AIE_ResultAutoCompare(pADMSLNO, pDEXAMSLNO, oConn, oTrans)

            End If

            oTrans.Commit()
            rtnString = "Result Temp Saved"

        Catch ex As Exception
            oTrans.Rollback()
            rtnString = ex.Message.ToString
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Private Function AIE_ResultTempSave(ByVal dsupload As DataSet, ByVal pADMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand

            oCommand.CommandText = "AIE_RESULT_TEMP_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            UCommand.CommandText = "AIE_RESULT_TEMP_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iADMSLNO 0
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iCOPYNO 0
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 2
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 3
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 4
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 5
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 6
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 7
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 8
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 9
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'ADD IN PARAMETER NAME iCORRECTANSWER 10
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER"

            'ADD IN PARAMETER NAME iCORRECTMARK 11
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'ADD IN PARAMETER NAME iNEGATIVEMARK 12
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            'ADD IN PARAMETER NAME iSTUANS 14
            oParameter = oCommand.Parameters.Add("iSTUANS1", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns1"

            'ADD IN PARAMETER NAME iSTUANS 15
            oParameter = oCommand.Parameters.Add("iSTUANS2", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns2"

            'ADD IN PARAMETER NAME iSTUANS 16
            oParameter = oCommand.Parameters.Add("iSTUANS3", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns3"

            'ADD IN PARAMETER NAME iSTUANS 17
            oParameter = oCommand.Parameters.Add("iSTUANS4", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns4"

            'ADD IN PARAMETER NAME iSTUANS 18
            oParameter = oCommand.Parameters.Add("iSTUANS5", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns5"

            'ADD IN PARAMETER NAME iSTUANS 19
            oParameter = oCommand.Parameters.Add("iSTUANS6", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns6"

            'ADD IN PARAMETER NAME iSTUANS 20
            oParameter = oCommand.Parameters.Add("iSTUANS7", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns7"

            'ADD IN PARAMETER NAME iSTUMARKS 14
            oParameter = oCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'Add in parameter as iSTUSTATUS
            oParameter = oCommand.Parameters.Add("iSTUSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"

            'ADD IN PARAMETER NAME iSTATUS 15
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.InsertCommand = oCommand

            ''''''''''''''''''''''''''''UPDATE''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'ADD IN PARAMETER NAME iRESULTTEMPSLNO 0
            oParameter = UCommand.Parameters.Add("iRESULTTEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTUPLOADSLNO"

            'ADD IN PARAMETER NAME iADMSLNO 1
            oParameter = UCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 2
            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iCOPYNO 3
            oParameter = UCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 4
            oParameter = UCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 5
            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 6
            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 7
            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 8
            oParameter = UCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 9
            oParameter = UCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 10
            oParameter = UCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 11
            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"


            'ADD IN PARAMETER NAME iSTUANS 14
            oParameter = UCommand.Parameters.Add("iSTUANS1", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns1"

            'ADD IN PARAMETER NAME iSTUANS 15
            oParameter = UCommand.Parameters.Add("iSTUANS2", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns2"

            'ADD IN PARAMETER NAME iSTUANS 16
            oParameter = UCommand.Parameters.Add("iSTUANS3", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns3"

            'ADD IN PARAMETER NAME iSTUANS 17
            oParameter = UCommand.Parameters.Add("iSTUANS4", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns4"

            'ADD IN PARAMETER NAME iSTUANS 18
            oParameter = UCommand.Parameters.Add("iSTUANS5", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns5"

            'ADD IN PARAMETER NAME iSTUANS 19
            oParameter = UCommand.Parameters.Add("iSTUANS6", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns6"

            'ADD IN PARAMETER NAME iSTUANS 20
            oParameter = UCommand.Parameters.Add("iSTUANS7", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns7"

            'ADD IN PARAMETER NAME iSTUMARKS 13
            oParameter = UCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'Add in parameter as iSTUSTATUS
            oParameter = UCommand.Parameters.Add("iSTUSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"

            'ADD IN PARAMETER NAME iSTATUS 14
            oParameter = UCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.UpdateCommand = UCommand
            oAdapter.Update(dsupload, "Objective")

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ' THIS IS FOR AUTOMATIC RESULT COMPAIRE WHEN COPY NO 2 IS SAVING
    Private Function AIE_ResultAutoCompare(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand

            oCommand.CommandText = "AIE_ARCOMP_CURSORE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iADMSLNO 0
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try

    End Function


#End Region

#Region " EMACET Objective Marks Entry "


    Public Function ECET_Objective_ResultTemp_Save(ByVal dsUpload As DataSet, ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal CopyNo As Integer, ByVal pStatus As String) As String
        Dim rtnString As String

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()


            'Exam Question Inserting Objective Descriptive
            If Not IsNothing(dsUpload) Then

                ECET_ResultTempSave(dsUpload, pADMSLNO, oConn, oTrans)
                If CopyNo = 2 Then ECET_ResultAutoCompare(pADMSLNO, pDEXAMSLNO, oConn, oTrans)

            End If

            oTrans.Commit()
            rtnString = "Result Temp Saved"

        Catch ex As Exception
            oTrans.Rollback()
            rtnString = ex.Message.ToString
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Private Function ECET_ResultTempSave(ByVal dsupload As DataSet, ByVal pADMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand

            oCommand.CommandText = "ECET_RESULT_TEMP_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            UCommand.CommandText = "ECET_RESULT_TEMP_UPDATE"
            UCommand.Connection = pConn
            UCommand.CommandType = CommandType.StoredProcedure
            UCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iADMSLNO 0
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iCOPYNO 0
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 2
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 3
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 4
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 5
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 6
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 7
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 8
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 9
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'ADD IN PARAMETER NAME iCORRECTANSWER 10
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER"

            'ADD IN PARAMETER NAME iCORRECTMARK 11
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'ADD IN PARAMETER NAME iNEGATIVEMARK 12
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"

            'ADD IN PARAMETER NAME iSTUANS 14
            oParameter = oCommand.Parameters.Add("iSTUANS1", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns1"

            'ADD IN PARAMETER NAME iSTUANS 15
            oParameter = oCommand.Parameters.Add("iSTUANS2", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns2"

            'ADD IN PARAMETER NAME iSTUANS 16
            oParameter = oCommand.Parameters.Add("iSTUANS3", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns3"

            'ADD IN PARAMETER NAME iSTUANS 17
            oParameter = oCommand.Parameters.Add("iSTUANS4", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns4"

            'ADD IN PARAMETER NAME iSTUANS 18
            oParameter = oCommand.Parameters.Add("iSTUANS5", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns5"

            'ADD IN PARAMETER NAME iSTUANS 19
            oParameter = oCommand.Parameters.Add("iSTUANS6", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns6"

            'ADD IN PARAMETER NAME iSTUANS 20
            oParameter = oCommand.Parameters.Add("iSTUANS7", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns7"

            'ADD IN PARAMETER NAME iSTUMARKS 14
            oParameter = oCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'Add in parameter as iSTUSTATUS
            oParameter = oCommand.Parameters.Add("iSTUSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"

            'ADD IN PARAMETER NAME iSTATUS 15
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.InsertCommand = oCommand

            ''''''''''''''''''''''''''''UPDATE''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'ADD IN PARAMETER NAME iRESULTTEMPSLNO 0
            oParameter = UCommand.Parameters.Add("iRESULTTEMPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTUPLOADSLNO"

            'ADD IN PARAMETER NAME iADMSLNO 1
            oParameter = UCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 2
            oParameter = UCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"


            'ADD IN PARAMETER NAME iCOPYNO 3
            oParameter = UCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"


            'ADD IN PARAMETER NAME iQPTTSLNO 4
            oParameter = UCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNo"
            'oParameter.Value = dsUpload.Tables(0).Rows(0)("QPTTSLNo")

            'ADD IN PARAMETER NAME iSUBJECTSLNO 5
            oParameter = UCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'ADD IN PARAMETER NAME iTOPICSLNO 6
            oParameter = UCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"


            'ADD IN PARAMETER NAME iTRACKSLNO 7
            oParameter = UCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPESLNO 8
            oParameter = UCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"


            'ADD IN PARAMETER NAME iNOOFQUESTIONS 9
            oParameter = UCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"


            'ADD IN PARAMETER NAME iQUESTIONSLNO 10
            oParameter = UCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"


            'ADD IN PARAMETER NAME iQUESTIONNO 11
            oParameter = UCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"


            'ADD IN PARAMETER NAME iSTUANS 14
            oParameter = UCommand.Parameters.Add("iSTUANS1", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns1"

            'ADD IN PARAMETER NAME iSTUANS 15
            oParameter = UCommand.Parameters.Add("iSTUANS2", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns2"

            'ADD IN PARAMETER NAME iSTUANS 16
            oParameter = UCommand.Parameters.Add("iSTUANS3", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns3"

            'ADD IN PARAMETER NAME iSTUANS 17
            oParameter = UCommand.Parameters.Add("iSTUANS4", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns4"

            'ADD IN PARAMETER NAME iSTUANS 18
            oParameter = UCommand.Parameters.Add("iSTUANS5", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns5"

            'ADD IN PARAMETER NAME iSTUANS 19
            oParameter = UCommand.Parameters.Add("iSTUANS6", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns6"

            'ADD IN PARAMETER NAME iSTUANS 20
            oParameter = UCommand.Parameters.Add("iSTUANS7", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuAns7"

            'ADD IN PARAMETER NAME iSTUMARKS 13
            oParameter = UCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "StuMarks"

            'Add in parameter as iSTUSTATUS
            oParameter = UCommand.Parameters.Add("iSTUSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"

            'ADD IN PARAMETER NAME iSTATUS 14
            oParameter = UCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"

            oAdapter.UpdateCommand = UCommand
            oAdapter.Update(dsupload, "Objective")

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ' THIS IS FOR AUTOMATIC RESULT COMPAIRE WHEN COPY NO 2 IS SAVING
    Private Function ECET_ResultAutoCompare(ByVal pADMSLNO As Integer, ByVal pDEXAMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand
            Dim UCommand As OracleClient.OracleCommand
            UCommand = New OracleCommand

            oCommand.CommandText = "ECET_ARCOMP_CURSORE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iADMSLNO 0
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO

            'ADD IN PARAMETER NAME iDEXAMSLNO 1
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try

    End Function


#End Region

#Region " Objective "

    Public Function StudentWiseObjective_Save(ByVal dsDes As DataSet, ByVal SubjArrlst As ArrayList) As String
        Try
            Dim I As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            If Not dsDes Is Nothing AndAlso Not SubjArrlst Is Nothing Then
                For I = 0 To dsDes.Tables(0).Rows.Count - 1
                    StuObjDelete(Val(dsDes.Tables(0).Rows(I)("ADMSLNO").ToString), Val(dsDes.Tables(0).Rows(I)("DEXAMSLNO").ToString), Val(dsDes.Tables(0).Rows(I)("SUBJECTSLNO").ToString), Val(dsDes.Tables(0).Rows(I)("TRACKSLNO").ToString), oConn, oTrans)
                Next
            End If

            StudentWiseObjectiveSave(dsDes, oConn, oTrans)
            oTrans.Commit()

        Catch ex As Exception
            oTrans.Rollback()
            'Throw ex
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Private Function StuObjDelete(ByVal pADMSLNO As Long, ByVal pDEXAMSLNO As Integer, ByVal pSUBJECTSLNO As Integer, ByVal pTRACKSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            oAdapter = New OracleDataAdapter
            Dim oCommand As OracleClient.OracleCommand
            oCommand = New OracleCommand

            oCommand.CommandText = "EXAM_STUOBJ_DELETE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pDEXAMSLNO


            oParameter = oCommand.Parameters.Add("iADMSNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pADMSLNO


            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSUBJECTSLNO


            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pTRACKSLNO

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Catch OrEx As OracleClient.OracleException
            Throw OrEx
        End Try

    End Function

    Private Function StudentWiseObjectiveSave(ByVal dsDes As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            oAdapter = New OracleDataAdapter
            oCommand = New OracleCommand

            Dim UCommand As New OracleCommand

            ''Insert command
            oCommand.CommandText = "EXAM_OBJRESFINAL_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans



            'Add in parameter as ADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add in parameter as ADMSLNO
            oParameter = oCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"

            'Add in parameter as EXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"


            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'Add in parameter as iCOPYNO
            oParameter = oCommand.Parameters.Add("iCOPYNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COPYNO"

            'Add in parameter as iQPTTSLNO
            oParameter = oCommand.Parameters.Add("iQPTTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTTSLNO"

            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"


            'Add in parameter as iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iMINIMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MINIMARKS"


            'Add in parameter as iTOPICSLNO
            oParameter = oCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'Add in parameter as iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TRACKSLNO"

            'Add in parameter as iEXAMTYPESLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPESLNO"

            'Add in parameter as iNOOFQUESTIONS
            oParameter = oCommand.Parameters.Add("iNOOFQUESTIONS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NOOFQUESTIONS"

            'Add in parameter as iQUESTIONSLNO
            oParameter = oCommand.Parameters.Add("iQUESTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONSLNO"

            'Add in parameter as iQUESTIONNO
            oParameter = oCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"

            'Add in parameter as iCORRECTANSWER
            oParameter = oCommand.Parameters.Add("iCORRECTANSWER", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTANSWER"

            'Add in parameter as iCORRECTMARK
            oParameter = oCommand.Parameters.Add("iCORRECTMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CORRECTMARK"

            'Add in parameter as iNEGATIVEMARK
            oParameter = oCommand.Parameters.Add("iNEGATIVEMARK", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "NEGATIVEMARK"



            'Add in parameter as iSTUSTATUS
            oParameter = oCommand.Parameters.Add("iSTUSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUSTATUS"

            'Add in parameter as iSTUMARKS
            oParameter = oCommand.Parameters.Add("iSTUMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUMARKS"

            'Add in parameter as iSTATUS
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUS"
            oAdapter.InsertCommand = oCommand





            oAdapter.Update(dsDes, dsDes.Tables(0).TableName)

            ''oTrans.Commit()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region " Staff Objective Files Upload"

    Public Function Staff_ObjectiveFiles_Save(ByVal iUSERSLNO As Integer, ByVal iDEXAMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal iFILENAME As String, ByVal iFILEPATH As String, ByVal iUSERFILENAME As String) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleCommand
            Dim UCommand As New OracleCommand


            ''Insert command EXAM_OBJECTIVEFILES_INSERT
            oCommand.CommandText = "STAFF_OBJECTIVEFILES_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans


            'Add in parameter as iUSERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            'Add in parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'Add in parameter as iFILENAME
            oParameter = oCommand.Parameters.Add("iFILENAME", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFILENAME

            'Add in parameter as iFILEPATH
            oParameter = oCommand.Parameters.Add("iFILEPATH", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFILEPATH

            'Add in parameter as iUSERFILENAME
            oParameter = oCommand.Parameters.Add("iUSERFILENAME", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERFILENAME


            'Add in parameter as iLOCKED
            oParameter = oCommand.Parameters.Add("iLOCKED", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = 0


            oCommand.ExecuteNonQuery()

            oTrans.Commit()
            Return " File Saved "
        Catch ex As Exception
            oTrans.Rollback()
            'Throw ex
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Staff_ObjectiveFiles_Update(ByVal iUSERSLNO As Integer, ByVal iDEXAMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleCommand
            Dim UCommand As New OracleCommand


            ''Insert command EXAM_OBJECTIVEFILES_UPDATE
            oCommand.CommandText = "STAFF_OBJECTIVEFILES_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans


            'Add in parameter as iUSERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'Add in parameter as iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO

            'Add in parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO


            oCommand.ExecuteNonQuery()

            oTrans.Commit()
            Return " Exam Locked "
        Catch ex As Exception
            oTrans.Rollback()
            'Throw ex
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Staff_ObjectiveFiles_Delete(ByVal iOBJFILESLNO As Integer) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oAdapter = New OracleDataAdapter
            oTrans = oConn.BeginTransaction()

            oCommand = New OracleCommand
            Dim UCommand As New OracleCommand


            ''Insert command EXAM_OBJECTIVEFILES_DELETE
            oCommand.CommandText = "STAFF_OBJECTIVEFILES_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans


            'Add in parameter as iUSERSLNO
            oParameter = oCommand.Parameters.Add("iOBJFILESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iOBJFILESLNO

            oCommand.ExecuteNonQuery()

            oTrans.Commit()

            Return " File Deleted "

        Catch ex As Exception
            oTrans.Rollback()
            'Throw ex
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


#End Region
End Class
