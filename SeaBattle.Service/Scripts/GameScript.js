$(document).ready(function () {
    (function () {
        var connect = function () {
            gameHub.client.message = function (message) {
                $(logContainerSelector).append("<li>" + message + "</li>");
            };
        }
    })();
});