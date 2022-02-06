function thd()
{
//var tbl = document.getElementById('TextBox1').value;
//var thd = document.getElementById('example').tHead;
//document.getElementById('tblJQ').innerHTML = tbl;
//thd.deleteRow(0);
//var trnew = thd.insertRow(0);
//trnew.innerHTML = tbl;
//thd.childNodes[0].parentNode.innerHTML = tbl;
//var tr = thd.createElement("tr");
//var tr = tbl.appendChild(document.createElement('tr'));
//tr.innerHTML = tbl;
//thd.appendChild(tr)

//var indexToInsert=1;
//var table = document.getElementById("example");
//var newJob = table.tHead.insertRow(indexToInsert);
//newJob.style.backgroundColor=randColor();
//newJob.innerHTML = "<td>Foo "+(i++)+".</td><td>Bar</td>";

//thd.parentNode.insertBefore(tr,thd);
    
//thd.
//thd.appendChild(tbl);
//document.getElementById('example').style.display = 'none';
}

function thdnew()
{
	var tbl = document.getElementById('TextBox1').value;
	//document.getElementById('tblJQ').innerHTML = tbl;
	
	var vscript = document.getElementById('TextBox2').value;
	IncludeScritps(vscript);
}

function IncludeScritps()
{
	var ISArg = IncludeScritps.arguments;
	var JQArgs1 = ISArg[0].split("JQSplit");
	
	for (var i=0; i<JQArgs1.length; i++)
	{
		var script=document.createElement('script');
		script.type='text/javascript';
		script.src=JQArgs1[i];
		
		var s = document.getElementsByTagName('script')[0];
		s.parentNode.insertBefore(script, s);
		
		//document.getElementsByTagName('head')[0]||document.getElementsByTagName('body')[0]).appendChild(bsa);
	}

}

function thdnew1()
{

	var vthd = document.getElementById('example1').tHead.innerHTML;
	var vtft = document.getElementById('example1').tFoot.innerHTML;
	var vtbd = document.getElementById('example1').tBodies[0].innerHTML;
	
	var tbdy = document.getElementById('example1').innerHTML;
	document.getElementById('TextBox2').value = tbdy;
		
	var hmlt = document.getElementById('TextBox2').value;
	var tbl = document.getElementById('example').getElementsByTagName('tbody')[0];
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + hmlt + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	for (var i=0, tr; tr = tmpTbl.rows[i]; i++) 
	{
		var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		tbl.appendChild(tr);
	} 
	
	//var tmpTable = document.createElement('div');
	//tmpTable.innerHTML = '<table><tbody>' + hmlt + '</tbody></table>';
	//var tr = tmpTable.getElementsByTagName('tr')[3].cloneNode(true);
	//tbl.appendChild(tr);
	
	
	//var tempNode = document.createElement('div');
	//tempNode.innerHTML = "<table>" + responseText+ "</table>";

	//var tempTable = tempNode.firstChild;
	//var tbody = 
	//for (var i=0, tr; tr = tempTable.rows[i]; i++) 
	//{
	    //tbody.appendChild(tr);
	//}  

	//MSIEsetTBodyInnerHTML.temp = document.createElement('div');

	//if (navigator  &&  navigator.userAgent.match( /MSIE/i ))  
	//MSIEsetTBodyInnerHTML(tbody, html);
	//else  //by specs, you can not use “innerHTML” until after the page is fully loaded  
	//tbody.innerHTML=html;

}

//function MSIEsetTBodyInnerHTML(tbody, html) 
//{ //fix MS Internet Exploder’s lameness
//  var temp = MSIEsetTBodyInnerHTML.temp;
//  temp.innerHTML = '<table><tbody>' + html + '</tbody></table>';
//  tbody.parentNode.replaceChild(temp.firstChild.firstChild, tbody);  
//}
	
	
function thdnew2()
{
	//var athd = document.getElementById('example1').tHead.innerHTML;	
	//var atbd = document.getElementById('example1').tBodies[0].innerHTML;
	//var atft = document.getElementById('example1').tFoot.innerHTML;
	
	//document.getElementById('TxtMHd').value = athd;
	//document.getElementById('TxtMbd').value = atbd;
	//document.getElementById('TxtMFt').value = atft;
	
	//alert('<%Session["ThStrSes"] = "' + TxtTHead +'"; %>' ;
	//alert('<%Session["ThStrSes"]%>');
	//alert('<%Session["TbStrSes"]%>');
	//alert('<%Session["TfStrSes"]%>');
	//'<%Session["TbStrSes"] = "' + TxtTBody +'"; %>' ;
	//'<%Session["TfStrSes"] = "' + TxtTFoot +'"; %>' ;

	var vthd = document.getElementById('TxtMHd').value;	
	var vtbd = document.getElementById('TxtMbd').value;
	var vtft = document.getElementById('TxtMFt').value;
	
	// tHead
	var thd = document.getElementById('example').tHead;
	thd.deleteRow(0);
	//thd.deleteRow(0);
	
	//var vthd = document.getElementById('example1').tHead.innerHTML;
	var tblH = document.getElementById('example').getElementsByTagName('tHead')[0];
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + vthd + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	for (var i=0, tr; tr = tmpTbl.rows[i]; i++) 
	{
		var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		tblH.appendChild(tr);
	} 

	// tBody
	
	//var tbg = document.getElementById('example1').getElementsByTagName('tbody')[0].getElementsByTagName('td');
	//for (c = 0; c < tbg.length; c++) 
	//{
    //    tbg[c].style.backgroundColor = '' //today's scripture reading
        //cells[c].style.color = 'white'
    //}
    
	//var vtbd = document.getElementById('example1').tBodies[0].innerHTML;
	var tbl = document.getElementById('example').getElementsByTagName('tbody')[0];
	
	//document.getElementById('TextBox1').value= vtbd;
	
	//var vtxtbdy = document.getElementById('TextBox1').value;
	
	//var vtxtbdy = vtbd.replace("BACKGROUND-COLOR: #ebded6","BACKGROUND-COLOR: #FF0000");
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + vtbd + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	for (var i=0, tr; tr = tmpTbl.rows[i]; i++) 
	{
		var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		tbl.appendChild(tr);
	} 

	// tFoot
	
	var tft = document.getElementById('example').tFoot;
	tft.deleteRow(0);

	var tblF = document.getElementById('example').getElementsByTagName('tFoot')[0];
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + vtft + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	for (var i=0, tr; tr = tmpTbl.rows[i]; i++) 
	{
		var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		tblF.appendChild(tr);
	} 
	
	//var tblF = document.getElementById('example').getElementsByTagName('tFoot')[0];
	
	//var tmpTable = document.createElement('div');
	//tmpTable.innerHTML = '<table><tbody>' + vtft + '</tbody></table>';
	
	//var tmpTbl = tmpTable.firstChild;
	
	//for (var i=0, tr; tr = tmpTbl.rows[i]; i++) 
	//{
	//	var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
	//	tblF.appendChild(tr);
	//} 

	
}

function hide()
			{
				//document.forms["span"].style.visibility = 'hidden';
				alert('venu');
			}