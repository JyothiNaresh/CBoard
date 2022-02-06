' Author    : P.Venu
' Purpose   : Graphs
' Created   : 13-Apr-2012

Module JGraph

#Region " Class Variables"

    Dim xdtExam As New DataTable
    Dim ydtExam As New DataTable
    Dim dsExam As New DataSet
    Dim Dr As DataRow
    Dim i, j, k As Integer
    Dim Js, Str As String
    Dim XAxis, Legend, Title, Data As String
    Dim DH, DT As String
    Dim VenArray As ArrayList

#End Region

#Region " Methods"

    Public Sub CreateGraph()
        Try
            XAxis = "['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']"
            Legend = "vertical"
            Title = "Narayana Charting"
            DH = "INDIA,PAKISTAN,SRILANKA,BANGLADESH"
            xdtExam.Columns.Add("CMBSLNO", Type.GetType("System.String"))
            xdtExam.Columns.Add("CMBNAME", Type.GetType("System.String"))
            xdtExam.Columns.Add("CMBEXAMS", Type.GetType("System.String"))
            xdtExam.Columns.Add("CMBEXAMNO", Type.GetType("System.String"))

            Dr = xdtExam.NewRow
            Dr(0) = "NARAYANA"
            Dr(1) = "CHAITANYA"
            Dr(2) = "N R I"
            Dr(3) = "VYSHNAVI"
            xdtExam.Rows.Add(Dr)

            ydtExam.Columns.Add("COL1", Type.GetType("System.String"))
            ydtExam.Columns.Add("COL2", Type.GetType("System.Int16"))
            ydtExam.Columns.Add("COL3", Type.GetType("System.Int16"))
            ydtExam.Columns.Add("COL4", Type.GetType("System.Int16"))
            ydtExam.Columns.Add("COL5", Type.GetType("System.Int16"))

            Dr = ydtExam.NewRow : Dr(0) = "2007" : Dr(1) = 90 : Dr(2) = 80 : Dr(3) = 75 : Dr(4) = 72 : ydtExam.Rows.Add(Dr)
            Dr = ydtExam.NewRow : Dr(0) = "2008" : Dr(1) = 70 : Dr(2) = 80 : Dr(3) = 65 : Dr(4) = 52 : ydtExam.Rows.Add(Dr)
            Dr = ydtExam.NewRow : Dr(0) = "2009" : Dr(1) = 12 : Dr(2) = 71 : Dr(3) = 68 : Dr(4) = 82 : ydtExam.Rows.Add(Dr)
            Dr = ydtExam.NewRow : Dr(0) = "2010" : Dr(1) = 22 : Dr(2) = 58 : Dr(3) = 78 : Dr(4) = 73 : ydtExam.Rows.Add(Dr)
            Dr = ydtExam.NewRow : Dr(0) = "2011" : Dr(1) = 92 : Dr(2) = 91 : Dr(3) = 25 : Dr(4) = 57 : ydtExam.Rows.Add(Dr)
            Dr = ydtExam.NewRow : Dr(0) = "2012" : Dr(1) = 99 : Dr(2) = 66 : Dr(3) = 48 : Dr(4) = 42 : ydtExam.Rows.Add(Dr)

            DynamicHtml(xdtExam, ydtExam)
        Catch ex As Exception

        End Try
    End Sub

    Public Function DynamicHtml(ByVal XaDt As DataTable, ByVal YaDt As DataTable) As String
        Try
            Dim TblStr As String
            'Table Tag
            TblStr = "<table id=*Chart* runat=*server* class=*hovertable*>"
            'Table Header Tag
            TblStr += "<thead><tr><th></th>"
            For i = 0 To XaDt.Columns.Count - 1
                TblStr += "<th>" + XaDt.Rows(0).Item(i).ToString + "</th>"
            Next
            TblStr += "</tr></thead>"
            'Table Data
            TblStr += "<tbody>"
            For i = 0 To YaDt.Rows.Count - 1
                TblStr += "<tr>"
                For j = 0 To YaDt.Columns.Count - 1
                    If j = 0 Then
                        TblStr += "<th>" + YaDt.Rows(i).Item(j) + "</th>"
                    Else
                        TblStr += "<td>" + YaDt.Rows(i).Item(j).ToString + "</td>"
                    End If

                Next
                TblStr += "</tr>"
            Next
            TblStr += "</tbody></table>"
            TblStr = TblStr.Replace("*", """")

            Return TblStr
            Dim Str As String
            'Str = "<script language='javascript'>DynamicGraph('" + TblStr + "','" + DrpGraphType.SelectedItem.Value + ",Narayana Charting','" + DrpTh.SelectedItem.Value + "');</script>"
            'RegisterStartupScript("JavaScript", Str)

        Catch ex As Exception

        End Try

    End Function

#End Region

End Module