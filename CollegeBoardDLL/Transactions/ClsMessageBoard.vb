'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS EXAMINATION 2.0
'   OBJECTIVE                         : THIS IS MIDDLE LAYER FOR AGENDA
'   ACTIVITY                          : ALL
'   AUTHOR                            : A.SURENDAR REDDY
'   INITIAL BASELINE DATE             : 12-6-2008
'   FINAL BASELINE DATE               : 12-6-2008
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsMessageBoard

#Region "Common Variables"

    Private oConn As OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private uCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private ds As New Data.DataSet
    Private oTrans As OracleTransaction
    Private ObjConn As Connection
    Private ReturnStr As Integer

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

    Public Sub Agenda_Insert(ByVal iAGNAME As String, ByVal iAGDATE As Date, ByVal iDESCRIPTION As String, ByVal iSTATUSSLNO As Integer, ByVal iUSERSLNO As Integer)
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "AG_AGENDA_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

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

            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub

    Public Sub Agenda_Update(ByVal iAGSLNO As Integer, ByVal iAGNAME As String, ByVal iAGDATE As Date, ByVal iDESCRIPTION As String, ByVal iSTATUSSLNO As Integer, ByVal iUSERSLNO As Integer)
        Dim strReturn As String
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "AG_AGENDA_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


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

            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
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

#End Region

#Region "Message Board "

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

    Public Sub MB_Message_Save(ByVal iMODULESLNO As Integer, ByVal iSUBJECT As String, ByVal iDESCRIPTION As String, ByVal iFILEPATH As String, ByVal iISACTIVE As Integer, ByVal iUSERSLNO As Integer)
        Try

            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "masters.MSG_MESSAGEBOARD_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure



            'ADD IN PARAMETER NAME iMODULESLNO
            oParameter = oCommand.Parameters.Add("iMODULESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iMODULESLNO


            'ADD IN PARAMETER NAME iSUBJECT 
            oParameter = oCommand.Parameters.Add("iSUBJECT", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSUBJECT


            'ADD IN PARAMETER NAME iDESCRIPTION 
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDESCRIPTION


            'ADD IN PARAMETER NAME iFILEPATH 
            oParameter = oCommand.Parameters.Add("iFILEPATH", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFILEPATH


            'ADD IN PARAMETER NAME iISACTIVE  
            oParameter = oCommand.Parameters.Add("iISACTIVE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iISACTIVE


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

    Public Sub MB_Message_Update(ByVal iMSGSLNO As Integer, ByVal iMODULESLNO As Integer, ByVal iSUBJECT As String, ByVal iDESCRIPTION As String, ByVal iFILEPATH As String, ByVal iISACTIVE As Integer, ByVal iUSERSLNO As Integer)
        Try
            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "masters.MSG_MESSAGEBOARD_UPDATE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iMSGSLNO
            oParameter = oCommand.Parameters.Add("iMSGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iMSGSLNO

            'ADD IN PARAMETER NAME iMODULESLNO
            oParameter = oCommand.Parameters.Add("iMODULESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iMODULESLNO


            'ADD IN PARAMETER NAME iSUBJECT 
            oParameter = oCommand.Parameters.Add("iSUBJECT", OracleType.VarChar, 250)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSUBJECT


            'ADD IN PARAMETER NAME iDESCRIPTION  
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 1000)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDESCRIPTION



            'ADD IN PARAMETER NAME iFILEPATH  
            oParameter = oCommand.Parameters.Add("iFILEPATH", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFILEPATH


            'ADD IN PARAMETER NAME iISACTIVE  
            oParameter = oCommand.Parameters.Add("iISACTIVE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iISACTIVE

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

    Public Sub MB_Message_Delete(ByVal iMSGSLNO As Integer, ByVal iUSERSLNO As Integer)
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "masters.MSG_MESSAGEBOARD_DELETE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME MSGSLNO 
            oParameter = oCommand.Parameters.Add("iMSGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iMSGSLNO

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

    Public Sub MB_Message_ActiveDeactive(ByVal iMSGSLNO As Integer, ByVal iUSERSLNO As Integer, ByVal iISACTIVE As Integer)
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "masters.MSG_MSGBOARD_ACTIVE_DEACTIVE"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME MSGSLNO 
            oParameter = oCommand.Parameters.Add("iMSGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iMSGSLNO

            'ADD IN PARAMETER NAME iUSERSLNO 
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO


            'ADD IN PARAMETER NAME iISACTIVE 
            oParameter = oCommand.Parameters.Add("iISACTIVE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iISACTIVE



            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub


    Public Sub MB_Message_Fonts(ByVal iMSGSLNO As Integer, ByVal iUSERSLNO As Integer, ByVal iFONTS As String)
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleClient.OracleCommand
            oParameter = New OracleClient.OracleParameter

            oCommand.CommandText = "masters.MSG_MSGBOARD_FONTS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME MSGSLNO 
            oParameter = oCommand.Parameters.Add("iMSGSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iMSGSLNO

            'ADD IN PARAMETER NAME iUSERSLNO 
            oParameter = oCommand.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iUSERSLNO


            'ADD IN PARAMETER NAME fonts string 
            oParameter = oCommand.Parameters.Add("iFONTS", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFONTS
            If iFONTS = "" Then
                oParameter.Value = DBNull.Value
            Else
                oParameter.Value = iFONTS
            End If


            oCommand.ExecuteNonQuery()


        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub


    Public Sub PARENT_FILES_Save(ByVal iCORS As String, ByVal iCOLLEGETYPESLNO As Integer, ByVal iCOURSESLNO As Integer, ByVal iFILECATEGORYSLNO As Integer, ByVal iFILECATEGORYNAME As String, ByVal iDESCRIPTION As String, ByVal iFILEPATH As String)
        Try

            oCommand = New OracleClient.OracleCommand

            oParameter = New OracleClient.OracleParameter

            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand.CommandText = "PARENTLOGIN.FILES_URLS_INSERT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iCORS
            oParameter = oCommand.Parameters.Add("iCORS", OracleType.VarChar)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCORS


            'ADD IN PARAMETER NAME iCOLLEGETYPESLNO 
            oParameter = oCommand.Parameters.Add("iCOLLEGETYPESLNO", OracleType.Number, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOLLEGETYPESLNO


            'ADD IN PARAMETER NAME iCOURSESLNO 
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iCOURSESLNO


            'ADD IN PARAMETER NAME iFILECATEGORYSLNO 
            oParameter = oCommand.Parameters.Add("iFILECATEGORYSLNO", OracleType.Number, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFILECATEGORYSLNO


            'ADD IN PARAMETER NAME iFILECATEGORYNAME 
            oParameter = oCommand.Parameters.Add("iFILECATEGORYNAME", OracleType.VarChar, 100)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFILECATEGORYNAME



            'ADD IN PARAMETER NAME iDESCRIPTION  
            oParameter = oCommand.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 200)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iDESCRIPTION


            'ADD IN PARAMETER NAME iFILEPATH  
            oParameter = oCommand.Parameters.Add("iFILEPATH", OracleType.VarChar, 300)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFILEPATH


            oCommand.ExecuteNonQuery()



        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Sub




#End Region


End Class
