// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.
function displayAllTaskLogs() {
    $(".tableBody").empty(),
        $.ajax({
            method: "GET",
            url: "https://localhost:44385/api/taskLog",
            dataType: "json",
            success: function (data) {
                $(data).each(function (index, item) {
                    $(".tableBody").append(
                        "<tr>" + "<td>" + item.Title + "</td>" +
                        "<td>" + item.Genre + "</td>" +
                        "<td>" + item.DirectorName + "</td>" +
                        "</tr>"
                    )
                })
            }
        });
}

function postTaskLog() {
    var newMovieTitle = $("#title")[0].value;
    var newGenre = $("#genre")[0].value;
    var newDirectorName = $("#directorName")[0].value;
    var data = { Title: newMovieTitle, Genre: newGenre, DirectorName: newDirectorName, MovieImage: null };
    $.post("https://localhost:44385/api/taskLog", data, function (response) {
        console.log(response);
    }, "json");
}

function searchTaskLog() {
    $(".tableBody").empty(),
        $.ajax({
            method: "GET",
            url: "https://localhost:44385/api/taskLog",
            dataType: "json",
            success: function (data) {
                $(data).each(function (index, item) {
                    if ($("#search")[0].value == "") {
                        $(".tableBody").append(
                            "<tr>" + "<td>" + item.Title + "</td>" +
                            "<td>" + item.Genre + "</td>" +
                            "<td>" + item.DirectorName + "</td>" +
                            "</tr>"
                        )
                    }
                    if ($("#search")[0].value == item.Title || $("#search")[0].value == item.Genre || $("#search")[0].value == item.DirectorName) {
                        $(".tableBody").append(
                            "<tr>" + "<td>" + item.Title + "</td>" +
                            "<td>" + item.Genre + "</td>" +
                            "<td>" + item.DirectorName + "</td>" +
                            "</tr>"
                        )
                    }
                }
                )
            }
        })
}

function displayPieChartData() {
        .ajax({
    method: GET
        // ....
        .success: function(data) {
            var chart = new CanvasJS.Chart("chartContainer", {
                animationEnabled: true,
                title: {
                    text: "Desktop Search Engine Market Share - 2016"
                },
                data: [{
                    type: "pie",
                    startAngle: 240,
                    yValueFormatString: "##0.00\"%\"",
                    indexLabel: "{label} {y}",
                    dataPoints: [
                        { y: <% MeetingMinutesTotal %>, label: "Google" },
                        { y: data.meetingMinutesTotal, label: data.meetingMinutesLabel },
                        { y: 7.06, label: "Baidu" },
                        { y: 4.91, label: "Yahoo" },
                        { y: 1.26, label: "Others" }
                    ]
                }]
            });
            chart.render();

        }
}
            };

$('#assigned').on("change", function () {
    var item = $("#assigned input:selected").text();

    $.post("/Create/SetAssigned",
        {
            data: item
        });
});