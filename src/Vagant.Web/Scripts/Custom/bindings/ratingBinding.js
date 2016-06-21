(function ($, ko) {

    function setRating(element, valueAccessor, allBindings) {
        var options = valueAccessor();

        if (options.initialValue && options.changeCallback) {

            $(element).val(options.initialValue());

            $(element).rating({
                min: 0,
                max: 5,
                step: 0.5,
                size: 'xs',
                showClear: false,
                showCaption: false,
                disabled: !options.isEditable()
            });

            $(element).on('rating.change', function () {
                if (typeof options.changeCallback === 'function') {
                    options.changeCallback(element, $(element).val());
                }
            });
        }
    }

    ko.bindingHandlers.rating = {
        init: function (element, valueAccessor, allBindings) {
            setRating(element, valueAccessor, allBindings);
        }
    };

})(jQuery, ko);