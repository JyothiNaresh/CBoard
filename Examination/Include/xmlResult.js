

function CheckAll() 
{
	var chkItem = event.srcElement;
	var blnChecked=false;
	
	blnChecked=chkItem.checked;
	
	var iRow=2;
		
		while (true) 
			{
			iItem = document.xmlResult.all("dgGrid__ctl" + iRow + "_chkIT")
			if (iItem == null) return;
			iItem.checked=blnChecked;
			HighlightRow(iItem);
			iRow = iRow + 1;
			}
	
}

function CheckAll1() 
{
	var chkItem = event.srcElement;
	var blnChecked=false;
	
	blnChecked=chkItem.checked;
	
	var iRow=2;
		
		while (true) 
			{
			iItem = document.xmlResult.all("DgCommon__ctl" + iRow + "_chkIT1")
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


function  xmlResultLoad()
{	
 if(document.xmlResult.txtMessage.value != "")
  {
	alert(document.xmlResult.txtMessage.value);
	document.xmlResult.txtMessage.value = "";
  }      
  
  if(document.xmlResult.txtSetfocus.value != "")
  {		
		var oField;
		oField = document.all(document.xmlResult.txtSetfocus.value);		
		oField.focus();
  } 
}