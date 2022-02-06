

function PCPresentCourseLoad()
{	
 
 if(document.PCPresentCourse.txtMessage.value != ""){
	alert(document.PCPresentCourse.txtMessage.value);
	document.PCPresentCourse.txtMessage.value = "";
  }      
  
 
  if(document.PCPresentCourse.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.PCPresentCourse.txtSetfocus.value);		
		oField.focus();
	} 
}

//******************************************* Single Mode Validateion ***********************************//
	function PCPresentCourseBatch_Validation() {
			
		if (document.PCPresentCourse.CboCourse.selectedIndex==-1) {
			alert("Please select Course Name");
			if (document.PCPresentCourse.CboCourse.disabled==false)
				document.PCPresentCourse.CboCourse.focus();
				return false;
		}
		
		if (document.PCPresentCourse.CboPVCourse.selectedIndex==-1) {
			alert("Please select Previous Course Name");
			
			return false;
		}
		
		
		
	
		return true;
	}

//******************************************* Batch *****************************************************//

function  PCPresentCourseBatchLoad()
{	
 if(document.PCPresentCourseBatch.txtMessage.value != ""){
	alert(document.PCPresentCourseBatch.txtMessage.value);
	document.PCPresentCourseBatch.txtMessage.value = "";
  }      
  
  if(document.PCPresentCourseBatch.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.PCPresentCourseBatch.txtSetfocus.value);		
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

function PCPresentCourseDetailsLoad()
{	
 
 if(document.PCPresentCourseDetails.txtMessage.value != ""){
	alert(document.PCPresentCourseDetails.txtMessage.value);
	document.PCPresentCourseDetails.txtMessage.value = "";
  }      
  
 
  if(document.PCPresentCourseDetails.txtSetfocus.value != "")
    {		
		var oField;
		oField = document.all(document.PCPresentCourseDetails.txtSetfocus.value);		
		oField.focus();
	} 
}
