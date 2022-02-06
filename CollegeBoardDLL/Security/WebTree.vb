
Imports System.Data.OracleClient

Public Class WebTree

#Region "Class Variables"
    Private oConncls As New Connection
    Private oConn As New OracleClient.OracleConnection
    Private oCommand As OracleClient.OracleCommand
    Private oParameter As OracleClient.OracleParameter
    Private oAdapter As OracleClient.OracleDataAdapter
    Private oComm As OracleCommand 'Command Object Declaration.
    Private ConObj As Connection
    Private Ds As DataSet
    Private DsChk As DataSet
    
#End Region

#Region "Tree User Get Methods"

    Public Function fillTree() As DataSet
        Try
            Ds = New DataSet
            oConn = oConncls.GetConnection()
            oAdapter = New OracleClient.OracleDataAdapter("select idnode,idparentnode,nodecaption,isparent,nodeaction from E_TREECONTENTS_MT ORDER BY IDNODE", oConn)
            oAdapter.Fill(Ds)

        Catch Oex As OracleException
            Throw Oex
        Catch ex As Exception
            Throw ex
        End Try
        Return Ds

    End Function

#End Region



End Class
