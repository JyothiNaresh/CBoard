//************************************* Student Details Begin**********************************************//


function showAddressDialog() {


var WinSettings = "center:yes;resizable:no;scrollbars:no;dialogHeight:280px;dialogWidth:710px"

var MyArgs = window.showModalDialog("../StudentFrame.htm",MyArgs,WinSettings);

document.AdmissionNew.cmdPost.click();

} 


//************************************* Student Details End**********************************************//

//****************************** Admission Home Page Java Script Begin ****************************//

function AdmissionHomePageLoad()
{	

	window.focus();
  if(document.AdmissionHomePage.txtMessage.value != ""){
	alert(document.AdmissionHomePage.txtMessage.value);
	document.AdmissionHomePage.txtMessage.value = "";
  }      
  
  if(document.AdmissionHomePage.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.AdmissionHomePage.txtSetfocus.value);		
		oField.focus();
	} 
}

//****************************** Admission Home Page Java Script End ****************************//




//************************************* Admission Search Page Begin**********************************************//


function AdmissionSearchLoad()
{	
if (document.AdmissionSearch.txtADMNO.Enabled =true)
  {
	document.AdmissionSearch.txtADMNO.focus();
  }
   
  if(document.AdmissionSearch.txtMessage.value != ""){
	alert(document.AdmissionSearch.txtMessage.value);
	document.AdmissionSearch.txtMessage.value = "";
  }      
  
  if(document.AdmissionSearch.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.AdmissionSearch.txtSetfocus.value);		
		oField.focus();
	} 
}



//Page Level Validations for SOASearch
function AdmissionSearch_Validation()
{	       
 var strFieldName = "Date Of Birth ";  
  if(!ValidateForm(document.AdmissionSearch.txtDOB, strFieldName)) {
	return false;
	}
}



//************************************* SOA Search Page End**********************************************//
//************************************* SOA Search Result  Page Begin**********************************************//

function AdmissionSearchResultLoad()
{	

   
  if(document.AdmissionSearchResult.txtMessage.value != ""){
	alert(document.AdmissionSearchResult.txtMessage.value);
	document.AdmissionSearchResult.txtMessage.value = "";
  }      
  
  if(document.AdmissionSearchResult.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.AdmissionSearchResult.txtSetfocus.value);		
		oField.focus();
	} 
}

//************************************* SOA Search Result  Page End**********************************************//

//****************************** Admission New Page Java Script Begin****************************//

//This function set the focus,when page is loaded
function AdmissionNewLoad()
{	
   if(document.AdmissionNew.txtMessage.value != ""){
	alert(document.AdmissionNew.txtMessage.value);
	document.AdmissionNew.txtMessage.value = "";
  }   
  
  if(document.AdmissionNew.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.AdmissionNew.txtSetfocus.value);		
		oField.focus();
	} 
    
} 

//Page Level Validations for Admission New
function ADMNew_Validation()
{	       

if(document.AdmissionNew.cboBranchAt.length==0) {
	alert('Select Branch At from the list');
	document.AdmissionNew.cboBranchAt.focus();
	return false;
  }

if(document.AdmissionNew.cboBranchFor.length==0) {
	alert('Select Branch For from the list');
	document.AdmissionNew.cboBranchFor.focus();
	return false;
  }

if(document.AdmissionNew.cboCourse.length==0) {
	alert('Select Course from the list');
	alert('SUdha3');
	document.AdmissionNew.cboCourse.focus();
	return false;
  }

if(document.AdmissionNew.cboGroup.length==0) {
	alert('Select Group from the list');
	document.AdmissionNew.cboGroup.focus();
	return false;
  }

if(document.AdmissionNew.cboBatch.length==0) {
	alert('Select Batch from the list');
	document.AdmissionNew.cboBatch.focus();
	return false;
  }

if(document.AdmissionNew.cboMedium.length==0) {
	alert('Select Medium from the list');
	document.AdmissionNew.cboMedium.focus();
	return false;
  }

if(document.AdmissionNew.cboStudentType.length==0) {
	alert('Select Student Type from the list');
	document.AdmissionNew.cboStudentType.focus();
	return false;
  }
 
  var strFieldName = "Form No ";  
  if(!ForceEntry(document.AdmissionNew.txtFormNo, strFieldName)) {
  	return false;
  }
   
  var strFieldName = "Form No ";  
  if(!ForceNumber(document.AdmissionNew.txtFormNo, strFieldName)) {
  	return false;
  } 
    
 }
