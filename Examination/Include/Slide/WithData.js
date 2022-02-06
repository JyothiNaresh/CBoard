/* Developed by P.Venu [27-Mar-2012 taken from HighCharts]*/

function DynamicGraph() 
{
    var JQArg = DynamicGraph.arguments;
    document.getElementById('ChartData').innerHTML = JQArg[0];
    document.getElementById('HtmlGrid').innerHTML = JQArg[7];
    var DrpTheme = document.getElementById('DrpTh');
    var JQArgs = JQArg[1].split(",");
    var JQChartTheme = JQArg[2];
    var JQlables = "'" + JQChartType + "'";
    var JQYStart = JQArg[3];
    if (JQArg[4] == 0)
    {
    var JQYIntervel = null;
    }
    else
    {
    var JQYIntervel = JQArg[4];
    }
    //var JQYIntervel = JQArg[4];
    var JQXaxis = parseFloat(JQArg[5]);
    var JQYaxis = parseFloat(JQArg[6]);
    //var Applytheme='JQtheme('+JQChartTheme')';
    if (JQChartTheme == 'Normal') {} else {
        JQtheme.call();
    }
    
    var JQChartType = JQArgs[0];
    var JQChartTitle = JQArgs[1];

    //var JQChartType = JQArgs[];
    //var JQChartTitle = JQArgs[0];

    $(function () 
    {
        // On document ready, call visualize on the datatable.
        $(document).ready(function () 
        {
            Highcharts.visualize = function (table, options) 
            {
                // the categories
                options.xAxis.categories = [];
                $('tbody th', table).each(function (i) 
                {
                    options.xAxis.categories.push(this.innerHTML);
                });
                
			//$("#Table2 tr:nth-child(" + i + ") td:eq(0)").each(
			//		function() 
			//		{  
			//			$(this).replaceWith('<th>' + $(this).text() + '</th>');  
			//		}
			//	);                
                // the data series
                options.series = [];
                $('tr', table).each(function (i) 
                {
                    var tr = this;
                    $('th, td', tr).each(function (j) 
                    {
                        if (j > 0) 
						{ // skip first column
                            if (i == 0) 
                            { // get the name and init the series
                                options.series[j - 1] = {name: this.innerHTML,data: []};
                            }
                             else 
                            { // add values
								var gval= parseFloat(this.innerHTML)
								if (isNaN(gval))
								{
									options.series[j - 1].data.push(0);
								}
								else
								{
	                                options.series[j - 1].data.push(parseFloat(this.innerHTML));
								}
                            }
                         }
                    });
                });
				var chart = new Highcharts.Chart(options);
             
				// create some buttons to test the resize logic
				var $container = $('#container');
				var origChartWidth =1000, 
				origChartHeight = 500,
				chartWidth = origChartWidth,
				chartHeight = origChartHeight;
				$('<button>Zoom[+]</button>').insertBefore($container).click(function() {chart.setSize(chartWidth *= 1.1, chartHeight *= 1.1);
				});
				$('<button>Zoom[-]</button>').insertBefore($container).click(function() {chart.setSize(chartWidth *= 0.9, chartHeight *= 0.9);
				});
				$('<button>Reset</button>').insertBefore($container).click(function() {chartWidth = origChartWidth; chartHeight = origChartHeight;chart.setSize(origChartWidth, origChartHeight);
				});
            }
            if (JQChartType == 'line') 
            {
                var table = document.getElementById('Chart'),
                options = {
							chart: {renderTo: 'container',type: JQChartType,zoomType: 'xy'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},labels: {rotation: -90,align: 'right'}},
							plotOptions: {JQChartType: {dataLabels: {enabled: true},enableMouseTracking: true}},
							yAxis: {max: 100,title: {text: JQYaxis},tickInterval: JQYIntervel}
						  };
            }
            if (JQChartType == 'column') 
            {
                var table = document.getElementById('Chart'),
                options = {
							chart: {renderTo: 'container',type: JQChartType,zoomType: 'xy'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},labels: {rotation: -90,align: 'right'}},
							plotOptions: {JQChartType: {dataLabels: {enabled: true},enableMouseTracking: true}},
							yAxis: {max: JQYStart,title: {text: JQYaxis},tickInterval: JQYIntervel}
						   };
            }
            if (JQChartType == 'area') 
            {
                var table = document.getElementById('Chart'),
                options = {
							chart: {renderTo: 'container',type: JQChartType,zoomType: 'xy'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},labels: {rotation: -90,align: 'right'}},
							plotOptions: {JQChartType: {dataLabels: {enabled: true},enableMouseTracking: true}},
							yAxis: {max: JQYStart,title: {text: JQYaxis},tickInterval: JQYIntervel}
						  };
            }
            if (JQChartType == 'bar')
			{
				var table = document.getElementById('Chart'),
				options = {
							chart: {renderTo: 'container',type: JQChartType,zoomType: 'xy'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},labels: {rotation: -90,align: 'right'}},
							plotOptions: {JQChartType: {dataLabels: {enabled: true},enableMouseTracking: true}},
							yAxis: {max: JQYStart,tickInterval: JQYIntervel,title: {text: JQYaxis},labels: {overflow: 'justify'}},
							tooltip: {formatter: function() {return '<b>'+ this.series.name +'</b><br/>'+this.y +' '+ this.x.toLowerCase();}}
   						  };
   		    }
   		    if (JQChartType == 'spline')
			{
				var table = document.getElementById('Chart'),
				options = {
							chart: {renderTo: 'container',type: JQChartType,zoomType: 'xy'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},labels: {rotation: -90,align: 'right'}},
							plotOptions: {JQChartType: {dataLabels: {enabled: true},enableMouseTracking: true}},
							yAxis: {max: JQYStart,tickInterval: JQYIntervel,title: {text: JQYaxis},labels: {overflow: 'justify'}},
							tooltip: {formatter: function() {return '<b>'+ this.series.name +'</b><br/>'+this.y +' '+ this.x.toLowerCase();}}
   						  };
   		    }
   		    if (JQChartType == 'columnstack')
            {
				var table = document.getElementById('Chart'),
				options = {
							chart: {renderTo: 'container',type:  'column'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},labels: {rotation: -90,align: 'right'}},
							yAxis: {max: JQYStart,tickInterval: JQYIntervel,title: {text: JQYaxis},labels: {overflow: 'justify'},stackLabels: {enabled: true,rotation: -45,align: 'right',style: {color: 'red'}}},
							//legend: {align: 'right',x: -100,verticalAlign: 'top',y: 20,floating: true,backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColorSolid) || 'white',borderColor: '#CCC',borderWidth: 1,shadow: false},
							tooltip: {formatter: function() {return '<b>'+ this.x +'</b><br/>'+this.series.name +': '+ this.y +'<br/>'+'Total: '+ this.point.stackTotal;}},
							plotOptions: {
										column: {
												stacking: 'normal',
												dataLabels: {
															enabled: true,
															rotation: -90, align: 'right',//verticalAlign: 'middle',
															color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'black'
															}
												}
									}
						  };
			}
            Highcharts.visualize(table, options);
        });
    });
}

