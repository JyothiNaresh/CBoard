//This Is For To open the New Window For ExamTypeWiseSingle
/**
var wExamQues;
function showExamWindow(Edit)
{
	var iCourseIndex=document.ExamTypeWiseQuestionsSingle.drpCourse.selectedIndex;
	if (iCourseIndex<0) {
		alert("Please Select Course");
	}
	else
	{
	var iCourseValue=document.ExamTypeWiseQuestionsSingle.drpCourse.options[iCourseIndex].value;
	wExamQues=window.open("ExamTypeWiseQuestions.aspx?EditMode=" + Edit + "&CourseSlno=" + iCourseValue);
		
	//document.ExamTypeWiseQuestionsSingle.cmdPost.click();
	}
}

*function SendEditValue()
		{
			var srcEvent = event.srcElement.id;
			
			if (srcEvent == "" || srcEvent.indexOf("__") == -1) 
				return false;
			
			if (srcEvent.indexOf("btnEdit") != -1 ) {
			
				srcText=srcEvent.substring(0,srcEvent.indexOf("_btnEdit")) ;
				
				trgText=srcText + "_txtSLNO";
				
				EditValue=document.ExamTypeWiseQuestionsSingle.item(trgText).value;
				document.ExamTypeWiseQuestionsSingle.txtEdit.text=EditValue;
				//alert(document.ExamTypeWiseQuestionsSingle.txtEdit.text)
				
				
			document.ExamTypeWiseQuestionsSingle.cmdPost.click();
						
									
				//document.				
				//showExamWindow(EditValue);
				
				return false;
				
			}			
				
		
		}


function ShowCourseSlno()
{
var Myarg=new Array('','');
Myarg=window.dialogArguments;
if (Myarg!=null) 
{
document.ExamTypeWiseQuestions.txtCourseSlno.value=Myarg[0].toString();
document.ExamTypeWiseQuestions.txtEditMode.value=Myarg[1].toString();
}
}*/


function ExamTypeWiseQuestionsSingleLoad()
{
if(document.ExamTypeWiseQuestionsSingle.txtMessage.value!="")
{
alert(document.ExamTypeWiseQuestionsSingle.txtMessage.value);
document.ExamTypeWiseQuestionsSingle.txtMessage.value="";
}

if(document.ExamTypeWiseQuestionsSingle.txtSetfocus.value!="")
{
var oField;
oField=document.all(document.ExamTypeWiseQuestionsSingle.txtSetfocus.value);
oField.focus();
}

if(document.ExamTypeWiseQuestionsSingle.txtMarks.value!="")
{
alert(document.ExamTypeWiseQuestionsSingle.txtMarks.value);
document.ExamTypeWiseQuestionsSingle.txtMarks.value="";
}

}



/**    /For Modal Dialogbox
function showExamDialog(EditMode) 
{
	var MyArgs =new Array ('','') ;
	MyArgs[0]=document.ExamTypeWiseQuestionsSingle.txtCourse.value;
	MyArgs[1]=EditMode;

	var WinSettings = "center:yes;resizable:no;scrollbars:no;dialogHeight:350px;dialogWidth:500px"
	MyArgs = window.showModalDialog("ExamType.htm",MyArgs,WinSettings);
	if (EditMode=='Add'){
		document.ExamTypeWiseQuestionsSingle.cmdPost.click();
	}
} **/


