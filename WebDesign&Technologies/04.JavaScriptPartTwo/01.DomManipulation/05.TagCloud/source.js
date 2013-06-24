/*
Create a tag cloud:
Visualize a string of tags (strings) in a given container
By given minFontSize and maxFontSize, generate the tags with different font-size, depending on the number of occurrences
*/

var tags = [
      "cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress", "xaml", "js", "http",
      "web", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript",
      "http", "http", "CMS"
];

var MIN_FONT_SIZE = 17;
var MAX_FONT_SIZE = 42;

function countBy(array) {
    var result = {};

    var lowerCasedArray = tags.map(function (el) {
        return el.toLowerCase();
    });

    lowerCasedArray.forEach(function (el) {
        result[el] = result[el] || 0;

        result[el]++;
    });

    return result;
}

var dictionary = countBy(tags);

function min(obj) {
    var result = Infinity;

    for (var el in obj) {
        result = Math.min(result, obj[el]);
    }

    return result;
}

function max(obj) {

    var result = -Infinity;

    for (var el in obj) {
        result = Math.max(result, obj[el]);
    }

    return result;
}

var length = max(dictionary) - min(dictionary);
var fontLength = MAX_FONT_SIZE - MIN_FONT_SIZE + 1;
var step = fontLength / length;

var span;
var el;
var size;

for (el in dictionary) {
    span = document.createElement('span');

    span.textContent = el;
    span.style.fontSize = (MIN_FONT_SIZE + (dictionary[el] - 1) * step) + "px";

    document.body.appendChild(span);
}
