'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating Exam Category
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 11-OCT-2006
'   FINAL BASELINE DATE               : 11-OCT-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsExamCategory

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

#Region "Exam Category"


    Public Function ExamCategory_Fetching(ByVal CourseSlno As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter
            oCommand.CommandText = "TEXAMCATEGORYMT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            '
            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

            Return ds

        Catch ex As Exception
            Throw ex
        Finally
            oConn.Close()
        End Try

    End Function


    Public Function ExamCategory_Save(ByVal ValuesDset As DataSet) As String
        Dim rtnString As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            ''rtnString = ExamCategory_Insert(ValuesDset, oConn, oTrans)
            rtnString = ExamCategory_Insert(ValuesDset, oConn, oTrans)

            oTrans.Commit()

            rtnString = "Records Saved With " & rtnString

            Return rtnString

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            oConn.Close()
        End Try

        Return rtnString

    End Function

    Private Function ExamCategory_Insert(ByVal ValuesDset As DataSet, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            Dim EXAMCATENAME As String
            Dim uCommand As New OracleCommand
            oCommand = New OracleClient.OracleCommand


            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "TEXAMCATEGORYMT_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            uCommand.CommandText = "SP_CTEXAMUPDATE"
            uCommand.Connection = pConn
            uCommand.CommandType = CommandType.StoredProcedure
            uCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = ValuesDset.Tables(0).Rows(0)("ExamCatName").ToString
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER NAME iEXAMCATENAME
            oParameter = oCommand.Parameters.Add("iEXAMCATENAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = ValuesDset.Tables(0).Rows(0)("ExamCatName").ToString
            oParameter.SourceColumn = "ExamCatName"

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = Val(ValuesDset.Tables(0).Rows(0)("Course"))
            oParameter.SourceColumn = "Course"

            'ADD IN PARAMETER NAME iPERIODICITY
            oParameter = oCommand.Parameters.Add("iPERIODICITY", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = ValuesDset.Tables(0).Rows(0)("Periodicity").ToString
            oParameter.SourceColumn = "Periodicity"



            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "Description"


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"


            oParameter = oCommand.Parameters.Add("oEXAMCATENAME", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.InsertCommand = oCommand


            'ADD IN PARAMETER NAME iEXAMCATESLNO
            oParameter = uCommand.Parameters.Add("iEXAMCATESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMCATESLNO"

            'ADD IN PARAMETER NAME iEXAMCATENAME
            oParameter = uCommand.Parameters.Add("iEXAMCATENAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ExamCatName"

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = uCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "Course"

            'ADD IN PARAMETER NAME iPERIODICITY
            oParameter = uCommand.Parameters.Add("iPERIODICITY", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "Periodicity"


            'ADD IN PARAMETER NAME iDESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "Description"

            oAdapter.UpdateCommand = uCommand


            oAdapter.Update(ValuesDset, "ExamCatDetails")

            EXAMCATENAME = oCommand.Parameters("oEXAMCATENAME").Value 'OUTPUT USING PROCEDURE

            'iNextCopyNo = oCommand.Parameters("oCOPYNO").Value
            Return EXAMCATENAME
        Catch ex As Exception
            Throw ex ''  EX
        Finally


        End Try

    End Function

    Public Function ExamCategory_Fetch(ByVal ExamCateSlno As Integer, ByVal iCOMACADEMICSLNO As Integer) As Data.DataSet

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "SP_CTEXAMFETCH"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iEXAMCATESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamCateSlno


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ExamCatDetails")

        Catch ex As Exception
            Throw ex
        Finally
            oConn.Close()
        End Try

        Return ds

    End Function


    Public Function ExamCat_Delete(ByVal iEXAMCATESLNO As Integer) As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "SP_EXAMCATEGORY_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSTR
            oParameter = oCommand.Parameters.Add("iEXAMCATESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMCATESLNO

            oCommand.ExecuteNonQuery()

            Return "Record Deleted"

        Catch ex As Exception
            Throw ex

        Catch ex As Exception
            '' Throw ex
            Throw EX
        Finally
            oConn.Close()
        End Try
    End Function
#End Region

End Class
