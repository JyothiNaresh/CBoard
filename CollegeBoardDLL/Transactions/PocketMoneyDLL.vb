Imports System.Data.OracleClient

Public Class PocketMoneyDLL

#Region "Class Variables"

    Private oConn As OracleConnection 'Connection Object Declaration.
    Private oComm As OracleCommand 'Command Object Declaration.
    Private oTrans As OracleTransaction 'Transaction Object Declaration.
    Private oAdap As OracleDataAdapter 'Adapter Object Declaration.
    Private oParam As OracleParameter 'Parameter Object Declaration.
    Private Ds As DataSet
    Private ConObj As Connection
    Private rtnMessage As String
    Private ReturnAddressSlno As Long
#End Region

#Region "Fetch Methods"

    Public Function FillBranchUserWise_Fetch(ByVal COMACADEMICSLNO As Integer, ByVal UserSLNO As Integer) As Data.DataSet
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "USERWISEEB"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = UserSLNO

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

    Public Function FillBranchUserWise_M_Fetch(ByVal COMACADEMICSLNO As Integer, ByVal UserSLNO As Integer, ByVal STATESLNO As Integer) As Data.DataSet
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "M_USERWISEBRANCH_M_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = UserSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COMACADEMICSLNO

            oParam = oComm.Parameters.Add("iSTATESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = STATESLNO


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

    Public Function FillBranchUser_TYPE_Fetch(ByVal COMACADEMICSLNO As Integer, ByVal UserSLNO As Integer, ByVal STATESLNO As Integer, ByVal COLLEGETYPESLNO As Integer) As Data.DataSet
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "USERWISEBRANCH_TYPE_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = UserSLNO

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COMACADEMICSLNO

            oParam = oComm.Parameters.Add("iSTATESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = STATESLNO

            oParam = oComm.Parameters.Add("iCOLLEGETYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COLLEGETYPESLNO


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

    Public Function PocketMoney_Search(ByVal COMACADEMICSLNO As Integer, ByVal ADMSNO As Integer, ByVal BRANCHSLNO As Integer)
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "POCKETMONEY_SEARCH"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = COMACADEMICSLNO

            oParam = oComm.Parameters.Add("iADMSNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = ADMSNO

            oParam = oComm.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = BRANCHSLNO

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

    Public Function DateWiseFeeCollection_Fetch(ByVal Fromdate As Date, ByVal Todate As Date) As Data.DataSet
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm = New OracleCommand
            oParam = New OracleParameter
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "P_DATEWISEFEE_SELECT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iFROMDADTE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Fromdate

            oParam = oComm.Parameters.Add("iTODATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Todate

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

#Region "Insert Methods"

    Public Function PocketMoney_Deposit_Insert(ByVal Arr As ArrayList) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("POCKETMONEY_SAVE")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            '''''''''''''''''''''''''' 1 ''''''''''''''''''''''''''''''

            oParam = oComm.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iCOLLEGESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iPAYMODETYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iTRANSDATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            '''''''''''''''''''''''''' 2 ''''''''''''''''''''''''''''''

            oParam = oComm.Parameters.Add("iAMT", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iTYPE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            oParam = oComm.Parameters.Add("iREMARKS", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            oParam = oComm.Parameters.Add("iCHEQUE_DD_NO", OracleType.VarChar, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(10)

            oParam = oComm.Parameters.Add("iCHEQUE_DD_DATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(11)

            oParam = oComm.Parameters.Add("iBANKNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(12)

            oParam = oComm.Parameters.Add("iBRANCHNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(13)

            oComm.Parameters.Add(New OracleParameter("oRtnValue", OracleType.VarChar, 11)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()

            oTrans.Commit()

            Return oComm.Parameters("oRtnValue").Value

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function Canteen_Deposit_Insert(ByVal Arr As ArrayList) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("C_CANTEENAGREEMENT_INSERT")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iSURNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iFATHERNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iCOMMITTED_AMT", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iPAID_AMT", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iAGREMENT_NAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iAGREMENT_FROM", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oParam = oComm.Parameters.Add("iAGREMENT_TO", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            oParam = oComm.Parameters.Add("iAGREMENT_NO", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            oParam = oComm.Parameters.Add("iCOMPANY_NAME", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(10)

            oParam = oComm.Parameters.Add("iHNO", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(11)

            oParam = oComm.Parameters.Add("iSTREET_VILL", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(12)

            oParam = oComm.Parameters.Add("iMANDAL_AREA", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(13)

            oParam = oComm.Parameters.Add("iCOUNTRYSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(14)

            oParam = oComm.Parameters.Add("iSTATESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(15)

            oParam = oComm.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(16)

            oParam = oComm.Parameters.Add("iMANDALSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(17)

            oParam = oComm.Parameters.Add("iPIN", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(18)

            oParam = oComm.Parameters.Add("iPHONERES", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(19)

            oParam = oComm.Parameters.Add("iMOBILE1", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(20)

            oParam = oComm.Parameters.Add("iMOBILE2", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(21)

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(22)

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(23)

            oComm.ExecuteNonQuery()

            oTrans.Commit()

            rtnMessage = "SUCCESS"

            Return rtnMessage

            Return oComm.Parameters("oRtnValue").Value

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function Address_Entry_Insert(ByVal Arr As ArrayList) As Long
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("ADDRESS_ENTRY_INSERT_NEW")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iFATHERNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iDOOR_NO", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iSTREET", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iVILLAGE", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iSTATESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oParam = oComm.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            oParam = oComm.Parameters.Add("iMANDALSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            oParam = oComm.Parameters.Add("iPROSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(10)

            oParam = oComm.Parameters.Add("iPIN", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(11)

            oParam = oComm.Parameters.Add("iMOBILE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(12)

            oParam = oComm.Parameters.Add("iPHONE_RES", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(13)

            oParam = oComm.Parameters.Add("iEMAILID", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(14)

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(15)

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(16)

            oParam = oComm.Parameters.Add("iSCHOOLNAME", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(17)

            oParam = oComm.Parameters.Add("iSSCMARKS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(18)

            oParam = oComm.Parameters.Add("iISTOPPER", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(19)

            oParam = oComm.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(20)

            oParam = oComm.Parameters.Add("iSCHOLLSNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(21)

            oParam = oComm.Parameters.Add("iCORPSCHOOLLSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(22)

            oParam = oComm.Parameters.Add("iCROPDISTRICTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(23)

            oParam = oComm.Parameters.Add("iFATOCCPUSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(24)

            oComm.Parameters.Add(New OracleParameter("oRtnValid", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()
            ReturnAddressSlno = oComm.Parameters("oRtnValid").Value

            oTrans.Commit()

            Return ReturnAddressSlno

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function PocketMoney_Withdraw_Insert(ByVal Arr As ArrayList) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("POCKETMONEY_WITHDRAW_INSERT")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            '''''''''''''''''''''''''' 1 ''''''''''''''''''''''''''''''

            oParam = oComm.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iCOLLEGESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iPAYMODETYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iTRANSDATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            '''''''''''''''''''''''''' 2 ''''''''''''''''''''''''''''''

            oParam = oComm.Parameters.Add("iAMT", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iTYPE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            oParam = oComm.Parameters.Add("iREMARKS", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            oComm.Parameters.Add(New OracleParameter("oRtnValue", OracleType.VarChar, 11)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()

            oTrans.Commit()

            Return oComm.Parameters("oRtnValue").Value

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function PM_Transfer_to_OP_Insert(ByVal Arr As ArrayList) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("PM_TO_OTHERPAYMENT_INSERT")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure

            '''''''''''''''''''''''''' 1 ''''''''''''''''''''''''''''''

            oParam = oComm.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iCOLLEGESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iPAYMODETYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iTRANSDATE", OracleType.DateTime)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            '''''''''''''''''''''''''' 2 ''''''''''''''''''''''''''''''

            oParam = oComm.Parameters.Add("iAMT", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oParam = oComm.Parameters.Add("iREMARKS", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            oParam = oComm.Parameters.Add("iHEADSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)


            oComm.Parameters.Add(New OracleParameter("oRtnValue", OracleType.VarChar, 100)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()

            oTrans.Commit()

            Return oComm.Parameters("oRtnValue").Value

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

    Public Function PRO_Address_Entry_Insert(ByVal Arr As ArrayList) As String
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("PRO_ADDRESS_ENTRY_INSERT")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iSTDNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iFATHERNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iFATOCCPUSLNO", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iSTREET", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iDOOR_NO", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oParam = oComm.Parameters.Add("iVILLAGE", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            oParam = oComm.Parameters.Add("iSTATESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            oParam = oComm.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(10)

            oParam = oComm.Parameters.Add("iMANDALSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(11)

            oParam = oComm.Parameters.Add("iPROSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(12)

            oParam = oComm.Parameters.Add("iPIN", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(13)

            oParam = oComm.Parameters.Add("iMOBILE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(14)

            oParam = oComm.Parameters.Add("iPHONE_RES", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(15)

            oParam = oComm.Parameters.Add("iEMAILID", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(16)

            oParam = oComm.Parameters.Add("iINTERHTNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(17)

            oParam = oComm.Parameters.Add("iEAMCETHTNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(18)

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(19)

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(20)



            oComm.ExecuteNonQuery()

            oTrans.Commit()
            Return 1


        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

#Region " Previos Scholl Name Insert"

    Public Function Pre_Schools_Insert(ByVal Arr As ArrayList) As Integer
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("PRV_SCHOOLS_INSERT")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iPRVSCHOOLSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iCODE", OracleType.VarChar, 10)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iDISTRICT", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iCORPSCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)


            oComm.ExecuteNonQuery()
            oTrans.Commit()
            Return 1

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

#End Region

#End Region

#Region "Report"

    Public Function DayBookReport_Fetch(ByVal pSqlString As String) As Data.DataSet
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oComm = New OracleCommand
            oAdap = New OracleClient.OracleDataAdapter
            Ds = New DataSet

            oComm.CommandText = "SECTION_BRANCH_RPT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSQLSTRING", OracleType.VarChar, 30000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = pSqlString

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

#Region "BANGLORE ADDRESS INSERT"

    Public Function Banglr_Address_Entry_Insert(ByVal Arr As ArrayList) As Long
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("ADDRESS_ENTRY_INSERT_BANGLR")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iFATHERNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iFATHER_OCCU", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iPRE_CLASS_SLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)


            oParam = oComm.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)


            oParam = oComm.Parameters.Add("iADDR1", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iADDR2", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oParam = oComm.Parameters.Add("iADDR3", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            oParam = oComm.Parameters.Add("iADDR4", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            oParam = oComm.Parameters.Add("iSTATESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(10)

            oParam = oComm.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(11)

            oParam = oComm.Parameters.Add("iTALUKASLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(12)

            oParam = oComm.Parameters.Add("iMANDALSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(13)

            oParam = oComm.Parameters.Add("iSUBAREASLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(14)


            oParam = oComm.Parameters.Add("iPINCODE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(15)


            oParam = oComm.Parameters.Add("iPHONE1", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(16)

            oParam = oComm.Parameters.Add("iPHONE2", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(17)

            oParam = oComm.Parameters.Add("iMOBILE1", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(18)

            oParam = oComm.Parameters.Add("iMOBILE2", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(19)

            oParam = oComm.Parameters.Add("iSCHOOL_NAME", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(20)


            oParam = oComm.Parameters.Add("iPLACEOFSCHOOL", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(21)

            oParam = oComm.Parameters.Add("iPROSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(22)

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(23)

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(24)


            oComm.Parameters.Add(New OracleParameter("oRtnValid", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()
            ReturnAddressSlno = oComm.Parameters("oRtnValid").Value

            oTrans.Commit()

            Return ReturnAddressSlno

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function
    Public Function RelAddress_Entry_Insert(ByVal Arr As ArrayList) As Long
        Try
            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oTrans = oConn.BeginTransaction()

            oComm = New OracleCommand("RELADDRESS_ENTRY_INSERT_NEW")
            oComm.Connection = oConn
            oComm.Transaction = oTrans
            oComm.CommandType = CommandType.StoredProcedure


            oParam = oComm.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iFATHERNAME", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iGROUPSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iDOOR_NO", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iSTREET", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)

            oParam = oComm.Parameters.Add("iVILLAGE", OracleType.VarChar, 50)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(6)

            oParam = oComm.Parameters.Add("iSTATESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(7)

            oParam = oComm.Parameters.Add("iDISTRICTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(8)

            oParam = oComm.Parameters.Add("iMANDALSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(9)

            oParam = oComm.Parameters.Add("iPROSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(10)

            oParam = oComm.Parameters.Add("iPIN", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(11)

            oParam = oComm.Parameters.Add("iMOBILE", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(12)

            oParam = oComm.Parameters.Add("iPHONE_RES", OracleType.VarChar, 15)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(13)

            oParam = oComm.Parameters.Add("iEMAILID", OracleType.VarChar, 30)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(14)

            oParam = oComm.Parameters.Add("iCOMACADEMICSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(15)

            oParam = oComm.Parameters.Add("iUSERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(16)

            oParam = oComm.Parameters.Add("iSCHOOLNAME", OracleType.VarChar, 100)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(17)

            oParam = oComm.Parameters.Add("iSSCMARKS", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(18)

            oParam = oComm.Parameters.Add("iISTOPPER", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(19)

            oParam = oComm.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(20)

            oParam = oComm.Parameters.Add("iSCHOLLSNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(21)

            oParam = oComm.Parameters.Add("iCORPSCHOOLLSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(22)

            oParam = oComm.Parameters.Add("iCROPDISTRICTSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(23)

            oParam = oComm.Parameters.Add("iFATOCCPUSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(24)


            oParam = oComm.Parameters.Add("iBLOODRELTIONSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(25)

            oParam = oComm.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(26)


            oComm.Parameters.Add(New OracleParameter("oRtnValid", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oComm.ExecuteNonQuery()
            ReturnAddressSlno = oComm.Parameters("oRtnValid").Value

            oTrans.Commit()

            Return ReturnAddressSlno

        Catch oex As OracleException
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw oex
        Catch ex As Exception
            If Not oTrans Is Nothing Then oTrans.Rollback()
            Throw ex
        Finally
            If Not ConObj Is Nothing Then ConObj.Free()
        End Try
    End Function

#End Region

#Region "Pro Student Verification"

    Public Function Pro_StdAddrss_Verufy_Update(ByVal Arr As ArrayList) As Integer
        Try

            ConObj = New Connection
            oConn = ConObj.GetConnection()
            oComm = New OracleClient.OracleCommand
            oParam = New OracleClient.OracleParameter
            oComm = New OracleCommand


            oComm.CommandText = "PROSTDADDRSSVERFY_UPDATE"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(0)

            oParam = oComm.Parameters.Add("iEXAMBATCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(1)

            oParam = oComm.Parameters.Add("iSTDTYPESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(2)

            oParam = oComm.Parameters.Add("iZONESLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(3)

            oParam = oComm.Parameters.Add("iISJOIN", OracleType.VarChar, 1)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(4)

            oParam = oComm.Parameters.Add("iVERFIED_USERSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = Arr(5)


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

End Class
