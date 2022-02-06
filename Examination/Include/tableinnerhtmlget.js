//Venu
function TableHtmlSource()
{
	var TsvArg = TableHtmlSource.arguments;
	
	document.getElementById(pnltbltext).style.display="block";
	var TxtTHead = document.getElementById('TxtHead').value;
	var TxtTBody = document.getElementById('TxtBody').value;
	var TxtTFoot = document.getElementById('TxtFoot').value;
	
	//THead
	//var thd = document.getElementById('example').tHead;
	//thd.deleteRow(0);
	//thd.deleteRow(0);
	
	//var vthd1 = document.getElementById('ReportDataTable').tHead.innerHTML;
	var vthd = document.getElementById(TsvArg[0]).tBodies[0].innerHTML;
	
	//var tblH = document.getElementById('example').getElementsByTagName('tHead')[0];
	var tblH = document.getElementById('example').getElementsByTagName('tHead')[0];
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + vthd + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	for (var i=0, tr; i<TsvArg[1]; i++) 
	{
		TxtTHead = TxtTHead + tmpTable.getElementsByTagName('tr')[i].outerHTML;
		//if (i<2)
		//{
		//TxtTHead = TxtTHead.replace(/colspan=15/g, "colspan='" + TsvArg[2] + "'>");
		//}
		//var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		//tblH.appendChild(tr);
	} 
	
	//TxtTHead=TxtTHead.replaceAll('TD>', 'TH>');
	TxtTHead=TxtTHead.replace(/TD>/g, "TH>");
	TxtTHead=TxtTHead.replace(/<TD/g, "<TH");
	//str.replace(/A/g, "Z");	
	//TxtTHead=TxtTHead.replaceAll('<TD', '<TH');
	
	//someString.replace('cat', 'dog');
	
	TxtTHead=TxtTHead.replace(/</g, "Venu1");	
	TxtTHead=TxtTHead.replace(/>/g, "Venu2");	

	document.getElementById('TxtHead').value = TxtTHead;

	//TBody
	var atbd = document.getElementById(TsvArg[0]).tBodies[0].innerHTML;
	
	//var tbl = document.getElementById('example').getElementsByTagName('tbody')[0];
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + atbd + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	var TbrStart = parseInt(TsvArg[1]) + 1;
	for (var i=TbrStart, tr; i<tmpTbl.rows.length - 1 ; i++ ) 
	{
		//var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		//tbl.appendChild(tr);
		TxtTBody = TxtTBody + tmpTable.getElementsByTagName('tr')[i].outerHTML;
	}
	
	TxtTBody = TxtTBody.replace(/</g, "Venu1");	
	TxtTBody = TxtTBody.replace(/>/g, "Venu2");	

	document.getElementById('TxtBody').value = TxtTBody;

	//var TxtTFoot = document.getElementById('TxtFoot').value;

	//TFoot
	//var tft = document.getElementById(TsvArg[0]).tFoot;
	//tft.deleteRow(0);
	
	var atft = document.getElementById(TsvArg[0]).tBodies[0].innerHTML;
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + atft + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;

	var TbrEnd = parseInt(tmpTbl.rows.length) - 1;	
	//for (var i=TbrEnd, tr; TbrEnd) 
	//{
		//var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		//tblF.appendChild(tr);
		TxtTFoot = TxtTFoot + tmpTable.getElementsByTagName('tr')[TbrEnd].outerHTML;
	//} 

	TxtTFoot = TxtTFoot.replace(/</g, "Venu1");	
	TxtTFoot = TxtTFoot.replace(/>/g, "Venu2");	
	
	document.getElementById('TxtFoot').value = TxtTFoot;
	
	//document.getElementById(TsvArg[0]).style.display="none";

}

