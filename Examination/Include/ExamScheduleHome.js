
//Validation function for Examination Home on Go Button

function ScheduleHomeValidation()

	{
		
		if (document.frmExamScheduleHome.cboCourse== '[object]')
		{
		if (document.frmExamScheduleHome.cboCourse.selectedIndex==-1) {
			alert("Invalid Course Name");
			document.frmExamScheduleHome.cboCourse.focus();
			return false;
		}
		}

		if (document.frmExamScheduleHome.cboPeriodicity== '[object]')
		{
		if (document.frmExamScheduleHome.cboPeriodicity.selectedIndex==-1) {
			alert("Invalid Periodicity Name");
			document.frmExamScheduleHome.cboPeriodicity.focus();
			return false;
		}
		}
		
		
		if (document.frmExamScheduleHome.cboExamType== '[object]')
		{
		if (document.frmExamScheduleHome.cboExamType.selectedIndex==-1) {
			alert("Invalid Examination Type Name");
			document.frmExamScheduleHome.cboExamType.focus();
			return false;
		}
		}

		if (document.frmExamScheduleHome.cboExamLevel== '[object]')
		{
		if (document.frmExamScheduleHome.cboExamLevel.selectedIndex==-1) {
			alert("Invalid Examination Level Name");
			document.frmExamScheduleHome.cboExamLevel.focus();
			return false;
		}
		}

		if (document.frmExamScheduleHome.cboExamLevel== '[object]')
		{
		if (document.frmExamScheduleHome.cboExamLevel.selectedIndex==1) {
		
		if (document.frmExamScheduleHome.cboBranch== '[object]')
		{	
			if (document.frmExamScheduleHome.cboBranch.selectedIndex == -1) {
				alert("Invalid Branch Name");
				document.frmExamScheduleHome.cboBranch.focus();
				return false;
			}
			}
		}
		}

		if (document.frmExamScheduleHome.txtFromDate=='[object]')
		{
		if (! ValidateForm(document.frmExamScheduleHome.txtFromDate,"From Date")) {
			return false;
		}
		}
		
		if (document.frmExamScheduleHome.txtToDate=='[object]')
		{
		if (! ValidateForm(document.frmExamScheduleHome.txtToDate,"To Date")) {
			return false;
		}
		}


		
		if (document.frmExamScheduleHome.cboStatus== '[object]')
		{
		if (document.frmExamScheduleHome.cboStatus.selectedIndex==-1) {
			alert("Invalid Status Name");
			document.frmExamScheduleHome.cboStatus.focus();
			return false;
		}
		}

	}
	
	
	
//***************************************************************************************************************
//Unchecks if user selected in check box in Grid

//dgSchedule__ctl3_chkOne


function ChecksOne() {

	var chkItem = event.srcElement;
	
	var iRow=3;
	
	if (chkItem.checked == true) {
	
		var iItem= document.frmExamScheduleHome.all("dgSchedule__ctl2_chkAll")
	
		while (true) {
	
			if (iItem == null) return;
			
			if (chkItem != iItem) iItem.checked=false;
			
			iItem = document.frmExamScheduleHome.all("dgSchedule__ctl" + iRow + "_chkOne")
	
			iRow = iRow + 1;
			}
	}

}

//*********************************************************************************************

function CheckAllReportMap() 
{
	
	var chkItem = event.srcElement;
	var blnChecked=false;
	
	blnChecked=chkItem.checked;
	
	var iRow=2;
		
		while (true) 
			{
			iItem = document.Form1.all("dgReportMap__ctl" + iRow + "_chkIT")
			if (iItem == null) return;
			iItem.checked=blnChecked;
			//HighlightRow(iItem);
			iRow = iRow + 1;
			}
	
}

//*********************************************************************************************
////For Grid Check Box
function CheckAll() 
{
	var chkItem = event.srcElement;
	var blnChecked=false;
	
	blnChecked=chkItem.checked;
	
	var iRow=2;
		
		while (true) 
			{
			iItem = document.frmExamScheduleHome.all("dgSchedule__ctl" + iRow + "_chkOne")
			if (iItem == null) return;
			iItem.checked=blnChecked;
			//HighlightRow(iItem);
			iRow = iRow + 1;
			}
	
}
//***************************************************************************************************************

////For Grid Check Box
function GaCheckAll() 
{
	var chkItem = event.srcElement;
	var blnChecked=false;
	
	blnChecked=chkItem.checked;
	
	var iRow=2;
		
		while (true) 
			{
			iItem = document.AcyearWiseGASubGroupDetailMap.all("dgGASGDT__ctl" + iRow + "_chkIT")
			if (iItem == null) return;
			iItem.checked=blnChecked;
			//HighlightRow(iItem);
			iRow = iRow + 1;
			}
	
}

//***************************************************************************************************************
////For Grid Check Box
function BrdCheckAll() 
{
	var chkItem = event.srcElement;
	var blnChecked=false;
	
	blnChecked=chkItem.checked;
	
	var iRow=2;
		
		while (true) 
			{
			iItem = document.AcyearWiseGASubGroupDetailMap.all("DgColl__ctl" + iRow + "_chkIT")
			if (iItem == null) return;
			iItem.checked=blnChecked;
			//HighlightRow(iItem);
			iRow = iRow + 1;
			}
	
}
//***************************************************************************************************************
//Key down event for text box in datagrid

function txtGridUpDown(frmName,grdName,txtName) {

	//alert(window.event.keyCode);

	if ((window.event.keyCode == 40 ) || (window.event.keyCode == 13 )) {
		//alert("IN 40");
		var txt = event.srcElement.id;
		//alert(txt);
		var sNum = txt.indexOf("__ctl");
		if (sNum != -1) 
			sNum=sNum + 5;
		else
			return false;
			
		var lNum = txt.indexOf("_txt");
		if (lNum == -1 ) return false ;
		
		var cNum = txt.substr(sNum,lNum - sNum);
		cNum = parseInt(cNum);
		
		cNum = cNum + 1;
		
		iItem = document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName);
		if (iItem == null) return false;
		iItem.focus();
		
		return false;
	}
	
	else if (window.event.keyCode == 38 ) {
	
		var txt = event.srcElement.id;
		
		var sNum = txt.indexOf("__ctl");
		if (sNum != -1) 
			sNum=sNum + 5;
		else
			return ;
			
		var lNum = txt.indexOf("_txt");
		if (lNum == -1 ) return ;
		
		var cNum = txt.substr(sNum,lNum-sNum);
		cNum = parseInt(cNum);
		
		cNum = cNum - 1;
		
		iItem = document.all(frmName).all(grdName + "__ctl" + cNum + "_" + txtName);
		
		if (iItem == null) return;
		iItem.focus();
	
	
	}	
	
	
}
	
	
//***************************************************************************************************************
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

