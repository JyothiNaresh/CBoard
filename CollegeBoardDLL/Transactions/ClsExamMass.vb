'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Exam Set (Mass) & Tailoring Mass
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 14-AUG-2006
'   FINAL BASELINE DATE               : 14-AUG-2006
'   MODIFICATIONS LOG                 : Wrong Tailoring,XML File Delete Functions adding on 20-Sep-2011 By (Venu)
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsExamMass

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


#Region "Sets"

    Private Function Set_Insert(ByVal iEXAMBRANCHSLNO As Integer, ByVal SetName As String, ByVal SetDesc As String, ByVal iCOMACADEMICSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            oCommand = New OracleCommand
            oCommand.CommandText = "TSETMT_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SetName


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'ADD IN PARAMETER NAME iSTUDENTSLNO
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SetDesc

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            Result = oCommand.Parameters("oRtnValid").Value
            Return Result

        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Function

    Private Function Set_Update(ByVal SetSlno As Integer, ByVal SetName As String, ByVal SetDesc As String, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            oCommand = New OracleCommand
            oCommand.CommandText = "TSETMT_UPDATE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iSetSlno
            oParameter = oCommand.Parameters.Add("iSetSlno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SetSlno

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SetName

            'ADD IN PARAMETER NAME iSTUDENTSLNO
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SetDesc

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            Result = oCommand.Parameters("oRtnValid").Value


        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function


    Public Function Set_Fatech(ByVal iEXAMBRANCHSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection 'establishing the Connection .

            oCommand = New OracleCommand
            oCommand.CommandText = "TSETMT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO

            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

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


    Public Function Set_Delete(ByVal Setslno As Integer) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand.CommandText = "TSETMT_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iSetSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Setslno


            'oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            'strReturn = oCommand.Parameters("oRtnValid").Value.ToString
            strReturn = "0-DELETE"
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return strReturn
    End Function


    Public Function GetSet(ByVal SetSlno As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            oConn = ObjConn.GetConnection   'establishing the Connection .

            oCommand = New OracleCommand
            oCommand.CommandText = "TSETMTEDIT_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iSetSlno
            oParameter = oCommand.Parameters.Add("iSetSlno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SetSlno

            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
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

#End Region

#Region "Exam Mass"


    Public Function SelectForPopup(ByVal iSELECTFOR As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
        Try
            ObjConn = New Connection
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            oConn = ObjConn.GetConnection   'establishing the Connection .

            oCommand = New OracleCommand
            oCommand.CommandText = "P_POPUPSELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSELECTFOR
            oParameter = oCommand.Parameters.Add("iSELECTFOR", OracleType.Int32)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSELECTFOR



            'ADD IN PARAMETER NAME iSELECTFOR
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Int32)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

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


    Public Function ExamMass(ByVal sTRSqlquery As String) As DataSet
        Try
            ObjConn = New Connection
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet
            oConn = ObjConn.GetConnection   'establishing the Connection .

            oCommand = New OracleCommand
            oCommand.CommandText = "MASSSELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            'ADD IN PARAMETER NAME iSTRSQL
            oParameter = oCommand.Parameters.Add("iSTRSQL", OracleType.VarChar, 8000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = sTRSqlquery


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function ExamMassStudent(ByVal sTRSqlquery As String) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "P_EXAMMASSSTUDENTS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iSTRSQL
            oParameter = oCommand.Parameters.Add("iSTR", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = sTRSqlquery

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function SetStudent_Fatch(ByVal SpName As String, ByVal SetSlno As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet("Students")

            oCommand.CommandText = SpName '"P_SETSTUDENTS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iSetSlno
            oParameter = oCommand.Parameters.Add("iSetSlno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SetSlno

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "Students")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function



    Public Function SetStudentForTailor(ByVal SpName As String, ByVal Dset As DataSet, ByVal DTable As String, ByVal iDEXAMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal iCOURSESLNO As Integer, ByVal iGROUPSLNO As Integer, ByVal iBATCHSLNO As Integer, ByVal iSECTIONSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer) As DataSet
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

            '

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


    Public Function Set_zoneBranch_Fatch(ByVal DSV As DataSet, ByVal Setslno As Integer) As DataSet
        Try

            ObjConn = New Connection
            oConn = ObjConn.GetConnection


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ' ds = New Data.DataSet("Details")

            oCommand.CommandText = "P_SETZONEBRANCH_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iSetSlno
            oParameter = oCommand.Parameters.Add("iSetSlno", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Setslno

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(DSV, "Details")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return DSV

    End Function

    Private Function ExamMass_Insert(ByVal Dset As DataSet, ByVal setSlno As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.Transaction = pTrans
            oCommand.CommandText = "TEXAMMASSMT_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iMTSETSLNO
            oParameter = oCommand.Parameters.Add("iMTSETSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = setSlno

            'Add In Parameter as iBranchSLNo
            oParameter = oCommand.Parameters.Add("iBranchSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANCHSLNO"

            'Add In Parameter as iBAYearSLNo
            oParameter = oCommand.Parameters.Add("iBAYearSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BAYEARSLNO"

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            ''Add In Parameter as iCOURSESLNO
            'oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "COURSESLNO"

            'Add In Parameter as iBACourseSLNo
            oParameter = oCommand.Parameters.Add("iBACourseSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'Add in Parameter as iGROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'Add In Parameter as iBATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BATCHSLNO"

            'Add In Parameter as iSectionSLNo
            oParameter = oCommand.Parameters.Add("iSectionSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"

            'Add In Parameter as iSubSectionSLNo
            oParameter = oCommand.Parameters.Add("iSubSectionSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBSECTIONSLNO"

            'Add In Parameter as iMediumSLNo
            oParameter = oCommand.Parameters.Add("iMediumSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MEDIUMSLNO"

            'Add In Parameter as iTypeSLNo
            oParameter = oCommand.Parameters.Add("iTypeSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUTYPESLNO"

            'Add In Parameter as iAdmSLNo
            oParameter = oCommand.Parameters.Add("iAdmSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add In Parameter as iDescription
            oParameter = oCommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = "Exam Mass "

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(Dset, "Students")

        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Function

    Private Function ExamMassCuraRRYLST_Insert(ByVal Dset As DataSet, ByVal setSlno As Integer, ByVal iSubBatchslno As Integer) As String
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            'oTrans = oConn.BeginTransaction()


            'oCommand.Transaction = pTrans
            oCommand.CommandText = "EXAM_CURMASS_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iMTSETSLNO
            oParameter = oCommand.Parameters.Add("iMTSETSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = setSlno


            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'Add In Parameter as iBACourseSLNo
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'Add in Parameter as iGROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'Add In Parameter as iBATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BATCHSLNO"

            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"


            'Add In Parameter as iSUBBATCHSLNO
            oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSubBatchslno


            oAdapter.InsertCommand = oCommand
            oAdapter.Update(Dset, "Details")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Private Function ExamMassCur_Insert(ByVal Dset As DataSet, ByVal setSlno As Integer, ByVal iSubBatchslno As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.Transaction = pTrans
            oCommand.CommandText = "EXAM_CURMASS_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iMTSETSLNO
            oParameter = oCommand.Parameters.Add("iMTSETSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = setSlno


            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'Add In Parameter as iBACourseSLNo
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'Add in Parameter as iGROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'Add In Parameter as iBATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BATCHSLNO"

            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"


            'Add In Parameter as iSUBBATCHSLNO
            oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSubBatchslno


            oAdapter.InsertCommand = oCommand
            oAdapter.Update(Dset, "Details")

        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Function


    Private Function ExamMassCur_Insert(ByVal Dset As DataSet, ByVal setSlno As Integer, ByVal iSubBatchslno As Integer, ByVal iExamTarget As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.Transaction = pTrans
            oCommand.CommandText = "EXAM_CURMASSET_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iMTSETSLNO
            oParameter = oCommand.Parameters.Add("iMTSETSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = setSlno


            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'Add In Parameter as iBACourseSLNo
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'Add in Parameter as iGROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'Add In Parameter as iBATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BATCHSLNO"

            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"


            'Add In Parameter as iSUBBATCHSLNO
            oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSubBatchslno

            'Add In Parameter as iExamTarget
            oParameter = oCommand.Parameters.Add("iExam_target", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iExamTarget


            oAdapter.InsertCommand = oCommand
            oAdapter.Update(Dset, "Details")

        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Function
    Private Function ExamMassSet_Update(ByVal Dset As DataSet, ByVal setSlno As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            Dim Incommand As New OracleCommand
            ' Dim DelCommand As New OracleCommand


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.Transaction = pTrans
            oCommand.CommandText = "TEXAMMASSMT_DELETE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure


            Incommand.Transaction = pTrans
            Incommand.CommandText = "TEXAMMASSMT_INSERT"
            Incommand.Connection = pConn
            Incommand.CommandType = CommandType.StoredProcedure

            ''''''''''''''''''''''''''''''''''Insert'''''''''''''''''''''''''''''''''''''''''''''''''''''''


            'Add In Parameter as iMTSETSLNO
            oParameter = Incommand.Parameters.Add("iMTSETSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = setSlno

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = Incommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'Add In Parameter as iBACourseSLNo
            oParameter = Incommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'Add in Parameter as iGROUPSLNO
            oParameter = Incommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'Add In Parameter as iBATCHSLNO
            oParameter = Incommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BATCHSLNO"

            'Add In Parameter as iSectionSLNo
            oParameter = Incommand.Parameters.Add("iSectionSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"

            'Add In Parameter as iSubSectionSLNo
            oParameter = Incommand.Parameters.Add("iSubSectionSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBSECTIONSLNO"

            'Add In Parameter as iMediumSLNo
            oParameter = Incommand.Parameters.Add("iMediumSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "MEDIUMSLNO"

            'Add In Parameter as iTypeSLNo
            oParameter = Incommand.Parameters.Add("iTypeSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STUTYPESLNO"

            'Add In Parameter as iAdmSLNo
            oParameter = Incommand.Parameters.Add("iAdmSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add In Parameter as iDescription
            oParameter = Incommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = "Exam Mass "

            oAdapter.InsertCommand = Incommand


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''End Of Insert'''''''''''''''''''''''''''''''''''''''''''''''

            'Add In Parameter as iMTSETSLNO
            oParameter = oCommand.Parameters.Add("iMTSETSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = setSlno

            ''Add In Parameter as iTypeSLNo
            'oParameter = oCommand.Parameters.Add("iTypeSLNo", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "STUTYPESLNO"

            'Add In Parameter as iAdmSLNo
            oParameter = oCommand.Parameters.Add("iAdmSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"


            oAdapter.DeleteCommand = oCommand

            oAdapter.Update(Dset, "Students")

        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Function


    Public Function ExamMass_Save(ByVal Dset As DataSet, ByVal iEXAMBRANCHSLNO As Integer, ByVal SetName As String, ByVal setDesc As String, ByVal iCOMACADEMICSLNO As Integer, ByVal arrylst As ArrayList) As String
        Dim rtnString As String

        Try
            Dim setResult As String
            Dim ASR() As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            'Sets Inserting
            setResult = Set_Insert(iEXAMBRANCHSLNO, SetName, setDesc, iCOMACADEMICSLNO, oConn, oTrans)
            ASR = setResult.Split(":")
            'Exam Mass Inserting
            'If Not IsNothing(Dset) AndAlso Dset.Tables(0).Rows.Count > 0 Then
            '    ExamMass_Insert(Dset, Val(setResult), oConn, oTrans)
            'End If

            'Exam Mass Inserting
            If Not IsNothing(Dset) AndAlso Dset.Tables(0).Rows.Count > 0 Then
                Dim Z As Integer

                For Z = 0 To arrylst.Count - 1
                    Dim DSE As DataSet
                    DSE = Dset.Copy
                    ExamMassCur_Insert(DSE, Val(ASR(0)), Val(arrylst(Z)), oConn, oTrans)
                    'ExamMassCuraRRYLST_Insert(Dset, Val(ASR(0)), Val(arrylst(i)))
                Next


            End If


            oTrans.Commit()
            rtnString = "Set Saved With " & ASR(1).ToString

        Catch ex As Exception
            oTrans.Rollback()
            rtnString = ex.Message.ToString
            rtnString = "Set Not Saved"
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString

    End Function

    Public Function ExamMass_Save(ByVal Dset As DataSet, ByVal iEXAMBRANCHSLNO As Integer, ByVal SetName As String, ByVal setDesc As String, ByVal iCOMACADEMICSLNO As Integer, ByVal arrylst As ArrayList, ByVal Etlst As ArrayList) As String
        Dim rtnString As String

        Try
            Dim setResult As String
            Dim ASR() As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            'Sets Inserting
            setResult = Set_Insert(iEXAMBRANCHSLNO, SetName, setDesc, iCOMACADEMICSLNO, oConn, oTrans)
            ASR = setResult.Split(":")
            'Exam Mass Inserting
            'If Not IsNothing(Dset) AndAlso Dset.Tables(0).Rows.Count > 0 Then
            '    ExamMass_Insert(Dset, Val(setResult), oConn, oTrans)
            'End If

            'Exam Mass Inserting
            If Not IsNothing(Dset) AndAlso Dset.Tables(0).Rows.Count > 0 Then
                Dim Z, Y As Integer

                For Z = 0 To arrylst.Count - 1
                    For Y = 0 To Etlst.Count - 1
                        Dim DSE As DataSet
                        DSE = Dset.Copy
                        ExamMassCur_Insert(DSE, Val(ASR(0)), Val(arrylst(Z)), Val(Etlst(Y)), oConn, oTrans)
                    Next
                    'ExamMassCuraRRYLST_Insert(Dset, Val(ASR(0)), Val(arrylst(i)))
                Next


            End If


            oTrans.Commit()
            rtnString = "Set Saved With " & ASR(1).ToString

        Catch ex As Exception
            oTrans.Rollback()
            rtnString = ex.Message.ToString
            rtnString = "Set Not Saved"
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString

    End Function

    Public Function ExamMass_Update(ByVal Dset As DataSet, ByVal SetSlno As Integer, ByVal SetName As String, ByVal setDesc As String, ByVal arrylst As ArrayList) As String
        Dim rtnString As String

        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            rtnString = Set_Update(SetSlno, SetName, setDesc, oConn, oTrans)


            'Exam Mass update

            If Not IsNothing(Dset) AndAlso Dset.Tables(0).Rows.Count > 0 Then
                'rtnString = ExamMassCur_Insert(Dset, SetSlno, oConn, oTrans)

                For i As Integer = 0 To arrylst.Count - 1
                    Dim DSE As DataSet
                    DSE = Dset.Copy
                    ExamMassCur_Insert(DSE, SetSlno, Val(arrylst(i).ToString), oConn, oTrans)
                Next

            End If

            oTrans.Commit()
            rtnString = "Set Updated"

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex

        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function


    Public Function ExamMass_Update(ByVal Dset As DataSet, ByVal SetSlno As Integer, ByVal SetName As String, ByVal setDesc As String, ByVal arrylst As ArrayList, ByVal Etlst As ArrayList) As String
        Dim rtnString As String

        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            rtnString = Set_Update(SetSlno, SetName, setDesc, oConn, oTrans)


            'Exam Mass update

            If Not IsNothing(Dset) AndAlso Dset.Tables(0).Rows.Count > 0 Then
                'rtnString = ExamMassCur_Insert(Dset, SetSlno, oConn, oTrans)

                For i As Integer = 0 To arrylst.Count - 1
                    For j As Integer = 0 To Etlst.Count - 1
                        Dim DSE As DataSet
                        DSE = Dset.Copy
                        ExamMassCur_Insert(DSE, SetSlno, Val(arrylst(i).ToString), Val(Etlst(j).ToString), oConn, oTrans)
                    Next
                Next

            End If

            oTrans.Commit()
            rtnString = "Set Updated"

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex

        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function


    Public Function ExamMass_Delete(ByVal Dset As DataSet, ByVal SetSlno As Integer, ByVal SetName As String, ByVal setDesc As String) As String
        Dim rtnString As String

        Try
            Dim setResult As String
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            If Not IsNothing(Dset) AndAlso Dset.Tables(0).Rows.Count > 0 Then
                rtnString = ExamMassCur_Delete(Dset, SetSlno, oConn, oTrans)
            End If

            oTrans.Commit()
            rtnString = "Set Updated"

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function

    Private Function ExamMassCur_Delete(ByVal Dset As DataSet, ByVal setSlno As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.Transaction = pTrans
            oCommand.CommandText = "EXAM_CURMASS_DELETE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iMTSETSLNO
            oParameter = oCommand.Parameters.Add("iMTSETSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = setSlno


            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'Add In Parameter as iBACourseSLNo
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'Add in Parameter as iGROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'Add In Parameter as iBATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BATCHSLNO"


            oAdapter.DeleteCommand = oCommand
            oAdapter.Update(Dset, "Details")

        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Function

#End Region


#Region "Exam Mass Tailor"

    Public Function ExamMassTailor_Save(ByVal Dset As DataSet, ByVal DEXAMSLNO As Integer) As String
        Dim rtnString As String

        Try
            Dim setResult As String
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()


            'Exam Mass Inserting
            If Not IsNothing(Dset) AndAlso Dset.Tables(0).Rows.Count > 0 Then
                ExamMassTailor_Update(Dset, DEXAMSLNO, oConn, oTrans)
            End If


            oTrans.Commit()
            rtnString = "Set Saved"


        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
            'rtnString = ex.Message.ToString
            'rtnString = "Set Not Saved"
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        'Return rtnString

    End Function

    Private Function ExamMassTailor_Update(ByVal Dset As DataSet, ByVal DEXAMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            Dim Incommand As New OracleCommand
            Dim DParameter As New OracleClient.OracleParameter


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.Transaction = pTrans
            oCommand.CommandText = "EXAMTAILORE_DELETE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure


            Incommand.Transaction = pTrans
            Incommand.CommandText = "EXAMTAILORED_MASS_UPDATE"
            Incommand.Connection = pConn
            Incommand.CommandType = CommandType.StoredProcedure

            ''''''''''''''''''''''''''''''''''Insert'''''''''''''''''''''''''''''''''''''''''''''''''''''''


            'Add In Parameter as iDEXAMSLNO
            oParameter = Incommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DEXAMSLNO


            'Add In Parameter as iAdmSLNo
            oParameter = Incommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            'Add In Parameter as iSectionSLNo
            oParameter = Incommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'Add In Parameter as iSectionSLNo
            oParameter = Incommand.Parameters.Add("iSECTIONSLO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SECTIONSLNO"

            'Add In Parameter as iDescription
            oParameter = Incommand.Parameters.Add("iDescription", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = "Exam Tailored Mass"


            'Add In Parameter as iOBJSTATUS
            oParameter = Incommand.Parameters.Add("iOBJSTATUS", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = "SELECTED"

            'Add In Parameter as iDescription
            oParameter = Incommand.Parameters.Add("iDESSTATUS", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = "SELECTED"

            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = Incommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            oAdapter.InsertCommand = Incommand


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''End Of Insert'''''''''''''''''''''''''''''''''''''''''''''''

            'Add In Parameter as iDEXAMSLNO
            DParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            DParameter.Direction = ParameterDirection.Input
            DParameter.Value = DEXAMSLNO

            ''Add In Parameter as iTypeSLNo
            'oParameter = oCommand.Parameters.Add("iTypeSLNo", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.SourceColumn = "STUTYPESLNO"

            'Add In Parameter as iAdmSLNo
            DParameter = oCommand.Parameters.Add("iAdmSLNo", OracleType.Number)
            DParameter.Direction = ParameterDirection.Input
            DParameter.SourceColumn = "ADMSLNO"


            oAdapter.DeleteCommand = oCommand

            oAdapter.Update(Dset, "Students")

        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Function

    Private Function EMT_Results_Update(ByVal Dset As DataSet, ByVal DEXAMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            Dim Incommand As New OracleCommand
            Dim DParameter As New OracleClient.OracleParameter


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.Transaction = pTrans
            oCommand.CommandText = "EXAMTAILORE_DELETE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure


            Incommand.Transaction = pTrans
            Incommand.CommandText = "EXAMTailored_MASS_INSERT"
            Incommand.Connection = pConn
            Incommand.CommandType = CommandType.StoredProcedure


            ''''''''''''''''''''''''''''''''''Insert'''''''''''''''''''''''''''''''''''''''''''''''''''''''


            'Add In Parameter as iDEXAMSLNO
            oParameter = Incommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DEXAMSLNO

            'Add In Parameter as iAdmSLNo
            oParameter = Incommand.Parameters.Add("iAdmSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ADMSLNO"

            oAdapter.InsertCommand = Incommand


            'Add In Parameter as iDEXAMSLNO
            DParameter = oCommand.Parameters.Add("iDEXAMSLNO", OracleType.Number)
            DParameter.Direction = ParameterDirection.Input
            DParameter.Value = DEXAMSLNO

            'Add In Parameter as iAdmSLNo
            DParameter = oCommand.Parameters.Add("iAdmSLNo", OracleType.Number)
            DParameter.Direction = ParameterDirection.Input
            DParameter.SourceColumn = "ADMSLNO"


            oAdapter.DeleteCommand = oCommand

            oAdapter.Update(Dset, "Students")

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function

    'Added by venu on 20-Sep-2011
    Public Function WrongTailoring_Delete(ByVal dset As DataSet, ByVal DEXAMSLNO As Integer) As Integer
        Try
            'Dim ODcommand As New OracleCommand
            'Dim DParameter As New OracleClient.OracleParameter

            'ODcommand = New OracleClient.OracleCommand
            'DParameter = New OracleClient.OracleParameter
            'oAdapter = New OracleClient.OracleDataAdapter

            'ODcommand.CommandText = "WRONGTAILORING_DELETE"
            'ODcommand.Connection = oConn
            'ODcommand.CommandType = CommandType.StoredProcedure

            'DParameter = ODcommand.Parameters.Add("IADMSLNO", OracleType.Number)
            'DParameter.Direction = ParameterDirection.Input
            'DParameter.SourceColumn = "ADMSLNO"

            'DParameter = ODcommand.Parameters.Add("IDEXAMSLNO", OracleType.Number)
            'DParameter.Direction = ParameterDirection.Input
            'DParameter.Value = DEXAMSLNO

            'ODcommand.ExecuteNonQuery()
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            Dim Strn As String
            Strn = ""
            For I As Integer = 0 To dset.Tables(0).Rows.Count - 1
                Strn += dset.Tables(0).Rows(I).Item(0).ToString + IIf(I <> dset.Tables(0).Rows.Count - 1, ",", "")
            Next
            'Dim myOracleTransaction As OracleTransaction

            oTrans = oConn.BeginTransaction()

            'myOracleTransaction = oConn.BeginTransaction()

            Dim myOracleCommand As New OracleClient.OracleCommand

            myOracleCommand.Connection = oConn

            myOracleCommand.Transaction = oTrans

            myOracleCommand.CommandText = "delete from EXAM_EXAMTailored_MASS where DEXAMSLNO=" & DEXAMSLNO & " AND ADMSLNO IN ( " & Strn & ")"

            myOracleCommand.ExecuteNonQuery()

            oTrans.Commit()

            Return 1

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function XMLFiles_Delete(ByVal XmlStr As String) As Integer
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            Dim myOracleCommand As New OracleClient.OracleCommand

            myOracleCommand.Connection = oConn

            myOracleCommand.Transaction = oTrans

            myOracleCommand.CommandText = "DELETE FROM EXAM_OBJECTIVEFILES WHERE OBJFILESLNO IN (" & XmlStr & ") AND STATUS NOT IN('C')"

            myOracleCommand.ExecuteNonQuery()

            oTrans.Commit()

            Return 1

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "Staff Exam Mass to Combinationkeys"

    Public Function StaffMassTailor_Save(ByVal Dset As DataSet, ByVal COMBINATIONKEY As Integer, ByVal COMACADEMICSLNO As Integer) As String
        Dim rtnString As String

        Try
            Dim setResult As String
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()


            'Exam Mass Inserting
            If Not IsNothing(Dset) AndAlso Dset.Tables(0).Rows.Count > 0 Then
                StaffMassTailor_Update(Dset, COMBINATIONKEY, COMACADEMICSLNO, oConn, oTrans)
            End If


            oTrans.Commit()
            rtnString = "Set Saved"


        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
            'rtnString = ex.Message.ToString
            'rtnString = "Set Not Saved"
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        'Return rtnString

    End Function

    Private Function StaffMassTailor_Update(ByVal Dset As DataSet, ByVal COMBINATIONKEY As Integer, ByVal COMACADEMICSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            Dim Incommand As New OracleCommand
            Dim DParameter As New OracleClient.OracleParameter


            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.Transaction = pTrans
            oCommand.CommandText = "STAFFCOMB_DELETE"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure


            Incommand.Transaction = pTrans
            Incommand.CommandText = "STAFF_COMB_MASS_UPDATE"
            Incommand.Connection = pConn
            Incommand.CommandType = CommandType.StoredProcedure

            ''''''''''''''''''''''''''''''''''Insert'''''''''''''''''''''''''''''''''''''''''''''''''''''''


            'Add In Parameter as iCOMBINATIONKEY
            oParameter = Incommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMBINATIONKEY

            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = Incommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            'Add In Parameter as UNIQUENO
            oParameter = Incommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "UNIQUENO"

            'Add In Parameter as EMPNO
            oParameter = Incommand.Parameters.Add("iEMPNO", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EMPNO"

            oAdapter.InsertCommand = Incommand


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''End Of Insert'''''''''''''''''''''''''''''''''''''''''''''''

            'Add In Parameter as iCOMBINATIONKEY
            DParameter = oCommand.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            DParameter.Direction = ParameterDirection.Input
            DParameter.Value = COMBINATIONKEY

            'Add In Parameter as iAdmSLNo
            DParameter = oCommand.Parameters.Add("iUNIQUENO", OracleType.Number)
            DParameter.Direction = ParameterDirection.Input
            DParameter.SourceColumn = "UNIQUENO"


            oAdapter.DeleteCommand = oCommand

            oAdapter.Update(Dset, "EMPMAP")

        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Function


#End Region

#Region " ScholarShip Test "

    Public Function ScholarShip_Save(ByVal Dset As DataSet, ByVal iEXAMBRANCHSLNO As Integer, ByVal SetName As String, ByVal setDesc As String, ByVal iCOMACADEMICSLNO As Integer, ByVal arrylst As ArrayList, ByVal iCOURSETYPE As Integer, ByVal iTALENTEXAMSLNO As Integer) As String
        Dim rtnString As String

        Try
            Dim setResult As String
            Dim ASR() As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            'Sets Inserting
            setResult = Set_Insert(iEXAMBRANCHSLNO, SetName, setDesc, iCOMACADEMICSLNO, oConn, oTrans)
            ASR = setResult.Split(":")
            'Exam Mass Inserting
            'If Not IsNothing(Dset) AndAlso Dset.Tables(0).Rows.Count > 0 Then
            '    ExamMass_Insert(Dset, Val(setResult), oConn, oTrans)
            'End If

            'Exam Mass Inserting
            If Not IsNothing(Dset) AndAlso Dset.Tables(0).Rows.Count > 0 Then
                Dim Z As Integer

                For Z = 0 To arrylst.Count - 1
                    'Dim DSE As DataSet
                    'DSE = Dset.Copy
                    ScholarShipCur_Insert(Dset, Val(ASR(0)), Val(arrylst(Z)), iCOURSETYPE, iTALENTEXAMSLNO, oConn, oTrans)
                    'ExamMassCuraRRYLST_Insert(Dset, Val(ASR(0)), Val(arrylst(i)))
                Next


            End If


            oTrans.Commit()
            rtnString = "Set Saved With " & ASR(1).ToString

        Catch ex As Exception
            oTrans.Rollback()
            rtnString = ex.Message.ToString
            rtnString = "Set Not Saved"
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString

    End Function

    Private Function ScholarShipCur_Insert(ByVal Dset As DataSet, ByVal setSlno As Integer, ByVal iSubBatchslno As Integer, ByVal iCOURSETYPE As Integer, ByVal iTALENTEXAMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.Transaction = pTrans
            oCommand.CommandText = "EXAM_CURSCHOLARSHIP_INSERT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iMTSETSLNO
            oParameter = oCommand.Parameters.Add("iMTSETSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = setSlno


            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'Add In Parameter as iBACourseSLNo
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'Add in Parameter as iGROUPSLNO
            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "GROUPSLNO"

            'Add In Parameter as iBATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BATCHSLNO"

            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"


            'Add In Parameter as iSUBBATCHSLNO
            oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSubBatchslno

            'Add In Parameter as iCOURSETYPE
            oParameter = oCommand.Parameters.Add("iCOURSETYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOURSETYPE
            '

            'Add In Parameter as TALENTEXAMSLNO
            oParameter = oCommand.Parameters.Add("iTALENTEXAMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iTALENTEXAMSLNO


            oAdapter.InsertCommand = oCommand
            oAdapter.Update(Dset, "Details")

        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Function

    Public Function ScholarShipMass_Update(ByVal Dset As DataSet, ByVal SetSlno As Integer, ByVal SetName As String, ByVal setDesc As String, ByVal arrylst As ArrayList, ByVal iCOURSETYPE As Integer, ByVal iTALENTEXAMSLNO As Integer) As String
        Dim rtnString As String
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            rtnString = Set_Update(SetSlno, SetName, setDesc, oConn, oTrans)


            'Exam Mass update

            If Not IsNothing(Dset) AndAlso Dset.Tables(0).Rows.Count > 0 Then
                'rtnString = ExamMassCur_Insert(Dset, SetSlno, oConn, oTrans)

                For i As Integer = 0 To arrylst.Count - 1
                    Dim DSE As DataSet
                    DSE = Dset.Copy
                    ScholarShipCur_Insert(DSE, SetSlno, Val(arrylst(i).ToString), iCOURSETYPE, iTALENTEXAMSLNO, oConn, oTrans)
                Next

            End If

            oTrans.Commit()
            rtnString = "Set Updated"

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
