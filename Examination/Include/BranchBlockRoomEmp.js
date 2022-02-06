//Single Mode
function BranchBlockRoomEmpSingleLoad()
{	
  if(document.BranchBlockRoomEmpSingle.txtMessage.value != "")
  {
	alert(document.BranchBlockRoomEmpSingle.txtMessage.value);
	document.BranchBlockRoomEmpSingle.txtMessage.value = "";
  }   
  
  if(document.BranchBlockRoomEmpSingle.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.BranchBlockRoomEmpSingle.txtSetfocus.value);		
		oField.focus();
	}    
  
   
}



//******************************************* Batch *****************************************************//

function  BranchBlockRoomBatchEmpLoad()
{	

 if(document.BranchBlockRoomBatchEmp.txtMessage.value != ""){
	alert(document.BranchBlockRoomBatchEmp.txtMessage.value);
	document.BranchBlockRoomBatchEmp.txtMessage.value = "";
	
  }      
 
  
  if(document.BranchBlockRoomBatchEmp.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.BranchBlockRoomBatchEmp.txtSetfocus.value);		
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