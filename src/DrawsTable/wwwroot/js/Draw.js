$(document).ready(function () {
    var drawDataFunction = draw.GetData();
    draw.Build(drawDataFunction);
});

var draw = {

    GetData: function () {
        var serviceURL = '/Draw/Get';
        return $.ajax({
            type: "GET",
            url: serviceURL,
            data: param = "",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        });
    },

    Build: function (drawDataFunction)
    {
        var _columnProps = [];
        var _matches;

        function CreateTableHeader (columns){
            var tableHeaders= '';

            $.each(columns, function (i, val) {
                tableHeaders += '<th>' + val.name + '</th>';                
                var columnWidth;
                if(val.type == "1")
                    columnWidth = "200px";
                else
                    columnWidth = "50px";
                _columnProps.push({
                    data: "cells." + i + ".matchNumber",
                    width: columnWidth
                });
            });
            $("#drawTableRowHeader").append(tableHeaders);
        }

        function SetRowCellValueAndStyle(row, data, index) {
            $.each(data.cells, function (i, val) {
                var rowCell = val;
                var td = $(row).find("td").eq(i);
                // Set cell Match Player
                if (rowCell.matchNumber != null &&  _matches != null)
                {
                    var match = _matches[rowCell.matchNumber - 1];
                    var opponentName; 
                    if (match != null)
                    {
                        switch (rowCell.style) {
                            case 1:
                                opponentName = match.opponent1.name
                                break;
                            case 2:
                                opponentName = match.opponent2.name
                                break;
                            default:
                                opponentName = "";
                        }
                    }
                    td.text(opponentName);
                }
                // Set cell style
                if (rowCell.style == "1")
                    td.addClass('first_player');
                else if (rowCell.style == "2")
                    td.addClass('second_player');
                else if (rowCell.style == "3")
                    td.addClass('odd_corner_connector');
                else if (rowCell.style == "4")
                    td.addClass('even_corner_connector');
                else if (rowCell.style == "5")
                    td.addClass('vertical_connector');
                else if (rowCell.style == "6")
                    td.addClass('horizontal_connector');


            });
        }

        function LoadTable(rows, matches) {
            _matches = matches;
            $('#drawTable').DataTable({
                data: rows,
                paging: false,
                ordering: false,
                searching: false,
                info: false,
                autoWidth: false,
                columns: _columnProps,
                rowCallback: function (row, data, index) {
                    SetRowCellValueAndStyle(row, data, index);
                    }
            });
        }


        drawDataFunction.done(function (data) {
            CreateTableHeader(data.columns);
            LoadTable(data.rows, data.matches);
        });

        drawDataFunction.fail(function (error) {
            //do stuff when error
            alert(error);
        });



        
    }


}