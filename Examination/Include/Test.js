function TestVenu()
{
	var TsvArg = TestVenu.arguments;
	
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
	//document.getElementById('Panel1').style.display="none";
	//document.getElementById('ibtnRun').style.display="none";
	//document.forms["text"].style.visibility = 'hidden';
	//document.forms["text"].style.visibility = 'hidden';

	//var ulrv = "../Reports/TextReports/ColleftfixDynamic.aspx"
	//var urlStr = ulrv + "?ThStrSes=" + TxtTHead + "&TbStrSes=" + TxtTBody + "&TfStrSes=" + TxtTFoot;
	
	//var urlStr = nUrl + "?var1=" + variable1 + "&var2=" + variable2;
	//window.open(urlStr,'_blank','');
	//window.open(urlStr, 'newwindow','toolbar=yes,location=no,menubar=no,width=450,height=200,resizable=yes,scrollbars=yes,top=200,left=250');
	
	//'<%Session["ThStrSes"] = "' + TxtTHead +'"; %>' ;
	//'<%Session["TbStrSes"] = "' + TxtTBody +'"; %>' ;
	//'<%Session["TfStrSes"] = "' + TxtTFoot +'"; %>' ;
	
	//window.location = "../Reports/TextReports/ColleftfixDynamic.aspx?thStr=venu";
	
	//$.ajax({
	//	type: "POST",url: "../ObjectiveReports/ObjRngRnkAnal_TestWiseDetails.aspx/RunDHtmlReport",data: "{}",contentType: "application/json; charset=utf-8",dataType: "json",success: function() {alert('SetSession executed.');}
	//});
	//alert('Click Priview to View Report..!');
	
	//document.getElementById('TxtImp').value = 1;
	//window.location.reload(true);
	
	//__doPostBack('ibtnPreview', '');
	//__doPostBack('ibtnImp', '');
	//__doPostBack('ChkImp', '');
	//ChkImp
	
	//reloadPage();
}


  function reloadPage()
  {
    //__doPostBack('ibtnImp', '');
  }
