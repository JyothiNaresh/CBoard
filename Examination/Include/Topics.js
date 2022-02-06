
function TopicsLoad()
{	
 
 if(document.Topics.txtMessage.value != ""){
	alert(document.Topics.txtMessage.value);
	document.Topics.txtMessage.value = "";
  }      
  
 
  if(document.Topics.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.Topics.txtSetfocus.value);		
		oField.focus();
	} 
}




/*************************************************************************/


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
