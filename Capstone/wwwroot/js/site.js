// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.
//function displayAllTasks() {
//    $(".tableBody").empty(),
//        $.ajax({
//            method: "GET",
//            url: "https://localhost:44365/api/movies",
//            dataType: "json",
//            success: function (data) {
//                $(data).each(function (index, item) {
//                    $(".tableBody").append(
//                        "<tr>" + "<td>" + item.Title + "</td>" +
//                        "<td>" + item.Genre + "</td>" +
//                        "<td>" + item.DirectorName + "</td>" +
//                        "</tr>"
//                    )
//                })
//            }
//        });
//}

//function postTasks() {
//    var newMovieTitle = $("#title")[0].value;
//    var newGenre = $("#genre")[0].value;
//    var newDirectorName = $("#directorName")[0].value;
//    var data = { Title: newMovieTitle, Genre: newGenre, DirectorName: newDirectorName, MovieImage: null };
//    $.post("https://localhost:44365/api/movies", data, function (response) {
//        console.log(response);
//    }, "json");
//}

//function searchTasks() {
//    $(".tableBody").empty(),
//        $.ajax({
//            method: "GET",
//            url: "https://localhost:44365/api/movies",
//            dataType: "json",
//            success: function (data) {
//                $(data).each(function (index, item) {
//                    if ($("#search")[0].value == "") {
//                        $(".tableBody").append(
//                            "<tr>" + "<td>" + item.Title + "</td>" +
//                            "<td>" + item.Genre + "</td>" +
//                            "<td>" + item.DirectorName + "</td>" +
//                            "</tr>"
//                        )
//                    }
//                    if ($("#search")[0].value == item.Title || $("#search")[0].value == item.Genre || $("#search")[0].value == item.DirectorName) {
//                        $(".tableBody").append(
//                            "<tr>" + "<td>" + item.Title + "</td>" +
//                            "<td>" + item.Genre + "</td>" +
//                            "<td>" + item.DirectorName + "</td>" +
//                            "</tr>"
//                        )
//                    }
//                }
//                )
//            }
//        })
//}
