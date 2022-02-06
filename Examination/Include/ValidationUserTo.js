function btnGo_onClick() {   
            // Connect to WMI   
            var locator = new ActiveXObject("WbemScripting.SWbemLocator");   
            var service = locator.ConnectServer(".");   
               
            // Get the info   
            var properties = service.ExecQuery("Select * from Win32_NetworkAdapter Where AdapterTypeID=0");   
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
					 window.document.Form1.Txt1.value=p.MACAddress;
					 }
				else if (i==2) 
					{	 
					window.document.Form1.Txt2.value=p.MACAddress;
					}
				else if (1==3)
					{	
					window.document.Form1.Txt3.value=p.MACAddress;
					}
                //document.write("</tr>");   
                i=i+1;
            }   
            //document.write("</table>");   
        }   