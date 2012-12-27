$(document).ready(function () {
    var messages = $.connection.messageHub;
    var mySound = new buzz.sound("Content/sound/ding.wav");

    messages.client.updateMedic = function (medic) {
        console.log(medic);
        $("#firstName").html(medic.nameFull).effect("bounce", { times:3 }, 300);
        $("#lastName").html(medic.nameShort).effect("bounce", { times: 3 }, 300);
        mySound.play();
    }

    $.connection.hub.start().done(function () {
        messages.server.subToMedic($("#medicId").val());
    });

});