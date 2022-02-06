function ShowHidePanel() 
{
var arg = ShowHidePanel.arguments;

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