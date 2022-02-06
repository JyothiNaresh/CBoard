
function PreviousCourseLoad()
{	
 
 if(document.PreviousCourse.txtMessage.value != ""){
	alert(document.PreviousCourse.txtMessage.value);
	document.PreviousCourse.txtMessage.value = "";
  }      
  
 
  if(document.PreviousCourse.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.PreviousCourse.txtSetfocus.value);		
		oField.focus();
	} 
}



//******************************************* Batch *****************************************************//

function  PreviousCourseBatchLoad()
{	
 if(document.PreviousCourseBatch.txtMessage.value != ""){
	alert(document.PreviousCourseBatch.txtMessage.value);
	document.PreviousCourseBatch.txtMessage.value = "";
  }      
  
  if(document.PreviousCourseBatch.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.PreviousCourseBatch.txtSetfocus.value);		
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

function PreviousCourseDetailsLoad()
{	
 
 if(document.PreviousCourseDetails.txtMessage.value != ""){
	alert(document.PreviousCourseDetails.txtMessage.value);
	document.PreviousCourseDetails.txtMessage.value = "";
  }      
  
 
  if(document.PreviousCourseDetails.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.PreviousCourseDetails.txtSetfocus.value);		
		oField.focus();
	} 
}
