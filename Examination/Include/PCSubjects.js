//Single Mode
function PCSubjectsLoad()
{	

if(document.PCSubjects.txtMessage.value != "")
  {

	alert(document.PCSubjects.txtMessage.value);
	document.PCSubjects.txtMessage.value = "";
  }      

   if(document.PCSubjects.txtSetfocus.value != "")
    {	
  		var oField;
		oField = document.all(document.PCSubjects.txtSetfocus.value);		
		oField.focus();
	} 

   }



//******************************************* Batch *****************************************************//

function  PCSubjectsBatchLoad()
{	
 if(document.PCSubjectsBatch.txtMessage.value != ""){
	alert(document.PCSubjectsBatch.txtMessage.value);
	document.PCSubjectsBatch.txtMessage.value = "";
  }      
  
  if(document.PCSubjectsBatch.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.PCSubjectsBatch.txtSetfocus.value);		
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

function PCSubjectsDetailsLoad()
{	
  if(document.PCSubjectsDetails.txtMessage.value != "")
  {
	alert(document.PCSubjectsDetails.txtMessage.value);
	document.PCSubjectsDetails.txtMessage.value = "";
  }      
  
   if(document.PCSubjectsDetails.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.PCSubjectsDetails.txtSetfocus.value);		
		oField.focus();
	} 
}