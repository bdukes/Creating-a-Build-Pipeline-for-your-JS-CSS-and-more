/*global jQuery */

void function doSomething($) {
    'use strict';

    $('.tm_t').each((i, item) => $(item).css('background-color', $('h3', item).text()));
}(jQuery);
