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
        var _columnsProps = [];

        function CreateTableHeader (columns){
            var tableHeaders;

            $.each(columns, function (i, val) {
                tableHeaders += "<th>" + val.name + "</th>";
                _columnsProps.push({ data : "cells." + i +  ".style" })
            });
            $("#drawTableRowHeader").append(tableHeaders);
        }

        function SetRowCellStyle(row, data, index) {
            $.each(data.cells, function (i, val) {
                var rowCell = val;
                if (rowCell.style == "1")
                    $(row).find("td").eq(i).addClass('matchFirstPlayer');
                else if (rowCell.style == "2")
                    $(row).find("td").eq(i).addClass('matchSecondPlayer');
            });
        }

        function LoadTable(rows) {
            $('#drawTable').DataTable({
                data: rows,
                paging: false,
                ordering: false,
                searching: false,
                info: false,
                columns: _columnsProps,
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