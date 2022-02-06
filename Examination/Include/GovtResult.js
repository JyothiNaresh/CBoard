
function txtGridUpDown(frmName,grdName,txtName) {

	//alert(window.event.keyCode);

	if ((window.event.keyCode == 40 ) || (window.event.keyCode == 13 )) {
		//alert("IN 40");
		var txt = event.srcElement.id;
		//alert(txt);
		var sNum = txt.indexOf("__ctl");
		if (sNum != -1) 
			sNum=sNum + 5;
		else
			return false;
			
		var lNum = txt.indexOf("_txt");
		if (lNum == -1 ) return false ;
		
		var cNum = txt.substr(sNum,lNum - sNum);
		cNum = parseInt(cNum);
		
		cNum = cNum + 1;
		
		iItem = document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName);
		if (iItem == null) return false;
		iItem.focus();
		
		return false;
	}
	
	else if (window.event.keyCode == 38 ) {

		var txt = event.srcElement.id;
		
		var sNum = txt.indexOf("__ctl");
		if (sNum != -1) 
			sNum=sNum + 5;
		else
			return ;

		var lNum = txt.indexOf("_txt");
		if (lNum == -1 ) return ;
		
		var cNum = txt.substr(sNum,lNum-sNum);
		cNum = parseInt(cNum);
		
		cNum = cNum - 1;
		
		iItem = document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName);
		
		if (iItem == null) return;
		iItem.focus();
		
	}	
	
}



////***************************************************************************************************************8


function txtGridUpDownSum(frmName,grdName,txtName,txtName1,txtName2) {

	//alert(window.event.keyCode);

	if ((window.event.keyCode == 40 ) || (window.event.keyCode == 13 )) {
		//alert("IN 40");
		var txt = event.srcElement.id;
		//alert(txt);
		var sNum = txt.indexOf("__ctl");
		if (sNum != -1) 
			sNum=sNum + 5;
		else
			return false;
			
		var lNum = txt.indexOf("_txt");
		if (lNum == -1 ) return false ;
		
		var cNum = txt.substr(sNum,lNum - sNum);
		cNum = parseInt(cNum);
		var asrcNum=parseInt(cNum);
		cNum = cNum + 1;
		
		
			
			
		iItem = document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName);
		
		iItem0 = document.all(frmName).all(grdName + "__ctl" + asrcNum + "_txtSubMarks");
		iItem1 = document.all(frmName).all(grdName + "__ctl" + asrcNum + "_" + txtName1);
		iItem2 = document.all(frmName).all(grdName + "__ctl" + asrcNum + "_" + txtName2);
		
		
		if (iItem == null) return false;
		iItem0.value=parseInt(iItem1.value)+parseInt(iItem2.value)
		iItem.focus();
		
		return false;
	}
	
	else if (window.event.keyCode == 38 ) {

		var txt = event.srcElement.id;
		//alert(txt);
		var sNum = txt.indexOf("__ctl");
		if (sNum != -1) 
			sNum=sNum + 5;
		else
			return ;

		var lNum = txt.indexOf("_txt");
		if (lNum == -1 ) return ;
		
		var cNum = txt.substr(sNum,lNum-sNum);
		cNum = parseInt(cNum);
		var asrcNum=parseInt(cNum);
		cNum = cNum - 1;
			
			
		iItem = document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName);			
		
		iItem0 = document.all(frmName).all(grdName + "__ctl" + asrcNum + "_txtSubMarks");
		iItem1 = document.all(frmName).all(grdName + "__ctl" + asrcNum + "_" + txtName1);
		iItem2 = document.all(frmName).all(grdName + "__ctl" + asrcNum + "_" + txtName2);
		
		if (iItem == null) return;
		iItem0.value=parseInt(iItem1.value)+parseInt(iItem2.value)		
		iItem.focus();
		
	}	
	else if (window.event.keyCode == 9 ) {
		//alert('asr');
		
		var txt = event.srcElement.id;
		var sNum = txt.indexOf("__ctl");
		if (sNum != -1) 
			sNum=sNum + 5;
		else
			return ;
			
		//alert('OK');
		
		var lNum = txt.indexOf("_txt");
			if (lNum == -1 ) return ;
		
		var cNum = txt.substr(sNum,lNum-sNum);
		cNum = parseInt(cNum);
					
		//alert('REDDY');
		
		//document.all(frmName).all(grdName + "__ctl" + cNum + "_txtSubMarks.value")=parseInt(document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName1.value))+parseInt(document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName2.value));
		
		//document.all(frmName).all(grdName + "__ctl" + cNum + "_txtSubMarks.value")=parseInt(document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName1.value))+parseInt(document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName2.value));
		
		iItem = document.all(frmName).all(grdName + "__ctl" + cNum + "_txtSubMarks");
		iItem1 = document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName1);
		iItem2 = document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName2);
		
		//alert(txtName);
		//alert(iItem.value);
		if (iItem == null) return;
		//iItem.value=parseInt(document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName1.value))+parseInt(document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName2.value));
		
		iItem.value=parseInt(iItem1.value)+parseInt(iItem2.value)
		/*if (txtName=='txtgiitp1')
			iItem2.focus();
			alert(txtName);
		else
			iItem.focus();
			alert(txtName);*/
		
		//alert(iItem.value);
		//document.all(frmName).all(grdName + "__ctl" + cNum + "_txtSubMarks.value")=parseInt(document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName1.value))+parseInt(document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName2.value));
		//alert('GOOD');		
		
	}	
}

///**********************************************************************************************************

function txtonblur(frmName,grdName,txtName1,txtName2) {

		var txt = event.srcElement.id;
		var sNum = txt.indexOf("__ctl");
		if (sNum != -1) 
			sNum=sNum + 5;
		else
			return ;
		
		var lNum = txt.indexOf("_txt");
			if (lNum == -1 ) return ;
		
		var cNum = txt.substr(sNum,lNum-sNum);
		cNum = parseInt(cNum);
					
	
		iItem = document.all(frmName).all(grdName + "__ctl" + cNum + "_txtSubMarks");
		iItem1 = document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName1);
		iItem2 = document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName2);
		
		if (iItem == null) return;
			iItem.value=parseInt(iItem1.value)+parseInt(iItem2.value);
		
}