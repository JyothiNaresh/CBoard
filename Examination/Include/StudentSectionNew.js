
////For Grid Check Box
function CheckAll() 
{
	var chkItem = event.srcElement;
	var blnChecked=false;
	
	blnChecked=chkItem.checked;
	
	var iRow=2;
		
		while (true) 
			{
			iItem = document.StudentSectionBatch2013.all("dgGrid__ctl" + iRow + "_chkIT")
			if (iItem == null) return;
			iItem.checked=blnChecked;
			HighlightRow(iItem);
			iRow = iRow + 1;
			}
	
}



////////////////////////////////////////
function HighlightRow(chkB)    
{
			var oItem = chkB.children;
			xState= chkB.checked;
			//xState=oItem.item(0).checked;    
			
			if(xState)
				{	chkB.parentElement.parentElement.style.backgroundColor='Lavender';
					// grdEmployees.SelectedItemStyle.BackColor
					chkB.parentElement.parentElement.style.color='black'; 
					// grdEmployees.SelectedItemStyle.ForeColor
				}
			else 
				{	chkB.parentElement.parentElement.style.backgroundColor='#E0E0E0'; 
					//grdEmployees.ItemStyle.BackColor
					chkB.parentElement.parentElement.style.color='Blue'; 
					//grdEmployees.ItemStyle.ForeColor
				}
}


//Single Mode
function StudentSectionSingleLoad()
{	
  if(document.StudentSectionSingle2013.txtMessage.value != "")
  {
	alert(document.StudentSectionSingle2013.txtMessage.value);
	document.StudentSectionSingle2013.txtMessage.value = "";
  }      
  
   
}



//******************************************* Batch *****************************************************//

function  StudentSectionBatchLoad()
{	
 if(document.StudentSectionBatch2013.txtMessage.value != ""){
	alert(document.StudentSectionBatch2013.txtMessage.value);
	document.StudentSectionBatch2013.txtMessage.value = "";
  }      
  
  if(document.StudentSectionBatch2013.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.StudentSectionBatch2013.txtSetfocus.value);		
		oField.focus();
	} 
}


function PressCancel(btn) {
		
		var iKeyCode = 0;
		
		
		if (window.event) 
			iKeyCode = window.event.keyCode;
		
		 if (iKeyCode==27){
			
			event.returnValue=false;
			event.cancel = true;
		
			btn.click();
			}
		
		} 


/***************************************************Details*************************************************/

function StudentSectionDetailsLoad()
{	
  if(document.StudentSection2013.txtMessage.value != "")
  {
	alert(document.StudentSection2013.txtMessage.value);
	document.StudentSection2013.txtMessage.value = "";
  }      
  
   if(document.StudentSection2013.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.StudentSection2013.txtSetfocus.value);		
		oField.focus();
	} 
}
