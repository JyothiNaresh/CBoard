


// code for check and uncheck

	function HighlightTop(chk)
		{
			var state =chk.checked;
			var ctl;
			
			var srcText;	
			var srcNumber;
			var ctlText;
			
			srcText = chk.id.substr(chk.id.indexOf("__") + 5 , 3);
			srcNumber = parseInt(srcText.substr(0,srcText.indexOf("_")));
			
			HighlightRow(chk);
			
			if (state)	{
				// check above
				for (var i = srcNumber - 1; i > 0; i--)	{
					ctlText = "dgRange__ctl" + i + "_" + "chkActive" ;
					ctl = window.document.getElementById(ctlText);
					if (ctl == null) break; //if (ctl != null) 
					ctl.checked = state;
					HighlightRow(ctl);
				} //end of for
			
			} //end state if
			
			// Un check down
				for (var i = srcNumber + 1; i <= 17; i++)	{
					ctlText = "dgRange__ctl" + i + "_" + "chkActive" ;
					ctl = window.document.getElementById(ctlText);
					if (ctl == null) break; //if (ctl != null) 
					ctl.checked = false;
					HighlightRow(ctl);
					
				} //end of for
				

		} //end

	function HighlightRow(chkB)    
	{
			var oItem = chkB.children;
			xState= chkB.checked;
			//xState=oItem.item(0).checked;    
			
			if(xState)
				{	
					
					chkB.parentElement.parentElement.parentElement.style.backgroundColor='Lavender';
					// grdEmployees.SelectedItemStyle.BackColor
					chkB.parentElement.parentElement.parentElement.style.color='black'; 
					// grdEmployees.SelectedItemStyle.ForeColor
				}
			else 
				{	chkB.parentElement.parentElement.parentElement.style.backgroundColor='#E0E0E0'; 
					//grdEmployees.ItemStyle.BackColor
					chkB.parentElement.parentElement.parentElement.style.color='Blue'; 
					//grdEmployees.ItemStyle.ForeColor
				}
}

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