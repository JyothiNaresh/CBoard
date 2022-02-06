
//******************************************* Batch *****************************************************//

function  SubjectMapLoad()
{	
 if(document.SubjectMap.txtMessage.value != ""){
	alert(document.SubjectMap.txtMessage.value);
	document.SubjectMap.txtMessage.value = "";
  }      
  
  if(document.SubjectMap.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.SubjectMap.txtSetfocus.value);		
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

function SubjectMappingViewDetailsLoad()
{	
 
 if(document.SubjectMappingViewDetails.txtMessage.value != ""){
	alert(document.SubjectMappingViewDetails.txtMessage.value);
	document.SubjectMappingViewDetails.txtMessage.value = "";
  }      
  
 
  if(document.SubjectMappingViewDetails.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.SubjectMappingViewDetails.txtSetfocus.value);		
		oField.focus();
	} 
}

