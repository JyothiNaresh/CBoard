function strReverse(Str)
{
	var res= Str.replace("#","").toUpperCase();
	var N = res.length;
	for (k = 0,t = ""; k < N; k++)
	{
		t += res.substring(N-k-1, N-k); // s.substring(from, to)
	}
	var ven = parseInt(t,16);
	return ven;
}
		
function CreateExcelSheet(tblid, sheetName, sheetNum, filePath) 
{
	var jstblArg = tblid.split(','); //Getting tableId's Splitting
	var wrkshtnames = sheetName.split(',');
	var wrksheets = sheetNum.split(','); //Getting SheetNum's Splitting
		
	var vTop = -4160,vCenter = -4108,vBottom = -4107;
	var hLeft = -4131,hCenter = -4108,hRight = -4152;
			
    var xlsAp = new ActiveXObject("Excel.Application");
    xlsAp.DisplayAlerts = false;
	var excBook = xlsAp.Workbooks.Add;
	//excBook.Password="NES";
		        
	for (rep = 0; rep < jstblArg.length ; rep++)
	{
		var tbl = document.getElementById(jstblArg[rep]);
		var x = tbl.rows;
		for (i = 0; i < x.length; i++) 
		{
			var y = x[i].cells;
			var Vmerge = 1 ;
			for (j = 0; j < y.length; j++) 
			{
				var PrvColsp = 0;
				var ColSp = y[j].colSpan;
				excBook.WorkSheets([rep+1]).Cells(i+1, j+Vmerge).value = y[j].innerText;
							
				excBook.WorkSheets([rep+1]).name = wrkshtnames[rep];		
							
				//For BackGroundColor
				var bgcol=y[j].bgColor;
							
				switch (bgcol)
				{
					case "#b8773d":
						bgcol = '#CC6600';
						break;
					case "#B8773D":
						bgcol = '#CC6600';
						break;
					case "#EBDED6":
						bgcol = '#FFD39B';
						break;
				}
				if(bgcol.length>0)
				{
					var bgven=strReverse(bgcol);
					excBook.WorkSheets([rep+1]).Cells(i+1, j+Vmerge).Interior.Color = bgven;
				}
						
				//For ForeColor
				var fntcol=y[j].currentStyle.color;
				if (fntcol.indexOf("#") > -1)
				{//ColorName
					var foreColor = strReverse(fntcol);
					excBook.WorkSheets([rep+1]).Cells(i+1, j+Vmerge).Font.Color = foreColor;
				}
							
				var cellBorderColor = strReverse('#33CCCC');
				excBook.WorkSheets([rep+1]).Cells(i+1, j+Vmerge).Borders.Color = cellBorderColor;
				
				//Horizontal Alignment
				switch (y[j].align)
				{
					case "center":
						excBook.WorkSheets([rep+1]).Cells( i+1, j+Vmerge).HorizontalAlignment	= hCenter;
						break;
					case "left":
						excBook.WorkSheets([rep+1]).Cells( i+1, j+Vmerge).HorizontalAlignment	= hLeft;
						break;
					case "right":
						excBook.WorkSheets([rep+1]).Cells( i+1, j+Vmerge).HorizontalAlignment	= hRight;
						break;
				}
				//Vertical Alignment
				excBook.WorkSheets([rep+1]).Range(excBook.WorkSheets([rep+1]).Cells( i+1, j+1), excBook.WorkSheets([rep+1]).Cells( i+1, j+ColSp)).VerticalAlignment	= vCenter;
				
				//Merge
				if (ColSp>1)
				{
					excBook.WorkSheets([rep+1]).Range(excBook.WorkSheets([rep+1]).Cells( i+1, j+Vmerge), excBook.WorkSheets([rep+1]).Cells( i+1, j+ColSp)).MergeCells = true;
					excBook.WorkSheets([rep+1]).Range(excBook.WorkSheets([rep+1]).Cells( i+1, j+Vmerge), excBook.WorkSheets([rep+1]).Cells( i+1, j+ColSp)).HorizontalAlignment = hCenter;
					excBook.WorkSheets([rep+1]).Range(excBook.WorkSheets([rep+1]).Cells( i+1, j+Vmerge), excBook.WorkSheets([rep+1]).Cells( i+1, j+ColSp)).VerticalAlignment = vCenter;
					excBook.WorkSheets([rep+1]).Range(excBook.WorkSheets([rep+1]).Cells( i+1, j+Vmerge), excBook.WorkSheets([rep+1]).Cells( i+1, j+ColSp)).Borders.Color = cellBorderColor;
				}
				Vmerge = ColSp;
			}
		}
	}
	var excPath = filePath;
	excBook.SaveAs(filePath);
	excBook.Close();
	xlsAp.Quit();
	window.CollectGarbage();
	alert('File Created Successfully..! Path :: ' + filePath);
}

