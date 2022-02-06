'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS EXAMINATION 2.0
'   OBJECTIVE                         : THIS IS MIDDLE LAYER FOR AGENDA
'   ACTIVITY                          : ALL
'   AUTHOR                            : A.SURENDAR REDDY
'   INITIAL BASELINE DATE             : 12-6-2008
'   FINAL BASELINE DATE               : 12-6-2008
'   MODIFICATIONS LOG                 : MEETING HEAD,MEETING PERSONS,PLACE,BRANCHES ADDING (P.VENU)-{19/12/2011}
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration
Public Class ClsAgenda

#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private uCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ds As New Data.DataSet
    Private oTrans As OracleTransaction
    Private ObjConn As Connection
    Private ReturnStr, AGSlno As Integer

#End Region

#Region "DataSetFetch"

    Public Function dataSet_Fetch(ByVal pSqlString As String) As Data.DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

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
            oAdapter.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return ds
    End Function

#End Region

#Region " Agenda "

    Public Function Agenda_Insert(ByVal iAGNAME As String, ByVal iAGDATE As Date, ByVal iDESCRIPTION As String, ByVal iSTATUSSLNO As Integer, ByVal iUSERSLNO As Integer, ByVal AGHEAD As Integer, ByVal AGPLACE As String, ByVal Agds As DataSet) As Integer

        Dim AgNum, RtnVal As Integer
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            AgNum = Agenda_AgendaInsert(iAGNAME, iAGDATE, iDESCRIPTION, iSTATUSSLNO, iUSERSLNO, AGHEAD, AGPLACE, oConn, oTrans)

            RtnVal = Agenda_HeadInsert(AgNum, Agds, oConn, oTrans)

            RtnVal += Agenda_BranchInsert(AgNum, Agds, oConn, oTrans)

            If RtnVal = 2 Then
                oTrans.Commit()
                Return 1
            End If

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Public Function Agenda_Update(ByVal AgNum As Integer, ByVal iAGNAME As String, ByVal iAGDATE As Date, ByVal iDESCRIPTION As String, ByVal iSTATUSSLNO As Integer, ByVal iUSERSLNO As Integer, ByVal AGHEAD As Integer, ByVal AGPLACE As String, ByVal Agds As DataSet) As Integer

        Dim RtnVal As Integer
        Try
            Dim setResult As String

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            Agenda_AgendaUpdate(AgNum, iAGNAME, iAGDATE, iDESCRIPTION, iSTATUSSLNO, iUSERSLNO, AGHEAD, AGPLACE, oConn, oTrans) ' Updating Agenda Details in Agenda Master

            RtnVal = Agenda_HeadDelete(AgNum, oConn, oTrans) ' Deleting Records From Agenda Heads Detail Table 
            RtnVal += Agenda_HeadInsert(AgNum, Agds, oConn, oTrans) ' Inserting Records in Agenda Heads Detail Table 
            RtnVal += Agenda_BranchDelete(AgNum, oConn, oTrans) ' Deleting Records From Agenda Branches Detail Table 
            RtnVal += Agenda_BranchInsert(AgNum, Agds, oConn, oTrans) ' Inserting Records in Branches Heads Detail Table 

            If RtnVal = 4 Then
                oTrans.Commit()
                Return 1
            End If

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Function

    Private Function Agenda_AgendaInsert(ByVal iAGNAME As String, ByVal iAGDATE As Date, ByVal iDESCRIPTION As String, ByVal iSTATUSSLNO As Integer, ByVal iUSERSLNO As Integer, ByVal AGHEAD As Integer, ByVal AGPLACE As String, ByVal oConn As OracleConnection, ByVal Otrans As OracleTransaction) As Integer
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            'ObjConn = New Connection
            'oConn = ObjConn.GetConnection()

            oCommand.CommandText = "AG_AGENDA_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = Otrans

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iAGNAME", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGNAME

            'ADD IN PARAMETER NAME iAGDATE 
            oParameter = oCommand.Parameters.Add("iAGDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGDATE

            'ADD IN PARAMETER NAME iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDESCRIPTION

            'ADD IN PARAMETER NAME iSTATUSSLNO 
            oParameter = oCommand.Parameters.Add("iSTATUSSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSTATUSSLNO

            'ADD IN PARAMETER NAME iUSERSLNO  
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'ADD IN PARAMETER NAME iAGHEADSLNO
            oParameter = oCommand.Parameters.Add("iAGHEADSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = AGHEAD

            'ADD IN PARAMETER NAME iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iAGPLACE", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = AGPLACE

            oCommand.Parameters.Add(New OracleParameter("SeqMt", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            AGSlno = oCommand.Parameters("SeqMt").Value

            Return AGSlno

        Catch ex As Exception
            Throw ex
            'Finally
            '    If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Sub Agenda_AgendaUpdate(ByVal iAGSLNO As Integer, ByVal iAGNAME As String, ByVal iAGDATE As Date, ByVal iDESCRIPTION As String, ByVal iSTATUSSLNO As Integer, ByVal iUSERSLNO As Integer, ByVal AGHEAD As Integer, ByVal AGPLACE As String, ByVal oConn As OracleConnection, ByVal Otrans As OracleTransaction)

        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            'ObjConn = New Connection
            'oConn = ObjConn.GetConnection()

            oCommand.CommandText = "AG_AGENDA_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = Otrans

            'ADD IN PARAMETER NAME iAGSLNO
            oParameter = oCommand.Parameters.Add("iAGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGSLNO

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iAGNAME", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGNAME

            'ADD IN PARAMETER NAME iAGDATE 
            oParameter = oCommand.Parameters.Add("iAGDATE", OracleType.DateTime)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGDATE

            'ADD IN PARAMETER NAME iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDESCRIPTION

            'ADD IN PARAMETER NAME iSTATUSSLNO 
            oParameter = oCommand.Parameters.Add("iSTATUSSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSTATUSSLNO

            'ADD IN PARAMETER NAME iUSERSLNO  
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO

            'ADD IN PARAMETER NAME iAGHEADSLNO
            oParameter = oCommand.Parameters.Add("iAGHEADSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = AGHEAD

            'ADD IN PARAMETER NAME iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iAGPLACE", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = AGPLACE

            oCommand.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
            'Finally
            '    If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub Agenda_Delete(ByVal iAGSLNO As Integer)
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "AG_AGENDA_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iAGSLNO 
            oParameter = oCommand.Parameters.Add("iAGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGSLNO


            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub Agenda_Lock(ByVal iAGSLNO As Integer, ByVal iLOCKSTATUS As Integer, ByVal iUSERSLNO As Integer)
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "AG_AGENDA_LOCK"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iAGSLNO 
            oParameter = oCommand.Parameters.Add("iAGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGSLNO


            'ADD IN PARAMETER NAME iLOCKSTATUS 
            oParameter = oCommand.Parameters.Add("iLOCKSTATUS", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iLOCKSTATUS


            'ADD IN PARAMETER NAME iUSERSLNO 
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO



            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub Head_Insert(ByVal iNAME As String, ByVal iORDER_SEQ As Integer, ByVal iSTATUS As String)
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "AG_HEAD_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iNAME


            'ADD IN PARAMETER NAME iSTATUSSLNO 
            oParameter = oCommand.Parameters.Add("iORDER_SEQ", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iORDER_SEQ

            'ADD IN PARAMETER NAME iSTATUS
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSTATUS


            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub Head_Update(ByVal iAGHEADSLNO As Integer, ByVal iNAME As String, ByVal iORDER_SEQ As Integer, ByVal iSTATUS As String)
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "AG_HEAD_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iAGSLNO
            oParameter = oCommand.Parameters.Add("iAGHEADSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGHEADSLNO



            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iNAME


            'ADD IN PARAMETER NAME iSTATUSSLNO 
            oParameter = oCommand.Parameters.Add("iORDER_SEQ", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iORDER_SEQ


            'ADD IN PARAMETER NAME iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 10)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSTATUS


            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub Head_Delete(ByVal iAGHEADSLNO As Integer)
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "AG_HEAD_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iAGSLNO 
            oParameter = oCommand.Parameters.Add("iAGHEADSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGHEADSLNO


            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Private Function Agenda_HeadInsert(ByVal iAGSLNO As Integer, ByVal agds As DataSet, ByVal oConn As OracleConnection, ByVal oTrans As OracleTransaction) As Integer
        Try
            oAdapter = New OracleDataAdapter
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            'ObjConn = New Connection
            'oConn = ObjConn.GetConnection()

            oCommand.CommandText = "AG_HEAD_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'ADD IN PARAMETER NAME iAGSLNO
            oParameter = oCommand.Parameters.Add("iAGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGSLNO

            'ADD IN PARAMETER NAME iAGHEADSLNO 
            oParameter = oCommand.Parameters.Add("iAGHEADSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "AGHEADSLNO"

            'ADD IN PARAMETER NAME iUPD 
            'oParameter = oCommand.Parameters.Add("iUPD", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = InUp

            'If InUp = 0 Then
            'oCommand.ExecuteNonQuery()
            'Else
            oAdapter.InsertCommand = oCommand
            oAdapter.Update(agds, "AgHead")
            'End If

            Return 1

        Catch ex As Exception
            Throw ex
            'Finally
            '    If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Agenda_HeadDelete(ByVal iAGSLNO As Integer, ByVal oConn As OracleConnection, ByVal oTrans As OracleTransaction) As Integer

        Try
            'ObjConn = New Connection
            'oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "AG_HEADDT_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'ADD IN PARAMETER NAME iAGSLNO 
            oParameter = oCommand.Parameters.Add("iAGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGSLNO

            oCommand.ExecuteNonQuery()

            Return 1

        Catch ex As Exception
            Throw ex
            'Finally
            '    If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Public Function Agenda_BranchDelete(ByVal iAGSLNO As Integer, ByVal oConn As OracleConnection, ByVal oTrans As OracleTransaction) As Integer

        Try
            'ObjConn = New Connection
            'oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "AG_BRANCH_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = oTrans

            'ADD IN PARAMETER NAME iAGSLNO 
            oParameter = oCommand.Parameters.Add("iAGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGSLNO

            oCommand.ExecuteNonQuery()

            Return 1

        Catch ex As Exception
            Throw ex
            'Finally
            '    If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    Private Function Agenda_BranchInsert(ByVal iAGSLNO As Integer, ByVal agds As DataSet, ByVal oConn As OracleConnection, ByVal otrans As OracleTransaction) As Integer
        Try
            oAdapter = New OracleDataAdapter
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            'ObjConn = New Connection
            'oConn = ObjConn.GetConnection()

            oCommand.CommandText = "AG_BRANCH_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = otrans

            'ADD IN PARAMETER NAME iAGSLNO
            oParameter = oCommand.Parameters.Add("iAGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGSLNO

            'ADD IN PARAMETER NAME iAGHEADSLNO 
            oParameter = oCommand.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "EXAMBRANCHSLNO"

            'ADD IN PARAMETER NAME iUPD 
            'oParameter = oCommand.Parameters.Add("iUPD", OracleType.Number)
            'oParameter.Direction = ParameterDirection.Input
            'oParameter.Value = InUp

            oAdapter.InsertCommand = oCommand
            oAdapter.Update(agds, "AgBranch")

            Return 1

        Catch ex As Exception
            Throw ex
            'Finally
            '    If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

#End Region

#Region " Agenda Topics "

    Public Sub AgendaTopics_Save(ByVal Dset As DataSet)
        Try

            oCommand = New OracleClient.OracleCommand
            uCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "AG_AGENDATOPICS_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            uCommand.CommandText = "AG_AGENDATOPICS_UPDATE"
            uCommand.Connection = oConn
            uCommand.CommandType = CommandType.StoredProcedure




            'ADD IN PARAMETER NAME iAGSLNO
            oParameter = oCommand.Parameters.Add("iAGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "AGSLNO"


            'ADD IN PARAMETER NAME iAGTNAME 
            oParameter = oCommand.Parameters.Add("iAGTNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "AGTNAME"


            'ADD IN PARAMETER NAME iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"


            'ADD IN PARAMETER NAME iCREATEUSERSLNO  
            oParameter = oCommand.Parameters.Add("iCREATEUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CREATEUSERSLNO"


            oAdapter.InsertCommand = oCommand

            'ADD IN PARAMETER NAME iAGTSLNO
            oParameter = uCommand.Parameters.Add("iAGTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "AGTSLNO"


            'ADD IN PARAMETER NAME iAGSLNO
            oParameter = uCommand.Parameters.Add("iAGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "AGSLNO"


            'ADD IN PARAMETER NAME iAGTNAME 
            oParameter = uCommand.Parameters.Add("iAGTNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "AGTNAME"


            'ADD IN PARAMETER NAME iDESCRIPTION 
            oParameter = uCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "DESCRIPTION"


            'ADD IN PARAMETER NAME iCREATEUSERSLNO  
            oParameter = uCommand.Parameters.Add("iCREATEUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "CREATEUSERSLNO"


            oAdapter.UpdateCommand = uCommand




            oAdapter.Update(Dset, "")


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub AgendaTopics_Save(ByVal iAGSLNO As Integer, ByVal iAGTNAME As String, ByVal iDESCRIPTION As String, ByVal iCREATEUSERSLNO As Integer)
        Try

            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "AG_AGENDATOPICS_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iAGSLNO
            oParameter = oCommand.Parameters.Add("iAGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGSLNO


            'ADD IN PARAMETER NAME iAGTNAME 
            oParameter = oCommand.Parameters.Add("iAGTNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGTNAME


            'ADD IN PARAMETER NAME iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDESCRIPTION


            'ADD IN PARAMETER NAME iCREATEUSERSLNO  
            oParameter = oCommand.Parameters.Add("iCREATEUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCREATEUSERSLNO


            oCommand.ExecuteNonQuery()



        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub AgendaTopics_Update(ByVal iAGTSLNO As Integer, ByVal iAGTNAME As String, ByVal iDESCRIPTION As String, ByVal iCREATEUSERSLNO As Integer)
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "AG_AGENDATOPICS_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iAGTSLNO
            oParameter = oCommand.Parameters.Add("iAGTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGTSLNO


            'ADD IN PARAMETER NAME iAGTNAME
            oParameter = oCommand.Parameters.Add("iAGTNAME", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGTNAME


            'ADD IN PARAMETER NAME iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDESCRIPTION



            'ADD IN PARAMETER NAME iCREATEUSERSLNO  
            oParameter = oCommand.Parameters.Add("iCREATEUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCREATEUSERSLNO

            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Sub

    Public Sub AgendaTopics_Delete(ByVal iAGTSLNO As Integer)
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "AG_AGENDATOPICS_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iAGTSLNO 
            oParameter = oCommand.Parameters.Add("iAGTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGTSLNO


            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub AgendaTopics_Approved(ByVal Dset As DataSet)
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter
            oAdapter = New OracleClient.OracleDataAdapter

            oCommand.CommandText = "AG_AT_APPROVED"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iAGTSLNO 
            oParameter = oCommand.Parameters.Add("iAGTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "AGTSLNO"


            'ADD IN PARAMETER NAME iSTATUSSLNO 
            oParameter = oCommand.Parameters.Add("iSTATUSSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "STATUSSLNO"


            'ADD IN PARAMETER NAME iAPPROVEDUSERSLNO 
            oParameter = oCommand.Parameters.Add("iAPPROVEDUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.SourceColumn = "APPROVEDUSERSLNO"

            oAdapter.InsertCommand = oCommand

            oAdapter.Update(Dset, "TOPICAPP")


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub AgendaApprovedTopics_Update(ByVal iAGTSLNO As Integer, ByVal iAGTNAME As String, ByVal iDESCRIPTION As String, ByVal iCREATEUSERSLNO As Integer)
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "AG_AT_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iAGTSLNO
            oParameter = oCommand.Parameters.Add("iAGTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGTSLNO


            'ADD IN PARAMETER NAME iAGTNAME
            oParameter = oCommand.Parameters.Add("iAGTNAME", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGTNAME


            'ADD IN PARAMETER NAME iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDESCRIPTION



            'ADD IN PARAMETER NAME iCREATEUSERSLNO  
            oParameter = oCommand.Parameters.Add("iCREATEUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCREATEUSERSLNO

            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Sub

    Public Sub AgendaApprovedTopics_Delete(ByVal iAGTSLNO As Integer)
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "AG_AT_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iAGTSLNO 
            oParameter = oCommand.Parameters.Add("iAGTSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGTSLNO


            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

#End Region

#Region " Mints of Meeting "

    Public Sub MintsofMeeting_Save(ByVal iAGSLNO As Integer, ByVal iMMDESC As String, ByVal iUSERSLNO As Integer)
        Try

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "AG_MINTOFMEET_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iAGSLNO
            oParameter = oCommand.Parameters.Add("iAGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGSLNO


            'ADD IN PARAMETER NAME iAGTNAME 
            oParameter = oCommand.Parameters.Add("iMMDESC", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iMMDESC



            'ADD IN PARAMETER NAME iUSERSLNO  
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO


            oCommand.ExecuteNonQuery()



        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub MintsofMeeting_Update(ByVal iAGMMSLNO As Integer, ByVal iMMDESC As String, ByVal iUSERSLNO As Integer)
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "AG_MINTOFMEET_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iAGMMSLNO
            oParameter = oCommand.Parameters.Add("iAGMMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGMMSLNO


            'ADD IN PARAMETER NAME iAGTNAME 
            oParameter = oCommand.Parameters.Add("iMMDESC", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iMMDESC



            'ADD IN PARAMETER NAME iUSERSLNO  
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO


            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
    End Sub

    Public Sub MintsofMeeting_Delete(ByVal iAGMMSLNO As Integer)
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "AG_MINTOFMEET_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iAGMMSLNO 
            oParameter = oCommand.Parameters.Add("iAGMMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iAGMMSLNO


            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

#End Region

End Class
