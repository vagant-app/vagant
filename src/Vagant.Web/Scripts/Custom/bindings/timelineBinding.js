(function ($, ko) {

    var timeline = null;

    function getDateConfigurationObjectsArray(dates) {
        var result = [];

        if (dates) {
            ko.utils.arrayForEach(dates, function (date) {
                result.push({
                    on: date
                });
            });
        }
        return result;
    }

    function updateEvents(dates) {
        if (timeline) {
            var pluginModel = timeline.data('jqtimeline');

            var existingEvents = pluginModel.getAllEvents();
            if (existingEvents && existingEvents.length > 0) {
                ko.utils.arrayForEach(existingEvents, function (eventObject) {
                    pluginModel.deleteEvent(eventObject.id);
                });
            }

            if (dates) {
                var dateObjects = getDateConfigurationObjectsArray(dates);
                ko.utils.arrayForEach(dateObjects, function (eventObject) {
                    pluginModel.addEvent(eventObject);
                });
            }
        }
    }

    function setTimeline(element, valueAccessor, allBindings) {
        var options = valueAccessor();

        if (options.dates && options.callback) {
            var unwrappedDatesArray = ko.unwrap(options.dates);
            timeline = $(element).jqtimeline({
                events: unwrappedDatesArray,
                numYears: 1,
                startYear: 2016,
                click: options.callback,
                gap: 90
            });
        }
    }

    function updateTimeline(element, valueAccessor, allBindings) {
        var options = valueAccessor();
        if (options.dates) {
            var unwrappedDatesArray = ko.unwrap(options.dates);
            updateEvents(unwrappedDatesArray);
        }
    }

    ko.bindingHandlers.timeline = {
        init: function (element, valueAccessor, allBindings) {
            setTimeline(element, valueAccessor, allBindings);
        },
        update: function (element, valueAccessor, allBindings) {
            updateTimeline(element, valueAccessor, allBindings);
        }
    };

})(jQuery, ko);