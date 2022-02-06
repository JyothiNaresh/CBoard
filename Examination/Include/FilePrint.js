function PrintFrame(xFile)
			{
				parent.iframePDF.location.href = xFile;
				alert(xFile);
				document.getElementById("spanMess").style.display="block";
				parent.iframePDF.onload = new function(){setTimeout("parent.iframePDF.print();parent.document.getElementById('spanMess').style.display='none';",5000);}
			}