/*global jQuery */

import { getRandomColor, isValidColor, } from '../Shared/Common.js';

const $ = jQuery;
const $items = $('.tm_t');
$items.each((_, item) => {
    const $item = $(item);
    const itemTitle = $item.find('h3').text();
    $item.css('background-color', itemTitle);

    if (!isValidColor($item.css('background-color'))) {
        $item.css('background-color', getRandomColor());
    }
});
$items.on('click', function flipColor() {
    const $item = $(this);
    const newColor = $item.data('previous-color') || getRandomColor();
    $item.data('previous-color', $item.css('background-color'));
    $item.css('background-color', newColor);
});