function thdnew2()
{
	var TsvArg = thdnew2.arguments;
	
	//document.getElementById('Container').innerHTML = TsvArg[2];
	//var athd = document.getElementById(TsvArg[0]).tHead.innerHTML;	
	var atbd = document.getElementById(TsvArg[0]).tBodies[0].innerHTML;
	//var atft = document.getElementById(TsvArg[0]).tFoot.innerHTML;
	
	//document.getElementById('TextBox1').value = athd;
	//document.getElementById('TextBox2').value = atbd;
	//document.getElementById('TextBox3').value = atft;
		
	//var vthd = document.getElementById('TextBox1').value;	
	//var vtbd = document.getElementById('TextBox2').value;
	//var vtft = document.getElementById('TextBox3').value;
	
	// tHead
	var thd = document.getElementById('example').tHead;
	//thd.deleteRow(0);
	//thd.deleteRow(0);
	//thd.deleteRow(0);
	
	//var vthd = document.getElementById(TsvArg[0]).tHead.innerHTML;
	var vthd = document.getElementById(TsvArg[0]).tBodies[0].innerHTML;
	var tblH = document.getElementById('example').getElementsByTagName('tHead')[0];
	//var tblH = document.getElementById('example').tHead.innerHTML;
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + vthd + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	for (var i=0, tr; i<TsvArg[1]; i++) 
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
    
	var vtbd = document.getElementById(TsvArg[0]).tBodies[0].innerHTML;
	var tbl = document.getElementById('example').getElementsByTagName('tbody')[0];
	//var tbl = document.getElementById('example').tBodies[0].innerHTML;
	//var tblH = document.getElementById('example').tHead.innerHTML;
	
	//document.getElementById('TextBox1').value= vtbd;
	
	//var vtxtbdy = document.getElementById('TextBox1').value;
	
	//var vtxtbdy = vtbd.replace("BACKGROUND-COLOR: #ebded6","BACKGROUND-COLOR: #FF0000");
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + vtbd + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	var TbrStart = parseInt(TsvArg[1]) + 1;
	var TbrStart1 = parseInt(TbrStart) + 4;
	for (var i=TbrStart, tr; i<TbrStart1 ; i++ ) 
	{
		var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		tbl.appendChild(tr);
	} 

	// tFoot
	
	var tft = document.getElementById('example').tFoot;
	//tft.deleteRow(0);
	
	//var vthd = document.getElementById(TsvArg[0]).tBodies[0].innerHTML;
	var vtft = document.getElementById(TsvArg[0]).tBodies[0].innerHTML;
	var tblF = document.getElementById('example').getElementsByTagName('tFoot')[0];
	//var tblF = document.getElementById('example').tFoot.innerHTML;
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + vtft + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	var TbrEnd = parseInt(tmpTbl.rows.length) - 1;	
	
	var tr = tmpTable.getElementsByTagName('tr')[TbrEnd].cloneNode(true);
	tblF.appendChild(tr);

	//for (var i=TbrEnd, tr; TbrEnd) 
	//{
		//var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		//tblF.appendChild(tr);
		//TxtTFoot = TxtTFoot + tmpTable.getElementsByTagName('tr')[TbrEnd].outerHTML;
	//} 
	
	//for (var i=0, tr; tr = tmpTbl.rows[i]; i++) 
	//{
		//var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		//tblF.appendChild(tr);
	//} 

	//document.getElementById(TsvArg[0]).style.display="none";	
	
	//$("#ReportDataTable").tablesorter();
	//$("#ReportDataTable").trigger("update"); 
	$("#example").tablesorter();
	//$("#example").trigger("update"); 
}

