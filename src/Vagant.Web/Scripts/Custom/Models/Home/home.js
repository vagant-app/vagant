var vagantApp = window.vagantApp || {};
vagantApp.home = vagantApp.home || {};

vagantApp.home.HomePage = function () {
    var self = this;

    self.timeline = new vagantApp.home.Timeline();
};

$(function () {
    ko.applyBindings(new vagantApp.home.HomePage());
});