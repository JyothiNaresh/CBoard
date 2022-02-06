'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : This is the Creating Exams
'   ACTIVITY                          : 
'   AUTHOR                            : A.Surendar Reddy
'   INITIAL BASELINE DATE             : 19-AUG-2006
'   FINAL BASELINE DATE               : 19-AUG-2006
'   MODIFICATIONS LOG                 : Nil
'----------------------------------------------------------------------------------------------
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsADM

#Region "Class Variables"

    Private oConn As OracleConnection 'Connection Object Declaration.
    Private oCommand As OracleCommand 'Command Object Declaration.
    Private oParameter As OracleParameter 'Parameter Object Declaration.
    Private oAdapter As OracleDataAdapter  'Adapter Object Declaration.
    Private oTrans As OracleTransaction 'Transaction Object Declaration.
    Private DsT, DsTax, DsCourseFeeActual, DsCourseFee, DsFormNo, DsReservation, DsEditFetch, DsGoFetch, DsADMRESSEARCH, DsREGSEARCH, DsADMHomeSearchFetch, DsADMDetailSearchFetch As DataSet
    Private Result As String 'Result of the return type.
    ''Private 'objStudent As StudentTemplate 'Student Class template Declaration
    ''Private 'objAddress As AddressTemplate 'Address Class template Declaration
    ''Private ReceiptTemp As New clsReceiptTemplate 'Payment Class template Declaration and instanciation
    Private VoucherNo As String
    Private LinkNo As Long

    Private TaxSLNO As Integer
    Private TaxPer As Decimal
    Private TotalTaxAmt As Decimal
    Private ObjConn As Connection

#End Region