function dyntblheadbodyfoot()
{
	var scriptargs = dyntblheadbodyfoot.arguments;
	
	var atbd = document.getElementById(scriptargs[0]).tBodies[0].innerHTML;
	
	// tHead
	var thd = document.getElementById(scriptargs[1]).tHead;
	
	var tblH = document.getElementById(scriptargs[1]).getElementsByTagName('tHead')[0];
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + atbd + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	for (var i=0, tr; i<scriptargs[2]; i++) 
	{
		var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		tblH.appendChild(tr);
	} 

	//alternate - 1
	//$("tr:first-child td").each(
   	//function() 
	//		{  
	//			$(this).replaceWith('<th>' + $(this).text() + '</th>');  
	//		}
	//);
	
	var str = document.getElementById(scriptargs[1]).getElementsByTagName('tHead')[0].innerHTML;
	var newStr0 = str.split("<TD").join("<TH"); // replace <td with <th
	var newStr1 = newStr0.split("</TD>").join("</TH>"); // replace  </td> with </th>
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + newStr1 + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	for (var i=0, tr; i<scriptargs[2]; i++) 
	{
		var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		tblH.appendChild(tr);
	} 
	
	var thd = document.getElementById(scriptargs[1]).tHead;
	
	//var thlnght = parseInt(thd.rows.length)/scriptargs[2];
	var roddel = parseInt(scriptargs[2])-1;
	for (var i=0, tr; i<scriptargs[2]; i++) 
	{
	thd.deleteRow(roddel);
	} 
	// TEST
	//thd.deleteRow(0);
	//thd.deleteRow(0);
	//thd.deleteRow(0);
	//thd.deleteRow(0);
	//
	var vtbd = document.getElementById(scriptargs[0]).tBodies[0].innerHTML;
	var tbl = document.getElementById(scriptargs[1]).getElementsByTagName('tbody')[0];
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + vtbd + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	for (var i=scriptargs[2], tr; i<tmpTbl.rows.length - 1; i++) 
	{
		var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		tbl.appendChild(tr);
	} 

	// tFoot
	
	var tft = document.getElementById(scriptargs[1]).tFoot;
	
	var tblF = document.getElementById(scriptargs[1]).getElementsByTagName('tFoot')[0];
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + atbd + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	var TbrEnd = parseInt(tmpTbl.rows.length) - 1;	
	
	//for (var i=0, tr; tr = tmpTbl.rows[i]; i++) 
	//{
		var tr = tmpTable.getElementsByTagName('tr')[TbrEnd].cloneNode(true);
		tblF.appendChild(tr);
	//} 

	document.getElementById(scriptargs[0]).style.display="none";	

	dyntblsort(scriptargs[1]);
	
	//var table = $('#'+scriptargs[1]);
	//table.bind("sortEnd",function() { 
	//var i = 1;
	//table.find("tr:gt(4)").each(function(){
	//		$(this).find("td:eq(0)").text(i);
	//		i++;
	//	});
	//}); 	
	
	//$('#'+scriptargs[1]).tablesorter(
		//{headers: {0: {sorter: false}}}
	//	{ headers: { 1: {sorter:"text"}, 2: {sorter:"digit"},3: {sorter:"digit"},4: {sorter:"digit"},5: {sorter:"percent"} } }
		
	//);
	
	//$("#dtappend")
	//.tablesorter({widthFixed: true, widgets: ['zebra'],headers: {0: {sorter: false}}}) 
    //.tablesorterPager({container: $("#pager")}); 
	
}

