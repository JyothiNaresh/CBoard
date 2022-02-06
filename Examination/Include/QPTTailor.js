
function QPTTailorLoad()
{
if(document.QPTTailor.txtMessage.value!="")
{
alert(document.QPTTailor.txtMessage.value);
document.QPTTailor.txtMessage.value="";
}

if(document.QPTTailor.txtSetfocus.value!="")
{
var oField;
oField=document.all(document.QPTTailor.txtSetfocus.value);
oField.focus();
}

if(document.QPTTailor.txtMarks.value!="")
{
alert(document.QPTTailor.txtMarks.value);
document.QPTTailor.txtMarks.value="";
}

}