function DynamicGraphMisc() 
{
	var TblHead = document.getElementById('Chart').tHead;
	
	var TblBody = document.getElementById('Chart').tBodies[0];
	
    var JQArg = DynamicGraphMisc.arguments;
    
    var tHd = document.getElementById('txtMHead').value;
    var tBd = document.getElementById('txtMBody').value;
    var tFt = document.getElementById('txtMFoot').value;

	tHd=tHd.replace(/Venu1/g, "<");	
	tHd=tHd.replace(/Venu2/g, ">");	

	tBd=tBd.replace(/Venu1/g, "<");	
	tBd=tBd.replace(/Venu2/g, ">");	

	tFt=tFt.replace(/Venu1/g, "<");	
	tFt=tFt.replace(/Venu2/g, ">");	
    
 	TblHead.deleteRow(0);

    var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + tHd + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	for (var i=0, tr; i<tmpTbl.rows.length; i++) 
	{
		var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		TblHead.appendChild(tr);
	} 

    var tmpTable = document.createElement('div');
	tmpTable.innerHTML = '<table><tbody>' + tBd + '</tbody></table>';
	
	var tmpTbl = tmpTable.firstChild;
	
	for (var i=0, tr; i<tmpTbl.rows.length; i++) 
	{
		var tr = tmpTable.getElementsByTagName('tr')[i].cloneNode(true);
		TblBody.appendChild(tr);
	} 
	var tblData = document.getElementById('Chart');
	
	document.getElementById('Table4').style.display="none";
	
    var DrpTheme = document.getElementById('DrpTh').value;
    var JQChartTheme = DrpTheme;
    
    var JQlables = "'DarkBlue'";
    
    var JQYStart = parseFloat(document.getElementById('TxtStartval').value);
    var JQYIntervel = parseFloat(document.getElementById('TxtInterval').value);
    
    var JQXaxis = JQArg[5];
    
    var JQYaxis = JQArg[6];
    
    if (JQChartTheme == 'Normal') 
    {
		//Nothing
    } 
    else 
    {
        JQtheme.call();
    }
    
    var JQChartType = JQArg[1];
    var JQChartTitle = JQArg[0];

    $(function () 
    {
        // On document ready, call visualize on the datatable.
        $(document).ready(function () 
        {
            Highcharts.visualize = function (table, options) 
            {
                // the categories
                options.xAxis.categories = [];
                
				var tblxaxis = document.getElementById('Chart').tBodies[0];
				
				for(var i=0;i<tblxaxis.rows.length;i++)
				{
					options.xAxis.categories.push(tblxaxis.rows[i].cells[0].innerHTML)
				}

				// the data series
                options.series = [];
                $('tr', table).each(function (i) 
                {
					var tr = this;
					$('th, td', tr).each(function (j) 
					{
                        if (j > 0) 
						{ // skip first column
                            if (i == parseInt(JQArg[7])-2) 
							{ // get the name and init the series
                                options.series[j - 1] = {name: this.innerHTML,data: []};
							}
							else 
							{ // add values
								if (i > parseInt(JQArg[7])-2)
								{
									var gval= parseFloat(this.innerHTML)
									if (isNaN(gval))
									//(gval == "NaN")
									{
									options.series[j - 1].data.push(0);
									}
									else
									{
									options.series[j - 1].data.push(parseFloat(this.innerHTML));
									}
								}	
							}
						}
					});
                });
                
				var chart = new Highcharts.Chart(options);
             
				// create some buttons to test the resize logic
				var $container = $('#container');
				var origChartWidth =1000, 
				origChartHeight = 500,
				chartWidth = origChartWidth,
				chartHeight = origChartHeight;
				$('<button>Zoom[+]</button>').insertBefore($container).click(function() {chart.setSize(chartWidth *= 1.1, chartHeight *= 1.1);
				});
				$('<button>Zoom[-]</button>').insertBefore($container).click(function() {chart.setSize(chartWidth *= 0.9, chartHeight *= 0.9);
				});
				$('<button>Reset</button>').insertBefore($container).click(function() {chartWidth = origChartWidth; chartHeight = origChartHeight;chart.setSize(origChartWidth, origChartHeight);
				});
            }
            if (JQChartType == 'line') 
            {
                var table = document.getElementById('Chart'),
                options = {
							chart: {renderTo: 'container',type: JQChartType,zoomType: 'xy'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},
							labels: {rotation: -45,align: 'right'}},
							plotOptions: {JQChartType:{dataLabels: {enabled: true,rotation: -90,align: 'center'},enableMouseTracking: true},
										  series: {dataLabels: {enabled: true,rotation: -90,align: 'center'},enableMouseTracking: true}
										 },		   
							yAxis: {max: JQYStart,title: {text: JQYaxis},tickInterval: JQYIntervel}
						  };
            }
            if (JQChartType == 'column') 
            {
                var table = document.getElementById('Chart'),
                options = {
							chart: {renderTo: 'container',type: JQChartType,zoomType: 'xy'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},
							labels: {rotation: -90,align: 'right'}},
							plotOptions: {JQChartType:{dataLabels: {enabled: true,rotation: -90,align: 'center'},enableMouseTracking: true},
										  series : {dataLabels: {enabled: true,rotation: -90,align: 'center'},enableMouseTracking: true}
										 },
							yAxis: {max: JQYStart,title: {text: JQYaxis},tickInterval: JQYIntervel}
						   };
            }
            if (JQChartType == 'area') 
            {
                var table = document.getElementById('Chart'),
                options = {
							chart: {renderTo: 'container',type: JQChartType,zoomType: 'xy'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},labels: {rotation: -90,align: 'right'}},
							plotOptions: {JQChartType: {dataLabels: {enabled: true},enableMouseTracking: true}},
							yAxis: {max: JQYStart,title: {text: JQYaxis},tickInterval: JQYIntervel}
						  };
            }
            if (JQChartType == 'bar')
			{
				var table = document.getElementById('Chart'),
				options = {
							chart: {renderTo: 'container',type: JQChartType,zoomType: 'xy'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},labels: {rotation: -90,align: 'right'}},
							plotOptions: {JQChartType: {dataLabels: {enabled: true},enableMouseTracking: true}},
							yAxis: {max: JQYStart,tickInterval: JQYIntervel,title: {text: JQYaxis},labels: {overflow: 'justify'}},
							tooltip: {formatter: function() {return '<b>'+ this.series.name +'</b><br/>'+this.y +' '+ this.x.toLowerCase();}}
   						  };
   		    }
   		    if (JQChartType == 'spline')
			{
				var table = document.getElementById('Chart'),
				options = {
							chart: {renderTo: 'container',type: JQChartType,zoomType: 'xy'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},labels: {rotation: -90,align: 'right'}},
							plotOptions: {JQChartType: {dataLabels: {enabled: true},enableMouseTracking: true}},
							yAxis: {max: JQYStart,tickInterval: JQYIntervel,title: {text: JQYaxis},labels: {overflow: 'justify'}},
							tooltip: {formatter: function() {return '<b>'+ this.series.name +'</b><br/>'+this.y +' '+ this.x.toLowerCase();}}
   						  };
   		    }
   		    if (JQChartType == 'columnstack')
            {
				var table = document.getElementById('Chart'),
				options = {
							chart: {renderTo: 'container',type:  'column'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},labels: {rotation: -90,align: 'right'}},
							yAxis: {max: JQYStart,tickInterval: JQYIntervel,title: {text: JQYaxis},labels: {overflow: 'justify'},stackLabels: {enabled: true,rotation: -45,align: 'right',style: {color: 'red'}}},
							//legend: {align: 'right',x: -100,verticalAlign: 'top',y: 20,floating: true,backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColorSolid) || 'white',borderColor: '#CCC',borderWidth: 1,shadow: false},
							tooltip: {formatter: function() {return '<b>'+ this.x +'</b><br/>'+this.series.name +': '+ this.y +'<br/>'+'Total: '+ this.point.stackTotal;}},
							plotOptions: {
										column: {
												stacking: 'normal',
												dataLabels: {
															enabled: true,
															rotation: -90, align: 'right',//verticalAlign: 'middle',
															color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'black'
															}
												}
									}
						  };
			}
            Highcharts.visualize(table, options);
        });
    });
}

