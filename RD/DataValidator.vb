Imports System.Web.UI.Control
Imports System.Web.UI.WebControls
Imports Microsoft.VisualBasic

Public Class DataValidator


    '''Public Function AlphaKey(ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '''    If ((Asc(e.KeyChar) < 65 Or Asc(e.KeyChar) > 91) And (Asc(e.KeyChar) < 97 Or Asc(e.KeyChar) > 122) And (Asc(e.KeyChar) <> 32) And (Asc(e.KeyChar) <> 8)) And (Asc(e.KeyChar) <> 46) And (Asc(e.KeyChar) <> 13) Then
    '''        'MessageBox.Show("Enter Only 'A' to 'Z' Characters Only", MsgBoxCaption, 'MessageBoxButtons.OK, 'MessageBoxIcon.Information)
    '''        e.Handled = True
    '''    End If

    '''End Function

    '''Public Function AlphaNumericKey(ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '''    If ((Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) < 65 Or Asc(e.KeyChar) > 91) And (Asc(e.KeyChar) < 97 Or Asc(e.KeyChar) > 122) And (Asc(e.KeyChar) <> 32) And (Asc(e.KeyChar) <> 8)) And (Asc(e.KeyChar) <> 46) And (Asc(e.KeyChar) <> 13) And (Asc(e.KeyChar) <> 38) And (Asc(e.KeyChar) <> 95) Then
    '''        'MessageBox.Show("Enter Alphanumrics Only", MsgBoxCaption, 'MessageBoxButtons.OK, 'MessageBoxIcon.Information)
    '''        e.Handled = True
    '''    End If
    '''End Function

    '''Public Function NumericKey(ByVal e As System.Windows.Forms.KeyPressEventArgs)

    '''    If ((Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8)) And (Asc(e.KeyChar) <> 13) Then
    '''        'MessageBox.Show("Enter Numerics Only", MsgBoxCaption, 'MessageBoxButtons.OK, 'MessageBoxIcon.Information)
    '''        e.Handled = True
    '''    End If


    '''End Function

    '''Public Function DecimalKey(ByVal StrVal As String, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '''    If (Asc(e.KeyChar) = 46) Then
    '''        If (StrVal.IndexOf(".") <> -1) Then
    '''            e.Handled = True
    '''        End If
    '''    Else
    '''        If ((Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 46) And (Asc(e.KeyChar) <> 8)) And (Asc(e.KeyChar) <> 13) Then
    '''            'MessageBox.Show("Enter Numrics or Decimal Only", MsgBoxCaption, 'MessageBoxButtons.OK, 'MessageBoxIcon.Information)
    '''            e.Handled = True
    '''        End If
    '''    End If
    '''End Function

    Public Function IsNothing(ByVal TxtText As String, ByVal MsgText As String) As Boolean
        If ((TxtText = Nothing) Or (TxtText = "")) Then
            'MessageBox.Show(MsgText & " is Mandatory Field", MsgBoxCaption, 'MessageBoxButtons.OK, 'MessageBoxIcon.Information)
            Return True
        Else
            Return False
        End If

    End Function

    Public Function DatesCheck(ByVal GreaterDate As String, ByVal LowerDate As String, ByVal GreaterDateName As String, ByVal LowerDateName As String) As Boolean
        If (DateValue(GreaterDate) < DateValue(LowerDate)) Then
            'MessageBox.Show(LowerDateName & " Cannot be Less than " & GreaterDateName, MsgBoxCaption, 'MessageBoxButtons.OK, 'MessageBoxIcon.Information)
            Return False
        Else
            Return True
        End If
    End Function

    Public Function DatesCompires(ByVal GreaterDate As Date, ByVal LowerDate As Date, ByVal GreaterDateName As String, ByVal LowerDateName As String) As Boolean
        If (GreaterDate < LowerDate) Then
            'MessageBox.Show(LowerDateName & "   Cannot be Greater Than  " & GreaterDateName, MsgBoxCaption, 'MessageBoxButtons.OK, 'MessageBoxIcon.Information)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function DataCheck(ByVal StrText As String, ByVal IntFlag As Integer)
        Dim StrInvalidStart As String = ".<>?/-_(){}[]|\+=&^%"
        Dim Ch As Integer
        Dim StrValidStringContent As String
        Dim Len = StrInvalidStart.Length
        If (StrText <> "") Then
            Dim FirstStr As String = StrText.Chars(0)
            Try

                For Ch = 0 To Len - 1
                    If (StrInvalidStart.Chars(Ch) = FirstStr) Then
                        ''MessageBox.Show(firststr)
                        ''MessageBox.Show(StrInvalidStart.Chars(Ch))
                        'MessageBox.Show("First Letter should be AlphaNumeric Only", MsgBoxCaption, 'MessageBoxButtons.OK, 'MessageBoxIcon.Information)
                        Return False
                        Exit Function
                    End If
                Next
            Catch e As Exception
                'MessageBox.Show(e.Message)
            End Try
        End If
        If (IntFlag = 1) Then StrValidStringContent = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@~#%$&()-+{}[]\`<>./?;: "
        If (IntFlag = 2) Then StrValidStringContent = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890 _&"
        If (IntFlag = 3) Then StrValidStringContent = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "
        If (IntFlag = 4) Then StrValidStringContent = "0123456789"
        If (IntFlag = 5) Then StrValidStringContent = "0123456789."

        Dim a As Array
        a = StrText.ToCharArray
        Dim index As Integer
        Dim i As Integer
        Dim IntCountDot As Integer = 0
        For index = 0 To a.GetLength(0) - 1

            If a(index) = "." Then IntCountDot = IntCountDot + 1

            If (StrValidStringContent.IndexOf(a(index)) = -1) Then
                'MessageBox.Show("Invalid Character  : " & a(index), MsgBoxCaption)
                Return False
                Exit Function
            End If
        Next
        If (IntFlag = 5 And IntCountDot > 1) Then
            'MessageBox.Show("Too Many Decimals")
            Return False
        Else
            Return True
        End If

    End Function

    'Checking Names Before Adding New Name or Modifing the Name
    Public Function IsDuplicate(ByVal al As ArrayList, ByVal Strtext As String, ByVal LstArrayColums As Integer, ByVal ColumNo As Integer, ByVal MsgTxt As String) As Boolean

        Dim RecCounter As Integer = 0
        Dim IntFields As Integer = LstArrayColums
        Dim IntCount As Integer = 0
        For IntCount = 0 To al.Count - IntFields Step IntFields
            Dim Str = al.Item(IntCount + ColumNo)
            If (UCase(Trim(Str)) = UCase(Trim(Strtext))) Then
                'MessageBox.Show(Strtext & "  " & MsgTxt, MsgBoxCaption, 'MessageBoxButtons.OK, 'MessageBoxIcon.Information)
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function

    'Checking For valid Parent
    Public Function IsParent(ByVal al As ArrayList, ByVal Strtext As String, ByVal LstArrayColums As Integer, ByVal ColumNo As Integer, ByVal MsgTxt As String) As Boolean

        Dim RecCounter As Integer = 0
        Dim IntFields As Integer = LstArrayColums
        Dim IntCount As Integer = 0
        For IntCount = 0 To al.Count - IntFields Step IntFields
            Dim Str = al.Item(IntCount + ColumNo) + 1
            If (UCase(Str) = UCase(Strtext)) Then
                'MessageBox.Show(Strtext & "  " & MsgTxt, MsgBoxCaption, 'MessageBoxButtons.OK, 'MessageBoxIcon.Information)
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function

    'Checking For Item/s Checked or Not in CheckedListBox
    '''Public Function IsChecked(ByVal ChLstBox As CheckedListBox, ByVal MsgTxt As String) As Boolean

    '''    Dim IntCounter As Integer
    '''    Dim IntFlag As Integer
    '''    For IntCounter = 0 To ChLstBox.Items.Count - 1
    '''        If (ChLstBox.GetItemChecked(IntCounter)) Then
    '''            IntFlag = IntFlag + 1
    '''        End If
    '''    Next
    '''    If (IntFlag > 0) Then
    '''        Return True
    '''    Else
    '''        ' 'MessageBox.Show(MsgTxt, MsgBoxCaption, 'MessageBoxButtons.OK, 'MessageBoxIcon.Information)
    '''        Return False
    '''    End If

    '''End Function

    'Public Sub EnterPress(ByVal ctrl As Control, ByVal e As KeyPressEventArgs)
    '    If (Asc(e.KeyChar) = 13) Then
    '        ''MessageBox.Show(ctrl.Name)
    '        ''MessageBox.Show(GetNextControl(ctrl, True).Name)
    '        GetNextControl(ctrl, True).Focus()
    '        GetNextControl(ctrl, True).Select()

    '    End If
    'End Sub

    'Set DataGrids Rows & Colums ReadOnly'

    '''Public Sub SetDataGridRowStatus(ByVal HeaderDataGrid As DataGrid, ByVal DetailsDataGrid As DataGrid)

    '''    Dim obj As Object
    '''    For Each obj In HeaderDataGrid.TableStyles(0).GridColumnStyles
    '''        Try
    '''            obj.Readonly = True
    '''        Catch ex As Exception
    '''            MsgBox(obj.ToString)
    '''        End Try
    '''    Next
    '''    For Each obj In DetailsDataGrid.TableStyles(0).GridColumnStyles
    '''        Try
    '''            obj.Readonly = True
    '''        Catch ex As Exception
    '''            MsgBox(obj.ToString)
    '''        End Try
    '''    Next
    '''End Sub

    '''Public Sub UGMsgbox(ByVal FirstTxt As String, ByVal SecondTxt As String)
    '''    'MessageBox.Show(SecondTxt & "   Cannot be Greater Than  " & FirstTxt, MsgBoxCaption, 'MessageBoxButtons.OK, 'MessageBoxIcon.Information)
    '''End Sub

    '''Public Sub IsNagetiveValue(ByVal MsgTxt As String)
    '''    'MessageBox.Show(MsgTxt & "   Cann't be Nagetive ", MsgBoxCaption, 'MessageBoxButtons.OK, 'MessageBoxIcon.Information)
    '''End Sub


End Class
