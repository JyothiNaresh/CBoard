//Single Mode
function BACGBSubjectEmployeesLoad()
{	
  if(document.BACGBSubjectEmployees.txtMessage.value != ""){
	alert(document.BACGBSubjectEmployees.txtMessage.value);
	document.BACGBSubjectEmployees.txtMessage.value = "";
  }      
  
   if(document.BACGBSubjectEmployees.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.BACGBSubjectEmployees.txtSetfocus.value);		
		oField.focus();
	} 
   
}



//******************************************* Batch *****************************************************//

function  BACGBSubjectEmployeesBatchLoad()
{	
 if(document.BACGBSubjectEmployeesBatch.txtMessage.value != ""){
	alert(document.BACGBSubjectEmployeesBatch.txtMessage.value);
	document.BACGBSubjectEmployeesBatch.txtMessage.value = "";
  }      
  
  if(document.BACGBSubjectEmployeesBatch.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.BACGBSubjectEmployeesBatch.txtSetfocus.value);		
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

function BACGBSubjectEmployeesDetailsLoad()
{	
  if(document.BACGBSubjectEmployeesDetails.txtMessage.value != "")
  {
	alert(document.BACGBSubjectEmployeesDetails.txtMessage.value);
	document.BACGBSubjectEmployeesDetails.txtMessage.value = "";
  }      
  
   if(document.BACGBSubjectEmployeesDetails.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.BACGBSubjectEmployeesDetails.txtSetfocus.value);		
		oField.focus();
	} 
}