function dyntblheadtbodiesfoot()
{
	//loadsrc();
	
	
	var scriptargs = dyntblheadtbodiesfoot.arguments;
	
	var rtype = parseInt(scriptargs[3]);
	
	document.getElementsByName("ifHelp")[0].src = scriptargs[5];

	var tblMain = document.getElementById(scriptargs[1]);
	
	var atbd = document.getElementById(scriptargs[0]).tBodies[0].innerHTML;
	
	// tHead
	var thd = document.getElementById(scriptargs[1]).tHead;
	
	var tblH = document.getElementById(scriptargs[1]).getElementsByTagName('tHead')[0];
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + atbd + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	for (var i=0, tr; i<scriptargs[2]; i++) 
	{
		var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		tblH.appendChild(tr);
	} 

	var str = document.getElementById(scriptargs[1]).getElementsByTagName('tHead')[0].innerHTML;
	var newStr0 = str.split("<TD").join("<TH"); // replace <td with <th
	var newStr1 = newStr0.split("</TD>").join("</TH>"); // replace  </td> with </th>
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + newStr1 + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	for (var i=0, tr; i<scriptargs[2]; i++) 
	{
		var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		tblH.appendChild(tr);
	} 
	
	var thd = document.getElementById(scriptargs[1]).tHead;
	
	var roddel = parseInt(scriptargs[2])-1;
	for (var i=0, tr; i<scriptargs[2]; i++) 
	{
	thd.deleteRow(roddel);
	} 
	
	// TBody
	
	var vtbd = document.getElementById(scriptargs[0]).tBodies[0].innerHTML;
	var tbl = document.getElementById(scriptargs[1]).getElementsByTagName('tbody')[0];
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + vtbd + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	for (var i=scriptargs[2], tr; i<tmpTbl.rows.length - 1; i++) 
	{
		var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		
		if (i==scriptargs[2])
		{
			var tblBody = document.createElement("tbody");
		}
		if (rtype == 0) // EX : NORMAL
		{
			tblBody.appendChild(tr);
		}
		else // EX : DIVISION/EB
		{
			if (scriptargs[6] == '0')
			{
				var celHtml = tr.childNodes[1].innerText
			}
			else
			{
				var celHtml = tr.childNodes[2].innerText
			}
			if (celHtml == "TOTAL")
			{
				tblMain.appendChild(tblBody);
				var tblBody = document.createElement("tbody");
				tblBody.className="tablesorter-no-sort";
				tblBody.appendChild(tr);
				tblMain.appendChild(tblBody);
				var tblBody = document.createElement("tbody");
			}
			else
			{
				tblBody.appendChild(tr);
			}	
		}
	} 

	if (rtype == 0)
	{
		tblMain.appendChild(tblBody);
	}
	// tFoot
	
	var tft = document.getElementById(scriptargs[1]).tFoot;
	
	var tblF = document.getElementById(scriptargs[1]).getElementsByTagName('tFoot')[0];
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + atbd + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	var TbrEnd = parseInt(tmpTbl.rows.length) - 1;	
	
	var tr = tmpTable.getElementsByTagName('tr')[TbrEnd].cloneNode(true);
	tblF.appendChild(tr);

	document.getElementById(scriptargs[0]).style.display="none";	

	tblMain.removeChild(tblMain.tBodies[0]);
	
	dyntblsort(scriptargs[1],scriptargs[3],scriptargs[4],scriptargs[2],scriptargs[6],scriptargs[7]);

	document.getElementById('Panel1').style.display="block";
	
	var txtval = document.getElementById('TextBox1').value;
	txtval = txtval + document.getElementById(scriptargs[1]).outerHTML;

	txtval=txtval.replace(/</g, "Venu1");	
	txtval=txtval.replace(/>/g, "Venu2");	

	document.getElementById('TextBox1').value = txtval;	
	
	document.getElementById('Panel1').style.display="none";
	
}

function dyntblsort()
{
	var jsarg = dyntblsort.arguments;
	var table = $('#'+jsarg[0]);
	table.bind("sortEnd",function() 
	{ 
		var i = 1;
		if (jsarg[4] == 0)
		{
			table.find("tr:gt("+jsarg[3]+")").each(function(){$(this).find("td:eq(0)").text(i);i++;});
		}
		else
		{
			table.find("tr:gt("+jsarg[3]+")").each(function(){$(this).find("td:eq(1)").text(i);i++;});
		}
	}); 	

	var rtype = parseInt(jsarg[1]);
	var det = parseInt(jsarg[2]);
	if (rtype == 0)
	{
		if (det == 0)
		{
		$('#'+jsarg[0]).tablesorter({
			headers: {0: {sorter: false}},
			textExtraction: {2: function(node, table, cellIndex){ return $(node).find("a").text(); }}, 
			theme : 'blue'
			,emptyTo: 'bottom' 
		});
		}
		else
		{
		$('#'+jsarg[0]).tablesorter({
			headers: {0: {sorter: false}},
			theme : 'blue'
			,emptyTo: 'bottom' 
		});
		}
	}
	else
	{
		if (det == 0)
		{
			$('#'+jsarg[0]).tablesorter({
				headers: {0: {sorter: false}},
				textExtraction: {2: function(node, table, cellIndex){ return $(node).find("a").text(); }},
				theme : 'blue',
				cssInfoBlock : "tablesorter-no-sort",
				widgets: [ 'zebra', 'stickyHeaders' ]
				,emptyTo: 'bottom' 
			});
		}
		else
		{
			$('#'+jsarg[0]).tablesorter({
				headers: {0: {sorter: false}},
				theme : 'blue',
				cssInfoBlock : "tablesorter-no-sort",
				widgets: [ 'zebra', 'stickyHeaders' ]
				,emptyTo: 'bottom' 
			});
		}
	}
}


