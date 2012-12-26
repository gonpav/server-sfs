$(document).ready(function () {
    var messages = $.connection.messageHub;

    messages.client.updateMedic = function (medic) {
        console.log(medic);
        $("#firstName").html(medic.firstName);
        $("#lastName").html(medic.lastName);
    }

    $.connection.hub.start().done(function () {
        messages.server.subToMedic($("#medicId").val());
    });

});