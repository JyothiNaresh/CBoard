'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 
'   OBJECTIVE                         : This is the Common Filling
'   ACTIVITY                          : 
'   AUTHOR                            : P.Venu
'   INITIAL BASELINE DATE             : 10-OCT-2012
'   FINAL BASELINE DATE               : 10-OCT-2012
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsCommonFillings

#Region " $ Class Variables"
    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private oTrans As OracleTransaction
    Private Ds As DataSet
    Private ObjConn As Connection
    Private RtnVal As Integer
    Private RtnStr As String
#End Region

#Region " $ Common Fetch"

    Public Function UserWise_ObjExams_Fetch(ByVal ComAcademicslno As Integer, ByVal UserSlno As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "EXAM_USERCOMBINATIONS_OBJ"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME ICOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ComAcademicslno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = UserSlno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds
    End Function

    Public Function Exam_ExamDates_Fetch(ByVal Combinationkey As Integer, ByVal AcaSlno As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "EXAM_EXAMDATES"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME ICOMBINATONKEY
            oParameter = oCommand.Parameters.Add("ICOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Combinationkey

            'ADD IN PARAMETER NAME ICOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = AcaSlno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds
    End Function

    Public Function Exam_ExamSubjects_Fetch(ByVal Examslno As String) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "EXAM_EXAMSUBJECTS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME ICOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("IEXAMSLNO", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Examslno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds
    End Function

    Public Function Exam_ExamSubjectTracks_Fetch(ByVal Examslno As String, ByVal Subjectslno As String, ByVal Report As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            If Report = 1 Then
                oCommand.CommandText = "EXAM_SUBJECTTRACKS"
            Else
                oCommand.CommandText = "EXAM_SUBJECTTRACKS1"
            End If

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME ICOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("IEXAMSLNO", OracleType.VarChar, 300)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Examslno

            'ADD IN PARAMETER NAME ICOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("IEXAMSUBJECTS", OracleType.VarChar, 300)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Subjectslno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds
    End Function

    Public Function Exam_ExamTracks_Fetch(ByVal Examslno As String) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "EXAM_EXAMTRACKS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IEXAMSLNO
            oParameter = oCommand.Parameters.Add("IEXAMSLNO", OracleType.VarChar, 500)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Examslno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds
    End Function

    Public Function Exam_ExamType_Fetch(ByVal Examslno As Integer) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            'ObjConn = New Connection
            'oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAM_EXAMTYPE_GET"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'ADD IN PARAMETER NAME iEXAMSLNO 
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Examslno

            oCommand.Parameters.Add(New OracleParameter("SeqMt", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            RtnVal = oCommand.Parameters("SeqMt").Value

            Return RtnVal

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Exam_Material_Fetch() As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "EXAM_MATERIAL_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds
    End Function

    Public Function Exam_EamAieQuestions_Fetch(ByVal ExamSlno As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "EXAM_EAMAIEQSTNS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iEXAMSLNO 
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamSlno

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds
    End Function

    Public Function Exam_TpStpMatMap_Fetch(ByVal Examslno As Integer, ByVal Subjectslno As Integer, ByVal TrackSlno As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "EXAM_TPSTPMATMAP_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Examslno

            'ADD IN PARAMETER NAME ISUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Subjectslno

            'ADD IN PARAMETER NAME iTRACKSLNO
            oParameter = oCommand.Parameters.Add("iTRACKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TrackSlno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds
    End Function

    Public Function Exam_ExamTpStpMat_Fetch(ByVal Examslno As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "EXAM_EXAMTPSTM_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IEXAMSLNO
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Examslno

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return Ds
    End Function

    Public Function Exam_CmbKey_ExamType_Fetch(ByVal CmbKey As Integer) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            'ObjConn = New Connection
            'oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAM_EXAMTYPE_CMBKEY_GET"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'ADD IN PARAMETER NAME iEXAMSLNO 
            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CmbKey

            oCommand.Parameters.Add(New OracleParameter("SeqMt", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            RtnVal = oCommand.Parameters("SeqMt").Value

            Return RtnVal

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region " $ Common Get"

#End Region

End Class
