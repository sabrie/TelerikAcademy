/*
    Write a script that shims querySelector and querySelectorAll in older browsers
*/

// converts LiveNodeList to StaticNodeList
function toArray(arrayLike) {
    var result = [];

    var i, length;

    for (i = 0, length = arrayLike.length; i < length; i++)
        result.push(arrayLike[i]);

    return result;
}

// works only for the following CSS selectors - #idName, .className, tagName
function querySelectorAllShim(selector) {
    if (selector.match(/^#/))
        return [document.getElementById(selector.substr(1))];

    if (selector.match(/^\./))
        return toArray(document.getElementsByClassName(selector.substr(1)));

    return toArray(document.getElementsByTagName(selector));
}

document.querySelectorAll = document.querySelectorAll || querySelectorAllShim;

function querySelectorShim(selector) {
    return document.querySelectorAll(selector)[0];
}

document.querySelector = document.querySelector || querySelectorShim;

console.log(querySelectorAllShim('#id'));
console.log(querySelectorAllShim('.className'));
console.log(querySelectorAllShim('p'));
console.log(querySelectorShim('.className'));
