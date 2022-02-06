'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the ComboBox Filling FOR Reports
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 14-NOV-2006
'   FINAL BASELINE DATE               : 14-NOV-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsRptComboBoxFilling


#Region "Class Variables"
    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private Ds As DataSet
    Private ObjConn As ReportConnection
#End Region

#Region "Common"


    Public Function ServerDate_Fetch() As String
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_SERVERDATE_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)
            Return Ds.Tables(0).Rows(0)(0).ToString

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region "Direct Fill"


    Public Function Branch_Fetch(ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_BRANCH_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

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


    Public Function Country_Fetch(ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_COUNTRY_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

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


    Public Function Course_Fetch(ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_COURSE_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

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

    Public Function PaymentMode_Fetch(ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_PaymentMode_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

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

    Public Function Medium_Fetch(ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_MEDIUM_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

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

    Public Function Group_Fetch(ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_GROUP_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

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

    Public Function Batch_Fetch(ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_BATCH_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

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

    Public Function StudentType_Fetch() As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_STUDENTTYPE_SELECT_SLNO_NAME"
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

    Public Function ReceiptAdvice_Fetch() As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_PAYADVICE_SELECT_SLNO_NAME"
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

    Public Function PaymentAdvice_Fetch() As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_PAYRECIPT_SELECT_SLNO_NAME"
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


    Public Function Concession_Fetch() As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_CONCESSION_SELECT_SLNO_NAME"
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

    Public Function Deduction_Fetch() As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_DEDUCTION_SELECT_SLNO_NAME"
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

    Public Function BAYCCourseAll_Fetch() As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_BAYCALL_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)

            Return Ds

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function SUBJECT_Fetch(ByVal PStatus As String) As Data.DataSet
        Try
            'oCommand = New OracleClient.OracleCommand
            'oParameter = New OracleClient.OracleParameter

            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "T_SUBJECT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iStatus  'Either A-active
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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

    Public Function PVCOURSE_Fetch(ByVal PStatus As String) As Data.DataSet
        Try

            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "T_PVC_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iStatus  'Either A-active
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME Cursor
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


    Public Function GetExamBranches() As DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "EBIdName_SELECT"
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


    Public Function GetCastes() As DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "CASTEIDNAME_SELECT"
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

#End Region

#Region "SubjectMapping"

    Public Function MAPPEDSUBJECTNOT_Fetch(ByVal PSubjectslno As Integer) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "T_MAPSUBJECT_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iStatus  'Either A-active
            oParameter = oCommand.Parameters.Add("iSubjectslno", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSubjectslno

            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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

    Public Function MAPSUBJECT_Fetch() As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "T_MAPSUBJECT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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

    Public Function GetMappingSubjects() As DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "SUBJECTNAME_SELECT"
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

    Public Function GetSubjects(ByVal isubjectslno As Integer) As DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "SUBJECTMAPNAME_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME isubjectslno
            oParameter = oCommand.Parameters.Add("isubjectslno", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = isubjectslno

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
#End Region

#Region "First Degree"

    Public Function State_Fetch(ByVal PCOUNTRYSLNO As Integer, ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_State_SELECT_For_Country"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCOUNTRYSLNO
            oParameter = oCommand.Parameters.Add("iCOUNTRYSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOUNTRYSLNO

            'ADD IN PARAMETER NAME iStatus
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME DataCur
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

    Public Function District_Fetch(ByVal PStateSLNO As Integer, ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_District_SELECT_For_State"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iStateSLNO
            oParameter = oCommand.Parameters.Add("iStateSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStateSLNO

            'ADD IN PARAMETER NAME iStatus
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME DataCur
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

    Public Function Place_Fetch(ByVal PDistrictSLNO As Integer, ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_Place_SELECT_For_District"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDistrictSLNO
            oParameter = oCommand.Parameters.Add("iDistrictSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PDistrictSLNO

            'ADD IN PARAMETER NAME iStatus
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME DataCur
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

    Public Function BranchWiseCourse_Fetch(ByVal PBranchSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_BraCouCol_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBranchSLNO
            oParameter = oCommand.Parameters.Add("iBranchSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBranchSLNO

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

    Public Function EXAMBranchWiseCourse_Fetch(ByVal eBranchSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "P_EBWISECOURSE_FILL"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBranchSLNO
            oParameter = oCommand.Parameters.Add("iEBRANCHSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = eBranchSLNO

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

    Public Function CourseWiseBranch_Fetch(ByVal PCourseSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_CourseBra_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBranchSLNO
            oParameter = oCommand.Parameters.Add("iCourseSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCourseSLNO

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

    Public Function CourseWiseGroup_Fetch(ByVal PCourseSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_CouGroup_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCourseSLNO
            oParameter = oCommand.Parameters.Add("iCourseSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCourseSLNO

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

    Public Function GroupWiseSubjects_Fetch(ByVal PCOURSESLNO As Integer) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = " M_Gr_subj_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCourseSLNO
            'oParameter = oCommand.Parameters.Add("iGroupSLNO", OracleType.Number, 4)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = PGroupSLNO

            'ADD IN PARAMETER NAME iCourseSLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOURSESLNO

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

    Public Function BranchWiseMedium_Fetch(ByVal PBranchSLNO As Integer, ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_BRAMEDIUM_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBranchSLNO
            oParameter = oCommand.Parameters.Add("iBranchSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBranchSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

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


    Public Function EXAMBranchWiseMedium_Fetch(ByVal eBranchSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "P_EBWISEMEDIUM_FILL"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBranchSLNO
            oParameter = oCommand.Parameters.Add("iEBranchSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = eBranchSLNO


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


    Public Function Company_Fetch(ByVal PCOMPANYSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_COMPANY_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCOMPANYSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOMPANYSLNO

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

    Public Function Zone_Fetch(ByVal PStatus As String, ByVal PZONESLNO As Integer) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_ZONE_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iZONESLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PZONESLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

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

    Public Function Region_Fetch(ByVal PStatus As String, ByVal PREGIONSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_REGION_SELECT_SLNO_NAME "
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iREGIONSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PREGIONSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

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

    Public Function BAY_Fetch(ByVal PBRANCHSLNo As Integer, ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = " M_BAY_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCOUNTRYSLNO
            oParameter = oCommand.Parameters.Add("iBRANCHSLNo", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANCHSLNo

            'ADD IN PARAMETER NAME iStatus
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME DataCur
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

    Public Function AcademicYear_Fetch(ByVal PCourseSLNo As Integer, ByVal PBranchSLNo As Integer, ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_CouAYear_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCourseSLNO
            oParameter = oCommand.Parameters.Add("iCourseSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCourseSLNo

            'ADD IN PARAMETER NAME iBranchSLNO
            oParameter = oCommand.Parameters.Add("iBranchSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBranchSLNo

            'ADD IN PARAMETER NAME DataCur
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

    Public Function BAYC_Fetch(ByVal PBRANCHCOURSESLNo As Integer, ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_BAYC_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCOUNTRYSLNO
            oParameter = oCommand.Parameters.Add("iBAYEARCOURSESLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANCHCOURSESLNo

            'ADD IN PARAMETER NAME iStatus
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME DataCur
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

    Public Function BAYCourse_Fetch(ByVal PBAYEARSLNo As Integer, ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = " M_BAYCourse_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBAYEARSLNo
            oParameter = oCommand.Parameters.Add("iBAYEARSLNo", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBAYEARSLNo

            'ADD IN PARAMETER NAME iStatus
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME DataCur
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

    Public Function BAYCCourse_Fetch(ByVal PBAYEARCOURSESLNO As Integer, ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = " M_BAYCCourse_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBAYEARSLNo
            oParameter = oCommand.Parameters.Add("iBAYEARCOURSESLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBAYEARCOURSESLNO

            'ADD IN PARAMETER NAME iStatus
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME DataCur
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

    Public Function GROUPSSS_Fetch(ByVal PCOURSESLNo As Integer, ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = " M_BAY_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCOUNTRYSLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNo", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOURSESLNo

            'ADD IN PARAMETER NAME iStatus
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME DataCur
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

    Public Function course_group_Fetch(ByVal PCOURSESLNO As Integer, ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_BAYC_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCOUNTRYSLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCOURSESLNO

            'ADD IN PARAMETER NAME iStatus
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME DataCur
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

    Public Function course_FetchBySLNo(ByVal pCGSSLNO As Integer, ByVal PStatus As String) As Data.DataSet
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand.CommandText = "M_COURSE_SELECT_CYSLNO"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME PLACE SLNO
            oParameter = oCommand.Parameters.Add("iCGSSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCGSSLNO

            'ADD IN PARAMETER NAME iStatus  'Either A-active
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME CURSOR
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

    Public Function GSUBJECT_Fetch(ByVal PGroupSLNo As Integer, ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "  M_GSUBJECT_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBAYEARSLNo
            oParameter = oCommand.Parameters.Add("iGroupSLNo", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PGroupSLNo

            'ADD IN PARAMETER NAME iStatus
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            'ADD IN PARAMETER NAME DataCur
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

    Public Function ExamBranch_Wise_Hostel_Fetch(ByVal EXAMBRANCHSLNO As Long) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_EAXMBRAWISEHOSTEL_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMBRANCHSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)
            Return Ds
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region "Second Degree"

    Public Function CourseGroupWiseBatch_Fetch(ByVal PCourseSLNO As Integer, ByVal PGroupSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_COUGRBATCH_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCourseSLNO
            oParameter = oCommand.Parameters.Add("iCourseSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCourseSLNO

            'ADD IN PARAMETER NAME iGroupSLNO
            oParameter = oCommand.Parameters.Add("iGroupSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PGroupSLNO

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

    Public Function Course_GroupWisesSubject_Fetch(ByVal PCourseSLNO As Integer, ByVal PGroupSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_CGS_SELECT_SLNO_NAME"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCourseSLNO
            oParameter = oCommand.Parameters.Add("iCourseSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCourseSLNO

            'ADD IN PARAMETER NAME iGroupSLNO
            oParameter = oCommand.Parameters.Add("iGroupSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PGroupSLNO

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

    Public Function BranchCourseGroupMediumWiseStudentType_Fetch(ByVal PBRANCHSLNo As Long, ByVal PCourseSLNO As Integer, ByVal PGroupSLNO As Integer, ByVal PBATCHSLNo As Long, ByVal PMEDIUMSLNO As Long) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_STUTYPE_SELECT_FOR_CFSLNO"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iBRANCHSLNo
            oParameter = oCommand.Parameters.Add("iBRANCHSLNo", OracleType.Number, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBRANCHSLNo

            'ADD IN PARAMETER NAME iCOURSESLNo
            oParameter = oCommand.Parameters.Add("iCOURSESLNo", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PCourseSLNO

            'ADD IN PARAMETER NAME iGROUPSLNo
            oParameter = oCommand.Parameters.Add("iGROUPSLNo", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PGroupSLNO

            'ADD IN PARAMETER NAME iBATCHSLNo
            oParameter = oCommand.Parameters.Add("iBATCHSLNo", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PBATCHSLNo

            'ADD IN PARAMETER NAME iMEDIUMSLNO
            oParameter = oCommand.Parameters.Add("iMEDIUMSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PMEDIUMSLNO

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

#End Region

#Region "ParseSqlString"

    Public Function Parse_Fetch(ByVal pSqlString As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection



            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "PARSE_SQLSTRING"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add IN Parameter to Accept the Sql String
            oParameter = oCommand.Parameters.Add("iSqlString", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSqlString

            'ADD IN PARAMETER NAME CURSOR
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

#End Region

#Region "Blocks"

    Public Function GetBlocks(ByVal iEXAMBRANCHSLNO As Integer, ByVal iBRANHOSTELSLNO As Integer) As DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "P_EBHBLOCKS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBRANHOSTELSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)
            Return Ds
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try


    End Function

    Public Function GetRooms(ByVal iEXAMBRANCHSLNO As Integer, ByVal iBRANHOSTELSLNO As Integer, ByVal iHOSBLOCKSLNO As Long) As DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "P_EBHBLOCKSROOM_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            oParameter = oCommand.Parameters.Add("iBRANHOSTELSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBRANHOSTELSLNO

            oParameter = oCommand.Parameters.Add("iHOSBLOCKSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iHOSBLOCKSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)
            Return Ds
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try


    End Function


    Public Function Employee_Fetch(ByVal PStatus As String) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_EMP_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

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

    Public Function Employee_Fetching(ByVal iExamBranchSlno As Integer) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "M_EMP_FETCHING"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iExamBranchSlno

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

#End Region

#Region "USER WISE FILL"


    Public Function EBUW_Fill(ByVal iBranchSlno As Integer, ByVal iCourseSlno As Integer, ByVal USERSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "P_EXAMBRANCH_FETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBranchSlno

            'ADD IN PARAMETER NAME COURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCourseSlno

            'ADD IN PARAMETER NAME USERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = USERSLNO


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'ADD IN PARAMETER NAME DATACUR
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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


    Public Function USERWISEEB(ByVal USERSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As Data.DataSet
        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "USERWISEEB"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME USERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = USERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'ADD IN PARAMETER NAME DATACUR
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
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

    Public Function UserWiseBranch_Fetch(ByVal iUSERSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet

        Try
            ObjConn = New ReportConnection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oAdapter = New OracleDataAdapter
            Ds = New DataSet
            oCommand.CommandText = "M_EXAMUSERWISEBRANCH_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iUSERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds)
            Return Ds

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function
#End Region

End Class
