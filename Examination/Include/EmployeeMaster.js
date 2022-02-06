function EmployeeSingleLoad()
 {	
	if(document.FrmEmployeeSingle.txtMessage.value != "")
	{
	alert(document.FrmEmployeeSingle.txtMessage.value);
	document.FrmEmployeeSingle.txtMessage.value = "";
	}   
	
	 if(document.FrmEmployeeSingle.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.FrmEmployeeSingle.txtSetfocus.value);		
		oField.focus();
	} 
	
 } 

function EmployeeBatchLoad()
{
  if(document.FrmEmployeeBatch.txtMessage.value != "")
	{
	alert(document.FrmEmployeeBatch.txtMessage.value);
	document.FrmEmployeeBatch.txtMessage.value = "";
	}  
	
	if(document.FrmEmployeeBatch.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.FrmEmployeeBatch.txtSetfocus.value);		
		oField.focus();
	}  
}


function FrmEmpDtlsLoad()
 {	
 
	if(document.FrmEmpDtls.txtMessage.value != "")
	{
	alert(document.FrmEmpDtls.txtMessage.value);
	document.FrmEmpDtls.txtMessage.value = "";
	}  
	
	if(document.FrmEmpDtls.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.FrmEmpDtls.txtSetfocus.value);		
		oField.focus();
	}  
	 
 } 