function CreateExcelSheet(tblid, sheetName, filePath) 
	    {
			//try
			//{
				var jstblArg = tblid.split(','); //Getting tableId's Splitting
				var wrkshtnames = sheetName.split(',');
				
				var vTop = -4160,vCenter = -4108,vBottom = -4107;
				var hLeft = -4131,hCenter = -4108,hRight = -4152;
				
		        var xlsAp = new ActiveXObject("Excel.Application");
		        xlsAp.DisplayAlerts = false;
				var excBook = xlsAp.Workbooks.Add;
				//excBook.Password="NES";
				
				var sheetCnt = excBook.Worksheets.Count - 1;
				
				for (ws = 0; ws < sheetCnt; ws++)
				{
					excBook.ActiveSheet.Delete(); // s.substring(from, to)
				}
				
			    for (rep = 0; rep < jstblArg.length ; rep++)
			    {
			    
					//if (Sheetindex > ExsheetCnt)
					//{
						var sheetC = excBook.Worksheets.Add();  
						//excBook.ActiveSheet.Move(excBook.Worksheets(sheetBefore));
						//excBook.ActiveSheet.Move(after:=Sheets(Sheets.Count)); 
						excBook.ActiveSheet.name = wrkshtnames[rep];		
					//}
					//else
					//{
					//	excBook.WorkSheets(Sheetindex).name = wrkshtnames[rep];		
					//}	
					
					var tbl = document.getElementById(jstblArg[rep]);
					var x = tbl.rows;
					for (i = 0; i < x.length; i++) 
					{
						var y = x[i].cells;
						var Vmerge = 1 ;
						for (j = 0; j < y.length; j++) 
						{
							var PrvColsp = 0;
							var ColSp = y[j].colSpan;
							var CelInd =  Vmerge;
							var Cmerge = 0;
							if (j>0)
							{
								Cmerge = (Vmerge + ColSp - 1);
							}
							else
							{
								Cmerge = ColSp;
							}
							
							excBook.ActiveSheet.Range(excBook.ActiveSheet.Cells( i+1, Vmerge), excBook.ActiveSheet.Cells( i+1, Cmerge)).value = y[j].innerText;
							
							//For BackGroundColor
							var bgcol=y[j].style.backgroundColor; 
							//var bgcol=y[j].bgColor;
							
							switch (bgcol)
							{
								case "#b8773d":
									bgcol = '#CC6600';
									break;
								case "#ebded6":
									bgcol = '#FFFFFF';
									break;
							}
							if(bgcol.length>0)
							{
								var bgven=strReverse(bgcol);
								excBook.ActiveSheet.Cells(i+1, CelInd).Interior.Color = bgven;
							}
							
							//For ForeColor
							var fntcol=y[j].currentStyle.color;
							if (fntcol.indexOf("#") > -1)
							{//ColorName
								var foreColor = strReverse(fntcol);
								excBook.ActiveSheet.Cells(i+1, CelInd).Font.Color = foreColor;
							}
							
							var cellBorderColor = strReverse('#33CCCC');
							excBook.ActiveSheet.Cells(i+1, CelInd).Borders.Color = cellBorderColor;
							
							var strLength = excBook.ActiveSheet.Cells(i+1, CelInd).Text.length;
							
							//alert(strLength);

							//Horizontal Alignment
							var halign;
							switch (y[j].align)
							{
								case "center":
									halign = hCenter;
									break;
								case "left":
									halign = hLeft;
									break;
								case "right":
									halign = hRight;
									break;
							}

							var fntStyle = y[j].style.fontWeight;
							
							
							if (fntStyle =='bold')
							{
								excBook.ActiveSheet.Range(excBook.ActiveSheet.Cells( i+1, Vmerge), excBook.ActiveSheet.Cells( i+1, Cmerge)).Font.Bold = true ;
							}
							excBook.ActiveSheet.Range(excBook.ActiveSheet.Cells( i+1, Vmerge), excBook.ActiveSheet.Cells( i+1, Cmerge)).MergeCells = true;
							excBook.ActiveSheet.Range(excBook.ActiveSheet.Cells( i+1, Vmerge), excBook.ActiveSheet.Cells( i+1, Cmerge)).HorizontalAlignment = halign;
							excBook.ActiveSheet.Range(excBook.ActiveSheet.Cells( i+1, Vmerge), excBook.ActiveSheet.Cells( i+1, Cmerge)).VerticalAlignment = vCenter;
							excBook.ActiveSheet.Range(excBook.ActiveSheet.Cells( i+1, Vmerge), excBook.ActiveSheet.Cells( i+1, Cmerge)).Borders.Color = cellBorderColor;
							excBook.ActiveSheet.Range(excBook.ActiveSheet.Cells( i+1, Vmerge), excBook.ActiveSheet.Cells( i+1, Cmerge)).RowHeight = 17;
							//adfadf
						//}
							Vmerge = Vmerge + ColSp;
						}
					}
					//for (CelNum = 0,t = ""; k < N; k++)
					//{
					//	t += res.substring(N-k-1, N-k); 
					//}	
				}
				//Setting ColumnWidth
				var excPath = filePath;
				excBook.SaveAs(filePath);
				excBook.Close();
				xlsAp.Quit();
				window.CollectGarbage();
				alert('File Created Successfully..! Path :: ' + filePath);
			}
		
		function strReverse(Str)
		{
			var res= Str.replace("#","").toUpperCase();
			var N = res.length;
			for (k = 0,t = ""; k < N; k++)
			{
				t += res.substring(N-k-1, N-k); // s.substring(from, to)
			}
			var ven = parseInt(t,16);
			return ven;
		}
		function excelExp(tblid, sheetName)
		{
			var objExcel = new ActiveXObject ("Excel.Application");
			objExcel.visible = false;
	
			objExcel.DisplayAlerts = false;

			var jstblArg = tblid.split(','); //Getting tableId's Splitting
			var wrkshtnames = sheetName.split(',');
			
			var objWorkbook = objExcel.Workbooks.Add;
			//objWorkbook.Password="NES";
			
			var sheetCnt = objWorkbook.Worksheets.Count - 1;
				
			for (ws = 0; ws < sheetCnt; ws++)
			{
				objWorkbook.ActiveSheet.Delete(); // s.substring(from, to)
			}
			
			for (rep = 0; rep < jstblArg.length ; rep++)
			{
				var rowlen = document.getElementById(jstblArg[rep]).rows.length;
				if (rowlen > 0)
				{
					var thisTabler = document.getElementById(jstblArg[rep]).outerHTML;
					window.clipboardData.setData("Text", thisTabler);
				
					var sheetR = objWorkbook.Worksheets.Add();  
					objWorkbook.ActiveSheet.name = wrkshtnames[rep];			
					sheetR.Paste
					var cellBorderColor = strReverse('#33CCCC');
					objWorkbook.ActiveSheet.Cells.Borders.Color = cellBorderColor;
				}
			}
			
			var FilePath = document.getElementById('txtfilename').value;
			objWorkbook.SaveAs(FilePath);
			objWorkbook.Close();
			objExcel.Quit();
			window.CollectGarbage();
			alert("Excel Created Succesfully.. Path : "+FilePath);
		}
		function convertTabs(tabname)
{
	var ctArg = tabname.split(',');
		
	$('#tabs').tabs();
			
	for (var i = 0; i < ctArg.length; i++) 
	{
		var tab = $('#tabs').tabs('getTab',i);
		$('#tabs').tabs('update', {tab: tab,options: {title: ctArg[i]}
		});	
	}
}