function GetRowDatas()
{
	var GrdArg = GetRowDatas;
	
	//THead
	var atbh = document.getElementById('dynamicorder').getElementsByTagName('tHead')[0].innerHTML;
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + atbh + '</tbody></table>';
	
	var tblvenb = document.getElementById('Table2').getElementsByTagName('tHead')[0];
	
	//Deleting Rows
	var allRows = document.getElementById('Table2').tHead.rows.length;

	if (allRows>0)
	{
		for (var i=0; i< allRows; i++) 
		{
			tblvenb.deleteRow(0);
		}
	}
	
	var tmpTbl = tmpTable.firstChild;
	
	for (var i=0, tr; i<tmpTbl.rows.length; i++) 
	{ 
		var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		tblvenb.appendChild(tr);
	} 
	
	//TBody
	var tbl = document.getElementById('dynamicorder').innerHTML;
	
	//Deleting Rows
	var tblven = document.getElementById('Table2').getElementsByTagName('tbody')[0];
	
	var allRows = document.getElementById('Table2').tBodies[0].rows.length;

	if (allRows>0)
	{
		for (var i=0; i< allRows; i++) 
		{
			tblven.deleteRow(0);
		}
	}
	
	var tbodies = document.getElementById('dynamicorder').tBodies.length;
	
	for (var venu=0; venu< tbodies;venu++)
	{
		var atbd = document.getElementById('dynamicorder').tBodies[venu].innerHTML;
		
		var tmpTable = document.createElement('div');
		tmpTable.innerHTML = '<table><tbody>' + atbd + '</tbody></table>';
	
		var tmpTbl = tmpTable.firstChild;
	
		for (var i=0, tr; i<tmpTbl.rows.length; i++) 
		{ 
			var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		
			if (tr.childNodes[0].childNodes[0].childNodes[0].checked == true)
			{
				tblven.appendChild(tr);
			}
		}
	}
			
	//TFoot
	var atbf = document.getElementById('dynamicorder').getElementsByTagName('tFoot')[0].innerHTML;
	
	var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + atbf + '</tbody></table>';
	
	var tblvenb = document.getElementById('Table2').getElementsByTagName('tbody')[0];
	
	var tmpTbl = tmpTable.firstChild;

	var TbrEnd = parseInt(tmpTbl.rows.length) - 1;	
	
	var tr = tmpTable.getElementsByTagName('tr')[TbrEnd].cloneNode(true);
	
	if (tr.childNodes[0].childNodes[0].childNodes[0].checked == true)
	{
		tblven.appendChild(tr);
	}

	var allRows = document.getElementById('Table2').rows;
	
	var colcnt = allRows[allRows.length-1].cells.length;
	
	for (var i=0; i< allRows.length; i++) 
	{
		if (allRows[i].cells.length > 1)
		{
			allRows[i].deleteCell(0); //delete the cell
			allRows[i].deleteCell(0); //delete the cell
		}	
	}
		
	//THead to TextBox
	var vthd = document.getElementById('txtHead').value;	
	vthd = '';
	vthd = vthd + document.getElementById('Table2').getElementsByTagName('tHead')[0].innerHTML;	
	vthd = vthd.replace(/</g, "Venu1");	
	vthd = vthd.replace(/</g, "Venu1");	
	document.getElementById('txtHead').value = vthd;
	
	//TBody to TextBox
	var vtbd = document.getElementById('txtBody').value;
	vtbd = '';
	vtbd = vtbd + document.getElementById('Table2').getElementsByTagName('tBody')[0].innerHTML;	
	vtbd = vtbd.replace(/</g, "Venu1");	
	vtbd = vtbd.replace(/</g, "Venu1");	
	document.getElementById('txtBody').value = vtbd;
	
	document.getElementById('Table3').style.display="none";

	__doPostBack('ibtnLady', '');
}

function vCheckAll()
{
    $("#dynamicorder thead tr th:first input:checkbox").click(function() {
    var checkedStatus = this.checked;
    $("#dynamicorder tbody tr td:first-child input:checkbox").each(function() {
        this.checked = checkedStatus;
    });
	});
}