function DynamicGraphMiscOnly() 
{

    var JQArg = DynamicGraphMiscOnly.arguments;
	
    var DrpTheme = document.getElementById('DrpTh').value;
    var DrpXAxisAlign = document.getElementById('drpXAxisAlign').value;
    if (DrpXAxisAlign == 'Vertical')
    {
		var XAxisAlign = -90;
    }
    else
    {
		var XAxisAlign = 0;
    }
    var ChkDataLables = document.getElementById('chkDataLables').checked;
        
    var JQChartTheme = DrpTheme;
    var JQlables = "'DarkBlue'";
    var JQYStart = parseFloat(document.getElementById('TxtStartval').value);
    var JQYIntervel = parseFloat(document.getElementById('TxtInterval').value);
    var JQXaxis = JQArg[5];
    var JQYaxis = JQArg[6];
    if (JQChartTheme == 'Normal') 
    {
    //Nothing
    } 
    else 
    {
        JQtheme.call();
    }
    
    var JQChartType = document.getElementById('DrpGraphType').value;
    var JQChartTitle = JQArg[0];

    $(function () 
    {
        // On document ready, call visualize on the datatable.
        $(document).ready(function () 
        {
            Highcharts.visualize = function (table, options) 
            {
                // the categories
                options.xAxis.categories = [];
                
				var tblxaxis = document.getElementById('Chart').tBodies[0];
				
				for(var i=0;i<tblxaxis.rows.length;i++)
				{
					options.xAxis.categories.push(tblxaxis.rows[i].cells[0].innerHTML)
				}
                
                // the data series
                options.series = [];
                $('tr', table).each(function (i) 
                {
                    var tr = this;
                    $('th, td', tr).each(function (j) 
                    {
                        if (j > 0) 
						{ // skip first column
                            if (i == parseInt(JQArg[7])-2) 
							{ // get the name and init the series
                                options.series[j - 1] = {name: this.innerHTML,data: []};
							}
							else 
							{ // add values
								if (i > parseInt(JQArg[7])-2)
								{
									var gval= parseFloat(this.innerHTML)
									if (isNaN(gval))
									{
									options.series[j - 1].data.push(0);
									}
									else
									{
									options.series[j - 1].data.push(parseFloat(this.innerHTML));
									}
								}	
							}
                       }
                    });
                });
                
				var chart = new Highcharts.Chart(options);
             
				// create some buttons to test the resize logic
				var $container = $('#container');
				var origChartWidth =1000, 
				origChartHeight = 500,
				chartWidth = origChartWidth,
				chartHeight = origChartHeight;
				
				$('button').remove();
				
				$('<button>Zoom[+]</button>').insertBefore($container).click(function() {chart.setSize(chartWidth *= 1.1, chartHeight *= 1.1);
				});
				$('<button>Zoom[-]</button>').insertBefore($container).click(function() {chart.setSize(chartWidth *= 0.9, chartHeight *= 0.9);
				});
				$('<button>Reset</button>').insertBefore($container).click(function() {chartWidth = origChartWidth; chartHeight = origChartHeight;chart.setSize(origChartWidth, origChartHeight);
				});

            }
            
            if (JQChartType == 'line') 
            {
                var table = document.getElementById('Chart'),
                options = {
							chart: {renderTo: 'container',type: JQChartType,zoomType: 'xy'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},
							labels: {rotation: XAxisAlign,align: 'right'}},
							plotOptions: {JQChartType:{dataLabels: {enabled: ChkDataLables,rotation: -90,align: 'center'},enableMouseTracking: true},
										  series: {dataLabels: {enabled: ChkDataLables,rotation: -90,align: 'center'},enableMouseTracking: true}
										 },		   
							yAxis: {max: JQYStart,title: {text: JQYaxis},tickInterval: JQYIntervel}
						  };
            }
            if (JQChartType == 'column') 
            {
                var table = document.getElementById('Chart'),
                options = {
							chart: {renderTo: 'container',type: JQChartType,zoomType: 'xy'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},
							labels: {rotation: XAxisAlign,align: 'right'}},
							plotOptions: {JQChartType:{dataLabels: {enabled: ChkDataLables,rotation: -90,align: 'center'},enableMouseTracking: true},
										  series : {dataLabels: {enabled: ChkDataLables,rotation: -90,align: 'center'},enableMouseTracking: true}
										 },
							yAxis: {max: JQYStart,title: {text: JQYaxis},tickInterval: JQYIntervel}
						   };
            }
            if (JQChartType == 'area') 
            {
                var table = document.getElementById('Chart'),
                options = {
							chart: {renderTo: 'container',type: JQChartType,zoomType: 'xy'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},labels: {rotation: XAxisAlign,align: 'right'}},
							plotOptions: {JQChartType:{dataLabels: {enabled: ChkDataLables,rotation: -90,align: 'center'},enableMouseTracking: true},
										  series: {dataLabels: {enabled: ChkDataLables,rotation: -90,align: 'center'},enableMouseTracking: true}
										 },		   
							yAxis: {max: JQYStart,title: {text: JQYaxis},tickInterval: JQYIntervel}
						  };
            }
            if (JQChartType == 'bar')
			{
				var table = document.getElementById('Chart'),
				options = {
							chart: {renderTo: 'container',type: JQChartType,zoomType: 'xy'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},labels: {rotation: XAxisAlign,align: 'right'}},
							plotOptions: {JQChartType:{dataLabels: {enabled: ChkDataLables,rotation: -90,align: 'center'},enableMouseTracking: true},
										  series: {dataLabels: {enabled: ChkDataLables,rotation: -90,align: 'center'},enableMouseTracking: true}
										 },		   
							yAxis: {max: JQYStart,tickInterval: JQYIntervel,title: {text: JQYaxis},labels: {overflow: 'justify'}},
							tooltip: {formatter: function() {return '<b>'+ this.series.name +'</b><br/>'+this.y +' '+ this.x.toLowerCase();}}
   						  };
   		    }
   		    if (JQChartType == 'spline')
			{
				var table = document.getElementById('Chart'),
				options = {
							chart: {renderTo: 'container',type: JQChartType,zoomType: 'xy'},
							title: {text: JQChartTitle},
							xAxis: {title: {text: JQXaxis},labels: {rotation: XAxisAlign,align: 'right'}},
							plotOptions: {JQChartType:{dataLabels: {enabled: ChkDataLables,rotation: -90,align: 'center'},enableMouseTracking: true},
										  series: {dataLabels: {enabled: ChkDataLables,rotation: -90,align: 'center'},enableMouseTracking: true}
										 },		   
							yAxis: {max: JQYStart,tickInterval: JQYIntervel,title: {text: JQYaxis},labels: {overflow: 'justify'}},
							tooltip: {formatter: function() {return '<b>'+ this.series.name +'</b><br/>'+this.y +' '+ this.x.toLowerCase();}}
   						  };
   		    }
            Highcharts.visualize(table, options);
        });
    });
}