#Region "Methods"

    'OBJECTIVE: This method is called to Insreting the data into Admission Table.
    'Table Name :T_ADM_DT.
    'Stored Procedure Name :F_INSERT_ADM.
    'It is returning the Latest Transaction SLNO.
    Private Function ADM_Insert(ByVal DsADM As DataSet, ByVal POLDORNEW As String, ByVal pCollegeSLNo As Integer, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As String
        Try

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oCommand.CommandText = "F_INSERT_ADM"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'Add IN PARAMETER NAME iTransDate
            oParameter = oCommand.Parameters.Add("iTransDate", OracleType.VarChar, 11)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DsADM.Tables(0).Rows(0)("TransDate").ToString


            'Add IN PARAMETER NAME iCollegeSLNo
            oParameter = oCommand.Parameters.Add("iBCCSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = pCollegeSLNo


            'Add IN PARAMETER NAME iRESSLNO
            oParameter = oCommand.Parameters.Add("iRESSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            If IsDBNull(DsADM.Tables(0).Rows(0)("RESSLNO")) Then
                oParameter.Value = DsADM.Tables(0).Rows(0)("RESSLNO")
            Else
                oParameter.Value = Val(DsADM.Tables(0).Rows(0)("RESSLNO"))
            End If


            'ADD IN PARAMETER NAME iSOASLNO
            oParameter = oCommand.Parameters.Add("iSOASLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            If IsDBNull(DsADM.Tables(0).Rows(0)("SOASLNO")) Then
                oParameter.Value = DsADM.Tables(0).Rows(0)("SOASLNO")
            Else
                oParameter.Value = Val(DsADM.Tables(0).Rows(0)("SOASLNO"))
            End If


            'ADD IN PARAMETER NAME iFormNo
            oParameter = oCommand.Parameters.Add("iFormNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CLng(DsADM.Tables(0).Rows(0)("FormNo"))

            'ADD IN PARAMETER NAME iBranchSLNO
            oParameter = oCommand.Parameters.Add("iBranchSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CInt(DsADM.Tables(0).Rows(0)("BranchSLNO"))

            'ADD IN PARAMETER NAME iReservationtype
            oParameter = oCommand.Parameters.Add("iReservationtype", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DsADM.Tables(0).Rows(0)("Reservationtype").ToString

            'ADD IN PARAMETER NAME iCourseSLNO
            oParameter = oCommand.Parameters.Add("iCourseSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CInt(DsADM.Tables(0).Rows(0)("CourseSLNO"))

            'ADD IN PARAMETER NAME iGroupSLNO
            oParameter = oCommand.Parameters.Add("iGroupSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CInt(DsADM.Tables(0).Rows(0)("GroupSLNO"))

            'ADD IN PARAMETER NAME iBatchSLNO
            oParameter = oCommand.Parameters.Add("iBatchSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CInt(DsADM.Tables(0).Rows(0)("BatchSLNO"))

            'ADD IN PARAMETER NAME iMediumSLNO
            oParameter = oCommand.Parameters.Add("iMediumSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CInt(DsADM.Tables(0).Rows(0)("MediumSLNO"))

            'ADD IN PARAMETER NAME iSTUTYPESLNO
            oParameter = oCommand.Parameters.Add("iSTUTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CInt(DsADM.Tables(0).Rows(0)("STUTYPESLNO"))

            'ADD IN PARAMETER NAME iStudentSLNo
            oParameter = oCommand.Parameters.Add("iStudentSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CInt(DsADM.Tables(0).Rows(0)("StudentSLNo"))

            'ADD IN PARAMETER NAME iTotalAmtToBePaid
            oParameter = oCommand.Parameters.Add("iTotalAmtToBePaid", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CDec(DsADM.Tables(0).Rows(0)("TotalAmtToBePaid"))

            'ADD IN PARAMETER NAME iTotalTaxAmtToBePaid
            oParameter = oCommand.Parameters.Add("iTotalTaxAmtToBePaid", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CDec(DsADM.Tables(0).Rows(0)("TotalTaxAmtToBePaid"))

            'ADD IN PARAMETER NAME iTotalAmtPaid
            oParameter = oCommand.Parameters.Add("iTotalAmtPaid", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CDec(DsADM.Tables(0).Rows(0)("TotalAmtPaid"))

            'ADD IN PARAMETER NAME iTotalTaxAmtPaid
            oParameter = oCommand.Parameters.Add("iTotalTaxAmtPaid", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CDec(DsADM.Tables(0).Rows(0)("TotalTaxAmtPaid"))

            'ADD IN PARAMETER NAME iTotalConcessionAmtReceived
            oParameter = oCommand.Parameters.Add("iTotalConcessionAmtReceived", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CDec(DsADM.Tables(0).Rows(0)("TotalConcessionAmtReceived"))

            'ADD IN PARAMETER NAME iAmtInStudent
            oParameter = oCommand.Parameters.Add("iAmtInStudent", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = CDec(DsADM.Tables(0).Rows(0)("AmtInStudent"))


            'ADD IN PARAMETER NAME iStatus
            oParameter = oCommand.Parameters.Add("iOLDORNEW", OracleType.VarChar, 3)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = POLDORNEW

            'ADD IN PARAMETER NAME iStatus
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DsADM.Tables(0).Rows(0)("Status").ToString

            'ADD IN PARAMETER NAME iOLDADMNO
            oParameter = oCommand.Parameters.Add("iOLDADMNO", OracleType.VarChar, 20)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DsADM.Tables(0).Rows(0)("OLDADMNO").ToString

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 200)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            Result = oCommand.Parameters("oRtnValid").Value
            Return Result

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    'Insreting the data into STUPAYORDERDETAILS TABLE.
    'Table Name :T_STUPAYORDERDETAILS_DT.
    'Stored Procedure Name :F_INSERT_STUPAYORDERDETAILS.
    'It is returning the Latest Transaction SLNO.
    Private Function STUPAYORDERDETAILS_Insert(ByVal Dr As DataRow, ByVal PADMSLNO As Long, ByVal TaxPercentage As Decimal, ByVal TaxAmt As Decimal, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As Long
        Try

            oCommand = New OracleCommand
            oParameter = New OracleParameter

            oCommand.CommandText = "F_INSERT_STUPAYORDERDETAILS"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iADMSLNO
            oParameter = oCommand.Parameters.Add("iADMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PADMSLNO)

            'ADD IN PARAMETER NAME iCFSLNO
            oParameter = oCommand.Parameters.Add("iCFSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(Dr("CFSLNO"))

            'ADD IN PARAMETER NAME iPOBSLNO
            oParameter = oCommand.Parameters.Add("iPOBSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(Dr("POBSLNO"))

            'ADD IN PARAMETER NAME iAmount
            oParameter = oCommand.Parameters.Add("iAmount", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(Dr("AMOUNT"))

            'ADD IN PARAMETER NAME iconcessionReceivedAmt
            oParameter = oCommand.Parameters.Add("iconcessionReceivedAmt", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = 0

            'ADD IN PARAMETER NAME iPAidAmt
            oParameter = oCommand.Parameters.Add("iPAidAmt", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = 0

            'ADD IN PARAMETER NAME iTaxPAidAmt
            oParameter = oCommand.Parameters.Add("iTaxPAidAmt", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = 0

            'ADD IN PARAMETER NAME iRemainingAmt
            oParameter = oCommand.Parameters.Add("iRemainingAmt", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(Dr("AMOUNT"))

            'ADD IN PARAMETER NAME iPayorderSequenceNo
            oParameter = oCommand.Parameters.Add("iPayorderSequenceNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(Dr("PAY_SEQUENCE"))

            'ADD IN PARAMETER NAME iConcessionSequenceNo
            oParameter = oCommand.Parameters.Add("iConcessionSequenceNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(Dr("CON_SEQUENCE"))

            'ADD IN PARAMETER NAME iTaxPercentage
            oParameter = oCommand.Parameters.Add("iTaxPercentage", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TaxPercentage

            'ADD IN PARAMETER NAME iTaxAmt
            oParameter = oCommand.Parameters.Add("iTaxAmt", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TaxAmt

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.Number)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            Result = oCommand.Parameters("oRtnValid").Value
            Return Result

        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Function

    'Fetch the data From T_COURSE_FEE_MT,T_payorder_breakup_mt.
    'Stored Procedure Name :M_CFEE_BREAKUP_SELECT.
    'It is returning the Dataset.
    Private Function CourseFee_BreakUp_Fetch(ByVal PBRANCHSLNo As Integer, ByVal PCOURSESLNo As Integer, ByVal PGROUPSLNo As Integer, ByVal PBATCHSLNo As Integer, ByVal PMEDIUMSLNo As Integer, ByVal PSTUTYPESLNo As Integer, ByVal PNEWOLD As String, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As DataSet
        Try
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            DsCourseFeeActual = New DataSet

            oCommand.CommandText = "M_CFEE_BREAKUP_SELECT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iBRANCHSLNo
            oParameter = oCommand.Parameters.Add("iBRANCHSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PBRANCHSLNo)

            'ADD IN PARAMETER NAME iCOURSESLNo
            oParameter = oCommand.Parameters.Add("iCOURSESLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PCOURSESLNo)

            'ADD IN PARAMETER NAME iGROUPSLNo
            oParameter = oCommand.Parameters.Add("iGROUPSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PGROUPSLNo)

            'ADD IN PARAMETER NAME iBATCHSLNo
            oParameter = oCommand.Parameters.Add("iBATCHSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PBATCHSLNo)

            'ADD IN PARAMETER NAME iMEDIUMSLNo
            oParameter = oCommand.Parameters.Add("iMEDIUMSLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PMEDIUMSLNo)

            'ADD IN PARAMETER NAME iSTUTYPESLNo
            oParameter = oCommand.Parameters.Add("iSTUTYPESLNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PSTUTYPESLNo)

            'ADD IN PARAMETER NAME iNEWOLD
            oParameter = oCommand.Parameters.Add("iNEWOLD", OracleType.VarChar, 3)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PNEWOLD

            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DataCur1", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DataCur2", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(DsCourseFeeActual)
            Return DsCourseFeeActual

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    'Fetch the data From T_TAX_MT.
    'Stored Procedure Name :M_TAX_ADM_SELECT.
    'It is returning the Dataset.
    Private Function Tax_Fetch(ByVal PStatus As String, ByVal pConn As OracleConnection, ByVal pTrans As OracleTransaction) As DataSet
        Try
            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            DsT = New DataSet

            oCommand.CommandText = "M_TAX_ADM_SELECT"
            oCommand.Connection = pConn
            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.Transaction = pTrans

            'ADD IN PARAMETER NAME iStatus
            oParameter = oCommand.Parameters.Add("iStatus", OracleType.Char, 1)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus

            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(DsT)
            Return DsT

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region


#Region "Wedservice Methods"


    'Fetch the data From T_SOA_DT.
    'Table Name:T_SOA_DT.
    'Stored Procedure Name :M_SOA_GO_SELECT.
    'It is returning the Dataset.


    Public Function FormNo_Fetch(ByVal PFormNo As String) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oConn.Open()

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            DsFormNo = New DataSet

            oCommand.CommandText = "M_SOA_GO_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSLNO
            oParameter = oCommand.Parameters.Add("iFORMNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PFormNo)


            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output
            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(DsFormNo)
            Return DsFormNo

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    Public Function FormNoExist_Or_Not(ByVal PFormNo As Long) As String
        Dim strReturn As String
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection()

            oCommand = New OracleCommand
            oParameter = New OracleParameter

            oCommand.CommandText = "F_FORMNO_EXIST_OR_NOT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME Country iFormNo
            oParameter = oCommand.Parameters.Add("iFormNo", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PFormNo

            oCommand.Parameters.Add(New OracleParameter("oRtnValid", OracleType.VarChar, 25)).Direction = ParameterDirection.ReturnValue
            oCommand.ExecuteNonQuery()

            strReturn = oCommand.Parameters("oRtnValid").Value.ToString

            Return strReturn

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    'Fetch the data from RES Table(Table Name :T_RES_DT) 

    Public Function Reservations_Fetch(ByVal PRESNO As String) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            DsReservation = New DataSet

            oCommand.CommandText = "M_RESSearchForADM_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME iResSlno
            oParameter = oCommand.Parameters.Add("iResSlno", OracleType.VarChar, 30)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PRESNO

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(DsReservation)
            Return DsReservation

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function



    Public Function ReservationNoExistInADM_Fetch(ByVal PRESNO As Long) As String
        Try
            Dim DsRESAMDExist As New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .


            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            DsReservation = New DataSet

            oCommand.CommandText = "M_RESADM_EXIST_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iResSlno
            oParameter = oCommand.Parameters.Add("iRESSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PRESNO

            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(DsRESAMDExist)

            If DsRESAMDExist.Tables(0).Rows.Count > 0 Then
                Return "EXIST"
            Else
                Return "NOT EXIST"
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    Public Function FormNoExistInADM_Fetch(ByVal PFORMNO As Long) As String
        Try
            Dim DsRESAMDExist As New DataSet
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            DsReservation = New DataSet

            oCommand.CommandText = "M_FRMADM_EXIST_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iFORMNO
            oParameter = oCommand.Parameters.Add("iFORMNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PFORMNO


            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(DsRESAMDExist)

            If DsRESAMDExist.Tables(0).Rows.Count > 0 Then
                Return "FormNo is already Exist in Admission (" + CStr(DsRESAMDExist.Tables(0).Rows(0)("ADMNO")) + ")"
            Else
                Return "NOT EXIST"
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    'Fetch the data from Admission Table(Table Name :T_ADM_DT) 

    Public Function ADM_Edit_Fetch(ByVal PSLNO As Long) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            DsEditFetch = New DataSet

            oCommand.CommandText = "M_ADM_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSLNO
            oParameter = oCommand.Parameters.Add("iSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = Val(PSLNO)

            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output
            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(DsEditFetch)
            Return DsEditFetch

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    'Fetch the data from Admission Table(Table Name :T_ADM_DT) 

    Public Function ADM_GO_Fetch(ByVal PADMNO As String) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .
            oConn.Open()

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            DsGoFetch = New DataSet

            oCommand.CommandText = "M_ADM_GO_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iSLNO
            oParameter = oCommand.Parameters.Add("iADMNO", OracleType.VarChar, 27)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PADMNO.ToString


            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output
            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(DsGoFetch)
            Return DsGoFetch

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    'Fetch the data from Admission Table(Table Name :T_ADM_DT) 

    Public Function REGNO_SEARCH_Fetch(ByVal PREGNO As String) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            DsREGSEARCH = New DataSet

            oCommand.CommandText = "M_REGNOSEARCH_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iREGNO
            oParameter = oCommand.Parameters.Add("iREGNO", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PREGNO.ToString

            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand

            oAdapter.Fill(DsREGSEARCH)

            Return DsREGSEARCH

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function

    'Fetch the data from Admission Table(Table Name :T_ADM_DT) 

    Public Function ADM_RES_SEARCH_Fetch(ByVal PADMNO As String, ByVal PREGNO As String, ByVal PStatus As String) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            DsADMRESSEARCH = New DataSet

            oCommand.CommandText = "M_ADMNOREGNOSEARCH_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure

            'ADD IN PARAMETER NAME iADMNO
            oParameter = oCommand.Parameters.Add("iADMNO", OracleType.VarChar, 27)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PADMNO.ToString

            'ADD IN PARAMETER NAME iREGNO
            oParameter = oCommand.Parameters.Add("iREGNO", OracleType.VarChar, 12)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PREGNO.ToString

            'ADD IN PARAMETER NAME iSTATUS
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 2)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = PStatus.ToString

            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand

            oAdapter.Fill(DsADMRESSEARCH)

            Return DsADMRESSEARCH

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    ''''Newly By Naidu

    Public Function ADM_DetailSearch(ByVal iBRANCHSLNO As Integer, ByVal iADMSNO As Integer, ByVal iFOXPROKEY As Integer, ByVal iSEARCHTYPE As Integer, ByVal pcmDset As DataSet) As DataSet
        Try
            pcmDset = FillAddress(iBRANCHSLNO, iADMSNO, iFOXPROKEY, iSEARCHTYPE, pcmDset)

            pcmDset = FillStuDetails(iBRANCHSLNO, iADMSNO, iFOXPROKEY, iSEARCHTYPE, pcmDset)

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return pcmDset

    End Function

    Private Function FillAddress(ByVal iBRANCHSLNO As Integer, ByVal iADMSNO As Integer, ByVal iFOXPROKEY As Integer, ByVal iSEARCHTYPE As Integer, ByVal pcmDset As DataSet) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .

            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter

            oCommand.CommandType = CommandType.StoredProcedure
            oCommand.CommandText = "M_FOXPRO_ADMSNO_SEARCH_SELECT"
            oCommand.Connection = oConn



            'ADD IN PARAMETER NAME Student Details
            oParameter = oCommand.Parameters.Add("DATACUR1", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output


            'ADD IN PARAMETER NAME iBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBRANCHSLNO

            'ADD IN PARAMETER NAME iADMSNO
            oParameter = oCommand.Parameters.Add("iADMSNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iADMSNO

            'ADD IN PARAMETER NAME AS FOXPROKEY
            oParameter = oCommand.Parameters.Add("iFOXPROKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFOXPROKEY

            'ADD IN PARAMETER NAME AS SEARCH TYPE
            oParameter = oCommand.Parameters.Add("iSEARCHTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSEARCHTYPE

            oAdapter.SelectCommand = oCommand

            oAdapter.Fill(pcmDset, "STUDETAILS")



        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return pcmDset

    End Function

    Private Function FillStuDetails(ByVal iBRANCHSLNO As Integer, ByVal iADMSNO As Integer, ByVal iFOXPROKEY As Integer, ByVal iSEARCHTYPE As Integer, ByVal pcmDset As DataSet) As DataSet
        Try
            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .


            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            ''DsADMDetailSearchFetch = New DataSet

            oCommand.CommandText = "STUDETAILS"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iBRANCHSLNO

            'ADD IN PARAMETER NAME iADMSNO
            oParameter = oCommand.Parameters.Add("iADMSNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iADMSNO

            'ADD IN PARAMETER NAME AS FOXPROKEY
            oParameter = oCommand.Parameters.Add("iFOXPROKEY", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iFOXPROKEY

            'ADD IN PARAMETER NAME AS SEARCH TYPE
            oParameter = oCommand.Parameters.Add("iSEARCHTYPE", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = iSEARCHTYPE

            ''''''ADD IN PARAMETER NAME Student Details
            '''''oParameter = oCommand.Parameters.Add("DATACUR1", OracleType.Cursor)
            '''''oParameter.Direction = ParameterDirection.Output

            'ADD IN PARAMETER NAME Student Details
            oParameter = oCommand.Parameters.Add("StudentAddress", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output



            oAdapter.SelectCommand = oCommand

            ''oAdapter.Fill(DsADMDetailSearchFetch)
            oAdapter.Fill(pcmDset, "StudentAddress")



        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

        Return pcmDset

    End Function



    Public Function ADM_DetailSearchFetch(ByVal Str As String) As DataSet
        Try


            Dim BRANCHSLNO, COURSESLNO, BATCHSLNO, MEDIUMSLNO, STUDENTTYPESLNO, FROM As Integer
            Dim ADMFROM, ADMTO, ADMSNO As Long
            Dim NAME, FATHERNAME, TELNO, MOBILENO, DOB, REGNO, STATUS As String

            Dim Str_Split() As String
            If Str <> "" Then
                Str_Split = Str.Split("~")

                BRANCHSLNO = Str_Split(0)
                COURSESLNO = Str_Split(1)
                BATCHSLNO = Str_Split(2)
                MEDIUMSLNO = Str_Split(3)
                STUDENTTYPESLNO = Str_Split(4)

                ADMSNO = Str_Split(5)
                REGNO = Str_Split(6)
                STATUS = Str_Split(7)
                NAME = Str_Split(8)
                FATHERNAME = Str_Split(9)

                TELNO = Str_Split(10)
                MOBILENO = Str_Split(11)
                DOB = Str_Split(12)
                ADMFROM = Str_Split(13)
                ADMTO = Str_Split(14)

                FROM = Str_Split(15)

            End If


            ObjConn = New Connection
            oConn = ObjConn.GetConnection() 'establishing the Connection .


            oCommand = New OracleCommand
            oParameter = New OracleParameter
            oAdapter = New OracleDataAdapter
            DsADMDetailSearchFetch = New DataSet

            oCommand.CommandText = "M_ADMDETAILSEARCH_SELECT"
            oCommand.Connection = oConn
            oCommand.CommandType = CommandType.StoredProcedure


            'ADD IN PARAMETER NAME iBRANCHSLNO
            oParameter = oCommand.Parameters.Add("iBRANCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BRANCHSLNO

            'ADD IN PARAMETER NAME iCOURSESLNO
            oParameter = oCommand.Parameters.Add("iCOURSESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = COURSESLNO

            'ADD IN PARAMETER NAME iBATCHSLNO
            oParameter = oCommand.Parameters.Add("iBATCHSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = BATCHSLNO

            'ADD IN PARAMETER NAME iMEDIUMSLNO
            oParameter = oCommand.Parameters.Add("iMEDIUMSLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MEDIUMSLNO

            'ADD IN PARAMETER NAME iSTUDENTTYPESLNO
            oParameter = oCommand.Parameters.Add("iSTUDENTTYPESLNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = STUDENTTYPESLNO

            'ADD IN PARAMETER NAME iADMSNO
            oParameter = oCommand.Parameters.Add("iADMSNO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ADMSNO

            'ADD IN PARAMETER NAME iREGNO
            oParameter = oCommand.Parameters.Add("iREGNO", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = REGNO

            'ADD IN PARAMETER NAME iSTATUS
            oParameter = oCommand.Parameters.Add("iSTATUS", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = STATUS

            'ADD IN PARAMETER NAME iNAME
            oParameter = oCommand.Parameters.Add("iNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = NAME

            'ADD IN PARAMETER NAME iFATHERNAME
            oParameter = oCommand.Parameters.Add("iFATHERNAME", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = FATHERNAME

            'ADD IN PARAMETER NAME iTELNO
            oParameter = oCommand.Parameters.Add("iTELNO", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = TELNO

            'ADD IN PARAMETER NAME iMOBILENO
            oParameter = oCommand.Parameters.Add("iMOBILENO", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = MOBILENO

            'ADD IN PARAMETER NAME iDOB
            oParameter = oCommand.Parameters.Add("iDOB", OracleType.VarChar, 50)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = DOB


            'ADD IN PARAMETER NAME iADMFROM
            oParameter = oCommand.Parameters.Add("iADMFROM", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ADMFROM

            'ADD IN PARAMETER NAME iADMTO
            oParameter = oCommand.Parameters.Add("iADMTO", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = ADMTO

            'ADD IN PARAMETER NAME iFROM
            oParameter = oCommand.Parameters.Add("iFROM", OracleType.Number)
            oParameter.Direction = ParameterDirection.Input
            oParameter.Value = FROM

            'ADD IN PARAMETER NAME Cursor
            oParameter = oCommand.Parameters.Add("DataCur", OracleType.Cursor)
            oParameter.Direction = ParameterDirection.Output

            oAdapter.SelectCommand = oCommand
            oAdapter.Fill(DsADMDetailSearchFetch)

            Return DsADMDetailSearchFetch

        Catch ex As Exception
            Throw ex
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try

    End Function


    Public Function ADM_Update(ByVal USERSLNO As Integer, ByVal TransSLNO As Long, ByVal TransDate As String, ByVal BranchSLNO As Integer, ByVal DsAddress As DataSet, ByVal DsStudent As DataSet) As String

        Dim rtnString As String
        Dim rAddressSLNo, rStudentSLNo As Long
        Dim i, j As Integer
        Dim dRow As DataRow
        Dim dRowArray As DataRow()
        Dim Dr As DataRow
        Try
            ''objStudent = New StudentTemplate
            ''objAddress = New AddressTemplate
            oConn = ObjConn.GetConnection()

            oTrans = oConn.BeginTransaction()

            'Address template Begin
            If Not IsNothing(DsAddress) Then
                If DsAddress.Tables.Count <> 0 Then
                    If Not IsNothing(DsAddress.Tables(0).GetChanges(DataRowState.Modified)) Then
                        'objAddress.Address_Update(DsAddress, oConn, oTrans)
                    ElseIf Not IsNothing(DsAddress.Tables(0).GetChanges(DataRowState.Added)) Then
                        'objAddress.Address_Insert(DsAddress, oConn, oTrans, rAddressSLNo)
                        DsStudent.Tables(0).Rows(0)("AddressSLNo") = rAddressSLNo
                        'objStudent.Student_Update(DsStudent, oConn, oTrans)
                    ElseIf Not IsNothing(DsAddress.Tables(0).GetChanges(DataRowState.Deleted)) Then
                        'objAddress.Address_Delete(DsAddress, oConn, oTrans)
                        rAddressSLNo = -1
                    End If
                End If
            End If
            'Address Template End

            'Student template Begin
            If Not IsNothing(DsStudent) Then
                If DsStudent.Tables.Count <> 0 Then
                    If Not IsNothing(DsStudent.Tables(0).GetChanges(DataRowState.Modified)) Then
                        If rAddressSLNo > 0 Then
                            DsStudent.Tables(0).Rows(0)("AddressSLNo") = rAddressSLNo
                        ElseIf rAddressSLNo = -1 Then
                            DsStudent.Tables(0).Rows(0)("AddressSLNo") = ""
                        End If
                        'objStudent.Student_Update(DsStudent, oConn, oTrans)
                    ElseIf Not IsNothing(DsStudent.Tables(0).GetChanges(DataRowState.Deleted)) Then
                        If rAddressSLNo > 0 Then
                            DsStudent.Tables(0).Rows(0)("AddressSLNo") = rAddressSLNo
                        ElseIf rAddressSLNo = -1 Then
                            DsStudent.Tables(0).Rows(0)("AddressSLNo") = ""
                        End If
                        'objStudent.Student_Delete(DsStudent, oConn, oTrans)
                        rStudentSLNo = -1
                    End If
                End If
            End If
            'Student template End

            'User Tracing Begin
            'UserTrace = New UserTracing
            'UserTrace.USERTRACE_Insert(USERSLNO, TransSLNO, "ADM", TransDate, BranchSLNO, BranchSLNO, "UPDATE", "A", oConn, oTrans)
            'User Tracing End

            oTrans.Commit()
            rtnString = "SUCCESS"
        Catch ex As Exception
            oTrans.Rollback()
            rtnString = ex.Message.ToString
        Finally
            If Not ObjConn Is Nothing Then ObjConn.Free()
        End Try
        Return rtnString
    End Function


#End Region


End Class
