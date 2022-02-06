


////For Grid Check Box
function CheckAll() 
{

	var chkItem = event.srcElement;
	
	var blnChecked=false;
	blnChecked=chkItem.checked;
	
	var iRow=2;
	
		
		while (true) {
		
		iItem = document.ExamBranchStudent.all("dgGrid__ctl" + iRow + "_chkIT")
		
			if (iItem == null) return;
			
			iItem.checked=blnChecked;
			HighlightRow(iItem);
					iRow = iRow + 1;
			}
	
}



//Single Mode
function ExamBranchStudentSingleLoad()
{	

  if(document.ExamBranchStudentSingle.txtMessage.value != "")
  {
	alert(document.ExamBranchStudentSingle.txtMessage.value);
	document.ExamBranchStudentSingle.txtMessage.value = "";
  }      

   if(document.ExamBranchStudentSingle.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.ExamBranchStudentSingle.txtSetfocus.value);		
		oField.focus();
	} 
 
   
}



//******************************************* Batch *****************************************************//

function  ExamBranchStudentLoad()
{	
 if(document.ExamBranchStudent.txtMessage.value != "")
 {
	alert(document.ExamBranchStudent.txtMessage.value);
	document.ExamBranchStudent.txtMessage.value = "";
  }      
  
  if(document.ExamBranchStudent.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.ExamBranchStudent.txtSetfocus.value);		
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

function EBWiseStudentDetailsLoad()
{	
  if(document.EBWiseStudentDetails.txtMessage.value != "")
  {
	alert(document.EBWiseStudentDetails.txtMessage.value);
	document.EBWiseStudentDetails.txtMessage.value = "";
  }      
  
   if(document.EBWiseStudentDetails.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.EBWiseStudentDetails.txtSetfocus.value);		
		oField.focus();
	} 
}
////////////////////////////////////////
function HighlightRow(chkB)    {
			var oItem = chkB.children;
			xState= chkB.checked;
			//xState=oItem.item(0).checked;    
			
			if(xState)
				{	chkB.parentElement.parentElement.style.backgroundColor='Lavender';
					// grdEmployees.SelectedItemStyle.BackColor
					chkB.parentElement.parentElement.style.color='black'; 
					// grdEmployees.SelectedItemStyle.ForeColor
				}else 
				{	chkB.parentElement.parentElement.style.backgroundColor='#E0E0E0'; 
					//grdEmployees.ItemStyle.BackColor
					chkB.parentElement.parentElement.style.color='Blue'; 
					//grdEmployees.ItemStyle.ForeColor
				}
		}