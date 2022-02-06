<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MacRegister.aspx.vb" Inherits="CollegeBoard.MacRegister"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MacRegister</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link2" href="../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
		<script id="clientEventHandlersJS" type="text/javascript"> 
		<!--   
        function btnGo_onClick() {   
            // Connect to WMI   
            var locator = new ActiveXObject("WbemScripting.SWbemLocator");   
            var service = locator.ConnectServer(".");   
               
            // Get the info   
            var properties = service.ExecQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled=TRUE");   
            var e = new Enumerator (properties);   
            var i=1;
               
            // Output info   
           // document.write("<table border=1>");   
            //document.write("<thead>");   
            //document.write("<td>Caption</td>");   
            //document.write("<td>MAC Address</td>");   
            //document.write("<td>TEXT MAC Address</td>");   
            //document.write("</thead>");   
            for (;!e.atEnd();e.moveNext ())   
            {   
                var p = e.item ();   
              //  document.write("<tr>");   
               // document.write("<td>" + p.Caption + "</td>");   
                //document.write("<td>" + p.MACAddress + "</td>");  
                //document.write("<td><input name=a  value=" + p.MACAddress + "></Input></td>");  
                if (i==1) 
					{
					 window.document.Form1.TxtMacadd1.value=p.MACAddress;
					 }
				else if (i==2) 
					{	 
					window.document.Form1.TxtMacadd2.value=p.MACAddress;
					}
				else if (1==3)
					{	
					window.document.Form1.TxtMacadd3.value=p.MACAddress;
					}
                //document.write("</tr>");   
                i=i+1;
            }   
            //document.write("</table>");   
        }   
        //-->  
		</script>
	</HEAD>
	<body onload="javascript:btnGo_onClick()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table3" cellSpacing="3" cellPadding="0" width="300" border="0">
							<TR>
								<TD>
									<asp:label id="Label5" runat="server" Width="110px" CssClass="Lables">User&nbsp;Id&nbsp;*</asp:label></TD>
								<TD>
									<asp:label id="LblDisUserId" runat="server" Width="185px" CssClass="Lables"></asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 17px"></TD>
								<TD style="HEIGHT: 17px"></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center" colSpan="2">
									<asp:Button id="BtnRegistr" accessKey="R" runat="server" Width="174px" Text="Register"></asp:Button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" border="0">
							<TR>
								<TD><asp:textbox id="TxtMacadd1" runat="server" Width="0px" Height="0px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:textbox id="TxtMacadd2" runat="server" Width="0px" Height="0px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:textbox id="TxtMacadd3" runat="server" Width="0px" Height="0px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
