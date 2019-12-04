$(document).ready(function () {
    (function () {
        function GameManager(connection) {
            var hub = connection.hub;
            var gameHub = connection.gameHub;

            //connection.on("SendMessage", function (message) {
            //    $(generalMessagesSelector).append(`<p>${message}</p>`);
            //});
            var fieldKey = "gameField";
            var usernameKey = "username";
            var gameContainerSelector = "#game";
            var logoffButtonSelector = "#logoff";
            var logonButtonSelector = "#logon";
            var inputUsernameSelector = "#inputUsername";
            var enterGameButtonSelector = "#enterGame";
            var initializeFieldSelector = "#initialize-field";
            var addShipSelector = "#add-ship";
            var generalMessagesSelector = "#general-messages";
            var shipsTableBodySelector = "#ships-table-body";
            var shootsTableBodySelector = "#shoots-table-body";
            var repairsTableBodySelector = "#repairs-table-body";
            var initializeFieldButtonSelector = "#initializeFieldBtn";
            var addShipButtonSelector = "#addShipBtn";
            var readyButtonSelector = "#readyBtn";
            var shootButtonSelector = "#getShoot";
            var repairButtonSelector = "#getRepair";
            var shootSelector = "#shoot";
            var repairSelector = "#repair";
            var shipsSelector = "#ships";

            var resolveElements = function() {
                var username = localStorage.getItem(usernameKey);
                if (!username) {
                    $(logonButtonSelector).show();
                    $(logoffButtonSelector).hide();
                    $(gameContainerSelector).hide();
                } else {
                    $(logonButtonSelector).hide();
                    $(logoffButtonSelector).show();
                    $(gameContainerSelector).show();
                }

                var field = localStorage.getItem(fieldKey);
                if (!field) {
                    $(initializeFieldSelector).show();
                } else {
                    $(initializeFieldSelector).hide();
                }
            };

            resolveElements();

            var clearUsername = function () {
                localStorage.removeItem(usernameKey);
            };

            var getUsername = function () {
                var username = localStorage.getItem(usernameKey);
                return username;
            };

            var setUsername = function (username) {
                localStorage.setItem(usernameKey, username);
            };

            var disconnect = function () {
                hub.stop();
            };

            var connect = function () {
                gameHub.client.sendMessage = function (message) {
                    $(generalMessagesSelector).append(`<p>${message}</p>`);
                };

                //gameHub.client.showGuess = function (show) {
                //    toggleGuess(show);
                //};

                gameHub.client.initializeField = function (field) {

                    console.log(field)
                    $(initializeFieldSelector).hide();
                    $(addShipSelector).show();
                    $(shipsSelector).show();
                };

                gameHub.client.startGame = function () {
                    $(addShipSelector).hide();
                    $(shipsSelector).hide();
                    $(shootSelector).show();
                    $(repairSelector).show();
                };

                hub.start().done(function () {
                    var username = getUsername();
                    if (username) {
                        gameHub.server.connect(username);
                    }
                });
            };

            connect();

            $(logoffButtonSelector).click(function () {
                disconnect();
                clearUsername();
                resolveElements();
            });

            $(enterGameButtonSelector).click(function () {
                var username = $(inputUsernameSelector).val();
                setUsername(username);
                resolveElements();
                connect();
            });

            $(addShipButtonSelector).click(function () {
                let ship = {
                    x: $(`${addShipSelector} #X`).val(),
                    y: $(`${addShipSelector} #Y`).val(),
                    length: $(`${addShipSelector} #Length`).val(),
                    range: $(`${addShipSelector} #Range`).val(),
                    speed: $(`${addShipSelector} #Speed`).val(),
                    type: $(`${addShipSelector} #Type`).val(),
                    direction: $(`${addShipSelector} #Direction`).val(),
                    // fieldId: localStorage.getItem(fieldKey)
                };

                gameHub.server.addShip(ship);
            });

            $(shootButtonSelector).click(function () {
                let shoot = {
                    x: $(`${shootSelector} #X`).val(),
                    y: $(`${shootSelector} #Y`).val()
                };

                gameHub.server.getShoot(shoot);
            });

            $(repairButtonSelector).click(function () {
                let repair = {
                    x: $(`${repairSelector} #X`).val(),
                    y: $(`${repairSelector} #Y`).val()
                };

                gameHub.server.getRepair(repair);
            });

            $(readyButtonSelector).click(function () {
                gameHub.invoke("Ready");
            });

            $(initializeFieldButtonSelector).click(function () {
                gameHub.invoke("InitMap");
            });

            let ships = [];

            gameHub.on("AddShip", function (ship) {
                ships.push(JSON.parse(ship));
                console.log(ship)
                printShips();
            });

            var printShips = function () {
                $(shipsTableBodySelector).children().remove();

                for (let ship of ships) {
                    $(shipsTableBodySelector).append(
                        `<tr>
                        <td>${ship.Id}</td>
                        <td>${ship.X}</td>
                        <td>${ship.Y}</td>
                        <td>${ship.Length}</td>
                        <td>${ship.Speed}</td>
                        <td>${ship.Range}</td>
                        <td>${ship.Type}</td>
                        <td>${ship.Direction}</td>
                     </tr>`
                    );
                }
            };

            let shoots = [];

            gameHub.on("GetShoot", function(shoot) {
                shoots.push(JSON.parse(shoot));
                console.log(shoot)
                printShoots();
            });

            var printShoots = function() {
                $(shootsTableBodySelector).children().remove();
                for (let shoot of shoots) {
                    $(shootsTableBodySelector).append(
                        `<tr>
                        <td>${shoot.X}</td>
                        <td>${shoot.Y}</td>
                     </tr>`
                    );
                }
            };

            let repairs = [];

            gameHub.on("GetRepair", function (repair) {
                repairs.push(JSON.parse(repair));
                console.log(repair)
                printRepairs();
            });

            var printRepairs = function () {
                $(repairsTableBodySelector).children().remove();
                for (let repair of repairs) {
                    $(repairsTableBodySelector).append(
                        `<tr>
                        <td>${repair.X}</td>
                        <td>${repair.Y}</td>
                     </tr>`
                    );
                }
            };

  
        }
        this.GameManager = new GameManager($.connection);
    })();
});