<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MacRD.aspx.vb" Inherits="CollegeBoard.MacRD"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MacRD</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" type="text/javascript">
    function btnGo_onClick() {   
            // Connect to WMI   
            var locator = new ActiveXObject("WbemScripting.SWbemLocator");   
            var service = locator.ConnectServer(".");   
               
            // Get the info   
            var properties = service.ExecQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled=TRUE");   
            var e = new Enumerator (properties);   
            var i=1;
               
            // Output info   
            document.write("<table border=1>");   
           document.write("<thead>");   
           document.write("<td>Caption</td>");   
           document.write("<td>MAC Address</td>");   
           document.write("<td>TEXT MAC Address</td>");   
           document.write("</thead>");   
            for (;!e.atEnd();e.moveNext ())   
            {   
                var p = e.item ();   
                document.write("<tr>");   
               document.write("<td>" + p.Caption + "</td>");   
              document.write("<td>" + p.MACAddress + "</td>");  
              document.write("<td><input name=a  value=" + p.MACAddress + "></Input></td>");  
                if (i==1) 
					{
					// window.document.Form1.Txt1.value=p.MACAddress;
					 }
				else if (i==2) 
					{	 
					//window.document.Form1.Txt2.value=p.MACAddress;
					}
				else if (1==3)
					{	
					//window.document.Form1.Txt3.value=p.MACAddress;
					}
                document.write("</tr>");   
                i=i+1;
            }   
            document.write("</table>");   
        }   
		</script>
	</HEAD>
	<body onload="javascript:btnGo_onClick()">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" border="0">
				<TBODY>
					<TR>
						<TD><asp:textbox id="Txt1" runat="server" Width="100px" Height="20px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD><asp:textbox id="Txt2" runat="server" Width="100px" Height="20px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD><asp:textbox id="Txt3" runat="server" Width="100px" Height="20px"></asp:textbox></TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
