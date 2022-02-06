function CombinationDetailsLoad()
{	
 
 if(document.CombSingle.txtMessage.value != ""){
	alert(document.CombSingle.txtMessage.value);
	document.CombSingle.txtMessage.value = "";
  }      
  
 
  if(document.CombSingle.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.CombSingle.txtSetfocus.value);		
		oField.focus();
	} 
}



//******************************************* Batch *****************************************************//

function  CombBatchLoad()
{	
 if(document.CombBatch.txtMessage.value != ""){
	alert(document.CombBatch.txtMessage.value);
	document.CombBatch.txtMessage.value = "";
  }      
  
  if(document.CombBatch.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.CombBatch.txtSetfocus.value);		
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

function CombinationDetailsLoad()
{	
 
 if(document.CombinationDetails.txtMessage.value != ""){
	alert(document.CombinationDetails.txtMessage.value);
	document.CombinationDetails.txtMessage.value = "";
  }      
  
 
  if(document.CombinationDetails.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.CombinationDetails.txtSetfocus.value);		
		oField.focus();
	} 
}



       