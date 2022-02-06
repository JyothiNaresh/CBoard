'-------------------------------------------------------------
' Author                :   Venu.P  
' Description           :   For Sms-ExcelFile Uploading
' StartDate             :   03-Sep-2011
' InitialBaselineDate   :   04-Sep-2011
' Modification Log      :   Dept adding [13-Dec-2011]- Venu.P
'-------------------------------------------------------------
Imports System.Data
Imports System.Data.OracleClient
Imports System.Configuration

Public Class ClsSchool_TC

#Region " * Class Variables"

    Private oConn As OracleConnection 'Connection Object Declaration.
    Private oComm As OracleCommand 'Command Object Declaration.
    Private oTrans As OracleTransaction 'Transaction Object Declaration.
    Private oAdap As OracleDataAdapter 'Adapter Object Declaration.
    Private oParam As OracleParameter 'Parameter Object Declaration.
    Private Ds As DataSet
    Private ConObj As Connection
    Private rtnMessage As String 'Result of the return type.
    Private rtnVal As Integer 'Result of the return type.
    Dim UMText As String
    Private Objfetch As Utility
    Private OraStr, OraStr_1, OraStr_2, OraStr_3, OraStr_4 As String

#End Region

#Region " * TC_Details Insert_Update"

    Public Function BOARDSCHTCDETAILS_INSERT(ByVal iUNIQUENO As Integer, ByVal iADMSLNO As Integer, ByVal iEXAMBRANCHSLNO As Integer, ByVal iTCBOOKNO As Integer, ByVal iTCNO As Integer, ByVal IFILEPATH As String, ByVal iINSUPD As Integer) As Integer
        Try
            oComm = New OracleCommand
            ConObj = New Connection
            oConn = ConObj.GetConnection()

            oComm.CommandText = "BOARD_SCH_TCDET_INSERT"
            oComm.Connection = oConn
            oComm.CommandType = CommandType.StoredProcedure

            oParam = oComm.Parameters.Add("iUNIQUENO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iUNIQUENO

            oParam = oComm.Parameters.Add("iADMSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iADMSLNO

            oParam = oComm.Parameters.Add("iEXAMBRANCHSLNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iEXAMBRANCHSLNO

            oParam = oComm.Parameters.Add("iTCBOOKNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iTCBOOKNO

            oParam = oComm.Parameters.Add("iTCNO", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iTCNO

            oParam = oComm.Parameters.Add("IFILEPATH", OracleType.VarChar, 1000)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = IFILEPATH

            oParam = oComm.Parameters.Add("iINSUPD", OracleType.Number)
            oParam.Direction = ParameterDirection.Input
            oParam.Value = iINSUPD

            oComm.ExecuteNonQuery()

            Return 1

        Catch ex As Exception

        End Try
    End Function

#End Region

End Class
