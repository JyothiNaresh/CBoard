function ConListItems() 
{
	var JQArg = ConListItems.arguments;
	document.getElementById('HtmlGrid').innerHTML = JQArg[0];
	//var SetSh = document.getElementById('TextBox4').value;
	//if(SetSh == '0')
	//		{
	//		pnl.style.display = 'none';
	//		}
	//	else
	//		{
	//		pnl.style.display = 'block';
	//		}
}
function getlivalue()
{
	uls = document.getElementById("TxtSets").value;
	
	for (var u=0; u<uls; u++) 
		{
		var dg = 1 + parseInt(u,10);
		lis=document.getElementById('DragContainer' + dg).getElementsByTagName('div');
		var uidivname = '';
		var uidivid = '';
		for (var i=0; i<lis.length; i++) 
			{
				if (i==0)
				{
				uidivid = lis[i].id;
				uidivname = lis[i].innerText;
				}
				else
				{
				uidivid = uidivid + ',' + lis[i].id;
				uidivname = uidivname + ',' + lis[i].innerText;
				}
			}
			if (u == 0)
			{
			document.getElementById('TxtSetDivId1').innerText=uidivid;
			document.getElementById('TxtSetDivName1').innerText=uidivname;
			}
			if (u == 1)
			{
			document.getElementById('TxtSetDivId2').innerText=uidivid;
			document.getElementById('TxtSetDivName2').innerText=uidivname;
			}
			if (u == 2)
			{
			document.getElementById('TxtSetDivId3').innerText=uidivid;
			document.getElementById('TxtSetDivName3').innerText=uidivname;
			}
			if (u == 3)
			{
			document.getElementById('TxtSetDivId4').innerText=uidivid;
			document.getElementById('TxtSetDivName4').innerText=uidivname;
			}
		}
		//alert(document.getElementById('TxtSet1').innerText);
		//alert(document.getElementById('TxtSet2').innerText);
		//alert(document.getElementById('TxtSet3').innerText);
		//alert(document.getElementById('TxtSet4').innerText);
		alert('Sets Saved..!');
}	
