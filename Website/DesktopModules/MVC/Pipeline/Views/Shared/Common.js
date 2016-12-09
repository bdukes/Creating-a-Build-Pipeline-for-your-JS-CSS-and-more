/*global jQuery */

void function defineCommonFunctions($) {
    'use strict';

    // from https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Math/random
    function getRandomIntInclusive(min, max) {
        min = Math.ceil(min);
        max = Math.floor(max);
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    window.getRandomColor = function getRandomColor() {
        var r = getRandomIntInclusive(0, 255);
        var g = getRandomIntInclusive(0, 255);
        var b = getRandomIntInclusive(0, 255);
        return 'rgb(' + r + ',' + g + ',' + b + ')';
    }
    
    window.isValidColor = function isValidColor (color) {
        return /rgb\(\d+,\s*\d+,\s*\d+\)/.test(color);
    }
}(jQuery);
