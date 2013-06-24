/*
Create a module that works with moving div elements. Implement functionality for:
    Add new moving div element to the DOM
        The module should generate random background, font and border colors for the div element
        All the div elements are with the same width and height
    The movements of the div elements can be either circular or rectangular
    The elements should be moving all the time
*/

function $(selector) {
    if (!(this instanceof $)) return new $(selector)

    this.elements = document.querySelectorAll(selector);
}

$.prototype.append = function (child) {
    var i;

    for (i = 0; i < this.elements.length; i++) {
        this.elements[i].appendChild(child.cloneNode(true));
    }
};

$.prototype.remove = function (selector) {
    var i, j, children;

    for (i = 0; i < this.elements.length; i++) {
        children = this.elements[i].querySelectorAll(selector);

        for (j = 0; j < children.length; j++) {
            children[j].parentNode.removeChild(children[j]);
        }
    }
};

$.prototype.on = function (event, callback) {
    var i;

    for (i = 0; i < this.elements.length; i++) {
        this.elements[i].addEventListener(event, callback);
    }
};

// rotate elements in circular
(function () {
    var radius = 100;
    var currentAngle = 0;

    (function animLoop() {
        var i, anglePerCircle;

        var circles = document.querySelectorAll('.circle');

        var stepAngle = 2 * Math.PI / circles.length;

        for (i = 0; i < circles.length; i++) {
            anglePerCircle = stepAngle * i

            circles[i].style.left = Math.cos(currentAngle + anglePerCircle) * radius + 'px';
            circles[i].style.top = Math.sin(currentAngle + anglePerCircle) * radius + 'px';
        }

        currentAngle += 0.009;
        currentAngle %= 2 * Math.PI;

        requestAnimationFrame(animLoop);
    }());

    // attaches elements to the mouse move
    //(function () {
    //    window.addEventListener('mousemove', function (e) {
    //        var i;

    //        var circles = document.querySelectorAll('.circle');

    //        for (i = 0; i < circles.length; i++) {
    //            circles[i].style.marginLeft = e.clientX + 'px';
    //            circles[i].style.marginTop = e.clientY + 'px';
    //        }
    //    });
    //}());
}());

function generateRandomDiv() {
    var div = document.createElement("div");

    div.innerHTML = "<strong>div</strong>";

    div.style.backgroundColor = generateRandomHexColor();
    div.style.color = generateRandomHexColor();

    div.style.borderColor = generateRandomHexColor();

    return div;
}

function generateRandomHexColor() {
    var r = generateRandomHexValue();
    var g = generateRandomHexValue();
    var b = generateRandomHexValue();

    var rgb = "#" + r + g + b;

    return rgb;
}

function generateRandomHexValue() {
    var decimal = generateRandomInt(0, 256)
    var decimalToHex = decimal.toString(16);;

    return decimalToHex;
}

function generateRandomInt(min, max) {
    var length = max - min + 1;
    var randomInt = Math.floor(Math.random() * length) + min;

    return randomInt;
}

// adds moving elements on clicking left mouse button
$('body').on('click', function () {
    var div = generateRandomDiv();

    div.className = 'circle';

    $('body').append(div);
});

// removes moving elements on clicking right mouse button
$('body').on('contextmenu', function (e) {
    e.preventDefault();

    $('body').remove('div:first-of-type');
});