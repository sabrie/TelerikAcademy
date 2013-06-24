/* Write a script that creates a number of div elements.Each div element must have the following
        Random width and height between 20px and 100px
        Random background color
        Random font color
        Random position on the screen (position:absolute)
        A strong element with text "div" inside the div
        Random border-radius
        Random border color
        Random border-width between 1px and 20px
*/

function generateRandomDiv() {
    var div = document.createElement("div");

    div.innerHTML = "<strong>div</strong>";

    div.style.width = generateRandomInt(20, 100) + "px";
    div.style.height = generateRandomInt(20, 100) + "px";

    div.style.backgroundColor = generateRandomHexColor();
    div.style.color = generateRandomHexColor();

    div.style.left = generateRandomInt(0, 100) + "%";
    div.style.top = generateRandomInt(0, 100) + "%";
    
    div.style.borderRadius = generateRandomInt(5, 25) + "px";
    div.style.borderColor = generateRandomHexColor();
    div.style.borderWidth = generateRandomInt(1, 20) + "px";
       
    return div;
}

function generateRandomInt(min, max) {
    var length = max - min + 1;
    var randomInt = Math.floor(Math.random() * length) + min;

    return randomInt;
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
    var decimalToHex = decimal.toString(16);

    return decimalToHex;
}

var numberOfRandomDivs = 120;

for (var i = 0; i < numberOfRandomDivs; i++) {
    document.body.appendChild(generateRandomDiv());
}