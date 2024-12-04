const connection = new signalR.HubConnectionBuilder()
    .withUrl("/notificationHub")
    .build();

connection.on("ReceiveNotification", function(message, id) {
    Toastify({
        text: message,
        duration: 5000,
        newWindow: true,
        gravity: "bottom",
        position: "left",
        offset: {
            x: 20,
            y: 100
        },
        backgroundColor: "linear-gradient(to right, #00b09b, #96c93d)",
        stopOnFocus: true,
        onClick: function () {
            window.location.href = '/Todos/Details?id=' + id;
        }
    }).showToast();
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});