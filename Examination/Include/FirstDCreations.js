
function FirstDCreationsLoad()
{	
 
 if(document.FirstDCreationsSingle.txtMessage.value != ""){
	alert(document.FirstDCreationsSingle.txtMessage.value);
	document.FirstDCreationsSingle.txtMessage.value = "";
  }      
  
 
  if(document.FirstDCreationsSingle.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.FirstDCreationsSingle.txtSetfocus.value);		
		oField.focus();
	} 
}



//******************************************* Batch *****************************************************//

function  FirstDCreationsBatchLoad()
{	
 if(document.FirstDCreationsBatch.txtMessage.value != ""){
	alert(document.FirstDCreationsBatch.txtMessage.value);
	document.FirstDCreationsBatch.txtMessage.value = "";
  }      
  
  if(document.FirstDCreationsBatch.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.FirstDCreationsBatch.txtSetfocus.value);		
		oField.focus();
	} 
}


function PressCancel(btn) {
		
		var iKeyCode = 0;		

		if (window.event) 
			iKeyCode = window.event.keyCode;
		
		/* if (iKeyCode==13) {
		
			event.returnValue=false;
			event.cancel = true;
			
			btn.click();
			}
		else */ if (iKeyCode==27){
			
			event.returnValue=false;
			event.cancel = true;
		
			btn.click();
			}
		
		} 


/***************************************************Details*************************************************/

function FirstDCreationsDetailsLoad()
{	
 
 if(document.FirstDCreationsDetails.txtMessage.value != ""){
	alert(document.FirstDCreationsDetails.txtMessage.value);
	document.FirstDCreationsDetails.txtMessage.value = "";
  }      
  
 
  if(document.FirstDCreationsDetails.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.FirstDCreationsDetails.txtSetfocus.value);		
		oField.focus();
	} 
}


/*****************************************************************************************/

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

       