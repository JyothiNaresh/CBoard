function CTExamLoad()
{	
 
 if(document.CTExam.txtMessage.value != ""){
	alert(document.CTExam.txtMessage.value);
	document.CTExam.txtMessage.value = "";
  }      
  
 
  if(document.CTExam.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.CTExam.txtSetfocus.value);		
		oField.focus();
	} 
}


//////////////////////////////////////////////////////////////////////////////////////////

function CTExamBatchLoad()
{	
 
 if(document.CTExamBatch.txtMessage.value != ""){
	alert(document.CTExamBatch.txtMessage.value);
	document.CTExamBatch.txtMessage.value = "";
  }      
  
 
  if(document.CTExamBatch.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.CTExamBatch.txtSetfocus.value);		
		oField.focus();
	} 
}

///////////////////////////////////////////////////////////////////////////

function ChecksOne() {

	var chkItem = event.srcElement;
	
	var blnChecked=false;
	blnChecked=chkItem.checked;
	
	
	var iRow=2;
	
			
		while (true) {
	//"_ChkDg1"	
		iItem = document.CTExam.all("DataGrid1__ctl" + iRow + "_ChkDg1")
		
			if (iItem == null) return;
			
			iItem.checked=blnChecked;
			
			HighlightRow(iItem);
					iRow = iRow + 1;
			}
	
}


///////////////////////////////////////////////////////////////////////////
function ChecksView() {

	var chkItem = event.srcElement;
	
	var blnChecked=false;
	blnChecked=chkItem.checked;
	
	
	var iRow=2;
	
			
		while (true) {
	
		iItem = document.CTExam.all("DGview__ctl" + iRow + "_ChkDg2")
		
			if (iItem == null) return;
			
			iItem.checked=blnChecked;
			HighlightRow(iItem);
					iRow = iRow + 1;
			}
	
}


///////////////////////////////Grid Row Color ///////////////////////////////////////

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
		
///////////////////////////////////////////////////////////////////////////

function ChecksPOPUP() {

	var chkItem = event.srcElement;
	
	var blnChecked=false;
	blnChecked=chkItem.checked;
	
	
	var iRow=2;
	
			
		while (true) {
	//"_ChkDg1"	
		iItem = document.CTExam.all("DGPopGrid__ctl" + iRow + "_ChkPOP")
		
			if (iItem == null) return;
			
			iItem.checked=blnChecked;
			
			HighlightRow(iItem);
					iRow = iRow + 1;
			}
	
}

///////////////////////////////////////////////////////////////////////////

function ResChecksPOPUP() {

	var chkItem = event.srcElement;
	
	var blnChecked=false;
	blnChecked=chkItem.checked;
	
	
	var iRow=2;
	
			
		while (true) {
	//"_ChkDg1"	
		iItem = document.frmResRangeIntRep.all("DgRangeInt__ctl" + iRow + "_ChkOne")
		
			if (iItem == null) return;
			
			iItem.checked=blnChecked;
			
			HighlightRow(iItem);
					iRow = iRow + 1;
			}
	
}


///////////////////////////////////////////////////////////////////////////

function ResMChecksPOPUP() {

	var chkItem = event.srcElement;
	
	var blnChecked=false;
	blnChecked=chkItem.checked;
	
	
	var iRow=2;
	
			
		while (true) {
	//"_ChkDg1"	
		iItem = document.RanksRangeMulitSelection.all("DgRangeInt__ctl" + iRow + "_ChkOne")
		
			if (iItem == null) return;
			
			iItem.checked=blnChecked;
			
			HighlightRow(iItem);
					iRow = iRow + 1;
			}
	
}

function WTDelChecksPOPUP() {

	var chkItem = event.srcElement;
	
	var blnChecked=false;
	blnChecked=chkItem.checked;
	
	
	var iRow=2;
	
			
		while (true) {
	//"_ChkDg1"	
		iItem = document.frmExamTailoringDelete.all("DgStudents__ctl" + iRow + "_ChkOne")
		
			if (iItem == null) return;
			
			iItem.checked=blnChecked;
			
			HighlightRow(iItem);
					iRow = iRow + 1;
			}
	
}
