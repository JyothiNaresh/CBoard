
function CGWiseSubjectsingleload()
{	
 
 if(document.CGWiseSubjectSingle.txtMessage.value != ""){
	alert(document.CGWiseSubjectSingle.txtMessage.value);
	document.CGWiseSubjectSingle.txtMessage.value = "";
  }      
  
 
  if(document.CGWiseSubjectSingle.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.CGWiseSubjectSingle.txtSetfocus.value);		
		oField.focus();
	} 
}



//******************************************* Batch *****************************************************//

function  CGWiseSubjectBatchLoad()
{	
 if(document.CGWiseSubjectBatch.txtMessage.value != ""){
	alert(document.CGWiseSubjectBatch.txtMessage.value);
	document.CGWiseSubjectBatch.txtMessage.value = "";
  }      
  
  if(document.CGWiseSubjectBatch.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.CGWiseSubjectBatch.txtSetfocus.value);		
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

function CGWiseSubjectDetailsLoad()
{	
 
 if(document.CGWiseSubjectDetails.txtMessage.value != ""){
	alert(document.CGWiseSubjectDetails.txtMessage.value);
	document.CGWiseSubjectDetails.txtMessage.value = "";
  }      
  
 
  if(document.CGWiseSubjectDetails.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.CGWiseSubjectDetails.txtSetfocus.value);		
		oField.focus();
	} 
}