//theme

function JQtheme() {
    var Drpval = document.getElementById('DrpTh');
    //var JQArg=JQtheme.arguments;
    if (Drpval.value == 'DarkBlue') {
        Highcharts.theme = {
            colors: ["#DDDF0D", "#55BF3B", "#DF5353", "#7798BF", "#aaeeee", "#ff0066", "#eeaaee", "#55BF3B", "#DF5353", "#7798BF", "#aaeeee"],
            chart: {
                backgroundColor: {
                    linearGradient: [0, 0, 250, 500],
                    stops: [
                        [0, 'rgb(48, 48, 96)'],
                        [1, 'rgb(0, 0, 0)']
                    ]
                },
                borderColor: '#000000',
                borderWidth: 2,
                className: 'dark-container',
                plotBackgroundColor: 'rgba(255, 255, 255, .1)',
                plotBorderColor: '#CCCCCC',
                plotBorderWidth: 1
            },
            title: {
                style: {
                    color: '#C0C0C0',
                    font: 'bold 16px "Trebuchet MS", Verdana, sans-serif'
                }
            },
            subtitle: {
                style: {
                    color: '#666666',
                    font: 'bold 12px "Trebuchet MS", Verdana, sans-serif'
                }
            },
            xAxis: {
                gridLineColor: '#333333',
                gridLineWidth: 1,
                labels: {
                    style: {
                        color: '#A0A0A0'
                    }
                },
                lineColor: '#A0A0A0',
                tickColor: '#A0A0A0',
                title: {
                    style: {
                        color: '#CCC',
                        fontWeight: 'bold',
                        fontSize: '12px',
                        fontFamily: 'Trebuchet MS, Verdana, sans-serif'
                    }
                }
            },
            yAxis: {
                gridLineColor: '#333333',
                labels: {
                    style: {
                        color: '#A0A0A0'
                    }
                },
                lineColor: '#A0A0A0',
                minorTickInterval: null,
                tickColor: '#A0A0A0',
                tickWidth: 1,
                title: {
                    style: {
                        color: '#CCC',
                        fontWeight: 'bold',
                        fontSize: '12px',
                        fontFamily: 'Trebuchet MS, Verdana, sans-serif'
                    }
                }
            },
            tooltip: {
                backgroundColor: 'rgba(0, 0, 0, 0.75)',
                style: {
                    color: '#F0F0F0'
                }
            },
            toolbar: {
                itemStyle: {
                    color: 'silver'
                }
            },
            plotOptions: {
                line: {
                    dataLabels: {
                        color: '#CCC'
                    },
                    marker: {
                        lineColor: '#333'
                    }
                },
                spline: {
                    marker: {
                        lineColor: '#333'
                    }
                },
                scatter: {
                    marker: {
                        lineColor: '#333'
                    }
                },
                candlestick: {
                    lineColor: 'white'
                }
            },
            legend: {
                itemStyle: {
                    font: '9pt Trebuchet MS, Verdana, sans-serif',
                    color: '#A0A0A0'
                },
                itemHoverStyle: {
                    color: '#FFF'
                },
                itemHiddenStyle: {
                    color: '#444'
                }
            },
            credits: {
                style: {
                    color: '#666'
                }
            },
            labels: {
                style: {
                    color: '#CCC'
                }
            },
            navigation: {
                buttonOptions: {
                    backgroundColor: {
                        linearGradient: [0, 0, 0, 20],
                        stops: [
                            [0.4, '#606060'],
                            [0.6, '#333333']
                        ]
                    },
                    borderColor: '#000000',
                    symbolStroke: '#C0C0C0',
                    hoverSymbolStroke: '#FFFFFF'
                }
            },

            exporting: {
                buttons: {
                    exportButton: {
                        symbolFill: '#55BE3B'
                    },
                    printButton: {
                        symbolFill: '#7797BE'
                    }
                }
            },

            // scroll charts
            rangeSelector: {
                buttonTheme: {
                    fill: {
                        linearGradient: [0, 0, 0, 20],
                        stops: [
                            [0.4, '#888'],
                            [0.6, '#555']
                        ]
                    },
                    stroke: '#000000',
                    style: {
                        color: '#CCC',
                        fontWeight: 'bold'
                    },
                    states: {
                        hover: {
                            fill: {
                                linearGradient: [0, 0, 0, 20],
                                stops: [
                                    [0.4, '#BBB'],
                                    [0.6, '#888']
                                ]
                            },
                            stroke: '#000000',
                            style: {
                                color: 'white'
                            }
                        },
                        select: {
                            fill: {
                                linearGradient: [0, 0, 0, 20],
                                stops: [
                                    [0.1, '#000'],
                                    [0.3, '#333']
                                ]
                            },
                            stroke: '#000000',
                            style: {
                                color: 'yellow'
                            }
                        }
                    }
                },
                inputStyle: {
                    backgroundColor: '#333',
                    color: 'silver'
                },
                labelStyle: {
                    color: 'silver'
                }
            },

            navigator: {
                handles: {
                    backgroundColor: '#666',
                    borderColor: '#AAA'
                },
                outlineColor: '#CCC',
                maskFill: 'rgba(16, 16, 16, 0.5)',
                series: {
                    color: '#7798BF',
                    lineColor: '#A6C7ED'
                }
            },

            scrollbar: {
                barBackgroundColor: {
                    linearGradient: [0, 0, 0, 20],
                    stops: [
                        [0.4, '#888'],
                        [0.6, '#555']
                    ]
                },
                barBorderColor: '#CCC',
                buttonArrowColor: '#CCC',
                buttonBackgroundColor: {
                    linearGradient: [0, 0, 0, 20],
                    stops: [
                        [0.4, '#888'],
                        [0.6, '#555']
                    ]
                },
                buttonBorderColor: '#CCC',
                rifleColor: '#FFF',
                trackBackgroundColor: {
                    linearGradient: [0, 0, 0, 10],
                    stops: [
                        [0, '#000'],
                        [1, '#333']
                    ]
                },
                trackBorderColor: '#666'
            },

            // special colors for some of the
            legendBackgroundColor: 'rgba(0, 0, 0, 0.5)',
            legendBackgroundColorSolid: 'rgb(35, 35, 70)',
            dataLabelsColor: '#444',
            textColor: '#C0C0C0',
            maskColor: 'rgba(255,255,255,0.3)'
        };

        // Apply the theme
        var highchartsOptions = Highcharts.setOptions(Highcharts.theme);

    }
    if (Drpval.value == 'DarkGreen') {
        Highcharts.theme = {
            colors: ["#DDDF0D", "#55BF3B", "#DF5353", "#7798BF", "#aaeeee", "#ff0066", "#eeaaee", "#55BF3B", "#DF5353", "#7798BF", "#aaeeee"],
            chart: {
                backgroundColor: {
                    linearGradient: [0, 0, 250, 500],
                    stops: [
                        [0, 'rgb(48, 96, 48)'],
                        [1, 'rgb(0, 0, 0)']
                    ]
                },
                borderColor: '#000000',
                borderWidth: 2,
                className: 'dark-container',
                plotBackgroundColor: 'rgba(255, 255, 255, .1)',
                plotBorderColor: '#CCCCCC',
                plotBorderWidth: 1
            },
            title: {
                style: {
                    color: '#C0C0C0',
                    font: 'bold 16px "Trebuchet MS", Verdana, sans-serif'
                }
            },
            subtitle: {
                style: {
                    color: '#666666',
                    font: 'bold 12px "Trebuchet MS", Verdana, sans-serif'
                }
            },
            xAxis: {
                gridLineColor: '#333333',
                gridLineWidth: 1,
                labels: {
                    style: {
                        color: '#A0A0A0'
                    }
                },
                lineColor: '#A0A0A0',
                tickColor: '#A0A0A0',
                title: {
                    style: {
                        color: '#CCC',
                        fontWeight: 'bold',
                        fontSize: '12px',
                        fontFamily: 'Trebuchet MS, Verdana, sans-serif'

                    }
                }
            },
            yAxis: {
                gridLineColor: '#333333',
                labels: {
                    style: {
                        color: '#A0A0A0'
                    }
                },
                lineColor: '#A0A0A0',
                minorTickInterval: null,
                tickColor: '#A0A0A0',
                tickWidth: 1,
                title: {
                    style: {
                        color: '#CCC',
                        fontWeight: 'bold',
                        fontSize: '12px',
                        fontFamily: 'Trebuchet MS, Verdana, sans-serif'
                    }
                }
            },
            tooltip: {
                backgroundColor: 'rgba(0, 0, 0, 0.75)',
                style: {
                    color: '#F0F0F0'
                }
            },
            toolbar: {
                itemStyle: {
                    color: 'silver'
                }
            },
            plotOptions: {
                line: {
                    dataLabels: {
                        color: '#CCC'
                    },
                    marker: {
                        lineColor: '#333'
                    }
                },
                spline: {
                    marker: {
                        lineColor: '#333'
                    }
                },
                scatter: {
                    marker: {
                        lineColor: '#333'
                    }
                },
                candlestick: {
                    lineColor: 'white'
                }
            },
            legend: {
                itemStyle: {
                    font: '9pt Trebuchet MS, Verdana, sans-serif',
                    color: '#A0A0A0'
                },
                itemHoverStyle: {
                    color: '#FFF'
                },
                itemHiddenStyle: {
                    color: '#444'
                }
            },
            credits: {
                style: {
                    color: '#666'
                }
            },
            labels: {
                style: {
                    color: '#CCC'
                }
            },

            navigation: {
                buttonOptions: {
                    backgroundColor: {
                        linearGradient: [0, 0, 0, 20],
                        stops: [
                            [0.4, '#606060'],
                            [0.6, '#333333']
                        ]
                    },
                    borderColor: '#000000',
                    symbolStroke: '#C0C0C0',
                    hoverSymbolStroke: '#FFFFFF'
                }
            },

            exporting: {
                buttons: {
                    exportButton: {
                        symbolFill: '#55BE3B'
                    },
                    printButton: {
                        symbolFill: '#7797BE'
                    }
                }
            },

            // scroll charts
            rangeSelector: {
                buttonTheme: {
                    fill: {
                        linearGradient: [0, 0, 0, 20],
                        stops: [
                            [0.4, '#888'],
                            [0.6, '#555']
                        ]
                    },
                    stroke: '#000000',
                    style: {
                        color: '#CCC',
                        fontWeight: 'bold'
                    },
                    states: {
                        hover: {
                            fill: {
                                linearGradient: [0, 0, 0, 20],
                                stops: [
                                    [0.4, '#BBB'],
                                    [0.6, '#888']
                                ]
                            },
                            stroke: '#000000',
                            style: {
                                color: 'white'
                            }
                        },
                        select: {
                            fill: {
                                linearGradient: [0, 0, 0, 20],
                                stops: [
                                    [0.1, '#000'],
                                    [0.3, '#333']
                                ]
                            },
                            stroke: '#000000',
                            style: {
                                color: 'yellow'
                            }
                        }
                    }
                },
                inputStyle: {
                    backgroundColor: '#333',
                    color: 'silver'
                },
                labelStyle: {
                    color: 'silver'
                }
            },

            navigator: {
                handles: {
                    backgroundColor: '#666',
                    borderColor: '#AAA'
                },
                outlineColor: '#CCC',
                maskFill: 'rgba(16, 16, 16, 0.5)',
                series: {
                    color: '#7798BF',
                    lineColor: '#A6C7ED'
                }
            },

            scrollbar: {
                barBackgroundColor: {
                    linearGradient: [0, 0, 0, 20],
                    stops: [
                        [0.4, '#888'],
                        [0.6, '#555']
                    ]
                },
                barBorderColor: '#CCC',
                buttonArrowColor: '#CCC',
                buttonBackgroundColor: {
                    linearGradient: [0, 0, 0, 20],
                    stops: [
                        [0.4, '#888'],
                        [0.6, '#555']
                    ]
                },
                buttonBorderColor: '#CCC',
                rifleColor: '#FFF',
                trackBackgroundColor: {
                    linearGradient: [0, 0, 0, 10],
                    stops: [
                        [0, '#000'],
                        [1, '#333']
                    ]
                },
                trackBorderColor: '#666'
            },

            // special colors for some of the
            legendBackgroundColor: 'rgba(0, 0, 0, 0.5)',
            legendBackgroundColorSolid: 'rgb(35, 35, 70)',
            dataLabelsColor: '#444',
            textColor: '#C0C0C0',
            maskColor: 'rgba(255,255,255,0.3)'
        };

        // Apply the theme
        var highchartsOptions = Highcharts.setOptions(Highcharts.theme);

    }
    if (Drpval.value == 'Grey') {
        Highcharts.theme = {
            colors: ["#DDDF0D", "#7798BF", "#55BF3B", "#DF5353", "#aaeeee", "#ff0066", "#eeaaee", "#55BF3B", "#DF5353", "#7798BF", "#aaeeee"],
            chart: {
                backgroundColor: {
                    linearGradient: [0, 0, 0, 400],
                    stops: [
                        [0, 'rgb(96, 96, 96)'],
                        [1, 'rgb(16, 16, 16)']
                    ]
                },
                borderWidth: 0,
                borderRadius: 15,
                plotBackgroundColor: null,
                plotShadow: false,
                plotBorderWidth: 0
            },
            title: {
                style: {
                    color: '#FFF',
                    font: '16px Lucida Grande, Lucida Sans Unicode, Verdana, Arial, Helvetica, sans-serif'
                }
            },
            subtitle: {
                style: {
                    color: '#DDD',
                    font: '12px Lucida Grande, Lucida Sans Unicode, Verdana, Arial, Helvetica, sans-serif'
                }
            },
            xAxis: {
                gridLineWidth: 0,
                lineColor: '#999',
                tickColor: '#999',
                labels: {
                    style: {
                        color: '#999',
                        fontWeight: 'bold'
                    }
                },
                title: {
                    style: {
                        color: '#AAA',
                        font: 'bold 12px Lucida Grande, Lucida Sans Unicode, Verdana, Arial, Helvetica, sans-serif'
                    }
                }
            },
            yAxis: {
                alternateGridColor: null,
                minorTickInterval: null,
                gridLineColor: 'rgba(255, 255, 255, .1)',
                lineWidth: 0,
                tickWidth: 0,
                labels: {
                    style: {
                        color: '#999',
                        fontWeight: 'bold'
                    }
                },
                title: {
                    style: {
                        color: '#AAA',
                        font: 'bold 12px Lucida Grande, Lucida Sans Unicode, Verdana, Arial, Helvetica, sans-serif'
                    }
                }
            },
            legend: {
                itemStyle: {
                    color: '#CCC'
                },
                itemHoverStyle: {
                    color: '#FFF'
                },
                itemHiddenStyle: {
                    color: '#333'
                }
            },
            labels: {
                style: {
                    color: '#CCC'
                }
            },
            tooltip: {
                backgroundColor: {
                    linearGradient: [0, 0, 0, 50],
                    stops: [
                        [0, 'rgba(96, 96, 96, .8)'],
                        [1, 'rgba(16, 16, 16, .8)']
                    ]
                },
                borderWidth: 0,
                style: {
                    color: '#FFF'
                }
            },


            plotOptions: {
                line: {
                    dataLabels: {
                        color: '#CCC'
                    },
                    marker: {
                        lineColor: '#333'
                    }
                },
                spline: {
                    marker: {
                        lineColor: '#333'
                    }
                },
                scatter: {
                    marker: {
                        lineColor: '#333'
                    }
                },
                candlestick: {
                    lineColor: 'white'
                }
            },

            toolbar: {
                itemStyle: {
                    color: '#CCC'
                }
            },

            navigation: {
                buttonOptions: {
                    backgroundColor: {
                        linearGradient: [0, 0, 0, 20],
                        stops: [
                            [0.4, '#606060'],
                            [0.6, '#333333']
                        ]
                    },
                    borderColor: '#000000',
                    symbolStroke: '#C0C0C0',
                    hoverSymbolStroke: '#FFFFFF'
                }
            },

            exporting: {
                buttons: {
                    exportButton: {
                        symbolFill: '#55BE3B'
                    },
                    printButton: {
                        symbolFill: '#7797BE'
                    }
                }
            },

            // scroll charts
            rangeSelector: {
                buttonTheme: {
                    fill: {
                        linearGradient: [0, 0, 0, 20],
                        stops: [
                            [0.4, '#888'],
                            [0.6, '#555']
                        ]
                    },
                    stroke: '#000000',
                    style: {
                        color: '#CCC',
                        fontWeight: 'bold'
                    },
                    states: {
                        hover: {
                            fill: {
                                linearGradient: [0, 0, 0, 20],
                                stops: [
                                    [0.4, '#BBB'],
                                    [0.6, '#888']
                                ]
                            },
                            stroke: '#000000',
                            style: {
                                color: 'white'
                            }
                        },
                        select: {
                            fill: {
                                linearGradient: [0, 0, 0, 20],
                                stops: [
                                    [0.1, '#000'],
                                    [0.3, '#333']
                                ]
                            },
                            stroke: '#000000',
                            style: {
                                color: 'yellow'
                            }
                        }
                    }
                },
                inputStyle: {
                    backgroundColor: '#333',
                    color: 'silver'
                },
                labelStyle: {
                    color: 'silver'
                }
            },

            navigator: {
                handles: {
                    backgroundColor: '#666',
                    borderColor: '#AAA'
                },
                outlineColor: '#CCC',
                maskFill: 'rgba(16, 16, 16, 0.5)',
                series: {
                    color: '#7798BF',
                    lineColor: '#A6C7ED'
                }
            },

            scrollbar: {
                barBackgroundColor: {
                    linearGradient: [0, 0, 0, 20],
                    stops: [
                        [0.4, '#888'],
                        [0.6, '#555']
                    ]
                },
                barBorderColor: '#CCC',
                buttonArrowColor: '#CCC',
                buttonBackgroundColor: {
                    linearGradient: [0, 0, 0, 20],
                    stops: [
                        [0.4, '#888'],
                        [0.6, '#555']
                    ]
                },
                buttonBorderColor: '#CCC',
                rifleColor: '#FFF',
                trackBackgroundColor: {
                    linearGradient: [0, 0, 0, 10],
                    stops: [
                        [0, '#000'],
                        [1, '#333']
                    ]
                },
                trackBorderColor: '#666'
            },

            // special colors for some of the demo examples
            legendBackgroundColor: 'rgba(48, 48, 48, 0.8)',
            legendBackgroundColorSolid: 'rgb(70, 70, 70)',
            dataLabelsColor: '#444',
            textColor: '#E0E0E0',
            maskColor: 'rgba(255,255,255,0.3)'
        };

        // Apply the theme
        var highchartsOptions = Highcharts.setOptions(Highcharts.theme);

    }
    if (Drpval.value == 'Grid') {
        Highcharts.theme = {
            colors: ['#058DC7', '#50B432', '#ED561B', '#DDDF00', '#24CBE5', '#64E572', '#FF9655', '#FFF263', '#6AF9C4'],
            chart: {
                backgroundColor: {
                    linearGradient: [0, 0, 500, 500],
                    stops: [
                        [0, 'rgb(255, 255, 255)'],
                        [1, 'rgb(240, 240, 255)']
                    ]
                },
                borderWidth: 2,
                plotBackgroundColor: 'rgba(255, 255, 255, .9)',
                plotShadow: true,
                plotBorderWidth: 1
            },
            title: {
                style: {
                    color: '#000',
                    font: 'bold 16px "Trebuchet MS", Verdana, sans-serif'
                }
            },
            subtitle: {
                style: {
                    color: '#666666',
                    font: 'bold 12px "Trebuchet MS", Verdana, sans-serif'
                }
            },
            xAxis: {
                gridLineWidth: 1,
                lineColor: '#000',
                tickColor: '#000',
                labels: {
                    style: {
                        color: '#000',
                        font: '11px Trebuchet MS, Verdana, sans-serif'
                    }
                },
                title: {
                    style: {
                        color: '#333',
                        fontWeight: 'bold',
                        fontSize: '12px',
                        fontFamily: 'Trebuchet MS, Verdana, sans-serif'

                    }
                }
            },
            yAxis: {
                minorTickInterval: 'auto',
                lineColor: '#000',
                lineWidth: 1,
                tickWidth: 1,
                tickColor: '#000',
                labels: {
                    style: {
                        color: '#000',
                        font: '11px Trebuchet MS, Verdana, sans-serif'
                    }
                },
                title: {
                    style: {
                        color: '#333',
                        fontWeight: 'bold',
                        fontSize: '12px',
                        fontFamily: 'Trebuchet MS, Verdana, sans-serif'
                    }
                }
            },
            legend: {
                itemStyle: {
                    font: '9pt Trebuchet MS, Verdana, sans-serif',
                    color: 'black'

                },
                itemHoverStyle: {
                    color: '#039'
                },
                itemHiddenStyle: {
                    color: 'gray'
                }
            },
            labels: {
                style: {
                    color: '#99b'
                }
            }
        };

        // Apply the theme
        var highchartsOptions = Highcharts.setOptions(Highcharts.theme);

    }
    if (Drpval.value == 'Skies') {
        Highcharts.theme = {
            colors: ["#514F78", "#42A07B", "#9B5E4A", "#72727F", "#1F949A", "#82914E", "#86777F", "#42A07B"],
            chart: {
                className: 'skies',
                borderWidth: 0,
                plotShadow: true,
                plotBackgroundImage: '../../Images/NewImages/skies.jpg',
                plotBackgroundColor: {
                    linearGradient: [0, 0, 250, 500],
                    stops: [
                        [0, 'rgba(255, 255, 255, 1)'],
                        [1, 'rgba(255, 255, 255, 0)']
                    ]
                },
                plotBorderWidth: 1
            },
            title: {
                style: {
                    color: '#3E576F',
                    font: '16px Lucida Grande, Lucida Sans Unicode, Verdana, Arial, Helvetica, sans-serif'
                }
            },
            subtitle: {
                style: {
                    color: '#6D869F',
                    font: '12px Lucida Grande, Lucida Sans Unicode, Verdana, Arial, Helvetica, sans-serif'
                }
            },
            xAxis: {
                gridLineWidth: 0,
                lineColor: '#C0D0E0',
                tickColor: '#C0D0E0',
                labels: {
                    style: {
                        color: '#666',
                        fontWeight: 'bold'
                    }
                },
                title: {
                    style: {
                        color: '#666',
                        font: '12px Lucida Grande, Lucida Sans Unicode, Verdana, Arial, Helvetica, sans-serif'
                    }
                }
            },
            yAxis: {
                alternateGridColor: 'rgba(255, 255, 255, .5)',
                lineColor: '#C0D0E0',
                tickColor: '#C0D0E0',
                tickWidth: 1,
                labels: {
                    style: {
                        color: '#666',
                        fontWeight: 'bold'
                    }
                },
                title: {
                    style: {
                        color: '#666',
                        font: '12px Lucida Grande, Lucida Sans Unicode, Verdana, Arial, Helvetica, sans-serif'
                    }
                }
            },
            legend: {
                itemStyle: {
                    font: '9pt Trebuchet MS, Verdana, sans-serif',
                    color: '#3E576F'
                },
                itemHoverStyle: {
                    color: 'black'
                },
                itemHiddenStyle: {
                    color: 'silver'
                }
            },
            labels: {
                style: {
                    color: '#3E576F'
                }
            }
        };

        // Apply the theme
        var highchartsOptions = Highcharts.setOptions(Highcharts.theme);

    }
}

