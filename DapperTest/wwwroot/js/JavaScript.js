var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationHub").build();

connection.start().then(function () {

}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("ClientSideFunction", function (message) {
    $('#ProductDescription').text(message);
    $('#exampleModal').modal('show');
});

$('#clientButton').click(function (event) {

    connection.invoke("NotifyClients").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});