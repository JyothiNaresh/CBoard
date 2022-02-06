Imports System.Data.OracleClient
Imports System.Configuration
Public Class ClsCourseWiseExams
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

#Region "Methods"
    Public Function CourseExam_Delete(ByVal iCODE As Integer) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "COURSEEXAMNAME_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iTopicSLNo
            oParameter = oCommand.Parameters.Add("iCODE", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCODE

            oCommand.ExecuteNonQuery()
            strReturn = "Record Deleted"
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return strReturn

    End Function

    Public Function CourseExam_Insert(ByVal iCOURSESLNO As Integer, ByVal iEXAMSLNO As Integer, ByVal iSTATUS As Integer, ByVal iDESCRIPTION As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "COURSEEXAMNAME_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOURSESLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMSLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSTATUS

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDISCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDESCRIPTION

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

    Public Function CourseExam_Update(ByVal iCODE As Integer, ByVal iCOURSESLNO As Integer, ByVal iEXAMSLNO As Integer, ByVal iSTATUS As Integer, ByVal iDESCRIPTION As String) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "COURSEEXAMNAME_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iCODE", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCODE


            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOURSESLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iEXAMSLNO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMSLNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSTATUS

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDISCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDESCRIPTION

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
End Class
