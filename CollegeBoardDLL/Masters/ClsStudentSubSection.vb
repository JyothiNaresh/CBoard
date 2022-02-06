'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : Class file for Student Sub Section Details
'   AUTHOR                            : Prakash
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsStudentSubSection
#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As New OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private OraTrans As OracleTransaction
    Dim ds As Data.DataSet
    Dim ObjConn As Connection
    

#End Region

#Region "Details mode Search Criterias"
    Public Function studentsubSectionDetail_Search(ByVal str As String) As DataSet
        Try
            Dim strSplit As Array
            Dim adap As New OracleDataAdapter
            Dim Cmd As New OracleClient.OracleCommand
            ds = New DataSet


            Dim AdmBranchSlno As Integer
            Dim CourseSlno As Integer
            Dim GroupSlno As Integer
            Dim BatchSlno As Integer
            Dim MediumSlno As Integer
            Dim StuTypeSlno As Integer
            Dim Gender As String
            Dim ExamBranchSlno As Integer
            Dim SectionSlno As Integer
            Dim UserSlno As Integer
            Dim COMACADEMICSLNO As Integer
            Dim Subsectionslno As Integer


            strSplit = str.Split("~")


            CourseSlno = strSplit(0)
            GroupSlno = strSplit(1)
            BatchSlno = strSplit(2)
            MediumSlno = strSplit(3)
            StuTypeSlno = strSplit(4)
            Gender = strSplit(5)
            ExamBranchSlno = strSplit(6)
            SectionSlno = strSplit(7)
            UserSlno = strSplit(8)
            COMACADEMICSLNO = strSplit(9)
            Subsectionslno = strSplit(10)

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            Cmd.CommandText = "EXAM_STUSUBSECTIONSEARCH"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME AS iCOURSESLNO
            oParameter = Cmd.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            'ADD IN PARAMETER NAME AS COURSESLNO
            oParameter = Cmd.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            'ADD IN PARAMETER NAME AS GROUPSLNO
            oParameter = Cmd.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MediumSlno

            'ADD IN PARAMETER NAME AS BATCHSLNO
            oParameter = Cmd.Parameters.Add("iSTUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StuTypeSlno

            'ADD IN PARAMETER NAME AS STUDENTTYPESLNO
            oParameter = Cmd.Parameters.Add("iGENDER", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Gender

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno

            'ADD IN PARAMETER NAME AS SECTIONSLNO
            oParameter = Cmd.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SectionSlno

            'ADD IN PARAMETER NAME AS userslno
            oParameter = Cmd.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = UserSlno

            'ADD IN PARAMETER NAME AS COMACADEMICSLNO
            oParameter = Cmd.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            'ADD IN PARAMETER NAME AS subsectionslno
            oParameter = Cmd.Parameters.Add("iSUBSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Subsectionslno

            oParameter = Cmd.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = Cmd
            adap.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function studentsubactivityDetail_Search(ByVal str As String) As DataSet
        Try
            Dim strSplit As Array
            Dim adap As New OracleDataAdapter
            Dim Cmd As New OracleClient.OracleCommand
            ds = New DataSet


            Dim AdmBranchSlno As Integer
            Dim CourseSlno As Integer
            Dim GroupSlno As Integer
            Dim BatchSlno As Integer
            Dim MediumSlno As Integer
            Dim StuTypeSlno As Integer
            Dim Gender As String
            Dim ExamBranchSlno As Integer
            Dim SectionSlno As Integer
            Dim UserSlno As Integer
            Dim COMACADEMICSLNO As Integer
            Dim GRPACTIVITYSLNO As Integer


            strSplit = str.Split("~")


            CourseSlno = strSplit(0)
            GroupSlno = strSplit(1)
            BatchSlno = strSplit(2)
            MediumSlno = strSplit(3)
            StuTypeSlno = strSplit(4)
            Gender = strSplit(5)
            ExamBranchSlno = strSplit(6)
            SectionSlno = strSplit(7)
            UserSlno = strSplit(8)
            COMACADEMICSLNO = strSplit(9)
            GRPACTIVITYSLNO = strSplit(10)

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            Cmd.CommandText = "EXAM_STUSUBACTIVITYSEARCH"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME AS iCOURSESLNO
            oParameter = Cmd.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            'ADD IN PARAMETER NAME AS COURSESLNO
            oParameter = Cmd.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            'ADD IN PARAMETER NAME AS GROUPSLNO
            oParameter = Cmd.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MediumSlno

            'ADD IN PARAMETER NAME AS BATCHSLNO
            oParameter = Cmd.Parameters.Add("iSTUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StuTypeSlno

            'ADD IN PARAMETER NAME AS STUDENTTYPESLNO
            oParameter = Cmd.Parameters.Add("iGENDER", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Gender

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno

            'ADD IN PARAMETER NAME AS SECTIONSLNO
            oParameter = Cmd.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SectionSlno

            'ADD IN PARAMETER NAME AS userslno
            oParameter = Cmd.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = UserSlno

            'ADD IN PARAMETER NAME AS COMACADEMICSLNO
            oParameter = Cmd.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            'ADD IN PARAMETER NAME AS subsectionslno
            oParameter = Cmd.Parameters.Add("iGRPACTIVITYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GRPACTIVITYSLNO

            oParameter = Cmd.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = Cmd
            adap.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

#End Region

#Region "Single mode student subsection edit mode data fetch"
    Public Function StudentSubSection_Code(ByVal iCode As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "P_STUSUBSECTION_FETCH"

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCode

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

    Public Function StudentSubACTIVITY_Code(ByVal iCode As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "P_STUSUBACTIVITY_FETCH"

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCode

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

#Region "single mode fetch"
    Public Function StudentSubSectionSingle_Fetch(ByVal str As String) As DataSet
        Try
            Dim strSplit As Array
            Dim adap As New OracleDataAdapter
            Dim Cmd As New OracleClient.OracleCommand
            ds = New DataSet

            Dim AdmBranchSlno As Integer
            Dim CourseSlno As Integer
            Dim GroupSlno As Integer
            Dim BatchSlno As Integer
            Dim MediumSlno As Integer
            Dim StuTypeSlno As Integer
            Dim Gender As String
            Dim ExamBranchSlno As Integer
            Dim COMACADEMICSLNO As Integer
            Dim Sectionslno As Integer

            strSplit = str.Split("~")

            'AdmBranchSlno = strSplit(0)
            CourseSlno = strSplit(0)
            GroupSlno = strSplit(1)
            BatchSlno = strSplit(2)
            MediumSlno = strSplit(3)
            StuTypeSlno = strSplit(4)
            Gender = strSplit(5)
            ExamBranchSlno = strSplit(6)
            COMACADEMICSLNO = strSplit(7)
            Sectionslno = strSplit(8)


            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            Cmd.CommandText = "EXAM_STUSUBSECTIONFETCH"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME AS STUDENTSLNO
            oParameter = Cmd.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            'ADD IN PARAMETER NAME AS COURSESLNO
            oParameter = Cmd.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            'ADD IN PARAMETER NAME AS GROUPSLNO
            oParameter = Cmd.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MediumSlno

            'ADD IN PARAMETER NAME AS BATCHSLNO
            oParameter = Cmd.Parameters.Add("iSTUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StuTypeSlno

            'ADD IN PARAMETER NAME AS STUDENTTYPESLNO
            oParameter = Cmd.Parameters.Add("iGENDER", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Gender

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno

            'ADD IN PARAMETER NAME AS COMACADEMICSLNO
            oParameter = Cmd.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO


            'ADD IN PARAMETER NAME AS SECTIONSLNO
            oParameter = Cmd.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Sectionslno


            oParameter = Cmd.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = Cmd
            adap.Fill(ds)

        Catch ex As Exception

        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function

    Public Function StudentSubACTIVITYSingle_Fetch(ByVal str As String) As DataSet
        Try
            Dim strSplit As Array
            Dim adap As New OracleDataAdapter
            Dim Cmd As New OracleClient.OracleCommand
            ds = New DataSet

            Dim AdmBranchSlno As Integer
            Dim CourseSlno As Integer
            Dim GroupSlno As Integer
            Dim BatchSlno As Integer
            Dim MediumSlno As Integer
            Dim StuTypeSlno As Integer
            Dim Gender As String
            Dim ExamBranchSlno As Integer
            Dim COMACADEMICSLNO As Integer
            Dim Sectionslno As Integer

            strSplit = str.Split("~")

            'AdmBranchSlno = strSplit(0)
            CourseSlno = strSplit(0)
            GroupSlno = strSplit(1)
            BatchSlno = strSplit(2)
            MediumSlno = strSplit(3)
            StuTypeSlno = strSplit(4)
            Gender = strSplit(5)
            ExamBranchSlno = strSplit(6)
            COMACADEMICSLNO = strSplit(7)
            Sectionslno = strSplit(8)


            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            Cmd.CommandText = "EXAM_STUSUBACTIVITYFETCH"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME AS STUDENTSLNO
            oParameter = Cmd.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            'ADD IN PARAMETER NAME AS COURSESLNO
            oParameter = Cmd.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            'ADD IN PARAMETER NAME AS GROUPSLNO
            oParameter = Cmd.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MediumSlno

            'ADD IN PARAMETER NAME AS BATCHSLNO
            oParameter = Cmd.Parameters.Add("iSTUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StuTypeSlno

            'ADD IN PARAMETER NAME AS STUDENTTYPESLNO
            oParameter = Cmd.Parameters.Add("iGENDER", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Gender

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno

            'ADD IN PARAMETER NAME AS COMACADEMICSLNO
            oParameter = Cmd.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO


            'ADD IN PARAMETER NAME AS SECTIONSLNO
            oParameter = Cmd.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Sectionslno


            oParameter = Cmd.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = Cmd
            adap.Fill(ds)

        Catch ex As Exception

        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function

#End Region

#Region "SINGLE MODE INSERT"
    Public Function StudentSubSectionSingle_Insert(ByVal dsSet As DataSet) As String
        Dim strReturn As String

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter



            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "F_STUDENTSUBSECTION_UPDATE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"


            oParameter = oCommand.Parameters.Add("iSUBSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBSECTIONSLNO"


            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue

            oAdapter.InsertCommand = oCommand

            oAdapter.Update(dsSet, "STUSUBSECTION")

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

            OraTrans.Commit()

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return strReturn

    End Function

    Public Function StudentGRPACTIVITYSingle_Insert(ByVal dsSet As DataSet) As String
        Dim strReturn As String

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter



            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "F_STUDENTGRPACTIVITY_UPDATE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"


            oParameter = oCommand.Parameters.Add("iGRPACTIVITYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GRPACTIVITYSLNO"


            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue

            oAdapter.InsertCommand = oCommand

            oAdapter.Update(dsSet, "STUSUBSECTION")

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

            OraTrans.Commit()

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return strReturn

    End Function
#End Region

#Region "SINGLE MODE UPDATE"
    Public Function StudentSubSectionSingle_Update(ByVal Admslno As Integer, ByVal iStuSubSecSlno As Integer) As String
        Dim strReturn As String

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter



            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "F_STUDENTSUBSECTION_UPDATE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Admslno


            oParameter = oCommand.Parameters.Add("iSUBSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iStuSubSecSlno


            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()
            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

            OraTrans.Commit()

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return strReturn
    End Function

    Public Function StudentGRPACTIVITYSingle_Update(ByVal Admslno As Integer, ByVal iStuSubSecSlno As Integer) As String
        Dim strReturn As String

        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter



            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "F_STUDENTGRPACTIVITY_UPDATE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Admslno


            oParameter = oCommand.Parameters.Add("iGRPACTIVITYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iStuSubSecSlno


            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()
            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

            OraTrans.Commit()

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return strReturn
    End Function
#End Region

#Region "subsection delete for masters"
    Public Function SubSectionMasters_Delete(ByVal iCODE As Integer) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "SUBSECTIONMASTERS_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER iTopicSLNo
            oParameter = oCommand.Parameters.Add("iCODE", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCODE

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

#Region "subsection insert for masters "
    Public Function SubSectionMasters_Insert(ByVal iCHARACTER As String, ByVal iDESCRIPTION As String, ByVal iFROMNO As Integer, ByVal iTONO As Integer) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "SUBSECTIONMASTERS_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iCHARACTER", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCHARACTER

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDESCRIPTION

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iFROMNO", OracleType.Number, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFROMNO

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iTONO", OracleType.Number, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iTONO


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

#Region "STUDENT SECTION BATCH INSERT"
    Public Function StudentSubSectionBatch_Insert(ByVal dsSet As DataSet) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "P_STUSUBSECTION_BATCHINSERT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            oParameter = oCommand.Parameters.Add("iSUBSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBSECTIONSLNO"

            oAdapter.InsertCommand = oCommand
            oAdapter.UpdateCommand = oCommand
            oAdapter.Update(dsSet, "STUSUBSECTION")
            OraTrans.Commit()
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return 1

    End Function

    Public Function StudentGRPACTIVITYBatch_Insert(ByVal dsSet As DataSet) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "P_STUGRPACTIVITY_BATCHINSERT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            oParameter = oCommand.Parameters.Add("iGRPACTIVITYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GRPACTIVITYSLNO"

            oAdapter.InsertCommand = oCommand
            oAdapter.UpdateCommand = oCommand
            oAdapter.Update(dsSet, "STUSUBSECTION")
            OraTrans.Commit()
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return 1

    End Function
#End Region

#Region "DatasetFetch"
    Public Function dataSet_Fetch(ByVal pSqlString As String) As Data.DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            oCommand.CommandText = "PARSE_SQLSTRING"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add IN Parameter to Accept the Sql String
            oParameter = oCommand.Parameters.Add("iSqlString", OracleType.VarChar, 5000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pSqlString

            'ADD IN PARAMETER NAME CURSOR
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "STUSUBSECTION")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


#End Region

    'MASTERS FOR SUBSECTION INCHARGE
#Region "insert for subsection incharge"
    Public Function SubSecInchargeAddress_Insert(ByVal strData As String) As String
        Dim strSplit As Array
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            strSplit = strData.Split("~")

            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "SUBSECTION_INCHARGE_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME FOR EXAMBRANHCSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(strSplit(0))

            'ADD IN PARAMETER NAME FOR NAME
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(1)

            'ADD IN PARAMETER NAME FOR FATHER NAME
            oParameter = oCommand.Parameters.Add("iFATHERNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(2)

            'ADD IN PARAMETER NAME FOR DOB
            oParameter = oCommand.Parameters.Add("iDOB", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(3)

            'ADD IN PARAMETER NAME FOR QUAL
            oParameter = oCommand.Parameters.Add("iQUAL", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(4)

            'ADD IN PARAMETER NAME FOR HNO
            oParameter = oCommand.Parameters.Add("iHNO", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(5)

            'ADD IN PARAMETER NAME FOR STREET
            oParameter = oCommand.Parameters.Add("iSTREET_VILL", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(6)

            'ADD IN PARAMETER NAME FOR COUNTRY
            oParameter = oCommand.Parameters.Add("iCOUNTRYSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(strSplit(7))

            'ADD IN PARAMETER NAME FOR STATE
            oParameter = oCommand.Parameters.Add("iSTATESLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(strSplit(8))

            'ADD IN PARAMETER NAME FOR PIN
            oParameter = oCommand.Parameters.Add("iPIN", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(9)

            'ADD IN PARAMETER NAME FOR PHONERES
            oParameter = oCommand.Parameters.Add("iPHONERES", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(10)

            'ADD IN PARAMETER NAME FOR PHONEOFF
            oParameter = oCommand.Parameters.Add("iPHONEOFF", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(11)

            'ADD IN PARAMETER NAME FOR MOBILE1
            oParameter = oCommand.Parameters.Add("iMOBILE1", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(12)

            'ADD IN PARAMETER NAME FOR MOBILE2
            oParameter = oCommand.Parameters.Add("iMOBILE2", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(13)

            'ADD IN PARAMETER NAME FOR EMAIL
            oParameter = oCommand.Parameters.Add("iEMAIL", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(14)


            oCommand.ExecuteNonQuery()
            SubSecInchargeAddress_Insert = "SUCCESS"
            OraTrans.Commit()
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function
#End Region

#Region "update for subsection incharge"
    Public Function SubSecInchargeAddress_Update(ByVal strData As String) As String
        Dim strSplit As Array
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            strSplit = strData.Split("~")

            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "SUBSECTION_INCHARGE_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME FOR EXAMBRANHCSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(strSplit(0))

            'ADD IN PARAMETER NAME FOR NAME
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(1)

            'ADD IN PARAMETER NAME FOR FATHER NAME
            oParameter = oCommand.Parameters.Add("iFATHERNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(2)

            'ADD IN PARAMETER NAME FOR DOB
            oParameter = oCommand.Parameters.Add("iDOB", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(3)

            'ADD IN PARAMETER NAME FOR QUAL
            oParameter = oCommand.Parameters.Add("iQUAL", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(4)

            'ADD IN PARAMETER NAME FOR HNO
            oParameter = oCommand.Parameters.Add("iHNO", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(5)

            'ADD IN PARAMETER NAME FOR STREET
            oParameter = oCommand.Parameters.Add("iSTREET_VILL", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(6)

            'ADD IN PARAMETER NAME FOR COUNTRY
            oParameter = oCommand.Parameters.Add("iCOUNTRYSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(strSplit(7))

            'ADD IN PARAMETER NAME FOR STATE
            oParameter = oCommand.Parameters.Add("iSTATESLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(strSplit(8))

            'ADD IN PARAMETER NAME FOR PIN
            oParameter = oCommand.Parameters.Add("iPIN", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(9)

            'ADD IN PARAMETER NAME FOR PHONERES
            oParameter = oCommand.Parameters.Add("iPHONERES", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(10)

            'ADD IN PARAMETER NAME FOR PHONEOFF
            oParameter = oCommand.Parameters.Add("iPHONEOFF", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(11)

            'ADD IN PARAMETER NAME FOR MOBILE1
            oParameter = oCommand.Parameters.Add("iMOBILE1", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(12)

            'ADD IN PARAMETER NAME FOR MOBILE2
            oParameter = oCommand.Parameters.Add("iMOBILE2", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(13)

            'ADD IN PARAMETER NAME FOR EMAIL
            oParameter = oCommand.Parameters.Add("iEMAIL", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(14)

            'ADD IN PARAMETER NAME FOR code
            oParameter = oCommand.Parameters.Add("iCODE", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = strSplit(15)


            oCommand.ExecuteNonQuery()
            SubSecInchargeAddress_Update = "SUCCESS"
            OraTrans.Commit()
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function
#End Region

#Region "fetch data for details student subsection incharges"
    Public Function StudentSubSecIncDetails_Select() As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oCommand.CommandText = "STUSUBSECINCH_DETAILS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "SubsectionDetailsDset")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function
#End Region

#Region "DELETE data for details student subsection incharges"
    Public Function StudentSubSecIncDetails_Delete(ByVal CODE As Integer) As String
        Dim rtnString As String

        Try

            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            OraTrans = oConn.BeginTransaction()

            dCommand.Transaction = OraTrans
            dCommand.CommandText = "STUSUBSECINCH_DETAILS_DELETE"
            dCommand.Connection = oConn
            dCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as CODE
            oParameter = dCommand.Parameters.Add("iCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CODE

            dCommand.ExecuteNonQuery()

            OraTrans.Commit()

            rtnString = "Record Deleted"


        Catch EX As Exception
            OraTrans.Rollback()
            Throw EX
        Catch ex As Exception
            OraTrans.Rollback()
            Throw EX
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

#End Region

    'MAPPING PROCEDURES FOR SUBSECTION INCHARGE
#Region "fetch data for details student subsection incharges Mappings"
    Public Function StudentSubSecIncMapDetails_Select() As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oCommand.CommandText = "SUBSECINCH_MAP_DETAILS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "SubsectionDetailsDset")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function
#End Region

#Region "SINGLE MODE INSERT for SUBSECTION INCHARGE MAPPINGS"
    Public Function StuSubSecInchSingleMap_Insert(ByVal dsSet As DataSet) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter



            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "SUBSECINCH_MAP_DETAILS_INSERT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"


            oParameter = oCommand.Parameters.Add("iINCHARGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "INCHARGESLNO"

            oParameter = oCommand.Parameters.Add("iSUBSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBSECTIONSLNO"

            oParameter = oCommand.Parameters.Add("iDESC", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(dsSet, "SUBSECINCH")

            OraTrans.Commit()
            StuSubSecInchSingleMap_Insert = "SUCCESS"
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

#End Region

#Region "SINGLE MODE UPDATE for SUBSECTION INCHARGE MAPPINGS"
    Public Function StuSubSecInchSingleMap_Update(ByVal dsSet As DataSet, ByVal Code As Integer) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter



            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "SUBSECINCH_MAP_DETAILS_UPDATE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"


            oParameter = oCommand.Parameters.Add("iINCHARGESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "INCHARGESLNO"

            oParameter = oCommand.Parameters.Add("iSUBSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBSECTIONSLNO"

            oParameter = oCommand.Parameters.Add("iDESC", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oParameter = oCommand.Parameters.Add("iCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Code

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(dsSet, "SUBSECINCH")

            OraTrans.Commit()
            StuSubSecInchSingleMap_Update = "SUCCESS"
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function
#End Region

#Region "DELETE  details student subsection incharges MAPPINGS"
    Public Function StuSubSecInchSingleMap_DELETE(ByVal CODE As Integer) As String
        Dim rtnString As String

        Try

            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            OraTrans = oConn.BeginTransaction()

            dCommand.Transaction = OraTrans
            dCommand.CommandText = "SUBSECINCH_MAP_DETAILS_DELETE"
            dCommand.Connection = oConn
            dCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as CODE
            oParameter = dCommand.Parameters.Add("iCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CODE

            dCommand.ExecuteNonQuery()

            OraTrans.Commit()

            rtnString = "Record Deleted"


        Catch EX As Exception
            OraTrans.Rollback()
            Throw EX
        Catch ex As Exception
            OraTrans.Rollback()
            Throw EX
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

#End Region

    'MAPPING PROCEDURES FOR SUB BATCH 
#Region "Sub Batch Procedures"

#Region "Details mode Search Criterias"
    Public Function StudentSubBatchDetail_Search(ByVal str As String) As DataSet
        Try
            Dim strSplit As Array
            Dim adap As New OracleDataAdapter
            Dim Cmd As New OracleClient.OracleCommand
            ds = New DataSet


            Dim AdmBranchSlno As Integer
            Dim CourseSlno As Integer
            Dim GroupSlno As Integer
            Dim BatchSlno As Integer
            Dim MediumSlno As Integer
            Dim StuTypeSlno As Integer
            Dim Gender As String
            Dim ExamBranchSlno As Integer
            Dim SectionSlno As Integer
            Dim UserSlno As Integer
            Dim COMACADEMICSLNO As Integer
            Dim SubBatchSlno As Integer


            strSplit = str.Split("~")


            CourseSlno = strSplit(0)
            GroupSlno = strSplit(1)
            BatchSlno = strSplit(2)
            MediumSlno = strSplit(3)
            StuTypeSlno = strSplit(4)
            Gender = strSplit(5)
            ExamBranchSlno = strSplit(6)
            SectionSlno = strSplit(7)
            UserSlno = strSplit(8)
            COMACADEMICSLNO = strSplit(9)
            SubBatchSlno = strSplit(10)

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            Cmd.CommandText = "EXAM_STUSUBBATCHSEARCH"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME AS iCOURSESLNO
            oParameter = Cmd.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            'ADD IN PARAMETER NAME AS COURSESLNO
            oParameter = Cmd.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            'ADD IN PARAMETER NAME AS GROUPSLNO
            oParameter = Cmd.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MediumSlno

            'ADD IN PARAMETER NAME AS BATCHSLNO
            oParameter = Cmd.Parameters.Add("iSTUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StuTypeSlno

            'ADD IN PARAMETER NAME AS STUDENTTYPESLNO
            oParameter = Cmd.Parameters.Add("iGENDER", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Gender

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno

            'ADD IN PARAMETER NAME AS SECTIONSLNO
            oParameter = Cmd.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SectionSlno

            'ADD IN PARAMETER NAME AS userslno
            oParameter = Cmd.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = UserSlno

            'ADD IN PARAMETER NAME AS COMACADEMICSLNO
            oParameter = Cmd.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            'ADD IN PARAMETER NAME AS subbatchslno
            oParameter = Cmd.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SubBatchSlno

            oParameter = Cmd.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = Cmd
            adap.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function
#End Region

#Region "single mode fetch"
    Public Function StudentSubBatchSingle_Fetch(ByVal str As String) As DataSet
        Try
            Dim strSplit As Array
            Dim adap As New OracleDataAdapter
            Dim Cmd As New OracleClient.OracleCommand
            ds = New DataSet


            Dim CourseSlno As Integer
            Dim GroupSlno As Integer
            Dim BatchSlno As Integer
            Dim MediumSlno As Integer
            Dim StuTypeSlno As Integer
            Dim Gender As String
            Dim ExamBranchSlno As Integer
            Dim COMACADEMICSLNO As Integer
            Dim Sectionslno As Integer

            strSplit = str.Split("~")


            CourseSlno = strSplit(0)
            GroupSlno = strSplit(1)
            BatchSlno = strSplit(2)
            MediumSlno = strSplit(3)
            StuTypeSlno = strSplit(4)
            Gender = strSplit(5)
            ExamBranchSlno = strSplit(6)
            COMACADEMICSLNO = strSplit(7)
            Sectionslno = strSplit(8)


            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            Cmd.CommandText = "EXAM_STUSUBBATCHFETCH"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME AS STUDENTSLNO
            oParameter = Cmd.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            'ADD IN PARAMETER NAME AS COURSESLNO
            oParameter = Cmd.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            'ADD IN PARAMETER NAME AS GROUPSLNO
            oParameter = Cmd.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MediumSlno

            'ADD IN PARAMETER NAME AS BATCHSLNO
            oParameter = Cmd.Parameters.Add("iSTUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StuTypeSlno

            'ADD IN PARAMETER NAME AS STUDENTTYPESLNO
            oParameter = Cmd.Parameters.Add("iGENDER", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Gender

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno

            'ADD IN PARAMETER NAME AS COMACADEMICSLNO
            oParameter = Cmd.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO


            'ADD IN PARAMETER NAME AS SECTIONSLNO
            oParameter = Cmd.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Sectionslno


            oParameter = Cmd.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = Cmd
            adap.Fill(ds)

        Catch ex As Exception

        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function
#End Region

#Region "Single mode student SUBBATCH edit mode data fetch"
    Public Function StudentSubBatch_Code(ByVal iCode As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAM_STUSUBBATCH_FETCH"

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCode

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

#Region "single/batch mode insert/update"

    Public Function Exam_Subatch_Save(ByVal Ds1 As DataSet) As String
        Dim rtnString As String
        Dim RtnVal1, RtnVal2 As Integer
        Try
            Dim setResult As String
            Dim Ds2 As DataSet

            Ds2 = Ds1.Copy
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            OraTrans = oConn.BeginTransaction()

            If Not IsNothing(Ds1) AndAlso Ds1.Tables(0).Rows.Count > 0 Then
                RtnVal1 = StudentSubBatchNew_Insert(Ds2)
                RtnVal2 = StudentSubBatch_Update(Ds1)
                If RtnVal1 = 1 AndAlso RtnVal1 = 1 Then
                    OraTrans.Commit()
                Else
                    OraTrans.Rollback()
                    rtnString = "Record Not Saved"
                End If
                rtnString = "Record Saved"
            End If

            Return 1

        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function StudentSubBatch_Update(ByVal dsSet As DataSet) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandText = "EXAM_STUSUBBATCH_UPDATE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBBATCHSLNO"

            oAdapter.InsertCommand = oCommand
            oAdapter.UpdateCommand = oCommand
            oAdapter.Update(dsSet, "STUSUBSECTION")


        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return 1
    End Function

    Public Function StudentSubBatchNew_Insert(ByVal dsSet As DataSet) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter



            oCommand.CommandText = "EXAM_SUBBATCHCHANGE_INSERT"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBBATCHSLNO"

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "USERSLNO"

            oAdapter.InsertCommand = oCommand
            oAdapter.UpdateCommand = oCommand
            oAdapter.Update(dsSet, "STUSUBSECTION")


        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return 1
    End Function

#End Region

#Region "COURSE-GROUP-BATCH-SUBBATCH MAPPING"

    Public Function P_ExamCGBSubbatchMap_Insert(ByVal Arr As ArrayList) As Integer
        Try
            ObjConn = New Connection
            oCommand = New OracleCommand
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "EXAM_CGBSUBBATCHMAP_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            ''----------------------- 1 ------------------------------------

            oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(0)

            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(1)

            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(2)

            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(3)

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arr(4)

            oCommand.ExecuteNonQuery()

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function P_ExamCGBSubbatchMap_Delete(ByVal PSlNo As String, ByVal pCOMACADEMICSLNO As Integer) As String
        Dim strReturn As String
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "EXAM_CGBSUBBATCHMAP_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME as slno
            oParameter = oCommand.Parameters.Add("iSUBBATCHID", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCOMACADEMICSLNO

            oCommand.ExecuteNonQuery()

            strReturn = 1

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function

#End Region

#End Region

#Region "University Procedures"
    'WRITTEN BY Y MAHESH REDDY
#Region "Details mode Search Criterias"
    Public Function StudentUniversityDetail_Search(ByVal str As String) As DataSet
        Try
            Dim strSplit As Array
            Dim adap As New OracleDataAdapter
            Dim Cmd As New OracleClient.OracleCommand
            ds = New DataSet
            Dim AdmBranchSlno As Integer
            Dim CourseSlno As Integer
            Dim GroupSlno As Integer
            Dim BatchSlno As Integer
            Dim MediumSlno As Integer
            Dim StuTypeSlno As Integer
            Dim Gender As String
            Dim ExamBranchSlno As Integer
            Dim SectionSlno As Integer
            Dim UserSlno As Integer
            Dim COMACADEMICSLNO As Integer
            Dim UniversitySlno As Integer


            strSplit = str.Split("~")


            CourseSlno = strSplit(0)
            GroupSlno = strSplit(1)
            BatchSlno = strSplit(2)
            MediumSlno = strSplit(3)
            StuTypeSlno = strSplit(4)
            Gender = strSplit(5)
            ExamBranchSlno = strSplit(6)
            SectionSlno = strSplit(7)
            UserSlno = strSplit(8)
            COMACADEMICSLNO = strSplit(9)
            UniversitySlno = strSplit(10)

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            Cmd.CommandText = "EXAM_STUUNIVERSITYSEARCH"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME AS iCOURSESLNO
            oParameter = Cmd.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            'ADD IN PARAMETER NAME AS COURSESLNO
            oParameter = Cmd.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            'ADD IN PARAMETER NAME AS GROUPSLNO
            oParameter = Cmd.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MediumSlno

            'ADD IN PARAMETER NAME AS BATCHSLNO
            oParameter = Cmd.Parameters.Add("iSTUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StuTypeSlno

            'ADD IN PARAMETER NAME AS STUDENTTYPESLNO
            oParameter = Cmd.Parameters.Add("iGENDER", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Gender

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno

            'ADD IN PARAMETER NAME AS SECTIONSLNO
            oParameter = Cmd.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SectionSlno

            'ADD IN PARAMETER NAME AS userslno
            oParameter = Cmd.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = UserSlno

            'ADD IN PARAMETER NAME AS COMACADEMICSLNO
            oParameter = Cmd.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            'ADD IN PARAMETER NAME AS Universityslno
            oParameter = Cmd.Parameters.Add("iUniversitySLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = UniversitySlno

            oParameter = Cmd.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = Cmd
            adap.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function
#End Region

#Region "single mode fetch"
    Public Function StudentUniversitySingle_Fetch(ByVal str As String) As DataSet
        Try
            Dim strSplit As Array
            Dim adap As New OracleDataAdapter
            Dim Cmd As New OracleClient.OracleCommand
            ds = New DataSet


            Dim CourseSlno As Integer
            Dim GroupSlno As Integer
            Dim BatchSlno As Integer
            Dim MediumSlno As Integer
            Dim StuTypeSlno As Integer
            Dim Gender As String
            Dim ExamBranchSlno As Integer
            Dim COMACADEMICSLNO As Integer
            Dim Sectionslno As Integer

            strSplit = str.Split("~")


            CourseSlno = strSplit(0)
            GroupSlno = strSplit(1)
            BatchSlno = strSplit(2)
            MediumSlno = strSplit(3)
            StuTypeSlno = strSplit(4)
            Gender = strSplit(5)
            ExamBranchSlno = strSplit(6)
            COMACADEMICSLNO = strSplit(7)
            Sectionslno = strSplit(8)


            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            Cmd.CommandText = "EXAM_STUUNIVERSITYFETCH"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME AS STUDENTSLNO
            oParameter = Cmd.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            'ADD IN PARAMETER NAME AS COURSESLNO
            oParameter = Cmd.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            'ADD IN PARAMETER NAME AS GROUPSLNO
            oParameter = Cmd.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MediumSlno

            'ADD IN PARAMETER NAME AS BATCHSLNO
            oParameter = Cmd.Parameters.Add("iSTUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StuTypeSlno

            'ADD IN PARAMETER NAME AS STUDENTTYPESLNO
            oParameter = Cmd.Parameters.Add("iGENDER", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Gender

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno

            'ADD IN PARAMETER NAME AS COMACADEMICSLNO
            oParameter = Cmd.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO


            'ADD IN PARAMETER NAME AS SECTIONSLNO
            oParameter = Cmd.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Sectionslno


            oParameter = Cmd.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = Cmd
            adap.Fill(ds)

        Catch ex As Exception

        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function
#End Region

#Region "Single mode Student UNIVERSITY edit mode data fetch"
    Public Function StudentUniversity_Code(ByVal iCode As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAM_STUUNIVERSITY_FETCH"

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCode

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

#Region "single/batch mode insert/update"
    Public Function StudentUniversity_Update(ByVal dsSet As DataSet) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "EXAM_STUUNIVERSITY_UPDATE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            oParameter = oCommand.Parameters.Add("iUNIVERSITYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "UNIVERSITYSLNO"

            oAdapter.InsertCommand = oCommand
            oAdapter.UpdateCommand = oCommand
            oAdapter.Update(dsSet, "STUSUBSECTION")
            OraTrans.Commit()
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return 1
    End Function
#End Region

#End Region

#Region "Special Batch Procedures"
    'WRITTEN BY Y MAHESH REDDY
#Region "Details mode Search Criterias"
    Public Function StudentSplBatchDetail_Search(ByVal str As String) As DataSet
        Try
            Dim strSplit As Array
            Dim adap As New OracleDataAdapter
            Dim Cmd As New OracleClient.OracleCommand
            ds = New DataSet
            Dim AdmBranchSlno As Integer
            Dim CourseSlno As Integer
            Dim GroupSlno As Integer
            Dim BatchSlno As Integer
            Dim MediumSlno As Integer
            Dim StuTypeSlno As Integer
            Dim Gender As String
            Dim ExamBranchSlno As Integer
            Dim SectionSlno As Integer
            Dim UserSlno As Integer
            Dim COMACADEMICSLNO As Integer
            Dim SplBatchSlno As Integer

            strSplit = str.Split("~")
            CourseSlno = strSplit(0)
            GroupSlno = strSplit(1)
            BatchSlno = strSplit(2)
            MediumSlno = strSplit(3)
            StuTypeSlno = strSplit(4)
            Gender = strSplit(5)
            ExamBranchSlno = strSplit(6)
            UserSlno = strSplit(7)
            COMACADEMICSLNO = strSplit(8)
            SplBatchSlno = strSplit(9)

            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            Cmd.CommandText = "EXAM_STUSPLBATCHSEARCH"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME AS iCOURSESLNO
            oParameter = Cmd.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            'ADD IN PARAMETER NAME AS COURSESLNO
            oParameter = Cmd.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            'ADD IN PARAMETER NAME AS GROUPSLNO
            oParameter = Cmd.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MediumSlno

            'ADD IN PARAMETER NAME AS BATCHSLNO
            oParameter = Cmd.Parameters.Add("iSTUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StuTypeSlno

            'ADD IN PARAMETER NAME AS STUDENTTYPESLNO
            oParameter = Cmd.Parameters.Add("iGENDER", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Gender

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno

            'ADD IN PARAMETER NAME AS userslno
            oParameter = Cmd.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = UserSlno

            'ADD IN PARAMETER NAME AS COMACADEMICSLNO
            oParameter = Cmd.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            'ADD IN PARAMETER NAME AS SplBatchslno
            oParameter = Cmd.Parameters.Add("iSplbatchSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SplBatchSlno

            oParameter = Cmd.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = Cmd
            adap.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function
#End Region

#Region "single mode fetch"
    Public Function StudentSplBatchSingle_Fetch(ByVal str As String) As DataSet
        Try
            Dim strSplit As Array
            Dim adap As New OracleDataAdapter
            Dim Cmd As New OracleClient.OracleCommand
            ds = New DataSet


            Dim CourseSlno As Integer
            Dim GroupSlno As Integer
            Dim BatchSlno As Integer
            Dim MediumSlno As Integer
            Dim StuTypeSlno As Integer
            Dim Gender As String
            Dim ExamBranchSlno As Integer
            Dim COMACADEMICSLNO As Integer
            Dim Sectionslno As Integer

            strSplit = str.Split("~")


            CourseSlno = strSplit(0)
            GroupSlno = strSplit(1)
            BatchSlno = strSplit(2)
            MediumSlno = strSplit(3)
            StuTypeSlno = strSplit(4)
            Gender = strSplit(5)
            ExamBranchSlno = strSplit(6)
            COMACADEMICSLNO = strSplit(7)


            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            Cmd.CommandText = "EXAM_STUSPLBATCHFETCH"
            Cmd.Connection = oConn
            Cmd.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME AS STUDENTSLNO
            oParameter = Cmd.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CourseSlno


            'ADD IN PARAMETER NAME AS BRANCHSLNO
            oParameter = Cmd.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GroupSlno

            'ADD IN PARAMETER NAME AS COURSESLNO
            oParameter = Cmd.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BatchSlno

            'ADD IN PARAMETER NAME AS GROUPSLNO
            oParameter = Cmd.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MediumSlno

            'ADD IN PARAMETER NAME AS BATCHSLNO
            oParameter = Cmd.Parameters.Add("iSTUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = StuTypeSlno

            'ADD IN PARAMETER NAME AS STUDENTTYPESLNO
            oParameter = Cmd.Parameters.Add("iGENDER", OracleType.VarChar, 5)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Gender

            'ADD IN PARAMETER NAME AS EXAMBRANCHSLNO
            oParameter = Cmd.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ExamBranchSlno

            'ADD IN PARAMETER NAME AS COMACADEMICSLNO
            oParameter = Cmd.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            oParameter = Cmd.Parameters.Add("DATACUR", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            adap.SelectCommand = Cmd
            adap.Fill(ds)

        Catch ex As Exception

        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return ds

    End Function
#End Region

#Region "Single mode Student Special Batch edit mode data fetch"
    Public Function StudentSplBatch_Code(ByVal iCode As Integer) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "EXAM_STUSPLBATCHFETCH"

            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME IUSERID
            oParameter = oCommand.Parameters.Add("iCODE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCode

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

#Region "single/batch mode insert/update"
    Public Function StudentSplBatch_Update(ByVal dsSet As DataSet) As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            OraTrans = oConn.BeginTransaction
            oCommand.Transaction = OraTrans

            oCommand.CommandText = "EXAM_STUSPLBATCH_UPDATE"
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Connection = oConn

            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            oParameter = oCommand.Parameters.Add("iSPLBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SPLBATCHSLNO"

            oAdapter.InsertCommand = oCommand
            oAdapter.UpdateCommand = oCommand
            oAdapter.Update(dsSet, "STUSUBSECTION")
            OraTrans.Commit()
        Catch ex As Exception
            OraTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return 1
    End Function
#End Region

#End Region
End Class
