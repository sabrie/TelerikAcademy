/*
Refactor the following examples to produce code with well-named 
identifiers in JavaScript

function _ClickON_TheButton(THE_event, argumenti) {
    var moqProzorec = window;
    var brauzyra = moqProzorec.navigator.appCodeName;
    var ism = brauzyra == "Mozilla";
    if (ism) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}
*/

function isMozilla() {
    if (navigator.appCodeName === 'Mozilla') {
        alert('Yes');
    }
    else {
        alert('No');
    }    
}

isMozilla();