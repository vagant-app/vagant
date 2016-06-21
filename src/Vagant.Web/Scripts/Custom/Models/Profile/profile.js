var vagantApp = window.vagantApp || {};
vagantApp.profile = vagantApp.profile || {};

vagantApp.profile.ProfilePage = function () {
    var self = this;

    self.contactInformation = new Profile.constructors.ContactInformation();
    self.achievements = new Profile.constructors.Achievements();
    self.profileHistory = new Profile.constructors.ProfileHistory();
};

$(function () {
    ko.applyBindings(new vagantApp.profile.ProfilePage());
});