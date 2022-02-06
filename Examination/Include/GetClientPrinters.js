// Author : Venu
function getPrinters () 
{
	var ISArg = getPrinters.arguments;
	var JQArgs1 = ISArg[0].split(",");
	
	var select = document.getElementById('drpClientPrinters');

	while (select.firstChild) {
	    select.removeChild(select.firstChild);
	}
	
	var opt = document.createElement("option");
        document.getElementById("drpClientPrinters").options.add(opt);
		// Assign text and value to Option object
		opt.text = '--Select--';
		opt.value = 0;
		
	var n, m,
	
	network = new ActiveXObject('WScript.Network'),printers = [],nwPrinters = network.EnumPrinterConnections();
			
	for (n = 0, m = 0; n < nwPrinters.length; n += 2, m++) 
	{
		printers[m] = {port: nwPrinters.Item(n), printer: nwPrinters.Item(n + 1)};
        
		for (var i=0; i<JQArgs1.length; i++)
		{
			var prinmae = printers[m].printer.toUpperCase();
			var pcnt = prinmae.indexOf(JQArgs1[i]);
			if(pcnt > -1)
			{
				var opt = document.createElement("option");
				// Add an Option object to Drop Down/List Box
				document.getElementById("drpClientPrinters").options.add(opt);
				// Assign text and value to Option object
				opt.text = printers[m].printer;
				opt.value = printers[m].printer;
			}
		}
	}
}