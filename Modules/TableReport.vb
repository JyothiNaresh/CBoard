Imports System.IO
Imports System.Math
Imports System.Web.UI
Module TableReport

#Region "Classic Header Styles"

    Public Function Headingstyle(ByVal iText As String, ByVal colspan As Integer) As TableCell
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

    Public Function Headingstyle(ByVal iText As String, ByVal colspan As Integer, ByVal wrap As Boolean) As TableCell
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
        TCell.Wrap = wrap
        TCell.HorizontalAlign = HorizontalAlign.Center
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function SideHeadingstyle(ByVal iText As String, ByVal iId As String, ByVal colspan As Integer) As TableCell
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

    Public Function SideHeadingstyle(ByVal iText As String, ByVal iId As String, ByVal colspan As Integer, ByVal wrap As Boolean) As TableCell
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
        TCell.Wrap = wrap
        TCell.HorizontalAlign = HorizontalAlign.Left
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function TotSideHeadingstyle(ByVal iText As String, ByVal iId As String, ByVal colspan As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.Text = iText
        TCell.ID = iId
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = colspan
        TCell.Height = Unit.Pixel(25)
        TCell.Font.Bold = True
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Left
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function SubHeadingstyle(ByVal iText As String, ByVal iId As String, ByVal icolspan As Integer, ByVal iOrdtxt As String, ByVal iordtyp As String) As TableCell
        Dim TCell As New TableCell
        Dim TLink As New System.Web.UI.WebControls.HyperLink
        'Dim TButton As New System.Web.UI.WebControls.Button
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TLink.Text = iText
        TLink.ForeColor = Color.Blue
        TLink.NavigateUrl = "Secwisestudentanalysis.aspx?ORD=" + iOrdtxt + "&ORDSTR=" + iordtyp
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

    Public Function SubHeadingstyle1(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        TCell.Font.Bold = True
        TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Center
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function HeadingstyleNew(ByVal iText As String, ByVal colspan As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#B8773D")
        TCell.Text = iText
        'TCell.ForeColor = Color.DarkBlue
        myAttributes.CssStyle.Add("Color", "blue")
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

    Public Function SubHeadingstyleNew(ByVal iText As String, ByVal iId As String, ByVal icolspan As Integer, ByVal iOrdtxt As String, ByVal iordtyp As String, ByVal pNavigateUrl As String, ByVal TCellWidth As Integer) As TableCell
        Dim TCell As New TableCell
        Dim TLink As New System.Web.UI.WebControls.HyperLink
        'Dim TButton As New System.Web.UI.WebControls.Button
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#B8773D")
        myAttributes.CssStyle.Add("Color", "white")
        TLink.Text = iText
        TLink.ForeColor = Color.Blue
        TLink.NavigateUrl = pNavigateUrl '"Secwisestudentanalysis.aspx?ORD=" + iOrdtxt + "&ORDSTR=" + iordtyp
        TCell.Controls.Add(TLink)
        TCell.ID = iId
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        TCell.Height = Unit.Pixel(25)
        TCell.Width = Unit.Pixel(TCellWidth)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Center
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleLeft(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Left
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function
#End Region

#Region "Classic Item Styles"

    Public Function Enteredstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleBgColor(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String, ByVal BgColor As String, ByVal Align As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", BgColor)
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        If Align = "R" Then
            TCell.HorizontalAlign = HorizontalAlign.Right
        ElseIf Align = "L" Then
            TCell.HorizontalAlign = HorizontalAlign.Left
        ElseIf Align = "C" Then
            TCell.HorizontalAlign = HorizontalAlign.Center
        End If
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleMod(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String, Optional ByVal Align As String = "") As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")

        TCell.Text = iText
        TCell.ToolTip = itooltip
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        If Align = "R" Or Align = "" Then
            TCell.HorizontalAlign = HorizontalAlign.Right
        ElseIf Align = "L" Then
            TCell.HorizontalAlign = HorizontalAlign.Left
        ElseIf Align = "C" Then
            TCell.HorizontalAlign = HorizontalAlign.Center
        End If
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleTarget(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String, Optional ByVal Align As String = "") As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Green")
        TCell.Text = iText
        TCell.ToolTip = itooltip
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.Font.Bold = True
        TCell.ColumnSpan = icolspan

        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        If Align = "R" Or Align = "" Then
            TCell.HorizontalAlign = HorizontalAlign.Right
        ElseIf Align = "L" Then
            TCell.HorizontalAlign = HorizontalAlign.Left
        ElseIf Align = "C" Then
            TCell.HorizontalAlign = HorizontalAlign.Center
        End If
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleBold(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Bold = True
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleMaterial(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String, ByVal Material As String, ByVal Compare As Integer, ByVal Total As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes

        If Material = "N" Then
            myAttributes.CssStyle.Add("background-color", "#76EEC6")
            If Total = 1 Then
                TCell.Font.Bold = True
            End If
        Else
            If Total = 1 Then
                myAttributes.CssStyle.Add("background-color", "#F781BE")
                TCell.Font.Bold = True
            Else
                myAttributes.CssStyle.Add("background-color", "#EBDED6")
            End If
        End If

        If Compare = 1 AndAlso Total = 0 Then
            myAttributes.CssStyle.Add("Color", "Red")
        Else
            myAttributes.CssStyle.Add("Color", "Blue")
        End If

        If itooltip = "" Then
            myAttributes.Add("onmouseover", "Tip(' No Details [Topic/SubTopic/Material] ', BGCOLOR, '#ffcccc', FONTCOLOR, '#800000', FONTSIZE, '9pt', FONTFACE, 'Courier New, Courier, mono', BORDERCOLOR, '#c00000')")
        Else
            myAttributes.Add("onmouseover", "Tip('" + itooltip + "', BALLOON, true, BALLOONIMGPATH, 'http://www.walterzorn.de/en/scripts/tip_balloon/', ABOVE, true, CENTERMOUSE, true, OFFSETX, 0, PADDING, 8)")
        End If
        myAttributes.Add("onmouseout", "UnTip()")
        TCell.Text = iText
        TCell.ToolTip = IIf(itooltip = "", " No Details [Topic/SubTopic/Material] ", itooltip)
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        TCell.Width = Unit.Percentage(100)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleMaterialNoTip(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String, ByVal Material As String, ByVal Compare As Integer, ByVal Total As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes

        If Material = "N" Then
            myAttributes.CssStyle.Add("background-color", "#76EEC6")
            If Total = 1 Then
                TCell.Font.Bold = True
            End If
        Else
            If Total = 1 Then
                myAttributes.CssStyle.Add("background-color", "#F781BE")
                TCell.Font.Bold = True
            Else
                myAttributes.CssStyle.Add("background-color", "#EBDED6")
            End If
        End If

        If Compare = 1 AndAlso Total = 0 Then
            myAttributes.CssStyle.Add("Color", "Red")
        Else
            myAttributes.CssStyle.Add("Color", "Blue")
        End If

        'If itooltip = "" Then
        '    myAttributes.Add("onmouseover", "Tip(' No Details [Topic/SubTopic/Material] ', BGCOLOR, '#ffcccc', FONTCOLOR, '#800000', FONTSIZE, '9pt', FONTFACE, 'Courier New, Courier, mono', BORDERCOLOR, '#c00000')")
        'Else
        '    myAttributes.Add("onmouseover", "Tip('" + itooltip + "', BALLOON, true, BALLOONIMGPATH, 'http://www.walterzorn.de/en/scripts/tip_balloon/', ABOVE, true, CENTERMOUSE, true, OFFSETX, 0, PADDING, 8)")
        'End If
        'myAttributes.Add("onmouseout", "UnTip()")
        TCell.Text = iText
        'TCell.ToolTip = IIf(itooltip = "", " No Details [Topic/SubTopic/Material] ", itooltip)
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        TCell.Width = Unit.Percentage(100)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function TotEnteredstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.Text = iText
        TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        TCell.Font.Bold = True
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function NotEnterdlink(ByVal iText As String, ByVal iId As String, ByVal icolspan As Integer, ByVal NavURL As String) As TableCell
        Dim TCell As New TableCell
        Dim TLink As New System.Web.UI.WebControls.HyperLink
        'Dim TButton As New System.Web.UI.WebControls.Button
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Red")
        TLink.Text = iText
        TLink.ForeColor = Color.Red
        TLink.NavigateUrl = NavURL
        TCell.Controls.Add(TLink)
        TCell.ID = iId
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        If iId = "L" Then
            TCell.HorizontalAlign = HorizontalAlign.Left
        Else
            TCell.HorizontalAlign = HorizontalAlign.Center
        End If
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredControl(ByVal iText As String, ByVal iId As String, ByVal icolspan As Integer) As TableCell
        Dim TCell As New TableCell

        Dim TChk As New System.Web.UI.WebControls.CheckBox

        TChk.CssClass = "lables"

        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")

        TChk.Text = iText

        TCell.Controls.Add(TChk)
        TCell.ID = iId
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        If iId = "L" Then
            TCell.HorizontalAlign = HorizontalAlign.Left
        Else
            TCell.HorizontalAlign = HorizontalAlign.Center
        End If
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function HeadingControl(ByVal iText As String, ByVal iId As String, ByVal icolspan As Integer) As TableCell
        Dim TCell As New TableCell

        Dim TChk As New System.Web.UI.WebControls.CheckBox

        TChk.CssClass = "lables"

        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("Color", "white")
        myAttributes.CssStyle.Add("font-family", "Verdana,Arial, Helvetica, sans-serif,Tahoma, Georgia, Tahoma, Sans-serif, Helvetica")
        TCell.Font.Size = FontUnit.XSmall

        TChk.Text = iText
        'TChk.Attributes.Add("onClick", "vCheckAll()")

        TCell.Controls.Add(TChk)
        TCell.ID = iId
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        If iId = "L" Then
            TCell.HorizontalAlign = HorizontalAlign.Left
        Else
            TCell.HorizontalAlign = HorizontalAlign.Center
        End If
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function


    Public Function NotEnteredstyleNew(ByVal iText As String, ByVal colspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.Text = iText
        TCell.CssClass = "GridItem"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ToolTip = itooltip + " NotEnter"
        TCell.ColumnSpan = colspan
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function TotalEnteredstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        'TCell.BackColor = Color.Lavender
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ToolTip = itooltip + " Total Enter"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function TotalNotEnteredstyle(ByVal iText As String, ByVal colspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        'TCell.BackColor = Color.Lavender
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.Text = iText
        TCell.CssClass = "GridItem"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ToolTip = itooltip + " Total NotEnter"
        TCell.ColumnSpan = colspan
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleTot(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        'myAttributes.CssStyle.Add("background-color", "#FF6600")
        myAttributes.CssStyle.Add("background-color", "#254061")
        myAttributes.CssStyle.Add("Color", "White")
        TCell.Text = iText
        TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Bold = True
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleTotMod(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        'myAttributes.CssStyle.Add("background-color", "#FF6600")
        myAttributes.CssStyle.Add("background-color", "#254061")
        'myAttributes.CssStyle.Add("background-color", Bgcolor)
        myAttributes.CssStyle.Add("Color", "White")
        TCell.Text = iText
        TCell.ToolTip = itooltip
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Bold = True
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleMul(ByVal iText As String, ByVal icolspan As Integer, ByVal RAlign As String, ByVal ColType As Integer, ByVal itooltip As String, ByVal Param As String, ByVal frmName As String) As TableCell
        Dim TCell As New TableCell

        If iText = "." Then
            TCell.Text = ""
        Else
            Dim myStrIF, CellTxt, CalStr As String
            Dim CalNum, IfrHt As Integer
            'Total(0),Subtotal(1),General(2)
            If ColType = 0 Then
                CellTxt = "<font color='#FF0000'>" + iText + "</font>"
            ElseIf ColType = 1 Then
                CellTxt = "<font color='#FF00FF'>" + iText + "</font>"
            ElseIf ColType = 2 Then
                CellTxt = "<font color='#0000FF'>" + iText + "</font>"
            End If
            CalNum = Trim(iText).Length
            If CalNum = 9 Or CalNum = 10 Or Trim(Left(iText, 1)) = "(" Then
                CalStr = iText.Replace("(", "") : CalStr = CalStr.Replace(")", "") : CalNum = Val(CalStr)
            ElseIf CalNum < 9 Or CalNum > 13 Then
                CalNum = Val(Trim(Left(iText, 8)))
            End If
            If CalNum > 0 Then
                If CalNum > 15 Then
                    IfrHt = 300
                Else
                    If CalNum = 1 Then
                        IfrHt = 65
                    Else
                        IfrHt = CalNum * 20 + 25
                    End If
                End If
            Else
                IfrHt = 70
            End If

            ' HtmlExapnd with Iframe
            myStrIF = "<div width=*100%*><A class=*highslide* href=*#* onclick=*return hs.htmlExpand(this,{ headingText: 'NARAYANA ' })*>" + CellTxt + "</A>" & _
            "<div width=*100%* class=*highslide-maincontent*><iframe src=*" + frmName.ToString + Param + "* height=*200* width=*100%* frameborder=*1* vspace=*0* hspace=*0* marginwidth=*0* marginheight=*0*  scrolling=*yes*>" & _
            "</iframe></div></div>"
            'noresize
            ' HtmlExapnd with Iframe New
            'myStrIF = "<div width=*100%*><a href=" + frmName.ToString + Param + " class=*highslide* onclick=*return hs.htmlExpand(this, {objectType : 'iframe',outlineType : 'rounded-white',maincontentText: 'Student-Details'} )* " + CellTxt + " </a></div>"

            myStrIF = myStrIF.Replace("*", """") : myStrIF = myStrIF.Replace("700", IIf(IfrHt < 300, IfrHt.ToString, "300"))

            Dim myAttributes As AttributeCollection = TCell.Attributes : myAttributes.CssStyle.Add("background-color", "#EBDED6")
            TCell.Text = myStrIF : TCell.ToolTip = itooltip + " Entered" : TCell.Font.Size = FontUnit.XSmall : TCell.Font.Name = "Courier New" : TCell.ColumnSpan = icolspan : TCell.ForeColor = Color.Blue : TCell.Wrap = False

            If RAlign = "M" Then
                TCell.HorizontalAlign = HorizontalAlign.Center
            ElseIf RAlign = "R" Then
                TCell.HorizontalAlign = HorizontalAlign.Right
            ElseIf RAlign = "L" Then
                TCell.HorizontalAlign = HorizontalAlign.Left
            End If
            TCell.VerticalAlign = VerticalAlign.Middle
        End If

        Return TCell
    End Function

    Public Function EnteredstyleMulTarget99(ByVal iText As String, ByVal Coltype As Integer, ByVal Param As String, ByVal frmName As String, ByVal Bg As String, Optional ByVal PrinceDetails As String = "") As TableCell
        Dim TCell As New TableCell

        If iText = "." Then
            TCell.Text = ""
        Else
            Dim myStrIF, CellTxt, CalStr As String
            Dim CalNum, IfrHt As Integer

            'Total(0),Subtotal(1),General(2)

            CalNum = Trim(iText).Length
            If CalNum = 9 Or CalNum = 10 Or Trim(Left(iText, 1)) = "(" Then
                CalStr = iText.Replace("(", "") : CalStr = CalStr.Replace(")", "") : CalNum = Val(CalStr)
            ElseIf CalNum < 9 Or CalNum > 13 Then
                CalNum = Val(Trim(Left(iText, 8)))
            End If
            If CalNum > 0 Then
                If CalNum > 15 Then
                    IfrHt = 300
                Else
                    If CalNum = 1 Then
                        IfrHt = 65
                    Else
                        IfrHt = CalNum * 20 + 25
                    End If
                End If
            Else
                IfrHt = 70
            End If

            Dim myAttributes As AttributeCollection = TCell.Attributes

            Select Case Bg
                Case "BKB"
                    'myAttributes.CssStyle.Add("background-color", "#08088A")
                    myAttributes.CssStyle.Add("background-color", "#A9A9F5")
                    'CellTxt = "<font color='#FF0000'>" + iText + "</font>"
                    CellTxt = "<font color='#FFFFFF'>" + iText + "</font>"

                    'myAttributes.CssStyle.Add("Color", "White")
                    'CellTxt = iText
                    'BGClr = "#08088A" 'BKB
                Case "BKG"
                    'myAttributes.CssStyle.Add("background-color", "#2E3B0B")
                    myAttributes.CssStyle.Add("background-color", "#5DBA9B")
                    'myAttributes.CssStyle.Add("Color", "White")
                    CellTxt = "<font color='#FFFFFF'>" + iText + "</font>"
                    CellTxt = iText
                    'BGClr = "#2E3B0B" 'BKG
                Case "BKN"
                    myAttributes.CssStyle.Add("background-color", "#EBDED6")
                    'myAttributes.CssStyle.Add("background-color", "#EBDED6")
                    'myAttributes.CssStyle.Add("Color", "Blue")
                    CellTxt = "<font color='#0000FF'>" + iText + "</font>"
                    'BGClr = "#EBDED6" 'BKN
                Case "BKR"
                    'myAttributes.CssStyle.Add("background-color", "#DF0101")
                    myAttributes.CssStyle.Add("background-color", "#F78181")
                    'myAttributes.CssStyle.Add("Color", "White")
                    CellTxt = "<font color='#FFFFFF'>" + iText + "</font>"
                    'CellTxt = iText
                    'BGClr = "#DF0101" 'BKR
            End Select

            ' HtmlExapnd with Iframe
            myStrIF = "<div width=*100%*><A class=*highslide* href=*#* onclick=*return hs.htmlExpand(this,{ headingText: '" + PrinceDetails.ToString + "' })*>" + CellTxt + "</A>" & _
            "<div width=*100%* class=*highslide-maincontent*><iframe src=*" + frmName.ToString + Param + "* height=*200* width=*100%* frameborder=*1* vspace=*0* hspace=*0* marginwidth=*0* marginheight=*0*  scrolling=*yes*>" & _
            "</iframe></div></div>"
            'noresize
            ' HtmlExapnd with Iframe New
            'myStrIF = "<div width=*100%*><a href=" + frmName.ToString + Param + " class=*highslide* onclick=*return hs.htmlExpand(this, {objectType : 'iframe',outlineType : 'rounded-white',maincontentText: 'Student-Details'} )* " + CellTxt + " </a></div>"

            myStrIF = myStrIF.Replace("*", """") : myStrIF = myStrIF.Replace("700", IIf(IfrHt < 300, IfrHt.ToString, "300"))

            TCell.Text = myStrIF
            TCell.Font.Size = FontUnit.XSmall
            TCell.Font.Bold = True
            TCell.Font.Name = "Courier New"
            TCell.Wrap = False
            TCell.HorizontalAlign = HorizontalAlign.Right
            TCell.VerticalAlign = VerticalAlign.Middle

        End If

        Return TCell
    End Function

    Public Function EnteredstyleMulMod(ByVal iText As String, ByVal icolspan As Integer, ByVal RAlign As String, ByVal ColType As Integer, ByVal itooltip As String, ByVal Param As String, ByVal frmName As String) As TableCell
        Dim TCell As New TableCell

        If iText = "." Then
            TCell.Text = ""
        Else
            Dim myStrIF, CellTxt, CalStr As String
            Dim CalNum, IfrHt As Integer
            'Total(0),Subtotal(1),General(2)
            If ColType = 0 Then
                CellTxt = "<font color='#FF0000'>" + iText + "</font>"
            ElseIf ColType = 1 Then
                CellTxt = "<font color='#FF00FF'>" + iText + "</font>"
            ElseIf ColType = 2 Then
                CellTxt = "<font color='#0000FF'>" + iText + "</font>"
            End If
            CalNum = Trim(iText).Length
            If CalNum = 9 Or CalNum = 10 Or Trim(Left(iText, 1)) = "(" Then
                CalStr = iText.Replace("(", "") : CalStr = CalStr.Replace(")", "") : CalNum = Val(CalStr)
            ElseIf CalNum < 9 Or CalNum > 13 Then
                CalNum = Val(Trim(Left(iText, 8)))
            End If
            If CalNum > 0 Then
                If CalNum > 15 Then
                    IfrHt = 300
                Else
                    If CalNum = 1 Then
                        IfrHt = 65
                    Else
                        IfrHt = CalNum * 20 + 25
                    End If
                End If
            Else
                IfrHt = 70
            End If

            ' HtmlExapnd with Iframe
            myStrIF = "<div><A class=*branchlinks* href=*#* onclick=*return hs.htmlExpand(this,{ headingText: 'NARAYANA ' })*>" + CellTxt + "</A>" & _
            "<div class=*highslide-maincontent*><iframe src=*" + frmName.ToString + Param + "* height=*auto* width=*100%* frameborder=*1* vspace=*0* hspace=*0* marginwidth=*0* marginheight=*0* noresize>" & _
            "</iframe></div></div>"
            '"<div class=*highslide-maincontent*><iframe src=*" + frmName.ToString + Param + "* height=*900* width=*700* frameborder=*1* vspace=*0* hspace=*0* marginwidth=*0* marginheight=*0* noresize>" & _
            '"<div class=*highslide-maincontent*><iframe src=*" + frmName.ToString + Param + "* style=*overflow: scroll;* frameborder=*1* vspace=*0* hspace=*0* marginwidth=*0* marginheight=*0* noresize>" & _
            'scrolling=*yes*
            'width='100%'
            myStrIF = myStrIF.Replace("*", """")
            'myStrIF = myStrIF.Replace("700", IIf(IfrHt < 300, IfrHt.ToString, "300"))

            Dim myAttributes As AttributeCollection = TCell.Attributes : myAttributes.CssStyle.Add("background-color", "#EBDED6")
            TCell.Text = myStrIF : TCell.ToolTip = itooltip + " Entered" : TCell.Font.Size = FontUnit.XSmall : TCell.Font.Name = "Courier New" : TCell.ColumnSpan = icolspan : TCell.ForeColor = Color.Blue : TCell.Wrap = False

            If RAlign = "M" Then
                TCell.HorizontalAlign = HorizontalAlign.Center
            ElseIf RAlign = "R" Then
                TCell.HorizontalAlign = HorizontalAlign.Right
            ElseIf RAlign = "L" Then
                TCell.HorizontalAlign = HorizontalAlign.Left
            End If
            TCell.VerticalAlign = VerticalAlign.Middle
        End If

        Return TCell
    End Function

    Public Function StrConcTbl(ByVal iText As String) As String
        Try
            Dim vLen As Integer
            Dim Strn As String
            vLen = Trim(iText).Length
            If vLen = 1 Then
                Strn = "[" + StrPadding(iText, 5, "M") + "]"
            ElseIf vLen = 2 Then
                Strn = "[" + StrPadding(iText, 3, "M") + "]"
            ElseIf vLen = 3 Then
                Strn = "[" + StrPadding(iText, 2, "M") + "]"
            ElseIf vLen = 4 Then
                Strn = "[" + StrPadding(iText, 1, "M") + "]"
            End If

            Return Strn
        Catch ex As Exception

        End Try
    End Function

    Public Function EnteredstyleCh1(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Green")
        TCell.Text = iText
        'TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleCh2(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Purple")
        TCell.Text = iText
        'TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleCh3(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.Text = iText
        'TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleCh4(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        'TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleChLeft(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        'TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Left
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleChK(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.Text = iText
        'TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Bold = True
        TCell.Font.Name = "Tahoma"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleBKG(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#5DBA9B")
        'myAttributes.CssStyle.Add("background-color", "#A9F5BC")
        myAttributes.CssStyle.Add("Color", "White")
        TCell.Text = iText
        'TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Bold = True
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleBKB(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        'myAttributes.CssStyle.Add("background-color", "#08088A")
        myAttributes.CssStyle.Add("background-color", "#A9A9F5")
        myAttributes.CssStyle.Add("Color", "White")
        TCell.Text = iText
        'TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Bold = True
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function
    Public Function EnteredstyleBKN(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        'myAttributes.CssStyle.Add("background-color", "#F7819F")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        'TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Bold = True
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleBKR(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        'myAttributes.CssStyle.Add("background-color", "#DF0101")
        myAttributes.CssStyle.Add("background-color", "#F78181")
        myAttributes.CssStyle.Add("Color", "White")
        TCell.Text = iText
        'TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Bold = True
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleChK1(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.Text = iText
        'TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Tahoma" 'Courier New
        TCell.ColumnSpan = icolspan
        TCell.Font.Bold = True
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

#End Region

#Region "Color1 Classic Header Styles"

    Public Function C1Headingstyle(ByVal iText As String, ByVal colspan As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "SteelBlue")
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

    Public Function C1SideHeadingstyle(ByVal iText As String, ByVal iId As String, ByVal colspan As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "WhiteSmoke")
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

    Public Function C1SubHeadingstyle(ByVal iText As String, ByVal iId As String, ByVal icolspan As Integer, ByVal iOrdtxt As String, ByVal iordtyp As String) As TableCell
        Dim TCell As New TableCell
        Dim TLink As New System.Web.UI.WebControls.HyperLink
        'Dim TButton As New System.Web.UI.WebControls.Button
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "WhiteSmoke")
        myAttributes.CssStyle.Add("Color", "Blue")
        TLink.Text = iText
        TLink.ForeColor = Color.Blue
        TLink.NavigateUrl = "Secwisestudentanalysis.aspx?ORD=" + iOrdtxt + "&ORDSTR=" + iordtyp
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

#Region "Color1 Classic Item Styles"

    Public Function C1Enteredstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "WhiteSmoke")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ToolTip = itooltip + " Enter"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function C1NotEnteredstyle(ByVal iText As String, ByVal colspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "WhiteSmoke")
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.Text = iText
        TCell.CssClass = "GridItem"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ToolTip = itooltip + " NotEnter"
        TCell.ColumnSpan = colspan
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function C1TotalEnteredstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "WhiteSmoke")
        'TCell.BackColor = Color.Lavender
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ToolTip = itooltip + "Total Enter"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function C1TotalNotEnteredstyle(ByVal iText As String, ByVal colspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "WhiteSmoke")
        'TCell.BackColor = Color.Lavender
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.Text = iText
        TCell.CssClass = "GridItem"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ToolTip = itooltip + " Total NotEnter"
        TCell.ColumnSpan = colspan
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function


#End Region

#Region "Color0 Classic Header Styles"

    Public Function C0Headingstyle(ByVal iText As String, ByVal colspan As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "Green")
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

    Public Function C0SideHeadingstyle(ByVal iText As String, ByVal iId As String, ByVal colspan As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "OldLace")
        myAttributes.CssStyle.Add("Color", "Green")
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

    Public Function C0SubHeadingstyle(ByVal iText As String, ByVal iId As String, ByVal icolspan As Integer, ByVal iOrdtxt As String, ByVal iordtyp As String) As TableCell
        Dim TCell As New TableCell
        Dim TLink As New System.Web.UI.WebControls.HyperLink
        'Dim TButton As New System.Web.UI.WebControls.Button
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "OldLace")
        myAttributes.CssStyle.Add("Color", "Green")
        TLink.Text = iText
        TLink.ForeColor = Color.Green
        TLink.NavigateUrl = "Secwisestudentanalysis.aspx?ORD=" + iOrdtxt + "&ORDSTR=" + iordtyp
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

#Region "Color0 Classic Item Styles"

    Public Function C0Enteredstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "OldLace")
        myAttributes.CssStyle.Add("Color", "Green")
        TCell.Text = iText
        TCell.ToolTip = itooltip + " Enter"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function C0NotEnteredstyle(ByVal iText As String, ByVal colspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "OldLace")
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.Text = iText
        TCell.CssClass = "GridItem"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ToolTip = itooltip + " NotEnter"
        TCell.ColumnSpan = colspan
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function C0TotalEnteredstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "OldLace")
        'TCell.BackColor = Color.Lavender
        myAttributes.CssStyle.Add("Color", "Green")
        TCell.Text = iText
        TCell.ToolTip = itooltip + " Total Enter"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function C0TotalNotEnteredstyle(ByVal iText As String, ByVal colspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "OldLace")
        'TCell.BackColor = Color.Lavender
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.Text = iText
        TCell.CssClass = "GridItem"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ToolTip = itooltip + "Total NotEnter"
        TCell.ColumnSpan = colspan
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function


#End Region

    'Public Function TableHeadingstyle(ByVal iText As String, ByVal colspan As Integer) As TableCell
    '    Dim TCell As New TableCell
    '    Dim myAttributes As AttributeCollection = TCell.Attributes
    '    myAttributes.CssStyle.Add("background-color", "#EBDED6")
    '    TCell.Text = iText
    '    'TCell.ForeColor = Color.DarkBlue
    '    myAttributes.CssStyle.Add("Color", "#663300")
    '    'myAttributes.CssStyle.Add("Color", "#663300")
    '    myAttributes.CssStyle.Add("font-family", "Verdana,Arial, Helvetica, sans-serif,Tahoma, Georgia, Tahoma, Sans-serif, Helvetica")
    '    TCell.Font.Size = FontUnit.XSmall
    '    'TCell.Font.Name = "Verdana"
    '    TCell.Font.Bold = True
    '    TCell.ColumnSpan = colspan
    '    TCell.Wrap = False
    '    TCell.HorizontalAlign = HorizontalAlign.Center
    '    TCell.VerticalAlign = VerticalAlign.Middle
    '    Return TCell
    'End Function

    Public Function HeadingstyleLeft(ByVal iText As String, ByVal colspan As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        'TCell.ForeColor = Color.DarkBlue
        ' myAttributes.CssStyle.Add("Color", "white")
        'myAttributes.CssStyle.Add("Color", "#663300")
        'myAttributes.CssStyle.Add("font-family", "Verdana,Arial, Helvetica, sans-serif,Tahoma, Georgia, Tahoma, Sans-serif, Helvetica")
        TCell.Font.Size = FontUnit.XSmall
        'TCell.Font.Name = "Verdana"
        TCell.Font.Name = "Courier New"
        TCell.Font.Bold = True
        TCell.ColumnSpan = colspan
        TCell.Wrap = True
        TCell.HorizontalAlign = HorizontalAlign.Left
        TCell.VerticalAlign = VerticalAlign.NotSet
        Return TCell
    End Function
    Public Function HeadingstyleL(ByVal iText As String, ByVal colspan As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#B8773D")
        'myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        'TCell.ForeColor = Color.DarkBlue
        myAttributes.CssStyle.Add("Color", "white")
        'myAttributes.CssStyle.Add("Color", "#663300")
        myAttributes.CssStyle.Add("font-family", "Verdana,Arial, Helvetica, sans-serif,Tahoma, Georgia, Tahoma, Sans-serif, Helvetica")
        TCell.Font.Size = FontUnit.XSmall
        'TCell.Font.Name = "Verdana"
        'TCell.Font.Name = "Courier New"
        TCell.Font.Bold = True
        TCell.ColumnSpan = colspan
        TCell.Wrap = True
        TCell.HorizontalAlign = HorizontalAlign.Left
        TCell.VerticalAlign = VerticalAlign.NotSet
        Return TCell
    End Function
    Public Function HeadingstyleNew2(ByVal iText As String, ByVal colspan As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#B8773D")
        TCell.Text = iText
        'TCell.ForeColor = Color.DarkBlue
        myAttributes.CssStyle.Add("Color", "blue")
        'myAttributes.CssStyle.Add("Color", "#663300")
        ' myAttributes.CssStyle.Add("font-family", "Verdana,Arial, Helvetica, sans-serif,Tahoma, Georgia, Tahoma, Sans-serif, Helvetica")
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        'TCell.Font.Bold = True
        TCell.ColumnSpan = colspan
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Center
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function
    Public Function HeadingstyleRight(ByVal iText As String, ByVal colspan As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#B8773D")
        TCell.Text = iText
        'TCell.ForeColor = Color.DarkBlue
        myAttributes.CssStyle.Add("Color", "white")
        'myAttributes.CssStyle.Add("Color", "#663300")
        myAttributes.CssStyle.Add("font-family", "Verdana,Arial, Helvetica, sans-serif,Tahoma, Georgia, Tahoma, Sans-serif, Helvetica")
        TCell.Font.Size = FontUnit.XXSmall
        'TCell.Font.Name = "Verdana"
        TCell.Font.Bold = True
        TCell.ColumnSpan = colspan
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function
    Public Function SubHeadingstyle(ByVal iText As String, ByVal iId As String, ByVal icolspan As Integer, ByVal iOrdtxt As String, ByVal iordtyp As String, ByVal pNavigateUrl As String, ByVal TCellWidth As Integer) As TableCell
        Dim TCell As New TableCell
        Dim TLink As New System.Web.UI.WebControls.HyperLink
        'Dim TButton As New System.Web.UI.WebControls.Button
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "white")
        TLink.Text = iText
        TLink.ForeColor = Color.Blue
        TLink.NavigateUrl = pNavigateUrl & "?ORD=" + iOrdtxt + "&ORDSTR=" + iordtyp '"Secwisestudentanalysis.aspx?ORD=" + iOrdtxt + "&ORDSTR=" + iordtyp
        TCell.Controls.Add(TLink)
        TCell.ID = iId
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        TCell.Height = Unit.Pixel(25)
        TCell.Width = Unit.Pixel(TCellWidth)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Center
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function
    Public Function HeadingstyleRightNew(ByVal iText As String, ByVal colspan As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#B8773D")
        TCell.Text = iText
        'TCell.ForeColor = Color.DarkBlue
        myAttributes.CssStyle.Add("Color", "white")
        'myAttributes.CssStyle.Add("Color", "#663300")
        myAttributes.CssStyle.Add("font-family", "Verdana,Arial, Helvetica, sans-serif,Tahoma, Georgia, Tahoma, Sans-serif, Helvetica")
        TCell.Font.Size = FontUnit.XXSmall
        'TCell.Font.Name = "Verdana"
        TCell.Font.Bold = True
        TCell.ColumnSpan = colspan
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function
    Public Function RightAlignstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ToolTip = itooltip
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function
    Public Function RightAlignstyle(ByVal iText As String, ByVal icolspan As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText

        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function
    Public Function RightAlignstyleVATop(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String, ByVal Total As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes

        If Total = 1 Then
            myAttributes.CssStyle.Add("background-color", "#F781BE")
            TCell.Font.Bold = True
        Else
            myAttributes.CssStyle.Add("background-color", "#EBDED6")
        End If
        myAttributes.CssStyle.Add("Color", "Blue")

        TCell.Text = iText
        TCell.ToolTip = itooltip
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Top
        Return TCell
    End Function
    Public Function LeftAlignstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ToolTip = itooltip
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Left
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function
    Public Function LeftAlignstyleVATop(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String, ByVal Total As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        If Total = 1 Then
            myAttributes.CssStyle.Add("background-color", "#F781BE")
            TCell.Font.Bold = True
        Else
            myAttributes.CssStyle.Add("background-color", "#EBDED6")
        End If
        myAttributes.CssStyle.Add("Color", "Blue")

        ' myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ToolTip = itooltip
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Left
        TCell.VerticalAlign = VerticalAlign.Top
        Return TCell
    End Function

    Public Function CenterAlignstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ToolTip = itooltip
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Center
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function
    Public Function CenterAlignstyleVATop(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String, ByVal Total As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes

        If Total = 1 Then
            myAttributes.CssStyle.Add("background-color", "#F781BE")
            TCell.Font.Bold = True
        Else
            myAttributes.CssStyle.Add("background-color", "#EBDED6")
        End If
        myAttributes.CssStyle.Add("Color", "Blue")


        TCell.Text = iText
        TCell.ToolTip = itooltip
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Center
        TCell.VerticalAlign = VerticalAlign.Top
        Return TCell
    End Function

    Public Function Totalsstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.Text = iText
        TCell.ToolTip = itooltip
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Bold = True
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    'Venu on 15-Feb-2011
    Public Function VEnteredstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        If itooltip.StartsWith("SubTotals") Then
            myAttributes.CssStyle.Add("Color", "OrangeRed")
        ElseIf itooltip.StartsWith("Totals") Then
            myAttributes.CssStyle.Add("Color", "Purple")
        ElseIf itooltip.StartsWith("GRANDTOTAL") Then
            myAttributes.CssStyle.Add("Color", "Red")
        Else
            myAttributes.CssStyle.Add("Color", "Red")
        End If

        TCell.ToolTip = IIf(itooltip <> "", itooltip.ToUpper, "GrandTotals")
        TCell.Text = iText
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Bold = True
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function
    Public Function VEnteredstyleTest(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        If itooltip.StartsWith("SubTotals") Then
            myAttributes.CssStyle.Add("Color", "OrangeRed")
        ElseIf itooltip.StartsWith("Totals") Then
            myAttributes.CssStyle.Add("Color", "Purple")
        ElseIf itooltip.StartsWith("GRANDTOTAL") Then
            myAttributes.CssStyle.Add("Color", "Red")
        Else
            myAttributes.CssStyle.Add("Color", "Red")
        End If

        TCell.ToolTip = IIf(itooltip <> "", itooltip.ToUpper, "GrandTotals")
        TCell.Text = iText
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Bold = True
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Left
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function
    Public Function VVEnteredstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        If itooltip = "MainTotal" Then
            myAttributes.CssStyle.Add("Color", "OrangeRed")
        ElseIf itooltip = "SubTotals" Then
            myAttributes.CssStyle.Add("Color", "Purple")
        Else
            myAttributes.CssStyle.Add("Color", "Green")
        End If
        'TCell.BackColor.Purple()


        TCell.Text = iText
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function
    Public Function FacultyEnteredstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        If itooltip = "R" Then
            myAttributes.CssStyle.Add("Color", "Red")
        ElseIf itooltip = "G" Then
            myAttributes.CssStyle.Add("Color", "Green")
        ElseIf itooltip = "B" Then
            myAttributes.CssStyle.Add("Color", "Blue")
        End If

        TCell.Text = iText
        TCell.Font.Bold = True
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        TCell.Width = Unit.Pixel(30)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Center
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function FacultyEnteredstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String, ByVal iUnitPixel As Integer) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        If itooltip = "R" Then
            myAttributes.CssStyle.Add("Color", "Red")
        ElseIf itooltip = "G" Then
            myAttributes.CssStyle.Add("Color", "Green")
        ElseIf itooltip = "B" Then
            myAttributes.CssStyle.Add("Color", "Blue")
        End If

        TCell.Text = iText
        TCell.Font.Bold = True
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Width = Unit.Pixel(iUnitPixel)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Center
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function FacultyEnteredstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String, ByVal iUnitPixel As Integer, ByVal iLink As String) As TableCell
        Dim TCell As New TableCell
        Dim TLink As New System.Web.UI.WebControls.HyperLink
        Dim myAttributes As AttributeCollection = TCell.Attributes
        TLink.Text = iText
        TLink.NavigateUrl = iLink
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        If itooltip = "R" Then
            TLink.ForeColor = Color.Red
            'myAttributes.CssStyle.Add("Color", "Red")
        ElseIf itooltip = "G" Then
            TLink.ForeColor = Color.Green
            'myAttributes.CssStyle.Add("Color", "Green")
        ElseIf itooltip = "B" Then
            TLink.ForeColor = Color.Blue
            'myAttributes.CssStyle.Add("Color", "Blue")
        End If
        TCell.Controls.Add(TLink)

        'TCell.Text = iText
        TCell.Font.Bold = True
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Width = Unit.Pixel(iUnitPixel)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Center
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function CenEnteredstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Blue")
        TCell.Text = iText
        TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Center
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function
    Public Function TotCenEnteredstyle(ByVal iText As String, ByVal icolspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.Text = iText
        TCell.ToolTip = itooltip + " Entered"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.Font.Bold = True
        TCell.ColumnSpan = icolspan
        'TCell.Height = Unit.Pixel(25)
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Center
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function
    Public Function NotEnteredstyle(ByVal iText As String, ByVal colspan As Integer, ByVal itooltip As String) As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.BackColor = Color.White
        TCell.ForeColor = Color.Red
        TCell.BorderColor = Color.Orange
        TCell.Text = iText
        TCell.CssClass = "GridItem"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ToolTip = itooltip + " NotEnter"
        TCell.ColumnSpan = colspan
        TCell.Wrap = False
        TCell.HorizontalAlign = HorizontalAlign.Right
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function NotEnteredstyleMod(ByVal iText As String, ByVal colspan As Integer, ByVal itooltip As String, Optional ByVal Align As String = "") As TableCell
        Dim TCell As New TableCell
        Dim myAttributes As AttributeCollection = TCell.Attributes
        myAttributes.CssStyle.Add("background-color", "#EBDED6")
        myAttributes.CssStyle.Add("Color", "Red")
        TCell.BackColor = Color.White
        TCell.ForeColor = Color.Red
        TCell.BorderColor = Color.Orange
        TCell.Text = iText
        TCell.CssClass = "GridItem"
        TCell.Font.Size = FontUnit.XSmall
        TCell.Font.Name = "Courier New"
        TCell.ToolTip = itooltip
        TCell.ColumnSpan = colspan
        TCell.Wrap = False
        If Align = "R" Or Align = "" Then
            TCell.HorizontalAlign = HorizontalAlign.Right
        ElseIf Align = "L" Then
            TCell.HorizontalAlign = HorizontalAlign.Left
        ElseIf Align = "C" Then
            TCell.HorizontalAlign = HorizontalAlign.Center
        End If
        TCell.VerticalAlign = VerticalAlign.Middle
        Return TCell
    End Function

    Public Function EnteredstyleMulRequest(ByVal iText As String, ByVal icolspan As Integer, ByVal RAlign As String, ByVal ColType As Integer, ByVal itooltip As String, ByVal Param As String, ByVal frmName As String, ByVal ifrmHeight As Integer, ByVal ifrmWidth As Integer) As TableCell
        Dim TCell As New TableCell

        If iText = "." Then
            TCell.Text = ""
        Else
            Dim myStrIF, CellTxt, CalStr As String
            Dim CalNum, IfrHt As Integer
            'Total(0),Subtotal(1),General(2)
            If ColType = 0 Then
                CellTxt = "<font color='#FF0000'>" + iText + "</font>"
            ElseIf ColType = 1 Then
                CellTxt = "<font color='#FF00FF'>" + iText + "</font>"
            ElseIf ColType = 2 Then
                CellTxt = "<font color='#0000FF'>" + iText + "</font>"
            End If
            CalNum = Trim(iText).Length
            If CalNum = 9 Or CalNum = 10 Or Trim(Left(iText, 1)) = "(" Then
                CalStr = iText.Replace("(", "") : CalStr = CalStr.Replace(")", "") : CalNum = Val(CalStr)
            ElseIf CalNum < 9 Or CalNum > 13 Then
                CalNum = Val(Trim(Left(iText, 8)))
            End If

            ' HtmlExapnd with Iframe
            myStrIF = "<div><A class=*branchlinks* href=*#* onclick=*return hs.htmlExpand(this,{ headingText: 'NARAYANA ' })*>" + CellTxt + "</A>" & _
            "<div class=*highslide-maincontent*><iframe src=*" + frmName.ToString + Param + "* height=*300* width=*700* frameborder=*1* vspace=*0* hspace=*0* marginwidth=*0* marginheight=*0* noresize>" & _
            "</iframe></div></div>"
            myStrIF = myStrIF.Replace("*", """")
            myStrIF = myStrIF.Replace("300", ifrmHeight)
            myStrIF = myStrIF.Replace("700", ifrmWidth)

            Dim myAttributes As AttributeCollection = TCell.Attributes : myAttributes.CssStyle.Add("background-color", "#EBDED6")
            TCell.Text = myStrIF : TCell.ToolTip = itooltip + " Entered" : TCell.Font.Size = FontUnit.XSmall : TCell.Font.Name = "Courier New" : TCell.ColumnSpan = icolspan : TCell.ForeColor = Color.Blue : TCell.Wrap = False

            If RAlign = "M" Then
                TCell.HorizontalAlign = HorizontalAlign.Center
            ElseIf RAlign = "R" Then
                TCell.HorizontalAlign = HorizontalAlign.Right
            ElseIf RAlign = "L" Then
                TCell.HorizontalAlign = HorizontalAlign.Left
            End If
            TCell.VerticalAlign = VerticalAlign.Middle
        End If

        Return TCell
    End Function

#Region " Linked Functions [Venu]"

    Public Function ReportFormatTableLink(ByVal StrCol As String, ByVal frmname As String, ByVal TblRpt As System.Web.UI.WebControls.Table, ByVal LstExams As ListBox, ByVal DsMain As DataSet, ByVal DsMain1 As DataSet, ByVal Dsmain2 As DataSet, ByVal DSPASS As DataSet, ByVal DtV As DataView, ByVal Mdv As DataView, ByVal Fdv As DataView, ByVal Adv As DataView, ByVal Nedv As DataView, ByVal RdbF As Boolean) As Table
        Try
            'NoOfExams = Session("NoOfExams")
            Dim i, v As Integer
            frmname = "../../Reports/TextReports/TrackPFAnalCorpSchWiseDet.aspx"
            Dim vLen, ExLen, NoOfCol, S, SBJ, SbjPre, SbjPrv As Integer
            Dim HD, HD1, HD2, HD3 As TableRow
            Dim TRP, TRF, TRA, TRNC, TRNE, TRTOT As TableRow
            Dim StrP, StrF, StrA, StrNE, StrNC, StrTot, StrTp, StrTf, StrTa, StrTNE, StrTNC, StrTTot As String
            Dim STRTRACK, SubjDate, SubTotal As String
            Dim BPERCENTAGE As Decimal
            HD1 = New TableRow
            HD1.Cells.Add(Headingstyle("", 4))
            HD1.Cells.Add(Headingstyle("", 2))
            TblRpt.Rows.Add(HD1)

            'Sub Heading
            HD1 = New TableRow : HD2 = New TableRow : HD3 = New TableRow
            HD1.Cells.Add(Headingstyle("S.NO", 1))
            HD1.Cells.Add(Headingstyle("CAMPUS", 1))
            HD1.Cells.Add(Headingstyle("Cstrn", 1))
            HD1.Cells.Add(Headingstyle("", 1))
            HD2.Cells.Add(Headingstyle("", 4))
            NoOfCol = 0
            For S = 0 To LstExams.Items.Count - 1
                Dim SBJDR() As DataRow
                SBJDR = DsMain.Tables(2).Select("DEXAMSLNO='" & LstExams.Items(S).Value.ToString & "'")

                If SBJDR.Length > 0 Then
                    For SBJ = 0 To SBJDR.Length - 1
                        SubjDate = "" : STRTRACK = "" : SubTotal = ""
                        SbjPre = Sbjdr(SBJ)("SUBJECTSLNO")
                        If SbjPre = SbjPrv Then
                            HD1.Cells.Add(Headingstyle(StrPadding(SBJDR(SBJ)("SUBJECTNAME").TOSTRING + "-" + SBJDR(SBJ)("TRACKSLNO").TOSTRING, 22, "M"), 1))
                        Else
                            HD1.Cells.Add(Headingstyle(StrPadding(SBJDR(SBJ)("SUBJECTNAME").TOSTRING, 22, "M"), 1))
                        End If
                        STRTRACK = STRTRACK & (StrPadding(SBJDR(SBJ)("TRACKNAME").ToString, 22, "M"))
                        SubjDate = SubjDate & (StrPadding(SBJDR(SBJ)("SUBJECTDATE").ToString, 22, "M"))
                        HD2.Cells.Add(Headingstyle(SubjDate, 1))
                        NoOfCol += 1
                        SbjPrv = SbjPre
                    Next
                Else
                    SubjDate = "" : STRTRACK = "" : SubTotal = ""
                    SbjPre = Sbjdr(SBJ)("SUBJECTSLNO")
                    If SbjPre = SbjPrv Then
                        HD1.Cells.Add(Headingstyle(StrPadding(SBJDR(SBJ)("SUBJECTNAME").TOSTRING + "-" + SBJDR(SBJ)("TRACKSLNO").TOSTRING, 22, "M"), 1))
                    Else
                        HD1.Cells.Add(Headingstyle(StrPadding(SBJDR(SBJ)("SUBJECTNAME").TOSTRING, 22, "M"), 1))
                    End If
                    STRTRACK = STRTRACK & (StrPadding(" ", 10, "M"))
                    SubjDate = SubjDate & (StrPadding(" ", 22, "M"))
                    HD2.Cells.Add(Headingstyle(SubjDate, 1))
                    NoOfCol += 1
                    SbjPrv = SbjPre
                End If
            Next

            HD1.Cells.Add(Headingstyle("Est Avg Rank", 1))
            HD1.Cells.Add(Headingstyle("CAMPUS", 1))
            HD2.Cells.Add(Headingstyle("", 2))
            TblRpt.Rows.Add(HD1)
            TblRpt.Rows.Add(HD2)

            Dim MMarks As Integer = 0.0 : Dim Rslno As Integer = 0
            Dim DRV As DataRowView : Dim IYES As Boolean = False : Dim SLNO As Integer = 0

            For Each DRV In DtV 'EST PASS ORDER
                SLNO = SLNO + 1
                Dim EBDR() As DataRow
                EBDR = DsMain.Tables(0).Select(StrCol & "='" & DRV(StrCol).ToString & "'")
                For i = 0 To EBDR.Length - 1    ' THIS EXAM BRANCH LOOP

                    Dim DR() As DataRow
                    TRP = New TableRow : TRF = New TableRow : TRA = New TableRow : TRNC = New TableRow : TRNE = New TableRow : TRTOT = New TableRow
                    TRP.Cells.Add(CenEnteredstyle(SLNO, 1, ""))

                    If StrCol = "PRVSCHOOLSLNO" Then
                        'TRP.Cells.Add(LEFTEnteredstyle(EBDR(i)("NAME").ToString, 1, "L"))
                        TRP.Cells.Add(LeftAlignstyle(Left(EBDR(i)("NAME").ToString, 5), 1, ""))
                    Else
                        TRP.Cells.Add(NotEnterdlink(EBDR(i)("NAME").ToString, "L", 1, frmname & "?LnkSlno=" & EBDR(i)(StrCol).ToString & "&RdbF=" & RdbF.ToString))
                    End If

                    TRP.Cells.Add(Enteredstyle(EBDR(i)("TOTALSTU").ToString, 1, "R"))
                    TRF.Cells.Add(Enteredstyle("", 3, "")) : TRA.Cells.Add(Enteredstyle("", 3, "")) : TRNE.Cells.Add(Enteredstyle("", 3, "")) : TRNC.Cells.Add(Enteredstyle("", 3, "")) : TRTOT.Cells.Add(Enteredstyle("", 3, ""))
                    TRP.Cells.Add(LeftAlignstyle("P:", 1, "")) : TRF.Cells.Add(LeftAlignstyle("F:", 1, "")) : TRA.Cells.Add(LeftAlignstyle("A:", 1, "")) : TRNE.Cells.Add(LeftAlignstyle("NE:", 1, "")) : TRNC.Cells.Add(LeftAlignstyle("NC:", 1, "")) : TRTOT.Cells.Add(LeftAlignstyle("S:", 1, ""))

                    '' EXAM WISE LOOP
                    For E As Integer = 0 To LstExams.Items.Count - 1
                        Dim SBJDR() As DataRow
                        SBJDR = DsMain.Tables(2).Select("DEXAMSLNO='" & LstExams.Items(E).Value.ToString & "'")
                        If SBJDR.Length > 0 Then
                            For T As Integer = 0 To SBJDR.Length - 1 '
                                Dim TRDR() As DataRow
                                TRDR = DsMain.Tables(2).Select("DEXAMSLNO='" & SBJDR(T)("DEXAMSLNO").ToString & "' AND SUBJECTSLNO='" & SBJDR(T)("SUBJECTSLNO").ToString & "'")
                                If TRDR.Length > 0 Then
                                    For TR As Integer = 0 To TRDR.Length - 1 'TRACK LOOP
                                        StrP = "" : StrF = "" : StrA = "" : StrNE = "" : StrNC = "" : StrTot = ""
                                        'THIs LOOP FOR TRACK WISE
                                        BPERCENTAGE = 0.0
                                        Dim DRS() As DataRow
                                        Dim COUNTDR() As DataRow

                                        Mdv.RowFilter = StrCol & "='" & EBDR(v)(StrCol).ToString & _
                                                                 "' AND DEXAMSLNO='" & TRDR(TR)("DEXAMSLNO").ToString & _
                                                                 "' AND SUBJECTSLNO='" & SBJDR(T)("SUBJECTSLNO").ToString & _
                                                                 "' AND TRACKSLNO='" & TRDR(TR)("TRACKSLNO").ToString & "'"

                                        COUNTDR = Dsmain2.Tables(0).Select(StrCol & "='" & EBDR(v)(StrCol).ToString & _
                                                                        "' AND DEXAMSLNO='" & TRDR(TR)("DEXAMSLNO").ToString & "'")

                                        Dim EBTOTAL As Integer = 0
                                        If COUNTDR.Length > 0 Then
                                            EBTOTAL = Val(COUNTDR(0)("TOTALSTU"))
                                        End If

                                        If Mdv.Count > 0 Then

                                            'Pass
                                            If Not IsDBNull(Mdv(0).Row("PASSTOTAL")) Then
                                                If Not IsDBNull(Mdv(0).Row("PASSPER")) Then
                                                    BPERCENTAGE = CDec(Mdv(0).Row("PASSPER"))
                                                Else
                                                    BPERCENTAGE = 0.0
                                                End If
                                                StrP += StrPadding(Mdv(0).Row("PASSTOTAL").ToString, 8, "R") + "("
                                                StrP += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                                                StrP += StrConcTbl(Mdv(0).Row("PASSRANK").ToString)
                                            Else
                                                StrP = "."
                                            End If

                                            'Fail
                                            If Not IsDBNull(Mdv(0).Row("FAILTOTAL")) Then
                                                If Not IsDBNull(Mdv(0).Row("FAILPER")) Then
                                                    BPERCENTAGE = CDec(Mdv(0).Row("FAILPER"))
                                                Else
                                                    BPERCENTAGE = 0.0
                                                End If
                                                StrF += StrPadding(Mdv(0).Row("FAILTOTAL").ToString, 8, "R") + "("
                                                StrF += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                                                StrF += StrConcTbl(Mdv(0).Row("FAILRANK").ToString)
                                            Else
                                                StrF = "."
                                            End If

                                            'Absent
                                            If Not IsDBNull(Mdv(0).Row("ABSENTTOTAL")) Then
                                                If Not IsDBNull(Mdv(0).Row("ABSENTPER")) Then
                                                    BPERCENTAGE = CDec(Mdv(0).Row("ABSENTPER"))
                                                Else
                                                    BPERCENTAGE = 0.0
                                                End If
                                                StrA += StrPadding(Mdv(0).Row("ABSENTTOTAL").ToString, 8, "R") + "("
                                                StrA += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                                                StrA += StrConcTbl(Mdv(0).Row("ABSENTRANK").ToString)
                                            Else
                                                StrA = "."
                                            End If

                                            'NotEntered
                                            Dim NOTBE As Double
                                            NOTBE = 0
                                            If Not IsDBNull(Mdv(0).Row("PASSTOTAL")) Then NOTBE = Val(Mdv(0).Row("PASSTOTAL"))
                                            If Not IsDBNull(Mdv(0).Row("FAILTOTAL")) Then NOTBE = NOTBE + Val(Mdv(0).Row("FAILTOTAL"))
                                            If Not IsDBNull(Mdv(0).Row("ABSENTTOTAL")) Then NOTBE = NOTBE + Val(Mdv(0).Row("ABSENTTOTAL"))
                                            NOTBE = EBTOTAL - NOTBE
                                            If NOTBE > 0 Then
                                                BPERCENTAGE = (NOTBE / EBTOTAL) * 100
                                                StrNE += StrPadding(NOTBE.ToString, 8, "R") + "(" + StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")[" + StrPadding(" ", 4, "R") + "]"
                                            Else
                                                StrNE = "."
                                            End If

                                            'Total
                                            Dim TOTALSTRN As Double = Val(Mdv(0).Row("PASSTOTAL").ToString) + Val(Mdv(0).Row("FAILTOTAL").ToString) + Val(Mdv(0).Row("ABSENTTOTAL").ToString)
                                            If Not IsDBNull(TOTALSTRN) Then
                                                vLen = Len(Trim(TOTALSTRN.ToString))
                                                If vLen = 1 Then
                                                    StrTot += "(" + StrPadding(TOTALSTRN.ToString, 7, "M") + ")"
                                                Else
                                                    StrTot += "(" + StrPadding(TOTALSTRN.ToString, 8, "R") + ")"
                                                End If
                                            Else
                                                StrTot = "."
                                            End If

                                            'NotConducted
                                            Dim TOTALNC As Double = 0
                                            TOTALNC = Val(EBDR(v)("TOTALSTU").ToString) - EBTOTAL
                                            If TOTALNC > 0 Then
                                                BPERCENTAGE = (TOTALNC / Val(EBDR(v)("TOTALSTU").ToString)) * 100
                                                StrNC += StrPadding((EBDR(v)("TOTALSTU") - EBTOTAL), 8, "R")
                                                StrNC += StrPadding("(", 1, "L")
                                                StrNC += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R")
                                                StrNC += StrPadding(")", 1, "L")
                                                StrNC += StrConcTbl(".")
                                            Else
                                                StrNC += ""
                                            End If
                                        Else
                                            StrP = "." : StrF = "." : StrA = "." : StrNE = "." : StrTot = "."
                                            If (EBDR(v)("TOTALSTU") - EBTOTAL) > 0 Then
                                                BPERCENTAGE = ((EBDR(v)("TOTALSTU") - EBTOTAL) / Val(EBDR(v)("TOTALSTU")) * 100)
                                                StrNC += StrPadding((EBDR(v)("TOTALSTU") - EBTOTAL), 8, "R")
                                                StrNC += StrPadding("(", 1, "L")
                                                StrNC += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R")
                                                StrNC += StrPadding(")", 1, "L")
                                                StrNC += StrConcTbl(".")
                                            Else
                                                StrNC += "."
                                            End If
                                        End If
                                        TRP.Cells.Add(Enteredstyle(IIf(StrP <> ".", StrP, ""), 1, ""))
                                        TRF.Cells.Add(Enteredstyle(IIf(StrF <> ".", StrF, ""), 1, ""))
                                        TRA.Cells.Add(Enteredstyle(IIf(StrA <> ".", StrA, ""), 1, ""))
                                        TRNE.Cells.Add(Enteredstyle(IIf(StrNE <> ".", StrNE, ""), 1, ""))
                                        TRNC.Cells.Add(Enteredstyle(IIf(StrNC <> ".", StrNC, ""), 1, ""))
                                        If StrTot <> "." Then
                                            TRTOT.Cells.Add(Enteredstyle(StrTot, 1, ""))
                                        Else
                                            TRTOT.Cells.Add(Enteredstyle("", 1, ""))
                                        End If
                                    Next 'END OF TRACK WISE LOOP
                                End If
                            Next 'END OF  SUBJECT WISE LOOP
                        End If
                    Next ' END OF EXAM WISE LOOP

                    StrTp = "" : StrTf = "" : StrTa = "" : StrTNE = "" : StrTNC = "" : StrTTot = ""

                    'EST TOTAL & RANK FOR PASS
                    Dim ESTBSTR As Double
                    Dim ESTDR() As DataRow
                    IYES = True
                    ESTBSTR = DRV("ESTTOTAL")
                    If Not IsDBNull(DRV("ESTTOTAL")) And DRV("ESTTOTAL") > 0 Then
                        If Not IsDBNull(DRV("ESTPASSPER")) Then
                            BPERCENTAGE = CDec(DRV("ESTPASSPER"))
                        Else
                            BPERCENTAGE = 0.0
                        End If
                        StrTp += StrPadding(DRV("ESTTOTAL").ToString, 8, "R") + "("
                        StrTp += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                        StrTp += StrConcTbl(DRV("ESTRANK").ToString)
                    Else
                        StrTp = "."
                    End If
                    'END OF EST TOTAL & RANK FOR PASS

                    'EST TOTAL & RANK FOR FAIL
                    Fdv.RowFilter = StrCol & "='" & EBDR(v)(StrCol).ToString & "'"
                    If Fdv.Count > 0 Then
                        If Not IsDBNull(Fdv(0).Row("ESTTOTAL")) And Fdv(0).Row("ESTTOTAL") > 0 Then
                            ESTBSTR = ESTBSTR + Fdv(0).Row("ESTTOTAL")
                            If Not IsDBNull(Fdv(0).Row("ESTPER")) Then
                                BPERCENTAGE = CDec(Fdv(0).Row("ESTPER"))
                            Else
                                BPERCENTAGE = 0.0
                            End If
                            StrTf += StrPadding(Fdv(0).Row("ESTTOTAL").ToString, 8, "R") + "("
                            StrTf += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                            StrTf += StrConcTbl(Fdv(0).Row("ESTRANK").ToString)
                        Else
                            StrTf = "."
                        End If
                    Else
                        StrTf = "."
                    End If
                    'END OF EST TOTAL & RANK FOR FAIL

                    'EST TOTAL & RANK FOR ABSENT
                    Adv.RowFilter = StrCol & "='" & EBDR(v)(StrCol).ToString & "'"
                    If Adv.Count > 0 Then
                        If Not IsDBNull(Adv(0).Row("ESTTOTAL")) And Adv(0).Row("ESTTOTAL") > 0 Then
                            ESTBSTR = ESTBSTR + Adv(0).Row("ESTTOTAL")
                            If Not IsDBNull(Adv(0).Row("ESTPER")) Then
                                BPERCENTAGE = CDec(Adv(0).Row("ESTPER"))
                            Else
                                BPERCENTAGE = 0.0
                            End If
                            StrTa += StrPadding(Adv(0).Row("ESTTOTAL").ToString, 8, "R") + "("
                            StrTa += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                            StrTa += StrConcTbl(Adv(0).Row("ESTRANK").ToString)
                        Else
                            StrTa = "."
                        End If
                    Else
                        StrTa = "."
                    End If
                    'END OF EST TOTAL & RANK FOR ABSENT

                    'EST TOTAL OF NOT NOT ENTER
                    Nedv.RowFilter = StrCol & "='" & EBDR(v)(StrCol).ToString & "'"
                    If Nedv.Count > 0 Then
                        If Not IsDBNull(Nedv(0).Row("ESTTOTAL")) And Nedv(0).Row("ESTTOTAL") > 0 Then
                            If Not IsDBNull(Nedv(0).Row("ESTPER")) Then
                                BPERCENTAGE = CDec(Nedv(0).Row("ESTPER"))
                            Else
                                BPERCENTAGE = 0.0
                            End If
                            StrTNE += StrPadding(Nedv(0).Row("ESTTOTAL").ToString, 8, "R") + "("
                            StrTNE += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                            StrTNE += StrConcTbl(Nedv(0).Row("ESTRANK").ToString)
                        Else
                            StrTNE = "."
                        End If
                    Else
                        StrTNE = "."
                    End If
                    ' END OF EST TOTAL OF NOT NOT ENTER

                    'EST TOTAL OF NOT NOT CONDECTED
                    StrNC = "."
                    ' END OF EST TOTAL OF NOT NOT CONDECTED
                    If Not IsDBNull(ESTBSTR) Then
                        vLen = Len(Trim(ESTBSTR.ToString))
                        If vLen = 1 Then
                            StrTTot += "(" + StrPadding(ESTBSTR.ToString, 7, "M") + ")"
                        Else
                            StrTTot += "(" + StrPadding(ESTBSTR.ToString, 8, "R") + ")"
                        End If
                    Else
                        StrTTot = "."
                    End If
                    TRP.Cells.Add(Enteredstyle(IIf(StrTp <> ".", StrTp, ""), 1, "")) : TRP.Cells.Add(LeftAlignstyle(EBDR(v)("NAME").ToString(), 1, ""))
                    TRF.Cells.Add(Enteredstyle(IIf(StrTf <> ".", StrTf, ""), 1, "")) : TRF.Cells.Add(Enteredstyle("", 1, ""))
                    TRA.Cells.Add(Enteredstyle(IIf(StrTa <> ".", StrTa, ""), 1, "")) : TRA.Cells.Add(Enteredstyle("", 1, ""))
                    TRNE.Cells.Add(Enteredstyle(IIf(StrTNE <> ".", StrTNE, ""), 1, "")) : TRNE.Cells.Add(Enteredstyle("", 1, ""))
                    TRNC.Cells.Add(Enteredstyle(IIf(StrTNC <> ".", StrTNC, ""), 1, "")) : TRNC.Cells.Add(Enteredstyle("", 1, ""))
                    If StrTot <> "." Then
                        TRTOT.Cells.Add(Enteredstyle(StrTTot, 1, ""))
                    Else
                        TRTOT.Cells.Add(Enteredstyle("", 1, ""))
                    End If
                    TRTOT.Cells.Add(Enteredstyle("", 1, ""))
                Next 'END OF EXAM BRANCH LOOP
                TblRpt.Rows.Add(TRP) : TblRpt.Rows.Add(TRF) : TblRpt.Rows.Add(TRA) : TblRpt.Rows.Add(TRNE) : TblRpt.Rows.Add(TRNC) : TblRpt.Rows.Add(TRTOT)
            Next  ''END OF EST PASS ORDER

            ''BOTTOM TOTALS 
            Dim MtStrP, MtStrF, MtStrA, MtStrNE, MtStrNC, MtStrTot As String

            Dim TOTALS, TOTALEXAM As Double
            Dim FAdr() As DataRow
            TRP = New TableRow : TRF = New TableRow : TRA = New TableRow : TRNC = New TableRow : TRNE = New TableRow : TRTOT = New TableRow
            TRP.Cells.Add(LeftAlignstyle(" TOTAL : ", 2, ""))
            TOTALS = DsMain.Tables(0).Compute("SUM(TOTALSTU)", " ")
            TRP.Cells.Add(Enteredstyle(TOTALS.ToString, 1, ""))
            TRF.Cells.Add(Enteredstyle("", 3, "")) : TRA.Cells.Add(Enteredstyle("", 3, "")) : TRNE.Cells.Add(Enteredstyle("", 3, "")) : TRNC.Cells.Add(Enteredstyle("", 3, "")) : TRTOT.Cells.Add(Enteredstyle("", 3, ""))
            TRP.Cells.Add(LeftAlignstyle("P:", 1, "")) : TRF.Cells.Add(LeftAlignstyle("F:", 1, "")) : TRA.Cells.Add(LeftAlignstyle("A:", 1, "")) : TRNE.Cells.Add(LeftAlignstyle("NE:", 1, "")) : TRNC.Cells.Add(LeftAlignstyle("NC:", 1, "")) : TRTOT.Cells.Add(LeftAlignstyle("S:", 1, ""))
            For L As Integer = 0 To LstExams.Items.Count - 1 'EXAMS LOOP
                Dim SBJDR() As DataRow
                SBJDR = DsMain.Tables(2).Select("DEXAMSLNO='" & LstExams.Items(L).Value.ToString & "'")
                If SBJDR.Length > 0 Then
                    For T As Integer = 0 To SBJDR.Length - 1
                        Dim TRDR() As DataRow
                        TRDR = DsMain.Tables(2).Select("DEXAMSLNO='" & SBJDR(T)("DEXAMSLNO").ToString & "' AND SUBJECTSLNO='" & SBJDR(T)("SUBJECTSLNO").ToString & "'")
                        If TRDR.Length > 0 Then
                            For Tr As Integer = 0 To TRDR.Length - 1
                                MtStrP = "" : MtStrF = "" : MtStrA = "" : MtStrNE = "" : MtStrNC = "" : MtStrTot = ""
                                FAdr = DsMain.Tables(1).Select("DEXAMSLNO='" & TRDR(Tr)("DEXAMSLNO").ToString & "'")

                                If Not IsDBNull(DsMain.Tables(1).Compute("SUM(ASRTOTAL)", "DEXAMSLNO='" & TRDR(Tr)("DEXAMSLNO").ToString & "' AND SUBJECTSLNO='" & SBJDR(T)("SUBJECTSLNO").ToString & "'")) Then
                                    TOTALEXAM = DsMain.Tables(1).Compute("SUM(ASRTOTAL)", "DEXAMSLNO='" & TRDR(Tr)("DEXAMSLNO").ToString & "' AND SUBJECTSLNO='" & SBJDR(T)("SUBJECTSLNO").ToString & "'")
                                Else
                                    TOTALEXAM = 0.0
                                End If

                                If Not IsDBNull(Dsmain2.Tables(0).Compute("SUM(TOTALSTU)", "DEXAMSLNO='" & TRDR(Tr)("DEXAMSLNO").ToString & "'")) Then
                                    TOTALS = Dsmain2.Tables(0).Compute("SUM(TOTALSTU)", "DEXAMSLNO='" & TRDR(Tr)("DEXAMSLNO").ToString & "'")
                                Else
                                    TOTALS = 0.0
                                End If

                                If FAdr.Length > 0 Then
                                    Dim pSUBJTOTAL, fSUBJTOTAL, aSUBJTOTAL, NeNTER As Double

                                    If Not IsDBNull(DsMain.Tables(1).Compute("SUM(PASSTOTAL)", "DEXAMSLNO='" & FAdr(0)("DEXAMSLNO").ToString & "' AND SUBJECTSLNO='" & SBJDR(T)("SUBJECTSLNO").ToString & "'")) Then
                                        pSUBJTOTAL = DsMain.Tables(1).Compute("SUM(PASSTOTAL)", "DEXAMSLNO='" & FAdr(0)("DEXAMSLNO").ToString & "' AND SUBJECTSLNO='" & SBJDR(T)("SUBJECTSLNO").ToString & "'")
                                    Else
                                        pSUBJTOTAL = 0
                                    End If

                                    If Not IsDBNull(DsMain.Tables(1).Compute("SUM(FAILTOTAL)", "DEXAMSLNO='" & FAdr(0)("DEXAMSLNO").ToString & "' AND SUBJECTSLNO='" & SBJDR(T)("SUBJECTSLNO").ToString & "'")) Then
                                        fSUBJTOTAL = DsMain.Tables(1).Compute("SUM(FAILTOTAL)", "DEXAMSLNO='" & FAdr(0)("DEXAMSLNO").ToString & "' AND SUBJECTSLNO='" & SBJDR(T)("SUBJECTSLNO").ToString & "'")
                                    Else
                                        fSUBJTOTAL = 0
                                    End If

                                    If Not IsDBNull(DsMain.Tables(1).Compute("SUM(ABSENTTOTAL)", "DEXAMSLNO='" & FAdr(0)("DEXAMSLNO").ToString & "' AND SUBJECTSLNO='" & SBJDR(T)("SUBJECTSLNO").ToString & "'")) Then
                                        aSUBJTOTAL = DsMain.Tables(1).Compute("SUM(ABSENTTOTAL)", "DEXAMSLNO='" & FAdr(0)("DEXAMSLNO").ToString & "' AND SUBJECTSLNO='" & SBJDR(T)("SUBJECTSLNO").ToString & "'")
                                    Else
                                        aSUBJTOTAL = 0
                                    End If

                                    'Pass
                                    If Not IsDBNull(pSUBJTOTAL) Then
                                        If pSUBJTOTAL > 0 AndAlso TOTALEXAM > 0 Then
                                            BPERCENTAGE = (pSUBJTOTAL / TOTALEXAM) * 100
                                        Else
                                            BPERCENTAGE = 0.0
                                        End If
                                        MtStrP += StrPadding(pSUBJTOTAL.ToString, 8, "R") + "("
                                        MtStrP += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                                        MtStrP += StrConcTbl(".")
                                    Else
                                        MtStrP = "."
                                    End If

                                    If Not IsDBNull(fSUBJTOTAL) Then
                                        If pSUBJTOTAL > 0 AndAlso TOTALEXAM > 0 Then
                                            BPERCENTAGE = (fSUBJTOTAL / TOTALEXAM) * 100
                                        Else
                                            BPERCENTAGE = 0.0
                                        End If
                                        MtStrF += StrPadding(fSUBJTOTAL.ToString, 8, "R") + "("
                                        MtStrF += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                                        MtStrF += StrConcTbl(".")
                                    Else
                                        MtStrF = "."
                                    End If

                                    If Not IsDBNull(aSUBJTOTAL) Then
                                        If aSUBJTOTAL > 0 AndAlso TOTALS > 0 Then
                                            BPERCENTAGE = (aSUBJTOTAL / TOTALEXAM) * 100
                                        Else
                                            BPERCENTAGE = 0.0
                                        End If
                                        MtStrA += StrPadding(aSUBJTOTAL.ToString, 8, "R") + "("
                                        MtStrA += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                                        MtStrA += StrConcTbl(".")
                                    Else
                                        MtStrA = "."
                                    End If

                                    If (TOTALS - (pSUBJTOTAL + fSUBJTOTAL + aSUBJTOTAL)) > 0 Then
                                        NeNTER = (TOTALS - (pSUBJTOTAL + fSUBJTOTAL + aSUBJTOTAL))
                                        If (TOTALS - (pSUBJTOTAL + fSUBJTOTAL + aSUBJTOTAL)) > 0 Then
                                            BPERCENTAGE = ((TOTALS - (pSUBJTOTAL + fSUBJTOTAL + aSUBJTOTAL)) / TOTALS) * 100
                                        Else
                                            BPERCENTAGE = 0.0
                                        End If
                                        MtStrNE += StrPadding(NeNTER.ToString, 8, "R") + "("
                                        MtStrNE += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                                        MtStrNE += StrConcTbl(".")
                                    Else
                                        MtStrNE += "."
                                    End If

                                    MtStrTot += StrPadding((pSUBJTOTAL + fSUBJTOTAL + aSUBJTOTAL).ToString, 8, "R")

                                    If Not IsDBNull(DsMain.Tables(0).Compute("SUM(TOTALSTU)", " ")) Then
                                        TOTALS = DsMain.Tables(0).Compute("SUM(TOTALSTU)", " ")
                                    Else
                                        TOTALS = 0.0
                                    End If

                                    If (TOTALS - (NeNTER + pSUBJTOTAL + fSUBJTOTAL + aSUBJTOTAL)) > 0 Then
                                        MtStrNC += StrPadding((TOTALS - (NeNTER + pSUBJTOTAL + fSUBJTOTAL + aSUBJTOTAL)).ToString, 8, "R")
                                    Else
                                        MtStrNC += "."
                                    End If
                                Else
                                    MtStrP += "." : MtStrF += "." : MtStrA += "."
                                    If (TOTALS - TOTALEXAM) > 0 Then
                                        BPERCENTAGE = ((TOTALS - TOTALEXAM) / TOTALS) * 100
                                        MtStrNE += StrPadding((TOTALS - TOTALEXAM).ToString, 8, "R") + "("
                                        MtStrNE += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                                        MtStrNE += StrConcTbl(".")
                                    Else
                                        MtStrNE += "."
                                    End If
                                    MtStrTot += "." : MtStrNC += "."
                                End If
                                TRP.Cells.Add(Enteredstyle(IIf(MtStrP <> ".", MtStrP, ""), 1, ""))
                                TRF.Cells.Add(Enteredstyle(IIf(MtStrF <> ".", MtStrF, ""), 1, ""))
                                TRA.Cells.Add(Enteredstyle(IIf(MtStrA <> ".", MtStrA, ""), 1, ""))
                                TRNE.Cells.Add(Enteredstyle(IIf(MtStrNE <> ".", MtStrNE, ""), 1, ""))
                                TRNC.Cells.Add(Enteredstyle(IIf(MtStrNC <> ".", MtStrNC, ""), 1, ""))
                                If MtStrTot <> "." Then
                                    TRTOT.Cells.Add(Enteredstyle(MtStrTot, 1, ""))
                                Else
                                    TRTOT.Cells.Add(Enteredstyle("", 1, ""))
                                End If
                            Next 'THIS LOOP FOR TRACKS
                        End If
                    Next
                End If
            Next
            '' END OF TOTALS
            MtStrP = "" : MtStrF = "" : MtStrA = "" : MtStrNE = "" : MtStrNC = "" : MtStrTot = ""

            Dim ESTTOTALPASS, ESTTOTALFAIL, ESTTOTALABSENT, ESTTOTALSTRANGTH As Double

            If Not IsDBNull(DSPASS.Tables("ASR").Compute("SUM(ESTTOTAL)", " ")) Then ESTTOTALPASS = DSPASS.Tables("ASR").Compute("SUM(ESTTOTAL)", " ")
            If Not IsDBNull(DsMain.Tables(4).Compute("SUM(ESTTOTAL)", " ")) Then ESTTOTALFAIL = DsMain.Tables(4).Compute("SUM(ESTTOTAL)", " ")
            If Not IsDBNull(DsMain.Tables(5).Compute("SUM(ESTTOTAL)", " ")) Then ESTTOTALABSENT = DsMain.Tables(5).Compute("SUM(ESTTOTAL)", " ")

            If RdbF = True Then
                ESTTOTALFAIL = ESTTOTALFAIL - (ESTTOTALPASS + ESTTOTALABSENT)
                ESTTOTALSTRANGTH = ESTTOTALPASS + ESTTOTALFAIL + ESTTOTALABSENT
            Else
                ESTTOTALFAIL = ESTTOTALFAIL - (ESTTOTALPASS)
                ESTTOTALSTRANGTH = ESTTOTALPASS + ESTTOTALFAIL
            End If

            If Not IsDBNull(ESTTOTALPASS) Then
                If ESTTOTALPASS > 0 AndAlso ESTTOTALSTRANGTH > 0 Then
                    BPERCENTAGE = (ESTTOTALPASS / ESTTOTALSTRANGTH) * 100
                Else
                    BPERCENTAGE = 0.0
                End If
                MtStrP += StrPadding(ESTTOTALPASS.ToString, 8, "R") + "("
                MtStrP += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                MtStrP += StrConcTbl(".")
            Else
                MtStrP = "."
            End If

            If Not IsDBNull(ESTTOTALFAIL) Then
                If ESTTOTALFAIL > 0 AndAlso ESTTOTALSTRANGTH > 0 Then
                    BPERCENTAGE = (ESTTOTALFAIL / ESTTOTALSTRANGTH) * 100
                Else
                    BPERCENTAGE = 0.0
                End If
                MtStrF += StrPadding(ESTTOTALFAIL.ToString, 8, "R") + "("
                MtStrF += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                MtStrF += StrConcTbl(".")
            Else
                MtStrF = "."
            End If

            If Not IsDBNull(ESTTOTALABSENT) Then
                If ESTTOTALABSENT > 0 AndAlso ESTTOTALSTRANGTH > 0 Then
                    BPERCENTAGE = (ESTTOTALABSENT / ESTTOTALSTRANGTH) * 100
                Else
                    BPERCENTAGE = 0.0
                End If
                MtStrA += StrPadding(ESTTOTALABSENT.ToString, 8, "R") + "("
                MtStrA += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                MtStrA += StrConcTbl(".")
            Else
                MtStrA = "."
            End If

            If DsMain1.Tables(1).Rows.Count <> 0 Then
                If (TOTALS - DsMain1.Tables(1).Rows.Count) > 0 AndAlso TOTALS > 0 Then
                    BPERCENTAGE = (DsMain1.Tables(1).Rows.Count / TOTALS) * 100
                Else
                    BPERCENTAGE = 0.0
                End If
                MtStrNE += StrPadding(DsMain1.Tables(1).Rows.Count.ToString, 8, "R") + "("
                MtStrNE += StrPadding(Format(BPERCENTAGE, "00.00"), 6, "R") + ")"
                MtStrNE += StrConcTbl(".")
            Else
                MtStrNE += "."
            End If

            MtStrTot += StrPadding(ESTTOTALSTRANGTH.ToString, 8, "R")
            TRP.Cells.Add(Enteredstyle(IIf(MtStrP <> ".", MtStrP, ""), 1, "")) : TRP.Cells.Add(LeftAlignstyle(" TOTAL : ", 1, ""))
            TRF.Cells.Add(Enteredstyle(IIf(MtStrF <> ".", MtStrF, ""), 1, "")) : TRF.Cells.Add(Enteredstyle("", 1, ""))
            TRA.Cells.Add(Enteredstyle(IIf(MtStrA <> ".", MtStrA, ""), 1, "")) : TRA.Cells.Add(Enteredstyle("", 1, ""))
            TRNE.Cells.Add(Enteredstyle(IIf(MtStrNE <> ".", MtStrNE, ""), 1, "")) : TRNE.Cells.Add(Enteredstyle("", 1, ""))
            TRNC.Cells.Add(Enteredstyle(IIf(MtStrNC <> ".", MtStrNC, ""), 1, "")) : TRNC.Cells.Add(Enteredstyle("", 1, ""))

            If MtStrTot <> "." Then
                TRTOT.Cells.Add(Enteredstyle(MtStrTot, 1, ""))
                TRTOT.Cells.Add(Enteredstyle("", 1, ""))
            Else
                TRTOT.Cells.Add(Enteredstyle("", 1, ""))
            End If
            TblRpt.Rows.Add(TRP) : TblRpt.Rows.Add(TRF) : TblRpt.Rows.Add(TRA) : TblRpt.Rows.Add(TRNE) : TblRpt.Rows.Add(TRNC) : TblRpt.Rows.Add(TRTOT)
            Dim TrNote As New TableRow
            TrNote.Cells.Add(CenterAlignstyle(" Note -> P: Pass, F: Fail, A: Absent , NE: Not Entered, NC: Not Conducted, S: (Pass+Fail+Absent)", NoOfCol + 6, ""))
            TblRpt.Rows.Add(TrNote)

            Return TblRpt

        Catch ex As Exception
        End Try
    End Function

    Public Function BlankCellsToRow(ByVal Tr As TableRow, ByVal CellsCnt As Integer) As TableRow
        ' Desc : Adding BlankCells to Tablerow with NoofCells 
        Dim i As Integer
        Try
            For i = 0 To CellsCnt - 1
                Dim TCell As New TableCell
                Dim myAttributes As AttributeCollection = TCell.Attributes
                myAttributes.CssStyle.Add("background-color", "#EBDED6")
                myAttributes.CssStyle.Add("Color", "Blue")
                TCell.Text = ""
                TCell.Font.Size = FontUnit.XSmall
                TCell.Font.Name = "Courier New"
                TCell.Wrap = False
                TCell.HorizontalAlign = HorizontalAlign.Right
                TCell.VerticalAlign = VerticalAlign.Middle
                Tr.Cells.Add(TCell)
            Next
            Return Tr
        Catch ex As Exception

        End Try
    End Function

    Public Sub MultiComboOptions(ByVal OptGroup As Integer, ByVal OptCols As String, ByVal OptDs As DataSet, ByVal SelId As HtmlSelect, Optional ByVal OptGrpCols As String = "")
        'Desc :  Multiple Combo Preparing Options
        Try
            Dim i As Integer : Dim RtnStr, OptColsSplit(), OptGrpColsSplit(), PreOptGrp, PrvOptGrp As String
            'Dim VItem As ListItem
            'If OptGroup = 1 Then
            '    OptGrpColsSplit = OptGrpCols.Split(",")
            'End If
            'OptColsSplit = OptCols.Split(",")

            For i = 0 To OptDs.Tables(0).Rows.Count - 1
                Dim VITEM As New ListItem
                VITEM = New ListItem(OptDs.Tables(0).Rows(i).Item(1).ToString, OptDs.Tables(0).Rows(i).Item(0).ToString)
                If OptGroup = 1 Then 'With Groups
                    PreOptGrp = OptDs.Tables(0).Rows(i).Item(3).ToString
                    VITEM.Attributes("OptionGroup") = PreOptGrp
                End If
                SelId.Items.Add(VITEM)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Public Function DisplayStringPrePrv(ByVal PreStr As String, ByVal PrvStr As String) As String
        Try
            If PrvStr = "" Then
                Return PreStr
            Else
                If PreStr = PrvStr Then
                    Return ""
                Else
                    Return PreStr
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region



End Module
