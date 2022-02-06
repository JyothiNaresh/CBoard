
function ShowHide() 
{
var arg = ShowHide.arguments;
var e = document.getElementById(arg[0]);
var d = document.getElementById(arg[1]);

	if(e.style.display == 'block' || e.style.display=='')
	{
		e.style.display = 'none';
	    d.value="0";
		}
	else
	{
		e.style.display = 'block';
		d.value="1";
	}
}

function PanelSet() 
{
var arg = PanelSet.arguments;

	for(var i = 0; i < arg.length; i++)
	{
		var parg = arg[i].split(",");
		var pnl = document.getElementById(parg[0]);
		if(parg[1] == '0')
			{
			pnl.style.display = 'none';
			}
		else
			{
			pnl.style.display = 'block';
			}	
	}
}

