/*global jQuery, getRandomColor, isValidColor */

void function setContentStyle($) {
    'use strict';

    var $items = $('.tm_t');
    $items.each(function updateItemStyle(_, item) {
        var $item = $(item);
        var itemTitle = $item.find('h3').text();
        $item.css('background-color', itemTitle);

        if (!isValidColor($item.css('background-color'))) {
            $item.css('background-color', getRandomColor());
        }
    });
    $items.on('click', function flipColor() {
        var $item = $(this);
        var newColor = $item.data('previous-color') || getRandomColor();
        $item.data('previous-color', $item.css('background-color'));
        $item.css('background-color', newColor);
    });
}(jQuery);
