
//******************************************* Batch *****************************************************//

function AHBRSBatchLoad()
{	
 if(document.AHBRSBatch.txtMessage.value != ""){
	alert(document.AHBRSBatch.txtMessage.value);
	document.AHBRSBatch.txtMessage.value = "";
  }      
  
  if(document.AHBRSBatch.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.AHBRSBatch.txtSetfocus.value);		
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

function BranchBlockRoomEmpDetailsLoad()
{	
  if(document.BranchBlockRoomEmpDetails.txtMessage.value != "")
  {
	alert(document.BranchBlockRoomEmpDetails.txtMessage.value);
	document.BranchBlockRoomEmpDetails.txtMessage.value = "";
  }      
  
   if(document.BranchBlockRoomEmpDetails.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.BranchBlockRoomEmpDetails.txtSetfocus.value);		
		oField.focus();
	} 
}