//Single Mode
function SectionWiseEmployeSingleLoad()
{	
  if(document.SectionWiseEmployeSingle.txtMessage.value != ""){
	alert(document.SectionWiseEmployeSingle.txtMessage.value);
	document.SectionWiseEmployeSingle.txtMessage.value = "";
															}      
  
   
}



//******************************************* Batch *****************************************************//

function  SectionWiseEmployeBatchLoad()
{	
 if(document.SectionWiseEmployeBatch.txtMessage.value != ""){
	alert(document.SectionWiseEmployeBatch.txtMessage.value);
	document.SectionWiseEmployeBatch.txtMessage.value = "";
  }      
  
  if(document.SectionWiseEmployeBatch.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.SectionWiseEmployeBatch.txtSetfocus.value);		
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

function SectionWiseEmployeDetailsLoad()
{	
  if(document.SectionWiseEmployeDetails.txtMessage.value != "")
  {
	alert(document.SectionWiseEmployeDetails.txtMessage.value);
	document.SectionWiseEmployeDetails.txtMessage.value = "";
  }      
  
   if(document.SectionWiseEmployeDetails.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.SectionWiseEmployeDetails.txtSetfocus.value);		
		oField.focus();
	} 
}