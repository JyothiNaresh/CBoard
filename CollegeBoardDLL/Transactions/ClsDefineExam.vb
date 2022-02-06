'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating Exams
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 14-AUG-2006
'   FINAL BASELINE DATE               : 14-AUG-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsDefineExam

#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As New OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ds As Data.DataSet
    Private oTrans As OracleTransaction
    Private Result As String
    Private ObjConn As Connection

#End Region

#Region "Define Exam"


    Public Function ExamName_Select() As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = "M_EXAMNAME_SELECT"
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


    Public Function ExamCateSets_Select(ByVal EXAMCATESLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = "SETSLNONAME_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iEXAMCATESLNO 
            oParameter = oCommand.Parameters.Add("iEXAMCATESLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMCATESLNO

            'ADD IN PARAMETER iEXAMCATESLNO 
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO


            'ADD IN PARAMETER iCOMACADEMICSLNO 
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO




            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function QuesPaperType_Select(ByVal EXAMCATESLNO As Integer, ByVal SetSlno As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = "QUESPTSLNONAME_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iEXAMCATESLNO 
            oParameter = oCommand.Parameters.Add("iEXAMCATESLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMCATESLNO

            'ADD IN PARAMETER iSETSLNO 
            oParameter = oCommand.Parameters.Add("iSETSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SetSlno

            'ADD IN PARAMETER iEXAMBRANCHSLNO 
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'ADD IN PARAMETER iCOMACADEMICSLNO 
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO



            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function GetExamDetails(ByVal DEXAMSLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = "DEFINEEXAM_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iDEXAMSLNO 
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DEXAMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ExamDetails")
            Return ds
        Catch ex As Exception

        End Try
    End Function


    Public Function DefineExam_Save(ByVal SetEntries As DataSet) As String
        Dim rtnString As String

        Try
            Dim setResult As String
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            'Sets Inserting
            rtnString = DefineExam_Insert(SetEntries, oConn, oTrans)




            oTrans.Commit()
            'rtnString() '= "Record Saved"


        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

    Private Function DefineExam_Insert(ByVal SetEntries As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            Dim uCommand As New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "DEFINEEXAM_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            uCommand.CommandText = "DEFINEEXAM_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure
            uCommand.Transaction = pTrans



            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMNAME"

            'ADD IN PARAMETER NAME iEXAMDATE
            oParameter = oCommand.Parameters.Add("iEXAMDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMDATE"

            'ADD IN PARAMETER NAME iEXAMCATESLNO
            oParameter = oCommand.Parameters.Add("iEXAMCATESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMCATESLNO"

            'ADD IN PARAMETER NAME iMTSETSLNO
            oParameter = oCommand.Parameters.Add("iMTSETSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MTSETSLNO"

            'ADD IN PARAMETER NAME iQPTMTSLNO
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            'ADD IN PARAMETER NAME iMRKENTRYLEVEL
            oParameter = oCommand.Parameters.Add("iMRKENTRYLEVEL", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MRKENTRYLEVEL"

            'ADD IN PARAMETER NAME iEXAMTYPE
            oParameter = oCommand.Parameters.Add("iEXAMTYPE", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPE"


            'ADD IN PARAMETER NAME  iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"


            'ADD IN PARAMETER NAME  iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iPAPERSETTEREBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PAPERSETTEREBSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPE
            oParameter = oCommand.Parameters.Add("iEXAMTYPEDTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPEDTSLNO"


            'ADD IN PARAMETER NAME iEXAMTYPE
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "USERSLNO"


            'ADD IN PARAMETER NAME oEXAMNAME
            oParameter = oCommand.Parameters.Add("oEXAMNAME", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.InsertCommand = oCommand



            'ADD IN PARAMETER NAME DEXAMSLNO
            oParameter = uCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = uCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMNAME"

            'ADD IN PARAMETER NAME iEXAMDATE
            oParameter = uCommand.Parameters.Add("iEXAMDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMDATE"

            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            'ADD IN PARAMETER NAME iMRKENTRYLEVEL
            oParameter = uCommand.Parameters.Add("iMRKENTRYLEVEL", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MRKENTRYLEVEL"

            'ADD IN PARAMETER NAME iMRKENTRYLEVEL
            oParameter = uCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "USERSLNO"

            oAdapter.UpdateCommand = uCommand


            oAdapter.Update(SetEntries, "ExamDetails")

            Result = "Record Saved With " & oCommand.Parameters("oEXAMNAME").Value

        Catch ex As Exception
            Throw ex
        End Try
        Return Result

    End Function

    Public Function Examtype_Fetch() As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            Ds = New Data.DataSet

            oCommand.CommandText = "WEB_EXAMTYPE_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

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

#Region "CDefine Exam"


    Public Function CExamName_Select() As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = "M_EXAMNAME_SELECT"
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

    Public Function CExamCateSets_Select(ByVal EXAMCATESLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = "SETSLNONAME_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iEXAMCATESLNO 
            oParameter = oCommand.Parameters.Add("iEXAMCATESLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMCATESLNO

            'ADD IN PARAMETER iEXAMCATESLNO 
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO


            'ADD IN PARAMETER iCOMACADEMICSLNO 
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO




            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function CQuesPaperType_Select(ByVal EXAMCATESLNO As Integer, ByVal SetSlno As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = "QUESPTSLNONAME_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iEXAMCATESLNO 
            oParameter = oCommand.Parameters.Add("iEXAMCATESLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMCATESLNO

            'ADD IN PARAMETER iSETSLNO 
            oParameter = oCommand.Parameters.Add("iSETSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SetSlno

            'ADD IN PARAMETER iEXAMBRANCHSLNO 
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'ADD IN PARAMETER iCOMACADEMICSLNO 
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO



            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function CGetExamDetails(ByVal DEXAMSLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = "CDEFINEEXAM_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iDEXAMSLNO 
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DEXAMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ExamDetails")
            Return ds
        Catch ex As Exception

        End Try
    End Function

    Public Function CGetExamDetails2(ByVal DEXAMSLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = "CDEFINEEXAM_SELECT2"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iDEXAMSLNO 
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DEXAMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ExamDetails")
            Return ds
        Catch ex As Exception

        End Try
    End Function

    Public Function CDefineExam_Save(ByVal SetEntries As DataSet) As String
        Dim rtnString As String

        Try
            Dim setResult As String
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            'Sets Inserting
            rtnString = CDefineExam_Insert(SetEntries, oConn, oTrans)




            oTrans.Commit()
            'rtnString() '= "Record Saved"


        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

    Public Function CDefineExam_Save2(ByVal SetEntries2 As DataSet) As String
        Dim rtnString As String

        Try
            Dim setResult As String
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            'Sets Inserting
            rtnString = CDefineExam_Insert2(SetEntries2, oConn, oTrans)


            oTrans.Commit()
            'rtnString() '= "Record Saved"


        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

    Private Function CDefineExam_Insert(ByVal SetEntries As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            Dim uCommand As New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "CDEFINEEXAM_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            uCommand.CommandText = "CDEFINEEXAM_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure
            uCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMNAME"

            'ADD IN PARAMETER NAME iEXAMDATE
            oParameter = oCommand.Parameters.Add("iEXAMDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMDATE"


            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"


            'ADD IN PARAMETER NAME  iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            'ADD IN PARAMETER NAME oEXAMNAME
            oParameter = oCommand.Parameters.Add("oEXAMNAME", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.InsertCommand = oCommand



            'ADD IN PARAMETER NAME DEXAMSLNO
            oParameter = uCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = uCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMNAME"

            'ADD IN PARAMETER NAME iEXAMDATE
            oParameter = uCommand.Parameters.Add("iEXAMDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMDATE"

            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.UpdateCommand = uCommand


            oAdapter.Update(SetEntries, "ExamDetails")

            Result = "Record Saved With " & oCommand.Parameters("oEXAMNAME").Value

        Catch ex As Exception
            Throw ex
        End Try
        Return Result

    End Function

    Private Function CDefineExam_Insert2(ByVal SetEntries2 As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            Dim uCommand As New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "CDEFINEEXAM_INSERT2"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'uCommand.CommandText = "CDEFINEEXAM_UPDATE2"
            'uCommand.Connection = pConn
            'uCommand.CommandType = CommandType.StoredProcedure
            'uCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME  iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME  iSUBJECTSLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME  iMAXMARKS
            oParameter = oCommand.Parameters.Add("iMAXMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MAXMARKS"

            'ADD IN PARAMETER NAME  iMINIMARKS
            oParameter = oCommand.Parameters.Add("iMINIMARKS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MINIMARKS"

            oAdapter.InsertCommand = oCommand

            oAdapter.Update(SetEntries2, "ExamDetails")

        Catch ex As Exception
            Throw ex
        End Try
        Return Result

    End Function

    Public Function CExamtype_Fetch() As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "WEB_EXAMTYPE_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function
#End Region

#Region "IIT Define Exam "
    Public Function IIT_DefineExam_Save(ByVal SetEntries As DataSet) As String
        Dim rtnString As String

        Try
            Dim setResult As String
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            'Sets Inserting
            rtnString = IIT_DefineExam_Insert(SetEntries, oConn, oTrans)




            oTrans.Commit()
            'rtnString() '= "Record Saved"


        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function
    Private Function IIT_DefineExam_Insert(ByVal SetEntries As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            Dim uCommand As New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "IIT_DEFINEEXAM_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            uCommand.CommandText = "DEFINEEXAM_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure
            uCommand.Transaction = pTrans



            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMNAME"

            'ADD IN PARAMETER NAME iEXAMDATE
            oParameter = oCommand.Parameters.Add("iEXAMDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMDATE"

            'ADD IN PARAMETER NAME iEXAMCATESLNO
            oParameter = oCommand.Parameters.Add("iEXAMCATESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMCATESLNO"

            'ADD IN PARAMETER NAME iMTSETSLNO
            oParameter = oCommand.Parameters.Add("iMTSETSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MTSETSLNO"

            'ADD IN PARAMETER NAME iQPTMTSLNO
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            'ADD IN PARAMETER NAME iMRKENTRYLEVEL
            oParameter = oCommand.Parameters.Add("iMRKENTRYLEVEL", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MRKENTRYLEVEL"

            'ADD IN PARAMETER NAME iEXAMTYPE
            oParameter = oCommand.Parameters.Add("iEXAMTYPE", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPE"

            'ADD IN PARAMETER NAME iEXAMTYPEDTSLNO
            oParameter = oCommand.Parameters.Add("iEXAMTYPEDTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPEDTSLNO"


            'ADD IN PARAMETER NAME  iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"


            'ADD IN PARAMETER NAME  iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iPAPERSETTEREBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PAPERSETTEREBSLNO"

            'ADD IN PARAMETER NAME  iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "USERSLNO"


            'ADD IN PARAMETER NAME oEXAMNAME
            oParameter = oCommand.Parameters.Add("oEXAMNAME", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.InsertCommand = oCommand



            'ADD IN PARAMETER NAME DEXAMSLNO
            oParameter = uCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = uCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMNAME"

            'ADD IN PARAMETER NAME iEXAMDATE
            oParameter = uCommand.Parameters.Add("iEXAMDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMDATE"

            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            'ADD IN PARAMETER NAME iMRKENTRYLEVEL
            oParameter = uCommand.Parameters.Add("iMRKENTRYLEVEL", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MRKENTRYLEVEL"

            'ADD IN PARAMETER NAME iMRKENTRYLEVEL
            oParameter = uCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "USERSLNO"

            oAdapter.UpdateCommand = uCommand


            oAdapter.Update(SetEntries, "ExamDetails")

            Result = "Record Saved With " & oCommand.Parameters("oEXAMNAME").Value

        Catch ex As Exception
            Throw ex
        End Try
        Return Result
    End Function
#End Region

#Region "Subject Wise Dates"


    Public Function GetExamsFORDATES(ByVal iCOMBINATIONKEY As String, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = "EXAM_DFINEEXAMS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iCOMBINATIONKEY 
            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMBINATIONKEY


            'ADD IN PARAMETER iCOMACADEMICSLNO 
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO


            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)
            Return ds
        Catch ex As Exception
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function


    Public Function GetsubjectDates(ByVal DsSubjectDates As DataSet, ByVal DEXAMSLNO As Integer, ByVal SpName As String) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = SpName
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iDEXAMSLNO 
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DEXAMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(DsSubjectDates, "SubjectDates")
            Return DsSubjectDates

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function



    Public Function SaveSubjectDates(ByVal DsSubjectDates As DataSet) As String
        Dim rtnString As String
        Try

            Dim uCommand As New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            oCommand.CommandText = "EXAM_SDATES_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            uCommand.CommandText = "EXAM_SDATES_UPDATE"
            uCommand.Connection = oConn
            uCommand.CommandType = CommandType.StoredProcedure
            uCommand.Transaction = oTrans


            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iEXAMDATE
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME iEXAMCATESLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTDATE"

            oAdapter.InsertCommand = oCommand


            'ADD IN PARAMETER NAME iSUBDATESLNO
            oParameter = uCommand.Parameters.Add("iSUBDATESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBDATESLNO"

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = uCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParameter = uCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME iSUBJECTDATE
            oParameter = uCommand.Parameters.Add("iSUBJECTDATE", OracleType.DateTime, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTDATE"

            oAdapter.UpdateCommand = uCommand


            oAdapter.Update(DsSubjectDates, "SubjectDates")

            oTrans.Commit()

            rtnString = "Record Saved"


        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

    Public Function STAFF_SaveSubjectDates(ByVal DsSubjectDates As DataSet) As String
        Dim rtnString As String
        Try

            Dim uCommand As New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            oCommand.CommandText = "STAFF_SDATES_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            uCommand.CommandText = "STAFF_SDATES_UPDATE"
            uCommand.Connection = oConn
            uCommand.CommandType = CommandType.StoredProcedure
            uCommand.Transaction = oTrans


            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iEXAMDATE
            oParameter = oCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME iEXAMCATESLNO
            oParameter = oCommand.Parameters.Add("iSUBJECTDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTDATE"

            oAdapter.InsertCommand = oCommand


            'ADD IN PARAMETER NAME iSUBDATESLNO
            oParameter = uCommand.Parameters.Add("iSUBDATESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBDATESLNO"

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = uCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParameter = uCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME iSUBJECTDATE
            oParameter = uCommand.Parameters.Add("iSUBJECTDATE", OracleType.DateTime, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTDATE"

            oAdapter.UpdateCommand = uCommand


            oAdapter.Update(DsSubjectDates, "SubjectDates")

            oTrans.Commit()

            rtnString = "Record Saved"


        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function
#End Region

#Region "Staff Define Exam "

    Public Function GetStaffExamDetails(ByVal DEXAMSLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = "STAFF_DEFINEEXAM_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iDEXAMSLNO 
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DEXAMSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ExamDetails")
            Return ds
        Catch ex As Exception

        End Try
    End Function

    Public Function Staff_DefineExam_Save(ByVal SetEntries As DataSet, ByVal iCOMBINATIONKEY As Integer) As String
        Dim rtnString As String

        Try
            Dim setResult() As String
            Dim DexamSlno As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()


            'Sets Inserting
            rtnString = Staff_DefineExam_Insert(SetEntries, oConn, oTrans, iCOMBINATIONKEY)

            setResult = rtnString.Split("+")

            DexamSlno = setResult(1)

            Staff_DEDD_Delete(DexamSlno, oConn, oTrans)
            Staff_DEDD_Insert(DexamSlno, SetEntries, Val(SetEntries.Tables("ExamDetails").Rows(0)("COMACADEMICSLNO").ToString), oConn, oTrans)


            rtnString = setResult(0)

            oTrans.Commit()

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

    Private Function Staff_DefineExam_Insert(ByVal SetEntries As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction, ByVal pCOMBINATIONKEY As Integer) As String

        Try

            Dim uCommand As New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "STAFF_DEFINEEXAM_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            uCommand.CommandText = "DEFINEEXAM_UPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure
            uCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMBINATIONKEY


            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMNAME"

            'ADD IN PARAMETER NAME iEXAMDATE
            oParameter = oCommand.Parameters.Add("iEXAMDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMDATE"

            'ADD IN PARAMETER NAME iPERIODICITY
            oParameter = oCommand.Parameters.Add("iPERIODICITY", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PERIODICITY"

            'ADD IN PARAMETER NAME iMTSETSLNO
            oParameter = oCommand.Parameters.Add("iMTSETSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MTSETSLNO"

            'ADD IN PARAMETER NAME iQPTMTSLNO
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            'ADD IN PARAMETER NAME iMRKENTRYLEVEL
            oParameter = oCommand.Parameters.Add("iMRKENTRYLEVEL", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MRKENTRYLEVEL"

            'ADD IN PARAMETER NAME iEXAMTYPE
            oParameter = oCommand.Parameters.Add("iEXAMTYPE", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPE"


            'ADD IN PARAMETER NAME  iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"



            'ADD IN PARAMETER NAME oEXAMNAME
            oParameter = oCommand.Parameters.Add("oEXAMNAME", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.InsertCommand = oCommand



            'ADD IN PARAMETER NAME DEXAMSLNO
            oParameter = uCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = uCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMNAME"

            'ADD IN PARAMETER NAME iEXAMDATE
            oParameter = uCommand.Parameters.Add("iEXAMDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMDATE"

            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            'ADD IN PARAMETER NAME iMRKENTRYLEVEL
            oParameter = uCommand.Parameters.Add("iMRKENTRYLEVEL", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MRKENTRYLEVEL"

            oAdapter.UpdateCommand = uCommand


            oAdapter.Update(SetEntries, "ExamDetails")

            Result = "Record Saved With " & oCommand.Parameters("oEXAMNAME").Value

        Catch ex As Exception
            Throw ex
        End Try
        Return Result

    End Function

    Private Function Staff_DEDD_Insert(ByVal IDexamSlno As Integer, ByVal SetEntries As DataSet, ByVal iCOMACADEMICSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            Dim uCommand As New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "STAFF_DEDD_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = IDexamSlno

            'ADD IN PARAMETER NAME iDEPARTMENTSLNO
            oParameter = oCommand.Parameters.Add("iDEPARTMENTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEPARTMENTSLNO"

            'ADD IN PARAMETER NAME iDESIGNATIONSLNO
            oParameter = oCommand.Parameters.Add("iDESIGNATIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESIGNATIONSLNO"

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            oAdapter.InsertCommand = oCommand

            oAdapter.Update(SetEntries, "ExamDepDesg")

        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Private Function Staff_DEDD_Insert(ByVal IDexamSlno As Integer, ByVal iCOMACADEMICSLNO As Integer, ByVal iCOMBINATIONKEY As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            Dim uCommand As New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "STAFF_EXAMEMP_SELECTNEW"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = IDexamSlno

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'ADD IN PARAMETER NAME iCOBINATIONKEY
            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMBINATIONKEY

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Catch OEX As OracleException
            Throw OEX
        End Try


    End Function

    Private Function Staff_DEDD_Delete(ByVal IDexamSlno As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            Dim uCommand As New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "STAFF_DEDD_DELETE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = IDexamSlno

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function SetStaffForTailor(ByVal SpName As String, ByVal Dset As DataSet, ByVal DTable As String, ByVal iDEXAMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal iCOURSESLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            'ds = New Data.DataSet("Students")

            oCommand.CommandText = SpName '"P_SETSTUDENTS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDEXAMSLNO


            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO 
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOURSESLNO

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

    Public Function StaffExamName_Select() As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = "STAFF_EXAMNAME_SELECT"
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

    Public Function Staff_DefineExam_SaveDesc(ByVal SetEntries As DataSet, ByVal iCOMBINATIONKEY As Integer) As String
        Dim rtnString As String

        Try
            Dim setResult() As String
            Dim DexamSlno As Integer
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()


            'Sets Inserting
            rtnString = Staff_DefineExam_InsertDesc(SetEntries, oConn, oTrans, iCOMBINATIONKEY)

            setResult = rtnString.Split("+")

            DexamSlno = setResult(1)

            Staff_DEDD_Delete(DexamSlno, oConn, oTrans)
            Staff_DEDD_Insert(DexamSlno, SetEntries, Val(SetEntries.Tables("ExamDetails").Rows(0)("COMACADEMICSLNO").ToString), oConn, oTrans)


            rtnString = setResult(0)

            oTrans.Commit()

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

    Private Function Staff_DefineExam_InsertDesc(ByVal SetEntries As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction, ByVal pCOMBINATIONKEY As Integer) As String
        Try

            Dim uCommand As New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter


            oCommand.CommandText = "STAFF_DEFINEEXAM_INSERTDESC"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            uCommand.CommandText = "DEFINEEXAM_UPDATEDESC"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure
            uCommand.Transaction = pTrans


            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMBINATIONKEY

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = oCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMNAME"

            'ADD IN PARAMETER NAME iEXAMDATE
            oParameter = oCommand.Parameters.Add("iEXAMDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMDATE"

            'ADD IN PARAMETER NAME iPERIODICITY
            oParameter = oCommand.Parameters.Add("iPERIODICITY", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PERIODICITY"

            'ADD IN PARAMETER NAME iMTSETSLNO
            oParameter = oCommand.Parameters.Add("iMTSETSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MTSETSLNO"

            'ADD IN PARAMETER NAME iQPTMTSLNO
            oParameter = oCommand.Parameters.Add("iQPTMTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QPTMTSLNO"


            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            'ADD IN PARAMETER NAME iMRKENTRYLEVEL
            oParameter = oCommand.Parameters.Add("iMRKENTRYLEVEL", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MRKENTRYLEVEL"

            'ADD IN PARAMETER NAME iEXAMTYPE
            oParameter = oCommand.Parameters.Add("iEXAMTYPE", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMTYPE"


            'ADD IN PARAMETER NAME  iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"



            'ADD IN PARAMETER NAME oEXAMNAME
            oParameter = oCommand.Parameters.Add("oEXAMNAME", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.InsertCommand = oCommand



            'ADD IN PARAMETER NAME DEXAMSLNO
            oParameter = uCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iEXAMNAME
            oParameter = uCommand.Parameters.Add("iEXAMNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMNAME"

            'ADD IN PARAMETER NAME iEXAMDATE
            oParameter = uCommand.Parameters.Add("iEXAMDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMDATE"

            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            'ADD IN PARAMETER NAME iMRKENTRYLEVEL
            oParameter = uCommand.Parameters.Add("iMRKENTRYLEVEL", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MRKENTRYLEVEL"

            oAdapter.UpdateCommand = uCommand


            oAdapter.Update(SetEntries, "ExamDetails")

            Result = "Record Saved With " & oCommand.Parameters("oEXAMNAME").Value

        Catch ex As Exception
            Throw ex
        End Try
        Return Result

    End Function

#End Region


#Region " Exam Subject Wise Topics "

    Public Function GetsubjectTopics(ByVal Ds As DataSet, ByVal SpName As String) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = SpName
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.Text

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds, "SubjectTopics")
            Return Ds

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function



    Public Function SaveSubjectTopics(ByVal DsSubjectTopics As DataSet) As String
        Dim rtnString As String
        Try

            Dim uCommand As New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()


            uCommand.CommandText = "EXAM_ESTOPICS_UPDATE"
            uCommand.Connection = oConn
            uCommand.CommandType = CommandType.StoredProcedure
            uCommand.Transaction = oTrans



            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = uCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iSUBJECTSLNO
            oParameter = uCommand.Parameters.Add("iSUBJECTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBJECTSLNO"

            'ADD IN PARAMETER NAME iQUESTIONNO
            oParameter = uCommand.Parameters.Add("iQUESTIONNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "QUESTIONNO"


            'ADD IN PARAMETER NAME iTOPICSLNO
            oParameter = uCommand.Parameters.Add("iTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "TOPICSLNO"

            'ADD IN PARAMETER NAME iUPDATETABLE
            oParameter = uCommand.Parameters.Add("iUPDATETABLE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "UPDATETABLE"


            'ADD IN PARAMETER NAME iSUBTOPICSLNO
            oParameter = uCommand.Parameters.Add("iSUBTOPICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBTOPICSLNO"


            oAdapter.UpdateCommand = uCommand


            oAdapter.Update(DsSubjectTopics, "SubjectTopics")

            oTrans.Commit()

            rtnString = "Record Saved"


        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

#End Region

#Region " IIT Parent Questions Marks "

    Public Function GetIITParentQuestionMrks(ByVal Ds As DataSet, ByVal DEXAMSLNO As Integer, ByVal iPARENTNO As Integer, ByVal SpName As String) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oCommand = New OracleCommand
            oCommand.CommandText = SpName
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iDEXAMSLNO 
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DEXAMSLNO

            'ADD IN PARAMETER iDEXAMSLNO 
            oParameter = oCommand.Parameters.Add("iPARENTNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iPARENTNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(Ds, "ParentMarks")
            Return Ds

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function SaveSIITParentQuestionMrks(ByVal Ds As DataSet) As String
        Dim rtnString As String
        Try

            Dim uCommand As New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            oCommand.CommandText = "EXAM_IITPARENT_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            uCommand.CommandText = "EXAM_IITPARENT_UPDATE"
            uCommand.Connection = oConn
            uCommand.CommandType = CommandType.StoredProcedure
            uCommand.Transaction = oTrans


            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iPARENTNO
            oParameter = oCommand.Parameters.Add("iPARENTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PARENTNO"

            'ADD IN PARAMETER NAME iSLNO
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLNO"

            'ADD IN PARAMETER NAME iMARKS
            oParameter = oCommand.Parameters.Add("iMARKS", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MARKS"

            oAdapter.InsertCommand = oCommand


            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = uCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iPARENTNO
            oParameter = uCommand.Parameters.Add("iPARENTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PARENTNO"

            'ADD IN PARAMETER NAME iSLNO
            oParameter = uCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLNO"

            'ADD IN PARAMETER NAME iMARKS
            oParameter = uCommand.Parameters.Add("iMARKS", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MARKS"


            oAdapter.UpdateCommand = uCommand


            oAdapter.Update(Ds, "ParentMarks")

            oTrans.Commit()

            rtnString = "Record Saved"


        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

#End Region

#Region "Parent Marks Entry Venu"
    Public Function SaveVIITParentQuestionMrks(ByVal Ds As DataSet) As String
        Dim rtnString As String
        Try

            Dim uCommand As New OracleClient.OracleCommand
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            oCommand.CommandText = "EXAM_IITPARENT_INSERT_NEW"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DEXAMSLNO"

            'ADD IN PARAMETER NAME iPARENTNO
            oParameter = oCommand.Parameters.Add("iPARENTNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "PARENTNO"

            'ADD IN PARAMETER NAME iSLNO
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SLNO"

            'ADD IN PARAMETER NAME iMARKS
            oParameter = oCommand.Parameters.Add("iMARKS", OracleType.Double)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MARKS"

            oAdapter.InsertCommand = oCommand



            oAdapter.Update(Ds, "ParentMarks")

            oTrans.Commit()

            rtnString = "Record Saved"


        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

#End Region

End Class
