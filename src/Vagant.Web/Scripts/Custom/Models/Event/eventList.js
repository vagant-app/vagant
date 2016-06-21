var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.EventList = function () {
    var self = this;

    //#region Fields
    var player = null;
    //#endregion

    //#region Properties
    self.isBusy = ko.observable();

    self.items = ko.observableArray([]);
    //#endregion

    //#region Private functions
    var markEventBeingPlayed = function (itemModel) {
        if (itemModel) {
            itemModel.updatePlayerStatus(true);
        }
    };

    var markAllEventsStopped = function () {
        ko.utils.arrayForEach(self.items(), function (itemModel) {
            if (itemModel) {
                itemModel.updatePlayerStatus(false);
            }
        });
    };
    //#endregion

    //#region Public functions
    self.loadData = function (events) {
        self.items.removeAll();
        if (events) {
            ko.utils.arrayForEach(events, function (eventObject) {
                var newItem = new vagantApp.event.EventListItem();
                newItem.loadData(eventObject);
                self.items.push(newItem);
            });
        }
    };

    self.setBusy = function () {
        self.isBusy(true);
    };

    self.setReady = function () {
        self.isBusy(false);
    };

    self.setPlayerReferrence = function (playerInstance) {
        player = playerInstance;
    };

    self.play = function (itemModel) {
        if (player) {
            markAllEventsStopped();
            player.load(itemModel.audioUrl());
            player.play();
            markEventBeingPlayed(itemModel);
        }
    };

    self.pause = function () {
        if (player) {
            markAllEventsStopped();
            player.pause();
        }
    };
    //#endregion
};