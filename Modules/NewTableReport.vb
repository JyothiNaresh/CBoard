Module NewTableReport

#Region "Classic Header Styles"

    Public Function HeadingstyleANA(ByVal iText As String, ByVal colspan As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#B8773D")
        TCell.Text = iText
        'TCell.ForeColor = Color.DarkBlue
        myAttributes.CssStyle.Add("Color", "white")
        'myAttributes.CssStyle.Add("Color", "#663300")
        myAttributes.CssStyle.Add("font-family", "Verdana,Arial, Helvetica, sans-serif,Tahoma, Georgia, Tahoma, Sans-serif, Helvetica")
        TCell.Font.Size = FontUnit.XSmall
        'TCell.Font.Name = "Verdana"
        TCell.Font.Bold = True
        TCell.ColumnSpan = colspan
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Center
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function SideHeadingstyleANA(ByVal iText As String, ByVal iId As String, ByVal colspan As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ID = iId
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = colspan
        TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Left
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function SubHeadingstyleANA(ByVal iText As String, ByVal iId As String, ByVal icolspan As Integer, ByVal iOrdtxt As String, ByVal iordtyp As String) As TableCell
        Dim TCell As New TableCell
        Dim TLink As New System.Web.UI.WebControls.HyperLink
        'Dim TButton As New System.Web.UI.WebControls.Button
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TLink.Text = iText
        TLink.ForeColor = Color.Blue
        TLink.NavigateUrl = "ExamNotAttendedStuSummary.aspx?ORD=" + iOrdtxt + "&ORDSTR=" + iordtyp
        TCell.Controls.Add(TLink)
        TCell.ID = iId
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Center
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

#End Region

#Region "Classic Item Styles"

    Public Function Attendedstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim TLink As New System.Web.UI.WebControls.HyperLink
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ToolTip = itooltip + " Attended"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function NotAttendedstyle(ByVal iText As String, ByVal iNavigateUrl As String, ByVal colspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim TLink As New System.Web.UI.WebControls.HyperLink
        Dim myAttributes As AttributeCollection = TCell.Attributes
        Dim myAttributeslnk As AttributeCollection = TLink.Attributes

        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Red")
        myAttributeslnk.CssStyle.Add("Color", "Red")
        If Trim(iText) = CStr(0) Then
            TCell.Text = iText
        Else
            TLink.Text = iText
            TLink.ForeColor = Color.Blue
            TLink.NavigateUrl = iNavigateUrl
            TCell.Controls.Add(TLink)
        End If

        TCell.CssClass = "GridItem"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ToolTip = itooltip + " Not Attended"
        TCell.ColumnSpan = colspan
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function TotalAttendedstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        'TCell.BackColor = Color.Lavender
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ToolTip = itooltip + " Total Attended"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function TotalNotAttendedstyle(ByVal iText As String, ByVal colspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        'TCell.BackColor = Color.Lavender
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.Text = iText
        TCell.CssClass = "GridItem"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ToolTip = itooltip + " Total Not Attended"
        TCell.ColumnSpan = colspan
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function


#End Region

End Module
