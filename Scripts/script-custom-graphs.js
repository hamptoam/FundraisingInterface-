// Load the Visualization API and the piechart package.  
google.load('visualization', '1.0', { 'packages': ['corechart'] });

// Set a callback to run when the Google Visualization API is loaded.  
$(document).ready(function () {
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/GetData',
            success:
                function (response) {
                    // Set chart options  
                    var options =
                    {
                        width: 1100,
                        height: 900,
                        sliceVisibilityThreshold: 0,
                        legend: { position: "top", alignment: "end" },
                        chartArea: { left: 370, top: 50, height: "90%" },
                        hAxis:
                        {
                            slantedText: true,
                            slantedTextAngle: 18
                        },
                        bar: { groupWidth: "50%" },
                    };

                    // Draw.  
                    drawGraph(response, options, 'graphId');
                }
        });
});

// Callback that creates and populates a data table,  
// instantiates the pie chart, passes in the data and  
// draws it.  
function drawGraph(dataValues, options, elementId) {
    // Initialization.  
    var data = new google.visualization.DataTable();

    // Setting.  
    data.addColumn('number', 'DailyFunds');
    data.addColumn('number', 'WeeklyFunds');
    data.addColumn('number', "Monthly Funds');
    data.addColumn('number', 'QuarterlyFunds');
    data.addColumn('number', 'YearlyFunds');

    // Processing...  
    for (var i = 0; i < dataValues.length; i++) {
        // Setting.  
        data.addRow([dataValues[i].DailyFunds, dataValues[i].WeeklyFunds, dataValues[i].MonthlyFunds, dataValues[i].QuarterlyFunds, dataValues[i).YearlyFunds;
    }

    // Setting label.  
    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
        {
            calc: "stringify",
            sourceColumn: 1,
            type: "string",
            role: "annotation"
        },
        2,
        {
            calc: "stringify",
            sourceColumn: 2,
            type: "string",
            role: "annotation"
        }
    ]);

    // Instantiate and draw our chart, passing in some options.  
    var chart = new google.visualization.BarChart(document.getElementById(elementId));

    // Draw chart.  
    chart.draw(view, options);
} 