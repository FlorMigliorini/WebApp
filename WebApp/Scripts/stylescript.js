$(function () {

    function DisplayResult1(call, data) {
        $('#result').append("<strong>" + call + "<strong>" + "<br/>");

        $.each(data, function (i, item) {

            $('#result').append(JSON.stringify(item));
            $('#result').append("<br/>");
        });
    };

    function DisplayResult2(call, data) {
        $('#result').append("<strong>" + call + "<strong>" + "<br/>");

        $('#result').append(JSON.stringify(item));
        $('#result').append("<br/>");
    };

    var serviceUrl = 'https://localhost:44392/api';
    $('#GetAll').on('click', function () {
        alert("Hello");
        $.ajax({
            url: serviceUrl + '/AssignmentsAPI',
            method: 'GET',
            success: function (data) {
                DisplayResult1("Get All:", data);
            }
        });
    });
   
});