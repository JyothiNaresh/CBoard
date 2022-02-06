'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating Exam Branchs
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 11-OCT-2006
'   FINAL BASELINE DATE               : 11-OCT-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsExamBranchs
#Region "Class Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As New OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ds As Data.DataSet
    Private oTrans As OracleTransaction
    Private Result As String
    Private ObjConn As Connection

#End Region

#Region "ExamBranchs"


    Public Function ExamBranchs_Select() As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oCommand.CommandText = "EXAMBRANCH_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            ''ADD IN PARAMETER iEXAMCATESLNO 
            'oParameter = oCommand.Parameters.Add("iEXAMCATESLNO", OracleType.Number, 4)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = EXAMCATESLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ExamBranchs")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds

    End Function

    Public Function SelectExamBranch(ByVal EXAMBRANCHSLNO As Integer) As DataSet
        Try

            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oCommand.CommandText = "EXAMBRANCHSLNO_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iEXAMBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMBRANCHSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "ExamBranchs")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function ExamBranch_Save(ByVal DSet As DataSet, ByVal BranchSlno As Integer) As String
        Dim rtnString As String

        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            ExamBranchs(DSet, BranchSlno, oConn, oTrans)

            oTrans.Commit()
            rtnString = "Record/s Saved"

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Public Function ExamBranchs(ByVal Dset As DataSet, ByVal BranchSlno As Integer, ByVal PConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            iCommand.Transaction = pTrans
            iCommand.CommandText = "EXAMBRANCH_INSERT"
            iCommand.Connection = PConn
            iCommand.CommandType = CommandType.StoredProcedure

            uCommand.Transaction = pTrans
            uCommand.CommandText = "EXAMBRANCH_UPDATE"
            uCommand.Connection = PConn
            uCommand.CommandType = CommandType.StoredProcedure

            dCommand.Transaction = pTrans
            dCommand.CommandText = "EXAMBRANCH_DELETE"
            dCommand.Connection = PConn
            dCommand.CommandType = CommandType.StoredProcedure



            'Add In Parameter as iBRANCHSLNO
            oParameter = iCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BranchSlno

            'Add In Parameter as iEXAMBRANCHNAME
            oParameter = iCommand.Parameters.Add("iEXAMBRANCHNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHNAME"

            'Add In Parameter as iDESCRIPTION
            oParameter = iCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"
            oAdapter.InsertCommand = iCommand

            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = uCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'Add In Parameter as iBRANCHSLNO
            oParameter = uCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BranchSlno

            'Add In Parameter as iEXAMBRANCHNAME
            oParameter = uCommand.Parameters.Add("iEXAMBRANCHNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHNAME"

            'Add In Parameter as iDESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.UpdateCommand = uCommand



            ''''''''''DELETE''''''''''''''''

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            ''Add In Parameter as iBRANCHSLNO
            'oParameter = dCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = BranchSlno

            oAdapter.DeleteCommand = dCommand


            oAdapter.Update(Dset, "ExamBranchs")


        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ExamBranchsDelete(ByVal EXAMBRANCHSLNO As Integer) As String
        Dim rtnString As String

        Try

            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oTrans = oConn.BeginTransaction()

            dCommand.Transaction = oTrans
            dCommand.CommandText = "EXAMBRANCH_DELETE"
            dCommand.Connection = oConn
            dCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMBRANCHSLNO

            dCommand.ExecuteNonQuery()

            oTrans.Commit()

            rtnString = "Record Deleted"


        Catch EX As Exception
            oTrans.Rollback()
            Throw EX
        Catch ex As Exception
            oTrans.Rollback()
            Throw EX
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString


    End Function


    Public Function ExambranchAddress_Select(ByVal EXAMBRANCHSLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oCommand.CommandText = "EXAM_EBADDRESS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iEXAMBRANCHSLNO 
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMBRANCHSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function ExanBranchAddress_Save(ByVal Arrylst As ArrayList) As String
        Try
            Dim rtnString As String
            Dim iCommand As New OracleClient.OracleCommand
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            iCommand.Transaction = oTrans
            iCommand.CommandText = "EXAM_EBADDRESS_UPDATE"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = iCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(0)


            'Add In Parameter as iPRINAME
            oParameter = iCommand.Parameters.Add("iPRINAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(1)

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = iCommand.Parameters.Add("iINCHARGENAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(2)

            'Add In Parameter as iCOUNTRYSLNO
            oParameter = iCommand.Parameters.Add("iCOUNTRYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(3)

            'Add In Parameter as iSTATESLNO
            oParameter = iCommand.Parameters.Add("iSTATESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(4)

            'Add In Parameter as iDISTRICTSLNO
            oParameter = iCommand.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(5)

            'Add In Parameter as iSTREET_VILL
            oParameter = iCommand.Parameters.Add("iSTREET_VILL", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(6)

            'Add In Parameter as iMANDAL_AREA
            oParameter = iCommand.Parameters.Add("iMANDAL_AREA", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(7)

            'Add In Parameter as iHNO
            oParameter = iCommand.Parameters.Add("iHNO", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(8)

            'Add In Parameter as iPIN
            oParameter = iCommand.Parameters.Add("iPIN", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(9)

            'Add In Parameter as iPHONE1
            oParameter = iCommand.Parameters.Add("iPHONE1", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(10)

            'Add In Parameter as iPHONE2
            oParameter = iCommand.Parameters.Add("iPHONE2", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(11)

            'Add In Parameter as iMOBILE
            oParameter = iCommand.Parameters.Add("iMOBILE", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(12)

            'Add In Parameter as iEMAIL
            oParameter = iCommand.Parameters.Add("iEMAIL", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(13)

            iCommand.ExecuteNonQuery()


            oTrans.Commit()

            rtnString = " Record Updated Successfully "

            Return rtnString

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try


    End Function




#End Region

#Region "Branch&course Wise ExamBranchs"

    Public Function EBSlnoName(ByVal BRANCHSLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oCommand.CommandText = "BRANCHEB_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BRANCHSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function BCEBDetails_Select(ByVal SqlStr As String) As DataSet
        Try

            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oCommand.CommandText = "BCEXAMBRANCH_DSELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iSTR
            oParameter = oCommand.Parameters.Add("iSTR", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SqlStr

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "BCEB")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function BCEB_Select(ByVal BsebSlno As Integer) As DataSet
        Try

            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oCommand.CommandText = "BCEXAMBRANCH_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iBCEBSLNO
            oParameter = oCommand.Parameters.Add("iBCEBSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BsebSlno

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "BCEB")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function


    Public Function BCEB_Save(ByVal Dset As DataSet, ByVal BranchSlno As Integer, ByVal CourseSlno As Integer) As String
        Dim rtnString As String

        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            rtnString = BCEB(Dset, BranchSlno, CourseSlno, oConn, oTrans)

            oTrans.Commit()
            rtnString = "Record/s Saved"

        Catch EX As Exception
            oTrans.Rollback()
            Throw EX
        Catch ex As Exception
            oTrans.Rollback()
            Throw EX
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Public Function BCEB(ByVal Dset As DataSet, ByVal BranchSlno As Integer, ByVal CourseSlno As Integer, ByVal PConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            iCommand.Transaction = pTrans
            iCommand.CommandText = "BCEXAMBRANCH_INSERT"
            iCommand.Connection = PConn
            iCommand.CommandType = CommandType.StoredProcedure

            uCommand.Transaction = pTrans
            uCommand.CommandText = "BCEXAMBRANCH_UPDATE"
            uCommand.Connection = PConn
            uCommand.CommandType = CommandType.StoredProcedure

            dCommand.Transaction = pTrans
            dCommand.CommandText = "BCEXAMBRANCH_DELETE"
            dCommand.Connection = PConn
            dCommand.CommandType = CommandType.StoredProcedure



            'Add In Parameter as iBRANCHSLNO
            oParameter = iCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANCHSLNO"

            'Add In Parameter as iCOURSESLNO
            oParameter = iCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = iCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'Add In Parameter as iDESCRIPTION
            oParameter = iCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.InsertCommand = iCommand

            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iBCEBSLNO
            oParameter = uCommand.Parameters.Add("iBCEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BCEBSLNO"

            'Add In Parameter as iBRANCHSLNO
            oParameter = uCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BRANCHSLNO"

            'Add In Parameter as iCOURSESLNO
            oParameter = uCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COURSESLNO"

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = uCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'Add In Parameter as iDESCRIPTION
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"

            oAdapter.UpdateCommand = uCommand


            ''''''''''DELETE''''''''''''''''

            'Add In Parameter as iBCEBSLNO
            oParameter = dCommand.Parameters.Add("iBCEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "BCEBSLNO"

            oAdapter.DeleteCommand = dCommand


            oAdapter.Update(Dset, "BCEB")


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function BcExamBranch_Delete(ByVal PSlNo As Integer) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New Data.DataSet

            oCommand.CommandText = "BCEXAMBRANCH_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME 
            oParameter = oCommand.Parameters.Add("iBCEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PSlNo

            '''oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 250)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = "Record Deleted Successfully"

            '''strReturn = oCommand.Parameters("oRtnValid").Value.ToString

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return strReturn

    End Function


#End Region

#Region "BCE ADDRESS USECASE PROCEDURES/FUNCTIONS"
    'prakash on 09/07/2007
    Public Function BCEBAddressDetails_Select(ByVal BRANCHSLNO As Integer, ByVal COURSESLNO As Integer, ByVal USERSLNO As Integer, ByVal COMACADEMICSLNO As Integer) As DataSet
        'FETCH DATA FOR ADDRESS DETAILS SCREEN
        Try

            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oCommand.CommandText = "BCEADDRESS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER iBRANCH
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BRANCHSLNO

            'ADD IN PARAMETER iCOURSE
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COURSESLNO

            

            'ADD IN PARAMETER NAME USERSLNO
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = USERSLNO


            'ADD IN PARAMETER NAME iCOMACADEMICSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            'ADD OUT PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds, "BCEB")

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function BCEBAddress_Save(ByVal Arrylst As ArrayList) As String
        'UPDATE DATA FOR ADDRESS ENTRY SCREEN
        Try
            Dim rtnString As String
            Dim iCommand As New OracleClient.OracleCommand
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oTrans = oConn.BeginTransaction()

            iCommand.Transaction = oTrans
            iCommand.CommandText = "EXAM_BECADDRESS_UPDATE"
            iCommand.Connection = oConn
            iCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iBCEBSLNO
            oParameter = iCommand.Parameters.Add("iBCEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(0)


            'Add In Parameter as iPRINAME
            oParameter = iCommand.Parameters.Add("iPRINAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(1)

            'Add In Parameter as iINCHARGENAME 
            oParameter = iCommand.Parameters.Add("iINCHARGENAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(2)

            'Add In Parameter as iCOLLEGENAME  
            oParameter = iCommand.Parameters.Add("iCOLLEGENAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(3)


            'Add In Parameter as iCOUNTRYSLNO
            oParameter = iCommand.Parameters.Add("iCOUNTRYSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(4)

            'Add In Parameter as iSTATESLNO
            oParameter = iCommand.Parameters.Add("iSTATESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(5)

            'Add In Parameter as iDISTRICTSLNO
            oParameter = iCommand.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(6)

            'Add In Parameter as iSTREET_VILL
            oParameter = iCommand.Parameters.Add("iSTREET_VILL", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(7)

            'Add In Parameter as iMANDAL_AREA
            oParameter = iCommand.Parameters.Add("iMANDAL_AREA", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(8)

            'Add In Parameter as iHNO
            oParameter = iCommand.Parameters.Add("iHNO", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(9)

            'Add In Parameter as iPIN
            oParameter = iCommand.Parameters.Add("iPIN", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(10)

            'Add In Parameter as iPHONE1
            oParameter = iCommand.Parameters.Add("iPHONE1", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(11)

            'Add In Parameter as iPHONE2
            oParameter = iCommand.Parameters.Add("iPHONE2", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(12)

            'Add In Parameter as iMOBILE
            oParameter = iCommand.Parameters.Add("iMOBILE", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(13)

            'Add In Parameter as iEMAIL
            oParameter = iCommand.Parameters.Add("iEMAIL", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Arrylst(14)

            iCommand.ExecuteNonQuery()


            oTrans.Commit()

            rtnString = " Record Updated Successfully "

            Return rtnString

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function BCEBAddress_Select(ByVal BCEBSLNO As Integer) As DataSet
        'FETCH DATA FOR ADDRESS ENTRY SCREEN
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oCommand.CommandText = "EXAM_BECADDRESS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iBCEBSLNO 
            oParameter = oCommand.Parameters.Add("iBCEBSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BCEBSLNO


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

#Region " Accademic Year Wise Exam Branch "

    Public Function AccYearExamBranch_Save(ByVal DSet As DataSet) As String
        Dim rtnString As String

        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            AccYearExamBranchs(DSet, oConn, oTrans)

            oTrans.Commit()
            rtnString = "Record/s Saved"

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Public Function AccYearExamBranchs(ByVal Dset As DataSet, ByVal PConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            iCommand.Transaction = pTrans
            iCommand.CommandText = "EXAM_ACYEXAMBRANCH_INSERT"
            iCommand.Connection = PConn
            iCommand.CommandType = CommandType.StoredProcedure

            uCommand.Transaction = pTrans
            uCommand.CommandText = "EXAM_ACYEXAMBRANCH_UPDATE"
            uCommand.Connection = PConn
            uCommand.CommandType = CommandType.StoredProcedure



            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = iCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = iCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            oAdapter.InsertCommand = iCommand


            ''''''''''UPDATE''''''''''''''''

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = uCommand.Parameters.Add("iACYEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "ACYEBSLNO"

            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = uCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "COMACADEMICSLNO"

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = uCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            oAdapter.UpdateCommand = uCommand


            oAdapter.Update(Dset, "ACYEB")


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function AccYearExamBranchsDelete(ByVal ACYEBSLNO As Integer) As String
        Dim rtnString As String

        Try

            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oTrans = oConn.BeginTransaction()

            dCommand.Transaction = oTrans
            dCommand.CommandText = "EXAM_ACYEXAMBRANCH_DELETE"
            dCommand.Connection = oConn
            dCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iACYEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ACYEBSLNO

            dCommand.ExecuteNonQuery()

            oTrans.Commit()

            rtnString = "Record Deleted"


        Catch EX As Exception
            oTrans.Rollback()
            Throw EX
        Catch ex As Exception
            oTrans.Rollback()
            Throw EX
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString


    End Function

    Public Function AccYearExamBranchs_insert(ByVal iCOMACADEMICSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer) As String
        Dim rtnString As String
        Try

            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oTrans = oConn.BeginTransaction()

            dCommand.Transaction = oTrans
            dCommand.CommandText = "EXAM_ACYEXAMBRANCH_INSERT"
            dCommand.Connection = oConn
            dCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = dCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO


            dCommand.ExecuteNonQuery()

            oTrans.Commit()

            rtnString = "Record Saved"


        Catch EX As Exception
            oTrans.Rollback()
            Throw EX
        Catch ex As Exception
            oTrans.Rollback()
            Throw EX
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString


    End Function

    Public Function AccYearExamBranchs_Updated(ByVal iACYEBSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer) As String
        Dim rtnString As String
        Try

            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oTrans = oConn.BeginTransaction()

            dCommand.Transaction = oTrans
            dCommand.CommandText = "EXAM_ACYEXAMBRANCH_UPDATE"
            dCommand.Connection = oConn
            dCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as iACYEBSLNO
            oParameter = dCommand.Parameters.Add("iACYEBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iACYEBSLNO

            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = dCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOMACADEMICSLNO

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iEXAMBRANCHSLNO


            dCommand.ExecuteNonQuery()

            oTrans.Commit()

            rtnString = "Record Updated"


        Catch EX As Exception
            oTrans.Rollback()
            Throw EX
        Catch ex As Exception
            oTrans.Rollback()
            Throw EX
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString


    End Function

#End Region

#Region " $ ExamBranch Sections Mapping"

    Public Function ExamBranchSectionsGet(ByVal COMACADEMICSLNO As Integer, ByVal EBSLNO As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oCommand.CommandText = "EXAM_EBSECTIONMAP"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EBSLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function Exam_CGBSBSectionsGet(ByVal COMACADEMICSLNO As Integer, ByVal EXAMBRANCHSLNO As Integer, ByVal COURSESLNO As Integer, ByVal GROUPSLNO As Integer, ByVal BATCHSLNO As Integer, ByVal SUBBATCHSLNO As Integer, ByVal QryMode As Integer) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oCommand.CommandText = "EXAM_CGBSBSECTIONS_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            'ADD IN PARAMETER iBRANCHSLNO
            oParameter = oCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            'ADD IN PARAMETER iBRANCHSLNO
            oParameter = oCommand.Parameters.Add("IEXAMBRANCHSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMBRANCHSLNO

            'ADD IN PARAMETER iBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COURSESLNO

            oParameter = oCommand.Parameters.Add("iGROUPSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GROUPSLNO

            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BATCHSLNO

            oParameter = oCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number, 4)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SUBBATCHSLNO

            oParameter = oCommand.Parameters.Add("iQRYMODE", OracleType.Number, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = QryMode

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

    Public Function Exam_CGBSBSectionSave(ByVal COMACADEMICSLNO As Integer, ByVal EXAMBRANCHSLNO As Integer, ByVal COURSESLNO As Integer, ByVal GROUPSLNO As Integer, ByVal BATCHSLNO As Integer, ByVal SUBBATCHSLNO As Integer, ByVal SECTIONSLNO As Integer, ByVal SECTION As Integer, ByVal USERSLNO As Integer) As String
        Dim rtnString As String
        Try
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oTrans = oConn.BeginTransaction()

            dCommand.Transaction = oTrans
            dCommand.CommandText = "EXAM_CGBSBSECTION_INSERT"
            dCommand.Connection = oConn
            dCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = dCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMBRANCHSLNO

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COURSESLNO

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GROUPSLNO

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BATCHSLNO

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SUBBATCHSLNO

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SECTIONSLNO

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iSECTION", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SECTION

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = USERSLNO

            dCommand.ExecuteNonQuery()

            oTrans.Commit()

            rtnString = "Record Saved"


        Catch EX As Exception
            oTrans.Rollback()
            Throw EX
        Catch ex As Exception
            oTrans.Rollback()
            Throw EX
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Public Function Exam_CGBSBSectionDelete(ByVal COMACADEMICSLNO As Integer, ByVal EXAMBRANCHSLNO As Integer, ByVal COURSESLNO As Integer, ByVal GROUPSLNO As Integer, ByVal BATCHSLNO As Integer, ByVal SUBBATCHSLNO As Integer, ByVal SECTIONSLNO As Integer) As String
        Dim rtnString As String
        Try
            Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()


            oTrans = oConn.BeginTransaction()

            dCommand.Transaction = oTrans
            dCommand.CommandText = "EXAM_EBSECTION_DELETE"
            dCommand.Connection = oConn
            dCommand.CommandType = CommandType.StoredProcedure


            'Add In Parameter as iCOMACADEMICSLNO
            oParameter = dCommand.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = EXAMBRANCHSLNO

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COURSESLNO

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = GROUPSLNO

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BATCHSLNO

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SUBBATCHSLNO

            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = dCommand.Parameters.Add("iSECTIONSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = SECTIONSLNO

            dCommand.ExecuteNonQuery()

            oTrans.Commit()

            rtnString = "Record Deleted"


        Catch EX As Exception
            oTrans.Rollback()
            Throw EX
        Catch ex As Exception
            oTrans.Rollback()
            Throw EX
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Public Function Exam_STATESBSEC_FIXSTRN_SELECT(ByVal STATESLNO As Integer, ByVal dsRANGE As DataSet, ByVal DtTable As String) As DataSet
        Try
            oAdapter = New OracleClient.OracleDataAdapter
            ds = New DataSet

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()
            oCommand = New OracleCommand
            oCommand.CommandText = "EXAM_STATESBSEC_FIXSTRN"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME DataCur
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER iBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iSTATESLNO", OracleType.Number, 3)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = STATESLNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(dsRANGE, DtTable)

        Catch EX As Exception
            oTrans.Rollback()
            Throw EX
        Catch ex As Exception
            oTrans.Rollback()
            Throw EX
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return dsRANGE

    End Function

    Public Function Exam_STATESBSEC_FIXSTRN_Save(ByVal Dt As DataSet, ByVal COMACADEMICSLNO As Integer, ByVal STATESLNO As Integer) As String
        Dim rtnString As String

        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            STATESBSEC_FIXSTRN(Dt, COMACADEMICSLNO, STATESLNO, oConn, oTrans)

            oTrans.Commit()
            rtnString = "Record/s Saved"

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return rtnString

    End Function

    Public Function STATESBSEC_FIXSTRN(ByVal Dset As DataSet, ByVal COMACADEMICSLNO As Integer, ByVal STATESLNO As Integer, ByVal PConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try
            Dim iCommand As New OracleClient.OracleCommand
            Dim uCommand As New OracleClient.OracleCommand
            'Dim dCommand As New OracleClient.OracleCommand

            oAdapter = New OracleClient.OracleDataAdapter
            oParameter = New OracleClient.OracleParameter

            iCommand.Transaction = pTrans
            iCommand.CommandText = "STATESBSEC_FIXSTRN_INSERT"
            iCommand.Connection = PConn
            iCommand.CommandType = CommandType.StoredProcedure

            uCommand.Transaction = pTrans
            uCommand.CommandText = "STATESBSEC_FIXSTRN_UPDATE"
            uCommand.Connection = PConn
            uCommand.CommandType = CommandType.StoredProcedure

            'dCommand.Transaction = pTrans
            'dCommand.CommandText = "STATESBSEC_FIXSTRN_DELETE"
            'dCommand.Connection = PConn
            'dCommand.CommandType = CommandType.StoredProcedure

            'Add In Parameter as iBRANCHSLNO

            oParameter = iCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            'Add In Parameter as iEXAMBRANCHNAME
            oParameter = iCommand.Parameters.Add("ISTATESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = STATESLNO

            'Add In Parameter as iDESCRIPTION
            oParameter = iCommand.Parameters.Add("ISUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBBATCHSLNO"
            oAdapter.InsertCommand = iCommand

            oParameter = iCommand.Parameters.Add("iFIXEDSTRN", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "FIXEDSTRN"
            oAdapter.InsertCommand = iCommand


            ''''''''''UPDATE''''''''''''''''
            'Add In Parameter as iEXAMBRANCHSLNO
            oParameter = uCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COMACADEMICSLNO

            'Add In Parameter as iBRANCHSLNO
            oParameter = uCommand.Parameters.Add("ISTATESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = STATESLNO

            'Add In Parameter as iEXAMBRANCHNAME
            oParameter = uCommand.Parameters.Add("ISUBBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "SUBBATCHSLNO"

            'Add In Parameter as iDESCRIPTION
            oParameter = uCommand.Parameters.Add("IFIXEDSTRN", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "FIXEDSTRN"

            oAdapter.UpdateCommand = uCommand


            ''''''''''DELETE''''''''''''''''

            'Add In Parameter as iEXAMBRANCHSLNO
            'oParameter = dCommand.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = COMACADEMICSLNO

            ''Add In Parameter as iBRANCHSLNO
            'oParameter = uCommand.Parameters.Add("ISTATESLNO", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = STATESLNO

            'oAdapter.DeleteCommand = dCommand

            oAdapter.Update(Dset, "RANGE")

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

End Class
