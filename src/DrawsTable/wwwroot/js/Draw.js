$(document).ready(function () {
    var ajaxFunction = draw.GetData();
    draw.Build(ajaxFunction);
   
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

    Build: function (ajaxFunction)
    {
        var _columnProps = [];
        var _columnDefs = [];
        var _columnTargets = [];

        function CreateTableHeader (columns){
            var tableHeaders= '';

            $.each(columns, function (i, val) {
                tableHeaders += '<th>' + val.name + '</th>';
                //tableHeaders += '<th></th>';
                var columnWidth;
                if(val.type == "1")
                    columnWidth = "200px";
                else
                    columnWidth = "50px";
                _columnProps.push({
                    data: "cells." + i + ".style",
                    width: columnWidth
                });
            });
            //_columnDefs.push({
            //    width: "200px", "targets": [0, 3, 6],
            //});
            $("#drawTableRowHeader").append(tableHeaders);
        }

        function SetRowCellStyle(row, data, index) {
            $.each(data.cells, function (i, val) {
                var rowCell = val;
                if (rowCell.style == "1")
                    $(row).find("td").eq(i).addClass('first_player');
                else if (rowCell.style == "2")
                    $(row).find("td").eq(i).addClass('second_player');
                else if (rowCell.style == "3")
                    $(row).find("td").eq(i).addClass('odd_corner_connector');
                else if (rowCell.style == "4")
                    $(row).find("td").eq(i).addClass('even_corner_connector');
                else if (rowCell.style == "5")
                    $(row).find("td").eq(i).addClass('vertical_connector');
                else if (rowCell.style == "6")
                    $(row).find("td").eq(i).addClass('horizontal_connector');
            });
        }

        function LoadTable(rows) {
            $('#drawTable').DataTable({
                data: rows,
                paging: false,
                ordering: false,
                searching: false,
                info: false,
                autoWidth: false,
                //columnDefs: _columnDefs,
                columns: _columnProps,
                rowCallback: function( row, data, index ) {
                        SetRowCellStyle(row, data, index)
                    }
            });
        }

        ajaxFunction.done(function (data) {
            CreateTableHeader(data.columns);
            LoadTable(data.rows);
        });

        ajaxFunction.fail(function (error) {
            //do stuff when error
            alert(error);
        });
    }


}