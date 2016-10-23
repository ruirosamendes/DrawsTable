
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

        function LoadTable(rows) {
            $('#drawTable').DataTable({
                data: rows,
                paging: false,
                ordering: false,
                searching: false,
                columns: _columnsProps
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