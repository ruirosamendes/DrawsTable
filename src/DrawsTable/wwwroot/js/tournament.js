$(document).ready(function () {
    var ajaxPlayers = tournament.GetPlayers();
    tournament.Build(ajaxPlayers);
});

var tournament = {

    GetPlayers: function () {
        var serviceURL = '/Tournament/GetPlayers';
        return $.ajax({
            type: "GET",
            url: serviceURL,
            data: param = "",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        });
    },

    GetMatches: function () {
        var serviceURL = '/Tournament/GetMatches';
        return $.ajax({
            type: "GET",
            url: serviceURL,
            data: param = "",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        });
    },

    Build: function (ajaxPlayers)
    {
        function LoadTable(players) {
            $('#playersTable').DataTable({
                data: players,
                paging: false,
                ordering: false,
                searching: false,
                info: false,
                columns: [
                    { data: 'rank' },
                    { data: 'name' },
                    { data: 'team' }
                    ]
            });
        }

        ajaxPlayers.done(function (data) {
            LoadTable(data);
        });

        ajaxPlayers.fail(function (error) {
            //do stuff when error
            alert(error);
        });
    }


}