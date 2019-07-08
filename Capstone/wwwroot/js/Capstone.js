function displayTaskEntryTypeTime() {
    $(".tableBody").empty(),
        $.ajax({
            method: "GET",
            url: "https://localhost:44385/api/values",
            dataType: "json",
            success: function (data) {
                $(data).each(function (index, item) {
                    $(".tableBody").append(
                        "<tr>" + "<td>" + item.TaskType + "</td>" +
                        "<td>" + item.TaskTime + "</td>" + "</tr>"
                    )
                })
            }
        });
}

function searchTaskLogs() {
    $(".tableBody").empty(),
        $.ajax({
            method: "GET",
            url: "https://localhost:44385/api/values",
            dataType: "json",
            success: function (data) {
                $(data).each(function (index, item) {
                    if ($("#search")[0].value == "") {
                        $(".tableBody").append(
                            "<tr>" + "<td>" + item.LogDate + "</td>" + "</tr>"
                        )
                    }
                }
                )
            }
        })
}

// function postMovie() {
//     var newMovieTitle = $("#title")[0].value;
//     var newGenre = $("#genre")[0].value;
//     var newDirectorName = $("#directorName")[0].value;
//     var data = { Title: newMovieTitle, Genre: newGenre, DirectorName: newDirectorName, MovieImage: null };
//     $.post("https://localhost:44365/api/movies", data, function (response) {
//         console.log(response);
//     }, "json");
// }