function AccordionData()
{
	var JQArg = AccordionData.arguments;
    document.getElementById('tabs-1').innerHTML = document.getElementById('TextBox1').value;
    document.getElementById('tabs-2').innerHTML = document.getElementById('TextBox2').value;
    
    document.getElementById('A1').innerHTML = JQArg[0];
    document.getElementById('A2').innerHTML = JQArg[1];
    var pnl=document.getElementById('Panel1')
    pnl.style.display = 'none';
	
}
function AccordionData1()
{
	var JQArg = AccordionData.arguments;
    document.getElementById('tabs-plain-1').innerHTML = document.getElementById('TextBox1').value;
    document.getElementById('tabs-plain-2').innerHTML = document.getElementById('TextBox2').value;
    document.getElementById('tabs-plain-3').innerHTML = document.getElementById('TextBox3').value;
    
    document.getElementById('A1').innerHTML = 'CRICKET';
    document.getElementById('A2').innerHTML = 'HOCKEY';
    document.getElementById('A3').innerHTML = 'BADMINTON';

    var pnl=document.getElementById('Panel1')
    pnl.style.display = 'none';

}
function AccordionData2()
{
	var JQArg = AccordionData.arguments;
    document.getElementById('tabs-center-1').innerHTML = document.getElementById('TextBox1').value;
    document.getElementById('tabs-center-2').innerHTML = document.getElementById('TextBox2').value;
}

function TabsDataDynamic()
{
	
	var JQArg = TabsDataDynamic.arguments;
	IncludeScritps(JQArg[1]);
	document.getElementById('tabs').innerHTML = JQArg[0];
	
	document.getElementById('tabs-1').innerHTML = document.getElementById('TxtTab1').value;
	document.getElementById('tabs-2').innerHTML = document.getElementById('TxtTab2').value;
	
    //var pnl=document.getElementById('Panel1');
    //pnl.style.display = 'none';
	
	var scnt = document.getElementsByTagName('script');
	var strng = '';

	for (var i=0; i<scnt.length; i++)
	{
		strng = strng + document.getElementsByTagName('script')[i].outerHTML+"/";
	}
	document.getElementById('TextBox1').innerText = strng;	
}

//Append Scripts to Body Tag
function IncludeScritps()
{
	var ISArg = IncludeScritps.arguments;
	var JQArgs1 = ISArg[0].split(",");
	
	for (var i=0; i<JQArgs1.length; i++)
	{
		var script=document.createElement('script');
		script.type='text/javascript';
		script.src=JQArgs1[i];
		
		var s = document.getElementsByTagName('script')[3];
		s.parentNode.insertBefore(script, s);
		
		//document.getElementsByTagName('head')[0]||document.getElementsByTagName('body')[0]).appendChild(bsa);
	}

}
