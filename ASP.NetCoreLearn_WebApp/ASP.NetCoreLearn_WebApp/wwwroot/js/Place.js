var dTable;
$(document).ready(function () {
    dTable = $('#myTable').DataTable({
        "ajax": {
          "url":"/Admin/Place/AllPlaces"
        },
            "columns": [
                { "data": "placeName" },
                { "data": "placeDescription" },
                { "data": "placeVisitRate" }
               
            ]
    });
});