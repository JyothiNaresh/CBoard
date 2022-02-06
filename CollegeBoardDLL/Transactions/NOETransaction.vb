Public Class NOETransaction

#Region "Class Variables"

    Private oConn As OracleConnection 'Connection Object Declaration.
    Private oComm As OracleCommand 'Command Object Declaration.
    Private oTrans As OracleTransaction 'Transaction Object Declaration.
    Private oAdap As OracleDataAdapter 'Adapter Object Declaration.
    Private oParam As OracleParameter 'Parameter Object Declaration.
    Private Ds As DataSet
    Private ConObj As Connection
    Private rtnMessage As String 'Result of the return type.
    Private rtnVal As Integer
    Dim Result As String

#End Region

    Public Function Student_PhotoUpLoad(ByVal Ds As DataSet) As String
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            oConn = ConObj.GetConnection() 'establishing the Connection .
            oComm.CommandText = "P_STUDENTPHOTO_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSADMSLNO
            oParam = oComm.Parameters.Add("iBITSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "BITSLNO"

            ''ADD IN PARAMETER NAME iFILEPATH
            'oParam = oComm.Parameters.Add("iFILEPATH", OracleType.VarChar, 250)
            'oParam.Direction = ParameterDirection.Input
            'oParam.SourceColumn = "FILEPATH"

            oAdap.InsertCommand = oComm
            oAdap.Update(Ds.Tables(0))

            Return "Records Saved Successfully"

        Catch Oex As OracleException
            rtnMessage = Oex.Message
            Throw Oex
        Catch ex As Exception
            rtnMessage = ex.Message
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
        Return rtnMessage

    End Function

    'Added by P.Venu on 15.07.2011 For Objections-Module Purpose

    Public Function OBJECTIONEXAMNAME_INSERT(ByVal Arr As ArrayList) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm.CommandText = "OBJECTION_EXAMNAME_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iOBJEXAMNAME", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iOBJDESCRIPTION", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iOBJEXAMSTATUS", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function OBJECTIONTESTDATE_INSERT(ByVal Arr As ArrayList) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm.CommandText = "OBJECTION_TESTDATE_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iOBJEXAMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iOBJTESTDATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iOBJTESTDESC", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iOBJCOMACADEMICSLNO", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iSUBJECTS", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iQFROM", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iQTO", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iOBJEXAMPAPERSETTER", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function OBJECTION_INSERT(ByVal Vdt As DataSet, ByVal ArrMt As ArrayList) As String

        Dim rtnString As Integer
        Dim RtnVal As Integer
        Try
            Dim setResult As String

            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oTrans = oConn.BeginTransaction()

            RtnVal = OBJECTION_MTINSERT(ArrMt)

            rtnString = OBJECTION_DTINSERT(Vdt, RtnVal)

            oTrans.Commit()

            Return rtnString

        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function OBJECTION_MTINSERT(ByVal ArrMt As ArrayList) As Integer
        Try
            oComm = New OracleCommand
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm.CommandText = "OBJECTIONS_INSERT_MT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'OBJEBSLNO
            oParam = oComm.Parameters.Add("iOBJEBSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(0)

            'OBJEBLANDLINE
            oParam = oComm.Parameters.Add("iOBJEBLANDLINE", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(1)

            'OBJPRINCE
            oParam = oComm.Parameters.Add("iOBJPRINCE", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(2)

            'OBJPRINCEMOB
            oParam = oComm.Parameters.Add("IOBJPRINCEMOB", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(3)

            'OBJEXAMSLNO
            oParam = oComm.Parameters.Add("iOBJEXAMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(4)

            'OBJTESTSLNO
            oParam = oComm.Parameters.Add("IOBJTESTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(5)

            'OBJCORRECTIONS
            oParam = oComm.Parameters.Add("IOBJCORRECTIONS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(6)

            'OBJCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iOBJCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(7)

            'OBJCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iOBJEXAMPAPERSETTER", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(8)

            oComm.Parameters.Add(New OracleParameter("SeqMt", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()

            Result = oComm.Parameters("SeqMt").Value

            Return Result

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function OBJECTION_DTINSERT(ByVal Ds As DataSet, ByVal Mtslno As Integer) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New Connection
            oAdap = New OracleDataAdapter
            oConn = ConObj.GetConnection()

            oComm.CommandText = "OBJECTIONS_INSERT_DT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'OBJTESTSLNO
            oParam = oComm.Parameters.Add("iOBJTESTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJTESTSLNO"

            'OBJMTSLNO
            oParam = oComm.Parameters.Add("iOBJMTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Mtslno

            'OBJSUBJECTSLNO
            oParam = oComm.Parameters.Add("iOBJSUBJECTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJSUBJECTSLNO"

            'OBJQUESTIONNO
            oParam = oComm.Parameters.Add("iOBJQUESTIONNO", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJQUESTIONNO"

            'OBJGIVENKEY
            oParam = oComm.Parameters.Add("iOBJGIVENKEY", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJGIVENKEY"

            'OBJCORRECTKEY
            oParam = oComm.Parameters.Add("iOBJCORRECTKEY", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJCORRECTKEY"

            'OBJREMAKRS
            oParam = oComm.Parameters.Add("iOBJREMARKS", OracleType.VarChar, 1000)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJREMARKS"

            'OBJLECTURER
            oParam = oComm.Parameters.Add("iOBJLECTURER", OracleType.VarChar, 25)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJLECTURER"

            'IOBJLECTMOBILE
            oParam = oComm.Parameters.Add("iOBJLECTMOBILE", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJLECTMOBILE"

            'OBJCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iOBJCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJCOMACADEMICSLNO"

            'QUESTIONNO
            oParam = oComm.Parameters.Add("IQUESTIONNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OQUESTIONNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(Ds, "GridData")

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function OBJECTION_FINALKEYINSERT(ByVal Ds As DataSet) As Integer
        Try

            oComm = New OracleCommand
            ConObj = New Connection
            oAdap = New OracleDataAdapter
            oConn = ConObj.GetConnection()

            oComm.CommandText = "OBJECTIONS_FINALKEY_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'OBJUSERSLNO
            oParam = oComm.Parameters.Add("IUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "USERSLNO"

            'OBJTESTSLNO
            oParam = oComm.Parameters.Add("IOBJTESTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJTESTSLNO"

            'OBJEXAMPAPERSETTER
            oParam = oComm.Parameters.Add("IOBJEXAMPAPERSETTER", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJEXAMPAPERSETTER"

            'OBJSUBJECTSLNO
            oParam = oComm.Parameters.Add("IOBJSUBJECTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJSUBJECTSLNO"

            'OBJQUESTIONNO
            oParam = oComm.Parameters.Add("IOBJQUESTIONNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJQUESTIONNO"

            'OBJQSTN
            oParam = oComm.Parameters.Add("IOBJQSTN", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJQSTN"

            'OBJGIVENKEY
            oParam = oComm.Parameters.Add("IOBJGIVENKEY", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJGIVENKEY"

            'OBJCOUNT
            oParam = oComm.Parameters.Add("IOBJCOUNT", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJCOUNT"

            'OBJSTATUS
            oParam = oComm.Parameters.Add("IOBJSTATUS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJSTATUS"

            'OBJACTION
            oParam = oComm.Parameters.Add("IOBJACTION", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJACTION"

            'OBJFINALKEY
            oParam = oComm.Parameters.Add("IOBJFINALKEY", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJFINALKEY"

            'OBJREMARKS
            oParam = oComm.Parameters.Add("IOBJREMARKS", OracleType.VarChar, 500)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJREMARKS"

            'OBJCOMACADEMICSLNO
            oParam = oComm.Parameters.Add("iOBJCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "OBJCOMACADEMICSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(Ds, "GridData")

            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function ExamObjLock(ByVal iUSERSLNO As Integer, ByVal EbArrlst As ArrayList, ByVal EbArrlstUnlock As ArrayList) As Integer
        Try
            Dim I As Integer
            ConObj = New Connection
            oConn = ConObj.GetConnection
            oTrans = oConn.BeginTransaction()

            If Not EbArrlst Is Nothing Then
                For I = 0 To EbArrlst.Count - 1
                    ObjLock(iUSERSLNO, Val(EbArrlst(I).ToString), oConn, oTrans)
                Next
            End If

            If Not EbArrlstUnlock Is Nothing Then
                For I = 0 To EbArrlstUnlock.Count - 1
                    ObjUnLock(iUSERSLNO, Val(EbArrlstUnlock(I).ToString), oConn, oTrans)
                Next
            End If

            oTrans.Commit()
            Return 1
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    'Added by P.Venu on 24.08.2011 For Student PhoneEmail Update

    Public Function STUDENT_PHONEEMAIL_UPDATE(ByVal ArrMt As ArrayList) As Integer
        Try
            oComm = New OracleCommand
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm.CommandText = "STUDETN_PHONEEMAIL_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("IADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(0)

            oParam = oComm.Parameters.Add("ICOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(1)

            oParam = oComm.Parameters.Add("IPHONERES", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(2)

            oParam = oComm.Parameters.Add("IPHONEOFF", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(3)

            oParam = oComm.Parameters.Add("IMOBILE1", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(4)

            oParam = oComm.Parameters.Add("IMOBILE2", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(5)

            oParam = oComm.Parameters.Add("IEMAIL", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ArrMt(6)

            oComm.ExecuteNonQuery()
            Return 1

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Private Sub ObjLock(ByVal iUSERSLNO As Integer, ByVal iDEXAMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter

            oComm.CommandText = "OBJECTION_EXAMLOCK"
            oComm.Connection = pConn
            oComm.CommandType = CommandType.StoredProcedure
            oComm.Transaction = pTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParam = oComm.Parameters.Add("iOBJUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iUSERSLNO

            oParam = oComm.Parameters.Add("iOBJTESTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDEXAMSLNO

            oComm.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ObjUnLock(ByVal iUSERSLNO As Integer, ByVal iDEXAMSLNO As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction)
        Try

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter

            oComm.CommandText = "OBJECTION_UNEXAMLOCK"
            oComm.Connection = pConn
            oComm.CommandType = CommandType.StoredProcedure
            oComm.Transaction = pTrans

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParam = oComm.Parameters.Add("iOBJUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iUSERSLNO

            oParam = oComm.Parameters.Add("iOBJTESTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDEXAMSLNO

            oComm.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ObjNilMistakes(ByVal iUSERSLNO As Integer, ByVal iDEXAMSLNO As Integer, ByVal ICOMACADEMICSLNO As Integer, ByVal ISMS As Integer) As Integer
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection

            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter

            oComm.CommandText = "OBJECTIONS_NILMISTAKESSMS"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iDEXAMSLNO
            oParam = oComm.Parameters.Add("iOBJUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iUSERSLNO

            oParam = oComm.Parameters.Add("iOBJTESTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iDEXAMSLNO

            oParam = oComm.Parameters.Add("iOBJCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ICOMACADEMICSLNO

            oParam = oComm.Parameters.Add("iOBJSMS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ISMS

            oComm.ExecuteNonQuery()

            Return 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function OBJECTION_EXAM_LOCK(ByVal Ds As DataSet) As Integer
    '    Try

    '        oComm = New OracleCommand
    '        ConObj = New Connection
    '        oAdap = New OracleDataAdapter
    '        oConn = ConObj.GetConnection()

    '        oComm.CommandText = "OBJECTION_EXAMLOCK"
    '        oComm.Connection = oConn
    '        oComm.CommandType = CommandType.StoredProcedure

    '        'OBJUSERSLNO
    '        oParam = oComm.Parameters.Add("IUSERSLNO", OracleType.Number)
    '        oParam.Direction = ParameterDirection.Input
    '        oParam.SourceColumn = "USERSLNO"

    '        'OBJTESTSLNO
    '        oParam = oComm.Parameters.Add("IOBJTESTSLNO", OracleType.Number)
    '        oParam.Direction = ParameterDirection.Input
    '        oParam.SourceColumn = "OBJTESTSLNO"

    '        oAdap.UpdateCommand = oComm
    '        oAdap.Update(Ds, "GridData")

    '        Return 1

    '    Catch Oex As OracleException
    '        Throw Oex
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If Not ConObj Is Nothing Then ConObj.Free()
    '    End Try
    'End Function

    'Public Function OBJECTION_EXAM_LOCK(ByVal ds As DataSet) As Integer
    '    Try
    '        oComm = New OracleCommand
    '        ConObj = New Connection
    '        oAdap = New OracleDataAdapter
    '        oConn = ConObj.GetConnection()

    '        oComm.CommandText = "OBJECTION_EXAMLOCK"
    '        oComm.Connection = oConn
    '        oComm.CommandType = CommandType.StoredProcedure

    '        'OBJUSERSLNO
    '        oParam = oComm.Parameters.Add("IUSERSLNO", OracleType.Number)
    '        oParam.Direction = ParameterDirection.Input
    '        oParam.SourceColumn = "USERSLNO"

    '        'OBJTESTSLNO
    '        oParam = oComm.Parameters.Add("IOBJTESTSLNO", OracleType.Number)
    '        oParam.Direction = ParameterDirection.Input
    '        oParam.SourceColumn = "OBJTESTSLNO"

    '        oAdap.InsertCommand = oComm
    '        oAdap.Update(ds, "GridData")

    '        Return 1

    '    Catch Oex As OracleException
    '        Throw Oex
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If Not ConObj Is Nothing Then ConObj.Free()
    '    End Try
    'End Function

End Class
