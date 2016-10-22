
$(document).ready(function () {
    var serviceURL = '/Draw/Get';

    $('#drawTable').DataTable({
        ajax: {
            type: "GET",
            url: serviceURL,
            dataSrc: 'rows',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        },
        paging: false,
        ordering: false,
        columns: [
            { data: "cells.0.style" },
            { data: "cells.1.style" },
            { data: "cells.2.style" },
            { data: "cells.3.style" },
            { data: "cells.4.style" },
            { data: "cells.5.style" },
            { data: "cells.6.style" }
        ]
    } );
});

var draw = {
    Show: function (e) {
        
    }

}