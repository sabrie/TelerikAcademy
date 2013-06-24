/*
Create a text area and two inputs with type="color"
Make the font color of the text area as the value of the first color input
Make the background color of the text area as the value of the second input
*/

var textarea = document.getElementById('textarea');

var foregroundColorInput = document.getElementById('js-foreground-color');

foregroundColorInput.addEventListener('change', function () {
    textarea.style.color = this.value;
});

var backgroundColorInput = document.getElementById('js-background-color');

backgroundColorInput.addEventListener('change', function () {
    textarea.style.backgroundColor = this.value;
});

// Reshenie na kolega - ot domashnite
//var textarea = document.getElementById("colorArea");

//function setFontColor() {
//    return textarea.style.color = document.getElementById("fontColor").value;
//}

//function setBackgroundColor() {
//    return textarea.style.backgroundColor = document.getElementById("backgroundColor").value;
//}