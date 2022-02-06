Public Class Commonfunctions

#Region "FillListBox"

    Public Shared Sub FillListAll(ByVal ListBox_From As ListBox, ByVal ListBox_To As ListBox)
        Dim intCounter As Integer = 0

        For intCounter = 0 To ListBox_From.Items.Count - 1
            ListBox_To.Items.Add(ListBox_From.Items(intCounter))
        Next
        ListBox_From.Items.Clear()
    End Sub

    Public Shared Sub FillListSel(ByVal ListBox_From As ListBox, ByVal ListBox_To As ListBox)
        Dim intCouter As Integer = 0
        Try

            If (Not ListBox_From.SelectedItem Is Nothing) Then

                Dim itmList As ListItem
                For Each itmList In ListBox_From.Items
                    If itmList.Selected Then
                        ListBox_To.Items.Add(itmList)
                    End If
                Next

                Dim i As Byte = 0
                Do
                    If ListBox_From.Items(i).Selected = True Then
                        ListBox_From.Items.Remove(ListBox_From.Items(i))
                    Else
                        i = i + 1
                    End If
                Loop Until (i = ListBox_From.Items.Count)

            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Shared Sub ClearListBox(ByVal ListBox_Clear As ListBox)
        ListBox_Clear.Items.Clear()
    End Sub

    Public Shared Sub FillListAllOnly(ByVal ListBox_From As ListBox, ByVal ListBox_To As ListBox)
        Dim intCounter As Integer = 0

        For intCounter = 0 To ListBox_From.Items.Count - 1
            ListBox_To.Items.Add(ListBox_From.Items(intCounter))
        Next
    End Sub

#End Region

#Region "Comman Methods"

    Public Shared Function iSaDate(ByVal strDate As String) As Boolean
        Try

            Dim dt As Date

            Dim strFormat() As String = {"d-M-yy", "d/M/yy", "d.M.yy", "d-M-yyyy", "d/M/yyyy", "d.M.yyyy", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy", "dd-MMM-yyyy", "dd/MMM/yyyy", "dd.MMM.yyyy"}
            dt = Date.ParseExact(strDate, strFormat, Nothing, Nothing)
            Return True

        Catch ex As FormatException
            Return False
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function ConvertToDate(ByVal strDate As String) As Date
        Try

            Dim dt As Date

            Dim strFormat() As String = {"d-M-yy", "d/M/yy", "d.M.yy", "d-M-yyyy", "d/M/yyyy", "d.M.yyyy", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy", "dd-MMM-yyyy", "dd/MMM/yyyy", "dd.MMM.yyyy"}
            dt = Date.ParseExact(strDate, strFormat, Nothing, Nothing)
            Return dt

        Catch ex As FormatException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function ConvertDateToString(ByVal strDate As String) As String
        Try

            Dim dt As Date

            Dim strFormat() As String = {"d-M-yy", "d/M/yy", "d.M.yy", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy", "dd-MMM-yyyy", "dd/MMM/yyyy", "dd.MMM.yyyy"}
            dt = Date.ParseExact(strDate, strFormat, Nothing, Nothing)

            Return Format(dt, "dd-MMM-yyyy")

        Catch ex As FormatException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'venu on 16-Feb-2011
    Public Shared Function VConvertDateToString(ByVal strDate As String) As String
        Try
            Dim dt As Date

            Dim strFormat() As String = {"d-M-yy", "d/M/yy", "d.M.yy", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy", "dd-MMM-yyyy", "dd/MMM/yyyy", "dd.MMM.yyyy", "ddmmyy"}
            dt = Date.ParseExact(strDate, strFormat, Nothing, Nothing)

            Return Format(dt, "ddMMMyy")

        Catch ex As FormatException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
