var messages = $.connection.messageHub;

messages.client.addMessage = function (message) {
    console.log(message);
    $("#messageOutput").val($("#messageOutput").val() + '\n' + message);
}

$.connection.hub.start().done(function () { messages.server.send("hello test") });
