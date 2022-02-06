//Single Mode
function BACGBSectionLoad()
{	
  if(document.BACGBSection.txtMessage.value != ""){
	alert(document.BACGBSection.txtMessage.value);
	document.BACGBSection.txtMessage.value = "";
  }      
  
   
}



//******************************************* Batch *****************************************************//

function  BACGBSectionBatchLoad()
{	
 if(document.BACGBSectionBatch.txtMessage.value != ""){
	alert(document.BACGBSectionBatch.txtMessage.value);
	document.BACGBSectionBatch.txtMessage.value = "";
  }      
  
  if(document.BACGBSectionBatch.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.BACGBSectionBatch.txtSetfocus.value);		
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

function BACGBSectionDetailsLoad()
{	
  if(document.BACGBSectionDetails.txtMessage.value != "")
  {
	alert(document.BACGBSectionDetails.txtMessage.value);
	document.BACGBSectionDetails.txtMessage.value = "";
  }      
  
   if(document.BACGBSectionDetails.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.BACGBSectionDetails.txtSetfocus.value);		
		oField.focus();
	} 
}