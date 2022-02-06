//This is a Function For Progress Text Report for Validations
function ProgressTextReport()
{
   if(document.TxtRptProgress.txtMessage.value != "")
    {
		alert(document.TxtRptProgress.txtMessage.value);
		document.TxtRptProgress.txtMessage.value = "";
    }  
  	 if(document.TxtRptProgress.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.TxtRptProgress.txtSetfocus.value);		
		oField.focus();
	} 
    
 }
 
 //This is a Function For StudentEnquiry Text Report For Validataions
 function StuEnquiryTextReport()
 {
   if(document.TxtRptStuEnquiry.txtMessage.value != "")
    {
		alert(document.TxtRptStuEnquiry.txtMessage.value);
		document.TxtRptStuEnquiry.txtMessage.value = "";
    }  
  	 if(document.TxtRptStuEnquiry.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.TxtRptStuEnquiry.txtSetfocus.value);		
		oField.focus();
	} 
    
  }
 
 
 
 //This is a Function For ToppersList Text Report For Validations
 function ToppersListTextReport()
 {
   if(document.TxtRptToppersList.txtMessage.value != "")
    {
		alert(document.TxtRptToppersList.txtMessage.value);
		document.TxtRptToppersList.txtMessage.value = "";
    }  
  	 if(document.TxtRptToppersList.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.TxtRptToppersList.txtSetfocus.value);		
		oField.focus();
	} 
    
  }
 
 
 function GovtExamResultReport_ButtonsHide()
{
 	document.Form1.all['ibtnExamBranchSelect'].style.visibility = 'hidden';
	document.Form1.all['ibtnExamBranchSelectAll'].style.visibility = 'hidden';
	document.Form1.all['ibtnExamBranchRemove'].style.visibility = 'hidden';
	document.Form1.all['ibtnExamBranchRemoveAll'].style.visibility = 'hidden';
	
	document.Form1.all['ibtnBatchSelect'].style.visibility = 'hidden';
	document.Form1.all['ibtnBatchSelectAll'].style.visibility = 'hidden';
	document.Form1.all['ibtnBatchRemove'].style.visibility = 'hidden';
	document.Form1.all['ibtnBatchRemoveAll'].style.visibility = 'hidden';
	
	document.Form1.all['ibtnCasteSelect'].style.visibility = 'hidden';
	document.Form1.all['ibtnCasteSelectAll'].style.visibility = 'hidden';
	document.Form1.all['ibtnCasteRemove'].style.visibility = 'hidden';
	document.Form1.all['ibtnCasteRemoveAll'].style.visibility = 'hidden';
	
	document.Form1.all['ibtnReport'].style.visibility = 'hidden';
	
}


function RankCardErrorList_1ButtonsHide()
{
 	document.Form1.all['BtnSelCourse'].style.visibility = 'hidden';
	document.Form1.all['BtnSelCourseAll'].style.visibility = 'hidden';
	document.Form1.all['BtnRemCourse'].style.visibility = 'hidden';
	document.Form1.all['BtnRemCourseAll'].style.visibility = 'hidden';
	
	document.Form1.all['BtnSelEB'].style.visibility = 'hidden';
	document.Form1.all['BtnSelEBAll'].style.visibility = 'hidden';
	document.Form1.all['BtnRemEB'].style.visibility = 'hidden';
	document.Form1.all['BtnRemEBAll'].style.visibility = 'hidden';
	
	document.Form1.all['BtnSelGroup'].style.visibility = 'hidden';
	document.Form1.all['BtnSelGroupAll'].style.visibility = 'hidden';
	document.Form1.all['BtnRemGroup'].style.visibility = 'hidden';
	document.Form1.all['BtnRemGroupAll'].style.visibility = 'hidden';
	
	document.Form1.all['BtnSelBatch'].style.visibility = 'hidden';
	document.Form1.all['BtnSelBatchAll'].style.visibility = 'hidden';
	document.Form1.all['BtnRemBatch'].style.visibility = 'hidden';
	document.Form1.all['BtnRemBatchAll'].style.visibility = 'hidden';
	
	document.Form1.all['ibtnSelectStutype'].style.visibility = 'hidden';
	document.Form1.all['ibtnSelectAllStutype'].style.visibility = 'hidden';
	document.Form1.all['ibtnRemoveStutype'].style.visibility = 'hidden';
	document.Form1.all['ibtnRemoveAllStutype'].style.visibility = 'hidden';
	
	document.Form1.all['BtnSelSection'].style.visibility = 'hidden';
	document.Form1.all['BtnSelSectionAll'].style.visibility = 'hidden';
	document.Form1.all['BtnRemSection'].style.visibility = 'hidden';
	document.Form1.all['BtnRemSectionAll'].style.visibility = 'hidden';
	
	document.Form1.all['iBtnReport'].style.visibility = 'hidden';
	
}
 
 //THE FOLLOWING FUNCTION FOR SET PAGE POSITION(SMART NAVIGATION PROPERTY IN .NET)
//AMARENDRA B.V AS ON 27/6/2008

function ScrollIt()
{
    if (document.Form1.PageX != undefined && document.Form1.PageY != undefined)
	window.scrollTo(document.Form1.PageX.value, document.Form1.PageY.value);
}
    
function setcoords() {
    var IE = document.all ? true : false
    if (!IE) document.captureEvents(Event.MOUSEMOVE)
    var myPageX = 0; var myPageY = 0;
    function getMouseXY(e) {
        if (IE) { // grab the x-y pos.s if browser is IE
            myPageX = event.clientX + document.body.scrollLeft
            myPageY = event.clientY + document.body.scrollTop
        } else {  // grab the x-y pos.s if browser is NS
            myPageX = e.pageX
            myPageY = e.pageY
        }
        // catch possible negative values in NS4
        if (myPageX < 0) { myPageX = 0 }
        if (myPageY < 0) { myPageY = 0 }
        // show the position values in the form named Show
        // in the text fields named MouseX and MouseY
        document.Show.MouseX.value = myPageX
        document.Show.MouseY.value = myPageY
        return true
    }
    //if (document.all)
    //{
    //    myPageX = document.body.scrollLeft;
    //    myPageY = document.body.scrollTop;
    //}
    //else
    //{.
    //    myPageX = window.pageXOffset;
    //    myPageY = window.pageYOffset;
    //}
    //document.Form1.PageX.value = myPageX;
    //document.Form1.PageY.value = myPageY;
}

//END

 function Reports_ButtonsHide()
{
 //added by prakash on oct 15 2007
  var imgbuttons = document.forms[0].getElementsByTagName("INPUT");
  for(var i = 0; i < imgbuttons.length; i++)
  {
    if(imgbuttons[i].type == "image")
      imgbuttons[i].style.visibility = 'hidden';
  };
}
 
 
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
	