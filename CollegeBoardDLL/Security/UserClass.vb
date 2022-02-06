'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 2.0
'   OBJECTIVE                         : This is the Middle layer for UserMethods.
'   ACTIVITY                          : Insert/Update/Delete/Select
'   AUTHOR                            : Srikanth
'   INITIAL BASELINE DATE             : -JAN-2006
'   FINAL BASELINE DATE               : -JAN-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient


Public Class UserClass

#Region "Class Variables"
    Private oConn As OracleConnection 'Connection Object Declaration.
    Private oComm As OracleCommand 'Command Object Declaration.
    Private oTrans As OracleTransaction 'Transaction Object Declaration.
    Private oAdap As OracleDataAdapter 'Adapter Object Declaration.
    Private oParam As OracleParameter 'Parameter Object Declaration.
    Private Ds As DataSet
    Private ConObj As Connection
    Private rtnMessage As String 'Result of the return type.
    Private UserSLNO As Integer
#End Region

#Region "User"

#Region "Methods "

    Public Function GetUserInformation(ByVal USERSLNO As Integer) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "E_M_USER_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output
            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function GetBranchUserTypeInformation(ByVal USERSLNO As Integer, ByVal COMACADEMICSLNO As Integer) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "E_M_USERBRANCHTYPE_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COMACADEMICSLNO

            oParam = oComm.Parameters.Add("DATACUR1", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DATACUR2", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oParam = oComm.Parameters.Add("DATACUR3", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function



#End Region

#Region "Insert/Update Methods"

    Public Function User_Permissions_Save(ByVal DsPer As DataSet, ByVal USERTYPESLNO As Integer) As String
        Try


            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            rtnMessage = Userrights_delete(USERTYPESLNO, oConn, oTrans)

            If rtnMessage <> "SUCCESS" Then
                oTrans.Rollback()
                Return rtnMessage
            End If

            rtnMessage = Userrights_Insert(DsPer, USERTYPESLNO, oConn, oTrans)
            If rtnMessage <> "SUCCESS" Then
                oTrans.Rollback()
                Return rtnMessage
            End If

            oTrans.Commit()
            Return rtnMessage

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Userrights_delete(ByVal USERTYPESLNO As Integer, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("E_M_USERRIGHTS_DELETE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERTYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERTYPESLNO

            oComm.ExecuteNonQuery()
            rtnMessage = "SUCCESS"

            Return rtnMessage

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
            Return "SUCCESS"
        End Try

    End Function
    Public Function Userrights_Insert(ByVal DsPer As DataSet, ByVal USERTYPESLNO As Integer, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As String
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand("E_M_USERRIGHTS_INSERT")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERTYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERTYPESLNO

            oParam = oComm.Parameters.Add("iIDNODE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "IDNODE"

            oParam = oComm.Parameters.Add("iIDPARENTNODE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "IDPARENTNODE"

            oAdap.InsertCommand = oComm
            oAdap.Update(DsPer, DsPer.Tables(0).TableName)

            rtnMessage = "SUCCESS"
            Return rtnMessage

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function User_Save(ByVal Mode As String, ByVal Arr As ArrayList, ByVal DsBranch As DataSet, ByVal DsUserType As DataSet) As String
        Try
            Dim UserSLNO As Integer

            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            If Mode = "New" Then

                UserSLNO = Operators_Insert(Arr, oConn, oTrans)

                If UserSLNO = 0 Then
                    oTrans.Rollback()
                    Return rtnMessage
                End If

                rtnMessage = User_BranchAcademic_Insert(DsBranch, UserSLNO, oConn, oTrans)
                If rtnMessage <> "SUCCESS" Then
                    oTrans.Rollback()
                    Return rtnMessage
                End If
                rtnMessage = User_UserType_Insert(DsUserType, UserSLNO, oConn, oTrans)
                If rtnMessage <> "SUCCESS" Then
                    oTrans.Rollback()
                    Return rtnMessage
                End If

            Else

                rtnMessage = Operators_Update(Arr, oConn, oTrans)
                If rtnMessage <> "SUCCESS" Then
                    oTrans.Rollback()
                    Return rtnMessage
                End If
                rtnMessage = User_BranchAcademic_Insert(DsBranch, Arr(0), oConn, oTrans)
                If rtnMessage <> "SUCCESS" Then
                    oTrans.Rollback()
                    Return rtnMessage
                End If
                rtnMessage = User_UserType_Insert(DsUserType, Arr(0), oConn, oTrans)
                If rtnMessage <> "SUCCESS" Then
                    oTrans.Rollback()
                    Return rtnMessage
                End If

            End If

            oTrans.Commit()
            Return rtnMessage

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function User_Segment_Save(ByVal Mode As String, ByVal Arr As ArrayList, ByVal DsBranch As DataSet, ByVal DsUserType As DataSet, ByVal DsSegment As DataSet) As String
        Try
            Dim UserSLNO As Integer

            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            If Mode = "New" Then

                UserSLNO = Operators_Insert(Arr, oConn, oTrans)

                If UserSLNO = 0 Then
                    oTrans.Rollback()
                    Return rtnMessage
                End If

                rtnMessage = User_BranchAcademic_Insert(DsBranch, UserSLNO, oConn, oTrans)
                If rtnMessage <> "SUCCESS" Then
                    oTrans.Rollback()
                    Return rtnMessage
                End If

                rtnMessage = User_UserType_Insert(DsUserType, UserSLNO, oConn, oTrans)
                If rtnMessage <> "SUCCESS" Then
                    oTrans.Rollback()
                    Return rtnMessage
                End If
                rtnMessage = User_BranchSegment_Insert(DsSegment, UserSLNO, oConn, oTrans)
                If rtnMessage <> "SUCCESS" Then
                    oTrans.Rollback()
                    Return rtnMessage
                End If
            Else

                rtnMessage = Operators_Update(Arr, oConn, oTrans)
                If rtnMessage <> "SUCCESS" Then
                    oTrans.Rollback()
                    Return rtnMessage
                End If
                rtnMessage = User_BranchAcademic_Insert(DsBranch, Arr(0), oConn, oTrans)
                If rtnMessage <> "SUCCESS" Then
                    oTrans.Rollback()
                    Return rtnMessage
                End If

                rtnMessage = User_UserType_Insert(DsUserType, Arr(0), oConn, oTrans)
                If rtnMessage <> "SUCCESS" Then
                    oTrans.Rollback()
                    Return rtnMessage
                End If
                rtnMessage = User_BranchSegment_Insert(DsSegment, Arr(0), oConn, oTrans)
                If rtnMessage <> "SUCCESS" Then
                    oTrans.Rollback()
                    Return rtnMessage
                End If
            End If

            oTrans.Commit()
            Return rtnMessage

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function User_BranchAcademic_Insert(ByVal DsBranch As DataSet, ByVal UserSLNO As Integer, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As String
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand("E_M_USERBRANCH_INSERT")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = UserSLNO

            oParam = oComm.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "BRANCHSLNO"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(DsBranch, DsBranch.Tables(0).TableName)

            rtnMessage = "SUCCESS"
            Return rtnMessage

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function User_BranchSegment_Insert(ByVal DsSegment As DataSet, ByVal UserSLNO As Integer, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As String
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand("E_M_USERBRANCH_SEGMENT_INSERT")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = UserSLNO

            oParam = oComm.Parameters.Add("iSEGMENTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SEGMENTSLNO"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(DsSegment, DsSegment.Tables(0).TableName)

            rtnMessage = "SUCCESS"
            Return rtnMessage

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function User_UserType_Insert(ByVal DsUserType As DataSet, ByVal UserSLNO As Integer, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As String
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand("E_M_USERUSERTYPE_INSERT")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = UserSLNO

            oParam = oComm.Parameters.Add("iUSERTYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "USERTYPESLNO"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(DsUserType, DsUserType.Tables(0).TableName)

            rtnMessage = "SUCCESS"
            Return rtnMessage

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Operators_Insert(ByVal Arr As ArrayList, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As Integer
        Try
            oComm = New OracleCommand("E_F_USER_INSERT")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERID", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iPASSWORD", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iCREATEDATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iFROMDATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iTOFATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)


            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iUSERFORM", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oParam = oComm.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            oComm.Parameters.Add(New OracleParameter("oRtnValid", OracleType.Number)).Direction = ParameterDirection.ReturnValue

            oComm.ExecuteNonQuery()

            UserSLNO = oComm.Parameters("oRtnValid").Value.ToString

            Return UserSLNO

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Operators_Update(ByVal Arr As ArrayList, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As String
        Try
            oComm = New OracleCommand("E_M_USER_UPDATE")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iUSERID", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iPASSWORD", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iCREATEDATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iFROMDATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iTOFATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oComm.ExecuteNonQuery()

            rtnMessage = "SUCCESS"

            Return rtnMessage

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Operators_Delete(ByVal USERSLNO As Integer) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("E_M_USER_DELETE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERSLNO

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"

            Return rtnMessage

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
            Return "SUCCESS"
        End Try
    End Function

#Region "PR TO DELETE"
    Public Function insertMaxNode1(ByVal idnode As Integer, ByVal idparentnode As Integer, ByVal nodecaption As String, ByVal nodetype As Integer, ByVal nodeaction As String)
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand("insert into T_TREECONTENTS_MT(IDNode, IDParentNode, NodeCaption, isparent, NodeAction) values (" & idnode & "," & idparentnode & ",'" & nodecaption & "'," & nodetype & ",'" & nodeaction & "')", oConn)
            oComm.ExecuteNonQuery()

        Catch Oex As OracleException
            Throw Oex

        Catch ex As Exception
            Throw ex

        End Try

    End Function
    Public Function GetMaxNode() As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet
            oConn = ConObj.GetConnection()
            oAdap = New OracleDataAdapter("SELECT NVL(MAX(IDNODE),0)+1 AS MAXID FROM T_TREECONTENTS_MT ", oConn)
            oAdap.Fill(Ds)
        Catch Oex As OracleException
            Throw Oex

        Catch ex As Exception
            Throw ex

        End Try
        Return Ds
    End Function
#End Region


    Public Function insertMaxNode(ByVal IDPARENTNODE As Integer, ByVal NODECAPTION As String, ByVal ISPARENT As Integer, ByVal NODEACTION As String)
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand("E_M_TC_MAXNODE_INSERT")
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iIDPARENTNODE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = IDPARENTNODE

            oParam = oComm.Parameters.Add("iNODECAPTION", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = NODECAPTION

            oParam = oComm.Parameters.Add("iISPARENT", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ISPARENT

            oParam = oComm.Parameters.Add("iNODEACTION", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = NODEACTION
            oComm.ExecuteNonQuery()

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function insertModuleUsers(ByVal username As String)
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand("INSERT INTO E_USERTYPE_MT(USERTYPESLNO,NAME) VALUES((SELECT NVL(MAX(USERTYPESLNO),0)+1 FROM E_USERTYPE_MT) ,'" & username & "') ", oConn)
            oComm.ExecuteNonQuery()

        Catch Oex As OracleException
            Throw Oex

        Catch ex As Exception
            Throw ex


        End Try
    End Function
    Public Function GetUserAccessTree(ByVal USERTYPESLNO As Integer) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter

            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "E_M_USERPERMISSIONSCHECK_FETCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERTYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERTYPESLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output
            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function



#Region " Many To Many ExamBranch Users"

    Public Function MToMExamBranchUser_Save(ByVal DsBranch As DataSet) As String
        Try
            Dim UserSLNO As Integer

            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()


            MToMExamBranchUser_Delete(DsBranch, oConn, oTrans)

            rtnMessage = MToMExamBranchUser_Insert(DsBranch, oConn, oTrans)
            If rtnMessage <> "SUCCESS" Then
                oTrans.Rollback()
                Return rtnMessage
            End If




            oTrans.Commit()
            Return rtnMessage

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function MToMExamBranchUser_Insert(ByVal DsBranch As DataSet, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As String
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand("E_M_USERBRANCH_INSERT")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "USERSLNO"

            oParam = oComm.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "BRANCHSLNO"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(DsBranch, DsBranch.Tables(0).TableName)

            rtnMessage = "SUCCESS"
            Return rtnMessage

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function MToMExamBranchUser_Delete(ByVal DsBranch As DataSet, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As Integer
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand("E_M_USERBRANCH_DELETE")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "USERSLNO"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(DsBranch, DsBranch.Tables(1).TableName)


        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


#End Region

#End Region

#Region "Login Check"

    Public Function CheckUser(ByVal USERID As String, ByVal PASSWORD As String, ByVal iCOMACADEMICSLNO As Integer, ByVal iIPADDR As String, ByVal iTXT1 As String, ByVal iTXT2 As String, ByVal iTXT3 As String) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "E_M_USERLOGIN_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERID", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERID

            oParam = oComm.Parameters.Add("iPASSWORD", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PASSWORD

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO


            oParam = oComm.Parameters.Add("iIPADDR", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iIPADDR




            oParam = oComm.Parameters.Add("iTXT1", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iTXT1


            oParam = oComm.Parameters.Add("iTXT2", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iTXT2

            oParam = oComm.Parameters.Add("iTXT3", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iTXT3



            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output
            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function CheckAdminUser(ByVal USERID As String, ByVal PASSWORD As String, ByVal iCOMACADEMICSLNO As Integer, ByVal iIPADDR As String, ByVal iTXT1 As String, ByVal iTXT2 As String, ByVal iTXT3 As String) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "E_M_USERLOGIN_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERID", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERID

            oParam = oComm.Parameters.Add("iPASSWORD", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PASSWORD

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO


            oParam = oComm.Parameters.Add("iIPADDR", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iIPADDR




            oParam = oComm.Parameters.Add("iTXT1", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iTXT1


            oParam = oComm.Parameters.Add("iTXT2", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iTXT2

            oParam = oComm.Parameters.Add("iTXT3", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iTXT3



            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output
            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function CheckPasswd(ByVal USERSLNO As Integer, ByVal OPASSWD As String, ByVal NPASSWD As String) As String

        Try
            Dim rtnMsg As String

            ConObj = New Connection
            oComm = New OracleCommand


            oConn = ConObj.GetConnection()
            oComm.CommandText = "E_F_USERPASSWORD_CHECK"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERSLNO

            oParam = oComm.Parameters.Add("iOPASSWD", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = OPASSWD

            oParam = oComm.Parameters.Add("iNPASSWD", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = NPASSWD

            oComm.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 15)).Direction = ParameterDirection.ReturnValue

            oComm.ExecuteNonQuery()

            rtnMsg = oComm.Parameters("oRtnValid").Value.ToString

            Return rtnMsg

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function UserLogin(ByVal USERSLNO As String, ByVal APPLICATIONSLNO As Integer, ByVal USERID As String, ByVal COMACADEMICSLNO As Integer) As Integer

        Try
            Dim rtnMsg As String

            ConObj = New Connection
            oComm = New OracleCommand


            oConn = ConObj.GetConnection()
            oComm.CommandText = "MASTERS.F_USERLOGTIME_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERSLNO


            oParam = oComm.Parameters.Add("iAPPLICATIONSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = APPLICATIONSLNO

            oParam = oComm.Parameters.Add("iUSERID", OracleType.VarChar, 20)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERID

            oParam = oComm.Parameters.Add("iAY_FIN_SLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COMACADEMICSLNO



            oComm.Parameters.Add(New OracleParameter("UserLogin", OracleType.Number)).Direction = ParameterDirection.ReturnValue

            oComm.ExecuteNonQuery()

            rtnMsg = oComm.Parameters("UserLogin").Value

            Return rtnMsg

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function UserLogOut(ByVal USERLOGSLNO As Integer) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("MASTERS.F_USERLOGTIME_UPDATE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iUSERLOGSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERLOGSLNO

            oComm.Parameters.Add(New OracleParameter("UserLogin", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"
            Return rtnMessage

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function UserAccess(ByVal pUSERSLNO As Integer, ByVal pLOGSLNO As Integer, ByVal pFORMNAME As String) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("EXAM_USER_ACCESS")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pUSERSLNO

            oParam = oComm.Parameters.Add("iLOGSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pLOGSLNO

            oParam = oComm.Parameters.Add("iFORMNAME", OracleType.VarChar, 200)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pFORMNAME

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"
            Return rtnMessage

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

#End Region

#Region "Fill Tree User Wise"

    Public Function FillTreeUserWise(ByVal USERSLNO As Integer, ByVal COMACADEMICSLNO As Integer) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "E_M_TC_USERWISETREE_SELECT"

            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COMACADEMICSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output
            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

#End Region

#Region "User Type"

#Region "Select Methods"

    Public Function UserType_Select(ByVal PSLNO As Long) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "E_M_USERTYPE_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERTYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PSLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output
            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

#End Region

#Region "Insert Update Delete Methods"

    Public Function UserType_Insert(ByVal Arr As ArrayList) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("E_M_USERTYPE_INSERT")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"

            Return rtnMessage

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function UserType_Update(ByVal Arr As ArrayList) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("E_M_USERTYPE_UPDATE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iUSERTYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iDESCRIPTION", OracleType.VarChar, 250)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"
            Return rtnMessage

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function UserType_Delete(ByVal PSLNO As Long) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("E_M_USERTYPE_DELETE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERTYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = PSLNO

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"

            Return rtnMessage

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

    Public Function Tree_Update(ByVal parid As Integer, ByVal nodedesc As String, ByVal nodetype As Integer, ByVal Filepath As String) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("E_M_TREE_UPDATE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iParid", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = parid

            oParam = oComm.Parameters.Add("inodeDesc", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = nodedesc

            oParam = oComm.Parameters.Add("inodeType", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = nodetype

            oParam = oComm.Parameters.Add("iFilepath", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Filepath

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"
            Return rtnMessage

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Function

#End Region

#Region " Fill User Types "

    Public Function User_Types_Fill(ByVal USERSLNO As Integer, ByVal COMACADEMICSLNO As Integer, ByVal USERTYPESLNO As Integer) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "E_USERTYPES_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COMACADEMICSLNO

            oParam = oComm.Parameters.Add("iUSERTYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERTYPESLNO

            oParam = oComm.Parameters.Add("DATACUR", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output
            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

#End Region

#End Region

#Region " Many To Many User Wise Combination Key "

    Public Function UserCombinationKey_Save(ByVal DsBranch As DataSet) As String
        Try
            Dim UserSLNO As Integer

            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()


            UserCombinationKey_Delete(DsBranch, oConn, oTrans)

            rtnMessage = UserCombinationKey_Insert(DsBranch, oConn, oTrans)
            If rtnMessage <> "SUCCESS" Then
                oTrans.Rollback()
                Return rtnMessage
            End If

            oTrans.Commit()
            Return rtnMessage

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Private Function UserCombinationKey_Insert(ByVal DsBranch As DataSet, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As String
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand("EXAM_USERCOMBINATIONKEY_INSERT")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "USERSLNO"

            oParam = oComm.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMBINATIONKEY"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(DsBranch, DsBranch.Tables(0).TableName)

            rtnMessage = "SUCCESS"
            Return rtnMessage

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function UserCombinationKey_Delete(ByVal DsBranch As DataSet, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As Integer
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand("EXAM_USERCOMBINATIONKEY_DELETE")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "USERSLNO"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(DsBranch, DsBranch.Tables(1).TableName)


        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function UserCombinationKey_Delete(ByVal iUSERSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer, ByVal iCOMBINATIONKEY As Integer) As Integer
        Try

            ConObj = New Connection
            oComm = New OracleCommand

            oConn = ConObj.GetConnection()
            oComm.CommandText = "EXAM_USERCOMBKEY_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure



            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iUSERSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO


            oParam = oComm.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMBINATIONKEY

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


    Public Function GetCombinationsInformation(ByVal USERSLNO As Integer, ByVal COMACADEMICSLNO As Integer) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "E_M_USERCOMBS_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COMACADEMICSLNO

            oParam = oComm.Parameters.Add("DATACUR1", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

#End Region

#Region "Combination Key Wise Key Obejections"

    Public Function CombinationKeyObjections_Save(ByVal DsBranch As DataSet) As String
        Try
            Dim UserSLNO As Integer

            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()


            CombinationKeyObjections_Delete(DsBranch, oConn, oTrans)

            rtnMessage = CombinationKeyObjections_Insert(DsBranch, oConn, oTrans)
            If rtnMessage <> "SUCCESS" Then
                oTrans.Rollback()
                Return rtnMessage
            End If

            oTrans.Commit()
            Return rtnMessage

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Private Function CombinationKeyObjections_Insert(ByVal DsBranch As DataSet, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As String
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand("EXAM_KEYOBJ_COMB_INSERT")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "USERSLNO"

            oParam = oComm.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMBINATIONKEY"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(DsBranch, DsBranch.Tables(0).TableName)

            rtnMessage = "SUCCESS"
            Return rtnMessage

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function CombinationKeyObjections_Delete(ByVal DsBranch As DataSet, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As Integer
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand("EXAM_KEYOBJ_COMB__DELETE")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "USERSLNO"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(DsBranch, DsBranch.Tables(1).TableName)


        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CombinationsKeyObjections_Delete(ByVal iUSERSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer, ByVal iCOMBINATIONKEY As Integer) As Integer
        Try

            ConObj = New Connection
            oComm = New OracleCommand

            oConn = ConObj.GetConnection()
            oComm.CommandText = "EXAM_KEYOBJ_COMBS_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure



            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iUSERSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO


            oParam = oComm.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMBINATIONKEY

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

    Public Function GetCombinationsKeyObjections(ByVal USERSLNO As Integer, ByVal COMACADEMICSLNO As Integer) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "EXAM_KEYOBJ_COMB_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COMACADEMICSLNO

            oParam = oComm.Parameters.Add("DATACUR1", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

#End Region

#Region " Mac Address "

    Public Function ClientMac_Save(ByVal DsMac As DataSet) As String
        Try


            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oAdap = New OracleDataAdapter
            oComm = New OracleCommand("MAC_USERMAC_INSERT")

            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "USERSLNO"


            oParam = oComm.Parameters.Add("iMACADD", OracleType.VarChar, 25)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "MACADD"

            oParam = oComm.Parameters.Add("iADMOREXAM", OracleType.Char)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "ADMOREXAM"

            oAdap.InsertCommand = oComm
            oAdap.Update(DsMac, DsMac.Tables(0).TableName)

            oTrans.Commit()

            Return " 1 "

        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function ClientMac_Delete(ByVal USERSLNO As Integer) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("MAC_USERMAC_DELETE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERSLNO

            oParam = oComm.Parameters.Add("iADMOREXAM", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = "E"

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"

            Return rtnMessage

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
            Return "SUCCESS"
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function


    Public Function ClientMac_Delete(ByVal USERSLNO As Integer, ByVal BYUSERSLNO As Integer) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("MAC_USERMAC_DELETE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERSLNO

            oParam = oComm.Parameters.Add("iADMOREXAM", OracleType.VarChar)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = "E"

            oParam = oComm.Parameters.Add("iBYUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = BYUSERSLNO

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"

            Return rtnMessage

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
            Return "SUCCESS"
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

#End Region

#Region " Emp Mapping To Exam Branch"

    Public Sub EmpEbMapping(ByVal iUserslno As Integer, ByVal IEmpslno As Integer)
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand(" UPDATE EXAM_USER_MT SET EMPSLNO=" & IEmpslno & " WHERE USERSLNO=" & iUserslno)
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.Text

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"



        Catch oex As OracleException
            oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try

    End Sub

#End Region

#Region " Many To Many User Wise Staff Combination Key "

    Public Function Staff_UserCombinationKey_Save(ByVal DsBranch As DataSet) As String
        Try
            Dim UserSLNO As Integer

            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()


            Staff_UserCombinationKey_Delete(DsBranch, oConn, oTrans)

            rtnMessage = Staff_UserCombinationKey_Insert(DsBranch, oConn, oTrans)
            If rtnMessage <> "SUCCESS" Then
                oTrans.Rollback()
                Return rtnMessage
            End If

            oTrans.Commit()
            Return rtnMessage

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Private Function Staff_UserCombinationKey_Insert(ByVal DsBranch As DataSet, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As String
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand("STAFF_USERCOMBKEY_INSERT")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "USERSLNO"

            oParam = oComm.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMBINATIONKEY"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(DsBranch, DsBranch.Tables(0).TableName)

            rtnMessage = "SUCCESS"
            Return rtnMessage

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function Staff_UserCombinationKey_Delete(ByVal DsBranch As DataSet, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As Integer
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand("STAFF_USERCOMACC_DELETE")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "USERSLNO"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(DsBranch, DsBranch.Tables(1).TableName)


        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Staff_UserCombinationKey_Delete(ByVal iUSERSLNO As Integer, ByVal iCOMACADEMICSLNO As Integer, ByVal iCOMBINATIONKEY As Integer) As Integer
        Try

            ConObj = New Connection
            oComm = New OracleCommand

            oConn = ConObj.GetConnection()
            oComm.CommandText = "STAFF_USERCOMBKEY_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure



            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iUSERSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMACADEMICSLNO


            oParam = oComm.Parameters.Add("iCOMBINATIONKEY", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iCOMBINATIONKEY

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

#End Region

#Region "SUBBATHWISE USER PERMISSIONS"
    Public Function UserSubbatch_Save(ByVal DsBranch As DataSet) As String
        Try
            Dim UserSLNO As Integer

            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            rtnMessage = UserSubbatch_Insert(DsBranch, oConn, oTrans)
            If rtnMessage <> "SUCCESS" Then
                oTrans.Rollback()
                Return rtnMessage
            End If

            oTrans.Commit()
            Return rtnMessage

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Private Function UserSubbatch_Insert(ByVal DsBranch As DataSet, ByVal Conn As OracleConnection, ByVal Tran As OracleTransaction) As String
        Try
            oAdap = New OracleDataAdapter
            oComm = New OracleCommand("EXAM_USERSUBBATCH_INSERT")
            oComm.Connection = Conn
            oComm.Transaction = Tran
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "USERSLNO"

            oParam = oComm.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COURSESLNO"

            oParam = oComm.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "GROUPSLNO"

            oParam = oComm.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "BATCHSLNO"

            oParam = oComm.Parameters.Add("iSUBBATCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "SUBBATCHSLNO"

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.SourceColumn = "COMACADEMICSLNO"

            oAdap.InsertCommand = oComm
            oAdap.Update(DsBranch, DsBranch.Tables(0).TableName)

            rtnMessage = "SUCCESS"
            Return rtnMessage

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function UserSubbatch_Delete(ByVal iEUSBMAPSLNO As Integer) As Integer
        Try

            ConObj = New Connection
            oComm = New OracleCommand

            oConn = ConObj.GetConnection()
            oComm.CommandText = "EXAM_USERSUBBATCH_DELETE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure



            oParam = oComm.Parameters.Add("iEUSBMAPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iEUSBMAPSLNO


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

    Public Function GetUserSubbatchInformation(ByVal USERSLNO As Integer, ByVal COURSESLNO As Integer, ByVal GROUPSLNO As Integer, ByVal COMACADEMICSLNO As Integer) As DataSet
        Try
            ConObj = New Connection
            oComm = New OracleCommand
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oConn = ConObj.GetConnection()
            oComm.CommandText = "E_M_USERSUBBATCH_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERSLNO

            oParam = oComm.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COURSESLNO

            oParam = oComm.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = GROUPSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COMACADEMICSLNO

            oParam = oComm.Parameters.Add("DATACUR1", OracleType.Cursor)
            oParam.Direction = ParameterDirection.Output

            oAdap.SelectCommand = oComm

            oAdap.Fill(Ds)

            Return Ds

        Catch oex As OracleException
            Throw oex
        Catch ex As Exception
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function
#End Region

#Region " User Mac & vsat Transfors"

    Public Function UserMacVastTrans(ByVal FMUBE As String, ByVal USERSLNO As Integer) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("EXAM_USERREG_UPDATE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            Dim ASR() As String
            ASR = FMUBE.Split(",")

            oParam = oComm.Parameters.Add("iFMUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Val(ASR(2).ToString)

            oParam = oComm.Parameters.Add("iBIOEMPNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Val(ASR(1).ToString)


            oParam = oComm.Parameters.Add("iEMPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Val(ASR(0).ToString)

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = USERSLNO


            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"

            Return rtnMessage

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function UserRegistrationTrans(ByVal TOUSERSLNO As Integer, ByVal FROMUSERSLNO As Integer, ByVal NOOFHOURS As Integer) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("EXAM_USERREGTRANS_INSERT")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iTOUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = TOUSERSLNO

            oParam = oComm.Parameters.Add("iFROMUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = FROMUSERSLNO

            oParam = oComm.Parameters.Add("iNOOFHOURS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = NOOFHOURS

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"

            Return rtnMessage

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function UserRegistrationRevents(ByVal iUSERSLNO As Integer) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("EXAM_USERREGTRANS_REVENTS")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iUSERSLNO


            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"

            Return rtnMessage

        Catch Oex As OracleException
            oTrans.Rollback()
            Throw Oex
        Catch ex As Exception
            oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

#End Region

End Class
