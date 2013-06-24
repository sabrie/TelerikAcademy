/*
Create a module for working with DOM. The module should have the following functionality
    Add DOM element to parent element given by selector
    Remove element from the DOM  by given selector
    Attach event to given selector by given event type and event hander
    Add elements to buffer, which appends them to the DOM when their count for some selector becomes 100
        The buffer contains elements for each selector it gets
    Get elements by CSS selector
    The module should reveal only the methods
*/

// Gets elements by CSS selector
function $(selector) {
    if (!(this instanceof $))
        return new $(selector)

    this.elements = Array.prototype.slice.call(document.querySelectorAll(selector));
}

// Add DOM element to parent element given by selector
$.prototype.append = function (child) {
    var i;

    for (i = 0; i < this.elements.length; i++) {
        this.elements[i].appendChild(child.cloneNode(true));
    }
};

// Remove element from the DOM by given selector
$.prototype.remove = function (selector) {
    var i, j, children;

    for (i = 0; i < this.elements.length; i++) {
        children = this.elements[i].querySelectorAll(selector);

        for (j = 0; j < children.length; j++) {
            children[j].parentNode.removeChild(children[j]);
        }
    }
}

// Attach event to given selector by given event type and event hander
$.prototype.on = function (event, callback) {
    var i;

    for (i = 0; i < this.elements.length; i++) {
        this.elements[i].addEventListener(event, callback);
    }
}

// Add elements to buffer, which appends them to the DOM when their count for some selector becomes 10
$.prototype.addToBuffer = function (el, count) {
    this.buffer = this.buffer || []

    this.buffer.push(el);

    if (this.buffer.length === count) {
        for (var i = 0; i < this.buffer.length; i++) {
            this.append(this.buffer[i])
        }
        this.buffer = []
    }
}

// appends div elements to body element by left click on the body
$('body').on('click', function () {
    var div = document.createElement('div');
    
    $('body').append(div);

});

// removes the div elements from body element by right click - one by one
$('body').on('contextmenu', function (e) {
    e.preventDefault();

    $('body').remove('div:first-of-type');
});

// creates <li> elements and adds them to the buffer 
// (appends them to the DOM) when their count reach given number 
{
    var ul = $('ul');
    var li = document.createElement('li');
    li.textContent = 'List item';
    var elementsCreated = 10;

    for (var i = 1; i <= elementsCreated; i++) {
        ul.addToBuffer(li, elementsCreated);
    }

    //setTimeout(function () {
    //    div.addToBuffer(p.cloneNode(true));
    //}, 1000);
}
