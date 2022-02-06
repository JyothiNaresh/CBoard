//Single Mode
function BranchBlockRoomSingleLoad()
{	
  if(document.BranchBlockRoomSingle.txtMessage.value != "")
  {
	alert(document.BranchBlockRoomSingle.txtMessage.value);
	document.BranchBlockRoomSingle.txtMessage.value = "";
  }      
  
  if(document.BranchBlockRoomSingle.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.BranchBlockRoomSingle.txtSetfocus.value);		
		oField.focus();
	} 
  
   
}



//******************************************* Batch *****************************************************//

function  BranchBlockRoomBatchLoad()
{	
 if(document.BranchBlockRoomBatch.txtMessage.value != ""){
	alert(document.BranchBlockRoomBatch.txtMessage.value);
	document.BranchBlockRoomBatch.txtMessage.value = "";
  }      
  
  if(document.BranchBlockRoomBatch.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.BranchBlockRoomBatch.txtSetfocus.value);		
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

function BranchBlockRoomsDetailsLoad()
{	
  if(document.BranchBlockRoomsDetails.txtMessage.value != "")
  {
	alert(document.BranchBlockRoomsDetails.txtMessage.value);
	document.BranchBlockRoomsDetails.txtMessage.value = "";
  }      
  
   if(document.BranchBlockRoomsDetails.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.BranchBlockRoomsDetails.txtSetfocus.value);		
		oField.focus();
	} 
}