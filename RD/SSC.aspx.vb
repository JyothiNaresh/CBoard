Public Class SSC
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Dim ds As New DataSet

    Private Sub prepareTable()
        Dim dt As New DataTable("EMP")
        dt.Columns.Add("EmpNo")
        dt.Columns.Add("EmpName")
        Dim dr As DataRow
        dr = dt.NewRow
        dr("EmpNo") = 1
        dr("EmpName") = "Naidu"
        dt.Rows.Add(dr)


        dr = dt.NewRow
        dr("EmpNo") = 2
        dr("EmpName") = "Madhav"
        dt.Rows.Add(dr)
        ds.Tables.Add(dt)

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ''If Not IsPostBack Then
        prepareTable()
        DataGrid1.DataSource = ds.Tables("EMP")
        DataGrid1.DataBind()

        'End If
        Dim obj As New SortedList
        obj.Add("First", "Naidu")
        obj.Add("Second", "Madhav")

        Response.Write("Count:=" & obj.Count & "<BR>")
        obj.TrimToSize()
        Response.Write("Capacity:=" & obj.Capacity & "<BR>")

        Response.Write(obj.ContainsValue("First") & "<BR>") '''''These Two are Boolean Conditions
        Response.Write(obj.ContainsValue("Second") & "<BR>")

        Response.Write(obj.IndexOfKey("First") & "<BR>") ''''These two are Giving the Indexes of the Key fields
        Response.Write(obj.IndexOfKey("Second") & "<BR>")

        Response.Write(obj.GetKey(0) & "<BR>") ''''These two are giving the Key fields of the Particular Indexes
        Response.Write(obj.GetKey(1) & "<BR>")

        Response.Write(obj.GetByIndex(0) & "<BR>")
        Response.Write(obj.GetByIndex(1))

        Dim ht As New Hashtable
        ht.Add("First", "Naidu")
        ht.Add("Second", "Madhav")

        Response.Write("Count:=" & ht.Count & "<BR>")
        Response.Write(ht.Item("First"))
    End Sub

End Class
